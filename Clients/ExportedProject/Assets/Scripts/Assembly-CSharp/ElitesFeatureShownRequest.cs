using System.Collections.Generic;
using UnityEngine;

public class ElitesFeatureShownRequest
{
	public static void Send()
	{
		PlayerAnalytics.instance.data.elitesShown = true;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.ElitesFeatureShown, new List<Tuple<string, string>>());
	}

	public static void OnSuccess(Dictionary<string, object> response)
	{
		Debug.Log("Elites Feature Shown Request Success");
	}
}
