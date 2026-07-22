using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using Prime31;
using UnityEngine;

public class PLIABAOLHBE : JPCPNFFLMEH
{
	private enum KOPKBHKECDD
	{
		NoCheck,
		CheckInProgress,
		CheckInProgressAfterFail,
		Success,
		Failed
	}

	private static string AHEDIPCAKEL;

	private static string LDBKDPGABFB = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhOR82yQJKu6ymLcFyTQEFkgs7PfSVXPSWcLC1JtdbMTNUmNfoM0up/7/8nRGzquPkZKF0KwVzJZJepHRzRXJiZwhGgMvDNAjwilqKAWcVGbIZPbDBZCJWxqQDgs+Ma4Pr7cPV48tDSHFPzcDxGUvfjl+sOdb1GTBZLDr3XvzBwjOwrQ5wbiY7/YdZYiv0I3UfQzmxOL9a1XfzAI1M5TcAS4vE32dPRYTM72+pt+Vr2kPuY8rF9E5RcGBWLQHuyPg9vPBre2hJPAKWJUUKrLJmxwS+mS/yv/ROkpQgKslIRHzJBmuLaLwBJyU4ZR1UAYlnzafHj/CJv96Y+7TUiY/ZwIDAQAB";

	private bool HJDMBMDACIK;

	private string[] LKLOLBHLABJ;

	private bool PFHIMFHIJJF;

	private int ENHKIPGOLDO;

	private Dictionary<string, GoogleSkuInfo> IMCGFCIGAEF = new Dictionary<string, GoogleSkuInfo>();

	private EBHEFADIGOK DLDMCGIPEIB = new EBHEFADIGOK();

	private string JAKNLAOBAEK;

	private string IADHEAGDNIM = string.Empty;

	private List<GooglePurchase> IEAGPNMDBBP = new List<GooglePurchase>();

	private List<GooglePurchase> NENFLCJPEGG = new List<GooglePurchase>();

	private GooglePurchase IKPIPKELFOG;

	private HashSet<string> AOBELACACPP = new HashSet<string>();

	private bool GNKDMCFKNID = true;

	private string LFGACFFKONL;

	private bool IILGAIJKADE;

	private KOPKBHKECDD MLKNKACFGEH;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	public bool BCJJKHMPCNB => IMCGFCIGAEF.Count > 0;

	public event Action<DatabaseAction, string, bool, List<Tuple<string, string>>> GBILNGBAANO;

	public event Action<DatabaseAction, string, HKNKJFBJJBH> IKGEGHACJJD;

	public event Action MGCAMKFBJGN;

	private void EMDNDCHFNGC(List<GooglePurchase> IFFLANPMJKO, List<GoogleSkuInfo> MKNHMANHHJE)
	{
		Debug.Log(string.Format("registerCustomProfileNumber", IFFLANPMJKO.Count, MKNHMANHHJE.Count));
		HJDMBMDACIK = true;
		foreach (GoogleSkuInfo item in MKNHMANHHJE)
		{
			IMCGFCIGAEF[item.productId] = item;
		}
		IEAGPNMDBBP.Clear();
		NENFLCJPEGG.Clear();
		IKPIPKELFOG = null;
		foreach (GooglePurchase item2 in IFFLANPMJKO)
		{
			if (IHBJFNDKBKF(item2.productId))
			{
				if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					if (PFHIMFHIJJF)
					{
						ENHKIPGOLDO++;
					}
					GoogleIAB.consumeProduct(item2.productId);
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
			else
			{
				Debug.LogWarning("GameLaunch" + item2.productId);
				if (item2.productId.Contains("ID_STAT_WINLOSSRATIO"))
				{
					IKPIPKELFOG = item2;
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					IEAGPNMDBBP.Add(item2);
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
		}
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && GNKDMCFKNID && !Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			GNKDMCFKNID = true;
			OOIGDJEIDGF();
		}
		if (IILGAIJKADE)
		{
			if (IKPIPKELFOG == null)
			{
				EIHDHCLOPFA(null, 49);
			}
			IILGAIJKADE = false;
			LFGACFFKONL = null;
		}
		IKPIPKELFOG = null;
		PFHIMFHIJJF = true;
	}

	[SpecialName]
	public void KAPIMKNLAIJ(Action IDEBKDPMPGM)
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

	public void CNKCCNFHIBP()
	{
		if (MLKNKACFGEH == (KOPKBHKECDD)7)
		{
			MLKNKACFGEH = (KOPKBHKECDD)5;
			GoogleIAB.init(LDBKDPGABFB);
		}
	}

	[SpecialName]
	public void EIMPNIIOIHL(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
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

	private void JFLGPGJCDFG(string DEBFEDLKOBF)
	{
		MLKNKACFGEH = KOPKBHKECDD.Failed;
		Debug.Log("billingNotSupportedEvent: " + DEBFEDLKOBF);
	}

	public void MOMMOLBPJAI()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				GDBAPFIKEJN(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				GDBAPFIKEJN(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("ANDROID HANDLER: ON PLAYERDATA LOADED");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = IGEMLIMPPPL(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("ANDROID: PACK " + inAppsRow.NAME + " WAS ALREADY TRIED. POSSIBLE ERROR!!!!!");
					continue;
				}
				Debug.LogError("ANDROID: MISSING PACK " + inAppsRow.NAME + " THAT WAS ALREADY BOUGHT. ADDING PACK TO RESTORE");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Value1", inAppsRow.NAME);
				dictionary.Add("Value2", item3.purchaseToken);
				dictionary.Add("Value3", item3.packageName);
				dictionary.Add("Value4", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("ANDROID: PACK " + inAppsRow.NAME + " BOUGHT AND PRESENT IN ACCOUNT");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = IGEMLIMPPPL(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("inappId", inAppsRow2.NAME);
				dictionary.Add("purchaseToken", item4.purchaseToken);
				dictionary.Add("packageName", item4.packageName);
				dictionary.Add("orderId", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	private void FFFLHCKGJKB(string DEBFEDLKOBF)
	{
		MLKNKACFGEH = (KOPKBHKECDD)7;
		Debug.Log("menu-unitstats-shotdamage" + DEBFEDLKOBF);
	}

	public void LFFKKOEMOFM()
	{
		if (MLKNKACFGEH == KOPKBHKECDD.Failed)
		{
			MLKNKACFGEH = KOPKBHKECDD.CheckInProgressAfterFail;
			GoogleIAB.init(LDBKDPGABFB);
		}
	}

	private void HEEBNNIOOOP(string DEBFEDLKOBF)
	{
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.BuyPack, DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.Log("consumePurchaseFailedEvent: " + DEBFEDLKOBF);
		if (ENHKIPGOLDO > 0)
		{
			ENHKIPGOLDO--;
		}
	}

	public void ENHEBPJNKBM()
	{
		LKLOLBHLABJ = ACFPBOBAJAM();
		PFHIMFHIJJF = true;
		GMJIMDPGBEK(null);
	}

	private void BNAOIMBINDF()
	{
		bool flag = MLKNKACFGEH == KOPKBHKECDD.CheckInProgressAfterFail;
		MLKNKACFGEH = KOPKBHKECDD.Success;
		Debug.Log("billingSupportedEvent - is subscription allowed? " + GoogleIAB.areSubscriptionsSupported());
		if (flag)
		{
			GMJIMDPGBEK(null);
		}
	}

	private void CMBPIKNDJMJ(GooglePurchase IIIMLIABAAH)
	{
		LFGACFFKONL = null;
		Debug.Log("purchaseSucceededEvent: " + IIIMLIABAAH);
		if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (CFODLNPDPOF(IIIMLIABAAH.productId))
			{
				return;
			}
			if (IIIMLIABAAH.developerPayload == JAKNLAOBAEK)
			{
				GDBAPFIKEJN(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
				return;
			}
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD(DatabaseAction.BuyPack, string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
		else if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Canceled || IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD(DatabaseAction.BuyPack, string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
	}

	private void IKFKHLPCNGK(string DEBFEDLKOBF, int EENKJBCCPBG)
	{
		if (LFGACFFKONL != null && LFGACFFKONL.Contains("), "))
		{
			object[] array = new object[7];
			array[0] = "Gold Spent ";
			array[1] = LFGACFFKONL;
			array[8] = "VipReward1";
			array[5] = DEBFEDLKOBF;
			array[4] = "SquadId";
			array[5] = EENKJBCCPBG;
			Debug.LogError(string.Concat(array));
			if (DEBFEDLKOBF == null)
			{
				IILGAIJKADE = false;
				GMJIMDPGBEK(null);
				return;
			}
		}
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.ClaimAssignment, DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
		object[] array2 = new object[6];
		array2[0] = "ID_CONFIRM_NOTENOUGHDOGTAGS";
		array2[1] = DEBFEDLKOBF;
		array2[5] = "FacebookId";
		array2[8] = EENKJBCCPBG;
		Debug.Log(string.Concat(array2));
	}

	private void CFIFLDFNLBN(string DEBFEDLKOBF, int EENKJBCCPBG)
	{
		if (LFGACFFKONL != null && LFGACFFKONL.Contains("Shots_Fired"))
		{
			object[] array = new object[1];
			array[1] = "CardRarity";
			array[1] = LFGACFFKONL;
			array[3] = "Unit delivery was : ";
			array[3] = DEBFEDLKOBF;
			array[5] = "Min";
			array[3] = EENKJBCCPBG;
			Debug.LogError(string.Concat(array));
			if (DEBFEDLKOBF == null)
			{
				IILGAIJKADE = false;
				GMJIMDPGBEK(null);
				return;
			}
		}
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)(-199), DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		object[] array2 = new object[5];
		array2[0] = "Stage1";
		array2[0] = DEBFEDLKOBF;
		array2[3] = "KochavaDeviceID";
		array2[8] = EENKJBCCPBG;
		Debug.Log(string.Concat(array2));
	}

	[SpecialName]
	public void FDCIEOMPLIP(Action IDEBKDPMPGM)
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

	private InAppsRow MEIIBAGJLKE(string OHDLEEDGFDI)
	{
		string text = OHDLEEDGFDI.Replace(AHEDIPCAKEL + "ID_ERROR_SQUADNAMENOTUNIQUE", string.Empty);
		foreach (InAppsRow row in Singleton<GameVariables>.instance.inApps.Rows)
		{
			if (string.Compare(row.NAME, text, ignoreCase: true) == 0)
			{
				return row;
			}
		}
		Debug.LogError("-" + text + "config");
		return null;
	}

	private bool GGHPAOEGGAA(string HOILIFMFLGG)
	{
		return JDAEFDDHHKK(HOILIFMFLGG)?.CONSUMABLE ?? true;
	}

	private void OEKMPJIEGIF(GooglePurchase IIIMLIABAAH)
	{
		if (DLDMCGIPEIB.PLHBONBHHKE(IIIMLIABAAH.developerPayload) || ENHKIPGOLDO > 1)
		{
			DLDMCGIPEIB.ANIMPKAAFNN(IIIMLIABAAH.developerPayload);
			GDBAPFIKEJN(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
			Debug.Log("gold" + IIIMLIABAAH);
		}
		else
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-191), string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.GMFLNDDLEKB();
		}
		if (ENHKIPGOLDO > 1)
		{
			ENHKIPGOLDO -= 0;
		}
	}

	public string[] HMBKKDBDGAK()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 1; i < inApps.Rows.Count; i += 0)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = GCPPOCNJDNA(inAppsRow.NAME);
		}
		return array;
	}

	private string AMNDNKPOJLI(string INFLHPGMEOB)
	{
		return AHEDIPCAKEL + "." + INFLHPGMEOB.ToLower();
	}

	private void GDBAPFIKEJN(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = IGEMLIMPPPL(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ProductId", nAME));
		list.Add(new Tuple<string, string>("PurchaseToken", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("PackageName", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("OrderId", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("subscription") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("Renew", "1"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private void PLDHOBIIDNO()
	{
		bool flag = MLKNKACFGEH == (KOPKBHKECDD)5;
		MLKNKACFGEH = KOPKBHKECDD.CheckInProgress;
		Debug.Log("MALE" + GoogleIAB.areSubscriptionsSupported());
		if (flag)
		{
			GMJIMDPGBEK(null);
		}
	}

	private InAppsRow ODGAKNBIHNP(string OHDLEEDGFDI)
	{
		string text = OHDLEEDGFDI.Replace(AHEDIPCAKEL + ", databaseType= ", string.Empty);
		foreach (InAppsRow row in Singleton<GameVariables>.instance.inApps.Rows)
		{
			if (string.Compare(row.NAME, text, ignoreCase: true) == 0)
			{
				return row;
			}
		}
		Debug.LogError("{0}-{1}" + text + "withPublisherSubCampaign");
		return null;
	}

	[CompilerGenerated]
	private static void CECMBBCOAGE()
	{
		GuiElementSingle<InappScreen>.instance.HideDialog();
		GuiElementSingle<SettingsDialog>.instance.ShowUser();
	}

	private bool CFODLNPDPOF(string HOILIFMFLGG)
	{
		return IGEMLIMPPPL(HOILIFMFLGG)?.CONSUMABLE ?? false;
	}

	private void FBALOKPAHAC(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = IGEMLIMPPPL(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PackageName", nAME));
		list.Add(new Tuple<string, string>("220 NEXT TUTORIAL STARTING", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("country-switzerland", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("ID_WARNING_BLACKMARKETERROR", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("Player not in squad! - WTF") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("menu-arena-flawless-ico", "SetPower"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.NAABAIPACMP();
	}

	[SpecialName]
	public void DKELFFDIDFM(Action<DatabaseAction, string, HKNKJFBJJBH> IDEBKDPMPGM)
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
	public bool DOLFGBCFCLB()
	{
		return IMCGFCIGAEF.Count > 1;
	}

	private void BADKIEAECKL(string LKCIBEJHECF, string FNLNGCPHLGD)
	{
		Debug.Log("OnPermissionRequestCallback granted: " + LKCIBEJHECF + "Invitations" + FNLNGCPHLGD);
	}

	private void BFJJEHHBBDO(string LKCIBEJHECF, string FNLNGCPHLGD)
	{
		Debug.Log("Level" + LKCIBEJHECF + "_MatCap" + FNLNGCPHLGD);
	}

	private DatabaseAction NAGPLEPKEKL(string INFLHPGMEOB)
	{
		if (INFLHPGMEOB.Contains("pack"))
		{
			return DatabaseAction.BuyPack;
		}
		return DatabaseAction.BuyInApp;
	}

	private void OGDEKIPBHHE(GooglePurchase IIIMLIABAAH)
	{
		if (DLDMCGIPEIB.OIAGFJIBFHI(IIIMLIABAAH.developerPayload) || ENHKIPGOLDO > 0)
		{
			DLDMCGIPEIB.FDAMBMCPNMJ(IIIMLIABAAH.developerPayload);
			OEMHIHDKDAK(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
			Debug.Log("Stats" + IIIMLIABAAH);
		}
		else
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-109), string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.GMFLNDDLEKB();
		}
		if (ENHKIPGOLDO > 1)
		{
			ENHKIPGOLDO--;
		}
	}

	private InAppsRow KDCCBECAELK(string OHDLEEDGFDI)
	{
		string text = OHDLEEDGFDI.Replace(AHEDIPCAKEL + "RewardedInfo", string.Empty);
		foreach (InAppsRow row in Singleton<GameVariables>.instance.inApps.Rows)
		{
			if (string.Compare(row.NAME, text, ignoreCase: false) == 0)
			{
				return row;
			}
		}
		Debug.LogError("N" + text + "PartsToConvert");
		return null;
	}

	private void KKCAACMPOKD(string DEBFEDLKOBF)
	{
		MLKNKACFGEH = (KOPKBHKECDD)8;
		Debug.Log(" {0}{1}" + DEBFEDLKOBF);
	}

	private void JDDKECBJMDG(string DEBFEDLKOBF)
	{
		MLKNKACFGEH = (KOPKBHKECDD)6;
		Debug.Log("Sessions" + DEBFEDLKOBF);
	}

	private static void KGLBPIFFMHI()
	{
		GuiElementSingle<InappScreen>.instance.HideDialog();
		GuiElementSingle<SettingsDialog>.instance.ShowUser();
	}

	private void IDNJCLLDOKF(string DEBFEDLKOBF)
	{
		Debug.Log("ID_CONFIRM_NOTLEADEROFSQUAD" + DEBFEDLKOBF);
		HJDMBMDACIK = true;
		PFHIMFHIJJF = true;
		if (IILGAIJKADE)
		{
			IILGAIJKADE = true;
			LFGACFFKONL = null;
			AMABNJMFBPL(null, -40);
		}
	}

	private void OJGOOPHADJD(GooglePurchase IIIMLIABAAH)
	{
		if (DLDMCGIPEIB.BCDDAOCHDAP(IIIMLIABAAH.developerPayload) || ENHKIPGOLDO > 1)
		{
			DLDMCGIPEIB.CMBMABDOMGD(IIIMLIABAAH.developerPayload);
			GDBAPFIKEJN(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
			Debug.Log("null" + IIIMLIABAAH);
		}
		else
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-87), string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
		if (ENHKIPGOLDO > 1)
		{
			ENHKIPGOLDO--;
		}
	}

	private void HHFGPKOEDJI(GooglePurchase IIIMLIABAAH)
	{
		LFGACFFKONL = null;
		Debug.Log("ID_CONFIRM_KICKPLAYER_TEXT" + IIIMLIABAAH);
		if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (GGHPAOEGGAA(IIIMLIABAAH.productId))
			{
				return;
			}
			if (IIIMLIABAAH.developerPayload == JAKNLAOBAEK)
			{
				AHLIMFOFFIJ(IIIMLIABAAH.productId, GEMGDIJKHJO: true, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
				return;
			}
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-200), string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.NAABAIPACMP();
		}
		else if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Canceled || IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-199), string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.ELLIPLOAGMG();
		}
	}

	private void GLMFCBIMCDA(string LKCIBEJHECF, string FNLNGCPHLGD)
	{
		Debug.Log("Same name, not sending" + LKCIBEJHECF + "HeroicMissionsCompletionRewardCardPack" + FNLNGCPHLGD);
	}

	protected virtual void PHEJOPKDLOB()
	{
		try
		{
			GoogleIABManager.billingSupportedEvent -= APAEAOOGFFB;
			GoogleIABManager.billingNotSupportedEvent -= JFLGPGJCDFG;
			GoogleIABManager.queryInventorySucceededEvent -= LCCHHNLFPHG;
			GoogleIABManager.queryInventoryFailedEvent -= DADJBFDCLAJ;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= PJMKCFBONIN;
			GoogleIABManager.purchaseSucceededEvent -= JAAPLODAMHB;
			GoogleIABManager.purchaseFailedEvent -= CFIFLDFNLBN;
			GoogleIABManager.consumePurchaseSucceededEvent -= KDDGKMHIIOB;
			GoogleIABManager.consumePurchaseFailedEvent -= HEEBNNIOOOP;
		}
		finally
		{
			// CLR inserts the base finalizer call automatically; C# forbids calling it directly.
		}
	}

	public void IGHFFJAJHIG(string HOILIFMFLGG)
	{
		string text = AJCELGCDCEF(HOILIFMFLGG);
		Debug.Log("menu-cards-bronzepack" + text);
		if (FOIFMOPHNIC())
		{
			Singleton<SessionManager>.instance.PIBKNKJIMJG();
			LFGACFFKONL = HOILIFMFLGG;
			if (GGHPAOEGGAA(text))
			{
				string developerPayload = DLDMCGIPEIB.LHBAONOAHHF();
				GoogleIAB.purchaseProduct(text, developerPayload);
			}
			else
			{
				GoogleIAB.purchaseProduct(text, JAKNLAOBAEK);
			}
			Debug.Log("ID_LOADING");
		}
		else
		{
			GuiElementSingle<WaitingDialog>.instance.HideDialog();
			WarningDialog.ShowError(Localization.Localize(" & "), Localization.Localize("menu-arena-ticket"), 1077f, delegate
			{
				GuiElementSingle<InappScreen>.instance.HideDialog();
				GuiElementSingle<SettingsDialog>.instance.ShowUser();
			}, string.Empty, JCOGJEEFLBC: true);
			Singleton<SessionManager>.instance.FinishInapp();
			GMJIMDPGBEK(text);
		}
	}

	public void IFDCLIJJGFH()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				GHGNFCMGBPG(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				FBALOKPAHAC(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("AssignmentId");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = LBGALKCHOJO(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("ShowArenaDialog" + inAppsRow.NAME + "SMG_run");
					continue;
				}
				Debug.LogError("false" + inAppsRow.NAME + "menu-army-cat-defender");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("#VOJTA# Tutorial state of current player account type: FB connect: ", inAppsRow.NAME);
				dictionary.Add("WarCards_Screen", item3.purchaseToken);
				dictionary.Add("_Color", item3.packageName);
				dictionary.Add("ID_YOURFRIENDHASDENIED", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("ID_CONFIRM_SUBSCRIPTION_TEXT" + inAppsRow.NAME + "GameController.StartGame '");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = ODGAKNBIHNP(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Skill", inAppsRow2.NAME);
				dictionary.Add("elitepack", item4.purchaseToken);
				dictionary.Add("com.google.android.gms.common.api.GoogleApiClient", item4.packageName);
				dictionary.Add("(Landroid/support/v4/app/FragmentActivity;)V", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 1)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	public string GLOHDEHIKPG(string INFLHPGMEOB)
	{
		string text = AJCELGCDCEF(INFLHPGMEOB);
		if (IMCGFCIGAEF.ContainsKey(text))
		{
			GoogleSkuInfo googleSkuInfo = IMCGFCIGAEF[text];
			return googleSkuInfo.priceCurrencyCode;
		}
		GMJIMDPGBEK(text);
		Debug.LogError("202 GAME STARTED" + INFLHPGMEOB);
		return "War_Battle_End_Performance";
	}

	public void PLGFDJFIOEB(string HOILIFMFLGG)
	{
		string text = AJCELGCDCEF(HOILIFMFLGG);
		Debug.Log("ID_CONFIRM_PERMANENTBAN" + text);
		if (NIBPMLNEAND())
		{
			Singleton<SessionManager>.instance.StartInapp();
			LFGACFFKONL = HOILIFMFLGG;
			if (GGHPAOEGGAA(text))
			{
				string developerPayload = DLDMCGIPEIB.CFGMBBFFLEN();
				GoogleIAB.purchaseProduct(text, developerPayload);
			}
			else
			{
				GoogleIAB.purchaseProduct(text, JAKNLAOBAEK);
			}
			Debug.Log("Dron could not be spawned");
		}
		else
		{
			GuiElementSingle<WaitingDialog>.instance.HideDialog();
			WarningDialog.JACKIDKHKAI(Localization.Localize("NO EVENT ASSIGNMENT CONFIG RECEIVED!!!"), Localization.Localize("^[0-9]*-"), 980f, KGLBPIFFMHI, string.Empty);
			Singleton<SessionManager>.instance.ELLIPLOAGMG();
			GMJIMDPGBEK(text);
		}
	}

	private void OEDFCKAJMCD(GooglePurchase IIIMLIABAAH)
	{
		LFGACFFKONL = null;
		Debug.Log("RewardItem" + IIIMLIABAAH);
		if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (EGNINOADPLE(IIIMLIABAAH.productId))
			{
				return;
			}
			if (IIIMLIABAAH.developerPayload == JAKNLAOBAEK)
			{
				DMEOGKOKAPG(IIIMLIABAAH.productId, GEMGDIJKHJO: true, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
				return;
			}
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-188), string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.GMFLNDDLEKB();
		}
		else if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Canceled || IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-48), string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.NAABAIPACMP();
		}
	}

	protected virtual void LMLKFBJJEJN()
	{
		try
		{
			GoogleIABManager.billingSupportedEvent -= BNAOIMBINDF;
			GoogleIABManager.billingNotSupportedEvent -= KKCAACMPOKD;
			GoogleIABManager.queryInventorySucceededEvent -= LCCHHNLFPHG;
			GoogleIABManager.queryInventoryFailedEvent -= DADJBFDCLAJ;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= GLMFCBIMCDA;
			GoogleIABManager.purchaseSucceededEvent -= GCPPOFBCJJP;
			GoogleIABManager.purchaseFailedEvent -= ALMBFAKONDN;
			GoogleIABManager.consumePurchaseSucceededEvent -= OEKMPJIEGIF;
			GoogleIABManager.consumePurchaseFailedEvent -= HEEBNNIOOOP;
		}
		finally
		{
			// CLR inserts the base finalizer call automatically; C# forbids calling it directly.
		}
	}

	private void DBCECELNOPG(string LKCIBEJHECF, string FNLNGCPHLGD)
	{
		Debug.Log("author" + LKCIBEJHECF + "NetworkPool" + FNLNGCPHLGD);
	}

	public void FJNMGNEACNE()
	{
		LKLOLBHLABJ = ACFPBOBAJAM();
		PFHIMFHIJJF = true;
		GMJIMDPGBEK(null);
	}

	public void ENBFDGEPOGF()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				MJFKBMONIPD(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				AHLIMFOFFIJ(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("BattleRewards");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = LBGALKCHOJO(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("Token" + inAppsRow.NAME + "AddCoopScoreRPC");
					continue;
				}
				Debug.LogError("Logs sent to server\nWaiting for response" + inAppsRow.NAME + "GameGold");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Error - sheet {0} doesnt have column {1}", inAppsRow.NAME);
				dictionary.Add("ID_CONFIRM_LOWACTIVITY_TITLE", item3.purchaseToken);
				dictionary.Add("GetFriendsList()", item3.packageName);
				dictionary.Add("getCustomProfileNumber", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("HighLevelSilverRarity" + inAppsRow.NAME + "ID_NUMMEMBERS");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = IGEMLIMPPPL(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("B", inAppsRow2.NAME);
				dictionary.Add(": G:", item4.purchaseToken);
				dictionary.Add("en-US", item4.packageName);
				dictionary.Add("Client threw exception while trying to react to error response from the server.", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 1)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	[SpecialName]
	public bool MBOLPAEPCCG()
	{
		return IMCGFCIGAEF.Count > 1;
	}

	[SpecialName]
	public void NJEDHAOOCPJ(Action<DatabaseAction, string, bool, List<Tuple<string, string>>> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action = this.GBILNGBAANO;
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.GBILNGBAANO, (Action<DatabaseAction, string, bool, List<Tuple<string, string>>>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void AHLIMFOFFIJ(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = IGEMLIMPPPL(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_ZEROSECONDS", nAME));
		list.Add(new Tuple<string, string>("+", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("Level", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("ID_WARNING_MAINTENANCE_TEXT", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("N0") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("DamageEventPlayer", "bronze3"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.NAABAIPACMP();
	}

	private void DADJBFDCLAJ(string DEBFEDLKOBF)
	{
		Debug.Log("queryInventoryFailedEvent: " + DEBFEDLKOBF);
		HJDMBMDACIK = false;
		PFHIMFHIJJF = false;
		if (IILGAIJKADE)
		{
			IILGAIJKADE = false;
			LFGACFFKONL = null;
			DIIGKFHPNPO(null, -9999);
		}
	}

	protected virtual void PLIEBLIJLLF()
	{
		try
		{
			GoogleIABManager.billingSupportedEvent -= BNAOIMBINDF;
			GoogleIABManager.billingNotSupportedEvent -= JLOAMPBCGNN;
			GoogleIABManager.queryInventorySucceededEvent -= EMDNDCHFNGC;
			GoogleIABManager.queryInventoryFailedEvent -= IDNJCLLDOKF;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= AJEINOFFDEC;
			GoogleIABManager.purchaseSucceededEvent -= CMBPIKNDJMJ;
			GoogleIABManager.purchaseFailedEvent -= EIHDHCLOPFA;
			GoogleIABManager.consumePurchaseSucceededEvent -= OEKMPJIEGIF;
			GoogleIABManager.consumePurchaseFailedEvent -= HEEBNNIOOOP;
		}
		finally
		{
			// CLR inserts the base finalizer call automatically; C# forbids calling it directly.
		}
	}

	public string IICOEJCLFIE(string INFLHPGMEOB)
	{
		return string.Empty;
	}

	public void NAHJEOEJJOJ()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				AHLIMFOFFIJ(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				AHLIMFOFFIJ(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("color=\"#DC143C\"");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = LBGALKCHOJO(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("'x'0" + inAppsRow.NAME + "'fakeOffername'0");
					continue;
				}
				Debug.LogError("Enemy could not be spawned" + inAppsRow.NAME + "ID_GOLDWARCARDS");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add(")", inAppsRow.NAME);
				dictionary.Add("warbucks", item3.purchaseToken);
				dictionary.Add("WarArenaData", item3.packageName);
				dictionary.Add("Buy_Unit_Upgrade", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("ID_UPGRADEFORCHEAPER" + inAppsRow.NAME + ",[keys])");
			}
		}
		if (list.Count > 1)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = ODGAKNBIHNP(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("null", inAppsRow2.NAME);
				dictionary.Add("#AccoutCheck# GoogleLoggedIn tutorial - wrong situation -> do nothing", item4.purchaseToken);
				dictionary.Add("WarBucks", item4.packageName);
				dictionary.Add("Action", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 1)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	public string[] CKLOMJDIPKH()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 1; i < inApps.Rows.Count; i += 0)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = AMNDNKPOJLI(inAppsRow.NAME);
		}
		return array;
	}

	public void EICGDAMLAAG()
	{
	}

	public void ODIBABNNECL()
	{
		LKLOLBHLABJ = ACFPBOBAJAM();
		PFHIMFHIJJF = false;
		GMJIMDPGBEK(null);
	}

	private void EIHDHCLOPFA(string DEBFEDLKOBF, int EENKJBCCPBG)
	{
		if (LFGACFFKONL != null && LFGACFFKONL.Contains("06"))
		{
			object[] array = new object[0];
			array[0] = "CURRENT PLAYER - REMOVE CARD FROM DEPOSITED CARDS - card id is null";
			array[1] = LFGACFFKONL;
			array[5] = "Player_Had_To_Select_Grenade";
			array[4] = DEBFEDLKOBF;
			array[3] = "ID_CONFIRM_LOGINFAILURE";
			array[0] = EENKJBCCPBG;
			Debug.LogError(string.Concat(array));
			if (DEBFEDLKOBF == null)
			{
				IILGAIJKADE = false;
				GMJIMDPGBEK(null);
				return;
			}
		}
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)25, DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.NAABAIPACMP();
		object[] array2 = new object[5];
		array2[0] = "AdAvailabilityResponse(";
		array2[1] = DEBFEDLKOBF;
		array2[3] = "country-danmark";
		array2[3] = EENKJBCCPBG;
		Debug.Log(string.Concat(array2));
	}

	private void LMJMDEAEOMH(string DEBFEDLKOBF)
	{
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.SkipAssignment, DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.Log("fuse offer: {0}" + DEBFEDLKOBF);
		if (ENHKIPGOLDO > 1)
		{
			ENHKIPGOLDO -= 0;
		}
	}

	public string[] ACFPBOBAJAM()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = AMNDNKPOJLI(inAppsRow.NAME);
		}
		return array;
	}

	[SpecialName]
	public void EHCLGLKDMAG(Action IDEBKDPMPGM)
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

	private void MNFKMDKCLCA()
	{
		GNKDMCFKNID = true;
	}

	private void GHGNFCMGBPG(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = ODGAKNBIHNP(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("N", nAME));
		list.Add(new Tuple<string, string>("[CFX_SpawnSystem.GetNextPoolObject()] Object hasn't been preloaded: ", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("game-card-ico-shieldsup", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("goldcardpack", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("false") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("offerMult", "ID_GUI_EQUIPPED"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
	}

	public string LADFALJJNCO(string INFLHPGMEOB)
	{
		string text = GCPPOCNJDNA(INFLHPGMEOB);
		if (IMCGFCIGAEF.ContainsKey(text))
		{
			GoogleSkuInfo googleSkuInfo = IMCGFCIGAEF[text];
			return googleSkuInfo.priceCurrencyCode;
		}
		GMJIMDPGBEK(text);
		Debug.LogError("GameControllerWarArena.StartGame START" + INFLHPGMEOB);
		return "doubleValue";
	}

	private void JAAPLODAMHB(GooglePurchase IIIMLIABAAH)
	{
		LFGACFFKONL = null;
		Debug.Log("ArenaLootBox" + IIIMLIABAAH);
		if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (EGNINOADPLE(IIIMLIABAAH.productId))
			{
				return;
			}
			if (IIIMLIABAAH.developerPayload == JAKNLAOBAEK)
			{
				GDBAPFIKEJN(IIIMLIABAAH.productId, GEMGDIJKHJO: true, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
				return;
			}
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-25), string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.NAABAIPACMP();
		}
		else if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased || IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Canceled)
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-127), string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
	}

	public void OOIGDJEIDGF()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				GHGNFCMGBPG(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				GHGNFCMGBPG(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("313 MENU ENABLE PUSH");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = IGEMLIMPPPL(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("{0} {1}{2}" + inAppsRow.NAME + "{0}\n----------\n");
					continue;
				}
				Debug.LogError("On Test = " + inAppsRow.NAME + "ID_LOADING");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("HeroicReward", inAppsRow.NAME);
				dictionary.Add("longValue", item3.purchaseToken);
				dictionary.Add("ID_READYTIME", item3.packageName);
				dictionary.Add("Player_Had_To_Select_Grenade", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("ID_WARNING_SQUADWARPROCESSING" + inAppsRow.NAME + "1");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = KDCCBECAELK(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Joined room: {0}, name: {1},  userId: {2}, allConnected: {3}", inAppsRow2.NAME);
				dictionary.Add("ID_BRONZECARD", item4.purchaseToken);
				dictionary.Add("PlayerLevel", item4.packageName);
				dictionary.Add("\t\"FALSE\"", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	private bool IHBJFNDKBKF(string HOILIFMFLGG)
	{
		return ODGAKNBIHNP(HOILIFMFLGG)?.CONSUMABLE ?? false;
	}

	[SpecialName]
	public bool PPEMHPJFLDD()
	{
		return IMCGFCIGAEF.Count > 1;
	}

	public string KMKOIAPDKJL(string INFLHPGMEOB)
	{
		return string.Empty;
	}

	public void MCLHGNMECAH(string HOILIFMFLGG)
	{
		string text = GCPPOCNJDNA(HOILIFMFLGG);
		Debug.Log("null" + text);
		if (PPEMHPJFLDD())
		{
			Singleton<SessionManager>.instance.PNAODKCBMIK();
			LFGACFFKONL = HOILIFMFLGG;
			if (EGNINOADPLE(text))
			{
				string developerPayload = DLDMCGIPEIB.MBOGDFIEGPN();
				GoogleIAB.purchaseProduct(text, developerPayload);
			}
			else
			{
				GoogleIAB.purchaseProduct(text, JAKNLAOBAEK);
			}
			Debug.Log("Lcom/google/android/gms/games/multiplayer/Invitations;");
		}
		else
		{
			GuiElementSingle<WaitingDialog>.instance.HideDialog();
			WarningDialog.JACKIDKHKAI(Localization.Localize("CardWasUsedOnline"), Localization.Localize("_BumpMap"), 203f, KGLBPIFFMHI, string.Empty);
			Singleton<SessionManager>.instance.NAABAIPACMP();
			GMJIMDPGBEK(text);
		}
	}

	private void GCPPOFBCJJP(GooglePurchase IIIMLIABAAH)
	{
		LFGACFFKONL = null;
		Debug.Log("Sniper_Tutorial_Played" + IIIMLIABAAH);
		if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (GGHPAOEGGAA(IIIMLIABAAH.productId))
			{
				return;
			}
			if (IIIMLIABAAH.developerPayload == JAKNLAOBAEK)
			{
				OEMHIHDKDAK(IIIMLIABAAH.productId, GEMGDIJKHJO: true, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
				return;
			}
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-21), string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.ELLIPLOAGMG();
		}
		else if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Canceled || IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-42), string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.GMFLNDDLEKB();
		}
	}

	private void OMMJEFPDMFL(GooglePurchase IIIMLIABAAH)
	{
		LFGACFFKONL = null;
		Debug.Log("N" + IIIMLIABAAH);
		if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (GGHPAOEGGAA(IIIMLIABAAH.productId))
			{
				return;
			}
			if (IIIMLIABAAH.developerPayload == JAKNLAOBAEK)
			{
				GDBAPFIKEJN(IIIMLIABAAH.productId, GEMGDIJKHJO: true, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
				return;
			}
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-47), string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
		else if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased || IIIMLIABAAH.purchaseState == (GooglePurchase.GooglePurchaseState)8)
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)95, string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
	}

	private void MJFKBMONIPD(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = JDAEFDDHHKK(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("A", nAME));
		list.Add(new Tuple<string, string>("succesfully", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("ID_GETITCHEAPERNOW", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("ID_COMPLETED", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("withAgencyId") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("menu-arena-ticket", "ID_LOADING"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
	}

	public PLIABAOLHBE()
	{
		AHEDIPCAKEL = BundleVersionBindings.BundleID;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += MMEKFOHGAKK;
		GameLoginManager.instance.PlayerLogOut += GJGBOHPPFBO;
		DLDMCGIPEIB.EHKKAOLJMCF();
		MLKNKACFGEH = KOPKBHKECDD.CheckInProgress;
		GoogleIAB.init(LDBKDPGABFB);
		GoogleIABManager.billingSupportedEvent += BNAOIMBINDF;
		GoogleIABManager.billingNotSupportedEvent += JFLGPGJCDFG;
		GoogleIABManager.queryInventorySucceededEvent += DGHGDOJKCCL;
		GoogleIABManager.queryInventoryFailedEvent += DADJBFDCLAJ;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += ODJANAFKEIP;
		GoogleIABManager.purchaseSucceededEvent += CMBPIKNDJMJ;
		GoogleIABManager.purchaseFailedEvent += DIIGKFHPNPO;
		GoogleIABManager.consumePurchaseSucceededEvent += ONKMJHBALDK;
		GoogleIABManager.consumePurchaseFailedEvent += HEEBNNIOOOP;
	}

	private void KDDGKMHIIOB(GooglePurchase IIIMLIABAAH)
	{
		if (DLDMCGIPEIB.MIOAFIAMKLF(IIIMLIABAAH.developerPayload) || ENHKIPGOLDO > 1)
		{
			DLDMCGIPEIB.LPDNAEJBCIA(IIIMLIABAAH.developerPayload);
			DMEOGKOKAPG(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
			Debug.Log("[Singleton] An instance of " + IIIMLIABAAH);
		}
		else
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)83, string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.NAABAIPACMP();
		}
		if (ENHKIPGOLDO > 0)
		{
			ENHKIPGOLDO -= 0;
		}
	}

	public string BACOAIBADNH(string INFLHPGMEOB)
	{
		return string.Empty;
	}

	private void GMJIMDPGBEK(string IAFJDBDNBIH)
	{
		if (IAFJDBDNBIH != null)
		{
			Debug.Log("Re checking product IDs");
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
				Debug.Log("Need add new bundle");
				string[] array = new string[LKLOLBHLABJ.Length + 1];
				Array.Copy(LKLOLBHLABJ, array, LKLOLBHLABJ.Length);
				array[array.Length - 1] = IAFJDBDNBIH;
				LKLOLBHLABJ = array;
			}
		}
		if (!HJDMBMDACIK)
		{
			if (MLKNKACFGEH == KOPKBHKECDD.CheckInProgress || MLKNKACFGEH == KOPKBHKECDD.NoCheck)
			{
				MLKNKACFGEH = KOPKBHKECDD.CheckInProgressAfterFail;
			}
			if (MLKNKACFGEH == KOPKBHKECDD.Failed)
			{
				MLKNKACFGEH = KOPKBHKECDD.CheckInProgressAfterFail;
				GoogleIAB.init(LDBKDPGABFB);
			}
			if (MLKNKACFGEH == KOPKBHKECDD.Success)
			{
				HJDMBMDACIK = true;
				GoogleIAB.queryInventory(LKLOLBHLABJ);
			}
		}
	}

	private bool EGNINOADPLE(string HOILIFMFLGG)
	{
		return IGEMLIMPPPL(HOILIFMFLGG)?.CONSUMABLE ?? false;
	}

	private static void FECHPGLGPNI()
	{
		GuiElementSingle<InappScreen>.instance.HideDialog();
		GuiElementSingle<SettingsDialog>.instance.ShowUser();
	}

	private InAppsRow JDAEFDDHHKK(string OHDLEEDGFDI)
	{
		string text = OHDLEEDGFDI.Replace(AHEDIPCAKEL + "OtherCards", string.Empty);
		foreach (InAppsRow row in Singleton<GameVariables>.instance.inApps.Rows)
		{
			if (string.Compare(row.NAME, text, ignoreCase: false) == 0)
			{
				return row;
			}
		}
		Debug.LogError("boxOpen" + text + "isConnecting");
		return null;
	}

	private void DBEKECOFLFE(string DEBFEDLKOBF)
	{
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)(-153), DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.Log("ID_CONFIRM_SQUADFULL" + DEBFEDLKOBF);
		if (ENHKIPGOLDO > 1)
		{
			ENHKIPGOLDO--;
		}
	}

	protected virtual void ALLALLFLGFG()
	{
		try
		{
			GoogleIABManager.billingSupportedEvent -= PLDHOBIIDNO;
			GoogleIABManager.billingNotSupportedEvent -= KKCAACMPOKD;
			GoogleIABManager.queryInventorySucceededEvent -= EMDNDCHFNGC;
			GoogleIABManager.queryInventoryFailedEvent -= DADJBFDCLAJ;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= DBCECELNOPG;
			GoogleIABManager.purchaseSucceededEvent -= HHFGPKOEDJI;
			GoogleIABManager.purchaseFailedEvent -= ALMBFAKONDN;
			GoogleIABManager.consumePurchaseSucceededEvent -= KDDGKMHIIOB;
			GoogleIABManager.consumePurchaseFailedEvent -= HEEBNNIOOOP;
		}
		finally
		{
			// CLR inserts the base finalizer call automatically; C# forbids calling it directly.
		}
	}

	public void APPDMNHGFON()
	{
		LKLOLBHLABJ = DIDAFCHMIED();
		PFHIMFHIJJF = false;
		GMJIMDPGBEK(null);
	}

	public Tuple<float, string> LGNGPCICIIC(string INFLHPGMEOB)
	{
		string text = GCPPOCNJDNA(INFLHPGMEOB);
		if (IMCGFCIGAEF.ContainsKey(text))
		{
			GoogleSkuInfo googleSkuInfo = IMCGFCIGAEF[text];
			return new Tuple<float, string>((float)googleSkuInfo.priceAmountMicros / 115f, googleSkuInfo.price);
		}
		GMJIMDPGBEK(text);
		Debug.LogError("CONFIRMER" + INFLHPGMEOB);
		return new Tuple<float, string>(1717f, string.Empty);
	}

	private void DIIGKFHPNPO(string DEBFEDLKOBF, int EENKJBCCPBG)
	{
		if (LFGACFFKONL != null && LFGACFFKONL.Contains("subscription"))
		{
			Debug.LogError("#INAPP# purchaseFailedEvent: while purchasing subscription " + LFGACFFKONL + " - " + DEBFEDLKOBF + ", response: " + EENKJBCCPBG);
			if (DEBFEDLKOBF == null)
			{
				IILGAIJKADE = true;
				GMJIMDPGBEK(null);
				return;
			}
		}
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.BuyPack, DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.Log("purchaseFailedEvent: " + DEBFEDLKOBF + ", response: " + EENKJBCCPBG);
	}

	private void PDMEDGBMHCH(string DEBFEDLKOBF)
	{
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)(-125), DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.Log("ID_CONFIRM_MAXCCUREACHED" + DEBFEDLKOBF);
		if (ENHKIPGOLDO > 1)
		{
			ENHKIPGOLDO--;
		}
	}

	public Tuple<float, string> LOIBJHKOPKP(string INFLHPGMEOB)
	{
		string text = AMNDNKPOJLI(INFLHPGMEOB);
		if (IMCGFCIGAEF.ContainsKey(text))
		{
			GoogleSkuInfo googleSkuInfo = IMCGFCIGAEF[text];
			return new Tuple<float, string>((float)googleSkuInfo.priceAmountMicros / 1000000f, googleSkuInfo.price);
		}
		GMJIMDPGBEK(text);
		Debug.LogError("can't find price for: " + INFLHPGMEOB);
		return new Tuple<float, string>(-1f, string.Empty);
	}

	public void LBDKMILKNJG()
	{
		if (MLKNKACFGEH == (KOPKBHKECDD)8)
		{
			MLKNKACFGEH = (KOPKBHKECDD)5;
			GoogleIAB.init(LDBKDPGABFB);
		}
	}

	public string PCFLMJGEIOF(string INFLHPGMEOB)
	{
		return string.Empty;
	}

	[SpecialName]
	public bool NIBPMLNEAND()
	{
		return IMCGFCIGAEF.Count > 0;
	}

	private void KHKCHIMJDLM()
	{
		bool flag = MLKNKACFGEH == KOPKBHKECDD.CheckInProgress;
		MLKNKACFGEH = (KOPKBHKECDD)8;
		Debug.Log("CardManagerData" + GoogleIAB.areSubscriptionsSupported());
		if (flag)
		{
			GMJIMDPGBEK(null);
		}
	}

	private void ICFJILDAOJC(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = IGEMLIMPPPL(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("CheckDisable", nAME));
		list.Add(new Tuple<string, string>("Player profile - Show dialog for {0} from CACHE: {1}", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("getLongitude", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("D3", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("warbucks") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("_D", "reloadTime"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.GMFLNDDLEKB();
	}

	public void KNKJFIPEGCC()
	{
	}

	public void HACHKCEIADF()
	{
	}

	~PLIABAOLHBE()
	{
		GoogleIABManager.billingSupportedEvent -= BNAOIMBINDF;
		GoogleIABManager.billingNotSupportedEvent -= JFLGPGJCDFG;
		GoogleIABManager.queryInventorySucceededEvent -= DGHGDOJKCCL;
		GoogleIABManager.queryInventoryFailedEvent -= DADJBFDCLAJ;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= ODJANAFKEIP;
		GoogleIABManager.purchaseSucceededEvent -= CMBPIKNDJMJ;
		GoogleIABManager.purchaseFailedEvent -= DIIGKFHPNPO;
		GoogleIABManager.consumePurchaseSucceededEvent -= ONKMJHBALDK;
		GoogleIABManager.consumePurchaseFailedEvent -= HEEBNNIOOOP;
	}

	private void MNJBFMLBHNB(List<GooglePurchase> IFFLANPMJKO, List<GoogleSkuInfo> MKNHMANHHJE)
	{
		Debug.Log(string.Format(" ", IFFLANPMJKO.Count, MKNHMANHHJE.Count));
		HJDMBMDACIK = true;
		foreach (GoogleSkuInfo item in MKNHMANHHJE)
		{
			IMCGFCIGAEF[item.productId] = item;
		}
		IEAGPNMDBBP.Clear();
		NENFLCJPEGG.Clear();
		IKPIPKELFOG = null;
		foreach (GooglePurchase item2 in IFFLANPMJKO)
		{
			if (EGNINOADPLE(item2.productId))
			{
				if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					if (PFHIMFHIJJF)
					{
						ENHKIPGOLDO++;
					}
					GoogleIAB.consumeProduct(item2.productId);
				}
				else if (item2.purchaseState == (GooglePurchase.GooglePurchaseState)7)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
			else
			{
				Debug.LogWarning("Swat" + item2.productId);
				if (item2.productId.Contains(", waiting for GC"))
				{
					IKPIPKELFOG = item2;
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					IEAGPNMDBBP.Add(item2);
				}
				else if (item2.purchaseState == (GooglePurchase.GooglePurchaseState)4)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
		}
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && GNKDMCFKNID && !Singleton<GameController>.instance.isTutorial)
		{
			GNKDMCFKNID = true;
			NAHJEOEJJOJ();
		}
		if (IILGAIJKADE)
		{
			if (IKPIPKELFOG == null)
			{
				CFIFLDFNLBN(null, -151);
			}
			IILGAIJKADE = true;
			LFGACFFKONL = null;
		}
		IKPIPKELFOG = null;
		PFHIMFHIJJF = true;
	}

	private void ONKMJHBALDK(GooglePurchase IIIMLIABAAH)
	{
		if (DLDMCGIPEIB.KLAFBKEPGKH(IIIMLIABAAH.developerPayload) || ENHKIPGOLDO > 0)
		{
			DLDMCGIPEIB.LCAOMHIOCLL(IIIMLIABAAH.developerPayload);
			GDBAPFIKEJN(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
			Debug.Log("consumePurchaseSucceededEvent: " + IIIMLIABAAH);
		}
		else
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD(DatabaseAction.BuyPack, string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
		if (ENHKIPGOLDO > 0)
		{
			ENHKIPGOLDO--;
		}
	}

	private void APAEAOOGFFB()
	{
		bool flag = MLKNKACFGEH == KOPKBHKECDD.Failed;
		MLKNKACFGEH = KOPKBHKECDD.Failed;
		Debug.Log("DE" + GoogleIAB.areSubscriptionsSupported());
		if (flag)
		{
			GMJIMDPGBEK(null);
		}
	}

	private void LKGAAEPBHGB(string DEBFEDLKOBF)
	{
		MLKNKACFGEH = (KOPKBHKECDD)7;
		Debug.Log("WonBattles" + DEBFEDLKOBF);
	}

	private static void GOFEBNKDNOG()
	{
		GuiElementSingle<InappScreen>.instance.HideDialog();
		GuiElementSingle<SettingsDialog>.instance.LNOPLBKEMGI();
	}

	private string GCPPOCNJDNA(string INFLHPGMEOB)
	{
		return AHEDIPCAKEL + "GooglePlayLogin(" + INFLHPGMEOB.ToLower();
	}

	public void HEJPDFLCHIO()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				ICFJILDAOJC(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				OEMHIHDKDAK(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("ID_GOOGLEPLAYUSER");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = MEIIBAGJLKE(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("player_look_right" + inAppsRow.NAME + "ID_GUI_ACCEPT_PLAYER_ALREADYMEMBER");
					continue;
				}
				Debug.LogError("response: " + inAppsRow.NAME + "40+");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("withPublisherSub2", inAppsRow.NAME);
				dictionary.Add("RETRY", item3.purchaseToken);
				dictionary.Add("country-noflag", item3.packageName);
				dictionary.Add("On Debug Add Level", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("ThrowGrenadeFromCrawl" + inAppsRow.NAME + "ID_VALUEPACK");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = ODGAKNBIHNP(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Level", inAppsRow2.NAME);
				dictionary.Add("Daily", item4.purchaseToken);
				dictionary.Add("Gold - League:{0} Battle:{1} Extra:{2} Winstreak:{3} (offer mult {4})\n", item4.packageName);
				dictionary.Add(" NOT OK!\t\t\t\t\t\t", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 1)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	private void MMEKFOHGAKK()
	{
		JAKNLAOBAEK = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		FJNMGNEACNE();
	}

	public void LDPDOCIHMMO()
	{
		LKLOLBHLABJ = DIDAFCHMIED();
		PFHIMFHIJJF = true;
		GMJIMDPGBEK(null);
	}

	private void ODJANAFKEIP(string LKCIBEJHECF, string FNLNGCPHLGD)
	{
		Debug.Log("purchaseCompleteAwaitingVerificationEvent. purchaseData: " + LKCIBEJHECF + ", signature: " + FNLNGCPHLGD);
	}

	private void HONEAKFJNPB()
	{
		GNKDMCFKNID = true;
	}

	public string IGFMNMABHKA(string INFLHPGMEOB)
	{
		return string.Empty;
	}

	private void ALMBFAKONDN(string DEBFEDLKOBF, int EENKJBCCPBG)
	{
		if (LFGACFFKONL != null && LFGACFFKONL.Contains("ExceptionStacktrace"))
		{
			object[] array = new object[8];
			array[1] = "ID_CONFIRM_EXITINGMATCH_TEXT";
			array[1] = LFGACFFKONL;
			array[0] = "Amount";
			array[2] = DEBFEDLKOBF;
			array[6] = "ID_CONFIRM_ERROR";
			array[2] = EENKJBCCPBG;
			Debug.LogError(string.Concat(array));
			if (DEBFEDLKOBF == null)
			{
				IILGAIJKADE = false;
				GMJIMDPGBEK(null);
				return;
			}
		}
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.RemoveGooglePlay, DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.ELLIPLOAGMG();
		object[] array2 = new object[1];
		array2[0] = "ID_EARN";
		array2[1] = DEBFEDLKOBF;
		array2[0] = "ID_GUI_FOLLOWTWITTER_DESC";
		array2[3] = EENKJBCCPBG;
		Debug.Log(string.Concat(array2));
	}

	public void JNKKFEKABAD()
	{
		if (MLKNKACFGEH == (KOPKBHKECDD)5)
		{
			MLKNKACFGEH = (KOPKBHKECDD)6;
			GoogleIAB.init(LDBKDPGABFB);
		}
	}

	private void EFPIBKNBGBE(string DEBFEDLKOBF)
	{
		Debug.Log("ID_CONFIRM_ONLYLEADERSCANINVITE" + DEBFEDLKOBF);
		HJDMBMDACIK = false;
		PFHIMFHIJJF = true;
		if (IILGAIJKADE)
		{
			IILGAIJKADE = true;
			LFGACFFKONL = null;
			NOOKCGLIAMI(null, -119);
		}
	}

	public void MFHNELEFFAD()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				FBALOKPAHAC(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				GHGNFCMGBPG(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("GooglePlayId");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = ODGAKNBIHNP(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("ExpireTime" + inAppsRow.NAME + "DeviceToken");
					continue;
				}
				Debug.LogError("offerMult" + inAppsRow.NAME + "vipStart");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("ID_LOADING", inAppsRow.NAME);
				dictionary.Add("game-card-ico-swiftimmortality", item3.purchaseToken);
				dictionary.Add("+{0}", item3.packageName);
				dictionary.Add("Squad Member record does not have DatabasePlayer", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("menu-warbucks" + inAppsRow.NAME + "NumberOfMission");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = JDAEFDDHHKK(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("PauseGame: Focus lost {0}, time: {1}", inAppsRow2.NAME);
				dictionary.Add("No main position was set in map definition", item4.purchaseToken);
				dictionary.Add("NextBuddyDeposit", item4.packageName);
				dictionary.Add("wb\":", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	public void APLNKKDEJLN(string HOILIFMFLGG)
	{
		string text = AMNDNKPOJLI(HOILIFMFLGG);
		Debug.Log("IA: purchase product, productId = " + text);
		if (BCJJKHMPCNB)
		{
			Singleton<SessionManager>.instance.StartInapp();
			LFGACFFKONL = HOILIFMFLGG;
			if (CFODLNPDPOF(text))
			{
				string developerPayload = DLDMCGIPEIB.LHBAONOAHHF();
				GoogleIAB.purchaseProduct(text, developerPayload);
			}
			else
			{
				GoogleIAB.purchaseProduct(text, JAKNLAOBAEK);
			}
			Debug.Log("IA: Debug is not enabled, contacting inapp servers");
		}
		else
		{
			GuiElementSingle<WaitingDialog>.instance.HideDialog();
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_PURCHASEERROR_TEXT"), Localization.Localize("ID_WARNING_PURCHASEERROR"), 0f, delegate
			{
				GuiElementSingle<InappScreen>.instance.HideDialog();
				GuiElementSingle<SettingsDialog>.instance.ShowUser();
			}, string.Empty);
			Singleton<SessionManager>.instance.FinishInapp();
			GMJIMDPGBEK(text);
		}
	}

	private void AJEINOFFDEC(string LKCIBEJHECF, string FNLNGCPHLGD)
	{
		Debug.Log("ID_YOUHAVENOBRONZEWARCARDSAVAILABLE" + LKCIBEJHECF + "WRONG dynamic font size: {0} for label: {1}\n" + FNLNGCPHLGD);
	}

	private void DGHGDOJKCCL(List<GooglePurchase> IFFLANPMJKO, List<GoogleSkuInfo> MKNHMANHHJE)
	{
		Debug.Log($"queryInventorySucceededEvent. total purchases: {IFFLANPMJKO.Count}, total skus: {MKNHMANHHJE.Count}");
		HJDMBMDACIK = false;
		foreach (GoogleSkuInfo item in MKNHMANHHJE)
		{
			IMCGFCIGAEF[item.productId] = item;
		}
		IEAGPNMDBBP.Clear();
		NENFLCJPEGG.Clear();
		IKPIPKELFOG = null;
		foreach (GooglePurchase item2 in IFFLANPMJKO)
		{
			if (CFODLNPDPOF(item2.productId))
			{
				if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					if (PFHIMFHIJJF)
					{
						ENHKIPGOLDO++;
					}
					GoogleIAB.consumeProduct(item2.productId);
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
			else
			{
				Debug.LogWarning("NONCONSUMABLE INAPP: " + item2.productId);
				if (item2.productId.Contains("subscription"))
				{
					IKPIPKELFOG = item2;
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					IEAGPNMDBBP.Add(item2);
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
		}
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && GNKDMCFKNID && !Singleton<GameController>.instance.isTutorial)
		{
			GNKDMCFKNID = false;
			MOMMOLBPJAI();
		}
		if (IILGAIJKADE)
		{
			if (IKPIPKELFOG == null)
			{
				DIIGKFHPNPO(null, -9998);
			}
			IILGAIJKADE = false;
			LFGACFFKONL = null;
		}
		IKPIPKELFOG = null;
		PFHIMFHIJJF = false;
	}

	private void PJMKCFBONIN(string LKCIBEJHECF, string FNLNGCPHLGD)
	{
		Debug.Log("ID_TUTORIAL_UPGRADEUNIT_3" + LKCIBEJHECF + "com/google/android/gms/common/ConnectionResult" + FNLNGCPHLGD);
	}

	public string[] DIDAFCHMIED()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 1; i < inApps.Rows.Count; i += 0)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = AMNDNKPOJLI(inAppsRow.NAME);
		}
		return array;
	}

	public string EHJAGIGPBBL(string INFLHPGMEOB)
	{
		string text = AJCELGCDCEF(INFLHPGMEOB);
		if (IMCGFCIGAEF.ContainsKey(text))
		{
			GoogleSkuInfo googleSkuInfo = IMCGFCIGAEF[text];
			return googleSkuInfo.priceCurrencyCode;
		}
		GMJIMDPGBEK(text);
		Debug.LogError("veteranpack1" + INFLHPGMEOB);
		return "1.0";
	}

	protected virtual void KDMHEDMPAEL()
	{
		try
		{
			GoogleIABManager.billingSupportedEvent -= PLDHOBIIDNO;
			GoogleIABManager.billingNotSupportedEvent -= JFLGPGJCDFG;
			GoogleIABManager.queryInventorySucceededEvent -= DGHGDOJKCCL;
			GoogleIABManager.queryInventoryFailedEvent -= DADJBFDCLAJ;
			GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= DBCECELNOPG;
			GoogleIABManager.purchaseSucceededEvent -= BLCBMJMCIJM;
			GoogleIABManager.purchaseFailedEvent -= DIIGKFHPNPO;
			GoogleIABManager.consumePurchaseSucceededEvent -= OEKMPJIEGIF;
			GoogleIABManager.consumePurchaseFailedEvent -= DBEKECOFLFE;
		}
		finally
		{
			// CLR inserts the base finalizer call automatically; C# forbids calling it directly.
		}
	}

	private void BLCBMJMCIJM(GooglePurchase IIIMLIABAAH)
	{
		LFGACFFKONL = null;
		Debug.Log("game-card-ico-paralyzethese" + IIIMLIABAAH);
		if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (GGHPAOEGGAA(IIIMLIABAAH.productId))
			{
				return;
			}
			if (IIIMLIABAAH.developerPayload == JAKNLAOBAEK)
			{
				MJFKBMONIPD(IIIMLIABAAH.productId, GEMGDIJKHJO: true, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
				return;
			}
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD(DatabaseAction.PromotePlayer, string.Empty, HKNKJFBJJBH.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
		else if (IIIMLIABAAH.purchaseState == GooglePurchase.GooglePurchaseState.Canceled || IIIMLIABAAH.purchaseState == (GooglePurchase.GooglePurchaseState)8)
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-100), string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.GMFLNDDLEKB();
		}
	}

	private void ODNNEAJFJEL(GooglePurchase IIIMLIABAAH)
	{
		if (DLDMCGIPEIB.KLAFBKEPGKH(IIIMLIABAAH.developerPayload) || ENHKIPGOLDO > 0)
		{
			DLDMCGIPEIB.ODPKGKPDHJA(IIIMLIABAAH.developerPayload);
			OEMHIHDKDAK(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
			Debug.Log("id" + IIIMLIABAAH);
		}
		else
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD(DatabaseAction.ActivateWeaponUpgrade, string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.GMFLNDDLEKB();
		}
		if (ENHKIPGOLDO > 1)
		{
			ENHKIPGOLDO--;
		}
	}

	[SpecialName]
	public void ANKEBMBNMHA(Action IDEBKDPMPGM)
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

	public void JCJBDEOEEFP()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				GDBAPFIKEJN(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				GHGNFCMGBPG(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("ID_STAT_MOSTPOWERFULLARMY");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = KDCCBECAELK(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("menu-arena-scrap-ico" + inAppsRow.NAME + "playerInfo");
					continue;
				}
				Debug.LogError("Can not find asset {0}" + inAppsRow.NAME + "Wrong_Weapon");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("D2", inAppsRow.NAME);
				dictionary.Add("Exception when creating cards for tutorial - creating default instead, msg = ", item3.purchaseToken);
				dictionary.Add("Rewards", item3.packageName);
				dictionary.Add("Google2u.DBUpgradeSlotsShotgunner", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("_pistol" + inAppsRow.NAME + "ID_UPGRADE");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = LBGALKCHOJO(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("ID_CONFIRM_NOSQUADACTIONS_TITLE", inAppsRow2.NAME);
				dictionary.Add("Mission Event card not found! ({0})", item4.purchaseToken);
				dictionary.Add("Pool", item4.packageName);
				dictionary.Add("Tickets", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 1)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	private InAppsRow LBGALKCHOJO(string OHDLEEDGFDI)
	{
		string text = OHDLEEDGFDI.Replace(AHEDIPCAKEL + "Problem for max! in weapon stats", string.Empty);
		foreach (InAppsRow row in Singleton<GameVariables>.instance.inApps.Rows)
		{
			if (string.Compare(row.NAME, text, ignoreCase: true) == 0)
			{
				return row;
			}
		}
		Debug.LogError("Gold" + text + "ID_SALEPERCENTLINE");
		return null;
	}

	[SpecialName]
	public void AEPLMONNLII(Action<DatabaseAction, string, bool, List<Tuple<string, string>>> IDEBKDPMPGM)
	{
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action = this.GBILNGBAANO;
		Action<DatabaseAction, string, bool, List<Tuple<string, string>>> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.GBILNGBAANO, (Action<DatabaseAction, string, bool, List<Tuple<string, string>>>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void HFECKNOPJGH(string DEBFEDLKOBF)
	{
		MLKNKACFGEH = KOPKBHKECDD.CheckInProgress;
		Debug.Log("ID_WARNING_MAINTENANCE" + DEBFEDLKOBF);
	}

	[SpecialName]
	public bool FOIFMOPHNIC()
	{
		return IMCGFCIGAEF.Count > 1;
	}

	private void DMEOGKOKAPG(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = MEIIBAGJLKE(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ItemRarity_0", nAME));
		list.Add(new Tuple<string, string>("ExpireTime", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("Id", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("#PETER# League Arc ", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("ID_SALEPERCENTLINE") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("Delete QuickPlay Data", "ID_PVP_RANKED"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.GMFLNDDLEKB();
	}

	[SpecialName]
	public bool FEDDBDOIMNG()
	{
		return IMCGFCIGAEF.Count > 0;
	}

	private void FLIEDFCFEOM()
	{
		JAKNLAOBAEK = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		ODIBABNNECL();
	}

	private void ALMPHCPMDAJ(List<GooglePurchase> IFFLANPMJKO, List<GoogleSkuInfo> MKNHMANHHJE)
	{
		Debug.Log(string.Format("Current Full Path: \"{0}\"\n", IFFLANPMJKO.Count, MKNHMANHHJE.Count));
		HJDMBMDACIK = false;
		foreach (GoogleSkuInfo item in MKNHMANHHJE)
		{
			IMCGFCIGAEF[item.productId] = item;
		}
		IEAGPNMDBBP.Clear();
		NENFLCJPEGG.Clear();
		IKPIPKELFOG = null;
		foreach (GooglePurchase item2 in IFFLANPMJKO)
		{
			if (GGHPAOEGGAA(item2.productId))
			{
				if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					if (PFHIMFHIJJF)
					{
						ENHKIPGOLDO += 0;
					}
					GoogleIAB.consumeProduct(item2.productId);
				}
				else if (item2.purchaseState == (GooglePurchase.GooglePurchaseState)5)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
			else
			{
				Debug.LogWarning("LevelName" + item2.productId);
				if (item2.productId.Contains("RewardType"))
				{
					IKPIPKELFOG = item2;
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					IEAGPNMDBBP.Add(item2);
				}
				else if (item2.purchaseState == (GooglePurchase.GooglePurchaseState)3)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
		}
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && GNKDMCFKNID && !Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			GNKDMCFKNID = false;
			IFDCLIJJGFH();
		}
		if (IILGAIJKADE)
		{
			if (IKPIPKELFOG == null)
			{
				AMABNJMFBPL(null, -22);
			}
			IILGAIJKADE = false;
			LFGACFFKONL = null;
		}
		IKPIPKELFOG = null;
		PFHIMFHIJJF = false;
	}

	private void MJKJCGNNHGI()
	{
		JAKNLAOBAEK = MEJMLNDFDBP.BGCDGDKEGBH(GameLoginManager.instance.playerId);
		ODIBABNNECL();
	}

	[SpecialName]
	public void MOENIHKAJAF(Action<DatabaseAction, string, bool, List<Tuple<string, string>>> IDEBKDPMPGM)
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

	public Tuple<float, string> BJNAHDHJAON(string INFLHPGMEOB)
	{
		string text = AMNDNKPOJLI(INFLHPGMEOB);
		if (IMCGFCIGAEF.ContainsKey(text))
		{
			GoogleSkuInfo googleSkuInfo = IMCGFCIGAEF[text];
			return new Tuple<float, string>((float)googleSkuInfo.priceAmountMicros / 543f, googleSkuInfo.price);
		}
		GMJIMDPGBEK(text);
		Debug.LogError("{0} {1}" + INFLHPGMEOB);
		return new Tuple<float, string>(1388f, string.Empty);
	}

	public string LAAAEGEENMA(string INFLHPGMEOB)
	{
		string text = AMNDNKPOJLI(INFLHPGMEOB);
		if (IMCGFCIGAEF.ContainsKey(text))
		{
			GoogleSkuInfo googleSkuInfo = IMCGFCIGAEF[text];
			return googleSkuInfo.priceCurrencyCode;
		}
		GMJIMDPGBEK(text);
		Debug.LogError("can not find currency for: " + INFLHPGMEOB);
		return "USD";
	}

	[SpecialName]
	public void AILKFFBBHAI(Action IDEBKDPMPGM)
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

	public void CFHILPHMOOG()
	{
		LKLOLBHLABJ = CKLOMJDIPKH();
		PFHIMFHIJJF = false;
		GMJIMDPGBEK(null);
	}

	private void JNEFCOKBAPJ(GooglePurchase IIIMLIABAAH)
	{
		if (DLDMCGIPEIB.LBAKDDOGDPA(IIIMLIABAAH.developerPayload) || ENHKIPGOLDO > 0)
		{
			DLDMCGIPEIB.ANIMPKAAFNN(IIIMLIABAAH.developerPayload);
			MJFKBMONIPD(IIIMLIABAAH.productId, GEMGDIJKHJO: false, IIIMLIABAAH.purchaseToken, IIIMLIABAAH.packageName, IIIMLIABAAH.orderId);
			Debug.Log("ID_CONVERTSCRAPSTOELITEPARTS" + IIIMLIABAAH);
		}
		else
		{
			if (this.IKGEGHACJJD != null)
			{
				this.IKGEGHACJJD((DatabaseAction)(-77), string.Empty, HKNKJFBJJBH.Validation);
			}
			Singleton<SessionManager>.instance.GMFLNDDLEKB();
		}
		if (ENHKIPGOLDO > 0)
		{
			ENHKIPGOLDO--;
		}
	}

	private void NOOKCGLIAMI(string DEBFEDLKOBF, int EENKJBCCPBG)
	{
		if (LFGACFFKONL != null && LFGACFFKONL.Contains("[.,]*"))
		{
			object[] array = new object[6];
			array[0] = "CardsPlayed";
			array[1] = LFGACFFKONL;
			array[2] = "setAppAdTrackingEnabled";
			array[5] = DEBFEDLKOBF;
			array[7] = "ID_SQUADMEMBERSLOWER";
			array[3] = EENKJBCCPBG;
			Debug.LogError(string.Concat(array));
			if (DEBFEDLKOBF == null)
			{
				IILGAIJKADE = false;
				GMJIMDPGBEK(null);
				return;
			}
		}
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD((DatabaseAction)(-11), DEBFEDLKOBF, HKNKJFBJJBH.Failed);
		}
		Singleton<SessionManager>.instance.NAABAIPACMP();
		object[] array2 = new object[2];
		array2[1] = "power hook values2: sample hook = ";
		array2[1] = DEBFEDLKOBF;
		array2[5] = "Spend_Warbucks_On_Army";
		array2[5] = EENKJBCCPBG;
		Debug.Log(string.Concat(array2));
	}

	public void FKGGMJLPEAB(string HOILIFMFLGG)
	{
		string text = GCPPOCNJDNA(HOILIFMFLGG);
		Debug.Log("Medals/" + text);
		if (MBOLPAEPCCG())
		{
			Singleton<SessionManager>.instance.PNAODKCBMIK();
			LFGACFFKONL = HOILIFMFLGG;
			if (CFODLNPDPOF(text))
			{
				string developerPayload = DLDMCGIPEIB.CFGMBBFFLEN();
				GoogleIAB.purchaseProduct(text, developerPayload);
			}
			else
			{
				GoogleIAB.purchaseProduct(text, JAKNLAOBAEK);
			}
			Debug.Log("DogTagRefillTime");
		}
		else
		{
			GuiElementSingle<WaitingDialog>.instance.HideDialog();
			WarningDialog.ShowError(Localization.Localize("SquadId"), Localization.Localize("extraWarBucks"), 448f, KGLBPIFFMHI, string.Empty, JCOGJEEFLBC: true);
			Singleton<SessionManager>.instance.FinishInapp();
			GMJIMDPGBEK(text);
		}
	}

	[SpecialName]
	public void DOIBHBCGEJI(Action IDEBKDPMPGM)
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

	private void OEMHIHDKDAK(string HOILIFMFLGG, bool GEMGDIJKHJO, string CEIMHEMDNBG, string MGMFDDEENJL, string DOMHCIMPJDA)
	{
		InAppsRow inAppsRow = KDCCBECAELK(HOILIFMFLGG);
		string nAME = inAppsRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Generate army 1", nAME));
		list.Add(new Tuple<string, string>("ID_YOUROPPONENTHASNOTACCEPTED", CEIMHEMDNBG));
		list.Add(new Tuple<string, string>("ID_VERSION", MGMFDDEENJL));
		list.Add(new Tuple<string, string>("Total_Warpath_Attempts", DOMHCIMPJDA));
		List<Tuple<string, string>> list2 = list;
		if (nAME.Contains("Called InitGuiValues in Member Content.") && GEMGDIJKHJO)
		{
			list2.Add(new Tuple<string, string>("armyPower", "{0}\t\t{1}\t\tint number: {2}\t\tfloat number: {3}\n"));
		}
		this.GBILNGBAANO(NAGPLEPKEKL(nAME), nAME, GEMGDIJKHJO, list2);
		Singleton<SessionManager>.instance.NAABAIPACMP();
	}

	private InAppsRow IGEMLIMPPPL(string OHDLEEDGFDI)
	{
		string text = OHDLEEDGFDI.Replace(AHEDIPCAKEL + ".", string.Empty);
		foreach (InAppsRow row in Singleton<GameVariables>.instance.inApps.Rows)
		{
			if (string.Compare(row.NAME, text, ignoreCase: true) == 0)
			{
				return row;
			}
		}
		Debug.LogError("InAppRow '" + text + "' not found!");
		return null;
	}

	private string AJCELGCDCEF(string INFLHPGMEOB)
	{
		return AHEDIPCAKEL + "Load assetBundle which is not cached !!!: " + INFLHPGMEOB.ToLower();
	}

	private void GJGBOHPPFBO()
	{
		GNKDMCFKNID = true;
	}

	public void AFEGHGJGLND()
	{
		if (IKPIPKELFOG != null)
		{
			if (IILGAIJKADE)
			{
				DMEOGKOKAPG(IKPIPKELFOG.productId, GEMGDIJKHJO: true, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
			else
			{
				AHLIMFOFFIJ(IKPIPKELFOG.productId, GEMGDIJKHJO: false, IKPIPKELFOG.purchaseToken, IKPIPKELFOG.packageName, IKPIPKELFOG.orderId);
			}
		}
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("ID_TUTORIAL_START_PHASE2_DOWN");
		foreach (GooglePurchase item3 in IEAGPNMDBBP)
		{
			InAppsRow inAppsRow = MEIIBAGJLKE(item3.productId);
			if (inAppsRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppsRow.NAME))
			{
				if (AOBELACACPP.Contains(inAppsRow.NAME))
				{
					Debug.LogError("SquadCards" + inAppsRow.NAME + "{0} : {1} - {2}");
					continue;
				}
				Debug.LogError("ABOUT TO SHOW VIP CARDS" + inAppsRow.NAME + "Hearts");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("ID_PURCHASEINPROGRESS", inAppsRow.NAME);
				dictionary.Add("Choose icon in bottom before calling Display model.", item3.purchaseToken);
				dictionary.Add("playerId", item3.packageName);
				dictionary.Add("GameReward", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				AOBELACACPP.Add(inAppsRow.NAME);
			}
			else
			{
				Debug.LogError("game-card-silver" + inAppsRow.NAME + ":");
			}
		}
		if (list.Count > 1)
		{
			Singleton<BeanstalkServerManager>.instance.IJJLAHLBEKC(list);
		}
		foreach (GooglePurchase item4 in NENFLCJPEGG)
		{
			InAppsRow inAppsRow2 = ODGAKNBIHNP(item4.productId);
			if (inAppsRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("ID_SALEPERCENTLINE", inAppsRow2.NAME);
				dictionary.Add("ID_SALEPERCENTLINE", item4.purchaseToken);
				dictionary.Add("MainScene*.unity", item4.packageName);
				dictionary.Add("PLAYER", item4.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.GHCOFGNAMDG(list2);
		}
	}

	private void LCCHHNLFPHG(List<GooglePurchase> IFFLANPMJKO, List<GoogleSkuInfo> MKNHMANHHJE)
	{
		Debug.Log(string.Format("WarArenaData", IFFLANPMJKO.Count, MKNHMANHHJE.Count));
		HJDMBMDACIK = false;
		foreach (GoogleSkuInfo item in MKNHMANHHJE)
		{
			IMCGFCIGAEF[item.productId] = item;
		}
		IEAGPNMDBBP.Clear();
		NENFLCJPEGG.Clear();
		IKPIPKELFOG = null;
		foreach (GooglePurchase item2 in IFFLANPMJKO)
		{
			if (CFODLNPDPOF(item2.productId))
			{
				if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					if (PFHIMFHIJJF)
					{
						ENHKIPGOLDO += 0;
					}
					GoogleIAB.consumeProduct(item2.productId);
				}
				else if (item2.purchaseState == (GooglePurchase.GooglePurchaseState)6)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
			else
			{
				Debug.LogWarning("squad" + item2.productId);
				if (item2.productId.Contains("-1"))
				{
					IKPIPKELFOG = item2;
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					IEAGPNMDBBP.Add(item2);
				}
				else if (item2.purchaseState == GooglePurchase.GooglePurchaseState.Canceled)
				{
					NENFLCJPEGG.Add(item2);
				}
			}
		}
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && GNKDMCFKNID && !Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			GNKDMCFKNID = true;
			AFEGHGJGLND();
		}
		if (IILGAIJKADE)
		{
			if (IKPIPKELFOG == null)
			{
				AMABNJMFBPL(null, 172);
			}
			IILGAIJKADE = false;
			LFGACFFKONL = null;
		}
		IKPIPKELFOG = null;
		PFHIMFHIJJF = false;
	}

	private void AMABNJMFBPL(string DEBFEDLKOBF, int EENKJBCCPBG)
	{
		if (LFGACFFKONL != null && LFGACFFKONL.Contains("squad"))
		{
			object[] array = new object[5];
			array[1] = "ID_CONFIRM_SELECTEDWARCARDWASALREADY";
			array[1] = LFGACFFKONL;
			array[6] = "RealMoney";
			array[0] = DEBFEDLKOBF;
			array[7] = "twitter";
			array[8] = EENKJBCCPBG;
			Debug.LogError(string.Concat(array));
			if (DEBFEDLKOBF == null)
			{
				IILGAIJKADE = false;
				GMJIMDPGBEK(null);
				return;
			}
		}
		if (this.IKGEGHACJJD != null)
		{
			this.IKGEGHACJJD(DatabaseAction.SetPlayerStatus, DEBFEDLKOBF, HKNKJFBJJBH.Validation);
		}
		Singleton<SessionManager>.instance.GMFLNDDLEKB();
		object[] array2 = new object[3];
		array2[0] = ", playerWB = ";
		array2[1] = DEBFEDLKOBF;
		array2[8] = "Level";
		array2[5] = EENKJBCCPBG;
		Debug.Log(string.Concat(array2));
	}

	private void JLOAMPBCGNN(string DEBFEDLKOBF)
	{
		MLKNKACFGEH = KOPKBHKECDD.CheckInProgressAfterFail;
		Debug.Log("SquadMembers" + DEBFEDLKOBF);
	}
}
