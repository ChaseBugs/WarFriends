using System;
using System.Collections.Generic;
using Amazon.MobileAnalytics.Model;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

public class MobileAnalyticsErrorEventArgs : EventArgs
{
	public string ClassName { get; set; }

	public string ErrorMessage { get; set; }

	public Exception Exception { get; set; }

	public List<Event> UndeliveredEvents { get; set; }

	internal MobileAnalyticsErrorEventArgs(string className, string errorMessage, Exception exception, List<Event> undeliveredEvents)
	{
		if (className == null)
		{
			throw new ArgumentNullException("className");
		}
		if (errorMessage == null)
		{
			throw new ArgumentNullException("errorMessage");
		}
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		if (undeliveredEvents == null)
		{
			throw new ArgumentNullException("undeliveredEvents");
		}
		ClassName = className;
		ErrorMessage = errorMessage;
		Exception = exception;
		UndeliveredEvents = undeliveredEvents;
	}
}
