using System;
using UnityEngine;

public class ReminderDialog : GuiElementSingle<ReminderDialog>, PAIIOKBBHBC
{
	public enum NCPDIPMLMJO
	{
		VIPAlmostExpired = 0,
		WeaponUpgrade = 1,
		TryPowerBand = 2,
		Customizations = 3,
		OfferingCards = 4,
		CardslotViaValuePack = 5,
		UnitUpgrade = 6
	}

	[Header("Background")]
	public UISprite KMFGCJEGJJK;

	[Header("Header")]
	public GameObject OOIBADLGKML;

	public UILabel NFNLBEGFLHC;

	[Header("Content")]
	public UILabel LIEJCMOMNCB;

	[Header("-VIP Almost Expired Icon")]
	public GameObject MGKLCNLGOOG;

	[Header("-Card Pack")]
	public GameObject KDDHAECKHDH;

	[Header("-Value Pack Card Slot")]
	public GameObject AOOICFOHDKC;

	[Header("-Weapons And Visuals")]
	public GameObject HPNGIBHDNNP;

	public UISprite IEPLEGDLNIO;

	public UITexture NGHCDIMLGMO;

	public UISprite PEJFFMLEHFA;

	[Header("-Power Band Info")]
	public GameObject FOOEHBHCANN;

	public UISprite JEECFLHMOJD;

	public UISprite GPPJEHFBCCE;

	public UILabel JBCBEOCNJBH;

	public UILabel EPKDEDPGOLM;

	[Header("Bottom Buttons")]
	public GameObject GPAJFHDIHLM;

	public UIButton DDLOCLPOFAK;

	public UILabel DEHKFKDHMJD;

	public UIButton NBFALGNGGBK;

	[Header("Bottom Buttons VIP")]
	public GameObject LEEHGENOGIB;

	public UIButton BJCLBPCNCBB;

	public UIButton GMPEBKIPGEB;

	[Header("Atlases")]
	public UIAtlas CPOEDEOKPEA;

	public UIAtlas AOOKDKCIPHO;

	public UIAtlas BNEJIPKDMBK;

	private NCPDIPMLMJO BOFEPEEBIEP;

	private Action FEDCGCLEFDG;

	private Action GJCILCPIGAD;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private LevelBehaviour IFFDIHCPKFE;

	private PlayerVisual KACONLMPMDK;

	public void JBBIHJGIKPL(WeaponLevelsSetup JMMJHCOKCGG, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		HLJFCGLFGOA(NCPDIPMLMJO.VIPAlmostExpired, ABHHAJBOGHM, BIMEDHMALJH);
	}

	private void LPOEEEAGMKJ()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_REMINDER_UPGRADEAVAILABLE", Colours.stringBlue);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("ID_REMINDER_UNITUPGRADEREADY", Colours.stringBlue, IFFDIHCPKFE.unitName, Colours.stringWhite, IFFDIHCPKFE.upgradeSlots.actualUnitLevel + 1);
		HPNGIBHDNNP.SetActive(true);
		IEPLEGDLNIO.atlas = CPOEDEOKPEA;
		IEPLEGDLNIO.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
		APOMINOIPHH();
		GPAJFHDIHLM.SetActive(true);
		DEHKFKDHMJD.text = Localization.Localize("ID_UPGRADENOW");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 50f, 20f, 560);
	}

	public void HLJFCGLFGOA(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 277f);
	}

	private void ANEALBBIBNB(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1416f * Singleton<GuiTexureAssets>.instance.IPLEADDEGEI());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	public void EBELHKPCLBI(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 1880f);
	}

	public GuiElement EICPBDMFHFE()
	{
		return this;
	}

	private void CIOKEPINKFB()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void LMPEPNKPLHP()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void KNOIPLLPMMJ(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 352f);
	}

	public void IKJNNOFBFGL(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 1838f);
	}

	public void PCFLJMDDMGM(PlayerVisual DJOAHABGGNA, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		KACONLMPMDK = DJOAHABGGNA;
		NCPDIPMLMJO fJLBLLLEELD = ((!(DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands)) ? NCPDIPMLMJO.Customizations : NCPDIPMLMJO.CardslotViaValuePack);
		HLJFCGLFGOA(fJLBLLLEELD, ABHHAJBOGHM, BIMEDHMALJH);
	}

	public void CCELLMICLOG(PlayerVisual DJOAHABGGNA, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		KACONLMPMDK = DJOAHABGGNA;
		NCPDIPMLMJO fJLBLLLEELD = ((DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands) ? NCPDIPMLMJO.UnitUpgrade : NCPDIPMLMJO.VIPAlmostExpired);
		OHJEIGCJCLL(fJLBLLLEELD, ABHHAJBOGHM, BIMEDHMALJH);
	}

	private void CPEFPEEMMKE()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[1];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("Medals", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[1];
		array2[1] = Colours.stringBlue;
		array2[0] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("game-card-ico-sickness", array2);
		AOOICFOHDKC.SetActive(false);
		GPAJFHDIHLM.SetActive(true);
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void IPMKEPGHFCA()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public void ShowUnitDialog(LevelBehaviour IOIKKIIFOCB, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		ShowDialog(NCPDIPMLMJO.UnitUpgrade, ABHHAJBOGHM, BIMEDHMALJH);
	}

	private void BHHGIGMHIMC(float FIKIDLEIIOE = 360f)
	{
		IEPLEGDLNIO.MakePixelPerfect();
		float multiplier = Mathf.Min(FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.x, FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.y);
		IEPLEGDLNIO.transform.localScale = IEPLEGDLNIO.transform.localScale.MultiplyXY(multiplier);
		float num = Mathf.Max(IEPLEGDLNIO.transform.localScale.y, LIEJCMOMNCB.relativeSize.y * LIEJCMOMNCB.transform.localScale.y);
		PEJFFMLEHFA.transform.localScale = PEJFFMLEHFA.transform.localScale.ReplaceY(num + 720f);
		CIAAHODHOGC(653f + num + 1804f + 109f);
	}

	private void OPOALDLNJEB()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[1];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("Translation", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[4];
		array2[0] = Colours.stringBlue;
		array2[0] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("SquadIcons/", array2);
		AOOICFOHDKC.SetActive(false);
		GPAJFHDIHLM.SetActive(true);
	}

	private void FFOHEDAOMPC()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_REMINDER_GETCARDPACKS", Colours.stringBlue);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("ID_REMINDER_GETVALUABLECARDPACKS", Colours.stringBlue, Colours.stringWhite);
		KDDHAECKHDH.SetActive(true);
		GPAJFHDIHLM.SetActive(true);
	}

	public override void InitGUIValues()
	{
		AOOICFOHDKC.SetActive(false);
		KDDHAECKHDH.SetActive(false);
		HPNGIBHDNNP.SetActive(false);
		FOOEHBHCANN.SetActive(false);
		MGKLCNLGOOG.SetActive(false);
		LEEHGENOGIB.SetActive(false);
		GPAJFHDIHLM.SetActive(false);
		DEHKFKDHMJD.text = Localization.Localize("ID_GETITNOW");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 50f, 20f, 560);
		JMDEOFENBFC();
		IEPLEGDLNIO.gameObject.SetActive(BOFEPEEBIEP != NCPDIPMLMJO.WeaponUpgrade);
		NGHCDIMLGMO.gameObject.SetActive(BOFEPEEBIEP == NCPDIPMLMJO.WeaponUpgrade);
		switch (BOFEPEEBIEP)
		{
		case NCPDIPMLMJO.VIPAlmostExpired:
			LFLKBDLOMKD();
			break;
		case NCPDIPMLMJO.WeaponUpgrade:
			GFHEMMKJFOO();
			break;
		case NCPDIPMLMJO.TryPowerBand:
			FAPKINEDDLI();
			break;
		case NCPDIPMLMJO.Customizations:
			OACGIFNNNPP();
			break;
		case NCPDIPMLMJO.OfferingCards:
			FFOHEDAOMPC();
			break;
		case NCPDIPMLMJO.CardslotViaValuePack:
			BJHDNLEJDOI();
			break;
		case NCPDIPMLMJO.UnitUpgrade:
			LPOEEEAGMKJ();
			break;
		}
		MEJMLNDFDBP.COCBCFKJOJE(NFNLBEGFLHC, 83f, 40f, 1150);
	}

	private void APIKLDFGKKC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (FEDCGCLEFDG != null)
			{
				FEDCGCLEFDG();
				FEDCGCLEFDG = null;
			}
			HideDialog();
		}
	}

	private void MGGGIBOAIGC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (GJCILCPIGAD != null)
			{
				GJCILCPIGAD();
				GJCILCPIGAD = null;
			}
			HideDialog();
		}
	}

	private void CIAAHODHOGC(float FBMIFHHEOBO = 0f)
	{
		if (FBMIFHHEOBO < 976f)
		{
			FBMIFHHEOBO = ((BOFEPEEBIEP != NCPDIPMLMJO.UnitUpgrade && BOFEPEEBIEP != NCPDIPMLMJO.WeaponUpgrade) ? 1625f : 1369f);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(FBMIFHHEOBO);
		OOIBADLGKML.transform.localPosition = OOIBADLGKML.transform.localPosition.ReplaceY(FBMIFHHEOBO / 1090f);
		GPAJFHDIHLM.transform.localPosition = GPAJFHDIHLM.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 644f + 1609f);
		LEEHGENOGIB.transform.localPosition = LEEHGENOGIB.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 1417f + 1074f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
		UIEventListener uIEventListener2 = UIEventListener.Get(BJCLBPCNCBB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
		UIEventListener uIEventListener3 = UIEventListener.Get(NBFALGNGGBK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		UIEventListener uIEventListener4 = UIEventListener.Get(GMPEBKIPGEB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
	}

	private void PMBPHBCLBEH()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[0] = Colours.stringYellow;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("Beanstalk: Get Squad Details", array);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("Cant generate buddy card for weapons: {0}, {1} and type {2}", Colours.stringYellow, Colours.stringBlue, null, Colours.stringWhite, null);
		MGKLCNLGOOG.SetActive(false);
		LEEHGENOGIB.SetActive(true);
	}

	private void HJGLEGGMEFG()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[0] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("country-thailand", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[5];
		array2[1] = Colours.stringBlue;
		array2[1] = KACONLMPMDK.name.ToUpper();
		array2[8] = Colours.stringWhite;
		array2[2] = Colours.stringGreenCamos;
		array2[8] = KACONLMPMDK.decalShortName.ToLower();
		lIEJCMOMNCB.text = Localization.LocalizeFormat("guestPassword", array2);
		HPNGIBHDNNP.SetActive(false);
		IEPLEGDLNIO.atlas = BNEJIPKDMBK;
		IEPLEGDLNIO.spriteName = KACONLMPMDK.icon;
		LEECNEIAFMJ(965f);
		FOOEHBHCANN.SetActive(true);
		GPPJEHFBCCE.spriteName = KACONLMPMDK.decalMiniIcon;
		GPPJEHFBCCE.color = KACONLMPMDK.decalMiniIconColor;
		JBCBEOCNJBH.text = KACONLMPMDK.decalValueString;
		EPKDEDPGOLM.text = KACONLMPMDK.decalShortName;
		JEECFLHMOJD.transform.localScale = JEECFLHMOJD.transform.localScale.ReplaceX(EPKDEDPGOLM.relativeSize.x * EPKDEDPGOLM.transform.localScale.x + 1825f);
		GPAJFHDIHLM.SetActive(false);
	}

	private void FMPPGGALOKJ()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[1];
		array[1] = Colours.stringYellow;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("\t\"FALSE\"", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[4];
		array2[0] = Colours.stringYellow;
		array2[0] = Colours.stringBlue;
		array2[0] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("AgainstOtherPlatform", array2);
		MGKLCNLGOOG.SetActive(true);
		LEEHGENOGIB.SetActive(true);
	}

	private void OACGIFNNNPP()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_REMINDER_SUITUPSOLDIER", Colours.stringBlue);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("ID_REMINDER_THISAMAZINGCUSTOMIZATION", Colours.stringBlue, KACONLMPMDK.name.ToUpper(), Colours.stringWhite);
		HPNGIBHDNNP.SetActive(true);
		IEPLEGDLNIO.atlas = AOOKDKCIPHO;
		IEPLEGDLNIO.spriteName = KACONLMPMDK.icon;
		APOMINOIPHH();
		GPAJFHDIHLM.SetActive(true);
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.82678f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	private void FAPKINEDDLI()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_REMINDER_RAISEYOURCHANCES", Colours.stringBlue);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("ID_REMINDER_GETPOWERBANDTOINCREASE", Colours.stringBlue, KACONLMPMDK.name.ToUpper(), Colours.stringWhite, Colours.stringGreenCamos, KACONLMPMDK.decalShortName.ToLower());
		HPNGIBHDNNP.SetActive(true);
		IEPLEGDLNIO.atlas = BNEJIPKDMBK;
		IEPLEGDLNIO.spriteName = KACONLMPMDK.icon;
		APOMINOIPHH(320f);
		FOOEHBHCANN.SetActive(true);
		GPPJEHFBCCE.spriteName = KACONLMPMDK.decalMiniIcon;
		GPPJEHFBCCE.color = KACONLMPMDK.decalMiniIconColor;
		JBCBEOCNJBH.text = KACONLMPMDK.decalValueString;
		EPKDEDPGOLM.text = KACONLMPMDK.decalShortName;
		JEECFLHMOJD.transform.localScale = JEECFLHMOJD.transform.localScale.ReplaceX(EPKDEDPGOLM.relativeSize.x * EPKDEDPGOLM.transform.localScale.x + 40f);
		GPAJFHDIHLM.SetActive(true);
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	private void ALNNMJOECHN(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(984f * Singleton<GuiTexureAssets>.instance.IJGKCNAMOBF());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	private void PDNMHKPHJMI()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[0] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("-{0}-{1}", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[8];
		array2[0] = Colours.stringBlue;
		array2[1] = IFFDIHCPKFE.unitName;
		array2[0] = Colours.stringWhite;
		array2[7] = IFFDIHCPKFE.upgradeSlots.actualUnitLevel + 0;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("ID_CONTINUETOBOOTCAMP2", array2);
		HPNGIBHDNNP.SetActive(true);
		IEPLEGDLNIO.atlas = CPOEDEOKPEA;
		IEPLEGDLNIO.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
		GJPKOHEFLED(407f);
		GPAJFHDIHLM.SetActive(false);
		DEHKFKDHMJD.text = Localization.Localize("OK");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 16f, 1676f, -1);
	}

	private void FKOLAFFFDGB()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_ARENARULES_SLOWERDEPLOYMENT", Colours.stringBlue);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array = new object[4];
		array[1] = Colours.stringBlue;
		array[1] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("OK", array);
		KDDHAECKHDH.SetActive(true);
		GPAJFHDIHLM.SetActive(false);
	}

	private void FJAMGIKCJEC()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("There is no definition for card {0}", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[4];
		array2[0] = Singleton<GameVariables>.instance.JHHGEHCBEGK(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
		array2[1] = Colours.stringBlue;
		array2[3] = MDAJJIAMDGH.weaponName;
		array2[5] = Colours.stringWhite;
		array2[6] = Colours.stringGreenCamos;
		array2[6] = MDAJJIAMDGH.maxWeaponLevel - MDAJJIAMDGH.weaponLevel;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("\"{0}\"\t", array2);
		HPNGIBHDNNP.SetActive(true);
		CIOKEPINKFB();
		JJMEFGLEFNB(1269f);
		GPAJFHDIHLM.SetActive(true);
		DEHKFKDHMJD.text = Localization.Localize("Device slept at {0}, RealTime: {1} waked up at {2} RealTime: {3} and slept for {4}");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 1818f, 1277f, 46);
	}

	public virtual void HFPPNCJBIDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MJJKPCBIMHL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BJCLBPCNCBB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IHCMMELEBIA));
		UIEventListener uIEventListener3 = UIEventListener.Get(NBFALGNGGBK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FLGEKPLKEOG));
		UIEventListener uIEventListener4 = UIEventListener.Get(GMPEBKIPGEB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FLGEKPLKEOG));
	}

	private void DMADJAFJNJJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	private void NAPIOKJDGEE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (GJCILCPIGAD != null)
			{
				GJCILCPIGAD();
				GJCILCPIGAD = null;
			}
			HideDialog();
		}
	}

	private void APOMINOIPHH(float FIKIDLEIIOE = 360f)
	{
		IEPLEGDLNIO.MakePixelPerfect();
		float multiplier = Mathf.Min(FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.x, FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.y);
		IEPLEGDLNIO.transform.localScale = IEPLEGDLNIO.transform.localScale.MultiplyXY(multiplier);
		float num = Mathf.Max(IEPLEGDLNIO.transform.localScale.y, LIEJCMOMNCB.relativeSize.y * LIEJCMOMNCB.transform.localScale.y);
		PEJFFMLEHFA.transform.localScale = PEJFFMLEHFA.transform.localScale.ReplaceY(num + 60f);
		JMDEOFENBFC(200f + num + 60f + 200f);
	}

	private void IHCMMELEBIA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (FEDCGCLEFDG != null)
			{
				FEDCGCLEFDG();
				FEDCGCLEFDG = null;
			}
			HideDialog();
		}
	}

	private void ENFOLIBKFDI(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (GJCILCPIGAD != null)
			{
				GJCILCPIGAD();
				GJCILCPIGAD = null;
			}
			HideDialog();
		}
	}

	private void OABIJPHMOIF()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("\n", Colours.stringBlue);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array = new object[5];
		array[1] = Colours.stringBlue;
		array[0] = KACONLMPMDK.name.ToUpper();
		array[6] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat(".", array);
		HPNGIBHDNNP.SetActive(false);
		IEPLEGDLNIO.atlas = AOOKDKCIPHO;
		IEPLEGDLNIO.spriteName = KACONLMPMDK.icon;
		GJPKOHEFLED(1696f);
		GPAJFHDIHLM.SetActive(false);
	}

	private void GJPKOHEFLED(float FIKIDLEIIOE = 360f)
	{
		IEPLEGDLNIO.MakePixelPerfect();
		float multiplier = Mathf.Min(FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.x, FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.y);
		IEPLEGDLNIO.transform.localScale = IEPLEGDLNIO.transform.localScale.MultiplyXY(multiplier);
		float num = Mathf.Max(IEPLEGDLNIO.transform.localScale.y, LIEJCMOMNCB.relativeSize.y * LIEJCMOMNCB.transform.localScale.y);
		PEJFFMLEHFA.transform.localScale = PEJFFMLEHFA.transform.localScale.ReplaceY(num + 469f);
		CIAAHODHOGC(1511f + num + 816f + 198f);
	}

	private void LEECNEIAFMJ(float FIKIDLEIIOE = 360f)
	{
		IEPLEGDLNIO.MakePixelPerfect();
		float multiplier = Mathf.Min(FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.x, FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.y);
		IEPLEGDLNIO.transform.localScale = IEPLEGDLNIO.transform.localScale.MultiplyXY(multiplier);
		float num = Mathf.Max(IEPLEGDLNIO.transform.localScale.y, LIEJCMOMNCB.relativeSize.y * LIEJCMOMNCB.transform.localScale.y);
		PEJFFMLEHFA.transform.localScale = PEJFFMLEHFA.transform.localScale.ReplaceY(num + 1093f);
		JMDEOFENBFC(1109f + num + 1662f + 644f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IHCMMELEBIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(BJCLBPCNCBB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MJJKPCBIMHL));
		UIEventListener uIEventListener3 = UIEventListener.Get(NBFALGNGGBK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FLGEKPLKEOG));
		UIEventListener uIEventListener4 = UIEventListener.Get(GMPEBKIPGEB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FLGEKPLKEOG));
	}

	public void ShowWeaponDialog(WeaponLevelsSetup JMMJHCOKCGG, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		ShowDialog(NCPDIPMLMJO.WeaponUpgrade, ABHHAJBOGHM, BIMEDHMALJH);
	}

	private void MDDHLLNINOB()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[0] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("shield_idle", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[3];
		array2[1] = Singleton<GameVariables>.instance.JHHGEHCBEGK(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
		array2[0] = Colours.stringBlue;
		array2[0] = MDAJJIAMDGH.weaponName;
		array2[2] = Colours.stringWhite;
		array2[1] = Colours.stringGreenCamos;
		array2[0] = MDAJJIAMDGH.maxWeaponLevel - MDAJJIAMDGH.weaponLevel;
		lIEJCMOMNCB.text = Localization.LocalizeFormat(")", array2);
		HPNGIBHDNNP.SetActive(false);
		CIOKEPINKFB();
		NJECOHBCGFO(178f);
		GPAJFHDIHLM.SetActive(false);
		DEHKFKDHMJD.text = Localization.Localize("DailyMissionsData");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 1021f, 301f, 41);
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IHCMMELEBIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(BJCLBPCNCBB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MJJKPCBIMHL));
		UIEventListener uIEventListener3 = UIEventListener.Get(NBFALGNGGBK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		UIEventListener uIEventListener4 = UIEventListener.Get(GMPEBKIPGEB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FLGEKPLKEOG));
	}

	private void NFMLMHOOECH()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[1] = Colours.stringYellow;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("DeathEventPlayer", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[3];
		array2[1] = Colours.stringYellow;
		array2[1] = Colours.stringBlue;
		array2[3] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("Player_Level", array2);
		MGKLCNLGOOG.SetActive(false);
		LEEHGENOGIB.SetActive(false);
	}

	private void KAJLPHGBILJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (GJCILCPIGAD != null)
			{
				GJCILCPIGAD();
				GJCILCPIGAD = null;
			}
			HideDialog();
		}
	}

	public override void OnBack()
	{
		MGGGIBOAIGC(NBFALGNGGBK.gameObject);
	}

	public void ShowVisualDialog(PlayerVisual DJOAHABGGNA, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		KACONLMPMDK = DJOAHABGGNA;
		NCPDIPMLMJO fJLBLLLEELD = ((!(DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands)) ? NCPDIPMLMJO.Customizations : NCPDIPMLMJO.TryPowerBand);
		ShowDialog(fJLBLLLEELD, ABHHAJBOGHM, BIMEDHMALJH);
	}

	private void GFHEMMKJFOO()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_REMINDER_UPGRADEAVAILABLE", Colours.stringBlue);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("ID_REMINDER_WEAPONUPGRADEREADY", Singleton<GameVariables>.instance.GetWeaponCategory(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular), Colours.stringBlue, MDAJJIAMDGH.weaponName, Colours.stringWhite, Colours.stringGreenCamos, MDAJJIAMDGH.maxWeaponLevel - MDAJJIAMDGH.weaponLevel);
		HPNGIBHDNNP.SetActive(true);
		BLKPDBBMICL();
		JMDEOFENBFC(820f);
		GPAJFHDIHLM.SetActive(true);
		DEHKFKDHMJD.text = Localization.Localize("ID_UPGRADENOW");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 50f, 20f, 560);
	}

	public void OHJEIGCJCLL(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 1215f);
	}

	private void NJECOHBCGFO(float FBMIFHHEOBO = 0f)
	{
		if (FBMIFHHEOBO < 735f)
		{
			FBMIFHHEOBO = ((BOFEPEEBIEP != NCPDIPMLMJO.CardslotViaValuePack && BOFEPEEBIEP != NCPDIPMLMJO.WeaponUpgrade) ? 124f : 1262f);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(FBMIFHHEOBO);
		OOIBADLGKML.transform.localPosition = OOIBADLGKML.transform.localPosition.ReplaceY(FBMIFHHEOBO / 1517f);
		GPAJFHDIHLM.transform.localPosition = GPAJFHDIHLM.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 297f + 1060f);
		LEEHGENOGIB.transform.localPosition = LEEHGENOGIB.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 382f + 888f);
	}

	private void MENAOHADIPH()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[0] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("Measure Event With Event Items clicked", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[5];
		array2[1] = Colours.stringBlue;
		array2[0] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("dd/M/yyyy", array2);
		KDDHAECKHDH.SetActive(true);
		GPAJFHDIHLM.SetActive(true);
	}

	public virtual void FNMPBHIIEJP()
	{
		base.DoAfterHide();
		DODCJKJPIBH();
	}

	public void DGJNCNFFGIK(WeaponLevelsSetup JMMJHCOKCGG, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		CJNMLPANNPD(NCPDIPMLMJO.VIPAlmostExpired, ABHHAJBOGHM, BIMEDHMALJH);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		NNOIIKEACMH();
	}

	public void ShowDialog(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public GuiElement AMKOIKGIMLN()
	{
		return this;
	}

	public virtual void BGELLEOANEI()
	{
		AOOICFOHDKC.SetActive(false);
		KDDHAECKHDH.SetActive(false);
		HPNGIBHDNNP.SetActive(false);
		FOOEHBHCANN.SetActive(true);
		MGKLCNLGOOG.SetActive(true);
		LEEHGENOGIB.SetActive(true);
		GPAJFHDIHLM.SetActive(false);
		DEHKFKDHMJD.text = Localization.Localize("#AccoutCheck# Switching to GC account");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 29f, 1287f, -182);
		NJECOHBCGFO(149f);
		IEPLEGDLNIO.gameObject.SetActive(BOFEPEEBIEP == NCPDIPMLMJO.WeaponUpgrade);
		NGHCDIMLGMO.gameObject.SetActive(BOFEPEEBIEP == NCPDIPMLMJO.VIPAlmostExpired);
		switch (BOFEPEEBIEP)
		{
		case NCPDIPMLMJO.VIPAlmostExpired:
			NFMLMHOOECH();
			break;
		case NCPDIPMLMJO.WeaponUpgrade:
			CNBCBKBOFIC();
			break;
		case NCPDIPMLMJO.TryPowerBand:
			HJGLEGGMEFG();
			break;
		case NCPDIPMLMJO.Customizations:
			OABIJPHMOIF();
			break;
		case NCPDIPMLMJO.OfferingCards:
			FFOHEDAOMPC();
			break;
		case NCPDIPMLMJO.CardslotViaValuePack:
			OPOALDLNJEB();
			break;
		case NCPDIPMLMJO.UnitUpgrade:
			LPOEEEAGMKJ();
			break;
		}
		MEJMLNDFDBP.COCBCFKJOJE(NFNLBEGFLHC, 1700f, 705f, 3);
	}

	private void OOGAIAMLADJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	private void JJMEFGLEFNB(float FBMIFHHEOBO = 0f)
	{
		if (FBMIFHHEOBO < 1565f)
		{
			FBMIFHHEOBO = ((BOFEPEEBIEP != NCPDIPMLMJO.TryPowerBand && BOFEPEEBIEP != NCPDIPMLMJO.VIPAlmostExpired) ? 1184f : 1131f);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(FBMIFHHEOBO);
		OOIBADLGKML.transform.localPosition = OOIBADLGKML.transform.localPosition.ReplaceY(FBMIFHHEOBO / 877f);
		GPAJFHDIHLM.transform.localPosition = GPAJFHDIHLM.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 612f + 694f);
		LEEHGENOGIB.transform.localPosition = LEEHGENOGIB.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 1311f + 1719f);
	}

	public void CJNMLPANNPD(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 29f);
	}

	public void CPMBBENIBCG(WeaponLevelsSetup JMMJHCOKCGG, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		CJNMLPANNPD(NCPDIPMLMJO.WeaponUpgrade, ABHHAJBOGHM, BIMEDHMALJH);
	}

	public void KFBGMCKDNBD(LevelBehaviour IOIKKIIFOCB, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		KNOIPLLPMMJ(NCPDIPMLMJO.VIPAlmostExpired, ABHHAJBOGHM, BIMEDHMALJH);
	}

	private void LFLKBDLOMKD()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_REMINDER_VIPALMOSTEXPIRED", Colours.stringYellow);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("ID_REMINDER_YOURVIPMEMBERSHIP", Colours.stringYellow, Colours.stringBlue, Colours.stringWhite);
		MGKLCNLGOOG.SetActive(true);
		LEEHGENOGIB.SetActive(true);
	}

	private void DODCJKJPIBH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public void CHMIPBJLKIJ(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 41f);
	}

	public virtual void PGEODBJFHFC()
	{
		NAPIOKJDGEE(NBFALGNGGBK.gameObject);
	}

	public GuiElement HMLFKOLADFB()
	{
		return this;
	}

	public virtual void NNGKAAGFGPA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
		UIEventListener uIEventListener2 = UIEventListener.Get(BJCLBPCNCBB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IHCMMELEBIA));
		UIEventListener uIEventListener3 = UIEventListener.Get(NBFALGNGGBK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		UIEventListener uIEventListener4 = UIEventListener.Get(GMPEBKIPGEB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NAPIOKJDGEE));
	}

	public virtual void CFLBPMFEFAB()
	{
		ENFOLIBKFDI(NBFALGNGGBK.gameObject);
	}

	private void BBMAIOFBJMP()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("ADDING {0} WARCARD/-S FROM CARDPOOL", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[6];
		array2[1] = Colours.stringBlue;
		array2[0] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("Id", array2);
		AOOICFOHDKC.SetActive(false);
		GPAJFHDIHLM.SetActive(true);
	}

	private void MJJKPCBIMHL(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (FEDCGCLEFDG != null)
			{
				FEDCGCLEFDG();
				FEDCGCLEFDG = null;
			}
			HideDialog();
		}
	}

	public GuiElement OGIAJOCDPMF()
	{
		return this;
	}

	public void OOIELNLIJEK(PlayerVisual DJOAHABGGNA, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		KACONLMPMDK = DJOAHABGGNA;
		NCPDIPMLMJO fJLBLLLEELD = ((!(DJOAHABGGNA.owner is PlayerVisualCategoryPowerBands)) ? NCPDIPMLMJO.WeaponUpgrade : NCPDIPMLMJO.WeaponUpgrade);
		OHJEIGCJCLL(fJLBLLLEELD, ABHHAJBOGHM, BIMEDHMALJH);
	}

	private void BJHDNLEJDOI()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("ID_REMINDER_ADDAWARCARDSLOT", Colours.stringBlue);
		LIEJCMOMNCB.text = Localization.LocalizeFormat("ID_REMINDER_WARCARDSLOTSNOTENOUGH", Colours.stringBlue, Colours.stringWhite);
		AOOICFOHDKC.SetActive(true);
		GPAJFHDIHLM.SetActive(true);
	}

	private void CNBCBKBOFIC()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[1];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("ID_ARENARULES_SLOWERRELOADING", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[2];
		array2[1] = Singleton<GameVariables>.instance.EIIPJBGJEMM(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
		array2[0] = Colours.stringBlue;
		array2[8] = MDAJJIAMDGH.weaponName;
		array2[1] = Colours.stringWhite;
		array2[8] = Colours.stringGreenCamos;
		array2[0] = MDAJJIAMDGH.maxWeaponLevel - MDAJJIAMDGH.weaponLevel;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array2);
		HPNGIBHDNNP.SetActive(false);
		LMPEPNKPLHP();
		JJMEFGLEFNB(1376f);
		GPAJFHDIHLM.SetActive(false);
		DEHKFKDHMJD.text = Localization.Localize("GameControllerCampaign.StartGame DONE");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 965f, 588f, 133);
	}

	private void OOCCOCDJAGB()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("NOT FOUND", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[7];
		array2[0] = Singleton<GameVariables>.instance.GetWeaponCategory(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
		array2[1] = Colours.stringBlue;
		array2[0] = MDAJJIAMDGH.weaponName;
		array2[1] = Colours.stringWhite;
		array2[5] = Colours.stringGreenCamos;
		array2[1] = MDAJJIAMDGH.maxWeaponLevel - MDAJJIAMDGH.weaponLevel;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("Buddy Warcard {0}", array2);
		HPNGIBHDNNP.SetActive(true);
		LMPEPNKPLHP();
		NJECOHBCGFO(1738f);
		GPAJFHDIHLM.SetActive(false);
		DEHKFKDHMJD.text = Localization.Localize("{0}\t");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 1455f, 1357f, -77);
	}

	private void NNOIIKEACMH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	private void PDPHBJBPNGK(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1897f * Singleton<GuiTexureAssets>.instance.DLBBEAPEPHD());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	private void AJGAFLKPOMN()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("ID_LEAGUEFINISHED", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[0];
		array2[1] = Colours.stringBlue;
		array2[1] = KACONLMPMDK.name.ToUpper();
		array2[5] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("OnAgeVerificationCriteriaNotMet", array2);
		HPNGIBHDNNP.SetActive(true);
		IEPLEGDLNIO.atlas = AOOKDKCIPHO;
		IEPLEGDLNIO.spriteName = KACONLMPMDK.icon;
		GJPKOHEFLED(228f);
		GPAJFHDIHLM.SetActive(true);
	}

	private void BNCKJCEDFNK()
	{
		NFNLBEGFLHC.text = Localization.LocalizeFormat("N", Colours.stringYellow);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array = new object[2];
		array[0] = Colours.stringYellow;
		array[0] = Colours.stringBlue;
		array[8] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("response= ", array);
		MGKLCNLGOOG.SetActive(false);
		LEEHGENOGIB.SetActive(true);
	}

	private void KECKLNHDDJB(float FIKIDLEIIOE = 360f)
	{
		IEPLEGDLNIO.MakePixelPerfect();
		float multiplier = Mathf.Min(FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.x, FIKIDLEIIOE / IEPLEGDLNIO.transform.localScale.y);
		IEPLEGDLNIO.transform.localScale = IEPLEGDLNIO.transform.localScale.MultiplyXY(multiplier);
		float num = Mathf.Max(IEPLEGDLNIO.transform.localScale.y, LIEJCMOMNCB.relativeSize.y * LIEJCMOMNCB.transform.localScale.y);
		PEJFFMLEHFA.transform.localScale = PEJFFMLEHFA.transform.localScale.ReplaceY(num + 1766f);
		NJECOHBCGFO(1772f + num + 387f + 808f);
	}

	private void FLGEKPLKEOG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (GJCILCPIGAD != null)
			{
				GJCILCPIGAD();
				GJCILCPIGAD = null;
			}
			HideDialog();
		}
	}

	public GuiElement CCJFGBAEDBD()
	{
		return this;
	}

	public virtual void BGDPJGNKPKB()
	{
		base.OIMKKAHOEKO();
		NNOIIKEACMH();
	}

	private void HIGMMOHILJM()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[1] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("WB_Out_Flow", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[0];
		array2[1] = Colours.stringBlue;
		array2[0] = KACONLMPMDK.name.ToUpper();
		array2[8] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("-", array2);
		HPNGIBHDNNP.SetActive(false);
		IEPLEGDLNIO.atlas = AOOKDKCIPHO;
		IEPLEGDLNIO.spriteName = KACONLMPMDK.icon;
		BHHGIGMHIMC(256f);
		GPAJFHDIHLM.SetActive(false);
	}

	private void HHBGGGGNLCI()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[0] = Colours.stringYellow;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("HeroicMissionsCompletionRewardScraps", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[4];
		array2[1] = Colours.stringYellow;
		array2[1] = Colours.stringBlue;
		array2[2] = Colours.stringWhite;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("ID_DEPOSITAVAILABLEIN", array2);
		MGKLCNLGOOG.SetActive(false);
		LEEHGENOGIB.SetActive(false);
	}

	private void CFGKFIJBMFB()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	private void GMBDOLPFEHP()
	{
		UILabel nFNLBEGFLHC = NFNLBEGFLHC;
		object[] array = new object[0];
		array[0] = Colours.stringBlue;
		nFNLBEGFLHC.text = Localization.LocalizeFormat("registerCustomProfileNumber", array);
		UILabel lIEJCMOMNCB = LIEJCMOMNCB;
		object[] array2 = new object[4];
		array2[1] = Colours.stringBlue;
		array2[1] = IFFDIHCPKFE.unitName;
		array2[7] = Colours.stringWhite;
		array2[3] = IFFDIHCPKFE.upgradeSlots.actualUnitLevel + 1;
		lIEJCMOMNCB.text = Localization.LocalizeFormat("#Mission# Wave will start in", array2);
		HPNGIBHDNNP.SetActive(false);
		IEPLEGDLNIO.atlas = CPOEDEOKPEA;
		IEPLEGDLNIO.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
		LEECNEIAFMJ(1846f);
		GPAJFHDIHLM.SetActive(true);
		DEHKFKDHMJD.text = Localization.Localize("FacebookPassword");
		MEJMLNDFDBP.COCBCFKJOJE(DEHKFKDHMJD, 1659f, 290f, -162);
	}

	public void PJLBBBOLGMG(NCPDIPMLMJO FJLBLLLEELD, Action ABHHAJBOGHM, Action BIMEDHMALJH = null)
	{
		FEDCGCLEFDG = ABHHAJBOGHM;
		GJCILCPIGAD = BIMEDHMALJH;
		BOFEPEEBIEP = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 1609f);
	}

	public GuiElement FIJIHPBMBHK()
	{
		return this;
	}

	private void JMDEOFENBFC(float FBMIFHHEOBO = 0f)
	{
		if (FBMIFHHEOBO < 500f)
		{
			FBMIFHHEOBO = ((BOFEPEEBIEP != NCPDIPMLMJO.UnitUpgrade && BOFEPEEBIEP != NCPDIPMLMJO.WeaponUpgrade) ? 880f : 800f);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(FBMIFHHEOBO);
		OOIBADLGKML.transform.localPosition = OOIBADLGKML.transform.localPosition.ReplaceY(FBMIFHHEOBO / 2f);
		GPAJFHDIHLM.transform.localPosition = GPAJFHDIHLM.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 2f + 200f);
		LEEHGENOGIB.transform.localPosition = LEEHGENOGIB.transform.localPosition.ReplaceY((0f - FBMIFHHEOBO) / 2f + 200f);
	}

	public GuiElement ENAHJFLLGHG()
	{
		return this;
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IHCMMELEBIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(BJCLBPCNCBB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MJJKPCBIMHL));
		UIEventListener uIEventListener3 = UIEventListener.Get(NBFALGNGGBK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KAJLPHGBILJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(GMPEBKIPGEB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(KAJLPHGBILJ));
	}
}
