using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class CardpoolRecord : PoolableObject
{
	[Header("Width Setter")]
	public UIButtonSetter buttonSetter;

	[Header("Player Info")]
	public UISprite highlight;

	public UILabel position;

	public PlayerIcon avatar;

	public GameObject playerIconButton;

	public UISprite countryIcon;

	public UISprite rankIcon;

	public UILabel rankNumber;

	public UILabel nickLabel;

	public BoxCollider playerButton;

	public UITable reputationTable;

	public UILabel reputationLabel;

	[Header("CardPool")]
	public GameObject emptyCardpool;

	public GameObject notifyButton;

	public GameObject cardPoolPart;

	public List<CardpoolCard> cards;

	[Header("Buttons")]
	public BoxCollider withdrawButton;

	public UISprite withdrawBackground;

	public UISprite withdrawIcon;

	public UILabel withdrawLabel;

	public GameObject depositButton;

	private DatabasePlayer mSquadMember;

	private bool mIsCurrentPlayer;

	private bool mWithdrawAvailable;

	private Card[] mMemberCards;

	public void Initialize(DatabasePlayer squadMember, int pos, bool withdrawAvailable, bool canBeNotified)
	{
		Card[] depositedCards = squadMember.GetDepositedCards();
		buttonSetter.SetWidth(UIRoot.list[0].activeWidth - 120f);
		mIsCurrentPlayer = squadMember.id == GameLoginManager.currentPlayer.id;
		mSquadMember = squadMember;
		mMemberCards = depositedCards;
		highlight.gameObject.SetActive(mIsCurrentPlayer);
		position.text = MiscTools.FormatNumberToOrdinalPoint(pos);
		avatar.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(squadMember);
		string text = GameVariables.CountryCodeSpriteName(squadMember.country);
		bool flag = !string.IsNullOrEmpty(text);
		countryIcon.gameObject.SetActive(flag);
		if (flag)
		{
			countryIcon.spriteName = text;
		}
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(squadMember.level);
		rankIcon.spriteName = levelDefinition.iconName;
		rankNumber.text = levelDefinition.displayString;
		nickLabel.text = squadMember.name;
		TweenColor.Begin(nickLabel.gameObject, 0f, Color.white);
		MiscTools.SetUILabelRescale(nickLabel, 37f, 20f);
		playerButton.size = new Vector3((float)nickLabel.lineWidth + 20f, 55f, 1f);
		playerButton.center = new Vector3((float)nickLabel.lineWidth / 2f, 0f, -2f);
		InitializeReputationPoints(squadMember.reputation);
		InitializeWarcards(depositedCards);
		depositButton.SetActive(mIsCurrentPlayer);
		withdrawButton.gameObject.SetActive(!mIsCurrentPlayer);
		SetWithdraw(withdrawAvailable);
		notifyButton.SetActive(canBeNotified);
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener5 = UIEventListener.Get(notifyButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(NotifyClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(notifyButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NotifyClick));
	}

	private void InitializeReputationPoints(int reputationPoints)
	{
		reputationLabel.text = MiscTools.FormatBigNumber(reputationPoints);
		reputationTable.repositionNow = true;
	}

	public void InitializeWarcards(Card[] poolCardsWithNull)
	{
		int num = 0;
		for (int i = 0; i < poolCardsWithNull.Length; i++)
		{
			if (poolCardsWithNull[i] != null)
			{
				num++;
			}
			else
			{
				Debug.LogError("NULL WARCARD");
			}
		}
		Card[] array = new Card[num];
		int num2 = 0;
		for (int j = 0; j < poolCardsWithNull.Length; j++)
		{
			if (poolCardsWithNull[j] != null)
			{
				array[num2] = poolCardsWithNull[j];
				num2++;
			}
		}
		cards[0].Initialize(10, this);
		for (int k = 1; k < cards.Count; k++)
		{
			cards[k].Initialize(k, this);
		}
		Array.Sort(array, WarcardsSortingByRarity);
		bool flag = array.Length > 0 || mSquadMember.id == GameLoginManager.currentPlayer.id;
		int num3 = -1;
		for (int l = 0; l < array.Length; l++)
		{
			if (array[l].isBuddyCard)
			{
				num3 = l;
			}
		}
		emptyCardpool.SetActive(!flag);
		cardPoolPart.SetActive(flag);
		mMemberCards = array;
		if (!flag)
		{
			return;
		}
		if (num3 > -1)
		{
			cards[0].InitializeCard(array[num3]);
		}
		else if (mIsCurrentPlayer)
		{
			if (CardManager.instance.isBuddyDepositAvailable)
			{
				cards[0].InitializeDepositBuddy();
			}
			else
			{
				cards[0].InitializeWaiting(CardManager.instance.nextBuddyDeposit);
			}
		}
		else
		{
			cards[0].InitializeEmpty(isBuddy: true);
		}
		int squadDisplayLevel = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true)?.rank ?? 1;
		int num4 = Singleton<GameVariables>.instance.SquadCardpoolSize(squadDisplayLevel);
		int num5 = 0;
		for (int m = 1; m < cards.Count; m++)
		{
			if (m > num4)
			{
				cards[m].InitializeNoCard();
			}
			else
			{
				if (num5 == num3)
				{
					num5++;
				}
				if (num5 >= array.Length)
				{
					cards[m].InitializeEmpty();
				}
				else
				{
					cards[m].InitializeCard(array[num5]);
				}
			}
			num5++;
		}
	}

	public void AnimateWarcards(List<Card> newDeposited)
	{
		int num = newDeposited.FindIndex((Card card1) => card1.isBuddyCard);
		int num2 = 0;
		if (num > -1)
		{
			cards[num2].Animate(0f);
		}
		num2++;
		int i;
		for (i = 0; i < mMemberCards.Length; i++)
		{
			if (!mMemberCards[i].isBuddyCard)
			{
				if (newDeposited.FindIndex((Card card2) => card2.id == mMemberCards[i].id) > -1)
				{
					cards[num2].Animate((float)i * 0.1f);
				}
				num2++;
			}
		}
	}

	private int WarcardsSortingByRarity(Card c1, Card c2)
	{
		if (c1 == null)
		{
			Debug.LogError("NULL WARCARD");
			return -1;
		}
		if (c2 == null)
		{
			Debug.LogError("NULL WARCARD");
			return 1;
		}
		if (c1.rarityNumber == c2.rarityNumber)
		{
			return c1.cardName.CompareTo(c2.cardName);
		}
		return c2.rarityNumber.CompareTo(c1.rarityNumber);
	}

	public void SetWithdraw(bool active)
	{
		mWithdrawAvailable = active;
		withdrawButton.enabled = active;
		withdrawBackground.color = ((!active) ? Colours.gray : Color.white);
		withdrawIcon.color = ((!active) ? Colours.gray : Color.white);
		withdrawLabel.color = ((!active) ? Colours.grayDark : Color.black);
	}

	public void ClickedOnCard(CardpoolCard.State state)
	{
		bool flag = !mIsCurrentPlayer && mWithdrawAvailable;
		bool flag2 = mIsCurrentPlayer && state == CardpoolCard.State.DepositBuddy;
		bool flag3 = mIsCurrentPlayer && (state == CardpoolCard.State.Card || state == CardpoolCard.State.Empty || state == CardpoolCard.State.NoCard);
		if (flag)
		{
			WithdrawClick(base.gameObject);
		}
		else if (flag2)
		{
			DepositBuddyClick();
		}
		else if (flag3)
		{
			DepositClick(base.gameObject);
		}
	}

	private void WithdrawClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<CardpoolDialog>.instance.ShowWithdraw(mSquadMember, mMemberCards);
	}

	private void DepositClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<CardpoolDialog>.instance.ShowDeposit(mMemberCards);
	}

	private void NotifyClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		Singleton<BeanstalkServerManager>.instance.NotifyPlayerToDeposit(mSquadMember.id);
		GuiScreenSingle<SquadScreen>.instance.cardpoolContent.Notified(mSquadMember.id);
		notifyButton.SetActive(value: false);
	}

	private void DepositBuddyClick()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CardManager.instance.ActualizeBuddyWarcardTime();
		CardBuddy buddyCard = CardManager.instance.buddyCard;
		cards[0].InitializeCard(buddyCard);
		Card[] array = new Card[mMemberCards.Length + 1];
		array[0] = buddyCard;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < mMemberCards.Length; i++)
		{
			if (dictionary.ContainsKey(mMemberCards[i].id))
			{
				CardManager.CardData cardData = JsonConvert.DeserializeObject<CardManager.CardData>(dictionary[mMemberCards[i].id]);
				cardData.amount++;
				dictionary[mMemberCards[i].id] = JsonConvert.SerializeObject(cardData);
			}
			else
			{
				dictionary.Add(mMemberCards[i].id, (!mMemberCards[i].isBuddyCard) ? JsonConvert.SerializeObject(new CardManager.CardData
				{
					amount = 1
				}) : JsonConvert.SerializeObject(buddyCard.buddyCardData));
			}
			array[i + 1] = mMemberCards[i];
		}
		dictionary.Add(buddyCard.id, JsonConvert.SerializeObject(buddyCard.buddyCardData));
		GameLoginManager.instance.SetDepositedCards(dictionary);
		GuiScreenSingle<SquadScreen>.instance.cardpoolContent.UpdateScreenCache(GameLoginManager.currentPlayer.id, dictionary);
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		dictionary2.Add(buddyCard.id, JsonConvert.SerializeObject(buddyCard.buddyCardData));
		Dictionary<string, string> value = dictionary2;
		Singleton<BeanstalkServerManager>.instance.DepositCards(JsonConvert.SerializeObject(value), "[]", new List<Card> { buddyCard });
		mMemberCards = array;
	}

	public void RemoveCardFromPool(Card removeCard, int reputationPointsNew)
	{
		InitializeReputationPoints(reputationPointsNew);
		if (removeCard == null || mMemberCards.Length == 0)
		{
			return;
		}
		Card[] array = new Card[mMemberCards.Length - 1];
		int num = 0;
		bool flag = false;
		for (int i = 0; i < mMemberCards.Length; i++)
		{
			if (!(mMemberCards[i] == null))
			{
				if (!flag && mMemberCards[i].id == removeCard.id)
				{
					flag = true;
					continue;
				}
				array[num] = mMemberCards[i];
				num++;
			}
		}
		mMemberCards = array;
		InitializeWarcards(mMemberCards);
	}

	private void ShowPlayer(GameObject go)
	{
		if (!string.IsNullOrEmpty(mSquadMember.name))
		{
			TweenColor tweenColor = TweenColor.Begin(nickLabel.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mSquadMember.name, mSquadMember.id);
		}
	}

	private void ShowPlayerIcon(GameObject go)
	{
		if (!string.IsNullOrEmpty(mSquadMember.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mSquadMember.name, mSquadMember.id);
		}
	}

	public void FreeTextures()
	{
		if (mSquadMember == null)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < mMemberCards.Length; i++)
		{
			if (mMemberCards[i].isBuddyCard)
			{
				num = i;
			}
		}
		cards[0].CleanUp();
		if (num > -1)
		{
			mMemberCards[num].RemoveCard();
		}
		mMemberCards = new Card[0];
		Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mSquadMember.id);
		mSquadMember = null;
	}

	private void OnPlayerTextureCreated(string playerID, Texture2D playerTexture, bool useBackground)
	{
		if (mSquadMember != null && mSquadMember.id == playerID)
		{
			avatar.avatar = playerTexture;
			avatar.UpdateIcon();
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		UIEventListener uIEventListener = UIEventListener.Get(withdrawButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(WithdrawClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(depositButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DepositClick));
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener3 = UIEventListener.Get(withdrawButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(WithdrawClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(depositButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DepositClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(notifyButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(NotifyClick));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		FreeTextures();
	}
}
