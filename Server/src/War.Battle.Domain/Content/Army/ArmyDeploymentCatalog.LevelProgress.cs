namespace War.BattleServer;

public sealed partial class ArmyDeploymentCatalog
{
    /// <summary>Uses UpgradeSlots.GetActualLevelForIndex / maxLevelOfUnit for secondary card actors.</summary>
    internal float NormalLevelProgress(string unitId, int normalUpgradeIndex)
    {
        _ = BaseStats(unitId, normalUpgradeIndex);
        if (_startingLevels == null || !_startingLevels.TryGetValue(unitId, out int startingLevel) ||
            normalLaneEnds == null || !normalLaneEnds.TryGetValue(unitId, out int normalCount))
        {
            throw new InvalidDataException("Secondary actor progress requires validated source level bounds.");
        }

        // UpgradeSlot.maxPower counts normal Tier rows; maxLevelOfUnit adds STARTINGLEVEL, not the last index.
        int actualLevel = checked(normalUpgradeIndex + startingLevel);
        int maximumLevel = checked(normalCount + startingLevel);
        return (float)actualLevel / maximumLevel;
    }
}
