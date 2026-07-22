using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class DatabasePlayer : KIGEPEJPEKB
{
	public static int maxPlayerName = 15;

	public string accountName;

	public AccountType accountType;

	public int armyPower;

	public string deviceToken;

	public long experience;

	public long facebookId;

	public string googlePlayId;

	[FormerlySerializedAs("siwaId")]
	public string id;

	public int lastAction;

	public int reputation;

	public string leagueDivision;

	public string leagueId;

	public int vipExpiration;

	public League leagueTier = League.Bronze3;

	public Dictionary<string, string> depositedCardsDic;

	public int level;

	public string country;

	public int sendLogsValue;

	[FormerlySerializedAs("isActiveGDPR")]
	public int beginnersLeague;

	public Dictionary<int, CamosManager.SavedPlayerVisualSlot> playerVisuals;

	public PlayerInventory.InventoryData inventoryData;

	public LevelManager.LevelManagerData levelManagerData;

	public int skill;

	public int medalsBalance;

	public int remainingMatches;

	public string squadName;

	public int squadPoints;

	public SquadRank squadRank;

	public PlayerStatus status;

	public string gameCenterId;

	public StatsManager.StatisticsData statisticsData;

	public bool awaitingSquadMember;

	public string visualType;

	public int visualTimestamp;

	public string influencerLink;

	public string influencerAlias;

	[JsonIgnore]
	public Dictionary<CloudRegionCode, int> bestRegions;

	public InternetConnection connectionType;

	private static DatabasePlayer mFakePlayer;

	public int armyPowerX10 => 10 * armyPower;

	public bool isInBeginnersLeague => beginnersLeague > 0 && statisticsData != null && statisticsData.mmmGames > 0;

	public Dictionary<string, LevelManager.SavedArmySlots> equippedUnits
	{
		get
		{
			if (levelManagerData == null)
			{
				levelManagerData = new LevelManager.LevelManagerData();
			}
			return levelManagerData.savedArmies;
		}
		set
		{
			if (levelManagerData == null)
			{
				levelManagerData = new LevelManager.LevelManagerData();
			}
			levelManagerData.savedArmies = value;
		}
	}

	public WarArenaCrown warArenaCrown
	{
		get
		{
			if (visualTimestamp < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				return WarArenaCrown.None;
			}
			switch (visualType)
			{
			case "bronze":
				return WarArenaCrown.BronzeCrown;
			case "silver":
				return WarArenaCrown.SilverCrown;
			case "gold":
				return WarArenaCrown.GoldCrown;
			case "flawless":
				return WarArenaCrown.Flawless;
			default:
				return WarArenaCrown.None;
			}
		}
	}

	public bool isInfluencer => !string.IsNullOrEmpty(influencerLink);

	public string influencerString => (!string.IsNullOrEmpty(influencerAlias)) ? influencerAlias : influencerLink;

	public bool isInLeague => remainingMatches == 0 && leagueDivision != "placement";

	public bool canPlayerSendLogs => sendLogsValue == 1;

	public bool isFacebookConnected => facebookId != -1;

	public bool isGameCenterConnected => !string.IsNullOrEmpty(gameCenterId);

	public bool isGooglePlayConnected => !string.IsNullOrEmpty(googlePlayId);

	public string name
	{
		get
		{
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			if (currentPlayer == null)
			{
				return null;
			}
			if (currentPlayer == this)
			{
				return accountName;
			}
			if (currentPlayer.id == id && currentPlayer.accountName != accountName)
			{
				return currentPlayer.accountName;
			}
			return accountName;
		}
	}

	public string visualsDebugLog
	{
		get
		{
			if (playerVisuals == null)
			{
				return "visuals: null";
			}
			if (playerVisuals.Count != 4)
			{
				string arg = string.Empty;
				foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in playerVisuals)
				{
					arg = " " + playerVisual.Value.equippedID;
				}
				return $"visuals: wrong number {playerVisuals.Count} -{arg}";
			}
			return $"visuals: {playerVisuals[0].equippedID} {playerVisuals[1].equippedID} {playerVisuals[2].equippedID} {playerVisuals[3].equippedID}";
		}
	}

	public string debugBasicInformation => string.Format("DatabasePlayer Name: {0}  Id: {1}  Level: {2}  SquadRank: {3}", (name != null) ? name : "null", (id != null) ? id : "null", level, squadRank);

	public string debugSquadInformation => string.Format("Squad: {0}  SquadPoints: {1}  Reputations: {2}  SquadRank: {3}", (squadName != null) ? squadName : "null", squadPoints, reputation, squadRank);

	public string debugLeagueInformation
	{
		get
		{
			if (isInBeginnersLeague)
			{
				return $"Beginners League:{beginnersLeague}  LeagueMedals: {medalsBalance}  GLobalMedals: {skill}";
			}
			return string.Format("League: {0}  LeagueId: {1}  LeagueDivision: {2}  WeeklyMedals: {3}  GLobalMedals: {4}", leagueTier, (leagueId != null) ? leagueId : "null", (leagueDivision != null) ? leagueDivision : "null", medalsBalance, skill);
		}
	}

	public string debugDepositedWarcards
	{
		get
		{
			string text = "Deposited Warcards: ";
			if (depositedCardsDic != null && depositedCardsDic.Count > 0)
			{
				foreach (KeyValuePair<string, string> item in depositedCardsDic)
				{
					text += string.Format("\"{0}\" ", (item.Key != null) ? item.Key : "null");
				}
			}
			else
			{
				text += "None";
			}
			return text;
		}
	}

	public static DatabasePlayer fakePlayer
	{
		get
		{
			if (mFakePlayer == null)
			{
				mFakePlayer = new DatabasePlayer();
				mFakePlayer.accountName = "FakePlayer";
				mFakePlayer.accountType = AccountType.Guest;
				mFakePlayer.armyPower = 22123;
				mFakePlayer.experience = LevelManager.instance.experience;
				mFakePlayer.id = "fake-player-id";
				mFakePlayer.lastAction = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				mFakePlayer.reputation = 0;
				mFakePlayer.leagueDivision = "fake-division";
				mFakePlayer.vipExpiration = 0;
				mFakePlayer.leagueTier = League.Bronze3;
				mFakePlayer.level = LevelManager.instance.currentLevel.displayNumber;
				mFakePlayer.playerVisuals = GameLoginManager.currentPlayer.playerVisuals;
				mFakePlayer.inventoryData = GameLoginManager.currentPlayer.inventoryData;
				mFakePlayer.levelManagerData = GameLoginManager.currentPlayer.levelManagerData;
				mFakePlayer.skill = 500;
				mFakePlayer.medalsBalance = 0;
				mFakePlayer.remainingMatches = 0;
				mFakePlayer.squadName = GameLoginManager.currentPlayer.squadName;
				mFakePlayer.squadPoints = 0;
				mFakePlayer.squadRank = SquadRank.Member;
				mFakePlayer.status = PlayerStatus.Online;
				mFakePlayer.statisticsData = GameLoginManager.currentPlayer.statisticsData;
				mFakePlayer.awaitingSquadMember = false;
				mFakePlayer.connectionType = InternetConnection.None;
			}
			return mFakePlayer;
		}
	}

	public string CompareToOtherInstance(DatabasePlayer secondInstance)
	{
		if (id != secondInstance.id)
		{
			return null;
		}
		string text = $"Comparing player {name} with id {id}:\n";
		if (name != secondInstance.name)
		{
			text += $"Different names \"{name}\" and \"{secondInstance.name}\"\n";
		}
		if (level != secondInstance.level)
		{
			text += $"Different levels \"{level}\" and \"{secondInstance.level}\"\n";
		}
		if (squadName != secondInstance.squadName)
		{
			text += string.Format("Different squads \"{0}\" and \"{1}\"\n", (squadName != null) ? squadName : "null", (secondInstance.squadName != null) ? secondInstance.squadName : "null");
		}
		if (skill != secondInstance.skill)
		{
			text += $"Different medals \"{skill}\" and \"{secondInstance.skill}\"\n";
		}
		if (armyPower != secondInstance.armyPower)
		{
			text += $"Different army power \"{armyPower}\" and \"{secondInstance.armyPower}\"\n";
		}
		if (squadPoints != secondInstance.squadPoints)
		{
			text += $"Different squad points \"{squadPoints}\" and \"{secondInstance.squadPoints}\"\n";
		}
		if (leagueTier != secondInstance.leagueTier)
		{
			text += $"Different league \"{leagueTier}\" and \"{secondInstance.leagueTier}\"\n";
		}
		if (visualsDebugLog != secondInstance.visualsDebugLog)
		{
			text += $"Different player visuals \"{visualsDebugLog}\" and \"{secondInstance.visualsDebugLog}\"\n";
		}
		return text;
	}

	public string CompareToOtherInstance(FHIPGDADNFG secondInstance)
	{
		if (id != secondInstance.INFLHPGMEOB)
		{
			return null;
		}
		string text = $"Comparing player {name} with id {id}:\n";
		if (name != secondInstance.MHPNDNJDPGE)
		{
			text += $"Different names \"{name}\" and \"{secondInstance.MHPNDNJDPGE}\"\n";
		}
		if (level != secondInstance.BCCDDJMPBLL)
		{
			text += $"Different levels \"{level}\" and \"{secondInstance.BCCDDJMPBLL}\"\n";
		}
		if (squadName != secondInstance.DBNNKLCNDJD)
		{
			text += string.Format("Different squads \"{0}\" and \"{1}\"\n", (squadName != null) ? squadName : "null", (secondInstance.DBNNKLCNDJD != null) ? secondInstance.DBNNKLCNDJD : "null");
		}
		if (skill != secondInstance.CJDHKJFKNAH)
		{
			text += $"Different medals \"{skill}\" and \"{secondInstance.CJDHKJFKNAH}\"\n";
		}
		if (armyPower != secondInstance.AMFJHAPGIJN)
		{
			text += $"Different army power \"{armyPower}\" and \"{secondInstance.AMFJHAPGIJN}\"\n";
		}
		if (visualsDebugLog != secondInstance.EFOPLPDLDEI)
		{
			text += $"Different player visuals \"{visualsDebugLog}\" and \"{secondInstance.EFOPLPDLDEI}\"\n";
		}
		return text;
	}

	internal Card[] GetDepositedCards()
	{
		if (depositedCardsDic == null)
		{
			return new Card[0];
		}
		List<Card> list = new List<Card>();
		foreach (KeyValuePair<string, string> item in depositedCardsDic)
		{
			CardManager.BuddyCardData buddyCardData = JsonConvert.DeserializeObject<CardManager.BuddyCardData>(item.Value);
			if (!string.IsNullOrEmpty(buddyCardData.buddyName))
			{
				list.Add(CardManager.instance.GetSquadCardInstance(item.Key, buddyCardData));
				continue;
			}
			int num = buddyCardData.amount;
			if (num == 0)
			{
				num = 1;
			}
			for (int i = 0; i < num; i++)
			{
				list.Add(CardManager.instance.GetSquadCardInstance(item.Key));
			}
		}
		return list.ToArray();
	}

	internal bool IsDepositedBuddyCard()
	{
		if (depositedCardsDic == null)
		{
			return false;
		}
		foreach (KeyValuePair<string, string> item in depositedCardsDic)
		{
			CardManager.BuddyCardData buddyCardData = JsonConvert.DeserializeObject<CardManager.BuddyCardData>(item.Value);
			if (!string.IsNullOrEmpty(buddyCardData.buddyName))
			{
				return true;
			}
		}
		return false;
	}

	public static DatabasePlayer CreateFromDatabase(JToken item, DatabasePlayer result = null)
	{
		if (result == null)
		{
			result = new DatabasePlayer();
		}
		if (item == null)
		{
			return result;
		}
		if (item["Regions"] != null)
		{
			try
			{
				result.bestRegions = JsonConvert.DeserializeObject<Dictionary<CloudRegionCode, int>>(KHJJFPPACBP.BKFCLMMJNHK("Regions", "S", item, string.Empty));
			}
			catch (Exception kIJELCLONNC)
			{
				Debug.LogError("Bad Player Regions!");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, "Bad player regiones, data= " + KHJJFPPACBP.BKFCLMMJNHK("Regions", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		if (item["Id"] != null)
		{
			result.id = KHJJFPPACBP.BKFCLMMJNHK("Id", "S", item, string.Empty);
		}
		if (item["DepositedCards"] != null)
		{
			result.depositedCardsDic = new Dictionary<string, string>();
			foreach (JToken item2 in (IEnumerable<JToken>)item["DepositedCards"]["M"])
			{
				JProperty jProperty = (JProperty)item2;
				if (jProperty.Value["S"] != null)
				{
					string value = jProperty.Value["S"].ToObject<string>();
					if (Regex.IsMatch(jProperty.Name, "^\\d*-\\d*$"))
					{
						result.depositedCardsDic.Add(jProperty.Name, value);
					}
					continue;
				}
				try
				{
					int num = KHJJFPPACBP.PELILBMKGHE(jProperty.Value["M"]["Amount"]["N"].ToString());
					if (num > 0)
					{
						result.depositedCardsDic.Add(jProperty.Name, JsonConvert.SerializeObject(new CardManager.CardData
						{
							amount = num
						}));
					}
				}
				catch (Exception)
				{
					Debug.LogError("ERROR : Couldnt parse deposited card = " + jProperty.Name);
				}
			}
			if (result.id == GameLoginManager.instance.playerId)
			{
				GameLoginManager.instance.SetDepositedCards(result.depositedCardsDic);
			}
		}
		if (item["InfluencerAlias"] != null)
		{
			result.influencerAlias = KHJJFPPACBP.BKFCLMMJNHK("InfluencerAlias", "S", item, string.Empty);
		}
		if (item["InfluencerLink"] != null)
		{
			result.influencerLink = KHJJFPPACBP.BKFCLMMJNHK("InfluencerLink", "S", item, string.Empty);
		}
		if (item["Level"] != null)
		{
			result.level = KHJJFPPACBP.PELILBMKGHE("Level", "N", item);
		}
		if (item["Reputation"] != null)
		{
			result.reputation = KHJJFPPACBP.PELILBMKGHE("Reputation", "N", item);
			if (result.id == GameLoginManager.instance.playerId)
			{
				GameLoginManager.instance.UpdateReputation(result.reputation);
			}
		}
		if (item["SquadPoints"] != null)
		{
			result.squadPoints = KHJJFPPACBP.PELILBMKGHE("SquadPoints", "N", item);
		}
		string bBFAEPEBENO = Singleton<ServerResultsCache>.instance.BBFAEPEBENO;
		if (!string.IsNullOrEmpty(bBFAEPEBENO) && item[bBFAEPEBENO] != null)
		{
			result.squadPoints += KHJJFPPACBP.PELILBMKGHE(bBFAEPEBENO, "N", item);
		}
		if (item["Name"] != null)
		{
			result.accountName = KHJJFPPACBP.BKFCLMMJNHK("Name", "S", item, string.Empty);
		}
		if (item["VisualType"] != null)
		{
			result.visualType = KHJJFPPACBP.BKFCLMMJNHK("VisualType", "S", item, string.Empty);
		}
		if (item["VisualTimestamp"] != null)
		{
			result.visualTimestamp = KHJJFPPACBP.PELILBMKGHE("VisualTimestamp", "N", item);
		}
		if (item["Experience"] != null)
		{
			result.experience = KHJJFPPACBP.OOAIMCEBPOK("Experience", "N", item, 0L);
		}
		if (item["Country"] != null)
		{
			result.country = KHJJFPPACBP.BKFCLMMJNHK("Country", "S", item, string.Empty);
		}
		if (item["SendLogs"] != null)
		{
			result.sendLogsValue = KHJJFPPACBP.PELILBMKGHE("SendLogs", "N", item);
		}
		else
		{
			result.sendLogsValue = 0;
		}
		if (item["InventoryData"] != null)
		{
			try
			{
				result.inventoryData = JsonConvert.DeserializeObject<PlayerInventory.InventoryData>(KHJJFPPACBP.BKFCLMMJNHK("InventoryData", "S", item, string.Empty));
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("Bad Inventory Data!");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC2, "Bad inventory data, data= " + KHJJFPPACBP.BKFCLMMJNHK("InventoryData", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		if (item["DeviceToken"] != null)
		{
			result.deviceToken = KHJJFPPACBP.BKFCLMMJNHK("DeviceToken", "S", item, string.Empty);
		}
		if (item["LastAction"] != null)
		{
			result.lastAction = KHJJFPPACBP.PELILBMKGHE("LastAction", "N", item);
		}
		if (item["PlayerVisuals"] != null)
		{
			try
			{
				result.playerVisuals = JsonConvert.DeserializeObject<Dictionary<int, CamosManager.SavedPlayerVisualSlot>>(KHJJFPPACBP.BKFCLMMJNHK("PlayerVisuals", "S", item, string.Empty));
			}
			catch (Exception kIJELCLONNC3)
			{
				Debug.LogError("Bad Player Visuals!");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC3, "Bad player visuals, data= " + KHJJFPPACBP.BKFCLMMJNHK("PlayerVisuals", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		if (item["LevelManagerData"] != null)
		{
			try
			{
				result.levelManagerData = JsonConvert.DeserializeObject<LevelManager.LevelManagerData>(KHJJFPPACBP.BKFCLMMJNHK("LevelManagerData", "S", item, string.Empty));
			}
			catch (Exception kIJELCLONNC4)
			{
				Debug.LogError("Bad Level Manager Data!");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC4, "Bad level manager data, data= " + KHJJFPPACBP.BKFCLMMJNHK("LevelManagerData", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		if (item["ArmyPower"] != null)
		{
			result.armyPower = KHJJFPPACBP.PELILBMKGHE("ArmyPower", "N", item);
		}
		if (item["Status"] != null)
		{
			result.status = (PlayerStatus)KHJJFPPACBP.PELILBMKGHE("Status", "N", item);
		}
		if (item["StatisticsData"] != null)
		{
			try
			{
				result.statisticsData = JsonConvert.DeserializeObject<StatsManager.StatisticsData>(KHJJFPPACBP.BKFCLMMJNHK("StatisticsData", "S", item, string.Empty));
			}
			catch (Exception kIJELCLONNC5)
			{
				Debug.LogError("Bad Statistics in DatabasePlayer!");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC5, "Bad player statistics, data= " + KHJJFPPACBP.BKFCLMMJNHK("StatisticsData", "S", item, string.Empty), Environment.StackTrace);
			}
		}
		else
		{
			result.statisticsData = new StatsManager.StatisticsData();
		}
		if (item["BeginnersLeague"] != null)
		{
			result.beginnersLeague = KHJJFPPACBP.PELILBMKGHE("BeginnersLeague", "N", item);
		}
		if (item["Vip"] != null)
		{
			Debug.Log("VIP EXPIRATION RECEIVED");
			result.vipExpiration = KHJJFPPACBP.PELILBMKGHE("Vip", "N", item);
		}
		if (item["LeagueId"] != null)
		{
			result.leagueId = KHJJFPPACBP.BKFCLMMJNHK("LeagueId", "S", item, string.Empty);
			string[] array = result.leagueId.Split('-');
			result.leagueTier = (League)KHJJFPPACBP.PELILBMKGHE(array[0]);
			result.leagueDivision = KHJJFPPACBP.BKFCLMMJNHK(array[array.Length - 1], string.Empty);
		}
		else
		{
			string text = ((item["EligibleLeagueId"] == null) ? "1" : KHJJFPPACBP.BKFCLMMJNHK("EligibleLeagueId", "N", item, string.Empty));
			result.leagueId = text + "-placement";
			result.leagueTier = (League)KHJJFPPACBP.PELILBMKGHE(text);
			result.leagueDivision = "placement";
		}
		if (item["AccountType"] != null)
		{
			result.accountType = (AccountType)KHJJFPPACBP.PELILBMKGHE("AccountType", "N", item);
		}
		if (item["Skill"] != null)
		{
			result.skill = KHJJFPPACBP.PELILBMKGHE("Skill", "N", item);
		}
		if (item["PlacementMatchesRequired"] != null)
		{
			result.remainingMatches = KHJJFPPACBP.PELILBMKGHE("PlacementMatchesRequired", "N", item);
		}
		else
		{
			result.remainingMatches = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE;
		}
		if (item["MedalsBalance"] != null)
		{
			result.medalsBalance = KHJJFPPACBP.PELILBMKGHE("MedalsBalance", "N", item);
		}
		if (!string.IsNullOrEmpty(Singleton<ServerResultsCache>.instance.DIIJOILPPOC) && item[Singleton<ServerResultsCache>.instance.DIIJOILPPOC] != null)
		{
			result.medalsBalance += KHJJFPPACBP.PELILBMKGHE(Singleton<ServerResultsCache>.instance.DIIJOILPPOC, "N", item);
		}
		if (item["SquadId"] != null)
		{
			result.squadName = KHJJFPPACBP.BKFCLMMJNHK("SquadId", "S", item, string.Empty);
		}
		if (item["SquadRank"] != null)
		{
			result.squadRank = (SquadRank)KHJJFPPACBP.PELILBMKGHE("SquadRank", "N", item);
		}
		result.facebookId = ((item["FacebookId"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK("FacebookId", "S", item, 0L));
		if (item["GameCenterId"] != null)
		{
			result.gameCenterId = KHJJFPPACBP.BKFCLMMJNHK("GameCenterId", "S", item, string.Empty);
		}
		if (item["GooglePlayId"] != null)
		{
			result.googlePlayId = KHJJFPPACBP.BKFCLMMJNHK("GooglePlayId", "S", item, string.Empty);
		}
		return result;
	}

	internal PlayerStatus GetRealStatus()
	{
		if (id == GameLoginManager.currentPlayer.id)
		{
			return PlayerStatus.Online;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		return (currentTimestamp - lastAction <= 2700) ? status : PlayerStatus.Offline;
	}

	public static DatabasePlayer CreateFromDatabasePlayerData(FHIPGDADNFG playerData)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = playerData.INFLHPGMEOB;
		databasePlayer.accountName = playerData.MHPNDNJDPGE;
		databasePlayer.facebookId = playerData.IOFHDGKGFBG;
		databasePlayer.playerVisuals = playerData.NFFKMCPMPPI.slots;
		return databasePlayer;
	}

	public void AddGameCenter(string gcId, string gcName)
	{
		gameCenterId = gcId;
	}

	public string GetSquadId()
	{
		return squadName;
	}

	public string GetId()
	{
		return id;
	}

	public void SetSquadId(string squadId)
	{
		squadName = squadId;
	}

	public string GetOriginalGooglePlayId()
	{
		if (googlePlayId == null)
		{
			return null;
		}
		return (!googlePlayId.StartsWith("GooglePlay")) ? googlePlayId : googlePlayId.Substring("GooglePlay".Length);
	}
}
