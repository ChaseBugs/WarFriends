using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseLandMine(Player owner,string requestId)
    {
        if(landMineSource==null||map==null||armyNavMeshConnectivity==null)return "land-mine-disabled";
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
}
