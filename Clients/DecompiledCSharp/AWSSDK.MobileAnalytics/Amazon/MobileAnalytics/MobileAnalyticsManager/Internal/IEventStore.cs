using System;
using System.Collections.Generic;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

public interface IEventStore : IDisposable
{
	long DatabaseSize { get; }

	void PutEvent(string value, string appId);

	List<JsonData> GetEvents(string appid, int maxAllowed);

	void DeleteEvent(List<string> rowIds);

	long NumberOfEvents(string appId);
}
