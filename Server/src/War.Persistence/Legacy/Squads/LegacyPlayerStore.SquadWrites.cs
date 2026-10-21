using MongoDB.Driver;
using War.Persistence.Legacy.Squads;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private async Task WriteSquadMutationAsync(
        IClientSessionHandle session,
        LegacySquadSnapshot snapshot,
        LegacySquadMutation mutation,
        CancellationToken cancellationToken)
    {
        if (mutation.IsCreation)
        {
            await Squads.InsertOneAsync(session, mutation.Squad!, cancellationToken: cancellationToken);
        }
        else if (mutation.IsDeletion)
        {
            DeleteResult deleted = await Squads.DeleteOneAsync(session,
                row => row.Id == snapshot.Squad!.Id && row.Revision == snapshot.Squad.Revision,
                cancellationToken: cancellationToken);
            RequireSquadWrite(deleted.DeletedCount);
        }
        else
        {
            ReplaceOneResult replaced = await Squads.ReplaceOneAsync(session,
                row => row.Id == snapshot.Squad!.Id && row.Revision == snapshot.Squad.Revision,
                mutation.Squad!, cancellationToken: cancellationToken);
            RequireSquadWrite(replaced.ModifiedCount);
        }

        if (mutation.OtherSquad != null)
        {
            ReplaceOneResult replaced = await Squads.ReplaceOneAsync(session,
                row => row.Id == snapshot.OtherSquad!.Id && row.Revision == snapshot.OtherSquad.Revision,
                mutation.OtherSquad, cancellationToken: cancellationToken);
            RequireSquadWrite(replaced.ModifiedCount);
        }

        foreach (LegacySquadPlayerChange change in mutation.Players)
        {
            await WriteSquadPlayerAsync(session, change, cancellationToken);
        }
    }

    private async Task WriteSquadPlayerAsync(
        IClientSessionHandle session, LegacySquadPlayerChange change, CancellationToken cancellationToken)
    {
        var update = Builders<LegacyPlayerDocument>.Update.Set(row => row.SquadId, change.SquadId)
            .Set(row => row.SquadRank, change.Rank).Inc(row => row.Revision, 1);
        if (change.WarBucks != null)
        {
            update = update.Set(row => row.WarBucks, change.WarBucks.Value)
                .Set(row => row.SquadCreationsCount, change.CreationsCount!.Value);
        }

        UpdateResult written = await players.UpdateOneAsync(session,
            row => row.Id == change.PlayerId && row.Revision == change.ExpectedRevision,
            update, cancellationToken: cancellationToken);
        RequireSquadWrite(written.ModifiedCount);
    }

    private static void RequireSquadWrite(long changedCount)
    {
        if (changedCount != 1)
        {
            throw new InvalidDataException("Squad publication lost its transaction snapshot.");
        }
    }

    private static void ValidateSquadMutation(LegacySquadSnapshot snapshot, LegacySquadMutation mutation)
    {
        if (mutation.Result <= 0 || mutation.Result is > 1 and <= 10 ||
            mutation.IsCreation && mutation.IsDeletion || mutation.Players.Count > 2)
        {
            throw new InvalidDataException("Invalid squad mutation outcome.");
        }

        if (mutation.Result != SquadSuccess)
        {
            if (mutation.Squad != null || mutation.OtherSquad != null || mutation.Players.Count != 0 ||
                mutation.IsCreation || mutation.IsDeletion)
            {
                throw new InvalidDataException("A failed squad transition cannot carry writes.");
            }

            return;
        }

        ValidateSquadWriteIdentity(snapshot, mutation);
        if (mutation.OtherSquad != null && (snapshot.OtherSquad == null ||
            snapshot.OtherSquad.Revision < 0 || snapshot.OtherSquad.Revision == long.MaxValue ||
            mutation.IsCreation || mutation.IsDeletion || mutation.OtherSquad.Id != snapshot.OtherSquad.Id ||
            mutation.OtherSquad.Revision != snapshot.OtherSquad.Revision + 1))
        {
            throw new InvalidDataException("Invalid previous-squad transfer identity.");
        }
        var seen = new HashSet<string>(StringComparer.Ordinal);
        foreach (LegacySquadPlayerChange change in mutation.Players)
        {
            LegacyPlayerDocument? original = change.PlayerId == snapshot.Actor.Id ? snapshot.Actor : snapshot.Target;
            if (original == null || original.Id != change.PlayerId || !seen.Add(change.PlayerId) ||
                original.Revision < 0 || original.Revision == long.MaxValue ||
                change.ExpectedRevision != original.Revision || change.Rank is < -1 or > 3 ||
                change.SquadId.Length == 0 && change.Rank != -1 ||
                change.SquadId.Length > 0 && change.Rank < 0 ||
                change.WarBucks.HasValue != change.CreationsCount.HasValue ||
                change.WarBucks is < 0 || change.CreationsCount is < 0)
            {
                throw new InvalidDataException("Invalid squad account mutation.");
            }
        }
    }

    private static void ValidateSquadWriteIdentity(LegacySquadSnapshot snapshot, LegacySquadMutation mutation)
    {
        if (mutation.IsCreation)
        {
            if (snapshot.Squad != null || mutation.Squad == null || mutation.Squad.Revision != 1)
            {
                throw new InvalidDataException("Invalid squad creation identity.");
            }

            return;
        }

        if (snapshot.Squad == null || snapshot.Squad.Revision < 0 || snapshot.Squad.Revision == long.MaxValue ||
            !mutation.IsDeletion && (mutation.Squad == null || mutation.Squad.Id != snapshot.Squad.Id ||
                mutation.Squad.Revision != snapshot.Squad.Revision + 1))
        {
            throw new InvalidDataException("Invalid squad transition revision.");
        }
    }
}
