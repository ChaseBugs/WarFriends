using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void ApplyPvpBonusGrenadePassengers(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        if (vehicles == null) return;
        if (groundVehicleWeapons == null)
            throw new InvalidDataException("Bonus grenade passenger poses are missing.");

        foreach (var vehicle in vehicles.Snapshot().OrderBy(item => item.EntityId))
        {
            if (!activeArmyEntities.TryGetValue(vehicle.EntityId, out var army) ||
                army.UnitId != vehicle.UnitId ||
                army.OwnerPlayerId != vehicle.OwnerPlayerId ||
                !groundVehicleFacing.TryGetValue(vehicle.EntityId, out var facing) ||
                !vehiclePassengers.TryGetValue(vehicle.EntityId, out var passengers))
                throw new InvalidDataException("Bonus grenade passenger lost host authority.");
            var vehicleOwner = Find(vehicle.OwnerPlayerId) ??
                throw new InvalidDataException("Bonus grenade passenger owner disappeared.");
            if (vehicleOwner.Definition.Fraction == owner.Definition.Fraction)
                continue;

            foreach (var passenger in passengers.Values.OrderBy(item =>
                         item.Binding.PointComponentFileId))
            {
                if (!passenger.Active) continue;
                if (passenger.AnimationStartTick > tick)
                    throw new InvalidDataException("Bonus grenade passenger animation is future-dated.");
                ulong animationTick = tick - passenger.AnimationStartTick;
                var hitboxes = groundVehicleWeapons.PassengerPoses.Place(
                    vehicle.UnitId, passenger.Binding, vehicle.Position,
                    facing, animationTick);
                Vector3 position = PassengerWorldPosition(vehicle.EntityId,
                    passenger.Binding);
                var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                    position, hitboxes, stage);
                if (effect == null) continue;
                if (!float.IsFinite(effect.RawDamage) ||
                    effect.RawDamage is <= 0f or > 10_000_000f)
                    throw new InvalidDataException("Bonus grenade passenger damage is invalid.");
                // Explosion.MissileExplode groups all part colliders by their
                // owner, so a passenger takes one blast without part weights.
                ApplyVehiclePassengerHostDamage(vehicle.EntityId,
                    passenger.Binding.Role, effect.RawDamage);
            }
        }
    }

    private void ApplyPvpBonusGrenadeRepairDrones(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        if (vehicles == null) return;
        if (groundVehicleWeapons == null)
            throw new InvalidDataException("Bonus grenade repair-drone source is missing.");

        foreach (var vehicle in vehicles.Snapshot()
                     .Where(item => item.UnitId == "ID_UNIT-TRANSPORTER")
                     .OrderBy(item => item.EntityId))
        {
            if (!activeArmyEntities.TryGetValue(vehicle.EntityId, out var army) ||
                army.UnitId != vehicle.UnitId ||
                army.OwnerPlayerId != vehicle.OwnerPlayerId ||
                !transporterRepairDrones.TryGetValue(vehicle.EntityId, out var drones))
                throw new InvalidDataException("Bonus grenade repair drone lost host authority.");
            var vehicleOwner = Find(vehicle.OwnerPlayerId) ??
                throw new InvalidDataException("Bonus grenade repair-drone owner disappeared.");
            if (vehicleOwner.Definition.Fraction == owner.Definition.Fraction)
                continue;
            int layer = vehicleOwner.Definition.Fraction switch
            {
                1 => 23,
                2 => 22,
                _ => throw new InvalidDataException("Bonus grenade repair-drone faction is invalid.")
            };

            foreach (var drone in drones.OrderBy(item => item.PathIndex))
            {
                if (!drone.Active) continue;
                var snapshot = drone.Snapshot();
                var collider = groundVehicleWeapons.PlaceRepairDrone(
                    vehicle.EntityId, drone.PathIndex, layer, snapshot);
                var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                    snapshot.Position, [collider.Hitbox], stage);
                if (effect == null) continue;
                if (!float.IsFinite(effect.RawDamage) ||
                    effect.RawDamage is <= 0f or > 10_000_000f ||
                    !ApplyTransporterRepairDroneHostDamage(vehicle.EntityId,
                        drone.PathIndex, effect.RawDamage))
                    throw new InvalidDataException("Bonus grenade repair-drone damage is invalid.");
                if (!drone.Active)
                    Emit(MatchEventKind.VehicleRepairDroneDown,
                        vehicle.OwnerPlayerId, "", vehicle.EntityId,
                        drone.Position, 0,
                        "vehicle-repair-drone-down:" + drone.PathIndex);
            }
        }
    }
}
