using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ResultsRewardsFlash : ResultsRewards
{
	private sealed class IIFHMKCKGAI
	{
		internal int LJNGJJGJKMO;

		internal void NNIJEDKBPGJ(int EAINKPNECEC)
		{
			if (EAINKPNECEC == LJNGJJGJKMO)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LevelUp, 1456f);
			}
		}

		internal void MAKLHLCDIKD(int EAINKPNECEC)
		{
			if (EAINKPNECEC == LJNGJJGJKMO)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-11), 1439f);
			}
		}

		internal void LGJCNCHBFDA(int EAINKPNECEC)
		{
			if (EAINKPNECEC == LJNGJJGJKMO)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-28), 732f);
			}
		}

		internal void LJCDGJKCNEC(int EAINKPNECEC)
		{
			if (EAINKPNECEC == LJNGJJGJKMO)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.FlashEndScreen);
			}
		}

		internal void ECPMEMNKMCB(int EAINKPNECEC)
		{
			if (EAINKPNECEC == LJNGJJGJKMO)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-78), 1742f);
			}
		}

		internal void KJIFNOJILDB(int EAINKPNECEC)
		{
			if (EAINKPNECEC == LJNGJJGJKMO)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-88), 1356f);
			}
		}
	}

	[FormerlySerializedAs("COEHJKPJALF")]
	[Header("Flash")]
	public UISprite HFENNCENBFE;

	private ONLHLPBMJOL BNABPLAGMEM = new ONLHLPBMJOL(0);

	public int cardsGot
	{
		set
		{
			BNABPLAGMEM.FKIIDCDCLHM = value;
		}
	}

	protected virtual TweenAnimator PNPIGDGJPBC(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1410f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, 449f, 1777f, -1, 1723f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(350f, 735f, 218f);
		object oEIICEJPGKI = localPosition + new Vector3(1155f, 766f, 211f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1508f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Loop);
		tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1324f, 6, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.Scale, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1625f, 1, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Position, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1022f, 6, null, UITweener.Method.EaseOut);
		}
		tweenAnimator.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 804f, 7, null, UITweener.Method.EaseIn);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.TextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1708f, 3, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(7, (TweenAnimator.MNAIKKJDPLK)(-122), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1490f, 2, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(100, (TweenAnimator.MNAIKKJDPLK)93, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1508f, 8, null, (UITweener.Method)6, UITweener.Style.Loop);
		}
		tweenAnimator.MNEFMODDFFK(-67, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1921f, 223f, -1, 1764f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		tweenAnimator.NFLKPCIHOPJ(84, TweenAnimator.MNAIKKJDPLK.Rotation, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 451f, -26, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		float num2 = num / 891f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 8 : 7);
		iNFLHPGMEOB = -55;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1475f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 627f, lJNGJJGJKMO, 1608f, (UITweener.Method)8, UITweener.Style.Once, 4);
		tweenAnimator.NFLKPCIHOPJ(90, TweenAnimator.MNAIKKJDPLK.Rotation, HFENNCENBFE.gameObject, num2, 1588f, 968f, 82, null, (UITweener.Method)7);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LGJCNCHBFDA;
		return tweenAnimator;
	}

	protected virtual void JPOIGLBBEJG(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 802f;
		base.IGICOIADLBC(GLLMPCPLLCD);
	}

	protected virtual void OHIIKNIAJED(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1545f;
		base.IGICOIADLBC(GLLMPCPLLCD);
	}

	protected virtual TweenAnimator KCDCENMAEDN(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 424f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, 1065f, 1400f, -1, 387f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 3;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1524f, 1146f, 471f);
		object oEIICEJPGKI = localPosition + new Vector3(19f, 1252f, 26f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1345f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		tweenAnimator.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 1786f, 8, null, (UITweener.Method)6);
		tweenAnimator.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Rotation, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 940f, 8, null, (UITweener.Method)7, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Position, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 517f, 7, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		}
		tweenAnimator.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1218f, 8, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Alpha, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 824f, 2, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.FEHALDPLGDB(5, (TweenAnimator.MNAIKKJDPLK)(-115), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1076f, 5, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(82, (TweenAnimator.MNAIKKJDPLK)38, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1590f, 0, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(115, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1238f, 1561f, -1, 675f, UITweener.Method.Linear, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(69, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 240f, -38, null, UITweener.Method.EaseIn);
		float num2 = num / 1443f;
		iIFHMKCKGAI.LJNGJJGJKMO = (GLLMPCPLLCD ? 7 : 0);
		iNFLHPGMEOB = -51;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1919f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1341f, lJNGJJGJKMO, 1265f, (UITweener.Method)7, (UITweener.Style)3, 0);
		tweenAnimator.FEHALDPLGDB(-98, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HFENNCENBFE.gameObject, num2, 1801f, 1071f, -25, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LJCDGJKCNEC;
		return tweenAnimator;
	}

	protected virtual TweenAnimator KGGBDAEJJID(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1549f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, 286f, 1560f, -1, 594f, (UITweener.Method)6, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1797f, 772f, 382f);
		object oEIICEJPGKI = localPosition + new Vector3(724f, 108f, 1208f);
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 857f, -1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 474f, 3, null, UITweener.Method.EaseOut);
		tweenAnimator.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1619f, 4, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 969f, 2, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		}
		tweenAnimator.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.Alpha, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 746f, 2, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Scale, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 691f, 5, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(5, (TweenAnimator.MNAIKKJDPLK)(-12), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1630f, 2, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(-106, (TweenAnimator.MNAIKKJDPLK)(-88), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1279f, 8, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(84, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 786f, 709f, -1, 1174f, UITweener.Method.EaseIn);
		tweenAnimator.MNEFMODDFFK(-12, TweenAnimator.MNAIKKJDPLK.Rotation, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1338f, 27, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		float num2 = num / 1206f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 2 : 2);
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 944f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 107f, lJNGJJGJKMO, 1332f, UITweener.Method.EaseOut, (UITweener.Style)4, 0);
		tweenAnimator.NFLKPCIHOPJ(-20, TweenAnimator.MNAIKKJDPLK.Scale, HFENNCENBFE.gameObject, num2, 49f, 439f, -118, null, UITweener.Method.BounceOut);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.MAKLHLCDIKD;
		return tweenAnimator;
	}

	protected virtual TweenAnimator EKNDKHAEJIO(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1367f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CLLHLNOFFNM.gameObject, num, 725f, 1859f, -1, 253f, (UITweener.Method)7);
		int iNFLHPGMEOB = 8;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(233f, 432f, 871f);
		object oEIICEJPGKI = localPosition + new Vector3(1499f, 1197f, 6f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 420f, -1, oEIICEJPGKI, (UITweener.Method)6);
		tweenAnimator.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1403f, 8, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		tweenAnimator.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.TextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 285f, 0, null, UITweener.Method.Linear);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(3, TweenAnimator.MNAIKKJDPLK.Scale, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 73f, 2, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1126f, 2, null, UITweener.Method.BounceOut);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 114f, 1, null, (UITweener.Method)7);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(1, (TweenAnimator.MNAIKKJDPLK)48, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1417f, 4, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(-8, (TweenAnimator.MNAIKKJDPLK)66, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 633f, 7, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(127, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1016f, 1609f, -1, 1393f, (UITweener.Method)8, UITweener.Style.Loop);
		tweenAnimator.AddTween(-59, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 329f, -14, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		float num2 = num / 667f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 5 : 8);
		iNFLHPGMEOB = 9;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1198f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 404f, lJNGJJGJKMO, 329f, (UITweener.Method)7, UITweener.Style.Once, 5);
		tweenAnimator.BPEKAKFKCIG(69, TweenAnimator.MNAIKKJDPLK.Scale, HFENNCENBFE.gameObject, num2, 498f, 1258f, 48, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.MAKLHLCDIKD;
		return tweenAnimator;
	}

	protected override TweenAnimator NBAJOILBHCA(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 693f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, CLLHLNOFFNM.gameObject, num, 329f, 1957f, -1, 765f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1532f, 941f, 506f);
		object oEIICEJPGKI = localPosition + new Vector3(1131f, 511f, 165f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 849f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 389f, 6, null, UITweener.Method.EaseOut);
		tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Alpha, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 300f, 3, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.Alpha, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 37f, 8, null, (UITweener.Method)6);
		}
		tweenAnimator.NFLKPCIHOPJ(3, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1182f, 6);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.Alpha, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1172f, 2, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(6, (TweenAnimator.MNAIKKJDPLK)72, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 81f, 6, null, (UITweener.Method)6);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(18, (TweenAnimator.MNAIKKJDPLK)75, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1567f, 3, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		}
		tweenAnimator.NFLKPCIHOPJ(91, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1551f, 1146f, -1, 1007f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(67, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1073f, -60, null, UITweener.Method.BounceIn);
		float num2 = num / 1337f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 4 : 3);
		iNFLHPGMEOB = 60;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1741f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 251f, lJNGJJGJKMO, 713f, UITweener.Method.Linear, (UITweener.Style)7, 4);
		tweenAnimator.FEHALDPLGDB(91, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HFENNCENBFE.gameObject, num2, 955f, 1863f, 122, null, (UITweener.Method)6, UITweener.Style.Loop);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.MAKLHLCDIKD;
		return tweenAnimator;
	}

	protected virtual void FBCMMMNAAIF(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 3f;
		base.NCJHMCBDICD(GLLMPCPLLCD);
	}

	protected virtual void EBGCOIINLKG(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1046f;
		base.IEGOOEPECDH(GLLMPCPLLCD);
	}

	protected override void GOGHDJFDKKN(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 866f;
		base.IIEIMKBKDAC(GLLMPCPLLCD);
	}

	protected virtual void GKBICIMNGKD(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1919f;
		base.EOOAEGLBHPP(GLLMPCPLLCD);
	}

	[SpecialName]
	public void AEIBAKLPGEI(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	[SpecialName]
	public void NOKNEHEHAIJ(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JAJGPMLLLOK(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual void KAAEHALKHGD(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1660f;
		base.FKJPLFBDNLD(GLLMPCPLLCD);
	}

	protected virtual TweenAnimator AKHFHBFHDJH(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 233f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Color, CLLHLNOFFNM.gameObject, num, 1777f, 191f, -1, 58f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 3;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1879f, 1902f, 1369f);
		object oEIICEJPGKI = localPosition + new Vector3(1711f, 1649f, 1468f);
		tweenAnimator.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 902f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 956f, 1, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		tweenAnimator.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Position, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1463f, 0, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 517f, 2, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		}
		tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.Scale, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 987f, 7, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1150f, 0, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.FEHALDPLGDB(0, (TweenAnimator.MNAIKKJDPLK)(-16), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 969f, 4, null, (UITweener.Method)6);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(-105, (TweenAnimator.MNAIKKJDPLK)14, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1121f, 8, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(103, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 815f, 1804f, -1, 637f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1175f, 32, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		float num2 = num / 876f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 3 : 0);
		iNFLHPGMEOB = -18;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1246f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1773f, lJNGJJGJKMO, 135f, UITweener.Method.EaseOut, (UITweener.Style)3, 0);
		tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Position, HFENNCENBFE.gameObject, num2, 442f, 103f, 91, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LJCDGJKCNEC;
		return tweenAnimator;
	}

	protected virtual TweenAnimator DMELPDDFPEC(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 57f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, CLLHLNOFFNM.gameObject, num, 49f, 409f, -1, 1337f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 8;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1558f, 40f, 1422f);
		object oEIICEJPGKI = localPosition + new Vector3(1967f, 432f, 1979f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1575f, -1, oEIICEJPGKI, (UITweener.Method)6);
		tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 20f, 0, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		tweenAnimator.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 54f, 0, null, (UITweener.Method)6, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.TextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1554f, 4, null, (UITweener.Method)7);
		}
		tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 729f, 5, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.TextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1626f, 5, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.FEHALDPLGDB(5, (TweenAnimator.MNAIKKJDPLK)72, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 66f, 7, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(10, TweenAnimator.MNAIKKJDPLK.ProgressBar, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 734f, 4, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		}
		tweenAnimator.AddTween(-5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1058f, 1882f, -1, 1250f, (UITweener.Method)8, UITweener.Style.Loop);
		tweenAnimator.NFLKPCIHOPJ(-30, TweenAnimator.MNAIKKJDPLK.Position, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 727f, -33, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		float num2 = num / 1976f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 1 : 5);
		iNFLHPGMEOB = 119;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1730f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 933f, lJNGJJGJKMO, 862f, UITweener.Method.Linear, UITweener.Style.PingPong, 5);
		tweenAnimator.BPEKAKFKCIG(-58, TweenAnimator.MNAIKKJDPLK.Color, HFENNCENBFE.gameObject, num2, 276f, 758f, 101, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.NNIJEDKBPGJ;
		return tweenAnimator;
	}

	protected virtual TweenAnimator MAPOAOKPHCE(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 560f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, 1091f, 609f, -1, 42f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 5;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(83f, 724f, 948f);
		object oEIICEJPGKI = localPosition + new Vector3(1159f, 1899f, 351f);
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 936f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1379f, 5, null, UITweener.Method.EaseIn);
		tweenAnimator.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Rotation, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1843f, 0, null, (UITweener.Method)8, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 309f, 0, null, (UITweener.Method)7, UITweener.Style.Loop);
		}
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Position, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 464f, 6, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1157f, 5, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.AddTween(4, (TweenAnimator.MNAIKKJDPLK)(-70), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1650f, 7, null, UITweener.Method.EaseIn);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(-56, (TweenAnimator.MNAIKKJDPLK)51, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 123f, 8, null, UITweener.Method.EaseOut);
		}
		tweenAnimator.MNEFMODDFFK(53, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 621f, 613f, -1, 953f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		tweenAnimator.MNEFMODDFFK(119, TweenAnimator.MNAIKKJDPLK.Color, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1380f, -100, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		float num2 = num / 1667f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 5 : 3);
		iNFLHPGMEOB = -60;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1083f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1134f, lJNGJJGJKMO, 1825f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		tweenAnimator.MNEFMODDFFK(45, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HFENNCENBFE.gameObject, num2, 1130f, 1167f, -84, null, (UITweener.Method)8);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.KJIFNOJILDB;
		return tweenAnimator;
	}

	protected virtual void HIBEACDOEON(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 438f;
		base.FKJPLFBDNLD(GLLMPCPLLCD);
	}

	protected virtual TweenAnimator DNJCMMGOMED(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 596f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, CLLHLNOFFNM.gameObject, num, 386f, 1699f, -1, 824f, (UITweener.Method)6, UITweener.Style.Loop);
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(750f, 260f, 1842f);
		object oEIICEJPGKI = localPosition + new Vector3(490f, 800f, 522f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1655f, -1, oEIICEJPGKI, (UITweener.Method)7);
		tweenAnimator.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1735f, 2, null, UITweener.Method.Linear, UITweener.Style.Loop);
		tweenAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.Rotation, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1542f, 0, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1977f, 7, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 46f, 3, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Scale, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 690f, 5, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(3, (TweenAnimator.MNAIKKJDPLK)124, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1849f, 7, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(78, (TweenAnimator.MNAIKKJDPLK)(-17), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1197f, 4, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		}
		tweenAnimator.FEHALDPLGDB(104, TweenAnimator.MNAIKKJDPLK.Color, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 723f, 1685f, -1, 1865f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		tweenAnimator.AddTween(-105, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1329f, 76, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		float num2 = num / 182f;
		iIFHMKCKGAI.LJNGJJGJKMO = (GLLMPCPLLCD ? 8 : 0);
		iNFLHPGMEOB = 94;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1032f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 733f, lJNGJJGJKMO, 180f, UITweener.Method.Linear);
		tweenAnimator.MNEFMODDFFK(127, TweenAnimator.MNAIKKJDPLK.Position, HFENNCENBFE.gameObject, num2, 1557f, 1562f, -85, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.KJIFNOJILDB;
		return tweenAnimator;
	}

	[SpecialName]
	public void BPJCDFGEKDO(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual TweenAnimator FIKJOHAJKGK(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1020f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Color, CLLHLNOFFNM.gameObject, num, 1343f, 1805f, -1, 1481f, UITweener.Method.Linear);
		int iNFLHPGMEOB = 5;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1713f, 765f, 1803f);
		object oEIICEJPGKI = localPosition + new Vector3(1556f, 1793f, 445f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1929f, -1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		tweenAnimator.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 799f, 4, null, (UITweener.Method)6);
		tweenAnimator.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Alpha, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 631f, 3, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1646f, 8, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		}
		tweenAnimator.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 937f, 3, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 63f, 8, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Position, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 304f, 7, null, (UITweener.Method)7);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(-96, (TweenAnimator.MNAIKKJDPLK)123, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 844f, 1, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		}
		tweenAnimator.AddTween(35, TweenAnimator.MNAIKKJDPLK.Rotation, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1211f, 449f, -1, 1509f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		tweenAnimator.NFLKPCIHOPJ(-78, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 468f, 112);
		float num2 = num / 237f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 8 : 7);
		iNFLHPGMEOB = 102;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1690f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 740f, lJNGJJGJKMO, 779f, UITweener.Method.BounceIn, (UITweener.Style)7, 3);
		tweenAnimator.FEHALDPLGDB(-43, TweenAnimator.MNAIKKJDPLK.Color, HFENNCENBFE.gameObject, num2, 191f, 233f, 15, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.MAKLHLCDIKD;
		return tweenAnimator;
	}

	protected virtual void PDPMNKKKKCC(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1120f;
		base.IIEIMKBKDAC(GLLMPCPLLCD);
	}

	[SpecialName]
	public void ICFDIGKLPCD(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HFJEHGAFLBE(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual void ODNGEJCPKIP(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1297f;
		base.KMLCLFGGGBK(GLLMPCPLLCD);
	}

	protected virtual TweenAnimator LNAGAJNLCGP(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 498f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CLLHLNOFFNM.gameObject, num, 1438f, 623f, -1, 215f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1442f, 770f, 607f);
		object oEIICEJPGKI = localPosition + new Vector3(706f, 134f, 1618f);
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 640f, -1, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Loop, 0);
		tweenAnimator.AddTween(6, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 23f, 6, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Color, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 846f, 5, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(2, TweenAnimator.MNAIKKJDPLK.Alpha, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 723f, 6, null, (UITweener.Method)8, UITweener.Style.Loop);
		}
		tweenAnimator.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 427f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.Position, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1684f, 3, null, UITweener.Method.EaseIn);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(1, (TweenAnimator.MNAIKKJDPLK)102, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1409f, 0, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(-53, (TweenAnimator.MNAIKKJDPLK)(-29), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 947f, 2, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		}
		tweenAnimator.AddTween(112, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1648f, 1957f, -1, 1499f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.FEHALDPLGDB(71, TweenAnimator.MNAIKKJDPLK.Position, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 289f, -34, null, (UITweener.Method)6);
		float num2 = num / 1301f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 3 : 2);
		iNFLHPGMEOB = 21;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 78f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 171f, lJNGJJGJKMO, 544f, UITweener.Method.BounceIn, (UITweener.Style)8, 3);
		tweenAnimator.AddTween(-114, TweenAnimator.MNAIKKJDPLK.Scale, HFENNCENBFE.gameObject, num2, 164f, 1673f, 51, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.ECPMEMNKMCB;
		return tweenAnimator;
	}

	protected virtual TweenAnimator DOLGLJLNKGJ(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1526f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, 1533f, 255f, -1, 168f, (UITweener.Method)6);
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(555f, 1066f, 671f);
		object oEIICEJPGKI = localPosition + new Vector3(1865f, 1056f, 1185f);
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 91f, -1, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Once, 0);
		tweenAnimator.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1628f, 7, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.Color, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 949f, 5, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 520f, 2, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		}
		tweenAnimator.AddTween(5, TweenAnimator.MNAIKKJDPLK.Color, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1707f, 5, null, UITweener.Method.BounceOut);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.Color, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 425f, 5, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.AlphaHider, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1249f, 6, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(24, (TweenAnimator.MNAIKKJDPLK)83, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1573f, 5, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(118, TweenAnimator.MNAIKKJDPLK.Scale, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 358f, 1898f, -1, 1288f, UITweener.Method.EaseOut);
		tweenAnimator.BPEKAKFKCIG(15, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 159f, -128, null, UITweener.Method.EaseIn);
		float num2 = num / 99f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 3 : 4);
		iNFLHPGMEOB = 72;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1521f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 264f, lJNGJJGJKMO, 1555f, (UITweener.Method)8, UITweener.Style.Once, 7);
		tweenAnimator.MNEFMODDFFK(-92, TweenAnimator.MNAIKKJDPLK.TextCounter, HFENNCENBFE.gameObject, num2, 1406f, 1228f, -21, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.NNIJEDKBPGJ;
		return tweenAnimator;
	}

	protected virtual void BCGGNHPPHML(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1814f;
		base.OIPPPJHBBIB(GLLMPCPLLCD);
	}

	protected virtual void BBNFMHDOGEG(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1871f;
		base.EOOAEGLBHPP(GLLMPCPLLCD);
	}

	protected virtual TweenAnimator BFCKAADCLEJ(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1668f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, 1868f, 1396f, -1, 692f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 6;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(323f, 573f, 1748f);
		object oEIICEJPGKI = localPosition + new Vector3(1117f, 349f, 1155f);
		tweenAnimator.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1415f, -1, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Loop, 0);
		tweenAnimator.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 1608f, 4, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		tweenAnimator.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Color, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 826f, 2, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.Rotation, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1965f, 2, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		}
		tweenAnimator.AddTween(6, TweenAnimator.MNAIKKJDPLK.Scale, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1577f, 6, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.Rotation, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 402f, 4, null, UITweener.Method.BounceOut);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(4, (TweenAnimator.MNAIKKJDPLK)(-1), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1608f, 8, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(53, (TweenAnimator.MNAIKKJDPLK)(-32), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1284f, 3, null, (UITweener.Method)6);
		}
		tweenAnimator.NFLKPCIHOPJ(-111, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 421f, 650f, -1, 1557f, (UITweener.Method)8, UITweener.Style.Loop);
		tweenAnimator.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1280f, -117, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		float num2 = num / 938f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 3 : 7);
		iNFLHPGMEOB = -64;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 634f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 789f, lJNGJJGJKMO, 1794f, UITweener.Method.EaseInOut, UITweener.Style.PingPong, 0);
		tweenAnimator.FEHALDPLGDB(-114, TweenAnimator.MNAIKKJDPLK.Color, HFENNCENBFE.gameObject, num2, 1479f, 1753f, 111, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.MAKLHLCDIKD;
		return tweenAnimator;
	}

	protected override TweenAnimator ILFKPKAKDPI(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 827f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.TextCounter, CLLHLNOFFNM.gameObject, num, 215f, 564f, -1, 291f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(733f, 1268f, 469f);
		object oEIICEJPGKI = localPosition + new Vector3(898f, 501f, 478f);
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 427f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 305f, 6, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Scale, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1090f, 4, null, UITweener.Method.BounceOut);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Color, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 181f, 0, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		}
		tweenAnimator.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.Alpha, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1458f, 5, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.Rotation, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 182f, 6, null, (UITweener.Method)6, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Color, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 735f, 1, null, (UITweener.Method)7, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(-78, (TweenAnimator.MNAIKKJDPLK)(-121), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 127f, 4, null, (UITweener.Method)8, UITweener.Style.Loop);
		}
		tweenAnimator.NFLKPCIHOPJ(51, TweenAnimator.MNAIKKJDPLK.Scale, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 943f, 1402f, -1, 1424f, (UITweener.Method)7, UITweener.Style.Once, 0);
		tweenAnimator.FEHALDPLGDB(-78, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 172f, -80, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		float num2 = num / 1641f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 3 : 7);
		iNFLHPGMEOB = -74;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1274f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 750f, lJNGJJGJKMO, 1170f, UITweener.Method.EaseOut, UITweener.Style.PingPong, 5);
		tweenAnimator.FEHALDPLGDB(95, TweenAnimator.MNAIKKJDPLK.Rotation, HFENNCENBFE.gameObject, num2, 1867f, 1802f, -19, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LJCDGJKCNEC;
		return tweenAnimator;
	}

	[SpecialName]
	public void DFGMODNKDPK(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual TweenAnimator NENJKPLAHOE(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1413f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Color, CLLHLNOFFNM.gameObject, num, 1296f, 604f, -1, 733f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 7;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(292f, 352f, 428f);
		object oEIICEJPGKI = localPosition + new Vector3(1071f, 820f, 699f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 683f, -1, oEIICEJPGKI, UITweener.Method.BounceOut);
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 300f, 0, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		tweenAnimator.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 423f, 7, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.Rotation, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 784f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		}
		tweenAnimator.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Rotation, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 681f, 3, null, UITweener.Method.BounceIn);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Scale, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 211f, 3, null, (UITweener.Method)8);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(7, (TweenAnimator.MNAIKKJDPLK)52, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 901f, 1, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(-93, (TweenAnimator.MNAIKKJDPLK)(-38), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 891f, 5, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		}
		tweenAnimator.AddTween(98, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1447f, 186f, -1, 1307f, (UITweener.Method)7, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(86, TweenAnimator.MNAIKKJDPLK.Rotation, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1308f, -100, null, (UITweener.Method)8);
		float num2 = num / 821f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 3 : 6);
		iNFLHPGMEOB = -54;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 913f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 294f, lJNGJJGJKMO, 1036f, (UITweener.Method)8, UITweener.Style.PingPong, 4);
		tweenAnimator.NFLKPCIHOPJ(-64, TweenAnimator.MNAIKKJDPLK.Color, HFENNCENBFE.gameObject, num2, 1115f, 1013f, 13, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.MAKLHLCDIKD;
		return tweenAnimator;
	}

	protected virtual TweenAnimator JLHKBPDBAMF(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1079f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Alpha, CLLHLNOFFNM.gameObject, num, 15f, 1282f, -1, 1788f, (UITweener.Method)7);
		int iNFLHPGMEOB = 6;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(108f, 1744f, 379f);
		object oEIICEJPGKI = localPosition + new Vector3(278f, 352f, 344f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 406f, -1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		tweenAnimator.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 921f, 8, null, UITweener.Method.Linear, UITweener.Style.Loop);
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Color, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1025f, 1, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.TextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1393f, 8, null, UITweener.Method.Linear);
		}
		tweenAnimator.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 531f, 3, null, (UITweener.Method)6);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Rotation, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1487f, 5, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(5, (TweenAnimator.MNAIKKJDPLK)(-125), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 121f, 7, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.TimeCounter, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1237f, 8, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		}
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1296f, 830f, -1, 1139f, UITweener.Method.EaseIn);
		tweenAnimator.AddTween(-65, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 879f, 104, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		float num2 = num / 729f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 8 : 8);
		iNFLHPGMEOB = -99;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1678f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 372f, lJNGJJGJKMO, 1545f, UITweener.Method.EaseIn, (UITweener.Style)5, 2);
		tweenAnimator.AddTween(-73, TweenAnimator.MNAIKKJDPLK.TextCounter, HFENNCENBFE.gameObject, num2, 1474f, 107f, -50, null, (UITweener.Method)8);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.NNIJEDKBPGJ;
		return tweenAnimator;
	}

	protected virtual void NHAONLLFBLF(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 715f;
		base.IEGOOEPECDH(GLLMPCPLLCD);
	}

	[SpecialName]
	public void KGMHOEAJOFC(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual void PDLCGNADKAD(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 904f;
		base.IGICOIADLBC(GLLMPCPLLCD);
	}

	[SpecialName]
	public void IMOOIGJPCPC(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual void OFMMJNILGMH(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1023f;
		base.OIPPPJHBBIB(GLLMPCPLLCD);
	}

	protected virtual void LNIEGOBIMIE(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 669f;
		base.OIPPPJHBBIB(GLLMPCPLLCD);
	}

	[SpecialName]
	public void CJIKHPEOGHK(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual TweenAnimator NPABDOBMAHK(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1292f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CLLHLNOFFNM.gameObject, num, 1392f, 244f, -1, 497f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(946f, 645f, 1168f);
		object oEIICEJPGKI = localPosition + new Vector3(1908f, 58f, 417f);
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1756f, -1, oEIICEJPGKI, UITweener.Method.BounceIn, UITweener.Style.Loop);
		tweenAnimator.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 679f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		tweenAnimator.AddTween(4, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 626f, 1);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1807f, 3, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		}
		tweenAnimator.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.Scale, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 847f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.Position, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 702f, 4, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(0, (TweenAnimator.MNAIKKJDPLK)(-27), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1560f, 1, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(-20, (TweenAnimator.MNAIKKJDPLK)(-37), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 847f, 6, null, (UITweener.Method)7);
		}
		tweenAnimator.MNEFMODDFFK(100, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 204f, 223f, -1, 961f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		tweenAnimator.NFLKPCIHOPJ(-108, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 188f, -51, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		float num2 = num / 1801f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 8 : 7);
		iNFLHPGMEOB = -112;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 329f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 233f, lJNGJJGJKMO, 1486f, UITweener.Method.BounceIn, (UITweener.Style)4, 0);
		tweenAnimator.FEHALDPLGDB(-17, TweenAnimator.MNAIKKJDPLK.Alpha, HFENNCENBFE.gameObject, num2, 63f, 280f, -87, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.KJIFNOJILDB;
		return tweenAnimator;
	}

	protected virtual TweenAnimator OADGOBNIAKM(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 67f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CLLHLNOFFNM.gameObject, num, 1605f, 678f, -1, 1028f, UITweener.Method.Linear);
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(155f, 124f, 785f);
		object oEIICEJPGKI = localPosition + new Vector3(1059f, 198f, 1857f);
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 356f, -1, oEIICEJPGKI, (UITweener.Method)6, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 581f, 4, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		tweenAnimator.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 707f, 4, null, (UITweener.Method)7);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(3, TweenAnimator.MNAIKKJDPLK.TextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 624f, 6, null, (UITweener.Method)8, UITweener.Style.Loop);
		}
		tweenAnimator.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Rotation, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 793f, 8, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1698f, 1, null, (UITweener.Method)7);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(5, (TweenAnimator.MNAIKKJDPLK)76, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 91f, 8, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(23, (TweenAnimator.MNAIKKJDPLK)(-2), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 76f, 6, null, (UITweener.Method)7, UITweener.Style.Loop);
		}
		tweenAnimator.AddTween(18, TweenAnimator.MNAIKKJDPLK.Color, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 356f, 1964f, -1, 1346f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		tweenAnimator.BPEKAKFKCIG(-122, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1195f, -25, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		float num2 = num / 1235f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 2 : 2);
		iNFLHPGMEOB = 27;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1237f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1760f, lJNGJJGJKMO, 632f, UITweener.Method.EaseIn, (UITweener.Style)3, 2);
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Color, HFENNCENBFE.gameObject, num2, 1039f, 1308f, -122, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.NNIJEDKBPGJ;
		return tweenAnimator;
	}

	[SpecialName]
	public void JINKBDDEFFM(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual TweenAnimator OPFIBJJPNMO(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 280f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Alpha, CLLHLNOFFNM.gameObject, num, 1942f, 1525f, -1, 539f, (UITweener.Method)8, UITweener.Style.Loop);
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(13f, 1286f, 1943f);
		object oEIICEJPGKI = localPosition + new Vector3(964f, 1735f, 1828f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 411f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Once, 0);
		tweenAnimator.AddTween(2, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 1340f, 6, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 361f, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.TextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1578f, 5, null, (UITweener.Method)8);
		}
		tweenAnimator.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Rotation, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1254f, 3, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Position, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1579f, 1, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(7, (TweenAnimator.MNAIKKJDPLK)(-56), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 428f, 8, null, UITweener.Method.BounceOut);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(60, (TweenAnimator.MNAIKKJDPLK)(-78), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1526f, 0, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		}
		tweenAnimator.MNEFMODDFFK(-6, TweenAnimator.MNAIKKJDPLK.Rotation, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 236f, 1338f, -1, 1886f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		tweenAnimator.BPEKAKFKCIG(-40, TweenAnimator.MNAIKKJDPLK.Scale, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1115f, 81, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		float num2 = num / 29f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 5 : 0);
		iNFLHPGMEOB = -99;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1407f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 403f, lJNGJJGJKMO, 890f, UITweener.Method.BounceOut, (UITweener.Style)3, 7);
		tweenAnimator.FEHALDPLGDB(50, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HFENNCENBFE.gameObject, num2, 379f, 731f, -55, null, UITweener.Method.EaseOut);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LGJCNCHBFDA;
		return tweenAnimator;
	}

	protected virtual void CBFKJLJOEHK(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1269f;
		base.MIOLCDHIFNJ(GLLMPCPLLCD);
	}

	protected virtual void IPAKPLDNPNJ(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 349f;
		base.GOGHDJFDKKN(GLLMPCPLLCD);
	}

	protected virtual TweenAnimator GHJAAOCHAJJ(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 598f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, 356f, 619f, -1, 272f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 8;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(141f, 836f, 368f);
		object oEIICEJPGKI = localPosition + new Vector3(252f, 1972f, 764f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 2f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		tweenAnimator.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1935f, 5, null, UITweener.Method.EaseOut);
		tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 601f, 2, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Rotation, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 247f, 0, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 714f, 4, null, (UITweener.Method)7, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.TextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1417f, 0, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(1, (TweenAnimator.MNAIKKJDPLK)120, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 44f, 4, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(73, (TweenAnimator.MNAIKKJDPLK)(-45), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1507f, 2, null, (UITweener.Method)6, UITweener.Style.Loop);
		}
		tweenAnimator.AddTween(-90, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 763f, 1046f, -1, 1318f, (UITweener.Method)6, UITweener.Style.Loop);
		tweenAnimator.MNEFMODDFFK(59, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 235f, -78, null, (UITweener.Method)8, UITweener.Style.Loop);
		float num2 = num / 207f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 1 : 8);
		iNFLHPGMEOB = 78;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1000f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 928f, lJNGJJGJKMO, 593f, UITweener.Method.BounceIn, (UITweener.Style)4, 7);
		tweenAnimator.FEHALDPLGDB(52, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HFENNCENBFE.gameObject, num2, 176f, 1261f, 91, null, UITweener.Method.Linear, UITweener.Style.Loop);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.KJIFNOJILDB;
		return tweenAnimator;
	}

	protected virtual TweenAnimator LCOFHLAEIHG(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1403f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, 1370f, 637f, -1, 682f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1987f, 1571f, 593f);
		object oEIICEJPGKI = localPosition + new Vector3(1203f, 826f, 1278f);
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 233f, -1, oEIICEJPGKI, UITweener.Method.BounceOut);
		tweenAnimator.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 416f, 4, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		tweenAnimator.AddTween(5, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1358f, 3, null, UITweener.Method.EaseIn);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1141f, 0, null, UITweener.Method.Linear, UITweener.Style.Loop);
		}
		tweenAnimator.NFLKPCIHOPJ(3, TweenAnimator.MNAIKKJDPLK.Alpha, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 853f, 1, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Scale, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 647f, 7, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(8, (TweenAnimator.MNAIKKJDPLK)70, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 366f, 3, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(-67, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1231f, 5, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		}
		tweenAnimator.BPEKAKFKCIG(85, TweenAnimator.MNAIKKJDPLK.Position, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1750f, 1295f, -1, 1790f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.FEHALDPLGDB(-87, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 506f, -91, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		float num2 = num / 263f;
		iIFHMKCKGAI.LJNGJJGJKMO = (GLLMPCPLLCD ? 1 : 8);
		iNFLHPGMEOB = 76;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 726f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 52f, lJNGJJGJKMO, 1401f, UITweener.Method.BounceOut, UITweener.Style.PingPong, 5);
		tweenAnimator.AddTween(-103, TweenAnimator.MNAIKKJDPLK.TextCounter, HFENNCENBFE.gameObject, num2, 1364f, 79f, -110, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LGJCNCHBFDA;
		return tweenAnimator;
	}

	[SpecialName]
	public void KMAGABFPLKG(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual void KENPNMAFGEN(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1068f;
		base.BLHGPKCDPBH(GLLMPCPLLCD);
	}

	protected virtual void PBAJIJCOIFJ(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 880f;
		base.IIEIMKBKDAC(GLLMPCPLLCD);
	}

	[SpecialName]
	public void OKBMPGNNAKL(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual TweenAnimator ONMACNEEMCK(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1052f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, 656f, 936f, -1, 1203f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 7;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(693f, 1075f, 174f);
		object oEIICEJPGKI = localPosition + new Vector3(1561f, 873f, 633f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1732f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		tweenAnimator.AddTween(2, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1426f, 2, null, (UITweener.Method)8);
		tweenAnimator.AddTween(6, TweenAnimator.MNAIKKJDPLK.Color, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 676f, 4);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.Color, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 21f, 0, null, (UITweener.Method)8);
		}
		tweenAnimator.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Rotation, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1559f, 1, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(3, TweenAnimator.MNAIKKJDPLK.TextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 139f, 1, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(4, (TweenAnimator.MNAIKKJDPLK)69, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1004f, 7, null, UITweener.Method.EaseOut);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(8, (TweenAnimator.MNAIKKJDPLK)59, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 662f, 7);
		}
		tweenAnimator.NFLKPCIHOPJ(-88, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1144f, 1561f, -1, 951f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		tweenAnimator.FEHALDPLGDB(-23, TweenAnimator.MNAIKKJDPLK.Rotation, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 916f, -41, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		float num2 = num / 589f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 7 : 4);
		iNFLHPGMEOB = 20;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 1722f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 40f, lJNGJJGJKMO, 1406f, UITweener.Method.EaseInOut, (UITweener.Style)6);
		tweenAnimator.BPEKAKFKCIG(-104, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HFENNCENBFE.gameObject, num2, 1435f, 588f, 123, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.KJIFNOJILDB;
		return tweenAnimator;
	}

	protected virtual TweenAnimator EINJDKOOHKG(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1497f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.TextCounter, CLLHLNOFFNM.gameObject, num, 1036f, 232f, -1, 569f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(181f, 1251f, 63f);
		object oEIICEJPGKI = localPosition + new Vector3(1966f, 544f, 1151f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 217f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Once, 0);
		tweenAnimator.MNEFMODDFFK(3, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 1146f, 5, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		tweenAnimator.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.Alpha, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1361f, 6, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.Rotation, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 821f, 0, null, (UITweener.Method)7);
		}
		tweenAnimator.AddTween(6, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 980f, 2, null, (UITweener.Method)8, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(4, TweenAnimator.MNAIKKJDPLK.TextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1774f, 7, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.AddTween(7, (TweenAnimator.MNAIKKJDPLK)111, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 561f, 5, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(85, (TweenAnimator.MNAIKKJDPLK)102, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1282f, 3, null, (UITweener.Method)6, UITweener.Style.Loop);
		}
		tweenAnimator.BPEKAKFKCIG(-54, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 972f, 637f, -1, 1563f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		tweenAnimator.AddTween(52, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1962f, -2, null, UITweener.Method.EaseIn);
		float num2 = num / 1420f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 6 : 2);
		iNFLHPGMEOB = 89;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 379f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1020f, lJNGJJGJKMO, 1738f, UITweener.Method.EaseInOut, (UITweener.Style)4, 3);
		tweenAnimator.BPEKAKFKCIG(-50, TweenAnimator.MNAIKKJDPLK.Color, HFENNCENBFE.gameObject, num2, 315f, 1897f, 46, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.KJIFNOJILDB;
		return tweenAnimator;
	}

	protected virtual void KIOHCAEDCLG(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 386f;
		base.BLHGPKCDPBH(GLLMPCPLLCD);
	}

	protected virtual void BINBIHEKOJJ(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1022f;
		base.KMLCLFGGGBK(GLLMPCPLLCD);
	}

	[SpecialName]
	public void OIBHJGDBNKA(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual void NHPNDBHDBDE(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 741f;
		base.IGICOIADLBC(GLLMPCPLLCD);
	}

	[SpecialName]
	public void HDPHDIKCKEE(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EKEOOMOJMBG(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected override void NCJHMCBDICD(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 0f;
		base.NCJHMCBDICD(GLLMPCPLLCD);
	}

	[SpecialName]
	public void CCODNKJHFEF(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	[SpecialName]
	public void OODNIBONBPB(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	protected virtual void KBNCJEGCOHP(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 1574f;
		base.EOOAEGLBHPP(GLLMPCPLLCD);
	}

	protected virtual void GAPFOKGDKHK(bool GLLMPCPLLCD)
	{
		HFENNCENBFE.alpha = 192f;
		base.GOGHDJFDKKN(GLLMPCPLLCD);
	}

	protected override TweenAnimator BCHDJNDIBGG(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 0.4f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, CLLHLNOFFNM.gameObject, num, 1f, 0f, -1, 0f);
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(0f, 10f, 0f);
		object oEIICEJPGKI = localPosition + new Vector3(0f, -20f, 0f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI);
		tweenAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 0f, 2);
		tweenAnimator.AddTween(4, TweenAnimator.MNAIKKJDPLK.TextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 0f, 3);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(5, TweenAnimator.MNAIKKJDPLK.TextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 0f, 4);
		}
		tweenAnimator.AddTween(6, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 0f, 3);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(7, TweenAnimator.MNAIKKJDPLK.TextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 0f, 4);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.TextCounterLong, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 0f, 3);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(9, TweenAnimator.MNAIKKJDPLK.TextCounterLong, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 0f, 4);
		}
		tweenAnimator.AddTween(20, TweenAnimator.MNAIKKJDPLK.Alpha, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 1f, 0f, -1, 0f);
		tweenAnimator.AddTween(21, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 0f, 20);
		float num2 = num / 7f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 6 : 7);
		iNFLHPGMEOB = 25;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 0.4f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, lJNGJJGJKMO, 0f, UITweener.Method.EaseInOut, UITweener.Style.PingPong, 5);
		tweenAnimator.AddTween(26, TweenAnimator.MNAIKKJDPLK.Alpha, HFENNCENBFE.gameObject, num2, 0f, 0f, 25);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LJCDGJKCNEC;
		return tweenAnimator;
	}

	protected virtual TweenAnimator JKNHEMHNCCC(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		IIFHMKCKGAI iIFHMKCKGAI = new IIFHMKCKGAI();
		float num = 1647f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, 1901f, 1945f, -1, 594f, (UITweener.Method)8);
		int iNFLHPGMEOB = 5;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1747f, 1035f, 1775f);
		object oEIICEJPGKI = localPosition + new Vector3(1051f, 1660f, 817f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1385f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Loop);
		tweenAnimator.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 1092f, 5, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 693f, 1, null, UITweener.Method.EaseOut, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.Color, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 950f, 4, null, (UITweener.Method)7);
		}
		tweenAnimator.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1683f, 1, null, (UITweener.Method)6, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 916f, 2, null, UITweener.Method.EaseIn);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1943f, 0, null, (UITweener.Method)8);
		}
		if (KEGGAOMKIAK && GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(122, (TweenAnimator.MNAIKKJDPLK)(-21), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 788f, 7, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		}
		tweenAnimator.MNEFMODDFFK(-109, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, 337f, 1007f, -1, 1917f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.FEHALDPLGDB(-29, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiScreenSingle<EndScreen>.instance.HGPGKHLOHEF.AGMGODJNNAC.gameObject, num, BNABPLAGMEM, 1242f, 26, null, UITweener.Method.EaseOut);
		float num2 = num / 1693f;
		iIFHMKCKGAI.LJNGJJGJKMO = ((!GLLMPCPLLCD) ? 2 : 4);
		iNFLHPGMEOB = -83;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = HFENNCENBFE.gameObject;
		kBJEOEEOEFG = num2;
		oEIICEJPGKI = 101f;
		int lJNGJJGJKMO = iIFHMKCKGAI.LJNGJJGJKMO;
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 176f, lJNGJJGJKMO, 858f, UITweener.Method.EaseIn, (UITweener.Style)7, 2);
		tweenAnimator.BPEKAKFKCIG(-24, TweenAnimator.MNAIKKJDPLK.Scale, HFENNCENBFE.gameObject, num2, 557f, 824f, 108, null, UITweener.Method.BounceOut);
		tweenAnimator.JHDBHGCKPDM = iIFHMKCKGAI.LJCDGJKCNEC;
		return tweenAnimator;
	}

	[SpecialName]
	public void IPGNPPBFLGF(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}

	[SpecialName]
	public void MHBPJANPBAN(int IDEBKDPMPGM)
	{
		BNABPLAGMEM.FKIIDCDCLHM = IDEBKDPMPGM;
	}
}
