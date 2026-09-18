using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prime31;

public class FacebookAndroid
{
	private static AndroidJavaObject _facebookPlugin;

	static FacebookAndroid()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.prime31.FacebookPlugin"))
			{
				_facebookPlugin = androidJavaClass.CallStatic<AndroidJavaObject>("instance", new object[0]);
			}
			FacebookManager.preLoginSucceededEvent += delegate
			{
				Facebook.instance.accessToken = getAccessToken();
			};
		}
	}

	internal static void babysitRequest(bool requiresPublishPermissions, Action afterAuthAction)
	{
		new FacebookAuthHelper(requiresPublishPermissions, afterAuthAction).start();
	}

	public static void init(bool printKeyHash = true)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("init", printKeyHash);
			Facebook.instance.accessToken = getAccessToken();
		}
	}

	public static string getAppLaunchUrl()
	{
		if (Application.platform != RuntimePlatform.Android)
		{
			return string.Empty;
		}
		return _facebookPlugin.Call<string>("getAppLaunchUrl", new object[0]);
	}

	public static void setSessionLoginBehavior(FacebookSessionLoginBehavior loginBehavior)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("setSessionLoginBehavior", loginBehavior.ToString());
		}
	}

	public static void setDefaultAudience(FacebookSessionDefaultAudience defaultAudience)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("setDefaultAudience", defaultAudience.ToString());
		}
	}

	public static bool isSessionValid()
	{
		if (Application.platform != RuntimePlatform.Android)
		{
			return false;
		}
		return _facebookPlugin.Call<bool>("isSessionValid", new object[0]);
	}

	public static string getAccessToken()
	{
		if (Application.platform != RuntimePlatform.Android)
		{
			return string.Empty;
		}
		return _facebookPlugin.Call<string>("getAccessToken", new object[0]);
	}

	public static List<object> getSessionPermissions()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			string json = _facebookPlugin.Call<string>("getSessionPermissions", new object[0]);
			return json.listFromJson();
		}
		return new List<object>();
	}

	public static void login()
	{
		loginWithReadPermissions(new string[0]);
	}

	public static void loginWithReadPermissions(string[] permissions)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("loginWithReadPermissions", new object[1] { permissions });
		}
	}

	public static void loginWithPublishPermissions(string[] permissions)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("loginWithPublishPermissions", new object[1] { permissions });
		}
	}

	public static void logout()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("logout");
			Facebook.instance.accessToken = string.Empty;
		}
	}

	public static void showFacebookShareDialog(FacebookShareContent parameters)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("showFacebookShareDialog", Json.encode(parameters));
		}
	}

	public static void showAppInviteDialog(string appLinkUrl, string previewImageUrl = null)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("showAppInviteDialog", appLinkUrl, previewImageUrl);
		}
	}

	public static void showGameRequestDialog(FacebookGameRequestContent content)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("showGameRequestDialog", Json.encode(content));
		}
	}

	public static void graphRequest(string graphPath, string httpMethod, Dictionary<string, string> parameters)
	{
		if (Application.platform != RuntimePlatform.Android)
		{
			return;
		}
		parameters = parameters ?? new Dictionary<string, string>();
		if (!isSessionValid())
		{
			babysitRequest(requiresPublishPermissions: true, delegate
			{
				_facebookPlugin.Call("graphRequest", graphPath, httpMethod, parameters.toJson());
			});
		}
		else
		{
			_facebookPlugin.Call("graphRequest", graphPath, httpMethod, parameters.toJson());
		}
	}

	public static void logEvent(string eventName, Dictionary<string, object> parameters = null)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (parameters != null)
			{
				_facebookPlugin.Call("logEventWithParameters", eventName, Json.encode(parameters));
			}
			else
			{
				_facebookPlugin.Call("logEvent", eventName);
			}
		}
	}

	public static void logPurchaseEvent(double amount, string currency)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_facebookPlugin.Call("logPurchaseEvent", amount, currency);
		}
	}

	public static void logEvent(string eventName, double valueToSum, Dictionary<string, object> parameters = null)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (parameters != null)
			{
				_facebookPlugin.Call("logEventAndValueToSumWithParameters", eventName, valueToSum, Json.encode(parameters));
			}
			else
			{
				_facebookPlugin.Call("logEventAndValueToSum", eventName, valueToSum);
			}
		}
	}
}
