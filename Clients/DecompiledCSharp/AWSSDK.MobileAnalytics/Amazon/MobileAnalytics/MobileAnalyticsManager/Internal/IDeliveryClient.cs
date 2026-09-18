using System;
using Amazon.MobileAnalytics.Model;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

public interface IDeliveryClient : IDisposable
{
	void EnqueueEventsForDelivery(Event eventObject);

	void AttemptDelivery();
}
