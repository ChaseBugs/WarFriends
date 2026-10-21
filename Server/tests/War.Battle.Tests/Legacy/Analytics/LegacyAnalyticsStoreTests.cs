using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Persistence;
using War.Persistence.Legacy.Analytics;

namespace War.Battle.Tests.Legacy.Analytics;

/// <summary>Forces lost-update, buffered-writer, session and failure boundaries for shown-once analytics.</summary>
internal static class LegacyAnalyticsStoreTests
{
    private const string Metadata = "{\"future\":{\"exact\":9223372036854775807},\"goldSpent\":5}";

    internal static async Task RunAsync(string uri)
    {
        await using var fixture = new LegacyAnalyticsStoreFixture(uri);
        await fixture.Store.Initialize(fixture.Token);
        await fixture.Buffers.Initialize(fixture.Token);
        await CheckFirstAndRepeatedAsync(fixture);
        await CheckParallelFlagsAsync(fixture);
        await CheckBufferedConflictAsync(fixture);
        await CheckSessionChangesAsync(fixture);
        await CheckDamagedStateAsync(fixture);
        await CheckInvalidSuccessorAsync(fixture);
        await CheckBypassAndUnknownFlagAsync(fixture);
        await CheckFailedWriteAsync(fixture);
        Console.WriteLine("PASS: 8 analytics race/buffer/session/corruption/successor/bypass/fault groups");
    }

    private static async Task CheckFirstAndRepeatedAsync(LegacyAnalyticsStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        int writes = 0;
        fixture.BeforeWrite = () => writes++;
        try
        {
            LegacyPlayerDocument? first = await fixture.Store.MarkAnalyticsShownAsync(
                player, LegacyAnalyticsFlag.Chat, fixture.Time, fixture.Token);
            BsonDocument before = await fixture.ReadAsync(player.Id);
            LegacyPlayerDocument? repeated = await fixture.Store.MarkAnalyticsShownAsync(
                player, LegacyAnalyticsFlag.Chat, fixture.Time, fixture.Token);
            BsonDocument after = await fixture.ReadAsync(player.Id);
            Require(first?.Revision == 2 && repeated?.Revision == 2 && writes == 1 && Same(before, after) &&
                Read(after)["chatShown"]!.GetValue<bool>(),
                "Repeated true flag consumed another revision or lost state.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckParallelFlagsAsync(LegacyAnalyticsStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(new() { [LegacyAnalyticsState.Key] = Metadata });
        using var reads = new Barrier(2);
        int writes = 0;
        fixture.BeforeWrite = () =>
        {
            if (Interlocked.Increment(ref writes) <= 2)
            {
                Require(reads.SignalAndWait(TimeSpan.FromSeconds(10), fixture.Token),
                    "Both analytics reads were not forced before either write.");
            }
        };
        try
        {
            Task<LegacyPlayerDocument?> Start(LegacyAnalyticsFlag flag) => Task.Run(() =>
                fixture.Store.MarkAnalyticsShownAsync(player, flag, fixture.Time, fixture.Token), fixture.Token);
            LegacyPlayerDocument?[] results = await Task.WhenAll(Start(LegacyAnalyticsFlag.Chat),
                Start(LegacyAnalyticsFlag.Crafting));
            BsonDocument saved = await fixture.ReadAsync(player.Id);
            JsonObject state = Read(saved);
            Require(results.All(result => result != null) && writes == 3 && saved["Revision"].AsInt64 == 3 &&
                state["chatShown"]!.GetValue<bool>() && state["craftingShown"]!.GetValue<bool>() &&
                state["future"]!["exact"]!.GetValue<long>() == long.MaxValue &&
                state["goldSpent"]!.GetValue<int>() == 5,
                "Concurrent shown flags overwrote one another or rounded newer metadata.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckBufferedConflictAsync(LegacyAnalyticsStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(new() { [LegacyAnalyticsState.Key] = Metadata });
        int writes = 0;
        fixture.BeforeWrite = () =>
        {
            if (Interlocked.Increment(ref writes) == 1)
            {
                fixture.Buffers.ExecuteAsync(fixture.Request(player.Id), fixture.Plan, fixture.Token)
                    .GetAwaiter().GetResult();
            }
        };
        try
        {
            await fixture.Store.MarkAnalyticsShownAsync(
                player, LegacyAnalyticsFlag.CardPool, fixture.Time, fixture.Token);
            BsonDocument saved = await fixture.ReadAsync(player.Id);
            JsonObject state = Read(saved);
            Require(writes == 2 && saved["Revision"].AsInt64 == 3 &&
                state["cardpoolShown"]!.GetValue<bool>() &&
                state["lastSeenSquadChatTimeStampDB"]!.GetValue<int>() == 123 &&
                state["future"]!["exact"]!.GetValue<long>() == long.MaxValue &&
                await fixture.ReceiptCountAsync(player.Id) == 1,
                "Shown flag replaced an actual committed buffered marker or its receipt.");
        }
        finally
        {
            fixture.BeforeWrite = null;
        }
    }

    private static async Task CheckSessionChangesAsync(LegacyAnalyticsStoreFixture fixture)
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

                BsonValue value = field == "SessionHash"
                    ? new BsonString(LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()))
                    : new BsonDateTime(fixture.Time.UtcDateTime.AddSeconds(-1));
                fixture.Raw.UpdateOne(new BsonDocument("_id", player.Id),
                    Builders<BsonDocument>.Update.Set(field, value).Inc("Revision", 1L));
                changed = fixture.Raw.Find(new BsonDocument("_id", player.Id)).Single();
            };
            try
            {
                LegacyPlayerDocument? result = await fixture.Store.MarkAnalyticsShownAsync(
                    player, LegacyAnalyticsFlag.Elites, fixture.Time, fixture.Token);
                BsonDocument after = await fixture.ReadAsync(player.Id);
                Require(result == null && changed != null && Same(changed, after),
                    "Analytics published after changed session authority: " + field);
            }
            finally
            {
                fixture.BeforeWrite = null;
            }
        }
    }

    private static async Task CheckDamagedStateAsync(LegacyAnalyticsStoreFixture fixture)
    {
        foreach (string? json in new string?[]
        {
            null, "null", "[]", "", "{\"chatShown\":null}", "{\"ChatShown\":true}",
            "{\"chatShown\":true,\"chatShown\":false}", "{\"goldSpent\":\"5\"}",
            "{\"transactions\":[{\"id\":142}]}", "{\"matchesToNextLootboxes\":0}"
        })
        {
            LegacyPlayerDocument player = await fixture.SeedAsync(new() { [LegacyAnalyticsState.Key] = json! });
            BsonDocument before = await fixture.ReadAsync(player.Id);
            await ExpectInvalidAsync(() => fixture.Store.MarkAnalyticsShownAsync(
                player, LegacyAnalyticsFlag.Chat, fixture.Time, fixture.Token));
            await ExpectInvalidAsync(() => fixture.Buffers.ExecuteAsync(
                fixture.Request(player.Id), fixture.Plan, fixture.Token));
            BsonDocument after = await fixture.ReadAsync(player.Id);
            Require(Same(before, after) && await fixture.ReceiptCountAsync(player.Id) == 0,
                "Damaged analytics was repaired, published or consumed a buffered receipt.");
        }
    }

    private static async Task CheckInvalidSuccessorAsync(LegacyAnalyticsStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        BsonDocument before = await fixture.ReadAsync(player.Id);
        await ExpectInvalidAsync(() => fixture.Buffers.ExecuteAsync(fixture.Request(player.Id), current =>
            fixture.Plan(current) with
            {
                Serialized = new Dictionary<string, string> { [LegacyAnalyticsState.Key] = "{\"chatShown\":1}" }
            },
            fixture.Token));
        Require(Same(before, await fixture.ReadAsync(player.Id)) && await fixture.ReceiptCountAsync(player.Id) == 0,
            "Invalid internal analytics successor changed state or consumed its receipt.");
    }

    private static async Task CheckBypassAndUnknownFlagAsync(LegacyAnalyticsStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        BsonDocument before = await fixture.ReadAsync(player.Id);
        Require(typeof(LegacyPlayerStore).GetMethod("SetSerialized") == null,
            "Generic analytics replacement must not be part of the production store API.");
        await ExpectInvalidAsync(() => fixture.Store.MarkAnalyticsShownAsync(
            player, (LegacyAnalyticsFlag)int.MaxValue, fixture.Time, fixture.Token));
        Require(Same(before, await fixture.ReadAsync(player.Id)),
            "Generic/unsupported analytics writer bypassed ownership.");
    }

    private static async Task CheckFailedWriteAsync(LegacyAnalyticsStoreFixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(
            new() { [LegacyAnalyticsState.Key] = "{\"chatShown\":false}" });
        BsonDocument before = await fixture.ReadAsync(player.Id);
        await fixture.Database.RunCommandAsync<BsonDocument>(new BsonDocument
        {
            { "collMod", "legacyPlayers" }, { "validator", new BsonDocument("Revision", 1L) }
        }, cancellationToken: fixture.Token);
        try
        {
            await fixture.Store.MarkAnalyticsShownAsync(player, LegacyAnalyticsFlag.Chat, fixture.Time, fixture.Token);
            throw new InvalidOperationException("Mongo validator did not refuse analytics publication.");
        }
        catch (MongoCommandException exception) when (exception.Code == 121)
        {
            Require(Same(before, await fixture.ReadAsync(player.Id)), "Failed analytics write changed durable state.");
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

        throw new InvalidOperationException("Invalid analytics authority was accepted.");
    }

    private static JsonObject Read(BsonDocument document) =>
        LegacyAnalyticsState.Parse(document["Serialized"][LegacyAnalyticsState.Key].AsString);

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
