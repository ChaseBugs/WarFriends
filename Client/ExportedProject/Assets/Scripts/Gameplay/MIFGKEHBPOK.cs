using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MIFGKEHBPOK
{
	public static Action<bool> NKBJMLEBMBH;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	public static void ADHGPFPFMHB(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("lootboxesOfferAdd");
		if (EENKJBCCPBG.ContainsKey("startResolutionForResult"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["********************************************"], 1L);
			Debug.Log("type" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("SyncShield"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_ARENATICKETSSMALL"], 1L);
			Debug.Log("Critical" + num2);
			Singleton<Wallet>.instance.KOKDKILILLK(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void BMJJAKBFAFL(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("WarBucks");
		if (EENKJBCCPBG.ContainsKey("OnPhotonJoinRoomFailed: {0}, message {1}"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_PACKXGOLD"], 1L);
			Debug.Log("Level" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("Hearts"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ok"], 0L);
			Debug.Log("Days_Since_Install" + num2);
			Singleton<Wallet>.instance.HHLLLPAANOE(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void BLKLMBBGCND(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Gold");
		if (EENKJBCCPBG.ContainsKey("Name"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_CONFIRM_ERROR"], 0L);
			Debug.Log("testingidsquadwarsend" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("About to show Unit Ready For Promotion - "))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_"], 0L);
			Debug.Log("+{0}" + num2);
			Singleton<Wallet>.instance.BCIDEFIGFBN(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	private static void PLFLAMJOLKD()
	{
		GameLoginManager.Relog();
	}

	public static void FDECGOMKMOF(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		if (CDLPMHEODBN == (IJEAJGCCHEF)97)
		{
			WarningDialog.ShowError(Localization.Localize("Password"), Localization.Localize("ID_CONFIRM_ERRORCLAIMREWARD_TEXT"), 1821f, PPGKOFBPCKH, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
		}
	}

	public static void BIMKCHFNIIM(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_RELOG_TO_FB_DIALOG_TITLE", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-69), list);
	}

	public static void LLCLNJKBGGM(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Buy Warbucks Request Success");
		if (EENKJBCCPBG.ContainsKey("GoldDeducted"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["GoldDeducted"], 0L);
			Debug.Log("Gold Spent " + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("WarbucksAdded"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["WarbucksAdded"], 0L);
			Debug.Log("Warbucks added " + num2);
			Singleton<Wallet>.instance.HHLLLPAANOE(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	private static void PPGKOFBPCKH()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	private static void DPDAKADHBBI()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void FLLPLBMOFFC(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("GLM: RegisterOrLogin -  9");
		if (EENKJBCCPBG.ContainsKey("Tutorial_Step_Complete"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG[", remove these cards = "], 0L);
			Debug.Log("ID_AVOIDRELEGATION2" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("ID_YES"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["menu-assignments-type-kill"], 1L);
			Debug.Log("CFX_SpawnSystem: There should only be one instance of CFX_SpawnSystem per Scene!" + num2);
			Singleton<Wallet>.instance.CJDCGFNCHMM(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	private static void BMJIEPKAGFI()
	{
		GameLoginManager.Relog();
	}

	public static void GLJAHAAJNEC(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("504 MENU ARMY SCREEN UNIT SELECTED");
		if (EENKJBCCPBG.ContainsKey("Mobile/Diffuse"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_BUTTON_TOPSQUADS"], 1L);
			Debug.Log("?" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("{0} -> {1}"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["setLatitude"], 0L);
			Debug.Log("Anticheat" + num2);
			Singleton<Wallet>.instance.BCIDEFIGFBN(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void JNAPGNOLBEG(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Different squads \"{0}\" and \"{1}\"\n");
		if (EENKJBCCPBG.ContainsKey("elitepack4"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["-{0}-{1}"], 1L);
			Debug.Log("ID_SLOTUPGRADE_CLIP_SIZE" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("ID_OVERTIME"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_SILVERSMALL"], 1L);
			Debug.Log("Got " + num2);
			Singleton<Wallet>.instance.CJDCGFNCHMM(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void FKDHHAIDBLI(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("217 MENU BATTLE SCREEN SHOWN", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-6), list);
	}

	public static void ANDJOHECHEI(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Map Loaded");
		if (EENKJBCCPBG.ContainsKey("ID_UNLOCKED"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Position"], 1L);
			Debug.Log("reloadTime" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("SetWeaponsUpgradeRPC"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG[" to "], 1L);
			Debug.Log("ID_GUI_TIMELIMITEDOFFER" + num2);
			Singleton<Wallet>.instance.KOKDKILILLK(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void ACFGDEDKPAO(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		if (CDLPMHEODBN == IJEAJGCCHEF.NotEnoughGoldForWarbucks)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTGOLDFORWARBUCKS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
		}
	}

	private static void KBKLGMLHJMA()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void CFHCHJLEMFB(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		if (CDLPMHEODBN == (IJEAJGCCHEF)(-94))
		{
			WarningDialog.ShowError(Localization.Localize("Wrong_Unit"), Localization.Localize("ID_CONFIRM_TUTORIALMATCH_TEXT"), 1730f, AEANMLPOOIP, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
		}
	}

	private static void AEJOLGELDJC()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void IKNDCOMKPKI(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_WARNING_PROMOTEERROR_TEXT", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-192), list);
	}

	public static void FANNAFLCNEL(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		if (CDLPMHEODBN == (IJEAJGCCHEF)(-113))
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("country-france"), Localization.Localize("ADDING WEAPON ON CLIENT"), 142f, ALJBNEEDFBI, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
		}
	}

	public static void CKDJEIHPHDO(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("LevelName", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-170), list);
	}

	[CompilerGenerated]
	private static void LOIOLIDEPDA()
	{
		GameLoginManager.Relog();
	}

	public static void DAJCCCBFDFG(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
		if (CDLPMHEODBN == (IJEAJGCCHEF)33)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Cards_Owned_Gold"), Localization.Localize("VipReward2"), 630f, BMJIEPKAGFI, string.Empty, JCOGJEEFLBC: true);
		}
	}

	private static void AEANMLPOOIP()
	{
		GameLoginManager.Relog(showScreen: false);
	}

	public static void EKFIFOMNPAC(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_GUI_EQUIPPED", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-126), list);
	}

	public static void BIJFDEPIOBB(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Enable Push Notifications - device token is the same! Not sending deviceToken", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)19, list);
	}

	private static void ALJBNEEDFBI()
	{
		GameLoginManager.Relog();
	}

	public static void DMBFOGJAMJB(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("ID_READYTIME");
		if (EENKJBCCPBG.ContainsKey("ID_OFFERACTIVE"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["WALLET - initialization WB {0}"], 1L);
			Debug.Log("#PETER# Tutorial Dialog - showing and mHideDialog is set to false" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("googlePlayLogin"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Win"], 0L);
			Debug.Log("CharacterClass" + num2);
			Singleton<Wallet>.instance.BCIDEFIGFBN(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void FHNELMHDNLA(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Beginners League:{0}  LeagueMedals: {1}  GLobalMedals: {2}");
		if (EENKJBCCPBG.ContainsKey("LootboxType"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Get Experiment Details"], 0L);
			Debug.Log("ID_EXPIRED" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("AdminName"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["FLOATVALUE"], 1L);
			Debug.Log("LevelName" + num2);
			Singleton<Wallet>.instance.BCIDEFIGFBN(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void GACNLGLMDLI(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Get Experiment Details clicked");
		if (EENKJBCCPBG.ContainsKey("open"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["DeviceToken"], 1L);
			Debug.Log("BanType" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("PlayerName"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["BlackMarketOffer"], 0L);
			Debug.Log(" - {0}" + num2);
			Singleton<Wallet>.instance.HHLLLPAANOE(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void NDHFECMKILC(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BonusHP", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-171), list);
	}

	public static void LHCJDCCBDEL(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("NOT ENOUGH GOLD FOR ARENA", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-182), list);
	}

	private static void FHBCKHPANHO()
	{
		GameLoginManager.Relog();
	}

	public static void IAJHAJOILKL(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG)
	{
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
		if (CDLPMHEODBN == (IJEAJGCCHEF)(-22))
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("' START"), Localization.Localize("ID_PLAYBATTLETOENTERBRONZELEAGUE"), 794f, FHBCKHPANHO, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
		}
	}

	public static void LDMBPFKFGBM(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("canShow");
		if (EENKJBCCPBG.ContainsKey(", action = check connection"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["hashCode"], 1L);
			Debug.Log("setCurrencyCode" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("menu-button-small"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_GUI_BUYRANDOMCARDS"], 0L);
			Debug.Log("ID_ARENASHORTCUTEVENTEND" + num2);
			Singleton<Wallet>.instance.KOKDKILILLK(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void JKBBEBNNKLF(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("Player_Level");
		if (EENKJBCCPBG.ContainsKey("menu-squad-1"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["There are {0} play windows. Max is 12. Setting 12 play windows."], 0L);
			Debug.Log("Warbucks" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("ID_CONFIRM_EXITINGCOOP_TEXT"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["()Z"], 0L);
			Debug.Log("Missing Card Pack Records in Card Menu Screen" + num2);
			Singleton<Wallet>.instance.BCIDEFIGFBN(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: false);
		}
	}

	public static void ICLJAHLDKIG(Dictionary<string, object> EENKJBCCPBG)
	{
		Debug.Log("{0:D2}:{1:D2}");
		if (EENKJBCCPBG.ContainsKey(")"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["GameLauncher.Async done"], 0L);
			Debug.Log("ShowAdForZoneID" + num);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		}
		if (EENKJBCCPBG.ContainsKey("TicketsCount"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["game-card-ico-crateblocker"], 1L);
			Debug.Log("AssetBundleManifest" + num2);
			Singleton<Wallet>.instance.CJDCGFNCHMM(num2);
		}
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH(obj: true);
		}
	}

	public static void PNHDGLHLNIE(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("WarbucksId", INFLHPGMEOB));
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.BuyWarbucksRequest, list);
	}
}
