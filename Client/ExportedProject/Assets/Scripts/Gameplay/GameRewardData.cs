using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Serializable]
public class GameRewardData
{
	public int type;

	[JsonProperty("d")]
	public JToken data;
}
