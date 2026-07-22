using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CBBKFKCOLPP
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003CGCEKGKJBNEB_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _003CLKCKBKMKLGG_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003CNCICDPGKHNL_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CCHLHMOFNIMF_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CKDIMBHAGCBC_003Ek__BackingField;

	private int BEBCNKHDJDC;

	private int EECGPHJJLHN;

	private int KOENBBNGCGA;

	private int PGOFCHMMCDL;

	private PNFCNJHKBBN BKPEMBPBFLF;

	private int EHKKGDJGCAK;

	private List<Card> GCGJFOJENDL;

	private int BCDPLPIDJGM;

	private int CFCLPHCHEPP;

	private int HDGCLIOMMMM;

	private LevelBehaviour IINOIBMKAPI;

	private int HMMPONAIBOC;

	private List<Card> CCGELMHFCFG;

	private string EBBNLNJLOFL;

	public float PKIFGJGBBCP
	{
		[CompilerGenerated]
		get
		{
			return _003CGCEKGKJBNEB_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CGCEKGKJBNEB_003Ek__BackingField = value;
		}
	}

	public float MMNGHBHJPDL
	{
		[CompilerGenerated]
		get
		{
			return _003CLKCKBKMKLGG_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CLKCKBKMKLGG_003Ek__BackingField = value;
		}
	}

	public float PKDAIEJDIFF
	{
		[CompilerGenerated]
		get
		{
			return _003CNCICDPGKHNL_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CNCICDPGKHNL_003Ek__BackingField = value;
		}
	}

	public bool HMGOHGOLMJB
	{
		[CompilerGenerated]
		get
		{
			return _003CCHLHMOFNIMF_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCHLHMOFNIMF_003Ek__BackingField = value;
		}
	}

	public bool HOHCFBAPGFN
	{
		[CompilerGenerated]
		get
		{
			return _003CKDIMBHAGCBC_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CKDIMBHAGCBC_003Ek__BackingField = value;
		}
	}

	public List<Card> EEMPEECADGP => GCGJFOJENDL;

	public List<Card> JOKJABADGFH => CCGELMHFCFG;

	public int FPMJEDOCJKE => (int)((float)BEBCNKHDJDC * PKIFGJGBBCP * FEMLFIMJCKB);

	public int HAFMGCFMCPC => (int)((float)PGOFCHMMCDL * PKDAIEJDIFF * LBLGIKMIELO);

	public int KKAODKNEFMG => (int)((float)(EECGPHJJLHN + KOENBBNGCGA) * MMNGHBHJPDL);

	public int GGGEBJOEKPE => (int)((float)EECGPHJJLHN * MMNGHBHJPDL);

	public int MOLBBCELGCF => (int)((float)KOENBBNGCGA * MMNGHBHJPDL);

	private float FEMLFIMJCKB => (!HMGOHGOLMJB) ? 1f : Singleton<VipManager>.instance.vipWarbucksMultiplier;

	private float LBLGIKMIELO => (!HMGOHGOLMJB) ? 1f : Singleton<VipManager>.instance.vipGoldMultiplier;

	public bool GOFNDLHIFLM => CCGELMHFCFG.Count > 0;

	public int GAJIJKKEMGJ => (int)((float)BEBCNKHDJDC * PKIFGJGBBCP);

	public int DLHGGEHHCDI => (int)((float)BEBCNKHDJDC * PKIFGJGBBCP * Singleton<VipManager>.instance.vipWarbucksMultiplier);

	public int PJCCEDPHNML => (int)((float)PGOFCHMMCDL * PKDAIEJDIFF);

	public int MCBAJIAHCJB => (int)((float)PGOFCHMMCDL * PKDAIEJDIFF * Singleton<VipManager>.instance.vipGoldMultiplier);

	[SpecialName]
	public bool OILGNLDJKIL()
	{
		return _003CCHLHMOFNIMF_003Ek__BackingField;
	}

	[SpecialName]
	public int FMMOKCAPJHJ()
	{
		return (int)((float)KOENBBNGCGA * EOHAGODNKCE());
	}

	[SpecialName]
	private void MCNPILADBFP(bool IDEBKDPMPGM)
	{
		_003CKDIMBHAGCBC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private float MMBHHEKPKLO()
	{
		return (!KEFEHECBEHL()) ? 391f : Singleton<VipManager>.instance.JOPANADJBGK();
	}

	private void MHMCPKHLGOA(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("ID_CONFIRM_ERROR"))
		{
			UnityEngine.Debug.Log("-");
			EBBNLNJLOFL = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["()Ljava/lang/String;"], string.Empty);
		}
	}

	public CBBKFKCOLPP(Dictionary<string, object> EENKJBCCPBG)
	{
		UnityEngine.Debug.Log("#Mission Rewards# Mission Game Rewards Came");
		BEBCNKHDJDC = 0;
		EECGPHJJLHN = 0;
		KOENBBNGCGA = 0;
		PGOFCHMMCDL = 0;
		PKIFGJGBBCP = 1f;
		MMNGHBHJPDL = 1f;
		PKDAIEJDIFF = 1f;
		HMGOHGOLMJB = Singleton<VipManager>.instance.NOGEIPHFNPK();
		BKPEMBPBFLF = PNFCNJHKBBN.None;
		EHKKGDJGCAK = 0;
		GCGJFOJENDL = new List<Card>();
		BCDPLPIDJGM = 0;
		CFCLPHCHEPP = 0;
		HDGCLIOMMMM = 0;
		IINOIBMKAPI = null;
		HMMPONAIBOC = 0;
		CCGELMHFCFG = new List<Card>();
		HBLBNEMJDBL(EENKJBCCPBG);
		DJGHDJFKCDD(EENKJBCCPBG);
		CFIPPGGJKDE(EENKJBCCPBG);
		KNJBBJFBPKO(EENKJBCCPBG);
		FCDFOPIPHIO(EENKJBCCPBG);
		LLHGOFBJOHB(EENKJBCCPBG);
		if (DailyMissionsManager.instance.currentMission.isHeroic)
		{
			GuiScreenSingle<HeroicScreen>.instance.PrepareEndMissionAnimation();
		}
		else
		{
			GuiScreenSingle<DailyMissionScreen>.instance.PrepareEndMissionAnimation();
		}
	}

	[SpecialName]
	public int DBOFGMICJBG()
	{
		return (int)((float)BEBCNKHDJDC * NFLBOCODDGL() * Singleton<VipManager>.instance.vipWarbucksMultiplier);
	}

	[SpecialName]
	public int FNOOGIBICDL()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB());
	}

	[SpecialName]
	public int EPHCBHBJPJO()
	{
		return (int)((float)(EECGPHJJLHN + KOENBBNGCGA) * MJCHKOLDMHD());
	}

	private void KNFAEKGKGJP(Dictionary<string, object> EENKJBCCPBG)
	{
		MCNPILADBFP(EENKJBCCPBG.ContainsKey("Broadcast_Duration"));
		if (HOHCFBAPGFN)
		{
			DailyMissionsManager.instance.data.isHeroicOpened = false;
			UnityEngine.Debug.Log("HeroicPoints");
			GuiScreenSingle<DailyMissionScreen>.instance.DLMOKMBNDJF();
		}
	}

	[SpecialName]
	public int PIGHNCHDOOJ()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB() * LBLGIKMIELO);
	}

	[SpecialName]
	public int PNLOCOCIJEE()
	{
		return (int)((float)EECGPHJJLHN * EOHAGODNKCE());
	}

	[SpecialName]
	private void KHFKIDPDGAN(float IDEBKDPMPGM)
	{
		_003CGCEKGKJBNEB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public List<Card> LGMKOADBDOA()
	{
		return GCGJFOJENDL;
	}

	public void NHBDJABCIHC()
	{
		if (!string.IsNullOrEmpty(EBBNLNJLOFL))
		{
			UnityEngine.Debug.Log("#Mission Rewards# New missions data are loaded to client");
			DailyMissionsManager.instance.LoadFromJsonString(EBBNLNJLOFL);
			EBBNLNJLOFL = null;
		}
	}

	[SpecialName]
	public int MLEGLGNNFBF()
	{
		return (int)((float)BEBCNKHDJDC * NFLBOCODDGL());
	}

	[SpecialName]
	public float LEKGOMLLBMA()
	{
		return _003CGCEKGKJBNEB_003Ek__BackingField;
	}

	private void INMAHALJMEM(Dictionary<string, object> EENKJBCCPBG)
	{
		DLAMIGNILMH(EENKJBCCPBG.ContainsKey(" "));
		if (HOHCFBAPGFN)
		{
			DailyMissionsManager.instance.data.isHeroicOpened = true;
			UnityEngine.Debug.Log("#PLAYERID# Saving Player Account with PlayerId = ");
			GuiScreenSingle<DailyMissionScreen>.instance.MLALNLKHJNM();
		}
	}

	[SpecialName]
	private float NNLBHBBIHJG()
	{
		return (!KEFEHECBEHL()) ? 628f : Singleton<VipManager>.instance.vipWarbucksMultiplier;
	}

	[SpecialName]
	private void PGKEDPLNJJK(float IDEBKDPMPGM)
	{
		_003CGCEKGKJBNEB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool KEFEHECBEHL()
	{
		return _003CCHLHMOFNIMF_003Ek__BackingField;
	}

	private void JNNGFLGOPIJ(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("Wrong_Category"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_CLAIM"], 1);
			DailyMissionsManager.instance.data.heroicPoints = num;
			UnityEngine.Debug.Log("Camosmanager.prefab" + num);
		}
	}

	[SpecialName]
	public List<Card> CBENGCPINIF()
	{
		return CCGELMHFCFG;
	}

	[SpecialName]
	public List<Card> NBCFHNBADID()
	{
		return GCGJFOJENDL;
	}

	[SpecialName]
	public int OGOCAFCNOKE()
	{
		return (int)((float)PGOFCHMMCDL * PKDAIEJDIFF * Singleton<VipManager>.instance.vipGoldMultiplier);
	}

	[SpecialName]
	private void DLAMIGNILMH(bool IDEBKDPMPGM)
	{
		_003CKDIMBHAGCBC_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void MDEBDKHGJCP(Dictionary<string, object> EENKJBCCPBG)
	{
		JToken jToken = ((!EENKJBCCPBG.ContainsKey("VIPMemeberShipAlmostEnded")) ? null : ((JToken)EENKJBCCPBG["VipReward2"]));
		if (jToken != null)
		{
			UnityEngine.Debug.Log("StartTime" + jToken);
		}
		if (jToken["ID_WAITINGFORFRIEND"] != null)
		{
			BEBCNKHDJDC += jToken["RemoveOld"]["Ranks/"].ToObject<int>();
			BEBCNKHDJDC += jToken["ok"]["Generate army 3"].ToObject<int>();
			BEBCNKHDJDC += jToken["helicopter_jump_pose"]["\"{0}\"\t"].ToObject<int>();
			BEBCNKHDJDC += jToken["ID_EXTRAWARCARDSLOT"]["cardPack"].ToObject<int>();
			if (jToken["Description"]["Beanstalk: Hashed id of fb friend "] != null)
			{
				PKIFGJGBBCP = jToken["N"]["cn"].ToObject<float>();
			}
		}
		if (jToken["menu-gold"] != null)
		{
			EECGPHJJLHN += jToken["ID_TUTORIAL_UPGRADEWEAPON_6"]["ID_READYTIME"].ToObject<int>();
			EECGPHJJLHN += jToken["Skillshot 0000"]["WinCount"].ToObject<int>();
			EECGPHJJLHN += jToken["Notifications"]["Chillingo: On Offers Released"].ToObject<int>();
			KOENBBNGCGA += jToken["ExceptionStacktrace"]["ID_INGOLD2"].ToObject<int>();
			if (jToken["OldSquadRank"]["Reported"] != null)
			{
				MMNGHBHJPDL = jToken["Fake DatabaseMessage - SquadDemoteMessage - Player:{0}\t\tNewRank:{1}"]["KickedPlayerDepositedCards"].ToObject<float>();
			}
		}
		if (jToken["name"] != null)
		{
			PGOFCHMMCDL += jToken["special"]["ID_TUTORIAL_OBJECTIVE"].ToObject<int>();
			PGOFCHMMCDL += jToken["Arena Lost - Scraps received = "]["NAME"].ToObject<int>();
			if (jToken["Something went wrong in updating players in league"]["ID_STAYINDIVISION"] != null)
			{
				PKDAIEJDIFF = jToken["Player {0} {1}"]["Configurations hacked"].ToObject<float>();
			}
		}
		else if (jToken["Directory \"{0}\" does not exists"] != null)
		{
			PGOFCHMMCDL += jToken["author"].ToObject<int>();
		}
		HMGOHGOLMJB = jToken["ID_CONFIRM_ALREADYLEADER"] != null && jToken["ID_SALEPERCENTLINE"].ToObject<bool>();
		if (NGJJDHGCIOJ() > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("ID_NOTINLEAGUETEXTANDHINT", DMBIHADLMOC());
		}
		if (FPMJEDOCJKE > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterWBIn("In queue", PKOENKBELLO());
		}
		Singleton<Wallet>.instance.HCBKOHCEFDJ(PIGHNCHDOOJ(), CFBCCEIHGJD(), 0L, 1L);
	}

	[SpecialName]
	public int OFMOIEKLFNA()
	{
		return (int)((float)BEBCNKHDJDC * LFIGMCMPKIE() * IFIBOCFIKDO());
	}

	public void GIPICGLPFPC()
	{
		if (IINOIBMKAPI != null && HMMPONAIBOC > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)41, IINOIBMKAPI, HMMPONAIBOC));
		}
		if (BCDPLPIDJGM > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, BCDPLPIDJGM));
		}
		if (CCGELMHFCFG != null && CCGELMHFCFG.Count > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.CardPack, DailyMissionsManager.instance.IFMAHECILCC(), CCGELMHFCFG.ToArray()), LJMMJDNNIFH: true);
		}
		if (CFCLPHCHEPP > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)25, CFCLPHCHEPP));
		}
		if (HDGCLIOMMMM > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)(-24), HDGCLIOMMMM), LJMMJDNNIFH: true);
		}
	}

	[SpecialName]
	public int KKDLMMKDDDC()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB() * Singleton<VipManager>.instance.LBMNNAPPDMC());
	}

	[SpecialName]
	private void MOBPELGJAMI(float IDEBKDPMPGM)
	{
		_003CGCEKGKJBNEB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int PFMIKPCNAFD()
	{
		return (int)((float)PGOFCHMMCDL * PKDAIEJDIFF * Singleton<VipManager>.instance.vipGoldMultiplier);
	}

	[SpecialName]
	public float EOGIFGDBIEB()
	{
		return _003CNCICDPGKHNL_003Ek__BackingField;
	}

	[SpecialName]
	public int MGGBFIIGCMH()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB() * Singleton<VipManager>.instance.LBMNNAPPDMC());
	}

	public void KJOIODINDPC()
	{
		if (!string.IsNullOrEmpty(EBBNLNJLOFL))
		{
			UnityEngine.Debug.Log("OnDeathRPC");
			DailyMissionsManager.instance.LoadFromJsonString(EBBNLNJLOFL);
			EBBNLNJLOFL = null;
		}
	}

	[SpecialName]
	public int GOJNFGPANFI()
	{
		return (int)((float)EECGPHJJLHN * EOHAGODNKCE());
	}

	[SpecialName]
	public int CMKMEEGKJII()
	{
		return (int)((float)(EECGPHJJLHN + KOENBBNGCGA) * MMNGHBHJPDL);
	}

	[SpecialName]
	public int KLBLCIAEDJA()
	{
		return (int)((float)BEBCNKHDJDC * NFLBOCODDGL() * Singleton<VipManager>.instance.GBAAPABFEFJ());
	}

	[SpecialName]
	public int IEFGHIOKCPN()
	{
		return (int)((float)BEBCNKHDJDC * NFGEMJDOBCA() * FEMLFIMJCKB);
	}

	private void OMHEALHGNJB(Dictionary<string, object> EENKJBCCPBG)
	{
		IHAHBLKBGNC(EENKJBCCPBG.ContainsKey("HeroicMissionsCompletionRewardGold"));
		if (BOLJCPALMDE())
		{
			DailyMissionsManager.instance.data.isHeroicOpened = true;
			UnityEngine.Debug.Log("{0} {1}{2}");
			GuiScreenSingle<DailyMissionScreen>.instance.MHIDNMDAJNI();
		}
	}

	private void OJICBEIIFDN(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("20-29"))
		{
			UnityEngine.Debug.Log("pt");
			EBBNLNJLOFL = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["N"], string.Empty);
		}
	}

	public CBBKFKCOLPP(int FHGIMNGIPKK, int JLALCKPAGNI, int HMDCDHFELFA)
	{
		EECGPHJJLHN = FHGIMNGIPKK;
		BEBCNKHDJDC = JLALCKPAGNI;
		PGOFCHMMCDL = HMDCDHFELFA;
		MMNGHBHJPDL = 1f;
		PKDAIEJDIFF = 1f;
		PKIFGJGBBCP = 1f;
	}

	[SpecialName]
	public List<Card> AIENCLDFPNP()
	{
		return CCGELMHFCFG;
	}

	[SpecialName]
	public bool HCMJMCGLKHM()
	{
		return CCGELMHFCFG.Count > 1;
	}

	private void FCDFOPIPHIO(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("DailyMissionsCompletionRewardGold"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["DailyMissionsCompletionRewardGold"]);
			BKPEMBPBFLF = PNFCNJHKBBN.Gold;
			Singleton<Wallet>.instance.COLJGNLBEII(EHKKGDJGCAK);
			UnityEngine.Debug.LogFormat("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} gold", EHKKGDJGCAK);
		}
		if (EENKJBCCPBG.ContainsKey("DailyMissionsCompletionRewardTickets"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["DailyMissionsCompletionRewardTickets"]);
			BKPEMBPBFLF = PNFCNJHKBBN.ArenaTickets;
			Singleton<Wallet>.instance.AddTickets(EHKKGDJGCAK);
			UnityEngine.Debug.LogFormat("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} arena tickets", EHKKGDJGCAK);
			Singleton<EventTrackingManager>.instance.TicketsGained("MissionReward", EHKKGDJGCAK);
		}
		if (EENKJBCCPBG.ContainsKey("DailyMissionsCompletionRewardScraps"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["DailyMissionsCompletionRewardScraps"]);
			BKPEMBPBFLF = PNFCNJHKBBN.Scraps;
			Singleton<Wallet>.instance.AddScraps(EHKKGDJGCAK);
			Singleton<EventTrackingManager>.instance.ScrapsGained("MissionReward", EHKKGDJGCAK);
			UnityEngine.Debug.LogFormat("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} scraps", EHKKGDJGCAK);
		}
		if (!EENKJBCCPBG.ContainsKey("DailyMissionsCompletionRewardCards"))
		{
			return;
		}
		JArray jArray = (JArray)EENKJBCCPBG["DailyMissionsCompletionRewardCards"];
		EHKKGDJGCAK = jArray.Count;
		BKPEMBPBFLF = PNFCNJHKBBN.BronzeWarCards;
		UnityEngine.Debug.LogFormat("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} warcards", EHKKGDJGCAK);
		JToken jToken = null;
		foreach (JToken item2 in jArray)
		{
			jToken = item2;
			Card item = CardManager.instance.AddCard(jToken.ToObject<string>());
			GCGJFOJENDL.Add(item);
		}
	}

	[SpecialName]
	public float LFIGMCMPKIE()
	{
		return _003CGCEKGKJBNEB_003Ek__BackingField;
	}

	public void FHDMBKAPNLO()
	{
		if (IINOIBMKAPI != null && HMMPONAIBOC > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.EliteParts, IINOIBMKAPI, HMMPONAIBOC));
		}
		if (BCDPLPIDJGM > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, BCDPLPIDJGM));
		}
		if (CCGELMHFCFG != null && CCGELMHFCFG.Count > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.CardPack, DailyMissionsManager.instance.heroicCardpack, CCGELMHFCFG.ToArray()));
		}
		if (CFCLPHCHEPP > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Tickets, CFCLPHCHEPP));
		}
		if (HDGCLIOMMMM > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Scraps, HDGCLIOMMMM));
		}
	}

	[SpecialName]
	public int HOMCDDOBFBE()
	{
		return (int)((float)BEBCNKHDJDC * NFLBOCODDGL() * Singleton<VipManager>.instance.vipWarbucksMultiplier);
	}

	public void IHMBJKPNIDC()
	{
		if (!string.IsNullOrEmpty(EBBNLNJLOFL))
		{
			UnityEngine.Debug.Log("width");
			DailyMissionsManager.instance.LoadFromJsonString(EBBNLNJLOFL);
			EBBNLNJLOFL = null;
		}
	}

	[SpecialName]
	public List<Card> DJIANIFMJGN()
	{
		return CCGELMHFCFG;
	}

	[SpecialName]
	public int CFBCCEIHGJD()
	{
		return (int)((float)BEBCNKHDJDC * PKIFGJGBBCP * MMBHHEKPKLO());
	}

	private void HBLBNEMJDBL(Dictionary<string, object> EENKJBCCPBG)
	{
		JToken jToken = ((!EENKJBCCPBG.ContainsKey("GameReward")) ? null : ((JToken)EENKJBCCPBG["GameReward"]));
		if (jToken != null)
		{
			UnityEngine.Debug.Log("#Mission Rewards# Game Rewards:\n" + jToken);
		}
		if (jToken["Warbucks"] != null)
		{
			BEBCNKHDJDC += jToken["Warbucks"]["BattleRewards"].ToObject<int>();
			BEBCNKHDJDC += jToken["Warbucks"]["ExtraRewards"].ToObject<int>();
			BEBCNKHDJDC += jToken["Warbucks"]["Winstreak"].ToObject<int>();
			BEBCNKHDJDC += jToken["Warbucks"]["League"].ToObject<int>();
			if (jToken["Warbucks"]["offerMult"] != null)
			{
				PKIFGJGBBCP = jToken["Warbucks"]["offerMult"].ToObject<float>();
			}
		}
		if (jToken["Xp"] != null)
		{
			EECGPHJJLHN += jToken["Xp"]["BattleRewards"].ToObject<int>();
			EECGPHJJLHN += jToken["Xp"]["ExtraRewards"].ToObject<int>();
			EECGPHJJLHN += jToken["Xp"]["Winstreak"].ToObject<int>();
			KOENBBNGCGA += jToken["Xp"]["Time"].ToObject<int>();
			if (jToken["Xp"]["offerMult"] != null)
			{
				MMNGHBHJPDL = jToken["Xp"]["offerMult"].ToObject<float>();
			}
		}
		if (jToken["GameGold"] != null)
		{
			PGOFCHMMCDL += jToken["GameGold"]["BattleRewards"].ToObject<int>();
			PGOFCHMMCDL += jToken["GameGold"]["League"].ToObject<int>();
			if (jToken["GameGold"]["offerMult"] != null)
			{
				PKDAIEJDIFF = jToken["GameGold"]["offerMult"].ToObject<float>();
			}
		}
		else if (jToken["Gold"] != null)
		{
			PGOFCHMMCDL += jToken["Gold"].ToObject<int>();
		}
		HMGOHGOLMJB = jToken["IsVip"] != null && jToken["IsVip"].ToObject<bool>();
		if (HAFMGCFMCPC > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("DailyMission", HAFMGCFMCPC);
		}
		if (FPMJEDOCJKE > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterWBIn("DailyMission", FPMJEDOCJKE);
		}
		Singleton<Wallet>.instance.IGDGGPOJPHL(HAFMGCFMCPC, FPMJEDOCJKE, 0L, 0L);
	}

	[SpecialName]
	public int DJPNAACEGFF()
	{
		return (int)((float)BEBCNKHDJDC * LFIGMCMPKIE() * Singleton<VipManager>.instance.GBAAPABFEFJ());
	}

	private void FBDPONJPBNI(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("506 MENU ARMY SCREEN UPGRADE ACTIVATED"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["0"], 1);
			BKPEMBPBFLF = PNFCNJHKBBN.Gold;
			Singleton<Wallet>.instance.COLJGNLBEII(EHKKGDJGCAK);
			UnityEngine.Debug.LogFormat("VipRewardForDay", EHKKGDJGCAK);
		}
		if (EENKJBCCPBG.ContainsKey("Shots_Fired"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["DepositedCards"]);
			BKPEMBPBFLF = PNFCNJHKBBN.BronzeCardpack;
			Singleton<Wallet>.instance.AddTickets(EHKKGDJGCAK);
			object[] array = new object[0];
			array[0] = EHKKGDJGCAK;
			UnityEngine.Debug.LogFormat("country-egypt", array);
			Singleton<EventTrackingManager>.instance.TicketsGained("Player", EHKKGDJGCAK);
		}
		if (EENKJBCCPBG.ContainsKey("Freeze game:"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["MineCards"], 1);
			BKPEMBPBFLF = PNFCNJHKBBN.BronzeCardpack;
			Singleton<Wallet>.instance.AddScraps(EHKKGDJGCAK);
			Singleton<EventTrackingManager>.instance.ScrapsGained("SpentParts", EHKKGDJGCAK);
			object[] array2 = new object[0];
			array2[0] = EHKKGDJGCAK;
			UnityEngine.Debug.LogFormat(" Golds for squad event - completed tier ", array2);
		}
		if (!EENKJBCCPBG.ContainsKey("_MatCap"))
		{
			return;
		}
		JArray jArray = (JArray)EENKJBCCPBG["ID_FEATURE_BURSTSIZE-WEAPONPREFIX"];
		EHKKGDJGCAK = jArray.Count;
		BKPEMBPBFLF = (PNFCNJHKBBN)72;
		UnityEngine.Debug.LogFormat("Show2RPC", EHKKGDJGCAK);
		JToken jToken = null;
		foreach (JToken item2 in jArray)
		{
			jToken = item2;
			Card item = CardManager.instance.AddCard(jToken.ToObject<string>());
			GCGJFOJENDL.Add(item);
		}
	}

	private void MGHGBLAMALI(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("Daily_mission_start_heroic"))
		{
			UnityEngine.Debug.Log("{0} {1} {2} {3}");
			EBBNLNJLOFL = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Password"], string.Empty);
		}
	}

	[SpecialName]
	public int DMDLGPFEMAP()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB() * Singleton<VipManager>.instance.BNPKNMAEAOO());
	}

	[SpecialName]
	public int POKDHNAANNA()
	{
		return (int)((float)BEBCNKHDJDC * LEKGOMLLBMA() * Singleton<VipManager>.instance.JOPANADJBGK());
	}

	public void FOMBLGNKDKL()
	{
		if (BKPEMBPBFLF == PNFCNJHKBBN.Gold)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)(-68), EHKKGDJGCAK), LJMMJDNNIFH: true);
		}
		if (BKPEMBPBFLF == PNFCNJHKBBN.EliteParts)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)65, EHKKGDJGCAK));
		}
		if (BKPEMBPBFLF == PNFCNJHKBBN.EliteParts)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EHKKGDJGCAK), LJMMJDNNIFH: true);
		}
	}

	public void CPHMJMIIHCD()
	{
		if (!string.IsNullOrEmpty(EBBNLNJLOFL))
		{
			UnityEngine.Debug.Log("CONFIRMAR");
			DailyMissionsManager.instance.LoadFromJsonString(EBBNLNJLOFL);
			EBBNLNJLOFL = null;
		}
	}

	private void CFIPPGGJKDE(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("DailyMissionsData"))
		{
			UnityEngine.Debug.Log("#Mission Rewards# New missions data (midnight or heroic completed)");
			EBBNLNJLOFL = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DailyMissionsData"], string.Empty);
		}
	}

	private void OOEBPECLBAJ(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("Player entered normal league: {0} and beginners league: {1}"))
		{
			BCDPLPIDJGM = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Locale"]);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(BCDPLPIDJGM, AJNINHIKAFC: false);
			object[] array = new object[0];
			array[1] = BCDPLPIDJGM;
			UnityEngine.Debug.LogFormat("menu-weaponstats-rateoffire", array);
		}
		if (EENKJBCCPBG.ContainsKey("{0}{1} / {2}"))
		{
			CFCLPHCHEPP = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["PlayerVisuals"], 1);
			Singleton<Wallet>.instance.OLAOFCJHNEM(CFCLPHCHEPP);
			Singleton<EventTrackingManager>.instance.TicketsGained("ID_ARENALOOTBOXSCRAPS", CFCLPHCHEPP);
			object[] array2 = new object[0];
			array2[1] = CFCLPHCHEPP;
			UnityEngine.Debug.LogFormat("RewardAmount", array2);
		}
		if (EENKJBCCPBG.ContainsKey("com/google/android/gms/games/Games"))
		{
			HDGCLIOMMMM = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG[" {0}{1}"], 1);
			Singleton<Wallet>.instance.DHIBMBCMBFM(HDGCLIOMMMM);
			object[] array3 = new object[0];
			array3[0] = HDGCLIOMMMM;
			UnityEngine.Debug.LogFormat("#VOJTA# ON GET NEW DAILY MISSIONS", array3);
			Singleton<EventTrackingManager>.instance.ScrapsGained("global", HDGCLIOMMMM);
		}
		if (EENKJBCCPBG.ContainsKey("TryRecconnect TryRecconnectToPhotonCoroutine going to reconnect"))
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["run_grenadelauncher"], string.Empty);
			HMMPONAIBOC = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["PlayerId"]);
			IINOIBMKAPI = LevelManager.instance.Unit(text);
			Singleton<EventTrackingManager>.instance.ElitePartsGained("ID_TUTORIAL_PROGRES_THROW", HMMPONAIBOC);
			if (IINOIBMKAPI == null)
			{
				object[] array4 = new object[0];
				array4[0] = text;
				UnityEngine.Debug.LogErrorFormat("03", array4);
			}
			else
			{
				UpgradeSlotElite upgradeSlotElite = IINOIBMKAPI.upgradeSlots.upgradeSlotElite;
				upgradeSlotElite.HJDGAPEOIGM(upgradeSlotElite.currentParts + HMMPONAIBOC);
				object[] array5 = new object[3];
				array5[1] = HMMPONAIBOC;
				array5[0] = text;
				UnityEngine.Debug.LogFormat("Network pool: InstantiatePooledObjects '", array5);
			}
		}
		if (!EENKJBCCPBG.ContainsKey("ID_ARENAISOPEN"))
		{
			return;
		}
		JArray jArray = (JArray)EENKJBCCPBG["GameController: Starting tutorial"];
		UnityEngine.Debug.LogFormat("DOWNLOADBTN", jArray.Count);
		JToken jToken = null;
		foreach (JToken item2 in jArray)
		{
			jToken = item2;
			Card item = CardManager.instance.AddCard(jToken.ToObject<string>());
			CCGELMHFCFG.Add(item);
		}
	}

	[SpecialName]
	public float EOHAGODNKCE()
	{
		return _003CLKCKBKMKLGG_003Ek__BackingField;
	}

	[SpecialName]
	public List<Card> OOPHDAOHGNF()
	{
		return GCGJFOJENDL;
	}

	private void CCPICGNCHJD(Dictionary<string, object> EENKJBCCPBG)
	{
		IHAHBLKBGNC(EENKJBCCPBG.ContainsKey("{0}{1}{2} {3}"));
		if (HOHCFBAPGFN)
		{
			DailyMissionsManager.instance.data.isHeroicOpened = false;
			UnityEngine.Debug.Log("MessageType");
			GuiScreenSingle<DailyMissionScreen>.instance.DLMOKMBNDJF();
		}
	}

	public void LFEIKGBPFOP()
	{
		if (IINOIBMKAPI != null && HMMPONAIBOC > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)74, IINOIBMKAPI, HMMPONAIBOC), LJMMJDNNIFH: true);
		}
		if (BCDPLPIDJGM > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, BCDPLPIDJGM), LJMMJDNNIFH: true);
		}
		if (CCGELMHFCFG != null && CCGELMHFCFG.Count > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Warbucks, DailyMissionsManager.instance.heroicCardpack, CCGELMHFCFG.ToArray()));
		}
		if (CFCLPHCHEPP > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)83, CFCLPHCHEPP), LJMMJDNNIFH: true);
		}
		if (HDGCLIOMMMM > 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)(-16), HDGCLIOMMMM), LJMMJDNNIFH: true);
		}
	}

	[SpecialName]
	public float MJCHKOLDMHD()
	{
		return _003CLKCKBKMKLGG_003Ek__BackingField;
	}

	private void KNJBBJFBPKO(Dictionary<string, object> EENKJBCCPBG)
	{
		HOHCFBAPGFN = EENKJBCCPBG.ContainsKey("HeroicMissionsUnlocked");
		if (HOHCFBAPGFN)
		{
			DailyMissionsManager.instance.data.isHeroicOpened = true;
			UnityEngine.Debug.Log("#Mission Rewards# Heroic was opened");
			GuiScreenSingle<DailyMissionScreen>.instance.HeroicOpened();
		}
	}

	[SpecialName]
	public bool BOLJCPALMDE()
	{
		return _003CKDIMBHAGCBC_003Ek__BackingField;
	}

	private void KKBFLNLJBOH(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("SyncShield"))
		{
			BCDPLPIDJGM = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Player_level"]);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(BCDPLPIDJGM, AJNINHIKAFC: false);
			UnityEngine.Debug.LogFormat("Card ", BCDPLPIDJGM);
		}
		if (EENKJBCCPBG.ContainsKey("warbucks"))
		{
			CFCLPHCHEPP = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["idle"], 1);
			Singleton<Wallet>.instance.AddTickets(CFCLPHCHEPP);
			Singleton<EventTrackingManager>.instance.TicketsGained("_DistanceParams", CFCLPHCHEPP);
			object[] array = new object[0];
			array[1] = CFCLPHCHEPP;
			UnityEngine.Debug.LogFormat("Item_ID", array);
		}
		if (EENKJBCCPBG.ContainsKey("BoughtIndex"))
		{
			HDGCLIOMMMM = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_GOLDC"]);
			Singleton<Wallet>.instance.DHIBMBCMBFM(HDGCLIOMMMM);
			object[] array2 = new object[0];
			array2[0] = HDGCLIOMMMM;
			UnityEngine.Debug.LogFormat("AssignmentsUpdate", array2);
			Singleton<EventTrackingManager>.instance.ScrapsGained("#AccoutCheck# missing ID from server", HDGCLIOMMMM);
		}
		if (EENKJBCCPBG.ContainsKey("WinCount"))
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["shop"], string.Empty);
			HMMPONAIBOC = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["PackId"], 1);
			IINOIBMKAPI = LevelManager.instance.Unit(text);
			Singleton<EventTrackingManager>.instance.ElitePartsGained("ELITEPARA", HMMPONAIBOC);
			if (IINOIBMKAPI == null)
			{
				object[] array3 = new object[0];
				array3[0] = text;
				UnityEngine.Debug.LogErrorFormat("DailyMissionsCompletionRewardGold", array3);
			}
			else
			{
				UpgradeSlotElite upgradeSlotElite = IINOIBMKAPI.upgradeSlots.upgradeSlotElite;
				upgradeSlotElite.LOHDPALFBPI(upgradeSlotElite.HMPNFKJHKGG() + HMMPONAIBOC);
				object[] array4 = new object[5];
				array4[0] = HMMPONAIBOC;
				array4[0] = text;
				UnityEngine.Debug.LogFormat("Parts", array4);
			}
		}
		if (!EENKJBCCPBG.ContainsKey("elite"))
		{
			return;
		}
		JArray jArray = (JArray)EENKJBCCPBG["Arena Lives: "];
		UnityEngine.Debug.LogFormat("gold", jArray.Count);
		JToken jToken = null;
		foreach (JToken item2 in jArray)
		{
			jToken = item2;
			Card item = CardManager.instance.AddCard(jToken.ToObject<string>());
			CCGELMHFCFG.Add(item);
		}
	}

	[SpecialName]
	public int GEMMHIMAPBO()
	{
		return (int)((float)KOENBBNGCGA * EOHAGODNKCE());
	}

	[SpecialName]
	public int FNHBBABHAAM()
	{
		return (int)((float)BEBCNKHDJDC * LEKGOMLLBMA() * Singleton<VipManager>.instance.GBAAPABFEFJ());
	}

	private void BCGJDEFIJCO(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("Configuration Error: sheet "))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ReputationPointsAdded"]);
			DailyMissionsManager.instance.data.heroicPoints = num;
			UnityEngine.Debug.Log("/" + num);
		}
	}

	private void OOPBOFBLOJD(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("Is_Against_Bot"))
		{
			UnityEngine.Debug.Log("ID_SKILLSHOTHINT_DOUBLEKILL");
			EBBNLNJLOFL = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["========Session Update============"], string.Empty);
		}
	}

	[SpecialName]
	public List<Card> MDPJGPOIFDB()
	{
		return CCGELMHFCFG;
	}

	private void LLHGOFBJOHB(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("HeroicMissionsCompletionRewardGold"))
		{
			BCDPLPIDJGM = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["HeroicMissionsCompletionRewardGold"]);
			Singleton<Wallet>.instance.COLJGNLBEII(BCDPLPIDJGM);
			UnityEngine.Debug.LogFormat("#Mission Rewards# 5 Heroic Missions completed. Gained {0} gold", BCDPLPIDJGM);
		}
		if (EENKJBCCPBG.ContainsKey("HeroicMissionsCompletionRewardTickets"))
		{
			CFCLPHCHEPP = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["HeroicMissionsCompletionRewardTickets"]);
			Singleton<Wallet>.instance.AddTickets(CFCLPHCHEPP);
			Singleton<EventTrackingManager>.instance.TicketsGained("HeroicReward", CFCLPHCHEPP);
			UnityEngine.Debug.LogFormat("#Mission Rewards# 5 Heroic Missions completed. Gained {0} arena tickets", CFCLPHCHEPP);
		}
		if (EENKJBCCPBG.ContainsKey("HeroicMissionsCompletionRewardScraps"))
		{
			HDGCLIOMMMM = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["HeroicMissionsCompletionRewardScraps"]);
			Singleton<Wallet>.instance.AddScraps(HDGCLIOMMMM);
			UnityEngine.Debug.LogFormat("#Mission Rewards# 5 Heroic Missions completed. Gained {0} scraps", HDGCLIOMMMM);
			Singleton<EventTrackingManager>.instance.ScrapsGained("HeroicReward", HDGCLIOMMMM);
		}
		if (EENKJBCCPBG.ContainsKey("HeroicMissionsCompletionRewardArmyUnitId"))
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["HeroicMissionsCompletionRewardArmyUnitId"], string.Empty);
			HMMPONAIBOC = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["HeroicMissionsCompletionRewardArmyUnitParts"]);
			IINOIBMKAPI = LevelManager.instance.Unit(text);
			Singleton<EventTrackingManager>.instance.ElitePartsGained("HeroicReward", HMMPONAIBOC);
			if (IINOIBMKAPI == null)
			{
				UnityEngine.Debug.LogErrorFormat("#Mission Rewards# 5 Heroic Missions completed. Unit {0} does not exists!", text);
			}
			else
			{
				IINOIBMKAPI.upgradeSlots.upgradeSlotElite.currentParts += HMMPONAIBOC;
				UnityEngine.Debug.LogFormat("#Mission Rewards# 5 Heroic Missions completed. Gained {0} {1} elite parts", HMMPONAIBOC, text);
			}
		}
		if (!EENKJBCCPBG.ContainsKey("HeroicMissionsCompletionRewardCardPack"))
		{
			return;
		}
		JArray jArray = (JArray)EENKJBCCPBG["HeroicMissionsCompletionRewardCardPack"];
		UnityEngine.Debug.LogFormat("#Mission Rewards# 5 Heroic Missions completed. Gained {0} warcards", jArray.Count);
		JToken jToken = null;
		foreach (JToken item2 in jArray)
		{
			jToken = item2;
			Card item = CardManager.instance.AddCard(jToken.ToObject<string>());
			CCGELMHFCFG.Add(item);
		}
	}

	private void OOCIPGNFBLD(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("ERROR WRONG DAILY REWARDS: "))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Country"]);
			BKPEMBPBFLF = PNFCNJHKBBN.EliteParts;
			Singleton<Wallet>.instance.BKFOPCDLPCJ(EHKKGDJGCAK, AJNINHIKAFC: false);
			object[] array = new object[1];
			array[1] = EHKKGDJGCAK;
			UnityEngine.Debug.LogFormat("    ", array);
		}
		if (EENKJBCCPBG.ContainsKey("animationEnd"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["IsVip"]);
			BKPEMBPBFLF = PNFCNJHKBBN.Scraps;
			Singleton<Wallet>.instance.OLAOFCJHNEM(EHKKGDJGCAK);
			object[] array2 = new object[0];
			array2[1] = EHKKGDJGCAK;
			UnityEngine.Debug.LogFormat("LevelName", array2);
			Singleton<EventTrackingManager>.instance.TicketsGained("ID_CRAFTABLEWARCARDS", EHKKGDJGCAK);
		}
		if (EENKJBCCPBG.ContainsKey("ID_WARNING_OPPONENTDISCONNECTED"))
		{
			EHKKGDJGCAK = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Skill"]);
			BKPEMBPBFLF = PNFCNJHKBBN.WarBucks;
			Singleton<Wallet>.instance.AddScraps(EHKKGDJGCAK);
			Singleton<EventTrackingManager>.instance.ScrapsGained("ID_MAX", EHKKGDJGCAK);
			UnityEngine.Debug.LogFormat("ID_READYTIME", EHKKGDJGCAK);
		}
		if (!EENKJBCCPBG.ContainsKey("Beanstalk: Deposit these cards = "))
		{
			return;
		}
		JArray jArray = (JArray)EENKJBCCPBG["ID_MEMBERSHIP_HINT1"];
		EHKKGDJGCAK = jArray.Count;
		BKPEMBPBFLF = (PNFCNJHKBBN)56;
		object[] array3 = new object[0];
		array3[0] = EHKKGDJGCAK;
		UnityEngine.Debug.LogFormat("Warp", array3);
		JToken jToken = null;
		foreach (JToken item2 in jArray)
		{
			jToken = item2;
			Card item = CardManager.instance.AddCard(jToken.ToObject<string>());
			GCGJFOJENDL.Add(item);
		}
	}

	[SpecialName]
	public int PHALKBKMJIK()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB());
	}

	public void HMKIILAPCDD()
	{
		if (!string.IsNullOrEmpty(EBBNLNJLOFL))
		{
			UnityEngine.Debug.Log("testingidsquadrankup");
			DailyMissionsManager.instance.LoadFromJsonString(EBBNLNJLOFL);
			EBBNLNJLOFL = null;
		}
	}

	private void NEGJAABBCPC(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("ID_UNITCOMBINATIONSAVED"))
		{
			UnityEngine.Debug.Log("]");
			EBBNLNJLOFL = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["GooglePlay"], string.Empty);
		}
	}

	[SpecialName]
	public int NGJJDHGCIOJ()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB() * LBLGIKMIELO);
	}

	[SpecialName]
	private void EIHFPJPJLNM(float IDEBKDPMPGM)
	{
		_003CNCICDPGKHNL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void IHAHBLKBGNC(bool IDEBKDPMPGM)
	{
		_003CKDIMBHAGCBC_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void NGJLLGJMOKF()
	{
		if (!string.IsNullOrEmpty(EBBNLNJLOFL))
		{
			UnityEngine.Debug.Log("null facebook friends");
			DailyMissionsManager.instance.LoadFromJsonString(EBBNLNJLOFL);
			EBBNLNJLOFL = null;
		}
	}

	[SpecialName]
	private void OECKFAKFHMD(bool IDEBKDPMPGM)
	{
		_003CCHLHMOFNIMF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int DMBIHADLMOC()
	{
		return (int)((float)PGOFCHMMCDL * PKDAIEJDIFF * PNCHOAKOMPP());
	}

	[SpecialName]
	private void JHBKEHHIOBJ(float IDEBKDPMPGM)
	{
		_003CGCEKGKJBNEB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float NFGEMJDOBCA()
	{
		return _003CGCEKGKJBNEB_003Ek__BackingField;
	}

	public void EEHIFDPDNJK()
	{
		if (BKPEMBPBFLF == PNFCNJHKBBN.Scraps)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Scraps, EHKKGDJGCAK));
		}
		if (BKPEMBPBFLF == PNFCNJHKBBN.ArenaTickets)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Tickets, EHKKGDJGCAK));
		}
		if (BKPEMBPBFLF == PNFCNJHKBBN.Gold)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EHKKGDJGCAK));
		}
	}

	[SpecialName]
	private void DDOOBLFLPFE(float IDEBKDPMPGM)
	{
		_003CNCICDPGKHNL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float NFLBOCODDGL()
	{
		return _003CGCEKGKJBNEB_003Ek__BackingField;
	}

	[SpecialName]
	public bool GOJGKKJHLOK()
	{
		return _003CCHLHMOFNIMF_003Ek__BackingField;
	}

	[SpecialName]
	public int BIODJBODMND()
	{
		return (int)((float)(EECGPHJJLHN + KOENBBNGCGA) * EOHAGODNKCE());
	}

	private void DJGHDJFKCDD(Dictionary<string, object> EENKJBCCPBG)
	{
		if (EENKJBCCPBG.ContainsKey("HeroicPoints"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["HeroicPoints"]);
			DailyMissionsManager.instance.data.heroicPoints = num;
			UnityEngine.Debug.Log("#Mission Rewards# Current Heroic Points: " + num);
		}
	}

	[SpecialName]
	public bool EGPJJNJCODJ()
	{
		return _003CKDIMBHAGCBC_003Ek__BackingField;
	}

	[SpecialName]
	public bool MCDGFJEPBBG()
	{
		return _003CKDIMBHAGCBC_003Ek__BackingField;
	}

	[SpecialName]
	private void MDMKOGGFOAA(float IDEBKDPMPGM)
	{
		_003CLKCKBKMKLGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int FMGHEBOHNCG()
	{
		return (int)((float)BEBCNKHDJDC * LFIGMCMPKIE() * Singleton<VipManager>.instance.vipWarbucksMultiplier);
	}

	[SpecialName]
	public int BOHEGAPDNPO()
	{
		return (int)((float)PGOFCHMMCDL * EOGIFGDBIEB() * Singleton<VipManager>.instance.LBMNNAPPDMC());
	}

	public void OFOPLLLIPNJ()
	{
		if (BKPEMBPBFLF == PNFCNJHKBBN.GoldCardpack)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Lootboxes, EHKKGDJGCAK));
		}
		if (BKPEMBPBFLF == PNFCNJHKBBN.XP)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)(-93), EHKKGDJGCAK));
		}
		if (BKPEMBPBFLF == PNFCNJHKBBN.Gold)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Dogtag, EHKKGDJGCAK), LJMMJDNNIFH: true);
		}
	}

	[SpecialName]
	public int OIKHKBNLBEG()
	{
		return (int)((float)BEBCNKHDJDC * LEKGOMLLBMA());
	}

	[SpecialName]
	private float IFIBOCFIKDO()
	{
		return (!OILGNLDJKIL()) ? 301f : Singleton<VipManager>.instance.GBAAPABFEFJ();
	}

	[SpecialName]
	private void OIHPEBBJBKN(float IDEBKDPMPGM)
	{
		_003CNCICDPGKHNL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int PKOENKBELLO()
	{
		return (int)((float)BEBCNKHDJDC * PKIFGJGBBCP * FEMLFIMJCKB);
	}

	[SpecialName]
	private float PNCHOAKOMPP()
	{
		return (!GOJGKKJHLOK()) ? 1397f : Singleton<VipManager>.instance.BNPKNMAEAOO();
	}

	[SpecialName]
	public int LMIFOCCBJCO()
	{
		return (int)((float)BEBCNKHDJDC * PKIFGJGBBCP * NNLBHBBIHJG());
	}

	public void GDGIDPPEPIB()
	{
		if (IINOIBMKAPI != null && HMMPONAIBOC > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)(-17), IINOIBMKAPI, HMMPONAIBOC), LJMMJDNNIFH: true);
		}
		if (BCDPLPIDJGM > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Dogtag, BCDPLPIDJGM));
		}
		if (CCGELMHFCFG != null && CCGELMHFCFG.Count > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.WarCard, DailyMissionsManager.instance.heroicCardpack, CCGELMHFCFG.ToArray()));
		}
		if (CFCLPHCHEPP > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)(-88), CFCLPHCHEPP));
		}
		if (HDGCLIOMMMM > 1)
		{
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC((IHFDGLMHHBE)58, HDGCLIOMMMM), LJMMJDNNIFH: true);
		}
	}
}
