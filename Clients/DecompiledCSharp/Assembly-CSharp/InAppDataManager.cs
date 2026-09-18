using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;

[Skip]
public class InAppDataManager : DatabaseSerializedObjectGeneric<InAppDataManager.InAppData>
{
	[Skip]
	public class InAppData
	{
		public Dictionary<string, InAppInfo> inapps;
	}

	[Skip]
	public class InAppInfo
	{
		public int left;

		public Dictionary<string, string> days;

		public int currentDay => 7 - left;

		public bool isActive => left > 0;
	}

	public string GetDailyInAppId(string id)
	{
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return id;
		}
		id = GetOtherInAppFromABTest(id);
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return id;
		}
		return null;
	}

	private string GetOtherInAppFromABTest(string id)
	{
		if (id.StartsWith("b"))
		{
			return id.Substring(1);
		}
		return "b" + id;
	}

	public InAppInfo GetDailyInApp(string id)
	{
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return data.inapps[id];
		}
		id = GetOtherInAppFromABTest(id);
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return data.inapps[id];
		}
		return null;
	}

	public void AddDailyGoldBooster()
	{
		if (data.inapps == null)
		{
			data.inapps = new Dictionary<string, InAppInfo>();
		}
		InAppInfo inAppInfo = new InAppInfo();
		inAppInfo.days = new Dictionary<string, string>();
		inAppInfo.left = 7;
		data.inapps.Add(Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold7daily1).NAME, inAppInfo);
	}
}
