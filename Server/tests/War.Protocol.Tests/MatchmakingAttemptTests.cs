using System.Net;
using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks cancellation resource ownership using the exact plain C# source shipped to Unity.</summary>
internal static class MatchmakingAttemptTests
{
    private const string AccessToken = "local-matchmaking-test-token";
    private const int TimeoutSeconds = 10;
    private const long FixtureExpiryUnixSeconds = 2000;

    internal static async Task<int> RunAsync()
    {
        int checks = await VerifyPendingCleanupAsync();
        checks += await VerifyFailedCleanupRetryAsync();
        checks += await VerifyPairedCleanupAsync();
        checks += await VerifyCancellationDuringIssuanceAsync();
        checks += await VerifyFailedIssuanceAsync();
        checks += await VerifyCancellationBeforeSearchAsync();
        checks += await VerifyRepeatedSearchRejectedAsync();
        checks += await VerifyLoadingOwnershipAsync();
        checks += await VerifyLoadingOwnerReleaseAsync();
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

    private static async Task<int> VerifyCancellationDuringIssuanceAsync()
    {
        var handler = new ControlledQueueHandler { HoldIssuance = true };
        using var attempt = CreateAttempt(handler);
        var search = attempt.FindAsync(TimeoutSeconds);
        await handler.IssuanceObserved.Task;
        var cancellation = attempt.CancelAsync();
        Require(!cancellation.IsCompleted && handler.CancelRequests == 0 && !handler.IsDisposed,
            "Pending issuance must retain HTTP ownership without account-wide cancellation.");
        handler.AcceptIssuance();
        await handler.CancellationObserved.Task;
        Require(!handler.JoinObserved.Task.IsCompleted && handler.IssueRequests == 1,
            "Cancellation during issuance must skip join and retain the one issued credential.");
        handler.AcceptCancellation();
        await cancellation;
        await ExpectCanceledAsync(search);
        await attempt.CompleteAsync();
        Require(handler.IsDisposed, "Scoped cleanup after issuance must release its original HTTP owner.");
        return 3;
    }

    private static async Task<int> VerifyFailedIssuanceAsync()
    {
        var handler = new ControlledQueueHandler { HoldIssuance = true };
        using var attempt = CreateAttempt(handler);
        var search = attempt.FindAsync(TimeoutSeconds);
        await handler.IssuanceObserved.Task;
        handler.RejectIssuance();
        await ExpectHttpFailureAsync(search);
        await attempt.CancelAsync();
        await attempt.CompleteAsync();
        Require(handler.CancelRequests == 0 && !handler.JoinObserved.Task.IsCompleted && handler.IsDisposed,
            "Failed stateless issuance must not fall back to account-wide queue cleanup.");
        return 1;
    }

    private static async Task<int> VerifyCancellationBeforeSearchAsync()
    {
        var handler = new ControlledQueueHandler();
        using var attempt = CreateAttempt(handler);
        await attempt.CancelAsync();
        await ExpectCanceledAsync(attempt.FindAsync(TimeoutSeconds));
        await attempt.CompleteAsync();
        Require(handler.IssueRequests == 0 && handler.CancelRequests == 0 && handler.IsDisposed,
            "An already cancelled owner must never issue a credential or send a join.");
        return 1;
    }

    private static async Task<int> VerifyRepeatedSearchRejectedAsync()
    {
        var handler = new ControlledQueueHandler();
        using var attempt = CreateAttempt(handler);
        var search = attempt.FindAsync(TimeoutSeconds);
        await handler.JoinObserved.Task;
        await ExpectInvalidOperationAsync(attempt.FindAsync(TimeoutSeconds));
        Task completion = attempt.CompleteAsync();
        Require(handler.IssueRequests == 1 && !completion.IsCompleted && !handler.IsDisposed,
            "A duplicate search must neither issue another scope nor complete the original search owner.");
        Task cancellation = attempt.CancelAsync();
        handler.AcceptCancellation();
        await ExpectCanceledAsync(search);
        await cancellation;
        await completion;
        Require(handler.IsDisposed && handler.CancelRequests == 1,
            "The original search still owns and completes its single scoped cancellation.");
        return 2;
    }

    private static SelfHostedMatchmakingAttempt CreateAttempt(ControlledQueueHandler handler)
    {
        var backend = new BackendClient(new Uri("http://127.0.0.1:30001/"), handler, true);
        return new SelfHostedMatchmakingAttempt(backend, AccessToken);
    }

    private static async Task<int> VerifyLoadingOwnershipAsync()
    {
        var handler = new ControlledQueueHandler { ReturnPair = true };
        using var attempt = CreateAttempt(handler);
        await attempt.FindAsync(TimeoutSeconds);
        attempt.RetainForLoading();
        await attempt.CompleteAsync();
        Require(attempt.IsRetainedForLoading && !handler.IsDisposed,
            "Successful admission must retain its original scoped HTTP owner through loading.");

        Task cancellation = attempt.CancelAsync();
        handler.AcceptCancellation("already-paired");
        await ExpectInvalidOperationAsync(cancellation);
        await ExpectInvalidOperationAsync(attempt.CompleteAsync());
        Require(!handler.IsDisposed, "Running-first refusal must retain loading cleanup ownership.");

        Task retry = attempt.CancelAsync();
        handler.AcceptCancellation();
        await retry;
        await attempt.CompleteAsync();
        Require(handler.IsDisposed && handler.IssueRequests == 1 && handler.CancelRequests == 2,
            "Loading cancellation retries must use the admitted attempt without issuing another credential.");
        return 3;
    }

    private static async Task<int> VerifyLoadingOwnerReleaseAsync()
    {
        var handler = new ControlledQueueHandler { ReturnPair = true };
        using var attempt = CreateAttempt(handler);
        try
        {
            attempt.RetainForLoading();
            throw new Exception("A search without a grant retained loading authority.");
        }
        catch (InvalidOperationException)
        {
            // No signed pair has been found, so loading ownership cannot exist yet.
        }

        await attempt.FindAsync(TimeoutSeconds);
        attempt.RetainForLoading();
        await attempt.CompleteAsync();
        await attempt.CompleteAsync();
        Require(!handler.IsDisposed && handler.CancelRequests == 0,
            "Repeated successful search completion must not cancel or release the loading owner.");
        attempt.Dispose();
        Require(handler.IsDisposed && handler.CancelRequests == 0,
            "Terminal owner release must dispose locally without changing the server outcome.");
        return 3;
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
        await ExpectInvalidOperationAsync(cancellation);
        await ExpectInvalidOperationAsync(attempt.CompleteAsync());
        Require(!handler.IsDisposed, "An allocated match is not a successful queue cancellation.");
        Task retry = attempt.CancelAsync();
        handler.AcceptCancellation("not-queued");
        await retry;
        await attempt.CompleteAsync();
        Require(handler.IsDisposed && handler.CancelRequests == 2,
            "Only a later authoritative cancellation acknowledgement releases the attempt.");
        return 2;
    }

    private static async Task ExpectInvalidOperationAsync(Task pending)
    {
        try
        {
            await pending;
        }
        catch (InvalidOperationException)
        {
            return;
        }

        throw new Exception("An unconfirmed or duplicate matchmaking operation was accepted.");
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
        private readonly TaskCompletionSource<HttpResponseMessage> _issuance = NewResponse();
        internal bool HoldIssuance { get; set; }
        internal bool ReturnPair { get; set; }
        internal int IssueRequests { get; private set; }
        internal TaskCompletionSource<bool> IssuanceObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        internal TaskCompletionSource<bool> CancellationObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        internal void AcceptIssuance()
        {
            _issuance.SetResult(IssueReply());
        }

        internal void RejectIssuance()
        {
            _issuance.SetException(new HttpRequestException("Controlled credential issuance failure."));
        }

        private static HttpResponseMessage IssueReply()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(new MatchQueueAttemptGrant
                    { Token = "fixture-attempt-token", ExpiresUnixSeconds = FixtureExpiryUnixSeconds }.ToByteArray())
            };
        }

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
            if (request.RequestUri?.AbsolutePath.EndsWith("/grant", StringComparison.Ordinal) == true)
            {
                return Task.FromResult(GrantReply());
            }
            if (request.RequestUri?.AbsolutePath.EndsWith("/attempt", StringComparison.Ordinal) == true)
            {
                IssueRequests++;
                IssuanceObserved.TrySetResult(true);
                return HoldIssuance ? _issuance.Task : Task.FromResult(IssueReply());
            }

            var scoped = MatchQueueRequest.Parser.ParseFrom(
                request.Content!.ReadAsByteArrayAsync().GetAwaiter().GetResult());
            Require(scoped.AttemptToken == "fixture-attempt-token", "Search and cleanup must retain one attempt token.");
            if (request.RequestUri?.AbsolutePath.EndsWith("/join", StringComparison.Ordinal) == true)
            {
                JoinObserved.TrySetResult(true);
                if (ReturnPair)
                {
                    var pair = new MatchQueueReply { Code = "paired", MatchId = "m" + new string('c', 32) };
                    pair.PlayerIds.Add(new string('a', 32));
                    pair.PlayerIds.Add(new string('b', 32));
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(pair.ToByteArray())
                    });
                }

                return Task.FromResult(Reply("waiting"));
            }

            Require(request.RequestUri?.AbsolutePath.EndsWith("/cancel", StringComparison.Ordinal) == true,
                "The fixture must not receive an unexpected Backend request.");
            if (CancelRequests != 0)
            {
                _cancellation = NewResponse();
            }

            CancelRequests++;
            CancellationObserved.TrySetResult(true);
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

        private static HttpResponseMessage GrantReply()
        {
            const int SessionKeyBytes = 32;
            var grant = new MatchConnectionGrant
            {
                MatchId = "m" + new string('c', 32), PlayerId = new string('a', 32), SessionId = 1,
                SessionKey = ByteString.CopyFrom(new byte[SessionKeyBytes])
            };
            for (int i = 0; i < 2; i++)
            {
                var view = new BattlePlayerView
                {
                    PlayerId = new string(i == 0 ? 'a' : 'b', 32), DisplayName = "Fixture player", Fraction = i + 1
                };
                view.VisualIds.Add(new[] { "head", "body", "legs", "decal" });
                view.Weapons.Add(new BattleWeaponView { SourceId = "fixture-rifle" });
                grant.PlayerViews.Add(view);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(grant.ToByteArray())
            };
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
