using System.Numerics;

namespace War.BattleServer;

public sealed record SnapshotEntity(ulong EntityId, Vector3 Position, ulong Revision);

public sealed class SnapshotBaseline
{
    private readonly Dictionary<ulong, SnapshotEntity> entities = [];
    private IReadOnlyList<ulong> removedEntityIds = Array.Empty<ulong>();

    public ulong Revision { get; private set; }
    public IReadOnlyList<ulong> RemovedEntityIds => removedEntityIds;
    public IReadOnlyList<SnapshotEntity> Entities => Array.AsReadOnly(
        entities.Values.OrderBy(entity => entity.EntityId).ToArray());

    /// <summary>Replace the complete entity roster for one newer revision.</summary>
    public IReadOnlyList<SnapshotEntity> Apply(ulong revision, IEnumerable<SnapshotEntity> incoming)
    {
        if (revision <= Revision || revision > 10_000_000)
            throw new InvalidDataException("Snapshot revision is stale or out of range.");
        var rows = (incoming ?? throw new ArgumentNullException(nameof(incoming))).ToArray();
        if (rows.Length > 4096)
            throw new InvalidDataException("Snapshot is too large.");

        var nextEntities = new Dictionary<ulong, SnapshotEntity>();
        foreach (var row in rows)
        {
            if (row.EntityId == 0 || !PlayerHitbox.Finite(row.Position) ||
                row.Revision != revision || !nextEntities.TryAdd(row.EntityId, row))
                throw new InvalidDataException("Invalid snapshot entity.");
        }

        var changed = new List<SnapshotEntity>();
        foreach (var row in rows)
        {
            if (!entities.TryGetValue(row.EntityId, out var prior) || prior.Position != row.Position)
                changed.Add(row);
        }
        var removed = entities.Keys.Where(id => !nextEntities.ContainsKey(id))
            .OrderBy(id => id).ToArray();

        // Publish only after the entire replacement and its removals validate.
        entities.Clear();
        foreach (var pair in nextEntities)
            entities.Add(pair.Key, pair.Value);
        removedEntityIds = Array.AsReadOnly(removed);
        Revision = revision;
        return changed;
    }
}
