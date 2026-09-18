using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class MenuHeader : GuiElementSingle<MenuHeader>
{
	[Header("Status")]
	public GameObject status;

	public UISprite rankIcon;

	public UILabel playerName;

	public UILabel levelNumber;

	public UILabel nextlevelNumber;

	public UISprite progressSprite;

	public UISprite progressSpriteWhite;

	public UIButton playerStatsButton;

	[Header("VIP")]
	public GameObject vipPart;

	public UISprite vipSprite;

	public GameObject vipButton;

	public GameObject vipSalePart;

	public UILabel salePercentLabel;

	public WinStreakCounter saleTimeCounter;

	[Header("Warbucks and Gold")]
	public UISprite warbucksIcon;

	public UILabel warBucksLabel;

	public UISprite goldIcon;

	public UILabel goldLabel;

	public UIButton moneyButton;

	public GameObject moneyWaitingObject;

	[Header("Settings")]
	public UIButton settingsButton;

	public UISprite settingsIcon;

	[Header("Anchors")]
	public Transform topAnchor;

	public Transform topLeftAnchor;

	private bool mGameEnded;

	public void SetUpWarbucksGoldWithoutAnimation(long warbucks, long gold)
	{
		warBucksLabel.text = MiscTools.FormatBigNumberLong(warbucks);
		goldLabel.text = MiscTools.FormatBigNumberLong(gold);
	}

	public void AnimateToCurrentValues()
	{
		long warBucks = Singleton<Wallet>.instance.warBucks;
		long gold = Singleton<Wallet>.instance.gold;
		long num = Convert.ToInt64(Regex.Replace(warBucksLabel.text, "[.,']*", string.Empty));
		long num2 = Convert.ToInt64(Regex.Replace(goldLabel.text, "[.,']*", string.Empty));
		InstanceOnGoldChanged(gold, gold - num2);
		InstanceOnWarbucksChanged(warBucks, warBucks - num);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.WarbucksChanged += InstanceOnWarbucksChanged;
		Singleton<Wallet>.instance.GoldChanged += InstanceOnGoldChanged;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += delegate
		{
			InitGUIValues();
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<VipManager>.instance.VipStatusChanged += delegate
		{
			ShowVipIcon();
		};
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		Singleton<OfferManager>.instance.SalesChanged += VipSale;
		GuiElement.ShowingDialog = (Action)Delegate.Combine(GuiElement.ShowingDialog, new Action(OnShowingDialog));
		GuiElement.HidingDialog = (Action<GuiElement>)Delegate.Combine(GuiElement.HidingDialog, new Action<GuiElement>(OnHidingDialog));
	}

	private void InstanceOnWarbucksChanged(long amount, long diff)
	{
		if (isShowed)
		{
			if (diff == 0L)
			{
				TweenTextCounterLong.Begin(warBucksLabel.gameObject, 0f, new LongObject(amount), new LongObject(amount));
			}
			else
			{
				TweenTextCounterLong.Begin(warBucksLabel.gameObject, 2f, new LongObject(amount - diff), new LongObject(amount));
			}
		}
	}

	private void InstanceOnGoldChanged(long amount, long diff)
	{
		if (isShowed)
		{
			if (diff == 0L)
			{
				TweenTextCounterLong.Begin(goldLabel.gameObject, 0f, new LongObject(amount), new LongObject(amount));
			}
			else
			{
				TweenTextCounterLong.Begin(goldLabel.gameObject, 2f, new LongObject(amount - diff), new LongObject(amount));
			}
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			switch (action)
			{
			case DatabaseAction.LoginToCustomAccount:
			case DatabaseAction.AddFacebook:
			case DatabaseAction.SwitchToFacebook:
			case DatabaseAction.ChangePlayerName:
			case DatabaseAction.AddGooglePlay:
			case DatabaseAction.RemoveGooglePlay:
				SetPlayerName(GameLoginManager.currentPlayer.name);
				break;
			case DatabaseAction.RemoveFacebook:
				InitGUIValues();
				break;
			case DatabaseAction.BuyVip:
				ShowVipIcon();
				break;
			}
		}
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		mGameEnded = true;
	}

	private void OnShowingDialog()
	{
		if (vipSalePart.activeSelf)
		{
			TweenAlpha.Begin(vipSalePart, 0.2f, 0f);
		}
	}

	private void OnHidingDialog(GuiElement dialog)
	{
		if (vipSalePart.activeSelf && DialogManager.instance.GetShownDialog() == null)
		{
			TweenAlpha.Begin(vipSalePart, 0.2f, 1f);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(playerStatsButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PlayerStatsButtonClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(vipButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(VipButtonClicked));
		UIEventListener uIEventListener3 = UIEventListener.Get(moneyButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MoneyButtonClicked));
		UIEventListener uIEventListener4 = UIEventListener.Get(settingsButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(SettingsButtonClicked));
	}

	private void PlayerStatsButtonClicked(GameObject go)
	{
		if (!GuiScreenSingle<PlayerStatsScreen>.instance.isShowed && !GuiScreenSingle<CardSelectionScreen>.instance.isShowed && !Singleton<GameController>.instance.isTutorial)
		{
			DialogManager.instance.HideAllDialogs();
			TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, 0.2f, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.isShowed;
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<PlayerStatsScreen>.instance);
			if (flag)
			{
				GuiScreenSingle<PlayerStatsScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			}
		}
	}

	private void VipButtonClicked(GameObject go)
	{
		if (!GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	private void MoneyButtonClicked(GameObject go)
	{
		if (!GuiElementSingle<InappScreen>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<InappScreen>.instance.routeToStore = "Direct";
			GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
		}
	}

	private void SettingsButtonClicked(GameObject go)
	{
		if (!GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			TweenRotationSpecial.Begin(settingsIcon.gameObject, 1f, Vector3.forward, 0f, 360f);
			GuiElementSingle<SettingsDialog>.instance.ShowGeneral();
		}
	}

	public override void InitGUIValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			SetPlayerName(GameLoginManager.currentPlayer.name);
			if (!mGameEnded)
			{
				UpdateLevel();
			}
			if (!mGameEnded)
			{
				UpdateProgress();
			}
			InitializeVIP();
			if (!mGameEnded)
			{
				InstanceOnWarbucksChanged(Singleton<Wallet>.instance.warBucks, 0L);
			}
			if (!mGameEnded)
			{
				InstanceOnGoldChanged(Singleton<Wallet>.instance.gold, 0L);
			}
			TweenRotationSpecial component = settingsIcon.gameObject.GetComponent<TweenRotationSpecial>();
			if (component != null)
			{
				component.enabled = false;
			}
			settingsIcon.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			if (Singleton<GameController>.instance.isTutorial)
			{
				HideAllmostEverything();
			}
			else
			{
				ShowEverything();
			}
			mGameEnded = false;
		}
	}

	private void SetPlayerName(string newName)
	{
		playerName.text = newName;
		MiscTools.SetUILabelRescale(playerName, 30f, 20f);
		playerName.color = Color.white;
		TweenColor component = playerName.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void UpdateProgress()
	{
		float progress = LevelManager.instance.GetProgress();
		progressSprite.fillAmount = progress;
		progressSpriteWhite.fillAmount = progress;
	}

	public void UpdateLevel()
	{
		LevelManager.GameLevel gameLevel = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.currentLevel : LevelManager.instance.previousLevel);
		levelNumber.text = gameLevel.displayString;
		rankIcon.spriteName = gameLevel.iconName;
		if (gameLevel.displayNumber == LevelManager.instance.maxDisplayLevel)
		{
			nextlevelNumber.text = Localization.Localize("ID_MAX");
			nextlevelNumber.color = Colours.blue;
			nextlevelNumber.transform.localScale = new Vector3(20f, 20f, 1f);
		}
		else
		{
			LevelManager.GameLevel gameLevel2 = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.nextLevel : LevelManager.instance.currentLevel);
			nextlevelNumber.text = gameLevel2.displayString;
			nextlevelNumber.color = Colours.grayMax;
			nextlevelNumber.transform.localScale = new Vector3(25f, 25f, 1f);
		}
	}

	private void InitializeVIP()
	{
		ShowVipIcon();
		VipSale();
	}

	private void ShowVipIcon()
	{
		vipSprite.spriteName = ((!Singleton<VipManager>.instance.IsVipActive()) ? "menu-top-vip-not" : "menu-top-vip");
	}

	private void VipSale()
	{
		if (!isShowed)
		{
			return;
		}
		int num = Singleton<OfferManager>.instance.DiscountedVIP();
		bool flag = num > 0;
		vipSalePart.SetActive(flag);
		if (flag)
		{
			salePercentLabel.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			saleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedVIPEndtime(), upperCaseCountdown: true);
			saleTimeCounter.winStreakTimer = delegate
			{
				vipSalePart.SetActive(value: false);
			};
		}
		else
		{
			saleTimeCounter.StopCountingTo();
			saleTimeCounter.winStreakTimer = null;
		}
	}

	private void ShowEverything()
	{
		vipPart.transform.localPosition = vipPart.transform.localPosition.ReplaceY(-61f);
		vipSprite.transform.parent.gameObject.SetActive(value: true);
		moneyButton.gameObject.SetActive(value: true);
		moneyButton.isEnabled = true;
		settingsButton.gameObject.SetActive(value: true);
	}

	private void HideAllmostEverything()
	{
		vipPart.transform.localPosition = vipPart.transform.localPosition.ReplaceY(100f);
		vipSprite.transform.parent.gameObject.SetActive(value: false);
		moneyButton.gameObject.SetActive(value: true);
		moneyButton.isEnabled = false;
		settingsButton.gameObject.SetActive(value: false);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		saleTimeCounter.StopCountingTo();
		saleTimeCounter.winStreakTimer = null;
	}
}
