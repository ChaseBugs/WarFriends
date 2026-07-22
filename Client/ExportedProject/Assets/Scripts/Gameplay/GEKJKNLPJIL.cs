using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class GEKJKNLPJIL
{
	public static Action NKBJMLEBMBH;

	[CompilerGenerated]
	private static Comparison<FHIPGDADNFG> IONHPHFCBGH;

	[CompilerGenerated]
	private static Predicate<FHIPGDADNFG> LGJCBPOPCPA;

	public static void GFKNEJKENBI()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GameStartedClient, new List<Tuple<string, string>>());
		}
	}

	public static void LKDOGOHHBMB(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["N"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.NMKKPDBJAFO(item2);
			list.Add(item);
		}
		Debug.Log("Gold:     {0}\n" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("#AccoutCheck# missing ID from server", list, DateTime.Now.AddMinutes(1649.0), (DatabaseAction)(-119));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static void ADHGPFPFMHB(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["0"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.NPJJMDKNMGK(item2);
			list.Add(item);
		}
		Debug.Log("com.tune.unityutils.TuneUnityFirstPlaylistListener" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("Metal", list, DateTime.Now.AddMinutes(1965.0), (DatabaseAction)(-114));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static void CGKHMPIIDAA(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["gold"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.KMPKJJJBKDN(item2);
			list.Add(item);
		}
		Debug.Log("ID_CONFIRM_SQUADFULL_TEXT" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("SquadWarsFinishedMessage: Claiming gold: {0}", list, DateTime.Now.AddMinutes(636.0), (DatabaseAction)(-49));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	private static bool CGPCMFCDNPP(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static void PHJODPDOKDF()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.ClaimCraftedCard, new List<Tuple<string, string>>());
		}
	}

	public static List<FHIPGDADNFG> DOMPEJCGIIF()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(BKONEGLDIFN);
		if (num >= 0)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(HBODAOFFJCB);
		return list;
	}

	public static List<FHIPGDADNFG> APDGBADEKJA()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(CPEKKJHKADF);
		if (num >= 1)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(GKMHDIDIPOG);
		return list;
	}

	public static void KLALGDGBJDI(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["PlayWindowCount"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.NPJJMDKNMGK(item2);
			list.Add(item);
		}
		Debug.Log("it" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("isConnecting", list, DateTime.Now.AddMinutes(40.0), DatabaseAction.AddFacebook);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	private static int KCOAHNMOHON(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.HHPFLCHHOCF() == BNBAIGNDIHN.MCLGEGLNMGO())
		{
			if (DKOLFPJNHIM.GNHAIAGNIGN() == BNBAIGNDIHN.NFCCHBEGOIH())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.MHPNDNJDPGE))
				{
					return (!string.IsNullOrEmpty(BNBAIGNDIHN.MHPNDNJDPGE)) ? (-1) : 0;
				}
				return DKOLFPJNHIM.MHPNDNJDPGE.CompareTo(BNBAIGNDIHN.PLJJMJDKIMH());
			}
			return BNBAIGNDIHN.OJKENGEIADE().CompareTo(DKOLFPJNHIM.LANIPFOMABP());
		}
		return DKOLFPJNHIM.DCPCOPOIDLG() ? (-1) : 0;
	}

	public static List<FHIPGDADNFG> GINKDMIPNOF()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(HIGNGJPFIEH);
		if (num >= 1)
		{
			list[num].DBJMAKLFDEH(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(EDFMOANKDCP);
		return list;
	}

	public static void NAJILGFCEBJ(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["DPS"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.KMPKJJJBKDN(item2);
			list.Add(item);
		}
		Debug.Log("ID_REPORTUSER_ITEM1" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>(" :", list, DateTime.Now.AddMinutes(793.0), (DatabaseAction)28);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static void ILILMNDNHDJ(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["GR"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.EOBMFCOBOLB(item2);
			list.Add(item);
		}
		Debug.Log("ID_GETTOAVOIDRELEGATION1" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("Id", list, DateTime.Now.AddMinutes(269.0), DatabaseAction.MessageWasShown);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static void KMEHKHPDJNI()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.TutorialEnded, new List<Tuple<string, string>>());
		}
	}

	public static void IIOMKHNPLCG()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-101), new List<Tuple<string, string>>());
		}
	}

	private static bool MABJDABDNBI(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static List<FHIPGDADNFG> PPHMFPLHOHM()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(PBHCIOHCAGC);
		if (num >= 0)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(HBODAOFFJCB);
		return list;
	}

	public static void GHLKECOKGCJ()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)22, new List<Tuple<string, string>>());
		}
	}

	public static List<FHIPGDADNFG> NPJMKDIMKBF()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(CPEKKJHKADF);
		if (num >= 0)
		{
			list[num].DBJMAKLFDEH(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(LENJFPCCMLH);
		return list;
	}

	private static int GMHDCNMOEMJ(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.BDJCPEBAEPF() == BNBAIGNDIHN.HHPFLCHHOCF())
		{
			if (DKOLFPJNHIM.NFCCHBEGOIH() == BNBAIGNDIHN.GNHAIAGNIGN())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.LFCGFGHCPIN()))
				{
					return string.IsNullOrEmpty(BNBAIGNDIHN.PLJJMJDKIMH()) ? 1 : (-1);
				}
				return DKOLFPJNHIM.KKIIICDNIDM().CompareTo(BNBAIGNDIHN.EJDLJFFGHLJ());
			}
			return BNBAIGNDIHN.LANIPFOMABP().CompareTo(DKOLFPJNHIM.GFFGKMKNADO());
		}
		return (!DKOLFPJNHIM.LIIHMCOCMAK) ? 1 : (-1);
	}

	private static bool CPEKKJHKADF(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static List<FHIPGDADNFG> ICGKFEKIANG()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(CPEKKJHKADF);
		if (num >= 0)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(JJPBCOFDEAM);
		return list;
	}

	public static void CDKJJJJPFIH()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-39), new List<Tuple<string, string>>());
		}
	}

	public static List<FHIPGDADNFG> HMHEFLGOGCN()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(BKONEGLDIFN);
		if (num >= 1)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(IDJACIPPDMP);
		return list;
	}

	public static void ODGEAMFIFLD(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["remainingTimeForNextDogtag"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.HMOMMOBOHKL(item2);
			list.Add(item);
		}
		Debug.Log("UnsentRewards" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("INTERRUPTED", list, DateTime.Now.AddMinutes(250.0), (DatabaseAction)(-61));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static void GLJAHAAJNEC(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["ID_STAT_SMGKILLS"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.MAINIENLLIL(item2);
			list.Add(item);
		}
		Debug.Log("null" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("101 LOADING MAP", list, DateTime.Now.AddMinutes(1270.0), (DatabaseAction)(-73));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static void GGOPFAFIDHG(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["ID_MIN"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.MAINIENLLIL(item2);
			list.Add(item);
		}
		Debug.Log("WarBucks" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("nextDay", list, DateTime.Now.AddMinutes(597.0), (DatabaseAction)(-9));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	private static int IDJACIPPDMP(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.BDJCPEBAEPF() == BNBAIGNDIHN.MCLGEGLNMGO())
		{
			if (DKOLFPJNHIM.NGOMBNGGFFH() == BNBAIGNDIHN.NGOMBNGGFFH())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.LFCGFGHCPIN()))
				{
					return string.IsNullOrEmpty(BNBAIGNDIHN.KKIIICDNIDM()) ? 1 : (-1);
				}
				return DKOLFPJNHIM.MHPNDNJDPGE.CompareTo(BNBAIGNDIHN.LFCGFGHCPIN());
			}
			return BNBAIGNDIHN.LANIPFOMABP().CompareTo(DKOLFPJNHIM.OJKENGEIADE());
		}
		return (!DKOLFPJNHIM.HHPFLCHHOCF()) ? 1 : (-1);
	}

	public static void MMDIJLAFOGM(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["SetPower"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.KMPKJJJBKDN(item2);
			list.Add(item);
		}
		Debug.Log("ID_STARTERPACK" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("before: critical: ", list, DateTime.Now.AddMinutes(1909.0), (DatabaseAction)25);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	private static int JFEKAFFKLHN(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.HHPFLCHHOCF() == BNBAIGNDIHN.LIIHMCOCMAK)
		{
			if (DKOLFPJNHIM.OJKENGEIADE() == BNBAIGNDIHN.GFFGKMKNADO())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.EJDLJFFGHLJ()))
				{
					return (!string.IsNullOrEmpty(BNBAIGNDIHN.MHPNDNJDPGE)) ? (-1) : 0;
				}
				return DKOLFPJNHIM.LFCGFGHCPIN().CompareTo(BNBAIGNDIHN.PLJJMJDKIMH());
			}
			return BNBAIGNDIHN.NGOMBNGGFFH().CompareTo(DKOLFPJNHIM.GNHAIAGNIGN());
		}
		return (!DKOLFPJNHIM.MCLGEGLNMGO()) ? 1 : (-1);
	}

	private static int GKMHDIDIPOG(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.LIIHMCOCMAK == BNBAIGNDIHN.LIIHMCOCMAK)
		{
			if (DKOLFPJNHIM.MDJHOGOFGLJ == BNBAIGNDIHN.MDJHOGOFGLJ)
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.MHPNDNJDPGE))
				{
					return (!string.IsNullOrEmpty(BNBAIGNDIHN.MHPNDNJDPGE)) ? (-1) : 0;
				}
				return DKOLFPJNHIM.MHPNDNJDPGE.CompareTo(BNBAIGNDIHN.MHPNDNJDPGE);
			}
			return BNBAIGNDIHN.MDJHOGOFGLJ.CompareTo(DKOLFPJNHIM.MDJHOGOFGLJ);
		}
		return (!DKOLFPJNHIM.LIIHMCOCMAK) ? 1 : (-1);
	}

	public static List<FHIPGDADNFG> DEIIKBCHFPC()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(GMLJMDCEDHB);
		if (num >= 1)
		{
			list[num].CPGIJMICDGC(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(CJDEPACBEDA);
		return list;
	}

	public static List<FHIPGDADNFG> PFMJNDLKBAD()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex((FHIPGDADNFG KHLGDCHJJPB) => KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id);
		if (num >= 0)
		{
			list[num].CPGIJMICDGC(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(GKMHDIDIPOG);
		return list;
	}

	public static List<FHIPGDADNFG> LLGGKINMPMP()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(JONFGDCPJDP);
		if (num >= 1)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(ECGDNICLEGO);
		return list;
	}

	public static List<FHIPGDADNFG> GCOBJEAGAML()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(JONFGDCPJDP);
		if (num >= 1)
		{
			list[num].NKCLMECDCPK(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(GMHDCNMOEMJ);
		return list;
	}

	private static int HBODAOFFJCB(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.BDJCPEBAEPF() == BNBAIGNDIHN.LIIHMCOCMAK)
		{
			if (DKOLFPJNHIM.OJKENGEIADE() == BNBAIGNDIHN.GNHAIAGNIGN())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.PLJJMJDKIMH()))
				{
					return (!string.IsNullOrEmpty(BNBAIGNDIHN.LFCGFGHCPIN())) ? (-1) : 0;
				}
				return DKOLFPJNHIM.LFCGFGHCPIN().CompareTo(BNBAIGNDIHN.LFCGFGHCPIN());
			}
			return BNBAIGNDIHN.LANIPFOMABP().CompareTo(DKOLFPJNHIM.OJKENGEIADE());
		}
		return (!DKOLFPJNHIM.MCLGEGLNMGO()) ? 1 : (-1);
	}

	private static bool PBHCIOHCAGC(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	private static int CHFKJCPLHFB(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.HHPFLCHHOCF() == BNBAIGNDIHN.HHPFLCHHOCF())
		{
			if (DKOLFPJNHIM.NGOMBNGGFFH() == BNBAIGNDIHN.LANIPFOMABP())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.KKIIICDNIDM()))
				{
					return (!string.IsNullOrEmpty(BNBAIGNDIHN.LFCGFGHCPIN())) ? (-1) : 0;
				}
				return DKOLFPJNHIM.PLJJMJDKIMH().CompareTo(BNBAIGNDIHN.EJDLJFFGHLJ());
			}
			return BNBAIGNDIHN.LANIPFOMABP().CompareTo(DKOLFPJNHIM.LANIPFOMABP());
		}
		return (!DKOLFPJNHIM.MCLGEGLNMGO()) ? 1 : (-1);
	}

	public static void KHBIAKGOHGH(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["ID_GUI_EQUIPPED"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.NMKKPDBJAFO(item2);
			list.Add(item);
		}
		Debug.Log("Buy_Unit_Upgrade" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("LootboxType", list, DateTime.Now.AddMinutes(126.0), DatabaseAction.BuyInApp);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static List<FHIPGDADNFG> AHPCPKDONNG()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(LGIOOLCHBEC);
		if (num >= 0)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(KCOAHNMOHON);
		return list;
	}

	private static bool OKPMHPMCGPA(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static void JBBJNFEHHFC()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetArenaLeaderboards, new List<Tuple<string, string>>());
		}
	}

	private static bool MAPODFELKIB(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static void DJIDACPPECH()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)145, new List<Tuple<string, string>>());
		}
	}

	public static List<FHIPGDADNFG> PBBHIODHALH()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(BKONEGLDIFN);
		if (num >= 0)
		{
			list[num].NKCLMECDCPK(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(JFEKAFFKLHN);
		return list;
	}

	public static void NBGJPOOGMCC()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-31), new List<Tuple<string, string>>());
		}
	}

	private static bool BKONEGLDIFN(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	private static int JJPBCOFDEAM(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.DCPCOPOIDLG() == BNBAIGNDIHN.MCLGEGLNMGO())
		{
			if (DKOLFPJNHIM.OJKENGEIADE() == BNBAIGNDIHN.LANIPFOMABP())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.LFCGFGHCPIN()))
				{
					return (!string.IsNullOrEmpty(BNBAIGNDIHN.EJDLJFFGHLJ())) ? (-1) : 0;
				}
				return DKOLFPJNHIM.KKIIICDNIDM().CompareTo(BNBAIGNDIHN.LFCGFGHCPIN());
			}
			return BNBAIGNDIHN.OJKENGEIADE().CompareTo(DKOLFPJNHIM.NGOMBNGGFFH());
		}
		return DKOLFPJNHIM.MCLGEGLNMGO() ? (-1) : 0;
	}

	public static void FMHJFAHMIFN(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["Spend_Warbucks_On_Weapons"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.KMPKJJJBKDN(item2);
			list.Add(item);
		}
		Debug.Log("123456789" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("country-mexico", list, DateTime.Now.AddMinutes(49.0), (DatabaseAction)115);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static List<FHIPGDADNFG> PHMBGKDHFDE()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(PBHCIOHCAGC);
		if (num >= 0)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(GKMHDIDIPOG);
		return list;
	}

	private static bool LGIOOLCHBEC(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static void FNOEANGFKKE(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["GameReward"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.NPJJMDKNMGK(item2);
			list.Add(item);
		}
		Debug.Log("OUI" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("localSquadLeaderboard", list, DateTime.Now.AddMinutes(1172.0), DatabaseAction.RefillDogtags);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static List<FHIPGDADNFG> NHIGMEOIJAD()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(OKPMHPMCGPA);
		if (num >= 0)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(CHFKJCPLHFB);
		return list;
	}

	private static int KPEIDOLAPEO(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.MCLGEGLNMGO() == BNBAIGNDIHN.LIIHMCOCMAK)
		{
			if (DKOLFPJNHIM.LANIPFOMABP() == BNBAIGNDIHN.GFFGKMKNADO())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.LFCGFGHCPIN()))
				{
					return string.IsNullOrEmpty(BNBAIGNDIHN.MHPNDNJDPGE) ? 1 : (-1);
				}
				return DKOLFPJNHIM.MHPNDNJDPGE.CompareTo(BNBAIGNDIHN.KKIIICDNIDM());
			}
			return BNBAIGNDIHN.OJKENGEIADE().CompareTo(DKOLFPJNHIM.MDJHOGOFGLJ);
		}
		return (!DKOLFPJNHIM.MCLGEGLNMGO()) ? 1 : (-1);
	}

	public static void DOAMBJEPACF()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-80), new List<Tuple<string, string>>());
		}
	}

	[CompilerGenerated]
	private static bool BMOHEIECCDP(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static void JNAPGNOLBEG(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["{"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.MAINIENLLIL(item2);
			list.Add(item);
		}
		Debug.Log(" TAB " + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("Weapon_ID", list, DateTime.Now.AddMinutes(720.0), (DatabaseAction)(-42));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	public static void LLCLNJKBGGM(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["Items"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.MAINIENLLIL(item2);
			list.Add(item);
		}
		Debug.Log("On Get Arena Leaderboards: CNT =  " + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("arenaLeaderboard", list, DateTime.Now.AddMinutes(2.0));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	private static bool HIGNGJPFIEH(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static void LKEPELMIJGD(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["nextWithdraw"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.NPJJMDKNMGK(item2);
			list.Add(item);
		}
		Debug.Log("Assignment_" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>(" found!", list, DateTime.Now.AddMinutes(1608.0), DatabaseAction.SetPlayerStatus);
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}

	private static bool CMDFEDPEKCF(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	private static int EDFMOANKDCP(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.HHPFLCHHOCF() == BNBAIGNDIHN.LIIHMCOCMAK)
		{
			if (DKOLFPJNHIM.MDJHOGOFGLJ == BNBAIGNDIHN.GFFGKMKNADO())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.PLJJMJDKIMH()))
				{
					return string.IsNullOrEmpty(BNBAIGNDIHN.KKIIICDNIDM()) ? 1 : (-1);
				}
				return DKOLFPJNHIM.KKIIICDNIDM().CompareTo(BNBAIGNDIHN.MHPNDNJDPGE);
			}
			return BNBAIGNDIHN.GNHAIAGNIGN().CompareTo(DKOLFPJNHIM.NGOMBNGGFFH());
		}
		return (!DKOLFPJNHIM.LIIHMCOCMAK) ? 1 : (-1);
	}

	private static int ECGDNICLEGO(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.DCPCOPOIDLG() == BNBAIGNDIHN.MCLGEGLNMGO())
		{
			if (DKOLFPJNHIM.LANIPFOMABP() == BNBAIGNDIHN.LANIPFOMABP())
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.EJDLJFFGHLJ()))
				{
					return (!string.IsNullOrEmpty(BNBAIGNDIHN.PLJJMJDKIMH())) ? (-1) : 0;
				}
				return DKOLFPJNHIM.PLJJMJDKIMH().CompareTo(BNBAIGNDIHN.PLJJMJDKIMH());
			}
			return BNBAIGNDIHN.OJKENGEIADE().CompareTo(DKOLFPJNHIM.GNHAIAGNIGN());
		}
		return (!DKOLFPJNHIM.DCPCOPOIDLG()) ? 1 : (-1);
	}

	public static void NECGIOONMPK()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)(-122), new List<Tuple<string, string>>());
		}
	}

	private static int LENJFPCCMLH(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.BDJCPEBAEPF() == BNBAIGNDIHN.LIIHMCOCMAK)
		{
			if (DKOLFPJNHIM.GFFGKMKNADO() == BNBAIGNDIHN.MDJHOGOFGLJ)
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.MHPNDNJDPGE))
				{
					return string.IsNullOrEmpty(BNBAIGNDIHN.EJDLJFFGHLJ()) ? 1 : (-1);
				}
				return DKOLFPJNHIM.EJDLJFFGHLJ().CompareTo(BNBAIGNDIHN.LFCGFGHCPIN());
			}
			return BNBAIGNDIHN.GFFGKMKNADO().CompareTo(DKOLFPJNHIM.GNHAIAGNIGN());
		}
		return (!DKOLFPJNHIM.HHPFLCHHOCF()) ? 1 : (-1);
	}

	public static List<FHIPGDADNFG> AOECLKAPELC()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		int num = list.FindIndex(CPEKKJHKADF);
		if (num >= 1)
		{
			list[num].HCCKBIHGJOB(WarArena.instance.data.flawless, WarArena.instance.data.topRun);
		}
		list.Sort(CJDEPACBEDA);
		return list;
	}

	private static int CJDEPACBEDA(FHIPGDADNFG DKOLFPJNHIM, FHIPGDADNFG BNBAIGNDIHN)
	{
		if (DKOLFPJNHIM.DCPCOPOIDLG() == BNBAIGNDIHN.LIIHMCOCMAK)
		{
			if (DKOLFPJNHIM.MDJHOGOFGLJ == BNBAIGNDIHN.MDJHOGOFGLJ)
			{
				if (string.IsNullOrEmpty(DKOLFPJNHIM.LFCGFGHCPIN()))
				{
					return string.IsNullOrEmpty(BNBAIGNDIHN.MHPNDNJDPGE) ? 1 : (-1);
				}
				return DKOLFPJNHIM.LFCGFGHCPIN().CompareTo(BNBAIGNDIHN.EJDLJFFGHLJ());
			}
			return BNBAIGNDIHN.NFCCHBEGOIH().CompareTo(DKOLFPJNHIM.NFCCHBEGOIH());
		}
		return DKOLFPJNHIM.BDJCPEBAEPF() ? (-1) : 0;
	}

	public static void ACDIBOEKKID()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.AddGooglePlay, new List<Tuple<string, string>>());
		}
	}

	public static void KLHOHKJAGFH()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.PFMJNDLKBAD();
		if (list != null)
		{
			if (NKBJMLEBMBH != null)
			{
				NKBJMLEBMBH();
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)11, new List<Tuple<string, string>>());
		}
	}

	private static bool GMLJMDCEDHB(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	private static bool JONFGDCPJDP(FHIPGDADNFG KHLGDCHJJPB)
	{
		return KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id;
	}

	public static void LEGDFLFHAHO(Dictionary<string, object> EENKJBCCPBG)
	{
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)EENKJBCCPBG["menu-squadpoint-ico"];
		foreach (JToken item2 in jArray)
		{
			FHIPGDADNFG item = FHIPGDADNFG.KMPKJJJBKDN(item2);
			list.Add(item);
		}
		Debug.Log("PlayerData" + list.Count);
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("{0}.", list, DateTime.Now.AddMinutes(1484.0), (DatabaseAction)(-115));
		if (NKBJMLEBMBH != null)
		{
			NKBJMLEBMBH();
		}
	}
}
