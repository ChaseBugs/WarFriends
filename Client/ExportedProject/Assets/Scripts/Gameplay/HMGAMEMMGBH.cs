using Newtonsoft.Json.Linq;

public class HMGAMEMMGBH
{
	public long LICHFMFEPBF;

	public string PAEKBHBGNGL;

	public string NNJEKEBMIFL;

	public bool DCMDCDPGFLA;

	public int CFGOLIMEJPM;

	public int ONKHFFGNNOE;

	public static HMGAMEMMGBH JKPDLPBOJHC(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["{0}/{1}"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("Count", "HeroicMissionsCompletionRewardGold", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["globalPlayerLeaderboard"] == null) ? " " : KHJJFPPACBP.BKFCLMMJNHK("facebookID", "test_contentType", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["ID_DELIVEREDTIME"] == null) ? "CREATOR" : KHJJFPPACBP.BKFCLMMJNHK("ID_OFFERACTIVE", "Cards Deposited", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = " ";
			text3 = "Buy_Weapon_Upgrade";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "friendlyName";
			text3 = "*.prefab";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "ID_CONFIRM_SERVERERROR"] == null) ? "Updating reputation for current player = " : KHJJFPPACBP.BKFCLMMJNHK(text3 + "gold", "ID_CATEGORY_LOW_SG_SNIPER", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "ID_LEAGUEFINISHED"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "fr-FR", "GoldReward{0}Max", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "customFloat"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "Player match state {0} to player {1}", "-BUFFMAXDESC", LFPFCHIJLML, 1));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 1;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH PBHNFCJCLOD(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["player_left_coverBack"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("ID_WARNING_ARENADOESNTEXIST", "220 NEXT TUTORIAL STARTING", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["ID_LEAGUE5"] == null) ? "unit" : KHJJFPPACBP.BKFCLMMJNHK("Medals/", "N", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["FollowUsOnTwitter"] == null) ? "Items" : KHJJFPPACBP.BKFCLMMJNHK("ID_WARNING_POORCONNECTION_TEXT", "localPlayerLeaderboard", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = " NOT OK!";
			text3 = "Gold";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "ID_CONFIRM_SQUADALREADYEXISTS";
			text3 = "null";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "ID_WARNING_INCORRECTAMOUNTOFELITEPARTS"] == null) ? "Player entered normal league: {0} and beginners league: {1}" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "PlayerName", "#AccoutCheck# GPGS login during tutorial", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "ID_WARNING_CANTSENDINVITE"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "ReSyncDisabledRPC", "ID_INTIME", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + " / "] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "ID_INMASTER1", "\t\"FALSE\"", LFPFCHIJLML, 1));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH OALBDJKEPNF(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["Parachuter"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("shop", "damage", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["ID_OFFERACTIVE"] == null) ? "skip session update scheduling, because alredy session update is " : KHJJFPPACBP.BKFCLMMJNHK("NULL", "Could not find parent screen", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["SubscriptionNoChange"] == null) ? "601 TUTORIAL STARTED" : KHJJFPPACBP.BKFCLMMJNHK("battlesLostInRow", "ID_INVITETOSQUAD", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "Idle";
			text3 = "End Screen - button content - visual notification changed. End Screen active ";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "Weapon_ID";
			text3 = "1";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "ID_YOUROPPONENT"] == null) ? "ItemRarity_3" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "'Day'0", "disconnect", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "GameControllerOnline.StartGame DONE"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "purchase", "S", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "WarArenaData"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "D2", "-", LFPFCHIJLML, 1));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH CEMIAHIFJBP(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["unit"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("Tutorial_Step_Complete", "1", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["Daily_Visit_Main_Menu"] == null) ? "Your Best" : KHJJFPPACBP.BKFCLMMJNHK("RewardGold", "ID_GUI_LEAGUEBONUS", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["ID_SCORE"] == null) ? "ID_INELITE2" : KHJJFPPACBP.BKFCLMMJNHK("Confirmed_In_App", "ID_RANK", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "\"}";
			text3 = "ID_READYTIME";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "Game shoootable entitiy without owner";
			text3 = "{0}{1}";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "Tank"] == null) ? "BattleRewards" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "EventAssignmentClaimed", "auto", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "ID_SKILLSHOTHINT_TRIPPLEKILL"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "ID_READYTIME", "ReportType", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "com/google/android/gms/common/ConnectionResult"] != null) ? KHJJFPPACBP.PELILBMKGHE(text2 + "Texture reference count is less than zero!", "Avg_fps", LFPFCHIJLML) : 0);
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 1;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH GMKMEBFEDOL(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["mortar_idle_standing"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("ID_STARTERASSIGNMENT", "-{0}-{1}", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["B"] == null) ? "C: " : KHJJFPPACBP.BKFCLMMJNHK("Tutorial upgrade unit running \"{0}\"\n", "{0} {1}", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["ID_WARNING_ARENADOESNTEXIST"] == null) ? "Player" : KHJJFPPACBP.BKFCLMMJNHK("ID_DEBUG_GUIERROR", " (FREE)", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "ID_KILLEDBYENEMYARMYUNIT";
			text3 = "Total_Warpath_Attempts";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "ID_WARNING_PURCHASEERROR";
			text3 = "WeaponTutorial";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "Heroic"] == null) ? "Gold" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "HighLevelSilverRarity", "-", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "Not a gold reward."] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "width", "Buffer already sent!", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + ")"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "): ", "$50-$100", LFPFCHIJLML));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 1;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH DMIAEEKMNHG(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["Deploys_Count"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("Play_Card_Tutorial", "LevelExperience", LFPFCHIJLML, 1);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["ID_CONFIRM_ERROR"] == null) ? "N" : KHJJFPPACBP.BKFCLMMJNHK("ok", "[-]", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["ID_ARENAFLAWLESSREWARDS"] == null) ? "SuggestedSquad" : KHJJFPPACBP.BKFCLMMJNHK("Already loading player data, wait", "\n", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "Card_1_Played";
			text3 = "DatabaseMessage - SquadDemoteMessage:\nPlayer to be demoted/kicked: {0}\nNewRank: {1}\nBy Player: {2}";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "category";
			text3 = "com.tune.TuneLocation";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "Scripts Full Path: \"{0}\"\n"] == null) ? "Directory \"{0}\" does not exists" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "\n</font>", "Buy_Lootboxes", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "isVIP"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "-[0-9]*$", ".", LFPFCHIJLML, 1L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "ID_WAITINGFOROPPONENTCARDS"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "weapon1", "Dron could not be spawned", LFPFCHIJLML));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH MAINIENLLIL(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["TimeStamp"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("TimeStamp", "N", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["ClientId"] == null) ? "-1" : KHJJFPPACBP.BKFCLMMJNHK("ClientId", "S", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["MasterId"] == null) ? "-1" : KHJJFPPACBP.BKFCLMMJNHK("MasterId", "S", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "Client";
			text3 = "Master";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "Master";
			text3 = "Client";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "Name"] == null) ? "p0lski" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "Name", "S", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "FacebookId"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "FacebookId", "S", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "SkillDifference"] != null) ? KHJJFPPACBP.PELILBMKGHE(text2 + "SkillDifference", "N", LFPFCHIJLML) : 0);
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH EJIKFGPAKHO(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["ID_WARNING_BADVERSIONERROR_TEXT"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("FuseBoxx: Session Started", "ID_GUI_EQUIPPED", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["set visual not borrowed"] == null) ? "Player" : KHJJFPPACBP.BKFCLMMJNHK("ID_YOURREWARDS", " is Opponent: ", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["Message Inform Squad Leader About Event came"] == null) ? "ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT" : KHJJFPPACBP.BKFCLMMJNHK("master3", "registerBirthday", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "()F";
			text3 = "VipReward1";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "CheckDisable";
			text3 = "ArenaLives";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + " "] == null) ? "ID_STARTERPACKCONTENTS" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "GoldDeducted", "ID_NUMMEMBERS", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "{0} {1}{2}"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "ID_CONFIRM_ERROR", "TESTING LABELS ON CHILDREN OF OBJECT \"", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "214 MENU ARMY SCREEN TUTORIAL UNIT"] != null) ? KHJJFPPACBP.PELILBMKGHE(text2 + "resultMessage", "ID_READYTIME", LFPFCHIJLML) : 0);
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 1;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH CPJAMAJJDHL(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["DecalManagerData"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("N", "-", LFPFCHIJLML, 1);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["{0} {1}"] == null) ? "ID_INSILVER2" : KHJJFPPACBP.BKFCLMMJNHK("ID_READYTIME", "ID_PASTEYOURVIDEOLINKHERE", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["ID_SHOTDAMAGE"] == null) ? "N" : KHJJFPPACBP.BKFCLMMJNHK("D3", "year", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "height";
			text3 = "WarFriends";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "{0} {1}";
			text3 = "Squad Member record does not have DatabasePlayer";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "GameLoginManager: Setting AccountDataDownloadingProgress = "] == null) ? "doubleValue" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "Rental", "ID_COLEADER", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "PhotonConnectionManager: Find pings found before: {0} Connection changed {1}"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "SquadId", "ID_TABLE_CURRENTLEAGUE", LFPFCHIJLML, 1L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "PickDropPointRPC"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "GameCenterId", "{0} / {1}", LFPFCHIJLML));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 1;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH GHAACDIKLIJ(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["mortar_down_idle"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("{0}{1}", "Assigment", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["Not used sprites ({0}/{1}) in atlas \"{2}\" :\n{3}"] == null) ? "squad" : KHJJFPPACBP.BKFCLMMJNHK("ID_CRAFTING", "Pack_Type", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["players"] == null) ? "stand_up_crawl" : KHJJFPPACBP.BKFCLMMJNHK("Scenes to go through: {0}", "DeathEvent", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "Visit_League_Table";
			text3 = "ID_CONFIRM_LOGGEDOUT";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "Cards_Buddy_Chosen";
			text3 = "ArmyUnitId";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "Beanstalk: Dev access unlocked"] == null) ? "KLHPEJKKNPD" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "FuseRewardedOptionKey_PostRollContinueButtonText", "RegisterParentalConsent()", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "menu-arena-lootbox-bronze"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "Pool", "{0} {1}", LFPFCHIJLML, 1L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "ID_SALEPERCENT"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "S", "ID_ELITEPACK_GOLDDESCRIPTION", LFPFCHIJLML));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH BHPKKIHPAMG(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["TopRun"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("ExperienceGained", "Gold", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["ID_CONTINUE"] == null) ? "menu-warbucks" : KHJJFPPACBP.BKFCLMMJNHK("Assignment: Score points in one battle", "ID_YOURWARCARDWITHDREW", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["Game created on server+"] == null) ? "Null cannot be saved as last weapon." : KHJJFPPACBP.BKFCLMMJNHK("Win", "VISUAL = NULL", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "otherInfo";
			text3 = "Rental";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "ID_LEAGUETOPPOSITIONHINT";
			text3 = "a";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "HeroicMissionsCompletionRewardCardPack"] == null) ? "Measure Session" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "PlayerRank_BoxID", "{0}{1}{2} {3}{4}", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "userId"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "CardId", "PartssGainedScraps", LFPFCHIJLML, 1L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "Unit"] != null) ? KHJJFPPACBP.PELILBMKGHE(text2 + "com/google/android/gms/common/ConnectionResult", "placement", LFPFCHIJLML, 1) : 0);
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH ICGLBEOPPLP(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["id"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("MessageId", "ID_CONFIRM_PROMOTEDEMOTEERROR", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["), "] == null) ? "InApp_ID" : KHJJFPPACBP.BKFCLMMJNHK("Awaiting players - Removing player ", "Price", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["player_level"] == null) ? "ID_GUI_SILVER" : KHJJFPPACBP.BKFCLMMJNHK("Items", "getLooper", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "QUALITY LEVEL: {0} DPI: {1} System memory: {2} Graphics memory: {3}";
			text3 = "*.prefab";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "maxMapId";
			text3 = "FacebookId";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "[FFFFFF] ("] == null) ? "#VOJTA# WAR ARENA CONFIG RECEIVED! Id = " : KHJJFPPACBP.BKFCLMMJNHK(text3 + "Concrete", "ID_SALEPERCENTLINE", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "Scraps"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "ID_REMINDER_GETVALUABLECARDPACKS", "Message Inform Squad Leader About Event came", LFPFCHIJLML, 1L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "Buy_"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "T", "ID_CONFIRM_ERROR", LFPFCHIJLML));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH OGIGGJNFIDE(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["Header {0}"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("ID_SLOTUPGRADE_POWER", "Session: On GC authenticated! Result = ", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["ID_UNLOCKEDATRANK"] == null) ? "ID_GUI_TIMEXPBONUS" : KHJJFPPACBP.BKFCLMMJNHK("ID_SAVEPERCENT", "DogTagRefillTime", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["bazooka_idle"] == null) ? "#AccoutCheck# OnCheckFacebookInTutorial: " : KHJJFPPACBP.BKFCLMMJNHK("ID_CATEGORY_LOW_SG_PRIMARY", "country-australia", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "Experience";
			text3 = "Manual_Unit_Spawn";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "These players came from server as awaiting to squad:\n";
			text3 = "\"";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "_"] == null) ? "+0" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "D2", "ID_TUTORIAL_UPGRADEUNIT_3", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "Special pack content: type: {0} id: {1} seconds: {2}{3}"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "Cards_Chosen", "\ni: {0} center: {1}", LFPFCHIJLML, 0L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "Swipe Raycasts Start FAILED!"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE(text2 + "ItemAmount", "S", LFPFCHIJLML, 1));
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 1;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH DJDAHIHNFHP(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["Client"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("DamageEventPlayerShoot damage: {0} to {1} new HP {2}", "Play_Card_Tutorial", LFPFCHIJLML);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["isLeft "] == null) ? "seconds" : KHJJFPPACBP.BKFCLMMJNHK("AssignemntId", "com.tune.unityutils.TuneUnityDeeplinkListener", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["#PETER# League Arc - start ignore on "] == null) ? "0" : KHJJFPPACBP.BKFCLMMJNHK("), ", "0", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "ID_FEATURE_BURSTSIZE";
			text3 = "ID_EXPIRED";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "S";
			text3 = "ReconnectDialog Hide";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "CONFIRM"] == null) ? " iconName:" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "Total_Transactions", "DogTagRefillTime", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "WarFriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Пожалуйста, подтверди разрешение в последующем диалоге. Мы никогда не воспользуемся эти разрешением для каких-либо других целей."] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + "game-card-ico-mineyourstep-full", "{0} {1}", LFPFCHIJLML, 1L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "  {1}x{0} ( {3} ) doubled for: {2}"] != null) ? KHJJFPPACBP.PELILBMKGHE(text2 + "ID_PURCHASINGINAPP", "On Get Arena Leaderboards: CNT =  ", LFPFCHIJLML) : 0);
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 0;
		return hMGAMEMMGBH;
	}

	public static HMGAMEMMGBH MHECCGBJFKO(JToken LFPFCHIJLML)
	{
		HMGAMEMMGBH hMGAMEMMGBH = new HMGAMEMMGBH();
		if (LFPFCHIJLML["S"] != null)
		{
			hMGAMEMMGBH.ONKHFFGNNOE = KHJJFPPACBP.PELILBMKGHE("Buy_Rental_Army_Unit", "ID_GUI_SYSTEMMAINTENANCE", LFPFCHIJLML, 1);
		}
		string playerId = GameLoginManager.instance.playerId;
		string text = ((LFPFCHIJLML["ID_DAYS"] == null) ? "OrderId" : KHJJFPPACBP.BKFCLMMJNHK("ID_NA", "$1.99", LFPFCHIJLML, string.Empty));
		string pAEKBHBGNGL = ((LFPFCHIJLML["Rental"] == null) ? "menu-twitter" : KHJJFPPACBP.BKFCLMMJNHK("Logs sent to server\nWaiting for response", "Buy_Weapon", LFPFCHIJLML, string.Empty));
		string text2;
		string text3;
		if (playerId == text)
		{
			hMGAMEMMGBH.PAEKBHBGNGL = pAEKBHBGNGL;
			text2 = "ID_SALEPERCENTLINE";
			text3 = "ID_WARNING_BLACKMARKETDOESNTEXIST";
		}
		else
		{
			hMGAMEMMGBH.PAEKBHBGNGL = text;
			text2 = "T";
			text3 = "ID_CREATESQUADNOTENOUGH";
		}
		hMGAMEMMGBH.NNJEKEBMIFL = ((LFPFCHIJLML[text3 + "View_Stats"] == null) ? "ID_READYTIME" : KHJJFPPACBP.BKFCLMMJNHK(text3 + "ID_DOWNLOADINGFILES", "ID_THATWASGOODRUNSOLDIERXWINS", LFPFCHIJLML, string.Empty));
		hMGAMEMMGBH.LICHFMFEPBF = ((LFPFCHIJLML[text3 + "ID_INGOLD2"] == null) ? (-1) : KHJJFPPACBP.OOAIMCEBPOK(text3 + ")", "ID_ARENAMODE", LFPFCHIJLML, 1L));
		hMGAMEMMGBH.CFGOLIMEJPM = ((LFPFCHIJLML[text2 + "ID_WAITINGFORREPLAYKIT"] != null) ? KHJJFPPACBP.PELILBMKGHE(text2 + "game-elite-debuff", "ETM: Show Rewarded Video", LFPFCHIJLML) : 0);
		hMGAMEMMGBH.DCMDCDPGFLA = hMGAMEMMGBH.CFGOLIMEJPM > 1;
		return hMGAMEMMGBH;
	}
}
