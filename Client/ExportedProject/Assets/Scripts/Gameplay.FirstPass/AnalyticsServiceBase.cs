using System;
using UnityEngine;

public abstract class AnalyticsServiceBase : IAnalyticsService
{
	private static IAnalyticsService _instance;

	public static IAnalyticsService instance => _instance;

	public static void Initialize<TAnalyticsService>() where TAnalyticsService : IAnalyticsService, new()
	{
		if (_instance != null)
		{
			Debug.LogError("Analytics Service already initialized.");
		}
		else
		{
			_instance = new TAnalyticsService();
		}
	}

	public abstract void LogHandledException(Exception exception);

	public abstract void LogCustomError(string title, string message);

	public abstract void LeaveBreadcrumb(string breadcrumb);

	public abstract void SetUsername(string username);
}
