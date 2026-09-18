using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyVIPCardsScreen : GuiElementSingle<DailyVIPCardsScreen>, IGuiDialog
{
	[Header("Header")]
	public UITable headerTable;

	public UILabel header;

	public UILabel header1;

	public UISprite vipSprite;

	public GameObject ornamentsL;

	public GameObject ornamentsR;

	[Header("Card List")]
	public GameObject cardsHolder;

	public CardRecord cardRecordPrefab;

	public UIGrid grid;

	[Header("Card Collider for Button")]
	public GameObject leftCard;

	public GameObject rightCard;

	private ObjectPool mPool;

	private List<CardRecord> mCardList = new List<CardRecord>();

	private bool mLeftRevealed;

	private bool mRightRevealed;

	private bool mCardsInitialized;

	private bool mAnimationInitialized;

	private float mInitDelay = 0.5f;

	private float mHideDelay = 1f;

	public void ShowDialogWithCards(string card1, string card2)
	{
		Get2RandomCards(card1, card2);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		UIEventListener.Get(leftCard).onClick = LeftCardClicked;
		UIEventListener.Get(rightCard).onClick = RightCardClicked;
		headerTable.onReposition = delegate
		{
			vipSprite.transform.localPosition = new Vector3(vipSprite.transform.localPosition.x, -44f, 0f);
			float num = ornamentsR.transform.localPosition.x + ornamentsR.transform.localScale.x / 2f;
			float val = 0f - headerTable.padding.x - (num - headerTable.padding.x) / 2f;
			headerTable.transform.localPosition = headerTable.transform.localPosition.ReplaceX(val);
			if (!mAnimationInitialized)
			{
				mAnimationInitialized = true;
				Animation_InitGUI(0.1f);
			}
		};
		grid.onReposition = delegate
		{
			Vector3 localPosition = grid.transform.localPosition;
			localPosition.x = (0f - grid.cellWidth) / 2f;
			grid.transform.localPosition = localPosition;
			for (int i = 0; i < mCardList.Count; i++)
			{
				mCardList[i].PrepareBuyAnimation();
				TweenAlpha.Begin(mCardList[i].backOfCard.gameObject, 0.05f, 0f, 1f).delay = mInitDelay;
				TweenScale tweenScale = TweenScale.Begin(mCardList[i].backOfCard.gameObject, 0.3f, mCardList[i].backOfCard.cachedTransform.localScale.MultiplyXY(2f));
				tweenScale.delay = mInitDelay + 0.05f;
				tweenScale.onFinished = delegate(UITweener tween)
				{
					mCardsInitialized = true;
					tween.onFinished = null;
				};
			}
		};
	}

	public override void InitGUIValues()
	{
		mCardsInitialized = false;
		mLeftRevealed = false;
		mRightRevealed = false;
		mAnimationInitialized = false;
		headerTable.repositionNow = true;
	}

	private void LeftCardClicked(GameObject go)
	{
		if (!mLeftRevealed && mCardsInitialized)
		{
			mLeftRevealed = true;
			mCardList[0].FlipBuyAnimation(0);
			AnimateHideDialog();
		}
	}

	private void RightCardClicked(GameObject go)
	{
		if (!mRightRevealed && mCardsInitialized)
		{
			mRightRevealed = true;
			mCardList[1].FlipBuyAnimation(0);
			AnimateHideDialog();
		}
	}

	private void AnimateHideDialog()
	{
		if (!mLeftRevealed || !mRightRevealed)
		{
			return;
		}
		InvokeAfterRealTime(delegate
		{
			Animation_ShowOrnaments(show: false, 1f, delegate
			{
				HideDialog();
			});
		}, mHideDelay);
	}

	private void Get2RandomCards(string warcard1ID, string warcard2ID)
	{
		if (mPool == null)
		{
			mPool = Singleton<GuiManager>.instance.objectPool;
		}
		Card cardInstance = CardManager.instance.GetCardInstance(warcard1ID);
		Card cardInstance2 = CardManager.instance.GetCardInstance(warcard2ID);
		CardRecord cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, grid.gameObject, "01 " + warcard1ID);
		if (cardRecord != null)
		{
			mCardList.Add(cardRecord);
			cardRecord.Initialize(cardInstance);
		}
		cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, grid.gameObject, "02 " + warcard2ID);
		if (cardRecord != null)
		{
			mCardList.Add(cardRecord);
			cardRecord.Initialize(cardInstance2);
		}
		grid.repositionNow = true;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DailyVIPCardsShow);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		foreach (CardRecord mCard in mCardList)
		{
			mCard.DestroyPooled();
		}
		mCardList.Clear();
	}

	private void Animation_InitGUI(float startDelay)
	{
		float num = 0.5f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(header.gameObject, num * 2f, 1f);
		tweenAlpha.from = 0f;
		tweenAlpha.delay = startDelay * 1.5f;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(vipSprite.gameObject, num * 2f, 1f);
		tweenAlpha2.from = 0f;
		tweenAlpha2.delay = startDelay * 1.5f;
		TweenAlpha tweenAlpha3 = TweenAlpha.Begin(header1.gameObject, num * 2f, 1f);
		tweenAlpha3.from = 0f;
		tweenAlpha3.delay = startDelay * 1.5f;
		TweenScale tweenScale = TweenScale.Begin(header.transform.parent.gameObject, 0.5f, new Vector3(1.15f, 1.15f, 1f));
		tweenScale.delay = startDelay;
		tweenScale.onFinished = delegate
		{
			TweenScale.Begin(header.transform.parent.gameObject, 0.25f, Vector3.one);
		};
		TweenScale tweenScale2 = TweenScale.Begin(header1.transform.parent.gameObject, 0.5f, new Vector3(1.15f, 1.15f, 1f));
		tweenScale2.delay = startDelay;
		tweenScale2.onFinished = delegate
		{
			TweenScale.Begin(header1.transform.parent.gameObject, 0.25f, Vector3.one);
		};
		Vector3 startScaleVIPIcon = vipSprite.transform.localScale;
		TweenScale tweenScale3 = TweenScale.Begin(scale: new Vector3(startScaleVIPIcon.x * 1.15f, startScaleVIPIcon.y * 1.15f, 1f), go: vipSprite.gameObject, duration: 0.5f);
		tweenScale3.delay = startDelay;
		tweenScale3.onFinished = delegate
		{
			TweenScale.Begin(vipSprite.gameObject, 0.25f, startScaleVIPIcon);
		};
		Animation_ShowOrnaments(show: true, num * 1.2f, null);
	}

	private void Animation_ShowOrnaments(bool show, float speed, Action callBack)
	{
		Vector3 localPosition = ornamentsL.transform.localPosition;
		Vector3 localPosition2 = ornamentsR.transform.localPosition;
		float activeWidth = UIRoot.list[0].activeWidth;
		if (show)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(ornamentsL, speed, 1f);
			tweenAlpha.from = 0f;
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(ornamentsR, speed, 1f);
			tweenAlpha2.from = 0f;
			TweenPosition tweenPosition = TweenPosition.Begin(ornamentsL, speed, localPosition);
			tweenPosition.from = new Vector3(localPosition.x - activeWidth, localPosition.y, localPosition.z);
			TweenPosition tweenPosition2 = TweenPosition.Begin(ornamentsR, speed, localPosition2);
			tweenPosition2.from = new Vector3(localPosition2.x + activeWidth, localPosition2.y, localPosition2.z);
			tweenAlpha.onFinished = delegate
			{
				if (callBack != null)
				{
					callBack();
				}
			};
			return;
		}
		TweenAlpha tweenAlpha3 = TweenAlpha.Begin(ornamentsL, speed, 0f);
		tweenAlpha3.from = 1f;
		TweenAlpha tweenAlpha4 = TweenAlpha.Begin(ornamentsR, speed, 0f);
		tweenAlpha4.from = 1f;
		TweenPosition.Begin(ornamentsL, speed, new Vector3(localPosition.x - activeWidth, localPosition.y, localPosition.z));
		TweenPosition.Begin(ornamentsR, speed, new Vector3(localPosition2.x + activeWidth, localPosition2.y, localPosition2.z));
		tweenAlpha3.onFinished = delegate
		{
			if (callBack != null)
			{
				callBack();
			}
		};
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
	}
}
