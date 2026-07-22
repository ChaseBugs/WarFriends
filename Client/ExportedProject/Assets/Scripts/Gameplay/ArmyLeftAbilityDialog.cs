using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmyLeftAbilityDialog : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("LHBGCEFHFBA")]
	public UIPanel HLNECHGJJBG;

	[FormerlySerializedAs("JEHIMPKHLCC")]
	public GameObject CHNKLHLJHDP;

	[FormerlySerializedAs("MDGBOIAPMJN")]
	public UILabel LCAFKBDICLL;

	[FormerlySerializedAs("IENCPNNLJEI")]
	public UILabel NFMNIANAMBN;

	[FormerlySerializedAs("LGCLCJCDEDO")]
	public ArmyUnitStatistics MPHPFFMLGDB;

	[FormerlySerializedAs("JAKBBLEONPH")]
	public ArmyPowerAnimation MBEENAOGFEK;

	[Header("-Locked Button")]
	[FormerlySerializedAs("MPFJINIPNIF")]
	public GameObject BPACCGEGAJG;

	[FormerlySerializedAs("GIIMGJIBOAD")]
	public UITable OILCOOCFHHO;

	[FormerlySerializedAs("PEPKNCBKKHC")]
	public UILabel AFNHAGOCMPE;

	[FormerlySerializedAs("FKLHOFEPDGM")]
	public UISprite[] FDEHPNGLLFC;

	[FormerlySerializedAs("NJLGPBNPHJB")]
	[Header("-Upgrade Button")]
	public GameObject CADEBFIDNLC;

	[FormerlySerializedAs("DGMIEBINFEJ")]
	public UITable OOBCCHCODGB;

	[FormerlySerializedAs("CANMJNFFPAG")]
	public UILabel GDGIJMPJHGN;

	[FormerlySerializedAs("LJBENNOAAEI")]
	public GameObject LKJPNKKKMOO;

	[FormerlySerializedAs("INHIPJGCEFF")]
	public UILabel JLNKACKOFBL;

	[FormerlySerializedAs("NMJPKJAMPCC")]
	public WinStreakCounter ODJFOLLKEPD;

	[FormerlySerializedAs("DFDCNHGGECC")]
	[Header("-Deliver now Button")]
	public GameObject AGGBGFNOIPI;

	[FormerlySerializedAs("EFDAKOOOCAI")]
	public UILabel LANKMOCLBML;

	[FormerlySerializedAs("CCGPOKELOKL")]
	public UILabel LLKGNPDGABK;

	[FormerlySerializedAs("FMBCGANCKBO")]
	public UISprite BJHPILOOKIF;

	[FormerlySerializedAs("BGPFAFOALIC")]
	public UITable DCDAOBJJIMD;

	[FormerlySerializedAs("DBNMJMFOPLD")]
	public UILabel NKGKGCBJDBK;

	[FormerlySerializedAs("mAbilityButtonDeliverSalePart")]
	[Header("--Subsccription")]
	[SerializeField]
	private GameObject mSubscriptionPart;

	[SerializeField]
	[FormerlySerializedAs("mAbilityButtonDeliverSaleLabel")]
	private UILabel mSubscriptionHint;

	[FormerlySerializedAs("mAbilityButtonDeliveryTimeSale")]
	[Header("-Activate Button")]
	public GameObject OOJMINHFDPC;

	[FormerlySerializedAs("mSubscriptionPart")]
	[Header("-Tier full Button")]
	public GameObject IAJDLGBGCDJ;

	[FormerlySerializedAs("GAHMEHCOJHH")]
	public UITable MCKJCCPCPOM;

	[FormerlySerializedAs("EAFLBDHAONB")]
	public UILabel GPFLADPPBGA;

	[FormerlySerializedAs("NPBGPCFLOAC")]
	public UISprite[] IMFOFIHCBKD;

	[Header("-Max Button")]
	[FormerlySerializedAs("HMGBIBFIGBH")]
	public GameObject BNLFKJPFMOI;

	private LevelBehaviour IFFDIHCPKFE;

	private bool CNBJMDECEJG;

	private float JCAFFELIFAO = 0.3f;

	private int CLDFFNMPKOP = -1;

	private bool JCKOBELDCGD;

	private void EHCKFLBFHMK(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVERSPECIAL);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Unit_Upgrade";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, CDMKCIKHIMM: true);
		PNDNJFJMEJE(AGGBGFNOIPI);
		LBBOFMMKHEI(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	private void AKBAEMFMBFO(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = true;
	}

	private TweenAlpha EDJDPHGENOF()
	{
		return PIHLGCEAPIE(1f);
	}

	public void SelectUnit(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
	}

	[CompilerGenerated]
	private void EIJOIAFOOJF(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private void GOODBJLFLBH(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LLKGNPDGABK.gameObject, 350f, 509f, 1460f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	public void InitGUIValues()
	{
	}

	private void OIIKGIADJGN(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LANKMOCLBML.gameObject, 1457f, 329f, 772f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void CPIEGCEDKNK()
	{
		MPHPFFMLGDB.AnimateStat();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
	}

	private void OHHFKMOKFMB()
	{
		UpgradeSlotSpecial upgradeSlotSpecial = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial;
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		bool isMaxUpgraded = upgradeSlotSpecial.isMaxUpgraded;
		bool isTierFullUpgraded = upgradeSlotSpecial.isTierFullUpgraded;
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.BDAAHLLPPGN();
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.BLEGKMEKOPE();
		JDJFMFFCHOJ();
		BPACCGEGAJG.SetActive(flag);
		AGGBGFNOIPI.SetActive(unitState != UpgradeSlots.JLANLLEABDC.Locked || upgradeSlotSpecial.LCFLGKPGEAG());
		OOJMINHFDPC.SetActive(unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering || upgradeSlotSpecial.LCFLGKPGEAG());
		IAJDLGBGCDJ.SetActive(!flag && isTierFullUpgraded && !isMaxUpgraded);
		BNLFKJPFMOI.SetActive(flag || isMaxUpgraded);
		CADEBFIDNLC.SetActive(!BPACCGEGAJG.activeSelf && !AGGBGFNOIPI.activeSelf && !OOJMINHFDPC.activeSelf && !IAJDLGBGCDJ.activeSelf && !BNLFKJPFMOI.activeSelf);
	}

	public void OPJIOHOHCAJ(bool NOLODGKKCDH = true)
	{
		if (!CNBJMDECEJG)
		{
			JCKOBELDCGD = true;
			FPPPLPHDBMO();
			return;
		}
		if (NOLODGKKCDH)
		{
			JCKOBELDCGD = false;
			OHHFKMOKFMB();
			KIOOEACJNOD();
			return;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.JLANLLEABDC.Locked || unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || unitState == UpgradeSlots.JLANLLEABDC.Delivering)
		{
			TweenAlpha tweenAlpha = AAGJAOHLHIG();
			if (tweenAlpha == null)
			{
				OHHFKMOKFMB();
				PKMBOCKEPIE(EOGFKBJCKHB: false);
			}
			else
			{
				JCKOBELDCGD = true;
				tweenAlpha.onFinished = DPOJIGMHIHN;
			}
		}
		else
		{
			AMBIFCOIHKA();
		}
	}

	public void OAAABGFLAFG()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = false;
		CHNKLHLJHDP.SetActive(value: false);
		HLNECHGJJBG.alpha1 = 1981f;
		TweenAlpha.Begin(HLNECHGJJBG.gameObject, JCAFFELIFAO, 22f);
		TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 803f, new Vector3(269f, 753f, 1279f), new Vector3(242f, 1122f, 1202f)).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		PCMMIPAAAOL();
		FPPPLPHDBMO();
		PKMBOCKEPIE(EOGFKBJCKHB: false);
		UIPanel[] componentsInChildren = CHNKLHLJHDP.GetComponentsInChildren<UIPanel>(includeInactive: true);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1297f).onFinished = null;
		}
	}

	private void MGCMOALEGJD(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = true;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
			{
				component2.alpha1 = 1f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	private void ABLGPDJDAHO()
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.UpdateLeftContent(NOLODGKKCDH: false);
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent(NOLODGKKCDH: false);
	}

	[CompilerGenerated]
	private void EACNIDLHDGD()
	{
		float val = 0f - DCDAOBJJIMD.padding.x - (NKGKGCBJDBK.transform.parent.transform.localPosition.x - DCDAOBJJIMD.padding.x) / 2f;
		DCDAOBJJIMD.transform.localPosition = DCDAOBJJIMD.transform.localPosition.ReplaceX(val);
	}

	private void LBBOFMMKHEI(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			Debug.Log($"Army Power Ability Animation from {LFNBJLJPEGP} to {armyPowerX}");
			MBEENAOGFEK.StartAnimation(hONEKCJDJDN, armyPowerX, 0.05f);
		}
	}

	public void LHIICLJBNBI()
	{
		CNBJMDECEJG = true;
		JCKOBELDCGD = false;
		CHNKLHLJHDP.SetActive(value: true);
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CADEBFIDNLC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ONFHPJLFLLM));
		UIEventListener uIEventListener2 = UIEventListener.Get(AGGBGFNOIPI.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHCKFLBFHMK));
		UIEventListener uIEventListener3 = UIEventListener.Get(OOJMINHFDPC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PJLFHEEBCBI));
		OOBCCHCODGB.onReposition = delegate
		{
			float val = 0f - OOBCCHCODGB.padding.x - (GDGIJMPJHGN.transform.parent.transform.localPosition.x - OOBCCHCODGB.padding.x) / 2f;
			OOBCCHCODGB.transform.localPosition = OOBCCHCODGB.transform.localPosition.ReplaceX(val);
		};
		DCDAOBJJIMD.onReposition = delegate
		{
			float val = 0f - DCDAOBJJIMD.padding.x - (NKGKGCBJDBK.transform.parent.transform.localPosition.x - DCDAOBJJIMD.padding.x) / 2f;
			DCDAOBJJIMD.transform.localPosition = DCDAOBJJIMD.transform.localPosition.ReplaceX(val);
		};
	}

	private TweenAlpha PIHLGCEAPIE(float FFFGJJDIMEF)
	{
		TweenAlpha tweenAlpha = CADEBFIDNLC.GetComponent<TweenAlpha>();
		bool flag = false;
		if (CHNKLHLJHDP.activeSelf && JCKOBELDCGD)
		{
			if (BPACCGEGAJG.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(BPACCGEGAJG, FFFGJJDIMEF);
				flag = true;
			}
			if (CADEBFIDNLC.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(CADEBFIDNLC, FFFGJJDIMEF);
				flag = true;
			}
			if (AGGBGFNOIPI.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(AGGBGFNOIPI, FFFGJJDIMEF);
				flag = true;
			}
			if (OOJMINHFDPC.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(OOJMINHFDPC, FFFGJJDIMEF);
				flag = true;
			}
			if (IAJDLGBGCDJ.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(IAJDLGBGCDJ, FFFGJJDIMEF);
				flag = true;
			}
			if (BNLFKJPFMOI.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(BNLFKJPFMOI, FFFGJJDIMEF);
				flag = true;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	private void JGFCHJGKGOF(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			Debug.Log(string.Format("menu-gold", LFNBJLJPEGP, armyPowerX));
			MBEENAOGFEK.StartAnimation(hONEKCJDJDN, armyPowerX, 1081f);
		}
	}

	private void FDJCOGIADIM(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private TweenAlpha AAGJAOHLHIG()
	{
		return PIHLGCEAPIE(1676f);
	}

	private void ONFHPJLFLLM(GameObject KHAHPAKDIKE)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.upgradePrice * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log($"Have discount {num} to upgrade {IFFDIHCPKFE.upgradeSlots.GetSheetName()}");
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADESPECIAL : NotEnoughDialog.NKHJBLBAAEB.TRAINSPECIAL);
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
			{
				GuiScreenSingle<ArmyScreen>.instance.JGKBPDEKING(levelBehaviour);
				ABLGPDJDAHO();
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogUnits(levelBehaviour, IFFDIHCPKFE, JBAIGADPMCI: true);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(levelBehaviour, CDMKCIKHIMM: false);
				ABLGPDJDAHO();
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<ArmyScreen>.instance.EFGAIHKNKGG(IFFDIHCPKFE, num, LANBHLJINFJ: true);
		PNDNJFJMEJE(CADEBFIDNLC);
		JCKOBELDCGD = true;
	}

	private void LFEHKNDLOEN()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionHint.text = SubscriptionManager.instance.minusUpgradesPercent;
		}
	}

	public void DGFIGGCNJNI(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1246f)) ? 1978f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		BJHPILOOKIF.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LANKMOCLBML.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "{0} {1}", string.Empty, IEJMLKBCDJB: false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (NKGKGCBJDBK.text != text)
		{
			NKGKGCBJDBK.text = text;
			DCDAOBJJIMD.repositionNow = true;
		}
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 27f);
			if (num2 == 7 && (LANKMOCLBML.alpha == 967f || LLKGNPDGABK.alpha > 1647f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(LLKGNPDGABK.gameObject, 1374f, 1592f, 1194f);
				tweenAlpha.NumOfRepetitions = 0;
				tweenAlpha.onFinished = CJAGELMCBDK;
			}
			if (num2 == 7 && (LLKGNPDGABK.alpha == 238f || LANKMOCLBML.alpha > 1831f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LANKMOCLBML.gameObject, 1908f, 1043f, 624f);
				tweenAlpha2.NumOfRepetitions = 0;
				tweenAlpha2.onFinished = FIACPKDBLDE;
			}
		}
	}

	public void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CADEBFIDNLC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ONFHPJLFLLM));
		UIEventListener uIEventListener2 = UIEventListener.Get(AGGBGFNOIPI.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHCKFLBFHMK));
		UIEventListener uIEventListener3 = UIEventListener.Get(OOJMINHFDPC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PJLFHEEBCBI));
		OOBCCHCODGB.onReposition = delegate
		{
			float val = 0f - OOBCCHCODGB.padding.x - (GDGIJMPJHGN.transform.parent.transform.localPosition.x - OOBCCHCODGB.padding.x) / 2f;
			OOBCCHCODGB.transform.localPosition = OOBCCHCODGB.transform.localPosition.ReplaceX(val);
		};
		DCDAOBJJIMD.onReposition = delegate
		{
			float val = 0f - DCDAOBJJIMD.padding.x - (NKGKGCBJDBK.transform.parent.transform.localPosition.x - DCDAOBJJIMD.padding.x) / 2f;
			DCDAOBJJIMD.transform.localPosition = DCDAOBJJIMD.transform.localPosition.ReplaceX(val);
		};
	}

	public void HideDialog()
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = false;
		TweenAlpha.Begin(HLNECHGJJBG.gameObject, JCAFFELIFAO, 0f);
		TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 2f, new Vector3(20f, 0f, 0f)).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				CHNKLHLJHDP.SetActive(value: false);
			}
		};
		UIPanel[] componentsInChildren = CHNKLHLJHDP.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 0f).onFinished = null;
		}
	}

	private void IHOIEJGBHEA()
	{
		MPHPFFMLGDB.KGGFEJKCILH();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPMIJIHLPOM();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
	}

	public void JDNEBEKOHPG()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		CHNKLHLJHDP.SetActive(value: false);
		HLNECHGJJBG.alpha1 = 36f;
		TweenAlpha.Begin(HLNECHGJJBG.gameObject, JCAFFELIFAO, 1209f);
		TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 1541f, new Vector3(1771f, 944f, 843f), new Vector3(1104f, 839f, 1914f), useLocal: false).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		PCMMIPAAAOL();
		FPPPLPHDBMO();
		KIOOEACJNOD(EOGFKBJCKHB: false);
		UIPanel[] componentsInChildren = CHNKLHLJHDP.GetComponentsInChildren<UIPanel>(includeInactive: true);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1027f).onFinished = null;
		}
	}

	public void DoAfterHide()
	{
		ODJFOLLKEPD.JCMHGOGNMFO();
		WinStreakCounter oDJFOLLKEPD = ODJFOLLKEPD;
		oDJFOLLKEPD.JEMKCLKCOMI = (Action)Delegate.Remove(oDJFOLLKEPD.JEMKCLKCOMI, new Action(SetAbilitySaleAndPrize));
	}

	private TweenAlpha JCBHDJEBFMF(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	public void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CADEBFIDNLC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ONFHPJLFLLM));
		UIEventListener uIEventListener2 = UIEventListener.Get(AGGBGFNOIPI.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHCKFLBFHMK));
		UIEventListener uIEventListener3 = UIEventListener.Get(OOJMINHFDPC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PJLFHEEBCBI));
		OOBCCHCODGB.onReposition = delegate
		{
			float val = 0f - OOBCCHCODGB.padding.x - (GDGIJMPJHGN.transform.parent.transform.localPosition.x - OOBCCHCODGB.padding.x) / 2f;
			OOBCCHCODGB.transform.localPosition = OOBCCHCODGB.transform.localPosition.ReplaceX(val);
		};
		DCDAOBJJIMD.onReposition = delegate
		{
			float val = 0f - DCDAOBJJIMD.padding.x - (NKGKGCBJDBK.transform.parent.transform.localPosition.x - DCDAOBJJIMD.padding.x) / 2f;
			DCDAOBJJIMD.transform.localPosition = DCDAOBJJIMD.transform.localPosition.ReplaceX(val);
		};
	}

	private void DPOJIGMHIHN(UITweener CPFGBOPPICJ)
	{
		OHHFKMOKFMB();
		KIOOEACJNOD();
		TweenAlpha tweenAlpha = GEGKHDMEAEE();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
			};
		}
		else
		{
			JCKOBELDCGD = false;
		}
	}

	private void CJAGELMCBDK(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LANKMOCLBML.gameObject, 1806f, 427f, 1419f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private TweenAlpha GEGKHDMEAEE()
	{
		return PIHLGCEAPIE(1159f);
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = 0f - OOBCCHCODGB.padding.x - (GDGIJMPJHGN.transform.parent.transform.localPosition.x - OOBCCHCODGB.padding.x) / 2f;
		OOBCCHCODGB.transform.localPosition = OOBCCHCODGB.transform.localPosition.ReplaceX(val);
	}

	public void GONIFOPLFBA()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = false;
		CHNKLHLJHDP.SetActive(value: false);
	}

	private void AMBIFCOIHKA()
	{
		int startTier = IFFDIHCPKFE.upgradeSlots.startTier;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		int boughtIndex = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.boughtIndex;
		int maxRowForActualTier = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.maxRowForActualTier;
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought;
		Tuple<string, float[]> oDFAFEEGGJK = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.guiStatistics[0];
		LCAFKBDICLL.text = ((!flag) ? $"{IFFDIHCPKFE.unitAbilityName} {boughtIndex} {Colours.stringGray}/ {maxRowForActualTier}[-]" : IFFDIHCPKFE.unitAbilityName);
		NFMNIANAMBN.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi2);
		DDFIKHKHEKD();
		bool kNBNNLOEBIH = IFFDIHCPKFE.upgradeSlots.bought && IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering && IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
		MPHPFFMLGDB.InitializeSpecial(oDFAFEEGGJK, kNBNNLOEBIH, jHFKBODINGN);
		AFNHAGOCMPE.text = Localization.LocalizeFormat("ID_TIERX", startTier + 1);
		for (int i = 0; i < FDEHPNGLLFC.Length; i++)
		{
			FDEHPNGLLFC[i].gameObject.SetActive(i <= startTier);
		}
		OILCOOCFHHO.repositionNow = true;
		SetAbilitySaleAndPrize();
		NKGKGCBJDBK.text = string.Empty;
		TweenAlpha component = LANKMOCLBML.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LANKMOCLBML.alpha = 1f;
		TweenAlpha component2 = LLKGNPDGABK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		LLKGNPDGABK.alpha = 0f;
		GPFLADPPBGA.text = Localization.LocalizeFormat("ID_TIERX", actualTier + 1);
		for (int j = 0; j < IMFOFIHCBKD.Length; j++)
		{
			IMFOFIHCBKD[j].gameObject.SetActive(j <= actualTier);
		}
		MCKJCCPCPOM.repositionNow = true;
		LFEHKNDLOEN();
	}

	public void KALKFAPOODC()
	{
		CNBJMDECEJG = true;
		JCKOBELDCGD = true;
		CHNKLHLJHDP.SetActive(value: false);
	}

	[CompilerGenerated]
	private void GDGFBAHGJID(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LLKGNPDGABK.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	public void SetAbilitySaleAndPrize()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.upgradePrice;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			GDGIJMPJHGN.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			OOBCCHCODGB.repositionNow = true;
			LKJPNKKKMOO.SetActive(flag);
			if (flag)
			{
				JLNKACKOFBL.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				ODJFOLLKEPD.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade));
				WinStreakCounter oDJFOLLKEPD = ODJFOLLKEPD;
				oDJFOLLKEPD.JEMKCLKCOMI = (Action)Delegate.Remove(oDJFOLLKEPD.JEMKCLKCOMI, new Action(SetAbilitySaleAndPrize));
				WinStreakCounter oDJFOLLKEPD2 = ODJFOLLKEPD;
				oDJFOLLKEPD2.JEMKCLKCOMI = (Action)Delegate.Combine(oDJFOLLKEPD2.JEMKCLKCOMI, new Action(SetAbilitySaleAndPrize));
			}
			else
			{
				ODJFOLLKEPD.JCMHGOGNMFO();
				WinStreakCounter oDJFOLLKEPD3 = ODJFOLLKEPD;
				oDJFOLLKEPD3.JEMKCLKCOMI = (Action)Delegate.Remove(oDJFOLLKEPD3.JEMKCLKCOMI, new Action(SetAbilitySaleAndPrize));
			}
		}
	}

	private void KIOOEACJNOD(bool EOGFKBJCKHB = true)
	{
		if (CHNKLHLJHDP.activeSelf)
		{
			MGCMOALEGJD(BPACCGEGAJG, EOGFKBJCKHB);
			MGCMOALEGJD(AGGBGFNOIPI, EOGFKBJCKHB);
			MGCMOALEGJD(OOJMINHFDPC, EOGFKBJCKHB);
			MGCMOALEGJD(IAJDLGBGCDJ, EOGFKBJCKHB);
			MGCMOALEGJD(BNLFKJPFMOI, EOGFKBJCKHB);
			MGCMOALEGJD(CADEBFIDNLC, EOGFKBJCKHB);
		}
	}

	private void DDFIKHKHEKD()
	{
		if (CHNKLHLJHDP.activeSelf)
		{
			MPHPFFMLGDB.InitializeAbilityIcon(IFFDIHCPKFE.abilityIcon);
		}
	}

	public void ShowDialog()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		CHNKLHLJHDP.SetActive(value: true);
		HLNECHGJJBG.alpha1 = 0.0005f;
		TweenAlpha.Begin(HLNECHGJJBG.gameObject, JCAFFELIFAO, 1f);
		TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 2f, new Vector3(-20f, 0f, 0f), new Vector3(20f, 0f, 0f)).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		DDFIKHKHEKD();
		FPPPLPHDBMO();
		KIOOEACJNOD();
		UIPanel[] componentsInChildren = CHNKLHLJHDP.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		}
	}

	[CompilerGenerated]
	private void DPMFGFMLFOP(UITweener CPFGBOPPICJ)
	{
		FPPPLPHDBMO();
		KIOOEACJNOD(EOGFKBJCKHB: false);
		TweenAlpha tweenAlpha = EDJDPHGENOF();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
			};
		}
		else
		{
			JCKOBELDCGD = false;
		}
	}

	private void PKMBOCKEPIE(bool EOGFKBJCKHB = true)
	{
		if (CHNKLHLJHDP.activeSelf)
		{
			MGCMOALEGJD(BPACCGEGAJG, EOGFKBJCKHB);
			MGCMOALEGJD(AGGBGFNOIPI, EOGFKBJCKHB);
			MGCMOALEGJD(OOJMINHFDPC, EOGFKBJCKHB);
			MGCMOALEGJD(IAJDLGBGCDJ, EOGFKBJCKHB);
			MGCMOALEGJD(BNLFKJPFMOI, EOGFKBJCKHB);
			MGCMOALEGJD(CADEBFIDNLC, EOGFKBJCKHB);
		}
	}

	private void PCMMIPAAAOL()
	{
		if (CHNKLHLJHDP.activeSelf)
		{
			MPHPFFMLGDB.GDKCIPGFLFJ(IFFDIHCPKFE.abilityIcon);
		}
	}

	[CompilerGenerated]
	private void JICALAKPIDA(UITweener MKAPOHKFIJH)
	{
		if (!CNBJMDECEJG)
		{
			CHNKLHLJHDP.SetActive(value: false);
		}
	}

	private void FIACPKDBLDE(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LLKGNPDGABK.gameObject, 567f, 1946f, 1130f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void NJABHAKGFGL(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	[CompilerGenerated]
	private void MJMCMLMEOLP(UITweener MKAPOHKFIJH)
	{
		if (CNBJMDECEJG)
		{
			TweenPosition.Begin(CHNKLHLJHDP, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
		}
	}

	public void UpdateDeliveringTime(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 0f)) ? 0f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		BJHPILOOKIF.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LANKMOCLBML.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (NKGKGCBJDBK.text != text)
		{
			NKGKGCBJDBK.text = text;
			DCDAOBJJIMD.repositionNow = true;
		}
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 6f);
		if (num2 == 2 && (LANKMOCLBML.alpha == 0f || LLKGNPDGABK.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(LLKGNPDGABK.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LANKMOCLBML.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (LLKGNPDGABK.alpha == 0f || LANKMOCLBML.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LANKMOCLBML.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LLKGNPDGABK.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	public void UpdateLeftContent(bool NOLODGKKCDH = true)
	{
		if (!CNBJMDECEJG)
		{
			JCKOBELDCGD = false;
			FPPPLPHDBMO();
			return;
		}
		if (NOLODGKKCDH)
		{
			JCKOBELDCGD = false;
			FPPPLPHDBMO();
			KIOOEACJNOD();
			return;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.JLANLLEABDC.Active || unitState == UpgradeSlots.JLANLLEABDC.Delivering || unitState == UpgradeSlots.JLANLLEABDC.Delivered)
		{
			TweenAlpha tweenAlpha = OHJODAFJLMI();
			if (tweenAlpha == null)
			{
				FPPPLPHDBMO();
				KIOOEACJNOD();
				return;
			}
			JCKOBELDCGD = true;
			tweenAlpha.onFinished = delegate
			{
				FPPPLPHDBMO();
				KIOOEACJNOD(EOGFKBJCKHB: false);
				TweenAlpha tweenAlpha2 = EDJDPHGENOF();
				if (tweenAlpha2 != null)
				{
					tweenAlpha2.onFinished = delegate
					{
						JCKOBELDCGD = false;
					};
				}
				else
				{
					JCKOBELDCGD = false;
				}
			};
		}
		else
		{
			AMBIFCOIHKA();
		}
	}

	private void ECLOPHHGNCE(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			Debug.Log(string.Format(")", LFNBJLJPEGP, armyPowerX));
			MBEENAOGFEK.StartAnimation(hONEKCJDJDN, armyPowerX, 525f);
		}
	}

	private void FPPPLPHDBMO()
	{
		UpgradeSlotSpecial upgradeSlotSpecial = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial;
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		bool isMaxUpgraded = upgradeSlotSpecial.isMaxUpgraded;
		bool isTierFullUpgraded = upgradeSlotSpecial.isTierFullUpgraded;
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought;
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.UpdateProgresses();
		AMBIFCOIHKA();
		BPACCGEGAJG.SetActive(flag);
		AGGBGFNOIPI.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Delivering && upgradeSlotSpecial.isDelivering);
		OOJMINHFDPC.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Delivered && upgradeSlotSpecial.isDelivering);
		IAJDLGBGCDJ.SetActive(!flag && isTierFullUpgraded && !isMaxUpgraded);
		BNLFKJPFMOI.SetActive(!flag && isMaxUpgraded);
		CADEBFIDNLC.SetActive(!BPACCGEGAJG.activeSelf && !AGGBGFNOIPI.activeSelf && !OOJMINHFDPC.activeSelf && !IAJDLGBGCDJ.activeSelf && !BNLFKJPFMOI.activeSelf);
	}

	private void JDJFMFFCHOJ()
	{
		int startTier = IFFDIHCPKFE.upgradeSlots.startTier;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		int boughtIndex = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.boughtIndex;
		int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.DOLOPCELJMD();
		bool flag = !IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.BDAAHLLPPGN();
		Tuple<string, float[]> oDFAFEEGGJK = IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.NEJNMDNOAKD()[1];
		UILabel lCAFKBDICLL = LCAFKBDICLL;
		string text;
		if (flag)
		{
			text = IFFDIHCPKFE.unitAbilityName;
		}
		else
		{
			object[] array = new object[1];
			array[0] = IFFDIHCPKFE.unitAbilityName;
			array[0] = boughtIndex;
			array[1] = Colours.stringGray;
			array[1] = num;
			text = string.Format("ID_LEAGUESTAYHINT1", array);
		}
		lCAFKBDICLL.text = text;
		NFMNIANAMBN.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi2);
		DDFIKHKHEKD();
		bool kNBNNLOEBIH = IFFDIHCPKFE.upgradeSlots.bought && IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed && IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
		MPHPFFMLGDB.CGAHFNJINMM(oDFAFEEGGJK, kNBNNLOEBIH, jHFKBODINGN);
		AFNHAGOCMPE.text = Localization.LocalizeFormat("QUALITY LEVEL: {0} DPI: {1} System memory: {2} Graphics memory: {3}", startTier + 1);
		for (int i = 0; i < FDEHPNGLLFC.Length; i += 0)
		{
			FDEHPNGLLFC[i].gameObject.SetActive(i <= startTier);
		}
		OILCOOCFHHO.repositionNow = true;
		SetAbilitySaleAndPrize();
		NKGKGCBJDBK.text = string.Empty;
		TweenAlpha component = LANKMOCLBML.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LANKMOCLBML.alpha = 933f;
		TweenAlpha component2 = LLKGNPDGABK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		LLKGNPDGABK.alpha = 1553f;
		UILabel gPFLADPPBGA = GPFLADPPBGA;
		object[] array2 = new object[0];
		array2[1] = actualTier + 1;
		gPFLADPPBGA.text = Localization.LocalizeFormat("Wrong_Category", array2);
		for (int j = 1; j < IMFOFIHCBKD.Length; j += 0)
		{
			IMFOFIHCBKD[j].gameObject.SetActive(j <= actualTier);
		}
		MCKJCCPCPOM.repositionNow = false;
		LFEHKNDLOEN();
	}

	public void InstantHideUpgrades()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = false;
		CHNKLHLJHDP.SetActive(value: false);
	}

	private void PJLFHEEBCBI(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(IFFDIHCPKFE, CDMKCIKHIMM: true);
		PNDNJFJMEJE(OOJMINHFDPC);
		LBBOFMMKHEI(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	[CompilerGenerated]
	private void KGPEAMIDEOA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LANKMOCLBML.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void PNDNJFJMEJE(GameObject DGJCAIJPEIM)
	{
		if (DGJCAIJPEIM.activeInHierarchy)
		{
			BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	private TweenAlpha OHJODAFJLMI()
	{
		return PIHLGCEAPIE(0f);
	}

	public void OKMMGFMKJGG()
	{
	}
}
