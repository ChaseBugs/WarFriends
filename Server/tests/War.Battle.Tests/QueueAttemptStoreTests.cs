using MongoDB.Driver;
using War.Infrastructure;
using War.Persistence;

/// <summary>Exercises attempt fencing against independent stores on a real Mongo replica set.</summary>
internal static class QueueAttemptStoreTests
{
    internal static async Task RunAsync(string uri)
    {
        string database = "war_queue_attempt_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        var queue = new BattleMatchQueueStore(uri, database);
        var other = new BattleMatchQueueStore(uri, database);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(60));
        try
        {
            await queue.Initialize(deadline.Token);
            await other.Initialize(deadline.Token);
            await VerifyEarlyAndStaleCancellationAsync(queue, other, deadline.Token);
            await VerifyConcurrentPairingAsync(queue, other, deadline.Token);
            await VerifyTicketReplacementAsync(queue, deadline.Token);
            await VerifyExpiredAndCorruptReceiptsAsync(queue, mongo.GetDatabase(database), deadline.Token);
            Console.WriteLine(
                "PASS: scoped queue cancellation, stale requests, concurrent stores, expiry and corruption");
        }
        finally
        {
            await mongo.DropDatabaseAsync(database);
        }
    }

    private static async Task VerifyEarlyAndStaleCancellationAsync(
        BattleMatchQueueStore queue, BattleMatchQueueStore other, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var old = CreateAttempt(Guid.NewGuid().ToString("N"), now);
        Require((await queue.CancelAttemptAsync(old, now, cancellationToken)).Code == "not-queued",
            "Cancellation before join must be acknowledged without a ticket.");
        Require((await other.JoinAttemptAsync(old, "early.fixture", now, cancellationToken)).Code == "cancelled",
            "A delayed first join must not recreate a cancelled attempt.");
        var current = CreateAttempt(old.PlayerId, now);
        Require((await queue.JoinAttemptAsync(current, "early.fixture", now, cancellationToken)).Code == "waiting",
            "A different attempt can enter after acknowledged cancellation.");
        Require((await other.CancelAttemptAsync(old, now, cancellationToken)).Code == "not-queued",
            "An old cancellation must leave the new waiting ticket untouched.");
        var peer = CreateAttempt(Guid.NewGuid().ToString("N"), now);
        var paired = await other.JoinAttemptAsync(peer, "early.fixture", now, cancellationToken);
        Require(paired.Code == "paired", "The surviving new ticket must still pair.");
        Require((await queue.CancelAttemptAsync(old, now, cancellationToken)).Code == "not-queued" &&
            (await queue.Existing(current.PlayerId, cancellationToken))?.MatchId == paired.MatchId,
            "An old cancellation must not capture a newer pair.");
        Require((await queue.CancelWithPairAsync(current.PlayerId, now, cancellationToken)).Code == "attempt-conflict",
            "Unscoped cancellation must not select a scoped pair.");
        await RejectAsync(() => queue.ExistingUnscoped(current.PlayerId, cancellationToken));
        var captured = await queue.CancelAttemptAsync(current, now, cancellationToken);
        Require(captured.Code == "already-paired" && captured.MatchId == paired.MatchId &&
            captured.Players!.SequenceEqual(paired.Players!), "Scoped cancellation captures its exact ordered pair.");
        await queue.Release(paired.MatchId!, paired.Players!, cancellationToken);
        Require((await other.JoinAttemptAsync(current, "early.fixture", now, cancellationToken)).Code == "cancelled",
            "Released cancellation must not reopen through a delayed same-attempt join.");
    }

    private static async Task VerifyConcurrentPairingAsync(
        BattleMatchQueueStore queue, BattleMatchQueueStore other, CancellationToken cancellationToken)
    {
        const int RaceCount = 32;
        for (int race = 0; race < RaceCount; race++)
        {
            var now = DateTimeOffset.UtcNow;
            var first = CreateAttempt(Guid.NewGuid().ToString("N"), now);
            var second = CreateAttempt(Guid.NewGuid().ToString("N"), now);
            string key = "attempt-race." + race;
            await queue.JoinAttemptAsync(first, key, now, cancellationToken);
            var pairing = other.JoinAttemptAsync(second, key, now, cancellationToken);
            var cancellation = queue.CancelAttemptAsync(first, now, cancellationToken);
            await Task.WhenAll(pairing, cancellation);
            var retained = await other.Existing(first.PlayerId, cancellationToken);
            Require(cancellation.Result.Code == "cancelled" && retained == null ||
                cancellation.Result.Code == "already-paired" && retained != null &&
                retained.MatchId == pairing.Result.MatchId &&
                cancellation.Result.MatchId == retained.MatchId,
                "Concurrent cancellation and pairing must commit one exact ownership outcome.");
            Require((await other.JoinAttemptAsync(first, key, now, cancellationToken)).Code == "cancelled",
                "Cancellation or captured cancellation intent must fence repeated admission.");
        }
    }

    private static async Task VerifyTicketReplacementAsync(
        BattleMatchQueueStore queue, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var old = CreateAttempt(Guid.NewGuid().ToString("N"), now);
        await queue.JoinAttemptAsync(old, "replace-attempt.fixture", now, cancellationToken);
        var later = now.AddSeconds(121);
        var replacement = CreateAttempt(old.PlayerId, later);
        Require((await queue.JoinAttemptAsync(
            replacement, "replace-attempt.fixture", later, cancellationToken)).Code == "waiting",
            "An expired waiting ticket may be replaced by a fresh attempt.");
        Require((await queue.JoinAttemptAsync(
            old, "replace-attempt.fixture", later, cancellationToken)).Code == "cancelled",
            "Replacing a ticket must close the old still-unexpired admission credential.");
        Require((await queue.CancelWithPairAsync(old.PlayerId, later, cancellationToken)).Code == "attempt-conflict",
            "Unscoped cancellation must not delete a scoped waiting ticket.");
    }

    private static async Task VerifyExpiredAndCorruptReceiptsAsync(
        BattleMatchQueueStore queue, IMongoDatabase database, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var first = CreateAttempt(Guid.NewGuid().ToString("N"), now);
        var second = CreateAttempt(Guid.NewGuid().ToString("N"), now);
        await queue.JoinAttemptAsync(first, "expiry-attempt.fixture", now, cancellationToken);
        var pair = await queue.JoinAttemptAsync(second, "expiry-attempt.fixture", now, cancellationToken);
        var expired = DateTimeOffset.FromUnixTimeSeconds(first.ExpiresUnixSeconds);
        await RejectAsync(() => queue.JoinAttemptAsync(first, "expiry-attempt.fixture", expired, cancellationToken));
        var receipts = database.GetCollection<BattleQueueAttemptDocument>("battle_queue_attempts");
        await receipts.DeleteOneAsync(row => row.PlayerId == first.PlayerId, cancellationToken);
        var captured = await queue.CancelAttemptAsync(first, expired, cancellationToken);
        Require(captured.MatchId == pair.MatchId && captured.Code == "already-paired",
            "After receipt pruning an expired token may still identify only its original pair.");
        Require(await receipts.CountDocumentsAsync(row => row.PlayerId == first.PlayerId,
            cancellationToken: cancellationToken) == 0,
            "Expired cancellation must not recreate a pruned receipt.");
        var damaged = CreateAttempt(Guid.NewGuid().ToString("N"), now);
        await queue.JoinAttemptAsync(damaged, "corrupt-attempt.fixture", now, cancellationToken);
        await receipts.UpdateOneAsync(row => row.PlayerId == damaged.PlayerId,
            Builders<BattleQueueAttemptDocument>.Update.Set(row => row.Revision, 0),
            cancellationToken: cancellationToken);
        await RejectAsync(() => queue.JoinAttemptAsync(damaged, "corrupt-attempt.fixture", now, cancellationToken));
        await RejectAsync(() => queue.CancelAttemptAsync(damaged, now, cancellationToken));
    }

    private static BattleQueueAttemptIdentity CreateAttempt(string playerId, DateTimeOffset now)
    {
        long issued = now.ToUnixTimeSeconds();
        return new BattleQueueAttemptIdentity(playerId, Guid.NewGuid().ToString("N"), issued,
            issued + BattleQueueAttemptTokens.LifetimeSeconds);
    }

    private static async Task RejectAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new Exception("Invalid or foreign queue attempt authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
