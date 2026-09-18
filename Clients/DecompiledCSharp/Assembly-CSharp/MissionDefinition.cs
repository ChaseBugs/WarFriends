using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class MissionDefinition
{
	[NonSerialized]
	[JsonIgnore]
	public int map;

	[NonSerialized]
	[JsonIgnore]
	public int objective;

	[NonSerialized]
	[JsonIgnore]
	public float maxTimeForMission;

	[NonSerialized]
	[JsonIgnore]
	public int scoreFor1Star;

	[NonSerialized]
	[JsonIgnore]
	public int scoreFor2Stars;

	[NonSerialized]
	[JsonIgnore]
	public int scoreFor3Stars;

	[NonSerialized]
	[JsonIgnore]
	public int maxUnits;

	[NonSerialized]
	[JsonIgnore]
	public int rewardWarbucks;

	[NonSerialized]
	[JsonIgnore]
	public int rewardGold;

	[NonSerialized]
	[JsonIgnore]
	public int rewardXP;

	[NonSerialized]
	[JsonIgnore]
	public MissionDefinitionMissionTypes type;

	[NonSerialized]
	[JsonIgnore]
	public float hpFract;

	[NonSerialized]
	[JsonIgnore]
	public float timeFract;

	[NonSerialized]
	[JsonIgnore]
	public int recommendedAP;

	public int playerEnergy;

	public int botEnergy;

	public List<MissionDefinitionBehaviour> behaviours;

	public List<MissionDefinitionInitialUnit> initialUnits;

	public List<MissionDefinitionEvent> events;

	public List<MissionDefinitionShieldState> playerShieldStates;

	public List<MissionDefinitionShieldState> botShieldStates;

	public MissionDefinitionBot bot;

	public Mission AddMissionComponent(GameObject go)
	{
		Mission result = null;
		switch (type)
		{
		case MissionDefinitionMissionTypes.KillOpponent:
			result = go.AddComponent(typeof(BotMission)) as Mission;
			break;
		case MissionDefinitionMissionTypes.SurviveXSeconds:
			result = go.AddComponent(typeof(SurviveMission)) as Mission;
			break;
		case MissionDefinitionMissionTypes.KillXEnemies:
			result = go.AddComponent(typeof(KillMission)) as Mission;
			break;
		case MissionDefinitionMissionTypes.Score:
			result = go.AddComponent(typeof(ScoreMission)) as Mission;
			break;
		default:
			Debug.LogError("UNKNOWN MISSION TYPE!!!");
			break;
		}
		return result;
	}

	public void OnPlayMission()
	{
		foreach (MissionDefinitionEvent @event in events)
		{
			@event.used = false;
			@event.spawned = 0;
		}
	}
}
