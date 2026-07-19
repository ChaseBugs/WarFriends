using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnDeathMatchGuiCardFixed : DeathMatchGuiCard
{
	protected virtual void OFAHCLHDJFC()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(414f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1133f, 1577f).style = UITweener.Style.Once;
		PLHCFECODNM(false);
	}

	public virtual void LBDPGKFPJKA()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1239f, 1880f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(45f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1643f, 123f).style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1942f, 1307f, 1526f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = MHHPHBGBNME;
		CGPOFAHOCOB(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = true;
	}

	public virtual void EPMJKMAMOJL()
	{
	}

	private void MHHPHBGBNME(UITweener POLCDJOBFKG)
	{
		PNFNJKJLPIP = false;
	}

	private void BKDDDCFONPE(UITweener POLCDJOBFKG)
	{
		PNFNJKJLPIP = false;
	}

	protected virtual void GNAOIICEOLI()
	{
		TweenPosition.Begin(base.gameObject, 938f, DDBBFBHJCOO - new Vector3(1461f, 1169f, 1709f), false);
	}

	public virtual void MGPMGKJAOIL()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1600f, 1234f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(234f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1140f, 474f).style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 575f, 1596f, 882f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.onFinished = MHHPHBGBNME;
		NCMOMBELDPH(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = true;
	}

	protected virtual void AOLOCHHNHCK()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(796f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 298f, 1317f).style = UITweener.Style.Loop;
		NDNDFHGFDAO(true);
	}

	private void NJDFIPOOOCB(UITweener POLCDJOBFKG)
	{
		PNFNJKJLPIP = false;
	}

	public virtual void BIIHCAEKCOD(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.NLMKCDMBPPC(OIJBDFANMCC);
		if (OIJBDFANMCC != null)
		{
			PLHCFECODNM(true);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1005f, 1606f).style = UITweener.Style.Loop;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 776f : 1285f, DDBBFBHJCOO);
		}
		else
		{
			HLOJHFCMMNJ(true);
			TweenPosition.Begin(base.gameObject, 585f, DDBBFBHJCOO, false);
		}
	}

	private void OGKIEKNNFBC(UITweener POLCDJOBFKG)
	{
		PNFNJKJLPIP = true;
	}

	protected virtual void MKCAHNHKFHE()
	{
		TweenPosition.Begin(base.gameObject, 1999f, DDBBFBHJCOO - new Vector3(1003f, 346f, 464f), false);
	}

	public virtual void JGLBMLDHGNC()
	{
	}

	public virtual void OOPFBDILMCJ()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1486f, 1350f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1743f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 546f, 856f).style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1343f, 1711f, 783f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = BKDDDCFONPE;
		NCMOMBELDPH(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = false;
	}

	public virtual void HFEHPCIBCJK()
	{
	}

	public virtual void HIFHGNNGGAM()
	{
	}

	protected virtual void CFDLJEOOADN()
	{
		TweenPosition.Begin(base.gameObject, 1936f, DDBBFBHJCOO - new Vector3(1366f, 1095f, 1241f), false);
	}

	protected virtual void NDKEOFIJLMA()
	{
		TweenPosition.Begin(base.gameObject, 218f, DDBBFBHJCOO - new Vector3(821f, 1218f, 1330f), false);
	}

	protected virtual void IAAIJCKEDPA()
	{
		TweenPosition.Begin(base.gameObject, 490f, DDBBFBHJCOO - new Vector3(314f, 988f, 1594f), false);
	}

	[CompilerGenerated]
	private void EIJJLEHJJHA(UITweener POLCDJOBFKG)
	{
		PNFNJKJLPIP = false;
	}

	public virtual void ILFJPOOMFDO(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.JLJMIOLJPNL(OIJBDFANMCC);
		if (OIJBDFANMCC != null)
		{
			HLOJHFCMMNJ(false);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1829f, 1866f).style = UITweener.Style.Once;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 732f : 155f, DDBBFBHJCOO, false);
		}
		else
		{
			HLOJHFCMMNJ(false);
			TweenPosition.Begin(base.gameObject, 237f, DDBBFBHJCOO, false);
		}
	}

	public override void DisableCard()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 0.5f, 0f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(250f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 0.3f, 0.3f).style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = delegate
		{
			PNFNJKJLPIP = false;
		};
		PHECMFGFABB(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = false;
	}

	public override void Hide()
	{
	}

	public virtual void DJNMPLKPENF(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.DIBLFOPCCPL(OIJBDFANMCC, true);
		if (OIJBDFANMCC != null)
		{
			NDNDFHGFDAO(false);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 77f, 387f).style = UITweener.Style.Loop;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1973f : 1296f, DDBBFBHJCOO);
		}
		else
		{
			PLHCFECODNM(true);
			TweenPosition.Begin(base.gameObject, 1941f, DDBBFBHJCOO, false);
		}
	}

	public virtual void AAHJOEILKNG(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.LEJEDFACEGP(OIJBDFANMCC, true);
		if (OIJBDFANMCC != null)
		{
			PLHCFECODNM(false);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 744f, 1869f).style = UITweener.Style.Once;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1424f : 1724f, DDBBFBHJCOO, false);
		}
		else
		{
			HLOJHFCMMNJ(false);
			TweenPosition.Begin(base.gameObject, 950f, DDBBFBHJCOO, false);
		}
	}

	public virtual void APHGCACOKBK()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1957f, 1110f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1658f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1198f, 1167f).style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 500f, 477f, 1809f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = OGKIEKNNFBC;
		IOIHNBMKCKM(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = false;
	}

	public override void Show(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.Show(OIJBDFANMCC);
		if (OIJBDFANMCC != null)
		{
			HLOJHFCMMNJ(false);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 0.3f, 0f).style = UITweener.Style.Once;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 0.3f : 0f, DDBBFBHJCOO);
		}
		else
		{
			HLOJHFCMMNJ(false);
			TweenPosition.Begin(base.gameObject, 0.3f, DDBBFBHJCOO);
		}
	}

	public virtual void PKLDJJIALHA()
	{
	}

	protected virtual void KCNEDHOBCHL()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1511f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1367f, 110f).style = UITweener.Style.Once;
		PLHCFECODNM(false);
	}

	protected virtual void GDEGLMGNLOM()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1733f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 308f, 125f).style = UITweener.Style.Loop;
		NDNDFHGFDAO(true);
	}

	protected virtual void KIMNGGHGBIM()
	{
		TweenPosition.Begin(base.gameObject, 663f, DDBBFBHJCOO - new Vector3(911f, 1472f, 1772f), false);
	}

	public virtual void BLDAKINNEBC()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1081f, 1646f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(226f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1107f, 216f).style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1169f, 118f, 1458f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = NJDFIPOOOCB;
		NCMOMBELDPH(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = true;
	}

	protected virtual void IPGOADADKOA()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1468f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1265f, 1323f).style = UITweener.Style.Once;
		HLOJHFCMMNJ(true);
	}

	public virtual void OBPBDPFEKME()
	{
	}

	protected virtual void LEIBPGKPLJD()
	{
		TweenPosition.Begin(base.gameObject, 796f, DDBBFBHJCOO - new Vector3(1666f, 1257f, 1937f), false);
	}

	public virtual void FJILILFMPIF(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.JLJMIOLJPNL(OIJBDFANMCC);
		if (OIJBDFANMCC != null)
		{
			PLHCFECODNM(true);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1546f, 1794f).style = UITweener.Style.Once;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 636f : 1211f, DDBBFBHJCOO, false);
		}
		else
		{
			HLOJHFCMMNJ(true);
			TweenPosition.Begin(base.gameObject, 766f, DDBBFBHJCOO);
		}
	}

	public virtual void NDODOLKAABG()
	{
	}

	protected virtual void OMKOEOIGDKC()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1949f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1513f, 216f).style = UITweener.Style.Loop;
		PLHCFECODNM(true);
	}

	protected virtual void DFIHIBHCJPC()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1728f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1731f, 234f).style = UITweener.Style.Loop;
		HLOJHFCMMNJ(true);
	}

	protected virtual void FIMJEIIONFC()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1824f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1496f, 1028f).style = UITweener.Style.Once;
		NDNDFHGFDAO(false);
	}

	protected virtual void CIKDLJGLMME()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1932f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 347f, 290f).style = UITweener.Style.Loop;
		PLHCFECODNM(false);
	}

	public virtual void LGKPFDMNNBO()
	{
	}

	protected virtual void LJJDDKIBGLH()
	{
		TweenPosition.Begin(base.gameObject, 1354f, DDBBFBHJCOO - new Vector3(1637f, 836f, 622f));
	}

	public virtual void PEBHGOMEKME(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.LEJEDFACEGP(OIJBDFANMCC);
		if (OIJBDFANMCC != null)
		{
			NDNDFHGFDAO(true);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1698f, 1831f).style = UITweener.Style.Loop;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1204f : 1894f, DDBBFBHJCOO, false);
		}
		else
		{
			HLOJHFCMMNJ(false);
			TweenPosition.Begin(base.gameObject, 1224f, DDBBFBHJCOO, false);
		}
	}

	protected virtual void NNGLNPCENFH()
	{
		TweenPosition.Begin(base.gameObject, 1700f, DDBBFBHJCOO - new Vector3(853f, 134f, 88f), false);
	}

	protected override void NMOFIPILGOP()
	{
		TweenPosition.Begin(base.gameObject, 0.3f, DDBBFBHJCOO - new Vector3(0f, 350f, 0f));
	}

	protected override void LKNFNKJHGDD()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(198f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 0.3f, 0.3f).style = UITweener.Style.Once;
		HLOJHFCMMNJ(true);
	}

	protected virtual void IIJHCIGAFIL()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1610f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 147f, 189f).style = UITweener.Style.Loop;
		PLHCFECODNM(true);
	}

	public virtual void KBDCLJNPODD()
	{
	}

	protected virtual void LHMNIIBIMMJ()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1931f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1863f, 1562f).style = UITweener.Style.Loop;
		NDNDFHGFDAO(false);
	}

	protected virtual void IINKFKENHKD()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(446f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1169f, 1900f).style = UITweener.Style.Once;
		HLOJHFCMMNJ(false);
	}

	public virtual void BBOHJOFMLDI(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		base.JLJMIOLJPNL(OIJBDFANMCC);
		if (OIJBDFANMCC != null)
		{
			PLHCFECODNM(false);
			TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1851f, 1861f).style = UITweener.Style.Once;
			TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1738f : 1549f, DDBBFBHJCOO);
		}
		else
		{
			PLHCFECODNM(true);
			TweenPosition.Begin(base.gameObject, 681f, DDBBFBHJCOO, false);
		}
	}

	protected override void OFCHHGEPKKM()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1179f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1870f, 1379f).style = UITweener.Style.Once;
		HLOJHFCMMNJ(true);
	}

	protected virtual void BLOHDJJOFBI()
	{
		TweenPosition.Begin(base.gameObject, 653f, DDBBFBHJCOO - new Vector3(596f, 1680f, 1074f), false);
	}

	public virtual void DBDKNCFPMLC()
	{
	}

	protected virtual void NPCFNBBDEDG()
	{
		TweenPosition.Begin(base.gameObject, 1150f, DDBBFBHJCOO - new Vector3(1111f, 240f, 1275f), false);
	}

	public virtual void OLOOOBDLGAI()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1276f, 407f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1642f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1897f, 1519f).style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 461f, 1856f, 796f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = OGKIEKNNFBC;
		CGPOFAHOCOB(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = true;
	}

	public virtual void PGDKKFKEPFE()
	{
	}

	public virtual void GOOIEFMGMDD()
	{
	}

	protected virtual void BBLDJFDOKHF()
	{
		TweenPosition.Begin(base.gameObject, 1249f, DDBBFBHJCOO - new Vector3(1660f, 1548f, 1498f));
	}

	private void PPOABMPDMLK(UITweener POLCDJOBFKG)
	{
		PNFNJKJLPIP = false;
	}

	private void DJLOKKHAFLM(UITweener POLCDJOBFKG)
	{
		PNFNJKJLPIP = true;
	}

	protected virtual void EGELHKKIMEL()
	{
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(430f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1323f, 662f).style = UITweener.Style.Once;
		PLHCFECODNM(false);
	}

	public virtual void EPHFNJEFBAE()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1788f, 1692f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1037f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1230f, 1468f).style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1062f, 436f, 1856f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.onFinished = DJLOKKHAFLM;
		NCMOMBELDPH(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = false;
	}

	public virtual void BIDCKIPCDKH()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 532f, 1786f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1070f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1276f, 1976f).style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1182f, 986f, 96f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = MHHPHBGBNME;
		NCMOMBELDPH(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = true;
	}

	public virtual void KBAMBEJGOKA()
	{
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 313f, 1992f);
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1940f);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1229f, 532f).style = UITweener.Style.Loop;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1986f, 1495f, 1595f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = delegate
		{
			PNFNJKJLPIP = false;
		};
		CGPOFAHOCOB(PNFNJKJLPIP);
		GetComponent<UIButtonScale>().enabled = true;
	}
}
