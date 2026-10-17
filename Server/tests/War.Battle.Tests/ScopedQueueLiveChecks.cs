using War.Client;

/// <summary>Checks attempt ownership through real authenticated protobuf and Worker control routes.</summary>
internal static class ScopedQueueLiveChecks
{
    internal static async Task RunAsync(
        BackendClient left, BackendClient right, string[] tokens, CancellationToken cancellationToken)
    {
        var cancelled = await left.CreateMatchQueueAttemptAsync(tokens[0], cancellationToken);
        Require((await left.CancelMatchQueueAsync(tokens[0], cancelled.Token, cancellationToken)).Code == "not-queued",
            "An early HTTP cancellation must persist its own scope.");
        Require((await left.JoinMatchQueueAsync(tokens[0], cancelled.Token, cancellationToken)).Code == "cancelled",
            "A delayed HTTP join must not reopen a cancelled attempt.");
        var current = await left.CreateMatchQueueAttemptAsync(tokens[0], cancellationToken);
        Require((await left.JoinMatchQueueAsync(
            tokens[0], current.Token, cancellationToken)).Code == "waiting",
            "A fresh scoped attempt must enter the queue.");
        Require((await left.CancelMatchQueueAsync(
            tokens[0], cancelled.Token, cancellationToken)).Code == "not-queued" &&
            (await left.CancelMatchQueueAsync(
                tokens[0], cancellationToken)).Code == "attempt-conflict",
            "Old and unscoped cancellations must preserve the current waiting attempt.");
        Require((await right.JoinMatchQueueAsync(tokens[1], cancellationToken)).Code == "waiting",
            "An unscoped caller must not consume a scoped candidate.");
        await right.CancelMatchQueueAsync(tokens[1], cancellationToken);
        await VerifyForeignCredentialAsync(right, tokens[1], current.Token, cancellationToken);
        var peer = await right.CreateMatchQueueAttemptAsync(tokens[1], cancellationToken);
        var paired = await right.JoinMatchQueueAsync(tokens[1], peer.Token, cancellationToken);
        var replay = await left.FindMatchAsync(
            tokens[0], current.Token, TimeSpan.FromSeconds(5), cancellationToken);
        Require(paired.Code == "paired" && replay.MatchId == paired.MatchId,
            "Both scoped participants must recover the same frozen pair.");
        Require((await left.CancelMatchQueueAsync(
            tokens[0], cancelled.Token, cancellationToken)).Code == "not-queued" &&
            (await left.CancelMatchQueueAsync(
                tokens[0], cancellationToken)).Code == "attempt-conflict",
            "Old and unscoped cancellation must not capture the new pair.");
        Require((await left.CancelMatchQueueAsync(tokens[0], current.Token, cancellationToken)).Code == "cancelled",
            "The owning scoped request must cancel the registered prestart Worker match.");
        Require((await left.JoinMatchQueueAsync(tokens[0], current.Token, cancellationToken)).Code == "cancelled",
            "A completed scoped cancellation must fence late HTTP admission.");
        var replacement = await left.CreateMatchQueueAttemptAsync(tokens[0], cancellationToken);
        Require((await left.JoinMatchQueueAsync(
            tokens[0], replacement.Token, cancellationToken)).Code == "waiting",
            "A new attempt must be usable after terminal acceptance and pair release.");
        Require((await left.CancelMatchQueueAsync(tokens[0], current.Token, cancellationToken)).Code == "not-queued",
            "A late old cancellation must leave the replacement attempt alive.");
        Console.WriteLine(
            "PASS: authenticated scoped queue, foreign-token refusal and stale HTTP cancellation fencing");
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
}
