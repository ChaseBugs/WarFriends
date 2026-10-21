using MongoDB.Driver;
using War.Persistence.Legacy.Cards;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private async Task WriteCardPoolTransferAsync(
        IClientSessionHandle session,
        LegacyCardPoolSnapshot snapshot,
        LegacyCardPoolMutation mutation,
        CancellationToken cancellationToken)
    {
        var actorUpdate = Builders<LegacyPlayerDocument>.Update
            .Set("Serialized.CardManagerData", mutation.ActorCards).Inc(row => row.Revision, 1);
        if (mutation.ActorDeposits != null)
        {
            actorUpdate = actorUpdate.Set(row => row.DepositedCards,
                new Dictionary<string, int>(mutation.ActorDeposits, StringComparer.Ordinal));
        }

        UpdateResult actorWrite = await players.UpdateOneAsync(session,
            row => row.Id == snapshot.Actor.Id && row.Revision == snapshot.Actor.Revision,
            actorUpdate, cancellationToken: cancellationToken);
        RequireCardPoolWrite(actorWrite);
        if (mutation.DonorDeposits != null)
        {
            await WriteCardPoolDonorAsync(session, snapshot.Donor!, mutation, cancellationToken);
        }

        if (mutation.NeedsSquadFence)
        {
            await FenceCardPoolSquadAsync(session, snapshot.Squad!, cancellationToken);
        }
    }

    private async Task WriteCardPoolDonorAsync(
        IClientSessionHandle session,
        LegacyPlayerDocument donor,
        LegacyCardPoolMutation mutation,
        CancellationToken cancellationToken)
    {
        if (donor.Revision < 0 || donor.Revision == long.MaxValue)
        {
            throw new InvalidDataException("Invalid donor revision.");
        }

        var update = Builders<LegacyPlayerDocument>.Update
            .Set(row => row.DepositedCards,
                new Dictionary<string, int>(mutation.DonorDeposits!, StringComparer.Ordinal))
            .Set(row => row.Reputation, mutation.DonorReputation!.Value).Inc(row => row.Revision, 1);
        UpdateResult result = await players.UpdateOneAsync(session,
            row => row.Id == donor.Id && row.Revision == donor.Revision, update,
            cancellationToken: cancellationToken);
        RequireCardPoolWrite(result);
    }

    private async Task FenceCardPoolSquadAsync(
        IClientSessionHandle session, LegacySquadDocument squad, CancellationToken cancellationToken)
    {
        if (squad.Revision < 0 || squad.Revision == long.MaxValue)
        {
            throw new InvalidDataException("Invalid card-pool squad revision.");
        }

        UpdateResult result = await players.Database.GetCollection<LegacySquadDocument>("legacySquads")
            .UpdateOneAsync(session, row => row.Id == squad.Id && row.Revision == squad.Revision,
                Builders<LegacySquadDocument>.Update.Inc(row => row.Revision, 1),
                cancellationToken: cancellationToken);
        RequireCardPoolWrite(result);
    }

    private static void RequireCardPoolWrite(UpdateResult result)
    {
        if (result.ModifiedCount != 1)
        {
            throw new InvalidDataException("Card-pool publication lost its transaction snapshot.");
        }
    }
}
