using System;

public class WarArenaRuleUnitsHP : WarArenaRuleGeneric<WarArenaRuleUnitsHP.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float healthMultiplier = 1f;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		if (data.healthMultiplier > 1f)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_STRONGERUNITS"));
		}
		if (data.healthMultiplier < 1f)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_WEAKERUNITS"));
		}
		return base.GetGenericRule();
	}

	public override bool SetupRule()
	{
		Singleton<GameController>.instance.gameControllerWarArena.hpCoeficient = data.healthMultiplier;
		return base.SetupRule();
	}
}
