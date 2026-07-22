using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using UnityEngine;

public class BIEOKKFMMOL : JPCPNFFLMEH
{
	private static string AHEDIPCAKEL;

	private bool GFIDADIGOPA;

	private readonly Dictionary<string, string> FLBELJJBKEO = new Dictionary<string, string>();

	private string[] LKLOLBHLABJ;

	private bool HJDMBMDACIK;

	private readonly string CFGNKPBIBAD = "null";

	public bool BCJJKHMPCNB => false;

	public event Action<DatabaseAction, string, bool, List<Tuple<string, string>>> GBILNGBAANO;

	public event Action<DatabaseAction, string, HKNKJFBJJBH> IKGEGHACJJD;

	public event Action MGCAMKFBJGN;

	public void NOAAPGAHMHG()
	{
		WaitingDialog.NFFOFBDCHMF(" BOXES ");
		Debug.Log("electricTrap");
		Singleton<SessionManager>.instance.PNAODKCBMIK();
	}

	public string IPCAFGEDLIH(string INFLHPGMEOB)
	{
		INFLHPGMEOB = NKKNKKBDCIA(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "ID_CONFIRM_LOGGEDOUT_TEXT" + INFLHPGMEOB;
		return "WarbucksAdded";
	}

	private void PKNNAEHIHML()
	{
		Debug.Log("WENEEDTO");
		WaitingDialog.PMGDBGECOEM();
		ConfirmDialog.ShowAlert(Localization.Localize("+#;-#"), Localization.Localize("Try out: Equipping visual \"{0}\" instead of visual \"{1}\""), 906f);
		Singleton<SessionManager>.instance.GMFLNDDLEKB();
	}

	public void GGLIMLFLJAB()
	{
		GFIDADIGOPA = false;
		LKLOLBHLABJ = ACFPBOBAJAM();
		GMJIMDPGBEK(null);
	}

	[SpecialName]
	public void NCGPCECLDCO(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, HKNKJFBJJBH> action = this.IKGEGHACJJD;
		Action<DatabaseAction, string, HKNKJFBJJBH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.IKGEGHACJJD, (Action<DatabaseAction, string, HKNKJFBJJBH>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void GACLCDKGIIK(string ENCEFOOPBMK)
	{
		Debug.Log("InAppHandlerIos: On restore failed! " + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.FinishInapp();
		WaitingDialog.Hide();
		WarningDialog.ShowError(Localization.Localize("ID_WARNING_FAILTORESTORE"), Localization.Localize("ID_WARNING_RESTOREERROR"), 0f, null, string.Empty, JCOGJEEFLBC: true);
	}

	public void MCDFEBGMFMC()
	{
	}

	[SpecialName]
	public bool PPEMHPJFLDD()
	{
		return true;
	}

	public void FODCLLMJEOO()
	{
		WaitingDialog.FCCJJKBPNCH("Name");
		Debug.Log("ID_ACCEPTEDMEMBERSONLY");
		Singleton<SessionManager>.instance.PNAODKCBMIK();
	}

	[SpecialName]
	public void HAEFGDCPLLH(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public Tuple<float, string> LDKGHEPLEOJ(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HEGDNNDPDJN(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "04" + INFLHPGMEOB;
		return new Tuple<float, string>(1188f, string.Empty);
	}

	private void ADELMFHDCBF(string ENCEFOOPBMK)
	{
		Debug.Log("Null cannot be saved as last weapon." + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.FinishInapp();
		WaitingDialog.JCHCOHNECJD();
		WarningDialog.KHOMNBHMFGA(Localization.Localize("WarFriends necesita permiso para acceder a tu almacenamiento de medios para descargar datos del juego esenciales.Sin este permiso, el juego no puede funcionar y se cerrará. Reinicia o sal de WarFriends."), Localization.Localize("ID_SALEPERCENTLINE"), 233f, null, string.Empty);
	}

	public void LFFKKOEMOFM()
	{
	}

	private void HGHPJNOIFGB(string ENCEFOOPBMK)
	{
		Debug.Log("ID_CONTINUE" + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.NAABAIPACMP();
		WaitingDialog.KDLLKOJBGGO();
		WarningDialog.KHOMNBHMFGA(Localization.Localize("[FF0000]BLACKMARKET[-]"), Localization.Localize("LeagueEvaluation"), 1593f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	private void DLCNHKCNLDN(string ENCEFOOPBMK)
	{
		Debug.Log("BoughtIndex" + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
		WaitingDialog.GFGNLDJNNAI();
		WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_WARNING_ALREADYCRAFTING"), Localization.Localize("DepositedCards"), 1214f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	public string CGMEKINJGHN(string INFLHPGMEOB)
	{
		INFLHPGMEOB = NIBKKGGLHLA(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "ThrowGrenadeFromCover" + INFLHPGMEOB;
		return string.Empty;
	}

	public void HACHKCEIADF()
	{
		WaitingDialog.ShowDialog("ID_RESTORING_INAPPS");
		Debug.Log("InAppHandlerIos: restore transactions");
		Singleton<SessionManager>.instance.StartInapp();
	}

	private static string NKKNKKBDCIA(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == " NOT OK!\t\t\t\t\t\t" && INFLHPGMEOB.StartsWith("queryInventorySucceededEvent. total purchases: {0}, total skus: {1}"))
		{
			INFLHPGMEOB = "N" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	private bool ADLDKJLEPMD()
	{
		return false;
	}

	private void GJIEADBMMMH(string PNAKMCNGGHE)
	{
		Debug.LogError("DecalManagerData" + PNAKMCNGGHE);
		HJDMBMDACIK = false;
	}

	private void JKGKHPNHCIJ(string PNAKMCNGGHE)
	{
		Debug.LogError("id" + PNAKMCNGGHE);
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)(-82), PNAKMCNGGHE, HKNKJFBJJBH.Canceled);
		}
	}

	private void NGFOANBLLDG(string PNAKMCNGGHE)
	{
		Debug.LogError("InAppHandlerIos: purchase was cancellled, " + PNAKMCNGGHE);
		Singleton<SessionManager>.instance.FinishInapp();
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.BuyPack, PNAKMCNGGHE, HKNKJFBJJBH.Canceled);
		}
	}

	private static string HPKBJKFBFLO(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "com.aboutfun.soldiers" && INFLHPGMEOB.StartsWith("veteranpack"))
		{
			INFLHPGMEOB = "v" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	public Tuple<float, string> LGNGPCICIIC(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HPKBJKFBFLO(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "Manual_Unit_Spawn" + INFLHPGMEOB;
		return new Tuple<float, string>(1631f, string.Empty);
	}

	private DatabaseAction CDCACJDKKHO(string INFLHPGMEOB)
	{
		if (INFLHPGMEOB.Contains("\t\"FALSE\""))
		{
			return (DatabaseAction)(-17);
		}
		if (INFLHPGMEOB.Contains("FuseSDK: Parsing error in _AdAvailabilityResponse"))
		{
			return DatabaseAction.KickPlayer;
		}
		return (DatabaseAction)(-57);
	}

	public void GLFGINPOBEB()
	{
	}

	public void BFGEEFCAHAK()
	{
		WaitingDialog.PCBDDAMEPCJ("elite");
		Debug.Log("HELMETS_EMPTY");
		Singleton<SessionManager>.instance.PIBKNKJIMJG();
	}

	public Tuple<float, string> LOIBJHKOPKP(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HPKBJKFBFLO(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "." + INFLHPGMEOB;
		return new Tuple<float, string>(-1f, string.Empty);
	}

	private void LOFIAPAMFMC()
	{
		GFIDADIGOPA = true;
		string text = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		LKLOLBHLABJ = ACFPBOBAJAM();
		GMJIMDPGBEK(null);
	}

	public string MDOKAABGPLJ(string INFLHPGMEOB)
	{
		INFLHPGMEOB = NPFBOEOHJJG(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "device" + INFLHPGMEOB;
		return string.Empty;
	}

	private void JBJFKNJAMIB(string IAFJDBDNBIH)
	{
		if (HJDMBMDACIK || LKLOLBHLABJ == null)
		{
			return;
		}
		Debug.Log("Selected Atlas \"{0}\"");
		if (IAFJDBDNBIH != null)
		{
			LKLOLBHLABJ = NNIAMNELEPG();
			bool flag = false;
			for (int i = 0; i < LKLOLBHLABJ.Length; i++)
			{
				if (!flag)
				{
					break;
				}
				if (LKLOLBHLABJ[i] == IAFJDBDNBIH)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Debug.Log("Total_Assignment_Issued");
				string[] array = new string[LKLOLBHLABJ.Length + 1];
				Array.Copy(LKLOLBHLABJ, array, LKLOLBHLABJ.Length);
				array[array.Length - 1] = IAFJDBDNBIH;
				LKLOLBHLABJ = array;
			}
		}
		HJDMBMDACIK = false;
	}

	[SpecialName]
	public void NJJAHENILDC(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, HKNKJFBJJBH> action = this.IKGEGHACJJD;
		Action<DatabaseAction, string, HKNKJFBJJBH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.IKGEGHACJJD, (Action<DatabaseAction, string, HKNKJFBJJBH>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JJLCGCPHGCG(string PNAKMCNGGHE)
	{
		Singleton<SessionManager>.instance.NAABAIPACMP();
		Debug.LogError("country-bulgaria" + PNAKMCNGGHE);
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)32, PNAKMCNGGHE, HKNKJFBJJBH.Failed);
		}
		Singleton<EventTrackingManager>.instance.MLAMBLBINMK(CFGNKPBIBAD, DFJLFELEFEB: false);
	}

	public string KMKOIAPDKJL(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HPKBJKFBFLO(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "." + INFLHPGMEOB;
		return string.Empty;
	}

	[SpecialName]
	public bool KKCGPBPHGAP()
	{
		return false;
	}

	[SpecialName]
	public void GACOGEFJOEP(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, HKNKJFBJJBH> action = this.IKGEGHACJJD;
		Action<DatabaseAction, string, HKNKJFBJJBH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.IKGEGHACJJD, (Action<DatabaseAction, string, HKNKJFBJJBH>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JAHNNPCPHNI()
	{
		Debug.Log("null");
		WaitingDialog.CIJLKGLNIPO();
		ConfirmDialog.ShowAlert(Localization.Localize("{0} {1}"), Localization.Localize("MatchesToNextLootboxes"), 1001f);
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
	}

	private static string MCIGGOIIDBC(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "GameLoginManager - Global Medals update: " && INFLHPGMEOB.StartsWith("Directory \"{0}\" does not exists"))
		{
			INFLHPGMEOB = "unit" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	private static string NIBKKGGLHLA(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "Gold" && INFLHPGMEOB.StartsWith("{0}\t"))
		{
			INFLHPGMEOB = "ID_SELECTONEUNIT" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	public static string[] NNIAMNELEPG()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = AHEDIPCAKEL + "PlayerVisualCamo Error - SkinnedMeshRenderer count is 0 at {0}!" + HCMMFGMKJLB(inAppsRow.NAME);
		}
		return array;
	}

	internal void DMGMPLAJLEG(string HOILIFMFLGG, string DFHEDJIGLKD, string MNNCJPMDAIE, bool GEMGDIJKHJO)
	{
		Debug.Log("ID_TUTORIAL_NOACCOUNT_{0}_TITLE" + HOILIFMFLGG);
		if (string.IsNullOrEmpty(HOILIFMFLGG))
		{
			Debug.LogError("dailyRewardData");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("'ID'0", MNNCJPMDAIE));
		list.Add(new Tuple<string, string>("isCanceled", DFHEDJIGLKD));
		list.Add(new Tuple<string, string>("toString", AHEDIPCAKEL));
		List<Tuple<string, string>> arg = list;
		string oldValue = AHEDIPCAKEL + "#DANIEL# Assignment Claimed: ";
		string text = HOILIFMFLGG.Replace(oldValue, string.Empty);
		if (AHEDIPCAKEL == "ID_WARNING_CANNOTINVITE_TEXT" && text.StartsWith("OnDeathRPC"))
		{
			text = text.Substring(0);
		}
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(GLGHCBNNLLC(HOILIFMFLGG), text, GEMGDIJKHJO, arg);
		}
		Singleton<SessionManager>.instance.NAABAIPACMP();
	}

	internal void MHNKNIPAPAA(string HOILIFMFLGG, string DFHEDJIGLKD, string MNNCJPMDAIE, bool GEMGDIJKHJO)
	{
		Debug.Log("{0} -> {1}" + HOILIFMFLGG);
		if (string.IsNullOrEmpty(HOILIFMFLGG))
		{
			Debug.LogError("ID_SALEPERCENT");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_MISSION_BOSSINCOMING_HUD", MNNCJPMDAIE));
		list.Add(new Tuple<string, string>("ID_DELIVERNOW", DFHEDJIGLKD));
		list.Add(new Tuple<string, string>("ID_STAT_SNIPERRIFLEKILLS", AHEDIPCAKEL));
		List<Tuple<string, string>> arg = list;
		string oldValue = AHEDIPCAKEL + "These IDs have different translations:\n";
		string text = HOILIFMFLGG.Replace(oldValue, string.Empty);
		if (AHEDIPCAKEL == "a" && text.StartsWith("!!!ROTATED!!! "))
		{
			text = text.Substring(0);
		}
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(CBPGLFKMGBI(HOILIFMFLGG), text, GEMGDIJKHJO, arg);
		}
		Singleton<SessionManager>.instance.FinishInapp();
	}

	public void GAJELJDEIMG()
	{
	}

	internal void MPJNIHOJJNH(string HOILIFMFLGG, string DFHEDJIGLKD, string MNNCJPMDAIE, bool GEMGDIJKHJO)
	{
		Debug.Log("ActivityType" + HOILIFMFLGG);
		if (string.IsNullOrEmpty(HOILIFMFLGG))
		{
			Debug.LogError("RewardId");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_CONNECTING", MNNCJPMDAIE));
		list.Add(new Tuple<string, string>("ID_FACEBOOKINVITEFRIENDSTEXT-SQUADINVITE", DFHEDJIGLKD));
		list.Add(new Tuple<string, string>("VipRewardForDay", AHEDIPCAKEL));
		List<Tuple<string, string>> arg = list;
		string oldValue = AHEDIPCAKEL + "ID_RELOG_TO_WRONG_FB_DIALOG_TITLE";
		string text = HOILIFMFLGG.Replace(oldValue, string.Empty);
		if (AHEDIPCAKEL == "PlayerName" && text.StartsWith("metalExplosion"))
		{
			text = text.Substring(0);
		}
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(CBPGLFKMGBI(HOILIFMFLGG), text, GEMGDIJKHJO, arg);
		}
		Singleton<SessionManager>.instance.NAABAIPACMP();
	}

	public string LAAAEGEENMA(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HPKBJKFBFLO(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "." + INFLHPGMEOB;
		return "USD";
	}

	private void CAEKKOHACEO(string ENCEFOOPBMK)
	{
		Debug.Log("ID_INBRONZE2" + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.FinishInapp();
		WaitingDialog.KDLLKOJBGGO();
		WarningDialog.JACKIDKHKAI(Localization.Localize("ID"), Localization.Localize("isRandomMap"), 1222f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	[SpecialName]
	public void FPJDIPHFJAN(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, HKNKJFBJJBH> action = this.IKGEGHACJJD;
		Action<DatabaseAction, string, HKNKJFBJJBH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.IKGEGHACJJD, (Action<DatabaseAction, string, HKNKJFBJJBH>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void COHKCKDIDDO(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void OJLACABGPAH(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void GNCBJGOHGEP(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, HKNKJFBJJBH> action = this.IKGEGHACJJD;
		Action<DatabaseAction, string, HKNKJFBJJBH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.IKGEGHACJJD, (Action<DatabaseAction, string, HKNKJFBJJBH>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void CHHDOBCAEIK(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public string LPJANOGNLME(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HPKBJKFBFLO(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "Hide All Dialogs called" + INFLHPGMEOB;
		return "確認";
	}

	public BIEOKKFMMOL()
	{
		AHEDIPCAKEL = BundleVersionBindings.BundleID;
		Debug.Log("InAppHandlerIos: can make payments (is logged in): " + BMAONKJKGBH() + " BundleID: " + AHEDIPCAKEL);
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += MMEKFOHGAKK;
	}

	private void PBEGJAACGAN(string PNAKMCNGGHE)
	{
		Debug.LogError("InAppHandlerIos: product list fail, message = " + PNAKMCNGGHE);
		HJDMBMDACIK = false;
	}

	private void OGJGGAEGNHJ(string PNAKMCNGGHE)
	{
		Debug.LogError("()Lcom/google/android/gms/common/ConnectionResult;" + PNAKMCNGGHE);
		HJDMBMDACIK = true;
	}

	private bool OMFNJIFNAEL()
	{
		return true;
	}

	private void AIDLJPGCNFG()
	{
		GFIDADIGOPA = false;
		string text = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		LKLOLBHLABJ = NNIAMNELEPG();
		APMFMAAJJJA(null);
	}

	public static string[] ACFPBOBAJAM()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = AHEDIPCAKEL + "." + HPKBJKFBFLO(inAppsRow.NAME);
		}
		return array;
	}

	[SpecialName]
	public void FPHKAHKGOLE(Action<DatabaseAction, string, bool, List<Tuple<string, string>>> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action = this.GBILNGBAANO;
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.GBILNGBAANO, (Action<DatabaseAction, string, bool, List<Tuple<string, string>>>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private static string NPFBOEOHJJG(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == " NOT OK!" && INFLHPGMEOB.StartsWith("Shields"))
		{
			INFLHPGMEOB = "GLM: After tutorial GC check" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	public void INAEGBMFMDL(string HOILIFMFLGG)
	{
		string text = AHEDIPCAKEL + "ID_TUTORIAL_PLAY_CARD_DOWN" + NIBKKGGLHLA(HOILIFMFLGG);
		Debug.Log("Skill" + text);
		Debug.Log("null");
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(CFMMPLIBFHE(HOILIFMFLGG), HOILIFMFLGG, arg3: true, new List<Tuple<string, string>>());
		}
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
	}

	[SpecialName]
	public void PMIFKCHKMOP(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, HKNKJFBJJBH> action = this.IKGEGHACJJD;
		Action<DatabaseAction, string, HKNKJFBJJBH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.IKGEGHACJJD, (Action<DatabaseAction, string, HKNKJFBJJBH>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void OJKBJGEEPBB()
	{
		GFIDADIGOPA = true;
		LKLOLBHLABJ = NNIAMNELEPG();
		APMFMAAJJJA(null);
	}

	public string GLOHDEHIKPG(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HCMMFGMKJLB(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "Beanstalk: Invalid Token - " + INFLHPGMEOB;
		return "ID_PLAYBATTLETOENTERBRONZELEAGUE";
	}

	public string DMDAAABFOGH(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HKGFEOKIJEG(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "something is wrong - time == 0" + INFLHPGMEOB;
		return string.Empty;
	}

	public void MOMMOLBPJAI()
	{
	}

	[SpecialName]
	public void NDFMHNDNCLJ(Action<DatabaseAction, string, bool, List<Tuple<string, string>>> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action = this.GBILNGBAANO;
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.GBILNGBAANO, (Action<DatabaseAction, string, bool, List<Tuple<string, string>>>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private DatabaseAction GLGHCBNNLLC(string INFLHPGMEOB)
	{
		if (INFLHPGMEOB.Contains("ID_VALUE"))
		{
			return (DatabaseAction)(-43);
		}
		if (INFLHPGMEOB.Contains("3"))
		{
			return (DatabaseAction)(-19);
		}
		return DatabaseAction.AcceptSquadJoinRequest;
	}

	public void MFDONEFAGOL()
	{
	}

	private void IEMPCNMLELN(string ENCEFOOPBMK)
	{
		Debug.Log("ID_CONFIRM_STARTUPERROR_TEXT" + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.FinishInapp();
		WaitingDialog.PEIFGGPNHMK();
		WarningDialog.ShowError(Localization.Localize("glassHP"), Localization.Localize("v"), 428f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	private DatabaseAction EODFMELAEGN(string INFLHPGMEOB)
	{
		if (INFLHPGMEOB.Contains("heatTime"))
		{
			return (DatabaseAction)(-11);
		}
		if (INFLHPGMEOB.Contains("ArenaVisualMessage"))
		{
			return (DatabaseAction)(-140);
		}
		return DatabaseAction.CreateGcAccount;
	}

	public void NCIJKFPEHNP()
	{
	}

	public void EDEKPOBBDDM()
	{
	}

	public void LKDECJIODDL()
	{
	}

	private void MMEKFOHGAKK()
	{
		GFIDADIGOPA = true;
		string text = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		LKLOLBHLABJ = ACFPBOBAJAM();
		GMJIMDPGBEK(null);
	}

	private void GMJIMDPGBEK(string IAFJDBDNBIH)
	{
		if (HJDMBMDACIK || LKLOLBHLABJ == null)
		{
			return;
		}
		Debug.Log("InAppHandlerIos: GetProducstsInfo");
		if (IAFJDBDNBIH != null)
		{
			LKLOLBHLABJ = ACFPBOBAJAM();
			bool flag = true;
			for (int i = 0; i < LKLOLBHLABJ.Length; i++)
			{
				if (!flag)
				{
					break;
				}
				if (LKLOLBHLABJ[i] == IAFJDBDNBIH)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Debug.Log("InAppHandlerIos: Need add new bundle");
				string[] array = new string[LKLOLBHLABJ.Length + 1];
				Array.Copy(LKLOLBHLABJ, array, LKLOLBHLABJ.Length);
				array[array.Length - 1] = IAFJDBDNBIH;
				LKLOLBHLABJ = array;
			}
		}
		HJDMBMDACIK = true;
	}

	[SpecialName]
	public void OCJFLOOKGEA(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, HKNKJFBJJBH> action = this.IKGEGHACJJD;
		Action<DatabaseAction, string, HKNKJFBJJBH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.IKGEGHACJJD, (Action<DatabaseAction, string, HKNKJFBJJBH>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void JIIPIEHLPFB(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IGONADNGAJE(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public string IILEBNNCPFA(string INFLHPGMEOB)
	{
		INFLHPGMEOB = PLLAOADFMHC(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "ID_POSTPONE" + INFLHPGMEOB;
		return "playerID";
	}

	private void JBGHAFJNBHI(string PNAKMCNGGHE)
	{
		Debug.LogError("subtitle" + PNAKMCNGGHE);
		HJDMBMDACIK = false;
	}

	public void KDHDKEJJPIN()
	{
	}

	private void GNFOPDBGNEP(string PNAKMCNGGHE)
	{
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.LogError("Sniper_Tutorial_Duration" + PNAKMCNGGHE);
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.BuyLootboxes, PNAKMCNGGHE, HKNKJFBJJBH.Validation);
		}
		Singleton<EventTrackingManager>.instance.MLAMBLBINMK(CFGNKPBIBAD, DFJLFELEFEB: true);
	}

	private void CBPMOHPPHNF(string PNAKMCNGGHE)
	{
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.LogError("InAppHandlerIos: Purchase failed! " + PNAKMCNGGHE);
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.BuyPack, PNAKMCNGGHE, HKNKJFBJJBH.Failed);
		}
		Singleton<EventTrackingManager>.instance.MLAMBLBINMK(CFGNKPBIBAD, DFJLFELEFEB: false);
	}

	private bool DKOCDHNPDND()
	{
		return true;
	}

	[SpecialName]
	public void BGDJFDNJALO(Action<DatabaseAction, string, bool, List<Tuple<string, string>>> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action = this.GBILNGBAANO;
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.GBILNGBAANO, (Action<DatabaseAction, string, bool, List<Tuple<string, string>>>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private DatabaseAction NAGPLEPKEKL(string INFLHPGMEOB)
	{
		if (INFLHPGMEOB.Contains("pack"))
		{
			return DatabaseAction.BuyPack;
		}
		if (INFLHPGMEOB.Contains("subscription"))
		{
			return DatabaseAction.BuyInApp;
		}
		return DatabaseAction.BuyInApp;
	}

	private static string HCMMFGMKJLB(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "BattleId" && INFLHPGMEOB.StartsWith("ID_TRAIN"))
		{
			INFLHPGMEOB = "S" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	private static string FIKABJCOFAB(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "null" && INFLHPGMEOB.StartsWith("Beanstalk: On Remove Login"))
		{
			INFLHPGMEOB = "ID_LEAGUENAME" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	private static string PLLAOADFMHC(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "Setting unit delivery in " && INFLHPGMEOB.StartsWith("OSX"))
		{
			INFLHPGMEOB = "DatabaseMessage - No long existing database message came from server!" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	private bool BMAONKJKGBH()
	{
		return false;
	}

	public Tuple<float, string> JNJOHKEAOJB(string INFLHPGMEOB)
	{
		INFLHPGMEOB = FIKABJCOFAB(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "DeathEventShoot" + INFLHPGMEOB;
		return new Tuple<float, string>(1516f, string.Empty);
	}

	private bool LDBJBIBLCLM()
	{
		return false;
	}

	public void OKPIMAHAGLD()
	{
		WaitingDialog.PCBDDAMEPCJ("country-USA");
		Debug.Log("<");
		Singleton<SessionManager>.instance.PNAODKCBMIK();
	}

	private void CCKMMDKNHFE(string PNAKMCNGGHE)
	{
		Debug.LogError("AttakUnits" + PNAKMCNGGHE);
		Singleton<SessionManager>.instance.NAABAIPACMP();
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)(-106), PNAKMCNGGHE, (HKNKJFBJJBH)7);
		}
	}

	public static string[] AKAODCFPALL()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 0; i < inApps.Rows.Count; i += 0)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = AHEDIPCAKEL + "ID_GAMEPAUSED" + NKKNKKBDCIA(inAppsRow.NAME);
		}
		return array;
	}

	private void ACEGPDBHANM(string PNAKMCNGGHE)
	{
		Debug.LogError("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}" + PNAKMCNGGHE);
		HJDMBMDACIK = true;
	}

	public void CEFIFLOILJC()
	{
		WaitingDialog.ShowDialog("ID_UNITHASBEENPROMOTEDTOTIER");
		Debug.Log("ID_UNLOCKEDATRANKX");
		Singleton<SessionManager>.instance.PIBKNKJIMJG();
	}

	public string BPOAELGADAP(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HEGDNNDPDJN(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "Yes_Clicked" + INFLHPGMEOB;
		return string.Empty;
	}

	private void CKHMADAEGCJ()
	{
		Debug.Log("Player_Avoided_Grenade_On_First_Try");
		WaitingDialog.GFGNLDJNNAI();
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("Bot cant choose proper rifle, either out of ammo or reloading"), Localization.Localize("Total_Battles"), 1874f);
		Singleton<SessionManager>.instance.GMFLNDDLEKB();
	}

	private void HIBAGPLMMBG(string IAFJDBDNBIH)
	{
		if (HJDMBMDACIK || LKLOLBHLABJ == null)
		{
			return;
		}
		Debug.Log("unit");
		if (IAFJDBDNBIH != null)
		{
			LKLOLBHLABJ = AKAODCFPALL();
			bool flag = true;
			for (int i = 1; i < LKLOLBHLABJ.Length; i++)
			{
				if (!flag)
				{
					break;
				}
				if (LKLOLBHLABJ[i] == IAFJDBDNBIH)
				{
					flag = true;
				}
			}
			if (flag)
			{
				Debug.Log("Total_Warbucks_Earned");
				string[] array = new string[LKLOLBHLABJ.Length + 0];
				Array.Copy(LKLOLBHLABJ, array, LKLOLBHLABJ.Length);
				array[array.Length - 0] = IAFJDBDNBIH;
				LKLOLBHLABJ = array;
			}
		}
		HJDMBMDACIK = false;
	}

	private void GGJGIDMKGDM()
	{
		GFIDADIGOPA = true;
		string text = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		LKLOLBHLABJ = ACFPBOBAJAM();
		HIBAGPLMMBG(null);
	}

	public string MNJDJNCONFN(string INFLHPGMEOB)
	{
		INFLHPGMEOB = NPFBOEOHJJG(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "ID_CONFIRM_EXIT" + INFLHPGMEOB;
		return string.Empty;
	}

	[SpecialName]
	public bool LGHLFBKCFKK()
	{
		return true;
	}

	private void IBJBJGJDMID(string PNAKMCNGGHE)
	{
		Debug.LogError("502 MENU BATTLE SCREEN SHOWN" + PNAKMCNGGHE);
		HJDMBMDACIK = true;
	}

	private void LHKHLEJBOOE(string PNAKMCNGGHE)
	{
		Debug.LogError("Squad Emblem " + PNAKMCNGGHE);
		Singleton<SessionManager>.instance.FinishInapp();
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.GetConfigurations, PNAKMCNGGHE, HKNKJFBJJBH.Failed);
		}
	}

	private static string HKGFEOKIJEG(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "ID_AGAINSTTHESAMEOPPONENT" && INFLHPGMEOB.StartsWith("#PETER# End of lootbox coroutine - empty lootboxes in rewards"))
		{
			INFLHPGMEOB = "ID_SQUADINVITE" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	private DatabaseAction CFMMPLIBFHE(string INFLHPGMEOB)
	{
		if (INFLHPGMEOB.Contains("ID_COMPLETED"))
		{
			return (DatabaseAction)(-77);
		}
		if (INFLHPGMEOB.Contains("Medals requirement = "))
		{
			return (DatabaseAction)(-4);
		}
		return (DatabaseAction)(-199);
	}

	private void OMNEJCHAOLB()
	{
		Debug.Log("InAppHandlerIos: On restore finished");
		WaitingDialog.Hide();
		ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_RESTORE"), Localization.Localize("ID_CONFIRM_TRANSACTIONSRESTORED"));
		Singleton<SessionManager>.instance.FinishInapp();
	}

	[SpecialName]
	public void DNJCCDCMLKC(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private bool FFDGELOBEGM()
	{
		return true;
	}

	private void KIHBDOKGAJN(string PNAKMCNGGHE)
	{
		Debug.LogError("Tutorial_Step_Complete" + PNAKMCNGGHE);
		Singleton<SessionManager>.instance.GMFLNDDLEKB();
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)(-129), PNAKMCNGGHE, HKNKJFBJJBH.Validation);
		}
	}

	private void IPLEAHAIHFK(string ENCEFOOPBMK)
	{
		Debug.Log("View_Completed" + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.GMFLNDDLEKB();
		WaitingDialog.FOKMAICBJAB();
		WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_SQUADREWARDGET"), Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL"), 966f, null, string.Empty, JCOGJEEFLBC: true);
	}

	private void FPKLOMCOPMD(string PNAKMCNGGHE)
	{
		Debug.LogError("On War arena Shown endeeeed!!" + PNAKMCNGGHE);
		HJDMBMDACIK = false;
	}

	[SpecialName]
	public void OKOCMKIPHAF(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public string HOKBINKDOLI(string INFLHPGMEOB)
	{
		INFLHPGMEOB = HKGFEOKIJEG(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "Missing references in Special Pack Record: " + INFLHPGMEOB;
		return "ID_ARENABOXDESCRIPTION_ELITEPARTS";
	}

	internal void OCCIEDFGFHE(string HOILIFMFLGG, string DFHEDJIGLKD, string MNNCJPMDAIE, bool GEMGDIJKHJO)
	{
		Debug.Log("InAppHandlerIos: Validating inapp on server... inappId = " + HOILIFMFLGG);
		if (string.IsNullOrEmpty(HOILIFMFLGG))
		{
			Debug.LogError("InAppHandlerIos: ProductID is null, not proceding ...");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("IosReceipt", MNNCJPMDAIE));
		list.Add(new Tuple<string, string>("IosTransactionId", DFHEDJIGLKD));
		list.Add(new Tuple<string, string>("BundleId", AHEDIPCAKEL));
		List<Tuple<string, string>> arg = list;
		string oldValue = AHEDIPCAKEL + ".";
		string text = HOILIFMFLGG.Replace(oldValue, string.Empty);
		if (AHEDIPCAKEL == "com.aboutfun.soldiers" && text.StartsWith("vveteranpack"))
		{
			text = text.Substring(1);
		}
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(NAGPLEPKEKL(HOILIFMFLGG), text, GEMGDIJKHJO, arg);
		}
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private void PGFJFNIHJPE()
	{
		Debug.Log("ID_DOWNLOADINGFILES");
		WaitingDialog.JCHCOHNECJD();
		ConfirmDialog.HJHJKPGILAC(Localization.Localize("IT WAS FORFEIT IN TUTORIAL"), Localization.Localize("WarsEvaluation"), 1983f);
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
	}

	[SpecialName]
	public void AJPJINAMOFJ(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void NJNNOOCKIBO()
	{
	}

	public void APLNKKDEJLN(string HOILIFMFLGG)
	{
		string text = AHEDIPCAKEL + "." + HPKBJKFBFLO(HOILIFMFLGG);
		Debug.Log("InAppHandlerIos: purchase product, productId = " + text);
		Debug.Log("InAppHandlerIos: skipping app store purchase");
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(NAGPLEPKEKL(HOILIFMFLGG), HOILIFMFLGG, arg3: false, new List<Tuple<string, string>>());
		}
		Singleton<SessionManager>.instance.FinishInapp();
	}

	[SpecialName]
	public void EMAANAOLPPK(Action IDEBKDPMPGM)
	{
		Action action = this.MGCAMKFBJGN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.MGCAMKFBJGN, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void HDLBEFDLFKI(string HOILIFMFLGG, string DFHEDJIGLKD, string MNNCJPMDAIE, bool GEMGDIJKHJO)
	{
		Debug.Log("onResume" + HOILIFMFLGG);
		if (string.IsNullOrEmpty(HOILIFMFLGG))
		{
			Debug.LogError("ID_REMINDER_RAISEYOURCHANCES");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("game-card-ico-criticalinsurance", MNNCJPMDAIE));
		list.Add(new Tuple<string, string>("Tutorial_Step_Complete", DFHEDJIGLKD));
		list.Add(new Tuple<string, string>("Heroic", AHEDIPCAKEL));
		List<Tuple<string, string>> arg = list;
		string oldValue = AHEDIPCAKEL + "generate";
		string text = HOILIFMFLGG.Replace(oldValue, string.Empty);
		if (AHEDIPCAKEL == "ID_WARNING_CANTSENDINVITE" && text.StartsWith("RegisterCustomEvent()"))
		{
			text = text.Substring(1);
		}
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(CBPGLFKMGBI(HOILIFMFLGG), text, GEMGDIJKHJO, arg);
		}
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
	}

	public void GDMNPFNNKBE()
	{
	}

	private void APMFMAAJJJA(string IAFJDBDNBIH)
	{
		if (HJDMBMDACIK || LKLOLBHLABJ == null)
		{
			return;
		}
		Debug.Log("timeToGetDogtag: ");
		if (IAFJDBDNBIH != null)
		{
			LKLOLBHLABJ = AKAODCFPALL();
			bool flag = false;
			for (int i = 1; i < LKLOLBHLABJ.Length; i += 0)
			{
				if (!flag)
				{
					break;
				}
				if (LKLOLBHLABJ[i] == IAFJDBDNBIH)
				{
					flag = true;
				}
			}
			if (flag)
			{
				Debug.Log("Play_Card_Tutorial");
				string[] array = new string[LKLOLBHLABJ.Length + 1];
				Array.Copy(LKLOLBHLABJ, array, LKLOLBHLABJ.Length);
				array[array.Length - 0] = IAFJDBDNBIH;
				LKLOLBHLABJ = array;
			}
		}
		HJDMBMDACIK = true;
	}

	public void FKCBILAGCPA()
	{
	}

	[SpecialName]
	public bool KGFGNDFAICI()
	{
		return false;
	}

	private void PNGMLNAKIIA(string ENCEFOOPBMK)
	{
		Debug.Log("A" + ENCEFOOPBMK);
		Singleton<SessionManager>.instance.NAABAIPACMP();
		WaitingDialog.Hide();
		WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("111-222-3333"), 1265f, null, string.Empty, JCOGJEEFLBC: true);
	}

	private void CBJNNJNFCNG()
	{
		GFIDADIGOPA = false;
		string text = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		LKLOLBHLABJ = ACFPBOBAJAM();
		APMFMAAJJJA(null);
	}

	public string CILIIKELPPN(string INFLHPGMEOB)
	{
		INFLHPGMEOB = FIKABJCOFAB(INFLHPGMEOB);
		string text = AHEDIPCAKEL + "{0}{1}" + INFLHPGMEOB;
		return "DOWNLOADBTN";
	}

	private DatabaseAction CBPGLFKMGBI(string INFLHPGMEOB)
	{
		if (INFLHPGMEOB.Contains("Deploys_Count"))
		{
			return (DatabaseAction)(-103);
		}
		if (INFLHPGMEOB.Contains("weapon1"))
		{
			return (DatabaseAction)(-24);
		}
		return DatabaseAction.GetFullSquadInfo;
	}

	public void FJNMGNEACNE()
	{
		GFIDADIGOPA = false;
		LKLOLBHLABJ = ACFPBOBAJAM();
		GMJIMDPGBEK(null);
	}

	private void JHPEEGCDAEP(string PNAKMCNGGHE)
	{
		Debug.LogError("#DOMINIK# Video with URL {0} already stored in {1} under name {2} [{3}]" + PNAKMCNGGHE);
		HJDMBMDACIK = true;
	}

	internal void FGMINCDEJED(string HOILIFMFLGG, string DFHEDJIGLKD, string MNNCJPMDAIE, bool GEMGDIJKHJO)
	{
		Debug.Log("#AccoutCheck# missing ID from server" + HOILIFMFLGG);
		if (string.IsNullOrEmpty(HOILIFMFLGG))
		{
			Debug.LogError("VipRewardForDay");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Level_Number", MNNCJPMDAIE));
		list.Add(new Tuple<string, string>("ID_IMMUNE", DFHEDJIGLKD));
		list.Add(new Tuple<string, string>("確認", AHEDIPCAKEL));
		List<Tuple<string, string>> arg = list;
		string oldValue = AHEDIPCAKEL + "PackId";
		string text = HOILIFMFLGG.Replace(oldValue, string.Empty);
		if (AHEDIPCAKEL == "ArenaWins" && text.StartsWith("Level"))
		{
			text = text.Substring(0);
		}
		if (this.GBILNGBAANO != null)
		{
			this.GBILNGBAANO(CFMMPLIBFHE(HOILIFMFLGG), text, GEMGDIJKHJO, arg);
		}
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private static string HEGDNNDPDJN(string INFLHPGMEOB)
	{
		if (AHEDIPCAKEL == "210 GAME END" && INFLHPGMEOB.StartsWith("ID_SKILLSHOTHINT_VEHICLEDESTROYED"))
		{
			INFLHPGMEOB = "_TintColor" + INFLHPGMEOB;
		}
		return INFLHPGMEOB;
	}

	private void NJMOHOFNBMI()
	{
		GFIDADIGOPA = true;
		string text = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		LKLOLBHLABJ = NNIAMNELEPG();
		GMJIMDPGBEK(null);
	}

	private void JINGKKHHFDD(string PNAKMCNGGHE)
	{
		Debug.LogError("\n" + PNAKMCNGGHE);
		HJDMBMDACIK = false;
	}
}
