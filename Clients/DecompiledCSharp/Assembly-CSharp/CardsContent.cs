using System;
using System.Collections.Generic;
using UnityEngine;

public class CardsContent : Core_BaseScript
{
	[Header("Header")]
	public UISprite topSpacer;

	public UILabel cardsHeader;

	[Header("Left Button")]
	public UILabel cardsCountLabel;

	[Header("List of Cards")]
	public CardRecord cardRecordPrefab;

	public UIDraggablePanel panelCards;

	public UIGrid gridCards;

	[Header("No Cards")]
	public UILabel noCardsGained;

	[Header("Bottom")]
	public UISprite bottomSpacer;

	private int mCount;

	private List<CardRecord> mCardsToAnimate = new List<CardRecord>();

	private List<TweenAnimator> mAnimator = new List<TweenAnimator>();

	private ObjectPool mPool;

	public List<TweenAnimator> Animator => mAnimator;

	public void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		mCardsToAnimate = new List<CardRecord>();
		InitAnimators();
		topSpacer.transform.localPosition = new Vector3(0f, (float)UIRoot.list[0].activeHeight / 2f, 0f);
		gridCards.onReposition = delegate
		{
			float num = ((float)Mathf.CeilToInt((float)mCardsToAnimate.Count / 3f) - 0.35f) * gridCards.cellHeight;
			bottomSpacer.transform.localPosition = new Vector3(0f, 0f - num, 0f);
		};
	}

	private void InitAnimators()
	{
		mAnimator = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimator.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimator.Add(tweenAnimator2);
	}

	internal void InitGuiValues()
	{
		InitCardsTab();
		InitializeCardContent();
	}

	public void AnimateShow(float fadeInTime)
	{
		PrepareAnimation();
	}

	private void InitCardsTab()
	{
		List<Card> obtainedCards = CardManager.instance.obtainedCards;
		obtainedCards.Sort((Card card1, Card card2) => string.Compare(card1.rarity.ToString() + card1.name, card2.rarity.ToString() + card2.name, StringComparison.Ordinal));
		foreach (CardRecord item in mCardsToAnimate)
		{
			item.DestroyPooled();
		}
		mCardsToAnimate.Clear();
		if (obtainedCards == null)
		{
			return;
		}
		string text = "********** DEBUG GAINED CARDS **********\n";
		foreach (Card item2 in obtainedCards)
		{
			text += $"Card: {item2.rarity} {item2.cardName}\t\t{item2.name}\n";
			CardRecord cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, gridCards.gameObject, $"Card {5 - item2.rarityNumber} {item2.cardName} {mCount++}");
			if (cardRecord != null)
			{
				cardRecord.Initialize(item2);
			}
			mCardsToAnimate.Add(cardRecord);
		}
		Debug.Log(text + "********************************************");
		GuiScreenSingle<EndScreen>.instance.results.cardsGot = obtainedCards.Count;
		GuiScreenSingle<EndScreen>.instance.resultCampaign.cardsGot = obtainedCards.Count;
	}

	private void InitializeCardContent()
	{
		cardsHeader.alpha = 0f;
		cardsCountLabel.alpha = 0f;
		cardsCountLabel.text = "0";
		noCardsGained.alpha = 0f;
	}

	private void PrepareAnimation()
	{
		TweenAnimator tweenAnimator = mAnimator[0];
		tweenAnimator.allTweens.Clear();
		if (mCardsToAnimate.Count > 0)
		{
			tweenAnimator.AddTween(0, TweenAnimator.TweenType.Alpha, cardsHeader.gameObject, 0.5f, 1f, 0f, -1, 0f);
		}
		tweenAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, cardsCountLabel.gameObject, 0.5f, 1f, 0f);
		int num = 2;
		gridCards.repositionNow = true;
		float num2 = 0.8f;
		foreach (CardRecord item in mCardsToAnimate)
		{
			TweenAlpha.Begin(item.cardPanel.gameObject, 0f, 0f);
			item.cardPanel.alpha1 = 0f;
			tweenAnimator.AddTween(num++, TweenAnimator.TweenType.Alpha, item.gameObject, 0.5f, 1f, num2, -1, 0f);
			num2 += 0.3f;
		}
		tweenAnimator.GenerateTweens();
		mAnimator[1].allTweens.Clear();
		if (mCardsToAnimate.Count == 0)
		{
			mAnimator[1].AddTween(1, TweenAnimator.TweenType.Alpha, noCardsGained.gameObject, 0.5f, 1f, 0f, -1, 0f);
			mAnimator[1].GenerateTweens();
		}
	}

	public void SetCardsAvailable()
	{
		foreach (CardRecord item in mCardsToAnimate)
		{
			item.SetAvailable();
		}
	}

	internal void ResetAnimation()
	{
		foreach (TweenAnimator item in mAnimator)
		{
			item.ResetTweens();
		}
	}

	internal void FinishAnimation()
	{
		foreach (TweenAnimator item in mAnimator)
		{
			item.FinishTweens();
		}
	}

	public void DoAfterHide()
	{
		if (mCardsToAnimate == null)
		{
			return;
		}
		foreach (CardRecord item in mCardsToAnimate)
		{
			item.DestroyPooled();
		}
		mCardsToAnimate.Clear();
	}
}
