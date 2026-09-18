public class ArenaWonMessage : DatabaseMessage
{
	public int mWonBattles;

	private bool mIsFlawless;

	public ArenaWonMessage(int wonBattles, bool isFlawless)
		: base("ArenaWonMessage", Type.ArenaWonMessage)
	{
		mIsFlawless = isFlawless;
		mWonBattles = wonBattles;
		messageId += string.Format("-{0}-{1}", (WarArena.instance.data != null) ? WarArena.instance.data.arenaId : "null", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ArenaWonDialog>.instance.ShowDialog(mIsFlawless, mWonBattles);
	}
}
