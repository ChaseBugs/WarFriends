using UnityEngine;

public class CardsGuiCloseButton : MonoBehaviour
{
	public CardsGuiElementNew mCardGui;

	private void OnClick()
	{
		mCardGui.OnCloseButtonClick();
	}
}
