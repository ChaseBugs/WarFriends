using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class UpgradeSlotsCar : UpgradeSlotsVehicle<DBUpgradeSlotsCar>
{
	public override float damage => (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");

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
		float num = (float)slot.owner.excel.GetValue(boughtIndexAbsolute, "special");
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num);
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial slot)
	{
		int maxIndexInExcel = slot.maxIndexInExcel;
		float num = (float)slot.owner.excel.GetValue(maxIndexInExcel, "special");
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num);
	}
}
