using System;
using System.Collections.Generic;

public class GrenadeBaseLevelsSetup<T> : WeaponLevelsSetup<T> where T : LevelManager.WeaponLevelDefinition
{
	public override float shotDamage => Convert.ToSingle(uprgradesExcel.GetValue(upgradeSlots.boughtIndex, "explodeDamage"));

	public override LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data, int level)
	{
		T val = (T)baseDefinition.Copy();
		val.Zero();
		val.rateOfFire = 0f;
		UpgradeSlot upgradeSlot = upgradeSlots;
		int rowIndex = (data.HasValue ? data.Value : upgradeSlot.boughtIndex);
		T val2 = val;
		val2.rateOfFire = (float)val2.rateOfFire + (float)uprgradesExcel.GetValue(rowIndex, "reloadTime");
		T val3 = val;
		val3.damageAmount = (float)val3.damageAmount + (float)uprgradesExcel.GetValue(rowIndex, "damage");
		T val4 = val;
		val4.ammoCount = (int)val4.ammoCount + (int)uprgradesExcel.GetValue(rowIndex, "ammo");
		return val;
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(statsFor(slot, "attack", "ID_SLOTUPGRADE_POWER"));
		list.Add(statsFor(slot, "ammo", "ID_SLOTUPGRADE_AMMO"));
		list.Add(statsFor(slot, "reloadTime", "ID_SLOTUPGRADE_ROF"));
		return list;
	}
}
