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
            if(!heavyTurrets.TrySpawn(requestId,owner.Definition.PlayerId,owner.Definition.Fraction,slot,position.Value,stats,out var spawned)||spawned==null)
            {cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "heavy-turret-placement-unavailable";}
            performance.RecordCard(requestId);stateRevision++;
            Emit(MatchEventKind.HeavyTurretSpawned,spawned.OwnerPlayerId,"CardHeavyTurret",spawned.EntityId,
                spawned.Position,spawned.Health,spawned.SlotComponentFileId.ToString());
            return "heavy-turret-spawned";
        }
        catch(Exception e) when(e is InvalidDataException or ArgumentOutOfRangeException or OverflowException)
        {heavyTurrets.TryRollback(requestId,owner.Definition.PlayerId);performance.TryRollbackCard(requestId);cardReservations.TryRelease(requestId,owner.Definition.PlayerId);return "invalid-heavy-turret-authority";}
    }
}
