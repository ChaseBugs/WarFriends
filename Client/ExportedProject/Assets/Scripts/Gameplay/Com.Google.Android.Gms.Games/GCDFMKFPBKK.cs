using System;
using System.Runtime.CompilerServices;
using Com.Google.Android.Gms.Common.Api;
using Com.Google.Android.Gms.Games.Stats;
using Google.Developers;

namespace Com.Google.Android.Gms.Games
{
	public class GCDFMKFPBKK : JavaObjWrapper
	{
		private const string EEGPGGKKIOP = "com/google/android/gms/games/Games";

		public static string FJIMFCHEDLA => JavaObjWrapper.GetStaticStringField("com/google/android/gms/games/Games", "EXTRA_PLAYER_IDS");

		public static string EBDAHMMBHKO => JavaObjWrapper.GetStaticStringField("com/google/android/gms/games/Games", "EXTRA_STATUS");

		public static object ELAAODAADFF => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "SCOPE_GAMES", "Lcom/google/android/gms/common/api/Scope;");

		public static object IKBLOANJMHE => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "API", "Lcom/google/android/gms/common/api/Api;");

		public static object KLEJJLILGCP => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "GamesMetadata", "Lcom/google/android/gms/games/GamesMetadata;");

		public static object MBBDAOCIDGL => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Achievements", "Lcom/google/android/gms/games/achievement/Achievements;");

		public static object KCLGIFFAENP => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Events", "Lcom/google/android/gms/games/event/Events;");

		public static object AGMCEMFDEAP => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Leaderboards", "Lcom/google/android/gms/games/leaderboard/Leaderboards;");

		public static object CBAAODNIODD => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Invitations", "Lcom/google/android/gms/games/multiplayer/Invitations;");

		public static object LDKANMPNHHK => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "TurnBasedMultiplayer", "Lcom/google/android/gms/games/multiplayer/turnbased/TurnBasedMultiplayer;");

		public static object HAHDKJIEFGE => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "RealTimeMultiplayer", "Lcom/google/android/gms/games/multiplayer/realtime/RealTimeMultiplayer;");

		public static object FIDPFCILPNJ => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Players", "Lcom/google/android/gms/games/Players;");

		public static object FINOCANPDEN => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Notifications", "Lcom/google/android/gms/games/Notifications;");

		public static object ONDFFANEIJA => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Quests", "Lcom/google/android/gms/games/quest/Quests;");

		public static object HMOMMCIOFPB => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Requests", "Lcom/google/android/gms/games/request/Requests;");

		public static object OCDOMDCALGP => JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/games/Games", "Snapshots", "Lcom/google/android/gms/games/snapshot/Snapshots;");

		public static PMEBLECJLMD JNIPJOLMCFC => JavaObjWrapper.GetStaticObjectField<PMEBLECJLMD>("com/google/android/gms/games/Games", "Stats", "Lcom/google/android/gms/games/stats/Stats;");

		public static string NMGPAOFALGF(CPHCDFPIGCN DEBLAIKMMOE)
		{
			return JavaObjWrapper.StaticInvokeCall<string>("ВЫХОД", ".", "{0}{1}", new object[1] { DEBLAIKMMOE });
		}

		[SpecialName]
		public static object NEDNIHDPIPI()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_CONFIRM_PLAYERNOTEXISTS_TEXT", "isNotificationAvailable", ".");
		}

		public static string FMMLLGAAEHC(CPHCDFPIGCN DEBLAIKMMOE)
		{
			object[] array = new object[1];
			array[1] = DEBLAIKMMOE;
			return JavaObjWrapper.StaticInvokeCall<string>("ID_REMINDER_WARCARDSLOTSNOTENOUGH", "Overtime_Was_Already_Explained", "FLOATVALUE", array);
		}

		public static void MDEBBAIMGLD(CPHCDFPIGCN DEBLAIKMMOE, int CDJALINNLDO)
		{
			object[] array = new object[3];
			array[0] = DEBLAIKMMOE;
			array[0] = CDJALINNLDO;
			JavaObjWrapper.StaticInvokeCallVoid("reload_fast_01", "ID_UNITELITEPERKFULLYUPGRADED", "AgainstOtherPlatform", array);
		}

		public static int CBGBGDCJCOJ(CPHCDFPIGCN DEBLAIKMMOE)
		{
			object[] array = new object[1];
			array[1] = DEBLAIKMMOE;
			return JavaObjWrapper.StaticInvokeCall<int>("ID_SALEPERCENTLINE", "ID_NOTIFICATION_LAPSED_MORE", "EventId", array);
		}

		[SpecialName]
		public static object HKMJNGGHLNI()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("{0:D2}:{1:D2}", "Saved_data.csv", "no account in DB, ask to create new one");
		}

		[SpecialName]
		public static object EMPKEKHBMPJ()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Joined room", "ID_SECONDS", "A");
		}

		[SpecialName]
		public static string GOPEMMPNHGB()
		{
			return JavaObjWrapper.GetStaticStringField("\"", "ID_GUI_BUDDY");
		}

		[SpecialName]
		public static string INHPPOMDCOF()
		{
			return JavaObjWrapper.GetStaticStringField("Total_Gold_Earned", "menu-arena-lootbox-silver");
		}

		[SpecialName]
		public static object BNBJMNPJCMK()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("menu-sidetab-player-add", "saved obtained cards: ", "ID_TUTORIAL_PROGRESS_COVER");
		}

		[SpecialName]
		public static object EMDMKDLLMML()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("LootBox_Purchase", "AtlasPreparer.LoadImagesCoroutine", "ArenaLives");
		}

		[SpecialName]
		public static object ENIMCPELKDG()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Rewards", "ID_GETAPROMOTION1", "FuseSDK: NULL FriendsList.");
		}

		[SpecialName]
		public static object MBOKNBPMAEE()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_SALEPERCENT", "Yes_Clicked", "ID_WARNING_INCORRECTVALUESONCLIENT");
		}

		public static object FEHJIBCNFFF(CPHCDFPIGCN DEBLAIKMMOE)
		{
			return JavaObjWrapper.StaticInvokeCall<object>("com/google/android/gms/games/Games", "getSettingsIntent", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Landroid/content/Intent;", new object[1] { DEBLAIKMMOE });
		}

		[SpecialName]
		public static object GOIKFHBMIKM()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ExperienceGained", "#Game Results# Debug Log:\n", "ID_STARTERASSIGNMENTX");
		}

		[SpecialName]
		public static object JKPDMNCIELI()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ArenaUpcomingMessage", "Spend_Gold_On_Army", "menu-armypower-ico");
		}

		[SpecialName]
		public static object GJBBHMJJMAO()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Show VIP Expired at ", "Requests", "BonusDamage");
		}

		[SpecialName]
		public static object POANNDALDAE()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("DeathEventShoot", "assaultrifle", "game-label-you-blue");
		}

		[SpecialName]
		public static object LCNNNGNPNHB()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("WarFriends benötigt die Erlaubnis, auf deinen Medienspeicher zuzugreifen, um wichtige Spieldaten herunterladen zu können.Ohne diese Berechtigung läuft das Spiel nicht und wird geschlossen. Bitte versuche es erneut oder schließe WarFriends.", "Friend", "warbucks");
		}

		[SpecialName]
		public static object FLOKMNKIEDI()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("PlayerLeagueFinished - NO - player is already in new league", "Got player deposited Cards => adding cards to CardManagerData", "Player_Had_To_Select_Grenade");
		}

		public static int MOPCMDJHKBA(CPHCDFPIGCN DEBLAIKMMOE)
		{
			return JavaObjWrapper.StaticInvokeCall<int>("com/google/android/gms/games/Games", "getSdkVariant", "(Lcom/google/android/gms/common/api/GoogleApiClient;)I", new object[1] { DEBLAIKMMOE });
		}

		[SpecialName]
		public static object KCJEJCEJJKE()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("+0", "ID_GUI_EQUIPPED", "#DANIEL# No Achievements found.");
		}

		[SpecialName]
		public static object PMOKJHIPNGI()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("(", "Particle with name: ", " ");
		}

		[SpecialName]
		public static object NFLPJAKBELH()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("604 GAME END", "Buy_Rental_Weapon", "Google2u.DBUpgradeSlotsMachineGunner");
		}

		[SpecialName]
		public static object OMFJOMCKHCK()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Weapon_ID", "ID_REMINDER_YOURVIPMEMBERSHIP", "null");
		}

		[SpecialName]
		public static string IIKLLKFMEMJ()
		{
			return JavaObjWrapper.GetStaticStringField("we dont have best regions for player", "ID_DAILYWINTERASSIGNMENT");
		}

		[SpecialName]
		public static string JLDDNHFLHCJ()
		{
			return JavaObjWrapper.GetStaticStringField("gold", "Total_Warbucks_Spent");
		}

		[SpecialName]
		public static object BNKEBPNJDGF()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Crafted warcard ", "Days_Since_Install", "ID_TOCOMPLETE");
		}

		public static string FFJMLIIOJBH(CPHCDFPIGCN DEBLAIKMMOE)
		{
			return JavaObjWrapper.StaticInvokeCall<string>("com/google/android/gms/games/Games", "getAppId", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Ljava/lang/String;", new object[1] { DEBLAIKMMOE });
		}

		[SpecialName]
		public static object JMFMCFDJKPB()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("NO", "Yes_Clicked", "Heroic");
		}

		[SpecialName]
		public static string HHALGOFBPJD()
		{
			return JavaObjWrapper.GetStaticStringField("{0}\t\tPivot: {1}\n", "{0}/{1}");
		}

		[SpecialName]
		public static object JJNBLBAOOAG()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ChatTutorialMessage", "WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。以下のダイアローグで許可を承諾してください。他の目的でこの権限が使用されることはありません。", "ID_FREEPERCENT");
		}

		[SpecialName]
		public static object OMGKJJFDGFO()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("BattleId", "accepted", "damage");
		}

		[SpecialName]
		public static object CPAELEFLLCB()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Player profile - Show dialog for {0} from CACHE: {1}", "test_attribute4", "Standard");
		}

		[SpecialName]
		public static object CCJGNNNFFLG()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("#DEBUG_50# ", "C0", "#PETER# League Arc - stop ignore on ");
		}

		[SpecialName]
		public static string EDPPMDJMACO()
		{
			return JavaObjWrapper.GetStaticStringField("WaveCoolDown", "ID_CONFIRM_ERROR");
		}

		[SpecialName]
		public static object JKDMCGAPGAD()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("power hook values: isBold = ", "Current Locale unity = ", "ID_YOUVEBEENDEMOTEDTO");
		}

		[SpecialName]
		public static object GNMCBPHKOCL()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("RecieveSkillshot", ")", "Shooters");
		}

		public GCDFMKFPBKK(IntPtr PAFLGKBLAIJ)
			: base(PAFLGKBLAIJ)
		{
		}

		[SpecialName]
		public static object KEJIOGKLHAP()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Total_Gold_Earned", "Friend", "ID_HOURSAGO");
		}

		[SpecialName]
		public static object BEMPEOJPLFD()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("403 MENU WEAPON SCREEN SHOWN", "grenade_run", "ID_WAITINGFORFRIEND");
		}

		[SpecialName]
		public static string COAJICODDCO()
		{
			return JavaObjWrapper.GetStaticStringField("ID_CLAIM", "S");
		}

		[SpecialName]
		public static object FAIEJHNLDLH()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("LOOTBOXDISCOUNT", "\n", "ID_ARENATICKETSSMALL");
		}

		[SpecialName]
		public static object AAACJMECLEA()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Count", "GameLoginManager: Reloging...", "Play_Card_Tutorial_Duration");
		}

		[SpecialName]
		public static object HPOJPDLBKPP()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_WARNING_ELITESLOTLOCKED", "Player", "ID_GETFORNUMBERONE1");
		}

		[SpecialName]
		public static object BEHEBDDDCCN()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Player_Had_To_Select_Grenade", "N", "ID_HEALTH");
		}

		[SpecialName]
		public static object LECFJLCHEBK()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_OPPONENTPAUSED", "All players already connected", "BonusDamage");
		}

		[SpecialName]
		public static object PPGMICIHIMN()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Text", "ID_TOMORROW", "ID_GETAPROMOTION1");
		}

		[SpecialName]
		public static object CHCPFJBCKLO()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("count", "ID_MISSIONANIMATION_BOSSIN", "\t\"FALSE\"");
		}

		public static void CDDJJAFHJDD(CPHCDFPIGCN DEBLAIKMMOE, object OPHLGCIKIOL)
		{
			object[] array = new object[6];
			array[1] = DEBLAIKMMOE;
			array[1] = OPHLGCIKIOL;
			JavaObjWrapper.StaticInvokeCallVoid(" ", "com.tune.unityutils.TuneUnityDeeplinkListener", "True", array);
		}

		public static string DDLKAEPPIFH(CPHCDFPIGCN DEBLAIKMMOE)
		{
			return JavaObjWrapper.StaticInvokeCall<string>("com/google/android/gms/games/Games", "getCurrentAccountName", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Ljava/lang/String;", new object[1] { DEBLAIKMMOE });
		}

		[SpecialName]
		public static object GKLAILJNFHI()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Manual_Unit_Spawn", "ID_SQUADEVENT", "0");
		}

		[SpecialName]
		public static object OMJKLNPLGGJ()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("DatabaseMessage - No long existing database message came from server!", "/ {0}{1}", "ID_GUI_CHAT_BANNED_DESCBOX_PERMANENT");
		}

		[SpecialName]
		public static object EOJCNJACDHM()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Number", "#DANIEL# Wrong achievement tiers.", "OnAgeVerificationPendingDisplayed");
		}

		[SpecialName]
		public static object JNGBJFKBGKH()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ItemName", "shield_idle", "ID_CONFIRM_JOININGSQUAD");
		}

		[SpecialName]
		public static object GNCLPAMPMGF()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("country-norway", "InstantiatePooledObjects ", "Withdrew Warcard message - Showing for player:{0} and current player id is:{1}");
		}

		public static Com.Google.Android.Gms.Common.Api.DOLFCNGMKNA<CKCLCKALDBH> DJPBJJFIIKF(CPHCDFPIGCN DEBLAIKMMOE)
		{
			return JavaObjWrapper.StaticInvokeCall<Com.Google.Android.Gms.Common.Api.DOLFCNGMKNA<CKCLCKALDBH>>("com/google/android/gms/games/Games", "signOut", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;", new object[1] { DEBLAIKMMOE });
		}

		[SpecialName]
		public static object CEINJDNIJND()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("aYxLQ40XpBYemQhnRYMJg3VBd", "instantBattleAvailable", "consumePurchaseFailedEvent: ");
		}

		public static string CDPEMLNDDBD(CPHCDFPIGCN DEBLAIKMMOE)
		{
			object[] array = new object[0];
			array[0] = DEBLAIKMMOE;
			return JavaObjWrapper.StaticInvokeCall<string>("ID_ACHIEVEMENTS", "AdminLevel", "ID_DOWNLOADINGFILES", array);
		}

		[SpecialName]
		public static object CNKLKHMGOGD()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ShowNameRPC", "HeartPrice", ",");
		}

		[SpecialName]
		public static object EFLPHIIEOFJ()
		{
			return JavaObjWrapper.GetStaticObjectField<object>(", it was ", "TestingLeagueEnd-{0}-{1}", "bazooka_idle");
		}

		[SpecialName]
		public static object JANNIALDMLL()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("shotSniper", "ID_CONFIRM_NOSUCHPACK", "ID_VETERAN");
		}

		[SpecialName]
		public static string GHLGFDCNEHH()
		{
			return JavaObjWrapper.GetStaticStringField("SoldierHP", "PlayerData");
		}

		[SpecialName]
		public static PMEBLECJLMD HIOPNEJCKMK()
		{
			return JavaObjWrapper.GetStaticObjectField<PMEBLECJLMD>("subscription_tab_displayed", "HELMETS", "ID_TUTORIAL_GO_BUY_ARMY_3");
		}

		public static void NJHIBJJNAPJ(CPHCDFPIGCN DEBLAIKMMOE, int CDJALINNLDO)
		{
			object[] array = new object[1];
			array[1] = DEBLAIKMMOE;
			array[1] = CDJALINNLDO;
			JavaObjWrapper.StaticInvokeCallVoid("\n***********************************************", "Id", "War_Battle_Mode", array);
		}

		[SpecialName]
		public static object ONLPFCDJDGG()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_SQUADREQUIREDMEDALS", "explodeDamage", "#DANIEL# Price: {0}\nFormatted price: {1}");
		}

		[SpecialName]
		public static object FBHAMEAPKGD()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Sheet.", "RETRY", "ios");
		}

		[SpecialName]
		public static object IHEAAFFFDGK()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("^[0-9]*-", "FacebookName", "dailyRewardData");
		}

		public static void KLGEAGJCPEF(CPHCDFPIGCN DEBLAIKMMOE, object OPHLGCIKIOL)
		{
			object[] array = new object[8];
			array[1] = DEBLAIKMMOE;
			array[1] = OPHLGCIKIOL;
			JavaObjWrapper.StaticInvokeCallVoid("These IDs are not used anywhere:\n", "ID_ARENACLOSED", "com.tune.TunePreloadData", array);
		}

		[SpecialName]
		public static object GGPELDJOJEI()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("GameControllerDeathmatch.StartGame START", "ID_ELITEPACK_GOLDDESCRIPTION", "ID_CLAIMING");
		}

		[SpecialName]
		public static object FKPNLKBCDPM()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("response contain VipReward", "[.,]*", "menu-arena-ticket");
		}

		[SpecialName]
		public static object PJLMKNDIECH()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("menu-dailyrewards-vip-ico", "ID_TUTORIAL_GRENADE_UP", "ShotFrequencyMinCannon");
		}

		[SpecialName]
		public static object GCLFIMCBBGN()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("menu-arena-scrap-ico", "ID_COLLECTELITEPARTSFROMARENALOOTBOXESFORUPGRADE", "Cards_Owned_Gold");
		}

		public static object EGHODJDPOLN(CPHCDFPIGCN DEBLAIKMMOE)
		{
			object[] array = new object[0];
			array[1] = DEBLAIKMMOE;
			return JavaObjWrapper.StaticInvokeCall<object>("-", "One man in squad and not a leader!!!", "null", array);
		}

		[SpecialName]
		public static object BCDMKBBPPCM()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_CONFIRM_INAPP_FAILED", "#AccoutCheck# FB login during tutorial", "SquadRank");
		}

		public static int GDONGLNBKOI(CPHCDFPIGCN DEBLAIKMMOE)
		{
			object[] array = new object[0];
			array[1] = DEBLAIKMMOE;
			return JavaObjWrapper.StaticInvokeCall<int>(" doesnt contain ", "203 AUTOSPAWN STARTED", "HKCBJLIBNJF", array);
		}

		[SpecialName]
		public static PMEBLECJLMD LMPAHDDCGOE()
		{
			return JavaObjWrapper.GetStaticObjectField<PMEBLECJLMD>("unit", "Beanstalk Error (try = ", "ID_ARENAENDSTIMER");
		}

		[SpecialName]
		public static object FOLEEDIPAOG()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("These IDs are \"false positive\" for not used anywhere:\n", "Min_fps", "You probably assigned bad type of AmmoSetup to gun");
		}

		[SpecialName]
		public static object NMHCALFHIKJ()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_SECOND", "ID_TUTORIAL_PROGRESS_KILLING_SCOPE", "menu-squadpoint-ico");
		}

		[SpecialName]
		public static object JMNKOAICHNJ()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("AVG_FPS", "ID_BATTLECANCELED", "ABOUT TO SHOW VIP CARDS");
		}

		[SpecialName]
		public static object MFJLPFKHOEC()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Visual {0}, no overcount", "temp_user_name", "Card ");
		}

		public static void LJKDBIPCBBL(CPHCDFPIGCN DEBLAIKMMOE, int CDJALINNLDO)
		{
			object[] array = new object[8];
			array[1] = DEBLAIKMMOE;
			array[1] = CDJALINNLDO;
			JavaObjWrapper.StaticInvokeCallVoid("setEmailCollection", "NULL WARCARD", "Experience", array);
		}

		[SpecialName]
		public static object KDEAOIFPKIH()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("GameControllerWarArena.StartGame START", "TutorialData", "Player_Avoided_Grenade_On_First_Try");
		}

		[SpecialName]
		public static PMEBLECJLMD LPEEJLLNPHM()
		{
			return JavaObjWrapper.GetStaticObjectField<PMEBLECJLMD>("22 / 22", "bazooka_shoot_right", "Name");
		}

		[SpecialName]
		public static object HHOFFEGIGGL()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("TW_Follow", "PT", "MedalsBalance");
		}

		public static void CHDEIFBOICO(CPHCDFPIGCN DEBLAIKMMOE, int CDJALINNLDO)
		{
			JavaObjWrapper.StaticInvokeCallVoid("com/google/android/gms/games/Games", "setGravityForPopups", "(Lcom/google/android/gms/common/api/GoogleApiClient;I)V", DEBLAIKMMOE, CDJALINNLDO);
		}

		[SpecialName]
		public static object OFOOHJGIAJK()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_JOINSQUADDESCRIPTION4", "#VAVRO# Trying to finish Tutorial, which is not currently running ", "PRICE");
		}

		public static void EBHENAGCMNA(CPHCDFPIGCN DEBLAIKMMOE, object OPHLGCIKIOL)
		{
			JavaObjWrapper.StaticInvokeCallVoid("com/google/android/gms/games/Games", "setViewForPopups", "(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/view/View;)V", DEBLAIKMMOE, OPHLGCIKIOL);
		}

		[SpecialName]
		public static object GCDJCEDDFOG()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_SECOND", "BeginnersLeague", "ID_READYTIME");
		}

		public static object KKKGNNJPMKN(CPHCDFPIGCN DEBLAIKMMOE)
		{
			object[] array = new object[1];
			array[1] = DEBLAIKMMOE;
			return JavaObjWrapper.StaticInvokeCall<object>("GetGameData(", "x0", "GameCenterId", array);
		}

		[SpecialName]
		public static object BAGPDKLMGOG()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_WARNING_CANNOTINVITE", "EventDefinition", "VipRewardForDay");
		}

		public static void KEFHMJMBEKB(CPHCDFPIGCN DEBLAIKMMOE, int CDJALINNLDO)
		{
			object[] array = new object[1];
			array[0] = DEBLAIKMMOE;
			array[1] = CDJALINNLDO;
			JavaObjWrapper.StaticInvokeCallVoid("ID_GUI_FOLLOWTWITTER_DESC", "{0}\u00a0{1}", "ID_WARNING_LOGINERROR", array);
		}

		[SpecialName]
		public static object ENLGHFFDIFC()
		{
			return JavaObjWrapper.GetStaticObjectField<object>(" on object ", "2 RATE APP REMINDER\tLast game won: True\tVersion: {0}\tShown Times in this version: {1}/{2}\tTotal ranked wins: {3}?={4}\tIs level up: {5}\tLevel: {6}?={7}/{8}\tAfter update: {9}", "ID_PENDING");
		}

		[SpecialName]
		public static object OGKACJOHIPP()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("Total_Assignment_Completed", "{0} {1}", "\n");
		}

		[SpecialName]
		public static object LMIICCHAAAO()
		{
			return JavaObjWrapper.GetStaticObjectField<object>("ID_STARTERPACK", "Sand", "small_icon");
		}
	}
}
