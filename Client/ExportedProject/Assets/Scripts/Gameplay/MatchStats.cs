using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class MatchStats
{
	public int missionsPlayed;

	public int mmmGames;

	public int battlesWonRanked;

	public int battlesLostRanked;

	public int battlesWonArena;

	public int battlesLostArena;

	public int flawlessRuns;

	public float deathMatchWinLooseStreak;

	public float deathMatchOfflineWinLooseStreak;

	public float deathMatchLossesInRow;

	public int battlesWon;

	public int battlesLost;

	public int battlesLostInRow;

	public int kills;

	public int vehicleDestroyed;

	public int hits;

	public int shotsFired;

	public int scorestreakGained;

	public int cratesStolen;

	public int cardsPlayed;

	public Dictionary<string, int> cardsPlayedSeparately = new Dictionary<string, int>();

	public Dictionary<int, int> weaponKills = new Dictionary<int, int>();

	public Dictionary<int, int> unitsDeployedSpecific = new Dictionary<int, int>();

	public Dictionary<int, int> unitsSpawnedSpecific = new Dictionary<int, int>();

	[FormerlySerializedAs("deployClicks")]
	public int secondsPlayed;

	[FormerlySerializedAs("secondsPlayed")]
	public int missionSucces;

	[FormerlySerializedAs("missionSucces")]
	public int missionsSolo;

	[FormerlySerializedAs("missionsSolo")]
	public int missionsCoop;

	[FormerlySerializedAs("missionsCoop")]
	public int missionsHeroic;

	public Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;

	[FormerlySerializedAs("missionsHeroic")]
	public int deployClicks;

	public Dictionary<LevelBehaviour.UnitType, int> unitsSpawnedByType
	{
		get
		{
			Dictionary<LevelBehaviour.UnitType, int> dictionary = new Dictionary<LevelBehaviour.UnitType, int>();
			foreach (object value in Enum.GetValues(typeof(LevelBehaviour.UnitType)))
			{
				LevelBehaviour.UnitType key = (LevelBehaviour.UnitType)value;
				dictionary[key] = 0;
			}
			foreach (KeyValuePair<int, int> item in unitsSpawnedSpecific)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[item.Key];
				dictionary[levelBehaviour.unitType] += item.Value;
			}
			return dictionary;
		}
	}

	public Dictionary<WeaponCategory, int> weaponTypeKills
	{
		get
		{
			Dictionary<WeaponCategory, int> dictionary = new Dictionary<WeaponCategory, int>();
			foreach (object value in Enum.GetValues(typeof(WeaponCategory)))
			{
				WeaponCategory key = (WeaponCategory)value;
				dictionary[key] = 0;
			}
			foreach (KeyValuePair<int, int> weaponKill in weaponKills)
			{
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[weaponKill.Key];
				dictionary[weaponLevelsSetup.BHCEOOLEHHG] += weaponKill.Value;
			}
			return dictionary;
		}
	}

	public int unitsDeployed
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, int> item in unitsDeployedSpecific)
			{
				num += item.Value;
			}
			return num;
		}
	}

	public int unitsSpawned
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, int> item in unitsSpawnedSpecific)
			{
				num += item.Value;
			}
			return num;
		}
	}

	public int soldierUnitsDeployed
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, int> item in unitsDeployedSpecific)
			{
				if (LevelManager.instance.behaviours[item.Key].isSoldier)
				{
					num += item.Value;
				}
			}
			return num;
		}
	}

	public int soldierUnitsSpawned
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, int> item in unitsSpawnedSpecific)
			{
				if (LevelManager.instance.behaviours[item.Key].isSoldier)
				{
					num += item.Value;
				}
			}
			return num;
		}
	}

	public int vehiclesDeployed
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, int> item in unitsDeployedSpecific)
			{
				if (!LevelManager.instance.behaviours[item.Key].isSoldier)
				{
					num += item.Value;
				}
			}
			return num;
		}
	}

	public int vehiclesSpawned
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, int> item in unitsSpawnedSpecific)
			{
				if (!LevelManager.instance.behaviours[item.Key].isSoldier)
				{
					num += item.Value;
				}
			}
			return num;
		}
	}

	public MatchStats()
	{
		foreach (object value in Enum.GetValues(typeof(WeaponCategory)))
		{
			WeaponCategory key = (WeaponCategory)value;
			weaponTypeKills[key] = 0;
		}
		allGainedRibbons = new Dictionary<SkillShot.SkillShotType, int>();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			unitsDeployedSpecific[behaviour.indexInLevelsManager] = 0;
			unitsSpawnedSpecific[behaviour.indexInLevelsManager] = 0;
		}
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			weaponKills[weaponLevelsSetup.indexInLevelManager] = 0;
		}
	}

	public void DeployUnit(int indexInlevelManager, int count, bool clicked)
	{
		unitsDeployedSpecific[indexInlevelManager]++;
		unitsSpawnedSpecific[indexInlevelManager] += count;
		if (clicked)
		{
			deployClicks++;
		}
	}

	public void PlayCard(Card card)
	{
		cardsPlayed++;
		if (!card.isBuddyCard)
		{
			if (!cardsPlayedSeparately.ContainsKey(card.id))
			{
				cardsPlayedSeparately[card.id] = 1;
			}
			else
			{
				cardsPlayedSeparately[card.id]++;
			}
		}
	}
}
