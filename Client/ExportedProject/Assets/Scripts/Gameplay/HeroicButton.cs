using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroicButton : Core_BaseScript
{
	private enum NKHJBLBAAEB
	{
		Small,
		Big
	}

	private sealed class HGCJHDEMAGG
	{
		internal UISprite HEMFBMIPNGJ;

		internal bool JEGJLALPCKO;

		internal UISprite KOBFLIFPLMC;

		internal UISprite NAPCLCBHAMF;

		internal UILabel GMBJHOCENGD;

		internal GameObject DGJCAIJPEIM;

		internal Vector3 FLCDKJIJHLL;

		internal UISprite PCDOMENGMOM;

		internal Vector3 MINMIPHDFGB;

		internal UISprite GLLCCFLPEEI;

		internal HeroicButton BJGCPDNMHDH;

		internal void LEDJMCDANFJ(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-62), 1518f);
			BJGCPDNMHDH.OMDKHLFMFBA();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 123f, 1668f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1644f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1035f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 60f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(521f)).onFinished = AHKKACPIAHJ;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1520f, 55f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 365f, 1489f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 581f, 335f);
			TweenPosition.Begin(DGJCAIJPEIM, 451f, DGJCAIJPEIM.transform.localPosition.AddY(1681f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1314f, FLCDKJIJHLL.MultiplyXY(600f), FLCDKJIJHLL.MultiplyXY(1871f)).onFinished = IHOMMCFGAPB;
		}

		internal void BLBAPKLOBKD(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1830f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 85f : 1125f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 134f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 665f, 556f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1938f, MINMIPHDFGB.MultiplyXY(72f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 840f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1352f, 493f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 340f, 439f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1524f, 1869f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 675f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1637f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1402f)).onFinished = OAJJKKNNOPI;
			}
		}

		internal void AHJLKEOANNH(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 657f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void EEMLMEDJICO(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 341f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1015f : 251f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1512f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1444f, 1037f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1555f, MINMIPHDFGB.MultiplyXY(862f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1361f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 986f, 1596f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 80f, 624f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 99f, 756f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1688f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(128f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1893f)).onFinished = IELMIAGLMPA;
			}
		}

		internal void PJLEDMHCDHO(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1099f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(135f)).onFinished = HPABMPFKOLD;
		}

		internal void LCEMKGDLGCB(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 984f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(845f)).onFinished = AGODEKJGAIJ;
		}

		internal void ACAPIBDCCLL(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 12f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void BIMAACDODIE(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 140f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void JEBHOJGCDBB(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 397f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(966f)).onFinished = KFPDOPGEAFO;
		}

		internal void AMIJFGBOCLC(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1447f, 1565f).onFinished = MILKIIDMINH;
		}

		internal void JHDEKOKOLPG(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-115), 1262f);
			BJGCPDNMHDH.DOINHAEFDNB();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 153f, 1220f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1969f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1687f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 241f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(40f)).onFinished = KLCBGHFEJCP;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1354f, 1420f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1236f, 695f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1364f, 1974f);
			TweenPosition.Begin(DGJCAIJPEIM, 900f, DGJCAIJPEIM.transform.localPosition.AddY(1760f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1466f, FLCDKJIJHLL.MultiplyXY(73f), FLCDKJIJHLL.MultiplyXY(249f)).onFinished = LBPGIEANDDL;
		}

		internal void BLDFHCDFHCC(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1289f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1377f)).onFinished = KFPDOPGEAFO;
		}

		internal void CEPMCMMFEAA(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1464f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void NIMHLBFCKED(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1805f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1839f)).onFinished = HJAENAEGJEO;
		}

		internal void AGODEKJGAIJ(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1481f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void BIGNHFCNJLL(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 0.3f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 181f : 124f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 0.5f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 0.6f, 0f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 0.5f, MINMIPHDFGB.MultiplyXY(2f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 0.3f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 0.3f, 0.25f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 0.3f, 0f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 0.2f, 1f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 0.2f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1.5f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(0.8f)).onFinished = IELMIAGLMPA;
			}
		}

		internal void FHPEKHHLKHM(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1067f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void LJCDGJKCNEC(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 0.6f, 1f).onFinished = EJLGBICBIFK;
		}

		internal void CBCHFKGOMPA(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 796f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void NDJOJHNIBFC(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1389f, 321f).onFinished = MBMPBDEFNGE;
		}

		internal void AKOAHKIHKCJ(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1916f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void LJDCIJDPLLF(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 0.2f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void MOEOCNNMMGD(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1946f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1088f)).onFinished = IHIJHCIFONB;
		}

		internal void AFGKAEIMPJA(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1518f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void HNIOCGFEKKH(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1336f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 982f : 1769f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 0; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 174f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1538f, 1166f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1179f, MINMIPHDFGB.MultiplyXY(1150f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1149f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 32f, 121f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1914f, 354f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1233f, 414f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1607f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1416f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1036f)).onFinished = CEPMCMMFEAA;
			}
		}

		internal void ABLKBKIJNKO(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 3f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void PPILLFMKDNJ(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 601f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void NGMELCCIEHN(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1841f, 954f).onFinished = CJPMPGPKIFJ;
		}

		internal void KPLNDNKBMAA(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BuyVIP, 338f);
			BJGCPDNMHDH.AAIELFEIACG();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1508f, 843f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1945f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(368f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1338f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1676f)).onFinished = BGOLABOINMG;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1130f, 869f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1220f, 718f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 121f, 1196f);
			TweenPosition.Begin(DGJCAIJPEIM, 1844f, DGJCAIJPEIM.transform.localPosition.AddY(572f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 867f, FLCDKJIJHLL.MultiplyXY(1846f), FLCDKJIJHLL.MultiplyXY(135f)).onFinished = AOBIIKGDPEH;
		}

		internal void KLCBGHFEJCP(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1687f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1695f)).onFinished = HICBDHEJOEH;
		}

		internal void PAOEOBFHCKN(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1939f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(657f)).onFinished = GBEADGDJIEP;
		}

		internal void FIPPDDHBJAL(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1835f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 538f : 1341f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1118f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1350f, 1525f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1044f, MINMIPHDFGB.MultiplyXY(540f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1064f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 231f, 884f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 174f, 578f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 409f, 1243f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1296f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1419f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1318f)).onFinished = PPILLFMKDNJ;
			}
		}

		internal void CPCNBLLIEOJ(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 368f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1867f : 1507f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 1904f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 541f, 427f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1195f, MINMIPHDFGB.MultiplyXY(972f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1677f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 108f, 800f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 561f, 50f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 953f, 1216f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1624f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(563f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1727f)).onFinished = PPILLFMKDNJ;
			}
		}

		internal void NNIJEDKBPGJ(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1888f, 101f).onFinished = MBMPBDEFNGE;
		}

		internal void IHOCLIODHMJ(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 391f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1879f)).onFinished = KJPGCDOPAHF;
		}

		internal void FFGOEHLBPHP(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 297f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1314f)).onFinished = AGODEKJGAIJ;
		}

		internal void MKJJHFLAFFD(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 324f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1916f)).onFinished = IHIJHCIFONB;
		}

		internal void CCPOHDNCDJC(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 165f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 398f : 1378f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 1234f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1873f, 49f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1118f, MINMIPHDFGB.MultiplyXY(1899f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 971f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1546f, 1488f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1876f, 1709f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 395f, 1008f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 461f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1837f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1814f)).onFinished = AKOAHKIHKCJ;
			}
		}

		internal void CJPMPGPKIFJ(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-102), 1779f);
			BJGCPDNMHDH.NLBGECENFGA();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 120f, 1596f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1133f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1792f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 469f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1824f)).onFinished = FFGOEHLBPHP;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 95f, 1332f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1678f, 1624f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1292f, 598f);
			TweenPosition.Begin(DGJCAIJPEIM, 1369f, DGJCAIJPEIM.transform.localPosition.AddY(1468f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1171f, FLCDKJIJHLL.MultiplyXY(1158f), FLCDKJIJHLL.MultiplyXY(875f)).onFinished = IOPJAPNNOOK;
		}

		internal void BOEOPLJBNHF(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 937f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void IBMEJCJCLOK(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)121, 564f);
			BJGCPDNMHDH.GNCBHHGEAIP();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1974f, 375f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1297f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(153f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1797f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1348f)).onFinished = JNPPAGHIMDJ;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 772f, 1537f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1161f, 114f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 524f, 538f);
			TweenPosition.Begin(DGJCAIJPEIM, 490f, DGJCAIJPEIM.transform.localPosition.AddY(290f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 751f, FLCDKJIJHLL.MultiplyXY(751f), FLCDKJIJHLL.MultiplyXY(1327f)).onFinished = FLHAMECGGAA;
		}

		internal void HPEHMGDBLIH(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1067f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1653f)).onFinished = BLDMJACAEDB;
		}

		internal void BLNOPKPLONB(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)68, 1638f);
			BJGCPDNMHDH.HAIKKLJNDBL();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 670f, 857f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 187f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1345f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1756f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1100f)).onFinished = FBGCFPAGIND;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1002f, 860f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 571f, 1666f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 501f, 229f);
			TweenPosition.Begin(DGJCAIJPEIM, 836f, DGJCAIJPEIM.transform.localPosition.AddY(1308f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1617f, FLCDKJIJHLL.MultiplyXY(1313f), FLCDKJIJHLL.MultiplyXY(1912f)).onFinished = IHOMMCFGAPB;
		}

		internal void CENOGMHAJNK(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-117), 397f);
			BJGCPDNMHDH.GPBAPJFMLAH();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1930f, 1071f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1871f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1674f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1868f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(141f)).onFinished = NIMHLBFCKED;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1847f, 991f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 720f, 42f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1730f, 670f);
			TweenPosition.Begin(DGJCAIJPEIM, 994f, DGJCAIJPEIM.transform.localPosition.AddY(1819f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 743f, FLCDKJIJHLL.MultiplyXY(735f), FLCDKJIJHLL.MultiplyXY(1739f)).onFinished = KMGAGOFDPNI;
		}

		internal void IOPJAPNNOOK(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 436f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1316f : 828f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 0; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1557f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1572f, 902f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1772f, MINMIPHDFGB.MultiplyXY(581f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1854f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 525f, 478f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 633f, 1993f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1181f, 1915f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1748f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1076f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(247f)).onFinished = MHNAGJBEIJP;
			}
		}

		internal void PMKALNAFAJK(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1132f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1890f)).onFinished = AEPGCFLNFHP;
		}

		internal void ALIBBKEHCFC(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 356f, 694f).onFinished = PAKIJEIDOBH;
		}

		internal void FNILDOLEBGG(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1568f, 595f).onFinished = OACBBOBDICJ;
		}

		internal void BAOECFCJFNN(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1554f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 173f : 577f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1703f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 944f, 1337f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1002f, MINMIPHDFGB.MultiplyXY(1797f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1174f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1518f, 1084f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1175f, 315f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1354f, 880f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 629f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1654f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1291f)).onFinished = MHNAGJBEIJP;
			}
		}

		internal void BMONIBOJLJF(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampClick, 1066f);
			BJGCPDNMHDH.NGGOIGHIJKM();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1404f, 1503f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1670f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(531f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 60f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(469f)).onFinished = AHKKACPIAHJ;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1994f, 706f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 958f, 1566f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 271f, 1726f);
			TweenPosition.Begin(DGJCAIJPEIM, 1961f, DGJCAIJPEIM.transform.localPosition.AddY(49f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 138f, FLCDKJIJHLL.MultiplyXY(769f), FLCDKJIJHLL.MultiplyXY(63f)).onFinished = CPCNBLLIEOJ;
		}

		internal void OHLGKFGIPCC(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1901f, 668f).onFinished = JHDEKOKOLPG;
		}

		internal void AJGDNKKLHLF(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1873f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1177f)).onFinished = ABLKBKIJNKO;
		}

		internal void AHKKACPIAHJ(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 110f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(705f)).onFinished = BLDMJACAEDB;
		}

		internal void BHEEPMPEMOJ(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 796f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 774f : 1332f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 432f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 859f, 1215f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1979f, MINMIPHDFGB.MultiplyXY(1264f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1451f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 815f, 751f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 781f, 1383f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1944f, 742f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1970f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(259f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(706f)).onFinished = DOEIBAONIIJ;
			}
		}

		internal void FIBGJHCGHJH(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 754f, 644f).onFinished = OPPNIDPBBIM;
		}

		internal void LKKPBNGCPHB(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)86, 1645f);
			BJGCPDNMHDH.NGGOIGHIJKM();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1934f, 1269f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 597f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1193f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 543f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1504f)).onFinished = OCEMAFDGLCC;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 238f, 804f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 304f, 1301f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 526f, 246f);
			TweenPosition.Begin(DGJCAIJPEIM, 1726f, DGJCAIJPEIM.transform.localPosition.AddY(1667f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 392f, FLCDKJIJHLL.MultiplyXY(1054f), FLCDKJIJHLL.MultiplyXY(1401f)).onFinished = LPGNOJNCOEB;
		}

		internal void MOHGACHDJEG(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1850f, 377f).onFinished = CENOGMHAJNK;
		}

		internal void LOJKOGKKDIO(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 605f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1328f)).onFinished = PIHLNKPHAGG;
		}

		internal void LBPGIEANDDL(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1195f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 652f : 1632f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1367f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1886f, 230f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1235f, MINMIPHDFGB.MultiplyXY(980f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 715f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1996f, 576f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 968f, 1672f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 870f, 1493f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 244f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(638f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(166f)).onFinished = HLFDPJIOFBJ;
			}
		}

		internal void KJMIFMILHKH(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1116f, 868f).onFinished = LKKPBNGCPHB;
		}

		internal void JNPPAGHIMDJ(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 314f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1302f)).onFinished = JPDNEMHJMFI;
		}

		internal void AEPGCFLNFHP(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1087f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void PIHLNKPHAGG(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 894f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void PANKBNOCEAM(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1152f, 26f).onFinished = BLNOPKPLONB;
		}

		internal void JJLALKLIICD(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1213f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void IBPOJAEJFKN(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 517f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void EJLGBICBIFK(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StarGained);
			BJGCPDNMHDH.DOINHAEFDNB();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 0.3f, 0f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 0.3f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(2f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 0.3f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1.5f)).onFinished = HONCMBHEKDP;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 0.3f, 1f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 0.3f, 1f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 0.3f, 1f);
			TweenPosition.Begin(DGJCAIJPEIM, 0.3f, DGJCAIJPEIM.transform.localPosition.AddY(30f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 0.3f, FLCDKJIJHLL.MultiplyXY(2f), FLCDKJIJHLL.MultiplyXY(0.8f)).onFinished = BIGNHFCNJLL;
		}

		internal void NDBAHLGOBDM(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1358f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void KMGAGOFDPNI(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1347f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1258f : 711f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 0; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1713f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1855f, 845f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 756f, MINMIPHDFGB.MultiplyXY(1030f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1914f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1550f, 274f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1411f, 1259f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 302f, 1116f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1757f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1522f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1623f)).onFinished = ACAPIBDCCLL;
			}
		}

		internal void EKKAEAPDLDI(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1334f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 964f : 868f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1542f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1579f, 1445f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 737f, MINMIPHDFGB.MultiplyXY(1768f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 872f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 633f, 851f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 946f, 974f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1200f, 1094f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1426f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1886f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(712f)).onFinished = OAJJKKNNOPI;
			}
		}

		internal void OCEMAFDGLCC(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1578f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(525f)).onFinished = ANFKDIGMAJE;
		}

		internal void JGIDEONGLJI(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 375f, 94f).onFinished = BLNOPKPLONB;
		}

		internal void OPPNIDPBBIM(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-66), 170f);
			BJGCPDNMHDH.AAIELFEIACG();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 936f, 1947f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 625f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1956f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1178f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1610f)).onFinished = BGOLABOINMG;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1816f, 395f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1199f, 1049f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1375f, 1948f);
			TweenPosition.Begin(DGJCAIJPEIM, 7f, DGJCAIJPEIM.transform.localPosition.AddY(1926f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 140f, FLCDKJIJHLL.MultiplyXY(95f), FLCDKJIJHLL.MultiplyXY(1023f)).onFinished = IOPJAPNNOOK;
		}

		internal void OAJJKKNNOPI(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1761f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void BLDMJACAEDB(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1492f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void NPPHHHHLIDP(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1210f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1830f : 1950f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 750f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1110f, 846f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1697f, MINMIPHDFGB.MultiplyXY(833f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1830f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 113f, 1670f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 283f, 1652f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 374f, 800f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 859f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(536f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(345f)).onFinished = JJLALKLIICD;
			}
		}

		internal void OACBBOBDICJ(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-107), 1992f);
			BJGCPDNMHDH.HAIKKLJNDBL();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1428f, 1282f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1724f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(232f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1588f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(285f)).onFinished = AJGDNKKLHLF;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1078f, 121f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 695f, 1521f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1998f, 1624f);
			TweenPosition.Begin(DGJCAIJPEIM, 749f, DGJCAIJPEIM.transform.localPosition.AddY(242f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1445f, FLCDKJIJHLL.MultiplyXY(1231f), FLCDKJIJHLL.MultiplyXY(165f)).onFinished = BHEEPMPEMOJ;
		}

		internal void BGOLABOINMG(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1599f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(88f)).onFinished = BLDMJACAEDB;
		}

		internal void FGANJBEIKEF(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1661f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(249f)).onFinished = BLDMJACAEDB;
		}

		internal void KEBLADMIDMM(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 577f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1967f)).onFinished = KFPDOPGEAFO;
		}

		internal void MBMPBDEFNGE(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGameVsSound, 1217f);
			BJGCPDNMHDH.GNCBHHGEAIP();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1082f, 1996f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 410f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(657f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 494f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1451f)).onFinished = KLCBGHFEJCP;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1737f, 40f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1914f, 598f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 884f, 458f);
			TweenPosition.Begin(DGJCAIJPEIM, 1714f, DGJCAIJPEIM.transform.localPosition.AddY(1780f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 596f, FLCDKJIJHLL.MultiplyXY(869f), FLCDKJIJHLL.MultiplyXY(1387f)).onFinished = BAOECFCJFNN;
		}

		internal void MILKIIDMINH(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-48), 1836f);
			BJGCPDNMHDH.NGGOIGHIJKM();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 45f, 1100f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 679f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1841f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1421f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(12f)).onFinished = BLMLPOEBKJN;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 116f, 1574f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1460f, 306f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1606f, 116f);
			TweenPosition.Begin(DGJCAIJPEIM, 1418f, DGJCAIJPEIM.transform.localPosition.AddY(342f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 31f, FLCDKJIJHLL.MultiplyXY(1120f), FLCDKJIJHLL.MultiplyXY(250f)).onFinished = BIGNHFCNJLL;
		}

		internal void AOBIIKGDPEH(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 853f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 663f : 75f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1345f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1059f, 957f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1406f, MINMIPHDFGB.MultiplyXY(917f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1309f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 943f, 1060f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 248f, 653f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1020f, 570f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1047f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1217f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1305f)).onFinished = MHNAGJBEIJP;
			}
		}

		internal void NCMLGJHPJNA(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 695f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 915f : 636f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 1533f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 58f, 1057f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1685f, MINMIPHDFGB.MultiplyXY(1070f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1834f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 898f, 432f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1967f, 1296f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1073f, 492f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 358f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(912f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(164f)).onFinished = AHJLKEOANNH;
			}
		}

		internal void BCMKCAHLNBG(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1981f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(166f)).onFinished = KFPDOPGEAFO;
		}

		internal void MNKDEBHAPPB(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 279f, 1906f).onFinished = CJPMPGPKIFJ;
		}

		internal void JBDJIDBNKIO(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-71), 1192f);
			BJGCPDNMHDH.NGGOIGHIJKM();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 696f, 838f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 163f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(95f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 113f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1407f)).onFinished = BLDFHCDFHCC;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 622f, 1937f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1511f, 1567f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 449f, 585f);
			TweenPosition.Begin(DGJCAIJPEIM, 642f, DGJCAIJPEIM.transform.localPosition.AddY(195f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 732f, FLCDKJIJHLL.MultiplyXY(1435f), FLCDKJIJHLL.MultiplyXY(226f)).onFinished = BIGNHFCNJLL;
		}

		internal void HICBDHEJOEH(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1496f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void KKGKOJMNOKN(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-51), 879f);
			BJGCPDNMHDH.NLBGECENFGA();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1699f, 1366f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1577f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1656f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1997f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1641f)).onFinished = PMKALNAFAJK;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1522f, 1796f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1291f, 392f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 771f, 452f);
			TweenPosition.Begin(DGJCAIJPEIM, 769f, DGJCAIJPEIM.transform.localPosition.AddY(251f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 269f, FLCDKJIJHLL.MultiplyXY(1242f), FLCDKJIJHLL.MultiplyXY(508f)).onFinished = LBPGIEANDDL;
		}

		internal void NBLNIDBBHMM(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1451f, 1977f).onFinished = EIGOHMKAMGI;
		}

		internal void BLMLPOEBKJN(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 403f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(623f)).onFinished = GBEADGDJIEP;
		}

		internal void DCDJIFCDGEI(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1697f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void KPHEPHDFCKK(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 63f, 314f).onFinished = LKKPBNGCPHB;
		}

		internal void DOEIBAONIIJ(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1500f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void FCLEJJHBFDP(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 684f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void IIPLOACIHMD(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1071f, 1389f).onFinished = MLKPCEOPLKO;
		}

		internal void PMABOKAEFNF(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 286f, 1116f).onFinished = LEDJMCDANFJ;
		}

		internal void FBGCFPAGIND(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1034f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1358f)).onFinished = FHPEKHHLKHM;
		}

		internal void MLKPCEOPLKO(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-65), 966f);
			BJGCPDNMHDH.GPBAPJFMLAH();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 940f, 702f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1770f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(449f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 312f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(963f)).onFinished = DOKNIEMLBGK;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1818f, 1670f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 75f, 704f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1343f, 1859f);
			TweenPosition.Begin(DGJCAIJPEIM, 1163f, DGJCAIJPEIM.transform.localPosition.AddY(1972f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 714f, FLCDKJIJHLL.MultiplyXY(955f), FLCDKJIJHLL.MultiplyXY(623f)).onFinished = EKKAEAPDLDI;
		}

		internal void IHIJHCIFONB(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 45f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void ANFKDIGMAJE(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1810f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void AELJLLOEILK(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1023f, 581f).onFinished = DACMPHJFMPH;
		}

		internal void EODJHIOCFAG(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 455f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1261f : 379f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 976f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 186f, 465f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 680f, MINMIPHDFGB.MultiplyXY(1489f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1835f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1378f, 437f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 438f, 1285f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1376f, 1608f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 652f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(350f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(798f)).onFinished = HLFDPJIOFBJ;
			}
		}

		internal void KFPDOPGEAFO(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1175f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void HJAENAEGJEO(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1852f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void LKDKAILNBFA(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1441f, 1590f).onFinished = LEDJMCDANFJ;
		}

		internal void JLDJJLDKGHA(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1838f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void MJFMLLKALLH(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 691f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1341f : 1587f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 655f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1119f, 202f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1904f, MINMIPHDFGB.MultiplyXY(1588f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1709f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 311f, 325f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1015f, 642f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 745f, 397f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1604f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(679f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(258f)).onFinished = NDBAHLGOBDM;
			}
		}

		internal void LIMGPKFEALB(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1613f, 348f).onFinished = BMONIBOJLJF;
		}

		internal void BJLNFBINOMF(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 578f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void NMOEHJHCEGD(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DogTagGain, 1718f);
			BJGCPDNMHDH.GPBAPJFMLAH();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1880f, 1128f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 613f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1136f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 952f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1996f)).onFinished = LONPLLMEKMM;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 880f, 1733f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1019f, 493f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 19f, 1409f);
			TweenPosition.Begin(DGJCAIJPEIM, 64f, DGJCAIJPEIM.transform.localPosition.AddY(763f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1539f, FLCDKJIJHLL.MultiplyXY(290f), FLCDKJIJHLL.MultiplyXY(1735f)).onFinished = EKKAEAPDLDI;
		}

		internal void NCLMPCCHDAM(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1945f, 453f).onFinished = CENOGMHAJNK;
		}

		internal void DACMPHJFMPH(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)103, 1649f);
			BJGCPDNMHDH.NLBGECENFGA();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1269f, 665f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 630f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1668f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 58f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(380f)).onFinished = HONCMBHEKDP;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1911f, 1687f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1390f, 193f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 830f, 109f);
			TweenPosition.Begin(DGJCAIJPEIM, 16f, DGJCAIJPEIM.transform.localPosition.AddY(290f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 597f, FLCDKJIJHLL.MultiplyXY(512f), FLCDKJIJHLL.MultiplyXY(44f)).onFinished = EEMLMEDJICO;
		}

		internal void PAKIJEIDOBH(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-127), 1355f);
			BJGCPDNMHDH.DMMKKOFBFIO();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1434f, 802f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1928f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1867f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1711f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(59f)).onFinished = LONPLLMEKMM;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 334f, 470f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 113f, 1144f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1412f, 846f);
			TweenPosition.Begin(DGJCAIJPEIM, 1464f, DGJCAIJPEIM.transform.localPosition.AddY(67f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 933f, FLCDKJIJHLL.MultiplyXY(974f), FLCDKJIJHLL.MultiplyXY(1215f)).onFinished = BAOECFCJFNN;
		}

		internal void IELMIAGLMPA(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 0.2f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void IHOMMCFGAPB(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1818f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 51f : 590f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 1409f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1154f, 696f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 196f, MINMIPHDFGB.MultiplyXY(136f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1604f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1255f, 235f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 56f, 1013f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 661f, 487f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 124f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(823f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1113f)).onFinished = HLFDPJIOFBJ;
			}
		}

		internal void HONCMBHEKDP(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 0.2f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(0.8f)).onFinished = LJDCIJDPLLF;
		}

		internal void LPGNOJNCOEB(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 284f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1698f : 749f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 0; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1329f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1677f, 1593f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 811f, MINMIPHDFGB.MultiplyXY(1899f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1234f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 107f, 702f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1033f, 1032f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1111f, 633f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 439f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1309f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1541f)).onFinished = DCDJIFCDGEI;
			}
		}

		internal void GBEADGDJIEP(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 19f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void KJPGCDOPAHF(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1769f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void HPABMPFKOLD(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 710f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void JMEBCMMIPAF(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1893f, 169f).onFinished = BLNOPKPLONB;
		}

		internal void MHLAFGIHEHN(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1830f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 226f : 1541f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1136f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1616f, 926f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1557f, MINMIPHDFGB.MultiplyXY(1998f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1901f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 472f, 982f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 157f, 1417f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 814f, 746f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1813f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(964f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1969f)).onFinished = BJLNFBINOMF;
			}
		}

		internal void COALBLGIDHF(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1555f, 332f).onFinished = EJLGBICBIFK;
		}

		internal void FLHAMECGGAA(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 952f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 332f : 62f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1850f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 367f, 1370f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 224f, MINMIPHDFGB.MultiplyXY(565f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 108f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 114f, 1581f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1504f, 1783f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1293f, 410f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 635f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(947f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(333f)).onFinished = PPILLFMKDNJ;
			}
		}

		internal void JDNPOHKEELM(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1490f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(467f)).onFinished = AGODEKJGAIJ;
		}

		internal void MNHAOLHNNIF(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1606f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(75f)).onFinished = GBEADGDJIEP;
		}

		internal void DOKNIEMLBGK(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1626f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1331f)).onFinished = IHIJHCIFONB;
		}

		internal void MFPNOPMOOKB(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1404f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void MHNAGJBEIJP(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1493f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void BMCMDMKGHHO(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1540f, 1597f).onFinished = KPLNDNKBMAA;
		}

		internal void IPFDNCFIDLC(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1407f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1557f : 1932f), useLocal: false);
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1369f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 555f, 1812f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 1737f, MINMIPHDFGB.MultiplyXY(421f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1823f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 490f, 1639f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1186f, 1625f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 156f, 598f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 22f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1242f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(972f)).onFinished = PPILLFMKDNJ;
			}
		}

		internal void LONPLLMEKMM(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 342f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1415f)).onFinished = KFPDOPGEAFO;
		}

		internal void MMAFECEHENB(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)118, 1445f);
			BJGCPDNMHDH.GPBAPJFMLAH();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1348f, 1907f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 945f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(972f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 170f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(328f)).onFinished = OCEMAFDGLCC;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 20f, 1517f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 8f, 1359f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1438f, 147f);
			TweenPosition.Begin(DGJCAIJPEIM, 1898f, DGJCAIJPEIM.transform.localPosition.AddY(455f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1072f, FLCDKJIJHLL.MultiplyXY(360f), FLCDKJIJHLL.MultiplyXY(1712f)).onFinished = FLHAMECGGAA;
		}

		internal void HLFDPJIOFBJ(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1268f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void CFGDGGBELGD(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-75), 863f);
			BJGCPDNMHDH.GPBAPJFMLAH();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1894f, 1032f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1683f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(745f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1231f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(1205f)).onFinished = LCEMKGDLGCB;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1749f, 684f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 912f, 867f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1705f, 1566f);
			TweenPosition.Begin(DGJCAIJPEIM, 945f, DGJCAIJPEIM.transform.localPosition.AddY(1041f), useLocal: false);
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1442f, FLCDKJIJHLL.MultiplyXY(1994f), FLCDKJIJHLL.MultiplyXY(424f)).onFinished = MHLAFGIHEHN;
		}

		internal void JPDNEMHJMFI(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 850f, BJGCPDNMHDH.FPJHAPAGNPL);
		}

		internal void KLIEJHAPOAE(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 407f, BJGCPDNMHDH.NMLPMKPMEME);
		}

		internal void HMLMCGLICPM(UITweener LCJKLGENNGM)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1664f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(374f)).onFinished = JLDJJLDKGHA;
		}

		internal void HFIAIHFDGEP(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 565f, 146f).onFinished = MBMPBDEFNGE;
		}

		internal void ILNPANOCHIH(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1060f, 1708f).onFinished = MMAFECEHENB;
		}

		internal void AFDIFBLGGKG(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1912f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1957f : 1287f));
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i++)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 301f, Color.white);
			}
			TweenAlpha.Begin(PCDOMENGMOM.gameObject, 1829f, 749f);
			TweenScale.Begin(PCDOMENGMOM.gameObject, 718f, MINMIPHDFGB.MultiplyXY(1016f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 1780f, FLCDKJIJHLL);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 982f, 117f);
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedShadow.gameObject, 1142f, 320f);
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1118f, 1668f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallInProgressIcon.gameObject, 1619f, BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1010f), BJGCPDNMHDH.NMLPMKPMEME.MultiplyXY(1897f)).onFinished = MHNAGJBEIJP;
			}
		}

		internal void EIGOHMKAMGI(UITweener DAECHDDDMJN)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpponentSearch, 402f);
			BJGCPDNMHDH.NGGOIGHIJKM();
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 513f, 593f);
				TweenScale.Begin(BJGCPDNMHDH.mSmallLockedLock.gameObject, 1210f, BJGCPDNMHDH.IJADNCEAFAB.MultiplyXY(1959f));
			}
			else
			{
				TweenScale.Begin(BJGCPDNMHDH.mSoldierUnit.gameObject, 1281f, BJGCPDNMHDH.FPJHAPAGNPL.MultiplyXY(562f)).onFinished = LONPLLMEKMM;
			}
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1861f, 893f);
			TweenAlpha.Begin(NAPCLCBHAMF.gameObject, 1975f, 83f);
			TweenAlpha.Begin(GMBJHOCENGD.gameObject, 1546f, 361f);
			TweenPosition.Begin(DGJCAIJPEIM, 718f, DGJCAIJPEIM.transform.localPosition.AddY(499f));
			TweenScale.Begin(KOBFLIFPLMC.gameObject, 524f, FLCDKJIJHLL.MultiplyXY(1775f), FLCDKJIJHLL.MultiplyXY(792f)).onFinished = MJFMLLKALLH;
		}
	}

	private sealed class CGNMKJJKHPN
	{
		internal GameObject DGJCAIJPEIM;

		internal bool JEGJLALPCKO;

		internal UISprite HEMFBMIPNGJ;

		internal UISprite GLLCCFLPEEI;

		internal UISprite KOBFLIFPLMC;

		internal Vector3 PDGEIGFCIOE;

		internal UISprite NIIFMDFKEFC;

		internal Vector3 KAIDDAONLCJ;

		internal UISprite GGFKJOGMFMO;

		internal Vector3 HMDBGEANKMI;

		internal UISprite OLIBALFJOLP;

		internal UISprite DMLCAKMKEAG;

		internal HeroicButton BJGCPDNMHDH;

		internal void LNMNIMADEAO(UITweener AEEBLJKPGMO)
		{
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 923f, Color.black.ReplaceA(1451f));
			}
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 33f, 1708f).onFinished = CJOGHDDFFNF;
		}

		internal void EOOLCOFIFJB(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 691f, 921f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1446f, 1417f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 1800f, PDGEIGFCIOE).onFinished = FLIKDCBHHEH;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 859f, KAIDDAONLCJ, useLocal: false).onFinished = OCACHPLBMBM;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 863f, 258f).onFinished = LNMNIMADEAO;
		}

		internal void FAOLPKNBLAL(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1885f, 1174f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 225f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(0f));
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 312f, 1941f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 747f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1880f), useLocal: false).onFinished = COEJBBJEGJK;
		}

		internal void BDEKCNIONFJ(UITweener PNIJONDHIHC)
		{
			if (!JEGJLALPCKO)
			{
				GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
			}
		}

		internal void NIHEIMLMEAN(UITweener AKCKHOODNAI)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 9f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(886f)).onFinished = EPMGONDBLFA;
		}

		internal void HPJCBDDALHB(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 405f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(36f));
		}

		internal void CJOGHDDFFNF(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 769f, 1542f).onFinished = PBEAOOPIIHM;
		}

		internal void PPJFCNPHDON(UITweener AEEBLJKPGMO)
		{
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1314f, Color.black.ReplaceA(875f));
			}
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 1894f, 1634f).onFinished = IELEEADKBGG;
		}

		internal void OHMPAAOEJED(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1751f, 51f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 16f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(539f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1121f), useLocal: false).onFinished = LAFKMKPGLHH;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 171f, 1530f).onFinished = KMOPEFKDLCP;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 769f, HMDBGEANKMI.MultiplyXY(500f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 1614f, 397f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 1519f, 994f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1993f, KAIDDAONLCJ.AddY(71f), KAIDDAONLCJ);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 463f, 1651f);
		}

		internal void EDCBIEABAFG(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1622f, 1427f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 390f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(953f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(873f)).onFinished = LJLJJCHBILG;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1352f, 398f).onFinished = OIPIBKIEMNC;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 699f, HMDBGEANKMI.MultiplyXY(1442f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 269f, 189f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 1866f, 672f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1443f, KAIDDAONLCJ.AddY(1367f), KAIDDAONLCJ);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 985f, 618f);
		}

		internal void JMDALFEGCOE(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 1805f, BJGCPDNMHDH.MHIAJFBLHEC);
		}

		internal void DPLCGKFMJLA(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1924f, 1929f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1059f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(342f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1964f, 1356f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 491f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1247f)).onFinished = PLEMNKHGLBA;
		}

		internal void MEJDMEIPEJB(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 116f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1311f : 787f), useLocal: false);
		}

		internal void EMADJNBPEEB(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 886f, 826f).onFinished = JABMKMBCKAO;
		}

		internal void MLJNAMJBFLL(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 35f, 129f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 339f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1149f), BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(988f), useLocal: false).onFinished = NLKBJCAIGCE;
		}

		internal void EIFMAOEAGEL(UITweener AKCKHOODNAI)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1844f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1596f), useLocal: false).onFinished = DLDEJJAFDGH;
		}

		internal void MMGNGCLDELN(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1235f, 1037f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1151f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(648f));
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 237f, 1350f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1048f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(940f), useLocal: false).onFinished = IDCNMJDFJFH;
		}

		internal void LBIKFLMKAEC(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1686f, 1218f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1745f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(603f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 346f, 839f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 94f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1770f), useLocal: false).onFinished = COEJBBJEGJK;
		}

		internal void PLOCOOFAFOD(UITweener AEEBLJKPGMO)
		{
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 384f, Color.black.ReplaceA(322f));
			}
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 718f, 1004f).onFinished = OFMCDOFPODI;
		}

		internal void MHLFKFCCGOC(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 265f, 950f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 63f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1874f));
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1291f, 671f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 876f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1643f)).onFinished = IDCNMJDFJFH;
		}

		internal void HEBMDAPKPKE(UITweener PNIJONDHIHC)
		{
			if (!JEGJLALPCKO)
			{
				GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
			}
		}

		internal void LJDCIJDPLLF(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 0.1f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(-20f));
		}

		internal void OMDOFMDIFHA(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 723f, 1771f).onFinished = DPLCGKFMJLA;
		}

		internal void LHJLOJEGLCD(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1452f, 807f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1239f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1698f), BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1899f)).onFinished = NIHEIMLMEAN;
		}

		internal void LIJFHOGPIPH(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1135f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(887f), useLocal: false);
		}

		internal void DHFMLGKPNMO(UITweener PNIJONDHIHC)
		{
			if (!JEGJLALPCKO)
			{
				GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
			}
		}

		internal void HONCMBHEKDP(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 0.1f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 181f : 124f));
		}

		internal void OFJDLANHAMD(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 1861f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(781f));
		}

		internal void CHKNAPNFDOE(UITweener AEEBLJKPGMO)
		{
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 0; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1052f, Color.black.ReplaceA(1023f));
			}
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 192f, 1857f).onFinished = NGBDHAIMOGK;
		}

		internal void DEMJEGPOMAM(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 214f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1018f));
		}

		internal void IPNILCPEJCE(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 728f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1416f), useLocal: false);
		}

		internal void OFMCDOFPODI(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 1934f, 1051f).onFinished = PBEAOOPIIHM;
		}

		internal void PLEMNKHGLBA(UITweener MGDJMGHCAAI)
		{
			if (!LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.ContinueAnimationOfCompleted();
			}
		}

		internal void BIGNHFCNJLL(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 0.6f, 0f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 0.2f, 0f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 0.1f, PDGEIGFCIOE).onFinished = IELMIAGLMPA;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 0.2f, KAIDDAONLCJ).onFinished = CLAINFGHGLJ;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 0.2f, 0f).onFinished = CALJKNNJHAO;
		}

		internal void NDIGEBFCBLN(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1678f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(908f), useLocal: false);
		}

		internal void KKJBEFCIKCK(UITweener MGDJMGHCAAI)
		{
			if (!LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.MOMBFJHPDKE();
			}
		}

		internal void HJOLGJOLAGE(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 940f, 1702f).onFinished = JABMKMBCKAO;
		}

		internal void COEJBBJEGJK(UITweener MGDJMGHCAAI)
		{
			if (!LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.ContinueAnimationOfCompleted();
			}
		}

		internal void BGKOBFAHJDD(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 0.2f, 1f).onFinished = BDEKCNIONFJ;
		}

		internal void HEICHMEJIPD(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 1970f, BJGCPDNMHDH.MHIAJFBLHEC);
		}

		internal void DGPKNJCOGBG(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 521f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1706f));
		}

		internal void EPINKNPFJMI(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1938f, 906f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1233f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(39f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(947f)).onFinished = LAFKMKPGLHH;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1949f, 1861f).onFinished = KMOPEFKDLCP;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 1582f, HMDBGEANKMI.MultiplyXY(357f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 74f, 1188f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 1249f, 1316f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1850f, KAIDDAONLCJ.AddY(404f), KAIDDAONLCJ);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 1433f, 1013f);
		}

		internal void OKMPJBMNFEF(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1032f, 844f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1280f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1875f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1933f)).onFinished = BBCHFBLJCID;
		}

		internal void EMHCJDABMCD(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1127f, 1186f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1684f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(120f));
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1986f, 1738f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 680f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(312f), useLocal: false).onFinished = PLEMNKHGLBA;
		}

		internal void DIDKLCKIPGN(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1676f, 187f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 333f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(63f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(843f), useLocal: false).onFinished = IPNILCPEJCE;
		}

		internal void AKCPOJMIBOG(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1215f, 1736f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 46f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1787f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1835f), useLocal: false).onFinished = EOCGKFAJOOF;
		}

		internal void ABLKBKIJNKO(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 959f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1534f), useLocal: false);
		}

		internal void LIBJKLPOJMA(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 1276f, BJGCPDNMHDH.MHIAJFBLHEC, useLocal: false);
		}

		internal void BCMKCAHLNBG(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1708f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1394f : 375f), useLocal: false);
		}

		internal void IDCNMJDFJFH(UITweener MGDJMGHCAAI)
		{
			if (!LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.HHNCKIOGKBA();
			}
		}

		internal void JABMKMBCKAO(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 643f, 1788f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 671f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(6f));
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1742f, 1245f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 349f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(171f)).onFinished = IDCNMJDFJFH;
		}

		internal void IINDOMEEJHA(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 1104f, BJGCPDNMHDH.MHIAJFBLHEC, useLocal: false);
		}

		internal void CHOIECFFEMH(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 1224f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(1621f));
		}

		internal void OOPCJEIOCEL(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 24f, 1231f).onFinished = PBEAOOPIIHM;
		}

		internal void CLAINFGHGLJ(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 0.2f, 1f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 0.2f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(-40f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(0f)).onFinished = GLCHANGEBNN;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 0.1f, 0f).onFinished = OIPIBKIEMNC;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 0.2f, HMDBGEANKMI.MultiplyXY(3f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 0.2f, 1f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 0.2f, 0.25f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 0.2f, KAIDDAONLCJ.AddY(30f), KAIDDAONLCJ);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 0.2f, 1f);
		}

		internal void OHBKNAFKGGL(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1579f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(422f), useLocal: false);
		}

		internal void EJLGBICBIFK(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 0.2f, 1f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 0.2f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(0f)).onFinished = LJDCIJDPLLF;
		}

		internal void NJJECLEFHBG(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 386f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1921f), useLocal: false);
		}

		internal void KMOPEFKDLCP(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 98f, 922f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1511f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1377f), BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1915f), useLocal: false).onFinished = IMBKCBCNNDC;
		}

		internal void DDHCOKFMEPI(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 820f, 1516f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1579f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(409f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 761f, 1034f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 494f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(76f), useLocal: false).onFinished = KKJBEFCIKCK;
		}

		internal void CKOIMNHIPCE(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 1912f, BJGCPDNMHDH.MHIAJFBLHEC, useLocal: false);
		}

		internal void KPANIGCGPKE(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1749f, 606f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1559f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(536f), BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(741f), useLocal: false).onFinished = NLKBJCAIGCE;
		}

		internal void LIIBDBFDNOC(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1663f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(569f));
		}

		internal void IGNHNKFEEPA(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 95f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1324f : 1305f), useLocal: false);
		}

		internal void EPMGONDBLFA(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 0.3f, 1f).onFinished = JOCOMHOIIHJ;
		}

		internal void JBDJIDBNKIO(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1970f, 1026f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 897f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(329f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1765f)).onFinished = DDJHCKFMHGE;
		}

		internal void NFFJEOEKJNG(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 438f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1884f : 176f));
		}

		internal void IMBKCBCNNDC(UITweener AKCKHOODNAI)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1413f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(129f)).onFinished = OMDOFMDIFHA;
		}

		internal void NEAHKMODMAH(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1368f, 1698f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 905f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(156f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1927f), useLocal: false).onFinished = CFPAIEMKNBL;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 814f, 1118f).onFinished = KMOPEFKDLCP;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 704f, HMDBGEANKMI.MultiplyXY(44f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 1971f, 1863f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 109f, 1940f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 850f, KAIDDAONLCJ.AddY(1313f), KAIDDAONLCJ, useLocal: false);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 295f, 662f);
		}

		internal void NGBDHAIMOGK(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 656f, 1917f).onFinished = PBEAOOPIIHM;
		}

		internal void HPCCHOJJGIK(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1300f, 314f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1066f, 1426f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 307f, PDGEIGFCIOE, useLocal: false).onFinished = IELMIAGLMPA;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1427f, KAIDDAONLCJ).onFinished = CLAINFGHGLJ;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 915f, 477f).onFinished = CHKNAPNFDOE;
		}

		internal void OCACHPLBMBM(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 360f, 1140f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 668f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(102f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1582f)).onFinished = POHOFBOGKJK;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 27f, 1542f).onFinished = KPANIGCGPKE;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 1207f, HMDBGEANKMI.MultiplyXY(417f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 988f, 1606f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 246f, 1107f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 110f, KAIDDAONLCJ.AddY(1790f), KAIDDAONLCJ);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 1562f, 1233f);
		}

		internal void OCEMAFDGLCC(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 168f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1309f : 640f), useLocal: false);
		}

		internal void CALJKNNJHAO(UITweener AEEBLJKPGMO)
		{
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 0.2f, Color.black.ReplaceA(0.1f));
			}
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 0.2f, 0f).onFinished = BGKOBFAHJDD;
		}

		internal void JOCOMHOIIHJ(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 0.2f, 0f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 0.2f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(-40f));
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 0.2f, 0f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 0.2f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(-40f)).onFinished = PLEMNKHGLBA;
		}

		internal void BPCIHGNLJKN(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 39f, 342f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 362f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(1411f));
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1566f, 364f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 792f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(453f), useLocal: false);
			}
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 159f, PDGEIGFCIOE.AddY(398f), useLocal: false);
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1109f, 209f);
			TweenColor.Begin(BJGCPDNMHDH.mNumber.gameObject, 980f, Color.black, Color.white);
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 1374f, BJGCPDNMHDH.MHIAJFBLHEC.AddY(750f), useLocal: false).onFinished = IKOBEJFJPHO;
		}

		internal void EOCGKFAJOOF(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1495f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(592f), useLocal: false);
		}

		internal void OGAAKOFDECM(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1221f, 1857f).onFinished = LBIKFLMKAEC;
		}

		internal void NLKBJCAIGCE(UITweener AKCKHOODNAI)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 0.1f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(-20f)).onFinished = EPMGONDBLFA;
		}

		internal void GEKCBDMOCBB(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 45f, 1016f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 18f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(259f), useLocal: false);
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1710f, 1138f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1104f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(538f));
			}
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 433f, PDGEIGFCIOE.AddY(96f));
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 1300f, 1874f);
			TweenColor.Begin(BJGCPDNMHDH.mNumber.gameObject, 1724f, Color.black, Color.white);
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 801f, BJGCPDNMHDH.MHIAJFBLHEC.AddY(1558f), useLocal: false).onFinished = IINDOMEEJHA;
		}

		internal void MNPKIAGIBLF(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 1038f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 1189f : 612f));
		}

		internal void OBHJJEJOFFF(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1433f, 1036f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 235f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1821f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1145f, 1017f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1811f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(236f)).onFinished = COEJBBJEGJK;
		}

		internal void KCOGEFBNDKA(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 259f, 237f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1530f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1664f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(402f)).onFinished = DDJHCKFMHGE;
		}

		internal void BBCHFBLJCID(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1348f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1637f), useLocal: false);
		}

		internal void LAFKMKPGLHH(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1944f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1074f));
		}

		internal void OPPNIDPBBIM(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1193f, 610f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1933f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1563f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1403f), useLocal: false).onFinished = DEMJEGPOMAM;
		}

		internal void JHDEKOKOLPG(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 283f, 762f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 763f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1072f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(843f)).onFinished = DGPKNJCOGBG;
		}

		internal void DPBLKLIMOJD(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 553f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 469f : 235f), useLocal: false);
		}

		internal void IPEEAPOEFJN(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1807f, 1773f).onFinished = DDHCOKFMEPI;
		}

		internal void ONPJIHKBECD(UITweener AKCKHOODNAI)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1086f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1094f), useLocal: false).onFinished = EMADJNBPEEB;
		}

		internal void NCMIHPHIKPF(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1172f, 390f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1047f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1342f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1167f, 246f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1133f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(96f), useLocal: false).onFinished = KKJBEFCIKCK;
		}

		internal void CCMHGGJFEJM(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 171f, 325f).onFinished = PBEAOOPIIHM;
		}

		internal void ONPGLELIGAB(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 757f, 1328f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1392f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1609f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(663f)).onFinished = NDIGEBFCBLN;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 416f, 1123f).onFinished = KMOPEFKDLCP;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 409f, HMDBGEANKMI.MultiplyXY(1145f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 439f, 1755f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 1990f, 1710f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1520f, KAIDDAONLCJ.AddY(840f), KAIDDAONLCJ);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 1511f, 923f);
		}

		internal void DLGLIHCIEOM(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 155f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(588f), useLocal: false);
		}

		internal void FAPPNJKJAJN(UITweener AEEBLJKPGMO)
		{
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			foreach (UISprite uISprite in mProgressArrows)
			{
				TweenColor.Begin(uISprite.gameObject, 1378f, Color.black.ReplaceA(1187f));
			}
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 859f, 1363f).onFinished = CJOGHDDFFNF;
		}

		internal void CADOCBDGLEA(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 636f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(547f), useLocal: false);
		}

		internal void ONMIMKCDCEG(UITweener AKCKHOODNAI)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1205f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1548f), useLocal: false).onFinished = DLDEJJAFDGH;
		}

		internal void HLBPCGPPCMJ(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 1719f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(1881f));
		}

		internal void DLDEJJAFDGH(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1790f, 528f).onFinished = DPLCGKFMJLA;
		}

		internal void IELEEADKBGG(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 506f, 88f).onFinished = DHFMLGKPNMO;
		}

		internal void IHOMMCFGAPB(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 850f, 718f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 819f, 1444f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 1718f, PDGEIGFCIOE, useLocal: false).onFinished = BPGFECGMOEN;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1100f, KAIDDAONLCJ, useLocal: false).onFinished = OHMPAAOEJED;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 1927f, 951f).onFinished = PLOCOOFAFOD;
		}

		internal void BBPKDMPNEDG(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 787f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(1104f), useLocal: false);
		}

		internal void PCKMJMGLPDG(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 1913f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(1522f), useLocal: false);
		}

		internal void PBEAOOPIIHM(UITweener PNIJONDHIHC)
		{
			if (!JEGJLALPCKO)
			{
				GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
			}
		}

		internal void IKOBEJFJPHO(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 0.15f, BJGCPDNMHDH.MHIAJFBLHEC);
		}

		internal void GMNOLOENDJB(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 422f, BJGCPDNMHDH.MHIAJFBLHEC);
		}

		internal void IELMIAGLMPA(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 0.2f, 0f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 0.2f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 0.2f, 0f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 0.2f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(-40f));
			}
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 0.2f, PDGEIGFCIOE.AddY(-30f));
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 0.2f, 0f);
			TweenColor.Begin(BJGCPDNMHDH.mNumber.gameObject, 0.3f, Color.black, Color.white);
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 0.15f, BJGCPDNMHDH.MHIAJFBLHEC.AddY(10f)).onFinished = IKOBEJFJPHO;
		}

		internal void GLCHANGEBNN(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 0.1f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(-20f));
		}

		internal void DEBBECMAJDE(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 186f, 1793f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1937f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1694f));
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 15f, 460f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 386f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1448f)).onFinished = IDCNMJDFJFH;
		}

		internal void DAGOGGGKECG(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 56f, 1549f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 687f, 675f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 640f, PDGEIGFCIOE, useLocal: false).onFinished = BPCIHGNLJKN;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 958f, KAIDDAONLCJ, useLocal: false).onFinished = CLAINFGHGLJ;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 469f, 196f).onFinished = LNMNIMADEAO;
		}

		internal void LJCDGJKCNEC(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 0.1f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(-20f));
		}

		internal void CBONJHEAODH(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 137f, 1765f).onFinished = HEBMDAPKPKE;
		}

		internal void AKINHDCALND(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 971f, BJGCPDNMHDH.MHIAJFBLHEC);
		}

		internal void IKPPDJNEELO(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1643f, 584f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 180f, 707f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 1202f, PDGEIGFCIOE, useLocal: false).onFinished = BPGFECGMOEN;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 154f, KAIDDAONLCJ).onFinished = ONPGLELIGAB;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 1677f, 1380f).onFinished = CALJKNNJHAO;
		}

		internal void DOKNIEMLBGK(UITweener GIIJCLFPIGO)
		{
			TweenPosition.Begin(DGJCAIJPEIM, 54f, DGJCAIJPEIM.transform.localPosition.ReplaceY((!JEGJLALPCKO) ? 933f : 213f));
		}

		internal void BPGFECGMOEN(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 1097f, 1120f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 1141f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(106f));
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1715f, 169f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 636f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1594f), useLocal: false);
			}
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 1078f, PDGEIGFCIOE.AddY(8f), useLocal: false);
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 801f, 1669f);
			TweenColor.Begin(BJGCPDNMHDH.mNumber.gameObject, 619f, Color.black, Color.white);
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 1902f, BJGCPDNMHDH.MHIAJFBLHEC.AddY(1396f), useLocal: false).onFinished = CKOIMNHIPCE;
		}

		internal void LJLJJCHBILG(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 940f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(104f), useLocal: false);
		}

		internal void AIMJGKKMLPI(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 277f, 1912f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1972f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(615f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1829f, 1475f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1593f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1658f), useLocal: false).onFinished = COEJBBJEGJK;
		}

		internal void PGFIJOCGPGD(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 325f, 267f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1914f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(357f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1071f, 1563f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1512f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1095f)).onFinished = COEJBBJEGJK;
		}

		internal void JIBDEKMGAAP(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 1578f, 753f).onFinished = PBEAOOPIIHM;
		}

		internal void POHOFBOGKJK(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1825f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1451f));
		}

		internal void OIPIBKIEMNC(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 0.2f, 1f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 0.2f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(-40f), BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(0f)).onFinished = NLKBJCAIGCE;
		}

		internal void CFPAIEMKNBL(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 13f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(943f));
		}

		internal void BLNOPKPLONB(UITweener IKPCPKPMMAH)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1333f, 692f);
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 187f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(47f), BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(180f)).onFinished = DEMJEGPOMAM;
		}

		internal void FLIKDCBHHEH(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 795f, 1279f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 1832f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(1418f), useLocal: false);
				TweenAlpha.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1408f, 17f);
				TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 868f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1468f));
			}
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 652f, PDGEIGFCIOE.AddY(1126f), useLocal: false);
			TweenAlpha.Begin(KOBFLIFPLMC.gameObject, 807f, 1672f);
			TweenColor.Begin(BJGCPDNMHDH.mNumber.gameObject, 436f, Color.black, Color.white);
			TweenPosition.Begin(BJGCPDNMHDH.mNumber.gameObject, 442f, BJGCPDNMHDH.MHIAJFBLHEC.AddY(813f)).onFinished = IKOBEJFJPHO;
		}

		internal void AANKDBDDDPK(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 476f, 272f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1096f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(553f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1092f, 1933f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1085f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(1134f), useLocal: false).onFinished = COEJBBJEGJK;
		}

		internal void GJAAIBCPKML(UITweener AEEBLJKPGMO)
		{
			UISprite[] mProgressArrows = BJGCPDNMHDH.mProgressArrows;
			for (int i = 1; i < mProgressArrows.Length; i += 0)
			{
				UISprite uISprite = mProgressArrows[i];
				TweenColor.Begin(uISprite.gameObject, 1846f, Color.black.ReplaceA(1576f));
			}
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 1915f, 1929f).onFinished = CBONJHEAODH;
		}

		internal void HIHJOOGKKOB(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1682f, 946f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 119f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(422f), useLocal: false);
			TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1660f, 1869f);
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1688f, BJGCPDNMHDH.mXPRewardPoints.transform.localPosition.ReplaceY(230f), useLocal: false).onFinished = IDCNMJDFJFH;
		}

		internal void LLIIHHNFKHG(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1573f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(298f));
		}

		internal void JGEOBDEOOPA(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardIcon.gameObject, 697f, BJGCPDNMHDH.mWarbucksRewardIcon.transform.localPosition.ReplaceY(350f), useLocal: false);
		}

		internal void DDJHCKFMHGE(UITweener BDEOMPEJELN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWarbucksRewardAmount.gameObject, 1041f, BJGCPDNMHDH.mWarbucksRewardAmount.transform.localPosition.ReplaceY(1453f));
		}

		internal void EODJHIOCFAG(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 283f, 1320f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 1522f, 1427f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 916f, PDGEIGFCIOE).onFinished = BPCIHGNLJKN;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1635f, KAIDDAONLCJ, useLocal: false).onFinished = OCACHPLBMBM;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 508f, 220f).onFinished = GJAAIBCPKML;
		}

		internal void AGNFEDMILNB(UITweener BHBCEPBDLOB)
		{
			if (JEGJLALPCKO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 1660f, 697f);
				TweenPosition.Begin(BJGCPDNMHDH.mXPRewardLabel.gameObject, 331f, BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1393f), BJGCPDNMHDH.mXPRewardLabel.transform.localPosition.ReplaceY(1287f), useLocal: false).onFinished = LLIIHHNFKHG;
				TweenAlpha.Begin(BJGCPDNMHDH.mXPRewardPoints.gameObject, 1726f, 343f).onFinished = MLJNAMJBFLL;
			}
			TweenScale.Begin(GGFKJOGMFMO.gameObject, 89f, HMDBGEANKMI.MultiplyXY(964f), HMDBGEANKMI);
			TweenAlpha.Begin(GGFKJOGMFMO.gameObject, 138f, 366f);
			TweenAlpha.Begin(OLIBALFJOLP.gameObject, 295f, 794f);
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1744f, KAIDDAONLCJ.AddY(683f), KAIDDAONLCJ);
			TweenAlpha.Begin(NIIFMDFKEFC.gameObject, 40f, 129f);
		}

		internal void DDCIHGFIFNE(UITweener LPICCDPEOKA)
		{
			TweenAlpha.Begin(HEMFBMIPNGJ.gameObject, 1809f, 1836f);
			TweenAlpha.Begin(GLLCCFLPEEI.gameObject, 238f, 133f);
			TweenPosition.Begin(KOBFLIFPLMC.gameObject, 743f, PDGEIGFCIOE).onFinished = FLIKDCBHHEH;
			TweenPosition.Begin(NIIFMDFKEFC.gameObject, 1955f, KAIDDAONLCJ, useLocal: false).onFinished = AGNFEDMILNB;
			TweenAlpha.Begin(DMLCAKMKEAG.gameObject, 1425f, 1486f).onFinished = CALJKNNJHAO;
		}

		internal void NMAPPHGCKFK(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mDoneProgress.gameObject, 1519f, 362f).onFinished = DHFMLGKPNMO;
		}
	}

	[Header("Animation Settings")]
	[SerializeField]
	private float mSpeed = 1f;

	[SerializeField]
	private float mMinX = -20f;

	[Header("Core")]
	[SerializeField]
	private NKHJBLBAAEB mCurrentType;

	[SerializeField]
	[Header("Progress")]
	private UISprite mDoneProgress;

	[SerializeField]
	private GameObject mProgressPart;

	[SerializeField]
	private UISprite[] mProgressArrows;

	[Header("Button")]
	[SerializeField]
	private BoxCollider mButtonCollider;

	[SerializeField]
	private UILabel mNumber;

	[Header("Completed Part")]
	[Header("- Small Variants")]
	[SerializeField]
	private GameObject mSmallCompleted;

	[SerializeField]
	private UISprite mSmallCompletedBackground;

	[SerializeField]
	private UISprite mSmallCompletedShadow;

	[SerializeField]
	private UISprite mSmallCompletedCheck;

	[SerializeField]
	[Header("In Progress Part")]
	private GameObject mSmallInProgress;

	[SerializeField]
	private UISprite mSmallInProgressGlow;

	[SerializeField]
	private UISprite mSmallInProgressBackground;

	[SerializeField]
	private UISprite mSmallInProgressShadow;

	[SerializeField]
	private UISprite mSmallInProgressIcon;

	[SerializeField]
	private GameObject mPlayButton;

	[SerializeField]
	private UISprite mPlayButtonBackground;

	[SerializeField]
	private UILabel mPlayButtonLabel;

	[SerializeField]
	[Header("In Progress Animation Part")]
	private GameObject mSmallAnimationObject;

	[SerializeField]
	private UISprite mSmallAnimationSprite;

	[SerializeField]
	[Header("Locked Part")]
	private GameObject mSmallLocked;

	[SerializeField]
	private UISprite mSmallLockedBackground;

	[SerializeField]
	private UISprite mSmallLockedShadow;

	[SerializeField]
	private UISprite mSmallLockedLock;

	[SerializeField]
	[Header("Rewards")]
	private GameObject mRewardsObject;

	[SerializeField]
	private UITable mXPRewardObject;

	[SerializeField]
	private UILabel mXPRewardPoints;

	[SerializeField]
	private UILabel mXPRewardLabel;

	[SerializeField]
	private UITable mWarbucksRewardObject;

	[SerializeField]
	private UILabel mWarbucksRewardAmount;

	[SerializeField]
	private UISprite mWarbucksRewardIcon;

	[SerializeField]
	private UITable mGoldRewardObject;

	[SerializeField]
	private UILabel mGoldRewardAmount;

	[SerializeField]
	private UISprite mGoldRewardIcon;

	[Header("- Big Variants")]
	[SerializeField]
	private UISprite mSoldierUnit;

	[Header("Completed Part")]
	[SerializeField]
	private GameObject mBigCompleted;

	[SerializeField]
	private UISprite mBigCompletedBackground;

	[SerializeField]
	private UISprite mBigCompletedShadow;

	[SerializeField]
	private UISprite mBigCompletedCheck;

	[SerializeField]
	[Header("In Progress Part")]
	private GameObject mBigInProgress;

	[SerializeField]
	private UISprite mBigInProgressGlow;

	[SerializeField]
	private UISprite mBigInProgressBackground;

	[SerializeField]
	private UISprite mBigInProgressShadow;

	[SerializeField]
	private GameObject mBigButton;

	[SerializeField]
	private UISprite mBigButtonBackground;

	[SerializeField]
	private UILabel mBigButtonLabel;

	[SerializeField]
	[Header("In Progress Animation Part")]
	private GameObject mBigAnimationObject;

	[SerializeField]
	private UISprite mBigAnimationSprite;

	[SerializeField]
	[Header("Locked Part")]
	private GameObject mBigLocked;

	[SerializeField]
	private UISprite mBigLockedBackground;

	private DailyMission ANEFJJFFOHM;

	private bool LALJLMACNJO;

	private float PHEADDEDEMG;

	private float JKBBIKLCPNG;

	private const float MELEEMGPHME = 74f;

	private Vector3 IJADNCEAFAB;

	private Vector3 OHGPKEMPEAB;

	private Vector3 GAFFLMFFJDM;

	private Vector3 NMLPMKPMEME;

	private Vector3 LPBHIPKNEDB;

	private Vector3 MHIAJFBLHEC;

	private Vector3 PMALDLLDDEL;

	private Vector3 HEFOLLHHIME;

	private Vector3 PMFFDLACKBB;

	private Vector3 PBMIFNFGFAK;

	private Vector3 DJBLFCGIBDJ;

	private Vector3 FPJHAPAGNPL;

	private Vector3 APALFALEPKE;

	private Vector3 HALEHFCOPLF;

	public void OIJKOGIGNLD()
	{
		CGNMKJJKHPN cGNMKJJKHPN = new CGNMKJJKHPN();
		cGNMKJJKHPN.BJGCPDNMHDH = this;
		cGNMKJJKHPN.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Big;
		mButtonCollider.enabled = false;
		JJMPINJACLO(cGNMKJJKHPN.JEGJLALPCKO);
		cGNMKJJKHPN.NIIFMDFKEFC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedBackground : mSmallCompletedBackground);
		cGNMKJJKHPN.OLIBALFJOLP = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedShadow : mSmallCompletedShadow);
		cGNMKJJKHPN.GGFKJOGMFMO = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedCheck : mSmallCompletedCheck);
		cGNMKJJKHPN.HEMFBMIPNGJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		cGNMKJJKHPN.KOBFLIFPLMC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		cGNMKJJKHPN.GLLCCFLPEEI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		cGNMKJJKHPN.DMLCAKMKEAG = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mSoldierUnit : mSmallInProgressIcon);
		cGNMKJJKHPN.DGJCAIJPEIM = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButton : mPlayButton);
		UISprite uISprite = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		UILabel uILabel = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		Vector3 lhs = ((!cGNMKJJKHPN.JEGJLALPCKO) ? FPJHAPAGNPL : NMLPMKPMEME);
		cGNMKJJKHPN.PDGEIGFCIOE = ((!cGNMKJJKHPN.JEGJLALPCKO) ? DJBLFCGIBDJ : LPBHIPKNEDB);
		cGNMKJJKHPN.KAIDDAONLCJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? APALFALEPKE : PMALDLLDDEL);
		cGNMKJJKHPN.HMDBGEANKMI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? HALEHFCOPLF : HEFOLLHHIME);
		if (cGNMKJJKHPN.JEGJLALPCKO)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 283f, 1339f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 204f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(13f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(730f)).onFinished = cGNMKJJKHPN.PCKMJMGLPDG;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 601f, 1554f).onFinished = cGNMKJJKHPN.KCOGEFBNDKA;
		}
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)70, 1502f);
		TweenAlpha.Begin(uISprite.gameObject, 970f, 468f);
		TweenAlpha.Begin(uILabel.gameObject, 813f, 783f);
		TweenPosition.Begin(cGNMKJJKHPN.DGJCAIJPEIM, 1805f, cGNMKJJKHPN.DGJCAIJPEIM.transform.localPosition.AddY(746f), useLocal: false).onFinished = cGNMKJJKHPN.IGNHNKFEEPA;
		TweenAlpha.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 1468f, 111f);
		TweenScale.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 1992f, lhs.MultiplyXY(415f)).onFinished = cGNMKJJKHPN.IKPPDJNEELO;
	}

	private void INOLBCBFILL(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: true);
			float num = 479f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 907f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 178f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(1872f - num / 1415f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(1211f - num2 / 357f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(172f - num3 / 660f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = true;
			mGoldRewardObject.repositionNow = true;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: false);
			mSmallInProgress.SetActive(value: true);
			mSmallCompleted.SetActive(value: false);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1993f, 1685f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1366f, 1534f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 1166f, 1863f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: true);
			mBigInProgress.SetActive(value: true);
			mBigCompleted.SetActive(value: true);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 196f, 802f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 745f, 765f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 340f, 1786f);
		}
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = true;
		TweenAlpha.Begin(mDoneProgress.gameObject, 1390f, 1477f);
		MGBCNOMEBFM(ECEOFMAEOGE: false);
		mNumber.color = Color.black;
	}

	private void LGMFGLEEABI()
	{
		mPlayButton.SetActive(value: true);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1970f, 677f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 920f, 1234f);
		TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 1321f, 711f);
		TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 1832f, 1011f);
		TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 1019f, 1607f);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 332f, 194f);
		TweenAlpha.Begin(mSmallLockedLock.gameObject, 1365f, 1676f);
		TweenScale.Begin(mSmallLockedLock.gameObject, 339f, IJADNCEAFAB);
		TweenPosition.Begin(mPlayButton, 1763f, mPlayButton.transform.localPosition.ReplaceY(1349f));
		TweenAlpha.Begin(mSmallLockedBackground.gameObject, 303f, 1404f);
		TweenAlpha.Begin(mSmallLockedShadow.gameObject, 1876f, 879f);
		TweenScale.Begin(mSmallLockedBackground.gameObject, 131f, GAFFLMFFJDM);
		TweenScale.Begin(mSmallInProgressBackground.gameObject, 1416f, OHGPKEMPEAB);
		TweenScale.Begin(mSmallInProgressIcon.gameObject, 1131f, NMLPMKPMEME);
		TweenPosition.Begin(mSmallInProgressBackground.gameObject, 1482f, LPBHIPKNEDB, useLocal: false);
		TweenPosition.Begin(mNumber.gameObject, 1785f, MHIAJFBLHEC, useLocal: false);
		TweenPosition.Begin(mSmallCompletedBackground.gameObject, 801f, PMALDLLDDEL);
		TweenScale.Begin(mSmallCompletedCheck.gameObject, 524f, HEFOLLHHIME);
		TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1522f, 1665f);
		TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1922f, 1271f);
		TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 1815f, 167f);
		mBigButton.SetActive(value: false);
		TweenAlpha.Begin(mBigButtonBackground.gameObject, 498f, 867f);
		TweenAlpha.Begin(mBigButtonLabel.gameObject, 472f, 1903f);
		TweenAlpha.Begin(mBigInProgressGlow.gameObject, 370f, 1714f);
		TweenAlpha.Begin(mBigInProgressBackground.gameObject, 1649f, 1577f);
		TweenAlpha.Begin(mBigInProgressShadow.gameObject, 289f, 687f);
		TweenPosition.Begin(mBigButton, 1075f, mBigButton.transform.localPosition.ReplaceY(743f));
		TweenAlpha.Begin(mBigLockedBackground.gameObject, 1868f, 310f);
		TweenScale.Begin(mBigLockedBackground.gameObject, 124f, PBMIFNFGFAK);
		TweenScale.Begin(mBigInProgressBackground.gameObject, 1445f, PMFFDLACKBB);
		TweenPosition.Begin(mBigInProgressBackground.gameObject, 1155f, DJBLFCGIBDJ);
		TweenScale.Begin(mSoldierUnit.gameObject, 1312f, FPJHAPAGNPL);
		TweenAlpha.Begin(mSoldierUnit.gameObject, 50f, 896f);
		TweenPosition.Begin(mBigCompletedBackground.gameObject, 1664f, APALFALEPKE, useLocal: false);
		TweenScale.Begin(mBigCompletedCheck.gameObject, 521f, HALEHFCOPLF);
		TweenAlpha.Begin(mBigCompletedCheck.gameObject, 739f, 1860f);
		TweenAlpha.Begin(mBigCompletedBackground.gameObject, 290f, 995f);
		TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1962f, 689f);
		mRewardsObject.SetActive(value: false);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1059f, 989f);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 1228f, 660f);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 790f, 1011f);
		TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1821f, 1291f);
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 1686f, 326f);
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 990f, 472f);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 729f, 1905f);
	}

	public void BILFFPCGFEA()
	{
		CGNMKJJKHPN cGNMKJJKHPN = new CGNMKJJKHPN();
		cGNMKJJKHPN.BJGCPDNMHDH = this;
		cGNMKJJKHPN.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = false;
		PPANKBGJMPI(cGNMKJJKHPN.JEGJLALPCKO);
		cGNMKJJKHPN.NIIFMDFKEFC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedBackground : mSmallCompletedBackground);
		cGNMKJJKHPN.OLIBALFJOLP = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedShadow : mSmallCompletedShadow);
		cGNMKJJKHPN.GGFKJOGMFMO = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedCheck : mSmallCompletedCheck);
		cGNMKJJKHPN.HEMFBMIPNGJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		cGNMKJJKHPN.KOBFLIFPLMC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		cGNMKJJKHPN.GLLCCFLPEEI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		cGNMKJJKHPN.DMLCAKMKEAG = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mSoldierUnit : mSmallInProgressIcon);
		cGNMKJJKHPN.DGJCAIJPEIM = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButton : mPlayButton);
		UISprite uISprite = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		UILabel uILabel = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		Vector3 lhs = ((!cGNMKJJKHPN.JEGJLALPCKO) ? FPJHAPAGNPL : NMLPMKPMEME);
		cGNMKJJKHPN.PDGEIGFCIOE = ((!cGNMKJJKHPN.JEGJLALPCKO) ? DJBLFCGIBDJ : LPBHIPKNEDB);
		cGNMKJJKHPN.KAIDDAONLCJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? APALFALEPKE : PMALDLLDDEL);
		cGNMKJJKHPN.HMDBGEANKMI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? HALEHFCOPLF : HEFOLLHHIME);
		if (cGNMKJJKHPN.JEGJLALPCKO)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1698f, 687f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 1305f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(1056f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(689f)).onFinished = cGNMKJJKHPN.CHOIECFFEMH;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 1046f, 380f).onFinished = cGNMKJJKHPN.JHDEKOKOLPG;
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OvertimeAlarm, 31f);
		TweenAlpha.Begin(uISprite.gameObject, 595f, 1748f);
		TweenAlpha.Begin(uILabel.gameObject, 103f, 408f);
		TweenPosition.Begin(cGNMKJJKHPN.DGJCAIJPEIM, 750f, cGNMKJJKHPN.DGJCAIJPEIM.transform.localPosition.AddY(1987f)).onFinished = cGNMKJJKHPN.DPBLKLIMOJD;
		TweenAlpha.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 969f, 1440f);
		TweenScale.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 1022f, lhs.MultiplyXY(1503f)).onFinished = cGNMKJJKHPN.IHOMMCFGAPB;
	}

	private void HINPALBAFMI(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1519f)
		{
			PAENPHMEMGC = 911f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 1042f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 953f * (1867f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void ADCCFCDFNGI(bool ECEOFMAEOGE)
	{
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(0.1f));
			}
		}
	}

	private void LENGNOCCDII(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			mSmallInProgress.SetActive(value: true);
			mSmallLocked.SetActive(value: false);
			TweenAlpha.Begin(mSmallAnimationSprite.gameObject, 1487f, 407f, 1834f);
			TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 1564f, 1546f);
			TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 1497f, 220f);
			TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 250f, 1515f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 677f, 1006f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1969f, 1677f);
		}
		else
		{
			mBigInProgress.SetActive(value: false);
			mBigLocked.SetActive(value: true);
			TweenAlpha.Begin(mBigAnimationSprite.gameObject, 1254f, 838f, 973f);
			TweenAlpha.Begin(mBigInProgressGlow.gameObject, 1738f, 1149f);
			TweenAlpha.Begin(mBigInProgressBackground.gameObject, 219f, 137f);
			TweenAlpha.Begin(mBigInProgressShadow.gameObject, 870f, 1390f);
			TweenAlpha.Begin(mBigButtonBackground.gameObject, 732f, 1296f);
			TweenAlpha.Begin(mBigButtonLabel.gameObject, 652f, 62f);
		}
		mProgressPart.SetActive(value: true);
		LALJLMACNJO = false;
		ADCCFCDFNGI(ECEOFMAEOGE: false);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 1043f, 1690f);
	}

	public void BONJCIDLEFB(MissionUnit HNPJBOOPFKO, bool GNNHPMOBMPP)
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		bool flag2 = HNPJBOOPFKO?.isVeteran ?? false;
		bool flag3 = HNPJBOOPFKO?.isElite ?? false;
		mSoldierUnit.gameObject.SetActive(!flag && GNNHPMOBMPP);
		if (!flag && (flag2 || flag3))
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
			mSoldierUnit.spriteName = ((!flag3) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mSoldierUnit.MakePixelPerfect();
			float b = 457f / mSoldierUnit.transform.localScale.y;
			mSoldierUnit.transform.localScale = mSoldierUnit.transform.localScale.MultiplyXY(Mathf.Min(32f, b));
			FPJHAPAGNPL = mSoldierUnit.transform.localScale;
		}
	}

	public void NPJKMHGLDIK(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		LCINGKNHEKL();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("S") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 1361f, 1871f, -128);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(!flag || ECEOFMAEOGE);
		mSmallInProgress.SetActive(flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mSmallLocked.SetActive(!flag || ECEOFMAEOGE || GIAFDDAKALM);
		mBigCompleted.SetActive(flag || ECEOFMAEOGE);
		mBigInProgress.SetActive(!flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mBigLocked.SetActive(!flag && !ECEOFMAEOGE && !GIAFDDAKALM);
		MissionUnit hNPJBOOPFKO = BMLABFOAMLC.config.NLEOKLFFECC();
		BONJCIDLEFB(hNPJBOOPFKO, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			AAIELFEIACG();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(!GIAFDDAKALM && ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 360f;
		BCAACBPAAGH(1813f);
		ADCCFCDFNGI(ECEOFMAEOGE);
	}

	private void DPPCFPNADKD(UITweener GGLNLPOKHPC)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 1156f, 1349f).onFinished = LBJPGANFAEJ;
	}

	private void AEHCGAHLFBB(UITweener HGPPOFHPJBM)
	{
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 507f, mGoldRewardIcon.transform.localPosition.ReplaceY(644f));
	}

	public void KJGJNENLEOF(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Big) ? 801f : 1505f);
		float num2 = CEHFMMJHCKC - num / 500f;
		float num3 = CEHFMMJHCKC - num + 580f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			float num4 = 202f * (float)i;
			mProgressArrows[i].gameObject.SetActive(num4 <= num3);
		}
		FAHLAMGLIAN(591f, KAKIMEJCEFA: true);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KMDEHHBOLLB));
	}

	public void KLCBAEJFNFD()
	{
		CGNMKJJKHPN cGNMKJJKHPN = new CGNMKJJKHPN();
		cGNMKJJKHPN.BJGCPDNMHDH = this;
		cGNMKJJKHPN.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Big;
		mButtonCollider.enabled = true;
		BFOCCDDFBHF(cGNMKJJKHPN.JEGJLALPCKO);
		cGNMKJJKHPN.NIIFMDFKEFC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedBackground : mSmallCompletedBackground);
		cGNMKJJKHPN.OLIBALFJOLP = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedShadow : mSmallCompletedShadow);
		cGNMKJJKHPN.GGFKJOGMFMO = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedCheck : mSmallCompletedCheck);
		cGNMKJJKHPN.HEMFBMIPNGJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		cGNMKJJKHPN.KOBFLIFPLMC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		cGNMKJJKHPN.GLLCCFLPEEI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		cGNMKJJKHPN.DMLCAKMKEAG = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mSoldierUnit : mSmallInProgressIcon);
		cGNMKJJKHPN.DGJCAIJPEIM = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButton : mPlayButton);
		UISprite uISprite = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		UILabel uILabel = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		Vector3 lhs = ((!cGNMKJJKHPN.JEGJLALPCKO) ? FPJHAPAGNPL : NMLPMKPMEME);
		cGNMKJJKHPN.PDGEIGFCIOE = ((!cGNMKJJKHPN.JEGJLALPCKO) ? DJBLFCGIBDJ : LPBHIPKNEDB);
		cGNMKJJKHPN.KAIDDAONLCJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? APALFALEPKE : PMALDLLDDEL);
		cGNMKJJKHPN.HMDBGEANKMI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? HALEHFCOPLF : HEFOLLHHIME);
		if (cGNMKJJKHPN.JEGJLALPCKO)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 951f, 1704f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 486f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(281f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(1806f)).onFinished = cGNMKJJKHPN.PCKMJMGLPDG;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 1185f, 1523f).onFinished = cGNMKJJKHPN.DIDKLCKIPGN;
		}
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-5), 1468f);
		TweenAlpha.Begin(uISprite.gameObject, 1963f, 139f);
		TweenAlpha.Begin(uILabel.gameObject, 905f, 428f);
		TweenPosition.Begin(cGNMKJJKHPN.DGJCAIJPEIM, 801f, cGNMKJJKHPN.DGJCAIJPEIM.transform.localPosition.AddY(518f), useLocal: false).onFinished = cGNMKJJKHPN.BCMKCAHLNBG;
		TweenAlpha.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 1943f, 1549f);
		TweenScale.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 805f, lhs.MultiplyXY(927f)).onFinished = cGNMKJJKHPN.HPCCHOJJGIK;
	}

	private void NGNFFOLFEAJ(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 415f)
		{
			PAENPHMEMGC = 1845f;
		}
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			float num = 577f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 567f * (1672f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void DFEMMAPIJDB(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 789f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 1765f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 1015f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(1096f - num / 128f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(1469f - num2 / 1309f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(1604f - num3 / 925f);
			mXPRewardObject.repositionNow = false;
			mWarbucksRewardObject.repositionNow = false;
			mGoldRewardObject.repositionNow = false;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: true);
			mSmallInProgress.SetActive(value: false);
			mSmallCompleted.SetActive(value: false);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 279f, 1869f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 627f, 607f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 1379f, 1359f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: false);
			mBigInProgress.SetActive(value: false);
			mBigCompleted.SetActive(value: true);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1219f, 1489f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 1823f, 1097f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 737f, 1867f);
		}
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: true);
		LALJLMACNJO = true;
		TweenAlpha.Begin(mDoneProgress.gameObject, 1733f, 1272f);
		BIHOBCCFOHF(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	public void InitGuiValues(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		PALCJJBEMLK();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("ID_BOSS") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 57f, 20f, 163);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(flag && ECEOFMAEOGE);
		mSmallInProgress.SetActive(flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mSmallLocked.SetActive(flag && !ECEOFMAEOGE && !GIAFDDAKALM);
		mBigCompleted.SetActive(!flag && ECEOFMAEOGE);
		mBigInProgress.SetActive(!flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mBigLocked.SetActive(!flag && !ECEOFMAEOGE && !GIAFDDAKALM);
		MissionUnit bossUnit = BMLABFOAMLC.config.bossUnit;
		InitializeBossUnit(bossUnit, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			DOINHAEFDNB();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 0f;
		CEAPNHFPKHM(0f);
		ADCCFCDFNGI(ECEOFMAEOGE);
	}

	public void AFLIMMDJHMK()
	{
		HGCJHDEMAGG hGCJHDEMAGG = new HGCJHDEMAGG();
		hGCJHDEMAGG.BJGCPDNMHDH = this;
		hGCJHDEMAGG.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Big;
		CBNMPJODLMN(hGCJHDEMAGG.JEGJLALPCKO);
		mButtonCollider.enabled = true;
		hGCJHDEMAGG.HEMFBMIPNGJ = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		hGCJHDEMAGG.KOBFLIFPLMC = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		hGCJHDEMAGG.DGJCAIJPEIM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButton : mPlayButton);
		hGCJHDEMAGG.NAPCLCBHAMF = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		hGCJHDEMAGG.GMBJHOCENGD = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		hGCJHDEMAGG.PCDOMENGMOM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigLockedBackground : mSmallLockedBackground);
		hGCJHDEMAGG.GLLCCFLPEEI = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		hGCJHDEMAGG.MINMIPHDFGB = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PBMIFNFGFAK : GAFFLMFFJDM);
		hGCJHDEMAGG.FLCDKJIJHLL = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PMFFDLACKBB : OHGPKEMPEAB);
		TweenAlpha.Begin(hGCJHDEMAGG.HEMFBMIPNGJ.gameObject, 287f, 579f).onFinished = hGCJHDEMAGG.NNIJEDKBPGJ;
	}

	public void ICNGBKKANLB(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Big) ? 1003f : 1344f);
		float num2 = CEHFMMJHCKC - num / 168f;
		float num3 = CEHFMMJHCKC - num + 694f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			float num4 = 1738f * (float)i;
			mProgressArrows[i].gameObject.SetActive(!(num4 <= num3));
		}
		FAHLAMGLIAN(1382f);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPEGOCGNOAH));
	}

	private void MOHLJECKJAH(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 329f)
		{
			PAENPHMEMGC = 1767f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 435f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 684f * (934f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void IANCEOJOFAD(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.XP)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 1079f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 1894f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 1680f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(20f - num / 1967f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(584f - num2 / 1377f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(460f - num3 / 260f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = true;
			mGoldRewardObject.repositionNow = true;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: true);
			mSmallInProgress.SetActive(value: false);
			mSmallCompleted.SetActive(value: true);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1054f, 600f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1821f, 588f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 621f, 1270f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: false);
			mBigInProgress.SetActive(value: false);
			mBigCompleted.SetActive(value: false);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1336f, 873f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 394f, 1317f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 585f, 1291f);
		}
		mProgressPart.SetActive(value: true);
		mDoneProgress.gameObject.SetActive(value: true);
		LALJLMACNJO = false;
		TweenAlpha.Begin(mDoneProgress.gameObject, 1151f, 183f);
		GKHOFGLGIMM(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	public void ILANJGIOJML(MissionUnit HNPJBOOPFKO, bool GNNHPMOBMPP)
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		bool flag2 = HNPJBOOPFKO?.isVeteran ?? false;
		bool flag3 = HNPJBOOPFKO?.isElite ?? true;
		mSoldierUnit.gameObject.SetActive(!flag && !GNNHPMOBMPP);
		if (!flag && (flag2 || flag3))
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
			mSoldierUnit.spriteName = ((!flag3) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mSoldierUnit.MakePixelPerfect();
			float b = 1983f / mSoldierUnit.transform.localScale.y;
			mSoldierUnit.transform.localScale = mSoldierUnit.transform.localScale.MultiplyXY(Mathf.Min(1607f, b));
			FPJHAPAGNPL = mSoldierUnit.transform.localScale;
		}
	}

	[CompilerGenerated]
	private void AALHPDIFBMP(UITweener HGPPOFHPJBM)
	{
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.1f, mGoldRewardIcon.transform.localPosition.ReplaceY(-20f));
	}

	private void KJKBAHJODMP(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			mSmallInProgress.SetActive(value: true);
			mSmallLocked.SetActive(value: true);
			TweenAlpha.Begin(mSmallAnimationSprite.gameObject, 0.8f, 0f, 0f);
			TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 0f, 0f);
			TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 0f, 0f);
			TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 0f, 0f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0f, 0f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0f, 0f);
		}
		else
		{
			mBigInProgress.SetActive(value: true);
			mBigLocked.SetActive(value: true);
			TweenAlpha.Begin(mBigAnimationSprite.gameObject, 0.8f, 0f, 0f);
			TweenAlpha.Begin(mBigInProgressGlow.gameObject, 0f, 0f);
			TweenAlpha.Begin(mBigInProgressBackground.gameObject, 0f, 0f);
			TweenAlpha.Begin(mBigInProgressShadow.gameObject, 0f, 0f);
			TweenAlpha.Begin(mBigButtonBackground.gameObject, 0f, 0f);
			TweenAlpha.Begin(mBigButtonLabel.gameObject, 0f, 0f);
		}
		mProgressPart.SetActive(value: true);
		LALJLMACNJO = true;
		ADCCFCDFNGI(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 0f, 0f);
	}

	private void KDPGNDKHDMH(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			mSmallInProgress.SetActive(value: true);
			mSmallLocked.SetActive(value: false);
			TweenAlpha.Begin(mSmallAnimationSprite.gameObject, 1123f, 1575f, 1747f);
			TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 1187f, 762f);
			TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 1826f, 1314f);
			TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 246f, 4f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 982f, 412f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1218f, 1550f);
		}
		else
		{
			mBigInProgress.SetActive(value: true);
			mBigLocked.SetActive(value: true);
			TweenAlpha.Begin(mBigAnimationSprite.gameObject, 1627f, 502f, 831f);
			TweenAlpha.Begin(mBigInProgressGlow.gameObject, 362f, 870f);
			TweenAlpha.Begin(mBigInProgressBackground.gameObject, 1882f, 1669f);
			TweenAlpha.Begin(mBigInProgressShadow.gameObject, 1434f, 1984f);
			TweenAlpha.Begin(mBigButtonBackground.gameObject, 1219f, 1810f);
			TweenAlpha.Begin(mBigButtonLabel.gameObject, 469f, 71f);
		}
		mProgressPart.SetActive(value: false);
		LALJLMACNJO = false;
		PHIFEAOLPFM(ECEOFMAEOGE: false);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 1967f, 226f);
	}

	private void FBLJLALGHOE(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 555f, 604f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 641f, mGoldRewardIcon.transform.localPosition.ReplaceY(145f));
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0f, 1106f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 245f, mGoldRewardAmount.transform.localPosition.ReplaceY(574f), useLocal: false);
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void AEOLAPGCIFL(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1750f)
		{
			PAENPHMEMGC = 1192f;
		}
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			float num = 302f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 906f * (511f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void NCIEAMBLGLI(UITweener GGLNLPOKHPC)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 1859f, 344f).onFinished = DPIOCGIDLFA;
	}

	private void KOKNLGDOJHJ(GameObject KHAHPAKDIKE)
	{
		if (ANEFJJFFOHM != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.EJDJFNDOFOK(ANEFJJFFOHM);
			DailyMissionsManager.instance.APFKBBHHAAG(ANEFJJFFOHM);
		}
	}

	private void GPBAPJFMLAH()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(1647f, 439f, 992f);
		TweenScale tweenScale = TweenScale.Begin(go, 1025f, vector, vector.MultiplyXY(817f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 449f, 1216f, 1509f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void NGGOIGHIJKM()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(1735f, 1603f, 443f);
		TweenScale tweenScale = TweenScale.Begin(go, 1543f, vector, vector.MultiplyXY(1813f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 1725f, 369f, 1358f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.style = UITweener.Style.Once;
	}

	private void PHIFEAOLPFM(bool ECEOFMAEOGE)
	{
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(158f));
			}
		}
	}

	private void KAIGBNIOMIE(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 402f, 1079f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 191f, mGoldRewardIcon.transform.localPosition.ReplaceY(230f), useLocal: false);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 1107f, 1554f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 1827f, mGoldRewardAmount.transform.localPosition.ReplaceY(1853f), useLocal: false);
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void GABBFHNHJAE(UITweener GGLNLPOKHPC)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 1846f, 411f).onFinished = LBJPGANFAEJ;
	}

	private void KMDEHHBOLLB(GameObject KHAHPAKDIKE)
	{
		if (ANEFJJFFOHM != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.ILFCOPPIOME(ANEFJJFFOHM);
			DailyMissionsManager.instance.APFKBBHHAAG(ANEFJJFFOHM);
		}
	}

	private void BDKHAKLEBKA(UITweener BGFNOJKLKIG)
	{
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 923f, mGoldRewardAmount.transform.localPosition.ReplaceY(638f)).onFinished = NCIEAMBLGLI;
	}

	private void DMMKKOFBFIO()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(1138f, 1186f, 1653f);
		TweenScale tweenScale = TweenScale.Begin(go, 604f, vector, vector.MultiplyXY(250f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 1093f, 1991f, 1845f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	public void AKNCPHIAEIJ(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		DMEEKGDKMLP();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = !GIAFDDAKALM && DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("EmailLogin(") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 578f, 1262f, 49);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(!flag || ECEOFMAEOGE);
		mSmallInProgress.SetActive(!flag || ECEOFMAEOGE || GIAFDDAKALM);
		mSmallLocked.SetActive(flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mBigCompleted.SetActive(flag || ECEOFMAEOGE);
		mBigInProgress.SetActive(flag || ECEOFMAEOGE || GIAFDDAKALM);
		mBigLocked.SetActive(flag || ECEOFMAEOGE || GIAFDDAKALM);
		MissionUnit hNPJBOOPFKO = BMLABFOAMLC.config.DHBDKBGBDAJ();
		AJDKHDKANLJ(hNPJBOOPFKO, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			HAIKKLJNDBL();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 422f;
		MOHLJECKJAH(649f);
		BIHOBCCFOHF(ECEOFMAEOGE);
	}

	private void FPBEHEOFPAH(bool ECEOFMAEOGE)
	{
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(1113f));
			}
		}
	}

	public void JLFLBBHGGIF(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		PALCJJBEMLK();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("Overtime_Was_Already_Explained") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 1810f, 1354f, 145);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(flag && ECEOFMAEOGE);
		mSmallInProgress.SetActive(!flag || ECEOFMAEOGE || GIAFDDAKALM);
		mSmallLocked.SetActive(flag && !ECEOFMAEOGE && !GIAFDDAKALM);
		mBigCompleted.SetActive(flag || ECEOFMAEOGE);
		mBigInProgress.SetActive(!flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mBigLocked.SetActive(!flag && !ECEOFMAEOGE && !GIAFDDAKALM);
		MissionUnit hNPJBOOPFKO = BMLABFOAMLC.config.IHLCGHOIEAC();
		ILANJGIOJML(hNPJBOOPFKO, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			AAIELFEIACG();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(!GIAFDDAKALM && ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 1368f;
		FAHLAMGLIAN(1587f);
		MGBCNOMEBFM(ECEOFMAEOGE);
	}

	private void GEIDEBGIJNB(UITweener HGPPOFHPJBM)
	{
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 536f, mGoldRewardIcon.transform.localPosition.ReplaceY(1663f));
	}

	private void LCMEAHKENFE(GameObject KHAHPAKDIKE)
	{
		if (ANEFJJFFOHM != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.ILFCOPPIOME(ANEFJJFFOHM);
			DailyMissionsManager.instance.NGLHLPHAKJB(ANEFJJFFOHM);
		}
	}

	private void AFJMKBEHNEF(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			mSmallInProgress.SetActive(value: false);
			mSmallLocked.SetActive(value: false);
			TweenAlpha.Begin(mSmallAnimationSprite.gameObject, 1717f, 652f, 808f);
			TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 325f, 1656f);
			TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 1956f, 1286f);
			TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 292f, 994f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 464f, 807f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 804f, 1947f);
		}
		else
		{
			mBigInProgress.SetActive(value: true);
			mBigLocked.SetActive(value: false);
			TweenAlpha.Begin(mBigAnimationSprite.gameObject, 578f, 1793f, 1470f);
			TweenAlpha.Begin(mBigInProgressGlow.gameObject, 151f, 293f);
			TweenAlpha.Begin(mBigInProgressBackground.gameObject, 987f, 1958f);
			TweenAlpha.Begin(mBigInProgressShadow.gameObject, 370f, 1502f);
			TweenAlpha.Begin(mBigButtonBackground.gameObject, 68f, 1991f);
			TweenAlpha.Begin(mBigButtonLabel.gameObject, 1767f, 767f);
		}
		mProgressPart.SetActive(value: true);
		LALJLMACNJO = true;
		BIHOBCCFOHF(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 1201f, 710f);
	}

	private void NGPPHKCIHKJ(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1704f)
		{
			PAENPHMEMGC = 1363f;
		}
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			float num = 1565f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 1703f * (542f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void NOCCKKAIHPI(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1406f, 880f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 10f, mGoldRewardIcon.transform.localPosition.ReplaceY(319f), useLocal: false);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 12f, 257f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 724f, mGoldRewardAmount.transform.localPosition.ReplaceY(806f));
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void BEKHAHCBGLF(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 963f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 1875f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 137f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(99f - num / 754f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(1635f - num2 / 846f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(1774f - num3 / 1395f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = false;
			mGoldRewardObject.repositionNow = false;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: false);
			mSmallInProgress.SetActive(value: false);
			mSmallCompleted.SetActive(value: true);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1564f, 1329f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1541f, 550f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 1237f, 1492f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: true);
			mBigInProgress.SetActive(value: false);
			mBigCompleted.SetActive(value: true);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 734f, 811f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 1167f, 957f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1935f, 1970f);
		}
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = true;
		TweenAlpha.Begin(mDoneProgress.gameObject, 846f, 1847f);
		ADCCFCDFNGI(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	public void AJDKHDKANLJ(MissionUnit HNPJBOOPFKO, bool GNNHPMOBMPP)
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		bool flag2 = HNPJBOOPFKO?.isVeteran ?? true;
		bool flag3 = HNPJBOOPFKO?.isElite ?? false;
		mSoldierUnit.gameObject.SetActive(flag || !GNNHPMOBMPP);
		if (!flag && (flag2 || flag3))
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
			mSoldierUnit.spriteName = ((!flag3) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mSoldierUnit.MakePixelPerfect();
			float b = 1902f / mSoldierUnit.transform.localScale.y;
			mSoldierUnit.transform.localScale = mSoldierUnit.transform.localScale.MultiplyXY(Mathf.Min(1814f, b));
			FPJHAPAGNPL = mSoldierUnit.transform.localScale;
		}
	}

	public void HEOMHIGCMOC(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Big) ? 62f : 925f);
		float num2 = CEHFMMJHCKC - num / 980f;
		float num3 = CEHFMMJHCKC - num + 819f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num4 = 1914f * (float)i;
			mProgressArrows[i].gameObject.SetActive(num4 <= num3);
		}
		BCAACBPAAGH(1483f);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LOEMDKMKKMF));
	}

	private void IICGKAHLNDP(UITweener BGFNOJKLKIG)
	{
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 1719f, mGoldRewardAmount.transform.localPosition.ReplaceY(1834f), useLocal: false).onFinished = IOMDOPGJEOF;
	}

	private void DMEEKGDKMLP()
	{
		mPlayButton.SetActive(value: true);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1931f, 753f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1603f, 362f);
		TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 494f, 1136f);
		TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 840f, 217f);
		TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 1274f, 835f);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 1682f, 1193f);
		TweenAlpha.Begin(mSmallLockedLock.gameObject, 168f, 942f);
		TweenScale.Begin(mSmallLockedLock.gameObject, 1003f, IJADNCEAFAB);
		TweenPosition.Begin(mPlayButton, 1693f, mPlayButton.transform.localPosition.ReplaceY(1828f), useLocal: false);
		TweenAlpha.Begin(mSmallLockedBackground.gameObject, 1249f, 1550f);
		TweenAlpha.Begin(mSmallLockedShadow.gameObject, 1232f, 857f);
		TweenScale.Begin(mSmallLockedBackground.gameObject, 872f, GAFFLMFFJDM);
		TweenScale.Begin(mSmallInProgressBackground.gameObject, 622f, OHGPKEMPEAB);
		TweenScale.Begin(mSmallInProgressIcon.gameObject, 47f, NMLPMKPMEME);
		TweenPosition.Begin(mSmallInProgressBackground.gameObject, 506f, LPBHIPKNEDB, useLocal: false);
		TweenPosition.Begin(mNumber.gameObject, 1749f, MHIAJFBLHEC);
		TweenPosition.Begin(mSmallCompletedBackground.gameObject, 267f, PMALDLLDDEL);
		TweenScale.Begin(mSmallCompletedCheck.gameObject, 1506f, HEFOLLHHIME);
		TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1260f, 1770f);
		TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 937f, 1759f);
		TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 241f, 108f);
		mBigButton.SetActive(value: true);
		TweenAlpha.Begin(mBigButtonBackground.gameObject, 1877f, 396f);
		TweenAlpha.Begin(mBigButtonLabel.gameObject, 1338f, 1807f);
		TweenAlpha.Begin(mBigInProgressGlow.gameObject, 1951f, 1683f);
		TweenAlpha.Begin(mBigInProgressBackground.gameObject, 1998f, 1777f);
		TweenAlpha.Begin(mBigInProgressShadow.gameObject, 1886f, 1869f);
		TweenPosition.Begin(mBigButton, 1018f, mBigButton.transform.localPosition.ReplaceY(1345f), useLocal: false);
		TweenAlpha.Begin(mBigLockedBackground.gameObject, 1620f, 921f);
		TweenScale.Begin(mBigLockedBackground.gameObject, 49f, PBMIFNFGFAK);
		TweenScale.Begin(mBigInProgressBackground.gameObject, 424f, PMFFDLACKBB);
		TweenPosition.Begin(mBigInProgressBackground.gameObject, 1492f, DJBLFCGIBDJ);
		TweenScale.Begin(mSoldierUnit.gameObject, 1424f, FPJHAPAGNPL);
		TweenAlpha.Begin(mSoldierUnit.gameObject, 734f, 895f);
		TweenPosition.Begin(mBigCompletedBackground.gameObject, 731f, APALFALEPKE, useLocal: false);
		TweenScale.Begin(mBigCompletedCheck.gameObject, 1396f, HALEHFCOPLF);
		TweenAlpha.Begin(mBigCompletedCheck.gameObject, 438f, 343f);
		TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1386f, 216f);
		TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1259f, 1004f);
		mRewardsObject.SetActive(value: true);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1942f, 214f);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 231f, 204f);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 495f, 1236f);
		TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1951f, 572f);
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 1622f, 1013f);
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 362f, 324f);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 402f, 1371f);
	}

	private void BOPGJFGMNJM()
	{
		if (LALJLMACNJO && mSpeed > 1967f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			FAHLAMGLIAN(num / mSpeed, KAKIMEJCEFA: true);
		}
	}

	public void KFIGIFMNNBK(MissionUnit HNPJBOOPFKO, bool GNNHPMOBMPP)
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		bool flag2 = HNPJBOOPFKO?.isVeteran ?? true;
		bool flag3 = HNPJBOOPFKO?.isElite ?? false;
		mSoldierUnit.gameObject.SetActive(!flag && GNNHPMOBMPP);
		if (!flag && (flag2 || flag3))
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
			mSoldierUnit.spriteName = ((!flag3) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mSoldierUnit.MakePixelPerfect();
			float b = 528f / mSoldierUnit.transform.localScale.y;
			mSoldierUnit.transform.localScale = mSoldierUnit.transform.localScale.MultiplyXY(Mathf.Min(1873f, b));
			FPJHAPAGNPL = mSoldierUnit.transform.localScale;
		}
	}

	public void PIAFBFFEBDP()
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 409f, 1050f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 779f, mGoldRewardIcon.transform.localPosition.ReplaceY(1571f), mGoldRewardIcon.transform.localPosition.ReplaceY(225f)).onFinished = CKIDBCKCKID;
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 1056f, 1502f).onFinished = FLCDHFAJPOM;
	}

	private void JEIHGKOHEAH(UITweener HPBPMJALCND)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 799f, 1636f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 761f, mGoldRewardAmount.transform.localPosition.ReplaceY(1624f), mGoldRewardAmount.transform.localPosition.ReplaceY(527f), useLocal: false).onFinished = delegate
		{
			TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.1f, mGoldRewardAmount.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
			{
				TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.3f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
					TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
					GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
				};
			};
		};
	}

	private void BOKGEGICDCG(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			mSmallInProgress.SetActive(value: true);
			mSmallLocked.SetActive(value: false);
			TweenAlpha.Begin(mSmallAnimationSprite.gameObject, 612f, 680f, 1626f);
			TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 306f, 963f);
			TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 822f, 1061f);
			TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 325f, 1168f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 215f, 459f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1962f, 1772f);
		}
		else
		{
			mBigInProgress.SetActive(value: false);
			mBigLocked.SetActive(value: false);
			TweenAlpha.Begin(mBigAnimationSprite.gameObject, 523f, 1638f, 287f);
			TweenAlpha.Begin(mBigInProgressGlow.gameObject, 383f, 411f);
			TweenAlpha.Begin(mBigInProgressBackground.gameObject, 498f, 864f);
			TweenAlpha.Begin(mBigInProgressShadow.gameObject, 1352f, 1768f);
			TweenAlpha.Begin(mBigButtonBackground.gameObject, 685f, 120f);
			TweenAlpha.Begin(mBigButtonLabel.gameObject, 1417f, 638f);
		}
		mProgressPart.SetActive(value: true);
		LALJLMACNJO = false;
		GKHOFGLGIMM(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 1688f, 1561f);
	}

	private void DOINHAEFDNB()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(1f, 1f, 1f);
		TweenScale tweenScale = TweenScale.Begin(go, 0.8f, vector, vector.MultiplyXY(2f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 0.8f, 0.4f, 0f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	public void FJJHFMBOFDO(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Big) ? 1467f : 1536f);
		float num2 = CEHFMMJHCKC - num / 1515f;
		float num3 = CEHFMMJHCKC - num + 1756f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num4 = 575f * (float)i;
			mProgressArrows[i].gameObject.SetActive(!(num4 <= num3));
		}
		FAHLAMGLIAN(1659f, KAKIMEJCEFA: true);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KMDEHHBOLLB));
	}

	public void LOBDMFNALMC()
	{
		CGNMKJJKHPN cGNMKJJKHPN = new CGNMKJJKHPN();
		cGNMKJJKHPN.BJGCPDNMHDH = this;
		cGNMKJJKHPN.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Big;
		mButtonCollider.enabled = false;
		PDJGLHBCPCD(cGNMKJJKHPN.JEGJLALPCKO);
		cGNMKJJKHPN.NIIFMDFKEFC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedBackground : mSmallCompletedBackground);
		cGNMKJJKHPN.OLIBALFJOLP = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedShadow : mSmallCompletedShadow);
		cGNMKJJKHPN.GGFKJOGMFMO = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedCheck : mSmallCompletedCheck);
		cGNMKJJKHPN.HEMFBMIPNGJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		cGNMKJJKHPN.KOBFLIFPLMC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		cGNMKJJKHPN.GLLCCFLPEEI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		cGNMKJJKHPN.DMLCAKMKEAG = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mSoldierUnit : mSmallInProgressIcon);
		cGNMKJJKHPN.DGJCAIJPEIM = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButton : mPlayButton);
		UISprite uISprite = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		UILabel uILabel = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		Vector3 lhs = ((!cGNMKJJKHPN.JEGJLALPCKO) ? FPJHAPAGNPL : NMLPMKPMEME);
		cGNMKJJKHPN.PDGEIGFCIOE = ((!cGNMKJJKHPN.JEGJLALPCKO) ? DJBLFCGIBDJ : LPBHIPKNEDB);
		cGNMKJJKHPN.KAIDDAONLCJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? APALFALEPKE : PMALDLLDDEL);
		cGNMKJJKHPN.HMDBGEANKMI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? HALEHFCOPLF : HEFOLLHHIME);
		if (cGNMKJJKHPN.JEGJLALPCKO)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1756f, 1491f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 1420f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(51f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(533f)).onFinished = cGNMKJJKHPN.HLBPCGPPCMJ;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 729f, 1125f).onFinished = cGNMKJJKHPN.KCOGEFBNDKA;
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootboxLegendary, 335f);
		TweenAlpha.Begin(uISprite.gameObject, 914f, 586f);
		TweenAlpha.Begin(uILabel.gameObject, 206f, 1352f);
		TweenPosition.Begin(cGNMKJJKHPN.DGJCAIJPEIM, 135f, cGNMKJJKHPN.DGJCAIJPEIM.transform.localPosition.AddY(1047f)).onFinished = cGNMKJJKHPN.OCEMAFDGLCC;
		TweenAlpha.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 873f, 1547f);
		TweenScale.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 516f, lhs.MultiplyXY(1942f)).onFinished = cGNMKJJKHPN.BIGNHFCNJLL;
	}

	private void NKGLGNEJIOA()
	{
		if (LALJLMACNJO && mSpeed > 1692f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			FAHLAMGLIAN(num / mSpeed, KAKIMEJCEFA: true);
		}
	}

	private void BHGIOOJKPGN(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: true);
			float num = 1829f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 674f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 1948f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(1860f - num / 197f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(193f - num2 / 1982f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(979f - num3 / 972f);
			mXPRewardObject.repositionNow = false;
			mWarbucksRewardObject.repositionNow = false;
			mGoldRewardObject.repositionNow = false;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: true);
			mSmallInProgress.SetActive(value: true);
			mSmallCompleted.SetActive(value: true);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 473f, 1886f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1518f, 1379f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 1282f, 1090f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: false);
			mBigInProgress.SetActive(value: true);
			mBigCompleted.SetActive(value: false);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1364f, 279f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 634f, 986f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 821f, 298f);
		}
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = true;
		TweenAlpha.Begin(mDoneProgress.gameObject, 120f, 6f);
		MGBCNOMEBFM(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	private void AENDHOOIEAK(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 164f, 283f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1355f, mGoldRewardIcon.transform.localPosition.ReplaceY(422f));
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 863f, 449f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 470f, mGoldRewardAmount.transform.localPosition.ReplaceY(1376f), useLocal: false);
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void MGBCNOMEBFM(bool ECEOFMAEOGE)
	{
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(17f));
			}
		}
	}

	private void FDOPBJPNFFL(UITweener BGFNOJKLKIG)
	{
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 1728f, mGoldRewardAmount.transform.localPosition.ReplaceY(577f), useLocal: false).onFinished = NCIEAMBLGLI;
	}

	public void ContinueAnimationOfCompleted()
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 1f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f), mGoldRewardIcon.transform.localPosition.ReplaceY(0f)).onFinished = delegate
		{
			TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.1f, mGoldRewardIcon.transform.localPosition.ReplaceY(-20f));
		};
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.1f, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 1f);
			TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f), mGoldRewardAmount.transform.localPosition.ReplaceY(0f)).onFinished = delegate
			{
				TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.1f, mGoldRewardAmount.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
				{
					TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.3f, 1f).onFinished = delegate
					{
						TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
						TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
						TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
						TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
						GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
					};
				};
			};
		};
	}

	[CompilerGenerated]
	private void CMGHHAIPKGC(UITweener GGLNLPOKHPC)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.3f, 1f).onFinished = delegate
		{
			TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
			TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
			TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
			TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
			GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
		};
	}

	public void BIBOBFCCNIJ()
	{
		HGCJHDEMAGG hGCJHDEMAGG = new HGCJHDEMAGG();
		hGCJHDEMAGG.BJGCPDNMHDH = this;
		hGCJHDEMAGG.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		AKNCBNKDMJG(hGCJHDEMAGG.JEGJLALPCKO);
		mButtonCollider.enabled = true;
		hGCJHDEMAGG.HEMFBMIPNGJ = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		hGCJHDEMAGG.KOBFLIFPLMC = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		hGCJHDEMAGG.DGJCAIJPEIM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButton : mPlayButton);
		hGCJHDEMAGG.NAPCLCBHAMF = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		hGCJHDEMAGG.GMBJHOCENGD = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		hGCJHDEMAGG.PCDOMENGMOM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigLockedBackground : mSmallLockedBackground);
		hGCJHDEMAGG.GLLCCFLPEEI = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		hGCJHDEMAGG.MINMIPHDFGB = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PBMIFNFGFAK : GAFFLMFFJDM);
		hGCJHDEMAGG.FLCDKJIJHLL = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PMFFDLACKBB : OHGPKEMPEAB);
		TweenAlpha.Begin(hGCJHDEMAGG.HEMFBMIPNGJ.gameObject, 1002f, 1304f).onFinished = hGCJHDEMAGG.IIPLOACIHMD;
	}

	private void HLOAONMIOAO(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 210f, 413f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1852f, mGoldRewardIcon.transform.localPosition.ReplaceY(801f));
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 768f, 1309f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 367f, mGoldRewardAmount.transform.localPosition.ReplaceY(772f));
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void EOCLEFCDFFD()
	{
		mPlayButton.SetActive(value: false);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1352f, 1815f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 298f, 188f);
		TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 705f, 35f);
		TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 239f, 1186f);
		TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 1419f, 254f);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 869f, 1188f);
		TweenAlpha.Begin(mSmallLockedLock.gameObject, 1310f, 99f);
		TweenScale.Begin(mSmallLockedLock.gameObject, 1612f, IJADNCEAFAB);
		TweenPosition.Begin(mPlayButton, 1809f, mPlayButton.transform.localPosition.ReplaceY(1030f));
		TweenAlpha.Begin(mSmallLockedBackground.gameObject, 1581f, 1173f);
		TweenAlpha.Begin(mSmallLockedShadow.gameObject, 1741f, 426f);
		TweenScale.Begin(mSmallLockedBackground.gameObject, 1939f, GAFFLMFFJDM);
		TweenScale.Begin(mSmallInProgressBackground.gameObject, 1905f, OHGPKEMPEAB);
		TweenScale.Begin(mSmallInProgressIcon.gameObject, 73f, NMLPMKPMEME);
		TweenPosition.Begin(mSmallInProgressBackground.gameObject, 567f, LPBHIPKNEDB);
		TweenPosition.Begin(mNumber.gameObject, 430f, MHIAJFBLHEC, useLocal: false);
		TweenPosition.Begin(mSmallCompletedBackground.gameObject, 883f, PMALDLLDDEL, useLocal: false);
		TweenScale.Begin(mSmallCompletedCheck.gameObject, 1861f, HEFOLLHHIME);
		TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1695f, 1710f);
		TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 328f, 1966f);
		TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 147f, 1700f);
		mBigButton.SetActive(value: true);
		TweenAlpha.Begin(mBigButtonBackground.gameObject, 1296f, 111f);
		TweenAlpha.Begin(mBigButtonLabel.gameObject, 351f, 577f);
		TweenAlpha.Begin(mBigInProgressGlow.gameObject, 890f, 720f);
		TweenAlpha.Begin(mBigInProgressBackground.gameObject, 1517f, 1027f);
		TweenAlpha.Begin(mBigInProgressShadow.gameObject, 1593f, 590f);
		TweenPosition.Begin(mBigButton, 1678f, mBigButton.transform.localPosition.ReplaceY(297f));
		TweenAlpha.Begin(mBigLockedBackground.gameObject, 1681f, 281f);
		TweenScale.Begin(mBigLockedBackground.gameObject, 1899f, PBMIFNFGFAK);
		TweenScale.Begin(mBigInProgressBackground.gameObject, 1490f, PMFFDLACKBB);
		TweenPosition.Begin(mBigInProgressBackground.gameObject, 120f, DJBLFCGIBDJ, useLocal: false);
		TweenScale.Begin(mSoldierUnit.gameObject, 1859f, FPJHAPAGNPL);
		TweenAlpha.Begin(mSoldierUnit.gameObject, 738f, 1888f);
		TweenPosition.Begin(mBigCompletedBackground.gameObject, 539f, APALFALEPKE);
		TweenScale.Begin(mBigCompletedCheck.gameObject, 123f, HALEHFCOPLF);
		TweenAlpha.Begin(mBigCompletedCheck.gameObject, 142f, 517f);
		TweenAlpha.Begin(mBigCompletedBackground.gameObject, 611f, 419f);
		TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1379f, 94f);
		mRewardsObject.SetActive(value: false);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1437f, 619f);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 1903f, 875f);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 564f, 745f);
		TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1658f, 5f);
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 583f, 446f);
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1097f, 571f);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 1679f, 994f);
	}

	private void JJMPINJACLO(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 1877f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 1608f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 1468f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(785f - num / 1937f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(404f - num2 / 1224f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(1322f - num3 / 1413f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = false;
			mGoldRewardObject.repositionNow = false;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: true);
			mSmallInProgress.SetActive(value: true);
			mSmallCompleted.SetActive(value: false);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 371f, 505f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1469f, 1898f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 77f, 522f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: false);
			mBigInProgress.SetActive(value: false);
			mBigCompleted.SetActive(value: false);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 499f, 1963f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 98f, 1025f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1417f, 1322f);
		}
		mProgressPart.SetActive(value: true);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = true;
		TweenAlpha.Begin(mDoneProgress.gameObject, 824f, 1119f);
		BIHOBCCFOHF(ECEOFMAEOGE: false);
		mNumber.color = Color.black;
	}

	private void FAHLAMGLIAN(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1800f)
		{
			PAENPHMEMGC = 1314f;
		}
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			float num = 1141f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 1561f * (158f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void DPIOCGIDLFA(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 65f, 1028f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1293f, mGoldRewardIcon.transform.localPosition.ReplaceY(415f), useLocal: false);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 75f, 1338f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 552f, mGoldRewardAmount.transform.localPosition.ReplaceY(1875f));
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void MIBIBOCHICG(bool ECEOFMAEOGE)
	{
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(805f));
			}
		}
	}

	private void IHCKIPHACNA(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.XP)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: true);
			float num = 35f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 1070f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 1965f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(346f - num / 134f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(159f - num2 / 1845f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(125f - num3 / 769f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = true;
			mGoldRewardObject.repositionNow = false;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: false);
			mSmallInProgress.SetActive(value: true);
			mSmallCompleted.SetActive(value: true);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1085f, 1230f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1676f, 1638f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 631f, 3f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: true);
			mBigInProgress.SetActive(value: false);
			mBigCompleted.SetActive(value: true);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1008f, 503f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 58f, 448f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1120f, 938f);
		}
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: true);
		LALJLMACNJO = false;
		TweenAlpha.Begin(mDoneProgress.gameObject, 798f, 385f);
		PHIFEAOLPFM(ECEOFMAEOGE: false);
		mNumber.color = Color.black;
	}

	private void BFOCCDDFBHF(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 1380f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 1666f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 1723f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(1203f - num / 79f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(908f - num2 / 639f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(1915f - num3 / 563f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = true;
			mGoldRewardObject.repositionNow = false;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: false);
			mSmallInProgress.SetActive(value: false);
			mSmallCompleted.SetActive(value: false);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 321f, 1896f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 784f, 1341f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 598f, 388f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: false);
			mBigInProgress.SetActive(value: true);
			mBigCompleted.SetActive(value: true);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1288f, 209f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 981f, 1447f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1546f, 1890f);
		}
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = true;
		TweenAlpha.Begin(mDoneProgress.gameObject, 1104f, 250f);
		GKHOFGLGIMM(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	public void LNLAPPKDCLN(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		EJFFIGHIEDA();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = !GIAFDDAKALM && DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("ID_CONFIRM_ERROR") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 1719f, 1615f, -188);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(!flag || ECEOFMAEOGE);
		mSmallInProgress.SetActive(!flag || ECEOFMAEOGE || GIAFDDAKALM);
		mSmallLocked.SetActive(!flag || ECEOFMAEOGE || GIAFDDAKALM);
		mBigCompleted.SetActive(!flag && ECEOFMAEOGE);
		mBigInProgress.SetActive(flag || ECEOFMAEOGE || GIAFDDAKALM);
		mBigLocked.SetActive(flag || ECEOFMAEOGE || GIAFDDAKALM);
		MissionUnit hNPJBOOPFKO = BMLABFOAMLC.config.CIDHFKPFJAK();
		BONJCIDLEFB(hNPJBOOPFKO, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			HAIKKLJNDBL();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 535f;
		CEAPNHFPKHM(605f);
		GKHOFGLGIMM(ECEOFMAEOGE);
	}

	public void AnimateCompleted()
	{
		CGNMKJJKHPN cGNMKJJKHPN = new CGNMKJJKHPN();
		cGNMKJJKHPN.BJGCPDNMHDH = this;
		cGNMKJJKHPN.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = false;
		LOMAFKIMCDC(cGNMKJJKHPN.JEGJLALPCKO);
		cGNMKJJKHPN.NIIFMDFKEFC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedBackground : mSmallCompletedBackground);
		cGNMKJJKHPN.OLIBALFJOLP = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedShadow : mSmallCompletedShadow);
		cGNMKJJKHPN.GGFKJOGMFMO = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedCheck : mSmallCompletedCheck);
		cGNMKJJKHPN.HEMFBMIPNGJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		cGNMKJJKHPN.KOBFLIFPLMC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		cGNMKJJKHPN.GLLCCFLPEEI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		cGNMKJJKHPN.DMLCAKMKEAG = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mSoldierUnit : mSmallInProgressIcon);
		cGNMKJJKHPN.DGJCAIJPEIM = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButton : mPlayButton);
		UISprite uISprite = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		UILabel uILabel = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		Vector3 lhs = ((!cGNMKJJKHPN.JEGJLALPCKO) ? FPJHAPAGNPL : NMLPMKPMEME);
		cGNMKJJKHPN.PDGEIGFCIOE = ((!cGNMKJJKHPN.JEGJLALPCKO) ? DJBLFCGIBDJ : LPBHIPKNEDB);
		cGNMKJJKHPN.KAIDDAONLCJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? APALFALEPKE : PMALDLLDDEL);
		cGNMKJJKHPN.HMDBGEANKMI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? HALEHFCOPLF : HEFOLLHHIME);
		if (cGNMKJJKHPN.JEGJLALPCKO)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0.2f, 1f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 0.2f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(-40f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(0f)).onFinished = cGNMKJJKHPN.LJCDGJKCNEC;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0.1f, 0f).onFinished = cGNMKJJKHPN.EJLGBICBIFK;
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionCompleted);
		TweenAlpha.Begin(uISprite.gameObject, 0.2f, 0f);
		TweenAlpha.Begin(uILabel.gameObject, 0.2f, 0f);
		TweenPosition.Begin(cGNMKJJKHPN.DGJCAIJPEIM, 0.1f, cGNMKJJKHPN.DGJCAIJPEIM.transform.localPosition.AddY(30f)).onFinished = cGNMKJJKHPN.HONCMBHEKDP;
		TweenAlpha.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 0.5f, 0f);
		TweenScale.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 0.5f, lhs.MultiplyXY(2.5f)).onFinished = cGNMKJJKHPN.BIGNHFCNJLL;
	}

	public void AnimateUnlocked()
	{
		HGCJHDEMAGG hGCJHDEMAGG = new HGCJHDEMAGG();
		hGCJHDEMAGG.BJGCPDNMHDH = this;
		hGCJHDEMAGG.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		KJKBAHJODMP(hGCJHDEMAGG.JEGJLALPCKO);
		mButtonCollider.enabled = true;
		hGCJHDEMAGG.HEMFBMIPNGJ = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		hGCJHDEMAGG.KOBFLIFPLMC = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		hGCJHDEMAGG.DGJCAIJPEIM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButton : mPlayButton);
		hGCJHDEMAGG.NAPCLCBHAMF = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		hGCJHDEMAGG.GMBJHOCENGD = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		hGCJHDEMAGG.PCDOMENGMOM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigLockedBackground : mSmallLockedBackground);
		hGCJHDEMAGG.GLLCCFLPEEI = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		hGCJHDEMAGG.MINMIPHDFGB = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PBMIFNFGFAK : GAFFLMFFJDM);
		hGCJHDEMAGG.FLCDKJIJHLL = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PMFFDLACKBB : OHGPKEMPEAB);
		TweenAlpha.Begin(hGCJHDEMAGG.HEMFBMIPNGJ.gameObject, 0.5f, 0f).onFinished = hGCJHDEMAGG.LJCDGJKCNEC;
	}

	public void NDOCBDDDMJJ()
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1001f, 748f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1753f, mGoldRewardIcon.transform.localPosition.ReplaceY(612f), mGoldRewardIcon.transform.localPosition.ReplaceY(1138f), useLocal: false).onFinished = GEIDEBGIJNB;
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 79f, 1328f).onFinished = delegate
		{
			TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 1f);
			TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f), mGoldRewardAmount.transform.localPosition.ReplaceY(0f)).onFinished = delegate
			{
				TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.1f, mGoldRewardAmount.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
				{
					TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.3f, 1f).onFinished = delegate
					{
						TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
						TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
						TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
						TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
						GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
					};
				};
			};
		};
	}

	public void IKPLOFBMCFA()
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1496f, 1954f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1552f, mGoldRewardIcon.transform.localPosition.ReplaceY(49f), mGoldRewardIcon.transform.localPosition.ReplaceY(1858f)).onFinished = AEHCGAHLFBB;
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 838f, 1320f).onFinished = FLCDHFAJPOM;
	}

	private void IOMDOPGJEOF(UITweener GGLNLPOKHPC)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 705f, 650f).onFinished = HLOAONMIOAO;
	}

	[CompilerGenerated]
	private void HMMKDNAACJE(UITweener BGFNOJKLKIG)
	{
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.1f, mGoldRewardAmount.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
		{
			TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.3f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
				TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
				TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
				GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
			};
		};
	}

	private void FLCDHFAJPOM(UITweener HPBPMJALCND)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 783f, 482f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 836f, mGoldRewardAmount.transform.localPosition.ReplaceY(1937f), mGoldRewardAmount.transform.localPosition.ReplaceY(69f)).onFinished = delegate
		{
			TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.1f, mGoldRewardAmount.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
			{
				TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.3f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
					TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
					GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
				};
			};
		};
	}

	public void InitializeBossUnit(MissionUnit HNPJBOOPFKO, bool GNNHPMOBMPP)
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		bool flag2 = HNPJBOOPFKO?.isVeteran ?? false;
		bool flag3 = HNPJBOOPFKO?.isElite ?? false;
		mSoldierUnit.gameObject.SetActive(!flag && !GNNHPMOBMPP);
		if (!flag && (flag2 || flag3))
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
			mSoldierUnit.spriteName = ((!flag3) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mSoldierUnit.MakePixelPerfect();
			float b = 144f / mSoldierUnit.transform.localScale.y;
			mSoldierUnit.transform.localScale = mSoldierUnit.transform.localScale.MultiplyXY(Mathf.Min(1f, b));
			FPJHAPAGNPL = mSoldierUnit.transform.localScale;
		}
	}

	private void EJFFIGHIEDA()
	{
		mPlayButton.SetActive(value: false);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1570f, 1475f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 380f, 804f);
		TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 1762f, 1001f);
		TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 1317f, 474f);
		TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 1948f, 1470f);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 837f, 1376f);
		TweenAlpha.Begin(mSmallLockedLock.gameObject, 337f, 486f);
		TweenScale.Begin(mSmallLockedLock.gameObject, 177f, IJADNCEAFAB);
		TweenPosition.Begin(mPlayButton, 1050f, mPlayButton.transform.localPosition.ReplaceY(338f));
		TweenAlpha.Begin(mSmallLockedBackground.gameObject, 1658f, 180f);
		TweenAlpha.Begin(mSmallLockedShadow.gameObject, 1760f, 1938f);
		TweenScale.Begin(mSmallLockedBackground.gameObject, 248f, GAFFLMFFJDM);
		TweenScale.Begin(mSmallInProgressBackground.gameObject, 260f, OHGPKEMPEAB);
		TweenScale.Begin(mSmallInProgressIcon.gameObject, 204f, NMLPMKPMEME);
		TweenPosition.Begin(mSmallInProgressBackground.gameObject, 1128f, LPBHIPKNEDB, useLocal: false);
		TweenPosition.Begin(mNumber.gameObject, 1419f, MHIAJFBLHEC);
		TweenPosition.Begin(mSmallCompletedBackground.gameObject, 209f, PMALDLLDDEL);
		TweenScale.Begin(mSmallCompletedCheck.gameObject, 453f, HEFOLLHHIME);
		TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1441f, 1502f);
		TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 126f, 1547f);
		TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 781f, 1613f);
		mBigButton.SetActive(value: true);
		TweenAlpha.Begin(mBigButtonBackground.gameObject, 321f, 708f);
		TweenAlpha.Begin(mBigButtonLabel.gameObject, 518f, 653f);
		TweenAlpha.Begin(mBigInProgressGlow.gameObject, 1043f, 1280f);
		TweenAlpha.Begin(mBigInProgressBackground.gameObject, 25f, 292f);
		TweenAlpha.Begin(mBigInProgressShadow.gameObject, 1176f, 765f);
		TweenPosition.Begin(mBigButton, 1225f, mBigButton.transform.localPosition.ReplaceY(1386f));
		TweenAlpha.Begin(mBigLockedBackground.gameObject, 590f, 963f);
		TweenScale.Begin(mBigLockedBackground.gameObject, 1054f, PBMIFNFGFAK);
		TweenScale.Begin(mBigInProgressBackground.gameObject, 1116f, PMFFDLACKBB);
		TweenPosition.Begin(mBigInProgressBackground.gameObject, 33f, DJBLFCGIBDJ, useLocal: false);
		TweenScale.Begin(mSoldierUnit.gameObject, 678f, FPJHAPAGNPL);
		TweenAlpha.Begin(mSoldierUnit.gameObject, 215f, 220f);
		TweenPosition.Begin(mBigCompletedBackground.gameObject, 1703f, APALFALEPKE, useLocal: false);
		TweenScale.Begin(mBigCompletedCheck.gameObject, 1626f, HALEHFCOPLF);
		TweenAlpha.Begin(mBigCompletedCheck.gameObject, 761f, 318f);
		TweenAlpha.Begin(mBigCompletedBackground.gameObject, 722f, 1293f);
		TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1206f, 152f);
		mRewardsObject.SetActive(value: false);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1162f, 1021f);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 433f, 793f);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1765f, 1347f);
		TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1285f, 1206f);
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 1088f, 1094f);
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1499f, 741f);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 1751f, 1989f);
	}

	private void LOEMDKMKKMF(GameObject KHAHPAKDIKE)
	{
		if (ANEFJJFFOHM != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.ILFCOPPIOME(ANEFJJFFOHM);
			DailyMissionsManager.instance.APFKBBHHAAG(ANEFJJFFOHM);
		}
	}

	private void LPEGOCGNOAH(GameObject KHAHPAKDIKE)
	{
		if (ANEFJJFFOHM != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.ShowDialog(ANEFJJFFOHM);
			DailyMissionsManager.instance.currentMission = ANEFJJFFOHM;
		}
	}

	public void CJADGACNBJL(MissionUnit HNPJBOOPFKO, bool GNNHPMOBMPP)
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		bool flag2 = HNPJBOOPFKO?.isVeteran ?? true;
		bool flag3 = HNPJBOOPFKO?.isElite ?? false;
		mSoldierUnit.gameObject.SetActive(flag || GNNHPMOBMPP);
		if (!flag && (flag2 || flag3))
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
			mSoldierUnit.spriteName = ((!flag3) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mSoldierUnit.MakePixelPerfect();
			float b = 433f / mSoldierUnit.transform.localScale.y;
			mSoldierUnit.transform.localScale = mSoldierUnit.transform.localScale.MultiplyXY(Mathf.Min(318f, b));
			FPJHAPAGNPL = mSoldierUnit.transform.localScale;
		}
	}

	[CompilerGenerated]
	private void PIENGDHCIKK(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	public void HHNCKIOGKBA()
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 855f, 650f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 508f, mGoldRewardIcon.transform.localPosition.ReplaceY(1917f), mGoldRewardIcon.transform.localPosition.ReplaceY(1524f)).onFinished = AEHCGAHLFBB;
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 486f, 757f).onFinished = JEIHGKOHEAH;
	}

	public void GEOMJEIJAOE()
	{
		CGNMKJJKHPN cGNMKJJKHPN = new CGNMKJJKHPN();
		cGNMKJJKHPN.BJGCPDNMHDH = this;
		cGNMKJJKHPN.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = true;
		JJMPINJACLO(cGNMKJJKHPN.JEGJLALPCKO);
		cGNMKJJKHPN.NIIFMDFKEFC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedBackground : mSmallCompletedBackground);
		cGNMKJJKHPN.OLIBALFJOLP = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedShadow : mSmallCompletedShadow);
		cGNMKJJKHPN.GGFKJOGMFMO = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedCheck : mSmallCompletedCheck);
		cGNMKJJKHPN.HEMFBMIPNGJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		cGNMKJJKHPN.KOBFLIFPLMC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		cGNMKJJKHPN.GLLCCFLPEEI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		cGNMKJJKHPN.DMLCAKMKEAG = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mSoldierUnit : mSmallInProgressIcon);
		cGNMKJJKHPN.DGJCAIJPEIM = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButton : mPlayButton);
		UISprite uISprite = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		UILabel uILabel = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		Vector3 lhs = ((!cGNMKJJKHPN.JEGJLALPCKO) ? FPJHAPAGNPL : NMLPMKPMEME);
		cGNMKJJKHPN.PDGEIGFCIOE = ((!cGNMKJJKHPN.JEGJLALPCKO) ? DJBLFCGIBDJ : LPBHIPKNEDB);
		cGNMKJJKHPN.KAIDDAONLCJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? APALFALEPKE : PMALDLLDDEL);
		cGNMKJJKHPN.HMDBGEANKMI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? HALEHFCOPLF : HEFOLLHHIME);
		if (cGNMKJJKHPN.JEGJLALPCKO)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 450f, 1930f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 967f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(1554f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(1430f)).onFinished = cGNMKJJKHPN.CHOIECFFEMH;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 632f, 653f).onFinished = cGNMKJJKHPN.BLNOPKPLONB;
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.EquipWeapon, 276f);
		TweenAlpha.Begin(uISprite.gameObject, 1076f, 214f);
		TweenAlpha.Begin(uILabel.gameObject, 1553f, 52f);
		TweenPosition.Begin(cGNMKJJKHPN.DGJCAIJPEIM, 187f, cGNMKJJKHPN.DGJCAIJPEIM.transform.localPosition.AddY(174f), useLocal: false).onFinished = cGNMKJJKHPN.MEJDMEIPEJB;
		TweenAlpha.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 361f, 211f);
		TweenScale.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 1266f, lhs.MultiplyXY(1858f)).onFinished = cGNMKJJKHPN.BIGNHFCNJLL;
	}

	private void BIHOBCCFOHF(bool ECEOFMAEOGE)
	{
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(605f));
			}
		}
	}

	public void LPEMONCEFDN()
	{
		HGCJHDEMAGG hGCJHDEMAGG = new HGCJHDEMAGG();
		hGCJHDEMAGG.BJGCPDNMHDH = this;
		hGCJHDEMAGG.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		AKNCBNKDMJG(hGCJHDEMAGG.JEGJLALPCKO);
		mButtonCollider.enabled = true;
		hGCJHDEMAGG.HEMFBMIPNGJ = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		hGCJHDEMAGG.KOBFLIFPLMC = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		hGCJHDEMAGG.DGJCAIJPEIM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButton : mPlayButton);
		hGCJHDEMAGG.NAPCLCBHAMF = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		hGCJHDEMAGG.GMBJHOCENGD = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		hGCJHDEMAGG.PCDOMENGMOM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigLockedBackground : mSmallLockedBackground);
		hGCJHDEMAGG.GLLCCFLPEEI = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		hGCJHDEMAGG.MINMIPHDFGB = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PBMIFNFGFAK : GAFFLMFFJDM);
		hGCJHDEMAGG.FLCDKJIJHLL = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PMFFDLACKBB : OHGPKEMPEAB);
		TweenAlpha.Begin(hGCJHDEMAGG.HEMFBMIPNGJ.gameObject, 880f, 1418f).onFinished = hGCJHDEMAGG.COALBLGIDHF;
	}

	public void JCEMKGHAHNE(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Small) ? 1069f : 1250f);
		float num2 = CEHFMMJHCKC - num / 76f;
		float num3 = CEHFMMJHCKC - num + 1459f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			float num4 = 209f * (float)i;
			mProgressArrows[i].gameObject.SetActive(num4 <= num3);
		}
		AEOLAPGCIFL(1614f, KAKIMEJCEFA: true);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPEGOCGNOAH));
	}

	public void InitControls(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Small) ? 182f : 114f);
		float num2 = CEHFMMJHCKC - num / 2f;
		float num3 = CEHFMMJHCKC - num + 74f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num4 = 74f * (float)i;
			mProgressArrows[i].gameObject.SetActive(num4 <= num3);
		}
		CEAPNHFPKHM(0f, KAKIMEJCEFA: true);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BBGOMIGEBKN));
	}

	private void LCINGKNHEKL()
	{
		mPlayButton.SetActive(value: true);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 764f, 289f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1901f, 1680f);
		TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 1724f, 1635f);
		TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 1278f, 784f);
		TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 1867f, 897f);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 487f, 1204f);
		TweenAlpha.Begin(mSmallLockedLock.gameObject, 212f, 297f);
		TweenScale.Begin(mSmallLockedLock.gameObject, 776f, IJADNCEAFAB);
		TweenPosition.Begin(mPlayButton, 1149f, mPlayButton.transform.localPosition.ReplaceY(1197f));
		TweenAlpha.Begin(mSmallLockedBackground.gameObject, 1955f, 239f);
		TweenAlpha.Begin(mSmallLockedShadow.gameObject, 1947f, 1000f);
		TweenScale.Begin(mSmallLockedBackground.gameObject, 333f, GAFFLMFFJDM);
		TweenScale.Begin(mSmallInProgressBackground.gameObject, 1141f, OHGPKEMPEAB);
		TweenScale.Begin(mSmallInProgressIcon.gameObject, 162f, NMLPMKPMEME);
		TweenPosition.Begin(mSmallInProgressBackground.gameObject, 1981f, LPBHIPKNEDB, useLocal: false);
		TweenPosition.Begin(mNumber.gameObject, 14f, MHIAJFBLHEC, useLocal: false);
		TweenPosition.Begin(mSmallCompletedBackground.gameObject, 836f, PMALDLLDDEL, useLocal: false);
		TweenScale.Begin(mSmallCompletedCheck.gameObject, 1187f, HEFOLLHHIME);
		TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 55f, 179f);
		TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1191f, 1762f);
		TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 1501f, 1607f);
		mBigButton.SetActive(value: true);
		TweenAlpha.Begin(mBigButtonBackground.gameObject, 329f, 1106f);
		TweenAlpha.Begin(mBigButtonLabel.gameObject, 698f, 172f);
		TweenAlpha.Begin(mBigInProgressGlow.gameObject, 1169f, 723f);
		TweenAlpha.Begin(mBigInProgressBackground.gameObject, 752f, 354f);
		TweenAlpha.Begin(mBigInProgressShadow.gameObject, 1941f, 744f);
		TweenPosition.Begin(mBigButton, 1593f, mBigButton.transform.localPosition.ReplaceY(1106f), useLocal: false);
		TweenAlpha.Begin(mBigLockedBackground.gameObject, 212f, 325f);
		TweenScale.Begin(mBigLockedBackground.gameObject, 1334f, PBMIFNFGFAK);
		TweenScale.Begin(mBigInProgressBackground.gameObject, 1577f, PMFFDLACKBB);
		TweenPosition.Begin(mBigInProgressBackground.gameObject, 234f, DJBLFCGIBDJ);
		TweenScale.Begin(mSoldierUnit.gameObject, 488f, FPJHAPAGNPL);
		TweenAlpha.Begin(mSoldierUnit.gameObject, 1961f, 134f);
		TweenPosition.Begin(mBigCompletedBackground.gameObject, 1671f, APALFALEPKE);
		TweenScale.Begin(mBigCompletedCheck.gameObject, 1537f, HALEHFCOPLF);
		TweenAlpha.Begin(mBigCompletedCheck.gameObject, 1790f, 1788f);
		TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1031f, 1043f);
		TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1574f, 23f);
		mRewardsObject.SetActive(value: false);
		TweenAlpha.Begin(mDoneProgress.gameObject, 1255f, 1097f);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 362f, 1133f);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 1652f, 787f);
		TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 8f, 1807f);
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 585f, 1747f);
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 980f, 1525f);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 223f, 702f);
	}

	public void JMDGHEGIPPE(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		EOCLEFCDFFD();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = GIAFDDAKALM || DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("UIReflectionEffect reference missing for index ") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 1284f, 343f, 80);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(flag && ECEOFMAEOGE);
		mSmallInProgress.SetActive(flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mSmallLocked.SetActive(!flag || ECEOFMAEOGE || GIAFDDAKALM);
		mBigCompleted.SetActive(flag || ECEOFMAEOGE);
		mBigInProgress.SetActive(flag || ECEOFMAEOGE || GIAFDDAKALM);
		mBigLocked.SetActive(!flag && !ECEOFMAEOGE && !GIAFDDAKALM);
		MissionUnit bossUnit = BMLABFOAMLC.config.bossUnit;
		AJDKHDKANLJ(bossUnit, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			OMDKHLFMFBA();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 1304f;
		CEAPNHFPKHM(1530f, KAKIMEJCEFA: true);
		BIHOBCCFOHF(ECEOFMAEOGE);
	}

	private void NCLHOHNKMOJ()
	{
		if (LALJLMACNJO && mSpeed > 1753f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			NGPPHKCIHKJ(num / mSpeed, KAKIMEJCEFA: true);
		}
	}

	private void OMDKHLFMFBA()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(1636f, 1029f, 1243f);
		TweenScale tweenScale = TweenScale.Begin(go, 1768f, vector, vector.MultiplyXY(518f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 634f, 1631f, 702f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Once;
	}

	private void CFLALBENGJN()
	{
		if (LALJLMACNJO && mSpeed > 65f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			FAHLAMGLIAN(num / mSpeed);
		}
	}

	private void NLBGECENFGA()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(1520f, 1332f, 1623f);
		TweenScale tweenScale = TweenScale.Begin(go, 333f, vector, vector.MultiplyXY(1287f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 1952f, 1292f, 171f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void LCBBILLHHPI()
	{
		if (LALJLMACNJO && mSpeed > 1102f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			MOHLJECKJAH(num / mSpeed);
		}
	}

	private void LBJPGANFAEJ(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1186f, 856f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1312f, mGoldRewardIcon.transform.localPosition.ReplaceY(1155f));
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 329f, 1993f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 1058f, mGoldRewardAmount.transform.localPosition.ReplaceY(907f));
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void GNCBHHGEAIP()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(744f, 1425f, 383f);
		TweenScale tweenScale = TweenScale.Begin(go, 1984f, vector, vector.MultiplyXY(618f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 1178f, 1048f, 1115f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void OHJBMHCJHJM(UITweener HGPPOFHPJBM)
	{
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 842f, mGoldRewardIcon.transform.localPosition.ReplaceY(1875f));
	}

	public void NMADELLJEPP(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Big) ? 1535f : 1541f);
		float num2 = CEHFMMJHCKC - num / 542f;
		float num3 = CEHFMMJHCKC - num + 1272f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num4 = 1465f * (float)i;
			mProgressArrows[i].gameObject.SetActive(!(num4 <= num3));
		}
		OJMCOEGNJBA(942f);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LOEMDKMKKMF));
	}

	private void GDNOFDFLECO(UITweener HGPPOFHPJBM)
	{
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1042f, mGoldRewardIcon.transform.localPosition.ReplaceY(376f), useLocal: false);
	}

	private void Update()
	{
		if (LALJLMACNJO && mSpeed > 0f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			CEAPNHFPKHM(num / mSpeed);
		}
	}

	private void CBNMPJODLMN(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			mSmallInProgress.SetActive(value: true);
			mSmallLocked.SetActive(value: false);
			TweenAlpha.Begin(mSmallAnimationSprite.gameObject, 256f, 1398f, 1495f);
			TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 602f, 927f);
			TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 270f, 603f);
			TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 1694f, 1909f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 472f, 1404f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 1972f, 1923f);
		}
		else
		{
			mBigInProgress.SetActive(value: true);
			mBigLocked.SetActive(value: true);
			TweenAlpha.Begin(mBigAnimationSprite.gameObject, 967f, 1714f, 1904f);
			TweenAlpha.Begin(mBigInProgressGlow.gameObject, 1865f, 1479f);
			TweenAlpha.Begin(mBigInProgressBackground.gameObject, 304f, 541f);
			TweenAlpha.Begin(mBigInProgressShadow.gameObject, 128f, 1409f);
			TweenAlpha.Begin(mBigButtonBackground.gameObject, 670f, 1752f);
			TweenAlpha.Begin(mBigButtonLabel.gameObject, 687f, 1083f);
		}
		mProgressPart.SetActive(value: false);
		LALJLMACNJO = true;
		ADCCFCDFNGI(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 308f, 398f);
	}

	private void PPANKBGJMPI(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 123f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 684f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 90f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(1393f - num / 310f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(952f - num2 / 1006f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(275f - num3 / 553f);
			mXPRewardObject.repositionNow = false;
			mWarbucksRewardObject.repositionNow = false;
			mGoldRewardObject.repositionNow = false;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: false);
			mSmallInProgress.SetActive(value: false);
			mSmallCompleted.SetActive(value: false);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1631f, 318f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1156f, 1524f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 1545f, 1335f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: true);
			mBigInProgress.SetActive(value: false);
			mBigCompleted.SetActive(value: false);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 846f, 1018f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 491f, 951f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 1702f, 92f);
		}
		mProgressPart.SetActive(value: false);
		mDoneProgress.gameObject.SetActive(value: false);
		LALJLMACNJO = false;
		TweenAlpha.Begin(mDoneProgress.gameObject, 1897f, 1411f);
		MIBIBOCHICG(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	private void DLILHIEGELJ(UITweener HGPPOFHPJBM)
	{
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1621f, mGoldRewardIcon.transform.localPosition.ReplaceY(9f));
	}

	private void CEAPNHFPKHM(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 0f)
		{
			PAENPHMEMGC = 1f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 74f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 74f * (-1f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	private void CKIDBCKCKID(UITweener HGPPOFHPJBM)
	{
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 141f, mGoldRewardIcon.transform.localPosition.ReplaceY(1591f));
	}

	private void CMCAKPMPCHN(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 688f, 19f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1960f, mGoldRewardIcon.transform.localPosition.ReplaceY(544f));
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 946f, 1830f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 780f, mGoldRewardAmount.transform.localPosition.ReplaceY(884f), useLocal: false);
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void OJMCOEGNJBA(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1881f)
		{
			PAENPHMEMGC = 863f;
		}
		for (int i = 0; i < mProgressArrows.Length; i++)
		{
			float num = 1943f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 1902f * (1365f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	public void MOMBFJHPDKE()
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 262f, 1385f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1860f, mGoldRewardIcon.transform.localPosition.ReplaceY(1493f), mGoldRewardIcon.transform.localPosition.ReplaceY(40f), useLocal: false).onFinished = GDNOFDFLECO;
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 525f, 1395f).onFinished = JEIHGKOHEAH;
	}

	private void JILJKEBJBOD(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 796f, 896f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 200f, mGoldRewardIcon.transform.localPosition.ReplaceY(1794f), useLocal: false);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 943f, 1930f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 1092f, mGoldRewardAmount.transform.localPosition.ReplaceY(75f), useLocal: false);
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	private void AKNCBNKDMJG(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			mSmallInProgress.SetActive(value: false);
			mSmallLocked.SetActive(value: true);
			TweenAlpha.Begin(mSmallAnimationSprite.gameObject, 1175f, 496f, 1421f);
			TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 335f, 1775f);
			TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 603f, 758f);
			TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 223f, 1729f);
			TweenAlpha.Begin(mPlayButtonBackground.gameObject, 1210f, 336f);
			TweenAlpha.Begin(mPlayButtonLabel.gameObject, 928f, 1389f);
		}
		else
		{
			mBigInProgress.SetActive(value: false);
			mBigLocked.SetActive(value: false);
			TweenAlpha.Begin(mBigAnimationSprite.gameObject, 923f, 1118f, 99f);
			TweenAlpha.Begin(mBigInProgressGlow.gameObject, 164f, 1371f);
			TweenAlpha.Begin(mBigInProgressBackground.gameObject, 1047f, 305f);
			TweenAlpha.Begin(mBigInProgressShadow.gameObject, 312f, 1224f);
			TweenAlpha.Begin(mBigButtonBackground.gameObject, 1040f, 1963f);
			TweenAlpha.Begin(mBigButtonLabel.gameObject, 541f, 1436f);
		}
		mProgressPart.SetActive(value: false);
		LALJLMACNJO = false;
		MIBIBOCHICG(ECEOFMAEOGE: true);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 1414f, 557f);
	}

	private void LOMAFKIMCDC(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.XP)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: true);
			float num = 20f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 20f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 20f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(-10f - num / 2f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(-10f - num2 / 2f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(-10f - num3 / 2f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = true;
			mGoldRewardObject.repositionNow = true;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: false);
			mSmallInProgress.SetActive(value: true);
			mSmallCompleted.SetActive(value: true);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 0f, 0f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 0f, 0f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 0f, 0f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: false);
			mBigInProgress.SetActive(value: true);
			mBigCompleted.SetActive(value: true);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 0f, 0f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 0f, 0f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 0f, 0f);
		}
		mProgressPart.SetActive(value: true);
		mDoneProgress.gameObject.SetActive(value: true);
		LALJLMACNJO = false;
		TweenAlpha.Begin(mDoneProgress.gameObject, 0f, 0f);
		ADCCFCDFNGI(ECEOFMAEOGE: false);
		mNumber.color = Color.black;
	}

	public void HCAOABHNLID(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Small) ? 1590f : 1774f);
		float num2 = CEHFMMJHCKC - num / 529f;
		float num3 = CEHFMMJHCKC - num + 1708f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			float num4 = 1819f * (float)i;
			mProgressArrows[i].gameObject.SetActive(num4 <= num3);
		}
		OJMCOEGNJBA(870f);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LOEMDKMKKMF));
	}

	private void BOEMHLPLOGA()
	{
		if (LALJLMACNJO && mSpeed > 1467f)
		{
			PHEADDEDEMG += Time.deltaTime;
			float num = PHEADDEDEMG % mSpeed;
			BCAACBPAAGH(num / mSpeed, KAKIMEJCEFA: true);
		}
	}

	public void EPFKCOHPCAK(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		EOCLEFCDFFD();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = !GIAFDDAKALM && DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("S") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 1081f, 537f, 66);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(!flag || ECEOFMAEOGE);
		mSmallInProgress.SetActive(flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mSmallLocked.SetActive(flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mBigCompleted.SetActive(flag || ECEOFMAEOGE);
		mBigInProgress.SetActive(!flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mBigLocked.SetActive(!flag && !ECEOFMAEOGE && !GIAFDDAKALM);
		MissionUnit hNPJBOOPFKO = BMLABFOAMLC.config.MPICOIBCOHE();
		CJADGACNBJL(hNPJBOOPFKO, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			NGGOIGHIJKM();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 1966f;
		NGPPHKCIHKJ(839f, KAKIMEJCEFA: true);
		ADCCFCDFNGI(ECEOFMAEOGE);
	}

	private void GKHOFGLGIMM(bool ECEOFMAEOGE)
	{
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			if (mProgressArrows[i].gameObject.activeSelf)
			{
				mProgressArrows[i].color = ((!ECEOFMAEOGE) ? Color.white : Color.black.ReplaceA(912f));
			}
		}
	}

	private void HDDGNJKPCHO(UITweener BCDIEGIGGLI)
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1427f, 890f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 1784f, mGoldRewardIcon.transform.localPosition.ReplaceY(10f));
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 197f, 25f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 11f, mGoldRewardAmount.transform.localPosition.ReplaceY(1217f));
		GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
	}

	public void BDDPEFHJAGA()
	{
		CGNMKJJKHPN cGNMKJJKHPN = new CGNMKJJKHPN();
		cGNMKJJKHPN.BJGCPDNMHDH = this;
		cGNMKJJKHPN.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		mButtonCollider.enabled = false;
		PDJGLHBCPCD(cGNMKJJKHPN.JEGJLALPCKO);
		cGNMKJJKHPN.NIIFMDFKEFC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedBackground : mSmallCompletedBackground);
		cGNMKJJKHPN.OLIBALFJOLP = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedShadow : mSmallCompletedShadow);
		cGNMKJJKHPN.GGFKJOGMFMO = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigCompletedCheck : mSmallCompletedCheck);
		cGNMKJJKHPN.HEMFBMIPNGJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		cGNMKJJKHPN.KOBFLIFPLMC = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		cGNMKJJKHPN.GLLCCFLPEEI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		cGNMKJJKHPN.DMLCAKMKEAG = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mSoldierUnit : mSmallInProgressIcon);
		cGNMKJJKHPN.DGJCAIJPEIM = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButton : mPlayButton);
		UISprite uISprite = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		UILabel uILabel = ((!cGNMKJJKHPN.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		Vector3 lhs = ((!cGNMKJJKHPN.JEGJLALPCKO) ? FPJHAPAGNPL : NMLPMKPMEME);
		cGNMKJJKHPN.PDGEIGFCIOE = ((!cGNMKJJKHPN.JEGJLALPCKO) ? DJBLFCGIBDJ : LPBHIPKNEDB);
		cGNMKJJKHPN.KAIDDAONLCJ = ((!cGNMKJJKHPN.JEGJLALPCKO) ? APALFALEPKE : PMALDLLDDEL);
		cGNMKJJKHPN.HMDBGEANKMI = ((!cGNMKJJKHPN.JEGJLALPCKO) ? HALEHFCOPLF : HEFOLLHHIME);
		if (cGNMKJJKHPN.JEGJLALPCKO)
		{
			TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 1336f, 1631f);
			TweenPosition.Begin(mWarbucksRewardIcon.gameObject, 716f, mWarbucksRewardIcon.transform.localPosition.ReplaceY(736f), mWarbucksRewardIcon.transform.localPosition.ReplaceY(158f)).onFinished = cGNMKJJKHPN.HPJCBDDALHB;
			TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 63f, 645f).onFinished = cGNMKJJKHPN.BLNOPKPLONB;
		}
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-36), 974f);
		TweenAlpha.Begin(uISprite.gameObject, 336f, 822f);
		TweenAlpha.Begin(uILabel.gameObject, 1583f, 1529f);
		TweenPosition.Begin(cGNMKJJKHPN.DGJCAIJPEIM, 95f, cGNMKJJKHPN.DGJCAIJPEIM.transform.localPosition.AddY(1515f), useLocal: false).onFinished = cGNMKJJKHPN.BCMKCAHLNBG;
		TweenAlpha.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 1641f, 31f);
		TweenScale.Begin(cGNMKJJKHPN.DMLCAKMKEAG.gameObject, 595f, lhs.MultiplyXY(995f)).onFinished = cGNMKJJKHPN.DDCIHGFIFNE;
	}

	private void BCAACBPAAGH(float PAENPHMEMGC, bool KAKIMEJCEFA = false)
	{
		PAENPHMEMGC = Mathf.Clamp01(PAENPHMEMGC);
		if (PAENPHMEMGC == 1359f)
		{
			PAENPHMEMGC = 1482f;
		}
		for (int i = 1; i < mProgressArrows.Length; i += 0)
		{
			float num = 67f * (float)i;
			if (KAKIMEJCEFA || mProgressArrows[i].gameObject.activeSelf)
			{
				float num2 = 991f * (685f + PAENPHMEMGC);
				float val = Mathf.Clamp(num + num2, mMinX, JKBBIKLCPNG);
				mProgressArrows[i].transform.localPosition = mProgressArrows[i].transform.localPosition.ReplaceX(val);
			}
		}
	}

	public void ENJJKEBMDOA()
	{
		HGCJHDEMAGG hGCJHDEMAGG = new HGCJHDEMAGG();
		hGCJHDEMAGG.BJGCPDNMHDH = this;
		hGCJHDEMAGG.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		KDPGNDKHDMH(hGCJHDEMAGG.JEGJLALPCKO);
		mButtonCollider.enabled = true;
		hGCJHDEMAGG.HEMFBMIPNGJ = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		hGCJHDEMAGG.KOBFLIFPLMC = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		hGCJHDEMAGG.DGJCAIJPEIM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButton : mPlayButton);
		hGCJHDEMAGG.NAPCLCBHAMF = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		hGCJHDEMAGG.GMBJHOCENGD = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		hGCJHDEMAGG.PCDOMENGMOM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigLockedBackground : mSmallLockedBackground);
		hGCJHDEMAGG.GLLCCFLPEEI = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		hGCJHDEMAGG.MINMIPHDFGB = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PBMIFNFGFAK : GAFFLMFFJDM);
		hGCJHDEMAGG.FLCDKJIJHLL = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PMFFDLACKBB : OHGPKEMPEAB);
		TweenAlpha.Begin(hGCJHDEMAGG.HEMFBMIPNGJ.gameObject, 548f, 9f).onFinished = hGCJHDEMAGG.NDJOJHNIBFC;
	}

	private void PALCJJBEMLK()
	{
		mPlayButton.SetActive(value: true);
		TweenAlpha.Begin(mPlayButtonBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mPlayButtonLabel.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallInProgressGlow.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallInProgressBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallInProgressShadow.gameObject, 0f, 0.25f);
		TweenAlpha.Begin(mSmallInProgressIcon.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallLockedLock.gameObject, 0f, 1f);
		TweenScale.Begin(mSmallLockedLock.gameObject, 0f, IJADNCEAFAB);
		TweenPosition.Begin(mPlayButton, 0f, mPlayButton.transform.localPosition.ReplaceY(124f));
		TweenAlpha.Begin(mSmallLockedBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallLockedShadow.gameObject, 0f, 0.25f);
		TweenScale.Begin(mSmallLockedBackground.gameObject, 0f, GAFFLMFFJDM);
		TweenScale.Begin(mSmallInProgressBackground.gameObject, 0f, OHGPKEMPEAB);
		TweenScale.Begin(mSmallInProgressIcon.gameObject, 0f, NMLPMKPMEME);
		TweenPosition.Begin(mSmallInProgressBackground.gameObject, 0f, LPBHIPKNEDB);
		TweenPosition.Begin(mNumber.gameObject, 0f, MHIAJFBLHEC);
		TweenPosition.Begin(mSmallCompletedBackground.gameObject, 0f, PMALDLLDDEL);
		TweenScale.Begin(mSmallCompletedCheck.gameObject, 0f, HEFOLLHHIME);
		TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 0f, 0.25f);
		mBigButton.SetActive(value: true);
		TweenAlpha.Begin(mBigButtonBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mBigButtonLabel.gameObject, 0f, 1f);
		TweenAlpha.Begin(mBigInProgressGlow.gameObject, 0f, 1f);
		TweenAlpha.Begin(mBigInProgressBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mBigInProgressShadow.gameObject, 0f, 0.25f);
		TweenPosition.Begin(mBigButton, 0f, mBigButton.transform.localPosition.ReplaceY(181f));
		TweenAlpha.Begin(mBigLockedBackground.gameObject, 0f, 1f);
		TweenScale.Begin(mBigLockedBackground.gameObject, 0f, PBMIFNFGFAK);
		TweenScale.Begin(mBigInProgressBackground.gameObject, 0f, PMFFDLACKBB);
		TweenPosition.Begin(mBigInProgressBackground.gameObject, 0f, DJBLFCGIBDJ);
		TweenScale.Begin(mSoldierUnit.gameObject, 0f, FPJHAPAGNPL);
		TweenAlpha.Begin(mSoldierUnit.gameObject, 0f, 1f);
		TweenPosition.Begin(mBigCompletedBackground.gameObject, 0f, APALFALEPKE);
		TweenScale.Begin(mBigCompletedCheck.gameObject, 0f, HALEHFCOPLF);
		TweenAlpha.Begin(mBigCompletedCheck.gameObject, 0f, 1f);
		TweenAlpha.Begin(mBigCompletedBackground.gameObject, 0f, 1f);
		TweenAlpha.Begin(mBigCompletedShadow.gameObject, 0f, 0.25f);
		mRewardsObject.SetActive(value: false);
		TweenAlpha.Begin(mDoneProgress.gameObject, 0f, 1f);
		TweenAlpha.Begin(mXPRewardLabel.gameObject, 0f, 0f);
		TweenAlpha.Begin(mXPRewardPoints.gameObject, 0f, 0f);
		TweenAlpha.Begin(mWarbucksRewardIcon.gameObject, 0f, 0f);
		TweenAlpha.Begin(mWarbucksRewardAmount.gameObject, 0f, 0f);
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0f, 0f);
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0f, 0f);
	}

	[CompilerGenerated]
	private void ENAABEIEOMM(UITweener HPBPMJALCND)
	{
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 1f);
		TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f), mGoldRewardAmount.transform.localPosition.ReplaceY(0f)).onFinished = delegate
		{
			TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.1f, mGoldRewardAmount.transform.localPosition.ReplaceY(-20f)).onFinished = delegate
			{
				TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.3f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(mGoldRewardIcon.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mGoldRewardIcon.gameObject, 0.2f, mGoldRewardIcon.transform.localPosition.ReplaceY(-40f));
					TweenAlpha.Begin(mGoldRewardAmount.gameObject, 0.2f, 0f);
					TweenPosition.Begin(mGoldRewardAmount.gameObject, 0.2f, mGoldRewardAmount.transform.localPosition.ReplaceY(-40f));
					GuiScreenSingle<HeroicScreen>.instance.EndHeroicMissionAnimation();
				};
			};
		};
	}

	public void PPDBCMENFLC()
	{
		TweenAlpha.Begin(mGoldRewardIcon.gameObject, 1609f, 626f);
		TweenPosition.Begin(mGoldRewardIcon.gameObject, 54f, mGoldRewardIcon.transform.localPosition.ReplaceY(1636f), mGoldRewardIcon.transform.localPosition.ReplaceY(341f)).onFinished = DLILHIEGELJ;
		TweenAlpha.Begin(mGoldRewardAmount.gameObject, 363f, 1794f).onFinished = JEIHGKOHEAH;
	}

	private void PDJGLHBCPCD(bool JEGJLALPCKO)
	{
		if (JEGJLALPCKO)
		{
			foreach (CDACJEGCGLB reward in ANEFJJFFOHM.rewards)
			{
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mXPRewardPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
				{
					mWarbucksRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
				if (reward.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
				{
					mGoldRewardAmount.text = MEJMLNDFDBP.GMIPFLIEOHD(reward.IEALLELGOBM);
				}
			}
			mRewardsObject.SetActive(value: false);
			float num = 956f + (mXPRewardLabel.relativeSize.x + mXPRewardPoints.relativeSize.x) * mXPRewardLabel.transform.localScale.x;
			float num2 = 921f + mWarbucksRewardIcon.transform.localScale.x + mWarbucksRewardAmount.relativeSize.x * mWarbucksRewardAmount.transform.localScale.x;
			float num3 = 716f + mGoldRewardIcon.transform.localScale.x + mGoldRewardAmount.relativeSize.x * mGoldRewardAmount.transform.localScale.x;
			mXPRewardObject.transform.localPosition = mXPRewardObject.transform.localPosition.ReplaceX(156f - num / 1890f);
			mWarbucksRewardObject.transform.localPosition = mWarbucksRewardObject.transform.localPosition.ReplaceX(751f - num2 / 625f);
			mGoldRewardObject.transform.localPosition = mGoldRewardObject.transform.localPosition.ReplaceX(1376f - num3 / 1505f);
			mXPRewardObject.repositionNow = true;
			mWarbucksRewardObject.repositionNow = false;
			mGoldRewardObject.repositionNow = true;
		}
		if (JEGJLALPCKO)
		{
			mSmallAnimationObject.SetActive(value: false);
			mSmallInProgress.SetActive(value: true);
			mSmallCompleted.SetActive(value: true);
			TweenAlpha.Begin(mSmallCompletedBackground.gameObject, 1954f, 1281f);
			TweenAlpha.Begin(mSmallCompletedCheck.gameObject, 1824f, 482f);
			TweenAlpha.Begin(mSmallCompletedShadow.gameObject, 401f, 1140f);
		}
		else
		{
			mBigAnimationObject.SetActive(value: true);
			mBigInProgress.SetActive(value: false);
			mBigCompleted.SetActive(value: true);
			TweenAlpha.Begin(mBigCompletedBackground.gameObject, 1055f, 1496f);
			TweenAlpha.Begin(mBigCompletedCheck.gameObject, 860f, 394f);
			TweenAlpha.Begin(mBigCompletedShadow.gameObject, 746f, 1528f);
		}
		mProgressPart.SetActive(value: true);
		mDoneProgress.gameObject.SetActive(value: true);
		LALJLMACNJO = true;
		TweenAlpha.Begin(mDoneProgress.gameObject, 159f, 1166f);
		PHIFEAOLPFM(ECEOFMAEOGE: true);
		mNumber.color = Color.black;
	}

	public void KEGBAJKOONK(DailyMission BMLABFOAMLC, bool GIAFDDAKALM, bool ECEOFMAEOGE)
	{
		PALCJJBEMLK();
		ANEFJJFFOHM = BMLABFOAMLC;
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		mButtonCollider.enabled = !GIAFDDAKALM && DebugSettings.debugEnabled;
		mNumber.text = ((!flag) ? Localization.Localize("PauseGameRPC") : MEJMLNDFDBP.GMIPFLIEOHD(ANEFJJFFOHM.number));
		MEJMLNDFDBP.COCBCFKJOJE(mNumber, 212f, 978f, 71);
		mNumber.color = ((!ECEOFMAEOGE) ? Color.black : Color.white);
		mSmallCompleted.SetActive(flag && ECEOFMAEOGE);
		mSmallInProgress.SetActive(!flag || ECEOFMAEOGE || GIAFDDAKALM);
		mSmallLocked.SetActive(flag && !ECEOFMAEOGE && GIAFDDAKALM);
		mBigCompleted.SetActive(flag || ECEOFMAEOGE);
		mBigInProgress.SetActive(flag || ECEOFMAEOGE || GIAFDDAKALM);
		mBigLocked.SetActive(flag || ECEOFMAEOGE || GIAFDDAKALM);
		MissionUnit hNPJBOOPFKO = BMLABFOAMLC.config.CIDHFKPFJAK();
		InitializeBossUnit(hNPJBOOPFKO, ECEOFMAEOGE);
		if (GIAFDDAKALM)
		{
			DOINHAEFDNB();
		}
		mDoneProgress.gameObject.SetActive(ECEOFMAEOGE);
		mProgressPart.SetActive(GIAFDDAKALM || ECEOFMAEOGE);
		LALJLMACNJO = GIAFDDAKALM;
		PHEADDEDEMG = 968f;
		NGNFFOLFEAJ(529f, KAKIMEJCEFA: true);
		GKHOFGLGIMM(ECEOFMAEOGE);
	}

	private void HAIKKLJNDBL()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(1935f, 1777f, 141f);
		TweenScale tweenScale = TweenScale.Begin(go, 751f, vector, vector.MultiplyXY(1840f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 691f, 739f, 1473f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void BBGOMIGEBKN(GameObject KHAHPAKDIKE)
	{
		if (ANEFJJFFOHM != null)
		{
			GuiElementSingle<DailyMissionDialog>.instance.ShowDialog(ANEFJJFFOHM);
			DailyMissionsManager.instance.currentMission = ANEFJJFFOHM;
		}
	}

	public void PLAOCDOMCPP(float CEHFMMJHCKC)
	{
		IJADNCEAFAB = mSmallLockedLock.transform.localScale;
		OHGPKEMPEAB = mSmallInProgressBackground.transform.localScale;
		GAFFLMFFJDM = mSmallLockedBackground.transform.localScale;
		NMLPMKPMEME = mSmallInProgressIcon.transform.localScale;
		LPBHIPKNEDB = mSmallInProgressBackground.transform.localPosition;
		MHIAJFBLHEC = mNumber.transform.localPosition;
		PMALDLLDDEL = mSmallCompletedBackground.transform.localPosition;
		HEFOLLHHIME = mSmallCompletedCheck.transform.localScale;
		PMFFDLACKBB = mBigInProgressBackground.transform.localScale;
		PBMIFNFGFAK = mBigLockedBackground.transform.localScale;
		DJBLFCGIBDJ = mBigInProgressBackground.transform.localPosition;
		APALFALEPKE = mBigCompletedBackground.transform.localPosition;
		HALEHFCOPLF = mBigCompletedCheck.transform.localScale;
		float num = ((mCurrentType != NKHJBLBAAEB.Small) ? 992f : 511f);
		float num2 = CEHFMMJHCKC - num / 829f;
		float num3 = CEHFMMJHCKC - num + 311f;
		JKBBIKLCPNG = num2;
		mButtonCollider.transform.localPosition = mButtonCollider.transform.localPosition.ReplaceX(num2);
		mDoneProgress.transform.localScale = mDoneProgress.transform.localScale.ReplaceX(num2);
		for (int i = 0; i < mProgressArrows.Length; i += 0)
		{
			float num4 = 1410f * (float)i;
			mProgressArrows[i].gameObject.SetActive(!(num4 <= num3));
		}
		CEAPNHFPKHM(517f);
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPEGOCGNOAH));
	}

	private void AAIELFEIACG()
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		GameObject go = ((!flag) ? mBigAnimationObject : mSmallAnimationObject);
		UISprite uISprite = ((!flag) ? mBigAnimationSprite : mSmallAnimationSprite);
		Vector3 vector = new Vector3(725f, 1721f, 969f);
		TweenScale tweenScale = TweenScale.Begin(go, 970f, vector, vector.MultiplyXY(1703f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 12f, 1045f, 1444f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.style = UITweener.Style.Once;
	}

	public void IHLBOMHLLFH(MissionUnit HNPJBOOPFKO, bool GNNHPMOBMPP)
	{
		bool flag = mCurrentType == NKHJBLBAAEB.Big;
		bool flag2 = HNPJBOOPFKO?.isVeteran ?? true;
		bool flag3 = HNPJBOOPFKO?.isElite ?? true;
		mSoldierUnit.gameObject.SetActive(!flag && !GNNHPMOBMPP);
		if (!flag && (flag2 || flag3))
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
			mSoldierUnit.spriteName = ((!flag3) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mSoldierUnit.MakePixelPerfect();
			float b = 25f / mSoldierUnit.transform.localScale.y;
			mSoldierUnit.transform.localScale = mSoldierUnit.transform.localScale.MultiplyXY(Mathf.Min(848f, b));
			FPJHAPAGNPL = mSoldierUnit.transform.localScale;
		}
	}

	public void EBNFKCPEAMM()
	{
		HGCJHDEMAGG hGCJHDEMAGG = new HGCJHDEMAGG();
		hGCJHDEMAGG.BJGCPDNMHDH = this;
		hGCJHDEMAGG.JEGJLALPCKO = mCurrentType == NKHJBLBAAEB.Small;
		AKNCBNKDMJG(hGCJHDEMAGG.JEGJLALPCKO);
		mButtonCollider.enabled = true;
		hGCJHDEMAGG.HEMFBMIPNGJ = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressGlow : mSmallInProgressGlow);
		hGCJHDEMAGG.KOBFLIFPLMC = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressBackground : mSmallInProgressBackground);
		hGCJHDEMAGG.DGJCAIJPEIM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButton : mPlayButton);
		hGCJHDEMAGG.NAPCLCBHAMF = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonBackground : mPlayButtonBackground);
		hGCJHDEMAGG.GMBJHOCENGD = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigButtonLabel : mPlayButtonLabel);
		hGCJHDEMAGG.PCDOMENGMOM = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigLockedBackground : mSmallLockedBackground);
		hGCJHDEMAGG.GLLCCFLPEEI = ((!hGCJHDEMAGG.JEGJLALPCKO) ? mBigInProgressShadow : mSmallInProgressShadow);
		hGCJHDEMAGG.MINMIPHDFGB = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PBMIFNFGFAK : GAFFLMFFJDM);
		hGCJHDEMAGG.FLCDKJIJHLL = ((!hGCJHDEMAGG.JEGJLALPCKO) ? PMFFDLACKBB : OHGPKEMPEAB);
		TweenAlpha.Begin(hGCJHDEMAGG.HEMFBMIPNGJ.gameObject, 746f, 29f).onFinished = hGCJHDEMAGG.NCLMPCCHDAM;
	}
}
