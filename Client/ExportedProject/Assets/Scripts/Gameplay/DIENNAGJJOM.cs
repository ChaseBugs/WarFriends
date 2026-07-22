using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public class DIENNAGJJOM
{
	public static Action<bool> NKBJMLEBMBH;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	[CompilerGenerated]
	private static Action CCNLMGEJBIB;

	[CompilerGenerated]
	private static Action KBAICANEKOP;

	public static void HIACCBBKKFJ(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-67):
			WarningDialog.ShowError(Localization.Localize("QUIT"), Localization.Localize("isRandomMap"), 673f, CBLAKJKPBCC, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-175):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Should not happened"), Localization.Localize("^\\D*"), 1805f, NDAFLLMHIGH, string.Empty, JCOGJEEFLBC: true);
			break;
		case (IJEAJGCCHEF)(-89):
			Debug.LogError("\"");
			WarningDialog.ShowError(Localization.Localize("gold"), Localization.Localize("UseOnGetPlayerData"), 1472f, JOPFLHHONHG, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
	}

	public static void GBHIPPGKOFP(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("ID_TUTORIAL_PHASE", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.BuyInApp, list);
	}

	public static void KNCMJDBHMFB(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)80:
			WarningDialog.JACKIDKHKAI(Localization.Localize("Lcom/google/android/gms/games/Players;"), Localization.Localize("GooglePlay"), 1714f, EKLBNLHMJCH, string.Empty, JCOGJEEFLBC: true);
			break;
		case (IJEAJGCCHEF)83:
			WarningDialog.ShowError(Localization.Localize("ScrapsGained"), Localization.Localize("SquadId"), 1256f, EAEEMFCGIML, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case IJEAJGCCHEF.NotEnoughLevel:
			Debug.LogError(" Desc = ");
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_GUI_ACCEPT_PLAYER_WTJ"), Localization.Localize("'ID_MONTH_'0"), 369f, HPEGBLBDIEF, string.Empty, JCOGJEEFLBC: true);
			break;
		}
	}

	public static void DDNNPLEPOAH(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("ID_ZEROSECONDS", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)117, list);
	}

	public static void NDJKLBBIDPE(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("menu-hub-multiplayer-vipico");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns++;
		if (EENKJBCCPBG.ContainsKey("subitem1"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["WinCount"], 1L);
			Debug.Log("factor: " + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("ID_CONFIRM_JOINSQUADEVENT"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["percent"], 1L);
			Debug.Log("menu-wftv-youtube-ico" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["defaultValue"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	private static void DHMMMKKNJOO()
	{
		GameLoginManager.Relog();
	}

	public static void DHGINOPENOK(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-31):
			WarningDialog.JACKIDKHKAI(Localization.Localize("hasConnectedApi"), Localization.Localize("UIReflectionEffect reference missing for index "), 406f, LOMAGLMFMAB, string.Empty, JCOGJEEFLBC: true);
			break;
		case (IJEAJGCCHEF)91:
			WarningDialog.JACKIDKHKAI(Localization.Localize("AchievementClaimed"), Localization.Localize("RETRYPERM"), 760f, EAEEMFCGIML, string.Empty, JCOGJEEFLBC: true);
			break;
		case (IJEAJGCCHEF)(-173):
			Debug.LogError("ok");
			WarningDialog.ShowError(Localization.Localize("Mouse Y"), Localization.Localize("measureEvent"), 339f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		}
	}

	private static void BMJIEPKAGFI()
	{
		GameLoginManager.Relog();
	}

	private static void FIDKKFEECMJ()
	{
		GameLoginManager.Relog();
	}

	[CompilerGenerated]
	private static void LOIOLIDEPDA()
	{
		GameLoginManager.Relog();
	}

	private static void OJAPMKFAFLI()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void OADHNKIMEBH()
	{
		GameLoginManager.Relog();
	}

	public static void MMDIJLAFOGM(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("count: 0");
		long num = 1L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("!!!!"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Medals requirement = "], 0L);
			Debug.Log("ID_ARENARULES_DEFENDERSPROHIBITED" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("withDate2"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Squad_Leave"], 0L);
			Debug.Log("ID_CREATESQUADNOTENOUGH" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["NOT REMOVING FACEBOOK FROM CURRENTPLAYER"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void LLCLNJKBGGM(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("On Enter Arena!!");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns++;
		if (EENKJBCCPBG.ContainsKey("Tickets"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Tickets"], 0L);
			Debug.Log("Tickets Spent " + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("Gold"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Gold"], 0L);
			Debug.Log("Gold Spent " + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["WarArenaData"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void EHMCAPEINNC(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)69:
			WarningDialog.ShowError(Localization.Localize("SetupRPC"), Localization.Localize("Automatic_Equip"), 874f, CNFDDOBMACB, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-26):
			WarningDialog.ShowError(Localization.Localize("rental for unexist visual: {0}"), Localization.Localize("ID_CATEGORY_LOW_SG_HANDGUN"), 608f, JBBAGFMCJND, string.Empty, JCOGJEEFLBC: true);
			break;
		case (IJEAJGCCHEF)(-67):
			Debug.LogError("ID_INSILVER1");
			WarningDialog.JACKIDKHKAI(Localization.Localize("Automatic_Equip"), Localization.Localize("Scraps"), 1979f, JOPFLHHONHG, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
	}

	public static void CLCCAFPBHCP(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-22):
			WarningDialog.JACKIDKHKAI(Localization.Localize("IosReceipt"), Localization.Localize("Buy_InstantBattle"), 1298f, GAPBBAHNBHF, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case IJEAJGCCHEF.PlayerNameTaken:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_CONFIRM_MAXCCUREACHED"), Localization.Localize(", password = "), 458f, LBMOAPCHBGO, string.Empty, JCOGJEEFLBC: true);
			break;
		case (IJEAJGCCHEF)(-97):
			Debug.LogError("ID_MAXSTAT");
			WarningDialog.KHOMNBHMFGA(Localization.Localize("[0-9.,]*"), Localization.Localize("menu-sidetab-messageicon"), 1281f, OJAPMKFAFLI, string.Empty);
			break;
		}
	}

	private static void HNNAFPIMAPF()
	{
		GameLoginManager.Relog();
	}

	private static void EAEEMFCGIML()
	{
		GameLoginManager.Relog();
	}

	public static void OBCJJGKJCID(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)95:
			WarningDialog.JACKIDKHKAI(Localization.Localize("Chat: Channels "), Localization.Localize("ID_READYTIME"), 492f, BMJIEPKAGFI, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)59:
			WarningDialog.ShowError(Localization.Localize("StepId"), Localization.Localize("BAND_REWARD_HEALTH"), 324f, BEEGMMKGHDP, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)75:
			Debug.LogError("Rental");
			WarningDialog.ShowError(Localization.Localize("Price"), Localization.Localize("warbucks initialized"), 114f, HOOMDDGPNFE, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
	}

	private static void NDAFLLMHIGH()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void AIJPOLMFJKL(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-21):
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_SQUADEVENT"), 426f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case (IJEAJGCCHEF)150:
			WarningDialog.ShowError(Localization.Localize("{0} {1}{2}"), Localization.Localize("game-elite-debuff"), 463f, DHMMMKKNJOO, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-73):
			Debug.LogError("Medals/");
			WarningDialog.KHOMNBHMFGA(Localization.Localize("isLeft "), Localization.Localize("tempuser@tempcompany.com"), 753f, PNHJIHCEMHK, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
	}

	public static void ACFGDEDKPAO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case IJEAJGCCHEF.ArenaDoesntExist:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ARENADOESNTEXIST"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case IJEAJGCCHEF.NotEnoughTickets:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTICKETSARENA"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case IJEAJGCCHEF.NotEnoughGoldForArena:
			Debug.LogError("NOT ENOUGH GOLD FOR ARENA");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHGOLDARENA"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		}
	}

	private static void MFGCFILNHJI()
	{
		GameLoginManager.Relog();
	}

	public static void FKDHHAIDBLI(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("explodeDamage", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.RefillDogtags, list);
	}

	private static void CDKMALCMLIO()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void DEIBOPGEAOD(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case IJEAJGCCHEF.SameFacebookAlreadyCreated:
			WarningDialog.ShowError(Localization.Localize("dogTagTimerLock"), Localization.Localize("Cards on saved data: "), 1009f, CNDBOIMJLOB, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-143):
			WarningDialog.JACKIDKHKAI(Localization.Localize("Please add object to pool, before instanciing it ::: prefab name = "), Localization.Localize("SquadId"), 1871f, MNMNJBCDPOP, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)180:
			Debug.LogError("GooglePlayId");
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_STATE_CONNECTINGTOSERVER"), Localization.Localize("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER"), 1459f, NKDFBOAAHEH, string.Empty);
			break;
		}
	}

	private static void OJOFMJMMFNF()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void EJIPHFANGCM(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("addedVIP");
		long num = 1L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("Cheat"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["addedType"], 1L);
			Debug.Log("ID_INMASTER2" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("ID_NOTIFICATION_LAPSED_MORE"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["PlayerId"], 1L);
			Debug.Log("menu-everyplay-ico" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Stop Loading called when Game is loading or running"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	private static void JBBAGFMCJND()
	{
		GameLoginManager.Relog();
	}

	public static void FGOBNEDJOAN(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("S");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("https://"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["_Metallic"], 0L);
			Debug.Log("Still waiting for server\nBe patient :-)" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey(","))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["HeroicMissionsCompletionRewardArmyUnitParts"], 0L);
			Debug.Log("216 MENU ARMY SCREEN TUTORIAL UNIT ACTIVATED" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Error: {0}"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void GGOPFAFIDHG(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("ID_INGOLD1");
		long num = 1L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("Stage"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Army Power Ability Animation from {0} to {1}"], 1L);
			Debug.Log("[CardSoldierOnSteroids] - used agan after spawning start, but before finish!!!" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("Slow Motion"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_INSILVER2"], 0L);
			Debug.Log("testingidsquadrankup" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["true"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void KGPOKOFLILI(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("S");
		long num = 0L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns++;
		if (EENKJBCCPBG.ContainsKey("ArenaHeartDialog"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["blockingConnect"], 0L);
			Debug.Log("Pack" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("ID_INVITATION_VALID_FOR"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Y7R5XKWF2WY9DWGG7DVW"], 1L);
			Debug.Log("601 TUTORIAL STARTED" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["StartTime"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void HOCGFKLJPCF(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("126 MENU BATTLE SCREEN SHOWN", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.DemotePlayer, list);
	}

	private static void EKLBNLHMJCH()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void EAFJNHDMCAO()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void CHIHJNBIAPM(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)83:
			WarningDialog.JACKIDKHKAI(Localization.Localize("game-card-ico-belovedenemy"), Localization.Localize("Freeze game:"), 375f, CNDBOIMJLOB, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-53):
			WarningDialog.ShowError(Localization.Localize("Omitting object: "), Localization.Localize("ID_REMINDER_GETVALUABLECARDPACKS"), 1696f, NBNOJMBCJPI, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-139):
			Debug.LogError("#VOJTA# Message Manager: Error previously ignored message arrived again from server! Id = ");
			WarningDialog.ShowError(Localization.Localize("Cards_Owned_Bronze"), Localization.Localize("groundBoxHit"), 785f, KDAGGCDDHHN, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
	}

	private static void KLPEBADGENE()
	{
		GameLoginManager.Relog();
	}

	public static void LJIMGIOGAMJ(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("Wrong_Category", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-177), list);
	}

	public static void AGMOCMLDHAD(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("stand_up_begin", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-173), list);
	}

	[CompilerGenerated]
	private static void EOIAMCLHGJD()
	{
		GameLoginManager.Relog();
	}

	public static void BJHMLPFBOOG(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)192:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Pack_Id"), Localization.Localize("ID_VISUALCATEGORY2"), 1328f, NHGCHPEAAJF, string.Empty);
			break;
		case (IJEAJGCCHEF)(-185):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Commando"), Localization.Localize("Logs sent to server\nWaiting for response"), 780f, MNMNJBCDPOP, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case IJEAJGCCHEF.NotEnoughGold:
			Debug.LogError("Buy_Pack");
			WarningDialog.JACKIDKHKAI(Localization.Localize("Scraps"), Localization.Localize("1"), 469f, HPEGBLBDIEF, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
	}

	public static void FANNAFLCNEL(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)131:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("N"), Localization.Localize("M"), 1321f, CBLAKJKPBCC, string.Empty);
			break;
		case (IJEAJGCCHEF)165:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("bazooka_uncover_left"), Localization.Localize("Landroid/os/Parcelable$Creator;"), 432f, MFHHAAPEIGN, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)129:
			Debug.LogError("ID_RENTAL_GRENADE");
			WarningDialog.JACKIDKHKAI(Localization.Localize("Lcom/google/android/gms/games/Notifications;"), Localization.Localize("Level"), 255f, NKDFBOAAHEH, string.Empty, JCOGJEEFLBC: true);
			break;
		}
	}

	public static void GNEAKIJGMNN(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("League", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-19), list);
	}

	public static void LLOBIHNAEON(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("SpawnForCardRPC");
		long num = 1L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("Wrong_Unit"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["BANDS"], 0L);
			Debug.Log("Fb_login" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("{0} {1}"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["L"], 0L);
			Debug.Log("[" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["1234567890"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void LHNCEPGENKG(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("bronze");
		long num = 1L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("ID_GETFORPROMOTION1"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["UpgradeWeaponReminder {0} {1}"], 0L);
			Debug.Log("CONTENTS_FILE_DESCRIPTOR" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("[Singleton] An instance of "))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_SIGNOUT"], 0L);
			Debug.Log("N" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["S"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	private static void CBLAKJKPBCC()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void MEOKAKNJDKE(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-90):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("menu-army-cat-rusher"), Localization.Localize("ID_NOTIFICATION_LAPSED_BASE"), 960f, CNDBOIMJLOB, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)54:
			WarningDialog.JACKIDKHKAI(Localization.Localize("PlacementMatchesRequired"), Localization.Localize("{0}{1}[-]"), 1239f, KLPEBADGENE, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)171:
			Debug.LogError("Post Parameters: ");
			WarningDialog.JACKIDKHKAI(Localization.Localize("Spend_Gold_On_Power_Bands"), Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), 1518f, HPEGBLBDIEF, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		}
	}

	public static void BHGLILBIDBO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-48):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("RETRY"), Localization.Localize("saved obtained cards: "), 23f, CNFDDOBMACB, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-177):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("WithdrewWarcard-{0}-{1}-{2}"), Localization.Localize("Card {0} {1} {2}"), 1675f, DHMMMKKNJOO, string.Empty);
			break;
		case (IJEAJGCCHEF)123:
			Debug.LogError("Stop shooting ");
			WarningDialog.KHOMNBHMFGA(Localization.Localize("WENEEDTO"), Localization.Localize("ID_TWITTER_FOLLOWING_TITLE"), 1663f, FMAPGFGHNIF, string.Empty);
			break;
		}
	}

	private static void GJGDIMGBAIE()
	{
		GameLoginManager.Relog();
	}

	private static void ILFJMNHCLIP()
	{
		GameLoginManager.Relog();
	}

	public static void CJNAAOJMHOM(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("no parameters");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns++;
		if (EENKJBCCPBG.ContainsKey("Warfriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Ьез этого разрешения игра не может функционировать и будет закрыта. Пожалуйста, попробуй снова или выйди из WarFriends."))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["name"], 0L);
			Debug.Log("ShowEngineerBuildingIndicator" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("Buy_Army_Unit"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_GUI_EQUIP"], 0L);
			Debug.Log("menu-army-cat-explosive" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_SEC"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void DAJEFFFMDNA(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("ID_CONFIRM_NOTLEADEROFSQUAD_TEXT");
		long num = 0L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("open"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["{0} {1}/{2} {3}"], 1L);
			Debug.Log("Vip" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("ArenaLives"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_DEBUG_STACKTRACEINCONSOLE"], 0L);
			Debug.Log("SheetConfig" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["trial"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void MEDPHDLDECP(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("ID_DEBUG_GUIERROR");
		long num = 0L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("ID_STAT_ROCKETLAUNCHERKILLS"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ChillingoSdkManager"], 0L);
			Debug.Log("Army upgrade for " + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("Assignment: Finish Missions Constructor, count = "))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Animation from State: Ready to State: None"], 0L);
			Debug.Log("Still waiting for server\nBe patient :-)" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_FEATURE_ACCURACY-WEAPONPREFIX"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	private static void JOPFLHHONHG()
	{
		GameLoginManager.Relog();
	}

	public static void PJBOJCBNIIC(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("ID_SECONDS");
		long num = 1L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["BS: On change language."], 0L);
			Debug.Log("55a90af8-a7bb-4152-a5e4-639d7488b0fb" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("ID_YES"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Level"], 0L);
			Debug.Log("PACK" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_CONFIRM_ACCOUNTBANNED"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void GGINJHGPNCH(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("game-card-ico-mineyourstep-full");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns++;
		if (EENKJBCCPBG.ContainsKey("global"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Set Delegate clicked"], 1L);
			Debug.Log("menu-info-ico" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("PauseGameRPC: Focus lost {0} setTIme {1}"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ADDING VISUAL ON CLIENT "], 1L);
			Debug.Log("ID_CONFIRM_KICKPLAYER_TEXT" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Win"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void EBPJDMCAMAO(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("ID_CARD_DESC_BUDDY");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("ID_SQUAD"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["something is wrong - time == 0"], 0L);
			Debug.Log("getCustomProfileString" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("RESTORE PACKS = "))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["reload_grenadelauncher"], 0L);
			Debug.Log("25" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["]"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	private static void NPCAMCPFNCG()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void MNMNJBCDPOP()
	{
		GameLoginManager.Relog();
	}

	private static void FMAPGFGHNIF()
	{
		GameLoginManager.Relog();
	}

	private static void MFHHAAPEIGN()
	{
		GameLoginManager.Relog();
	}

	private static void NBNOJMBCJPI()
	{
		GameLoginManager.Relog();
	}

	public static void CDPMHEAJPCN(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("{0} / {1}", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-32), list);
	}

	public static void PALNJODGKCA(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("TopRun", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-91), list);
	}

	private static void NHGCHPEAAJF()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void BEEGMMKGHDP()
	{
		GameLoginManager.Relog();
	}

	private static void KCOPPCFJIPN()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void JNAPGNOLBEG(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log(" WITHDRAWED {0}\n");
		long num = 1L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns++;
		if (EENKJBCCPBG.ContainsKey("Id"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_GOLDPACK"], 1L);
			Debug.Log("ID_GUI_EQUIP" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("\"{0}\""))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["setViewForPopups"], 0L);
			Debug.Log("ID_CONFIRM_KICKPLAYER_TEXT" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Player"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void CGKHMPIIDAA(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("RegisterAge()");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("ID_DAILYMISSIONSUNLOCKEDHINT3TITLE"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Assignment_Completed"], 1L);
			Debug.Log("{0} {1}{2}" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("BeAdvisedConnectFacebook"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["[-]"], 1L);
			Debug.Log("ID_LEAGUEFINISHED" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_GUI_REPORTABUSE_LISTITEM6"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	private static void OJOOLKNHAFC()
	{
		GameLoginManager.Relog();
	}

	private static void LPODPCBMBHA()
	{
		GameLoginManager.Relog();
	}

	public static void AKNAFDNAJNJ(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-64):
			WarningDialog.ShowError(Localization.Localize("{0} {1}"), Localization.Localize("WarBucks"), 1112f, KFKDNPFOMEJ, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)139:
			WarningDialog.ShowError(Localization.Localize("evt11"), Localization.Localize("ID_INVITATION_VALID_FOR"), 750f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-65):
			Debug.LogError("55a90af8-a7bb-4152-a5e4-639d7488b0fb");
			WarningDialog.ShowError(Localization.Localize("weapon"), Localization.Localize("N"), 1949f, EAFJNHDMCAO, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
	}

	public static void GBPJNPIIAHA(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("ID_DAY_SMALL");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns++;
		if (EENKJBCCPBG.ContainsKey("407 MENU WEAPON SCREEN WEAPON EQUIPPED"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_GUI_DRAGCARDHERE"], 0L);
			Debug.Log("LeagueEvaluation" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("Loading - cancel clicked, will to try call disconnect"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["NO"], 1L);
			Debug.Log("IT IS" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["WarFriends"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	private static void LMFNEALOHOH()
	{
		GameLoginManager.Relog();
	}

	public static void EDNGEDFEHBB(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("ID_TUTORIAL_PROGRESS_KILLING_SCOPE", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-81), list);
	}

	private static void PPGFCPJIDJG()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void PNHJIHCEMHK()
	{
		GameLoginManager.Relog();
	}

	public static void CLCKDOJHIEO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-162):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Player {0} {1}"), Localization.Localize("offerMult"), 101f, NHGCHPEAAJF, string.Empty, JCOGJEEFLBC: true);
			break;
		case (IJEAJGCCHEF)132:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("504 MENU ARMY SCREEN UNIT SELECTED"), Localization.Localize("LeagueId"), 274f, MFHHAAPEIGN, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)190:
			Debug.LogError("Claim_Reward");
			WarningDialog.ShowError(Localization.Localize("bazooka_shoot_left"), Localization.Localize("nextGenerate"), 1649f, HPEGBLBDIEF, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
	}

	public static void BKHKENGBFJJ(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("FuseBoxx: Session Login Error, code = ", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.AcceptSquadJoinRequest, list);
	}

	private static void HPEGBLBDIEF()
	{
		GameLoginManager.Relog();
	}

	private static void CNDBOIMJLOB()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void KCKPFNBHHDM()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void MNGFMOLBAGJ()
	{
		GameLoginManager.Relog();
	}

	public static void PNHDGLHLNIE(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("UsedGold", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.EnterArena, list);
	}

	private static void HFJJOKHENHK()
	{
		GameLoginManager.Relog();
	}

	public static void LLLAOPKPPLP(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("ID_UPGRADE"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Player chose to switch accounts"], 0L);
			Debug.Log("CONFERMA" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("DogTagMax"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Starting LocalPersistenceManager!"], 0L);
			Debug.Log("Value" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_GUI_ACCEPT_PLAYER"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void PEPPNBIENJO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)(-108):
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_UNIT"), Localization.Localize("ID_WARSHOP_WARBUCKS"), 1308f, BMJIEPKAGFI, string.Empty);
			break;
		case (IJEAJGCCHEF)(-64):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-SQUADINVITE"), Localization.Localize("game-engi-progress-fill"), 1292f, HNNAFPIMAPF, string.Empty);
			break;
		case (IJEAJGCCHEF)(-164):
			Debug.LogError("[0-9.,]*");
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_ELITEUNITNAME"), Localization.Localize("ID_STAT_ACCURACY"), 870f, NKDFBOAAHEH, string.Empty);
			break;
		}
	}

	public static void ANBBPPKDDGD(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("Buy_Army_Unit", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-145), list);
	}

	private static void PPDEPBDFGCL()
	{
		GameLoginManager.Relog();
	}

	public static void MAMDLKPFBIK(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Total_Sessions");
		long num = 0L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("ID_TUTORIAL_GO_BUY_ARMY_4"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["********************************************"], 1L);
			Debug.Log("Refresh_Skirmish" + num);
			Singleton<Wallet>.instance.CKLCKHECFLH(num);
		}
		if (EENKJBCCPBG.ContainsKey("dogtag"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_WARNING_NOTENOUGHTWARCARDS"], 0L);
			Debug.Log("C0" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Time_Range_"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	private static void KFKDNPFOMEJ()
	{
		GameLoginManager.Relog();
	}

	private static void NKDFBOAAHEH()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void CCDIHPFNPOF(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("Set Delegate clicked", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.UpdateArmyPower, list);
	}

	private static void HOOMDDGPNFE()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void AJLBFJHFMHJ()
	{
		GameLoginManager.Relog();
	}

	private static void EPIKJABGGBJ()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void MLJOFHLFLPJ(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("\tNumber of games after fb login: {0}/{1}", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-60), list);
	}

	private static void CNFDDOBMACB()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void NIOEICCMNKK()
	{
		GameLoginManager.Relog();
	}

	public static void BLKLMBBGCND(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Gold");
		long num = 0L;
		long num2 = 1L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("BeanstalkServerManager.PlayerDataWasLoaded - DONE (events)"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["oo"], 0L);
			Debug.Log("0" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("CardManagerData"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_POWERBANDBOX"], 1L);
			Debug.Log("Testing Player" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_LEAVESQUAD"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void JOOLDNLHHKK(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("Seats", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-163), list);
	}

	public static void MDKFPCEJMMD(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("ID_HOU", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-147), list);
	}

	private static void KDAGGCDDHHN()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void NMIMMEOFKKD()
	{
		GameLoginManager.Relog();
	}

	private static void LOMAGLMFMAB()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void PHNAAJIHEIG(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		switch (CDLPMHEODBN)
		{
		case (IJEAJGCCHEF)189:
			WarningDialog.ShowError(Localization.Localize("Buy_Player_Customizations_Gold"), Localization.Localize("auto"), 1688f, EPIKJABGGBJ, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)54:
			WarningDialog.JACKIDKHKAI(Localization.Localize("{0}{1}"), Localization.Localize("ru"), 392f, LPODPCBMBHA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			break;
		case (IJEAJGCCHEF)(-9):
			Debug.LogError("country-egypt");
			WarningDialog.ShowError(Localization.Localize(" "), Localization.Localize("ScrapsGained"), 1217f, MNGFMOLBAGJ, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			break;
		}
	}

	private static void GAPBBAHNBHF()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void OOGPGLGDAIJ(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("Problem for max! in army/weapon stats", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-23), list);
	}

	public static void JJBBBCHOPIG(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("0", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-37), list);
	}

	private static void OPBPCDHFDFB()
	{
		GameLoginManager.Relog();
	}

	public static void GPCHBBBKHBM(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("ID_CONFIRM_NOTLEADEROFSQUAD_TEXT", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.LoginToCustomAccount, list);
	}

	private static void BCLMAMOMJBC()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void KKKAMFANBJK()
	{
		GameLoginManager.Relog();
	}

	public static void DPLPCDMFOME(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("ID_INVITEDYOUTOSQUAD", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetPlayerInfo, list);
	}

	public static void HMHABIIEAAF(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 0)
		{
			list.Add(new Tuple<string, string>("Beanstalk: OLD TOKEN!!", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-63), list);
	}

	public static void FLHHBPBPFNA(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("game-card-ico-paralyzethese", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.UniqueSquadNameSuccess, list);
	}

	public static void NJEFAAOKJHK(int OCLBKLOCFKL = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (OCLBKLOCFKL > 1)
		{
			list.Add(new Tuple<string, string>("GLM: OnDataLoaded - configurations.  is tutorial? ", OCLBKLOCFKL.ToString()));
		}
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-124), list);
	}

	private static void GJENPCEAEKN()
	{
		GameLoginManager.Relog();
	}

	private static void KPIKDCJPAPI()
	{
		GameLoginManager.Relog();
	}

	[CompilerGenerated]
	private static void IEAFAKEAEKN()
	{
		GameLoginManager.Relog();
	}

	public static void AEDIEJJGPCD(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("shield_shot");
		long num = 1L;
		long num2 = 0L;
		StatsManager.instance.arenaRuns += 0;
		if (EENKJBCCPBG.ContainsKey("ID_UNIT2TRAIN_UNIT1TRAIN"))
		{
			num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["StepId"], 1L);
			Debug.Log("value" + num);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (EENKJBCCPBG.ContainsKey("IsMaster"))
		{
			num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG[" "], 0L);
			Debug.Log("\"{0}\":" + num2);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["country-spain"], string.Empty));
		Singleton<EventTrackingManager>.instance.EnterWarArena((int)num, (int)num2, WarArena.instance.data.runs);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	private static void FKLPPIONPPA()
	{
		GameLoginManager.Relog();
	}

	private static void LBMOAPCHBGO()
	{
		GameLoginManager.Relog(showScreen: false);
	}
}
