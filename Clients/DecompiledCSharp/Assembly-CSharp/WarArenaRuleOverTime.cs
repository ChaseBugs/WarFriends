using System;
using Google2u;

public class WarArenaRuleOverTime : WarArenaRuleGeneric<WarArenaRuleOverTime.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public int overtimeAfter = 120;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		if (data.overtimeAfter < 0)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_NOOVERTIME"));
		}
		if (data.overtimeAfter == 0)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_INSTANTOVERTIME"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_LATEOVERTIME"));
		}
		if (data.overtimeAfter < num)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_EARLYOVERTIME"));
		}
		return base.GetGenericRule();
	}

	public override void ApplyRule()
	{
		base.ApplyRule();
		Singleton<GameController>.instance.gameControllerWarArena.SetOverTime(data.overtimeAfter);
	}
}
