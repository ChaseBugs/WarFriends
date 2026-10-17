using System;

/// <summary>Uses original visual loaders without unrelated account-backed upgrade-slot initialization.</summary>
public sealed class AbortUpgradeSlotsProbe : UpgradeSlots
{
    protected override void Awake()
    {
        // This fixture supplies only source visual definitions, not a complete player economy.
    }

    public override UnitUpgrades LoadData(
        LevelBehaviour behaviour,
        UnitUpgrades? boughtUpgrades = null,
        Perk perk = null)
    {
        throw new NotSupportedException("Account upgrade initialization is outside this loading probe.");
    }
}
