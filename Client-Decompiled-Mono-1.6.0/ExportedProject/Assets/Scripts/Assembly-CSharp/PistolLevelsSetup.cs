using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class PistolLevelsSetup : WeaponLevelsSetup
{
	public override float shotDamage
	{
		get
		{
			return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "damage")) * base.weaponFeature.damageCoef;
		}
	}

	public virtual List<Tuple<string, float[]>> NINIIBGAJCN(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "リトライ", "ID_CONFIRM_RESTORE", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_SILVERWARCARDS", "GLM: RegisterOrLogin - 6.5: no GC response, use stored values", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_READYTIME", "response for {0}", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LJJNPDJCCJD(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "v", "Level", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_ELITEPACK_WEAPONDESCRIPTION", "Fuseboxx Config Value = ", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Master", "ID_DAILYMISSIONSUNLOCKED", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float OKJHCNICJGK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.BDNCLOPCDLO(), "ID_MISSIONANIMATION_WAVESTARTED")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float FKBOCDNDFIH()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "The shader ")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float BKMHMMPBLBL()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "CannonDamage")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float DDINKMGDNLF()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: ")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float DHHBENFGFBM()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), "kr")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> CFMBLKBEOOC(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Total_Battles", "ID_CONFIRM_ERROR", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "RATE APP - counter set to max: ", "Card_1_Played", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Localization", " bonusIcon:", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> NFAGENJDCCJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "123456789123456", "()Lcom/google/android/gms/games/stats/PlayerStats;", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = ", "ID_SAVEPERCENTLINE", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_YOUNEEDMONEYTOUPGRADEELITE", "Action ", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float LDFPGMNFCDM()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.BDNCLOPCDLO(), "ID_UNITPOWERFULLYUPGRADED")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float GHNOOEOLIND()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "S")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float PAMPCBDIJAL()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "Assignment: Error, task definition not found for id = ")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> GFJDKGGCDFK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Gold", "ID_CONFIRM_GAMELAREADYENDED", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ShotFrequencyMax", "ID_SLOTUPGRADE_ROF", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "DisableOnStart", "Bullet with NO weapon", base.weaponFeature.reloadCoef));
		return list;
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "attack", "ID_SLOTUPGRADE_DAMAGE", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "clipSize", "ID_SLOTUPGRADE_CLIP_SIZE", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "reloadTime", "ID_SLOTUPGRADE_ROF", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> EKBIICIJIBG(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " BundleID: ", "ID_GUI_REPORTABUSE_LISTITEM4", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "LikeUsOnFacebook", "PlayerRank", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CONFIRM_SQUADEVENT_TEXT", "{0}-{1}", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float KKOBLKDEECP()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), "ID_CATEGORY_LOW_SG_SHOTGUN")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> LGGEIGLAAFC(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Google2u.DBUpgradeSlotsShotgunner", "DPS", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Omitting object: ", "N", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "LoadingFinishedRPC", "PlayerName", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LEGEPDLIOLJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "[", " on object ", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_PURCHASED", "Sessions", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CONFIRM_CONNECTTOGOOGLENAMETEXT", "Deadline", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float FOMDMILEFFK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "TuneListener trackerDidSucceed: ")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float OJHDGNNDDMD()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.PNKECEJELDP(), "ES")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float ICHKLEAGGCJ()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "out of range")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> EMIPCHOMJGF(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "BS: Player report sent!", "402 MENU BATTLE SCREEN SHOWN", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Dictionary filled and contains {0} ids", "Spend_Warbucks_On_Army", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "special", "ID_GETFORREWARD2", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float DEBOLDFPEAK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.GCBOONOBIKH(), "Customization {0} is purchasable through {1}")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> PKKGGPLAHFA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_MEMBERSHIP_HINT3", "LevelExperience", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "com/google/android/gms/games/Games", "ID_GOLD", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "FeaturedVideos", "ID_GC_LOGIN_TUTORIAL_TEXT", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> NEFDDDLHBON(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_GETFORNUMBERONE2", "ID_STARTERASSIGNMENTSEXPIRED", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "KickedPlayerId", "[^\\d]", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "com/google/android/gms/common/ConnectionResult", "lastWeeksPlayerLeague", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> BPDIHMEADHA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, ")", "BeginnersLeague", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_GUI_EQUIPPED", "Spend_Warbucks_On_Weapons", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "C2", "WRONG NUMBER OF ORDER ", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float EHABCANDMKB()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "ID_WAITVIDEO1")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float NAHNFMIIMEB()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "WarFriends cannot function without downloading these additional data. Do you really wish to QUIT or would you like to download the data?")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float OFKPOGLAILL()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "ShootCopyRPC")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> HDPMJGABCHI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Average_Transaction_Amount", "AccountType", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "UA", "ID_ERRORPROFANITYNICK", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} {1}", "\n", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> CFPIJLPBPIJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Player visual Error: id not find: ", "Swipe Raycasts End FAILED!", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Assignment: DestroyEnemyCratesAssignment Constructor", "PlayerName", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Pack: Gold Cards ", "ID_WAITINGFORFRIENDCARDS", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float BMMHMODMHKD()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "placement")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float HLMFMGBKNAP()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "ID_REMINDER_WARCARDSLOTSNOTENOUGH")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> KIIGIADKCMA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "getAverageSessionLength", "menu-assignments-type-deploy", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Can not find boss", "NetworkReInstantiate", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_GUI_DRAGCARDHERE", "menu-army-reload-ico", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> HJLJNNFOPPA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "WENEEDTO", "Action ", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "NO", "RegisterBirthday()", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Google2u.AssaultRifle_AK47", "ELECTRICTRAPS", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float NLGHAFEEHEK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.BDNCLOPCDLO(), "ID_NOTIFICATION_DOGTAGFULL")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> AEKNPKIPLOE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CONFIRM_CONNECTTOGOOGLENAMETEXT", "player name", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "bot", "Quit called when Game is loading or running", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "05", "bad number of weapons for bot: ", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> CHMOIAIJNAB(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "DailyMissionsCompletionRewardCards", "ID_ISALREADYMEMBEROFANOTHERSQUAD", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_STARTERASSIGNMENT5", "U", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CONFIRM_EXITINGMATCH", "Still waiting for server\nBe patient :-)", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float LABCAKNDEDK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.GCBOONOBIKH(), "IsRestore")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> EAKMBEHIJAK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " OK!", "DOWNLOAD", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_MINUTES", "ID_READYTIME", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_PLAYERLEAGUEENDSIN", "squadCreationsCnt", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> BEJDOICGOGK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Yes_Clicked", "Clearing Waitlist cache...", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_WARNING_CANTSENDINVITE_TEXT", "getCustomProfileString", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "FuseBox Event Level Up for level {0}", "check offer", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float AMLDFEJOIEK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), "| time: ")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> JJLFBAFICEA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "PurchaseToken", "Claiming reward ", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "com/google/android/gms/common/ConnectionResult", "Cards_Chosen", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_RANDOMMAP", "ID_GUI_EQUIPPED", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> GJDEKOGJHPK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Cancel - Disconnect, clicked in dialog !!!", "Number", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_GUI_CHAT_BANNED_DESCBOX_PERMANENT", "Start broadcasting", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CONFIRM_NOSQUADACTIONS_TEXT", "acountDataDownloadingInProgress = False", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> JKFJCGGJJKC(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "#PETER# Removing squad promote message - message time:{0}, server time:{1}, isInSquad:{2}", "Checking success string: ", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Country", "REWARDGOLD", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "kr", "Arena Lives: ", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LDJABDNIABK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_SECONDWEAPONDAMAGE", "Bad player statistics, data= ", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "menu-weaponstats-criticalchance", "ID_CONFIRM_SERVERCOULDNOTCOMPLETED", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} {1}{2}", "ERROR CLAIM STARTER ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED ", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> CIFEHNGJMKH(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_NA", "ObtainedCards", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Level", "ID_GETFORNUMBERONE1", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Unknown Tutorial Stage", "111-222-3333", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> OFOLMDAFELD(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "OnApplicationResumed", "lapsed_player_2", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "primary", "LeagueId", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Not sending error to database!!", "Automatic_Equip", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LBKODPFFOPC(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "WarbucksAdded", "ID_HOURS", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "discount", "ID_TUTORIAL_KILLING_SCOPE_DOWN", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0}\t\t{1}\t\tint number: {2}\t\tfloat number: {3}\n", "added", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float MBDCGKFCFGF()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "{0} {1} {2}lvl {3}")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> EELEAGABDAI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ActivateBonusResultRPC", "GO TO OFFER", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Local", "1", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_GUI_TWEETABOUT_DESC", "ID_ARENARULES_INSTANTOVERTIME", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float FFHLPGHCEMK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "SpecialOfferSuffix")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float CLGKDKNIEFK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "ID_GUI_EQUIPPED")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> PNLFFLHJOEG(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "shootAdditive", "ID_RANK", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " Standard", "ID_JOINSQUADDESCRIPTION3", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "damage", "Server error during ", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> AMNMPIFGIDO(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ios", "battleID", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "About to show Name Change Reminder", "PlayerName", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "target_id", "idle", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float POKJNICKHEK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "ID_ULTIMATEHEROICREWARDS")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> AICDAPKDMHM(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ArmyPower", "VipReward1", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Rank", "Challenge Counter expired!", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "subscriber_since", "Squad Member record does not have DatabasePlayer", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> FANDDNKJKFI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "URL", "ID_ENGLISH", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "NewVisuals", " found!", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Shots_Fired", "ID_CONFIRM_ERROR", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LJKGEOMLMFM(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Weapon upgrade for ", "Amount", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "game-card-ico-bulletsponge-full", "menu-button-promote-ico", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Dictionary created/cleared.\n", "You probably assigned bad type of AmmoSetup to gun", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> JIFPIHMLAGA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Language", "N", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "PNManager: Local Notification extraData='{0}'", "^[0-9]*-", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "On Debug Add Scraps Request: ", "null", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> OHLBGACPKIB(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " succesfully joined squad ", "/AssetBundles/", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "no AI object for: ", "ID_CONFIRM_FORFEITARENA", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} {1}/{2} {3}", "Wrong_Category", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> EIIPDLCPJCB(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "AddedCards", "OK", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Total_Assignment_Completed", "ID_CLOSESIN", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_READYTIME", "AtlasPreparer.LoadTutorialCoroutine", base.weaponFeature.reloadCoef));
		return list;
	}

	[SpecialName]
	public virtual float PAEEHODJAJN()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OFEJOLENCKI(), "GLM: RegisterOrLogin -  playerAccount == NULL")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float LGJPABGMKHD()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "r")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float CANKBLAAFFB()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.KMHMJEDDNOP(), "RowIDs")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> OLCNBGPPDBI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_UPGRADE", " {0} - {1} in {2}\n", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERED\t\tbutton type: ACTIVATE", "Buy_Lootboxes", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "getConnectionResult", "ID_CONFIRM_NOSUCHPACK", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float OAJFGOCNEPI()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "ID_BLACKMARKETLEFTTEXT2")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float FALCHAOCEOH()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OFEJOLENCKI(), "N")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> LMMDHPHJJHN(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "WarCards", "withAttribute5", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "SoldierBehaviourBuddy ChangeEquippedWeapons: Prim: {0} Sec: {1}", "ID_SQUADSIZEINCREASEATSQUADRANK", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "AssignmentIndex", "#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> JNKDKFOGDLJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} {1}", "PromotedPlayer", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Wrong_Weapon", "\"", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "lastWeeksPlayerLeague", "ID_MEMBERSHIP_HINT5TRIAL", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> PHJBAFMFGPO(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "DogTagLastUpdate", "ID_CONFIRM_SERVERDIDNTRESPONDAFTER", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "IS SLOW DEVICE?? ", "はい", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "BeforeLeagueId", "PreRollMessage", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> AFDMPBIMOKH(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Click on the ground to spawn the selected effect", "Play_Card_Tutorial", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "RewardMessage", "ID_SEARCHRESULTSFOR", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " ", "ID_UNITMAXUPGRADED", base.weaponFeature.reloadCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> NJFKIKMLIJO(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "About to show GC Change Name Dialog", "leagueMembers", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Gold Spent ", "ApplyVisuals Error, indices are null!", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "NewPlayerMemberId", "registerCustomProfileString", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> FJAFBAPOPEE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_UNITHASBEENPROMOTEDTOTIER", "1.0", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "doesnt exist", "RewardMessage", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "WALLET - spent GOLD {0}", "VisualType", base.weaponFeature.reloadCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> FJDHNIELKEN(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "LootboxType", "HeroicMissionsCompletionRewardScraps", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, ")", "Ranks/", base.weaponFeature.clipSizeCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "/AssetBundles/", "ID_DEMOTEDTODIVISION", base.weaponFeature.reloadCoef, true));
		return list;
	}

	[SpecialName]
	public virtual float GPCOPECHEJK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "menu-cards-bronzepack")) * base.weaponFeature.damageCoef;
	}
}
