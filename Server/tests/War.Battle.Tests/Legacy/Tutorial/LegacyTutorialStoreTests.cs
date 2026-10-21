using MongoDB.Bson;
using MongoDB.Driver;
using War.Persistence;
using War.Persistence.Legacy.Tutorial;

namespace War.Battle.Tests.Legacy.Tutorial;

/// <summary>
/// Forces tutorial identity, duplicate, stale-state, session, legacy migration and refused-write cases.
/// </summary>
internal static class LegacyTutorialStoreTests
{
    private static readonly string BattleA = new('a', 32);
    private static readonly string BattleB = new('b', 32);

    internal static async Task RunAsync(string uri)
    {
        await using var fixture = new LegacyTutorialStoreFixture(uri);
        await fixture.Store.Initialize(fixture.Token);
        await CheckLifecycleAsync(fixture);
        await CheckParallelStartsAsync(fixture);
        await CheckParallelEndsAsync(fixture);
        await CheckOldEndAgainstNewStartAsync(fixture);
        await CheckSessionChangesAsync(fixture);
        await CheckLegacyMigrationAsync(fixture);
        await CheckDamagedStateAsync(fixture);
        await CheckFailedWritesAsync(fixture);
        Console.WriteLine("PASS: 8 tutorial identity/race/replay/session/migration/corruption/fault groups");
    }

    private static async Task CheckLifecycleAsync(LegacyTutorialStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        LegacyTutorialResult start = await fixture.ApplyAsync(player, LegacyTutorialOperation.Start());
        LegacyTutorialResult startAgain = await fixture.ApplyAsync(player, LegacyTutorialOperation.Start());
        Require(start.Outcome == LegacyTutorialOutcome.Published && start.Player!.Revision == 2 &&
            startAgain.Outcome == LegacyTutorialOutcome.Replayed && start.BattleId == startAgain.BattleId &&
            startAgain.Player!.Revision == 2, "Duplicate tutorial start replaced an active identity.");
        LegacyTutorialResult end = await fixture.ApplyAsync(player, LegacyTutorialOperation.End(start.BattleId));
        BsonDocument before = await fixture.ReadAsync(player.Id);
        LegacyTutorialResult replay = await fixture.ApplyAsync(player, LegacyTutorialOperation.End(start.BattleId));
        Require(end.Outcome == LegacyTutorialOutcome.Published && replay.Outcome == LegacyTutorialOutcome.Replayed &&
            replay.Player!.Revision == 3 && replay.Player.TutorialCompleted &&
            replay.Player.PendingTutorialBattleId == null && Same(before, await fixture.ReadAsync(player.Id)) &&
            replay.Player.Gold == 100 &&
            replay.Player.Serialized["PlayerAnalyticsData"] == player.Serialized["PlayerAnalyticsData"],
            "Tutorial end/replay changed wallets, metadata, identity or revision more than once.");
        Require((await fixture.ApplyAsync(player, LegacyTutorialOperation.End(BattleB))).Outcome ==
            LegacyTutorialOutcome.WrongBattle, "Unrelated completed battle ID was accepted as a replay.");
        fixture.Change(player.Id, Builders<BsonDocument>.Update.Set("LevelExperience", 99).Inc("Revision", 1L));
        replay = await fixture.ApplyAsync(player, LegacyTutorialOperation.End(start.BattleId));
        Require(replay.Player!.LevelExperience == 99,
            "Delayed tutorial acknowledgement rolled back newer progression.");
    }

    private static async Task CheckParallelStartsAsync(LegacyTutorialStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        LegacyTutorialResult[] results = await RaceAsync(fixture, player, LegacyTutorialOperation.Start());
        Require(results.Select(result => result.BattleId).Distinct().Count() == 1 &&
            results.Count(result => result.Outcome == LegacyTutorialOutcome.Published) == 1 &&
            results.Count(result => result.Outcome == LegacyTutorialOutcome.Replayed) == 1 &&
            (await fixture.ReadAsync(player.Id))["Revision"].AsInt64 == 2,
            "Concurrent starts minted/replaced more than one tutorial identity.");
    }

    private static async Task CheckParallelEndsAsync(LegacyTutorialStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(Pending(BattleA));
        LegacyTutorialResult[] results = await RaceAsync(fixture, player, LegacyTutorialOperation.End(BattleA));
        BsonDocument saved = await fixture.ReadAsync(player.Id);
        Require(results.Count(result => result.Outcome == LegacyTutorialOutcome.Published) == 1 &&
            results.Count(result => result.Outcome == LegacyTutorialOutcome.Replayed) == 1 &&
            saved["Revision"].AsInt64 == 2 && saved["TutorialCompleted"].AsBoolean,
            "Concurrent ends published completion more than once.");
    }

    private static async Task<LegacyTutorialResult[]> RaceAsync(
        LegacyTutorialStoreFixture fixture, LegacyPlayerDocument player, LegacyTutorialOperation operation)
    {
        using var reads = new Barrier(2);
        int writes = 0;
        fixture.BeforeWrite = () =>
        {
            if (Interlocked.Increment(ref writes) <= 2)
            {
                Require(reads.SignalAndWait(TimeSpan.FromSeconds(10), fixture.Token),
                    "Both tutorial reads were not forced before either write.");
            }
        };
        try
        {
            Task<LegacyTutorialResult> Start() => Task.Run(() => fixture.ApplyAsync(player, operation), fixture.Token);
            LegacyTutorialResult[] results = await Task.WhenAll(Start(), Start());
            Require(writes == 2, "A duplicate tutorial unexpectedly consumed another write after its conflict.");
            return results;
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckOldEndAgainstNewStartAsync(LegacyTutorialStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(Pending(BattleA));
        BsonDocument? replacement = null;
        fixture.BeforeWrite = () =>
        {
            if (replacement != null)
            {
                return;
            }

            fixture.Change(player.Id, Builders<BsonDocument>.Update.Set("PendingTutorialBattleId", BattleB)
                .Set("TutorialState", new LegacyTutorialState { BattleId = BattleB }.ToBsonDocument())
                .Inc("Revision", 1L));
            replacement = fixture.Raw.Find(new BsonDocument("_id", player.Id)).Single();
        };
        try
        {
            LegacyTutorialResult result = await fixture.ApplyAsync(player, LegacyTutorialOperation.End(BattleA));
            BsonDocument after = await fixture.ReadAsync(player.Id);
            Require(result.Outcome == LegacyTutorialOutcome.WrongBattle &&
                replacement != null && Same(replacement, after),
                "Old battle A completed or cleared newly published battle B.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckSessionChangesAsync(LegacyTutorialStoreFixture fixture)
    {
        LegacyTutorialOperation[] operations = [LegacyTutorialOperation.Start(), LegacyTutorialOperation.End(BattleA)];
        foreach (LegacyTutorialOperation operation in operations)
        {
            await CheckSessionChangeAsync(fixture, operation, "SessionHash");
            await CheckSessionChangeAsync(fixture, operation, "SessionExpiresUtc");
        }
    }

    private static async Task CheckSessionChangeAsync(
        LegacyTutorialStoreFixture fixture, LegacyTutorialOperation operation, string field)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(new() { PendingTutorialBattleId = BattleA });
        // A legacy pending row requires publication for both start migration and end.
        BsonDocument? changed = null;
        fixture.BeforeWrite = () =>
        {
            if (changed != null)
            {
                return;
            }

            BsonValue value = field == "SessionHash"
                ? new BsonString(LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()))
                : new BsonDateTime(fixture.Time.UtcDateTime.AddSeconds(-1));
            fixture.Change(player.Id, Builders<BsonDocument>.Update.Set(field, value).Inc("Revision", 1L));
            changed = fixture.Raw.Find(new BsonDocument("_id", player.Id)).Single();
        };
        try
        {
            LegacyTutorialResult result = await fixture.ApplyAsync(player, operation);
            BsonDocument after = await fixture.ReadAsync(player.Id);
            Require(result.Outcome == LegacyTutorialOutcome.InvalidSession && changed != null && Same(changed, after),
                "Tutorial publication survived a revoked/expired session.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckLegacyMigrationAsync(LegacyTutorialStoreFixture fixture)
    {
        LegacyPlayerDocument pending = await fixture.SeedAsync(new() { PendingTutorialBattleId = BattleA });
        LegacyTutorialResult start = await fixture.ApplyAsync(pending, LegacyTutorialOperation.Start());
        Require(start.Outcome == LegacyTutorialOutcome.Published && start.BattleId == BattleA &&
            start.Player!.TutorialState?.Version == 1, "Legacy pending migration invented a replacement battle ID.");
        LegacyPlayerDocument direct = await fixture.SeedAsync(new() { PendingTutorialBattleId = BattleB });
        LegacyTutorialResult end = await fixture.ApplyAsync(direct, LegacyTutorialOperation.End(BattleB));
        Require(end.Player!.TutorialState?.Completed == true && end.BattleId == BattleB,
            "Source-backed legacy pending end did not retain its bound identity.");
        LegacyPlayerDocument unbound = await fixture.SeedAsync(new() { TutorialCompleted = true });
        BsonDocument before = await fixture.ReadAsync(unbound.Id);
        LegacyTutorialResult blockedStart = await fixture.ApplyAsync(unbound, LegacyTutorialOperation.Start());
        LegacyTutorialResult blockedEnd = await fixture.ApplyAsync(unbound, LegacyTutorialOperation.End(BattleA));
        Require(blockedStart.Outcome == LegacyTutorialOutcome.LegacyProofRequired &&
            blockedEnd.Outcome == LegacyTutorialOutcome.LegacyProofRequired &&
            Same(before, await fixture.ReadAsync(unbound.Id)),
            "Unbound old completion was blessed from a new request.");
    }

    private static async Task CheckDamagedStateAsync(LegacyTutorialStoreFixture fixture)
    {
        (string Field, BsonValue Value)[] cases =
        [
            ("TutorialCompleted", 1), ("TutorialCompleted", BsonNull.Value), ("PendingTutorialBattleId", "bad"),
            ("TutorialState", BsonNull.Value), ("TutorialState", new BsonDocument()),
            ("TutorialState", new BsonDocument { { "Version", 1 }, { "BattleId", BattleA }, { "Completed", true } })
        ];
        foreach (var damage in cases)
        {
            LegacyPlayerDocument player = await fixture.SeedAsync();
            fixture.Change(player.Id, Builders<BsonDocument>.Update.Set(damage.Field, damage.Value));
            BsonDocument before = await fixture.ReadAsync(player.Id);
            try
            {
                await fixture.ApplyAsync(player, LegacyTutorialOperation.Start());
                throw new InvalidOperationException("Damaged tutorial state was accepted.");
            }
            catch (Exception exception) when (exception is InvalidDataException or FormatException)
            {
                Require(Same(before, await fixture.ReadAsync(player.Id)), "Damaged tutorial was silently repaired.");
            }
        }
    }

    private static async Task CheckFailedWritesAsync(LegacyTutorialStoreFixture fixture)
    {
        LegacyPlayerDocument fresh = await fixture.SeedAsync();
        LegacyPlayerDocument pending = await fixture.SeedAsync(Pending(BattleA));
        await fixture.Database.RunCommandAsync<BsonDocument>(new BsonDocument
        {
            { "collMod", "legacyPlayers" }, { "validator", new BsonDocument("Revision", 1L) }
        }, cancellationToken: fixture.Token);
        await ExpectWriteFailureAsync(fixture, fresh, LegacyTutorialOperation.Start());
        await ExpectWriteFailureAsync(fixture, pending, LegacyTutorialOperation.End(BattleA));
    }

    private static async Task ExpectWriteFailureAsync(
        LegacyTutorialStoreFixture fixture, LegacyPlayerDocument player, LegacyTutorialOperation operation)
    {
        BsonDocument before = await fixture.ReadAsync(player.Id);
        try
        {
            await fixture.ApplyAsync(player, operation);
            throw new InvalidOperationException("Mongo validator did not refuse tutorial publication.");
        }
        catch (MongoCommandException exception) when (exception.Code == 121)
        {
            Require(Same(before, await fixture.ReadAsync(player.Id)),
                "Failed tutorial write changed state or mirrors.");
        }
    }

    private static LegacyPlayerDocument Pending(string id) => new()
    {
        PendingTutorialBattleId = id, TutorialState = new() { BattleId = id }
    };

    private static bool Same(BsonDocument before, BsonDocument after) =>
        before.ToBson().AsSpan().SequenceEqual(after.ToBson());

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
