using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
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
    private void AdvanceHeavyTurrets()
    {
        foreach(var turret in heavyTurrets.Snapshot())
        {
            turret.Attack.AdvanceTick();
            if(turret.Attack.Phase==HeavyTurretAttackPhase.Cooldown&&turret.Attack.CooldownTicksRemaining==0)
            {
                var selected=SelectHeavyTurretTarget(turret);
                if(selected!=null)turret.Attack.TryBegin(selected.Id);
            }
            if(!turret.Attack.ShotDue)continue;
            var target=ResolveHeavyTurretTarget(turret,turret.Attack.TargetId);
            if(target==null){turret.Attack.CancelTarget();continue;}
            bool real=turret.Attack.CurrentShotIsReal;
            if(!turret.Attack.CommitShot())throw new InvalidDataException("Heavy Turret shot commit diverged.");
            stateRevision++;
            Emit(MatchEventKind.HeavyTurretFired,turret.OwnerPlayerId,target.Id,turret.EntityId,
                target.Position,real?turret.Damage:0,target.Kind+":"+(real?"real":"fake"));
            if(!real)continue;
            if(target.Kind=="decoy")ApplyDecoyProjectileImpact(turret.OwnerPlayerId,target.EntityId,turret.Damage,1,turret.EntityId);
            else if(target.Kind=="army")ApplyArmyProjectileImpact(turret.OwnerPlayerId,target.EntityId,turret.Damage,1);
            else ApplyResolvedPlayerDamage(turret.OwnerPlayerId,target.Id,
                new ResolvedPlayerDamage(turret.Damage,CombatDamageType.Shot,HasWeapon:true,FriendKill:false),1,true);
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
            null:new(id,player.Position,"player");
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
}
