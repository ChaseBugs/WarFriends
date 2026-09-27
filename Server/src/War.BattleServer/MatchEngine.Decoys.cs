using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly DroneTargetRegistry droneTargets=new();
    private readonly HashSet<string> dronePlayerTargets=new(StringComparer.Ordinal);
    private static string DronePlayerId(string id)=>"player:"+id;
    private void UpdateDronePlayerTarget(Player player)
    {
        if(!dronePlayerTargets.Contains(player.Definition.PlayerId))return;
        droneTargets.Update(new(DronePlayerId(player.Definition.PlayerId),player.Definition.Fraction,
            !player.Dead,true,false,null,player.Position));
    }
    private readonly Dictionary<ulong,int> droneArmyTargets=[];
    private static string DroneArmyId(ulong id)=>"army:"+id.ToString(System.Globalization.CultureInfo.InvariantCulture);
    private void RegisterDroneArmyTarget(ulong key,ArmyDeploymentFamily family)
    {
        string? ownerType=family.IsSoldier?"EnemyController":family.BehaviorType switch
        {
            "DroneBehaviour"=>"Drone","TankBehaviour"=>"Tank",
            "HelicopterBehaviour"=>"Helicopter","AssaultHelicopterBehaviour"=>"AssaultHelicopter",
            "CarBehaviour"=>"AICar","CarBuggyBehaviour"=>"AICarBuggy",
            "CarTransporterBehaviour"=>"AICarTransporter",_=>null
        };
        // Mech owner/prefab identity is not established by the recovered implementation.
        if(ownerType is null)return;
        var row=activeArmyEntities[key];
        droneTargets.Enable(ownerType,new(DroneArmyId(key),row.OwnerFraction,true,true,false,
            family.UnitType,new(row.X,row.Y,row.Z)));
        droneArmyTargets.Add(key,family.UnitType);
    }
    internal IReadOnlyList<DroneTargetCandidate> DroneTargetSnapshot()
    {
        foreach(var (key,unitType) in droneArmyTargets)
        {
            var row=activeArmyEntities[key];
            droneTargets.Update(new(DroneArmyId(key),row.OwnerFraction,true,true,false,
                unitType,new(row.X,row.Y,row.Z)));
        }
        return droneTargets.Snapshot();
    }
    private readonly DroneColliderCatalog? droneColliders;
    internal bool DroneCanSee(Vector3 position,Vector3 target)
        =>(rifleCombat??throw new InvalidDataException("Drone visibility requires host collision poses."))
            .DroneCanSee(position,target);
    internal DroneTargetCandidate? SelectDroneTarget(int fraction,Vector3 position)
        =>DroneTargetPolicy.Select(fraction,DroneTargetSnapshot(),row=>DroneCanSee(position,row.Position));
    private static string DroneDecoyId(ulong id)=>"decoy:"+id.ToString(System.Globalization.CultureInfo.InvariantCulture);
    internal float? DecoyHealth(ulong entityId)=>decoys.Snapshot().SingleOrDefault(x=>x.EntityId==entityId)?.Health;
    internal bool DecoyObstacleOccupied(int componentFileId)=>decoys.OccupiedObstacleIds.Contains(componentFileId);

    private string UseDecoy(Player owner,string requestId)
    {
        if(decoySource==null||map==null||armyNavMeshConnectivity==null)return "decoy-disabled";
        if(!owner.CardsSelected||!owner.SelectedCards.Contains("CardDecoy",StringComparer.Ordinal))
            return "decoy-not-selected";
        if(!Guid.TryParseExact(requestId,"N",out _))return "invalid-decoy-request";
        if(decoys.TryReplay(requestId,owner.Definition.PlayerId,out _))return "decoy-replayed";
        if(cardReservations==null)return "card-inventory-disabled";
        if(!performance.CanRecordCard(requestId))return "decoy-receipt-unavailable";
        if(events.Count>MaximumRetainedEvents-decoySource.SpawnCount)return "event-backpressure";
        if(stateRevision>ulong.MaxValue-(ulong)decoySource.SpawnCount)return "decoy-receipt-unavailable";
        if(!cardReservations.TryReserve(requestId,owner.Definition.PlayerId,"CardDecoy"))return "decoy-unavailable";
        var registeredTargets=new List<string>();
        try
        {
            var slots=decoySource.Select(map.Source,owner.Definition.Fraction,
                decoys.OccupiedObstacleIds,armyChoice);
            if(slots.Count!=decoySource.SpawnCount)
            {
                cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "decoy-slots-unavailable";
            }
            Vector3 target=OpposingDecoyLookTarget(owner.Definition.Fraction);
            var placements=new List<(DecoyObstacleSlot Slot,Vector3 Position,Vector3 Facing)>();
            foreach(var slot in slots)
            {
                var position=armyNavMeshConnectivity.SampleNearest(map,slot.InitialMidpoint,10f);
                if(!position.HasValue)
                {
                    cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "decoy-placement-unavailable";
                }
                var facing=target-position.Value;facing.Y=0;
                if(facing.LengthSquared()<.000001f)
                {
                    cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "decoy-placement-unavailable";
                }
                placements.Add((slot,position.Value,Vector3.Normalize(facing)));
            }
            int level=owner.Definition.PlayerLevel??throw new InvalidDataException("Decoy activation needs trusted player level.");
            float health=decoySource.Health(level,decoyMaxDisplayLevel);
            if(!decoys.TrySpawn(requestId,owner.Definition.PlayerId,owner.Definition.Fraction,
                health,placements,out var spawned))
            {
                cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "decoy-placement-unavailable";
            }
            performance.RecordCard(requestId);
            foreach(var row in spawned)
            {
                var targetId=DroneDecoyId(row.EntityId);
                droneTargets.Enable("Decoy",new(targetId,row.OwnerFraction,true,true,true,null,row.Position));
                registeredTargets.Add(targetId);
                stateRevision++;
                Emit(MatchEventKind.DecoySpawned,row.OwnerPlayerId,"CardDecoy",row.EntityId,
                    row.Position,row.Health,row.ObstacleComponentFileId.ToString());
            }
            return "decoy-spawned";
        }
        catch(Exception e) when(e is InvalidDataException or ArgumentOutOfRangeException or OverflowException)
        {
            foreach(var id in registeredTargets)droneTargets.Disable(id);
            decoys.TryRollbackSpawn(requestId,owner.Definition.PlayerId);
            performance.TryRollbackCard(requestId);
            cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "invalid-decoy-authority";
        }
    }

    private Vector3 OpposingDecoyLookTarget(int ownerFraction)
    {
        var targets=map!.Covers.Where(x=>x.Fraction!=ownerFraction).Select(x=>x.ShotPosition).ToArray();
        if(targets.Length==0)throw new InvalidDataException("Decoy has no opposing look target.");
        Vector3 sum=Vector3.Zero;foreach(var target in targets)sum+=target;
        var result=sum/targets.Length;
        if(!PlayerHitbox.Finite(result))throw new InvalidDataException("Invalid Decoy look target.");
        return result;
    }

    private IReadOnlyList<DynamicShotTarget> DecoyShotTargets(Player shooter)
    {
        if(decoySource==null)return [];
        var prefab=decoySource.Prefab;var result=new List<DynamicShotTarget>();
        foreach(var row in decoys.Snapshot())
        {
            if(row.OwnerFraction==shooter.Definition.Fraction)continue;
            int layer=row.OwnerFraction==1?23:22;
            float yaw=MathF.Atan2(row.Facing.X,row.Facing.Z);
            var rotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,yaw);
            var center=row.Position+Vector3.Transform(prefab.ColliderCenter,rotation);
            var hitbox=new PlayerHitbox(prefab.Source+"#"+prefab.ColliderComponentFileId,
                PlayerHitboxKind.Box,1,center,prefab.ColliderSize,rotation,0,Vector3.Zero,0,
                transformPosition:row.Position);
            result.Add(new(row.EntityId,0,layer,hitbox,Decoy:true));
        }
        return result;
    }

    private void ApplyDecoyProjectileImpact(string shooterId,ulong entityId,float rawDamage,
        float partWeight,ulong projectileId)
    {
        var shooter=Find(shooterId)??throw new InvalidDataException("Decoy impact shooter disappeared.");
        var target=decoys.Snapshot().SingleOrDefault(x=>x.EntityId==entityId);
        if(target==null)return;
        if(target.OwnerFraction==shooter.Definition.Fraction||!float.IsFinite(rawDamage)||rawDamage<=0||
           rawDamage>10_000_000||partWeight!=1)
            throw new InvalidDataException("Invalid Decoy projectile impact.");
        if(!decoys.TryDamage(entityId,rawDamage,out var before,out bool destroyed)||before==null)return;
        shooter.ConfirmedEnemyHits=checked(shooter.ConfirmedEnemyHits+1);stateRevision++;
        if(destroyed)
        {
            droneTargets.Disable(DroneDecoyId(entityId));
            Emit(MatchEventKind.DecoyDestroyed,shooterId,before.OwnerPlayerId,entityId,
                before.Position,0,"projectile:"+projectileId);
        }
    }
}
