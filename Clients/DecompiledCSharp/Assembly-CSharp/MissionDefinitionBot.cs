using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class MissionDefinitionBot
{
	public string name;

	public int difficulty;

	public int level;

	public float hpReduction;

	public string camo;

	public string headAccesory;

	public string helmet;

	public string powerBand;

	public bool useDefinedCards;

	public List<string> cards = new List<string>();

	[NonSerialized]
	[JsonIgnore]
	public string[] botVisuals;
}
