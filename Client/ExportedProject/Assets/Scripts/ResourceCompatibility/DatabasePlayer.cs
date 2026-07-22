using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

[Preserve]
public class DatabasePlayer : BBHBMFEDANN
{
	public static int maxPlayerName;

	public string accountName;

	public AccountType accountType;

	public int armyPower;

	public string deviceToken;

	public long experience;

	public long facebookId;

	public string googlePlayId;

	public string siwaId;

	public string id;

	public int lastAction;

	public int reputation;

	public int invaderDamage;

	public string leagueDivision;

	public string leagueId;

	public int vipExpiration;

	public int subscriptionExpiration;

	public League leagueTier;

	public Dictionary<string, string> depositedCardsDic;

	public int level;

	public string country;

	public int sendLogsValue;

	public int isActiveGDPR;

	public int matchmakingBan;

	public int challengeBan;

	public int arenaBan;

	public int beginnersLeague;

	public int prestigeLevel;

	public Dictionary<int, CamosManager.SavedPlayerVisualSlot> playerVisuals;

	public PlayerInventory.InventoryData inventoryData;

	public LevelManager.LevelManagerData levelManagerData;

	public AugmentationManager.AugmentationData augmentationData;

	public WeaponAugsManager.WeaponAugData weaponAugData;

	public int skill;

	public int? skillChangeInLastMatch;

	public int medalsBalance;

	public int remainingMatches;

	public string squadName;

	public int squadPoints;

	public bool isNewSquad;

	public SquadRank squadRank;

	public PlayerStatus status;

	public string gameCenterId;

	public StatsManager.StatisticsData statisticsData;

	public bool awaitingSquadMember;

	public string visualType;

	public int visualTimestamp;

	public string influencerLink;

	public string influencerAlias;

	public int offersDisabled;

	[JsonIgnore]
	public Dictionary<CloudRegionCode, int> bestRegions;

	public InternetConnection connectionType;

	private static DatabasePlayer mFakePlayer;

	public int armyPowerX10 => 0;

	public bool isInBeginnersLeague => false;

	public bool isPrestigeActive => false;

	public int avatarLevel => 0;

	public Dictionary<string, LevelManager.SavedArmySlots> equippedUnits
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public WarArenaCrown warArenaCrown => default(WarArenaCrown);

	public bool isInfluencer => false;

	public string influencerString => null;

	public bool isInLeague => false;

	public bool canPlayerSendLogs => false;

	public bool freeToPlayBullshit => false;

	public bool applyRulesGDPR => false;

	public bool isMatchmakingBan => false;

	public bool isArenaBan => false;

	public bool isChallengeBan => false;

	public bool isFacebookConnected => false;

	public bool isGameCenterConnected => false;

	public bool isGooglePlayConnected => false;

	public bool isSIWAConnected => false;

	public string name => null;

	public string visualsDebugLog => null;

	public string debugBasicInformation => null;

	public string debugSquadInformation => null;

	public string debugLeagueInformation => null;

	public string debugDepositedWarcards => null;

	public static DatabasePlayer fakePlayer => null;

	public string CompareToOtherInstance(DatabasePlayer secondInstance)
	{
		return null;
	}

	public string CompareToOtherInstance(DMHJBMDKJNO secondInstance)
	{
		return null;
	}

	internal Card[] GetDepositedCards()
	{
		return null;
	}

	internal bool IsDepositedBuddyCard()
	{
		return false;
	}

	public static DatabasePlayer CreateFromDatabase(JToken item, DatabasePlayer result = null)
	{
		return null;
	}

	public static DatabasePlayer CreateFakeDatabasePlayer(KJLIMOPJICE playerProperties, CloudRegionCode bestRegion)
	{
		return null;
	}

	internal PlayerStatus GetRealStatus()
	{
		return default(PlayerStatus);
	}

	public static DatabasePlayer CreateFromDatabasePlayerData(DMHJBMDKJNO playerData)
	{
		return null;
	}

	public void AddGameCenter(string gcId, string gcName)
	{
	}

	public string GetSquadId()
	{
		return null;
	}

	public string GetId()
	{
		return null;
	}

	public void SetSquadId(string squadId)
	{
	}

	public string GetOriginalGooglePlayId()
	{
		return null;
	}

	public string GetOriginalSIWAId()
	{
		return null;
	}
}
