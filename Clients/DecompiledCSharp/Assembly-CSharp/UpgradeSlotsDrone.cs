using System.Collections.Generic;
using Google2u;

public class UpgradeSlotsDrone : UpgradeSlotsMechanical<DBUpgradeSlotsDrone>
{
	public override float damage => (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "special", "seconds"));
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
}
