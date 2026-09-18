using UnityEngine;

public class InappButtonSpecial : InappButton
{
	[Header("Locked")]
	public UIPanel lockPanel;

	public UISprite lockedIcon;

	public BoxCollider buttonCollider;

	private bool mIsLocked;

	private float mAlphaBorderLockedMax = 0.1f;

	public override TweenAlpha Animate(bool toHighlight)
	{
		if (mIsLocked)
		{
			TweenColor.Begin(buttonName.gameObject, mDuration, Colours.grayLockedCards);
			TweenAlpha.Begin(border.gameObject, mDuration, mAlphaBorderLockedMax);
			return TweenAlpha.Begin(highlight.gameObject, mDuration, 0f);
		}
		return base.Animate(toHighlight);
	}

	public override void InstantAnimate(bool toHighlight)
	{
		if (mIsLocked)
		{
			border.alpha = mAlphaBorderLockedMax;
			highlight.alpha = 0f;
			buttonName.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == lockPanel.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.InstantAnimate(toHighlight);
		}
	}

	public void SetLocked(bool isLocked)
	{
		mIsLocked = isLocked;
		lockedIcon.gameObject.SetActive(mIsLocked);
		buttonCollider.enabled = !mIsLocked;
		if (mIsLocked)
		{
			InstantAnimate(toHighlight: false);
		}
	}
}
