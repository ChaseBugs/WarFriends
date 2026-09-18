using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class UpgradeSlotsGrennader : UpgradeSlotsBaseSoldier<DBUpgradeSlotsShotgunner>
{
	public override string shotDamageName => Localization.Localize("ID_GRENADEDAMAGE");

	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "GrenadeExplodeDamage");
		}
	}

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int rowIndex = upgradeSlot.boughtIndex;
			float val = (float)base.excel.GetValue(rowIndex, "damage");
			list.Add(new Tuple<string, float>("ID_PISTOLDAMAGE", val));
			return list;
		}
	}

	public override Perk PerkImplementation(UnitUpgradeDefinition def, Perk currentPerk)
	{
		int rowIndex = Mathf.Clamp(def.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		Perk perk = new Perk();
		perk.accuracyCoef = 1f - num;
		perk.debuffCount = 1;
		Perk perk2 = perk;
		return perk2 * currentPerk;
	}

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)def;
		base.LoadDefinitionFromXLS((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, rowIndex);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(rowIndex, "GrenadeExplodeDamage");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(rowIndex, "GrenadeMinDamage");
	}
}
