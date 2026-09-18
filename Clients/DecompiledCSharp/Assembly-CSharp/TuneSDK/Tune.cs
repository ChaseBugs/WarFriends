using System;
using System.Collections.Generic;
using UnityEngine;

namespace TuneSDK;

public class Tune : MonoBehaviour
{
	public static void Init(string advertiserId, string conversionKey)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.Init(advertiserId, conversionKey);
		}
	}

	public static void Init(string advertiserId, string conversionKey, bool turnOnTMA)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.Init(advertiserId, conversionKey, turnOnTMA);
		}
	}

	public static void Init(string advertiserId, string conversionKey, string packageName, bool wearable)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.Init(advertiserId, conversionKey);
		}
	}

	public static void CheckForDeferredDeeplink()
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.CheckForDeferredDeeplink();
		}
	}

	public static void AutomateIapEventMeasurement(bool automate)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetDeepLink(string deepLinkUrl)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetDeepLink(deepLinkUrl);
		}
	}

	public static void MeasureEvent(string eventName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.MeasureEvent(eventName);
		}
	}

	public static void MeasureEvent(TuneEvent tuneEvent)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.MeasureEvent(tuneEvent);
		}
	}

	public static void MeasureSession()
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.MeasureSession();
		}
	}

	public static void SetAge(int age)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetAge(age);
		}
	}

	public static void SetAppAdTracking(bool adTrackingEnabled)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetAppAdTracking(adTrackingEnabled);
		}
	}

	public static void SetDebugMode(bool debug)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetDebugMode(debug);
		}
	}

	private static void SetEventAttribute1(string eventAttribute)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventAttribute2(string eventAttribute)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventAttribute3(string eventAttribute)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventAttribute4(string eventAttribute)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventAttribute5(string eventAttribute)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventContentId(string eventContentId)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventContentType(string eventContentType)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventDate1(DateTime eventDate)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventDate2(DateTime eventDate)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventLevel(int eventLevel)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventQuantity(int eventQuantity)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventRating(float eventRating)
	{
		if (Application.isEditor)
		{
		}
	}

	private static void SetEventSearchString(string eventSearchString)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetExistingUser(bool isExistingUser)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetExistingUser(isExistingUser);
		}
	}

	public static void SetFacebookEventLogging(bool enable, bool limit)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetFacebookEventLogging(enable, limit);
		}
	}

	public static void SetFacebookUserId(string fbUserId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetFacebookUserId(fbUserId);
		}
	}

	public static void SetGender(int gender)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetGender(gender);
		}
	}

	public static void SetGoogleUserId(string googleUserId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetGoogleUserId(googleUserId);
		}
	}

	public static void SetLocation(double latitude, double longitude, double altitude)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetLocation(latitude, longitude, altitude);
		}
	}

	public static void SetPackageName(string packageName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetPackageName(packageName);
		}
	}

	public static void SetPayingUser(bool isPayingUser)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetPayingUser(isPayingUser);
		}
	}

	public static void SetPhoneNumber(string phoneNumber)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetPhoneNumber(phoneNumber);
		}
	}

	public static void SetShouldAutoCollectDeviceLocation(bool shouldAutoCollect)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetShouldAutoCollectDeviceLocation(shouldAutoCollect);
		}
	}

	public static void SetTwitterUserId(string twitterUserId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetTwitterUserId(twitterUserId);
		}
	}

	public static void SetUserEmail(string userEmail)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetUserEmail(userEmail);
		}
	}

	public static void SetUserId(string userId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetUserId(userId);
		}
	}

	public static void SetUserName(string userName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetUserName(userName);
		}
	}

	public static bool GetIsPayingUser()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetIsPayingUser();
		}
		return false;
	}

	public static string GetMATId()
	{
		return GetTuneId();
	}

	public static string GetTuneId()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetMatId();
		}
		return string.Empty;
	}

	public static string GetOpenLogId()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetOpenLogId();
		}
		return string.Empty;
	}

	public static void RegisterCustomProfileString(string variableName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileString(variableName);
		}
	}

	public static void RegisterCustomProfileString(string variableName, string defaultValue)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileString(variableName, defaultValue);
		}
	}

	public static void RegisterCustomProfileDate(string variableName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileDate(variableName);
		}
	}

	public static void RegisterCustomProfileDate(string variableName, DateTime defaultValue)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileDate(variableName, defaultValue);
		}
	}

	public static void RegisterCustomProfileNumber(string variableName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileNumber(variableName);
		}
	}

	public static void RegisterCustomProfileNumber(string variableName, int defaultValue)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileNumber(variableName, defaultValue);
		}
	}

	public static void RegisterCustomProfileNumber(string variableName, double defaultValue)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileNumber(variableName, defaultValue);
		}
	}

	public static void RegisterCustomProfileNumber(string variableName, float defaultValue)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileNumber(variableName, defaultValue);
		}
	}

	public static void RegisterCustomProfileGeoLocation(string variableName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileGeoLocation(variableName);
		}
	}

	public static void RegisterCustomProfileGeoLocation(string variableName, TuneLocation defaultValue)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterCustomProfileGeoLocation(variableName, defaultValue);
		}
	}

	public static void SetCustomProfileString(string variableName, string value)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetCustomProfileString(variableName, value);
		}
	}

	public static void SetCustomProfileDate(string variableName, DateTime value)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetCustomProfileDate(variableName, value);
		}
	}

	public static void SetCustomProfileNumber(string variableName, int value)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetCustomProfileNumber(variableName, value);
		}
	}

	public static void SetCustomProfileNumber(string variableName, double value)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetCustomProfileNumber(variableName, value);
		}
	}

	public static void SetCustomProfileNumber(string variableName, float value)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetCustomProfileNumber(variableName, value);
		}
	}

	public static void SetCustomProfileGeolocation(string variableName, TuneLocation value)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetCustomProfileGeolocation(variableName, value);
		}
	}

	public static string GetCustomProfileString(string variableName)
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetCustomProfileString(variableName);
		}
		return string.Empty;
	}

	public static DateTime GetCustomProfileDate(string variableName)
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetCustomProfileDate(variableName);
		}
		return default(DateTime);
	}

	public static double GetCustomProfileNumber(string variableName)
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetCustomProfileNumber(variableName);
		}
		return -1.0;
	}

	public static TuneLocation GetCustomProfileGeolocation(string variableName)
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetCustomProfileGeolocation(variableName);
		}
		return null;
	}

	public static void ClearCustomProfileVariable(string variableName)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.ClearCustomProfileVariable(variableName);
		}
	}

	public static void ClearAllCustomProfileVariables()
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.ClearAllCustomProfileVariables();
		}
	}

	public static void RegisterPowerHook(string hookId, string friendlyName, string defaultValue)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.RegisterPowerHook(hookId, friendlyName, defaultValue);
		}
	}

	public static string GetValueForHookById(string hookId)
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetValueForHookById(hookId);
		}
		return string.Empty;
	}

	public static void SetValueForHookById(string hookId, string value)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetValueForHookById(hookId, value);
		}
	}

	public static void OnPowerHooksChanged(bool listenForPowerHooksChanged)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.OnPowerHooksChanged(listenForPowerHooksChanged);
		}
	}

	public static Dictionary<string, TunePowerHookExperimentDetails> GetPowerHookExperimentDetails()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetPowerHookExperimentDetails();
		}
		return null;
	}

	public static Dictionary<string, TuneInAppMessageExperimentDetails> GetInAppMessageExperimentDetails()
	{
		if (!Application.isEditor)
		{
		}
		return null;
	}

	public static void OnFirstPlaylistDownloaded(bool listenForFirstPlaylist)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.OnFirstPlaylistDownloaded(listenForFirstPlaylist);
		}
	}

	public static void OnFirstPlaylistDownloaded(bool listenForFirstPlaylist, long timeout)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.OnFirstPlaylistDownloaded(listenForFirstPlaylist, timeout);
		}
	}

	public static void SetPushNotificationSenderId(string pushSenderId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetPushNotificationSenderId(pushSenderId);
		}
	}

	public static void SetPushNotificationRegistrationId(string registrationId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetPushNotificationRegistrationId(registrationId);
		}
	}

	public static void SetOptedOutOfPush(bool optedOutOfPush)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetOptedOutOfPush(optedOutOfPush);
		}
	}

	public static string GetDeviceToken()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetDeviceToken();
		}
		return string.Empty;
	}

	public static bool DidUserManuallyDisablePush()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.DidUserManuallyDisablePush();
		}
		return false;
	}

	public static bool DidSessionStartFromTunePush()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.DidSessionStartFromTunePush();
		}
		return false;
	}

	public static TunePushInfo GetTunePushInfoForSession()
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.GetTunePushInfoForSession();
		}
		return null;
	}

	public static bool IsUserInSegmentId(string segmentId)
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.IsUserInSegmentId(segmentId);
		}
		return false;
	}

	public static bool IsUserInAnySegmentIds(string[] segmentIds)
	{
		if (!Application.isEditor)
		{
			return TuneAndroid.Instance.IsUserInAnySegmentIds(segmentIds);
		}
		return false;
	}

	public static void ForceSetUserInSegmentId(string segmentId, bool isInSegment)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.ForceSetUserInSegmentId(segmentId, isInSegment);
		}
	}

	public static void SetAppleAdvertisingIdentifier(string advertiserIdentifier, bool trackingEnabled)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetAppleVendorIdentifier(string vendorIdentifier)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetJailbroken(bool isJailbroken)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetShouldAutoDetectJailbroken(bool isAutoDetectJailbroken)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetShouldAutoCollectAppleAdvertisingIdentifier(bool shouldAutoCollect)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetShouldAutoGenerateVendorIdentifier(bool shouldAutoGenerate)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetUseCookieTracking(bool useCookieTracking)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetAndroidId(string androidId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetAndroidId(androidId);
		}
	}

	public static void SetAndroidIdMd5(string androidIdMd5)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetAndroidIdMd5(androidIdMd5);
		}
	}

	public static void SetAndroidIdSha1(string androidIdSha1)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetAndroidIdSha1(androidIdSha1);
		}
	}

	public static void SetAndroidIdSha256(string androidIdSha256)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetAndroidIdSha256(androidIdSha256);
		}
	}

	public static void SetDeviceId(string deviceId)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetDeviceId(deviceId);
		}
	}

	public static void SetEmailCollection(bool collectEmail)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetEmailCollection(collectEmail);
		}
	}

	public static void SetMacAddress(string macAddress)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetMacAddress(macAddress);
		}
	}

	public static void SetGoogleAdvertisingId(string adId, bool isLATEnabled)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetGoogleAdvertisingId(adId, isLATEnabled);
		}
	}

	public static void SetCurrencyCode(string currencyCode)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetCurrencyCode(currencyCode);
		}
	}

	public static void SetDelegate(bool enable)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetDelegate(enable);
		}
	}

	public static void SetPreloadedApp(TunePreloadData preloadData)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetPreloadedApp(preloadData);
		}
	}

	public static void SetTRUSTeId(string tpid)
	{
		if (!Application.isEditor)
		{
			TuneAndroid.Instance.SetTRUSTeId(tpid);
		}
	}

	private static string GetDateTimeString(DateTime dateTime)
	{
		DateTime dateTime2 = new DateTime(1970, 1, 1);
		double totalMilliseconds = new TimeSpan(dateTime.Ticks).TotalMilliseconds;
		return (totalMilliseconds - new TimeSpan(dateTime2.Ticks).TotalMilliseconds).ToString();
	}

	private static DateTime GetDateTimeFromString(string dateString)
	{
		double value = Convert.ToDouble(dateString);
		return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(value);
	}
}
