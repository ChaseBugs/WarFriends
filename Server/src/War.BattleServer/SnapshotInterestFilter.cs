using System.Numerics;

namespace War.BattleServer;

public static class SnapshotInterestFilter
{
    public static IReadOnlyList<SnapshotEntity> Within(IEnumerable<SnapshotEntity> entities,Vector3 center,float radius)
    {
        if(!PlayerHitbox.Finite(center)||!float.IsFinite(radius)||radius<=0||radius>500)
            throw new InvalidDataException("Invalid snapshot interest bounds.");
        var rows=(entities??throw new ArgumentNullException(nameof(entities))).ToArray();
        if(rows.Length>4096)throw new InvalidDataException("Snapshot interest set is too large.");
        var ids = new HashSet<ulong>();
        foreach (var row in rows)
            if (row.EntityId == 0 || row.Revision == 0 || !PlayerHitbox.Finite(row.Position) || !ids.Add(row.EntityId))
                throw new InvalidDataException("Invalid snapshot interest entity.");
        float squared=radius*radius;
        return rows.Where(x=>Vector3.DistanceSquared(x.Position,center)<=squared)
            .OrderBy(x=>x.EntityId).ToArray();
    }
}
