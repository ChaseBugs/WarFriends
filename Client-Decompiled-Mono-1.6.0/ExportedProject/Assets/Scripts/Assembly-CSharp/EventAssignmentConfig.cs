using System;
using Newtonsoft.Json;

[Serializable]
public class EventAssignmentConfig
{
	public string type;

	public int target;

	[JsonProperty("progress")]
	public int eventPointsReward;

	public GameRewardData reward;
}
