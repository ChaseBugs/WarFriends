namespace War.BattleServer;

public static class SnapshotChunker
{
    public static IReadOnlyList<IReadOnlyList<SnapshotEntity>> Chunk(IEnumerable<SnapshotEntity> entities,int chunkSize=64)
    {
        if(chunkSize is <1 or >512)throw new InvalidDataException("Invalid snapshot chunk size.");
        var rows=(entities??throw new ArgumentNullException(nameof(entities))).OrderBy(x=>x.EntityId).ToArray();
        if(rows.Length>4096)throw new InvalidDataException("Snapshot is too large.");
        var result=new List<IReadOnlyList<SnapshotEntity>>();
        for(int i=0;i<rows.Length;i+=chunkSize)result.Add(rows.Skip(i).Take(chunkSize).ToArray());
        return result;
    }
}
