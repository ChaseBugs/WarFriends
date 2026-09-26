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
    // Handlers run on Unity's synchronization context. Failed handlers cause
    // the same event ID to be fetched again; side effects must be idempotent.
    public event Action<MatchEvent> CombatEventReceived;
    public event Action<IReadOnlyList<BarrelViewState>> BarrelStateReceived;
    public event Action<MatchArmyBatch> ArmyOffersReceived;
    public event Action<IReadOnlyList<BattleArmyEntityState>> ArmyEntitiesReceived;
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
    private bool destroyed;
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
        var renderer = new SelfHostedRiflePoseRenderer(root, animator);
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
        Apply(await roomLifecycle.MarkReadyAsync(lifetime.Token));
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
    public Task Forfeit() { return Execute(c => c.ForfeitAsync(lifetime.Token)); }
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
        var batch = await connection.PollBarrelsAsync(lifetime.Token);
        barrelTracker.Apply(batch);
        var state = barrelTracker.Snapshot();
        if (BarrelStateReceived != null) BarrelStateReceived(state);
        return state.Count;
    }

    public async Task<MatchArmyBatch> RefreshArmy()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        var batch = await connection.PollArmyAsync(lifetime.Token);
        if (ArmyOffersReceived != null) ArmyOffersReceived(batch.Clone());
        return batch;
    }

    public async Task<IReadOnlyList<BattleArmyEntityState>> RefreshArmyEntities()
    {
        if (!IsConnected || connection == null)
            throw new InvalidOperationException("Connect to a self-hosted match first.");
        var rows = await connection.FetchArmyEntitiesAsync(lifetime.Token);
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
            var batch = await connection.PollEventsAsync(ProcessedEventId, lifetime.Token);
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
        Apply(await operation(connection)); // Unity synchronization context owns state/events.
    }

    private async void Update()
    {
        if (!IsConnected || polling || Time.realtimeSinceStartup < nextPoll) return;
        polling = true;
        nextPoll = Time.realtimeSinceStartup + 0.1f;
        try
        {
            Apply(await connection.PollAsync(lifetime.Token));
            if (CombatEventReceived != null) await DispatchEvents();
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
        catch (Exception e)
        {
            if (IsConnected && ConnectionError != null) ConnectionError(e.Message);
        }
        finally { polling = false; }
    }

    private void Apply(MatchReply reply)
    {
        if (destroyed) return;
        // Replayed mutation responses intentionally contain their original state.
        // Do not rewind rendering when a newer poll snapshot already arrived.
        if (State != null && (reply.Snapshot.ServerTick < State.ServerTick ||
            reply.Snapshot.StateRevision < State.StateRevision)) return;
        var next = reply.Snapshot.Clone();
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
    private void OnRoomPhaseChanged(SelfHostedRoomPhase phase)
    {
        if (!destroyed && RoomPhaseChanged != null) RoomPhaseChanged(phase);
    }
    private void Close()
    {
        IsConnected = false;
        if (matchmaking != null) matchmaking.Cancel();
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
