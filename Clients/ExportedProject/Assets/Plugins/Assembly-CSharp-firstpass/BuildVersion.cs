using UnityEngine;

public class BuildVersion
{
	private static string bundleIdentifier;

	private static string version;

	private static int versionCode;

	private static string clientVersion;

	public static string BundleIdentifier => bundleIdentifier;

	public static string Version => version;

	public static int VersionCode => versionCode;

	public static string ClientVersion => clientVersion;

	static BuildVersion()
	{
		Reload();
	}

	public static void Reload()
	{
		Debug.Log("BuildVersion - Reload");
		bundleIdentifier = string.Empty;
		version = string.Empty;
		versionCode = 0;
		TextAsset textAsset = Resources.Load("BuildVersion", typeof(TextAsset)) as TextAsset;
		if (textAsset != null)
		{
			string[] array = textAsset.text.Trim().Split(';');
			bundleIdentifier = array[0];
			version = array[1];
			int.TryParse(array[2], out versionCode);
			clientVersion = array[3];
		}
		else
		{
			Debug.LogError("BuildVersion.Reload - textAsset not found!");
		}
	}
}
