using System.Numerics;
using War.Protocol;
namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong,DroneAttackState> droneAttacks=[];
    private readonly DroneWeaponCatalog? droneWeapon;
    private readonly DroneProjectileCatalog? droneProjectile;
    private sealed record DroneHostProjectile(ulong ArmyId,string Owner,DroneProjectileIntent Intent,
        BulletFlight? Real,DroneFakeProjectileFlight? Fake);
    internal sealed record DroneHostImpact(ulong ArmyId,DroneProjectileIntent Intent,BulletImpact Impact);
    private readonly Dictionary<ulong,DroneHostProjectile> droneProjectiles=[];
    internal int PendingDroneProjectiles=>droneProjectiles.Count;
    internal ulong? LaunchObservedDroneProjectile(ulong key)
    {
        var intent=ObserveDroneAttack(key);
        if(intent==null)return null;
        var army=activeArmyEntities[key];
        ulong id=checked(projectileId+1);
        try
        {
            var flight=intent.Shot.Batch.IsFake
                ?new DroneHostProjectile(key,army.OwnerPlayerId,intent,null,new DroneFakeProjectileFlight(intent,tick))
                :new DroneHostProjectile(key,army.OwnerPlayerId,intent,new BulletFlight(id,army.OwnerPlayerId,
                    new(intent.Speed,intent.CheckDistance,false),intent.Shot.Muzzle,intent.Shot.Batch.Target,tick,
                    (origin,direction,range)=>TraceHeavyTurretShot(army.OwnerPlayerId,origin,direction,range)),null);
            droneProjectiles.Add(id,flight);projectileId=id;return id;
        }
        catch(ProjectileTargetException){return null;}
    }
    internal IReadOnlyList<DroneHostImpact> AdvanceDroneProjectileFlights()
    {
        var impacts=new List<DroneHostImpact>();
        foreach(var (id,projectile) in droneProjectiles.OrderBy(x=>x.Key).ToArray())
        {
            if(projectile.Fake is { } fake)
            {
                fake.Advance(tick);if(fake.Finished)droneProjectiles.Remove(id);
            }
            else
            {
                var flight=projectile.Real??throw new InvalidDataException("Drone projectile lacks flight authority.");
                var impact=flight.Advance(tick);
                if(flight.Finished)droneProjectiles.Remove(id);
                if(impact!=null)
                {
                    impacts.Add(new(projectile.ArmyId,projectile.Intent,impact));
                    ApplyDroneProjectileImpact(projectile.Intent,impact);
                    if(Terminal)break;
                }
            }
        }
        return impacts.AsReadOnly();
    }
    private void ApplyDroneProjectileImpact(DroneProjectileIntent intent,BulletImpact impact)
    {
        if(intent.Shot.Batch.IsFake)throw new InvalidDataException("Fake Drone round cannot authorize damage.");
        stateRevision++;
        Emit(MatchEventKind.Impact,impact.OwnerId,impact.Hit.PlayerId??"",impact.ProjectileId,impact.Hit.Position,0,"drone");
        // Both weapons use Ammo without PlayerWeapon: same unit shield and barrel policy.
        ApplyHeavyTurretEnvironmentImpact(impact,intent.Damage);
        if(Terminal)return;
        var hit=impact.Hit;
        if(hit.PlayerId is { } player)
            ApplyResolvedPlayerDamage(impact.OwnerId,player,new(intent.Damage,CombatDamageType.Shot,
                PartWeight:hit.PartWeight,FriendKill:true,PlayerCoefficient:intent.PlayerDamageCoefficient,
                PlayerOvertimeCoefficient:intent.PlayerOvertimeDamageCoefficient,Overtime:overtime),
                damageRoll?.Invoke()??1,true);
        else if(hit is {DynamicDecoy:true,DynamicEntityId:ulong decoy})
            ApplyDecoyProjectileImpact(impact.OwnerId,decoy,intent.Damage,hit.PartWeight,impact.ProjectileId);
        else if(hit is {DynamicArmyInfantry:true,DynamicEntityId:ulong infantry})
            ApplyArmyProjectileImpact(impact.OwnerId,infantry,intent.Damage,hit.PartWeight);
        else if(hit is {DynamicHeavyTurret:true,DynamicEntityId:ulong turret})
            ApplyHeavyTurretProjectileImpact(impact.OwnerId,turret,intent.Damage,hit.PartWeight,impact.ProjectileId);
        else if(hit is {DynamicPassengerRole:{} role,DynamicEntityId:ulong vehicle})
            ApplyGroundVehiclePassengerProjectileImpact(impact.OwnerId,vehicle,role,intent.Damage,hit.PartWeight);
        else if(hit is {DynamicRepairDronePathIndex:int path,DynamicEntityId:ulong repairVehicle})
            ApplyTransporterRepairDroneProjectileImpact(impact.OwnerId,repairVehicle,path,intent.Damage,hit.PartWeight);
        else if(hit is {DynamicPartId:int part,DynamicEntityId:ulong body})
            ApplyArmyBodyProjectileImpact(impact.OwnerId,body,part,intent.Damage);
    }
    internal float? DroneAttackDeadline(ulong key)=>droneAttacks.GetValueOrDefault(key)?.Deadline;
    internal DroneProjectileIntent? ObserveDroneAttack(ulong key)
    {
        if(phase!=BattlePhase.Running||!activeArmyEntities.TryGetValue(key,out var row)||
           !droneAttacks.TryGetValue(key,out var attack)||!armyDamage.TryGetValue(key,out float damage))
            throw new InvalidDataException("Drone attack observation lacks live match authority.");
        if(row.DroneRotation is not { } q)throw new InvalidDataException("Drone attack lacks current orientation.");
        var position=new Vector3(row.X,row.Y,row.Z);var rotation=new Quaternion(q.X,q.Y,q.Z,q.W);
        float time=(float)((double)tick/MatchManifest.TickRate);
        attack.Prepare(time,true,row.OwnerFraction,position,rotation,DroneTargetSnapshot(),
            target=>DroneCanSee(position,target.Position),ResolveDroneShotTarget);
        bool capacity=projectileId<ulong.MaxValue&&PendingProjectileCount<MaximumProjectiles&&EventCapacityForShot();
        var intent=attack.AdvanceProjectile(time,position,rotation,damage,capacity);
        if(intent==null)return null;
        var policy=(armyCatalog??throw new InvalidDataException("Drone damage policy source absent."))
            .PlayerDamagePolicy(row.UnitId);
        return intent with {PlayerDamageCoefficient=policy.PlayerDamageRatio,
            PlayerOvertimeDamageCoefficient=policy.OvertimePlayerDamageRatio};
    }
    private int DroneBatchRange(int minimum,int maximum)
    {
        if(minimum==maximum)return minimum;
        int choice=armyChoice(maximum-minimum);
        if(choice<0||choice>=maximum-minimum)throw new InvalidDataException("Invalid Drone batch integer sample.");
        return minimum+choice;
    }
    internal DroneTargetDetails ResolveDroneShotTarget(DroneTargetCandidate target)
    {
        if(target.Id.StartsWith("player:",StringComparison.Ordinal))
        {
            string id=target.Id[7..];var player=Find(id)??throw new InvalidDataException("Drone player target disappeared.");
            if(rifleCombat==null||playerShotTargets==null||map==null)
                throw new InvalidDataException("Drone player target lacks source poses.");
            var pose=rifleCombat.Pose(id);
            var rows=playerShotTargets.Gameplay.Select(t=>new DroneShotTarget(t.TransformFileId,t.Type,
                pose.BodyTarget(t.TransformFileId).Position)).ToArray();
            return new(Array.AsReadOnly(rows),true,player.Position,
                -Vector3.Transform(Vector3.UnitZ,map.Covers[player.Cover].Rotation),player.Route==null,Vector3.Zero);
        }
        if(target.Id.StartsWith("decoy:",StringComparison.Ordinal)&&ulong.TryParse(target.Id.AsSpan(6),out ulong decoyId))
        {
            var row=decoys.Snapshot().SingleOrDefault(x=>x.EntityId==decoyId);
            if(row==null||decoySource==null)throw new InvalidDataException("Drone Decoy target disappeared.");
            var rotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.Atan2(row.Facing.X,row.Facing.Z));
            var source=decoySource.Prefab;
            return new([new(source.TargetTransformFileId,1,row.Position+Vector3.Transform(source.TargetLocalPosition,rotation))],
                false,row.Position,Vector3.Zero,false,Vector3.Zero);
        }
        if(target.Id.StartsWith("army:",StringComparison.Ordinal)&&ulong.TryParse(target.Id.AsSpan(5),out ulong key)&&
           activeArmyEntities.TryGetValue(key,out var army))
        {
            var position=new Vector3(army.X,army.Y,army.Z);
            if(InfantryShotTargets(key) is { } targets)
                return new(targets,false,position,Vector3.Zero,false,InfantryVelocity(key));
            if(armyDronePaths.TryGetValue(key,out var drone))
                return new([new(454360,1,position)],false,position,Vector3.Zero,false,
                    drone.Velocity*MatchManifest.TickRate);
            if(vehicles?.TryGet(key,out var vehicle)==true&&vehicle!=null&&groundVehicleWeapons!=null)
            {
                var rig=groundVehicleWeapons.For(vehicle.UnitId);
                return new([new(rig.ShotTargetTransformFileId,1,position+rig.ShotTarget)],false,position,
                    Vector3.Zero,false,groundVehicleVelocities.GetValueOrDefault(key));
            }
        }
        throw new InvalidDataException("Drone target has no verified runtime aim binding.");
    }
}
