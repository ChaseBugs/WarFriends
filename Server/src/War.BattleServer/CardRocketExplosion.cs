using System.Numerics;

namespace War.BattleServer;

internal sealed record CardRocketPlayerHit(CombatDamageType Kind, float RawDamage);
internal sealed record CardRocketDynamicHit(CombatDamageType Kind, float RawDamage);

/// <summary>
/// The Rocket card uses Explosion.MissileExplode with the BazookaEnemy
/// prefab's 0.8/1.2 unit radii. Its damage comes from the card at launch.
/// </summary>
internal static class CardRocketExplosion
{
    private const float DeadRadius = .8f;
    private const float HurtRadius = 1.2f;

    internal static IReadOnlyList<MapDynamicCollider> ClosestColliders(
        Vector3 impact, IReadOnlyList<MapDynamicCollider> overlaps)
    {
        if (!PlayerHitbox.Finite(impact) || overlaps == null ||
            overlaps.Any(collider => collider == null ||
                string.IsNullOrEmpty(collider.DynamicOwner)))
            throw new InvalidDataException("Rocket explosion needs valid overlap owners.");

        return overlaps.GroupBy(collider => collider.DynamicOwner,
                StringComparer.Ordinal)
            .Select(group => group.OrderBy(collider => Vector3.Distance(impact,
                    Vector3.Clamp(impact, collider.BoundsMin, collider.BoundsMax)))
                .ThenBy(collider => collider.ColliderIndex).First())
            .OrderBy(collider => collider.ColliderIndex)
            .ToArray();
    }

    internal static CardRocketDynamicHit ResolveDynamic(Vector3 impact,
        MapDynamicCollider collider, ArmyCardRocketRuntime missile)
    {
        ValidateMissile(impact, missile);
        if (collider == null || !PlayerHitbox.Finite(collider.TransformPosition) ||
            !PlayerHitbox.Finite(collider.BoundsMin) ||
            !PlayerHitbox.Finite(collider.BoundsMax))
            throw new InvalidDataException("Rocket explosion needs a valid dynamic collider.");

        float distance = Vector3.Distance(impact,
            Vector3.Clamp(impact, collider.BoundsMin, collider.BoundsMax));
        if (distance < DeadRadius)
            return new CardRocketDynamicHit(CombatDamageType.Explosion,
                missile.ExplosionDamage);

        float rootDistance = Vector3.Distance(collider.TransformPosition, impact);
        float fraction = Math.Clamp(1f - (rootDistance - DeadRadius) /
            (HurtRadius - DeadRadius), 0f, 1f);
        float damage = missile.DirectDamage +
            (missile.ExplosionDamage - missile.DirectDamage) * fraction * fraction;
        return new CardRocketDynamicHit(CombatDamageType.Shiver, damage);
    }

    internal static CardRocketPlayerHit? ResolvePlayer(Vector3 impact,
        PlayerCollisionModel pose, Vector3 playerRoot,
        ArmyCardRocketRuntime missile, bool shieldBetween)
    {
        ValidateMissile(impact, missile);
        if (!PlayerHitbox.Finite(playerRoot) ||
            pose == null || pose.Role != "gameplay" ||
            pose.PoseKind == "serialized-reference-only")
            throw new InvalidDataException("Rocket explosion needs valid launch and pose authority.");

        var closest = pose.Parts
            .Where(part => part.OverlapsSphere(impact, HurtRadius))
            .Select(part => new { Part = part,
                Distance = part.BoundsDistanceToPoint(impact) })
            .OrderBy(row => row.Distance)
            .ThenBy(row => row.Part.SourcePath, StringComparer.Ordinal)
            .FirstOrDefault();
        if (closest == null)
            return null;

        float multiplier = shieldBetween ? missile.PlayerBehindShieldRatio : 1f;
        if (closest.Distance < DeadRadius)
            return new CardRocketPlayerHit(CombatDamageType.Explosion,
                missile.ExplosionDamage * multiplier);

        // The collider chooses the victim, while the root transform sets the
        // falloff in the recovered client's Shiver branch.
        float rootDistance = Vector3.Distance(playerRoot, impact);
        float fraction = Math.Clamp(1f - (rootDistance - DeadRadius) /
            (HurtRadius - DeadRadius), 0f, 1f);
        float rawDamage = missile.DirectDamage +
            (missile.ExplosionDamage - missile.DirectDamage) * fraction * fraction;
        return new CardRocketPlayerHit(CombatDamageType.Shiver,
            rawDamage * multiplier);
    }

    private static void ValidateMissile(Vector3 impact,
        ArmyCardRocketRuntime missile)
    {
        if (!PlayerHitbox.Finite(impact) || missile == null ||
            !float.IsFinite(missile.DirectDamage) || missile.DirectDamage < 0 ||
            !float.IsFinite(missile.ExplosionDamage) ||
            missile.ExplosionDamage < missile.DirectDamage ||
            !float.IsFinite(missile.PlayerBehindShieldRatio) ||
            missile.PlayerBehindShieldRatio is < 0 or > 1)
            throw new InvalidDataException("Rocket explosion needs valid launch authority.");
    }
}
