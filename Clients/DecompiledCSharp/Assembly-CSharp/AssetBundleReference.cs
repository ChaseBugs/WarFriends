using System;

[Serializable]
public class AssetBundleReference
{
	public bool cached;

	public bool isLocal;

	public string name;

	public float size;

	public bool shouldBeDownloaded => isLocal || PlayerAnalytics.instance.tutorialFinished;

	public string url => Singleton<AssetBundleManager>.instance.locaDownloadingUrl + name;

	public override string ToString()
	{
		return name;
	}
}
