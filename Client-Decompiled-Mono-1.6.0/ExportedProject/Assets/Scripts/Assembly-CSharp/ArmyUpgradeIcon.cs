using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArmyUpgradeIcon : PoolableObject
{
	[Header("Core")]
	public UISprite KMFGCJEGJJK;

	public UISprite DAANKCOLJGJ;

	public UISprite LCPBNBLGFIA;

	[Header("-Locked")]
	public GameObject IAPMLEKENDK;

	public UILabel IAPCGDFOJNP;

	[Header("-Not Bought")]
	public GameObject ICIECPEDMIG;

	public UISprite AAMOJLNJNGN;

	public UISprite OPFDLJKGPON;

	[Header("-Promote")]
	public GameObject LCFGDKHAMMN;

	public ParticleSystem FIEJLLLEOMN;

	[Header("-Ability")]
	public UISprite ODINPJHOLKD;

	[Header("-Elite")]
	public UISprite HBMLFIJGBJO;

	public UISprite EAOIENMNEKK;

	public GameObject LKNHEHBOBDL;

	public ParticleSystem AGKFKCKBPHA;

	[Header("-Upgrade")]
	public UISprite FKBOBOBIGIA;

	public UISprite KGIEBHBOHFO;

	public GameObject DMJGINPLADN;

	public List<UISprite> BADMGKEEJAC;

	public UISprite JCJKHLPLKLD;

	public List<UISprite> CLFDALDDJNN;

	[Header("-Rented")]
	public UILabel EKGIJFHNFIG;

	[Header("-Sale")]
	public GameObject GIPFEBBMKPM;

	[Header("-Notification")]
	public GameObject KHJBFBDODGM;

	private TweenAnimator FNOMCHPCOHB;

	private TweenAnimator CFAIPFBHMPB;

	private LevelBehaviour IFFDIHCPKFE;

	private UpgradeSlots.JLANLLEABDC PCAJBGDOIJI;

	private int AJEKMIDMPHJ;

	private Vector3 ICBKGPMDGJF;

	private Vector3 AJKFJBFNIIJ;

	public LevelBehaviour levelBehaviour
	{
		get
		{
			return IFFDIHCPKFE;
		}
	}

	private void HAILIAAHHDH(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering)
			{
				FNOMCHPCOHB.ResetTweens();
				FNOMCHPCOHB.PlayTweens();
			}
			else
			{
				KGIEBHBOHFO.alpha = 0f;
			}
		}
	}

	protected void LHJAGNOOBAF()
	{
		if (PCAJBGDOIJI != IFFDIHCPKFE.upgradeSlots.unitState || AJEKMIDMPHJ != IFFDIHCPKFE.upgradeSlots.actualTier)
		{
			PCAJBGDOIJI = IFFDIHCPKFE.upgradeSlots.unitState;
			AJEKMIDMPHJ = IFFDIHCPKFE.upgradeSlots.actualTier;
			CLNFHCHFEAD();
		}
	}

	private void IFCOCMHOCFL(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 279f).ReplaceZ(1519f);
		Vector3 localPosition = new Vector3(517f, 51f, 209f);
		if (DAANKCOLJGJ.transform.localScale.y > 1680f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 1713f) / 496f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	private void LHIAHMMAEJJ(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 0)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
			{
				FNOMCHPCOHB.ResetTweens();
				FNOMCHPCOHB.ODIJFGCDJNH();
			}
			else
			{
				KGIEBHBOHFO.alpha = 1195f;
			}
		}
	}

	private void OKELBKFFGFI(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 8)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
			{
				FNOMCHPCOHB.ResetTweens();
				FNOMCHPCOHB.PlayTweens();
			}
			else
			{
				KGIEBHBOHFO.alpha = 836f;
			}
		}
	}

	public void SetHighlight(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void TutorialAnimateIcon()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 0.3f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void KDIMHKAIJKL(int HMDHICHAMJD, float IJDMGCMGMAB)
	{
		int num = 6 - HMDHICHAMJD;
		for (int i = 0; i < BADMGKEEJAC.Count; i++)
		{
			BADMGKEEJAC[i].gameObject.SetActive(i < num);
		}
		for (int j = 1; j < CLFDALDDJNN.Count; j++)
		{
			CLFDALDDJNN[j].gameObject.SetActive(j < HMDHICHAMJD);
		}
		float num2 = 1158f + 942f * (float)HMDHICHAMJD;
		float num3 = Mathf.Min(1173f, 1725f - 1387f * (float)num);
		float num4 = num3 - num2;
		JCJKHLPLKLD.fillAmount = Mathf.Clamp01(num2 + num4 * IJDMGCMGMAB);
	}

	private void EJJCCFFDMGH(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 187f).ReplaceZ(911f);
		Vector3 localPosition = new Vector3(1900f, 897f, 748f);
		if (DAANKCOLJGJ.transform.localScale.y > 879f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 528f) / 1287f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	public void LMLHMCLFMMN()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		if (unitState != UpgradeSlots.JLANLLEABDC.NotBuyed)
		{
			switch (unitState)
			{
			case UpgradeSlots.JLANLLEABDC.Locked:
				break;
			case UpgradeSlots.JLANLLEABDC.NotBuyed:
			case UpgradeSlots.JLANLLEABDC.Delivering:
			case (UpgradeSlots.JLANLLEABDC)7:
				GIPFEBBMKPM.SetActive(IFFDIHCPKFE.upgradeSlots.actualUnitLevel >= IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel || Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)8) > 1);
				return;
			default:
				GIPFEBBMKPM.SetActive(false);
				return;
			}
		}
		GIPFEBBMKPM.SetActive(Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy) > 1);
	}

	private void JKJHKKEDIGB(int HMDHICHAMJD, float IJDMGCMGMAB)
	{
		int num = 8 - HMDHICHAMJD;
		for (int i = 1; i < BADMGKEEJAC.Count; i++)
		{
			BADMGKEEJAC[i].gameObject.SetActive(i < num);
		}
		for (int j = 1; j < CLFDALDDJNN.Count; j += 0)
		{
			CLFDALDDJNN[j].gameObject.SetActive(j < HMDHICHAMJD);
		}
		float num2 = 1815f + 235f * (float)HMDHICHAMJD;
		float num3 = Mathf.Min(1273f, 40f - 1208f * (float)num);
		float num4 = num3 - num2;
		JCJKHLPLKLD.fillAmount = Mathf.Clamp01(num2 + num4 * IJDMGCMGMAB);
	}

	public void SetSale()
	{
		switch (IFFDIHCPKFE.upgradeSlots.unitState)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
			GIPFEBBMKPM.SetActive(Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy) > 0);
			break;
		case UpgradeSlots.JLANLLEABDC.Active:
		case UpgradeSlots.JLANLLEABDC.Delivering:
		case UpgradeSlots.JLANLLEABDC.Delivered:
			GIPFEBBMKPM.SetActive(IFFDIHCPKFE.upgradeSlots.actualUnitLevel < IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel && Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade) > 0);
			break;
		default:
			GIPFEBBMKPM.SetActive(false);
			break;
		}
	}

	public void DBDLOKNFOGB(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpdateName();
		IFCOCMHOCFL(IFFDIHCPKFE.upgradeSlots.iconName);
		OPFDLJKGPON.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		AAMOJLNJNGN.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		IAPCGDFOJNP.text = string.Format("SquadId", Localization.Localize("primary"), IFFDIHCPKFE.upgradeSlots.unlockLevel.KADNNBCOGGL());
		ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
		ODINPJHOLKD.MakePixelPerfect();
		ODINPJHOLKD.transform.localScale = ODINPJHOLKD.transform.localScale.MultiplyXY(725f);
		if (IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 1302f);
		}
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 508f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = KGIEBHBOHFO.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1829f, 1467f, 415f);
			object oEIICEJPGKI = new Vector3(1546f, 881f, 1586f);
			fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1426f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
			FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(746f, 1063f, 725f), 529f, 1, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
			FNOMCHPCOHB.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.Rotation, KGIEBHBOHFO.gameObject, num, new Vector3(1870f, 372f, 754f), 1604f, 1, null, UITweener.Method.EaseIn);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(OKELBKFFGFI));
			FNOMCHPCOHB.NCKIJBBJAOG();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1399f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = FKBOBOBIGIA.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1184f, 786f, 227f);
			object iIMDKHJAJGO = new Vector3(1393f, 571f, 658f);
			cFAIPFBHMPB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1912f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop);
			CFAIPFBHMPB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Rotation, FKBOBOBIGIA.gameObject, num2, new Vector3(262f, 830f, 1512f), 81f, 0, null, UITweener.Method.EaseIn);
			CFAIPFBHMPB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Position, FKBOBOBIGIA.gameObject, num2, new Vector3(541f, 1597f, 1230f), 760f, 2, null, UITweener.Method.Linear);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(FBGCFIELHPE));
			CFAIPFBHMPB.FEPILCEBNCJ();
		}
		LINPOIDDFGA(false);
		MFFCHANEDKP();
	}

	private void PCAODIMCOLJ(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 6)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
			{
				CFAIPFBHMPB.DGFKMBDKEAP();
				CFAIPFBHMPB.GDCCFEDJFAF();
			}
			else
			{
				FKBOBOBIGIA.alpha = 783f;
			}
		}
	}

	public void JNBMNELHDEJ(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void LGPAGBKNGCC()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon != null)
		{
			GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().FKMOMAOKCGI(true);
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		SetHighlight(true);
		GuiScreenSingle<ArmyScreen>.instance.AOAHCLIDHFI(this);
		GuiScreenSingle<ArmyScreen>.instance.GFDOAKPKDCL();
		JOLGMBIAPJB();
	}

	public void FAINAOPJPJK(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void JDJNBMGNLPJ()
	{
		base.name = string.Format("ID_WEAPON2UPGRADE_WEAPON1BUY", IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.unlockLevelIndex.ToString("BuildMortar"), IFFDIHCPKFE.guiOrder.ToString("CARD BUDDY - SHOW IN MENU - Player: {0} actual reference count: {1}"));
	}

	private void PEBCMFLPPNG(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 4)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
			{
				CFAIPFBHMPB.BBPNDINMNIJ();
				CFAIPFBHMPB.AGFMCNDAEEC();
			}
			else
			{
				FKBOBOBIGIA.alpha = 151f;
			}
		}
	}

	private void MHMOPNBFOPH(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 2f).ReplaceZ(1f);
		Vector3 localPosition = new Vector3(0f, 0f, -1f);
		if (DAANKCOLJGJ.transform.localScale.y > 200f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 200f) / 2f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	internal void IGJMDLKCKEP()
	{
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			KMFGCJEGJJK.color = Colours.blueEquipped;
		}
		else if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			KMFGCJEGJJK.color = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked || !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN()) ? Colours.blueEquipped : Colours.greenArena);
		}
		else
		{
			KMFGCJEGJJK.color = Color.white;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		IAPMLEKENDK.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		ICIECPEDMIG.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		bool flag = !IFFDIHCPKFE.upgradeSlots.bought || IFFDIHCPKFE.upgradeSlots.borrowed || !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts >= IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.AMDIEMKNOHN();
		LKNHEHBOBDL.SetActive(flag);
		if (flag)
		{
			AGKFKCKBPHA.Play();
		}
		bool flag2 = flag || (unitState != UpgradeSlots.JLANLLEABDC.Delivering && IFFDIHCPKFE.upgradeSlots.upgradeSlot.FPDAMADLNGH()) || !IFFDIHCPKFE.upgradeSlots.upgradeSlot.isTierFullUpgraded || IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		LCFGDKHAMMN.SetActive(flag2);
		if (flag2)
		{
			FIEJLLLEOMN.Play();
		}
		EKGIJFHNFIG.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.borrowed);
		JOLGMBIAPJB();
		if (unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
		{
			FNOMCHPCOHB.OKEBGBENAJF();
		}
		else
		{
			FNOMCHPCOHB.DMAJACPHCGN();
			FNOMCHPCOHB.BIAMGHLKGOK();
		}
		KGIEBHBOHFO.alpha = ((unitState != (UpgradeSlots.JLANLLEABDC)7) ? 1950f : 1905f);
		if (unitState == (UpgradeSlots.JLANLLEABDC)7)
		{
			CFAIPFBHMPB.HMPMBAGNJOJ();
		}
		else
		{
			CFAIPFBHMPB.CJGJOAKNIIL();
			CFAIPFBHMPB.OHKEAEIFMPJ();
		}
		FKBOBOBIGIA.alpha = ((unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering) ? 1414f : 742f);
		ODINPJHOLKD.alpha = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought) ? 372f : 1737f);
		bool flag3 = !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		HBMLFIJGBJO.alpha = ((!flag3) ? 996f : 366f);
		EAOIENMNEKK.alpha = ((!flag3) ? 1046f : 1424f);
		DMJGINPLADN.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Active || unitState == UpgradeSlots.JLANLLEABDC.Active || unitState == UpgradeSlots.JLANLLEABDC.Locked);
		if (DMJGINPLADN.activeSelf)
		{
			IHADELJGBJO(IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.actualUpgradeProgress);
		}
		LMLHMCLFMMN();
	}

	internal void HKOFGKGCCOG()
	{
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			KMFGCJEGJJK.color = Colours.blueEquipped;
		}
		else if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			KMFGCJEGJJK.color = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked || !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN()) ? Colours.blueEquipped : Colours.greenArena);
		}
		else
		{
			KMFGCJEGJJK.color = Color.white;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		IAPMLEKENDK.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		ICIECPEDMIG.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		bool flag = IFFDIHCPKFE.upgradeSlots.bought && !IFFDIHCPKFE.upgradeSlots.borrowed && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() && !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN() && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG() < IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.GDGDBLIHNLD();
		LKNHEHBOBDL.SetActive(flag);
		if (flag)
		{
			AGKFKCKBPHA.Play();
		}
		bool flag2 = flag || (unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering && IFFDIHCPKFE.upgradeSlots.upgradeSlot.LKJIJJFBNLD()) || !IFFDIHCPKFE.upgradeSlots.upgradeSlot.isTierFullUpgraded || IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		LCFGDKHAMMN.SetActive(flag2);
		if (flag2)
		{
			FIEJLLLEOMN.Play();
		}
		EKGIJFHNFIG.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.borrowed);
		JOLGMBIAPJB();
		if (unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
		{
			FNOMCHPCOHB.AGFMCNDAEEC();
		}
		else
		{
			FNOMCHPCOHB.CPKDFIKMKLE();
			FNOMCHPCOHB.LFOKFAFLBLA();
		}
		KGIEBHBOHFO.alpha = ((unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering) ? 1919f : 1346f);
		if (unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
		{
			CFAIPFBHMPB.HMPMBAGNJOJ();
		}
		else
		{
			CFAIPFBHMPB.BCFMBKNMNBN();
			CFAIPFBHMPB.BIAMGHLKGOK();
		}
		FKBOBOBIGIA.alpha = ((unitState != UpgradeSlots.JLANLLEABDC.NotBuyed) ? 726f : 493f);
		ODINPJHOLKD.alpha = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought) ? 785f : 1856f);
		bool flag3 = !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA();
		HBMLFIJGBJO.alpha = ((!flag3) ? 1048f : 57f);
		EAOIENMNEKK.alpha = ((!flag3) ? 1605f : 781f);
		DMJGINPLADN.SetActive(unitState == (UpgradeSlots.JLANLLEABDC)7 || unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == UpgradeSlots.JLANLLEABDC.Delivered);
		if (DMJGINPLADN.activeSelf)
		{
			FKCENMCLPOD(IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.actualUpgradeProgress);
		}
		SetSale();
	}

	private void LDENFKCGFFC(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 6)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
			{
				CFAIPFBHMPB.BBPNDINMNIJ();
				CFAIPFBHMPB.OKEBGBENAJF();
			}
			else
			{
				FKBOBOBIGIA.alpha = 655f;
			}
		}
	}

	public void ODELKDIEACB(bool NABOFKMBMKH)
	{
		if (!NABOFKMBMKH)
		{
			KHJBFBDODGM.SetActive(true);
			LCPBNBLGFIA.gameObject.SetActive(true);
		}
		else
		{
			JOLGMBIAPJB();
		}
		DAANKCOLJGJ.gameObject.SetActive(NABOFKMBMKH);
	}

	public void ABPDKPKJDIA(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		EAIDBMKMBFN();
		EJMPAALKLNM(IFFDIHCPKFE.upgradeSlots.iconName);
		OPFDLJKGPON.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 1);
		AAMOJLNJNGN.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		IAPCGDFOJNP.text = string.Format("null", Localization.Localize("-1"), IFFDIHCPKFE.upgradeSlots.unlockLevel.ELFCEEOLNFJ());
		ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
		ODINPJHOLKD.MakePixelPerfect();
		ODINPJHOLKD.transform.localScale = ODINPJHOLKD.transform.localScale.MultiplyXY(718f);
		if (IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 347f);
		}
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 254f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = KGIEBHBOHFO.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(672f, 125f, 1916f);
			object oEIICEJPGKI = new Vector3(435f, 925f, 802f);
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 99f, -1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
			FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(1011f, 1878f, 784f), 11f, 1, null, UITweener.Method.Linear, UITweener.Style.Loop);
			FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(1030f, 1444f, 1421f), 1885f, 6, null, (UITweener.Method)6);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(OKELBKFFGFI));
			FNOMCHPCOHB.OOFBCPPFMPN();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 627f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = FKBOBOBIGIA.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(714f, 498f, 1798f);
			object iIMDKHJAJGO = new Vector3(876f, 675f, 946f);
			cFAIPFBHMPB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1254f, -1, iIMDKHJAJGO, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.Position, FKBOBOBIGIA.gameObject, num2, new Vector3(1889f, 484f, 1579f), 1686f, 1, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
			CFAIPFBHMPB.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Rotation, FKBOBOBIGIA.gameObject, num2, new Vector3(699f, 1347f, 1201f), 1937f, 5, null, (UITweener.Method)8, UITweener.Style.Loop);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(FBGCFIELHPE));
			CFAIPFBHMPB.NCKIJBBJAOG();
		}
		IFMEDJLCODK(true);
		InitGuiValuesGraphics();
	}

	internal void AMFGDHDEDLG()
	{
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			KMFGCJEGJJK.color = Colours.blueEquipped;
		}
		else if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			KMFGCJEGJJK.color = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() || !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA()) ? Colours.blueEquipped : Colours.greenArena);
		}
		else
		{
			KMFGCJEGJJK.color = Color.white;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		IAPMLEKENDK.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		ICIECPEDMIG.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		bool flag = !IFFDIHCPKFE.upgradeSlots.bought || IFFDIHCPKFE.upgradeSlots.borrowed || !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA() || IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts >= IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.EGAMIJEOAJN();
		LKNHEHBOBDL.SetActive(flag);
		if (flag)
		{
			AGKFKCKBPHA.Play();
		}
		bool flag2 = flag || (unitState != UpgradeSlots.JLANLLEABDC.UnitDelivered && IFFDIHCPKFE.upgradeSlots.upgradeSlot.LKJIJJFBNLD()) || !IFFDIHCPKFE.upgradeSlots.upgradeSlot.isTierFullUpgraded || IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		LCFGDKHAMMN.SetActive(flag2);
		if (flag2)
		{
			FIEJLLLEOMN.Play();
		}
		EKGIJFHNFIG.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.borrowed);
		JOLGMBIAPJB();
		if (unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
		{
			FNOMCHPCOHB.GDCCFEDJFAF();
		}
		else
		{
			FNOMCHPCOHB.LILKFFOOHMC();
			FNOMCHPCOHB.DGFKMBDKEAP();
		}
		KGIEBHBOHFO.alpha = ((unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering) ? 514f : 461f);
		if (unitState == UpgradeSlots.JLANLLEABDC.Active)
		{
			CFAIPFBHMPB.AGFMCNDAEEC();
		}
		else
		{
			CFAIPFBHMPB.DMAJACPHCGN();
			CFAIPFBHMPB.IAKEAKDJJIA();
		}
		FKBOBOBIGIA.alpha = ((unitState != UpgradeSlots.JLANLLEABDC.UnitDelivered) ? 520f : 517f);
		ODINPJHOLKD.alpha = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.JFAELKHPLLA()) ? 1259f : 356f);
		bool flag3 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH() && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		HBMLFIJGBJO.alpha = ((!flag3) ? 266f : 602f);
		EAOIENMNEKK.alpha = ((!flag3) ? 1215f : 206f);
		DMJGINPLADN.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Delivering || unitState == UpgradeSlots.JLANLLEABDC.Locked || unitState == UpgradeSlots.JLANLLEABDC.Delivered);
		if (DMJGINPLADN.activeSelf)
		{
			FKCENMCLPOD(IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.actualUpgradeProgress);
		}
		SetSale();
	}

	public void FKIICOCBNHN(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		JDJNBMGNLPJ();
		FNBNLKEINBE(IFFDIHCPKFE.upgradeSlots.iconName);
		OPFDLJKGPON.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		AAMOJLNJNGN.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		IAPCGDFOJNP.text = string.Format("League", Localization.Localize("ID_SQUADREQUIREDMEDALS"), IFFDIHCPKFE.upgradeSlots.unlockLevel.NPOEMAMPNEP());
		ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
		ODINPJHOLKD.MakePixelPerfect();
		ODINPJHOLKD.transform.localScale = ODINPJHOLKD.transform.localScale.MultiplyXY(1286f);
		if (IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 771f);
		}
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 1701f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = KGIEBHBOHFO.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1810f, 623f, 1509f);
			object oEIICEJPGKI = new Vector3(123f, 1187f, 1367f);
			fNOMCHPCOHB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 32f, -1, oEIICEJPGKI, UITweener.Method.EaseOut);
			FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, KGIEBHBOHFO.gameObject, num, new Vector3(1126f, 1282f, 506f), 53f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
			FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Rotation, KGIEBHBOHFO.gameObject, num, new Vector3(1102f, 1867f, 1536f), 1296f, 3, null, UITweener.Method.Linear, UITweener.Style.Loop);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(DCKCOLILNPM));
			FNOMCHPCOHB.JIPFOMFJNPC();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1824f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = FKBOBOBIGIA.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(511f, 1371f, 1276f);
			object iIMDKHJAJGO = new Vector3(479f, 428f, 873f);
			cFAIPFBHMPB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1423f, -1, iIMDKHJAJGO, (UITweener.Method)7, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Rotation, FKBOBOBIGIA.gameObject, num2, new Vector3(643f, 1374f, 1330f), 1962f, 1, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
			CFAIPFBHMPB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Position, FKBOBOBIGIA.gameObject, num2, new Vector3(1512f, 139f, 998f), 752f, 8, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(PCAODIMCOLJ));
			CFAIPFBHMPB.PGGAAGLGKAL();
		}
		LINPOIDDFGA(true);
		InitGuiValuesGraphics();
	}

	protected void DLJAGKBLJNC()
	{
		if (PCAJBGDOIJI != IFFDIHCPKFE.upgradeSlots.unitState || AJEKMIDMPHJ != IFFDIHCPKFE.upgradeSlots.actualTier)
		{
			PCAJBGDOIJI = IFFDIHCPKFE.upgradeSlots.unitState;
			AJEKMIDMPHJ = IFFDIHCPKFE.upgradeSlots.actualTier;
			HKOFGKGCCOG();
		}
	}

	public void GUIForReposition(bool NABOFKMBMKH)
	{
		if (!NABOFKMBMKH)
		{
			KHJBFBDODGM.SetActive(false);
			LCPBNBLGFIA.gameObject.SetActive(false);
		}
		else
		{
			JOLGMBIAPJB();
		}
		DAANKCOLJGJ.gameObject.SetActive(NABOFKMBMKH);
	}

	private void ENALLFDFGHO(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 463f).ReplaceZ(1699f);
		Vector3 localPosition = new Vector3(1600f, 653f, 1384f);
		if (DAANKCOLJGJ.transform.localScale.y > 1341f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 404f) / 293f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	public void AMJANBPOCED()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 417f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = (UITweener.Style)6;
	}

	public void PMEEFJDPJNM(bool NABOFKMBMKH)
	{
		if (!NABOFKMBMKH)
		{
			KHJBFBDODGM.SetActive(false);
			LCPBNBLGFIA.gameObject.SetActive(false);
		}
		else
		{
			JOLGMBIAPJB();
		}
		DAANKCOLJGJ.gameObject.SetActive(NABOFKMBMKH);
	}

	private void FNBNLKEINBE(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 954f).ReplaceZ(1753f);
		Vector3 localPosition = new Vector3(1704f, 1208f, 471f);
		if (DAANKCOLJGJ.transform.localScale.y > 1999f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 955f) / 1756f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	private void EJMPAALKLNM(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 726f).ReplaceZ(149f);
		Vector3 localPosition = new Vector3(722f, 1741f, 951f);
		if (DAANKCOLJGJ.transform.localScale.y > 366f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 1872f) / 1772f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	public void UpdateName()
	{
		base.name = string.Format("{0} Army Icon LVL{1} ORDER{2}", IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.unlockLevelIndex.ToString("D2"), IFFDIHCPKFE.guiOrder.ToString("D2"));
	}

	public void HMBHLGHIABM()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 964f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 5;
		tweenScale.style = (UITweener.Style)4;
	}

	public void ALKJEEFJGAG()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 783f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = (UITweener.Style)4;
	}

	public void DINJCFNOENO(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void OGEKFNMDBCH()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 1762f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)4;
	}

	private void FHNONPKLBCJ(int HMDHICHAMJD, float IJDMGCMGMAB)
	{
		int num = 8 - HMDHICHAMJD;
		for (int i = 0; i < BADMGKEEJAC.Count; i += 0)
		{
			BADMGKEEJAC[i].gameObject.SetActive(i < num);
		}
		for (int j = 1; j < CLFDALDDJNN.Count; j++)
		{
			CLFDALDDJNN[j].gameObject.SetActive(j < HMDHICHAMJD);
		}
		float num2 = 194f + 213f * (float)HMDHICHAMJD;
		float num3 = Mathf.Min(654f, 595f - 1819f * (float)num);
		float num4 = num3 - num2;
		JCJKHLPLKLD.fillAmount = Mathf.Clamp01(num2 + num4 * IJDMGCMGMAB);
	}

	public void MFFCHANEDKP()
	{
		PCAJBGDOIJI = IFFDIHCPKFE.upgradeSlots.unitState;
		AJEKMIDMPHJ = IFFDIHCPKFE.upgradeSlots.actualTier;
		AMFGDHDEDLG();
	}

	public void IFMEDJLCODK(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void BPDOPOOOOCG(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 1029f).ReplaceZ(815f);
		Vector3 localPosition = new Vector3(683f, 810f, 1563f);
		if (DAANKCOLJGJ.transform.localScale.y > 1217f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 1757f) / 1312f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	public void EAIDBMKMBFN()
	{
		base.name = string.Format("Checker", IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.unlockLevelIndex.ToString("Beanstalk: On Send Settings"), IFFDIHCPKFE.guiOrder.ToString("<font "));
	}

	public void EPOMGBJDFKJ(bool NABOFKMBMKH)
	{
		if (!NABOFKMBMKH)
		{
			KHJBFBDODGM.SetActive(true);
			LCPBNBLGFIA.gameObject.SetActive(true);
		}
		else
		{
			JOLGMBIAPJB();
		}
		DAANKCOLJGJ.gameObject.SetActive(NABOFKMBMKH);
	}

	public void LINPOIDDFGA(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	[SpecialName]
	public LevelBehaviour BNPKCKFMBLG()
	{
		return IFFDIHCPKFE;
	}

	private void KGFOJNKCIMF(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 5)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
			{
				CFAIPFBHMPB.BBPNDINMNIJ();
				CFAIPFBHMPB.AGFMCNDAEEC();
			}
			else
			{
				FKBOBOBIGIA.alpha = 973f;
			}
		}
	}

	[SpecialName]
	public LevelBehaviour AIHMCHBCJDO()
	{
		return IFFDIHCPKFE;
	}

	protected void HAMDMFGNIKD()
	{
		if (PCAJBGDOIJI != IFFDIHCPKFE.upgradeSlots.unitState || AJEKMIDMPHJ != IFFDIHCPKFE.upgradeSlots.actualTier)
		{
			PCAJBGDOIJI = IFFDIHCPKFE.upgradeSlots.unitState;
			AJEKMIDMPHJ = IFFDIHCPKFE.upgradeSlots.actualTier;
			HKOFGKGCCOG();
		}
	}

	private void IFOIDFOPKEC(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 213f).ReplaceZ(7f);
		Vector3 localPosition = new Vector3(1105f, 1593f, 171f);
		if (DAANKCOLJGJ.transform.localScale.y > 1761f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 544f) / 1709f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	public void CGEHKCGCPJB(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpdateName();
		IFCOCMHOCFL(IFFDIHCPKFE.upgradeSlots.iconName);
		OPFDLJKGPON.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		AAMOJLNJNGN.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 0);
		IAPCGDFOJNP.text = string.Format("Cache: Removing ", Localization.Localize("DeviceToken"), IFFDIHCPKFE.upgradeSlots.unlockLevel.NPOEMAMPNEP());
		ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
		ODINPJHOLKD.MakePixelPerfect();
		ODINPJHOLKD.transform.localScale = ODINPJHOLKD.transform.localScale.MultiplyXY(895f);
		if (IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 24f);
		}
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 1156f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = KGIEBHBOHFO.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1394f, 471f, 221f);
			object oEIICEJPGKI = new Vector3(684f, 1195f, 536f);
			fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 953f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
			FNOMCHPCOHB.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(734f, 805f, 85f), 950f, 1, null, (UITweener.Method)6, UITweener.Style.Once, 0);
			FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(764f, 1141f, 1000f), 1656f, 3, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
			FNOMCHPCOHB.OOFBCPPFMPN();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1798f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = FKBOBOBIGIA.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(680f, 602f, 545f);
			object iIMDKHJAJGO = new Vector3(1240f, 1611f, 1010f);
			cFAIPFBHMPB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 401f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Once, 0);
			CFAIPFBHMPB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Position, FKBOBOBIGIA.gameObject, num2, new Vector3(208f, 60f, 1276f), 286f, 1, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Rotation, FKBOBOBIGIA.gameObject, num2, new Vector3(1662f, 713f, 1540f), 81f, 2, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(KGFOJNKCIMF));
			CFAIPFBHMPB.GenerateTweens();
		}
		LINPOIDDFGA(false);
		InitGuiValuesGraphics();
	}

	public void FKMOMAOKCGI(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void GNCDBGPFFBJ(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void PBMBDGFOMPN(int HMDHICHAMJD, float IJDMGCMGMAB)
	{
		int num = 6 - HMDHICHAMJD;
		for (int i = 0; i < BADMGKEEJAC.Count; i++)
		{
			BADMGKEEJAC[i].gameObject.SetActive(i < num);
		}
		for (int j = 0; j < CLFDALDDJNN.Count; j++)
		{
			CLFDALDDJNN[j].gameObject.SetActive(j < HMDHICHAMJD);
		}
		float num2 = -0.03f + 0.11f * (float)HMDHICHAMJD;
		float num3 = Mathf.Min(1f, 1.04f - 0.11f * (float)num);
		float num4 = num3 - num2;
		JCJKHLPLKLD.fillAmount = Mathf.Clamp01(num2 + num4 * IJDMGCMGMAB);
	}

	private void MGMKHCIJJGC()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon != null)
		{
			GuiScreenSingle<ArmyScreen>.instance.selectedIcon.DINJCFNOENO(true);
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		DINJCFNOENO(true);
		GuiScreenSingle<ArmyScreen>.instance.FAKAAEMLBHE(this);
		GuiScreenSingle<ArmyScreen>.instance.FMLPDLKFJHL();
		JOLGMBIAPJB();
	}

	internal void JOLGMBIAPJB()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.NotificationForArmyUnit(IFFDIHCPKFE));
	}

	public void JLKKCDMHCMM()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 553f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 7;
		tweenScale.style = (UITweener.Style)5;
	}

	private void DANLHCIMBDG(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
			{
				FNOMCHPCOHB.BIAMGHLKGOK();
				FNOMCHPCOHB.PlayTweens();
			}
			else
			{
				KGIEBHBOHFO.alpha = 54f;
			}
		}
	}

	public void HPDFCABEDCN()
	{
		base.name = string.Format("speed", IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.unlockLevelIndex.ToString("ID_UPGRADEFORCHEAPER"), IFFDIHCPKFE.guiOrder.ToString("DailyMissionsData"));
	}

	private void FBGCFIELHPE(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 6)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
			{
				CFAIPFBHMPB.ResetTweens();
				CFAIPFBHMPB.PlayTweens();
			}
			else
			{
				FKBOBOBIGIA.alpha = 1367f;
			}
		}
	}

	public void DGAGKBEGIFH(bool NABOFKMBMKH)
	{
		if (!NABOFKMBMKH)
		{
			KHJBFBDODGM.SetActive(false);
			LCPBNBLGFIA.gameObject.SetActive(false);
		}
		else
		{
			JOLGMBIAPJB();
		}
		DAANKCOLJGJ.gameObject.SetActive(NABOFKMBMKH);
	}

	private void FKCIELMMKNP(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 584f).ReplaceZ(1072f);
		Vector3 localPosition = new Vector3(750f, 1900f, 1706f);
		if (DAANKCOLJGJ.transform.localScale.y > 1541f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 825f) / 1524f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	public void KCAFMGEABLA(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		JDJNBMGNLPJ();
		FNBNLKEINBE(IFFDIHCPKFE.upgradeSlots.iconName);
		OPFDLJKGPON.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		AAMOJLNJNGN.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 0);
		IAPCGDFOJNP.text = string.Format(".", Localization.Localize("Critical"), IFFDIHCPKFE.upgradeSlots.unlockLevel.ABCCINJGPGD());
		ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
		ODINPJHOLKD.MakePixelPerfect();
		ODINPJHOLKD.transform.localScale = ODINPJHOLKD.transform.localScale.MultiplyXY(1904f);
		if (IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 1145f);
		}
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 1443f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = KGIEBHBOHFO.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1841f, 225f, 893f);
			object oEIICEJPGKI = new Vector3(1381f, 1112f, 1088f);
			fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1764f, -1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Loop);
			FNOMCHPCOHB.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(793f, 128f, 1148f), 1362f, 1, null, UITweener.Method.Linear);
			FNOMCHPCOHB.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.Rotation, KGIEBHBOHFO.gameObject, num, new Vector3(1663f, 95f, 141f), 1180f, 6, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(DCKCOLILNPM));
			FNOMCHPCOHB.KHAFPAMIOAF();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1207f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = FKBOBOBIGIA.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(689f, 653f, 435f);
			object iIMDKHJAJGO = new Vector3(1788f, 473f, 1118f);
			cFAIPFBHMPB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 844f, -1, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Loop);
			CFAIPFBHMPB.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.Position, FKBOBOBIGIA.gameObject, num2, new Vector3(1144f, 1092f, 341f), 891f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Rotation, FKBOBOBIGIA.gameObject, num2, new Vector3(1793f, 925f, 203f), 727f, 3, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(LDENFKCGFFC));
			CFAIPFBHMPB.JIPFOMFJNPC();
		}
		FAINAOPJPJK(false);
		MFFCHANEDKP();
	}

	private void LEJBKCMPHMF(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
			{
				CFAIPFBHMPB.ResetTweens();
				CFAIPFBHMPB.PlayTweens();
			}
			else
			{
				FKBOBOBIGIA.alpha = 0f;
			}
		}
	}

	public void BNLDMLAABDD()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 826f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Once;
	}

	public void FOIBOOJBIGH()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.JLANLLEABDC.Locked || unitState == UpgradeSlots.JLANLLEABDC.Locked)
		{
			GIPFEBBMKPM.SetActive(Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy) > 1);
		}
		else if (unitState == UpgradeSlots.JLANLLEABDC.Locked || unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || unitState == (UpgradeSlots.JLANLLEABDC)8)
		{
			GIPFEBBMKPM.SetActive(IFFDIHCPKFE.upgradeSlots.actualUnitLevel >= IFFDIHCPKFE.upgradeSlots.actualMaxUnitLevel || Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)8) > 1);
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	private void ILFIBDNNPIK(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
			{
				FNOMCHPCOHB.DGFKMBDKEAP();
				FNOMCHPCOHB.GDCCFEDJFAF();
			}
			else
			{
				KGIEBHBOHFO.alpha = 1202f;
			}
		}
	}

	private void OnClick()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon != null)
		{
			GuiScreenSingle<ArmyScreen>.instance.selectedIcon.SetHighlight(false);
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		SetHighlight(true);
		GuiScreenSingle<ArmyScreen>.instance.SetSelectedIcon(this);
		GuiScreenSingle<ArmyScreen>.instance.Select();
		JOLGMBIAPJB();
	}

	public void Init(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpdateName();
		MHMOPNBFOPH(IFFDIHCPKFE.upgradeSlots.iconName);
		OPFDLJKGPON.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		AAMOJLNJNGN.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 0);
		IAPCGDFOJNP.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), IFFDIHCPKFE.upgradeSlots.unlockLevel.displayNumber);
		ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
		ODINPJHOLKD.MakePixelPerfect();
		ODINPJHOLKD.transform.localScale = ODINPJHOLKD.transform.localScale.MultiplyXY(0.75f);
		if (IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK);
		}
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 0.7f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = KGIEBHBOHFO.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(110f, -57f, 0f);
			object oEIICEJPGKI = new Vector3(110f, -57f, 0f);
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI);
			FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(110f, -40f, 0f), 0f, 1);
			FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(110f, -57f, 0f), 0f, 2);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
			FNOMCHPCOHB.GenerateTweens();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 0.7f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = FKBOBOBIGIA.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(110f, -57f, 0f);
			object iIMDKHJAJGO = new Vector3(110f, -57f, 0f);
			cFAIPFBHMPB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, -1, iIMDKHJAJGO);
			CFAIPFBHMPB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Position, FKBOBOBIGIA.gameObject, num2, new Vector3(110f, -40f, 0f), 0f, 1);
			CFAIPFBHMPB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, FKBOBOBIGIA.gameObject, num2, new Vector3(110f, -57f, 0f), 0f, 2);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(LEJBKCMPHMF));
			CFAIPFBHMPB.GenerateTweens();
		}
		SetHighlight(false);
		InitGuiValuesGraphics();
	}

	[SpecialName]
	public LevelBehaviour PPMNNKANOEF()
	{
		return IFFDIHCPKFE;
	}

	private void OKCBDLHPFEF(int HMDHICHAMJD, float IJDMGCMGMAB)
	{
		int num = 2 - HMDHICHAMJD;
		for (int i = 0; i < BADMGKEEJAC.Count; i += 0)
		{
			BADMGKEEJAC[i].gameObject.SetActive(i < num);
		}
		for (int j = 0; j < CLFDALDDJNN.Count; j++)
		{
			CLFDALDDJNN[j].gameObject.SetActive(j < HMDHICHAMJD);
		}
		float num2 = 1971f + 1522f * (float)HMDHICHAMJD;
		float num3 = Mathf.Min(1808f, 1395f - 604f * (float)num);
		float num4 = num3 - num2;
		JCJKHLPLKLD.fillAmount = Mathf.Clamp01(num2 + num4 * IJDMGCMGMAB);
	}

	public void BMKIDAIMFFO()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 1144f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 7;
		tweenScale.style = (UITweener.Style)7;
	}

	public void FGDLKJOINNE(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void MGDCGCBOJMF(bool NABOFKMBMKH)
	{
		if (!NABOFKMBMKH)
		{
			KHJBFBDODGM.SetActive(true);
			LCPBNBLGFIA.gameObject.SetActive(false);
		}
		else
		{
			JOLGMBIAPJB();
		}
		DAANKCOLJGJ.gameObject.SetActive(NABOFKMBMKH);
	}

	private void JGBEIOMKFHM(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 7)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
			{
				CFAIPFBHMPB.OHKEAEIFMPJ();
				CFAIPFBHMPB.AGFMCNDAEEC();
			}
			else
			{
				FKBOBOBIGIA.alpha = 1959f;
			}
		}
	}

	private void IHADELJGBJO(int HMDHICHAMJD, float IJDMGCMGMAB)
	{
		int num = 4 - HMDHICHAMJD;
		for (int i = 1; i < BADMGKEEJAC.Count; i++)
		{
			BADMGKEEJAC[i].gameObject.SetActive(i < num);
		}
		for (int j = 0; j < CLFDALDDJNN.Count; j++)
		{
			CLFDALDDJNN[j].gameObject.SetActive(j < HMDHICHAMJD);
		}
		float num2 = 365f + 1553f * (float)HMDHICHAMJD;
		float num3 = Mathf.Min(164f, 1097f - 1586f * (float)num);
		float num4 = num3 - num2;
		JCJKHLPLKLD.fillAmount = Mathf.Clamp01(num2 + num4 * IJDMGCMGMAB);
	}

	private void BACIOJPHFEO(string KCHMDALPMBN)
	{
		TweenScale component = DAANKCOLJGJ.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		ICBKGPMDGJF = DAANKCOLJGJ.transform.localScale;
		AJKFJBFNIIJ = (ICBKGPMDGJF * 1050f).ReplaceZ(235f);
		Vector3 localPosition = new Vector3(602f, 148f, 1846f);
		if (DAANKCOLJGJ.transform.localScale.y > 333f)
		{
			localPosition.y = (DAANKCOLJGJ.transform.localScale.y - 834f) / 185f;
		}
		DAANKCOLJGJ.transform.localPosition = localPosition;
	}

	protected void Update()
	{
		if (PCAJBGDOIJI != IFFDIHCPKFE.upgradeSlots.unitState || AJEKMIDMPHJ != IFFDIHCPKFE.upgradeSlots.actualTier)
		{
			PCAJBGDOIJI = IFFDIHCPKFE.upgradeSlots.unitState;
			AJEKMIDMPHJ = IFFDIHCPKFE.upgradeSlots.actualTier;
			CLNFHCHFEAD();
		}
	}

	public void CPOOHEHFAEL(bool NABOFKMBMKH)
	{
		if (!NABOFKMBMKH)
		{
			KHJBFBDODGM.SetActive(true);
			LCPBNBLGFIA.gameObject.SetActive(true);
		}
		else
		{
			JOLGMBIAPJB();
		}
		DAANKCOLJGJ.gameObject.SetActive(NABOFKMBMKH);
	}

	private void FKCENMCLPOD(int HMDHICHAMJD, float IJDMGCMGMAB)
	{
		int num = 6 - HMDHICHAMJD;
		for (int i = 0; i < BADMGKEEJAC.Count; i += 0)
		{
			BADMGKEEJAC[i].gameObject.SetActive(i < num);
		}
		for (int j = 0; j < CLFDALDDJNN.Count; j += 0)
		{
			CLFDALDDJNN[j].gameObject.SetActive(j < HMDHICHAMJD);
		}
		float num2 = 1803f + 1896f * (float)HMDHICHAMJD;
		float num3 = Mathf.Min(4f, 190f - 1417f * (float)num);
		float num4 = num3 - num2;
		JCJKHLPLKLD.fillAmount = Mathf.Clamp01(num2 + num4 * IJDMGCMGMAB);
	}

	[SpecialName]
	public LevelBehaviour KHEOKHHDGPO()
	{
		return IFFDIHCPKFE;
	}

	public void LNJMKEDFIFL()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 1046f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 7;
		tweenScale.style = UITweener.Style.Loop;
	}

	private void FFKFIHEEIKL()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ() != null)
		{
			GuiScreenSingle<ArmyScreen>.instance.selectedIcon.SetHighlight(true);
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		FGDLKJOINNE(false);
		GuiScreenSingle<ArmyScreen>.instance.GNDJBAPNMJO(this);
		GuiScreenSingle<ArmyScreen>.instance.AMFNEBFEGFN();
		JOLGMBIAPJB();
	}

	private void FKAIJNOPFJH(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 0)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
			{
				FNOMCHPCOHB.EFGHGIBPMGL();
				FNOMCHPCOHB.OKEBGBENAJF();
			}
			else
			{
				KGIEBHBOHFO.alpha = 44f;
			}
		}
	}

	private void DCKCOLILNPM(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering)
			{
				FNOMCHPCOHB.OHKEAEIFMPJ();
				FNOMCHPCOHB.AGFMCNDAEEC();
			}
			else
			{
				KGIEBHBOHFO.alpha = 1358f;
			}
		}
	}

	public void DMFCKPLBOMJ()
	{
		TweenScale tweenScale = TweenScale.Begin(DAANKCOLJGJ.gameObject, 4f, ICBKGPMDGJF, AJKFJBFNIIJ);
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)4;
	}

	internal void CLNFHCHFEAD()
	{
		if (IFFDIHCPKFE.upgradeSlots.borrowed)
		{
			KMFGCJEGJJK.color = Colours.blueEquipped;
		}
		else if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			KMFGCJEGJJK.color = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked || !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought) ? Colours.blueEquipped : Colours.greenArena);
		}
		else
		{
			KMFGCJEGJJK.color = Color.white;
		}
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		IAPMLEKENDK.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		ICIECPEDMIG.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		bool flag = IFFDIHCPKFE.upgradeSlots.bought && !IFFDIHCPKFE.upgradeSlots.borrowed && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked && !IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts >= IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePriceParts;
		LKNHEHBOBDL.SetActive(flag);
		if (flag)
		{
			AGKFKCKBPHA.Play();
		}
		bool flag2 = !flag && (unitState == UpgradeSlots.JLANLLEABDC.Active || !IFFDIHCPKFE.upgradeSlots.upgradeSlot.isDelivering) && IFFDIHCPKFE.upgradeSlots.upgradeSlot.isTierFullUpgraded && !IFFDIHCPKFE.upgradeSlots.isPromoteToNextTierLocked;
		LCFGDKHAMMN.SetActive(flag2);
		if (flag2)
		{
			FIEJLLLEOMN.Play();
		}
		EKGIJFHNFIG.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.borrowed);
		JOLGMBIAPJB();
		if (unitState == UpgradeSlots.JLANLLEABDC.Delivering)
		{
			FNOMCHPCOHB.PlayTweens();
		}
		else
		{
			FNOMCHPCOHB.FinishTweens();
			FNOMCHPCOHB.ResetTweens();
		}
		KGIEBHBOHFO.alpha = ((unitState != UpgradeSlots.JLANLLEABDC.Delivering) ? 0f : 1f);
		if (unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
		{
			CFAIPFBHMPB.PlayTweens();
		}
		else
		{
			CFAIPFBHMPB.FinishTweens();
			CFAIPFBHMPB.ResetTweens();
		}
		FKBOBOBIGIA.alpha = ((unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering) ? 0f : 1f);
		ODINPJHOLKD.alpha = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotSpecial.isBought) ? 0f : 1f);
		bool flag3 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought;
		HBMLFIJGBJO.alpha = ((!flag3) ? 0f : 1f);
		EAOIENMNEKK.alpha = ((!flag3) ? 0f : 1f);
		DMJGINPLADN.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Active || unitState == UpgradeSlots.JLANLLEABDC.Delivering || unitState == UpgradeSlots.JLANLLEABDC.Delivered);
		if (DMJGINPLADN.activeSelf)
		{
			PBMBDGFOMPN(IFFDIHCPKFE.upgradeSlots.actualTier, IFFDIHCPKFE.upgradeSlots.actualUpgradeProgress);
		}
		SetSale();
	}

	public void PKNHLFBHNAH(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		UpdateName();
		BPDOPOOOOCG(IFFDIHCPKFE.upgradeSlots.iconName);
		OPFDLJKGPON.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		AAMOJLNJNGN.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		IAPCGDFOJNP.text = string.Format("S", Localization.Localize("com/google/android/gms/common/ConnectionResult"), IFFDIHCPKFE.upgradeSlots.unlockLevel.MHAOKJCDIOL());
		ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
		ODINPJHOLKD.MakePixelPerfect();
		ODINPJHOLKD.transform.localScale = ODINPJHOLKD.transform.localScale.MultiplyXY(1070f);
		if (IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			IOIKKIIFOCB.SetUpEliteIcon(HBMLFIJGBJO, EAOIENMNEKK, 1082f);
		}
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 292f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = KGIEBHBOHFO.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1464f, 1500f, 1338f);
			object oEIICEJPGKI = new Vector3(942f, 1210f, 746f);
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 293f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
			FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Rotation, KGIEBHBOHFO.gameObject, num, new Vector3(98f, 81f, 907f), 1323f, 1, null, (UITweener.Method)6);
			FNOMCHPCOHB.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Position, KGIEBHBOHFO.gameObject, num, new Vector3(1775f, 305f, 595f), 1776f, 4, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
			FNOMCHPCOHB.KHAFPAMIOAF();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1918f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = FKBOBOBIGIA.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1100f, 1682f, 1636f);
			object iIMDKHJAJGO = new Vector3(1983f, 569f, 387f);
			cFAIPFBHMPB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 19f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.AddTween(4, TweenAnimator.MNAIKKJDPLK.Rotation, FKBOBOBIGIA.gameObject, num2, new Vector3(224f, 512f, 1571f), 294f, 0, null, UITweener.Method.Linear);
			CFAIPFBHMPB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, FKBOBOBIGIA.gameObject, num2, new Vector3(1331f, 315f, 237f), 1260f, 7, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(PEBCMFLPPNG));
			CFAIPFBHMPB.FEPILCEBNCJ();
		}
		FGDLKJOINNE(false);
		InitGuiValuesGraphics();
	}

	public void InitGuiValuesGraphics()
	{
		PCAJBGDOIJI = IFFDIHCPKFE.upgradeSlots.unitState;
		AJEKMIDMPHJ = IFFDIHCPKFE.upgradeSlots.actualTier;
		CLNFHCHFEAD();
	}
}
