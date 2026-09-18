using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using FuseMisc;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class FuseboxxService
{
	private class FuseboxxConfigurationKey
	{
		public const string ConfigName = "ConfigName";

		public const string StarterPackDays = "StarterPackDays";

		public const string BattleWarbucksRewards = "BattleWarbucksRewards";

		public const string CardRarity = "CardRarity";

		public const string DogTags = "DogTags";

		public const string LevelRewards = "LevelRewards";

		public const string StartingCurrency = "StartingCurrency";

		public const string SpecialOfferSuffix = "SpecialOfferSuffix";

		public const string SpecialOfferDiscountAdd = "SpecialOfferDiscountAdd";

		public const string SpecialPackPrefix = "Pack.";

		public const string goldInappPrefix = "goldPrefix";

		public const string wbInappPrefix = "wbPrefix";

		public const string PlayerProgressRate = "PlayerProgressRate";

		public const string GoldCoefficient = "GoldCoefficient";

		public const string GoldExpCoefficient = "GoldExpCoefficient";

		public const string TutorialCards = "TutorialCards";

		public const string FuseboxxConfigValue = "FuseboxxConfigValue";

		public const string SheetABTestVarian = "SheetVersionVariant";
	}

	public enum Currency
	{
		Medals = 1,
		Levels,
		Warbucks,
		Gold
	}

	private const string mDefaultConfigName = "devConfig";

	private const string mAppIdAboutFun = "e695d3cf-1ed0-4989-89fe-e041e4ee7e2b";

	private const string mAppIdChillingo = "6c771dc4-510b-4402-a4f9-0c08579edd37";

	private const string mAppIdChillingoAndroid = "76e544a0-32c5-4775-9716-ff04c6fbaaa3";

	private string mZoneReward = "173432c2";

	private string mZoneAll = "24cdfc1f";

	private string mZoneOffer = "49a0434f";

	private RewardType mReward;

	private bool mHaveAnyConfigurationDownloaded;

	private float mInitTime;

	private bool mCanSaveConfigs;

	private bool mNeedSaveConfigs;

	private Dictionary<string, string> configFromDb;

	private string usedABvariant = string.Empty;

	private bool mIsVideoPlaying;

	public bool isVideoPlaying => mIsVideoPlaying;

	public event Action RewardVideoPreloaded;

	public event Action AdvertisementVideoRewardError;

	public FuseboxxService()
	{
		mInitTime = Time.time;
	}

	public FuseboxxService(FuseSDK fuseSdk)
	{
		mInitTime = Time.time;
		FuseSDK.SessionStartReceived += SessionStarted;
		FuseSDK.SessionLoginError += SessionLoginError;
		FuseSDK.AdDeclined += AdDeclined;
		FuseSDK.AdAvailabilityResponse += AdAvailabilityResponse;
		FuseSDK.AdWillClose += AdWillClose;
		FuseSDK.AdDidShow += AdDidShow;
		FuseSDK.RewardedAdCompletedWithObject += RewardedAdCompletedWithObject;
		FuseSDK.IAPOfferAcceptedWithObject += IAPOfferAcceptedWithObject;
		FuseSDK.VirtualGoodsOfferAcceptedWithObject += VirtualGoodsOfferAcceptedWithObject;
		FuseSDK.GameConfigurationReceived += GameConfigurationReceived;
		FuseSDK.NotificationAction += NotificationAction;
		FuseSDK.NotificationWillClose += NotificationWillClose;
		string bundleID = BundleVersionBindings.BundleID;
		if (bundleID.Contains("aboutfun"))
		{
			Debug.Log("Fusebox: Setting ios app id for about fun = e695d3cf-1ed0-4989-89fe-e041e4ee7e2b");
			fuseSdk.iOSAppID = "e695d3cf-1ed0-4989-89fe-e041e4ee7e2b";
			mZoneReward = "64680ae1";
			mZoneAll = "69dfa7c2";
			mZoneOffer = "69dfa7c2";
		}
		else
		{
			Debug.Log("Fusebox: Bundle Id is chillingo! " + bundleID);
			fuseSdk.iOSAppID = "76e544a0-32c5-4775-9716-ff04c6fbaaa3";
		}
	}

	public void SceneLoadedAndPreset()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += InstanceOnDataLoaded;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	private void InstanceOnDataLoaded(DatabaseAction databaseAction)
	{
		switch (databaseAction)
		{
		case DatabaseAction.GetPlayerData:
		case DatabaseAction.CreateAccount:
		case DatabaseAction.TutorialEnded:
		case DatabaseAction.CreateGcAccount:
			mCanSaveConfigs = true;
			if (mHaveAnyConfigurationDownloaded)
			{
				GameConfigurationManager.instance.GetConfigurations(GetConfigVariant());
			}
			else
			{
				GameConfigurationManager.instance.StartCoroutine(WaitForFuseboxConfigurations());
			}
			break;
		}
	}

	public void StartLoginProcces()
	{
		mCanSaveConfigs = false;
	}

	private IEnumerator WaitForFuseboxConfigurations()
	{
		while (!mHaveAnyConfigurationDownloaded && mInitTime + 40f > Time.time)
		{
			yield return new WaitForSeconds(0.2f);
		}
		GameConfigurationManager.instance.GetConfigurations(GetConfigVariant());
		yield return null;
	}

	private string GetConfigVariant()
	{
		string text = string.Empty;
		if (mHaveAnyConfigurationDownloaded)
		{
			text = FuseSDK.GetGameConfigurationValue("SheetVersionVariant");
			if (text == null)
			{
				text = string.Empty;
			}
		}
		else if (configFromDb != null && configFromDb.ContainsKey("SheetVersionVariant"))
		{
			text = configFromDb["SheetVersionVariant"];
		}
		usedABvariant = text;
		return text;
	}

	public void OverrideConfigurations()
	{
		Debug.LogWarning("Fuseboxx: Overriding Configurations");
		Dictionary<string, string> gameConfiguration = FuseSDK.GetGameConfiguration();
		if (mNeedSaveConfigs)
		{
			Singleton<BeanstalkServerManager>.instance.SendFuseboxConfigurations(PrepareConfigurationString());
		}
		if (!mHaveAnyConfigurationDownloaded)
		{
			gameConfiguration = configFromDb;
		}
		try
		{
			if (gameConfiguration == null || !gameConfiguration.ContainsKey("Pack.moneypack1"))
			{
				Debug.Log("changing moneypack to B variant withoud data from fuseboxx");
				Singleton<OfferManager>.instance.RegisterPacksNameChange("moneypack1", "moneypack1B");
			}
		}
		catch (Exception)
		{
			Debug.LogError("Error during set moneypack1B as default");
		}
		if (gameConfiguration == null)
		{
			Debug.LogError("Fuseboxx: No Dictionary with configuration found!");
			return;
		}
		foreach (KeyValuePair<string, string> item in gameConfiguration)
		{
			try
			{
				switch (item.Key)
				{
				case "isInABtest":
					Debug.Log("A/B test value: " + item.Value);
					continue;
				case "CardRarity":
					OverrideCardRarities(JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
					continue;
				case "DogTags":
					OverrideDogTags(JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
					continue;
				case "TutorialCards":
					OverrideTutorialCards(item.Value);
					continue;
				case "goldPrefix":
					GuiElementSingle<InappScreen>.instance.goldPart.goldPrefix = item.Value;
					continue;
				case "wbPrefix":
					Debug.LogWarning("WARBUCKS PREFIX = " + item.Value);
					GuiElementSingle<InappScreen>.instance.warbucksPart.warbucksPrefix = item.Value;
					continue;
				case "LevelRewards":
					OverrideLevelRewards(JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
					continue;
				case "SpecialOfferSuffix":
					Singleton<OfferManager>.instance.suffixForABtesting = item.Value;
					if (Singleton<OfferManager>.instance.suffixForABtesting == "\"")
					{
						Singleton<OfferManager>.instance.suffixForABtesting = string.Empty;
					}
					Debug.Log("setting special offer discount suffix: " + Singleton<OfferManager>.instance.suffixForABtesting + " |");
					continue;
				case "SpecialOfferDiscountAdd":
				{
					int result = 0;
					if (int.TryParse(item.Value, out result))
					{
						Singleton<OfferManager>.instance.DiscountChangeForABTesting = result;
						Debug.Log("setting special offer discount add: " + Singleton<OfferManager>.instance.DiscountChangeForABTesting);
					}
					else
					{
						Singleton<OfferManager>.instance.DiscountChangeForABTesting = 0;
					}
					continue;
				}
				}
				if (item.Key.StartsWith("Pack."))
				{
					Singleton<OfferManager>.instance.RegisterPacksNameChange(item.Key.Substring("Pack.".Length), item.Value);
				}
				else if (item.Key.StartsWith("Google2u"))
				{
					OverrideItem(item.Key, JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
				}
				else if (item.Key.StartsWith("HELMETS") || item.Key.StartsWith("HEAD") || item.Key.StartsWith("CAMOS") || item.Key.StartsWith("BANDS"))
				{
					OverrideDecals(item.Key, JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
				}
				else if (item.Key.StartsWith("Constants."))
				{
					OverrideSheetConstant(item.Key.Substring(10), item.Value);
				}
				else if (item.Key.StartsWith("Sheet."))
				{
					OverrideSheet(item.Key.Replace("Sheet.", "Google2u."), JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
				}
				else
				{
					Debug.LogWarning("UNKNOWN FUSEBOXX CONFIGURATION KEY = " + item.Key);
				}
			}
			catch (Exception)
			{
				Debug.LogError("Error parsing Fuseboxx configuration. Key = " + item.Key + ", Value = " + item.Value);
			}
		}
	}

	private void OverrideTutorialCards(string value)
	{
		StringConstants stringConstants = Singleton<GameVariables>.instance.stringConstants;
		int num = Array.IndexOf(stringConstants.rowNames, StringConstants.rowIds.TutorialCards.ToString());
		if (num != -1)
		{
			stringConstants.SetValue(num, "VALUE", value);
		}
	}

	private void OverrideItem(string itemId, Dictionary<string, object> dictionary)
	{
		WeaponUpgrades weaponUpgradesSheet = LevelManager.instance.weaponUpgradesSheet;
		int num = -1;
		for (int i = 0; i < weaponUpgradesSheet.Rows.Count; i++)
		{
			if (weaponUpgradesSheet.Rows[i].NAME == itemId)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			Debug.Log("overriding weapon " + itemId);
			if (dictionary.ContainsKey("warbucks"))
			{
				weaponUpgradesSheet.SetValue(num, "PRICE", dictionary["warbucks"].ToString());
			}
			if (dictionary.ContainsKey("gold"))
			{
				weaponUpgradesSheet.SetValue(num, "PRICEGOLD", dictionary["gold"].ToString());
			}
			if (dictionary.ContainsKey("unlockLevel"))
			{
				weaponUpgradesSheet.SetValue(num, "UNLOCKLEVEL", dictionary["unlockLevel"].ToString());
			}
		}
		ArmyUpgrades armyUpgradesSheet = LevelManager.instance.armyUpgradesSheet;
		num = -1;
		for (int j = 0; j < armyUpgradesSheet.Rows.Count; j++)
		{
			if (armyUpgradesSheet.Rows[j].NAME == itemId)
			{
				num = j;
				break;
			}
		}
		if (num != -1)
		{
			Debug.Log("overriding army unit " + itemId);
			if (dictionary.ContainsKey("warbucks"))
			{
				armyUpgradesSheet.SetValue(num, "PRICE", dictionary["warbucks"].ToString());
			}
			if (dictionary.ContainsKey("gold"))
			{
				armyUpgradesSheet.SetValue(num, "PRICEGOLD", dictionary["gold"].ToString());
			}
			if (dictionary.ContainsKey("unlockLevel"))
			{
				armyUpgradesSheet.SetValue(num, "UNLOCKLEVEL", dictionary["unlockLevel"].ToString());
			}
		}
	}

	private void OverrideDecals(string decalId, Dictionary<string, object> dictionary)
	{
		PlayerVisuals getPlayerVisualsSafety = CamosManager.instance.getPlayerVisualsSafety;
		if (getPlayerVisualsSafety.namesToIndex.ContainsKey(decalId))
		{
			int num = getPlayerVisualsSafety.namesToIndex[decalId];
			if (num != -1)
			{
				getPlayerVisualsSafety.SetValue(num, "PRICEWARBUCKS", dictionary["warbucks"].ToString());
				getPlayerVisualsSafety.SetValue(num, "PRICEGOLD", dictionary["gold"].ToString());
			}
		}
		else
		{
			Debug.Log("decal not found in sheet: " + decalId);
		}
	}

	private void OverrideLevelRewards(Dictionary<string, object> dictionary)
	{
		foreach (LevelManager.GameLevel level in LevelManager.instance.levels)
		{
			if (dictionary.ContainsKey(level.displayNumber.ToString(CultureInfo.InvariantCulture)))
			{
				object value = dictionary[level.displayNumber.ToString(CultureInfo.InvariantCulture)];
				level.golds = Convert.ToInt32(value);
			}
		}
	}

	private void OverrideInAppRealPrice(Dictionary<string, object> dictionary)
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			int num = Array.IndexOf(inApps.rowNames, item.Key);
			if (num != -1)
			{
				inApps.SetValue(num, "NAME", item.Value.ToString());
			}
		}
	}

	private void OverrideSheet(string key, Dictionary<string, object> dict)
	{
		if (GameConfigurationManager.instance.sheetsDictionary.ContainsKey(key))
		{
			Google2uComponentBase google2uComponentBase = GameConfigurationManager.instance.sheetsDictionary[key];
			Debug.LogError("Fuseboxx: Override Sheet Constants" + key);
			{
				foreach (KeyValuePair<string, object> item in dict)
				{
					int num = Convert.ToInt32(item.Key);
					Debug.LogError("OVERRIDING SHEET DELIVERY TIME " + num + " to " + item.Value);
					google2uComponentBase.SetValue(num, "DELIVERYTIME", item.Value.ToString());
				}
				return;
			}
		}
		Debug.LogError("Sheet " + key + " not found!");
	}

	private void OverrideSheetConstant(string key, string value)
	{
		Debug.LogError("Fuseboxx: Override Sheet Constants" + key + ", val = " + value);
		Google2u.Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(value);
		int rowIndex = constants.GetRowIndex(key);
		if (rowIndex != -1)
		{
			constants.SetValue(rowIndex, "FLOATVALUE", num.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void OverrideDogTags(Dictionary<string, object> dictionary)
	{
		Google2u.Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(dictionary["OneDogTagRefillRate"]);
		int num2 = Array.IndexOf(constants.rowNames, Google2u.Constants.rowIds.DogTagRefillTime.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num.ToString(CultureInfo.InvariantCulture));
		}
		float num3 = Convert.ToSingle(dictionary["DogTagCap"]);
		num2 = Array.IndexOf(constants.rowNames, Google2u.Constants.rowIds.DogTagCap.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num3.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void OverrideCardRarities(Dictionary<string, object> dictionary)
	{
		Google2u.Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(dictionary["HighLevelGoldRarity"]);
		int num2 = Array.IndexOf(constants.rowNames, Google2u.Constants.rowIds.GoldCardRarity.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num.ToString(CultureInfo.InvariantCulture));
		}
		float num3 = Convert.ToSingle(dictionary["HighLevelSilverRarity"]);
		num2 = Array.IndexOf(constants.rowNames, Google2u.Constants.rowIds.SilverCardRarity.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num3.ToString(CultureInfo.InvariantCulture));
		}
		float num4 = Convert.ToSingle(dictionary["LowLevelGoldRarity"]);
		num2 = Array.IndexOf(constants.rowNames, Google2u.Constants.rowIds.GoldCardRarityEarly.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num4.ToString(CultureInfo.InvariantCulture));
		}
		float num5 = Convert.ToSingle(dictionary["LowLevelSilverRarity"]);
		num2 = Array.IndexOf(constants.rowNames, Google2u.Constants.rowIds.SilverCardRarityEarly.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num5.ToString(CultureInfo.InvariantCulture));
		}
		CardManager.LowLevelTreshold = Convert.ToInt32(dictionary["LowLevel"]);
		CardManager.HighLevelTreshold = Convert.ToInt32(dictionary["HighLevel"]);
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		if (!IsRewardVideoPreloaded())
		{
			FuseSDK.PreloadAdForZoneID(mZoneReward);
		}
	}

	private void OnDataLoaded()
	{
		FuseSDK.PreloadAdForZoneID(mZoneReward);
	}

	public bool IsRewardVideoPreloaded()
	{
		return FuseSDK.IsAdAvailableForZoneID(mZoneReward);
	}

	~FuseboxxService()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded -= OnDataLoaded;
		Singleton<GameController>.instance.GameEnded -= OnGameEnded;
		Singleton<BeanstalkServerManager>.instance.DataLoaded -= InstanceOnDataLoaded;
		FuseSDK.SessionStartReceived -= SessionStarted;
		FuseSDK.SessionLoginError -= SessionLoginError;
		FuseSDK.AdDeclined -= AdDeclined;
		FuseSDK.AdAvailabilityResponse -= AdAvailabilityResponse;
		FuseSDK.AdWillClose -= AdWillClose;
		FuseSDK.AdDidShow -= AdDidShow;
		FuseSDK.RewardedAdCompletedWithObject -= RewardedAdCompletedWithObject;
		FuseSDK.IAPOfferAcceptedWithObject -= IAPOfferAcceptedWithObject;
		FuseSDK.VirtualGoodsOfferAcceptedWithObject -= VirtualGoodsOfferAcceptedWithObject;
		FuseSDK.GameConfigurationReceived -= GameConfigurationReceived;
		FuseSDK.NotificationAction -= NotificationAction;
		FuseSDK.NotificationWillClose -= NotificationWillClose;
	}

	public void RegisterCurrency(Currency currency, long amount)
	{
		int balance = (int)((amount <= int.MaxValue) ? amount : int.MaxValue);
		FuseSDK.RegisterCurrency((int)currency, balance);
	}

	public void DeserializeSavedConfig(string configData)
	{
		if (string.IsNullOrEmpty(configData))
		{
			return;
		}
		configFromDb = new Dictionary<string, string>();
		object obj = JsonConvert.DeserializeObject(configData);
		if (!(obj is JObject jObject))
		{
			return;
		}
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			configFromDb.Add(item.Key, item.Value.ToString());
		}
	}

	private void NotificationWillClose()
	{
		Debug.Log("Fuseboxx: Notification will close");
	}

	private void NotificationAction(string obj)
	{
		Debug.Log("Fuseboxx: NotificationAction, " + obj);
	}

	internal Dictionary<string, object> GetStartingCurrency()
	{
		return GetJsonConfigurationValue("StartingCurrency");
	}

	internal string GetStarterPackDays()
	{
		return FuseSDK.GetGameConfigurationValue("StarterPackDays");
	}

	internal Dictionary<string, object> GetBattleWarbucksRewards()
	{
		return GetJsonConfigurationValue("BattleWarbucksRewards");
	}

	internal string GetPlayerProgressRate()
	{
		return FuseSDK.GetGameConfigurationValue("PlayerProgressRate");
	}

	public string GetFuseboxxConfigValue()
	{
		string gameConfigurationValue = FuseSDK.GetGameConfigurationValue("FuseboxxConfigValue");
		if (string.IsNullOrEmpty(gameConfigurationValue))
		{
			Debug.Log("Fuseboxx: Fuseboxx Config Value not found!");
			return null;
		}
		return gameConfigurationValue;
	}

	private Dictionary<string, object> GetJsonConfigurationValue(string key)
	{
		try
		{
			string gameConfigurationValue = FuseSDK.GetGameConfigurationValue(key);
			if (string.IsNullOrEmpty(gameConfigurationValue))
			{
				Debug.Log("Fuseboxx: Error No " + key + " found!");
				return null;
			}
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(gameConfigurationValue);
			if (dictionary == null)
			{
				Debug.Log("Fuseboxx: Error No " + key + " found!");
				return null;
			}
			return dictionary;
		}
		catch (Exception ex)
		{
			Debug.LogError("Fuseboxx: Error json for key " + key + ", exception = " + ex.Message);
			return null;
		}
	}

	private string PrepareConfigurationString()
	{
		Dictionary<string, string> gameConfiguration = FuseSDK.GetGameConfiguration();
		if (gameConfiguration != null && gameConfiguration.Count > 0)
		{
			return JsonConvert.SerializeObject(gameConfiguration);
		}
		return "{}";
	}

	private void GameConfigurationReceived()
	{
		Debug.Log("Fuseboxx: Game configuration received after time " + (Time.time - mInitTime));
		mHaveAnyConfigurationDownloaded = true;
		mNeedSaveConfigs = !mCanSaveConfigs;
		if (mCanSaveConfigs)
		{
			Singleton<BeanstalkServerManager>.instance.SendFuseboxConfigurations(PrepareConfigurationString());
		}
	}

	private void VirtualGoodsOfferAcceptedWithObject(VGOfferInfo obj)
	{
		Debug.Log("Fuseboxx: virtual goods offer accepted wtih object " + obj.ItemName + ", " + obj.ItemAmount + " , " + obj.PurchaseCurrency + " , " + obj.PurchasePrice);
	}

	private void IAPOfferAcceptedWithObject(IAPOfferInfo obj)
	{
		Debug.Log("Fuseboxx: iap offer accepted with object " + obj.ItemName + ", " + obj.ItemAmount + " , " + obj.ProductPrice + " , " + obj.ProductId);
	}

	private void RewardedAdCompletedWithObject(RewardedInfo obj)
	{
		Debug.Log("FuseBoxx: Reward ad completed");
		Singleton<EventTrackingManager>.instance.SetLastShowedTimeForAdtype(mReward);
		if (mReward != RewardType.None)
		{
			Singleton<BeanstalkServerManager>.instance.AddVideoReward(mReward);
		}
		switch (mReward)
		{
		case RewardType.LootBox:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Lootbox", completed: true);
			break;
		case RewardType.Dogtag:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("DogTags", completed: true);
			break;
		case RewardType.RandomCard:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("WarCards", completed: true);
			break;
		case RewardType.GoldenSuitcase:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Golden_Suitcase", completed: true);
			break;
		}
		mReward = RewardType.None;
		Singleton<EventTrackingManager>.instance.RegisterWatchAd("WarCards", completed: true);
	}

	private void AdDeclined()
	{
		switch (mReward)
		{
		case RewardType.Dogtag:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("DogTags", completed: false);
			break;
		case RewardType.GoldenSuitcase:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Golden_Suitcase", completed: false);
			break;
		case RewardType.LootBox:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Lootbox", completed: false);
			break;
		case RewardType.RandomCard:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("WarCards", completed: false);
			break;
		}
		mReward = RewardType.None;
	}

	private void SessionLoginError(FuseError errorCode)
	{
		Debug.Log("FuseBoxx: Session Login Error, code = " + errorCode);
	}

	private void AdWillClose()
	{
		Debug.Log("FuseBoxx: Ad Will Close");
		FuseSDK.PreloadAdForZoneID(mZoneReward);
		SoundsManager.Instance.EnableMusic();
		mIsVideoPlaying = false;
		if (this.RewardVideoPreloaded != null)
		{
			this.RewardVideoPreloaded();
		}
	}

	private void AdDidShow(int networkId, int mediaType)
	{
		Debug.LogWarningFormat("Fuseboxx: Add Did Show networkId: {0} mediaType: {1}", networkId, mediaType);
	}

	private void AdAvailabilityResponse(bool isAdAvailable, FuseError fuseError)
	{
		Debug.Log("FuseBoxx: Ad Availability Response, isAdAvailable = " + isAdAvailable + ", hasError = " + fuseError);
		if (isAdAvailable && this.RewardVideoPreloaded != null)
		{
			this.RewardVideoPreloaded();
		}
		if (fuseError == FuseError.INVALID_REQUEST && this.AdvertisementVideoRewardError != null)
		{
			this.AdvertisementVideoRewardError();
		}
	}

	public void RegisterEvent(string eventName, string parameterName, string parameterValue, Hashtable table)
	{
		bool flag = FuseSDK.RegisterEvent(eventName, parameterName, parameterValue, table);
	}

	public void RegisterCustomEvent(int eventId, string value)
	{
		bool flag = FuseSDK.RegisterCustomEvent(eventId, value);
		Debug.LogError("Fuseboxx Custom Event with params: " + eventId + ", val = " + value);
	}

	public void RegisterCustomEvent(int eventId, int value)
	{
		FuseSDK.RegisterCustomEvent(eventId, value);
	}

	internal void ShowAd(string adZone)
	{
	}

	private void SessionStarted()
	{
		Debug.Log("FuseBoxx: Session Started");
	}

	internal void ShowRewardedVideo(RewardType reward)
	{
		SoundsManager.Instance.DisableMusic();
		mReward = reward;
		mIsVideoPlaying = true;
		FuseSDK.ShowAdForZoneID(mZoneReward);
	}

	public void testStuff()
	{
		Debug.Log("Fuseb oxx manager: TEsting stufff");
		Debug.Log("Display notifications");
		Debug.Log("SHOWING ADD FOR ZONE All");
		FuseSDK.ShowAdForZoneID(mZoneAll);
	}

	public void CheckOffer(bool show)
	{
		Debug.Log("Fuseboxx: Show offer for zone " + mZoneOffer + " show " + show);
		if (FuseSDK.ZoneHasVirtualGoodsOffer(mZoneOffer))
		{
			VGOfferInfo vGOfferInfoForZone = FuseSDK.GetVGOfferInfoForZone(mZoneOffer);
			Debug.Log("have virtual goods offer:\n" + vGOfferInfoForZone.ToString());
			Singleton<OfferManager>.instance.HaveOfferFormFusebox(vGOfferInfoForZone);
			if (show)
			{
				FuseSDK.ShowAdForZoneID(mZoneOffer);
			}
		}
		else
		{
			Debug.Log("ZoneHasVirtualGoodsOffer is false, preloading Ad.");
			FuseSDK.PreloadAdForZoneID(mZoneOffer);
		}
	}
}
