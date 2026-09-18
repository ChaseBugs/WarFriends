using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class UpgradeSlotsCarBuggy : UpgradeSlotsVehicle<DBUpgradeSlotsCarBuggy>
{
	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "CannonDamage");
		}
	}

	public override float rateOfFire
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			if (base.excel.HasColumn("ShotFrequencyMinCannon") && base.excel.HasColumn("ShotFrequencyMaxCannon"))
			{
				float num = (float)base.excel.GetValue(rowIndex, "ShotFrequencyMinCannon");
				float num2 = (float)base.excel.GetValue(rowIndex, "ShotFrequencyMaxCannon");
				return 60f / ((num + num2) * 0.5f);
			}
			return 1f;
		}
	}

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			if (upgradeSlotSpecial.isBought)
			{
				List<Tuple<string, float>> list = new List<Tuple<string, float>>();
				int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
				float val = (float)base.excel.GetValue(boughtIndexAbsolute, "special");
				list.Add(new Tuple<string, float>("ID_SECONDWEAPONDAMAGE", val));
				return list;
			}
			return base.unitSpecifics;
		}
	}

	protected override void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
		base.LoadDefinitionFromXLS(def, rowIndex);
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)def;
		carBuggyBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMaxCannon");
		carBuggyBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(rowIndex, "ShotFrequencyMinCannon");
		carBuggyBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(rowIndex, "CannonDamage");
	}

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(slot, "DPS", "damage");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[2]);
		list.Add(tuple);
		return list;
	}

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial slot)
	{
		int boughtIndexAbsolute = slot.boughtIndexAbsolute;
		float num = (float)base.excel.GetValue(boughtIndexAbsolute, "special");
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num);
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial slot)
	{
		int maxIndexInExcel = slot.maxIndexInExcel;
		float num = (float)base.excel.GetValue(maxIndexInExcel, "special");
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num);
	}
}
