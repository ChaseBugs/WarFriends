using System.Numerics;

namespace War.BattleServer;

internal sealed class HeavyTurretMatchEntity
{
    internal ulong EntityId{get;}internal string RequestId{get;}internal string OwnerPlayerId{get;}
    internal int OwnerFraction{get;}internal int SlotComponentFileId{get;}internal Vector3 Position{get;}
    internal float Health{get;set;}internal float MaximumHealth{get;}internal float Damage{get;}
    internal int BatchMinimum{get;}internal int BatchMaximum{get;}internal float ShootMinimum{get;}
    internal float ShootMaximum{get;}internal float RealShotProbability{get;}internal HeavyTurretAttackState Attack{get;}
    internal HeavyTurretMatchEntity(ulong entityId,string requestId,string ownerPlayerId,int ownerFraction,
        int slotComponentFileId,Vector3 position,HeavyTurretStats stats,float effectiveRealShotProbability,Func<float> random)
    {EntityId=entityId;RequestId=requestId;OwnerPlayerId=ownerPlayerId;OwnerFraction=ownerFraction;
     SlotComponentFileId=slotComponentFileId;Position=position;Health=MaximumHealth=stats.Health;Damage=stats.Damage;
     BatchMinimum=stats.BatchMinimum;BatchMaximum=stats.BatchMaximum;ShootMinimum=stats.ShootMinimum;
     ShootMaximum=stats.ShootMaximum;RealShotProbability=effectiveRealShotProbability;
     Attack=new(stats with {RealShotProbability=effectiveRealShotProbability},random);}
}

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
        HeavyTurretStats stats,float effectiveRealShotProbability,Func<float> random,out HeavyTurretMatchEntity? row)
    {
        row=null;if(!Guid.TryParseExact(requestId,"N",out _)||!Guid.TryParseExact(owner,"N",out _)||fraction is not (1 or 2)||
           slot==null||slot.ComponentFileId<=0||occupied.Contains(slot.ComponentFileId)||entities.Count>=capacity||receipts.ContainsKey(requestId)||
           !PlayerHitbox.Finite(position)||!float.IsFinite(stats.Health)||stats.Health<=0||stats.Health>10_000_000||
           !float.IsFinite(stats.Damage)||stats.Damage<=0||stats.Damage>10_000_000||stats.BatchMinimum is <1 or >32||
           stats.BatchMaximum<=stats.BatchMinimum||stats.BatchMaximum>32||!float.IsFinite(stats.ShootMinimum)||stats.ShootMinimum<=0||
           !float.IsFinite(stats.ShootMaximum)||stats.ShootMaximum<stats.ShootMinimum||stats.ShootMaximum>3600||
           !float.IsFinite(stats.RealShotProbability)||stats.RealShotProbability is <0 or >1||
           !float.IsFinite(effectiveRealShotProbability)||effectiveRealShotProbability is <0 or >1||nextEntityId==ulong.MaxValue)return false;
        row=new(++nextEntityId,requestId,owner,fraction,slot.ComponentFileId,position,stats,effectiveRealShotProbability,random);
        entities.Add(row.EntityId,row);if(!occupied.Add(slot.ComponentFileId))throw new InvalidDataException("Heavy Turret occupancy diverged.");
        receipts.Add(requestId,new(owner,row.EntityId));return true;
    }
    internal IReadOnlyList<HeavyTurretMatchEntity> RemoveOwner(string owner)
    {var rows=entities.Values.Where(x=>x.OwnerPlayerId==owner).OrderBy(x=>x.EntityId).ToArray();foreach(var row in rows){entities.Remove(row.EntityId);if(!occupied.Remove(row.SlotComponentFileId))throw new InvalidDataException("Heavy Turret occupancy diverged.");}return rows;}
    internal bool TryRollback(string requestId,string owner)
    {if(!receipts.TryGetValue(requestId,out var receipt)||receipt.OwnerPlayerId!=owner)return false;if(entities.Remove(receipt.EntityId,out var row)&&!occupied.Remove(row.SlotComponentFileId))throw new InvalidDataException("Heavy Turret rollback diverged.");receipts.Remove(requestId);return true;}
    internal bool TryDamage(ulong entityId,float amount,out HeavyTurretMatchEntity? row,out bool destroyed)
    {
        row=null;destroyed=false;if(!float.IsFinite(amount)||amount<=0||amount>10_000_000)throw new InvalidDataException("Invalid Heavy Turret damage.");
        if(!entities.TryGetValue(entityId,out row))return false;
        row.Health=Math.Max(0,row.Health-amount);destroyed=row.Health==0;
        if(destroyed){entities.Remove(entityId);if(!occupied.Remove(row.SlotComponentFileId))throw new InvalidDataException("Heavy Turret damage occupancy diverged.");}
        return true;
    }
}
