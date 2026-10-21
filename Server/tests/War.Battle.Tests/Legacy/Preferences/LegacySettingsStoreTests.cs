using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using War.Battle.Tests.Support;
using War.Persistence;
using War.Persistence.Legacy.Preferences;

namespace War.Battle.Tests.Legacy.Preferences;

/// <summary>Forces current-revision publication, metadata/session conflicts and failed Settings writes.</summary>
internal static class LegacySettingsStoreTests
{
    internal const string AllOff = "{\"challenge\":false,\"squadStatus\":false,\"squadEvents\":false," +
        "\"maintenance\":false,\"playerLeague\":false,\"dailyRewardNotification\":false}";
    internal const string AllOn = "{\"challenge\":true,\"squadStatus\":true,\"squadEvents\":true," +
        "\"maintenance\":true,\"playerLeague\":true,\"dailyRewardNotification\":true}";

    internal static async Task RunAsync(string uri)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        Action? beforeWrite = null;
        settings.ClusterConfigurator = cluster => cluster.Subscribe<CommandStartedEvent>(command =>
        {
            if (command.CommandName == "findAndModify")
            {
                beforeWrite?.Invoke();
            }
        });
        var client = new MongoClient(settings);
        var trustedClient = new MongoClient(uri);
        string name = "war_settings_" + Guid.NewGuid().ToString("N");
        var context = new Context(client.GetDatabase(name), trustedClient.GetDatabase(name));
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(120));
        try
        {
            await context.Store.Initialize(deadline.Token);
            await CheckFirstWriteAsync(context, deadline.Token);
            await CheckRaceAsync(context, hook => beforeWrite = hook, deadline.Token);
            await CheckMetadataConflictAsync(context, hook => beforeWrite = hook, deadline.Token);
            await CheckSessionConflictAsync(context, hook => beforeWrite = hook, deadline.Token);
            await CheckDamagedStateAsync(context, deadline.Token);
            await CheckFailedWriteAsync(context, deadline.Token);
            Console.WriteLine("PASS: 6 Settings publication/race/metadata/session/corruption/fault groups");
        }
        finally
        {
            beforeWrite = null;
            await trustedClient.DropDatabaseAsync(name, CancellationToken.None);
        }
    }

    private static async Task CheckFirstWriteAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(null, cancellationToken);
        LegacyPlayerDocument? committed = await context.Store.ApplySettingsAsync(
            player, LegacySettingsSnapshot.Parse(AllOn), context.Time, cancellationToken);
        Require(committed?.Serialized["Settings"] == AllOn && committed.Revision == 2,
            "Initial Settings did not publish as one complete snapshot.");
        Require(typeof(LegacyPlayerStore).GetMethod("SetSerialized") == null,
            "Generic blob replacement must not bypass complete Settings authority.");
    }

    private static async Task CheckRaceAsync(
        Context context, Action<Action?> setHook, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(Metadata(1), cancellationToken);
        using var writes = new Barrier(2);
        int commands = 0;
        setHook(() =>
        {
            if (Interlocked.Increment(ref commands) <= 2)
            {
                Require(writes.SignalAndWait(TimeSpan.FromSeconds(10), cancellationToken),
                    "Settings race did not force both revision reads before either write.");
            }
        });
        try
        {
            Task<LegacyPlayerDocument?> Start(string json) => Task.Run(() => context.Store.ApplySettingsAsync(
                player, LegacySettingsSnapshot.Parse(json), context.Time, cancellationToken), cancellationToken);
            LegacyPlayerDocument?[] results = await Task.WhenAll(Start(AllOn), Start(AllOff));
            LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
            JsonObject snapshot = JsonNode.Parse(saved.Serialized["Settings"])!.AsObject();
            bool[] flags = snapshot.Where(property => property.Key != "futureMetadata")
                .Select(property => property.Value!.GetValue<bool>()).ToArray();
            Require(results.All(result => result != null) && commands == 3 && saved.Revision == 3 &&
                flags.Length == 6 && flags.All(flag => flag == flags[0]) &&
                snapshot["futureMetadata"]!["revision"]!.GetValue<int>() == 1,
                "Concurrent complete snapshots mixed flags or discarded unmodeled metadata.");
        }
        finally
        {
            setHook(null);
        }
    }

    private static async Task CheckMetadataConflictAsync(
        Context context, Action<Action?> setHook, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(Metadata(1), cancellationToken);
        int commands = 0;
        setHook(() =>
        {
            if (Interlocked.Increment(ref commands) == 1)
            {
                context.Players.UpdateOne(row => row.Id == player.Id,
                    Builders<LegacyPlayerDocument>.Update.Set("Serialized.Settings", Metadata(2))
                        .Inc(row => row.Revision, 1));
            }
        });
        try
        {
            await context.Store.ApplySettingsAsync(player, LegacySettingsSnapshot.Parse(AllOn),
                context.Time, cancellationToken);
            LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
            JsonObject snapshot = JsonNode.Parse(saved.Serialized["Settings"])!.AsObject();
            Require(commands == 2 && saved.Revision == 3 && snapshot["challenge"]!.GetValue<bool>() &&
                snapshot["futureMetadata"]!["revision"]!.GetValue<int>() == 2 &&
                snapshot["futureMetadata"]!["exact"]!.GetValue<long>() == long.MaxValue &&
                saved.Serialized["PlayerAnalyticsData"] == "{\"opaque\":17}",
                "Retry overwrote newer metadata, rounded its integer or replaced another subsystem.");
        }
        finally
        {
            setHook(null);
        }
    }

    private static async Task CheckSessionConflictAsync(
        Context context, Action<Action?> setHook, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(AllOff, cancellationToken);
        int commands = 0;
        setHook(() =>
        {
            if (Interlocked.Increment(ref commands) == 1)
            {
                context.Players.UpdateOne(row => row.Id == player.Id,
                    Builders<LegacyPlayerDocument>.Update.Set(row => row.SessionHash,
                        LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken())).Inc(row => row.Revision, 1));
            }
        });
        try
        {
            LegacyPlayerDocument? result = await context.Store.ApplySettingsAsync(
                player, LegacySettingsSnapshot.Parse(AllOn), context.Time, cancellationToken);
            LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
            Require(result == null && commands == 1 && saved.Revision == 2 && saved.Serialized["Settings"] == AllOff,
                "Settings retried through session rotation or published an obsolete caller's flags.");
        }
        finally
        {
            setHook(null);
        }
    }

    private static async Task CheckDamagedStateAsync(Context context, CancellationToken cancellationToken)
    {
        foreach (string damaged in new[] { "null", "{}", "{\"challenge\":true}" })
        {
            LegacyPlayerDocument player = await context.SeedAsync(damaged, cancellationToken);
            bool rejected = false;
            try
            {
                await context.Store.ApplySettingsAsync(player, LegacySettingsSnapshot.Parse(AllOn),
                    context.Time, cancellationToken);
            }
            catch (InvalidDataException)
            {
                rejected = true;
            }

            LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
            Require(rejected && saved.Revision == 1 && saved.Serialized["Settings"] == damaged,
                "Settings update reset damaged durable state into a new valid snapshot.");
        }
    }

    private static async Task CheckFailedWriteAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(AllOff, cancellationToken);
        await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
        {
            { "collMod", "legacyPlayers" },
            { "validator", new BsonDocument("Serialized.Settings", new BsonDocument("$regex", "\"challenge\":false")) }
        }, cancellationToken: cancellationToken);
        try
        {
            bool rejected = false;
            try
            {
                await context.Store.ApplySettingsAsync(player, LegacySettingsSnapshot.Parse(AllOn),
                    context.Time, cancellationToken);
            }
            catch (MongoCommandException exception) when (exception.Code == 121)
            {
                rejected = true;
            }
            catch (MongoWriteException exception) when (exception.WriteError.Code == 121)
            {
                rejected = true;
            }

            LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
            Require(rejected && saved.Revision == 1 && saved.Serialized["Settings"] == AllOff,
                "A rejected atomic Settings write published a partial successor.");
        }
        finally
        {
            await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
            {
                { "collMod", "legacyPlayers" }, { "validator", new BsonDocument() }
            }, cancellationToken: CancellationToken.None);
        }
    }

    private static string Metadata(int revision)
    {
        JsonObject state = JsonNode.Parse(AllOff)!.AsObject();
        state["futureMetadata"] = new JsonObject { ["revision"] = revision, ["exact"] = long.MaxValue };
        return state.ToJsonString();
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class Context(IMongoDatabase database, IMongoDatabase trusted)
    {
        internal DateTimeOffset Time { get; } = DateTimeOffset.UtcNow;
        internal IMongoDatabase Database { get; } = trusted;
        internal LegacyPlayerStore Store { get; } = new(database);
        internal IMongoCollection<LegacyPlayerDocument> Players { get; } =
            trusted.GetCollection<LegacyPlayerDocument>("legacyPlayers");

        internal Task<LegacyPlayerDocument> ReadAsync(string id, CancellationToken cancellationToken) =>
            Players.Find(row => row.Id == id).SingleAsync(cancellationToken);

        internal async Task<LegacyPlayerDocument> SeedAsync(string? settings, CancellationToken cancellationToken)
        {
            var player = new LegacyPlayerDocument
            {
                Id = Guid.NewGuid().ToString("N"),
                DogTagMax = 4500,
                CreatedUtc = Time.UtcDateTime.AddMinutes(-1),
                SessionExpiresUtc = Time.UtcDateTime.AddHours(1)
            };
            player.Serialized["PlayerAnalyticsData"] = "{\"opaque\":17}";
            if (settings != null)
            {
                player.Serialized["Settings"] = settings;
            }

            await LegacyTestAccounts.InsertAsync(Database, player, cancellationToken);
            return player;
        }
    }
}
