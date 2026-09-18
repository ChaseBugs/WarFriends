public class ArenaUnlockedMessage : DatabaseMessage
{
	public ArenaUnlockedMessage()
		: base("ArenaUnlockedMessage", Type.TimeLimitedOffer)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ArenaUnlockedDialog>.instance.ShowDialog();
	}
}
