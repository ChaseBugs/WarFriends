using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;
using WarFriends.Legacy;

public class ReminderManager : InGameSerializedObjectGeneric<ReminderManager.SaveData>
{
	public enum ReminderType
	{
		VipRunningOut,
		VipExpired,
		Cards,
		UpgradeWeapon,
		UpgradeUnit,
		PowerBand,
		SquadJoinCreate,
		ConnectFb,
		VipPurchase,
		MoneyPackRunningOut,
		StarterPackRunningOut,
		DailyAssignments
	}

	public class SaveData
	{
		public Dictionary<ReminderType, int> remindersTimeDefinitions;

		public int losesStreaks;

		public bool lastSessionVIPStatus;
	}

	private static ReminderManager mInstance;

	public WeaponLevelsSetup weaponForUpgrade;

	private int mLastTimeFromWeaponUpgrade;

	private bool mAnyAvailableWeaponCanBeUpgraded;

	private bool mAnyWeaponDeliveringDelivered;

	public LevelBehaviour unitForUpgrade;

	private int mLastTimeFromUnitUpgrade;

	private bool mAnyAvailableUnitCanBeUpgraded;

	private bool mAnyUnitDeliveringDelivered;

	public int losesStreaks
	{
		get
		{
			return data.losesStreaks;
		}
		set
		{
			data.losesStreaks = value;
			Save();
		}
	}

	public bool lastSessionVIPStatus
	{
		get
		{
			return data.lastSessionVIPStatus;
		}
		set
		{
			data.lastSessionVIPStatus = value;
			Save();
		}
	}

	private bool isUpgradeTutorialRunning => TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;

	public static ReminderManager instance
	{
		get
		{
			mInstance = mInstance ?? ((ReminderManager)SingletonSupport.FindOrCreate(typeof(ReminderManager)));
			return mInstance;
		}
	}

	public int vipRunningOutSeconds => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipRunningOutSeconds).FLOATVALUE;

	public int minTimeSinceLastWeaponUpgrade => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastWeaponUpgrade).FLOATVALUE;

	public int minTimeSinceLastUnitUpgrade => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastUnitUpgrade).FLOATVALUE;

	public int minLevelForCardsReminder => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinLevelForCardsReminder).FLOATVALUE;

	public int lowNumberOfCards => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LowNumberOfCards).FLOATVALUE;

	public int minLevelForSquadJoinOrCreateReminder => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinLevelForSquadJoinOrCreateReminder).FLOATVALUE;

	public int minTimeSinceLastVipPurchase => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastVipPurchase).FLOATVALUE;

	public int rateAppMaxShow => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppMaxShow).FLOATVALUE;

	public int notificationAllowWinsNeed => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowWinsNeed).FLOATVALUE;

	public int notificationAllowTimeBetween => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowHoursBetween).FLOATVALUE * 3600;

	public int notificationAllowMaxShow => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowMaxShow).FLOATVALUE * 3600;

	public int nameChangeReminderGamesAfterFbLogin => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NameChangeReminderGamesAfterFbLogin).FLOATVALUE;

	public int facebookRemindDialogShow1After => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReminder1After).FLOATVALUE * 3600;

	public int facebookRemindDialogShow2After => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReminder2After).FLOATVALUE * 3600;

	public int facebookRemindDialogShow3After => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReminder3After).FLOATVALUE * 3600;

	public int vipReminderBetweenTime => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenVIPreminderShown).FLOATVALUE * 3600;

	public int weaponReminderBetweenTime => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenWeaponUpgradeReminderShown).FLOATVALUE * 3600;

	public int unitReminderBetweenTime => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenUnitUpgradeReminderShown).FLOATVALUE * 3600;

	public int squadReminderBetweenTime => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenSquadReminderShown).FLOATVALUE * 3600;

	public int unitCategoriesReminderAfterGames => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.UnitCategoriesReminderAfterGames).FLOATVALUE;

	public int moneyPackRunningOutSeconds => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MoneyPackRunningOutSeconds).FLOATVALUE * 3600;

	public int rateAppShowAfterBattles => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppShowAfterBattles).FLOATVALUE;

	public int rateAppShowAfterLevel => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppShowAfterLevel).FLOATVALUE;

	public int rateAppShowSecondTimeAfterLevel => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppShowSecondTimeAfterLevel).FLOATVALUE;

	public int starterPackRunningOutSeconds => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.StarterPackRunningOutSeconds).FLOATVALUE * 3600;

	public string debugMoneyPackRunningOut
	{
		get
		{
			int num = (data.remindersTimeDefinitions.ContainsKey(ReminderType.MoneyPackRunningOut) ? data.remindersTimeDefinitions[ReminderType.MoneyPackRunningOut] : 0);
			return string.Format("Show money pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}", PlayerAnalytics.instance.showMoneyPack, MEJMLNDFDBP.CJCFPDLDMEK(moneyPackRunningOutSeconds, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(PlayerAnalytics.instance.data.moneyPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp - num, "ID_READYTIME", string.Empty));
		}
	}

	public string debugStarterPackRunningOut
	{
		get
		{
			int num = (data.remindersTimeDefinitions.ContainsKey(ReminderType.StarterPackRunningOut) ? data.remindersTimeDefinitions[ReminderType.StarterPackRunningOut] : 0);
			return string.Format("Show starter pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}", PlayerAnalytics.instance.showMoneyPack, MEJMLNDFDBP.CJCFPDLDMEK(starterPackRunningOutSeconds, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp - num, "ID_READYTIME", string.Empty));
		}
	}

	public string debugVipRunningOut
	{
		get
		{
			int num = (data.remindersTimeDefinitions.ContainsKey(ReminderType.VipRunningOut) ? data.remindersTimeDefinitions[ReminderType.VipRunningOut] : 0);
			return string.Format("VIP active: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}", Singleton<VipManager>.instance.NOGEIPHFNPK(), MEJMLNDFDBP.CJCFPDLDMEK(vipRunningOutSeconds, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<VipManager>.instance.vipExpiration - Singleton<VipManager>.instance.vipStart, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp - num, "ID_READYTIME", string.Empty));
		}
	}

	public string debugVipExpired
	{
		get
		{
			int num = (data.remindersTimeDefinitions.ContainsKey(ReminderType.VipExpired) ? data.remindersTimeDefinitions[ReminderType.VipExpired] : 0);
			return string.Format("VIP active: {0}\tLast time VIP active: {1}\tLast shown: {2}", Singleton<VipManager>.instance.NOGEIPHFNPK(), lastSessionVIPStatus, MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp - num, "ID_READYTIME", string.Empty));
		}
	}

	public bool canShowWeaponUpgradeReminder
	{
		get
		{
			CountAllVariablesForWeaponUpgrade();
			return TutorialManagerStage4.instance.wasFinished && !mAnyWeaponDeliveringDelivered && mAnyAvailableWeaponCanBeUpgraded && Singleton<BeanstalkServerManager>.instance.currentTimestamp - mLastTimeFromWeaponUpgrade > minTimeSinceLastWeaponUpgrade;
		}
	}

	public string debugWeaponUpgradeConditions
	{
		get
		{
			CountAllVariablesForWeaponUpgrade();
			return string.Format("Tutorial for weapon upgraded shown: {0}\tAny weapon delivering/delivered: {1}\tAny weapon can be upgraded: {2}\tTime since last update: {3}\tChosen Weapon: {4}", TutorialManagerStage4.instance.wasFinished, mAnyWeaponDeliveringDelivered, mAnyAvailableWeaponCanBeUpgraded, MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp - mLastTimeFromWeaponUpgrade, "ID_READYTIME", string.Empty), (!(weaponForUpgrade == null)) ? weaponForUpgrade.weaponName : "null");
		}
	}

	public bool canShowUnitUpgradeReminder
	{
		get
		{
			CountAllVariablesForUnitUpgrade();
			return TutorialManagerStage5.instance.wasFinished && !mAnyUnitDeliveringDelivered && mAnyAvailableUnitCanBeUpgraded && Singleton<BeanstalkServerManager>.instance.currentTimestamp - mLastTimeFromUnitUpgrade > minTimeSinceLastUnitUpgrade;
		}
	}

	public string debugUnitUpgradeConditions
	{
		get
		{
			CountAllVariablesForUnitUpgrade();
			return string.Format("Tutorial for unit upgraded shown: {0}\tAny unit delivering/delivered: {1}\tAny unit can be upgraded: {2}\tTime since last update: {3}\tChosen Unit: {4}", TutorialManagerStage5.instance.wasFinished, mAnyUnitDeliveringDelivered, mAnyAvailableUnitCanBeUpgraded, MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp - mLastTimeFromUnitUpgrade, "ID_READYTIME", string.Empty), (!(unitForUpgrade == null)) ? unitForUpgrade.unitName : "null");
		}
	}

	private void CheckDictionary()
	{
		if (data.remindersTimeDefinitions == null)
		{
			data.remindersTimeDefinitions = new Dictionary<ReminderType, int>();
			data.remindersTimeDefinitions.Add(ReminderType.VipRunningOut, 0);
			data.remindersTimeDefinitions.Add(ReminderType.VipExpired, 0);
			data.remindersTimeDefinitions.Add(ReminderType.Cards, 0);
			data.remindersTimeDefinitions.Add(ReminderType.MoneyPackRunningOut, 0);
			data.remindersTimeDefinitions.Add(ReminderType.StarterPackRunningOut, 0);
			data.remindersTimeDefinitions.Add(ReminderType.DailyAssignments, 0);
			data.losesStreaks = 0;
			data.lastSessionVIPStatus = false;
			Save();
		}
	}

	private void SaveShowTime(ReminderType typ)
	{
		CheckDictionary();
		if (data.remindersTimeDefinitions.ContainsKey(typ))
		{
			data.remindersTimeDefinitions[typ] = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
		else
		{
			data.remindersTimeDefinitions.Add(typ, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		}
		Save();
	}

	private bool WasShownInLast24Hours(ReminderType typ)
	{
		CheckDictionary();
		if (data.remindersTimeDefinitions.ContainsKey(typ))
		{
			int num = Singleton<BeanstalkServerManager>.instance.currentTimestamp - data.remindersTimeDefinitions[typ];
			return num < 86400;
		}
		return false;
	}

	private bool WasShownInLast7Days(ReminderType typ)
	{
		CheckDictionary();
		if (data.remindersTimeDefinitions.ContainsKey(typ))
		{
			int num = Singleton<BeanstalkServerManager>.instance.currentTimestamp - data.remindersTimeDefinitions[typ];
			return num < 604800;
		}
		return false;
	}

	private bool WasShownToday(ReminderType typ)
	{
		CheckDictionary();
		if (data.remindersTimeDefinitions.ContainsKey(typ))
		{
			int iPEANJOMOGO = data.remindersTimeDefinitions[typ];
			DateTime dateTime = MEJMLNDFDBP.LAEDFBJFGBP(iPEANJOMOGO);
			DateTime currentDateTime = Singleton<BeanstalkServerManager>.instance.currentDateTime;
			return dateTime.Day == currentDateTime.Day && dateTime.Month == currentDateTime.Month && dateTime.Year == currentDateTime.Year;
		}
		return false;
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		CheckDictionary();
		Singleton<GameController>.instance.GameStarted -= OnGameStarted;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded -= OnGameEnded;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		Singleton<VipManager>.instance.VipStatusChanged += OnVipStatusChanged;
	}

	private void OnGameStarted()
	{
		StopAllCoroutines();
	}

	private void OnGameEnded(GameController.HKGHCIEPGEL gameEndReason)
	{
		if (!Singleton<GameController>.instance.isTutorial)
		{
			losesStreaks = ((!Singleton<GameController>.instance.wonLastGame) ? (losesStreaks + 1) : 0);
		}
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (!Singleton<GameController>.instance.isTutorial)
		{
			Debug.Log($"Reminder Manager: CLIENT REMINDERS AFTER PLAYER DATA LOADED:\n{debugMoneyPackRunningOut}\n{debugStarterPackRunningOut}\n{debugVipRunningOut}\n{debugVipExpired}");
			ShowMoneyPackRunningOut();
			ShowStarterPackRunningOut();
			ShowVipRunningOut();
			ShowVipExpired();
			lastSessionVIPStatus = Singleton<VipManager>.instance.NOGEIPHFNPK();
		}
	}

	private void OnVipStatusChanged(bool isVip)
	{
		if (!isVip)
		{
			lastSessionVIPStatus = true;
		}
		ShowVipExpired();
		lastSessionVIPStatus = isVip;
	}

	private void ShowMoneyPackRunningOut()
	{
		if (PlayerAnalytics.instance.showMoneyPack && PlayerAnalytics.instance.data.moneyPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp < moneyPackRunningOutSeconds && !WasShownInLast24Hours(ReminderType.MoneyPackRunningOut))
		{
			Singleton<MessageManager>.instance.AddMessage(new NHKKDKJNMFL(MIIMAINACGE: true));
			SaveShowTime(ReminderType.MoneyPackRunningOut);
		}
	}

	private void ShowStarterPackRunningOut()
	{
		if (PlayerAnalytics.instance.showStarterPack && PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp < starterPackRunningOutSeconds && !WasShownInLast24Hours(ReminderType.StarterPackRunningOut))
		{
			Singleton<MessageManager>.instance.AddMessage(new GJJLHIIMGOP(MIIMAINACGE: true));
			SaveShowTime(ReminderType.StarterPackRunningOut);
		}
	}

	private void ShowVipRunningOut()
	{
		if (Singleton<VipManager>.instance.NOGEIPHFNPK() && Singleton<VipManager>.instance.vipExpiration - Singleton<VipManager>.instance.vipStart >= vipRunningOutSeconds + 10 && Singleton<VipManager>.instance.vipExpiration - Singleton<BeanstalkServerManager>.instance.currentTimestamp <= vipRunningOutSeconds && !WasShownInLast24Hours(ReminderType.VipRunningOut))
		{
			Singleton<MessageManager>.instance.AddMessage(new FFBPJHGONDP());
			SaveShowTime(ReminderType.VipRunningOut);
		}
	}

	private void ShowVipExpired()
	{
		if (!Singleton<VipManager>.instance.NOGEIPHFNPK() && lastSessionVIPStatus && !WasShownInLast24Hours(ReminderType.VipExpired))
		{
			Singleton<MessageManager>.instance.AddMessage(new FMCFACHPNOP());
			SaveShowTime(ReminderType.VipExpired);
		}
	}

	private void CountAllVariablesForWeaponUpgrade()
	{
		weaponForUpgrade = null;
		mAnyAvailableWeaponCanBeUpgraded = false;
		mAnyWeaponDeliveringDelivered = false;
		mLastTimeFromWeaponUpgrade = 0;
		List<WeaponLevelsSetup> list = new List<WeaponLevelsSetup>();
		int num = 0;
		foreach (PlayerInventory.InventorySlot inventorySlot in PlayerInventory.instance.inventorySlots)
		{
			if (inventorySlot.category != WeaponCategory.Pistol)
			{
				WeaponLevelsSetup weaponLevelsSetup = inventorySlot.weaponLevelsSetup;
				if (weaponLevelsSetup.canBeUpgraded && !weaponLevelsSetup.tryOutWeapon)
				{
					list.Add(weaponLevelsSetup);
				}
			}
		}
		foreach (WeaponLevelsSetup weaponLevelsSetup2 in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup2.bought && !weaponLevelsSetup2.tryOutWeapon)
			{
				if (mLastTimeFromWeaponUpgrade < (int)weaponLevelsSetup2.endDeliveryTime)
				{
					mLastTimeFromWeaponUpgrade = (int)weaponLevelsSetup2.endDeliveryTime;
				}
				mAnyWeaponDeliveringDelivered = mAnyWeaponDeliveringDelivered || weaponLevelsSetup2.delivering || weaponLevelsSetup2.deliveryActivationNeeded;
			}
		}
		mAnyAvailableWeaponCanBeUpgraded = list.Count > 0;
		if (mAnyAvailableWeaponCanBeUpgraded)
		{
			weaponForUpgrade = list[UnityEngine.Random.Range(0, list.Count)];
		}
	}

	private void CountAllVariablesForUnitUpgrade()
	{
		unitForUpgrade = null;
		mAnyAvailableUnitCanBeUpgraded = false;
		mAnyUnitDeliveringDelivered = false;
		mLastTimeFromUnitUpgrade = 0;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		int num = 0;
		List<LevelBehaviour> list2 = new List<LevelBehaviour>();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (!behaviour.upgradeSlots.bought || behaviour.upgradeSlots.borrowed)
			{
				continue;
			}
			if (mLastTimeFromUnitUpgrade < (int)behaviour.upgradeSlots.endDeliveryTime)
			{
				mLastTimeFromUnitUpgrade = (int)behaviour.upgradeSlots.endDeliveryTime;
			}
			if (behaviour.upgradeSlots.canBeUpgraded)
			{
				list2.Add(behaviour);
				if (behaviour.upgradeSlots.actualTier > num)
				{
					num = behaviour.upgradeSlots.actualTier;
				}
			}
			mAnyUnitDeliveringDelivered = mAnyUnitDeliveringDelivered || behaviour.upgradeSlots.delivering || behaviour.upgradeSlots.deliveryActivationNeeded;
		}
		foreach (LevelBehaviour item in list2)
		{
			if (item.upgradeSlots.actualTier == num)
			{
				list.Add(item);
			}
		}
		mAnyAvailableUnitCanBeUpgraded = list.Count > 0;
		if (mAnyAvailableUnitCanBeUpgraded)
		{
			unitForUpgrade = list[UnityEngine.Random.Range(0, list.Count)];
		}
	}

	public PlayerVisual GetRandomPowerBand()
	{
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		List<PlayerVisual> list = new List<PlayerVisual>();
		PlayerVisual playerVisual = null;
		foreach (PlayerVisual allVisual in CamosManager.instance.playerVisualCategories[3].allVisuals)
		{
			if (allVisual.timeActive > 0)
			{
				if (playerVisual == null)
				{
					playerVisual = allVisual;
				}
				if (!allVisual.isVipOnly && displayNumber <= allVisual.unlockLevel.displayNumber)
				{
					list.Add(allVisual);
				}
			}
		}
		return (list.Count != 0) ? list[UnityEngine.Random.Range(0, list.Count - 1)] : playerVisual;
	}

	public bool ShowWarcardsReminder()
	{
		if (CardManager.instance.data.GetCardAmount() >= lowNumberOfCards || GameLoginManager.generatedCurrentPlayer.level < minLevelForCardsReminder || isUpgradeTutorialRunning)
		{
			return false;
		}
		if (WasShownInLast24Hours(ReminderType.Cards))
		{
			return false;
		}
		Singleton<MessageManager>.instance.AddMessage(new EOLJBBIEJHL());
		SaveShowTime(ReminderType.Cards);
		return true;
	}

	public bool ShowDailyAssignmentsReminder()
	{
		if (WasShownToday(ReminderType.DailyAssignments))
		{
			return false;
		}
		Singleton<MessageManager>.instance.AddMessage(new IGHFNDHLCAF());
		SaveShowTime(ReminderType.DailyAssignments);
		return true;
	}
}
