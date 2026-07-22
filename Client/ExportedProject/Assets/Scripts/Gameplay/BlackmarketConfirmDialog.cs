using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlackmarketConfirmDialog : GuiElementSingle<BlackmarketConfirmDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Core")]
	private GameObject mCloseButton;

	[SerializeField]
	private UITexture mWeaponTexture;

	[SerializeField]
	private UILabel mTextLabel;

	[SerializeField]
	private GameObject mBuyButton;

	[SerializeField]
	private UITable mPriceTable;

	[SerializeField]
	private UILabel mGoldLabel;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private Action<bool> PMFAEKAALAK;

	public virtual void IBNHJGLOHAE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HDHHILILNAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = MGALGNDOBBM;
	}

	private void MHELLECPBAI(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	public GuiElement KHNOCHHPLDF()
	{
		return this;
	}

	private void LALEMNJFAFF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		BBHEGJNGIDA(eBFDAICCJAK);
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LGMNMEBNEFM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = NAOPHHPFFPG;
	}

	public void DJPBIEBIAOJ(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 1040f);
	}

	public virtual void IDKBKFNPAPD()
	{
		LAPHNPODKPB(mCloseButton);
	}

	private void PFLJKJCHCIF()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 451f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void CKOFGDGOILM()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		LKBKPMKJLEP(eBFDAICCJAK);
	}

	public virtual void GBPEJMFMBJM()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
		BADOMKBKFFC();
	}

	private void NEOCMLAOFON()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public virtual void HLBIJGPEPIO()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
		LJCFLBPBBKC();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
		NNOIIKEACMH();
	}

	private void IKDNOEHGBIF()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LGMNMEBNEFM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = delegate
		{
			float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
			mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void ILFCOPPIOME(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 96f);
	}

	public void ShowDialog(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance);
	}

	private void LJCCPHPPMAM()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		LKBKPMKJLEP(eBFDAICCJAK);
	}

	public virtual void MDLMEDANPLD()
	{
		KPNLGDHEEMP();
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[3];
		array[0] = Colours.stringAzureBlackmarket;
		array[0] = MDAJJIAMDGH.weaponName.ToUpper();
		array[5] = Singleton<GameVariables>.instance.EIIPJBGJEMM(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
		uILabel.text = Localization.LocalizeFormat("Video_feed_upload", array);
	}

	private void LAPHNPODKPB(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	public virtual void CDMCFJMCKBP()
	{
		LAPHNPODKPB(mCloseButton);
	}

	private void EAKEFDOJMCA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	private void PPEGLHGPKHJ(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: false);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1209f * Singleton<GuiTexureAssets>.instance.MNDPPODHJHA());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = delegate
		{
			float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
			mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	public GuiElement FKCNDEANKNA()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		BLKPDBBMICL();
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
		mPriceTable.repositionNow = true;
		mTextLabel.text = Localization.LocalizeFormat("ID_CONFIRMTOBUYWEAPON", Colours.stringAzureBlackmarket, MDAJJIAMDGH.weaponName.ToUpper(), Singleton<GameVariables>.instance.GetWeaponCategory(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	private void LGMNMEBNEFM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	public void PJDNPHAHFBE(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 1759f);
	}

	public virtual void HFPPNCJBIDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CFKMKONHEHE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DGDOLLJONAK));
		mPriceTable.onReposition = ADJDNLIOFMB;
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void EPHIAFIFKJC()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public GuiElement AMKOIKGIMLN()
	{
		return this;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void JHENNGOBJCJ()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1953f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void BACIOBJJEMP()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		PPEGLHGPKHJ(eBFDAICCJAK);
	}

	private void CHEBEAKAIEB()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		BBHEGJNGIDA(eBFDAICCJAK);
	}

	private void JLKCJPJIEID()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		BBHEGJNGIDA(eBFDAICCJAK);
	}

	private void KOGJKJDEHKG()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void IDJMEDOGFGI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
			HideDialog();
		}
	}

	private void ADJDNLIOFMB()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1386f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void LKBKPMKJLEP(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(372f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	public virtual void EJLHAPDGBCL()
	{
		LGMNMEBNEFM(mCloseButton);
	}

	private void ACJJMGFDPGM()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public virtual void LKDFHKIAKAB()
	{
		HEBILNGCGDN(mCloseButton);
	}

	private void DGDOLLJONAK(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	private void MGALGNDOBBM()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1535f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void CKIFBLHLAOO()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
		ACJJMGFDPGM();
	}

	private void JNCHNHNGAFP()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	private void BADOMKBKFFC()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GAIGOIIFIIP();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public void KFKNFJCGMFD(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 1073f);
	}

	public virtual void BAAOGDMJCLK()
	{
		BLKPDBBMICL();
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[5];
		array[1] = Colours.stringAzureBlackmarket;
		array[0] = MDAJJIAMDGH.weaponName.ToUpper();
		array[4] = Singleton<GameVariables>.instance.JHHGEHCBEGK(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
		uILabel.text = Localization.LocalizeFormat("Animation for State: Ready", array);
	}

	public virtual void KJLDIJPMPAM()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
		EPHIAFIFKJC();
	}

	private void HDHHILILNAB(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	public GuiElement DDIIHKEFFNA()
	{
		return this;
	}

	private void NNOIIKEACMH()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public GuiElement GFLIHAFEKBK()
	{
		return this;
	}

	public GuiElement JPBIPBMAHBO()
	{
		return this;
	}

	private void MANDPFDHOKN()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 395f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void NMMEDNEGDNI()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
		EPHIAFIFKJC();
	}

	private void LBLHIDALMPB()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		LDPJPLKHFIG(eBFDAICCJAK);
	}

	public void JKIMMLIGLAF(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 1817f);
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HGFLHIEILKP));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = MANDPFDHOKN;
	}

	public void ONHPOAIKLAO(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 1388f);
	}

	public void NODJKBBENBL(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 627f);
	}

	public GuiElement KBCELKIEAAM()
	{
		return this;
	}

	private void FMIMDPFNKAJ()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void NMHMFDOFDBC()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
		NNOIIKEACMH();
	}

	public virtual void PGJDLKDMCHN()
	{
		BACIOBJJEMP();
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[8];
		array[0] = Colours.stringAzureBlackmarket;
		array[1] = MDAJJIAMDGH.weaponName.ToUpper();
		array[0] = Singleton<GameVariables>.instance.JHHGEHCBEGK(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
		uILabel.text = Localization.LocalizeFormat("ID_GUI_BEADVISED_PURCHASEVIP", array);
	}

	public virtual void GCJNPLEFBHI()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
		IKDNOEHGBIF();
	}

	private void BBHEGJNGIDA(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: false);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1009f * Singleton<GuiTexureAssets>.instance.MLLEMEJOADP());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	private void OGHALGIDMCN(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: false);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(380f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HGFLHIEILKP));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DGDOLLJONAK));
		mPriceTable.onReposition = MGALGNDOBBM;
	}

	private void LDPJPLKHFIG(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1330f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: true);
		}
	}

	private void LJCFLBPBBKC()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public GuiElement HIDNIFBOPAL()
	{
		return this;
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mCloseButton);
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	private void JHLEGPMOMON()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		OGHALGIDMCN(eBFDAICCJAK);
	}

	private void OEAAJNGBBKK()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		MDAJJIAMDGH = null;
	}

	public virtual void LCMFDLLFBDC()
	{
		BLKPDBBMICL();
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[5];
		array[0] = Colours.stringAzureBlackmarket;
		array[0] = MDAJJIAMDGH.weaponName.ToUpper();
		array[4] = Singleton<GameVariables>.instance.EIIPJBGJEMM(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
		uILabel.text = Localization.LocalizeFormat("Sniper_Tutorial_Played", array);
	}

	public virtual void AHDJEJIKCAB()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
		IKDNOEHGBIF();
	}

	public void GONOICLIMKO(WeaponLevelsSetup JMMJHCOKCGG, Action<bool> BLHPGCIDEBE)
	{
		MDAJJIAMDGH = JMMJHCOKCGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketConfirmDialog>.instance, 1714f);
	}

	public virtual void HCGDNLHIOBL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HDHHILILNAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = ADJDNLIOFMB;
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(0.8638f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	public virtual void EEFEFOHKIBF()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
		ACJJMGFDPGM();
	}

	private void CFKMKONHEHE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	public virtual void AAPGEAEKKGF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHELLECPBAI));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = MGALGNDOBBM;
	}

	private void NAOPHHPFFPG()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1277f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void HGFLHIEILKP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			HideDialog();
		}
	}

	private void FOKOFFHFGHG()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		LKBKPMKJLEP(eBFDAICCJAK);
	}

	public virtual void JKEEMKIHFEE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LGMNMEBNEFM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DGDOLLJONAK));
		mPriceTable.onReposition = JHENNGOBJCJ;
	}

	public virtual void PDHNLAMPOBN()
	{
		BLKPDBBMICL();
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[1];
		array[0] = Colours.stringAzureBlackmarket;
		array[1] = MDAJJIAMDGH.weaponName.ToUpper();
		array[4] = Singleton<GameVariables>.instance.GetWeaponCategory(MDAJJIAMDGH.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
		uILabel.text = Localization.LocalizeFormat("Deploys_Count", array);
	}

	private void KPNLGDHEEMP()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}
}
