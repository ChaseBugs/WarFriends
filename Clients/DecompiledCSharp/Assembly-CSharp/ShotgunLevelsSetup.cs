using System;
using System.Collections.Generic;

public class ShotgunLevelsSetup : WeaponLevelsSetup<ShotgunLevelDefinition>
{
	public override float shotDamage => Convert.ToSingle(uprgradesExcel.GetValue(upgradeSlots.boughtIndex, "maxDamage"));

	public override LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data, int level)
	{
		ShotgunLevelDefinition shotgunLevelDefinition = (ShotgunLevelDefinition)baseDefinition.Copy();
		shotgunLevelDefinition.Zero();
		shotgunLevelDefinition.rateOfFire = baseDefinition.rateOfFire;
		UpgradeSlot upgradeSlot = upgradeSlots;
		int rowIndex = (data.HasValue ? data.Value : upgradeSlot.boughtIndex);
		shotgunLevelDefinition.reloadTime = (float)shotgunLevelDefinition.reloadTime + (float)uprgradesExcel.GetValue(rowIndex, "reloadTime");
		shotgunLevelDefinition.minDamage += (float)uprgradesExcel.GetValue(rowIndex, "minDamage");
		shotgunLevelDefinition.maxDamage += (float)uprgradesExcel.GetValue(rowIndex, "maxDamage");
		shotgunLevelDefinition.clipSize = (int)shotgunLevelDefinition.clipSize + (int)uprgradesExcel.GetValue(rowIndex, "clipSize");
		shotgunLevelDefinition.ammoCount = (int)shotgunLevelDefinition.ammoCount + (int)uprgradesExcel.GetValue(rowIndex, "ammo");
		return shotgunLevelDefinition;
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(statsFor(slot, "attack", "ID_SLOTUPGRADE_DAMAGE"));
		list.Add(statsFor(slot, "clipSize", "ID_SLOTUPGRADE_CLIP_SIZE"));
		list.Add(statsFor(slot, "reloadTime", "ID_SLOTUPGRADE_ROF"));
		list.Add(statsFor(slot, "ammo", "ID_SLOTUPGRADE_AMMO"));
		return list;
	}
}
