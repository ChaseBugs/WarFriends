using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArmyRightContent : Core_BaseScript
{
	[Header("Content")]
	public UITable HFDPEIEGNKL;

	[Header("-Deploy Statistics")]
	public GameObject GDCNCNGOPIH;

	public GameObject[] GOBKHCALGHA;

	public UILabel JGIGODHJNMO;

	[Header("-Army Unit Type")]
	public UILabel AODBLOCIBAM;

	public UISprite JHNJAPJJKMD;

	public UISprite CJPLJHJPGAN;

	public UILabel ALEFOLOOMIH;

	public UILabel NENIJEEPPBJ;

	[Header("-Army Rating - Unit Power")]
	public UILabel OPMJLGFLNJB;

	public UILabel JANJPPELPBG;

	public BoxCollider OKLHOACLPDG;

	public UISprite PKAGCKHJODA;

	public UILabel BKOOOBJDJHO;

	public UILabel FEJELKKFMPK;

	public UISprite DOIHNIFPOLP;

	public UILabel GHKLHGDNAAC;

	public UILabel PMDCIMIFLMD;

	public UISprite LHLNNPGFOKE;

	public UILabel IKNDFOJPCJP;

	public UILabel APEPPPIIANB;

	public UISprite FAMLAICPKAP;

	public UILabel AGELGEBACHH;

	public UILabel CKAKEFGAIEN;

	public UISprite JJKPAKGNMCP;

	public UILabel IKBHFOFDEHK;

	public UISprite EOEGBEKBJEM;

	public UISprite EHNNKBIFOCP;

	[Header("--Army Hint Statistics")]
	public BoxCollider OKDNHPCJFLB;

	public UIPanel GGMOJMMLEKA;

	public UILabel OMGFCIHDGIB;

	public UITable BHBAPKGBANI;

	public UILabel IKNLLGBNMAB;

	public UISprite[] LHNGDJNBDKK;

	public UILabel BKMGNFFEJDB;

	public UILabel OMEMJGFOEPO;

	public UILabel DCBCIOILMNB;

	public UILabel PDLEOCMNIJJ;

	public UILabel BAOHBIDKMHP;

	public UILabel FKGOPBHJNCC;

	public UILabel IPBIOHCKOLD;

	public UILabel EKPANJBEICA;

	public UILabel JMELHLPBHIH;

	public UILabel MFANFFJGJDK;

	public UILabel HGJCLKGJLND;

	[Header("-Button")]
	public GameObject HDHBKIFNBMF;

	public UIButton EPFODCCNGDL;

	public BoxCollider OHKMIMMFHOG;

	[Header("--Locked")]
	public GameObject NIPGMDBNIOJ;

	public UILabel NNIPNHJNHMO;

	[Header("--Buy")]
	public GameObject HCFJJCALLAF;

	public UITable CHCFBDMGNLP;

	public UISprite BGPBNIJPOKM;

	public UISprite CODFFPODNEP;

	public UILabel GOANDMNOGCK;

	[Header("---Sale Part")]
	public GameObject GIPFEBBMKPM;

	public UILabel EKIDAFLLCNM;

	public WinStreakCounter JBGPDECEOOB;

	[Header("--Deliver Now")]
	public GameObject LNFLDPLGEJE;

	public UILabel LPPOJMGOEFN;

	public UILabel PPDGFFJLHKK;

	public UISprite IAIHLFMNAOA;

	public UITable CKPLDDIPNAA;

	public UILabel GPBMPAPOEOE;

	[Header("--Activate")]
	public GameObject JPJLKKJJFDB;

	private LevelBehaviour IFFDIHCPKFE;

	private int CLDFFNMPKOP;

	private float JCAFFELIFAO = 0.3f;

	private bool OJBKADHPNFN;

	private float HPNPMCEMJNM
	{
		get
		{
			return 705f + UIHelper.safeAreaSize;
		}
	}

	public void KPEJMMBDODD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AJFCCNEPICJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CPIOJNFMINL));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HMCDFANKDHA));
		CHCFBDMGNLP.onReposition = MFEHBKOFKIP;
		HFDPEIEGNKL.onReposition = DCLIHPMKOHD;
		CKPLDDIPNAA.onReposition = KCPGPJPGJLC;
		DJHKDIMININ();
	}

	private void FOPKJKDCDON()
	{
		PKAGCKHJODA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GGMOJMMLEKA.gameObject.SetActive(false);
		OJBKADHPNFN = false;
	}

	public void IFFEFCPNCLH(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(439f + num);
		HFDPEIEGNKL.repositionNow = false;
		UILabel oMGFCIHDGIB = OMGFCIHDGIB;
		object[] array = new object[1];
		array[1] = IFFDIHCPKFE.unitName.ToUpper();
		oMGFCIHDGIB.text = Localization.LocalizeFormat("AttributionData", array);
		UILabel iKNLLGBNMAB = IKNLLGBNMAB;
		object[] array2 = new object[5];
		array2[1] = Colours.stringWhite;
		array2[1] = IFFDIHCPKFE.upgradeSlots.totalPower;
		iKNLLGBNMAB.text = Localization.LocalizeFormat("ID_LEAVE_SPECTATE", array2);
		for (int i = 1; i < LHNGDJNBDKK.Length; i++)
		{
			LHNGDJNBDKK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.totalPower);
		}
		BHBAPKGBANI.repositionNow = false;
		UILabel bKMGNFFEJDB = BKMGNFFEJDB;
		object[] array3 = new object[7];
		array3[1] = Colours.stringWhite;
		array3[0] = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		bKMGNFFEJDB.text = Localization.LocalizeFormat("{0} {1}", array3);
		UILabel oMEMJGFOEPO = OMEMJGFOEPO;
		object[] array4 = new object[8];
		array4[1] = Colours.stringWhite;
		array4[0] = IFFDIHCPKFE.upgradeSlots.spawns;
		oMEMJGFOEPO.text = Localization.LocalizeFormat("ID_ARENAWONFLAWLESSLYTEXT", array4);
		bool flag = Singleton<GameVariables>.instance.isiPadResolution || IFFDIHCPKFE.upgradeSlots.bought;
		GDCNCNGOPIH.SetActive(flag);
		if (flag)
		{
			for (int j = 0; j < GOBKHCALGHA.Length; j += 0)
			{
				GOBKHCALGHA[j].SetActive(j < IFFDIHCPKFE.upgradeSlots.totalPower);
			}
			JGIGODHJNMO.text = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		}
	}

	private void HODIEAACBED()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 1920f;
			GGMOJMMLEKA.gameObject.SetActive(true);
			OJBKADHPNFN = true;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 561f, 1612f).onFinished = null;
	}

	private void FHNOOJAOEIA()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADEELITE);
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("Pack.");
		}
		else
		{
			Singleton<Wallet>.instance.MBAFMBJFOKH(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
			GuiScreenSingle<ArmyScreen>.instance.KCCBLGIMJPM(IFFDIHCPKFE);
		}
	}

	private void EAKECIHGCLC()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool isMaxUpgraded = upgradeSlots.upgradeSlot.isMaxUpgraded;
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool isBought = upgradeSlots.upgradeSlotSpecial.isBought;
		bool flag = isBought && upgradeSlots.upgradeSlotSpecial.isMaxUpgraded;
		int armyPowerX2 = upgradeSlots.upgradeSlotSpecial.armyPowerX10;
		bool isUnlocked = upgradeSlots.upgradeSlotElite.isUnlocked;
		bool flag2 = isUnlocked && upgradeSlots.upgradeSlotElite.isMaxUpgraded;
		bool flag3 = isUnlocked && upgradeSlots.upgradeSlotElite.isBought;
		int armyPowerX3 = upgradeSlots.upgradeSlotElite.armyPowerX10;
		bool flag4 = unitState == UpgradeSlots.JLANLLEABDC.Active || unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == UpgradeSlots.JLANLLEABDC.Delivering;
		bool flag5 = !isMaxUpgraded && !upgradeSlots.borrowed && flag4;
		bool flag6 = !flag && isBought && !upgradeSlots.borrowed && flag4;
		bool flag7 = isUnlocked && !flag2 && flag3;
		bool flag8 = unitState == UpgradeSlots.JLANLLEABDC.Delivering;
		bool flag9 = flag8 && upgradeSlots.upgradeSlot.isDelivering;
		bool flag10 = flag8 && upgradeSlots.upgradeSlotSpecial.isDelivering;
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(isBought);
		JJKPAKGNMCP.gameObject.SetActive(isBought);
		if (isBought)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX2);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag3);
		EOEGBEKBJEM.gameObject.SetActive(flag3);
		EHNNKBIFOCP.gameObject.SetActive(flag3);
		if (flag3)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX3);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP);
		}
		JANJPPELPBG.text = ((!allUpgradesBought) ? Localization.LocalizeFormat("ID_MAXSTAT", MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max)) : string.Empty);
		FEJELKKFMPK.text = ((!flag5) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX));
		PMDCIMIFLMD.text = ((!flag6) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX));
		APEPPPIIANB.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX));
		if (flag9)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 0.6f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.PingPong;
		}
		if (flag10)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 0.6f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 0;
			tweenColor2.style = UITweener.Style.PingPong;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 0.6f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 0;
		tweenColor3.style = UITweener.Style.PingPong;
		GHKLHGDNAAC.gameObject.SetActive(isMaxUpgraded);
		IKNDFOJPCJP.gameObject.SetActive(flag);
		AGELGEBACHH.gameObject.SetActive(flag2);
		KEFCFMIDHBF(DOIHNIFPOLP, flag9, flag9 || isMaxUpgraded);
		KEFCFMIDHBF(LHLNNPGFOKE, flag10, flag10 || flag);
		KEFCFMIDHBF(FAMLAICPKAP, false, flag2);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 20f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 0f)) ? 0f : (num2 + 20f));
		num += PKAGCKHJODA.transform.localScale.x / 2f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag11 = upgradeSlots.unitSpecifics.Count > 0;
		bool flag12 = flag11 && upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag11);
		PDLEOCMNIJJ.text = ((!flag11) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[0].Value1));
		BAOHBIDKMHP.text = ((!flag11) ? string.Empty : ((!flag12) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[0].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[0].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 0f)) ? Localization.Localize("ID_NA") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 0f)) ? Localization.Localize("ID_NA") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 0f)) ? Localization.Localize("ID_NA") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 0f)) ? Localization.Localize("ID_NA") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 0f)) ? Localization.Localize("ID_NA") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	public void LHFBPFKOONF(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1280f)) ? 1735f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Already loading player data, wait", string.Empty, false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = false;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1050f);
			if (num2 == 0 && (LPPOJMGOEFN.alpha == 1470f || PPDGFFJLHKK.alpha > 692f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 1694f, 1652f, 750f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.onFinished = PHEPMMBBFKN;
			}
			if (num2 == 2 && (PPDGFFJLHKK.alpha == 1339f || LPPOJMGOEFN.alpha > 1262f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 292f, 1245f, 63f);
				tweenAlpha2.NumOfRepetitions = 0;
				tweenAlpha2.onFinished = HLHGLLMGHAA;
			}
		}
	}

	private void CPIOJNFMINL(GameObject KHAHPAKDIKE)
	{
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			IDINCHPIGPI();
		}
	}

	private void PNKKJAHOLMH()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.TRAINSPECIAL);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("ID_WARNING_INCORRECTASSIGNMENTS_TEXT");
		}
		else
		{
			Singleton<Wallet>.instance.ALBICJOEMEF(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
			GuiScreenSingle<ArmyScreen>.instance.KCCBLGIMJPM(IFFDIHCPKFE);
		}
	}

	public void FNLELBKLNBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHGDHGCBOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DIGMKHABEGF));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HJJEIDACGGA));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HFDPEIEGNKL.onReposition = DCLIHPMKOHD;
		CKPLDDIPNAA.onReposition = GDLIABMNKPF;
		FOPKJKDCDON();
	}

	private void JNGFKKEBOHH(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 660f, 1740f, 87f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void EFHGNLCMMAH()
	{
		GuiScreenSingle<ArmyScreen>.instance.ANPJBBCCJDF(IFFDIHCPKFE);
	}

	private void JKNKEPJDFBB(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1692f, 713f, 716f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	public void CDHICHLOPEN()
	{
		if (!IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)0);
			int num2 = IFFDIHCPKFE.upgradeSlots.price + IFFDIHCPKFE.upgradeSlots.priceGold;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (-107 - num) / -13;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = true;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				UILabel eKIDAFLLCNM = EKIDAFLLCNM;
				object[] array = new object[1];
				array[1] = num;
				eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_YES", array);
				JBGPDECEOOB.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, AKDLEDNDIEO.Buy));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(PMBLOMEGDDN));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(LECBFEFACLE));
			}
			else
			{
				JBGPDECEOOB.KEIIENDMKLN();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(CDHICHLOPEN));
			}
		}
	}

	public void BCMCGJGLFPL()
	{
		JBGPDECEOOB.PEHBGMEHFEM();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		IEFJCBMAANN();
	}

	private void BJAAPNHBGBG(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMPADNOGGNL.alpha = 1111f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(1789f, 1607f, 228f);
		}
		else
		{
			float num = 1638f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 469f * num, 5f, 1682f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 785f * num, new Vector3(160f, 1054f, 1461f), new Vector3(1752f, 1459f, 239f));
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void AAENNLBNGEG()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 1475f;
			GGMOJMMLEKA.gameObject.SetActive(true);
			OJBKADHPNFN = false;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 255f, 1234f).onFinished = null;
	}

	public void KPKONEJJKLO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNACCFOJBOI));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DIGMKHABEGF));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HJJEIDACGGA));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HFDPEIEGNKL.onReposition = delegate
		{
			GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
			float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 20f;
			num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 20f + PKAGCKHJODA.transform.localScale.x / 2f;
			GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 4f, -24000f);
		};
		CKPLDDIPNAA.onReposition = GDLIABMNKPF;
		NPGAKFHEEFJ();
	}

	public void OEFIGDDPNDK(GameObject KHAHPAKDIKE)
	{
		JCGLGAPBGOM(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	[CompilerGenerated]
	private void ANFHNPGGHHH(UITweener MGDJMGHCAAI)
	{
		NDNNJMAKKBD();
		TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 1f);
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(25f);
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AJFCCNEPICJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CPIOJNFMINL));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(StatisticsBackgroundClick));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HFDPEIEGNKL.onReposition = delegate
		{
			GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
			float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 20f;
			num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 20f + PKAGCKHJODA.transform.localScale.x / 2f;
			GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 4f, -24000f);
		};
		CKPLDDIPNAA.onReposition = delegate
		{
			float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
			CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
		};
		FOPKJKDCDON();
	}

	private void BDDIDGFEJEN(GameObject KHAHPAKDIKE)
	{
		switch (IFFDIHCPKFE.upgradeSlots.unitState)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
			Debug.Log("ID_RELOG_TO_WRONG_FB_DIALOG_TITLE");
			LevelManager.instance.DebugAddLevel();
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
			Debug.Log("disconnect");
			JDGDJDDANFA();
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			Debug.Log("ID_YOUNEEDMONEYTODELIVERSPECIAL");
			GHCIIJEDFND();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.AGJKPJANEBC(true);
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			Debug.Log("ID_CONFIRM_ERROR");
			HNINMCGLEAK();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.HGOLLOAPIPD();
			break;
		default:
			Debug.Log("country-south-africa");
			break;
		}
	}

	private void JEBCBBONELG(UpgradeSlots.JLANLLEABDC MHHOHDBKCFK)
	{
		switch (MHHOHDBKCFK)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(1246f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(515f);
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(329f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(935f);
			break;
		default:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(247f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(1948f);
			break;
		}
	}

	private void AMKAFLFNGLH()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 755f;
			GGMOJMMLEKA.gameObject.SetActive(true);
			OJBKADHPNFN = false;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 759f, 150f).onFinished = null;
	}

	public void AnimateUnitPower()
	{
		TweenScale tweenScale = TweenScale.Begin(BKOOOBJDJHO.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 4f, new Vector3(62f, 62f, 1f), new Vector3(112f, 112f, 1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	public void PMBLOMEGDDN()
	{
		if (!IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy);
			int num2 = IFFDIHCPKFE.upgradeSlots.price + IFFDIHCPKFE.upgradeSlots.priceGold;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (40 - num) / 104;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = true;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				EKIDAFLLCNM.text = Localization.LocalizeFormat("#Mission Rewards# New missions data (midnight or heroic completed)", num);
				JBGPDECEOOB.APFDDFPMACA(Singleton<OfferManager>.instance.LDBPLEDPPOP(IFFDIHCPKFE, (AKDLEDNDIEO)0));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(LECBFEFACLE));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(CDHICHLOPEN));
			}
			else
			{
				JBGPDECEOOB.BGHNMCPLIPE();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(CDHICHLOPEN));
			}
		}
	}

	private void MPICINDMION(UpgradeSlots.JLANLLEABDC MHHOHDBKCFK)
	{
		switch (MHHOHDBKCFK)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(136f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(1799f);
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(702f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(847f);
			break;
		default:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(82f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(1899f);
			break;
		}
	}

	private void GDLIABMNKPF()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 1243f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	private void BEPNEHBOGEI()
	{
		PKAGCKHJODA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GGMOJMMLEKA.gameObject.SetActive(true);
		OJBKADHPNFN = true;
	}

	private void MFEHBKOFKIP()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 890f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void EMFFNNIMPBG(UITweener MGDJMGHCAAI)
	{
		NDDIDNIJAPK();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(754f), false);
	}

	private void CMMFJNGPAAB()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.IKPEDPCLLID("Rewards");
		}
		else
		{
			Singleton<Wallet>.instance.ALBICJOEMEF(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
			GuiScreenSingle<ArmyScreen>.instance.KCCBLGIMJPM(IFFDIHCPKFE);
		}
	}

	private void BOEMNGNPCNI()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 1539f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void KCPGPJPGJLC()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 734f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	private float PNOIKOAJOAC()
	{
		return 351f + UIHelper.safeAreaSize;
	}

	private void HCPKABIHLKC(UITweener MGDJMGHCAAI)
	{
		HLLEMKBDCHJ();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(484f));
	}

	private void FIACPKDBLDE(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 717f, 718f, 850f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void MIFEMJAOBAM()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 573f;
			GGMOJMMLEKA.gameObject.SetActive(false);
			OJBKADHPNFN = false;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 1247f, 1803f).onFinished = null;
	}

	public void HMCDFANKDHA(GameObject KHAHPAKDIKE)
	{
		CMAJCOOIBDL(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	private void DIGMKHABEGF(GameObject KHAHPAKDIKE)
	{
		if (OJBKADHPNFN)
		{
			JCGLGAPBGOM(false);
		}
		else
		{
			AAENNLBNGEG();
		}
	}

	public void MNIBCGDEAHG(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1138f)) ? 1950f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "country-portugal", string.Empty, false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = false;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 665f);
			if (num2 == 5 && (LPPOJMGOEFN.alpha == 270f || PPDGFFJLHKK.alpha > 610f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 1185f, 1945f, 1009f);
				tweenAlpha.NumOfRepetitions = 0;
				tweenAlpha.onFinished = PHEPMMBBFKN;
			}
			if (num2 == 4 && (PPDGFFJLHKK.alpha == 1435f || LPPOJMGOEFN.alpha > 577f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1161f, 288f, 41f);
				tweenAlpha2.NumOfRepetitions = 0;
				tweenAlpha2.onFinished = PLJGLBMEHFF;
			}
		}
	}

	private void DINDADNGPHG(UpgradeSlots.JLANLLEABDC MHHOHDBKCFK)
	{
		switch (MHHOHDBKCFK)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(1050f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(1740f);
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(1552f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(1537f);
			break;
		default:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(782f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(346f);
			break;
		}
	}

	[CompilerGenerated]
	private void DPJLAHJGPPE(UITweener MGDJMGHCAAI)
	{
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(25f));
	}

	private void AIJMMNPBMPI(GameObject KHAHPAKDIKE)
	{
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			EBMHMJCFBIM();
		}
	}

	private void HLLEMKBDCHJ()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		HGDDEHJJLNP();
		NIPGMDBNIOJ.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		NNIPNHJNHMO.text = Localization.LocalizeFormat("Saved another leaderboard", Colours.stringBlue, IFFDIHCPKFE.upgradeSlots.unlockLevel.MHAOKJCDIOL());
		HCFJJCALLAF.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		BGPBNIJPOKM.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		CODFFPODNEP.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 0);
		SetSaleAndPrize();
		LNFLDPLGEJE.SetActive(unitState == (UpgradeSlots.JLANLLEABDC)8);
		GPBMPAPOEOE.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LPPOJMGOEFN.alpha = 374f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 1742f;
		JPJLKKJJFDB.SetActive(unitState == (UpgradeSlots.JLANLLEABDC)7);
		OHKMIMMFHOG.enabled = unitState != UpgradeSlots.JLANLLEABDC.Locked;
		CGCAMPFGEMK(unitState);
		HDHBKIFNBMF.SetActive(NIPGMDBNIOJ.activeSelf || HCFJJCALLAF.activeSelf || LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf);
		HFDPEIEGNKL.repositionNow = false;
		HFDPEIEGNKL.transform.localPosition = HFDPEIEGNKL.transform.localPosition.ReplaceY((!HDHBKIFNBMF.activeSelf) ? 1284f : 1056f);
	}

	private void KEFCFMIDHBF(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMPADNOGGNL.alpha = 1f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(104f, 74f, 1f);
		}
		else
		{
			float num = 0.5f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 2f * num, 1f, 0f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 2f * num, new Vector3(104f, 74f, 1f), new Vector3(208f, 148f, 1f));
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void EMMKHDAGKCO()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool isMaxUpgraded = upgradeSlots.upgradeSlot.isMaxUpgraded;
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool isBought = upgradeSlots.upgradeSlotSpecial.isBought;
		bool flag = isBought && upgradeSlots.upgradeSlotSpecial.NNFCKENGOMF();
		int fFHHEHHFOKJ = upgradeSlots.upgradeSlotSpecial.NDLFMKODJGG();
		bool isUnlocked = upgradeSlots.upgradeSlotElite.isUnlocked;
		bool flag2 = isUnlocked && upgradeSlots.upgradeSlotElite.IDFIPMFGPIM();
		bool flag3 = !isUnlocked || upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		int armyPowerX2 = upgradeSlots.upgradeSlotElite.armyPowerX10;
		bool flag4 = unitState == UpgradeSlots.JLANLLEABDC.Delivering || unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == UpgradeSlots.JLANLLEABDC.Locked;
		bool flag5 = isMaxUpgraded || upgradeSlots.borrowed || flag4;
		bool flag6 = flag || !isBought || upgradeSlots.borrowed || flag4;
		bool flag7 = isUnlocked && !flag2 && flag3;
		bool flag8 = unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered;
		bool flag9 = !flag8 || upgradeSlots.upgradeSlot.FPDAMADLNGH();
		bool flag10 = !flag8 || upgradeSlots.upgradeSlotSpecial.FPDAMADLNGH();
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(isBought);
		JJKPAKGNMCP.gameObject.SetActive(isBought);
		if (isBought)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag3);
		EOEGBEKBJEM.gameObject.SetActive(flag3);
		EHNNKBIFOCP.gameObject.SetActive(flag3);
		if (flag3)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX2);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP, 629f);
		}
		UILabel jANJPPELPBG = JANJPPELPBG;
		string text;
		if (allUpgradesBought)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max);
			text = Localization.LocalizeFormat("getExperimentId", array);
		}
		jANJPPELPBG.text = text;
		FEJELKKFMPK.text = ((!flag5) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX, 1667f));
		PMDCIMIFLMD.text = ((!flag6) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX, 456f));
		APEPPPIIANB.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX, 1231f));
		if (flag9)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 348f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.Once;
		}
		if (flag10)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 1776f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.style = (UITweener.Style)4;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 1045f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 0;
		tweenColor3.style = (UITweener.Style)6;
		GHKLHGDNAAC.gameObject.SetActive(isMaxUpgraded);
		IKNDFOJPCJP.gameObject.SetActive(flag);
		AGELGEBACHH.gameObject.SetActive(flag2);
		MANDLOFIMKH(DOIHNIFPOLP, flag9, flag9 || isMaxUpgraded);
		BLJMMDILOLC(LHLNNPGFOKE, flag10, flag10 || flag);
		AIOPMALGJJN(FAMLAICPKAP, false, flag2);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 257f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 388f)) ? 521f : (num2 + 360f));
		num += PKAGCKHJODA.transform.localScale.x / 359f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag11 = upgradeSlots.unitSpecifics.Count > 0;
		bool flag12 = !flag11 || upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag11);
		PDLEOCMNIJJ.text = ((!flag11) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[1].Value1));
		BAOHBIDKMHP.text = ((!flag11) ? string.Empty : ((!flag12) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[0].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[0].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 478f)) ? Localization.Localize("ID_SALEPERCENT") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 693f)) ? Localization.Localize("SetGameObjectCallback") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 1597f)) ? Localization.Localize("setViewForPopups") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 667f)) ? Localization.Localize("ID_STATE_CONNECTINGTOSERVER") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 1041f)) ? Localization.Localize("instantBattleAvailable") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	[SpecialName]
	private float DLELKMDPODO()
	{
		return 359f + UIHelper.safeAreaSize;
	}

	private void MMJIFMCIAON(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMPADNOGGNL.alpha = 559f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(378f, 409f, 802f);
		}
		else
		{
			float num = 1656f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1834f * num, 1770f, 1179f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 760f * num, new Vector3(1164f, 1689f, 1104f), new Vector3(1941f, 476f, 1086f));
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	public void DJOEGBIMLOK(bool NOLODGKKCDH = true)
	{
		if (NOLODGKKCDH)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(1147f));
			HLLEMKBDCHJ();
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked || IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(ALNEPJFGINB())).onFinished = LGAKHJLPIOP;
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered && (LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf || HCFJJCALLAF.activeSelf))
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(DLELKMDPODO()), false);
			TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 279f).onFinished = delegate
			{
				NDNNJMAKKBD();
				TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 1f);
				EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(25f);
			};
		}
		else
		{
			JGEAOHCLKPF();
		}
	}

	public void COBDHBOCGAP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHGDHGCBOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CPIOJNFMINL));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KHEIOKNOBGO));
		CHCFBDMGNLP.onReposition = MFEHBKOFKIP;
		HFDPEIEGNKL.onReposition = delegate
		{
			GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
			float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 20f;
			num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 20f + PKAGCKHJODA.transform.localScale.x / 2f;
			GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 4f, -24000f);
		};
		CKPLDDIPNAA.onReposition = GDLIABMNKPF;
		EBADAABONCP();
	}

	private void IBHIGDJACBA()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 1144f;
			GGMOJMMLEKA.gameObject.SetActive(true);
			OJBKADHPNFN = false;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 1105f, 1023f).onFinished = null;
	}

	private void FJIKDLMEIML()
	{
		GuiScreenSingle<ArmyScreen>.instance.EEOGACOBOOH(IFFDIHCPKFE);
	}

	public void LPOPNGPOKIN(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 905f)) ? 1341f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "GetVGOfferInfoForZone", string.Empty, false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = true;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1460f);
		if (num2 == 5 && (LPPOJMGOEFN.alpha == 1769f || PPDGFFJLHKK.alpha > 1531f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 86f, 1939f, 495f);
			tweenAlpha.NumOfRepetitions = 0;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 0 && (PPDGFFJLHKK.alpha == 1172f || LPPOJMGOEFN.alpha > 975f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 392f, 87f, 1965f);
			tweenAlpha2.NumOfRepetitions = 0;
			tweenAlpha2.onFinished = PLJGLBMEHFF;
		}
	}

	private void HEIHKLDOACJ(UITweener MGDJMGHCAAI)
	{
		DJHKDIMININ();
	}

	private void MANDLOFIMKH(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMPADNOGGNL.alpha = 1893f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(540f, 908f, 1344f);
		}
		else
		{
			float num = 336f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 909f * num, 183f, 641f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 1566f * num, new Vector3(1268f, 6f, 1917f), new Vector3(364f, 432f, 279f));
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void NDDIDNIJAPK()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		EMMKHDAGKCO();
		NIPGMDBNIOJ.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		UILabel nNIPNHJNHMO = NNIPNHJNHMO;
		object[] array = new object[8];
		array[0] = Colours.stringBlue;
		array[0] = IFFDIHCPKFE.upgradeSlots.unlockLevel.displayNumber;
		nNIPNHJNHMO.text = Localization.LocalizeFormat("Name", array);
		HCFJJCALLAF.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		BGPBNIJPOKM.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		CODFFPODNEP.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		PMBLOMEGDDN();
		LNFLDPLGEJE.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Active);
		GPBMPAPOEOE.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LPPOJMGOEFN.alpha = 350f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 330f;
		JPJLKKJJFDB.SetActive(unitState == (UpgradeSlots.JLANLLEABDC)8);
		OHKMIMMFHOG.enabled = unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
		DINDADNGPHG(unitState);
		HDHBKIFNBMF.SetActive(!NIPGMDBNIOJ.activeSelf && !HCFJJCALLAF.activeSelf && !LNFLDPLGEJE.activeSelf && JPJLKKJJFDB.activeSelf);
		HFDPEIEGNKL.repositionNow = false;
		HFDPEIEGNKL.transform.localPosition = HFDPEIEGNKL.transform.localPosition.ReplaceY((!HDHBKIFNBMF.activeSelf) ? 104f : 451f);
	}

	[SpecialName]
	private float ALNEPJFGINB()
	{
		return 1430f + UIHelper.safeAreaSize;
	}

	private void NDNNJMAKKBD()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		EAKECIHGCLC();
		NIPGMDBNIOJ.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		NNIPNHJNHMO.text = Localization.LocalizeFormat("ID_GUI_UNLOCKEDAT", Colours.stringBlue, IFFDIHCPKFE.upgradeSlots.unlockLevel.displayNumber);
		HCFJJCALLAF.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		BGPBNIJPOKM.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		CODFFPODNEP.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 0);
		SetSaleAndPrize();
		LNFLDPLGEJE.SetActive(unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering);
		GPBMPAPOEOE.text = string.Empty;
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
		JPJLKKJJFDB.SetActive(unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered);
		OHKMIMMFHOG.enabled = unitState != UpgradeSlots.JLANLLEABDC.Locked;
		GCOLDOGGPEF(unitState);
		HDHBKIFNBMF.SetActive(NIPGMDBNIOJ.activeSelf || HCFJJCALLAF.activeSelf || LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf);
		HFDPEIEGNKL.repositionNow = true;
		HFDPEIEGNKL.transform.localPosition = HFDPEIEGNKL.transform.localPosition.ReplaceY((!HDHBKIFNBMF.activeSelf) ? 312f : 270f);
	}

	private void BNACCFOJBOI(GameObject KHAHPAKDIKE)
	{
		switch (IFFDIHCPKFE.upgradeSlots.unitState)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
			Debug.Log("en");
			LevelManager.instance.DebugAddLevel();
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
			Debug.Log("SWITCH TO DEATCHMATCH");
			JDGDJDDANFA();
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			Debug.Log("07");
			CMMFJNGPAAB();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.NCDHKBKPPMG(false);
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			Debug.Log("Game shoootable entitiy without owner");
			OLBPDALHLDG();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.KKJEHCHKJDB();
			break;
		default:
			Debug.Log("armyPower");
			break;
		}
	}

	public void KHEIOKNOBGO(GameObject KHAHPAKDIKE)
	{
		AKBJLEMHAAJ(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	private void ODHFKEGEBMO()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.IKPEDPCLLID("Automatic_Equip");
		}
		else
		{
			Singleton<Wallet>.instance.ALBICJOEMEF(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
			GuiScreenSingle<ArmyScreen>.instance.DEMLFFPFKMH(IFFDIHCPKFE);
		}
	}

	public void KIEBMLPFDBH()
	{
		TweenScale tweenScale = TweenScale.Begin(BKOOOBJDJHO.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 358f, new Vector3(65f, 1532f, 1145f), new Vector3(1020f, 1838f, 375f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = (UITweener.Style)6;
	}

	private void LCONMFPGFAM(UITweener MGDJMGHCAAI)
	{
		DJHKDIMININ();
	}

	private void CMAJCOOIBDL(bool FGHNCECHPPO = true)
	{
		if (GGMOJMMLEKA.gameObject.activeSelf)
		{
			if (FGHNCECHPPO)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
			}
			TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 0.2f, 0f).onFinished = delegate
			{
				FOPKJKDCDON();
			};
		}
	}

	private void FDLKALCGLCH(GameObject KHAHPAKDIKE)
	{
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL(false);
		}
		else
		{
			HODIEAACBED();
		}
	}

	private void NPGAKFHEEFJ()
	{
		PKAGCKHJODA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GGMOJMMLEKA.gameObject.SetActive(true);
		OJBKADHPNFN = true;
	}

	private void JDGDJDDANFA()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)0);
		int num2 = IFFDIHCPKFE.upgradeSlots.price * (-17 - num) / 57;
		int num3 = IFFDIHCPKFE.upgradeSlots.priceGold * (-107 - num) / 111;
		if (num > 0)
		{
			Debug.Log(string.Format("Gold", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num2, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.PDANLJJAEDC(")");
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num3))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num3, IFFDIHCPKFE.unitName);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("RequestsResults");
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (IFFDIHCPKFE.upgradeSlots.priceGold > 0)
			{
				Debug.Log("There is null unit in mission {0} {1} configuration");
			}
			else if (levelBehaviour.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
			{
				GuiScreenSingle<ArmyScreen>.instance.EEOGACOBOOH(levelBehaviour);
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Active)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogUnits(levelBehaviour, IFFDIHCPKFE, false);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.NGAOKIAMKAD(levelBehaviour, true);
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		Singleton<Wallet>.instance.ALBICJOEMEF(num3);
		GuiScreenSingle<ArmyScreen>.instance.GAKDCJEFKEL(IFFDIHCPKFE, num);
	}

	private void NLDFGEFNLNL()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		GBNAGBKIBML();
		NIPGMDBNIOJ.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		UILabel nNIPNHJNHMO = NNIPNHJNHMO;
		object[] array = new object[8];
		array[1] = Colours.stringBlue;
		array[0] = IFFDIHCPKFE.upgradeSlots.unlockLevel.NPOEMAMPNEP();
		nNIPNHJNHMO.text = Localization.LocalizeFormat("warbucks", array);
		HCFJJCALLAF.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		BGPBNIJPOKM.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		CODFFPODNEP.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		CDHICHLOPEN();
		LNFLDPLGEJE.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		GPBMPAPOEOE.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LPPOJMGOEFN.alpha = 817f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 229f;
		JPJLKKJJFDB.SetActive(unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering);
		OHKMIMMFHOG.enabled = unitState == UpgradeSlots.JLANLLEABDC.Locked;
		MPICINDMION(unitState);
		HDHBKIFNBMF.SetActive(NIPGMDBNIOJ.activeSelf || HCFJJCALLAF.activeSelf || LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf);
		HFDPEIEGNKL.repositionNow = false;
		HFDPEIEGNKL.transform.localPosition = HFDPEIEGNKL.transform.localPosition.ReplaceY((!HDHBKIFNBMF.activeSelf) ? 416f : 142f);
	}

	public void UpdateRightContent(bool NOLODGKKCDH = true)
	{
		if (NOLODGKKCDH)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(25f));
			NDNNJMAKKBD();
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM)).onFinished = delegate
			{
				NDNNJMAKKBD();
				TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(25f));
			};
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active && (LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf || HCFJJCALLAF.activeSelf))
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM));
			TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 0f).onFinished = delegate
			{
				NDNNJMAKKBD();
				TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 1f);
				EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(25f);
			};
		}
		else
		{
			EAKECIHGCLC();
		}
	}

	private void LGAKHJLPIOP(UITweener MGDJMGHCAAI)
	{
		NLDFGEFNLNL();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(396f));
	}

	public void HCAOABHNLID()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AJFCCNEPICJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CPIOJNFMINL));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NPLAOBMIBMD));
		CHCFBDMGNLP.onReposition = DKOGFLOOJCN;
		HFDPEIEGNKL.onReposition = JCPDBHAOMFC;
		CKPLDDIPNAA.onReposition = delegate
		{
			float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
			CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
		};
		EBADAABONCP();
	}

	public void GJPIMMHDNMO(GameObject KHAHPAKDIKE)
	{
		CMAJCOOIBDL(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	private void OKECDACPKHB(UITweener MGDJMGHCAAI)
	{
		KDHACIJKGNH();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(1863f), false);
	}

	public void DHHHCBPJNCL(GameObject KHAHPAKDIKE)
	{
		CMAJCOOIBDL(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	public void SetSaleAndPrize()
	{
		if (!IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy);
			int num2 = IFFDIHCPKFE.upgradeSlots.price + IFFDIHCPKFE.upgradeSlots.priceGold;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = true;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, AKDLEDNDIEO.Buy));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(SetSaleAndPrize));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
			else
			{
				JBGPDECEOOB.JCMHGOGNMFO();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
		}
	}

	private void AJFCCNEPICJ(GameObject KHAHPAKDIKE)
	{
		switch (IFFDIHCPKFE.upgradeSlots.unitState)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: LOCKED\t\tbutton type: LEVEL UP");
			LevelManager.instance.DebugAddLevel();
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: NOT BOUGHT\t\tbutton type: BUY UNIT");
			HMAPLDEANJF();
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER");
			GHCIIJEDFND();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.deliveringAnimation = false;
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT");
			BACFJFFBPOO();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.PlayEndAnimation();
			break;
		default:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - should not happen");
			break;
		}
	}

	public void BGPAHPGDDJB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHGDHGCBOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DIGMKHABEGF));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LLJJAPNCABB));
		CHCFBDMGNLP.onReposition = MFEHBKOFKIP;
		HFDPEIEGNKL.onReposition = DCLIHPMKOHD;
		CKPLDDIPNAA.onReposition = delegate
		{
			float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
			CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
		};
		BEPNEHBOGEI();
	}

	private void IHILDLODJDM(UITweener MGDJMGHCAAI)
	{
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(601f), false);
	}

	public void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BDDIDGFEJEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CPIOJNFMINL));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DHHHCBPJNCL));
		CHCFBDMGNLP.onReposition = DKOGFLOOJCN;
		HFDPEIEGNKL.onReposition = DCLIHPMKOHD;
		CKPLDDIPNAA.onReposition = BOEMNGNPCNI;
		NPGAKFHEEFJ();
	}

	private void EGAHIJAHPCP(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 511f, 1204f, 1005f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void ECDKLKABMAL()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 711f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	public void EMOKJHJIIGF(GameObject KHAHPAKDIKE)
	{
		JCGLGAPBGOM(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	private void EBMHMJCFBIM()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 148f;
			GGMOJMMLEKA.gameObject.SetActive(true);
			OJBKADHPNFN = false;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 1252f, 1214f).onFinished = null;
	}

	private void BLJMMDILOLC(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMPADNOGGNL.alpha = 1098f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(1892f, 1637f, 435f);
		}
		else
		{
			float num = 1826f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 844f * num, 611f, 626f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 413f * num, new Vector3(161f, 555f, 535f), new Vector3(1722f, 1025f, 1034f));
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 1;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	[CompilerGenerated]
	private void FAILEAJDHBM(UITweener MGDJMGHCAAI)
	{
		FOPKJKDCDON();
	}

	private void OEJAJOAJCNC(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMPADNOGGNL.alpha = 1682f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(956f, 391f, 931f);
		}
		else
		{
			float num = 156f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 896f * num, 909f, 1503f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 1730f * num, new Vector3(12f, 975f, 1202f), new Vector3(939f, 42f, 506f));
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 1;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void IKKBPBIMPPO(UITweener MGDJMGHCAAI)
	{
		NLDFGEFNLNL();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(1448f), false);
	}

	private void FNIONNPPHCI()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice, IFFDIHCPKFE.unitName);
			GuiElementSingle<InappScreen>.instance.PDANLJJAEDC("Google2u.DBUpgradeSlotsGrennader");
		}
		else
		{
			Singleton<Wallet>.instance.ALBICJOEMEF(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
			GuiScreenSingle<ArmyScreen>.instance.GBNGDHECMOP(IFFDIHCPKFE);
		}
	}

	private void KDHACIJKGNH()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		GBNAGBKIBML();
		NIPGMDBNIOJ.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		UILabel nNIPNHJNHMO = NNIPNHJNHMO;
		object[] array = new object[3];
		array[1] = Colours.stringBlue;
		array[1] = IFFDIHCPKFE.upgradeSlots.unlockLevel.ELFCEEOLNFJ();
		nNIPNHJNHMO.text = Localization.LocalizeFormat("ID_TOCOMPLETE", array);
		HCFJJCALLAF.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		BGPBNIJPOKM.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 1);
		CODFFPODNEP.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		PMBLOMEGDDN();
		LNFLDPLGEJE.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		GPBMPAPOEOE.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LPPOJMGOEFN.alpha = 266f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 1808f;
		JPJLKKJJFDB.SetActive(unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered);
		OHKMIMMFHOG.enabled = unitState == UpgradeSlots.JLANLLEABDC.Locked;
		CGCAMPFGEMK(unitState);
		HDHBKIFNBMF.SetActive(!NIPGMDBNIOJ.activeSelf && !HCFJJCALLAF.activeSelf && !LNFLDPLGEJE.activeSelf && JPJLKKJJFDB.activeSelf);
		HFDPEIEGNKL.repositionNow = false;
		HFDPEIEGNKL.transform.localPosition = HFDPEIEGNKL.transform.localPosition.ReplaceY((!HDHBKIFNBMF.activeSelf) ? 1568f : 1700f);
	}

	private void HMAPLDEANJF()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy);
		int num2 = IFFDIHCPKFE.upgradeSlots.price * (100 - num) / 100;
		int num3 = IFFDIHCPKFE.upgradeSlots.priceGold * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log(string.Format("Have discount {0} to buy {1}", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Buy_Units";
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num3))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num3, IFFDIHCPKFE.unitName);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Buy_Units";
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (IFFDIHCPKFE.upgradeSlots.priceGold > 0)
			{
				Debug.Log("Buying army unit for gold possible even when already upgrading");
			}
			else if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
			{
				GuiScreenSingle<ArmyScreen>.instance.JGKBPDEKING(levelBehaviour);
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogUnits(levelBehaviour, IFFDIHCPKFE, false);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(levelBehaviour, false);
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		Singleton<Wallet>.instance.MBAFMBJFOKH(num3);
		GuiScreenSingle<ArmyScreen>.instance.GAKDCJEFKEL(IFFDIHCPKFE, num);
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 20f;
		num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 20f + PKAGCKHJODA.transform.localScale.x / 2f;
		GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 4f, -24000f);
	}

	public void NPLAOBMIBMD(GameObject KHAHPAKDIKE)
	{
		AKBJLEMHAAJ(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	private void PHEPMMBBFKN(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 775f, 1862f, 69f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void KGKIBEBMEEF(UITweener MGDJMGHCAAI)
	{
		HLLEMKBDCHJ();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(596f), false);
	}

	private void JCPDBHAOMFC()
	{
		GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 656f;
		num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 1939f + PKAGCKHJODA.transform.localScale.x / 1484f;
		GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 1091f, 1633f);
	}

	public void DoAfterHide()
	{
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		FOPKJKDCDON();
	}

	private void BAIDEAAFFED()
	{
		GuiScreenSingle<ArmyScreen>.instance.JGKBPDEKING(IFFDIHCPKFE);
	}

	public void UpdateDeliveringTime(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 0f)) ? 0f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
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

	private void NMIDCFHHOOE(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMPADNOGGNL.alpha = 1922f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(1917f, 1955f, 336f);
		}
		else
		{
			float num = 1879f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 40f * num, 276f, 1177f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 370f * num, new Vector3(919f, 957f, 713f), new Vector3(210f, 957f, 625f));
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	public void StatisticsBackgroundClick(GameObject KHAHPAKDIKE)
	{
		CMAJCOOIBDL(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	public void FBBJKJGBOJL(bool NOLODGKKCDH = true)
	{
		if (NOLODGKKCDH)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(1372f));
			HLLEMKBDCHJ();
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(ALNEPJFGINB()), false).onFinished = HCPKABIHLKC;
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed && (LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf || HCFJJCALLAF.activeSelf))
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(ALNEPJFGINB()), false);
			TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 28f).onFinished = GFHDJFEIPOK;
		}
		else
		{
			JGEAOHCLKPF();
		}
	}

	private void AIOPMALGJJN(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMPADNOGGNL.alpha = 1671f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(1486f, 1921f, 1082f);
		}
		else
		{
			float num = 1985f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1958f * num, 780f, 44f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 1507f * num, new Vector3(848f, 1657f, 572f), new Vector3(621f, 101f, 1464f));
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	public void CLPOIBICIJA(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 151f)) ? 1902f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "THANK YOU", string.Empty, false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = false;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1321f);
			if (num2 == 5 && (LPPOJMGOEFN.alpha == 489f || PPDGFFJLHKK.alpha > 1270f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 642f, 910f, 815f);
				tweenAlpha.NumOfRepetitions = 0;
				tweenAlpha.onFinished = JKNKEPJDFBB;
			}
			if (num2 == 1 && (PPDGFFJLHKK.alpha == 764f || LPPOJMGOEFN.alpha > 92f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1396f, 825f, 48f);
				tweenAlpha2.NumOfRepetitions = 0;
				tweenAlpha2.onFinished = HLHGLLMGHAA;
			}
		}
	}

	private void AOMMBBJOMCE(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMPADNOGGNL.alpha = 531f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			GMPADNOGGNL.transform.localScale = new Vector3(958f, 1460f, 1600f);
		}
		else
		{
			float num = 370f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 552f * num, 1822f, 1793f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 41f * num, new Vector3(1300f, 885f, 1068f), new Vector3(1265f, 1081f, 1349f));
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void IDINCHPIGPI()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 0f;
			GGMOJMMLEKA.gameObject.SetActive(true);
			OJBKADHPNFN = true;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 0.2f, 1f).onFinished = null;
	}

	[CompilerGenerated]
	private void KGPEAMIDEOA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void GFHDJFEIPOK(UITweener MGDJMGHCAAI)
	{
		NLDFGEFNLNL();
		TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 115f);
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(10f);
	}

	private void BACFJFFBPOO()
	{
		GuiScreenSingle<ArmyScreen>.instance.JGKBPDEKING(IFFDIHCPKFE);
	}

	[SpecialName]
	private float BNHKGHPMANN()
	{
		return 1577f + UIHelper.safeAreaSize;
	}

	private void DBBCLFJHHGP()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool flag = upgradeSlots.upgradeSlot.IDFIPMFGPIM();
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool isBought = upgradeSlots.upgradeSlotSpecial.isBought;
		bool flag2 = isBought && upgradeSlots.upgradeSlotSpecial.NNFCKENGOMF();
		int fFHHEHHFOKJ = upgradeSlots.upgradeSlotSpecial.NDLFMKODJGG();
		bool isUnlocked = upgradeSlots.upgradeSlotElite.isUnlocked;
		bool flag3 = !isUnlocked || upgradeSlots.upgradeSlotElite.IDFIPMFGPIM();
		bool flag4 = !isUnlocked || upgradeSlots.upgradeSlotElite.JFAELKHPLLA();
		int fFHHEHHFOKJ2 = upgradeSlots.upgradeSlotElite.NDLFMKODJGG();
		bool flag5 = unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered || unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == UpgradeSlots.JLANLLEABDC.Delivering;
		bool flag6 = !flag && !upgradeSlots.borrowed && flag5;
		bool flag7 = !flag2 && isBought && !upgradeSlots.borrowed && flag5;
		bool flag8 = !isUnlocked || flag3 || flag4;
		bool flag9 = unitState == (UpgradeSlots.JLANLLEABDC)8;
		bool flag10 = !flag9 || upgradeSlots.upgradeSlot.FPDAMADLNGH();
		bool flag11 = !flag9 || upgradeSlots.upgradeSlotSpecial.LCFLGKPGEAG();
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(isBought);
		JJKPAKGNMCP.gameObject.SetActive(isBought);
		if (isBought)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag4);
		EOEGBEKBJEM.gameObject.SetActive(flag4);
		EHNNKBIFOCP.gameObject.SetActive(flag4);
		if (flag4)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP, 807f);
		}
		UILabel jANJPPELPBG = JANJPPELPBG;
		string text;
		if (allUpgradesBought)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max);
			text = Localization.LocalizeFormat(". Correcting...", array);
		}
		jANJPPELPBG.text = text;
		FEJELKKFMPK.text = ((!flag6) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX, 600f));
		PMDCIMIFLMD.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX, 1605f));
		APEPPPIIANB.text = ((!flag8) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX, 739f));
		if (flag10)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 1860f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.Once;
		}
		if (flag11)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 655f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.style = UITweener.Style.Loop;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 14f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 1;
		tweenColor3.style = UITweener.Style.PingPong;
		GHKLHGDNAAC.gameObject.SetActive(flag);
		IKNDFOJPCJP.gameObject.SetActive(flag2);
		AGELGEBACHH.gameObject.SetActive(flag3);
		NMIDCFHHOOE(DOIHNIFPOLP, flag10, flag10 || flag);
		KEFCFMIDHBF(LHLNNPGFOKE, flag11, !flag11 && flag2);
		AIOPMALGJJN(FAMLAICPKAP, true, flag3);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 399f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 313f)) ? 1455f : (num2 + 1204f));
		num += PKAGCKHJODA.transform.localScale.x / 788f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag12 = upgradeSlots.unitSpecifics.Count > 1;
		bool flag13 = !flag12 || upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag12);
		PDLEOCMNIJJ.text = ((!flag12) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[0].Value1));
		BAOHBIDKMHP.text = ((!flag12) ? string.Empty : ((!flag13) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[0].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[1].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 551f)) ? Localization.Localize("menu-gold") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 1122f)) ? Localization.Localize("#PETER# League Arc ") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 1866f)) ? Localization.Localize("#AccoutCheck# account exist") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 411f)) ? Localization.Localize("HeroicReward") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 413f)) ? Localization.Localize("MinDamage") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	public void NKNJCBEPGFK(bool NOLODGKKCDH = true)
	{
		if (NOLODGKKCDH)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(692f), false);
			NDNOOOOIMOJ();
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked || IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || IFFDIHCPKFE.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(ALNEPJFGINB())).onFinished = DBDOCENODBG;
		}
		else if (IFFDIHCPKFE.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered && (LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf || HCFJJCALLAF.activeSelf))
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(BNHKGHPMANN()));
			TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 1240f).onFinished = delegate
			{
				NDNNJMAKKBD();
				TweenAlpha.Begin(HFDPEIEGNKL.gameObject, JCAFFELIFAO, 1f);
				EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(25f);
			};
		}
		else
		{
			DBBCLFJHHGP();
		}
	}

	public void MPBLCELDAGK(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(1335f + num);
		HFDPEIEGNKL.repositionNow = false;
		UILabel oMGFCIHDGIB = OMGFCIHDGIB;
		object[] array = new object[1];
		array[1] = IFFDIHCPKFE.unitName.ToUpper();
		oMGFCIHDGIB.text = Localization.LocalizeFormat("grenadelauncher_idle", array);
		UILabel iKNLLGBNMAB = IKNLLGBNMAB;
		object[] array2 = new object[8];
		array2[1] = Colours.stringWhite;
		array2[0] = IFFDIHCPKFE.upgradeSlots.totalPower;
		iKNLLGBNMAB.text = Localization.LocalizeFormat("shield_unhide", array2);
		for (int i = 1; i < LHNGDJNBDKK.Length; i++)
		{
			LHNGDJNBDKK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.totalPower);
		}
		BHBAPKGBANI.repositionNow = false;
		UILabel bKMGNFFEJDB = BKMGNFFEJDB;
		object[] array3 = new object[0];
		array3[0] = Colours.stringWhite;
		array3[1] = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		bKMGNFFEJDB.text = Localization.LocalizeFormat("count", array3);
		UILabel oMEMJGFOEPO = OMEMJGFOEPO;
		object[] array4 = new object[2];
		array4[1] = Colours.stringWhite;
		array4[0] = IFFDIHCPKFE.upgradeSlots.spawns;
		oMEMJGFOEPO.text = Localization.LocalizeFormat("CardManagerData", array4);
		bool flag = !Singleton<GameVariables>.instance.isiPadResolution && IFFDIHCPKFE.upgradeSlots.bought;
		GDCNCNGOPIH.SetActive(flag);
		if (flag)
		{
			for (int j = 1; j < GOBKHCALGHA.Length; j += 0)
			{
				GOBKHCALGHA[j].SetActive(j < IFFDIHCPKFE.upgradeSlots.totalPower);
			}
			JGIGODHJNMO.text = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		}
	}

	private void PAPFCAFPEJN()
	{
		PKAGCKHJODA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GGMOJMMLEKA.gameObject.SetActive(false);
		OJBKADHPNFN = false;
	}

	private void KPHGDHGCBOC(GameObject KHAHPAKDIKE)
	{
		switch (IFFDIHCPKFE.upgradeSlots.unitState)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
			Debug.Log("Play_Card_Tutorial_Duration");
			LevelManager.instance.DebugAddLevel();
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
			Debug.Log("GetGameConfigurationValue(");
			AGPCMJFLAIB();
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			Debug.Log("metalExplosion");
			FNIONNPPHCI();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.IGHALNDAGCL(true);
			break;
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			Debug.Log("response contain VipReward");
			OLBPDALHLDG();
			GuiScreenSingle<ArmyScreen>.instance.FHFIPPFJIAH.HGOLLOAPIPD();
			break;
		default:
			Debug.Log("Excel {0} dont have row Tier!!!");
			break;
		}
	}

	private void HLHGLLMGHAA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 1199f, 1535f, 504f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void HACDMJBJHOD()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool flag = upgradeSlots.upgradeSlot.IDFIPMFGPIM();
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool isBought = upgradeSlots.upgradeSlotSpecial.isBought;
		bool flag2 = !isBought || upgradeSlots.upgradeSlotSpecial.isMaxUpgraded;
		int armyPowerX2 = upgradeSlots.upgradeSlotSpecial.armyPowerX10;
		bool isUnlocked = upgradeSlots.upgradeSlotElite.isUnlocked;
		bool flag3 = !isUnlocked || upgradeSlots.upgradeSlotElite.NNFCKENGOMF();
		bool flag4 = !isUnlocked || upgradeSlots.upgradeSlotElite.isBought;
		int fFHHEHHFOKJ = upgradeSlots.upgradeSlotElite.NDLFMKODJGG();
		bool flag5 = unitState == (UpgradeSlots.JLANLLEABDC)8 || unitState == (UpgradeSlots.JLANLLEABDC)7 || unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered;
		bool flag6 = !flag && !upgradeSlots.borrowed && flag5;
		bool flag7 = flag2 || !isBought || upgradeSlots.borrowed || flag5;
		bool flag8 = !isUnlocked || flag3 || flag4;
		bool flag9 = unitState == UpgradeSlots.JLANLLEABDC.Delivering;
		bool flag10 = !flag9 || upgradeSlots.upgradeSlot.isDelivering;
		bool flag11 = !flag9 || upgradeSlots.upgradeSlotSpecial.LCFLGKPGEAG();
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(isBought);
		JJKPAKGNMCP.gameObject.SetActive(isBought);
		if (isBought)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX2);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag4);
		EOEGBEKBJEM.gameObject.SetActive(flag4);
		EHNNKBIFOCP.gameObject.SetActive(flag4);
		if (flag4)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP, 994f);
		}
		UILabel jANJPPELPBG = JANJPPELPBG;
		string text;
		if (allUpgradesBought)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max);
			text = Localization.LocalizeFormat("Golden_Suitcase", array);
		}
		jANJPPELPBG.text = text;
		FEJELKKFMPK.text = ((!flag6) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX, 964f));
		PMDCIMIFLMD.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX, 981f));
		APEPPPIIANB.text = ((!flag8) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX, 75f));
		if (flag10)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 816f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)5;
		}
		if (flag11)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 609f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 0;
			tweenColor2.style = UITweener.Style.PingPong;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 248f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 1;
		tweenColor3.style = UITweener.Style.Loop;
		GHKLHGDNAAC.gameObject.SetActive(flag);
		IKNDFOJPCJP.gameObject.SetActive(flag2);
		AGELGEBACHH.gameObject.SetActive(flag3);
		MMJIFMCIAON(DOIHNIFPOLP, flag10, flag10 || flag);
		BJAAPNHBGBG(LHLNNPGFOKE, flag11, !flag11 && flag2);
		AOMMBBJOMCE(FAMLAICPKAP, true, flag3);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 1959f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 1412f)) ? 1709f : (num2 + 466f));
		num += PKAGCKHJODA.transform.localScale.x / 865f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag12 = upgradeSlots.unitSpecifics.Count > 0;
		bool flag13 = flag12 && upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag12);
		PDLEOCMNIJJ.text = ((!flag12) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[0].Value1));
		BAOHBIDKMHP.text = ((!flag12) ? string.Empty : ((!flag13) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[1].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[0].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 806f)) ? Localization.Localize("HP") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 428f)) ? Localization.Localize("Fuseboxx Config Value = ") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 771f)) ? Localization.Localize("WarsEvaluation") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 1959f)) ? Localization.Localize("Player_Avoided_Grenade_On_First_Try") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 202f)) ? Localization.Localize("Result for action:{0} on global:{1}") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	public void LECBFEFACLE()
	{
		if (!IFFDIHCPKFE.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)0);
			int num2 = IFFDIHCPKFE.upgradeSlots.price + IFFDIHCPKFE.upgradeSlots.priceGold;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (-56 - num) / -66;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = false;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				EKIDAFLLCNM.text = Localization.LocalizeFormat("Effect: ", num);
				JBGPDECEOOB.MIOOAOFMLIE(Singleton<OfferManager>.instance.LDBPLEDPPOP(IFFDIHCPKFE, (AKDLEDNDIEO)0));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(PMBLOMEGDDN));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(CDHICHLOPEN));
			}
			else
			{
				JBGPDECEOOB.LOINIDOGNCO();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(CDHICHLOPEN));
			}
		}
	}

	public void EPMIJIHLPOM()
	{
		TweenScale tweenScale = TweenScale.Begin(BKOOOBJDJHO.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 183f, new Vector3(589f, 1230f, 1631f), new Vector3(1991f, 1389f, 1448f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)4;
	}

	private void OLBPDALHLDG()
	{
		GuiScreenSingle<ArmyScreen>.instance.JGKBPDEKING(IFFDIHCPKFE);
	}

	private void JCGLGAPBGOM(bool FGHNCECHPPO = true)
	{
		if (GGMOJMMLEKA.gameObject.activeSelf)
		{
			if (FGHNCECHPPO)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
			}
			TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 427f, 491f).onFinished = HEIHKLDOACJ;
		}
	}

	private void DJHKDIMININ()
	{
		PKAGCKHJODA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GGMOJMMLEKA.gameObject.SetActive(true);
		OJBKADHPNFN = true;
	}

	private void GCOLDOGGPEF(UpgradeSlots.JLANLLEABDC MHHOHDBKCFK)
	{
		switch (MHHOHDBKCFK)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(15f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(205f);
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(0f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(180f);
			break;
		default:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(0f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(1f);
			break;
		}
	}

	private void GHCIIJEDFND()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Unit_Upgrade";
		}
		else
		{
			Singleton<Wallet>.instance.MBAFMBJFOKH(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
			GuiScreenSingle<ArmyScreen>.instance.BCLKDNPDOBI(IFFDIHCPKFE);
		}
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	public void NKPCPPKAIJO()
	{
		TweenScale tweenScale = TweenScale.Begin(BKOOOBJDJHO.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1306f, new Vector3(1624f, 748f, 516f), new Vector3(754f, 1348f, 55f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.Loop;
	}

	public void NBADGLOBLAO(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1340f)) ? 873f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Name", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = false;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1501f);
			if (num2 == 2 && (LPPOJMGOEFN.alpha == 222f || PPDGFFJLHKK.alpha > 724f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 510f, 1723f, 1377f);
				tweenAlpha.NumOfRepetitions = 0;
				tweenAlpha.onFinished = PHEPMMBBFKN;
			}
			if (num2 == 7 && (PPDGFFJLHKK.alpha == 855f || LPPOJMGOEFN.alpha > 1609f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 148f, 810f, 1278f);
				tweenAlpha2.NumOfRepetitions = 1;
				tweenAlpha2.onFinished = EGAHIJAHPCP;
			}
		}
	}

	private void FCJMIJEFGFB()
	{
		GuiScreenSingle<ArmyScreen>.instance.GFJONMCEGPE(IFFDIHCPKFE);
	}

	public void SelectUnit(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(154f + num);
		HFDPEIEGNKL.repositionNow = true;
		OMGFCIHDGIB.text = Localization.LocalizeFormat("ID_UNITDETAILEDSTATISTICS", IFFDIHCPKFE.unitName.ToUpper());
		IKNLLGBNMAB.text = Localization.LocalizeFormat("ID_ENERGYCOSTPERUNIT", Colours.stringWhite, IFFDIHCPKFE.upgradeSlots.totalPower);
		for (int i = 0; i < LHNGDJNBDKK.Length; i++)
		{
			LHNGDJNBDKK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.totalPower);
		}
		BHBAPKGBANI.repositionNow = true;
		BKMGNFFEJDB.text = Localization.LocalizeFormat("ID_DEPLOYCOOLDOWNPERUNIT", Colours.stringWhite, MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown));
		OMEMJGFOEPO.text = Localization.LocalizeFormat("ID_DEPLOYAMOUNT", Colours.stringWhite, IFFDIHCPKFE.upgradeSlots.spawns);
		bool flag = Singleton<GameVariables>.instance.isiPadResolution || IFFDIHCPKFE.upgradeSlots.bought;
		GDCNCNGOPIH.SetActive(flag);
		if (flag)
		{
			for (int j = 0; j < GOBKHCALGHA.Length; j++)
			{
				GOBKHCALGHA[j].SetActive(j < IFFDIHCPKFE.upgradeSlots.totalPower);
			}
			JGIGODHJNMO.text = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		}
	}

	private void PLJGLBMEHFF(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 1982f, 1434f, 1893f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void CGCAMPFGEMK(UpgradeSlots.JLANLLEABDC MHHOHDBKCFK)
	{
		switch (MHHOHDBKCFK)
		{
		case UpgradeSlots.JLANLLEABDC.Locked:
		case UpgradeSlots.JLANLLEABDC.UnitDelivering:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(933f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(1414f);
			break;
		case UpgradeSlots.JLANLLEABDC.NotBuyed:
		case UpgradeSlots.JLANLLEABDC.UnitDelivered:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(658f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(39f);
			break;
		default:
			OHKMIMMFHOG.center = OHKMIMMFHOG.center.ReplaceY(1574f);
			OHKMIMMFHOG.size = OHKMIMMFHOG.size.ReplaceY(256f);
			break;
		}
	}

	private void EKGLKPGNAAB()
	{
		if (!GGMOJMMLEKA.gameObject.activeSelf)
		{
			PKAGCKHJODA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			GGMOJMMLEKA.alpha1 = 1316f;
			GGMOJMMLEKA.gameObject.SetActive(true);
			OJBKADHPNFN = false;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 966f, 980f).onFinished = null;
	}

	private void LFAIFCNCIEM()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool flag = upgradeSlots.upgradeSlot.NNFCKENGOMF();
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool flag2 = upgradeSlots.upgradeSlotSpecial.BDAAHLLPPGN();
		bool flag3 = flag2 && upgradeSlots.upgradeSlotSpecial.isMaxUpgraded;
		int armyPowerX2 = upgradeSlots.upgradeSlotSpecial.armyPowerX10;
		bool isUnlocked = upgradeSlots.upgradeSlotElite.isUnlocked;
		bool flag4 = !isUnlocked || upgradeSlots.upgradeSlotElite.NNFCKENGOMF();
		bool flag5 = isUnlocked && upgradeSlots.upgradeSlotElite.isBought;
		int armyPowerX3 = upgradeSlots.upgradeSlotElite.armyPowerX10;
		bool flag6 = unitState == UpgradeSlots.JLANLLEABDC.Delivering || unitState == UpgradeSlots.JLANLLEABDC.Delivering || unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering;
		bool flag7 = flag || upgradeSlots.borrowed || flag6;
		bool flag8 = flag3 || !flag2 || upgradeSlots.borrowed || flag6;
		bool flag9 = !isUnlocked || flag4 || flag5;
		bool flag10 = unitState == UpgradeSlots.JLANLLEABDC.Active;
		bool flag11 = flag10 && upgradeSlots.upgradeSlot.FPDAMADLNGH();
		bool flag12 = flag10 && upgradeSlots.upgradeSlotSpecial.isDelivering;
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(flag2);
		JJKPAKGNMCP.gameObject.SetActive(flag2);
		if (flag2)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX2);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag5);
		EOEGBEKBJEM.gameObject.SetActive(flag5);
		EHNNKBIFOCP.gameObject.SetActive(flag5);
		if (flag5)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX3);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP, 1702f);
		}
		JANJPPELPBG.text = ((!allUpgradesBought) ? Localization.LocalizeFormat("ID_COMPLETED", MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max)) : string.Empty);
		FEJELKKFMPK.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX, 1973f));
		PMDCIMIFLMD.text = ((!flag8) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX, 1348f));
		APEPPPIIANB.text = ((!flag9) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX, 1852f));
		if (flag11)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 1149f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
		}
		if (flag12)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 108f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 0;
			tweenColor2.style = (UITweener.Style)7;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 112f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 1;
		tweenColor3.style = (UITweener.Style)3;
		GHKLHGDNAAC.gameObject.SetActive(flag);
		IKNDFOJPCJP.gameObject.SetActive(flag3);
		AGELGEBACHH.gameObject.SetActive(flag4);
		OEJAJOAJCNC(DOIHNIFPOLP, flag11, !flag11 && flag);
		MMJIFMCIAON(LHLNNPGFOKE, flag12, !flag12 && flag3);
		BLJMMDILOLC(FAMLAICPKAP, true, flag4);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 662f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 1058f)) ? 236f : (num2 + 1746f));
		num += PKAGCKHJODA.transform.localScale.x / 82f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag13 = upgradeSlots.unitSpecifics.Count > 1;
		bool flag14 = flag13 && upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag13);
		PDLEOCMNIJJ.text = ((!flag13) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[1].Value1));
		BAOHBIDKMHP.text = ((!flag13) ? string.Empty : ((!flag14) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[0].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[1].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 1143f)) ? Localization.Localize("Beanstalk Server Manager: NOT SENDING STARTER PACK DAYS") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 628f)) ? Localization.Localize("#AccoutCheck# check gpgs, but Id is not same {0} != {1}") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 1170f)) ? Localization.Localize("Unit delivery was : ") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 18f)) ? Localization.Localize("#AccoutCheck# Account exist check result NOT contain result message") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 1970f)) ? Localization.Localize("{0} {1}") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	public void HOAGOGKNCIH(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(1218f + num);
		HFDPEIEGNKL.repositionNow = false;
		OMGFCIHDGIB.text = Localization.LocalizeFormat("PlayerLevel", IFFDIHCPKFE.unitName.ToUpper());
		UILabel iKNLLGBNMAB = IKNLLGBNMAB;
		object[] array = new object[1];
		array[1] = Colours.stringWhite;
		array[0] = IFFDIHCPKFE.upgradeSlots.totalPower;
		iKNLLGBNMAB.text = Localization.LocalizeFormat("matchMadeGames", array);
		for (int i = 1; i < LHNGDJNBDKK.Length; i += 0)
		{
			LHNGDJNBDKK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.totalPower);
		}
		BHBAPKGBANI.repositionNow = true;
		UILabel bKMGNFFEJDB = BKMGNFFEJDB;
		object[] array2 = new object[2];
		array2[1] = Colours.stringWhite;
		array2[0] = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		bKMGNFFEJDB.text = Localization.LocalizeFormat("ID_COMPLETED", array2);
		UILabel oMEMJGFOEPO = OMEMJGFOEPO;
		object[] array3 = new object[7];
		array3[0] = Colours.stringWhite;
		array3[0] = IFFDIHCPKFE.upgradeSlots.spawns;
		oMEMJGFOEPO.text = Localization.LocalizeFormat("S", array3);
		bool flag = Singleton<GameVariables>.instance.isiPadResolution || IFFDIHCPKFE.upgradeSlots.bought;
		GDCNCNGOPIH.SetActive(flag);
		if (flag)
		{
			for (int j = 1; j < GOBKHCALGHA.Length; j++)
			{
				GOBKHCALGHA[j].SetActive(j < IFFDIHCPKFE.upgradeSlots.totalPower);
			}
			JGIGODHJNMO.text = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		}
	}

	private void AKBJLEMHAAJ(bool FGHNCECHPPO = true)
	{
		if (GGMOJMMLEKA.gameObject.activeSelf)
		{
			if (FGHNCECHPPO)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
			}
			TweenAlpha.Begin(GGMOJMMLEKA.gameObject, 851f, 490f).onFinished = JNLPBBINBEG;
		}
	}

	private void HNINMCGLEAK()
	{
		GuiScreenSingle<ArmyScreen>.instance.CNBHHOECDHP(IFFDIHCPKFE);
	}

	public void JINNELNKOGJ(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(1368f + num);
		HFDPEIEGNKL.repositionNow = false;
		UILabel oMGFCIHDGIB = OMGFCIHDGIB;
		object[] array = new object[1];
		array[1] = IFFDIHCPKFE.unitName.ToUpper();
		oMGFCIHDGIB.text = Localization.LocalizeFormat("GLM: OnDataLoaded - configurations.  is tutorial? ", array);
		UILabel iKNLLGBNMAB = IKNLLGBNMAB;
		object[] array2 = new object[2];
		array2[0] = Colours.stringWhite;
		array2[0] = IFFDIHCPKFE.upgradeSlots.totalPower;
		iKNLLGBNMAB.text = Localization.LocalizeFormat("_MIN_", array2);
		for (int i = 0; i < LHNGDJNBDKK.Length; i++)
		{
			LHNGDJNBDKK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.totalPower);
		}
		BHBAPKGBANI.repositionNow = true;
		UILabel bKMGNFFEJDB = BKMGNFFEJDB;
		object[] array3 = new object[1];
		array3[1] = Colours.stringWhite;
		array3[0] = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		bKMGNFFEJDB.text = Localization.LocalizeFormat("#AccoutCheck# account exist", array3);
		UILabel oMEMJGFOEPO = OMEMJGFOEPO;
		object[] array4 = new object[6];
		array4[1] = Colours.stringWhite;
		array4[1] = IFFDIHCPKFE.upgradeSlots.spawns;
		oMEMJGFOEPO.text = Localization.LocalizeFormat("tickets", array4);
		bool flag = !Singleton<GameVariables>.instance.isiPadResolution && IFFDIHCPKFE.upgradeSlots.bought;
		GDCNCNGOPIH.SetActive(flag);
		if (flag)
		{
			for (int j = 0; j < GOBKHCALGHA.Length; j += 0)
			{
				GOBKHCALGHA[j].SetActive(j < IFFDIHCPKFE.upgradeSlots.totalPower);
			}
			JGIGODHJNMO.text = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		}
	}

	public void MPNFAPKFNHL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BDDIDGFEJEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CPIOJNFMINL));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GJPIMMHDNMO));
		CHCFBDMGNLP.onReposition = MFEHBKOFKIP;
		HFDPEIEGNKL.onReposition = delegate
		{
			GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
			float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 20f;
			num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 20f + PKAGCKHJODA.transform.localScale.x / 2f;
			GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 4f, -24000f);
		};
		CKPLDDIPNAA.onReposition = delegate
		{
			float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
			CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
		};
		PAPFCAFPEJN();
	}

	private void EBADAABONCP()
	{
		PKAGCKHJODA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GGMOJMMLEKA.gameObject.SetActive(true);
		OJBKADHPNFN = false;
	}

	private void DKOGFLOOJCN()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 962f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	public void PCCFLEEAGEI()
	{
		JBGPDECEOOB.GGKCMHOGFPF();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		DJHKDIMININ();
	}

	private void JNLPBBINBEG(UITweener MGDJMGHCAAI)
	{
		PAPFCAFPEJN();
	}

	private void HGDDEHJJLNP()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool flag = upgradeSlots.upgradeSlot.IDFIPMFGPIM();
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool isBought = upgradeSlots.upgradeSlotSpecial.isBought;
		bool flag2 = !isBought || upgradeSlots.upgradeSlotSpecial.isMaxUpgraded;
		int fFHHEHHFOKJ = upgradeSlots.upgradeSlotSpecial.NDLFMKODJGG();
		bool flag3 = upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		bool flag4 = flag3 && upgradeSlots.upgradeSlotElite.IDFIPMFGPIM();
		bool flag5 = flag3 && upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		int fFHHEHHFOKJ2 = upgradeSlots.upgradeSlotElite.NDLFMKODJGG();
		bool flag6 = unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == (UpgradeSlots.JLANLLEABDC)7 || unitState == UpgradeSlots.JLANLLEABDC.Delivered;
		bool flag7 = flag || upgradeSlots.borrowed || flag6;
		bool flag8 = !flag2 && isBought && !upgradeSlots.borrowed && flag6;
		bool flag9 = flag3 && !flag4 && flag5;
		bool flag10 = unitState == (UpgradeSlots.JLANLLEABDC)7;
		bool flag11 = !flag10 || upgradeSlots.upgradeSlot.isDelivering;
		bool flag12 = !flag10 || upgradeSlots.upgradeSlotSpecial.LKJIJJFBNLD();
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(isBought);
		JJKPAKGNMCP.gameObject.SetActive(isBought);
		if (isBought)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag5);
		EOEGBEKBJEM.gameObject.SetActive(flag5);
		EHNNKBIFOCP.gameObject.SetActive(flag5);
		if (flag5)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP, 1917f);
		}
		UILabel jANJPPELPBG = JANJPPELPBG;
		string text;
		if (allUpgradesBought)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max);
			text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", array);
		}
		jANJPPELPBG.text = text;
		FEJELKKFMPK.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX, 500f));
		PMDCIMIFLMD.text = ((!flag8) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX, 347f));
		APEPPPIIANB.text = ((!flag9) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX, 1965f));
		if (flag11)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 667f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)7;
		}
		if (flag12)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 1889f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 0;
			tweenColor2.style = (UITweener.Style)7;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 1128f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 1;
		tweenColor3.style = (UITweener.Style)5;
		GHKLHGDNAAC.gameObject.SetActive(flag);
		IKNDFOJPCJP.gameObject.SetActive(flag2);
		AGELGEBACHH.gameObject.SetActive(flag4);
		AOMMBBJOMCE(DOIHNIFPOLP, flag11, !flag11 && flag);
		NMIDCFHHOOE(LHLNNPGFOKE, flag12, flag12 || flag2);
		KEFCFMIDHBF(FAMLAICPKAP, true, flag4);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 542f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 1617f)) ? 1289f : (num2 + 564f));
		num += PKAGCKHJODA.transform.localScale.x / 307f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag13 = upgradeSlots.unitSpecifics.Count > 0;
		bool flag14 = flag13 && upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag13);
		PDLEOCMNIJJ.text = ((!flag13) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[1].Value1));
		BAOHBIDKMHP.text = ((!flag13) ? string.Empty : ((!flag14) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[1].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[0].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 257f)) ? Localization.Localize("com/google/android/gms/common/ConnectionResult") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 1504f)) ? Localization.Localize("PlayWarcardsAssignment complate at: ") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 1412f)) ? Localization.Localize("Metal") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 1927f)) ? Localization.Localize("aYxLQ40XpBYemQhnRYMJg3VBd") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 764f)) ? Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC_TEXT") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	private void IEFJCBMAANN()
	{
		PKAGCKHJODA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GGMOJMMLEKA.gameObject.SetActive(true);
		OJBKADHPNFN = false;
	}

	public void NEINEPJDKCL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AJFCCNEPICJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FDLKALCGLCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OEFIGDDPNDK));
		CHCFBDMGNLP.onReposition = MFEHBKOFKIP;
		HFDPEIEGNKL.onReposition = JCPDBHAOMFC;
		CKPLDDIPNAA.onReposition = GDLIABMNKPF;
		IEFJCBMAANN();
	}

	private void DCLIHPMKOHD()
	{
		GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 1636f;
		num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 1912f + PKAGCKHJODA.transform.localScale.x / 332f;
		GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 1104f, 1966f);
	}

	public void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHGDHGCBOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OKLHOACLPDG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AIJMMNPBMPI));
		UIEventListener uIEventListener3 = UIEventListener.Get(OKDNHPCJFLB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LLJJAPNCABB));
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HFDPEIEGNKL.onReposition = delegate
		{
			GGMOJMMLEKA.transform.position = OKLHOACLPDG.transform.position;
			float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 20f;
			num += JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x + 20f + PKAGCKHJODA.transform.localScale.x / 2f;
			GGMOJMMLEKA.transform.localPosition = new Vector3(GGMOJMMLEKA.transform.localPosition.x + num, GGMOJMMLEKA.transform.localPosition.y + 4f, -24000f);
		};
		CKPLDDIPNAA.onReposition = KCPGPJPGJLC;
		DJHKDIMININ();
	}

	public void LLJJAPNCABB(GameObject KHAHPAKDIKE)
	{
		JCGLGAPBGOM(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	private void DBDOCENODBG(UITweener MGDJMGHCAAI)
	{
		NLDFGEFNLNL();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(1669f));
	}

	private void GBNAGBKIBML()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool isMaxUpgraded = upgradeSlots.upgradeSlot.isMaxUpgraded;
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool flag = upgradeSlots.upgradeSlotSpecial.BDAAHLLPPGN();
		bool flag2 = !flag || upgradeSlots.upgradeSlotSpecial.NNFCKENGOMF();
		int fFHHEHHFOKJ = upgradeSlots.upgradeSlotSpecial.NDLFMKODJGG();
		bool flag3 = upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		bool flag4 = flag3 && upgradeSlots.upgradeSlotElite.IDFIPMFGPIM();
		bool flag5 = flag3 && upgradeSlots.upgradeSlotElite.JFAELKHPLLA();
		int armyPowerX2 = upgradeSlots.upgradeSlotElite.armyPowerX10;
		bool flag6 = unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || unitState == UpgradeSlots.JLANLLEABDC.Delivered || unitState == UpgradeSlots.JLANLLEABDC.Delivered;
		bool flag7 = !isMaxUpgraded && !upgradeSlots.borrowed && flag6;
		bool flag8 = !flag2 && flag && !upgradeSlots.borrowed && flag6;
		bool flag9 = flag3 && !flag4 && flag5;
		bool flag10 = unitState == (UpgradeSlots.JLANLLEABDC)7;
		bool flag11 = flag10 && upgradeSlots.upgradeSlot.FPDAMADLNGH();
		bool flag12 = flag10 && upgradeSlots.upgradeSlotSpecial.LCFLGKPGEAG();
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(flag);
		JJKPAKGNMCP.gameObject.SetActive(flag);
		if (flag)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag5);
		EOEGBEKBJEM.gameObject.SetActive(flag5);
		EHNNKBIFOCP.gameObject.SetActive(flag5);
		if (flag5)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX2);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP, 1366f);
		}
		UILabel jANJPPELPBG = JANJPPELPBG;
		string text;
		if (allUpgradesBought)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max);
			text = Localization.LocalizeFormat(" NOT OK! Load army data from DB", array);
		}
		jANJPPELPBG.text = text;
		FEJELKKFMPK.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX, 1879f));
		PMDCIMIFLMD.text = ((!flag8) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX, 1197f));
		APEPPPIIANB.text = ((!flag9) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX, 766f));
		if (flag11)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 1408f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)8;
		}
		if (flag12)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 1424f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.style = (UITweener.Style)6;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 1819f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 0;
		tweenColor3.style = (UITweener.Style)7;
		GHKLHGDNAAC.gameObject.SetActive(isMaxUpgraded);
		IKNDFOJPCJP.gameObject.SetActive(flag2);
		AGELGEBACHH.gameObject.SetActive(flag4);
		NMIDCFHHOOE(DOIHNIFPOLP, flag11, flag11 || isMaxUpgraded);
		BLJMMDILOLC(LHLNNPGFOKE, flag12, !flag12 && flag2);
		MMJIFMCIAON(FAMLAICPKAP, false, flag4);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 1807f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 1907f)) ? 84f : (num2 + 1981f));
		num += PKAGCKHJODA.transform.localScale.x / 280f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag13 = upgradeSlots.unitSpecifics.Count > 1;
		bool flag14 = flag13 && upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag13);
		PDLEOCMNIJJ.text = ((!flag13) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[1].Value1));
		BAOHBIDKMHP.text = ((!flag13) ? string.Empty : ((!flag14) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[1].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[0].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 1149f)) ? Localization.Localize("_Alpha") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 1147f)) ? Localization.Localize(" 2") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 1791f)) ? Localization.Localize("leagueMembers") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 18f)) ? Localization.Localize("-") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 1272f)) ? Localization.Localize("On Accept Special Offer") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	[CompilerGenerated]
	private void GDGFBAHGJID(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	public void HJJEIDACGGA(GameObject KHAHPAKDIKE)
	{
		CMAJCOOIBDL(KHAHPAKDIKE == OKDNHPCJFLB.gameObject);
	}

	public void NOIMPGJIPPK(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1186f)) ? 1960f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_GC_LOGIN_TUTORIAL_TEXT", string.Empty, false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.instantUnitDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = false;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1130f);
		if (num2 == 6 && (LPPOJMGOEFN.alpha == 1701f || PPDGFFJLHKK.alpha > 1150f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 1547f, 401f, 1327f);
			tweenAlpha.NumOfRepetitions = 0;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 1 && (PPDGFFJLHKK.alpha == 1289f || LPPOJMGOEFN.alpha > 1984f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1523f, 1131f, 1926f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private void JGEAOHCLKPF()
	{
		UpgradeSlots upgradeSlots = IFFDIHCPKFE.upgradeSlots;
		UpgradeSlots.JLANLLEABDC unitState = upgradeSlots.unitState;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool isMaxUpgraded = upgradeSlots.upgradeSlot.isMaxUpgraded;
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		bool isBought = upgradeSlots.upgradeSlotSpecial.isBought;
		bool flag = !isBought || upgradeSlots.upgradeSlotSpecial.isMaxUpgraded;
		int armyPowerX2 = upgradeSlots.upgradeSlotSpecial.armyPowerX10;
		bool flag2 = upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		bool flag3 = flag2 && upgradeSlots.upgradeSlotElite.isMaxUpgraded;
		bool flag4 = flag2 && upgradeSlots.upgradeSlotElite.BDAAHLLPPGN();
		int armyPowerX3 = upgradeSlots.upgradeSlotElite.armyPowerX10;
		bool flag5 = unitState != UpgradeSlots.JLANLLEABDC.NotBuyed && unitState != (UpgradeSlots.JLANLLEABDC)8 && unitState == UpgradeSlots.JLANLLEABDC.Delivering;
		bool flag6 = !isMaxUpgraded && !upgradeSlots.borrowed && flag5;
		bool flag7 = !flag && isBought && !upgradeSlots.borrowed && flag5;
		bool flag8 = !flag2 || flag3 || flag4;
		bool flag9 = unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering;
		bool flag10 = !flag9 || upgradeSlots.upgradeSlot.FPDAMADLNGH();
		bool flag11 = !flag9 || upgradeSlots.upgradeSlotSpecial.FPDAMADLNGH();
		BKOOOBJDJHO.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX);
		CKAKEFGAIEN.gameObject.SetActive(isBought);
		JJKPAKGNMCP.gameObject.SetActive(isBought);
		if (isBought)
		{
			CKAKEFGAIEN.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX2);
			JJKPAKGNMCP.spriteName = IFFDIHCPKFE.abilityIcon;
		}
		IKBHFOFDEHK.gameObject.SetActive(flag4);
		EOEGBEKBJEM.gameObject.SetActive(flag4);
		EHNNKBIFOCP.gameObject.SetActive(flag4);
		if (flag4)
		{
			IKBHFOFDEHK.text = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX3);
			IFFDIHCPKFE.SetUpEliteIcon(EOEGBEKBJEM, EHNNKBIFOCP, 1674f);
		}
		UILabel jANJPPELPBG = JANJPPELPBG;
		string text;
		if (allUpgradesBought)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(armyPowerX10Max);
			text = Localization.LocalizeFormat("ActivityType", array);
		}
		jANJPPELPBG.text = text;
		FEJELKKFMPK.text = ((!flag6) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSlot - armyPowerX, 914f));
		PMDCIMIFLMD.text = ((!flag7) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX, 792f));
		APEPPPIIANB.text = ((!flag8) ? string.Empty : MEJMLNDFDBP.AKEMDPDJPLH(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX, 608f));
		if (flag10)
		{
			TweenColor component = FEJELKKFMPK.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			FEJELKKFMPK.color = Colours.greenDelivering;
		}
		else
		{
			FEJELKKFMPK.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(FEJELKKFMPK.gameObject, 126f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
		}
		if (flag11)
		{
			TweenColor component2 = PMDCIMIFLMD.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			PMDCIMIFLMD.color = Colours.greenDelivering;
		}
		else
		{
			PMDCIMIFLMD.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(PMDCIMIFLMD.gameObject, 531f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 0;
			tweenColor2.style = (UITweener.Style)3;
		}
		APEPPPIIANB.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(APEPPPIIANB.gameObject, 1864f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 0;
		tweenColor3.style = UITweener.Style.PingPong;
		GHKLHGDNAAC.gameObject.SetActive(isMaxUpgraded);
		IKNDFOJPCJP.gameObject.SetActive(flag);
		AGELGEBACHH.gameObject.SetActive(flag3);
		MMJIFMCIAON(DOIHNIFPOLP, flag10, flag10 || isMaxUpgraded);
		NMIDCFHHOOE(LHLNNPGFOKE, flag11, flag11 || flag);
		NMIDCFHHOOE(FAMLAICPKAP, true, flag3);
		float num = OPMJLGFLNJB.relativeSize.x * OPMJLGFLNJB.transform.localScale.x + 1344f;
		float val = OPMJLGFLNJB.transform.localPosition.x + num;
		float num2 = JANJPPELPBG.relativeSize.x * JANJPPELPBG.transform.localScale.x;
		num += ((!(num2 > 1948f)) ? 653f : (num2 + 1178f));
		num += PKAGCKHJODA.transform.localScale.x / 1210f;
		JANJPPELPBG.transform.localPosition = JANJPPELPBG.transform.localPosition.ReplaceX(val);
		PKAGCKHJODA.transform.localPosition = PKAGCKHJODA.transform.localPosition.ReplaceX(num);
		bool flag12 = upgradeSlots.unitSpecifics.Count > 1;
		bool flag13 = !flag12 || upgradeSlots.isSpecificTime;
		DCBCIOILMNB.gameObject.SetActive(flag12);
		PDLEOCMNIJJ.text = ((!flag12) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[0].Value1));
		BAOHBIDKMHP.text = ((!flag12) ? string.Empty : ((!flag13) ? MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.unitSpecifics[0].Value2) : MEJMLNDFDBP.DLDMHFBIEEO(upgradeSlots.unitSpecifics[0].Value2)));
		FKGOPBHJNCC.text = upgradeSlots.shotDamageName;
		IPBIOHCKOLD.text = ((!(upgradeSlots.damage >= 803f)) ? Localization.Localize("weapon0") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.damage));
		EKPANJBEICA.text = ((!(upgradeSlots.rateOfFire >= 1817f)) ? Localization.Localize("StepId") : MEJMLNDFDBP.KMDFJMCIFKA(upgradeSlots.rateOfFire));
		JMELHLPBHIH.text = ((!(upgradeSlots.accuracy >= 1594f)) ? Localization.Localize("WasShown") : MEJMLNDFDBP.JJBMMICPIIG(upgradeSlots.accuracy));
		MFANFFJGJDK.text = ((!(upgradeSlots.bulletSpeed >= 1776f)) ? Localization.Localize("squadMembers") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.bulletSpeed));
		HGJCLKGJLND.text = ((!(upgradeSlots.movementSpeed >= 1710f)) ? Localization.Localize("AchievementCompleted") : MEJMLNDFDBP.MAJBCINJAGF(upgradeSlots.movementSpeed));
	}

	private void CDNOPCMFBII()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 876f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void AGPCMJFLAIB()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Buy);
		int num2 = IFFDIHCPKFE.upgradeSlots.price * (55 - num) / -93;
		int num3 = IFFDIHCPKFE.upgradeSlots.priceGold * (91 - num) / 62;
		if (num > 0)
		{
			Debug.Log(string.Format("{0} {1}", num, IFFDIHCPKFE.upgradeSlots.GetSheetName()));
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num2, IFFDIHCPKFE.unitName);
			GuiElementSingle<InappScreen>.instance.PDANLJJAEDC("ID_TUTORIAL_GRENADE_UP");
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num3))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num3, IFFDIHCPKFE.unitName);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("com.mobcrush.mobcrush");
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (IFFDIHCPKFE.upgradeSlots.priceGold > 0)
			{
				Debug.Log("StartTime");
			}
			else if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering)
			{
				GuiScreenSingle<ArmyScreen>.instance.JGKBPDEKING(levelBehaviour);
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ECDBLKDFAMF(levelBehaviour, IFFDIHCPKFE, true);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.JOFEFBHDFIN(levelBehaviour, false);
			}
		}
		Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
		Singleton<Wallet>.instance.ALBICJOEMEF(num3);
		GuiScreenSingle<ArmyScreen>.instance.GAKDCJEFKEL(IFFDIHCPKFE, num);
	}

	private void NDNOOOOIMOJ()
	{
		UpgradeSlots.JLANLLEABDC unitState = IFFDIHCPKFE.upgradeSlots.unitState;
		EAKECIHGCLC();
		NIPGMDBNIOJ.SetActive(unitState == UpgradeSlots.JLANLLEABDC.Locked);
		UILabel nNIPNHJNHMO = NNIPNHJNHMO;
		object[] array = new object[3];
		array[1] = Colours.stringBlue;
		array[0] = IFFDIHCPKFE.upgradeSlots.unlockLevel.JICMGFNAHFL();
		nNIPNHJNHMO.text = Localization.LocalizeFormat("DogTagRefillTime", array);
		HCFJJCALLAF.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		BGPBNIJPOKM.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.price > 0);
		CODFFPODNEP.gameObject.SetActive(IFFDIHCPKFE.upgradeSlots.priceGold > 1);
		PMBLOMEGDDN();
		LNFLDPLGEJE.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		GPBMPAPOEOE.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LPPOJMGOEFN.alpha = 720f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 657f;
		JPJLKKJJFDB.SetActive(unitState == UpgradeSlots.JLANLLEABDC.NotBuyed);
		OHKMIMMFHOG.enabled = unitState == UpgradeSlots.JLANLLEABDC.Locked;
		DINDADNGPHG(unitState);
		HDHBKIFNBMF.SetActive(!NIPGMDBNIOJ.activeSelf && !HCFJJCALLAF.activeSelf && !LNFLDPLGEJE.activeSelf && JPJLKKJJFDB.activeSelf);
		HFDPEIEGNKL.repositionNow = false;
		HFDPEIEGNKL.transform.localPosition = HFDPEIEGNKL.transform.localPosition.ReplaceY((!HDHBKIFNBMF.activeSelf) ? 729f : 808f);
	}

	public void FPHFGANOINE(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(586f + num);
		HFDPEIEGNKL.repositionNow = true;
		OMGFCIHDGIB.text = Localization.LocalizeFormat("{0}-{1}", IFFDIHCPKFE.unitName.ToUpper());
		UILabel iKNLLGBNMAB = IKNLLGBNMAB;
		object[] array = new object[6];
		array[1] = Colours.stringWhite;
		array[0] = IFFDIHCPKFE.upgradeSlots.totalPower;
		iKNLLGBNMAB.text = Localization.LocalizeFormat("WasShown", array);
		for (int i = 1; i < LHNGDJNBDKK.Length; i += 0)
		{
			LHNGDJNBDKK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.totalPower);
		}
		BHBAPKGBANI.repositionNow = true;
		UILabel bKMGNFFEJDB = BKMGNFFEJDB;
		object[] array2 = new object[3];
		array2[0] = Colours.stringWhite;
		array2[0] = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		bKMGNFFEJDB.text = Localization.LocalizeFormat("1", array2);
		UILabel oMEMJGFOEPO = OMEMJGFOEPO;
		object[] array3 = new object[5];
		array3[1] = Colours.stringWhite;
		array3[0] = IFFDIHCPKFE.upgradeSlots.spawns;
		oMEMJGFOEPO.text = Localization.LocalizeFormat("Tickets", array3);
		bool flag = !Singleton<GameVariables>.instance.isiPadResolution && IFFDIHCPKFE.upgradeSlots.bought;
		GDCNCNGOPIH.SetActive(flag);
		if (flag)
		{
			for (int j = 0; j < GOBKHCALGHA.Length; j += 0)
			{
				GOBKHCALGHA[j].SetActive(j < IFFDIHCPKFE.upgradeSlots.totalPower);
			}
			JGIGODHJNMO.text = MEJMLNDFDBP.DLDMHFBIEEO(IFFDIHCPKFE.upgradeSlots.coolDown);
		}
	}
}
