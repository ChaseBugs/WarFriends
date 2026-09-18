using Google2u;
using UnityEngine;

public class UpgradeSlotsAssaultHelicopter : UpgradeSlotsVehicle<DBUpgradeSlotsDrone>
{
	public override float damage => (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");

	public override Perk PerkImplementation(UnitUpgradeDefinition def, Perk currentPerk)
	{
		int rowIndex = Mathf.Clamp(def.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		Perk perk = new Perk();
		perk.speedCoef = 1f + num;
		perk.buffCount = 1;
		Perk perk2 = perk;
		return perk2 * currentPerk;
	}

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		base.LoadDefinitionFromXLS(def, rowIndex);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)def;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(rowIndex, "glassHP");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(rowIndex, "speed");
	}
}
