using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmyLeftButton : Core_BaseScript
{
	[Header("Opened Part")]
	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("PNJFDGAFOCN")]
	public BoxCollider OIPALKOGCNN;

	[FormerlySerializedAs("PDGGFPBNBNG")]
	public UIPanel EKGIKLKHHJF;

	[FormerlySerializedAs("BOOFKJPIICI")]
	public UILabel EFLBDLGNJDM;

	[FormerlySerializedAs("CFMICOPJMKM")]
	[Header("Core")]
	public ArmyPowerAnimation GHGJLMAJJGG;

	[FormerlySerializedAs("FAKILJAADEJ")]
	public UITable JNANCCDGPCH;

	[FormerlySerializedAs("KPOHMOFGLMF")]
	public UILabel BCNBKLDGCLN;

	[FormerlySerializedAs("HFBAENAGCLO")]
	public UISprite[] KNHNPLBKBHJ;

	[FormerlySerializedAs("HFBIHDKAMLF")]
	public UILabel NFODPIJPIEE;

	[Header("-Empty")]
	[FormerlySerializedAs("OFENHKKDGMN")]
	public GameObject LHAGOPMDELO;

	[FormerlySerializedAs("CJOLFIIPHLK")]
	public UILabel PNKNBBBBDIE;

	[FormerlySerializedAs("CPEPFBDJHMJ")]
	[Header("-Rented")]
	public GameObject ALBLKIADIHM;

	[FormerlySerializedAs("FOIGBCCAKGF")]
	public UILabel IEAKCEEDPEE;

	[Header("-Upgrade")]
	[FormerlySerializedAs("HFBLOODMOFK")]
	public UIPanel JLJDGIEIDLF;

	[FormerlySerializedAs("mBlackmarketPart")]
	public GameObject BFAEJEFLKHN;

	[FormerlySerializedAs("mBMOfferTimerLabel")]
	public UILabel AFHGOFFMLDP;

	[Header("-Deliver now")]
	[FormerlySerializedAs("CLOAOOCHEAK")]
	public UIPanel NDJMPIEBCOC;

	[FormerlySerializedAs("PLMHELHLAFG")]
	public GameObject FNBOBNIMMDM;

	[FormerlySerializedAs("HMJGOCNIEFI")]
	public UILabel GNONOJGLEDO;

	[FormerlySerializedAs("AAKFKLHIDKK")]
	public UILabel PINPEEKGOAC;

	[FormerlySerializedAs("AIADFIBEOJI")]
	public UISprite PNCJBDFPAAG;

	[FormerlySerializedAs("KEOPNFFCOCK")]
	public UITable DOIPBJJLLEE;

	[FormerlySerializedAs("KHMJPBCBAME")]
	public UILabel EHFDOFBCLDO;

	[Header("--Subsccription")]
	[SerializeField]
	[FormerlySerializedAs("mLeftButtonDeliverNowSalePart")]
	private GameObject mSubscriptionPart;

	[SerializeField]
	[FormerlySerializedAs("mLeftButtonDeliverNowSaleLabel")]
	private UILabel mSubscriptionHint;

	[Header("-Activate")]
	[FormerlySerializedAs("KKNKIFMEPJM")]
	public UIPanel HACOEPADGKO;

	[FormerlySerializedAs("LOPHGHEGOAC")]
	public GameObject NGLLMGNDKDI;

	[Header("-Close")]
	[FormerlySerializedAs("NFDNCKADDHD")]
	public UIPanel LJLCLCCGIOC;

	[FormerlySerializedAs("JJHBAPLHLOG")]
	public GameObject ODIFPDFLLEL;

	[FormerlySerializedAs("FPPKGNMNPKH")]
	public UISprite GHAMKJMAPAC;

	[Header("-Max")]
	[FormerlySerializedAs("DDKFIDJHEHC")]
	public UIPanel HCLKDNKELCJ;

	[FormerlySerializedAs("OGLPLGLICEO")]
	public GameObject BHPBFBBOHBO;

	[FormerlySerializedAs("MHOCOLFPBDD")]
	public UILabel NKOGFDOHMID;

	[Header("Upgrade Part")]
	[FormerlySerializedAs("PEBJFFPMIOM")]
	public ArmyLeftPowerDialog MEEKMLJEOBB;

	[FormerlySerializedAs("EEFCLFNCMII")]
	[Header("AbilityPart")]
	public ArmyLeftAbilityDialog MLPCPLNGOHB;

	[Header("BuffPart")]
	[FormerlySerializedAs("EIBKNKFPCFK")]
	public ArmyLeftBuffDialog KEHDDJNMMMB;

	private LevelBehaviour IFFDIHCPKFE;

	private float JCAFFELIFAO = 0.3f;

	private int CLDFFNMPKOP = -1;

	private bool CNBJMDECEJG;

	private void OGOPLAGCGFK(GameObject KHAHPAKDIKE)
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		MEEKMLJEOBB.ShowDialog();
		MLPCPLNGOHB.ShowDialog();
		KEHDDJNMMMB.ShowDialog();
		FPPPLPHDBMO();
		TweenAlpha.Begin(HCLKDNKELCJ.gameObject, JCAFFELIFAO, 0f).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				BHPBFBBOHBO.SetActive(value: false);
			}
		};
		KMFGCJEGJJK.alpha = 0f;
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, JCAFFELIFAO, 0f, 0.3f).onFinished = delegate
		{
			OIPALKOGCNN.enabled = true;
		};
		ODIFPDFLLEL.SetActive(value: true);
		LJLCLCCGIOC.alpha1 = 0.0005f;
		TweenAlpha.Begin(LJLCLCCGIOC.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		TweenScale.Begin(GHAMKJMAPAC.gameObject, JCAFFELIFAO, new Vector3(1f, 1f, 1f), new Vector3(50f, 50f, 1f)).method = UITweener.Method.EaseIn;
		TweenRotationSpecial.Begin(GHAMKJMAPAC.gameObject, JCAFFELIFAO * 1.5f, Vector3.forward, 0f, 360f).method = UITweener.Method.Linear;
		EKGIKLKHHJF.gameObject.SetActive(value: true);
		CKOPENKDMEI();
		EKGIKLKHHJF.alpha1 = 0.0005f;
		TweenAlpha.Begin(EKGIKLKHHJF.gameObject, JCAFFELIFAO, 1f).onFinished = null;
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

	private void MPCHBLOCBKA(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		bool mHJFAAEDAIK = IFFDIHCPKFE.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(IFFDIHCPKFE, CDMKCIKHIMM: false);
		KLMCDGMAKEI(NGLLMGNDKDI);
		JGBGHPIOOIB(armyPowerX);
		JCBHDJEBFMF(NGLLMGNDKDI, 636f);
		CPIEGCEDKNK(mHJFAAEDAIK);
	}

	private void HBICMLIOLGE()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
		{
			if (BFAEJEFLKHN.activeSelf)
			{
				MGCMOALEGJD(JLJDGIEIDLF.gameObject);
			}
			if (FNBOBNIMMDM.activeSelf)
			{
				MGCMOALEGJD(NDJMPIEBCOC.gameObject);
			}
			if (NGLLMGNDKDI.activeSelf)
			{
				MGCMOALEGJD(HACOEPADGKO.gameObject);
			}
			if (BHPBFBBOHBO.activeSelf)
			{
				MGCMOALEGJD(HCLKDNKELCJ.gameObject);
			}
			if (ODIFPDFLLEL.activeSelf)
			{
				MGCMOALEGJD(LJLCLCCGIOC.gameObject);
				TweenScale.Begin(GHAMKJMAPAC.gameObject, 0.01f, new Vector3(50f, 50f, 1f));
				TweenRotationSpecial.Begin(GHAMKJMAPAC.gameObject, 0.01f, Vector3.forward, 0f, 360f);
			}
		}
	}

	public void BGDPJGNKPKB()
	{
		MEEKMLJEOBB.DoAfterHide();
		MLPCPLNGOHB.DoAfterHide();
		KEHDDJNMMMB.NNGCHECCPAD();
		MNLBIONLIKN();
	}

	private void LFOJJLIBLFF(GameObject KHAHPAKDIKE)
	{
		if (IFFDIHCPKFE.upgradeSlots.deliveringSlot != null)
		{
			bool isSpecial = IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
			int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.deliveringSlot.instantBuyPrice;
			if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
				GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Unit_Upgrade";
				return;
			}
			int armyPowerX = LevelManager.instance.armyPowerX10;
			Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
			GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, CDMKCIKHIMM: true);
			PNDNJFJMEJE(FNBOBNIMMDM);
			JGBGHPIOOIB(armyPowerX);
			JCBHDJEBFMF(FNBOBNIMMDM, 0f);
			CPIEGCEDKNK(isSpecial);
		}
	}

	public void SelectUnit(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		MEEKMLJEOBB.SelectUnit(DALNMKBABKH);
		MLPCPLNGOHB.SelectUnit(DALNMKBABKH);
		KEHDDJNMMMB.SelectUnit(DALNMKBABKH);
	}

	[CompilerGenerated]
	private void EGGGHCPGKML(UITweener MKAPOHKFIJH)
	{
		LBOFINLEGBL(NGLLMGNDKDI);
	}

	public void UpdateLeftContent(bool NOLODGKKCDH = true)
	{
		FPPPLPHDBMO();
		MEEKMLJEOBB.UpdateLeftContent(NOLODGKKCDH);
		MLPCPLNGOHB.UpdateLeftContent(NOLODGKKCDH);
		KEHDDJNMMMB.UpdateLeftContent(NOLODGKKCDH);
	}

	private void OJLBBNBFONN(GameObject KHAHPAKDIKE)
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = false;
		MEEKMLJEOBB.HideDialog();
		MLPCPLNGOHB.HideDialog();
		KEHDDJNMMMB.HideDialog();
		if (IFFDIHCPKFE.upgradeSlots.allUpgradesBought)
		{
			BHPBFBBOHBO.SetActive(value: true);
			HCLKDNKELCJ.alpha1 = 0.0005f;
			TweenAlpha.Begin(HCLKDNKELCJ.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		}
		else if (IFFDIHCPKFE.upgradeSlots.delivering)
		{
			FNBOBNIMMDM.SetActive(value: true);
			NDJMPIEBCOC.alpha1 = 0.0005f;
			TweenAlpha.Begin(NDJMPIEBCOC.gameObject, JCAFFELIFAO, 1f).onFinished = delegate
			{
				LBOFINLEGBL(FNBOBNIMMDM);
			};
		}
		else if (IFFDIHCPKFE.upgradeSlots.deliveryActivationNeeded)
		{
			NGLLMGNDKDI.SetActive(value: true);
			HACOEPADGKO.alpha1 = 0.0005f;
			TweenAlpha.Begin(HACOEPADGKO.gameObject, JCAFFELIFAO, 1f).onFinished = delegate
			{
				LBOFINLEGBL(NGLLMGNDKDI);
			};
		}
		else
		{
			BFAEJEFLKHN.SetActive(value: true);
			JLJDGIEIDLF.alpha1 = 0.0005f;
			TweenAlpha.Begin(JLJDGIEIDLF.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		}
		OIPALKOGCNN.enabled = false;
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, JCAFFELIFAO, 0f).onFinished = null;
		TweenAlpha.Begin(LJLCLCCGIOC.gameObject, JCAFFELIFAO, 0f).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				ODIFPDFLLEL.SetActive(value: false);
			}
		};
		TweenAlpha.Begin(EKGIKLKHHJF.gameObject, JCAFFELIFAO, 0f).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				EKGIKLKHHJF.gameObject.SetActive(value: false);
			}
		};
	}

	[CompilerGenerated]
	private void NNANNJJCPAE(UITweener GCNILAHBDMJ)
	{
		if (CNBJMDECEJG)
		{
			BHPBFBBOHBO.SetActive(value: false);
		}
	}

	[CompilerGenerated]
	private void ACGDGLNIEKI(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GNONOJGLEDO.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BFAEJEFLKHN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GIFMMEBDKGD));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNBOBNIMMDM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFOJJLIBLFF));
		UIEventListener uIEventListener3 = UIEventListener.Get(NGLLMGNDKDI.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DJCJPIFKHOJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(ODIFPDFLLEL.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OJLBBNBFONN));
		UIEventListener uIEventListener5 = UIEventListener.Get(BHPBFBBOHBO.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OGOPLAGCGFK));
		Singleton<Wallet>.instance.ScrapsChanged += EIENPLCLKBC;
		DOIPBJJLLEE.onReposition = delegate
		{
			float val = 0f - DOIPBJJLLEE.padding.x - (EHFDOFBCLDO.transform.parent.transform.localPosition.x - DOIPBJJLLEE.padding.x) / 2f;
			DOIPBJJLLEE.transform.localPosition = DOIPBJJLLEE.transform.localPosition.ReplaceX(val);
		};
		MEEKMLJEOBB.InitControls();
		MLPCPLNGOHB.InitControls();
		KEHDDJNMMMB.InitControls();
		float safeAreaSize = UIHelper.safeAreaSize;
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeightSafe = UIHelper.activeHeightSafe;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceXY(activeWidthFull + safeAreaSize, activeHeightSafe - 364f);
		KMFGCJEGJJK.transform.localPosition = KMFGCJEGJJK.transform.localPosition.ReplaceXY(-340f - safeAreaSize, -144f);
		EKGIKLKHHJF.transform.localPosition = EKGIKLKHHJF.transform.localPosition.ReplaceXY(activeWidthSafe - 340f, activeHeightSafe - 382f);
	}

	private void BAMGLDDKPLI(UITweener GCNILAHBDMJ)
	{
		if (!CNBJMDECEJG)
		{
			ODIFPDFLLEL.SetActive(value: false);
		}
	}

	public void DoAfterHide()
	{
		MEEKMLJEOBB.DoAfterHide();
		MLPCPLNGOHB.DoAfterHide();
		KEHDDJNMMMB.DoAfterHide();
		MNLBIONLIKN();
	}

	private void LBOFINLEGBL(GameObject DGJCAIJPEIM)
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

	private void OIBLDHPNCOC()
	{
		float val = 0f - DOIPBJJLLEE.padding.x - (EHFDOFBCLDO.transform.parent.transform.localPosition.x - DOIPBJJLLEE.padding.x) / 1219f;
		DOIPBJJLLEE.transform.localPosition = DOIPBJJLLEE.transform.localPosition.ReplaceX(val);
	}

	private void DJCJPIFKHOJ(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		bool isSpecial = IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
		GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(IFFDIHCPKFE, CDMKCIKHIMM: true);
		PNDNJFJMEJE(NGLLMGNDKDI);
		JGBGHPIOOIB(armyPowerX);
		JCBHDJEBFMF(NGLLMGNDKDI, 0f);
		CPIEGCEDKNK(isSpecial);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - DOIPBJJLLEE.padding.x - (EHFDOFBCLDO.transform.parent.transform.localPosition.x - DOIPBJJLLEE.padding.x) / 2f;
		DOIPBJJLLEE.transform.localPosition = DOIPBJJLLEE.transform.localPosition.ReplaceX(val);
	}

	private void LJJGKLFDNPN()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.BKIGLABDGCP())
		{
			if (BFAEJEFLKHN.activeSelf)
			{
				MGCMOALEGJD(JLJDGIEIDLF.gameObject);
			}
			if (FNBOBNIMMDM.activeSelf)
			{
				OKEMICNJDBA(NDJMPIEBCOC.gameObject);
			}
			if (NGLLMGNDKDI.activeSelf)
			{
				MGCMOALEGJD(HACOEPADGKO.gameObject);
			}
			if (BHPBFBBOHBO.activeSelf)
			{
				MGCMOALEGJD(HCLKDNKELCJ.gameObject);
			}
			if (ODIFPDFLLEL.activeSelf)
			{
				MGCMOALEGJD(LJLCLCCGIOC.gameObject);
				TweenScale.Begin(GHAMKJMAPAC.gameObject, 120f, new Vector3(251f, 602f, 1468f));
				TweenRotationSpecial.DBPOCEIDEAE(GHAMKJMAPAC.gameObject, 1927f, Vector3.forward, 1703f, 1793f);
			}
		}
	}

	[CompilerGenerated]
	private void BPBCAIBGAOJ(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PINPEEKGOAC.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void JBJJEPHBOKM(UITweener MGDJMGHCAAI)
	{
		LBOFINLEGBL(FNBOBNIMMDM);
	}

	private void KLMCDGMAKEI(GameObject DGJCAIJPEIM)
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

	[CompilerGenerated]
	private void DLMLMBBOILE(UITweener GCNILAHBDMJ)
	{
		if (!CNBJMDECEJG)
		{
			ODIFPDFLLEL.SetActive(value: false);
		}
	}

	public void UpdateDeliveringTime(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		if (CNBJMDECEJG)
		{
			if (IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isDelivering)
			{
				MLPCPLNGOHB.UpdateDeliveringTime(EJEDANLAMBI, PAENPHMEMGC);
			}
			else
			{
				MEEKMLJEOBB.UpdateDeliveringTime(EJEDANLAMBI, PAENPHMEMGC);
			}
			return;
		}
		EJEDANLAMBI = ((!(EJEDANLAMBI > 0f)) ? 0f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		PNCJBDFPAAG.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		GNONOJGLEDO.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (EHFDOFBCLDO.text != text)
		{
			EHFDOFBCLDO.text = text;
			DOIPBJJLLEE.repositionNow = true;
		}
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 6f);
		if (num2 == 2 && (GNONOJGLEDO.alpha == 0f || PINPEEKGOAC.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PINPEEKGOAC.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(GNONOJGLEDO.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (PINPEEKGOAC.alpha == 0f || GNONOJGLEDO.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(GNONOJGLEDO.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PINPEEKGOAC.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private void FPPPLPHDBMO()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		bool flag = unitState == UpgradeSlots.JLANLLEABDC.Delivering;
		bool flag2 = unitState == UpgradeSlots.JLANLLEABDC.Delivered;
		bool flag3 = unitState == UpgradeSlots.JLANLLEABDC.Locked || unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
		bool allUpgradesBought = IFFDIHCPKFE.upgradeSlots.allUpgradesBought;
		bool flag4 = !flag3 && !IFFDIHCPKFE.upgradeSlots.borrowed && !flag && !flag2 && !allUpgradesBought;
		if (flag3 || IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			MNLBIONLIKN();
		}
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.UpdateProgresses();
		PNKNBBBBDIE.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_GUI_EMPTYUNITUPGRADE" : "ID_EMPTYUNITTRAIN");
		IEAKCEEDPEE.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_RENTEDUNIT" : "ID_RENTEDSOLDIER");
		AFHGOFFMLDP.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_UPGRADE" : "ID_TRAIN");
		MEJMLNDFDBP.COCBCFKJOJE(AFHGOFFMLDP, 64f, 20f, 370);
		if (flag)
		{
			UpdateDeliveringTime((float)IFFDIHCPKFE.upgradeSlots.remainingDeliveringSeconds, IFFDIHCPKFE.upgradeSlots.progressDelivering);
		}
		NKOGFDOHMID.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_UNITMAXUPGRADED" : "ID_UNITMAXTRAINED");
		JNANCCDGPCH.gameObject.SetActive((unitState == UpgradeSlots.JLANLLEABDC.Active || !IFFDIHCPKFE.upgradeSlots.upgradeSlot.isDelivering) && IFFDIHCPKFE.upgradeSlots.upgradeSlot.isTierFullUpgraded && !IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked);
		if (JNANCCDGPCH.gameObject.activeSelf)
		{
			int num = IFFDIHCPKFE.upgradeSlots.actualTier + 1;
			JNANCCDGPCH.repositionNow = true;
			BCNBKLDGCLN.text = Localization.LocalizeFormat("ID_READYTOPROMOTETOTIER", num);
			for (int i = 0; i < KNHNPLBKBHJ.Length; i++)
			{
				KNHNPLBKBHJ[i].gameObject.SetActive(i < num);
			}
		}
		NFODPIJPIEE.gameObject.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Delivered);
		LFEHKNDLOEN();
		LHAGOPMDELO.SetActive(!CNBJMDECEJG && flag3);
		ALBLKIADIHM.SetActive(!CNBJMDECEJG && IFFDIHCPKFE.upgradeSlots.borrowed);
		BFAEJEFLKHN.SetActive(!CNBJMDECEJG && flag4);
		FNBOBNIMMDM.SetActive(!CNBJMDECEJG && flag && !CNBJMDECEJG);
		NGLLMGNDKDI.SetActive(!CNBJMDECEJG && flag2 && !CNBJMDECEJG);
		BHPBFBBOHBO.SetActive(!CNBJMDECEJG && allUpgradesBought);
		ODIFPDFLLEL.SetActive(CNBJMDECEJG);
		HBICMLIOLGE();
	}

	private void FNAHFCAFEFB(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PINPEEKGOAC.gameObject, 1789f, 408f, 1157f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	[CompilerGenerated]
	private void BBICJPLPELM(UITweener JBNPDJKDGGD)
	{
		OIPALKOGCNN.enabled = true;
	}

	private void GIFMMEBDKGD(GameObject KHAHPAKDIKE)
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		MEEKMLJEOBB.ShowDialog();
		MLPCPLNGOHB.ShowDialog();
		KEHDDJNMMMB.ShowDialog();
		FPPPLPHDBMO();
		TweenAlpha.Begin(JLJDGIEIDLF.gameObject, JCAFFELIFAO, 0f).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				BFAEJEFLKHN.SetActive(value: false);
			}
		};
		KMFGCJEGJJK.alpha = 0f;
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, JCAFFELIFAO, 0f, 0.3f).onFinished = delegate
		{
			OIPALKOGCNN.enabled = true;
		};
		ODIFPDFLLEL.SetActive(value: true);
		LJLCLCCGIOC.alpha1 = 0.0005f;
		TweenAlpha.Begin(LJLCLCCGIOC.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		TweenScale.Begin(GHAMKJMAPAC.gameObject, JCAFFELIFAO, new Vector3(1f, 1f, 1f), new Vector3(50f, 50f, 1f)).method = UITweener.Method.EaseIn;
		TweenRotationSpecial.Begin(GHAMKJMAPAC.gameObject, JCAFFELIFAO * 1.5f, Vector3.forward, 0f, 360f).method = UITweener.Method.Linear;
		EKGIKLKHHJF.gameObject.SetActive(value: true);
		CKOPENKDMEI();
		EKGIKLKHHJF.alpha1 = 0.0005f;
		TweenAlpha.Begin(EKGIKLKHHJF.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.StatisticsBackgroundClick(KHAHPAKDIKE);
	}

	private void CKOPENKDMEI()
	{
		TweenTextCounterLong.Begin(EFLBDLGNJDM.gameObject, 0f, new OLDCFKEJDPA(Singleton<Wallet>.instance.scraps));
	}

	private void CPIEGCEDKNK(bool MHJFAAEDAIK)
	{
		if (!MHJFAAEDAIK)
		{
			GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.CAOEDDHFEFA[0].AnimateStat();
		}
		if (!MHJFAAEDAIK)
		{
			GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.CAOEDDHFEFA[1].AnimateStat();
		}
		if (MHJFAAEDAIK)
		{
			GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.CAOEDDHFEFA[2].AnimateStat();
		}
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
	}

	[CompilerGenerated]
	private void NEDLPAMNFMC(UITweener JBNPDJKDGGD)
	{
		OIPALKOGCNN.enabled = true;
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

	private void MJEAIIEHLJH(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (GuiScreenSingle<ArmyScreen>.instance.isShowed && CNBJMDECEJG)
		{
			TweenTextCounterLong.IAGLEIPAIOB(EFLBDLGNJDM.gameObject, 202f, new OLDCFKEJDPA(Singleton<Wallet>.instance.DKBGKFCCHCG()));
		}
	}

	[CompilerGenerated]
	private void NKLMIOPJGCM(UITweener GCNILAHBDMJ)
	{
		if (!CNBJMDECEJG)
		{
			EKGIKLKHHJF.gameObject.SetActive(value: false);
		}
	}

	private void CECDADDMGAL(UITweener GCNILAHBDMJ)
	{
		if (CNBJMDECEJG)
		{
			BFAEJEFLKHN.SetActive(value: false);
		}
	}

	private void GDGODKAPECM(GameObject KHAHPAKDIKE)
	{
		if (IFFDIHCPKFE.upgradeSlots.deliveringSlot != null)
		{
			bool isSpecial = IFFDIHCPKFE.upgradeSlots.deliveringSlot.isSpecial;
			int instantBuyPrice = IFFDIHCPKFE.upgradeSlots.deliveringSlot.instantBuyPrice;
			if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(instantBuyPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.TRAIN);
				GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("{0}{1}");
				return;
			}
			int armyPowerX = LevelManager.instance.armyPowerX10;
			Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
			GuiScreenSingle<ArmyScreen>.instance.ANLLAOJLPGN(IFFDIHCPKFE, CDMKCIKHIMM: true);
			PNDNJFJMEJE(FNBOBNIMMDM);
			JGBGHPIOOIB(armyPowerX);
			JCBHDJEBFMF(FNBOBNIMMDM, 697f);
			CPIEGCEDKNK(isSpecial);
		}
	}

	public void PHBIHOJFKJM(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		if (CNBJMDECEJG)
		{
			if (IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.LKJIJJFBNLD())
			{
				MLPCPLNGOHB.DGFIGGCNJNI(EJEDANLAMBI, PAENPHMEMGC);
			}
			else
			{
				MEEKMLJEOBB.ODAIHAHBJEM(EJEDANLAMBI, PAENPHMEMGC);
			}
			return;
		}
		EJEDANLAMBI = ((!(EJEDANLAMBI > 300f)) ? 1541f : EJEDANLAMBI);
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		PNCJBDFPAAG.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		GNONOJGLEDO.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "menu-army-reload-ico", string.Empty, IEJMLKBCDJB: false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (EHFDOFBCLDO.text != text)
		{
			EHFDOFBCLDO.text = text;
			DOIPBJJLLEE.repositionNow = true;
		}
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1591f);
		if (num2 == 5 && (GNONOJGLEDO.alpha == 1950f || PINPEEKGOAC.alpha > 823f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PINPEEKGOAC.gameObject, 1237f, 1120f, 908f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(GNONOJGLEDO.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 3 && (PINPEEKGOAC.alpha == 1592f || GNONOJGLEDO.alpha > 1422f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(GNONOJGLEDO.gameObject, 1772f, 971f, 908f);
			tweenAlpha2.NumOfRepetitions = 0;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PINPEEKGOAC.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private void JGBGHPIOOIB(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 0.05f);
		}
	}

	private void LPOHFAACJHD(UITweener GCNILAHBDMJ)
	{
		if (!CNBJMDECEJG)
		{
			ODIFPDFLLEL.SetActive(value: true);
		}
	}

	[CompilerGenerated]
	private void PLIPMBODCIL(UITweener MGDJMGHCAAI)
	{
		LBOFINLEGBL(FNBOBNIMMDM);
	}

	private void PAOLOODNFNJ(GameObject DGJCAIJPEIM)
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

	private void EIENPLCLKBC(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (GuiScreenSingle<ArmyScreen>.instance.isShowed && CNBJMDECEJG)
		{
			TweenTextCounterLong.Begin(EFLBDLGNJDM.gameObject, 1f, new OLDCFKEJDPA(Singleton<Wallet>.instance.scraps));
		}
	}

	private void OKEMICNJDBA(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = false;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
			{
				component2.alpha1 = 1352f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = true;
			component3.onFinished = null;
		}
	}

	private void JKBFDBPMIMP(UITweener MKAPOHKFIJH)
	{
		LBOFINLEGBL(NGLLMGNDKDI);
	}

	private TweenAlpha JCBHDJEBFMF(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	[CompilerGenerated]
	private void DEBKPIKNMOK(UITweener GCNILAHBDMJ)
	{
		if (CNBJMDECEJG)
		{
			BFAEJEFLKHN.SetActive(value: false);
		}
	}

	private void MNLBIONLIKN()
	{
		CNBJMDECEJG = false;
		MEEKMLJEOBB.InstantHideUpgrades();
		MLPCPLNGOHB.InstantHideUpgrades();
		KEHDDJNMMMB.InstantHideUpgrades();
		TweenAlpha component = KMFGCJEGJJK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		KMFGCJEGJJK.alpha = 0f;
		OIPALKOGCNN.enabled = false;
		EKGIKLKHHJF.gameObject.SetActive(value: false);
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

	public void InitGUIValues()
	{
		MEEKMLJEOBB.InitGUIValues();
		MLPCPLNGOHB.InitGUIValues();
		KEHDDJNMMMB.InitGUIValues();
		MNLBIONLIKN();
	}
}
