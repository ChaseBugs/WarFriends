using System;
using System.Collections.Generic;

public class GrenadeLevelsSetup : GrenadeBaseLevelsSetup<GrenadeLevelDefinition>
{
	public override float shotDamage => Convert.ToSingle(uprgradesExcel.GetValue(upgradeSlots.boughtIndex, "explodeDamage"));

	public override float rateOfFirePerMinute
	{
		get
		{
			if (uprgradesExcel.HasColumn("reloadTime"))
			{
				return 60f / (float)uprgradesExcel.GetValue(upgradeSlots.boughtIndex, "reloadTime");
			}
			return -1f;
		}
	}

	public override LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data, int level)
	{
		GrenadeLevelDefinition grenadeLevelDefinition = (GrenadeLevelDefinition)baseDefinition.Copy();
		grenadeLevelDefinition.Zero();
		UpgradeSlot upgradeSlot = upgradeSlots;
		int rowIndex = (data.HasValue ? data.Value : upgradeSlot.boughtIndex);
		grenadeLevelDefinition.rateOfFire = (float)grenadeLevelDefinition.rateOfFire + (float)uprgradesExcel.GetValue(rowIndex, "reloadTime");
		grenadeLevelDefinition.damageAmount = (float)grenadeLevelDefinition.damageAmount + (float)uprgradesExcel.GetValue(rowIndex, "mindamage");
		grenadeLevelDefinition.explodeDamageAmount = (float)grenadeLevelDefinition.explodeDamageAmount + (float)uprgradesExcel.GetValue(rowIndex, "ExplodeDamage");
		grenadeLevelDefinition.ammoCount = (int)grenadeLevelDefinition.ammoCount + (int)uprgradesExcel.GetValue(rowIndex, "ammo");
		if (uprgradesExcel.HasColumn("DeadRadius"))
		{
			grenadeLevelDefinition.deadRadius = (float)uprgradesExcel.GetValue(rowIndex, "DeadRadius");
			grenadeLevelDefinition.hurtradius = (float)uprgradesExcel.GetValue(rowIndex, "DeadRadius") * 1.5f;
		}
		grenadeLevelDefinition.clipSize = 1;
		grenadeLevelDefinition.playerBehindShieldDamageRatio = base.damageToPlayerBehindShieldRatio;
		return grenadeLevelDefinition;
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
