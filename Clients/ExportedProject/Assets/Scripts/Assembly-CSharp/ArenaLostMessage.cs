public class ArenaLostMessage : DatabaseMessage
{
	private int mScraps;

	private int mWins;

	private bool mArenaExpired;

	public ArenaLostMessage(int scraps, bool arenaExpired)
		: base("Arena", Type.ArenaLostMessage)
	{
		mScraps = scraps;
		mWins = WarArena.instance.data.wins;
		mArenaExpired = arenaExpired;
		messageId += string.Format("{0}Message-{1}", (!arenaExpired) ? "Lost" : "Ended", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ArenaLostDialog>.instance.ShowDialog(mArenaExpired, mWins, mScraps);
	}
}
