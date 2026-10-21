using System.Numerics;

namespace War.BattleServer;

internal sealed record CardGrenadierBlastHit(CombatDamageType Kind,
    float RawDamage);

/// <summary>
/// GrenadeAmmo creates ExplosionInfo with playerRadiusCoef = 0.7.
/// Explosion.MissileExplode chooses the nearest overlapping collider, then
/// uses its root position for the outer-ring damage interpolation.
/// </summary>
internal static class CardGrenadierExplosionDamage
{
    private const float PlayerRadiusRatio = .7f;

    internal static CardGrenadierBlastHit? ResolvePlayer(Vector3 explosion,
        PlayerCollisionModel pose, Vector3 playerRoot,
        ArmyGrenadeDamageStats damage, ArmyCardGrenadierRuntime setup,
        bool shieldNearby)
    {
        Validate(explosion, damage, setup);
        if (pose == null || pose.Role != "gameplay" ||
            pose.PoseKind == "serialized-reference-only" ||
            !PlayerHitbox.Finite(playerRoot))
            throw new InvalidDataException(
                "Card Grenadier needs a current player collision pose.");

        // MissileExplode gathers with the full hurt radius before applying playerRadiusCoef to bounds distance.
        var nearest = pose.Parts
            .Where(part => part.OverlapsSphere(explosion, setup.OuterRadius))
            .Select(part => new
            {
                Part = part,
                Distance = part.BoundsDistanceToPoint(explosion)
            })
            .OrderBy(row => row.Distance)
            .ThenBy(row => row.Part.SourcePath, StringComparer.Ordinal)
            .FirstOrDefault();
        if (nearest == null)
            return null;

        float shieldRatio = shieldNearby ? setup.PlayerBehindShieldRatio : 1f;
        if (nearest.Distance < setup.InnerRadius * PlayerRadiusRatio)
            return new CardGrenadierBlastHit(CombatDamageType.Explosion,
                damage.Explosion * shieldRatio);

        if (nearest.Distance > setup.OuterRadius * PlayerRadiusRatio)
        {
            return null;
        }

        float rootDistance = Vector3.Distance(playerRoot, explosion);
        return new CardGrenadierBlastHit(CombatDamageType.Shiver,
            RingDamage(rootDistance, damage, setup) * shieldRatio);
    }

    internal static CardGrenadierBlastHit? ResolveDynamic(Vector3 explosion,
        float closestColliderDistance, Vector3 targetRoot,
        ArmyGrenadeDamageStats damage, ArmyCardGrenadierRuntime setup)
    {
        Validate(explosion, damage, setup);
        if (!float.IsFinite(closestColliderDistance) ||
            closestColliderDistance < 0f ||
            !PlayerHitbox.Finite(targetRoot))
            throw new InvalidDataException(
                "Card Grenadier has invalid dynamic target geometry.");
        if (closestColliderDistance > setup.OuterRadius)
            return null;
        if (closestColliderDistance < setup.InnerRadius)
            return new CardGrenadierBlastHit(CombatDamageType.Explosion,
                damage.Explosion);
        return new CardGrenadierBlastHit(CombatDamageType.Shiver,
            RingDamage(Vector3.Distance(explosion, targetRoot),
                damage, setup));
    }

    internal static CardGrenadierBlastHit? ResolveArmy(Vector3 explosion,
        Vector3 targetRoot, IReadOnlyList<PlayerHitbox> parts,
        ArmyGrenadeDamageStats damage, ArmyCardGrenadierRuntime setup)
    {
        Validate(explosion, damage, setup);
        if (!PlayerHitbox.Finite(targetRoot) || parts == null ||
            parts.Any(part => part == null))
            throw new InvalidDataException(
                "Card Grenadier needs current army hitboxes.");

        PlayerHitbox? nearest = parts
            .Where(part => part.OverlapsSphere(explosion,
                setup.OuterRadius))
            .OrderBy(part => part.BoundsDistanceToPoint(explosion))
            .ThenBy(part => part.SourcePath, StringComparer.Ordinal)
            .FirstOrDefault();
        return nearest == null ? null : ResolveDynamic(explosion,
            nearest.BoundsDistanceToPoint(explosion), targetRoot,
            damage, setup);
    }

    private static float RingDamage(float rootDistance,
        ArmyGrenadeDamageStats damage, ArmyCardGrenadierRuntime setup)
    {
        float weight = Math.Clamp(1f - (rootDistance - setup.InnerRadius) /
            (setup.OuterRadius - setup.InnerRadius), 0f, 1f);
        return damage.Minimum +
            (damage.Explosion - damage.Minimum) * weight * weight;
    }

    private static void Validate(Vector3 explosion,
        ArmyGrenadeDamageStats damage, ArmyCardGrenadierRuntime setup)
    {
        if (!PlayerHitbox.Finite(explosion) || damage == null ||
            setup == null || !float.IsFinite(damage.Minimum) ||
            damage.Minimum < 0f || damage.Minimum > 10_000_000f ||
            !float.IsFinite(damage.Explosion) ||
            damage.Explosion < damage.Minimum ||
            damage.Explosion > 10_000_000f ||
            !float.IsFinite(setup.InnerRadius) ||
            !float.IsFinite(setup.OuterRadius) ||
            setup.InnerRadius <= 0f ||
            setup.OuterRadius <= setup.InnerRadius ||
            !float.IsFinite(setup.PlayerBehindShieldRatio) ||
            setup.PlayerBehindShieldRatio is < 0f or > 1f)
            throw new InvalidDataException(
                "Card Grenadier explosion authority is invalid.");
    }
}
