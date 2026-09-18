using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;

public class WarArenaRuleCrates : WarArenaRuleGeneric<WarArenaRuleCrates.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float killStreakRatio = 0.75f;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		if (data.killStreakRatio <= 0f)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_NOCRATES"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_LESSCRATES"));
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_MORECRATES"));
		}
		return base.GetGenericRule();
	}

	public override void ApplyRule()
	{
		Singleton<ScoreManager>.instance.killStreakScoreRatio = data.killStreakRatio;
		base.ApplyRule();
	}
}
