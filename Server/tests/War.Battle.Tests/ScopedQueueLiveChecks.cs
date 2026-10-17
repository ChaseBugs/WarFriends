using War.Client;

/// <summary>Checks attempt ownership through real authenticated protobuf and Worker control routes.</summary>
internal static class ScopedQueueLiveChecks
{
    internal static async Task RunAsync(Scenario scenario, Func<Task> restartBackendAsync)
    {
        var attempts = await PrepareWaitingAttemptsAsync(scenario, restartBackendAsync);
        string firstMatchId = await VerifyPairedRestartAsync(scenario, attempts, restartBackendAsync);
        await VerifyReplacementRestartAsync(scenario, attempts.CurrentToken, firstMatchId, restartBackendAsync);
        Console.WriteLine(
            "PASS: scoped queue ownership and exact grants survive three actual Backend process restarts");
    }

    private static async Task<AttemptCredentials> PrepareWaitingAttemptsAsync(
        Scenario scenario, Func<Task> restartBackendAsync)
    {
        BackendClient left = scenario.Left;
        BackendClient right = scenario.Right;
        string[] tokens = scenario.AccessTokens;
        CancellationToken cancellationToken = scenario.CancellationToken;
        var cancelled = await left.CreateMatchQueueAttemptAsync(tokens[0], cancellationToken);
        Require((await left.CancelMatchQueueAsync(tokens[0], cancelled.Token, cancellationToken)).Code == "not-queued",
            "An early HTTP cancellation must persist its own scope.");
        Require((await left.JoinMatchQueueAsync(tokens[0], cancelled.Token, cancellationToken)).Code == "cancelled",
            "A delayed HTTP join must not reopen a cancelled attempt.");
        var current = await left.CreateMatchQueueAttemptAsync(tokens[0], cancellationToken);
        Require((await left.JoinMatchQueueAsync(
            tokens[0], current.Token, cancellationToken)).Code == "waiting",
            "A fresh scoped attempt must enter the queue.");
        await restartBackendAsync();
        Require((await left.JoinMatchQueueAsync(tokens[0], cancelled.Token, cancellationToken)).Code == "cancelled",
            "A real Backend restart must retain cancellation before first admission.");
        Require((await left.JoinMatchQueueAsync(tokens[0], current.Token, cancellationToken)).Code == "waiting",
            "A waiting attempt must survive restart with its original credential.");
        Require((await left.CancelMatchQueueAsync(
            tokens[0], cancelled.Token, cancellationToken)).Code == "not-queued" &&
            (await left.CancelMatchQueueAsync(
                tokens[0], cancellationToken)).Code == "attempt-conflict",
            "Old and unscoped cancellations must preserve the current waiting attempt.");
        Require((await right.JoinMatchQueueAsync(tokens[1], cancellationToken)).Code == "waiting",
            "An unscoped caller must not consume a scoped candidate.");
        await right.CancelMatchQueueAsync(tokens[1], cancellationToken);
        return new AttemptCredentials(cancelled.Token, current.Token);
    }

    private static async Task<string> VerifyPairedRestartAsync(
        Scenario scenario, AttemptCredentials attempts, Func<Task> restartBackendAsync)
    {
        BackendClient left = scenario.Left;
        BackendClient right = scenario.Right;
        string[] tokens = scenario.AccessTokens;
        CancellationToken cancellationToken = scenario.CancellationToken;
        await VerifyForeignCredentialAsync(right, tokens[1], attempts.CurrentToken, cancellationToken);
        var peer = await right.CreateMatchQueueAttemptAsync(tokens[1], cancellationToken);
        var paired = await right.JoinMatchQueueAsync(tokens[1], peer.Token, cancellationToken);
        var replay = await left.FindMatchAsync(
            tokens[0], attempts.CurrentToken, TimeSpan.FromSeconds(5), cancellationToken);
        Require(paired.Code == "paired" && replay.MatchId == paired.MatchId,
            "Both scoped participants must recover the same frozen pair.");
        await restartBackendAsync();
        var restartedGrant = await left.FindMatchAsync(
            tokens[0], attempts.CurrentToken, TimeSpan.FromSeconds(5), cancellationToken);
        Require(restartedGrant.Equals(replay),
            "Backend restart must preserve the exact match, session key, ticket, roster and frozen grant.");
        Require((await left.CancelMatchQueueAsync(
            tokens[0], attempts.CancelledToken, cancellationToken)).Code == "not-queued" &&
            (await left.CancelMatchQueueAsync(
                tokens[0], cancellationToken)).Code == "attempt-conflict",
            "Old and unscoped cancellation must not capture the new pair.");
        Require((await left.CancelMatchQueueAsync(
            tokens[0], attempts.CurrentToken, cancellationToken)).Code == "cancelled",
            "The owning scoped request must cancel the registered prestart Worker match.");
        Require((await left.JoinMatchQueueAsync(
            tokens[0], attempts.CurrentToken, cancellationToken)).Code == "cancelled",
            "A completed scoped cancellation must fence late HTTP admission.");
        return paired.MatchId;
    }

    private static async Task VerifyReplacementRestartAsync(
        Scenario scenario, string previousAttempt, string previousMatchId, Func<Task> restartBackendAsync)
    {
        BackendClient left = scenario.Left;
        BackendClient right = scenario.Right;
        string[] tokens = scenario.AccessTokens;
        CancellationToken cancellationToken = scenario.CancellationToken;
        var replacement = await left.CreateMatchQueueAttemptAsync(tokens[0], cancellationToken);
        Require((await left.JoinMatchQueueAsync(
            tokens[0], replacement.Token, cancellationToken)).Code == "waiting",
            "A new attempt must be usable after terminal acceptance and pair release.");
        await restartBackendAsync();
        Require((await left.CancelMatchQueueAsync(tokens[0], previousAttempt, cancellationToken)).Code == "not-queued",
            "A late old cancellation must leave the replacement attempt alive.");
        var replacementPeer = await right.CreateMatchQueueAttemptAsync(tokens[1], cancellationToken);
        var replacementPair = await right.JoinMatchQueueAsync(tokens[1], replacementPeer.Token, cancellationToken);
        Require(replacementPair.Code == "paired" && replacementPair.MatchId != previousMatchId,
            "A replacement waiting ticket must survive restart and form a distinct pair.");
        Require((await left.CancelMatchQueueAsync(
            tokens[0], previousAttempt, cancellationToken)).Code == "not-queued" &&
            (await left.JoinMatchQueueAsync(
                tokens[0], replacement.Token, cancellationToken)).MatchId == replacementPair.MatchId,
            "An old cancellation after restart must not capture a replacement pair.");
        Require((await left.CancelMatchQueueAsync(tokens[0], replacement.Token, cancellationToken)).Code == "cancelled",
            "The restarted Backend must still accept the owning cancellation and terminal proof.");
    }

    private static async Task VerifyForeignCredentialAsync(
        BackendClient client, string token, string foreignAttempt, CancellationToken cancellationToken)
    {
        try
        {
            await client.JoinMatchQueueAsync(token, foreignAttempt, cancellationToken);
        }
        catch (HttpRequestException failure) when (
            failure.Message.Contains("Backend status 400", StringComparison.Ordinal))
        {
            return;
        }

        throw new Exception("A foreign player's attempt credential admitted a queue request.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed class AttemptCredentials
    {
        internal AttemptCredentials(string cancelledToken, string currentToken)
        {
            CancelledToken = cancelledToken;
            CurrentToken = currentToken;
        }

        internal string CancelledToken { get; }
        internal string CurrentToken { get; }
    }

    internal sealed class Scenario
    {
        internal Scenario(
            BackendClient left,
            BackendClient right,
            string[] accessTokens,
            CancellationToken cancellationToken)
        {
            Left = left;
            Right = right;
            AccessTokens = accessTokens;
            CancellationToken = cancellationToken;
        }

        internal BackendClient Left { get; }
        internal BackendClient Right { get; }
        internal string[] AccessTokens { get; }
        internal CancellationToken CancellationToken { get; }
    }
}
