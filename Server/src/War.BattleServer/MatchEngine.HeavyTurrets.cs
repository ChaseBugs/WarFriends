using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private sealed record HeavyTurretProjectile(BulletFlight Flight,float Damage);
    private readonly Dictionary<ulong,HeavyTurretProjectile> heavyTurretProjectiles=[];
    private string UseHeavyTurret(Player owner,string requestId)
    {
        if(heavyTurretSource==null||map==null||armyNavMeshConnectivity==null)return "heavy-turret-disabled";
        if(!owner.CardsSelected||!owner.SelectedCards.Contains("CardHeavyTurret",StringComparer.Ordinal))return "heavy-turret-not-selected";
        if(!Guid.TryParseExact(requestId,"N",out _))return "invalid-heavy-turret-request";
        if(heavyTurrets.TryReplay(requestId,owner.Definition.PlayerId,out _))return "heavy-turret-replayed";
        if(cardReservations==null)return "card-inventory-disabled";
        if(!performance.CanRecordCard(requestId)||events.Count>=MaximumRetainedEvents||stateRevision==ulong.MaxValue)return "heavy-turret-receipt-unavailable";
        if(!cardReservations.TryReserve(requestId,owner.Definition.PlayerId,"CardHeavyTurret"))return "heavy-turret-unavailable";
        try
        {
            var slot=heavyTurretSource.SelectNearestFree(map,owner.Cover,owner.Definition.Fraction,owner.Position,
                heavyTurrets.OccupiedSlotIds.Contains);
            if(slot==null){cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "heavy-turret-slots-unavailable";}
            var position=armyNavMeshConnectivity.SampleNearest(map,slot.SourcePosition,heavyTurretSource.NavMeshSampleRadius);
            if(!position.HasValue){cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "heavy-turret-placement-unavailable";}
            int level=owner.Definition.PlayerLevel??throw new InvalidDataException("Heavy Turret activation needs trusted player level.");
            var stats=heavyTurretSource.Compose(level);
            if(!heavyTurrets.TrySpawn(requestId,owner.Definition.PlayerId,owner.Definition.Fraction,slot,position.Value,stats,
                heavyTurretSource.EffectiveRealShotProbability,NextArmyFloat,out var spawned)||spawned==null)
            {cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "heavy-turret-placement-unavailable";}
            performance.RecordCard(requestId);stateRevision++;
            Emit(MatchEventKind.HeavyTurretSpawned,spawned.OwnerPlayerId,"CardHeavyTurret",spawned.EntityId,
                spawned.Position,spawned.Health,spawned.SlotComponentFileId.ToString());
            return "heavy-turret-spawned";
        }
        catch(Exception e) when(e is InvalidDataException or ArgumentOutOfRangeException or OverflowException)
        {heavyTurrets.TryRollback(requestId,owner.Definition.PlayerId);performance.TryRollbackCard(requestId);cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "invalid-heavy-turret-authority";}
    }

    internal float? HeavyTurretHealth(ulong entityId)=>heavyTurrets.Snapshot().SingleOrDefault(x=>x.EntityId==entityId)?.Health;
    internal bool ApplyHeavyTurretHostDamage(string attackerId,ulong entityId,float damage,string source)
    {
        var attacker=Find(attackerId)??throw new InvalidDataException("Heavy Turret attacker disappeared.");
        var target=heavyTurrets.Snapshot().SingleOrDefault(x=>x.EntityId==entityId);if(target==null)return false;
        if(target.OwnerFraction==attacker.Definition.Fraction||string.IsNullOrEmpty(source)||source.Length>64||source.Any(char.IsControl))
            throw new InvalidDataException("Invalid Heavy Turret damage authority.");
        if(!heavyTurrets.TryDamage(entityId,damage,out var changed,out bool destroyed)||changed==null)return false;
        attacker.ConfirmedEnemyHits=checked(attacker.ConfirmedEnemyHits+1);stateRevision++;
        Emit(destroyed?MatchEventKind.HeavyTurretDestroyed:MatchEventKind.HeavyTurretDamaged,
            attackerId,changed.OwnerPlayerId,entityId,changed.Position,changed.Health,source);
        return true;
    }

    private sealed record HeavyTurretTarget(string Id,Vector3 Position,string Kind,ulong EntityId=0);
    private readonly Dictionary<ulong,HeavyTurretTarget> heavyTurretBatchTargets=[];
    private void AdvanceHeavyTurrets()
    {
        var live=heavyTurrets.Snapshot();
        foreach(var id in heavyTurretBatchTargets.Keys.Where(id=>!live.Any(x=>x.EntityId==id)).ToArray())heavyTurretBatchTargets.Remove(id);
        foreach(var turret in live)
        {
            if(turret.Attack.Phase==HeavyTurretAttackPhase.Cooldown)heavyTurretBatchTargets.Remove(turret.EntityId);
            turret.Attack.AdvanceTick();
            if(turret.Attack.Phase==HeavyTurretAttackPhase.Cooldown&&turret.Attack.CooldownTicksRemaining==0)
            {
                var selected=SelectHeavyTurretTarget(turret);
                if(selected!=null)turret.Attack.TryBegin(selected.Id);
            }
            if(!turret.Attack.ShotDue)continue;
            if(!heavyTurretBatchTargets.TryGetValue(turret.EntityId,out var target))
            {
                target=ResolveHeavyTurretTarget(turret,turret.Attack.TargetId);
                if(target==null||!HeavyTurretCanSee(turret,target)){turret.Attack.CancelTarget();continue;}
                // BatchedWeapon retains mTargetPosition and its complete mask,
                // even when the target moves or dies during the batch.
                heavyTurretBatchTargets.Add(turret.EntityId,target);
                turret.Attack.PrepareBatchRounds();
            }
            if(projectileId==ulong.MaxValue||PendingProjectileCount>=MaximumProjectiles||!EventCapacityForShot())continue;
            bool real=turret.Attack.CurrentShotIsReal;
            ulong shotId=++projectileId;
            if(real)
            {
                var origin=turret.Position+heavyTurretSource!.MuzzleOffset;
                try
                {
                    var flight=new BulletFlight(shotId,turret.OwnerPlayerId,
                        new(HeavyTurretBulletSpeed(target.Kind),heavyTurretSource.BulletCheckDistance,false),
                        origin,target.Position,tick,(from,direction,range)=>TraceHeavyTurretShot(turret.OwnerPlayerId,from,direction,range));
                    heavyTurretProjectiles.Add(shotId,new(flight,turret.Damage));
                }
                catch(ProjectileTargetException){turret.Attack.CancelTarget();continue;}
            }
            if(!turret.Attack.CommitShot())throw new InvalidDataException("Heavy Turret shot commit diverged.");
            stateRevision++;
            Emit(MatchEventKind.HeavyTurretFired,turret.OwnerPlayerId,target.Id,shotId,
                target.Position,real?turret.Damage:0,target.Kind+":"+(real?"real":"fake"));
        }
    }
    private HeavyTurretTarget? SelectHeavyTurretTarget(HeavyTurretMatchEntity turret)
    {
        var decoyRows=decoys.Snapshot().Where(x=>x.OwnerFraction!=turret.OwnerFraction).OrderBy(x=>x.EntityId).ToArray();
        if(decoyRows.Length>0){var row=decoyRows[Choose(decoyRows.Length)];return new("decoy:"+row.EntityId,row.Position,"decoy",row.EntityId);}
        var infantry=activeArmyEntities.Values.Where(x=>x.OwnerFraction!=turret.OwnerFraction&&infantryAnimations.ContainsKey(x.EntityKey)).ToArray();
        var rushers=infantry.Where(x=>ArmyRusherPointCatalog.IsRusher(
            armyCatalog!.Families.Single(f=>f.UnitId==x.UnitId).BehaviorType)).OrderBy(x=>x.EntityKey).ToArray();
        var pool=rushers.Length>0?rushers:infantry.OrderBy(x=>x.EntityKey).ToArray();
        if(pool.Length>0){var row=pool[Choose(pool.Length)];return new("army:"+row.EntityKey,new(row.X,row.Y,row.Z),"army",row.EntityKey);}
        var opponent=players.SingleOrDefault(x=>x.Definition.Fraction!=turret.OwnerFraction&&x.Health>0&&!x.Reconnecting);
        return opponent==null?null:new(opponent.Definition.PlayerId,opponent.Position,"player");
    }
    private HeavyTurretTarget? ResolveHeavyTurretTarget(HeavyTurretMatchEntity turret,string id)
    {
        if(id.StartsWith("decoy:",StringComparison.Ordinal)&&ulong.TryParse(id.AsSpan(6),out ulong decoyId))
        {var row=decoys.Snapshot().SingleOrDefault(x=>x.EntityId==decoyId&&x.OwnerFraction!=turret.OwnerFraction);return row==null?null:new(id,row.Position,"decoy",decoyId);}
        if(id.StartsWith("army:",StringComparison.Ordinal)&&ulong.TryParse(id.AsSpan(5),out ulong armyId)&&
           activeArmyEntities.TryGetValue(armyId,out var army)&&army.OwnerFraction!=turret.OwnerFraction&&infantryAnimations.ContainsKey(armyId))
            return new(id,new(army.X,army.Y,army.Z),"army",armyId);
        var player=Find(id);return player==null||player.Definition.Fraction==turret.OwnerFraction||player.Health<=0||player.Reconnecting?
            null:new(id,HeavyTurretPlayerTarget(id,turret.Position),"player");
    }
    private Vector3 HeavyTurretPlayerTarget(string playerId,Vector3 origin)
    {
        if(rifleCombat==null)throw new InvalidDataException("Heavy Turret target lacks host player poses.");
        var player=Find(playerId)??throw new InvalidDataException("Heavy Turret target player disappeared.");
        var pose=rifleCombat.Pose(playerId);
        if(player.Route!=null&&pose.MovingTarget!=null)
        {
            Vector3 target=pose.MovingTarget.Position;Vector3 velocity=HeavyTurretPlayerVelocity(player);
            float seconds=Vector3.Distance(origin,target)/HeavyTurretBulletSpeed("player");
            var predicted=target+velocity*seconds;
            if(!PlayerHitbox.Finite(predicted))throw new InvalidDataException("Heavy Turret prediction escaped scene bounds.");
            return predicted;
        }
        if(playerShotTargets==null||map==null)throw new InvalidDataException("Heavy Turret lacks source shot targets.");
        // The recovered player state stays HidingBehindShield while firing;
        // aimForward is the negative current defend-point forward.
        var forward=-Vector3.Transform(Vector3.UnitZ,map.Covers[player.Cover].Rotation);
        var towardTurret=origin-player.Position;
        int mask=HeavyTurretStationaryTargetMask(forward,towardTurret,heavyTurretSource!.ShieldHitProbability,NextArmyFloat);
        var selected=playerShotTargets.Nearest(mask,origin,row=>pose.BodyTarget(row.TransformFileId).Position);
        return pose.BodyTarget(selected.TransformFileId).Position;
    }
    internal static int HeavyTurretStationaryTargetMask(Vector3 forward,Vector3 towardTurret,float shieldProbability,Func<float> random)
    {
        if(!PlayerHitbox.Finite(forward)||!PlayerHitbox.Finite(towardTurret)||forward.LengthSquared()==0||
           towardTurret.LengthSquared()==0||!float.IsFinite(shieldProbability)||shieldProbability is <0 or >1)
            throw new InvalidDataException("Invalid Heavy Turret target selection authority.");
        if(Vector3.Dot(Vector3.Normalize(forward),Vector3.Normalize(towardTurret))<MathF.Cos(50*MathF.PI/180))return 2;
        float value=random();if(!float.IsFinite(value)||value is <0 or >=1)throw new InvalidDataException("Invalid Heavy Turret target random value.");
        return value>=shieldProbability?9:2;
    }
    private float HeavyTurretBulletSpeed(string targetKind)=>heavyTurretSource!.EffectiveBulletSpeed*(targetKind=="player"?.5f:1f);
    private Vector3 HeavyTurretPlayerVelocity(Player player)
    {
        if(player.Route==null)return Vector3.Zero;
        if(tick<=player.MoveStart||tick>=player.MoveEnd)return Vector3.Zero;
        float traveled=(float)(tick-player.MoveStart)/MatchManifest.TickRate*player.Definition.MovementSpeed;
        for(int i=1;i<player.Route.Length;i++)
        {
            var delta=player.Route[i]-player.Route[i-1];float length=delta.Length();
            if(length>0&&traveled<=length)return delta/length*player.Definition.MovementSpeed;
            traveled-=length;
        }
        return Vector3.Zero;
    }
    private int Choose(int count)
    {int choice=armyChoice(count);if(choice<0||choice>=count)throw new InvalidDataException("Heavy Turret target selection escaped its source set.");return choice;}

    private IReadOnlyList<DynamicShotTarget> HeavyTurretShotTargets(Player shooter)
    {
        if(heavyTurretSource==null)return [];
        var result=new List<DynamicShotTarget>();
        foreach(var row in heavyTurrets.Snapshot())
        {
            if(row.OwnerFraction==shooter.Definition.Fraction)continue;
            int layer=row.OwnerFraction==1?23:22;
            foreach(var collider in heavyTurretSource.Colliders)
            {
                var hitbox=new PlayerHitbox(heavyTurretSource.PrefabRevision+"#"+collider.ComponentFileId,
                    PlayerHitboxKind.Box,1,row.Position+collider.Center,collider.Size,collider.Rotation,0,
                    Vector3.Zero,0,transformPosition:row.Position);
                result.Add(new(row.EntityId,collider.ComponentFileId,layer,hitbox,HeavyTurret:true));
            }
        }
        return result;
    }

    private void ApplyHeavyTurretProjectileImpact(string shooterId,ulong entityId,float rawDamage,float partWeight,ulong projectileId)
    {
        if(partWeight!=1)throw new InvalidDataException("Invalid Heavy Turret projectile part weight.");
        ApplyHeavyTurretHostDamage(shooterId,entityId,rawDamage,"projectile:"+projectileId);
    }

    private ShotCollision? TraceHeavyTurretShot(string owner,Vector3 origin,Vector3 direction,float range,uint mask=uint.MaxValue)
    {
        if(map==null)throw new InvalidDataException("Heavy Turret shot lost its map.");
        if(rifleCombat==null)throw new InvalidDataException("Heavy Turret shot lacks host player poses.");
        return rifleCombat.TraceForBazooka(owner,origin,direction,range,mask);
    }
    private bool HeavyTurretCanSee(HeavyTurretMatchEntity turret,HeavyTurretTarget target)
    {
        var origin=turret.Position+heavyTurretSource!.MuzzleOffset;
        var sightPosition=target.Position;
        if(target.Kind=="player")
        {
            // TurretSeesEnemy checks GetShotTargets(AllIn)[0], independently
            // of Fire's eventual Shield/WholeBody/Moving target choice.
            var first=playerShotTargets!.Gameplay.First(x=>(x.Type&0xFFFFFB)==x.Type);
            sightPosition=rifleCombat!.Pose(target.Id).BodyTarget(first.TransformFileId).Position;
        }
        var delta=sightPosition-origin;
        float distance=delta.Length();if(distance<.001f)return false;var direction=delta/distance;
        // AIObject.CanSeeTargetStatic offsets 0.25 and stops 0.5 before the target.
        const uint visibilityMask=(1u<<8)|(1u<<13)|(1u<<22)|(1u<<23)|(1u<<24)|(1u<<26)|(1u<<27)|(1u<<30);
        float range=Math.Max(.1f,distance-.75f);
        return TraceHeavyTurretShot(turret.OwnerPlayerId,origin+direction*.25f,direction,range,visibilityMask)==null;
    }
    private void AdvanceHeavyTurretProjectiles()
    {
        foreach(var pair in heavyTurretProjectiles.ToArray())
        {
            BulletImpact? impact=pair.Value.Flight.Advance(tick);
            if(pair.Value.Flight.Finished)heavyTurretProjectiles.Remove(pair.Key);
            if(impact==null)continue;
            stateRevision++;Emit(MatchEventKind.Impact,impact.OwnerId,impact.Hit.PlayerId??"",impact.ProjectileId,
                impact.Hit.Position,0,"heavy-turret");
            ApplyHeavyTurretEnvironmentImpact(impact,pair.Value.Damage);
            if(Terminal)return;
            if(impact.Hit.PlayerId is {} playerId)
                ApplyResolvedPlayerDamage(impact.OwnerId,playerId,
                    new ResolvedPlayerDamage(pair.Value.Damage,CombatDamageType.Shot,HasWeapon:true,FriendKill:false,
                        PartWeight:impact.Hit.PartWeight,PlayerCoefficient:heavyTurretSource!.PlayerDamageRatio,
                        PlayerOvertimeCoefficient:heavyTurretSource.PlayerOvertimeDamageRatio,Overtime:overtime),1,true);
            else if(impact.Hit is {DynamicDecoy:true,DynamicEntityId:ulong decoyId})
                ApplyDecoyProjectileImpact(impact.OwnerId,decoyId,pair.Value.Damage,impact.Hit.PartWeight,impact.ProjectileId);
            else if(impact.Hit is {DynamicArmyInfantry:true,DynamicEntityId:ulong armyId})
                ApplyArmyProjectileImpact(impact.OwnerId,armyId,pair.Value.Damage,impact.Hit.PartWeight);
            else if(impact.Hit is {DynamicHeavyTurret:true,DynamicEntityId:ulong turretId})
                ApplyHeavyTurretProjectileImpact(impact.OwnerId,turretId,pair.Value.Damage,impact.Hit.PartWeight,impact.ProjectileId);
            else if(impact.Hit is {DynamicPassengerRole:{} role,DynamicEntityId:ulong vehicleId})
                ApplyGroundVehiclePassengerProjectileImpact(impact.OwnerId,vehicleId,role,pair.Value.Damage,impact.Hit.PartWeight);
            else if(impact.Hit is {DynamicRepairDronePathIndex:int path,DynamicEntityId:ulong repairVehicleId})
                ApplyTransporterRepairDroneProjectileImpact(impact.OwnerId,repairVehicleId,path,pair.Value.Damage,impact.Hit.PartWeight);
            else if(impact.Hit is {DynamicPartId:int part,DynamicEntityId:ulong bodyId})
                ApplyGroundVehicleProjectileImpact(impact.OwnerId,bodyId,part,pair.Value.Damage);
        }
    }
    internal void ApplyHeavyTurretEnvironmentImpact(BulletImpact impact,float damage)
    {
        if(impact.Tick!=tick||!float.IsFinite(damage)||damage<0||damage>100_000_000)
            throw new InvalidDataException("Invalid Heavy Turret environment impact authority.");
        var owner=Find(impact.OwnerId)??throw new InvalidDataException("Heavy Turret impact owner disappeared.");
        if(impact.Hit.DynamicOwner is {} dynamicOwner&&shields!=null)
        {
            bool enemyHit=shields.IsLiveEnemyShield(dynamicOwner,owner.Definition.Fraction);
            // Shield.DoDamage uses UnitToShieldCoef when the weapon has no
            // PlayerWeapon, as for the recovered Heavy Turret weapon.
            var changed=shields.ApplyUnitShot(dynamicOwner,owner.Definition.Fraction,damage,tick);
            if(enemyHit)owner.ConfirmedEnemyHits=checked(owner.ConfirmedEnemyHits+1);
            if(changed!=null)
            {
                stateRevision++;
                EmitShield(changed.Destroyed?MatchEventKind.ShieldDestroyed:MatchEventKind.ShieldDamaged,
                    impact.OwnerId,changed,impact.ProjectileId);
            }
        }
        if(impact.Hit.ColliderIndex is int colliderIndex&&barrels?.Contains(colliderIndex)==true)
            ApplyBarrelImpact(impact,damage);
    }
}
