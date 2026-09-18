using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DatabasePlayerMissionLeaderboard
{
	public long fbId;

	public string id;

	public MissionsManager.MissionManagerData missionData;

	public string name;

	public CamosManager.DecalManagerData decalData;

	internal static DatabasePlayerMissionLeaderboard CreateFromDatabase(JToken item)
	{
		DatabasePlayerMissionLeaderboard databasePlayerMissionLeaderboard = new DatabasePlayerMissionLeaderboard();
		if (item["PlayerId"] != null)
		{
			databasePlayerMissionLeaderboard.id = StringParser.ParseString("PlayerId", "S", item, string.Empty);
		}
		if (item["PlayerName"] != null)
		{
			databasePlayerMissionLeaderboard.name = StringParser.ParseString("PlayerName", "S", item, string.Empty);
		}
		databasePlayerMissionLeaderboard.fbId = ((item["FacebookId"] == null) ? (-1) : StringParser.ParseLong("FacebookId", "S", item));
		if (item["MissionManagerData"] != null)
		{
			string value = StringParser.ParseString("MissionManagerData", "S", item, string.Empty);
			try
			{
				databasePlayerMissionLeaderboard.missionData = JsonConvert.DeserializeObject<MissionsManager.MissionManagerData>(value);
			}
			catch (Exception exception)
			{
				Debug.LogError("Bad Mission Manager Data");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, "Bad mission manager data, data= " + StringParser.ParseString("MissionManagerData", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		if (item["DecalManagerData"] != null)
		{
			try
			{
				databasePlayerMissionLeaderboard.decalData = JsonConvert.DeserializeObject<CamosManager.DecalManagerData>(StringParser.ParseString("DecalManagerData", "S", item, string.Empty));
			}
			catch (Exception exception2)
			{
				Debug.LogError("Bad Decal Manager Data");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception2, "Bad Decal Manager data, data= " + StringParser.ParseString("DecalManagerData", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		return databasePlayerMissionLeaderboard;
	}

	internal int GetMissionScore(int missionIndex)
	{
		if (missionData != null && missionData.missionData.ContainsKey(missionIndex))
		{
			return Convert.ToInt32(missionData.missionData[missionIndex].highscore);
		}
		return 0;
	}
}
