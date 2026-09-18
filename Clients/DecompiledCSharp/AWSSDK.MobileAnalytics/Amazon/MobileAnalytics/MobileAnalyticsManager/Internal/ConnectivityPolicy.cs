using Amazon.Runtime.Internal.Util;
using Amazon.Util.Storage.Internal;
using UnityEngine;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

public class ConnectivityPolicy : IDeliveryPolicy
{
	private readonly bool IsDataAllowed;

	private Logger _logger = Logger.GetLogger(typeof(ConnectivityPolicy));

	public ConnectivityPolicy(bool IsDataAllowed)
	{
		this.IsDataAllowed = IsDataAllowed;
	}

	public bool IsAllowed()
	{
		return HasNetworkConnectivity();
	}

	private bool HasNetworkConnectivity()
	{
		NetworkReachability reachability = NetworkInfo.Reachability;
		bool result = false;
		switch (reachability)
		{
		case NetworkReachability.NotReachable:
			result = false;
			break;
		case NetworkReachability.ReachableViaLocalAreaNetwork:
			result = true;
			break;
		case NetworkReachability.ReachableViaCarrierDataNetwork:
			result = IsDataAllowed;
			break;
		}
		return result;
	}

	public void HandleDeliveryAttempt(bool isSuccessful)
	{
	}
}
