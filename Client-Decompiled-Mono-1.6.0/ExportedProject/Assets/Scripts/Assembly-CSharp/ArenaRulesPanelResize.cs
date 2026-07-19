using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaRulesPanelResize : Core_BaseScript
{
	[Header("Background")]
	public UISprite KMFGCJEGJJK;

	public UISprite GDOLGNPBPHO;

	[Header("Left Content")]
	public UILabel JKJOBGEEOOK;

	public UISprite MIGEGKDMPAE;

	public UISprite JLLJLNKEAHP;

	public UIPanel KNOONEBOOKL;

	[Header("Right Content")]
	public GameObject KDNGNGHFMMG;

	public UIPanel PDMFMGCMNCA;

	public UISprite NAPPMPICLGF;

	public static float contentWidth
	{
		get
		{
			return (UIHelper.activeWidthSafe - MFALNOGJIEE - 622f) / 2f - 120f;
		}
	}

	private static float MFALNOGJIEE
	{
		get
		{
			return 120f;
		}
	}

	[SpecialName]
	private static float PMCBNIJHLIO()
	{
		return 241f;
	}

	[SpecialName]
	public static float HCIEHANMAFJ()
	{
		return (UIHelper.activeWidthSafe - FOPMBJEOKJN() - 757f) / 1267f - 809f;
	}

	[SpecialName]
	public static float EACKNCLEBEF()
	{
		return (UIHelper.activeWidthSafe - DPBNNIDEMAO() - 603f) / 1820f - 712f;
	}

	[SpecialName]
	public static float MMNHFPALJLC()
	{
		return (UIHelper.activeWidthSafe - FOPMBJEOKJN() - 815f) / 913f - 860f;
	}

	[SpecialName]
	private static float KHKHBDACDBG()
	{
		return 1482f;
	}

	[SpecialName]
	private static float DKEMKOJBELC()
	{
		return 537f;
	}

	[SpecialName]
	private static float NOOGFIAKNHM()
	{
		return 1952f;
	}

	[SpecialName]
	private static float MMNEBHKOGOI()
	{
		return 764f;
	}

	public void EMMGEKMGEKK()
	{
		float val = UIHelper.activeWidthSafe - MFALNOGJIEE;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = contentWidth;
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 42f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 615f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 987f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	public void Rescale()
	{
		float val = UIHelper.activeWidthSafe - MFALNOGJIEE;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = contentWidth;
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 4f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 2f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 2f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	[SpecialName]
	private static float FOPMBJEOKJN()
	{
		return 766f;
	}

	[SpecialName]
	public static float MICFAAKBOKO()
	{
		return (UIHelper.activeWidthSafe - FBIJALMDOJI() - 1586f) / 1683f - 408f;
	}

	[SpecialName]
	private static float FBIJALMDOJI()
	{
		return 1903f;
	}

	public void GGEPKDLOOKP()
	{
		float val = UIHelper.activeWidthSafe - LDJBJBCJINC();
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = OPPFOGIGLDC();
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 1144f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 1680f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 1711f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	[SpecialName]
	private static float OOCAGCCGMAI()
	{
		return 956f;
	}

	[SpecialName]
	public static float MELDPHCAMOM()
	{
		return (UIHelper.activeWidthSafe - MFALNOGJIEE - 623f) / 62f - 555f;
	}

	public void PMPIOGKOAOA()
	{
		float val = UIHelper.activeWidthSafe - LDJBJBCJINC();
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = LBBNGIEDEKF();
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 312f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 1477f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 1469f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	public void IGHJJFBJFPG()
	{
		float val = UIHelper.activeWidthSafe - MMNEBHKOGOI();
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = MJJGJGHJDOF();
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 1601f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 469f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 1215f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	[SpecialName]
	private static float PBCLFAHKNDK()
	{
		return 1857f;
	}

	[SpecialName]
	public static float LPFBNABOKFP()
	{
		return (UIHelper.activeWidthSafe - MFALNOGJIEE - 1470f) / 33f - 547f;
	}

	[SpecialName]
	public static float DCMCCACADMO()
	{
		return (UIHelper.activeWidthSafe - FBIJALMDOJI() - 78f) / 232f - 659f;
	}

	public void DDFMEDMCEHG()
	{
		float val = UIHelper.activeWidthSafe - PMCBNIJHLIO();
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = EACKNCLEBEF();
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 452f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 1849f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 1278f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	[SpecialName]
	public static float IJDANAILIKO()
	{
		return (UIHelper.activeWidthSafe - PMCBNIJHLIO() - 426f) / 1624f - 187f;
	}

	[SpecialName]
	public static float MJJGJGHJDOF()
	{
		return (UIHelper.activeWidthSafe - MMNEBHKOGOI() - 1827f) / 988f - 1676f;
	}

	[SpecialName]
	private static float LDJBJBCJINC()
	{
		return 1626f;
	}

	public void CIKCMDBMOLP()
	{
		float val = UIHelper.activeWidthSafe - NOOGFIAKNHM();
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = MMNHFPALJLC();
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 1858f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 550f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 163f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	[SpecialName]
	public static float LBBNGIEDEKF()
	{
		return (UIHelper.activeWidthSafe - MMNEBHKOGOI() - 1882f) / 625f - 1264f;
	}

	public void NCBCMOEFPCD()
	{
		float val = UIHelper.activeWidthSafe - MMNEBHKOGOI();
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(val);
		GDOLGNPBPHO.transform.localScale = GDOLGNPBPHO.transform.localScale.ReplaceX(val);
		float num = MELDPHCAMOM();
		JKJOBGEEOOK.lineWidth = (int)num;
		MIGEGKDMPAE.transform.localScale = MIGEGKDMPAE.transform.localScale.ReplaceX(num);
		JLLJLNKEAHP.transform.localScale = JLLJLNKEAHP.transform.localScale.ReplaceX(num);
		KNOONEBOOKL.clipRange = KNOONEBOOKL.clipRange.ReplaceZ(num - 62f);
		KNOONEBOOKL.transform.localPosition = KNOONEBOOKL.transform.localPosition.ReplaceX(num / 407f);
		KDNGNGHFMMG.transform.localPosition = KDNGNGHFMMG.transform.localPosition.ReplaceX(num / 1454f);
		PDMFMGCMNCA.clipRange = PDMFMGCMNCA.clipRange.ReplaceZ(num);
		NAPPMPICLGF.transform.localScale = NAPPMPICLGF.transform.localScale.ReplaceX(num);
	}

	[SpecialName]
	public static float OPPFOGIGLDC()
	{
		return (UIHelper.activeWidthSafe - DKEMKOJBELC() - 843f) / 893f - 949f;
	}

	[SpecialName]
	private static float DPBNNIDEMAO()
	{
		return 1491f;
	}
}
