using UnityEngine;

public class LeagueButton : SquadButton
{
	[Header("Additional")]
	public UISprite icon;

	private float mSpaceBetween = 16f;

	protected override float mInsideWidth => Mathf.Max(minimalWidth, icon.transform.localScale.x + mSpaceBetween + buttonName.relativeSize.x * buttonName.transform.localScale.x);

	public override void Initialize(string nameOfButton, float duration, bool toHighlight = false)
	{
		mDuration = duration;
		buttonName.text = nameOfButton;
		float num = buttonName.relativeSize.x * buttonName.transform.localScale.x;
		float x = icon.transform.localScale.x;
		float num2 = x + mSpaceBetween + num;
		icon.transform.localPosition = icon.transform.localPosition.ReplaceX((0f - num2) / 2f + x / 2f);
		buttonName.transform.localPosition = buttonName.transform.localPosition.ReplaceX(num2 / 2f - num / 2f);
		if (buttonSetter != null)
		{
			buttonSetter.SetWidth(mInsideWidth + mSpaceAround);
		}
		InstantAnimate(toHighlight);
	}
}
