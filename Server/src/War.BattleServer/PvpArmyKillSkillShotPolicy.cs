namespace War.BattleServer;

/// <summary>Source base flags for a player-owned opposing army-entity death.</summary>
internal static class PvpArmyKillSkillShotPolicy
{
    internal const int Kill = 4096;
    internal const int VehicleDestroyed = 512;
    internal const int TankDestroyed = 16384;

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
}
