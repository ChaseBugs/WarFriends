using System.Collections.Generic;
using UnityEngine;

public class ResultsRewardsNA : ResultsRewards
{
	[Header("Differentiate Types")]
	public GameObject resultsNA;

	public GameObject resultsValues;

	private TweenAnimator mAnimatorNoValues;

	public TweenAnimator animatorNoValues => mAnimatorNoValues;

	public override TweenAnimator InitControls(bool headerAnimation = true)
	{
		mAnimatorNoValues = CreateAnimatorForMoney();
		return base.InitControls(headerAnimation);
	}

	private TweenAnimator CreateAnimatorForMoney()
	{
		float time = 0.4f;
		TweenAnimator tweenAnimator = rewardsPanel.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = rewardsPanel.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, rewardsPanel.gameObject, time, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(from: localPosition + new Vector3(0f, -20f, 0f), id: 2, tweenType: TweenAnimator.TweenType.Position, tweenTarget: rewardsPanel.gameObject, time: time, to: localPosition + new Vector3(0f, 10f, 0f), delay: 0f);
		tweenAnimator.AddTween(3, TweenAnimator.TweenType.Position, rewardsPanel.gameObject, time, localPosition, 0f, 2);
		return tweenAnimator;
	}

	public TweenAnimator InitGuiValuesEmpty()
	{
		resultsNA.SetActive(value: true);
		resultsValues.SetActive(value: false);
		InitializeObjects();
		return mAnimatorNoValues;
	}

	public TweenAnimator InitGuiValuesAssign()
	{
		resultsNA.SetActive(value: false);
		resultsValues.SetActive(value: false);
		InitializeObjects();
		return mAnimatorNoValues;
	}

	public override TweenAnimator InitGuiValuesSimple(bool isVip, int warbucks, int gold, int warbucksVIP, int goldVIP, long walletWb, long walletGold)
	{
		resultsNA.SetActive(value: false);
		resultsValues.SetActive(value: true);
		return base.InitGuiValuesSimple(isVip, warbucks, gold, warbucksVIP, goldVIP, walletWb, walletGold);
	}
}
