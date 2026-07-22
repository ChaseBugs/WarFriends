using System.Collections.Generic;
using UnityEngine;

public class MHEHGPLIFHF
{
	public static void DFDHBIGFJFO(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SetLabelDynamic - Done", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("equals" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-127), aBMLHILNNDM);
	}

	public static void FBGJBBHFENO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-23):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Squad"], string.Empty);
			object[] array3 = new object[0];
			array3[1] = text5;
			Debug.LogFormat("Wrong_Category", array3);
			WarningDialog.ShowError(Localization.Localize("{0} / [FECA21]{1}"), Localization.Localize("deviceName"), 1017f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)188:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_GUI_CHAT_BANNED_DESCBOX_TEMP"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["HeroicMissionsCompletionRewardCardPack"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG[","], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Country"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[7];
			array2[1] = text;
			array2[1] = text2;
			array2[5] = text3;
			array2[8] = text4;
			Debug.LogFormat("Render player texture ERROR: Weapon load failed! (timeouted - 5 sec)", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize("SoldierHP"), Localization.Localize("Request Finished with Error! "), 1100f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)(-21):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "\"NEGINFINITY\"");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["\"NaN\""], 1);
			object[] array = new object[0];
			array[0] = num;
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("BeginnersLeague", array), Localization.Localize("libraryVersion"), 958f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void CJNAAOJMHOM(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("Tier"), Localization.Localize("FB_Like"), 1222f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["0"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Items" + text);
	}

	public static void LKDOGOHHBMB(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("S"), Localization.Localize("EventDefinition"), 688f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["In squad data from server is no squad wars position and there is no squad war processing."], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Error - sheet {0} doesnt have column {1}" + text);
	}

	public static void DAJCCCBFDFG(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)126:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["PrepareBotForDeathMatch 8"], string.Empty);
			object[] array3 = new object[1];
			array3[1] = text5;
			Debug.LogFormat("PowerBandExpiresOn", array3);
			WarningDialog.ShowError(Localization.Localize("Game_Type"), Localization.Localize("ID_SKILLSHOTHINT_ENEMYPLAYERHIT"), 1828f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-157):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_GUI_ACCEPT_PLAYER_CANTJOIN"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["{0}{1}"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["워프렌즈가 중요한 게임 데이터를 다운로드 받으려면 미디어 저장소에 대한 접근 권한이 필요합니다. 이 권한이 없으면, 게임이 정상적으로 작동되지 않고 종료됩니다. 다시 시도하거나 워프렌즈를 종료해주세요."], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["WarCards"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[7];
			array2[0] = text;
			array2[0] = text2;
			array2[8] = text3;
			array2[1] = text4;
			Debug.LogFormat("com.tune.TuneGender", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Session_start"), Localization.Localize("]"), 520f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)123:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "stickers");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Automatic_Equip"]);
			object[] array = new object[0];
			array[0] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("game-card-ico-bulletsponge-full", array), Localization.Localize("StartTime"), 1032f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void GOFFAOPEGAP(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)26:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}"], string.Empty);
			Debug.LogFormat("ID_SALEPERCENTLINE", text5);
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_INVITEDYOUTOCOOP"), Localization.Localize("ID_CONFIRM_SUBSCRIPTION_TEXT"), 316f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)150:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Problem for max! in army/weapon stats"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_LEAGUETOPPOSITIONHINT"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["expiresOn"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_ARENAREWARDEXPIRATION"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array = new object[4];
			array[1] = text;
			array[0] = text2;
			array[6] = text3;
			array[3] = text4;
			Debug.LogFormat("ID_CONFIRM_OFFERWRONGDISCOUNT", array);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ANDROID: PACK "), Localization.Localize("Beanstalk: Squad Details is cached, returning ..."), 1344f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)(-87):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "Cache: Removing ");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["GooglePlay"], 1);
			WarningDialog.ShowError(Localization.LocalizeFormat("App not installed", num), Localization.Localize(", "), 1507f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		}
	}

	public static void CGKHMPIIDAA(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("ID_SILVERARENACROWN"), Localization.Localize("canShow"), 975f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_BATTLEINARENA"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("Squad" + text);
	}

	public static void OMANPLAFBKC(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)46:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_CONFIRM_SQUADEVENT_TEXT"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("CONFIRMAR", array2);
			WarningDialog.ShowError(Localization.Localize("https://www.facebook.com/warfriendsgame/"), Localization.Localize("CONFIRM"), 1199f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)49:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Server Response:\n"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["SoldierBehaviourStartShootingNetwork"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_SKILLSHOTHINT_TANKDESTROYED"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_FEATURE_MAGAZINE-DESCRIPTION"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array = new object[1];
			array[0] = text;
			array[0] = text2;
			array[5] = text3;
			array[8] = text4;
			Debug.LogFormat("UnitCategoriesReminder", array);
			WarningDialog.ShowError(Localization.Localize("ID_JOINSQUADDESCRIPTION3"), Localization.Localize("FinishGameMultiplayerRPC"), 764f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-92):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "registerEvent");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Cant generate buddy card for weapons: {0}, {1} and type {2}"]);
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("Leaderboards - Squad Wars - is in squad:{0},\t\tsquad wars procesing:{1}", num), Localization.Localize("Icon"), 1966f, null, string.Empty);
			break;
		}
		}
	}

	public static void CDPMHEAJPCN(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Cards_Buddy_Chosen", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError(", action = " + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.LeaveSquad, aBMLHILNNDM);
	}

	public static void FMHJFAHMIFN(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("run"), Localization.Localize("{0}:\t\t{1}\n"), 1374f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_CONFIRM_SERVERDIDNTRESPONDAFTER"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("ID_HEALTH" + text);
	}

	public static void KNCMJDBHMFB(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-110):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_ARENAPROMOENDSIN"], string.Empty);
			object[] array3 = new object[0];
			array3[1] = text5;
			Debug.LogFormat("offerType", array3);
			WarningDialog.JACKIDKHKAI(Localization.Localize("NO WAR ARENA CONFIG!!!"), Localization.Localize("elite2"), 1312f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-151):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["InAppRow '"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Device PAUSED at {0} RealTime: {1}, Doing CG.Collect() = {2}"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Social_Behaviour"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["attack"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[3];
			array2[1] = text;
			array2[1] = text2;
			array2[7] = text3;
			array2[2] = text4;
			Debug.LogFormat("Lcom/google/android/gms/common/api/Scope;", array2);
			WarningDialog.ShowError(Localization.Localize("shield_idle"), Localization.Localize("Enemy could not be spawned"), 1941f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)34:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "_Color");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["SH: New message = "], 1);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat(" TOTAL UNSUED RESERVED: ", array), Localization.Localize("game-card-ico-triggerhappy"), 1391f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		}
	}

	public static void ICLJAHLDKIG(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.ShowAlert(Localization.Localize("Wrong_Weapon"), Localization.Localize("game-card-ico-healingstorm"), 150f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_PURCHASEINPROGRESS"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("goldShields" + text);
	}

	public static void IELEELNOJAC(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("SIGN_IN_REQUIRED"), Localization.Localize("menu-assignments-bar-red"), 616f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_TRAIN"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("PlayerLeaguesId" + text);
	}

	public static void MDAPPNGJDJP(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-75):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["LEAVING ARENA BATTLE"], string.Empty);
			object[] array3 = new object[1];
			array3[1] = text5;
			Debug.LogFormat("ID_BATTLECANCELED", array3);
			WarningDialog.ShowError(Localization.Localize("Loading assignment data after GAME!!"), Localization.Localize("qbz_reload"), 1931f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-21):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_BLACKMARKETLEFTTEXT3"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_LOADING"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["NETWORK_ERROR"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["LevelManagerData"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[8];
			array2[0] = text;
			array2[1] = text2;
			array2[2] = text3;
			array2[0] = text4;
			Debug.LogFormat("DogTagLastUpdate", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize("Awaiting players - Player was removed from awaiting members."), Localization.Localize("SetupPushNotifications("), 1490f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)20:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "damage");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["BOT"], 1);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("Exception message: ", array), Localization.Localize("Location"), 233f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		}
	}

	public static void GBOCNHGKEDB(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-190):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["_MatCap"], string.Empty);
			object[] array3 = new object[0];
			array3[0] = text5;
			Debug.LogFormat("Player_Level_Up", array3);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("()F"), Localization.Localize("ID_GC_LOGOUT_TEXT"), 866f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case IJEAJGCCHEF.DecalCategoryNotFound:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_MEDALSTOJOINBIG"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["AttachWeaponsRPC"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["'friend'0"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_EMPTYSQUADMESSAGE"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array2 = new object[7];
			array2[0] = text;
			array2[0] = text2;
			array2[5] = text3;
			array2[3] = text4;
			Debug.LogFormat("grenade", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_CONFIRM_NOTENOUGHDOGTAGS"), Localization.Localize("ID_READYTIME"), 1929f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)142:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "ID_AFFECTEDOWNUNITS");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_BEGINNERSLEAGUE2"]);
			object[] array = new object[0];
			array[0] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("error in creating new row in: ", array), Localization.Localize("T"), 1387f, null, string.Empty);
			break;
		}
		}
	}

	public static void NNPJHKBCJHD(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_REQUIREDMINBIG", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError(" tutorial running: " + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-112), aBMLHILNNDM);
	}

	public static void PALNJODGKCA(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("WENEEDTO", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("," + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-77), aBMLHILNNDM);
	}

	public static void PHKNCEEHBPP(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)163:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Squad Member record does not have DatabasePlayer"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("FOUND", array2);
			WarningDialog.ShowError(Localization.Localize("Bad player regiones, data= "), Localization.Localize("isVIP"), 137f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)32:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["dataEnabled"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Name"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_SALEPERCENTLINE"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ChallengedPlayerId"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array = new object[2];
			array[1] = text;
			array[0] = text2;
			array[7] = text3;
			array[2] = text4;
			Debug.LogFormat("Sniper_Tutorial_Duration", array);
			WarningDialog.JACKIDKHKAI(Localization.Localize("116 STAGE 5 CONTINUE"), Localization.Localize("Squad rank updated from server, on client = "), 508f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-2):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "IsLocal");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_INPROGRESS"], 1);
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("ID_OFFERENDSIN", num), Localization.Localize("WarFriends"), 616f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void CPPOPPGMBAF(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("elitepack2" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-63), aBMLHILNNDM);
	}

	public static void KJALILPOFDD(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("url ", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("ID_BUY" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)83, aBMLHILNNDM);
	}

	public static void MOAGCJIGGON(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ExceptionMessage"), Localization.Localize("Bot Cards does not contain id: "), 129f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ArenaBattleStart"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Player_Avoided_Grenade_On_First_Try" + text);
	}

	public static void PHNAAJIHEIG(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-157):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["menu-squad-{0}"], string.Empty);
			object[] array3 = new object[1];
			array3[1] = text5;
			Debug.LogFormat("disconnect", array3);
			WarningDialog.JACKIDKHKAI(Localization.Localize("No connection."), Localization.Localize("FinishChoosingCardsRPC"), 1983f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)(-151):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Current Locale unity = "], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["FuseSDK: Parsing error in _AccountLoginComplete"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG[", password = "], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_REQUIREDMINBIG"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array2 = new object[0];
			array2[1] = text;
			array2[0] = text2;
			array2[1] = text3;
			array2[0] = text4;
			Debug.LogFormat("CONFIRM", array2);
			WarningDialog.ShowError(Localization.Localize("ID_ARENARULES_EXPLOSIVESPROHIBITED"), Localization.Localize("PA: warbucks spent "), 182f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-147):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "{0} {1}");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["\t\"TRUE\""], 1);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("WFX_MF", array), Localization.Localize("registerCustomProfileString"), 1639f, null, string.Empty);
			break;
		}
		}
	}

	public static void FGKNOEDBDOJ(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("C0", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("Area" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-33), aBMLHILNNDM);
	}

	public static void NILJPIJNOMB(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>(", stacktrace = ", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("it" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-185), aBMLHILNNDM);
	}

	public static void DAJEFFFMDNA(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("ID_TUTORIAL_SNIPERSHOOT_UP"), Localization.Localize("-"), 1349f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_TUTORIAL_NOACCOUNT_{0}_TEXT"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("lootboxId" + text);
	}

	public static void IMBCAJMDPLD(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Total_Sessions", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("워프렌즈가 중요한 게임 데이터를 다운로드하려면 미디어 저장 장치에 대한 접근 권한이 필요합니다. 다음에 나오는 권한 설정을 수락해주세요. 이 권한 설정은 다른 목적으로는 사용되지 않습니다." + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.PromoteUnit, aBMLHILNNDM);
	}

	public static void PBFNJOLIEOO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)180:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ArenaUpcomingMessage"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("Assignment: Destroy Crates Constructor", array2);
			WarningDialog.ShowError(Localization.Localize("0"), Localization.Localize("CH"), 579f, null, string.Empty, JCOGJEEFLBC: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-196):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["GameCenterId"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Record Custom Event"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["GameDataReceived("], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["BonusDamage"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array = new object[7];
			array[0] = text;
			array[0] = text2;
			array[3] = text3;
			array[2] = text4;
			Debug.LogFormat("CLIENT REMINDERS:\nTutorial upgrade weapon running \"{0}\"\n", array);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("menu-arena-lootbox-bronze"), Localization.Localize("WebPlayer"), 1457f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)(-14):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "Play_Card_Tutorial_Duration");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["EventDefinition"]);
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("[Crashlytics Init] CrashlyticsService->Ctor->Initialize->After", num), Localization.Localize("InAppHandlerIos: On restore failed! "), 1463f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void ICCFCMFAKMO(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("squad", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("Category Button {0}" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-1), aBMLHILNNDM);
	}

	public static void EANLHENLFKC(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("116 STAGE 5 CONTINUE"), Localization.Localize("Unit"), 367f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["{0} doesn't contain data for card unit"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Unit_Upgrade" + text);
	}

	public static void ELOEPIMGBCN(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-197):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_VIPSTATUS"], string.Empty);
			object[] array3 = new object[0];
			array3[0] = text5;
			Debug.LogFormat("lastWeeksPlayerLeague", array3);
			WarningDialog.JACKIDKHKAI(Localization.Localize("TimeOfMatch"), Localization.Localize("SetupPushNotifications("), 984f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)163:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Get full squad id = "], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["NewVisuals"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_{0}_NAME"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["currentActivity"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[4];
			array2[1] = text;
			array2[1] = text2;
			array2[6] = text3;
			array2[2] = text4;
			Debug.LogFormat("ID_CONFIRM_SUBSCRIPTION_TEXT", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize("ServerResponseHandler.GetConfigurations DONE"), Localization.Localize("Google2u.DBUpgradeSlotsAssaulter"), 8f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case IJEAJGCCHEF.AlreadyUpgrading:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "ID_BRONZELOOTBOX");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_CONFIRM_ERROR"]);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("ID_STAT_HANDGUNKILLS", array), Localization.Localize("ID_GETREWARDSFORSTARTERASSIGNMENTS"), 1979f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void FLEMJBCCFJA(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)30:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Total_Gold_Spent"], string.Empty);
			object[] array3 = new object[0];
			array3[1] = text5;
			Debug.LogFormat(", password = ", array3);
			WarningDialog.ShowError(Localization.Localize("ID_STAT_MOSTREPUTATIONPOINTS"), Localization.Localize("Try Joining room "), 570f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)(-13):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["S"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["BoobyTrapSetRPC"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Time"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["{0} x {1}{2}[-]"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[2];
			array2[1] = text;
			array2[0] = text2;
			array2[8] = text3;
			array2[8] = text4;
			Debug.LogFormat("getGameConfigurationKeys", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize("menu-squadpoint-ico"), Localization.Localize("ID_CLAIMED"), 1140f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-194):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "ID_SKILLSHOTHINT_LONGSHOT");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["{0}"], 1);
			object[] array = new object[1];
			array[1] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("warbucks", array), Localization.Localize("Yes_Clicked"), 196f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void MBMCHKHNEJH(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_SQUADREWARDGET", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("HEAVYTURRET" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.KickPlayer, aBMLHILNNDM);
	}

	public static void JKBBEBNNKLF(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("GameCenterManager: Authenticate called - canShowDialog:"), Localization.Localize("ID_SELECTONEUNIT"), 1810f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["N"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Days_Since_Install" + text);
	}

	public static void HPLDKJICLND(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("\"", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("EE" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-113), aBMLHILNNDM);
	}

	public static void IKJAGHACKFP(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-153):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_CONFIRM_YOURVIDEOSUCCESSSUBMIT"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("menu-gold", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("game-card-ico-criticalinsurance"), Localization.Localize("\""), 638f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)21:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["AccountType"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_GETITCHEAPERNOW"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Terms: Start"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["reloadTime"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array = new object[0];
			array[0] = text;
			array[1] = text2;
			array[1] = text3;
			array[8] = text4;
			Debug.LogFormat("InAppHandlerIos: On restore finished", array);
			WarningDialog.ShowError(Localization.Localize("menu-sidetab-bg-box"), Localization.Localize("BS: player succesfully accepted to squad"), 1414f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-167):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "124 MENU WEAPON SCREEN TUTORIAL WEAPON ACTIVATED");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["after update GC still GC account, but no added or missing gcID or gcPassword"], 1);
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("Tickets", num), Localization.Localize("{0}:\t{1}\n"), 1158f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void PJOBJBLPFED(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("null"), Localization.Localize("KCOPCEKOCHL"), 1999f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_GUI_SYSTEMMAINTENANCE_DESC"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("EventAssignmentUpdate" + text);
	}

	public static void LOJKKBGCIBL(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("VIP"), Localization.Localize("null"), 1576f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_UNITELITEPERKFULLYTRAINED"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("ID_CONFIRM_FRIENDCANCELLED" + text);
	}

	public static void CEJCHANHBLL(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("adding cards: ", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("101 LOADING MAP" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetPlayerData, aBMLHILNNDM);
	}

	public static void DJBPOHNNLLD(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-76):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["S"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("ID_LOCAL", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Lcom/google/android/gms/games/stats/Stats;"), Localization.Localize("pt"), 1725f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-165):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Sniper_Tutorial_Duration"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["RewardMessage"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["was added"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Scripts search finished.\n"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array = new object[6];
			array[0] = text;
			array[1] = text2;
			array[6] = text3;
			array[5] = text4;
			Debug.LogFormat("Shooters", array);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("country-hong-kong"), Localization.Localize("Bronze"), 527f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-193):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "com.unity3d.player.UnityPlayer");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["OK"]);
			WarningDialog.ShowError(Localization.LocalizeFormat("#DANIEL# New Assignemnts Arrived: ", num), Localization.Localize(" "), 1553f, null, string.Empty);
			break;
		}
		}
	}

	public static void EOJJHBPGDHO(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.ShowAlert(Localization.Localize("Status"), Localization.Localize("BattleId"), 285f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["{0}{1} / {2}"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("()I" + text);
	}

	public static void AGMOCMLDHAD(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Category Button {0}", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("leagueId" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-152), aBMLHILNNDM);
	}

	public static void GACNLGLMDLI(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ID_PERMANENTUNLOCK"), Localization.Localize("S"), 1553f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Add RARITY {0} warcard - {1}"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("{0} {1}" + text);
	}

	public static void OLFEEPDMAFI(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("$5-$10"), Localization.Localize("TutorialCards"), 887f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Play_Card_Tutorial"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Visual {0}, no overcount" + text);
	}

	public static void FLCADAOMPLO(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("offerMult", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("#PETER# Removing squad left message - message time:{0}, server time:{1}, isInSquad:{2}" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-16), aBMLHILNNDM);
	}

	public static void EHCIFFMGCKB(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ID_HOU"), Localization.Localize("ID_WARCARDSARESPECIALBONUSES"), 682f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["HeroicMissionsCompletionRewardScraps"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("Yes_Clicked" + text);
	}

	public static void LKEPELMIJGD(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.ShowAlert(Localization.Localize("Weapon model not found! weaponprefab = '{0}' assetBundleName = '{1}'"), Localization.Localize("ID_SENDINGINVITE"), 233f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["RemoveFriend("], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("S" + text);
	}

	public static void EBPJDMCAMAO(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("menu-sidetab-joinedsquad"), Localization.Localize("ID_CONFIRM_FORFEIT_TEXT"), 210f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CANCELED"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("newMember" + text);
	}

	public static void EHGAGADAFEH(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("LEADERBOARDS - showing top squads - global:", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("ID_ARENAENDEDDESCRIPTION0WINS" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-54), aBMLHILNNDM);
	}

	public static void LIOCJBJNDMN(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("On Get Arena Leaderboards: CNT =  ", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("BufferId" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.BuyUnit, aBMLHILNNDM);
	}

	public static void HCNMMOHJFCD(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("AddAmmoRPC"), Localization.Localize("ID_CONFIRM_THANKYOU"), 991f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Texture reference count is less than zero!"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("DOWNLOAD" + text);
	}

	public static void PNHDGLHLNIE(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("URL", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("url " + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.AddVideoFeed, aBMLHILNNDM);
	}

	public static void KPPFDKMGOJJ(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("addPowerbandTime"), Localization.Localize("ID_PENDING"), 1480f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ScrappingParts"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Error - first node is not ROOT but " + text);
	}

	public static void ICNJEJOANDK(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Mission_Type", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("Error in Resync OwnerId: {0}, My Id: {1}, isOwnerActive: {2}, isMasterClient:{3}" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.PromoteUnit, aBMLHILNNDM);
	}

	public static void DHMNGEBGJAH(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("CURRENT PLAYER - REMOVE CARD FROM DEPOSITED CARDS - card id is null"), Localization.Localize("electricTrap"), 1263f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["trial"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("ID_PLUSHEALTH" + text);
	}

	public static void GIIAKCCHBGI(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("gameCenterPassword", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("OK" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-72), aBMLHILNNDM);
	}

	public static void PBHGKCMOEKI(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_YOURREWARDS", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("ID_SKILLSHOTHINT_TRIPPLEKILL" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.ArmyUnitWasShown, aBMLHILNNDM);
	}

	public static void MNOPMBHHOBL(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("MY", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("GameControllerCampaign.StartGame START" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.BuyCardPack, aBMLHILNNDM);
	}

	public static void NAJILGFCEBJ(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("ID_YOUNEEDMONEYTOUPGRADEELITE"), Localization.Localize("ID_CONFIRM_ERROR"), 447f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_REMINDER_GETCARDPACKS"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT2" + text);
	}

	public static void PINCGNIJMEK(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)93:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["SquadId"], string.Empty);
			object[] array2 = new object[0];
			array2[0] = text5;
			Debug.LogFormat("\t\"FALSE\"", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("()Lcom/google/android/gms/common/api/Status;"), Localization.Localize("ID_GOLDENLOOTBOXSMALL"), 1440f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-92):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_ERROR_SHORTINPUT"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Panel \"{0}\" has ok Depths"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Для запуска WarFriends требуется загрузить приблизительно 190 МБ дополнительных данных.\nВремя загрузки может варьироваться в зависимости от вашей сети и местонахождения.\n\nНачать загрузку?"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["WBTransactionAmount"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array = new object[1];
			array[0] = text;
			array[1] = text2;
			array[1] = text3;
			array[4] = text4;
			Debug.LogFormat("106 STAGE 2 STARTED", array);
			WarningDialog.JACKIDKHKAI(Localization.Localize("Panel \"{0}\" has ok Z"), Localization.Localize("PayWithTickets"), 601f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-197):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "Hiding CONFIRM dialog");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Load assetBundle which is not cached !!!: "]);
			WarningDialog.ShowError(Localization.LocalizeFormat("AtlasPreparer.LoadTutorialCoroutine", num), Localization.Localize("ID_CONFIRM_ACCOUNTBANNED"), 1621f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		}
	}

	public static void LPDEKCNMPLI(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)144:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Beanstalk Server Manager: Found Player Progress = "], string.Empty);
			Debug.LogFormat("VipReward1", text5);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Result for action:{0} on global:{1}"), Localization.Localize("BotWeaponPower"), 1405f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)128:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Prefabs Full Path: \"{0}\"\n"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["{0}{1}"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["isGameCenter"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Player with id {0} doesnt exists ! "], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array2 = new object[4];
			array2[0] = text;
			array2[1] = text2;
			array2[6] = text3;
			array2[7] = text4;
			Debug.LogFormat("ID_STARTERASSIGNMENT6", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_TUTORIAL_DELIVER"), Localization.Localize("Rank_up_4"), 796f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-3):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "Set isInMatch: ");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["OnPhotonJoinRoomFailed: {0}, message {1}"]);
			object[] array = new object[0];
			array[0] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("ID_WARNING_ERRORCLAIMEVENT", array), Localization.Localize("#PETER# removing warcards from slots"), 581f, null, string.Empty);
			break;
		}
		}
	}

	public static void PACPAOLNFAH(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Player_id", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("SETTING FullResNoMS" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetAllPlayers, aBMLHILNNDM);
	}

	public static void DCCBNMNEOLM(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT"), Localization.Localize("({0}\u00a0/\u00a0{1})"), 1161f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["\"NaN\""], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("ID_CATEGORY_LOW_PL_GRENADE" + text);
	}

	public static void NGFBCEKADPJ(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)6:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DogTagCap"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("Skill", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize("Setting performance to: "), Localization.Localize("DailyMissionsData"), 726f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)(-49):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_REMINDER_GETCARDPACKS"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["确认"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Time"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Bonus Name"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array = new object[3];
			array[0] = text;
			array[1] = text2;
			array[4] = text3;
			array[8] = text4;
			Debug.LogFormat("metalExplosion", array);
			WarningDialog.JACKIDKHKAI(Localization.Localize("MaintenanceMessage"), Localization.Localize("Inactive player disconnected: "), 1696f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)(-109):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "Player_Level");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Prefabs to go through: {0} + {1}"]);
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("country-egypt", num), Localization.Localize("ID_UNLOCKEDATRANK"), 472f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void DIGALKHGDCP(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.ShowAlert(Localization.Localize("stand_up_crawl"), Localization.Localize("BeAdvisedConnectFacebook"), 1324f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Multiday_gold_claimed"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Beanstalk: " + text);
	}

	public static void HIACCBBKKFJ(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-179):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["_FrustumCornersWS"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("ID_DEBUG_STACKTRACEINCONSOLE", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize("NotEnoughPlayers"), Localization.Localize("shotReal"), 527f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)40:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["."], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["SquadWarWins"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["InApp_ID"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["123 MENU WEAPON SCREEN TUTORIAL WEAPON BUY CLICKED"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array = new object[7];
			array[1] = text;
			array[1] = text2;
			array[4] = text3;
			array[6] = text4;
			Debug.LogFormat("ID_USEREXISTSGAMECENTERTEXT", array);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("SkillShotManager.prefab"), Localization.Localize("DPS"), 242f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)19:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "ID_YOUNEEDXTICKETSFOREXTRAHEART");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["SyncWarperRPC"], 1);
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("-1", num), Localization.Localize("OnConnectionFailed: 00"), 713f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void GLJAHAAJNEC(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("special"), Localization.Localize("ID_READYTIME"), 1245f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG[" "], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("veteranpack5" + text);
	}

	public static void BKHKENGBFJJ(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>(" (ID:", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("ChillingoSdkManager" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.LoginToCustomAccount, aBMLHILNNDM);
	}

	public static void GGOPFAFIDHG(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("FuseBox Event VisualGained for rarity {0}"), Localization.Localize("getRewardedInfoForZoneID"), 387f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["PlaySparks"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("roomName" + text);
	}

	public static void BDKKGKLLCNF(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)85:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_MEMBER"], string.Empty);
			object[] array3 = new object[0];
			array3[1] = text5;
			Debug.LogFormat("\\D*$", array3);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CONNECTIONERROR"), Localization.Localize("Yes_Clicked"), 1290f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-184):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG[" "], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["GameController.Awake DONE"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Checker"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["0"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[5];
			array2[0] = text;
			array2[1] = text2;
			array2[7] = text3;
			array2[2] = text4;
			Debug.LogFormat("IOAJFNMOGOD", array2);
			WarningDialog.JACKIDKHKAI(Localization.Localize(")"), Localization.Localize("getAppId"), 1625f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-63):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "下載");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["newMember"], 1);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("cn", array), Localization.Localize("test_attribute5"), 132f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void BJOEEBJABGO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-21):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Xp"], string.Empty);
			Debug.LogFormat("ID_CONFIRM_INFO", text5);
			WarningDialog.JACKIDKHKAI(Localization.Localize(" abilityIcon:"), Localization.Localize("\"{0}\""), 1405f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)185:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["small_icon"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_TUTORIAL_TAPON"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_CONFIRM_ERROR"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DOWNLOAD"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[3];
			array2[1] = text;
			array2[0] = text2;
			array2[6] = text3;
			array2[1] = text4;
			Debug.LogFormat("PrepareBotForDeathMatch 4", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("-1"), Localization.Localize("Card_1_Played"), 1204f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)159:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "N0");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_MONEYPACKINFORMATIONS"]);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("GoldCoefficient", array), Localization.Localize("ID_GUI_SQUADLEVELEDUP_CARDPOOLINC"), 1174f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void MDLALOJFJOG(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-74):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["resultMessage"], string.Empty);
			object[] array3 = new object[0];
			array3[1] = text5;
			Debug.LogFormat("{0} {1}", array3);
			WarningDialog.ShowError(Localization.Localize("GameLauncher.Async"), Localization.Localize("com/google/android/gms/games/Games"), 1607f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)(-70):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["discount"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Set Delegate"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CURRENT PLAYER - depositedCardsDic is null"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["You probably assigned bad type of AmmoSetup to gun"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array2 = new object[7];
			array2[1] = text;
			array2[1] = text2;
			array2[6] = text3;
			array2[5] = text4;
			Debug.LogFormat("Challenge Counter expired!", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("{0} {1} {2}/ {3}[-]"), Localization.Localize("1"), 354f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)39:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "ID_SALEPERCENTLINE");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ExpiresOn"], 1);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("AIRSTRIKE", array), Localization.Localize("getCustomProfileString"), 1084f, null, string.Empty);
			break;
		}
		}
	}

	public static void OBCJJGKJCID(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-37):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["MMICMBJKHFO"], string.Empty);
			object[] array3 = new object[1];
			array3[1] = text5;
			Debug.LogFormat("ID_CONFIRM_WRONGPLAYERDATA", array3);
			WarningDialog.ShowError(Localization.Localize("Windows"), Localization.Localize("null"), 1000f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)(-23):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["BS: On Get New Assignemnts"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["target_id"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Country"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["aYxLQ40XpBYemQhnRYMJg3VBd"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[1];
			array2[0] = text;
			array2[1] = text2;
			array2[1] = text3;
			array2[1] = text4;
			Debug.LogFormat("extraVip", array2);
			WarningDialog.ShowError(Localization.Localize("SquadId"), Localization.Localize("Gold"), 876f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)(-189):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "{0}\u00a0{1}");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Z "], 1);
			object[] array = new object[1];
			array[1] = num;
			WarningDialog.ShowError(Localization.LocalizeFormat("blackmarket", array), Localization.Localize("ArenaLootBox"), 1205f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void MDKFPCEJMMD(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("([-_:]|\\s)", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("VipReward1" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-85), aBMLHILNNDM);
	}

	public static void BAKCPBKEIHJ(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Sniper_Tutorial_Duration", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("PlayerName" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)50, aBMLHILNNDM);
	}

	public static void ACFGDEDKPAO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case IJEAJGCCHEF.WrongVideoFeed:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["URL"], string.Empty);
			Debug.LogFormat("#DOMINIK# Wrong url added! {0}", text5);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WRONGVIDEOFEED"), Localization.Localize("ID_WARNING_INVALIDLINK"), 0f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case IJEAJGCCHEF.DuplicatedVideoFeed:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["URL"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["category"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["name"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["order"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			Debug.LogFormat("#DOMINIK# Video with URL {0} already stored in {1} under name {2} [{3}]", text, text2, text3, text4);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_DUPLICATEDVIDEOFEED"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		}
		case IJEAJGCCHEF.MaxVideoFeedsExceeded:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "dailyLimit");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["max"]);
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_WARNING_MAXVIDEOFEEDSSUBMITTED", num), Localization.Localize("ID_WARNING_LIMITREACHED"), 0f, null, string.Empty);
			break;
		}
		}
	}

	public static void NAKCECEJION(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)198:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Predefined_Assignment_Completed"], string.Empty);
			object[] array3 = new object[0];
			array3[1] = text5;
			Debug.LogFormat("Terms: OnApplicationPause close session", array3);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_TUTORIAL_SNIPER_UP"), Localization.Localize("#PETER# League Arc "), 847f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)123:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Can not find asset {0}"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["WarsEvaluation"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["SetIsImmortalRPC"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ChangeWeightForDestroyablePartRPC"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[6];
			array2[0] = text;
			array2[1] = text2;
			array2[4] = text3;
			array2[7] = text4;
			Debug.LogFormat("warfriends-staging.eu-west-1.elasticbeanstalk.com/", array2);
			WarningDialog.ShowError(Localization.Localize("isUserInAnySegmentIds"), Localization.Localize("subitem1"), 1499f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)137:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "0\u00a0");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_SALEPERCENT"]);
			object[] array = new object[0];
			array[0] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("SERVICE_DISABLED", array), Localization.Localize("ID_STARTERASSIGNMENT"), 168f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void CLCKDOJHIEO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-193):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["No free position for decoy!"], string.Empty);
			Debug.LogFormat("Enemy could not be spawned", text5);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("weapon1"), Localization.Localize("division changed!!!"), 1059f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-78):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Gold"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_FEATURE_SHOTSPEED-FANCY"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Prefabs to go through: {0} + {1}"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["GameConfigurationReceived()"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array2 = new object[3];
			array2[0] = text;
			array2[1] = text2;
			array2[3] = text3;
			array2[8] = text4;
			Debug.LogFormat("game-card-ico-healingstorm", array2);
			WarningDialog.ShowError(Localization.Localize("com/google/android/gms/common/ConnectionResult"), Localization.Localize("UnitReadyForPromotion {0} {1}"), 592f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)163:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "WindowDuration");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["menu-army-cat-rusher"], 1);
			object[] array = new object[0];
			array[0] = num;
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_INVITATION_VALID_FOR", array), Localization.Localize("strafing_right"), 370f, null, string.Empty);
			break;
		}
		}
	}

	public static void HCNAMKEIAGO(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Total_Warbucks_Spent", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("r" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-81), aBMLHILNNDM);
	}

	public static void KLPFJPBMDGG(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)14:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Mega_Reward"], string.Empty);
			object[] array2 = new object[0];
			array2[0] = text5;
			Debug.LogFormat("Video_feed_accessed", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_MIN"), Localization.Localize("after update GC still GC account, but no added or missing gcID or gcPassword"), 347f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-197):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Particle with name: "], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["LevelName"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CurrentBundleVersion.GetModifiedVersion - version is '{0}'"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DamageEventPlayerShoot damage: {0} to {1} new HP {2}"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array = new object[6];
			array[1] = text;
			array[0] = text2;
			array[7] = text3;
			array[0] = text4;
			Debug.LogFormat("N", array);
			WarningDialog.JACKIDKHKAI(Localization.Localize("seconds"), Localization.Localize("menu-hub-multiplayer-vipico"), 838f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)74:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "com.google.android.gms.common.api.PendingResult");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_OK"], 1);
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("GooglePlay", num), Localization.Localize("N"), 1171f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void KNOFKHFPJIA(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("BS: Player report sent!"), Localization.Localize("Squad name success"), 1583f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_DEBUG_EVENTASSIGNMENTUPDATE"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("bazooka_shoot_left" + text);
	}

	public static void NDOGABMBLAG(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Play_Skirmish", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("ID_INMASTER2" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-176), aBMLHILNNDM);
	}

	public static void JBDDAMJMKGM(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-170):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["MissionType"], string.Empty);
			object[] array2 = new object[0];
			array2[1] = text5;
			Debug.LogFormat("Days_Since_Install", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("PlayerGold"), Localization.Localize("ClientVersion"), 543f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)116:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["BeginnersLeague"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Buy_Upgrade_For_Army_Unit_Elite"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Arena Expired - you gain scraps. You have {0} lives."], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_WAITFORDOGTAGTOREFILL"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array = new object[5];
			array[0] = text;
			array[1] = text2;
			array[8] = text3;
			array[6] = text4;
			Debug.LogFormat("Application focus changed to {0} and have created AWS mobile analytics {1}", array);
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_GETTOAVOIDRELEGATION1"), Localization.Localize("ID_WARNING_CANNOTCREATESQUAD_TEXT"), 1111f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)(-46):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "ID_TOCOMPLETE");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["SquadId"]);
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("BANDS_EMPTY", num), Localization.Localize("menu-arena-scrap-ico"), 928f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void FKANLBDBPGI(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-2):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_YOURFRIENDHASDENIED"], string.Empty);
			object[] array3 = new object[1];
			array3[1] = text5;
			Debug.LogFormat("#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP", array3);
			WarningDialog.JACKIDKHKAI(Localization.Localize("S"), Localization.Localize("SquadWarWins"), 3f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)89:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["League"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Lcom/google/android/gms/games/event/Events;"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_ARENAREWARDREQUIREMENTS"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Wood"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array2 = new object[7];
			array2[1] = text;
			array2[1] = text2;
			array2[4] = text3;
			array2[1] = text4;
			Debug.LogFormat("Directory \"{0}\" does not exists", array2);
			WarningDialog.ShowError(Localization.Localize("isVIP"), Localization.Localize("discount"), 1268f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
		case (IJEAJGCCHEF)(-162):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "ID_STAT_WINLOSSRATIO");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["LevelName"]);
			object[] array = new object[0];
			array[1] = num;
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("ExplodeRPC", array), Localization.Localize("Beanstalk: On Remove Login"), 1632f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void CNKNKBNNJAB(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)158:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Hearts"], string.Empty);
			Debug.LogFormat("ID_STATE_FRIENDISREADYTOBATTLE", text5);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Time"), Localization.Localize("Scraps"), 911f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)160:
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_ACTIVATEINSTEADOF"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["damage:"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Anticheat"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Beanstalk: Get Squad Details"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array = new object[1];
			array[1] = text;
			array[0] = text2;
			array[3] = text3;
			array[5] = text4;
			Debug.LogFormat("CheckMessages", array);
			WarningDialog.JACKIDKHKAI(Localization.Localize("Heroic"), Localization.Localize("{0} [9A9999]/[0BBCFF] {1}"), 1129f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		case (IJEAJGCCHEF)(-29):
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "missing UIRoot");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["{0} {1}"]);
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("ID_FEATURE_DAMAGE-DESCRIPTION", num), Localization.Localize("ShotFrequencyMax"), 1536f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
		}
	}

	public static void KMJOFIBBBGE(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.CKGMDJFKNPO(Localization.Localize("SIGN_IN_FAILED"), Localization.Localize("ID_SALEPERCENTLINE"), 1460f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Assignment_Completed"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("menu-army-cat-defender" + text);
	}

	public static void MAMDLKPFBIK(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("FuseSDK_Prime31_IAB: GoogleIAB.queryInventory failed with message: "), Localization.Localize("Loading - cancel clicked, will to try call disconnect"), 200f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["true"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("6-10" + text);
	}

	public static void OOMNIBFFIGO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-89):
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_GUI_ACCEPT_PLAYER_ALREADYMEMBER"], string.Empty);
			object[] array3 = new object[1];
			array3[1] = text5;
			Debug.LogFormat("-{0}-{1}", array3);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("placement"), Localization.Localize("SERVICE_MISSING_PERMISSION"), 1629f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text5);
			break;
		}
		case (IJEAJGCCHEF)(-197):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Sniper_Tutorial_Duration"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["true"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Lcom/google/android/gms/games/Players;"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["\""], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
			object[] array2 = new object[3];
			array2[1] = text;
			array2[1] = text2;
			array2[6] = text3;
			array2[5] = text4;
			Debug.LogFormat("com/google/android/gms/games/Games", array2);
			WarningDialog.ShowError(Localization.Localize("1"), Localization.Localize("MainScene"), 464f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)77:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, "accountName");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["menu-army-cat-defender"], 1);
			object[] array = new object[1];
			array[1] = num;
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("LevelName", array), Localization.Localize("SDK_INT"), 219f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		}
	}

	public static void OOHAOGELPIM(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Subscription", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("CardId" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.TutorialEnded, aBMLHILNNDM);
	}

	public static void ENGMPKBMPJK(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ID_XTICKETS"), Localization.Localize("HAVE A NICE DAY"), 763f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["gold"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("PlayerData" + text);
	}

	public static void HHMMAJANNEH(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)43:
		{
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_SENDINGINVITE"], string.Empty);
			object[] array3 = new object[1];
			array3[1] = text5;
			Debug.LogFormat("gold3", array3);
			WarningDialog.JACKIDKHKAI(Localization.Localize("SpecialOfferDiscountAdd"), Localization.Localize("SetFractionRPC"), 904f, null, string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text5);
			break;
		}
		case (IJEAJGCCHEF)(-98):
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DeathEventPlayer"], string.Empty);
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["set schedule gc check 2"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Y7R5XKWF2WY9DWGG7DVW"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["NO EVENT ASSIGNMENT CONFIG RECEIVED!!!"], string.Empty);
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
			object[] array2 = new object[6];
			array2[1] = text;
			array2[0] = text2;
			array2[8] = text3;
			array2[2] = text4;
			Debug.LogFormat("GameController.LoadAndStartNewMap - 1sec delay", array2);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("{0} {1}"), Localization.Localize("Play_Card_Tutorial_Duration"), 1433f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)6:
		{
			Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, "ID_DOYOUWANTTOBUYWARBUCKS");
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["max"]);
			object[] array = new object[0];
			array[0] = num;
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("setAndroidIdSha1", array), Localization.Localize("RegisterAge()"), 254f, null, string.Empty, JCOGJEEFLBC: true);
			break;
		}
		}
	}

	public static void OOGPGLGDAIJ(string HKODIHDPOGE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("{0} {1}", HKODIHDPOGE));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.LogError("ID_ARENARULES_NOCRATES" + HKODIHDPOGE);
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-157), aBMLHILNNDM);
	}

	public static void GGINJHGPNCH(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.KDAEFLFPBMN(Localization.Localize("Card_3_Played"), Localization.Localize("ID_GUI_LEAGUEBONUS"), 1176f);
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["LootBoxRotation"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: false, text);
		Debug.Log("Google2u." + text);
	}

	public static void LLCLNJKBGGM(Dictionary<string, object> EENKJBCCPBG)
	{
		ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SUCCESS"), Localization.Localize("ID_CONFIRM_YOURVIDEOSUCCESSSUBMIT"));
		string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["URL"], string.Empty);
		Singleton<EventTrackingManager>.instance.VideoUploaded(NOCIMJBMOCB: true, text);
		Debug.Log("#DOMINIK# Video feeed added!! " + text);
	}
}
