using System.Xml.Linq;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

internal class MobileAnalyticsManagerConfigSectionRoot
{
	private const string mobileAnalyticsKey = "mobileAnalytics";

	public MobileAnalyticsManagerConfigSection SectionConfig { get; set; }

	public MobileAnalyticsManagerConfigSectionRoot(XElement section)
	{
		if (section != null)
		{
			SectionConfig = AWSConfigs.GetObject<MobileAnalyticsManagerConfigSection>(section, "mobileAnalytics");
		}
	}
}
