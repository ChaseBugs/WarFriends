using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy.DogTags;
using War.Battle.Tests.Legacy.Accounts;
using War.Battle.Tests.Support;
using War.Persistence;
using War.Persistence.Legacy.DogTags;

namespace War.Battle.Tests.Legacy.DogTags;

/// <summary>Forces stale reads, wallet/session changes and failed writes against one owned Mongo database.</summary>
internal static class LegacyDogTagStoreTests
{
    internal static async Task RunAsync(string uri)
    {
        var client = new MongoClient(uri);
        string name = "war_dogtags_" + Guid.NewGuid().ToString("N");
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(120));
        var context = new Context(client.GetDatabase(name));
        try
        {
            await context.Store.Initialize(deadline.Token);
            await CheckRefillRaceAsync(context, deadline.Token);
            await CheckPenaltyRaceAsync(context, deadline.Token);
            await CheckMixedRaceAsync(context, deadline.Token);
            await CheckWalletChangeAsync(context, deadline.Token);
            await CheckSessionChangeAsync(context, deadline.Token);
            await CheckClockConflictAsync(context, deadline.Token);
            await CheckDamagedStateAsync(context, deadline.Token);
            await CheckFailedWriteAsync(context, deadline.Token);
            Console.WriteLine("PASS: 8 dog-tag race, session/wallet/clock fence and failed-publication scenarios");
        }
        finally
        {
            await client.DropDatabaseAsync(name, CancellationToken.None);
        }
    }

    private static async Task CheckRefillRaceAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 100, cancellationToken);
        LegacyDogTagResult?[] results = await RaceAsync(
            context, player, [context.Refill, context.Refill], cancellationToken);
        LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
        Require(saved.Gold == 65 && saved.DogTagSeconds == 4500 && saved.Revision == 2 &&
            results.Count(result => result?.Outcome == LegacyDogTagOutcome.Applied) == 1 &&
            results.Count(result => result?.Outcome == LegacyDogTagOutcome.Unchanged) == 1,
            "Concurrent refill charged twice or overwrote the committed pool.");
    }

    private static async Task CheckPenaltyRaceAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 100, cancellationToken);
        await RaceAsync(context, player, [context.Pay, context.Pay], cancellationToken);
        LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
        Require(saved.DogTagSeconds == -1800 && saved.Gold == 100 && saved.Revision == 3,
            "Concurrent penalties lost debt or changed the wallet.");
    }

    private static async Task CheckMixedRaceAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 100, cancellationToken);
        await RaceAsync(context, player, [context.Pay, context.Refill], cancellationToken);
        LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
        Require(saved.Gold == 65 && saved.DogTagSeconds is 3600 or 4500 && saved.Revision == 3,
            "Penalty/refill race did not conserve a valid serial order.");
    }

    private static async Task CheckWalletChangeAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 35, cancellationToken);
        int plans = 0;
        LegacyDogTagResult? result = await context.Store.ApplyDogTagAsync(player, context.Time, current =>
        {
            if (++plans == 1)
            {
                UpdateResult changed = context.Players.UpdateOne(row => row.Id == player.Id,
                    Builders<LegacyPlayerDocument>.Update.Inc(row => row.Gold, -35).Inc(row => row.Revision, 1));
                Require(changed.ModifiedCount == 1, "Wallet conflict fixture did not publish.");
            }

            return context.Refill(current);
        }, cancellationToken);
        LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
        Require(plans == 2 && result?.Outcome == LegacyDogTagOutcome.NotEnoughGold &&
            saved.Gold == 0 && saved.DogTagSeconds == 0 && saved.Revision == 2,
            "Refill trusted an old wallet or overwrote a competing mutation.");
    }

    private static async Task CheckSessionChangeAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 100, cancellationToken);
        await context.Players.UpdateOneAsync(row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.SessionHash,
                LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken())).Inc(row => row.Revision, 1),
            cancellationToken: cancellationToken);
        LegacyDogTagResult? result = await context.Store.ApplyDogTagAsync(
            player, context.Time, context.Pay, cancellationToken);
        LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
        Require(result == null && saved.DogTagSeconds == 0 && saved.Revision == 2,
            "An obsolete authenticated snapshot mutated a rotated session.");
    }

    private static async Task CheckDamagedStateAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 100, cancellationToken);
        await context.Players.UpdateOneAsync(row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.DogTagLastUpdate, int.MaxValue),
            cancellationToken: cancellationToken);
        try
        {
            await context.Store.ApplyDogTagAsync(player, context.Time, context.Refill, cancellationToken);
        }
        catch (InvalidDataException)
        {
            LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
            Require(saved.Gold == 100 && saved.Revision == 1 && saved.DogTagLastUpdate == int.MaxValue,
                "Rejected dog-tag corruption changed the durable snapshot.");
            return;
        }

        throw new InvalidOperationException("Future stored dog-tag time was accepted.");
    }

    private static async Task CheckClockConflictAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 100, cancellationToken);
        int plans = 0;
        try
        {
            await context.Store.ApplyDogTagAsync(player, context.Time, current =>
            {
                if (++plans == 1)
                {
                    context.Players.UpdateOne(row => row.Id == player.Id,
                        Builders<LegacyPlayerDocument>.Update.Set(row => row.DogTagSeconds, -899)
                            .Set(row => row.DogTagLastUpdate, (int)context.Time.ToUnixTimeSeconds() + 1)
                            .Inc(row => row.Revision, 1));
                }

                return context.Pay(current);
            }, cancellationToken);
        }
        catch (InvalidDataException)
        {
            LegacyPlayerDocument saved = await context.ReadAsync(player.Id, cancellationToken);
            Require(plans == 1 && saved.DogTagSeconds == -899 && saved.Revision == 2 &&
                saved.DogTagLastUpdate == (int)context.Time.ToUnixTimeSeconds() + 1,
                "Older request time rewound a concurrently advanced dog-tag cursor.");
            return;
        }

        throw new InvalidOperationException("A stale request clock replaced a newer dog-tag tuple.");
    }

    private static async Task CheckFailedWriteAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.SeedAsync(0, 100, cancellationToken);
        await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
        {
            { "collMod", "legacyPlayers" },
            { "validator", new BsonDocument("DogTagSeconds", new BsonDocument("$gte", 0)) }
        }, cancellationToken: cancellationToken);
        try
        {
            bool rejected = false;
            try
            {
                await context.Store.ApplyDogTagAsync(player, context.Time, context.Pay, cancellationToken);
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
            Require(rejected && saved.DogTagSeconds == 0 && saved.Gold == 100 && saved.Revision == 1,
                "Rejected Mongo write partially published a dog-tag/wallet successor.");
        }
        finally
        {
            await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
            {
                { "collMod", "legacyPlayers" }, { "validator", new BsonDocument() }
            }, cancellationToken: CancellationToken.None);
        }
    }

    private static async Task<LegacyDogTagResult?[]> RaceAsync(
        Context context,
        LegacyPlayerDocument player,
        Func<LegacyPlayerDocument, LegacyDogTagMutation>[] operations,
        CancellationToken cancellationToken)
    {
        using var readers = new Barrier(operations.Length);
        Task<LegacyDogTagResult?> Start(Func<LegacyPlayerDocument, LegacyDogTagMutation> operation)
        {
            int plans = 0;
            return Task.Run(() => context.Store.ApplyDogTagAsync(player, context.Time, current =>
            {
                if (Interlocked.Increment(ref plans) == 1)
                {
                    Require(readers.SignalAndWait(TimeSpan.FromSeconds(10), cancellationToken),
                        "Race did not force both original revision reads.");
                }

                return operation(current);
            }, cancellationToken), cancellationToken);
        }

        return await Task.WhenAll(operations.Select(Start));
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class Context(IMongoDatabase database)
    {
        private readonly LegacyDogTagPolicy _policy = LegacyDogTagPolicy.FromCatalog(
            LegacyAccountTestFixture.Catalog(), LegacyAccountTestFixture.Policy())!;

        internal DateTimeOffset Time { get; } = DateTimeOffset.UtcNow;
        internal IMongoDatabase Database { get; } = database;
        internal IMongoCollection<LegacyPlayerDocument> Players { get; } =
            database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        internal LegacyPlayerStore Store { get; } = new(database);

        internal Task<LegacyPlayerDocument> ReadAsync(string id, CancellationToken cancellationToken) =>
            Players.Find(row => row.Id == id).SingleAsync(cancellationToken);

        internal LegacyDogTagMutation Pay(LegacyPlayerDocument player) =>
            LegacyDogTagRules.Pay(player, _policy, (int)Time.ToUnixTimeSeconds());

        internal LegacyDogTagMutation Refill(LegacyPlayerDocument player) =>
            LegacyDogTagRules.Refill(player, _policy, (int)Time.ToUnixTimeSeconds());

        internal async Task<LegacyPlayerDocument> SeedAsync(int seconds, long gold, CancellationToken cancellationToken)
        {
            var player = new LegacyPlayerDocument
            {
                Id = Guid.NewGuid().ToString("N"),
                Gold = gold,
                DogTagMax = 4500,
                DogTagSeconds = seconds,
                DogTagLastUpdate = (int)Time.ToUnixTimeSeconds(),
                CreatedUtc = Time.UtcDateTime.AddMinutes(-1),
                SessionExpiresUtc = Time.UtcDateTime.AddHours(1)
            };
            await LegacyTestAccounts.InsertAsync(Database, player, cancellationToken);
            return player;
        }
    }
}
