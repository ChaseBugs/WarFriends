using System.Net;

using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks failed cleanup retains original scope and cannot be mistaken for confirmed cancellation.</summary>
internal static class RematchAttemptCancellationTests
{
    internal static async Task RunAsync()
    {
        string sourceId = "m" + new string('a', 32);
        string nextId = "m" + new string('b', 32);
        string player = new string('a', 32);
        var source = new MatchSnapshot { MatchId = sourceId, Phase = BattlePhase.Ended };
        source.Players.Add(new BattlePlayerState { PlayerId = player });
        source.Players.Add(new BattlePlayerState { PlayerId = new string('b', 32) });
        ByteString original = source.ToByteString();
        using var handler = new CleanupHandler(source, nextId);
        using var owner = new SelfHostedRematchAttempt(new BackendClient(
            new Uri("http://127.0.0.1:8080/"), handler, true), "fixture-session", source, player);
        await RequireFailureAsync(owner.CancelAsync);
        Require(owner.IsCancellationRequested && !owner.IsCancellationConfirmed,
            "A failed consent cancellation must retain unresolved cleanup.");
        try
        {
            await owner.FindAsync(CancellationToken.None);
            throw new InvalidDataException("An unresolved cancelled owner restarted discovery.");
        }
        catch (OperationCanceledException)
        {
            // Discovery is blocked independently of the remote cleanup receipt.
        }
        await RequireFailureAsync(owner.CancelAsync);
        Require(!owner.IsCancellationConfirmed, "A failed allocated cancellation must not confirm cleanup.");
        await owner.CancelAsync();
        Require(owner.IsCancellationConfirmed && handler.Calls == CleanupHandler.ExpectedCalls &&
            source.ToByteString().Equals(original), "Cleanup retry changed scope or original terminal state.");
        Console.WriteLine("PASS: actual Unity rematch owner retains " +
            "failed consent/allocation cleanup and original scope");
    }

    private static async Task RequireFailureAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (HttpRequestException)
        {
            return;
        }
        throw new InvalidDataException("Expected unavailable cleanup was treated as confirmed.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    private sealed class CleanupHandler(MatchSnapshot source, string nextId) : HttpMessageHandler
    {
        internal const int ExpectedCalls = 5;
        internal int Calls { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = request.Content ?? throw new InvalidDataException("Cleanup request body is missing.");
            var body = MatchGrantRequest.Parser.ParseFrom(await content.ReadAsByteArrayAsync(cancellationToken));
            Require(body.MatchId == source.MatchId && request.Headers.Authorization?.Parameter == "fixture-session",
                "Cleanup retried another source identity or credential.");
            Calls++;
            bool isAllocation = Calls is 3 or 5;
            Require(request.RequestUri?.AbsolutePath == (isAllocation ?
                "/v1/battle/rematch/cancel-allocation" : "/v1/battle/rematch/cancel"),
                "Cleanup selected a generic queue cancellation path.");
            if (Calls is 1 or 3)
            {
                return Reply(new ErrorResponse { Code = "unavailable" }, HttpStatusCode.ServiceUnavailable);
            }
            if (Calls == ExpectedCalls)
            {
                return Reply(new MatchQueueReply { Code = "completed", MatchId = nextId }, HttpStatusCode.OK);
            }
            var consent = new MatchRematchConsent
            {
                MatchId = source.MatchId, Status = "allocated", NextMatchId = nextId, Revision = 3,
                ExpiresUnixMilliseconds = DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeMilliseconds(),
            };
            consent.AcceptedPlayerIds.Add(source.Players.Select(player => player.PlayerId));
            return Reply(consent, HttpStatusCode.OK);
        }

        private static HttpResponseMessage Reply(IMessage body, HttpStatusCode status)
        {
            return new HttpResponseMessage(status)
            {
                Content = new ByteArrayContent(body.ToByteArray())
                {
                    Headers =
                    {
                        ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-protobuf"),
                    },
                },
            };
        }
    }
}
