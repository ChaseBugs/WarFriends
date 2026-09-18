using System;
using UnityEngine;

public sealed class AndroidOpenBroadcastApp : Core_BaseScript
{
	public static void launchApp(string bundleId = "com.google.android.apps.youtube.gaming")
	{
		bool flag = false;
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		AndroidJavaObject androidJavaObject3 = null;
		try
		{
			androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { bundleId });
		}
		catch (Exception)
		{
			flag = true;
		}
		if (flag)
		{
			Application.OpenURL("https://play.google.com/store/apps/details?id=" + bundleId);
		}
		else
		{
			try
			{
				androidJavaObject.Call("startActivity", androidJavaObject3);
			}
			catch (Exception)
			{
			}
		}
		if (androidJavaClass != null)
		{
			androidJavaClass.Dispose();
			androidJavaClass = null;
		}
		if (androidJavaObject != null)
		{
			androidJavaObject.Dispose();
			androidJavaObject = null;
		}
		if (androidJavaObject2 != null)
		{
			androidJavaObject2.Dispose();
			androidJavaObject2 = null;
		}
		if (androidJavaObject3 != null)
		{
			androidJavaObject3.Dispose();
			androidJavaObject3 = null;
		}
	}
}
