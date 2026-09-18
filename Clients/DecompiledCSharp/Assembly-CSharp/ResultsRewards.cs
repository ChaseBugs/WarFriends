using System.Collections.Generic;
using UnityEngine;

public class ResultsRewards : Core_BaseScript
{
	[Header("Both Rewards")]
	public UIPanel rewardsPanel;

	public UISprite rewardsWBIcon;

	public UISprite rewardsGoldIcon;

	public UILabel rewardsWB;

	public UILabel rewardsGold;

	public UILabel rewardsWBVIP;

	public UILabel rewardsGoldVIP;

	[Header("Settings")]
	public float positionUp = 32f;

	protected TweenAnimator mAnimatorMoney;

	protected TweenAnimator mAnimatorOnlyWB;

	protected IntObject mResultWb = new IntObject(0);

	protected IntObject mResultGold = new IntObject(0);

	protected IntObject mResultWbVIP = new IntObject(0);

	protected IntObject mResultGoldVIP = new IntObject(0);

	protected LongObject mWalletWb = new LongObject(0L);

	protected LongObject mWalletGold = new LongObject(0L);

	public TweenAnimator animatorMoney => mAnimatorMoney;

	public TweenAnimator animatorOnlyWB => mAnimatorOnlyWB;

	public void AnimateShow(float fadeInTime)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(rewardsPanel.gameObject, fadeInTime, 0f, 0f);
		tweenAlpha.method = UITweener.Method.EaseInOut;
	}

	public virtual TweenAnimator InitControls(bool headerAnimation = true)
	{
		mAnimatorMoney = CreateAnimatorForMoney(alsoGold: true, headerAnimation);
		mAnimatorOnlyWB = CreateAnimatorForMoney(alsoGold: false, headerAnimation);
		return mAnimatorMoney;
	}

	protected virtual TweenAnimator CreateAnimatorForMoney(bool alsoGold = true, bool headerAnimation = false)
	{
		float time = 0.4f;
		TweenAnimator tweenAnimator = rewardsPanel.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = rewardsPanel.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, rewardsPanel.gameObject, time, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(from: localPosition + new Vector3(0f, -20f, 0f), id: 2, tweenType: TweenAnimator.TweenType.Position, tweenTarget: rewardsPanel.gameObject, time: time, to: localPosition + new Vector3(0f, 10f, 0f), delay: 0f);
		tweenAnimator.AddTween(3, TweenAnimator.TweenType.Position, rewardsPanel.gameObject, time, localPosition, 0f, 2);
		tweenAnimator.AddTween(4, TweenAnimator.TweenType.TextCounter, rewardsWB.gameObject, time, mResultWb, 0f, 3);
		if (alsoGold)
		{
			tweenAnimator.AddTween(5, TweenAnimator.TweenType.TextCounter, rewardsGold.gameObject, time, mResultGold, 0f, 4);
		}
		tweenAnimator.AddTween(6, TweenAnimator.TweenType.TextCounter, rewardsWBVIP.gameObject, time, mResultWbVIP, 0f, 3);
		if (alsoGold)
		{
			tweenAnimator.AddTween(7, TweenAnimator.TweenType.TextCounter, rewardsGoldVIP.gameObject, time, mResultGoldVIP, 0f, 4);
		}
		if (headerAnimation)
		{
			tweenAnimator.AddTween(8, TweenAnimator.TweenType.TextCounterLong, GuiElementSingle<MenuHeader>.instance.warBucksLabel.gameObject, time, mWalletWb, 0f, 3);
		}
		if (headerAnimation)
		{
			tweenAnimator.AddTween(9, TweenAnimator.TweenType.TextCounterLong, GuiElementSingle<MenuHeader>.instance.goldLabel.gameObject, time, mWalletGold, 0f, 4);
		}
		return tweenAnimator;
	}

	public virtual TweenAnimator InitGuiValuesSimple(bool isVip, int warbucks, int gold, int warbucksVIP, int goldVIP, long walletWb, long walletGold)
	{
		VipColors(isVip);
		bool flag = gold > 0;
		mResultWb.val = warbucks;
		mResultGold.val = gold;
		mResultWbVIP.val = warbucksVIP;
		mResultGoldVIP.val = goldVIP;
		mWalletWb.val = walletWb;
		mWalletGold.val = walletGold;
		InitializeObjects(flag);
		return (!flag) ? mAnimatorOnlyWB : mAnimatorMoney;
	}

	public void Corrections(long walletWb)
	{
		mWalletWb.val = walletWb;
	}

	protected void VipColors(bool isVip)
	{
		rewardsWB.color = ((!isVip) ? Color.white : Colours.whiteWbShadow);
		rewardsGold.color = ((!isVip) ? Colours.yellowGold : Colours.yellowGoldShadow);
		rewardsWBVIP.color = ((!isVip) ? Colours.whiteWbShadow : Color.white);
		rewardsGoldVIP.color = ((!isVip) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	protected virtual void InitializeObjects(bool alsoGold = true)
	{
		rewardsPanel.alpha1 = 0f;
		rewardsWB.text = "+0";
		rewardsGold.text = "+0";
		rewardsWBVIP.text = "+0";
		rewardsGoldVIP.text = "+0";
		rewardsWBIcon.transform.localPosition = new Vector3(rewardsWBIcon.transform.localPosition.x, (!alsoGold) ? 0f : positionUp, rewardsWBIcon.transform.localPosition.z);
		rewardsWB.transform.localPosition = new Vector3(rewardsWB.transform.localPosition.x, (!alsoGold) ? 0f : positionUp, rewardsWB.transform.localPosition.z);
		rewardsWBVIP.transform.localPosition = new Vector3(rewardsWBVIP.transform.localPosition.x, (!alsoGold) ? 0f : positionUp, rewardsWBVIP.transform.localPosition.z);
		rewardsGoldIcon.gameObject.SetActive(alsoGold);
		rewardsGold.gameObject.SetActive(alsoGold);
		rewardsGoldVIP.gameObject.SetActive(alsoGold);
	}
}
