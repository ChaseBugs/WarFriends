using System.Collections.Generic;

public class MinigunLevelsSetup : WeaponLevelsSetup<MinigunLevelDefinition>
{
	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(statsFor(slot, "attack", "ID_SLOTUPGRADE_DAMAGE"));
		list.Add(statsFor(slot, "ammo", "ID_SLOTUPGRADE_AMMO"));
		list.Add(statsFor(slot, "heatTime", "ID_SLOTUPGRADE_HEAT"));
		return list;
	}

	public override LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data, int level)
	{
		MinigunLevelDefinition minigunLevelDefinition = (MinigunLevelDefinition)baseDefinition.Copy();
		minigunLevelDefinition.Zero();
		minigunLevelDefinition.rateOfFire = baseDefinition.rateOfFire;
		int rowIndex = (data.HasValue ? data.Value : upgradeSlots.boughtIndex);
		minigunLevelDefinition.damageAmount = (float)minigunLevelDefinition.damageAmount + (float)uprgradesExcel.GetValue(rowIndex, "damage");
		minigunLevelDefinition.coolDown += (float)uprgradesExcel.GetValue(rowIndex, "heatTime");
		minigunLevelDefinition.ammoCount = (int)minigunLevelDefinition.ammoCount + (int)uprgradesExcel.GetValue(rowIndex, "ammo");
		return minigunLevelDefinition;
	}
}
