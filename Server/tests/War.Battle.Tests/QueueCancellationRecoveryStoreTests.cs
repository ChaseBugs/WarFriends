using MongoDB.Bson;
using MongoDB.Driver;
using War.Infrastructure;
using War.Persistence;

/// <summary>Checks durable cancellation claims, takeover and fail-closed page validation on real MongoDB.</summary>
internal static class QueueCancellationRecoveryStoreTests
{
    internal static async Task RunAsync(string uri)
    {
        string databaseName = "war_cancel_recovery_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        var database = mongo.GetDatabase(databaseName);
        var first = new BattleMatchQueueStore(uri, databaseName);
        var second = new BattleMatchQueueStore(uri, databaseName);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(60));
        try
        {
            await first.Initialize(deadline.Token);
            await second.Initialize(deadline.Token);
            var now = DateTimeOffset.UtcNow;
            await CreatePendingAsync(first, now, deadline.Token);
            await database.GetCollection<BattleQueueAttemptDocument>("battle_queue_attempts")
                .DeleteManyAsync(FilterDefinition<BattleQueueAttemptDocument>.Empty, deadline.Token);
            // Advance logical server time beyond signed admission and receipt retention without sleeping.
            now = now.AddSeconds(700);
            Require((await first.ClaimCancellationsAsync(now, deadline.Token)).Count == 1,
                "A committed pair intent must survive removal of all short-lived attempt receipts.");
            Require((await second.ClaimCancellationsAsync(now, deadline.Token)).Count == 0,
                "Another Backend must not take an unexpired recovery claim.");
            now = now.AddSeconds(BattleMatchQueueStore.CancellationRetrySeconds);
            Require((await second.ClaimCancellationsAsync(now, deadline.Token)).Count == 1,
                "The exact expiry boundary must permit takeover after a Backend stops.");
            var pending = await CreatePendingAsync(first, now, deadline.Token);
            var claims = await Task.WhenAll(first.ClaimCancellationsAsync(now, deadline.Token),
                second.ClaimCancellationsAsync(now, deadline.Token));
            Require(claims.Sum(page => page.Count) == 1 &&
                claims.SelectMany(page => page).Single().MatchId == pending.MatchId,
                "Independent Backend stores must claim one exact pair only once.");
            await VerifyLegacyClaimAsync(first, database, now, deadline.Token);
            await VerifyCorruptPageAsync(first, database, now, deadline.Token);
            Console.WriteLine(
                "PASS: cancellation recovery survives receipt expiry, supports takeover and rejects corrupt pages");
        }
        finally
        {
            await mongo.DropDatabaseAsync(databaseName);
        }
    }

    private static async Task VerifyLegacyClaimAsync(
        BattleMatchQueueStore queue, IMongoDatabase database, DateTimeOffset now, CancellationToken cancellationToken)
    {
        string player = Guid.NewGuid().ToString("N");
        string peer = Guid.NewGuid().ToString("N");
        const string CompatibilityKey = "legacy-recovery.fixture";
        await queue.Join(player, CompatibilityKey, now, cancellationToken);
        var pair = await queue.Join(peer, CompatibilityKey, now, cancellationToken);
        await queue.CancelWithPairAsync(player, now, cancellationToken);
        await database.GetCollection<BsonDocument>("battle_pairs").UpdateOneAsync(
            new BsonDocument("MatchId", pair.MatchId),
            new BsonDocument("$unset", new BsonDocument("AttemptIds", 1)), cancellationToken: cancellationToken);
        var claimed = await queue.ClaimCancellationsAsync(now, cancellationToken);
        Require(claimed.Count == 1 && claimed[0].MatchId == pair.MatchId,
            "Legacy pairs without an attempt array must retain exact cancellation ownership.");
    }

    private static async Task VerifyCorruptPageAsync(
        BattleMatchQueueStore queue, IMongoDatabase database, DateTimeOffset now, CancellationToken cancellationToken)
    {
        var valid = await CreatePendingAsync(queue, now, cancellationToken);
        var damaged = await CreatePendingAsync(queue, now, cancellationToken);
        var rows = database.GetCollection<BattlePairDocument>("battle_pairs");
        var original = await rows.Find(row => row.MatchId == valid.MatchId).SingleAsync(cancellationToken);
        var badRow = await rows.Find(row => row.MatchId == damaged.MatchId).SingleAsync(cancellationToken);
        await rows.UpdateOneAsync(row => row.MatchId == damaged.MatchId,
            Builders<BattlePairDocument>.Update.Set("Cancellation.PlayerId", Guid.NewGuid().ToString("N")),
            cancellationToken: cancellationToken);
        await RejectAsync(() => queue.ClaimCancellationsAsync(now, cancellationToken));
        await VerifyUnclaimedAsync(rows, original, cancellationToken);
        await rows.ReplaceOneAsync(row => row.MatchId == damaged.MatchId, badRow,
            cancellationToken: cancellationToken);
        await rows.UpdateOneAsync(row => row.MatchId == damaged.MatchId,
            Builders<BattlePairDocument>.Update.Set("Cancellation.RetryAfterUtc", now.AddDays(1).UtcDateTime),
            cancellationToken: cancellationToken);
        await RejectAsync(() => queue.ClaimCancellationsAsync(now, cancellationToken));
        await VerifyUnclaimedAsync(rows, original, cancellationToken);
        await database.GetCollection<BsonDocument>("battle_pairs").UpdateOneAsync(
            new BsonDocument("MatchId", damaged.MatchId),
            new BsonDocument("$unset", new BsonDocument("Cancellation.RetryAfterUtc", 1)),
            cancellationToken: cancellationToken);
        await RejectAsync(() => queue.ClaimCancellationsAsync(now, cancellationToken));
        await VerifyUnclaimedAsync(rows, original, cancellationToken);
        await database.GetCollection<BsonDocument>("battle_pairs").UpdateOneAsync(
            new BsonDocument("MatchId", damaged.MatchId),
            new BsonDocument("$set", new BsonDocument("Cancellation", "invalid-intent-shape")),
            cancellationToken: cancellationToken);
        await RejectAsync(() => queue.ClaimCancellationsAsync(now, cancellationToken));
        await VerifyUnclaimedAsync(rows, original, cancellationToken);
    }

    private static async Task VerifyUnclaimedAsync(
        IMongoCollection<BattlePairDocument> rows, BattlePairDocument original, CancellationToken cancellationToken)
    {
        var after = await rows.Find(row => row.Id == original.Id).SingleAsync(cancellationToken);
        Require(after.Cancellation?.RetryAfterUtc == original.Cancellation?.RetryAfterUtc,
            "One malformed candidate must abort the complete page before its first lease write.");
    }

    private static async Task<BattlePairingResult> CreatePendingAsync(
        BattleMatchQueueStore queue, DateTimeOffset now, CancellationToken cancellationToken)
    {
        long issued = now.ToUnixTimeSeconds();
        var first = new BattleQueueAttemptIdentity(Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"),
            issued, issued + BattleQueueAttemptTokens.LifetimeSeconds);
        var second = new BattleQueueAttemptIdentity(Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"),
            issued, issued + BattleQueueAttemptTokens.LifetimeSeconds);
        const string CompatibilityKey = "recovery-claims.fixture";
        await queue.JoinAttemptAsync(first, CompatibilityKey, now, cancellationToken);
        await queue.JoinAttemptAsync(second, CompatibilityKey, now, cancellationToken);
        var pair = await queue.CancelAttemptAsync(first, now, cancellationToken);
        Require(pair.Code == "already-paired", "Recovery setup requires a captured durable cancellation intent.");
        return pair;
    }

    private static async Task RejectAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception failure) when (failure is InvalidDataException or FormatException or BsonException)
        {
            return;
        }

        throw new Exception("Malformed cancellation recovery authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
