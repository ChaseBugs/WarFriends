using UnityEngine;

public class SettingsDebugCheckButton : Core_BaseScript
{
	public BoxCollider buttonCollider;

	public UISprite checkIcon;

	public UILabel checkButtonLabel;

	public void Initialize(string text)
	{
		float num = 62f;
		float num2 = num / 2f;
		checkButtonLabel.text = text;
		float x = checkButtonLabel.transform.localPosition.x;
		float num3 = checkButtonLabel.relativeSize.x * checkButtonLabel.transform.localScale.x;
		float num4 = num2 + x + num3 + 20f;
		buttonCollider.size = buttonCollider.size.ReplaceX(num4);
		buttonCollider.center = buttonCollider.center.ReplaceX(num4 / 2f - 10f - num2);
	}

	public void SetHighlight(bool setHighlight)
	{
		checkIcon.gameObject.SetActive(setHighlight);
	}
}
