public class ElitePerkTutorialMessage : DatabaseMessage
{
	public ElitePerkTutorialMessage()
		: base("ElitePerkTutorialMessage", Type.ElitePerkTutorialMessage)
	{
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ElitePerkTutorialDialog>.instance.ShowDialog();
	}
}
