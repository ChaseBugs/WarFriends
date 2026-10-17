using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks normal disconnect routing and delayed lobby reset against actual recovered components.</summary>
[InitializeOnLoad]
public static class UnityMatchmakingCancellationAudit
{
    private const string SessionKey = "WarFriends.MatchmakingCancellationAudit";
    private const string AccessToken = "native-queue-test-token";
    private const int TimeoutSeconds = 10;
    private const int PollMilliseconds = 20;
    private const int MaximumPolls = 100;
    private const float FirstDelaySeconds = 0.1f;
    private const float ReplacementDelaySeconds = 5f;
    private const int ObserveDelayMilliseconds = 200;
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

    static UnityMatchmakingCancellationAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += BeginWhenPlaying;
        }
    }

    /// <summary>Enters an isolated Play Mode scene so component destruction uses the actual Unity lifecycle.</summary>
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
        RunChecksAsync();
    }

    private static async void RunChecksAsync()
    {
        GameObject sources = null;
        try
        {
            sources = new GameObject("InactiveQueueSourceControllers");
            sources.SetActive(false);
            PhotonConnectionManager photon = sources.AddComponent<PhotonConnectionManager>();
            typeof(Singleton<PhotonConnectionManager>).GetField("_instance",
                BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, photon);
            await VerifyPendingDisconnectAsync();
            await VerifyDestroyedOwnerAsync();
            await VerifyDelayedResetAsync(sources.AddComponent<GameControllerDeathMatch>());
            Debug.Log("PASS: normal disconnect cancels queue search, waits for authenticated HTTP cleanup, " +
                "and delayed reset/disable cannot create or clear a replacement lobby request; " +
                "controlled component/HTTP callbacks, no allocated match or rendered UI.");
            SessionState.SetBool(SessionKey, false);
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            SessionState.SetBool(SessionKey, false);
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (sources != null)
            {
                UnityEngine.Object.DestroyImmediate(sources);
            }
        }
    }

    private static async Task VerifyPendingDisconnectAsync()
    {
        GameObject owner = new GameObject("PendingQueueAdapter");
        try
        {
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            var handler = new QueueHandler();
            using (var backend = new BackendClient(new Uri("http://127.0.0.1:30001/"), handler, true))
            {
                Task search = InstallSearch(client, backend);
                Require(client.IsMatchmaking && !client.OwnsMatch, "The source fixture must own only a pending queue.");
                PhotonConnectionManager.Disconnect();
                Require(IsCancellationRequested(client),
                    "Normal Disconnect must cancel matchmaking before UDP admission.");
                await ExpectCanceledAsync(search);
                Require(handler.CancelRequests == 1 && client.IsMatchmaking && !handler.IsDisposed,
                    "The original HTTP owner must remain alive while remote cleanup is pending.");
                Task explicitCancellation = client.CancelMatchmaking();
                VerifyDirectAdmissionBlocked(client);
                handler.AcceptCancellation();
                await explicitCancellation;
                for (int poll = 0; poll < MaximumPolls && client.IsMatchmaking; poll++)
                {
                    await Task.Delay(PollMilliseconds);
                }

                Require(!client.IsMatchmaking && handler.IsDisposed,
                    "Only confirmed remote cleanup releases the pending queue owner.");
                await client.CancelMatchmaking();
                Require(handler.CancelRequests == 1, "Repeated UI cancellation must not send another queue request.");
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void VerifyDirectAdmissionBlocked(SelfHostedBattleClient client)
    {
        bool hasRejected = false;
        try
        {
            client.Connect(null).GetAwaiter().GetResult();
        }
        catch (InvalidOperationException)
        {
            hasRejected = true;
        }

        Require(hasRejected, "Direct admission must not bypass account-scoped pending queue cleanup.");
    }

    private static async Task VerifyDestroyedOwnerAsync()
    {
        GameObject owner = new GameObject("DestroyedQueueAdapter");
        try
        {
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            var handler = new QueueHandler();
            using (var backend = new BackendClient(new Uri("http://127.0.0.1:30001/"), handler, true))
            {
                Task search = InstallSearch(client, backend);
                UnityEngine.Object.DestroyImmediate(owner);
                await ExpectCanceledAsync(search);
                Require(handler.CancelRequests == 1 && !handler.IsDisposed,
                    "Destroying the component must not abort its pending HTTP cancellation.");
                handler.AcceptCancellation();
                for (int poll = 0; poll < MaximumPolls && !handler.IsDisposed; poll++)
                {
                    await Task.Delay(PollMilliseconds);
                }

                Require(handler.IsDisposed, "A destroyed owner must release resources after remote cleanup finishes.");
            }
        }
        finally
        {
            if (owner != null)
            {
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    private static async Task VerifyDelayedResetAsync(GameControllerDeathMatch controller)
    {
        MethodInfo begin = typeof(GameControllerDeathMatch)
            .GetMethod("BeginSelfHostedRandomMatchmakingAsync", PrivateInstance);
        MethodInfo reset = typeof(GameControllerDeathMatch).GetMethod("Reset", PrivateInstance);
        FieldInfo request = typeof(GameControllerDeathMatch).GetField("_matchmakingRequest", PrivateInstance);
        var deferred = new DeferredContinuationContext();
        SynchronizationContext previous = SynchronizationContext.Current;
        try
        {
            SynchronizationContext.SetSynchronizationContext(deferred);
            begin.Invoke(controller, new object[] { FirstDelaySeconds });
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(previous);
        }

        reset.Invoke(controller, null);
        begin.Invoke(controller, new object[] { ReplacementDelaySeconds });
        object replacement = request.GetValue(controller);
        for (int poll = 0; poll < MaximumPolls && !deferred.HasCallbacks; poll++)
        {
            await Task.Delay(PollMilliseconds);
        }

        Require(deferred.HasCallbacks, "The canceled continuation must be held until its replacement exists.");
        deferred.Drain();
        Require(ReferenceEquals(request.GetValue(controller), replacement),
            "A canceled delay continuation must not clear the replacement lobby request.");
        reset.Invoke(controller, null);
        await Task.Delay(ObserveDelayMilliseconds);
        Require(request.GetValue(controller) == null &&
            UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>() == null,
            "Canceled delayed starts must not create an adapter or begin recovered-session matchmaking.");
        begin.Invoke(controller, new object[] { FirstDelaySeconds });
        typeof(GameControllerDeathMatch).GetMethod("OnDisable", PrivateInstance).Invoke(controller, null);
        await Task.Delay(ObserveDelayMilliseconds);
        Require(request.GetValue(controller) == null &&
            UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>() == null,
            "Disabling the source controller must cancel its delayed start.");
    }

    private static Task InstallSearch(SelfHostedBattleClient client, BackendClient backend)
    {
        FieldInfo field = typeof(SelfHostedBattleClient).GetField("matchmaking", PrivateInstance);
        if (field.FieldType == typeof(CancellationTokenSource))
        {
            // The same audit reproduces the old Disconnect routing failure before the production fix.
            var source = new CancellationTokenSource();
            field.SetValue(client, source);
            typeof(SelfHostedBattleClient).GetField("matchmakingBackend", PrivateInstance).SetValue(client, backend);
            typeof(SelfHostedBattleClient).GetField("matchmakingToken", PrivateInstance).SetValue(client, AccessToken);
            return backend.FindMatchAsync(AccessToken, TimeSpan.FromSeconds(TimeoutSeconds), source.Token);
        }

        object attempt = Activator.CreateInstance(field.FieldType, PrivateInstance, null,
            new object[] { backend, AccessToken }, null);
        field.SetValue(client, attempt);
        return (Task)field.FieldType.GetMethod("FindAsync", PrivateInstance)
            .Invoke(attempt, new object[] { TimeoutSeconds });
    }

    private static bool IsCancellationRequested(SelfHostedBattleClient client)
    {
        object attempt = typeof(SelfHostedBattleClient).GetField("matchmaking", PrivateInstance).GetValue(client);
        CancellationTokenSource oldSource = attempt as CancellationTokenSource;
        if (oldSource != null)
        {
            return oldSource.IsCancellationRequested;
        }

        return (bool)attempt.GetType().GetProperty("IsCancellationRequested", PrivateInstance).GetValue(attempt, null);
    }

    private static async Task ExpectCanceledAsync(Task pending)
    {
        try
        {
            await pending;
        }
        catch (OperationCanceledException)
        {
            return;
        }

        throw new InvalidOperationException("A canceled queue search returned a match grant.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class QueueHandler : HttpMessageHandler
    {
        private readonly TaskCompletionSource<HttpResponseMessage> _cancellation =
            new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);

        internal int CancelRequests { get; private set; }

        internal bool IsDisposed { get; private set; }

        internal void AcceptCancellation()
        {
            _cancellation.SetResult(Reply("cancelled"));
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Require(request.Headers.Authorization.Parameter == AccessToken, "Queue authentication must be preserved.");
            if (request.RequestUri.AbsolutePath.EndsWith("/join", StringComparison.Ordinal))
            {
                return Task.FromResult(Reply("waiting"));
            }

            Require(request.RequestUri.AbsolutePath.EndsWith("/cancel", StringComparison.Ordinal),
                "Unexpected queue fixture request.");
            CancelRequests++;
            return _cancellation.Task;
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            _cancellation.TrySetCanceled();
            base.Dispose(disposing);
        }

        private static HttpResponseMessage Reply(string code)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(new MatchQueueReply { Code = code }.ToByteArray())
            };
        }
    }

    private sealed class DeferredContinuationContext : SynchronizationContext
    {
        private readonly Queue<Action> _callbacks = new Queue<Action>();

        internal bool HasCallbacks
        {
            get
            {
                lock (_callbacks)
                {
                    return _callbacks.Count != 0;
                }
            }
        }

        public override void Post(SendOrPostCallback callback, object state)
        {
            lock (_callbacks)
            {
                _callbacks.Enqueue(() => callback(state));
            }
        }

        internal void Drain()
        {
            while (HasCallbacks)
            {
                Action callback;
                lock (_callbacks)
                {
                    callback = _callbacks.Dequeue();
                }

                callback();
            }
        }
    }
}
