using UnityEngine;

public class CompareWeaponsRecord : MonoBehaviour
{
	[Header("Header")]
	public UILabel FCIOBPPMFJA;

	[Header("Core")]
	public UITexture NGHCDIMLGMO;

	public UISprite KMFGCJEGJJK;

	public UILabel APLODBKLDEG;

	public UISprite NOFOFAAFPOJ;

	public UILabel BCCDDJMPBLL;

	public UISprite BPBHIIAMDDL;

	private WeaponLevelsSetup MDAJJIAMDGH;

	public void NOMBEBADCKJ()
	{
		HBGNJFIDLEM();
	}

	public void HLBIJGPEPIO()
	{
		CFFBMDBPMFK();
	}

	private void GIFBEEONHMF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GAIGOIIFIIP();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		PLIOIPDHDCK(eBFDAICCJAK);
	}

	private void GIMHNLNCNEA()
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

	public void PLCKEDNAMLI(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.GetWeaponCategory(fABOAIMLLOI, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
	}

	private void NOHMOAGDMCF()
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

	public void NMHMFDOFDBC()
	{
		MEHPFALNHPJ();
	}

	private void CFFBMDBPMFK()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void CHLKFIEIJFE()
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

	public void MMKEEBKDKLG(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			BDKLKEJLNOI();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		GIFBEEONHMF();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 1763f : 1918f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 1431f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(621f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 1864f : 913f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(true);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 14f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.DPNJCOOEHJE(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(true, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.OBKAPNICHMJ(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 1414f : 1909f, 829f, 0f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(593f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(211f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(669f);
		}
	}

	private void INCKDPDPIPA()
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

	private void EJPJLHDLABL(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1248f * Singleton<GuiTexureAssets>.instance.FAOGOKNFGAL());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	private void KPNLGDHEEMP()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		FNJJBGJAGAC(eBFDAICCJAK);
	}

	private void GDMAFOLOGNC()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void HKPDDINMBAC()
	{
		KLJFGLDKMBJ();
	}

	public void DDHCMFLIABO(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			CHLKFIEIJFE();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		AHKFNFMAPEF();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 1264f : 51f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 477f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(1699f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 751f : 614f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(true);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 539f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.HMOJHDPPAOA(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(false, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.HMOJHDPPAOA(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 1391f : 475f, 1773f, 156f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(497f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(1062f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(591f);
		}
	}

	private void GMGDGDNODAP(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(649f * Singleton<GuiTexureAssets>.instance.MLLEMEJOADP());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	private void PLIOIPDHDCK(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1321f * Singleton<GuiTexureAssets>.instance.IJGKCNAMOBF());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	public void MPBHGIGOHBE(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.GetWeaponCategory(fABOAIMLLOI, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
	}

	private void AHKFNFMAPEF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		HKKNOEKNKFI(eBFDAICCJAK);
	}

	private void EDHPDLBEOHA()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void HKKNOEKNKFI(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1939f * Singleton<GuiTexureAssets>.instance.DLBBEAPEPHD());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	private void BDKLKEJLNOI()
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

	public void GHNIJJKDAJH()
	{
		NOKKAPEGMMH();
	}

	public void ACBHGJCMCPG(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			NNOIIKEACMH();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		JEKMJAOACFJ();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 1048f : 801f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 760f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(281f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 1754f : 400f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(false);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 1473f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.HMOJHDPPAOA(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(true, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.OHFFFHLNEBH(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 1655f : 525f, 988f, 1456f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(1005f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(0f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(54f);
		}
	}

	private void FOGOFKILPNI(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1255f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	public void DAINIFDEAIO(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(fABOAIMLLOI, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
	}

	private void FNJJBGJAGAC(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1925f * Singleton<GuiTexureAssets>.instance.CBCEFDMDNMK());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	private void MEHPFALNHPJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void PAGNLNHPBFJ(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(fABOAIMLLOI, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
	}

	private void EMGPBNCLGII()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		PLGOOPGCOAM(eBFDAICCJAK);
	}

	private void CLKEMCCACBD(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1961f * Singleton<GuiTexureAssets>.instance.NEKAPIDHBNC());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	private void JEKMJAOACFJ()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void KIHLFDGMNOP(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(fABOAIMLLOI, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
	}

	public void DPFKOFFMNPC(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			GIMHNLNCNEA();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		BHOCEHICMCI();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 1901f : 1790f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 89f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(1033f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 619f : 1083f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(true);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 1932f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.NMAJKMDBKJJ(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(true, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.GKIEAIPJHJN(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 1799f : 1080f, 22f, 1486f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(1197f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(870f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(689f);
		}
	}

	private void CNFKPKEBBFB()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void NOKKAPEGMMH()
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

	private void BKFDFGOHIEL()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		CLKEMCCACBD(eBFDAICCJAK);
	}

	public void CFIAHPMMJOE(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			GIMHNLNCNEA();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		KIJHOJLEFOL();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 1098f : 930f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 289f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(653f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 870f : 1086f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(false);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 222f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.GKIEAIPJHJN(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(false, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.NJBGFNBOFFN(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 613f : 256f, 1388f, 1696f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(1509f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(73f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(464f);
		}
	}

	public void HCLKKBOBAHO(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.GetWeaponCategory(fABOAIMLLOI, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
	}

	private void PKAHHGEMOJK()
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

	public void BPDMKGEDADP(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.GetWeaponCategory(fABOAIMLLOI, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
	}

	private void MGEPLIAICLK()
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

	public void FNMPBHIIEJP()
	{
		INCKDPDPIPA();
	}

	private void PLGOOPGCOAM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(39f * Singleton<GuiTexureAssets>.instance.IJGKCNAMOBF());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	private void KLJFGLDKMBJ()
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

	public void AFHMOPJGNBM(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			CFFBMDBPMFK();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		BKFDFGOHIEL();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 26f : 1184f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 71f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(1198f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 1708f : 486f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(false);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 1888f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.GKIEAIPJHJN(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(false, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.NMAJKMDBKJJ(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 1266f : 1378f, 1355f, 1056f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(1410f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(826f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(918f);
		}
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void DoAfterHide()
	{
		NNOIIKEACMH();
	}

	private void NBOHAIEMFAD()
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

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.34552f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	public void BCMCGJGLFPL()
	{
		DNOFDHOICFI();
	}

	public void FLMPHCNMDFA()
	{
		EDHPDLBEOHA();
	}

	public void InitializeSlot(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.GetWeaponCategory(fABOAIMLLOI, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
	}

	public void KLFGGKPPHJN(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.GetWeaponCategory(fABOAIMLLOI, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
	}

	public void POFPIJKJFBP()
	{
		NOKKAPEGMMH();
	}

	public void IFLHOKBNJPH()
	{
		NOKKAPEGMMH();
	}

	private void KIJHOJLEFOL()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		FOGOFKILPNI(eBFDAICCJAK);
	}

	private void OAKNNNMDLAH()
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

	private void BHOCEHICMCI()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		HKKNOEKNKFI(eBFDAICCJAK);
	}

	private void HJIJLJBEIAF(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(999f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	public void FJFDJJJNCAJ()
	{
		NOKKAPEGMMH();
	}

	public void LAALCOMHIPK()
	{
		KLJFGLDKMBJ();
	}

	public void Initialize(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			NNOIIKEACMH();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		BLKPDBBMICL();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 32f : 168f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 0f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(0.3f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 0f : 1f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(false);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 1f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.CreateFeature(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(true, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.CreateFeature(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 42f : 155f, -100f, -2f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(0.15f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(0.15f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(0.1f);
		}
	}

	private void HMACJLEPNPJ(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(734f * Singleton<GuiTexureAssets>.instance.NFJLFPEOFKD());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
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

	private void DNOFDHOICFI()
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

	public void HGOCKFKMENE()
	{
		MGEPLIAICLK();
	}

	private void CHEBEAKAIEB()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		FOGOFKILPNI(eBFDAICCJAK);
	}

	public void HNPCBFNILBD()
	{
		MGEPLIAICLK();
	}

	private void MKJJCAPMKBN(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(327f * Singleton<GuiTexureAssets>.instance.DLBBEAPEPHD());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	public void DKCOOAKKFKD()
	{
		EDHPDLBEOHA();
	}

	private void INLICPBGKOD()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		GMGDGDNODAP(eBFDAICCJAK);
	}

	public void HCEJNMJHDJN(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			HBGNJFIDLEM();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		GIFBEEONHMF();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 64f : 1905f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 307f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(1374f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 472f : 970f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(true);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 956f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.OBKAPNICHMJ(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(true, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.ENGPIADFOEN(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 1781f : 829f, 781f, 132f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(198f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(1134f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(332f);
		}
	}

	public void DIFICJJIJCC(int KDEACKELOFC)
	{
		WeaponCategory fABOAIMLLOI = GameVariables.JPLODJAFFFP[KDEACKELOFC];
		FCIOBPPMFJA.text = Singleton<GameVariables>.instance.GetWeaponCategory(fABOAIMLLOI, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
	}

	private void HBGNJFIDLEM()
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

	public void CHOLKMFKINL(WeaponLevelsSetup MBNLFKHLDBH, PlayerInventory.JIMOKIIJHNA BANGMNGBOCN, WeaponLevelsSetup FDKEEMEBCCF, PlayerInventory.JIMOKIIJHNA AGCKBJEDLKC, bool OEKEJMJIECP, bool ILCIMCBBCKB)
	{
		if (MDAJJIAMDGH != null)
		{
			CHLKFIEIJFE();
		}
		MDAJJIAMDGH = MBNLFKHLDBH;
		KIJHOJLEFOL();
		NOFOFAAFPOJ.gameObject.SetActive(MBNLFKHLDBH.purchasableInBlackmarket);
		NOFOFAAFPOJ.transform.localPosition = NOFOFAAFPOJ.transform.localPosition.ReplaceX((!OEKEJMJIECP) ? 1263f : 1255f);
		KMFGCJEGJJK.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			APLODBKLDEG.text = string.Empty;
			BCCDDJMPBLL.text = string.Empty;
			BPBHIIAMDDL.alpha = 1258f;
			KMFGCJEGJJK.color = ((!ILCIMCBBCKB) ? Color.white.ReplaceA(614f) : Color.white);
			NGHCDIMLGMO.alpha = ((!ILCIMCBBCKB) ? 72f : 688f);
			if (!ILCIMCBBCKB)
			{
				NOFOFAAFPOJ.gameObject.SetActive(false);
			}
			return;
		}
		NGHCDIMLGMO.alpha = 356f;
		WeaponFeatures weaponFeatures = LevelManager.instance.weaponFeatures;
		WeaponFeature nHJABEOIPKH = weaponFeatures.DPNJCOOEHJE(MBNLFKHLDBH, BANGMNGBOCN.FIPONKNHIAL);
		int weaponPowerX = MBNLFKHLDBH.GetWeaponPowerX10(BANGMNGBOCN.DGPAEJJENDP, nHJABEOIPKH);
		APLODBKLDEG.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BCCDDJMPBLL.text = MEJMLNDFDBP.GMIPFLIEOHD(MBNLFKHLDBH.GetLevel(true, BANGMNGBOCN.DGPAEJJENDP));
		WeaponFeature nHJABEOIPKH2 = weaponFeatures.ECAJKDEJDDO(FDKEEMEBCCF, AGCKBJEDLKC.FIPONKNHIAL);
		int weaponPowerX2 = FDKEEMEBCCF.GetWeaponPowerX10(AGCKBJEDLKC.DGPAEJJENDP, nHJABEOIPKH2);
		BCCDDJMPBLL.transform.localPosition = new Vector3((!OEKEJMJIECP) ? 1255f : 1471f, 1126f, 1144f);
		if (weaponPowerX == weaponPowerX2)
		{
			APLODBKLDEG.color = Color.white;
			BPBHIIAMDDL.color = Color.white.ReplaceA(741f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			APLODBKLDEG.color = Colours.greenWeaponStats;
			BPBHIIAMDDL.color = Colours.greenWeaponStats.ReplaceA(129f);
		}
		else
		{
			APLODBKLDEG.color = Colours.redWeaponStats;
			BPBHIIAMDDL.color = Colours.redWeaponStats.ReplaceA(331f);
		}
	}
}
