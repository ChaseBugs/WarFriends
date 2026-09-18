using Google2u;
using UnityEngine;

public class UpgradeSlotsShotgunner : UpgradeSlotsBaseSoldier<DBUpgradeSlotsShotgunner>
{
	public override Perk PerkImplementation(UnitUpgradeDefinition def, Perk currentPerk)
	{
		int rowIndex = Mathf.Clamp(def.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		Perk perk = new Perk();
		perk.hpCoef = 1f - num;
		perk.debuffCount = 1;
		Perk perk2 = perk;
		return perk2 * currentPerk;
	}
}
