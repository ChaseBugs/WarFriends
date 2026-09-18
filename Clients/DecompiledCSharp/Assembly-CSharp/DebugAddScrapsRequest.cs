using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugAddScrapsRequest
{
	public static Action Response;

	public static void Send()
	{
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.DebugAddScraps, new List<Tuple<string, string>>());
	}

	public static void OnSuccess(Dictionary<string, object> response)
	{
		int num = StringParser.ParseInt(response["Scraps"]);
		Debug.Log("On Debug Add Scraps Request: " + num);
		Singleton<Wallet>.instance.AddScraps(num);
		if (Response != null)
		{
			Response();
		}
	}
}
