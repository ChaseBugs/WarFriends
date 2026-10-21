using MongoDB.Bson;
using MongoDB.Driver;
using War.Persistence;
using War.Persistence.Legacy.Profile;

namespace War.Battle.Tests.Legacy.Profile;

/// <summary>Forces profile/rename conflicts and refused writes without new processes or password derivation.</summary>
internal static class LegacyProfileStoreTests
{
    internal static async Task RunAsync(string uri)
    {
        await using var fixture = new LegacyProfileStoreFixture(uri);
        await fixture.Store.Initialize(fixture.Token);
        await CheckReplacementsAsync(fixture);
        await CheckParallelFieldsAsync(fixture);
        await CheckMetadataConflictAsync(fixture);
        await CheckRevocationAsync(fixture);
        await CheckRenameRaceAsync(fixture, 0, 100);
        await CheckRenameRaceAsync(fixture, 1, 25);
        await CheckRenameRefusalsAsync(fixture);
        await CheckRenameRevocationAsync(fixture);
        await CheckDamagedProfilesAsync(fixture);
        await CheckFailedWritesAsync(fixture);
        Console.WriteLine("PASS: 10 profile tuple/race/metadata/session/rename/refusal/corruption/fault groups");
    }

    private static async Task CheckReplacementsAsync(LegacyProfileStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        LegacyProfileChange[] changes =
        [
            LegacyProfileChange.ForDeviceRegistration(" padded token ", "ko-KR"),
            LegacyProfileChange.ForLanguage("fr"), LegacyProfileChange.ForCountry("gb"),
            LegacyProfileChange.ForStatus(2)
        ];
        foreach (LegacyProfileChange change in changes)
        {
            Require(await fixture.Store.ApplyProfileAsync(player, change, fixture.Time, fixture.Token) != null,
                "Valid profile replacement failed to rebase against the current same-session revision.");
        }

        BsonDocument saved = await fixture.ReadAsync(player.Id);
        Require(saved["Revision"].AsInt64 == 5 && saved["Locale"] == "fr" && saved["Country"] == "GB" &&
            saved["DeviceToken"] == " padded token " && saved["Status"].AsInt32 == 2 &&
            saved["LastAction"].AsInt32 == fixture.Time.ToUnixTimeSeconds() &&
            saved["Serialized"]["PlayerAnalyticsData"] == player.Serialized["PlayerAnalyticsData"],
            "Profile tuple, exact token, current revision or unrelated Int64 metadata was lost.");
    }

    private static async Task CheckParallelFieldsAsync(LegacyProfileStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        using var reads = new Barrier(2);
        int writes = 0;
        fixture.BeforeWrite = () =>
        {
            if (Interlocked.Increment(ref writes) <= 2)
            {
                Require(reads.SignalAndWait(TimeSpan.FromSeconds(10), fixture.Token),
                    "Both profile reads were not forced before either write.");
            }
        };
        try
        {
            Task<LegacyPlayerDocument?> Start(LegacyProfileChange change) => Task.Run(() =>
                fixture.Store.ApplyProfileAsync(player, change, fixture.Time, fixture.Token), fixture.Token);
            LegacyPlayerDocument?[] results = await Task.WhenAll(Start(LegacyProfileChange.ForLanguage("ko")),
                Start(LegacyProfileChange.ForCountry("gb")));
            BsonDocument saved = await fixture.ReadAsync(player.Id);
            Require(results.All(result => result != null) && writes == 3 && saved["Revision"].AsInt64 == 3 &&
                saved["Locale"] == "ko" && saved["Country"] == "GB",
                "Concurrent independent profile replacements lost one committed field.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckMetadataConflictAsync(LegacyProfileStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        int writes = 0;
        const string newer = "{\"future\":9223372036854775806,\"counter\":2}";
        fixture.BeforeWrite = () =>
        {
            if (Interlocked.Increment(ref writes) == 1)
            {
                fixture.Change(player.Id, Builders<BsonDocument>.Update.Inc("Revision", 1L)
                    .Set("Serialized.PlayerAnalyticsData", newer)
                    .Set("LastAction", (int)fixture.Time.ToUnixTimeSeconds() + 1));
            }
        };
        try
        {
            await fixture.Store.ApplyProfileAsync(
                player, LegacyProfileChange.ForStatus(1), fixture.Time, fixture.Token);
            BsonDocument saved = await fixture.ReadAsync(player.Id);
            Require(writes == 2 && saved["Revision"].AsInt64 == 3 &&
                saved["Serialized"]["PlayerAnalyticsData"] == newer &&
                saved["LastAction"].AsInt32 == fixture.Time.ToUnixTimeSeconds() + 1,
                "Rebased heartbeat overwrote newer metadata or regressed presence.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckRevocationAsync(LegacyProfileStoreFixture fixture)
    {
        foreach (string field in new[] { "SessionHash", "SessionExpiresUtc" })
        {
            LegacyPlayerDocument player = await fixture.SeedAsync();
            BsonDocument? changed = null;
            fixture.BeforeWrite = () =>
            {
                if (changed != null)
                {
                    return;
                }

                BsonValue replacement = field == "SessionHash"
                    ? new BsonString(LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()))
                    : new BsonDateTime(fixture.Time.UtcDateTime.AddSeconds(-1));
                fixture.Change(player.Id, Builders<BsonDocument>.Update.Inc("Revision", 1L).Set(field, replacement));
                changed = fixture.Raw.Find(new BsonDocument("_id", player.Id)).Single(fixture.Token);
            };
            try
            {
                LegacyPlayerDocument? result = await fixture.Store.ApplyProfileAsync(player,
                    LegacyProfileChange.ForCountry("gb"), fixture.Time, fixture.Token);
                BsonDocument after = await fixture.ReadAsync(player.Id);
                Require(result == null && changed != null && Same(changed, after),
                    "Profile publication survived revoked/expired session authority: " + field);
            }
            finally
            {
                fixture.BeforeWrite = null;
            }
        }
    }

    private static async Task CheckRenameRaceAsync(LegacyProfileStoreFixture fixture, int count, long gold)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(count, gold);
        using var reads = new Barrier(2);
        int writes = 0;
        fixture.BeforeWrite = () =>
        {
            if (Interlocked.Increment(ref writes) <= 2)
            {
                Require(reads.SignalAndWait(TimeSpan.FromSeconds(10), fixture.Token), "Rename race was not forced.");
            }
        };
        try
        {
            Task<LegacyRenameResult> Start(string name) => Task.Run(() => fixture.Store.RenamePlayerAsync(
                player, new LegacyRenameRequest(name, count > 0), new LegacyRenamePolicy(25), fixture.Token),
                fixture.Token);
            LegacyRenameResult[] results = await Task.WhenAll(Start("Alpha"), Start("Bravo"));
            LegacyRenameResult winner = results.Single(result => result.Outcome == LegacyRenameOutcome.Published);
            BsonDocument saved = await fixture.ReadAsync(player.Id);
            Require(writes == 2 && results.Count(result => result.Outcome == LegacyRenameOutcome.StaleRevision) == 1 &&
                saved["RenameCount"].AsInt32 == count + 1 && saved["Revision"].AsInt64 == 2 &&
                saved["Gold"].AsInt64 == gold - winner.Price && saved["Name"] == winner.Player!.Name,
                "Concurrent renames published more than one count/debit or returned an uncommitted name.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckRenameRefusalsAsync(LegacyProfileStoreFixture fixture)
    {
        var cases = new[]
        {
            (Count: 1, Gold: 100L, Pay: true, Cost: (int?)null, Result: LegacyRenameOutcome.MissingPrice),
            (Count: 1, Gold: 100L, Pay: false, Cost: (int?)25, Result: LegacyRenameOutcome.PaymentRequired),
            (Count: 1, Gold: 24L, Pay: true, Cost: (int?)25, Result: LegacyRenameOutcome.NotEnoughGold),
            (Count: 28, Gold: long.MaxValue, Pay: true, Cost: (int?)25, Result: LegacyRenameOutcome.InvalidPrice)
        };
        foreach (var scenario in cases)
        {
            LegacyPlayerDocument player = await fixture.SeedAsync(scenario.Count, scenario.Gold);
            BsonDocument before = await fixture.ReadAsync(player.Id);
            LegacyRenameResult result = await fixture.Store.RenamePlayerAsync(player,
                new LegacyRenameRequest("After", scenario.Pay), new LegacyRenamePolicy(scenario.Cost), fixture.Token);
            Require(result.Outcome == scenario.Result && Same(before, await fixture.ReadAsync(player.Id)),
                "Refused rename changed count/balance/name: " + scenario.Result);
        }
    }

    private static async Task CheckRenameRevocationAsync(LegacyProfileStoreFixture fixture)
    {
        foreach (string field in new[] { "SessionHash", "SessionExpiresUtc" })
        {
            LegacyPlayerDocument player = await fixture.SeedAsync(1, 25);
            BsonDocument? changed = null;
            fixture.BeforeWrite = () =>
            {
                if (changed != null)
                {
                    return;
                }

                BsonValue replacement = field == "SessionHash"
                    ? new BsonString(LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()))
                    : new BsonDateTime(DateTime.UtcNow.AddSeconds(-1));
                fixture.Change(player.Id, Builders<BsonDocument>.Update.Inc("Revision", 1L).Set(field, replacement));
                changed = fixture.Raw.Find(new BsonDocument("_id", player.Id)).Single(fixture.Token);
            };
            try
            {
                LegacyRenameResult result = await fixture.Store.RenamePlayerAsync(player,
                    new LegacyRenameRequest("After", true), new LegacyRenamePolicy(25), fixture.Token);
                BsonDocument after = await fixture.ReadAsync(player.Id);
                Require(result.Outcome == LegacyRenameOutcome.InvalidSession && changed != null && Same(changed, after),
                    "Rename charged or changed name after session authority changed: " + field);
            }
            finally
            {
                fixture.BeforeWrite = null;
            }
        }
    }

    private static async Task CheckDamagedProfilesAsync(LegacyProfileStoreFixture fixture)
    {
        (string Field, BsonValue Value)[] cases =
        [
            ("Name", BsonNull.Value), ("Locale", "???"), ("Country", "GBR"), ("DeviceToken", "bad\n"),
            ("Serialized.Settings", "{}"), ("Serialized.Settings", BsonNull.Value)
        ];
        foreach (var damage in cases)
        {
            LegacyPlayerDocument player = await fixture.SeedAsync();
            fixture.Change(player.Id, Builders<BsonDocument>.Update.Set(damage.Field, damage.Value));
            BsonDocument before = await fixture.ReadAsync(player.Id);
            await ExpectInvalidAsync(() => fixture.Store.ApplyProfileAsync(player,
                LegacyProfileChange.ForLanguage("ko"), fixture.Time, fixture.Token));
            await ExpectInvalidAsync(() => fixture.Store.RenamePlayerAsync(player,
                new LegacyRenameRequest("After", false), new LegacyRenamePolicy(25), fixture.Token));
            Require(Same(before, await fixture.ReadAsync(player.Id)),
                "Profile update repaired/replaced damaged authority without a migration: " + damage.Field);
        }
    }

    private static async Task ExpectInvalidAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Damaged profile authority was accepted.");
    }

    private static async Task CheckFailedWritesAsync(LegacyProfileStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        BsonDocument before = await fixture.ReadAsync(player.Id);
        await fixture.Database.RunCommandAsync<BsonDocument>(new BsonDocument
        {
            { "collMod", "legacyPlayers" }, { "validator", new BsonDocument("Revision", 1L) }
        }, cancellationToken: fixture.Token);
        await ExpectWriteFailureAsync(() => fixture.Store.ApplyProfileAsync(player,
            LegacyProfileChange.ForLanguage("ko"), fixture.Time, fixture.Token));
        await ExpectWriteFailureAsync(() => fixture.Store.RenamePlayerAsync(player,
            new LegacyRenameRequest("After", false), new LegacyRenamePolicy(25), fixture.Token));
        Require(Same(before, await fixture.ReadAsync(player.Id)),
            "Failed profile/rename write changed durable authority.");
    }

    private static async Task ExpectWriteFailureAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (MongoCommandException exception) when (exception.Code == 121)
        {
            return;
        }

        throw new InvalidOperationException("Mongo validator did not reject the profile write.");
    }

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
