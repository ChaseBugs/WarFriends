using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
public class EventAssignmentConfig
{
	public string type;

	public int target;

	public string param;

	public int day;

	public string assignmentDescription;

	[JsonProperty]
	public int eventPointsReward;

	public GameRewardData reward;
}
