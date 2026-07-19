using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpInfo : Core_BaseScript
{
	[Header("-Core")]
	public UISprite MBMIOELEAND;

	public UISprite PAENPHMEMGC;

	public UISprite[] ONHKJPKDMEM;

	public UILabel FKLKLCBOMNE;

	private TweenAnimator FNOMCHPCOHB;

	private Vector3 HANDNIONGDE = new Vector3(400f, 68f, 1f);

	private Vector3 CCIPBABILMN = new Vector3(570f, 97f, 1f);

	private Vector3 LCONNCBHIII = new Vector3(320f, 54f, 1f);

	private Vector3 KOPBDKAHHCD = new Vector3(6f, -3f, -1f);

	private Vector3 EMPGGKHAKCI = new Vector3(6f, 10f, -1f);

	private Vector3 GBDLEDCFEIJ = new Vector3(6f, -31f, -1f);

	private NHOGNBCNIEK NDJAJPKKOAF = new NHOGNBCNIEK(0f);

	private NHOGNBCNIEK PGIKIBBAGGA = new NHOGNBCNIEK(0f);

	private NHOGNBCNIEK GFKLCFENKAO = new NHOGNBCNIEK(0f);

	private Vector3 IDAEFMLAGJE;

	private Vector3 DKPDKEHJENN;

	private Vector3 KKBPDHHCKAD;

	private Vector3 FIBLFOFDDMJ;

	public void AFOEKDOBLAL(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1339f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 326f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1684f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1889f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 697f);
	}

	public void CEJCIDGDEEO()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		BMBGIHAELID();
	}

	public void FDJAGPPFBAI()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		BMBGIHAELID();
	}

	public void OPJPLCLCGIM(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[1].delay = Mathf.Clamp(EMICAEBMJPD, 645f, 1139f);
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	public void JEHIMAHNCCJ(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1303f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 179f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1230f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 385f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 1692f);
	}

	public void GCFAPIEMIKG(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.JEEKNFJCAMJ();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 513f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 706f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[1].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 1419f;
		PAENPHMEMGC.alpha = 1777f;
		FKLKLCBOMNE.alpha = 546f;
		ONHKJPKDMEM[0].alpha = 1310f;
		ONHKJPKDMEM[0].alpha = 1274f;
	}

	public void AABJOFLJLHC(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 332f, 41f);
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	public void EMIKJEPACOO(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1491f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 309f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1312f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1053f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 111f);
	}

	private void IAHLCGOPCCL(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical, 1764f);
		}
	}

	private void KLOJBCMKAHJ()
	{
		ONHKJPKDMEM[0].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[0].transform.localScale;
		DKPDKEHJENN = (0.5f * IDAEFMLAGJE).ReplaceZ(1f);
		KKBPDHHCKAD = (2f * IDAEFMLAGJE).ReplaceZ(1f);
		FIBLFOFDDMJ = (3f * IDAEFMLAGJE).ReplaceZ(1f);
	}

	private void FMNHGPLDNAG(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 1887f);
		}
	}

	public void InitGuiValues(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.FinishTweens();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 0.1f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 0f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[1].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 0f;
		PAENPHMEMGC.alpha = 0f;
		FKLKLCBOMNE.alpha = 0f;
		ONHKJPKDMEM[0].alpha = 0f;
		ONHKJPKDMEM[1].alpha = 0f;
	}

	private void AIJOPBFOEDK(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 925f);
		}
	}

	public void JCEMKGHAHNE()
	{
		JLCOILDFHKK();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		HKOLCILDFDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(KHPKDAHHCLG));
	}

	public void LACHGBAIGBI()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		CJLIAPIKAAF();
	}

	public void HDELAHBDFMP()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		OPPFBBMGCPP();
	}

	public void HFPPNCJBIDK()
	{
		JCFHBKJOPPK();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		AJEDFPCMCCK();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(NNGMPOBOOLB));
	}

	private void HAILIAAHHDH(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade);
		}
	}

	public void KHDBHMNGHDC(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.PHCCOHJPLKE();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 834f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 1974f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[0].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 1877f;
		PAENPHMEMGC.alpha = 1989f;
		FKLKLCBOMNE.alpha = 1676f;
		ONHKJPKDMEM[1].alpha = 1754f;
		ONHKJPKDMEM[0].alpha = 645f;
	}

	private void OLAAEGAOBEH()
	{
		float num = 977f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, 1105f, 446f, 1204f, -1, 1091f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, num * 1797f, LCONNCBHIII, 1390f, 1, CCIPBABILMN, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 240f, HANDNIONGDE, 404f, 0, LCONNCBHIII, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 1527f, 434f, 1372f, 1, 287f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 1219f, 1380f, num * 272f, 0, 1317f, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 50f, 1272f, num * 863f, 61, 1965f, (UITweener.Method)6);
		FNOMCHPCOHB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1855f, EMPGGKHAKCI, num * 650f, 1, GBDLEDCFEIJ, UITweener.Method.EaseIn);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1649f, KOPBDKAHHCD, 1880f, 1, EMPGGKHAKCI, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, FKLKLCBOMNE.gameObject, num * 1121f, 760f, 439f, 0, 1175f);
		FNOMCHPCOHB.NFLKPCIHOPJ(-89, (TweenAnimator.MNAIKKJDPLK)(-16), PAENPHMEMGC.gameObject, num * 1047f, GFKLCFENKAO, num * 1762f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-110, (TweenAnimator.MNAIKKJDPLK)119, PAENPHMEMGC.gameObject, num * 1091f, PGIKIBBAGGA, 1521f, -6, GFKLCFENKAO, (UITweener.Method)6);
		FNOMCHPCOHB.MNEFMODDFFK(-27, TweenAnimator.MNAIKKJDPLK.Rotation, PAENPHMEMGC.gameObject, num * 1782f, 423f, num * 1249f, 1, 892f, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-86, TweenAnimator.MNAIKKJDPLK.Rotation, PAENPHMEMGC.gameObject, num * 1337f, 449f, 1024f, 30, 505f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-112, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[0].gameObject, num * 1956f, KKBPDHHCKAD, num * 1085f, 0, DKPDKEHJENN, (UITweener.Method)8);
		FNOMCHPCOHB.MNEFMODDFFK(66, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[1].gameObject, num * 1588f, IDAEFMLAGJE, 1350f, -46, KKBPDHHCKAD, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(-113, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 1596f, 1243f, num * 1267f, 1, 1208f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-8, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ONHKJPKDMEM[0].gameObject, num * 1996f, FIBLFOFDDMJ, num * 686f, 0, IDAEFMLAGJE, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(99, TweenAnimator.MNAIKKJDPLK.Rotation, ONHKJPKDMEM[1].gameObject, num * 961f, 1590f, num * 98f, 0, 736f, UITweener.Method.Linear);
		FNOMCHPCOHB.BPEKAKFKCIG(104, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 599f, 1579f, num * 922f, 22, 743f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.JIPFOMFJNPC();
	}

	public void GNLNAAMAABI(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 960f, 348f);
		FNOMCHPCOHB.PlayTweens();
	}

	private void PMKJGLCBBNH()
	{
		float num = 1112f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, 1715f, 64f, 506f, -1, 1053f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 477f, LCONNCBHIII, 1082f, 1, CCIPBABILMN, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 1577f, HANDNIONGDE, 948f, 0, LCONNCBHIII, UITweener.Method.EaseIn);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.Color, MBMIOELEAND.gameObject, num * 1329f, 1863f, 1970f, 0, 1938f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 1859f, 821f, num * 1345f, 0, 1463f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 133f, 1423f, num * 841f, -7, 1486f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1398f, EMPGGKHAKCI, num * 1898f, 0, GBDLEDCFEIJ, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(3, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 1042f, KOPBDKAHHCD, 1468f, 1, EMPGGKHAKCI, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Alpha, FKLKLCBOMNE.gameObject, num * 480f, 630f, 1462f, 0, 645f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(51, (TweenAnimator.MNAIKKJDPLK)55, PAENPHMEMGC.gameObject, num * 886f, GFKLCFENKAO, num * 1487f, 0, NDJAJPKKOAF, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(15, (TweenAnimator.MNAIKKJDPLK)(-121), PAENPHMEMGC.gameObject, num * 138f, PGIKIBBAGGA, 1137f, 6, GFKLCFENKAO, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-61, TweenAnimator.MNAIKKJDPLK.Position, PAENPHMEMGC.gameObject, num * 845f, 562f, num * 896f, 1, 144f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(54, TweenAnimator.MNAIKKJDPLK.Position, PAENPHMEMGC.gameObject, num * 852f, 1071f, 557f, -46, 775f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-118, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[1].gameObject, num * 732f, KKBPDHHCKAD, num * 940f, 0, DKPDKEHJENN, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(70, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 1086f, IDAEFMLAGJE, 1405f, -53, KKBPDHHCKAD, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-119, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[0].gameObject, num * 1969f, 1144f, num * 1562f, 0, 495f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.BPEKAKFKCIG(92, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[1].gameObject, num * 1580f, FIBLFOFDDMJ, num * 656f, 1, IDAEFMLAGJE, UITweener.Method.EaseIn);
		FNOMCHPCOHB.MNEFMODDFFK(124, TweenAnimator.MNAIKKJDPLK.Rotation, ONHKJPKDMEM[0].gameObject, num * 1937f, 135f, num * 785f, 1, 1459f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(-121, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 1796f, 617f, num * 1405f, -98, 259f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.OOFBCPPFMPN();
	}

	private void IEFMDCNIKDD()
	{
		ONHKJPKDMEM[0].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[0].transform.localScale;
		DKPDKEHJENN = (1712f * IDAEFMLAGJE).ReplaceZ(1135f);
		KKBPDHHCKAD = (1964f * IDAEFMLAGJE).ReplaceZ(1610f);
		FIBLFOFDDMJ = (804f * IDAEFMLAGJE).ReplaceZ(843f);
	}

	public void HKCBDFNIHOJ(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 880f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 829f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 357f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 1390f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1857f);
	}

	public void NKMIAOPINPK()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		OLAAEGAOBEH();
	}

	private void KHPKDAHHCLG(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 547f);
		}
	}

	public void KCBOEBLDBMO()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		BMBGIHAELID();
	}

	public void MKLGFNBIDIE(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.CPKDFIKMKLE();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 862f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 1308f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[1].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 694f;
		PAENPHMEMGC.alpha = 696f;
		FKLKLCBOMNE.alpha = 1663f;
		ONHKJPKDMEM[1].alpha = 1975f;
		ONHKJPKDMEM[1].alpha = 345f;
	}

	public void AAJLGPIGDED()
	{
		JCFHBKJOPPK();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		CJLIAPIKAAF();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(DFGNEOCIJGO));
	}

	public void HFIEBHKAOEK(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.HLKNEKNIENJ();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 1319f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 480f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[1].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 736f;
		PAENPHMEMGC.alpha = 1131f;
		FKLKLCBOMNE.alpha = 1160f;
		ONHKJPKDMEM[1].alpha = 1652f;
		ONHKJPKDMEM[0].alpha = 1268f;
	}

	public void OELMHGDPMAL()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		MBDKJIGMIFA();
	}

	public void JPEEPGLCOMO(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1682f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 1143f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 996f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1885f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 216f);
	}

	private void DANLHCIMBDG(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 646f);
		}
	}

	public void JAIAMFJHDLP()
	{
		FFBHMNPMFLD();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		INMLEPJEILD();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(HFALHNPGEAJ));
	}

	private void KPAMNBEGLPA(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade, 1391f);
		}
	}

	private void NNGMPOBOOLB(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 1153f);
		}
	}

	private void NDNLIHEHEOD()
	{
		ONHKJPKDMEM[1].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[0].transform.localScale;
		DKPDKEHJENN = (1394f * IDAEFMLAGJE).ReplaceZ(1600f);
		KKBPDHHCKAD = (1463f * IDAEFMLAGJE).ReplaceZ(697f);
		FIBLFOFDDMJ = (1874f * IDAEFMLAGJE).ReplaceZ(1074f);
	}

	public void EIICBIBONNK(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.LILKFFOOHMC();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 1084f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 877f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[0].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 1729f;
		PAENPHMEMGC.alpha = 248f;
		FKLKLCBOMNE.alpha = 1027f;
		ONHKJPKDMEM[0].alpha = 422f;
		ONHKJPKDMEM[1].alpha = 815f;
	}

	private void HKOLCILDFDP()
	{
		float num = 1498f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, 98f, 1447f, 1001f, -1, 830f, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 79f, LCONNCBHIII, 1454f, 0, CCIPBABILMN, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 142f, HANDNIONGDE, 1203f, 1, LCONNCBHIII, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 160f, 697f, 729f, 1, 129f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 28f, 1773f, num * 986f, 0, 1075f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 63f, 1888f, num * 12f, 55, 486f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 253f, EMPGGKHAKCI, num * 387f, 0, GBDLEDCFEIJ, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 1407f, KOPBDKAHHCD, 634f, 7, EMPGGKHAKCI, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Scale, FKLKLCBOMNE.gameObject, num * 1175f, 708f, 716f, 0, 815f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.FEHALDPLGDB(-77, (TweenAnimator.MNAIKKJDPLK)98, PAENPHMEMGC.gameObject, num * 1887f, GFKLCFENKAO, num * 1011f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(83, (TweenAnimator.MNAIKKJDPLK)71, PAENPHMEMGC.gameObject, num * 1472f, PGIKIBBAGGA, 130f, 111, GFKLCFENKAO, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-94, TweenAnimator.MNAIKKJDPLK.Scale, PAENPHMEMGC.gameObject, num * 1597f, 1437f, num * 710f, 1, 1695f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(-39, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PAENPHMEMGC.gameObject, num * 1884f, 531f, 569f, 85, 735f, UITweener.Method.BounceOut);
		FNOMCHPCOHB.AddTween(-30, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ONHKJPKDMEM[0].gameObject, num * 1313f, KKBPDHHCKAD, num * 364f, 0, DKPDKEHJENN, UITweener.Method.EaseIn);
		FNOMCHPCOHB.MNEFMODDFFK(-52, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 1678f, IDAEFMLAGJE, 2f, -119, KKBPDHHCKAD, UITweener.Method.BounceOut);
		FNOMCHPCOHB.BPEKAKFKCIG(-65, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[1].gameObject, num * 634f, 765f, num * 204f, 0, 1469f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.MNEFMODDFFK(-8, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[1].gameObject, num * 1279f, FIBLFOFDDMJ, num * 1899f, 0, IDAEFMLAGJE, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(46, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ONHKJPKDMEM[1].gameObject, num * 33f, 448f, num * 292f, 1, 64f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(12, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[0].gameObject, num * 60f, 1307f, num * 1860f, 47, 1266f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.PGGAAGLGKAL();
	}

	private void HAKDIBMCDKF()
	{
		float num = 1739f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, 1399f, 902f, 1154f, -1, 1718f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 94f, LCONNCBHIII, 1906f, 0, CCIPBABILMN, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 841f, HANDNIONGDE, 342f, 0, LCONNCBHIII, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 980f, 737f, 1290f, 0, 1732f, UITweener.Method.Linear);
		FNOMCHPCOHB.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 1513f, 1265f, num * 1525f, 1, 468f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MBMIOELEAND.gameObject, num * 463f, 1380f, num * 1139f, 42, 1687f, (UITweener.Method)8);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 500f, EMPGGKHAKCI, num * 1616f, 1, GBDLEDCFEIJ, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1469f, KOPBDKAHHCD, 123f, 3, EMPGGKHAKCI, UITweener.Method.Linear);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Alpha, FKLKLCBOMNE.gameObject, num * 387f, 1510f, 655f, 0, 744f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(41, (TweenAnimator.MNAIKKJDPLK)46, PAENPHMEMGC.gameObject, num * 993f, GFKLCFENKAO, num * 1545f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(104, (TweenAnimator.MNAIKKJDPLK)36, PAENPHMEMGC.gameObject, num * 1294f, PGIKIBBAGGA, 1304f, -76, GFKLCFENKAO, (UITweener.Method)7);
		FNOMCHPCOHB.AddTween(74, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PAENPHMEMGC.gameObject, num * 1610f, 164f, num * 954f, 1, 109f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-22, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PAENPHMEMGC.gameObject, num * 621f, 1622f, 1674f, 84, 1799f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.FEHALDPLGDB(64, TweenAnimator.MNAIKKJDPLK.Rotation, ONHKJPKDMEM[1].gameObject, num * 308f, KKBPDHHCKAD, num * 540f, 0, DKPDKEHJENN, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-42, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 1505f, IDAEFMLAGJE, 331f, 121, KKBPDHHCKAD, UITweener.Method.Linear);
		FNOMCHPCOHB.BPEKAKFKCIG(28, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ONHKJPKDMEM[1].gameObject, num * 535f, 1096f, num * 1522f, 0, 7f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-86, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[1].gameObject, num * 976f, FIBLFOFDDMJ, num * 315f, 1, IDAEFMLAGJE, (UITweener.Method)6);
		FNOMCHPCOHB.FEHALDPLGDB(-101, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[1].gameObject, num * 461f, 1015f, num * 344f, 0, 300f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(85, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[0].gameObject, num * 1712f, 117f, num * 883f, 101, 1384f, UITweener.Method.Linear);
		FNOMCHPCOHB.NCKIJBBJAOG();
	}

	private void NAAFPEBFDCA(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 801f);
		}
	}

	public void FMONHIFFJEF(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1401f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 1123f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1566f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 1238f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 800f);
	}

	private void AJEDFPCMCCK()
	{
		float num = 1023f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, 616f, 181f, 947f, -1, 1455f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 1181f, LCONNCBHIII, 1799f, 0, CCIPBABILMN, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 646f, HANDNIONGDE, 1829f, 0, LCONNCBHIII, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 1167f, 1610f, 803f, 0, 192f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 1772f, 476f, num * 1292f, 1, 1364f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 177f, 979f, num * 947f, 57, 1449f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1200f, EMPGGKHAKCI, num * 470f, 0, GBDLEDCFEIJ, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 591f, KOPBDKAHHCD, 701f, 5, EMPGGKHAKCI, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Alpha, FKLKLCBOMNE.gameObject, num * 881f, 1198f, 379f, 1, 1925f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(29, (TweenAnimator.MNAIKKJDPLK)(-39), PAENPHMEMGC.gameObject, num * 784f, GFKLCFENKAO, num * 1582f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(15, (TweenAnimator.MNAIKKJDPLK)53, PAENPHMEMGC.gameObject, num * 1101f, PGIKIBBAGGA, 431f, -11, GFKLCFENKAO, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(76, TweenAnimator.MNAIKKJDPLK.TextCounter, PAENPHMEMGC.gameObject, num * 538f, 1155f, num * 1534f, 0, 146f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-33, TweenAnimator.MNAIKKJDPLK.Alpha, PAENPHMEMGC.gameObject, num * 1001f, 1186f, 896f, -104, 1352f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-109, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[0].gameObject, num * 375f, KKBPDHHCKAD, num * 1103f, 1, DKPDKEHJENN);
		FNOMCHPCOHB.AddTween(40, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 979f, IDAEFMLAGJE, 1625f, -73, KKBPDHHCKAD);
		FNOMCHPCOHB.NFLKPCIHOPJ(89, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 1377f, 1464f, num * 914f, 0, 1496f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(55, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ONHKJPKDMEM[0].gameObject, num * 6f, FIBLFOFDDMJ, num * 305f, 1, IDAEFMLAGJE, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-36, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[0].gameObject, num * 499f, 647f, num * 1185f, 1, 1372f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(51, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[0].gameObject, num * 1090f, 682f, num * 958f, 82, 1826f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.GenerateTweens();
	}

	public void FNLELBKLNBG()
	{
		NDNLIHEHEOD();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		LKEFCFNAENP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(FCNNCIOPBAO));
	}

	public void IHACJBJDIJD()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		BMBGIHAELID();
	}

	private void NKHKBFKGNAM()
	{
		ONHKJPKDMEM[1].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[0].transform.localScale;
		DKPDKEHJENN = (1552f * IDAEFMLAGJE).ReplaceZ(1021f);
		KKBPDHHCKAD = (1437f * IDAEFMLAGJE).ReplaceZ(1540f);
		FIBLFOFDDMJ = (1664f * IDAEFMLAGJE).ReplaceZ(1542f);
	}

	public void IAKNDCDEIHM()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		BMBGIHAELID();
	}

	private void OKELBKFFGFI(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade, 1278f);
		}
	}

	public void IDDLDDBKJJK(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.FinishTweens();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 720f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 813f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[1].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 873f;
		PAENPHMEMGC.alpha = 1140f;
		FKLKLCBOMNE.alpha = 1204f;
		ONHKJPKDMEM[1].alpha = 1714f;
		ONHKJPKDMEM[0].alpha = 1902f;
	}

	public void GJDACDMNOGD(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 265f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 210f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 549f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 807f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 1475f);
	}

	public void DHNILCPGLLI()
	{
		IEFMDCNIKDD();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		MBDKJIGMIFA();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(DFAKNLJMKCO));
	}

	private void JEIHKMEJCCM()
	{
		float num = 436f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, 821f, 1071f, 135f, -1, 300f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 11f, LCONNCBHIII, 1509f, 0, CCIPBABILMN, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 696f, HANDNIONGDE, 960f, 0, LCONNCBHIII, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 230f, 123f, 633f, 1, 837f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 1129f, 1285f, num * 420f, 1, 1877f, (UITweener.Method)8);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 580f, 1636f, num * 1771f, -18, 1200f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1077f, EMPGGKHAKCI, num * 987f, 0, GBDLEDCFEIJ, UITweener.Method.EaseIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 1976f, KOPBDKAHHCD, 184f, 4, EMPGGKHAKCI, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Color, FKLKLCBOMNE.gameObject, num * 463f, 1831f, 1760f, 1, 1404f, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-32, (TweenAnimator.MNAIKKJDPLK)31, PAENPHMEMGC.gameObject, num * 111f, GFKLCFENKAO, num * 1609f, 0, NDJAJPKKOAF, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-115, (TweenAnimator.MNAIKKJDPLK)120, PAENPHMEMGC.gameObject, num * 317f, PGIKIBBAGGA, 280f, -68, GFKLCFENKAO, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(46, TweenAnimator.MNAIKKJDPLK.Color, PAENPHMEMGC.gameObject, num * 1662f, 1477f, num * 964f, 0, 1431f, (UITweener.Method)7);
		FNOMCHPCOHB.NFLKPCIHOPJ(-71, TweenAnimator.MNAIKKJDPLK.Alpha, PAENPHMEMGC.gameObject, num * 442f, 1409f, 808f, 23, 879f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(48, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 939f, KKBPDHHCKAD, num * 821f, 0, DKPDKEHJENN, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(-24, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[0].gameObject, num * 1723f, IDAEFMLAGJE, 1803f, 55, KKBPDHHCKAD, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(41, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ONHKJPKDMEM[0].gameObject, num * 39f, 901f, num * 1964f, 1, 624f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-118, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 1068f, FIBLFOFDDMJ, num * 738f, 1, IDAEFMLAGJE, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(-123, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[1].gameObject, num * 637f, 317f, num * 537f, 1, 407f, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(-105, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ONHKJPKDMEM[1].gameObject, num * 955f, 628f, num * 1500f, -97, 1855f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.KHAFPAMIOAF();
	}

	public void OFPPHLADEGD(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 287f, 782f);
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	private void BMBGIHAELID()
	{
		float num = 141f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, 536f, 214f, 1055f, -1, 140f, (UITweener.Method)8);
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, num * 1027f, LCONNCBHIII, 986f, 0, CCIPBABILMN, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 894f, HANDNIONGDE, 435f, 1, LCONNCBHIII, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 1089f, 1123f, 1089f, 1, 120f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, num * 1533f, 1655f, num * 1460f, 1, 134f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 1452f, 1246f, num * 870f, 40, 362f, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 1267f, EMPGGKHAKCI, num * 1238f, 0, GBDLEDCFEIJ, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 781f, KOPBDKAHHCD, 225f, 8, EMPGGKHAKCI, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Color, FKLKLCBOMNE.gameObject, num * 1525f, 1574f, 73f, 1, 1756f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-108, (TweenAnimator.MNAIKKJDPLK)108, PAENPHMEMGC.gameObject, num * 389f, GFKLCFENKAO, num * 1991f, 0, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-104, (TweenAnimator.MNAIKKJDPLK)(-116), PAENPHMEMGC.gameObject, num * 1237f, PGIKIBBAGGA, 1192f, -88, GFKLCFENKAO, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(35, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PAENPHMEMGC.gameObject, num * 476f, 144f, num * 360f, 1, 1285f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(66, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PAENPHMEMGC.gameObject, num * 1897f, 542f, 1623f, -5, 1043f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-91, TweenAnimator.MNAIKKJDPLK.Rotation, ONHKJPKDMEM[1].gameObject, num * 1401f, KKBPDHHCKAD, num * 947f, 0, DKPDKEHJENN, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(-125, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[1].gameObject, num * 412f, IDAEFMLAGJE, 1563f, 116, KKBPDHHCKAD, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(20, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 1750f, 132f, num * 1656f, 1, 1504f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[1].gameObject, num * 262f, FIBLFOFDDMJ, num * 1744f, 1, IDAEFMLAGJE, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-99, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 1867f, 920f, num * 1966f, 1, 1769f, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(-113, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[0].gameObject, num * 1490f, 821f, num * 1919f, 21, 1f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.KHAFPAMIOAF();
	}

	private void MBDKJIGMIFA()
	{
		float num = 771f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, 209f, 1025f, 1835f, -1, 902f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, num * 273f, LCONNCBHIII, 464f, 1, CCIPBABILMN, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.Color, MBMIOELEAND.gameObject, num * 1767f, HANDNIONGDE, 1835f, 0, LCONNCBHIII, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MBMIOELEAND.gameObject, num * 1018f, 959f, 475f, 1, 1179f, UITweener.Method.Linear);
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 428f, 1415f, num * 1551f, 1, 117f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 453f, 244f, num * 1433f, 86, 276f, (UITweener.Method)6);
		FNOMCHPCOHB.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1267f, EMPGGKHAKCI, num * 1702f, 1, GBDLEDCFEIJ, UITweener.Method.Linear);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 966f, KOPBDKAHHCD, 481f, 3, EMPGGKHAKCI, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, FKLKLCBOMNE.gameObject, num * 1402f, 88f, 1558f, 1, 334f, (UITweener.Method)7);
		FNOMCHPCOHB.AddTween(-80, (TweenAnimator.MNAIKKJDPLK)40, PAENPHMEMGC.gameObject, num * 1182f, GFKLCFENKAO, num * 1586f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-83, (TweenAnimator.MNAIKKJDPLK)73, PAENPHMEMGC.gameObject, num * 1281f, PGIKIBBAGGA, 1472f, 106, GFKLCFENKAO, (UITweener.Method)7);
		FNOMCHPCOHB.NFLKPCIHOPJ(-79, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PAENPHMEMGC.gameObject, num * 852f, 1956f, num * 1922f, 0, 1534f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-96, TweenAnimator.MNAIKKJDPLK.TextCounter, PAENPHMEMGC.gameObject, num * 63f, 1868f, 500f, 15, 1344f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(113, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ONHKJPKDMEM[0].gameObject, num * 1440f, KKBPDHHCKAD, num * 92f, 1, DKPDKEHJENN, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(-42, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 793f, IDAEFMLAGJE, 597f, -4, KKBPDHHCKAD, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-41, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[1].gameObject, num * 984f, 1979f, num * 1971f, 1, 1469f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.BPEKAKFKCIG(-104, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[0].gameObject, num * 1909f, FIBLFOFDDMJ, num * 1777f, 0, IDAEFMLAGJE, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-3, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 692f, 1573f, num * 35f, 0, 1273f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 712f, 1412f, num * 1729f, 87, 749f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.IGBJIEBMEBF();
	}

	public void AKDLHCLHGJM(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 573f, 1457f);
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	private void LKEFCFNAENP()
	{
		float num = 13f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, 52f, 555f, 67f, -1, 920f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 184f, LCONNCBHIII, 1952f, 1, CCIPBABILMN, UITweener.Method.EaseIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 1973f, HANDNIONGDE, 707f, 0, LCONNCBHIII, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, num * 235f, 1462f, 1613f, 0, 1169f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MBMIOELEAND.gameObject, num * 1803f, 1210f, num * 1440f, 0, 532f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 173f, 297f, num * 1386f, -63, 1890f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 215f, EMPGGKHAKCI, num * 66f, 0, GBDLEDCFEIJ, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 1356f, KOPBDKAHHCD, 1769f, 2, EMPGGKHAKCI, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(4, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FKLKLCBOMNE.gameObject, num * 1947f, 1461f, 817f, 1, 1416f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(80, (TweenAnimator.MNAIKKJDPLK)(-107), PAENPHMEMGC.gameObject, num * 605f, GFKLCFENKAO, num * 340f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(17, (TweenAnimator.MNAIKKJDPLK)56, PAENPHMEMGC.gameObject, num * 1169f, PGIKIBBAGGA, 900f, 50, GFKLCFENKAO, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-69, TweenAnimator.MNAIKKJDPLK.Position, PAENPHMEMGC.gameObject, num * 1939f, 305f, num * 1995f, 1, 1661f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.FEHALDPLGDB(-72, TweenAnimator.MNAIKKJDPLK.TextCounter, PAENPHMEMGC.gameObject, num * 1733f, 1291f, 785f, -105, 933f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-57, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[0].gameObject, num * 774f, KKBPDHHCKAD, num * 1302f, 0, DKPDKEHJENN, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(58, TweenAnimator.MNAIKKJDPLK.Rotation, ONHKJPKDMEM[1].gameObject, num * 578f, IDAEFMLAGJE, 1096f, -10, KKBPDHHCKAD, UITweener.Method.Linear);
		FNOMCHPCOHB.MNEFMODDFFK(123, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[1].gameObject, num * 1189f, 237f, num * 1215f, 0, 681f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-38, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[1].gameObject, num * 1391f, FIBLFOFDDMJ, num * 1656f, 0, IDAEFMLAGJE, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(49, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[0].gameObject, num * 317f, 667f, num * 1438f, 0, 1251f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-115, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[0].gameObject, num * 1276f, 1398f, num * 381f, -42, 468f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.KHAFPAMIOAF();
	}

	public void IBNHJGLOHAE()
	{
		NDNLIHEHEOD();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		BMBGIHAELID();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(JNJIJCEPBMN));
	}

	public void NNJPGBKBGHF()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		KCBHBEBEKFB();
	}

	public void IDIBNMLJDIK(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.CJGJOAKNIIL();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 978f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 639f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[0].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 1003f;
		PAENPHMEMGC.alpha = 1162f;
		FKLKLCBOMNE.alpha = 1640f;
		ONHKJPKDMEM[1].alpha = 1387f;
		ONHKJPKDMEM[1].alpha = 974f;
	}

	public void EFINNDNBJDN()
	{
		DJKINANKKKH();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KCBHBEBEKFB();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(NNGMPOBOOLB));
	}

	public void EKGAFMDBHFC(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[1].delay = Mathf.Clamp(EMICAEBMJPD, 1897f, 170f);
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	public void HKJCCMPAJDG(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1386f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 325f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 6f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 762f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 1397f);
	}

	private void INMLEPJEILD()
	{
		float num = 202f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, 867f, 1832f, 1125f, -1, 298f, (UITweener.Method)6);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 1268f, LCONNCBHIII, 1359f, 1, CCIPBABILMN, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, num * 1490f, HANDNIONGDE, 1440f, 1, LCONNCBHIII, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 1474f, 735f, 1072f, 1, 266f, UITweener.Method.Linear);
		FNOMCHPCOHB.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MBMIOELEAND.gameObject, num * 634f, 775f, num * 1068f, 0, 1989f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 500f, 17f, num * 78f, 48, 1983f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 801f, EMPGGKHAKCI, num * 767f, 1, GBDLEDCFEIJ, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 51f, KOPBDKAHHCD, 1979f, 3, EMPGGKHAKCI, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(2, TweenAnimator.MNAIKKJDPLK.TextCounter, FKLKLCBOMNE.gameObject, num * 958f, 109f, 1457f, 1, 188f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.BPEKAKFKCIG(-78, (TweenAnimator.MNAIKKJDPLK)(-38), PAENPHMEMGC.gameObject, num * 1046f, GFKLCFENKAO, num * 515f, 1, NDJAJPKKOAF, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(1, (TweenAnimator.MNAIKKJDPLK)58, PAENPHMEMGC.gameObject, num * 898f, PGIKIBBAGGA, 141f, 85, GFKLCFENKAO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-86, TweenAnimator.MNAIKKJDPLK.Rotation, PAENPHMEMGC.gameObject, num * 1354f, 1696f, num * 1197f, 1, 1839f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.MNEFMODDFFK(-57, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, PAENPHMEMGC.gameObject, num * 1053f, 250f, 430f, -95, 1753f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(-109, TweenAnimator.MNAIKKJDPLK.Position, ONHKJPKDMEM[1].gameObject, num * 1440f, KKBPDHHCKAD, num * 1649f, 0, DKPDKEHJENN, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-43, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[0].gameObject, num * 1120f, IDAEFMLAGJE, 181f, 21, KKBPDHHCKAD, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(30, TweenAnimator.MNAIKKJDPLK.Position, ONHKJPKDMEM[0].gameObject, num * 815f, 857f, num * 659f, 0, 240f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-69, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 671f, FIBLFOFDDMJ, num * 1511f, 1, IDAEFMLAGJE, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-61, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[0].gameObject, num * 1912f, 1163f, num * 859f, 0, 1746f, UITweener.Method.Linear);
		FNOMCHPCOHB.NFLKPCIHOPJ(-104, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 424f, 1196f, num * 1558f, 113, 1545f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.NCKIJBBJAOG();
	}

	public void MIPPKOJPMMM(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1348f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 30f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 426f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1356f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 136f);
	}

	public void TutorialHide(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 0f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 0f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 0f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 0f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 0f);
	}

	private void DJKINANKKKH()
	{
		ONHKJPKDMEM[1].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[0].transform.localScale;
		DKPDKEHJENN = (1184f * IDAEFMLAGJE).ReplaceZ(89f);
		KKBPDHHCKAD = (80f * IDAEFMLAGJE).ReplaceZ(1156f);
		FIBLFOFDDMJ = (668f * IDAEFMLAGJE).ReplaceZ(566f);
	}

	public void DMHPPHOOGMD(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[1].delay = Mathf.Clamp(EMICAEBMJPD, 342f, 576f);
		FNOMCHPCOHB.GDCCFEDJFAF();
	}

	private void FFBHMNPMFLD()
	{
		ONHKJPKDMEM[1].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[1].transform.localScale;
		DKPDKEHJENN = (21f * IDAEFMLAGJE).ReplaceZ(1305f);
		KKBPDHHCKAD = (985f * IDAEFMLAGJE).ReplaceZ(1644f);
		FIBLFOFDDMJ = (1492f * IDAEFMLAGJE).ReplaceZ(1814f);
	}

	public void CHIIALCHJEL(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.FinishTweens();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 762f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 1026f;
		ONHKJPKDMEM[1].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[0].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 1062f;
		PAENPHMEMGC.alpha = 1878f;
		FKLKLCBOMNE.alpha = 1828f;
		ONHKJPKDMEM[0].alpha = 1183f;
		ONHKJPKDMEM[1].alpha = 1446f;
	}

	private void PIFBFOKEJBB()
	{
		ONHKJPKDMEM[0].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[1].transform.localScale;
		DKPDKEHJENN = (1293f * IDAEFMLAGJE).ReplaceZ(1270f);
		KKBPDHHCKAD = (1973f * IDAEFMLAGJE).ReplaceZ(1639f);
		FIBLFOFDDMJ = (464f * IDAEFMLAGJE).ReplaceZ(1112f);
	}

	public void AMBDHDEBPJJ()
	{
		NDNLIHEHEOD();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		JEIHKMEJCCM();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(KHPKDAHHCLG));
	}

	public void ADGBOOPDKJN()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		PMKJGLCBBNH();
	}

	public void NJFKLKNFONN(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 641f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 894f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1606f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1575f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1607f);
	}

	public void FJCAOOHMJBO(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.LILKFFOOHMC();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 1225f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 304f;
		ONHKJPKDMEM[1].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[1].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 560f;
		PAENPHMEMGC.alpha = 128f;
		FKLKLCBOMNE.alpha = 1840f;
		ONHKJPKDMEM[0].alpha = 1457f;
		ONHKJPKDMEM[0].alpha = 1486f;
	}

	public void EBONMMHLBCM()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		PMKJGLCBBNH();
	}

	public void CKNGJNFAFPG(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.JEEKNFJCAMJ();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 1285f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 93f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[1].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 336f;
		PAENPHMEMGC.alpha = 706f;
		FKLKLCBOMNE.alpha = 755f;
		ONHKJPKDMEM[1].alpha = 776f;
		ONHKJPKDMEM[1].alpha = 561f;
	}

	private void JNJIJCEPBMN(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade, 1272f);
		}
	}

	public void OJLONNEIBLE()
	{
		JLCOILDFHKK();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		HKOLCILDFDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(FMNHGPLDNAG));
	}

	private void DFGNEOCIJGO(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade, 1569f);
		}
	}

	public void ODLKCAGIKBE()
	{
		DJKINANKKKH();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		AJEDFPCMCCK();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(DFAKNLJMKCO));
	}

	public void KPKONEJJKLO()
	{
		JCFHBKJOPPK();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		BMBGIHAELID();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(NAAFPEBFDCA));
	}

	private void KCBHBEBEKFB()
	{
		float num = 1483f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, 1806f, 1769f, 1816f, -1, 1490f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 308f, LCONNCBHIII, 35f, 0, CCIPBABILMN, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 458f, HANDNIONGDE, 1193f, 1, LCONNCBHIII, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Color, MBMIOELEAND.gameObject, num * 1192f, 1572f, 1160f, 1, 1873f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 664f, 1739f, num * 1333f, 1, 1474f, (UITweener.Method)6);
		FNOMCHPCOHB.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 801f, 435f, num * 1943f, -19, 1802f, UITweener.Method.Linear);
		FNOMCHPCOHB.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1523f, EMPGGKHAKCI, num * 1362f, 0, GBDLEDCFEIJ, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 1080f, KOPBDKAHHCD, 957f, 6, EMPGGKHAKCI, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.TextCounter, FKLKLCBOMNE.gameObject, num * 521f, 1600f, 1391f, 1, 1098f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.BPEKAKFKCIG(45, (TweenAnimator.MNAIKKJDPLK)106, PAENPHMEMGC.gameObject, num * 1038f, GFKLCFENKAO, num * 1733f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(41, (TweenAnimator.MNAIKKJDPLK)(-87), PAENPHMEMGC.gameObject, num * 607f, PGIKIBBAGGA, 1733f, -105, GFKLCFENKAO, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-22, TweenAnimator.MNAIKKJDPLK.Scale, PAENPHMEMGC.gameObject, num * 1731f, 413f, num * 1041f, 0, 45f, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(11, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PAENPHMEMGC.gameObject, num * 1852f, 640f, 1030f, -7, 36f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(125, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[1].gameObject, num * 1072f, KKBPDHHCKAD, num * 127f, 0, DKPDKEHJENN, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(23, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[0].gameObject, num * 98f, IDAEFMLAGJE, 1418f, 120, KKBPDHHCKAD, UITweener.Method.EaseOut);
		FNOMCHPCOHB.FEHALDPLGDB(-6, TweenAnimator.MNAIKKJDPLK.Rotation, ONHKJPKDMEM[1].gameObject, num * 828f, 913f, num * 1597f, 1, 992f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-112, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ONHKJPKDMEM[1].gameObject, num * 1327f, FIBLFOFDDMJ, num * 1001f, 0, IDAEFMLAGJE, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-68, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, ONHKJPKDMEM[1].gameObject, num * 296f, 998f, num * 1091f, 0, 257f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-124, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[1].gameObject, num * 11f, 686f, num * 1700f, -9, 1462f, UITweener.Method.Linear);
		FNOMCHPCOHB.PGGAAGLGKAL();
	}

	private void FCNNCIOPBAO(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 446f);
		}
	}

	public void HKGPHGJKBGD(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 141f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 957f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1649f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1044f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 557f);
	}

	public void NCHPIDDFJKE(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.NDGCGHLLPMC();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 918f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 518f;
		ONHKJPKDMEM[0].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[0].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 226f;
		PAENPHMEMGC.alpha = 1897f;
		FKLKLCBOMNE.alpha = 791f;
		ONHKJPKDMEM[1].alpha = 533f;
		ONHKJPKDMEM[1].alpha = 335f;
	}

	public void FBODCFNPAFP()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		HKOLCILDFDP();
	}

	public void IEOAGCPNBBI(float NCEABGKOIHA)
	{
		FNOMCHPCOHB.KIOKIAFPHPE();
		PGIKIBBAGGA.FKIIDCDCLHM = Mathf.Clamp01(NCEABGKOIHA);
		GFKLCFENKAO.FKIIDCDCLHM = Mathf.Clamp01(PGIKIBBAGGA.FKIIDCDCLHM + 1749f);
		MBMIOELEAND.transform.localScale = CCIPBABILMN;
		FKLKLCBOMNE.transform.localPosition = GBDLEDCFEIJ;
		PAENPHMEMGC.fillAmount = 1448f;
		ONHKJPKDMEM[1].transform.localScale = DKPDKEHJENN;
		ONHKJPKDMEM[0].transform.localScale = IDAEFMLAGJE;
		MBMIOELEAND.alpha = 572f;
		PAENPHMEMGC.alpha = 169f;
		FKLKLCBOMNE.alpha = 1439f;
		ONHKJPKDMEM[1].alpha = 357f;
		ONHKJPKDMEM[0].alpha = 508f;
	}

	public void AIJEMOLBNEC()
	{
		PIFBFOKEJBB();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		PMKJGLCBBNH();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(DFGNEOCIJGO));
	}

	private void HFALHNPGEAJ(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1502f);
		}
	}

	public void GPLDKGIHCEO()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		HAKDIBMCDKF();
	}

	public void GJPIOFKJCPJ(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[1].delay = Mathf.Clamp(EMICAEBMJPD, 341f, 1433f);
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	private void MGDHJGGJCAN()
	{
		ONHKJPKDMEM[1].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[1].transform.localScale;
		DKPDKEHJENN = (966f * IDAEFMLAGJE).ReplaceZ(1608f);
		KKBPDHHCKAD = (517f * IDAEFMLAGJE).ReplaceZ(1394f);
		FIBLFOFDDMJ = (370f * IDAEFMLAGJE).ReplaceZ(1023f);
	}

	public void OGFDGIKEGKE()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		OLAAEGAOBEH();
	}

	public void CDFFMGKMLEA(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 127f, 1044f);
		FNOMCHPCOHB.HMPMBAGNJOJ();
	}

	public void PlayAnimation(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 0f, 10f);
		FNOMCHPCOHB.PlayTweens();
	}

	public void OOBJHJLMEED()
	{
		NKHKBFKGNAM();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KCBHBEBEKFB();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(NJNFHPJCCHL));
	}

	private void CJLIAPIKAAF()
	{
		float num = 511f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Color, MBMIOELEAND.gameObject, 1044f, 897f, 1129f, -1, 72f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 1119f, LCONNCBHIII, 800f, 1, CCIPBABILMN, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 1674f, HANDNIONGDE, 576f, 0, LCONNCBHIII, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 862f, 142f, 749f, 0, 1143f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.Color, MBMIOELEAND.gameObject, num * 1878f, 1773f, num * 1314f, 1, 1025f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.Rotation, MBMIOELEAND.gameObject, num * 1972f, 1032f, num * 588f, -8, 1720f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 831f, EMPGGKHAKCI, num * 1901f, 1, GBDLEDCFEIJ, UITweener.Method.EaseIn);
		FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Rotation, FKLKLCBOMNE.gameObject, num * 982f, KOPBDKAHHCD, 504f, 0, EMPGGKHAKCI, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Color, FKLKLCBOMNE.gameObject, num * 22f, 730f, 855f, 0, 1446f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(87, (TweenAnimator.MNAIKKJDPLK)(-5), PAENPHMEMGC.gameObject, num * 1055f, GFKLCFENKAO, num * 1518f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-127, (TweenAnimator.MNAIKKJDPLK)68, PAENPHMEMGC.gameObject, num * 670f, PGIKIBBAGGA, 649f, 99, GFKLCFENKAO, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-53, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PAENPHMEMGC.gameObject, num * 1617f, 877f, num * 939f, 1, 1540f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-92, TweenAnimator.MNAIKKJDPLK.Alpha, PAENPHMEMGC.gameObject, num * 289f, 1895f, 124f, 118, 1888f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(120, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[0].gameObject, num * 648f, KKBPDHHCKAD, num * 1912f, 0, DKPDKEHJENN, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-127, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 1469f, IDAEFMLAGJE, 96f, -70, KKBPDHHCKAD, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(-55, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, ONHKJPKDMEM[1].gameObject, num * 1504f, 956f, num * 1772f, 1, 1250f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(-77, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 1184f, FIBLFOFDDMJ, num * 1190f, 1, IDAEFMLAGJE, UITweener.Method.EaseOut);
		FNOMCHPCOHB.MNEFMODDFFK(-74, TweenAnimator.MNAIKKJDPLK.Color, ONHKJPKDMEM[0].gameObject, num * 1943f, 1314f, num * 1504f, 1, 783f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(-17, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 1925f, 162f, num * 970f, 35, 278f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.OOFBCPPFMPN();
	}

	public void LAMGPLAJLEJ(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 1101f, 1939f);
		FNOMCHPCOHB.ODIJFGCDJNH();
	}

	public void LBDELDJPHCM(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 90f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 692f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1891f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 1208f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1965f);
	}

	private void JNEKFECJEJJ(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 190f);
		}
	}

	private void IEEHMDEAJIJ()
	{
		ONHKJPKDMEM[0].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[0].transform.localScale;
		DKPDKEHJENN = (1653f * IDAEFMLAGJE).ReplaceZ(889f);
		KKBPDHHCKAD = (1175f * IDAEFMLAGJE).ReplaceZ(1218f);
		FIBLFOFDDMJ = (1451f * IDAEFMLAGJE).ReplaceZ(40f);
	}

	public void LPDHJHAEFOA()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		AJEDFPCMCCK();
	}

	private void DFAKNLJMKCO(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade, 371f);
		}
	}

	public void IGDBMAKMDNE(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1329f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 1670f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1730f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 278f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 1739f);
	}

	private void OOAGNEIMOCK(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade, 617f);
		}
	}

	public void HCKHBEGMBMO(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 633f);
		TweenAlpha.Begin(FKLKLCBOMNE.gameObject, KBJEOEEOEFG, 1957f);
		TweenAlpha.Begin(PAENPHMEMGC.gameObject, KBJEOEEOEFG, 1517f);
		TweenAlpha.Begin(ONHKJPKDMEM[1].gameObject, KBJEOEEOEFG, 1015f);
		TweenAlpha.Begin(ONHKJPKDMEM[0].gameObject, KBJEOEEOEFG, 102f);
	}

	public void DebugRecreateAnimations()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		OPPFBBMGCPP();
	}

	public void PEIILMKDGBK()
	{
		IEEHMDEAJIJ();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KCBHBEBEKFB();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(JNEKFECJEJJ));
	}

	private void JLCOILDFHKK()
	{
		ONHKJPKDMEM[1].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[1].transform.localScale;
		DKPDKEHJENN = (1542f * IDAEFMLAGJE).ReplaceZ(271f);
		KKBPDHHCKAD = (566f * IDAEFMLAGJE).ReplaceZ(241f);
		FIBLFOFDDMJ = (1887f * IDAEFMLAGJE).ReplaceZ(720f);
	}

	public void FHINGMFHKLG()
	{
		FFBHMNPMFLD();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		OPPFBBMGCPP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
	}

	public void FPCCMILLDDG()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		HAKDIBMCDKF();
	}

	public void OGPKLKIEBHM()
	{
		JCFHBKJOPPK();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		JEIHKMEJCCM();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(OKELBKFFGFI));
	}

	public void InitControls()
	{
		KLOJBCMKAHJ();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		OPPFBBMGCPP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
	}

	private void OPPFBBMGCPP()
	{
		float num = 1f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, 0.0001f, 0f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, num * 6f, LCONNCBHIII, 0f, 0, CCIPBABILMN, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Scale, MBMIOELEAND.gameObject, num * 4f, HANDNIONGDE, 0f, 1, LCONNCBHIII, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 1f, 0.15f, 0f, 0, 0f, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(4, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 5f, 0.6f, num * 2f, 1, 0.15f);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Alpha, MBMIOELEAND.gameObject, num * 4f, 0.3f, num * 5f, 12, 0.6f);
		FNOMCHPCOHB.AddTween(6, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 4f, EMPGGKHAKCI, num * 1f, 1, GBDLEDCFEIJ, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 5f, KOPBDKAHHCD, 0f, 6, EMPGGKHAKCI, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(8, TweenAnimator.MNAIKKJDPLK.Alpha, FKLKLCBOMNE.gameObject, num * 3f, 1f, 0f, 1, 0f);
		FNOMCHPCOHB.AddTween(9, TweenAnimator.MNAIKKJDPLK.ProgressBar, PAENPHMEMGC.gameObject, num * 7f, GFKLCFENKAO, num * 2f, 1, NDJAJPKKOAF, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(10, TweenAnimator.MNAIKKJDPLK.ProgressBar, PAENPHMEMGC.gameObject, num * 4f, PGIKIBBAGGA, 0f, 9, GFKLCFENKAO, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(11, TweenAnimator.MNAIKKJDPLK.Alpha, PAENPHMEMGC.gameObject, num * 7f, 0.4f, num * 2f, 1, 0f);
		FNOMCHPCOHB.AddTween(12, TweenAnimator.MNAIKKJDPLK.Alpha, PAENPHMEMGC.gameObject, num * 4f, 0.15f, 0f, 9, 0.5f);
		FNOMCHPCOHB.AddTween(13, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 5f, KKBPDHHCKAD, num * 2f, 1, DKPDKEHJENN);
		FNOMCHPCOHB.AddTween(14, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[0].gameObject, num * 5f, IDAEFMLAGJE, 0f, 13, KKBPDHHCKAD);
		FNOMCHPCOHB.AddTween(15, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[0].gameObject, num * 1f, 1f, num * 2f, 1, 0f, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(16, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 10f, FIBLFOFDDMJ, num * 2f, 1, IDAEFMLAGJE);
		FNOMCHPCOHB.AddTween(17, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[1].gameObject, num * 1f, 0.3f, num * 2f, 1, 0f, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(18, TweenAnimator.MNAIKKJDPLK.Alpha, ONHKJPKDMEM[1].gameObject, num * 2f, 0f, num * 7f, 17, 0.3f, UITweener.Method.Linear);
		FNOMCHPCOHB.GenerateTweens();
	}

	public void FAHPIINNMBB()
	{
		DJKINANKKKH();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		HAKDIBMCDKF();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(KHPKDAHHCLG));
	}

	public void KJGJNENLEOF()
	{
		KLOJBCMKAHJ();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		HAKDIBMCDKF();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(NAAFPEBFDCA));
	}

	public void HOLMGCJLLDA()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		BMBGIHAELID();
	}

	public void IHJKGIDHOFO(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[0].delay = Mathf.Clamp(EMICAEBMJPD, 1451f, 1032f);
		FNOMCHPCOHB.ODIJFGCDJNH();
	}

	public void BDAMDKLCALK(float EMICAEBMJPD = 0f)
	{
		FNOMCHPCOHB.BEOAHFDJEMD[1].delay = Mathf.Clamp(EMICAEBMJPD, 449f, 858f);
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	private void JCFHBKJOPPK()
	{
		ONHKJPKDMEM[1].MakePixelPerfect();
		IDAEFMLAGJE = ONHKJPKDMEM[0].transform.localScale;
		DKPDKEHJENN = (479f * IDAEFMLAGJE).ReplaceZ(707f);
		KKBPDHHCKAD = (1863f * IDAEFMLAGJE).ReplaceZ(595f);
		FIBLFOFDDMJ = (659f * IDAEFMLAGJE).ReplaceZ(1912f);
	}

	private void GOPFJPCLNFF()
	{
		float num = 1523f / (float)GuiElementSingle<LevelUpDialog>.instance.MADOCMEKEDJ;
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, MBMIOELEAND.gameObject, 1051f, 1060f, 772f, -1, 390f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 1203f, LCONNCBHIII, 1934f, 1, CCIPBABILMN, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.TextCounter, MBMIOELEAND.gameObject, num * 386f, HANDNIONGDE, 1024f, 1, LCONNCBHIII, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.Position, MBMIOELEAND.gameObject, num * 1799f, 1551f, 1355f, 1, 1292f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, MBMIOELEAND.gameObject, num * 1886f, 518f, num * 507f, 1, 679f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, MBMIOELEAND.gameObject, num * 1582f, 1220f, num * 1690f, 35, 460f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 1556f, EMPGGKHAKCI, num * 1350f, 1, GBDLEDCFEIJ, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.Position, FKLKLCBOMNE.gameObject, num * 679f, KOPBDKAHHCD, 278f, 2, EMPGGKHAKCI, UITweener.Method.BounceOut);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FKLKLCBOMNE.gameObject, num * 1753f, 1106f, 563f, 1, 1041f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-58, (TweenAnimator.MNAIKKJDPLK)(-71), PAENPHMEMGC.gameObject, num * 1755f, GFKLCFENKAO, num * 1456f, 1, NDJAJPKKOAF, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(3, (TweenAnimator.MNAIKKJDPLK)(-39), PAENPHMEMGC.gameObject, num * 43f, PGIKIBBAGGA, 703f, -112, GFKLCFENKAO, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(22, TweenAnimator.MNAIKKJDPLK.Rotation, PAENPHMEMGC.gameObject, num * 1563f, 1640f, num * 731f, 0, 1964f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-58, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PAENPHMEMGC.gameObject, num * 811f, 1170f, 797f, 6, 320f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-70, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 1933f, KKBPDHHCKAD, num * 1105f, 0, DKPDKEHJENN, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(82, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, ONHKJPKDMEM[1].gameObject, num * 381f, IDAEFMLAGJE, 551f, -70, KKBPDHHCKAD, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-38, TweenAnimator.MNAIKKJDPLK.TextCounter, ONHKJPKDMEM[0].gameObject, num * 658f, 1599f, num * 396f, 0, 635f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(124, TweenAnimator.MNAIKKJDPLK.Scale, ONHKJPKDMEM[1].gameObject, num * 26f, FIBLFOFDDMJ, num * 1797f, 0, IDAEFMLAGJE, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(23, TweenAnimator.MNAIKKJDPLK.Rotation, ONHKJPKDMEM[0].gameObject, num * 1879f, 1484f, num * 1225f, 1, 1891f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-108, TweenAnimator.MNAIKKJDPLK.Position, ONHKJPKDMEM[1].gameObject, num * 1504f, 1880f, num * 1988f, 9, 976f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.KHAFPAMIOAF();
	}

	public void INMDPGCHHPN()
	{
		JCFHBKJOPPK();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		MBDKJIGMIFA();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(AIJOPBFOEDK));
	}

	private void NJNFHPJCCHL(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 670f);
		}
	}

	private void MFHEPHOGOOI(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical, 35f);
		}
	}

	public void CPAKIBKODJC()
	{
		IEEHMDEAJIJ();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		HAKDIBMCDKF();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(FCNNCIOPBAO));
	}

	private void FEDJIBLACLP(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 179f);
		}
	}
}
