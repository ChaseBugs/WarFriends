using System;
using System.Collections.Generic;
using FuseMisc;

public class FuseSDKEditorSession
{
	public static event Action SessionStartReceived;

	public static event Action<FuseError> SessionLoginError;

	public static event Action GameConfigurationReceived;

	public static event Action<AccountType, string> AccountLoginComplete;

	public static event Action<string, string> AccountLoginError;

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

	static FuseSDKEditorSession()
	{
		FuseSDKEditorSession.SessionStartReceived = delegate
		{
		};
		FuseSDKEditorSession.SessionLoginError = delegate
		{
		};
		FuseSDKEditorSession.GameConfigurationReceived = delegate
		{
		};
	}

	public static void StartSession(string gameID)
	{
	}

	public static void RegisterAndroidInAppPurchase(IAPState purchaseState, string purchaseToken, string productId, string orderId, DateTime purchaseTime, string developerPayload, double price, string currency)
	{
	}

	public static void RegisterVirtualGoodsPurchase(int virtualgoodID, int currencyAmount, int currencyID)
	{
	}

	public static bool IsAdAvailableForZoneID(string zoneId)
	{
		return false;
	}

	public static bool ZoneHasRewarded(string zoneId)
	{
		return false;
	}

	public static bool ZoneHasIAPOffer(string zoneId)
	{
		return false;
	}

	public static bool ZoneHasVirtualGoodsOffer(string zoneId)
	{
		return false;
	}

	public static RewardedInfo GetRewardedInfoForZone(string zonId)
	{
		return default(RewardedInfo);
	}

	public static VGOfferInfo GetVGOfferInfoForZone(string zonId)
	{
		return default(VGOfferInfo);
	}

	public static IAPOfferInfo GetIAPOfferInfoForZone(string zonId)
	{
		return default(IAPOfferInfo);
	}

	public static void ShowAdForZoneID(string zoneId, Dictionary<string, string> options = null)
	{
	}

	public static void PreloadAdForZoneID(string zoneId)
	{
	}

	public static void DisplayMoreGames()
	{
	}

	public static void SetRewardedVideoUserID(string userID)
	{
	}

	public static void DisplayNotifications()
	{
	}

	public static bool IsNotificationAvailable()
	{
		return false;
	}

	public static void RegisterGender(Gender gender)
	{
	}

	public static void RegisterAge(int age)
	{
	}

	public static void RegisterBirthday(int year, int month, int day)
	{
	}

	public static void RegisterLevel(int level)
	{
	}

	public static bool RegisterCurrency(int currencyType, int balance)
	{
		return false;
	}

	public static void RegisterParentalConsent(bool consentGranted)
	{
	}

	public static bool RegisterCustomEvent(int eventNumber, string value)
	{
		return false;
	}

	public static bool RegisterCustomEvent(int eventNumber, int value)
	{
		return false;
	}

	public static string GetFuseId()
	{
		return string.Empty;
	}

	public static string GetOriginalAccountAlias()
	{
		return string.Empty;
	}

	public static string GetOriginalAccountId()
	{
		return string.Empty;
	}

	public static FuseMisc.AccountType GetOriginalAccountType()
	{
		return FuseMisc.AccountType.NONE;
	}

	public static void GameCenterLogin()
	{
	}

	public static void FacebookLogin(string facebookId, string name, string accessToken)
	{
	}

	public static void TwitterLogin(string twitterId, string alias)
	{
	}

	public static void FuseLogin(string fuseId, string alias)
	{
	}

	public static void EmailLogin(string email, string alias)
	{
	}

	public static void DeviceLogin(string alias)
	{
	}

	public static void GooglePlayLogin(string alias, string token)
	{
	}

	public static int GamesPlayed()
	{
		return -1;
	}

	public static string LibraryVersion()
	{
		return string.Empty;
	}

	public static bool Connected()
	{
		return false;
	}

	public static void UTCTimeFromServer()
	{
	}

	public static void FuseLog(string str)
	{
	}

	public static void EnableData()
	{
	}

	public static void DisableData()
	{
	}

	public static bool DataEnabled()
	{
		return false;
	}

	public static void UpdateFriendsListFromServer()
	{
	}

	public static List<Friend> GetFriendsList()
	{
		return null;
	}

	public static void AddFriend(string fuseId)
	{
	}

	public static void RemoveFriend(string fuseId)
	{
	}

	public static void AcceptFriend(string fuseId)
	{
	}

	public static void RejectFriend(string fuseId)
	{
	}

	public static void MigrateFriends(string fuseId)
	{
	}

	public static void UserPushNotification(string fuseId, string message)
	{
	}

	public static void FriendsPushNotification(string message)
	{
	}

	public static string GetGameConfigurationValue(string key)
	{
		return null;
	}

	public static Dictionary<string, string> GetGameConfiguration()
	{
		return null;
	}
}
