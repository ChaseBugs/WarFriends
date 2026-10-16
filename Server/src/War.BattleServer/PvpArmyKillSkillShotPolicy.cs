namespace War.BattleServer;

/// <summary>Source base flags for a player-owned opposing army-entity death.</summary>
internal static class PvpArmyKillSkillShotPolicy
{
    internal const int Kill = 4096;
    internal const int VehicleDestroyed = 512;
    internal const int TankDestroyed = 16384;
    internal const int ExplosiveKill = 8192;
    internal const int OneHitKill = 16;

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
