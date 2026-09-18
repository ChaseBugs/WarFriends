using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class UpgradeSlotsCommando : UpgradeSlotsBaseSoldier<DBUpgradeSlotsCommando>
{
	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			if (upgradeSlotSpecial.isBought)
			{
				List<Tuple<string, float>> list = new List<Tuple<string, float>>();
				float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");
				float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "special");
				float val = num * num2;
				list.Add(new Tuple<string, float>("ID_POISONDAMAGE", val));
				return list;
			}
			return base.unitSpecifics;
		}
	}

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(slot, "special", "damage");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[2] * num);
		list.Add(tuple);
		return list;
	}

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial slot)
	{
		int rowIndex = slot.owner.upgradeSlot.boughtIndex;
		float num = (float)slot.owner.excel.GetValue(rowIndex, "damage");
		int boughtIndexAbsolute = slot.boughtIndexAbsolute;
		float num2 = (float)slot.owner.excel.GetValue(boughtIndexAbsolute, "special");
		float num3 = num * num2;
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num3);
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial slot)
	{
		int maxIndexInExcel = slot.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)slot.owner.excel.GetValue(maxIndexInExcel, "damage");
		int maxIndexInExcel2 = slot.maxIndexInExcel;
		float num2 = (float)slot.owner.excel.GetValue(maxIndexInExcel2, "special");
		float num3 = num * num2;
		return MiscTools.FormatFloatNumberRoundZeroOrOne(num3);
	}
}
