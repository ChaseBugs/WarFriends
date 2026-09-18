using System;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Skip]
public class StatsManager : DatabaseSerializedObjectGeneric<StatsManager.StatisticsData>
{
	[Skip]
	public class StatisticsData
	{
		public int missionsPlayed;

		public int mmmGames;

		public int battlesWonRanked;

		public int battlesLostRanked;

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

		public int missionsKills;

		public int missionsDeaths;

		public int missionsHits;

		public int missionsShotsFired;

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

		public int battlesPlayed => battlesWon + battlesLost;

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

	[Skip]
	public class MatchStats
	{
		public int missionsPlayed;

		public int mmmGames;

		public int battlesWonRanked;

		public int battlesLostRanked;

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

		public int secondsPlayed;

		public int missionsKills;

		public int missionsDeaths;

		public int missionsHits;

		public int missionsShotsFired;

		public int missionSucces;

		public Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;

		public int deployClicks;

		public Dictionary<LevelBehaviour.UnitType, int> unitsSpawnedByType
		{
			get
			{
				Dictionary<LevelBehaviour.UnitType, int> dictionary = new Dictionary<LevelBehaviour.UnitType, int>();
				foreach (object value in Enum.GetValues(typeof(LevelBehaviour.UnitType)))
				{
					LevelBehaviour.UnitType key = (LevelBehaviour.UnitType)(int)value;
					dictionary[key] = 0;
				}
				foreach (KeyValuePair<int, int> item in unitsSpawnedSpecific)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[item.Key];
					Dictionary<LevelBehaviour.UnitType, int> dictionary3;
					Dictionary<LevelBehaviour.UnitType, int> dictionary2 = (dictionary3 = dictionary);
					LevelBehaviour.UnitType unitType;
					LevelBehaviour.UnitType key2 = (unitType = levelBehaviour.unitType);
					int num = dictionary3[unitType];
					dictionary2[key2] = num + item.Value;
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
					WeaponCategory key = (WeaponCategory)(int)value;
					dictionary[key] = 0;
				}
				foreach (KeyValuePair<int, int> weaponKill in weaponKills)
				{
					WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[weaponKill.Key];
					Dictionary<WeaponCategory, int> dictionary3;
					Dictionary<WeaponCategory, int> dictionary2 = (dictionary3 = dictionary);
					WeaponCategory weaponCategory;
					WeaponCategory key2 = (weaponCategory = weaponLevelsSetup.weaponCategory);
					int num = dictionary3[weaponCategory];
					dictionary2[key2] = num + weaponKill.Value;
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

		public MatchStats()
		{
			foreach (object value in Enum.GetValues(typeof(WeaponCategory)))
			{
				WeaponCategory key = (WeaponCategory)(int)value;
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
			Dictionary<int, int> dictionary2;
			Dictionary<int, int> dictionary = (dictionary2 = unitsDeployedSpecific);
			int key2;
			int key = (key2 = indexInlevelManager);
			key2 = dictionary2[key2];
			dictionary[key] = key2 + 1;
			Dictionary<int, int> dictionary4;
			Dictionary<int, int> dictionary3 = (dictionary4 = unitsSpawnedSpecific);
			int key3 = (key2 = indexInlevelManager);
			key2 = dictionary4[key2];
			dictionary3[key3] = key2 + count;
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
					return;
				}
				Dictionary<string, int> dictionary2;
				Dictionary<string, int> dictionary = (dictionary2 = cardsPlayedSeparately);
				string id;
				string key = (id = card.id);
				int num = dictionary2[id];
				dictionary[key] = num + 1;
			}
		}
	}

	public DailyRewardMonthScreen.DailyRewardSerwerData dailyRewardData;

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

	public int totalWins => missionSucces + battlesWon;

	public int totalGames => battlesPlayed + missionsPlayed;

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

	public float deathMatchLossesInRow => data.deathMatchLossesInRow;

	public int battlesPlayed => battlesWon + battlesLost;

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

	public float winLoseRatio => data.winLoseRatio;

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

	public float accuracy => (data.shotsFired != 0) ? Mathf.Clamp01((float)hits / (float)data.shotsFired) : (-1f);

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
				WeaponCategory key = (WeaponCategory)(int)value;
				dictionary[key] = 0;
			}
			foreach (KeyValuePair<int, int> weaponKill in data.weaponKills)
			{
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[weaponKill.Key];
				Dictionary<WeaponCategory, int> dictionary3;
				Dictionary<WeaponCategory, int> dictionary2 = (dictionary3 = dictionary);
				WeaponCategory weaponCategory;
				WeaponCategory key2 = (weaponCategory = weaponLevelsSetup.weaponCategory);
				int num = dictionary3[weaponCategory];
				dictionary2[key2] = num + weaponKill.Value;
			}
			return dictionary;
		}
	}

	public long globalXP => LevelManager.instance.experience;

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

	public int assignmentsCompleted => AssignmentsManager.instance.GetCompletedAssignments();

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

	public int armyPowerX10 => LevelManager.instance.armyPowerX10;

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
			int num = 0;
			foreach (Mission mission in MissionsManager.instance.missions)
			{
				if (mission.completed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int missionsCoop
	{
		get
		{
			int num = 0;
			foreach (Mission mission in MissionsManager.instance.missions)
			{
				if (mission.completedInCoop)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int starsGained
	{
		get
		{
			int num = 0;
			foreach (Mission mission in MissionsManager.instance.missions)
			{
				num += mission.numberOfStars;
			}
			return num;
		}
	}

	public int missionsKills
	{
		get
		{
			return data.missionsKills;
		}
		set
		{
			data.missionsKills = value;
		}
	}

	public int missionsDeaths
	{
		get
		{
			return data.missionsDeaths;
		}
		set
		{
			data.missionsDeaths = value;
		}
	}

	public float missionsKillsDeathsRatio => (missionsDeaths != 0) ? ((float)missionsKills / (float)missionsDeaths) : (-1f);

	public int missionsHits
	{
		get
		{
			return data.missionsHits;
		}
		set
		{
			data.missionsHits = value;
		}
	}

	public int missionsShotsFired
	{
		get
		{
			return data.missionsShotsFired;
		}
		set
		{
			data.missionsShotsFired = value;
		}
	}

	public float missionsAccuracy => (missionsShotsFired != 0) ? Mathf.Clamp01((float)missionsHits / (float)missionsShotsFired) : (-1f);

	public int missionsCount => GuiScreenSingle<MissionScreen>.instance.numberOfMissions;

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

	public DailyReward ParseReward(JToken item)
	{
		DailyReward dailyReward = item["addedType"].ToObject<DailyReward>();
		switch (dailyReward)
		{
		case DailyReward.Warbucks:
		{
			long amount = StringParser.ParseLongToken(item["added"], 0L);
			Singleton<Wallet>.instance.AddWarBucksReward(amount);
			break;
		}
		case DailyReward.Gold:
		{
			long goldAmount = StringParser.ParseLongToken(item["added"], 0L);
			Singleton<Wallet>.instance.AddGoldReward(goldAmount);
			break;
		}
		case DailyReward.ArenaTickets:
		{
			long amount2 = StringParser.ParseLongToken(item["added"], 0L);
			Singleton<Wallet>.instance.AddTickets(amount2);
			break;
		}
		case DailyReward.BronzeCards:
		case DailyReward.SilverCards:
		case DailyReward.GoldCards:
		case DailyReward.ParticularCards:
		case DailyReward.BronzeCardpack:
		case DailyReward.SilverCardpack:
		case DailyReward.GoldCardpack:
		{
			int num = StringParser.ParseIntToken(item["added"]["count"]);
			string text = item["added"]["cards"].ToString();
			string[] array = text.Split(';');
			for (int i = 0; i < array.Length; i++)
			{
				CardManager.instance.AddMultipleCards(array[i], num);
			}
			if (GuiScreenSingle<DailyRewardMonthScreen>.instance.isFullyShowed)
			{
				GuiScreenSingle<DailyRewardMonthScreen>.instance.ShowCards(array, num);
			}
			if (GuiElementSingle<InGameMessageDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowCards(array, num);
			}
			break;
		}
		case DailyReward.PowerBand:
		case DailyReward.Customization:
		{
			string idVisual = item["added"]["id"].ToString();
			PlayerVisual playerVisual;
			if (item["added"]["expiresOn"] != null)
			{
				int expiresOn = StringParser.ParseIntToken(item["added"]["expiresOn"]);
				playerVisual = CamosManager.instance.GetPowerBand(idVisual);
				playerVisual.Buy();
				playerVisual.setExpiresOn(expiresOn);
			}
			else
			{
				playerVisual = CamosManager.instance.GetVisual(idVisual);
				playerVisual.Buy();
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
			break;
		}
		case DailyReward.Vip:
		{
			int vipStart = StringParser.ParseIntToken(item["added"]["start"]);
			int vipExpiration = StringParser.ParseIntToken(item["added"]["expires"]);
			Singleton<VipManager>.instance.vipStart = vipStart;
			Singleton<VipManager>.instance.vipExpiration = vipExpiration;
			break;
		}
		default:
			Debug.LogError("unimplemented daily reward!");
			break;
		}
		if (item["VipReward1"] != null)
		{
			Debug.Log("response contain VipReward");
			string text2 = StringParser.ParseString(item["VipReward1"], string.Empty);
			string text3 = StringParser.ParseString(item["VipReward2"], string.Empty);
			string dayString = "a";
			if (item["VipRewardForDay"] != null)
			{
				dayString = StringParser.ParseString(item["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new VipCardMessage(text2, text3, dayString));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		return dailyReward;
	}

	public bool DailyRewardDataLoaded(JToken item)
	{
		if (item == null)
		{
			return false;
		}
		if (dailyRewardData == null)
		{
			dailyRewardData = new DailyRewardMonthScreen.DailyRewardSerwerData(item);
		}
		else
		{
			dailyRewardData.UpdateFromData(item);
		}
		if (item["ok"] != null)
		{
			DatabaseResult databaseResult = (DatabaseResult)StringParser.ParseIntToken(item["ok"]);
			if (databaseResult != DatabaseResult.Success)
			{
				Debug.LogError($"claim reward failed: {databaseResult}");
				if (databaseResult == DatabaseResult.TryClaimAlreadyClaimedReward)
				{
				}
				if (databaseResult != DatabaseResult.TryClaimWrongRewad)
				{
				}
			}
			else
			{
				DailyReward rewardType = ParseReward(item);
				Singleton<EventTrackingManager>.instance.RegisterRewardClaimedEvent(dailyRewardData.lastClaimed, dailyRewardData.totalDays, rewardType);
			}
		}
		return dailyRewardData.canClaim;
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
			Dictionary<int, int> unitsDeployedSpecific;
			Dictionary<int, int> dictionary = (unitsDeployedSpecific = data.unitsDeployedSpecific);
			int key2;
			int key = (key2 = indexInLevelManager);
			key2 = unitsDeployedSpecific[key2];
			dictionary[key] = key2 + value;
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
			Dictionary<int, int> weaponKills;
			Dictionary<int, int> dictionary = (weaponKills = data.weaponKills);
			int key2;
			int key = (key2 = indexInLevelManager);
			key2 = weaponKills[key2];
			dictionary[key] = key2 + numberOfKills;
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

	public void SaveRibbonsFromGame(Dictionary<SkillShot.SkillShotType, int> skillshots)
	{
		CheckExisting();
		foreach (KeyValuePair<RibbonManager.RibbonItemDefinition, int> ribbon in Singleton<RibbonManager>.instance.GetRibbons(skillshots))
		{
			if (ribbon.Value > 0)
			{
				if (data.allGainedRibbons.ContainsKey(ribbon.Key.skillShotType))
				{
					Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;
					Dictionary<SkillShot.SkillShotType, int> dictionary = (allGainedRibbons = data.allGainedRibbons);
					SkillShot.SkillShotType skillShotType;
					SkillShot.SkillShotType key = (skillShotType = ribbon.Key.skillShotType);
					int num = allGainedRibbons[skillShotType];
					dictionary[key] = num + ribbon.Value;
				}
				else
				{
					data.allGainedRibbons.Add(ribbon.Key.skillShotType, ribbon.Value);
				}
			}
		}
	}

	public void FillMatchStatsWithRibbons(Dictionary<SkillShot.SkillShotType, int> skillshots)
	{
		if (matchStats.allGainedRibbons == null)
		{
			matchStats.allGainedRibbons = new Dictionary<SkillShot.SkillShotType, int>();
		}
		foreach (KeyValuePair<RibbonManager.RibbonItemDefinition, int> ribbon in Singleton<RibbonManager>.instance.GetRibbons(skillshots))
		{
			if (ribbon.Value > 0)
			{
				if (matchStats.allGainedRibbons.ContainsKey(ribbon.Key.skillShotType))
				{
					Dictionary<SkillShot.SkillShotType, int> allGainedRibbons;
					Dictionary<SkillShot.SkillShotType, int> dictionary = (allGainedRibbons = matchStats.allGainedRibbons);
					SkillShot.SkillShotType skillShotType;
					SkillShot.SkillShotType key = (skillShotType = ribbon.Key.skillShotType);
					int num = allGainedRibbons[skillShotType];
					dictionary[key] = num + ribbon.Value;
				}
				else
				{
					matchStats.allGainedRibbons.Add(ribbon.Key.skillShotType, ribbon.Value);
				}
			}
		}
	}

	public Dictionary<RibbonManager.RibbonItemDefinition, int> GetAllTimeRibbons()
	{
		CheckExisting();
		Dictionary<RibbonManager.RibbonItemDefinition, int> dictionary = new Dictionary<RibbonManager.RibbonItemDefinition, int>();
		foreach (RibbonManager.RibbonItemDefinition ribbon in Singleton<RibbonManager>.instance.ribbons)
		{
			int value = (data.allGainedRibbons.ContainsKey(ribbon.skillShotType) ? data.allGainedRibbons[ribbon.skillShotType] : 0);
			dictionary.Add(ribbon, value);
		}
		return dictionary;
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
		if (weapon.owner == PlayerController.currentPlayer)
		{
			if (Singleton<GameController>.instance.isPVP)
			{
				matchStats.shotsFired++;
			}
			else if (Singleton<GameController>.instance.isMission)
			{
				matchStats.missionsShotsFired++;
			}
		}
	}

	public void RecomputeStatistics(GameController.GameEndReason gameEndReason)
	{
		bool isRandomMatchMaking = Singleton<GameController>.instance.isRandomMatchMaking;
		if (Singleton<GameController>.instance.isRandomMatchMaking)
		{
			matchStats.mmmGames++;
		}
		bool flag = false;
		if (gameEndReason == GameController.GameEndReason.Win || gameEndReason == GameController.GameEndReason.WinByForfeit)
		{
			flag = true;
			matchStats.battlesWon = 1;
			matchStats.battlesLostInRow = -1;
			matchStats.battlesWonRanked = (isRandomMatchMaking ? 1 : 0);
		}
		if (gameEndReason == GameController.GameEndReason.Killed || gameEndReason == GameController.GameEndReason.Forfeit)
		{
			flag = false;
			matchStats.battlesLost = 1;
			matchStats.battlesLostRanked = (isRandomMatchMaking ? 1 : 0);
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
			if (Singleton<ScoreManager>.instance.skillShotCounts.ContainsKey(SkillShot.SkillShotType.Kill))
			{
				matchStats.kills = Singleton<ScoreManager>.instance.skillShotCounts[SkillShot.SkillShotType.Kill];
			}
			if (Singleton<ScoreManager>.instance.skillShotCounts.ContainsKey(SkillShot.SkillShotType.VehicleDestroyed))
			{
				matchStats.vehicleDestroyed = Singleton<ScoreManager>.instance.skillShotCounts[SkillShot.SkillShotType.VehicleDestroyed];
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
			if (gameEndReason == GameController.GameEndReason.MissionSuccess)
			{
				matchStats.missionSucces = 1;
			}
			if (PlayerController.currentPlayer.destroyableParts.health <= 0f)
			{
				matchStats.missionsDeaths = 1;
			}
			if (Singleton<ScoreManager>.instance.skillShotCounts.ContainsKey(SkillShot.SkillShotType.Kill))
			{
				matchStats.missionsKills = Singleton<ScoreManager>.instance.skillShotCounts[SkillShot.SkillShotType.Kill];
			}
		}
		FillMatchStatsWithRibbons(Singleton<ScoreManager>.instance.skillShotCounts);
		battlesLostInRow = ((matchStats.battlesLostInRow == 0) ? battlesLostInRow : ((matchStats.battlesLostInRow > 0) ? (battlesLostInRow + 1) : 0));
		IncrementStatistics(gameEndReason);
	}

	private void IncrementStatistics(GameController.GameEndReason gameEndReason)
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			return;
		}
		matchmadeGames += matchStats.mmmGames;
		battlesWon += matchStats.battlesWon;
		if (Singleton<GameController>.instance.isWarArena)
		{
			instance.arenaWins += matchStats.battlesWon;
		}
		battlesLost += matchStats.battlesLost;
		battlesWonRanked += matchStats.battlesWonRanked;
		battlesLostRanked += matchStats.battlesLostRanked;
		shots += matchStats.shotsFired;
		hits += matchStats.hits;
		kills += matchStats.kills;
		vehicleDestroyed += matchStats.vehicleDestroyed;
		unitsDeployedTotal += matchStats.unitsDeployed;
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
				Dictionary<string, int> cardsPlayedSeparately;
				Dictionary<string, int> dictionary = (cardsPlayedSeparately = data.cardsPlayedSeparately);
				string key2;
				string key = (key2 = item2.Key);
				int num = cardsPlayedSeparately[key2];
				dictionary[key] = num + item2.Value;
			}
			else
			{
				data.cardsPlayedSeparately[item2.Key] = item2.Value;
			}
		}
		missionsPlayed += matchStats.missionsPlayed;
		missionsKills += matchStats.missionsKills;
		missionsShotsFired += matchStats.missionsShotsFired;
		missionsHits += matchStats.missionsHits;
		missionsDeaths += matchStats.missionsDeaths;
		missionSucces += matchStats.missionSucces;
		SaveRibbonsFromGame(Singleton<ScoreManager>.instance.skillShotCounts);
	}

	public void AddWeaponTypeKill(WeaponCategory category)
	{
		Dictionary<WeaponCategory, int> weaponTypeKills;
		Dictionary<WeaponCategory, int> dictionary = (weaponTypeKills = matchStats.weaponTypeKills);
		WeaponCategory key2;
		WeaponCategory key = (key2 = category);
		int num = weaponTypeKills[key2];
		dictionary[key] = num + 1;
	}

	public void AddWeaponKill(int indexInLevelmanager)
	{
		Dictionary<int, int> weaponKills;
		Dictionary<int, int> dictionary = (weaponKills = matchStats.weaponKills);
		int key2;
		int key = (key2 = indexInLevelmanager);
		key2 = weaponKills[key2];
		dictionary[key] = key2 + 1;
	}

	public void UpdatePlayerLeague()
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		if (bestLeague < leagueTier)
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
