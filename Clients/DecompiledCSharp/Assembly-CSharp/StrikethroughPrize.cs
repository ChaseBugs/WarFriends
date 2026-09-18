using UnityEngine;

public class StrikethroughPrize : Core_BaseScript
{
	[Header("Setting")]
	public bool isDynamicFont;

	[Header("Labels")]
	public UILabel prizeLabel;

	public UISprite strikeThrought;

	public void SetUpStrikeThrought()
	{
		float y = prizeLabel.transform.localScale.y;
		float num = Mathf.Max(20f, prizeLabel.relativeSize.x * prizeLabel.transform.localScale.x);
		float num2 = ((!isDynamicFont) ? y : Mathf.Round(y / 0.826f));
		float val = Mathf.Sqrt(num * num + num2 * num2);
		float num3 = Vector2.Angle(new Vector2(num2, 0f), new Vector2(num2, num));
		strikeThrought.transform.localScale = strikeThrought.transform.localScale.ReplaceX(val);
		strikeThrought.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - (90f - num3));
	}
}
