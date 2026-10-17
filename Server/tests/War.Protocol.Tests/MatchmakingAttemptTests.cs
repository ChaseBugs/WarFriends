using System.Net;
using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks cancellation resource ownership using the exact plain C# source shipped to Unity.</summary>
internal static class MatchmakingAttemptTests
{
    private const string AccessToken = "local-matchmaking-test-token";
    private const int TimeoutSeconds = 10;

    internal static async Task<int> RunAsync()
    {
        int checks = await VerifyPendingCleanupAsync();
        checks += await VerifyFailedCleanupRetryAsync();
        checks += await VerifyPairedCleanupAsync();
        Console.WriteLine("PASS: " + checks + " recovered Client matchmaking cancellation checks");
        return checks;
    }

    private static async Task<int> VerifyPendingCleanupAsync()
    {
        var handler = new ControlledQueueHandler();
        using var attempt = CreateAttempt(handler);
        Task<MatchConnectionGrant> search = attempt.FindAsync(TimeoutSeconds);
        await handler.JoinObserved.Task;
        Task cancellation = attempt.CancelAsync();
        Require(attempt.IsCancellationRequested && handler.CancelRequests == 1,
            "Cancellation must stop local search and send one authenticated remote cleanup.");
        Require(ReferenceEquals(cancellation, attempt.CancelAsync()) && handler.CancelRequests == 1,
            "Repeated cancellation must share the outstanding HTTP task.");
        await ExpectCanceledAsync(search);
        Task completion = attempt.CompleteAsync();
        Require(!completion.IsCompleted && !handler.IsDisposed,
            "Search completion must not dispose a pending remote cancellation request.");
        handler.AcceptCancellation();
        await cancellation;
        await completion;
        Require(handler.IsDisposed, "The original HTTP owner is released after cancellation acknowledgement.");
        return 4;
    }

    private static async Task<int> VerifyFailedCleanupRetryAsync()
    {
        var handler = new ControlledQueueHandler();
        using var attempt = CreateAttempt(handler);
        Task<MatchConnectionGrant> search = attempt.FindAsync(TimeoutSeconds);
        await handler.JoinObserved.Task;
        Task cancellation = attempt.CancelAsync();
        handler.RejectCancellation();
        await ExpectCanceledAsync(search);
        await ExpectHttpFailureAsync(cancellation);
        await ExpectHttpFailureAsync(attempt.CompleteAsync());
        Require(!handler.IsDisposed, "An unconfirmed remote cancellation must retain retry resources.");
        Task retry = attempt.CancelAsync();
        Require(handler.CancelRequests == 2 && !ReferenceEquals(retry, cancellation),
            "A failed cleanup must be retryable with the same attempt's authentication.");
        handler.AcceptCancellation();
        await retry;
        await attempt.CompleteAsync();
        Require(handler.IsDisposed, "Successful retry releases only the retained attempt.");
        return 3;
    }

    private static SelfHostedMatchmakingAttempt CreateAttempt(ControlledQueueHandler handler)
    {
        var backend = new BackendClient(new Uri("http://127.0.0.1:30001/"), handler, true);
        return new SelfHostedMatchmakingAttempt(backend, AccessToken);
    }

    private static async Task<int> VerifyPairedCleanupAsync()
    {
        var handler = new ControlledQueueHandler();
        using var attempt = CreateAttempt(handler);
        Task<MatchConnectionGrant> search = attempt.FindAsync(TimeoutSeconds);
        await handler.JoinObserved.Task;
        Task cancellation = attempt.CancelAsync();
        handler.AcceptCancellation("already-paired");
        await ExpectCanceledAsync(search);
        await ExpectUnconfirmedAsync(cancellation);
        await ExpectUnconfirmedAsync(attempt.CompleteAsync());
        Require(!handler.IsDisposed, "An allocated match is not a successful queue cancellation.");
        Task retry = attempt.CancelAsync();
        handler.AcceptCancellation("not-queued");
        await retry;
        await attempt.CompleteAsync();
        Require(handler.IsDisposed && handler.CancelRequests == 2,
            "Only a later authoritative cancellation acknowledgement releases the attempt.");
        return 2;
    }

    private static async Task ExpectUnconfirmedAsync(Task pending)
    {
        try
        {
            await pending;
        }
        catch (InvalidOperationException)
        {
            return;
        }

        throw new Exception("An already-paired response was accepted as queue cleanup.");
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

        throw new Exception("The canceled search returned a grant.");
    }

    private static async Task ExpectHttpFailureAsync(Task pending)
    {
        try
        {
            await pending;
        }
        catch (HttpRequestException)
        {
            return;
        }

        throw new Exception("A failed cancellation was silently reported as success.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed class ControlledQueueHandler : HttpMessageHandler
    {
        private TaskCompletionSource<HttpResponseMessage> _cancellation = NewResponse();

        internal TaskCompletionSource<bool> JoinObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        internal int CancelRequests { get; private set; }

        internal bool IsDisposed { get; private set; }

        internal void AcceptCancellation(string code = "cancelled")
        {
            _cancellation.SetResult(Reply(code));
        }

        internal void RejectCancellation()
        {
            _cancellation.SetException(new HttpRequestException("Controlled queue cleanup failure."));
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Require(request.Headers.Authorization?.Parameter == AccessToken,
                "Every queue request must retain the original bearer token.");
            if (request.RequestUri?.AbsolutePath.EndsWith("/join", StringComparison.Ordinal) == true)
            {
                JoinObserved.TrySetResult(true);
                return Task.FromResult(Reply("waiting"));
            }

            Require(request.RequestUri?.AbsolutePath.EndsWith("/cancel", StringComparison.Ordinal) == true,
                "The fixture must not receive an unexpected Backend request.");
            if (CancelRequests != 0)
            {
                _cancellation = NewResponse();
            }

            CancelRequests++;
            return _cancellation.Task;
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }

        private static TaskCompletionSource<HttpResponseMessage> NewResponse()
        {
            return new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        private static HttpResponseMessage Reply(string code)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(new MatchQueueReply { Code = code }.ToByteArray())
            };
        }
    }
}
