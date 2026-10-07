namespace War.BattleServer;

public static class SnapshotChunker
{
    public static IReadOnlyList<IReadOnlyList<SnapshotEntity>> Chunk(
        IEnumerable<SnapshotEntity> entities, int chunkSize = 64)
    {
        if (chunkSize is < 1 or > 512)
            throw new InvalidDataException("Invalid snapshot chunk size.");
        var rows = (entities ?? throw new ArgumentNullException(nameof(entities)))
            .OrderBy(entity => entity.EntityId).ToArray();
        if (rows.Length > 4096)
            throw new InvalidDataException("Snapshot is too large.");
        if (rows.Length > chunkSize * 512)
            throw new InvalidDataException("Snapshot needs more than 512 chunks.");

        ulong previousId = 0;
        ulong revision = rows.Length == 0 ? 0 : rows[0].Revision;
        foreach (var row in rows)
        {
            if (row.EntityId == 0 || row.EntityId <= previousId ||
                !PlayerHitbox.Finite(row.Position) || row.Revision == 0 ||
                row.Revision > 10_000_000 || row.Revision != revision)
                throw new InvalidDataException("Invalid snapshot entity for chunking.");
            previousId = row.EntityId;
        }

        var result = new List<IReadOnlyList<SnapshotEntity>>();
        for (int index = 0; index < rows.Length; index += chunkSize)
            result.Add(rows.Skip(index).Take(chunkSize).ToArray());
        return result;
    }
}
