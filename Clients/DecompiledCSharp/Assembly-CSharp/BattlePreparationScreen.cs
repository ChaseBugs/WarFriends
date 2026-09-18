using System;
using System.Collections.Generic;
using UnityEngine;

public class BattlePreparationScreen : GuiScreenSingle<BattlePreparationScreen>
{
	[Header("Top Right")]
	public GameObject backButton;

	[Header("Top Right")]
	public MapSelectionContent mapSelection;

	[Header("Middle")]
	public UIGrid bigButtonsGrid;

	public List<UIButtonSetter> centerButtonSetters;

	public BattlePreparationUnitButton armyButton;

	public BattlePreparationWeaponButton weaponButton;

	public BattlePreparationWarCardsButton warCardsButton;

	public BattlePreparationCustomizationButton customizationButton;

	[Header("Bottom")]
	public GameModesContent gameModeContent;

	public InstantBattleButton instantBattleButton;

	public PlayerVsPlayerButton playerVsPlayerButton;

	[Header("- Arena Shortcut")]
	public GameObject arenaShortcut;

	public UISprite arenaShortcutBackground;

	public GameObject arenaShortcutLockedPart;

	public UILabel arenaShortcutLockedLabel;

	public GameObject arenaShortcutOpenedPart;

	public UILabel arenaShortcutTimeLabel;

	[Header("- Small PvP")]
	public GameObject playerVsPlayerButtonSmall;

	public UIButtonSetter playerVsPlayerSmallSetter;

	public UILabel playerVsPlayerTopLabel;

	public UILabel playerVsPlayerBottomLabel;

	private bool mArenaTimerRunning;

	private float mTimer;

	private bool mShowGameModes;

	private int mWidthOfButtonCache = -1;

	public int widthOfMiddleButton
	{
		get
		{
			if (mWidthOfButtonCache > 0)
			{
				return mWidthOfButtonCache;
			}
			float num = 1.3333334f;
			float num2 = 1.7777778f;
			float num3 = Mathf.Clamp(UIRoot.list[0].activeWidth / (float)UIRoot.list[0].activeHeight, num, num2);
			float num4 = (num3 - num2) / (num - num2);
			mWidthOfButtonCache = Mathf.FloorToInt(658f + num4 * -230f);
			return mWidthOfButtonCache;
		}
	}

	public void OpenScreenWithGameModesOpen()
	{
		mShowGameModes = true;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public override void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		Singleton<OfferManager>.instance.SalesChanged += OnSalesChanged;
		WarArena.instance.WarArenaExpired += OnWarArenaExpired;
		playerVsPlayerButton.InitEvents();
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
		Singleton<ArmyPreviewCamera>.instance.PlayerDataLoaded();
		RenderMainPlayer();
	}

	private void OnSalesChanged()
	{
		if (isShowed)
		{
			Sales();
		}
	}

	private void OnWarArenaExpired()
	{
		if (isShowed)
		{
			InitializeBottomShortcut();
		}
	}

	protected override void InitControls()
	{
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += OnRewardVideoChanged;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += OnRewardVideoChanged;
		WarArena.instance.WarArenaDataChanged += InitializeBottomShortcut;
		UIButtonSetter uIButtonSetter = playerVsPlayerSmallSetter;
		uIButtonSetter.Rescaled = (Action)Delegate.Combine(uIButtonSetter.Rescaled, new Action(SmallPvPButtonReposition));
		UIEventListener uIEventListener = UIEventListener.Get(arenaShortcut);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OpenArenaClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerVsPlayerButtonSmall);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(playerVsPlayerButton.PvPClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(backButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BackButtonClick));
		mapSelection.InitControls();
		armyButton.InitControls();
		weaponButton.InitControls();
		warCardsButton.InitControls();
		customizationButton.InitControls();
		gameModeContent.InitControls();
		instantBattleButton.InitControls();
		playerVsPlayerButton.InitControls();
		SetUpCenterButtonsAccordingToWidth();
	}

	public void OnRewardVideoChanged()
	{
		if (isShowed)
		{
			warCardsButton.SetUpFreeWarcard();
		}
	}

	private void SetUpCenterButtonsAccordingToWidth()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = (activeWidth - 228f) / 4f;
		foreach (UIButtonSetter centerButtonSetter in centerButtonSetters)
		{
			centerButtonSetter.SetWidth(num);
		}
		float val = 0f - activeWidth / 2f + 60f + num / 2f;
		bigButtonsGrid.transform.localPosition = bigButtonsGrid.transform.localPosition.ReplaceX(val);
		bigButtonsGrid.cellWidth = num + 36f;
	}

	private void SmallPvPButtonReposition()
	{
		LocalizeSmallPvPButton();
	}

	private void ArenaButtonReposition()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = activeWidth / 1920f;
		float num2 = (activeWidth - (940f + 420f * num + 440f * num + 60f)) / 3f;
		float num3 = (activeWidth - (940f + 876f * num + 60f)) / 2f;
		float num4 = ((LevelManager.instance.isWarArenaLocked || (!WarArena.instance.isReminderTime && !WarArena.instance.isOpened)) ? num3 : num2);
		arenaShortcut.transform.localPosition = arenaShortcut.transform.localPosition.ReplaceX(500f + num4 + 440f + num4 + 210f * num);
	}

	private void OpenArenaClick(GameObject go)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.ShowDialog();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(WarArena.instance.isArenaTicketBought ? ArenaScreen.ArenaScreenMode.MainArena : ArenaScreen.ArenaScreenMode.EnterArena);
		}
	}

	private void BackButtonClick(GameObject go)
	{
		if (gameModeContent.shownModes)
		{
			if (!gameModeContent.isAnimating)
			{
				gameModeContent.CloseModeSelection(go);
			}
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui((!(base.previousScreen != null)) ? GuiScreenSingle<MainScreen>.instance : base.previousScreen);
		}
	}

	public override void InitGUIValues()
	{
		base.previousScreen = GuiScreenSingle<MainScreen>.instance;
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			InitBlank();
			return;
		}
		RenderMainPlayer();
		mapSelection.InitGuiValues();
		armyButton.InitGUIValues();
		weaponButton.InitGUIValues();
		warCardsButton.InitGUIValues();
		customizationButton.InitGUIValues();
		InitializeBottomShortcut();
		gameModeContent.InitGuiValues(mShowGameModes);
		mShowGameModes = false;
		bool isInstantBattleEnabled = Singleton<GameVariables>.instance.isInstantBattleEnabled;
		instantBattleButton.gameObject.SetActive(isInstantBattleEnabled);
		if (isInstantBattleEnabled)
		{
			instantBattleButton.InitGuiValues();
		}
		Sales();
		if (!Singleton<GameController>.instance.isTutorial)
		{
			ReminderManager.instance.ShowDailyAssignmentsReminder();
		}
	}

	private void InitializeBottomShortcut()
	{
		bool showWarArenaPromoLocked = LevelManager.instance.showWarArenaPromoLocked;
		bool flag = !LevelManager.instance.isWarArenaLocked && (WarArena.instance.isReminderTime || WarArena.instance.isOpened);
		bool flag2 = showWarArenaPromoLocked || flag;
		InitializeArenaShortcut(showWarArenaPromoLocked, flag);
		playerVsPlayerButtonSmall.SetActive(flag2);
		playerVsPlayerButton.gameObject.SetActive(!flag2);
		if (!flag2)
		{
			playerVsPlayerButton.InitGUIValues();
		}
		ArenaButtonReposition();
		instantBattleButton.InstantBattleButtonReposition();
	}

	private void InitializeArenaShortcut(bool showArenaLocked, bool showArenaTimer)
	{
		mArenaTimerRunning = showArenaTimer;
		arenaShortcut.SetActive(showArenaLocked || showArenaTimer);
		arenaShortcutBackground.color = ((!showArenaLocked) ? Color.white : Colours.grayButton);
		arenaShortcutLockedPart.SetActive(showArenaLocked);
		arenaShortcutOpenedPart.SetActive(!showArenaLocked);
		if (showArenaLocked)
		{
			arenaShortcutLockedLabel.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANKX", MiscTools.FormatBigNumber(LevelManager.instance.warArenaUnlockLevel));
			MiscTools.SetUILabelRescale(arenaShortcutLockedLabel, 30f, 20f);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		armyButton.DoAfterHide();
		weaponButton.DoAfterHide();
		warCardsButton.DoAfterHide();
		customizationButton.DoAfterHide();
		gameModeContent.DoAfterHide();
	}

	private void Sales()
	{
		armyButton.SaleUnits();
		weaponButton.SaleWeapons();
		warCardsButton.SaleCardPacks();
	}

	private void InitBlank()
	{
		armyButton.InitBlank();
		weaponButton.InitBlank();
		warCardsButton.InitBlank();
		customizationButton.InitBlank();
		playerVsPlayerButton.InitBlank();
	}

	public void SetUpDeliveringLabel(int remainingTime, ref UILabel deliveringLabel, bool instant)
	{
		switch (remainingTime % 6)
		{
		case 5:
			deliveringLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
			TweenAlpha.Begin(deliveringLabel.gameObject, (!instant) ? 1f : 0.01f, 0f);
			break;
		case 4:
			deliveringLabel.text = Localization.Localize("ID_GUI_DELIVERING");
			TweenAlpha.Begin(deliveringLabel.gameObject, (!instant) ? 1f : 0.01f, 1f);
			break;
		case 3:
			deliveringLabel.text = Localization.Localize("ID_GUI_DELIVERING");
			break;
		case 2:
			deliveringLabel.text = Localization.Localize("ID_GUI_DELIVERING");
			TweenAlpha.Begin(deliveringLabel.gameObject, (!instant) ? 1f : 0.01f, 0f);
			break;
		case 1:
			deliveringLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
			TweenAlpha.Begin(deliveringLabel.gameObject, (!instant) ? 1f : 0.01f, 1f);
			break;
		case 0:
			deliveringLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
			break;
		}
	}

	public void TestUnitPosition()
	{
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
		{
			if (!(armyButton.unitIcon.spriteName != LevelManager.instance.behaviours[i].upgradeSlots.iconName))
			{
				int index = ((i + 1 != LevelManager.instance.behaviours.Count) ? (i + 1) : 0);
				armyButton.SetUpUnitLook(LevelManager.instance.behaviours[index]);
				break;
			}
		}
	}

	public void TestWeaponLook()
	{
		for (int i = 0; i < LevelManager.instance.weaponLevelsSetups.Count; i++)
		{
			if (!(weaponButton.weaponIcon.spriteName != LevelManager.instance.weaponLevelsSetups[i].playerWeapon.iconName))
			{
				int index = ((i + 1 != LevelManager.instance.weaponLevelsSetups.Count) ? (i + 1) : 0);
				weaponButton.SetUpWeaponLook(LevelManager.instance.weaponLevelsSetups[index].playerWeapon.iconName);
				break;
			}
		}
	}

	private void RenderMainPlayer()
	{
		customizationButton.RenderMainPlayer();
	}

	protected override void Update()
	{
		base.Update();
		if (mArenaTimerRunning)
		{
			mTimer += Time.deltaTime;
			if (mTimer >= 0.333f)
			{
				mTimer -= 0.333f;
				UpdateArenaText();
			}
		}
	}

	private void UpdateArenaText()
	{
		arenaShortcutTimeLabel.text = WarArenaGui.CreateArenaTimeTextWithColour(Colours.stringBlack);
		MiscTools.SetUILabelRescale(arenaShortcutTimeLabel, 30f, 20f);
		if (WarArena.instance.isExpired)
		{
			WarArena.instance.TryGetNewArena();
		}
	}

	private void LocalizeSmallPvPButton()
	{
		playerVsPlayerTopLabel.text = Localization.Localize("ID_PVP_RANKED");
		playerVsPlayerBottomLabel.text = Localization.Localize("ID_PVP_BATTLE");
		float x = playerVsPlayerTopLabel.relativeSize.x;
		float x2 = playerVsPlayerBottomLabel.relativeSize.x;
		float num = Math.Max(x, x2);
		int num2 = playerVsPlayerSmallSetter.width - 200;
		float defaultHeight = Mathf.Min(50f, (float)num2 / num);
		MiscTools.SetUILabelRescale(playerVsPlayerTopLabel, defaultHeight, 20f);
		MiscTools.SetUILabelRescale(playerVsPlayerBottomLabel, defaultHeight, 20f);
	}
}
