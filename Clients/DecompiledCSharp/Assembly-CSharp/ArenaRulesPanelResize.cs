using UnityEngine;

public class ArenaRulesPanelResize : Core_BaseScript
{
	[Header("Background")]
	public UISprite background;

	public UISprite backgroundFill;

	[Header("Left Content")]
	public UILabel hintLabel;

	public UISprite rewardsBorder;

	public UISprite rewardsBorderFill;

	public UIPanel rewards;

	[Header("Right Content")]
	public GameObject content;

	public UIPanel heroes;

	public UISprite infoBackground;

	public static float doublePadding => 120f;

	public static float contentWidth => (UIRoot.list[0].activeWidth - doublePadding - 622f) / 2f - 120f;

	public void Rescale()
	{
		float val = UIRoot.list[0].activeWidth - doublePadding;
		background.transform.localScale = background.transform.localScale.ReplaceX(val);
		backgroundFill.transform.localScale = backgroundFill.transform.localScale.ReplaceX(val);
		float num = contentWidth;
		hintLabel.lineWidth = (int)num;
		rewardsBorder.transform.localScale = rewardsBorder.transform.localScale.ReplaceX(num);
		rewardsBorderFill.transform.localScale = rewardsBorderFill.transform.localScale.ReplaceX(num);
		rewards.clipRange = rewards.clipRange.ReplaceZ(num - 4f);
		rewards.transform.localPosition = rewards.transform.localPosition.ReplaceX(num / 2f);
		content.transform.localPosition = content.transform.localPosition.ReplaceX(num / 2f);
		heroes.clipRange = heroes.clipRange.ReplaceZ(num);
		infoBackground.transform.localScale = infoBackground.transform.localScale.ReplaceX(num);
	}
}
