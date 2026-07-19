using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LeagueResultDialog : GuiElementSingle<LeagueResultDialog>, PAIIOKBBHBC
{
	private enum NKHJBLBAAEB
	{
		Demotion = 0,
		Finished = 1,
		Promotion = 2
	}

	[Header("Core")]
	public UISprite KMFGCJEGJJK;

	public GameObject MGEGMLELNFD;

	[Header("Header")]
	public UILabel OKMNFHNBMFA;

	[Header("Middle Part")]
	public UITable CCODGCEOMOP;

	public GameObject ENAGBHIDGNC;

	[Header("-Finished Part")]
	public GameObject FLKBAPLOPCF;

	public UILabel GFCGJNJCOCC;

	public UILabel JKGDFGAPCEC;

	public UISprite MJKICJCNBEC;

	public UISprite JJADELOKMOP;

	[Header("-Description Part")]
	public UILabel JPCIACBHGHO;

	[Header("-Win Bonus Part")]
	public UISprite MHKEBMNCCEO;

	public UILabel FNGBLDCOOKN;

	public UISprite MNGKIFNOOAF;

	[Header("-Money Part")]
	public GameObject CLPNODBKDCP;

	public UISprite MDDIOFPDLCB;

	public UISprite BGPBNIJPOKM;

	public UILabel BMENLOAIDDB;

	public UISprite BJPGJFFOICH;

	public GameObject NKJBDMDMMCH;

	public UISprite JMBCFGBLADP;

	public UISprite ADONBKGNGCG;

	public UILabel LKCHKLPFEKM;

	public UISprite JDJENEHFHKE;

	[Header("Left Part")]
	public UISprite KHPDFLPPMDD;

	public UISprite GEAMGMBNGNE;

	public UITexture BFLBNOPDOAE;

	[Header("Bottom Part")]
	public GameObject JMBPNBGCFIL;

	public BoxCollider EFDCDBOCBBI;

	public GameObject DMPBNBPBDFD;

	public UILabel HLPPHFIEGBL;

	public UISprite EMHGDFGBNFA;

	public GameObject HKMJJILBLPH;

	[Header("Animation Part")]
	public UITexture APIDNBIHEFB;

	public UILabel MEKIBLPANJI;

	public UITexture NOPEIEHIJIA;

	public UILabel PIMPLAINMJN;

	[Header("-Particles")]
	public ParticleSystem DNNNFJGLMJC;

	public ParticleSystem MIJOGDBBMDO;

	private League KNNEGKLGBKO;

	private League OJLHIJEHJJO;

	private int HLLEIILLCIC;

	private NKHJBLBAAEB GPABKIOEGKM = NKHJBLBAAEB.Finished;

	private TweenAnimator KDBGAMFIELL;

	private TweenAnimator EMINBMPHPFJ;

	private TweenAnimator ACCCJBDCDCK;

	private float FGIPPNFFPEL = 0.05f;

	private float HKJHFGJIMIL = 0.01f;

	private float JCAFFELIFAO = 0.2f;

	private float CLLOMDNLHDG = 0.05f;

	private Vector3 AGGGPHFGJDI = new Vector3(60f, 60f, 1f);

	private Vector3 JBOLDEGFJJP = new Vector3(120f, 120f, 1f);

	private Vector3 CPBDKKGIOHP;

	private Vector3 CBHDKEFHFMP;

	private Vector3 LPFGKALCGML;

	private Vector3 OOMOGFGELHI = new Vector3(280f, 0f, 0f);

	private Vector3 MNFNJDCCCCM = new Vector3(0f, 0f, 0f);

	private Vector3 NGPFDFJACCJ = new Vector3(-150f, 0f, 0f);

	private Vector3 JCIKBMFOPIC = new Vector3(204f, 0f, 0f);

	private Vector3 CNFGKCMFFOC = new Vector3(0f, 0f, 0f);

	private Vector3 FOOBFBOEABO = new Vector3(-90f, 0f, 0f);

	private Vector3 LOJDMHIPKCI = new Vector3(229f, -84f, 0f);

	private Vector3 BLJBHFBKKHO = new Vector3(25f, -84f, 0f);

	private Vector3 PEHEPDFKOMI = new Vector3(-65f, -84f, 0f);

	private Vector3 HJPMJMKOCLG;

	private Vector3 NILGABEFPAL;

	private Vector3 DHCNHBGJLFL;

	private Vector3 GCFHIMDABME = new Vector3(-378f, 0f, 0f);

	private Vector3 NKHDKBHKJCK = new Vector3(-421f, 0f, 0f);

	private Vector3 ODINEIOOPGG = new Vector3(-334f, 0f, 0f);

	private Vector3 HPBHLFPDKDE = new Vector3(378f, 0f, 0f);

	private Vector3 HGIHICGBHCF = new Vector3(334f, 0f, 0f);

	private Vector3 GDLDCEOMIEA = new Vector3(421f, 0f, 0f);

	private Vector3 OLHBMBFPABL = new Vector3(-372f, -10f, -1f);

	private Vector3 MFBMBBDPGMO = new Vector3(-372f, 1f, -1f);

	private Vector3 JFKPCDAKICI = new Vector3(-372f, -36f, -1f);

	private Vector3 AFLJAGABFFC = new Vector3(0f, -4f, -1f);

	private Vector3 KJFCKFODGAI = new Vector3(0f, 10f, -1f);

	private Vector3 GOCPEMACJJE = new Vector3(0f, -30f, -1f);

	private Vector3 EAEBDEKPIBG = new Vector3(-372f, 0f, 0f);

	private Vector3 KDFFFINIABP = new Vector3(-419f, 0f, 0f);

	private Vector3 HMDKKLLOJCO = new Vector3(-332f, 0f, 0f);

	private Vector3 ILGGEHIILNI = new Vector3(372f, 0f, 0f);

	private Vector3 JPKBOOFIGLF = new Vector3(332f, 0f, 0f);

	private Vector3 HDCDICFCMJM = new Vector3(419f, 0f, 0f);

	private Vector3 LDHOBENLGAH = new Vector3(-197f, -5f, 0f);

	private Vector3 FEBNJNGGBMP = new Vector3(-197f, 8f, 0f);

	private Vector3 KAKIEOHOGOH = new Vector3(-197f, -30f, 0f);

	private Vector3 BCJHNKGKNDM = new Vector3(197f, -5f, 0f);

	private Vector3 CFBLEPANEML = new Vector3(197f, 8f, 0f);

	private Vector3 AECNIEBBNNI = new Vector3(197f, -30f, 0f);

	private Vector3 IMDMCFKEDJL = new Vector3(0f, -224f, 0f);

	private Vector3 IMGIAAKCJEB = new Vector3(0f, -211f, 0f);

	private Vector3 DNFAJJEAGFN = new Vector3(0f, -249f, 0f);

	private static Dictionary<NKHJBLBAAEB, Tuple<Color, string>> ILCAMNAMGLI = new Dictionary<NKHJBLBAAEB, Tuple<Color, string>>
	{
		{
			NKHJBLBAAEB.Demotion,
			new Tuple<Color, string>(Colours.redLeague, Colours.stringRedLeague)
		},
		{
			NKHJBLBAAEB.Finished,
			new Tuple<Color, string>(Colours.blue, Colours.stringBlue)
		},
		{
			NKHJBLBAAEB.Promotion,
			new Tuple<Color, string>(Colours.greenLeague, Colours.stringGreenLeague)
		}
	};

	private static Dictionary<NKHJBLBAAEB, Tuple<string, string>> OKDDKBMLFNC = new Dictionary<NKHJBLBAAEB, Tuple<string, string>>
	{
		{
			NKHJBLBAAEB.Demotion,
			new Tuple<string, string>("ID_LEAGUEDEMOTION", "ID_YOUVEBEENDEMOTEDTO")
		},
		{
			NKHJBLBAAEB.Finished,
			new Tuple<string, string>("ID_LEAGUEFINISHED", "ID_NOTBADYOUVEHOLDYOURGROUND")
		},
		{
			NKHJBLBAAEB.Promotion,
			new Tuple<string, string>("ID_LEAGUEPROMOTION", "ID_GOODJOBYOUVEBEENPROMOTED")
		}
	};

	[CompilerGenerated]
	private void GJKDPAAJHFB(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 55)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueIconShowed);
			if (GPABKIOEGKM == NKHJBLBAAEB.Promotion)
			{
				DNNNFJGLMJC.Play();
			}
			else if (GPABKIOEGKM == NKHJBLBAAEB.Demotion)
			{
				MIJOGDBBMDO.Play();
			}
		}
		if (EAINKPNECEC == 114 || EAINKPNECEC == 126)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
		}
		if (EAINKPNECEC == 135)
		{
			EFDCDBOCBBI.enabled = true;
		}
	}

	private int NKCJPCLJFJG(ref TweenAnimator AGMEHGCOPBM)
	{
		float num = 100f;
		AGMEHGCOPBM.AddTween(123, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, APIDNBIHEFB.gameObject, DCIKANJJFIJ * 1673f, 874f, 1579f, -1, 941f, UITweener.Method.Linear, UITweener.Style.Loop);
		AGMEHGCOPBM.AddTween(-102, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, FGIPPNFFPEL, 90f, 1380f, -11, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		TweenAnimator obj = AGMEHGCOPBM;
		int iNFLHPGMEOB = -41;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		GameObject nIHOBEAHEKJ = BFLBNOPDOAE.gameObject;
		float jCAFFELIFAO = JCAFFELIFAO;
		object iIMDKHJAJGO = CBHDKEFHFMP;
		object oEIICEJPGKI = Vector3.one;
		obj.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 739f, 34, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.AddTween(33, TweenAnimator.MNAIKKJDPLK.Rotation, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 1828f, CPBDKKGIOHP, 624f, -16, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		AGMEHGCOPBM.FEHALDPLGDB(-27, TweenAnimator.MNAIKKJDPLK.Position, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1844f, 1455f, 53, null, (UITweener.Method)8);
		TweenAnimator obj2 = AGMEHGCOPBM;
		iNFLHPGMEOB = 115;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = PIMPLAINMJN.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = JBOLDEGFJJP;
		iIMDKHJAJGO = Vector3.one;
		obj2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 19f, -106, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.FEHALDPLGDB(52, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PIMPLAINMJN.gameObject, JCAFFELIFAO * 1863f, AGGGPHFGJDI, 1205f, 88, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.AddTween(-49, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, NOPEIEHIJIA.gameObject, HKJHFGJIMIL, 1459f, 1030f, -113, null, (UITweener.Method)6);
		AGMEHGCOPBM.FEHALDPLGDB(-116, TweenAnimator.MNAIKKJDPLK.Rotation, NOPEIEHIJIA.gameObject, num + JCAFFELIFAO * 1247f, 70f, 1203f, -49, null, UITweener.Method.Linear);
		TweenAnimator obj3 = AGMEHGCOPBM;
		iNFLHPGMEOB = -31;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = NOPEIEHIJIA.gameObject;
		jCAFFELIFAO = num + FGIPPNFFPEL + JCAFFELIFAO * 1533f;
		iIMDKHJAJGO = LPFGKALCGML;
		oEIICEJPGKI = CBHDKEFHFMP;
		obj3.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 1577f, -72, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.AddTween(-44, TweenAnimator.MNAIKKJDPLK.Rotation, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1594f, 755f, 96, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		AGMEHGCOPBM.FEHALDPLGDB(116, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1385f, 214f, 27, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.BPEKAKFKCIG(-122, TweenAnimator.MNAIKKJDPLK.TextCounter, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 643f, 719f, -46, null, (UITweener.Method)6, UITweener.Style.Loop);
		AGMEHGCOPBM.AddTween(25, TweenAnimator.MNAIKKJDPLK.Color, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 94f, 982f, -98, null, UITweener.Method.EaseIn);
		AGMEHGCOPBM.NFLKPCIHOPJ(70, TweenAnimator.MNAIKKJDPLK.Rotation, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 739f, 1309f, 20);
		AGMEHGCOPBM.FEHALDPLGDB(25, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 559f, 1899f, 72, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		AGMEHGCOPBM.FEHALDPLGDB(51, TweenAnimator.MNAIKKJDPLK.Color, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1482f, 1462f, -17, null, (UITweener.Method)6);
		AGMEHGCOPBM.BPEKAKFKCIG(-24, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 16f, 443f, 74, null, (UITweener.Method)6);
		AGMEHGCOPBM.NFLKPCIHOPJ(50, TweenAnimator.MNAIKKJDPLK.Color, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1654f, 1315f, -31, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		AGMEHGCOPBM.BPEKAKFKCIG(-127, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1236f, 1182f, -68, null, UITweener.Method.Linear, UITweener.Style.Loop);
		AGMEHGCOPBM.BPEKAKFKCIG(-126, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 966f, NGPFDFJACCJ, 1791f, -44, null, UITweener.Method.EaseIn);
		AGMEHGCOPBM.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 1655f, MNFNJDCCCCM, 1848f, -121, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.NFLKPCIHOPJ(-46, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, KHPDFLPPMDD.gameObject, JCAFFELIFAO * 663f, 386f, 270f, 89, 407f, (UITweener.Method)8, UITweener.Style.Once, 0);
		TweenAnimator obj4 = AGMEHGCOPBM;
		iNFLHPGMEOB = -65;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = KHPDFLPPMDD.gameObject;
		jCAFFELIFAO = JCAFFELIFAO * 836f;
		oEIICEJPGKI = PEHEPDFKOMI;
		iIMDKHJAJGO = LOJDMHIPKCI;
		obj4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 1154f, -20, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		AGMEHGCOPBM.MNEFMODDFFK(-28, TweenAnimator.MNAIKKJDPLK.Rotation, KHPDFLPPMDD.gameObject, JCAFFELIFAO * 1312f, BLJBHFBKKHO, 973f, -65);
		return -45;
	}

	private void PGIEENOKEGE(ref TweenAnimator AGMEHGCOPBM)
	{
		TweenAnimator obj = AGMEHGCOPBM;
		obj.JHDBHGCKPDM = (Action<int>)Delegate.Combine(obj.JHDBHGCKPDM, (Action<int>)delegate(int EAINKPNECEC)
		{
			if (EAINKPNECEC == 55)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueIconShowed);
				if (GPABKIOEGKM == NKHJBLBAAEB.Promotion)
				{
					DNNNFJGLMJC.Play();
				}
				else if (GPABKIOEGKM == NKHJBLBAAEB.Demotion)
				{
					MIJOGDBBMDO.Play();
				}
			}
			if (EAINKPNECEC == 114 || EAINKPNECEC == 126)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
			}
			if (EAINKPNECEC == 135)
			{
				EFDCDBOCBBI.enabled = true;
			}
		});
	}

	private void LAGFNMNNDDI(ref TweenAnimator AGMEHGCOPBM, int OFDMBFAPAAC, bool OCAILDBABGH = true)
	{
		AGMEHGCOPBM.MNEFMODDFFK(-43, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, 1706f * FGIPPNFFPEL + 903f * HKJHFGJIMIL, 411f, 263f, OFDMBFAPAAC, 1815f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		AGMEHGCOPBM.BPEKAKFKCIG(77, TweenAnimator.MNAIKKJDPLK.TextCounter, GFCGJNJCOCC.gameObject, JCAFFELIFAO, 944f, 525f, 58, 1728f, UITweener.Method.BounceIn);
		AGMEHGCOPBM.FEHALDPLGDB(112, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, JKGDFGAPCEC.gameObject, JCAFFELIFAO, 320f, 980f, 89, 1494f, UITweener.Method.Linear);
		TweenAnimator obj = AGMEHGCOPBM;
		int iNFLHPGMEOB = 12;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject fLKBAPLOPCF = FLKBAPLOPCF;
		float jCAFFELIFAO = JCAFFELIFAO;
		object iIMDKHJAJGO = NILGABEFPAL;
		object oEIICEJPGKI = DHCNHBGJLFL;
		obj.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 1294f, -100, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		AGMEHGCOPBM.FEHALDPLGDB(-41, TweenAnimator.MNAIKKJDPLK.Position, FLKBAPLOPCF, JCAFFELIFAO * 17f, HJPMJMKOCLG, 1524f, 76, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		AGMEHGCOPBM.FEHALDPLGDB(121, TweenAnimator.MNAIKKJDPLK.Position, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 1481f, 416f, 113, 441f, (UITweener.Method)7);
		AGMEHGCOPBM.FEHALDPLGDB(-4, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MJKICJCNBEC.gameObject, JCAFFELIFAO, 86f, 448f, 56, 1334f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		AGMEHGCOPBM.MNEFMODDFFK(102, TweenAnimator.MNAIKKJDPLK.Alpha, JJADELOKMOP.gameObject, JCAFFELIFAO, 1600f, 277f, 20, 826f, UITweener.Method.BounceIn);
		TweenAnimator obj2 = AGMEHGCOPBM;
		iNFLHPGMEOB = 39;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		fLKBAPLOPCF = MJKICJCNBEC.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = NKHDKBHKJCK;
		iIMDKHJAJGO = ODINEIOOPGG;
		obj2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 277f, 76, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(24, TweenAnimator.MNAIKKJDPLK.Rotation, MJKICJCNBEC.gameObject, JCAFFELIFAO * 1045f, GCFHIMDABME, 660f, -2, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		TweenAnimator obj3 = AGMEHGCOPBM;
		iNFLHPGMEOB = 63;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		fLKBAPLOPCF = JJADELOKMOP.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = GDLDCEOMIEA;
		oEIICEJPGKI = HGIHICGBHCF;
		obj3.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 103f, -116, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
		AGMEHGCOPBM.BPEKAKFKCIG(75, TweenAnimator.MNAIKKJDPLK.Rotation, JJADELOKMOP.gameObject, JCAFFELIFAO * 282f, HPBHLFPDKDE, 39f, -107, null, UITweener.Method.BounceIn);
		AGMEHGCOPBM.NFLKPCIHOPJ(-112, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 269f, 1395f, -7, 1329f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.MNEFMODDFFK(-53, TweenAnimator.MNAIKKJDPLK.TextCounter, JPCIACBHGHO.gameObject, JCAFFELIFAO, 1340f, 1239f, -15, 1875f, (UITweener.Method)7);
		TweenAnimator obj4 = AGMEHGCOPBM;
		iNFLHPGMEOB = 40;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = JPCIACBHGHO.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = MFBMBBDPGMO;
		iIMDKHJAJGO = JFKPCDAKICI;
		obj4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 997f, 113, iIMDKHJAJGO, UITweener.Method.Linear);
		AGMEHGCOPBM.AddTween(-117, TweenAnimator.MNAIKKJDPLK.Position, JPCIACBHGHO.gameObject, JCAFFELIFAO * 881f, OLHBMBFPABL, 648f, -98, null, UITweener.Method.Linear, UITweener.Style.Loop);
		AGMEHGCOPBM.AddTween(3, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 1319f, 1746f, -93, 1490f, UITweener.Method.Linear, UITweener.Style.Loop);
		AGMEHGCOPBM.FEHALDPLGDB(-28, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FNGBLDCOOKN.gameObject, JCAFFELIFAO, 430f, 1966f, 18, 856f, (UITweener.Method)7);
		TweenAnimator obj5 = AGMEHGCOPBM;
		iNFLHPGMEOB = 36;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = FNGBLDCOOKN.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = KJFCKFODGAI;
		oEIICEJPGKI = GOCPEMACJJE;
		obj5.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 146f, 61, oEIICEJPGKI, UITweener.Method.Linear);
		AGMEHGCOPBM.NFLKPCIHOPJ(93, TweenAnimator.MNAIKKJDPLK.Rotation, FNGBLDCOOKN.gameObject, JCAFFELIFAO * 1583f, AFLJAGABFFC, 1926f, -114, null, (UITweener.Method)8, UITweener.Style.Loop);
		AGMEHGCOPBM.NFLKPCIHOPJ(-57, TweenAnimator.MNAIKKJDPLK.TextCounter, MHKEBMNCCEO.gameObject, JCAFFELIFAO, 454f, 1909f, -51, 1348f, (UITweener.Method)8, UITweener.Style.Loop);
		AGMEHGCOPBM.AddTween(91, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MNGKIFNOOAF.gameObject, JCAFFELIFAO, 469f, 1258f, 58, 50f, (UITweener.Method)7, UITweener.Style.Loop);
		TweenAnimator obj6 = AGMEHGCOPBM;
		iNFLHPGMEOB = -45;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = MHKEBMNCCEO.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = KDFFFINIABP;
		iIMDKHJAJGO = HMDKKLLOJCO;
		obj6.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 1627f, 29, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.AddTween(-82, TweenAnimator.MNAIKKJDPLK.Rotation, MHKEBMNCCEO.gameObject, JCAFFELIFAO * 1581f, EAEBDEKPIBG, 1439f, 120, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		TweenAnimator obj7 = AGMEHGCOPBM;
		iNFLHPGMEOB = -37;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = MNGKIFNOOAF.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = HDCDICFCMJM;
		oEIICEJPGKI = JPKBOOFIGLF;
		obj7.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 673f, 76, oEIICEJPGKI, UITweener.Method.Linear);
		AGMEHGCOPBM.NFLKPCIHOPJ(-112, TweenAnimator.MNAIKKJDPLK.Rotation, MNGKIFNOOAF.gameObject, JCAFFELIFAO * 1495f, ILGGEHIILNI, 1195f, -31, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		int eBPMMNFLPMP = -18;
		LDHOBENLGAH = new Vector3(1219f, 103f, 534f);
		FEBNJNGGBMP = new Vector3(521f, 1356f, 358f);
		KAKIEOHOGOH = new Vector3(891f, 592f, 1737f);
		AGMEHGCOPBM.AddTween(69, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 1750f, 1654f, -3, 1522f, (UITweener.Method)7, UITweener.Style.Once, 0);
		AGMEHGCOPBM.FEHALDPLGDB(-120, TweenAnimator.MNAIKKJDPLK.Color, BGPBNIJPOKM.gameObject, JCAFFELIFAO, 1242f, 103f, 21, 152f, (UITweener.Method)6);
		AGMEHGCOPBM.AddTween(-38, TweenAnimator.MNAIKKJDPLK.Rotation, BMENLOAIDDB.gameObject, JCAFFELIFAO, 1389f, 1873f, 98, 85f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.FEHALDPLGDB(115, TweenAnimator.MNAIKKJDPLK.Color, MDDIOFPDLCB.gameObject, JCAFFELIFAO, 1267f, 1134f, -123, 1699f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		TweenAnimator obj8 = AGMEHGCOPBM;
		iNFLHPGMEOB = 56;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = CLPNODBKDCP;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = FEBNJNGGBMP;
		iIMDKHJAJGO = KAKIEOHOGOH;
		obj8.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 1118f, -120, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.NFLKPCIHOPJ(19, TweenAnimator.MNAIKKJDPLK.Position, CLPNODBKDCP, JCAFFELIFAO * 992f, LDHOBENLGAH, 1447f, -126, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		AGMEHGCOPBM.MNEFMODDFFK(-70, TweenAnimator.MNAIKKJDPLK.Position, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 1324f, 603f, 63, 229f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		AGMEHGCOPBM.MNEFMODDFFK(-118, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 1207f, 910f, 6, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.BPEKAKFKCIG(-54, TweenAnimator.MNAIKKJDPLK.Alpha, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 1984f, 160f, -52, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.BPEKAKFKCIG(85, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 1481f, 542f, 35, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.NFLKPCIHOPJ(24, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 834f, 788f, -66, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.NFLKPCIHOPJ(-79, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 78f, 854f, 8, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		AGMEHGCOPBM.BPEKAKFKCIG(41, TweenAnimator.MNAIKKJDPLK.Scale, ADONBKGNGCG.gameObject, JCAFFELIFAO, 536f, 1951f, 93, 1188f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.MNEFMODDFFK(-117, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, LKCHKLPFEKM.gameObject, JCAFFELIFAO, 1440f, 1727f, 73, 314f, (UITweener.Method)7);
		AGMEHGCOPBM.AddTween(-22, TweenAnimator.MNAIKKJDPLK.Position, JMBCFGBLADP.gameObject, JCAFFELIFAO, 1957f, 737f, 0, 923f, (UITweener.Method)8);
		TweenAnimator obj9 = AGMEHGCOPBM;
		iNFLHPGMEOB = -46;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		fLKBAPLOPCF = NKJBDMDMMCH;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = CFBLEPANEML;
		oEIICEJPGKI = AECNIEBBNNI;
		obj9.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 15f, -92, oEIICEJPGKI, UITweener.Method.Linear);
		AGMEHGCOPBM.FEHALDPLGDB(112, TweenAnimator.MNAIKKJDPLK.Rotation, NKJBDMDMMCH, JCAFFELIFAO * 249f, BCJHNKGKNDM, 232f, -91, null, (UITweener.Method)7);
		AGMEHGCOPBM.MNEFMODDFFK(122, TweenAnimator.MNAIKKJDPLK.Rotation, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 570f, 1022f, 62, 1459f, UITweener.Method.Linear, UITweener.Style.Loop);
		AGMEHGCOPBM.MNEFMODDFFK(-75, TweenAnimator.MNAIKKJDPLK.Rotation, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 1934f, 1367f, 32, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.FEHALDPLGDB(178, TweenAnimator.MNAIKKJDPLK.Scale, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 416f, 1301f, -60, null, (UITweener.Method)8, UITweener.Style.Loop);
		AGMEHGCOPBM.BPEKAKFKCIG(86, TweenAnimator.MNAIKKJDPLK.Scale, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 1292f, 97f, -45, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.BPEKAKFKCIG(107, TweenAnimator.MNAIKKJDPLK.Rotation, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 1067f, 1556f, -85, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		AGMEHGCOPBM.FEHALDPLGDB(-186, TweenAnimator.MNAIKKJDPLK.Scale, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 1870f, 767f, 154, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		AGMEHGCOPBM.NFLKPCIHOPJ(-37, TweenAnimator.MNAIKKJDPLK.Alpha, EMHGDFGBNFA.gameObject, JCAFFELIFAO, 1002f, 1502f, eBPMMNFLPMP, 1498f, UITweener.Method.EaseOut);
		AGMEHGCOPBM.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Color, HLPPHFIEGBL.gameObject, JCAFFELIFAO, 423f, 1903f, eBPMMNFLPMP, 1545f);
		TweenAnimator obj10 = AGMEHGCOPBM;
		iNFLHPGMEOB = -127;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = DMPBNBPBDFD;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = IMGIAAKCJEB;
		iIMDKHJAJGO = DNFAJJEAGFN;
		obj10.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 1496f, eBPMMNFLPMP, iIMDKHJAJGO, UITweener.Method.Linear);
		AGMEHGCOPBM.NFLKPCIHOPJ(54, TweenAnimator.MNAIKKJDPLK.Rotation, DMPBNBPBDFD, JCAFFELIFAO * 122f, IMDMCFKEDJL, 1186f, -141, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
	}

	private void BJODOOIPPOD()
	{
		CPBDKKGIOHP = BFLBNOPDOAE.transform.localScale;
		CBHDKEFHFMP = CPBDKKGIOHP.MultiplyXY(161f);
		LPFGKALCGML = CPBDKKGIOHP.MultiplyXY(221f);
		HJPMJMKOCLG = FLKBAPLOPCF.transform.localPosition;
		NILGABEFPAL = HJPMJMKOCLG.AddY(1265f);
		DHCNHBGJLFL = HJPMJMKOCLG.AddY(687f);
	}

	private void ADDPJHEAPBP()
	{
		FFDCEACBGOC();
		EGJDKKHNHJK();
		if (GPABKIOEGKM == NKHJBLBAAEB.Promotion)
		{
			ODCAOAHHBAG(ref KDBGAMFIELL);
			int oFDMBFAPAAC = NOEEGFDDAIP(ref KDBGAMFIELL);
			LDNGAJMBPNM(ref KDBGAMFIELL, oFDMBFAPAAC);
			PGIEENOKEGE(ref KDBGAMFIELL);
			KDBGAMFIELL.PlayTweens();
		}
		else if (GPABKIOEGKM == NKHJBLBAAEB.Demotion)
		{
			ODCAOAHHBAG(ref ACCCJBDCDCK);
			int oFDMBFAPAAC2 = NOEEGFDDAIP(ref ACCCJBDCDCK);
			LDNGAJMBPNM(ref ACCCJBDCDCK, oFDMBFAPAAC2);
			PGIEENOKEGE(ref ACCCJBDCDCK);
			ACCCJBDCDCK.PlayTweens();
		}
		else
		{
			ODCAOAHHBAG(ref EMINBMPHPFJ);
			int oFDMBFAPAAC3 = NBEABDDNFBN(ref EMINBMPHPFJ);
			LDNGAJMBPNM(ref EMINBMPHPFJ, oFDMBFAPAAC3, false);
			PGIEENOKEGE(ref EMINBMPHPFJ);
			EMINBMPHPFJ.PlayTweens();
		}
	}

	public virtual void PEIILMKDGBK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JEFBKLNGGCN));
		CCODGCEOMOP.onReposition = delegate
		{
			float num = Mathf.Abs(ENAGBHIDGNC.transform.localPosition.y);
			bool flag = Singleton<GameVariables>.instance.LeagueGoDownPercent(KNNEGKLGBKO) > 0f;
			float num2 = 209f + num + ((!flag) ? 0f : 104f) + 220f;
			JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num);
			KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num2);
			MGEGMLELNFD.transform.localPosition = MGEGMLELNFD.transform.localPosition.ReplaceY(num2 / 2f);
			ADDPJHEAPBP();
		};
	}

	private void FFDCEACBGOC()
	{
		GFCGJNJCOCC.alpha = 0f;
		JKGDFGAPCEC.alpha = 0f;
		MJKICJCNBEC.alpha = 0f;
		JJADELOKMOP.alpha = 0f;
		JPCIACBHGHO.alpha = 0f;
		MHKEBMNCCEO.alpha = 0f;
		FNGBLDCOOKN.alpha = 0f;
		MNGKIFNOOAF.alpha = 0f;
		MDDIOFPDLCB.alpha = 0f;
		BGPBNIJPOKM.alpha = 0f;
		BMENLOAIDDB.alpha = 0f;
		BJPGJFFOICH.alpha = 0f;
		JMBCFGBLADP.alpha = 0f;
		ADONBKGNGCG.alpha = 0f;
		LKCHKLPFEKM.alpha = 0f;
		JDJENEHFHKE.alpha = 0f;
		KHPDFLPPMDD.alpha = 0f;
		GEAMGMBNGNE.alpha = 0f;
		BFLBNOPDOAE.alpha = 0f;
		APIDNBIHEFB.alpha = 0f;
		MEKIBLPANJI.alpha = 0f;
		NOPEIEHIJIA.alpha = 0f;
		PIMPLAINMJN.alpha = 0f;
		HLPPHFIEGBL.alpha = 0f;
		EMHGDFGBNFA.alpha = 0f;
	}

	private int NBEABDDNFBN(ref TweenAnimator AGMEHGCOPBM)
	{
		float num = 0.7f;
		AGMEHGCOPBM.AddTween(30, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, DCIKANJJFIJ * 0.33f, 0f, 0f, -1, 0f);
		AGMEHGCOPBM.AddTween(51, TweenAnimator.MNAIKKJDPLK.Alpha, BFLBNOPDOAE.gameObject, FGIPPNFFPEL, 1f, 0f, 30);
		TweenAnimator obj = AGMEHGCOPBM;
		int iNFLHPGMEOB = 52;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = BFLBNOPDOAE.gameObject;
		float jCAFFELIFAO = JCAFFELIFAO;
		object iIMDKHJAJGO = CBHDKEFHFMP;
		object oEIICEJPGKI = Vector3.one;
		obj.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 0f, 30, oEIICEJPGKI, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(53, TweenAnimator.MNAIKKJDPLK.Scale, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 0.5f, CPBDKKGIOHP, 0f, 52, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(54, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 30);
		TweenAnimator obj2 = AGMEHGCOPBM;
		iNFLHPGMEOB = 55;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = PIMPLAINMJN.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = JBOLDEGFJJP;
		iIMDKHJAJGO = Vector3.one;
		obj2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 0f, 30, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(56, TweenAnimator.MNAIKKJDPLK.Scale, PIMPLAINMJN.gameObject, JCAFFELIFAO * 0.5f, AGGGPHFGJDI, 0f, 55, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(57, TweenAnimator.MNAIKKJDPLK.Alpha, NOPEIEHIJIA.gameObject, HKJHFGJIMIL, 0.3f, 0f, 52);
		AGMEHGCOPBM.AddTween(59, TweenAnimator.MNAIKKJDPLK.Alpha, NOPEIEHIJIA.gameObject, num + JCAFFELIFAO * 0.5f, 0f, 0f, 57);
		TweenAnimator obj3 = AGMEHGCOPBM;
		iNFLHPGMEOB = 60;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = NOPEIEHIJIA.gameObject;
		jCAFFELIFAO = num + FGIPPNFFPEL + JCAFFELIFAO * 0.5f;
		iIMDKHJAJGO = LPFGKALCGML;
		oEIICEJPGKI = CBHDKEFHFMP;
		obj3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 0f, 52, oEIICEJPGKI, UITweener.Method.Linear);
		AGMEHGCOPBM.AddTween(61, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 60);
		AGMEHGCOPBM.AddTween(62, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 0f, 0f, 61);
		AGMEHGCOPBM.AddTween(63, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 0f, 0f, 62);
		AGMEHGCOPBM.AddTween(64, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1f, 0f, 63);
		AGMEHGCOPBM.AddTween(65, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 64);
		AGMEHGCOPBM.AddTween(66, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 0f, 0f, 65);
		AGMEHGCOPBM.AddTween(67, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 0f, 0f, 66);
		AGMEHGCOPBM.AddTween(68, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1f, 0f, 67);
		AGMEHGCOPBM.AddTween(69, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 68);
		AGMEHGCOPBM.AddTween(70, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 0f, 0f, 69);
		AGMEHGCOPBM.AddTween(71, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 2f, NGPFDFJACCJ, 0f, 60, null, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(72, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 1f, MNFNJDCCCCM, 0f, 71, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(73, TweenAnimator.MNAIKKJDPLK.Alpha, KHPDFLPPMDD.gameObject, JCAFFELIFAO * 1.5f, 1f, 0f, 60, 0f);
		TweenAnimator obj4 = AGMEHGCOPBM;
		iNFLHPGMEOB = 74;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = KHPDFLPPMDD.gameObject;
		jCAFFELIFAO = JCAFFELIFAO * 2f;
		oEIICEJPGKI = PEHEPDFKOMI;
		iIMDKHJAJGO = LOJDMHIPKCI;
		obj4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 0f, 60, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(75, TweenAnimator.MNAIKKJDPLK.Position, KHPDFLPPMDD.gameObject, JCAFFELIFAO * 1f, BLJBHFBKKHO, 0f, 74, null, UITweener.Method.EaseOut);
		return 60;
	}

	private int NOEEGFDDAIP(ref TweenAnimator AGMEHGCOPBM)
	{
		float num = 0.7f;
		bool flag = GPABKIOEGKM == NKHJBLBAAEB.Demotion;
		GameObject gameObject = ((!flag) ? KHPDFLPPMDD.gameObject : GEAMGMBNGNE.gameObject);
		Vector3 vector = ((!flag) ? BLJBHFBKKHO : CNFGKCMFFOC);
		Vector3 vector2 = ((!flag) ? PEHEPDFKOMI : FOOBFBOEABO);
		Vector3 vector3 = ((!flag) ? LOJDMHIPKCI : JCIKBMFOPIC);
		AGMEHGCOPBM.AddTween(30, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, DCIKANJJFIJ, 1f, 0f, -1, 0f);
		AGMEHGCOPBM.AddTween(31, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, DCIKANJJFIJ, 1f, 0f, -1, 0f);
		AGMEHGCOPBM.AddTween(32, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, FGIPPNFFPEL, 1f, 0f, 30);
		AGMEHGCOPBM.AddTween(33, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, HKJHFGJIMIL, 0f, 0f, 32);
		AGMEHGCOPBM.AddTween(34, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, FGIPPNFFPEL, 0f, 0f, 33);
		AGMEHGCOPBM.AddTween(35, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, HKJHFGJIMIL, 1f, 0f, 34);
		AGMEHGCOPBM.AddTween(36, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, FGIPPNFFPEL, 1f, 0f, 35);
		AGMEHGCOPBM.AddTween(37, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, HKJHFGJIMIL, 0f, 0f, 36);
		AGMEHGCOPBM.AddTween(38, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, FGIPPNFFPEL, 0f, 0f, 37);
		AGMEHGCOPBM.AddTween(39, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, HKJHFGJIMIL, 1f, 0f, 38);
		AGMEHGCOPBM.AddTween(40, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, FGIPPNFFPEL, 1f, 0f, 39);
		AGMEHGCOPBM.AddTween(41, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, FGIPPNFFPEL, 1f, 0f, 30);
		AGMEHGCOPBM.AddTween(42, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, HKJHFGJIMIL, 0f, 0f, 32);
		AGMEHGCOPBM.AddTween(43, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, FGIPPNFFPEL, 0f, 0f, 33);
		AGMEHGCOPBM.AddTween(44, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, HKJHFGJIMIL, 1f, 0f, 34);
		AGMEHGCOPBM.AddTween(45, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, FGIPPNFFPEL, 1f, 0f, 35);
		AGMEHGCOPBM.AddTween(46, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, HKJHFGJIMIL, 0f, 0f, 36);
		AGMEHGCOPBM.AddTween(47, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, FGIPPNFFPEL, 0f, 0f, 37);
		AGMEHGCOPBM.AddTween(48, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, HKJHFGJIMIL, 1f, 0f, 38);
		AGMEHGCOPBM.AddTween(49, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, FGIPPNFFPEL, 0f, 0f, 55);
		AGMEHGCOPBM.AddTween(50, TweenAnimator.MNAIKKJDPLK.Alpha, MEKIBLPANJI.gameObject, FGIPPNFFPEL, 0f, 0f, 48);
		AGMEHGCOPBM.AddTween(51, TweenAnimator.MNAIKKJDPLK.Alpha, BFLBNOPDOAE.gameObject, FGIPPNFFPEL, 1f, 0f, 40);
		TweenAnimator obj = AGMEHGCOPBM;
		int iNFLHPGMEOB = 52;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = BFLBNOPDOAE.gameObject;
		float jCAFFELIFAO = JCAFFELIFAO;
		object iIMDKHJAJGO = CBHDKEFHFMP;
		object oEIICEJPGKI = Vector3.one;
		obj.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 0f, 40, oEIICEJPGKI, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(53, TweenAnimator.MNAIKKJDPLK.Scale, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 0.5f, CPBDKKGIOHP, 0f, 52, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(54, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 40);
		TweenAnimator obj2 = AGMEHGCOPBM;
		iNFLHPGMEOB = 55;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = PIMPLAINMJN.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = JBOLDEGFJJP;
		iIMDKHJAJGO = Vector3.one;
		obj2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 0f, 40, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(56, TweenAnimator.MNAIKKJDPLK.Scale, PIMPLAINMJN.gameObject, JCAFFELIFAO * 0.5f, AGGGPHFGJDI, 0f, 55, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(57, TweenAnimator.MNAIKKJDPLK.Alpha, NOPEIEHIJIA.gameObject, HKJHFGJIMIL, 0.3f, 0f, 52);
		AGMEHGCOPBM.AddTween(59, TweenAnimator.MNAIKKJDPLK.Alpha, NOPEIEHIJIA.gameObject, num + JCAFFELIFAO * 0.5f, 0f, 0f, 57);
		TweenAnimator obj3 = AGMEHGCOPBM;
		iNFLHPGMEOB = 60;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = NOPEIEHIJIA.gameObject;
		jCAFFELIFAO = num + FGIPPNFFPEL + JCAFFELIFAO * 0.5f;
		iIMDKHJAJGO = LPFGKALCGML;
		oEIICEJPGKI = CBHDKEFHFMP;
		obj3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 0f, 52, oEIICEJPGKI, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(61, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 60);
		AGMEHGCOPBM.AddTween(62, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 0f, 0f, 61);
		AGMEHGCOPBM.AddTween(63, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 0f, 0f, 62);
		AGMEHGCOPBM.AddTween(64, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1f, 0f, 63);
		AGMEHGCOPBM.AddTween(65, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 64);
		AGMEHGCOPBM.AddTween(66, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 0f, 0f, 65);
		AGMEHGCOPBM.AddTween(67, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 0f, 0f, 66);
		AGMEHGCOPBM.AddTween(68, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1f, 0f, 67);
		AGMEHGCOPBM.AddTween(69, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1f, 0f, 68);
		AGMEHGCOPBM.AddTween(70, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 0f, 0f, 69);
		AGMEHGCOPBM.AddTween(71, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 2f, NGPFDFJACCJ, 0f, 60, null, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(72, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 1f, MNFNJDCCCCM, 0f, 71, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(73, TweenAnimator.MNAIKKJDPLK.Alpha, gameObject, JCAFFELIFAO * 1.5f, 1f, 0f, 60, 0f);
		TweenAnimator obj4 = AGMEHGCOPBM;
		iNFLHPGMEOB = 74;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = gameObject;
		jCAFFELIFAO = JCAFFELIFAO * 2f;
		oEIICEJPGKI = vector2;
		iIMDKHJAJGO = vector3;
		obj4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 0f, 60, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(75, TweenAnimator.MNAIKKJDPLK.Position, gameObject, JCAFFELIFAO * 1f, vector, 0f, 74, null, UITweener.Method.EaseOut);
		return 60;
	}

	private void ODCAOAHHBAG(ref TweenAnimator AGMEHGCOPBM)
	{
		if (AGMEHGCOPBM == null)
		{
			AGMEHGCOPBM = base.gameObject.AddComponent<TweenAnimator>();
			AGMEHGCOPBM.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			AGMEHGCOPBM.BEOAHFDJEMD.Clear();
		}
	}

	private void KDAENCDLEFH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (GPABKIOEGKM == NKHJBLBAAEB.Promotion)
			{
				KDBGAMFIELL.FinishTweens();
			}
			else if (GPABKIOEGKM == NKHJBLBAAEB.Demotion)
			{
				ACCCJBDCDCK.FinishTweens();
			}
			else
			{
				EMINBMPHPFJ.FinishTweens();
			}
		}
	}

	public void ShowDialog(League ELCGHEGDBEK, League NJFHKOHJNAG, int BOMMOMLJGLI)
	{
		KNNEGKLGBKO = NJFHKOHJNAG;
		OJLHIJEHJJO = ELCGHEGDBEK;
		HLLEIILLCIC = BOMMOMLJGLI;
		GPABKIOEGKM = ((NJFHKOHJNAG == ELCGHEGDBEK) ? NKHJBLBAAEB.Finished : ((NJFHKOHJNAG > ELCGHEGDBEK) ? NKHJBLBAAEB.Promotion : NKHJBLBAAEB.Demotion));
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void BPFIHIDAEGK()
	{
		CPIIHOJMLMJ();
		EGJDKKHNHJK();
		if (GPABKIOEGKM == (NKHJBLBAAEB)6)
		{
			LKMJEIJPADN(ref KDBGAMFIELL);
			int oFDMBFAPAAC = NOEEGFDDAIP(ref KDBGAMFIELL);
			LDNGAJMBPNM(ref KDBGAMFIELL, oFDMBFAPAAC);
			PGIEENOKEGE(ref KDBGAMFIELL);
			KDBGAMFIELL.GDCCFEDJFAF();
		}
		else if (GPABKIOEGKM == NKHJBLBAAEB.Demotion)
		{
			ODCAOAHHBAG(ref ACCCJBDCDCK);
			int oFDMBFAPAAC2 = NOEEGFDDAIP(ref ACCCJBDCDCK);
			LDNGAJMBPNM(ref ACCCJBDCDCK, oFDMBFAPAAC2);
			PGIEENOKEGE(ref ACCCJBDCDCK);
			ACCCJBDCDCK.AGFMCNDAEEC();
		}
		else
		{
			ODCAOAHHBAG(ref EMINBMPHPFJ);
			int oFDMBFAPAAC3 = NBEABDDNFBN(ref EMINBMPHPFJ);
			LAGFNMNNDDI(ref EMINBMPHPFJ, oFDMBFAPAAC3, false);
			PGIEENOKEGE(ref EMINBMPHPFJ);
			EMINBMPHPFJ.OKEBGBENAJF();
		}
	}

	private int NGPJNJDJNFH(ref TweenAnimator AGMEHGCOPBM)
	{
		float num = 1756f;
		AGMEHGCOPBM.NFLKPCIHOPJ(34, TweenAnimator.MNAIKKJDPLK.Rotation, APIDNBIHEFB.gameObject, DCIKANJJFIJ * 1187f, 192f, 757f, -1, 632f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		AGMEHGCOPBM.MNEFMODDFFK(-51, TweenAnimator.MNAIKKJDPLK.TextCounter, BFLBNOPDOAE.gameObject, FGIPPNFFPEL, 1157f, 154f, 125, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		TweenAnimator obj = AGMEHGCOPBM;
		int iNFLHPGMEOB = -68;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		GameObject nIHOBEAHEKJ = BFLBNOPDOAE.gameObject;
		float jCAFFELIFAO = JCAFFELIFAO;
		object iIMDKHJAJGO = CBHDKEFHFMP;
		object oEIICEJPGKI = Vector3.one;
		obj.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 1303f, -102, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
		AGMEHGCOPBM.MNEFMODDFFK(73, TweenAnimator.MNAIKKJDPLK.Alpha, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 725f, CPBDKKGIOHP, 909f, -20, null, (UITweener.Method)7, UITweener.Style.Loop);
		AGMEHGCOPBM.AddTween(91, TweenAnimator.MNAIKKJDPLK.Scale, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 797f, 235f, 16, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		TweenAnimator obj2 = AGMEHGCOPBM;
		iNFLHPGMEOB = 108;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = PIMPLAINMJN.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = JBOLDEGFJJP;
		iIMDKHJAJGO = Vector3.one;
		obj2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 1614f, -56, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop);
		AGMEHGCOPBM.MNEFMODDFFK(127, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PIMPLAINMJN.gameObject, JCAFFELIFAO * 1154f, AGGGPHFGJDI, 354f, -48, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.BPEKAKFKCIG(64, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, NOPEIEHIJIA.gameObject, HKJHFGJIMIL, 158f, 1395f, -62, null, (UITweener.Method)6);
		AGMEHGCOPBM.AddTween(111, TweenAnimator.MNAIKKJDPLK.Color, NOPEIEHIJIA.gameObject, num + JCAFFELIFAO * 576f, 1543f, 1586f, 122, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		TweenAnimator obj3 = AGMEHGCOPBM;
		iNFLHPGMEOB = 120;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = NOPEIEHIJIA.gameObject;
		jCAFFELIFAO = num + FGIPPNFFPEL + JCAFFELIFAO * 948f;
		iIMDKHJAJGO = LPFGKALCGML;
		oEIICEJPGKI = CBHDKEFHFMP;
		obj3.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, iIMDKHJAJGO, 1583f, 108, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.MNEFMODDFFK(-55, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1514f, 322f, -109, null, UITweener.Method.Linear);
		AGMEHGCOPBM.BPEKAKFKCIG(-94, TweenAnimator.MNAIKKJDPLK.Position, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 692f, 1541f, -108, null, (UITweener.Method)8);
		AGMEHGCOPBM.AddTween(2, TweenAnimator.MNAIKKJDPLK.Position, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1619f, 439f, 39, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		AGMEHGCOPBM.NFLKPCIHOPJ(-54, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1110f, 897f, 57, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.FEHALDPLGDB(114, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1829f, 1963f, -39, null, (UITweener.Method)7, UITweener.Style.Loop);
		AGMEHGCOPBM.AddTween(71, TweenAnimator.MNAIKKJDPLK.TextCounter, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1966f, 1521f, 60, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		AGMEHGCOPBM.NFLKPCIHOPJ(-5, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 473f, 947f, -97, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.BPEKAKFKCIG(-42, TweenAnimator.MNAIKKJDPLK.Rotation, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 493f, 190f, 58, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		AGMEHGCOPBM.MNEFMODDFFK(-44, TweenAnimator.MNAIKKJDPLK.Alpha, PIMPLAINMJN.gameObject, FGIPPNFFPEL, 1575f, 637f, -66, null, (UITweener.Method)7);
		AGMEHGCOPBM.BPEKAKFKCIG(12, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PIMPLAINMJN.gameObject, HKJHFGJIMIL, 1965f, 359f, 84, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.MNEFMODDFFK(14, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 404f, NGPFDFJACCJ, 1260f, 16, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		AGMEHGCOPBM.FEHALDPLGDB(-63, TweenAnimator.MNAIKKJDPLK.Position, BFLBNOPDOAE.gameObject, JCAFFELIFAO * 388f, MNFNJDCCCCM, 61f, 10, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		AGMEHGCOPBM.AddTween(-80, TweenAnimator.MNAIKKJDPLK.TextCounter, KHPDFLPPMDD.gameObject, JCAFFELIFAO * 1555f, 1110f, 901f, -13, 1827f, UITweener.Method.Linear);
		TweenAnimator obj4 = AGMEHGCOPBM;
		iNFLHPGMEOB = -59;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = KHPDFLPPMDD.gameObject;
		jCAFFELIFAO = JCAFFELIFAO * 1323f;
		oEIICEJPGKI = PEHEPDFKOMI;
		iIMDKHJAJGO = LOJDMHIPKCI;
		obj4.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, jCAFFELIFAO, oEIICEJPGKI, 200f, 20, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop);
		AGMEHGCOPBM.BPEKAKFKCIG(102, TweenAnimator.MNAIKKJDPLK.Rotation, KHPDFLPPMDD.gameObject, JCAFFELIFAO * 1582f, BLJBHFBKKHO, 1935f, 91, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		return 10;
	}

	public override void AIKPJGLHLLO()
	{
		if (EFDCDBOCBBI.enabled)
		{
			JEFBKLNGGCN(DMPBNBPBDFD.gameObject);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		CCODGCEOMOP.onReposition = delegate
		{
			float num = Mathf.Abs(ENAGBHIDGNC.transform.localPosition.y);
			bool flag = Singleton<GameVariables>.instance.LeagueGoDownPercent(KNNEGKLGBKO) > 0f;
			float num2 = 209f + num + ((!flag) ? 0f : 104f) + 220f;
			JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num);
			KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num2);
			MGEGMLELNFD.transform.localPosition = MGEGMLELNFD.transform.localPosition.ReplaceY(num2 / 2f);
			ADDPJHEAPBP();
		};
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void IELDBMNCJJC()
	{
		CPBDKKGIOHP = BFLBNOPDOAE.transform.localScale;
		CBHDKEFHFMP = CPBDKKGIOHP.MultiplyXY(1.5f);
		LPFGKALCGML = CPBDKKGIOHP.MultiplyXY(2f);
		HJPMJMKOCLG = FLKBAPLOPCF.transform.localPosition;
		NILGABEFPAL = HJPMJMKOCLG.AddY(13f);
		DHCNHBGJLFL = HJPMJMKOCLG.AddY(-20f);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float num = Mathf.Abs(ENAGBHIDGNC.transform.localPosition.y);
		bool flag = Singleton<GameVariables>.instance.LeagueGoDownPercent(KNNEGKLGBKO) > 0f;
		float num2 = 209f + num + ((!flag) ? 0f : 104f) + 220f;
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY(0f - num);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(num2);
		MGEGMLELNFD.transform.localPosition = MGEGMLELNFD.transform.localPosition.ReplaceY(num2 / 2f);
		ADDPJHEAPBP();
	}

	private void LDNGAJMBPNM(ref TweenAnimator AGMEHGCOPBM, int OFDMBFAPAAC, bool OCAILDBABGH = true)
	{
		AGMEHGCOPBM.AddTween(80, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, 3f * FGIPPNFFPEL + 2f * HKJHFGJIMIL, 0f, 0f, OFDMBFAPAAC, 0f);
		AGMEHGCOPBM.AddTween(81, TweenAnimator.MNAIKKJDPLK.Alpha, GFCGJNJCOCC.gameObject, JCAFFELIFAO, 1f, 0f, 80, 0f);
		AGMEHGCOPBM.AddTween(84, TweenAnimator.MNAIKKJDPLK.Alpha, JKGDFGAPCEC.gameObject, JCAFFELIFAO, 1f, 0f, 80, 0f);
		TweenAnimator obj = AGMEHGCOPBM;
		int iNFLHPGMEOB = 85;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject fLKBAPLOPCF = FLKBAPLOPCF;
		float jCAFFELIFAO = JCAFFELIFAO;
		object iIMDKHJAJGO = NILGABEFPAL;
		object oEIICEJPGKI = DHCNHBGJLFL;
		obj.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 0f, 80, oEIICEJPGKI, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(86, TweenAnimator.MNAIKKJDPLK.Position, FLKBAPLOPCF, JCAFFELIFAO * 0.5f, HJPMJMKOCLG, 0f, 85, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(87, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 0f, 0f, 94, 0f);
		AGMEHGCOPBM.AddTween(88, TweenAnimator.MNAIKKJDPLK.Alpha, MJKICJCNBEC.gameObject, JCAFFELIFAO, 1f, 0f, 87, 0f);
		AGMEHGCOPBM.AddTween(89, TweenAnimator.MNAIKKJDPLK.Alpha, JJADELOKMOP.gameObject, JCAFFELIFAO, 1f, 0f, 87, 0f);
		TweenAnimator obj2 = AGMEHGCOPBM;
		iNFLHPGMEOB = 90;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = MJKICJCNBEC.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = NKHDKBHKJCK;
		iIMDKHJAJGO = ODINEIOOPGG;
		obj2.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 0f, 87, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(91, TweenAnimator.MNAIKKJDPLK.Position, MJKICJCNBEC.gameObject, JCAFFELIFAO * 0.5f, GCFHIMDABME, 0f, 90, null, UITweener.Method.EaseOut);
		TweenAnimator obj3 = AGMEHGCOPBM;
		iNFLHPGMEOB = 92;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = JJADELOKMOP.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = GDLDCEOMIEA;
		oEIICEJPGKI = HGIHICGBHCF;
		obj3.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 0f, 87, oEIICEJPGKI, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(93, TweenAnimator.MNAIKKJDPLK.Position, JJADELOKMOP.gameObject, JCAFFELIFAO * 0.5f, HPBHLFPDKDE, 0f, 92, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(94, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 0f, 0f, 80, 0f);
		AGMEHGCOPBM.AddTween(95, TweenAnimator.MNAIKKJDPLK.Alpha, JPCIACBHGHO.gameObject, JCAFFELIFAO, 1f, 0f, 94, 0f);
		TweenAnimator obj4 = AGMEHGCOPBM;
		iNFLHPGMEOB = 96;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = JPCIACBHGHO.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = MFBMBBDPGMO;
		iIMDKHJAJGO = JFKPCDAKICI;
		obj4.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 0f, 94, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(97, TweenAnimator.MNAIKKJDPLK.Position, JPCIACBHGHO.gameObject, JCAFFELIFAO * 0.5f, OLHBMBFPABL, 0f, 96, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(98, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 0f, 0f, 87, 0f);
		AGMEHGCOPBM.AddTween(99, TweenAnimator.MNAIKKJDPLK.Alpha, FNGBLDCOOKN.gameObject, JCAFFELIFAO, 1f, 0f, 98, 0f);
		TweenAnimator obj5 = AGMEHGCOPBM;
		iNFLHPGMEOB = 100;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = FNGBLDCOOKN.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = KJFCKFODGAI;
		oEIICEJPGKI = GOCPEMACJJE;
		obj5.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 0f, 98, oEIICEJPGKI, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(101, TweenAnimator.MNAIKKJDPLK.Position, FNGBLDCOOKN.gameObject, JCAFFELIFAO * 0.5f, AFLJAGABFFC, 0f, 100, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(102, TweenAnimator.MNAIKKJDPLK.Alpha, MHKEBMNCCEO.gameObject, JCAFFELIFAO, 1f, 0f, 100, 0f);
		AGMEHGCOPBM.AddTween(103, TweenAnimator.MNAIKKJDPLK.Alpha, MNGKIFNOOAF.gameObject, JCAFFELIFAO, 1f, 0f, 100, 0f);
		TweenAnimator obj6 = AGMEHGCOPBM;
		iNFLHPGMEOB = 104;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = MHKEBMNCCEO.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = KDFFFINIABP;
		iIMDKHJAJGO = HMDKKLLOJCO;
		obj6.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 0f, 100, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(105, TweenAnimator.MNAIKKJDPLK.Position, MHKEBMNCCEO.gameObject, JCAFFELIFAO * 0.5f, EAEBDEKPIBG, 0f, 104, null, UITweener.Method.EaseOut);
		TweenAnimator obj7 = AGMEHGCOPBM;
		iNFLHPGMEOB = 106;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = MNGKIFNOOAF.gameObject;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = HDCDICFCMJM;
		oEIICEJPGKI = JPKBOOFIGLF;
		obj7.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 0f, 100, oEIICEJPGKI, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(107, TweenAnimator.MNAIKKJDPLK.Position, MNGKIFNOOAF.gameObject, JCAFFELIFAO * 0.5f, ILGGEHIILNI, 0f, 106, null, UITweener.Method.EaseOut);
		int eBPMMNFLPMP = 124;
		LDHOBENLGAH = new Vector3(-197f, 0f, 0f);
		FEBNJNGGBMP = new Vector3(-197f, 13f, 0f);
		KAKIEOHOGOH = new Vector3(-197f, -25f, 0f);
		AGMEHGCOPBM.AddTween(108, TweenAnimator.MNAIKKJDPLK.Alpha, APIDNBIHEFB.gameObject, CLLOMDNLHDG, 0f, 0f, 98, 0f);
		AGMEHGCOPBM.AddTween(109, TweenAnimator.MNAIKKJDPLK.Alpha, BGPBNIJPOKM.gameObject, JCAFFELIFAO, 1f, 0f, 108, 0f);
		AGMEHGCOPBM.AddTween(110, TweenAnimator.MNAIKKJDPLK.Alpha, BMENLOAIDDB.gameObject, JCAFFELIFAO, 1f, 0f, 108, 0f);
		AGMEHGCOPBM.AddTween(111, TweenAnimator.MNAIKKJDPLK.Alpha, MDDIOFPDLCB.gameObject, JCAFFELIFAO, 1f, 0f, 108, 0f);
		TweenAnimator obj8 = AGMEHGCOPBM;
		iNFLHPGMEOB = 112;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = CLPNODBKDCP;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = FEBNJNGGBMP;
		iIMDKHJAJGO = KAKIEOHOGOH;
		obj8.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 0f, 108, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(113, TweenAnimator.MNAIKKJDPLK.Position, CLPNODBKDCP, JCAFFELIFAO * 0.5f, LDHOBENLGAH, 0f, 112, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(114, TweenAnimator.MNAIKKJDPLK.Alpha, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 0.8f, 0f, 113, 0f);
		AGMEHGCOPBM.AddTween(115, TweenAnimator.MNAIKKJDPLK.Alpha, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 0.2f, 0f, 114);
		AGMEHGCOPBM.AddTween(116, TweenAnimator.MNAIKKJDPLK.Alpha, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 0.8f, 0f, 115);
		AGMEHGCOPBM.AddTween(117, TweenAnimator.MNAIKKJDPLK.Alpha, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 0.2f, 0f, 116);
		AGMEHGCOPBM.AddTween(118, TweenAnimator.MNAIKKJDPLK.Alpha, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 0.8f, 0f, 117);
		AGMEHGCOPBM.AddTween(119, TweenAnimator.MNAIKKJDPLK.Alpha, BJPGJFFOICH.gameObject, FGIPPNFFPEL, 0f, 0f, 118);
		AGMEHGCOPBM.AddTween(121, TweenAnimator.MNAIKKJDPLK.Alpha, ADONBKGNGCG.gameObject, JCAFFELIFAO, 1f, 0f, 113, 0f);
		AGMEHGCOPBM.AddTween(122, TweenAnimator.MNAIKKJDPLK.Alpha, LKCHKLPFEKM.gameObject, JCAFFELIFAO, 1f, 0f, 113, 0f);
		AGMEHGCOPBM.AddTween(123, TweenAnimator.MNAIKKJDPLK.Alpha, JMBCFGBLADP.gameObject, JCAFFELIFAO, 1f, 0f, 113, 0f);
		TweenAnimator obj9 = AGMEHGCOPBM;
		iNFLHPGMEOB = 124;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = NKJBDMDMMCH;
		jCAFFELIFAO = JCAFFELIFAO;
		iIMDKHJAJGO = CFBLEPANEML;
		oEIICEJPGKI = AECNIEBBNNI;
		obj9.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, iIMDKHJAJGO, 0f, 113, oEIICEJPGKI, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(125, TweenAnimator.MNAIKKJDPLK.Position, NKJBDMDMMCH, JCAFFELIFAO * 0.5f, BCJHNKGKNDM, 0f, 124, null, UITweener.Method.EaseOut);
		AGMEHGCOPBM.AddTween(126, TweenAnimator.MNAIKKJDPLK.Alpha, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 0.8f, 0f, 125, 0f);
		AGMEHGCOPBM.AddTween(127, TweenAnimator.MNAIKKJDPLK.Alpha, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 0.2f, 0f, 126);
		AGMEHGCOPBM.AddTween(128, TweenAnimator.MNAIKKJDPLK.Alpha, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 0.8f, 0f, 127);
		AGMEHGCOPBM.AddTween(129, TweenAnimator.MNAIKKJDPLK.Alpha, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 0.2f, 0f, 128);
		AGMEHGCOPBM.AddTween(130, TweenAnimator.MNAIKKJDPLK.Alpha, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 0.8f, 0f, 129);
		AGMEHGCOPBM.AddTween(131, TweenAnimator.MNAIKKJDPLK.Alpha, JDJENEHFHKE.gameObject, FGIPPNFFPEL, 0f, 0f, 130);
		AGMEHGCOPBM.AddTween(132, TweenAnimator.MNAIKKJDPLK.Alpha, EMHGDFGBNFA.gameObject, JCAFFELIFAO, 1f, 0f, eBPMMNFLPMP, 0f);
		AGMEHGCOPBM.AddTween(133, TweenAnimator.MNAIKKJDPLK.Alpha, HLPPHFIEGBL.gameObject, JCAFFELIFAO, 1f, 0f, eBPMMNFLPMP, 0f);
		TweenAnimator obj10 = AGMEHGCOPBM;
		iNFLHPGMEOB = 134;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		fLKBAPLOPCF = DMPBNBPBDFD;
		jCAFFELIFAO = JCAFFELIFAO;
		oEIICEJPGKI = IMGIAAKCJEB;
		iIMDKHJAJGO = DNFAJJEAGFN;
		obj10.AddTween(iNFLHPGMEOB, hADMLJODMKA, fLKBAPLOPCF, jCAFFELIFAO, oEIICEJPGKI, 0f, eBPMMNFLPMP, iIMDKHJAJGO, UITweener.Method.EaseIn);
		AGMEHGCOPBM.AddTween(135, TweenAnimator.MNAIKKJDPLK.Position, DMPBNBPBDFD, JCAFFELIFAO * 0.5f, IMDMCFKEDJL, 0f, 134, null, UITweener.Method.EaseOut);
	}

	public override void InitGUIValues()
	{
		OKMNFHNBMFA.text = Localization.Localize(OKDDKBMLFNC[GPABKIOEGKM].Value1);
		OKMNFHNBMFA.color = ILCAMNAMGLI[GPABKIOEGKM].Value1;
		CCODGCEOMOP.repositionNow = true;
		GFCGJNJCOCC.text = Localization.Localize("ID_FINISHED");
		JKGDFGAPCEC.text = MEJMLNDFDBP.PDDBDAMHIAA(HLLEIILLCIC);
		GFCGJNJCOCC.color = ((GPABKIOEGKM != NKHJBLBAAEB.Promotion) ? Color.white : Colours.greenLeague);
		JKGDFGAPCEC.color = GFCGJNJCOCC.color;
		MJKICJCNBEC.color = ILCAMNAMGLI[GPABKIOEGKM].Value1;
		JJADELOKMOP.color = ILCAMNAMGLI[GPABKIOEGKM].Value1;
		JKGDFGAPCEC.color = ILCAMNAMGLI[GPABKIOEGKM].Value1;
		float num = GFCGJNJCOCC.relativeSize.x * GFCGJNJCOCC.transform.localScale.x + 22f;
		JKGDFGAPCEC.transform.localPosition = new Vector3(num, JKGDFGAPCEC.transform.localPosition.y, JKGDFGAPCEC.transform.localPosition.z);
		num += JKGDFGAPCEC.relativeSize.x * JKGDFGAPCEC.transform.localScale.x;
		FLKBAPLOPCF.transform.localPosition = FLKBAPLOPCF.transform.localPosition.ReplaceX(0f - num / 2f);
		float val = (756f - (num + 64f)) / 2f;
		MJKICJCNBEC.transform.localScale = MJKICJCNBEC.transform.localScale.ReplaceX(val);
		JJADELOKMOP.transform.localScale = JJADELOKMOP.transform.localScale.ReplaceX(val);
		JPCIACBHGHO.text = Localization.LocalizeFormat(OKDDKBMLFNC[GPABKIOEGKM].Value2, ILCAMNAMGLI[GPABKIOEGKM].Value2, GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1, Colours.stringWhite);
		float num2 = ((GPABKIOEGKM != NKHJBLBAAEB.Demotion) ? 55f : 48f);
		JPCIACBHGHO.transform.localScale = new Vector3(num2, num2, 1f);
		val = (744f - (FNGBLDCOOKN.relativeSize.x * FNGBLDCOOKN.transform.localScale.x + 48f)) / 2f;
		MHKEBMNCCEO.transform.localScale = MHKEBMNCCEO.transform.localScale.ReplaceX(val);
		MNGKIFNOOAF.transform.localScale = MNGKIFNOOAF.transform.localScale.ReplaceX(val);
		BMENLOAIDDB.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
		BFLBNOPDOAE.MakePixelPerfect();
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.MultiplyXY(1.44f);
		bool flag = Singleton<GameVariables>.instance.LeagueGoDownPercent(KNNEGKLGBKO) > 0f;
		float num3 = ((!flag) ? 0f : (-104f));
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != NKHJBLBAAEB.Promotion) ? "ID_OK" : "ID_AWESOME");
		HKMJJILBLPH.SetActive(flag);
		DMPBNBPBDFD.transform.localPosition = DMPBNBPBDFD.transform.localPosition.ReplaceY(-120f + num3);
		IMDMCFKEDJL = IMDMCFKEDJL.ReplaceY(-120f + num3);
		IMGIAAKCJEB = IMGIAAKCJEB.ReplaceY(-120f + num3 + 13f);
		DNFAJJEAGFN = DNFAJJEAGFN.ReplaceY(-120f + num3 - 25f);
		APIDNBIHEFB.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[OJLHIJEHJJO].Value2);
		APIDNBIHEFB.MakePixelPerfect();
		APIDNBIHEFB.transform.localScale = APIDNBIHEFB.transform.localScale.MultiplyXY(1.44f);
		MEKIBLPANJI.text = GameVariables.CAOGFCFGFPD[OJLHIJEHJJO].Value1;
		NOPEIEHIJIA.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
		PIMPLAINMJN.text = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
		EFDCDBOCBBI.enabled = false;
		IELDBMNCJJC();
	}

	public override void OnBack()
	{
		if (EFDCDBOCBBI.enabled)
		{
			KDAENCDLEFH(DMPBNBPBDFD.gameObject);
		}
	}

	private void HHBAHEPFBEE()
	{
		CPBDKKGIOHP = BFLBNOPDOAE.transform.localScale;
		CBHDKEFHFMP = CPBDKKGIOHP.MultiplyXY(808f);
		LPFGKALCGML = CPBDKKGIOHP.MultiplyXY(959f);
		HJPMJMKOCLG = FLKBAPLOPCF.transform.localPosition;
		NILGABEFPAL = HJPMJMKOCLG.AddY(1003f);
		DHCNHBGJLFL = HJPMJMKOCLG.AddY(930f);
	}

	private void CPIIHOJMLMJ()
	{
		GFCGJNJCOCC.alpha = 359f;
		JKGDFGAPCEC.alpha = 489f;
		MJKICJCNBEC.alpha = 1022f;
		JJADELOKMOP.alpha = 1894f;
		JPCIACBHGHO.alpha = 1740f;
		MHKEBMNCCEO.alpha = 1536f;
		FNGBLDCOOKN.alpha = 72f;
		MNGKIFNOOAF.alpha = 1905f;
		MDDIOFPDLCB.alpha = 1410f;
		BGPBNIJPOKM.alpha = 1082f;
		BMENLOAIDDB.alpha = 140f;
		BJPGJFFOICH.alpha = 1859f;
		JMBCFGBLADP.alpha = 82f;
		ADONBKGNGCG.alpha = 172f;
		LKCHKLPFEKM.alpha = 533f;
		JDJENEHFHKE.alpha = 1624f;
		KHPDFLPPMDD.alpha = 333f;
		GEAMGMBNGNE.alpha = 1819f;
		BFLBNOPDOAE.alpha = 303f;
		APIDNBIHEFB.alpha = 1662f;
		MEKIBLPANJI.alpha = 1692f;
		NOPEIEHIJIA.alpha = 676f;
		PIMPLAINMJN.alpha = 673f;
		HLPPHFIEGBL.alpha = 1854f;
		EMHGDFGBNFA.alpha = 425f;
	}

	private void JEFBKLNGGCN(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (GPABKIOEGKM == (NKHJBLBAAEB)3)
			{
				KDBGAMFIELL.HLKNEKNIENJ();
			}
			else if (GPABKIOEGKM == NKHJBLBAAEB.Demotion)
			{
				ACCCJBDCDCK.KIOKIAFPHPE();
			}
			else
			{
				EMINBMPHPFJ.KIOKIAFPHPE();
			}
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		BFLBNOPDOAE.mainTexture = null;
		APIDNBIHEFB.mainTexture = null;
		NOPEIEHIJIA.mainTexture = null;
	}

	private void DGEKBFIIPLM(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -50)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampIntro, 1687f);
			if (GPABKIOEGKM == NKHJBLBAAEB.Promotion)
			{
				DNNNFJGLMJC.Play();
			}
			else if (GPABKIOEGKM == NKHJBLBAAEB.Demotion)
			{
				MIJOGDBBMDO.Play();
			}
		}
		if (EAINKPNECEC == -42 || EAINKPNECEC == -69)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-74), 1348f);
		}
		if (EAINKPNECEC == 195)
		{
			EFDCDBOCBBI.enabled = true;
		}
	}

	private void EGJDKKHNHJK()
	{
		BFLBNOPDOAE.transform.localPosition = OOMOGFGELHI;
		NOPEIEHIJIA.transform.localScale = CPBDKKGIOHP;
	}

	private void LKMJEIJPADN(ref TweenAnimator AGMEHGCOPBM)
	{
		if (AGMEHGCOPBM == null)
		{
			AGMEHGCOPBM = base.gameObject.AddComponent<TweenAnimator>();
			AGMEHGCOPBM.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		}
		else
		{
			AGMEHGCOPBM.BEOAHFDJEMD.Clear();
		}
	}
}
