using System;
using System.Collections.Generic;
using UnityEngine;

public class CardpoolCard : Core_BaseScript
{
	public enum State
	{
		NoCard,
		Empty,
		Card,
		DepositBuddy,
		WaitingBuddy
	}

	[Header("Core")]
	public List<UIWidget> widgets;

	[Header("Empty")]
	public GameObject emptyPart;

	public UISprite borderEmpty;

	[Header("Card")]
	public GameObject cardPart;

	public UISprite cardBackground;

	public UITexture cardTexture;

	public UISprite cardIcon;

	public UISprite cardBonusIcon;

	public UILabel cardBonusLabel;

	[Header("Deposit Buddy")]
	public GameObject depositBuddyPart;

	[Header("Waiting Buddy")]
	public GameObject waitingBuddyPart;

	public WinStreakCounter waitingTime;

	private State mState;

	private Card mCard;

	private CardpoolRecord mParentRecord;

	public Card card
	{
		get
		{
			return mCard;
		}
		private set
		{
			if (value == null && mCard != null)
			{
				mCard.HideInMenu();
			}
			mCard = value;
			if (mCard != null)
			{
				mCard.ShowInMenu();
			}
		}
	}

	public void Initialize(int position, CardpoolRecord parent)
	{
		position++;
		int num = 11;
		int num2 = 11;
		int num3 = 12;
		int num4 = (num - position) * num2;
		for (int i = 0; i < widgets.Count; i++)
		{
			widgets[i].depth = num3 + num4 + i;
		}
		cardBackground.depth = num3 + num4 + 7;
		cardIcon.depth = num3 + num4 + 8;
		cardBonusIcon.depth = num3 + num4 + 9;
		cardBonusLabel.depth = num3 + num4 + 10;
		mParentRecord = parent;
		CleanUp();
	}

	public void InitializeNoCard()
	{
		mState = State.NoCard;
		SetLook();
		CleanUp();
	}

	public void InitializeEmpty(bool isBuddy = false)
	{
		mState = State.Empty;
		SetLook();
		CleanUp();
		borderEmpty.color = ((!isBuddy) ? Colours.grayBorder : Colours.pink);
	}

	public void InitializeCard(Card insertCard)
	{
		mState = State.Card;
		SetLook();
		CleanUp();
		card = insertCard;
		card.SetUpSmallCard(cardBackground, cardIcon, cardBonusIcon, cardBonusLabel, cardTexture);
	}

	public void InitializeDepositBuddy()
	{
		mState = State.DepositBuddy;
		SetLook();
		CleanUp();
	}

	public void InitializeWaiting(int timeWhenReady)
	{
		mState = State.WaitingBuddy;
		SetLook();
		CleanUp();
		waitingTime.StartCountingTo(timeWhenReady);
		WinStreakCounter winStreakCounter = waitingTime;
		winStreakCounter.winStreakTimer = (Action)Delegate.Combine(winStreakCounter.winStreakTimer, new Action(InitializeDepositBuddy));
	}

	public void CleanUp()
	{
		card = null;
		waitingTime.StopCountingTo();
		WinStreakCounter winStreakCounter = waitingTime;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(InitializeDepositBuddy));
		StopAnimation();
	}

	public void Animate(float delay)
	{
		float num = 0.583f;
		float num2 = num * 1.1f;
		TweenScale tweenScale = TweenScale.Begin(cardPart, 0.25f, new Vector3(num, num, 1f), new Vector3(num2, num2, 1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.delay = Mathf.Max(0f, GuiElementSingle<CardpoolDialog>.instance.fadeOutTime - 0.1f + delay);
	}

	private void StopAnimation()
	{
		float num = 0.583f;
		TweenScale component = cardPart.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		cardPart.transform.localScale = new Vector3(num, num, 1f);
	}

	private void SetLook()
	{
		emptyPart.SetActive(mState == State.Empty);
		cardPart.SetActive(mState == State.Card);
		depositBuddyPart.SetActive(mState == State.DepositBuddy);
		waitingBuddyPart.SetActive(mState == State.WaitingBuddy);
	}

	public void OnClick()
	{
		mParentRecord.ClickedOnCard(mState);
	}

	protected void Update()
	{
		if (!cardTexture.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			cardIcon.gameObject.SetActive(value: false);
			cardTexture.gameObject.SetActive(value: true);
			cardTexture.mainTexture = card.iconTexture;
		}
	}
}
