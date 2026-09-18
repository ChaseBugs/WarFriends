using System;
using Newtonsoft.Json;

[Serializable]
public class MissionDefinitionEvent
{
	public float time;

	public string behaviour;

	public int level;

	public bool isCardUnit;

	public int count;

	public string card;

	[NonSerialized]
	[JsonIgnore]
	public bool used;

	[NonSerialized]
	[JsonIgnore]
	public int spawned;
}
