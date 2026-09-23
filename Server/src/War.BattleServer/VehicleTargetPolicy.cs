using System.Numerics;

namespace War.BattleServer;

public readonly record struct VehicleTarget(string OwnerPlayerId, string TargetPlayerId,
    Vector3 Origin, Vector3 Target, float Distance);

/// <summary>Validates a vehicle target before turret or projectile authority is applied.</summary>
public static class VehicleTargetPolicy
{
    public static VehicleTarget Validate(string ownerPlayerId, string targetPlayerId,
        Vector3 origin, Vector3 target, float maxRange)
    {
        if (!Guid.TryParseExact(ownerPlayerId, "N", out _) ||
            !Guid.TryParseExact(targetPlayerId, "N", out _) || ownerPlayerId == targetPlayerId ||
            !PlayerHitbox.Finite(origin) || !PlayerHitbox.Finite(target) ||
            !float.IsFinite(maxRange) || maxRange <= 0 || maxRange > 10000)
            throw new InvalidDataException("Invalid vehicle target authority.");
        var distance = Vector3.Distance(origin, target);
        if (!float.IsFinite(distance) || distance > maxRange + .001f)
            throw new InvalidDataException("Vehicle target is outside the trusted range.");
        return new VehicleTarget(ownerPlayerId, targetPlayerId, origin, target, distance);
    }
}
