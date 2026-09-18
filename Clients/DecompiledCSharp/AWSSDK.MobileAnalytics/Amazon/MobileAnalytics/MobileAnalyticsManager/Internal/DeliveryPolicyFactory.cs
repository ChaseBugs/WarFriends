namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

public class DeliveryPolicyFactory : IDeliveryPolicyFactory
{
	private readonly bool IsDataNetworkAllowed;

	public DeliveryPolicyFactory(bool IsDataNetworkAllowed)
	{
		this.IsDataNetworkAllowed = IsDataNetworkAllowed;
	}

	public IDeliveryPolicy NewConnectivityPolicy()
	{
		return new ConnectivityPolicy(IsDataNetworkAllowed);
	}
}
