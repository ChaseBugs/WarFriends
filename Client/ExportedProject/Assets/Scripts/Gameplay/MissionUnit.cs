using System;
using Newtonsoft.Json;

[Serializable]
public class MissionUnit
{
	[JsonProperty("i")]
	public int behaviourIndex;

	[JsonProperty("vet")]
	public bool isVeteran;

	[JsonProperty("eli")]
	public bool isElite;

	[JsonProperty("lev")]
	public int level;
}
