using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class CardpoolDialog : GuiElementSingle<CardpoolDialog>, IGuiDialog
{
	public enum Type
	{
		Withdraw,
		Deposit
	}

	[Header("Core")]
	public UIPanel dialogPanel;

	public GameObject backButton;

	public GameObject closeButton;

	[Header("Warcard Withdrawed")]
	public UIPanel centerTitleParent;

	public UILabel warcardWithdrew;

	public UILabel fromPlayer;

	public GameObject centerObject;

	public UITable bottomTable;

	public UILabel leftText;

	public WinStreakCounter centerText;

	public UILabel rightText;

	[Header("Withdraw Warcard")]
	public UIPanel leftTopPanel;

	public UITable leftTopTable;

	public PlayerIcon leftTopPlayerIcon;

	public UILabel leftTopPlayerName;

	public UIPanel centerPanel;

	public UIDraggablePanel draggablePanel;

	public UIPooledGrid warcardGrid;

	public CardRecord warcardPrefab;

	[Header("Deposit Warcards")]
	public UILabel leftTopTitle;

	public UITable filterTable;

	public List<CardFilter> filters;

	public GameObject bottomBackground;

	public GameObject bottomLeftPart;

	public UIGrid bottomGrid;

	public CardpoolDialogCardRecord warcardBottomPrefab;

	public GameObject okButton;

	private Type mCurrentType;

	private DatabasePlayer mPlayer;

	private CardFilter mSelectedFilter;

	private List<int> mFilterCountTypes = new List<int>();

	private List<Card> mShowCards;

	private List<Card> mDepositedCards;

	private List<CardpoolDialogCardRecord> mBottomContainers = new List<CardpoolDialogCardRecord>();

	private bool mAnimatingWithdraw;

	private Card mBuddyCardForDeposit;

	private int mIndexOfBuddyInDeposited;

	public void ShowDeposit(Card[] depositedCards)
	{
		mCurrentType = Type.Deposit;
		if (mDepositedCards == null)
		{
			mDepositedCards = new List<Card>();
		}
		else
		{
			mDepositedCards.Clear();
		}
		mIndexOfBuddyInDeposited = -1;
		Array.Sort(depositedCards, WarcardsSortingByRarity);
		if (depositedCards != null)
		{
			for (int i = 0; i < depositedCards.Length; i++)
			{
				if (!(depositedCards[i] == null))
				{
					mDepositedCards.Add(depositedCards[i]);
					if (depositedCards[i].isBuddyCard)
					{
						mIndexOfBuddyInDeposited = i;
					}
				}
			}
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowWithdraw(DatabasePlayer player, Card[] playerCards)
	{
		if (player == null)
		{
			return;
		}
		mCurrentType = Type.Withdraw;
		mPlayer = player;
		if (mShowCards == null)
		{
			mShowCards = new List<Card>();
		}
		else
		{
			mShowCards.Clear();
		}
		for (int i = 0; i < playerCards.Length; i++)
		{
			if (!(playerCards[i] == null))
			{
				mShowCards.Add(playerCards[i]);
			}
		}
		mShowCards.Sort(WarcardsSortingByRarity);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(okButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		CardManager.instance.WithdrawTimeChanged += OnWithdrawTimeChanged;
		bottomTable.onReposition = delegate
		{
			float val = 0f - bottomTable.padding.x - (rightText.transform.localPosition.x - bottomTable.padding.x) / 2f;
			bottomTable.transform.localPosition = bottomTable.transform.localPosition.ReplaceX(val);
		};
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		foreach (CardFilter filter in filters)
		{
			UIEventListener uIEventListener4 = UIEventListener.Get(filter.gameObject);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ChangeFilter));
		}
		mBottomContainers.Add(warcardBottomPrefab);
		warcardBottomPrefab.isBuddy = true;
		for (int num = 1; num < 11; num++)
		{
			CardpoolDialogCardRecord cardpoolDialogCardRecord = UnityEngine.Object.Instantiate(warcardBottomPrefab);
			cardpoolDialogCardRecord.transform.parent = bottomGrid.transform;
			cardpoolDialogCardRecord.transform.localScale = warcardBottomPrefab.transform.localScale;
			cardpoolDialogCardRecord.transform.localPosition = warcardBottomPrefab.transform.localPosition;
			cardpoolDialogCardRecord.name = $"WarCard {num + 1}";
			cardpoolDialogCardRecord.isBuddy = false;
			mBottomContainers.Add(cardpoolDialogCardRecord);
		}
		bottomGrid.cellWidth = ((!Singleton<GameVariables>.instance.isiPadResolution) ? 139f : 132f);
		bottomGrid.repositionNow = true;
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void OnPlayerTextureCreated(string playerID, Texture2D playerTexture, bool useBackground)
	{
		if (isShowed && mCurrentType == Type.Withdraw && mPlayer != null && mPlayer.id == playerID)
		{
			leftTopPlayerIcon.avatar = playerTexture;
			leftTopPlayerIcon.UpdateIcon();
		}
	}

	private void OnWithdrawTimeChanged()
	{
		if (isShowed && !mAnimatingWithdraw && CardManager.instance.nextWithdraw > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			centerText.StartCountingTo(CardManager.instance.nextWithdraw);
		}
	}

	public override void InitGUIValues()
	{
		closeButton.SetActive(mCurrentType == Type.Withdraw);
		okButton.SetActive(mCurrentType == Type.Deposit);
		centerTitleParent.gameObject.SetActive(value: false);
		bottomTable.gameObject.SetActive(mCurrentType == Type.Withdraw);
		leftText.gameObject.SetActive(value: false);
		centerText.gameObject.SetActive(value: false);
		rightText.gameObject.SetActive(mCurrentType == Type.Withdraw);
		leftTopTable.gameObject.SetActive(mCurrentType == Type.Withdraw);
		leftTopTitle.gameObject.SetActive(mCurrentType == Type.Deposit);
		filterTable.gameObject.SetActive(mCurrentType == Type.Deposit);
		bottomBackground.SetActive(mCurrentType == Type.Deposit);
		bottomLeftPart.SetActive(mCurrentType == Type.Deposit);
		bottomGrid.gameObject.SetActive(mCurrentType == Type.Deposit);
		warcardGrid.MakeEmpty();
		draggablePanel.onePanelDisabled = false;
		centerText.StopCountingTo();
		centerText.winStreakTimer = null;
		if (mCurrentType == Type.Withdraw)
		{
			rightText.text = Localization.Localize("ID_YOUCANWITHDRAWANYWARCARD");
			bottomTable.repositionNow = true;
			leftTopPlayerName.text = mPlayer.name;
			warcardWithdrew.text = Localization.LocalizeFormat("ID_WARCARDWITHDRAWED", mPlayer.name);
			fromPlayer.text = Localization.LocalizeFormat("ID_FROMPLAYER", mPlayer.name);
			leftTopPlayerIcon.Reset();
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(mPlayer);
			leftTopTable.repositionNow = true;
			warcardGrid.init(mShowCards.Count, InstantiateWarcard, FreeWarcard, draggablePanel);
			draggablePanel.AlignToPos(instant: true);
		}
		if (mCurrentType == Type.Deposit)
		{
			SetUpFilters();
			SetUpBottomContainers();
			ShowWarcardsAccordingToFilter();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<SquadScreen>.instance.cardpoolContent.draggablePanel.onePanelDisabled = true;
		draggablePanel.onePanelDisabled = false;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mCurrentType == Type.Deposit)
		{
			SendToServerChangesInDepositedWarCards();
		}
	}

	private void SendToServerChangesInDepositedWarCards()
	{
		CardManager.instance.ActualizeBuddyWarcardTime();
		List<Card> list = new List<Card>();
		List<Card> list2 = mDepositedCards;
		for (int i = 0; i < mBottomContainers.Count; i++)
		{
			if (mBottomContainers[i].card != null && (i <= 0 || !mBottomContainers[i].card.isBuddyCard))
			{
				list.Add(mBottomContainers[i].card);
			}
		}
		List<Card> list3 = new List<Card>();
		List<Card> list4 = new List<Card>();
		List<Card> list5 = new List<Card>();
		for (int j = 0; j < list2.Count + list.Count; j++)
		{
			Card processingCard = ((j >= list2.Count) ? list[j - list2.Count] : list2[j]);
			int num = list3.FindIndex((Card card1) => card1.id == processingCard.id);
			if (num >= 0)
			{
				continue;
			}
			list3.Add(processingCard);
			int num2 = 0;
			for (int num3 = 0; num3 < list2.Count; num3++)
			{
				if (processingCard.isBuddyCard)
				{
					if (list2[num3].isBuddyCard)
					{
						num2++;
					}
				}
				else if (list2[num3].id == processingCard.id)
				{
					num2++;
				}
			}
			int num4 = 0;
			for (int num5 = 0; num5 < list.Count; num5++)
			{
				if (processingCard.isBuddyCard)
				{
					if (list[num5].isBuddyCard)
					{
						num4++;
					}
				}
				else if (list[num5].id == processingCard.id)
				{
					num4++;
				}
			}
			if (num2 != num4)
			{
				while (num4 > num2)
				{
					list4.Add(processingCard);
					num4--;
				}
				while (num4 < num2)
				{
					list5.Add(processingCard);
					num2--;
				}
			}
		}
		if (list5.Count > 0 || list4.Count > 0)
		{
			Dictionary<string, string> cardsInJson = GetCardsInJson(mBottomContainers);
			GameLoginManager.instance.SetDepositedCards(cardsInJson);
			GuiScreenSingle<SquadScreen>.instance.cardpoolContent.UpdateScreenCache(GameLoginManager.currentPlayer.id, cardsInJson);
			ProcessWarcards(list5, list4);
			string cardsInJson2 = GetCardsInJson(list5);
			string cardsInJson3 = GetCardsInJson(list4);
			Singleton<BeanstalkServerManager>.instance.DepositCards(cardsInJson3, cardsInJson2, list4);
			GuiScreenSingle<SquadScreen>.instance.cardpoolContent.DepositedWarcards(list, list4);
		}
		else
		{
			Debug.Log("Deposited warcards DID NOT change");
		}
		draggablePanel.onePanelDisabled = true;
	}

	private string GetCardsInJson(List<Card> cards)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Card card in cards)
		{
			if (dictionary.ContainsKey(card.id))
			{
				CardManager.CardData cardData = JsonConvert.DeserializeObject<CardManager.CardData>(dictionary[card.id]);
				cardData.amount++;
				dictionary[card.id] = JsonConvert.SerializeObject(cardData);
			}
			else
			{
				dictionary.Add(card.id, (!card.isBuddyCard) ? JsonConvert.SerializeObject(new CardManager.CardData
				{
					amount = 1
				}) : JsonConvert.SerializeObject(CardManager.instance.buddyCard.buddyCardData));
			}
		}
		return JsonConvert.SerializeObject(dictionary);
	}

	private Dictionary<string, string> GetCardsInJson(List<CardpoolDialogCardRecord> cardContainer)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < cardContainer.Count; i++)
		{
			if (!(cardContainer[i].card != null))
			{
				continue;
			}
			Card card = cardContainer[i].card;
			if (i <= 0 || !card.isBuddyCard)
			{
				if (dictionary.ContainsKey(card.id))
				{
					CardManager.CardData cardData = JsonConvert.DeserializeObject<CardManager.CardData>(dictionary[card.id]);
					cardData.amount++;
					dictionary[card.id] = JsonConvert.SerializeObject(cardData);
				}
				else
				{
					dictionary.Add(card.id, (!card.isBuddyCard) ? JsonConvert.SerializeObject(new CardManager.CardData
					{
						amount = 1
					}) : JsonConvert.SerializeObject(CardManager.instance.buddyCard.buddyCardData));
				}
			}
		}
		return dictionary;
	}

	private void ProcessWarcards(List<Card> addedWarcards, List<Card> removedWarcards)
	{
		string text = "DEPOSITING INFORMATIONS:\n";
		foreach (Card addedWarcard in addedWarcards)
		{
			text += string.Format(" WITHDRAWED {0}\n", (!addedWarcard.isBuddyCard) ? addedWarcard.name : "BUDDY WARCARD");
			addedWarcard.AddCard();
		}
		foreach (Card removedWarcard in removedWarcards)
		{
			text += string.Format(" DEPOSIT {0}\n", (!removedWarcard.isBuddyCard) ? removedWarcard.name : "BUDDY WARCARD");
			if (!removedWarcard.isBuddyCard)
			{
				removedWarcard.RemoveCard();
			}
		}
		Debug.Log(text);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (mPlayer != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mPlayer.id);
			mPlayer = null;
		}
		for (int i = 0; i < mBottomContainers.Count; i++)
		{
			mBottomContainers[i].InitializeEmpty();
		}
		warcardGrid.MakeEmpty();
		if (mShowCards != null)
		{
			mShowCards.Clear();
		}
		GuiScreenSingle<SquadScreen>.instance.cardpoolContent.draggablePanel.onePanelDisabled = false;
		CardManager.instance.withdrawingCard = null;
	}

	private void ChangeFilter(GameObject go)
	{
		CardFilter filter = go.GetComponentsInChildren<CardFilter>(includeInactive: true)[0];
		int index = filters.FindIndex((CardFilter a) => a == filter);
		if (mSelectedFilter != null)
		{
			mSelectedFilter.Selected(select: false);
		}
		mSelectedFilter = filters[index];
		mSelectedFilter.Selected(select: true);
		ShowWarcardsAccordingToFilter();
	}

	private void ShowWarcardsAccordingToFilter()
	{
		int filterIndex = filters.FindIndex((CardFilter a) => a == mSelectedFilter);
		int num = SelectedFilter(filterIndex);
		if (mShowCards == null)
		{
			mShowCards = new List<Card>();
		}
		else
		{
			mShowCards.Clear();
		}
		if (mCurrentType == Type.Deposit && mIndexOfBuddyInDeposited == -1 && (num == 0 || num == 4))
		{
			mBuddyCardForDeposit = CardManager.instance.buddyCard;
			mShowCards.Add(mBuddyCardForDeposit);
		}
		else
		{
			mBuddyCardForDeposit = null;
		}
		foreach (Card item in CardManager.instance.cardsByRarity)
		{
			if ((num <= 0 || num == item.rarityNumber) && !item.isBuddyCard && item.amount > 0)
			{
				mShowCards.Add(item);
			}
		}
		bool flag = false;
		for (int num2 = 0; num2 < mDepositedCards.Count; num2++)
		{
			if ((num <= 0 || num == mDepositedCards[num2].rarityNumber) && !mShowCards.Contains(mDepositedCards[num2]))
			{
				mShowCards.Add(mDepositedCards[num2]);
				flag = true;
			}
		}
		if (flag)
		{
			mShowCards.Sort(WarcardsSortingByRarity);
		}
		warcardGrid.MakeEmpty();
		warcardGrid.init(mShowCards.Count, InstantiateWarcard, FreeWarcard, draggablePanel);
		draggablePanel.AlignToPos(instant: true);
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

	private void SetUpBottomContainers()
	{
		int num = 0;
		int squadDisplayLevel = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true)?.rank ?? 1;
		int num2 = Singleton<GameVariables>.instance.SquadCardpoolSize(squadDisplayLevel);
		if (mIndexOfBuddyInDeposited > -1)
		{
			mBottomContainers[0].InitializeCard(mDepositedCards[mIndexOfBuddyInDeposited]);
		}
		else
		{
			mBottomContainers[0].InitializeEmpty();
		}
		for (int i = 1; i < mBottomContainers.Count; i++)
		{
			if (i > num2)
			{
				mBottomContainers[i].InitializeNoCard();
			}
			else
			{
				if (num == mIndexOfBuddyInDeposited)
				{
					num++;
				}
				if (num >= mDepositedCards.Count)
				{
					mBottomContainers[i].InitializeEmpty();
				}
				else
				{
					mBottomContainers[i].InitializeCard(mDepositedCards[num]);
				}
			}
			num++;
		}
	}

	private void SetUpFilters()
	{
		mFilterCountTypes[0] = 0;
		mFilterCountTypes[1] = 0;
		mFilterCountTypes[2] = 0;
		mFilterCountTypes[3] = 0;
		mFilterCountTypes[4] = 0;
		foreach (Card item in CardManager.instance.cardsByRarity)
		{
			List<int> list2;
			List<int> list = (list2 = mFilterCountTypes);
			int index2;
			int index = (index2 = 0);
			index2 = list2[index2];
			list[index] = index2 + item.amount;
			List<int> list4;
			List<int> list3 = (list4 = mFilterCountTypes);
			int index3 = (index2 = item.rarityNumber);
			index2 = list4[index2];
			list3[index3] = index2 + item.amount;
		}
		filters[0].Init(Localization.LocalizeFormat("ID_GUI_ALLCARDS", mFilterCountTypes[0]), selected: true);
		filters[1].Init(Localization.LocalizeFormat("ID_GUI_BUDDY", mFilterCountTypes[4]), selected: false);
		filters[2].Init(Localization.LocalizeFormat("ID_GUI_GOLD", mFilterCountTypes[3]), selected: false);
		filters[3].Init(Localization.LocalizeFormat("ID_GUI_SILVER", mFilterCountTypes[2]), selected: false);
		filters[4].Init(Localization.LocalizeFormat("ID_GUI_BRONZE", mFilterCountTypes[1]), selected: false);
		filterTable.repositionNow = true;
		mSelectedFilter = filters[0];
	}

	private Transform InstantiateWarcard(int index)
	{
		if (0 <= index && index < mShowCards.Count)
		{
			CardRecord cardRecord = (CardRecord)Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(warcardPrefab, warcardGrid.gameObject, "WarCard Record " + index.ToString("D2"));
			if (cardRecord != null)
			{
				CardRecord.Behaviour behaviour = ((mCurrentType != Type.Deposit) ? CardRecord.Behaviour.Withdraw : CardRecord.Behaviour.Deposit);
				if (mShowCards[index] == mBuddyCardForDeposit && !CardManager.instance.isBuddyDepositAvailable)
				{
					behaviour = CardRecord.Behaviour.CountDownBuddy;
				}
				cardRecord.Initialize(mShowCards[index], behaviour);
				if (behaviour == CardRecord.Behaviour.Withdraw)
				{
					cardRecord.SetAvailable();
					cardRecord.OnCardClick += WithdrawCard;
				}
				else
				{
					SetCardRecord(cardRecord);
					cardRecord.OnCardClick += DepositCard;
				}
				if (isShowed && !base.isFullyShowed)
				{
					float alpha = dialogPanel.alpha1;
					float duration = (1f - alpha) * fadeInTime;
					cardRecord.cardPanel.alpha1 = alpha;
					TweenAlpha.Begin(cardRecord.gameObject, duration, alpha, 1f);
				}
				return cardRecord.transform;
			}
		}
		return null;
	}

	private void FreeWarcard(Transform transform)
	{
		CardRecord component = transform.GetComponent<CardRecord>();
		if (component != null)
		{
			component.DestroyPooled();
		}
	}

	public void WithdrawCard(CardRecord cardRecord)
	{
		if (!isShowed)
		{
			return;
		}
		mAnimatingWithdraw = true;
		string cardId = cardRecord.card.id;
		CardManager.instance.withdrawingCard = cardRecord.card;
		if (cardRecord.card.isBuddyCard)
		{
			CardManager.BuddyCardData buddyCardData = (cardRecord.card as CardBuddy).buddyCardData;
			CardManager.instance.AddBuddyCard(cardRecord.card.id, buddyCardData);
			cardId = "BuddyCard_" + buddyCardData.unityType;
		}
		else
		{
			CardManager.instance.AddCard(cardRecord.card.id);
		}
		Singleton<EventTrackingManager>.instance.RegisterWithdrawCard(cardId, CardManager.instance.GetRarityCounts());
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Withdraw_Card");
		Singleton<BeanstalkServerManager>.instance.WithdrawCard(mPlayer.id, cardRecord.card.id);
		int num = mPlayer.reputation + Singleton<GameVariables>.instance.ReputationPointsForWarcard(cardRecord.card.rarity);
		mPlayer.reputation = num;
		Dictionary<string, string> depositedCardsDic = mPlayer.depositedCardsDic;
		if (depositedCardsDic.ContainsKey(cardRecord.card.id))
		{
			string value = depositedCardsDic[cardRecord.card.id];
			CardManager.BuddyCardData buddyCardData2 = JsonConvert.DeserializeObject<CardManager.BuddyCardData>(value);
			if (buddyCardData2.amount == 1)
			{
				depositedCardsDic.Remove(cardRecord.card.id);
			}
			else
			{
				buddyCardData2.amount--;
				depositedCardsDic[cardRecord.card.id] = JsonConvert.SerializeObject(buddyCardData2);
			}
		}
		mPlayer.depositedCardsDic = depositedCardsDic;
		CardManager.instance.nextWithdraw = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 60 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CardWithdrawTimer).FLOATVALUE;
		Singleton<ServerResultsCache>.instance.UpdateSquadPlayer(mPlayer);
		GuiScreenSingle<SquadScreen>.instance.cardpoolContent.UpdateScreenCache(mPlayer.id, mPlayer.depositedCardsDic, num);
		GuiScreenSingle<SquadScreen>.instance.cardpoolContent.WithdrewCard(mPlayer, cardRecord.card, num);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CraftingClaim);
		WithdrawAnimation(cardRecord);
	}

	public void DepositCard(CardRecord cardRecord)
	{
		if (cardRecord.behaviour != CardRecord.Behaviour.Deposit)
		{
			return;
		}
		if (cardRecord.isAvailable)
		{
			if (AddCard(cardRecord))
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardEquiped);
				cardRecord.SelectForCraftingAnimation();
				Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Donate_Card");
			}
		}
		else if (!cardRecord.card.isBuddyCard)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardReturn);
			RemoveCardFromContainer(cardRecord);
		}
	}

	private bool AddCard(CardRecord cardRecord)
	{
		bool result = false;
		if (cardRecord.card.isBuddyCard)
		{
			if (mBottomContainers[0].isEmpty)
			{
				mBottomContainers[0].AnimateCard(cardRecord);
				result = true;
			}
		}
		else
		{
			for (int i = 1; i < mBottomContainers.Count; i++)
			{
				if (mBottomContainers[i].isEmpty)
				{
					mBottomContainers[i].AnimateCard(cardRecord);
					result = true;
					break;
				}
			}
		}
		SetCardRecord(cardRecord);
		return result;
	}

	public void RemoveCard(Card card)
	{
		for (int i = 0; i < warcardGrid.containItems; i++)
		{
			Transform itemOnIndex = warcardGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardRecord component = itemOnIndex.GetComponent<CardRecord>();
				if (component != null && component.card.id == card.id)
				{
					SetCardRecord(component);
				}
			}
		}
	}

	private void RemoveCardFromContainer(CardRecord cardRecord)
	{
		if (mCurrentType != Type.Deposit)
		{
			return;
		}
		foreach (CardpoolDialogCardRecord mBottomContainer in mBottomContainers)
		{
			if (mBottomContainer.card == cardRecord.card)
			{
				mBottomContainer.InitializeEmpty();
				SetCardRecord(cardRecord);
				break;
			}
		}
	}

	public void WithdrawAnimation(CardRecord cardRecord)
	{
		float dur = 0.4f;
		draggablePanel.onePanelDisabled = true;
		cardRecord.transform.parent = centerObject.transform;
		cardRecord.transform.localScale = Vector3.one;
		cardRecord.OnCardClick -= WithdrawCard;
		cardRecord.withdrawButton.SetActive(value: false);
		for (int i = 0; i < warcardGrid.containItems; i++)
		{
			Transform itemOnIndex = warcardGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardRecord component = itemOnIndex.GetComponent<CardRecord>();
				if (component != null && component != cardRecord)
				{
					component.OnCardClick -= WithdrawCard;
					TweenAlpha.Begin(component.gameObject, dur, 0f);
				}
			}
		}
		TweenAlpha.Begin(leftTopPanel.gameObject, dur, 0f);
		TweenAlpha.Begin(rightText.gameObject, dur * 0.75f, 0f);
		centerTitleParent.gameObject.SetActive(value: true);
		TweenAlpha.Begin(centerTitleParent.gameObject, dur * 0.75f, 0f, 0f).onFinished = delegate
		{
			TweenPosition.Begin(cardRecord.gameObject, dur, new Vector3(0f, 0f, -5f));
			centerText.gameObject.SetActive(value: true);
			centerText.counterLabel.alpha = 0f;
			if (CardManager.instance.nextWithdraw > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				centerText.StartCountingTo(CardManager.instance.nextWithdraw);
			}
			else
			{
				centerText.StartCountingTo(Singleton<BeanstalkServerManager>.instance.currentTimestamp + 60 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CardWithdrawTimer).FLOATVALUE);
			}
			WinStreakCounter winStreakCounter = centerText;
			winStreakCounter.TextChanged = (Action)Delegate.Remove(winStreakCounter.TextChanged, new Action(OnTextChanged));
			WinStreakCounter winStreakCounter2 = centerText;
			winStreakCounter2.TextChanged = (Action)Delegate.Combine(winStreakCounter2.TextChanged, new Action(OnTextChanged));
			WinStreakCounter winStreakCounter3 = centerText;
			winStreakCounter3.winStreakTimer = (Action)Delegate.Combine(winStreakCounter3.winStreakTimer, (Action)delegate
			{
				HideDialog();
			});
			leftText.gameObject.SetActive(value: true);
			leftText.alpha = 0f;
			rightText.text = Localization.Localize("ID_FORANOTHERWARCARD");
			bottomTable.repositionNow = true;
			TweenAlpha.Begin(centerTitleParent.gameObject, dur, 1f).onFinished = null;
			TweenAlpha.Begin(leftText.gameObject, dur, 1f);
			TweenAlpha.Begin(centerText.gameObject, dur, 1f);
			TweenAlpha.Begin(rightText.gameObject, dur, 1f);
			mAnimatingWithdraw = false;
		};
	}

	private void OnTextChanged()
	{
		bottomTable.repositionNow = true;
	}

	private int NumberOfCardsInContainers(CardRecord cardRecord)
	{
		int num = 0;
		for (int i = 0; i < mBottomContainers.Count; i++)
		{
			if (mBottomContainers[i].card != null && mBottomContainers[i].card.id == cardRecord.card.id)
			{
				num++;
			}
		}
		return num;
	}

	private int NumberOfCardsInDeposited(CardRecord cardRecord)
	{
		int num = 0;
		for (int i = 0; i < mDepositedCards.Count; i++)
		{
			if (mDepositedCards[i].id == cardRecord.card.id)
			{
				num++;
			}
		}
		return num;
	}

	private void SetCardRecord(CardRecord cardRecord)
	{
		int num = NumberOfCardsInContainers(cardRecord);
		int num2 = NumberOfCardsInDeposited(cardRecord);
		if (cardRecord.card.isBuddyCard)
		{
			bool flag = mBuddyCardForDeposit == cardRecord.card;
			bool flag2 = mIndexOfBuddyInDeposited > -1 && mDepositedCards[mIndexOfBuddyInDeposited] == cardRecord.card;
			if (flag && CardManager.instance.isBuddyDepositAvailable && num == 0)
			{
				cardRecord.SetAvailable();
				return;
			}
			cardRecord.SetUnAvailable();
			cardRecord.SetHighlight(flag2);
			if (flag2)
			{
				cardRecord.highlightSprite.alpha = 0.4f;
			}
			return;
		}
		int amount = cardRecord.card.amount;
		bool flag3 = amount + num2 > num;
		cardRecord.SetAmount(amount + num2 - num);
		if (flag3)
		{
			cardRecord.SetAvailable();
		}
		else
		{
			cardRecord.SetUnAvailable();
		}
		cardRecord.SetHighlight(num > 0);
		if (num > 0)
		{
			cardRecord.highlightSprite.alpha = 0.4f;
		}
	}

	private int SelectedFilter(int filterIndex)
	{
		switch (filterIndex)
		{
			case 1:
				return 4;
			case 2:
				return 3;
			case 3:
				return 2;
			case 4:
				return 1;
			default:
				return 0;
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(backButton);
	}
}
