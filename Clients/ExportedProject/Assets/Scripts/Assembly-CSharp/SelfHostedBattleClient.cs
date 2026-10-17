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
    private const int MinimumMatchmakingTimeoutSeconds = 5;
    private const int MaximumMatchmakingTimeoutSeconds = 300;
    [SerializeField] private string backendEndpoint = "http://127.0.0.1:8080/";
    [SerializeField] private int matchmakingTimeoutSeconds = 120;
    [SerializeField] private bool allowLocalHttp = true;
    public static SelfHostedBattleClient Active { get; private set; }
    public event Action<MatchSnapshot> StateReceived;
    /// <summary>Publishes validated common co-op enemy fields before mission outcome callbacks.</summary>
    public event Action<IReadOnlyList<CoopEnemyViewState>> CoopEnemiesReceived;
    /// <summary>Notifies visuals after a match connection and its active views have been released.</summary>
    public event Action MatchClosed;
    /// <summary>Gets the current isolated common enemy view without enabling local AI.</summary>
    public IReadOnlyList<CoopEnemyViewState> CoopEnemies { get; private set; } = Array.Empty<CoopEnemyViewState>();
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
    private string _observedPoseCatalogRevision = string.Empty;
    private SelfHostedRoomLifecycle roomLifecycle;
    private CancellationTokenSource lifetime;
    private SelfHostedMatchmakingAttempt matchmaking;
    private bool _hasLoadingFailure;
    private bool polling;
    private bool _isAbortRecoverySuspended;
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
    private ScoreManager _scoreManager;
    private MissionsManager _missionManager;

    /// <summary>Binds the selected source mission before co-op presentation receives host snapshots.</summary>
    public void BindMissionManager(MissionsManager manager)
    {
        if (manager == null)
        {
            throw new ArgumentNullException(nameof(manager));
        }

        manager.ResetSelfHostedHud();
        _missionManager = manager;
        if (State != null)
        {
            manager.ApplySelfHostedHud(State, LocalPlayerId);
        }
    }

    /// <summary>Binds the scene score view before room or terminal callbacks consume a snapshot.</summary>
    public void BindScoreManager(ScoreManager manager)
    {
        if (manager == null)
        {
            return;
        }

        _scoreManager = manager;
        if (_scoreManager != null && State != null)
        {
            _scoreManager.ApplySelfHostedSnapshot(State, LocalPlayerId);
        }
    }
    public bool IsMatchmaking { get { return matchmaking != null && !matchmaking.IsRetainedForLoading; } }

    internal bool HasLoadingCancellationAuthority
    {
        get { return matchmaking != null && matchmaking.IsRetainedForLoading && OwnsMatch; }
    }

    internal SelfHostedMatchmakingAttempt LoadingCancellationOwner
    {
        get { return HasLoadingCancellationAuthority ? matchmaking : null; }
    }

    /// <summary>Cancels the exact admitted attempt while retaining UDP delivery of the server's terminal proof.</summary>
    internal Task CancelFailedLoadingAsync()
    {
        if (!HasLoadingCancellationAuthority)
        {
            throw new InvalidOperationException("This match has no retained loading cancellation authority.");
        }

        _hasLoadingFailure = true;
        SelfHostedMatchmakingAttempt attempt = matchmaking;
        MatchConnection ownedConnection = connection;
        return attempt.CancelLoadingWithRetryAsync(() => !destroyed && !_isAbortRecoverySuspended &&
            Active == this && matchmaking == attempt && connection == ownedConnection && State != null &&
            (State.Phase == BattlePhase.Waiting || State.Phase == BattlePhase.Countdown));
    }
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

    /// <summary>Reuses an owned match even while its GameObject is inactive before finding a free adapter.</summary>
    public static SelfHostedBattleClient GetOrCreate()
    {
        if (Active != null && Active.OwnsMatch)
        {
            // Scene inactivity does not release an admitted or recovering match's ownership.
            return Active;
        }

        SelfHostedBattleClient current = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
        if (current != null) return current;
        GameObject owner = new GameObject("SelfHostedBattleClient");
        UnityEngine.Object.DontDestroyOnLoad(owner);
        return owner.AddComponent<SelfHostedBattleClient>();
    }

    public Task MatchmakeWithRecoveredSession()
    {
        RequireAbortRecoveryReleased();
        GameLoginManager login = Singleton<GameLoginManager>.instance;
        if (login == null || string.IsNullOrEmpty(login.accessToken))
            throw new InvalidOperationException("The recovered Backend session is not available.");
        return MatchmakeAndConnect(backendEndpoint, login.accessToken, matchmakingTimeoutSeconds, allowLocalHttp);
    }

    /// <summary>Owns one authenticated queue search and admits its grant only while that search is current.</summary>
    public async Task MatchmakeAndConnect(
        string backendEndpoint, string accessToken, int timeoutSeconds, bool allowLocalHttp)
    {
        RequireAbortRecoveryReleased();
        if (destroyed)
        {
            throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        }
        if (string.IsNullOrEmpty(accessToken) || timeoutSeconds < MinimumMatchmakingTimeoutSeconds ||
            timeoutSeconds > MaximumMatchmakingTimeoutSeconds)
        {
            throw new ArgumentException("Matchmaking requires a token and a 5-second to 5-minute timeout.");
        }

        if (matchmaking != null && matchmaking.IsCancellationRequested)
        {
            await CancelMatchmaking();
        }

        if (connection != null || matchmaking != null)
        {
            throw new InvalidOperationException("A self-hosted match operation is already active.");
        }

        Uri endpoint;
        if (!Uri.TryCreate(backendEndpoint, UriKind.Absolute, out endpoint))
        {
            throw new ArgumentException("A valid Backend endpoint is required.", nameof(backendEndpoint));
        }

        var attempt = new SelfHostedMatchmakingAttempt(new BackendClient(endpoint, allowLocalHttp), accessToken);
        matchmaking = attempt;
        try
        {
            MatchConnectionGrant grant = await attempt.FindAsync(timeoutSeconds);
            RequireCurrentMatchmaking(attempt);
            await ConnectCoreAsync(grant, 0);
            RequireCurrentMatchmaking(attempt);
            attempt.RetainForLoading();
        }
        catch
        {
            if (!attempt.IsCancellationRequested)
            {
                await CancelQueueAfterFailureAsync(attempt);
            }

            throw;
        }
        finally
        {
            await CompleteMatchmakingAsync(attempt);
        }
    }

    /// <summary>Closes pending admission and waits for acknowledged cancellation before another search.</summary>
    public async Task CancelMatchmaking()
    {
        RequireAbortRecoveryReleased();
        SelfHostedMatchmakingAttempt attempt = matchmaking;
        if (attempt == null)
        {
            return;
        }

        // Close admission as well as the HTTP search; it uses a separate UDP cancellation token.
        Task cancellation = attempt.CancelAsync();
        if (attempt.IsRetainedForLoading)
        {
            // A failed HTTP request or Running-first refusal is not authority to discard this live match.
            await cancellation;
        }

        Close();
        await cancellation;
        await CompleteMatchmakingAsync(attempt);
    }

    private void RequireCurrentMatchmaking(SelfHostedMatchmakingAttempt attempt)
    {
        if (destroyed || matchmaking != attempt || attempt.IsCancellationRequested)
        {
            throw new OperationCanceledException("The matchmaking attempt was canceled or replaced.");
        }
    }

    private async Task CancelQueueAfterFailureAsync(SelfHostedMatchmakingAttempt attempt)
    {
        try
        {
            await attempt.CancelAsync();
        }
        catch (Exception failure)
        {
            // Keep the original search failure; the retained attempt blocks a new join until cleanup retries.
            if (!destroyed)
            {
                Debug.LogWarning("Self-hosted queue cancellation failed: " + failure.GetType().Name);
            }
        }
    }

    private async Task CompleteMatchmakingAsync(SelfHostedMatchmakingAttempt attempt)
    {
        try
        {
            await attempt.CompleteAsync();
        }
        catch (Exception failure)
        {
            if (destroyed)
            {
                // A destroyed owner cannot retry, but the bounded HTTP cancellation had its chance to finish.
                attempt.Dispose();
            }
            else
            {
                Debug.LogWarning("Self-hosted queue cleanup is pending: " + failure.GetType().Name);
            }

            return;
        }

        if (matchmaking == attempt && (!attempt.IsRetainedForLoading || attempt.IsCancellationRequested))
        {
            matchmaking = null;
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

    /// <summary>Admits a direct trusted grant only when no account-scoped queue cleanup remains pending.</summary>
    public Task Connect(MatchConnectionGrant grant, ulong processedEventId = 0)
    {
        RequireAbortRecoveryReleased();
        if (matchmaking != null)
        {
            throw new InvalidOperationException("Finish the pending matchmaking cleanup before direct admission.");
        }

        return ConnectCoreAsync(grant, processedEventId);
    }

    private async Task ConnectCoreAsync(MatchConnectionGrant grant, ulong processedEventId)
    {
        RequireAbortRecoveryReleased();
        if (destroyed) throw new ObjectDisposedException(nameof(SelfHostedBattleClient));
        if (connection != null) throw new InvalidOperationException("This component already owns a match session.");
        var preparedTracker = barrelCatalog == null ? null :
            new BarrelStateTracker(grant.MatchId, grant.ManifestHash, barrelCatalog);
        string poseRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision;
        MatchConnection ownedConnection = new MatchConnection(grant, poseRevision);
        connection = ownedConnection;
        _observedPoseCatalogRevision = poseRevision;
        PlayerViews = connection.PlayerViews;
        BeginSnapshotScope(grant);
        Active = this;
        roomLifecycle = new SelfHostedRoomLifecycle(connection);
        roomLifecycle.PhaseChanged += OnRoomPhaseChanged;
        PhotonCompatibility = new SelfHostedPhotonCompatibility(roomLifecycle);
        barrelTracker = preparedTracker;
        lifetime = new CancellationTokenSource();
        ProcessedEventId = processedEventId;
        var token = lifetime.Token;
        try
        {
            var reply = await roomLifecycle.ConnectAsync(token);
            RequireConnectionOwner(ownedConnection, token);
            Apply(reply);
            RequireConnectionOwner(ownedConnection, token);
            IsConnected = true;
            if (barrelTracker != null) await RefreshBarrels();
            if (ArmyEntitiesReceived != null) await RefreshArmyEntities();
            RequireConnectionOwner(ownedConnection, token);
        }
        catch
        {
            if (ReferenceEquals(connection, ownedConnection))
            {
                Close();
            }
            throw;
        }
    }

    private void RequireConnectionOwner(MatchConnection expected, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (!ReferenceEquals(connection, expected))
        {
            throw new OperationCanceledException(token);
        }
    }

    /// <summary>Stops delivery during abort cleanup while preserving the self-hosted ownership guard.</summary>
    public void SuspendAbortedMatch()
    {
        if (!OwnsMatch || State == null || State.Phase != BattlePhase.Aborted)
        {
            throw new InvalidOperationException("Only a confirmed aborted match can suspend for recovery.");
        }

        _isAbortRecoverySuspended = true;
        IsConnected = false;
        lifetime.Cancel();
    }

    /// <summary>Releases the retained abort owner only after its scene cleanup has completed.</summary>
    public void FinishAbortedMatchRecovery()
    {
        if (!_isAbortRecoverySuspended)
        {
            throw new InvalidOperationException("There is no suspended abort recovery to finish.");
        }

        Close();
        _isAbortRecoverySuspended = false;
    }

    private void RequireAbortRecoveryReleased()
    {
        if (_isAbortRecoverySuspended)
        {
            throw new InvalidOperationException("Finish aborted battle cleanup before replacing its connection.");
        }
    }

    private void BeginSnapshotScope(MatchConnectionGrant grant)
    {
        // Host ticks and revisions are ordered inside one match, not across successive grants.
        State = null;
        _isAbortRecoverySuspended = false;
        CoopEnemies = Array.Empty<CoopEnemyViewState>();
        matchId = grant.MatchId;
        LocalPlayerId = grant.PlayerId;
        manifestHash = grant.ManifestHash;
    }

    /// <summary>Ask the Backend for a fresh capability using the recovered login session.</summary>
    public Task ReconnectWithRecoveredSession()
    {
        RequireAbortRecoveryReleased();
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

            var nextConnection = new MatchConnection(grant, _observedPoseCatalogRevision);
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
        if (_hasLoadingFailure)
        {
            throw new InvalidOperationException("A failed battle load cannot report scene readiness.");
        }

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
                if (State != null && (State.Phase == BattlePhase.Ended || State.Phase == BattlePhase.Aborted ||
                    SelfHostedCoopDepartureState.IsLocalDeparture(State, LocalPlayerId)))
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
                    return; // Apply publishes either the shared terminal state or this co-op peer's departure.
                }
                catch (Exception failure)
                {
                    lastFailure = failure;
                    // A consumed Forfeit is terminal or removes this co-op peer.
                    // The Worker will not issue that peer another grant; retry the original receipt.
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
    public async Task<MatchReply> UseUnitCardResult(string sourceCardId)
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseUnitCardAsync(
            Guid.NewGuid().ToString("N"), sourceCardId, lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
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
        return await UseMedkitResult("MEDKIT");
    }

    public async Task<MatchReply> UseMedkitResult(string sourceCardId)
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseMedkitAsync(
            Guid.NewGuid().ToString("N"), sourceCardId, lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseMaxHealthResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseMaxHealthAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseEmptyMagResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseEmptyMagAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseBulletSpongeResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseBulletSpongeAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseImmortalResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseImmortalAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseSlowMoveResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseSlowMoveAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseDisarmedResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseDisarmedAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseShieldReflectionResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseShieldReflectionAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseKevlarUpResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseKevlarUpAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseShieldSpawnerResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseShieldSpawnerAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseBackstabResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseBackstabAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseSabotageResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseSabotageAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseGrenadesBurstResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseGrenadesBurstAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseScoreMultiplierResult(string sourceCardId)
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        if (sourceCardId != "STREAKBOOST" && sourceCardId != "CRATEBLOCKER")
            throw new ArgumentException("Unknown score multiplier card.", "sourceCardId");
        MatchReply reply = await connection.UseScoreMultiplierAsync(
            Guid.NewGuid().ToString("N"), sourceCardId, lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> QueueBonusCardResult(string sourceCardId)
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        if (sourceCardId != "HEALTHCRATE" && sourceCardId != "TURRETCRATE" &&
            sourceCardId != "KEVLARCRATE" && sourceCardId != "AMMOCRATE")
            throw new ArgumentException("Unknown queued bonus card.", "sourceCardId");
        MatchReply reply = await connection.QueueBonusCardAsync(
            Guid.NewGuid().ToString("N"), sourceCardId, lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseRandomKevlarResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseRandomKevlarAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
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
    public async Task<MatchReply> UseAmmoBoxResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseAmmoBoxAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseAmmoThiefResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseAmmoThiefAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseBrokenLegsResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseBrokenLegsAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseMassShieldDestroyerResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseMassShieldDestroyerAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseShieldDestroyerResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseShieldDestroyerAsync(
            Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseSuperSoldiersResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseSuperSoldiersAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseVehicleHealthResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseVehicleHealthAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
        Apply(reply);
        return reply.Clone();
    }
    public async Task<MatchReply> UseMineYourStepResult()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        MatchReply reply = await connection.UseMineYourStepAsync(Guid.NewGuid().ToString("N"), lifetime.Token);
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
        if (_isAbortRecoverySuspended)
        {
            return;
        }

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
        if (destroyed || _isAbortRecoverySuspended) return;
        if (!string.IsNullOrEmpty(matchId) &&
            (reply.Snapshot.MatchId != matchId || reply.Snapshot.ManifestHash != manifestHash))
        {
            // A completed operation from a replaced connection must not publish into the current match.
            return;
        }
        // Replayed mutation responses intentionally contain their original state.
        // Do not rewind rendering when a newer poll snapshot already arrived.
        if (State != null && (reply.Snapshot.ServerTick < State.ServerTick ||
            reply.Snapshot.StateRevision < State.StateRevision)) return;
        var next = reply.Snapshot.Clone();
        if (reply.ObservedPoseCatalogRevision != _observedPoseCatalogRevision)
        {
            throw new InvalidOperationException("The snapshot does not match the negotiated pose renderer.");
        }
        IReadOnlyList<CoopEnemyViewState> enemyViews = Array.Empty<CoopEnemyViewState>();
        if (next.Coop != null && !string.IsNullOrEmpty(next.Coop.MissionType))
        {
            enemyViews = CoopEnemyViewProjection.FromSnapshot(next, LocalPlayerId, _observedPoseCatalogRevision);
        }

        if (State != null && State.Phase != next.Phase)
            foreach (var renderer in rifleViews.Values)
                renderer.ResetRemote();
        foreach (var player in next.Players)
        {
            SelfHostedRiflePoseRenderer renderer;
            if (player.RiflePose != null && rifleViews.TryGetValue(player.PlayerId, out renderer)) renderer.Apply(player);
        }
        State = next;
        CoopEnemies = enemyViews;
        if (_scoreManager != null)
        {
            _scoreManager.ApplySelfHostedSnapshot(State, LocalPlayerId);
        }
        if (!cardsSelectedByBothRaised && State.Players.Count == 2 && State.Players[0].CardsSelected && State.Players[1].CardsSelected)
        {
            cardsSelectedByBothRaised = true;
            if (CardsSelectedByBoth != null) CardsSelectedByBoth();
        }
        if (_missionManager != null)
        {
            _missionManager.ApplySelfHostedHud(State, LocalPlayerId);
        }

        if (State.Coop != null && !string.IsNullOrEmpty(State.Coop.MissionType) && CoopEnemiesReceived != null)
        {
            CoopEnemiesReceived(CoopEnemies);
        }

        if (roomLifecycle != null) roomLifecycle.Observe(State);
        if (StateReceived != null) StateReceived(State.Clone());
    }

    private void OnDestroy()
    {
        destroyed = true;
        Close();
    }
    public void LeaveMatch()
    {
        if (_isAbortRecoverySuspended)
        {
            // Cleanup still needs this ownership guard to avoid legacy Photon fallback in recovered components.
            return;
        }

        Close();
    }
    private void OnRoomPhaseChanged(SelfHostedRoomPhase phase)
    {
        if (!destroyed && RoomPhaseChanged != null) RoomPhaseChanged(phase);
    }
    private async void ObserveQueueCancellationAsync(SelfHostedMatchmakingAttempt attempt)
    {
        await CancelQueueAfterFailureAsync(attempt);
        await CompleteMatchmakingAsync(attempt);
    }

    private void Close()
    {
        bool hadMatch = connection != null || LocalPlayerId != null || CoopEnemies.Count != 0;
        CoopEnemies = Array.Empty<CoopEnemyViewState>();
        _missionManager = null;
        IsConnected = false;
        if (matchmaking != null)
        {
            if (matchmaking.IsRetainedForLoading && State != null &&
                (State.Phase == BattlePhase.Running || State.Phase == BattlePhase.Ended ||
                 State.Phase == BattlePhase.Aborted))
            {
                // Loading cancellation cannot forfeit a started battle or change a terminal result.
                matchmaking.Dispose();
                matchmaking = null;
            }
            else
            {
                // This observer retains failed cleanup so another search cannot replace its authority.
                ObserveQueueCancellationAsync(matchmaking);
            }
        }
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
        _hasLoadingFailure = false;
        _observedPoseCatalogRevision = string.Empty;
        if (Active == this) Active = null;
        roomLifecycle = null;
        PhotonCompatibility = null;
        cardsSelectedByBothRaised = false;
        LocalPlayerId = null;
        rifleViews.Clear();
        rifleRoots.Clear();
        _scoreManager = null;
        if (deathMatchBridge != null) { Destroy(deathMatchBridge); deathMatchBridge = null; }
        barrelTracker = null;
        barrelCatalog = null;
        if (hadMatch && MatchClosed != null)
        {
            MatchClosed();
        }
    }
}
