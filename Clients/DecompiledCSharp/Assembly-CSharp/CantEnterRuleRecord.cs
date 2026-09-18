using UnityEngine;

public class CantEnterRuleRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite icon;

	public UILabel title;

	public UILabel hintText;

	public void Initialize(WarArenaRule.WarArenaRuleGui rule)
	{
		title.text = rule.alternativeText;
		MiscTools.SetUILabelRescale(title, 47f, 20f, 1000);
		hintText.text = rule.hint;
		float val = -50f - title.relativeSize.x * title.transform.localScale.x / 2f;
		icon.transform.localPosition = icon.transform.localPosition.ReplaceX(val);
	}
}
