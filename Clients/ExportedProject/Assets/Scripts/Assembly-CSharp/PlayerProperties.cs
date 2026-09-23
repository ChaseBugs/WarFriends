using System.Collections.Generic;
using ExitGames.Client.Photon;
using Newtonsoft.Json;
using UnityEngine;
using War.Protocol;

public class PlayerProperties
{
	public List<Tuple<string, CardManager.BuddyCardData>> buddyCards = new List<Tuple<string, CardManager.BuddyCardData>>();

	public string chosenCards = string.Empty;

	public string country;

	public long facebookID;

	public bool isInLeague;

	public bool isVip;

	public League league;

	public int leagueMedals;

	public int beginnersLeague;

	private DatabasePlayerInfo mBotInfo;

	public int medals;

	public string name;

	public PhotonPlayer photonPlayer;

	public string playerID;

	public string[] playerVisuals;

	public Texture texture;

	private List<UnitUpgradeDefinition> mUpgrades;

	public int matchMadeGames;

	public WarArenaCrown warArenaCrown;

	public Dictionary<string, UnitUpgradeDefinition> upgradesDictionary { get; private set; }

	public bool goldShields { get; private set; }

	public int level { get; set; }

	public int armyPower { get; set; }

	public PlayerInventory.EquippedWeapon[] weapons { get; set; }

	public int armyPowerX10 => 10 * armyPower;

	public bool isInBeginnersLeague => beginnersLeague > 0;

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo { get; set; }

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet { get; set; }

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory { get; set; }

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand { get; set; }

	public bool isBot { get; set; }

	public static Hashtable photonPlayerProperties
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("maxMapId", Singleton<MapManager>.instance.unlockedmaps);
			hashtable.Add("mapId", (!Singleton<MapManager>.instance.isRandomMap) ? Singleton<MapManager>.instance.currentMap.id : 10);
			hashtable.Add("isRandomMap", Singleton<MapManager>.instance.isRandomMap ? 1 : 0);
			hashtable.Add("level", Singleton<GameController>.instance.mainController.playerLevel);
			hashtable.Add("playerID", GameLoginManager.instance.playerId);
			hashtable.Add("facebookID", GameLoginManager.instance.facebookId);
			hashtable.Add("playerVisuals", Singleton<GameController>.instance.mainController.equppedVisuals);
			hashtable.Add("weapons", Singleton<GameController>.instance.mainController.equippedWeapons);
			hashtable.Add("armyPower", LevelManager.instance.armyPower);
			hashtable.Add("defendPosition", Random.Range(0, 2));
			hashtable.Add("upgrades", JsonConvert.SerializeObject(Singleton<GameController>.instance.mainController.GetUnitsUpgrades()));
			hashtable.Add("league", (int)GameLoginManager.currentPlayer.leagueTier);
			hashtable.Add("isVIP", Singleton<VipManager>.instance.IsVipActive());
			hashtable.Add("medals", GameLoginManager.instance.medals);
			hashtable.Add("isInLeague", GameLoginManager.currentPlayer.isInLeague);
			hashtable.Add("country", GameLoginManager.currentPlayer.country);
			hashtable.Add("leagueMedals", GameLoginManager.currentPlayer.medalsBalance);
			hashtable.Add("beginnersLeague", GameLoginManager.currentPlayer.beginnersLeague);
			hashtable.Add("matchMadeGames", StatsManager.instance.matchmadeGames);
			hashtable.Add("warArenaCrown", GameLoginManager.currentPlayer.warArenaCrown);
			hashtable.Add("goldShields", WarArena.instance.goldShieldsActive);
			Hashtable hashtable2 = hashtable;
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
			{
				hashtable2["defendPosition"] = ((!PhotonNetwork.isMasterClient) ? 1 : 0);
			}
			return hashtable2;
		}
	}

	public DatabasePlayerInfo databaseInfoBot => mBotInfo;

	public List<UnitUpgradeDefinition> upgrades
	{
		get
		{
			return mUpgrades;
		}
		set
		{
			mUpgrades = value;
			upgradesDictionary = new Dictionary<string, UnitUpgradeDefinition>();
			for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				upgradesDictionary[levelBehaviour.GetType().ToString()] = value[i];
			}
		}
	}

	public void ClearAccesories()
	{
		equippedCamo = null;
		equippedHeadAccesory = null;
		equippedHelmet = null;
		equippedPowerBand = null;
	}

	public static PlayerProperties CreateFromPhotonPlayer(PhotonPlayer player, Fractions fraction)
	{
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.name = player.name;
		playerProperties.photonPlayer = player;
		playerProperties.facebookID = (long)player.customProperties["facebookID"];
		playerProperties.playerID = player.userId;
		playerProperties.weapons = (PlayerInventory.EquippedWeapon[])player.customProperties["weapons"];
		playerProperties.level = (int)player.customProperties["level"];
		playerProperties.armyPower = (int)player.customProperties["armyPower"];
		playerProperties.texture = ((fraction != PlayerController.currentPlayer.fraction) ? Singleton<ArmyPreviewCamera>.instance.player2Texture : Singleton<ArmyPreviewCamera>.instance.player3Texture);
		playerProperties.upgrades = JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>((string)player.customProperties["upgrades"]);
		playerProperties.league = (League)(int)player.customProperties["league"];
		playerProperties.isVip = (bool)player.customProperties["isVIP"];
		playerProperties.playerVisuals = (string[])player.customProperties["playerVisuals"];
		playerProperties.medals = (int)player.customProperties["medals"];
		playerProperties.isBot = false;
		playerProperties.isInLeague = (bool)player.customProperties["isInLeague"];
		playerProperties.country = (string)player.customProperties["country"];
		playerProperties.leagueMedals = (int)player.customProperties["leagueMedals"];
		playerProperties.beginnersLeague = (int)player.customProperties["beginnersLeague"];
		playerProperties.matchMadeGames = (int)player.customProperties["matchMadeGames"];
		playerProperties.warArenaCrown = (WarArenaCrown)(int)player.customProperties["warArenaCrown"];
		playerProperties.goldShields = (bool)player.customProperties["goldShields"];
		return playerProperties;
	}

	public static PlayerProperties CreateForLocalPlayer()
	{
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.name = GameLoginManager.currentPlayer.name;
		playerProperties.photonPlayer = PhotonNetwork.player;
		playerProperties.facebookID = GameLoginManager.instance.facebookId;
		playerProperties.playerID = GameLoginManager.instance.playerId;
		playerProperties.level = Singleton<GameController>.instance.mainController.playerLevel;
		playerProperties.armyPower = LevelManager.instance.armyPower;
		playerProperties.weapons = Singleton<GameController>.instance.mainController.equippedWeapons;
		playerProperties.texture = Singleton<ArmyPreviewCamera>.instance.player1Texture;
		playerProperties.upgrades = Singleton<GameController>.instance.mainController.GetUnitsUpgrades();
		playerProperties.league = GameLoginManager.currentPlayer.leagueTier;
		playerProperties.isVip = Singleton<VipManager>.instance.IsVipActive();
		playerProperties.playerVisuals = Singleton<GameController>.instance.mainController.equppedVisuals;
		playerProperties.medals = GameLoginManager.currentPlayer.skill;
		playerProperties.isBot = false;
		playerProperties.isInLeague = GameLoginManager.currentPlayer.isInLeague;
		playerProperties.country = GameLoginManager.currentPlayer.country;
		playerProperties.leagueMedals = (GameLoginManager.currentPlayer.isInLeague ? GameLoginManager.currentPlayer.medalsBalance : 0);
		playerProperties.beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
		playerProperties.matchMadeGames = StatsManager.instance.matchmadeGames;
		playerProperties.warArenaCrown = GameLoginManager.currentPlayer.warArenaCrown;
		playerProperties.goldShields = WarArena.instance.goldShieldsActive;
		playerProperties.chosenCards = CardManager.instance.selectedCards;
		playerProperties.buddyCards = CardManager.instance.selectedBuddyCards;
		return playerProperties;
	}

	/// <summary>Constructs the recovered scene-facing player state from the authenticated
	/// Backend projection. Combat authority remains on the BattleServer.</summary>
	public static PlayerProperties CreateFromBattleView(BattlePlayerView view, Fractions fraction)
	{
		if (view == null || view.VisualIds.Count != 4 || view.Weapons.Count == 0)
			throw new System.InvalidOperationException("The self-hosted player view is incomplete.");
		PlayerProperties result = new PlayerProperties();
		result.name = view.DisplayName;
		result.playerID = view.PlayerId;
		result.level = view.Level;
		result.armyPower = view.ArmyPower;
		result.medals = view.Skill;
		result.leagueMedals = view.LeagueMedals;
		result.beginnersLeague = view.BeginnersLeague;
		result.country = view.Country;
		result.isVip = view.IsVip;
		result.isInLeague = !string.IsNullOrEmpty(view.LeagueId);
		result.league = ParseBattleLeague(view.LeagueId);
		result.isBot = false;
		result.warArenaCrown = WarArenaCrown.None;
		result.goldShields = false;
		result.playerVisuals = new string[view.VisualIds.Count];
		view.VisualIds.CopyTo(result.playerVisuals, 0);
		result.weapons = new PlayerInventory.EquippedWeapon[view.Weapons.Count];
		for (int i = 0; i < view.Weapons.Count; i++)
		{
			BattleWeaponView weapon = view.Weapons[i];
			result.weapons[i] = new PlayerInventory.EquippedWeapon
			{
				weaponId = weapon.WeaponIndex,
				weaponUpgrade = weapon.UpgradeIndex,
				enabled = true
			};
		}
		Dictionary<string, BattleUnitView> units = new Dictionary<string, BattleUnitView>(System.StringComparer.Ordinal);
		foreach (BattleUnitView unit in view.Units) units.Add(unit.SourceId, unit);
		List<UnitUpgradeDefinition> upgrades = new List<UnitUpgradeDefinition>();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			BattleUnitView unit;
			bool equipped = units.TryGetValue(behaviour.upgradeSlots.GetSheetName(), out unit);
			UpgradeSlots.UnitUpgrades values = new UpgradeSlots.UnitUpgrades(1f);
			if (equipped)
			{
				values.slotUpgradeindex = unit.UpgradeIndex;
				values.slotUpgradeIndexSpecial = unit.SpecialIndex;
				values.slotUpgradeIndexElite = unit.EliteIndex;
				values.isSpecial = unit.SpecialIndex >= 0;
				values.isElite = unit.EliteIndex >= 0;
			}
			upgrades.Add(new UnitUpgradeDefinition(equipped, values, false, equipped ? unit.Tier : 0));
		}
		result.upgrades = upgrades;
		result.texture = view.PlayerId == GameLoginManager.instance.playerId ? Singleton<ArmyPreviewCamera>.instance.player1Texture :
			(fraction == PlayerController.currentPlayer.fraction ? Singleton<ArmyPreviewCamera>.instance.player3Texture : Singleton<ArmyPreviewCamera>.instance.player2Texture);
		return result;
	}

	private static League ParseBattleLeague(string value)
	{
		if (string.IsNullOrEmpty(value)) return League.NoLeague;
		int separator = value.IndexOf('-');
		string tier = separator < 0 ? value : value.Substring(0, separator);
		int parsed;
		if (!int.TryParse(tier, out parsed) || parsed < (int)League.NoLeague || parsed > (int)League.Champion)
			throw new System.InvalidOperationException("The self-hosted league projection is invalid.");
		return (League)parsed;
	}

	public static PlayerProperties CreateForLocalPlayerLight()
	{
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.name = GameLoginManager.currentPlayer.name;
		playerProperties.armyPower = LevelManager.instance.armyPower;
		playerProperties.weapons = PlayerInventory.instance.equippedWeapons;
		playerProperties.upgrades = LevelManager.instance.GetUpgrades();
		playerProperties.level = LevelManager.instance.currentLevel.displayNumber;
		return playerProperties;
	}

	public void UpdateSelectedUnits(string json)
	{
		upgrades = JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>(json);
	}

	public void CreateFakeDataForBot(bool isInSquad)
	{
		mBotInfo = new DatabasePlayerInfo
		{
			accountName = name,
			level = level - 1,
			skill = medals,
			armyPower = armyPower,
			leagueTier = league,
			remainingMatches = GameLoginManager.currentPlayer.remainingMatches,
			facebookId = -1L,
			status = PlayerStatus.Online,
			lastAction = Singleton<BeanstalkServerManager>.instance.currentTimestamp,
			country = country,
			beginnersLeague = beginnersLeague
		};
		bool flag = level > LevelManager.instance.warcardsUnlockLevel;
		mBotInfo.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 0; i < playerVisuals.Length; i++)
		{
			string equippedID = playerVisuals[i];
			mBotInfo.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		StatsManager.StatisticsData statisticsData = new StatsManager.StatisticsData();
		mBotInfo.statisticsData = statisticsData;
		float num = Random.Range(0.8f, 2.2f);
		int num2 = medals - GameLoginManager.currentPlayer.skill;
		float num3 = (float)num2 / (float)GameLoginManager.currentPlayer.skill;
		float a = (float)StatsManager.instance.data.battlesWonRanked + num3 * (float)StatsManager.instance.data.battlesWonRanked + Random.Range(0f, (float)medals / 200f);
		int num4 = medals - 500;
		float b = (float)num4 / 9f + Random.Range(0f, 6f);
		a = Mathf.Max(a, b);
		statisticsData.battlesWonRanked = (int)a;
		statisticsData.battlesLostRanked = (int)((float)statisticsData.battlesWonRanked / num);
		statisticsData.mmmGames = statisticsData.battlesWonRanked + statisticsData.battlesLostRanked;
		matchMadeGames = statisticsData.mmmGames;
		statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int j = 0; j < upgrades.Count; j++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = upgrades[j];
			if (unitUpgradeDefinition.isEquipped)
			{
				statisticsData.unitsDeployedSpecific[j] = Random.Range(0, 100);
			}
		}
		statisticsData.weaponKills = new Dictionary<int, int>();
		for (int k = 0; k < weapons.Length; k++)
		{
			int weaponId = weapons[k].weaponId;
			statisticsData.weaponKills[weaponId] = Random.Range(0, 100);
		}
		List<Card> cards = CardManager.instance.cards;
		Card card = cards[Random.Range(0, cards.Count)];
		while (card.isBuddyCard)
		{
			card = cards[Random.Range(0, cards.Count)];
		}
		statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (flag)
		{
			statisticsData.cardsPlayedSeparately[card.id] = 100;
		}
		mBotInfo.levelManagerData = new LevelManager.LevelManagerData();
		for (int l = 0; l < weapons.Length; l++)
		{
			int weaponId2 = weapons[l].weaponId;
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[weaponId2];
			mBotInfo.levelManagerData.savedWeapons[weaponLevelsSetup.GetSheetName()] = new LevelManager.SavedWeaponSlots
			{
				bought = true,
				boughtIndex = ((weapons != null) ? weapons[l].weaponUpgrade : 0)
			};
		}
		mBotInfo.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		for (int m = 0; m < upgrades.Count; m++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition2 = upgrades[m];
			string sheetName = LevelManager.instance.behaviours[m].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition2.isEquipped)
			{
				mBotInfo.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition2.isEquipped,
					boughtIndex = unitUpgradeDefinition2.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition2.tier
				};
			}
		}
		mBotInfo.inventoryData = new PlayerInventory.InventoryData();
		for (int n = 0; n < weapons.Length; n++)
		{
			PlayerInventory.EquippedWeapon equippedWeapon = weapons[n];
			mBotInfo.inventoryData.slots[n] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = equippedWeapon.weaponId
			};
		}
		mBotInfo.statisticsData.maxMedals = ((!(Random.value < 0.3f)) ? medals : Mathf.Clamp((int)((float)medals * Random.Range(1f, 1.02f)), 500, int.MaxValue));
		if (!isInSquad)
		{
			return;
		}
		List<DatabaseSquad> globalSquadLeaderboard = Singleton<ServerResultsCache>.instance.GetGlobalSquadLeaderboard(ommitTime: true);
		if (globalSquadLeaderboard != null && globalSquadLeaderboard.Count > 1)
		{
			DatabaseSquad databaseSquad = null;
			do
			{
				databaseSquad = globalSquadLeaderboard[Random.Range(0, globalSquadLeaderboard.Count)];
			}
			while (databaseSquad.name == GameLoginManager.currentPlayer.squadName);
			mBotInfo.squadName = databaseSquad.name;
			mBotInfo.squadEmblem = databaseSquad.icon;
			mBotInfo.squadPoints = databaseSquad.squadPoints / Mathf.Max(databaseSquad.size, 1);
			mBotInfo.reputation = (flag ? (Random.Range(0, 24) * 5) : 0);
		}
	}

	public Dictionary<string, int> GetWeaponsForStats()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (weapons != null)
		{
			for (int i = 0; i < weapons.Length; i++)
			{
				int weaponId = weapons[i].weaponId;
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[weaponId];
				dictionary[weaponLevelsSetup.GetSheetName().Replace("Google2u.", string.Empty)] = ((weapons != null) ? weapons[i].weaponUpgrade : 0);
			}
		}
		return dictionary;
	}

	public Dictionary<string, int> GetArmyForStats()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < upgrades.Count; i++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = upgrades[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace("Google2u.DBUpgradeSlots", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	public void EndMatch(bool loose)
	{
		if (mBotInfo != null)
		{
			int value = (int)(0.05f * (float)Mathf.Abs(mBotInfo.skill - PlayerController.currentPlayer.playerProperties.medals));
			value = Mathf.Clamp(value, 7, 13);
			value = Random.Range(value - 2, value + 2);
			value = Mathf.Clamp(value, 7, 13);
			if (loose)
			{
				mBotInfo.statisticsData.battlesLostRanked++;
				mBotInfo.skill -= value;
				medals -= value;
			}
			else
			{
				mBotInfo.statisticsData.battlesWonRanked++;
				mBotInfo.skill += value;
				mBotInfo.statisticsData.maxMedals = Mathf.Max(mBotInfo.statisticsData.maxMedals, mBotInfo.skill);
				medals += value;
			}
			matchMadeGames++;
			if (mBotInfo.statisticsData.mmmGames == 0)
			{
				mBotInfo.beginnersLeague = 1;
			}
			mBotInfo.statisticsData.mmmGames++;
			if (!mBotInfo.isInBeginnersLeague && mBotInfo.remainingMatches > 0)
			{
				isInLeague = mBotInfo.remainingMatches == 1;
				mBotInfo.remainingMatches--;
			}
		}
	}
}
