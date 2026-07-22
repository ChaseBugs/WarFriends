using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadWarEndDialog : GuiElementSingle<SquadWarEndDialog>, PAIIOKBBHBC
{
	[Header("Left Part")]
	[FormerlySerializedAs("HJKHJLNNMAG")]
	public UITable LFKGHKNKHOL;

	[FormerlySerializedAs("HLIHJDECJAO")]
	public UITexture GEAGOKJMJFD;

	[FormerlySerializedAs("OFOMNJAPIBJ")]
	public UILabel CGIFEHPDBAL;

	[FormerlySerializedAs("IEJPOMOKLBK")]
	public UILabel PEECOJOFACH;

	[FormerlySerializedAs("ILKBDEFKCHB")]
	public UITable AJLDACMAIPI;

	[FormerlySerializedAs("MIDDJEBNOGN")]
	public UILabel IKFHJFIIKJE;

	[FormerlySerializedAs("ECMMODBOMLA")]
	public UILabel DDNCOGPPMDH;

	[FormerlySerializedAs("LKBEFEEPFLG")]
	public UILabel LAEGNMEBCOK;

	[FormerlySerializedAs("AGFCDGJPPKH")]
	public UISprite[] HIPOAECNCJO;

	[FormerlySerializedAs("JPHMKMAADDK")]
	[Header("Left Bottom Part")]
	public UITable OLBGGFNGMAK;

	[FormerlySerializedAs("IIAKCPNBFIF")]
	public UILabel HBJJAEBGNII;

	[FormerlySerializedAs("AKJKAMAHFPM")]
	public UILabel HNLMIGFFBMP;

	[Header("Right List")]
	[FormerlySerializedAs("ICKPAEEPOBH")]
	public UIDraggablePanel NFLPPGKCOBL;

	[FormerlySerializedAs("DGNCEBABJJP")]
	public SquadWarEndMemberRecord ENHFFICNHNC;

	[FormerlySerializedAs("IEMNPCFMDID")]
	public UIPooledGrid NEMLDOPDFND;

	[Header("Bottom Button")]
	[FormerlySerializedAs("IFLNMMJLAPE")]
	public UIButton DMPBNBPBDFD;

	[FormerlySerializedAs("NMJCMEPOLON")]
	public UILabel GMBJHOCENGD;

	private string AKEOMKLDIIF;

	private string KGFHEAPPLFJ;

	private int JNJDCCMKPBI;

	private int EJAFHHOOGOH;

	private int MBFPGPOBBJL;

	private int NOOGOKLLFHA;

	private int CAJLKKFFOLO;

	private List<SquadWarsContent.IAIOAHOIDOF> JHGLKIKLGJK;

	private HHFHFANGCEJ NGDKKFFCGCI;

	[CompilerGenerated]
	private static Predicate<SquadWarsContent.IAIOAHOIDOF> LGJCBPOPCPA;

	public virtual void CBDEMEDELHL()
	{
		bool flag = EJAFHHOOGOH < 0;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 0;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(OJEPLCBKMKB);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("ID_CLAIM" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(819f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = false;
		UILabel pEECOJOFACH = PEECOJOFACH;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper();
		pEECOJOFACH.text = Localization.LocalizeFormat("EndReason", array);
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = false;
		DDNCOGPPMDH.text = Localization.Localize((num > 1) ? "URL" : ((num >= 0) ? "ERROR CLAIM ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED" : "05"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 859f, 714f, -89);
		LAEGNMEBCOK.text = string.Format("ID_HEROICMISSIONX", Localization.Localize("ID_OK"), -51 - CAJLKKFFOLO);
		for (int i = 0; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, NNOMHFPDKLM, EHCLCOLDNJD, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("App not installed") : Localization.Localize("gold"));
	}

	private void MFGKKKADKAK()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1931f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void KBMBNDOBGIH()
	{
		base.DoAfterHide();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	private void EHCLCOLDNJD(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	public virtual void EIPCLGCNKGO()
	{
		FMFNFGBMADA(DMPBNBPBDFD.gameObject);
	}

	private static bool HNDGFJOGEEB(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	public virtual void LNHLMINOKGO()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	public GuiElement JEAMNJAPFJK()
	{
		return this;
	}

	private void OMFEFJDIAFI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log(string.Format("====== Waiting to connect to photon: ", EJAFHHOOGOH));
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning("InApp_ID");
			}
		}
	}

	public override void OnBack()
	{
		IJCLEFNGOMP(DMPBNBPBDFD.gameObject);
	}

	private void KCPGPJPGJLC()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 504f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	private Transform JJDOLANDILI(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("ID_OK", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "ID_WARNING_CONNECTIONERROR" : "ID_REMINDER_THISAMAZINGCUSTOMIZATION")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.PPLIBOAJOCA(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 2f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private void LAGLBMKOAFD(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	public virtual void CKGGNJACIGL()
	{
		DPKELGHKKPA(DMPBNBPBDFD.gameObject);
	}

	[CompilerGenerated]
	private static bool EFNLCPFLBAI(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	private static bool FBJIAGLNIBL(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	public virtual void DLDGKEHFKDP()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	private static bool GNMCJFPNION(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	public void EBELHKPCLBI(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.KJNIJCBJJDE().HEKABLHCGHC);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 838f);
	}

	public virtual void BAAOGDMJCLK()
	{
		bool flag = EJAFHHOOGOH < 0;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 1;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(HNDGFJOGEEB);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("menu-powerband-health-ico" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(1151f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = false;
		PEECOJOFACH.text = Localization.LocalizeFormat("BUDDY WARCARD", MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper());
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = false;
		DDNCOGPPMDH.text = Localization.Localize((num > 1) ? "Warfriend" : ((num >= 1) ? "LevelExperience" : "{0} {1}{2}"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 338f, 1475f, -108);
		LAEGNMEBCOK.text = string.Format("ID_EMPTYUNITTRAIN", Localization.Localize("accountId"), -99 - CAJLKKFFOLO);
		for (int i = 1; i < HIPOAECNCJO.Length; i++)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, GDJEAIPNGIL, ILLCFCKOFHO, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("\n") : Localization.Localize("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} scraps"));
	}

	private void CLEHONMPGHI()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1828f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private void BPADNOGBBPG()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 1978f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void MFBOBBCJLOD()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public virtual void NJGCIDCPPAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IJCLEFNGOMP));
		LFKGHKNKHOL.onReposition = BAFNOAACHIA;
		AJLDACMAIPI.onReposition = FIOHHANEGNP;
		OLBGGFNGMAK.onReposition = MLNMKAOMJAA;
	}

	private void DPKELGHKKPA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log(string.Format("Start", EJAFHHOOGOH));
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning("Application focus changed to {0} and have created AWS mobile analytics {1}");
			}
		}
	}

	private void GAKPLBHCJGH(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private void KOGKOMPPIDH(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void LAJPKHGFBGL()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 1045f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	private static bool MDJBAPPICFA(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB == null || NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	private void CONMNAAJHAL()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 1739f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void ODDKEELDBJF()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	public void FACFLKKLGEB(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.OKBAIGKCPKA().SortFunctionPlayers);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.NIMBHACOENJ(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 1850f);
	}

	public void NGBCDPEPOOB(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.instance.FPAPKAAAMFM);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.NIMBHACOENJ(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 843f);
	}

	private Transform MOHJDBDGPHE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("Start TimeLock: ", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "ArenaLives" : "#AccoutCheck# FB login during tutorial")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.MCONFEEMOLE(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	public virtual void EIKAKAMAPIO()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 2f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void BNCDFKGNPII()
	{
		ICDBFHEDHNP(DMPBNBPBDFD.gameObject);
	}

	private void GFANDPCCKAF()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 682f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	private void CEJJCENBBIK(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	public virtual void LLFCBMDKMOL()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public virtual void KIECGCGABFJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OMFEFJDIAFI));
		LFKGHKNKHOL.onReposition = LMGBCIFHGFL;
		AJLDACMAIPI.onReposition = FIOHHANEGNP;
		OLBGGFNGMAK.onReposition = MGHGKCDPHGD;
	}

	private void CCGAOKKBBIC()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1099f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	public virtual void BPKMFPOHJCG()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	private void CJLJNFCFKPI()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 1325f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void ENKGEFMNGOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMFNFGBMADA));
		LFKGHKNKHOL.onReposition = CCGAOKKBBIC;
		AJLDACMAIPI.onReposition = BPADNOGBBPG;
		OLBGGFNGMAK.onReposition = KCPGPJPGJLC;
	}

	public GuiElement PKCKPALMHMO()
	{
		return this;
	}

	private void LNGHBKPJHEI(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private static bool CECBAMBJPEC(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	private Transform LMKHBDELHEF(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("{0:3} {1}", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "Squad Member" : "Header")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.Initialize(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	private void OCDMNLKGCHJ()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 304f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void EMIJACMANFB()
	{
		OMFEFJDIAFI(DMPBNBPBDFD.gameObject);
	}

	public virtual void PBAEIEJPLBC()
	{
		OMFEFJDIAFI(DMPBNBPBDFD.gameObject);
	}

	private void FKCALGEPEMD()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1866f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	private void HLMFBJLHOGH()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1927f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private void IJCLEFNGOMP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log($"SquadWarEndDialog - Claiming gold: {EJAFHHOOGOH}");
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning("SquadWarEndDialog - Database message not set.");
			}
		}
	}

	private void FIOHHANEGNP()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 1488f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	private Transform GDJEAIPNGIL(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("): ", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "machinegn_reload" : "CardId")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.GHFHNLNHCFC(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMFNFGBMADA));
		LFKGHKNKHOL.onReposition = MFGKKKADKAK;
		AJLDACMAIPI.onReposition = LAJPKHGFBGL;
		OLBGGFNGMAK.onReposition = GJJIJFNFPKD;
	}

	private static bool OJEPLCBKMKB(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	private Transform GJCJNAICANK(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("AtlasPreparer - CLEARING ATLAS ", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "Prefabs" : "S")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.EDKFKNGLLBM(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	private Transform EJFMEOBOPHP(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("ID_ERROR_SQUADSKILLCLAMP", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "{0} {1}." : "ShootWalk")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.Initialize(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 2f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	private static bool OCICCHBFHMC(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB == null || NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	public virtual void BEFMHIFMMLB()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public virtual void BGDBMCDGBGE()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	private void MLNMKAOMJAA()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 249f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	private void MNDOJANLJAC()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 1104f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	private void LILMIHDAMOL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log(string.Format(" abilityIcon:", EJAFHHOOGOH));
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning("You probably assigned bad type of AmmoSetup to gun");
			}
		}
	}

	public void PGNOMEFCKMO(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.OKBAIGKCPKA().OAJAKEIEADE);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 1859f);
	}

	private Transform ABOKGOHKPEC(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("0", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "ID_SQUADMEDALSBIG" : "0")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.DPFKOFFMNPC(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	public virtual void AHCIKCJPBCN()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public void CBPJNPHOAFN(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.OKBAIGKCPKA().BEFMGDGDNBK);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.NIMBHACOENJ(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 567f);
	}

	private void MDOIDLBMDIG()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1335f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private void GJJIJFNFPKD()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 798f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void LBLEJMFCBIC()
	{
		bool flag = EJAFHHOOGOH < 0;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 0;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(GNMCJFPNION);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("VipCardMessage {0}" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(752f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = true;
		UILabel pEECOJOFACH = PEECOJOFACH;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper();
		pEECOJOFACH.text = Localization.LocalizeFormat("ID_SKILLSHOTHINT_REVENGEKILL", array);
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = false;
		DDNCOGPPMDH.text = Localization.Localize((num > 0) ? "resizing texture " : ((num >= 0) ? "Player" : "EventAssignmentConfig"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 551f, 1448f, -121);
		LAEGNMEBCOK.text = string.Format("SENDING BUFFER IMMEDIATELY", Localization.Localize("(Lcom/google/android/gms/common/api/GoogleApiClient;)Ljava/lang/String;"), 22 - CAJLKKFFOLO);
		for (int i = 1; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, MOHJDBDGPHE, EPADPPIBFDM, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("VirtualGoodID") : Localization.Localize("Fuseboxx Custom Event with params: "));
	}

	private void BAFNOAACHIA()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 711f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	public override void InitGUIValues()
	{
		bool flag = EJAFHHOOGOH < 1;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 0;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex((SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH) => NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("SquadIcons/" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(0.5f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = true;
		PEECOJOFACH.text = Localization.LocalizeFormat("ID_SQUADPLACE", MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper());
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = true;
		DDNCOGPPMDH.text = Localization.Localize((num > 0) ? "ID_PROMOTEDTODIVISION" : ((num >= 0) ? "ID_STAYINGINDIVISION" : "ID_DEMOTEDTODIVISION"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 37f, 20f, 288);
		LAEGNMEBCOK.text = string.Format("{0} {1}", Localization.Localize("ID_DIVISION"), 9 - CAJLKKFFOLO);
		for (int num3 = 0; num3 < HIPOAECNCJO.Length; num3++)
		{
			HIPOAECNCJO[num3].gameObject.SetActive(num3 < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, LMKHBDELHEF, KOGKOMPPIDH, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("ID_AWESOME") : Localization.Localize("ID_CONTINUE"));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	private void GKOPEFCOAPD()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 1641f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	private void KGGHPCBHEDK()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 612f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	public void ShowDialog(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.instance.SortFunctionPlayers);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void OIBLDHPNCOC()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1885f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private void BHAAEAOGDMD()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 464f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	private static bool BEBLJIDJDBH(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	public virtual void JOBJPEJDPKK()
	{
		DPKELGHKKPA(DMPBNBPBDFD.gameObject);
	}

	private Transform NNOMHFPDKLM(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("OK", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "BoughtIndex" : " OK!")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.GBCFOFKPPJP(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	public void KPDJABMGPDM(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.OKBAIGKCPKA().OAJAKEIEADE);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 589f);
	}

	public virtual void DKCOOAKKFKD()
	{
		base.DoAfterHide();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	public virtual void EBOBKBJNNDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FGMLCHBFPCC));
		LFKGHKNKHOL.onReposition = HLMFBJLHOGH;
		AJLDACMAIPI.onReposition = BPADNOGBBPG;
		OLBGGFNGMAK.onReposition = delegate
		{
			float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 2f + OLBGGFNGMAK.padding.x;
			OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
		};
	}

	private void OIEKHNBEDHA()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 990f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void GHAPDPMLPJL()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IJCLEFNGOMP));
		LFKGHKNKHOL.onReposition = delegate
		{
			float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 2f + LFKGHKNKHOL.padding.x;
			LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
		};
		AJLDACMAIPI.onReposition = delegate
		{
			float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 2f + AJLDACMAIPI.padding.x;
			AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
		};
		OLBGGFNGMAK.onReposition = delegate
		{
			float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 2f + OLBGGFNGMAK.padding.x;
			OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
		};
	}

	private static bool KIODGOCMLKO(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB == null || NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	public virtual void LIJFFGBNJPG()
	{
		base.OIMKKAHOEKO();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public void KJAGDCNDDOG(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.IOCHLIINFOC().OAJAKEIEADE);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.NIMBHACOENJ(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 930f);
	}

	public GuiElement ANDPIIIFIAA()
	{
		return this;
	}

	public virtual void MPBHLHILKLL()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	private void LMGBCIFHGFL()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 896f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FGMLCHBFPCC));
		LFKGHKNKHOL.onReposition = CCGAOKKBBIC;
		AJLDACMAIPI.onReposition = OIEKHNBEDHA;
		OLBGGFNGMAK.onReposition = GJJIJFNFPKD;
	}

	public virtual void OCACKBJDEHI()
	{
		bool flag = EJAFHHOOGOH < 0;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 0;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(FBJIAGLNIBL);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>(" (#" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(1370f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = true;
		UILabel pEECOJOFACH = PEECOJOFACH;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper();
		pEECOJOFACH.text = Localization.LocalizeFormat("game-label-you-blue", array);
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = false;
		DDNCOGPPMDH.text = Localization.Localize((num > 1) ? "Error: Buddy card not ready! " : ((num >= 0) ? "attrValue21" : "rental for unexist unit: {0}"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 1046f, 1568f, -94);
		LAEGNMEBCOK.text = string.Format("ID_STAT_SNIPERRIFLEKILLS", Localization.Localize("ID_VIP_DAYS"), -8 - CAJLKKFFOLO);
		for (int i = 0; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, HHNLMHHEAPP, LAGLBMKOAFD, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: true);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("ID_MEMBER") : Localization.Localize("ID_CONFIRM_EXITWARFRIENDS"));
	}

	public void AHJFFMAFCEG(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.KDAJDAPPJHF().OAJAKEIEADE);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 1231f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void KCJPCIGFBMD()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 146f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void HKKHHAKOFHL()
	{
		bool flag = EJAFHHOOGOH < 1;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 1;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(HNDGFJOGEEB);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("PowerBandExpiresOn" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(363f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = false;
		UILabel pEECOJOFACH = PEECOJOFACH;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper();
		pEECOJOFACH.text = Localization.LocalizeFormat("Beanstalk: That account already exists! Player will choose how to proceed, provider = ", array);
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = false;
		DDNCOGPPMDH.text = Localization.Localize((num > 1) ? "ID_INVITEDYOUTOFIGHT" : ((num >= 1) ? "discount" : "09"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 1000f, 1522f, 92);
		LAEGNMEBCOK.text = string.Format("ID_DEBUG_STACKTRACEINCONSOLE", Localization.Localize("OnConnectionFailed: "), 6 - CAJLKKFFOLO);
		for (int i = 1; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = false;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, PPIGFHNPDNI, CEJJCENBBIK, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("game-card-ico-shieldsup") : Localization.Localize("ID_SECONDS"));
	}

	private void MKBIEDJGLAP(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private void HEJHBEAEKBF()
	{
		float num = (IKFHJFIIKJE.transform.parent.localPosition.x - AJLDACMAIPI.padding.x) / 1670f + AJLDACMAIPI.padding.x;
		AJLDACMAIPI.transform.localPosition = AJLDACMAIPI.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void AGFDJGJALKD()
	{
		bool flag = EJAFHHOOGOH < 0;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 1;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(HNDGFJOGEEB);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("DogTagSeconds" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(321f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = false;
		PEECOJOFACH.text = Localization.LocalizeFormat("ID_MAXSTAT", MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper());
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = true;
		DDNCOGPPMDH.text = Localization.Localize((num > 1) ? "PlayerName" : ((num >= 1) ? "Buy_Army_Unit_Gold" : "added"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 1672f, 1312f, 64);
		LAEGNMEBCOK.text = string.Format("Shots_Hits", Localization.Localize("com/google/android/gms/games/Games"), 114 - CAJLKKFFOLO);
		for (int i = 0; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, EJFMEOBOPHP, EPADPPIBFDM, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("Sniper_Tutorial_Duration") : Localization.Localize("ABOUT TO SHOW DAILY RENTAL"));
	}

	public virtual void LMNNNHJKMFP()
	{
		bool flag = EJAFHHOOGOH < 0;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 0;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(MDJBAPPICFA);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("ID_AREYOUSUREYOUWANTTOCONVERTPARTS" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(581f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = true;
		UILabel pEECOJOFACH = PEECOJOFACH;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper();
		pEECOJOFACH.text = Localization.LocalizeFormat("videoName", array);
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = true;
		DDNCOGPPMDH.text = Localization.Localize((num > 1) ? "registerForPushNotifications" : ((num >= 1) ? " was not in the list of products." : "OnAgeVerificationCriteriaMet"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 50f, 544f, -129);
		LAEGNMEBCOK.text = string.Format("{0} {1}/ {2}", Localization.Localize("WarCard {0}"), 55 - CAJLKKFFOLO);
		for (int i = 0; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = false;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, JJDOLANDILI, LNGHBKPJHEI, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: true, UIDraggablePanel.Alingment.BottomRight);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("Error Deserializing JSON for ") : Localization.Localize("InGameMessage-{0}"));
	}

	public virtual void GBJHCKCPOBB()
	{
		base.DoAfterHide();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public virtual void DOANAOOEAKD()
	{
		DPKELGHKKPA(DMPBNBPBDFD.gameObject);
	}

	public virtual void POKDDAGBIDO()
	{
		bool flag = EJAFHHOOGOH < 0;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 1;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(GNMCJFPNION);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>(" {0}{1}" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(4f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = false;
		PEECOJOFACH.text = Localization.LocalizeFormat("ShotFrequencyMinCannon", MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper());
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = true;
		DDNCOGPPMDH.text = Localization.Localize((num > 0) ? "ID_CATEGORY_GRENADELAUNCHER" : ((num >= 1) ? "menu-event-reward-progress-red" : "{0} is {1}. Msg:{2}"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 253f, 491f, -161);
		LAEGNMEBCOK.text = string.Format("PARCELABLE_WRITE_RETURN_VALUE", Localization.Localize("b"), 89 - CAJLKKFFOLO);
		for (int i = 0; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, KJIILCBANCO, ILLCFCKOFHO, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize(")") : Localization.Localize("GoldCoefficient"));
	}

	public void GILDIKINMFE(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.KDAJDAPPJHF().BEFMGDGDNBK);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.NIMBHACOENJ(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 1747f);
	}

	private Transform PPIGFHNPDNI(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("ID_WARARENAUNLOCKED", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "AccountId" : "N")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.OJJHCFFEFGI(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	public virtual void DMBLJNMGLAH()
	{
		bool flag = EJAFHHOOGOH < 1;
		int num = CAJLKKFFOLO - NOOGOKLLFHA;
		int fFHHEHHFOKJ = 0;
		if (JHGLKIKLGJK != null)
		{
			int num2 = JHGLKIKLGJK.FindIndex(MDJBAPPICFA);
			if (num2 > -1)
			{
				fFHHEHHFOKJ = JHGLKIKLGJK[num2].KHLGDCHJJPB.squadPoints;
			}
		}
		int pDKIAALFDNG = MEJMLNDFDBP.NJDAEFEJPLL(JNJDCCMKPBI, MBFPGPOBBJL);
		int fFHHEHHFOKJ2 = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(pDKIAALFDNG, NOOGOKLLFHA);
		GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("ID_DEBUG_STACKTRACEINCONSOLE" + KGFHEAPPLFJ);
		GEAGOKJMJFD.MakePixelPerfect();
		GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(538f);
		CGIFEHPDBAL.text = AKEOMKLDIIF;
		LFKGHKNKHOL.repositionNow = false;
		UILabel pEECOJOFACH = PEECOJOFACH;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.PDDBDAMHIAA(JNJDCCMKPBI).ToUpper();
		pEECOJOFACH.text = Localization.LocalizeFormat("getSpendPercentile", array);
		IKFHJFIIKJE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		AJLDACMAIPI.repositionNow = false;
		DDNCOGPPMDH.text = Localization.Localize((num > 0) ? "LOOTBOXES DISCOUNTED" : ((num >= 1) ? "game-revenge-indicator" : "Confirmed_In_App"));
		MEJMLNDFDBP.COCBCFKJOJE(DDNCOGPPMDH, 252f, 538f, -114);
		LAEGNMEBCOK.text = string.Format("ID_WARNING_TWITTERACCOUNTSUSPENDED", Localization.Localize("country-germany"), -46 - CAJLKKFFOLO);
		for (int i = 1; i < HIPOAECNCJO.Length; i += 0)
		{
			HIPOAECNCJO[i].gameObject.SetActive(i < CAJLKKFFOLO);
		}
		HBJJAEBGNII.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		HNLMIGFFBMP.text = MEJMLNDFDBP.GMIPFLIEOHD(EJAFHHOOGOH);
		OLBGGFNGMAK.repositionNow = true;
		NEMLDOPDFND.MakeEmpty();
		NEMLDOPDFND.init(JHGLKIKLGJK.Count, HHNLMHHEAPP, KOGKOMPPIDH, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: true);
		GMBJHOCENGD.text = ((!flag) ? Localization.Localize("#PETER# User was watching add - waiting for server reward - reward came") : Localization.Localize(")"));
	}

	private void EPADPPIBFDM(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	public virtual void MDHKDOOOKAI()
	{
		FGMLCHBFPCC(DMPBNBPBDFD.gameObject);
	}

	private void LIFLEEGJFFN()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 1711f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private void FGMLCHBFPCC(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log(string.Format("ShootFromBazookaFromCrawl", EJAFHHOOGOH));
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning("ID_FACEBOOKHINT-SQUADINVITE");
			}
		}
	}

	public virtual void CGPFPNNICIO()
	{
		base.DoAfterHide();
		GEAGOKJMJFD.mainTexture = null;
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	private void EIFDFPLIHPA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log(string.Format("x", EJAFHHOOGOH));
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning(")");
			}
		}
	}

	private void BJAIDPGBGLI(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private static bool IBLODNJMAGH(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB == null || NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	private void ICDBFHEDHNP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log(string.Format("ID_INVITEDYOUTOFIGHT", EJAFHHOOGOH));
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning("_grenadelauncher");
			}
		}
	}

	private void FMFNFGBMADA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (NGDKKFFCGCI != null)
			{
				Debug.Log(string.Format(" (#", EJAFHHOOGOH));
				Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(NGDKKFFCGCI);
			}
			else
			{
				Debug.LogWarning("next");
			}
		}
	}

	public GuiElement BNOEFEIAPNN()
	{
		return this;
	}

	public void FPKBPNDDOHP(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.IOCHLIINFOC().FPAPKAAAMFM);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 1698f);
	}

	private void BNEKLBKKOCD()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 140f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private Transform HHNLMHHEAPP(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("ID_WARNING_CANTSENDINVITE_TEXT", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "ID_GUI_CHAT_SQUAD_KICK" : "ID_GOODJOBYOUVEBEENPROMOTED")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.OJJHCFFEFGI(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	private static bool IOKFFIIEBPB(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		return NDPMDKGJAFH.KHLGDCHJJPB != null && NDPMDKGJAFH.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	private void JEKKOLLKEAJ()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 776f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private Transform KJIILCBANCO(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < JHGLKIKLGJK.Count)
		{
			SquadWarsContent.IAIOAHOIDOF iAIOAHOIDOF = JHGLKIKLGJK[DFHAAIFFLOE];
			SquadWarEndMemberRecord squadWarEndMemberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(ENHFFICNHNC, NEMLDOPDFND.gameObject, string.Format("Create player instance at ", DFHAAIFFLOE, (!iAIOAHOIDOF.JAHGCGMPCKP) ? "()V" : "Resource: {0} loaded {1} times\n")) as SquadWarEndMemberRecord;
			if (squadWarEndMemberRecord != null)
			{
				squadWarEndMemberRecord.GCBFCCNLMDN(iAIOAHOIDOF);
				return squadWarEndMemberRecord.transform;
			}
		}
		return null;
	}

	public virtual void INMDPGCHHPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IJCLEFNGOMP));
		LFKGHKNKHOL.onReposition = LMGBCIFHGFL;
		AJLDACMAIPI.onReposition = BPADNOGBBPG;
		OLBGGFNGMAK.onReposition = CONMNAAJHAL;
	}

	public void MEHCHHCOJFM(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.OKBAIGKCPKA().OAJAKEIEADE);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.NIMBHACOENJ(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 926f);
	}

	private void COHIKMEHECM(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private void MGHGKCDPHGD()
	{
		float num = (HNLMIGFFBMP.transform.parent.localPosition.x - OLBGGFNGMAK.padding.x) / 1368f + OLBGGFNGMAK.padding.x;
		OLBGGFNGMAK.transform.localPosition = OLBGGFNGMAK.transform.localPosition.ReplaceX(0f - num);
	}

	public void BJEAOMIBLFI(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.OFLMKOOONKH().SortFunctionPlayers);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 254f);
	}

	private void BHADJPEPODO()
	{
		float num = (CGIFEHPDBAL.transform.parent.localPosition.x - LFKGHKNKHOL.padding.x) / 814f + LFKGHKNKHOL.padding.x;
		LFKGHKNKHOL.transform.localPosition = LFKGHKNKHOL.transform.localPosition.ReplaceX(0f - num);
	}

	private void ILLCFCKOFHO(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadWarEndMemberRecord component = ENCEFOOPBMK.GetComponent<SquadWarEndMemberRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	public void IFMMDKLNLJL(string DBNNKLCNDJD, string LOKHAAIPCDD, int HOCOGFPLDFK, int JAKNOMLICHG, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, List<DatabasePlayer> FHBAEAOCCDE, HHFHFANGCEJ PNAKMCNGGHE)
	{
		FHBAEAOCCDE.Sort(SquadWarManager.instance.BEFMGDGDNBK);
		AKEOMKLDIIF = DBNNKLCNDJD;
		KGFHEAPPLFJ = LOKHAAIPCDD;
		JNJDCCMKPBI = HOCOGFPLDFK;
		MBFPGPOBBJL = JAKNOMLICHG;
		EJAFHHOOGOH = OGJOPNCMJDC;
		NOOGOKLLFHA = HGIOPOBDFKE;
		CAJLKKFFOLO = FOCMIAIAHDE;
		JHGLKIKLGJK = GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.CreateSquadMembersList(FHBAEAOCCDE, HGIOPOBDFKE, JAKNOMLICHG, HOCOGFPLDFK);
		NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(this, 987f);
	}
}
