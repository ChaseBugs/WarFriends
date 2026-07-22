using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
public class GameRewardData
{
	public int type;

	public int doubleFor;

	[JsonProperty]
	public JToken data;
}
