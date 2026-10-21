using System.Numerics;

namespace War.BattleServer;

/// <summary>Constructs mutable flights from the already-selected source binding and host shot.</summary>
internal static class BulletLaunchFactory
{
    private const float MaximumBurstWeaponDamage = 100_000_000f;

    internal static void Validate(BulletLaunch launch, string family)
    {
        if (launch.ProjectileId == 0 || string.IsNullOrEmpty(launch.OwnerId) ||
            !PlayerHitbox.Finite(launch.MuzzlePosition) || !PlayerHitbox.Finite(launch.TargetPosition) ||
            !float.IsFinite(launch.CriticalRoll) || launch.CriticalRoll is < 0f or > 1f ||
            launch.TraceCollision == null)
        {
            throw new InvalidDataException($"Invalid {family} projectile authority.");
        }
    }

    internal static void ValidateBurstDamage(float damage, string family)
    {
        if (!float.IsFinite(damage) || damage is < 0f or > MaximumBurstWeaponDamage)
        {
            throw new InvalidDataException($"Invalid {family} damage authority.");
        }
    }

    internal static BulletFlight Create(BulletLaunch launch, BulletFlightDefinition definition, Vector3 shotOffset)
    {
        return new BulletFlight(launch.ProjectileId, launch.OwnerId, definition,
            launch.MuzzlePosition + shotOffset, launch.TargetPosition, launch.SimulationTick, launch.TraceCollision);
    }
}
