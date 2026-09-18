public class BundleVersionBindings
{
	protected static string m_bundleID;

	protected static string m_bundleVersion;

	public static string BundleID
	{
		get
		{
			if (m_bundleID == null)
			{
				m_bundleID = BuildVersion.BundleIdentifier;
			}
			return m_bundleID;
		}
	}

	public static string BundleVersion
	{
		get
		{
			m_bundleVersion = "999.99";
			return m_bundleVersion;
		}
	}

	public static bool pushNotificationEnabled => true;

	protected static string GetBundleInfo()
	{
		return string.Empty;
	}

	protected static void GetVersionInfo()
	{
		m_bundleVersion = string.Empty;
	}

	public static bool IsJailBreak()
	{
		return false;
	}

	public static bool IsValidContent()
	{
		return false;
	}

	public static bool DyLibFound()
	{
		return false;
	}

	public static bool IsDownloaded()
	{
		return false;
	}
}
