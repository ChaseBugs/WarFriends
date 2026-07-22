using System;
using Newtonsoft.Json;

[Serializable]
public class MissionUnit
{
	[JsonProperty]
	public int behaviourIndex;

	[JsonProperty]
	public bool isVeteran;

	[JsonProperty]
	public bool isElite;

	[JsonProperty]
	public int level;
}
