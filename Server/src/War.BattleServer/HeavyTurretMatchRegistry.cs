using System.Numerics;

namespace War.BattleServer;

internal sealed record HeavyTurretMatchEntity(ulong EntityId,string RequestId,string OwnerPlayerId,
    int OwnerFraction,int SlotComponentFileId,Vector3 Position,float Health,float MaximumHealth,
    float Damage,int BatchMinimum,int BatchMaximum,float ShootMinimum,float ShootMaximum,float RealShotProbability);

internal sealed class HeavyTurretMatchRegistry
{
    private sealed record Receipt(string OwnerPlayerId,ulong EntityId);
    private readonly int capacity;private readonly Dictionary<ulong,HeavyTurretMatchEntity> entities=[];
    private readonly Dictionary<string,Receipt> receipts=new(StringComparer.Ordinal);private readonly HashSet<int> occupied=[];
    private ulong nextEntityId;
    internal HeavyTurretMatchRegistry(int capacity=16){if(capacity is <1 or >80)throw new ArgumentOutOfRangeException(nameof(capacity));this.capacity=capacity;}
    internal IReadOnlySet<int> OccupiedSlotIds=>occupied;
    internal IReadOnlyList<HeavyTurretMatchEntity> Snapshot()=>entities.Values.OrderBy(x=>x.EntityId).ToArray();
    internal bool TryReplay(string requestId,string owner,out HeavyTurretMatchEntity? row)
    {row=null;if(!receipts.TryGetValue(requestId,out var receipt)||receipt.OwnerPlayerId!=owner)return false;entities.TryGetValue(receipt.EntityId,out row);return true;}
    internal bool TrySpawn(string requestId,string owner,int fraction,HeavyTurretPlacement slot,Vector3 position,
        HeavyTurretStats stats,out HeavyTurretMatchEntity? row)
    {
        row=null;if(!Guid.TryParseExact(requestId,"N",out _)||!Guid.TryParseExact(owner,"N",out _)||fraction is not (1 or 2)||
           slot==null||slot.ComponentFileId<=0||occupied.Contains(slot.ComponentFileId)||entities.Count>=capacity||receipts.ContainsKey(requestId)||
           !PlayerHitbox.Finite(position)||!float.IsFinite(stats.Health)||stats.Health<=0||stats.Health>10_000_000||
           !float.IsFinite(stats.Damage)||stats.Damage<=0||stats.Damage>10_000_000||stats.BatchMinimum is <1 or >32||
           stats.BatchMaximum<=stats.BatchMinimum||stats.BatchMaximum>32||!float.IsFinite(stats.ShootMinimum)||stats.ShootMinimum<=0||
           !float.IsFinite(stats.ShootMaximum)||stats.ShootMaximum<stats.ShootMinimum||stats.ShootMaximum>3600||
           !float.IsFinite(stats.RealShotProbability)||stats.RealShotProbability is <0 or >1||nextEntityId==ulong.MaxValue)return false;
        row=new(++nextEntityId,requestId,owner,fraction,slot.ComponentFileId,position,stats.Health,stats.Health,stats.Damage,
            stats.BatchMinimum,stats.BatchMaximum,stats.ShootMinimum,stats.ShootMaximum,stats.RealShotProbability);
        entities.Add(row.EntityId,row);if(!occupied.Add(slot.ComponentFileId))throw new InvalidDataException("Heavy Turret occupancy diverged.");
        receipts.Add(requestId,new(owner,row.EntityId));return true;
    }
    internal IReadOnlyList<HeavyTurretMatchEntity> RemoveOwner(string owner)
    {var rows=entities.Values.Where(x=>x.OwnerPlayerId==owner).OrderBy(x=>x.EntityId).ToArray();foreach(var row in rows){entities.Remove(row.EntityId);if(!occupied.Remove(row.SlotComponentFileId))throw new InvalidDataException("Heavy Turret occupancy diverged.");}return rows;}
    internal bool TryRollback(string requestId,string owner)
    {if(!receipts.TryGetValue(requestId,out var receipt)||receipt.OwnerPlayerId!=owner)return false;if(entities.Remove(receipt.EntityId,out var row)&&!occupied.Remove(row.SlotComponentFileId))throw new InvalidDataException("Heavy Turret rollback diverged.");receipts.Remove(requestId);return true;}
}
