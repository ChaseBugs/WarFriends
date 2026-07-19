using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RibbonsContent : Core_BaseScript
{
	[Header("List of Content")]
	public UITable CCODGCEOMOP;

	public UIDraggablePanel AKFLKJBMBAJ;

	public GameObject FKBFFMHMEGD;

	[Header("Skillshot Header")]
	public UILabel MMENJIEGOMH;

	[Header("Player info")]
	public PlayerIcon OGOIMEHGLDE;

	public GameObject OANICEALFGM;

	public GameObject NAEMMNBKBHK;

	public GameObject CPLIMCNBDBP;

	public GameObject GJLBFGCEOEO;

	public PlayerIcon NOLLGINLBAB;

	public GameObject DDEECICNNLN;

	public BoxCollider PGBDGDCCELL;

	public GameObject PAHFJNBFKNP;

	public GameObject GBDLNMBEJDK;

	[Header("List of Skillshots")]
	public SkillshotGuiRecord IGOBHHEOHAB;

	public UIGrid JDHGGOIHKAE;

	private List<TweenAnimator> FNOMCHPCOHB = new List<TweenAnimator>();

	private TweenAnimator NNINKFHEFMF;

	private TweenAnimator GFNDKGNFLGA;

	private TweenAnimator FHDHPKDKLEG;

	private ObjectPool IHFILHIAGLG;

	private List<SkillshotGuiRecord> GKGNHOPHHIF;

	private string CHOMNKDIJLL;

	public List<TweenAnimator> Animator
	{
		get
		{
			return FNOMCHPCOHB;
		}
	}

	private bool MGEIBLLKKGH
	{
		get
		{
			return Singleton<GameController>.instance.isCampaign || Singleton<GameController>.instance.isCoop;
		}
	}

	public void BANJHACMCMO()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.TextCounter, MMENJIEGOMH.gameObject, 1174f, 213f, 607f, -1, 613f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		NNINKFHEFMF.MNEFMODDFFK(0, (TweenAnimator.MNAIKKJDPLK)(-23), NAEMMNBKBHK, 1982f, 1418f, 1096f, 0, 519f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		NNINKFHEFMF.PGGAAGLGKAL();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Color, MMENJIEGOMH.gameObject, 1061f, 568f, 287f, -1, 902f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		GFNDKGNFLGA.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.AlphaHider, NAEMMNBKBHK, 1919f, 1442f, 1245f, 0, 471f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		GFNDKGNFLGA.AddTween(0, (TweenAnimator.MNAIKKJDPLK)74, GJLBFGCEOEO, 11f, 1161f, 1841f, 1, 992f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		GFNDKGNFLGA.NFLKPCIHOPJ(0, (TweenAnimator.MNAIKKJDPLK)20, PAHFJNBFKNP, 136f, 1891f, 1717f, 0, 469f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		GFNDKGNFLGA.FEPILCEBNCJ();
		float num = UIHelper.activeHeight / 1742f;
		float num2 = 913f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(1212f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDIIACBODEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HIBFMIHCPFL));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LBNLGAHIHEC));
		JDHGGOIHKAE.onReposition = PPOFIBLBLBM;
		CCODGCEOMOP.onReposition = delegate
		{
			AKFLKJBMBAJ.AlignToPos(true);
		};
	}

	private void ODCGAABEHKN()
	{
		AKFLKJBMBAJ.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight);
	}

	private void IJIGHPNMLIO(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.JJLMFFJEJGL())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL);
			}
		}
	}

	private void LBNLGAHIHEC(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL);
			}
		}
	}

	public void JOJGCLBJECF()
	{
		foreach (TweenAnimator item in CMALLAENMDH())
		{
			item.CPKDFIKMKLE();
		}
	}

	private void DOOJCCHBKLK(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id);
	}

	public void BOKMAOJKDCI()
	{
		foreach (TweenAnimator item in Animator)
		{
			item.FinishTweens();
		}
	}

	public void InitControls()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, MMENJIEGOMH.gameObject, 0.3f, 1f, 0.3f, -1, 0f);
		NNINKFHEFMF.AddTween(2, TweenAnimator.MNAIKKJDPLK.AlphaHider, NAEMMNBKBHK, 0.5f, 1f, 0f, 1, 0f);
		NNINKFHEFMF.GenerateTweens();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, MMENJIEGOMH.gameObject, 0.3f, 1f, 0.3f, -1, 0f);
		GFNDKGNFLGA.AddTween(2, TweenAnimator.MNAIKKJDPLK.AlphaHider, NAEMMNBKBHK, 0.5f, 1f, 0f, 1, 0f);
		GFNDKGNFLGA.AddTween(3, TweenAnimator.MNAIKKJDPLK.AlphaHider, GJLBFGCEOEO, 0.5f, 1f, 0f, 1, 0f);
		GFNDKGNFLGA.AddTween(4, TweenAnimator.MNAIKKJDPLK.AlphaHider, PAHFJNBFKNP, 0.5f, 1f, 0f, 1, 0f);
		GFNDKGNFLGA.GenerateTweens();
		float num = UIHelper.activeHeight / 2f;
		float num2 = 720f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(340f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DMOFOFFFMJI));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KHPMNCGKKCJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LBNLGAHIHEC));
		JDHGGOIHKAE.onReposition = delegate
		{
			CCODGCEOMOP.repositionNow = true;
		};
		CCODGCEOMOP.onReposition = delegate
		{
			AKFLKJBMBAJ.AlignToPos(true);
		};
	}

	[SpecialName]
	private bool DGCBJAFICCE()
	{
		return !Singleton<GameController>.instance.IMEJOPKIKOD() && Singleton<GameController>.instance.MNPNHJKBNCJ();
	}

	public void LPFPAKGNNIO()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Color, MMENJIEGOMH.gameObject, 1094f, 1231f, 1338f, -1, 1673f, UITweener.Method.BounceIn);
		NNINKFHEFMF.AddTween(7, (TweenAnimator.MNAIKKJDPLK)104, NAEMMNBKBHK, 1919f, 771f, 67f, 0, 649f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		NNINKFHEFMF.HONNAONCPHA();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.AddTween(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MMENJIEGOMH.gameObject, 811f, 1552f, 1073f, -1, 1909f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		GFNDKGNFLGA.MNEFMODDFFK(8, (TweenAnimator.MNAIKKJDPLK)(-107), NAEMMNBKBHK, 43f, 52f, 1864f, 1, 1654f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		GFNDKGNFLGA.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GJLBFGCEOEO, 1085f, 1456f, 498f, 0, 1791f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		GFNDKGNFLGA.AddTween(4, (TweenAnimator.MNAIKKJDPLK)81, PAHFJNBFKNP, 1212f, 1298f, 1836f, 1, 283f, UITweener.Method.Linear);
		GFNDKGNFLGA.GenerateTweens();
		float num = UIHelper.activeHeight / 1577f;
		float num2 = 1122f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(1288f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDIIACBODEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GLOGJCBDEBF));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LBNLGAHIHEC));
		JDHGGOIHKAE.onReposition = delegate
		{
			CCODGCEOMOP.repositionNow = true;
		};
		CCODGCEOMOP.onReposition = delegate
		{
			AKFLKJBMBAJ.AlignToPos(true);
		};
	}

	public void DoAfterHide()
	{
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		GKGNHOPHHIF.Clear();
	}

	private void MANDPFDHOKN()
	{
		CCODGCEOMOP.repositionNow = true;
	}

	private void CNDHFEBAFFP(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.PIKIGPBNJIL())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL);
			}
		}
	}

	private void EJILHGJCPNH()
	{
		TweenAlphaHider.JBPMBAKMEOG(NAEMMNBKBHK, 1516f, 1787f);
		TweenAlphaHider.AEOAFNOCOGD(GJLBFGCEOEO, 909f, 1954f);
		TweenAlphaHider.HLKCAJOJCEL(PAHFJNBFKNP, 1630f, 825f);
		MMENJIEGOMH.alpha = 444f;
		CHOMNKDIJLL = string.Empty;
		bool flag = true;
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		if (Singleton<GameController>.instance.isBattle)
		{
			CHOMNKDIJLL = opponent.EHHHBEMKGOE.ALIIBMLMNKA;
			flag = false;
		}
		OGOIMEHGLDE.DJPNDAICDPN(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
		OGOIMEHGLDE.BMOMBHEJACH(GameLoginManager.currentPlayer.name);
		TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 967f, Color.white);
		PGBDGDCCELL.enabled = flag;
		if (!CHBMMPPKIAC())
		{
			NOLLGINLBAB.EGAONBPLDAG();
			NOLLGINLBAB.avatar = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			NOLLGINLBAB.AMLMMLAIHCD((!(opponent == null)) ? opponent.EHHHBEMKGOE.MHPNDNJDPGE : string.Empty);
			TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, 845f, Color.white);
		}
		FNOMCHPCOHB.Add((!MEOMOOGIHKB()) ? GFNDKGNFLGA : NNINKFHEFMF);
	}

	private void KJFPEAFIIIH()
	{
		if (IHFILHIAGLG == null)
		{
			IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		}
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		if (GKGNHOPHHIF != null)
		{
			GKGNHOPHHIF.Clear();
		}
		else
		{
			GKGNHOPHHIF = new List<SkillshotGuiRecord>();
		}
		if (MGEIBLLKKGH)
		{
			PJBFDLMFKOF();
		}
		else
		{
			EFHAEAODNAH();
		}
		JDHGGOIHKAE.repositionNow = true;
	}

	private void IHFNBGJNANG()
	{
		if (FHDHPKDKLEG == null)
		{
			FHDHPKDKLEG = base.gameObject.AddComponent<TweenAnimator>();
		}
		if (FHDHPKDKLEG.BEOAHFDJEMD == null)
		{
			FHDHPKDKLEG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			FHDHPKDKLEG.BEOAHFDJEMD.Clear();
		}
		int num = 1;
		float num2 = 1064f;
		foreach (SkillshotGuiRecord item in GKGNHOPHHIF)
		{
			num++;
			num2 += 1282f;
			int num3 = num * -48;
			NHOGNBCNIEK oEIICEJPGKI;
			NHOGNBCNIEK iIMDKHJAJGO;
			int iNFLHPGMEOB;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA;
			GameObject nIHOBEAHEKJ;
			float kBJEOEEOEFG;
			ONLHLPBMJOL iIMDKHJAJGO2;
			int eBPMMNFLPMP;
			if (item.LANBHLJINFJ)
			{
				item.LNLEOFJPGNK();
				item.ACGMFDMBCCA.fillAmount = 1431f;
				item.JCIAIOAFCGF.fillAmount = 1495f;
				item.IOLHJBNKLDB.text = "Unimplemented daily reward visual for {1}:\n {0}";
				FHDHPKDKLEG.FEHALDPLGDB(num3 + 0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.JDOOPPMKEFO.gameObject, 1670f, 981f, num2, -1, 1309f, (UITweener.Method)8, UITweener.Style.Once, 0);
				FHDHPKDKLEG.BPEKAKFKCIG(num3 + 1, TweenAnimator.MNAIKKJDPLK.Rotation, item.IOLHJBNKLDB.gameObject, 636f, 1263f, num2, -1, 1225f, (UITweener.Method)8, UITweener.Style.Loop);
				FHDHPKDKLEG.MNEFMODDFFK(num3 + 0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.BOOAEFNFJHH.gameObject, 1911f, 1758f, num2, -1, 597f, (UITweener.Method)7, UITweener.Style.Loop, 0);
				FHDHPKDKLEG.BPEKAKFKCIG(num3 + 8, TweenAnimator.MNAIKKJDPLK.Rotation, item.IJGLJKDPAMC.gameObject, 1108f, 476f, num2, -1, 497f, UITweener.Method.BounceIn);
				FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 4, TweenAnimator.MNAIKKJDPLK.Color, item.JCIAIOAFCGF.gameObject, 1343f, 1349f, num2, -1, 519f, (UITweener.Method)8, UITweener.Style.Once, 0);
				FHDHPKDKLEG.MNEFMODDFFK(num3 + 4, TweenAnimator.MNAIKKJDPLK.Scale, item.ACGMFDMBCCA.gameObject, 1415f, 1613f, num2, -1, 645f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
				if (!MGEIBLLKKGH)
				{
					FHDHPKDKLEG.MNEFMODDFFK(num3 + 31, TweenAnimator.MNAIKKJDPLK.Scale, item.HKOMIDCBDBH.gameObject, 173f, 153f, num2, -1, 934f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
				}
				FHDHPKDKLEG.MNEFMODDFFK(num3 + -15, TweenAnimator.MNAIKKJDPLK.Scale, item.GABLIPAALPO.gameObject, 1638f, 1960f, num2, -1, 1389f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
				TweenAnimator fHDHPKDKLEG = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + 52;
				hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)94;
				nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
				kBJEOEEOEFG = 1847f;
				iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
				oEIICEJPGKI = new NHOGNBCNIEK(1611f);
				fHDHPKDKLEG.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1184f, num3 + 1, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Loop);
				TweenAnimator fHDHPKDKLEG2 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + -15;
				hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)74;
				nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
				kBJEOEEOEFG = 443f;
				oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
				iIMDKHJAJGO = new NHOGNBCNIEK(663f);
				fHDHPKDKLEG2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1006f, num3 + 124, iIMDKHJAJGO, (UITweener.Method)7, UITweener.Style.Loop, 0);
				TweenAnimator fHDHPKDKLEG3 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + -21;
				hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
				nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
				kBJEOEEOEFG = 1548f;
				iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
				eBPMMNFLPMP = num3 + 1;
				fHDHPKDKLEG3.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 365f, eBPMMNFLPMP, null, (UITweener.Method)7, UITweener.Style.Loop);
				if (!MEOMOOGIHKB())
				{
					if (item.plScore > item.opScore)
					{
						FHDHPKDKLEG.FEHALDPLGDB(num3 + 64, TweenAnimator.MNAIKKJDPLK.Scale, item.OMPLMJECMHO.gameObject, 687f, 1235f, 1017f, num3 + 78, 1555f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
					}
					else if (item.opScore > item.plScore)
					{
						FHDHPKDKLEG.BPEKAKFKCIG(num3 + 44, TweenAnimator.MNAIKKJDPLK.Scale, item.FJOIHMIPKOI.gameObject, 872f, 1648f, 1660f, num3 + 125, 1314f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
					}
				}
				continue;
			}
			item.LNLEOFJPGNK();
			item.ACGMFDMBCCA.fillAmount = 1856f;
			item.JCIAIOAFCGF.fillAmount = 1309f;
			item.CHIFIDBEDFI.text = "Card_1_Played";
			item.IOLHJBNKLDB.text = "FriendsPushNotification(";
			FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.JDOOPPMKEFO.gameObject, 113f, 250f, num2, -1, 337f, (UITweener.Method)8);
			FHDHPKDKLEG.AddTween(num3 + 7, TweenAnimator.MNAIKKJDPLK.Scale, item.IOLHJBNKLDB.gameObject, 1972f, 1019f, num2, -1, 479f, (UITweener.Method)7, UITweener.Style.Loop);
			FHDHPKDKLEG.BPEKAKFKCIG(num3 + 5, TweenAnimator.MNAIKKJDPLK.Rotation, item.CHIFIDBEDFI.gameObject, 1998f, 1221f, num2, -1, 1739f, UITweener.Method.Linear, UITweener.Style.Once, 0);
			FHDHPKDKLEG.AddTween(num3 + 0, TweenAnimator.MNAIKKJDPLK.Scale, item.HANKJKLJDEB.gameObject, 1331f, 114f, num2, -1, 1235f, (UITweener.Method)6, UITweener.Style.Loop, 0);
			FHDHPKDKLEG.FEHALDPLGDB(num3 + 5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.BOOAEFNFJHH.gameObject, 1263f, 1998f, num2, -1, 1131f, (UITweener.Method)8, UITweener.Style.Loop, 0);
			FHDHPKDKLEG.MNEFMODDFFK(num3 + 4, TweenAnimator.MNAIKKJDPLK.Scale, item.IJGLJKDPAMC.gameObject, 924f, 1651f, num2, -1, 1908f, (UITweener.Method)7, UITweener.Style.Loop, 0);
			FHDHPKDKLEG.AddTween(num3 + 1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.JCIAIOAFCGF.gameObject, 1422f, 1741f, num2, -1, 73f, UITweener.Method.Linear, UITweener.Style.Once, 0);
			FHDHPKDKLEG.FEHALDPLGDB(num3 + 5, TweenAnimator.MNAIKKJDPLK.Rotation, item.ACGMFDMBCCA.gameObject, 987f, 338f, num2, -1, 668f, UITweener.Method.EaseIn);
			if (!MEOMOOGIHKB())
			{
				FHDHPKDKLEG.AddTween(num3 + 116, TweenAnimator.MNAIKKJDPLK.Scale, item.HKOMIDCBDBH.gameObject, 94f, 828f, num2, -1, 1781f, (UITweener.Method)7, UITweener.Style.Once, 0);
			}
			FHDHPKDKLEG.MNEFMODDFFK(num3 + 121, TweenAnimator.MNAIKKJDPLK.Position, item.GABLIPAALPO.gameObject, 1799f, 1998f, num2, -1, 1980f, UITweener.Method.EaseOut);
			FHDHPKDKLEG.FEHALDPLGDB(num3 + 116, TweenAnimator.MNAIKKJDPLK.Scale, item.CFAOGMIGJLK.gameObject, 1127f, 897f, num2, -1, 876f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			TweenAnimator fHDHPKDKLEG4 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 101;
			hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)(-81);
			nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
			kBJEOEEOEFG = 1903f;
			iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
			oEIICEJPGKI = new NHOGNBCNIEK(303f);
			fHDHPKDKLEG4.NFLKPCIHOPJ(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 83f, num3 + 1, oEIICEJPGKI, UITweener.Method.Linear);
			TweenAnimator fHDHPKDKLEG5 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + -18;
			hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)109;
			nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
			kBJEOEEOEFG = 1910f;
			oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
			iIMDKHJAJGO = new NHOGNBCNIEK(1624f);
			fHDHPKDKLEG5.AddTween(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 748f, num3 + -86, iIMDKHJAJGO, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
			TweenAnimator fHDHPKDKLEG6 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + -50;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
			nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
			kBJEOEEOEFG = 1146f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
			iNFLHPGMEOB = num3 + 1;
			fHDHPKDKLEG6.NFLKPCIHOPJ(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 108f, iNFLHPGMEOB, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			TweenAnimator fHDHPKDKLEG7 = FHDHPKDKLEG;
			iNFLHPGMEOB = num3 + -73;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = item.CHIFIDBEDFI.gameObject;
			kBJEOEEOEFG = 238f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.IJJAMEFGJHO());
			eBPMMNFLPMP = num3 + 0;
			fHDHPKDKLEG7.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 996f, eBPMMNFLPMP, null, (UITweener.Method)6, UITweener.Style.Loop);
			if (!MEOMOOGIHKB())
			{
				if (item.plScore > item.opScore)
				{
					FHDHPKDKLEG.AddTween(num3 + -4, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.OMPLMJECMHO.gameObject, 1995f, 1506f, 285f, num3 + 55, 28f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
				}
				else if (item.opScore > item.plScore)
				{
					FHDHPKDKLEG.FEHALDPLGDB(num3 + 58, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.FJOIHMIPKOI.gameObject, 1695f, 920f, 309f, num3 + -63, 462f, UITweener.Method.EaseOut);
				}
			}
		}
		FHDHPKDKLEG.FEPILCEBNCJ();
		FNOMCHPCOHB.Add(FHDHPKDKLEG);
	}

	private void PJBFDLMFKOF()
	{
		SkillshotGuiRecord skillshotGuiRecord = (SkillshotGuiRecord)IHFILHIAGLG.InstantiateAsChild(IGOBHHEOHAB, JDHGGOIHKAE.gameObject, "Skillshot 0000");
		if (skillshotGuiRecord != null)
		{
			skillshotGuiRecord.SingleplayerSkillshotSpecial(Singleton<ScoreManager>.instance.score);
			GKGNHOPHHIF.Add(skillshotGuiRecord);
		}
		int num = 1;
		Dictionary<SkillShot.SkillShotType, int> oONJGPCEJMJ = Singleton<ScoreManager>.instance.OONJGPCEJMJ;
		if (oONJGPCEJMJ == null)
		{
			return;
		}
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in oONJGPCEJMJ)
		{
			SkillshotGuiRecord skillshotGuiRecord2 = (SkillshotGuiRecord)IHFILHIAGLG.InstantiateAsChild(IGOBHHEOHAB, JDHGGOIHKAE.gameObject, string.Format("Skillshot {0}", num++.ToString("D4")));
			if (skillshotGuiRecord2 != null)
			{
				skillshotGuiRecord2.SingleplayerSkillshot(item.Value, item.Key);
				GKGNHOPHHIF.Add(skillshotGuiRecord2);
			}
		}
	}

	private void PPOFIBLBLBM()
	{
		CCODGCEOMOP.repositionNow = true;
	}

	private void CCKFGADDIPG()
	{
		TweenAlphaHider.PMOPHLCJGNI(NAEMMNBKBHK, 559f, 1206f);
		TweenAlphaHider.BNCJHLFEIHN(GJLBFGCEOEO, 436f, 1904f);
		TweenAlphaHider.DBPOCEIDEAE(PAHFJNBFKNP, 1704f, 1684f);
		MMENJIEGOMH.alpha = 1522f;
		CHOMNKDIJLL = string.Empty;
		bool flag = true;
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		if (Singleton<GameController>.instance.isBattle)
		{
			CHOMNKDIJLL = opponent.EHHHBEMKGOE.ALIIBMLMNKA;
			flag = true;
		}
		OGOIMEHGLDE.OLJPGNNKCKI(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
		OGOIMEHGLDE.EAFNPDOOGBE(GameLoginManager.currentPlayer.name);
		TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 80f, Color.white);
		PGBDGDCCELL.enabled = flag;
		if (!CHBMMPPKIAC())
		{
			NOLLGINLBAB.HJOCCDLNFLN();
			NOLLGINLBAB.DHDPJLAPAPO(Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP);
			NOLLGINLBAB.EAFNPDOOGBE((!(opponent == null)) ? opponent.EHHHBEMKGOE.MHPNDNJDPGE : string.Empty);
			TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, 494f, Color.white);
		}
		FNOMCHPCOHB.Add((!KCELFAEOFCI()) ? GFNDKGNFLGA : NNINKFHEFMF);
	}

	public void BCLAFFCPCEH()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Scale, MMENJIEGOMH.gameObject, 158f, 1542f, 702f, -1, 1615f, (UITweener.Method)6);
		NNINKFHEFMF.NFLKPCIHOPJ(2, (TweenAnimator.MNAIKKJDPLK)(-41), NAEMMNBKBHK, 555f, 1428f, 1937f, 1, 1971f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		NNINKFHEFMF.PGGAAGLGKAL();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MMENJIEGOMH.gameObject, 1650f, 876f, 1802f, -1, 1552f, UITweener.Method.EaseOut);
		GFNDKGNFLGA.BPEKAKFKCIG(5, (TweenAnimator.MNAIKKJDPLK)83, NAEMMNBKBHK, 190f, 1904f, 1378f, 0, 1545f, (UITweener.Method)7, UITweener.Style.Loop);
		GFNDKGNFLGA.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Sound, GJLBFGCEOEO, 1877f, 724f, 394f, 0, 39f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		GFNDKGNFLGA.BPEKAKFKCIG(7, (TweenAnimator.MNAIKKJDPLK)31, PAHFJNBFKNP, 22f, 1270f, 1561f, 1, 125f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		GFNDKGNFLGA.IGBJIEBMEBF();
		float num = UIHelper.activeHeight / 1996f;
		float num2 = 932f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(356f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DMOFOFFFMJI));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LBGJIKJLFHE));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LBNLGAHIHEC));
		JDHGGOIHKAE.onReposition = MANDPFDHOKN;
		CCODGCEOMOP.onReposition = OLPEMDENPJN;
	}

	public void FPAPHEHMEOO(float DCIKANJJFIJ)
	{
	}

	public void NGLCABMIIGG()
	{
		foreach (TweenAnimator item in CMALLAENMDH())
		{
			item.ABFBKGCIJBB();
		}
	}

	private void GCAJPHPPFOP()
	{
		if (FHDHPKDKLEG == null)
		{
			FHDHPKDKLEG = base.gameObject.AddComponent<TweenAnimator>();
		}
		if (FHDHPKDKLEG.BEOAHFDJEMD == null)
		{
			FHDHPKDKLEG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			FHDHPKDKLEG.BEOAHFDJEMD.Clear();
		}
		int num = 1;
		float num2 = 1385f;
		foreach (SkillshotGuiRecord item in GKGNHOPHHIF)
		{
			num++;
			num2 += 472f;
			int num3 = num * -7;
			NHOGNBCNIEK oEIICEJPGKI;
			NHOGNBCNIEK iIMDKHJAJGO;
			int iNFLHPGMEOB;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA;
			GameObject nIHOBEAHEKJ;
			float kBJEOEEOEFG;
			ONLHLPBMJOL iIMDKHJAJGO2;
			int eBPMMNFLPMP;
			if (item.LANBHLJINFJ)
			{
				item.HideAll();
				item.ACGMFDMBCCA.fillAmount = 221f;
				item.JCIAIOAFCGF.fillAmount = 1960f;
				item.IOLHJBNKLDB.text = "Weapon state changed from \"{0}\" to \"{1}\"";
				FHDHPKDKLEG.AddTween(num3 + 0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.JDOOPPMKEFO.gameObject, 670f, 1266f, num2, -1, 826f);
				FHDHPKDKLEG.AddTween(num3 + 1, TweenAnimator.MNAIKKJDPLK.TextCounter, item.IOLHJBNKLDB.gameObject, 272f, 553f, num2, -1, 117f, UITweener.Method.BounceOut);
				FHDHPKDKLEG.BPEKAKFKCIG(num3 + 5, TweenAnimator.MNAIKKJDPLK.Rotation, item.BOOAEFNFJHH.gameObject, 1209f, 628f, num2, -1, 1292f, UITweener.Method.EaseOut, UITweener.Style.Loop);
				FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 2, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.IJGLJKDPAMC.gameObject, 974f, 1910f, num2, -1, 1700f, (UITweener.Method)8, UITweener.Style.Loop, 0);
				FHDHPKDKLEG.FEHALDPLGDB(num3 + 7, TweenAnimator.MNAIKKJDPLK.TextCounter, item.JCIAIOAFCGF.gameObject, 428f, 719f, num2, -1, 864f, UITweener.Method.BounceOut);
				FHDHPKDKLEG.MNEFMODDFFK(num3 + 6, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.ACGMFDMBCCA.gameObject, 681f, 538f, num2, -1, 843f, (UITweener.Method)6);
				if (!MEOMOOGIHKB())
				{
					FHDHPKDKLEG.NFLKPCIHOPJ(num3 + -30, TweenAnimator.MNAIKKJDPLK.Alpha, item.HKOMIDCBDBH.gameObject, 1498f, 1037f, num2, -1, 520f, UITweener.Method.Linear, UITweener.Style.Once, 0);
				}
				FHDHPKDKLEG.AddTween(num3 + -120, TweenAnimator.MNAIKKJDPLK.Alpha, item.GABLIPAALPO.gameObject, 837f, 107f, num2, -1, 14f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
				TweenAnimator fHDHPKDKLEG = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + -123;
				hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)(-54);
				nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
				kBJEOEEOEFG = 1871f;
				iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
				oEIICEJPGKI = new NHOGNBCNIEK(1578f);
				fHDHPKDKLEG.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 402f, num3 + 1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Loop);
				TweenAnimator fHDHPKDKLEG2 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + -123;
				hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)16;
				nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
				kBJEOEEOEFG = 254f;
				oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
				iIMDKHJAJGO = new NHOGNBCNIEK(143f);
				fHDHPKDKLEG2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1076f, num3 + -3, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop);
				TweenAnimator fHDHPKDKLEG3 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + 9;
				hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
				nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
				kBJEOEEOEFG = 1769f;
				iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
				eBPMMNFLPMP = num3 + 0;
				fHDHPKDKLEG3.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 1102f, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
				if (!INIAFCFICKF())
				{
					if (item.plScore > item.opScore)
					{
						FHDHPKDKLEG.NFLKPCIHOPJ(num3 + -20, TweenAnimator.MNAIKKJDPLK.Alpha, item.OMPLMJECMHO.gameObject, 891f, 856f, 489f, num3 + -113, 52f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
					}
					else if (item.opScore > item.plScore)
					{
						FHDHPKDKLEG.MNEFMODDFFK(num3 + 36, TweenAnimator.MNAIKKJDPLK.Alpha, item.FJOIHMIPKOI.gameObject, 932f, 400f, 1286f, num3 + 93, 1964f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
					}
				}
				continue;
			}
			item.HideAll();
			item.ACGMFDMBCCA.fillAmount = 1139f;
			item.JCIAIOAFCGF.fillAmount = 1278f;
			item.CHIFIDBEDFI.text = "ID_DAYS";
			item.IOLHJBNKLDB.text = "Skill";
			FHDHPKDKLEG.MNEFMODDFFK(num3 + 1, TweenAnimator.MNAIKKJDPLK.Color, item.JDOOPPMKEFO.gameObject, 314f, 104f, num2, -1, 308f, (UITweener.Method)8);
			FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.IOLHJBNKLDB.gameObject, 276f, 1975f, num2, -1, 449f, UITweener.Method.BounceOut);
			FHDHPKDKLEG.FEHALDPLGDB(num3 + 1, TweenAnimator.MNAIKKJDPLK.Alpha, item.CHIFIDBEDFI.gameObject, 668f, 949f, num2, -1, 1231f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
			FHDHPKDKLEG.FEHALDPLGDB(num3 + 1, TweenAnimator.MNAIKKJDPLK.Scale, item.HANKJKLJDEB.gameObject, 232f, 998f, num2, -1, 477f, (UITweener.Method)6, UITweener.Style.Loop);
			FHDHPKDKLEG.AddTween(num3 + 5, TweenAnimator.MNAIKKJDPLK.Scale, item.BOOAEFNFJHH.gameObject, 579f, 513f, num2, -1, 1675f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
			FHDHPKDKLEG.BPEKAKFKCIG(num3 + 1, TweenAnimator.MNAIKKJDPLK.Position, item.IJGLJKDPAMC.gameObject, 477f, 1983f, num2, -1, 1168f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
			FHDHPKDKLEG.BPEKAKFKCIG(num3 + 2, TweenAnimator.MNAIKKJDPLK.TextCounter, item.JCIAIOAFCGF.gameObject, 1800f, 141f, num2, -1, 801f, UITweener.Method.EaseIn, UITweener.Style.Loop);
			FHDHPKDKLEG.AddTween(num3 + 7, TweenAnimator.MNAIKKJDPLK.Alpha, item.ACGMFDMBCCA.gameObject, 1524f, 1794f, num2, -1, 244f, (UITweener.Method)7, UITweener.Style.Loop, 0);
			if (!MEOMOOGIHKB())
			{
				FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 66, TweenAnimator.MNAIKKJDPLK.Position, item.HKOMIDCBDBH.gameObject, 1498f, 466f, num2, -1, 68f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
			}
			FHDHPKDKLEG.NFLKPCIHOPJ(num3 + -49, TweenAnimator.MNAIKKJDPLK.Alpha, item.GABLIPAALPO.gameObject, 1149f, 1090f, num2, -1, 1798f, (UITweener.Method)7, UITweener.Style.Once, 0);
			FHDHPKDKLEG.BPEKAKFKCIG(num3 + 54, TweenAnimator.MNAIKKJDPLK.Scale, item.CFAOGMIGJLK.gameObject, 1473f, 682f, num2, -1, 1252f, (UITweener.Method)7, UITweener.Style.Once, 0);
			TweenAnimator fHDHPKDKLEG4 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 71;
			hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)(-81);
			nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
			kBJEOEEOEFG = 1015f;
			iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
			oEIICEJPGKI = new NHOGNBCNIEK(1208f);
			fHDHPKDKLEG4.BPEKAKFKCIG(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 746f, num3 + 1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
			TweenAnimator fHDHPKDKLEG5 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 22;
			hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)(-22);
			nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
			kBJEOEEOEFG = 78f;
			oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
			iIMDKHJAJGO = new NHOGNBCNIEK(887f);
			fHDHPKDKLEG5.FEHALDPLGDB(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 74f, num3 + 60, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Loop, 0);
			TweenAnimator fHDHPKDKLEG6 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + -43;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
			kBJEOEEOEFG = 1040f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
			iNFLHPGMEOB = num3 + 0;
			fHDHPKDKLEG6.MNEFMODDFFK(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 1384f, iNFLHPGMEOB, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
			TweenAnimator fHDHPKDKLEG7 = FHDHPKDKLEG;
			iNFLHPGMEOB = num3 + -29;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
			nIHOBEAHEKJ = item.CHIFIDBEDFI.gameObject;
			kBJEOEEOEFG = 967f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plModifier);
			eBPMMNFLPMP = num3 + 1;
			fHDHPKDKLEG7.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 1793f, eBPMMNFLPMP, null, (UITweener.Method)7, UITweener.Style.Once, 0);
			if (!INIAFCFICKF())
			{
				if (item.plScore > item.opScore)
				{
					FHDHPKDKLEG.MNEFMODDFFK(num3 + 80, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.OMPLMJECMHO.gameObject, 1181f, 1567f, 937f, num3 + -38, 1360f, UITweener.Method.EaseIn);
				}
				else if (item.opScore > item.plScore)
				{
					FHDHPKDKLEG.AddTween(num3 + -46, TweenAnimator.MNAIKKJDPLK.Rotation, item.FJOIHMIPKOI.gameObject, 1300f, 765f, 1320f, num3 + -88, 1902f, UITweener.Method.Linear, UITweener.Style.Once, 0);
				}
			}
		}
		FHDHPKDKLEG.GenerateTweens();
		FNOMCHPCOHB.Add(FHDHPKDKLEG);
	}

	private void HIBFMIHCPFL(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BINFBHBEFJM())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.LFGDGAAFIKB());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	private void GLOGJCBDEBF(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.LFGDGAAFIKB());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	public void CKPAAPIFKGK(float DCIKANJJFIJ)
	{
	}

	private void GOGFALIHDEM()
	{
		if (IHFILHIAGLG == null)
		{
			IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		}
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		if (GKGNHOPHHIF != null)
		{
			GKGNHOPHHIF.Clear();
		}
		else
		{
			GKGNHOPHHIF = new List<SkillshotGuiRecord>();
		}
		if (INIAFCFICKF())
		{
			PJBFDLMFKOF();
		}
		else
		{
			LBMDDDKFPOO();
		}
		JDHGGOIHKAE.repositionNow = true;
	}

	private void IDAJGAEALEK()
	{
		TweenAlphaHider.AKNNLALFDIJ(NAEMMNBKBHK, 701f, 1272f);
		TweenAlphaHider.GMLNHEIJHDE(GJLBFGCEOEO, 982f, 539f);
		TweenAlphaHider.DBPOCEIDEAE(PAHFJNBFKNP, 1406f, 955f);
		MMENJIEGOMH.alpha = 805f;
		CHOMNKDIJLL = string.Empty;
		bool flag = false;
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		if (Singleton<GameController>.instance.isBattle)
		{
			CHOMNKDIJLL = opponent.EHHHBEMKGOE.ALIIBMLMNKA;
			flag = true;
		}
		OGOIMEHGLDE.BIEIDBBDNIF(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
		OGOIMEHGLDE.AJLMACKOEPF(GameLoginManager.currentPlayer.name);
		TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 1166f, Color.white);
		PGBDGDCCELL.enabled = flag;
		if (!DGCBJAFICCE())
		{
			NOLLGINLBAB.OOOLABBEKDF();
			NOLLGINLBAB.DJPNDAICDPN(Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP);
			NOLLGINLBAB.AEEHINLDEJC((!(opponent == null)) ? opponent.EHHHBEMKGOE.MHPNDNJDPGE : string.Empty);
			TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, 135f, Color.white);
		}
		FNOMCHPCOHB.Add((!INIAFCFICKF()) ? GFNDKGNFLGA : NNINKFHEFMF);
	}

	[SpecialName]
	public List<TweenAnimator> LPFBMKBHFPE()
	{
		return FNOMCHPCOHB;
	}

	private void CPDMKIKFELO()
	{
		if (IHFILHIAGLG == null)
		{
			IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		}
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		if (GKGNHOPHHIF != null)
		{
			GKGNHOPHHIF.Clear();
		}
		else
		{
			GKGNHOPHHIF = new List<SkillshotGuiRecord>();
		}
		if (MEOMOOGIHKB())
		{
			PJBFDLMFKOF();
		}
		else
		{
			EFHAEAODNAH();
		}
		JDHGGOIHKAE.repositionNow = true;
	}

	public void CMENHODKPPL()
	{
		foreach (TweenAnimator item in JAGNEDAEGFO())
		{
			item.LILKFFOOHMC();
		}
	}

	private void EFHAEAODNAH()
	{
		SkillshotGuiRecord skillshotGuiRecord = (SkillshotGuiRecord)IHFILHIAGLG.InstantiateAsChild(IGOBHHEOHAB, JDHGGOIHKAE.gameObject, "Skillshot 0000");
		if (skillshotGuiRecord != null)
		{
			skillshotGuiRecord.MultiplayerSkillshotSpecial(Singleton<ScoreManager>.instance.score, Singleton<ScoreManager>.instance.opponentScore);
			GKGNHOPHHIF.Add(skillshotGuiRecord);
		}
		int num = 1;
		Dictionary<SkillShot.SkillShotType, int> oONJGPCEJMJ = Singleton<ScoreManager>.instance.OONJGPCEJMJ;
		if (oONJGPCEJMJ == null)
		{
			return;
		}
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in oONJGPCEJMJ)
		{
			int jOBMMDAKJMO = (Singleton<ScoreManager>.instance.KDBOEKLEPLG.ContainsKey(item.Key) ? Singleton<ScoreManager>.instance.KDBOEKLEPLG[item.Key] : 0);
			SkillshotGuiRecord skillshotGuiRecord2 = (SkillshotGuiRecord)IHFILHIAGLG.InstantiateAsChild(IGOBHHEOHAB, JDHGGOIHKAE.gameObject, string.Format("Skillshot {0}", num++.ToString("D4")));
			if (skillshotGuiRecord2 != null)
			{
				skillshotGuiRecord2.MultiplayerSkillshot(item.Value, jOBMMDAKJMO, item.Key);
				GKGNHOPHHIF.Add(skillshotGuiRecord2);
			}
		}
	}

	private void POPAIGGCAII()
	{
		if (FHDHPKDKLEG == null)
		{
			FHDHPKDKLEG = base.gameObject.AddComponent<TweenAnimator>();
		}
		if (FHDHPKDKLEG.BEOAHFDJEMD == null)
		{
			FHDHPKDKLEG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			FHDHPKDKLEG.BEOAHFDJEMD.Clear();
		}
		int num = 0;
		float num2 = 1499f;
		foreach (SkillshotGuiRecord item in GKGNHOPHHIF)
		{
			num++;
			num2 += 1543f;
			int num3 = num * -117;
			NHOGNBCNIEK oEIICEJPGKI;
			NHOGNBCNIEK iIMDKHJAJGO;
			int iNFLHPGMEOB;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA;
			GameObject nIHOBEAHEKJ;
			float kBJEOEEOEFG;
			ONLHLPBMJOL iIMDKHJAJGO2;
			int eBPMMNFLPMP;
			if (item.LANBHLJINFJ)
			{
				item.HideAll();
				item.ACGMFDMBCCA.fillAmount = 1459f;
				item.JCIAIOAFCGF.fillAmount = 211f;
				item.IOLHJBNKLDB.text = "AdminName";
				FHDHPKDKLEG.MNEFMODDFFK(num3 + 0, TweenAnimator.MNAIKKJDPLK.Color, item.JDOOPPMKEFO.gameObject, 23f, 508f, num2, -1, 1142f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
				FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 8, TweenAnimator.MNAIKKJDPLK.Position, item.IOLHJBNKLDB.gameObject, 185f, 858f, num2, -1, 73f, (UITweener.Method)6, UITweener.Style.Loop, 0);
				FHDHPKDKLEG.BPEKAKFKCIG(num3 + 2, TweenAnimator.MNAIKKJDPLK.Alpha, item.BOOAEFNFJHH.gameObject, 1578f, 776f, num2, -1, 1815f);
				FHDHPKDKLEG.MNEFMODDFFK(num3 + 0, TweenAnimator.MNAIKKJDPLK.Alpha, item.IJGLJKDPAMC.gameObject, 1586f, 183f, num2, -1, 433f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
				FHDHPKDKLEG.MNEFMODDFFK(num3 + 5, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.JCIAIOAFCGF.gameObject, 1629f, 1631f, num2, -1, 1582f, (UITweener.Method)7, UITweener.Style.Loop, 0);
				FHDHPKDKLEG.FEHALDPLGDB(num3 + 8, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.ACGMFDMBCCA.gameObject, 1906f, 1571f, num2, -1, 401f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
				if (!INIAFCFICKF())
				{
					FHDHPKDKLEG.AddTween(num3 + 42, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.HKOMIDCBDBH.gameObject, 1956f, 1903f, num2, -1, 1026f, (UITweener.Method)8, UITweener.Style.Once, 0);
				}
				FHDHPKDKLEG.BPEKAKFKCIG(num3 + 67, TweenAnimator.MNAIKKJDPLK.TextCounter, item.GABLIPAALPO.gameObject, 879f, 1510f, num2, -1, 751f, UITweener.Method.EaseIn);
				TweenAnimator fHDHPKDKLEG = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + -112;
				hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)(-93);
				nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
				kBJEOEEOEFG = 952f;
				iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
				oEIICEJPGKI = new NHOGNBCNIEK(502f);
				fHDHPKDKLEG.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1062f, num3 + 1, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Loop);
				TweenAnimator fHDHPKDKLEG2 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + 12;
				hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)(-24);
				nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
				kBJEOEEOEFG = 1911f;
				oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
				iIMDKHJAJGO = new NHOGNBCNIEK(1730f);
				fHDHPKDKLEG2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 634f, num3 + 71, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Loop, 0);
				TweenAnimator fHDHPKDKLEG3 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + 39;
				hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
				nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
				kBJEOEEOEFG = 1671f;
				iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
				eBPMMNFLPMP = num3 + 0;
				fHDHPKDKLEG3.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 148f, eBPMMNFLPMP, null, (UITweener.Method)7);
				if (!MGEIBLLKKGH)
				{
					if (item.plScore > item.opScore)
					{
						FHDHPKDKLEG.BPEKAKFKCIG(num3 + -42, TweenAnimator.MNAIKKJDPLK.Scale, item.OMPLMJECMHO.gameObject, 682f, 1868f, 352f, num3 + -105, 1977f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
					}
					else if (item.opScore > item.plScore)
					{
						FHDHPKDKLEG.FEHALDPLGDB(num3 + -85, TweenAnimator.MNAIKKJDPLK.Rotation, item.FJOIHMIPKOI.gameObject, 1289f, 1495f, 750f, num3 + 97, 598f, UITweener.Method.Linear);
					}
				}
				continue;
			}
			item.HideAll();
			item.ACGMFDMBCCA.fillAmount = 180f;
			item.JCIAIOAFCGF.fillAmount = 1941f;
			item.CHIFIDBEDFI.text = "JSON = ";
			item.IOLHJBNKLDB.text = "Cards_Owned_Silver";
			FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.JDOOPPMKEFO.gameObject, 1545f, 648f, num2, -1, 1212f, (UITweener.Method)8, UITweener.Style.Once, 0);
			FHDHPKDKLEG.MNEFMODDFFK(num3 + 7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.IOLHJBNKLDB.gameObject, 1411f, 1502f, num2, -1, 498f, UITweener.Method.EaseIn);
			FHDHPKDKLEG.MNEFMODDFFK(num3 + 5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.CHIFIDBEDFI.gameObject, 517f, 1735f, num2, -1, 1657f, (UITweener.Method)8, UITweener.Style.Loop);
			FHDHPKDKLEG.NFLKPCIHOPJ(num3 + 0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.HANKJKLJDEB.gameObject, 882f, 1499f, num2, -1, 371f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
			FHDHPKDKLEG.BPEKAKFKCIG(num3 + 5, TweenAnimator.MNAIKKJDPLK.Position, item.BOOAEFNFJHH.gameObject, 456f, 850f, num2, -1, 1685f, (UITweener.Method)6);
			FHDHPKDKLEG.FEHALDPLGDB(num3 + 5, TweenAnimator.MNAIKKJDPLK.Color, item.IJGLJKDPAMC.gameObject, 1863f, 1554f, num2, -1, 1838f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			FHDHPKDKLEG.MNEFMODDFFK(num3 + 0, TweenAnimator.MNAIKKJDPLK.Position, item.JCIAIOAFCGF.gameObject, 942f, 680f, num2, -1, 1570f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
			FHDHPKDKLEG.AddTween(num3 + 1, TweenAnimator.MNAIKKJDPLK.TextCounter, item.ACGMFDMBCCA.gameObject, 192f, 362f, num2, -1, 262f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
			if (!MEOMOOGIHKB())
			{
				FHDHPKDKLEG.FEHALDPLGDB(num3 + 50, TweenAnimator.MNAIKKJDPLK.Color, item.HKOMIDCBDBH.gameObject, 1639f, 943f, num2, -1, 597f, (UITweener.Method)6, UITweener.Style.Once, 0);
			}
			FHDHPKDKLEG.MNEFMODDFFK(num3 + 79, TweenAnimator.MNAIKKJDPLK.Rotation, item.GABLIPAALPO.gameObject, 792f, 977f, num2, -1, 220f, UITweener.Method.BounceIn, UITweener.Style.Loop);
			FHDHPKDKLEG.AddTween(num3 + 84, TweenAnimator.MNAIKKJDPLK.TextCounter, item.CFAOGMIGJLK.gameObject, 1307f, 9f, num2, -1, 295f, UITweener.Method.EaseIn);
			TweenAnimator fHDHPKDKLEG4 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + -37;
			hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)96;
			nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
			kBJEOEEOEFG = 1210f;
			iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
			oEIICEJPGKI = new NHOGNBCNIEK(741f);
			fHDHPKDKLEG4.BPEKAKFKCIG(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 943f, num3 + 1, oEIICEJPGKI, UITweener.Method.BounceIn);
			TweenAnimator fHDHPKDKLEG5 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 59;
			hADMLJODMKA = (TweenAnimator.MNAIKKJDPLK)(-31);
			nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
			kBJEOEEOEFG = 861f;
			oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
			iIMDKHJAJGO = new NHOGNBCNIEK(739f);
			fHDHPKDKLEG5.NFLKPCIHOPJ(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1453f, num3 + 65, iIMDKHJAJGO, UITweener.Method.Linear);
			TweenAnimator fHDHPKDKLEG6 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 47;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
			nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
			kBJEOEEOEFG = 30f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
			iNFLHPGMEOB = num3 + 0;
			fHDHPKDKLEG6.MNEFMODDFFK(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 1431f, iNFLHPGMEOB, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			TweenAnimator fHDHPKDKLEG7 = FHDHPKDKLEG;
			iNFLHPGMEOB = num3 + 19;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
			nIHOBEAHEKJ = item.CHIFIDBEDFI.gameObject;
			kBJEOEEOEFG = 1814f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.IJJAMEFGJHO());
			eBPMMNFLPMP = num3 + 0;
			fHDHPKDKLEG7.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 989f, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
			if (!INIAFCFICKF())
			{
				if (item.plScore > item.opScore)
				{
					FHDHPKDKLEG.AddTween(num3 + -105, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.OMPLMJECMHO.gameObject, 644f, 1165f, 978f, num3 + 52, 1940f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
				}
				else if (item.opScore > item.plScore)
				{
					FHDHPKDKLEG.AddTween(num3 + -6, TweenAnimator.MNAIKKJDPLK.Alpha, item.FJOIHMIPKOI.gameObject, 367f, 586f, 724f, num3 + -17, 857f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
				}
			}
		}
		FHDHPKDKLEG.IGBJIEBMEBF();
		FNOMCHPCOHB.Add(FHDHPKDKLEG);
	}

	private void CFPOABFFBJG(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	private void CIOGNKGIALM(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	private void KNHIMGFHDOM()
	{
		TweenAlphaHider.Begin(NAEMMNBKBHK, 0.01f, 0f);
		TweenAlphaHider.Begin(GJLBFGCEOEO, 0.01f, 0f);
		TweenAlphaHider.Begin(PAHFJNBFKNP, 0.01f, 0f);
		MMENJIEGOMH.alpha = 0f;
		CHOMNKDIJLL = string.Empty;
		bool flag = false;
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		if (Singleton<GameController>.instance.isBattle)
		{
			CHOMNKDIJLL = opponent.EHHHBEMKGOE.ALIIBMLMNKA;
			flag = true;
		}
		OGOIMEHGLDE.avatar = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		OGOIMEHGLDE.SetName(GameLoginManager.currentPlayer.name);
		TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 0f, Color.white);
		PGBDGDCCELL.enabled = flag;
		if (!MGEIBLLKKGH)
		{
			NOLLGINLBAB.Reset();
			NOLLGINLBAB.avatar = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			NOLLGINLBAB.SetName((!(opponent == null)) ? opponent.EHHHBEMKGOE.MHPNDNJDPGE : string.Empty);
			TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, 0f, Color.white);
		}
		FNOMCHPCOHB.Add((!MGEIBLLKKGH) ? GFNDKGNFLGA : NNINKFHEFMF);
	}

	[SpecialName]
	public List<TweenAnimator> CMALLAENMDH()
	{
		return FNOMCHPCOHB;
	}

	public void InitGuiValues()
	{
		FNOMCHPCOHB.Clear();
		string text = "Ribbon Bug Passed ";
		try
		{
			text += " 1";
			KNHIMGFHDOM();
			text += " 2";
			KJFPEAFIIIH();
			text += " 3";
			EKLFJNOOKJP();
			text += " 4";
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("{0}\n{1}", text, ex.StackTrace));
			AnalyticsHelper.LogHandledException(ex);
		}
	}

	public void LNLAPPKDCLN()
	{
		FNOMCHPCOHB.Clear();
		string text = "ID_CONFIRM_THANKYOU";
		try
		{
			text += "'Day'0";
			PMMLHBCPMLF();
			text += "ID_WARNING_NOTENOUGHTLEVEL";
			KJFPEAFIIIH();
			text += "Enemy could not be spawned";
			IHFNBGJNANG();
			text += "PromotedPlayer";
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("Elite_parts", text, ex.StackTrace));
			AnalyticsHelper.LogHandledException(ex);
		}
	}

	public void HJJOAJHBKCH()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Position, MMENJIEGOMH.gameObject, 1956f, 1599f, 273f, -1, 957f, UITweener.Method.EaseOut);
		NNINKFHEFMF.BPEKAKFKCIG(5, (TweenAnimator.MNAIKKJDPLK)(-113), NAEMMNBKBHK, 1300f, 1775f, 1027f, 0, 764f, UITweener.Method.BounceOut);
		NNINKFHEFMF.OOFBCPPFMPN();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.AddTween(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MMENJIEGOMH.gameObject, 290f, 1849f, 1913f, -1, 1304f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		GFNDKGNFLGA.FEHALDPLGDB(1, (TweenAnimator.MNAIKKJDPLK)(-101), NAEMMNBKBHK, 360f, 1690f, 118f, 0, 1698f, UITweener.Method.Linear);
		GFNDKGNFLGA.BPEKAKFKCIG(5, (TweenAnimator.MNAIKKJDPLK)72, GJLBFGCEOEO, 78f, 1074f, 1142f, 0, 325f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		GFNDKGNFLGA.BPEKAKFKCIG(4, (TweenAnimator.MNAIKKJDPLK)(-27), PAHFJNBFKNP, 651f, 1229f, 862f, 1, 10f, UITweener.Method.BounceOut);
		GFNDKGNFLGA.GenerateTweens();
		float num = UIHelper.activeHeight / 1901f;
		float num2 = 68f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(342f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDIIACBODEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CNDHFEBAFFP));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LEJPANKDICE));
		JDHGGOIHKAE.onReposition = MANDPFDHOKN;
		CCODGCEOMOP.onReposition = OLPEMDENPJN;
	}

	[SpecialName]
	public List<TweenAnimator> JAGNEDAEGFO()
	{
		return FNOMCHPCOHB;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		CCODGCEOMOP.repositionNow = true;
	}

	public void KDGJKKOONPB()
	{
		IHFILHIAGLG.EMLIBBBMNLN(IGOBHHEOHAB);
		GKGNHOPHHIF.Clear();
	}

	public void ACFDANMKHNG()
	{
		IHFILHIAGLG.EMLIBBBMNLN(IGOBHHEOHAB);
		GKGNHOPHHIF.Clear();
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		AKFLKJBMBAJ.AlignToPos(true);
	}

	private void MDIIACBODEN(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 1728f, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 2;
		tweenColor.style = (UITweener.Style)5;
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id);
	}

	public void OHFLAKOOGEM(float DCIKANJJFIJ)
	{
	}

	public void FinishAnimation()
	{
		foreach (TweenAnimator item in Animator)
		{
			item.FinishTweens();
		}
	}

	private void DAKKBOEONFE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id, false);
	}

	private void PBFNNKHIJGO()
	{
		if (IHFILHIAGLG == null)
		{
			IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		}
		IHFILHIAGLG.EMLIBBBMNLN(IGOBHHEOHAB);
		if (GKGNHOPHHIF != null)
		{
			GKGNHOPHHIF.Clear();
		}
		else
		{
			GKGNHOPHHIF = new List<SkillshotGuiRecord>();
		}
		if (INIAFCFICKF())
		{
			PJBFDLMFKOF();
		}
		else
		{
			EFHAEAODNAH();
		}
		JDHGGOIHKAE.repositionNow = true;
	}

	private void AEMCHBCBOFP(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.PIKIGPBNJIL())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CLODFDOMBIK());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	public void IODCFNOOAKM()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, MMENJIEGOMH.gameObject, 1203f, 342f, 773f, -1, 838f, UITweener.Method.Linear);
		NNINKFHEFMF.BPEKAKFKCIG(2, (TweenAnimator.MNAIKKJDPLK)(-76), NAEMMNBKBHK, 470f, 641f, 552f, 1, 959f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		NNINKFHEFMF.NCKIJBBJAOG();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, MMENJIEGOMH.gameObject, 1364f, 1971f, 1053f, -1, 801f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		GFNDKGNFLGA.NFLKPCIHOPJ(1, (TweenAnimator.MNAIKKJDPLK)119, NAEMMNBKBHK, 1147f, 1537f, 116f, 0, 597f, UITweener.Method.BounceIn);
		GFNDKGNFLGA.FEHALDPLGDB(5, (TweenAnimator.MNAIKKJDPLK)83, GJLBFGCEOEO, 1185f, 1040f, 1227f, 1, 1058f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		GFNDKGNFLGA.FEHALDPLGDB(3, (TweenAnimator.MNAIKKJDPLK)58, PAHFJNBFKNP, 1806f, 847f, 918f, 1, 1242f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		GFNDKGNFLGA.HONNAONCPHA();
		float num = UIHelper.activeHeight / 1744f;
		float num2 = 1700f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(1892f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DMOFOFFFMJI));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DAKKBOEONFE));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CNDHFEBAFFP));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CADKNBGKMEA));
		JDHGGOIHKAE.onReposition = PPOFIBLBLBM;
		CCODGCEOMOP.onReposition = NHEOJCCKDCO;
	}

	[SpecialName]
	private bool CHBMMPPKIAC()
	{
		return Singleton<GameController>.instance.ALPNOKNLMEG() || Singleton<GameController>.instance.isCoop;
	}

	public void PJOCALLFHAF()
	{
		foreach (TweenAnimator item in JAGNEDAEGFO())
		{
			item.KIOKIAFPHPE();
		}
	}

	private void PMMLHBCPMLF()
	{
		TweenAlphaHider.PMKKKICHILI(NAEMMNBKBHK, 1125f, 1997f);
		TweenAlphaHider.MDBMAINKPKG(GJLBFGCEOEO, 1145f, 774f);
		TweenAlphaHider.EMGFPLOHOLG(PAHFJNBFKNP, 1345f, 1925f);
		MMENJIEGOMH.alpha = 1245f;
		CHOMNKDIJLL = string.Empty;
		bool flag = true;
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		if (Singleton<GameController>.instance.isBattle)
		{
			CHOMNKDIJLL = opponent.EHHHBEMKGOE.ALIIBMLMNKA;
			flag = true;
		}
		OGOIMEHGLDE.BIEIDBBDNIF(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
		OGOIMEHGLDE.AMLMMLAIHCD(GameLoginManager.currentPlayer.name);
		TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 1543f, Color.white);
		PGBDGDCCELL.enabled = flag;
		if (!DGCBJAFICCE())
		{
			NOLLGINLBAB.KLIEOBHDFCG();
			NOLLGINLBAB.avatar = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			NOLLGINLBAB.GFEIGLKOPJK((!(opponent == null)) ? opponent.EHHHBEMKGOE.MHPNDNJDPGE : string.Empty);
			TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, 1587f, Color.white);
		}
		FNOMCHPCOHB.Add((!CHBMMPPKIAC()) ? GFNDKGNFLGA : NNINKFHEFMF);
	}

	[SpecialName]
	private bool MEOMOOGIHKB()
	{
		return Singleton<GameController>.instance.ALPNOKNLMEG() || Singleton<GameController>.instance.isCoop;
	}

	public void GMJCEEHFAJG()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MMENJIEGOMH.gameObject, 771f, 503f, 703f, -1, 1255f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		NNINKFHEFMF.MNEFMODDFFK(3, (TweenAnimator.MNAIKKJDPLK)(-91), NAEMMNBKBHK, 117f, 961f, 608f, 0, 1084f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		NNINKFHEFMF.KHAFPAMIOAF();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.AddTween(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MMENJIEGOMH.gameObject, 564f, 671f, 594f, -1, 1563f, UITweener.Method.Linear);
		GFNDKGNFLGA.BPEKAKFKCIG(8, (TweenAnimator.MNAIKKJDPLK)90, NAEMMNBKBHK, 1436f, 1202f, 1796f, 0, 574f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		GFNDKGNFLGA.AddTween(0, (TweenAnimator.MNAIKKJDPLK)25, GJLBFGCEOEO, 990f, 215f, 379f, 1, 726f, (UITweener.Method)8, UITweener.Style.Loop);
		GFNDKGNFLGA.FEHALDPLGDB(0, (TweenAnimator.MNAIKKJDPLK)58, PAHFJNBFKNP, 939f, 155f, 124f, 0, 947f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		GFNDKGNFLGA.NCKIJBBJAOG();
		float num = UIHelper.activeHeight / 1928f;
		float num2 = 1964f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(1441f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDIIACBODEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KHPMNCGKKCJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CADKNBGKMEA));
		JDHGGOIHKAE.onReposition = MANDPFDHOKN;
		CCODGCEOMOP.onReposition = EIGHAKHHGEI;
	}

	private void FNACJALCDPK()
	{
		if (IHFILHIAGLG == null)
		{
			IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		}
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		if (GKGNHOPHHIF != null)
		{
			GKGNHOPHHIF.Clear();
		}
		else
		{
			GKGNHOPHHIF = new List<SkillshotGuiRecord>();
		}
		if (MEOMOOGIHKB())
		{
			PJBFDLMFKOF();
		}
		else
		{
			LBMDDDKFPOO();
		}
		JDHGGOIHKAE.repositionNow = false;
	}

	private void EOJOHJOCKDL(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 1656f, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 5;
		tweenColor.style = (UITweener.Style)6;
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id);
	}

	public void ENNMDICLIGH()
	{
		foreach (TweenAnimator item in Animator)
		{
			item.DGFKMBDKEAP();
		}
	}

	public void AEPHDFDLCHC()
	{
		foreach (TweenAnimator item in JAGNEDAEGFO())
		{
			item.DGFKMBDKEAP();
		}
	}

	private void LEJPANKDICE(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.PIKIGPBNJIL())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	private void LBMDDDKFPOO()
	{
		SkillshotGuiRecord skillshotGuiRecord = (SkillshotGuiRecord)IHFILHIAGLG.OKEAAILFPIG(IGOBHHEOHAB, JDHGGOIHKAE.gameObject, "Hiding request to join private squad");
		if (skillshotGuiRecord != null)
		{
			skillshotGuiRecord.MultiplayerSkillshotSpecial(Singleton<ScoreManager>.instance.EIBLONLEOMA(), Singleton<ScoreManager>.instance.IIPCHGNMLCN());
			GKGNHOPHHIF.Add(skillshotGuiRecord);
		}
		int num = 0;
		Dictionary<SkillShot.SkillShotType, int> oONJGPCEJMJ = Singleton<ScoreManager>.instance.OONJGPCEJMJ;
		if (oONJGPCEJMJ == null)
		{
			return;
		}
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in oONJGPCEJMJ)
		{
			int jOBMMDAKJMO = ((!Singleton<ScoreManager>.instance.KDBOEKLEPLG.ContainsKey(item.Key)) ? 1 : Singleton<ScoreManager>.instance.KDBOEKLEPLG[item.Key]);
			SkillshotGuiRecord skillshotGuiRecord2 = (SkillshotGuiRecord)IHFILHIAGLG.AAIBNGPFKGF(IGOBHHEOHAB, JDHGGOIHKAE.gameObject, string.Format("ShotFrequencyMin", num++.ToString("ID_CONFIRM_ERROR")));
			if (skillshotGuiRecord2 != null)
			{
				skillshotGuiRecord2.MultiplayerSkillshot(item.Value, jOBMMDAKJMO, item.Key);
				GKGNHOPHHIF.Add(skillshotGuiRecord2);
			}
		}
	}

	private void NHEOJCCKDCO()
	{
		AKFLKJBMBAJ.AlignToPos(false, UIDraggablePanel.Alingment.TopLeft, true);
	}

	private void DMOFOFFFMJI(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(OGOIMEHGLDE.PKHHKJLGHFM.gameObject, 0.2f, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 2;
		tweenColor.style = UITweener.Style.PingPong;
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id);
	}

	private void KNEKEJNFNBK()
	{
		if (IHFILHIAGLG == null)
		{
			IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		}
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		if (GKGNHOPHHIF != null)
		{
			GKGNHOPHHIF.Clear();
		}
		else
		{
			GKGNHOPHHIF = new List<SkillshotGuiRecord>();
		}
		if (DGCBJAFICCE())
		{
			PJBFDLMFKOF();
		}
		else
		{
			LBMDDDKFPOO();
		}
		JDHGGOIHKAE.repositionNow = true;
	}

	private void LBGJIKJLFHE(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BINFBHBEFJM())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	[SpecialName]
	private bool KCELFAEOFCI()
	{
		return Singleton<GameController>.instance.HMBNJHKKIPJ() || Singleton<GameController>.instance.isCoop;
	}

	private void CADKNBGKMEA(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.JJLMFFJEJGL())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BLFCDBMINCD());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	[SpecialName]
	public List<TweenAnimator> MMMCBLHEAAN()
	{
		return FNOMCHPCOHB;
	}

	private void DCLIHPMKOHD()
	{
		AKFLKJBMBAJ.AlignToPos(false);
	}

	public void JMDOFLJIGKO()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Position, MMENJIEGOMH.gameObject, 275f, 1772f, 1288f, -1, 1738f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		NNINKFHEFMF.BPEKAKFKCIG(6, (TweenAnimator.MNAIKKJDPLK)(-4), NAEMMNBKBHK, 1578f, 790f, 1859f, 0, 1211f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		NNINKFHEFMF.OOFBCPPFMPN();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Rotation, MMENJIEGOMH.gameObject, 1586f, 1299f, 1292f, -1, 794f, UITweener.Method.Linear, UITweener.Style.Loop);
		GFNDKGNFLGA.MNEFMODDFFK(8, (TweenAnimator.MNAIKKJDPLK)44, NAEMMNBKBHK, 1439f, 1650f, 217f, 0, 1955f, (UITweener.Method)8, UITweener.Style.Loop);
		GFNDKGNFLGA.BPEKAKFKCIG(5, (TweenAnimator.MNAIKKJDPLK)(-128), GJLBFGCEOEO, 96f, 1136f, 1095f, 1, 1749f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		GFNDKGNFLGA.NFLKPCIHOPJ(1, (TweenAnimator.MNAIKKJDPLK)15, PAHFJNBFKNP, 1185f, 335f, 498f, 1, 921f, (UITweener.Method)7);
		GFNDKGNFLGA.HONNAONCPHA();
		float num = UIHelper.activeHeight / 1816f;
		float num2 = 1505f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(390f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EOJOHJOCKDL));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LBGJIKJLFHE));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NBKJAOEKOAK));
		JDHGGOIHKAE.onReposition = MANDPFDHOKN;
		CCODGCEOMOP.onReposition = OLPEMDENPJN;
	}

	private void EKLFJNOOKJP()
	{
		if (FHDHPKDKLEG == null)
		{
			FHDHPKDKLEG = base.gameObject.AddComponent<TweenAnimator>();
		}
		if (FHDHPKDKLEG.BEOAHFDJEMD == null)
		{
			FHDHPKDKLEG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			FHDHPKDKLEG.BEOAHFDJEMD.Clear();
		}
		int num = 0;
		float num2 = 0.5f;
		foreach (SkillshotGuiRecord item in GKGNHOPHHIF)
		{
			num++;
			num2 += 0.2f;
			int num3 = num * 100;
			NHOGNBCNIEK oEIICEJPGKI;
			NHOGNBCNIEK iIMDKHJAJGO;
			int iNFLHPGMEOB;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA;
			GameObject nIHOBEAHEKJ;
			float kBJEOEEOEFG;
			ONLHLPBMJOL iIMDKHJAJGO2;
			int eBPMMNFLPMP;
			if (item.LANBHLJINFJ)
			{
				item.HideAll();
				item.ACGMFDMBCCA.fillAmount = 0f;
				item.JCIAIOAFCGF.fillAmount = 0f;
				item.IOLHJBNKLDB.text = "x0";
				FHDHPKDKLEG.AddTween(num3 + 1, TweenAnimator.MNAIKKJDPLK.Alpha, item.JDOOPPMKEFO.gameObject, 0.5f, 1f, num2, -1, 0f);
				FHDHPKDKLEG.AddTween(num3 + 3, TweenAnimator.MNAIKKJDPLK.Alpha, item.IOLHJBNKLDB.gameObject, 0.5f, 1f, num2, -1, 0f);
				FHDHPKDKLEG.AddTween(num3 + 5, TweenAnimator.MNAIKKJDPLK.Alpha, item.BOOAEFNFJHH.gameObject, 0.5f, 1f, num2, -1, 0f);
				FHDHPKDKLEG.AddTween(num3 + 6, TweenAnimator.MNAIKKJDPLK.Alpha, item.IJGLJKDPAMC.gameObject, 0.5f, 1f, num2, -1, 0f);
				FHDHPKDKLEG.AddTween(num3 + 7, TweenAnimator.MNAIKKJDPLK.Alpha, item.JCIAIOAFCGF.gameObject, 0.5f, 1f, num2, -1, 0f);
				FHDHPKDKLEG.AddTween(num3 + 8, TweenAnimator.MNAIKKJDPLK.Alpha, item.ACGMFDMBCCA.gameObject, 0.5f, 1f, num2, -1, 0f);
				if (!MGEIBLLKKGH)
				{
					FHDHPKDKLEG.AddTween(num3 + 9, TweenAnimator.MNAIKKJDPLK.Alpha, item.HKOMIDCBDBH.gameObject, 0.5f, 1f, num2, -1, 0f);
				}
				FHDHPKDKLEG.AddTween(num3 + 10, TweenAnimator.MNAIKKJDPLK.Alpha, item.GABLIPAALPO.gameObject, 0.5f, 1f, num2, -1, 0f);
				TweenAnimator fHDHPKDKLEG = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + 12;
				hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.ProgressBar;
				nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
				kBJEOEEOEFG = 0.2f;
				iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
				oEIICEJPGKI = new NHOGNBCNIEK(0f);
				fHDHPKDKLEG.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, num3 + 1, oEIICEJPGKI);
				TweenAnimator fHDHPKDKLEG2 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + 13;
				hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.ProgressBar;
				nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
				kBJEOEEOEFG = 0.2f;
				oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
				iIMDKHJAJGO = new NHOGNBCNIEK(0f);
				fHDHPKDKLEG2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, num3 + 12, iIMDKHJAJGO);
				TweenAnimator fHDHPKDKLEG3 = FHDHPKDKLEG;
				iNFLHPGMEOB = num3 + 14;
				hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
				nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
				kBJEOEEOEFG = 0.4f;
				iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
				eBPMMNFLPMP = num3 + 1;
				fHDHPKDKLEG3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 0f, eBPMMNFLPMP);
				if (!MGEIBLLKKGH)
				{
					if (item.plScore > item.opScore)
					{
						FHDHPKDKLEG.AddTween(num3 + 16, TweenAnimator.MNAIKKJDPLK.Alpha, item.OMPLMJECMHO.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
					}
					else if (item.opScore > item.plScore)
					{
						FHDHPKDKLEG.AddTween(num3 + 16, TweenAnimator.MNAIKKJDPLK.Alpha, item.FJOIHMIPKOI.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
					}
				}
				continue;
			}
			item.HideAll();
			item.ACGMFDMBCCA.fillAmount = 0f;
			item.JCIAIOAFCGF.fillAmount = 0f;
			item.CHIFIDBEDFI.text = "+0";
			item.IOLHJBNKLDB.text = "x0";
			FHDHPKDKLEG.AddTween(num3 + 1, TweenAnimator.MNAIKKJDPLK.Alpha, item.JDOOPPMKEFO.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 2, TweenAnimator.MNAIKKJDPLK.Alpha, item.IOLHJBNKLDB.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 3, TweenAnimator.MNAIKKJDPLK.Alpha, item.CHIFIDBEDFI.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 4, TweenAnimator.MNAIKKJDPLK.Alpha, item.HANKJKLJDEB.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 5, TweenAnimator.MNAIKKJDPLK.Alpha, item.BOOAEFNFJHH.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 6, TweenAnimator.MNAIKKJDPLK.Alpha, item.IJGLJKDPAMC.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 7, TweenAnimator.MNAIKKJDPLK.Alpha, item.JCIAIOAFCGF.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 8, TweenAnimator.MNAIKKJDPLK.Alpha, item.ACGMFDMBCCA.gameObject, 0.5f, 1f, num2, -1, 0f);
			if (!MGEIBLLKKGH)
			{
				FHDHPKDKLEG.AddTween(num3 + 9, TweenAnimator.MNAIKKJDPLK.Alpha, item.HKOMIDCBDBH.gameObject, 0.5f, 1f, num2, -1, 0f);
			}
			FHDHPKDKLEG.AddTween(num3 + 10, TweenAnimator.MNAIKKJDPLK.Alpha, item.GABLIPAALPO.gameObject, 0.5f, 1f, num2, -1, 0f);
			FHDHPKDKLEG.AddTween(num3 + 11, TweenAnimator.MNAIKKJDPLK.Alpha, item.CFAOGMIGJLK.gameObject, 0.5f, 1f, num2, -1, 0f);
			TweenAnimator fHDHPKDKLEG4 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 12;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.ProgressBar;
			nIHOBEAHEKJ = item.JCIAIOAFCGF.gameObject;
			kBJEOEEOEFG = 0.2f;
			iIMDKHJAJGO = new NHOGNBCNIEK(item.plProgress);
			oEIICEJPGKI = new NHOGNBCNIEK(0f);
			fHDHPKDKLEG4.AddTween(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, num3 + 1, oEIICEJPGKI);
			TweenAnimator fHDHPKDKLEG5 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 13;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.ProgressBar;
			nIHOBEAHEKJ = item.ACGMFDMBCCA.gameObject;
			kBJEOEEOEFG = 0.2f;
			oEIICEJPGKI = new NHOGNBCNIEK(item.plProgress);
			iIMDKHJAJGO = new NHOGNBCNIEK(0f);
			fHDHPKDKLEG5.AddTween(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, num3 + 12, iIMDKHJAJGO);
			TweenAnimator fHDHPKDKLEG6 = FHDHPKDKLEG;
			eBPMMNFLPMP = num3 + 14;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
			nIHOBEAHEKJ = item.IOLHJBNKLDB.gameObject;
			kBJEOEEOEFG = 0.4f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plScore);
			iNFLHPGMEOB = num3 + 1;
			fHDHPKDKLEG6.AddTween(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 0f, iNFLHPGMEOB);
			TweenAnimator fHDHPKDKLEG7 = FHDHPKDKLEG;
			iNFLHPGMEOB = num3 + 15;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
			nIHOBEAHEKJ = item.CHIFIDBEDFI.gameObject;
			kBJEOEEOEFG = 0.4f;
			iIMDKHJAJGO2 = new ONLHLPBMJOL(item.plModifier);
			eBPMMNFLPMP = num3 + 1;
			fHDHPKDKLEG7.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO2, 0f, eBPMMNFLPMP);
			if (!MGEIBLLKKGH)
			{
				if (item.plScore > item.opScore)
				{
					FHDHPKDKLEG.AddTween(num3 + 16, TweenAnimator.MNAIKKJDPLK.Alpha, item.OMPLMJECMHO.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
				}
				else if (item.opScore > item.plScore)
				{
					FHDHPKDKLEG.AddTween(num3 + 16, TweenAnimator.MNAIKKJDPLK.Alpha, item.FJOIHMIPKOI.gameObject, 0.5f, 1f, 0f, num3 + 12, 0f);
				}
			}
		}
		FHDHPKDKLEG.GenerateTweens();
		FNOMCHPCOHB.Add(FHDHPKDKLEG);
	}

	private void KHPMNCGKKCJ(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL);
			}
		}
	}

	public void AnimateShow(float DCIKANJJFIJ)
	{
	}

	private void DBPFHDELBAH()
	{
		if (IHFILHIAGLG == null)
		{
			IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		}
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		if (GKGNHOPHHIF != null)
		{
			GKGNHOPHHIF.Clear();
		}
		else
		{
			GKGNHOPHHIF = new List<SkillshotGuiRecord>();
		}
		if (MEOMOOGIHKB())
		{
			PJBFDLMFKOF();
		}
		else
		{
			LBMDDDKFPOO();
		}
		JDHGGOIHKAE.repositionNow = false;
	}

	private void GIEJNDAOPJN(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			TweenColor tweenColor = TweenColor.Begin(NOLLGINLBAB.PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.PIKIGPBNJIL())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BLFCDBMINCD());
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL);
			}
		}
	}

	public void ResetAnimation()
	{
		foreach (TweenAnimator item in Animator)
		{
			item.ResetTweens();
		}
	}

	public void JKEEMKIHFEE()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		FNOMCHPCOHB = new List<TweenAnimator>();
		NNINKFHEFMF = base.gameObject.AddComponent<TweenAnimator>();
		NNINKFHEFMF.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		NNINKFHEFMF.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MMENJIEGOMH.gameObject, 1647f, 921f, 1991f, -1, 1756f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		NNINKFHEFMF.MNEFMODDFFK(7, (TweenAnimator.MNAIKKJDPLK)(-110), NAEMMNBKBHK, 202f, 270f, 494f, 1, 695f, (UITweener.Method)8, UITweener.Style.Loop);
		NNINKFHEFMF.KHAFPAMIOAF();
		GFNDKGNFLGA = base.gameObject.AddComponent<TweenAnimator>();
		GFNDKGNFLGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		GFNDKGNFLGA.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Rotation, MMENJIEGOMH.gameObject, 1180f, 65f, 401f, -1, 1432f, (UITweener.Method)6, UITweener.Style.Loop);
		GFNDKGNFLGA.BPEKAKFKCIG(6, (TweenAnimator.MNAIKKJDPLK)23, NAEMMNBKBHK, 983f, 133f, 527f, 1, 496f, (UITweener.Method)8);
		GFNDKGNFLGA.FEHALDPLGDB(4, (TweenAnimator.MNAIKKJDPLK)(-33), GJLBFGCEOEO, 1828f, 1235f, 247f, 0, 1669f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		GFNDKGNFLGA.BPEKAKFKCIG(3, (TweenAnimator.MNAIKKJDPLK)(-65), PAHFJNBFKNP, 436f, 606f, 1736f, 0, 1341f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		GFNDKGNFLGA.NCKIJBBJAOG();
		float num = UIHelper.activeHeight / 425f;
		float num2 = 117f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(1257f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EOJOHJOCKDL));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DOOJCCHBKLK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GBDLNMBEJDK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KHPMNCGKKCJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(DDEECICNNLN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LEJPANKDICE));
		JDHGGOIHKAE.onReposition = PPOFIBLBLBM;
		CCODGCEOMOP.onReposition = DCLIHPMKOHD;
	}

	private void OLPEMDENPJN()
	{
		AKFLKJBMBAJ.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight, true);
	}

	public void BGHBHHFBCIC()
	{
		FNOMCHPCOHB.Clear();
		string text = "PlayerLevel";
		try
		{
			text += "StartTime";
			KNHIMGFHDOM();
			text += "Weapon";
			GOGFALIHDEM();
			text += "medals";
			EKLFJNOOKJP();
			text += "ID_STARTERPACK";
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("View_Completed", text, ex.StackTrace));
			AnalyticsHelper.LogHandledException(ex);
		}
	}

	public void IOALKHMJEEA()
	{
		FNOMCHPCOHB.Clear();
		string text = "Player not in squad! - WTF";
		try
		{
			text += "#AccoutCheck# Facebook accoun found - invalid ID";
			KNHIMGFHDOM();
			text += "AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}";
			CPDMKIKFELO();
			text += "null";
			POPAIGGCAII();
			text += "ID_RANK";
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("com/google/android/gms/games/Games", text, ex.StackTrace));
			AnalyticsHelper.LogHandledException(ex);
		}
	}

	private void EIGHAKHHGEI()
	{
		AKFLKJBMBAJ.AlignToPos(true);
	}

	public void LIJFFGBNJPG()
	{
		IHFILHIAGLG.FreeObjectsWithPrefab(IGOBHHEOHAB);
		GKGNHOPHHIF.Clear();
	}

	public void FBBPINNHOCH()
	{
		IHFILHIAGLG.NDPKMHDALCM(IGOBHHEOHAB);
		GKGNHOPHHIF.Clear();
	}

	private void NBKJAOEKOAK(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.isBattle)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.JJLMFFJEJGL())
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(NOLLGINLBAB.PKHHKJLGHFM.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NOLLGINLBAB.PKHHKJLGHFM.text, CHOMNKDIJLL, false);
			}
		}
	}

	[SpecialName]
	private bool INIAFCFICKF()
	{
		return !Singleton<GameController>.instance.ALPNOKNLMEG() && Singleton<GameController>.instance.MNPNHJKBNCJ();
	}

	public void GNKABPFOIBC(float DCIKANJJFIJ)
	{
	}
}
