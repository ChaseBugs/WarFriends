using MongoDB.Driver;
using War.BattleServer;

namespace War.Persistence;

public sealed partial class BattleResultStore
{
    /// <summary>Stores terminal evidence and removes its allocation in one atomic publication.</summary>
    public async Task<string> AcceptAndReleasePairAsync(
        string matchId, string digest, byte[] payload, CancellationToken cancellationToken)
    {
        var terminal = TerminalOutbox.ValidatePayload(payload, matchId, digest);
        using var session = await _client.StartSessionAsync(cancellationToken: cancellationToken);
        var transaction = new TransactionOptions(
            readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority);
        return await session.WithTransactionAsync(async (current, token) =>
        {
            var pairs = _database.GetCollection<BattlePairDocument>("battle_pairs");
            var pair = await pairs.Find(current, row => row.MatchId == matchId).FirstOrDefaultAsync(token);
            var previous = await results.Find(current, row => row.MatchId == matchId).FirstOrDefaultAsync(token);
            if (previous != null)
            {
                Validate(previous, matchId, DateTime.UtcNow);
                if (previous.Digest != digest || !previous.Snapshot.AsSpan().SequenceEqual(payload))
                {
                    return "conflict";
                }
            }

            if (pair == null)
            {
                return previous != null ? "already-accepted" :
                    throw new InvalidDataException("Backend-allocated result has no durable pair.");
            }

            MatchManifest manifest = await ValidateTerminalPairAsync(current, pair, terminal, token);
            if (previous == null)
            {
                await ConsumeOrdinaryCardsAsync(current, manifest, terminal, token);
                var document = new BattleResultDocument
                {
                    Id = Guid.NewGuid().ToString("N"),
                    MatchId = matchId,
                    Digest = digest,
                    Snapshot = payload.ToArray(),
                    AcceptedUtc = DateTime.UtcNow,
                    TerminalPhase = terminal.Phase,
                };
                await results.InsertOneAsync(current, document, cancellationToken: token);
            }

            // Deleting the same pair that grant publication writes prevents snapshot write skew.
            var deleted = await pairs.DeleteOneAsync(current,
                row => row.Id == pair.Id && row.MatchId == matchId, cancellationToken: token);
            if (deleted.DeletedCount != 1)
            {
                throw new InvalidDataException("Terminal acceptance lost its allocation authority.");
            }

            return previous == null ? "accepted" : "already-accepted";
        }, transaction, cancellationToken);
    }

    private async Task<MatchManifest> ValidateTerminalPairAsync(
        IClientSessionHandle session, BattlePairDocument pair,
        War.Protocol.MatchSnapshot terminal, CancellationToken cancellationToken)
    {
        var validated = BattleMatchQueueStore.ValidatePairDocument(pair);
        if (!terminal.Players.Select(player => player.PlayerId).SequenceEqual(validated.Players!))
        {
            throw new InvalidDataException("Terminal player roster differs from durable pair.");
        }

        var snapshots = _database.GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots");
        var snapshot = await snapshots.Find(session, row => row.Id == pair.MatchId)
            .FirstOrDefaultAsync(cancellationToken) ??
            throw new InvalidDataException("Paired match has no frozen manifest.");
        byte[] frozen = BattleManifestSnapshotStore.Validate(snapshot, pair.MatchId, pair.Players);
        var manifest = MatchManifest.Parse(frozen);
        if (manifest.Digest() != terminal.ManifestHash)
        {
            throw new InvalidDataException("Terminal proof differs from frozen match authority.");
        }

        PvpBonusCurrencyManifestValidator.Validate(terminal, manifest);
        return manifest;
    }
}
