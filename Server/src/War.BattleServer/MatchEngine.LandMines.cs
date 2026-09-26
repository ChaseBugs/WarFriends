using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    // Host-only insertion used by deterministic simulation proofs and future
    // server-authored scene mechanics. No UDP command can choose a position.
    internal bool TryRegisterLandMine(string requestId,string ownerPlayerId,Vector3 position,float damage)
    {
        if(phase!=BattlePhase.Running||landMineSource==null||map==null||!PlayerHitbox.Finite(position)||
           !Guid.TryParseExact(requestId,"N",out _)||Find(ownerPlayerId) is not {Admitted:true} owner||
           events.Count>=MaximumRetainedEvents||stateRevision==ulong.MaxValue)return false;
        var slot=landMineSource.ForMap(map).FirstOrDefault(x=>x.Fraction!=owner.Definition.Fraction);
        if(slot==null||!landMines.TrySpawn(requestId,ownerPlayerId,owner.Definition.Fraction,damage,
            [(slot,position)],out var spawned)||spawned.Count!=1)return false;
        var row=spawned[0];stateRevision++;
        Emit(MatchEventKind.LandMineSpawned,row.OwnerPlayerId,"CardLandmine",row.EntityId,
            row.Position,row.Damage,row.HidingComponentFileId.ToString());
        return true;
    }

    private string UseLandMine(Player owner,string requestId)
    {
        if(landMineSource==null||map==null||armyNavMeshConnectivity==null||
           (rifleCombat==null&&grenadeCombat==null))return "land-mine-disabled";
        if(!owner.CardsSelected||!owner.SelectedCards.Contains("CardLandmine",StringComparer.Ordinal))return "land-mine-not-selected";
        if(!Guid.TryParseExact(requestId,"N",out _))return "invalid-land-mine-request";
        if(landMines.TryReplay(requestId,owner.Definition.PlayerId,out _))return "land-mine-replayed";
        if(cardReservations==null)return "card-inventory-disabled";
        if(!performance.CanRecordCard(requestId))return "land-mine-receipt-unavailable";
        if(events.Count>MaximumRetainedEvents-landMineSource.SpawnLimit)return "event-backpressure";
        if(stateRevision>ulong.MaxValue-(ulong)landMineSource.SpawnLimit)return "land-mine-receipt-unavailable";
        if(!cardReservations.TryReserve(requestId,owner.Definition.PlayerId,"CardLandmine"))return "land-mine-unavailable";
        try
        {
            var slots=landMineSource.Select(map.Source,owner.Definition.Fraction,armyChoice);
            if(slots.Count is <1 or >3)
            {cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "land-mine-slots-unavailable";}
            var placements=new List<(LandMineHidingSlot Slot,Vector3 Position)>();
            foreach(var slot in slots)
            {
                var position=armyNavMeshConnectivity.SampleNearest(map,slot.SourcePosition,landMineSource.NavMeshSampleRadius);
                if(!position.HasValue)
                {cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "land-mine-placement-unavailable";}
                placements.Add((slot,position.Value));
            }
            int level=owner.Definition.PlayerLevel??throw new InvalidDataException("Land Mine activation needs trusted player level.");
            float damage=landMineSource.Damage(level,decoyMaxDisplayLevel);
            if(!landMines.TrySpawn(requestId,owner.Definition.PlayerId,owner.Definition.Fraction,damage,placements,out var spawned))
            {cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "land-mine-placement-unavailable";}
            performance.RecordCard(requestId);
            foreach(var row in spawned)
            {
                stateRevision++;
                Emit(MatchEventKind.LandMineSpawned,row.OwnerPlayerId,"CardLandmine",row.EntityId,
                    row.Position,row.Damage,row.HidingComponentFileId.ToString());
            }
            return "land-mine-spawned";
        }
        catch(Exception e) when(e is InvalidDataException or ArgumentOutOfRangeException or OverflowException)
        {
            landMines.TryRollbackSpawn(requestId,owner.Definition.PlayerId);performance.TryRollbackCard(requestId);
            cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "invalid-land-mine-authority";
        }
    }

    private PlayerCollisionModel LandMinePose(string playerId)
        =>rifleCombat?.Pose(playerId).Collision??grenadeCombat?.Collision(playerId)??
          throw new InvalidDataException("Land Mine lost current player collision authority.");

    private void AdvanceLandMines()
    {
        if(landMineSource==null||landMines.Snapshot().Count==0)return;
        foreach(var mine in landMines.Snapshot())
        {
            var playerTrigger=players.Where(x=>!x.Dead&&x.Definition.Fraction!=mine.OwnerFraction)
                .OrderBy(x=>x.Definition.PlayerId,StringComparer.Ordinal)
                .FirstOrDefault(x=>LandMineExplosion.Triggered(mine.Position,landMineSource.Prefab,
                    LandMinePose(x.Definition.PlayerId)));
            var armyTrigger=activeArmyEntities.Values.Where(x=>x.OwnerFraction!=mine.OwnerFraction&&
                    infantryAnimations.ContainsKey(x.EntityKey)).OrderBy(x=>x.EntityKey)
                .FirstOrDefault(x=>LandMineExplosion.Triggered(mine.Position,landMineSource.Prefab,
                    (InfantryPose(x.EntityKey)??throw new InvalidDataException("Land Mine trigger lost infantry pose.")).Parts));
            if(playerTrigger==null&&armyTrigger==null)continue;
            if(!landMines.TryRemove(mine.EntityId,out var removed)||removed!=mine)
                throw new InvalidDataException("Land Mine trigger compare-and-remove failed.");
            stateRevision++;
            string target=playerTrigger?.Definition.PlayerId??armyTrigger!.OwnerPlayerId;
            string reason=playerTrigger!=null?"player-trigger":"army-trigger:"+armyTrigger!.EntityKey;
            Emit(MatchEventKind.LandMineTriggered,mine.OwnerPlayerId,target,
                mine.EntityId,mine.Position,mine.Damage,reason);
            var attacker=Find(mine.OwnerPlayerId)??throw new InvalidDataException("Land Mine owner disappeared.");
            foreach(var army in activeArmyEntities.Values.Where(x=>x.OwnerFraction!=mine.OwnerFraction&&
                        infantryAnimations.ContainsKey(x.EntityKey)).OrderBy(x=>x.EntityKey).ToArray())
            {
                var pose=InfantryPose(army.EntityKey)??throw new InvalidDataException("Land Mine explosion lost infantry pose.");
                var root=new Vector3(army.X,army.Y,army.Z);
                var effect=LandMineExplosion.Resolve(mine.Position,mine.Damage,landMineSource,pose.Parts,root);
                if(effect!=null&&ApplyArmyHostDamage(army.EntityKey,effect.RawDamage))
                    attacker.ConfirmedEnemyHits=checked(attacker.ConfirmedEnemyHits+1);
            }
            foreach(var victim in players.Where(x=>!x.Dead).ToArray())
            {
                var effect=LandMineExplosion.Resolve(mine.Position,mine.Damage,landMineSource,
                    LandMinePose(victim.Definition.PlayerId),victim.Position);
                if(effect==null)continue;
                bool enemy=attacker!=victim&&attacker.Definition.Fraction!=victim.Definition.Fraction;
                ApplyResolvedPlayerDamage(mine.OwnerPlayerId,victim.Definition.PlayerId,
                    new(effect.RawDamage,effect.Kind,HasWeapon:true,FriendKill:true,Overtime:overtime),
                    damageRoll?.Invoke()??1f,enemy);
                if(Terminal)return;
            }
        }
    }
}
