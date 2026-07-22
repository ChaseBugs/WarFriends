using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
public class CommanderObjectiveData
{
	[JsonProperty]
	public int[] myValue;

	[JsonProperty]
	public int[] recruitsValue;

	[JsonProperty]
	public int tier;
}
