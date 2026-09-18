public class SpecialOfferRecord : Core_BaseScript
{
	private void OnPress(bool isPressed)
	{
		if (isPressed)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.DragStart();
		}
		else
		{
			GuiElementSingle<SpecialOfferDialog>.instance.DragDone();
		}
	}
}
