using System;
using Amazon.MobileAnalytics.Model;
using Amazon.Runtime;

namespace Amazon.MobileAnalytics;

public interface IAmazonMobileAnalytics : IAmazonService, IDisposable
{
	void PutEventsAsync(PutEventsRequest request, AmazonServiceCallback<PutEventsRequest, PutEventsResponse> callback, AsyncOptions options = null);
}
