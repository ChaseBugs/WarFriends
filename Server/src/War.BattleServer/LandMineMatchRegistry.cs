using System.Numerics;

namespace War.BattleServer;

internal sealed record LandMineMatchEntity(ulong EntityId,string RequestId,string OwnerPlayerId,
    int OwnerFraction,int HidingComponentFileId,Vector3 Position,float Damage);

/// <summary>Match-owned Land Mine entities and retry receipts.</summary>
internal sealed class LandMineMatchRegistry
{
    private sealed record Receipt(string OwnerPlayerId,ulong[] EntityIds);
    private readonly int capacity;
    private readonly Dictionary<ulong,LandMineMatchEntity> entities=[];
    private readonly Dictionary<string,Receipt> receipts=new(StringComparer.Ordinal);
    private ulong nextEntityId;
    internal LandMineMatchRegistry(int capacity=48)
    {if(capacity is <3 or >256)throw new ArgumentOutOfRangeException(nameof(capacity));this.capacity=capacity;}
    internal IReadOnlyList<LandMineMatchEntity> Snapshot()=>entities.Values.OrderBy(x=>x.EntityId).ToArray();
    internal bool TryReplay(string requestId,string ownerPlayerId,out IReadOnlyList<LandMineMatchEntity> rows)
    {
        rows=[];if(!receipts.TryGetValue(requestId,out var receipt)||receipt.OwnerPlayerId!=ownerPlayerId)return false;
        rows=receipt.EntityIds.Where(entities.ContainsKey).Select(id=>entities[id]).ToArray();return true;
    }
    internal bool TrySpawn(string requestId,string ownerPlayerId,int ownerFraction,float damage,
        IReadOnlyList<(LandMineHidingSlot Slot,Vector3 Position)> placements,out IReadOnlyList<LandMineMatchEntity> spawned)
    {
        spawned=[];
        if(!Guid.TryParseExact(requestId,"N",out _)||!Guid.TryParseExact(ownerPlayerId,"N",out _)||
           ownerFraction is not (1 or 2)||!float.IsFinite(damage)||damage<=0||damage>10_000_000||
           placements==null||placements.Count is <1 or >3||entities.Count>capacity-placements.Count||receipts.ContainsKey(requestId))return false;
        var slots=new HashSet<int>();
        foreach(var placement in placements)
            if(placement.Slot==null||placement.Slot.Fraction==ownerFraction||placement.Slot.ComponentFileId<=0||
               !slots.Add(placement.Slot.ComponentFileId)||!PlayerHitbox.Finite(placement.Position))return false;
        if(nextEntityId>ulong.MaxValue-(ulong)placements.Count)return false;
        var accepted=new LandMineMatchEntity[placements.Count];
        for(int i=0;i<accepted.Length;i++)
        {
            var placement=placements[i];accepted[i]=new(++nextEntityId,requestId,ownerPlayerId,ownerFraction,
                placement.Slot.ComponentFileId,placement.Position,damage);
        }
        foreach(var row in accepted)entities.Add(row.EntityId,row);
        receipts.Add(requestId,new(ownerPlayerId,accepted.Select(x=>x.EntityId).ToArray()));spawned=accepted;return true;
    }
    internal bool TryRemove(ulong entityId,out LandMineMatchEntity? removed)
    {if(entities.Remove(entityId,out var row)){removed=row;return true;}removed=null;return false;}
    internal IReadOnlyList<LandMineMatchEntity> RemoveOwner(string ownerPlayerId)
    {
        var removed=entities.Values.Where(x=>x.OwnerPlayerId==ownerPlayerId).OrderBy(x=>x.EntityId).ToArray();
        foreach(var row in removed)entities.Remove(row.EntityId);return removed;
    }
    internal bool TryRollbackSpawn(string requestId,string ownerPlayerId)
    {
        if(!receipts.TryGetValue(requestId,out var receipt)||receipt.OwnerPlayerId!=ownerPlayerId)return false;
        foreach(var id in receipt.EntityIds)entities.Remove(id);receipts.Remove(requestId);return true;
    }
}
