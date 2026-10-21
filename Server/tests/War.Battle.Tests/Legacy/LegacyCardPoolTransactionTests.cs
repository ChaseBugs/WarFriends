using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Backend.Legacy.Cards;
using War.Persistence;
using War.Persistence.Legacy.Cards;

namespace War.Battle.Tests.Legacy;

/// <summary>Checks competing stock, repeated intents, rollback and membership races in real MongoDB.</summary>
internal static class LegacyCardPoolTransactionTests
{
    internal static async Task RunAsync(string uri)
    {
        var client = new MongoClient(uri);
        string name = "war_card_pool_" + Guid.NewGuid().ToString("N");
        var context = new Context(client.GetDatabase(name));
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(120));
        try
        {
            await context.Store.Initialize(deadline.Token);
            await CheckLastCardAsync(context, deadline.Token);
            await CheckRepeatedOperationAsync(context, deadline.Token);
            await CheckLegacyRetryAsync(context, deadline.Token);
            await CheckReceiptFailureAsync(context, deadline.Token);
            await CheckMembershipRaceAsync(context, deadline.Token);
            Console.WriteLine("PASS: 5 card-pool concurrency, retry, rollback and membership-race scenarios");
        }
        finally
        {
            await client.DropDatabaseAsync(name, CancellationToken.None);
        }
    }

    private static async Task CheckLastCardAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyCardPoolSnapshot first = LegacyCardPoolTests.CreateSnapshot();
        var other = new LegacyPlayerDocument { Id = Guid.NewGuid().ToString("N"), SquadId = first.Actor.SquadId };
        first.Squad!.Members.Add(new LegacySquadMember { PlayerId = other.Id });
        await context.SeedAsync(first, cancellationToken);
        await context.InsertPlayerAsync(other, cancellationToken);
        LegacyCardPoolIntent intent = LegacyCardPoolTests.Withdrawal(first);
        LegacyCardPoolOperation operation = Operation(first.Actor.Id, intent, "first");
        int calculations = 0;
        using var readers = new Barrier(2);
        LegacyCardPoolMutation Calculate(LegacyCardPoolSnapshot snapshot)
        {
            if (Interlocked.Increment(ref calculations) <= 2)
            {
                Require(readers.SignalAndWait(TimeSpan.FromSeconds(5), cancellationToken), "Missing stock contender.");
            }

            return context.Rules.Calculate(snapshot, intent, LegacyCardPoolTests.Now);
        }

        LegacyCardPoolResult[] results = await Task.WhenAll(
            Task.Run(() => context.Store.ApplyCardPoolAsync(operation, Calculate, cancellationToken)),
            Task.Run(() => context.Store.ApplyCardPoolAsync(operation with
            {
                ActorId = other.Id,
                OperationId = "second"
            }, Calculate, cancellationToken)));
        Require(results.Count(result => result.Result == 1) == 1 && calculations >= 3,
            "The last donor card must have exactly one winner after conflict recalculation.");
        LegacyPlayerDocument donor = await context.ReadAsync(first.Donor!.Id, cancellationToken);
        Require(donor.DepositedCards.Count == 0 && donor.Reputation == 45, "Donor stock/reputation diverged.");
        int total = results.Sum(result => context.Amount(result.Actor));
        Require(total == 1, "Competing withdrawals created or lost a card.");
    }

    private static async Task CheckRepeatedOperationAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyCardPoolSnapshot snapshot = LegacyCardPoolTests.CreateSnapshot();
        snapshot.Actor.Serialized["CardManagerData"] = PlayerState.Write(new CardManagerData
        {
            CardData = new() { [LegacyCardPoolTests.CardId] = new() { Amount = 2 } }
        });
        await context.SeedAsync(snapshot, cancellationToken);
        var intent = new LegacyCardPoolIntent(new Dictionary<string, int> { [LegacyCardPoolTests.CardId] = 1 },
            new Dictionary<string, int>(), null, null);
        LegacyCardPoolOperation operation = Operation(snapshot.Actor.Id, intent, "deposit-once");
        Task<LegacyCardPoolResult> Apply() => context.ApplyAsync(operation, intent, cancellationToken);
        LegacyCardPoolResult[] replies = await Task.WhenAll(Task.Run(Apply), Task.Run(Apply));
        Require(replies.All(result => result.Result == 1), "Repeated keyed deposit must replay success.");
        LegacyPlayerDocument actor = await context.ReadAsync(snapshot.Actor.Id, cancellationToken);
        Require(context.Amount(actor) == 1 && actor.DepositedCards[LegacyCardPoolTests.CardId] == 1,
            "A repeated operation applied its deposit twice.");
        LegacyCardPoolIntent altered = intent with { Added = new Dictionary<string, int>() };
        LegacyCardPoolResult rejected = await context.ApplyAsync(operation with
        {
            PayloadDigest = LegacyCardPoolParser.Digest(altered)
        }, altered, cancellationToken);
        Require(rejected.Result == 11301, "Reused identity with changed payload must reject.");
        var restarted = new LegacyPlayerStore(context.Database);
        LegacyCardPoolResult replay = await restarted.ApplyCardPoolAsync(operation,
            row => context.Rules.Calculate(row, intent, LegacyCardPoolTests.Now), cancellationToken);
        Require(replay.Result == 1 && context.Amount(replay.Actor) == 1, "Restart/lost-reply replay applied again.");
    }

    private static async Task CheckLegacyRetryAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyCardPoolSnapshot snapshot = LegacyCardPoolTests.CreateSnapshot();
        await context.SeedAsync(snapshot, cancellationToken);
        LegacyCardPoolIntent intent = LegacyCardPoolTests.Withdrawal(snapshot);
        LegacyCardPoolOperation operation = Operation(snapshot.Actor.Id, intent, null);
        LegacyCardPoolResult first = await context.ApplyAsync(operation, intent, cancellationToken);
        LegacyCardPoolResult replay = await context.ApplyAsync(operation, intent, cancellationToken);
        Require(first.Result == 1 && replay.Result == 1 && context.Amount(replay.Actor) == 1,
            "Unkeyed withdrawal must replay its matching active cooldown without another grant.");
        LegacyCardPoolResult expired = await context.ApplyAsync(operation with
        {
            NowUnixSeconds = first.NextWithdraw
        }, intent, cancellationToken);
        Require(expired.Result == 11301, "A past-cooldown request must not replay an old success.");
    }

    private static async Task CheckReceiptFailureAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyCardPoolSnapshot snapshot = LegacyCardPoolTests.CreateSnapshot();
        await context.SeedAsync(snapshot, cancellationToken);
        LegacyCardPoolIntent intent = LegacyCardPoolTests.Withdrawal(snapshot);
        await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
        {
            ["collMod"] = "legacyCardPoolReceipts",
            ["validator"] = new BsonDocument("Result", -1),
            ["validationLevel"] = "strict"
        }, cancellationToken: cancellationToken);
        bool hasRejected = false;
        try
        {
            await context.ApplyAsync(Operation(snapshot.Actor.Id, intent, "fault"), intent, cancellationToken);
        }
        catch (MongoWriteException)
        {
            hasRejected = true;
        }
        finally
        {
            await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
            {
                ["collMod"] = "legacyCardPoolReceipts",
                ["validator"] = new BsonDocument()
            }, cancellationToken: cancellationToken);
        }

        LegacyPlayerDocument actor = await context.ReadAsync(snapshot.Actor.Id, cancellationToken);
        LegacyPlayerDocument donor = await context.ReadAsync(snapshot.Donor!.Id, cancellationToken);
        LegacySquadDocument squad = await context.Database.GetCollection<LegacySquadDocument>("legacySquads")
            .Find(row => row.Id == snapshot.Squad!.Id).SingleAsync(cancellationToken);
        Require(hasRejected && context.Amount(actor) == 0 && donor.Reputation == 0 &&
            donor.DepositedCards[LegacyCardPoolTests.CardId] == 1 && squad.Revision == 0,
            "A receipt failure must roll back receiver, donor, cooldown, reputation and squad fence.");
    }

    private static async Task CheckMembershipRaceAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyCardPoolSnapshot snapshot = LegacyCardPoolTests.CreateSnapshot();
        await context.SeedAsync(snapshot, cancellationToken);
        LegacyCardPoolIntent intent = LegacyCardPoolTests.Withdrawal(snapshot);
        using var hasRead = new ManualResetEventSlim();
        using var canWrite = new ManualResetEventSlim();
        int calculations = 0;
        Task<LegacyCardPoolResult> pending = Task.Run(() => context.Store.ApplyCardPoolAsync(
            Operation(snapshot.Actor.Id, intent, "membership"), current =>
            {
                if (Interlocked.Increment(ref calculations) == 1)
                {
                    hasRead.Set();
                    Require(canWrite.Wait(TimeSpan.FromSeconds(5), cancellationToken), "Membership race timed out.");
                }

                return context.Rules.Calculate(current, intent, LegacyCardPoolTests.Now);
            }, cancellationToken));
        Require(hasRead.Wait(TimeSpan.FromSeconds(5), cancellationToken), "Transfer did not read its snapshot.");
        try
        {
            // Simulate an external roster change while the transfer holds its old read snapshot.
            UpdateResult removed = await context.Database.GetCollection<LegacySquadDocument>("legacySquads")
                .UpdateOneAsync(row => row.Id == snapshot.Squad!.Id,
                    Builders<LegacySquadDocument>.Update.PullFilter(row => row.Members,
                        member => member.PlayerId == snapshot.Donor!.Id).Inc(row => row.Revision, 1),
                    cancellationToken: cancellationToken);
            Require(removed.ModifiedCount == 1, "The competing roster change did not apply.");
        }
        finally
        {
            canWrite.Set();
        }

        LegacyCardPoolResult result = await pending;
        Require(calculations >= 2 && result.Result == 11301 && context.Amount(result.Actor) == 0,
            "A concurrent roster removal must force revalidation before any transfer commits.");
    }

    private static LegacyCardPoolOperation Operation(string actor, LegacyCardPoolIntent intent, string? id) => new()
    {
        ActorId = actor,
        DonorId = intent.DonorId,
        ActionId = intent.CardId == null ? 174 : 175,
        PayloadDigest = LegacyCardPoolParser.Digest(intent),
        OperationId = id,
        NowUnixSeconds = LegacyCardPoolTests.Now
    };

    private static void Require(bool condition, string message) => LegacyCardPoolTests.Require(condition, message);

    private sealed class Context(IMongoDatabase database)
    {
        internal IMongoDatabase Database { get; } = database;

        internal LegacyPlayerStore Store { get; } = new(database);

        internal LegacyCardPoolRules Rules { get; } = new(LegacyCardPoolTests.LoadPolicy());

        internal async Task SeedAsync(LegacyCardPoolSnapshot snapshot, CancellationToken cancellationToken)
        {
            await InsertPlayerAsync(snapshot.Actor, cancellationToken);
            await InsertPlayerAsync(snapshot.Donor!, cancellationToken);
            await Database.GetCollection<LegacySquadDocument>("legacySquads")
                .InsertOneAsync(snapshot.Squad!, cancellationToken: cancellationToken);
        }

        internal Task InsertPlayerAsync(LegacyPlayerDocument player, CancellationToken cancellationToken)
        {
            player.SessionHash = Guid.NewGuid().ToString("N");
            return Database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
                .InsertOneAsync(player, cancellationToken: cancellationToken);
        }

        internal async Task<LegacyPlayerDocument> ReadAsync(string id, CancellationToken cancellationToken) =>
            await Store.ById(id, cancellationToken) ?? throw new InvalidDataException("Missing fixture player.");

        internal int Amount(LegacyPlayerDocument actor) =>
            actor.Serialized.TryGetValue("CardManagerData", out string? json)
                ? LegacyCardPoolTests.ReadAmount(json) : 0;

        internal Task<LegacyCardPoolResult> ApplyAsync(
            LegacyCardPoolOperation operation, LegacyCardPoolIntent intent, CancellationToken cancellationToken) =>
            Store.ApplyCardPoolAsync(operation,
                snapshot => Rules.Calculate(snapshot, intent, operation.NowUnixSeconds), cancellationToken);
    }
}
