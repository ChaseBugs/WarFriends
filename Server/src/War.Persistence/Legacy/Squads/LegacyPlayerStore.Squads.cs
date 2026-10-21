using MongoDB.Driver;
using War.Persistence.Legacy.Squads;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int SquadSuccess = 1;
    private const int SquadDeadlineSeconds = 30;
    private const int SquadDuplicateRetries = 4;
    private const int MembershipProofLimit = 2;

    private static readonly TransactionOptions SquadTransactionOptions = new(
        readConcern: ReadConcern.Snapshot,
        readPreference: ReadPreference.Primary,
        writeConcern: WriteConcern.WMajority);

    private IMongoCollection<LegacySquadDocument> Squads =>
        players.Database.GetCollection<LegacySquadDocument>("legacySquads");

    /// <summary>Re-reads and commits all membership, role and creation-economy changes together.</summary>
    public async Task<LegacySquadResult> ApplySquadAsync(
        LegacySquadOperation operation,
        Func<LegacySquadSnapshot, LegacySquadMutation> calculate,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(operation.ActorId))
        {
            throw new InvalidDataException("Missing squad actor.");
        }

        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        deadline.CancelAfter(TimeSpan.FromSeconds(SquadDeadlineSeconds));
        for (int attempt = 0; ; attempt++)
        {
            using IClientSessionHandle session = await players.Database.Client.StartSessionAsync(
                cancellationToken: deadline.Token);
            try
            {
                return await session.WithTransactionAsync((transaction, token) =>
                    ApplySquadTransactionAsync(transaction, new SquadExecution(operation, calculate), token),
                    SquadTransactionOptions, deadline.Token);
            }
            catch (MongoWriteException exception) when (
                exception.WriteError.Category == ServerErrorCategory.DuplicateKey && attempt < SquadDuplicateRetries)
            {
                // A competing creation may have claimed the name; recalculate against its commit.
            }
        }
    }

    private async Task<LegacySquadResult> ApplySquadTransactionAsync(
        IClientSessionHandle session, SquadExecution execution, CancellationToken cancellationToken)
    {
        LegacySquadSnapshot snapshot = await ReadSquadSnapshotAsync(session, execution.Operation, cancellationToken);
        LegacySquadMutation mutation = execution.Calculate(snapshot);
        ValidateSquadMutation(snapshot, mutation);
        if (mutation.Result == SquadSuccess)
        {
            await WriteSquadMutationAsync(session, snapshot, mutation, cancellationToken);
        }

        LegacyPlayerDocument actor = await players.Find(session, row => row.Id == snapshot.Actor.Id)
            .SingleAsync(cancellationToken);
        LegacyPlayerDocument? target = snapshot.Target == null ? null :
            await players.Find(session, row => row.Id == snapshot.Target.Id).SingleAsync(cancellationToken);
        LegacySquadDocument? squad = mutation.Result == SquadSuccess ? mutation.Squad : snapshot.Squad;
        return new LegacySquadResult(mutation.Result, actor, target, mutation.IsDeletion ? null : squad);
    }

    private async Task<LegacySquadSnapshot> ReadSquadSnapshotAsync(
        IClientSessionHandle session, LegacySquadOperation operation, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument actor = await players.Find(session, row => row.Id == operation.ActorId)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidDataException("Squad actor disappeared.");
        LegacyPlayerIdentityAuthority.Validate(actor);
        LegacyPlayerEconomyAuthority.Validate(actor);
        LegacyPlayerDocument? target = null;
        if (operation.TargetId != null && operation.TargetId != actor.Id)
        {
            target = await players.Find(session, row => row.Id == operation.TargetId)
                .FirstOrDefaultAsync(cancellationToken);
            if (target != null)
            {
                LegacyPlayerIdentityAuthority.Validate(target);
                LegacyPlayerEconomyAuthority.Validate(target);
            }
        }

        string squadId = operation.SquadId ?? actor.SquadId;
        LegacySquadDocument? squad = string.IsNullOrEmpty(squadId) ? null :
            await Squads.Find(session, row => row.Id == squadId).FirstOrDefaultAsync(cancellationToken);
        string? otherId = actor.SquadId.Length > 0 && actor.SquadId != squadId ? actor.SquadId :
            target != null && target.SquadId.Length > 0 && target.SquadId != squadId ? target.SquadId : null;
        LegacySquadDocument? other = otherId == null ? null :
            await Squads.Find(session, row => row.Id == otherId).FirstOrDefaultAsync(cancellationToken);
        return new LegacySquadSnapshot
        {
            Actor = actor,
            Target = target,
            Squad = squad,
            OtherSquad = other,
            ActorMemberships = await FindMembershipsAsync(session, actor.Id, cancellationToken),
            TargetMemberships = target == null ? [] :
                await FindMembershipsAsync(session, target.Id, cancellationToken)
        };
    }

    private Task<List<string>> FindMembershipsAsync(
        IClientSessionHandle session, string playerId, CancellationToken cancellationToken) =>
        Squads.Find(session, Builders<LegacySquadDocument>.Filter
                .ElemMatch(row => row.Members, member => member.PlayerId == playerId))
            .Project(row => row.Id).Limit(MembershipProofLimit).ToListAsync(cancellationToken);

    private sealed record SquadExecution(
        LegacySquadOperation Operation, Func<LegacySquadSnapshot, LegacySquadMutation> Calculate);
}
