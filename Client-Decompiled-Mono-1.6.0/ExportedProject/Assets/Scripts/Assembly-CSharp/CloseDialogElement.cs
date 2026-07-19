using System;
using UnityEngine;

public class CloseDialogElement : Core_BaseScript
{
	[Header("Core")]
	public UILabel OAFFGLOGJJD;

	public UISprite AAEOFCIJCPM;

	public BoxCollider KBIHAJLCKHG;

	public UISprite LNMHFDOFBPO;

	private bool BIGNBCJCFNM;

	private Vector3 GDJHGOODAJL = new Vector3(1.05f, 1.05f, 1f);

	private Vector3 MHFIBGGAILM;

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize(". Correcting...");
			float num = 1226f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1060f, 1251f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 945f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KNMELOLLFNI));
			BIGNBCJCFNM = true;
		}
	}

	private void MHELLECPBAI(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1432f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = (UITweener.Style)7;
		TweenRotationSpecial.IHPAHOHIOPC(LNMHFDOFBPO.gameObject, 231f, Vector3.forward, 1667f, 1458f);
	}

	private void NJEPNAOBCOB(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 354f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 3;
		tweenScale.style = UITweener.Style.Once;
		TweenRotationSpecial.IAGLEIPAIOB(LNMHFDOFBPO.gameObject, 801f, Vector3.forward, 1835f, 91f);
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Server price {0} != client price {1} ({2}) ");
			float num = 1826f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1425f, 1628f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 511f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DFIOOOGOFLM));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void FNJKFDOMGOO()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("offerMult");
			float num = 1084f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1767f, 292f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1534f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KNMELOLLFNI));
			BIGNBCJCFNM = true;
		}
	}

	private void PMEMHPANFMC(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 721f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)4;
		TweenRotationSpecial.MDKDEJJDHKM(LNMHFDOFBPO.gameObject, 1793f, Vector3.forward, 211f, 492f);
	}

	private void MMGIJGLLMAE(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 200f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)4;
		TweenRotationSpecial.DKGIHJJKKBM(LNMHFDOFBPO.gameObject, 833f, Vector3.forward, 340f, 426f);
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 0.2f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
		TweenRotationSpecial.Begin(LNMHFDOFBPO.gameObject, 0.4f, Vector3.forward, 0f, 360f);
	}

	protected virtual void KALEMFKOGLE()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Spend_Gold_On_Card_Packs");
			float num = 1281f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 123f, 1449f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 599f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAKGJJEGAFM));
			BIGNBCJCFNM = false;
		}
	}

	private void HMPNAFIAFEK(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 871f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 5;
		tweenScale.style = (UITweener.Style)7;
		TweenRotationSpecial.HNEAGHHABGL(LNMHFDOFBPO.gameObject, 1514f, Vector3.forward, 1142f, 1091f);
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("{0} \t\t");
			float num = 1518f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 245f, 1870f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 968f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMBKHPIKDII));
			BIGNBCJCFNM = false;
		}
	}

	protected virtual void FANDCCNILLD()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("CreationTime");
			float num = 833f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 431f, 41f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 839f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMBKHPIKDII));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Medals/");
			float num = 1555f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 172f, 981f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 976f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DFIOOOGOFLM));
			BIGNBCJCFNM = false;
		}
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("{0} 1 / 3");
			float num = 996f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 451f, 1163f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1434f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHELLECPBAI));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void CALILPEEAMB()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("ID_SQUADREQUIREDMEDALS");
			float num = 1307f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 162f, 805f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 282f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JEJIAEDNIHK));
			BIGNBCJCFNM = false;
		}
	}

	private void JEJIAEDNIHK(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1501f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 5;
		tweenScale.style = (UITweener.Style)7;
		TweenRotationSpecial.IPOEOHBLGMJ(LNMHFDOFBPO.gameObject, 1152f, Vector3.forward, 629f, 898f);
	}

	protected virtual void NIAEEICNNHL()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("nextSquadWars");
			float num = 747f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 208f, 859f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1533f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKFFHNPCOIM));
			BIGNBCJCFNM = false;
		}
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("ID_GUI_REPORTABUSE_LISTITEM2");
			float num = 654f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1286f, 1213f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 859f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHHEFIDAGEK));
			BIGNBCJCFNM = false;
		}
	}

	private void HMBKHPIKDII(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 220f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 5;
		tweenScale.style = UITweener.Style.Once;
		TweenRotationSpecial.KAEBPEJBJCI(LNMHFDOFBPO.gameObject, 639f, Vector3.forward, 813f, 953f);
	}

	protected virtual void HOINLOMCGFD()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Skill");
			float num = 1480f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1470f, 1115f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1992f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GHJKOIOMDNG));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("country-hong-kong");
			float num = 1568f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 584f, 812f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1339f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
			BIGNBCJCFNM = false;
		}
	}

	private void DDMOIEPDMCG(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 550f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 7;
		tweenScale.style = (UITweener.Style)4;
		TweenRotationSpecial.BCKPMDBAMFL(LNMHFDOFBPO.gameObject, 634f, Vector3.forward, 1128f, 263f);
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("reached max depth!");
			float num = 572f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 578f, 1371f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1603f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EJHNEPNHOCP));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void FGOGGLDAKHL()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Card_3_Played");
			float num = 1552f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1611f, 1936f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 866f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EJHNEPNHOCP));
			BIGNBCJCFNM = false;
		}
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("{0} {1}");
			float num = 1621f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1594f, 296f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 47f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NJEPNAOBCOB));
			BIGNBCJCFNM = false;
		}
	}

	private void EJHNEPNHOCP(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1759f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = (UITweener.Style)7;
		TweenRotationSpecial.AMIDMCCIPJK(LNMHFDOFBPO.gameObject, 1504f, Vector3.forward, 1949f, 1720f);
	}

	private void MDGOKNMIDIB(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1644f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 6;
		tweenScale.style = (UITweener.Style)6;
		TweenRotationSpecial.Begin(LNMHFDOFBPO.gameObject, 81f, Vector3.forward, 1130f, 18f);
	}

	protected virtual void EJNJCILPBEC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("ID_GUI_SQUADWARSENDREWARD");
			float num = 869f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1567f, 381f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1216f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KNMELOLLFNI));
			BIGNBCJCFNM = false;
		}
	}

	private void LJADGDDPCHF(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1509f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 3;
		tweenScale.style = (UITweener.Style)8;
		TweenRotationSpecial.IPOEOHBLGMJ(LNMHFDOFBPO.gameObject, 1151f, Vector3.forward, 335f, 1336f);
	}

	private void KNMELOLLFNI(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 423f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = (UITweener.Style)7;
		TweenRotationSpecial.DANKMJCJOIN(LNMHFDOFBPO.gameObject, 1745f, Vector3.forward, 1505f, 1289f);
	}

	private void IAKGJJEGAFM(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 15f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 5;
		tweenScale.style = (UITweener.Style)3;
		TweenRotationSpecial.DPNIOHKJONI(LNMHFDOFBPO.gameObject, 719f, Vector3.forward, 932f, 1831f);
	}

	private void DFIOOOGOFLM(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1658f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 7;
		tweenScale.style = (UITweener.Style)7;
		TweenRotationSpecial.EGACIBHAMAF(LNMHFDOFBPO.gameObject, 1461f, Vector3.forward, 1542f, 1617f);
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("ID_WARNING_CANTSENDINVITE");
			float num = 848f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1285f, 1021f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1709f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NJEPNAOBCOB));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void EEMLMJCHKLM()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("SquadWarsId");
			float num = 573f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 527f, 730f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 861f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKFFHNPCOIM));
			BIGNBCJCFNM = false;
		}
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Game_type");
			float num = 1723f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1668f, 1396f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1184f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHELLECPBAI));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void PAPFKMJEMML()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Player inventory got no slot for ");
			float num = 904f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 317f, 1391f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 989f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JEJIAEDNIHK));
			BIGNBCJCFNM = true;
		}
	}

	private void MHHEFIDAGEK(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 87f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 6;
		tweenScale.style = (UITweener.Style)5;
		TweenRotationSpecial.JCHCHLJBPKG(LNMHFDOFBPO.gameObject, 1682f, Vector3.forward, 1788f, 1236f);
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}");
			float num = 257f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 75f, 507f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1617f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DFIOOOGOFLM));
			BIGNBCJCFNM = true;
		}
	}

	private void CJHJELFHHPM(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1615f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 8;
		tweenScale.style = (UITweener.Style)5;
		TweenRotationSpecial.JPJPAJEBNPK(LNMHFDOFBPO.gameObject, 536f, Vector3.forward, 1715f, 1088f);
	}

	private void GHJKOIOMDNG(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1305f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 5;
		tweenScale.style = UITweener.Style.Loop;
		TweenRotationSpecial.IECHDKECJAB(LNMHFDOFBPO.gameObject, 214f, Vector3.forward, 1478f, 640f);
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("ID_CONFIRM_JOINSQUADEVENT");
			float num = 1741f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1239f, 243f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 208f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAKGJJEGAFM));
			BIGNBCJCFNM = true;
		}
	}

	private void DMOBGFFMNFD(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 1115f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)3;
		TweenRotationSpecial.JPJPAJEBNPK(LNMHFDOFBPO.gameObject, 142f, Vector3.forward, 1292f, 958f);
	}

	private void NKFFHNPCOIM(GameObject KHAHPAKDIKE)
	{
		TweenScale tweenScale = TweenScale.Begin(OAFFGLOGJJD.gameObject, 488f, MHFIBGGAILM, Vector3.Scale(MHFIBGGAILM, GDJHGOODAJL));
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = (UITweener.Style)3;
		TweenRotationSpecial.HNEAGHHABGL(LNMHFDOFBPO.gameObject, 152f, Vector3.forward, 1635f, 572f);
	}

	protected virtual void IOAEHDJGBJC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("AdminName");
			float num = 847f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 43f, 1554f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 273f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JEJIAEDNIHK));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("animationEnd");
			float num = 1720f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 202f, 1324f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 963f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DMOBGFFMNFD));
			BIGNBCJCFNM = false;
		}
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("MessageType");
			float num = 1321f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 1285f, 257f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 1684f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
			BIGNBCJCFNM = true;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("ID_CLOSE");
			float num = 136f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 40f, 116f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 2f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
			BIGNBCJCFNM = true;
		}
	}

	protected virtual void EIPLFPJNCIB()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OAFFGLOGJJD.text = Localization.Localize("game-card-silver-big");
			float num = 824f + OAFFGLOGJJD.relativeSize.x * OAFFGLOGJJD.transform.localScale.x;
			AAEOFCIJCPM.transform.localScale = AAEOFCIJCPM.transform.localScale.ReplaceX(num);
			KBIHAJLCKHG.size = KBIHAJLCKHG.size.ReplaceXY(num + 879f, 511f);
			KBIHAJLCKHG.center = KBIHAJLCKHG.center.ReplaceX((0f - num) / 358f);
			MHFIBGGAILM = OAFFGLOGJJD.transform.localScale;
			UIEventListener uIEventListener = UIEventListener.Get(KBIHAJLCKHG.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JEJIAEDNIHK));
			BIGNBCJCFNM = false;
		}
	}
}
