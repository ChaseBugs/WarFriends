using Amazon.Runtime;
using Amazon.Util.Internal;

namespace Amazon.MobileAnalytics;

public class AmazonMobileAnalyticsConfig : ClientConfig
{
	private static readonly string UserAgentString = InternalSDKUtils.BuildUserAgentString("3.3.1.17");

	private string _userAgent = UserAgentString;

	public override string RegionEndpointServiceName => "mobileanalytics";

	public override string ServiceVersion => "2014-06-05";

	public override string UserAgent => _userAgent;

	public AmazonMobileAnalyticsConfig()
	{
		base.AuthenticationServiceName = "mobileanalytics";
	}
}
