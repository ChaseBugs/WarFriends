public class ChatTutorialMessage : DatabaseMessage
{
	public ChatTutorialMessage()
		: base("ChatTutorialMessage", Type.ChatTutorialMessage)
	{
	}

	public override void Show()
	{
		base.Show();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<UserGeneratedContent>.instance, 0f);
	}
}
