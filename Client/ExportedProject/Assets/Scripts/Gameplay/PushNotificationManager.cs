using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Firebase.Messaging;
using Google2u;
using Prime31;
using UnityEngine;
using WarFriends.Legacy;

public class PushNotificationManager : InGameSerializedObjectGeneric<PushNotificationManager.PushNotificationData>
{
	public enum BAIMJGGJNHF
	{
		SQUAD_INFO,
		GAME_INFO,
		CHALLENGES,
		EVENT_INFO,
		MAX
	}

	public class PushNotificationData
	{
		public bool failedToRegister;

		public string deviceToken;

		public Dictionary<string, LocalNotificationData> localNotifications = new Dictionary<string, LocalNotificationData>();
	}

	public class LocalNotificationData
	{
		public string message = string.Empty;

		public int deadline;

		public bool skip;

		public int notificationId;

		public BAIMJGGJNHF channel;

		public int badgeNumber;
	}

	private const string gcmSenderId = "329232687073";

	private bool inicialized;

	private static PushNotificationManager mInstance;

	private bool mWasAwakedFromPushNotificationChallenge;

	private bool notificationsInitialized;

	public static PushNotificationManager instance
	{
		get
		{
			mInstance = mInstance ?? ((PushNotificationManager)SingletonSupport.FindOrCreate(typeof(PushNotificationManager)));
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
		EtceteraAndroid.checkForNotifications();
		CancelLocalNotifications();
	}

	private void InitNotifications()
	{
		if (!notificationsInitialized)
		{
			for (int i = 0; i < 4; i++)
			{
				BAIMJGGJNHF bAIMJGGJNHF = (BAIMJGGJNHF)i;
				string text = bAIMJGGJNHF.ToString();
				string text2 = Localization.Localize($"ID_{text}_NAME");
				string empty = string.Empty;
				Debug.LogFormat("#Notifications# registering {0} with name {1}\n{2}", text, text2, empty);
				NotificationsAndroid.registerChannel(text, text2, text);
			}
			notificationsInitialized = true;
		}
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
		InitNotifications();
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
			ScheduleNotification("NextDailyRewardLocalnotification", text, onTime, BAIMJGGJNHF.GAME_INFO, 1, absoluteTime: true);
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
			int num = MEJMLNDFDBP.LJDADOKBBNA(row.WARBUCKS);
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(row.GOLD);
			int num3 = MEJMLNDFDBP.LJDADOKBBNA(row.GOLDCARDS);
			int num4 = MEJMLNDFDBP.LJDADOKBBNA(row.SILVERCARDS);
			int num5 = MEJMLNDFDBP.LJDADOKBBNA(row.VIPSECONDS);
			bool flag = row.PLAYERVISUALS.Length > 3 || row.WEAPONS.Length > 3 || row.ARMYUNITS.Length > 3 || row.CARDSLOT;
			StringBuilder stringBuilder = new StringBuilder(Localization.Localize("ID_NOTIFICATION_LAPSED_BASE"));
			stringBuilder.Append(" ");
			bool flag2 = true;
			if (num5 > 60)
			{
				stringBuilder.AppendFormat(Localization.Localize("ID_NOTIFICATION_LAPSED_VIP"), MEJMLNDFDBP.OLHOHLGMFBK(num5));
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
			ScheduleNotification(i.ToString("'lapsedNot'0"), stringBuilder.ToString(), array[i - 1], BAIMJGGJNHF.GAME_INFO);
		}
		Save();
	}

	internal void ScheduleLocalNextWarsNotification(int deadline)
	{
		ScheduleNotification("nextSquadWars", Localization.Localize("ID_NOTIFICATION_SQUADWAREND"), deadline + 3600, BAIMJGGJNHF.EVENT_INFO);
		Save();
	}

	internal void ScheduleNextWithdrawNotification(int nextWithdraw)
	{
		Debug.Log("PNManager: Scheduling Next withdraw in " + (nextWithdraw - Singleton<BeanstalkServerManager>.instance.currentTimestamp));
		ScheduleNotification("nextWithdraw", Localization.Localize("ID_NOTIFICATION_WITHDRAWAVAILABLE"), nextWithdraw - Singleton<BeanstalkServerManager>.instance.currentTimestamp, BAIMJGGJNHF.SQUAD_INFO);
		Save();
	}

	internal void ScheduleCraftingFinishedNotification(int deadline, bool goldWarcard)
	{
		Debug.Log("PNManager: Scheduling Crafting Finished Notification in " + (deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp));
		string message = Localization.Localize((!goldWarcard) ? "ID_NOTIFICATION_SILVERCRAFT" : "ID_NOTIFICATION_GOLDCRAFT");
		ScheduleNotification("craftingFinished", message, deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp, BAIMJGGJNHF.GAME_INFO);
		Save();
	}

	internal void ScheduleLocalNextLeagueNotification(int deadline)
	{
		ScheduleNotification("nextPlayerLeague", Localization.Localize("ID_NOTIFICATION_PLAYERLEAGUEEND"), deadline + 3600, BAIMJGGJNHF.EVENT_INFO);
		Save();
	}

	public void ScheduleLocalWeaponNotification()
	{
		int remainingWeaponDelivery = LevelManager.instance.data.GetRemainingWeaponDelivery();
		if (remainingWeaponDelivery > 0)
		{
			string message = Localization.Localize("ID_NOTIFICATION_WEAPONUPGRADEDELIVERED");
			ScheduleNotification("weapon", message, remainingWeaponDelivery, BAIMJGGJNHF.GAME_INFO);
			Save();
		}
	}

	public void ScheduleLocalUnitNotification()
	{
		int remainingUnitDelivery = LevelManager.instance.data.GetRemainingUnitDelivery();
		if (remainingUnitDelivery > 0)
		{
			string message = Localization.Localize("ID_NOTIFICATION_UNITUPGRADEDELIVERED");
			ScheduleNotification("unit", message, remainingUnitDelivery, BAIMJGGJNHF.GAME_INFO);
			Save();
		}
	}

	public void ScheduleLocalDogtagNotification(int seconds)
	{
		if (seconds > 0)
		{
			string message = Localization.Localize("ID_NOTIFICATION_DOGTAGFULL");
			ScheduleNotification("dogtag", message, seconds, BAIMJGGJNHF.GAME_INFO);
			Save();
		}
	}

	public void SheduleLocalSkirmishNotification(int timeStamp)
	{
		if (timeStamp > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			string message = Localization.Localize("ID_NOTIFICATION_INSTANTBATTLEAVAILABLE");
			ScheduleNotification("instantBattleAvailable", message, timeStamp, BAIMJGGJNHF.GAME_INFO, 1, absoluteTime: true);
			Save();
		}
	}

	public void ScheduleLocalWarArenaReminder(int arenaStartTime)
	{
		if (!LevelManager.instance.isWarArenaLocked)
		{
			int num = (int)(float)WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
			int num2 = 3600 * num;
			int num3 = arenaStartTime - num2;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num3 >= currentTimestamp)
			{
				string keyFormat = $"ID_NOTIFICATION_WARARENAREMINDER{UnityEngine.Random.Range(1, 5)}";
				string message = Localization.LocalizeFormat(keyFormat, num);
				ScheduleNotification("warArenaReminder", message, num3, BAIMJGGJNHF.EVENT_INFO, 1, absoluteTime: true);
				Save();
			}
		}
	}

	public void ScheduleLocalWarArenaStart(int phaseStartTime, bool isArenaStartAlso = false)
	{
		if (!LevelManager.instance.isWarArenaLocked)
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (phaseStartTime >= currentTimestamp)
			{
				string key = ((!isArenaStartAlso) ? $"ID_NOTIFICATION_WARARENAPHASE{UnityEngine.Random.Range(1, 3)}" : $"ID_NOTIFICATION_WARARENASTART{UnityEngine.Random.Range(1, 5)}");
				string message = Localization.Localize(key);
				ScheduleNotification("warArenaStart", message, phaseStartTime, BAIMJGGJNHF.EVENT_INFO, 1, absoluteTime: true);
				Save();
			}
		}
	}

	private void RescheduleLocalNotifications()
	{
		if (Singleton.applicationIsQuitting)
		{
			return;
		}
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
					if (localNotification.Key == "instantBattleAvailable" && PlayerAnalytics.instance.data.IsInstantBattlesFull())
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
					localNotification.Value.notificationId = NotificationsAndroid.ScheduleNotification(num, "Warfriends", localNotification.Value.message, localNotification.Value.channel.ToString(), localNotification.Value.badgeNumber);
				}
			}
			Save();
		}
		catch (Exception ex)
		{
			Debug.LogError(ex);
			AnalyticsHelper.LogHandledException(ex);
		}
	}

	private void OutputLocalNotifications()
	{
		if (Singleton.applicationIsQuitting)
		{
			return;
		}
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
				NotificationsAndroid.CancelNotification(value.notificationId);
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
				NotificationsAndroid.CancelNotification(localNotification.Value.notificationId);
				localNotification.Value.notificationId = -1;
			}
		}
		EtceteraAndroid.cancelAllNotifications();
		Save();
	}

	public bool ArePushNotificationsEnabledOnDevice()
	{
		return true;
	}

	public void EnablePushNotifications(string databaseDeviceToken)
	{
		Debug.Log("#Notifications# Database Token = " + databaseDeviceToken + ", my device token = " + data.deviceToken);
		if (string.IsNullOrEmpty(data.deviceToken))
		{
			data.failedToRegister = true;
			Debug.Log("PNManager: Enable Push Notifications");
			if (!inicialized)
			{
				inicialized = true;
				FirebaseMessaging.TokenReceived += OnTokenReceived;
				FirebaseMessaging.MessageReceived += OnMessageReceived;
			}
			return;
		}
		if (!inicialized)
		{
			Debug.Log("PNManager: Enable Push Notifications");
			inicialized = true;
			FirebaseMessaging.TokenReceived += OnTokenReceived;
			FirebaseMessaging.MessageReceived += OnMessageReceived;
		}
		if (databaseDeviceToken == null)
		{
			databaseDeviceToken = string.Empty;
		}
		int num = databaseDeviceToken.IndexOf("$#");
		num = ((num >= 0) ? (num + 2) : 0);
		if (databaseDeviceToken.Substring(num) == data.deviceToken)
		{
			Debug.Log("Enable Push Notifications - device token is the same! Not sending deviceToken");
			return;
		}
		Debug.Log("Enable Push Notifications - devicetoken is different!");
		Singleton<BeanstalkServerManager>.instance.PIPLIJHJHFC(data.deviceToken);
	}

	private void ScheduleNotification(string notificationKey, string message, int seconds, BAIMJGGJNHF channel, int badgeNum = 1, bool absoluteTime = false)
	{
		CancelLocalNotification(notificationKey, save: false);
		data.localNotifications[notificationKey] = new LocalNotificationData
		{
			deadline = ((!absoluteTime) ? (Singleton<BeanstalkServerManager>.instance.currentTimestamp + seconds) : seconds),
			message = message,
			channel = channel,
			badgeNumber = badgeNum
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
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(currentPlayer2.squadName, FHKKPEIDDJN: true);
			}
			break;
		}
		case DatabaseAction.PromotePlayer:
		case DatabaseAction.DemotePlayer:
		{
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			if (!string.IsNullOrEmpty(currentPlayer.squadName))
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(currentPlayer.squadName, FHKKPEIDDJN: true);
			}
			Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
			break;
		}
		case DatabaseAction.MessageSent:
			wasAwakedFromPushNotificationChallenge = true;
			Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
			break;
		case DatabaseAction.SystemMessage:
			Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
			break;
		}
	}

	private void OnRegistrationSucceded(string deviceToken)
	{
		Debug.LogError("PNManager: registration succeded: " + deviceToken);
		data.failedToRegister = false;
		data.deviceToken = deviceToken;
		Save();
		Singleton<BeanstalkServerManager>.instance.PIPLIJHJHFC(deviceToken);
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

	public void OnTokenReceived(object sender, TokenReceivedEventArgs token)
	{
		Debug.Log("#Notifications# Received Registration Token: " + token.Token);
		data.failedToRegister = false;
		data.deviceToken = token.Token;
		Save();
		Singleton<BeanstalkServerManager>.instance.PIPLIJHJHFC(data.deviceToken);
	}

	public void OnMessageReceived(object sender, MessageReceivedEventArgs e)
	{
		Debug.LogFormat("#Notifications# Received a new message {0} ({1})", e.Message.MessageId, e.Message.MessageType);
		if (e.Message.Data != null && e.Message.Data.ContainsKey("id"))
		{
			Debug.LogFormat("#Notifications# Received a with data id = {0}", e.Message.Data["id"]);
			if (int.TryParse(e.Message.Data["id"], out var result))
			{
				DatabaseAction databaseAction = (DatabaseAction)result;
				ReactToNotification(databaseAction);
			}
		}
	}

	private void etceteraNotificationReceivedEvent(string extraData)
	{
		Debug.LogFormat("PNManager: Local Notification extraData='{0}'", extraData ?? "null");
	}
}
