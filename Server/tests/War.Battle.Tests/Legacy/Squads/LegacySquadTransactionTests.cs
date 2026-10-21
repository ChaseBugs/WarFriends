using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Backend.Legacy.Squads;
using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Battle.Tests.Legacy.Squads;

/// <summary>Checks squad races and publication failures against an isolated replica-set database.</summary>
internal static class LegacySquadTransactionTests
{
    internal static async Task RunAsync(string uri)
    {
        var client = new MongoClient(uri);
        string name = "war_squad_transactions_" + Guid.NewGuid().ToString("N");
        var context = new Context(client.GetDatabase(name));
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(120));
        try
        {
            await context.Store.Initialize(deadline.Token);
            await new LegacySquadStore(context.Database).Initialize(deadline.Token);
            await CheckTwoCreationsAsync(context, deadline.Token);
            await CheckNameCollisionAsync(context, deadline.Token);
            await CheckCompetingJoinsAsync(context, deadline.Token);
            await CheckCompetingAcceptsAsync(context, deadline.Token);
            await CheckTransferAgainstKickAsync(context, deadline.Token);
            await CheckFailureBoundariesAsync(context, deadline.Token);
            await CheckTransferFailureBoundariesAsync(context, deadline.Token);
            Console.WriteLine("PASS: 5 forced squad races and 13 publication-boundary rollback scenarios");
        }
        finally
        {
            await client.DropDatabaseAsync(name, CancellationToken.None);
        }
    }

    private static async Task CheckTwoCreationsAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument actor = SquadTestFixture.Player();
        await context.InsertPlayerAsync(actor, cancellationToken);
        var first = new Attempt(actor.Id, SquadTestFixture.Creation(SquadTestFixture.Name()));
        var second = new Attempt(actor.Id, SquadTestFixture.Creation(SquadTestFixture.Name()));
        Competition competition = await context.CompeteAsync(first, second, cancellationToken);
        RequireOneWinner(competition);
        LegacyPlayerDocument saved = await context.ReadPlayerAsync(actor.Id, cancellationToken);
        Require(saved.WarBucks == actor.WarBucks - SquadTestFixture.CreationPrice && saved.SquadCreationsCount == 1,
            "Two creations must charge and increment exactly once.");
        long squads = await context.Squads.CountDocumentsAsync(row => row.Id == first.Command.SquadId ||
            row.Id == second.Command.SquadId, cancellationToken: cancellationToken);
        Require(squads == 1, "A losing creation left an orphaned squad.");
    }

    private static async Task CheckNameCollisionAsync(Context context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument first = SquadTestFixture.Player();
        LegacyPlayerDocument second = SquadTestFixture.Player();
        await context.InsertPlayerAsync(first, cancellationToken);
        await context.InsertPlayerAsync(second, cancellationToken);
        LegacySquadCommand command = SquadTestFixture.Creation(SquadTestFixture.Name());
        Competition competition = await context.CompeteAsync(new Attempt(first.Id, command),
            new Attempt(second.Id, command), cancellationToken);
        RequireOneWinner(competition);
        Require(competition.Results.Any(result => result.Result == 3701), "The losing name claim must report taken.");
        LegacyPlayerDocument[] players = [await context.ReadPlayerAsync(first.Id, cancellationToken),
            await context.ReadPlayerAsync(second.Id, cancellationToken)];
        Require(players.Sum(player => player.SquadCreationsCount) == 1 &&
            players.Sum(player => player.WarBucks) == first.WarBucks + second.WarBucks - SquadTestFixture.CreationPrice,
            "Name collision must not charge the loser.");
    }

    private static async Task CheckCompetingJoinsAsync(Context context, CancellationToken cancellationToken)
    {
        LegacySquadSnapshot first = SquadTestFixture.Create();
        LegacySquadSnapshot second = SquadTestFixture.Create();
        LegacyPlayerDocument joining = SquadTestFixture.Player();
        await context.SeedAsync(first, cancellationToken);
        await context.SeedAsync(second, cancellationToken);
        await context.InsertPlayerAsync(joining, cancellationToken);
        LegacySquadCommand Join(string squadId) => new()
        {
            Action = DatabaseAction.JoinSquad,
            NowUnixSeconds = SquadTestFixture.Now,
            SquadId = squadId
        };
        Competition competition = await context.CompeteAsync(new Attempt(joining.Id, Join(first.Squad!.Id)),
            new Attempt(joining.Id, Join(second.Squad!.Id)), cancellationToken);
        Require(competition.Calculations >= 3 && competition.Results.All(result => result.Result == 1),
            "Distinct joins must linearize as admission then an atomic non-Leader transfer.");
        long memberships = await context.Squads.CountDocumentsAsync(
            Builders<LegacySquadDocument>.Filter.ElemMatch(row => row.Members, member => member.PlayerId == joining.Id),
            cancellationToken: cancellationToken);
        LegacyPlayerDocument saved = await context.ReadPlayerAsync(joining.Id, cancellationToken);
        Require(memberships == 1 && saved.SquadId.Length > 0, "Concurrent joins placed one account in two rosters.");
    }

    private static async Task CheckCompetingAcceptsAsync(Context context, CancellationToken cancellationToken)
    {
        LegacySquadSnapshot first = SquadTestFixture.Create();
        LegacySquadSnapshot second = SquadTestFixture.Create();
        LegacyPlayerDocument joining = SquadTestFixture.Player();
        first.Squad!.PendingRequests.Add(joining.Id);
        second.Squad!.PendingRequests.Add(joining.Id);
        await context.SeedAsync(first, cancellationToken);
        await context.SeedAsync(second, cancellationToken);
        await context.InsertPlayerAsync(joining, cancellationToken);
        LegacySquadCommand Accept(LegacySquadSnapshot snapshot) => new()
        {
            Action = DatabaseAction.AcceptSquadJoinRequest,
            NowUnixSeconds = SquadTestFixture.Now,
            SquadId = snapshot.Squad!.Id,
            TargetId = joining.Id
        };
        Competition competition = await context.CompeteAsync(new Attempt(first.Actor.Id, Accept(first)),
            new Attempt(second.Actor.Id, Accept(second)), cancellationToken);
        Require(competition.Calculations >= 3 && competition.Results.All(result => result.Result == 1),
            "Distinct approvals must linearize without duplicating the admitted player's membership.");
        long memberships = await context.Squads.CountDocumentsAsync(
            Builders<LegacySquadDocument>.Filter.ElemMatch(row => row.Members, member => member.PlayerId == joining.Id),
            cancellationToken: cancellationToken);
        Require(memberships == 1, "Competing approvals overwrote an already admitted account's pointer.");
    }

    private static async Task CheckTransferAgainstKickAsync(Context context, CancellationToken cancellationToken)
    {
        LegacySquadSnapshot snapshot = SquadTestFixture.Create();
        snapshot.Target!.SquadRank = 3;
        snapshot.Squad!.Members[1].Rank = 3;
        LegacyPlayerDocument kicker = SquadTestFixture.Player();
        kicker.SquadId = snapshot.Squad.Id;
        kicker.SquadRank = 3;
        snapshot.Squad.Members.Add(new LegacySquadMember { PlayerId = kicker.Id, Rank = 3 });
        await context.SeedAsync(snapshot, cancellationToken);
        await context.InsertPlayerAsync(kicker, cancellationToken);
        LegacySquadCommand transfer = SquadTestFixture.Command(DatabaseAction.PromotePlayerToFounder, snapshot);
        LegacySquadCommand kick = SquadTestFixture.Command(DatabaseAction.KickPlayer, snapshot);
        Competition competition = await context.CompeteAsync(new Attempt(snapshot.Actor.Id, transfer),
            new Attempt(kicker.Id, kick), cancellationToken);
        RequireOneWinner(competition);
        LegacySquadDocument squad = await context.Squads.Find(row => row.Id == snapshot.Squad.Id)
            .SingleAsync(cancellationToken);
        Require(squad.Members.Count(member => member.Rank == 2) == 1, "Leadership race must preserve one Leader.");
        foreach (LegacySquadMember member in squad.Members)
        {
            LegacyPlayerDocument player = await context.ReadPlayerAsync(member.PlayerId, cancellationToken);
            Require(player.SquadId == squad.Id && player.SquadRank == member.Rank,
                "A leadership race committed inconsistent account/roster rank mirrors.");
        }
    }

    private static async Task CheckFailureBoundariesAsync(Context context, CancellationToken cancellationToken)
    {
        DatabaseAction[] actions = [DatabaseAction.CreateSquad, DatabaseAction.JoinSquad,
            DatabaseAction.AcceptSquadJoinRequest, DatabaseAction.LeaveSquad, DatabaseAction.PromotePlayer,
            DatabaseAction.DemotePlayer, DatabaseAction.PromotePlayerToFounder, DatabaseAction.KickPlayer];
        foreach (DatabaseAction action in actions)
        {
            RollbackCase scenario = await CreateRollbackCaseAsync(context, action, cancellationToken);
            await CheckRollbackAsync(context, scenario, cancellationToken);
        }

        RollbackCase secondPlayer = await CreateRollbackCaseAsync(context,
            DatabaseAction.PromotePlayerToFounder, cancellationToken);
        await CheckRollbackAsync(context, secondPlayer with { RejectedPlayerId = secondPlayer.ActorId },
            cancellationToken);
    }

    private static async Task<RollbackCase> CreateRollbackCaseAsync(
        Context context, DatabaseAction action, CancellationToken cancellationToken)
    {
        LegacySquadSnapshot snapshot = SquadTestFixture.Create();
        if (action == DatabaseAction.CreateSquad)
        {
            LegacyPlayerDocument actor = SquadTestFixture.Player();
            await context.InsertPlayerAsync(actor, cancellationToken);
            return new RollbackCase(actor.Id, actor.Id, SquadTestFixture.Creation(SquadTestFixture.Name()));
        }

        if (action is DatabaseAction.JoinSquad or DatabaseAction.AcceptSquadJoinRequest)
        {
            snapshot.Target!.SquadId = "";
            snapshot.Target.SquadRank = -1;
            snapshot.Squad!.Members.RemoveAt(1);
            snapshot.Squad.PendingRequests.Add(snapshot.Target.Id);
        }
        else if (action == DatabaseAction.LeaveSquad)
        {
            snapshot.Squad!.Members.RemoveAt(1);
            snapshot = snapshot with { Target = null, TargetMemberships = [] };
        }
        else if (action == DatabaseAction.DemotePlayer)
        {
            snapshot.Target!.SquadRank = 1;
            snapshot.Squad!.Members[1].Rank = 1;
        }

        await context.SeedAsync(snapshot, cancellationToken);
        string actorId = action == DatabaseAction.JoinSquad ? snapshot.Target!.Id : snapshot.Actor.Id;
        string rejectedId = snapshot.Target?.Id ?? snapshot.Actor.Id;
        LegacySquadCommand command = SquadTestFixture.Command(action, snapshot) with
        {
            SquadId = action is DatabaseAction.JoinSquad or DatabaseAction.AcceptSquadJoinRequest
                ? snapshot.Squad!.Id : null,
            TargetId = action is DatabaseAction.JoinSquad or DatabaseAction.LeaveSquad ? null : snapshot.Target?.Id
        };
        return new RollbackCase(actorId, rejectedId, command);
    }

    private static async Task CheckTransferFailureBoundariesAsync(Context context, CancellationToken cancellationToken)
    {
        DatabaseAction[] actions = [DatabaseAction.JoinSquad, DatabaseAction.AcceptSquadJoinRequest];
        foreach (DatabaseAction action in actions)
        {
            LegacySquadSnapshot source = SquadTestFixture.Create();
            LegacySquadSnapshot destination = SquadTestFixture.Create();
            destination.Squad!.PendingRequests.Add(source.Target!.Id);
            await context.SeedAsync(source, cancellationToken);
            await context.SeedAsync(destination, cancellationToken);
            var command = new LegacySquadCommand
            {
                Action = action,
                NowUnixSeconds = SquadTestFixture.Now,
                SquadId = destination.Squad.Id,
                TargetId = action == DatabaseAction.AcceptSquadJoinRequest ? source.Target.Id : null
            };
            string actorId = action == DatabaseAction.JoinSquad ? source.Target.Id : destination.Actor.Id;
            var scenario = new RollbackCase(actorId, source.Target.Id, command);
            await CheckRollbackAsync(context, scenario, cancellationToken);
            string before = await context.SnapshotAsync(cancellationToken);
            await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
            {
                ["collMod"] = "legacySquads",
                ["validationLevel"] = "strict",
                ["validator"] = new BsonDocument("_id", new BsonDocument("$ne", source.Squad!.Id))
            }, cancellationToken: cancellationToken);
            bool hasRejected = false;
            try
            {
                await context.ApplyAsync(new Attempt(actorId, command), cancellationToken);
            }
            catch (MongoWriteException)
            {
                hasRejected = true;
            }
            finally
            {
                await context.Database.RunCommandAsync<BsonDocument>(new BsonDocument
                {
                    ["collMod"] = "legacySquads",
                    ["validator"] = new BsonDocument()
                }, cancellationToken: cancellationToken);
            }

            Require(hasRejected && before == await context.SnapshotAsync(cancellationToken),
                "A previous-roster write failure must roll back the destination roster too: " + action);
        }
    }

    private static async Task CheckRollbackAsync(
        Context context, RollbackCase scenario, CancellationToken cancellationToken)
    {
        string before = await context.SnapshotAsync(cancellationToken);
        await context.SetValidatorAsync(new BsonDocument("_id", new BsonDocument("$ne", scenario.RejectedPlayerId)),
            cancellationToken);
        bool hasRejected = false;
        try
        {
            await context.ApplyAsync(new Attempt(scenario.ActorId, scenario.Command), cancellationToken);
        }
        catch (MongoWriteException)
        {
            hasRejected = true;
        }
        finally
        {
            await context.SetValidatorAsync(new BsonDocument(), cancellationToken);
        }

        string after = await context.SnapshotAsync(cancellationToken);
        Require(hasRejected && before == after,
            "Publication failure leaked a partial squad/account write: " + scenario.Command.Action);
    }

    private static void RequireOneWinner(Competition competition) =>
        Require(competition.Calculations >= 3 && competition.Results.Count(result => result.Result == 1) == 1,
            "Forced competing snapshots must recalculate and produce exactly one successful transition.");

    private static void Require(bool condition, string message) => SquadTestFixture.Require(condition, message);

    private sealed record Attempt(string ActorId, LegacySquadCommand Command);

    private sealed record Competition(LegacySquadResult[] Results, int Calculations);

    private sealed record RollbackCase(string ActorId, string RejectedPlayerId, LegacySquadCommand Command);

    private sealed class Context(IMongoDatabase database)
    {
        internal IMongoDatabase Database { get; } = database;

        internal LegacyPlayerStore Store { get; } = new(database);

        internal IMongoCollection<LegacySquadDocument> Squads { get; } =
            database.GetCollection<LegacySquadDocument>("legacySquads");

        private LegacySquadRules Rules { get; } = new(new LegacySquadPolicy(SquadTestFixture.CreationPrice));

        internal async Task SeedAsync(LegacySquadSnapshot snapshot, CancellationToken cancellationToken)
        {
            await InsertPlayerAsync(snapshot.Actor, cancellationToken);
            if (snapshot.Target != null)
            {
                await InsertPlayerAsync(snapshot.Target, cancellationToken);
            }

            await Squads.InsertOneAsync(snapshot.Squad!, cancellationToken: cancellationToken);
        }

        internal Task InsertPlayerAsync(LegacyPlayerDocument player, CancellationToken cancellationToken) =>
            Database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
                .InsertOneAsync(player, cancellationToken: cancellationToken);

        internal async Task<LegacyPlayerDocument> ReadPlayerAsync(string id, CancellationToken cancellationToken) =>
            await Store.ById(id, cancellationToken) ?? throw new InvalidDataException("Missing squad fixture player.");

        internal Task<LegacySquadResult> ApplyAsync(Attempt attempt, CancellationToken cancellationToken) =>
            Store.ApplySquadAsync(new LegacySquadOperation(attempt.ActorId,
                attempt.Command.TargetId, attempt.Command.SquadId),
                snapshot => Rules.Calculate(snapshot, attempt.Command), cancellationToken);

        internal async Task<Competition> CompeteAsync(
            Attempt first, Attempt second, CancellationToken cancellationToken)
        {
            using var readers = new Barrier(2);
            int calculations = 0;
            Task<LegacySquadResult> Apply(Attempt attempt) => Task.Run(() => Store.ApplySquadAsync(
                new LegacySquadOperation(attempt.ActorId, attempt.Command.TargetId, attempt.Command.SquadId),
                snapshot =>
                {
                    if (Interlocked.Increment(ref calculations) <= 2)
                    {
                        Require(readers.SignalAndWait(TimeSpan.FromSeconds(5), cancellationToken),
                            "Missing race reader.");
                    }

                    return Rules.Calculate(snapshot, attempt.Command);
                }, cancellationToken));
            LegacySquadResult[] results = await Task.WhenAll(Apply(first), Apply(second));
            return new Competition(results, calculations);
        }

        internal Task<BsonDocument> SetValidatorAsync(BsonDocument validator, CancellationToken cancellationToken) =>
            Database.RunCommandAsync<BsonDocument>(new BsonDocument
            {
                ["collMod"] = "legacyPlayers",
                ["validator"] = validator,
                ["validationLevel"] = "strict"
            }, cancellationToken: cancellationToken);

        internal async Task<string> SnapshotAsync(CancellationToken cancellationToken)
        {
            List<BsonDocument> players = await Database.GetCollection<BsonDocument>("legacyPlayers")
                .Find(FilterDefinition<BsonDocument>.Empty).Sort(Builders<BsonDocument>.Sort.Ascending("_id"))
                .ToListAsync(cancellationToken);
            List<BsonDocument> squads = await Database.GetCollection<BsonDocument>("legacySquads")
                .Find(FilterDefinition<BsonDocument>.Empty).Sort(Builders<BsonDocument>.Sort.Ascending("_id"))
                .ToListAsync(cancellationToken);
            return new BsonArray(players).ToJson() + new BsonArray(squads).ToJson();
        }
    }
}
