using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Serializable]
public class SavedMission
{
	[JsonProperty("type")]
	public string missionType;

	[JsonProperty("cnf")]
	public JToken missionConfig;

	public bool completedSolo;

	public bool completedCoop;
}
