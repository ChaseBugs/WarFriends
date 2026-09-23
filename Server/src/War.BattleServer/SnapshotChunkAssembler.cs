namespace War.BattleServer;

/// <summary>Collects one bounded snapshot revision before it is applied to a baseline.</summary>
public sealed class SnapshotChunkAssembler
{
    private readonly ulong revision;
    private readonly int expectedCount;
    private readonly int maxEntities;
    private readonly SortedDictionary<int, IReadOnlyList<SnapshotEntity>> chunks = [];
    private readonly HashSet<ulong> entityIds = [];
    private int entityCount;

    public SnapshotChunkAssembler(ulong revision, int expectedCount, int maxEntities = 4096)
    {
        if (revision == 0 || expectedCount is < 1 or > 512 || maxEntities is < 1 or > 4096)
            throw new InvalidDataException("Invalid snapshot chunk contract.");
        this.revision = revision;
        this.expectedCount = expectedCount;
        this.maxEntities = maxEntities;
    }

    public bool IsComplete => chunks.Count == expectedCount;
    public int ReceivedChunks => chunks.Count;
    public int ReceivedEntities => entityCount;

    public void Add(int index, IReadOnlyList<SnapshotEntity> rows)
    {
        if (index < 0 || index >= expectedCount || rows is null || rows.Count == 0 || rows.Count > 512)
            throw new InvalidDataException("Invalid snapshot chunk.");
        if (chunks.ContainsKey(index)) throw new InvalidDataException("Duplicate snapshot chunk.");
        if (entityCount + rows.Count > maxEntities) throw new InvalidDataException("Snapshot entity limit exceeded.");
        ulong previous = 0;
        foreach (var row in rows)
        {
            if (row.EntityId == 0 || row.Revision != revision || !PlayerHitbox.Finite(row.Position) ||
                (previous != 0 && row.EntityId <= previous) || entityIds.Contains(row.EntityId))
                throw new InvalidDataException("Invalid snapshot chunk entity.");
            previous = row.EntityId;
        }
        chunks.Add(index, rows);
        foreach (var row in rows) entityIds.Add(row.EntityId);
        entityCount += rows.Count;
    }

    public IReadOnlyList<SnapshotEntity> Complete()
    {
        if (!IsComplete) throw new InvalidDataException("Snapshot is incomplete.");
        return chunks.OrderBy(x => x.Key).SelectMany(x => x.Value).ToArray();
    }

    public IReadOnlyList<SnapshotEntity> ApplyTo(SnapshotBaseline baseline)
    {
        if (baseline is null) throw new ArgumentNullException(nameof(baseline));
        return baseline.Apply(revision, Complete());
    }
}
