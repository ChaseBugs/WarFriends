using System.Numerics;

namespace War.BattleServer;

internal sealed record DecoyMatchEntity(ulong EntityId,string RequestId,string OwnerPlayerId,
    int OwnerFraction,int ObstacleComponentFileId,Vector3 Position,Vector3 Facing,
    float Health,float MaximumHealth);

/// <summary>Match-owned Decoy health, obstacle occupancy, and request receipts.</summary>
internal sealed class DecoyMatchRegistry
{
    private sealed record Receipt(string OwnerPlayerId,ulong[] EntityIds);
    private readonly int capacity;
    private readonly Dictionary<ulong,DecoyMatchEntity> entities=[];
    private readonly Dictionary<string,Receipt> receipts=new(StringComparer.Ordinal);
    private readonly HashSet<int> occupied=[];
    private ulong nextEntityId;

    internal DecoyMatchRegistry(int capacity=48)
    {
        if(capacity is <3 or >256)throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity=capacity;
    }

    internal IReadOnlySet<int> OccupiedObstacleIds=>occupied;
    internal IReadOnlyList<DecoyMatchEntity> Snapshot()=>entities.Values.OrderBy(x=>x.EntityId).ToArray();

    internal bool TryReplay(string requestId,string ownerPlayerId,out IReadOnlyList<DecoyMatchEntity> rows)
    {
        rows=[];
        if(!receipts.TryGetValue(requestId,out var receipt)||receipt.OwnerPlayerId!=ownerPlayerId)return false;
        rows=receipt.EntityIds.Where(entities.ContainsKey).Select(id=>entities[id]).ToArray();
        return true;
    }

    internal bool TrySpawn(string requestId,string ownerPlayerId,int ownerFraction,float maximumHealth,
        IReadOnlyList<(DecoyObstacleSlot Slot,Vector3 Position,Vector3 Facing)> placements,
        out IReadOnlyList<DecoyMatchEntity> spawned)
    {
        spawned=[];
        if(!Guid.TryParseExact(requestId,"N",out _)||!Guid.TryParseExact(ownerPlayerId,"N",out _)||
           ownerFraction is not (1 or 2)||!float.IsFinite(maximumHealth)||maximumHealth<=0||maximumHealth>10_000_000||
           placements==null||placements.Count!=3||entities.Count>capacity-placements.Count||
           receipts.ContainsKey(requestId))return false;
        var slotIds=new HashSet<int>();
        foreach(var placement in placements)
            if(placement.Slot==null||placement.Slot.Fraction!=ownerFraction||placement.Slot.ComponentFileId<=0||
               !slotIds.Add(placement.Slot.ComponentFileId)||occupied.Contains(placement.Slot.ComponentFileId)||
               !PlayerHitbox.Finite(placement.Position)||!PlayerHitbox.Finite(placement.Facing)||
               Math.Abs(placement.Facing.LengthSquared()-1)>.0001f)return false;
        if(nextEntityId>ulong.MaxValue-(ulong)placements.Count)return false;
        var accepted=new DecoyMatchEntity[placements.Count];
        for(int i=0;i<accepted.Length;i++)
        {
            var placement=placements[i];ulong id=++nextEntityId;
            accepted[i]=new(id,requestId,ownerPlayerId,ownerFraction,placement.Slot.ComponentFileId,
                placement.Position,placement.Facing,maximumHealth,maximumHealth);
        }
        foreach(var row in accepted)
        {
            entities.Add(row.EntityId,row);
            if(!occupied.Add(row.ObstacleComponentFileId))throw new InvalidDataException("Decoy obstacle transaction diverged.");
        }
        receipts.Add(requestId,new(ownerPlayerId,accepted.Select(x=>x.EntityId).ToArray()));
        spawned=accepted;return true;
    }

    internal bool TryDamage(ulong entityId,float damage,out DecoyMatchEntity? before,out bool destroyed)
    {
        destroyed=false;before=null;
        if(!entities.TryGetValue(entityId,out var row)||!float.IsFinite(damage)||damage<=0||damage>10_000_000)return false;
        before=row;float health=Math.Max(0,row.Health-damage);
        if(health<=0)
        {
            entities.Remove(entityId);
            if(!occupied.Remove(row.ObstacleComponentFileId))throw new InvalidDataException("Decoy obstacle occupancy diverged.");
            destroyed=true;
        }
        else entities[entityId]=row with{Health=health};
        return true;
    }

    internal IReadOnlyList<DecoyMatchEntity> RemoveOwner(string ownerPlayerId)
    {
        var removed=entities.Values.Where(x=>x.OwnerPlayerId==ownerPlayerId).OrderBy(x=>x.EntityId).ToArray();
        foreach(var row in removed)
        {
            entities.Remove(row.EntityId);
            if(!occupied.Remove(row.ObstacleComponentFileId))throw new InvalidDataException("Decoy obstacle occupancy diverged.");
        }
        return removed;
    }

    internal bool TryRollbackSpawn(string requestId,string ownerPlayerId)
    {
        if(!receipts.TryGetValue(requestId,out var receipt)||receipt.OwnerPlayerId!=ownerPlayerId)return false;
        foreach(var id in receipt.EntityIds)
            if(entities.Remove(id,out var row)&&!occupied.Remove(row.ObstacleComponentFileId))
                throw new InvalidDataException("Decoy obstacle rollback diverged.");
        receipts.Remove(requestId);return true;
    }
}
