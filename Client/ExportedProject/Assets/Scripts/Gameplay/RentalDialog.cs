using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RentalDialog : GuiElementSingle<RentalDialog>, PAIIOKBBHBC
{
	[Header("Header")]
	public UILabel OKMNFHNBMFA;

	[Header("Content")]
	public CircleProgress FHFIPPFJIAH;

	[Header("-Weapon")]
	public GameObject IPJGCHLDPNN;

	[Header("--Left")]
	public UILabel PPFCOELFDEI;

	public List<ProgressBarRecordRentalDialog> BOIMODJFNLJ;

	[Header("--Middle")]
	public UITexture NGHCDIMLGMO;

	[Header("--Right")]
	public UISprite KELBMDMFKGE;

	public UILabel NKFPAIBKJLN;

	public UITable PLAJLODCALI;

	public UILabel BKFGHNPPHEK;

	public GameObject BFIKGAJAFPD;

	public UILabel MCPCIHEBDDB;

	public UISprite AIFMBPEECBK;

	[Header("-Unit")]
	public GameObject DNCJEBDPBNA;

	[Header("--Left")]
	public UILabel JHONGBLEHLJ;

	public List<ProgressBarArmyRecordRentalDialog> NGMDHEGFIKE;

	public BoxCollider EEJLKNFPGNF;

	public UISprite AFJJKEIDCOO;

	public UIPanel CDJJCFKGGNM;

	public BoxCollider EKBKEMKCBOP;

	public UISprite GODMILJPCKC;

	public UITable JMMCCMGDLHC;

	public UISprite ODINPJHOLKD;

	public UILabel KCBMFPDBHMK;

	public UILabel NFMNIANAMBN;

	public GameObject IMNEFKFMJCL;

	[Header("--Middle")]
	public UISprite NACGOGCPIAH;

	[Header("--Right")]
	public GameObject BNDBPOEDIHJ;

	public UILabel AODBLOCIBAM;

	public UISprite JHNJAPJJKMD;

	public UISprite CJPLJHJPGAN;

	public UILabel ALEFOLOOMIH;

	public UILabel NENIJEEPPBJ;

	[Header("-Power Band")]
	public GameObject DPHDJEAHODH;

	[Header("--Left")]
	public UITable MIIKHEMFJPA;

	public UILabel PIHCIHILDBO;

	public UITable IDHLOENDLBL;

	public UILabel EJILDMGICPA;

	public UISprite HPFACGCBKCK;

	[Header("--Middle")]
	public UISprite JAJCFNOIBPM;

	[Header("--Right")]
	public UITable MKJPHJIIJDD;

	public UISprite NPLIAGMKPPK;

	public UILabel FBIBBNPGOCG;

	public GameObject FHFCNLIGFNB;

	public UILabel DCOFECNGCKC;

	[Header("Bottom")]
	public UIButton MPPDEAMFKMO;

	public UIButton KKIGLEGPJKG;

	public UIButton HDDBLHBCFHG;

	public UITable CHCFBDMGNLP;

	public UISprite BGPBNIJPOKM;

	public UISprite CODFFPODNEP;

	public UILabel LMCJKECEHGM;

	[Header("Early Unlock")]
	public GameObject JBFNFECHDCB;

	public UILabel AIELHBIOBJL;

	public UILabel AFJECEJJIJN;

	public UILabel DANIJOPJCKC;

	[Header("On Sale")]
	public GameObject GIPFEBBMKPM;

	public GameObject NNFBFMHGPEB;

	public UILabel EKIDAFLLCNM;

	public UITable JPBIHKIOCOI;

	public GameObject CLIMOEHAMBP;

	public GameObject OKOFOHHOGNO;

	public StrikethroughPrize JHHCNMFNDFN;

	public UILabel HLLCKBPCHBL;

	[Header("Animation")]
	public ArmyPowerAnimation GHGJLMAJJGG;

	private string KKJCAACJNHG;

	private int OKGNPCBCIDN;

	private DKHAOLDJLMK PPBJNCCFBJG;

	private bool BHCBHPPNNBI;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private LevelBehaviour IFFDIHCPKFE;

	private PlayerVisual FGIMNJOOAOB;

	private int ENEFFHEDLJJ;

	private int KKBPMPEBKIL;

	private bool GBKLFKHMFCP;

	private static Dictionary<DKHAOLDJLMK, Vector3> DJCLJHJKJOJ = new Dictionary<DKHAOLDJLMK, Vector3>
	{
		{
			DKHAOLDJLMK.ArmyUnit,
			new Vector3(820f, 200f, -5f)
		},
		{
			DKHAOLDJLMK.Weapon,
			new Vector3(440f, 200f, -5f)
		},
		{
			DKHAOLDJLMK.PlayerVisual,
			new Vector3(440f, 200f, -5f)
		}
	};

	private static Dictionary<DKHAOLDJLMK, Vector3> HEPEIFIKMGP = new Dictionary<DKHAOLDJLMK, Vector3>
	{
		{
			DKHAOLDJLMK.ArmyUnit,
			new Vector3(820f, -64f, -5f)
		},
		{
			DKHAOLDJLMK.Weapon,
			new Vector3(726f, 200f, -5f)
		},
		{
			DKHAOLDJLMK.PlayerVisual,
			new Vector3(726f, 200f, -5f)
		}
	};

	private void GJLOIIJKABA()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 507f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 632f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 1510f + 1133f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 875f);
	}

	private void EKINHJJEGDA()
	{
		IPJGCHLDPNN.SetActive(PPBJNCCFBJG == DKHAOLDJLMK.Weapon);
		DNCJEBDPBNA.SetActive(PPBJNCCFBJG == DKHAOLDJLMK.ArmyUnit);
		DPHDJEAHODH.SetActive(PPBJNCCFBJG == DKHAOLDJLMK.PlayerVisual);
		GIPFEBBMKPM.SetActive(BHCBHPPNNBI);
		JBFNFECHDCB.SetActive(value: false);
	}

	private void FODJOKGKDCJ()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 1264f;
		BMABFEBBOLF();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 219f, 168f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(1655f, 1418f, 882f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 882f, new Vector3(183f, 976f, 1782f), new Vector3(1079f, 407f, 1916f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void PBGFKBHDPKM()
	{
		KKIGLEGPJKG.gameObject.SetActive(!BHCBHPPNNBI);
		HDDBLHBCFHG.gameObject.SetActive(BHCBHPPNNBI);
		FHFCNLIGFNB.SetActive(BHCBHPPNNBI);
		if (BHCBHPPNNBI)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENT", OKGNPCBCIDN);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 58f, 20f, 130);
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(!GBKLFKHMFCP);
			LMCJKECEHGM.text = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			CHCFBDMGNLP.repositionNow = true;
			HLLCKBPCHBL.text = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			CLIMOEHAMBP.SetActive(!GBKLFKHMFCP);
			OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
			JHHCNMFNDFN.SetUpStrikeThrought();
			JPBIHKIOCOI.repositionNow = true;
		}
	}

	private void HEPHMHHFIEH()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		AFJJKEIDCOO.MakePixelPerfect();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.4f, new Vector3(478f, -180f, -5f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			CHOLLNEBBBE();
		};
	}

	private void DNLLEGPGDDB()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 85f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 224f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 1626f + 1226f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 1996f);
	}

	private void EHLPFIKFJJP()
	{
		MDAJJIAMDGH = LevelManager.instance.Weapon(KKJCAACJNHG);
		if (MDAJJIAMDGH == null)
		{
			Debug.LogError($"Weapon {KKJCAACJNHG} does not exists on client.");
			return;
		}
		KKBPMPEBKIL = MDAJJIAMDGH.price + MDAJJIAMDGH.priceGold;
		GBKLFKHMFCP = MDAJJIAMDGH.price > 0;
		ENEFFHEDLJJ = MEJMLNDFDBP.LJDADOKBBNA((float)(KKBPMPEBKIL * (100 - OKGNPCBCIDN)) / 100f);
		int displayNumber = MDAJJIAMDGH.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(MDAJJIAMDGH.BHCEOOLEHHG);
		PPFCOELFDEI.text = MDAJJIAMDGH.weaponName.ToUpper();
		BOIMODJFNLJ[0].InitializeStat(MDAJJIAMDGH, slotForCategory.weaponLevelsSetup, 0);
		BOIMODJFNLJ[1].InitializeStat(MDAJJIAMDGH, slotForCategory.weaponLevelsSetup, 1);
		BOIMODJFNLJ[2].InitializeStat(MDAJJIAMDGH, slotForCategory.weaponLevelsSetup, 2);
		BLKPDBBMICL();
		KELBMDMFKGE.spriteName = slotForCategory.iconName;
		KELBMDMFKGE.MakePixelPerfect();
		NKFPAIBKJLN.text = Localization.Localize(GameVariables.PIOLIEMNBGN[MDAJJIAMDGH.BHCEOOLEHHG]);
		int weaponPowerX = MDAJJIAMDGH.weaponPowerX10;
		int weaponPowerX2 = slotForCategory.weaponLevelsSetup.weaponPowerX10;
		int num = Mathf.Max(0, weaponPowerX - weaponPowerX2);
		Debug.Log($"Weapon Power This: {weaponPowerX},   Equipped {slotForCategory.weaponLevelsSetup.weaponName}: {weaponPowerX2},   Difference: {num}");
		BKFGHNPPHEK.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BFIKGAJAFPD.SetActive(num > 0);
		if (num > 0)
		{
			MCPCIHEBDDB.text = $"+{MEJMLNDFDBP.GMIPFLIEOHD(num)}";
			AIFMBPEECBK.transform.localScale = AIFMBPEECBK.transform.localScale.ReplaceX(MCPCIHEBDDB.relativeSize.x * MCPCIHEBDDB.transform.localScale.x + 16f);
		}
		PLAJLODCALI.repositionNow = true;
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 30f, 20f, 142);
		}
	}

	private void ABJIEJDOKDK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (HDDBLHBCFHG.gameObject.activeSelf)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("ID_STAT_GLOBALXP", KKJCAACJNHG, -1, -1);
			}
			HideDialog();
		}
	}

	private void HBMFAKAAPMP(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		bool flag = true;
		DKHAOLDJLMK pPBJNCCFBJG = PPBJNCCFBJG;
		if (pPBJNCCFBJG != DKHAOLDJLMK.ArmyUnit)
		{
			switch (pPBJNCCFBJG)
			{
			case DKHAOLDJLMK.ArmyUnit:
				flag = LevelManager.instance.BuyRentalUnit(IFFDIHCPKFE, ENEFFHEDLJJ);
				break;
			case (DKHAOLDJLMK)6:
				flag = LevelManager.instance.BuyRentalPowerBand(FGIMNJOOAOB, ENEFFHEDLJJ);
				break;
			}
		}
		else
		{
			flag = LevelManager.instance.BuyRentalWeapon(MDAJJIAMDGH, ENEFFHEDLJJ);
		}
		if (flag)
		{
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Items", KKJCAACJNHG, GBKLFKHMFCP ? ENEFFHEDLJJ : 0, GBKLFKHMFCP ? 1 : ENEFFHEDLJJ);
			HideDialog();
		}
	}

	private void POBALOBJLLP()
	{
		KKIGLEGPJKG.gameObject.SetActive(!BHCBHPPNNBI);
		HDDBLHBCFHG.gameObject.SetActive(BHCBHPPNNBI);
		FHFCNLIGFNB.SetActive(BHCBHPPNNBI);
		if (BHCBHPPNNBI)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[1] = OKGNPCBCIDN;
			eKIDAFLLCNM.text = Localization.LocalizeFormat("VipReward1", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1570f, 128f, -113);
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(GBKLFKHMFCP);
			LMCJKECEHGM.text = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			CHCFBDMGNLP.repositionNow = false;
			HLLCKBPCHBL.text = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			CLIMOEHAMBP.SetActive(!GBKLFKHMFCP);
			OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
			JHHCNMFNDFN.SetUpStrikeThrought();
			JPBIHKIOCOI.repositionNow = true;
		}
	}

	public GuiElement DOHCPGIDCII()
	{
		return this;
	}

	private void LNIINLAEPMC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			PNLMOHGMINK();
		}
		else
		{
			EIPBFFLKMIL();
		}
	}

	private void BMABFEBBOLF()
	{
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
			ODINPJHOLKD.MakePixelPerfect();
		}
	}

	private void AGOPCCBCBNC()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void EAHLPGMGFMD()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		JBMBJPJGJFB(eBFDAICCJAK);
	}

	private void DOGNEAHNICP()
	{
		KKIGLEGPJKG.gameObject.SetActive(!BHCBHPPNNBI);
		HDDBLHBCFHG.gameObject.SetActive(BHCBHPPNNBI);
		FHFCNLIGFNB.SetActive(BHCBHPPNNBI);
		if (BHCBHPPNNBI)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = OKGNPCBCIDN;
			eKIDAFLLCNM.text = Localization.LocalizeFormat("withPublisherSub2", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1760f, 1339f, 48);
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(!GBKLFKHMFCP);
			LMCJKECEHGM.text = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			CHCFBDMGNLP.repositionNow = false;
			HLLCKBPCHBL.text = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			CLIMOEHAMBP.SetActive(!GBKLFKHMFCP);
			OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
			JHHCNMFNDFN.NFLJDPDCPIJ();
			JPBIHKIOCOI.repositionNow = true;
		}
	}

	private void NNOIIKEACMH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void FLNCHFEDOJA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			bool flag = true;
			switch (PPBJNCCFBJG)
			{
			case DKHAOLDJLMK.Weapon:
				flag = LevelManager.instance.BuyRentalWeapon(MDAJJIAMDGH, ENEFFHEDLJJ);
				break;
			case DKHAOLDJLMK.ArmyUnit:
				flag = LevelManager.instance.BuyRentalUnit(IFFDIHCPKFE, ENEFFHEDLJJ);
				break;
			case (DKHAOLDJLMK)6:
				flag = LevelManager.instance.BuyRentalPowerBand(FGIMNJOOAOB, ENEFFHEDLJJ);
				break;
			}
			if (flag)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("UnitTutorial", KKJCAACJNHG, GBKLFKHMFCP ? ENEFFHEDLJJ : 0, GBKLFKHMFCP ? 1 : ENEFFHEDLJJ);
				HideDialog();
			}
		}
	}

	private void GPIINBDGFFE()
	{
		FGIMNJOOAOB = CamosManager.instance.GetPowerBand(KKJCAACJNHG);
		if (FGIMNJOOAOB == null)
		{
			Debug.LogError(string.Format("warcards", KKJCAACJNHG));
			return;
		}
		KKBPMPEBKIL = FGIMNJOOAOB.DPKHLANDNPK() + FGIMNJOOAOB.CEPPEMPPAHE();
		GBKLFKHMFCP = FGIMNJOOAOB.priceWarbucks > 1;
		ENEFFHEDLJJ = MEJMLNDFDBP.LJDADOKBBNA((float)(KKBPMPEBKIL * (-65 - OKGNPCBCIDN)) / 223f);
		int num = FGIMNJOOAOB.CIFLPEFJJFP().ABCCINJGPGD();
		bool flag = num > LevelManager.instance.currentLevel.MHAOKJCDIOL();
		PIHCIHILDBO.text = FGIMNJOOAOB.name.ToUpperInvariant();
		IDHLOENDLBL.repositionNow = true;
		HPFACGCBKCK.spriteName = FGIMNJOOAOB.LIIOLLAAHGB();
		HPFACGCBKCK.MakePixelPerfect();
		HPFACGCBKCK.transform.localScale = HPFACGCBKCK.transform.localScale.MultiplyXY(604f);
		HPFACGCBKCK.color = FGIMNJOOAOB.decalMiniIconColor;
		EJILDMGICPA.text = FGIMNJOOAOB.decalValueString;
		JAJCFNOIBPM.spriteName = FGIMNJOOAOB.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(1730f);
		MKJPHJIIJDD.repositionNow = true;
		NPLIAGMKPPK.spriteName = FGIMNJOOAOB.decalMiniIcon;
		NPLIAGMKPPK.MakePixelPerfect();
		NPLIAGMKPPK.color = FGIMNJOOAOB.GPDIGNGOAEH();
		FBIBBNPGOCG.text = ((FGIMNJOOAOB.decalType != 0) ? string.Empty : "Message: squad player ended game -> get squad details to sync exp and stats") + "ExplodeDamageMax" + FGIMNJOOAOB.description;
		UILabel dCOFECNGCKC = DCOFECNGCKC;
		object[] array = new object[0];
		array[0] = Colours.stringBlue + MEJMLNDFDBP.MAJBCINJAGF((float)FGIMNJOOAOB.timeActive / 1169f);
		dCOFECNGCKC.text = Localization.LocalizeFormat("ID_GUI_TIMEXPBONUS", array);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("ID_VISUALRARITY3", Localization.Localize("HeartPrice"), num);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 1956f, 1370f, -157);
		}
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	[CompilerGenerated]
	private void BEANPPLCGNN(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void CHOLLNEBBBE()
	{
		if (DNCJEBDPBNA.activeSelf)
		{
			AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			AFJJKEIDCOO.MakePixelPerfect();
		}
		CDJJCFKGGNM.gameObject.SetActive(value: false);
	}

	private void MLKCMOIMKJM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<BeanstalkServerManager>.instance.NCKODKEJGHD(FPEPEFGHCGG: false);
			switch (PPBJNCCFBJG)
			{
			case DKHAOLDJLMK.Weapon:
				MDAJJIAMDGH.tryOutWeapon = false;
				LevelManager.instance.EquipRentalWeapon(MDAJJIAMDGH, onlyTry: true);
				break;
			case DKHAOLDJLMK.ArmyUnit:
				IFFDIHCPKFE.upgradeSlots.borrowed = true;
				LevelManager.instance.TryRentalUnit(IFFDIHCPKFE);
				break;
			case (DKHAOLDJLMK)8:
				FGIMNJOOAOB.EFPABPANAJE(IDEBKDPMPGM: true);
				LevelManager.instance.EquipRentalVisual(FGIMNJOOAOB, onlyTry: true);
				break;
			}
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("BUDDY_CARD_BOT", KKJCAACJNHG, -1, -1);
			HideDialog();
		}
	}

	private void JBMBJPJGJFB(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1211f * Singleton<GuiTexureAssets>.instance.NEKAPIDHBNC());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void PEDJFACMHHF(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(FPEPEFGHCGG: false);
		DKHAOLDJLMK pPBJNCCFBJG = PPBJNCCFBJG;
		if (pPBJNCCFBJG != DKHAOLDJLMK.ArmyUnit)
		{
			switch (pPBJNCCFBJG)
			{
			case DKHAOLDJLMK.ArmyUnit:
				IFFDIHCPKFE.upgradeSlots.borrowed = true;
				LevelManager.instance.TryRentalUnit(IFFDIHCPKFE);
				break;
			case DKHAOLDJLMK.Weapon:
				FGIMNJOOAOB.EFPABPANAJE(IDEBKDPMPGM: true);
				LevelManager.instance.EquipRentalVisual(FGIMNJOOAOB, onlyTry: true);
				break;
			}
		}
		else
		{
			MDAJJIAMDGH.tryOutWeapon = false;
			LevelManager.instance.EquipRentalWeapon(MDAJJIAMDGH, onlyTry: false);
		}
		Singleton<EventTrackingManager>.instance.RegisterRentalEvent(", ", KKJCAACJNHG, -1, -1);
		HideDialog();
	}

	private void OIEOMEOBMNA()
	{
		IPJGCHLDPNN.SetActive(PPBJNCCFBJG == DKHAOLDJLMK.ArmyUnit);
		DNCJEBDPBNA.SetActive(PPBJNCCFBJG == DKHAOLDJLMK.Weapon);
		DPHDJEAHODH.SetActive(PPBJNCCFBJG == (DKHAOLDJLMK)3);
		GIPFEBBMKPM.SetActive(BHCBHPPNNBI);
		JBFNFECHDCB.SetActive(value: false);
	}

	private void IOLDAPCLHMA(GameObject KHAHPAKDIKE)
	{
		if (!BKIGLABDGCP())
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(FPEPEFGHCGG: false);
		DKHAOLDJLMK pPBJNCCFBJG = PPBJNCCFBJG;
		if (pPBJNCCFBJG != DKHAOLDJLMK.ArmyUnit)
		{
			if (pPBJNCCFBJG != DKHAOLDJLMK.ArmyUnit)
			{
				if (pPBJNCCFBJG == DKHAOLDJLMK.ArmyUnit)
				{
					FGIMNJOOAOB.tryOutVisual = false;
					LevelManager.instance.EquipRentalVisual(FGIMNJOOAOB, onlyTry: false);
				}
			}
			else
			{
				IFFDIHCPKFE.upgradeSlots.borrowed = false;
				LevelManager.instance.TryRentalUnit(IFFDIHCPKFE);
			}
		}
		else
		{
			MDAJJIAMDGH.tryOutWeapon = true;
			LevelManager.instance.EquipRentalWeapon(MDAJJIAMDGH, onlyTry: false);
		}
		Singleton<EventTrackingManager>.instance.RegisterRentalEvent("gold", KKJCAACJNHG, -1, -1);
		HideDialog();
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JFBLFGBILOO));
		UIEventListener uIEventListener2 = UIEventListener.Get(KKIGLEGPJKG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGNOIKAFNGI));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FLNCHFEDOJA));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = LNIINLAEPMC;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HEPHMHHFIEH();
		};
		CHCFBDMGNLP.onReposition = BFEOEKANJBP;
		JPBIHKIOCOI.onReposition = delegate
		{
			float val = 770f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
			JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
		};
		JMMCCMGDLHC.onReposition = GJLOIIJKABA;
		IDHLOENDLBL.onReposition = delegate
		{
			MIIKHEMFJPA.repositionNow = true;
		};
	}

	public void ShowRentalDialog(string NCPADPILKLG, int JFHIOHMMNDI, DKHAOLDJLMK POLJGPMHFBF, bool JIFJOMPDNPN)
	{
		KKJCAACJNHG = NCPADPILKLG;
		OKGNPCBCIDN = JFHIOHMMNDI;
		PPBJNCCFBJG = POLJGPMHFBF;
		BHCBHPPNNBI = JIFJOMPDNPN;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(KKIGLEGPJKG.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LOOKELFNBAB));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (CDJJCFKGGNM.gameObject.activeSelf)
			{
				HEPHMHHFIEH();
			}
			else
			{
				EIPBFFLKMIL();
			}
		};
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HEPHMHHFIEH();
		};
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		JPBIHKIOCOI.onReposition = delegate
		{
			float val = 770f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
			JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
		};
		JMMCCMGDLHC.onReposition = HPPPHFIJMMN;
		IDHLOENDLBL.onReposition = delegate
		{
			MIIKHEMFJPA.repositionNow = true;
		};
	}

	private void CIKNOKPPGHK()
	{
		FGIMNJOOAOB = CamosManager.instance.GetPowerBand(KKJCAACJNHG);
		if (FGIMNJOOAOB == null)
		{
			Debug.LogError(string.Format("ID_WARNING_ERRORCLAIMEVENT", KKJCAACJNHG));
			return;
		}
		KKBPMPEBKIL = FGIMNJOOAOB.priceWarbucks + FGIMNJOOAOB.priceGold;
		GBKLFKHMFCP = FGIMNJOOAOB.DPKHLANDNPK() > 0;
		ENEFFHEDLJJ = MEJMLNDFDBP.LJDADOKBBNA((float)(KKBPMPEBKIL * (57 - OKGNPCBCIDN)) / 524f);
		int displayNumber = FGIMNJOOAOB.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.ABCCINJGPGD();
		PIHCIHILDBO.text = FGIMNJOOAOB.name.ToUpperInvariant();
		IDHLOENDLBL.repositionNow = true;
		HPFACGCBKCK.spriteName = FGIMNJOOAOB.decalMiniIcon;
		HPFACGCBKCK.MakePixelPerfect();
		HPFACGCBKCK.transform.localScale = HPFACGCBKCK.transform.localScale.MultiplyXY(451f);
		HPFACGCBKCK.color = FGIMNJOOAOB.GPDIGNGOAEH();
		EJILDMGICPA.text = FGIMNJOOAOB.FKIHLEGENCE();
		JAJCFNOIBPM.spriteName = FGIMNJOOAOB.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(1113f);
		MKJPHJIIJDD.repositionNow = false;
		NPLIAGMKPPK.spriteName = FGIMNJOOAOB.DEAIJJIAEFP();
		NPLIAGMKPPK.MakePixelPerfect();
		NPLIAGMKPPK.color = FGIMNJOOAOB.decalMiniIconColor;
		FBIBBNPGOCG.text = ((FGIMNJOOAOB.decalType != 0) ? string.Empty : "Vip days = ") + "com/google/android/gms/common/ConnectionResult" + FGIMNJOOAOB.IGGMAMDJBNB();
		UILabel dCOFECNGCKC = DCOFECNGCKC;
		object[] array = new object[0];
		array[1] = Colours.stringBlue + MEJMLNDFDBP.MAJBCINJAGF((float)FGIMNJOOAOB.timeActive / 903f);
		dCOFECNGCKC.text = Localization.LocalizeFormat("'ID_MONTH_'0", array);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("Joined room", Localization.Localize("r"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 1948f, 1290f, -34);
		}
	}

	private void HLILIDEAFNC()
	{
		IFFDIHCPKFE = LevelManager.instance.Unit(KKJCAACJNHG);
		if (IFFDIHCPKFE == null)
		{
			Debug.LogError($"Unit {KKJCAACJNHG} does not exists on client.");
			return;
		}
		KKBPMPEBKIL = IFFDIHCPKFE.upgradeSlots.price + IFFDIHCPKFE.upgradeSlots.priceGold;
		GBKLFKHMFCP = IFFDIHCPKFE.upgradeSlots.price > 0;
		ENEFFHEDLJJ = MEJMLNDFDBP.LJDADOKBBNA((float)(KKBPMPEBKIL * (100 - OKGNPCBCIDN)) / 100f);
		int displayNumber = IFFDIHCPKFE.upgradeSlots.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		JHONGBLEHLJ.text = IFFDIHCPKFE.unitName;
		NGMDHEGFIKE[0].InitializeStat(IFFDIHCPKFE);
		NGMDHEGFIKE[1].InitializeStat(IFFDIHCPKFE, JFPCEOFJKIG: false);
		NGMDHEGFIKE[2].InitializeAbility(IFFDIHCPKFE);
		BMABFEBBOLF();
		KCBMFPDBHMK.text = IFFDIHCPKFE.unitAbilityName;
		NFMNIANAMBN.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		JMMCCMGDLHC.repositionNow = true;
		NACGOGCPIAH.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		float multiplier = Mathf.Min(500f / NACGOGCPIAH.transform.localScale.x, 460f / NACGOGCPIAH.transform.localScale.y);
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = 154f + NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(num);
		BNDBPOEDIHJ.transform.localPosition = BNDBPOEDIHJ.transform.localPosition.ReplaceY(-180f + num);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 30f, 20f, 142);
		}
	}

	private void HPPPHFIJMMN()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 30f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 60f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 2f + 30f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 60f);
	}

	public override void InitGUIValues()
	{
		GGJNEGPBDHL();
		GHGJLMAJJGG.InitializeAlphaZero();
		CHOLLNEBBBE();
		if (!BHCBHPPNNBI)
		{
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Display_Rental", KKJCAACJNHG, -1, -1);
		}
	}

	public virtual void ACLOLICAKGL()
	{
		BENAHCDEKCM();
		GHGJLMAJJGG.NPGJCLKDCGA();
		CHOLLNEBBBE();
		if (!BHCBHPPNNBI)
		{
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("-ABILITYMAXDESC", KKJCAACJNHG, -1, -1);
		}
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void JFBLFGBILOO(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (HDDBLHBCFHG.gameObject.activeSelf)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("ID_ERROR_SQUADNAME_PROFANITY", KKJCAACJNHG, -1, -1);
			}
			HideDialog();
		}
	}

	private void KPDMPLEAEGO()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void FNDHHAAEBBA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (HDDBLHBCFHG.gameObject.activeSelf)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("registerCustomProfileNumber", KKJCAACJNHG, -1, -1);
			}
			HideDialog();
		}
	}

	private void NCFBEJPMHPL(UITweener MGDJMGHCAAI)
	{
		CHOLLNEBBBE();
	}

	private void DKOGFLOOJCN(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			HEPHMHHFIEH();
		}
		else
		{
			EHODAOHFDGL();
		}
	}

	public GuiElement HIDNIFBOPAL()
	{
		return this;
	}

	private void BENAHCDEKCM()
	{
		object[] array = new object[4];
		array[0] = PPBJNCCFBJG;
		array[0] = KKJCAACJNHG;
		array[4] = OKGNPCBCIDN;
		array[2] = BHCBHPPNNBI;
		Debug.Log(string.Format("Id", array));
		OKMNFHNBMFA.text = ((!BHCBHPPNNBI) ? Localization.Localize("NextWithdraw") : Localization.Localize("ID_GC_LOGOUT_TITLE"));
		OKMNFHNBMFA.color = ((!BHCBHPPNNBI) ? Colours.blue : Colours.goldTier);
		FHFIPPFJIAH.HHNICOADMPB(333f);
		EIPPIEOKGBE();
		switch (PPBJNCCFBJG)
		{
		case DKHAOLDJLMK.Weapon:
			EHLPFIKFJJP();
			break;
		case DKHAOLDJLMK.ArmyUnit:
			HLILIDEAFNC();
			break;
		case (DKHAOLDJLMK)4:
			DNKFJKHMLAE();
			break;
		}
		NNFBFMHGPEB.transform.localPosition = DJCLJHJKJOJ[PPBJNCCFBJG];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[PPBJNCCFBJG];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize(" AND ");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 1036f, 487f, 13);
			DANIJOPJCKC.text = Localization.Localize("ID_READYTIME");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 650f, 585f, 130);
		}
		DOJOPEJBCMJ();
	}

	private void EIPBFFLKMIL()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: true);
		CDJJCFKGGNM.alpha1 = 0.005f;
		BMABFEBBOLF();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 0.4f, 1f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(478f, -180f, -5f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.25f, new Vector3(478f, -200f, -5f), new Vector3(478f, -170f, -5f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void KPKMFMBFPHF()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 240f;
		BJDAFCHEKAI();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 1450f, 1341f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(1923f, 951f, 1956f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 80f, new Vector3(1149f, 65f, 352f), new Vector3(185f, 1706f, 1854f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = OOODHAMABPL;
	}

	private void IDJMEDOGFGI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			bool flag = false;
			switch (PPBJNCCFBJG)
			{
			case DKHAOLDJLMK.Weapon:
				flag = LevelManager.instance.BuyRentalWeapon(MDAJJIAMDGH, ENEFFHEDLJJ);
				break;
			case DKHAOLDJLMK.ArmyUnit:
				flag = LevelManager.instance.BuyRentalUnit(IFFDIHCPKFE, ENEFFHEDLJJ);
				break;
			case DKHAOLDJLMK.PlayerVisual:
				flag = LevelManager.instance.BuyRentalPowerBand(FGIMNJOOAOB, ENEFFHEDLJJ);
				break;
			}
			if (flag)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Accept_Rental", KKJCAACJNHG, GBKLFKHMFCP ? ENEFFHEDLJJ : 0, (!GBKLFKHMFCP) ? ENEFFHEDLJJ : 0);
				HideDialog();
			}
		}
	}

	private void PNLMOHGMINK()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		AFJJKEIDCOO.MakePixelPerfect();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 510f, 1639f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 159f, new Vector3(1623f, 1723f, 509f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = NCFBEJPMHPL;
	}

	private void JDFHFNGHCLG()
	{
		FGIMNJOOAOB = CamosManager.instance.GetPowerBand(KKJCAACJNHG);
		if (FGIMNJOOAOB == null)
		{
			Debug.LogError($"Power Band {KKJCAACJNHG} does not exists on client.");
			return;
		}
		KKBPMPEBKIL = FGIMNJOOAOB.priceWarbucks + FGIMNJOOAOB.priceGold;
		GBKLFKHMFCP = FGIMNJOOAOB.priceWarbucks > 0;
		ENEFFHEDLJJ = MEJMLNDFDBP.LJDADOKBBNA((float)(KKBPMPEBKIL * (100 - OKGNPCBCIDN)) / 100f);
		int displayNumber = FGIMNJOOAOB.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		PIHCIHILDBO.text = FGIMNJOOAOB.name.ToUpperInvariant();
		IDHLOENDLBL.repositionNow = true;
		HPFACGCBKCK.spriteName = FGIMNJOOAOB.decalMiniIcon;
		HPFACGCBKCK.MakePixelPerfect();
		HPFACGCBKCK.transform.localScale = HPFACGCBKCK.transform.localScale.MultiplyXY(1.5f);
		HPFACGCBKCK.color = FGIMNJOOAOB.decalMiniIconColor;
		EJILDMGICPA.text = FGIMNJOOAOB.decalValueString;
		JAJCFNOIBPM.spriteName = FGIMNJOOAOB.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(1.5f);
		MKJPHJIIJDD.repositionNow = true;
		NPLIAGMKPPK.spriteName = FGIMNJOOAOB.decalMiniIcon;
		NPLIAGMKPPK.MakePixelPerfect();
		NPLIAGMKPPK.color = FGIMNJOOAOB.decalMiniIconColor;
		FBIBBNPGOCG.text = ((FGIMNJOOAOB.decalType != 0) ? string.Empty : " ") + "    " + FGIMNJOOAOB.description;
		DCOFECNGCKC.text = Localization.LocalizeFormat("ID_GUI_POWERBANDON", Colours.stringBlue + MEJMLNDFDBP.MAJBCINJAGF((float)FGIMNJOOAOB.timeActive / 3600f));
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 30f, 20f, 142);
		}
	}

	private void OOODHAMABPL(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 454f, new Vector3(1979f, 1306f, 1152f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = null;
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.9255f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void CCDKBPFONON(GameObject KHAHPAKDIKE)
	{
		if (!BKIGLABDGCP())
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(FPEPEFGHCGG: true);
		DKHAOLDJLMK pPBJNCCFBJG = PPBJNCCFBJG;
		switch (pPBJNCCFBJG)
		{
		default:
			if (pPBJNCCFBJG == DKHAOLDJLMK.Weapon)
			{
				FGIMNJOOAOB.tryOutVisual = false;
				LevelManager.instance.EquipRentalVisual(FGIMNJOOAOB, onlyTry: true);
			}
			break;
		case DKHAOLDJLMK.Weapon:
			MDAJJIAMDGH.tryOutWeapon = false;
			LevelManager.instance.EquipRentalWeapon(MDAJJIAMDGH, onlyTry: true);
			break;
		case DKHAOLDJLMK.ArmyUnit:
			IFFDIHCPKFE.upgradeSlots.borrowed = true;
			LevelManager.instance.TryRentalUnit(IFFDIHCPKFE);
			break;
		}
		Singleton<EventTrackingManager>.instance.RegisterRentalEvent("ID_COMPLETED", KKJCAACJNHG, -1, -1);
		HideDialog();
	}

	private void LJNAKBBJIIC()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 356f;
		BJDAFCHEKAI();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 1586f, 577f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(223f, 1234f, 835f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1430f, new Vector3(1212f, 791f, 198f), new Vector3(1982f, 1286f, 1324f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		CHOLLNEBBBE();
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GHGJLMAJJGG.StopAllAnimations();
		NNOIIKEACMH();
	}

	private void DNKFJKHMLAE()
	{
		FGIMNJOOAOB = CamosManager.instance.GetPowerBand(KKJCAACJNHG);
		if (FGIMNJOOAOB == null)
		{
			Debug.LogError(string.Format("Player_Had_To_Select_Grenade", KKJCAACJNHG));
			return;
		}
		KKBPMPEBKIL = FGIMNJOOAOB.DPKHLANDNPK() + FGIMNJOOAOB.IIBGJDGPPCL();
		GBKLFKHMFCP = FGIMNJOOAOB.DPKHLANDNPK() > 1;
		ENEFFHEDLJJ = MEJMLNDFDBP.LJDADOKBBNA((float)(KKBPMPEBKIL * (-30 - OKGNPCBCIDN)) / 1274f);
		int num = FGIMNJOOAOB.CIFLPEFJJFP().NPOEMAMPNEP();
		bool flag = num > LevelManager.instance.currentLevel.KADNNBCOGGL();
		PIHCIHILDBO.text = FGIMNJOOAOB.name.ToUpperInvariant();
		IDHLOENDLBL.repositionNow = false;
		HPFACGCBKCK.spriteName = FGIMNJOOAOB.DEAIJJIAEFP();
		HPFACGCBKCK.MakePixelPerfect();
		HPFACGCBKCK.transform.localScale = HPFACGCBKCK.transform.localScale.MultiplyXY(1725f);
		HPFACGCBKCK.color = FGIMNJOOAOB.decalMiniIconColor;
		EJILDMGICPA.text = FGIMNJOOAOB.JIHLMBOBKHL();
		JAJCFNOIBPM.spriteName = FGIMNJOOAOB.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(438f);
		MKJPHJIIJDD.repositionNow = true;
		NPLIAGMKPPK.spriteName = FGIMNJOOAOB.decalMiniIcon;
		NPLIAGMKPPK.MakePixelPerfect();
		NPLIAGMKPPK.color = FGIMNJOOAOB.decalMiniIconColor;
		FBIBBNPGOCG.text = ((FGIMNJOOAOB.decalType != 0) ? string.Empty : "ID_LEAGUE12") + "Scraps" + FGIMNJOOAOB.description;
		DCOFECNGCKC.text = Localization.LocalizeFormat("com/google/android/gms/common/ConnectionResult", Colours.stringBlue + MEJMLNDFDBP.MAJBCINJAGF((float)FGIMNJOOAOB.timeActive / 143f));
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("Shotgunner spawned", Localization.Localize("DOWNLOADBTN"), num);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 586f, 353f, -183);
		}
	}

	private void HFGGAEILLEM(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			PNLMOHGMINK();
		}
		else
		{
			FODJOKGKDCJ();
		}
	}

	private void IPJHOKJIMAI()
	{
		MIIKHEMFJPA.repositionNow = true;
	}

	private void PPEKNCGDMLA()
	{
		if (DNCJEBDPBNA.activeSelf)
		{
			AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			AFJJKEIDCOO.MakePixelPerfect();
		}
		CDJJCFKGGNM.gameObject.SetActive(value: false);
	}

	private void BJDAFCHEKAI()
	{
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
			ODINPJHOLKD.MakePixelPerfect();
		}
	}

	private void BFEOEKANJBP()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 858f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void ONJPGIAMBLM()
	{
		KKIGLEGPJKG.gameObject.SetActive(!BHCBHPPNNBI);
		HDDBLHBCFHG.gameObject.SetActive(BHCBHPPNNBI);
		FHFCNLIGFNB.SetActive(BHCBHPPNNBI);
		if (BHCBHPPNNBI)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = OKGNPCBCIDN;
			eKIDAFLLCNM.text = Localization.LocalizeFormat("Processing the request Timed Out!", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1351f, 26f, -195);
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(GBKLFKHMFCP);
			LMCJKECEHGM.text = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			CHCFBDMGNLP.repositionNow = false;
			HLLCKBPCHBL.text = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			CLIMOEHAMBP.SetActive(!GBKLFKHMFCP);
			OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
			JHHCNMFNDFN.DMPLCNEPDLM();
			JPBIHKIOCOI.repositionNow = false;
		}
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HEPHMHHFIEH();
	}

	public virtual void IHLGGCNHCDG()
	{
		BENAHCDEKCM();
		GHGJLMAJJGG.InitializeAlphaZero();
		PPEKNCGDMLA();
		if (!BHCBHPPNNBI)
		{
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("ID_READYTIME", KKJCAACJNHG, -1, -1);
		}
	}

	private void KGFEBJELEAF(UITweener MGDJMGHCAAI)
	{
		CHOLLNEBBBE();
	}

	private void EIPPIEOKGBE()
	{
		IPJGCHLDPNN.SetActive(PPBJNCCFBJG == DKHAOLDJLMK.Weapon);
		DNCJEBDPBNA.SetActive(PPBJNCCFBJG == DKHAOLDJLMK.ArmyUnit);
		DPHDJEAHODH.SetActive(PPBJNCCFBJG == (DKHAOLDJLMK)5);
		GIPFEBBMKPM.SetActive(BHCBHPPNNBI);
		JBFNFECHDCB.SetActive(value: true);
	}

	private void INCABCNCHKM()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 1618f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 1538f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 115f + 1066f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 1939f);
	}

	private void KHBBFKIJEDM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (HDDBLHBCFHG.gameObject.activeSelf)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Decline_Rental", KKJCAACJNHG, -1, -1);
			}
			HideDialog();
		}
	}

	private void DOJOPEJBCMJ()
	{
		KKIGLEGPJKG.gameObject.SetActive(!BHCBHPPNNBI);
		HDDBLHBCFHG.gameObject.SetActive(BHCBHPPNNBI);
		FHFCNLIGFNB.SetActive(BHCBHPPNNBI);
		if (BHCBHPPNNBI)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = OKGNPCBCIDN;
			eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_TUTORIAL_TAPON", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1257f, 1021f, -15);
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(!GBKLFKHMFCP);
			LMCJKECEHGM.text = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			CHCFBDMGNLP.repositionNow = true;
			HLLCKBPCHBL.text = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			CLIMOEHAMBP.SetActive(!GBKLFKHMFCP);
			OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
			JHHCNMFNDFN.NFLJDPDCPIJ();
			JPBIHKIOCOI.repositionNow = false;
		}
	}

	private void LIEIPDKMHOB(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (HDDBLHBCFHG.gameObject.activeSelf)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("a", KKJCAACJNHG, -1, -1);
			}
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void NHGENLCBIKL(UITweener MGDJMGHCAAI)
	{
		CHOLLNEBBBE();
	}

	public virtual void PAHEFBCOENP()
	{
		GGJNEGPBDHL();
		GHGJLMAJJGG.HGANEGJOLCN();
		PPEKNCGDMLA();
		if (!BHCBHPPNNBI)
		{
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("SubscriptionNoChange", KKJCAACJNHG, -1, -1);
		}
	}

	private void LOOKELFNBAB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(FPEPEFGHCGG: false);
			switch (PPBJNCCFBJG)
			{
			case DKHAOLDJLMK.Weapon:
				MDAJJIAMDGH.tryOutWeapon = true;
				LevelManager.instance.EquipRentalWeapon(MDAJJIAMDGH, onlyTry: true);
				break;
			case DKHAOLDJLMK.ArmyUnit:
				IFFDIHCPKFE.upgradeSlots.borrowed = true;
				LevelManager.instance.TryRentalUnit(IFFDIHCPKFE);
				break;
			case DKHAOLDJLMK.PlayerVisual:
				FGIMNJOOAOB.tryOutVisual = true;
				LevelManager.instance.EquipRentalVisual(FGIMNJOOAOB, onlyTry: true);
				break;
			}
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Try_Out_Rental", KKJCAACJNHG, -1, -1);
			HideDialog();
		}
	}

	public override void OnBack()
	{
		KHBBFKIJEDM(MPPDEAMFKMO.gameObject);
	}

	private void JIPHBAJGDNM()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 1293f;
		BMABFEBBOLF();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 764f, 1871f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(525f, 26f, 988f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 197f, new Vector3(1837f, 1157f, 73f), new Vector3(1146f, 1581f, 1074f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO()
	{
		MIIKHEMFJPA.repositionNow = true;
	}

	private void GLAGCMNMIGG()
	{
		float val = 1978f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
		JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
	}

	private void CGNOIKAFNGI(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.NCKODKEJGHD(FPEPEFGHCGG: false);
		DKHAOLDJLMK pPBJNCCFBJG = PPBJNCCFBJG;
		if (pPBJNCCFBJG != DKHAOLDJLMK.ArmyUnit)
		{
			switch (pPBJNCCFBJG)
			{
			case DKHAOLDJLMK.ArmyUnit:
				IFFDIHCPKFE.upgradeSlots.borrowed = true;
				LevelManager.instance.TryRentalUnit(IFFDIHCPKFE);
				break;
			case (DKHAOLDJLMK)8:
				FGIMNJOOAOB.tryOutVisual = false;
				LevelManager.instance.EquipRentalVisual(FGIMNJOOAOB, onlyTry: false);
				break;
			}
		}
		else
		{
			MDAJJIAMDGH.tryOutWeapon = false;
			LevelManager.instance.EquipRentalWeapon(MDAJJIAMDGH, onlyTry: false);
		}
		Singleton<EventTrackingManager>.instance.RegisterRentalEvent("/", KKJCAACJNHG, -1, -1);
		HideDialog();
	}

	[CompilerGenerated]
	private void EACNIDLHDGD()
	{
		float val = 770f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
		JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
	}

	private void EHODAOHFDGL()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 97f;
		BJDAFCHEKAI();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 1068f, 463f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(255f, 1231f, 727f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1312f, new Vector3(1347f, 1044f, 1574f), new Vector3(1875f, 1332f, 1589f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			HEPHMHHFIEH();
		}
		else
		{
			EIPBFFLKMIL();
		}
	}

	private void GGJNEGPBDHL()
	{
		Debug.Log($"Rental Dialog called: type: \"{PPBJNCCFBJG}, \"ID: \"{KKJCAACJNHG}\", discount: \"{OKGNPCBCIDN}%\", is sale: \"{BHCBHPPNNBI}\"");
		OKMNFHNBMFA.text = ((!BHCBHPPNNBI) ? Localization.Localize("ID_TRYFORFREE") : Localization.Localize("ID_ONETIMESPECIALOFFER"));
		OKMNFHNBMFA.color = ((!BHCBHPPNNBI) ? Colours.blue : Colours.goldTier);
		FHFIPPFJIAH.FillCircle(1f);
		EKINHJJEGDA();
		switch (PPBJNCCFBJG)
		{
		case DKHAOLDJLMK.Weapon:
			EHLPFIKFJJP();
			break;
		case DKHAOLDJLMK.ArmyUnit:
			HLILIDEAFNC();
			break;
		case DKHAOLDJLMK.PlayerVisual:
			JDFHFNGHCLG();
			break;
		}
		NNFBFMHGPEB.transform.localPosition = DJCLJHJKJOJ[PPBJNCCFBJG];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[PPBJNCCFBJG];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize("ID_EARLYUNLOCK1");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 52f, 20f, 200);
			DANIJOPJCKC.text = Localization.Localize("ID_EARLYUNLOCK2");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 42f, 20f, 168);
		}
		PBGFKBHDPKM();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void KPHCLDMHGIF()
	{
		KKIGLEGPJKG.gameObject.SetActive(BHCBHPPNNBI);
		HDDBLHBCFHG.gameObject.SetActive(BHCBHPPNNBI);
		FHFCNLIGFNB.SetActive(BHCBHPPNNBI);
		if (BHCBHPPNNBI)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = OKGNPCBCIDN;
			eKIDAFLLCNM.text = Localization.LocalizeFormat("id", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1969f, 1594f, -102);
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(GBKLFKHMFCP);
			LMCJKECEHGM.text = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			CHCFBDMGNLP.repositionNow = true;
			HLLCKBPCHBL.text = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			CLIMOEHAMBP.SetActive(!GBKLFKHMFCP);
			OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
			JHHCNMFNDFN.DMPLCNEPDLM();
			JPBIHKIOCOI.repositionNow = false;
		}
	}
}
