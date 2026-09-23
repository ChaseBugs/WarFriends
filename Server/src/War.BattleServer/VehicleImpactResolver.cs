using System.Numerics;

namespace War.BattleServer;

internal sealed record VehicleImpact(ulong EntityId, string AttackerPlayerId,
    string VictimPlayerId, Vector3 Position, float Damage, float Distance);

internal static class VehicleImpactResolver
{
    internal static VehicleImpact Resolve(ulong entityId, string attackerPlayerId,
        string victimPlayerId, Vector3 origin, Vector3 hitPosition, float radius, float trustedDamage)
    {
        if (entityId == 0 || !Guid.TryParseExact(attackerPlayerId, "N", out _) ||
            !Guid.TryParseExact(victimPlayerId, "N", out _) || attackerPlayerId == victimPlayerId ||
            !PlayerHitbox.Finite(origin) || !PlayerHitbox.Finite(hitPosition) ||
            !float.IsFinite(radius) || radius <= 0 || radius > 10000 ||
            !float.IsFinite(trustedDamage) || trustedDamage <= 0 || trustedDamage > 10_000_000)
            throw new InvalidDataException("Invalid vehicle impact authority.");
        var distance = Vector3.Distance(origin, hitPosition);
        if (!float.IsFinite(distance) || distance > radius + .001f)
            throw new InvalidDataException("Vehicle impact is outside its trusted range.");
        return new VehicleImpact(entityId, attackerPlayerId, victimPlayerId, hitPosition, trustedDamage, distance);
    }
}
