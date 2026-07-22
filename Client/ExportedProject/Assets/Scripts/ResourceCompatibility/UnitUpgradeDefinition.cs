using UnityEngine.Scripting;

[Preserve]
public class UnitUpgradeDefinition
{
	public bool isEquipped;

	public bool isNew;

	public bool isCovert;

	public int tier;

	public UpgradeSlots.UnitUpgrades unitUpgrades;

	public int index;

	public bool enabled;

	public UnitUpgradeDefinition(bool isEquipped, UpgradeSlots.UnitUpgrades upgradeIndex, bool isNew, int tier, bool isCovert)
	{
	}

	public UnitUpgradeDefinition()
	{
	}

	public override string ToString()
	{
		return null;
	}

	public static UpgradeSlots.UnitUpgrades GetPreviewUpgrades(LevelBehaviour behavior, float scale = 1f)
	{
		return default(UpgradeSlots.UnitUpgrades);
	}
}
