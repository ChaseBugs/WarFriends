using System;

public interface IAnalyticsService
{
	void LogHandledException(Exception exception);

	void LogCustomError(string title, string message);

	void LeaveBreadcrumb(string breadcrumb);

	void SetUsername(string username);
}
