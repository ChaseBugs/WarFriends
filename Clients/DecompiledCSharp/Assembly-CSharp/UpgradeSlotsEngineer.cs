using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class UpgradeSlotsEngineer : UpgradeSlotsBaseSoldier<DBUpgradeSlotsShotgunner>
{
	public UpgradeSlotsTurret upgradeSlotsTurret;

	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			int rowIndex2 = (int)base.excel.GetValue(rowIndex, "Turret");
			return (float)upgradeSlotsTurret.excel.GetValue(rowIndex2, "damage");
		}
	}

	public override float accuracy
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			int rowIndex2 = (int)base.excel.GetValue(rowIndex, "Turret");
			return (float)upgradeSlotsTurret.excel.GetValue(rowIndex2, "realShotProbability");
		}
	}

	public override float rateOfFire
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			int rowIndex2 = (int)base.excel.GetValue(rowIndex, "Turret");
			float num = (float)upgradeSlotsTurret.excel.GetValue(rowIndex2, "ShotFrequencyMin");
			float num2 = (float)upgradeSlotsTurret.excel.GetValue(rowIndex2, "ShotFrequencyMax");
			return 60f / ((num + num2) * 0.5f);
		}
	}

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(base.boughtIndex, "special");
			if (upgradeSlotSpecial.isBought)
			{
				int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
				list.Add(new Tuple<string, float>("ID_TURRETBUILDTIME", num + (float)base.excel.GetValue(boughtIndexAbsolute, "special")));
			}
			else
			{
				list.Add(new Tuple<string, float>("ID_TURRETBUILDTIME", num));
			}
			return list;
		}
	}

	public override bool isSpecificTime => true;

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

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		SoldierBehaviourDefinititonEngineer soldierBehaviourDefinititonEngineer = (SoldierBehaviourDefinititonEngineer)def;
		base.LoadDefinitionFromXLS((BehaviourDefinititon)soldierBehaviourDefinititonEngineer, rowIndex);
		soldierBehaviourDefinititonEngineer.turretUpgradeLevel += (int)base.excel.GetValue(rowIndex, "Turret");
	}

	private int GetTurretUpgrades(int boughtIndices)
	{
		return (int)base.excel.GetValue(boughtIndices, "Turret");
	}

	public override IEnumerator LoadMineVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		yield return StartCoroutine(base.LoadMineVisualsCoroutine(unitUpgrades, bought));
		UnitUpgrades turretUnitUpgrades = new UnitUpgrades(1f)
		{
			slotUpgradeindex = GetTurretUpgrades(unitUpgrades.slotUpgradeindex)
		};
		yield return StartCoroutine(upgradeSlotsTurret.LoadMineVisualsCoroutine(turretUnitUpgrades, bought));
	}

	public override IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		yield return StartCoroutine(base.LoadOponentVisualsCoroutine(unitUpgrades, bought));
		int turretUpgradeLevel = GetTurretUpgrades(unitUpgrades.slotUpgradeindex);
		UnitUpgrades turretUnitUpgrades = new UnitUpgrades(1f)
		{
			slotUpgradeindex = GetTurretUpgrades(unitUpgrades.slotUpgradeindex)
		};
		yield return StartCoroutine(upgradeSlotsTurret.LoadOponentVisualsCoroutine(turretUnitUpgrades, bought));
	}

	public override void NullOpponentVisuals()
	{
		base.NullOpponentVisuals();
		upgradeSlotsTurret.NullOpponentVisuals();
	}

	public override void NullCardVisuals(bool mine, bool opponent)
	{
		base.NullCardVisuals(mine, opponent);
		upgradeSlotsTurret.NullCardVisuals(mine, opponent);
	}

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "special", "seconds"));
		float value = StartStatsFor(slot, "special", "seconds").Value2;
		list[0].Value2[0] += value;
		list[0].Value2[1] += value;
		list[0].Value2[2] += value;
		return list;
	}

	public override List<Tuple<string, float>> GetGuiStatsSpecialStart(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		list.Add(StartStatsFor(slot, "special", "seconds"));
		return list;
	}

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial slot)
	{
		float num = slot.guiStatistics[0].Value2[0];
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num);
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial slot)
	{
		float num = slot.guiStatistics[0].Value2[1];
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num);
	}

	public override string GetAbilityStartValue(UpgradeSlotSpecial slot)
	{
		float value = slot.guiStatisticsStart[0].Value2;
		return MiscTools.FormatFloatNumberRoundZeroOrOne(value);
	}
}
