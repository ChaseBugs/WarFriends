using MongoDB.Driver;
using War.BattleServer;
using War.Protocol;

namespace War.Persistence;

public sealed partial class BattleGrantStore
{
    /// <summary>Publishes only while the exact allocator pair remains uncancelled in the same transaction.</summary>
    public async Task<string> PublishForActivePairAsync(
        string matchId,
        string manifestHash,
        IEnumerable<MatchConnectionGrant> values,
        CancellationToken cancellationToken)
    {
        var document = CreateDocument(matchId, manifestHash, values);
        using var session = await _client.StartSessionAsync(cancellationToken: cancellationToken);
        var transaction = new TransactionOptions(
            readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority);
        return await session.WithTransactionAsync(async (current, token) =>
        {
            var pairs = _database.GetCollection<BattlePairDocument>("battle_pairs");
            var pair = await pairs.Find(current, row => row.MatchId == matchId).FirstOrDefaultAsync(token);
            if (pair == null)
            {
                return "cancelled";
            }

            var validated = BattleMatchQueueStore.ValidatePairDocument(pair);
            if (pair.Cancellation != null)
            {
                return "cancelled";
            }

            if (!validated.Players!.SequenceEqual(new[] { document.PlayerA, document.PlayerB }))
            {
                throw new InvalidDataException("Grant publication roster differs from its durable pair.");
            }

            await ValidateFrozenGrantAsync(current, pair, document, token);
            await TouchPublicationPairAsync(current, pair, token);
            return await PublishDocumentAsync(current, document, token);
        }, transaction, cancellationToken);
    }

    private async Task ValidateFrozenGrantAsync(
        IClientSessionHandle session, BattlePairDocument pair, BattleGrantDocument document, CancellationToken cancellationToken)
    {
        var snapshots = _database.GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots");
        var snapshot = await snapshots.Find(session, row => row.Id == pair.MatchId)
            .FirstOrDefaultAsync(cancellationToken) ??
            throw new InvalidDataException("Active pair has no frozen manifest.");
        byte[] frozen = BattleManifestSnapshotStore.Validate(snapshot, pair.MatchId, pair.Players);
        RequireMatchingMap(document, MatchManifest.Parse(frozen));
    }

    private async Task TouchPublicationPairAsync(
        IClientSessionHandle session, BattlePairDocument pair, CancellationToken cancellationToken)
    {
        if (pair.GrantPublicationRevision >= long.MaxValue - 1)
        {
            throw new InvalidDataException("Grant publication revision is exhausted.");
        }

        // A read alone permits write skew. Touch the pair so cancellation/removal serializes with publication.
        var pairs = _database.GetCollection<BattlePairDocument>("battle_pairs");
        var updated = await pairs.UpdateOneAsync(session, row => row.Id == pair.Id && row.MatchId == pair.MatchId,
            Builders<BattlePairDocument>.Update.Inc(row => row.GrantPublicationRevision, 1L),
            cancellationToken: cancellationToken);
        if (updated.ModifiedCount != 1)
        {
            throw new InvalidDataException("Grant publication lost its pair authority.");
        }
    }

    private async Task<string> PublishDocumentAsync(
        IClientSessionHandle session, BattleGrantDocument document, CancellationToken cancellationToken)
    {
        var existing = await grants.Find(session, row => row.MatchId == document.MatchId)
            .FirstOrDefaultAsync(cancellationToken);
        if (existing != null)
        {
            _ = ValidateDocument(existing);
            return Same(existing, document) ? "already-published" : "conflict";
        }

        await grants.InsertOneAsync(session, document, cancellationToken: cancellationToken);
        return "published";
    }
}
