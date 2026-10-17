using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks additive queue wire compatibility and prevents an empty scope becoming a legacy mutation.</summary>
internal static class QueueAttemptWireTests
{
    internal static int Run()
    {
        var scoped = new MatchQueueRequest { AttemptToken = "opaque-attempt-credential" };
        if (!MatchQueueRequest.Parser.ParseFrom(scoped.ToByteArray()).Equals(scoped))
        {
            throw new Exception("Scoped queue request did not retain its opaque token.");
        }

        var unknown = MatchQueueRequest.Parser.ParseFrom(new byte[] { 16, 1 });
        if (unknown.Equals(new MatchQueueRequest { AttemptToken = unknown.AttemptToken }))
        {
            throw new Exception("Unknown queue fields escaped exact request validation.");
        }

        using var backend = new BackendClient(new Uri("http://127.0.0.1:1/"), true);
        foreach (string emptyScope in new[] { "", " " })
        {
            Reject(() => backend.JoinMatchQueueAsync("session", emptyScope, CancellationToken.None));
            Reject(() => backend.CancelMatchQueueAsync("session", emptyScope, CancellationToken.None));
            Reject(() => backend.FindMatchAsync(
                "session", emptyScope, TimeSpan.FromSeconds(5), CancellationToken.None));
        }

        return 8;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (ArgumentException)
        {
            return;
        }

        throw new Exception("An empty scoped credential fell back to an account-wide request.");
    }
}
