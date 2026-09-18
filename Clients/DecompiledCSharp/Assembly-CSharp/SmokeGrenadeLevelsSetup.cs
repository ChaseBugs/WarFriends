public class SmokeGrenadeLevelsSetup : GrenadeBaseLevelsSetup<SmokeGrenadeLevelDefinition>
{
	public override LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data, int level)
	{
		LevelManager.WeaponLevelDefinition weaponLevelDefinition = base.SetUpWeapon(data, level);
		SmokeGrenadeLevelDefinition smokeGrenadeLevelDefinition = (SmokeGrenadeLevelDefinition)weaponLevelDefinition;
		UpgradeSlot upgradeSlot = upgradeSlots;
		int rowIndex = (data.HasValue ? data.Value : upgradeSlot.boughtIndex);
		smokeGrenadeLevelDefinition.radius += (float)uprgradesExcel.GetValue(rowIndex, "Radius");
		smokeGrenadeLevelDefinition.time += (float)uprgradesExcel.GetValue(rowIndex, "Time");
		return weaponLevelDefinition;
	}
}
