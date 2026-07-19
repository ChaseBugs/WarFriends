using System;
using UnityEngine;

public class TutorialWeaponDialog : GuiElementSingle<TutorialWeaponDialog>, PAIIOKBBHBC
{
	[Header("Content")]
	public UILabel NDBAGOOMIDJ;

	public UITexture NGHCDIMLGMO;

	public UILabel DEOJCFEFBHP;

	public UIButton DMPBNBPBDFD;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private void DNOFDHOICFI()
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

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void NDCOOCAOPCL(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 22f);
	}

	public virtual void POFPIJKJFBP()
	{
		base.OIMKKAHOEKO();
		BHIFFFLJDOO();
	}

	public virtual void KIECGCGABFJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FNAIBJCLAJL));
	}

	private void EDDJDDDJJJM()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void LHCEHKGAEEE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void NEOCMLAOFON()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NCLHGCOBGDE));
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.7404f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(false);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		NNOIIKEACMH();
	}

	private void ADMIKNNOIGO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void OFHOGHEKBPJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	private void NCJDGOFFODA()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public virtual void IHLGGCNHCDG()
	{
		if (!(MDAJJIAMDGH == null))
		{
			NDBAGOOMIDJ.text = Localization.Localize((MDAJJIAMDGH.BHCEOOLEHHG != (WeaponCategory.SMG | WeaponCategory.RocketLauncher)) ? "-" : "ID_ARENASTARTSTIMER");
			BLKPDBBMICL();
			DEOJCFEFBHP.text = ((MDAJJIAMDGH.BHCEOOLEHHG != ~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade)) ? Localization.Localize("android.os.Build$VERSION") : Localization.Localize("Pack_Type"));
		}
	}

	private void NCLHGCOBGDE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void AIIJHNNODDM()
	{
		FNAIBJCLAJL(DMPBNBPBDFD.gameObject);
	}

	public virtual void ILHPNHECBJG()
	{
		ADMIKNNOIGO(DMPBNBPBDFD.gameObject);
	}

	private void BHIFFFLJDOO()
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

	public virtual void KJBGADNDLGI()
	{
		KDAENCDLEFH(DMPBNBPBDFD.gameObject);
	}

	public void EMCKDMFGEIB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1751f);
	}

	public virtual void OGHPJHOJMIK()
	{
		KDAENCDLEFH(DMPBNBPBDFD.gameObject);
	}

	private void GKLPAKILLFG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void DMADJAFJNJJ()
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

	public virtual void JCOILGHDPHA()
	{
		base.DoAfterHide();
		DNOFDHOICFI();
	}

	public void AHJFFMAFCEG(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1247f);
	}

	public void OFEAPBAJLGG(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1389f);
	}

	public override void GENKPBNDOCB()
	{
		FEKCNIELADE(DMPBNBPBDFD.gameObject);
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FNAIBJCLAJL));
	}

	public override void InitGUIValues()
	{
		if (!(MDAJJIAMDGH == null))
		{
			NDBAGOOMIDJ.text = Localization.Localize((MDAJJIAMDGH.BHCEOOLEHHG != WeaponCategory.Minigun) ? "ID_ROCKETLAUNCHERHINT" : "ID_MINIGUNHINT");
			BLKPDBBMICL();
			DEOJCFEFBHP.text = ((MDAJJIAMDGH.BHCEOOLEHHG != WeaponCategory.Minigun) ? Localization.Localize("ID_ROCKETLAUNCHERTUTORIALTEXT") : Localization.Localize("ID_MINIGUNTUTORIALTEXT"));
		}
	}

	private void IMNPOFONMDG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void HAHKNAIIIPC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FNAIBJCLAJL));
	}

	private void FEKCNIELADE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void BEPGKIFJFKA()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		PDPHBJBPNGK(eBFDAICCJAK);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}

	private void BADOMKBKFFC()
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

	private void KDAENCDLEFH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void AIJEMOLBNEC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OFHOGHEKBPJ));
	}

	public virtual void CDHLMEPGPNJ()
	{
		if (!(MDAJJIAMDGH == null))
		{
			NDBAGOOMIDJ.text = Localization.Localize((MDAJJIAMDGH.BHCEOOLEHHG != ~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade)) ? "{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}" : "Wood");
			GODMAJOAKPF();
			DEOJCFEFBHP.text = ((MDAJJIAMDGH.BHCEOOLEHHG != ~WeaponCategory.LMG) ? Localization.Localize("\t\tKEYBOARD DONNNEEEE   ") : Localization.Localize("ERROR - BAD FORMAT"));
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

	public virtual void DBMCMLINOPD()
	{
		base.DoAfterHide();
		LJCFLBPBBKC();
	}

	public virtual void DOANAOOEAKD()
	{
		FPPBNJLHOGG(DMPBNBPBDFD.gameObject);
	}

	public GuiElement BEOCBHEIKKO()
	{
		return this;
	}

	public virtual void BEAOKIEIEIM()
	{
		LMEMKCHKILN(DMPBNBPBDFD.gameObject);
	}

	public virtual void EGNPMLEJLMJ()
	{
		FPPBNJLHOGG(DMPBNBPBDFD.gameObject);
	}

	public override void OnBack()
	{
		KDAENCDLEFH(DMPBNBPBDFD.gameObject);
	}

	public virtual void MOCIFAAJDAA()
	{
		base.DoAfterHide();
		DMADJAFJNJJ();
	}

	public void ShowDialog(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void DILDDAGFIEO()
	{
		KDAENCDLEFH(DMPBNBPBDFD.gameObject);
	}

	public void OAAABGFLAFG(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1794f);
	}

	public virtual void PHNKOMPPPLD()
	{
		if (!(MDAJJIAMDGH == null))
		{
			NDBAGOOMIDJ.text = Localization.Localize((MDAJJIAMDGH.BHCEOOLEHHG != ~(WeaponCategory.Primary | WeaponCategory.RocketLauncher | WeaponCategory.Pistol)) ? "MX" : "Cards_Owned_Silver");
			BEPGKIFJFKA();
			DEOJCFEFBHP.text = ((MDAJJIAMDGH.BHCEOOLEHHG != (WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Pistol)) ? Localization.Localize("ios") : Localization.Localize("아니오"));
		}
	}

	private void EHGCLOACGFK()
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

	public virtual void MKPIKCBBKIB()
	{
		FPPBNJLHOGG(DMPBNBPBDFD.gameObject);
	}

	private void DHINAHHFKNJ()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void EJDEHFDNEOC()
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

	public void EBELHKPCLBI(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1323f);
	}

	private void EIGCJAAKGLN()
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

	private void ENPMFODIICN()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		PDPHBJBPNGK(eBFDAICCJAK);
	}

	public virtual void NLBAPEADKNJ()
	{
		base.OIMKKAHOEKO();
		CNFKPKEBBFB();
	}

	private void CIOKEPINKFB()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public virtual void AIIAHAKKMBN()
	{
		base.OIMKKAHOEKO();
		EIGCJAAKGLN();
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void CNFKPKEBBFB()
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

	private void PDPHBJBPNGK(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(415f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(true);
		}
	}

	public virtual void LDBLJDJNJJN()
	{
		base.DoAfterHide();
		CNFKPKEBBFB();
	}

	private void FNAIBJCLAJL(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void DLCJLHFFLPJ()
	{
		FNAIBJCLAJL(DMPBNBPBDFD.gameObject);
	}

	public virtual void JGCMMECGCOE()
	{
		base.OIMKKAHOEKO();
		NNOIIKEACMH();
	}

	private void IBKNLGBJBIO()
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

	private void LMEMKCHKILN(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void LBHGDEGEALA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement EBKJBKMFEKE()
	{
		return this;
	}

	private void LOBNEOPBOPO()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public virtual void PNLGFNBEOLG()
	{
		if (!(MDAJJIAMDGH == null))
		{
			NDBAGOOMIDJ.text = Localization.Localize((MDAJJIAMDGH.BHCEOOLEHHG != (WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun)) ? "country-belarus" : "CheckDisable");
			NEOCMLAOFON();
			DEOJCFEFBHP.text = ((MDAJJIAMDGH.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade)) ? Localization.Localize("+{0}%") : Localization.Localize("ID_CONFIRM_DELETESQUAD"));
		}
	}

	public virtual void EIPCLGCNKGO()
	{
		FEKCNIELADE(DMPBNBPBDFD.gameObject);
	}

	private void AHEAOOHMMFD()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public virtual void MGIDNGCKLCF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LMEMKCHKILN));
	}

	public void CBPJNPHOAFN(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1831f);
	}

	private void FPPBNJLHOGG(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKLPAKILLFG));
	}

	public void JDNEBEKOHPG(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1591f);
	}

	public void DOKNIFNNCDH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		Singleton<GuiManager>.instance.ShowDialog(this, 494f);
	}

	private void GODMAJOAKPF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		PDPHBJBPNGK(eBFDAICCJAK);
	}

	private void LJCFLBPBBKC()
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

	public virtual void AIIIDDDAPGB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}
}
