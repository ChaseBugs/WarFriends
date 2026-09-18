public class PoisonGrenadeLevelsSetup : GrenadeBaseLevelsSetup<PoisonGrenadeLevelDefinition>
{
	public override LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data, int level)
	{
		LevelManager.WeaponLevelDefinition weaponLevelDefinition = base.SetUpWeapon(data, level);
		PoisonGrenadeLevelDefinition poisonGrenadeLevelDefinition = (PoisonGrenadeLevelDefinition)weaponLevelDefinition;
		UpgradeSlot upgradeSlot = upgradeSlots;
		int rowIndex = (data.HasValue ? data.Value : upgradeSlot.boughtIndex);
		poisonGrenadeLevelDefinition.radius += (float)uprgradesExcel.GetValue(rowIndex, "Radius");
		poisonGrenadeLevelDefinition.time += (float)uprgradesExcel.GetValue(rowIndex, "Time");
		return weaponLevelDefinition;
	}
}
