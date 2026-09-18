using System;

public class WarArenaRuleCoolDown : WarArenaRuleGeneric<WarArenaRuleCoolDown.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float coolDownMultiplier = 1f;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		if (data.coolDownMultiplier > 1f)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SLOWERDEPLOYMENT"));
		}
		if (data.coolDownMultiplier < 1f)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_FASTERDEPLOYMENT"));
		}
		return base.GetGenericRule();
	}

	public override void ApplyRule()
	{
		base.ApplyRule();
		Singleton<SpawningManagerDeathMatch>.instance.coolDownMultiplier = data.coolDownMultiplier;
	}
}
