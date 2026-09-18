using System;
using Google2u;
using UnityEngine;

public class CurrentBundleVersion : Singleton<CurrentBundleVersion>
{
	public string revision;

	public string ourVersion;

	private string mFinalVersion;

	private string mFinalVersionShort;

	public string version
	{
		get
		{
			if (mFinalVersion == null)
			{
				mFinalVersion = GetModifiedVersion();
			}
			return mFinalVersion;
		}
	}

	public string shortVersion
	{
		get
		{
			if (mFinalVersionShort == null)
			{
				string[] value = version.Split('.');
				mFinalVersionShort = string.Join(".", value, 0, 3);
			}
			return mFinalVersionShort;
		}
	}

	public string photonVersion
	{
		get
		{
			string empty = string.Empty;
			empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersionAndroid).VALUE;
			return empty + ".c";
		}
	}

	public string matchMakingVersionRanked
	{
		get
		{
			string empty = string.Empty;
			empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersionAndroidMatchMaking).VALUE;
			return empty + ".c";
		}
	}

	private string GetModifiedVersion()
	{
		string originalVersion = GetOriginalVersion();
		Debug.LogWarningFormat("CurrentBundleVersion.GetModifiedVersion - version is '{0}'", originalVersion ?? "null");
		string[] array = originalVersion.Split('.');
		string value = array[0];
		float num = Convert.ToSingle(value);
		array[0] = ((!(num > 100f)) ? num : (num - 100f)).ToString();
		return string.Join(".", array);
	}

	private string GetOriginalVersion()
	{
		if (string.IsNullOrEmpty(ourVersion))
		{
			ourVersion = "0.0";
		}
		return BuildVersion.ClientVersion + "." + ourVersion;
	}
}
