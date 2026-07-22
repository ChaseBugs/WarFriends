using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
public class SpecialOpsData
{
	[JsonProperty]
	public bool shouldSendSpecialOpsEvents;

	[JsonProperty]
	public string id;

	[JsonProperty]
	public bool isNew;

	[JsonProperty]
	public int progress;

	[JsonProperty]
	public int LoyaltyPoints;

	[JsonProperty]
	public int NextSO;
}
