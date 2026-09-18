using System;
using UnityEngine;

public class ArmyLeftBuffProgress : Core_BaseScript
{
	[Header("-Core")]
	[SerializeField]
	private UISprite mProgressBackground;

	[SerializeField]
	private UISprite mEliteIcon;

	[SerializeField]
	private UILabel mProgressLabel;

	[SerializeField]
	private UISprite mFlash;

	private LevelBehaviour mUnit;

	private int mCurrentParts;

	private int mUpgradeCostParts;

	private bool mAnimatingSpend;

	private float mDuration;

	private float mTimeOfAnimation;

	public bool isAnimatingSpend => mAnimatingSpend;

	public void Initialize(LevelBehaviour unit)
	{
		mUnit = unit;
		UpgradeSlotElite upgradeSlotElite = mUnit.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		int num = (isUnlocked ? upgradeSlotElite.boughtIndex : 0);
		int num2 = (isUnlocked ? upgradeSlotElite.actualMaxLevel : 0);
		bool flag = isUnlocked && num == num2;
		mCurrentParts = upgradeSlotElite.currentParts;
		mUpgradeCostParts = upgradeSlotElite.upgradePriceParts;
		float progress = upgradeSlotElite.progress;
		mEliteIcon.spriteName = mUnit.upgradeSlots.iconNameElite;
		mEliteIcon.MakePixelPerfect();
		if (mUnit.isSoldier)
		{
			mEliteIcon.pivot = UIWidget.Pivot.Bottom;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(-56f);
			float multiplier = 120f / mEliteIcon.transform.localScale.y;
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			mEliteIcon.pivot = UIWidget.Pivot.Center;
			mEliteIcon.transform.localPosition = mEliteIcon.transform.localPosition.ReplaceY(0f);
			float multiplier2 = Mathf.Min(174f / mEliteIcon.transform.localScale.x, 110f / mEliteIcon.transform.localScale.y);
			mEliteIcon.transform.localScale = mEliteIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mProgressBackground.fillAmount = ((!flag) ? progress : 1f);
		mProgressLabel.text = ((!flag) ? $"{Colours.stringGreenArena}{MiscTools.FormatBigNumber(mCurrentParts)}[-] {Colours.stringGray}/[-] {MiscTools.FormatBigNumber(mUpgradeCostParts)}" : $"{Colours.stringGreenArena}{MiscTools.FormatBigNumber(mCurrentParts)}[-]");
		bool animate = isUnlocked && !flag && mCurrentParts >= mUpgradeCostParts;
		PulsateProgressBar(animate);
		FinishAnimations();
	}

	public void AnimateSpend(float duration)
	{
		mAnimatingSpend = true;
		mDuration = duration;
		mTimeOfAnimation = 0f;
		PulsateProgressBar(animate: false);
	}

	private void PulsateProgressBar(bool animate)
	{
		if (animate)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mProgressBackground.gameObject, 0.4f, 0.258f, 0.656f);
			tweenAlpha.style = UITweener.Style.PingPong;
			tweenAlpha.NumOfRepetitions = 0;
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(mProgressBackground.gameObject, 0.1f, 0.258f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void FinishAnimations()
	{
		mAnimatingSpend = false;
		TweenAlpha component = mFlash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mFlash.alpha = 0f;
	}

	private float EaseInOutValue(float value)
	{
		value -= Mathf.Sin(value * ((float)Math.PI * 2f)) / ((float)Math.PI * 2f);
		return value;
	}

	private void Update()
	{
		if (!mAnimatingSpend)
		{
			return;
		}
		mTimeOfAnimation += Time.deltaTime;
		if (mTimeOfAnimation < mDuration)
		{
			float num = EaseInOutValue(Mathf.Clamp01(mTimeOfAnimation / mDuration));
			int currentParts = mUnit.upgradeSlots.upgradeSlotElite.currentParts;
			int num2 = currentParts + Mathf.RoundToInt((1f - num) * (float)(mCurrentParts - currentParts));
			mProgressBackground.fillAmount = (float)num2 / (float)mUpgradeCostParts;
			mProgressLabel.text = $"{Colours.stringGreenArena}{MiscTools.FormatBigNumber(num2)}[-] {Colours.stringGray}/[-] {MiscTools.FormatBigNumber(mUpgradeCostParts)}";
		}
		else
		{
			mAnimatingSpend = false;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 0.02f, 0f, 1f);
			tweenAlpha.onFinished = delegate
			{
				GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.buffDialog.UpdateLeftContent();
				mFlash.alpha = 1f;
				TweenAlpha.Begin(mFlash.gameObject, 0.2f, 1f, 0f).onFinished = null;
			};
		}
	}
}
