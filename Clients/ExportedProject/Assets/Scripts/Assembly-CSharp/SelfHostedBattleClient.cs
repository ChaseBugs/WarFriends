using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>
/// Main-thread Unity adapter for the self-hosted match protocol. It never creates
/// Photon rooms or grants rewards. Configure with a participant-specific grant
/// supplied by the trusted allocator (or the local validation harness).
/// </summary>
public sealed class SelfHostedBattleClient : MonoBehaviour, SelfHostedBattleClientAdapter
{
    [SerializeField] private string backendEndpoint = "http://127.0.0.1:8080/";
    [SerializeField] private int matchmakingTimeoutSeconds = 120;
    [SerializeField] private bool allowLocalHttp = true;
    public static SelfHostedBattleClient Active { get; private set; }
    public event Action<MatchSnapshot> StateReceived;
    public event Action FullSnapshotRebuild;
    // Handlers run on Unity's synchronization context. Failed handlers cause
    // the same event ID to be fetched again; side effects must be idempotent.
    public event Action<MatchEvent> CombatEventReceived;
    public event Action<IReadOnlyList<BarrelViewState>> BarrelStateReceived;
    public event Action<MatchArmyBatch> ArmyOffersReceived;
    public event Action<IReadOnlyList<BattleArmyEntityState>> ArmyEntitiesReceived;
    public event Action<MatchProjectileBatch> ProjectileScanReceived;
    public event Action<string> ConnectionError;
    public event Action<SelfHostedRoomPhase> RoomPhaseChanged;
    public event Action CardsSelectedByBoth;
    public MatchSnapshot State { get; private set; }
    public string LocalPlayerId { get; private set; }
    public IReadOnlyList<BattlePlayerView> PlayerViews { get; private set; }
    public ulong ProcessedEventId { get; private set; }
    public bool IsConnected { get; private set; }
    public SelfHostedPhotonCompatibility PhotonCompatibility { get; private set; }
    private MatchConnection connection;
    private SelfHostedRoomLifecycle roomLifecycle;
    private CancellationTokenSource lifetime;
    private CancellationTokenSource matchmaking;
    private BackendClient matchmakingBackend;
    private string matchmakingToken;
    private bool polling;
    private float nextPoll;
    private float nextBarrelPoll;
    private float nextArmyPoll;
    private float nextArmyEntityPoll;
    private float nextProjectileScan;
    private bool destroyed;
    private bool reconnecting;
    private string reconnectRequestId;
    private Task reconnectTask;
    private int reconnectAttempts;
    private float nextReconnectAttempt;
    private bool reconnectFailureReported;
    private bool forfeitCommandPending;
    private bool forfeitRecoveryActive;
    private bool cardsSelectedByBothRaised;
    private readonly SemaphoreSlim eventDelivery = new SemaphoreSlim(1, 1);
    private readonly Dictionary<string, SelfHostedRiflePoseRenderer> rifleViews = new Dictionary<string, SelfHostedRiflePoseRenderer>(StringComparer.Ordinal);
    private readonly Dictionary<string, Transform> rifleRoots = new Dictionary<string, Transform>(StringComparer.Ordinal);
    private List<BarrelSceneIdentity> barrelCatalog;
    private BarrelStateTracker barrelTracker;
    private string matchId;
    private string manifestHash;
    private SpawningManagerDeathMatch armyManager;
    private SelfHostedDeathMatchBridge deathMatchBridge;
    public bool IsMatchmaking { get { return matchmaking != null; } }
    public bool OwnsMatch { get { return connection != null; } }
    public bool ReconnectFailed { get { return reconnectFailureReported; } }
    public bool IsReconnecting { get { return reconnectTask != null || reconnecting ||
        connection != null && !IsConnected && (reconnectRequestId != null || reconnectAttempts > 0); } }

    // The simulation tick stops during a disconnect. PauseHostTick keeps moving,
    // so it is the only clock that can measure the Worker's grace deadline.
    public bool TryGetOpponentReconnectSeconds(out float seconds)
    {
        if (!IsConnected) { seconds = 0f; return false; }
        return TryGetOpponentReconnectSeconds(State, LocalPlayerId, out seconds);
    }

    public static bool TryGetOpponentReconnectSeconds(MatchSnapshot snapshot,
        string localPlayerId, out float seconds)
    {
        seconds = 0f;
        if (snapshot == null || snapshot.PauseHostTick == 0 || string.IsNullOrEmpty(localPlayerId)) return false;
        foreach (var player in snapshot.Players)
        {
            if (player.PlayerId == localPlayerId || !player.Reconnecting) continue;
            if (player.ReconnectDeadlineHostTick <= snapshot.PauseHostTick) return true;
            seconds = (float)(player.ReconnectDeadlineHostTick - snapshot.PauseHostTick) / 30f;
            return true;
        }
        return false;
    }

    public static SelfHostedBattleClient GetOrCreate()
    {
        SelfHostedBattleClient current = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
        if (current != null) return current;
        GameObject owner = new GameObject("SelfHostedBattleClient");
        UnityEngine.Object.DontDestroyOnLoad(owner);
        return owner.AddComponent<SelfHostedBattleClient>();
    }

    public Task MatchmakeWithRecoveredSession()
    {
        GameLoginManager login = Singleton<GameLoginManager>.instance;
        if (login == null || string.IsNullOrEmpty(login.accessToken))
            throw new InvalidOperationException("The recovered Backend session is not available.");
        return MatchmakeAndConnect(backendEndpoint, login.accessToken, matchmakingTimeoutSeconds, allowLocalHttp);
    }

    public async Task MatchmakeAndConnect(string backendEndpoint, string accessToken, int timeoutSeconds, bool allowLocalHttp)
    {
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        if (connection != null || matchmaking != null) throw new InvalidOperationException("A self-hosted match operation is already active.");
        Uri endpoint;
        if (!Uri.TryCreate(backendEndpoint, UriKind.Absolute, out endpoint))
            throw new ArgumentException("A valid Backend endpoint is required.", nameof(backendEndpoint));
        var source = new CancellationTokenSource();
        matchmaking = source;
        matchmakingToken = accessToken;
        matchmakingBackend = new BackendClient(endpoint, allowLocalHttp);
        try
        {
            MatchConnectionGrant grant = await matchmakingBackend.FindMatchAsync(accessToken,
                TimeSpan.FromSeconds(timeoutSeconds), source.Token);
            source.Token.ThrowIfCancellationRequested();
            await Connect(grant);
        }
        finally
        {
            if (matchmaking == source) matchmaking = null;
            source.Dispose();
            if (matchmakingBackend != null) { matchmakingBackend.Dispose(); matchmakingBackend = null; }
            matchmakingToken = null;
        }
    }

    public async Task CancelMatchmaking()
    {
        var source = matchmaking;
        var backend = matchmakingBackend;
        var token = matchmakingToken;
        if (source == null) return;
        source.Cancel();
        if (backend != null && !string.IsNullOrEmpty(token))
        {
            try { await backend.CancelMatchQueueAsync(token, CancellationToken.None); }
            catch { }
        }
    }

    /// <summary>Route the original deathmatch army cards through this connected
    /// match. The scene owner must call this after Connect and before play.</summary>
    public async Task BindArmyManager(SpawningManagerDeathMatch manager)
    {
        if (!IsConnected || manager == null || armyManager != null)
            throw new InvalidOperationException("Connect and bind one army manager per match.");
        manager.BindSelfHosted(this);
        armyManager = manager;
        try { await RefreshArmy(); }
        catch
        {
            manager.UnbindSelfHosted(this);
            armyManager = null;
            throw;
        }
    }

    /// <summary>Bind a rig whose animation updates are owned by the self-hosted
    /// presentation path. The scene owner must stop other writers to this rig.</summary>
    public void BindRifleView(string playerId, Transform root, SoldierAnimationController animator)
    {
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        Guid parsed;
        if (!Guid.TryParseExact(playerId, "N", out parsed) || playerId != playerId.ToLowerInvariant() || rifleViews.ContainsKey(playerId) ||
            root != null && rifleRoots.ContainsValue(root))
            throw new ArgumentException("One canonical player identity per rifle view.", nameof(playerId));
        var originalController = root == null ? null : root.GetComponent<PlayerController>();
        if (animator != null && animator.enabled || originalController != null && originalController.enabled)
            throw new InvalidOperationException("Disable original player and animation writers before binding the server pose view.");
        var renderer = new SelfHostedRiflePoseRenderer(root, animator,
            playerId != LocalPlayerId);
        BattlePlayerState current = null;
        if (State != null) foreach (var player in State.Players) if (player.PlayerId == playerId) { current = player; break; }
        if (current != null && current.RiflePose != null) renderer.Apply(current);
        rifleViews.Add(playerId, renderer);
        rifleRoots.Add(playerId, root);
    }

    public void UnbindRifleView(string playerId) { rifleViews.Remove(playerId); rifleRoots.Remove(playerId); }

    public void ActivateDeathMatchScene(PlayerController local, PlayerController other)
    {
        if (!IsConnected || deathMatchBridge != null || local == null || other == null)
            throw new InvalidOperationException("One connected self-hosted DeathMatch scene is required.");
        deathMatchBridge = gameObject.AddComponent<SelfHostedDeathMatchBridge>();
        deathMatchBridge.Configure(this, local, other);
    }

    /// <summary>Bind the reviewed map's collider-to-scene-file-ID identities.
    /// The adapter never guesses an identity from a hierarchy name.</summary>
    public void BindBarrelCatalog(IEnumerable<BarrelSceneIdentity> source)
    {
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        if (source == null || barrelCatalog != null || barrelTracker != null)
            throw new InvalidOperationException("Bind one source barrel catalog per match.");
        var candidate = new List<BarrelSceneIdentity>(source);
        var tracker = connection == null ? null :
            new BarrelStateTracker(matchId, manifestHash, candidate);
        barrelCatalog = candidate;
        barrelTracker = tracker;
    }

    public async Task Connect(MatchConnectionGrant grant, ulong processedEventId = 0)
    {
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        if (connection != null) throw new InvalidOperationException("This component already owns a match session.");
        var preparedTracker = barrelCatalog == null ? null :
            new BarrelStateTracker(grant.MatchId, grant.ManifestHash, barrelCatalog);
        connection = new MatchConnection(grant);
        PlayerViews = connection.PlayerViews;
        Active = this;
        roomLifecycle = new SelfHostedRoomLifecycle(connection);
        roomLifecycle.PhaseChanged += OnRoomPhaseChanged;
        PhotonCompatibility = new SelfHostedPhotonCompatibility(roomLifecycle);
        matchId = grant.MatchId;
        LocalPlayerId = grant.PlayerId;
        manifestHash = grant.ManifestHash;
        barrelTracker = preparedTracker;
        lifetime = new CancellationTokenSource();
        ProcessedEventId = processedEventId;
        var token = lifetime.Token;
        try
        {
            var reply = await roomLifecycle.ConnectAsync(token);
            token.ThrowIfCancellationRequested();
            Apply(reply);
            IsConnected = true;
            if (barrelTracker != null) await RefreshBarrels();
            if (ArmyEntitiesReceived != null) await RefreshArmyEntities();
        }
        catch
        {
            Close();
            throw;
        }
    }

    /// <summary>Ask the Backend for a fresh capability using the recovered login session.</summary>
    public Task ReconnectWithRecoveredSession()
    {
        if (reconnectTask != null) return reconnectTask;
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        if (connection == null || string.IsNullOrEmpty(matchId))
            throw new InvalidOperationException("There is no self-hosted match to reconnect.");
        GameLoginManager login = Singleton<GameLoginManager>.instance;
        if (login == null || string.IsNullOrEmpty(login.accessToken))
            throw new InvalidOperationException("The recovered Backend session is not available.");
        Task attempt = ReconnectWithToken(login.accessToken);
        if (attempt.IsCompleted) return attempt;
        reconnectTask = attempt;
        return attempt;
    }

    private async Task ReconnectWithToken(string accessToken)
    {
        bool grantReturned = false;
        try
        {
            IsConnected = false; // Stop new scene input while the Backend issues a grant.
            if (reconnectRequestId == null) reconnectRequestId = Guid.NewGuid().ToString("N");
            using (var backend = new BackendClient(new Uri(backendEndpoint), allowLocalHttp))
            {
                var grant = await backend.ReconnectMatchAsync(matchId, reconnectRequestId,
                    accessToken, CancellationToken.None);
                grantReturned = true;
                await Reconnect(grant);
                reconnectRequestId = null;
                reconnectAttempts = 0;
                reconnectFailureReported = false;
            }
        }
        catch
        {
            if (grantReturned)
            {
                // The Worker may already have admitted this grant. A new
                // request ID asks it for a higher session generation.
                reconnectRequestId = null;
                IsConnected = false;
            }
            reconnectAttempts++;
            nextReconnectAttempt = Time.realtimeSinceStartup + Mathf.Min(2f * reconnectAttempts, 5f);
            throw;
        }
        finally { reconnectTask = null; }
    }

    /// <summary>
    /// Replace the transport while keeping the current scene, presenters and
    /// callback-committed event cursor. A local test may pass a trusted grant.
    /// </summary>
    public async Task Reconnect(MatchConnectionGrant grant)
    {
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        if (reconnecting || connection == null || lifetime == null ||
            State == null || State.Phase == BattlePhase.Ended || State.Phase == BattlePhase.Aborted)
            throw new InvalidOperationException("A running self-hosted match is required for reconnect.");
        if (grant == null || grant.MatchId != matchId || grant.PlayerId != LocalPlayerId ||
            grant.ManifestHash != manifestHash)
            throw new InvalidOperationException("Replacement grant differs from the active match.");

        reconnecting = true;
        IsConnected = false;
        var oldConnection = connection;
        var oldLifecycle = roomLifecycle;
        var oldLifetime = lifetime;
        oldLifetime.Cancel();
        try
        {
            // Stop an old poll before replacing the scene's transport fields.
            while (polling) await Task.Yield();
            await eventDelivery.WaitAsync();
            eventDelivery.Release();
            MatchPendingCommand unresolved = await oldConnection.CapturePendingAsync(CancellationToken.None);

            var nextConnection = new MatchConnection(grant);
            var nextLifecycle = new SelfHostedRoomLifecycle(nextConnection);
            var nextLifetime = new CancellationTokenSource();
            bool installed = false;
            try
            {
                if (!SamePlayerViews(PlayerViews, nextConnection.PlayerViews))
                    throw new InvalidOperationException("Replacement grant changed the match roster view.");
                await nextLifecycle.ConnectAsync(nextLifetime.Token);
                if (unresolved != null)
                {
                    await nextConnection.RestorePendingAsync(unresolved, nextLifetime.Token);
                    await nextConnection.RetryPendingAsync(nextLifetime.Token);
                }
                var current = await nextConnection.PollAsync(nextLifetime.Token);
                var refreshedBarrels = barrelCatalog == null ? null :
                    new BarrelStateTracker(matchId, manifestHash, barrelCatalog);
                if (refreshedBarrels != null)
                    refreshedBarrels.Apply(await nextConnection.PollBarrelsAsync(nextLifetime.Token));
                IReadOnlyList<BattleArmyEntityState> entities = ArmyEntitiesReceived == null ? null :
                    await nextConnection.FetchArmyEntitiesAsync(nextLifetime.Token);
                var offers = ArmyOffersReceived == null ? null :
                    await nextConnection.PollArmyAsync(nextLifetime.Token);
                var projectiles = ProjectileScanReceived == null || !current.Snapshot.ProjectilesTruncated ? null :
                    await nextConnection.FetchProjectilesAsync(nextLifetime.Token);
                ulong? snapshotEventBaseline = null;
                if (CombatEventReceived != null)
                {
                    try { await nextConnection.PollEventsAsync(ProcessedEventId, nextLifetime.Token); }
                    catch (MatchEventCursorExpiredException expired)
                    {
                        // All presenters below receive fresh authoritative state.
                        // Only after they succeed may we skip events older than
                        // that snapshot. Later events still replay normally.
                        snapshotEventBaseline = ValidateSnapshotEventBoundary(current.Snapshot,
                            ProcessedEventId, expired.LatestEventId);
                    }
                }

                if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
                oldLifecycle.PhaseChanged -= OnRoomPhaseChanged;
                oldLifecycle.Close();
                oldLifetime.Dispose();
                connection = nextConnection;
                roomLifecycle = nextLifecycle;
                lifetime = nextLifetime;
                PhotonCompatibility = new SelfHostedPhotonCompatibility(nextLifecycle);
                PlayerViews = nextConnection.PlayerViews;
                barrelTracker = refreshedBarrels;
                nextLifecycle.PhaseChanged += OnRoomPhaseChanged;
                State = null;
                foreach (var renderer in rifleViews.Values) renderer.ResetRemote();
                IsConnected = true;
                installed = true;
                if (FullSnapshotRebuild != null) FullSnapshotRebuild();
                Apply(current);
                if (refreshedBarrels != null && BarrelStateReceived != null)
                    BarrelStateReceived(refreshedBarrels.Snapshot());
                if (entities != null && ArmyEntitiesReceived != null)
                    ArmyEntitiesReceived(entities);
                if (offers != null && ArmyOffersReceived != null)
                    ArmyOffersReceived(offers.Clone());
                if (projectiles != null && ProjectileScanReceived != null)
                    ProjectileScanReceived(projectiles);
                if (snapshotEventBaseline.HasValue)
                    ProcessedEventId = snapshotEventBaseline.Value;
                if (CombatEventReceived != null) await DispatchEvents();
                nextPoll = Time.realtimeSinceStartup + 0.1f;
            }
            finally
            {
                if (!installed)
                {
                    nextLifecycle.Close();
                    nextLifetime.Dispose();
                }
            }
        }
        finally { reconnecting = false; }
    }

    /// <summary>Keep lost events behind the same state boundary used to rebuild the scene.</summary>
    public static ulong ValidateSnapshotEventBoundary(MatchSnapshot snapshot,
        ulong processedEventId, ulong hostLatestEventId)
    {
        if (snapshot == null || snapshot.LatestEventId < processedEventId ||
            snapshot.LatestEventId > hostLatestEventId)
            throw new InvalidOperationException("The full snapshot has no valid event boundary.");
        return snapshot.LatestEventId;
    }

    private static bool SamePlayerViews(IReadOnlyList<BattlePlayerView> oldViews,
        IReadOnlyList<BattlePlayerView> newViews)
    {
        if (oldViews == null || newViews == null || oldViews.Count != newViews.Count) return false;
        for (int i = 0; i < oldViews.Count; i++)
            if (!oldViews[i].Equals(newViews[i])) return false;
        return true;
    }

    public Task Ready() { return ExecuteReady(); }
    public Task ReadyAsync() { return Ready(); }
    public bool DispatchRpc(string method, params object[] arguments)
    {
        if (destroyed || !IsConnected) return false;
        return new SelfHostedRpcRouter(this).TryDispatch(method, arguments);
    }
    private async Task ExecuteReady()
    {
        if (!IsConnected || roomLifecycle == null) throw new InvalidOperationException("No self-hosted room is connected.");
        var active = connection;
        var reply = await roomLifecycle.MarkReadyAsync(lifetime.Token);
        if (IsConnected && active == connection) Apply(reply);
    }
    public Task Fire(Vector3 target) { return Execute(c => c.FireAsync(target.x, target.y, target.z, lifetime.Token)); }
    public Task MinigunHold(bool pressed,Vector3 target) { return Execute(c => c.MinigunHoldAsync(pressed,target.x,target.y,target.z,lifetime.Token)); }
    public Task SniperAim(bool pressed,bool cancelled,Vector3 target) { return Execute(c => c.SniperAimAsync(pressed,cancelled,target.x,target.y,target.z,lifetime.Token)); }
    public Task BazookaHold(bool pressed,Vector3 target) { return Execute(c => c.BazookaHoldAsync(pressed,target.x,target.y,target.z,lifetime.Token)); }
    public Task GrenadeLauncherThrow(Vector3 target) { return Execute(c => c.GrenadeLauncherThrowAsync(target.x,target.y,target.z,lifetime.Token)); }
    public Task GrenadeSwipeThrow(Vector3 start,Vector3 end,float heldSeconds) { return Execute(c => c.GrenadeSwipeThrowAsync(start.x,start.y,start.z,end.x,end.y,end.z,heldSeconds,lifetime.Token)); }
    public Task Reload() { return Execute(c => c.ReloadAsync(lifetime.Token)); }
    public Task SwitchWeapon(int slot) { return Execute(c => c.SwitchWeaponAsync(slot, lifetime.Token)); }
    public async void RequestWeaponSwitch(int inventoryIndex)
    {
        try
        {
            BattlePlayerView local = null;
            if (PlayerViews != null) foreach (BattlePlayerView view in PlayerViews) if (view.PlayerId == LocalPlayerId) { local = view; break; }
            if (local == null || inventoryIndex < 0 || inventoryIndex >= local.Weapons.Count)
                throw new InvalidOperationException("The requested recovered weapon slot is unavailable.");
            await SwitchWeapon(local.Weapons[inventoryIndex].Slot);
        }
        catch (Exception exception)
        {
            Debug.LogError("Self-hosted weapon switch failed: " + exception.GetType().Name);
            if (ConnectionError != null) ConnectionError(exception.Message);
        }
    }
    public Task MoveCover(int direction) { return Execute(c => c.MoveCoverAsync(direction, lifetime.Token)); }
    /// <summary>
    /// Co-op Shield.GetLock asks for a specific defend point. The host may
    /// choose only that point; the caller waits for its accepted movement.
    /// </summary>
    public async Task<bool> RequestCoopCover(int direction, int targetCoverIndex)
    {
        if (!IsConnected || connection == null || State == null ||
            State.Coop == null)
            throw new InvalidOperationException(
                "A connected co-op match is required for a shield lock.");

        MatchConnection active = connection;
        MatchReply reply = await active.MoveCoopCoverAsync(direction,
            targetCoverIndex, lifetime.Token);
        if (!IsConnected || active != connection)
            return false;
        Apply(reply);
        return reply.Code == "moving";
    }
    public Task Forfeit() { return Execute(c => c.ForfeitAsync(lifetime.Token)); }
    public async Task ForfeitWithRecovery()
    {
        if (!OwnsMatch) throw new InvalidOperationException("There is no self-hosted match to forfeit.");
        if (forfeitRecoveryActive) throw new InvalidOperationException("Forfeit recovery is already running.");
        forfeitRecoveryActive = true;
        try
        {
            Exception lastFailure = null;
            for (int attempt = 0; attempt < 3 && !destroyed; attempt++)
            {
                if (State != null && (State.Phase == BattlePhase.Ended || State.Phase == BattlePhase.Aborted))
                { forfeitCommandPending = false; return; }
                try
                {
                    if (!IsConnected) await ReconnectWithRecoveredSession();
                    if (forfeitCommandPending)
                        await RetryPending(); // Same command ID if the terminal reply was lost.
                    else
                    {
                        forfeitCommandPending = true;
                        await Forfeit();
                    }
                    forfeitCommandPending = false;
                    return; // Apply publishes the Worker's terminal snapshot.
                }
                catch (Exception failure)
                {
                    lastFailure = failure;
                    // A consumed Forfeit makes the match terminal; the Worker will
                    // not issue another reconnect grant. Retry its original receipt.
                    if (reconnectFailureReported || destroyed) break;
                    await Task.Delay(500);
                }
            }
            throw new InvalidOperationException("The Worker did not confirm the forfeit.", lastFailure);
        }
        finally { forfeitRecoveryActive = false; }
    }
    public Task RetryPending() { return Execute(c => c.RetryPendingAsync(lifetime.Token)); }
    public Task Refresh() { return Execute(c => c.PollAsync(lifetime.Token)); }
    public Task DeployArmy(int optionIndex) { return Execute(c => c.DeployArmyAsync(optionIndex, lifetime.Token)); }
    public async Task<MatchReply> UseDecoyResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseDecoyAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseLandMineResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseLandMineAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseHeavyTurretResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseHeavyTurretAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseMedkitResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseMedkitAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseHealingStormResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseHealingStormAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseShieldsUpResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseShieldsUpAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseShieldGeneratorResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseShieldGeneratorAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public Task SelectCards(IEnumerable<string> cards, IEnumerable<int> normal, IEnumerable<int> special,
        IEnumerable<int> elite, IEnumerable<string> buddies)
    {
        return Execute(c => c.SelectCardsAsync(cards, normal, special, elite, buddies, lifetime.Token));
    }
    public async Task<MatchReply> SelectCardsResult(IEnumerable<string> cards, IEnumerable<int> normal,
        IEnumerable<int> special, IEnumerable<int> elite, IEnumerable<string> buddies)
    {
        if (!IsConnected || connection == null) throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.SelectCardsAsync(cards, normal, special, elite, buddies, lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> DeployArmyResult(int optionIndex)
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        var reply = await connection.DeployArmyAsync(optionIndex, lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public Task<MatchEventBatch> FetchEvents(ulong processedEventId)
    {
        if (!IsConnected || connection == null) throw new InvalidOperationException("No self-hosted match is connected.");
        return connection.PollEventsAsync(processedEventId, lifetime.Token);
    }

    public async Task<int> RefreshBarrels()
    {
        if (!IsConnected || connection == null || barrelTracker == null)
            throw new InvalidOperationException("Bind a source barrel catalog and connect first.");
        var active = connection;
        var tracker = barrelTracker;
        var batch = await active.PollBarrelsAsync(lifetime.Token);
        if (!IsConnected || active != connection || tracker != barrelTracker)
            throw new OperationCanceledException("The battle session changed during the barrel scan.");
        tracker.Apply(batch);
        var state = tracker.Snapshot();
        if (BarrelStateReceived != null) BarrelStateReceived(state);
        return state.Count;
    }

    public async Task<MatchArmyBatch> RefreshArmy()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        var active = connection;
        var batch = await active.PollArmyAsync(lifetime.Token);
        if (!IsConnected || active != connection)
            throw new OperationCanceledException("The battle session changed during the army scan.");
        if (ArmyOffersReceived != null) ArmyOffersReceived(batch.Clone());
        return batch;
    }

    public async Task<IReadOnlyList<BattleArmyEntityState>> RefreshArmyEntities()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        var active = connection;
        var rows = await active.FetchArmyEntitiesAsync(lifetime.Token);
        if (!IsConnected || active != connection)
            throw new OperationCanceledException("The battle session changed during the entity scan.");
        nextArmyEntityPoll = Time.realtimeSinceStartup + 0.5f;
        var copy = new List<BattleArmyEntityState>(rows.Count);
        foreach (var row in rows) copy.Add(row.Clone());
        if (ArmyEntitiesReceived != null) ArmyEntitiesReceived(copy.AsReadOnly());
        return copy.AsReadOnly();
    }

    public async Task<int> DispatchEvents()
    {
        if (CombatEventReceived == null) throw new InvalidOperationException("Bind an event consumer before dispatching combat events.");
        if (!IsConnected || connection == null) throw new InvalidOperationException("No self-hosted match is connected.");
        await eventDelivery.WaitAsync(lifetime.Token);
        try
        {
            var active = connection;
            var batch = await active.PollEventsAsync(ProcessedEventId, lifetime.Token);
            if (!IsConnected || active != connection)
                throw new OperationCanceledException("The battle session changed during event delivery.");
            int delivered = 0;
            foreach (var item in batch.Events)
            {
                if (barrelTracker != null && (item.Kind == MatchEventKind.BarrelDamaged ||
                    item.Kind == MatchEventKind.BarrelDestroyed))
                {
                    bool changed;
                    try { changed = barrelTracker.ApplyEvent(item); }
                    catch (InvalidOperationException)
                    {
                        // A missing event revision must be repaired from the full
                        // host projection before this cursor is acknowledged.
                        await RefreshBarrels();
                        changed = barrelTracker.ApplyEvent(item);
                    }
                    if (changed && BarrelStateReceived != null)
                        BarrelStateReceived(barrelTracker.Snapshot());
                }
                CombatEventReceived(item.Clone());
                ProcessedEventId = item.EventId;
                delivered++;
            }
            return delivered;
        }
        finally { eventDelivery.Release(); }
    }

    private async Task Execute(Func<MatchConnection, Task<MatchReply>> operation)
    {
        if (!IsConnected || connection == null) throw new InvalidOperationException("No self-hosted match is connected.");
        var active = connection;
        var reply = await operation(active);
        if (IsConnected && active == connection) Apply(reply); // Unity synchronization context owns state/events.
    }

    private async void Update()
    {
        if (forfeitRecoveryActive) return;
        if (!IsConnected)
        {
            if (!destroyed && reconnectTask == null &&
                reconnectAttempts > 0 && reconnectAttempts < 3 &&
                Time.realtimeSinceStartup >= nextReconnectAttempt)
            {
                try { await ReconnectWithRecoveredSession(); }
                catch (Exception e)
                {
                    Debug.LogError("Self-hosted reconnect retry failed: " + e);
                    if (ConnectionError != null) ConnectionError(e.Message);
                }
            }
            if (reconnectAttempts >= 3 && !reconnectFailureReported)
            {
                reconnectFailureReported = true;
                MatchManager.matchState = MatchState.GameCancelled;
                if (ConnectionError != null) ConnectionError("The battle session could not reconnect.");
            }
            return;
        }
        try
        {
            foreach (var renderer in rifleViews.Values)
                renderer.RenderRemote(Time.realtimeSinceStartup, Time.deltaTime);
        }
        catch (Exception e)
        {
            if (ConnectionError != null) ConnectionError(e.Message);
            return;
        }
        if (polling || Time.realtimeSinceStartup < nextPoll) return;
        polling = true;
        nextPoll = Time.realtimeSinceStartup + 0.1f;
        bool recoveryRequired = false;
        try
        {
            var active = connection;
            var reply = await active.PollAsync(lifetime.Token);
            if (!IsConnected || active != connection) return;
            Apply(reply);
            if (CombatEventReceived != null) await DispatchEvents();
            if (ProjectileScanReceived != null && State != null && State.ProjectilesTruncated &&
                Time.realtimeSinceStartup >= nextProjectileScan)
            {
                nextProjectileScan = Time.realtimeSinceStartup + 0.5f;
                var scan = await active.FetchProjectilesAsync(lifetime.Token);
                if (!IsConnected || active != connection) return;
                if (State != null && scan.SnapshotTick >= State.ServerTick)
                    ProjectileScanReceived(scan);
            }
            if (barrelTracker != null && Time.realtimeSinceStartup >= nextBarrelPoll)
            {
                nextBarrelPoll = Time.realtimeSinceStartup + 0.5f;
                await RefreshBarrels();
            }
            if (ArmyOffersReceived != null && Time.realtimeSinceStartup >= nextArmyPoll)
            {
                nextArmyPoll = Time.realtimeSinceStartup + 0.5f;
                await RefreshArmy();
            }
            if (ArmyEntitiesReceived != null && Time.realtimeSinceStartup >= nextArmyEntityPoll)
            {
                nextArmyEntityPoll = Time.realtimeSinceStartup + 0.5f;
                await RefreshArmyEntities();
            }
        }
        catch (OperationCanceledException) { }
        catch (TimeoutException) { recoveryRequired = true; }
        catch (MatchEventCursorExpiredException) { recoveryRequired = true; }
        catch (Exception e)
        {
            if (IsConnected && ConnectionError != null) ConnectionError(e.Message);
        }
        finally { polling = false; }
        if (recoveryRequired && IsConnected && !destroyed)
        {
            try { await ReconnectWithRecoveredSession(); }
            catch (Exception e)
            {
                Debug.LogError("Self-hosted reconnect failed: " + e);
                if (ConnectionError != null) ConnectionError(e.Message);
            }
        }
    }

    private void Apply(MatchReply reply)
    {
        if (destroyed) return;
        // Replayed mutation responses intentionally contain their original state.
        // Do not rewind rendering when a newer poll snapshot already arrived.
        if (State != null && (reply.Snapshot.ServerTick < State.ServerTick ||
            reply.Snapshot.StateRevision < State.StateRevision)) return;
        var next = reply.Snapshot.Clone();
        if (State != null && State.Phase != next.Phase)
            foreach (var renderer in rifleViews.Values)
                renderer.ResetRemote();
        foreach (var player in next.Players)
        {
            SelfHostedRiflePoseRenderer renderer;
            if (player.RiflePose != null && rifleViews.TryGetValue(player.PlayerId, out renderer)) renderer.Apply(player);
        }
        State = next;
        if (!cardsSelectedByBothRaised && State.Players.Count == 2 && State.Players[0].CardsSelected && State.Players[1].CardsSelected)
        {
            cardsSelectedByBothRaised = true;
            if (CardsSelectedByBoth != null) CardsSelectedByBoth();
        }
        if (roomLifecycle != null) roomLifecycle.Observe(State);
        if (StateReceived != null) StateReceived(State.Clone());
    }

    private void OnDestroy() { destroyed = true; Close(); }
    public void LeaveMatch() { Close(); }
    private void OnRoomPhaseChanged(SelfHostedRoomPhase phase)
    {
        if (!destroyed && RoomPhaseChanged != null) RoomPhaseChanged(phase);
    }
    private void Close()
    {
        IsConnected = false;
        if (matchmaking != null) matchmaking.Cancel();
        reconnectRequestId = null;
        reconnectAttempts = 0;
        forfeitCommandPending = false;
        forfeitRecoveryActive = false;
        if (armyManager != null) { armyManager.UnbindSelfHosted(this); armyManager = null; }
        if (lifetime != null) { lifetime.Cancel(); lifetime.Dispose(); lifetime = null; }
        if (roomLifecycle != null)
        {
            roomLifecycle.PhaseChanged -= OnRoomPhaseChanged;
            roomLifecycle.Close();
        }
        else if (connection != null) connection.Dispose();
        connection = null;
        if (Active == this) Active = null;
        roomLifecycle = null;
        PhotonCompatibility = null;
        cardsSelectedByBothRaised = false;
        LocalPlayerId = null;
        rifleViews.Clear();
        rifleRoots.Clear();
        if (deathMatchBridge != null) { Destroy(deathMatchBridge); deathMatchBridge = null; }
        barrelTracker = null;
        barrelCatalog = null;
    }
}
