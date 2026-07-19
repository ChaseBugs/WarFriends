using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponLeftContent : Core_BaseScript
{
	[Header("Header")]
	public UITable LHKLOFBMPGN;

	[Header("-Line 1")]
	public UITable HGPPNIOLAEK;

	public UILabel OJLKFHEIMJJ;

	public UILabel NLFMNGMACHH;

	[Header("-Line 2")]
	public UITable IEIKMKFHDOJ;

	public UISprite NOFOFAAFPOJ;

	public UILabel PPFCOELFDEI;

	[Header("-Line 3")]
	public UITable LMHBCNBKOCG;

	public UILabel PPEHOGPDIGI;

	[Header("Statistics")]
	public List<WeaponStatProgressBar> CAOEDDHFEFA;

	[Header("Button")]
	public GameObject IJFDHHLOHII;

	public UIButton EDHCOMHOKDC;

	public BoxCollider AIPKDCLGOAN;

	[Header("-Empty")]
	public GameObject KKIBELEPAOK;

	[Header("-Upgrade")]
	public GameObject JEFAKEIGOEN;

	public UITable CHCFBDMGNLP;

	public UILabel HJKCBBANLDM;

	public UITable MAAMDIKGBBD;

	public UILabel EEHIBOFCIBP;

	[Header("--Sale Part")]
	public GameObject GIPFEBBMKPM;

	public UILabel EKIDAFLLCNM;

	public WinStreakCounter JBGPDECEOOB;

	[Header("-Deliver Now")]
	public GameObject NBGKOCKGCCK;

	public UILabel LPPOJMGOEFN;

	public UILabel PPDGFFJLHKK;

	public UISprite IAIHLFMNAOA;

	public UITable CKPLDDIPNAA;

	public UILabel NBFHHHGJDJA;

	[SerializeField]
	[Header("--Subsccription")]
	private GameObject mSubscriptionPart;

	[SerializeField]
	private UILabel mSubscriptionHint;

	[Header("-Activate")]
	public GameObject NJMAGIBDNLM;

	[Header("-Max")]
	public GameObject LLOLKNBCPKP;

	[Header("-Rental")]
	public GameObject GCMFKPMOCFL;

	[Header("-Minigun Upgrade")]
	public GameObject BKCGCJPOPEE;

	[Header("Animation")]
	public ArmyPowerAnimation GHGJLMAJJGG;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private WeaponLevelsSetup EDCBHGKBLEA;

	private int CLDFFNMPKOP;

	private float JCAFFELIFAO = 0.3f;

	private float HPNPMCEMJNM
	{
		get
		{
			return -620f - UIHelper.safeAreaSize;
		}
	}

	private void JHCACKNHBJC(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1923f, 1595f, 1793f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void PLEAKCFCPOF(int LFNBJLJPEGP)
	{
		if (MDAJJIAMDGH.DHHKOKKDDDO() == EDCBHGKBLEA.DHHKOKKDDDO())
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 1743f);
		}
	}

	private void JONIDFOHFAH(WeaponLevelsSetup.JLANLLEABDC NNIHEDAMNGF)
	{
		BoxCollider component = EDHCOMHOKDC.GetComponent<BoxCollider>();
		component.size = new Vector3(956f, (NNIHEDAMNGF != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? 1329f : 1363f, 1873f);
		component.center = new Vector3(1966f, (NNIHEDAMNGF != WeaponLevelsSetup.JLANLLEABDC.NotBuyed) ? 573f : 1140f, 726f);
	}

	[SpecialName]
	private float PGMJMHOPHFF()
	{
		return 668f - UIHelper.safeAreaSize;
	}

	private void DJAEEHLMLJB(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1148f, 25f, 152f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void OEEAEGMJIMH(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 1707f, 1266f, 596f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void LEPHDKMPCPP()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	private void DMPOOCHHBNK()
	{
		int num = MDAJJIAMDGH.MGAGEKAAJOL.OBMKGNPMLHB();
		if (!Singleton<Wallet>.instance.CanBuyGold(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("ID_CANCEL");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.ALBICJOEMEF(num);
		GuiScreenSingle<WeaponScreen>.instance.APGDCFFDPOF(MDAJJIAMDGH, false);
		JLIPONCMMFE(armyPowerX);
		PBNOLBDMKLJ();
	}

	private void CBEJONLKHCJ()
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<WeaponScreen>.instance.MBKJEPDJFKJ(MDAJJIAMDGH, true);
		JLIPONCMMFE(armyPowerX);
		CPIEGCEDKNK();
	}

	private void GMGJFOKCHCK()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		int weaponLevel = MDAJJIAMDGH.weaponLevel;
		int maxWeaponLevel = MDAJJIAMDGH.maxWeaponLevel;
		PPEHOGPDIGI.text = string.Format("ID_GOLD", weaponLevel, Colours.stringGray, maxWeaponLevel);
		PLMJOIGBLBO();
		NJMAGIBDNLM.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		NBGKOCKGCCK.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		NBFHHHGJDJA.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LPPOJMGOEFN.alpha = 552f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		PPDGFFJLHKK.alpha = 759f;
		JEFAKEIGOEN.SetActive(weaponLevel >= maxWeaponLevel || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		SetSaleAndPrize();
		EEHIBOFCIBP.text = (weaponLevel + 0).ToString();
		MAAMDIKGBBD.repositionNow = false;
		bool flag = weaponLevel != maxWeaponLevel || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered;
		LLOLKNBCPKP.SetActive(flag);
		bool flag2 = weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked && weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked && weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && weaponState == (WeaponLevelsSetup.JLANLLEABDC)8;
		KKIBELEPAOK.SetActive(flag2);
		GCMFKPMOCFL.SetActive(false);
		bool tryOutWeapon = MDAJJIAMDGH.tryOutWeapon;
		if (tryOutWeapon)
		{
			NJMAGIBDNLM.SetActive(true);
			NBGKOCKGCCK.SetActive(true);
			JEFAKEIGOEN.SetActive(false);
			LLOLKNBCPKP.SetActive(true);
			KKIBELEPAOK.SetActive(false);
			GCMFKPMOCFL.SetActive(false);
			BKCGCJPOPEE.SetActive(false);
		}
		BKCGCJPOPEE.SetActive(false);
		DIGHOBILJAJ();
		bool flag3 = !flag && !flag2 && tryOutWeapon;
		AIPKDCLGOAN.enabled = !flag3;
		DHDAODPNMCF(weaponState);
	}

	public void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDKCDOCOMIM));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HGPPNIOLAEK.onReposition = LEPHDKMPCPP;
		IEIKMKFHDOJ.onReposition = LEPHDKMPCPP;
		LMHBCNBKOCG.onReposition = LEPHDKMPCPP;
		CKPLDDIPNAA.onReposition = delegate
		{
			float val = 0f - CKPLDDIPNAA.padding.x - (NBFHHHGJDJA.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
			CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
		};
	}

	private void AJOFNLKMKAH(int LFNBJLJPEGP)
	{
		if (MDAJJIAMDGH.DHHKOKKDDDO() == EDCBHGKBLEA.DHHKOKKDDDO())
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 1036f);
		}
	}

	private void LHLDMBBJHFF()
	{
		int num = MDAJJIAMDGH.MGAGEKAAJOL.OBMKGNPMLHB();
		if (!Singleton<Wallet>.instance.CanBuyGold(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, MDAJJIAMDGH.weaponName);
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("NO");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.ALBICJOEMEF(num);
		GuiScreenSingle<WeaponScreen>.instance.APGDCFFDPOF(MDAJJIAMDGH, true);
		PLEAKCFCPOF(armyPowerX);
		PBNOLBDMKLJ();
	}

	[CompilerGenerated]
	private void KGPEAMIDEOA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void NPOPGCMEIOL(UITweener MGDJMGHCAAI)
	{
		FPPPLPHDBMO();
		TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(1749f), false);
	}

	private void KJEOBCMLJBP(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1922f, 368f, 1714f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	public void UpdateContentAfterEquip()
	{
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(MDAJJIAMDGH.BHCEOOLEHHG);
		EDCBHGKBLEA = slotForCategory.weaponLevelsSetup;
		FAGNIAIBJBJ();
	}

	private void IDCDCGNJMGC(UITweener MGDJMGHCAAI)
	{
		GMGJFOKCHCK();
		TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(1196f));
	}

	public void NIFNIFGLAHA()
	{
		if (!MDAJJIAMDGH.bought)
		{
			return;
		}
		int num = Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)6);
		int num2 = MDAJJIAMDGH.MGAGEKAAJOL.HDJOMPBICBK();
		bool flag = num > 0;
		if (flag)
		{
			num2 = num2 * (-76 - num) / -68;
		}
		HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		CHCFBDMGNLP.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_READYTIME", num);
			JBGPDECEOOB.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(MDAJJIAMDGH, (AKDLEDNDIEO)4));
			JBGPDECEOOB.JEMKCLKCOMI = delegate
			{
				SetSaleAndPrize();
			};
		}
		else
		{
			JBGPDECEOOB.FCGPLOBEHDL();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
	}

	private void FPPPLPHDBMO()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		int weaponLevel = MDAJJIAMDGH.weaponLevel;
		int maxWeaponLevel = MDAJJIAMDGH.maxWeaponLevel;
		PPEHOGPDIGI.text = string.Format("{0}{1} / {2}", weaponLevel, Colours.stringGray, maxWeaponLevel);
		FAGNIAIBJBJ();
		NJMAGIBDNLM.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered);
		NBGKOCKGCCK.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
		NBFHHHGJDJA.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LPPOJMGOEFN.alpha = 1f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 0f;
		JEFAKEIGOEN.SetActive(weaponLevel < maxWeaponLevel && weaponState == WeaponLevelsSetup.JLANLLEABDC.Active);
		SetSaleAndPrize();
		EEHIBOFCIBP.text = (weaponLevel + 1).ToString();
		MAAMDIKGBBD.repositionNow = true;
		bool flag = weaponLevel == maxWeaponLevel && weaponState == WeaponLevelsSetup.JLANLLEABDC.Active;
		LLOLKNBCPKP.SetActive(flag);
		bool flag2 = weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered;
		KKIBELEPAOK.SetActive(flag2);
		GCMFKPMOCFL.SetActive(false);
		bool tryOutWeapon = MDAJJIAMDGH.tryOutWeapon;
		if (tryOutWeapon)
		{
			NJMAGIBDNLM.SetActive(false);
			NBGKOCKGCCK.SetActive(false);
			JEFAKEIGOEN.SetActive(false);
			LLOLKNBCPKP.SetActive(false);
			KKIBELEPAOK.SetActive(false);
			GCMFKPMOCFL.SetActive(true);
			BKCGCJPOPEE.SetActive(false);
		}
		BKCGCJPOPEE.SetActive(false);
		LFEHKNDLOEN();
		bool flag3 = flag || flag2 || tryOutWeapon;
		AIPKDCLGOAN.enabled = !flag3;
		LFDHHGDINHB(weaponState);
	}

	private void LFDHHGDINHB(WeaponLevelsSetup.JLANLLEABDC NNIHEDAMNGF)
	{
		BoxCollider component = EDHCOMHOKDC.GetComponent<BoxCollider>();
		component.size = new Vector3(580f, (NNIHEDAMNGF != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? 180f : 150f, 1f);
		component.center = new Vector3(0f, (NNIHEDAMNGF != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? 0f : (-15f), 0f);
	}

	private void DBINHFIAEHF()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		int weaponLevel = MDAJJIAMDGH.weaponLevel;
		int maxWeaponLevel = MDAJJIAMDGH.maxWeaponLevel;
		PPEHOGPDIGI.text = string.Format("ID_RENTAL_GRENADELAUNCHER", weaponLevel, Colours.stringGray, maxWeaponLevel);
		FAGNIAIBJBJ();
		NJMAGIBDNLM.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		NBGKOCKGCCK.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
		NBFHHHGJDJA.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LPPOJMGOEFN.alpha = 839f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 1937f;
		JEFAKEIGOEN.SetActive(weaponLevel < maxWeaponLevel && weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
		BEOKODLBKEO();
		EEHIBOFCIBP.text = (weaponLevel + 1).ToString();
		MAAMDIKGBBD.repositionNow = true;
		bool flag = weaponLevel == maxWeaponLevel && weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
		LLOLKNBCPKP.SetActive(flag);
		bool flag2 = weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked && weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed && weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering && weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
		KKIBELEPAOK.SetActive(flag2);
		GCMFKPMOCFL.SetActive(true);
		bool tryOutWeapon = MDAJJIAMDGH.tryOutWeapon;
		if (tryOutWeapon)
		{
			NJMAGIBDNLM.SetActive(true);
			NBGKOCKGCCK.SetActive(true);
			JEFAKEIGOEN.SetActive(false);
			LLOLKNBCPKP.SetActive(true);
			KKIBELEPAOK.SetActive(true);
			GCMFKPMOCFL.SetActive(false);
			BKCGCJPOPEE.SetActive(false);
		}
		BKCGCJPOPEE.SetActive(true);
		GHFGKBLAPPJ();
		bool flag3 = !flag && !flag2 && tryOutWeapon;
		AIPKDCLGOAN.enabled = flag3;
		DHDAODPNMCF(weaponState);
	}

	public void DoAfterHide()
	{
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	public void SetSaleAndPrize()
	{
		if (!MDAJJIAMDGH.bought)
		{
			return;
		}
		int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Upgrade);
		int num2 = MDAJJIAMDGH.MGAGEKAAJOL.upgradePrice;
		bool flag = num > 0;
		if (flag)
		{
			num2 = num2 * (100 - num) / 100;
		}
		HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		CHCFBDMGNLP.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(MDAJJIAMDGH, AKDLEDNDIEO.Upgrade));
			JBGPDECEOOB.JEMKCLKCOMI = delegate
			{
				SetSaleAndPrize();
			};
		}
		else
		{
			JBGPDECEOOB.JCMHGOGNMFO();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
	}

	public void SelectWeapon(WeaponLevelsSetup KCMMAALIOIB)
	{
		MDAJJIAMDGH = KCMMAALIOIB;
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(KCMMAALIOIB.BHCEOOLEHHG);
		EDCBHGKBLEA = slotForCategory.weaponLevelsSetup;
		NLFMNGMACHH.text = ((slotForCategory == null) ? Singleton<GameVariables>.instance.GetWeaponCategory(KCMMAALIOIB.BHCEOOLEHHG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular) : slotForCategory.name);
		HGPPNIOLAEK.repositionNow = true;
		NOFOFAAFPOJ.gameObject.SetActive(KCMMAALIOIB.purchasableInBlackmarket);
		PPFCOELFDEI.text = MDAJJIAMDGH.weaponName.ToUpper();
		IEIKMKFHDOJ.repositionNow = true;
		LMHBCNBKOCG.repositionNow = true;
		OJLKFHEIMJJ.color = ((!KCMMAALIOIB.purchasableInBlackmarket) ? Colours.blue : Colours.azureBlackmarket).ReplaceA(0.5f);
		NLFMNGMACHH.color = ((!KCMMAALIOIB.purchasableInBlackmarket) ? Colours.blue : Colours.azureBlackmarket).ReplaceA(0.5f);
		PPFCOELFDEI.color = ((!KCMMAALIOIB.purchasableInBlackmarket) ? Colours.blue : Colours.azureBlackmarket);
	}

	private void FAGNIAIBJBJ()
	{
		CAOEDDHFEFA[0].InitializeStat(MDAJJIAMDGH, EDCBHGKBLEA, 0);
		CAOEDDHFEFA[1].InitializeStat(MDAJJIAMDGH, EDCBHGKBLEA, 1);
		CAOEDDHFEFA[2].InitializeStat(MDAJJIAMDGH, EDCBHGKBLEA, 2);
	}

	private void MDMDKBDCKOJ()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 40f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	public void MLAEGNJBKIM()
	{
		JBGPDECEOOB.BGHNMCPLIPE();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	private void PBNOLBDMKLJ()
	{
		CAOEDDHFEFA[0].OFLHCIBMNMB();
		CAOEDDHFEFA[1].HEFPMCLAOIE();
		CAOEDDHFEFA[3].NNKBLCDKCKB();
		GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.OEOMIOIDACJ();
		GuiScreenSingle<WeaponScreen>.instance.AnimateUpgrade();
	}

	public void NBOPNJMNPKL(WeaponLevelsSetup KCMMAALIOIB)
	{
		MDAJJIAMDGH = KCMMAALIOIB;
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(KCMMAALIOIB.BHCEOOLEHHG);
		EDCBHGKBLEA = slotForCategory.BHDJIJGIHCL();
		NLFMNGMACHH.text = ((slotForCategory == null) ? Singleton<GameVariables>.instance.EIIPJBGJEMM(KCMMAALIOIB.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural) : slotForCategory.PHCDBKOGMDA());
		HGPPNIOLAEK.repositionNow = true;
		NOFOFAAFPOJ.gameObject.SetActive(KCMMAALIOIB.purchasableInBlackmarket);
		PPFCOELFDEI.text = MDAJJIAMDGH.weaponName.ToUpper();
		IEIKMKFHDOJ.repositionNow = true;
		LMHBCNBKOCG.repositionNow = true;
		OJLKFHEIMJJ.color = ((!KCMMAALIOIB.purchasableInBlackmarket) ? Colours.blue : Colours.azureBlackmarket).ReplaceA(71f);
		NLFMNGMACHH.color = ((!KCMMAALIOIB.purchasableInBlackmarket) ? Colours.blue : Colours.azureBlackmarket).ReplaceA(1361f);
		PPFCOELFDEI.color = ((!KCMMAALIOIB.purchasableInBlackmarket) ? Colours.blue : Colours.azureBlackmarket);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	public void BEOKODLBKEO()
	{
		if (!MDAJJIAMDGH.bought)
		{
			return;
		}
		int num = Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)7);
		int num2 = MDAJJIAMDGH.MGAGEKAAJOL.LOLLBGNIOMM();
		bool flag = num > 1;
		if (flag)
		{
			num2 = num2 * (-88 - num) / 124;
		}
		HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		CHCFBDMGNLP.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("GoldReward{0}Max", num);
			JBGPDECEOOB.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(MDAJJIAMDGH, AKDLEDNDIEO.Buy));
			JBGPDECEOOB.JEMKCLKCOMI = delegate
			{
				SetSaleAndPrize();
			};
		}
		else
		{
			JBGPDECEOOB.PEHBGMEHFEM();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
	}

	private void PLMJOIGBLBO()
	{
		CAOEDDHFEFA[0].FGPILHIMEAM(MDAJJIAMDGH, EDCBHGKBLEA, 1);
		CAOEDDHFEFA[1].HKFIIJJKIEL(MDAJJIAMDGH, EDCBHGKBLEA, 1);
		CAOEDDHFEFA[7].MIJNLELOJEC(MDAJJIAMDGH, EDCBHGKBLEA, 6);
	}

	[CompilerGenerated]
	private void DBHMOGJPFAA()
	{
		SetSaleAndPrize();
	}

	public void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDKCDOCOMIM));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HGPPNIOLAEK.onReposition = MLKAMKAKGML;
		IEIKMKFHDOJ.onReposition = LEPHDKMPCPP;
		LMHBCNBKOCG.onReposition = MLKAMKAKGML;
		CKPLDDIPNAA.onReposition = NCGKHELLHDD;
	}

	private void CPIEGCEDKNK()
	{
		CAOEDDHFEFA[0].AnimateStat();
		CAOEDDHFEFA[1].AnimateStat();
		CAOEDDHFEFA[2].AnimateStat();
		GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.AnimateWeaponPower();
		GuiScreenSingle<WeaponScreen>.instance.AnimateUpgrade();
	}

	private void GPEPFFEEFMK()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionHint.text = SubscriptionManager.instance.minusUpgradesPercent;
		}
	}

	public void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDKCDOCOMIM));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HGPPNIOLAEK.onReposition = MLKAMKAKGML;
		IEIKMKFHDOJ.onReposition = LEPHDKMPCPP;
		LMHBCNBKOCG.onReposition = LEPHDKMPCPP;
		CKPLDDIPNAA.onReposition = delegate
		{
			float val = 0f - CKPLDDIPNAA.padding.x - (NBFHHHGJDJA.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
			CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
		};
	}

	private void MLKAMKAKGML()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (NBFHHHGJDJA.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	private void NELPGPHOFHC(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 203f, 1813f, 417f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void DOKLBGAJNAH()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Upgrade);
		int num2 = MDAJJIAMDGH.MGAGEKAAJOL.upgradePrice * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log(string.Format("Have discount {0} to upgrade {1}", num, MDAJJIAMDGH.DHHKOKKDDDO()));
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				GuiScreenSingle<WeaponScreen>.instance.GFDDLFMLJMJ(weaponLevelsSetup, WeaponScreen.ABDDBOABKOK.WeaponScreen);
			}
			else
			{
				if (weaponLevelsSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogWeapons(weaponLevelsSetup, MDAJJIAMDGH);
					return;
				}
				GuiScreenSingle<WeaponScreen>.instance.MBKJEPDJFKJ(weaponLevelsSetup, false);
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<WeaponScreen>.instance.IEFLIEHLBNA(MDAJJIAMDGH, num);
	}

	private void FDKCDOCOMIM(GameObject KHAHPAKDIKE)
	{
		if (MDAJJIAMDGH.tryOutWeapon)
		{
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon is rented - do nothing");
			return;
		}
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Active:
		{
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT ACTIVE\t\tbutton type: UPGRADE/MAX");
			int weaponLevel = MDAJJIAMDGH.weaponLevel;
			int maxWeaponLevel = MDAJJIAMDGH.maxWeaponLevel;
			if (weaponLevel < maxWeaponLevel)
			{
				DOKLBGAJNAH();
			}
			break;
		}
		case WeaponLevelsSetup.JLANLLEABDC.Delivering:
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERING\t\tbutton type: DELIVER NOW");
			BPLBHMICKFB();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.Delivered:
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERED\t\tbutton type: ACTIVATE");
			CBEJONLKHCJ();
			break;
		default:
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: OTHER\t\tbutton type: EMPTY");
			break;
		}
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

	[CompilerGenerated]
	private void FCJMBMEBDAI(UITweener MGDJMGHCAAI)
	{
		FPPPLPHDBMO();
		TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(60f));
	}

	public void UpdateDeliveringTime(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 0f)) ? 0f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.instantWeaponDeliveryPrice);
		if (NBFHHHGJDJA.text != text)
		{
			NBFHHHGJDJA.text = text;
			CKPLDDIPNAA.repositionNow = true;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 6f);
		if (num2 == 2 && (LPPOJMGOEFN.alpha == 0f || PPDGFFJLHKK.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (PPDGFFJLHKK.alpha == 0f || LPPOJMGOEFN.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDKCDOCOMIM));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HGPPNIOLAEK.onReposition = MLKAMKAKGML;
		IEIKMKFHDOJ.onReposition = MLKAMKAKGML;
		LMHBCNBKOCG.onReposition = MLKAMKAKGML;
		CKPLDDIPNAA.onReposition = delegate
		{
			float val = 0f - CKPLDDIPNAA.padding.x - (NBFHHHGJDJA.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
			CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
		};
	}

	private void JLIPONCMMFE(int LFNBJLJPEGP)
	{
		if (MDAJJIAMDGH.DHHKOKKDDDO() == EDCBHGKBLEA.DHHKOKKDDDO())
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX, 0.05f);
		}
	}

	private void OKHCAFKONFG()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionHint.text = SubscriptionManager.instance.minusUpgradesPercent;
		}
	}

	private void GHFGKBLAPPJ()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionHint.text = SubscriptionManager.instance.minusUpgradesPercent;
		}
	}

	public void PJBGBJAIJDJ(bool LGIIPHPACIC = true)
	{
		if (LGIIPHPACIC)
		{
			TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(652f), false);
			GMGJFOKCHCK();
		}
		else if (MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
		{
			TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(PGMJMHOPHFF())).onFinished = delegate
			{
				FPPPLPHDBMO();
				TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(60f));
			};
		}
		else
		{
			PPEHOGPDIGI.text = string.Format("ID_CONFIRM_PROMOTEDEMOTEERROR", MDAJJIAMDGH.weaponLevel, Colours.stringGray, MDAJJIAMDGH.maxWeaponLevel);
		}
	}

	private void NCGKHELLHDD()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (NBFHHHGJDJA.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 1853f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	public void UpdateLeftContent(bool LGIIPHPACIC = true)
	{
		if (LGIIPHPACIC)
		{
			TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(60f));
			FPPPLPHDBMO();
		}
		else if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
		{
			TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(HPNPMCEMJNM)).onFinished = delegate
			{
				FPPPLPHDBMO();
				TweenPosition.Begin(IJFDHHLOHII, JCAFFELIFAO, IJFDHHLOHII.transform.localPosition.ReplaceX(60f));
			};
		}
		else
		{
			PPEHOGPDIGI.text = string.Format("{0}{1} / {2}", MDAJJIAMDGH.weaponLevel, Colours.stringGray, MDAJJIAMDGH.maxWeaponLevel);
		}
	}

	private void DHDAODPNMCF(WeaponLevelsSetup.JLANLLEABDC NNIHEDAMNGF)
	{
		BoxCollider component = EDHCOMHOKDC.GetComponent<BoxCollider>();
		component.size = new Vector3(611f, (NNIHEDAMNGF != (WeaponLevelsSetup.JLANLLEABDC)8) ? 294f : 199f, 902f);
		component.center = new Vector3(136f, (NNIHEDAMNGF != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering) ? 1892f : 799f, 593f);
	}

	[CompilerGenerated]
	private void HFBDDEHDGCG(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void ELPKDAHCHGL()
	{
		int num = MDAJJIAMDGH.MGAGEKAAJOL.OBMKGNPMLHB();
		if (!Singleton<Wallet>.instance.CanBuyGold(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.TRAINELITE);
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("{0} {1}");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(num);
		GuiScreenSingle<WeaponScreen>.instance.NHAPEPLDGBB(MDAJJIAMDGH, true);
		AJOFNLKMKAH(armyPowerX);
		PBNOLBDMKLJ();
	}

	private void JMBOMJCBBJO()
	{
		CAOEDDHFEFA[1].InitializeStat(MDAJJIAMDGH, EDCBHGKBLEA, 0);
		CAOEDDHFEFA[1].MIJNLELOJEC(MDAJJIAMDGH, EDCBHGKBLEA, 1);
		CAOEDDHFEFA[2].OJPLLBPIHJK(MDAJJIAMDGH, EDCBHGKBLEA, 6);
	}

	private void BPLBHMICKFB()
	{
		int instantBuyPrice = MDAJJIAMDGH.MGAGEKAAJOL.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Weapon_Upgrade";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.MBAFMBJFOKH(instantBuyPrice);
		GuiScreenSingle<WeaponScreen>.instance.APGDCFFDPOF(MDAJJIAMDGH, true);
		JLIPONCMMFE(armyPowerX);
		CPIEGCEDKNK();
	}

	private void DIGHOBILJAJ()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionHint.text = SubscriptionManager.instance.minusUpgradesPercent;
		}
	}

	private void JKECNCAFBEI()
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<WeaponScreen>.instance.MBKJEPDJFKJ(MDAJJIAMDGH, true);
		JLIPONCMMFE(armyPowerX);
		PBNOLBDMKLJ();
	}

	private void IFLPLOHPCMI()
	{
		int num = MDAJJIAMDGH.MGAGEKAAJOL.HDPFDJKKIFI();
		if (!Singleton<Wallet>.instance.CanBuyGold(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("OpponentRank");
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.ALBICJOEMEF(num);
		GuiScreenSingle<WeaponScreen>.instance.APGDCFFDPOF(MDAJJIAMDGH, false);
		PLEAKCFCPOF(armyPowerX);
		PBNOLBDMKLJ();
	}
}
