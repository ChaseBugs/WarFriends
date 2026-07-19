using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerVisualIcon : Core_BaseScript
{
	[Header("Core")]
	public UISprite KMFGCJEGJJK;

	public UISprite LCPBNBLGFIA;

	public UISprite DAANKCOLJGJ;

	public UISprite JAJCFNOIBPM;

	[Header("-Packs")]
	public GameObject ANODBGELEBJ;

	[Header("-Parts")]
	public UILabel NJHBBJMPGJI;

	public GameObject BFJBIABFJDL;

	public UISprite LEEACGFHPIN;

	public UILabel AHJLEEHJKDG;

	public UISprite LLNJNOKFFFN;

	[Header("-Arena")]
	public GameObject IGIENAGNFEO;

	public UISprite PMMNANLHKNH;

	[Header("-Equiped")]
	public UISprite IMGOIFHGPAB;

	[Header("---Locked")]
	public GameObject IAPMLEKENDK;

	public UILabel IAPCGDFOJNP;

	[Header("---Not Bought")]
	public GameObject ICIECPEDMIG;

	public UISprite AAMOJLNJNGN;

	public UISprite OPFDLJKGPON;

	[Header("---Power Band Info")]
	public GameObject BCFOLGJLFDP;

	public UILabel JBCBEOCNJBH;

	public UISprite FIHDDPJFFDG;

	[Header("---Rented")]
	public UILabel EKGIJFHNFIG;

	[Header("-Sale")]
	public GameObject GIPFEBBMKPM;

	[Header("-Notification")]
	public GameObject KHJBFBDODGM;

	private PlayerVisual HHOJADAAMGF;

	public PlayerVisual visual
	{
		get
		{
			return HHOJADAAMGF;
		}
	}

	public void KOHOPHJAAFN(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	internal void AEODKKBKHKF()
	{
		bool isEquipped = HHOJADAAMGF.isEquipped;
		KMFGCJEGJJK.color = (isEquipped ? Colours.blueEquipped : ((!HHOJADAAMGF.purchasableInShop && !HHOJADAAMGF.FICMIKMIMBJ()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!isEquipped) ? 1799f : 1761f);
	}

	internal void HJJNLJJIPNC()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool purchasableInShop = HHOJADAAMGF.purchasableInShop;
		bool flag = HHOJADAAMGF.FICMIKMIMBJ();
		bool flag2 = isBought || HHOJADAAMGF.numberOfParts > 1;
		bool flag3 = HHOJADAAMGF.JGEBIPKGFKA() && HHOJADAAMGF.owner.categoryNumber > 0;
		BFJBIABFJDL.SetActive(!purchasableInShop || flag3);
		LLNJNOKFFFN.gameObject.SetActive(isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 521f : 1674f);
		NJHBBJMPGJI.gameObject.SetActive(flag2);
		if (flag2)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[5];
			array[1] = CMMAMCJKEOG().numberOfParts;
			array[1] = Colours.stringGrayParts;
			array[6] = Colours.stringWhite;
			array[4] = IGAJLHIBODL().numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format("Getting gameConfig: Offset = ", array);
		}
		ANODBGELEBJ.SetActive(!isBought && !purchasableInShop && flag);
		GGAGNFHKEAN();
		FLMPFEEEJLN();
		IGIENAGNFEO.SetActive(flag);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	internal void GEHIJOGHJDH()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool flag = HHOJADAAMGF.LLDLKAEIJKP();
		bool flag2 = HHOJADAAMGF.FICMIKMIMBJ();
		bool flag3 = !isBought && HHOJADAAMGF.numberOfParts > 0;
		bool flag4 = !HHOJADAAMGF.JGEBIPKGFKA() || HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(!flag || !flag4);
		LLNJNOKFFFN.gameObject.SetActive(isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 1425f : 1976f);
		NJHBBJMPGJI.gameObject.SetActive(flag3);
		if (flag3)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[8];
			array[1] = BLNNEECJDMB().numberOfParts;
			array[0] = Colours.stringGrayParts;
			array[5] = Colours.stringWhite;
			array[1] = HHBCPNFOGBI().GMLFJPOEEAO();
			nJHBBJMPGJI.text = string.Format("A", array);
		}
		ANODBGELEBJ.SetActive(isBought || flag || flag2);
		FPPJHLCLBKL();
		LPEPBHOFDMN();
		IGIENAGNFEO.SetActive(flag2);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	public void JLFHNIOJOAE(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void GALNDBOBJPL(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void POGCLFHNNEE(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void IOCLNENHNLE()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.ICIFNECPCLK(this);
		FCPOKCLHCKH();
	}

	internal void AKLDBJHIIAO()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool purchasableInShop = HHOJADAAMGF.purchasableInShop;
		bool flag = HHOJADAAMGF.NIAGCEJGCIL();
		bool flag2 = isBought || HHOJADAAMGF.numberOfParts > 0;
		bool flag3 = !HHOJADAAMGF.JGEBIPKGFKA() || HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(!purchasableInShop || flag3);
		LLNJNOKFFFN.gameObject.SetActive(!isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 134f : 1142f);
		NJHBBJMPGJI.gameObject.SetActive(flag2);
		if (flag2)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[7];
			array[1] = DFMPCEKHNDG().numberOfParts;
			array[0] = Colours.stringGrayParts;
			array[8] = Colours.stringWhite;
			array[6] = AEDBCCKEEGK().numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format("Gunslinger", array);
		}
		ANODBGELEBJ.SetActive(!isBought && !purchasableInShop && !flag);
		JOLGMBIAPJB();
		ABNAJEIPMDF();
		IGIENAGNFEO.SetActive(flag);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	public void BIJAPDEFEDM(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	[SpecialName]
	public PlayerVisual CMMAMCJKEOG()
	{
		return HHOJADAAMGF;
	}

	public void DDMCPNFAKIE()
	{
		GEHIJOGHJDH();
	}

	internal void FCPOKCLHCKH()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	private void FLDCHPBPKND()
	{
		if (IGAJLHIBODL() != null && AEDBCCKEEGK().isFromArena && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(POMMLFHPFPI().isBought);
		}
	}

	private void Update()
	{
		if (visual != null && visual.isFromArena && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(!visual.isBought);
		}
	}

	internal void ALIGDJPNPBN()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool purchasableInShop = HHOJADAAMGF.purchasableInShop;
		bool flag = HHOJADAAMGF.FICMIKMIMBJ();
		bool flag2 = !isBought && HHOJADAAMGF.numberOfParts > 0;
		bool flag3 = HHOJADAAMGF.JGEBIPKGFKA() && HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(purchasableInShop && !flag3);
		LLNJNOKFFFN.gameObject.SetActive(isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 1766f : 886f);
		NJHBBJMPGJI.gameObject.SetActive(flag2);
		if (flag2)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[6];
			array[0] = NHFDAOOICLK().numberOfParts;
			array[1] = Colours.stringGrayParts;
			array[6] = Colours.stringWhite;
			array[5] = BLNNEECJDMB().numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format("_Existing_User", array);
		}
		ANODBGELEBJ.SetActive(isBought || purchasableInShop || flag);
		BMMPLBGAIEK();
		NHANPMAEBKE();
		IGIENAGNFEO.SetActive(flag);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	public void LEIJLADCFBH()
	{
		JPEELFFLOMG();
	}

	private void LPFGBKIINMP()
	{
		if (POMMLFHPFPI() != null && KFHOAJEFFEL().isFromArena && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(!HHBCPNFOGBI().isBought);
		}
	}

	public void Initialize(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool purchasableInShop = DJOAHABGGNA.purchasableInShop;
		bool isFromArena = DJOAHABGGNA.isFromArena;
		int num = 2;
		if (purchasableInShop)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax > 0) ? 3 : 0);
		}
		else if (isFromArena)
		{
			num = 1;
		}
		int num2 = 2;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 0)
		{
			num2 = 1;
		}
		base.gameObject.name = string.Format("{0} {1} {2} {3}", num, num2, (int)DJOAHABGGNA.rarity, DJOAHABGGNA.id);
		JAJCFNOIBPM.gameObject.SetActive(false);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(false);
		EKGIJFHNFIG.gameObject.SetActive(false);
		BCFOLGJLFDP.SetActive(false);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(true);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 200f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 200f) / 2f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.rarity];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(0.5f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 30f, 20f, 212);
		SetHighlight(false);
		IHCIGBPKKKD();
		InitGuiValuesGraphics();
	}

	public void NHANPMAEBKE()
	{
		GIPFEBBMKPM.SetActive(false);
	}

	private void BCFIPPHODCL()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.ICIFNECPCLK(this);
		DKPHDOMNDCG();
	}

	internal void MPMBHJNBEAL()
	{
		bool isEquipped = HHOJADAAMGF.isEquipped;
		KMFGCJEGJJK.color = (isEquipped ? Colours.blueEquipped : ((!HHOJADAAMGF.purchasableInShop && !HHOJADAAMGF.NIAGCEJGCIL()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!isEquipped) ? 1443f : 854f);
	}

	public void CMAKBEPLANA(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void DIFNPMABNCI(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void IHMEAAIKGAP(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool purchasableInShop = DJOAHABGGNA.purchasableInShop;
		bool flag = DJOAHABGGNA.NIAGCEJGCIL();
		int num = 3;
		if (purchasableInShop)
		{
			num = ((DJOAHABGGNA.GMLFJPOEEAO() <= 0) ? 1 : 8);
		}
		else if (flag)
		{
			num = 1;
		}
		int num2 = 2;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 1;
		}
		else if (DJOAHABGGNA.numberOfParts > 0)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[7];
		array[1] = num;
		array[1] = num2;
		array[1] = (int)DJOAHABGGNA.rarity;
		array[5] = DJOAHABGGNA.CCDMONFHBII();
		obj.name = string.Format("VisualTimestamp", array);
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(true);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(false);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1151f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 586f) / 1302f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.GFOLGKEMPPN()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(448f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1000f, 979f, 103);
		DIFNPMABNCI(true);
		FLIOLKAOFAI();
		GIPFBAKFCJN();
	}

	internal void NKMCIDLCHEA()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	public void ALODEAALJAH(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool isFromArena = DJOAHABGGNA.isFromArena;
		int num = 1;
		if (flag)
		{
			num = ((DJOAHABGGNA.GMLFJPOEEAO() <= 1) ? 1 : 3);
		}
		else if (isFromArena)
		{
			num = 1;
		}
		int num2 = 0;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		base.gameObject.name = string.Format("ID_SQUADSIZEINCREASEATSQUADRANK", num, num2, null, null, (int)DJOAHABGGNA.DOJECMCGMKB(), null, null, DJOAHABGGNA.CCDMONFHBII());
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(false);
		BCFOLGJLFDP.SetActive(false);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1390f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 1572f) / 1080f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(964f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.GDNDBMKBECH() : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1738f, 838f, 85);
		POGCLFHNNEE(true);
		OBHOONKHLOB();
		GIPFBAKFCJN();
	}

	public void HMKEGKBHILJ()
	{
		PDLMIBCLICE();
	}

	internal void JPEELFFLOMG()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool purchasableInShop = HHOJADAAMGF.purchasableInShop;
		bool isFromArena = HHOJADAAMGF.isFromArena;
		bool flag = !isBought && HHOJADAAMGF.numberOfParts > 0;
		bool flag2 = !HHOJADAAMGF.isDefault || HHOJADAAMGF.owner.categoryNumber > 0;
		BFJBIABFJDL.SetActive(!purchasableInShop || !flag2);
		LLNJNOKFFFN.gameObject.SetActive(!isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 399f : 1499f);
		NJHBBJMPGJI.gameObject.SetActive(flag);
		if (flag)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[6];
			array[1] = HHBCPNFOGBI().numberOfParts;
			array[0] = Colours.stringGrayParts;
			array[2] = Colours.stringWhite;
			array[7] = NHFDAOOICLK().numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format("ID_READYTIME", array);
		}
		ANODBGELEBJ.SetActive(!isBought && !purchasableInShop && !isFromArena);
		FPPJHLCLBKL();
		FLMPFEEEJLN();
		IGIENAGNFEO.SetActive(isFromArena);
		PMMNANLHKNH.gameObject.SetActive(!isBought);
	}

	internal void LODINCOFCMK()
	{
		bool isEquipped = HHOJADAAMGF.isEquipped;
		KMFGCJEGJJK.color = (isEquipped ? Colours.blueEquipped : ((!HHOJADAAMGF.LLDLKAEIJKP() && !HHOJADAAMGF.NIAGCEJGCIL()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!isEquipped) ? 528f : 603f);
	}

	public void FLMPFEEEJLN()
	{
		GIPFEBBMKPM.SetActive(false);
	}

	internal void ELOFJACBEEG()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool flag = HHOJADAAMGF.LLDLKAEIJKP();
		bool flag2 = HHOJADAAMGF.NIAGCEJGCIL();
		bool flag3 = !isBought && HHOJADAAMGF.numberOfParts > 1;
		bool flag4 = !HHOJADAAMGF.JGEBIPKGFKA() || HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(flag && !flag4);
		LLNJNOKFFFN.gameObject.SetActive(!isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 55f : 1003f);
		NJHBBJMPGJI.gameObject.SetActive(flag3);
		if (flag3)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[8];
			array[0] = DFMPCEKHNDG().numberOfParts;
			array[0] = Colours.stringGrayParts;
			array[8] = Colours.stringWhite;
			array[3] = AEDBCCKEEGK().numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format("game-card-ico-healingstorm", array);
		}
		ANODBGELEBJ.SetActive(isBought || flag || flag2);
		HNJNFMHBBHG();
		ABNAJEIPMDF();
		IGIENAGNFEO.SetActive(flag2);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	internal void HNJNFMHBBHG()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	public void ABNAJEIPMDF()
	{
		GIPFEBBMKPM.SetActive(true);
	}

	public void NBOODHLLBAA(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool flag2 = DJOAHABGGNA.FICMIKMIMBJ();
		int num = 2;
		if (flag)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax <= 0) ? 0 : 0);
		}
		else if (flag2)
		{
			num = 0;
		}
		int num2 = 4;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[8];
		array[1] = num;
		array[0] = num2;
		array[0] = (int)DJOAHABGGNA.GFOLGKEMPPN();
		array[5] = DJOAHABGGNA.id;
		obj.name = string.Format("VipReward2", array);
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(false);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(false);
		IGIENAGNFEO.SetActive(true);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1668f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 1183f) / 1989f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.GFOLGKEMPPN()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1314f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 1) ? DJOAHABGGNA.GDNDBMKBECH() : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 453f, 829f, -34);
		KOHOPHJAAFN(false);
		FGIPDIDEEIP();
		MPEIOHPLHEM();
	}

	private void DDOAMLFCMMO()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.ICIFNECPCLK(this);
		BMMPLBGAIEK();
	}

	[SpecialName]
	public PlayerVisual KFHOAJEFFEL()
	{
		return HHOJADAAMGF;
	}

	internal void LBBKAPJIENH()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	internal void NAAGKCKKMID()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool flag = HHOJADAAMGF.LLDLKAEIJKP();
		bool isFromArena = HHOJADAAMGF.isFromArena;
		bool flag2 = isBought || HHOJADAAMGF.numberOfParts > 0;
		bool flag3 = !HHOJADAAMGF.isDefault || HHOJADAAMGF.owner.categoryNumber > 0;
		BFJBIABFJDL.SetActive(!flag || flag3);
		LLNJNOKFFFN.gameObject.SetActive(isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 1258f : 1887f);
		NJHBBJMPGJI.gameObject.SetActive(flag2);
		if (flag2)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[7];
			array[1] = NHFDAOOICLK().numberOfParts;
			array[0] = Colours.stringGrayParts;
			array[4] = Colours.stringWhite;
			array[4] = CMMAMCJKEOG().GMLFJPOEEAO();
			nJHBBJMPGJI.text = string.Format("BeginnersLeagueEntered", array);
		}
		ANODBGELEBJ.SetActive(isBought || flag || isFromArena);
		GGAGNFHKEAN();
		NGCGMHGELCF();
		IGIENAGNFEO.SetActive(isFromArena);
		PMMNANLHKNH.gameObject.SetActive(!isBought);
	}

	private void BAHDLPDOCDO()
	{
		if (MOKNNJGNIOB() != null && IPIFODODJHK().FICMIKMIMBJ() && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(!NHFDAOOICLK().isBought);
		}
	}

	private void PMOIOADCKPO()
	{
		if (DFMPCEKHNDG() != null && CMMAMCJKEOG().FICMIKMIMBJ() && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(KFHOAJEFFEL().isBought);
		}
	}

	public void CMOHGKPENIJ(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool isFromArena = DJOAHABGGNA.isFromArena;
		int num = 1;
		if (flag)
		{
			num = ((DJOAHABGGNA.GMLFJPOEEAO() > 1) ? 3 : 0);
		}
		else if (isFromArena)
		{
			num = 1;
		}
		int num2 = 0;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 1;
		}
		else if (DJOAHABGGNA.numberOfParts > 0)
		{
			num2 = 1;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[4];
		array[0] = num;
		array[1] = num2;
		array[5] = (int)DJOAHABGGNA.rarity;
		array[5] = DJOAHABGGNA.CCDMONFHBII();
		obj.name = string.Format("()Z", array);
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(true);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(true);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 459f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 355f) / 46f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(161f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1143f, 368f, -68);
		JLFHNIOJOAE(false);
		FLIOLKAOFAI();
		BNBFBIPGHIK();
	}

	internal void GJAGBMPLFGL()
	{
		bool isEquipped = HHOJADAAMGF.isEquipped;
		KMFGCJEGJJK.color = (isEquipped ? Colours.blueEquipped : ((!HHOJADAAMGF.LLDLKAEIJKP() && !HHOJADAAMGF.NIAGCEJGCIL()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!isEquipped) ? 1960f : 623f);
	}

	public void OMCNLOHKCBJ(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool flag2 = DJOAHABGGNA.FICMIKMIMBJ();
		int num = 6;
		if (flag)
		{
			num = ((DJOAHABGGNA.GMLFJPOEEAO() > 0) ? 6 : 0);
		}
		else if (flag2)
		{
			num = 0;
		}
		int num2 = 0;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[0];
		array[1] = num;
		array[0] = num2;
		array[8] = (int)DJOAHABGGNA.DOJECMCGMKB();
		array[2] = DJOAHABGGNA.id;
		obj.name = string.Format("InAppHandlerIos: Purchase failed! ", array);
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(true);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1024f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 1103f) / 1347f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1799f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.JGEBIPKGFKA() || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.GDNDBMKBECH() : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1404f, 546f, 174);
		BIJAPDEFEDM(false);
		MPMBHJNBEAL();
		InitGuiValuesGraphics();
	}

	public void HGIMHKNPAAF()
	{
		GIPFEBBMKPM.SetActive(true);
	}

	internal void IHJCGOANEFE()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool purchasableInShop = HHOJADAAMGF.purchasableInShop;
		bool isFromArena = HHOJADAAMGF.isFromArena;
		bool flag = !isBought && HHOJADAAMGF.numberOfParts > 0;
		bool flag2 = HHOJADAAMGF.isDefault && HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(!purchasableInShop || flag2);
		LLNJNOKFFFN.gameObject.SetActive(isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 1725f : 396f);
		NJHBBJMPGJI.gameObject.SetActive(flag);
		if (flag)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[5];
			array[1] = IGAJLHIBODL().numberOfParts;
			array[1] = Colours.stringGrayParts;
			array[5] = Colours.stringWhite;
			array[8] = visual.numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format("Manual_Unit_Spawn", array);
		}
		ANODBGELEBJ.SetActive(!isBought && !purchasableInShop && isFromArena);
		PLJPNGPJMCL();
		KBGGHDBFHGD();
		IGIENAGNFEO.SetActive(isFromArena);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	private void MMCNCJPBOCH()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.Select(this);
		HNJNFMHBBHG();
	}

	internal void GGAGNFHKEAN()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.NotificationForVisual(HHOJADAAMGF));
	}

	public void SetSale()
	{
		GIPFEBBMKPM.SetActive(false);
	}

	internal void CMKDMHKJCGP()
	{
		bool flag = HHOJADAAMGF.BCPLNFLOIAD();
		KMFGCJEGJJK.color = (flag ? Colours.blueEquipped : ((!HHOJADAAMGF.purchasableInShop && !HHOJADAAMGF.FICMIKMIMBJ()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!flag) ? 307f : 1765f);
	}

	private void OnClick()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.Select(this);
		JOLGMBIAPJB();
	}

	public void JMLMMFOCKCN(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool flag2 = DJOAHABGGNA.NIAGCEJGCIL();
		int num = 5;
		if (flag)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax <= 1) ? 1 : 2);
		}
		else if (flag2)
		{
			num = 0;
		}
		int num2 = 6;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[5];
		array[1] = num;
		array[0] = num2;
		array[6] = (int)DJOAHABGGNA.DOJECMCGMKB();
		array[1] = DJOAHABGGNA.CCDMONFHBII();
		obj.name = string.Format("N", array);
		JAJCFNOIBPM.gameObject.SetActive(false);
		IAPMLEKENDK.SetActive(true);
		ICIECPEDMIG.SetActive(false);
		EKGIJFHNFIG.gameObject.SetActive(false);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(true);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1647f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 406f) / 1900f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.rarity];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1599f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.JGEBIPKGFKA() || DJOAHABGGNA.owner.categoryNumber <= 1) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 713f, 732f, -137);
		SetHighlight(false);
		GOBOGKADMOO();
		BNBFBIPGHIK();
	}

	internal void BMMPLBGAIEK()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	private void BAAPLPFMBJB()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.ICIFNECPCLK(this);
		HNJNFMHBBHG();
	}

	internal void FPPJHLCLBKL()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	public void FANFNOPNGBL(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool isFromArena = DJOAHABGGNA.isFromArena;
		int num = 8;
		if (flag)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax > 1) ? 3 : 0);
		}
		else if (isFromArena)
		{
			num = 1;
		}
		int num2 = 2;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 0)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[7];
		array[1] = num;
		array[1] = num2;
		array[4] = (int)DJOAHABGGNA.rarity;
		array[8] = DJOAHABGGNA.id;
		obj.name = string.Format("SERVICE_MISSING_PERMISSION", array);
		JAJCFNOIBPM.gameObject.SetActive(false);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(false);
		EKGIJFHNFIG.gameObject.SetActive(false);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 266f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 294f) / 730f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(364f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 1) ? DJOAHABGGNA.GDNDBMKBECH() : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 176f, 919f, 142);
		BIJAPDEFEDM(true);
		AEODKKBKHKF();
		IFFMLDHMMEH();
	}

	public void IFFMLDHMMEH()
	{
		GEHIJOGHJDH();
	}

	public void KBPMGOALFCE(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void IEMFGBCBAAJ(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool purchasableInShop = DJOAHABGGNA.purchasableInShop;
		bool flag = DJOAHABGGNA.NIAGCEJGCIL();
		int num = 3;
		if (purchasableInShop)
		{
			num = ((DJOAHABGGNA.GMLFJPOEEAO() <= 0) ? 1 : 6);
		}
		else if (flag)
		{
			num = 0;
		}
		int num2 = 2;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 0)
		{
			num2 = 1;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[8];
		array[0] = num;
		array[1] = num2;
		array[0] = (int)DJOAHABGGNA.GFOLGKEMPPN();
		array[7] = DJOAHABGGNA.id;
		obj.name = string.Format("S", array);
		JAJCFNOIBPM.gameObject.SetActive(false);
		IAPMLEKENDK.SetActive(true);
		ICIECPEDMIG.SetActive(false);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(false);
		IGIENAGNFEO.SetActive(true);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1126f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 1917f) / 1192f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1481f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.JGEBIPKGFKA() || DJOAHABGGNA.owner.categoryNumber <= 1) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1047f, 1835f, -98);
		SetHighlight(false);
		GJAGBMPLFGL();
		HCINJCAEMON();
	}

	public void GIPFBAKFCJN()
	{
		HJJNLJJIPNC();
	}

	private void MHCJJBCHEKG()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.Select(this);
		GGAGNFHKEAN();
	}

	public void BMOABCDKNJB(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void GBCFOFKPPJP(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool flag2 = DJOAHABGGNA.NIAGCEJGCIL();
		int num = 3;
		if (flag)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax <= 0) ? 1 : 6);
		}
		else if (flag2)
		{
			num = 1;
		}
		int num2 = 6;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 0)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[7];
		array[1] = num;
		array[0] = num2;
		array[1] = (int)DJOAHABGGNA.GFOLGKEMPPN();
		array[7] = DJOAHABGGNA.id;
		obj.name = string.Format("LevelName", array);
		JAJCFNOIBPM.gameObject.SetActive(false);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(false);
		EKGIJFHNFIG.gameObject.SetActive(false);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(true);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 666f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 1926f) / 117f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1664f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1533f, 403f, -163);
		DNHOHNOJHCM(false);
		OBHOONKHLOB();
		BNBFBIPGHIK();
	}

	public void NEIGIFMCCAE(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool flag2 = DJOAHABGGNA.FICMIKMIMBJ();
		int num = 2;
		if (flag)
		{
			num = ((DJOAHABGGNA.GMLFJPOEEAO() <= 1) ? 1 : 0);
		}
		else if (flag2)
		{
			num = 1;
		}
		int num2 = 7;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 1;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[2];
		array[1] = num;
		array[0] = num2;
		array[0] = (int)DJOAHABGGNA.DOJECMCGMKB();
		array[3] = DJOAHABGGNA.id;
		obj.name = string.Format("add", array);
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(true);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(true);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 718f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 311f) / 1860f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1381f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.GDNDBMKBECH() : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1500f, 990f, -74);
		SetHighlight(false);
		AEODKKBKHKF();
		BNBFBIPGHIK();
	}

	internal void AEOLLMIMGPA()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	internal void GOBOGKADMOO()
	{
		bool flag = HHOJADAAMGF.BCPLNFLOIAD();
		KMFGCJEGJJK.color = (flag ? Colours.blueEquipped : ((!HHOJADAAMGF.purchasableInShop && !HHOJADAAMGF.NIAGCEJGCIL()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!flag) ? 1700f : 61f);
	}

	public void LPEPBHOFDMN()
	{
		GIPFEBBMKPM.SetActive(true);
	}

	private void NHEOMLPEBLC()
	{
		if (MOKNNJGNIOB() != null && BLNNEECJDMB().FICMIKMIMBJ() && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(!AEDBCCKEEGK().isBought);
		}
	}

	internal void PDLMIBCLICE()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool flag = HHOJADAAMGF.LLDLKAEIJKP();
		bool flag2 = HHOJADAAMGF.NIAGCEJGCIL();
		bool flag3 = !isBought && HHOJADAAMGF.numberOfParts > 0;
		bool flag4 = HHOJADAAMGF.JGEBIPKGFKA() && HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(!flag || flag4);
		LLNJNOKFFFN.gameObject.SetActive(!isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 1213f : 905f);
		NJHBBJMPGJI.gameObject.SetActive(flag3);
		if (flag3)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[4];
			array[1] = KFHOAJEFFEL().numberOfParts;
			array[0] = Colours.stringGrayParts;
			array[5] = Colours.stringWhite;
			array[1] = NHFDAOOICLK().GMLFJPOEEAO();
			nJHBBJMPGJI.text = string.Format("Tickets:  {0}\n", array);
		}
		ANODBGELEBJ.SetActive(isBought || flag || !flag2);
		FCPOKCLHCKH();
		NGCGMHGELCF();
		IGIENAGNFEO.SetActive(flag2);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	public void KKIAFIBAAIL()
	{
		IHLMCCFGAMI();
	}

	[SpecialName]
	public PlayerVisual NHFDAOOICLK()
	{
		return HHOJADAAMGF;
	}

	public void MPEIOHPLHEM()
	{
		HJJNLJJIPNC();
	}

	public void KBGGHDBFHGD()
	{
		GIPFEBBMKPM.SetActive(true);
	}

	internal void HKOFGKGCCOG()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool flag = HHOJADAAMGF.LLDLKAEIJKP();
		bool flag2 = HHOJADAAMGF.NIAGCEJGCIL();
		bool flag3 = !isBought && HHOJADAAMGF.numberOfParts > 1;
		bool flag4 = !HHOJADAAMGF.JGEBIPKGFKA() || HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(flag && flag4);
		LLNJNOKFFFN.gameObject.SetActive(!isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 1689f : 356f);
		NJHBBJMPGJI.gameObject.SetActive(flag3);
		if (flag3)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[3];
			array[0] = POMMLFHPFPI().numberOfParts;
			array[0] = Colours.stringGrayParts;
			array[1] = Colours.stringWhite;
			array[3] = POMMLFHPFPI().numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format(", val = ", array);
		}
		ANODBGELEBJ.SetActive(!isBought && !flag && !flag2);
		DKPHDOMNDCG();
		NGCGMHGELCF();
		IGIENAGNFEO.SetActive(flag2);
		PMMNANLHKNH.gameObject.SetActive(isBought);
	}

	public void NDIJBPIDGOF(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool purchasableInShop = DJOAHABGGNA.purchasableInShop;
		bool flag = DJOAHABGGNA.NIAGCEJGCIL();
		int num = 6;
		if (purchasableInShop)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax > 1) ? 1 : 0);
		}
		else if (flag)
		{
			num = 1;
		}
		int num2 = 2;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 1;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[4];
		array[0] = num;
		array[1] = num2;
		array[2] = (int)DJOAHABGGNA.rarity;
		array[7] = DJOAHABGGNA.CCDMONFHBII();
		obj.name = string.Format("#PETER# Start of lootbox coroutine", array);
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1663f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 236f) / 487f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(236f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 1135f, 550f, -21);
		DIFNPMABNCI(true);
		FGIPDIDEEIP();
		MPEIOHPLHEM();
	}

	public void HCINJCAEMON()
	{
		IHLMCCFGAMI();
	}

	internal void CLNFHCHFEAD()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool purchasableInShop = HHOJADAAMGF.purchasableInShop;
		bool isFromArena = HHOJADAAMGF.isFromArena;
		bool flag = !isBought && HHOJADAAMGF.numberOfParts > 0;
		bool flag2 = HHOJADAAMGF.isDefault && HHOJADAAMGF.owner.categoryNumber > 0;
		BFJBIABFJDL.SetActive(purchasableInShop && !flag2);
		LLNJNOKFFFN.gameObject.SetActive(!isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 24f : 0f);
		NJHBBJMPGJI.gameObject.SetActive(flag);
		if (flag)
		{
			NJHBBJMPGJI.text = string.Format("{0}{1}/{2}{3}", visual.numberOfParts, Colours.stringGrayParts, Colours.stringWhite, visual.numberOfPartsMax);
		}
		ANODBGELEBJ.SetActive(!isBought && !purchasableInShop && !isFromArena);
		JOLGMBIAPJB();
		SetSale();
		IGIENAGNFEO.SetActive(isFromArena);
		PMMNANLHKNH.gameObject.SetActive(!isBought);
	}

	public void HBDEPMJNLEK(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool purchasableInShop = DJOAHABGGNA.purchasableInShop;
		bool isFromArena = DJOAHABGGNA.isFromArena;
		int num = 0;
		if (purchasableInShop)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax <= 1) ? 1 : 4);
		}
		else if (isFromArena)
		{
			num = 0;
		}
		int num2 = 3;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 0)
		{
			num2 = 1;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[2];
		array[1] = num;
		array[1] = num2;
		array[8] = (int)DJOAHABGGNA.rarity;
		array[8] = DJOAHABGGNA.id;
		obj.name = string.Format("About to show Buy Cards Reminder", array);
		JAJCFNOIBPM.gameObject.SetActive(false);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(false);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(true);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 1040f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 435f) / 175f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1338f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.JGEBIPKGFKA() || DJOAHABGGNA.owner.categoryNumber <= 1) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 131f, 1531f, -39);
		POGCLFHNNEE(true);
		GJAGBMPLFGL();
		DDMCPNFAKIE();
	}

	[SpecialName]
	public PlayerVisual IGAJLHIBODL()
	{
		return HHOJADAAMGF;
	}

	private void ELJHCOHCAJI()
	{
		if (IGAJLHIBODL() != null && IGAJLHIBODL().FICMIKMIMBJ() && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(visual.isBought);
		}
	}

	[SpecialName]
	public PlayerVisual BLNNEECJDMB()
	{
		return HHOJADAAMGF;
	}

	public void NFAEFKKCAGE()
	{
		GEHIJOGHJDH();
	}

	internal void JOLGMBIAPJB()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.NotificationForVisual(HHOJADAAMGF));
	}

	public void DCMMEGPBEHD()
	{
		GIPFEBBMKPM.SetActive(true);
	}

	internal void GFJAJMOFDBP()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool flag = HHOJADAAMGF.LLDLKAEIJKP();
		bool isFromArena = HHOJADAAMGF.isFromArena;
		bool flag2 = isBought || HHOJADAAMGF.numberOfParts > 0;
		bool flag3 = HHOJADAAMGF.isDefault && HHOJADAAMGF.owner.categoryNumber > 0;
		BFJBIABFJDL.SetActive(flag && flag3);
		LLNJNOKFFFN.gameObject.SetActive(isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 425f : 1596f);
		NJHBBJMPGJI.gameObject.SetActive(flag2);
		if (flag2)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[0];
			array[0] = BLNNEECJDMB().numberOfParts;
			array[1] = Colours.stringGrayParts;
			array[0] = Colours.stringWhite;
			array[7] = IGAJLHIBODL().GMLFJPOEEAO();
			nJHBBJMPGJI.text = string.Format("PlayerName", array);
		}
		ANODBGELEBJ.SetActive(!isBought && !flag && !isFromArena);
		GGAGNFHKEAN();
		FLMPFEEEJLN();
		IGIENAGNFEO.SetActive(isFromArena);
		PMMNANLHKNH.gameObject.SetActive(!isBought);
	}

	private void ILPHFGBPAKM()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.ICIFNECPCLK(this);
		LBBKAPJIENH();
	}

	[SpecialName]
	public PlayerVisual POMMLFHPFPI()
	{
		return HHOJADAAMGF;
	}

	internal void FGIPDIDEEIP()
	{
		bool isEquipped = HHOJADAAMGF.isEquipped;
		KMFGCJEGJJK.color = (isEquipped ? Colours.blueEquipped : ((!HHOJADAAMGF.LLDLKAEIJKP() && !HHOJADAAMGF.FICMIKMIMBJ()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!isEquipped) ? 564f : 1123f);
	}

	internal void PLJPNGPJMCL()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.OBGMLFNHACP(HHOJADAAMGF));
	}

	internal void DKPHDOMNDCG()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.NotificationForVisual(HHOJADAAMGF));
	}

	public void FJLJLDNCBBD(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool purchasableInShop = DJOAHABGGNA.purchasableInShop;
		bool flag = DJOAHABGGNA.NIAGCEJGCIL();
		int num = 4;
		if (purchasableInShop)
		{
			num = ((DJOAHABGGNA.numberOfPartsMax > 0) ? 2 : 0);
		}
		else if (flag)
		{
			num = 0;
		}
		int num2 = 3;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 0;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[4];
		array[1] = num;
		array[1] = num2;
		array[8] = (int)DJOAHABGGNA.DOJECMCGMKB();
		array[3] = DJOAHABGGNA.CCDMONFHBII();
		obj.name = string.Format("S", array);
		JAJCFNOIBPM.gameObject.SetActive(true);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(false);
		EKGIJFHNFIG.gameObject.SetActive(false);
		BCFOLGJLFDP.SetActive(true);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(false);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 408f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 1349f) / 913f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.GFOLGKEMPPN()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(4f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.JGEBIPKGFKA() || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.rarityName : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 23f, 612f, -159);
		KBPMGOALFCE(true);
		GJAGBMPLFGL();
		PPNFBNHGCLA();
	}

	[SpecialName]
	public PlayerVisual IPIFODODJHK()
	{
		return HHOJADAAMGF;
	}

	[SpecialName]
	public PlayerVisual AEDBCCKEEGK()
	{
		return HHOJADAAMGF;
	}

	public void NGCGMHGELCF()
	{
		GIPFEBBMKPM.SetActive(false);
	}

	internal void PIIOHBJLLID()
	{
		KHJBFBDODGM.SetActive(Singleton<NotificationManager>.instance.NotificationForVisual(HHOJADAAMGF));
	}

	public void IDFKAAHDJHL()
	{
		GIPFEBBMKPM.SetActive(true);
	}

	public void SetHighlight(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void LCBBILLHHPI()
	{
		if (DFMPCEKHNDG() != null && DFMPCEKHNDG().FICMIKMIMBJ() && !PMMNANLHKNH.gameObject.activeSelf)
		{
			PMMNANLHKNH.gameObject.SetActive(!MOKNNJGNIOB().isBought);
		}
	}

	[SpecialName]
	public PlayerVisual HHBCPNFOGBI()
	{
		return HHOJADAAMGF;
	}

	internal void OBHOONKHLOB()
	{
		bool flag = HHOJADAAMGF.BCPLNFLOIAD();
		KMFGCJEGJJK.color = (flag ? Colours.blueEquipped : ((!HHOJADAAMGF.purchasableInShop && !HHOJADAAMGF.isFromArena) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!flag) ? 997f : 165f);
	}

	[SpecialName]
	public PlayerVisual DFMPCEKHNDG()
	{
		return HHOJADAAMGF;
	}

	public void BGCBCFJEKEH(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void BCOFLPMCBFJ(PlayerVisual DJOAHABGGNA)
	{
		HHOJADAAMGF = DJOAHABGGNA;
		bool flag = DJOAHABGGNA.LLDLKAEIJKP();
		bool isFromArena = DJOAHABGGNA.isFromArena;
		int num = 6;
		if (flag)
		{
			num = ((DJOAHABGGNA.GMLFJPOEEAO() <= 0) ? 1 : 0);
		}
		else if (isFromArena)
		{
			num = 1;
		}
		int num2 = 5;
		if (DJOAHABGGNA.isBought)
		{
			num2 = 1;
		}
		else if (DJOAHABGGNA.numberOfParts > 1)
		{
			num2 = 0;
		}
		GameObject obj = base.gameObject;
		object[] array = new object[8];
		array[1] = num;
		array[0] = num2;
		array[3] = (int)DJOAHABGGNA.GFOLGKEMPPN();
		array[6] = DJOAHABGGNA.id;
		obj.name = string.Format("ID_STARTERASSIGNMENT", array);
		JAJCFNOIBPM.gameObject.SetActive(false);
		IAPMLEKENDK.SetActive(false);
		ICIECPEDMIG.SetActive(true);
		EKGIJFHNFIG.gameObject.SetActive(true);
		BCFOLGJLFDP.SetActive(false);
		IGIENAGNFEO.SetActive(false);
		DAANKCOLJGJ.gameObject.SetActive(true);
		DAANKCOLJGJ.spriteName = DJOAHABGGNA.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		if (DAANKCOLJGJ.transform.localScale.y > 551f)
		{
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((DAANKCOLJGJ.transform.localScale.y - 282f) / 1998f);
		}
		NJHBBJMPGJI.color = GameVariables.DDCPLFNIJDN[DJOAHABGGNA.DOJECMCGMKB()];
		LEEACGFHPIN.color = NJHBBJMPGJI.color.ReplaceA(1077f);
		AHJLEEHJKDG.text = ((!DJOAHABGGNA.isDefault || DJOAHABGGNA.owner.categoryNumber <= 0) ? DJOAHABGGNA.GDNDBMKBECH() : string.Empty);
		MEJMLNDFDBP.COCBCFKJOJE(AHJLEEHJKDG, 886f, 410f, 125);
		JLFHNIOJOAE(true);
		CMKDMHKJCGP();
		KKIAFIBAAIL();
	}

	internal void IHCIGBPKKKD()
	{
		bool isEquipped = HHOJADAAMGF.isEquipped;
		KMFGCJEGJJK.color = (isEquipped ? Colours.blueEquipped : ((!HHOJADAAMGF.purchasableInShop && !HHOJADAAMGF.isFromArena) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!isEquipped) ? 0f : 1f);
	}

	public void InitGuiValuesGraphics()
	{
		CLNFHCHFEAD();
	}

	public void DNHOHNOJHCM(bool NCFKLBGOEEF)
	{
		LCPBNBLGFIA.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void PMANEOFCMMP()
	{
		GIPFEBBMKPM.SetActive(true);
	}

	internal void IHLMCCFGAMI()
	{
		bool isBought = HHOJADAAMGF.isBought;
		bool purchasableInShop = HHOJADAAMGF.purchasableInShop;
		bool flag = HHOJADAAMGF.NIAGCEJGCIL();
		bool flag2 = !isBought && HHOJADAAMGF.numberOfParts > 0;
		bool flag3 = HHOJADAAMGF.isDefault && HHOJADAAMGF.owner.categoryNumber > 1;
		BFJBIABFJDL.SetActive(!purchasableInShop || !flag3);
		LLNJNOKFFFN.gameObject.SetActive(!isBought);
		AHJLEEHJKDG.transform.localPosition = AHJLEEHJKDG.transform.localPosition.ReplaceX((!isBought) ? 1851f : 357f);
		NJHBBJMPGJI.gameObject.SetActive(flag2);
		if (flag2)
		{
			UILabel nJHBBJMPGJI = NJHBBJMPGJI;
			object[] array = new object[1];
			array[0] = KFHOAJEFFEL().numberOfParts;
			array[1] = Colours.stringGrayParts;
			array[4] = Colours.stringWhite;
			array[5] = visual.numberOfPartsMax;
			nJHBBJMPGJI.text = string.Format("ID_UPGRADED", array);
		}
		ANODBGELEBJ.SetActive(!isBought && !purchasableInShop && !flag);
		FPPJHLCLBKL();
		FLMPFEEEJLN();
		IGIENAGNFEO.SetActive(flag);
		PMMNANLHKNH.gameObject.SetActive(!isBought);
	}

	public void BNBFBIPGHIK()
	{
		HKOFGKGCCOG();
	}

	[SpecialName]
	public PlayerVisual MOKNNJGNIOB()
	{
		return HHOJADAAMGF;
	}

	public void PPNFBNHGCLA()
	{
		NAAGKCKKMID();
	}

	internal void FLIOLKAOFAI()
	{
		bool isEquipped = HHOJADAAMGF.isEquipped;
		KMFGCJEGJJK.color = (isEquipped ? Colours.blueEquipped : ((!HHOJADAAMGF.purchasableInShop && !HHOJADAAMGF.NIAGCEJGCIL()) ? Color.yellow : Color.white));
		IMGOIFHGPAB.alpha = ((!isEquipped) ? 1658f : 1703f);
	}
}
