using System;
using System.Collections.Generic;
using UnityEngine;

public class WarcardsContent : Core_BaseScript
{
	[Header("Core")]
	public UIPanel contentPanel;

	[Header("Filter Buttons")]
	public UITable filterTable;

	public List<CardFilter> filters;

	[Header("Card List")]
	public CardRecord cardRecordPrefab;

	public UIPooledGrid grid;

	public UIDraggablePanel draggablePanel;

	public UILabel noWarCardsLabel;

	[Header("Bottom Part")]
	public UIGrid bottomGrid;

	public List<CardPackRecord> cardPacks;

	private bool mIsActive;

	private bool mIsFullyShowed;

	private ObjectPool mPool;

	private List<Card> mShowedCards;

	private CardFilter mSelectedFilter;

	private List<int> mFilterCountTypes = new List<int>();

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
		TweenAlpha.Begin(cardPacks[0].gameObject, duration, toAlpha);
		TweenAlpha.Begin(cardPacks[1].gameObject, duration, toAlpha);
		TweenAlpha.Begin(cardPacks[2].gameObject, duration, toAlpha);
		TweenAlpha.Begin(cardPacks[3].gameObject, duration, toAlpha);
		TweenAlpha.Begin(cardPacks[4].gameObject, duration, toAlpha);
		for (int i = 0; i < grid.containItems; i++)
		{
			Transform itemOnIndex = grid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				TweenAlpha.Begin(itemOnIndex.gameObject, duration, toAlpha);
			}
		}
	}

	public void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += OnVideoAdEvent;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += OnVideoAdEvent;
		Singleton<OfferManager>.instance.SalesChanged += OnSalesChanged;
		CardManager.instance.ErrorHappened += OnError;
		CardManager.instance.CardPackBought += OnCardPackBought;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		GuiElement.HidingDialog = (Action<GuiElement>)Delegate.Combine(GuiElement.HidingDialog, new Action<GuiElement>(OnDialogHiding));
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
		if (cardPacks.Count < 5)
		{
			Debug.LogError("Missing Card Pack Records in Card Menu Screen");
		}
		foreach (CardPackRecord cardPack in cardPacks)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(cardPack.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CardPackClicked));
		}
		cardPacks[0].Initialize(CardPack.None);
		cardPacks[1].Initialize(CardPack.Gold);
		cardPacks[2].Initialize(CardPack.Silver);
		cardPacks[3].Initialize(CardPack.Bronze);
		cardPacks[4].Initialize(CardPack.Starter);
		mShowedCards = new List<Card>();
		float num = 366f;
		float num2 = 10f;
		float num3 = num + num2;
		bottomGrid.transform.localPosition = new Vector3(-2f * num3 - 10f, bottomGrid.transform.localPosition.y, bottomGrid.transform.localPosition.z);
		bottomGrid.cellWidth = num3;
	}

	private void OnPlayerDataLoaded()
	{
		if (mIsActive)
		{
			UpdateHeaderAndCards();
		}
	}

	private void OnVideoAdEvent()
	{
		if (mIsActive)
		{
			SetVideoWatchButtonLook();
		}
	}

	private void OnSalesChanged()
	{
		if (!mIsActive)
		{
			return;
		}
		foreach (CardPackRecord cardPack in cardPacks)
		{
			cardPack.SetSale();
		}
	}

	private void OnError()
	{
		if (mIsActive)
		{
			InitGUIValues();
		}
	}

	private void OnCardPackBought()
	{
		if (mIsActive)
		{
			UpdateHeaderAndCards();
			for (int i = 1; i < cardPacks.Count - 1; i++)
			{
				cardPacks[i].InitGuiValues();
			}
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (mIsActive && (action == DatabaseAction.AddVideoReward || action == DatabaseAction.BuyPack))
		{
			InitGUIValues();
		}
	}

	private void OnDialogHiding(GuiElement dialogToHide)
	{
		if (mIsActive)
		{
			bool flag = dialogToHide is RewardDialog;
			bool flag2 = dialogToHide is ConfirmDialog;
			bool flag3 = dialogToHide is WaitingDialog;
			if (flag || flag2 || flag3)
			{
				InitGUIValues();
			}
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

	public void InitGUIValues()
	{
		if (!mIsActive)
		{
			return;
		}
		UpdateHeaderAndCards(selectDefaultFilter: true);
		for (int i = 0; i < cardPacks.Count; i++)
		{
			cardPacks[i].InitGuiValues();
		}
		SetStarterOrValuePack();
		bottomGrid.repositionNow = true;
		bottomGrid.onReposition = delegate
		{
			bottomGrid.repositionNow = false;
			SetVideoWatchButtonLook();
			foreach (CardPackRecord cardPack in cardPacks)
			{
				cardPack.SetBasePosition();
			}
		};
	}

	public void DoAfterHide()
	{
		grid.MakeEmpty();
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

	protected void Update()
	{
		if (cardPacks[4].typePack == CardPack.Starter && !PlayerAnalytics.instance.showStarterPack)
		{
			SetStarterOrValuePack();
		}
	}

	public void SetStarterOrValuePack()
	{
		if (!mIsActive)
		{
			return;
		}
		bool showStarterPack = PlayerAnalytics.instance.showStarterPack;
		bool flag = !PlayerAnalytics.instance.data.IsPackBought(CardPack.Value);
		if (!showStarterPack && !flag)
		{
			cardPacks[4].typePack = CardPack.None;
			cardPacks[4].gameObject.SetActive(value: false);
			return;
		}
		cardPacks[4].gameObject.SetActive(value: true);
		if (!showStarterPack)
		{
			cardPacks[4].Initialize(CardPack.Value);
		}
		else if (!flag)
		{
			cardPacks[4].Initialize(CardPack.Starter);
		}
		else if (UnityEngine.Random.Range(0, 100) > 50)
		{
			cardPacks[4].Initialize(CardPack.Starter);
		}
		else
		{
			cardPacks[4].Initialize(CardPack.Value);
		}
	}

	public void UpdateHeaderAndCards(bool selectDefaultFilter = false)
	{
		if (!mIsActive)
		{
			return;
		}
		if (filterTable.gameObject.activeSelf)
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
		}
		DisplayCards();
	}

	public void StopBuyingCardPackAnimation()
	{
		if (cardPacks == null)
		{
			return;
		}
		for (int i = 0; i < cardPacks.Count; i++)
		{
			if (cardPacks[i] != null && cardPacks[i].isAnimating)
			{
				cardPacks[i].StopAnimationAndHide();
			}
		}
	}

	public void BuyCardPack(CardPackRecord pack)
	{
		CardPack typePack = pack.typePack;
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(typePack);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(typePack);
		float value = Singleton<GameVariables>.instance.PriceOfPack(typePack).Value1;
		switch (typePack)
		{
		case CardPack.Starter:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(CardPack.Starter));
			Debug.Log("STARTER PACK for $" + value.ToString("0.##"));
			break;
		case CardPack.Value:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(CardPack.Value));
			Debug.Log("VALUE PACK for $" + value.ToString("0.##"));
			break;
		case CardPack.Bronze:
		case CardPack.Silver:
		case CardPack.Gold:
		{
			if (pack == null)
			{
				break;
			}
			int num3 = Singleton<OfferManager>.instance.DiscountedCardpack(typePack);
			num = num * (100 - num3) / 100;
			num2 = num2 * (100 - num3) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, Localization.Localize(typePack.ToString().ToUpper() + "PACK"));
				GuiElementSingle<InappScreen>.instance.routeToStore = "WarCards";
				break;
			}
			if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, Localization.Localize(typePack.ToString().ToUpper() + "PACK"));
				GuiElementSingle<InappScreen>.instance.routeToStore = "WarCards";
				break;
			}
			if (num > 0)
			{
				Singleton<Wallet>.instance.WarBucksSpentFake(num);
			}
			if (num2 > 0)
			{
				Singleton<Wallet>.instance.GoldSpentFake(num2);
			}
			GuiScreenSingle<CardMenuScreen>.instance.owerlay.StartShowAnimation(CardManager.instance.BuyCardPack(typePack, num, num2, num3));
			pack.PlayBuyAnimation(GuiScreenSingle<CardMenuScreen>.instance.owerlay.transform);
			break;
		}
		default:
			Singleton<EventTrackingManager>.instance.ShowRewardedVideo(RewardType.RandomCard);
			cardPacks[0].SetVideoRewardPack(isVideoReady: false);
			break;
		}
	}

	public void DebugShowVideoReady()
	{
		cardPacks[0].SetVideoRewardPack(isVideoReady: true);
	}

	private void SetVideoWatchButtonLook()
	{
		bool videoRewardPack = Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.RandomCard);
		cardPacks[0].SetVideoRewardPack(videoRewardPack);
	}

	private void DisplayCards()
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
		int filterIndex = (filterTable.gameObject.activeSelf ? filters.FindIndex((CardFilter a) => a == mSelectedFilter) : 0);
		int num = SelectedFilter(filterIndex);
		foreach (Card item in CardManager.instance.cardsByRarity)
		{
			if ((num <= 0 || num == item.rarityNumber) && item.amount > 0)
			{
				mShowedCards.Add(item);
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
		grid.init(mShowedCards.Count, InstantiateWarcardRecord, FreeWarcardRecord, draggablePanel);
		draggablePanel.AlignToPos(instant: true);
		grid.PositionChanged();
		draggablePanel.MoveAbsolute(new Vector3(-0.003f, 0f, 0f));
		draggablePanel.AlignToPos(instant: false);
	}

	private Transform InstantiateWarcardRecord(int index)
	{
		if (mShowedCards.Count > index && index >= 0)
		{
			Card card = mShowedCards[index];
			CardRecord cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, grid.gameObject, "Card " + card.cardName);
			if (cardRecord != null)
			{
				cardRecord.Initialize(card, CardRecord.Behaviour.MyWarcards);
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

	private void CardPackClicked(GameObject go)
	{
		CardPackRecord component = go.GetComponent<CardPackRecord>();
		if (component != null)
		{
			switch (component.typePack)
			{
			case CardPack.None:
				Singleton<EventTrackingManager>.instance.ShowRewardedVideo(RewardType.RandomCard);
				cardPacks[0].SetVideoRewardPack(isVideoReady: false);
				break;
			case CardPack.Bronze:
			case CardPack.Silver:
			case CardPack.Gold:
				GuiElementSingle<PackDetailsDialog>.instance.ShowDialog(component.typePack, component);
				break;
			case CardPack.Starter:
				GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.STARTER_PACK);
				break;
			case CardPack.Value:
				GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
				break;
			}
		}
	}

	private int SelectedFilter(int filterIndex)
	{
		return filterIndex switch
		{
			1 => 4, 
			2 => 3, 
			3 => 2, 
			4 => 1, 
			_ => 0, 
		};
	}
}
