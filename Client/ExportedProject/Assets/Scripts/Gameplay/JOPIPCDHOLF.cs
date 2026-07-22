using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JOPIPCDHOLF
{
	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	public static void HPFPGKAKPJE(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		WarArena.instance.FailedDownloadWarArena();
		Debug.LogError("207 STAGE 7 SNIPER");
		if (CDLPMHEODBN == (IJEAJGCCHEF)(-12))
		{
			string arg = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["set schedule gc check 2"], string.Empty);
			Debug.LogError(string.Format("ID_MISSION_BOSS", arg));
			WarningDialog.ShowError(Localization.Localize("TUNE Unity Test App"), Localization.Localize("Arena Lost - Scraps received = "), 1427f, LPBDDGGAPKB, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
		}
	}

	public static void NDAFGAKLLJO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		WarArena.instance.FailedDownloadWarArena();
		Debug.LogError("ID_CRATESTOLEN");
		if (CDLPMHEODBN == (IJEAJGCCHEF)179)
		{
			string arg = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_CONFIRM_ERROR"], string.Empty);
			Debug.LogError(string.Format("Agent get stucked !!! ", arg));
			WarningDialog.JACKIDKHKAI(Localization.Localize("ID_ENGLISH"), Localization.Localize("ID_SKILL"), 1353f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
		}
	}

	public static void LLCLNJKBGGM(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.LogError("On War arena endeeeed!!");
		if (EENKJBCCPBG.ContainsKey("Scraps"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Scraps"]);
			Debug.Log("Arena Lost - Scraps received = " + num);
			Singleton<MessageManager>.instance.AddMessage(new HODMKPGAPAF(num, DADIPKIKEOO: true));
			Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			Singleton<EventTrackingManager>.instance.ScrapsGained("ArenaEnded", num);
			Debug.LogFormat("Arena Expired - you gain scraps. You have {0} lives.", WarArena.instance.data.lives);
		}
		if (EENKJBCCPBG.ContainsKey("NewArena"))
		{
			WarArena.instance.LoadWarArenaConfig((JToken)EENKJBCCPBG["NewArena"]);
			Debug.Log("SHOW WAR ARENA DIALOG!!");
			string iNFLHPGMEOB = WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB;
			bool isOpened = WarArena.instance.isOpened;
			Singleton<MessageManager>.instance.AddMessage(new IFBNMHNJFPD(iNFLHPGMEOB, isOpened));
		}
	}

	public static void PNHDGLHLNIE()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ArenaId", WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB.ToString()));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.Log(WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB + " arena id");
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.WarArenaEnded, aBMLHILNNDM);
	}

	public static void PHKNCEEHBPP(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		WarArena.instance.FailedDownloadWarArena();
		Debug.LogError("Unit delivery now is : ");
		if (CDLPMHEODBN == (IJEAJGCCHEF)(-9))
		{
			string arg = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["game-kill-overtime"], string.Empty);
			Debug.LogError(string.Format("beginnersLeague", arg));
			WarningDialog.ShowError(Localization.Localize("ID_STARTERPACK"), Localization.Localize("country-philippines"), 2f, LPBDDGGAPKB, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
		}
	}

	public static void EKFIFOMNPAC()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_CONFIRM_SQUADFULL", WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB.ToString()));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.Log(WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB + "lastWeeksPlayerLeague");
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-95), aBMLHILNNDM);
	}

	[CompilerGenerated]
	private static void LOIOLIDEPDA()
	{
		GameLoginManager.Relog();
	}

	private static void BJBBEAHMPEB()
	{
		GameLoginManager.Relog();
	}

	public static void LOBLLDBEHCJ()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("{0} {1}{2}", WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB.ToString()));
		List<Tuple<string, string>> aBMLHILNNDM = list;
		Debug.Log(WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB + "x");
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-80), aBMLHILNNDM);
	}

	private static void LPBDDGGAPKB()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void GGOPFAFIDHG(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.LogError("S");
		if (EENKJBCCPBG.ContainsKey("Tutorial_Step_Complete"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ADDED WB "], 1);
			Debug.Log("ID_SLOTUPGRADE_HEAT" + num);
			Singleton<MessageManager>.instance.AddMessage(new HODMKPGAPAF(num, DADIPKIKEOO: false));
			Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			Singleton<EventTrackingManager>.instance.ScrapsGained("menu-hub-multiplayer-vipico", num);
			object[] array = new object[0];
			array[0] = WarArena.instance.data.lives;
			Debug.LogFormat("WENEEDTO", array);
		}
		if (EENKJBCCPBG.ContainsKey("ID_READYTIME"))
		{
			WarArena.instance.LoadWarArenaConfig((JToken)EENKJBCCPBG["CONFIRM"]);
			Debug.Log("ID_FACEBOOKCONNECT");
			string iNFLHPGMEOB = WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB;
			bool jHMJENBCOGE = WarArena.instance.PBGAHILNNAH();
			Singleton<MessageManager>.instance.AddMessage(new IFBNMHNJFPD(iNFLHPGMEOB, jHMJENBCOGE), LJMMJDNNIFH: true);
		}
	}

	public static void ACFGDEDKPAO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		WarArena.instance.FailedDownloadWarArena();
		Debug.LogError("errooor war arena ended!!!");
		if (CDLPMHEODBN == IJEAJGCCHEF.WarArenaNotFound)
		{
			string arg = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["WrongId"], string.Empty);
			Debug.LogError($"WarArenaId with ID {arg} not found in DB!");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WRONGARENAID"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
		}
	}

	private static void OOILNPBNGOC()
	{
		GameLoginManager.Relog(showScreen: false);
	}
}
