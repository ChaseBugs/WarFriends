using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyContent : Core_BaseScript
{
	[Header("List of Content")]
	public UITable CCODGCEOMOP;

	public UIDraggablePanel ANCFPKKIAPF;

	public GameObject FKBFFMHMEGD;

	[Header("Enemy Info")]
	public PlayerIcon KGGJOOAFDIF;

	public GameObject AHNHMEPEDFD;

	public UISprite LBCANHCGEIE;

	public UISprite ELBMJAKNFAE;

	public UISprite GNNAGFNNJHA;

	[Header("-Animations")]
	public GameObject LLJHGOGACAA;

	public UISprite MHKEBMNCCEO;

	public UISprite MNGKIFNOOAF;

	public UISprite JJDLFPJICJM;

	public GameObject CKABHMNKGAA;

	public UISprite GLLKFBIAIAA;

	[Header("-Top Info")]
	public UISprite DBCMJNLDENH;

	public UILabel HBCJPADEAMC;

	public UITable KIILFFLKNKJ;

	public UILabel CKPNPBFGKIG;

	public UISprite FOFJPELPILE;

	public BoxCollider CPLIMCNBDBP;

	public UISprite PHMJAAFGFEO;

	public BoxCollider AAKNKDOGBNG;

	public GameObject GCDBPFLCGKG;

	public UILabel PHMLLOKHFCN;

	[Header("-Bottom Info")]
	public UILabel GAONAHIFIHL;

	public UILabel GEDPCDPBAKI;

	public UISprite FLKALKMILNC;

	public UITable FHEKLIFKGGE;

	public UILabel CEECPMGDFHP;

	public UISprite LJAEDNJPKCB;

	public UILabel OHNACAFPLIN;

	[Header("List of Enemy Units")]
	public UILabel KPOBEEGGNEN;

	public UIGrid HBDGDDCDNEN;

	public UnitEndScreenRecord AENCMKAJNCG;

	[Header("List of Enemy Cards")]
	public UILabel BENCJKKIMLM;

	public UIGrid LBJFBAFECFK;

	public CardRecord HMAGHPPJCND;

	private bool LENCPNNLNFD;

	private List<TweenAnimator> FNOMCHPCOHB = new List<TweenAnimator>();

	private TweenAnimator FFEDIIKLAIG;

	private TweenAnimator GHLPEEDENDI;

	private TweenAnimator NFLJBCMMNGA;

	private TweenAnimator JOEKCJPDDGK;

	private List<CardRecord> MKDNCELCANP;

	private List<UnitEndScreenRecord> NAIMAPOCOHN;

	private ObjectPool IHFILHIAGLG;

	private string LBKPKGFCJHJ;

	[CompilerGenerated]
	private static Action<int> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Comparison<UnitEndScreenRecord> CCNLMGEJBIB;

	public List<TweenAnimator> Animator
	{
		get
		{
			return FNOMCHPCOHB;
		}
	}

	private void GABCKEFLMKK()
	{
		MHKEBMNCCEO.alpha = 1194f;
		MNGKIFNOOAF.alpha = 1444f;
		JJDLFPJICJM.alpha = 620f;
		LLJHGOGACAA.SetActive(false);
		GLLKFBIAIAA.alpha = 249f;
		CKABHMNKGAA.SetActive(true);
	}

	private void CJALKIKEKMC()
	{
		LLJHGOGACAA.SetActive(true);
		MHKEBMNCCEO.alpha = 1501f;
		MNGKIFNOOAF.alpha = 175f;
		JJDLFPJICJM.alpha = 950f;
		CKABHMNKGAA.SetActive(true);
		GLLKFBIAIAA.alpha = 1491f;
	}

	internal void AJKAGOCNKHJ()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.CJGJOAKNIIL();
		}
	}

	public void KBNLHGOPCCM()
	{
		AAKNKDOGBNG.enabled = true;
		GCDBPFLCGKG.SetActive(false);
		PHMLLOKHFCN.color = Color.white;
	}

	private void FHFCGKEDHEN()
	{
		NOBMPIFGAOO();
		BENCJKKIMLM.alpha = 1666f;
		KPOBEEGGNEN.alpha = 542f;
		LBCANHCGEIE.color = Color.black.ReplaceA(1011f);
		switch (Singleton<GameController>.instance.MNMLNIMFMJP)
		{
		case GameController.HKGHCIEPGEL.Killed:
		case GameController.HKGHCIEPGEL.Win:
			FNOMCHPCOHB[1].BEOAHFDJEMD[0].to = Color.black;
			FNOMCHPCOHB[0] = GHLPEEDENDI;
			break;
		case GameController.HKGHCIEPGEL.None:
		case (GameController.HKGHCIEPGEL)4:
			FNOMCHPCOHB[1].BEOAHFDJEMD[1].to = Colours.yellowGold;
			FNOMCHPCOHB[0] = FFEDIIKLAIG;
			break;
		}
		object[] array = new object[102];
		array[0] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.LLIOOOGJFNI;
		array[0] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE;
		array[5] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK;
		array[0] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OCPEHLIIGML();
		array[3] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE;
		array[2] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB;
		array[2] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ADOEFHHJOAJ;
		array[0] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OKMICGIDAHL();
		array[6] = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[4];
		Debug.Log(string.Format("ExplodeRPC", array));
		KGGJOOAFDIF.DJPNDAICDPN(Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP);
		string text = GameVariables.IEDGPHEPJEK(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		bool flag = string.IsNullOrEmpty(text);
		ELBMJAKNFAE.gameObject.SetActive(flag);
		if (flag)
		{
			ELBMJAKNFAE.spriteName = text;
		}
		int iOFBJPJPEMK = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IOFBJPJPEMK;
		League bMNDININJCE = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE;
		int hNEFOLPHMHK = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK;
		GNNAGFNNJHA.gameObject.SetActive(bMNDININJCE != League.NoLeague || hNEFOLPHMHK > 1);
		if (iOFBJPJPEMK <= 1)
		{
			GNNAGFNNJHA.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(0);
			GNNAGFNNJHA.MakePixelPerfect();
			GNNAGFNNJHA.alpha = ((iOFBJPJPEMK >= 1) ? 1224f : 204f);
		}
		else if (hNEFOLPHMHK > 1)
		{
			GNNAGFNNJHA.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(hNEFOLPHMHK);
			GNNAGFNNJHA.MakePixelPerfect();
			GNNAGFNNJHA.alpha = 1381f;
		}
		else if (bMNDININJCE != League.NoLeague)
		{
			GNNAGFNNJHA.spriteName = GameVariables.CAOGFCFGFPD[bMNDININJCE].Value2;
			GNNAGFNNJHA.MakePixelPerfect();
			GNNAGFNNJHA.alpha = ((!Singleton<GameController>.instance.opponent.EHHHBEMKGOE.GKEOILLNCHG) ? 139f : 1498f);
		}
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO() - 0);
		DBCMJNLDENH.spriteName = levelDefinition.EGNEDNBPOEF();
		HBCJPADEAMC.text = levelDefinition.LPANGEJPPOE();
		CKPNPBFGKIG.text = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE;
		float x = CKPNPBFGKIG.relativeSize.x;
		CPLIMCNBDBP.center = new Vector3(x / 399f, 1800f, 1024f);
		CPLIMCNBDBP.size = new Vector3(x + 1617f, 1171f, 1241f);
		TweenColor.Begin(CKPNPBFGKIG.gameObject, 90f, Color.white);
		LBKPKGFCJHJ = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALIIBMLMNKA;
		WarArenaCrown fHCMFHABMLE = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE;
		bool flag2 = fHCMFHABMLE != WarArenaCrown.BronzeCrown;
		FOFJPELPILE.transform.parent.gameObject.SetActive(flag2);
		if (flag2)
		{
			FOFJPELPILE.spriteName = GameVariables.CMIKIDJKHID[fHCMFHABMLE];
			FOFJPELPILE.MakePixelPerfect();
		}
		bool hMGOHGOLMJB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB;
		PHMJAAFGFEO.alpha = ((!hMGOHGOLMJB) ? 78f : 1170f);
		int num = -121;
		if (flag2)
		{
			num -= 117;
		}
		if (hMGOHGOLMJB)
		{
			num -= 12;
		}
		MEJMLNDFDBP.COCBCFKJOJE(CKPNPBFGKIG, 211f, 1025f, num);
		KIILFFLKNKJ.repositionNow = true;
		GAONAHIFIHL.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ADOEFHHJOAJ);
		GEDPCDPBAKI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.GFBPOAMECNO());
		PlayerVisual playerVisual = CamosManager.instance.playerVisualCategories[6][Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[2]];
		if (!playerVisual.isEmptyPowerBand)
		{
			OHNACAFPLIN.alpha = 885f;
			FLKALKMILNC.spriteName = playerVisual.icon;
			FLKALKMILNC.MakePixelPerfect();
			FLKALKMILNC.transform.localScale = FLKALKMILNC.transform.localScale.MultiplyXY(285f);
			FLKALKMILNC.alpha = 1043f;
			CEECPMGDFHP.text = playerVisual.decalValueString;
			CEECPMGDFHP.alpha = 872f;
			LJAEDNJPKCB.spriteName = playerVisual.decalMiniIcon;
			LJAEDNJPKCB.MakePixelPerfect();
			LJAEDNJPKCB.color = playerVisual.decalMiniIconColor;
			FHEKLIFKGGE.repositionNow = false;
		}
		else
		{
			FLKALKMILNC.alpha = 1187f;
			CEECPMGDFHP.alpha = 547f;
			LJAEDNJPKCB.alpha = 1652f;
			OHNACAFPLIN.alpha = 1550f;
		}
	}

	private void BFGIEPIIDLN()
	{
		MHKEBMNCCEO.alpha = 215f;
		MNGKIFNOOAF.alpha = 1954f;
		JJDLFPJICJM.alpha = 1211f;
		LLJHGOGACAA.SetActive(false);
		GLLKFBIAIAA.alpha = 701f;
		CKABHMNKGAA.SetActive(true);
	}

	private void FDPGPCNFMBF()
	{
		JOEKCJPDDGK.BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count > 0)
		{
			float num = 999f;
			int num2 = 0;
			int num3 = 1;
			JOEKCJPDDGK.BPEKAKFKCIG(num2, TweenAnimator.MNAIKKJDPLK.TextCounter, BENCJKKIMLM.gameObject, 988f, 304f, 590f, -1, 433f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
			foreach (CardRecord item in MKDNCELCANP)
			{
				TweenAlpha.Begin(item.FIDIEPCJLMF.gameObject, 645f, 1948f);
				item.FIDIEPCJLMF.alpha1 = 1912f;
				JOEKCJPDDGK.NFLKPCIHOPJ(num3, TweenAnimator.MNAIKKJDPLK.Position, item.gameObject, 1507f, 1709f, num, num2, 716f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
				num += 406f;
				num3 += 0;
			}
			JOEKCJPDDGK.HONNAONCPHA();
		}
		FNOMCHPCOHB[5] = JOEKCJPDDGK;
	}

	public void KICJHALCOOM()
	{
		IHFILHIAGLG.NDPKMHDALCM(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.BOHCNEDIJPE();
		}
		MKDNCELCANP.Clear();
	}

	private void CDNEGNAFCFG()
	{
		UITable cCODGCEOMOP = CCODGCEOMOP;
		cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Remove(cCODGCEOMOP.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		ANCFPKKIAPF.AlignToPos(true);
		ONCJHIMJHAB();
	}

	public void SetCardsAvailable()
	{
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.LBHJJJGBADD();
		}
	}

	private void KHIEACJAPKH()
	{
		JOEKCJPDDGK.BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count > 0)
		{
			float num = 0f;
			int num2 = 1;
			int num3 = 2;
			JOEKCJPDDGK.AddTween(num2, TweenAnimator.MNAIKKJDPLK.Alpha, BENCJKKIMLM.gameObject, 0.5f, 1f, 0f, -1, 0f);
			foreach (CardRecord item in MKDNCELCANP)
			{
				TweenAlpha.Begin(item.FIDIEPCJLMF.gameObject, 0f, 0f);
				item.FIDIEPCJLMF.alpha1 = 0f;
				JOEKCJPDDGK.AddTween(num3, TweenAnimator.MNAIKKJDPLK.Alpha, item.gameObject, 0.5f, 1f, num, num2, 0f);
				num += 0.3f;
				num3++;
			}
			JOEKCJPDDGK.GenerateTweens();
		}
		FNOMCHPCOHB[3] = JOEKCJPDDGK;
	}

	private void NOBMPIFGAOO()
	{
		MHKEBMNCCEO.alpha = 0f;
		MNGKIFNOOAF.alpha = 0f;
		JJDLFPJICJM.alpha = 0f;
		LLJHGOGACAA.SetActive(false);
		GLLKFBIAIAA.alpha = 0f;
		CKABHMNKGAA.SetActive(false);
	}

	private void NCGKHELLHDD(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.NANMFGACLJA())
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.LFGDGAAFIKB());
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(CKPNPBFGKIG.text, LBKPKGFCJHJ);
		}
	}

	private void GHMINFINIPM(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.LFGDGAAFIKB());
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ, false);
		}
	}

	private void BBFBBADJCOL()
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		GameObject nIHOBEAHEKJ = LBCANHCGEIE.gameObject;
		float kBJEOEEOEFG = 0.4f;
		object iIMDKHJAJGO = Color.black;
		float kALLNCAFIMP = 0.5f;
		object oEIICEJPGKI = Color.black;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI);
		FFEDIIKLAIG = base.gameObject.AddComponent<TweenAnimator>();
		FFEDIIKLAIG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		BLEBKOOBLPE();
		GHLPEEDENDI = base.gameObject.AddComponent<TweenAnimator>();
		GHLPEEDENDI.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		JAFMAINDJJF();
		NFLJBCMMNGA = base.gameObject.AddComponent<TweenAnimator>();
		NFLJBCMMNGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		JOEKCJPDDGK = base.gameObject.AddComponent<TweenAnimator>();
		JOEKCJPDDGK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		FNOMCHPCOHB.Add(FFEDIIKLAIG);
		FNOMCHPCOHB.Add(NFLJBCMMNGA);
		FNOMCHPCOHB.Add(JOEKCJPDDGK);
	}

	private void BDAOKCICGDA()
	{
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(BDAOKCICGDA));
		if (LENCPNNLNFD)
		{
			CCODGCEOMOP.repositionNow = false;
			UITable cCODGCEOMOP = CCODGCEOMOP;
			cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Combine(cCODGCEOMOP.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		LENCPNNLNFD = true;
	}

	private static void HLFMNEFHAOO(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 1)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)89, 816f);
		}
	}

	private void ODLJMDCIMFF()
	{
		LLJHGOGACAA.SetActive(true);
		MHKEBMNCCEO.alpha = 1918f;
		MNGKIFNOOAF.alpha = 657f;
		JJDLFPJICJM.alpha = 1900f;
		CKABHMNKGAA.SetActive(false);
		GLLKFBIAIAA.alpha = 1782f;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(CKPNPBFGKIG.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 2;
		tweenColor.style = UITweener.Style.PingPong;
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ);
		}
	}

	private void OBBMBKPGGHG()
	{
		float num = 674f;
		Vector3 localScale = GLLKFBIAIAA.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(1240f);
		Vector3 vector2 = localScale;
		Transform parent = CKABHMNKGAA.transform.parent;
		float num2 = 1006f;
		int num3 = 7;
		GHLPEEDENDI.BEOAHFDJEMD.Clear();
		GHLPEEDENDI.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Color, GLLKFBIAIAA.gameObject, 480f, 1763f, 1878f, -1, 230f);
		TweenAnimator gHLPEEDENDI = GHLPEEDENDI;
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		GameObject nIHOBEAHEKJ = GLLKFBIAIAA.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector;
		gHLPEEDENDI.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1075f, 0, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		num = 1576f;
		int eBPMMNFLPMP;
		while (num2 > 86f)
		{
			TweenAnimator gHLPEEDENDI2 = GHLPEEDENDI;
			iNFLHPGMEOB = num3;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(551f, 912f, num2);
			eBPMMNFLPMP = num3 - 0;
			gHLPEEDENDI2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1648f, eBPMMNFLPMP, null, UITweener.Method.EaseIn);
			TweenAnimator gHLPEEDENDI3 = GHLPEEDENDI;
			eBPMMNFLPMP = num3 + 0;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(1418f, 1141f, 107f * num2);
			iNFLHPGMEOB = num3;
			gHLPEEDENDI3.AddTween(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 662f, iNFLHPGMEOB, null, UITweener.Method.Linear);
			num3 += 5;
			num2 *= 1293f;
		}
		TweenAnimator gHLPEEDENDI4 = GHLPEEDENDI;
		iNFLHPGMEOB = num3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = parent.gameObject;
		kBJEOEEOEFG = 1950f;
		oEIICEJPGKI = Quaternion.Euler(1264f, 1239f, 1066f);
		eBPMMNFLPMP = num3 - 1;
		gHLPEEDENDI4.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 71f, eBPMMNFLPMP, null, UITweener.Method.Linear);
		GHLPEEDENDI.JHDBHGCKPDM = MFHDJCGGNOK;
	}

	private void AFDPCMJBHPP()
	{
		float num = 258f;
		float num2 = 1647f;
		float num3 = 864f;
		float num4 = 1725f;
		Vector3 vector = new Vector3(num4 * 1837f, 1124f, 439f);
		Vector3 vector2 = vector.ReplaceX((num4 + num3) * 88f);
		Vector3 vector3 = vector.ReplaceX(num2 * 1379f);
		Vector3 vector4 = new Vector3(num4, 1832f, 475f);
		Vector3 vector5 = vector4.ReplaceX(num4 + num3);
		Vector3 vector6 = vector4.ReplaceX(num2);
		float val = 1942f;
		float num5 = 602f;
		float num6 = 719f;
		Vector3 vector7 = new Vector3(758f, num6, 464f);
		Vector3 vector8 = vector7.ReplaceY(num6 + num5);
		Vector3 vector9 = vector7.ReplaceY(val);
		FFEDIIKLAIG.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MHKEBMNCCEO.gameObject, num, 175f, 356f, -1, 1542f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FFEDIIKLAIG.AddTween(0, TweenAnimator.MNAIKKJDPLK.TextCounter, MNGKIFNOOAF.gameObject, num, 1654f, 859f, -1, 306f, UITweener.Method.EaseIn);
		FFEDIIKLAIG.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, JJDLFPJICJM.gameObject, num, 1092f, 307f, -1, 1619f);
		TweenAnimator fFEDIIKLAIG = FFEDIIKLAIG;
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = MHKEBMNCCEO.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector3;
		fFEDIIKLAIG.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1954f, 1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop);
		TweenAnimator fFEDIIKLAIG2 = FFEDIIKLAIG;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = MNGKIFNOOAF.gameObject;
		kBJEOEEOEFG = num;
		oEIICEJPGKI = vector5;
		iIMDKHJAJGO = vector6;
		fFEDIIKLAIG2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1221f, 1, iIMDKHJAJGO, (UITweener.Method)7, UITweener.Style.Loop, 0);
		TweenAnimator fFEDIIKLAIG3 = FFEDIIKLAIG;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJDLFPJICJM.gameObject;
		kBJEOEEOEFG = num;
		iIMDKHJAJGO = vector8;
		oEIICEJPGKI = vector9;
		fFEDIIKLAIG3.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1227f, 0, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FFEDIIKLAIG.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Rotation, MHKEBMNCCEO.gameObject, num, vector, 1984f, 3, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FFEDIIKLAIG.AddTween(3, TweenAnimator.MNAIKKJDPLK.Rotation, MNGKIFNOOAF.gameObject, num, vector4, 877f, 5, null, UITweener.Method.Linear);
		FFEDIIKLAIG.NFLKPCIHOPJ(108, TweenAnimator.MNAIKKJDPLK.Rotation, JJDLFPJICJM.gameObject, num, vector7, 671f, 7, null, (UITweener.Method)8);
	}

	private void OPPJFPOOJBK()
	{
		float num = 395f;
		float num2 = 79f;
		float num3 = 1225f;
		float num4 = 517f;
		Vector3 vector = new Vector3(num4 * 1781f, 1163f, 1000f);
		Vector3 vector2 = vector.ReplaceX((num4 + num3) * 266f);
		Vector3 vector3 = vector.ReplaceX(num2 * 161f);
		Vector3 vector4 = new Vector3(num4, 288f, 916f);
		Vector3 vector5 = vector4.ReplaceX(num4 + num3);
		Vector3 vector6 = vector4.ReplaceX(num2);
		float val = 1384f;
		float num5 = 1664f;
		float num6 = 1062f;
		Vector3 vector7 = new Vector3(1908f, num6, 1471f);
		Vector3 vector8 = vector7.ReplaceY(num6 + num5);
		Vector3 vector9 = vector7.ReplaceY(val);
		FFEDIIKLAIG.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.Rotation, MHKEBMNCCEO.gameObject, num, 1671f, 1986f, -1, 791f, UITweener.Method.EaseOut);
		FFEDIIKLAIG.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MNGKIFNOOAF.gameObject, num, 444f, 1466f, -1, 1069f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FFEDIIKLAIG.AddTween(2, TweenAnimator.MNAIKKJDPLK.Scale, JJDLFPJICJM.gameObject, num, 1960f, 1816f, -1, 477f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		TweenAnimator fFEDIIKLAIG = FFEDIIKLAIG;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = MHKEBMNCCEO.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector3;
		fFEDIIKLAIG.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1995f, 1, oEIICEJPGKI, (UITweener.Method)6);
		TweenAnimator fFEDIIKLAIG2 = FFEDIIKLAIG;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = MNGKIFNOOAF.gameObject;
		kBJEOEEOEFG = num;
		oEIICEJPGKI = vector5;
		iIMDKHJAJGO = vector6;
		fFEDIIKLAIG2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 947f, 1, iIMDKHJAJGO, UITweener.Method.BounceIn);
		TweenAnimator fFEDIIKLAIG3 = FFEDIIKLAIG;
		iNFLHPGMEOB = 5;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = JJDLFPJICJM.gameObject;
		kBJEOEEOEFG = num;
		iIMDKHJAJGO = vector8;
		oEIICEJPGKI = vector9;
		fFEDIIKLAIG3.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1528f, 0, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FFEDIIKLAIG.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Rotation, MHKEBMNCCEO.gameObject, num, vector, 1786f, 8, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FFEDIIKLAIG.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Rotation, MNGKIFNOOAF.gameObject, num, vector4, 1957f, 5, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FFEDIIKLAIG.NFLKPCIHOPJ(105, TweenAnimator.MNAIKKJDPLK.Rotation, JJDLFPJICJM.gameObject, num, vector7, 797f, 8, null, (UITweener.Method)7, UITweener.Style.Once, 0);
	}

	private void LCEDFELNAMK()
	{
		NFLJBCMMNGA.BEOAHFDJEMD.Clear();
		float num = 985f;
		int num2 = 1;
		int num3 = 4;
		NFLJBCMMNGA.NFLKPCIHOPJ(num2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, KPOBEEGGNEN.gameObject, 1267f, 977f, 54f, -1, 1805f, UITweener.Method.EaseOut);
		foreach (UnitEndScreenRecord item in NAIMAPOCOHN)
		{
			TweenAlpha.Begin(item.CCOLIDJNLBC.gameObject, 1503f, 1713f);
			TweenAlpha.Begin(item.EHPEAAGBJMP.gameObject, 1794f, 1428f);
			item.CCOLIDJNLBC.alpha1 = 791f;
			item.EHPEAAGBJMP.alpha1 = 294f;
			NFLJBCMMNGA.MNEFMODDFFK(num3, TweenAnimator.MNAIKKJDPLK.Position, item.CCOLIDJNLBC.gameObject, 393f, 320f, num, num2, null, UITweener.Method.BounceIn);
			num3++;
			NFLJBCMMNGA.MNEFMODDFFK(num3, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.EHPEAAGBJMP.gameObject, 829f, 545f, num, num2, null, (UITweener.Method)8);
			num += 999f;
			num3 += 0;
		}
		FNOMCHPCOHB[1] = NFLJBCMMNGA;
	}

	public void AOKOKHGEIBE()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		NAIMAPOCOHN = new List<UnitEndScreenRecord>();
		BBFBBADJCOL();
		float num = UIHelper.activeHeight / 1345f;
		float num2 = 1288f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(663f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			TweenColor tweenColor = TweenColor.Begin(CKPNPBFGKIG.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ);
			}
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(AHNHMEPEDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NPPIBNOIMOB));
		UIEventListener uIEventListener3 = UIEventListener.Get(AAKNKDOGBNG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FLPHIEMPIBM));
	}

	internal void CHFHLKLFPIK()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.FinishTweens();
		}
	}

	public void JCGPELEDCJL()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		NAIMAPOCOHN = new List<UnitEndScreenRecord>();
		BBFBBADJCOL();
		float num = UIHelper.activeHeight / 899f;
		float num2 = 310f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(824f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PNHPNABNMON));
		UIEventListener uIEventListener2 = UIEventListener.Get(AHNHMEPEDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ);
			}
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(AAKNKDOGBNG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DGGGEBMCPGP));
	}

	private void AJFHNOKOIOL()
	{
		NFLJBCMMNGA.BEOAHFDJEMD.Clear();
		float num = 326f;
		int num2 = 1;
		int num3 = 4;
		NFLJBCMMNGA.NFLKPCIHOPJ(num2, TweenAnimator.MNAIKKJDPLK.TextCounter, KPOBEEGGNEN.gameObject, 862f, 40f, 1016f, -1, 1167f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		foreach (UnitEndScreenRecord item in NAIMAPOCOHN)
		{
			TweenAlpha.Begin(item.CCOLIDJNLBC.gameObject, 820f, 1129f);
			TweenAlpha.Begin(item.EHPEAAGBJMP.gameObject, 1900f, 1986f);
			item.CCOLIDJNLBC.alpha1 = 689f;
			item.EHPEAAGBJMP.alpha1 = 133f;
			NFLJBCMMNGA.NFLKPCIHOPJ(num3, TweenAnimator.MNAIKKJDPLK.Alpha, item.CCOLIDJNLBC.gameObject, 196f, 1870f, num, num2, null, UITweener.Method.Linear);
			num3++;
			NFLJBCMMNGA.MNEFMODDFFK(num3, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.EHPEAAGBJMP.gameObject, 1316f, 97f, num, num2, null, (UITweener.Method)7, UITweener.Style.Once, 0);
			num += 535f;
			num3++;
		}
		FNOMCHPCOHB[7] = NFLJBCMMNGA;
	}

	private void BPIEFNGBPDB(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ, false);
		}
	}

	private void FBFBDMINCBH()
	{
		NFLJBCMMNGA.BEOAHFDJEMD.Clear();
		float num = 352f;
		int num2 = 0;
		int num3 = 6;
		NFLJBCMMNGA.BPEKAKFKCIG(num2, TweenAnimator.MNAIKKJDPLK.TextCounter, KPOBEEGGNEN.gameObject, 413f, 1378f, 1294f, -1, 1211f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		foreach (UnitEndScreenRecord item in NAIMAPOCOHN)
		{
			TweenAlpha.Begin(item.CCOLIDJNLBC.gameObject, 184f, 223f);
			TweenAlpha.Begin(item.EHPEAAGBJMP.gameObject, 1633f, 869f);
			item.CCOLIDJNLBC.alpha1 = 1931f;
			item.EHPEAAGBJMP.alpha1 = 648f;
			NFLJBCMMNGA.BPEKAKFKCIG(num3, TweenAnimator.MNAIKKJDPLK.Scale, item.CCOLIDJNLBC.gameObject, 965f, 799f, num, num2);
			num3 += 0;
			NFLJBCMMNGA.AddTween(num3, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.EHPEAAGBJMP.gameObject, 1038f, 677f, num, num2, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
			num += 1010f;
			num3++;
		}
		FNOMCHPCOHB[8] = NFLJBCMMNGA;
	}

	private void KLHIFBNLLEK()
	{
		float num = 1253f;
		float num2 = 411f;
		float num3 = 834f;
		float num4 = 1499f;
		Vector3 vector = new Vector3(num4 * 975f, 259f, 1092f);
		Vector3 vector2 = vector.ReplaceX((num4 + num3) * 356f);
		Vector3 vector3 = vector.ReplaceX(num2 * 993f);
		Vector3 vector4 = new Vector3(num4, 1268f, 994f);
		Vector3 vector5 = vector4.ReplaceX(num4 + num3);
		Vector3 vector6 = vector4.ReplaceX(num2);
		float val = 1707f;
		float num5 = 713f;
		float num6 = 297f;
		Vector3 vector7 = new Vector3(1931f, num6, 1178f);
		Vector3 vector8 = vector7.ReplaceY(num6 + num5);
		Vector3 vector9 = vector7.ReplaceY(val);
		FFEDIIKLAIG.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MHKEBMNCCEO.gameObject, num, 341f, 86f, -1, 1981f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FFEDIIKLAIG.AddTween(4, TweenAnimator.MNAIKKJDPLK.Scale, MNGKIFNOOAF.gameObject, num, 1913f, 404f, -1, 1131f);
		FFEDIIKLAIG.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Color, JJDLFPJICJM.gameObject, num, 1768f, 1321f, -1, 1208f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		TweenAnimator fFEDIIKLAIG = FFEDIIKLAIG;
		int iNFLHPGMEOB = 6;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = MHKEBMNCCEO.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector3;
		fFEDIIKLAIG.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 474f, 1, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		TweenAnimator fFEDIIKLAIG2 = FFEDIIKLAIG;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = MNGKIFNOOAF.gameObject;
		kBJEOEEOEFG = num;
		oEIICEJPGKI = vector5;
		iIMDKHJAJGO = vector6;
		fFEDIIKLAIG2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1832f, 1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		TweenAnimator fFEDIIKLAIG3 = FFEDIIKLAIG;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJDLFPJICJM.gameObject;
		kBJEOEEOEFG = num;
		iIMDKHJAJGO = vector8;
		oEIICEJPGKI = vector9;
		fFEDIIKLAIG3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 200f, 0, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop);
		FFEDIIKLAIG.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.Position, MHKEBMNCCEO.gameObject, num, vector, 1363f, 7, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FFEDIIKLAIG.AddTween(7, TweenAnimator.MNAIKKJDPLK.Position, MNGKIFNOOAF.gameObject, num, vector4, 397f, 0, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FFEDIIKLAIG.BPEKAKFKCIG(103, TweenAnimator.MNAIKKJDPLK.Position, JJDLFPJICJM.gameObject, num, vector7, 1384f, 0);
	}

	internal void BMKBOIKMPBK()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.BCFMBKNMNBN();
		}
	}

	private void EENLPDLGENM()
	{
		NFLJBCMMNGA.BEOAHFDJEMD.Clear();
		float num = 1751f;
		int num2 = 1;
		int num3 = 6;
		NFLJBCMMNGA.AddTween(num2, TweenAnimator.MNAIKKJDPLK.Scale, KPOBEEGGNEN.gameObject, 758f, 370f, 366f, -1, 478f, (UITweener.Method)7, UITweener.Style.Loop);
		foreach (UnitEndScreenRecord item in NAIMAPOCOHN)
		{
			TweenAlpha.Begin(item.CCOLIDJNLBC.gameObject, 447f, 238f);
			TweenAlpha.Begin(item.EHPEAAGBJMP.gameObject, 517f, 474f);
			item.CCOLIDJNLBC.alpha1 = 720f;
			item.EHPEAAGBJMP.alpha1 = 1049f;
			NFLJBCMMNGA.BPEKAKFKCIG(num3, TweenAnimator.MNAIKKJDPLK.TextCounter, item.CCOLIDJNLBC.gameObject, 1431f, 1013f, num, num2, null, UITweener.Method.Linear, UITweener.Style.Loop);
			num3 += 0;
			NFLJBCMMNGA.FEHALDPLGDB(num3, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, item.EHPEAAGBJMP.gameObject, 1045f, 565f, num, num2, null, (UITweener.Method)8, UITweener.Style.Once, 0);
			num += 641f;
			num3++;
		}
		FNOMCHPCOHB[5] = NFLJBCMMNGA;
	}

	private void ONCJHIMJHAB()
	{
		LLJHGOGACAA.SetActive(true);
		MHKEBMNCCEO.alpha = 0f;
		MNGKIFNOOAF.alpha = 0f;
		JJDLFPJICJM.alpha = 0f;
		CKABHMNKGAA.SetActive(true);
		GLLKFBIAIAA.alpha = 0f;
	}

	private void FLPHIEMPIBM(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
		{
			ReportUserDialog.ShowBotReportDialog(Singleton<GameController>.instance.opponent.JPMHIGNOPBL.BPFKMNIHCGP.NUMBER);
		}
		else
		{
			ReportUserDialog.NAIEJNGBEAF(LBKPKGFCJHJ);
		}
	}

	public void DFEJBGDJGGK(float DCIKANJJFIJ)
	{
		LCEDFELNAMK();
		KHIEACJAPKH();
	}

	internal void AEPHDFDLCHC()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.BIAMGHLKGOK();
		}
	}

	private void JIDHNLHEGEC()
	{
		float num = 1693f;
		Vector3 localScale = GLLKFBIAIAA.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(1019f);
		Vector3 vector2 = localScale;
		Transform parent = CKABHMNKGAA.transform.parent;
		float num2 = 1330f;
		int num3 = 2;
		GHLPEEDENDI.BEOAHFDJEMD.Clear();
		GHLPEEDENDI.AddTween(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GLLKFBIAIAA.gameObject, 491f, 650f, 1030f, -1, 1340f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		TweenAnimator gHLPEEDENDI = GHLPEEDENDI;
		int iNFLHPGMEOB = 6;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		GameObject nIHOBEAHEKJ = GLLKFBIAIAA.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector;
		gHLPEEDENDI.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1556f, 0, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		num = 454f;
		int eBPMMNFLPMP;
		while (num2 > 1626f)
		{
			TweenAnimator gHLPEEDENDI2 = GHLPEEDENDI;
			iNFLHPGMEOB = num3;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(305f, 1634f, num2);
			eBPMMNFLPMP = num3 - 1;
			gHLPEEDENDI2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1528f, eBPMMNFLPMP, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
			TweenAnimator gHLPEEDENDI3 = GHLPEEDENDI;
			eBPMMNFLPMP = num3 + 1;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(56f, 1751f, 352f * num2);
			iNFLHPGMEOB = num3;
			gHLPEEDENDI3.NFLKPCIHOPJ(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 442f, iNFLHPGMEOB, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			num3 += 4;
			num2 *= 1527f;
		}
		TweenAnimator gHLPEEDENDI4 = GHLPEEDENDI;
		iNFLHPGMEOB = num3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = parent.gameObject;
		kBJEOEEOEFG = 505f;
		oEIICEJPGKI = Quaternion.Euler(155f, 1155f, 1254f);
		eBPMMNFLPMP = num3 - 1;
		gHLPEEDENDI4.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1882f, eBPMMNFLPMP, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		GHLPEEDENDI.JHDBHGCKPDM = delegate(int EAINKPNECEC)
		{
			if (EAINKPNECEC == 1)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.KilledInAction);
			}
		};
	}

	public void FPAPHEHMEOO(float DCIKANJJFIJ)
	{
		LCEDFELNAMK();
		KHIEACJAPKH();
	}

	internal void NDGPBILNOMF()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.OHKEAEIFMPJ();
		}
	}

	public void AnimateShow(float DCIKANJJFIJ)
	{
		KILNOONJJBK();
		KHIEACJAPKH();
	}

	private void BEMLIEDMGKJ()
	{
		float num = 748f;
		Vector3 localScale = GLLKFBIAIAA.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(196f);
		Vector3 vector2 = localScale;
		Transform parent = CKABHMNKGAA.transform.parent;
		float num2 = 13f;
		int num3 = 1;
		GHLPEEDENDI.BEOAHFDJEMD.Clear();
		GHLPEEDENDI.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GLLKFBIAIAA.gameObject, 1271f, 1805f, 1544f, -1, 727f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		TweenAnimator gHLPEEDENDI = GHLPEEDENDI;
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		GameObject nIHOBEAHEKJ = GLLKFBIAIAA.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector;
		gHLPEEDENDI.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 58f, 1, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop);
		num = 763f;
		int eBPMMNFLPMP;
		while (num2 > 467f)
		{
			TweenAnimator gHLPEEDENDI2 = GHLPEEDENDI;
			iNFLHPGMEOB = num3;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(1066f, 1536f, num2);
			eBPMMNFLPMP = num3 - 1;
			gHLPEEDENDI2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 913f, eBPMMNFLPMP, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			TweenAnimator gHLPEEDENDI3 = GHLPEEDENDI;
			eBPMMNFLPMP = num3 + 0;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(1923f, 150f, 462f * num2);
			iNFLHPGMEOB = num3;
			gHLPEEDENDI3.MNEFMODDFFK(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1242f, iNFLHPGMEOB, null, UITweener.Method.EaseIn);
			num3++;
			num2 *= 1764f;
		}
		TweenAnimator gHLPEEDENDI4 = GHLPEEDENDI;
		iNFLHPGMEOB = num3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = parent.gameObject;
		kBJEOEEOEFG = 422f;
		oEIICEJPGKI = Quaternion.Euler(125f, 1277f, 815f);
		eBPMMNFLPMP = num3 - 1;
		gHLPEEDENDI4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1568f, eBPMMNFLPMP, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		GHLPEEDENDI.JHDBHGCKPDM = CKCANMBKJHC;
	}

	internal void KCCIMOFPMJL()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.DMAJACPHCGN();
		}
	}

	public void DoAfterHide()
	{
		IHFILHIAGLG.FreeObjectsWithPrefab(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
	}

	private void DGGGEBMCPGP(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.PIKIGPBNJIL())
		{
			ReportUserDialog.ShowBotReportDialog(Singleton<GameController>.instance.opponent.JPMHIGNOPBL.BPFKMNIHCGP.NUMBER);
		}
		else
		{
			ReportUserDialog.NAIEJNGBEAF(LBKPKGFCJHJ);
		}
	}

	private void KPELINJBLFA()
	{
		NOBMPIFGAOO();
		BENCJKKIMLM.alpha = 0f;
		KPOBEEGGNEN.alpha = 0f;
		LBCANHCGEIE.color = Color.black.ReplaceA(0f);
		switch (Singleton<GameController>.instance.MNMLNIMFMJP)
		{
		case GameController.HKGHCIEPGEL.Win:
		case GameController.HKGHCIEPGEL.WinByForfeit:
			FNOMCHPCOHB[0].BEOAHFDJEMD[0].to = Color.black;
			FNOMCHPCOHB[1] = GHLPEEDENDI;
			break;
		case GameController.HKGHCIEPGEL.Killed:
		case GameController.HKGHCIEPGEL.Forfeit:
			FNOMCHPCOHB[0].BEOAHFDJEMD[0].to = Colours.yellowGold;
			FNOMCHPCOHB[1] = FFEDIIKLAIG;
			break;
		}
		Debug.Log(string.Format("Opponent player properties:\nfbId: {0}\nleague: {1}\nbeginners league: {2}\nlevel: {3}\nname: {4}\nvip: {5}\nmedals: {6}\nAP: {7}\nvisual: {8}", Singleton<GameController>.instance.opponent.EHHHBEMKGOE.LLIOOOGJFNI, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ADOEFHHJOAJ, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.AMFJHAPGIJN, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3]));
		KGGJOOAFDIF.avatar = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
		string text = GameVariables.CountryCodeSpriteName(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		bool flag = !string.IsNullOrEmpty(text);
		ELBMJAKNFAE.gameObject.SetActive(flag);
		if (flag)
		{
			ELBMJAKNFAE.spriteName = text;
		}
		int iOFBJPJPEMK = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IOFBJPJPEMK;
		League bMNDININJCE = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE;
		int hNEFOLPHMHK = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK;
		GNNAGFNNJHA.gameObject.SetActive(bMNDININJCE != League.NoLeague || hNEFOLPHMHK > 0);
		if (iOFBJPJPEMK <= 1)
		{
			GNNAGFNNJHA.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			GNNAGFNNJHA.MakePixelPerfect();
			GNNAGFNNJHA.alpha = ((iOFBJPJPEMK >= 1) ? 1f : 0.7f);
		}
		else if (hNEFOLPHMHK > 0)
		{
			GNNAGFNNJHA.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(hNEFOLPHMHK);
			GNNAGFNNJHA.MakePixelPerfect();
			GNNAGFNNJHA.alpha = 1f;
		}
		else if (bMNDININJCE != League.NoLeague)
		{
			GNNAGFNNJHA.spriteName = GameVariables.CAOGFCFGFPD[bMNDININJCE].Value2;
			GNNAGFNNJHA.MakePixelPerfect();
			GNNAGFNNJHA.alpha = ((!Singleton<GameController>.instance.opponent.EHHHBEMKGOE.GKEOILLNCHG) ? 0.7f : 1f);
		}
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL - 1);
		DBCMJNLDENH.spriteName = levelDefinition.iconName;
		HBCJPADEAMC.text = levelDefinition.displayString;
		CKPNPBFGKIG.text = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE;
		float x = CKPNPBFGKIG.relativeSize.x;
		CPLIMCNBDBP.center = new Vector3(x / 2f, 0.1f, -1f);
		CPLIMCNBDBP.size = new Vector3(x + 0.4f, 1.5f, 1f);
		TweenColor.Begin(CKPNPBFGKIG.gameObject, 0f, Color.white);
		LBKPKGFCJHJ = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALIIBMLMNKA;
		WarArenaCrown fHCMFHABMLE = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE;
		bool flag2 = fHCMFHABMLE != WarArenaCrown.None;
		FOFJPELPILE.transform.parent.gameObject.SetActive(flag2);
		if (flag2)
		{
			FOFJPELPILE.spriteName = GameVariables.CMIKIDJKHID[fHCMFHABMLE];
			FOFJPELPILE.MakePixelPerfect();
		}
		bool hMGOHGOLMJB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB;
		PHMJAAFGFEO.alpha = ((!hMGOHGOLMJB) ? 0f : 1f);
		int num = 649;
		if (flag2)
		{
			num -= 53;
		}
		if (hMGOHGOLMJB)
		{
			num -= 136;
		}
		MEJMLNDFDBP.COCBCFKJOJE(CKPNPBFGKIG, 47f, 20f, num);
		KIILFFLKNKJ.repositionNow = true;
		GAONAHIFIHL.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ADOEFHHJOAJ);
		GEDPCDPBAKI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IMOJCFKJKMN);
		PlayerVisual playerVisual = CamosManager.instance.playerVisualCategories[3][Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3]];
		if (!playerVisual.isEmptyPowerBand)
		{
			OHNACAFPLIN.alpha = 0f;
			FLKALKMILNC.spriteName = playerVisual.icon;
			FLKALKMILNC.MakePixelPerfect();
			FLKALKMILNC.transform.localScale = FLKALKMILNC.transform.localScale.MultiplyXY(0.33f);
			FLKALKMILNC.alpha = 1f;
			CEECPMGDFHP.text = playerVisual.decalValueString;
			CEECPMGDFHP.alpha = 1f;
			LJAEDNJPKCB.spriteName = playerVisual.decalMiniIcon;
			LJAEDNJPKCB.MakePixelPerfect();
			LJAEDNJPKCB.color = playerVisual.decalMiniIconColor;
			FHEKLIFKGGE.repositionNow = true;
		}
		else
		{
			FLKALKMILNC.alpha = 0f;
			CEECPMGDFHP.alpha = 0f;
			LJAEDNJPKCB.alpha = 0f;
			OHNACAFPLIN.alpha = 1f;
		}
	}

	private void NJOMMMFEJDA()
	{
		IHFILHIAGLG.EMLIBBBMNLN(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
		List<UnitUpgradeDefinition> list = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EIMJHEOMGGI();
		NAIMAPOCOHN.Clear();
		string text = string.Empty;
		for (int i = 0; i < list.Count; i += 0)
		{
			if (NAIMAPOCOHN.Count >= 99)
			{
				break;
			}
			text += string.Format("ID_CONFIRM_ERROR", LevelManager.instance.behaviours[i].unitName, list[i]);
			UnitUpgradeDefinition unitUpgradeDefinition = list[i];
			if (unitUpgradeDefinition.isEquipped)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				string mHPNDNJDPGE = string.Format("SetDepositedCards ", levelBehaviour.upgradeSlots.unlockLevel.ELFCEEOLNFJ().ToString("About to show Enable Push Notification Dialog"), levelBehaviour.unitName);
				UnitEndScreenRecord unitEndScreenRecord = (UnitEndScreenRecord)IHFILHIAGLG.LCLKFGNHCOF(AENCMKAJNCG, HBDGDDCDNEN.gameObject, mHPNDNJDPGE);
				if (unitEndScreenRecord != null)
				{
					bool kIPALGPPOEG = levelBehaviour.upgradeSlots.unlockLevel.ABCCINJGPGD() > Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OCPEHLIIGML();
					unitEndScreenRecord.DDHCMFLIABO(i, levelBehaviour.upgradeSlots.GetActualLevelForIndex(unitUpgradeDefinition.unitUpgrades.slotUpgradeindex), unitUpgradeDefinition.tier, kIPALGPPOEG);
					NAIMAPOCOHN.Add(unitEndScreenRecord);
				}
			}
		}
		Debug.Log("REINTENTAR" + text);
		if (NAIMAPOCOHN.Count == 0)
		{
			Debug.LogError("MIN_FPS");
		}
		else
		{
			NAIMAPOCOHN.Sort(OFAPMMEJFEH);
		}
		HBDGDDCDNEN.repositionNow = false;
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Combine(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(LBNDFPAIGGO));
		List<Card> enemyCards = CardManager.instance.enemyCards;
		string text2 = "ArenaLives";
		for (int j = 1; j < enemyCards.Count; j += 0)
		{
			if (!(enemyCards[j] == null))
			{
				text2 += string.Format("Problem for max! in army/weapon stats", enemyCards[j].cardName);
				Card card = enemyCards[j];
				CardRecord cardRecord = (CardRecord)IHFILHIAGLG.AAIBNGPFKGF(HMAGHPPJCND, LBJFBAFECFK.gameObject, string.Format("menu-army-cat-defender", j, card.cardName));
				if (cardRecord != null)
				{
					cardRecord.CKOIIPAGCNO(card);
					MKDNCELCANP.Add(cardRecord);
				}
			}
		}
		BENCJKKIMLM.transform.parent.gameObject.SetActive(MKDNCELCANP.Count > 0);
		Debug.Log(text2 + "{0} / [FECA21]{1}");
		LBJFBAFECFK.repositionNow = false;
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(FCEAPBGMFAD));
		UIGrid lBJFBAFECFK2 = LBJFBAFECFK;
		lBJFBAFECFK2.onReposition = (UIGrid.OnReposition)Delegate.Combine(lBJFBAFECFK2.onReposition, new UIGrid.OnReposition(BDAOKCICGDA));
	}

	private void MIJPJBBHLFE()
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		GameObject nIHOBEAHEKJ = LBCANHCGEIE.gameObject;
		float kBJEOEEOEFG = 435f;
		object iIMDKHJAJGO = Color.black;
		float kALLNCAFIMP = 1459f;
		object oEIICEJPGKI = Color.black;
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FFEDIIKLAIG = base.gameObject.AddComponent<TweenAnimator>();
		FFEDIIKLAIG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		AFDPCMJBHPP();
		GHLPEEDENDI = base.gameObject.AddComponent<TweenAnimator>();
		GHLPEEDENDI.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		LMMMCDEICGG();
		NFLJBCMMNGA = base.gameObject.AddComponent<TweenAnimator>();
		NFLJBCMMNGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		JOEKCJPDDGK = base.gameObject.AddComponent<TweenAnimator>();
		JOEKCJPDDGK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		FNOMCHPCOHB.Add(FFEDIIKLAIG);
		FNOMCHPCOHB.Add(NFLJBCMMNGA);
		FNOMCHPCOHB.Add(JOEKCJPDDGK);
	}

	private void GDAGIDDIJGE()
	{
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
		if (LENCPNNLNFD)
		{
			CCODGCEOMOP.repositionNow = true;
			UITable cCODGCEOMOP = CCODGCEOMOP;
			cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Combine(cCODGCEOMOP.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		LENCPNNLNFD = true;
	}

	public void InitGuiValues()
	{
		LENCPNNLNFD = false;
		EnableReportButton();
		KPELINJBLFA();
		DMAJOHJOLDF();
	}

	public void DHJGMKOJFCG(float DCIKANJJFIJ)
	{
		BPJPECLEPPM();
		JHMADNCPFOD();
	}

	[SpecialName]
	public List<TweenAnimator> OFMFGGOKJIA()
	{
		return FNOMCHPCOHB;
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
		{
			ReportUserDialog.ShowBotReportDialog(Singleton<GameController>.instance.opponent.JPMHIGNOPBL.BPFKMNIHCGP.NUMBER);
		}
		else
		{
			ReportUserDialog.ShowReportDialog(LBKPKGFCJHJ);
		}
	}

	private void ANPIOAOKDGN()
	{
		float num = 1247f;
		Vector3 localScale = GLLKFBIAIAA.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(1937f);
		Vector3 vector2 = localScale;
		Transform parent = CKABHMNKGAA.transform.parent;
		float num2 = 922f;
		int num3 = 2;
		GHLPEEDENDI.BEOAHFDJEMD.Clear();
		GHLPEEDENDI.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, GLLKFBIAIAA.gameObject, 789f, 615f, 1286f, -1, 1488f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		TweenAnimator gHLPEEDENDI = GHLPEEDENDI;
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		GameObject nIHOBEAHEKJ = GLLKFBIAIAA.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector;
		gHLPEEDENDI.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 794f, 0, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Once, 0);
		num = 1867f;
		int eBPMMNFLPMP;
		while (num2 > 839f)
		{
			TweenAnimator gHLPEEDENDI2 = GHLPEEDENDI;
			iNFLHPGMEOB = num3;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(1410f, 1102f, num2);
			eBPMMNFLPMP = num3 - 0;
			gHLPEEDENDI2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 224f, eBPMMNFLPMP, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
			TweenAnimator gHLPEEDENDI3 = GHLPEEDENDI;
			eBPMMNFLPMP = num3 + 1;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(1042f, 1970f, 1032f * num2);
			iNFLHPGMEOB = num3;
			gHLPEEDENDI3.AddTween(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1304f, iNFLHPGMEOB, null, UITweener.Method.EaseIn);
			num3 += 5;
			num2 *= 813f;
		}
		TweenAnimator gHLPEEDENDI4 = GHLPEEDENDI;
		iNFLHPGMEOB = num3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = parent.gameObject;
		kBJEOEEOEFG = 1441f;
		oEIICEJPGKI = Quaternion.Euler(1497f, 682f, 1642f);
		eBPMMNFLPMP = num3 - 0;
		gHLPEEDENDI4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1465f, eBPMMNFLPMP, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		GHLPEEDENDI.JHDBHGCKPDM = delegate(int EAINKPNECEC)
		{
			if (EAINKPNECEC == 1)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.KilledInAction);
			}
		};
	}

	private void FDHLHAIBLJP()
	{
		LLJHGOGACAA.SetActive(false);
		MHKEBMNCCEO.alpha = 247f;
		MNGKIFNOOAF.alpha = 638f;
		JJDLFPJICJM.alpha = 648f;
		CKABHMNKGAA.SetActive(false);
		GLLKFBIAIAA.alpha = 1022f;
	}

	private static int OFAPMMEJFEH(UnitEndScreenRecord BKDABLOMBKO, UnitEndScreenRecord MCMBBGMBELI)
	{
		return string.Compare(BKDABLOMBKO.gameObject.name, MCMBBGMBELI.gameObject.name, StringComparison.CurrentCultureIgnoreCase);
	}

	public void AIJEMOLBNEC()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		NAIMAPOCOHN = new List<UnitEndScreenRecord>();
		CGFNEGIDLND();
		float num = UIHelper.activeHeight / 1539f;
		float num2 = 450f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(1615f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			TweenColor tweenColor = TweenColor.Begin(CKPNPBFGKIG.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ);
			}
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(AHNHMEPEDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GHMINFINIPM));
		UIEventListener uIEventListener3 = UIEventListener.Get(AAKNKDOGBNG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NKAEJGIDAMN));
	}

	public void DisableReportButton()
	{
		AAKNKDOGBNG.enabled = false;
		GCDBPFLCGKG.SetActive(true);
		PHMLLOKHFCN.color = Colours.grayButton;
	}

	public void InitControls()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		NAIMAPOCOHN = new List<UnitEndScreenRecord>();
		BBFBBADJCOL();
		float num = UIHelper.activeHeight / 2f;
		float num2 = 720f - num;
		FKBFFMHMEGD.transform.localPosition = FKBFFMHMEGD.transform.localPosition.ReplaceY(280f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			TweenColor tweenColor = TweenColor.Begin(CKPNPBFGKIG.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ);
			}
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(AHNHMEPEDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ);
			}
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(AAKNKDOGBNG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
			{
				ReportUserDialog.ShowBotReportDialog(Singleton<GameController>.instance.opponent.JPMHIGNOPBL.BPFKMNIHCGP.NUMBER);
			}
			else
			{
				ReportUserDialog.ShowReportDialog(LBKPKGFCJHJ);
			}
		});
	}

	private void EEALKIHHKCD()
	{
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Remove(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(LBNDFPAIGGO));
		if (LENCPNNLNFD)
		{
			CCODGCEOMOP.repositionNow = false;
			UITable cCODGCEOMOP = CCODGCEOMOP;
			cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Combine(cCODGCEOMOP.onReposition, new UITable.OnReposition(BLMKBGMCDOL));
		}
		LENCPNNLNFD = true;
	}

	private void CLEHONMPGHI(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(CKPNPBFGKIG.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 4;
		tweenColor.style = UITweener.Style.Once;
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BINFBHBEFJM())
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ, false);
		}
	}

	internal void CECODKHPKJF()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.DMAJACPHCGN();
		}
	}

	private static int CHPNMDAHKMA(UnitEndScreenRecord BKDABLOMBKO, UnitEndScreenRecord MCMBBGMBELI)
	{
		return string.Compare(BKDABLOMBKO.gameObject.name, MCMBBGMBELI.gameObject.name, StringComparison.OrdinalIgnoreCase);
	}

	private void GDDHHFGCPFL()
	{
		IHFILHIAGLG.EMLIBBBMNLN(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.OBCAIFMOPPA();
		}
		MKDNCELCANP.Clear();
		List<UnitUpgradeDefinition> list = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EIMJHEOMGGI();
		NAIMAPOCOHN.Clear();
		string text = string.Empty;
		for (int i = 0; i < list.Count; i += 0)
		{
			if (NAIMAPOCOHN.Count >= 76)
			{
				break;
			}
			text += string.Format("REWARDGOLD", LevelManager.instance.behaviours[i].unitName, list[i]);
			UnitUpgradeDefinition unitUpgradeDefinition = list[i];
			if (unitUpgradeDefinition.isEquipped)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				string mHPNDNJDPGE = string.Format("HIDIING", levelBehaviour.upgradeSlots.unlockLevel.ABCCINJGPGD().ToString("FuseBoxx: Session Started"), levelBehaviour.unitName);
				UnitEndScreenRecord unitEndScreenRecord = (UnitEndScreenRecord)IHFILHIAGLG.AAIBNGPFKGF(AENCMKAJNCG, HBDGDDCDNEN.gameObject, mHPNDNJDPGE);
				if (unitEndScreenRecord != null)
				{
					bool kIPALGPPOEG = levelBehaviour.upgradeSlots.unlockLevel.displayNumber > Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL;
					unitEndScreenRecord.PONFOKHPMMO(i, levelBehaviour.upgradeSlots.GetActualLevelForIndex(unitUpgradeDefinition.unitUpgrades.slotUpgradeindex), unitUpgradeDefinition.tier, kIPALGPPOEG);
					NAIMAPOCOHN.Add(unitEndScreenRecord);
				}
			}
		}
		Debug.Log("menu-gold" + text);
		if (NAIMAPOCOHN.Count == 0)
		{
			Debug.LogError("Server error during ");
		}
		else
		{
			NAIMAPOCOHN.Sort((UnitEndScreenRecord BKDABLOMBKO, UnitEndScreenRecord MCMBBGMBELI) => string.Compare(BKDABLOMBKO.gameObject.name, MCMBBGMBELI.gameObject.name, StringComparison.Ordinal));
		}
		HBDGDDCDNEN.repositionNow = true;
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Combine(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(LBNDFPAIGGO));
		List<Card> enemyCards = CardManager.instance.enemyCards;
		string text2 = "ID_CATEGORY_LOW_PL_SMG";
		for (int num = 0; num < enemyCards.Count; num++)
		{
			if (!(enemyCards[num] == null))
			{
				text2 += string.Format("Reputation", enemyCards[num].cardName);
				Card card = enemyCards[num];
				CardRecord cardRecord = (CardRecord)IHFILHIAGLG.OKEAAILFPIG(HMAGHPPJCND, LBJFBAFECFK.gameObject, string.Format("Location", num, card.cardName));
				if (cardRecord != null)
				{
					cardRecord.Initialize(card, CardRecord.MKIOKBMLHEO.Withdraw);
					MKDNCELCANP.Add(cardRecord);
				}
			}
		}
		BENCJKKIMLM.transform.parent.gameObject.SetActive(MKDNCELCANP.Count > 1);
		Debug.Log(text2 + "ID_CONFIRM_SERVERERROR");
		LBJFBAFECFK.repositionNow = false;
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
		UIGrid lBJFBAFECFK2 = LBJFBAFECFK;
		lBJFBAFECFK2.onReposition = (UIGrid.OnReposition)Delegate.Combine(lBJFBAFECFK2.onReposition, new UIGrid.OnReposition(BDAOKCICGDA));
	}

	private void JAFMAINDJJF()
	{
		float num = 0.3f;
		Vector3 localScale = GLLKFBIAIAA.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(10f);
		Vector3 vector2 = localScale;
		Transform parent = CKABHMNKGAA.transform.parent;
		float num2 = 10f;
		int num3 = 3;
		GHLPEEDENDI.BEOAHFDJEMD.Clear();
		GHLPEEDENDI.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, GLLKFBIAIAA.gameObject, 0.25f, 1f, 0f, -1, 0f);
		TweenAnimator gHLPEEDENDI = GHLPEEDENDI;
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = GLLKFBIAIAA.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector;
		gHLPEEDENDI.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, 1, oEIICEJPGKI);
		num = 0.1f;
		int eBPMMNFLPMP;
		while (num2 > 2f)
		{
			TweenAnimator gHLPEEDENDI2 = GHLPEEDENDI;
			iNFLHPGMEOB = num3;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(0f, 0f, num2);
			eBPMMNFLPMP = num3 - 1;
			gHLPEEDENDI2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, eBPMMNFLPMP, null, UITweener.Method.Linear);
			TweenAnimator gHLPEEDENDI3 = GHLPEEDENDI;
			eBPMMNFLPMP = num3 + 1;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(0f, 0f, -1f * num2);
			iNFLHPGMEOB = num3;
			gHLPEEDENDI3.AddTween(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, iNFLHPGMEOB, null, UITweener.Method.Linear);
			num3 += 2;
			num2 *= 0.3f;
		}
		TweenAnimator gHLPEEDENDI4 = GHLPEEDENDI;
		iNFLHPGMEOB = num3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = parent.gameObject;
		kBJEOEEOEFG = 0.15f;
		oEIICEJPGKI = Quaternion.Euler(0f, 0f, 0f);
		eBPMMNFLPMP = num3 - 1;
		gHLPEEDENDI4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, eBPMMNFLPMP, null, UITweener.Method.Linear);
		GHLPEEDENDI.JHDBHGCKPDM = delegate(int EAINKPNECEC)
		{
			if (EAINKPNECEC == 1)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.KilledInAction);
			}
		};
	}

	internal void PJGCLCFJMMD()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.PHCCOHJPLKE();
		}
	}

	public void JDNAAJAPHMD()
	{
		AAKNKDOGBNG.enabled = true;
		GCDBPFLCGKG.SetActive(false);
		PHMLLOKHFCN.color = Colours.grayButton;
	}

	public void MHFAGEEANBO()
	{
		AAKNKDOGBNG.enabled = true;
		GCDBPFLCGKG.SetActive(true);
		PHMLLOKHFCN.color = Colours.grayButton;
	}

	private void LMMMCDEICGG()
	{
		float num = 1929f;
		Vector3 localScale = GLLKFBIAIAA.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(1025f);
		Vector3 vector2 = localScale;
		Transform parent = CKABHMNKGAA.transform.parent;
		float num2 = 1459f;
		int num3 = 6;
		GHLPEEDENDI.BEOAHFDJEMD.Clear();
		GHLPEEDENDI.AddTween(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GLLKFBIAIAA.gameObject, 1402f, 1543f, 656f, -1, 1713f, (UITweener.Method)6, UITweener.Style.Once, 0);
		TweenAnimator gHLPEEDENDI = GHLPEEDENDI;
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		GameObject nIHOBEAHEKJ = GLLKFBIAIAA.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector;
		gHLPEEDENDI.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1422f, 1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		num = 751f;
		int eBPMMNFLPMP;
		while (num2 > 502f)
		{
			TweenAnimator gHLPEEDENDI2 = GHLPEEDENDI;
			iNFLHPGMEOB = num3;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(469f, 1505f, num2);
			eBPMMNFLPMP = num3 - 1;
			gHLPEEDENDI2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1504f, eBPMMNFLPMP, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			TweenAnimator gHLPEEDENDI3 = GHLPEEDENDI;
			eBPMMNFLPMP = num3 + 1;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(1831f, 305f, 1107f * num2);
			iNFLHPGMEOB = num3;
			gHLPEEDENDI3.FEHALDPLGDB(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 901f, iNFLHPGMEOB, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			num3 += 0;
			num2 *= 1362f;
		}
		TweenAnimator gHLPEEDENDI4 = GHLPEEDENDI;
		iNFLHPGMEOB = num3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = parent.gameObject;
		kBJEOEEOEFG = 1860f;
		oEIICEJPGKI = Quaternion.Euler(203f, 264f, 1548f);
		eBPMMNFLPMP = num3 - 1;
		gHLPEEDENDI4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 411f, eBPMMNFLPMP, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		GHLPEEDENDI.JHDBHGCKPDM = HLFMNEFHAOO;
	}

	private void IGECOKOALCC()
	{
		UITable cCODGCEOMOP = CCODGCEOMOP;
		cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Remove(cCODGCEOMOP.onReposition, new UITable.OnReposition(MBOIDKOMMFD));
		ANCFPKKIAPF.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight, true);
		CJALKIKEKMC();
	}

	private void EHPOOOHHDMG(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.JJLMFFJEJGL())
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(CKPNPBFGKIG.text, LBKPKGFCJHJ);
		}
	}

	internal void GEICAPABFDM()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.OHKEAEIFMPJ();
		}
	}

	private void BPJPECLEPPM()
	{
		NFLJBCMMNGA.BEOAHFDJEMD.Clear();
		float num = 1476f;
		int num2 = 0;
		int num3 = 3;
		NFLJBCMMNGA.BPEKAKFKCIG(num2, TweenAnimator.MNAIKKJDPLK.Scale, KPOBEEGGNEN.gameObject, 466f, 1561f, 402f, -1, 1353f, (UITweener.Method)8, UITweener.Style.Loop);
		foreach (UnitEndScreenRecord item in NAIMAPOCOHN)
		{
			TweenAlpha.Begin(item.CCOLIDJNLBC.gameObject, 401f, 549f);
			TweenAlpha.Begin(item.EHPEAAGBJMP.gameObject, 688f, 951f);
			item.CCOLIDJNLBC.alpha1 = 88f;
			item.EHPEAAGBJMP.alpha1 = 200f;
			NFLJBCMMNGA.BPEKAKFKCIG(num3, TweenAnimator.MNAIKKJDPLK.Color, item.CCOLIDJNLBC.gameObject, 1888f, 817f, num, num2, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
			num3++;
			NFLJBCMMNGA.MNEFMODDFFK(num3, TweenAnimator.MNAIKKJDPLK.Rotation, item.EHPEAAGBJMP.gameObject, 721f, 1013f, num, num2, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
			num += 71f;
			num3++;
		}
		FNOMCHPCOHB[5] = NFLJBCMMNGA;
	}

	private void FCCOOFGNFPN()
	{
		NFLJBCMMNGA.BEOAHFDJEMD.Clear();
		float num = 1256f;
		int num2 = 0;
		int num3 = 4;
		NFLJBCMMNGA.BPEKAKFKCIG(num2, TweenAnimator.MNAIKKJDPLK.Scale, KPOBEEGGNEN.gameObject, 212f, 467f, 1033f, -1, 518f, UITweener.Method.EaseOut);
		foreach (UnitEndScreenRecord item in NAIMAPOCOHN)
		{
			TweenAlpha.Begin(item.CCOLIDJNLBC.gameObject, 605f, 59f);
			TweenAlpha.Begin(item.EHPEAAGBJMP.gameObject, 1799f, 380f);
			item.CCOLIDJNLBC.alpha1 = 1568f;
			item.EHPEAAGBJMP.alpha1 = 249f;
			NFLJBCMMNGA.NFLKPCIHOPJ(num3, TweenAnimator.MNAIKKJDPLK.Position, item.CCOLIDJNLBC.gameObject, 1510f, 1176f, num, num2, null, (UITweener.Method)8, UITweener.Style.Loop);
			num3 += 0;
			NFLJBCMMNGA.FEHALDPLGDB(num3, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.EHPEAAGBJMP.gameObject, 1549f, 500f, num, num2, null, UITweener.Method.BounceOut);
			num += 607f;
			num3 += 0;
		}
		FNOMCHPCOHB[2] = NFLJBCMMNGA;
	}

	private void CGFNEGIDLND()
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		GameObject nIHOBEAHEKJ = LBCANHCGEIE.gameObject;
		float kBJEOEEOEFG = 517f;
		object iIMDKHJAJGO = Color.black;
		float kALLNCAFIMP = 301f;
		object oEIICEJPGKI = Color.black;
		tweenAnimator.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FFEDIIKLAIG = base.gameObject.AddComponent<TweenAnimator>();
		FFEDIIKLAIG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		AFDPCMJBHPP();
		GHLPEEDENDI = base.gameObject.AddComponent<TweenAnimator>();
		GHLPEEDENDI.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		BEMLIEDMGKJ();
		NFLJBCMMNGA = base.gameObject.AddComponent<TweenAnimator>();
		NFLJBCMMNGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		JOEKCJPDDGK = base.gameObject.AddComponent<TweenAnimator>();
		JOEKCJPDDGK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		FNOMCHPCOHB.Add(FFEDIIKLAIG);
		FNOMCHPCOHB.Add(NFLJBCMMNGA);
		FNOMCHPCOHB.Add(JOEKCJPDDGK);
	}

	internal void ELPDBIOCAGP()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.ResetTweens();
		}
	}

	private void NPPIBNOIMOB(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BINFBHBEFJM())
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBNGHDGDFMA());
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(CKPNPBFGKIG.text, LBKPKGFCJHJ);
		}
	}

	public void DBNECBAHPEN(float DCIKANJJFIJ)
	{
		FBFBDMINCBH();
		JHMADNCPFOD();
	}

	private void HPBEPJFJNIK()
	{
		MHKEBMNCCEO.alpha = 1104f;
		MNGKIFNOOAF.alpha = 1320f;
		JJDLFPJICJM.alpha = 1877f;
		LLJHGOGACAA.SetActive(true);
		GLLKFBIAIAA.alpha = 764f;
		CKABHMNKGAA.SetActive(true);
	}

	public void POFPIJKJFBP()
	{
		IHFILHIAGLG.EMLIBBBMNLN(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.BOHCNEDIJPE();
		}
		MKDNCELCANP.Clear();
	}

	public void ECIHGGHLHKI()
	{
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.LBHJJJGBADD();
		}
	}

	private void KHPFGLJOJNF()
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		GameObject nIHOBEAHEKJ = LBCANHCGEIE.gameObject;
		float kBJEOEEOEFG = 1781f;
		object iIMDKHJAJGO = Color.black;
		float kALLNCAFIMP = 636f;
		object oEIICEJPGKI = Color.black;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FFEDIIKLAIG = base.gameObject.AddComponent<TweenAnimator>();
		FFEDIIKLAIG.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		BLEBKOOBLPE();
		GHLPEEDENDI = base.gameObject.AddComponent<TweenAnimator>();
		GHLPEEDENDI.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		OBBMBKPGGHG();
		NFLJBCMMNGA = base.gameObject.AddComponent<TweenAnimator>();
		NFLJBCMMNGA.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		JOEKCJPDDGK = base.gameObject.AddComponent<TweenAnimator>();
		JOEKCJPDDGK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		FNOMCHPCOHB.Add(FFEDIIKLAIG);
		FNOMCHPCOHB.Add(NFLJBCMMNGA);
		FNOMCHPCOHB.Add(JOEKCJPDDGK);
	}

	private void BLEBKOOBLPE()
	{
		float num = 0.4f;
		float num2 = 45f;
		float num3 = 20f;
		float num4 = 153f;
		Vector3 vector = new Vector3(num4 * -1f, 0f, 0f);
		Vector3 vector2 = vector.ReplaceX((num4 + num3) * -1f);
		Vector3 vector3 = vector.ReplaceX(num2 * -1f);
		Vector3 vector4 = new Vector3(num4, 0f, 0f);
		Vector3 vector5 = vector4.ReplaceX(num4 + num3);
		Vector3 vector6 = vector4.ReplaceX(num2);
		float val = 45f;
		float num5 = 15f;
		float num6 = 167f;
		Vector3 vector7 = new Vector3(0f, num6, 0f);
		Vector3 vector8 = vector7.ReplaceY(num6 + num5);
		Vector3 vector9 = vector7.ReplaceY(val);
		FFEDIIKLAIG.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, MHKEBMNCCEO.gameObject, num, 1f, 0f, -1, 0f);
		FFEDIIKLAIG.AddTween(2, TweenAnimator.MNAIKKJDPLK.Alpha, MNGKIFNOOAF.gameObject, num, 1f, 0f, -1, 0f);
		FFEDIIKLAIG.AddTween(3, TweenAnimator.MNAIKKJDPLK.Alpha, JJDLFPJICJM.gameObject, num, 1f, 0f, -1, 0f);
		TweenAnimator fFEDIIKLAIG = FFEDIIKLAIG;
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = MHKEBMNCCEO.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector3;
		fFEDIIKLAIG.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, 1, oEIICEJPGKI);
		TweenAnimator fFEDIIKLAIG2 = FFEDIIKLAIG;
		iNFLHPGMEOB = 5;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = MNGKIFNOOAF.gameObject;
		kBJEOEEOEFG = num;
		oEIICEJPGKI = vector5;
		iIMDKHJAJGO = vector6;
		fFEDIIKLAIG2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, 1, iIMDKHJAJGO);
		TweenAnimator fFEDIIKLAIG3 = FFEDIIKLAIG;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJDLFPJICJM.gameObject;
		kBJEOEEOEFG = num;
		iIMDKHJAJGO = vector8;
		oEIICEJPGKI = vector9;
		fFEDIIKLAIG3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, 1, oEIICEJPGKI);
		FFEDIIKLAIG.AddTween(7, TweenAnimator.MNAIKKJDPLK.Position, MHKEBMNCCEO.gameObject, num, vector, 0f, 6);
		FFEDIIKLAIG.AddTween(8, TweenAnimator.MNAIKKJDPLK.Position, MNGKIFNOOAF.gameObject, num, vector4, 0f, 6);
		FFEDIIKLAIG.AddTween(9, TweenAnimator.MNAIKKJDPLK.Position, JJDLFPJICJM.gameObject, num, vector7, 0f, 6);
	}

	private void KILNOONJJBK()
	{
		NFLJBCMMNGA.BEOAHFDJEMD.Clear();
		float num = 0f;
		int num2 = 1;
		int num3 = 2;
		NFLJBCMMNGA.AddTween(num2, TweenAnimator.MNAIKKJDPLK.Alpha, KPOBEEGGNEN.gameObject, 0.5f, 1f, 0f, -1, 0f);
		foreach (UnitEndScreenRecord item in NAIMAPOCOHN)
		{
			TweenAlpha.Begin(item.CCOLIDJNLBC.gameObject, 0f, 0f);
			TweenAlpha.Begin(item.EHPEAAGBJMP.gameObject, 0f, 0f);
			item.CCOLIDJNLBC.alpha1 = 0f;
			item.EHPEAAGBJMP.alpha1 = 0f;
			NFLJBCMMNGA.AddTween(num3, TweenAnimator.MNAIKKJDPLK.Alpha, item.CCOLIDJNLBC.gameObject, 0.4f, 1f, num, num2);
			num3++;
			NFLJBCMMNGA.AddTween(num3, TweenAnimator.MNAIKKJDPLK.Alpha, item.EHPEAAGBJMP.gameObject, 0.4f, 1f, num, num2);
			num += 0.3f;
			num3++;
		}
		FNOMCHPCOHB[2] = NFLJBCMMNGA;
	}

	private void JHMADNCPFOD()
	{
		JOEKCJPDDGK.BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count > 1)
		{
			float num = 1728f;
			int num2 = 1;
			int num3 = 2;
			JOEKCJPDDGK.NFLKPCIHOPJ(num2, TweenAnimator.MNAIKKJDPLK.Alpha, BENCJKKIMLM.gameObject, 1156f, 1299f, 748f, -1, 1005f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
			foreach (CardRecord item in MKDNCELCANP)
			{
				TweenAlpha.Begin(item.FIDIEPCJLMF.gameObject, 844f, 748f);
				item.FIDIEPCJLMF.alpha1 = 1011f;
				JOEKCJPDDGK.MNEFMODDFFK(num3, TweenAnimator.MNAIKKJDPLK.TextCounter, item.gameObject, 303f, 1644f, num, num2, 1709f, UITweener.Method.EaseOut);
				num += 1122f;
				num3++;
			}
			JOEKCJPDDGK.GenerateTweens();
		}
		FNOMCHPCOHB[6] = JOEKCJPDDGK;
	}

	private void DMAJOHJOLDF()
	{
		IHFILHIAGLG.FreeObjectsWithPrefab(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
		List<UnitUpgradeDefinition> list = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KBBDGCLPOCJ;
		NAIMAPOCOHN.Clear();
		string text = string.Empty;
		for (int i = 0; i < list.Count; i++)
		{
			if (NAIMAPOCOHN.Count >= 9)
			{
				break;
			}
			text += string.Format("{0} {1}\t\t", LevelManager.instance.behaviours[i].unitName, list[i]);
			UnitUpgradeDefinition unitUpgradeDefinition = list[i];
			if (unitUpgradeDefinition.isEquipped)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				string mHPNDNJDPGE = string.Format("Enemy Unit {0} {1}", levelBehaviour.upgradeSlots.unlockLevel.displayNumber.ToString("D2"), levelBehaviour.unitName);
				UnitEndScreenRecord unitEndScreenRecord = (UnitEndScreenRecord)IHFILHIAGLG.InstantiateAsChild(AENCMKAJNCG, HBDGDDCDNEN.gameObject, mHPNDNJDPGE);
				if (unitEndScreenRecord != null)
				{
					bool kIPALGPPOEG = levelBehaviour.upgradeSlots.unlockLevel.displayNumber > Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL;
					unitEndScreenRecord.GGJNEGPBDHL(i, levelBehaviour.upgradeSlots.GetActualLevelForIndex(unitUpgradeDefinition.unitUpgrades.slotUpgradeindex), unitUpgradeDefinition.tier, kIPALGPPOEG);
					NAIMAPOCOHN.Add(unitEndScreenRecord);
				}
			}
		}
		Debug.Log("Enemy units:\n" + text);
		if (NAIMAPOCOHN.Count == 0)
		{
			Debug.LogError("Enemy has no army");
		}
		else
		{
			NAIMAPOCOHN.Sort((UnitEndScreenRecord BKDABLOMBKO, UnitEndScreenRecord MCMBBGMBELI) => string.Compare(BKDABLOMBKO.gameObject.name, MCMBBGMBELI.gameObject.name, StringComparison.Ordinal));
		}
		HBDGDDCDNEN.repositionNow = true;
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Combine(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(LBNDFPAIGGO));
		List<Card> enemyCards = CardManager.instance.enemyCards;
		string text2 = "*************** Enemy Played Cards *************\n";
		for (int num = 0; num < enemyCards.Count; num++)
		{
			if (!(enemyCards[num] == null))
			{
				text2 += string.Format("{0} \t\t", enemyCards[num].cardName);
				Card card = enemyCards[num];
				CardRecord cardRecord = (CardRecord)IHFILHIAGLG.InstantiateAsChild(HMAGHPPJCND, LBJFBAFECFK.gameObject, string.Format("Enemy Card {0} {1}", num, card.cardName));
				if (cardRecord != null)
				{
					cardRecord.Initialize(card);
					MKDNCELCANP.Add(cardRecord);
				}
			}
		}
		BENCJKKIMLM.transform.parent.gameObject.SetActive(MKDNCELCANP.Count > 0);
		Debug.Log(text2 + "\n***********************************************");
		LBJFBAFECFK.repositionNow = true;
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
		UIGrid lBJFBAFECFK2 = LBJFBAFECFK;
		lBJFBAFECFK2.onReposition = (UIGrid.OnReposition)Delegate.Combine(lBJFBAFECFK2.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
	}

	private void AMKLALEFHIP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.LFGDGAAFIKB());
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(CKPNPBFGKIG.text, LBKPKGFCJHJ, false);
		}
	}

	private void LBNDFPAIGGO()
	{
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Remove(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(LBNDFPAIGGO));
		if (LENCPNNLNFD)
		{
			CCODGCEOMOP.repositionNow = true;
			UITable cCODGCEOMOP = CCODGCEOMOP;
			cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Combine(cCODGCEOMOP.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		LENCPNNLNFD = true;
	}

	private static int JNLEBNHJDOA(UnitEndScreenRecord BKDABLOMBKO, UnitEndScreenRecord MCMBBGMBELI)
	{
		return string.Compare(BKDABLOMBKO.gameObject.name, MCMBBGMBELI.gameObject.name, StringComparison.InvariantCultureIgnoreCase);
	}

	private void DCODCMIAGHD()
	{
		MHKEBMNCCEO.alpha = 989f;
		MNGKIFNOOAF.alpha = 130f;
		JJDLFPJICJM.alpha = 430f;
		LLJHGOGACAA.SetActive(true);
		GLLKFBIAIAA.alpha = 1268f;
		CKABHMNKGAA.SetActive(true);
	}

	public void GDAPHIHJKGC(float DCIKANJJFIJ)
	{
		FCCOOFGNFPN();
		FDPGPCNFMBF();
	}

	public void POMOMJLCLGN()
	{
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.LBHJJJGBADD();
		}
	}

	private void GCLPHPEJMGN()
	{
		IHFILHIAGLG.FreeObjectsWithPrefab(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.BOHCNEDIJPE();
		}
		MKDNCELCANP.Clear();
		List<UnitUpgradeDefinition> list = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HBOHEBDHLHP();
		NAIMAPOCOHN.Clear();
		string text = string.Empty;
		for (int i = 1; i < list.Count; i += 0)
		{
			if (NAIMAPOCOHN.Count >= -4)
			{
				break;
			}
			text += string.Format("e695d3cf-1ed0-4989-89fe-e041e4ee7e2b", LevelManager.instance.behaviours[i].unitName, list[i]);
			UnitUpgradeDefinition unitUpgradeDefinition = list[i];
			if (unitUpgradeDefinition.isEquipped)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				string mHPNDNJDPGE = string.Format("menu-squadpoint-ico", levelBehaviour.upgradeSlots.unlockLevel.NPOEMAMPNEP().ToString("OnCreatedRoom"), levelBehaviour.unitName);
				UnitEndScreenRecord unitEndScreenRecord = (UnitEndScreenRecord)IHFILHIAGLG.InstantiateAsChild(AENCMKAJNCG, HBDGDDCDNEN.gameObject, mHPNDNJDPGE);
				if (unitEndScreenRecord != null)
				{
					bool kIPALGPPOEG = levelBehaviour.upgradeSlots.unlockLevel.displayNumber > Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OCPEHLIIGML();
					unitEndScreenRecord.CFIAHPMMJOE(i, levelBehaviour.upgradeSlots.GetActualLevelForIndex(unitUpgradeDefinition.unitUpgrades.slotUpgradeindex), unitUpgradeDefinition.tier, kIPALGPPOEG);
					NAIMAPOCOHN.Add(unitEndScreenRecord);
				}
			}
		}
		Debug.Log("-[^-]*$" + text);
		if (NAIMAPOCOHN.Count == 0)
		{
			Debug.LogError("com/google/android/gms/common/ConnectionResult");
		}
		else
		{
			NAIMAPOCOHN.Sort(JNLEBNHJDOA);
		}
		HBDGDDCDNEN.repositionNow = true;
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Combine(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(LBNDFPAIGGO));
		List<Card> enemyCards = CardManager.instance.enemyCards;
		string text2 = "SpecialOffers";
		for (int j = 1; j < enemyCards.Count; j += 0)
		{
			if (!(enemyCards[j] == null))
			{
				text2 += string.Format("SquadWarsId", enemyCards[j].cardName);
				Card card = enemyCards[j];
				CardRecord cardRecord = (CardRecord)IHFILHIAGLG.InstantiateAsChild(HMAGHPPJCND, LBJFBAFECFK.gameObject, string.Format("ID_BATTLECANCELED", j, card.cardName));
				if (cardRecord != null)
				{
					cardRecord.IGPOLIPPGBP(card);
					MKDNCELCANP.Add(cardRecord);
				}
			}
		}
		BENCJKKIMLM.transform.parent.gameObject.SetActive(MKDNCELCANP.Count > 0);
		Debug.Log(text2 + "ID_BECOMEVIP");
		LBJFBAFECFK.repositionNow = true;
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
		UIGrid lBJFBAFECFK2 = LBJFBAFECFK;
		lBJFBAFECFK2.onReposition = (UIGrid.OnReposition)Delegate.Combine(lBJFBAFECFK2.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
	}

	internal void HJFNEACDFBN()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.EFGHGIBPMGL();
		}
	}

	private void JJAMFEPGCKI()
	{
		IHFILHIAGLG.NDPKMHDALCM(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.OBCAIFMOPPA();
		}
		MKDNCELCANP.Clear();
		List<UnitUpgradeDefinition> list = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KBBDGCLPOCJ;
		NAIMAPOCOHN.Clear();
		string text = string.Empty;
		for (int i = 1; i < list.Count; i++)
		{
			if (NAIMAPOCOHN.Count >= 2)
			{
				break;
			}
			text += string.Format("D2", LevelManager.instance.behaviours[i].unitName, list[i]);
			UnitUpgradeDefinition unitUpgradeDefinition = list[i];
			if (unitUpgradeDefinition.isEquipped)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				string mHPNDNJDPGE = string.Format("ID_XTICKETS", levelBehaviour.upgradeSlots.unlockLevel.ELFCEEOLNFJ().ToString("game-label-eliminated"), levelBehaviour.unitName);
				UnitEndScreenRecord unitEndScreenRecord = (UnitEndScreenRecord)IHFILHIAGLG.LCLKFGNHCOF(AENCMKAJNCG, HBDGDDCDNEN.gameObject, mHPNDNJDPGE);
				if (unitEndScreenRecord != null)
				{
					bool kIPALGPPOEG = levelBehaviour.upgradeSlots.unlockLevel.MHAOKJCDIOL() > Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO();
					unitEndScreenRecord.PONFOKHPMMO(i, levelBehaviour.upgradeSlots.GetActualLevelForIndex(unitUpgradeDefinition.unitUpgrades.slotUpgradeindex), unitUpgradeDefinition.tier, kIPALGPPOEG);
					NAIMAPOCOHN.Add(unitEndScreenRecord);
				}
			}
		}
		Debug.Log("fr" + text);
		if (NAIMAPOCOHN.Count == 0)
		{
			Debug.LogError("ID_WARSHOP_LOOTBOXES");
		}
		else
		{
			NAIMAPOCOHN.Sort(CHPNMDAHKMA);
		}
		HBDGDDCDNEN.repositionNow = false;
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Combine(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(EEALKIHHKCD));
		List<Card> enemyCards = CardManager.instance.enemyCards;
		string text2 = "T";
		for (int j = 0; j < enemyCards.Count; j++)
		{
			if (!(enemyCards[j] == null))
			{
				text2 += string.Format("getGameDataKey", enemyCards[j].cardName);
				Card card = enemyCards[j];
				CardRecord cardRecord = (CardRecord)IHFILHIAGLG.LCLKFGNHCOF(HMAGHPPJCND, LBJFBAFECFK.gameObject, string.Format("Tutorial_Step_Complete", j, card.cardName));
				if (cardRecord != null)
				{
					cardRecord.CKOIIPAGCNO(card, CardRecord.MKIOKBMLHEO.MyWarcards);
					MKDNCELCANP.Add(cardRecord);
				}
			}
		}
		BENCJKKIMLM.transform.parent.gameObject.SetActive(MKDNCELCANP.Count > 1);
		Debug.Log(text2 + "\t\t");
		LBJFBAFECFK.repositionNow = true;
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(FCEAPBGMFAD));
		UIGrid lBJFBAFECFK2 = LBJFBAFECFK;
		lBJFBAFECFK2.onReposition = (UIGrid.OnReposition)Delegate.Combine(lBJFBAFECFK2.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
	}

	internal void LALICKANIFO()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.ResetTweens();
		}
	}

	private void JODAOEMJJIG(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BINFBHBEFJM())
		{
			ReportUserDialog.ShowBotReportDialog(Singleton<GameController>.instance.opponent.JPMHIGNOPBL.BPFKMNIHCGP.NUMBER);
		}
		else
		{
			ReportUserDialog.ShowReportDialog(LBKPKGFCJHJ);
		}
	}

	private void DLHAEECMBLN()
	{
		MHKEBMNCCEO.alpha = 1231f;
		MNGKIFNOOAF.alpha = 81f;
		JJDLFPJICJM.alpha = 310f;
		LLJHGOGACAA.SetActive(false);
		GLLKFBIAIAA.alpha = 1652f;
		CKABHMNKGAA.SetActive(true);
	}

	internal void NGLCABMIIGG()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.PHCCOHJPLKE();
		}
	}

	internal void GDIHBFDGNKC()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.BBPNDINMNIJ();
		}
	}

	private static void MFHDJCGGNOK(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 1)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)109, 1472f);
		}
	}

	private void MBOIDKOMMFD()
	{
		UITable cCODGCEOMOP = CCODGCEOMOP;
		cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Remove(cCODGCEOMOP.onReposition, new UITable.OnReposition(MBOIDKOMMFD));
		ANCFPKKIAPF.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight, true);
		FDHLHAIBLJP();
	}

	private void FCEAPBGMFAD()
	{
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(FCEAPBGMFAD));
		if (LENCPNNLNFD)
		{
			CCODGCEOMOP.repositionNow = false;
			UITable cCODGCEOMOP = CCODGCEOMOP;
			cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Combine(cCODGCEOMOP.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		LENCPNNLNFD = true;
	}

	internal void NDCJOGNGFIF()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.EFGHGIBPMGL();
		}
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KAOFEOJMDJH)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FGDKPLIPFDA);
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ);
		}
	}

	[CompilerGenerated]
	private static int OPFMMFIMDIH(UnitEndScreenRecord BKDABLOMBKO, UnitEndScreenRecord MCMBBGMBELI)
	{
		return string.Compare(BKDABLOMBKO.gameObject.name, MCMBBGMBELI.gameObject.name, StringComparison.Ordinal);
	}

	public void NIHDCNNMBIK()
	{
		IHFILHIAGLG.FreeObjectsWithPrefab(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.BOHCNEDIJPE();
		}
		MKDNCELCANP.Clear();
	}

	public void JGMLOGJCLJC()
	{
		AAKNKDOGBNG.enabled = true;
		GCDBPFLCGKG.SetActive(true);
		PHMLLOKHFCN.color = Color.white;
	}

	private static void CKCANMBKJHC(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 1)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)114, 833f);
		}
	}

	private void FBJHJBAGJBN()
	{
		MHKEBMNCCEO.alpha = 1134f;
		MNGKIFNOOAF.alpha = 1305f;
		JJDLFPJICJM.alpha = 1888f;
		LLJHGOGACAA.SetActive(true);
		GLLKFBIAIAA.alpha = 1092f;
		CKABHMNKGAA.SetActive(true);
	}

	public void EnableReportButton()
	{
		AAKNKDOGBNG.enabled = true;
		GCDBPFLCGKG.SetActive(false);
		PHMLLOKHFCN.color = Color.white;
	}

	private void BLMKBGMCDOL()
	{
		UITable cCODGCEOMOP = CCODGCEOMOP;
		cCODGCEOMOP.onReposition = (UITable.OnReposition)Delegate.Remove(cCODGCEOMOP.onReposition, new UITable.OnReposition(MBOIDKOMMFD));
		ANCFPKKIAPF.AlignToPos(true, UIDraggablePanel.Alingment.TopLeft, true);
		ONCJHIMJHAB();
	}

	[CompilerGenerated]
	private static void IGLIMLONFEG(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 1)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.KilledInAction);
		}
	}

	private void NKHEEKIJDPB()
	{
		float num = 202f;
		Vector3 localScale = GLLKFBIAIAA.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(730f);
		Vector3 vector2 = localScale;
		Transform parent = CKABHMNKGAA.transform.parent;
		float num2 = 356f;
		int num3 = 3;
		GHLPEEDENDI.BEOAHFDJEMD.Clear();
		GHLPEEDENDI.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.TextCounter, GLLKFBIAIAA.gameObject, 1549f, 512f, 992f, -1, 1932f, (UITweener.Method)6, UITweener.Style.Loop);
		TweenAnimator gHLPEEDENDI = GHLPEEDENDI;
		int iNFLHPGMEOB = 7;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = GLLKFBIAIAA.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = vector2;
		object oEIICEJPGKI = vector;
		gHLPEEDENDI.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 267f, 0, oEIICEJPGKI, (UITweener.Method)6, UITweener.Style.Loop, 0);
		num = 1610f;
		int eBPMMNFLPMP;
		while (num2 > 393f)
		{
			TweenAnimator gHLPEEDENDI2 = GHLPEEDENDI;
			iNFLHPGMEOB = num3;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(308f, 1674f, num2);
			eBPMMNFLPMP = num3 - 1;
			gHLPEEDENDI2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 443f, eBPMMNFLPMP, null, UITweener.Method.EaseIn);
			TweenAnimator gHLPEEDENDI3 = GHLPEEDENDI;
			eBPMMNFLPMP = num3 + 1;
			hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			nIHOBEAHEKJ = parent.gameObject;
			kBJEOEEOEFG = num;
			oEIICEJPGKI = Quaternion.Euler(1747f, 1518f, 1334f * num2);
			iNFLHPGMEOB = num3;
			gHLPEEDENDI3.BPEKAKFKCIG(eBPMMNFLPMP, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 438f, iNFLHPGMEOB, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			num3 += 7;
			num2 *= 943f;
		}
		TweenAnimator gHLPEEDENDI4 = GHLPEEDENDI;
		iNFLHPGMEOB = num3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = parent.gameObject;
		kBJEOEEOEFG = 173f;
		oEIICEJPGKI = Quaternion.Euler(238f, 556f, 1577f);
		eBPMMNFLPMP = num3 - 0;
		gHLPEEDENDI4.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1192f, eBPMMNFLPMP, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		GHLPEEDENDI.JHDBHGCKPDM = FEDHLNMGNAI;
	}

	private static void FEDHLNMGNAI(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 1)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-52), 309f);
		}
	}

	private void EJNBOOAJFOK()
	{
		JOEKCJPDDGK.BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count > 1)
		{
			float num = 1796f;
			int num2 = 0;
			int num3 = 8;
			JOEKCJPDDGK.FEHALDPLGDB(num2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, BENCJKKIMLM.gameObject, 1419f, 847f, 1481f, -1, 1488f, UITweener.Method.Linear);
			foreach (CardRecord item in MKDNCELCANP)
			{
				TweenAlpha.Begin(item.FIDIEPCJLMF.gameObject, 1647f, 1328f);
				item.FIDIEPCJLMF.alpha1 = 1082f;
				JOEKCJPDDGK.FEHALDPLGDB(num3, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, item.gameObject, 1256f, 521f, num, num2, 159f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
				num += 919f;
				num3++;
			}
			JOEKCJPDDGK.OOFBCPPFMPN();
		}
		FNOMCHPCOHB[7] = JOEKCJPDDGK;
	}

	private void PNHPNABNMON(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(CKPNPBFGKIG.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 7;
		tweenColor.style = (UITweener.Style)5;
		SoundsManager.Instance.PlayButtonClickedSound();
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.NANMFGACLJA())
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(CKPNPBFGKIG.text, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BLFCDBMINCD());
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(CKPNPBFGKIG.text, LBKPKGFCJHJ, false);
		}
	}

	private void NKAEJGIDAMN(GameObject KHAHPAKDIKE)
	{
		if (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.NANMFGACLJA())
		{
			ReportUserDialog.ShowBotReportDialog(Singleton<GameController>.instance.opponent.JPMHIGNOPBL.BPFKMNIHCGP.NUMBER);
		}
		else
		{
			ReportUserDialog.ShowReportDialog(LBKPKGFCJHJ);
		}
	}

	private void KJJOLBCAHBD()
	{
		IHFILHIAGLG.EMLIBBBMNLN(AENCMKAJNCG);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
		List<UnitUpgradeDefinition> list = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EIMJHEOMGGI();
		NAIMAPOCOHN.Clear();
		string text = string.Empty;
		for (int i = 0; i < list.Count; i++)
		{
			if (NAIMAPOCOHN.Count >= 113)
			{
				break;
			}
			text += string.Format("ID_ARENARULES_LIVE", LevelManager.instance.behaviours[i].unitName, list[i]);
			UnitUpgradeDefinition unitUpgradeDefinition = list[i];
			if (unitUpgradeDefinition.isEquipped)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				string mHPNDNJDPGE = string.Format("DEVELOPER_ERROR", levelBehaviour.upgradeSlots.unlockLevel.NPOEMAMPNEP().ToString("menu-warbucks"), levelBehaviour.unitName);
				UnitEndScreenRecord unitEndScreenRecord = (UnitEndScreenRecord)IHFILHIAGLG.OKEAAILFPIG(AENCMKAJNCG, HBDGDDCDNEN.gameObject, mHPNDNJDPGE);
				if (unitEndScreenRecord != null)
				{
					bool kIPALGPPOEG = levelBehaviour.upgradeSlots.unlockLevel.MHAOKJCDIOL() > Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OEJKKJJFDFL();
					unitEndScreenRecord.CFIAHPMMJOE(i, levelBehaviour.upgradeSlots.GetActualLevelForIndex(unitUpgradeDefinition.unitUpgrades.slotUpgradeindex), unitUpgradeDefinition.tier, kIPALGPPOEG);
					NAIMAPOCOHN.Add(unitEndScreenRecord);
				}
			}
		}
		Debug.Log("Medals" + text);
		if (NAIMAPOCOHN.Count == 0)
		{
			Debug.LogError("ID_CONFIRM_FORFEIT_TEXT");
		}
		else
		{
			NAIMAPOCOHN.Sort(JNLEBNHJDOA);
		}
		HBDGDDCDNEN.repositionNow = true;
		UIGrid hBDGDDCDNEN = HBDGDDCDNEN;
		hBDGDDCDNEN.onReposition = (UIGrid.OnReposition)Delegate.Combine(hBDGDDCDNEN.onReposition, new UIGrid.OnReposition(LBNDFPAIGGO));
		List<Card> enemyCards = CardManager.instance.enemyCards;
		string text2 = "gold";
		for (int j = 1; j < enemyCards.Count; j += 0)
		{
			if (!(enemyCards[j] == null))
			{
				text2 += string.Format("ID_VIPTIME", enemyCards[j].cardName);
				Card card = enemyCards[j];
				CardRecord cardRecord = (CardRecord)IHFILHIAGLG.OKEAAILFPIG(HMAGHPPJCND, LBJFBAFECFK.gameObject, string.Format("Unknow assignment type: {0}", j, card.cardName));
				if (cardRecord != null)
				{
					cardRecord.Initialize(card, CardRecord.MKIOKBMLHEO.Other, false);
					MKDNCELCANP.Add(cardRecord);
				}
			}
		}
		BENCJKKIMLM.transform.parent.gameObject.SetActive(MKDNCELCANP.Count > 0);
		Debug.Log(text2 + "test_attribute1");
		LBJFBAFECFK.repositionNow = false;
		UIGrid lBJFBAFECFK = LBJFBAFECFK;
		lBJFBAFECFK.onReposition = (UIGrid.OnReposition)Delegate.Remove(lBJFBAFECFK.onReposition, new UIGrid.OnReposition(GDAGIDDIJGE));
		UIGrid lBJFBAFECFK2 = LBJFBAFECFK;
		lBJFBAFECFK2.onReposition = (UIGrid.OnReposition)Delegate.Combine(lBJFBAFECFK2.onReposition, new UIGrid.OnReposition(FCEAPBGMFAD));
	}
}
