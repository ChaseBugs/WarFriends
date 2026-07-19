using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Overtime : GuiElementSingle<Overtime>
{
	public UISprite ABENDKFKIGH;

	public UISprite PEJFFMLEHFA;

	private TweenAnimator FNOMCHPCOHB;

	private Vector3 BKLKJLFFLKE = new Vector3(500f, 109f, 1f);

	private bool MKALMODMIMP;

	public bool isAnimationFinished
	{
		get
		{
			return MKALMODMIMP;
		}
	}

	public virtual void DJMCADMNEDH()
	{
	}

	private void JNJIJCEPBMN(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 8)
		{
			MKALMODMIMP = false;
		}
	}

	private void LDPHOMJGFJN()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			OCCGGJJCLID();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(LMHPHHLKILP));
		}
	}

	private void HFNAIFBAEMJ()
	{
		MKALMODMIMP = true;
	}

	public virtual void LPKCIHOFMGC()
	{
	}

	public override void InitControls()
	{
		LFKPPLNIMOF();
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Singleton<MatchManager>.instance.OverTimeStarted += HNGKNPEOMHA;
	}

	private void IIPMFKHJGID()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	private void LMDLNDCLNDN()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	[SpecialName]
	public bool HFBKBKCJFMO()
	{
		return MKALMODMIMP;
	}

	public virtual void JBPMEEOHJIH()
	{
	}

	public virtual void IMEOAPEABLG()
	{
		FALOPPGICOB();
		Singleton<GameController>.instance.GameStarted += BMOKJKNLOBG;
		Singleton<MatchManager>.instance.CFEABFIOJMI(MCAJPNPBOKB);
	}

	private void KBEIFLGDKCH()
	{
		float num = 226f;
		float num2 = 451f;
		float kBJEOEEOEFG = 273f;
		float kBJEOEEOEFG2 = 1763f;
		float kALLNCAFIMP = 1061f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 152f, BKLKJLFFLKE.y * 1317f, 1332f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1339f, 559f, 1932f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1757f;
		vector3.z = 197f;
		Vector3 vector4 = localScale * 124f;
		vector4.z = 946f;
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 889f, 1048f, -1, 627f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1726f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 622f, -1, oEIICEJPGKI, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, num2 + num * 338f, vector2, 1009f, 7, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 811f, 1112f, 7, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1714f, 695f, -1, 641f);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 5;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 113f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1264f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, num, vector4, 856f, 7, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, num2 + num * 1139f, localScale, 147f, 5, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-36, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1293f, kALLNCAFIMP, 8, null, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(38, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 414f, kALLNCAFIMP, 26, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(68, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1982f, kALLNCAFIMP, 46, null, (UITweener.Method)6);
		FNOMCHPCOHB.BPEKAKFKCIG(45, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 657f, kALLNCAFIMP, -122, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(10, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 869f, kALLNCAFIMP, 75, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
	}

	private void GAPMEHFNAOI()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	public virtual void NEINEPJDKCL()
	{
		CLABKADKMPB();
		Singleton<GameController>.instance.GameStarted += BMOKJKNLOBG;
		Singleton<MatchManager>.instance.OverTimeStarted += MPLOLPOPNIM;
	}

	[SpecialName]
	public bool DAKFCNOLFPC()
	{
		return MKALMODMIMP;
	}

	private void LCGBJLCDAFA()
	{
		MKALMODMIMP = false;
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	public virtual void OBIBHNFJKHD()
	{
	}

	private void ADGAMJBGCBO(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 69)
		{
			MKALMODMIMP = true;
		}
	}

	public virtual void OJLONNEIBLE()
	{
		AAEGAPOGAMA();
		Singleton<GameController>.instance.GameStarted += AGKEEDJJGNG;
		Singleton<MatchManager>.instance.CFEABFIOJMI(ECKCFLMGMLC);
	}

	private void MEICFOFNGHO(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -100)
		{
			MKALMODMIMP = false;
		}
	}

	public virtual void BNEPKGCDIFH()
	{
	}

	private void NCCGCCNGOJO()
	{
		MKALMODMIMP = false;
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	private void DPNDPEDFLOO()
	{
		MKALMODMIMP = false;
	}

	private void OHICPADKAPE()
	{
		MKALMODMIMP = true;
	}

	private void CEAOHHLNPOM()
	{
		float num = 491f;
		float num2 = 515f;
		float kBJEOEEOEFG = 498f;
		float kBJEOEEOEFG2 = 763f;
		float kALLNCAFIMP = 137f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1014f, BKLKJLFFLKE.y * 1555f, 889f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1632f, 1769f, 766f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 480f;
		vector3.z = 9f;
		Vector3 vector4 = localScale * 144f;
		vector4.z = 1083f;
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1263f, 278f, -1, 39f);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 3;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1148f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 753f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, num2 + num * 457f, vector2, 1705f, 6, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1676f, 595f, 5, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1617f, 1517f, -1, 450f, (UITweener.Method)7, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 57f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 792f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, num, vector4, 1556f, 0, null, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, num2 + num * 1616f, localScale, 1807f, 7, null, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-99, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 237f, kALLNCAFIMP, 2, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(119, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 300f, kALLNCAFIMP, -66, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-65, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1966f, kALLNCAFIMP, 33, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-56, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 395f, kALLNCAFIMP, 111, null, UITweener.Method.EaseIn);
		FNOMCHPCOHB.BPEKAKFKCIG(-74, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 649f, kALLNCAFIMP, -44, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
	}

	private void JHICLADEJAF()
	{
		MKALMODMIMP = false;
	}

	private void LHOAGEOOMKI()
	{
		float num = 1839f;
		float num2 = 810f;
		float kBJEOEEOEFG = 1109f;
		float kBJEOEEOEFG2 = 594f;
		float kALLNCAFIMP = 256f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 817f, BKLKJLFFLKE.y * 827f, 1647f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 686f, 1528f, 295f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 536f;
		vector3.z = 1726f;
		Vector3 vector4 = localScale * 464f;
		vector4.z = 278f;
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 907f, 898f, -1, 24f, (UITweener.Method)7, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 3;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1851f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 779f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, num2 + num * 801f, vector2, 1634f, 3, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Rotation, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1828f, 69f, 0, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 307f, 738f, -1, 1187f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 8f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1475f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(8, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, num, vector4, 361f, 7, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, num2 + num * 1842f, localScale, 130f, 2, null, UITweener.Method.Linear);
		FNOMCHPCOHB.NFLKPCIHOPJ(-21, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 560f, kALLNCAFIMP, 0, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-85, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1814f, kALLNCAFIMP, -121, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-27, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1336f, kALLNCAFIMP, 42, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(114, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1283f, kALLNCAFIMP, 21, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(-14, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1839f, kALLNCAFIMP, 86, null, UITweener.Method.Linear);
	}

	private void FHHOBJNMGDI()
	{
		float num = 1369f;
		float num2 = 1966f;
		float kBJEOEEOEFG = 306f;
		float kBJEOEEOEFG2 = 1156f;
		float kALLNCAFIMP = 1372f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1883f, BKLKJLFFLKE.y * 1051f, 1373f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1926f, 671f, 1351f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 32f;
		vector3.z = 1269f;
		Vector3 vector4 = localScale * 166f;
		vector4.z = 1959f;
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1541f, 1361f, -1, 1870f, UITweener.Method.Linear, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 6;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1590f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 1136f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, num2 + num * 463f, vector2, 1763f, 8, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Color, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 270f, 1786f, 6, null, (UITweener.Method)8);
		FNOMCHPCOHB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1192f, 926f, -1, 1249f, (UITweener.Method)6, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 1502f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 543f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, num, vector4, 1224f, 1, null, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, num2 + num * 1331f, localScale, 1274f, 1, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(127, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 672f, kALLNCAFIMP, 2, null, UITweener.Method.Linear);
		FNOMCHPCOHB.NFLKPCIHOPJ(127, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 765f, kALLNCAFIMP, -84, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(-21, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1231f, kALLNCAFIMP, 86, null, (UITweener.Method)6);
		FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1955f, kALLNCAFIMP, 122, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-21, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 381f, kALLNCAFIMP, 122, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
	}

	public virtual void DBFHCLPIOKH()
	{
	}

	public virtual void LPFPAKGNNIO()
	{
		AAEGAPOGAMA();
		Singleton<GameController>.instance.GameStarted += EMNJNPNBKFL;
		Singleton<MatchManager>.instance.CFEABFIOJMI(CMDPACOBDCK);
	}

	private void HBMJGALNHPA()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			PAMJDKKLOEK();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(MEICFOFNGHO));
		}
	}

	private void LMHPHHLKILP(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 73)
		{
			MKALMODMIMP = false;
		}
	}

	private void AEEGGAIMHMI()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.ODIJFGCDJNH();
	}

	public virtual void PGJDLKDMCHN()
	{
	}

	private void DAACEADIAFD()
	{
		float num = 787f;
		float num2 = 1956f;
		float kBJEOEEOEFG = 1064f;
		float kBJEOEEOEFG2 = 1746f;
		float kALLNCAFIMP = 280f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 138f, BKLKJLFFLKE.y * 428f, 776f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1730f, 1811f, 1315f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1161f;
		vector3.z = 1203f;
		Vector3 vector4 = localScale * 1034f;
		vector4.z = 1801f;
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1596f, 86f, -1, 932f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 7;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 392f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 1677f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, num2 + num * 1320f, vector2, 1305f, 4);
		FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1597f, 972f, 0, null, (UITweener.Method)8);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1488f, 1058f, -1, 1500f, (UITweener.Method)7, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 636f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1758f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, num, vector4, 832f, 0, null, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, num2 + num * 516f, localScale, 805f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(96, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1310f, kALLNCAFIMP, 5, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-92, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 350f, kALLNCAFIMP, 14, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(70, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 431f, kALLNCAFIMP, -17, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1027f, kALLNCAFIMP, 125, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(38, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 916f, kALLNCAFIMP, 25, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
	}

	private void MOGDBEGCPOF()
	{
		float num = 1725f;
		float num2 = 1849f;
		float kBJEOEEOEFG = 383f;
		float kBJEOEEOEFG2 = 550f;
		float kALLNCAFIMP = 1421f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1308f, BKLKJLFFLKE.y * 509f, 1607f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1252f, 678f, 224f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1267f;
		vector3.z = 1493f;
		Vector3 vector4 = localScale * 143f;
		vector4.z = 38f;
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1454f, 304f, -1, 751f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 515f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 644f, -1, oEIICEJPGKI, (UITweener.Method)6);
		FNOMCHPCOHB.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PEJFFMLEHFA.gameObject, num2 + num * 328f, vector2, 237f, 4, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1013f, 602f, 7, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 807f, 526f, -1, 1035f, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 1521f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 145f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, num, vector4, 255f, 7, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, num2 + num * 1338f, localScale, 680f, 2, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(43, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 920f, kALLNCAFIMP, 5, null, UITweener.Method.BounceIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(-110, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1817f, kALLNCAFIMP, -103, null, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(83, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 626f, kALLNCAFIMP, -20, null, (UITweener.Method)7);
		FNOMCHPCOHB.NFLKPCIHOPJ(122, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 75f, kALLNCAFIMP, 56, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(68, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 803f, kALLNCAFIMP, -105, null, UITweener.Method.BounceIn);
	}

	[SpecialName]
	public bool MDINDCEMEGO()
	{
		return MKALMODMIMP;
	}

	public virtual void OKMMGFMKJGG()
	{
	}

	private void KKCOMJNOLJA()
	{
		float num = 210f;
		float num2 = 730f;
		float kBJEOEEOEFG = 1763f;
		float kBJEOEEOEFG2 = 886f;
		float kALLNCAFIMP = 1928f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 194f, BKLKJLFFLKE.y * 1237f, 1984f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1188f, 1020f, 1437f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 750f;
		vector3.z = 601f;
		Vector3 vector4 = localScale * 960f;
		vector4.z = 771f;
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Rotation, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 926f, 1037f, -1, 548f, (UITweener.Method)6);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1717f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 367f, -1, oEIICEJPGKI, (UITweener.Method)6);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, num2 + num * 669f, vector2, 1245f, 8, null, (UITweener.Method)7);
		FNOMCHPCOHB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1505f, 610f, 0, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1411f, 1735f, -1, 400f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 60f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 518f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, num, vector4, 601f, 6, null, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, num2 + num * 413f, localScale, 766f, 6, null, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(-114, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 610f, kALLNCAFIMP, 0, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-34, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 173f, kALLNCAFIMP, -22, null, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(14, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1831f, kALLNCAFIMP, 122, null, UITweener.Method.Linear);
		FNOMCHPCOHB.BPEKAKFKCIG(-24, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 131f, kALLNCAFIMP, -35, null, (UITweener.Method)6);
		FNOMCHPCOHB.NFLKPCIHOPJ(-118, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1450f, kALLNCAFIMP, 22, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
	}

	public virtual void GHJHCKFJEAM()
	{
	}

	public virtual void DOLLFDPMGOD()
	{
	}

	private void HKGECBMNJEL(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 116)
		{
			MKALMODMIMP = false;
		}
	}

	public virtual void KCAFCPAFBMC()
	{
	}

	public virtual void HEEANEFGCCJ()
	{
	}

	private void HNGKNPEOMHA()
	{
		MKALMODMIMP = false;
		FNOMCHPCOHB.PlayTweens();
	}

	private void JHHEOKOMLLD()
	{
		MKALMODMIMP = false;
	}

	private void LPIMFOFDKPH()
	{
		float num = 346f;
		float num2 = 1168f;
		float kBJEOEEOEFG = 155f;
		float kBJEOEEOEFG2 = 1645f;
		float kALLNCAFIMP = 197f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 513f, BKLKJLFFLKE.y * 1660f, 330f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 936f, 824f, 192f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 183f;
		vector3.z = 1107f;
		Vector3 vector4 = localScale * 1732f;
		vector4.z = 1641f;
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 642f, 1044f, -1, 98f);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 5;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 326f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 1251f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, num2 + num * 25f, vector2, 1119f, 5, null, UITweener.Method.Linear);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.TextCounter, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 958f, 1551f, 7, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1990f, 570f, -1, 1688f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 1143f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1035f, -1, iIMDKHJAJGO, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, num, vector4, 1387f, 8, null, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, num2 + num * 1851f, localScale, 409f, 2, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-29, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 400f, kALLNCAFIMP, 1, null, UITweener.Method.BounceOut);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 683f, kALLNCAFIMP, -15, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(73, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1249f, kALLNCAFIMP, -20, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(23, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1276f, kALLNCAFIMP, 94, null, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(49, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1321f, kALLNCAFIMP, -9, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
	}

	private void HAILIAAHHDH(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 14)
		{
			MKALMODMIMP = true;
		}
	}

	private void OACPHGGBKKD()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	private void CMDPACOBDCK()
	{
		MKALMODMIMP = false;
		FNOMCHPCOHB.PlayTweens();
	}

	public virtual void HHJDKKFKKIL()
	{
	}

	public virtual void LNKPEDEGODJ()
	{
	}

	private void LPDIGOIOBEO(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -113)
		{
			MKALMODMIMP = true;
		}
	}

	private void EMNJNPNBKFL()
	{
		MKALMODMIMP = true;
	}

	public virtual void HCMELDFOBCP()
	{
	}

	private void POLGAJPMEDI()
	{
		MKALMODMIMP = true;
	}

	public virtual void OPKPLEGMOPI()
	{
	}

	private void JKDCFEOBGPE()
	{
		float num = 403f;
		float num2 = 341f;
		float kBJEOEEOEFG = 435f;
		float kBJEOEEOEFG2 = 1513f;
		float kALLNCAFIMP = 1083f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 880f, BKLKJLFFLKE.y * 694f, 249f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 353f, 124f, 396f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 518f;
		vector3.z = 1328f;
		Vector3 vector4 = localScale * 1271f;
		vector4.z = 702f;
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 60f, 509f, -1, 1848f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 6;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 73f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 769f, -1, oEIICEJPGKI, (UITweener.Method)8);
		FNOMCHPCOHB.MNEFMODDFFK(3, TweenAnimator.MNAIKKJDPLK.TextCounter, PEJFFMLEHFA.gameObject, num2 + num * 1628f, vector2, 1237f, 4, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 913f, 682f, 5, null, (UITweener.Method)8);
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1339f, 710f, -1, 1251f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 712f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1197f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, num, vector4, 1280f, 5, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, num2 + num * 1313f, localScale, 907f, 3, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(67, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 261f, kALLNCAFIMP, 0, null, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(30, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 229f, kALLNCAFIMP, -60, null, UITweener.Method.EaseIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(-33, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 912f, kALLNCAFIMP, -64, null, (UITweener.Method)7);
		FNOMCHPCOHB.AddTween(41, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1781f, kALLNCAFIMP, -78, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(44, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1261f, kALLNCAFIMP, -54, null, (UITweener.Method)8, UITweener.Style.Once, 0);
	}

	private void DFFNDLBLEII()
	{
		MKALMODMIMP = false;
	}

	private void AKPFOKNFGEL()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	private void FDLJDDOEDJE()
	{
		MKALMODMIMP = false;
	}

	private void ECKCFLMGMLC()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	private void BHFNHPJKKBB()
	{
		MKALMODMIMP = true;
	}

	public virtual void JCIBDJMFOLI()
	{
	}

	public virtual void AGFDJGJALKD()
	{
	}

	public virtual void HAHKNAIIIPC()
	{
		LFKPPLNIMOF();
		Singleton<GameController>.instance.GameStarted += ODDKCEPNDEB;
		Singleton<MatchManager>.instance.OverTimeStarted += ECKCFLMGMLC;
	}

	private void LPBEBJKBNPB()
	{
		float num = 1406f;
		float num2 = 126f;
		float kBJEOEEOEFG = 1532f;
		float kBJEOEEOEFG2 = 1924f;
		float kALLNCAFIMP = 1434f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 48f, BKLKJLFFLKE.y * 1863f, 772f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1654f, 1595f, 1964f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 439f;
		vector3.z = 39f;
		Vector3 vector4 = localScale * 1703f;
		vector4.z = 745f;
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1411f, 1887f, -1, 873f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 6;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 110f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 1311f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.Rotation, PEJFFMLEHFA.gameObject, num2 + num * 1783f, vector2, 1436f, 6, null, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1014f, 1244f, 2, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1225f, 1006f, -1, 1809f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 343f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 95f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, num, vector4, 484f, 2, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, num2 + num * 883f, localScale, 946f, 0, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-107, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1038f, kALLNCAFIMP, 3, null, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(112, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1406f, kALLNCAFIMP, 26, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(73, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1944f, kALLNCAFIMP, 47, null, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(78, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 994f, kALLNCAFIMP, -104, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(30, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 855f, kALLNCAFIMP, 66, null, UITweener.Method.BounceIn);
	}

	private void LFKPPLNIMOF()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			LHJLIGIDABG();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
		}
	}

	[SpecialName]
	public bool OOMNKFOGCDG()
	{
		return MKALMODMIMP;
	}

	private void PNIGFBKGECK(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 39)
		{
			MKALMODMIMP = false;
		}
	}

	public virtual void JJDJKPGLHGD()
	{
	}

	private void GAJOGCPADFN()
	{
		MKALMODMIMP = false;
	}

	public virtual void JMNHKBNACBE()
	{
		LDPHOMJGFJN();
		Singleton<GameController>.instance.GameStarted += POLGAJPMEDI;
		Singleton<MatchManager>.instance.CFEABFIOJMI(LCGBJLCDAFA);
	}

	private void FPCLGNEOEKD()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			PAMJDKKLOEK();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(DIBPILKCFMP));
		}
	}

	public virtual void AOKOKHGEIBE()
	{
		JKJJOHJBMPM();
		Singleton<GameController>.instance.GameStarted += EMNJNPNBKFL;
		Singleton<MatchManager>.instance.CFEABFIOJMI(CLGNHBLKMIF);
	}

	private void LHJLIGIDABG()
	{
		float num = 0.2f;
		float num2 = 1f;
		float kBJEOEEOEFG = 0.01f;
		float kBJEOEEOEFG2 = 0.05f;
		float kALLNCAFIMP = 0.05f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 6f, BKLKJLFFLKE.y * 6f, 1f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 3f, 1f, 1f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1.2f;
		vector3.z = 1f;
		Vector3 vector4 = localScale * 1.1f;
		vector4.z = 1f;
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1f, 0f, -1, 0f);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 3f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, num2 + num * 3f, vector2, 0f, 2);
		FNOMCHPCOHB.AddTween(4, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 0f, 0f, 3);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1f, 0f, -1, 0f);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 3f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 0f, -1, iIMDKHJAJGO, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, num, vector4, 0f, 6, null, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(8, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, num2 + num * 2f, localScale, 0f, 7, null, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(10, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 0f, kALLNCAFIMP, 8);
		FNOMCHPCOHB.AddTween(11, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1f, kALLNCAFIMP, 10);
		FNOMCHPCOHB.AddTween(12, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 0f, kALLNCAFIMP, 11);
		FNOMCHPCOHB.AddTween(13, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1f, kALLNCAFIMP, 12);
		FNOMCHPCOHB.AddTween(14, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 0f, kALLNCAFIMP, 13);
	}

	private void HANKPBGKPOD()
	{
		MKALMODMIMP = false;
	}

	private void EGDCKNFHMBK()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			LPBEBJKBNPB();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(LPDIGOIOBEO));
		}
	}

	private void MPLOLPOPNIM()
	{
		MKALMODMIMP = false;
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	private void KCBKNOKKJJC()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			KKCOMJNOLJA();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(LMHPHHLKILP));
		}
	}

	private void DIBPILKCFMP(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -63)
		{
			MKALMODMIMP = true;
		}
	}

	public virtual void CHPAFPBJAEM()
	{
		KCBKNOKKJJC();
		Singleton<GameController>.instance.GameStarted += HGLIKBAGDHB;
		Singleton<MatchManager>.instance.OverTimeStarted += MPLOLPOPNIM;
	}

	[SpecialName]
	public bool BLMKLJOIFJI()
	{
		return MKALMODMIMP;
	}

	public virtual void DHNILCPGLLI()
	{
		CLABKADKMPB();
		Singleton<GameController>.instance.GameStarted += DPNDPEDFLOO;
		Singleton<MatchManager>.instance.CFEABFIOJMI(AKPFOKNFGEL);
	}

	private void AGKEEDJJGNG()
	{
		MKALMODMIMP = true;
	}

	private void OCCGGJJCLID()
	{
		float num = 1930f;
		float num2 = 517f;
		float kBJEOEEOEFG = 1959f;
		float kBJEOEEOEFG2 = 1085f;
		float kALLNCAFIMP = 1510f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1689f, BKLKJLFFLKE.y * 1316f, 1740f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1347f, 38f, 799f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1387f;
		vector3.z = 312f;
		Vector3 vector4 = localScale * 1183f;
		vector4.z = 1088f;
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1059f, 1844f, -1, 971f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 490f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 830f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.Color, PEJFFMLEHFA.gameObject, num2 + num * 228f, vector2, 1554f, 2, null, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 390f, 216f, 8, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 159f, 444f, -1, 1276f, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 289f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 404f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, num, vector4, 1253f, 7, null, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, num2 + num * 377f, localScale, 1900f, 4, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(46, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 589f, kALLNCAFIMP, 0, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(41, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1985f, kALLNCAFIMP, -17, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(123, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1154f, kALLNCAFIMP, -118, null, (UITweener.Method)7);
		FNOMCHPCOHB.NFLKPCIHOPJ(-66, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1267f, kALLNCAFIMP, 127, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-97, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1585f, kALLNCAFIMP, 67, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
	}

	private void MCAJPNPBOKB()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	private void PAMJDKKLOEK()
	{
		float num = 1819f;
		float num2 = 196f;
		float kBJEOEEOEFG = 1138f;
		float kBJEOEEOEFG2 = 1101f;
		float kALLNCAFIMP = 245f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1178f, BKLKJLFFLKE.y * 1314f, 1159f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 282f, 642f, 1429f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1544f;
		vector3.z = 925f;
		Vector3 vector4 = localScale * 1636f;
		vector4.z = 1568f;
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1551f, 1474f, -1, 1242f, (UITweener.Method)7, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 3;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1461f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 1194f, -1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(3, TweenAnimator.MNAIKKJDPLK.Rotation, PEJFFMLEHFA.gameObject, num2 + num * 859f, vector2, 899f, 0, null, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1767f, 280f, 8, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1615f, 1135f, -1, 136f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 5;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 1336f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 238f, -1, iIMDKHJAJGO, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, num, vector4, 694f, 3, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, num2 + num * 1763f, localScale, 1957f, 8, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-101, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1641f, kALLNCAFIMP, 6, null, UITweener.Method.Linear);
		FNOMCHPCOHB.MNEFMODDFFK(58, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 614f, kALLNCAFIMP, 93, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-75, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 61f, kALLNCAFIMP, 69, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(81, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1658f, kALLNCAFIMP, -92, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 945f, kALLNCAFIMP, -76, null, UITweener.Method.Linear);
	}

	private void BMOKJKNLOBG()
	{
		MKALMODMIMP = true;
	}

	public virtual void PKLGGJFBEJA()
	{
	}

	private void EKCNJLHMJPN()
	{
		float num = 12f;
		float num2 = 1086f;
		float kBJEOEEOEFG = 1387f;
		float kBJEOEEOEFG2 = 1097f;
		float kALLNCAFIMP = 224f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1220f, BKLKJLFFLKE.y * 587f, 568f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 141f, 1114f, 1176f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1780f;
		vector3.z = 517f;
		Vector3 vector4 = localScale * 334f;
		vector4.z = 1099f;
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1231f, 86f, -1, 1624f, (UITweener.Method)8, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 8;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1213f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 1102f, -1, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Position, PEJFFMLEHFA.gameObject, num2 + num * 1825f, vector2, 144f, 5, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 301f, 1208f, 8, null, (UITweener.Method)6);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 108f, 936f, -1, 1762f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 1261f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1243f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, num, vector4, 309f, 3, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, num2 + num * 678f, localScale, 861f, 5, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-2, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1878f, kALLNCAFIMP, 1, null, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(32, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1556f, kALLNCAFIMP, 56, null, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(-97, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 390f, kALLNCAFIMP, -73, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-28, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1914f, kALLNCAFIMP, -36, null, UITweener.Method.BounceOut);
		FNOMCHPCOHB.FEHALDPLGDB(-3, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1366f, kALLNCAFIMP, -59, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
	}

	private void AAEGAPOGAMA()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			FKNIMEDPEOA();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(PNIGFBKGECK));
		}
	}

	public virtual void PEIILMKDGBK()
	{
		CLABKADKMPB();
		Singleton<GameController>.instance.GameStarted += FDLJDDOEDJE;
		Singleton<MatchManager>.instance.CFEABFIOJMI(LMDLNDCLNDN);
	}

	private void FALOPPGICOB()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			LPBEBJKBNPB();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(JNJIJCEPBMN));
		}
	}

	private void CLABKADKMPB()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			EKCNJLHMJPN();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(DIBPILKCFMP));
		}
	}

	private void MOCIIGHPLGB()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			LPIMFOFDKPH();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(PNIGFBKGECK));
		}
	}

	private void EBMJKBLKMAH()
	{
		float num = 551f;
		float num2 = 85f;
		float kBJEOEEOEFG = 1002f;
		float kBJEOEEOEFG2 = 869f;
		float kALLNCAFIMP = 1064f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 804f, BKLKJLFFLKE.y * 1934f, 1370f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1446f, 782f, 546f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1044f;
		vector3.z = 1811f;
		Vector3 vector4 = localScale * 1328f;
		vector4.z = 1924f;
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 195f, 1144f, -1, 1681f, UITweener.Method.BounceIn);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 7;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 528f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 729f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PEJFFMLEHFA.gameObject, num2 + num * 615f, vector2, 761f, 5, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 480f, 1021f, 7, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1050f, 1968f, -1, 1079f, (UITweener.Method)8, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 1470f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 240f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, num, vector4, 1716f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, num2 + num * 831f, localScale, 1006f, 5, null, UITweener.Method.EaseIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(62, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 255f, kALLNCAFIMP, 0, null, UITweener.Method.BounceIn);
		FNOMCHPCOHB.AddTween(-44, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 854f, kALLNCAFIMP, 73, null, UITweener.Method.BounceIn);
		FNOMCHPCOHB.FEHALDPLGDB(62, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1034f, kALLNCAFIMP, 104, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-53, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 977f, kALLNCAFIMP, -7, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-12, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 171f, kALLNCAFIMP, -53, null, (UITweener.Method)8);
	}

	private void JKOMADGAFHO()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			EKCNJLHMJPN();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(CBAGGENPOGK));
		}
	}

	public virtual void HDIKNMGGFKL()
	{
		KCBKNOKKJJC();
		Singleton<GameController>.instance.GameStarted += DPNDPEDFLOO;
		Singleton<MatchManager>.instance.CFEABFIOJMI(HNGKNPEOMHA);
	}

	private void HNJNDPHDIAE()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	public virtual void PLDBDGJLOFP()
	{
	}

	private void LFCPBDBLBEE()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	public virtual void HEOMHIGCMOC()
	{
		LDPHOMJGFJN();
		Singleton<GameController>.instance.GameStarted += HFNAIFBAEMJ;
		Singleton<MatchManager>.instance.CFEABFIOJMI(LCGBJLCDAFA);
	}

	private void HGLIKBAGDHB()
	{
		MKALMODMIMP = false;
	}

	[SpecialName]
	public bool OHNKMPCPECJ()
	{
		return MKALMODMIMP;
	}

	private void IIKPNKHIMIO()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	private void CLGNHBLKMIF()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	private void ODDKCEPNDEB()
	{
		MKALMODMIMP = false;
	}

	private void BCMPFNBNBPK()
	{
		MKALMODMIMP = true;
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	private void NMPBLCAFIAJ()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			DAACEADIAFD();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(MEICFOFNGHO));
		}
	}

	private void NCAKLEOEDBO()
	{
		MKALMODMIMP = false;
	}

	public virtual void INMDPGCHHPN()
	{
		JKJJOHJBMPM();
		Singleton<GameController>.instance.GameStarted += BHFNHPJKKBB;
		Singleton<MatchManager>.instance.CFEABFIOJMI(IIKPNKHIMIO);
	}

	public virtual void NKPJHEKEEHE()
	{
	}

	private void CBAGGENPOGK(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -118)
		{
			MKALMODMIMP = true;
		}
	}

	private void HPPAAPNECPL(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -36)
		{
			MKALMODMIMP = false;
		}
	}

	public virtual void ILLBJBLCLGF()
	{
	}

	private void JHHGNFOLEEI()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			JCFFLACAOKK();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(JNJIJCEPBMN));
		}
	}

	public virtual void CEOBPADJPIA()
	{
		GJJKDKFJHLI();
		Singleton<GameController>.instance.GameStarted += OHICPADKAPE;
		Singleton<MatchManager>.instance.OverTimeStarted += CMDPACOBDCK;
	}

	[SpecialName]
	public bool IFDNOALOODC()
	{
		return MKALMODMIMP;
	}

	public virtual void OFCCACPEBHD()
	{
	}

	private void FKNIMEDPEOA()
	{
		float num = 512f;
		float num2 = 424f;
		float kBJEOEEOEFG = 1926f;
		float kBJEOEEOEFG2 = 1027f;
		float kALLNCAFIMP = 418f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 263f, BKLKJLFFLKE.y * 816f, 237f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 1586f, 1608f, 842f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 150f;
		vector3.z = 1834f;
		Vector3 vector4 = localScale * 247f;
		vector4.z = 1024f;
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.Rotation, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1095f, 1562f, -1, 521f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1960f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 683f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PEJFFMLEHFA.gameObject, num2 + num * 1655f, vector2, 69f, 0, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.TextCounter, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 568f, 488f, 3, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1812f, 883f, -1, 1683f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 768f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1856f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(3, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, num, vector4, 124f, 4, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, num2 + num * 60f, localScale, 1981f, 5, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 701f, kALLNCAFIMP, 7, null, UITweener.Method.BounceOut);
		FNOMCHPCOHB.AddTween(76, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1031f, kALLNCAFIMP, 18, null, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(114, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1596f, kALLNCAFIMP, 5, null, (UITweener.Method)6);
		FNOMCHPCOHB.BPEKAKFKCIG(-103, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1013f, kALLNCAFIMP, 68, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(88, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 501f, kALLNCAFIMP, -73, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
	}

	[SpecialName]
	public bool AELLJFENHEM()
	{
		return MKALMODMIMP;
	}

	private void JJNDCIBHGKI()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			LPIMFOFDKPH();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(PNIGFBKGECK));
		}
	}

	public override void InitGUIValues()
	{
	}

	private void MMOGMHIGDOD()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			LHOAGEOOMKI();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(ADGAMJBGCBO));
		}
	}

	private void GJJKDKFJHLI()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			PAMJDKKLOEK();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(ADGAMJBGCBO));
		}
	}

	public virtual void KFLBEIPPMBF()
	{
		KCBKNOKKJJC();
		Singleton<GameController>.instance.GameStarted += FDLJDDOEDJE;
		Singleton<MatchManager>.instance.OverTimeStarted += OACPHGGBKKD;
	}

	private void JCFFLACAOKK()
	{
		float num = 0f;
		float num2 = 603f;
		float kBJEOEEOEFG = 235f;
		float kBJEOEEOEFG2 = 1519f;
		float kALLNCAFIMP = 1884f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1426f, BKLKJLFFLKE.y * 806f, 575f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 688f, 822f, 1063f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 134f;
		vector3.z = 142f;
		Vector3 vector4 = localScale * 1721f;
		vector4.z = 314f;
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Alpha, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 629f, 756f, -1, 911f);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 7;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1898f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 199f, -1, oEIICEJPGKI, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, PEJFFMLEHFA.gameObject, num2 + num * 309f, vector2, 542f, 5, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 1855f, 1141f, 3, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 1127f, 358f, -1, 422f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 293f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 1692f, -1, iIMDKHJAJGO, UITweener.Method.Linear);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Rotation, ABENDKFKIGH.gameObject, num, vector4, 1593f, 4, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, num2 + num * 813f, localScale, 1963f, 6, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(115, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 213f, kALLNCAFIMP, 4, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-77, TweenAnimator.MNAIKKJDPLK.Position, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 626f, kALLNCAFIMP, 104, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(74, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 82f, kALLNCAFIMP, 118, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(-89, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 507f, kALLNCAFIMP, -103, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-32, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 31f, kALLNCAFIMP, 110, null, UITweener.Method.Linear);
	}

	private void AFFELDHOAKB()
	{
		float num = 574f;
		float num2 = 1578f;
		float kBJEOEEOEFG = 355f;
		float kBJEOEEOEFG2 = 1280f;
		float kALLNCAFIMP = 1192f;
		Vector3 vector = new Vector3(BKLKJLFFLKE.x * 1534f, BKLKJLFFLKE.y * 1172f, 339f);
		Vector3 vector2 = new Vector3(BKLKJLFFLKE.x * 286f, 1538f, 349f);
		ABENDKFKIGH.MakePixelPerfect();
		Vector3 localScale = ABENDKFKIGH.transform.localScale;
		Vector3 vector3 = localScale * 1853f;
		vector3.z = 1523f;
		Vector3 vector4 = localScale * 1639f;
		vector4.z = 175f;
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 139f, 1231f, -1, 1206f, (UITweener.Method)6, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = PEJFFMLEHFA.gameObject;
		float kBJEOEEOEFG3 = num * 1861f;
		object iIMDKHJAJGO = vector;
		object oEIICEJPGKI = Vector3.one;
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, iIMDKHJAJGO, 93f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Scale, PEJFFMLEHFA.gameObject, num2 + num * 1415f, vector2, 1456f, 0, null, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PEJFFMLEHFA.gameObject, kBJEOEEOEFG2, 881f, 682f, 1, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, kBJEOEEOEFG2, 698f, 660f, -1, 779f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = ABENDKFKIGH.gameObject;
		kBJEOEEOEFG3 = num * 162f;
		oEIICEJPGKI = vector3;
		iIMDKHJAJGO = Vector3.one;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG3, oEIICEJPGKI, 898f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ABENDKFKIGH.gameObject, num, vector4, 557f, 2, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Alpha, ABENDKFKIGH.gameObject, num2 + num * 1136f, localScale, 737f, 6, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(103, TweenAnimator.MNAIKKJDPLK.Color, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 706f, kALLNCAFIMP, 3, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-15, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1981f, kALLNCAFIMP, 8, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-50, TweenAnimator.MNAIKKJDPLK.TextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1274f, kALLNCAFIMP, 4, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.BPEKAKFKCIG(86, TweenAnimator.MNAIKKJDPLK.Scale, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 1313f, kALLNCAFIMP, 6, null, UITweener.Method.EaseIn);
		FNOMCHPCOHB.BPEKAKFKCIG(-5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ABENDKFKIGH.gameObject, kBJEOEEOEFG, 442f, kALLNCAFIMP, 124, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
	}

	[SpecialName]
	public bool NJNLJHODMBM()
	{
		return MKALMODMIMP;
	}

	private void JKJJOHJBMPM()
	{
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			FKNIMEDPEOA();
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(HKGECBMNJEL));
		}
	}

	private void CCNEECHBCBN(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -1)
		{
			MKALMODMIMP = false;
		}
	}
}
