using MongoDB.Driver;
using War.BattleServer;

namespace War.Persistence;

public sealed partial class BattleGrantStore
{
    private async Task RequireFrozenMapAsync(BattleGrantDocument document, CancellationToken cancellationToken)
    {
        BattleManifestSnapshotDocument snapshot = await _database
            .GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots")
            .Find(row => row.Id == document.MatchId).FirstOrDefaultAsync(cancellationToken)
            ?? throw new InvalidDataException("The battle grant has no frozen scene authority.");
        byte[] bytes = BattleManifestSnapshotStore.Validate(snapshot, document.MatchId,
            new[] { document.PlayerA, document.PlayerB });
        MatchManifest manifest = MatchManifest.Parse(bytes);
        RequireMatchingMap(document, manifest);
    }

    private static void RequireMatchingMap(BattleGrantDocument document, MatchManifest manifest)
    {
        var grants = ValidateDocument(document);
        if (manifest.Digest() != document.ManifestHash || grants.First.MapId != manifest.MapId ||
            grants.First.MapRevision != manifest.MapRevision)
        {
            throw new InvalidDataException("The battle grant map differs from its frozen manifest.");
        }
    }
}
