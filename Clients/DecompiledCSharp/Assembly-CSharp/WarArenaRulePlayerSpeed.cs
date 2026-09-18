using System;

public class WarArenaRulePlayerSpeed : WarArenaRuleGeneric<WarArenaRulePlayerSpeed.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float playerSpeed = 1f;
	}

	protected override WarArenaRuleGui GetGenericRule()
	{
		if (data.playerSpeed > 1f)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_PLAYERSMOVEFASTER"));
		}
		if (data.playerSpeed < 1f)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_PLAYERSMOVESLOWER"));
		}
		return base.GetGenericRule();
	}

	public override void ApplyRule()
	{
		base.ApplyRule();
		PlayerController currentPlayer = PlayerController.currentPlayer;
		currentPlayer.speed = data.playerSpeed;
	}
}
