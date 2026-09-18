using System;

public class WarArenaRulePlayerHp : WarArenaRuleGeneric<WarArenaRulePlayerHp.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float playerHp;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		return new WarArenaRuleGui("PlayerHp");
	}

	public override bool SetupRule()
	{
		if (data.playerHp > 0f)
		{
			Singleton<GameController>.instance.gameControllerWarArena.SetPlayerHP(data.playerHp);
		}
		return base.SetupRule();
	}
}
