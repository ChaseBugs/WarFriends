using System.Numerics;

namespace War.BattleServer;

/// <summary>Source base flags for a player-owned opposing army-entity death.</summary>
internal static class PvpArmyKillSkillShotPolicy
{
    internal const int Kill = 4096;
    internal const int VehicleDestroyed = 512;
    internal const int TankDestroyed = 16384;
    internal const int ExplosiveKill = 8192;
    internal const int OneHitKill = 16;
    internal const int HeadShot = 1;
    internal const int LongShot = 4;

    /// <summary>
    /// The Client compares the victim and current weapon transform only for
    /// a player-owned Shot death. Equality with the scene distance is short.
    /// </summary>
    internal static int ConfirmedLongShotFlag(
        Vector3 victimRoot, Vector3 weaponRoot, float sourceDistance)
    {
        if (!PlayerHitbox.Finite(victimRoot) ||
            !PlayerHitbox.Finite(weaponRoot) ||
            !float.IsFinite(sourceDistance) || sourceDistance <= 0f)
        {
            throw new InvalidDataException("Long-shot distance lacks finite host positions.");
        }

        float squaredDistance = Vector3.DistanceSquared(victimRoot, weaponRoot);
        float squaredThreshold = sourceDistance * sourceDistance;
        if (!float.IsFinite(squaredDistance) || !float.IsFinite(squaredThreshold))
        {
            throw new InvalidDataException("Long-shot distance exceeds the host float range.");
        }

        return squaredDistance > squaredThreshold ? LongShot : 0;
    }

    /// <summary>
    /// The recovered EnemyController marks a shot death as a headshot only
    /// when its DestroyableObjectpart has index one.
    /// </summary>
    internal static int ConfirmedShotHeadFlag(ShotCollision hit)
    {
        ArgumentNullException.ThrowIfNull(hit);
        if (!hit.DynamicArmyInfantry)
        {
            return 0;
        }

        if (!hit.SourceDestroyable || hit.ColliderLayer is not (22 or 23))
        {
            throw new InvalidDataException(
                "Infantry shot lacks its source destroyable collider.");
        }

        if (hit.SourcePath == EnemyPoseCatalog.ArmyHeadSourcePath &&
            hit.PartWeight == 1.5f)
        {
            return HeadShot;
        }

        if (hit.SourcePath == EnemyPoseCatalog.ArmyBodySourcePath &&
            hit.PartWeight == 1f)
        {
            return 0;
        }

        throw new InvalidDataException(
            "Infantry shot differs from its pinned body and head colliders.");
    }

    /// <summary>
    /// A confirmed lethal damage callback gets OneHitKill when the root
    /// DestroyableObject was at full health before that callback.
    /// </summary>
    internal static int ConfirmedOneHitFlag(float healthBeforeDamage,
        float maximumHealth)
    {
        if (!float.IsFinite(healthBeforeDamage) ||
            !float.IsFinite(maximumHealth) ||
            maximumHealth <= 0f ||
            healthBeforeDamage <= 0f ||
            healthBeforeDamage > maximumHealth)
        {
            throw new InvalidDataException(
                "Confirmed army death has invalid prior health.");
        }

        return healthBeforeDamage >= maximumHealth ? OneHitKill : 0;
    }

    /// <summary>Classifies the recovered victim family without optional kill conditions.</summary>
    internal static int BaseFlags(ArmyDeploymentCatalog catalog, string unitId)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        ArmyDeploymentFamily? family = catalog.Families.SingleOrDefault(
            candidate => candidate.UnitId == unitId);
        if (family == null)
        {
            throw new InvalidDataException("Unknown army victim for a player-owned kill.");
        }

        if (family.IsSoldier)
        {
            return Kill;
        }

        int flags = Kill | VehicleDestroyed;
        if (unitId == "ID_UNIT-TANK")
        {
            flags |= TankDestroyed;
        }

        return flags;
    }

    /// <summary>Adds the source explosion flag for a player-owned blast death.</summary>
    internal static int ExplosionFlags(ArmyDeploymentCatalog catalog, string unitId)
    {
        return BaseFlags(catalog, unitId) | ExplosiveKill;
    }
}
