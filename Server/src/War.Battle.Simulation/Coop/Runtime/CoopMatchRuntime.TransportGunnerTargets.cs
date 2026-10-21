namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const int TransportGunnerCollisionLayer = 23;

    /// <summary>Places the living turret soldier's sampled idle rig at its current host-owned seat.</summary>
    internal IReadOnlyList<DynamicShotTarget> PlaceRestingTransportGunnerTargets(ulong entityId)
    {
        if (groundVehicleBodies == null ||
            TransportGunner(entityId) is not { TurretEnabled: true } gunner ||
            PlaceTransportGunner(entityId) is not { } seat)
        {
            return [];
        }
        if (gunner.SpawnTick > tick)
        {
            throw new InvalidDataException("Co-op gunner pose precedes its spawn.");
        }

        // EnemyController.SwitchStateToVehicle calls Idle and attaches the soldier
        // to enemyPointVehicle. Its health and colliders are separate from the aircraft.
        return groundVehicleBodies.PassengerPoses.PlaceHelicopterGunner(seat, tick - gunner.SpawnTick)
            .Select(hitbox => new DynamicShotTarget(
                entityId, 0, TransportGunnerCollisionLayer, hitbox, HelicopterGunner: true))
            .ToArray();
    }
}
