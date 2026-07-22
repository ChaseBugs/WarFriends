using UnityEngine;

public static class NotificationsAndroid
{
	private static AndroidJavaClass plugin;

	static NotificationsAndroid()
	{
		plugin = new AndroidJavaClass("com.aboutfun.plugins.notifications.Notifications");
		int num = 1;
		if (plugin != null)
		{
			plugin.CallStatic("setLogLevel", num);
		}
		else
		{
			PluginError("NotificationsAndroid");
		}
	}

	public static void CancelNotification(int id)
	{
		if (plugin != null)
		{
			plugin.CallStatic("cancelNotification", id);
		}
		else
		{
			PluginError("CancelNotification");
		}
	}

	public static int ScheduleNotification(int time, string title, string text, string channelId, int badge = 1, string smallIco = "small_icon", string largeIco = "large_icon")
	{
		if (plugin != null)
		{
			return plugin.CallStatic<int>("sheduleNotification", new object[7] { channelId, title, text, smallIco, largeIco, badge, time });
		}
		PluginError("ScheduleNotification");
		return -1;
	}

	public static void registerChannel(string channelId, string channelName, string channelDescription)
	{
		if (plugin != null)
		{
			plugin.CallStatic("createNotificationChannel", channelId, channelName, channelDescription);
		}
		else
		{
			PluginError("registerChannel");
		}
	}

	private static void PluginError(string method)
	{
		Debug.LogErrorFormat("NOTIFICATION ANDROID PLUGIN - {0}: null java plugin class!", method);
	}
}
