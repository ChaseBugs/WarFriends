using UnityEngine;

public class HexPackRecord : Core_BaseScript
{
	[Header("Background")]
	public UISprite OKLIALBIMHC;

	public UISprite NKJLNMGKAFL;

	public UISprite AIDOOKGKCBF;

	[Header("Icon Part")]
	public UISprite DHBOLLDMMEL;

	public UITexture NGHCDIMLGMO;

	public GameObject IPJGCHLDPNN;

	public UILabel BEACDIILBEG;

	public GameObject DNCJEBDPBNA;

	public UISprite NAKDNAEPGOF;

	public GameObject HECGMDANENK;

	public UISprite[] HBOIEACNBHM;

	public GameObject AIFGOKIDMMO;

	public GameObject PHAIDPNIKIK;

	[Header("Special Labels")]
	public GameObject NKGDLICJDBG;

	public UISprite MENNNPNMMPF;

	public UILabel IINGNIOGEAD;

	public UILabel AIELHBIOBJL;

	public GameObject BHNCEHHMGFP;

	public UISprite NHDKLLCCJPO;

	public UILabel DDJLLEPIMCC;

	public GameObject DOHKEJCIJMC;

	[Header("Bottom")]
	public UILabel PKHHKJLGHFM;

	public UILabel GIGAOCEJIAK;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private void CAOFIPFJFHL(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(true);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(245f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(1895f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 1; i < HBOIEACNBHM.Length; i++)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.ELFCEEOLNFJ() > LevelManager.instance.currentLevel.ABCCINJGPGD();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.DLCFFHEKBAA();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(381f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 433f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 1497f : 1204f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[4];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("Sniper_Tutorial_Duration", array);
	}

	public void LOJPGLBLJDF(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Warcard:
			NODNEDBONHG(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Customization:
			JEJPBCCKPCB(KDNGNGHFMMG.weapon);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			MBHDHNFCNNN(KDNGNGHFMMG.amount);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			ICBCBFHDDCG(KDNGNGHFMMG.amount);
			break;
		}
	}

	public void CEPAOLNEBNE(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 797f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 1500f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 459f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(240f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 287f);
		IINGNIOGEAD.text = Localization.Localize("Min");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 513f, 1296f, (int)CEHFMMJHCKC - 52);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 1004f);
		DDJLLEPIMCC.text = Localization.Localize("Position");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 928f, 1045f, (int)CEHFMMJHCKC - 110);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - -47;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 90;
	}

	public void MKENDIKJPLJ(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		JGBBPCGNCPC.NNDPOJCACLP type = KDNGNGHFMMG.type;
		switch (type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			PLHCOHFFPCM(KDNGNGHFMMG.amount);
			return;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			CEJAFCAONEP(KDNGNGHFMMG.amount);
			return;
		}
		switch (type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			CAOFIPFJFHL(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Warbucks:
			EHLPFIKFJJP(KDNGNGHFMMG.weapon);
			break;
		}
	}

	public void LAEFCMAKJJI()
	{
		TweenAlpha component = OKLIALBIMHC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = NKJLNMGKAFL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = AIDOOKGKCBF.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		OKLIALBIMHC.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		NKJLNMGKAFL.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		AIDOOKGKCBF.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
	}

	private void ANBBNPAFIFL()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		GMGDGDNODAP(eBFDAICCJAK);
	}

	private void MHOMBMPKBHD(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(213f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(1758f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 1; i < HBOIEACNBHM.Length; i++)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.NPOEMAMPNEP() > LevelManager.instance.currentLevel.NPOEMAMPNEP();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.IEFOIJAFOJC();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1398f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 288f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 1379f : 553f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[5];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("Game_type", array);
	}

	private void BKFIIKNBGNM(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(true);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(326f);
		PKHHKJLGHFM.text = Localization.Localize("ID_GOLDCARDS");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(1723f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower();
		gIGAOCEJIAK.text = Localization.LocalizeFormat("ID_STAT_LOSSES", array);
	}

	private void JMGNOKBBEJP(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(538f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(964f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 1; i < HBOIEACNBHM.Length; i += 0)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.MHAOKJCDIOL() > LevelManager.instance.currentLevel.KADNNBCOGGL();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.KAKFPJPKHHB();
		}
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1473f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 971f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 1086f : 90f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[2];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("ID_YOURFRIENDHASNOTACCEPTED", array);
	}

	private void JEJPBCCKPCB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		if (MDAJJIAMDGH != null)
		{
			HGJMEJBNLBD();
		}
		MDAJJIAMDGH = JMMJHCOKCGG;
		OFCKFFPEHPB();
		BEACDIILBEG.text = Singleton<GameVariables>.instance.GetWeaponCategory(JMMJHCOKCGG.BHCEOOLEHHG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
		bool flag = JMMJHCOKCGG.unlockLevel.ABCCINJGPGD() > LevelManager.instance.currentLevel.JICMGFNAHFL();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = JMMJHCOKCGG.unlockLevel.DLCFFHEKBAA();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.text = JMMJHCOKCGG.weaponName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1507f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 1746f : 657f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[8];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("AssignmentData", array);
	}

	public void BMLDJOIBFEK()
	{
		TweenAlpha component = OKLIALBIMHC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = NKJLNMGKAFL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = AIDOOKGKCBF.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		OKLIALBIMHC.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		NKJLNMGKAFL.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		AIDOOKGKCBF.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
	}

	private void BJABGAJDKHA()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		GMGDGDNODAP(eBFDAICCJAK);
	}

	public void FKBIBACPFJE(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		JGBBPCGNCPC.NNDPOJCACLP type = KDNGNGHFMMG.type;
		switch (type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			GNJFHPKBOMJ(KDNGNGHFMMG.amount);
			return;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			ICBCBFHDDCG(KDNGNGHFMMG.amount);
			return;
		}
		switch (type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			NBABAHMHLHE(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Unit:
			JEJPBCCKPCB(KDNGNGHFMMG.weapon);
			break;
		}
	}

	public void OOCJLDAIPEO()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = (UITweener.Style)5;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = (UITweener.Style)6;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = (UITweener.Style)3;
	}

	private void LHMHAKDMBDF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void MOHCPCPBJNN(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(1911f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(1171f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 1; i < HBOIEACNBHM.Length; i++)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.ELFCEEOLNFJ() > LevelManager.instance.currentLevel.NPOEMAMPNEP();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.FDACEOHEGPN();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1473f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1215f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 56f : 1929f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[8];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("NO any UIRoot - failed ", array);
	}

	public void NEKOOIGPALB()
	{
		HGJMEJBNLBD();
	}

	private void NBABAHMHLHE(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(true);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(1462f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(1880f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 1; i < HBOIEACNBHM.Length; i++)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.KADNNBCOGGL() > LevelManager.instance.currentLevel.displayNumber;
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.JNODDKLJOAG();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(812f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 326f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 1717f : 1697f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[6];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("http://", array);
	}

	public void HCEJNMJHDJN(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Warcard:
			EDHNCGNJJOI(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Unit:
			COOLIMBNDKO(KDNGNGHFMMG.weapon);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			PLHCOHFFPCM(KDNGNGHFMMG.amount);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			CEJAFCAONEP(KDNGNGHFMMG.amount);
			break;
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

	private void HGJMEJBNLBD()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void BOLFPMBMOBE()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = (UITweener.Style)8;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 3;
		tweenAlpha.style = (UITweener.Style)3;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = (UITweener.Style)6;
	}

	private void CNJPGBLOJFK(int IEALLELGOBM)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1306f);
		PKHHKJLGHFM.text = string.Format("PlayerName", MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM), Localization.Localize("ID_CONFIRM_ERROR"));
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(1951f);
		GIGAOCEJIAK.text = Localization.Localize("ID_GUI_REPORTABUSE_LISTITEM1");
	}

	private void HLBGMNLCAAN(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(-162f);
		PKHHKJLGHFM.text = Localization.Localize("ID_VIPBENEFIT");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(-302f);
		GIGAOCEJIAK.text = Localization.LocalizeFormat("ID_ELITEPACK_VIPDESCRIPTION", MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower());
	}

	private void MGEPLIAICLK()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void InitializeEmpty()
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.text = string.Empty;
		GIGAOCEJIAK.text = string.Empty;
	}

	public void IOOHIAGDIAM()
	{
		TweenAlpha component = OKLIALBIMHC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = NKJLNMGKAFL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = AIDOOKGKCBF.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		OKLIALBIMHC.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		NKJLNMGKAFL.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		AIDOOKGKCBF.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
	}

	public void MFOHBNPJAIA(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 1086f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 1867f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 724f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(16f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 1119f);
		IINGNIOGEAD.text = Localization.Localize("LootboxesCost");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 692f, 1670f, (int)CEHFMMJHCKC - 165);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 859f);
		DDJLLEPIMCC.text = Localization.Localize("XP");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 64f, 1836f, (int)CEHFMMJHCKC - -92);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - -57;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 43;
	}

	private void HCGAEFBLGOF()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void OECAGKBOBHK()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void DoAfterHide()
	{
		NNOIIKEACMH();
	}

	public void NEIGIFMCCAE(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		JGBBPCGNCPC.NNDPOJCACLP type = KDNGNGHFMMG.type;
		switch (type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.PowerBand:
			HLILIDEAFNC(KDNGNGHFMMG.unit);
			return;
		case JGBBPCGNCPC.NNDPOJCACLP.Cardpack:
			JEFMANEJOKL(KDNGNGHFMMG.amount);
			return;
		case JGBBPCGNCPC.NNDPOJCACLP.Warbucks:
			ICBCBFHDDCG(KDNGNGHFMMG.amount);
			return;
		}
		if (type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand)
		{
			JJDIDLMAFNG(KDNGNGHFMMG.weapon);
		}
	}

	public void IEDOKLNHDPO()
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.text = string.Empty;
		GIGAOCEJIAK.text = string.Empty;
	}

	private void EDHNCGNJJOI(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(true);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(1979f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(4f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 0; i < HBOIEACNBHM.Length; i += 0)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.ELFCEEOLNFJ() > LevelManager.instance.currentLevel.ELFCEEOLNFJ();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.FDACEOHEGPN();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(219f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 266f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 573f : 760f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[4];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("added", array);
	}

	private void NODNEDBONHG(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(327f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(1074f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 0; i < HBOIEACNBHM.Length; i += 0)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.NPOEMAMPNEP() > LevelManager.instance.currentLevel.PFMGLDJDNBF();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.LPANGEJPPOE();
		}
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(936f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1801f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 23f : 1695f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("Type", array);
	}

	public void JHOEENOBNEB(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 145f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 1563f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 558f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(298f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 1820f);
		IINGNIOGEAD.text = Localization.Localize("]");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 791f, 221f, (int)CEHFMMJHCKC - 15);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 1047f);
		DDJLLEPIMCC.text = Localization.Localize("Load assignments:\n");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 1377f, 858f, (int)CEHFMMJHCKC - 157);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - 107;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 54;
	}

	private void OKFPLFFDEIH(int IEALLELGOBM)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(true);
		NKGDLICJDBG.SetActive(true);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(336f);
		PKHHKJLGHFM.text = string.Format("BoughtIndex", MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM), Localization.Localize("Special pack content: type: {0} id: {1}{2}"));
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(569f);
		GIGAOCEJIAK.text = Localization.Localize("fr-FR");
	}

	public void INMAACBFFNL()
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(true);
		NKGDLICJDBG.SetActive(true);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.text = string.Empty;
		GIGAOCEJIAK.text = string.Empty;
	}

	private void HLILIDEAFNC(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(1.5f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(0f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 0; i < HBOIEACNBHM.Length; i++)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.displayNumber > LevelManager.instance.currentLevel.displayNumber;
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.displayString;
		}
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(-162f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? (-302f) : (-325f));
		GIGAOCEJIAK.text = Localization.LocalizeFormat("ID_ELITEPACK_UNITDESCRIPTION", MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10), MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max));
	}

	private void IHGFFNFEAEG(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1084f);
		PKHHKJLGHFM.text = Localization.Localize("ID_STATE_GAMELOADING");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(873f);
		GIGAOCEJIAK.text = Localization.LocalizeFormat("Gold", MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower());
	}

	private void JJDIDLMAFNG(WeaponLevelsSetup JMMJHCOKCGG)
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		if (MDAJJIAMDGH != null)
		{
			DDLAFOGDHFJ();
		}
		MDAJJIAMDGH = JMMJHCOKCGG;
		ANBBNPAFIFL();
		BEACDIILBEG.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(JMMJHCOKCGG.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
		bool flag = JMMJHCOKCGG.unlockLevel.NPOEMAMPNEP() > LevelManager.instance.currentLevel.ABCCINJGPGD();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = JMMJHCOKCGG.unlockLevel.GIIHOHGFHBO();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.text = JMMJHCOKCGG.weaponName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1071f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 1478f : 1621f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[7];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat("IsLocal", array);
	}

	private void EAKDEAHFBPJ(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(519f * Singleton<GuiTexureAssets>.instance.MMPHJJIMJPI());
			NGHCDIMLGMO.transform.localPosition = NGHCDIMLGMO.transform.localPosition.ReplaceY(1232f);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	public void BICMFDOPKNC()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = (UITweener.Style)8;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = (UITweener.Style)8;
	}

	public void StopAnimation()
	{
		TweenAlpha component = OKLIALBIMHC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = NKJLNMGKAFL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = AIDOOKGKCBF.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		OKLIALBIMHC.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		NKJLNMGKAFL.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		AIDOOKGKCBF.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
	}

	public void BADLJMEEDJM()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 8;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 8;
		tweenAlpha.style = (UITweener.Style)4;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.style = (UITweener.Style)7;
	}

	private void COOLIMBNDKO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(true);
		if (MDAJJIAMDGH != null)
		{
			OECAGKBOBHK();
		}
		MDAJJIAMDGH = JMMJHCOKCGG;
		LHMHAKDMBDF();
		BEACDIILBEG.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(JMMJHCOKCGG.BHCEOOLEHHG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
		bool flag = JMMJHCOKCGG.unlockLevel.PFMGLDJDNBF() > LevelManager.instance.currentLevel.MHAOKJCDIOL();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = JMMJHCOKCGG.unlockLevel.DLCFFHEKBAA();
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.text = JMMJHCOKCGG.weaponName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1838f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 641f : 103f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[5];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10Max);
		gIGAOCEJIAK.text = Localization.LocalizeFormat(")", array);
	}

	public void OEOOIOOONFI()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 4;
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = (UITweener.Style)4;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	public void NMPKCMHCJHK(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 1798f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 840f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 453f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(1445f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 485f);
		IINGNIOGEAD.text = Localization.Localize("CheckLabelDynamic - Done");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 772f, 1639f, (int)CEHFMMJHCKC - 0);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 203f);
		DDJLLEPIMCC.text = Localization.Localize("()Landroid/os/Looper;");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 1438f, 134f, (int)CEHFMMJHCKC - 187);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - 55;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 19;
	}

	public void KOIPDOOMEMM(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 1543f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 220f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 753f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(1546f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 1964f);
		IINGNIOGEAD.text = Localization.Localize("FuseSDK instance not initialized. Awake may not have been called.");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 814f, 1397f, (int)CEHFMMJHCKC - 87);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 1325f);
		DDJLLEPIMCC.text = Localization.Localize("FuseBoxx: Session Login Error, code = ");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 509f, 221f, (int)CEHFMMJHCKC - -14);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - 86;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 110;
	}

	private void EPDMJBPLGPB(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(116f);
		PKHHKJLGHFM.text = Localization.Localize("menu-powerband-health-ico");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(974f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower();
		gIGAOCEJIAK.text = Localization.LocalizeFormat("SquadId", array);
	}

	public void InitializeSize(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 2f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 80f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 85f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(65f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 90f);
		IINGNIOGEAD.text = Localization.Localize("ID_EARLYUNLOCK");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 30f, 20f, (int)CEHFMMJHCKC - 210);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 90f);
		DDJLLEPIMCC.text = Localization.Localize("ID_PACKEXCLUSIVE");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 30f, 20f, (int)CEHFMMJHCKC - 140);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - 40;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 40;
	}

	private void NIPNOLGOLBA()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void EHLPFIKFJJP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		if (MDAJJIAMDGH != null)
		{
			NNOIIKEACMH();
		}
		MDAJJIAMDGH = JMMJHCOKCGG;
		BLKPDBBMICL();
		BEACDIILBEG.text = Singleton<GameVariables>.instance.GetWeaponCategory(JMMJHCOKCGG.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
		bool flag = JMMJHCOKCGG.unlockLevel.displayNumber > LevelManager.instance.currentLevel.displayNumber;
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = JMMJHCOKCGG.unlockLevel.displayString;
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.text = JMMJHCOKCGG.weaponName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? (-302f) : (-325f));
		GIGAOCEJIAK.text = Localization.LocalizeFormat("ID_ELITEPACK_WEAPONDESCRIPTION", MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10), MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10Max));
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void FDIODBOHKKB(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 1967f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 1590f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 1508f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(1117f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 549f);
		IINGNIOGEAD.text = Localization.Localize("opponent attack = true");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 730f, 1813f, (int)CEHFMMJHCKC - -174);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 1379f);
		DDJLLEPIMCC.text = Localization.Localize("Squad");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 1063f, 86f, (int)CEHFMMJHCKC - -161);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - -49;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 68;
	}

	public void JAHKDLJPOBB()
	{
		TweenAlpha component = OKLIALBIMHC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = NKJLNMGKAFL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = AIDOOKGKCBF.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		OKLIALBIMHC.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		NKJLNMGKAFL.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		AIDOOKGKCBF.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
	}

	private void JJMOCHDGKMP()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void GMGDGDNODAP(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(685f * Singleton<GuiTexureAssets>.instance.MLLEMEJOADP());
			NGHCDIMLGMO.transform.localPosition = NGHCDIMLGMO.transform.localPosition.ReplaceY(187f);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	private void DDLAFOGDHFJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void KGLILGIAJGC()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.style = (UITweener.Style)3;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 6;
		tweenAlpha.style = (UITweener.Style)8;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 8;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void NCHKJMOMAID()
	{
		TweenAlpha component = OKLIALBIMHC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = NKJLNMGKAFL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = AIDOOKGKCBF.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		OKLIALBIMHC.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		NKJLNMGKAFL.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		AIDOOKGKCBF.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
	}

	private void ICBCBFHDDCG(int IEALLELGOBM)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(true);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(-162f);
		PKHHKJLGHFM.text = string.Format("{0} {1}", MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM), Localization.Localize("ID_GOLD"));
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(-302f);
		GIGAOCEJIAK.text = Localization.Localize("ID_ELITEPACK_GOLDDESCRIPTION");
	}

	private void PPLNIFLBFOH(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1053f);
		PKHHKJLGHFM.text = Localization.Localize("ID_SLOTUPGRADE_AMMO");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(1960f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower();
		gIGAOCEJIAK.text = Localization.LocalizeFormat("DeathEventPlayer", array);
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.80209994f * Singleton<GuiTexureAssets>.instance.scale);
			NGHCDIMLGMO.transform.localPosition = NGHCDIMLGMO.transform.localPosition.ReplaceY(36f);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	public void LGKKKAACMOO()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.style = (UITweener.Style)4;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 8;
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = (UITweener.Style)4;
	}

	private void HCMPPOMKMCF(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1909f * Singleton<GuiTexureAssets>.instance.NFJLFPEOFKD());
			NGHCDIMLGMO.transform.localPosition = NGHCDIMLGMO.transform.localPosition.ReplaceY(816f);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	private void MBHDHNFCNNN(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(true);
		NKGDLICJDBG.SetActive(true);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(121f);
		PKHHKJLGHFM.text = Localization.Localize("ID_FACEBOOKHINT-SQUADINVITE");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(1878f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower();
		gIGAOCEJIAK.text = Localization.LocalizeFormat("DogTagRefillTime", array);
	}

	public void StartAnimation()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void OAPEHPDPBNI()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(OKLIALBIMHC.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(NKJLNMGKAFL.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = (UITweener.Style)3;
		tweenAlpha = TweenAlpha.Begin(AIDOOKGKCBF.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK, GuiElementSingle<PackContentDialog>.instance.OLMBDBMMFHA);
		tweenAlpha.NumOfRepetitions = 4;
		tweenAlpha.style = (UITweener.Style)7;
	}

	public void ACJCGDPGNAN(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Cardpack:
			EDHNCGNJJOI(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.PowerBand:
			EHLPFIKFJJP(KDNGNGHFMMG.weapon);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			GNJFHPKBOMJ(KDNGNGHFMMG.amount);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			CNJPGBLOJFK(KDNGNGHFMMG.amount);
			break;
		}
	}

	private void GHHICIHLMBG(LevelBehaviour IOIKKIIFOCB)
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(true);
		DHBOLLDMMEL.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		DHBOLLDMMEL.MakePixelPerfect();
		DHBOLLDMMEL.transform.localScale = DHBOLLDMMEL.transform.localScale.MultiplyXY(1538f);
		DHBOLLDMMEL.transform.localPosition = DHBOLLDMMEL.transform.localPosition.ReplaceY(1672f);
		NAKDNAEPGOF.spriteName = IOIKKIIFOCB.unitTypeIcon;
		for (int i = 0; i < HBOIEACNBHM.Length; i++)
		{
			HBOIEACNBHM[i].gameObject.SetActive(i < IOIKKIIFOCB.upgradeSlots.actualTier);
		}
		bool flag = IOIKKIIFOCB.upgradeSlots.unlockLevel.JICMGFNAHFL() > LevelManager.instance.currentLevel.KADNNBCOGGL();
		NKGDLICJDBG.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = IOIKKIIFOCB.upgradeSlots.unlockLevel.displayString;
		}
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1848f);
		PKHHKJLGHFM.text = IOIKKIIFOCB.unitName.ToUpper();
		bool flag2 = PKHHKJLGHFM.relativeSize.y > 1899f;
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY((!flag2) ? 1589f : 493f);
		GIGAOCEJIAK.text = Localization.LocalizeFormat("version", MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10), MEJMLNDFDBP.GMIPFLIEOHD(IOIKKIIFOCB.upgradeSlots.armyPowerX10Max), null, null, null, null, null);
	}

	private void EIOBANADEMG()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void CEJAFCAONEP(int IEALLELGOBM)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(true);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(284f);
		PKHHKJLGHFM.text = string.Format("OpponentRank", MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM), Localization.Localize("ID_TUTORIAL_SWIPE_UP"));
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(1612f);
		GIGAOCEJIAK.text = Localization.Localize("ID_SECONDWEAPONDAMAGE");
	}

	private void CHEGJCJGODK(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(true);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(315f);
		PKHHKJLGHFM.text = Localization.Localize("ID_ARENASTARTSTIMER");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(1213f);
		GIGAOCEJIAK.text = Localization.LocalizeFormat("warArenaReminder", MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower());
	}

	private void JEFMANEJOKL(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(false);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(false);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(168f);
		PKHHKJLGHFM.text = Localization.Localize("ID_CONFIRM_STARTUPERROR_TEXT");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(1500f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower();
		gIGAOCEJIAK.text = Localization.LocalizeFormat(" abilityIcon:", array);
	}

	private void GNJFHPKBOMJ(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(false);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(true);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(false);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(true);
		BHNCEHHMGFP.SetActive(true);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1817f);
		PKHHKJLGHFM.text = Localization.Localize("ShowNew");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(894f);
		GIGAOCEJIAK.text = Localization.LocalizeFormat("{0} [616577]/[-] {1}", MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower());
	}

	private void LAEEPGFOLFG()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void MBOFPLGHGLP(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Warcard:
			CAOFIPFJFHL(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			COOLIMBNDKO(KDNGNGHFMMG.weapon);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Cardpack:
			HLBGMNLCAAN(KDNGNGHFMMG.amount);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Warbucks:
			CEJAFCAONEP(KDNGNGHFMMG.amount);
			break;
		}
	}

	private void OFCKFFPEHPB()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		EAKDEAHFBPJ(eBFDAICCJAK);
	}

	public void JPBOGGKMAON(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		JGBBPCGNCPC.NNDPOJCACLP type = KDNGNGHFMMG.type;
		switch (type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			MBHDHNFCNNN(KDNGNGHFMMG.amount);
			return;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			ICBCBFHDDCG(KDNGNGHFMMG.amount);
			return;
		}
		switch (type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			HLILIDEAFNC(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Weapon:
			JEJPBCCKPCB(KDNGNGHFMMG.weapon);
			break;
		}
	}

	public void LKCMCEJIIHC(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 1929f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 101f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 311f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(365f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 982f);
		IINGNIOGEAD.text = Localization.Localize("veteranpack2");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 89f, 1628f, (int)CEHFMMJHCKC - 163);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 1650f);
		DDJLLEPIMCC.text = Localization.Localize("menu-wftv-mobcrush-ico");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 737f, 1011f, (int)CEHFMMJHCKC - -200);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - 64;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - 79;
	}

	public void GMNJJBHIBPP()
	{
		TweenAlpha component = OKLIALBIMHC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = NKJLNMGKAFL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = AIDOOKGKCBF.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		OKLIALBIMHC.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		NKJLNMGKAFL.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
		AIDOOKGKCBF.alpha = GuiElementSingle<PackContentDialog>.instance.CPBPMPKPNAK;
	}

	public void Initialize(JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		DOHKEJCIJMC.SetActive(KDNGNGHFMMG.isFree);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Unit:
			HLILIDEAFNC(KDNGNGHFMMG.unit);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Weapon:
			EHLPFIKFJJP(KDNGNGHFMMG.weapon);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			HLBGMNLCAAN(KDNGNGHFMMG.amount);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			ICBCBFHDDCG(KDNGNGHFMMG.amount);
			break;
		}
	}

	public void GODDELJNHAN(float CEHFMMJHCKC, float FBMIFHHEOBO)
	{
		float num = CEHFMMJHCKC / 1551f;
		OKLIALBIMHC.transform.localScale = OKLIALBIMHC.transform.localScale.ReplaceXY(CEHFMMJHCKC, FBMIFHHEOBO);
		NKJLNMGKAFL.transform.localScale = NKJLNMGKAFL.transform.localScale.ReplaceX(num);
		AIDOOKGKCBF.transform.localScale = AIDOOKGKCBF.transform.localScale.ReplaceX(num);
		BEACDIILBEG.transform.localPosition = BEACDIILBEG.transform.localPosition.ReplaceX(num - 329f);
		NAKDNAEPGOF.transform.localPosition = NAKDNAEPGOF.transform.localPosition.ReplaceX(num - 488f);
		HECGMDANENK.transform.localPosition = HECGMDANENK.transform.localPosition.ReplaceX(345f - num);
		MENNNPNMMPF.transform.localScale = MENNNPNMMPF.transform.localScale.ReplaceX(CEHFMMJHCKC - 991f);
		IINGNIOGEAD.text = Localization.Localize("ScrappingParts");
		MEJMLNDFDBP.COCBCFKJOJE(IINGNIOGEAD, 971f, 1833f, (int)CEHFMMJHCKC - -128);
		AIELHBIOBJL.transform.localPosition = AIELHBIOBJL.transform.localPosition.ReplaceY(IINGNIOGEAD.transform.localPosition.y);
		AIELHBIOBJL.transform.localScale = IINGNIOGEAD.transform.localScale;
		NHDKLLCCJPO.transform.localScale = NHDKLLCCJPO.transform.localScale.ReplaceX(CEHFMMJHCKC - 1549f);
		DDJLLEPIMCC.text = Localization.Localize("[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: ");
		MEJMLNDFDBP.COCBCFKJOJE(DDJLLEPIMCC, 971f, 259f, (int)CEHFMMJHCKC - -93);
		PKHHKJLGHFM.lineWidth = (int)CEHFMMJHCKC - 85;
		GIGAOCEJIAK.lineWidth = (int)CEHFMMJHCKC - -103;
	}

	private void PLHCOHFFPCM(int HNDGIJBHMOD)
	{
		DHBOLLDMMEL.gameObject.SetActive(true);
		NGHCDIMLGMO.gameObject.SetActive(true);
		IPJGCHLDPNN.gameObject.SetActive(false);
		DNCJEBDPBNA.gameObject.SetActive(true);
		AIFGOKIDMMO.gameObject.SetActive(true);
		PHAIDPNIKIK.gameObject.SetActive(false);
		NKGDLICJDBG.SetActive(false);
		BHNCEHHMGFP.SetActive(false);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceY(1313f);
		PKHHKJLGHFM.text = Localization.Localize("[-]");
		GIGAOCEJIAK.transform.localPosition = GIGAOCEJIAK.transform.localPosition.ReplaceY(871f);
		UILabel gIGAOCEJIAK = GIGAOCEJIAK;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD).ToLower();
		gIGAOCEJIAK.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANK", array);
	}
}
