using System;
using Newtonsoft.Json;
using UnityEngine.Serialization;

[Serializable]
public class EventAssignmentConfig
{
	public string type;

	public int target;

	[JsonProperty("progress")]
	[FormerlySerializedAs("day")]
	public int eventPointsReward;

	public GameRewardData reward;
}
