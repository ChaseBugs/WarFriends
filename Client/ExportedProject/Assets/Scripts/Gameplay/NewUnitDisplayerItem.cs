using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NewUnitDisplayerItem : PoolableObject
{
	[FormerlySerializedAs("FHOEGLFOKAL")]
	public tk2dSprite ADCBCPONCBL;

	[FormerlySerializedAs("GGCCIKBCMDB")]
	public tk2dSprite EPJMNENIMBM;

	private TweenAnimator FNOMCHPCOHB;

	[FormerlySerializedAs("FBBCHEANMGG")]
	public Transform FEFMPBGPKIE;

	private Vector3 IAJAILAGAKC;

	[FormerlySerializedAs("JAHJEGIBJMG")]
	public TextMesh BLLFJLJPIJP;

	[FormerlySerializedAs("KMHMDLCDNBG")]
	public TextMesh HGCIOGMBCEI;

	private void OAEOIHABKOO(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(50f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 2f);
		gHECLGIFKNF = IAOPNKEGFGD(HealthBarManager.instance.KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 2f + 0.4f + 12.8f);
	}

	private void PAPBGGLNAJK(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -63)
		{
			DestroyPooled();
		}
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 188f;
		object iIMDKHJAJGO = new Vector3(886f, 1401f, 1641f);
		object oEIICEJPGKI = new Vector3(1891f, 507f, 799f);
		fNOMCHPCOHB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 650f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Color, ADCBCPONCBL.gameObject, 370f, 1558f, 1050f, -1, 1144f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Color, BLLFJLJPIJP.gameObject, 390f, 1667f, 113f, -1, 675f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(47, TweenAnimator.MNAIKKJDPLK.Color, EPJMNENIMBM.gameObject, 1697f, 369f, 1317f, -1, 887f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.FEHALDPLGDB(-118, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HGCIOGMBCEI.gameObject, 1397f, 1599f, 1370f, -1, 1787f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Rotation, FEFMPBGPKIE.gameObject, 906f, new Vector3(1031f, 301f, 1579f), 154f, 0, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		float num = 754f;
		int num2 = 6;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 568f;
		oEIICEJPGKI = 1795f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 5;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)6, (UITweener.Style)4, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 164f;
		oEIICEJPGKI = 1091f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.BPEKAKFKCIG(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceIn, (UITweener.Style)5, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 120;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1129f;
		oEIICEJPGKI = 235f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 3;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)7, UITweener.Style.Once, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -113;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1662f;
		oEIICEJPGKI = 1248f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 5;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.NFLKPCIHOPJ(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceOut, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(OONMPOLMJBN));
		FNOMCHPCOHB.JIPFOMFJNPC();
	}

	private void MEHALOCNHNJ(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 977f) / x2);
	}

	private Vector3 KKMHHNJLMJP(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(649f, 1386f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1669f, 965f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public virtual void MGKNFBFBLIP()
	{
		base.OnInstancied();
	}

	private void NPAFLONKNKI(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 470f) / x2);
	}

	public void KNBJJPIFIPE(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("ID_JUSTONEMORERANKUP");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		LLPCHOOAIFD(HGCIOGMBCEI, EPJMNENIMBM);
		OBEDFPPJILH(BLLFJLJPIJP, ADCBCPONCBL);
		KGIBLLHFEHO(GHECLGIFKNF);
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	protected virtual void JJBODEPAMBI()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 523f;
		object iIMDKHJAJGO = new Vector3(135f, 985f, 897f);
		object oEIICEJPGKI = new Vector3(1752f, 762f, 1666f);
		fNOMCHPCOHB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 842f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ADCBCPONCBL.gameObject, 1503f, 1851f, 1262f, -1, 707f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Color, BLLFJLJPIJP.gameObject, 498f, 1481f, 1490f, -1, 1490f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-80, TweenAnimator.MNAIKKJDPLK.Scale, EPJMNENIMBM.gameObject, 203f, 739f, 1929f, -1, 1176f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(31, TweenAnimator.MNAIKKJDPLK.TextCounter, HGCIOGMBCEI.gameObject, 284f, 1507f, 1704f, -1, 901f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.Rotation, FEFMPBGPKIE.gameObject, 980f, new Vector3(1306f, 24f, 168f), 381f, 1, null, UITweener.Method.Linear, UITweener.Style.Loop);
		float num = 1720f;
		int num2 = 3;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1595f;
		oEIICEJPGKI = 65f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 4;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)6, UITweener.Style.Loop, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 1527f;
		oEIICEJPGKI = 926f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 3;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.BPEKAKFKCIG(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)6, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 95;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 574f;
		oEIICEJPGKI = 116f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 6;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceOut, UITweener.Style.Once, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -72;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1499f;
		oEIICEJPGKI = 1438f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.NFLKPCIHOPJ(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseOut, (UITweener.Style)3, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(PAPBGGLNAJK));
		FNOMCHPCOHB.PGGAAGLGKAL();
	}

	private void LLPCHOOAIFD(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1759f) / x2);
	}

	protected virtual void OGFAHEALGFN()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1719f;
		object iIMDKHJAJGO = new Vector3(597f, 1416f, 155f);
		object oEIICEJPGKI = new Vector3(1229f, 1158f, 1452f);
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1749f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.Color, ADCBCPONCBL.gameObject, 1305f, 669f, 943f, -1, 56f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Rotation, BLLFJLJPIJP.gameObject, 824f, 798f, 1876f, -1, 1467f, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(-59, TweenAnimator.MNAIKKJDPLK.Color, EPJMNENIMBM.gameObject, 1778f, 706f, 560f, -1, 682f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(115, TweenAnimator.MNAIKKJDPLK.Alpha, HGCIOGMBCEI.gameObject, 1475f, 1459f, 1371f, -1, 352f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 1206f, new Vector3(1421f, 412f, 1518f), 1573f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		float num = 1472f;
		int num2 = 7;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1843f;
		oEIICEJPGKI = 1046f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 3;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceOut, (UITweener.Style)6, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 1403f;
		oEIICEJPGKI = 328f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.MNEFMODDFFK(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceIn, (UITweener.Style)6, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = -43;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 715f;
		oEIICEJPGKI = 1251f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 5;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)8, (UITweener.Style)7, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -40;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1442f;
		oEIICEJPGKI = 263f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)8, (UITweener.Style)7, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(GGKMPDMNGBK));
		FNOMCHPCOHB.HONNAONCPHA();
	}

	protected override void Awake()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 0.3f;
		object iIMDKHJAJGO = new Vector3(-12.8f, 15f, 0f);
		object oEIICEJPGKI = new Vector3(-12.8f, 0f, 0f);
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ADCBCPONCBL.gameObject, 0.3f, 1f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BLLFJLJPIJP.gameObject, 0.3f, 1f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(22, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, EPJMNENIMBM.gameObject, 0.3f, 1f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(33, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HGCIOGMBCEI.gameObject, 0.3f, 1f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(4, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 0.1f, new Vector3(-12.8f, 10f, 0f), 0f, 0, null, UITweener.Method.EaseIn);
		float num = 1.3f;
		int num2 = 5;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 0.05f;
		oEIICEJPGKI = 0f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 4;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 0.05f;
		oEIICEJPGKI = 0f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 9;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 0.05f;
		oEIICEJPGKI = 0f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 4;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 10;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 0.05f;
		oEIICEJPGKI = 0f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(JHDBHGCKPDM));
		FNOMCHPCOHB.GenerateTweens();
	}

	public virtual void ACCLADFINDD()
	{
		base.OnInstancied();
	}

	private void KOHLBKJCDJJ(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 41)
		{
			BOHCNEDIJPE();
		}
	}

	private void NBIEKPIKOFB(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -39)
		{
			BOHCNEDIJPE();
		}
	}

	protected virtual void NAMAMGENMGH()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 853f;
		object iIMDKHJAJGO = new Vector3(802f, 164f, 432f);
		object oEIICEJPGKI = new Vector3(1957f, 1260f, 1258f);
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 893f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.Position, ADCBCPONCBL.gameObject, 1808f, 1868f, 22f, -1, 1136f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, BLLFJLJPIJP.gameObject, 90f, 643f, 378f, -1, 776f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-38, TweenAnimator.MNAIKKJDPLK.TextCounter, EPJMNENIMBM.gameObject, 1812f, 114f, 978f, -1, 734f, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(28, TweenAnimator.MNAIKKJDPLK.Scale, HGCIOGMBCEI.gameObject, 1802f, 1549f, 313f, -1, 97f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.Rotation, FEFMPBGPKIE.gameObject, 591f, new Vector3(1905f, 1674f, 1569f), 464f, 0, null, UITweener.Method.EaseIn);
		float num = 1698f;
		int num2 = 8;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1668f;
		oEIICEJPGKI = 1178f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 2;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, (UITweener.Style)4, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 524f;
		oEIICEJPGKI = 1925f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.NFLKPCIHOPJ(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseIn, (UITweener.Style)5, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 33;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 13f;
		oEIICEJPGKI = 1625f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 2;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)6, UITweener.Style.Once, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 18;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1046f;
		oEIICEJPGKI = 328f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 5;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.FEHALDPLGDB(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.Linear, (UITweener.Style)4, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(BFPMMBJHFLO));
		FNOMCHPCOHB.GenerateTweens();
	}

	private void JJAPIBCPACK(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -81)
		{
			DestroyPooled();
		}
	}

	private Vector3 KKKMKFFMFHO(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1302f, 1965f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(750f, 1473f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private Vector3 HLMKGHNJGNC(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1579f, 1582f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1234f, 1928f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void HKCMIFECDFA(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.OGBIHEFNJGO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1645f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 548f);
		gHECLGIFKNF = JPJKIECEABM(HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 1823f + 225f + 642f);
	}

	private Vector3 OOAOMLGEANP(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(180f, 1367f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(234f, 68f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
	}

	private Vector3 IAKFKMLCJFN(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1686f, 1125f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(549f, 1363f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public virtual void AOGFPIADEHO()
	{
		base.JMAFCGDIICK();
	}

	private void JFHDJAOMLHE(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 477f) / x2);
	}

	private Vector3 IAOPNKEGFGD(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(0f, 0f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1f, 0f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	protected virtual void NLOODGLGPHE()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1463f;
		object iIMDKHJAJGO = new Vector3(854f, 965f, 1067f);
		object oEIICEJPGKI = new Vector3(182f, 1886f, 1934f);
		fNOMCHPCOHB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1008f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(8, TweenAnimator.MNAIKKJDPLK.TextCounter, ADCBCPONCBL.gameObject, 1563f, 1830f, 1875f, -1, 346f, UITweener.Method.BounceIn);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.Color, BLLFJLJPIJP.gameObject, 415f, 1536f, 502f, -1, 1647f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(124, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, EPJMNENIMBM.gameObject, 116f, 1909f, 1422f, -1, 456f);
		FNOMCHPCOHB.BPEKAKFKCIG(-32, TweenAnimator.MNAIKKJDPLK.Position, HGCIOGMBCEI.gameObject, 964f, 848f, 1413f, -1, 771f, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 1694f, new Vector3(321f, 874f, 430f), 1689f, 1, null, UITweener.Method.EaseIn);
		float num = 610f;
		int num2 = 5;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 258f;
		oEIICEJPGKI = 441f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 4;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseOut, UITweener.Style.PingPong, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 574f;
		oEIICEJPGKI = 723f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseOut, (UITweener.Style)4, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 17;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 312f;
		oEIICEJPGKI = 726f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 2;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceOut, (UITweener.Style)3, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -86;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 984f;
		oEIICEJPGKI = 366f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.FEHALDPLGDB(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)8, (UITweener.Style)6, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(AGACFPGNPLJ));
		FNOMCHPCOHB.OOFBCPPFMPN();
	}

	protected virtual void IIPMNCCFNIA()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1865f;
		object iIMDKHJAJGO = new Vector3(1654f, 1213f, 1744f);
		object oEIICEJPGKI = new Vector3(152f, 130f, 1096f);
		fNOMCHPCOHB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1641f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ADCBCPONCBL.gameObject, 246f, 149f, 304f, -1, 761f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(4, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BLLFJLJPIJP.gameObject, 539f, 551f, 1891f, -1, 1316f, UITweener.Method.Linear);
		FNOMCHPCOHB.BPEKAKFKCIG(-43, TweenAnimator.MNAIKKJDPLK.Position, EPJMNENIMBM.gameObject, 1068f, 1445f, 148f, -1, 1411f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(64, TweenAnimator.MNAIKKJDPLK.Alpha, HGCIOGMBCEI.gameObject, 249f, 1558f, 1181f, -1, 1501f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Rotation, FEFMPBGPKIE.gameObject, 1371f, new Vector3(1296f, 1954f, 1381f), 1459f, 1, null, UITweener.Method.Linear);
		float num = 332f;
		int num2 = 5;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 140f;
		oEIICEJPGKI = 1259f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 0;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceOut, (UITweener.Style)7, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 944f;
		oEIICEJPGKI = 1964f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 3;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 43;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1247f;
		oEIICEJPGKI = 1080f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 3;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceIn, (UITweener.Style)4, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 150f;
		oEIICEJPGKI = 1264f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.MNEFMODDFFK(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceIn, UITweener.Style.Once, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(MCLDPEKHDON));
		FNOMCHPCOHB.OOFBCPPFMPN();
	}

	private void GPJJPGHJNEJ(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 91f) / x2);
	}

	public virtual void BKCGHKNDFLL()
	{
		base.HPPIBGEJMNL();
	}

	private void OONMPOLMJBN(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -69)
		{
			BOHCNEDIJPE();
		}
	}

	protected virtual void PCDHCIDJJOB()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 923f;
		object iIMDKHJAJGO = new Vector3(891f, 1162f, 1186f);
		object oEIICEJPGKI = new Vector3(1900f, 1367f, 1595f);
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1242f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Alpha, ADCBCPONCBL.gameObject, 1145f, 259f, 215f, -1, 182f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BLLFJLJPIJP.gameObject, 1417f, 1398f, 527f, -1, 536f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(34, TweenAnimator.MNAIKKJDPLK.Color, EPJMNENIMBM.gameObject, 1269f, 1736f, 814f, -1, 119f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(74, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HGCIOGMBCEI.gameObject, 730f, 1860f, 220f, -1, 407f, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 1428f, new Vector3(537f, 568f, 635f), 1885f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		float num = 1067f;
		int num2 = 3;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1658f;
		oEIICEJPGKI = 1911f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 1;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)8, (UITweener.Style)4, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 1373f;
		oEIICEJPGKI = 1690f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 7;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.NFLKPCIHOPJ(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 123;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1841f;
		oEIICEJPGKI = 1531f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 6;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, (UITweener.Style)6, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 110;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1168f;
		oEIICEJPGKI = 296f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 6;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)7, (UITweener.Style)8, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(LBMEJOPOOKO));
		FNOMCHPCOHB.GenerateTweens();
	}

	private void PDHAIALEJLC(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.CAGAKKADGDG().WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.ICPEKOGEEEN().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1880f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 7f);
		gHECLGIFKNF = IAKFKMLCJFN(HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 965f + 1655f + 542f);
	}

	public void EEKLDEMMFGJ(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("[Singleton] An instance of ");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		FFJOIOPNCBM(HGCIOGMBCEI, EPJMNENIMBM);
		JFHDJAOMLHE(BLLFJLJPIJP, ADCBCPONCBL);
		JJHBBBGDJKA(GHECLGIFKNF);
		FNOMCHPCOHB.ODIJFGCDJNH();
	}

	private void BFPMMBJHFLO(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 91)
		{
			DestroyPooled();
		}
	}

	public void ENNFEMHMNGJ(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("CheckEnable");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		LLPCHOOAIFD(HGCIOGMBCEI, EPJMNENIMBM);
		BMHMJIPJOGL(BLLFJLJPIJP, ADCBCPONCBL);
		HKCMIFECDFA(GHECLGIFKNF);
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	private Vector3 OKNOEDNOOID(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1996f, 301f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1853f, 639f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 510f;
		object iIMDKHJAJGO = new Vector3(1501f, 92f, 1890f);
		object oEIICEJPGKI = new Vector3(1456f, 1984f, 803f);
		fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1308f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ADCBCPONCBL.gameObject, 1466f, 1124f, 1681f, -1, 260f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.Scale, BLLFJLJPIJP.gameObject, 1092f, 764f, 1037f, -1, 1674f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(122, TweenAnimator.MNAIKKJDPLK.Rotation, EPJMNENIMBM.gameObject, 929f, 1815f, 682f, -1, 1888f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-92, TweenAnimator.MNAIKKJDPLK.Color, HGCIOGMBCEI.gameObject, 1713f, 658f, 1905f, -1, 1703f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 964f, new Vector3(460f, 1409f, 1671f), 1917f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		float num = 2f;
		int num2 = 1;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1026f;
		oEIICEJPGKI = 549f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 2;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)6, (UITweener.Style)5, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 310f;
		oEIICEJPGKI = 777f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 3;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.NFLKPCIHOPJ(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseIn, UITweener.Style.Loop, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 115;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1326f;
		oEIICEJPGKI = 1174f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 6;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)6, (UITweener.Style)8, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 23;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 688f;
		oEIICEJPGKI = 1633f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 2;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)8, (UITweener.Style)5, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(GGKMPDMNGBK));
		FNOMCHPCOHB.HONNAONCPHA();
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 968f;
		object iIMDKHJAJGO = new Vector3(315f, 683f, 995f);
		object oEIICEJPGKI = new Vector3(1899f, 452f, 1551f);
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 475f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ADCBCPONCBL.gameObject, 1651f, 1518f, 141f, -1, 956f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.Rotation, BLLFJLJPIJP.gameObject, 1192f, 526f, 1636f, -1, 805f, UITweener.Method.Linear);
		FNOMCHPCOHB.BPEKAKFKCIG(-55, TweenAnimator.MNAIKKJDPLK.TextCounter, EPJMNENIMBM.gameObject, 911f, 375f, 1837f, -1, 916f);
		FNOMCHPCOHB.AddTween(-49, TweenAnimator.MNAIKKJDPLK.Rotation, HGCIOGMBCEI.gameObject, 1592f, 1439f, 1059f, -1, 23f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Rotation, FEFMPBGPKIE.gameObject, 547f, new Vector3(652f, 1703f, 824f), 863f, 1, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		float num = 79f;
		int num2 = 4;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1856f;
		oEIICEJPGKI = 1817f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 2;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceOut, (UITweener.Style)6, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 1528f;
		oEIICEJPGKI = 727f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 2;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.FEHALDPLGDB(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.Linear, (UITweener.Style)4, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 18;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1436f;
		oEIICEJPGKI = 329f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 6;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)7, (UITweener.Style)3, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 32;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 802f;
		oEIICEJPGKI = 891f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.BPEKAKFKCIG(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceIn, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(EENANKKDOCH));
		FNOMCHPCOHB.JIPFOMFJNPC();
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1649f;
		object iIMDKHJAJGO = new Vector3(953f, 1476f, 1493f);
		object oEIICEJPGKI = new Vector3(1212f, 616f, 287f);
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1085f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ADCBCPONCBL.gameObject, 1679f, 50f, 225f, -1, 498f, (UITweener.Method)8);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, BLLFJLJPIJP.gameObject, 1383f, 1903f, 385f, -1, 115f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-68, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, EPJMNENIMBM.gameObject, 290f, 1277f, 745f, -1, 1946f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(120, TweenAnimator.MNAIKKJDPLK.TextCounter, HGCIOGMBCEI.gameObject, 426f, 756f, 390f, -1, 1801f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 1708f, new Vector3(1705f, 1491f, 30f), 817f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		float num = 1547f;
		int num2 = 0;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1142f;
		oEIICEJPGKI = 1261f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 6;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)8, UITweener.Style.Once, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 1292f;
		oEIICEJPGKI = 1952f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 3;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.FEHALDPLGDB(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)8, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 102;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1558f;
		oEIICEJPGKI = 565f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 5;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceIn, UITweener.Style.Loop, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 101;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 606f;
		oEIICEJPGKI = 1902f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.BPEKAKFKCIG(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceOut, UITweener.Style.Once, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(AGACFPGNPLJ));
		FNOMCHPCOHB.OOFBCPPFMPN();
	}

	private void OGPBGGEFHAG(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1100f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 1218f);
		gHECLGIFKNF = HLMKGHNJGNC(HealthBarManager.GAFFKDOELMI().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 110f + 879f + 718f);
	}

	private Vector3 MOHNLDJBMCB(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1733f, 866f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(348f, 1913f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public void CFOFMDFFMGO(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("AddedCards");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		MGLJIFKENDF(HGCIOGMBCEI, EPJMNENIMBM);
		NKJDHONNAIO(BLLFJLJPIJP, ADCBCPONCBL);
		JJHBBBGDJKA(GHECLGIFKNF);
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	private Vector3 KMOECABDOGP(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1957f, 264f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1723f, 1380f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void CCBGOCKJMJO(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.HEANFGONCBJ().WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1472f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 74f);
		gHECLGIFKNF = KKMHHNJLMJP(HealthBarManager.BNDNFHKPDLM().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 363f + 1966f + 501f);
	}

	private void KGIBLLHFEHO(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1387f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 1433f);
		gHECLGIFKNF = KMOECABDOGP(HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 892f + 431f + 1512f);
	}

	private Vector3 ELGHLLKAHCD(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1487f, 1542f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1885f, 625f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void OBEDFPPJILH(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1721f) / x2);
	}

	public void Play(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("ID_NEWUNIT");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		KPBKADEOMKP(HGCIOGMBCEI, EPJMNENIMBM);
		KPBKADEOMKP(BLLFJLJPIJP, ADCBCPONCBL);
		OAEOIHABKOO(GHECLGIFKNF);
		FNOMCHPCOHB.PlayTweens();
	}

	private void NPDCKMMNJPD(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -28)
		{
			BOHCNEDIJPE();
		}
	}

	private void PDIONBEIPID(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -92)
		{
			DestroyPooled();
		}
	}

	public void HKLFDBHLNGO(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("()I");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		IOPBIKANEKA(HGCIOGMBCEI, EPJMNENIMBM);
		BMHMJIPJOGL(BLLFJLJPIJP, ADCBCPONCBL);
		PDHAIALEJLC(GHECLGIFKNF);
		FNOMCHPCOHB.ODIJFGCDJNH();
	}

	private void CMGMMPCDGLF(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 11)
		{
			OBCAIFMOPPA();
		}
	}

	private void HNDIBFCOMCL(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -98)
		{
			DestroyPooled();
		}
	}

	private void IOPBIKANEKA(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 997f) / x2);
	}

	private Vector3 KAKJAINBECF(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(353f, 1710f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1322f, 176f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void AKDIDKNEBLB(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 113f) / x2);
	}

	private void MCLDPEKHDON(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -115)
		{
			DestroyPooled();
		}
	}

	public virtual void OLCGDMKDNDE()
	{
		base.JMAFCGDIICK();
	}

	public virtual void BNFPJKBFBAH()
	{
		base.OnInstancied();
	}

	private Vector3 AFDHLNAGFGD(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1689f, 298f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1970f, 19f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1177f;
		object iIMDKHJAJGO = new Vector3(1593f, 487f, 636f);
		object oEIICEJPGKI = new Vector3(1472f, 1055f, 529f);
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1460f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Color, ADCBCPONCBL.gameObject, 1047f, 694f, 925f, -1, 1329f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Color, BLLFJLJPIJP.gameObject, 1778f, 1566f, 3f, -1, 639f, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(-20, TweenAnimator.MNAIKKJDPLK.Color, EPJMNENIMBM.gameObject, 772f, 1301f, 180f, -1, 1524f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(-91, TweenAnimator.MNAIKKJDPLK.TextCounter, HGCIOGMBCEI.gameObject, 269f, 1182f, 1881f, -1, 1143f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Rotation, FEFMPBGPKIE.gameObject, 536f, new Vector3(781f, 1286f, 1564f), 830f, 1, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		float num = 1111f;
		int num2 = 5;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1166f;
		oEIICEJPGKI = 1661f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 6;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceIn, UITweener.Style.Once, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 1498f;
		oEIICEJPGKI = 1343f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)6, UITweener.Style.Loop, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 71;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1268f;
		oEIICEJPGKI = 947f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 8;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)7, UITweener.Style.Loop, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 114;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1922f;
		oEIICEJPGKI = 939f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 5;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.NFLKPCIHOPJ(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)7, (UITweener.Style)7, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(GGKMPDMNGBK));
		FNOMCHPCOHB.FEPILCEBNCJ();
	}

	public void JHKBNLNIHKF(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("Fuseboxx: Fuseboxx Config Value not found!");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		OBEDFPPJILH(HGCIOGMBCEI, EPJMNENIMBM);
		HNENKCOFNLK(BLLFJLJPIJP, ADCBCPONCBL);
		CCBGOCKJMJO(GHECLGIFKNF);
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	public virtual void IDKGHKBALEB()
	{
		base.HPPIBGEJMNL();
	}

	public virtual void GJFFGAKEILM()
	{
		base.OnInstancied();
	}

	protected virtual void DFMALDFADAB()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 944f;
		object iIMDKHJAJGO = new Vector3(425f, 1919f, 1272f);
		object oEIICEJPGKI = new Vector3(992f, 1985f, 39f);
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1446f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.Scale, ADCBCPONCBL.gameObject, 743f, 960f, 1892f, -1, 1444f, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, BLLFJLJPIJP.gameObject, 938f, 662f, 1629f, -1, 298f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(19, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, EPJMNENIMBM.gameObject, 865f, 1403f, 370f, -1, 1666f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-125, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HGCIOGMBCEI.gameObject, 1540f, 1776f, 502f, -1, 466f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 1176f, new Vector3(950f, 1155f, 611f), 483f, 0, null, UITweener.Method.Linear, UITweener.Style.Loop);
		float num = 1606f;
		int num2 = 7;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1422f;
		oEIICEJPGKI = 848f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 2;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)7, (UITweener.Style)4, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 605f;
		oEIICEJPGKI = 1121f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 3;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.MNEFMODDFFK(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)6, (UITweener.Style)8, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1386f;
		oEIICEJPGKI = 455f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 8;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)6, (UITweener.Style)5, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -65;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 136f;
		oEIICEJPGKI = 403f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 2;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)6, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(KOHLBKJCDJJ));
		FNOMCHPCOHB.HONNAONCPHA();
	}

	public void GEFHHIKPDGE(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize(" (#");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		NKJDHONNAIO(HGCIOGMBCEI, EPJMNENIMBM);
		NPAFLONKNKI(BLLFJLJPIJP, ADCBCPONCBL);
		OAEOIHABKOO(GHECLGIFKNF);
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	private Vector3 NMADLAJLEBO(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(0f, 1773f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1199f, 1707f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void INMFFHJNJEO(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.LBBFBJMLEJB().WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1916f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 930f);
		gHECLGIFKNF = GHCHODCFEFB(HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 1342f + 201f + 319f);
	}

	private Vector3 AOJBFFBNHCG(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(747f, 912f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1429f, 1917f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private Vector3 GHCHODCFEFB(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1954f, 250f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(606f, 991f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void GGKMPDMNGBK(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 82)
		{
			BOHCNEDIJPE();
		}
	}

	private void HNENKCOFNLK(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1062f) / x2);
	}

	public void FEAGCHEJNLN(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("unit");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		NKJDHONNAIO(HGCIOGMBCEI, EPJMNENIMBM);
		IOPBIKANEKA(BLLFJLJPIJP, ADCBCPONCBL);
		PDHAIALEJLC(GHECLGIFKNF);
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	public void HMCJOEIICJC(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("ios");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		BMHMJIPJOGL(HGCIOGMBCEI, EPJMNENIMBM);
		LLPCHOOAIFD(BLLFJLJPIJP, ADCBCPONCBL);
		OGPBGGEFHAG(GHECLGIFKNF);
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	private void EENANKKDOCH(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -59)
		{
			BOHCNEDIJPE();
		}
	}

	private Vector3 JPJKIECEABM(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1887f, 1423f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(915f, 1590f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1137f;
		object iIMDKHJAJGO = new Vector3(134f, 1650f, 1674f);
		object oEIICEJPGKI = new Vector3(813f, 777f, 401f);
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 169f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Position, ADCBCPONCBL.gameObject, 1609f, 1247f, 762f, -1, 222f);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.Rotation, BLLFJLJPIJP.gameObject, 379f, 116f, 635f, -1, 1065f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-66, TweenAnimator.MNAIKKJDPLK.TextCounter, EPJMNENIMBM.gameObject, 1717f, 1710f, 1443f, -1, 55f, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-105, TweenAnimator.MNAIKKJDPLK.Position, HGCIOGMBCEI.gameObject, 209f, 672f, 1935f, -1, 733f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(8, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 1027f, new Vector3(186f, 1477f, 328f), 879f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		float num = 1618f;
		int num2 = 5;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 5;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1983f;
		oEIICEJPGKI = 1583f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 5;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, (UITweener.Style)3, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 693f;
		oEIICEJPGKI = 793f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 1;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.FEHALDPLGDB(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseIn, (UITweener.Style)6, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = -6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1984f;
		oEIICEJPGKI = 1499f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 7;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceOut, UITweener.Style.PingPong, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 108;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1068f;
		oEIICEJPGKI = 1235f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.BPEKAKFKCIG(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)7, UITweener.Style.Once, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(LBMEJOPOOKO));
		FNOMCHPCOHB.NCKIJBBJAOG();
	}

	protected virtual void FJOCJOOFJBI()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 201f;
		object iIMDKHJAJGO = new Vector3(1682f, 1395f, 1243f);
		object oEIICEJPGKI = new Vector3(22f, 1971f, 1141f);
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1001f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ADCBCPONCBL.gameObject, 813f, 766f, 283f, -1, 1445f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Scale, BLLFJLJPIJP.gameObject, 1644f, 1494f, 20f, -1, 1266f, (UITweener.Method)7);
		FNOMCHPCOHB.NFLKPCIHOPJ(-83, TweenAnimator.MNAIKKJDPLK.Rotation, EPJMNENIMBM.gameObject, 579f, 1482f, 1703f, -1, 101f, UITweener.Method.BounceOut);
		FNOMCHPCOHB.MNEFMODDFFK(-92, TweenAnimator.MNAIKKJDPLK.Rotation, HGCIOGMBCEI.gameObject, 1846f, 1744f, 107f, -1, 236f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, FEFMPBGPKIE.gameObject, 844f, new Vector3(1132f, 195f, 1138f), 725f, 0, null, UITweener.Method.EaseIn);
		float num = 1142f;
		int num2 = 4;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 712f;
		oEIICEJPGKI = 1108f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 7;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseOut, (UITweener.Style)7, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 653f;
		oEIICEJPGKI = 393f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 8;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.BPEKAKFKCIG(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 88;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1838f;
		oEIICEJPGKI = 918f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 3;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseIn, (UITweener.Style)4, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -121;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 511f;
		oEIICEJPGKI = 657f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 1;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.MNEFMODDFFK(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)8, UITweener.Style.Loop, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(GGKMPDMNGBK));
		FNOMCHPCOHB.FEPILCEBNCJ();
	}

	private void ALAPJGPDFIO(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1989f) / x2);
	}

	private void PJBPNIFFIAA(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 497f) / x2);
	}

	private void NLHIKELKIIL(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.CAGAKKADGDG().WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.GAFFKDOELMI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1803f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 719f);
		gHECLGIFKNF = LFIJEBEFHMC(HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 1487f + 1729f + 29f);
	}

	private void JHDBHGCKPDM(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 10)
		{
			DestroyPooled();
		}
	}

	private void MGLJIFKENDF(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 762f) / x2);
	}

	public void KPHGBBCOHIB(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("-");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		LLPCHOOAIFD(HGCIOGMBCEI, EPJMNENIMBM);
		MEHALOCNHNJ(BLLFJLJPIJP, ADCBCPONCBL);
		INMFFHJNJEO(GHECLGIFKNF);
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	private Vector3 LFIJEBEFHMC(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(796f, 1629f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(731f, 581f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void KPBKADEOMKP(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 4f) / x2);
	}

	private Vector3 DIDAMNIPJCP(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(879f, 639f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1878f, 688f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public virtual void KILENFLJMDH()
	{
		base.OnInstancied();
	}

	public void DGPOJONMPJO(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("Win");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		MGLJIFKENDF(HGCIOGMBCEI, EPJMNENIMBM);
		GPJJPGHJNEJ(BLLFJLJPIJP, ADCBCPONCBL);
		PDHAIALEJLC(GHECLGIFKNF);
		FNOMCHPCOHB.PlayTweens();
	}

	private Vector3 BHONKOBGIAO(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(638f, 422f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(512f, 179f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private Vector3 ILHIMCLCJFB(Camera PHHJDIGEOPJ, Vector3 GHECLGIFKNF, Bounds MBJLNICGOMO)
	{
		Vector3 result = GHECLGIFKNF;
		Vector3 vector = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1761f, 1177f));
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(63f, 157f));
		if (GHECLGIFKNF.x - MBJLNICGOMO.extents.x < vector.x)
		{
			result.x = vector.x + MBJLNICGOMO.extents.x;
		}
		if (GHECLGIFKNF.x + MBJLNICGOMO.extents.x > vector2.x)
		{
			result.x = vector2.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void AGACFPGNPLJ(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -111)
		{
			OBCAIFMOPPA();
		}
	}

	public virtual void CJCAHANJGKK()
	{
		base.OnInstancied();
	}

	public virtual void BMCDLGBGHKJ()
	{
		base.OnInstancied();
	}

	private void LBMEJOPOOKO(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 99)
		{
			DestroyPooled();
		}
	}

	protected virtual void IOKMAFLIJEG()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1471f;
		object iIMDKHJAJGO = new Vector3(971f, 211f, 841f);
		object oEIICEJPGKI = new Vector3(1086f, 1066f, 1952f);
		fNOMCHPCOHB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 446f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ADCBCPONCBL.gameObject, 47f, 673f, 731f, -1, 1467f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, BLLFJLJPIJP.gameObject, 926f, 787f, 1502f, -1, 389f, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(-12, TweenAnimator.MNAIKKJDPLK.Scale, EPJMNENIMBM.gameObject, 475f, 574f, 328f, -1, 696f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(36, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HGCIOGMBCEI.gameObject, 373f, 1942f, 1025f, -1, 831f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 1077f, new Vector3(164f, 755f, 1299f), 1228f, 1, null, UITweener.Method.Linear);
		float num = 144f;
		int num2 = 2;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1159f;
		oEIICEJPGKI = 227f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 3;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.BounceIn, UITweener.Style.Once, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 644f;
		oEIICEJPGKI = 1821f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 4;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.MNEFMODDFFK(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.EaseInOut, (UITweener.Style)6, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 112;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 535f;
		oEIICEJPGKI = 1698f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 7;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseOut, (UITweener.Style)8, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = 72;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 710f;
		oEIICEJPGKI = 739f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 5;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.NFLKPCIHOPJ(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceOut, UITweener.Style.Loop, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(JJAPIBCPACK));
		FNOMCHPCOHB.HONNAONCPHA();
	}

	private void NKJDHONNAIO(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1176f) / x2);
	}

	public void LBGIIDNFIHN(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("Password");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		OBEDFPPJILH(HGCIOGMBCEI, EPJMNENIMBM);
		KPBKADEOMKP(BLLFJLJPIJP, ADCBCPONCBL);
		OGPBGGEFHAG(GHECLGIFKNF);
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	protected virtual void EIPLFPJNCIB()
	{
		base.Awake();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = FEFMPBGPKIE.gameObject;
		float kBJEOEEOEFG = 1755f;
		object iIMDKHJAJGO = new Vector3(1825f, 1696f, 1654f);
		object oEIICEJPGKI = new Vector3(1360f, 1815f, 1412f);
		fNOMCHPCOHB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1077f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ADCBCPONCBL.gameObject, 393f, 377f, 1422f, -1, 1055f, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.Alpha, BLLFJLJPIJP.gameObject, 850f, 441f, 643f, -1, 1241f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(-21, TweenAnimator.MNAIKKJDPLK.Color, EPJMNENIMBM.gameObject, 789f, 1146f, 295f, -1, 1839f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(32, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HGCIOGMBCEI.gameObject, 952f, 985f, 981f, -1, 1925f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Position, FEFMPBGPKIE.gameObject, 536f, new Vector3(718f, 1088f, 1476f), 1226f, 1, null, UITweener.Method.Linear);
		float num = 1815f;
		int num2 = 7;
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = ADCBCPONCBL.gameObject;
		kBJEOEEOEFG = 1820f;
		oEIICEJPGKI = 769f;
		float kALLNCAFIMP = num;
		int eBPMMNFLPMP = 3;
		int hOLBAEHICEF = num2;
		fNOMCHPCOHB2.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, UITweener.Method.EaseOut, (UITweener.Style)4, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		hOLBAEHICEF = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = BLLFJLJPIJP.gameObject;
		kALLNCAFIMP = 1313f;
		oEIICEJPGKI = 1300f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 3;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB3.MNEFMODDFFK(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, (UITweener.Method)8, UITweener.Style.Once, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 115;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = EPJMNENIMBM.gameObject;
		kBJEOEEOEFG = 1734f;
		oEIICEJPGKI = 1623f;
		kALLNCAFIMP = num;
		eBPMMNFLPMP = 4;
		hOLBAEHICEF = num2;
		fNOMCHPCOHB4.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, eBPMMNFLPMP, null, (UITweener.Method)7, UITweener.Style.PingPong, hOLBAEHICEF);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		hOLBAEHICEF = -6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = HGCIOGMBCEI.gameObject;
		kALLNCAFIMP = 1412f;
		oEIICEJPGKI = 1069f;
		kBJEOEEOEFG = num;
		eBPMMNFLPMP = 7;
		iNFLHPGMEOB = num2;
		fNOMCHPCOHB5.AddTween(hOLBAEHICEF, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, eBPMMNFLPMP, null, UITweener.Method.BounceIn, UITweener.Style.Loop, iNFLHPGMEOB);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(NPDCKMMNJPD));
		FNOMCHPCOHB.OOFBCPPFMPN();
	}

	public void KNAMCNPMKKP(string JHONGBLEHLJ, Vector3 GHECLGIFKNF)
	{
		HGCIOGMBCEI.text = Localization.Localize("New hearth bought!");
		BLLFJLJPIJP.text = JHONGBLEHLJ.ToUpper();
		ALAPJGPDFIO(HGCIOGMBCEI, EPJMNENIMBM);
		KPBKADEOMKP(BLLFJLJPIJP, ADCBCPONCBL);
		OAEOIHABKOO(GHECLGIFKNF);
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	private void JJHBBBGDJKA(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(GHECLGIFKNF);
		base.transform.position = HealthBarManager.JCEKIJCAMGH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point).ReplaceZ(1176f);
		float x = ADCBCPONCBL.GetBounds().size.x;
		Vector3 gHECLGIFKNF = ADCBCPONCBL.transform.position.AddX(x / 684f);
		gHECLGIFKNF = HLMKGHNJGNC(HealthBarManager.BCDJJBAFLLG().KPDAPFBIPAI, gHECLGIFKNF, ADCBCPONCBL.GetBounds());
		base.transform.position = gHECLGIFKNF.AddX((0f - x) / 126f + 482f + 1943f);
	}

	private void FFJOIOPNCBM(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1942f) / x2);
	}

	private void PDNDJCODODK(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1352f) / x2);
	}

	private void BMHMJIPJOGL(TextMesh ACPFLDCJGKC, tk2dSprite KMFGCJEGJJK)
	{
		float x = ACPFLDCJGKC.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = KMFGCJEGJJK.GetBounds().size.x;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX((x + 1428f) / x2);
	}

	public virtual void CKIMHDOFLEB()
	{
		base.HPPIBGEJMNL();
	}
}
