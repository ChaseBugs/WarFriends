using System.Xml.Linq;
using Amazon.Util.Internal;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

public class MobileAnalyticsManagerConfig
{
	private const int defaultSessionTimeout = 5;

	private const int defaultMaxDBSize = 5242880;

	private const double defaultDBWarningThreshold = 0.9;

	private const int defaultMaxRequestSize = 102400;

	private const bool defaultAllowUseDataNetwork = false;

	private const string mobileAnalyticsKey = "mobileAnalytics";

	public int SessionTimeout { get; set; }

	public int MaxDBSize { get; set; }

	public double DBWarningThreshold { get; set; }

	public int MaxRequestSize { get; set; }

	public bool AllowUseDataNetwork { get; set; }

	public MobileAnalyticsManagerConfig()
	{
		SessionTimeout = 5;
		MaxDBSize = 5242880;
		DBWarningThreshold = 0.9;
		MaxRequestSize = 102400;
		AllowUseDataNetwork = false;
		XElement serviceSection = new RootConfig().GetServiceSection("mobileAnalytics");
		if (serviceSection != null)
		{
			MobileAnalyticsManagerConfigSectionRoot mobileAnalyticsManagerConfigSectionRoot = new MobileAnalyticsManagerConfigSectionRoot(serviceSection);
			if (mobileAnalyticsManagerConfigSectionRoot.SectionConfig != null)
			{
				Configure(mobileAnalyticsManagerConfigSectionRoot.SectionConfig);
			}
		}
	}

	internal void Configure(MobileAnalyticsManagerConfigSection section)
	{
		SessionTimeout = section.SessionTimeout ?? 5;
		MaxDBSize = section.MaxDBSize ?? 5242880;
		DBWarningThreshold = section.DBWarningThreashold ?? 0.9;
		MaxRequestSize = section.MaxRequestSize ?? 102400;
		AllowUseDataNetwork = section.AllowUseDataNetwork ?? false;
	}
}
