using System;
using System.Collections.Generic;
using UnityEngine;

namespace TuneSDK;

public class TuneAndroid
{
	private static TuneAndroid instance;

	private AndroidJavaClass ajcTune = new AndroidJavaClass("com.tune.Tune");

	private AndroidJavaClass ajcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

	private AndroidJavaObject ajcCurrentActivity;

	public AndroidJavaObject ajcInstance;

	public static TuneAndroid Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new TuneAndroid();
			}
			return instance;
		}
	}

	private TuneAndroid()
	{
		ajcCurrentActivity = ajcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	}

	public void Init(string advertiserId, string conversionKey)
	{
		ajcInstance = ajcTune.CallStatic<AndroidJavaObject>("init", new object[3] { ajcCurrentActivity, advertiserId, conversionKey });
		ajcInstance.Call("setPluginName", "unity");
	}

	public void Init(string advertiserId, string conversionKey, bool turnOnTMA)
	{
		ajcInstance = ajcTune.CallStatic<AndroidJavaObject>("init", new object[4] { ajcCurrentActivity, advertiserId, conversionKey, turnOnTMA });
		ajcInstance.Call("setPluginName", "unity");
	}

	public void MeasureSession()
	{
		ajcInstance.Call("setReferralSources", ajcCurrentActivity);
		ajcInstance.Call("measureSession");
	}

	public void MeasureEvent(string eventName)
	{
		ajcInstance.Call("measureEvent", eventName);
	}

	public void MeasureEvent(TuneEvent tuneEvent)
	{
		AndroidJavaObject tuneEventJavaObject = GetTuneEventJavaObject(tuneEvent);
		ajcInstance.Call("measureEvent", tuneEventJavaObject);
	}

	public void CheckForDeferredDeeplink()
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityDeeplinkListener");
		ajcInstance.Call("checkForDeferredDeeplink", androidJavaObject);
	}

	public bool GetIsPayingUser()
	{
		return ajcInstance.Call<bool>("getIsPayingUser", new object[0]);
	}

	public string GetMatId()
	{
		return ajcInstance.Call<string>("getMatId", new object[0]);
	}

	public string GetOpenLogId()
	{
		return ajcInstance.Call<string>("getOpenLogId", new object[0]);
	}

	public void SetAge(int age)
	{
		ajcInstance.Call("setAge", age);
	}

	public void SetAndroidId(string androidId)
	{
		ajcInstance.Call("setAndroidId", androidId);
	}

	public void SetAndroidIdMd5(string androidIdMd5)
	{
		ajcInstance.Call("setAndroidIdMd5", androidIdMd5);
	}

	public void SetAndroidIdSha1(string androidIdSha1)
	{
		ajcInstance.Call("setAndroidIdSha1", androidIdSha1);
	}

	public void SetAndroidIdSha256(string androidIdSha256)
	{
		ajcInstance.Call("setAndroidIdSha256", androidIdSha256);
	}

	public void SetAppAdTracking(bool adTrackingEnabled)
	{
		ajcInstance.Call("setAppAdTrackingEnabled", adTrackingEnabled);
	}

	public void SetCurrencyCode(string currencyCode)
	{
		ajcInstance.Call("setCurrencyCode", currencyCode);
	}

	public void SetDeepLink(string deepLinkUrl)
	{
		ajcInstance.Call("setReferralUrl", deepLinkUrl);
	}

	public void SetDebugMode(bool debugMode)
	{
		ajcInstance.Call("setDebugMode", debugMode);
	}

	public void SetDeviceId(string deviceId)
	{
		ajcInstance.Call("setDeviceId", deviceId);
	}

	public void SetDelegate(bool enable)
	{
		if (enable)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityListener");
			ajcInstance.Call("setListener", androidJavaObject);
		}
	}

	public void SetEmailCollection(bool collectEmail)
	{
		ajcInstance.Call("setEmailCollection", collectEmail);
	}

	public void SetExistingUser(bool isExistingUser)
	{
		ajcInstance.Call("setExistingUser", isExistingUser);
	}

	public void SetFacebookEventLogging(bool fbEventLogging, bool limitEventAndDataUsage)
	{
		ajcInstance.Call("setFacebookEventLogging", fbEventLogging, ajcCurrentActivity, limitEventAndDataUsage);
	}

	public void SetFacebookUserId(string facebookUserId)
	{
		ajcInstance.Call("setFacebookUserId", facebookUserId);
	}

	public void SetGender(int gender)
	{
		AndroidJavaObject androidJavaObject;
		switch (gender)
		{
		case 0:
			androidJavaObject = new AndroidJavaClass("com.tune.TuneGender").GetStatic<AndroidJavaObject>("MALE");
			return;
		case 1:
			androidJavaObject = new AndroidJavaClass("com.tune.TuneGender").GetStatic<AndroidJavaObject>("FEMALE");
			return;
		}
		androidJavaObject = new AndroidJavaClass("com.tune.TuneGender").GetStatic<AndroidJavaObject>("UNKNOWN");
		ajcInstance.Call("setGender", androidJavaObject);
	}

	public void SetGoogleAdvertisingId(string googleAid, bool isLATEnabled)
	{
		ajcInstance.Call("setGoogleAdvertisingId", googleAid, isLATEnabled);
	}

	public void SetGoogleUserId(string googleUserId)
	{
		ajcInstance.Call("setGoogleUserId", googleUserId);
	}

	public void SetLocation(double latitude, double longitude, double altitude)
	{
		ajcInstance.Call("setLatitude", latitude);
		ajcInstance.Call("setLongitude", longitude);
		ajcInstance.Call("setAltitude", altitude);
	}

	public void SetMacAddress(string macAddress)
	{
		ajcInstance.Call("setMacAddress", macAddress);
	}

	public void SetPackageName(string packageName)
	{
		ajcInstance.Call("setPackageName", packageName);
	}

	public void SetPayingUser(bool isPayingUser)
	{
		ajcInstance.Call("setIsPayingUser", isPayingUser);
	}

	public void SetPhoneNumber(string phoneNumber)
	{
		ajcInstance.Call("setPhoneNumber", phoneNumber);
	}

	public void SetShouldAutoCollectDeviceLocation(bool shouldAutoCollect)
	{
		ajcInstance.Call("setShouldAutoCollectDeviceLocation", shouldAutoCollect);
	}

	public void SetTRUSTeId(string tpid)
	{
		ajcInstance.Call("setTRUSTeId", tpid);
	}

	public void SetTwitterUserId(string twitterUserId)
	{
		ajcInstance.Call("setTwitterUserId", twitterUserId);
	}

	public void SetUserEmail(string userEmail)
	{
		ajcInstance.Call("setUserEmail", userEmail);
	}

	public void SetUserId(string userId)
	{
		ajcInstance.Call("setUserId", userId);
	}

	public void SetUserName(string userName)
	{
		ajcInstance.Call("setUserName", userName);
	}

	public void SetPreloadedApp(TunePreloadData preloadData)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TunePreloadData", preloadData.publisherId);
		if (preloadData.offerId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withOfferId", new object[1] { preloadData.offerId });
		}
		if (preloadData.agencyId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAgencyId", new object[1] { preloadData.agencyId });
		}
		if (preloadData.publisherReferenceId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherReferenceId", new object[1] { preloadData.publisherReferenceId });
		}
		if (preloadData.publisherSub1 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub1", new object[1] { preloadData.publisherSub1 });
		}
		if (preloadData.publisherSub2 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub2", new object[1] { preloadData.publisherSub2 });
		}
		if (preloadData.publisherSub3 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub3", new object[1] { preloadData.publisherSub3 });
		}
		if (preloadData.publisherSub4 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub4", new object[1] { preloadData.publisherSub4 });
		}
		if (preloadData.publisherSub5 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub5", new object[1] { preloadData.publisherSub5 });
		}
		if (preloadData.publisherSubAd != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubAd", new object[1] { preloadData.publisherSubAd });
		}
		if (preloadData.publisherSubAdgroup != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubAdgroup", new object[1] { preloadData.publisherSubAdgroup });
		}
		if (preloadData.publisherSubCampaign != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubCampaign", new object[1] { preloadData.publisherSubCampaign });
		}
		if (preloadData.publisherSubKeyword != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubKeyword", new object[1] { preloadData.publisherSubKeyword });
		}
		if (preloadData.publisherSubPublisher != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubPublisher", new object[1] { preloadData.publisherSubPublisher });
		}
		if (preloadData.publisherSubSite != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubSite", new object[1] { preloadData.publisherSubSite });
		}
		if (preloadData.advertiserSubAd != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubAd", new object[1] { preloadData.advertiserSubAd });
		}
		if (preloadData.advertiserSubAdgroup != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubAdgroup", new object[1] { preloadData.advertiserSubAdgroup });
		}
		if (preloadData.advertiserSubCampaign != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubCampaign", new object[1] { preloadData.advertiserSubCampaign });
		}
		if (preloadData.advertiserSubKeyword != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubKeyword", new object[1] { preloadData.advertiserSubKeyword });
		}
		if (preloadData.advertiserSubPublisher != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubPublisher", new object[1] { preloadData.advertiserSubPublisher });
		}
		if (preloadData.advertiserSubSite != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubSite", new object[1] { preloadData.advertiserSubSite });
		}
		ajcInstance.Call("setPreloadedApp", androidJavaObject);
	}

	public void RegisterCustomProfileString(string variableName)
	{
		ajcInstance.Call("registerCustomProfileString", variableName);
	}

	public void RegisterCustomProfileString(string variableName, string defaultValue)
	{
		ajcInstance.Call("registerCustomProfileString", variableName, defaultValue);
	}

	public void RegisterCustomProfileDate(string variableName)
	{
		ajcInstance.Call("registerCustomProfileDate", variableName);
	}

	public void RegisterCustomProfileDate(string variableName, DateTime defaultValue)
	{
		AndroidJavaObject javaDate = GetJavaDate(defaultValue);
		ajcInstance.Call("registerCustomProfileDate", variableName, javaDate);
	}

	public void RegisterCustomProfileNumber(string variableName)
	{
		ajcInstance.Call("registerCustomProfileNumber", variableName);
	}

	public void RegisterCustomProfileNumber(string variableName, int defaultValue)
	{
		ajcInstance.Call("registerCustomProfileNumber", variableName, defaultValue);
	}

	public void RegisterCustomProfileNumber(string variableName, double defaultValue)
	{
		ajcInstance.Call("registerCustomProfileNumber", variableName, defaultValue);
	}

	public void RegisterCustomProfileNumber(string variableName, float defaultValue)
	{
		ajcInstance.Call("registerCustomProfileNumber", variableName, defaultValue);
	}

	public void RegisterCustomProfileGeoLocation(string variableName)
	{
		ajcInstance.Call("registerCustomProfileGeolocation", variableName);
	}

	public void RegisterCustomProfileGeoLocation(string variableName, TuneLocation defaultValue)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TuneLocation", defaultValue.longitude, defaultValue.latitude);
		ajcInstance.Call("registerCustomProfileGeolocation", variableName, androidJavaObject);
	}

	public void SetCustomProfileString(string variableName, string value)
	{
		ajcInstance.Call("setCustomProfileStringValue", variableName, value);
	}

	public void SetCustomProfileDate(string variableName, DateTime value)
	{
		AndroidJavaObject javaDate = GetJavaDate(value);
		ajcInstance.Call("setCustomProfileDate", variableName, javaDate);
	}

	public void SetCustomProfileNumber(string variableName, int value)
	{
		ajcInstance.Call("setCustomProfileNumber", variableName, value);
	}

	public void SetCustomProfileNumber(string variableName, double value)
	{
		ajcInstance.Call("setCustomProfileNumber", variableName, value);
	}

	public void SetCustomProfileNumber(string variableName, float value)
	{
		ajcInstance.Call("setCustomProfileNumber", variableName, value);
	}

	public void SetCustomProfileGeolocation(string variableName, TuneLocation value)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TuneLocation", value.longitude, value.latitude);
		ajcInstance.Call("setCustomProfileGeolocation", variableName, androidJavaObject);
	}

	public string GetCustomProfileString(string variableName)
	{
		return ajcInstance.Call<string>("getCustomProfileString", new object[1] { variableName });
	}

	public DateTime GetCustomProfileDate(string variableName)
	{
		AndroidJavaObject androidJavaObject = ajcInstance.Call<AndroidJavaObject>("getCustomProfileDate", new object[1] { variableName });
		if (androidJavaObject != null)
		{
			long num = androidJavaObject.Call<long>("getTime", new object[0]);
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(num);
		}
		return default(DateTime);
	}

	public double GetCustomProfileNumber(string variableName)
	{
		return ajcInstance.Call<AndroidJavaObject>("getCustomProfileNumber", new object[1] { variableName })?.Call<double>("doubleValue", new object[0]) ?? (-1.0);
	}

	public TuneLocation GetCustomProfileGeolocation(string variableName)
	{
		TuneLocation tuneLocation = new TuneLocation();
		AndroidJavaObject androidJavaObject = ajcInstance.Call<AndroidJavaObject>("getCustomProfileGeolocation", new object[1] { variableName });
		if (androidJavaObject != null)
		{
			double latitude = androidJavaObject.Call<double>("getLatitude", new object[0]);
			double longitude = androidJavaObject.Call<double>("getLongitude", new object[0]);
			tuneLocation.latitude = latitude;
			tuneLocation.longitude = longitude;
		}
		return tuneLocation;
	}

	public void ClearCustomProfileVariable(string variableName)
	{
		ajcInstance.Call("clearCustomProfileVariable", variableName);
	}

	public void ClearAllCustomProfileVariables()
	{
		ajcInstance.Call("clearAllCustomProfileVariables");
	}

	public void RegisterPowerHook(string hookId, string friendlyName, string defaultValue)
	{
		ajcInstance.Call("registerPowerHook", hookId, friendlyName, defaultValue);
	}

	public string GetValueForHookById(string hookId)
	{
		return ajcInstance.Call<string>("getValueForHookById", new object[1] { hookId });
	}

	public void SetValueForHookById(string hookId, string value)
	{
		ajcInstance.Call("setValueForHookById", hookId, value);
	}

	public void OnPowerHooksChanged(bool listenForPowerHooksChanged)
	{
		if (listenForPowerHooksChanged)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityPowerHooksListener");
			ajcInstance.Call("onPowerHooksChanged", androidJavaObject);
		}
	}

	public Dictionary<string, TunePowerHookExperimentDetails> GetPowerHookExperimentDetails()
	{
		Dictionary<string, TunePowerHookExperimentDetails> dictionary = new Dictionary<string, TunePowerHookExperimentDetails>();
		AndroidJavaObject androidJavaObject = ajcInstance.Call<AndroidJavaObject>("getPowerHookExperimentDetails", new object[0]);
		if (androidJavaObject != null)
		{
			AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("entrySet", new object[0]);
			AndroidJavaObject androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("iterator", new object[0]);
			while (androidJavaObject3.Call<bool>("hasNext", new object[0]))
			{
				AndroidJavaObject androidJavaObject4 = androidJavaObject3.Call<AndroidJavaObject>("next", new object[0]);
				string key = androidJavaObject4.Call<string>("getKey", new object[0]);
				AndroidJavaObject experimentDetails = androidJavaObject4.Call<AndroidJavaObject>("getValue", new object[0]);
				dictionary.Add(key, new TunePowerHookExperimentDetails(experimentDetails));
			}
		}
		return dictionary;
	}

	public void OnFirstPlaylistDownloaded(bool listenForFirstPlaylist)
	{
		if (listenForFirstPlaylist)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityFirstPlaylistListener");
			ajcInstance.Call("onFirstPlaylistDownloaded", androidJavaObject);
		}
	}

	public void OnFirstPlaylistDownloaded(bool listenForFirstPlaylist, long timeout)
	{
		if (listenForFirstPlaylist)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityFirstPlaylistListener");
			ajcInstance.Call("onFirstPlaylistDownloaded", androidJavaObject, timeout);
		}
	}

	public void SetPushNotificationSenderId(string pushSenderId)
	{
		ajcInstance.Call("setPushNotificationSenderId", pushSenderId);
	}

	public void SetPushNotificationRegistrationId(string registrationId)
	{
		ajcInstance.Call("setPushNotificationRegistrationId", registrationId);
	}

	public void SetOptedOutOfPush(bool optedOutOfPush)
	{
		ajcInstance.Call("setOptedOutOfPush", optedOutOfPush);
	}

	public string GetDeviceToken()
	{
		return ajcInstance.Call<string>("getDeviceToken", new object[0]);
	}

	public bool DidUserManuallyDisablePush()
	{
		return ajcInstance.Call<bool>("didUserManuallyDisablePush", new object[0]);
	}

	public bool DidSessionStartFromTunePush()
	{
		return ajcInstance.Call<bool>("didSessionStartFromTunePush", new object[0]);
	}

	public TunePushInfo GetTunePushInfoForSession()
	{
		string campaignId = string.Empty;
		string pushId = string.Empty;
		Dictionary<string, string> extrasPayload = new Dictionary<string, string>();
		try
		{
			AndroidJavaObject androidJavaObject = ajcInstance.Call<AndroidJavaObject>("getTunePushInfoForSession", new object[0]);
			campaignId = androidJavaObject.Call<string>("getCampaignId", new object[0]);
			pushId = androidJavaObject.Call<string>("getPushId", new object[0]);
			AndroidJavaObject jsonObject = androidJavaObject.Call<AndroidJavaObject>("getExtrasPayload", new object[0]);
			extrasPayload = JsonToDictionary(jsonObject);
		}
		catch (Exception)
		{
		}
		return new TunePushInfo(campaignId, pushId, extrasPayload);
	}

	public bool IsUserInSegmentId(string segmentId)
	{
		return ajcInstance.Call<bool>("isUserInSegmentId", new object[1] { segmentId });
	}

	public bool IsUserInAnySegmentIds(string[] segmentIds)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.ArrayList");
		foreach (string text in segmentIds)
		{
			androidJavaObject.Call<bool>("add", new object[1] { text });
		}
		return ajcInstance.Call<bool>("isUserInAnySegmentIds", new object[1] { androidJavaObject });
	}

	public void ForceSetUserInSegmentId(string segmentId, bool isInSegment)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.tune.TuneDebugUtilities");
		androidJavaClass.CallStatic("forceSetUserInSegmentId", segmentId, isInSegment);
	}

	private Dictionary<string, string> JsonToDictionary(AndroidJavaObject jsonObject)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		AndroidJavaObject androidJavaObject = jsonObject.Call<AndroidJavaObject>("keys", new object[0]);
		while (androidJavaObject.Call<bool>("hasNext", new object[0]))
		{
			string text = androidJavaObject.Call<string>("next", new object[0]);
			dictionary.Add(text, jsonObject.Call<string>("get", new object[1] { text }));
		}
		return dictionary;
	}

	private AndroidJavaObject DictionaryToMap(Dictionary<string, string> dict)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.HashMap");
		if (dict != null)
		{
			foreach (KeyValuePair<string, string> item in dict)
			{
				androidJavaObject.Call<string>("put", new object[2] { item.Key, item.Value });
			}
		}
		return androidJavaObject;
	}

	private AndroidJavaObject GetTuneEventJavaObject(TuneEvent tuneEvent)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TuneEvent", tuneEvent.name);
		double? revenue = tuneEvent.revenue;
		if (revenue.HasValue)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withRevenue", new object[1] { tuneEvent.revenue });
		}
		if (tuneEvent.currencyCode != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withCurrencyCode", new object[1] { tuneEvent.currencyCode });
		}
		if (tuneEvent.advertiserRefId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserRefId", new object[1] { tuneEvent.advertiserRefId });
		}
		if (tuneEvent.eventItems != null)
		{
			AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.util.ArrayList");
			TuneItem[] eventItems = tuneEvent.eventItems;
			for (int i = 0; i < eventItems.Length; i++)
			{
				TuneItem tuneItem = eventItems[i];
				AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("com.tune.TuneEventItem", tuneItem.name);
				int? quantity = tuneItem.quantity;
				if (quantity.HasValue)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withQuantity", new object[1] { tuneItem.quantity });
				}
				double? unitPrice = tuneItem.unitPrice;
				if (unitPrice.HasValue)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withUnitPrice", new object[1] { tuneItem.unitPrice });
				}
				double? revenue2 = tuneItem.revenue;
				if (revenue2.HasValue)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withRevenue", new object[1] { tuneItem.revenue });
				}
				if (tuneItem.attribute1 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute1", new object[1] { tuneItem.attribute1 });
				}
				if (tuneItem.attribute2 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute2", new object[1] { tuneItem.attribute2 });
				}
				if (tuneItem.attribute3 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute3", new object[1] { tuneItem.attribute3 });
				}
				if (tuneItem.attribute4 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute4", new object[1] { tuneItem.attribute4 });
				}
				if (tuneItem.attribute5 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute5", new object[1] { tuneItem.attribute5 });
				}
				androidJavaObject2.Call<bool>("add", new object[1] { androidJavaObject3 });
			}
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withEventItems", new object[1] { androidJavaObject2 });
		}
		if (tuneEvent.receipt != null && tuneEvent.receiptSignature != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withReceipt", new object[2] { tuneEvent.receipt, tuneEvent.receiptSignature });
		}
		if (tuneEvent.contentType != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withContentType", new object[1] { tuneEvent.contentType });
		}
		if (tuneEvent.contentId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withContentId", new object[1] { tuneEvent.contentId });
		}
		int? level = tuneEvent.level;
		if (level.HasValue)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withLevel", new object[1] { tuneEvent.level });
		}
		int? quantity2 = tuneEvent.quantity;
		if (quantity2.HasValue)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withQuantity", new object[1] { tuneEvent.quantity });
		}
		if (tuneEvent.searchString != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withSearchString", new object[1] { tuneEvent.searchString });
		}
		DateTime? date = tuneEvent.date1;
		if (date.HasValue)
		{
			DateTime? date2 = tuneEvent.date1;
			AndroidJavaObject javaDate = GetJavaDate(date2.Value);
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withDate1", new object[1] { javaDate });
		}
		DateTime? date3 = tuneEvent.date2;
		if (date3.HasValue)
		{
			DateTime? date4 = tuneEvent.date2;
			AndroidJavaObject javaDate2 = GetJavaDate(date4.Value);
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withDate2", new object[1] { javaDate2 });
		}
		if (tuneEvent.attribute1 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute1", new object[1] { tuneEvent.attribute1 });
		}
		if (tuneEvent.attribute2 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute2", new object[1] { tuneEvent.attribute2 });
		}
		if (tuneEvent.attribute3 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute3", new object[1] { tuneEvent.attribute3 });
		}
		if (tuneEvent.attribute4 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute4", new object[1] { tuneEvent.attribute4 });
		}
		if (tuneEvent.attribute5 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute5", new object[1] { tuneEvent.attribute5 });
		}
		return androidJavaObject;
	}

	private AndroidJavaObject GetJavaDate(DateTime date)
	{
		double totalMilliseconds = new TimeSpan(date.Ticks).TotalMilliseconds;
		double num = totalMilliseconds - new TimeSpan(new DateTime(1970, 1, 1).Ticks).TotalMilliseconds;
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Double", num);
		long num2 = androidJavaObject.Call<long>("longValue", new object[0]);
		return new AndroidJavaObject("java.util.Date", num2);
	}
}
