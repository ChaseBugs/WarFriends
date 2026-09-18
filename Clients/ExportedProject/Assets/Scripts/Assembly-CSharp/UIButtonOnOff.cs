using System;

public class UIButtonOnOff : UIButton
{
	public bool IsOn = true;

	public UISprite OffSprite;

	public Action<bool> StateChanged;

	protected override void OnEnable()
	{
		base.OnEnable();
		if (IsOn)
		{
			OffSprite.alpha = 0f;
		}
		OffSprite.gameObject.SetActive(!IsOn);
	}

	public override void OnPress(bool isPressed)
	{
		base.OnPress(isPressed);
		if (!isPressed)
		{
			IsOn = !IsOn;
			if (!IsOn)
			{
				OffSprite.gameObject.SetActive(value: true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OffSprite.gameObject, 0.3f, (!IsOn) ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(OnFinished));
			if (StateChanged != null)
			{
				StateChanged(IsOn);
			}
		}
	}

	private void OnFinished(UITweener tween)
	{
		if (IsOn)
		{
			OffSprite.gameObject.SetActive(value: false);
		}
	}
}
