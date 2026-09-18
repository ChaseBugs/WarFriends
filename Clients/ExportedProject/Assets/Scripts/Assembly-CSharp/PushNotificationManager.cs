using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Beebyte.Obfuscator;
using Google2u;
using Prime31;
using UnityEngine;

[Skip]
public class PushNotificationManager : InGameSerializedObjectGeneric<PushNotificationManager.PushNotificationData>
{
	[Skip]
	public class PushNotificationData
	{
		public bool failedToRegister;

		public string deviceToken;

		public Dictionary<string, LocalNotificationData> localNotifications = new Dictionary<string, LocalNotificationData>();
	}

	[Skip]
	public class LocalNotificationData
	{
		public string message = string.Empty;

		public int deadline;

		public bool skip;

		public int notificationId;
	}

	private const string gcmSenderId = "329232687073";

	private static PushNotificationManager mInstance;

	private bool mWasAwakedFromPushNotificationChallenge;

	public static PushNotificationManager instance
	{
		get
		{
			mInstance = mInstance ?? ((PushNotificationManager)UnityEngine.Object.FindObjectsOfType(typeof(PushNotificationManager))[0]);
			return mInstance;
		}
	}

	public bool wasAwakedFromPushNotificationChallenge
	{
		get
		{
			bool result = mWasAwakedFromPushNotificationChallenge;
			mWasAwakedFromPushNotificationChallenge = false;
			return result;
		}
		set
		{
			mWasAwakedFromPushNotificationChallenge = value;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		GameLoginManager.instance.PlayerLogOut += OnLogOut;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
		EtceteraAndroidManager.notificationReceivedEvent += etceteraNotificationReceivedEvent;
		GoogleCloudMessagingManager.notificationReceivedEvent += gcmNotificationReceivedEvent;
		GoogleCloudMessagingManager.registrationSucceededEvent += gcmRegistrationSucceededEvent;
		GoogleCloudMessagingManager.registrationFailedEvent += gcmRegistrationFailedEvent;
		GoogleCloudMessagingManager.unregistrationSucceededEvent += gcmUnregistrationSucceededEvent;
		GoogleCloudMessagingManager.unregistrationFailedEvent += gcmUnregistrationFailedEvent;
		EtceteraAndroid.checkForNotifications();
		GoogleCloudMessaging.checkForNotifications();
		CancelLocalNotifications();
	}

	protected override void Start()
	{
		base.Start();
		OutputLocalNotifications();
	}

	protected void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			OutputLocalNotifications();
			RescheduleLocalNotifications();
		}
	}

	protected void OnApplicationQuit()
	{
		OutputLocalNotifications();
		RescheduleLocalNotifications();
	}

	private void OnApplicationResumed()
	{
	}

	private void OnPlayerDataLoaded()
	{
		EnablePushNotifications(GameLoginManager.instance.data.currentPlayer.deviceToken);
	}

	private void OnLogOut()
	{
		CancelLocalNotifications();
	}

	public bool hasValidDeviceToken()
	{
		return !string.IsNullOrEmpty(data.deviceToken);
	}

	public void ScheduleDailyRewardNotification(int onTime, string text)
	{
		if (onTime > 1)
		{
			ScheduleNotification("NextDailyRewardLocalnotification", text, onTime, absoluteTime: true);
			Save();
		}
		else
		{
			CancelLocalNotification("NextDailyRewardLocalnotification");
		}
	}

	internal void ScheduleLapsedPlayerNotifications()
	{
		Constants constants = Singleton<GameVariables>.instance.constants;
		int[] array = new int[3]
		{
			(int)(float)constants.GetRow(Constants.rowIds.LapsedPlayerInterval1).FLOATVALUE,
			(int)(float)constants.GetRow(Constants.rowIds.LapsedPlayerInterval2).FLOATVALUE,
			(int)(float)constants.GetRow(Constants.rowIds.LapsedPlayerInterval3).FLOATVALUE
		};
		for (int i = 1; i <= 3; i++)
		{
			PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(i.ToString("'lapsed_player_'0"));
			int num = MiscTools.RoundToInt(row.WARBUCKS);
			int num2 = MiscTools.RoundToInt(row.GOLD);
			int num3 = MiscTools.RoundToInt(row.GOLDCARDS);
			int num4 = MiscTools.RoundToInt(row.SILVERCARDS);
			int num5 = MiscTools.RoundToInt(row.VIPSECONDS);
			bool flag = row.PLAYERVISUALS.Length > 3 || row.WEAPONS.Length > 3 || row.ARMYUNITS.Length > 3 || row.CARDSLOT;
			StringBuilder stringBuilder = new StringBuilder(Localization.Localize("ID_NOTIFICATION_LAPSED_BASE"));
			stringBuilder.Append(" ");
			bool flag2 = true;
			if (num5 > 60)
			{
				stringBuilder.AppendFormat(Localization.Localize("ID_NOTIFICATION_LAPSED_VIP"), MiscTools.PrintableTimeVipConvertSmall(num5));
				flag2 = false;
			}
			if (num3 > 0)
			{
				if (!flag2)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.AppendFormat(Localization.Localize("ID_NOTIFICATION_LAPSED_GOLDCARDS"), num3);
				flag2 = false;
			}
			if (num4 > 0)
			{
				if (!flag2)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.AppendFormat(Localization.Localize("ID_NOTIFICATION_LAPSED_SILVERCARDS"), num4);
				flag2 = false;
			}
			if (num2 > 0)
			{
				if (!flag2)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.AppendFormat(Localization.Localize("ID_NOTIFICATION_DAILYREWARD_GOLD"), num2);
				flag2 = false;
			}
			if (num > 0)
			{
				if (!flag2)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.AppendFormat(Localization.Localize("ID_NOTIFICATION_DAILYREWARD_WB"), num);
				flag2 = false;
			}
			if (flag)
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(Localization.Localize("ID_NOTIFICATION_LAPSED_MORE"));
			}
			stringBuilder.Append(" ");
			stringBuilder.Append(Localization.Localize("ID_NOTIFICATION_LAPSED_END"));
			ScheduleNotification(i.ToString("'lapsedNot'0"), stringBuilder.ToString(), array[i - 1]);
		}
		Save();
	}

	internal void ScheduleLocalNextWarsNotification(int deadline)
	{
		ScheduleNotification("nextSquadWars", Localization.Localize("ID_NOTIFICATION_SQUADWAREND"), deadline + 3600);
		Save();
	}

	internal void ScheduleNextWithdrawNotification(int nextWithdraw)
	{
		Debug.Log("PNManager: Scheduling Next withdraw in " + (nextWithdraw - Singleton<BeanstalkServerManager>.instance.currentTimestamp));
		ScheduleNotification("nextWithdraw", Localization.Localize("ID_NOTIFICATION_WITHDRAWAVAILABLE"), nextWithdraw - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		Save();
	}

	internal void ScheduleCraftingFinishedNotification(int deadline, bool goldWarcard)
	{
		Debug.Log("PNManager: Scheduling Crafting Finished Notification in " + (deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp));
		ScheduleNotification("craftingFinished", Localization.Localize((!goldWarcard) ? "ID_NOTIFICATION_SILVERCRAFT" : "ID_NOTIFICATION_GOLDCRAFT"), deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		Save();
	}

	internal void ScheduleLocalNextLeagueNotification(int deadline)
	{
		ScheduleNotification("nextPlayerLeague", Localization.Localize("ID_NOTIFICATION_PLAYERLEAGUEEND"), deadline + 3600);
		Save();
	}

	private void RescheduleLocalNotifications()
	{
		try
		{
			CancelLocalNotifications();
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (currentTimestamp == 0)
			{
				Debug.LogError("PNManager: Not rescheduling -> Beanstalk.currentTimestamp is zero!");
			}
			if (data.localNotifications == null)
			{
				Debug.LogError("PNManager: Not rescheduling -> data.localNotifications is null");
				return;
			}
			RestrictDeliveryNotifications();
			if (data.localNotifications == null)
			{
				return;
			}
			foreach (KeyValuePair<string, LocalNotificationData> localNotification in data.localNotifications)
			{
				int num = localNotification.Value.deadline - currentTimestamp;
				if (num > 0)
				{
					if (localNotification.Value.skip)
					{
						Debug.Log("Skipping note with message " + localNotification.Value.message);
						continue;
					}
					if (localNotification.Key == "nextPlayerLeague" && (SettingsManager.instance.data == null || !SettingsManager.instance.playerLeague || GameLoginManager.currentPlayer.isInBeginnersLeague))
					{
						Debug.Log("Skipping next player league notification");
						continue;
					}
					if (localNotification.Key == "nextWithdraw" && string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && (SettingsManager.instance.data == null || !SettingsManager.instance.squadStatus))
					{
						Debug.Log("Skipping next withdraw basecause player left squad");
						continue;
					}
					if (localNotification.Key == "nextSquadWars" && (SettingsManager.instance.data == null || !SettingsManager.instance.squadStatus))
					{
						Debug.Log("Skipping next squad war notification");
						continue;
					}
					if (localNotification.Key == "NextDailyRewardLocalnotification" && (SettingsManager.instance.data == null || !SettingsManager.instance.dailyRewardNotification))
					{
						Debug.Log("Skipping next daily reward notification");
						continue;
					}
					if (localNotification.Key == "dogtag" && Singleton<DogTagManager>.instance.isFull)
					{
						Debug.Log("Skipping dogtag notification");
						continue;
					}
					if (localNotification.Key == "instantBattleAvailable" && (!Singleton<GameVariables>.instance.isInstantBattleEnabled || PlayerAnalytics.instance.data.IsInstantBattlesFull()))
					{
						Debug.Log("Skipping instant battle notification");
						continue;
					}
					if ((localNotification.Key == "warArenaReminder" || localNotification.Key == "warArenaStart") && (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded || LevelManager.instance.isWarArenaLocked))
					{
						Debug.Log("Skipping wararena notification");
						continue;
					}
					Debug.Log("Scheduling notification in " + num + ", message = " + localNotification.Value.message);
					AndroidNotificationConfiguration androidNotificationConfiguration = new AndroidNotificationConfiguration(num, "Warfriends", localNotification.Value.message, string.Empty).build();
					androidNotificationConfiguration.smallIcon = "small_icon";
					androidNotificationConfiguration.largeIcon = "large_icon";
					localNotification.Value.notificationId = EtceteraAndroid.scheduleNotification(androidNotificationConfiguration);
				}
			}
			Save();
		}
		catch (Exception ex)
		{
			Debug.LogError(ex);
			Crittercism.LogHandledException(ex);
		}
	}

	private void OutputLocalNotifications()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, LocalNotificationData> localNotification in data.localNotifications)
		{
			if (!localNotification.Value.skip)
			{
				stringBuilder.AppendLine("Note:" + localNotification.Key + ", " + localNotification.Value.message + ", in " + (localNotification.Value.deadline - currentTimestamp));
			}
		}
		Debug.Log("Scheduling notifications: " + stringBuilder);
	}

	public void RescheduleLocalNotificationsAfterError(DatabaseAction failedAction)
	{
		switch (failedAction)
		{
		case DatabaseAction.BuyWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
			CancelLocalNotification("weapon");
			break;
		case DatabaseAction.BuyUnitUpgrade:
		case DatabaseAction.BuyUnit:
			CancelLocalNotification("unit");
			break;
		case DatabaseAction.InstantUnitUpgrade:
		case DatabaseAction.ActivateUnitUpgrade:
			CancelLocalNotification("unit");
			ScheduleLocalUnitNotification();
			break;
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.ActivateWeaponUpgrade:
			CancelLocalNotification("weapon");
			ScheduleLocalWeaponNotification();
			break;
		}
	}

	public void ScheduleLocalNotifications(DatabaseAction action)
	{
		switch (action)
		{
		case DatabaseAction.BuyWeaponUpgrade:
			ScheduleLocalWeaponNotification();
			break;
		case DatabaseAction.BuyUnitUpgrade:
			ScheduleLocalUnitNotification();
			break;
		case DatabaseAction.InstantUnitUpgrade:
		case DatabaseAction.ActivateUnitUpgrade:
		case DatabaseAction.InstantBuyUnit:
		case DatabaseAction.ActivateUnit:
			CancelLocalNotification("unit");
			break;
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.ActivateWeaponUpgrade:
		case DatabaseAction.InstantBuyWeapon:
		case DatabaseAction.ActivateWeapon:
			CancelLocalNotification("weapon");
			break;
		}
	}

	public void CancelLocalNotification(string key, bool save = true)
	{
		if (data.localNotifications.TryGetValue(key, out var value))
		{
			if (value.notificationId >= 0)
			{
				EtceteraAndroid.cancelNotification(value.notificationId);
				value.notificationId = -1;
			}
			data.localNotifications.Remove(key);
		}
		if (save)
		{
			Save();
		}
	}

	private void CancelLocalNotifications()
	{
		foreach (KeyValuePair<string, LocalNotificationData> localNotification in data.localNotifications)
		{
			if (localNotification.Value.notificationId >= 0)
			{
				EtceteraAndroid.cancelNotification(localNotification.Value.notificationId);
				localNotification.Value.notificationId = -1;
			}
		}
		EtceteraAndroid.cancelAllNotifications();
		Save();
	}

	public void ScheduleLocalWeaponNotification()
	{
		int remainingWeaponDelivery = LevelManager.instance.data.GetRemainingWeaponDelivery();
		if (remainingWeaponDelivery > 0)
		{
			string message = Localization.Localize("ID_NOTIFICATION_WEAPONUPGRADEDELIVERED");
			ScheduleNotification("weapon", message, remainingWeaponDelivery);
			Save();
		}
	}

	public void ScheduleLocalUnitNotification()
	{
		int remainingUnitDelivery = LevelManager.instance.data.GetRemainingUnitDelivery();
		if (remainingUnitDelivery > 0)
		{
			string message = Localization.Localize("ID_NOTIFICATION_UNITUPGRADEDELIVERED");
			ScheduleNotification("unit", message, remainingUnitDelivery);
			Save();
		}
	}

	public void ScheduleLocalDogtagNotification(int seconds)
	{
		if (seconds > 0)
		{
			string message = Localization.Localize("ID_NOTIFICATION_DOGTAGFULL");
			ScheduleNotification("dogtag", message, seconds);
			Save();
		}
	}

	public void SheduleLocalSkirmishNotification(int timeStamp)
	{
		if (timeStamp > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			string message = Localization.Localize("ID_NOTIFICATION_INSTANTBATTLEAVAILABLE");
			ScheduleNotification("instantBattleAvailable", message, timeStamp, absoluteTime: true);
			Save();
		}
	}

	public void ScheduleWarArenaReminder(int arenaStartTime)
	{
		int num = (int)(float)WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
		int num2 = 3600 * num;
		int num3 = arenaStartTime - num2;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (num3 >= currentTimestamp)
		{
			string message = Localization.LocalizeFormat("ID_NOTIFICATION_WARARENAREMINDER", num);
			ScheduleNotification("warArenaReminder", message, num3, absoluteTime: true);
			Save();
		}
	}

	public void ScheduleWarArenaStart(int phaseStartTime, bool isArenaStartAlso = false)
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (phaseStartTime >= currentTimestamp)
		{
			string message = Localization.Localize((!isArenaStartAlso) ? "ID_NOTIFICATION_WARARENAPHASE" : "ID_NOTIFICATION_WARARENASTART");
			ScheduleNotification("warArenaStart", message, phaseStartTime, absoluteTime: true);
			Save();
		}
	}

	public bool ArePushNotificationsEnabledOnDevice()
	{
		return true;
	}

	public void EnablePushNotifications(string databaseDeviceToken)
	{
		Debug.Log("Database Token = " + databaseDeviceToken + ", my device token = " + data.deviceToken);
		if (string.IsNullOrEmpty(data.deviceToken))
		{
			data.failedToRegister = true;
			Debug.Log("PNManager: Enable Push Notifications");
			GoogleCloudMessaging.register("329232687073");
		}
		else if (databaseDeviceToken == data.deviceToken)
		{
			Debug.Log("Enable Push Notifications - device token is the same! Not sending deviceToken");
		}
		else
		{
			Debug.Log("Enable Push Notifications - devicetoken is different!");
			Singleton<BeanstalkServerManager>.instance.UpdateDeviceToken(data.deviceToken);
		}
	}

	private void ScheduleNotification(string notificationKey, string message, int seconds, bool absoluteTime = false)
	{
		CancelLocalNotification(notificationKey, save: false);
		data.localNotifications[notificationKey] = new LocalNotificationData
		{
			deadline = ((!absoluteTime) ? (Singleton<BeanstalkServerManager>.instance.currentTimestamp + seconds) : seconds),
			message = message
		};
	}

	private void RestrictDeliveryNotifications()
	{
		if (!data.localNotifications.ContainsKey("unit") || !data.localNotifications.ContainsKey("weapon"))
		{
			return;
		}
		int num = data.localNotifications["unit"].deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num2 = data.localNotifications["weapon"].deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (num2 > 0 && num > 0 && num2 < 300 && num < 300)
		{
			if (num2 < num)
			{
				data.localNotifications["unit"].skip = true;
				data.localNotifications["weapon"].skip = false;
			}
			else
			{
				data.localNotifications["unit"].skip = false;
				data.localNotifications["weapon"].skip = true;
			}
		}
		else
		{
			data.localNotifications["unit"].skip = false;
			data.localNotifications["weapon"].skip = false;
		}
	}

	private void ReactToNotification(DatabaseAction databaseAction)
	{
		switch (databaseAction)
		{
		case DatabaseAction.JoinSquad:
		case DatabaseAction.JoinSquadRequest:
		{
			DatabasePlayer currentPlayer2 = GameLoginManager.currentPlayer;
			if (!string.IsNullOrEmpty(currentPlayer2.squadName))
			{
				Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(currentPlayer2.squadName, forceUpdate: true);
			}
			break;
		}
		case DatabaseAction.PromotePlayer:
		case DatabaseAction.DemotePlayer:
		{
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			if (!string.IsNullOrEmpty(currentPlayer.squadName))
			{
				Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(currentPlayer.squadName, forceUpdate: true);
			}
			Singleton<BeanstalkServerManager>.instance.GetAllMessages();
			break;
		}
		case DatabaseAction.MessageSent:
			wasAwakedFromPushNotificationChallenge = true;
			Singleton<BeanstalkServerManager>.instance.GetAllMessages();
			break;
		case DatabaseAction.SystemMessage:
			Singleton<BeanstalkServerManager>.instance.GetAllMessages();
			break;
		}
	}

	private void OnRegistrationSucceded(string deviceToken)
	{
		Debug.LogError("PNManager: registration succeded: " + deviceToken);
		data.failedToRegister = false;
		data.deviceToken = deviceToken;
		Save();
		Singleton<BeanstalkServerManager>.instance.UpdateDeviceToken(deviceToken);
	}

	private void OnRegistrationFailed(string obj)
	{
		Debug.Log("PNManager: registration failed: " + obj);
		data.failedToRegister = true;
		Save();
	}

	private void OnReceivedEvent(IDictionary obj)
	{
		Debug.Log("PNManager: Received event: " + obj.ToStringFull());
		if (obj.Contains("id"))
		{
			DatabaseAction databaseAction = (DatabaseAction)Convert.ToInt32(obj["id"]);
			ReactToNotification(databaseAction);
		}
	}

	private void OnReceivedLaunchEvent(IDictionary obj)
	{
		Debug.Log("PNManager: Received event at launch: " + obj.ToStringFull());
		if (obj.Contains("id"))
		{
			DatabaseAction databaseAction = (DatabaseAction)Convert.ToInt32(obj["id"]);
			ReactToNotification(databaseAction);
		}
	}

	private void OnLocalNotification(IDictionary obj)
	{
		Debug.Log("PNManager: Local Notification");
		foreach (object item in obj)
		{
			Debug.Log("Key = " + item.ToString());
		}
	}

	private void etceteraNotificationReceivedEvent(string extraData)
	{
		Debug.LogFormat("PNManager: Local Notification extraData='{0}'", extraData ?? "null");
	}

	private void gcmNotificationReceivedEvent(Dictionary<string, object> obj)
	{
		if (obj == null)
		{
			return;
		}
		Debug.Log("PNManager: Received event: " + obj.ToStringFull());
		if (obj.ContainsKey("id"))
		{
			object obj2 = obj["id"];
			if (obj2 != null && int.TryParse(obj2.ToString(), out var result))
			{
				DatabaseAction databaseAction = (DatabaseAction)result;
				ReactToNotification(databaseAction);
			}
		}
	}

	private void gcmRegistrationSucceededEvent(string registrationId)
	{
		Debug.Log("PNManager: registration succeded: " + registrationId);
		data.failedToRegister = false;
		data.deviceToken = registrationId;
		Save();
		Singleton<BeanstalkServerManager>.instance.UpdateDeviceToken(registrationId);
	}

	private void gcmRegistrationFailedEvent(string msg)
	{
		Debug.Log("PNManager: registration failed: " + msg);
		data.failedToRegister = true;
		Save();
		Singleton<BeanstalkServerManager>.instance.GetAllMessages();
	}

	private void gcmUnregistrationSucceededEvent()
	{
		Debug.Log("gcmUnregistrationSucceededEvent");
	}

	private void gcmUnregistrationFailedEvent(string msg)
	{
		Debug.LogError("gcmUnregistrationFailedEvent: " + msg);
	}
}
