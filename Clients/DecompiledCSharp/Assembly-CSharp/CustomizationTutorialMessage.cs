public class CustomizationTutorialMessage : DatabaseMessage
{
	public CustomizationTutorialMessage()
		: base("CustomizationTutorialMessage", Type.CustomizationTutorialMessage)
	{
	}

	public override void Show()
	{
		base.Show();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CustomizationsTutorial>.instance, 0f);
	}
}
