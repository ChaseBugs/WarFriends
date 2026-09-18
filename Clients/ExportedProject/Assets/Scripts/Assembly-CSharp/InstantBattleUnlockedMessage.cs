public class InstantBattleUnlockedMessage : DatabaseMessage
{
	public InstantBattleUnlockedMessage()
		: base("InstantBattleUnlockedMessage", Type.InstantBattleUnlockedMessage)
	{
	}

	public override void Show()
	{
		base.Show();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleUnlockDialog>.instance, 0f);
	}
}
