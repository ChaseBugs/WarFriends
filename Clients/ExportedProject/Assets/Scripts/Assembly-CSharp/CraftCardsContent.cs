using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftCardsContent : Core_BaseScript
{
	public enum State
	{
		None,
		Craft,
		Crafting,
		Ready
	}

	[Header("Core")]
	public UIPanel contentPanel;

	public UIPanel[] panels;

	public CraftCardOverlay craftCardOverlay;

	[Header("Filter Buttons")]
	public UITable filterTable;

	public List<CardFilter> filters;

	[Header("Card List")]
	public CardRecord cardRecordPrefab;

	public UIPooledGrid grid;

	public UIDraggablePanel draggablePanel;

	public UILabel noWarCardsLabel;

	[Header("Bottom Part")]
	public UISprite border;

	public UISprite background;

	public UILabel hintLabel;

	public List<UISprite> craftingArrows;

	public List<CardContainer> craftingContainer;

	public CraftResult craftingResult;

	[Header("Debug")]
	public GameObject debugSpeedCraft;

	private bool mIsActive;

	private bool mIsFullyShowed;

	private ObjectPool mPool;

	private CardFilter mSelectedFilter;

	private List<Card> mShowedCards;

	private List<int> mFilterCountTypes = new List<int>();

	private int mAllowedRarity;

	private State mPreviousState;

	private bool[] mPreviousCraftingContainerContent = new bool[3];

	private string mCardIdForClaimAnimation = string.Empty;

	public bool canChangeContent
	{
		get
		{
			State state = GetState();
			return state == State.None || state == State.Craft;
		}
	}

	public bool isActive => GuiScreenSingle<CardMenuScreen>.instance.isShowed && mIsActive;

	private int mAllowedAsCardRarity
	{
		get
		{
			if (mAllowedRarity == 1)
			{
				return 1;
			}
			if (mAllowedRarity == 2)
			{
				return 2;
			}
			if (mAllowedRarity == 3)
			{
				return 3;
			}
			if (mAllowedRarity == 4)
			{
				return 4;
			}
			return 0;
		}
	}

	public State GetState()
	{
		if (CardCraftingManager.instance.isCardCrafting)
		{
			return State.Crafting;
		}
		if (CardCraftingManager.instance.isCardCrafted)
		{
			return State.Ready;
		}
		return ContainersAreFull() ? State.Craft : State.None;
	}

	public void Animate(bool showTab, bool instant)
	{
		mIsActive = showTab;
		mIsFullyShowed = false;
		if (mIsActive && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			AnimatePanels((!instant) ? (GuiScreenSingle<CardMenuScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(contentPanel.gameObject, (!instant) ? (GuiScreenSingle<CardMenuScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
				else
				{
					mIsFullyShowed = true;
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	private void AnimatePanels(float duration, float toAlpha)
	{
		for (int i = 0; i < grid.containItems; i++)
		{
			Transform itemOnIndex = grid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				TweenAlpha.Begin(itemOnIndex.gameObject, duration, toAlpha);
			}
		}
		for (int j = 0; j < panels.Length; j++)
		{
			if (panels[j].gameObject.activeSelf)
			{
				TweenAlpha.Begin(panels[j].gameObject, duration, toAlpha);
			}
		}
		for (int k = 0; k < craftingContainer.Count; k++)
		{
			if (toAlpha == 1f)
			{
				float toAlpha2 = ((!canChangeContent) ? 0.8f : 1f);
				craftingContainer[k].dragPart.alpha1 = 0f;
				craftingContainer[k].cardContent.alpha1 = 0f;
				TweenAlpha.Begin(craftingContainer[k].dragPart.gameObject, duration, 0f, toAlpha);
				TweenAlpha.Begin(craftingContainer[k].cardContent.gameObject, duration, 0f, toAlpha2);
			}
			else
			{
				TweenAlpha.Begin(craftingContainer[k].dragPart.gameObject, duration, toAlpha);
				TweenAlpha.Begin(craftingContainer[k].cardContent.gameObject, duration, toAlpha);
			}
		}
		TweenAlpha.Begin(craftingResult.panel.gameObject, duration, toAlpha);
	}

	public void AnimateShowOverride(float dur)
	{
		float toAlpha = ((!canChangeContent) ? 0.8f : 1f);
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			TweenAlpha.Begin(craftingContainer[i].cardContent.gameObject, dur, 0f, toAlpha);
		}
	}

	public void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
		CardManager.instance.ErrorHappened += OnError;
		CardManager.instance.CardPackBought += OnPlayerDataLoaded;
		CardCraftingManager.instance.EndTimeChanged += OnChangedCraftingEndTime;
		CardCraftingManager.instance.NewDataLoaded += OnError;
		GuiElement.HidingDialog = (Action<GuiElement>)Delegate.Combine(GuiElement.HidingDialog, new Action<GuiElement>(OnDialogHiding));
		DebugSettings.instance.Changed += SetDebugButtons;
		craftCardOverlay.InitControls();
		foreach (CardFilter filter in filters)
		{
			UIEventListener uIEventListener = UIEventListener.Get(filter.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ChangeFilter));
		}
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mShowedCards = new List<Card>();
		float activeWidth = UIRoot.list[0].activeWidth;
		border.transform.localScale = new Vector3(activeWidth - 370f, border.transform.localScale.y, border.transform.localScale.z);
		background.transform.localScale = new Vector3(activeWidth - 780f, background.transform.localScale.y, background.transform.localScale.z);
		hintLabel.lineWidth = (int)(activeWidth - 1600f);
		if (craftingContainer.Count < 3)
		{
			Debug.LogError("Too few containers!!!!");
		}
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			craftingContainer[i].InitCardContainer(i + 1);
			craftingContainer[i].SetEmpty();
			craftingContainer[i].ChangedContent += OnChangedContent;
			mPreviousCraftingContainerContent[i] = false;
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(craftingResult.craftButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CraftClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(craftingResult.claimButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ClaimClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(debugSpeedCraft);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DebugClick));
	}

	private void OnPlayerDataLoaded()
	{
		if (mIsActive)
		{
			UpdateHeaderAndCards();
		}
	}

	private void OnError()
	{
		if (mIsActive)
		{
			InitGUIValues();
		}
	}

	private void OnChangedCraftingEndTime()
	{
		if (mIsActive)
		{
			craftingResult.SetCrafting();
		}
	}

	private void OnDialogHiding(GuiElement dialogToHide)
	{
		if (mIsActive)
		{
			bool flag = dialogToHide is RewardDialog;
			bool flag2 = dialogToHide is ConfirmDialog;
			bool flag3 = dialogToHide is WaitingDialog;
			bool flag4 = dialogToHide is WarningDialog;
			if (flag || flag2 || flag3 || flag4)
			{
				UpdateHeaderAndCards(selectDefaultFilter: true);
			}
		}
	}

	private void SetDebugButtons()
	{
		debugSpeedCraft.SetActive(value: false);
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
		DisplayCards();
	}

	private void OnChangedContent()
	{
		State state = GetState();
		if (state != State.Crafting && state != State.Ready)
		{
			bool flag = craftingContainer[0].card == null;
			bool flag2 = craftingContainer[1].card == null;
			bool flag3 = craftingContainer[2].card == null;
			if (flag && flag2 && flag3)
			{
				mAllowedRarity = 0;
			}
			if (!flag)
			{
				mAllowedRarity = craftingContainer[0].card.rarityNumber;
			}
			if (!flag2)
			{
				mAllowedRarity = craftingContainer[1].card.rarityNumber;
			}
			if (!flag3)
			{
				mAllowedRarity = craftingContainer[2].card.rarityNumber;
			}
			if (!flag && !flag2 && !flag3)
			{
				craftingResult.SetWarcardBackground((CardManager.CardType)Mathf.Clamp(mAllowedAsCardRarity, 1, 4));
				craftingResult.Initialize(CraftResult.State.Craft);
			}
			else
			{
				craftingResult.Initialize(CraftResult.State.None);
			}
			UpdateShowCardRecords();
			InitializeArrowsAnimations();
		}
	}

	private void CraftClick(GameObject go)
	{
		List<Card> list = new List<Card>();
		foreach (CardContainer item in craftingContainer)
		{
			if (item.card != null)
			{
				list.Add(item.card);
			}
		}
		if (list.Count < 3)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTWARCARDS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			return;
		}
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CraftingStart);
		CardCraftingManager.instance.CraftWarcard(list);
		UpdateFilterNumbers();
		UpdateShowCardRecords();
		bool flag = list[0].rarity == CardManager.CardType.Silver;
		hintLabel.text = Localization.LocalizeFormat("ID_RANDOMWARCARDCRAFTINGINPROGRESS", Localization.Localize((!flag) ? "ID_SILVERSMALL" : "ID_GOLDSMALL"));
		MiscTools.SetUILabelRescale(hintLabel, 37f, 20f);
		craftingResult.SetCrafting();
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			craftingContainer[i].CraftingLook();
		}
		InitializeArrowsAnimations();
		if (!PlayerAnalytics.instance.data.craftingShown)
		{
			Singleton<BeanstalkServerManager>.instance.CraftingShown();
		}
	}

	private void ClaimClick(GameObject go)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CraftingClaim);
		Singleton<BeanstalkServerManager>.instance.ClaimCraftedCard();
		CardCraftingManager.instance.waitingForServerResponse = true;
		craftingResult.Initialize(CraftResult.State.Ready);
	}

	private void DebugClick(GameObject go)
	{
	}

	public void InitGUIValues()
	{
		craftCardOverlay.PrepareOverlay();
		InitializeCrafting();
		UpdateHeaderAndCards(selectDefaultFilter: true);
		SetDebugButtons();
	}

	public void DoAfterHide()
	{
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			if (!craftingContainer[i].isEmpty)
			{
				craftingContainer[i].ChangedContent -= OnChangedContent;
				craftingContainer[i].RemoveCard();
				craftingContainer[i].ChangedContent += OnChangedContent;
			}
		}
		ClearCacheAndDisplay();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = draggablePanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	public void UpdateHeaderAndCards(bool selectDefaultFilter = false)
	{
		if (mIsActive)
		{
			if (selectDefaultFilter)
			{
				mSelectedFilter = filters[0];
			}
			UpdateFilterNumbers();
			DisplayCards();
		}
	}

	private void UpdateFilterNumbers()
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
			int rarityNumber;
			int index = (rarityNumber = item.rarityNumber);
			rarityNumber = list2[rarityNumber];
			list[index] = rarityNumber + item.amount;
		}
		mFilterCountTypes[0] = mFilterCountTypes[1] + mFilterCountTypes[2];
		if (mSelectedFilter == null)
		{
			mSelectedFilter = filters[0];
		}
		bool selected = mSelectedFilter == filters[0];
		bool selected2 = mSelectedFilter == filters[1];
		bool selected3 = mSelectedFilter == filters[2];
		filters[0].Init(Localization.LocalizeFormat("ID_CRAFTABLEWARCARDS", mFilterCountTypes[0]), selected);
		filters[1].Init(Localization.LocalizeFormat("ID_GUI_SILVER", mFilterCountTypes[2]), selected2);
		filters[2].Init(Localization.LocalizeFormat("ID_GUI_BRONZE", mFilterCountTypes[1]), selected3);
		filterTable.repositionNow = true;
	}

	public bool TryToPutCardIntoEmptyContainer(CardRecord cardToPut)
	{
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			if (craftingContainer[i].isAvailable && craftingContainer[i].isEmpty && craftingContainer[i].InsertCardRecord(cardToPut))
			{
				return true;
			}
		}
		return false;
	}

	public void TryToRemoveCardFromAnyContainer(CardRecord cardToRemove)
	{
		State state = GetState();
		if (state == State.Crafting || state == State.Ready)
		{
			return;
		}
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			if (craftingContainer[i].isAvailable && !craftingContainer[i].isEmpty && craftingContainer[i].card.id == cardToRemove.card.id)
			{
				craftingContainer[i].RemoveCard();
				break;
			}
		}
	}

	public void UpdateCardRecord(Card card)
	{
		if (card == null)
		{
			return;
		}
		for (int i = 0; i < grid.containItems; i++)
		{
			Transform itemOnIndex = grid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardRecord component = itemOnIndex.GetComponent<CardRecord>();
				if (component.card.id == card.id)
				{
					SetAvailabilityLookForCrafting(component);
					SetAmountForCardRecord(component);
				}
			}
		}
	}

	public void ClaimAnimation(string cardId)
	{
		mCardIdForClaimAnimation = cardId;
		if (GuiScreenSingle<CardMenuScreen>.instance.isShowed && mIsActive)
		{
			StartClaimAnimation();
		}
	}

	public void StartClaimAnimation()
	{
		craftCardOverlay.AnimateWarcard(CardManager.instance.GetCardInstance(mCardIdForClaimAnimation));
	}

	public void ClaimingAnimationFinished()
	{
		craftingResult.Initialize(CraftResult.State.None);
		bool flag = true;
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			if (!craftingContainer[0].cardContent.gameObject.activeSelf)
			{
				continue;
			}
			if (i == 0)
			{
				flag = false;
				TweenScale.Begin(craftingContainer[0].cardContent.gameObject, 0.2f, Vector3.one, new Vector3(0.001f, 0.001f, 1f)).onFinished = delegate
				{
					EmptyContainers();
				};
			}
			else
			{
				TweenScale.Begin(craftingContainer[i].cardContent.gameObject, 0.2f, Vector3.one, new Vector3(0.001f, 0.001f, 1f));
			}
		}
		mAllowedRarity = 0;
		mCardIdForClaimAnimation = string.Empty;
		UpdateFilterNumbers();
		DisplayCards();
		hintLabel.text = Localization.Localize("ID_INSERTTHREESILVERORBRONZECARDS");
		MiscTools.SetUILabelRescale(hintLabel, 37f, 20f);
		InitializeArrowsAnimations();
		if (flag)
		{
			EmptyContainers();
		}
	}

	private void EmptyContainers()
	{
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			craftingContainer[i].ChangedContent -= OnChangedContent;
			craftingContainer[i].RemoveCard();
			craftingContainer[i].NormalLook();
			craftingContainer[i].ChangedContent += OnChangedContent;
		}
		InitializeArrowsAnimations();
		UpdateShowCardRecords();
	}

	private int NumberOfCardsInContainers(Card card)
	{
		int num = 0;
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			if (!craftingContainer[i].isEmpty && craftingContainer[i].card.id == card.id)
			{
				num++;
			}
		}
		return num;
	}

	private bool ContainersAreFull()
	{
		bool flag = false;
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			if (craftingContainer[i].isEmpty)
			{
				flag = true;
			}
		}
		return !flag;
	}

	private void InitializeCrafting()
	{
		mAllowedRarity = 0;
		List<Card> craftingCards = CardCraftingManager.instance.craftingCards;
		hintLabel.text = ((!CardCraftingManager.instance.isCrafting) ? Localization.Localize("ID_INSERTTHREESILVERORBRONZECARDS") : Localization.LocalizeFormat("ID_RANDOMWARCARDCRAFTINGINPROGRESS", Localization.Localize((craftingCards[0].rarity != CardManager.CardType.Silver) ? "ID_SILVERSMALL" : "ID_GOLDSMALL")));
		MiscTools.SetUILabelRescale(hintLabel, 37f, 20f);
		for (int i = 0; i < craftingContainer.Count; i++)
		{
			if (i < craftingCards.Count)
			{
				mAllowedRarity = craftingCards[i].rarityNumber;
				craftingContainer[i].ChangedContent -= OnChangedContent;
				craftingContainer[i].InsertCard(craftingCards[i], playSound: false);
				craftingContainer[i].ChangedContent += OnChangedContent;
			}
			else if (craftingContainer[i].isEmpty)
			{
				craftingContainer[i].SetEmpty();
			}
			else
			{
				craftingContainer[i].ChangedContent -= OnChangedContent;
				craftingContainer[i].RemoveCard();
				craftingContainer[i].ChangedContent += OnChangedContent;
			}
			mPreviousCraftingContainerContent[i] = i < craftingCards.Count;
		}
		switch (GetState())
		{
		case State.Ready:
			craftingResult.SetWarcardBackground(craftingCards[0].rarity);
			craftingResult.Initialize(CraftResult.State.Ready, initialization: true);
			break;
		case State.Craft:
			craftingResult.SetWarcardBackground(craftingCards[0].rarity);
			craftingResult.Initialize(CraftResult.State.Craft, initialization: true);
			break;
		case State.Crafting:
			craftingResult.SetWarcardBackground(craftingCards[0].rarity);
			craftingResult.SetCrafting(initialization: true);
			break;
		default:
			craftingResult.Initialize(CraftResult.State.None, initialization: true);
			break;
		}
		for (int j = 0; j < craftingContainer.Count; j++)
		{
			if (!craftingContainer[j].isEmpty && !canChangeContent)
			{
				craftingContainer[j].CraftingLook();
			}
			else
			{
				craftingContainer[j].NormalLook();
			}
		}
		InitializeArrowsAnimations(initialization: true);
	}

	private void ClearCacheAndDisplay()
	{
		grid.MakeEmpty();
		if (mShowedCards != null)
		{
			mShowedCards.Clear();
		}
		else
		{
			mShowedCards = new List<Card>();
		}
	}

	private void DisplayCards()
	{
		ClearCacheAndDisplay();
		int filterIndex = filters.FindIndex((CardFilter a) => a == mSelectedFilter);
		int num = SelectedFilter(filterIndex);
		foreach (Card item in CardManager.instance.cardsByRarity)
		{
			if ((num <= 0 || num == item.rarityNumber) && item.amount > 0 && item.rarityNumber < 3)
			{
				mShowedCards.Add(item);
			}
		}
		Card card;
		foreach (Card craftingCard in CardCraftingManager.instance.craftingCards)
		{
			card = craftingCard;
			if (num <= 0 || num == card.rarityNumber)
			{
				int num2 = mShowedCards.FindIndex((Card c1) => c1.id == card.id);
				if (num2 < 0)
				{
					mShowedCards.Add(card);
				}
			}
		}
		bool flag = mShowedCards.Count > 0;
		noWarCardsLabel.gameObject.SetActive(!flag);
		if (!flag)
		{
			noWarCardsLabel.text = Localization.Localize(GameVariables.noWarCardsDictionary[num]);
			draggablePanel.AlignToPos(instant: true);
			return;
		}
		mShowedCards.Sort(WarcardsSortingForCrafting);
		grid.init(mShowedCards.Count, InstantiateWarcardRecord, FreeWarcardRecord, draggablePanel);
		draggablePanel.AlignToPos(instant: true);
		grid.PositionChanged();
		draggablePanel.MoveAbsolute(new Vector3(-0.003f, 0f, 0f));
		draggablePanel.AlignToPos(instant: false);
	}

	private int WarcardsSortingForCrafting(Card c1, Card c2)
	{
		if (c1.rarityNumber == c2.rarityNumber)
		{
			return c1.cardName.CompareTo(c2.cardName);
		}
		return c2.rarityNumber.CompareTo(c1.rarityNumber);
	}

	private Transform InstantiateWarcardRecord(int index)
	{
		if (mShowedCards.Count > index && index >= 0)
		{
			Card card = mShowedCards[index];
			CardRecord cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, grid.gameObject, "Card " + card.cardName);
			if (cardRecord != null)
			{
				cardRecord.Initialize(card, CardRecord.Behaviour.CraftCards);
				SetAvailabilityLookForCrafting(cardRecord);
				SetAmountForCardRecord(cardRecord);
				if (mIsActive && !mIsFullyShowed)
				{
					float alpha = contentPanel.alpha1;
					float duration = (1f - alpha) * GuiScreenSingle<CardMenuScreen>.instance.fadeInTime;
					cardRecord.cardPanel.alpha1 = alpha;
					TweenAlpha.Begin(cardRecord.gameObject, duration, alpha, 1f);
				}
				return cardRecord.transform;
			}
		}
		return null;
	}

	private void FreeWarcardRecord(Transform toFree)
	{
		CardRecord component = toFree.GetComponent<CardRecord>();
		if (component != null)
		{
			component.DestroyPooled();
		}
	}

	private void UpdateShowCardRecords()
	{
		for (int i = 0; i < grid.containItems; i++)
		{
			Transform itemOnIndex = grid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardRecord component = itemOnIndex.GetComponent<CardRecord>();
				SetAvailabilityLookForCrafting(component);
				SetAmountForCardRecord(component);
			}
		}
	}

	private void SetAmountForCardRecord(CardRecord cardRecord)
	{
		State state = GetState();
		bool flag = state == State.Crafting || state == State.Ready;
		int num = NumberOfCardsInContainers(cardRecord.card);
		int amount = cardRecord.card.amount;
		cardRecord.SetAmount((!flag) ? (amount - num) : amount);
	}

	private void SetAvailabilityLookForCrafting(CardRecord cardRecord)
	{
		State state = GetState();
		int num = NumberOfCardsInContainers(cardRecord.card);
		int amount = cardRecord.card.amount;
		if (cardRecord.card.rarity == CardManager.CardType.Gold || cardRecord.card.rarity == CardManager.CardType.Buddy)
		{
			cardRecord.SetUnAvailable();
			cardRecord.SetHighlight(show: false);
		}
		else if (mAllowedAsCardRarity > 0 && mAllowedAsCardRarity != cardRecord.card.rarityNumber)
		{
			cardRecord.SetUnAvailable();
			cardRecord.SetHighlight(show: false);
		}
		else if (state == State.Crafting || state == State.Ready)
		{
			cardRecord.SetUnAvailable();
			if (num == 0)
			{
				cardRecord.SetHighlight(show: false);
			}
			else
			{
				cardRecord.highlightSprite.alpha = 0.4f;
			}
		}
		else if (num > 0)
		{
			if (amount <= num)
			{
				cardRecord.SetUnAvailable();
			}
			else
			{
				cardRecord.SetAvailable();
				cardRecord.SetHighlight(show: true);
			}
			cardRecord.highlightSprite.alpha = 0.4f;
		}
		else
		{
			cardRecord.SetAvailable();
		}
	}

	public void InitializeArrowsAnimations(bool initialization = false)
	{
		State state = GetState();
		if (initialization)
		{
			mPreviousState = state;
		}
		if (mPreviousState != state)
		{
			ArrowsAnimationsChangingState(mPreviousState, state);
		}
		else
		{
			ArrowsAnimationsForState(state, initialization);
		}
		mPreviousState = state;
	}

	private void ArrowsAnimationsChangingState(State fromState, State toState)
	{
		float duration = 0.25f;
		if (fromState == State.None && toState == State.Craft)
		{
			for (int i = 0; i < craftingArrows.Count; i++)
			{
				if (!mPreviousCraftingContainerContent[i])
				{
					mPreviousCraftingContainerContent[i] = true;
					ArrowScaleAndAlphaAnimation(craftingArrows[i], show: true, showStateCraft: true);
				}
			}
		}
		if (fromState == State.Craft && toState == State.None)
		{
			StopAlphaArrowsAnimation();
			for (int j = 0; j < craftingArrows.Count; j++)
			{
				if (craftingContainer[j].card == null)
				{
					mPreviousCraftingContainerContent[j] = false;
					ArrowScaleAndAlphaAnimation(craftingArrows[j], show: false);
				}
				else
				{
					TweenAlpha.Begin(craftingArrows[j].gameObject, duration, craftingArrows[j].alpha, 1f).onFinished = null;
				}
			}
		}
		if (fromState == State.Craft && toState == State.Crafting)
		{
			float toAlpha = 0.6f;
			TweenAlpha.Begin(craftingArrows[0].gameObject, duration, craftingArrows[0].alpha, toAlpha);
			TweenAlpha.Begin(craftingArrows[1].gameObject, duration, craftingArrows[1].alpha, toAlpha);
			TweenAlpha.Begin(craftingArrows[2].gameObject, duration, craftingArrows[2].alpha, toAlpha).onFinished = delegate
			{
				ArrowsAnimationsForState(State.Crafting);
			};
		}
		if (fromState == State.Crafting && toState == State.Ready)
		{
			StopAlphaArrowsAnimation();
			ArrowsAnimationsForState(State.Ready);
		}
		if (fromState == State.Ready && toState == State.None)
		{
			StopAlphaArrowsAnimation();
			TweenAlpha.Begin(craftingArrows[0].gameObject, duration, craftingArrows[0].alpha, 0f);
			TweenAlpha.Begin(craftingArrows[1].gameObject, duration, craftingArrows[1].alpha, 0f);
			TweenAlpha.Begin(craftingArrows[2].gameObject, duration, craftingArrows[2].alpha, 0f).onFinished = delegate
			{
				ArrowsAnimationsForState(State.None);
			};
		}
	}

	private void ArrowsAnimationsForState(State currentState, bool initialization = false)
	{
		float duration = 0.25f;
		if (currentState == State.None)
		{
			if (initialization)
			{
				StopAlphaArrowsAnimation();
				for (int i = 0; i < craftingArrows.Count; i++)
				{
					craftingArrows[i].alpha = 0f;
				}
			}
			for (int j = 0; j < craftingArrows.Count; j++)
			{
				bool flag = craftingContainer[j].card != null;
				if (flag && !mPreviousCraftingContainerContent[j])
				{
					mPreviousCraftingContainerContent[j] = true;
					ArrowScaleAndAlphaAnimation(craftingArrows[j], show: true);
				}
				if (!flag && mPreviousCraftingContainerContent[j])
				{
					mPreviousCraftingContainerContent[j] = false;
					ArrowScaleAndAlphaAnimation(craftingArrows[j], show: false);
				}
			}
		}
		if (currentState == State.Craft)
		{
			StopAlphaArrowsAnimation();
			StopScaleArrowsAnimation();
			ArrowWave(0);
		}
		if (currentState == State.Crafting)
		{
			float toAlpha = 0.6f;
			StopAlphaArrowsAnimation();
			StopScaleArrowsAnimation();
			TweenAlpha.Begin(craftingArrows[0].gameObject, duration, craftingArrows[0].alpha, toAlpha);
			TweenAlpha.Begin(craftingArrows[1].gameObject, duration, craftingArrows[1].alpha, toAlpha);
			TweenAlpha.Begin(craftingArrows[2].gameObject, duration, craftingArrows[2].alpha, toAlpha);
		}
		if (currentState == State.Ready)
		{
			StopAlphaArrowsAnimation();
			StopScaleArrowsAnimation();
			ArrowsPulse();
		}
	}

	private void ArrowScaleAndAlphaAnimation(UISprite arrow, bool show, bool showStateCraft = false)
	{
		float duration = 0.25f;
		arrow.alpha = ((!show) ? 1f : 0f);
		Vector3 vector = new Vector3(148f, 284f, 1f);
		Vector3 vector2 = vector * 1.4f;
		vector2.z = 1f;
		TweenScale.Begin(arrow.gameObject, duration, (!show) ? vector : vector2, (!show) ? vector2 : vector);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(arrow.gameObject, duration, (!show) ? 1f : 0f, (!show) ? 0f : 1f);
		tweenAlpha.onFinished = delegate
		{
			if (showStateCraft)
			{
				ArrowsAnimationsForState(State.Craft);
			}
		};
	}

	private void ArrowWave(int index)
	{
		float dur = 0.25f;
		float minAlpha = 0.5f;
		float maxAlpha = 1f;
		if (index < craftingArrows.Count)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(craftingArrows[index].gameObject, dur, maxAlpha, minAlpha);
			tweenAlpha.method = UITweener.Method.EaseOut;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(craftingArrows[index].gameObject, dur, minAlpha, maxAlpha);
				tweenAlpha3.method = UITweener.Method.EaseIn;
				tweenAlpha3.onFinished = null;
				ArrowWave(index + 1);
			};
		}
		else if (index > 6)
		{
			ArrowWave(0);
		}
		else
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(craftingArrows[0].gameObject, dur, maxAlpha, maxAlpha);
			tweenAlpha2.onFinished = delegate
			{
				ArrowWave(index + 1);
			};
		}
	}

	private void ArrowsPulse()
	{
		float dur = 0.35f;
		float minAlpha = 0.3f;
		float middleAlpha = 0.5f;
		float maxAlpha = 0.8f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(craftingArrows[0].gameObject, dur, middleAlpha, maxAlpha);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha = TweenAlpha.Begin(craftingArrows[1].gameObject, 0.66f * dur, middleAlpha, maxAlpha);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha = TweenAlpha.Begin(craftingArrows[2].gameObject, 0.66f * dur, middleAlpha, maxAlpha);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(craftingArrows[0].gameObject, 2f * dur, maxAlpha, minAlpha);
			tweenAlpha2.method = UITweener.Method.EaseInOut;
			tweenAlpha2 = TweenAlpha.Begin(craftingArrows[1].gameObject, 1.66f * dur, maxAlpha, minAlpha);
			tweenAlpha2.method = UITweener.Method.EaseInOut;
			tweenAlpha2 = TweenAlpha.Begin(craftingArrows[2].gameObject, 1.66f * dur, maxAlpha, minAlpha);
			tweenAlpha2.method = UITweener.Method.EaseInOut;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(craftingArrows[0].gameObject, dur, minAlpha, middleAlpha);
				tweenAlpha3.method = UITweener.Method.EaseIn;
				tweenAlpha3 = TweenAlpha.Begin(craftingArrows[1].gameObject, dur, minAlpha, middleAlpha);
				tweenAlpha3.method = UITweener.Method.EaseIn;
				tweenAlpha3 = TweenAlpha.Begin(craftingArrows[2].gameObject, dur, minAlpha, middleAlpha);
				tweenAlpha3.method = UITweener.Method.EaseIn;
				tweenAlpha3.onFinished = delegate
				{
					ArrowsPulse();
				};
			};
		};
	}

	private void StopAlphaArrowsAnimation()
	{
		TweenAlpha component = craftingArrows[0].gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.method = UITweener.Method.EaseInOut;
			component.onFinished = null;
			component.enabled = false;
		}
		component = craftingArrows[1].gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.method = UITweener.Method.EaseInOut;
			component.onFinished = null;
			component.enabled = false;
		}
		component = craftingArrows[2].gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.method = UITweener.Method.EaseInOut;
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void StopScaleArrowsAnimation()
	{
		TweenScale component = craftingArrows[0].gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = craftingArrows[1].gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = craftingArrows[2].gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		Vector3 localScale = new Vector3(148f, 284f, 1f);
		craftingArrows[0].transform.localScale = localScale;
		craftingArrows[1].transform.localScale = localScale;
		craftingArrows[2].transform.localScale = localScale;
	}

	private int SelectedFilter(int filterIndex)
	{
		switch (filterIndex)
		{
			case 1:
				return 2;
			case 2:
				return 1;
			default:
				return 0;
		}
	}
}
