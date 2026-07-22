using System;
using System.ComponentModel;
using Newtonsoft.Json;

[Serializable]
public sealed class AchievementProgressGroupData
{
	public const int DefaultLocalOffset = int.MinValue;

	public int id;

	[DefaultValue(0)]
	[JsonProperty("offset", DefaultValueHandling = DefaultValueHandling.Populate)]
	public int localOffset = int.MinValue;

	[JsonProperty("value")]
	public int localCurrentValue;

	[JsonProperty("progress")]
	public AchievementProgressData[] achievementProgressData = new AchievementProgressData[0];
}
