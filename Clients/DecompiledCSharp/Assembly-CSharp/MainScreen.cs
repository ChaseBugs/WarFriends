using System;
using UnityEngine;

public class MainScreen : GuiScreenSingle<MainScreen>
{
	[Header("Left")]
	public LeftGoldenSuitcase goldenSuitcaseLeft;

	public GameObject dailyRewardButton;

	public GameObject dailyRewardBadge;

	public IntroductionDeals dealsOnRight;

	[Header("Top")]
	public MainScreenAssignments assignments;

	[Header("Right")]
	public MainScreenSocial social;

	public GameObject gpgsButton;

	public UILabel gpgsLabel;

	[Header("Bottom Left")]
	public IntroductionSquadButton squadButton;

	[Header("Bottom")]
	public MainScreenLeaguePlayers bottomLeaguePlayers;

	[Header("Bottom Right")]
	public UIButton nextButton;

	public GameObject notificationObject;

	public UILabel notificationText;

	public GameObject positionForTutorialText;

	public GameObject positionForTutorialHand;

	private bool mShowAchievementsAfterGPGSLogin;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		goldenSuitcaseLeft.InitEvents();
		dealsOnRight.InitEvents();
		social.InitEvents();
		squadButton.InitEvents();
		bottomLeaguePlayers.InitEvents();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!isShowed)
		{
			return;
		}
		switch (action)
		{
		case DatabaseAction.CheckDailyReward:
		case DatabaseAction.ClaimDailyReward:
			if (StatsManager.instance.dailyRewardData != null)
			{
				UpdateDailyrewadButton();
			}
			break;
		case DatabaseAction.LoginToCustomAccount:
		case DatabaseAction.AddFacebook:
		case DatabaseAction.CreateGcAccount:
		case DatabaseAction.RemoveFacebook:
		case DatabaseAction.AddGooglePlay:
		case DatabaseAction.RemoveGooglePlay:
			UpdateDailyrewadButton();
			GPGSLook();
			break;
		}
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	protected override void InitControls()
	{
		goldenSuitcaseLeft.InitControls();
		dealsOnRight.InitControls();
		assignments.InitControls();
		social.InitControls();
		squadButton.InitControls();
		bottomLeaguePlayers.InitControls();
		UIEventListener uIEventListener = UIEventListener.Get(nextButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NextButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(dailyRewardButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DailyRewardButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(gpgsButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.isLoggedIn)
			{
				Singleton<GooglePlayGameService>.instance.ShowAchievementsUI();
			}
			else if (GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected)
			{
				mShowAchievementsAfterGPGSLogin = true;
				GameLoginManager.instance.LoginToGoogle();
			}
			else
			{
				GameLoginManager.instance.LoginToGoogle();
			}
		});
		Singleton<GooglePlayGameService>.instance.LoggedIn += OnGooglePlayGameServiceLoggedIn;
		Singleton<GooglePlayGameService>.instance.LoggedInFromInit += delegate
		{
			GPGSLook();
		};
		Singleton<GooglePlayGameService>.instance.LoggedOut += delegate
		{
			GPGSLook();
		};
		Singleton<NotificationManager>.instance.UnitDelivered += UpdateNextNotifications;
		Singleton<NotificationManager>.instance.WeaponDelivered += UpdateNextNotifications;
	}

	private void NextButtonClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void DailyRewardButtonClick(GameObject go)
	{
		GuiScreenSingle<DailyRewardMonthScreen>.instance.showedFromDialog = false;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyRewardMonthScreen>.instance);
	}

	private void UpdateNextNotifications()
	{
		if (isShowed)
		{
			NextNotifications();
		}
	}

	private void NextNotifications()
	{
		int numberOfMenuNotifications = Singleton<NotificationManager>.instance.GetNumberOfMenuNotifications();
		notificationText.text = MiscTools.FormatBigNumber(numberOfMenuNotifications);
		notificationObject.SetActive(numberOfMenuNotifications > 0);
	}

	public override void InitGUIValues()
	{
		goldenSuitcaseLeft.InitGuiValues();
		UpdateDailyrewadButton();
		dealsOnRight.InitGuiValues();
		assignments.InitGuiValues();
		social.InitGUIValues();
		GPGSLook();
		squadButton.InitGuiValues();
		bottomLeaguePlayers.InitGuiValues();
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			NextNotifications();
		}
		mShowAchievementsAfterGPGSLogin = false;
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		bottomLeaguePlayers.AnimateShow();
		dealsOnRight.AnimateShow();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		dealsOnRight.DoBeforeHide();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		bottomLeaguePlayers.DoAfterHide();
		goldenSuitcaseLeft.DoAfterHide();
		squadButton.DoAfterHide();
	}

	private void UpdateDailyrewadButton()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			dailyRewardButton.SetActive(value: false);
		}
		else if (LevelManager.instance.isDailyRewardsLocked)
		{
			dailyRewardButton.SetActive(value: false);
		}
		else if (StatsManager.instance.dailyRewardData == null)
		{
			dailyRewardButton.SetActive(value: false);
			Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
		}
		else
		{
			dailyRewardButton.SetActive(value: true);
			dailyRewardBadge.SetActive(StatsManager.instance.dailyRewardData.canClaim);
		}
	}

	private void GPGSLook()
	{
		bool isGooglePlayConnected = GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected;
		gpgsLabel.text = Localization.Localize((!isGooglePlayConnected) ? "ID_CONNECTTOGOOGLEPLAY" : "ID_GOOGLEPLAYACHIEVEMENTS");
	}

	public override void OnBack()
	{
		ConfirmDialog.ShowChoice(Localization.Localize("ID_CONFIRM_EXIT"), Localization.Localize("ID_CONFIRM_EXITWARFRIENDS"), delegate(ConfirmDialog dialog, bool result)
		{
			if (result)
			{
				Application.Quit();
			}
		}, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
	}

	public void OnApplicationFocus()
	{
		GPGSLook();
	}

	public void OnGooglePlayGameServiceLoggedIn(bool success)
	{
		GPGSLook();
		if (mShowAchievementsAfterGPGSLogin)
		{
			mShowAchievementsAfterGPGSLogin = false;
			if (success)
			{
				Singleton<GooglePlayGameService>.instance.ShowAchievementsUI();
			}
		}
	}
}
