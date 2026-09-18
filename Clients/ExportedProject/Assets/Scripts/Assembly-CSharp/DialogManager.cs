using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;

[Skip]
public class DialogManager : InGameSerializedObjectGeneric<DialogManager.DialogData>
{
	[Skip]
	public class DialogData
	{
		public int rateAppDialogTimestamp;

		public bool rateAppSuccess;

		public int pushNotificationDialogTimestamp;

		public int pushNotificationShownCounter;

		public bool pushNotificationEnableSuccess;

		public int weaponUpgradeReminderTimestamp;

		public int unitUpgradeReminderTimestamp;

		public int powerBandBuyReminderTimestamp;

		public int firstPlayedTimestamp;

		public int facebookLoginCounter;

		public bool nameWasChanged;

		public int numberOfGamesAfterFbLogin;

		public bool shownNameChangeReminder;

		public int joinOrCreateSquadReminderTimestamp;

		public int purchaseVipReminderTimestamp;

		public bool unitCategoriesShown;
	}

	private const int oneDay = 86400;

	private IGuiDialog[] mDialogs;

	private static DialogManager mInstance;

	private string mDebugMessage;

	public static DialogManager instance
	{
		get
		{
			mInstance = mInstance ?? ((DialogManager)Object.FindObjectsOfType(typeof(DialogManager))[0]);
			return mInstance;
		}
	}

	public bool isSomeDialogShowed => numberOfShownDialogues > 0;

	public int numberOfShownDialogues
	{
		get
		{
			int num = 0;
			IGuiDialog[] array = mDialogs;
			foreach (IGuiDialog guiDialog in array)
			{
				if (guiDialog.GetGuiElement().gameObject.activeSelf)
				{
					num++;
				}
			}
			return num;
		}
	}

	protected DialogManager()
	{
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		GameLoginManager.instance.PlayerLogOut += OnLogout;
		mDialogs = Singleton<GuiManager>.instance.root.gameObject.GetComponentsInChildren<IGuiDialog>(includeInactive: true);
		mInstance = this;
	}

	public GuiElement GetShownDialog()
	{
		for (int i = 0; i < mDialogs.Length; i++)
		{
			IGuiDialog guiDialog = mDialogs[i];
			if (guiDialog.GetGuiElement().isShowed)
			{
				return guiDialog.GetGuiElement();
			}
		}
		return null;
	}

	private void OnLogout()
	{
		HideAllDialogs();
	}

	internal void HideAllDialogs()
	{
		Debug.Log("Hide All Dialogs called");
		for (int i = 0; i < mDialogs.Length; i++)
		{
			GuiElement guiElement = mDialogs[i].GetGuiElement();
			if (guiElement.isShowed)
			{
				Debug.Log("Hidding " + guiElement.gameObject.name);
				Singleton<GuiManager>.instance.FadeOut(guiElement);
			}
		}
	}

	public void CheckEveryTimeAfterGameEnd()
	{
		bool flag = false;
		if (data.firstPlayedTimestamp == 0)
		{
			data.firstPlayedTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			flag = true;
			AddDebugMessage("Saving first played timestamp");
		}
		if (GameLoginManager.currentPlayer.isFacebookConnected && PlayerAnalytics.instance.data.renameCount == 0 && !data.shownNameChangeReminder)
		{
			data.numberOfGamesAfterFbLogin++;
			flag = true;
			AddDebugMessage("Increasing number of games after facebook login");
		}
		if (flag)
		{
			Save();
		}
	}

	public void ShowClientSideNotifications()
	{
		if ((!Singleton<GameController>.instance.wonLastGame || !ShowPushNotificationDialog()) && !ShowWeaponUpgradeReminder() && !ShowUnitUpgradeReminder() && !ShowLoginToFacebook() && !ShowNameChangeReminder() && !ShowJoinOrCreateSquadReminder() && !ShowPurchaseVipReminder() && !ShowUnitCategories())
		{
		}
	}

	public bool ShowEnablePushNotificationsDialog(float waitTime)
	{
		if (!data.pushNotificationEnableSuccess)
		{
			data.pushNotificationShownCounter++;
			Save();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsDialog>.instance, waitTime);
			return true;
		}
		return false;
	}

	public bool ShowPushNotificationDialog()
	{
		string text = $"1 PUSH REMINDER\tLast game won: True\tPush notifications allowed: {PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice()}";
		if (!PushNotificationManager.instance.hasValidDeviceToken() && !PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
		{
			text += $"\tTotal wins: {StatsManager.instance.totalWins}/{ReminderManager.instance.notificationAllowWinsNeed}";
			if (StatsManager.instance.totalWins >= ReminderManager.instance.notificationAllowWinsNeed)
			{
				int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				int num = currentTimestamp - data.pushNotificationDialogTimestamp;
				text += string.Format("\tTime since last show: {0}", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
				if (num >= ReminderManager.instance.notificationAllowTimeBetween)
				{
					text += $"\tPush notification shown counter: {data.pushNotificationShownCounter}/{ReminderManager.instance.notificationAllowMaxShow}";
					if (data.pushNotificationShownCounter < ReminderManager.instance.notificationAllowMaxShow)
					{
						Singleton<MessageManager>.instance.AddMessage(new EnablePushNotificationMessage());
						data.pushNotificationDialogTimestamp = currentTimestamp;
						data.pushNotificationShownCounter++;
						Save();
						AddDebugMessage(text + "\t\"TRUE\"");
						return true;
					}
					Debug.Log("Dialog Manager: PN dialog shown too many times");
					AddDebugMessage(text + "\t\"FALSE\"");
					return false;
				}
				Debug.Log("Dialog Manager: PN dialog shown recently");
				AddDebugMessage(text + "\t\"FALSE\"");
				return false;
			}
			Debug.Log("Dialog Manager: PN dialog too low wins");
			AddDebugMessage(text + "\t\"FALSE\"");
			return false;
		}
		Debug.Log("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = " + GameLoginManager.currentPlayer.deviceToken);
		PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public void PushNotificationWasEnabled()
	{
		data.pushNotificationEnableSuccess = true;
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowReward).DBKEY;
		Singleton<BeanstalkServerManager>.instance.AddOneTimeReward(dBKEY);
		Save();
	}

	public bool ShowRateAppDialog(bool showAfterBattle = true)
	{
		if (Singleton<MessageManager>.instance.IsRateAppInQueue())
		{
			Debug.Log("RATE APP REMINDER -> is already in queue for showing, not adding next one.");
			return false;
		}
		int rateAppShownCounter = PlayerAnalytics.instance.data.rateAppShownCounter;
		bool flag = false;
		if (string.IsNullOrEmpty(PlayerAnalytics.instance.data.rateAppClientVersion))
		{
			PlayerAnalytics.instance.data.rateAppClientVersion = Singleton<CurrentBundleVersion>.instance.version;
			flag = true;
		}
		if (string.IsNullOrEmpty(PlayerAnalytics.instance.data.rateAppFirstVersion))
		{
			PlayerAnalytics.instance.data.rateAppFirstVersion = Singleton<CurrentBundleVersion>.instance.version;
			flag = true;
		}
		if (data.rateAppSuccess && PlayerAnalytics.instance.data.rateAppClickYesCounter == 0)
		{
			PlayerAnalytics.instance.data.rateAppClickYesCounter++;
			flag = true;
		}
		string rateAppClientVersion = PlayerAnalytics.instance.data.rateAppClientVersion;
		int battlesWonRanked = StatsManager.instance.data.battlesWonRanked;
		bool flag2 = data.rateAppSuccess || PlayerAnalytics.instance.data.rateAppClientVersion != PlayerAnalytics.instance.data.rateAppFirstVersion;
		string text = $"2 RATE APP REMINDER\tLast game won: True\tVersion: {rateAppClientVersion}\tShown Times in this version: {rateAppShownCounter}/{ReminderManager.instance.rateAppMaxShow}\tTotal ranked wins: {battlesWonRanked}?={ReminderManager.instance.rateAppShowAfterBattles}\tIs level up: {LevelManager.instance.isLevelUp}\tLevel: {LevelManager.instance.currentLevel.displayNumber}?={ReminderManager.instance.rateAppShowAfterLevel}/{ReminderManager.instance.rateAppShowSecondTimeAfterLevel}\tAfter update: {flag2}";
		if (showAfterBattle)
		{
			if (rateAppClientVersion != Singleton<CurrentBundleVersion>.instance.version)
			{
				Singleton<MessageManager>.instance.AddMessage(new RateAppMessage(Singleton<CurrentBundleVersion>.instance.version, 0, flag2));
				PlayerAnalytics.instance.data.rateAppShownCounter = 1;
				PlayerAnalytics.instance.data.rateAppClientVersion = Singleton<CurrentBundleVersion>.instance.version;
				Save();
				Singleton<BeanstalkServerManager>.instance.UpdateAnalytics();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
			if (rateAppShownCounter < ReminderManager.instance.rateAppMaxShow && ((ReminderManager.instance.rateAppShowAfterBattles == battlesWonRanked && Singleton<GameController>.instance.wonLastGame) || (LevelManager.instance.isLevelUp && LevelManager.instance.currentLevel.displayNumber == ReminderManager.instance.rateAppShowAfterLevel) || (LevelManager.instance.isLevelUp && LevelManager.instance.currentLevel.displayNumber == ReminderManager.instance.rateAppShowSecondTimeAfterLevel)))
			{
				Singleton<MessageManager>.instance.AddMessage(new RateAppMessage(rateAppClientVersion, rateAppShownCounter, flag2));
				PlayerAnalytics.instance.data.rateAppShownCounter++;
				Save();
				Singleton<BeanstalkServerManager>.instance.UpdateAnalytics();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
			if (flag)
			{
				Save();
				Singleton<BeanstalkServerManager>.instance.UpdateAnalytics();
			}
			AddDebugMessage(text + "\t\"FALSE\"");
			return false;
		}
		text = $"RATE APP REMINDER\tVersion: {rateAppClientVersion}\tShown Times in this version: {rateAppShownCounter}/{ReminderManager.instance.rateAppMaxShow}";
		if (rateAppShownCounter < ReminderManager.instance.rateAppMaxShow)
		{
			Singleton<MessageManager>.instance.AddMessage(new RateAppMessage(rateAppClientVersion, rateAppShownCounter, flag2));
			PlayerAnalytics.instance.data.rateAppShownCounter++;
			Save();
			Singleton<BeanstalkServerManager>.instance.UpdateAnalytics();
			Debug.Log(text + "\t\"TRUE\"");
			return true;
		}
		if (flag)
		{
			Save();
			Singleton<BeanstalkServerManager>.instance.UpdateAnalytics();
		}
		Debug.Log(text + "\t\"FALSE\"");
		return false;
	}

	public void GameWasRated()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppReward).FLOATVALUE;
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppReward).DBKEY;
		if (num > 0)
		{
			Singleton<BeanstalkServerManager>.instance.AddOneTimeReward(dBKEY);
		}
		data.rateAppSuccess = true;
		Save();
		PlayerAnalytics.instance.data.rateAppShownCounter = ReminderManager.instance.rateAppMaxShow;
		PlayerAnalytics.instance.data.rateAppClickYesCounter++;
		Singleton<BeanstalkServerManager>.instance.UpdateAnalytics();
	}

	public void NoMoreRateAppInThisVersion()
	{
		PlayerAnalytics.instance.data.rateAppShownCounter = ReminderManager.instance.rateAppMaxShow;
		Save();
		Singleton<BeanstalkServerManager>.instance.UpdateAnalytics();
		Debug.Log("RATE APP - counter set to max: " + PlayerAnalytics.instance.data.rateAppShownCounter);
	}

	public bool ShowLoginToFacebook()
	{
		string text = $"6 LOGIN FB REMINDER\tConnected to fb: {GameLoginManager.currentPlayer.isFacebookConnected}";
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			int num = Singleton<BeanstalkServerManager>.instance.currentTimestamp - data.firstPlayedTimestamp;
			text += string.Format("\tTime since last show: {0}\tFb login counter: {1}/3", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty), data.facebookLoginCounter);
			if ((data.facebookLoginCounter == 0 && num > ReminderManager.instance.facebookRemindDialogShow1After) || (data.facebookLoginCounter == 1 && num > ReminderManager.instance.facebookRemindDialogShow2After) || (data.facebookLoginCounter == 2 && num > ReminderManager.instance.facebookRemindDialogShow3After))
			{
				Singleton<MessageManager>.instance.AddMessage(new BeAdvisedConnectFacebook());
				data.facebookLoginCounter++;
				Save();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
		}
		else
		{
			data.facebookLoginCounter = 3;
			Save();
		}
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public bool ShowNameChangeReminder()
	{
		string text = $"7 NAME CHANGE REMINDER\tConnected to fb: {GameLoginManager.currentPlayer.isFacebookConnected}\tNumber or renames: {PlayerAnalytics.instance.data.renameCount}\tShown name changed reminder: {data.shownNameChangeReminder}";
		if (GameLoginManager.currentPlayer.isFacebookConnected && PlayerAnalytics.instance.data.renameCount == 0 && !data.shownNameChangeReminder)
		{
			text += $"\tNumber of games after fb login: {data.numberOfGamesAfterFbLogin}/{ReminderManager.instance.nameChangeReminderGamesAfterFbLogin}";
			if (data.numberOfGamesAfterFbLogin >= ReminderManager.instance.nameChangeReminderGamesAfterFbLogin)
			{
				Singleton<MessageManager>.instance.AddMessage(new NameChangeReminder());
				data.shownNameChangeReminder = true;
				Save();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
		}
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public bool ShowWeaponUpgradeReminder()
	{
		string text = "3 WEAPON UPGRADE REMINDER\t" + ReminderManager.instance.debugWeaponUpgradeConditions;
		if (ReminderManager.instance.canShowWeaponUpgradeReminder)
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = currentTimestamp - data.weaponUpgradeReminderTimestamp;
			text += string.Format("\tTime since last show: {0}", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
			if (num >= ReminderManager.instance.weaponReminderBetweenTime)
			{
				Singleton<MessageManager>.instance.AddMessage(new UpgradeWeaponReminder(ReminderManager.instance.weaponForUpgrade));
				data.weaponUpgradeReminderTimestamp = currentTimestamp;
				Save();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
		}
		Debug.Log("DialogManager: Weapon upgrade reminder condition not passed");
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public bool ShowUnitUpgradeReminder()
	{
		string text = "4 UNIT UPGRADE REMINDER\t" + ReminderManager.instance.debugUnitUpgradeConditions;
		if (ReminderManager.instance.canShowUnitUpgradeReminder)
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = currentTimestamp - data.unitUpgradeReminderTimestamp;
			text += string.Format("\tTime since last show: {0}", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
			if (num >= ReminderManager.instance.unitReminderBetweenTime)
			{
				Singleton<MessageManager>.instance.AddMessage(new UpgradeUnitReminder(ReminderManager.instance.unitForUpgrade));
				data.unitUpgradeReminderTimestamp = currentTimestamp;
				Save();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
		}
		Debug.Log("Dialog Manager: Unit upgrade reminder condition not passed");
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public bool ShowJoinOrCreateSquadReminder()
	{
		string text = $"8 SQUAD REMINDER\tIs in squad: {!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName)}\tLevel: {LevelManager.instance.currentLevel.displayNumber}/{ReminderManager.instance.minLevelForSquadJoinOrCreateReminder}";
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && LevelManager.instance.currentLevel.displayNumber >= ReminderManager.instance.minLevelForSquadJoinOrCreateReminder && !LevelManager.instance.isSquadJoinAndCreateLocked)
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = currentTimestamp - data.joinOrCreateSquadReminderTimestamp;
			int num2 = currentTimestamp - data.purchaseVipReminderTimestamp;
			text += string.Format("\tTime since last show: {0}\tTime since vip reminder: {1}", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty), MiscTools.PrintableTime(num2, "ID_READYTIME", string.Empty));
			if (num >= ReminderManager.instance.squadReminderBetweenTime && num2 >= 86400)
			{
				Singleton<MessageManager>.instance.AddMessage(new BeAdvisedJoinOrCreateSquad());
				data.joinOrCreateSquadReminderTimestamp = currentTimestamp;
				Save();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
		}
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public bool ShowPurchaseVipReminder()
	{
		string text = $"9 VIP REMINDER\tIs vip {Singleton<VipManager>.instance.IsVipActive()}";
		if (!Singleton<VipManager>.instance.IsVipActive())
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = currentTimestamp - Singleton<VipManager>.instance.vipExpiration;
			int num2 = currentTimestamp - data.purchaseVipReminderTimestamp;
			int num3 = currentTimestamp - data.joinOrCreateSquadReminderTimestamp;
			text += string.Format("\tTime since vip: {0}\tTime since last show: {1}\tTime since squad reminder: {2}", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty), MiscTools.PrintableTime(num2, "ID_READYTIME", string.Empty), MiscTools.PrintableTime(num3, "ID_READYTIME", string.Empty));
			if (num >= ReminderManager.instance.minTimeSinceLastVipPurchase && num2 >= ReminderManager.instance.vipReminderBetweenTime && num3 >= 86400)
			{
				Singleton<MessageManager>.instance.AddMessage(new BeAdvisedPurchaseVIP());
				data.purchaseVipReminderTimestamp = currentTimestamp;
				Save();
				AddDebugMessage(text + "\t\"TRUE\"");
				return true;
			}
		}
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public bool ShowUnitCategories()
	{
		string text = $"10 Unit Categories\tWas shown {data.unitCategoriesShown}\tGames {StatsManager.instance.totalGames}/{ReminderManager.instance.unitCategoriesReminderAfterGames}";
		if (!data.unitCategoriesShown && StatsManager.instance.totalGames >= ReminderManager.instance.unitCategoriesReminderAfterGames)
		{
			Singleton<MessageManager>.instance.AddMessage(new UnitCategoriesReminder());
			data.unitCategoriesShown = true;
			Save();
			AddDebugMessage(text + "\t\"TRUE\"");
			return true;
		}
		AddDebugMessage(text + "\t\"FALSE\"");
		return false;
	}

	public void InitializeDebugMessage()
	{
		mDebugMessage = $"CLIENT REMINDERS:\nTutorial upgrade weapon running \"{TutorialManagerStage4.instance.isTutorialRunning}\"\n";
		mDebugMessage += $"Tutorial upgrade unit running \"{TutorialManagerStage5.instance.isTutorialRunning}\"\n";
		mDebugMessage += $"Level up \"{LevelManager.instance.isLevelUp}\"\n";
	}

	public void InitializeDebugMessageForRateApp()
	{
		mDebugMessage = string.Empty;
	}

	public void AddDebugMessage(string debugText)
	{
		mDebugMessage = mDebugMessage + debugText + "\n";
	}

	public void PrintDebugMessage()
	{
		Debug.Log(mDebugMessage);
	}

	public IGuiDialog GetTopMostDialog()
	{
		float num = float.MaxValue;
		IGuiDialog result = null;
		IGuiDialog[] array = mDialogs;
		foreach (IGuiDialog guiDialog in array)
		{
			GuiElement guiElement = guiDialog.GetGuiElement();
			if (guiElement.isShowed && guiElement.transform.position.z < num)
			{
				num = guiElement.transform.position.z;
				result = guiDialog;
			}
		}
		return result;
	}
}
