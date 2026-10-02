using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private sealed record HelicopterHostProjectile(string Owner,BulletFlight? Real,
        HelicopterFakeProjectileFlight? Fake,float Damage,float PlayerRatio,float OvertimeRatio);
    private readonly Dictionary<ulong,HelicopterTurretWeaponState> armyHelicopterWeapons=[];
    private readonly Dictionary<ulong,HelicopterHostProjectile> helicopterProjectiles=[];
    internal int PendingHelicopterProjectiles=>helicopterProjectiles.Count;

    private void AdvanceHelicopterTurret(ulong key,float time)
    {
        if(!activeArmyEntities.TryGetValue(key,out var row)||row.HelicopterRotation is not { } rotation||
           !armyHelicopterGunners.TryGetValue(key,out var gunner)||
           !armyHelicopterAcquisitions.TryGetValue(key,out var acquisition)||
           !armyHelicopterTurrets.TryGetValue(key,out var tween)||
           !armyHelicopterWeapons.TryGetValue(key,out var weapon)||
           !armyHelicopterShots.TryGetValue(key,out var stats))
            throw new InvalidDataException("Helicopter turret lost source combat authority.");
        if(!gunner.Snapshot().TurretEnabled)return;

        if(acquisition.AwaitingAim&&tween.Ready)
        {
            var target=DroneTargetSnapshot().FirstOrDefault(x=>x.Id==acquisition.TargetId&&
                x.Fraction!=row.OwnerFraction&&x.Alive&&x.Visible);
            var details=target==null?null:ResolveDroneShotTarget(target);
            var first=details?.Targets.FirstOrDefault(x=>(x.Type&0xFFFFFB)==x.Type);
            bool visible=first!=null&&
                HelicopterCurrentSightRay(key,first.Position,true) is { } ray&&
                HelicopterVisibilityRay(ray);
            if(visible&&details!=null)
            {
                var root=new Vector3(row.X,row.Y,row.Z);
                var acquisitionRotation=new Quaternion(rotation.X,rotation.Y,rotation.Z,rotation.W);
                var selected=HelicopterTurretShotTargetPolicy.Select(
                    HelicopterTurretAim.ParentPosition(root,acquisitionRotation),details,
                    stats.ShieldHitProbability,NextArmyFloat);
                if(selected!=null)
                {
                    int span=stats.FireBatchSizeMax-stats.FireBatchSizeMin;
                    int choice=span==0?0:armyChoice(span);
                    if(choice<0||choice>=Math.Max(1,span))
                        throw new InvalidDataException("Helicopter batch size escaped source range.");
                    int count=stats.FireBatchSizeMin+choice;
                    if(count<=0)throw new InvalidDataException("Helicopter selected an empty shot batch.");
                    // Gun.ComputeFlyTimeToTarget is the base implementation (zero).
                    // AimingHelper therefore adds no velocity lead for this turret.
                    weapon.Begin(selected.Position,count,stats.ProbabilityOfRealShot,
                        selected.Type==2);
                }
                else visible=false;
            }
            acquisition.ResolveAim(tick,visible);
        }

        if(!weapon.Shooting||projectileId==ulong.MaxValue||
           PendingProjectileCount>=MaximumProjectiles||!EventCapacityForShot())return;
        var rootPosition=new Vector3(row.X,row.Y,row.Z);
        var q=new Quaternion(rotation.X,rotation.Y,rotation.Z,rotation.W);
        var pose=tween.Current(rootPosition,q);
        var round=weapon.Advance(time,HelicopterTurretAim.ParentPosition(rootPosition,q),
            pose.MuzzlePosition);
        if(round==null)return;
        ulong id=checked(projectileId+1);
        try
        {
            if(round.Batch.IsFake)
            {
                var fake=new HelicopterFakeProjectileFlight(round.Muzzle,round.Batch.Target,
                    stats.ShotSpeed,tick);
                helicopterProjectiles.Add(id,new(row.OwnerPlayerId,null,fake,0,0,0));
            }
            else
            {
                if(!armyDamage.TryGetValue(key,out float damage)||!float.IsFinite(damage)||damage<=0)
                    throw new InvalidDataException("Helicopter shot lacks source damage authority.");
                var policy=(armyCatalog??throw new InvalidDataException("Helicopter player damage policy absent."))
                    .PlayerDamagePolicy(row.UnitId);
                var flight=new BulletFlight(id,row.OwnerPlayerId,
                    new(stats.ShotSpeed,.5f,false),round.Muzzle,round.Batch.Target,tick,
                    (origin,direction,range)=>TraceHeavyTurretShot(row.OwnerPlayerId,origin,direction,range));
                helicopterProjectiles.Add(id,new(row.OwnerPlayerId,flight,null,damage,
                    policy.PlayerDamageRatio,policy.OvertimePlayerDamageRatio));
            }
        }
        catch(ProjectileTargetException)
        {
            weapon.Reset();acquisition.Reset(tick);return;
        }
        projectileId=id;stateRevision++;
        Emit(MatchEventKind.HelicopterFired,row.OwnerPlayerId,acquisition.TargetId??"",id,
            round.Batch.Target,0,"helicopter");
        events[^1].HelicopterShot=new HelicopterShotPresentation
        {
            ArmyEntityKey=key,MuzzleX=round.Muzzle.X,MuzzleY=round.Muzzle.Y,
            MuzzleZ=round.Muzzle.Z,
            Speed=round.Batch.IsFake?stats.ShotSpeed*1.5f:stats.ShotSpeed,
            Fake=round.Batch.IsFake,Shield=round.Shield
        };
        if(round.Batch.EndsBatch)acquisition.Reset(tick);
    }

    private void AdvanceHelicopterProjectiles()
    {
        foreach(var pair in helicopterProjectiles.OrderBy(x=>x.Key).ToArray())
        {
            var projectile=pair.Value;
            if(projectile.Fake is { } fake)
            {
                fake.Advance(tick);
                if(fake.Finished)helicopterProjectiles.Remove(pair.Key);
                continue;
            }
            var flight=projectile.Real??throw new InvalidDataException("Helicopter projectile lacks flight authority.");
            var impact=flight.Advance(tick);
            if(flight.Finished)helicopterProjectiles.Remove(pair.Key);
            if(impact==null)continue;
            stateRevision++;
            Emit(MatchEventKind.Impact,impact.OwnerId,impact.Hit.PlayerId??"",
                impact.ProjectileId,impact.Hit.Position,0,"helicopter");
            ApplyHeavyTurretEnvironmentImpact(impact,projectile.Damage);
            if(Terminal)return;
            var hit=impact.Hit;
            if(hit.PlayerId is { } player)
                ApplyResolvedPlayerDamage(impact.OwnerId,player,
                    new(projectile.Damage,CombatDamageType.Shot,PartWeight:hit.PartWeight,
                        FriendKill:true,PlayerCoefficient:projectile.PlayerRatio,
                        PlayerOvertimeCoefficient:projectile.OvertimeRatio,Overtime:overtime),
                    damageRoll?.Invoke()??1,true);
            else if(hit is {DynamicDecoy:true,DynamicEntityId:ulong decoy})
                ApplyDecoyProjectileImpact(impact.OwnerId,decoy,projectile.Damage,
                    hit.PartWeight,impact.ProjectileId);
            else if(hit is {DynamicArmyInfantry:true,DynamicEntityId:ulong infantry})
                ApplyArmyProjectileImpact(impact.OwnerId,infantry,projectile.Damage,hit.PartWeight);
            else if(hit is {DynamicHeavyTurret:true,DynamicEntityId:ulong turret})
                ApplyHeavyTurretProjectileImpact(impact.OwnerId,turret,projectile.Damage,
                    hit.PartWeight,impact.ProjectileId);
            else if(hit is {DynamicPassengerRole:{} role,DynamicEntityId:ulong vehicle})
                ApplyGroundVehiclePassengerProjectileImpact(impact.OwnerId,vehicle,role,
                    projectile.Damage,hit.PartWeight);
            else if(hit is {DynamicRepairDronePathIndex:int path,DynamicEntityId:ulong repairVehicle})
                ApplyTransporterRepairDroneProjectileImpact(impact.OwnerId,repairVehicle,path,
                    projectile.Damage,hit.PartWeight);
            else if(hit is {DynamicPartId:int part,DynamicEntityId:ulong body})
                ApplyArmyBodyProjectileImpact(impact.OwnerId,body,part,projectile.Damage);
            if(Terminal)return;
        }
    }
}
