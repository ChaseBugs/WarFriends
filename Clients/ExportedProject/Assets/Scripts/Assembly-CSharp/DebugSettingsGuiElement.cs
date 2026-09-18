public class DebugSettingsGuiElement : GuiElement
{
	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		base.gameObject.SetActive(value: false);
	}
}
