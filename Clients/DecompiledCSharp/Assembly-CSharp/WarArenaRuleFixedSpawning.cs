using System;

public class WarArenaRuleFixedSpawning : WarArenaRuleGeneric<WarArenaRuleFixedSpawning.Data>
{
	[Serializable]
	public class Data : RuleData
	{
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_FIXEDSPAWNING"));
	}

	public override bool SetupRule()
	{
		base.SetupRule();
		Singleton<GameController>.instance.gameControllerWarArena.SetSpawningType(SpawningType.Fixed);
		return true;
	}
}
