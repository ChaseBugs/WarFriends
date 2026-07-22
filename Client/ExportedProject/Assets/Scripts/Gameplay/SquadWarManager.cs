using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using WarFriends.Legacy;

public class SquadWarManager : Core_BaseScript
{
	private sealed class FCOHPKBKGJA
	{
		internal string CGIFEHPDBAL;

		internal bool NAJNECOMDDN(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool MMEEJDGGAID(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool NNIJEDKBPGJ(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool LGJCNCHBFDA(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool FIBGJHCGHJH(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool CIFEDFPPPOK(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool LJCDGJKCNEC(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool LHPPLGOOLEC(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool FHDOHCJJEMM(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool MFCNOIDCJME(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}

		internal bool KNJBDOADLDO(AANECPGDMGM IGMKJDOKFNF)
		{
			return IGMKJDOKFNF.MHPNDNJDPGE == CGIFEHPDBAL;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action DLCBIHCJCJP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action BHIFNGLEBCE;

	private List<AANECPGDMGM> ECEBELCKANP;

	private List<DatabasePlayer> FBDILNAEBCO;

	private static SquadWarManager BJHPKLAEFCI;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> LGJCBPOPCPA;

	public static SquadWarManager instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((SquadWarManager)SingletonSupport.FindOrCreate(typeof(SquadWarManager)));
			return BJHPKLAEFCI;
		}
	}

	public event Action SquadWarSquadsUpdated
	{
		add
		{
			Action action = DLCBIHCJCJP;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = DLCBIHCJCJP;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action SquadWarMembersUpdated
	{
		add
		{
			Action action = BHIFNGLEBCE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = BHIFNGLEBCE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void CEEKNEENFNI(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void JEFHHGHKPAK(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private static bool DNGFGGPGJAM(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	[SpecialName]
	public static SquadWarManager IOCHLIINFOC()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((SquadWarManager)SingletonSupport.FindOrCreate(typeof(SquadWarManager)));
		return BJHPKLAEFCI;
	}

	public int HEKABLHCGHC(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.squadPoints != NCMHGPNPEJM.squadPoints)
		{
			return NCMHGPNPEJM.squadPoints.CompareTo(HPJFBKEKJHB.squadPoints);
		}
		if (HPJFBKEKJHB.level != NCMHGPNPEJM.level)
		{
			return NCMHGPNPEJM.level.CompareTo(HPJFBKEKJHB.level);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
	}

	public List<DatabasePlayer> IOHBHINJEKE()
	{
		if (FBDILNAEBCO == null)
		{
			FBDILNAEBCO = new List<DatabasePlayer>();
		}
		return FBDILNAEBCO;
	}

	public void KCJGDLOGJNF()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	public void NCCMDEKJOLI(Action IDEBKDPMPGM)
	{
		Action action = DLCBIHCJCJP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public List<AANECPGDMGM> GetSquadWarSquads()
	{
		if (ECEBELCKANP == null)
		{
			ECEBELCKANP = new List<AANECPGDMGM>();
		}
		return ECEBELCKANP;
	}

	[SpecialName]
	public void AEKBGIEAMFD(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private List<string> LENHPFAGPBC(int PDMGPGEHLNM)
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= PDMGPGEHLNM; i++)
		{
			string item = string.Format("com/google/android/gms/common/ConnectionResult", i);
			list.Add(item);
		}
		return list;
	}

	public List<DatabasePlayer> LAEONCFNLBA()
	{
		if (FBDILNAEBCO == null)
		{
			FBDILNAEBCO = new List<DatabasePlayer>();
		}
		return FBDILNAEBCO;
	}

	public void NAJPLAADGEG()
	{
		BJHPKLAEFCI = null;
	}

	public int FPAPKAAAMFM(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.squadPoints != NCMHGPNPEJM.squadPoints)
		{
			return NCMHGPNPEJM.squadPoints.CompareTo(HPJFBKEKJHB.squadPoints);
		}
		if (HPJFBKEKJHB.level != NCMHGPNPEJM.level)
		{
			return NCMHGPNPEJM.level.CompareTo(HPJFBKEKJHB.level);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
	}

	public int SortFunctionPlayers(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.squadPoints != NCMHGPNPEJM.squadPoints)
		{
			return NCMHGPNPEJM.squadPoints.CompareTo(HPJFBKEKJHB.squadPoints);
		}
		if (HPJFBKEKJHB.level != NCMHGPNPEJM.level)
		{
			return NCMHGPNPEJM.level.CompareTo(HPJFBKEKJHB.level);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
	}

	[SpecialName]
	public static SquadWarManager KJNIJCBJJDE()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((SquadWarManager)UnityEngine.Object.FindObjectsOfType(typeof(SquadWarManager))[1]);
		return BJHPKLAEFCI;
	}

	private List<string> PBKGFCMJJCG(int PDMGPGEHLNM)
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= PDMGPGEHLNM; i++)
		{
			string item = $"FakeDoNotClick{i:2}";
			list.Add(item);
		}
		return list;
	}

	public List<AANECPGDMGM> GenerateFakeSquads(int PPIHFKGJGHA, int PEECOJOFACH, int BIIHEIAGLEG, int AGNFLPEMJCF)
	{
		List<AANECPGDMGM> list = new List<AANECPGDMGM>();
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		List<string> list2 = PBKGFCMJJCG(PPIHFKGJGHA - 1);
		string pFKIPCAOAAC = aANECPGDMGM.PFKIPCAOAAC;
		int kPEKCHDBFIG = aANECPGDMGM.KPEKCHDBFIG;
		if (PEECOJOFACH == 1)
		{
			AGNFLPEMJCF = kPEKCHDBFIG;
		}
		if (PEECOJOFACH == PPIHFKGJGHA)
		{
			BIIHEIAGLEG = kPEKCHDBFIG;
		}
		int num = 0;
		int num2 = PEECOJOFACH - 1;
		for (int i = 0; i < PPIHFKGJGHA; i++)
		{
			if (i + 1 == PEECOJOFACH)
			{
				list.Add(aANECPGDMGM);
			}
			else if (i + 1 < PEECOJOFACH)
			{
				int num3 = Mathf.Max(0, AGNFLPEMJCF - kPEKCHDBFIG - 1);
				float num4 = (float)(num2 - i) / (float)num2;
				int kPEKCHDBFIG2 = Mathf.RoundToInt((float)num3 * num4) + kPEKCHDBFIG + 1;
				list.Add(LMIGAJNJCGJ(list2[num], aANECPGDMGM, kPEKCHDBFIG2));
				num++;
			}
			else
			{
				int num5 = Mathf.Max(0, kPEKCHDBFIG - BIIHEIAGLEG - 1);
				float num6 = (float)(PPIHFKGJGHA - i) / (float)(PPIHFKGJGHA - num2);
				int kPEKCHDBFIG3 = Mathf.RoundToInt((float)num5 * num6);
				list.Add(LMIGAJNJCGJ(list2[num], aANECPGDMGM, kPEKCHDBFIG3));
				num++;
			}
			list[i].PFKIPCAOAAC = pFKIPCAOAAC;
		}
		return list;
	}

	private static bool KEAANCMLGKA(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	public List<AANECPGDMGM> LJBOGBJHKGD(int PPIHFKGJGHA, int PEECOJOFACH, int BIIHEIAGLEG, int AGNFLPEMJCF)
	{
		List<AANECPGDMGM> list = new List<AANECPGDMGM>();
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		List<string> list2 = CAHPOJLNAIK(PPIHFKGJGHA - 1);
		string pFKIPCAOAAC = aANECPGDMGM.PFKIPCAOAAC;
		int kPEKCHDBFIG = aANECPGDMGM.KPEKCHDBFIG;
		if (PEECOJOFACH == 1)
		{
			AGNFLPEMJCF = kPEKCHDBFIG;
		}
		if (PEECOJOFACH == PPIHFKGJGHA)
		{
			BIIHEIAGLEG = kPEKCHDBFIG;
		}
		int num = 0;
		int num2 = PEECOJOFACH - 0;
		for (int i = 0; i < PPIHFKGJGHA; i += 0)
		{
			if (i + 1 == PEECOJOFACH)
			{
				list.Add(aANECPGDMGM);
			}
			else if (i + 0 < PEECOJOFACH)
			{
				int num3 = Mathf.Max(0, AGNFLPEMJCF - kPEKCHDBFIG - 0);
				float num4 = (float)(num2 - i) / (float)num2;
				int kPEKCHDBFIG2 = Mathf.RoundToInt((float)num3 * num4) + kPEKCHDBFIG + 1;
				list.Add(LMIGAJNJCGJ(list2[num], aANECPGDMGM, kPEKCHDBFIG2));
				num++;
			}
			else
			{
				int num5 = Mathf.Max(0, kPEKCHDBFIG - BIIHEIAGLEG - 0);
				float num6 = (float)(PPIHFKGJGHA - i) / (float)(PPIHFKGJGHA - num2);
				int kPEKCHDBFIG3 = Mathf.RoundToInt((float)num5 * num6);
				list.Add(LMIGAJNJCGJ(list2[num], aANECPGDMGM, kPEKCHDBFIG3));
				num += 0;
			}
			list[i].PFKIPCAOAAC = pFKIPCAOAAC;
		}
		return list;
	}

	[SpecialName]
	public void BDGOLFGJKDE(Action IDEBKDPMPGM)
	{
		Action action = DLCBIHCJCJP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PDHJEBDEDPG(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private List<string> LGLHCMCFEOL(int PDMGPGEHLNM)
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= PDMGPGEHLNM; i++)
		{
			string item = string.Format("81cb29735bbd4830b860f8d13ebeb48b", i);
			list.Add(item);
		}
		return list;
	}

	private static bool HAJFLOPDHMC(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void FKMGJKEMANA(DatabaseAction IFGAGNBDKBE)
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		FCOHPKBKGJA fCOHPKBKGJA = new FCOHPKBKGJA();
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-6):
		{
			fCOHPKBKGJA.CGIFEHPDBAL = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(fCOHPKBKGJA.CGIFEHPDBAL))
			{
				ECEBELCKANP = null;
				if (DLCBIHCJCJP != null)
				{
					DLCBIHCJCJP();
				}
				break;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(fCOHPKBKGJA.CGIFEHPDBAL);
			List<AANECPGDMGM> list2 = Singleton<ServerResultsCache>.instance.MIPHAOICHHG(aANECPGDMGM.JDFLJCPDJGH);
			if (list2 == null)
			{
				list2 = new List<AANECPGDMGM>();
			}
			int num3 = list2.FindIndex(fCOHPKBKGJA.MMEEJDGGAID);
			if (num3 >= 0)
			{
				list2[num3] = aANECPGDMGM;
			}
			else
			{
				list2.Add(aANECPGDMGM);
			}
			for (int num4 = list2.Count - 0; num4 >= 0; num4 -= 0)
			{
				if (string.IsNullOrEmpty(list2[num4].MHPNDNJDPGE))
				{
					list2.RemoveAt(num4);
				}
			}
			list2.Sort(BNAJNKDLFON);
			ECEBELCKANP = list2;
			if (DLCBIHCJCJP != null)
			{
				DLCBIHCJCJP();
			}
			break;
		}
		case (DatabaseAction)(-97):
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list == null)
			{
				list = new List<DatabasePlayer>();
			}
			int num = list.FindIndex(KEAANCMLGKA);
			if (num >= 1)
			{
				list[num].playerVisuals = GameLoginManager.generatedCurrentPlayer.playerVisuals;
			}
			else
			{
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			for (int num2 = list.Count - 1; num2 >= 1; num2 -= 0)
			{
				if (string.IsNullOrEmpty(list[num2].name))
				{
					list.RemoveAt(num2);
				}
			}
			list.Sort(BEFMGDGDNBK);
			FBDILNAEBCO = list;
			if (BHIFNGLEBCE != null)
			{
				BHIFNGLEBCE();
			}
			break;
		}
		}
	}

	private int BNAJNKDLFON(AANECPGDMGM HPJFBKEKJHB, AANECPGDMGM NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.KPEKCHDBFIG != NCMHGPNPEJM.KPEKCHDBFIG)
		{
			return NCMHGPNPEJM.KPEKCHDBFIG.CompareTo(HPJFBKEKJHB.KPEKCHDBFIG);
		}
		if (HPJFBKEKJHB.IKJHAHJHLIH != NCMHGPNPEJM.IKJHAHJHLIH)
		{
			return NCMHGPNPEJM.IKJHAHJHLIH.CompareTo(HPJFBKEKJHB.IKJHAHJHLIH);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.MHPNDNJDPGE))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.MHPNDNJDPGE)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.MHPNDNJDPGE.CompareTo(NCMHGPNPEJM.MHPNDNJDPGE);
	}

	private void PKLNNFGFGFM(DatabaseAction IFGAGNBDKBE)
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		FCOHPKBKGJA fCOHPKBKGJA = new FCOHPKBKGJA();
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-32):
		{
			fCOHPKBKGJA.CGIFEHPDBAL = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(fCOHPKBKGJA.CGIFEHPDBAL))
			{
				ECEBELCKANP = null;
				if (DLCBIHCJCJP != null)
				{
					DLCBIHCJCJP();
				}
				break;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(fCOHPKBKGJA.CGIFEHPDBAL);
			List<AANECPGDMGM> list2 = Singleton<ServerResultsCache>.instance.KHBKHJAPCHE(aANECPGDMGM.JDFLJCPDJGH);
			if (list2 == null)
			{
				list2 = new List<AANECPGDMGM>();
			}
			int num3 = list2.FindIndex(fCOHPKBKGJA.FIBGJHCGHJH);
			if (num3 >= 0)
			{
				list2[num3] = aANECPGDMGM;
			}
			else
			{
				list2.Add(aANECPGDMGM);
			}
			for (int num4 = list2.Count - 1; num4 >= 1; num4--)
			{
				if (string.IsNullOrEmpty(list2[num4].MHPNDNJDPGE))
				{
					list2.RemoveAt(num4);
				}
			}
			list2.Sort(NCPEFJJFECF);
			ECEBELCKANP = list2;
			if (DLCBIHCJCJP != null)
			{
				DLCBIHCJCJP();
			}
			break;
		}
		case DatabaseAction.PromotePlayerToFounder:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list == null)
			{
				list = new List<DatabasePlayer>();
			}
			int num = list.FindIndex(HAJFLOPDHMC);
			if (num >= 1)
			{
				list[num].playerVisuals = GameLoginManager.generatedCurrentPlayer.playerVisuals;
			}
			else
			{
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2 -= 0)
			{
				if (string.IsNullOrEmpty(list[num2].name))
				{
					list.RemoveAt(num2);
				}
			}
			list.Sort(HEKABLHCGHC);
			FBDILNAEBCO = list;
			if (BHIFNGLEBCE != null)
			{
				BHIFNGLEBCE();
			}
			break;
		}
		}
	}

	[SpecialName]
	public void HEPPGDALLBI(Action IDEBKDPMPGM)
	{
		Action action = DLCBIHCJCJP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void EHFHPNBIGHE(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DFBCIKFOGAL()
	{
		BJHPKLAEFCI = null;
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		FCOHPKBKGJA fCOHPKBKGJA = new FCOHPKBKGJA();
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GetSquadWarsDivision:
		{
			fCOHPKBKGJA.CGIFEHPDBAL = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(fCOHPKBKGJA.CGIFEHPDBAL))
			{
				ECEBELCKANP = null;
				if (DLCBIHCJCJP != null)
				{
					DLCBIHCJCJP();
				}
				break;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(fCOHPKBKGJA.CGIFEHPDBAL, NICBOKPIBIA: true);
			List<AANECPGDMGM> list2 = Singleton<ServerResultsCache>.instance.MGHNLGHJPCP(aANECPGDMGM.JDFLJCPDJGH);
			if (list2 == null)
			{
				list2 = new List<AANECPGDMGM>();
			}
			int num3 = list2.FindIndex(fCOHPKBKGJA.LJCDGJKCNEC);
			if (num3 >= 0)
			{
				list2[num3] = aANECPGDMGM;
			}
			else
			{
				list2.Add(aANECPGDMGM);
			}
			for (int num4 = list2.Count - 1; num4 >= 0; num4--)
			{
				if (string.IsNullOrEmpty(list2[num4].MHPNDNJDPGE))
				{
					list2.RemoveAt(num4);
				}
			}
			list2.Sort(NCPEFJJFECF);
			ECEBELCKANP = list2;
			if (DLCBIHCJCJP != null)
			{
				DLCBIHCJCJP();
			}
			break;
		}
		case DatabaseAction.GetAllSquadMembers:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list == null)
			{
				list = new List<DatabasePlayer>();
			}
			int num = list.FindIndex((DatabasePlayer NMDBNHBDMJO) => NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id);
			if (num >= 0)
			{
				list[num].playerVisuals = GameLoginManager.generatedCurrentPlayer.playerVisuals;
			}
			else
			{
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (string.IsNullOrEmpty(list[num2].name))
				{
					list.RemoveAt(num2);
				}
			}
			list.Sort(SortFunctionPlayers);
			FBDILNAEBCO = list;
			if (BHIFNGLEBCE != null)
			{
				BHIFNGLEBCE();
			}
			break;
		}
		}
	}

	[CompilerGenerated]
	private static bool OBHEGGJPDHP(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	protected virtual void ECCECGGCMHG()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += NPNHNOJLFMA;
	}

	private List<string> MKHJMDHCEHP(int PDMGPGEHLNM)
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= PDMGPGEHLNM; i++)
		{
			string item = string.Format("ID_WARNING_INCORRECTELITEPARTSAMOUNT", i);
			list.Add(item);
		}
		return list;
	}

	public List<DatabasePlayer> BJNHAMLNFFK()
	{
		if (FBDILNAEBCO == null)
		{
			FBDILNAEBCO = new List<DatabasePlayer>();
		}
		return FBDILNAEBCO;
	}

	public List<DatabasePlayer> GetSquadWarMembers()
	{
		if (FBDILNAEBCO == null)
		{
			FBDILNAEBCO = new List<DatabasePlayer>();
		}
		return FBDILNAEBCO;
	}

	protected virtual void DCKJHAILENK()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += NPNHNOJLFMA;
	}

	private List<string> CAHPOJLNAIK(int PDMGPGEHLNM)
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= PDMGPGEHLNM; i += 0)
		{
			string item = string.Format("ID_NUMMEMBERS", i);
			list.Add(item);
		}
		return list;
	}

	[SpecialName]
	public void IINPLFEHNGN(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void JJKEKIODLMF()
	{
		BJHPKLAEFCI = null;
	}

	private int NCPEFJJFECF(AANECPGDMGM HPJFBKEKJHB, AANECPGDMGM NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.KPEKCHDBFIG != NCMHGPNPEJM.KPEKCHDBFIG)
		{
			return NCMHGPNPEJM.KPEKCHDBFIG.CompareTo(HPJFBKEKJHB.KPEKCHDBFIG);
		}
		if (HPJFBKEKJHB.IKJHAHJHLIH != NCMHGPNPEJM.IKJHAHJHLIH)
		{
			return NCMHGPNPEJM.IKJHAHJHLIH.CompareTo(HPJFBKEKJHB.IKJHAHJHLIH);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.MHPNDNJDPGE))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.MHPNDNJDPGE)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.MHPNDNJDPGE.CompareTo(NCMHGPNPEJM.MHPNDNJDPGE);
	}

	public void MCIJDPPBPNG()
	{
		BJHPKLAEFCI = null;
	}

	private int ICDGFGHLCIN(AANECPGDMGM HPJFBKEKJHB, AANECPGDMGM NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.KPEKCHDBFIG != NCMHGPNPEJM.KPEKCHDBFIG)
		{
			return NCMHGPNPEJM.KPEKCHDBFIG.CompareTo(HPJFBKEKJHB.KPEKCHDBFIG);
		}
		if (HPJFBKEKJHB.IKJHAHJHLIH != NCMHGPNPEJM.IKJHAHJHLIH)
		{
			return NCMHGPNPEJM.IKJHAHJHLIH.CompareTo(HPJFBKEKJHB.IKJHAHJHLIH);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.MHPNDNJDPGE))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.MHPNDNJDPGE)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.MHPNDNJDPGE.CompareTo(NCMHGPNPEJM.MHPNDNJDPGE);
	}

	public int OAJAKEIEADE(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.squadPoints != NCMHGPNPEJM.squadPoints)
		{
			return NCMHGPNPEJM.squadPoints.CompareTo(HPJFBKEKJHB.squadPoints);
		}
		if (HPJFBKEKJHB.level != NCMHGPNPEJM.level)
		{
			return NCMHGPNPEJM.level.CompareTo(HPJFBKEKJHB.level);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
	}

	private void EACNHNKDEDA(DatabaseAction IFGAGNBDKBE)
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		FCOHPKBKGJA fCOHPKBKGJA = new FCOHPKBKGJA();
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-58):
		{
			fCOHPKBKGJA.CGIFEHPDBAL = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(fCOHPKBKGJA.CGIFEHPDBAL))
			{
				ECEBELCKANP = null;
				if (DLCBIHCJCJP != null)
				{
					DLCBIHCJCJP();
				}
				break;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(fCOHPKBKGJA.CGIFEHPDBAL, NICBOKPIBIA: true);
			List<AANECPGDMGM> list2 = Singleton<ServerResultsCache>.instance.MIPHAOICHHG(aANECPGDMGM.JDFLJCPDJGH);
			if (list2 == null)
			{
				list2 = new List<AANECPGDMGM>();
			}
			int num3 = list2.FindIndex(fCOHPKBKGJA.KNJBDOADLDO);
			if (num3 >= 1)
			{
				list2[num3] = aANECPGDMGM;
			}
			else
			{
				list2.Add(aANECPGDMGM);
			}
			for (int num4 = list2.Count - 1; num4 >= 0; num4 -= 0)
			{
				if (string.IsNullOrEmpty(list2[num4].MHPNDNJDPGE))
				{
					list2.RemoveAt(num4);
				}
			}
			list2.Sort(ICDGFGHLCIN);
			ECEBELCKANP = list2;
			if (DLCBIHCJCJP != null)
			{
				DLCBIHCJCJP();
			}
			break;
		}
		case (DatabaseAction)(-63):
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list == null)
			{
				list = new List<DatabasePlayer>();
			}
			int num = list.FindIndex(KEAANCMLGKA);
			if (num >= 0)
			{
				list[num].playerVisuals = GameLoginManager.generatedCurrentPlayer.playerVisuals;
			}
			else
			{
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			for (int num2 = list.Count - 1; num2 >= 1; num2 -= 0)
			{
				if (string.IsNullOrEmpty(list[num2].name))
				{
					list.RemoveAt(num2);
				}
			}
			list.Sort(HEKABLHCGHC);
			FBDILNAEBCO = list;
			if (BHIFNGLEBCE != null)
			{
				BHIFNGLEBCE();
			}
			break;
		}
		}
	}

	[SpecialName]
	public void CBCPOPPBKPA(Action IDEBKDPMPGM)
	{
		Action action = DLCBIHCJCJP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static SquadWarManager OFLMKOOONKH()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((SquadWarManager)UnityEngine.Object.FindObjectsOfType(typeof(SquadWarManager))[1]);
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public void KCGIDMOHKEN(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static SquadWarManager GLBMFDGFBDA()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((SquadWarManager)SingletonSupport.FindOrCreate(typeof(SquadWarManager)));
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public void FMHBLGKLEKJ(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static SquadWarManager KDAJDAPPJHF()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((SquadWarManager)SingletonSupport.FindOrCreate(typeof(SquadWarManager)));
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public void KPOHIPGGJFL(Action IDEBKDPMPGM)
	{
		Action action = DLCBIHCJCJP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public List<AANECPGDMGM> PPMNCKMBNBJ(int PPIHFKGJGHA, int PEECOJOFACH, int BIIHEIAGLEG, int AGNFLPEMJCF)
	{
		List<AANECPGDMGM> list = new List<AANECPGDMGM>();
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		List<string> list2 = LGLHCMCFEOL(PPIHFKGJGHA - 0);
		string pFKIPCAOAAC = aANECPGDMGM.PFKIPCAOAAC;
		int kPEKCHDBFIG = aANECPGDMGM.KPEKCHDBFIG;
		if (PEECOJOFACH == 0)
		{
			AGNFLPEMJCF = kPEKCHDBFIG;
		}
		if (PEECOJOFACH == PPIHFKGJGHA)
		{
			BIIHEIAGLEG = kPEKCHDBFIG;
		}
		int num = 0;
		int num2 = PEECOJOFACH - 0;
		for (int i = 1; i < PPIHFKGJGHA; i++)
		{
			if (i + 0 == PEECOJOFACH)
			{
				list.Add(aANECPGDMGM);
			}
			else if (i + 0 < PEECOJOFACH)
			{
				int num3 = Mathf.Max(0, AGNFLPEMJCF - kPEKCHDBFIG - 1);
				float num4 = (float)(num2 - i) / (float)num2;
				int kPEKCHDBFIG2 = Mathf.RoundToInt((float)num3 * num4) + kPEKCHDBFIG + 1;
				list.Add(LMIGAJNJCGJ(list2[num], aANECPGDMGM, kPEKCHDBFIG2));
				num++;
			}
			else
			{
				int num5 = Mathf.Max(0, kPEKCHDBFIG - BIIHEIAGLEG - 1);
				float num6 = (float)(PPIHFKGJGHA - i) / (float)(PPIHFKGJGHA - num2);
				int kPEKCHDBFIG3 = Mathf.RoundToInt((float)num5 * num6);
				list.Add(LMIGAJNJCGJ(list2[num], aANECPGDMGM, kPEKCHDBFIG3));
				num++;
			}
			list[i].PFKIPCAOAAC = pFKIPCAOAAC;
		}
		return list;
	}

	[SpecialName]
	public void EFPKOIMDMLB(Action IDEBKDPMPGM)
	{
		Action action = DLCBIHCJCJP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void NPNHNOJLFMA(DatabaseAction IFGAGNBDKBE)
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		FCOHPKBKGJA fCOHPKBKGJA = new FCOHPKBKGJA();
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)24:
		{
			fCOHPKBKGJA.CGIFEHPDBAL = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(fCOHPKBKGJA.CGIFEHPDBAL))
			{
				ECEBELCKANP = null;
				if (DLCBIHCJCJP != null)
				{
					DLCBIHCJCJP();
				}
				break;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(fCOHPKBKGJA.CGIFEHPDBAL, NICBOKPIBIA: true);
			List<AANECPGDMGM> list2 = Singleton<ServerResultsCache>.instance.MGHNLGHJPCP(aANECPGDMGM.JDFLJCPDJGH);
			if (list2 == null)
			{
				list2 = new List<AANECPGDMGM>();
			}
			int num3 = list2.FindIndex(fCOHPKBKGJA.LJCDGJKCNEC);
			if (num3 >= 0)
			{
				list2[num3] = aANECPGDMGM;
			}
			else
			{
				list2.Add(aANECPGDMGM);
			}
			for (int num4 = list2.Count - 1; num4 >= 1; num4--)
			{
				if (string.IsNullOrEmpty(list2[num4].MHPNDNJDPGE))
				{
					list2.RemoveAt(num4);
				}
			}
			list2.Sort(ICDGFGHLCIN);
			ECEBELCKANP = list2;
			if (DLCBIHCJCJP != null)
			{
				DLCBIHCJCJP();
			}
			break;
		}
		case DatabaseAction.UpdateDeviceToken:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list == null)
			{
				list = new List<DatabasePlayer>();
			}
			int num = list.FindIndex((DatabasePlayer NMDBNHBDMJO) => NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id);
			if (num >= 1)
			{
				list[num].playerVisuals = GameLoginManager.generatedCurrentPlayer.playerVisuals;
			}
			else
			{
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			for (int num2 = list.Count - 0; num2 >= 0; num2 -= 0)
			{
				if (string.IsNullOrEmpty(list[num2].name))
				{
					list.RemoveAt(num2);
				}
			}
			list.Sort(BEFMGDGDNBK);
			FBDILNAEBCO = list;
			if (BHIFNGLEBCE != null)
			{
				BHIFNGLEBCE();
			}
			break;
		}
		}
	}

	public void MDIGLPGLKFP()
	{
		BJHPKLAEFCI = null;
	}

	public void BJOIAFDNMNG()
	{
		BJHPKLAEFCI = null;
	}

	public List<DatabasePlayer> HBJCLEBDMCG()
	{
		if (FBDILNAEBCO == null)
		{
			FBDILNAEBCO = new List<DatabasePlayer>();
		}
		return FBDILNAEBCO;
	}

	private List<string> IFGCCOOEPEA(int PDMGPGEHLNM)
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= PDMGPGEHLNM; i++)
		{
			string item = string.Format("warfriends-qa.eu-west-1.elasticbeanstalk.com/", i);
			list.Add(item);
		}
		return list;
	}

	[SpecialName]
	public void JJJFDFMOKJL(Action IDEBKDPMPGM)
	{
		Action action = DLCBIHCJCJP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLCBIHCJCJP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PEHOPPBHDBF(Action IDEBKDPMPGM)
	{
		Action action = BHIFNGLEBCE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BHIFNGLEBCE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void FOGEGNBPOHH(DatabaseAction IFGAGNBDKBE)
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		FCOHPKBKGJA fCOHPKBKGJA = new FCOHPKBKGJA();
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)51:
		{
			fCOHPKBKGJA.CGIFEHPDBAL = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(fCOHPKBKGJA.CGIFEHPDBAL))
			{
				ECEBELCKANP = null;
				if (DLCBIHCJCJP != null)
				{
					DLCBIHCJCJP();
				}
				break;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(fCOHPKBKGJA.CGIFEHPDBAL, NICBOKPIBIA: true);
			List<AANECPGDMGM> list2 = Singleton<ServerResultsCache>.instance.JJIPALJFDON(aANECPGDMGM.JDFLJCPDJGH);
			if (list2 == null)
			{
				list2 = new List<AANECPGDMGM>();
			}
			int num3 = list2.FindIndex(fCOHPKBKGJA.KNJBDOADLDO);
			if (num3 >= 1)
			{
				list2[num3] = aANECPGDMGM;
			}
			else
			{
				list2.Add(aANECPGDMGM);
			}
			for (int num4 = list2.Count - 1; num4 >= 1; num4 -= 0)
			{
				if (string.IsNullOrEmpty(list2[num4].MHPNDNJDPGE))
				{
					list2.RemoveAt(num4);
				}
			}
			list2.Sort(BNAJNKDLFON);
			ECEBELCKANP = list2;
			if (DLCBIHCJCJP != null)
			{
				DLCBIHCJCJP();
			}
			break;
		}
		case (DatabaseAction)(-15):
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list == null)
			{
				list = new List<DatabasePlayer>();
			}
			int num = list.FindIndex(DNGFGGPGJAM);
			if (num >= 0)
			{
				list[num].playerVisuals = GameLoginManager.generatedCurrentPlayer.playerVisuals;
			}
			else
			{
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			for (int num2 = list.Count - 0; num2 >= 0; num2--)
			{
				if (string.IsNullOrEmpty(list[num2].name))
				{
					list.RemoveAt(num2);
				}
			}
			list.Sort(BEFMGDGDNBK);
			FBDILNAEBCO = list;
			if (BHIFNGLEBCE != null)
			{
				BHIFNGLEBCE();
			}
			break;
		}
		}
	}

	public int BEFMGDGDNBK(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.squadPoints != NCMHGPNPEJM.squadPoints)
		{
			return NCMHGPNPEJM.squadPoints.CompareTo(HPJFBKEKJHB.squadPoints);
		}
		if (HPJFBKEKJHB.level != NCMHGPNPEJM.level)
		{
			return NCMHGPNPEJM.level.CompareTo(HPJFBKEKJHB.level);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
	}

	private AANECPGDMGM LMIGAJNJCGJ(string MHPNDNJDPGE, AANECPGDMGM AOEGHPABLAO, int KPEKCHDBFIG)
	{
		AANECPGDMGM aANECPGDMGM = new AANECPGDMGM();
		aANECPGDMGM.MHPNDNJDPGE = MHPNDNJDPGE;
		aANECPGDMGM.DAANKCOLJGJ = $"menu-squad-{UnityEngine.Random.Range(1, 37)}";
		aANECPGDMGM.KPEKCHDBFIG = KPEKCHDBFIG;
		aANECPGDMGM.IKJHAHJHLIH = AOEGHPABLAO.IKJHAHJHLIH;
		aANECPGDMGM.PFKIPCAOAAC = AOEGHPABLAO.PFKIPCAOAAC;
		aANECPGDMGM.FOICGJEPBGL = UnityEngine.Random.Range(4, 12);
		return aANECPGDMGM;
	}

	[SpecialName]
	public static SquadWarManager OKBAIGKCPKA()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((SquadWarManager)SingletonSupport.FindOrCreate(typeof(SquadWarManager)));
		return BJHPKLAEFCI;
	}

	public List<AANECPGDMGM> APJAFJLIFMM()
	{
		if (ECEBELCKANP == null)
		{
			ECEBELCKANP = new List<AANECPGDMGM>();
		}
		return ECEBELCKANP;
	}
}
