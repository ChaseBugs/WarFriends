using System;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

public class EventStoreException : Exception
{
	public EventStoreException(string message)
		: base(message)
	{
	}

	public EventStoreException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
