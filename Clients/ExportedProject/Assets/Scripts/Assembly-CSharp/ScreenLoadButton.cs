public class ScreenLoadButton : GuiElement
{
	public bool Goback;

	public GuiScreen LoadScreen;

	public float delay;

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}

	private void OnClick()
	{
		if (Singleton<GuiManager>.instance.currentScreen.isFullyShowed)
		{
			if (Goback && Singleton<GuiManager>.instance.currentScreen.previousScreen != null)
			{
				Singleton<GuiManager>.instance.ShowGui(Singleton<GuiManager>.instance.currentScreen.previousScreen);
			}
			else if (LoadScreen != null)
			{
				Singleton<GuiManager>.instance.ShowGui(LoadScreen);
			}
		}
	}
}
