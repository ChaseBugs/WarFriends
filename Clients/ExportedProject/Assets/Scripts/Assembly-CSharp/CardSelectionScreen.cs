using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectionScreen : GuiScreenSingle<CardSelectionScreen>
{
	public UIPanel screenPanel;

	[Header("Top")]
	public UIButton backButton;

	public LobbyHeader lobbyHeader;

	[Header("-Filters")]
	public UITable filterTable;

	public List<CardFilter> filters;

	[Header("Center")]
	public RandomCardRecord randomCardRecordPrefab;

	public UILabel noWarCardsLabel;

	[Header("-Card List")]
	public CardRecord cardRecordPrefab;

	public UIPooledGrid grid;

	public UIDraggablePanel draggablePanel;

	[Header("-Locked Part")]
	public GameObject lockedWarcards;

	public UILabel unlockWarcardsLabel;

	public UILabel unlockWarcardsHint;

	[Header("-Arena Part")]
	public GameObject arenaWarcardsRestriction;

	[Header("Bottom Left")]
	public List<CardContainer> containers;

	public UIPanel hintBuddyCardDialogPanel;

	[Header("Fight Button")]
	public UIButton fightButton;

	public GameObject fightButtonDisabled;

	public UILabel matchTimeCountdown;

	public UISprite matchTimeCountdownBackground;

	[Header("Tutorial")]
	public GameObject positionForTutorialText;

	public GameObject positionForTutorialHand;

	private CardFilter mSelectedFilter;

	private List<int> mFilterCountTypes = new List<int>();

	private ObjectPool mPool;

	private RandomCardRecord mBuyCardPack;

	private bool mShowBuy3Cards;

	private static int mCnt = 10000;

	private List<Card> mCardsToShow;

	private Dictionary<string, CardRecord> mCardDictionary;

	private bool mFightClicked;

	private bool mCountdownStarted;

	private float mBaseVolume = 0.052500002f;

	private float mVolumeIncrement = 0.027999999f;

	private float mTimer;

	public Dictionary<string, CardRecord> instantiatedCards => mCardDictionary;

	public CardContainer vipContainer => mVipContainer;

	private CardContainer mVipContainer => containers[3];

	private CardContainer mLockContainer => containers[4];

	private CardContainer mBuddyContainer => containers[5];

	private bool mIsWarcardsTutorial => TutorialManagerPlayWarcards.instance.isTutorialRunning;

	public void ShowLobby()
	{
		headerType = HeaderType.League;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardSelectionScreen>.instance);
	}

	public void ShowArenaLobby()
	{
		headerType = HeaderType.Arena;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardSelectionScreen>.instance);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		MatchManager.MatchStateChanged += MatchStateChanged;
		lobbyHeader.InitEvents();
	}

	private void MatchStateChanged(MatchState matchState)
	{
		if (isShowed && !mIsWarcardsTutorial)
		{
			if (MatchManager.canFight)
			{
				EnableFightButton();
			}
			else
			{
				DisableFightButton();
			}
		}
	}

	public void EnableFightButton()
	{
		fightButton.gameObject.SetActive(value: true);
		fightButtonDisabled.SetActive(value: false);
	}

	public void DisableFightButton()
	{
		fightButton.gameObject.SetActive(value: false);
		fightButtonDisabled.SetActive(value: true);
	}

	protected override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(fightButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(StartGame));
		UIEventListener uIEventListener2 = UIEventListener.Get(backButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BackButtonClicked));
		UIEventListener uIEventListener3 = UIEventListener.Get(hintBuddyCardDialogPanel.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HideBuddyCardHint();
		});
		foreach (CardFilter filter in filters)
		{
			UIEventListener uIEventListener4 = UIEventListener.Get(filter.gameObject);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ChangeFilter));
		}
		Singleton<VipManager>.instance.VipStatusChanged += VipContainer;
		CardManager.instance.ErrorHappened += delegate
		{
			if (isShowed)
			{
				InitGUIValues();
			}
		};
		CardManager.instance.CardPackBought += delegate
		{
			if (isShowed)
			{
				UpdateHeaderAndCards();
			}
		};
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += delegate
		{
			RemoveCardsFromContainers();
		};
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			RemoveCardsFromContainers();
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (isShowed)
			{
				if (action == DatabaseAction.BuyPack)
				{
					LockedContainer(CardManager.instance.extraSlot);
				}
				if (action == DatabaseAction.AddFacebook || action == DatabaseAction.SwitchToFacebook)
				{
					foreach (CardContainer container in containers)
					{
						container.RemoveCard();
					}
					CardManager.instance.cardsForGame.Clear();
				}
			}
		};
		lobbyHeader.InitControls();
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mFilterCountTypes.Add(0);
		mPool = Singleton<GuiManager>.instance.objectPool;
		mCardsToShow = new List<Card>();
		mBuyCardPack = (RandomCardRecord)mPool.InstantiateAsChild(randomCardRecordPrefab, grid.gameObject, "_random card");
		mBuyCardPack.Init(Localization.Localize("ID_GUI_BUYRANDOMCARDS"), Localization.Localize("ID_BUY"));
		mBuyCardPack.gameObject.SetActive(value: false);
		int num = 1;
		foreach (CardContainer container2 in containers)
		{
			container2.HookEvents();
			container2.InitCardContainer(num);
			num++;
		}
	}

	private void StartGame(GameObject go)
	{
		mFightClicked = true;
		Singleton<GameController>.instance.mainController.FinishChoosingCards();
		if (mIsWarcardsTutorial)
		{
			TutorialManagerPlayWarcards.instance.fightPressed = true;
		}
	}

	private void BackButtonClicked(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		if (mIsWarcardsTutorial)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITINGMATCH"), Localization.Localize("ID_CONFIRM_TUTORIALMATCH_TEXT"), delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					mFightClicked = false;
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
					TutorialManagerPlayWarcards.instance.FinishTutorial();
					GuiElementSingle<TutorialDialog>.instance.Hide();
					Singleton<GameController>.instance.gameControllerTutorial.RemoveCardsForCardsTutorial();
				}
			}, 0.2f);
		}
		else if (!string.IsNullOrEmpty(Singleton<GameController>.instance.mainController.quitText))
		{
			if (Singleton<GameController>.instance.mainController.ableToQuit)
			{
				GoBack();
				return;
			}
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITINGMATCH"), Singleton<GameController>.instance.mainController.quitText, delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					GoBack();
				}
			}, 0.2f);
		}
		else
		{
			mFightClicked = false;
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
			GuiScreenSingle<MissionScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		}
	}

	private void GoBack()
	{
		mFightClicked = false;
		if (Singleton<GameController>.instance.isBattle)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.ArenaScreenMode.MainArena;
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
			GuiScreenSingle<MissionScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		}
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

	private void RemoveCardsFromContainers()
	{
		foreach (CardContainer container in containers)
		{
			if (container.isAvailable && !container.isEmpty)
			{
				container.RemoveCard();
			}
		}
	}

	public override void InitGUIValues()
	{
		mFightClicked = false;
		AssignmentsManager.instance.GetAssignmentsAfterStarterEnd();
		if (mIsWarcardsTutorial)
		{
			FiltersLook(showFilters: false);
			WarcardsLockedLook(CardManager.CardFilter.All, showWarcardsLocked: false);
			BottomSlotsLook(isWarcardsLocked: false);
			InitializeWarcards(showWarcards: true);
			draggablePanel.disableDragIfFits = true;
			TutorialLook(showTutorial: true);
		}
		else if (LevelManager.instance.isWarcardsLocked)
		{
			FiltersLook(showFilters: false);
			WarcardsLockedLook(CardManager.CardFilter.All, showWarcardsLocked: true);
			BottomSlotsLook(isWarcardsLocked: true);
			InitializeWarcards(showWarcards: false);
			draggablePanel.disableDragIfFits = true;
			TutorialLook(showTutorial: false);
		}
		else
		{
			CardManager.CardFilter cardsFilter = Singleton<GameController>.instance.mainController.cardsFilter;
			bool flag = cardsFilter != CardManager.CardFilter.None;
			WarcardsLockedLook(cardsFilter, showWarcardsLocked: false);
			BottomSlotsLook(Singleton<GameController>.instance.mainController.cardsFilter);
			FiltersLook(cardsFilter == CardManager.CardFilter.All);
			InitializeWarcards(flag);
			draggablePanel.disableDragIfFits = !flag;
			TutorialLook(showTutorial: false);
		}
		InitializeCountdown();
		InitializeFightButton();
		InitializeHeader();
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		InitializePlayerRender();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (Singleton<GuiManager>.instance.toBeShowedUp != null)
		{
			Singleton<GuiManager>.instance.toBeShowedUp.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		grid.MakeEmpty();
		lobbyHeader.DoAfterHide();
		foreach (CardContainer container in containers)
		{
			if (container.isAvailable && !container.isEmpty)
			{
				container.DoAfterHide();
			}
		}
		hintBuddyCardDialogPanel.gameObject.SetActive(value: false);
		if (!mFightClicked)
		{
			Singleton<GameController>.instance.Quit();
		}
	}

	private void FiltersLook(bool showFilters)
	{
		filters[0].gameObject.SetActive(showFilters);
		filters[1].gameObject.SetActive(showFilters);
		filters[2].gameObject.SetActive(showFilters);
		filters[3].gameObject.SetActive(showFilters);
		filters[4].gameObject.SetActive(showFilters);
	}

	private void WarcardsLockedLook(CardManager.CardFilter restriction, bool showWarcardsLocked)
	{
		lockedWarcards.SetActive(showWarcardsLocked);
		if (showWarcardsLocked)
		{
			unlockWarcardsLabel.text = Localization.LocalizeFormat("ID_WARCARDSUNLOCKEDATRANK", LevelManager.instance.warcardsUnlockLevel);
			MiscTools.SetUILabelRescale(unlockWarcardsLabel, 66f, 37f, 930);
			unlockWarcardsHint.text = Localization.Localize("ID_WARCARDSARESPECIALBONUSES");
			MiscTools.SetUILabelRescale(unlockWarcardsHint, 35f, 17f, 1060);
		}
		arenaWarcardsRestriction.SetActive(restriction == CardManager.CardFilter.None);
	}

	private void BottomSlotsLook(bool isWarcardsLocked)
	{
		if (isWarcardsLocked)
		{
			containers[0].SetWarcardsLocked();
			containers[1].SetWarcardsLocked();
			containers[2].SetWarcardsLocked();
			mVipContainer.SetWarcardsLocked();
			mLockContainer.SetWarcardsLocked();
			mBuddyContainer.SetWarcardsLocked();
			return;
		}
		containers[0].SetEmpty();
		containers[1].SetEmpty();
		containers[2].SetEmpty();
		VipContainer(Singleton<VipManager>.instance.IsVipActive());
		LockedContainer(CardManager.instance.extraSlot);
		mBuddyContainer.SetEmpty();
		if (!mIsWarcardsTutorial)
		{
			InsertUnusedCardFromPreviousGame();
		}
	}

	private void BottomSlotsLook(CardManager.CardFilter cardFilter)
	{
		bool flag = cardFilter == CardManager.CardFilter.All || cardFilter == CardManager.CardFilter.Bronze || cardFilter == CardManager.CardFilter.Silver || cardFilter == CardManager.CardFilter.Gold;
		bool flag2 = cardFilter == CardManager.CardFilter.All || cardFilter == CardManager.CardFilter.Buddy;
		if (flag)
		{
			containers[0].SetEmpty();
			containers[1].SetEmpty();
			containers[2].SetEmpty();
			VipContainer(Singleton<VipManager>.instance.IsVipActive());
			LockedContainer(CardManager.instance.extraSlot);
		}
		else
		{
			containers[0].SetWarcardsLocked();
			containers[1].SetWarcardsLocked();
			containers[2].SetWarcardsLocked();
			mVipContainer.SetWarcardsLocked();
			mLockContainer.SetWarcardsLocked();
		}
		if (flag2)
		{
			mBuddyContainer.SetEmpty();
		}
		else
		{
			mBuddyContainer.SetWarcardsLocked();
		}
		if (flag && flag2 && !mIsWarcardsTutorial)
		{
			InsertUnusedCardFromPreviousGame();
		}
	}

	public void VipContainer(bool isVip)
	{
		if (LevelManager.instance.isWarcardsLocked)
		{
			mVipContainer.SetWarcardsLocked();
			return;
		}
		if (isVip)
		{
			mVipContainer.SetEmpty();
			return;
		}
		if (!mVipContainer.isEmpty)
		{
			mVipContainer.RemoveCard();
		}
		mVipContainer.SetVip();
	}

	public void LockedContainer(bool isUnlocked)
	{
		if (isUnlocked)
		{
			mLockContainer.SetEmpty();
		}
		else
		{
			mLockContainer.SetLocked();
		}
	}

	private void InsertUnusedCardFromPreviousGame()
	{
		int num = 0;
		foreach (CardContainer container in containers)
		{
			CardManager.CardFilter cardsFilter = Singleton<GameController>.instance.mainController.cardsFilter;
			if (!container.isAvailable)
			{
				continue;
			}
			if (container.isBuddyContainer)
			{
				foreach (Card item in CardManager.instance.cardsForGame)
				{
					if (!item.isBuddyCard || (CardManager.GetFilter(item.rarity) & cardsFilter) == 0)
					{
						continue;
					}
					container.InsertCard(item, playSound: false);
					break;
				}
				continue;
			}
			for (int i = num; i < CardManager.instance.cardsForGame.Count; i++)
			{
				Card card = CardManager.instance.cardsForGame[i];
				if (card == null || card.amount <= 0 || card.isBuddyCard)
				{
					num++;
				}
				else if ((CardManager.GetFilter(card.rarity) & cardsFilter) != CardManager.CardFilter.None)
				{
					container.InsertCard(card, playSound: false);
					num = i + 1;
					break;
				}
			}
		}
	}

	private void InitializeWarcards(bool showWarcards)
	{
		if (showWarcards)
		{
			mShowBuy3Cards = DebugSettings.isOurDevice && DebugSettings.debugEnabled && !mIsWarcardsTutorial;
			noWarCardsLabel.transform.localPosition = noWarCardsLabel.transform.localPosition.ReplaceX((!mShowBuy3Cards) ? 0f : 160f);
			mBuyCardPack.gameObject.SetActive(mShowBuy3Cards);
			UpdateHeaderAndCards(selectDefaultFilter: true);
			return;
		}
		mBuyCardPack.gameObject.SetActive(value: false);
		noWarCardsLabel.gameObject.SetActive(value: false);
		grid.MakeEmpty();
		mCardsToShow.Clear();
		if (mCardDictionary != null)
		{
			mCardDictionary.Clear();
		}
		else
		{
			mCardDictionary = new Dictionary<string, CardRecord>();
		}
	}

	private void InitializeCountdown()
	{
		mCountdownStarted = false;
		InitCountdownAnimation();
		matchTimeCountdown.text = string.Empty;
	}

	private void InitializeFightButton()
	{
		if (Singleton<GameController>.instance.isMission)
		{
			EnableFightButton();
		}
		else
		{
			MatchStateChanged(MatchManager.matchState);
		}
	}

	private void TutorialLook(bool showTutorial)
	{
		if (showTutorial)
		{
			mCountdownStarted = true;
		}
	}

	private void InitializeHeader()
	{
		if (!Singleton<GameController>.instance.isMission)
		{
			lobbyHeader.MatchStateChanged(MatchManager.matchState);
		}
		lobbyHeader.InitGUIValues();
	}

	private void InitializePlayerRender()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.currentPlayer, useBackground: true, PlayerTexturePool.RenderType.Classic);
		}
	}

	public void CancelClickedInLoadingDialog()
	{
		mFightClicked = false;
	}

	public void SetCardsForGame()
	{
		mFightClicked = true;
		CardManager.instance.ClearCardsForGame();
		foreach (CardContainer container in containers)
		{
			if (!container.isEmpty)
			{
				Card card = container.card;
				CardManager.instance.cardsForGame.Add(card);
			}
		}
		SavingLastSelected.instance.SaveSelectedCards();
	}

	public void UpdateHeaderAndCards(bool selectDefaultFilter = false)
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
		if (selectDefaultFilter)
		{
			mSelectedFilter = filters[0];
		}
		DisplayCards();
	}

	public void UpdateAvailability(Card card, bool available)
	{
		if (!(card == null) && mCardDictionary.ContainsKey(card.id))
		{
			if (available)
			{
				mCardDictionary[card.id].SetAvailable();
			}
			else
			{
				mCardDictionary[card.id].SetUnAvailable();
			}
		}
	}

	public bool TryToPutCardIntoEmptyContainer(CardRecord cardToPut)
	{
		foreach (CardContainer container in containers)
		{
			if (!container.isAvailable || !container.isEmpty || !container.InsertCardRecord(cardToPut))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public void TryToRemoveCardFromAnyContainer(CardRecord cardToRemove)
	{
		foreach (CardContainer container in containers)
		{
			if (!container.isAvailable || container.isEmpty || !(container.card.id == cardToRemove.card.id))
			{
				continue;
			}
			container.RemoveCard();
			break;
		}
	}

	private void DisplayCards()
	{
		grid.MakeEmpty();
		mCardsToShow.Clear();
		if (mCardDictionary != null)
		{
			mCardDictionary.Clear();
		}
		else
		{
			mCardDictionary = new Dictionary<string, CardRecord>();
		}
		int filterIndex = filters.FindIndex((CardFilter a) => a == mSelectedFilter);
		int num = SelectedFilter(filterIndex);
		foreach (Card item in CardManager.instance.cardsByRarity)
		{
			if ((num <= 0 || num == item.rarityNumber) && item.amount > 0)
			{
				mCardsToShow.Add(item);
			}
		}
		SetTutorialCards();
		int num2 = mCardsToShow.Count;
		if (mShowBuy3Cards)
		{
			num2++;
		}
		bool flag = mCardsToShow.Count > 0;
		noWarCardsLabel.gameObject.SetActive(!flag);
		if (!flag)
		{
			noWarCardsLabel.text = Localization.Localize(GameVariables.noWarCardsDictionary[num]);
			draggablePanel.AlignToPos(instant: true);
			return;
		}
		grid.init(num2, InstantiateByIndex, MakeItemFree, draggablePanel);
		draggablePanel.AlignToPos(instant: true);
		grid.PositionChanged();
		draggablePanel.MoveAbsolute(new Vector3(-0.003f, 0f, 0f));
		draggablePanel.AlignToPos(instant: false);
	}

	private int SelectedFilter(int filterIndex)
	{
		CardManager.CardFilter cardsFilter = Singleton<GameController>.instance.mainController.cardsFilter;
		if (filterIndex == 1 || cardsFilter == CardManager.CardFilter.Buddy)
		{
			return 4;
		}
		if (filterIndex == 2 || cardsFilter == CardManager.CardFilter.Gold)
		{
			return 3;
		}
		if (filterIndex == 3 || cardsFilter == CardManager.CardFilter.Silver)
		{
			return 2;
		}
		if (filterIndex == 4 || cardsFilter == CardManager.CardFilter.Bronze)
		{
			return 1;
		}
		return 0;
	}

	private void SetTutorialCards()
	{
		if (mIsWarcardsTutorial)
		{
			mCardsToShow.Clear();
			Singleton<GameController>.instance.gameControllerTutorial.InitTutorialCards();
			mCardsToShow.Add(Singleton<GameController>.instance.gameControllerTutorial.tutorialCards[0]);
			mCardsToShow.Add(Singleton<GameController>.instance.gameControllerTutorial.tutorialCards[1]);
			mCardsToShow.Add(Singleton<GameController>.instance.gameControllerTutorial.tutorialCards[2]);
		}
	}

	private Transform InstantiateByIndex(int index)
	{
		if (mShowBuy3Cards)
		{
			if (index == 0)
			{
				mBuyCardPack.gameObject.SetActive(value: true);
				return mBuyCardPack.transform;
			}
			index--;
		}
		if (mCardsToShow.Count > index && index >= 0)
		{
			Card card = mCardsToShow[index];
			CardRecord cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, grid.gameObject, mCnt--.ToString("D6") + "card " + card.cardName);
			if (cardRecord != null)
			{
				mCardDictionary[card.id] = cardRecord;
				cardRecord.Initialize(card, CardRecord.Behaviour.Lobby);
				CheckAvailability(cardRecord);
				if (isShowed && !base.isFullyShowed)
				{
					float alpha = screenPanel.alpha1;
					float duration = (1f - alpha) * fadeInTime;
					cardRecord.cardPanel.alpha1 = alpha;
					TweenAlpha.Begin(cardRecord.gameObject, duration, alpha, 1f);
				}
				return cardRecord.transform;
			}
		}
		return null;
	}

	private void CheckAvailability(CardRecord cardRec)
	{
		foreach (CardContainer container in containers)
		{
			if (container.isAvailable)
			{
				Card card = container.card;
				if (card != null && card == cardRec.card)
				{
					cardRec.SetUnAvailable();
					break;
				}
			}
		}
	}

	private void MakeItemFree(Transform toFree)
	{
		CardRecord component = toFree.GetComponent<CardRecord>();
		if (component != null)
		{
			if (mCardDictionary.ContainsKey(component.card.id))
			{
				mCardDictionary.Remove(component.card.id);
			}
			component.DestroyPooled();
		}
		else
		{
			toFree.gameObject.SetActive(value: false);
		}
	}

	private void InitCountdownAnimation()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(matchTimeCountdownBackground.gameObject, 0f, 0f);
		tweenAlpha.style = UITweener.Style.Once;
	}

	private IEnumerator CountdownAnimation()
	{
		float alpha = 0.3f;
		TweenAlpha tw5Sec = TweenAlpha.Begin(matchTimeCountdownBackground.gameObject, 1f, 0f, alpha);
		tw5Sec.style = UITweener.Style.Once;
		while (MatchManager.timeLeft > 6f)
		{
			if (MatchManager.timeLeft == float.MaxValue)
			{
				InitCountdownAnimation();
				yield break;
			}
			yield return 0;
		}
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CountdownSound, mBaseVolume + mVolumeIncrement * 6f);
		for (int i = 5; i >= 1; i--)
		{
			TweenAlpha tw4to1Sec = TweenAlpha.Begin(matchTimeCountdownBackground.gameObject, 0.5f, alpha, 0f);
			tw4to1Sec.style = UITweener.Style.PingPong;
			tw4to1Sec.NumOfRepetitions = 2;
			while (MatchManager.timeLeft > (float)i)
			{
				if (MatchManager.timeLeft == float.MaxValue)
				{
					InitCountdownAnimation();
					yield break;
				}
				yield return 0;
			}
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CountdownSound, mBaseVolume + mVolumeIncrement * (float)i);
		}
		TweenAlpha tw3Sec = TweenAlpha.Begin(matchTimeCountdownBackground.gameObject, 1f / 9f, alpha, 0f);
		tw3Sec.style = UITweener.Style.PingPong;
		tw3Sec.NumOfRepetitions = 9;
	}

	public void BuddyCardContainerClicked()
	{
		if (!LevelManager.instance.isWarcardsLocked)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (hintBuddyCardDialogPanel.gameObject.activeSelf)
			{
				HideBuddyCardHint();
			}
			else
			{
				ShowBuddyCardHint();
			}
		}
	}

	private void ShowBuddyCardHint()
	{
		hintBuddyCardDialogPanel.gameObject.SetActive(value: true);
		hintBuddyCardDialogPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(hintBuddyCardDialogPanel.gameObject, 0.4f, 1f).onFinished = null;
		hintBuddyCardDialogPanel.transform.localPosition = new Vector3(1250f, 286f, -60f);
		TweenPosition tweenPosition = TweenPosition.Begin(hintBuddyCardDialogPanel.gameObject, 0.25f, new Vector3(1250f, 286f, -60f), new Vector3(1250f, 316f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(hintBuddyCardDialogPanel.gameObject, 0.15f, new Vector3(1250f, 306f, -60f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void HideBuddyCardHint()
	{
		TweenAlpha.Begin(hintBuddyCardDialogPanel.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(hintBuddyCardDialogPanel.gameObject, 0.4f, new Vector3(1250f, 326f, -60f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			hintBuddyCardDialogPanel.gameObject.SetActive(value: false);
		};
	}

	protected override void Update()
	{
		base.Update();
		mTimer += Time.deltaTime;
		if (mTimer >= 0.333f)
		{
			mTimer -= 0.333f;
			UpdateTexts();
		}
	}

	private void UpdateTexts()
	{
		if (!mIsWarcardsTutorial)
		{
			matchTimeCountdown.text = MatchManager.matchTimeStatus;
			if (!mCountdownStarted && MatchManager.timeLeft <= 7f)
			{
				mCountdownStarted = true;
				matchTimeCountdownBackground.transform.localScale = matchTimeCountdownBackground.transform.localScale.ReplaceX(matchTimeCountdown.relativeSize.x * matchTimeCountdown.transform.localScale.x + 32f);
				StartCoroutine(CountdownAnimation());
			}
		}
	}

	public override void OnBack()
	{
		BackButtonClicked(null);
	}
}
