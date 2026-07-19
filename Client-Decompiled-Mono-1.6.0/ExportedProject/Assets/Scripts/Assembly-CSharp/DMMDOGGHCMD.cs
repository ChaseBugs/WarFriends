using System.Runtime.CompilerServices;

public class DMMDOGGHCMD : KJMGFHMIBII
{
	public override bool MBOHGLCBEFJ
	{
		get
		{
			return true;
		}
	}

	public override RoomOptions NCDDLBIJIIH
	{
		get
		{
			RoomOptions roomOptions = base.NCDDLBIJIIH;
			roomOptions.IsVisible = true;
			return roomOptions;
		}
	}

	public override int MANOCBMEGOK
	{
		get
		{
			return 10;
		}
	}

	public override string NJKMFAGIKIE
	{
		get
		{
			return "randomLobby" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
		}
	}

	[SpecialName]
	public virtual string MGFPCIACIBJ()
	{
		return "ID_DEBUG_STACKTRACEINCONSOLE" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
	}

	public virtual string LHPHGFACCHO(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.NPOEMAMPNEP(), "ID_GUI_SQUADLEVELEDUP", "ID_CONFIRM_RESTART_TEXT", 1475f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ID_GOLDPACK", "Google2u.DBUpgradeSlotsAssaulter", 1252f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "BotLevel", "WarBucks", 1910f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "http://localhost:8081/", "Xp", 887f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1493f), "1", "discount", 229f);
		string[] array = new string[95];
		array[0] = text;
		array[0] = "Assets";
		array[6] = text2;
		array[3] = "ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT";
		array[0] = text3;
		array[7] = "Days_Since_Install";
		array[6] = text4;
		array[8] = "grenadeExplosion";
		array[5] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int MKOHDEMJNBJ()
	{
		return 45;
	}

	[SpecialName]
	public virtual string ICLENMEABBL()
	{
		return "Desert" + Singleton<CurrentBundleVersion>.instance.BELIAKELGGL();
	}

	public virtual string PKFOBCCOHBJ(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.displayNumber, "ID_LEAGUE12", "getNumberOfPurchases", 1965f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "Weapon", "ID_DEPLOYEDSOLDIERS", 199f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "PlayerStatus", "Dictionary filled and contains {0} ids", 909f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ID_CONFIRM_ERROR", "com/google/android/gms/common/ConnectionResult", 1615f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1770f), "{0} {1}{2}", "game-ico-poison", 869f);
		string[] array = new string[11];
		array[0] = text;
		array[0] = "WALLET - initialization WB {0}";
		array[2] = text2;
		array[0] = "game-card-ico-shieldgenerator";
		array[0] = text3;
		array[5] = "Xp";
		array[1] = text4;
		array[4] = "'Offer '0";
		array[3] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual RoomOptions PCNLIPIJEFK()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual int KHIPMAHCIDF()
	{
		return 71;
	}

	public virtual string CEAAADLKKMA(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ABCCINJGPGD(), "Desert", "ID_YOUNEEDTOEQUIPWEAPON", 1901f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ArenaWins", "[FFFFFF]{0}[-]  {1}", 379f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "Gold", "Notifications", 1273f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "warp_idle", "Buy_Army_Unit_At_Rank_Gold", 1504f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 373f), "pistol", "BattleRewards", 224f);
		string[] array = new string[-9];
		array[1] = text;
		array[0] = "players";
		array[6] = text2;
		array[0] = "SquadWarsPosition";
		array[2] = text3;
		array[6] = "{0}{1}{2} {3}{4}";
		array[8] = text4;
		array[8] = "SkillDifference";
		array[8] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int PFEBBPAINHP()
	{
		return 31;
	}

	[SpecialName]
	public virtual string MBFJDNGJNDO()
	{
		return "0" + Singleton<CurrentBundleVersion>.instance.PPNKHOBNDCI();
	}

	[SpecialName]
	public virtual string KPFEJFONGGE()
	{
		return "ID_BUYSTARTERPACK" + Singleton<CurrentBundleVersion>.instance.BELIAKELGGL();
	}

	public virtual string MMDODNMOKGF(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.displayNumber, "weapon", "FLOATVALUE", 1004f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "{0}: {1}\n", "Play_Card_Tutorial_Duration", 1045f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ID_INVITATIONDENIED", "PNManager: Not rescheduling -> data.localNotifications is null", 24f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "CheckEnable", ", name = ", 1910f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1317f), "Player_Had_To_Select_Grenade", "FakeDoNotClick{0:2}", 1127f);
		string[] array = new string[59];
		array[0] = text;
		array[0] = "ID_DEBUG_GUIERROR";
		array[0] = text2;
		array[8] = "ID_TONORMALLEAGUEHINT2";
		array[7] = text3;
		array[1] = "SquadIcons/";
		array[5] = text4;
		array[4] = "Action ";
		array[1] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual RoomOptions GEHLGCLAOHD()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual bool OKFLEONBIKG()
	{
		return false;
	}

	[SpecialName]
	public virtual int OCCPNCBMCEA()
	{
		return -106;
	}

	[SpecialName]
	public virtual bool EHALJAIIGGP()
	{
		return false;
	}

	[SpecialName]
	public virtual string CLIOOMLMMKM()
	{
		return "menu-weapon-benelli-starterpack" + Singleton<CurrentBundleVersion>.instance.BELIAKELGGL();
	}

	[SpecialName]
	public virtual bool AGFONHFJBFH()
	{
		return false;
	}

	public virtual string LCIJDJGPMAE(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.NPOEMAMPNEP(), "ID_SLOTUPGRADE_AMMO", "ID_ARENARULES_UNLIMITEDAMMO", 1324f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "claim reward failed: {0}", "ID_READYTIME", 1600f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "com/google/android/gms/games/Games", "0", 842f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, " ", "getStatus", 488f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1265f), "Font problems with labels", "SpritesWorkaround", 1797f);
		string[] array = new string[57];
		array[0] = text;
		array[0] = "VipRewardForDay";
		array[4] = text2;
		array[8] = "CAUGHT AN MISSION EXCEPTION ";
		array[4] = text3;
		array[6] = "menu-army-power-ico";
		array[0] = text4;
		array[8] = "Yes_Clicked";
		array[1] = text5;
		return string.Concat(array);
	}

	public virtual string BLEJEOFAAPP(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.KADNNBCOGGL(), "N", "BS: Update Army Power", 627f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "warbucks", "ID_SKILLSHOTHINT_HEADSHOT", 557f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "GameCenterProvider function OnAuthenticatedFailure() called => GC: Authenticated failure ", "AssignmentsIds", 635f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ID_EARLYUNLOCK2", "Items", 444f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1659f), "HP", "Data", 909f);
		string[] array = new string[56];
		array[1] = text;
		array[0] = "D2";
		array[6] = text2;
		array[0] = "Time: ";
		array[6] = text3;
		array[2] = "ID_XOFPLAYERSGETSRELEGATED";
		array[6] = text4;
		array[3] = "ServerPrice";
		array[3] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual bool HNKACCAHHLF()
	{
		return false;
	}

	[SpecialName]
	public virtual RoomOptions ELKKDAGGGPF()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	public virtual string CMPOODDMNLM(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.displayNumber, "GOT MAINTENANCE MESSAGE IN CREATE ACCOUNT", "Adding MessageId instead of empty Jtoken", 1695f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "CardTrade_Withdraw", "SoldierBehaviourBuddy SetWeaponsUpgrades: Prim: {0} Sec: {1}", 1136f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "GameLauncher.LoadMainScene", "dialog shown = {0}, lives = {1}", 1177f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "grenadeExplosion", "#account# logged to facebook result {0}", 1804f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1649f), "getCustomProfileNumber", "bd18592b-6778-40f5-9327-0aba2d2f1e64", 853f);
		string[] array = new string[-19];
		array[0] = text;
		array[1] = "ID_LOADING";
		array[4] = text2;
		array[7] = "CZ";
		array[8] = text3;
		array[6] = "ID_CONFIRM_ERROR";
		array[8] = text4;
		array[2] = "'x'0";
		array[3] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int NNNEMBIANGI()
	{
		return 11;
	}

	[SpecialName]
	public virtual int JIFBCEJIMMN()
	{
		return -109;
	}

	[SpecialName]
	public virtual bool HJNALGGKDPL()
	{
		return false;
	}

	[SpecialName]
	public virtual bool HCMJBGKCAME()
	{
		return false;
	}

	[SpecialName]
	public virtual RoomOptions HPELGDCBCPK()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual RoomOptions OHEPHDPIKPN()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = true;
		return roomOptions;
	}

	[SpecialName]
	public virtual RoomOptions KPIAFFOPCBL()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual int KHHCOPPMOCC()
	{
		return 59;
	}

	[SpecialName]
	public virtual RoomOptions OLDADHNMHOF()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	public virtual string BALMBEFOJEJ(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ELFCEEOLNFJ(), "ID_DAY_SMALL", "com.mobcrush.mobcrush", 13f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ID_SLOTUPGRADE_ROF", "ImproveAllWeaponsRPC", 751f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ID_STATE_SELECTINGWARCARDS", "EventAssignmentCompletedMessage", 966f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ID_NOTIFICATION_SILVERCRAFT", "response contain VipReward", 202f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1207f), "FuseboxxConfigValue", "\t\"TRUE\"", 1090f);
		string[] array = new string[3];
		array[0] = text;
		array[1] = "Weapon";
		array[3] = text2;
		array[5] = "VipRewardForDay";
		array[7] = text3;
		array[1] = " ";
		array[4] = text4;
		array[8] = "ID_LEAGUEDEMOTEHINT1";
		array[4] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual RoomOptions CGBGKPHFDNB()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	public virtual string FHBNJPFNODK(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.displayNumber, "YES", "Some error occurred. Please, try again later.", 1487f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ID_NOTIFICATION_WITHDRAWAVAILABLE", "CLIENT", 60f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ID_BUYSTARTERPACK", ",", 826f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "playerInfo", "ID_SLOTUPGRADE_DAMAGE", 1166f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1866f), "ID_VALUEPACKCONTENTS", "ID_TUTORIAL_SWIPE_UP2", 533f);
		string[] array = new string[-64];
		array[1] = text;
		array[1] = "Null photon view in PhotonLevelIDChanger";
		array[5] = text2;
		array[8] = "ID_FEATURE_CRITICAL-FANCY";
		array[0] = text3;
		array[8] = "PlayWindowCount";
		array[6] = text4;
		array[0] = "ID_SILVERLOOTBOX";
		array[7] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int JLMCANFNNLD()
	{
		return 13;
	}

	public virtual string FFMDGJCFIDA(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ELFCEEOLNFJ(), "veteranpack", "ID_ARENARULES_MORECRATES", 212f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ChillingoSdkManager", "ID_TUTORIAL_GO_TO_ARMORY_3_DOWN", 1210f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "Buy_Weapon_Upgrade", "AccountType", 1094f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "menu-squadpoint-ico-bw", "워프렌즈를 실행하려면 약 190MB의 추가 데이터를 다운로드 받아야 합니다.\n다운로드 시간은 네트워크 및 지역에 따라 달라질 수 있습니다.\n\n계속 진행하시겠습니까?", 1417f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1196f), "VipRewardForDay", "ID_WARNING_CANTSENDINVITE_TEXT", 149f);
		string[] array = new string[30];
		array[1] = text;
		array[0] = "ID_SALEPERCENTLINE";
		array[1] = text2;
		array[8] = "{0}{1}";
		array[0] = text3;
		array[8] = "Beanstalk: Get Player ";
		array[5] = text4;
		array[6] = "null";
		array[4] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string JOKKPLLIDKO()
	{
		return "ID_LEAGUESTAYHINT1" + Singleton<CurrentBundleVersion>.instance.AMEIIGFAPLC();
	}

	[SpecialName]
	public virtual bool AAEEIJIBEOK()
	{
		return false;
	}

	[SpecialName]
	public virtual string AAIPLPBHHAK()
	{
		return "<" + Singleton<CurrentBundleVersion>.instance.BKLELJFDPEE();
	}

	[SpecialName]
	public virtual RoomOptions DCHDNKLNCKB()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual RoomOptions JNNHJLANGEG()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = true;
		return roomOptions;
	}

	[SpecialName]
	public virtual int AFAKPOEPCJM()
	{
		return 108;
	}

	[SpecialName]
	public virtual int KNJOCEIAHKA()
	{
		return -49;
	}

	[SpecialName]
	public virtual RoomOptions FFDIGMCAOKF()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual int HOGLODLDEKE()
	{
		return 46;
	}

	[SpecialName]
	public virtual int AEHKABBGAPG()
	{
		return -51;
	}

	[SpecialName]
	public virtual int APAPNLFFDIN()
	{
		return 4;
	}

	[SpecialName]
	public virtual int DBIEEBNGOGK()
	{
		return 19;
	}

	[SpecialName]
	public virtual int PBMPCBJJCLH()
	{
		return -114;
	}

	[SpecialName]
	public virtual int BNDNDPBLGHO()
	{
		return -119;
	}

	public virtual string PDELCEODPPG(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ELFCEEOLNFJ(), "disconnect", "[.,]*", 534f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "null powerband for: ", "ID_STATE_DISCONNECTED", 967f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "RETRYPERM", "ID_FIGHT", 926f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "Buy_Player_Customizations_Gold", "{0} {1}", 49f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 736f), ", ", "VipCardMessage {0}", 1782f);
		string[] array = new string[40];
		array[0] = text;
		array[1] = "GooglePlay";
		array[0] = text2;
		array[1] = "try add null pack";
		array[1] = text3;
		array[3] = "game-card-ico-disarmed";
		array[1] = text4;
		array[0] = "SERVICE_DISABLED";
		array[8] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string GMOININAGEP()
	{
		return "WarFriends doit télécharger environ 190 Mo de données supplémentaires pour fonctionner.\nLa durée du téléchargement peut varier selon votre réseau et votre emplacement.\n\nVoulez-vous continuer ?" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
	}

	[SpecialName]
	public virtual string MPBCCLECPCI()
	{
		return "no player Id found" + Singleton<CurrentBundleVersion>.instance.BKLELJFDPEE();
	}

	[SpecialName]
	public virtual int AHOGNBJBHAK()
	{
		return 28;
	}

	[SpecialName]
	public virtual int IBJHAPJHFEE()
	{
		return -106;
	}

	[SpecialName]
	public virtual RoomOptions FCKNAAHGJMO()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = true;
		return roomOptions;
	}

	[SpecialName]
	public virtual bool HEBFIGDBMCP()
	{
		return false;
	}

	[SpecialName]
	public virtual string HKKKNGPFBEC()
	{
		return "Id" + Singleton<CurrentBundleVersion>.instance.AMEIIGFAPLC();
	}

	[SpecialName]
	public virtual string CMNFEGJDGBE()
	{
		return "1" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
	}

	[SpecialName]
	public virtual bool ICAFDPKALOM()
	{
		return true;
	}

	public virtual string FCLEMJBGJEJ(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.displayNumber, "ShootFromCrawl", "squadPoints", 285f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ID_CONFIRM_STARTUPERROR", ")", 1249f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "TuneListener onFirstPlaylistDownloaded", "shotSniper", 106f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "menu-army-upgradebar-gray", "Different league \"{0}\" and \"{1}\"\n", 1110f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1848f), "\t\"TRUE\"", "RestoredPacks", 1688f);
		string[] array = new string[64];
		array[1] = text;
		array[1] = "veteranpack";
		array[7] = text2;
		array[6] = "1";
		array[2] = text3;
		array[6] = "Beanstalk: Get Player ";
		array[8] = text4;
		array[2] = "#AccoutCheck# FacebookLoginDuringTutorial - ALL OK - loged to FB connectet to this account";
		array[7] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string DPBJOHMNJEG()
	{
		return "IsLocal" + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
	}

	[SpecialName]
	public virtual RoomOptions DIOJDKLHJKK()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = true;
		return roomOptions;
	}

	[SpecialName]
	public virtual RoomOptions BGGBMGLNLAA()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	public virtual string GNACPGPJNMO(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.NPOEMAMPNEP(), "SquadIcons/", "ID_CONFIRM_EXITINGMATCH", 550f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "S", "count", 159f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "Particle with name: ", "SetShieldPositionRPC", 1339f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "PlacementMatchesRequired", "UsedCards", 717f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 277f), "ID_OPENLOOTBOX", "ID_SLOTUPGRADE_AMMO", 1470f);
		string[] array = new string[-83];
		array[1] = text;
		array[0] = "ID_CONFIRM_PROMOTETOLEADER";
		array[3] = text2;
		array[5] = "ID_RENTAL_LMG";
		array[5] = text3;
		array[0] = "{0}{1}";
		array[8] = text4;
		array[4] = "Total_Battles";
		array[5] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual bool AJOOABLHCKI()
	{
		return false;
	}

	[SpecialName]
	public virtual int HMPANGODOAF()
	{
		return -39;
	}

	[SpecialName]
	public virtual string PIPOCCPKGOI()
	{
		return "No overlay to display cards!" + Singleton<CurrentBundleVersion>.instance.BKLELJFDPEE();
	}

	public virtual string IAIIKICJJLL(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ABCCINJGPGD(), "Reported", "#Mission Rewards# Game Rewards:\n", 1250f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "Hide reconnect dialog", "Buy_", 1945f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "On Level Squad Up", "WasShown", 1693f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ID_SALEPERCENT", "fr", 1688f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1016f), "RegisterParentalConsent()", "ID_WARNING_CANTSENDINVITE", 817f);
		string[] array = new string[-23];
		array[1] = text;
		array[1] = "ID_REFILLED";
		array[6] = text2;
		array[1] = "ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE";
		array[4] = text3;
		array[3] = "com/google/android/gms/common/ConnectionResult";
		array[3] = text4;
		array[6] = "FuseSDK instance not initialized. Awake may not have been called.";
		array[8] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string PNPJOLPIGAJ()
	{
		return "()I" + Singleton<CurrentBundleVersion>.instance.AMEIIGFAPLC();
	}

	public virtual string FLPJMOPDEPL(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.NPOEMAMPNEP(), "Purchase_Attempt", "ID_INSTANTBATTLEUNLOCKED", 1802f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "S", "ID_TURRETBUILDTIME", 191f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, ")", "ID_WARNING_SERVERDATA", 574f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ID_SALEPERCENT", "ID_WARNING_NOTENOUGHTLEVEL", 220f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1167f), "ID_CLOSE", "vveteranpack", 166f);
		string[] array = new string[-27];
		array[1] = text;
		array[0] = "ID_INBRONZE2";
		array[3] = text2;
		array[3] = "java.util.HashMap";
		array[2] = text3;
		array[4] = "ID_GUI_EQUIP";
		array[2] = text4;
		array[6] = "Shotgunner spawned";
		array[8] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string FPCNAGOGCHN()
	{
		return "CONFIRMAR" + Singleton<CurrentBundleVersion>.instance.PPNKHOBNDCI();
	}

	[SpecialName]
	public virtual int KPKDMNPANAF()
	{
		return -111;
	}

	[SpecialName]
	public virtual bool KLGNIKHAAEN()
	{
		return true;
	}

	public virtual string OMDEKCMGONF(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ELFCEEOLNFJ(), "game-label-you-blue", "Scene could not be find", 800f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ID_SALEPERCENTLINE", "VipReward2", 357f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "Release cards : ", "Added", 1275f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "Player_Waited_Till_Delivery_Ends", "menu-assignments-type-destroy", 755f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 161f), "./warfriends", "ID_SELECTTWOUNITS", 1807f);
		string[] array = new string[125];
		array[0] = text;
		array[0] = "getChurnProbability";
		array[0] = text2;
		array[2] = "ArmyPower";
		array[2] = text3;
		array[3] = "Enemy could not be spawned";
		array[0] = text4;
		array[4] = "menu-assignments-type-score";
		array[8] = text5;
		return string.Concat(array);
	}

	public override string EKJACHPMFOM(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.displayNumber, "C0", "Rank");
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "C1", "League");
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "C2", "Medals");
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "C3", "ArmyPower");
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 100f), "C5", "winLooseStreak", 100f);
		return text + " AND " + text2 + " AND " + text3 + " AND " + text4 + " AND " + text5;
	}

	public virtual string MDNOIFOJHBK(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.PFMGLDJDNBF(), "BoobyTrapSetRPC", "IN", 1073f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "SetAngle", "./Assets/Scripts", 1656f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "Video ad reward - lootbox visuals List =  ", "Weapon delivery now is : ", 1438f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ID_CONFIRM_TEMPORARBAN", "grenadelauncher_idle", 337f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1268f), "shield_shot", "GoldCoefficient", 1176f);
		string[] array = new string[62];
		array[1] = text;
		array[0] = "veteranpack";
		array[5] = text2;
		array[0] = "game-card-ico-paralyzethese";
		array[8] = text3;
		array[1] = "\"{0}\"\t";
		array[0] = text4;
		array[3] = "LevelExperience";
		array[3] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string KIOCEFPJMDF()
	{
		return "ItemRarity_2" + Singleton<CurrentBundleVersion>.instance.OIFKMEKIAPM();
	}

	[SpecialName]
	public virtual int BAJKMCKDHFC()
	{
		return -40;
	}

	[SpecialName]
	public virtual int CAMEJAPKOAI()
	{
		return 63;
	}

	public virtual string HCIILLNKINA(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.KADNNBCOGGL(), "Player", "RewardedInfo", 971f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ItemsOwned_Rarity_1", "Scraps", 5f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ID_GETFREEGOLD", "ID_GOLDPACK", 1432f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "AMMOBOX", "KR", 1524f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1039f), ", action = check connection", "ID_ATTACK", 1426f);
		string[] array = new string[-118];
		array[1] = text;
		array[0] = "xmas";
		array[2] = text2;
		array[0] = "GLM: RegisterOrLogin - NOT GameCenterProvider.instance.hasResponse!!!, use saved!";
		array[0] = text3;
		array[2] = "()I";
		array[3] = text4;
		array[7] = "ID_MISSION_SURVIVE_HUD";
		array[6] = text5;
		return string.Concat(array);
	}

	public virtual string PKBCGKLLFKH(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.NPOEMAMPNEP(), "S", "hide", 1167f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "1", "testingidevententered", 526f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ID_LOGOUT", "ID_GUI_REPORTABUSE_LISTITEM8", 1546f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "1080799636982", "unitDelivery", 279f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1551f), "L", " {0}{1}", 1651f);
		string[] array = new string[89];
		array[0] = text;
		array[1] = "ID_SALEPERCENTLINE";
		array[1] = text2;
		array[4] = "withAttribute5";
		array[1] = text3;
		array[3] = "BeforeLeagueId";
		array[3] = text4;
		array[2] = "menu-sidetab-servermaintenance-ico";
		array[1] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int NDHIOHNGBOO()
	{
		return 33;
	}

	[SpecialName]
	public virtual RoomOptions HLPHNONHNAK()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual RoomOptions EEMOHNMPBFE()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	public virtual string BMPPBLGMFFI(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.JICMGFNAHFL(), "ID_CURRENTSQUADRANK", "ID_STAT_ALLTIMERUNS", 1491f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "\n", "FinishGameMultiplayerRPC", 185f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "Manual_Unit_Spawn", "data.slots doesnt contain: ", 934f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "dbKey", "N", 615f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 459f), "#VAVRO# SETTING BOT DIFICULTY TO WEAK", ", result = ", 713f);
		string[] array = new string[94];
		array[1] = text;
		array[0] = "ID_DIVISION";
		array[5] = text2;
		array[2] = "ID_CONTAINSXWARCARDS";
		array[3] = text3;
		array[2] = "Attempt";
		array[0] = text4;
		array[6] = "ID_CONFIRMTRAILSUBSRIPTIONANDROIDTEXT";
		array[1] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int AEGNKKDCPAA()
	{
		return -94;
	}

	[SpecialName]
	public virtual RoomOptions JHMPJLLCAJE()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	[SpecialName]
	public virtual RoomOptions LBPGIOEBKHA()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	public virtual string MAIJJFKAJNL(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.PFMGLDJDNBF(), "SEND PLAYER REPORT ERROR - NO PLAYER ID", "GuaranteedScraps", 806f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "ID_SECONDS", "1", 1637f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ID_SQUADMEDALS", "Enemies Freezed", 1319f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ServerResponseHandler.GetConfigurations DONE", "Card_2_Played", 475f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1536f), "0", "elite", 435f);
		string[] array = new string[-87];
		array[1] = text;
		array[0] = "ID_CONFIRM_ERROR";
		array[8] = text2;
		array[6] = "These IDs have the same translations:\n";
		array[5] = text3;
		array[3] = "{0}%";
		array[2] = text4;
		array[6] = "special";
		array[0] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int KDBDHEOBKGA()
	{
		return 43;
	}

	[SpecialName]
	public virtual RoomOptions NECGKBFBFCD()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = false;
		return roomOptions;
	}

	public virtual string LIPNGPEKJKF(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.KADNNBCOGGL(), "Start '{0}'", "BAND_TYPE_RELOAD", 192f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, ", action = ", "ID_CONFIRM_SQUADFULL", 1542f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "{0} / [FECA21]{1}[-]", "null", 115f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "instantBattleAvailable", "dataEnabled", 603f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 505f), "CONFIRMAR", "ID_STAT_MOSTWINS", 1584f);
		string[] array = new string[-128];
		array[0] = text;
		array[0] = "Play_Card_Tutorial_Duration";
		array[3] = text2;
		array[4] = "S";
		array[8] = text3;
		array[5] = "NO";
		array[7] = text4;
		array[1] = "105 STAGE 1 COVER 2";
		array[2] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string DEFLCBKEEDD()
	{
		return "ID_ZEROSECONDS" + Singleton<CurrentBundleVersion>.instance.AMEIIGFAPLC();
	}

	[SpecialName]
	public virtual int KECDHLNIDBF()
	{
		return -61;
	}

	public virtual string CDBKBKLNFKM(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.PFMGLDJDNBF(), "Google2u.SniperRifle_M24", "special", 1481f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "SquadIcons/", "다운로드", 1074f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "com/google/android/gms/common/ConnectionResult", "menu-hub-multiplayer-vipico", 1856f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "Token", "VGOfferInfo", 167f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 868f), "ID_OVERTIMEKILL", "CardId", 211f);
		string[] array = new string[-31];
		array[0] = text;
		array[0] = "\\D*";
		array[0] = text2;
		array[1] = "{0}{1}\n{2}{3}";
		array[1] = text3;
		array[5] = "{0} {1}{2}";
		array[7] = text4;
		array[2] = " and mScheduleSessionUpdate is ";
		array[1] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string PKCHAHKAIIE()
	{
		return "DogTagCap" + Singleton<CurrentBundleVersion>.instance.BELIAKELGGL();
	}

	[SpecialName]
	public virtual string APJMLGJOENM()
	{
		return "Cards choosen " + Singleton<CurrentBundleVersion>.instance.matchMakingVersionRanked;
	}

	public virtual string NAKIDIJGEEN(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.NPOEMAMPNEP(), "resizing texture ", "doubleValue", 748f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "Level", "ID_ARENARULES_NORMALIZATION", 80f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "Army_Unit_ID", "OtherPlayerId", 673f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "Landroid/os/Parcelable$Creator;", "ID_STAT_KILLS", 529f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 637f), "0", "{0} Squad Total Stat", 289f);
		string[] array = new string[-40];
		array[0] = text;
		array[1] = "Device PAUSED at {0} RealTime: {1}, Doing CG.Collect() = {2}";
		array[4] = text2;
		array[2] = "AFTER CreateFromDatabase";
		array[1] = text3;
		array[3] = "ID_CONFIRM_ERROR";
		array[2] = text4;
		array[5] = "Count";
		array[2] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual string KILHAINNCKG()
	{
		return "GrenadeExplodeDamage" + Singleton<CurrentBundleVersion>.instance.BKLELJFDPEE();
	}

	[SpecialName]
	public virtual bool ABEAGAMLFHD()
	{
		return true;
	}

	public virtual string KMELOLMHJOB(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.PFMGLDJDNBF(), "Medals/", "ID_UPGRADE", 1061f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "call check CG autentication", "ShotFrequencyMin", 1743f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "com/google/android/gms/games/Games", "damage", 332f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "'friend'0", "Scripts", 1115f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1734f), "Increasing texture count in player texture pool!", "Google2u.", 636f);
		string[] array = new string[1];
		array[0] = text;
		array[0] = "IsUnique";
		array[2] = text2;
		array[4] = "DogTagCap";
		array[6] = text3;
		array[3] = "S";
		array[6] = text4;
		array[0] = "country-danmark";
		array[4] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int JJCFODKLNGD()
	{
		return 70;
	}

	public virtual string CGOAIDCLFIN(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ABCCINJGPGD(), "nonEliteUnits", "MachineGunner", 1019f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "PowerBandId", "PartsGainedLootbox", 1614f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ID_WARNING_CANNOTCREATESQUAD_TEXT", "ID_SILVERPACK", 1961f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "InAppHandlerIos: purchase product, productId = ", "withPublisherSub5", 51f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1603f), "Saved_data.csv", "UnitReadyForPromotion {0} {1}", 1367f);
		string[] array = new string[113];
		array[1] = text;
		array[1] = "#Game Rewards# - Squad Points: {0} (after offer mult x{1} on server)";
		array[5] = text2;
		array[5] = "Application focus changed to {0} and have created AWS mobile analytics {1}";
		array[7] = text3;
		array[5] = "Manual_Unit_Spawn";
		array[4] = text4;
		array[5] = "Amount";
		array[3] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual int CPMHBBMKIEE()
	{
		return 0;
	}

	[SpecialName]
	public virtual int JOPHDGCCPKM()
	{
		return -90;
	}

	public virtual string HMFKCMJDPDO(int DKHDNINDEKD)
	{
		string text = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.currentLevel.ABCCINJGPGD(), "ID_NEXTLOOTBOXINPVPBATTLES", "Automatic_Equip", 1680f);
		string text2 = OHDNLGHFNAH(DKHDNINDEKD, (int)GameLoginManager.currentPlayer.leagueTier, "Level", "ID_LOOTBOXES", 809f);
		string text3 = OHDNLGHFNAH(DKHDNINDEKD, GameLoginManager.currentPlayer.medalsBalance, "ArenaLives", "\t\"TRUE\"", 1286f);
		string text4 = OHDNLGHFNAH(DKHDNINDEKD, LevelManager.instance.bestArmyPower, "ID_CONFIRM_ERROR", "setExistingUser", 693f);
		string text5 = OHDNLGHFNAH(DKHDNINDEKD, (int)(StatsManager.instance.data.deathMatchWinLooseStreak * 1435f), "ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT", "ID_PACKXGOLD", 736f);
		string[] array = new string[0];
		array[0] = text;
		array[0] = "Action ";
		array[5] = text2;
		array[8] = "Mouse Y";
		array[8] = text3;
		array[0] = "menu-gold";
		array[8] = text4;
		array[2] = "ID_FEATURE_AMMO-FANCY";
		array[1] = text5;
		return string.Concat(array);
	}

	[SpecialName]
	public virtual RoomOptions PEJOCCPOHCG()
	{
		RoomOptions roomOptions = base.NCDDLBIJIIH;
		roomOptions.IsVisible = true;
		return roomOptions;
	}
}
