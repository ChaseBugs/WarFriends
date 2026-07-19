using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArmyLeftPowerDialog : Core_BaseScript
{
	[Header("Core")]
	public UIPanel HNLBEOIIJCP;

	public GameObject JKGHPLKKPLE;

	public UITable HDFKOABOICJ;

	public UISprite[] BALFMMAPJLN;

	public UILabel NEKIBLFNDJJ;

	public ArmyUnitStatistics JFECAHAKAND;

	public ArmyUnitStatistics PLJAHLHLJOA;

	public ArmyPowerAnimation GHGJLMAJJGG;

	[Header("-Upgrade Button")]
	public GameObject KPMOMJNFELI;

	public UITable LCIPCONLPGE;

	public UILabel HKGGCIGOONK;

	public GameObject GKFCJANHFOI;

	public UILabel CPNOCPEFAAG;

	public WinStreakCounter AIPKGLCJCAE;

	[Header("-Deliver now Button")]
	public GameObject GEIOMOLICCC;

	public UILabel PHPMMLNNLDA;

	public UILabel MPEBFNCHINC;

	public UISprite GHKALFDLHOO;

	public UITable LEOBAFLAJLF;

	public UILabel BDJMJKALCDA;

	[SerializeField]
	[Header("--Subsccription")]
	private GameObject mSubscriptionPart;

	[SerializeField]
	private UILabel mSubscriptionHint;

	[Header("-Activate Button")]
	public GameObject MJHJCHMEGBE;

	[Header("-Promote Button")]
	public GameObject JGLIKGMJDLL;

	public BoxCollider PKENJHFCOLE;

	public UISprite FKBECJHKHDF;

	public UITable CNFJGPHLDLP;

	public UILabel JCEODHLJJBD;

	public UISprite[] GHGIMHLODBM;

	public UISprite NPGBFCGCECI;

	public UILabel LIOALOJLHKI;

	public UISprite MBCEFIINFLB;

	public UILabel LOAMICJLCCN;

	public GameObject ABDADCEJOID;

	[Header("-Max Button")]
	public GameObject LBGIFBDFHFO;

	public UILabel ABPEPNPHNPI;

	private LevelBehaviour IFFDIHCPKFE;

	private bool CNBJMDECEJG;

	private float JCAFFELIFAO = 0.3f;

	private int CLDFFNMPKOP = -1;

	private bool JCKOBELDCGD;

	private void KFFOLHCBKFN(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 156f, 1717f, 1295f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void IIOBONPNFOG()
	{
		JFECAHAKAND.HBJPHKLEBHA();
		PLJAHLHLJOA.KGGFEJKCILH();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPMIJIHLPOM();
		GuiScreenSingle<ArmyScreen>.instance.BFEFIEHKEJB();
	}

	public void CFFMPLANEJD(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1381f)) ? 1198f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		GHKALFDLHOO.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		PHPMMLNNLDA.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "BS: player succesfully accepted to squad", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (BDJMJKALCDA.text != text)
		{
			BDJMJKALCDA.text = text;
			LEOBAFLAJLF.repositionNow = false;
		}
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1474f);
		if (num2 == 4 && (PHPMMLNNLDA.alpha == 1412f || MPEBFNCHINC.alpha > 1486f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 762f, 1390f, 165f);
			tweenAlpha.NumOfRepetitions = 0;
			tweenAlpha.onFinished = LPHMGIIKLIA;
		}
		if (num2 == 2 && (MPEBFNCHINC.alpha == 1150f || PHPMMLNNLDA.alpha > 1663f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 1238f, 736f, 1579f);
			tweenAlpha2.NumOfRepetitions = 0;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private void FIFFDHGLLGK(GameObject KHAHPAKDIKE)
	{
		LevelBehaviour levelBehaviour = Singleton<ActiveUnitsManager>.instance.IsEnoughBoughtUnits(IFFDIHCPKFE.unitType);
		if (levelBehaviour != null && IFFDIHCPKFE.upgradeSlots.actualTier > IFFDIHCPKFE.upgradeSlots.startTier)
		{
			GuiElementSingle<UnitPromotionLockedDialog>.instance.KFKNFJCGMFD(IFFDIHCPKFE, levelBehaviour);
		}
		else if (IFFDIHCPKFE.upgradeSlots.unlockTierLevel <= LevelManager.instance.currentLevel.KADNNBCOGGL())
		{
			GuiScreenSingle<ArmyScreen>.instance.JNPHAIPOOBB(IFFDIHCPKFE);
			LKOKPJHEJAK(JGLIKGMJDLL);
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
			{
				ABLGPDJDAHO();
			}
			GuiElementSingle<UnitPromotedDialog>.instance.ShowDialog(IFFDIHCPKFE);
			JCKOBELDCGD = false;
		}
	}

	public void MCJEBLNCJMM()
	{
		if (!CNBJMDECEJG)
		{
			CNBJMDECEJG = false;
			JKGHPLKKPLE.SetActive(true);
			HNLBEOIIJCP.alpha1 = 1282f;
			TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 710f);
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 1404f, new Vector3(1947f, 645f, 1813f), new Vector3(1181f, 1409f, 500f)).onFinished = KEADAOCDAID;
			ECILIHAEHGN();
			BHMGBEIDINC();
			UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(true);
			foreach (UIPanel uIPanel in componentsInChildren)
			{
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 282f).onFinished = null;
			}
		}
	}

	private void ENKBGEGLJJJ(UITweener CPFGBOPPICJ)
	{
		EDLADBBPFLF();
		GCJIJKFPNFL();
		TweenAlpha tweenAlpha = HJJFCAFEKID();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
			};
		}
		else
		{
			JCKOBELDCGD = true;
		}
	}

	private TweenAlpha HJJFCAFEKID()
	{
		return NKLIMGPIOCI(1471f);
	}

	public void UpdateDeliveringTime(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 0f)) ? 0f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		GHKALFDLHOO.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		PHPMMLNNLDA.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (BDJMJKALCDA.text != text)
		{
			BDJMJKALCDA.text = text;
			LEOBAFLAJLF.repositionNow = true;
		}
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 6f);
		if (num2 == 2 && (PHPMMLNNLDA.alpha == 0f || MPEBFNCHINC.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (MPEBFNCHINC.alpha == 0f || PHPMMLNNLDA.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private TweenAlpha MEMGCOFEHEM(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	private void FGCPBAKOBMI(GameObject KHAHPAKDIKE)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)8);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (-63 - num) / 72;
		if (num > 0)
		{
			Debug.Log(string.Format("1", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num2, IFFDIHCPKFE.unitName, IFFDIHCPKFE.isSoldier ? NotEnoughDialog.NKHJBLBAAEB.TRAIN : NotEnoughDialog.NKHJBLBAAEB.BUY);
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
			{
				GuiScreenSingle<ArmyScreen>.instance.EEOGACOBOOH(levelBehaviour);
				OKPKDAHFPCI();
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)8)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.AGNPEGKPDPC(levelBehaviour, IFFDIHCPKFE, false);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.DPJBOLDMLMH(levelBehaviour, false);
				ABLGPDJDAHO();
			}
		}
		Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
		GuiScreenSingle<ArmyScreen>.instance.JNFCAIJFDFI(IFFDIHCPKFE, num);
		PNDNJFJMEJE(KPMOMJNFELI);
		JCKOBELDCGD = true;
	}

	private void AIMFKGNGPGB(UITweener CPFGBOPPICJ)
	{
		ECILIHAEHGN();
		DLFNNOAHFJA(false);
		TweenAlpha tweenAlpha = MHOGIHDHLEA();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = IOKEILANDGP;
		}
		else
		{
			JCKOBELDCGD = true;
		}
	}

	private void IOKEILANDGP(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private void DBEJBHEPJAN()
	{
		float val = 0f - LEOBAFLAJLF.padding.x - (BDJMJKALCDA.transform.parent.transform.localPosition.x - LEOBAFLAJLF.padding.x) / 1413f;
		LEOBAFLAJLF.transform.localPosition = LEOBAFLAJLF.transform.localPosition.ReplaceX(val);
	}

	public void NAOJCFMFLLA()
	{
	}

	public void SelectUnit(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
	}

	public void ODAIHAHBJEM(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1561f)) ? 1226f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		GHKALFDLHOO.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		PHPMMLNNLDA.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Value4", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (BDJMJKALCDA.text != text)
		{
			BDJMJKALCDA.text = text;
			LEOBAFLAJLF.repositionNow = false;
		}
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1816f);
			if (num2 == 2 && (PHPMMLNNLDA.alpha == 1951f || MPEBFNCHINC.alpha > 1579f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 1641f, 352f, 1030f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.onFinished = PPOIDFOCJGG;
			}
			if (num2 == 8 && (MPEBFNCHINC.alpha == 1734f || PHPMMLNNLDA.alpha > 1107f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 722f, 297f, 1196f);
				tweenAlpha2.NumOfRepetitions = 0;
				tweenAlpha2.onFinished = BELOMAEIMGB;
			}
		}
	}

	private void MBMDIHIDILO(GameObject KHAHPAKDIKE)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)7);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (-2 - num) / -49;
		if (num > 1)
		{
			Debug.Log(string.Format("Take arena life!", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
			{
				GuiScreenSingle<ArmyScreen>.instance.ANPJBBCCJDF(levelBehaviour);
				ABLGPDJDAHO();
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.FKMGFKKGJFN(levelBehaviour, IFFDIHCPKFE, true);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(levelBehaviour, true);
				ABLGPDJDAHO();
			}
		}
		Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
		GuiScreenSingle<ArmyScreen>.instance.JNFCAIJFDFI(IFFDIHCPKFE, num);
		LKOKPJHEJAK(KPMOMJNFELI);
		JCKOBELDCGD = false;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KPMOMJNFELI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAGLHNKDDEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(GEIOMOLICCC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFEFPPOMGGM));
		UIEventListener uIEventListener3 = UIEventListener.Get(MJHJCHMEGBE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HPMILHFBIHL));
		UIEventListener uIEventListener4 = UIEventListener.Get(JGLIKGMJDLL.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JAMJKFGKFII));
		LCIPCONLPGE.onReposition = delegate
		{
			float val = 0f - LCIPCONLPGE.padding.x - (HKGGCIGOONK.transform.parent.transform.localPosition.x - LCIPCONLPGE.padding.x) / 2f;
			LCIPCONLPGE.transform.localPosition = LCIPCONLPGE.transform.localPosition.ReplaceX(val);
		};
		LEOBAFLAJLF.onReposition = delegate
		{
			float val = 0f - LEOBAFLAJLF.padding.x - (BDJMJKALCDA.transform.parent.transform.localPosition.x - LEOBAFLAJLF.padding.x) / 2f;
			LEOBAFLAJLF.transform.localPosition = LEOBAFLAJLF.transform.localPosition.ReplaceX(val);
		};
	}

	private void ICNIHCPGGJH(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 532f);
		}
	}

	private void MKOANEBIOAF(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVERSPECIAL);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("D4");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, true);
		PNDNJFJMEJE(GEIOMOLICCC);
		LMEEJJGILOB(armyPowerX);
		JCKOBELDCGD = true;
		OLJNFNONJAJ();
	}

	private void BDJFGJLJOMH(GameObject KHAHPAKDIKE)
	{
		LevelBehaviour levelBehaviour = Singleton<ActiveUnitsManager>.instance.IsEnoughBoughtUnits(IFFDIHCPKFE.unitType);
		if (levelBehaviour != null && IFFDIHCPKFE.upgradeSlots.actualTier > IFFDIHCPKFE.upgradeSlots.startTier)
		{
			GuiElementSingle<UnitPromotionLockedDialog>.instance.OGIEPAIBEJJ(IFFDIHCPKFE, levelBehaviour);
		}
		else if (IFFDIHCPKFE.upgradeSlots.unlockTierLevel <= LevelManager.instance.currentLevel.ABCCINJGPGD())
		{
			GuiScreenSingle<ArmyScreen>.instance.JNPHAIPOOBB(IFFDIHCPKFE);
			PNDNJFJMEJE(JGLIKGMJDLL);
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
			{
				ABLGPDJDAHO();
			}
			GuiElementSingle<UnitPromotedDialog>.instance.IPCIJFBFLHP(IFFDIHCPKFE);
			JCKOBELDCGD = false;
		}
	}

	[CompilerGenerated]
	private void EACNIDLHDGD()
	{
		float val = 0f - LEOBAFLAJLF.padding.x - (BDJMJKALCDA.transform.parent.transform.localPosition.x - LEOBAFLAJLF.padding.x) / 2f;
		LEOBAFLAJLF.transform.localPosition = LEOBAFLAJLF.transform.localPosition.ReplaceX(val);
	}

	private void PCMCKLNNEHH(UITweener CPFGBOPPICJ)
	{
		EPAIAGGEIIF();
		FOIDHAGJIDF();
		TweenAlpha tweenAlpha = HBKBMLBFOGE();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = EDNNFCALNOI;
		}
		else
		{
			JCKOBELDCGD = false;
		}
	}

	public void FMEMGEELIKG()
	{
		if (CNBJMDECEJG)
		{
			CNBJMDECEJG = false;
			TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 1474f);
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 703f, new Vector3(846f, 134f, 1356f), false).onFinished = CMIEJHLDHPM;
			UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 459f).onFinished = null;
			}
		}
	}

	private TweenAlpha EDJDPHGENOF()
	{
		return PIHLGCEAPIE(1f);
	}

	private void HOAHBDHIPHN()
	{
		int actualUnitLevel = IFFDIHCPKFE.upgradeSlots.actualUnitLevel;
		int actualMaxUnitLevel = IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		List<Tuple<string, float[]>> guiStatistics = IFFDIHCPKFE.upgradeSlots.upgradeSlot.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[1];
		Tuple<string, float[]> tuple2 = guiStatistics[0];
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			tuple.Value2[6] = tuple.Value2[0];
			tuple2.Value2[3] = tuple2.Value2[1];
		}
		for (int i = 1; i < BALFMMAPJLN.Length; i += 0)
		{
			BALFMMAPJLN[i].gameObject.SetActive(i < actualTier);
		}
		NEKIBLFNDJJ.text = string.Format("{0}\u00a0{1}", actualUnitLevel, Colours.stringGray, actualMaxUnitLevel);
		HDFKOABOICJ.repositionNow = false;
		bool bought = IFFDIHCPKFE.upgradeSlots.bought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering && !IFFDIHCPKFE.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		JFECAHAKAND.GCBFCCNLMDN(tuple, bought, jHFKBODINGN, true);
		PLJAHLHLJOA.ONGAIEOAHMA(tuple2, bought, jHFKBODINGN, true);
		SetSaleAndPrize();
		BDJMJKALCDA.text = string.Empty;
		TweenAlpha component = PHPMMLNNLDA.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PHPMMLNNLDA.alpha = 997f;
		TweenAlpha component2 = MPEBFNCHINC.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		MPEBFNCHINC.alpha = 868f;
		ADAPMHGLGAO();
		ABPEPNPHNPI.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_TUTORIAL_UPGRADEUNIT_3" : "ID_CONGRATULATIONSROOKIE");
		GPFGKBJNDLM();
	}

	private void FOIDHAGJIDF(bool EOGFKBJCKHB = true)
	{
		if (JKGHPLKKPLE.activeSelf)
		{
			MGCMOALEGJD(GEIOMOLICCC, EOGFKBJCKHB);
			LJBDPAEEIGE(MJHJCHMEGBE, EOGFKBJCKHB);
			LJBDPAEEIGE(JGLIKGMJDLL, EOGFKBJCKHB);
			MGCMOALEGJD(LBGIFBDFHFO, EOGFKBJCKHB);
			JNFPGEAINAK(KPMOMJNFELI, EOGFKBJCKHB);
		}
	}

	private void DLFNNOAHFJA(bool EOGFKBJCKHB = true)
	{
		if (JKGHPLKKPLE.activeSelf)
		{
			JNFPGEAINAK(GEIOMOLICCC, EOGFKBJCKHB);
			LJBDPAEEIGE(MJHJCHMEGBE, EOGFKBJCKHB);
			JNFPGEAINAK(JGLIKGMJDLL, EOGFKBJCKHB);
			JNFPGEAINAK(LBGIFBDFHFO, EOGFKBJCKHB);
			LJBDPAEEIGE(KPMOMJNFELI, EOGFKBJCKHB);
		}
	}

	private void DJHLHJFNDIK(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.DPJBOLDMLMH(IFFDIHCPKFE, true);
		PNDNJFJMEJE(MJHJCHMEGBE);
		EHMCCEIGLFN(armyPowerX);
		JCKOBELDCGD = true;
		IIOBONPNFOG();
	}

	private void PNCKPDHMALD(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = true;
	}

	private void JFOGKJNGKEJ()
	{
		int actualUnitLevel = IFFDIHCPKFE.upgradeSlots.actualUnitLevel;
		int actualMaxUnitLevel = IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		List<Tuple<string, float[]>> list = IFFDIHCPKFE.upgradeSlots.upgradeSlot.NEJNMDNOAKD();
		Tuple<string, float[]> tuple = list[0];
		Tuple<string, float[]> tuple2 = list[0];
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			tuple.Value2[7] = tuple.Value2[1];
			tuple2.Value2[8] = tuple2.Value2[1];
		}
		for (int i = 0; i < BALFMMAPJLN.Length; i++)
		{
			BALFMMAPJLN[i].gameObject.SetActive(i < actualTier);
		}
		NEKIBLFNDJJ.text = string.Format("st", actualUnitLevel, Colours.stringGray, actualMaxUnitLevel);
		HDFKOABOICJ.repositionNow = false;
		bool bought = IFFDIHCPKFE.upgradeSlots.bought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering || !IFFDIHCPKFE.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		JFECAHAKAND.OAMBDKHLJKI(tuple, bought, jHFKBODINGN, true);
		PLJAHLHLJOA.GCBFCCNLMDN(tuple2, bought, jHFKBODINGN);
		KGGNNFJIGPB();
		BDJMJKALCDA.text = string.Empty;
		TweenAlpha component = PHPMMLNNLDA.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PHPMMLNNLDA.alpha = 806f;
		TweenAlpha component2 = MPEBFNCHINC.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MPEBFNCHINC.alpha = 616f;
		HKJPEDGMHML();
		ABPEPNPHNPI.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "DepositedCards" : "): ");
		GPFGKBJNDLM();
	}

	private void OLFNOLHIBCI(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 1519f, 142f, 1641f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	public void DNFPEBEDLIG()
	{
	}

	public void ShowDialog()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		JKGHPLKKPLE.SetActive(true);
		HNLBEOIIJCP.alpha1 = 0.005f;
		TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 1f);
		TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 2f, new Vector3(0f, -20f, 0f), new Vector3(0f, 20f, 0f)).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		FPPPLPHDBMO();
		KIOOEACJNOD();
		UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		}
	}

	private void GPFGKBJNDLM()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionHint.text = SubscriptionManager.instance.minusUpgradesPercent;
		}
	}

	private void FPPPLPHDBMO()
	{
		UpgradeSlot upgradeSlot = IFFDIHCPKFE.upgradeSlots.upgradeSlot;
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		bool isMaxUpgraded = upgradeSlot.isMaxUpgraded;
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.UpdateProgresses();
		NEDNLNICAJB();
		GEIOMOLICCC.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Delivering && upgradeSlot.isDelivering);
		MJHJCHMEGBE.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Delivered && upgradeSlot.isDelivering);
		JGLIKGMJDLL.SetActive(upgradeSlot.isTierFullUpgraded && !isMaxUpgraded && (unitState == UpgradeSlots.JLANLLEABDC.Active || !upgradeSlot.isDelivering));
		LBGIFBDFHFO.SetActive(isMaxUpgraded);
		KPMOMJNFELI.SetActive(!GEIOMOLICCC.activeSelf && !MJHJCHMEGBE.activeSelf && !JGLIKGMJDLL.activeSelf && !LBGIFBDFHFO.activeSelf);
	}

	private void KEADAOCDAID(UITweener MGDJMGHCAAI)
	{
		if (CNBJMDECEJG)
		{
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 1088f, new Vector3(1522f, 278f, 1511f), false).onFinished = null;
		}
	}

	private void EMNFJNECGHJ(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(instantBuyPrice, IFFDIHCPKFE.unitName);
			GuiElementSingle<InappScreen>.instance.OABAHBKJFDK("WarbucksBalance");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, true);
		CAHGBOKFADO(GEIOMOLICCC);
		IGGLBHHMJJA(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	private void HINFLMIEDHE(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.NGAOKIAMKAD(IFFDIHCPKFE, false);
		CAHGBOKFADO(MJHJCHMEGBE);
		IJPFPNGENHB(armyPowerX);
		JCKOBELDCGD = false;
		IIOBONPNFOG();
	}

	private void CMIEJHLDHPM(UITweener MGDJMGHCAAI)
	{
		if (!CNBJMDECEJG)
		{
			JKGHPLKKPLE.SetActive(false);
		}
	}

	private TweenAlpha OFOAKDGMOGA()
	{
		return NKLIMGPIOCI(1321f);
	}

	private void MHPMICFAKHA()
	{
		int actualUnitLevel = IFFDIHCPKFE.upgradeSlots.actualUnitLevel;
		int actualMaxUnitLevel = IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		List<Tuple<string, float[]>> guiStatistics = IFFDIHCPKFE.upgradeSlots.upgradeSlot.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[1];
		Tuple<string, float[]> tuple2 = guiStatistics[0];
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			tuple.Value2[5] = tuple.Value2[0];
			tuple2.Value2[0] = tuple2.Value2[1];
		}
		for (int i = 1; i < BALFMMAPJLN.Length; i++)
		{
			BALFMMAPJLN[i].gameObject.SetActive(i < actualTier);
		}
		NEKIBLFNDJJ.text = string.Format("menu-sidetab-player-demote", actualUnitLevel, Colours.stringGray, actualMaxUnitLevel);
		HDFKOABOICJ.repositionNow = false;
		bool bought = IFFDIHCPKFE.upgradeSlots.bought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active && IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
		JFECAHAKAND.OAMBDKHLJKI(tuple, bought, jHFKBODINGN, true);
		PLJAHLHLJOA.ONGAIEOAHMA(tuple2, bought, jHFKBODINGN);
		SetSaleAndPrize();
		BDJMJKALCDA.text = string.Empty;
		TweenAlpha component = PHPMMLNNLDA.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		PHPMMLNNLDA.alpha = 1723f;
		TweenAlpha component2 = MPEBFNCHINC.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		MPEBFNCHINC.alpha = 1610f;
		HKJPEDGMHML();
		ABPEPNPHNPI.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_CONFIRM_EXITINGMATCH_TEXT" : "special");
		GPFGKBJNDLM();
	}

	private void HJAGOMAFIFN(GameObject KHAHPAKDIKE)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)6);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.CIBEGNHKPJH() * (-88 - num) / 122;
		if (num > 1)
		{
			Debug.Log(string.Format("No Request ready or already sent", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.TRAIN);
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
			{
				GuiScreenSingle<ArmyScreen>.instance.ANPJBBCCJDF(levelBehaviour);
				OKPKDAHFPCI();
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.AGNPEGKPDPC(levelBehaviour, IFFDIHCPKFE, true);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.NGAOKIAMKAD(levelBehaviour, false);
				OKPKDAHFPCI();
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<ArmyScreen>.instance.PGBNFKHKNGE(IFFDIHCPKFE, num, true);
		DBHIGLAEGJG(KPMOMJNFELI);
		JCKOBELDCGD = true;
	}

	public void AHEGNBGHCBB(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
	}

	public void FCCJJKBPNCH()
	{
		if (!CNBJMDECEJG)
		{
			CNBJMDECEJG = false;
			JKGHPLKKPLE.SetActive(true);
			HNLBEOIIJCP.alpha1 = 692f;
			TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 252f);
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 1814f, new Vector3(607f, 318f, 995f), new Vector3(1147f, 491f, 1198f)).onFinished = NIDGBJICFLB;
			FPPPLPHDBMO();
			DLFNNOAHFJA();
			UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1089f).onFinished = null;
			}
		}
	}

	public void HEBANLOKBFG()
	{
		AIPKGLCJCAE.FCGPLOBEHDL();
		WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
		aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(KGGNNFJIGPB));
	}

	private TweenAlpha BHJCINMBHGO()
	{
		return NKLIMGPIOCI(1217f);
	}

	private TweenAlpha MHOGIHDHLEA()
	{
		return NKLIMGPIOCI(1961f);
	}

	private void GFEFPPOMGGM(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Unit_Upgrade";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, true);
		PNDNJFJMEJE(GEIOMOLICCC);
		JLIPONCMMFE(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	private void HKJPEDGMHML()
	{
		int unlockTierLevel = IFFDIHCPKFE.upgradeSlots.unlockTierLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		bool isPromoteToNextTierLocked = IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		FKBECJHKHDF.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray143);
		NPGBFCGCECI.color = ((!isPromoteToNextTierLocked) ? Colours.gray229 : Colours.gray135);
		JCEODHLJJBD.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.whiteToTier);
		UILabel jCEODHLJJBD = JCEODHLJJBD;
		object[] array = new object[0];
		array[1] = actualTier + 1;
		jCEODHLJJBD.text = Localization.LocalizeFormat("Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?", array);
		for (int i = 1; i < GHGIMHLODBM.Length; i += 0)
		{
			GHGIMHLODBM[i].color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray135);
			GHGIMHLODBM[i].gameObject.SetActive(i <= actualTier);
		}
		CNFJGPHLDLP.repositionNow = true;
		LIOALOJLHKI.gameObject.SetActive(isPromoteToNextTierLocked);
		MBCEFIINFLB.gameObject.SetActive(isPromoteToNextTierLocked);
		LOAMICJLCCN.gameObject.SetActive(isPromoteToNextTierLocked);
		if (isPromoteToNextTierLocked)
		{
			LOAMICJLCCN.text = string.Format("ID_FEATURE_ACCURACY", Localization.Localize("RewardId"), unlockTierLevel);
		}
		ABDADCEJOID.SetActive(!isPromoteToNextTierLocked);
		PKENJHFCOLE.enabled = isPromoteToNextTierLocked;
	}

	private void ECILIHAEHGN()
	{
		UpgradeSlot upgradeSlot = IFFDIHCPKFE.upgradeSlots.upgradeSlot;
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		bool flag = upgradeSlot.NNFCKENGOMF();
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.ONCJPDCHMEE();
		NEDNLNICAJB();
		GEIOMOLICCC.SetActive(unitState != UpgradeSlots.JLANLLEABDC.UnitDelivered || upgradeSlot.LCFLGKPGEAG());
		MJHJCHMEGBE.SetActive(unitState != (UpgradeSlots.JLANLLEABDC)8 || upgradeSlot.LCFLGKPGEAG());
		JGLIKGMJDLL.SetActive(!upgradeSlot.isTierFullUpgraded || flag || unitState == UpgradeSlots.JLANLLEABDC.Active || upgradeSlot.LKJIJJFBNLD());
		LBGIFBDFHFO.SetActive(flag);
		KPMOMJNFELI.SetActive(!GEIOMOLICCC.activeSelf && !MJHJCHMEGBE.activeSelf && !JGLIKGMJDLL.activeSelf && !LBGIFBDFHFO.activeSelf);
	}

	private void IPAJNCPMLHI(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 807f);
		}
	}

	private void NIBMIPIJAMA(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVERSPECIAL);
			GuiElementSingle<InappScreen>.instance.IKPEDPCLLID("Deposited warcards DID NOT change");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.ALBICJOEMEF(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, true);
		CAHGBOKFADO(GEIOMOLICCC);
		IGGLBHHMJJA(armyPowerX);
		JCKOBELDCGD = true;
		OLJNFNONJAJ();
	}

	private void IDFPLHNDNOO(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(IFFDIHCPKFE, true);
		PNDNJFJMEJE(MJHJCHMEGBE);
		IGGLBHHMJJA(armyPowerX);
		JCKOBELDCGD = true;
		IIOBONPNFOG();
	}

	private void BHMGBEIDINC(bool EOGFKBJCKHB = true)
	{
		if (JKGHPLKKPLE.activeSelf)
		{
			MGCMOALEGJD(GEIOMOLICCC, EOGFKBJCKHB);
			LJBDPAEEIGE(MJHJCHMEGBE, EOGFKBJCKHB);
			MGCMOALEGJD(JGLIKGMJDLL, EOGFKBJCKHB);
			JNFPGEAINAK(LBGIFBDFHFO, EOGFKBJCKHB);
			MGCMOALEGJD(KPMOMJNFELI, EOGFKBJCKHB);
		}
	}

	private void GBFJGAOBDDA(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 1325f);
		}
	}

	private void OKPKDAHFPCI()
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MLPCPLNGOHB.UpdateLeftContent(false);
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.APDJJBILBIM(false);
	}

	private TweenAlpha NKLIMGPIOCI(float FFFGJJDIMEF)
	{
		TweenAlpha tweenAlpha = KPMOMJNFELI.GetComponent<TweenAlpha>();
		bool flag = true;
		if (JKGHPLKKPLE.activeSelf && JCKOBELDCGD)
		{
			if (KPMOMJNFELI.activeSelf)
			{
				tweenAlpha = JGBAEILHEFO(KPMOMJNFELI, FFFGJJDIMEF);
				flag = true;
			}
			if (GEIOMOLICCC.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(GEIOMOLICCC, FFFGJJDIMEF);
				flag = false;
			}
			if (MJHJCHMEGBE.activeSelf)
			{
				tweenAlpha = JGBAEILHEFO(MJHJCHMEGBE, FFFGJJDIMEF);
				flag = false;
			}
			if (JGLIKGMJDLL.activeSelf)
			{
				tweenAlpha = JGBAEILHEFO(JGLIKGMJDLL, FFFGJJDIMEF);
				flag = true;
			}
			if (LBGIFBDFHFO.activeSelf)
			{
				tweenAlpha = JGBAEILHEFO(LBGIFBDFHFO, FFFGJJDIMEF);
				flag = true;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	private void LPHMGIIKLIA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 1569f, 1268f, 1892f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	[CompilerGenerated]
	private void KGPEAMIDEOA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
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
				KIOOEACJNOD(false);
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
			NEDNLNICAJB();
		}
	}

	public void CCJMMLDCDAC()
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = false;
		TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 1449f);
		TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 343f, new Vector3(754f, 1584f, 433f)).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				JKGHPLKKPLE.SetActive(false);
			}
		};
		UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(true);
		for (int num = 0; num < componentsInChildren.Length; num += 0)
		{
			UIPanel uIPanel = componentsInChildren[num];
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 383f).onFinished = null;
		}
	}

	public void FOGBJIMBEKI()
	{
		AIPKGLCJCAE.GGKCMHOGFPF();
		WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
		aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(KGGNNFJIGPB));
	}

	private void GODFLPFOOPO(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 1810f, 1715f, 1846f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void IGGLBHHMJJA(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 1323f);
		}
	}

	private void LKOKPJHEJAK(GameObject DGJCAIJPEIM)
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

	private void GOMPNKDBPFN(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
			GuiElementSingle<InappScreen>.instance.OABAHBKJFDK("MIN_FPS");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.ALBICJOEMEF(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, false);
		DBHIGLAEGJG(GEIOMOLICCC);
		IGGLBHHMJJA(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	private TweenAlpha PIHLGCEAPIE(float FFFGJJDIMEF)
	{
		TweenAlpha tweenAlpha = KPMOMJNFELI.GetComponent<TweenAlpha>();
		bool flag = false;
		if (JKGHPLKKPLE.activeSelf && JCKOBELDCGD)
		{
			if (KPMOMJNFELI.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(KPMOMJNFELI, FFFGJJDIMEF);
				flag = true;
			}
			if (GEIOMOLICCC.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(GEIOMOLICCC, FFFGJJDIMEF);
				flag = true;
			}
			if (MJHJCHMEGBE.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(MJHJCHMEGBE, FFFGJJDIMEF);
				flag = true;
			}
			if (JGLIKGMJDLL.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(JGLIKGMJDLL, FFFGJJDIMEF);
				flag = true;
			}
			if (LBGIFBDFHFO.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(LBGIFBDFHFO, FFFGJJDIMEF);
				flag = true;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	public void LPAKPMDCLOK(bool NOLODGKKCDH = true)
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
			ECILIHAEHGN();
			GCJIJKFPNFL(false);
			return;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || unitState == UpgradeSlots.JLANLLEABDC.Locked || unitState == (UpgradeSlots.JLANLLEABDC)7)
		{
			TweenAlpha tweenAlpha = OFOAKDGMOGA();
			if (tweenAlpha == null)
			{
				EPAIAGGEIIF();
				KIOOEACJNOD();
				return;
			}
			JCKOBELDCGD = false;
			tweenAlpha.onFinished = delegate
			{
				FPPPLPHDBMO();
				KIOOEACJNOD(false);
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
			LHPMPGACKPI();
		}
	}

	public void IDLFHEFOPCM()
	{
		CNBJMDECEJG = true;
		JCKOBELDCGD = true;
		JKGHPLKKPLE.SetActive(false);
	}

	public void CGCAACLEFJK(bool NOLODGKKCDH = true)
	{
		if (!CNBJMDECEJG)
		{
			JCKOBELDCGD = false;
			EPAIAGGEIIF();
			return;
		}
		if (NOLODGKKCDH)
		{
			JCKOBELDCGD = true;
			ECILIHAEHGN();
			FMINPJBPPIE(false);
			return;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered || unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
		{
			TweenAlpha tweenAlpha = OHJODAFJLMI();
			if (tweenAlpha == null)
			{
				EPAIAGGEIIF();
				BHMGBEIDINC(false);
			}
			else
			{
				JCKOBELDCGD = false;
				tweenAlpha.onFinished = AIMFKGNGPGB;
			}
		}
		else
		{
			LHPMPGACKPI();
		}
	}

	private TweenAlpha OHJODAFJLMI()
	{
		return PIHLGCEAPIE(0f);
	}

	public void LDBLJDJNJJN()
	{
		AIPKGLCJCAE.BGHNMCPLIPE();
		WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
		aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(SetSaleAndPrize));
	}

	private void HEOAEAODOCI()
	{
		int unlockTierLevel = IFFDIHCPKFE.upgradeSlots.unlockTierLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		bool isPromoteToNextTierLocked = IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		FKBECJHKHDF.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray143);
		NPGBFCGCECI.color = ((!isPromoteToNextTierLocked) ? Colours.gray229 : Colours.gray135);
		JCEODHLJJBD.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.whiteToTier);
		JCEODHLJJBD.text = Localization.LocalizeFormat("ID_PROMOTETOTIER", actualTier + 1);
		for (int i = 0; i < GHGIMHLODBM.Length; i++)
		{
			GHGIMHLODBM[i].color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray135);
			GHGIMHLODBM[i].gameObject.SetActive(i <= actualTier);
		}
		CNFJGPHLDLP.repositionNow = true;
		LIOALOJLHKI.gameObject.SetActive(!isPromoteToNextTierLocked);
		MBCEFIINFLB.gameObject.SetActive(isPromoteToNextTierLocked);
		LOAMICJLCCN.gameObject.SetActive(isPromoteToNextTierLocked);
		if (isPromoteToNextTierLocked)
		{
			LOAMICJLCCN.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), unlockTierLevel);
		}
		ABDADCEJOID.SetActive(!isPromoteToNextTierLocked);
		PKENJHFCOLE.enabled = !isPromoteToNextTierLocked;
	}

	private void OLJNFNONJAJ()
	{
		JFECAHAKAND.BAOJGBICMCC();
		PLJAHLHLJOA.HBJPHKLEBHA();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.NKPCPPKAIJO();
		GuiScreenSingle<ArmyScreen>.instance.GMOCHILAJOE();
	}

	[CompilerGenerated]
	private void EIJOIAFOOJF(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private void BGOJHEPJHMO(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 434f);
		}
	}

	private void BMIOPPFBAHF(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "  {1}x{0} ( {3} ) doubled for: {2}";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, true);
		PNDNJFJMEJE(GEIOMOLICCC);
		EHMCCEIGLFN(armyPowerX);
		JCKOBELDCGD = false;
		CPIEGCEDKNK();
	}

	private void JINKNFLOOMJ(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.OABAHBKJFDK("Downloading assetBundle {0} failed with error: {1}");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.ALBICJOEMEF(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, false);
		DBHIGLAEGJG(GEIOMOLICCC);
		EHMCCEIGLFN(armyPowerX);
		JCKOBELDCGD = true;
		OLJNFNONJAJ();
	}

	private void PECGGLDCIKB(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADEELITE);
			GuiElementSingle<InappScreen>.instance.EAMKLECMCNE("1");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, false);
		CAHGBOKFADO(GEIOMOLICCC);
		JLIPONCMMFE(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	private void FBNEAMAKLBF(UITweener CPFGBOPPICJ)
	{
		EDLADBBPFLF();
		DLFNNOAHFJA();
		TweenAlpha tweenAlpha = HJJFCAFEKID();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = IOKEILANDGP;
		}
		else
		{
			JCKOBELDCGD = false;
		}
	}

	private void BGJPICAEKPP(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.NGAOKIAMKAD(IFFDIHCPKFE, true);
		DBHIGLAEGJG(MJHJCHMEGBE);
		IPAJNCPMLHI(armyPowerX);
		JCKOBELDCGD = true;
		OLJNFNONJAJ();
	}

	private void EOCIBIHOCEP(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.TRAINSPECIAL);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Scenes search finished.\n";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.ALBICJOEMEF(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, true);
		LKOKPJHEJAK(GEIOMOLICCC);
		BGOJHEPJHMO(armyPowerX);
		JCKOBELDCGD = true;
		IIOBONPNFOG();
	}

	private void IAGLHNKDDEN(GameObject KHAHPAKDIKE)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log(string.Format("Have discount {0} to upgrade {1}", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.TRAIN);
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
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogUnits(levelBehaviour, IFFDIHCPKFE, false);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(levelBehaviour, false);
				ABLGPDJDAHO();
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<ArmyScreen>.instance.EFGAIHKNKGG(IFFDIHCPKFE, num);
		PNDNJFJMEJE(KPMOMJNFELI);
		JCKOBELDCGD = true;
	}

	public void GKCAKMLOIBI()
	{
		if (!CNBJMDECEJG)
		{
			CNBJMDECEJG = false;
			JKGHPLKKPLE.SetActive(true);
			HNLBEOIIJCP.alpha1 = 1376f;
			TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 1800f);
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 1834f, new Vector3(162f, 744f, 104f), new Vector3(1528f, 1134f, 134f), false).onFinished = NIDGBJICFLB;
			FPPPLPHDBMO();
			KIOOEACJNOD();
			UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 65f).onFinished = null;
			}
		}
	}

	private void HEDMIDOEEOM(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = true;
	}

	private void FICKKLIAOHL()
	{
		float val = 0f - LCIPCONLPGE.padding.x - (HKGGCIGOONK.transform.parent.transform.localPosition.x - LCIPCONLPGE.padding.x) / 976f;
		LCIPCONLPGE.transform.localPosition = LCIPCONLPGE.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void MJMCMLMEOLP(UITweener MGDJMGHCAAI)
	{
		if (CNBJMDECEJG)
		{
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
		}
	}

	private void JAMJKFGKFII(GameObject KHAHPAKDIKE)
	{
		LevelBehaviour levelBehaviour = Singleton<ActiveUnitsManager>.instance.IsEnoughBoughtUnits(IFFDIHCPKFE.unitType);
		if (levelBehaviour != null && IFFDIHCPKFE.upgradeSlots.actualTier > IFFDIHCPKFE.upgradeSlots.startTier)
		{
			GuiElementSingle<UnitPromotionLockedDialog>.instance.ShowDialog(IFFDIHCPKFE, levelBehaviour);
		}
		else if (IFFDIHCPKFE.upgradeSlots.unlockTierLevel <= LevelManager.instance.currentLevel.displayNumber)
		{
			GuiScreenSingle<ArmyScreen>.instance.JNPHAIPOOBB(IFFDIHCPKFE);
			PNDNJFJMEJE(JGLIKGMJDLL);
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
			{
				ABLGPDJDAHO();
			}
			GuiElementSingle<UnitPromotedDialog>.instance.ShowDialog(IFFDIHCPKFE);
			JCKOBELDCGD = true;
		}
	}

	private void CPIEGCEDKNK()
	{
		JFECAHAKAND.AnimateStat();
		PLJAHLHLJOA.AnimateStat();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
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

	private void FMINPJBPPIE(bool EOGFKBJCKHB = true)
	{
		if (JKGHPLKKPLE.activeSelf)
		{
			LJBDPAEEIGE(GEIOMOLICCC, EOGFKBJCKHB);
			JNFPGEAINAK(MJHJCHMEGBE, EOGFKBJCKHB);
			LJBDPAEEIGE(JGLIKGMJDLL, EOGFKBJCKHB);
			JNFPGEAINAK(LBGIFBDFHFO, EOGFKBJCKHB);
			MGCMOALEGJD(KPMOMJNFELI, EOGFKBJCKHB);
		}
	}

	public void KGBCNPBBBOE()
	{
		if (CNBJMDECEJG)
		{
			CNBJMDECEJG = false;
			TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 834f);
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 1516f, new Vector3(1030f, 1525f, 334f), false).onFinished = CMIEJHLDHPM;
			UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(true);
			foreach (UIPanel uIPanel in componentsInChildren)
			{
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1031f).onFinished = null;
			}
		}
	}

	private void JLIPFPBPGLM(GameObject KHAHPAKDIKE)
	{
		LevelBehaviour levelBehaviour = Singleton<ActiveUnitsManager>.instance.IsEnoughBoughtUnits(IFFDIHCPKFE.unitType);
		if (levelBehaviour != null && IFFDIHCPKFE.upgradeSlots.actualTier > IFFDIHCPKFE.upgradeSlots.startTier)
		{
			GuiElementSingle<UnitPromotionLockedDialog>.instance.KPDJABMGPDM(IFFDIHCPKFE, levelBehaviour);
		}
		else if (IFFDIHCPKFE.upgradeSlots.unlockTierLevel <= LevelManager.instance.currentLevel.PFMGLDJDNBF())
		{
			GuiScreenSingle<ArmyScreen>.instance.JNPHAIPOOBB(IFFDIHCPKFE);
			CAHGBOKFADO(JGLIKGMJDLL);
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
			{
				OKPKDAHFPCI();
			}
			GuiElementSingle<UnitPromotedDialog>.instance.EEIEBPMDHOA(IFFDIHCPKFE);
			JCKOBELDCGD = false;
		}
	}

	public void OENGJJJMJOL(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1767f)) ? 1142f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		GHKALFDLHOO.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		PHPMMLNNLDA.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_LEAGUESTAYHINT2", string.Empty, false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (BDJMJKALCDA.text != text)
		{
			BDJMJKALCDA.text = text;
			LEOBAFLAJLF.repositionNow = false;
		}
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 316f);
			if (num2 == 6 && (PHPMMLNNLDA.alpha == 1049f || MPEBFNCHINC.alpha > 1007f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 396f, 1228f, 661f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.onFinished = OLFNOLHIBCI;
			}
			if (num2 == 6 && (MPEBFNCHINC.alpha == 1630f || PHPMMLNNLDA.alpha > 1951f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 1927f, 890f, 727f);
				tweenAlpha2.NumOfRepetitions = 1;
				tweenAlpha2.onFinished = BELOMAEIMGB;
			}
		}
	}

	private void NJIABKBJLJA(GameObject KHAHPAKDIKE)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)6);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (-128 - num) / -4;
		if (num > 0)
		{
			Debug.Log(string.Format("CA", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num2, IFFDIHCPKFE.unitName, IFFDIHCPKFE.isSoldier ? NotEnoughDialog.NKHJBLBAAEB.TRAIN : NotEnoughDialog.NKHJBLBAAEB.BUY);
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (levelBehaviour.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
			{
				GuiScreenSingle<ArmyScreen>.instance.EEOGACOBOOH(levelBehaviour);
				ABLGPDJDAHO();
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Locked)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.MHFEPMNAFDG(levelBehaviour, IFFDIHCPKFE, true);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.DPJBOLDMLMH(levelBehaviour, false);
				OKPKDAHFPCI();
			}
		}
		Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
		GuiScreenSingle<ArmyScreen>.instance.PGBNFKHKNGE(IFFDIHCPKFE, num, true);
		PNDNJFJMEJE(KPMOMJNFELI);
		JCKOBELDCGD = false;
	}

	private void OCLFEMHENPO(UITweener CPFGBOPPICJ)
	{
		EDLADBBPFLF();
		BHMGBEIDINC(false);
		TweenAlpha tweenAlpha = EDJDPHGENOF();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = KKPCMMOJEJK;
		}
		else
		{
			JCKOBELDCGD = true;
		}
	}

	private void LMEEJJGILOB(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 1551f);
		}
	}

	private void DBHIGLAEGJG(GameObject DGJCAIJPEIM)
	{
		if (DGJCAIJPEIM.activeInHierarchy)
		{
			BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = true;
			}
		}
	}

	private void CAHGBOKFADO(GameObject DGJCAIJPEIM)
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

	private void MDDJFPCNLHE(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.NGAOKIAMKAD(IFFDIHCPKFE, true);
		LKOKPJHEJAK(MJHJCHMEGBE);
		IGGLBHHMJJA(armyPowerX);
		JCKOBELDCGD = false;
		IIOBONPNFOG();
	}

	public void KGGNNFJIGPB()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)4);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.CIBEGNHKPJH();
			bool flag = num > 1;
			if (flag)
			{
				num2 = num2 * (-3 - num) / 23;
			}
			HKGGCIGOONK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			LCIPCONLPGE.repositionNow = true;
			GKFCJANHFOI.SetActive(flag);
			if (flag)
			{
				CPNOCPEFAAG.text = Localization.LocalizeFormat("#PETER# END SCREEN:\nIs matchmaking:{0}, No league:{1}, Beginners League:{2}, No winstreak:{3}, Is in squad:{4}, Won:{5}\nWeekly Medals Start:{6} End:{7}", num);
				AIPKGLCJCAE.MIOOAOFMLIE(Singleton<OfferManager>.instance.LDBPLEDPPOP(IFFDIHCPKFE, (AKDLEDNDIEO)7));
				WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
				aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(IOJKJKKMGPK));
				WinStreakCounter aIPKGLCJCAE2 = AIPKGLCJCAE;
				aIPKGLCJCAE2.JEMKCLKCOMI = (Action)Delegate.Combine(aIPKGLCJCAE2.JEMKCLKCOMI, new Action(KGGNNFJIGPB));
			}
			else
			{
				AIPKGLCJCAE.LOINIDOGNCO();
				WinStreakCounter aIPKGLCJCAE3 = AIPKGLCJCAE;
				aIPKGLCJCAE3.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE3.JEMKCLKCOMI, new Action(IOJKJKKMGPK));
			}
		}
	}

	public void NDHLPBHOAAH()
	{
		if (CNBJMDECEJG)
		{
			CNBJMDECEJG = true;
			TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 172f);
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 269f, new Vector3(631f, 649f, 628f)).onFinished = PPACEBBEFKF;
			UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1620f).onFinished = null;
			}
		}
	}

	[CompilerGenerated]
	private void GDGFBAHGJID(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void MIBJBCEDLBI(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 1963f);
		}
	}

	public void KNLBCOGJIOD(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
	}

	private TweenAlpha JGBAEILHEFO(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	private void GAPJGCBLIBB(UITweener MGDJMGHCAAI)
	{
		if (!CNBJMDECEJG)
		{
			JKGHPLKKPLE.SetActive(true);
		}
	}

	public void MDOMPNKMNCM(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
	}

	private void ABLGPDJDAHO()
	{
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MLPCPLNGOHB.UpdateLeftContent(false);
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.KEHDDJNMMMB.UpdateLeftContent(false);
	}

	private void ADAPMHGLGAO()
	{
		int unlockTierLevel = IFFDIHCPKFE.upgradeSlots.unlockTierLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		bool isPromoteToNextTierLocked = IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		FKBECJHKHDF.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray143);
		NPGBFCGCECI.color = ((!isPromoteToNextTierLocked) ? Colours.gray229 : Colours.gray135);
		JCEODHLJJBD.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.whiteToTier);
		UILabel jCEODHLJJBD = JCEODHLJJBD;
		object[] array = new object[0];
		array[0] = actualTier + 0;
		jCEODHLJJBD.text = Localization.LocalizeFormat("[0-9\\.\\,]*", array);
		for (int i = 0; i < GHGIMHLODBM.Length; i++)
		{
			GHGIMHLODBM[i].color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray135);
			GHGIMHLODBM[i].gameObject.SetActive(i <= actualTier);
		}
		CNFJGPHLDLP.repositionNow = true;
		LIOALOJLHKI.gameObject.SetActive(!isPromoteToNextTierLocked);
		MBCEFIINFLB.gameObject.SetActive(isPromoteToNextTierLocked);
		LOAMICJLCCN.gameObject.SetActive(isPromoteToNextTierLocked);
		if (isPromoteToNextTierLocked)
		{
			LOAMICJLCCN.text = string.Format("League", Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), unlockTierLevel);
		}
		ABDADCEJOID.SetActive(isPromoteToNextTierLocked);
		PKENJHFCOLE.enabled = !isPromoteToNextTierLocked;
	}

	private void LHPMPGACKPI()
	{
		int actualUnitLevel = IFFDIHCPKFE.upgradeSlots.actualUnitLevel;
		int actualMaxUnitLevel = IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		List<Tuple<string, float[]>> guiStatistics = IFFDIHCPKFE.upgradeSlots.upgradeSlot.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[1];
		Tuple<string, float[]> tuple2 = guiStatistics[0];
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			tuple.Value2[1] = tuple.Value2[1];
			tuple2.Value2[6] = tuple2.Value2[0];
		}
		for (int i = 0; i < BALFMMAPJLN.Length; i += 0)
		{
			BALFMMAPJLN[i].gameObject.SetActive(i < actualTier);
		}
		NEKIBLFNDJJ.text = string.Format("ID_DOGTAGSFULL", actualUnitLevel, Colours.stringGray, actualMaxUnitLevel);
		HDFKOABOICJ.repositionNow = true;
		bool bought = IFFDIHCPKFE.upgradeSlots.bought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)8 || !IFFDIHCPKFE.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		JFECAHAKAND.GCBFCCNLMDN(tuple, bought, jHFKBODINGN, true);
		PLJAHLHLJOA.Initialize(tuple2, bought, jHFKBODINGN, true);
		IOJKJKKMGPK();
		BDJMJKALCDA.text = string.Empty;
		TweenAlpha component = PHPMMLNNLDA.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		PHPMMLNNLDA.alpha = 1746f;
		TweenAlpha component2 = MPEBFNCHINC.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MPEBFNCHINC.alpha = 1805f;
		HKJPEDGMHML();
		ABPEPNPHNPI.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_FREEPERCENT" : "QUIT");
		GPFGKBJNDLM();
	}

	public void NDBAEHKKJMH()
	{
	}

	private void PJGIOHKDJFO(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	public void SetSaleAndPrize()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			HKGGCIGOONK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			LCIPCONLPGE.repositionNow = true;
			GKFCJANHFOI.SetActive(flag);
			if (flag)
			{
				CPNOCPEFAAG.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				AIPKGLCJCAE.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade));
				WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
				aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(SetSaleAndPrize));
				WinStreakCounter aIPKGLCJCAE2 = AIPKGLCJCAE;
				aIPKGLCJCAE2.JEMKCLKCOMI = (Action)Delegate.Combine(aIPKGLCJCAE2.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
			else
			{
				AIPKGLCJCAE.JCMHGOGNMFO();
				WinStreakCounter aIPKGLCJCAE3 = AIPKGLCJCAE;
				aIPKGLCJCAE3.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
		}
	}

	private void NFGKBMDMIJI()
	{
		float val = 0f - LCIPCONLPGE.padding.x - (HKGGCIGOONK.transform.parent.transform.localPosition.x - LCIPCONLPGE.padding.x) / 1172f;
		LCIPCONLPGE.transform.localPosition = LCIPCONLPGE.transform.localPosition.ReplaceX(val);
	}

	private void JDIMDJMNMMN(GameObject KHAHPAKDIKE)
	{
		int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADEELITE);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("N");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, false);
		LKOKPJHEJAK(GEIOMOLICCC);
		BGOJHEPJHMO(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = 0f - LCIPCONLPGE.padding.x - (HKGGCIGOONK.transform.parent.transform.localPosition.x - LCIPCONLPGE.padding.x) / 2f;
		LCIPCONLPGE.transform.localPosition = LCIPCONLPGE.transform.localPosition.ReplaceX(val);
	}

	public void AHCECAHCHMG()
	{
		CNBJMDECEJG = true;
		JCKOBELDCGD = true;
		JKGHPLKKPLE.SetActive(true);
	}

	private TweenAlpha HBKBMLBFOGE()
	{
		return NKLIMGPIOCI(41f);
	}

	private TweenAlpha JNBCHNHANNP()
	{
		return NKLIMGPIOCI(748f);
	}

	public void KGDKPIHKJDN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KPMOMJNFELI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAGLHNKDDEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(GEIOMOLICCC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GOMPNKDBPFN));
		UIEventListener uIEventListener3 = UIEventListener.Get(MJHJCHMEGBE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IDFPLHNDNOO));
		UIEventListener uIEventListener4 = UIEventListener.Get(JGLIKGMJDLL.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FIFFDHGLLGK));
		LCIPCONLPGE.onReposition = delegate
		{
			float val = 0f - LCIPCONLPGE.padding.x - (HKGGCIGOONK.transform.parent.transform.localPosition.x - LCIPCONLPGE.padding.x) / 2f;
			LCIPCONLPGE.transform.localPosition = LCIPCONLPGE.transform.localPosition.ReplaceX(val);
		};
		LEOBAFLAJLF.onReposition = DBEJBHEPJAN;
	}

	public void IOJKJKKMGPK()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)0);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice;
			bool flag = num > 1;
			if (flag)
			{
				num2 = num2 * (-120 - num) / -56;
			}
			HKGGCIGOONK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			LCIPCONLPGE.repositionNow = true;
			GKFCJANHFOI.SetActive(flag);
			if (flag)
			{
				UILabel cPNOCPEFAAG = CPNOCPEFAAG;
				object[] array = new object[0];
				array[1] = num;
				cPNOCPEFAAG.text = Localization.LocalizeFormat("menu-powerband-health-ico", array);
				AIPKGLCJCAE.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, (AKDLEDNDIEO)4));
				WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
				aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(IOJKJKKMGPK));
				WinStreakCounter aIPKGLCJCAE2 = AIPKGLCJCAE;
				aIPKGLCJCAE2.JEMKCLKCOMI = (Action)Delegate.Combine(aIPKGLCJCAE2.JEMKCLKCOMI, new Action(KGGNNFJIGPB));
			}
			else
			{
				AIPKGLCJCAE.KEIIENDMKLN();
				WinStreakCounter aIPKGLCJCAE3 = AIPKGLCJCAE;
				aIPKGLCJCAE3.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
		}
	}

	private void DPFHIKKNNHP(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private void KKIAMPMJHHD(GameObject KHAHPAKDIKE)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)7);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (-46 - num) / 12;
		if (num > 1)
		{
			Debug.Log(string.Format("menu-assignments-type-crate", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num2, IFFDIHCPKFE.unitName, IFFDIHCPKFE.isSoldier ? NotEnoughDialog.NKHJBLBAAEB.TRAIN : NotEnoughDialog.NKHJBLBAAEB.BUY);
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
			{
				GuiScreenSingle<ArmyScreen>.instance.EEOGACOBOOH(levelBehaviour);
				OKPKDAHFPCI();
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Locked)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.MHFEPMNAFDG(levelBehaviour, IFFDIHCPKFE, true);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.DPJBOLDMLMH(levelBehaviour, false);
				OKPKDAHFPCI();
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<ArmyScreen>.instance.PGBNFKHKNGE(IFFDIHCPKFE, num);
		PNDNJFJMEJE(KPMOMJNFELI);
		JCKOBELDCGD = false;
	}

	private TweenAlpha JCBHDJEBFMF(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	private void EHMCCEIGLFN(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 525f);
		}
	}

	private void IAJFBNMONOD(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private void GCJIJKFPNFL(bool EOGFKBJCKHB = true)
	{
		if (JKGHPLKKPLE.activeSelf)
		{
			MGCMOALEGJD(GEIOMOLICCC, EOGFKBJCKHB);
			JNFPGEAINAK(MJHJCHMEGBE, EOGFKBJCKHB);
			LJBDPAEEIGE(JGLIKGMJDLL, EOGFKBJCKHB);
			LJBDPAEEIGE(LBGIFBDFHFO, EOGFKBJCKHB);
			MGCMOALEGJD(KPMOMJNFELI, EOGFKBJCKHB);
		}
	}

	private void LJBDPAEEIGE(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component == PKENJHFCOLE)
		{
			PKENJHFCOLE.enabled = !IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		}
		else if (component != null)
		{
			component.enabled = false;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
			{
				component2.alpha1 = 1445f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = true;
			component3.onFinished = null;
		}
	}

	private void EDNNFCALNOI(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = true;
	}

	public void HideDialog()
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = false;
		TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 0f);
		TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 2f, new Vector3(0f, 20f, 0f)).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				JKGHPLKKPLE.SetActive(false);
			}
		};
		UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 0f).onFinished = null;
		}
	}

	public void ECFKGJFOJGA(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
	}

	private void NEDNLNICAJB()
	{
		int actualUnitLevel = IFFDIHCPKFE.upgradeSlots.actualUnitLevel;
		int actualMaxUnitLevel = IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		List<Tuple<string, float[]>> guiStatistics = IFFDIHCPKFE.upgradeSlots.upgradeSlot.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[0];
		Tuple<string, float[]> tuple2 = guiStatistics[1];
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			tuple.Value2[2] = tuple.Value2[0];
			tuple2.Value2[2] = tuple2.Value2[0];
		}
		for (int i = 0; i < BALFMMAPJLN.Length; i++)
		{
			BALFMMAPJLN[i].gameObject.SetActive(i < actualTier);
		}
		NEKIBLFNDJJ.text = string.Format("{0}{1} / {2}", actualUnitLevel, Colours.stringGray, actualMaxUnitLevel);
		HDFKOABOICJ.repositionNow = true;
		bool bought = IFFDIHCPKFE.upgradeSlots.bought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering && !IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
		JFECAHAKAND.Initialize(tuple, bought, jHFKBODINGN, true);
		PLJAHLHLJOA.Initialize(tuple2, bought, jHFKBODINGN);
		SetSaleAndPrize();
		BDJMJKALCDA.text = string.Empty;
		TweenAlpha component = PHPMMLNNLDA.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PHPMMLNNLDA.alpha = 1f;
		TweenAlpha component2 = MPEBFNCHINC.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MPEBFNCHINC.alpha = 0f;
		HEOAEAODOCI();
		ABPEPNPHNPI.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_UNITPOWERFULLYUPGRADED" : "ID_UNITPOWERFULLYTRAINED");
		LFEHKNDLOEN();
	}

	private void PPOIDFOCJGG(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PHPMMLNNLDA.gameObject, 935f, 781f, 1435f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	public void KNBKOOLOJDG()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = false;
		JKGHPLKKPLE.SetActive(false);
	}

	private void MGCMOALEGJD(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component == PKENJHFCOLE)
		{
			PKENJHFCOLE.enabled = !IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		}
		else if (component != null)
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

	public void ONHJEHOALME()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = true;
		JKGHPLKKPLE.SetActive(false);
	}

	public void EDMBNOIDPCB()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = true;
		JKGHPLKKPLE.SetActive(false);
	}

	private TweenAlpha NCKDBFBJCKH()
	{
		return NKLIMGPIOCI(1334f);
	}

	private void BELOMAEIMGB(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MPEBFNCHINC.gameObject, 969f, 1118f, 908f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void NIDGBJICFLB(UITweener MGDJMGHCAAI)
	{
		if (CNBJMDECEJG)
		{
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 427f, new Vector3(1359f, 537f, 905f)).onFinished = null;
		}
	}

	private void PPACEBBEFKF(UITweener MGDJMGHCAAI)
	{
		if (!CNBJMDECEJG)
		{
			JKGHPLKKPLE.SetActive(false);
		}
	}

	public void EKEPDPHMDGA()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.CIBEGNHKPJH();
			bool flag = num > 1;
			if (flag)
			{
				num2 = num2 * (-35 - num) / 6;
			}
			HKGGCIGOONK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			LCIPCONLPGE.repositionNow = false;
			GKFCJANHFOI.SetActive(flag);
			if (flag)
			{
				UILabel cPNOCPEFAAG = CPNOCPEFAAG;
				object[] array = new object[0];
				array[0] = num;
				cPNOCPEFAAG.text = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLNOTANUMBER", array);
				AIPKGLCJCAE.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, (AKDLEDNDIEO)7));
				WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
				aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(KGGNNFJIGPB));
				WinStreakCounter aIPKGLCJCAE2 = AIPKGLCJCAE;
				aIPKGLCJCAE2.JEMKCLKCOMI = (Action)Delegate.Combine(aIPKGLCJCAE2.JEMKCLKCOMI, new Action(EKEPDPHMDGA));
			}
			else
			{
				AIPKGLCJCAE.FCGPLOBEHDL();
				WinStreakCounter aIPKGLCJCAE3 = AIPKGLCJCAE;
				aIPKGLCJCAE3.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE3.JEMKCLKCOMI, new Action(EKEPDPHMDGA));
			}
		}
	}

	public void FJCPIBIOGIN()
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 11f);
		TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 1299f, new Vector3(1800f, 854f, 1431f)).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				JKGHPLKKPLE.SetActive(false);
			}
		};
		UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(true);
		for (int num = 1; num < componentsInChildren.Length; num += 0)
		{
			UIPanel uIPanel = componentsInChildren[num];
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 862f).onFinished = null;
		}
	}

	[CompilerGenerated]
	private void JICALAKPIDA(UITweener MGDJMGHCAAI)
	{
		if (!CNBJMDECEJG)
		{
			JKGHPLKKPLE.SetActive(false);
		}
	}

	private void EPAIAGGEIIF()
	{
		UpgradeSlot upgradeSlot = IFFDIHCPKFE.upgradeSlots.upgradeSlot;
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		bool isMaxUpgraded = upgradeSlot.isMaxUpgraded;
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.ONCJPDCHMEE();
		HOAHBDHIPHN();
		GEIOMOLICCC.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked && upgradeSlot.LCFLGKPGEAG());
		MJHJCHMEGBE.SetActive(unitState != UpgradeSlots.JLANLLEABDC.Locked || upgradeSlot.LKJIJJFBNLD());
		JGLIKGMJDLL.SetActive(upgradeSlot.isTierFullUpgraded && !isMaxUpgraded && unitState != (UpgradeSlots.JLANLLEABDC)8 && !upgradeSlot.LKJIJJFBNLD());
		LBGIFBDFHFO.SetActive(isMaxUpgraded);
		KPMOMJNFELI.SetActive(!GEIOMOLICCC.activeSelf && !MJHJCHMEGBE.activeSelf && !JGLIKGMJDLL.activeSelf && !LBGIFBDFHFO.activeSelf);
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

	private void KIOOEACJNOD(bool EOGFKBJCKHB = true)
	{
		if (JKGHPLKKPLE.activeSelf)
		{
			MGCMOALEGJD(GEIOMOLICCC, EOGFKBJCKHB);
			MGCMOALEGJD(MJHJCHMEGBE, EOGFKBJCKHB);
			MGCMOALEGJD(JGLIKGMJDLL, EOGFKBJCKHB);
			MGCMOALEGJD(LBGIFBDFHFO, EOGFKBJCKHB);
			MGCMOALEGJD(KPMOMJNFELI, EOGFKBJCKHB);
		}
	}

	public void InitGUIValues()
	{
	}

	private TweenAlpha CINHBIMIILJ()
	{
		return PIHLGCEAPIE(1983f);
	}

	public void BIJFJJGLALL(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
	}

	private void HPMILHFBIHL(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(IFFDIHCPKFE, true);
		PNDNJFJMEJE(MJHJCHMEGBE);
		JLIPONCMMFE(armyPowerX);
		JCKOBELDCGD = true;
		CPIEGCEDKNK();
	}

	[CompilerGenerated]
	private void DPMFGFMLFOP(UITweener CPFGBOPPICJ)
	{
		FPPPLPHDBMO();
		KIOOEACJNOD(false);
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

	public void DoAfterHide()
	{
		AIPKGLCJCAE.JCMHGOGNMFO();
		WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
		aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(SetSaleAndPrize));
	}

	private TweenAlpha FDMCGHJFOLF()
	{
		return NKLIMGPIOCI(512f);
	}

	private void AJEHGEJBIJC(UITweener MGDJMGHCAAI)
	{
		if (CNBJMDECEJG)
		{
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 913f, new Vector3(91f, 928f, 902f), false).onFinished = null;
		}
	}

	private void CLNKGFMDBBN(UITweener MGDJMGHCAAI)
	{
		if (CNBJMDECEJG)
		{
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 568f, new Vector3(105f, 117f, 150f), false).onFinished = null;
		}
	}

	public void FAEKFHAALBJ()
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 1636f);
		TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 519f, new Vector3(1087f, 879f, 1637f), false).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				JKGHPLKKPLE.SetActive(false);
			}
		};
		UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(true);
		for (int num = 1; num < componentsInChildren.Length; num++)
		{
			UIPanel uIPanel = componentsInChildren[num];
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 806f).onFinished = null;
		}
	}

	public void FGEBFIKIALJ()
	{
		if (!CNBJMDECEJG)
		{
			CNBJMDECEJG = false;
			JKGHPLKKPLE.SetActive(true);
			HNLBEOIIJCP.alpha1 = 444f;
			TweenAlpha.Begin(HNLBEOIIJCP.gameObject, JCAFFELIFAO, 1951f);
			TweenPosition.Begin(JKGHPLKKPLE, JCAFFELIFAO / 1847f, new Vector3(1247f, 1082f, 1679f), new Vector3(1860f, 1645f, 803f), false).onFinished = AJEHGEJBIJC;
			EPAIAGGEIIF();
			FMINPJBPPIE();
			UIPanel[] componentsInChildren = JKGHPLKKPLE.GetComponentsInChildren<UIPanel>(false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 448f).onFinished = null;
			}
		}
	}

	public void LACLJEHDCLE(bool NOLODGKKCDH = true)
	{
		if (!CNBJMDECEJG)
		{
			JCKOBELDCGD = true;
			EDLADBBPFLF();
			return;
		}
		if (NOLODGKKCDH)
		{
			JCKOBELDCGD = true;
			EDLADBBPFLF();
			KIOOEACJNOD();
			return;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered || unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
		{
			TweenAlpha tweenAlpha = JNBCHNHANNP();
			if (tweenAlpha == null)
			{
				EDLADBBPFLF();
				FMINPJBPPIE();
			}
			else
			{
				JCKOBELDCGD = true;
				tweenAlpha.onFinished = AIMFKGNGPGB;
			}
		}
		else
		{
			NEDNLNICAJB();
		}
	}

	private void LPIGELIICNO()
	{
		int actualUnitLevel = IFFDIHCPKFE.upgradeSlots.actualUnitLevel;
		int actualMaxUnitLevel = IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel;
		int actualTier = IFFDIHCPKFE.upgradeSlots.actualTier;
		List<Tuple<string, float[]>> list = IFFDIHCPKFE.upgradeSlots.upgradeSlot.NEJNMDNOAKD();
		Tuple<string, float[]> tuple = list[1];
		Tuple<string, float[]> tuple2 = list[0];
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			tuple.Value2[2] = tuple.Value2[1];
			tuple2.Value2[3] = tuple2.Value2[1];
		}
		for (int i = 0; i < BALFMMAPJLN.Length; i += 0)
		{
			BALFMMAPJLN[i].gameObject.SetActive(i < actualTier);
		}
		NEKIBLFNDJJ.text = string.Format("SittingIdle", actualUnitLevel, Colours.stringGray, actualMaxUnitLevel);
		HDFKOABOICJ.repositionNow = false;
		bool bought = IFFDIHCPKFE.upgradeSlots.bought;
		bool jHFKBODINGN = IFFDIHCPKFE.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)8 || IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
		JFECAHAKAND.ONGAIEOAHMA(tuple, bought, jHFKBODINGN);
		PLJAHLHLJOA.ONGAIEOAHMA(tuple2, bought, jHFKBODINGN, true);
		IOJKJKKMGPK();
		BDJMJKALCDA.text = string.Empty;
		TweenAlpha component = PHPMMLNNLDA.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		PHPMMLNNLDA.alpha = 44f;
		TweenAlpha component2 = MPEBFNCHINC.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		MPEBFNCHINC.alpha = 1204f;
		ADAPMHGLGAO();
		ABPEPNPHNPI.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "Message" : "+0");
		GPFGKBJNDLM();
	}

	public void InstantHideUpgrades()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = false;
		JKGHPLKKPLE.SetActive(false);
	}

	private void IJPFPNGENHB(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 1786f);
		}
	}

	private void JLIPONCMMFE(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 0.05f);
		}
	}

	private void JNFPGEAINAK(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component == PKENJHFCOLE)
		{
			PKENJHFCOLE.enabled = !IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		}
		else if (component != null)
		{
			component.enabled = false;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.LHDGJFHPJNM())
			{
				component2.alpha1 = 410f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	public void DBPANFPEKNJ()
	{
		AIPKGLCJCAE.KEIIENDMKLN();
		WinStreakCounter aIPKGLCJCAE = AIPKGLCJCAE;
		aIPKGLCJCAE.JEMKCLKCOMI = (Action)Delegate.Remove(aIPKGLCJCAE.JEMKCLKCOMI, new Action(EKEPDPHMDGA));
	}

	private void KKPCMMOJEJK(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = true;
	}

	private void LPMNNCIKGPA(UITweener CPFGBOPPICJ)
	{
		ECILIHAEHGN();
		GCJIJKFPNFL();
		TweenAlpha tweenAlpha = HBKBMLBFOGE();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = HEDMIDOEEOM;
		}
		else
		{
			JCKOBELDCGD = false;
		}
	}

	public void JGDMLKMKHCJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KPMOMJNFELI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IAGLHNKDDEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(GEIOMOLICCC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JDIMDJMNMMN));
		UIEventListener uIEventListener3 = UIEventListener.Get(MJHJCHMEGBE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IDFPLHNDNOO));
		UIEventListener uIEventListener4 = UIEventListener.Get(JGLIKGMJDLL.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BDJFGJLJOMH));
		LCIPCONLPGE.onReposition = NFGKBMDMIJI;
		LEOBAFLAJLF.onReposition = delegate
		{
			float val = 0f - LEOBAFLAJLF.padding.x - (BDJMJKALCDA.transform.parent.transform.localPosition.x - LEOBAFLAJLF.padding.x) / 2f;
			LEOBAFLAJLF.transform.localPosition = LEOBAFLAJLF.transform.localPosition.ReplaceX(val);
		};
	}

	public void IDPMLFEOHHJ()
	{
		CNBJMDECEJG = true;
		JCKOBELDCGD = false;
		JKGHPLKKPLE.SetActive(false);
	}

	private void EDLADBBPFLF()
	{
		UpgradeSlot upgradeSlot = IFFDIHCPKFE.upgradeSlots.upgradeSlot;
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		bool flag = upgradeSlot.NNFCKENGOMF();
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.BLEGKMEKOPE();
		MHPMICFAKHA();
		GEIOMOLICCC.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Active && upgradeSlot.LKJIJJFBNLD());
		MJHJCHMEGBE.SetActive(unitState != UpgradeSlots.JLANLLEABDC.NotBuyed || upgradeSlot.FPDAMADLNGH());
		JGLIKGMJDLL.SetActive(!upgradeSlot.isTierFullUpgraded || flag || unitState == UpgradeSlots.JLANLLEABDC.Delivering || !upgradeSlot.LKJIJJFBNLD());
		LBGIFBDFHFO.SetActive(flag);
		KPMOMJNFELI.SetActive(!GEIOMOLICCC.activeSelf && !MJHJCHMEGBE.activeSelf && !JGLIKGMJDLL.activeSelf && LBGIFBDFHFO.activeSelf);
	}
}
