using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class GetArenaLeaderboardsRequest
{
	public static Action Response;

	public static void SendRequest()
	{
		List<DatabasePlayerData> arenaLeaderboard = Singleton<ServerResultsCache>.instance.GetArenaLeaderboard();
		if (arenaLeaderboard != null)
		{
			if (Response != null)
			{
				Response();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetArenaLeaderboards, new List<Tuple<string, string>>());
		}
	}

	public static void OnSuccess(Dictionary<string, object> response)
	{
		List<DatabasePlayerData> list = new List<DatabasePlayerData>();
		JArray jArray = (JArray)response["Items"];
		foreach (JToken item2 in jArray)
		{
			DatabasePlayerData item = DatabasePlayerData.CreateFromDatabase(item2);
			list.Add(item);
		}
		Debug.Log("On Get Arena Leaderboards: CNT =  " + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayerData>>("arenaLeaderboard", list, DateTime.Now.AddMinutes(2.0));
		if (Response != null)
		{
			Response();
		}
	}
}
