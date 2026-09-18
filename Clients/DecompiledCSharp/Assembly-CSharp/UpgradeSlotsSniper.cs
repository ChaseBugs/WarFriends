using Google2u;
using UnityEngine;

public class UpgradeSlotsSniper : UpgradeSlotsBaseSoldier<DBUpgradeSlotsSniper>
{
	public override Perk PerkImplementation(UnitUpgradeDefinition def, Perk currentPerk)
	{
		int rowIndex = Mathf.Clamp(def.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		Perk perk = new Perk();
		perk.accuracyCoef = 1f + num;
		perk.buffCount = 1;
		Perk perk2 = perk;
		return perk2 * currentPerk;
	}
}
