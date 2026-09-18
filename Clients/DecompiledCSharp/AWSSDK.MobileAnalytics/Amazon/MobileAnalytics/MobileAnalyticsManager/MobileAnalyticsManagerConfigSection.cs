namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

internal class MobileAnalyticsManagerConfigSection
{
	public int? SessionTimeout { get; set; }

	public int? MaxDBSize { get; set; }

	public double? DBWarningThreashold { get; set; }

	public int? MaxRequestSize { get; set; }

	public bool? AllowUseDataNetwork { get; set; }
}
