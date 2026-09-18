using System;
using System.Collections.Generic;
using TuneSDK;
using UnityEngine;

public class TuneSample : MonoBehaviour
{
	private string TUNE_ADVERTISER_ID;

	private string TUNE_CONVERSION_KEY;

	private string TUNE_PACKAGE_NAME;

	private static int titleFontSize = 50;

	private static bool isTitleBold = true;

	private Vector2 scrollPosition = Vector2.zero;

	private void Awake()
	{
		TUNE_ADVERTISER_ID = "877";
		TUNE_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";
		TUNE_PACKAGE_NAME = "com.hasoffers.unitytestapp";
		MonoBehaviour.print("Awake called: " + TUNE_ADVERTISER_ID + ", " + TUNE_CONVERSION_KEY);
	}

	private void Update()
	{
		if (Input.touchCount == 0)
		{
			return;
		}
		Touch touch = Input.touches[0];
		if (touch.phase == TouchPhase.Moved)
		{
			float num = Time.deltaTime / touch.deltaTime;
			if (num == 0f || float.IsNaN(num) || float.IsInfinity(num))
			{
				num = 1f;
			}
			Vector2 vector = touch.deltaPosition * num;
			scrollPosition.y += vector.y;
		}
	}

	private void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.fontStyle = (isTitleBold ? FontStyle.Bold : FontStyle.Normal);
		gUIStyle.fontSize = titleFontSize;
		gUIStyle.alignment = TextAnchor.MiddleCenter;
		gUIStyle.normal.textColor = Color.white;
		GUI.skin.button.fontSize = 40;
		GUI.Label(new Rect(10f, 5f, Screen.width - 20, Screen.height / 10), "TUNE Unity Test App", gUIStyle);
		scrollPosition = GUI.BeginScrollView(new Rect(10f, 5 + Screen.height / 10, Screen.width - 20, Screen.height), scrollPosition, new Rect(10f, 0f, Screen.width - 20, (float)Screen.height * 1.2f), GUIStyle.none, GUIStyle.none);
		if (GUI.Button(new Rect(10f, 0f, Screen.width - 20, Screen.height / 10), "Start TUNE SDK"))
		{
			MonoBehaviour.print("Start TUNE SDK clicked");
			Tune.Init(TUNE_ADVERTISER_ID, TUNE_CONVERSION_KEY);
			Tune.SetPackageName(TUNE_PACKAGE_NAME);
			Tune.SetFacebookEventLogging(enable: true, limit: false);
			Tune.CheckForDeferredDeeplink();
			Tune.AutomateIapEventMeasurement(automate: true);
			Tune.RegisterPowerHook("hookId", "friendlyName", "defaultValue");
			Tune.SetPushNotificationSenderId("1080799636982");
			Tune.RegisterCustomProfileString("customString", "val1");
			Tune.RegisterCustomProfileDate("customDate", new DateTime(2015, 6, 1));
			Tune.RegisterCustomProfileNumber("customInt", 1);
			Tune.RegisterCustomProfileNumber("customDouble", 0.99);
			Tune.RegisterCustomProfileNumber("customFloat", 5.99f);
			TuneLocation tuneLocation = new TuneLocation();
			tuneLocation.latitude = 55.2;
			tuneLocation.longitude = 122.44;
			Tune.RegisterCustomProfileGeoLocation("customGeo", tuneLocation);
			Tune.RegisterPowerHook("titleFontBold", "Is Title Text Font Bold", "false");
			Tune.RegisterPowerHook("titleFontSize", "Title Text Font Size", "25");
		}
		else if (GUI.Button(new Rect(10f, 1 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Set Delegate"))
		{
			MonoBehaviour.print("Set Delegate clicked");
			Tune.SetDelegate(enable: true);
			Tune.OnPowerHooksChanged(listenForPowerHooksChanged: true);
			Tune.OnFirstPlaylistDownloaded(listenForFirstPlaylist: true);
		}
		else if (GUI.Button(new Rect(10f, 2 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Enable Debug Mode"))
		{
			MonoBehaviour.print("Enable Debug Mode clicked");
			Tune.SetDebugMode(debug: true);
		}
		else if (GUI.Button(new Rect(10f, 3 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Measure Session"))
		{
			MonoBehaviour.print("Measure Session clicked");
			Tune.MeasureSession();
		}
		else if (GUI.Button(new Rect(10f, 4 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Measure Event"))
		{
			MonoBehaviour.print("Measure Event clicked");
			Tune.MeasureEvent("evt11");
		}
		else if (GUI.Button(new Rect(10f, 5 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Measure Event With Event Items"))
		{
			MonoBehaviour.print("Measure Event With Event Items clicked");
			TuneItem tuneItem = new TuneItem("subitem1");
			tuneItem.unitPrice = 5.0;
			tuneItem.quantity = 5;
			tuneItem.revenue = 3.0;
			tuneItem.attribute2 = "attrValue12";
			tuneItem.attribute3 = "attrValue13";
			tuneItem.attribute4 = "attrValue14";
			tuneItem.attribute5 = "attrValue15";
			TuneItem tuneItem2 = new TuneItem("subitem2");
			tuneItem2.unitPrice = 1.0;
			tuneItem2.quantity = 3;
			tuneItem2.revenue = 1.5;
			tuneItem2.attribute1 = "attrValue21";
			tuneItem2.attribute3 = "attrValue23";
			TuneItem[] eventItems = new TuneItem[2] { tuneItem, tuneItem2 };
			TuneEvent tuneEvent = new TuneEvent("purchase");
			tuneEvent.revenue = 10.0;
			tuneEvent.currencyCode = "AUD";
			tuneEvent.advertiserRefId = "ref222";
			tuneEvent.attribute1 = "test_attribute1";
			tuneEvent.attribute2 = "test_attribute2";
			tuneEvent.attribute3 = "test_attribute3";
			tuneEvent.attribute4 = "test_attribute4";
			tuneEvent.attribute5 = "test_attribute5";
			tuneEvent.contentType = "test_contentType";
			tuneEvent.contentId = "test_contentId";
			tuneEvent.date1 = DateTime.UtcNow;
			tuneEvent.date2 = DateTime.UtcNow.Add(new TimeSpan(new DateTime(2, 1, 1).Ticks));
			tuneEvent.level = 3;
			tuneEvent.quantity = 2;
			tuneEvent.rating = 4.5;
			tuneEvent.searchString = "test_searchString";
			tuneEvent.eventItems = eventItems;
			tuneEvent.transactionState = 1;
			Tune.MeasureEvent(tuneEvent);
		}
		else if (GUI.Button(new Rect(10f, 6 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Test Setter Methods"))
		{
			MonoBehaviour.print("Test Setter Methods clicked");
			Tune.SetAge(34);
			Tune.SetAppAdTracking(adTrackingEnabled: true);
			Tune.SetDebugMode(debug: true);
			Tune.SetExistingUser(isExistingUser: false);
			Tune.SetFacebookUserId("temp_facebook_user_id");
			Tune.SetGender(0);
			Tune.SetGoogleUserId("temp_google_user_id");
			Tune.SetLocation(111.0, 222.0, 333.0);
			Tune.SetPayingUser(isPayingUser: true);
			Tune.SetPhoneNumber("111-222-3333");
			Tune.SetTwitterUserId("twitter_user_id");
			Tune.SetUserId("temp_user_id");
			Tune.SetUserName("temp_user_name");
			Tune.SetUserEmail("tempuser@tempcompany.com");
			Tune.SetDeepLink("myapp://myval1/myval2");
			Tune.SetAndroidId("111111111111");
			Tune.SetDeviceId("123456789123456");
			Tune.SetGoogleAdvertisingId("12345678-1234-1234-1234-123456789012", isLATEnabled: true);
			Tune.SetMacAddress("AA:BB:CC:DD:EE:FF");
			Tune.SetCurrencyCode("CAD");
			Tune.SetTRUSTeId("1234567890");
			TunePreloadData preloadedApp = new TunePreloadData("1122334455");
			preloadedApp.advertiserSubAd = "some_adv_sub_ad_id";
			preloadedApp.publisherSub3 = "some_pub_sub3";
			Tune.SetPreloadedApp(preloadedApp);
		}
		else if (GUI.Button(new Rect(10f, 7 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Test Getter Methods"))
		{
			MonoBehaviour.print("Test Getter Methods clicked");
			MonoBehaviour.print("isPayingUser = " + Tune.GetIsPayingUser());
			MonoBehaviour.print("tuneId     = " + Tune.GetTuneId());
			MonoBehaviour.print("openLogId = " + Tune.GetOpenLogId());
		}
		else if (GUI.Button(new Rect(10f, 8 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Get Custom Profile Variables"))
		{
			MonoBehaviour.print("Get Custom Profile Variables clicked");
			MonoBehaviour.print("Custom string = " + Tune.GetCustomProfileString("customString"));
			MonoBehaviour.print("Custom date = " + Tune.GetCustomProfileDate("customDate").ToString("MM/dd/yyyy"));
			MonoBehaviour.print("Custom int = " + Tune.GetCustomProfileNumber("customInt"));
			MonoBehaviour.print("Custom double = " + Tune.GetCustomProfileNumber("customDouble"));
			MonoBehaviour.print("Custom float = " + Tune.GetCustomProfileNumber("customFloat"));
			TuneLocation customProfileGeolocation = Tune.GetCustomProfileGeolocation("customGeo");
			MonoBehaviour.print("Custom location = " + customProfileGeolocation.latitude + ", " + customProfileGeolocation.longitude);
		}
		else if (GUI.Button(new Rect(10f, 9 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Get Experiment Details"))
		{
			MonoBehaviour.print("Get Experiment Details clicked");
			Dictionary<string, TunePowerHookExperimentDetails> powerHookExperimentDetails = Tune.GetPowerHookExperimentDetails();
			foreach (KeyValuePair<string, TunePowerHookExperimentDetails> item in powerHookExperimentDetails)
			{
				MonoBehaviour.print("key is " + item.Key);
				MonoBehaviour.print("experiment name is " + item.Value.experimentName);
				MonoBehaviour.print("experiment id is " + item.Value.experimentId);
				MonoBehaviour.print("experiment type is " + item.Value.experimentType);
				MonoBehaviour.print("variant id is " + item.Value.currentVariantId);
				MonoBehaviour.print("variant name is " + item.Value.currentVariantName);
				MonoBehaviour.print("variant letter is " + item.Value.currentVariantLetter);
				MonoBehaviour.print("running is " + item.Value.isRunning);
			}
		}
		else if (GUI.Button(new Rect(10f, 10 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Test Power Hooks"))
		{
			string valueForHookById = Tune.GetValueForHookById("titleFontBold");
			string valueForHookById2 = Tune.GetValueForHookById("titleFontSize");
			string valueForHookById3 = Tune.GetValueForHookById("hookId");
			MonoBehaviour.print("power hook values1: sample hook = " + valueForHookById3);
			MonoBehaviour.print("power hook values2: sample hook = " + Tune.GetValueForHookById("hookId"));
			MonoBehaviour.print("power hook values: isBold = " + valueForHookById + ", size = " + valueForHookById2);
			isTitleBold = valueForHookById.Equals("true");
			titleFontSize = int.Parse(valueForHookById2);
		}
		GUI.EndScrollView();
	}

	public static string getSampleiTunesIAPReceipt()
	{
		return "dGhpcyBpcyBhIHNhbXBsZSBpb3MgYXBwIHN0b3JlIHJlY2VpcHQ=";
	}
}
