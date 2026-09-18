using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HordeMission : Mission
{
	public WaveManager.WaveDefinition waveDefinition;

	public override void PlayMission(bool isMaster)
	{
		base.PlayMission(isMaster);
		if (isMaster)
		{
			Singleton<WaveManager>.instance.waveDefinition = waveDefinition;
		}
	}

	public override void OpenMission(DatabasePlayer player, bool isInvite, bool isRematch, bool isHeroicMode)
	{
		base.OpenMission(player, isInvite, isRematch, isHeroicMode);
		if (isInvite)
		{
			Singleton<GameController>.instance.StartHostMultiplayer();
		}
		else if (!isRematch && Singleton<GameController>.instance.isCampaign)
		{
			Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
		}
	}

	public override void LoadMissionData(MissionDefinition missionDefinition)
	{
		base.LoadMissionData(missionDefinition);
		waveDefinition = new WaveManager.WaveDefinition();
		waveDefinition.behaviourDefinitions = new List<WaveManager.WaveBehaviourDefinition>();
		waveDefinition.maxEnemies = missionDefinition.maxUnits;
		waveDefinition.behaviourDefinitions = new List<WaveManager.WaveBehaviourDefinition>();
		foreach (MissionDefinitionBehaviour behaviour in missionDefinition.behaviours)
		{
			waveDefinition.behaviourDefinitions.Add(new WaveManager.WaveBehaviourDefinition
			{
				behaviourLevel = new WaveManager.BehaviourLevel
				{
					behaviorName = Mission.behavioursDictionary[behaviour.name].Value1.Name,
					upgradesSingleLevel = behaviour.level
				},
				sceneLimit = behaviour.sceneLimit,
				count = behaviour.missionLimit
			});
		}
	}

	public override void EndMission()
	{
		base.EndMission();
	}
}
