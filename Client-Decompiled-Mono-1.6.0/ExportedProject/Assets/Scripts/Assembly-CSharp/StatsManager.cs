using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class StatsManager : DatabaseSerializedObjectGeneric<StatsManager.StatisticsData>
{
	public class StatisticsData
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

		public int unitsDeployed;

		public int soldierUnitsDeployed;

		public int vehiclesDeployed;

		public int cardsPlayed;

		public int scorestreakGained;

		public int cratesStolen;

		public int squadPointsTotal;

		public Dictionary<int, int> unitsDeployedSpecific = new Dictionary<int, int>();

		public Dictionary<int, int> weaponKills;

		public Dictionary<string, int> cardsPlayedSeparately = new Dictionary<string, int>();

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

		public float deathmatchOfflineWinLooseStreakRatio
		{
			get
			{
				float fLOATVALUE = Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakMax).FLOATVALUE;
				float fLOATVALUE2 = Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakMin).FLOATVALUE;
				float value = (deathMatchOfflineWinLooseStreak - fLOATVALUE2) / (fLOATVALUE - fLOATVALUE2);
				return Mathf.Clamp01(value);
			}
		}

		public int battlesPlayed
		{
			get
			{
				return battlesWon + battlesLost;
			}
		}

		public float accuracy
		{
			get
			{
				if (shotsFired == 0)
				{
					return -1f;
				}
				return (float)hits / (float)shotsFired;
			}
		}

		public float winLoseRatio
		{
			get
			{
				int num = battlesLostRanked;
				if (num == 0)
				{
					num = 1;
				}
				return (float)battlesWonRanked / (float)num;
			}
		}

		[JsonIgnore]
		public int favouriteUnitIndex
		{
			get
			{
				if (unitsDeployedSpecific == null)
				{
					return -1;
				}
				int result = 0;
				int num = 0;
				foreach (KeyValuePair<int, int> item in unitsDeployedSpecific)
				{
					if (num < item.Value)
					{
						num = item.Value;
						result = item.Key;
					}
				}
				return result;
			}
		}

		[JsonIgnore]
		public int favouriteWeaponIndex
		{
			get
			{
				if (weaponKills == null)
				{
					return -1;
				}
				int result = 0;
				int num = 0;
				foreach (KeyValuePair<int, int> weaponKill in weaponKills)
				{
					if (num < weaponKill.Value)
					{
						num = weaponKill.Value;
						result = weaponKill.Key;
					}
				}
				return result;
			}
		}

		[JsonIgnore]
		public string favouriteWarcardId
		{
			get
			{
				if (cardsPlayedSeparately == null)
				{
					return null;
				}
				string result = string.Empty;
				int num = 0;
				foreach (KeyValuePair<string, int> item in cardsPlayedSeparately)
				{
					if (num < item.Value)
					{
						num = item.Value;
						result = item.Key;
					}
				}
				return result;
			}
		}
	}

	public MatchStats matchStats;

	private WinStreakManager mWinStreakManager;

	private static StatsManager mInstance;

	public WinStreakManager.WinStreak winStreak
	{
		get
		{
			return mWinStreakManager.data;
		}
		set
		{
			mWinStreakManager.data.WinCount = value.WinCount;
			mWinStreakManager.data.TimeStamp = value.TimeStamp;
		}
	}

	public static StatsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((StatsManager)UnityEngine.Object.FindObjectsOfType(typeof(StatsManager))[0]);
			return mInstance;
		}
	}

	public int totalWins
	{
		get
		{
			return missionSucces + battlesWon;
		}
	}

	public int totalGames
	{
		get
		{
			return battlesPlayed + missionsPlayed;
		}
	}

	public int missionsPlayed
	{
		get
		{
			return data.missionsPlayed;
		}
		set
		{
			data.missionsPlayed = value;
		}
	}

	public int missionSucces
	{
		get
		{
			return data.missionSucces;
		}
		set
		{
			data.missionSucces = value;
		}
	}

	public int matchmadeGames
	{
		get
		{
			return data.mmmGames;
		}
		set
		{
			data.mmmGames = value;
		}
	}

	public float deathMatchLossesInRow
	{
		get
		{
			return data.deathMatchLossesInRow;
		}
	}

	public int battlesPlayed
	{
		get
		{
			return battlesWon + battlesLost;
		}
	}

	public int battlesWon
	{
		get
		{
			return data.battlesWon;
		}
		set
		{
			data.battlesWon = value;
		}
	}

	public int battlesLostRanked
	{
		get
		{
			return data.battlesLostRanked;
		}
		set
		{
			data.battlesLostRanked = value;
		}
	}

	public int battlesWonRanked
	{
		get
		{
			return data.battlesWonRanked;
		}
		set
		{
			data.battlesWonRanked = value;
		}
	}

	public int battlesLostArena
	{
		get
		{
			return data.battlesLostArena;
		}
		set
		{
			data.battlesLostArena = value;
		}
	}

	public int battlesWonArena
	{
		get
		{
			return data.battlesWonArena;
		}
		set
		{
			data.battlesWonArena = value;
		}
	}

	public int flawlessRuns
	{
		get
		{
			return data.flawlessRuns;
		}
		set
		{
			data.flawlessRuns = value;
		}
	}

	public int battlesLost
	{
		get
		{
			return data.battlesLost;
		}
		set
		{
			data.battlesLost = value;
		}
	}

	public int battlesLostInRow
	{
		get
		{
			return data.battlesLostInRow;
		}
		set
		{
			data.battlesLostInRow = value;
		}
	}

	public float winLoseRatio
	{
		get
		{
			return data.winLoseRatio;
		}
	}

	public int kills
	{
		get
		{
			return data.kills;
		}
		set
		{
			data.kills = value;
		}
	}

	public int vehicleDestroyed
	{
		get
		{
			return data.vehicleDestroyed;
		}
		set
		{
			data.vehicleDestroyed = value;
		}
	}

	public int hits
	{
		get
		{
			return data.hits;
		}
		set
		{
			data.hits = value;
		}
	}

	public int shots
	{
		get
		{
			return data.shotsFired;
		}
		set
		{
			data.shotsFired = value;
		}
	}

	public float accuracy
	{
		get
		{
			return (data.shotsFired != 0) ? Mathf.Clamp01((float)hits / (float)data.shotsFired) : (-1f);
		}
	}

	public int unitsDeployedTotal
	{
		get
		{
			return data.unitsDeployed;
		}
		set
		{
			data.unitsDeployed = value;
		}
	}

	public int soldierUnitsDeployedTotal
	{
		get
		{
			return data.soldierUnitsDeployed;
		}
		set
		{
			data.soldierUnitsDeployed = value;
		}
	}

	public int vehiclesDeployedTotal
	{
		get
		{
			return data.vehiclesDeployed;
		}
		set
		{
			data.vehiclesDeployed = value;
		}
	}

	public int cardsPlayed
	{
		get
		{
			return data.cardsPlayed;
		}
		set
		{
			data.cardsPlayed = value;
		}
	}

	public int scorestreakGained
	{
		get
		{
			return data.scorestreakGained;
		}
		set
		{
			data.scorestreakGained = value;
		}
	}

	public int cratesStolen
	{
		get
		{
			return data.cratesStolen;
		}
		set
		{
			data.cratesStolen = value;
		}
	}

	public Dictionary<WeaponCategory, int> mWeaponTypeKills
	{
		get
		{
			CheckExisting();
			Dictionary<WeaponCategory, int> dictionary = new Dictionary<WeaponCategory, int>();
			foreach (object value in Enum.GetValues(typeof(WeaponCategory)))
			{
				WeaponCategory key = (WeaponCategory)value;
				dictionary[key] = 0;
			}
			foreach (KeyValuePair<int, int> weaponKill in data.weaponKills)
			{
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[weaponKill.Key];
				dictionary[weaponLevelsSetup.BHCEOOLEHHG] += weaponKill.Value;
			}
			return dictionary;
		}
	}

	public long globalXP
	{
		get
		{
			return LevelManager.instance.experience;
		}
	}

	public int secondsPlayed
	{
		get
		{
			return data.secondsPlayed;
		}
		set
		{
			data.secondsPlayed = value;
		}
	}

	public int assignmentsCompleted
	{
		get
		{
			return AssignmentsManager.instance.GetCompletedAssignments();
		}
	}

	public int claimedRewards
	{
		get
		{
			return data.claimedRewards;
		}
		set
		{
			data.claimedRewards = value;
		}
	}

	public int maxMedals
	{
		get
		{
			return data.maxMedals;
		}
		set
		{
			data.maxMedals = value;
		}
	}

	public League bestLeague
	{
		get
		{
			return data.bestLeague;
		}
		set
		{
			data.bestLeague = value;
		}
	}

	public int armyPowerX10
	{
		get
		{
			return LevelManager.instance.armyPowerX10;
		}
	}

	public int weaponsPurchased
	{
		get
		{
			int num = 0;
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup.bought && weaponLevelsSetup.unlockLevel.displayNumber > 3)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int weaponsUpgrades
	{
		get
		{
			int num = 0;
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				num += (weaponLevelsSetup.bought ? (weaponLevelsSetup.weaponLevel - 1) : 0);
			}
			return num;
		}
	}

	public int unitsPurchased
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots.bought && behaviour.upgradeSlots.unlockLevel.displayNumber > 3)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int unitsUpgrades
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				num += behaviour.upgradeSlots.boughtIndex;
			}
			return num;
		}
	}

	public int soldierUnitsUpgrades
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.isSoldier)
				{
					num += behaviour.upgradeSlots.boughtIndex;
				}
			}
			return num;
		}
	}

	public int mechanicalUnitsUpgrades
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (!behaviour.isSoldier)
				{
					num += behaviour.upgradeSlots.boughtIndex;
				}
			}
			return num;
		}
	}

	public int customisationsPurchased
	{
		get
		{
			int num = 0;
			foreach (PlayerVisualCategory playerVisualCategory in CamosManager.instance.playerVisualCategories)
			{
				if (playerVisualCategory as PlayerVisualCategoryPowerBands != null)
				{
					continue;
				}
				foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
				{
					if (allVisual.isBought && (allVisual.priceGold > 0 || allVisual.priceWarbucks > 0))
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	public int weaponsPurchaseCount
	{
		get
		{
			int num = 0;
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup.unlockLevel.displayNumber > 3)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int weaponsUpgradesCount
	{
		get
		{
			int num = 0;
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				num += weaponLevelsSetup.maxWeaponLevel - 1;
			}
			return num;
		}
	}

	public int unitPurchaseCount
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots.unlockLevel.displayNumber > 3)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int unitUpgradesCount
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				num += behaviour.upgradeSlots.numberOfUpgrades - 1;
			}
			return num;
		}
	}

	public int customisationsCount
	{
		get
		{
			int num = 0;
			foreach (PlayerVisualCategory playerVisualCategory in CamosManager.instance.playerVisualCategories)
			{
				if (playerVisualCategory as PlayerVisualCategoryPowerBands != null)
				{
					continue;
				}
				foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
				{
					if (allVisual.priceGold > 0 || allVisual.priceWarbucks > 0)
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	public int missionsCompleted
	{
		get
		{
			return data.missionsSolo;
		}
		set
		{
			data.missionsSolo = value;
		}
	}

	public int missionsCoop
	{
		get
		{
			return data.missionsCoop;
		}
		set
		{
			data.missionsCoop = value;
		}
	}

	public int missionsHeroic
	{
		get
		{
			return data.missionsHeroic;
		}
		set
		{
			data.missionsHeroic = value;
		}
	}

	public int arenaRuns
	{
		get
		{
			return data.arenaAllTimeRuns;
		}
		set
		{
			data.arenaAllTimeRuns = value;
		}
	}

	public int arenaBattles
	{
		get
		{
			return data.arenaBattlesPlayed;
		}
		set
		{
			data.arenaBattlesPlayed = value;
		}
	}

	public int arenaWins
	{
		get
		{
			return data.arenaWins;
		}
		set
		{
			data.arenaWins = value;
		}
	}

	public int arenaFlawless
	{
		get
		{
			return data.arenaFlawless;
		}
		set
		{
			data.arenaFlawless = value;
		}
	}

	public int arenaLootboxes
	{
		get
		{
			return data.arenaLootboxes;
		}
		set
		{
			data.arenaLootboxes = value;
		}
	}

	private void CheckExisting()
	{
		if (data.cardsPlayedSeparately == null)
		{
			data.cardsPlayedSeparately = new Dictionary<string, int>();
		}
		if (data.weaponKills == null)
		{
			data.weaponKills = new Dictionary<int, int>();
		}
		if (data.allGainedRibbons == null)
		{
			data.allGainedRibbons = new Dictionary<SkillShot.SkillShotType, int>();
		}
		if (data.unitsDeployedSpecific == null)
		{
			data.unitsDeployedSpecific = new Dictionary<int, int>();
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	private void SetUnitsDeploted(int indexInLevelManager, int value)
	{
		CheckExisting();
		if (data.unitsDeployedSpecific.ContainsKey(indexInLevelManager))
		{
			data.unitsDeployedSpecific[indexInLevelManager] += value;
		}
		else
		{
			data.unitsDeployedSpecific.Add(indexInLevelManager, value);
		}
	}

	private void SetWeaponKills(int indexInLevelManager, int numberOfKills)
	{
		CheckExisting();
		if (data.weaponKills.ContainsKey(indexInLevelManager))
		{
			data.weaponKills[indexInLevelManager] += numberOfKills;
		}
		else
		{
			data.weaponKills.Add(indexInLevelManager, numberOfKills);
		}
	}

	public int GetWeaponKills(WeaponCategory category)
	{
		if (mWeaponTypeKills.ContainsKey(category))
		{
			return mWeaponTypeKills[category];
		}
		return 0;
	}

	protected override void Start()
	{
		base.Start();
		mWinStreakManager = GetComponent<WinStreakManager>();
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Weapon.OnShotFired += WeaponOnOnShotFired;
		matchStats = new MatchStats();
	}

	private void OnGameStarted()
	{
		matchStats = new MatchStats();
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 pos)
	{
		if (weapon.owner == PlayerController.OGMBJPKOPCB && Singleton<GameController>.instance.isPVP)
		{
			matchStats.shotsFired++;
		}
	}

	public void OnNewFlawless()
	{
		matchStats.flawlessRuns = 1;
		flawlessRuns += matchStats.flawlessRuns;
	}

	public void RecomputeStatistics(GameController.HKGHCIEPGEL gameEndReason)
	{
		bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
		bool isWarArena = Singleton<GameController>.instance.isWarArena;
		if (Singleton<GameController>.instance.isRandomMatchMaking)
		{
			matchStats.mmmGames++;
		}
		bool flag = false;
		if (gameEndReason == GameController.HKGHCIEPGEL.Win || gameEndReason == GameController.HKGHCIEPGEL.WinByForfeit)
		{
			flag = true;
			matchStats.battlesWon = 1;
			matchStats.battlesLostInRow = -1;
			matchStats.battlesWonRanked = (isRandomMatchMaking ? 1 : 0);
			matchStats.battlesWonArena = (isWarArena ? 1 : 0);
		}
		if (gameEndReason == GameController.HKGHCIEPGEL.Killed || gameEndReason == GameController.HKGHCIEPGEL.Forfeit)
		{
			flag = false;
			matchStats.battlesLost = 1;
			matchStats.battlesLostRanked = (isRandomMatchMaking ? 1 : 0);
			matchStats.battlesLostArena = (isWarArena ? 1 : 0);
			matchStats.battlesLostInRow = 1;
		}
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		if (Singleton<GameController>.instance.isBattle)
		{
			bool isDeathMatchOffline = Singleton<GameController>.instance.isDeathMatchOffline;
			if (Singleton<GameController>.instance.isRandomMatchMaking)
			{
				float fLOATVALUE = matchMakingConstants.GetRow((!isDeathMatchOffline) ? MatchMakingConstants.rowIds.winLooseStreakWonMatch : MatchMakingConstants.rowIds.winLooseStreakWonMatchOffline).FLOATVALUE;
				float fLOATVALUE2 = matchMakingConstants.GetRow((!isDeathMatchOffline) ? MatchMakingConstants.rowIds.winLooseStreakLostMatch : MatchMakingConstants.rowIds.winLooseStreakLostMatchOfflilne).FLOATVALUE;
				float fLOATVALUE3 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakMax).FLOATVALUE;
				float fLOATVALUE4 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakMin).FLOATVALUE;
				if (Singleton<GameController>.instance.isDeathMatch)
				{
					float deathMatchWinLooseStreak = data.deathMatchWinLooseStreak;
					data.deathMatchWinLooseStreak = Mathf.Clamp(deathMatchWinLooseStreak + ((!flag) ? fLOATVALUE2 : fLOATVALUE), fLOATVALUE4, fLOATVALUE3);
					matchStats.deathMatchWinLooseStreak = data.deathMatchWinLooseStreak - deathMatchWinLooseStreak;
				}
				if (isDeathMatchOffline)
				{
					float deathMatchOfflineWinLooseStreak = data.deathMatchOfflineWinLooseStreak;
					if (data.mmmGames == 0)
					{
						data.deathMatchOfflineWinLooseStreak = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakOfflineDefault).FLOATVALUE;
					}
					data.deathMatchOfflineWinLooseStreak = Mathf.Clamp(data.deathMatchOfflineWinLooseStreak + ((!flag) ? fLOATVALUE2 : fLOATVALUE), fLOATVALUE4, fLOATVALUE3);
					matchStats.deathMatchOfflineWinLooseStreak = data.deathMatchOfflineWinLooseStreak - deathMatchOfflineWinLooseStreak;
				}
				float num = data.deathMatchLossesInRow;
				data.deathMatchLossesInRow = ((!flag) ? (num + (float)(Singleton<GameController>.instance.isDeathMatch ? 1 : 0)) : 0f);
				matchStats.deathMatchLossesInRow = data.deathMatchLossesInRow - num;
			}
			if (Singleton<ScoreManager>.instance.OONJGPCEJMJ.ContainsKey(SkillShot.SkillShotType.Kill))
			{
				matchStats.kills = Singleton<ScoreManager>.instance.OONJGPCEJMJ[SkillShot.SkillShotType.Kill];
			}
			if (Singleton<ScoreManager>.instance.OONJGPCEJMJ.ContainsKey(SkillShot.SkillShotType.VehicleDestroyed))
			{
				matchStats.vehicleDestroyed = Singleton<ScoreManager>.instance.OONJGPCEJMJ[SkillShot.SkillShotType.VehicleDestroyed];
			}
		}
		else
		{
			matchStats.scorestreakGained = 0;
			matchStats.cratesStolen = 0;
		}
		if (Singleton<GameController>.instance.isMission)
		{
			matchStats.missionsPlayed = 1;
			matchStats.missionSucces = 1;
			if (gameEndReason == GameController.HKGHCIEPGEL.MissionSuccess)
			{
				switch (DailyMissionsManager.instance.currentMission.missionType)
				{
				case GEIKAIJBCPE.Daily:
					matchStats.missionsSolo = 1;
					break;
				case GEIKAIJBCPE.Coop:
					matchStats.missionsCoop = 1;
					break;
				case GEIKAIJBCPE.Heroic:
					matchStats.missionsHeroic = 1;
					break;
				}
			}
		}
		battlesLostInRow = ((matchStats.battlesLostInRow == 0) ? battlesLostInRow : ((matchStats.battlesLostInRow > 0) ? (battlesLostInRow + 1) : 0));
		IncrementStatistics(gameEndReason);
	}

	private void IncrementStatistics(GameController.HKGHCIEPGEL gameEndReason)
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			return;
		}
		matchmadeGames += matchStats.mmmGames;
		battlesWon += matchStats.battlesWon;
		if (Singleton<GameController>.instance.isWarArena)
		{
			arenaWins += matchStats.battlesWon;
		}
		if (Singleton<GameController>.instance.isMission)
		{
			missionsCompleted += matchStats.missionsSolo;
			missionsCoop += matchStats.missionsCoop;
			missionsHeroic += matchStats.missionsHeroic;
		}
		battlesLost += matchStats.battlesLost;
		battlesWonRanked += matchStats.battlesWonRanked;
		battlesLostRanked += matchStats.battlesLostRanked;
		battlesWonArena += matchStats.battlesWonArena;
		battlesLostArena += matchStats.battlesLostArena;
		shots += matchStats.shotsFired;
		hits += matchStats.hits;
		kills += matchStats.kills;
		vehicleDestroyed += matchStats.vehicleDestroyed;
		unitsDeployedTotal += matchStats.unitsDeployed;
		soldierUnitsDeployedTotal += matchStats.soldierUnitsSpawned;
		vehiclesDeployedTotal += matchStats.vehiclesSpawned;
		cardsPlayed += matchStats.cardsPlayed;
		scorestreakGained += matchStats.scorestreakGained;
		cratesStolen += matchStats.cratesStolen;
		foreach (KeyValuePair<int, int> weaponKill in matchStats.weaponKills)
		{
			SetWeaponKills(weaponKill.Key, weaponKill.Value);
		}
		foreach (KeyValuePair<int, int> item in matchStats.unitsDeployedSpecific)
		{
			SetUnitsDeploted(item.Key, item.Value);
		}
		foreach (KeyValuePair<string, int> item2 in matchStats.cardsPlayedSeparately)
		{
			if (data.cardsPlayedSeparately.ContainsKey(item2.Key))
			{
				data.cardsPlayedSeparately[item2.Key] += item2.Value;
			}
			else
			{
				data.cardsPlayedSeparately[item2.Key] = item2.Value;
			}
		}
		missionsPlayed += matchStats.missionsPlayed;
		missionSucces += matchStats.missionSucces;
	}

	public void AddWeaponTypeKill(WeaponCategory category)
	{
		matchStats.weaponTypeKills[category]++;
	}

	public void AddWeaponKill(int indexInLevelmanager)
	{
		matchStats.weaponKills[indexInLevelmanager]++;
	}

	public void UpdatePlayerLeague()
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		if (GameLoginManager.currentPlayer.isInLeague && bestLeague < leagueTier)
		{
			bestLeague = leagueTier;
		}
	}

	public void UpdatePlayerMedals()
	{
		int skill = GameLoginManager.currentPlayer.skill;
		if (maxMedals < skill)
		{
			maxMedals = skill;
		}
	}
}
