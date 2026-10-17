using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks the original controller's abort entry before resource/UI coroutines advance.</summary>
[InitializeOnLoad]
public static class UnityAbortRecoveryRoutingAudit
{
    private const string SessionKey = "WarFriends.AbortRecoveryRoutingAudit";
    private const BindingFlags InstanceFields = BindingFlags.Instance | BindingFlags.NonPublic;
    private const string MatchId = "abort-routing-fixture";
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const int SessionKeyBytes = 32;
    private const int TicketLifetimeSeconds = 60;
    private static bool _injectCleanupFailure;
    private static GameControllerCoop _coop;
    private static GameControllerWarArena _arena;

    static UnityAbortRecoveryRoutingAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += BeginWhenPlaying;
        }
    }

    /// <summary>Enters Play Mode with controlled managers; no normal account or menu boot is exercised.</summary>
    public static void RunAsync()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(SessionKey, true);
        EditorApplication.update -= BeginWhenPlaying;
        EditorApplication.update += BeginWhenPlaying;
        EditorApplication.isPlaying = true;
    }

    private static void BeginWhenPlaying()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        EditorApplication.update -= BeginWhenPlaying;
        RunChecks();
    }

    private static async void RunChecks()
    {
        try
        {
            var root = new GameObject("AbortRecoveryRoutingProbe");
            var game = root.AddComponent<AbortRecoveryControllerProbe>();
            game.enabled = false;
            var sources = new GameObject("InactiveAbortRecoverySources");
            sources.SetActive(false);
            var controller = sources.AddComponent<GameControllerDeathMatch>();
            _coop = sources.AddComponent<GameControllerCoop>();
            _arena = sources.AddComponent<GameControllerWarArena>();
            var time = sources.AddComponent<TimeManager>();
            var map = sources.AddComponent<MapManager>();
            var atlas = sources.AddComponent<AtlasPreparer>();
            typeof(Singleton<AtlasPreparer>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, atlas);
            typeof(Singleton<GameController>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, game);
            typeof(Singleton<MapManager>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, map);
            typeof(TimeManager).GetField("mInstance", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, time);
            SetGame(game, "mMainController", controller);
            int outcomes = 0;
            game.GameEnded += _ => outcomes++;
            foreach (GameController.GameState state in Enum.GetValues(typeof(GameController.GameState)))
            {
                await VerifyStateAsync(game, controller, time, state);
            }

            _injectCleanupFailure = true;
            foreach (GameController.GameState state in Enum.GetValues(typeof(GameController.GameState)))
            {
                await VerifyStateAsync(game, controller, time, state);
            }

            Require(outcomes == 0 && UnityEngine.Object.FindObjectOfType<BeanstalkServerManager>() == null &&
                UnityEngine.Object.FindObjectOfType<Chat>() == null,
                "Abort entry must not publish an outcome or start Backend/Photon Chat services.");
            SessionState.SetBool(SessionKey, false);
            Debug.Log("PASS: owner-bound abort entry in Menu/Waiting/Loading/Playing, no outcome, " +
                "suspended delivery and blocked replacement loads; stops before resource/menu UI execution.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            SessionState.SetBool(SessionKey, false);
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static async Task VerifyStateAsync(GameController game, GameControllerDeathMatch controller,
        TimeManager time, GameController.GameState initialState)
    {
        SetGame(game, "_isSelfHostedAbortRecovery", false);
        typeof(GameController).GetProperty("gameState").SetValue(game, initialState, null);
        SetGame(game, "mGameIsRunning", true);
        time.gameIsRunning = true;
        game.gameEndReason = GameController.GameEndReason.Win;
        var adapterRoot = new GameObject("AbortRoutingAdapter");
        var client = adapterRoot.AddComponent<SelfHostedBattleClient>();
        using (var receiver = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0)))
        {
            InstallConnection(client, receiver);
            Apply(client, Snapshot(BattlePhase.Waiting));
            typeof(GameControllerOnline).GetField("mSelfHostedClient", InstanceFields).SetValue(controller, client);
            typeof(GameControllerOnline).GetMethod("BindSelfHostedAbortRecovery", InstanceFields)
                .Invoke(controller, new object[] { client });
            var handler = (Action<MatchSnapshot>)typeof(GameControllerOnline)
                .GetField("_selfHostedAbortHandler", InstanceFields).GetValue(controller);
            handler = VerifySubscriptionLifecycle(game, controller, client, handler);
            VerifyRejectedOwners(game, controller, client, handler);
            if (!_injectCleanupFailure)
            {
                await VerifyLoadingFailureDispatchAsync(game, controller, client);
            }
            var resourceScope = new BattleResourceLoadScope();
            SetGame(game, "_battleResourceLoads", resourceScope);
            System.Collections.IEnumerator loading = PendingResourceRoutine();
            if (_injectCleanupFailure)
            {
                loading = UnityResourceScopeFailureAudit.CreateFailingLoad();
            }
            resourceScope.Start(game, loading);
            Require(resourceScope.PendingCount == 1, "The controlled resource loader did not become pending.");
            if (!_injectCleanupFailure)
            {
                UnityResourceExecutionFailureAudit.InjectExecutionFailure(resourceScope, game);
            }
            if (_injectCleanupFailure)
            {
                VerifyInjectedAbortFailure(game, client, handler);
                UnityEngine.Object.DestroyImmediate(adapterRoot);
                return;
            }
            var scopeField = typeof(AtlasPreparer).GetField("_gameLoadScope", InstanceFields);
            object previousAtlasScope = scopeField.GetValue(Singleton<AtlasPreparer>.instance);
            Apply(client, Snapshot(BattlePhase.Aborted));
            Require(resourceScope.PendingCount == 0,
                "Confirmed abort left its tracked managed resource loader pending.");
            Require(!ReferenceEquals(previousAtlasScope, scopeField.GetValue(Singleton<AtlasPreparer>.instance)),
                "Confirmed abort did not invalidate the separately hosted game-atlas loader.");
            Require(game.IsSelfHostedAbortRecovery && game.gameState == GameController.GameState.Loading &&
                !game.gameIsRunning && !time.gameIsRunning && game.gameEndReason == GameController.GameEndReason.None &&
                MatchManager.matchState == MatchState.GameCancelled && client.OwnsMatch && !client.IsConnected,
                "Confirmed abort entry did not stop gameplay while retaining ownership for cleanup.");
            VerifyBlockedReplacement(game, controller, client, handler);
            game.StopAllCoroutines();
            typeof(GameControllerOnline).GetMethod("CompleteSelfHostedAbort", InstanceFields)
                .Invoke(controller, new object[] { client });
            client.FinishAbortedMatchRecovery();
            Require(!client.OwnsMatch && SelfHostedBattleClient.Active == null,
                "Completed cleanup did not release the retained owner.");
            SetGame(game, "_isSelfHostedAbortRecovery", false);
            handler(Snapshot(BattlePhase.Aborted));
            Require(!game.IsSelfHostedAbortRecovery, "A reset owner's captured callback restarted recovery.");
            await VerifyReleasedAdapterAsync(game, client, receiver, handler);
        }

        UnityEngine.Object.DestroyImmediate(adapterRoot);
    }

    private static async Task VerifyLoadingFailureDispatchAsync(
        GameController game, GameControllerDeathMatch controller, SelfHostedBattleClient client)
    {
        // The preceding stale-callback control intentionally leaves an Aborted snapshot installed.
        typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client, Snapshot(BattlePhase.Waiting), null);
        var http = new LoadingCancellationHandler();
        var backend = new BackendClient(new Uri("http://127.0.0.1:30001/"), http, true);
        Type attemptType = typeof(SelfHostedBattleClient).Assembly.GetType("SelfHostedMatchmakingAttempt", true);
        object attempt = Activator.CreateInstance(attemptType, InstanceFields, null,
            new object[] { backend, "fixture-access-token" }, null);
        // Search issuance is covered by portable tests; this isolates the admitted Unity owner boundary.
        attemptType.GetField("_attemptToken", InstanceFields).SetValue(attempt, Task.FromResult("fixture-attempt"));
        attemptType.GetField("_hasGrant", InstanceFields).SetValue(attempt, true);
        attemptType.GetMethod("RetainForLoading", InstanceFields).Invoke(attempt, null);
        typeof(SelfHostedBattleClient).GetField("matchmaking", InstanceFields).SetValue(client, attempt);
        var scope = new BattleResourceLoadScope();
        var expected = new InvalidOperationException("Controlled loading failure.");
        try
        {
            scope.RunSetup(() => { throw expected; });
        }
        catch (InvalidOperationException failure)
        {
            Require(ReferenceEquals(failure, expected), "Setup changed the original loading exception.");
        }
        SetGame(game, "_battleResourceLoads", scope);
        SetGame(game, "_resourceLoadClient", client);
        MethodInfo lateUpdate = typeof(GameController).GetMethod("LateUpdate", InstanceFields);
        object previousAttempt = Activator.CreateInstance(attemptType, InstanceFields, null,
            new object[] { new BackendClient(new Uri("http://127.0.0.1:30001/"),
                new LoadingCancellationHandler(), true), "previous-fixture-token" }, null);
        SetGame(game, "_resourceLoadCancellationOwner", previousAttempt);
        lateUpdate.Invoke(game, null);
        Require(http.Requests == 0, "A different attempt on the same adapter inherited the old loading failure.");
        ((IDisposable)previousAttempt).Dispose();
        SetGame(game, "_resourceLoadCancellationOwner", attempt);
        SetGame(game, "mMainController", _coop);
        lateUpdate.Invoke(game, null);
        Require(http.Requests == 0, "A different controller cancelled the previous owner's loading failure.");
        SetGame(game, "mMainController", controller);
        lateUpdate.Invoke(game, null);
        lateUpdate.Invoke(game, null);
        Require(http.Requests == 1 && client.OwnsMatch && client.IsConnected,
            "Loading failure must issue one scoped cancellation while retaining terminal UDP delivery.");
        DateTime retryDeadline = DateTime.UtcNow.AddSeconds(5);
        while (http.Requests < 2)
        {
            Require(DateTime.UtcNow < retryDeadline, "Temporary HTTP failure did not retry in Unity.");
            await Task.Yield();
        }
        lateUpdate.Invoke(game, null);
        Require(http.Requests == 2 && client.OwnsMatch && client.IsConnected,
            "A successful retry must retain UDP and must not start another cancellation operation.");
        bool rejectedReady = false;
        try
        {
            await client.ReadyAsync();
        }
        catch (InvalidOperationException)
        {
            rejectedReady = true;
        }
        Require(rejectedReady, "Failed loading still sent readiness to the Worker.");
        bool rejectedReplacement = false;
        try
        {
            game.StartGame();
        }
        catch (InvalidOperationException)
        {
            rejectedReplacement = true;
        }
        Require(rejectedReplacement, "A new map replaced the failed loading scope before terminal recovery.");
        Debug.Log("PASS: deferred loading failure dispatch rejects another controller, retries a temporary HTTP " +
            "failure with the same scope, retains transport and blocks Ready; controlled credential and receipt.");
    }

    private sealed class LoadingCancellationHandler : HttpMessageHandler
    {
        internal int Requests { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Require(request.RequestUri.AbsolutePath.EndsWith("/queue/cancel", StringComparison.Ordinal) &&
                request.Headers.Authorization.Parameter == "fixture-access-token",
                "Loading cancellation lost its exact authenticated route.");
            var body = MatchQueueRequest.Parser.ParseFrom(
                request.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult());
            Require(body.AttemptToken == "fixture-attempt", "Loading cancellation lost its attempt scope.");
            Requests++;
            if (Requests == 1)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new ByteArrayContent(new ErrorResponse { Code = "match_cancellation_deferred" }.ToByteArray())
                });
            }

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(new MatchQueueReply { Code = "cancelled" }.ToByteArray())
            });
        }
    }

    private static void VerifyInjectedAbortFailure(GameController game, SelfHostedBattleClient client,
        Action<MatchSnapshot> handler)
    {
        GameController.GameState initialState = game.gameState;
        AggregateException reported = null;
        try
        {
            Apply(client, Snapshot(BattlePhase.Aborted));
        }
        catch (TargetInvocationException failure)
        {
            reported = failure.InnerException as AggregateException;
        }
        Require(reported != null && reported.Flatten().InnerExceptions.Any(error =>
            error.Message == UnityResourceScopeFailureAudit.CleanupFailureMessage),
            "The controlled abort did not report its injected resource cleanup failure.");
        Require(game.IsSelfHostedAbortRecovery && game.gameState == GameController.GameState.Loading &&
            !game.gameIsRunning && !TimeManager.instance.gameIsRunning &&
            game.gameEndReason == GameController.GameEndReason.None &&
            MatchManager.matchState == MatchState.GameCancelled && client.OwnsMatch && !client.IsConnected,
            "Resource cleanup failure left confirmed-abort gameplay or transport running before recovery.");
        VerifyBlockedReplacement(game, (GameControllerDeathMatch)game.mainController, client, handler);
        Debug.Log("PASS: injected " + initialState + " abort cleanup failure retains a suspended owner, " +
            "stopped gameplay and blocked " +
            "admission; fixture forces adapter destruction instead of claiming successful recovery.");
    }

    private static System.Collections.IEnumerator PendingResourceRoutine()
    {
        while (true)
        {
            yield return null;
        }
    }

    private static void VerifyRejectedOwners(GameController game, GameControllerDeathMatch controller,
        SelfHostedBattleClient client, Action<MatchSnapshot> handler)
    {
        var aborted = Snapshot(BattlePhase.Aborted);
        typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client, aborted.Clone(), null);
        typeof(GameControllerOnline).GetField("mSelfHostedClient", InstanceFields).SetValue(controller, null);
        handler(aborted);
        typeof(GameControllerOnline).GetField("mSelfHostedClient", InstanceFields).SetValue(controller, client);
        var foreign = aborted.Clone();
        foreign.MatchId = "another-match";
        handler(foreign);
        handler(Snapshot(BattlePhase.Waiting));
        Require(!game.IsSelfHostedAbortRecovery, "A replaced owner, foreign match or non-abort triggered recovery.");
    }

    private static Action<MatchSnapshot> VerifySubscriptionLifecycle(GameController game,
        GameControllerDeathMatch controller, SelfHostedBattleClient client, Action<MatchSnapshot> oldHandler)
    {
        typeof(GameControllerDeathMatch).GetMethod("OnDisable", InstanceFields).Invoke(controller, null);
        typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client, Snapshot(BattlePhase.Aborted), null);
        oldHandler(Snapshot(BattlePhase.Aborted));
        Require(!game.IsSelfHostedAbortRecovery, "A captured callback survived disabling its subscription.");
        typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client, Snapshot(BattlePhase.Waiting), null);
        typeof(GameControllerOnline).GetMethod("OnEnable", InstanceFields).Invoke(controller, null);
        var current = (Action<MatchSnapshot>)typeof(GameControllerOnline)
            .GetField("_selfHostedAbortHandler", InstanceFields).GetValue(controller);
        Require(current != null && !ReferenceEquals(current, oldHandler),
            "Enabling the original owner must establish a fresh subscription.");
        return current;
    }

    private static void VerifyBlockedReplacement(GameController game, GameControllerDeathMatch controller,
        SelfHostedBattleClient client, Action<MatchSnapshot> handler)
    {
        handler(Snapshot(BattlePhase.Aborted));
        game.StopGame(true);
        game.FinishGame();
        controller.StopGame();
        controller.Quit();
        controller.Forfeit();
        _coop.Quit();
        _coop.Forfeit();
        _coop.FinishGame();
        _arena.Quit();
        _arena.FinishGame();
        client.LeaveMatch();
        Apply(client, Snapshot(BattlePhase.Running));
        Require(client.State.Phase == BattlePhase.Aborted && client.OwnsMatch &&
            game.gameEndReason == GameController.GameEndReason.None,
            "A late gameplay callback changed abort ownership or projected an outcome.");
        Reject(() => game.StartGame(), "A new map load entered during recovery.");
        Reject(() => game.mainController = null, "Another controller replaced the recovering owner.");
        Reject(() => controller.StartRandomMatchMaking(), "Another match request entered during recovery.");
        Reject(() => _arena.StartRandomMatchMaking(), "An Arena request entered during recovery.");
        Reject(() => _coop.StartMultiplayerGame("replacement", CloudRegionCode.none),
            "A co-op request entered during recovery.");
        Reject(() => client.Connect(null), "A direct grant replaced the abort cleanup owner.");
        Reject(() => client.MatchmakeWithRecoveredSession(), "A queue request entered during abort cleanup.");
        Reject(() => client.ReconnectWithRecoveredSession(), "Reconnect entered during abort cleanup.");
    }

    private static void InstallConnection(SelfHostedBattleClient client, UdpClient receiver)
    {
        MatchConnectionGrant grant = CreateGrant(receiver, MatchId);
        typeof(SelfHostedBattleClient).GetField("connection", InstanceFields)
            .SetValue(client, new MatchConnection(grant));
        typeof(SelfHostedBattleClient).GetField("lifetime", InstanceFields)
            .SetValue(client, new CancellationTokenSource());
        typeof(SelfHostedBattleClient).GetField("_observedPoseCatalogRevision", InstanceFields)
            .SetValue(client, ObservedInfantryPoseCatalogData.BuiltIn.Revision);
        typeof(SelfHostedBattleClient).GetMethod("BeginSnapshotScope", InstanceFields)
            .Invoke(client, new object[] { grant });
        typeof(SelfHostedBattleClient).GetProperty("Active").SetValue(null, client, null);
        typeof(SelfHostedBattleClient).GetProperty("IsConnected").SetValue(client, true, null);
    }

    private static MatchConnectionGrant CreateGrant(UdpClient receiver, string matchId)
    {
        var grant = new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = (uint)((IPEndPoint)receiver.Client.LocalEndPoint).Port,
            MatchId = matchId, ManifestHash = new string('a', 64), PlayerId = PlayerId, SessionId = 1,
            SessionKey = ByteString.CopyFrom(new byte[SessionKeyBytes]), Ticket = "controlled-abort-fixture",
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + TicketLifetimeSeconds,
        };
        return grant;
    }

    private static async Task VerifyReleasedAdapterAsync(GameController game, SelfHostedBattleClient client,
        UdpClient receiver, Action<MatchSnapshot> oldHandler)
    {
        Task admission = client.Connect(CreateGrant(receiver, "replacement-after-abort"));
        oldHandler(Snapshot(BattlePhase.Aborted));
        Require(client.OwnsMatch && client.State == null && !game.IsSelfHostedAbortRecovery,
            "Releasing cleanup must permit a fresh scope without reviving the old callback.");
        client.LeaveMatch();
        try
        {
            await admission;
        }
        catch (OperationCanceledException)
        {
            return;
        }
        catch (ObjectDisposedException)
        {
            return;
        }
        catch (SocketException failure) when (failure.SocketErrorCode == SocketError.OperationAborted ||
            failure.SocketErrorCode == SocketError.Interrupted || failure.SocketErrorCode == SocketError.NotSocket)
        {
            return;
        }

        throw new InvalidOperationException(
            "The deliberately unanswered replacement admission unexpectedly completed.");
    }

    private static MatchSnapshot Snapshot(BattlePhase phase)
    {
        return new MatchSnapshot
        {
            MatchId = MatchId, ManifestHash = new string('a', 64), Phase = phase, StateRevision = 1,
        };
    }

    private static void Apply(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", InstanceFields).Invoke(client, new object[]
        {
            new MatchReply
            {
                Snapshot = snapshot, ObservedPoseCatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision,
            },
        });
    }

    private static void SetGame(GameController game, string field, object value)
    {
        typeof(GameController).GetField(field, InstanceFields).SetValue(game, value);
    }

    private static void Reject(Action action, string message)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }

        throw new InvalidOperationException(message);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
