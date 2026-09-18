using UnityEngine;

public class GoldBoosterRecord : Core_BaseScript
{
	[Header("Core")]
	public int number;

	public UISprite goldIcon;

	public UILabel dayLabel;

	public UISprite line;

	public UILabel collectedLabel;

	public void Initialize(bool collected)
	{
		goldIcon.alpha = ((!collected) ? 0.375f : 1f);
		dayLabel.text = Localization.LocalizeFormat("ID_DAYX", number);
		float x = 540f - (178f + dayLabel.relativeSize.x * dayLabel.transform.localScale.x);
		line.transform.localScale = new Vector3(x, line.transform.localScale.y, line.transform.localScale.z);
		collectedLabel.color = ((!collected) ? Color.white : Colours.goldBooster);
		collectedLabel.text = Localization.Localize((!collected) ? "ID_NOTCOLLECTED" : "ID_COLLECTED");
	}
}
