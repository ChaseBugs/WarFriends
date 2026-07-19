public class UnitUpgradeDefinition
{
	public bool isEquipped;

	public bool isNew;

	public int tier;

	public UpgradeSlots.UnitUpgrades unitUpgrades;

	public int index;

	public bool enabled = true;

	public UnitUpgradeDefinition(bool isEquipped, UpgradeSlots.UnitUpgrades upgradeIndex, bool isNew, int tier)
	{
		this.isEquipped = isEquipped;
		unitUpgrades = upgradeIndex;
		this.isNew = isNew;
		this.tier = tier;
	}

	public UnitUpgradeDefinition()
	{
	}

	public static UpgradeSlots.UnitUpgrades GetPreviewUpgrades(LevelBehaviour behavior, float scale = 1f)
	{
		return UpgradeSlots.UnitUpgrades.GetPreviewUpgrades(behavior, scale);
	}
}
