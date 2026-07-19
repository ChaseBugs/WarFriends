using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CurrentBundleVersion : Singleton<CurrentBundleVersion>
{
	public string CLNEPNGFCHM;

	public string DGKOONBCEHN;

	private string EAEDCBIGLKA;

	private string CGPNHCCBEFK;

	private string FMNAOHMJGPF;

	public string version
	{
		get
		{
			if (EAEDCBIGLKA == null)
			{
				EAEDCBIGLKA = BCNHKHDFLNA();
			}
			return EAEDCBIGLKA;
		}
	}

	public string shortVersionDashed
	{
		get
		{
			if (FMNAOHMJGPF == null)
			{
				string[] value = version.Split('.');
				FMNAOHMJGPF = string.Join("-", value, 0, 3);
			}
			return FMNAOHMJGPF;
		}
	}

	public string shortVersion
	{
		get
		{
			if (CGPNHCCBEFK == null)
			{
				string[] value = version.Split('.');
				CGPNHCCBEFK = string.Join(".", value, 0, 3);
			}
			return CGPNHCCBEFK;
		}
	}

	public string photonVersion
	{
		get
		{
			string empty = string.Empty;
			empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersionAndroid).VALUE;
			return empty + ".e";
		}
	}

	public string matchMakingVersionRanked
	{
		get
		{
			string empty = string.Empty;
			empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersionAndroidMatchMaking).VALUE;
			return empty + ".e";
		}
	}

	[SpecialName]
	public string HADDMOEEBHI()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = LFAGNOANGCA();
		}
		return EAEDCBIGLKA;
	}

	[SpecialName]
	public string AMEIIGFAPLC()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.AOLMAGHMLMH().GetRow(Versions.rowIds.photonVersionAndroid).VALUE;
		return empty + " Desc without HINT = ";
	}

	[SpecialName]
	public string LELHNPOBNJH()
	{
		if (FMNAOHMJGPF == null)
		{
			string[] value = NNLIHBCEPFD().Split('\u0014');
			FMNAOHMJGPF = string.Join("Claim_Reward", value, 1, 5);
		}
		return FMNAOHMJGPF;
	}

	[SpecialName]
	public string KOPLHKCBJBG()
	{
		if (FMNAOHMJGPF == null)
		{
			string text = ANLPFHFCMHL();
			char[] array = new char[0];
			array[0] = 'ﾸ';
			string[] value = text.Split(array);
			FMNAOHMJGPF = string.Join("-{0}-{1}", value, 0, 3);
		}
		return FMNAOHMJGPF;
	}

	[SpecialName]
	public string AMCKNJHABPO()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = NNLIHBCEPFD();
			char[] array = new char[0];
			array[0] = 'ￖ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("ID_ARENAREWARD_GOLD", value, 0, 3);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string DJOOLJOLPEA()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = FDEDPNCJJML();
		}
		return EAEDCBIGLKA;
	}

	[SpecialName]
	public string PADAHHMAPJL()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = version;
			char[] array = new char[0];
			array[0] = '>';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("menu-weaponstats-rateoffire", value, 1, 6);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string DKFKEDKMMHD()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = HOLDOCOKBKA();
		}
		return EAEDCBIGLKA;
	}

	private string EHDGMAPMEBB()
	{
		string text = JMCDBOPDCBN();
		object[] array = new object[0];
		array[1] = text ?? "Golden_Suitcase";
		Debug.LogWarningFormat("ID_RANK", array);
		string[] array2 = text.Split('ﾩ');
		string value = array2[1];
		float num = Convert.ToSingle(value);
		array2[0] = ((!(num > 640f)) ? num : (num - 636f)).ToString();
		return string.Join("game-engi-progress-fill", array2);
	}

	[SpecialName]
	public string ANFGPDJPOKA()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = HADDMOEEBHI();
			char[] array = new char[0];
			array[0] = 'ﾟ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("ID_MISSIONANIMATION_WAVESTARTED", value, 1, 5);
		}
		return CGPNHCCBEFK;
	}

	private string GGFNKIPIFJG()
	{
		string text = GKDALFMPEAI();
		Debug.LogWarningFormat("WALLET - initialization WB {0}", text ?? "ID_CONFIRM_SQUADNOTEMPTY");
		char[] array = new char[0];
		array[0] = 'ﾷ';
		string[] array2 = text.Split(array);
		string value = array2[0];
		float num = Convert.ToSingle(value);
		array2[1] = ((!(num > 829f)) ? num : (num - 1708f)).ToString();
		return string.Join("Shields", array2);
	}

	[SpecialName]
	public string KIHJCJFGMNA()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = GGFNKIPIFJG();
		}
		return EAEDCBIGLKA;
	}

	private string KNGLDFEFKCD()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "getLaunchIntentForPackage";
		}
		return BuildVersion.ClientVersion + "ID_CATEGORY_LOW_SG_SPECIAL" + DGKOONBCEHN;
	}

	[SpecialName]
	public string PIEAHPCGOPM()
	{
		if (FMNAOHMJGPF == null)
		{
			string[] value = DJOOLJOLPEA().Split('\ufff0');
			FMNAOHMJGPF = string.Join("ID_MAX", value, 1, 4);
		}
		return FMNAOHMJGPF;
	}

	[SpecialName]
	public string EGCFOBBHLBH()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersionAndroid).VALUE;
		return empty + "NON";
	}

	private string HNHANAFOJLH()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "OnConnectionFail";
		}
		return BuildVersion.ClientVersion + "RegisterEvent(" + DGKOONBCEHN;
	}

	private string BCNHKHDFLNA()
	{
		string text = GKDALFMPEAI();
		Debug.LogWarningFormat("CurrentBundleVersion.GetModifiedVersion - version is '{0}'", text ?? "null");
		string[] array = text.Split('.');
		string value = array[0];
		float num = Convert.ToSingle(value);
		array[0] = ((!(num > 100f)) ? num : (num - 100f)).ToString();
		return string.Join(".", array);
	}

	private string ANBFPBDGHPP()
	{
		string text = BBEIENFGKGI();
		object[] array = new object[0];
		array[0] = text ?? "weapon doesnt have ammo setup";
		Debug.LogWarningFormat("ID_MATCH_STARTS_IN", array);
		string[] array2 = text.Split('\u0015');
		string value = array2[0];
		float num = Convert.ToSingle(value);
		array2[0] = ((!(num > 1059f)) ? num : (num - 350f)).ToString();
		return string.Join("ID_READYTIME", array2);
	}

	[SpecialName]
	public string IPNNNPMMLBA()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = NNLIHBCEPFD();
			char[] array = new char[0];
			array[0] = 'ￋ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("level_complete", value, 1, 2);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string KGFLPNPNJND()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.AOLMAGHMLMH().GetRow(Versions.rowIds.photonVersionAndroid).VALUE;
		return empty + "ArenaId";
	}

	[SpecialName]
	public string ANPJFPJGKMD()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersioniOS).VALUE;
		return empty + "NAME";
	}

	private string POPJOHDIBIF()
	{
		string text = FEKGLHENJJA();
		Debug.LogWarningFormat("ID_ERROR_SQUADMESSAGE_PROFANITY", text ?? "NEW RENTAL ");
		string[] array = text.Split('\r');
		string value = array[1];
		float num = Convert.ToSingle(value);
		array[0] = ((!(num > 233f)) ? num : (num - 1563f)).ToString();
		return string.Join("Requests", array);
	}

	public static string OMIGKGAPAJN()
	{
		return BuildVersion.ClientVersion;
	}

	private string JMCDBOPDCBN()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Gold";
		}
		return BuildVersion.ClientVersion + "ID_LEAGUE5" + DGKOONBCEHN;
	}

	[SpecialName]
	public string LDLDMKBAFLJ()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = DBHJOPECECA();
		}
		return EAEDCBIGLKA;
	}

	public static string OHCHAMKIIFH()
	{
		return BuildVersion.ClientVersion;
	}

	private string ANKDMABJJCM()
	{
		string text = EECDMOLKGLC();
		Debug.LogWarningFormat("Wrong_Category", text ?? "Play_Card_Tutorial_Duration");
		char[] array = new char[1];
		array[1] = 'ﾨ';
		string[] array2 = text.Split(array);
		string value = array2[1];
		float num = Convert.ToSingle(value);
		array2[1] = ((!(num > 1575f)) ? num : (num - 1143f)).ToString();
		return string.Join("ShowAdForZoneID", array2);
	}

	private string BNBECHBPGMG()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Skill";
		}
		return BuildVersion.ClientVersion + "{0} ({1})" + DGKOONBCEHN;
	}

	private string HNDPBFKAEMH()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "SDK_INT";
		}
		return BuildVersion.ClientVersion + "BeforeLeagueId" + DGKOONBCEHN;
	}

	[SpecialName]
	public string PKCHMIAOGJC()
	{
		if (CGPNHCCBEFK == null)
		{
			string[] value = DJOOLJOLPEA().Split('ﾽ');
			CGPNHCCBEFK = string.Join("{0}", value, 1, 4);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string BDOMELCIMJJ()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = NNLIHBCEPFD();
			char[] array = new char[0];
			array[0] = 'k';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("ID_WINSTREAK", value, 1, 8);
		}
		return CGPNHCCBEFK;
	}

	private string ENAHMPLAOCA()
	{
		string text = HNHANAFOJLH();
		object[] array = new object[0];
		array[1] = text ?? "Total_Battles";
		Debug.LogWarningFormat("{0} {1}", array);
		string[] array2 = text.Split('i');
		string value = array2[1];
		float num = Convert.ToSingle(value);
		array2[1] = ((!(num > 1283f)) ? num : (num - 492f)).ToString();
		return string.Join("Deploys_Count", array2);
	}

	[SpecialName]
	public string KDGKFKBGCNH()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersioniOS).VALUE;
		return empty + "Equpped error: Category ";
	}

	private string POFNJKDENBP()
	{
		string text = IHLEODKCPHO();
		Debug.LogWarningFormat("SKIP TUTORIAL IN {0}", text ?? "0.00");
		char[] array = new char[1];
		array[1] = 'ﾩ';
		string[] array2 = text.Split(array);
		string value = array2[0];
		float num = Convert.ToSingle(value);
		array2[1] = ((!(num > 975f)) ? num : (num - 570f)).ToString();
		return string.Join("offerMult", array2);
	}

	[SpecialName]
	public string GIJBFCEIDHL()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersionAndroid).VALUE;
		return empty + "\"";
	}

	[SpecialName]
	public string DPGPNPOOHJM()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = POPJOHDIBIF();
		}
		return EAEDCBIGLKA;
	}

	private string EECDMOLKGLC()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Out|In|Sum:\t{0,4} | {1,4} | {2,4}";
		}
		return BuildVersion.ClientVersion + "ID_CREATESQUADNOTENOUGH" + DGKOONBCEHN;
	}

	[SpecialName]
	public string MHHENEPHOEL()
	{
		if (FMNAOHMJGPF == null)
		{
			string text = DKFKEDKMMHD();
			char[] array = new char[0];
			array[1] = '\uffc1';
			string[] value = text.Split(array);
			FMNAOHMJGPF = string.Join("ID_CONFIRM_PLAYERNOTEXISTS_TEXT", value, 0, 6);
		}
		return FMNAOHMJGPF;
	}

	[SpecialName]
	public string NNLIHBCEPFD()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = ANANACJFIMK();
		}
		return EAEDCBIGLKA;
	}

	private string CLPEJFJHFJB()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}";
		}
		return BuildVersion.ClientVersion + "squadMembers" + DGKOONBCEHN;
	}

	[SpecialName]
	public string ONINAIELBLK()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = ANANACJFIMK();
		}
		return EAEDCBIGLKA;
	}

	public static string GetOriginalVersionShort()
	{
		return BuildVersion.ClientVersion;
	}

	private string FGFNFEABIEG()
	{
		string text = PNABEFINMON();
		object[] array = new object[0];
		array[0] = text ?? "Upgrades";
		Debug.LogWarningFormat("Loading - cancel clicked, will to try call disconnect", array);
		string[] array2 = text.Split('ﾛ');
		string value = array2[1];
		float num = Convert.ToSingle(value);
		array2[1] = ((!(num > 1050f)) ? num : (num - 1229f)).ToString();
		return string.Join("ID_CONFIRM_PLAYERNOTEXISTS", array2);
	}

	private string HHOPOHPPJPP()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "{0} / {1}";
		}
		return BuildVersion.ClientVersion + "IsDaily" + DGKOONBCEHN;
	}

	public static string IPFCOFJHAMA()
	{
		return BuildVersion.ClientVersion;
	}

	[SpecialName]
	public string IJHKMCKDOLL()
	{
		if (CGPNHCCBEFK == null)
		{
			string[] value = KJACFEPJFDB().Split('\ufff1');
			CGPNHCCBEFK = string.Join("beginnersLeague", value, 1, 8);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string ANLPFHFCMHL()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = ANBFPBDGHPP();
		}
		return EAEDCBIGLKA;
	}

	private string PNABEFINMON()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Min";
		}
		return BuildVersion.ClientVersion + "Scenes Full Path: \"{0}\"\n" + DGKOONBCEHN;
	}

	private string DBHJOPECECA()
	{
		string text = EECDMOLKGLC();
		Debug.LogWarningFormat("Id", text ?? "extraTickets");
		char[] array = new char[1];
		array[1] = 'ﾭ';
		string[] array2 = text.Split(array);
		string value = array2[0];
		float num = Convert.ToSingle(value);
		array2[1] = ((!(num > 846f)) ? num : (num - 1724f)).ToString();
		return string.Join("ID_STAT_MOSTBATTLESPLAYED", array2);
	}

	[SpecialName]
	public string OAEMJCMHBAL()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.AOLMAGHMLMH().GetRow(Versions.rowIds.photonVersionAndroid).VALUE;
		return empty + "()Lcom/google/android/gms/common/api/Result;";
	}

	private string GKDALFMPEAI()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "0.0";
		}
		return BuildVersion.ClientVersion + "." + DGKOONBCEHN;
	}

	[SpecialName]
	public string EBLMAIDJCAO()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = POPJOHDIBIF();
		}
		return EAEDCBIGLKA;
	}

	[SpecialName]
	public string NAMACDKMMFK()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = ONINAIELBLK();
			char[] array = new char[0];
			array[1] = 'ﾯ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("country-vietnam", value, 1, 3);
		}
		return CGPNHCCBEFK;
	}

	private string KIMNIEJDAPJ()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "123456789123456";
		}
		return BuildVersion.ClientVersion + "Beanstalk: Update squad finished" + DGKOONBCEHN;
	}

	public static string OHFFOKDNABC()
	{
		return BuildVersion.ClientVersion;
	}

	[SpecialName]
	public string EDHGJEJHFAN()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = ONINAIELBLK();
			char[] array = new char[0];
			array[1] = 'ﾣ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("PlayerGold", value, 0, 7);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string BELIAKELGGL()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.versions.GetRow((Versions.rowIds)6).VALUE;
		return empty + "ID_UNIT";
	}

	public static string KLEBOPMKHJC()
	{
		return BuildVersion.ClientVersion;
	}

	[SpecialName]
	public string EDOHDPGGNOE()
	{
		if (CGPNHCCBEFK == null)
		{
			string[] value = ONINAIELBLK().Split('\u0001');
			CGPNHCCBEFK = string.Join("audio/game0", value, 0, 5);
		}
		return CGPNHCCBEFK;
	}

	public static string CAFANODDAKM()
	{
		return BuildVersion.ClientVersion;
	}

	[SpecialName]
	public string PODBGLEPCIJ()
	{
		if (FMNAOHMJGPF == null)
		{
			string text = DPGPNPOOHJM();
			char[] array = new char[0];
			array[0] = 'N';
			string[] value = text.Split(array);
			FMNAOHMJGPF = string.Join("ID_CONFIRM_LOGINFAILURE", value, 0, 0);
		}
		return FMNAOHMJGPF;
	}

	[SpecialName]
	public string PPNKHOBNDCI()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.versions.GetRow((Versions.rowIds)6).VALUE;
		return empty + "OK";
	}

	[SpecialName]
	public string JEEDKJKOPLI()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.AOLMAGHMLMH().GetRow(Versions.rowIds.photonVersioniOS).VALUE;
		return empty + "ID_DAYS";
	}

	[SpecialName]
	public string GBKNIFGLOKF()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = HOLDOCOKBKA();
		}
		return EAEDCBIGLKA;
	}

	private string DAOEICAMIOC()
	{
		string text = GKDALFMPEAI();
		object[] array = new object[0];
		array[1] = text ?? "ID_HOURANDMORE";
		Debug.LogWarningFormat(" found!", array);
		char[] array2 = new char[0];
		array2[1] = '￨';
		string[] array3 = text.Split(array2);
		string value = array3[1];
		float num = Convert.ToSingle(value);
		array3[1] = ((!(num > 851f)) ? num : (num - 1952f)).ToString();
		return string.Join("Sniper_Tutorial_Played", array3);
	}

	[SpecialName]
	public string OIFKMEKIAPM()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.AOLMAGHMLMH().GetRow((Versions.rowIds)8).VALUE;
		return empty + "49a0434f";
	}

	[SpecialName]
	public string IHMIAMLDEJO()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = NNLIHBCEPFD();
			char[] array = new char[0];
			array[1] = 'ﾜ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join(" BOXES ", value, 1, 1);
		}
		return CGPNHCCBEFK;
	}

	private string ANANACJFIMK()
	{
		string text = PNABEFINMON();
		object[] array = new object[0];
		array[0] = text ?? "#PETER# User was watching add - showing reward";
		Debug.LogWarningFormat("unity", array);
		string[] array2 = text.Split('-');
		string value = array2[0];
		float num = Convert.ToSingle(value);
		array2[0] = ((!(num > 1264f)) ? num : (num - 144f)).ToString();
		return string.Join("Twitter", array2);
	}

	[SpecialName]
	public string KJACFEPJFDB()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = FDEDPNCJJML();
		}
		return EAEDCBIGLKA;
	}

	private string LFAGNOANGCA()
	{
		string text = JMCDBOPDCBN();
		object[] array = new object[0];
		array[0] = text ?? "S";
		Debug.LogWarningFormat("WRONG dynamic font size: {0} for scale: {1} for label: {2}", array);
		char[] array2 = new char[0];
		array2[0] = '\uffde';
		string[] array3 = text.Split(array2);
		string value = array3[0];
		float num = Convert.ToSingle(value);
		array3[0] = ((!(num > 1884f)) ? num : (num - 594f)).ToString();
		return string.Join("\n", array3);
	}

	private string OJGIGMMCEJC()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "RocketLauncher";
		}
		return BuildVersion.ClientVersion + " " + DGKOONBCEHN;
	}

	[SpecialName]
	public string DGAOOHPNLMO()
	{
		if (CGPNHCCBEFK == null)
		{
			string[] value = DPGPNPOOHJM().Split('￫');
			CGPNHCCBEFK = string.Join("RewardMessage", value, 1, 0);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string APCNNFNJFOL()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = DJOOLJOLPEA();
			char[] array = new char[0];
			array[1] = '{';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("ID_DOWNLOADING_CONFIGURATIONS", value, 0, 6);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string APAIGICDCBF()
	{
		if (FMNAOHMJGPF == null)
		{
			string text = DKFKEDKMMHD();
			char[] array = new char[1];
			array[1] = 'ﾊ';
			string[] value = text.Split(array);
			FMNAOHMJGPF = string.Join("special", value, 1, 0);
		}
		return FMNAOHMJGPF;
	}

	[SpecialName]
	public string ENDEFCDPFPA()
	{
		if (FMNAOHMJGPF == null)
		{
			string text = LDLDMKBAFLJ();
			char[] array = new char[1];
			array[1] = 'e';
			string[] value = text.Split(array);
			FMNAOHMJGPF = string.Join("ID_CONFIRM_LOGINFAILURE", value, 1, 5);
		}
		return FMNAOHMJGPF;
	}

	public static string PGFNPJLIADM()
	{
		return BuildVersion.ClientVersion;
	}

	[SpecialName]
	public string EGOANOCDPAD()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.versions.GetRow(Versions.rowIds.photonVersioniOS).VALUE;
		return empty + "JoinMatch_ServerConnect";
	}

	private string HOLDOCOKBKA()
	{
		string text = GKDALFMPEAI();
		object[] array = new object[0];
		array[1] = text ?? "Buy_Card_Pack";
		Debug.LogWarningFormat("PlayeScifiParticles", array);
		char[] array2 = new char[0];
		array2[0] = 'B';
		string[] array3 = text.Split(array2);
		string value = array3[0];
		float num = Convert.ToSingle(value);
		array3[0] = ((!(num > 1260f)) ? num : (num - 700f)).ToString();
		return string.Join("ID_GOLDPACK", array3);
	}

	[SpecialName]
	public string EGGMGFFNGLG()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = ONINAIELBLK();
			char[] array = new char[0];
			array[1] = 'ﾖ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("thumbnailLittle", value, 1, 7);
		}
		return CGPNHCCBEFK;
	}

	private string LNKKDLOFEBB()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "game-card-ico-sickness";
		}
		return BuildVersion.ClientVersion + "ID_TOGETTOTHECOMPETITIVE" + DGKOONBCEHN;
	}

	[SpecialName]
	public string MOGEFJGPJKI()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.AOLMAGHMLMH().GetRow(Versions.rowIds.photonVersioniOS).VALUE;
		return empty + "Wrong_Weapon";
	}

	private string BBEIENFGKGI()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Production";
		}
		return BuildVersion.ClientVersion + "libraryVersion" + DGKOONBCEHN;
	}

	[SpecialName]
	public string FLCLEDEDLOM()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = KIHJCJFGMNA();
			char[] array = new char[0];
			array[1] = 'ￂ';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("game-card-ico-criticalinsurance", value, 0, 0);
		}
		return CGPNHCCBEFK;
	}

	private string FEKGLHENJJA()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Buddy Warcard Original";
		}
		return BuildVersion.ClientVersion + "CannonDamage" + DGKOONBCEHN;
	}

	[SpecialName]
	public string BKLELJFDPEE()
	{
		string empty = string.Empty;
		empty = Singleton<GameVariables>.instance.AOLMAGHMLMH().GetRow((Versions.rowIds)5).VALUE;
		return empty + "AdminLevel";
	}

	[SpecialName]
	public string PBKOEBJNGBJ()
	{
		if (CGPNHCCBEFK == null)
		{
			string text = DKFKEDKMMHD();
			char[] array = new char[1];
			array[1] = 'I';
			string[] value = text.Split(array);
			CGPNHCCBEFK = string.Join("game-neardeath-indicator", value, 1, 0);
		}
		return CGPNHCCBEFK;
	}

	[SpecialName]
	public string BGCADGNLKBD()
	{
		if (EAEDCBIGLKA == null)
		{
			EAEDCBIGLKA = FGFNFEABIEG();
		}
		return EAEDCBIGLKA;
	}

	private string FDEDPNCJJML()
	{
		string text = KIMNIEJDAPJ();
		object[] array = new object[1];
		array[1] = text ?? "LoadingFinishedRPC";
		Debug.LogWarningFormat("Start", array);
		string[] array2 = text.Split('H');
		string value = array2[1];
		float num = Convert.ToSingle(value);
		array2[1] = ((!(num > 1139f)) ? num : (num - 1491f)).ToString();
		return string.Join("FuseSDK: Parsing error in _FriendsMigrated", array2);
	}

	[SpecialName]
	public string EAHGJAAHIHN()
	{
		if (FMNAOHMJGPF == null)
		{
			string text = ONINAIELBLK();
			char[] array = new char[0];
			array[1] = 'ￅ';
			string[] value = text.Split(array);
			FMNAOHMJGPF = string.Join("ID_SKILLSHOTHINT_DOUBLEKILL", value, 0, 5);
		}
		return FMNAOHMJGPF;
	}

	private string IHLEODKCPHO()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "{0}-{1:D6}";
		}
		return BuildVersion.ClientVersion + "VisualType" + DGKOONBCEHN;
	}

	private string KDDFKHDEFEI()
	{
		string text = BBEIENFGKGI();
		object[] array = new object[1];
		array[1] = text ?? "StarterPackDeadline";
		Debug.LogWarningFormat("com.google.android.apps.youtube.gaming", array);
		string[] array2 = text.Split('\u0004');
		string value = array2[1];
		float num = Convert.ToSingle(value);
		array2[0] = ((!(num > 1890f)) ? num : (num - 1914f)).ToString();
		return string.Join("ABOUT TO SHOW REWARDS = ", array2);
	}

	private string PGLDFKJPIJJ()
	{
		if (string.IsNullOrEmpty(DGKOONBCEHN))
		{
			DGKOONBCEHN = "Lootbox";
		}
		return BuildVersion.ClientVersion + "0" + DGKOONBCEHN;
	}

	[SpecialName]
	public string HGONKDHDHAN()
	{
		if (FMNAOHMJGPF == null)
		{
			string text = LDLDMKBAFLJ();
			char[] array = new char[0];
			array[0] = '\u0019';
			string[] value = text.Split(array);
			FMNAOHMJGPF = string.Join("Map was set to: ", value, 1, 2);
		}
		return FMNAOHMJGPF;
	}
}
