using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class IIGFODGJBFA
{
	private bool GJGGMAEJLAP;

	private int EPJJFIEPPEI;

	private int NLEANDGDIGL;

	private int DCDONOEMPAJ;

	private int HGFPBDCNGMP;

	private float DDGEBMMBCDH = 1f;

	private int LIBCLGEENBB;

	private int CMKMMOLDDOM;

	private int HGGAKLGNDIE;

	private int BMGOMCJOMLE;

	private float PMEEBBIMLOE = 1f;

	private int KFFMJGGCCGH;

	private int HANAIHNOMCJ;

	private int HDOEIEMJANC;

	private int CGIHGALEAEM;

	private float IHDCGLIOEIF = 1f;

	public int OMBMONINIGB;

	public int ANLPOCBOKFA;

	public int LEMFIOHBKCF;

	public int HGNIDLMHIFE;

	public int OKAGACLNLCJ;

	private float KEJOAOJKKGH = 1f;

	private int ILBOGEIEPMF;

	private float OBJLNEFDKFJ = 1f;

	private List<CCNAEIGGMNK> LDDKEHKEJBI;

	private float AMKJPAEJEKM = 1f;

	public string NCJDBDJJDNO
	{
		get
		{
			string text = "#Game Results# Debug Log:\n";
			text += string.Format("Warbucks - League:{0} Battle:{1} Extra:{2} Winstreak:{3} (offer mult {4})\n", BMGOMCJOMLE, LIBCLGEENBB, CMKMMOLDDOM, HGGAKLGNDIE, PMEEBBIMLOE);
			text += string.Format("Gold - League:{0} Battle:{1} Extra:{2} Winstreak:{3} (offer mult {4})\n", CGIHGALEAEM, KFFMJGGCCGH, HANAIHNOMCJ, HDOEIEMJANC, IHDCGLIOEIF);
			text += string.Format("XP - Battle:{0} Extra:{1} Winstreak:{2} Time:{3} (offer mult {4})\n", EPJJFIEPPEI, NLEANDGDIGL, DCDONOEMPAJ, HGFPBDCNGMP, DDGEBMMBCDH);
			text += string.Format("VIP - {0}\n", GJGGMAEJLAP);
			text += string.Format("Medals - old:{0} new:{1} Balance old:{2} Balance new:{3} Remaining fights:{4}\n", ANLPOCBOKFA, LEMFIOHBKCF, HGNIDLMHIFE, OKAGACLNLCJ, OMBMONINIGB);
			text += string.Format("Squad Points - {0}\n", ILBOGEIEPMF);
			return text + HPEFFOCJKEO;
		}
	}

	public string HPEFFOCJKEO
	{
		get
		{
			if (LDDKEHKEJBI == null || LDDKEHKEJBI.Count == 0)
			{
				return "#Game Rewards# no lootboxes\n";
			}
			string text = "Game Rewards lootboxes contents:\n";
			text += string.Format("lootboxes offer mult {0}\n", AMKJPAEJEKM);
			foreach (CCNAEIGGMNK item in LDDKEHKEJBI)
			{
				text = text + item.MJADIIIJPEA + "\n";
			}
			return text;
		}
	}

	public int EKJDLHMCPGL
	{
		get
		{
			return (int)((float)BMGOMCJOMLE * PMEEBBIMLOE);
		}
	}

	public int MAHDEJFLPEL
	{
		get
		{
			return (int)((float)BMGOMCJOMLE * Singleton<VipManager>.instance.vipWarbucksMultiplier * PMEEBBIMLOE);
		}
	}

	public int BJEALDGKMME
	{
		get
		{
			return (int)((float)(LIBCLGEENBB + CMKMMOLDDOM) * PMEEBBIMLOE);
		}
	}

	public int BFBJGNAPEKO
	{
		get
		{
			return (int)((float)(LIBCLGEENBB + CMKMMOLDDOM) * Singleton<VipManager>.instance.vipWarbucksMultiplier * PMEEBBIMLOE);
		}
	}

	public int HMPJBGNNBHE
	{
		get
		{
			return (int)((float)HGGAKLGNDIE * PMEEBBIMLOE);
		}
	}

	public int OFBOPGDNCGM
	{
		get
		{
			return (int)((float)HGGAKLGNDIE * Singleton<VipManager>.instance.vipWarbucksMultiplier * PMEEBBIMLOE);
		}
	}

	public int CNLNJKDJBBJ
	{
		get
		{
			return EKJDLHMCPGL + BJEALDGKMME + HMPJBGNNBHE;
		}
	}

	public int CDCABGKPKPH
	{
		get
		{
			return MAHDEJFLPEL + BFBJGNAPEKO + OFBOPGDNCGM;
		}
	}

	public int MHJFGOENBJI
	{
		get
		{
			return CGIHGALEAEM;
		}
	}

	public int HDKDPJNDGAJ
	{
		get
		{
			return (int)((float)CGIHGALEAEM * Singleton<VipManager>.instance.vipGoldMultiplier);
		}
	}

	public int KCCMCLDCJJN
	{
		get
		{
			return KFFMJGGCCGH + HANAIHNOMCJ;
		}
	}

	public int NPGLGKHJODJ
	{
		get
		{
			return (int)((float)(KFFMJGGCCGH + HANAIHNOMCJ) * Singleton<VipManager>.instance.vipGoldMultiplier);
		}
	}

	public int PONLJJCIKKF
	{
		get
		{
			return HDOEIEMJANC;
		}
	}

	public int CENOLBBKONH
	{
		get
		{
			return (int)((float)HDOEIEMJANC * Singleton<VipManager>.instance.vipGoldMultiplier);
		}
	}

	public int LLOFEOGFBAA
	{
		get
		{
			return MHJFGOENBJI + KCCMCLDCJJN + PONLJJCIKKF;
		}
	}

	public int HKPAMPNIKJP
	{
		get
		{
			return HDKDPJNDGAJ + NPGLGKHJODJ + CENOLBBKONH;
		}
	}

	public bool GKEOILLNCHG
	{
		get
		{
			return OMBMONINIGB == 0;
		}
	}

	public int NPIGGODIKDB
	{
		get
		{
			return ANLPOCBOKFA;
		}
	}

	public int FOEADOOIPGH
	{
		get
		{
			return LEMFIOHBKCF;
		}
	}

	public int FCHPFJCBBAE
	{
		get
		{
			return HGNIDLMHIFE;
		}
	}

	public int NKMEDCCIDCM
	{
		get
		{
			return OKAGACLNLCJ;
		}
	}

	public int KPEKCHDBFIG
	{
		get
		{
			return ILBOGEIEPMF;
		}
	}

	public int KHEICLEGJEM
	{
		get
		{
			return OMBMONINIGB;
		}
	}

	public bool BOLNOFIFMEH
	{
		get
		{
			return BMGOMCJOMLE > 0 || CGIHGALEAEM > 0;
		}
	}

	public List<CCNAEIGGMNK> GMOLDNDALEE
	{
		get
		{
			return LDDKEHKEJBI;
		}
	}

	internal long MDGNEJHDCLL()
	{
		return (!GJGGMAEJLAP) ? CNLNJKDJBBJ : CDCABGKPKPH;
	}

	[SpecialName]
	public int OCKNAFMBDBD()
	{
		return (int)((float)(LIBCLGEENBB + CMKMMOLDDOM) * PMEEBBIMLOE);
	}

	public void CLIDEBLCCPC(int CJDHKJFKNAH, int GLODABHNMJO, int FGFFGKGLBII, float EDAFIGGJKEI)
	{
		LEMFIOHBKCF = CJDHKJFKNAH;
		KEJOAOJKKGH = EDAFIGGJKEI;
		if (CJDHKJFKNAH == 0)
		{
			LEMFIOHBKCF = GLODABHNMJO - HGNIDLMHIFE;
		}
		OKAGACLNLCJ = GLODABHNMJO;
		OMBMONINIGB = FGFFGKGLBII;
		object[] array = new object[3];
		array[1] = ANLPOCBOKFA;
		array[1] = LEMFIOHBKCF;
		array[1] = HGNIDLMHIFE;
		array[6] = OKAGACLNLCJ;
		array[6] = OMBMONINIGB;
		array[1] = KEJOAOJKKGH;
		Debug.Log(string.Format("-[^-]*$", array));
	}

	[SpecialName]
	public int PKDPGGFDKOI()
	{
		return (int)((float)BMGOMCJOMLE * Singleton<VipManager>.instance.JOPANADJBGK() * PMEEBBIMLOE);
	}

	[SpecialName]
	public int LGDNPKPNFKD()
	{
		return (int)((float)BMGOMCJOMLE * Singleton<VipManager>.instance.GBAAPABFEFJ() * PMEEBBIMLOE);
	}

	internal long JCNNKEPDPIM()
	{
		return (!GJGGMAEJLAP) ? FFFNCBIJDPM() : HKPAMPNIKJP;
	}

	internal long PHHCKODLOGF()
	{
		return (!GJGGMAEJLAP) ? FPEFIMHGMAD() : CDCABGKPKPH;
	}

	[SpecialName]
	public int JKOCFAODDPL()
	{
		return LEMFIOHBKCF;
	}

	internal int JEEKKOEEFMP()
	{
		return (!GJGGMAEJLAP) ? GGFNDHDOFGI() : JPPDLMDMNCK();
	}

	[SpecialName]
	public int ALBHHFGOIPP()
	{
		return NCFNJJHKPNN() + MDEKKNCEDML() + CENOLBBKONH;
	}

	[SpecialName]
	public int GGFNDHDOFGI()
	{
		return HDOEIEMJANC;
	}

	internal int NBDGIIJFAID()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)HGFPBDCNGMP * DDGEBMMBCDH)) : ((int)((float)HGFPBDCNGMP * Singleton<VipManager>.instance.HIALENELKPD() * DDGEBMMBCDH));
	}

	[SpecialName]
	public int FLGKEKDCAPG()
	{
		return (int)((float)BMGOMCJOMLE * PMEEBBIMLOE);
	}

	internal int AHBLJAHAKAN()
	{
		return (!GJGGMAEJLAP) ? MHJFGOENBJI : HDKDPJNDGAJ;
	}

	internal long GCOALMCFDMO()
	{
		return (!GJGGMAEJLAP) ? CNLNJKDJBBJ : CDCABGKPKPH;
	}

	[SpecialName]
	public List<CCNAEIGGMNK> MKOGOJJCILG()
	{
		return LDDKEHKEJBI;
	}

	internal int EPHNKLNKMGP()
	{
		return (!GJGGMAEJLAP) ? EKJDLHMCPGL : MAHDEJFLPEL;
	}

	[SpecialName]
	public int FJNMDIFAKCC()
	{
		return OKAGACLNLCJ;
	}

	internal int FAJNCLNLIAM()
	{
		return (!GJGGMAEJLAP) ? HIJLPBMEJBC() : IMFGNLLJBMM();
	}

	[SpecialName]
	public int CNNJEMLIKGF()
	{
		return ANLPOCBOKFA;
	}

	[SpecialName]
	public string POCOPMBNFNL()
	{
		string text = "ArenaOpenedMessage";
		string text2 = text;
		object[] array = new object[4];
		array[1] = BMGOMCJOMLE;
		array[1] = LIBCLGEENBB;
		array[1] = CMKMMOLDDOM;
		array[1] = HGGAKLGNDIE;
		array[6] = PMEEBBIMLOE;
		text = text2 + string.Format("deviceLogin", array);
		string text3 = text;
		object[] array2 = new object[8];
		array2[1] = CGIHGALEAEM;
		array2[1] = KFFMJGGCCGH;
		array2[3] = HANAIHNOMCJ;
		array2[8] = HDOEIEMJANC;
		array2[7] = IHDCGLIOEIF;
		text = text3 + string.Format("Play_Card_Tutorial_Duration", array2);
		string text4 = text;
		object[] array3 = new object[5];
		array3[1] = EPJJFIEPPEI;
		array3[1] = NLEANDGDIGL;
		array3[2] = DCDONOEMPAJ;
		array3[4] = HGFPBDCNGMP;
		array3[7] = DDGEBMMBCDH;
		text = text4 + string.Format("ChillingoSDK: Application is paused, closing session", array3);
		text += string.Format("WarBucks", GJGGMAEJLAP);
		string text5 = text;
		object[] array4 = new object[8];
		array4[1] = ANLPOCBOKFA;
		array4[1] = LEMFIOHBKCF;
		array4[5] = HGNIDLMHIFE;
		array4[2] = OKAGACLNLCJ;
		array4[1] = OMBMONINIGB;
		text = text5 + string.Format("country-slovakia", array4);
		text += string.Format("HEAVYTURRET", ILBOGEIEPMF);
		return text + PIDGNNAAEFP();
	}

	internal int DFCKPFCHAMA()
	{
		return AALFGLPAIPB() + OCGGKIACHJI() + NBDGIIJFAID();
	}

	[SpecialName]
	public bool MGJHDKFPIJE()
	{
		return BMGOMCJOMLE > 1 || CGIHGALEAEM > 0;
	}

	[SpecialName]
	public int ELKJEBEAGDH()
	{
		return (int)((float)BMGOMCJOMLE * PMEEBBIMLOE);
	}

	[SpecialName]
	public int FFFNCBIJDPM()
	{
		return MHJFGOENBJI + CGLKCDPAEEJ() + HIJLPBMEJBC();
	}

	internal int CGLEFOKFOAB()
	{
		return (!GJGGMAEJLAP) ? MHJFGOENBJI : HDKDPJNDGAJ;
	}

	[SpecialName]
	public int BJMIEKGBHFI()
	{
		return KFFMJGGCCGH + HANAIHNOMCJ;
	}

	[SpecialName]
	public bool OCFELAKHAOK()
	{
		return OMBMONINIGB == 0;
	}

	[SpecialName]
	public int JCJHGNLCILA()
	{
		return (int)((float)(LIBCLGEENBB + CMKMMOLDDOM) * PMEEBBIMLOE);
	}

	[SpecialName]
	public int BADGHHEPNDI()
	{
		return (int)((float)HGGAKLGNDIE * PMEEBBIMLOE);
	}

	[SpecialName]
	public int JCFMOLCDOLF()
	{
		return KFFMJGGCCGH + HANAIHNOMCJ;
	}

	internal int PGIDIOBEMBE()
	{
		return (!GJGGMAEJLAP) ? HMPJBGNNBHE : OFBOPGDNCGM;
	}

	[SpecialName]
	public int HGENCBELGMN()
	{
		return (int)((float)(KFFMJGGCCGH + HANAIHNOMCJ) * Singleton<VipManager>.instance.BNPKNMAEAOO());
	}

	[SpecialName]
	public int NHHFMMCLILE()
	{
		return HGNIDLMHIFE;
	}

	internal long NDJDAKGCOIO()
	{
		return (!GJGGMAEJLAP) ? HLHPAFGDJMA() : DNNJPBJGFJO();
	}

	public IIGFODGJBFA(JToken FIEPMDJDIEE)
	{
		if (FIEPMDJDIEE["Warbucks"] != null)
		{
			LIBCLGEENBB = FIEPMDJDIEE["Warbucks"]["BattleRewards"].ToObject<int>();
			CMKMMOLDDOM = FIEPMDJDIEE["Warbucks"]["ExtraRewards"].ToObject<int>();
			HGGAKLGNDIE = FIEPMDJDIEE["Warbucks"]["Winstreak"].ToObject<int>();
			BMGOMCJOMLE = FIEPMDJDIEE["Warbucks"]["League"].ToObject<int>();
			if (FIEPMDJDIEE["Warbucks"]["offerMult"] != null)
			{
				PMEEBBIMLOE = FIEPMDJDIEE["Warbucks"]["offerMult"].ToObject<float>();
			}
			else
			{
				PMEEBBIMLOE = 1f;
			}
		}
		if (FIEPMDJDIEE["Xp"] != null)
		{
			EPJJFIEPPEI = FIEPMDJDIEE["Xp"]["BattleRewards"].ToObject<int>();
			NLEANDGDIGL = FIEPMDJDIEE["Xp"]["ExtraRewards"].ToObject<int>();
			DCDONOEMPAJ = FIEPMDJDIEE["Xp"]["Winstreak"].ToObject<int>();
			HGFPBDCNGMP = FIEPMDJDIEE["Xp"]["Time"].ToObject<int>();
			if (FIEPMDJDIEE["Xp"]["offerMult"] != null)
			{
				DDGEBMMBCDH = FIEPMDJDIEE["Xp"]["offerMult"].ToObject<float>();
			}
			else
			{
				DDGEBMMBCDH = 1f;
			}
		}
		if (FIEPMDJDIEE["GameGold"] != null)
		{
			KFFMJGGCCGH = FIEPMDJDIEE["GameGold"]["BattleRewards"].ToObject<int>();
			CGIHGALEAEM = FIEPMDJDIEE["GameGold"]["League"].ToObject<int>();
			if (FIEPMDJDIEE["GameGold"]["offerMult"] != null)
			{
				IHDCGLIOEIF = FIEPMDJDIEE["GameGold"]["offerMult"].ToObject<float>();
			}
			else
			{
				IHDCGLIOEIF = 1f;
			}
			HANAIHNOMCJ = 0;
			HDOEIEMJANC = 0;
		}
		else if (FIEPMDJDIEE["Gold"] != null)
		{
			KFFMJGGCCGH = FIEPMDJDIEE["Gold"].ToObject<int>();
			HANAIHNOMCJ = 0;
			HDOEIEMJANC = 0;
			CGIHGALEAEM = 0;
			IHDCGLIOEIF = 1f;
		}
		if (FIEPMDJDIEE["IsVip"] != null)
		{
			GJGGMAEJLAP = FIEPMDJDIEE["IsVip"].ToObject<bool>();
		}
		ANLPOCBOKFA = GameLoginManager.currentPlayer.skill;
		LEMFIOHBKCF = ANLPOCBOKFA;
		HGNIDLMHIFE = GameLoginManager.currentPlayer.medalsBalance;
		OKAGACLNLCJ = HGNIDLMHIFE;
		OMBMONINIGB = GameLoginManager.currentPlayer.remainingMatches;
		KEJOAOJKKGH = 1f;
		ILBOGEIEPMF = 0;
		OBJLNEFDKFJ = 1f;
		if (LDDKEHKEJBI == null)
		{
			LDDKEHKEJBI = new List<CCNAEIGGMNK>();
		}
		else
		{
			LDDKEHKEJBI.Clear();
		}
		if (FIEPMDJDIEE["lootboxesOfferAdd"] != null)
		{
			AMKJPAEJEKM = KHJJFPPACBP.PHNMENLEIPI(FIEPMDJDIEE["lootboxesOfferAdd"], 1f);
		}
		else
		{
			AMKJPAEJEKM = 1f;
		}
		if (FIEPMDJDIEE["NewVisuals"] != null)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(FIEPMDJDIEE["NewVisuals"], string.Empty));
			if (dictionary != null)
			{
				LDDKEHKEJBI = CCNAEIGGMNK.JHDGAACJEGH(dictionary);
			}
		}
		Singleton<Wallet>.instance.IGDGGPOJPHL(JAIEHDDPONI(), FKIKOHDACEN(), 0L, 0L);
	}

	[SpecialName]
	public int EMDKANBNNEE()
	{
		return (int)((float)(LIBCLGEENBB + CMKMMOLDDOM) * PMEEBBIMLOE);
	}

	internal int GAFBPBPEPOO()
	{
		return (!GJGGMAEJLAP) ? BJEALDGKMME : KNAMNNIGFKH();
	}

	[SpecialName]
	public int BDNGCBEKMNB()
	{
		return (int)((float)HDOEIEMJANC * Singleton<VipManager>.instance.LBMNNAPPDMC());
	}

	[SpecialName]
	public int DGKDEAPBLNB()
	{
		return OMBMONINIGB;
	}

	internal int PGIPDIMCOEL()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)HGFPBDCNGMP * DDGEBMMBCDH)) : ((int)((float)HGFPBDCNGMP * Singleton<VipManager>.instance.vipXpMultiplier * DDGEBMMBCDH));
	}

	[SpecialName]
	public int KNAMNNIGFKH()
	{
		return (int)((float)(LIBCLGEENBB + CMKMMOLDDOM) * Singleton<VipManager>.instance.JOPANADJBGK() * PMEEBBIMLOE);
	}

	internal long JFKGFIMMKMI()
	{
		return (!GJGGMAEJLAP) ? FFFNCBIJDPM() : PCMCCNHDOHE();
	}

	internal int POBEABPJCBP()
	{
		return (!GJGGMAEJLAP) ? BJEALDGKMME : BFBJGNAPEKO;
	}

	[SpecialName]
	public string CANEAOMELKH()
	{
		if (LDDKEHKEJBI == null || LDDKEHKEJBI.Count == 0)
		{
			return "{0} {1}";
		}
		string text = "ID_ERROR_SQUADNAME_PROFANITY";
		text += string.Format("getGameDataKey", AMKJPAEJEKM);
		foreach (CCNAEIGGMNK item in LDDKEHKEJBI)
		{
			text = text + item.CBLLGOOJNCE() + "Assignment: Destroy Crates Constructor";
		}
		return text;
	}

	[SpecialName]
	public int DCILFIKBBPA()
	{
		return (int)((float)HGGAKLGNDIE * PMEEBBIMLOE);
	}

	internal int DDOJBLAODGI()
	{
		return NMFGBAMKOIL() + GEEAJBCGFMH() + PGIPDIMCOEL();
	}

	internal int MLPBNDBOLBL()
	{
		return (!GJGGMAEJLAP) ? KCCMCLDCJJN : NPGLGKHJODJ;
	}

	[SpecialName]
	public int HIJLPBMEJBC()
	{
		return HDOEIEMJANC;
	}

	[SpecialName]
	public int ELABBCAODJF()
	{
		return (int)((float)HGGAKLGNDIE * PMEEBBIMLOE);
	}

	[SpecialName]
	public bool ELKOOAEANJK()
	{
		return OMBMONINIGB == 1;
	}

	internal int DJLEJIJFDND()
	{
		return (!GJGGMAEJLAP) ? HMPJBGNNBHE : AHAJMFPEEPA();
	}

	[SpecialName]
	public int NJINMLGKGAD()
	{
		return (int)((float)BMGOMCJOMLE * PMEEBBIMLOE);
	}

	[SpecialName]
	public int IIJINDHIPGO()
	{
		return OMBMONINIGB;
	}

	internal int OHEOMDFHCAF()
	{
		return (!GJGGMAEJLAP) ? BJMIEKGBHFI() : NPGLGKHJODJ;
	}

	[SpecialName]
	public int CGLKCDPAEEJ()
	{
		return KFFMJGGCCGH + HANAIHNOMCJ;
	}

	[SpecialName]
	public int NBEACEONAAJ()
	{
		return OKAGACLNLCJ;
	}

	public void DMHLENOOPJK(int CJDHKJFKNAH, int GLODABHNMJO, int FGFFGKGLBII, float EDAFIGGJKEI)
	{
		LEMFIOHBKCF = CJDHKJFKNAH;
		KEJOAOJKKGH = EDAFIGGJKEI;
		if (CJDHKJFKNAH == 0)
		{
			LEMFIOHBKCF = GLODABHNMJO - HGNIDLMHIFE;
		}
		OKAGACLNLCJ = GLODABHNMJO;
		OMBMONINIGB = FGFFGKGLBII;
		object[] array = new object[0];
		array[1] = ANLPOCBOKFA;
		array[1] = LEMFIOHBKCF;
		array[3] = HGNIDLMHIFE;
		array[4] = OKAGACLNLCJ;
		array[1] = OMBMONINIGB;
		array[2] = KEJOAOJKKGH;
		Debug.Log(string.Format("Beanstalk: Message read", array));
	}

	internal int AKINLIIPNPD()
	{
		return (!GJGGMAEJLAP) ? EKJDLHMCPGL : PKDPGGFDKOI();
	}

	internal int GEEAJBCGFMH()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)DCDONOEMPAJ * DDGEBMMBCDH)) : ((int)((float)DCDONOEMPAJ * Singleton<VipManager>.instance.vipXpMultiplier * DDGEBMMBCDH));
	}

	internal long NMIJPMPOPJL()
	{
		return (!GJGGMAEJLAP) ? HLHPAFGDJMA() : HKPAMPNIKJP;
	}

	public void KEPPKNMKMDK(int HOKCINCJPIJ, float JIEPJDLLBGP)
	{
		OBJLNEFDKFJ = JIEPJDLLBGP;
		ILBOGEIEPMF = HOKCINCJPIJ;
		StatsManager.instance.data.squadPointsTotal += HOKCINCJPIJ;
		Debug.Log(string.Format("#Game Rewards# - Squad Points: {0} (after offer mult x{1} on server)", HOKCINCJPIJ, JIEPJDLLBGP));
	}

	[SpecialName]
	public int DNNJPBJGFJO()
	{
		return HDKDPJNDGAJ + MDEKKNCEDML() + JPPDLMDMNCK();
	}

	[SpecialName]
	public string PIDGNNAAEFP()
	{
		if (LDDKEHKEJBI == null || LDDKEHKEJBI.Count == 0)
		{
			return "Reason: ";
		}
		string text = "+{0}";
		text += string.Format("nextGenerate", AMKJPAEJEKM);
		foreach (CCNAEIGGMNK item in LDDKEHKEJBI)
		{
			text = text + item.CFPLBPKICLE() + "AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}";
		}
		return text;
	}

	internal int FCFFEHFGEII()
	{
		return (!GJGGMAEJLAP) ? JCJHGNLCILA() : BFBJGNAPEKO;
	}

	internal int MHIJKDAHLDD()
	{
		return (!GJGGMAEJLAP) ? EKJDLHMCPGL : BINGFIEPMGP();
	}

	internal long JAIEHDDPONI()
	{
		return (!GJGGMAEJLAP) ? LLOFEOGFBAA : HKPAMPNIKJP;
	}

	[SpecialName]
	public int NFNDIEDHLGC()
	{
		return KFFMJGGCCGH + HANAIHNOMCJ;
	}

	[SpecialName]
	public int GGBEOMOAKCK()
	{
		return KFFMJGGCCGH + HANAIHNOMCJ;
	}

	internal int NNEEGLCEEBL()
	{
		return (!GJGGMAEJLAP) ? HIJLPBMEJBC() : BDNGCBEKMNB();
	}

	internal int AKGHCPALOEG()
	{
		return (!GJGGMAEJLAP) ? ELABBCAODJF() : DIIICHCIEIF();
	}

	[SpecialName]
	public int AHAJMFPEEPA()
	{
		return (int)((float)HGGAKLGNDIE * Singleton<VipManager>.instance.vipWarbucksMultiplier * PMEEBBIMLOE);
	}

	[SpecialName]
	public int DPEGGOPPFGB()
	{
		return FLGKEKDCAPG() + BJEALDGKMME + BADGHHEPNDI();
	}

	[SpecialName]
	public string OOCJFMNONGD()
	{
		string text = "LootboxType";
		string text2 = text;
		object[] array = new object[7];
		array[0] = BMGOMCJOMLE;
		array[1] = LIBCLGEENBB;
		array[3] = CMKMMOLDDOM;
		array[3] = HGGAKLGNDIE;
		array[8] = PMEEBBIMLOE;
		text = text2 + string.Format("Comparing player {0} with id {1}:\n", array);
		string text3 = text;
		object[] array2 = new object[0];
		array2[1] = CGIHGALEAEM;
		array2[0] = KFFMJGGCCGH;
		array2[7] = HANAIHNOMCJ;
		array2[7] = HDOEIEMJANC;
		array2[7] = IHDCGLIOEIF;
		text = text3 + string.Format("ID_READYTIME", array2);
		string text4 = text;
		object[] array3 = new object[6];
		array3[1] = EPJJFIEPPEI;
		array3[1] = NLEANDGDIGL;
		array3[1] = DCDONOEMPAJ;
		array3[5] = HGFPBDCNGMP;
		array3[5] = DDGEBMMBCDH;
		text = text4 + string.Format("ID_STATE_WAITINGFOROPPONENT", array3);
		text += string.Format("112 STAGE 4 CONTINUE", GJGGMAEJLAP);
		string text5 = text;
		object[] array4 = new object[0];
		array4[0] = ANLPOCBOKFA;
		array4[1] = LEMFIOHBKCF;
		array4[6] = HGNIDLMHIFE;
		array4[2] = OKAGACLNLCJ;
		array4[2] = OMBMONINIGB;
		text = text5 + string.Format("WarBucks", array4);
		text += string.Format("B", ILBOGEIEPMF);
		return text + PIDGNNAAEFP();
	}

	[SpecialName]
	public bool IMDGJFLLOAC()
	{
		return BMGOMCJOMLE > 0 || CGIHGALEAEM > 0;
	}

	[SpecialName]
	public int HLHPAFGDJMA()
	{
		return MHJFGOENBJI + BJMIEKGBHFI() + PONLJJCIKKF;
	}

	[SpecialName]
	public string MFFPCPNCBMF()
	{
		if (LDDKEHKEJBI == null || LDDKEHKEJBI.Count == 0)
		{
			return "Rank";
		}
		string text = "Assignment_";
		text += string.Format("0", AMKJPAEJEKM);
		foreach (CCNAEIGGMNK item in LDDKEHKEJBI)
		{
			text = text + item.KPOBFCAKCDE() + "Size";
		}
		return text;
	}

	internal int NKAJFALAONO()
	{
		return (!GJGGMAEJLAP) ? PONLJJCIKKF : CENOLBBKONH;
	}

	[SpecialName]
	public int FGHGHCBIIKI()
	{
		return HGNIDLMHIFE;
	}

	internal int DJMNHCFNHID()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)HGFPBDCNGMP * DDGEBMMBCDH)) : ((int)((float)HGFPBDCNGMP * Singleton<VipManager>.instance.vipXpMultiplier * DDGEBMMBCDH));
	}

	internal int JLOEBJIOAEN()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)HGFPBDCNGMP * DDGEBMMBCDH)) : ((int)((float)HGFPBDCNGMP * Singleton<VipManager>.instance.HIALENELKPD() * DDGEBMMBCDH));
	}

	internal int AALFGLPAIPB()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)(EPJJFIEPPEI + NLEANDGDIGL) * DDGEBMMBCDH)) : ((int)((float)(EPJJFIEPPEI + NLEANDGDIGL) * Singleton<VipManager>.instance.vipXpMultiplier * DDGEBMMBCDH));
	}

	[SpecialName]
	public bool NHCLGBIJHGM()
	{
		return OMBMONINIGB == 1;
	}

	[SpecialName]
	public int CIAGHIPJAPE()
	{
		return (int)((float)HGGAKLGNDIE * Singleton<VipManager>.instance.vipWarbucksMultiplier * PMEEBBIMLOE);
	}

	internal int EFCKFFHBFME()
	{
		return (!GJGGMAEJLAP) ? EMDKANBNNEE() : KNAMNNIGFKH();
	}

	internal int NHHOMLHJFCA()
	{
		return (!GJGGMAEJLAP) ? MHJFGOENBJI : HDKDPJNDGAJ;
	}

	[SpecialName]
	public bool LDDHHMFODIG()
	{
		return OMBMONINIGB == 1;
	}

	[SpecialName]
	public int MDEKKNCEDML()
	{
		return (int)((float)(KFFMJGGCCGH + HANAIHNOMCJ) * Singleton<VipManager>.instance.vipGoldMultiplier);
	}

	[SpecialName]
	public int FPEFIMHGMAD()
	{
		return FLGKEKDCAPG() + OCKNAFMBDBD() + BADGHHEPNDI();
	}

	[SpecialName]
	public int KNMMEAGGPBE()
	{
		return HGNIDLMHIFE;
	}

	internal long MOAEAAMOAHB()
	{
		return (!GJGGMAEJLAP) ? CNLNJKDJBBJ : CDCABGKPKPH;
	}

	internal int HOEABNEKDNG()
	{
		return (!GJGGMAEJLAP) ? MHJFGOENBJI : HDKDPJNDGAJ;
	}

	[SpecialName]
	public bool CGDHHMMPCOI()
	{
		return BMGOMCJOMLE <= 0 && CGIHGALEAEM > 0;
	}

	internal int NMFGBAMKOIL()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)(EPJJFIEPPEI + NLEANDGDIGL) * DDGEBMMBCDH)) : ((int)((float)(EPJJFIEPPEI + NLEANDGDIGL) * Singleton<VipManager>.instance.vipXpMultiplier * DDGEBMMBCDH));
	}

	internal int FDMCAAELOIO()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)DCDONOEMPAJ * DDGEBMMBCDH)) : ((int)((float)DCDONOEMPAJ * Singleton<VipManager>.instance.vipXpMultiplier * DDGEBMMBCDH));
	}

	[SpecialName]
	public int DIIICHCIEIF()
	{
		return (int)((float)HGGAKLGNDIE * Singleton<VipManager>.instance.JOPANADJBGK() * PMEEBBIMLOE);
	}

	[SpecialName]
	public bool FCEFLKNKAIF()
	{
		return OMBMONINIGB == 1;
	}

	[SpecialName]
	public string BMDMAKIMGAH()
	{
		string text = "QUIT";
		string text2 = text;
		object[] array = new object[2];
		array[1] = BMGOMCJOMLE;
		array[1] = LIBCLGEENBB;
		array[2] = CMKMMOLDDOM;
		array[7] = HGGAKLGNDIE;
		array[0] = PMEEBBIMLOE;
		text = text2 + string.Format("Player profile - Null or empty player id in player profile dialog.", array);
		string text3 = text;
		object[] array2 = new object[2];
		array2[1] = CGIHGALEAEM;
		array2[1] = KFFMJGGCCGH;
		array2[2] = HANAIHNOMCJ;
		array2[0] = HDOEIEMJANC;
		array2[1] = IHDCGLIOEIF;
		text = text3 + string.Format("SquadMembers", array2);
		string text4 = text;
		object[] array3 = new object[5];
		array3[0] = EPJJFIEPPEI;
		array3[0] = NLEANDGDIGL;
		array3[4] = DCDONOEMPAJ;
		array3[1] = HGFPBDCNGMP;
		array3[2] = DDGEBMMBCDH;
		text = text4 + string.Format("menu-crown-bronze", array3);
		text += string.Format("Card_1_Played", GJGGMAEJLAP);
		string text5 = text;
		object[] array4 = new object[8];
		array4[0] = ANLPOCBOKFA;
		array4[1] = LEMFIOHBKCF;
		array4[8] = HGNIDLMHIFE;
		array4[6] = OKAGACLNLCJ;
		array4[0] = OMBMONINIGB;
		text = text5 + string.Format("ID_TUTORIAL_WARCARDS_STARTUP", array4);
		text += string.Format("PlayerLevel", ILBOGEIEPMF);
		return text + PIDGNNAAEFP();
	}

	[SpecialName]
	public int JPPDLMDMNCK()
	{
		return (int)((float)HDOEIEMJANC * Singleton<VipManager>.instance.LBMNNAPPDMC());
	}

	public IIGFODGJBFA(int FHGIMNGIPKK, int JLALCKPAGNI, int HMDCDHFELFA)
	{
		GJGGMAEJLAP = false;
		EPJJFIEPPEI = FHGIMNGIPKK;
		NLEANDGDIGL = 0;
		DCDONOEMPAJ = 0;
		HGFPBDCNGMP = 0;
		DDGEBMMBCDH = 1f;
		LIBCLGEENBB = JLALCKPAGNI;
		CMKMMOLDDOM = 0;
		HGGAKLGNDIE = 0;
		BMGOMCJOMLE = 0;
		PMEEBBIMLOE = 1f;
		KFFMJGGCCGH = HMDCDHFELFA;
		HANAIHNOMCJ = 0;
		HDOEIEMJANC = 0;
		CGIHGALEAEM = 0;
		IHDCGLIOEIF = 1f;
		KEJOAOJKKGH = 1f;
		OBJLNEFDKFJ = 1f;
		AMKJPAEJEKM = 1f;
		if (LDDKEHKEJBI == null)
		{
			LDDKEHKEJBI = new List<CCNAEIGGMNK>();
		}
		else
		{
			LDDKEHKEJBI.Clear();
		}
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			DCDONOEMPAJ += 5000;
		}
	}

	internal int EPEKCAJAGDJ()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)(EPJJFIEPPEI + NLEANDGDIGL) * DDGEBMMBCDH)) : ((int)((float)(EPJJFIEPPEI + NLEANDGDIGL) * Singleton<VipManager>.instance.ABLJCPDBCMH() * DDGEBMMBCDH));
	}

	[SpecialName]
	public bool LFFIOCNKPEJ()
	{
		return BMGOMCJOMLE <= 1 && CGIHGALEAEM > 1;
	}

	internal int DGHGLLCKFIN()
	{
		return AALFGLPAIPB() + GEEAJBCGFMH() + JLOEBJIOAEN();
	}

	[SpecialName]
	public int IMFGNLLJBMM()
	{
		return (int)((float)HDOEIEMJANC * Singleton<VipManager>.instance.vipGoldMultiplier);
	}

	[SpecialName]
	public string PANNGDLNFCD()
	{
		if (LDDKEHKEJBI == null || LDDKEHKEJBI.Count == 0)
		{
			return " ";
		}
		string text = "Dictionary created/cleared.\n";
		text += string.Format("Rule {0:D2}", AMKJPAEJEKM);
		foreach (CCNAEIGGMNK item in LDDKEHKEJBI)
		{
			text = text + item.GCHKGBHDMEN() + "squad";
		}
		return text;
	}

	[SpecialName]
	public int NCFNJJHKPNN()
	{
		return (int)((float)CGIHGALEAEM * Singleton<VipManager>.instance.BNPKNMAEAOO());
	}

	internal int LCIHCPAKPJJ()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)DCDONOEMPAJ * DDGEBMMBCDH)) : ((int)((float)DCDONOEMPAJ * Singleton<VipManager>.instance.vipXpMultiplier * DDGEBMMBCDH));
	}

	public void GIKKGAHPPFN(int HOKCINCJPIJ, float JIEPJDLLBGP)
	{
		OBJLNEFDKFJ = JIEPJDLLBGP;
		ILBOGEIEPMF = HOKCINCJPIJ;
		StatsManager.instance.data.squadPointsTotal += HOKCINCJPIJ;
		Debug.Log(string.Format("ID_WARNING_NOTENOUGHTLEVEL", HOKCINCJPIJ, JIEPJDLLBGP));
	}

	internal int OCGGKIACHJI()
	{
		return (!GJGGMAEJLAP) ? ((int)((float)DCDONOEMPAJ * DDGEBMMBCDH)) : ((int)((float)DCDONOEMPAJ * Singleton<VipManager>.instance.ABLJCPDBCMH() * DDGEBMMBCDH));
	}

	[SpecialName]
	public int CLPBDHNGDPB()
	{
		return OMBMONINIGB;
	}

	internal int LEHHOKLKHPI()
	{
		return (!GJGGMAEJLAP) ? BJMIEKGBHFI() : NPGLGKHJODJ;
	}

	internal int MLLKHJIJLHB()
	{
		return (!GJGGMAEJLAP) ? GGFNDHDOFGI() : JPPDLMDMNCK();
	}

	[SpecialName]
	public int FFOLGMIJEDE()
	{
		return OKAGACLNLCJ;
	}

	[SpecialName]
	public int IFNIJDIFDNG()
	{
		return (int)((float)HGGAKLGNDIE * Singleton<VipManager>.instance.JOPANADJBGK() * PMEEBBIMLOE);
	}

	[SpecialName]
	public int BINGFIEPMGP()
	{
		return (int)((float)BMGOMCJOMLE * Singleton<VipManager>.instance.JOPANADJBGK() * PMEEBBIMLOE);
	}

	internal int MCEHIKILNCJ()
	{
		return (!GJGGMAEJLAP) ? MHJFGOENBJI : HDKDPJNDGAJ;
	}

	[SpecialName]
	public int MOIHJNLHLEO()
	{
		return OKAGACLNLCJ;
	}

	[SpecialName]
	public int PCMCCNHDOHE()
	{
		return NCFNJJHKPNN() + MDEKKNCEDML() + BDNGCBEKMNB();
	}

	internal int FLFOOAJOGDP()
	{
		return (!GJGGMAEJLAP) ? PONLJJCIKKF : BDNGCBEKMNB();
	}

	public void MCCFNOMBBDB(int CJDHKJFKNAH, int GLODABHNMJO, int FGFFGKGLBII, float EDAFIGGJKEI)
	{
		LEMFIOHBKCF = CJDHKJFKNAH;
		KEJOAOJKKGH = EDAFIGGJKEI;
		if (CJDHKJFKNAH == 0)
		{
			LEMFIOHBKCF = GLODABHNMJO - HGNIDLMHIFE;
		}
		OKAGACLNLCJ = GLODABHNMJO;
		OMBMONINIGB = FGFFGKGLBII;
		Debug.Log(string.Format("#Game Rewards# - Medals old:{0} new:{1} Balance old:{2} new:{3} Remaining fights:{4} - (offer mult {5})", ANLPOCBOKFA, LEMFIOHBKCF, HGNIDLMHIFE, OKAGACLNLCJ, OMBMONINIGB, KEJOAOJKKGH));
	}

	[SpecialName]
	public int CDNLHNNKIME()
	{
		return OKAGACLNLCJ;
	}

	internal long FKIKOHDACEN()
	{
		return (!GJGGMAEJLAP) ? CNLNJKDJBBJ : CDCABGKPKPH;
	}

	[SpecialName]
	public List<CCNAEIGGMNK> CJKHCOMAGJL()
	{
		return LDDKEHKEJBI;
	}

	[SpecialName]
	public int MBLHLIHGKKE()
	{
		return HGNIDLMHIFE;
	}

	[SpecialName]
	public int CEPLELIPFKL()
	{
		return (int)((float)HGGAKLGNDIE * Singleton<VipManager>.instance.GBAAPABFEFJ() * PMEEBBIMLOE);
	}

	internal int KFMLDOKICLF()
	{
		return (!GJGGMAEJLAP) ? HMPJBGNNBHE : CIAGHIPJAPE();
	}

	internal long MJGFKEILJNF()
	{
		return (!GJGGMAEJLAP) ? CNLNJKDJBBJ : CDCABGKPKPH;
	}

	[SpecialName]
	public int MKCJEBMANOF()
	{
		return OKAGACLNLCJ;
	}
}
