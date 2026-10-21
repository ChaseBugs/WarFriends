using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using War.Backend.Legacy.Accounts;
using War.Persistence;
using War.Persistence.Legacy.Accounts;

namespace War.Battle.Tests.Legacy.Accounts;

/// <summary>Checks initial publication, rejected input, historical damage and rotation on real MongoDB.</summary>
internal static class LegacyAccountStoreTests
{
    private const int ParallelAccounts = 4;

    internal static async Task RunAsync(string uri)
    {
        var inserts = new ConcurrentQueue<BsonDocument>();
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ClusterConfigurator = cluster => cluster.Subscribe<CommandStartedEvent>(command =>
        {
            if (command.CommandName == "insert" && command.Command["insert"] == "legacyPlayers")
            {
                inserts.Enqueue(command.Command.DeepClone().AsBsonDocument);
            }
        });
        var client = new MongoClient(settings);
        string name = "war_account_store_" + Guid.NewGuid().ToString("N");
        var context = new Context(client.GetDatabase(name), inserts);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(120));
        try
        {
            await context.Store.Initialize(deadline.Token);
            await CheckRejectedBeforeHashAsync(context, deadline.Token);
            await CheckConcurrentCreationAsync(context, deadline.Token);
            await CheckFailedInsertAsync(context, deadline.Token);
            await CheckDamagedHistoricalRowAsync(context, deadline.Token);
            await CheckExpiredSessionAsync(context, deadline.Token);
            await CheckRotationRacesAsync(context, deadline.Token);
            await CheckFailedRotationAsync(context, deadline.Token);
            Console.WriteLine("PASS: 7 account publication, concurrency, credential/session and rollback scenarios");
        }
        finally
        {
            await client.DropDatabaseAsync(name, CancellationToken.None);
        }
    }

    private static async Task CheckRejectedBeforeHashAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyAccountRegistration valid = LegacyAccountTestFixture.Registration();
        LegacyAccountRegistration[] invalid = [valid with { Locale = " en" }, valid with { DeviceToken = "" },
            valid with { UtcOffsetHours = double.NaN }, valid with { UtcOffsetHours = double.PositiveInfinity },
            valid with { DeviceToken = "token\n" }, valid with { GameCenterId = "G:unsupported" }];
        foreach (LegacyAccountRegistration input in invalid)
        {
            LegacyAccountCreation creation = LegacyAccountTestFixture.Creation() with { Registration = input };
            await ExpectInvalidAsync(() => context.Store.CreateAccountAsync(creation, cancellationToken));
            Require(creation.Player.Id == "" && creation.Player.Salt.Length == 0 &&
                creation.Player.PasswordHash.Length == 0,
                "Rejected reusable input performed credential work.");
        }

        LegacyAccountCreation badStarter = LegacyAccountTestFixture.Creation();
        badStarter.Player.Gold = -1;
        await ExpectInvalidAsync(() => context.Store.CreateAccountAsync(badStarter, cancellationToken));
        LegacyAccountCreation badLifetime = LegacyAccountTestFixture.Creation() with { SessionLifetimeHours = 0 };
        await ExpectInvalidAsync(() => context.Store.CreateAccountAsync(badLifetime, cancellationToken));
        Require(badStarter.Player.Salt.Length == 0 && badLifetime.Player.Salt.Length == 0 && context.Inserts.IsEmpty,
            "Invalid starter policy reached hashing or persistence.");
    }

    private static async Task CheckConcurrentCreationAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyAccountRegistration registration = LegacyAccountTestFixture.Registration() with
        {
            Locale = "kr",
            UtcOffsetHours = -1E-07,
            DeviceToken = " padded-opaque-token "
        };
        using var readers = new Barrier(ParallelAccounts);
        Task<LegacyAccountCreated>[] pending = Enumerable.Range(0, ParallelAccounts).Select(_ => Task.Run(() =>
        {
            Require(readers.SignalAndWait(TimeSpan.FromSeconds(5), cancellationToken),
                "Missing registration contender.");
            return context.Service.CreateAsync(registration, cancellationToken);
        }, cancellationToken)).ToArray();
        LegacyAccountCreated[] created = await Task.WhenAll(pending);
        Require(created.Select(result => result.Token).Distinct().Count() == ParallelAccounts,
            "Concurrent initial sessions must be distinct.");
        Require(context.Inserts.Count == ParallelAccounts, "Creation must perform exactly one insert per account.");
        foreach (BsonDocument command in context.Inserts)
        {
            BsonDocument document = command["documents"].AsBsonArray.Single().AsBsonDocument;
            Require(Regex.IsMatch(document["SessionHash"].AsString, "\\A[A-F0-9]{64}\\z") &&
                document["Revision"].ToInt64() == 1, "An initial insert published missing session material.");
        }

        foreach (LegacyAccountCreated result in created)
        {
            LegacyPlayerDocument? saved = await context.Store.Authenticate(result.Token,
                result.Player.Id, cancellationToken);
            Require(saved != null && saved.Revision == 1 &&
                saved.SessionHash == LegacyPlayerStore.HashToken(result.Token),
                "A returned initial token did not authenticate its committed account.");
            Require(saved!.Locale == "kr" && saved.DeviceToken == " padded-opaque-token " &&
                saved.InitialUtcOffsetHours == -1E-07 && saved.LastAction == saved.DogTagLastUpdate &&
                saved.CreatedUtc == DateTimeOffset.FromUnixTimeSeconds(saved.LastAction).UtcDateTime &&
                saved.SessionExpiresUtc == saved.CreatedUtc.AddHours(24), "Initial metadata/time tuple diverged.");
            Require(await context.Store.VerifyPassword(saved.Id, result.Password, cancellationToken) != null,
                "The returned password did not verify against the initial insert.");
        }
    }

    private static async Task CheckFailedInsertAsync(Context context, CancellationToken cancellationToken)
    {
        long before = await context.Players.CountDocumentsAsync(FilterDefinition<LegacyPlayerDocument>.Empty,
            cancellationToken: cancellationToken);
        await context.SetValidatorAsync(new BsonDocument("Name", new BsonDocument("$ne", "Recruit")),
            cancellationToken);
        bool hasRejected = false;
        try
        {
            await context.Service.CreateAsync(LegacyAccountTestFixture.Registration(), cancellationToken);
        }
        catch (MongoWriteException exception) when (exception.WriteError.Code == 121)
        {
            hasRejected = true;
        }
        finally
        {
            await context.SetValidatorAsync(new BsonDocument(), cancellationToken);
        }

        long after = await context.Players.CountDocumentsAsync(FilterDefinition<LegacyPlayerDocument>.Empty,
            cancellationToken: cancellationToken);
        Require(hasRejected && after == before, "A failed initial insert returned success or left a partial account.");
    }

    private static async Task CheckDamagedHistoricalRowAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyAccountCreated original = await context.CreateAsync(cancellationToken);
        LegacyPlayerDocument damaged = await context.ReadAsync(original.Player.Id, cancellationToken);
        damaged.Id = Guid.NewGuid().ToString("N");
        damaged.SessionHash = "";
        await context.Players.InsertOneAsync(damaged, cancellationToken: cancellationToken);
        string before = damaged.ToBsonDocument().ToJson();
        await ExpectInvalidAsync(() => context.Store.VerifyPassword(damaged.Id, original.Password, cancellationToken));
        await ExpectInvalidAsync(() => context.Store.RotateSessionAsync(damaged, 24, cancellationToken));
        LegacyPlayerDocument unchanged = await context.ReadAsync(damaged.Id, cancellationToken);
        Require(unchanged.ToBsonDocument().ToJson() == before, "Login silently repaired a damaged historical session.");
        LegacyAccountCreated next = await context.CreateAsync(cancellationToken);
        Require(next.Player.SessionHash.Length == 64, "A historical empty hash still blocked new registrations.");
    }

    private static async Task CheckExpiredSessionAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyAccountCreated original = await context.CreateAsync(cancellationToken);
        DateTime createdUtc = DateTime.UtcNow.AddHours(-2);
        await context.Players.UpdateOneAsync(row => row.Id == original.Player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.CreatedUtc, createdUtc)
                .Set(row => row.SessionExpiresUtc, createdUtc.AddHours(1)), cancellationToken: cancellationToken);
        Require(await context.Store.Authenticate(original.Token, original.Player.Id, cancellationToken) == null,
            "An expired bearer must not authenticate.");
        LegacyPlayerDocument verified = await context.Store.VerifyPassword(original.Player.Id,
            original.Password, cancellationToken) ?? throw new InvalidDataException("Valid expired account rejected.");
        LegacySessionIssued issued = await context.Store.RotateSessionAsync(verified, 24, cancellationToken)
            ?? throw new InvalidDataException("Expired valid account could not renew.");
        Require(issued.Player.Revision == 2 && await context.Store.Authenticate(issued.Token,
            original.Player.Id, cancellationToken) != null, "Renewal must return the committed session revision.");
    }

    private static async Task CheckRotationRacesAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyAccountCreated original = await context.CreateAsync(cancellationToken);
        LegacySessionIssued?[] replies = await Task.WhenAll(
            Task.Run(() => context.Store.RotateSessionAsync(original.Player, 24, cancellationToken)),
            Task.Run(() => context.Store.RotateSessionAsync(original.Player, 24, cancellationToken)));
        Require(replies.All(reply => reply != null) && replies.Select(reply => reply!.Player.Revision)
            .Order().SequenceEqual([2L, 3L]),
            "Concurrent rotations must return distinct committed revisions.");
        foreach (LegacySessionIssued? reply in replies)
        {
            Require(reply!.Player.SessionHash == LegacyPlayerStore.HashToken(reply.Token),
                "Rotation returned a stale session.");
        }

        LegacyAccountCreated deleted = await context.CreateAsync(cancellationToken);
        await context.Players.DeleteOneAsync(row => row.Id == deleted.Player.Id, cancellationToken);
        Require(await context.Store.RotateSessionAsync(deleted.Player, 24, cancellationToken) == null,
            "Rotation issued a token for a deleted account.");
        LegacyAccountCreated changed = await context.CreateAsync(cancellationToken);
        await context.Players.UpdateOneAsync(row => row.Id == changed.Player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.PasswordHash, RandomNumberGenerator.GetBytes(32))
                .Inc(row => row.Revision, 1), cancellationToken: cancellationToken);
        Require(await context.Store.RotateSessionAsync(changed.Player, 24, cancellationToken) == null,
            "Rotation reused a proof after the credential changed.");
    }

    private static async Task CheckFailedRotationAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyAccountCreated original = await context.CreateAsync(cancellationToken);
        await context.SetValidatorAsync(new BsonDocument("Revision", new BsonDocument("$lte", 1)), cancellationToken);
        bool hasRejected = false;
        try
        {
            await context.Store.RotateSessionAsync(original.Player, 24, cancellationToken);
        }
        catch (MongoCommandException exception) when (exception.Code == 121)
        {
            hasRejected = true;
        }
        finally
        {
            await context.SetValidatorAsync(new BsonDocument(), cancellationToken);
        }

        LegacyPlayerDocument saved = await context.ReadAsync(original.Player.Id, cancellationToken);
        Require(hasRejected && saved.Revision == 1 && saved.SessionHash == original.Player.SessionHash,
            "Failed rotation changed session state or returned an uncommitted token.");
    }

    private static async Task ExpectInvalidAsync(Func<Task> action)
    {
        bool hasRejected = false;
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            hasRejected = true;
        }

        Require(hasRejected, "Invalid reusable account/session input was accepted.");
    }

    private static void Require(bool condition, string message) => LegacyAccountTestFixture.Require(condition, message);

    private sealed class Context
    {
        private readonly IMongoDatabase _database;

        internal ConcurrentQueue<BsonDocument> Inserts { get; }

        internal LegacyPlayerStore Store { get; }

        internal IMongoCollection<LegacyPlayerDocument> Players { get; }

        internal LegacyAccountService Service { get; }

        internal Context(IMongoDatabase database, ConcurrentQueue<BsonDocument> inserts)
        {
            _database = database;
            Inserts = inserts;
            Store = new LegacyPlayerStore(database);
            Players = database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
            Service = new LegacyAccountService(Store, LegacyAccountTestFixture.Policy());
        }

        internal Task<LegacyAccountCreated> CreateAsync(CancellationToken cancellationToken) =>
            Store.CreateAccountAsync(LegacyAccountTestFixture.Creation(), cancellationToken);

        internal Task<LegacyPlayerDocument> ReadAsync(string id, CancellationToken cancellationToken) =>
            Players.Find(row => row.Id == id).SingleAsync(cancellationToken);

        internal Task<BsonDocument> SetValidatorAsync(BsonDocument validator, CancellationToken cancellationToken) =>
            _database.RunCommandAsync<BsonDocument>(new BsonDocument
            {
                ["collMod"] = "legacyPlayers",
                ["validator"] = validator,
                ["validationLevel"] = "strict"
            }, cancellationToken: cancellationToken);
    }
}
