using System.Collections.Generic;

public class MatchStats
{
	public int missionsPlayed;

	public int mmmGames;

	public int battlesWonRanked;

	public int battlesLostRanked;

	public int battlesWonArena;

	public int battlesLostArena;

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

	public Dictionary<string, int> cardsPlayedSeparately;

	public Dictionary<int, int> weaponKills;

	public Dictionary<int, int> unitsDeployedSpecific;

	public Dictionary<int, int> unitsSpawnedSpecific;

	public int deployClicks;

	public int secondsPlayed;

	public int missionSucces;

	public int missionsSolo;

	public int missionsCoop;

	public int missionsHeroic;

	public Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;

	public Dictionary<LevelBehaviour.UnitType, int> unitsSpawnedByType => null;

	public Dictionary<WeaponCategory, int> weaponTypeKills => null;

	public int unitsDeployed => 0;

	public int unitsSpawned => 0;

	public int soldierUnitsDeployed => 0;

	public int soldierUnitsSpawned => 0;

	public int vehiclesDeployed => 0;

	public int vehiclesSpawned => 0;

	public void PlayCard(Card card)
	{
	}

	public void SaveCurrentPlayerData(Dictionary<int, int> weaponKillsData, Dictionary<int, int> unitsDeployClicksData, Dictionary<int, int> unitsSpawnData, int deployClicksData)
	{
	}
}
