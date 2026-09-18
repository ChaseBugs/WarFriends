using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenuOwerlay : Core_BaseScript
{
	private const float basePos = 280f;

	private const float move = 80f;

	[Header("Animation")]
	public UIPanel owerlayPanel;

	public GameObject owerlay;

	[Header("List of Cards")]
	public CardRecord cardRecordPrefab;

	public GameObject topCards;

	public GameObject downCards;

	[Header("Continue Button")]
	public UIButton continueButton;

	public AnimationCurve buttonAnimatinCurve;

	private ObjectPool mPool;

	private List<CardRecord> mCardList;

	protected override void Awake()
	{
		base.Awake();
		UIEventListener.Get(continueButton.gameObject).onClick = HideOverlay;
	}

	private void AddSkipAnimationToBackground()
	{
		RemoveSkipAnimationFromBackground();
		UIEventListener uIEventListener = UIEventListener.Get(owerlay);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowNow));
	}

	private void RemoveSkipAnimationFromBackground()
	{
		UIEventListener uIEventListener = UIEventListener.Get(owerlay);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowNow));
	}

	private void HideOverlay(GameObject go)
	{
		Hide();
	}

	private void ShowNow(GameObject go)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardEquiped);
		ShowInstanly();
	}

	public void Hide()
	{
		RemoveSkipAnimationFromBackground();
		base.gameObject.SetActive(value: true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(base.gameObject, 0.2f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha.onFinished = delegate
		{
			ResetDraw();
		};
		foreach (CardRecord mCard in mCardList)
		{
			TweenAlpha.Begin(mCard.gameObject, 0.2f, 0f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		CardManager.instance.CardPackBoughtEvent();
	}

	public void ResetDraw()
	{
		base.gameObject.SetActive(value: true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
			component.alpha = 1f;
		}
		base.gameObject.SetActive(value: false);
		continueButton.gameObject.SetActive(value: false);
		if (mCardList == null)
		{
			mCardList = new List<CardRecord>();
		}
		for (int i = 0; i < mCardList.Count; i++)
		{
			mCardList[i].DestroyPooled();
		}
		mCardList.Clear();
	}

	public void StartShowAnimation(Card[] cards, float initDelay = 1.2f, bool canHideImmediately = true)
	{
		if (mPool == null)
		{
			mPool = Singleton<GuiManager>.instance.objectPool;
		}
		base.gameObject.SetActive(value: true);
		SetOwerlayAlphaToZero();
		owerlayPanel.isFreezed = false;
		owerlayPanel.alpha1 = 1f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(owerlay, 0.4f, 0f, 0.942f);
		tweenAlpha.delay = 0.1f;
		tweenAlpha.alpha = 0f;
		if (canHideImmediately)
		{
			StartCoroutine(AddSkipAnimationIn(0.5f));
		}
		UIDraggablePanel.panelDisabled = true;
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < cards.Length; i++)
		{
			if (cards[i] == null)
			{
				continue;
			}
			bool flag = i * 2 < cards.Length;
			CardRecord newCard = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, (!flag) ? downCards : topCards, "card " + cards[i].cardName);
			if (!(newCard != null))
			{
				continue;
			}
			mCardList.Add(newCard);
			newCard.Initialize(cards[i]);
			newCard.PrepareBuyAnimation();
			newCard.boxCollider.enabled = false;
			int num = ((!flag) ? (i - (cards.Length + 1) / 2) : i);
			zero.y = (float)((!flag) ? 1 : (-1)) * (280f - newCard.backOfCard.cachedTransform.localScale.y * 0.25f);
			zero.x = ((float)num * newCard.backOfCard.cachedTransform.localScale.x - (float)(((flag ? 1 : 0) + cards.Length) / 2 - 1) * newCard.backOfCard.cachedTransform.localScale.x * 0.5f) * 0.5f;
			newCard.transform.localPosition = zero;
			TweenAlpha.Begin(newCard.backOfCard.gameObject, 0.05f, 0f, 1f).delay = initDelay;
			TweenPosition tweenPosition = TweenPosition.Begin(newCard.gameObject, 0.3f, GetCardPosition(flag, num, cards.Length, newCard));
			TweenScale.Begin(newCard.backOfCard.gameObject, 0.3f, newCard.backOfCard.cachedTransform.localScale.MultiplyXY(2f)).delay = initDelay + 0.05f;
			tweenPosition.delay = initDelay + 0.05f;
			int delayIndex = i;
			tweenPosition.onFinished = delegate
			{
				newCard.FlipBuyAnimation(delayIndex);
				if (delayIndex == 0 && !canHideImmediately)
				{
					AddSkipAnimationToBackground();
				}
			};
		}
		float num2 = initDelay + 0.2f + (float)cards.Length * 0.35f;
		continueButton.transform.localPosition = new Vector3(0f, -100f, 0f);
		TweenPosition tweenPosition2 = TweenPosition.Begin(continueButton.gameObject, 0.4f, new Vector3(0f, 100f, 0f));
		tweenPosition2.delay = num2;
		tweenPosition2.animationCurve = buttonAnimatinCurve;
		continueButton.gameObject.SetActive(value: true);
		downCards.transform.localPosition = new Vector3(0f, -280f, 0f);
		topCards.transform.localPosition = new Vector3(0f, 280f, 0f);
		TweenPosition.Begin(downCards, 0.2f, new Vector3(0f, -200f, 0f)).delay = num2 + 0.3f;
		TweenPosition.Begin(topCards, 0.2f, new Vector3(0f, 360f, 0f)).delay = num2 + 0.4f;
	}

	private Vector3 GetCardPosition(bool top, int myIndex, int totalCards, CardRecord newCard)
	{
		Vector3 zero = Vector3.zero;
		float num = UIRoot.list[0].activeWidth - 40f;
		float num2 = (float)(((top ? 1 : 0) + totalCards) / 2) * newCard.background.cachedTransform.localScale.x + 10f;
		if (num2 > num)
		{
			num2 = num;
		}
		float num3 = num2 / (float)(((top ? 1 : 0) + totalCards) / 2);
		zero.y = 0f;
		zero.x = num3 * (float)myIndex - num2 * 0.5f + num3 * 0.5f;
		return zero;
	}

	private void ShowInstanly()
	{
		for (int i = 0; i < mCardList.Count; i++)
		{
			CardRecord cardRecord = mCardList[i];
			cardRecord.UnhookAndStopAllTweens();
			cardRecord.InitBigCardLook();
			bool flag = i * 2 < mCardList.Count;
			int myIndex = ((!flag) ? (i - (mCardList.Count + 1) / 2) : i);
			TweenPosition.Begin(cardRecord.gameObject, 0f, GetCardPosition(flag, myIndex, mCardList.Count, cardRecord));
		}
		RemoveSkipAnimationFromBackground();
		if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CardMenuScreen>.instance)
		{
			GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.StopBuyingCardPackAnimation();
		}
		TweenPosition tweenPosition = TweenPosition.Begin(continueButton.gameObject, 0.4f, new Vector3(0f, 100f, 0f));
		tweenPosition.delay = 0f;
		tweenPosition.animationCurve = buttonAnimatinCurve;
		continueButton.gameObject.SetActive(value: true);
		TweenPosition.Begin(downCards, 0.2f, new Vector3(0f, -200f, 0f)).delay = 0f;
		TweenPosition.Begin(topCards, 0.2f, new Vector3(0f, 360f, 0f)).delay = 0f;
	}

	private IEnumerator AddSkipAnimationIn(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		AddSkipAnimationToBackground();
	}

	private void SetOwerlayAlphaToZero()
	{
		owerlay.SetActive(value: true);
		UISprite component = owerlay.GetComponent<UISprite>();
		if (component != null)
		{
			component.alpha = 0f;
		}
	}
}
