using MongoDB.Driver;

namespace War.Persistence;

public sealed partial class BattleRematchConsentStore
{
    private async Task ReserveAccountRevisionsAsync(IClientSessionHandle session, BattleRematchReservation request,
        string[] playerIds, CancellationToken cancellationToken)
    {
        if (request.PreparedManifest == null)
        {
            return;
        }
        IReadOnlyList<BattleAccountRevision> revisions = ValidateAccountRevisionProof(request, playerIds);

        var players = _consents.Database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        foreach (BattleAccountRevision expected in revisions)
        {
            // This real write conflicts with equipment changes after the manifest's account read.
            UpdateResult reserved = await players.UpdateOneAsync(session,
                row => row.Id == expected.PlayerId && row.Revision == expected.Revision,
                Builders<LegacyPlayerDocument>.Update.Inc(row => row.Revision, 1L),
                cancellationToken: cancellationToken);
            if (reserved.ModifiedCount != 1)
            {
                throw new InvalidDataException("Prepared rematch account changed before reservation.");
            }
        }
    }

    private static IReadOnlyList<BattleAccountRevision> ValidateAccountRevisionProof(
        BattleRematchReservation request, string[] playerIds)
    {
        IReadOnlyList<BattleAccountRevision> revisions = request.ExpectedAccountRevisions
            ?? throw new InvalidDataException("Prepared rematch account revision proof is absent.");
        if (revisions.Count != playerIds.Length || !revisions.Select(row => row.PlayerId).SequenceEqual(playerIds) ||
            revisions.Any(row => row.Revision < 1 || row.Revision == long.MaxValue))
        {
            throw new InvalidDataException("Prepared rematch account revision proof differs from its roster.");
        }
        return revisions;
    }
}
