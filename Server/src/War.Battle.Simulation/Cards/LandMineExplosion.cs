using System.Numerics;

namespace War.BattleServer;

internal sealed record LandMinePlayerExplosion(string PartPath, CombatDamageType Kind, float RawDamage);
internal sealed record LandMineDynamicExplosion(CombatDamageType Kind, float RawDamage);

internal static class LandMineExplosion
{
    internal static LandMineDynamicExplosion ResolveDynamic(Vector3 origin, float damage,
        LandMineSourceCatalog source, MapDynamicCollider collider) =>
        ResolveDynamic(origin, damage, damage, source, collider);

    internal static LandMineDynamicExplosion ResolveDynamic(Vector3 origin,
        float explosionDamage, float outerDamage, LandMineSourceCatalog source,
        MapDynamicCollider collider)
    {
        if (!PlayerHitbox.Finite(origin) || !ValidDamage(explosionDamage, outerDamage) ||
            source == null || collider == null || source.HurtRadius <= source.DeadRadius ||
            !PlayerHitbox.Finite(collider.TransformPosition) ||
            !PlayerHitbox.Finite(collider.BoundsMin) || !PlayerHitbox.Finite(collider.BoundsMax))
            throw new InvalidDataException("Land Mine dynamic explosion requires source authority.");

        float closest = Vector3.Distance(origin,
            Vector3.Clamp(origin, collider.BoundsMin, collider.BoundsMax));
        float rootDistance = Vector3.Distance(origin, collider.TransformPosition);
        float amount = MineYourStepFalloff.Damage(outerDamage, explosionDamage,
            source.DeadRadius, source.HurtRadius, rootDistance, closest);
        CombatDamageType kind = closest < source.DeadRadius ?
            CombatDamageType.Explosion : CombatDamageType.Shiver;
        return new LandMineDynamicExplosion(kind, amount);
    }

    internal static bool Triggered(Vector3 minePosition, LandMinePrefabSource prefab,
        PlayerCollisionModel pose)
    {
        if (!PlayerHitbox.Finite(minePosition) || prefab == null || pose == null ||
            pose.Role != "gameplay" || pose.PoseKind == "serialized-reference-only")
            throw new InvalidDataException("Land Mine trigger requires current host authority.");
        return Triggered(minePosition, prefab, pose.Parts);
    }

    internal static bool Triggered(Vector3 minePosition, LandMinePrefabSource prefab,
        IReadOnlyList<PlayerHitbox> parts)
    {
        if (!PlayerHitbox.Finite(minePosition) || prefab == null || parts == null ||
            parts.Count is < 1 or > 64)
            throw new InvalidDataException("Land Mine trigger requires current host authority.");
        Vector3 center = minePosition + prefab.TriggerCenter;
        return parts.Any(part => part.OverlapsBox(center, prefab.TriggerSize, Quaternion.Identity));
    }

    internal static LandMinePlayerExplosion? Resolve(Vector3 minePosition, float damage,
        LandMineSourceCatalog source, PlayerCollisionModel pose, Vector3 root) =>
        Resolve(minePosition, damage, damage, source, pose, root);

    internal static LandMinePlayerExplosion? Resolve(Vector3 minePosition,
        float explosionDamage, float outerDamage, LandMineSourceCatalog source,
        PlayerCollisionModel pose, Vector3 root)
    {
        if (!PlayerHitbox.Finite(minePosition) || !PlayerHitbox.Finite(root) ||
            !ValidDamage(explosionDamage, outerDamage) || source == null || pose == null ||
            pose.Role != "gameplay" || pose.PoseKind == "serialized-reference-only")
            throw new InvalidDataException("Land Mine explosion requires current host authority.");
        return Resolve(minePosition, explosionDamage, outerDamage, source, pose.Parts,
            root, source.PlayerRadiusCoefficient);
    }

    internal static LandMinePlayerExplosion? Resolve(Vector3 minePosition, float damage,
        LandMineSourceCatalog source, IReadOnlyList<PlayerHitbox> parts, Vector3 root) =>
        Resolve(minePosition, damage, damage, source, parts, root,
            source?.PlayerRadiusCoefficient ?? 0);

    internal static LandMinePlayerExplosion? Resolve(Vector3 minePosition,
        float explosionDamage, float outerDamage, LandMineSourceCatalog source,
        IReadOnlyList<PlayerHitbox> parts, Vector3 root, float radiusCoefficient)
    {
        if (!PlayerHitbox.Finite(minePosition) || !PlayerHitbox.Finite(root) ||
            !ValidDamage(explosionDamage, outerDamage) || source == null || parts == null ||
            parts.Count is < 1 or > 64 || !float.IsFinite(radiusCoefficient) ||
            radiusCoefficient <= 0 || radiusCoefficient > 1)
            throw new InvalidDataException("Land Mine explosion requires current host authority.");

        float deadRadius = source.DeadRadius * radiusCoefficient;
        float hurtRadius = source.HurtRadius * radiusCoefficient;
        var selected = parts.Where(part => part.OverlapsSphere(minePosition, hurtRadius))
            .Select(part => (Part: part, Distance: part.DistanceToPoint(minePosition)))
            .OrderBy(item => item.Distance)
            .ThenBy(item => item.Part.SourcePath, StringComparer.Ordinal)
            .FirstOrDefault();
        if (selected.Part == null) return null;

        CombatDamageType kind = selected.Distance < deadRadius ?
            CombatDamageType.Explosion : CombatDamageType.Shiver;
        float amount = MineYourStepFalloff.Damage(outerDamage, explosionDamage,
            source.DeadRadius, source.HurtRadius,
            Vector3.Distance(minePosition, root), selected.Distance, radiusCoefficient);
        return amount > 0 ? new LandMinePlayerExplosion(selected.Part.SourcePath, kind, amount) : null;
    }

    private static bool ValidDamage(float explosionDamage, float outerDamage) =>
        float.IsFinite(explosionDamage) && float.IsFinite(outerDamage) &&
        outerDamage > 0 && outerDamage <= explosionDamage && explosionDamage <= 10_000_000;
}
