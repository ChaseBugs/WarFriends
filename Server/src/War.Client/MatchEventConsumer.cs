using System;
using System.IO;
using System.Numerics;
using War.Protocol;

namespace War.Client
{
    /// <summary>Validates and dispatches contiguous server event pages to Unity-facing callbacks.</summary>
    public sealed class MatchEventConsumer
    {
        public ulong LastEventId { get; private set; }
        public event Action<MatchEvent> EventReceived;

        public int Consume(MatchEventBatch batch)
        {
            if (batch == null || batch.Code != "events" || batch.LatestEventId < LastEventId || batch.Events.Count > 4)
                throw new InvalidOperationException("Invalid match event batch.");
            ulong expected = LastEventId;
            foreach (var item in batch.Events)
            {
                if (item.EventId <= LastEventId || item.EventId != checked(++expected) ||
                    item.Kind == MatchEventKind.Unspecified || item.Tick > 10_000_000 ||
                    float.IsNaN(item.X) || float.IsInfinity(item.X) || float.IsNaN(item.Y) ||
                    float.IsInfinity(item.Y) || float.IsNaN(item.Z) || float.IsInfinity(item.Z))
                    throw new InvalidDataException("Invalid or stale match event.");
                if (item.Kind == MatchEventKind.AirSpawned || item.Kind == MatchEventKind.AirDespawned ||
                    item.Kind == MatchEventKind.DeployableSpawned || item.Kind == MatchEventKind.DeployableDespawned)
                    if (item.ProjectileId == 0 || !Guid.TryParseExact(item.ActorId, "N", out _))
                        throw new InvalidDataException("Invalid entity lifecycle event.");
                if ((item.Kind == MatchEventKind.CardEffectApplied || item.Kind == MatchEventKind.CardEffectExpired) &&
                    (!Guid.TryParseExact(item.ActorId, "N", out _) || string.IsNullOrWhiteSpace(item.Reason)))
                    throw new InvalidDataException("Invalid card effect lifecycle event.");
                if (item.Kind == MatchEventKind.ObjectiveProgress &&
                    (!Guid.TryParseExact(item.ActorId, "N", out _) || item.ProjectileId == 0 || string.IsNullOrWhiteSpace(item.Reason)))
                    throw new InvalidDataException("Invalid objective progress event.");
                if (item.Kind == MatchEventKind.ArenaSettled &&
                    (!Guid.TryParseExact(item.ActorId, "N", out _) ||
                     !item.Reason.EndsWith(":won", StringComparison.Ordinal) &&
                     !item.Reason.EndsWith(":lost", StringComparison.Ordinal)))
                    throw new InvalidDataException("Invalid Arena settlement event.");
                if ((item.Kind == MatchEventKind.VehicleSpawned || item.Kind == MatchEventKind.VehicleDestroyed) &&
                    (!Guid.TryParseExact(item.ActorId, "N", out _) || !uint.TryParse(item.Reason, out var generation) || generation == 0 ||
                     item.ProjectileId == 0 || string.IsNullOrWhiteSpace(item.TargetId)))
                    throw new InvalidDataException("Invalid vehicle lifecycle event.");
                if((item.Kind==MatchEventKind.VehiclePassengerDown||
                    item.Kind==MatchEventKind.VehiclePassengerRespawned)&&
                   (!Guid.TryParseExact(item.ActorId,"N",out _)||item.ProjectileId==0||item.TargetId!=""||
                    !item.Reason.StartsWith("vehicle-passenger-",StringComparison.Ordinal)))
                    throw new InvalidDataException("Invalid vehicle passenger lifecycle event.");
                if((item.Kind==MatchEventKind.VehicleRepairDroneDown||
                    item.Kind==MatchEventKind.VehicleRepairDroneRespawned||
                    item.Kind==MatchEventKind.VehicleRepairDroneExploded)&&
                   (!Guid.TryParseExact(item.ActorId,"N",out _)||item.ProjectileId==0||item.TargetId!=""||
                    (item.Kind==MatchEventKind.VehicleRepairDroneDown?
                        item.Reason!="vehicle-repair-drone-down:0"&&item.Reason!="vehicle-repair-drone-down:1":
                     item.Kind==MatchEventKind.VehicleRepairDroneRespawned?
                        item.Reason!="vehicle-repair-drone-respawn:0"&&item.Reason!="vehicle-repair-drone-respawn:1":
                        item.Reason!="vehicle-repair-drone-exploded:0"&&item.Reason!="vehicle-repair-drone-exploded:1")))
                    throw new InvalidDataException("Invalid vehicle repair-drone lifecycle event.");
                if ((item.Kind == MatchEventKind.WarperWarpStarted || item.Kind == MatchEventKind.WarperWarpEnded) &&
                    (!Guid.TryParseExact(item.ActorId, "N", out _) || item.TargetId != "" || item.ProjectileId != 0 ||
                     item.ArmyEntityId <= 0 || item.ArmyOptionIndex < 0 || item.ArmyOptionIndex >= 48 ||
                     item.ArmyUnitId != "ID_UNIT-WARPER" || item.ArmySpawnComponentFileId <= 0 ||
                     item.ArmyReservationFileId < 0 || item.ArmyEnergyRecipientId != "" || item.Reason != "warper"))
                    throw new InvalidDataException("Invalid Warper presentation event.");
            }
            if (batch.Events.Count > 0 && batch.Events[batch.Events.Count - 1].EventId > batch.LatestEventId)
                throw new InvalidDataException("Event page exceeds its latest cursor.");
            foreach (var item in batch.Events) EventReceived?.Invoke(item);
            if (batch.Events.Count > 0) LastEventId = batch.Events[batch.Events.Count - 1].EventId;
            return batch.Events.Count;
        }
    }
}
