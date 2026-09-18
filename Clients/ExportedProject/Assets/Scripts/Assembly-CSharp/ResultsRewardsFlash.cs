using System.Collections.Generic;
using UnityEngine;

public class ResultsRewardsFlash : ResultsRewards
{
	[Header("Flash")]
	public UISprite flash;

	private IntObject mCardsGot = new IntObject(0);

	public int cardsGot
	{
		set
		{
			mCardsGot.val = value;
		}
	}

	protected override TweenAnimator CreateAnimatorForMoney(bool alsoGold = true, bool headerAnimation = false)
	{
		float num = 0.4f;
		TweenAnimator tweenAnimator = rewardsPanel.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = rewardsPanel.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, rewardsPanel.gameObject, num, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(from: localPosition + new Vector3(0f, -20f, 0f), id: 2, tweenType: TweenAnimator.TweenType.Position, tweenTarget: rewardsPanel.gameObject, time: num, to: localPosition + new Vector3(0f, 10f, 0f), delay: 0f);
		tweenAnimator.AddTween(3, TweenAnimator.TweenType.Position, rewardsPanel.gameObject, num, localPosition, 0f, 2);
		tweenAnimator.AddTween(4, TweenAnimator.TweenType.TextCounter, rewardsWB.gameObject, num, mResultWb, 0f, 3);
		if (alsoGold)
		{
			tweenAnimator.AddTween(5, TweenAnimator.TweenType.TextCounter, rewardsGold.gameObject, num, mResultGold, 0f, 4);
		}
		tweenAnimator.AddTween(6, TweenAnimator.TweenType.TextCounter, rewardsWBVIP.gameObject, num, mResultWbVIP, 0f, 3);
		if (alsoGold)
		{
			tweenAnimator.AddTween(7, TweenAnimator.TweenType.TextCounter, rewardsGoldVIP.gameObject, num, mResultGoldVIP, 0f, 4);
		}
		if (headerAnimation)
		{
			tweenAnimator.AddTween(8, TweenAnimator.TweenType.TextCounterLong, GuiElementSingle<MenuHeader>.instance.warBucksLabel.gameObject, num, mWalletWb, 0f, 3);
		}
		if (headerAnimation && alsoGold)
		{
			tweenAnimator.AddTween(9, TweenAnimator.TweenType.TextCounterLong, GuiElementSingle<MenuHeader>.instance.goldLabel.gameObject, num, mWalletGold, 0f, 4);
		}
		tweenAnimator.AddTween(20, TweenAnimator.TweenType.Alpha, GuiScreenSingle<EndScreen>.instance.cards.cardsCountLabel.gameObject, num, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(21, TweenAnimator.TweenType.TextCounter, GuiScreenSingle<EndScreen>.instance.cards.cardsCountLabel.gameObject, num, mCardsGot, 0f, 20);
		float time = num / 7f;
		int idMoneyLast = ((!alsoGold) ? 6 : 7);
		tweenAnimator.AddTween(playAfterIdFinished: idMoneyLast, id: 25, tweenType: TweenAnimator.TweenType.Alpha, tweenTarget: flash.gameObject, time: time, to: 0.4f, delay: 0f, from: 0f, method: UITweener.Method.EaseInOut, style: UITweener.Style.PingPong, numOfRepetitions: 5);
		tweenAnimator.AddTween(26, TweenAnimator.TweenType.Alpha, flash.gameObject, time, 0f, 0f, 25);
		tweenAnimator.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == idMoneyLast)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.FlashEndScreen);
			}
		};
		return tweenAnimator;
	}

	protected override void InitializeObjects(bool alsoGold)
	{
		flash.alpha = 0f;
		base.InitializeObjects(alsoGold);
	}
}
