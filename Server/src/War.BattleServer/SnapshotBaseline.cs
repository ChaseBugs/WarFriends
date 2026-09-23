using System.Numerics;

namespace War.BattleServer;

public sealed record SnapshotEntity(ulong EntityId,Vector3 Position,ulong Revision);

public sealed class SnapshotBaseline
{
    private readonly Dictionary<ulong,SnapshotEntity> entities=[];
    public ulong Revision { get; private set; }
    public IReadOnlyList<SnapshotEntity> Apply(ulong revision,IEnumerable<SnapshotEntity> incoming)
    {
        if(revision<=Revision)throw new InvalidDataException("Snapshot revision is stale.");
        var rows=(incoming??throw new ArgumentNullException(nameof(incoming))).ToArray();
        if(rows.Length>4096)throw new InvalidDataException("Snapshot is too large.");
        var incomingIds = new HashSet<ulong>();
        foreach(var row in rows)
        {
            if(row.EntityId==0||!incomingIds.Add(row.EntityId)||!PlayerHitbox.Finite(row.Position)||row.Revision!=revision)throw new InvalidDataException("Invalid snapshot entity.");
        }
        var changed=new List<SnapshotEntity>();
        foreach(var row in rows)
            if(!entities.TryGetValue(row.EntityId,out var prior)||prior.Position!=row.Position){entities[row.EntityId]=row;changed.Add(row);}
        Revision=revision;return changed;
    }
}
