public class ArenaGoldenShieldMessage : DatabaseMessage
{
	private int mRemainingSeconds;

	private int mWonBattles;

	public ArenaGoldenShieldMessage(int remainingSeconds, int wonBattles)
		: base(string.Empty, Type.ArenaGoldenShieldMessage)
	{
		mRemainingSeconds = remainingSeconds;
		mWonBattles = wonBattles;
		messageId = $"ArenaGoldenShieldMessage-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ArenaShieldsDialog>.instance.ShowDialog(mWonBattles, mRemainingSeconds);
	}
}
