using System;
using UnityEngine;

public static class AnalyticsHelper
{
	public static void LogHandledException(Exception exception)
	{
		if (CheckAnalyticsServiceAvailability())
		{
			AnalyticsServiceBase.instance.LogHandledException(exception);
		}
	}

	public static void LogCustomError(string title, string message)
	{
		if (CheckAnalyticsServiceAvailability())
		{
			AnalyticsServiceBase.instance.LogCustomError(title, message);
		}
	}

	public static void LeaveBreadcrumb(string breadcrumb)
	{
		if (CheckAnalyticsServiceAvailability())
		{
			AnalyticsServiceBase.instance.LeaveBreadcrumb(breadcrumb);
		}
	}

	public static void SetUsername(string username)
	{
		if (CheckAnalyticsServiceAvailability())
		{
			AnalyticsServiceBase.instance.SetUsername(username);
		}
	}

	private static bool CheckAnalyticsServiceAvailability()
	{
		if (AnalyticsServiceBase.instance == null)
		{
			Debug.LogError("Analytics service not yet available.");
			return false;
		}
		return true;
	}
}
