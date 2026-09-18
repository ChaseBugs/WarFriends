using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class CamosScreen : GuiScreenSingle<CamosScreen>
{
	[Header("Left Part")]
	public UITable headerTable;

	public UITable screenTable;

	public UILabel categoryName;

	public UILabel visualName;

	public UITable leftTable;

	public GameObject vipOnly;

	public GameObject notCompatiblePart;

	public UILabel notCompatibleText;

	public UILabel customizationRarityAndCategory;

	public UILabel customizationDescription;

	[Header("Right Part")]
	public UITable rightTable;

	public GameObject partsPart;

	public UIPanel visualOverlayPanel;

	public UISprite customizationIcon;

	public UISprite partsIcon;

	public UILabel partsLabel;

	public UILabel customizationPartsCountLabel;

	[Header("-Arena Part")]
	public GameObject arenaPart;

	public UILabel arenaHintLabel;

	public UIGrid arenaGrid;

	public UISprite[] arenaWins;

	public GameObject arenaTimerPart;

	public UILabel arenaTimerHintLabel;

	[Header("-Equip Part")]
	public GameObject equipPart;

	public UIButton equipButton;

	public GameObject equippedButtonOff;

	public UISprite equippedButtonOnHighlight;

	public UISprite equippedButtonOnIconInside;

	public UISprite equippedButtonOnIconOutSide;

	public UILabel equippedLabel;

	[Header("-Packs Button")]
	public UIButton packsButton;

	[Header("-Lootbox Hint")]
	public GameObject lootboxHintObject;

	public UILabel lootboxRemainingBattlesHint;

	public UIGrid lootboxRemainingBattlesGrid;

	public UISprite[] lootboxRemainingBattlesSprites;

	[Header("-Parts Hint")]
	public BoxCollider buttonHintCollider;

	public UISprite buttonHintSprite;

	public UIPanel hintPanel;

	public UISprite hintBackground;

	[Header("---Old Description")]
	public GameObject descriptionPart;

	public UILabel descriptionLabel;

	[Header("---Locked Part")]
	public GameObject lockedPart;

	public UILabel lockedLabel;

	[Header("---Buy Part")]
	public GameObject buyPart;

	public UIButton buyButton;

	public UITable prizeTable;

	public UILabel prizeLabel;

	public UISprite goldIcon;

	public UISprite warbucksIcon;

	[Header("---Sale Part")]
	public GameObject salePart;

	public UILabel salePercent;

	public WinStreakCounter saleTimeCounter;

	[Header("---Active Part")]
	public GameObject activePart;

	[Header("---Power Band Part")]
	public GameObject powerBandPart;

	public UISprite powerBandMiniIcon;

	public UILabel bonusLabel;

	public GameObject progressPart;

	public UISprite progress;

	public UILabel timeLabel;

	[Header("Bottom Part")]
	public UIGridStretchWidth categoriesGrid;

	public PlayerVisualsCategoryButton categoryButton;

	[Header("-Visuals List")]
	public PlayerVisualIcon playerVisualIconPrefab;

	public UIGrid bottomTable;

	public UIDraggablePanel draggablePanel;

	[HideInInspector]
	public PlayerVisualIcon selectedIcon;

	private List<PlayerVisualsCategoryButton> mAllButtons;

	private PlayerVisualsCategoryButton mSelectedCategoryButton;

	private List<PlayerVisualIcon> mAllIcons = new List<PlayerVisualIcon>();

	private PlayerVisual.State mPowerBandState;

	private bool mIsPowerBand;

	private bool mForceShow;

	private bool mChangedVisuals;

	private bool mShowedStats;

	private static Dictionary<int, string> mRarityAndCategory = new Dictionary<int, string>
	{
		{ 0, "ID_VISUALCATEGORY0" },
		{ 1, "ID_VISUALCATEGORY1" },
		{ 2, "ID_VISUALCATEGORY2" }
	};

	private float mTimer;

	public void SelectVisual(PlayerVisual visual)
	{
		mForceShow = true;
		SavingLastSelected.instance.SaveLastVisual(visual);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		DisplayModel();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mChangedVisuals)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(GameLoginManager.currentPlayer.id, useBackground: false, ignoreWarnings: true);
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(GameLoginManager.currentPlayer.id, useBackground: true, ignoreWarnings: true);
		}
		Singleton<ArmyPreviewCamera>.instance.HidePlayer(CamosManager.instance.mainPlayer);
		PlayerController.currentPlayer.playerProperties.playerVisuals = CamosManager.instance.equppedIndices;
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(isSelected: false);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		saleTimeCounter.StopCountingTo();
		saleTimeCounter.winStreakTimer = null;
		InstaHideHintStats();
	}

	protected override void InitControls()
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		int num = playerVisualCategories.Count - 1;
		mAllButtons = new List<PlayerVisualsCategoryButton>();
		foreach (PlayerVisualCategory item in playerVisualCategories)
		{
			if (!(item is PlayerVisualCategoryPowerBands))
			{
				PlayerVisualsCategoryButton playerVisualsCategoryButton = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(categoryButton, categoriesGrid.gameObject, $"Category Button {item.categoryNumber}") as PlayerVisualsCategoryButton;
				playerVisualsCategoryButton.transform.localPosition = new Vector3(playerVisualsCategoryButton.transform.localPosition.x, playerVisualsCategoryButton.transform.localPosition.y, 0f);
				playerVisualsCategoryButton.Initialize(item, num);
				if (mSelectedCategoryButton == null)
				{
					mSelectedCategoryButton = playerVisualsCategoryButton;
				}
				mAllButtons.Add(playerVisualsCategoryButton);
			}
		}
		categoriesGrid.columns = num;
		categoriesGrid.Reposition();
		bottomTable.sorted = true;
		bottomTable.repositionNow = true;
		Singleton<ArmyPreviewCamera>.instance.OnRotate += PreviewCameraOnRotate;
		UIEventListener uIEventListener = UIEventListener.Get(buyButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnBuyClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(equipButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OnEquipClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(packsButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OnPacksClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(buttonHintCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HintButtonClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(hintBackground.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HintBackgroundClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (!isShowed || action != DatabaseAction.BuyPack)
			{
				return;
			}
			Select(selectedIcon);
			foreach (PlayerVisualIcon mAllIcon in mAllIcons)
			{
				mAllIcon.UpdateGraphics();
				mAllIcon.SetEquipped();
			}
		};
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				UpdateSalesInCategories();
				foreach (PlayerVisualIcon mAllIcon2 in mAllIcons)
				{
					mAllIcon2.SetSale();
				}
				SetSaleAndPrice();
			}
		};
		prizeTable.onReposition = delegate
		{
			float val = (0f - (prizeLabel.transform.parent.transform.localPosition.x - prizeTable.padding.x)) / 2f - prizeTable.padding.x;
			prizeTable.transform.localPosition = prizeTable.transform.localPosition.ReplaceX(val);
		};
		screenTable.onReposition = delegate
		{
			headerTable.repositionNow = true;
		};
		bottomTable.onReposition = delegate
		{
			if (selectedIcon != null)
			{
				bottomTable.repositionNow = false;
				Vector3 vec = selectedIcon.transform.localPosition + selectedIcon.transform.parent.localPosition;
				draggablePanel.AlignToCenter(vec, instant: true);
			}
		};
		rightTable.onReposition = delegate
		{
			float z = hintPanel.transform.localPosition.z;
			hintPanel.transform.position = buttonHintSprite.transform.position;
			hintPanel.transform.localPosition = new Vector3(hintPanel.transform.localPosition.x, hintPanel.transform.localPosition.y + 4f, z);
		};
		InitializeEquipLabel();
		InstaHideHintStats();
	}

	private void OnBuyClick(GameObject go)
	{
		if (selectedIcon.visual.isVipOnly && !Singleton<VipManager>.instance.IsVipActive())
		{
			return;
		}
		int priceGold = selectedIcon.visual.priceGold;
		int priceWarbucks = selectedIcon.visual.priceWarbucks;
		if (!Singleton<Wallet>.instance.CanBuyGold(priceGold))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(priceGold, selectedIcon.visual.name);
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyW(priceWarbucks))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(priceWarbucks, selectedIcon.visual.name);
			return;
		}
		mChangedVisuals = true;
		Singleton<Wallet>.instance.WarBucksSpentFake(priceWarbucks);
		Singleton<Wallet>.instance.GoldSpentFake(priceGold);
		BuyPlayerVisual(selectedIcon.visual, 0);
		selectedIcon.visual.Equip();
		Select(selectedIcon);
		foreach (PlayerVisualIcon mAllIcon in mAllIcons)
		{
			mAllIcon.UpdateGraphics();
			mAllIcon.SetEquipped();
		}
	}

	private void OnEquipClick(GameObject go)
	{
		if (selectedIcon.visual.isEquipped)
		{
			return;
		}
		mChangedVisuals = true;
		EquipPlayerVisual(selectedIcon.visual);
		foreach (PlayerVisualIcon mAllIcon in mAllIcons)
		{
			mAllIcon.SetEquipped();
		}
		if (mIsPowerBand)
		{
			Select(selectedIcon);
			return;
		}
		equippedLabel.text = Localization.Localize("ID_GUI_EQUIPPED");
		float duration = 0.3f;
		TweenColor.Begin(equippedLabel.gameObject, duration, Color.white);
		TweenAlphaHider.Begin(equippedButtonOff, duration, 0f);
		TweenAlpha.Begin(equippedButtonOnHighlight.gameObject, duration, 1f);
		TweenAlpha.Begin(equippedButtonOnIconOutSide.gameObject, duration, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(equippedButtonOnIconInside.gameObject, duration, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
		CamosManager.instance.UpdateVisuals(CamosManager.instance.mainPlayer);
	}

	private void OnPacksClick(GameObject go)
	{
		if (selectedIcon.visual.purchasable == PlayerVisual.Purchasable.ValuePack)
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
		}
		else if (selectedIcon.visual.purchasable == PlayerVisual.Purchasable.StarterPack)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.STARTER_PACK);
		}
		else if (selectedIcon.visual.purchasable == PlayerVisual.Purchasable.StarterAssignment)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<StarterAssignmentDialog>.instance, 0f);
		}
		else
		{
			Debug.LogError($"Customization {selectedIcon.visual.visualName} is purchasable through {selectedIcon.visual.purchasable}");
		}
	}

	public void OnVisualChanged()
	{
		mChangedVisuals = true;
		foreach (PlayerVisualIcon mAllIcon in mAllIcons)
		{
			mAllIcon.SetEquipped();
		}
		Select(selectedIcon);
	}

	public override void InitGUIValues()
	{
		mChangedVisuals = false;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		PlayerVisual playerVisual = ChooseVisualToShow();
		foreach (PlayerVisualsCategoryButton mAllButton in mAllButtons)
		{
			if (mAllButton.category == playerVisual.owner)
			{
				SelectCategory(mAllButton);
				break;
			}
		}
		foreach (PlayerVisualIcon mAllIcon in mAllIcons)
		{
			if (mAllIcon.visual == playerVisual)
			{
				Select(mAllIcon);
				break;
			}
		}
		foreach (PlayerVisualIcon mAllIcon2 in mAllIcons)
		{
			mAllIcon2.InitGuiValuesGraphics();
			mAllIcon2.SetEquipped();
		}
		Vector3 vec = selectedIcon.transform.localPosition + selectedIcon.transform.parent.localPosition;
		draggablePanel.AlignToCenter(vec, instant: true);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new CustomizationTutorialMessage());
		}
	}

	private PlayerVisual ChooseVisualToShow()
	{
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisual();
		if (playerVisual == null)
		{
			Debug.Log("Last visual not choosen!!!!!");
			foreach (PlayerVisual allVisual in CamosManager.instance.playerVisualCategories[0].allVisuals)
			{
				if (allVisual.isEquipped)
				{
					playerVisual = allVisual;
				}
			}
		}
		if (mForceShow)
		{
			mForceShow = false;
			return playerVisual;
		}
		PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
		if (unlockedVisualWithNotification != null)
		{
			return unlockedVisualWithNotification;
		}
		return playerVisual;
	}

	public void Select(PlayerVisualIcon playerVisualIcon)
	{
		if (!(playerVisualIcon == null))
		{
			if (selectedIcon != null)
			{
				selectedIcon.SetHighlight(isSelected: false);
			}
			selectedIcon = playerVisualIcon;
			selectedIcon.SetHighlight(isSelected: true);
			if (selectedIcon.visual.notificate)
			{
				WasShown(selectedIcon.visual);
			}
			selectedIcon.visual.showed = true;
			selectedIcon.ShowHideNotification();
			selectedIcon.visual.ApplyVisual(CamosManager.instance.mainPlayer, useHighRes: true);
			CamosManager.instance.UpdateVisuals(CamosManager.instance.mainPlayer);
			mIsPowerBand = false;
			SavingLastSelected.instance.SaveLastVisual(selectedIcon.visual);
			InitializeLeftPart();
			InitializeRightPart();
			UpdateNotificationsInCategories();
			UpdateSalesInCategories();
		}
	}

	private void InitializeLeftPart()
	{
		categoryName.text = mSelectedCategoryButton.label.text;
		visualName.text = selectedIcon.visual.name.ToUpper();
		screenTable.repositionNow = true;
		vipOnly.SetActive(value: false);
		if (selectedIcon.visual.owner.categoryNumber == 1 || selectedIcon.visual.owner.categoryNumber == 2)
		{
			string text = CamosManager.instance.mainPlayer.playerProperties.playerVisuals[1];
			string text2 = CamosManager.instance.mainPlayer.playerProperties.playerVisuals[2];
			bool helmetHidden = false;
			bool headAccesoryHidden = false;
			CamosManager.instance.GetVisualVisibility(text, text2, out helmetHidden, out headAccesoryHidden);
			bool flag = helmetHidden || headAccesoryHidden;
			if (flag)
			{
				string idVisual = ((!(mSelectedCategoryButton.category == CamosManager.instance.playerVisualCategories[1])) ? text : text2);
				notCompatibleText.text = Localization.LocalizeFormat("ID_NOTCOMPATIBLEWITH", CamosManager.instance.GetVisual(idVisual).name);
			}
			notCompatiblePart.SetActive(flag);
		}
		else
		{
			notCompatiblePart.SetActive(value: false);
		}
		customizationDescription.text = selectedIcon.visual.description;
		string keyFormat = mRarityAndCategory[selectedIcon.visual.owner.categoryNumber];
		customizationRarityAndCategory.text = ((!selectedIcon.visual.isFromArena) ? Localization.LocalizeFormat(keyFormat, selectedIcon.visual.rarityName, Colours.stringWhite) : Localization.Localize("ID_ARENARARITY"));
		customizationRarityAndCategory.color = ((!selectedIcon.visual.isFromArena) ? GameVariables.rarityColours[selectedIcon.visual.rarity] : Colours.rarityArena);
		leftTable.repositionNow = true;
	}

	private void InitializeRightPart()
	{
		descriptionPart.SetActive(value: false);
		lockedPart.SetActive(value: false);
		buyPart.SetActive(value: false);
		activePart.SetActive(value: false);
		bool isBought = selectedIcon.visual.isBought;
		bool purchasableInShop = selectedIcon.visual.purchasableInShop;
		bool isFromArena = selectedIcon.visual.isFromArena;
		equipPart.SetActive(isBought);
		packsButton.gameObject.SetActive(!isBought && !purchasableInShop && !isFromArena);
		partsPart.SetActive(!isBought && purchasableInShop);
		arenaPart.SetActive(!isBought && isFromArena);
		arenaTimerPart.SetActive(isBought && isFromArena);
		if (isFromArena)
		{
			if (isBought)
			{
				arenaTimerHintLabel.text = Localization.LocalizeFormat("ID_ARENAREWARDEXPIRATION", MiscTools.PrintableTime((float)selectedIcon.visual.remainingTime, "ID_READYTIME", string.Empty));
			}
			WarArenaConfig.VisualType visualType = (WarArenaConfig.VisualType)(selectedIcon.visual.rarity + 1);
			int num = ((WarArena.instance.warArenaConfig != null) ? WarArena.instance.warArenaConfig.GetVisualRequirements(visualType) : 0);
			arenaHintLabel.text = Localization.LocalizeFormat("ID_ARENAREWARDREQUIREMENTS", num);
			for (int i = 0; i < arenaWins.Length; i++)
			{
				arenaWins[i].gameObject.SetActive(i < num);
			}
			float val = -24f - (float)num * 39f / 2f;
			arenaGrid.transform.localPosition = arenaGrid.transform.localPosition.ReplaceX(val);
		}
		if (isBought)
		{
			InitializeEquipButton();
			InstaHideHintStats();
		}
		else if (purchasableInShop)
		{
			if (partsPart.activeSelf)
			{
				customizationIcon.spriteName = selectedIcon.visual.icon;
				customizationIcon.MakePixelPerfect();
				float multiplier = Mathf.Min(136f / customizationIcon.transform.localScale.x, 136f / customizationIcon.transform.localScale.y);
				customizationIcon.transform.localScale = customizationIcon.transform.localScale.MultiplyXY(multiplier);
			}
			customizationPartsCountLabel.color = GameVariables.rarityColours[selectedIcon.visual.rarity];
			partsIcon.color = customizationPartsCountLabel.color;
			partsLabel.color = customizationPartsCountLabel.color;
			customizationPartsCountLabel.text = $"{selectedIcon.visual.numberOfParts} {Colours.stringGrayParts}/{Colours.stringWhite} {selectedIcon.visual.numberOfPartsMax}";
		}
		lootboxHintObject.SetActive(purchasableInShop);
		if (purchasableInShop)
		{
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
			int num3 = num2 - PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			lootboxRemainingBattlesHint.text = Localization.LocalizeFormat("ID_PLAYPVPRANKEDBATTLESTOGETLOOTBOX", num2, Colours.stringCyanLootbox, Colours.stringGrayParts, num3);
			float num4 = 530f / (float)num2 - 8f;
			for (int j = 0; j < lootboxRemainingBattlesSprites.Length; j++)
			{
				lootboxRemainingBattlesSprites[j].gameObject.SetActive(j < num2);
				lootboxRemainingBattlesSprites[j].transform.localScale = lootboxRemainingBattlesSprites[j].transform.localScale.ReplaceX(num4);
				if (j < num2)
				{
					lootboxRemainingBattlesSprites[j].color = ((j >= num3) ? Colours.grayParts : Colours.cyanLootbox);
				}
			}
			lootboxRemainingBattlesGrid.cellWidth = num4 + 8f;
			lootboxRemainingBattlesGrid.repositionNow = true;
		}
		if (base.isFullyShowed && visualOverlayPanel.gameObject.activeInHierarchy)
		{
			TweenAlpha component = visualOverlayPanel.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			visualOverlayPanel.alpha1 = 1f;
		}
		rightTable.repositionNow = true;
	}

	private void InitializeEquipLabel()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		equippedLabel.text = text3;
		MiscTools.SetUILabelRescale(equippedLabel, 57f, 20f, 340);
	}

	private void InitializeEquipButton()
	{
		bool isEquipped = selectedIcon.visual.isEquipped;
		equippedLabel.text = ((!isEquipped) ? Localization.Localize("ID_GUI_EQUIP") : Localization.Localize("ID_GUI_EQUIPPED"));
		equippedLabel.color = ((!isEquipped) ? Color.black : Color.white);
		TweenAlphaHider.Begin(equippedButtonOff, 0f, (!isEquipped) ? 1f : 0f);
		equippedButtonOnHighlight.alpha = ((!isEquipped) ? 0f : 1f);
		equippedButtonOnIconInside.alpha = ((!isEquipped) ? 0f : 1f);
		equippedButtonOnIconOutSide.alpha = ((!isEquipped) ? 0f : 0.16f);
		if (!isEquipped)
		{
			TweenAlpha.Begin(equippedButtonOnIconInside.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	private void SetSaleAndPrice()
	{
		int num = selectedIcon.visual.priceWarbucks + selectedIcon.visual.priceGold;
		prizeLabel.text = MiscTools.FormatBigNumber(num);
		prizeTable.repositionNow = true;
		salePart.SetActive(value: false);
		saleTimeCounter.StopCountingTo();
		saleTimeCounter.winStreakTimer = null;
	}

	public void SelectCategory(PlayerVisualsCategoryButton playerVisualsCategoryButton)
	{
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		if (mSelectedCategoryButton != null)
		{
			mSelectedCategoryButton.Highlight(setOn: false);
		}
		mSelectedCategoryButton = playerVisualsCategoryButton;
		mSelectedCategoryButton.Highlight(setOn: true);
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(isSelected: false);
		}
		PlayerVisualCategory category = playerVisualsCategoryButton.category;
		int categ = 0;
		for (int i = 0; i < CamosManager.instance.playerVisualCategories.Count; i++)
		{
			if (category == CamosManager.instance.playerVisualCategories[i])
			{
				categ = i;
			}
		}
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisualForIndex(categ);
		if (playerVisual != null && playerVisual.purchasable == PlayerVisual.Purchasable.StarterAssignment && !StarterAssignmentsManager.instance.isActive && !playerVisual.isBought)
		{
			playerVisual = null;
		}
		int num = 0;
		foreach (PlayerVisual allVisual in category.allVisuals)
		{
			if ((allVisual.purchasable != PlayerVisual.Purchasable.StarterAssignment || StarterAssignmentsManager.instance.isActive || allVisual.isBought) && (allVisual.purchasable != PlayerVisual.Purchasable.Arena || allVisual.isBought || WarArena.instance.isOpened))
			{
				if (playerVisual == null)
				{
					playerVisual = allVisual;
				}
				PlayerVisualIcon playerVisualIcon = null;
				playerVisualIcon = ((num < mAllIcons.Count) ? mAllIcons[num] : AddIcon());
				playerVisualIcon.gameObject.SetActive(value: true);
				playerVisualIcon.Initialize(allVisual);
				if (allVisual == playerVisual)
				{
					Select(playerVisualIcon);
				}
				num++;
			}
		}
		for (int j = num; j < mAllIcons.Count; j++)
		{
			PlayerVisualIcon playerVisualIcon2 = mAllIcons[j];
			playerVisualIcon2.gameObject.SetActive(value: false);
		}
		bottomTable.repositionNow = true;
		playerVisualsCategoryButton.Notification();
	}

	public void UpdateNotificationsInCategories()
	{
		foreach (PlayerVisualsCategoryButton mAllButton in mAllButtons)
		{
			mAllButton.Notification();
		}
	}

	public void UpdateSalesInCategories()
	{
		foreach (PlayerVisualsCategoryButton mAllButton in mAllButtons)
		{
			mAllButton.Sale();
		}
	}

	private PlayerVisualIcon AddIcon()
	{
		PlayerVisualIcon playerVisualIcon = UnityEngine.Object.Instantiate(playerVisualIconPrefab);
		playerVisualIcon.transform.parent = bottomTable.transform;
		playerVisualIcon.transform.localScale = playerVisualIconPrefab.transform.localScale;
		playerVisualIcon.transform.localPosition = default(Vector3);
		mAllIcons.Add(playerVisualIcon);
		return playerVisualIcon;
	}

	private void DisplayModel()
	{
		Singleton<ArmyPreviewCamera>.instance.DisplayPlayer(CamosManager.instance.mainPlayer);
	}

	private void PreviewCameraOnRotate(bool rotating)
	{
	}

	private void HintButtonClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mShowedStats)
		{
			HideHintStats();
		}
		else
		{
			ShowHintStats();
		}
	}

	private void HintBackgroundClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideHintStats();
	}

	private void ShowHintStats()
	{
		if (!hintPanel.gameObject.activeSelf)
		{
			buttonHintSprite.spriteName = MiscTools.closeButtonSprite;
			hintPanel.alpha1 = 0f;
			hintPanel.gameObject.SetActive(value: true);
			mShowedStats = true;
		}
		TweenAlpha.Begin(hintPanel.gameObject, 0.2f, 1f).onFinished = null;
	}

	private void HideHintStats()
	{
		if (hintPanel.gameObject.activeSelf)
		{
			TweenAlpha.Begin(hintPanel.gameObject, 0.2f, 0f).onFinished = delegate
			{
				InstaHideHintStats();
			};
		}
	}

	private void InstaHideHintStats()
	{
		buttonHintSprite.spriteName = MiscTools.infoButtonSprite;
		hintPanel.gameObject.SetActive(value: false);
		mShowedStats = false;
	}

	protected override void Update()
	{
		base.Update();
		mTimer += Time.deltaTime;
		if (!(mTimer > 0.333f))
		{
			return;
		}
		mTimer -= 0.333f;
		CamosManager.instance.CheckEquippedHelmet();
		if (selectedIcon != null && selectedIcon.visual.isFromArena && arenaTimerPart.activeSelf)
		{
			bool isBought = selectedIcon.visual.isBought;
			arenaTimerPart.SetActive(isBought);
			if (isBought)
			{
				arenaTimerHintLabel.text = Localization.LocalizeFormat("ID_ARENAREWARDEXPIRATION", MiscTools.PrintableWholeTimeLongForm((float)selectedIcon.visual.remainingTime, selectedIcon.visual.remainingTime < 3600.0));
			}
		}
	}

	public void BuyPlayerVisual(PlayerVisual visual, int discount)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Name", visual.row.NAME);
		dictionary.Add("Warbucks", visual.priceWarbucks);
		dictionary.Add("Gold", visual.priceGold);
		dictionary.Add("discount", discount);
		dictionary.Add("StartTime", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		string objData = JsonConvert.SerializeObject(dictionary);
		int priceWarbucks = visual.priceWarbucks;
		int priceGold = visual.priceGold;
		requestBuffer.AddRequest(DatabaseAction.BuyDecal, objData, priceWarbucks, priceGold, visual.row.NAME, visual is PlayerVisualCategoryPowerBands.PlayerVisualPowerBand);
		visual.Buy();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Buy);
	}

	public void WasShown(PlayerVisual visual)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.VisualWasShown, visual.row.NAME, 0, 0, string.Empty);
		visual.notificate = false;
		Singleton<NotificationManager>.instance.VisualWasShownFunction();
	}

	public void EquipPlayerVisual(PlayerVisual visual)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.EquipDecal, visual.row.NAME, 0, 0, string.Empty);
		visual.Equip();
	}

	public int AddParts(PlayerVisual visual, int count)
	{
		return visual.AddParts(count);
	}
}
