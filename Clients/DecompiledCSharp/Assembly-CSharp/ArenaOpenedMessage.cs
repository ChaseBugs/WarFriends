public class ArenaOpenedMessage : DatabaseMessage
{
	private string mArenaId;

	public ArenaOpenedMessage(string arenaId, bool isArenaOpened)
		: base(string.Empty, Type.ArenaOpenedMessage)
	{
		mArenaId = arenaId;
		messageId = string.Format("{0}-{1}", (!isArenaOpened) ? "ArenaUpcomingMessage" : "ArenaOpenedMessage", mArenaId);
	}

	public override void Show()
	{
		base.Show();
		if (!LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ShowDialog();
		}
	}
}
