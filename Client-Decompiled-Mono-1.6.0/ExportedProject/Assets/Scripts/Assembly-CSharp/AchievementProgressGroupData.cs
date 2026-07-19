using System;
using System.ComponentModel;
using Newtonsoft.Json;

[Serializable]
public sealed class AchievementProgressGroupData
{
	public const int DefaultLocalOffset = int.MinValue;

	public int id;

	[JsonProperty("offset", DefaultValueHandling = DefaultValueHandling.Populate)]
	[DefaultValue(0)]
	public int localOffset = int.MinValue;

	[JsonProperty("value")]
	public int localCurrentValue;

	[JsonProperty("progress")]
	public AchievementProgressData[] achievementProgressData = new AchievementProgressData[0];
}
