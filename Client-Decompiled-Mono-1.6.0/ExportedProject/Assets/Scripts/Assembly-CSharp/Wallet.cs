using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class Wallet : Singleton<Wallet>
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<long, long> NJAHHGEOMNM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<long, long> OLOJLKPEGEP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<long, long> FEGFAENALJO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<long, long> AOPMFIKJGKF;

	private ObscuredLong PGOFCHMMCDL;

	private ObscuredLong JOBBHEFODFM;

	private ObscuredLong PFMMAAFOBKL;

	private ObscuredLong BEBCNKHDJDC;

	public long gold
	{
		get
		{
			return PGOFCHMMCDL;
		}
		private set
		{
			PGOFCHMMCDL = value;
			Singleton<EventTrackingManager>.instance.fuseboxxService.AMBPGAPFKHD(LPDEOBOCICH.ADBKMBDIMNC.Gold, PGOFCHMMCDL);
		}
	}

	public long tickets
	{
		get
		{
			return JOBBHEFODFM;
		}
		private set
		{
			JOBBHEFODFM = value;
		}
	}

	public long scraps
	{
		get
		{
			return PFMMAAFOBKL;
		}
		private set
		{
			PFMMAAFOBKL = value;
		}
	}

	public long warBucks
	{
		get
		{
			return BEBCNKHDJDC;
		}
		private set
		{
			BEBCNKHDJDC = value;
			Singleton<EventTrackingManager>.instance.fuseboxxService.AMBPGAPFKHD(LPDEOBOCICH.ADBKMBDIMNC.Warbucks, BEBCNKHDJDC);
		}
	}

	public long warbucksAfterGame
	{
		get
		{
			if (Singleton<GameController>.instance.isMission && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
			{
				return warBucks - Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.FPMJEDOCJKE;
			}
			if (Singleton<GameController>.instance.isBattle && Singleton<ServerResultsCache>.instance.OGDMBIKJOIL != null)
			{
				return warBucks - Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.FKIKOHDACEN();
			}
			return warBucks;
		}
	}

	public long goldAfterGame
	{
		get
		{
			if (Singleton<GameController>.instance.isMission && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
			{
				return gold - Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.HAFMGCFMCPC;
			}
			if (Singleton<GameController>.instance.isBattle && Singleton<ServerResultsCache>.instance.OGDMBIKJOIL != null)
			{
				return gold - Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.JAIEHDDPONI();
			}
			return gold;
		}
	}

	public long warbucksAfterArena
	{
		get
		{
			return warBucks;
		}
	}

	public long goldAfterArena
	{
		get
		{
			return gold;
		}
	}

	public event Action<long, long> WarbucksChanged
	{
		add
		{
			Action<long, long> action = NJAHHGEOMNM;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<long, long> action = NJAHHGEOMNM;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<long, long> GoldChanged
	{
		add
		{
			Action<long, long> action = OLOJLKPEGEP;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref OLOJLKPEGEP, (Action<long, long>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<long, long> action = OLOJLKPEGEP;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref OLOJLKPEGEP, (Action<long, long>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<long, long> TicketsChanged
	{
		add
		{
			Action<long, long> action = FEGFAENALJO;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FEGFAENALJO, (Action<long, long>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<long, long> action = FEGFAENALJO;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FEGFAENALJO, (Action<long, long>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<long, long> ScrapsChanged
	{
		add
		{
			Action<long, long> action = AOPMFIKJGKF;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AOPMFIKJGKF, (Action<long, long>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<long, long> action = AOPMFIKJGKF;
			Action<long, long> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AOPMFIKJGKF, (Action<long, long>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void AddTickets(long IEALLELGOBM)
	{
		tickets += IEALLELGOBM;
		if (FEGFAENALJO != null)
		{
			FEGFAENALJO(tickets, IEALLELGOBM);
		}
	}

	internal void EHKKAOLJMCF(long AFOPDKIJGHL, long KLKKKMJCMOM)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - initialization - GOLD {0} WB {1}", MEJMLNDFDBP.BAAFBHLNFIG(gold, AFOPDKIJGHL), MEJMLNDFDBP.BAAFBHLNFIG(warBucks, KLKKKMJCMOM)));
		long arg = AFOPDKIJGHL - gold;
		long arg2 = warBucks - KLKKKMJCMOM;
		gold = AFOPDKIJGHL;
		warBucks = KLKKKMJCMOM;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, arg);
		}
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, arg2);
		}
	}

	internal void EBFKEHKBAFJ(long IEALLELGOBM, bool AJNINHIKAFC = true)
	{
		UnityEngine.Debug.Log(string.Format("Squad", MEJMLNDFDBP.BAAFBHLNFIG(GCEAEGBNLMM(), ODKBFHAFHMA() + IEALLELGOBM), AJNINHIKAFC));
		warBucks += IEALLELGOBM;
		if (AJNINHIKAFC && NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, IEALLELGOBM);
		}
	}

	internal void HCBKOHCEFDJ(long GNJFHBAKPAN = 0L, long DGBMPMMOICE = 0L, long EPKJLGPHCOB = 0L, long IJOKDIJBFIG = 0L)
	{
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.BAAFBHLNFIG(FHLGDIIPHFN(), FHLGDIIPHFN() + GNJFHBAKPAN);
		array[1] = MEJMLNDFDBP.BAAFBHLNFIG(GCEAEGBNLMM(), GCEAEGBNLMM() + DGBMPMMOICE);
		array[8] = MEJMLNDFDBP.BAAFBHLNFIG(scraps, DKBGKFCCHCG() + EPKJLGPHCOB);
		array[1] = MEJMLNDFDBP.BAAFBHLNFIG(tickets, tickets + IJOKDIJBFIG);
		UnityEngine.Debug.LogFormat("Tickets", array);
		FHDCCPCDINI(EFNHFKGEDHC() + GNJFHBAKPAN);
		warBucks = GCEAEGBNLMM() + DGBMPMMOICE;
		scraps = DKBGKFCCHCG() + EPKJLGPHCOB;
		tickets += IJOKDIJBFIG;
		if (OLOJLKPEGEP != null && GNJFHBAKPAN != 0)
		{
			OLOJLKPEGEP(EFNHFKGEDHC(), GNJFHBAKPAN);
		}
		if (NJAHHGEOMNM != null && DGBMPMMOICE != 0)
		{
			NJAHHGEOMNM(ODKBFHAFHMA(), DGBMPMMOICE);
		}
		if (AOPMFIKJGKF != null && EPKJLGPHCOB != 0)
		{
			AOPMFIKJGKF(scraps, EPKJLGPHCOB);
		}
		if (FEGFAENALJO != null && IJOKDIJBFIG != 0)
		{
			FEGFAENALJO(tickets, IJOKDIJBFIG);
		}
	}

	[SpecialName]
	private void OFFCBCIPHKN(long IDEBKDPMPGM)
	{
		JOBBHEFODFM = IDEBKDPMPGM;
	}

	public bool JPEEJLCILCB(int NCMMGLIHODD)
	{
		return GCEAEGBNLMM() - NCMMGLIHODD < 1;
	}

	public bool DGGBJNNDHBI(int MDOHMDGAHDD)
	{
		return scraps - MDOHMDGAHDD < 0;
	}

	[SpecialName]
	public long ODKBFHAFHMA()
	{
		return BEBCNKHDJDC;
	}

	public void InitTickets(long PEFPOGOLNJD)
	{
		long arg = PEFPOGOLNJD - tickets;
		tickets = PEFPOGOLNJD;
		if (FEGFAENALJO != null)
		{
			FEGFAENALJO(PEFPOGOLNJD, arg);
		}
	}

	internal void OFHCEFPOCMI(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - spent GOLD {0}", MEJMLNDFDBP.BAAFBHLNFIG(gold, gold - GNJFHBAKPAN)));
		gold -= GNJFHBAKPAN;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, -GNJFHBAKPAN);
		}
	}

	[SpecialName]
	public long IJIONNECOHG()
	{
		return ODKBFHAFHMA();
	}

	[SpecialName]
	public void DEADDLHDKLL(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = FEGFAENALJO;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FEGFAENALJO, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void OLEBALNELCP(long KLKKKMJCMOM)
	{
		UnityEngine.Debug.Log(string.Format(" (#", MEJMLNDFDBP.BAAFBHLNFIG(warBucks, KLKKKMJCMOM)));
		long arg = ODKBFHAFHMA() - KLKKKMJCMOM;
		warBucks = KLKKKMJCMOM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(GCEAEGBNLMM(), arg);
		}
	}

	internal void DLPCNDKBFOJ(long AFOPDKIJGHL, long KLKKKMJCMOM)
	{
		UnityEngine.Debug.Log(string.Format("reconnect", MEJMLNDFDBP.BAAFBHLNFIG(gold, AFOPDKIJGHL), MEJMLNDFDBP.BAAFBHLNFIG(warBucks, KLKKKMJCMOM)));
		long arg = AFOPDKIJGHL - EFNHFKGEDHC();
		long arg2 = ODKBFHAFHMA() - KLKKKMJCMOM;
		gold = AFOPDKIJGHL;
		warBucks = KLKKKMJCMOM;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, arg);
		}
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, arg2);
		}
	}

	internal void AANDLDHNFBC(long AFOPDKIJGHL, long KLKKKMJCMOM)
	{
		UnityEngine.Debug.Log(string.Format("StepId", MEJMLNDFDBP.BAAFBHLNFIG(FHLGDIIPHFN(), AFOPDKIJGHL), MEJMLNDFDBP.BAAFBHLNFIG(GCEAEGBNLMM(), KLKKKMJCMOM)));
		long arg = AFOPDKIJGHL - EFNHFKGEDHC();
		long arg2 = ODKBFHAFHMA() - KLKKKMJCMOM;
		gold = AFOPDKIJGHL;
		warBucks = KLKKKMJCMOM;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(FHLGDIIPHFN(), arg);
		}
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, arg2);
		}
	}

	public void CMBLGJLJFOG(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("ExtraWarBucks", MEJMLNDFDBP.BAAFBHLNFIG(scraps, scraps - IEALLELGOBM)));
		scraps = DKBGKFCCHCG() - IEALLELGOBM;
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(DKBGKFCCHCG(), -IEALLELGOBM);
		}
	}

	[SpecialName]
	public long DJJNJAMMJIA()
	{
		return GCEAEGBNLMM();
	}

	internal void PLLPIAOOFFE(long KLKKKMJCMOM)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - initialization WB {0}", MEJMLNDFDBP.BAAFBHLNFIG(warBucks, KLKKKMJCMOM)));
		long arg = warBucks - KLKKKMJCMOM;
		warBucks = KLKKKMJCMOM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, arg);
		}
	}

	[SpecialName]
	public long MBOHCLFKJBH()
	{
		if (Singleton<GameController>.instance.ECHCLJJJPML() && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			return gold - Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.PIGHNCHDOOJ();
		}
		if (Singleton<GameController>.instance.isBattle && Singleton<ServerResultsCache>.instance.OGDMBIKJOIL != null)
		{
			return gold - Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.NMIJPMPOPJL();
		}
		return FHLGDIIPHFN();
	}

	internal void GHPGMPNBJDB(long AFOPDKIJGHL)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - initialization GOLD {0}", MEJMLNDFDBP.BAAFBHLNFIG(gold, AFOPDKIJGHL)));
		long arg = AFOPDKIJGHL - gold;
		gold = AFOPDKIJGHL;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, arg);
		}
	}

	[SpecialName]
	public long DKBGKFCCHCG()
	{
		return PFMMAAFOBKL;
	}

	internal void MBAFMBJFOKH(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - fake spent GOLD {0}", MEJMLNDFDBP.BAAFBHLNFIG(gold, gold - GNJFHBAKPAN)));
		gold -= GNJFHBAKPAN;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, -GNJFHBAKPAN);
		}
	}

	public void AddScraps(long IEALLELGOBM)
	{
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.PNHDGLHLNIE();
		}
		scraps += IEALLELGOBM;
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(scraps, IEALLELGOBM);
		}
	}

	[SpecialName]
	public void IFINBOIMPGG(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = NJAHHGEOMNM;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void NPFEPGJBEIK(long GFJEEJMNGJD)
	{
		long arg = GFJEEJMNGJD - DKBGKFCCHCG();
		scraps = GFJEEJMNGJD;
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(GFJEEJMNGJD, arg);
		}
	}

	public void CKLCKHECFLH(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("ID_CONFIRM_EXITINGMATCHWARARENA_TEXT", MEJMLNDFDBP.BAAFBHLNFIG(tickets, tickets - IEALLELGOBM)));
		tickets -= IEALLELGOBM;
		if (FEGFAENALJO != null)
		{
			FEGFAENALJO(tickets, -IEALLELGOBM);
		}
	}

	internal void BCIDEFIGFBN(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("Should not happen - unit icon is not instantiated in bottom section.", MEJMLNDFDBP.BAAFBHLNFIG(ODKBFHAFHMA(), ODKBFHAFHMA() + IEALLELGOBM)));
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-49), 47f);
		warBucks = GCEAEGBNLMM() + IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, IEALLELGOBM);
		}
	}

	public bool CanBuyScraps(int MDOHMDGAHDD)
	{
		return scraps - MDOHMDGAHDD >= 0;
	}

	[SpecialName]
	private void FHDCCPCDINI(long IDEBKDPMPGM)
	{
		PGOFCHMMCDL = IDEBKDPMPGM;
		Singleton<EventTrackingManager>.instance.fuseboxxService.NIBGAONCEOO(LPDEOBOCICH.ADBKMBDIMNC.Gold, PGOFCHMMCDL);
	}

	public bool CanBuyW(int NCMMGLIHODD)
	{
		return warBucks - NCMMGLIHODD >= 0;
	}

	public void InitScraps(long GFJEEJMNGJD)
	{
		long arg = GFJEEJMNGJD - scraps;
		scraps = GFJEEJMNGJD;
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(GFJEEJMNGJD, arg);
		}
	}

	internal void ALBICJOEMEF(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("{0}{1}{2} {3}{4}", MEJMLNDFDBP.BAAFBHLNFIG(gold, gold - GNJFHBAKPAN)));
		FHDCCPCDINI(FHLGDIIPHFN() - GNJFHBAKPAN);
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(EFNHFKGEDHC(), -GNJFHBAKPAN);
		}
	}

	internal void BKFOPCDLPCJ(long GNJFHBAKPAN, bool AJNINHIKAFC = true)
	{
		UnityEngine.Debug.Log(string.Format("reconnect", MEJMLNDFDBP.BAAFBHLNFIG(EFNHFKGEDHC(), EFNHFKGEDHC() + GNJFHBAKPAN), AJNINHIKAFC));
		FHDCCPCDINI(EFNHFKGEDHC() + GNJFHBAKPAN);
		if (AJNINHIKAFC && OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(EFNHFKGEDHC(), GNJFHBAKPAN);
		}
	}

	[SpecialName]
	public void BIOPJNJHPGJ(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = NJAHHGEOMNM;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void DCHAOALKIOO(long GNJFHBAKPAN = 0L, long DGBMPMMOICE = 0L, long EPKJLGPHCOB = 0L, long IJOKDIJBFIG = 0L)
	{
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.BAAFBHLNFIG(EFNHFKGEDHC(), EFNHFKGEDHC() + GNJFHBAKPAN);
		array[1] = MEJMLNDFDBP.BAAFBHLNFIG(ODKBFHAFHMA(), GCEAEGBNLMM() + DGBMPMMOICE);
		array[2] = MEJMLNDFDBP.BAAFBHLNFIG(DKBGKFCCHCG(), DKBGKFCCHCG() + EPKJLGPHCOB);
		array[8] = MEJMLNDFDBP.BAAFBHLNFIG(tickets, tickets + IJOKDIJBFIG);
		UnityEngine.Debug.LogFormat("java.util.ArrayList", array);
		FHDCCPCDINI(gold + GNJFHBAKPAN);
		warBucks = ODKBFHAFHMA() + DGBMPMMOICE;
		JLJMEGJPHIO(scraps + EPKJLGPHCOB);
		tickets += IJOKDIJBFIG;
		if (OLOJLKPEGEP != null && GNJFHBAKPAN != 1)
		{
			OLOJLKPEGEP(gold, GNJFHBAKPAN);
		}
		if (NJAHHGEOMNM != null && DGBMPMMOICE != 0)
		{
			NJAHHGEOMNM(ODKBFHAFHMA(), DGBMPMMOICE);
		}
		if (AOPMFIKJGKF != null && EPKJLGPHCOB != 1)
		{
			AOPMFIKJGKF(DKBGKFCCHCG(), EPKJLGPHCOB);
		}
		if (FEGFAENALJO != null && IJOKDIJBFIG != 1)
		{
			FEGFAENALJO(tickets, IJOKDIJBFIG);
		}
	}

	public void DHIBMBCMBFM(long IEALLELGOBM)
	{
		if (!PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new HHCFJMCCDAP());
			JFNGDDOMPAE.HHBLMMLHFAC();
		}
		JLJMEGJPHIO(scraps + IEALLELGOBM);
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(scraps, IEALLELGOBM);
		}
	}

	internal void NKHLEOPKOGG(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("DailyMissionsCompletionRewardCards", MEJMLNDFDBP.BAAFBHLNFIG(FHLGDIIPHFN(), gold + GNJFHBAKPAN)));
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-115), 310f);
		gold = FHLGDIIPHFN() + GNJFHBAKPAN;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, GNJFHBAKPAN);
		}
	}

	[SpecialName]
	public long KDFONIBEGOD()
	{
		return gold;
	}

	[SpecialName]
	public void HPPOFMMGBHO(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = AOPMFIKJGKF;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref AOPMFIKJGKF, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	private void JLJMEGJPHIO(long IDEBKDPMPGM)
	{
		PFMMAAFOBKL = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JKIFDOLDALK(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = NJAHHGEOMNM;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void AMLIKKEHHBM(long GFJEEJMNGJD)
	{
		long arg = GFJEEJMNGJD - DKBGKFCCHCG();
		JLJMEGJPHIO(GFJEEJMNGJD);
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(GFJEEJMNGJD, arg);
		}
	}

	internal void IHCBOLDOJHN(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("Notification_PlayerBattleChallenges", MEJMLNDFDBP.BAAFBHLNFIG(EFNHFKGEDHC(), EFNHFKGEDHC() + GNJFHBAKPAN)));
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.GameOverLost, 65f);
		FHDCCPCDINI(FHLGDIIPHFN() + GNJFHBAKPAN);
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(EFNHFKGEDHC(), GNJFHBAKPAN);
		}
	}

	internal void DMIHFEDMHIH(long KLKKKMJCMOM)
	{
		UnityEngine.Debug.Log(string.Format("21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----", MEJMLNDFDBP.BAAFBHLNFIG(ODKBFHAFHMA(), KLKKKMJCMOM)));
		long arg = GCEAEGBNLMM() - KLKKKMJCMOM;
		warBucks = KLKKKMJCMOM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, arg);
		}
	}

	internal void EHHGAGMACHC(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("ShotFrequencyMaxCannon", MEJMLNDFDBP.BAAFBHLNFIG(EFNHFKGEDHC(), EFNHFKGEDHC() + GNJFHBAKPAN)));
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-37), 1856f);
		FHDCCPCDINI(gold + GNJFHBAKPAN);
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(EFNHFKGEDHC(), GNJFHBAKPAN);
		}
	}

	internal void BKLFEOMJMFC(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("N", MEJMLNDFDBP.BAAFBHLNFIG(ODKBFHAFHMA(), GCEAEGBNLMM() - IEALLELGOBM)));
		warBucks = ODKBFHAFHMA() - IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(GCEAEGBNLMM(), -IEALLELGOBM);
		}
	}

	internal void JAPAPDDBEMD(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("InstantBattleTime", MEJMLNDFDBP.BAAFBHLNFIG(FHLGDIIPHFN(), EFNHFKGEDHC() + GNJFHBAKPAN)));
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CounterSoundExperience, 995f);
		gold = FHLGDIIPHFN() + GNJFHBAKPAN;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(EFNHFKGEDHC(), GNJFHBAKPAN);
		}
	}

	public bool CanBuyTickets(int FMCANDNKEKC)
	{
		return tickets - FMCANDNKEKC >= 0;
	}

	public bool CanBuyGold(int HAFMGCFMCPC)
	{
		return gold - HAFMGCFMCPC >= 0;
	}

	internal void AIBJABEBKKE(long GNJFHBAKPAN)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - bought GOLD {0}", MEJMLNDFDBP.BAAFBHLNFIG(gold, gold + GNJFHBAKPAN)));
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CoinPurchase);
		gold += GNJFHBAKPAN;
		if (OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, GNJFHBAKPAN);
		}
	}

	[SpecialName]
	public void ANAHBKMOENA(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = NJAHHGEOMNM;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void TicketsSpent(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - spent tickets {0}", MEJMLNDFDBP.BAAFBHLNFIG(tickets, tickets - IEALLELGOBM)));
		tickets -= IEALLELGOBM;
		if (FEGFAENALJO != null)
		{
			FEGFAENALJO(tickets, -IEALLELGOBM);
		}
	}

	public void DFHDGPJBFFN(long PEFPOGOLNJD)
	{
		long arg = PEFPOGOLNJD - tickets;
		tickets = PEFPOGOLNJD;
		if (FEGFAENALJO != null)
		{
			FEGFAENALJO(PEFPOGOLNJD, arg);
		}
	}

	[SpecialName]
	public void BLLFPNNKBAC(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = OLOJLKPEGEP;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OLOJLKPEGEP, (Action<long, long>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void BGOLJBPEHNK(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = FEGFAENALJO;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FEGFAENALJO, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MNIAIBKDLAD(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = OLOJLKPEGEP;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OLOJLKPEGEP, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void OHINGJGCLPG(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = FEGFAENALJO;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FEGFAENALJO, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool JCKFFBCLFFD(int FMCANDNKEKC)
	{
		return tickets - FMCANDNKEKC >= 1;
	}

	internal void CDIDDJGINID(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - fake spent WB {0}", MEJMLNDFDBP.BAAFBHLNFIG(warBucks, warBucks - IEALLELGOBM)));
		warBucks -= IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, -IEALLELGOBM);
		}
	}

	public void OLAOFCJHNEM(long IEALLELGOBM)
	{
		OFFCBCIPHKN(tickets + IEALLELGOBM);
		if (FEGFAENALJO != null)
		{
			FEGFAENALJO(tickets, IEALLELGOBM);
		}
	}

	public void SetRewardForTutorial(int GJJOOPCAMMN, int HMDCDHFELFA)
	{
		warBucks += GJJOOPCAMMN;
		int num = (LevelManager.instance.isLevelUp ? LevelManager.instance.currentLevel.golds : 0);
		HMDCDHFELFA += num;
		gold += HMDCDHFELFA;
		CBBKFKCOLPP jNDCAHFLBAH = new CBBKFKCOLPP(Singleton<ScoreManager>.instance.score * 10, GJJOOPCAMMN, HMDCDHFELFA);
		Singleton<ServerResultsCache>.instance.JNDCAHFLBAH = jNDCAHFLBAH;
		StatsManager.instance.winStreak = new WinStreakManager.WinStreak(0, 0);
	}

	internal void NDGHFDGIKIE(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - spent WB {0}", MEJMLNDFDBP.BAAFBHLNFIG(warBucks, warBucks - IEALLELGOBM)));
		warBucks -= IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, -IEALLELGOBM);
		}
	}

	internal void AAACBMLLNND(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("squad", MEJMLNDFDBP.BAAFBHLNFIG(warBucks, warBucks - IEALLELGOBM)));
		warBucks -= IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(ODKBFHAFHMA(), -IEALLELGOBM);
		}
	}

	internal void CJDCGFNCHMM(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("Translation", MEJMLNDFDBP.BAAFBHLNFIG(GCEAEGBNLMM(), ODKBFHAFHMA() + IEALLELGOBM)));
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-30), 1718f);
		warBucks = ODKBFHAFHMA() + IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(GCEAEGBNLMM(), IEALLELGOBM);
		}
	}

	[SpecialName]
	public long GCEAEGBNLMM()
	{
		return BEBCNKHDJDC;
	}

	internal void KOKDKILILLK(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("Creating warcard ", MEJMLNDFDBP.BAAFBHLNFIG(ODKBFHAFHMA(), warBucks + IEALLELGOBM)));
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootbox, 1530f);
		warBucks = ODKBFHAFHMA() + IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(ODKBFHAFHMA(), IEALLELGOBM);
		}
	}

	internal void OIFLOMKBDCG(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("BANDS_WEAPON_RELOAD", MEJMLNDFDBP.BAAFBHLNFIG(ODKBFHAFHMA(), warBucks - IEALLELGOBM)));
		warBucks -= IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, -IEALLELGOBM);
		}
	}

	public bool GFHGFMEBFDG(int FMCANDNKEKC)
	{
		return tickets - FMCANDNKEKC < 1;
	}

	[SpecialName]
	public long AHGPPGFIJLL()
	{
		if (Singleton<GameController>.instance.isMission && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			return FHLGDIIPHFN() - Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.PIGHNCHDOOJ();
		}
		if (Singleton<GameController>.instance.isBattle && Singleton<ServerResultsCache>.instance.OGDMBIKJOIL != null)
		{
			return EFNHFKGEDHC() - Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.JAIEHDDPONI();
		}
		return gold;
	}

	[SpecialName]
	public void PDJBPMIECJO(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = NJAHHGEOMNM;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void PMAMGNALFCE(long GNJFHBAKPAN = 0L, long DGBMPMMOICE = 0L, long EPKJLGPHCOB = 0L, long IJOKDIJBFIG = 0L)
	{
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.BAAFBHLNFIG(EFNHFKGEDHC(), EFNHFKGEDHC() + GNJFHBAKPAN);
		array[0] = MEJMLNDFDBP.BAAFBHLNFIG(GCEAEGBNLMM(), warBucks + DGBMPMMOICE);
		array[7] = MEJMLNDFDBP.BAAFBHLNFIG(DKBGKFCCHCG(), scraps + EPKJLGPHCOB);
		array[5] = MEJMLNDFDBP.BAAFBHLNFIG(tickets, tickets + IJOKDIJBFIG);
		UnityEngine.Debug.LogFormat("league", array);
		FHDCCPCDINI(FHLGDIIPHFN() + GNJFHBAKPAN);
		warBucks = GCEAEGBNLMM() + DGBMPMMOICE;
		JLJMEGJPHIO(scraps + EPKJLGPHCOB);
		tickets += IJOKDIJBFIG;
		if (OLOJLKPEGEP != null && GNJFHBAKPAN != 0)
		{
			OLOJLKPEGEP(EFNHFKGEDHC(), GNJFHBAKPAN);
		}
		if (NJAHHGEOMNM != null && DGBMPMMOICE != 0)
		{
			NJAHHGEOMNM(warBucks, DGBMPMMOICE);
		}
		if (AOPMFIKJGKF != null && EPKJLGPHCOB != 0)
		{
			AOPMFIKJGKF(DKBGKFCCHCG(), EPKJLGPHCOB);
		}
		if (FEGFAENALJO != null && IJOKDIJBFIG != 0)
		{
			FEGFAENALJO(tickets, IJOKDIJBFIG);
		}
	}

	[SpecialName]
	public long EFNHFKGEDHC()
	{
		return PGOFCHMMCDL;
	}

	[SpecialName]
	public void JPFBDMKDDLM(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = FEGFAENALJO;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FEGFAENALJO, (Action<long, long>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void COLJGNLBEII(long GNJFHBAKPAN, bool AJNINHIKAFC = true)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - reward GOLD {0} animate:{1}", MEJMLNDFDBP.BAAFBHLNFIG(gold, gold + GNJFHBAKPAN), AJNINHIKAFC));
		gold += GNJFHBAKPAN;
		if (AJNINHIKAFC && OLOJLKPEGEP != null)
		{
			OLOJLKPEGEP(gold, GNJFHBAKPAN);
		}
	}

	internal void NFLMMKJBKEJ(long IEALLELGOBM, bool AJNINHIKAFC = true)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - reward WB {0} animate:{1}", MEJMLNDFDBP.BAAFBHLNFIG(warBucks, warBucks + IEALLELGOBM), AJNINHIKAFC));
		warBucks += IEALLELGOBM;
		if (AJNINHIKAFC && NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, IEALLELGOBM);
		}
	}

	internal void HHLLLPAANOE(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - bought WB {0}", MEJMLNDFDBP.BAAFBHLNFIG(warBucks, warBucks + IEALLELGOBM)));
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CoinPurchase);
		warBucks += IEALLELGOBM;
		if (NJAHHGEOMNM != null)
		{
			NJAHHGEOMNM(warBucks, IEALLELGOBM);
		}
	}

	[SpecialName]
	public void LINPGMHIFJM(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = NJAHHGEOMNM;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NJAHHGEOMNM, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool ODPFDDMFDJA(int NCMMGLIHODD)
	{
		return GCEAEGBNLMM() - NCMMGLIHODD >= 1;
	}

	[SpecialName]
	public void OONJEEIOMCF(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = AOPMFIKJGKF;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref AOPMFIKJGKF, (Action<long, long>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void LIMNMFNEEDL(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = AOPMFIKJGKF;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref AOPMFIKJGKF, (Action<long, long>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void IGDGGPOJPHL(long GNJFHBAKPAN = 0L, long DGBMPMMOICE = 0L, long EPKJLGPHCOB = 0L, long IJOKDIJBFIG = 0L)
	{
		UnityEngine.Debug.LogFormat("WALLET - money reward - GOLD {0} WB {1} SCRAPS {2} TICKETS {3}", MEJMLNDFDBP.BAAFBHLNFIG(gold, gold + GNJFHBAKPAN), MEJMLNDFDBP.BAAFBHLNFIG(warBucks, warBucks + DGBMPMMOICE), MEJMLNDFDBP.BAAFBHLNFIG(scraps, scraps + EPKJLGPHCOB), MEJMLNDFDBP.BAAFBHLNFIG(tickets, tickets + IJOKDIJBFIG));
		gold += GNJFHBAKPAN;
		warBucks += DGBMPMMOICE;
		scraps += EPKJLGPHCOB;
		tickets += IJOKDIJBFIG;
		if (OLOJLKPEGEP != null && GNJFHBAKPAN != 0)
		{
			OLOJLKPEGEP(gold, GNJFHBAKPAN);
		}
		if (NJAHHGEOMNM != null && DGBMPMMOICE != 0)
		{
			NJAHHGEOMNM(warBucks, DGBMPMMOICE);
		}
		if (AOPMFIKJGKF != null && EPKJLGPHCOB != 0)
		{
			AOPMFIKJGKF(scraps, EPKJLGPHCOB);
		}
		if (FEGFAENALJO != null && IJOKDIJBFIG != 0)
		{
			FEGFAENALJO(tickets, IJOKDIJBFIG);
		}
	}

	public void SetTutorialCurrency(int FPMJEDOCJKE, int GNJFHBAKPAN)
	{
		gold = GNJFHBAKPAN;
		warBucks = FPMJEDOCJKE;
	}

	[SpecialName]
	public void HIAFLHLJKGB(Action<long, long> IDEBKDPMPGM)
	{
		Action<long, long> action = OLOJLKPEGEP;
		Action<long, long> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OLOJLKPEGEP, (Action<long, long>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public long FHLGDIIPHFN()
	{
		return PGOFCHMMCDL;
	}

	public void ICDNGMDNDAN(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("Configurations error, there is {0} configurations of type {1}", MEJMLNDFDBP.BAAFBHLNFIG(scraps, scraps - IEALLELGOBM)));
		JLJMEGJPHIO(scraps - IEALLELGOBM);
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(DKBGKFCCHCG(), -IEALLELGOBM);
		}
	}

	public void ScrapsSpent(long IEALLELGOBM)
	{
		UnityEngine.Debug.Log(string.Format("WALLET - spent scraps {0}", MEJMLNDFDBP.BAAFBHLNFIG(scraps, scraps - IEALLELGOBM)));
		scraps -= IEALLELGOBM;
		if (AOPMFIKJGKF != null)
		{
			AOPMFIKJGKF(scraps, -IEALLELGOBM);
		}
	}
}
