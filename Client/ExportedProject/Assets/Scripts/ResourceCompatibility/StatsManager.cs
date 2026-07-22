using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;

public class StatsManager : DatabaseSerializedObjectGeneric<StatsManager.StatisticsData>
{
	[Preserve]
	public class StatisticsData
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

		public int unitsDeployed;

		public int soldierUnitsDeployed;

		public int soldierUnitsSpawned;

		public int vehiclesDeployed;

		public int cardsPlayed;

		public int scorestreakGained;

		public int cratesStolen;

		public int squadPointsTotal;

		public Dictionary<int, int> unitsDeployedSpecific;

		public Dictionary<int, int> weaponKills;

		public Dictionary<string, int> cardsPlayedSeparately;

		public int secondsPlayed;

		public int maxMedals;

		public League bestLeague;

		public int claimedRewards;

		public int missionsSolo;

		public int missionsCoop;

		public int missionsHeroic;

		public int missionSucces;

		public int arenaAllTimeRuns;

		public int arenaBattlesPlayed;

		public int arenaWins;

		public int arenaFlawless;

		public int arenaLootboxes;

		public Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;

		public float deathmatchOfflineWinLooseStreakRatio => 0f;

		public int battlesPlayed => 0;

		public float accuracy => 0f;

		public float winLoseRatio => 0f;

		[JsonIgnore]
		public int favouriteUnitIndex => 0;

		[JsonIgnore]
		public int favouriteWeaponIndex => 0;

		[JsonIgnore]
		public string favouriteWarcardId => null;
	}

	public MatchStats matchStats;

	private WinStreakManager mWinStreakManager;

	private static StatsManager mInstance;

	public WinStreakManager.WinStreak winStreak
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static StatsManager instance => null;

	public int totalWins => 0;

	public int totalGames => 0;

	public int missionsPlayed
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int missionSucces
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int matchmadeGames
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float deathMatchLossesInRow => 0f;

	public float deathMatchOfflineWinLooseStreak
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public int battlesPlayed => 0;

	public int battlesWon
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int battlesLostRanked
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int battlesWonRanked
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int battlesLostArena
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int battlesWonArena
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int battlesLost
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int battlesLostInRow
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float winLoseRatio => 0f;

	public int kills
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int vehicleDestroyed
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int hits
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int shots
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float accuracy => 0f;

	public int unitsDeployedTotal
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int soldierUnitsDeployedTotal
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int soldierUnitsSpawnedTotal
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int vehiclesDeployedTotal
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int cardsPlayed
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int scorestreakGained
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int cratesStolen
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Dictionary<WeaponCategory, int> mWeaponTypeKills => null;

	public long globalXP => 0L;

	public long globalPXP => 0L;

	public int secondsPlayed
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int assignmentsCompleted => 0;

	public int claimedRewards
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int maxMedals
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public League bestLeague
	{
		get
		{
			return default(League);
		}
		set
		{
		}
	}

	public int armyPowerX10 => 0;

	public int weaponsPurchased => 0;

	public int weaponsUpgrades => 0;

	public int unitsPurchased => 0;

	public int unitsUpgrades => 0;

	public int soldierUnitsUpgrades => 0;

	public int mechanicalUnitsUpgrades => 0;

	public int customisationsPurchased => 0;

	public int weaponsPurchaseCount => 0;

	public int weaponsUpgradesCount => 0;

	public int unitPurchaseCount => 0;

	public int unitUpgradesCount => 0;

	public int customisationsCount => 0;

	public int missionsCompleted
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int missionsCoop
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int missionsHeroic
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int arenaRuns
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int arenaBattles
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int arenaWins
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int arenaFlawless
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int arenaLootboxes
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void CheckExisting()
	{
	}

	public void OnDestroy()
	{
	}

	private void SetUnitsDeploted(int indexInLevelManager, int value)
	{
	}

	private void SetWeaponKills(int indexInLevelManager, int numberOfKills)
	{
	}

	public int GetWeaponKills(WeaponCategory category)
	{
		return 0;
	}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void OnGameStarted()
	{
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 pos)
	{
	}

	public void RecomputeStatistics(GameController.ALOAMODMHMO gameEndReason)
	{
	}

	private void IncrementStatistics(GameController.ALOAMODMHMO gameEndReason)
	{
	}

	public void UpdatePlayerLeague()
	{
	}

	public void UpdatePlayerMedals()
	{
	}
}
