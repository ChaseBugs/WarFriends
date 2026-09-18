using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Beebyte.Obfuscator;
using FuseMisc;
using UnityEngine;

[Skip]
public class FuseSDK : MonoBehaviour
{
	private static AndroidJavaClass _fusePlugin;

	private static AndroidJavaClass _fuseUnityPlugin;

	private static bool __AdWillCloseCalled = true;

	public string AndroidAppID;

	public string iOSAppID;

	public bool StartAutomatically = true;

	public string GCM_SenderID = string.Empty;

	public bool registerForPushNotifications = true;

	public bool logging = true;

	public bool editorSessions;

	public bool standaloneSessions;

	public bool androidIAB;

	public bool androidUnibill;

	public bool iosStoreKit;

	public bool iosUnibill;

	public bool soomlaStore;

	private static bool _sessionStarted;

	private static FuseSDK _instance;

	private static Action<string> _adClickedwithURL;

	public static event Action SessionStartReceived;

	public static event Action<FuseError> SessionLoginError;

	public static event Action GameConfigurationReceived;

	public static event Action<AccountType, string> AccountLoginComplete;

	public static event Action<string, FuseError> AccountLoginError;

	public static event Action<string> NotificationAction;

	public static event Action NotificationWillClose;

	public static event Action<string, FuseError> FriendAdded;

	public static event Action<string, FuseError> FriendRemoved;

	public static event Action<string, FuseError> FriendAccepted;

	public static event Action<string, FuseError> FriendRejected;

	public static event Action<string, FuseError> FriendsMigrated;

	public static event Action<List<Friend>> FriendsListUpdated;

	public static event Action<FuseError> FriendsListError;

	public static event Action<int, string, string> PurchaseVerification;

	public static event Action<bool, FuseError> AdAvailabilityResponse;

	public static event Action AdWillClose;

	public static event Action AdFailedToDisplay;

	public static event Action<int, int> AdDidShow;

	public static event Action<RewardedInfo> RewardedAdCompletedWithObject;

	public static event Action<IAPOfferInfo> IAPOfferAcceptedWithObject;

	public static event Action<VGOfferInfo> VirtualGoodsOfferAcceptedWithObject;

	public static event Action AdDeclined;

	public static event Action<DateTime> TimeUpdated;

	[Obsolete("Game data is deprecated and will be removed from future releases.")]
	public static event Action<int, FuseError> GameDataError;

	[Obsolete("Game data is deprecated and will be removed from future releases.")]
	public static event Action<int> GameDataSetAcknowledged;

	[Obsolete("Game data is deprecated and will be removed from future releases.")]
	public static event Action<int, string, string, Dictionary<string, string>> GameDataReceived;

	private void Awake()
	{
		GameObject gameObject = GameObject.Find("FuseSDK");
		if (gameObject != null && gameObject != base.gameObject && gameObject.GetComponent<FuseSDK>() != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		_instance = this;
		if (androidIAB && !GetComponent<FuseSDK_Prime31_IAB>())
		{
			base.gameObject.AddComponent<FuseSDK_Prime31_IAB>().logging = logging;
		}
		if (androidUnibill && !GetComponent<FuseSDK_Unibill_Android>())
		{
			base.gameObject.AddComponent<FuseSDK_Unibill_Android>().logging = logging;
		}
		_fuseUnityPlugin = new AndroidJavaClass("com.upsight.mediation.unity.FuseUnitySDK");
		FuseLog("FuseUnityPlugin " + ((_fuseUnityPlugin != null) ? "FOUND" : "NOT FOUND"));
		FuseLog("Callback object is: " + base.gameObject.name);
		_fuseUnityPlugin.CallStatic("SetGameObjectCallback", base.gameObject.name);
	}

	private void Start()
	{
		if (!string.IsNullOrEmpty(AndroidAppID) && StartAutomatically)
		{
			_StartSession(AndroidAppID, handleAdURLs: false);
		}
	}

	private void OnApplicationPause(bool pausing)
	{
		if (_fuseUnityPlugin != null)
		{
			if (pausing)
			{
				_fuseUnityPlugin.CallStatic("onPause");
				return;
			}
			_instance.StartCoroutine(__WaitForAdWillClose(0.5f));
			_fuseUnityPlugin.CallStatic("onResume");
		}
	}

	private void OnDestroy()
	{
		if (_fuseUnityPlugin != null && _instance == this)
		{
			_fuseUnityPlugin.CallStatic("onDestroy");
		}
	}

	public static void StartSession()
	{
		if (_instance != null)
		{
			_StartSession(_instance.AndroidAppID, handleAdURLs: false);
		}
		else
		{
			Debug.LogError("FuseSDK instance not initialized. Awake may not have been called.");
		}
	}

	private static void _StartSession(string gameId, bool handleAdURLs)
	{
		if (_sessionStarted)
		{
			Debug.LogWarning("FuseSDK: Duplicate StartSession call. Ignoring.");
			return;
		}
		if (string.IsNullOrEmpty(gameId))
		{
			Debug.LogError("FuseSDK: Null or empty App ID. Make sure your App ID is entered in the FuseSDK prefab");
			return;
		}
		_sessionStarted = true;
		FuseLog("StartSession(" + gameId + ")");
		_fuseUnityPlugin.CallStatic("startSession", gameId, handleAdURLs);
	}

	[Obsolete("Registering events is deprecated and will be removed from future releases.")]
	public static bool RegisterEvent(string name, Dictionary<string, string> parameters)
	{
		FuseLog("RegisterEvent(" + name + ", [parameters])");
		if (parameters == null)
		{
			return RegisterEvent(name, null, null, null, 0.0);
		}
		bool flag = true;
		foreach (KeyValuePair<string, string> parameter in parameters)
		{
			flag &= RegisterEvent(name, parameter.Key, parameter.Value, null, 0.0);
		}
		return flag;
	}

	[Obsolete("Registering events is deprecated and will be removed from future releases.")]
	public static bool RegisterEvent(string name, string paramName, string paramValue, Hashtable variables)
	{
		FuseLog("RegisterEvent(" + name + "," + paramName + "," + paramValue + ", [variables])");
		if (variables == null)
		{
			return RegisterEvent(name, paramName, paramValue, null, 0.0);
		}
		try
		{
			string[] array = variables.Keys.Cast<string>().ToArray();
			double[] array2 = (from object o in variables.Values
				select Convert.ToDouble(o)).ToArray();
			return _fuseUnityPlugin.CallStatic<bool>("registerEvent", new object[5] { name, paramName, paramValue, array, array2 });
		}
		catch (Exception exception)
		{
			Debug.LogError("FuseSDK: Error parsing hashtable in RegisterEvent. Operation failed.");
			Debug.LogException(exception);
			return false;
		}
	}

	[Obsolete("Registering events is deprecated and will be removed from future releases.")]
	public static bool RegisterEvent(string name, string paramName, string paramValue, string variableName, double variableValue)
	{
		FuseLog("RegisterEvent(" + name + "," + paramName + "," + paramValue + "," + variableName + "," + variableValue + ")");
		return _fuseUnityPlugin.CallStatic<bool>("registerEvent", new object[5] { name, paramName, paramValue, variableName, variableValue });
	}

	public static void RegisterVirtualGoodsPurchase(int virtualgoodID, int currencyAmount, int currencyID)
	{
		_fuseUnityPlugin.CallStatic("registerVirtualGoodsPurchase", virtualgoodID, currencyAmount, currencyID);
	}

	public static void RegisterAndroidInAppPurchase(IAPState purchaseState, string purchaseToken, string productId, string orderId, DateTime purchaseTime, string developerPayload, double price, string currency)
	{
		RegisterAndroidInAppPurchase(purchaseState, purchaseToken, productId, orderId, purchaseTime.ToUnixTimestamp(), developerPayload, price, currency);
	}

	public static void RegisterAndroidInAppPurchase(IAPState purchaseState, string purchaseToken, string productId, string orderId, long purchaseTime, string developerPayload, double price, string currency)
	{
		FuseLog("RegisterInAppPurchase(" + purchaseState.ToString() + "," + purchaseToken + "," + productId + "," + orderId + "," + purchaseTime + "," + developerPayload + "," + price + "," + currency + ")");
		_fuseUnityPlugin.CallStatic("registerInAppPurchase", purchaseState.ToString(), purchaseToken, productId, orderId, purchaseTime, developerPayload, (float)price, currency);
	}

	public static void RegisterIOSInAppPurchaseList(Product[] products)
	{
	}

	public static void RegisterIOSInAppPurchase(string productId, string transactionId, byte[] transactionReceipt, IAPState transactionState)
	{
	}

	public static void RegisterUnibillPurchase(string productID, byte[] receipt)
	{
	}

	public static bool IsAdAvailableForZoneID(string zoneId)
	{
		FuseLog("IsAdAvailableForZoneID");
		return _fuseUnityPlugin.CallStatic<bool>("isAdAvailableForZoneID", new object[1] { zoneId });
	}

	public static bool ZoneHasRewarded(string zoneId)
	{
		FuseLog("ZoneHasRewarded");
		return _fuseUnityPlugin.CallStatic<bool>("zoneHasRewarded", new object[1] { zoneId });
	}

	public static bool ZoneHasIAPOffer(string zoneId)
	{
		FuseLog("ZoneHasIAPOffer");
		return _fuseUnityPlugin.CallStatic<bool>("zoneHasIAPOffer", new object[1] { zoneId });
	}

	public static bool ZoneHasVirtualGoodsOffer(string zoneId)
	{
		FuseLog("ZoneHasVirtualGoodsOffer");
		return _fuseUnityPlugin.CallStatic<bool>("zoneHasVirtualGoodsOffer", new object[1] { zoneId });
	}

	public static RewardedInfo GetRewardedInfoForZone(string zoneId)
	{
		FuseLog("GetRewardedInfoForZoneID");
		string infoString = _fuseUnityPlugin.CallStatic<string>("getRewardedInfoForZoneID", new object[1] { zoneId });
		return new RewardedInfo(infoString);
	}

	public static VGOfferInfo GetVGOfferInfoForZone(string zoneId)
	{
		FuseLog("GetVGOfferInfoForZone");
		string infoString = _fuseUnityPlugin.CallStatic<string>("getVirtualGoodsOfferInfoForZoneID", new object[1] { zoneId });
		return new VGOfferInfo(infoString);
	}

	public static IAPOfferInfo GetIAPOfferInfoForZone(string zoneId)
	{
		FuseLog("GetIAPOfferInfoForZone");
		string infoString = _fuseUnityPlugin.CallStatic<string>("getIAPOfferInfoForZoneID", new object[1] { zoneId });
		return new IAPOfferInfo(infoString);
	}

	public static void ShowAdForZoneID(string zoneId, Dictionary<string, string> options = null)
	{
		FuseSDK.AdWillClose = (Action)Delegate.Combine(FuseSDK.AdWillClose, new Action(__AdWillCloseMoneybackGuaranteeR));
		__AdWillCloseCalled = false;
		FuseLog("ShowAdForZoneID");
		string[] array = ((options != null) ? options.Keys.ToArray() : new string[0]);
		string[] array2 = ((options != null) ? options.Values.ToArray() : new string[0]);
		_fuseUnityPlugin.CallStatic("showAdForZoneID", zoneId, array, array2);
	}

	public static void PreloadAdForZoneID(string zoneId)
	{
		FuseLog("PreloadAdForZoneID");
		_fuseUnityPlugin.CallStatic("preloadAdForZoneID", zoneId);
	}

	public static void SetRewardedVideoUserID(string userID)
	{
		FuseLog("SetRewardedVideoUserID");
		_fuseUnityPlugin.CallStatic("setRewardedVideoUserID", userID);
	}

	public static void DisplayNotifications()
	{
		FuseLog("DisplayNotifications()");
		_fuseUnityPlugin.CallStatic("displayNotifications");
	}

	public static bool IsNotificationAvailable()
	{
		FuseLog("IsNotificationAvailable()");
		return _fuseUnityPlugin.CallStatic<bool>("isNotificationAvailable", new object[0]);
	}

	public static void RegisterGender(Gender gender)
	{
		FuseLog("RegisterGender()");
		_fuseUnityPlugin.CallStatic("registerGender", (int)gender);
	}

	public static void RegisterAge(int age)
	{
		FuseLog("RegisterAge()");
		_fuseUnityPlugin.CallStatic("registerAge", age);
	}

	public static void RegisterBirthday(int year, int month, int day)
	{
		FuseLog("RegisterBirthday()");
		_fuseUnityPlugin.CallStatic("registerBirthday", year, month, day);
	}

	public static void RegisterLevel(int level)
	{
		FuseLog("RegisterLevel()");
		_fuseUnityPlugin.CallStatic("registerLevel", level);
	}

	public static bool RegisterCurrency(int currencyType, int balance)
	{
		FuseLog("RegisterCurrency()");
		return _fuseUnityPlugin.CallStatic<bool>("registerCurrency", new object[2] { currencyType, balance });
	}

	public static void RegisterParentalConsent(bool consentGranted)
	{
		FuseLog("RegisterParentalConsent()");
		_fuseUnityPlugin.CallStatic("registerParentalConsent", consentGranted);
	}

	public static bool RegisterCustomEvent(int eventNumber, string value)
	{
		FuseLog("RegisterCustomEvent()");
		return _fuseUnityPlugin.CallStatic<bool>("registerCustomEventString", new object[2] { eventNumber, value });
	}

	public static bool RegisterCustomEvent(int eventNumber, int value)
	{
		FuseLog("RegisterCustomEvent()");
		return _fuseUnityPlugin.CallStatic<bool>("registerCustomEventInt", new object[2] { eventNumber, value });
	}

	public static string GetFuseId()
	{
		FuseLog("GetFuseId()");
		return _fuseUnityPlugin.CallStatic<string>("getFuseID", new object[0]);
	}

	public static string GetOriginalAccountAlias()
	{
		FuseLog("GetOriginalAccountAlias()");
		return _fuseUnityPlugin.CallStatic<string>("getOriginalAccountAlias", new object[0]);
	}

	public static string GetOriginalAccountId()
	{
		FuseLog("GetOriginalAccountId()");
		return _fuseUnityPlugin.CallStatic<string>("getOriginalAccountId", new object[0]);
	}

	public static AccountType GetOriginalAccountType()
	{
		FuseLog("GetOriginalAccountType()");
		return (AccountType)_fuseUnityPlugin.CallStatic<int>("getOriginalAccountType", new object[0]);
	}

	public static void GameCenterLogin()
	{
	}

	public static void FacebookLogin(string facebookId, string name, string accessToken)
	{
		FuseLog("FacebookLogin(" + facebookId + "," + name + "," + accessToken + ")");
		_fuseUnityPlugin.CallStatic("facebookLogin", facebookId, name, accessToken);
	}

	public static void TwitterLogin(string twitterId, string alias)
	{
		FuseLog("TwitterLogin(" + twitterId + ")");
		_fuseUnityPlugin.CallStatic("twitterLogin", twitterId, alias);
	}

	public static void FuseLogin(string fuseId, string alias)
	{
		FuseLog("FuseLogin(" + fuseId + "," + alias + ")");
		_fuseUnityPlugin.CallStatic("fuseLogin", fuseId, alias);
	}

	public static void EmailLogin(string email, string alias)
	{
		FuseLog("EmailLogin(" + alias + ")");
		_fuseUnityPlugin.CallStatic("deviceLogin", alias);
	}

	public static void DeviceLogin(string alias)
	{
		FuseLog("DeviceLogin(" + alias + ")");
		_fuseUnityPlugin.CallStatic("deviceLogin", alias);
	}

	public static void GooglePlayLogin(string alias, string token)
	{
		FuseLog("GooglePlayLogin(" + alias + "," + token + ")");
		_fuseUnityPlugin.CallStatic("googlePlayLogin", alias, token);
	}

	public static void ManualRegisterForPushNotifications(string gcmSenderID)
	{
		if (_instance != null && !_instance.registerForPushNotifications && !string.IsNullOrEmpty(gcmSenderID))
		{
			FuseLog("ManualRegisterForPushNotifications(" + gcmSenderID + ")");
			_fuseUnityPlugin.CallStatic("registerForPushNotifications", gcmSenderID);
		}
	}

	public static int GamesPlayed()
	{
		FuseLog("GamesPlayed()");
		return _fuseUnityPlugin.CallStatic<int>("gamesPlayed", new object[0]);
	}

	public static string LibraryVersion()
	{
		FuseLog("LibraryVersion()");
		return _fuseUnityPlugin.CallStatic<string>("libraryVersion", new object[0]);
	}

	public static bool Connected()
	{
		FuseLog("Connected()");
		return _fuseUnityPlugin.CallStatic<bool>("connected", new object[0]);
	}

	public static void UTCTimeFromServer()
	{
		FuseLog("TimeFromServer()");
		_fuseUnityPlugin.CallStatic("utcTimeFromServer");
	}

	public static void FuseLog(string str)
	{
		if (_instance != null && _instance.logging)
		{
			Debug.Log("FuseSDK: " + str);
		}
	}

	public static void EnableData()
	{
		FuseLog("EnableData()");
		_fuseUnityPlugin.CallStatic("enableData");
	}

	public static void DisableData()
	{
		FuseLog("DisableData()");
		_fuseUnityPlugin.CallStatic("disableData");
	}

	public static bool DataEnabled()
	{
		FuseLog("DataEnabled()");
		return _fuseUnityPlugin.CallStatic<bool>("dataEnabled", new object[0]);
	}

	public static void UpdateFriendsListFromServer()
	{
		FuseLog("UpdateFriendsListFromServer()");
		_fuseUnityPlugin.CallStatic("updateFriendsListFromServer");
	}

	public static List<Friend> GetFriendsList()
	{
		FuseLog("GetFriendsList()");
		return DeserializeFriendsList(_fuseUnityPlugin.CallStatic<string[]>("getFriendsList", new object[0]));
	}

	public static void AddFriend(string fuseId)
	{
		FuseLog("AddFriend(" + fuseId + ")");
		_fuseUnityPlugin.CallStatic("addFriend", fuseId);
	}

	public static void RemoveFriend(string fuseId)
	{
		FuseLog("RemoveFriend(" + fuseId + ")");
		_fuseUnityPlugin.CallStatic("removeFriend", fuseId);
	}

	public static void AcceptFriend(string fuseId)
	{
		FuseLog("AcceptFriend(" + fuseId + ")");
		_fuseUnityPlugin.CallStatic("acceptFriend", fuseId);
	}

	public static void RejectFriend(string fuseId)
	{
		FuseLog("RejectFriend(" + fuseId + ")");
		_fuseUnityPlugin.CallStatic("rejectFriend", fuseId);
	}

	public static void MigrateFriends(string fuseId)
	{
		FuseLog("MigrateFriends(" + fuseId + ")");
		_fuseUnityPlugin.CallStatic("migrateFriends", fuseId);
	}

	public static void UserPushNotification(string fuseId, string message)
	{
		FuseLog("UserPushNotification(" + fuseId + "," + message + ")");
		_fuseUnityPlugin.CallStatic("userPushNotification", fuseId, message);
	}

	public static void FriendsPushNotification(string message)
	{
		FuseLog("FriendsPushNotification(" + message + ")");
		_fuseUnityPlugin.CallStatic("friendsPushNotification", message);
	}

	public static string GetGameConfigurationValue(string key)
	{
		FuseLog("GetGameConfigurationValue(" + key + ")");
		return _fuseUnityPlugin.CallStatic<string>("getGameConfigurationValue", new object[1] { key });
	}

	public static Dictionary<string, string> GetGameConfiguration()
	{
		FuseLog("GetGameConfiguration()");
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int num = 100;
		int num2 = 0;
		AndroidJNI.AttachCurrentThread();
		AndroidJNI.PushLocalFrame(0);
		string[] array = _fuseUnityPlugin.CallStatic<string[]>("getGameConfigurationKeys", new object[2] { num2, num });
		while (array != null && array.Length > 0)
		{
			FuseLog("Getting gameConfig: Offset = " + num2 + ", keys.Length = " + array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				dictionary.Add(array[i], GetGameConfigurationValue(array[i]));
			}
			num2 += num;
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
			AndroidJNI.PushLocalFrame(0);
			array = _fuseUnityPlugin.CallStatic<string[]>("getGameConfigurationKeys", new object[2] { num2, num });
		}
		AndroidJNI.PopLocalFrame(IntPtr.Zero);
		FuseLog("Got " + dictionary.Count + " game config values");
		return dictionary;
	}

	[Obsolete("Game data is deprecated and will be removed from future releases.")]
	public static int SetGameData(Dictionary<string, string> data, string fuseId = "", string key = "")
	{
		FuseLog("SetGameData(" + key + ", [data]," + fuseId + ")");
		if (string.IsNullOrEmpty(fuseId))
		{
			fuseId = GetFuseId();
		}
		if (data == null)
		{
			data = new Dictionary<string, string>();
		}
		string[] array = data.Keys.ToArray();
		string[] array2 = data.Values.ToArray();
		return _fuseUnityPlugin.CallStatic<int>("setGameData", new object[4] { fuseId, key, array, array2 });
	}

	[Obsolete("Game data is deprecated and will be removed from future releases.")]
	public static int GetGameData(params string[] keys)
	{
		return GetGameDataForFuseId(string.Empty, string.Empty, keys);
	}

	[Obsolete("Game data is deprecated and will be removed from future releases.")]
	public static int GetGameDataForFuseId(string fuseId, string key, params string[] keys)
	{
		FuseLog("GetGameData(" + fuseId + "," + key + ",[keys])");
		return _fuseUnityPlugin.CallStatic<int>("getGameData", new object[3]
		{
			fuseId,
			key,
			(keys != null) ? keys : new string[0]
		});
	}

	private void _SessionStartReceived(string _)
	{
		FuseLog("SessionStartReceived()");
		if (registerForPushNotifications)
		{
			SetupPushNotifications(GCM_SenderID);
		}
		OnSessionStartReceived();
	}

	private void SetupPushNotifications(string gcmSenderID)
	{
		FuseLog("SetupPushNotifications(" + gcmSenderID + ")");
		_fuseUnityPlugin.CallStatic("registerForPushNotifications", gcmSenderID);
	}

	private void _SessionLoginError(string error)
	{
		FuseLog("SessionLoginError(" + error + ")");
		if (int.TryParse(error, out var result))
		{
			OnSessionLoginError(result);
		}
	}

	private void _PurchaseVerification(string param)
	{
		FuseLog("PurchaseVerification(" + param + ")");
		string[] array = param.Split(',');
		if (array.Length == 3 && int.TryParse(array[0], out var result))
		{
			OnPurchaseVerification(result, array[1], array[2]);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _PurchaseVerification");
		}
	}

	private void _AdAvailabilityResponse(string param)
	{
		FuseLog("AdAvailabilityResponse(" + param + ")");
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2))
		{
			OnAdAvailabilityResponse(result, result2);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _AdAvailabilityResponse");
		}
	}

	private void _AdWillClose(string _)
	{
		FuseLog("AdWillClose()");
		OnAdWillClose();
	}

	private void _AdFailedToDisplay(string _)
	{
		FuseLog("AdFailedToDisplay()");
		OnAdFailedToDisplay();
	}

	private void _AdDidShow(string param)
	{
		FuseLog("AdDidShow(" + param + ")");
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2))
		{
			OnAdDidShow(result, result2);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _AdDidShow");
		}
	}

	private void _RewardedAdCompleted(string param)
	{
		FuseLog("RewardedAdCompleted(" + param + ")");
		OnRewardedAdCompleted(new RewardedInfo(param));
	}

	private void _IAPOfferAccepted(string param)
	{
		FuseLog("IAPOfferAccepted(" + param + ")");
		OnIAPOfferAccepted(new IAPOfferInfo(param));
	}

	private void _VirtualGoodsOfferAccepted(string param)
	{
		FuseLog("VirtualGoodsOfferAccepted(" + param + ")");
		OnVirtualGoodsOfferAccepted(new VGOfferInfo(param));
	}

	private void _AdDeclined(string param)
	{
		FuseLog("AdDeclined(" + param + ")");
		OnAdDeclined();
	}

	private void _AdClickedWithURL(string url)
	{
		FuseLog("OnAdClickedWithURL()");
		OnAdClickedWithURL(url);
	}

	private void _NotificationAction(string action)
	{
		FuseLog("NotificationAction()");
		OnNotificationAction(action);
	}

	private void _NotificationWillClose(string _)
	{
		FuseLog("NotificationAction()");
		OnNotificationWillClose();
	}

	private void _AccountLoginComplete(string param)
	{
		FuseLog("AccountLoginComplete(" + param + ")");
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[0], out var result))
		{
			OnAccountLoginComplete(result, array[1]);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _AccountLoginComplete");
		}
	}

	private void _AccountLoginError(string param)
	{
		FuseLog("_AccountLoginError(" + param + ")");
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[1], out var result))
		{
			OnAccountLoginError(array[0], result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _AccountLoginError");
		}
	}

	private void _TimeUpdated(string timestamp)
	{
		FuseLog("TimeUpdated(" + timestamp + ")");
		if (long.TryParse(timestamp, out var result))
		{
			OnTimeUpdated(result.ToDateTime());
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _TimeUpdated");
		}
	}

	private void _FriendAdded(string param)
	{
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[1], out var result))
		{
			OnFriendAdded(array[0], result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _FriendAdded");
		}
	}

	private void _FriendRemoved(string param)
	{
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[1], out var result))
		{
			OnFriendRemoved(array[0], result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _FriendAdded");
		}
	}

	private void _FriendAccepted(string param)
	{
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[1], out var result))
		{
			OnFriendAccepted(array[0], result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _FriendAdded");
		}
	}

	private void _FriendRejected(string param)
	{
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[1], out var result))
		{
			OnFriendRejected(array[0], result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _FriendAdded");
		}
	}

	private void _FriendsMigrated(string param)
	{
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[1], out var result))
		{
			OnFriendsMigrated(array[0], result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _FriendsMigrated");
		}
	}

	private static List<Friend> DeserializeFriendsList(string[] friendList)
	{
		List<Friend> list = new List<Friend>();
		if (friendList == null)
		{
			Debug.LogWarning("FuseSDK: NULL FriendsList.");
			return list;
		}
		foreach (string text in friendList)
		{
			string[] array = text.Split(',');
			if (array.Length == 4)
			{
				list.Add(new Friend
				{
					FuseId = array[0],
					AccountId = array[1],
					Alias = array[2],
					Pending = (array[3] != "0")
				});
			}
			else
			{
				Debug.LogError("FuseSDK: Error reading FriendsList data. Invalid line: " + text);
			}
		}
		return list;
	}

	private void _FriendsListUpdated(string _)
	{
		FuseLog("FriendsListUpdated()");
		OnFriendsListUpdated(GetFriendsList());
	}

	private void _FriendsListError(string error)
	{
		FuseLog("FriendsListError(" + error + ")");
		if (int.TryParse(error, out var result))
		{
			OnFriendsListError(result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _FriendsListError");
		}
	}

	private void _GameConfigurationReceived(string _)
	{
		FuseLog("GameConfigurationReceived()");
		OnGameConfigurationReceived();
	}

	private void _GameDataSetAcknowledged(string requestId)
	{
		FuseLog("GameDataSetAcknowledged(" + requestId + ")");
		if (int.TryParse(requestId, out var result))
		{
			OnGameDataSetAcknowledged(result);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _GameDataSetAcknowledged");
		}
	}

	private void _GameDataError(string param)
	{
		FuseLog("GameDataError(" + param + ")");
		string[] array = param.Split(',');
		if (array.Length == 2 && int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2))
		{
			OnGameDataError(result, result2);
		}
		else
		{
			Debug.LogError("FuseSDK: Parsing error in _GameDataError");
		}
	}

	private void _GameDataReceived(string param)
	{
		FuseLog("GameDataReceived(" + param + ")");
		int result = -1;
		string fuseId = string.Empty;
		string[] array = param.Split(',');
		if (array.Length == 2)
		{
			fuseId = array[1];
			if (!int.TryParse(array[0], out result))
			{
				Debug.LogError("FuseSDK: Parsing error in _GameDataReceived");
			}
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int num = 100;
		int num2 = 0;
		AndroidJNI.AttachCurrentThread();
		AndroidJNI.PushLocalFrame(0);
		string[] array2 = _fuseUnityPlugin.CallStatic<string[]>("getGameDataKeys", new object[2] { num2, num });
		while (array2 != null && array2.Length > 0)
		{
			FuseLog("Getting gameData: Offset = " + num2 + ", keys.Length = " + array2.Length);
			for (int i = 0; i < array2.Length; i++)
			{
				dictionary.Add(array2[i], _fuseUnityPlugin.CallStatic<string>("getGameDataKey", new object[1] { array2[i] }));
			}
			num2 += num;
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
			AndroidJNI.PushLocalFrame(0);
			array2 = _fuseUnityPlugin.CallStatic<string[]>("getGameDataKeys", new object[2] { num2, num });
		}
		AndroidJNI.PopLocalFrame(IntPtr.Zero);
		FuseLog("Got " + dictionary.Count + " game data values");
		OnGameDataReceived(fuseId, string.Empty, dictionary, result);
	}

	private static void __AdWillCloseMoneybackGuaranteeR()
	{
		__AdWillCloseCalled = true;
		FuseSDK.AdWillClose = (Action)Delegate.Remove(FuseSDK.AdWillClose, new Action(__AdWillCloseMoneybackGuaranteeR));
	}

	private IEnumerator __WaitForAdWillClose(float timeout)
	{
		if (!__AdWillCloseCalled)
		{
			yield return new WaitForSeconds(timeout);
			if (!__AdWillCloseCalled)
			{
				FuseSDK.AdWillClose = (Action)Delegate.Remove(FuseSDK.AdWillClose, new Action(__AdWillCloseMoneybackGuaranteeR));
				OnAdWillClose();
				__AdWillCloseCalled = true;
			}
		}
	}

	public static void Internal_StartSession(string appID, string gcmSenderID = null)
	{
		GameObject gameObject;
		FuseSDK component;
		if (!string.IsNullOrEmpty(gcmSenderID) && (gameObject = GameObject.Find("FuseSDK")) != null && (component = gameObject.GetComponent<FuseSDK>()) != null)
		{
			component.GCM_SenderID = gcmSenderID;
		}
		_StartSession(appID, handleAdURLs: false);
	}

	public static void StartSession(Action<string> adClickedWithURLHandler)
	{
		if (_instance != null)
		{
			_adClickedwithURL = adClickedWithURLHandler;
			_StartSession(_instance.AndroidAppID, handleAdURLs: true);
		}
		else
		{
			Debug.LogError("FuseSDK instance not initialized. Awake may not have been called.");
		}
	}

	private static void OnSessionStartReceived()
	{
		if (FuseSDK.SessionStartReceived != null)
		{
			FuseSDK.SessionStartReceived();
		}
	}

	private static void OnSessionLoginError(int error)
	{
		if (FuseSDK.SessionLoginError != null)
		{
			FuseSDK.SessionLoginError((error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnPurchaseVerification(int verified, string transactionId, string originalTransactionId)
	{
		if (FuseSDK.PurchaseVerification != null)
		{
			FuseSDK.PurchaseVerification(verified, transactionId, originalTransactionId);
		}
	}

	private static void OnAdAvailabilityResponse(int available, int error)
	{
		if (FuseSDK.AdAvailabilityResponse != null)
		{
			FuseSDK.AdAvailabilityResponse(available != 0, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnAdWillClose()
	{
		if (FuseSDK.AdWillClose != null)
		{
			FuseSDK.AdWillClose();
		}
	}

	private static void OnAdFailedToDisplay()
	{
		if (FuseSDK.AdFailedToDisplay != null)
		{
			FuseSDK.AdFailedToDisplay();
		}
	}

	private static void OnAdDidShow(int networkId, int mediaType)
	{
		if (FuseSDK.AdDidShow != null)
		{
			FuseSDK.AdDidShow(networkId, mediaType);
		}
	}

	private static void OnRewardedAdCompleted(RewardedInfo rewardInfo)
	{
		if (FuseSDK.RewardedAdCompletedWithObject != null)
		{
			FuseSDK.RewardedAdCompletedWithObject(rewardInfo);
		}
	}

	private static void OnIAPOfferAccepted(IAPOfferInfo offerInfo)
	{
		if (FuseSDK.IAPOfferAcceptedWithObject != null)
		{
			FuseSDK.IAPOfferAcceptedWithObject(offerInfo);
		}
	}

	private static void OnVirtualGoodsOfferAccepted(VGOfferInfo offerInfo)
	{
		if (FuseSDK.VirtualGoodsOfferAcceptedWithObject != null)
		{
			FuseSDK.VirtualGoodsOfferAcceptedWithObject(offerInfo);
		}
	}

	private static void OnAdDeclined()
	{
		if (FuseSDK.AdDeclined != null)
		{
			FuseSDK.AdDeclined();
		}
	}

	private static void OnAdClickedWithURL(string url)
	{
		if (_adClickedwithURL != null)
		{
			_adClickedwithURL(url);
		}
	}

	private static void OnNotificationAction(string action)
	{
		if (FuseSDK.NotificationAction != null)
		{
			FuseSDK.NotificationAction(action);
		}
	}

	private static void OnNotificationWillClose()
	{
		if (FuseSDK.NotificationWillClose != null)
		{
			FuseSDK.NotificationWillClose();
		}
	}

	private static void OnAccountLoginComplete(int type, string accountId)
	{
		if (FuseSDK.AccountLoginComplete != null)
		{
			FuseSDK.AccountLoginComplete((AccountType)type, accountId);
		}
	}

	private static void OnAccountLoginError(string accountId, int error)
	{
		if (FuseSDK.AccountLoginError != null)
		{
			FuseSDK.AccountLoginError(accountId, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnTimeUpdated(DateTime time)
	{
		if (FuseSDK.TimeUpdated != null)
		{
			FuseSDK.TimeUpdated(time);
		}
	}

	private static void OnFriendAdded(string fuseId, int error)
	{
		if (FuseSDK.FriendAdded != null)
		{
			FuseSDK.FriendAdded(fuseId, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnFriendRemoved(string fuseId, int error)
	{
		if (FuseSDK.FriendRemoved != null)
		{
			FuseSDK.FriendRemoved(fuseId, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnFriendAccepted(string fuseId, int error)
	{
		if (FuseSDK.FriendAccepted != null)
		{
			FuseSDK.FriendAccepted(fuseId, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnFriendRejected(string fuseId, int error)
	{
		if (FuseSDK.FriendRejected != null)
		{
			FuseSDK.FriendRejected(fuseId, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnFriendsMigrated(string fuseId, int error)
	{
		if (FuseSDK.FriendsMigrated != null)
		{
			FuseSDK.FriendsMigrated(fuseId, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnFriendsListUpdated(List<Friend> friends)
	{
		if (FuseSDK.FriendsListUpdated != null)
		{
			FuseSDK.FriendsListUpdated(friends);
		}
	}

	private static void OnFriendsListError(int error)
	{
		if (FuseSDK.FriendsListError != null)
		{
			FuseSDK.FriendsListError((error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnGameConfigurationReceived()
	{
		if (FuseSDK.GameConfigurationReceived != null)
		{
			FuseSDK.GameConfigurationReceived();
		}
	}

	private static void OnGameDataError(int error, int requestId)
	{
		if (FuseSDK.GameDataError != null)
		{
			FuseSDK.GameDataError(requestId, (error >= 7) ? FuseError.UNDEFINED : ((FuseError)error));
		}
	}

	private static void OnGameDataSetAcknowledged(int requestId)
	{
		if (FuseSDK.GameDataSetAcknowledged != null)
		{
			FuseSDK.GameDataSetAcknowledged(requestId);
		}
	}

	private static void OnGameDataReceived(string fuseId, string dataKey, Dictionary<string, string> data, int requestId)
	{
		if (FuseSDK.GameDataReceived != null)
		{
			FuseSDK.GameDataReceived(requestId, fuseId, dataKey, data);
		}
	}
}
