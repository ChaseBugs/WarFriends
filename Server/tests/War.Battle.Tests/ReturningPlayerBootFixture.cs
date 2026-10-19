using System.Text.Json;
using MongoDB.Driver;
using War.Persistence;

namespace War.Battle.Tests;

/// <summary>Seeds one isolated boot account for source-preserving returning-player matchmaking checks.</summary>
internal static class ReturningPlayerBootFixture
{
    private const string DatabasePrefix = "war_client_boot_";
    private const int ReturningRankIndex = 4;
    private const long ReturningExperience = 215_960;
    private const int RecordedAverageFps = 30;

    /// <summary>Updates only an unused smoke database after its original starter insertion has been verified.</summary>
    internal static async Task SeedAsync(string uri, string databaseName, string reportPath)
    {
        await SeedAccountsAsync(uri, databaseName, reportPath, 1);
    }

    /// <summary>Seeds exactly two already booted identities for the normal two-Unity admission gate.</summary>
    internal static async Task SeedPairAsync(string uri, string databaseName, string reportPath)
    {
        await SeedAccountsAsync(uri, databaseName, reportPath, 2);
    }

    private static async Task SeedAccountsAsync(string uri, string databaseName, string reportPath, int accountCount)
    {
        if (!databaseName.StartsWith(DatabasePrefix, StringComparison.Ordinal) ||
            !Guid.TryParseExact(databaseName[DatabasePrefix.Length..], "N", out _))
        {
            throw new InvalidDataException("Returning-player fixtures require an isolated client-boot database.");
        }

        IMongoDatabase database = new MongoClient(uri).GetDatabase(databaseName);
        await RequireUnusedBattleStateAsync(database);
        IMongoCollection<LegacyPlayerDocument> players = database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        List<LegacyPlayerDocument> accounts = await players.Find(_ => true).Limit(accountCount + 1).ToListAsync();
        if (accounts.Count != accountCount || accounts.Any(account => account.Revision < 1 ||
            account.Revision == long.MaxValue))
        {
            throw new InvalidDataException("The isolated boot roster has an unexpected count or revision.");
        }

        foreach (LegacyPlayerDocument account in accounts)
        {
            await UpdateAccountAsync(players, account);
        }
        await File.WriteAllTextAsync(reportPath, JsonSerializer.Serialize(new
        {
            schemaVersion = 1,
            accountCount,
            scope = "synthetic returning-player state; not earned progression or battle acceptance",
            rankIndex = ReturningRankIndex,
            experience = ReturningExperience,
            recordedAverageFps = RecordedAverageFps
        }) + "\n");
        Console.WriteLine("PASS: isolated returning-player fixture seeded without changing Client routing rules");
    }

    private static async Task RequireUnusedBattleStateAsync(IMongoDatabase database)
    {
        string[] collections = ["battle_queue_tickets", "battle_pairs", "battle_allocations"];
        foreach (string collectionName in collections)
        {
            long count = await database.GetCollection<MongoDB.Bson.BsonDocument>(collectionName)
                .CountDocumentsAsync(FilterDefinition<MongoDB.Bson.BsonDocument>.Empty);
            if (count != 0)
            {
                throw new InvalidDataException("A returning-player fixture cannot change admitted battle state.");
            }
        }
    }

    private static async Task UpdateAccountAsync(
        IMongoCollection<LegacyPlayerDocument> players, LegacyPlayerDocument account)
    {
        // LevelManager uses zero-based rows. The first four recovered EXPERIENCE thresholds total 215,960.
        // UserDeviceManager falls back to the first saved device when the current model has no entry.
        string devices = JsonSerializer.Serialize(new
        {
            userDevices = new Dictionary<string, object>
            {
                ["ValidationFixtureDevice"] = new { lastAverageFps = new[] { RecordedAverageFps } }
            }
        });
        UpdateDefinition<LegacyPlayerDocument> update = Builders<LegacyPlayerDocument>.Update
            .Set(player => player.Level, ReturningRankIndex)
            .Set(player => player.LevelExperience, 0)
            .Set(player => player.Experience, ReturningExperience)
            .Set("Serialized.UserDevices", devices)
            .Inc(player => player.Revision, 1);
        UpdateResult result = await players.UpdateOneAsync(
            player => player.Id == account.Id && player.Revision == account.Revision, update);
        if (result.ModifiedCount != 1)
        {
            throw new InvalidDataException("The boot account changed while seeding its returning-player fixture.");
        }
    }
}
