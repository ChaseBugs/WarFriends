using System;
using UnityEngine;

public class LeftGoldenSuitcase : Core_BaseScript
{
	public enum SuitcaseState
	{
		None,
		Waiting,
		Ready
	}

	[Header("Core")]
	public BoxCollider buttonCollider;

	public GameObject goldenSuitcaseButton;

	public UIButtonScale buttonScale;

	public UISprite icon;

	public UISprite background;

	public UILabel goldenUpLabel;

	public UILabel whiteDownLabel;

	[Header("Hint Part")]
	public UIPanel hintDialog;

	public BoxCollider hintButtonCollider;

	public UISprite hintButtonSprite;

	public UILabel hintText;

	public UISprite hintBackground;

	private SuitcaseState mPreviousState;

	private int mTimeToShow = -1;

	public void InitEvents()
	{
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += UpdateState;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += UpdateState;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(goldenSuitcaseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GoldenSuitcaseClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(hintButtonCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HintButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(hintDialog.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HintDialogClick));
	}

	private void GoldenSuitcaseClick(GameObject go)
	{
		SuitcaseState actualState = GetActualState();
		if (actualState == SuitcaseState.Ready)
		{
			UpdateLook(forceNone: true);
			AnimateNoneSuitcase();
			mPreviousState = SuitcaseState.None;
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<EventTrackingManager>.instance.ShowRewardedVideo(RewardType.GoldenSuitcase);
		}
	}

	private void HintButtonClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (hintDialog.gameObject.activeSelf)
		{
			HideHint();
		}
		else
		{
			ShowHint();
		}
	}

	private void HintDialogClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideHint();
	}

	private void ShowHint()
	{
		SetHintHeight();
		hintButtonSprite.spriteName = MiscTools.closeButtonSprite;
		hintButtonSprite.MakePixelPerfect();
		hintDialog.gameObject.SetActive(value: true);
		hintDialog.alpha1 = 0.005f;
		TweenAlpha.Begin(hintDialog.gameObject, 0.4f, 1f).onFinished = null;
		hintDialog.transform.localPosition = new Vector3(460f, 81f, -60f);
		TweenPosition tweenPosition = TweenPosition.Begin(hintDialog.gameObject, 0.25f, new Vector3(460f, 81f, -60f), new Vector3(460f, 111f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(hintDialog.gameObject, 0.15f, new Vector3(460f, 101f, -60f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void HideHint()
	{
		hintButtonSprite.spriteName = MiscTools.infoButtonSprite;
		hintButtonSprite.MakePixelPerfect();
		TweenAlpha.Begin(hintDialog.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(hintDialog.gameObject, 0.4f, new Vector3(460f, 121f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			InstantHideHint();
		};
	}

	private void InstantHideHint()
	{
		hintDialog.gameObject.SetActive(value: false);
		hintButtonSprite.spriteName = MiscTools.infoButtonSprite;
		hintButtonSprite.MakePixelPerfect();
	}

	public void InitGuiValues()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateEverySecond));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateEverySecond));
		mPreviousState = SuitcaseState.None;
		SuitcaseState suitcaseState = UpdateLook();
		Debug.Log("Main Screen: Golden Suitcase: Initialize state " + suitcaseState);
		switch (suitcaseState)
		{
		case SuitcaseState.Ready:
			AnimateReadySuitcase(initialization: true);
			break;
		case SuitcaseState.None:
			AnimateNoneSuitcase();
			break;
		default:
			AnimateWaitingSuitcase();
			break;
		}
		mPreviousState = suitcaseState;
		InstantHideHint();
	}

	private void SetHintHeight()
	{
		float num = Mathf.Abs(hintText.transform.localPosition.y) + hintText.relativeSize.y * hintText.transform.localScale.y + 40f;
		hintBackground.transform.localScale = hintBackground.transform.localScale.ReplaceY(num);
		hintButtonCollider.size = hintButtonCollider.size.ReplaceY(num);
		hintButtonCollider.center = hintButtonCollider.center.ReplaceY((0f - num) / 2f);
	}

	private void UpdateWaitTime()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = mTimeToShow - currentTimestamp;
		if (num <= 0)
		{
			UpdateState();
			return;
		}
		whiteDownLabel.text = MiscTools.PrintableTime(num, "ID_NOW", "ID_INTIME").ToUpper();
		MiscTools.SetUILabelRescale(whiteDownLabel, 30f, 20f);
	}

	private SuitcaseState UpdateLook(bool forceNone = false)
	{
		SuitcaseState suitcaseState = ((!forceNone) ? GetActualState() : SuitcaseState.None);
		Debug.Log("Main Screen: Golden Suitcase: update to state: " + suitcaseState);
		switch (suitcaseState)
		{
		case SuitcaseState.None:
			SetUpButton(enabled: false);
			goldenUpLabel.text = string.Empty;
			whiteDownLabel.text = string.Empty;
			break;
		case SuitcaseState.Waiting:
			SetUpButton(enabled: false);
			goldenUpLabel.text = Localization.Localize("ID_NEWSUITCASE");
			MiscTools.SetUILabelRescale(goldenUpLabel, 30f, 20f, 280);
			UpdateWaitTime();
			break;
		case SuitcaseState.Ready:
			SetUpButton(enabled: true);
			goldenUpLabel.text = Localization.Localize("ID_GOLDENSUITCASE");
			MiscTools.SetUILabelRescale(goldenUpLabel, 30f, 20f, 280);
			whiteDownLabel.text = Localization.Localize("ID_AVAILABLE");
			MiscTools.SetUILabelRescale(whiteDownLabel, 30f, 20f);
			break;
		}
		return suitcaseState;
	}

	private void UpdateState()
	{
		if (!GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			return;
		}
		SuitcaseState suitcaseState = UpdateLook();
		if (mPreviousState != suitcaseState)
		{
			switch (suitcaseState)
			{
			case SuitcaseState.Ready:
				AnimateReadySuitcase();
				break;
			case SuitcaseState.None:
				AnimateNoneSuitcase();
				break;
			default:
				AnimateWaitingSuitcase();
				break;
			}
			mPreviousState = suitcaseState;
		}
	}

	public void TestAnimationState(SuitcaseState state)
	{
		if (mPreviousState != state)
		{
			switch (state)
			{
			case SuitcaseState.Ready:
				AnimateReadySuitcase();
				break;
			case SuitcaseState.None:
				AnimateNoneSuitcase();
				break;
			default:
				AnimateWaitingSuitcase();
				break;
			}
			mPreviousState = state;
		}
	}

	private void UpdateEverySecond()
	{
		if (mTimeToShow != -1)
		{
			UpdateWaitTime();
		}
	}

	private SuitcaseState GetActualState()
	{
		if (LevelManager.instance.isGoldenSuitcaseLocked)
		{
			Debug.Log("Main Screen: Golden Suitcase: State Locked. Unlocked at level: " + LevelManager.instance.goldenSuitcaseUnlockLevel);
			return SuitcaseState.None;
		}
		Debug.Log("Main Screen: Golden Suitcase: Time when next golden suitcase: " + Singleton<EventTrackingManager>.instance.timeToNextShowGoldenSuitcase + "\nand preloaded ad: " + Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.None) + "\nwith suitcase check: " + Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.GoldenSuitcase) + "\ncurrent time: " + Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		if (Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.GoldenSuitcase))
		{
			mTimeToShow = -1;
			return SuitcaseState.Ready;
		}
		mTimeToShow = Singleton<EventTrackingManager>.instance.timeToNextShowGoldenSuitcase;
		return (mTimeToShow != -1 && Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.None)) ? SuitcaseState.Waiting : SuitcaseState.None;
	}

	private void AnimateReadySuitcase(bool initialization = false)
	{
		float duration = 0.2f;
		TweenAlpha.Begin(icon.gameObject, duration, 1f);
		TweenAlpha.Begin(background.gameObject, duration, 1f);
		TweenAlpha.Begin(goldenUpLabel.gameObject, duration, 1f);
		TweenAlpha.Begin(whiteDownLabel.gameObject, duration, 1f);
		TweenAlpha.Begin(hintButtonSprite.gameObject, duration, 1f);
		hintButtonCollider.enabled = true;
		buttonCollider.enabled = true;
		LoopingScaleAnimation();
	}

	private void AnimateNoneSuitcase()
	{
		float duration = 0.2f;
		TweenAlpha.Begin(icon.gameObject, duration, 0f);
		TweenAlpha.Begin(background.gameObject, duration, 0f);
		TweenAlpha.Begin(goldenUpLabel.gameObject, duration, 0f);
		TweenAlpha.Begin(whiteDownLabel.gameObject, duration, 0f);
		TweenAlpha.Begin(hintButtonSprite.gameObject, duration, 0f);
		hintButtonCollider.enabled = false;
		buttonCollider.enabled = false;
		EndOfScaleAnimation();
	}

	private void AnimateWaitingSuitcase()
	{
		float duration = 0.2f;
		TweenAlpha.Begin(icon.gameObject, duration, 1f);
		TweenAlpha.Begin(background.gameObject, duration, 1f);
		TweenAlpha.Begin(goldenUpLabel.gameObject, duration, 1f);
		TweenAlpha.Begin(whiteDownLabel.gameObject, duration, 1f);
		TweenAlpha.Begin(hintButtonSprite.gameObject, duration, 1f);
		hintButtonCollider.enabled = true;
		buttonCollider.enabled = false;
		EndOfScaleAnimation();
	}

	private void LoopingScaleAnimation()
	{
		Vector3 vector = new Vector3(110f, 112f, 1f);
		TweenScale tweenScale = TweenScale.Begin(icon.gameObject, 0.4f, vector, vector.MultiplyXY(1.1f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 0;
	}

	private void EndOfScaleAnimation()
	{
		TweenScale tweenScale = TweenScale.Begin(scale: new Vector3(110f, 112f, 1f), go: icon.gameObject, duration: 0.2f);
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	private void SetUpButton(bool enabled)
	{
		buttonScale.hover = ((!enabled) ? Vector3.one : new Vector3(1.1f, 1.1f, 1f));
		buttonScale.pressed = ((!enabled) ? Vector3.one : new Vector3(1.05f, 1.05f, 1f));
		Color lhs = ((!enabled) ? Colours.gray : Color.white);
		icon.color = lhs.ReplaceA(icon.alpha);
	}

	public void DoAfterHide()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateEverySecond));
	}
}
