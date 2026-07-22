using System;
using UnityEngine;
using UnityEngine.Serialization;

public class StarterAssignmentRewardDialog : GuiElementSingle<StarterAssignmentRewardDialog>, PAIIOKBBHBC
{
	[Header("Reward")]
	[FormerlySerializedAs("COGPFIGDCJG")]
	public UITexture NGHCDIMLGMO;

	[Header("Bottom")]
	[FormerlySerializedAs("GCDJFGHEOKH")]
	public GameObject KGPGCCPMCIG;

	[Header("Animation")]
	[FormerlySerializedAs("ELCMECGGFKB")]
	public CardMenuOwerlay JEGNECDPAFK;

	private Card[] OAKNNNMGEID;

	public void EEIEBPMDHOA(Card[] HGPGKHLOHEF)
	{
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 1148f);
	}

	private void PBIHPJECMPG(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		NMIADNEAAFB();
	}

	public virtual void IEHJMLIMNEP()
	{
		JEGNECDPAFK.MPFNDLEFIKN();
		INMJAIMDLMC();
	}

	public virtual void AAPGEAEKKGF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KGPGCCPMCIG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CNCHGBCGBOB));
	}

	private void JILOAENNJKF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("menu-sidetab-bg-box-button");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1314f * Singleton<GuiTexureAssets>.instance.IJGKCNAMOBF());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	public virtual void AEMAANAKHPG()
	{
		base.MEPKGFFNPAD();
		JEGNECDPAFK.BKLMJCEPNMK(OAKNNNMGEID, 972f);
	}

	public virtual void ICDHOMKLGLK()
	{
		base.BJIPCOPNEAM();
		JEGNECDPAFK.BKPMDFENMPC(OAKNNNMGEID, 379f);
	}

	private void HCKKOFEAOAJ(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void HHJDKKFKKIL()
	{
		JEGNECDPAFK.AOBFOFAGIOD();
		AMHDKKLHKEO();
	}

	public GuiElement GMPEFKABFGG()
	{
		return this;
	}

	public virtual void CICEFDONBML()
	{
		GHFCINPHPHA(KGPGCCPMCIG);
	}

	public virtual void HGKNCKIKBDC()
	{
		JEGNECDPAFK.MPFNDLEFIKN();
		AMHDKKLHKEO();
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KGPGCCPMCIG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GHFCINPHPHA));
	}

	private void AMHDKKLHKEO()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GAIGOIIFIIP();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_CONFIRM_SQUADNOTEMPTY");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1809f * Singleton<GuiTexureAssets>.instance.NNOEPDDIFBA());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	public void ILFCOPPIOME(Card[] HGPGKHLOHEF)
	{
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 898f);
	}

	public GuiElement HJFNBHHEGIF()
	{
		return this;
	}

	private void AHAGMDCOMME()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("Yes_Clicked");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(218f * Singleton<GuiTexureAssets>.instance.MMPHJJIMJPI());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	public virtual void NLBAPEADKNJ()
	{
		base.DoAfterHide();
		NMIADNEAAFB();
	}

	public virtual void OFCCACPEBHD()
	{
		JEGNECDPAFK.AOBFOFAGIOD();
		PNBDOHHFBEA();
	}

	public virtual void JCIBDJMFOLI()
	{
		JEGNECDPAFK.AOBFOFAGIOD();
		AMHDKKLHKEO();
	}

	public void IKJNNOFBFGL(Card[] HGPGKHLOHEF)
	{
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 1158f);
	}

	private void NKACHLHLHLH()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D texture2D = weapons.LoadAsset("menu-weapon-mp5-elite");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.617f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	public virtual void AIMELNDIKII()
	{
		base.DALAPEANFLB();
		JEGNECDPAFK.BKPMDFENMPC(OAKNNNMGEID, 688f, DNEMOLAGBHH: false);
	}

	public virtual void BFFHGHMJOGP()
	{
		EHGPIICGKNI(KGPGCCPMCIG);
	}

	public virtual void INPIJKMMADI()
	{
		base.OIMKKAHOEKO();
		CGLIKOEBJNG();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KGPGCCPMCIG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EHGPIICGKNI));
	}

	public void ShowDialog(Card[] HGPGKHLOHEF)
	{
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void OAAABGFLAFG(Card[] HGPGKHLOHEF)
	{
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 1410f);
	}

	private void DNCLECOFGFO()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("确定");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1149f * Singleton<GuiTexureAssets>.instance.CBCEFDMDNMK());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void CNCHGBCGBOB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void NPLOPHFGDKK()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("SpawnByCardRPC");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(43f * Singleton<GuiTexureAssets>.instance.KHHIIBIMMDH());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	public virtual void BHKNLDEDGGC()
	{
		base.PDBDILLHKID();
		JEGNECDPAFK.ADFPKNKIAGM(OAKNNNMGEID, 1562f);
	}

	public virtual void AJCCKKEMDHO()
	{
		HCKKOFEAOAJ(KGPGCCPMCIG);
	}

	public override void InitGUIValues()
	{
		JEGNECDPAFK.ResetDraw();
		NKACHLHLHLH();
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	public virtual void NDCIPPAMICK()
	{
		base.MEPKGFFNPAD();
		JEGNECDPAFK.EKOGCJGEEJA(OAKNNNMGEID, 1624f);
	}

	private void KLICCOJKAFH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		resourceLoaderTexture2D.FreeAsset("0");
	}

	private void PNBDOHHFBEA()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ShotFrequencyMax");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1964f * Singleton<GuiTexureAssets>.instance.FAOGOKNFGAL());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	private void INMJAIMDLMC()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset(" (#");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1513f * Singleton<GuiTexureAssets>.instance.KHHIIBIMMDH());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		JEGNECDPAFK.StartShowAnimation(OAKNNNMGEID, 0.2f);
	}

	private void NMINADDLDHF()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		resourceLoaderTexture2D.FreeAsset(".");
	}

	private void EHGPIICGKNI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement EEAHKOCLJHB()
	{
		return this;
	}

	public virtual void HEIJOCBENDG()
	{
		base.MOJBHFPBAPP();
		JEGNECDPAFK.EKOGCJGEEJA(OAKNNNMGEID, 1120f);
	}

	private void CGLIKOEBJNG()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		resourceLoaderTexture2D.FreeAsset("ID_FORFEIT");
	}

	private void NMIADNEAAFB()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset("menu-weapon-mp5-elite");
	}

	private void ADNAOEDHCLJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		resourceLoaderTexture2D.FreeAsset("WarFriends");
	}

	public virtual void HNPCBFNILBD()
	{
		base.DoAfterHide();
		CGLIKOEBJNG();
	}

	private void GHFCINPHPHA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void OnBack()
	{
		EHGPIICGKNI(KGPGCCPMCIG);
	}

	public virtual void DMFOJDBAKOM()
	{
		base.MOJBHFPBAPP();
		JEGNECDPAFK.StartShowAnimation(OAKNNNMGEID, 486f, DNEMOLAGBHH: false);
	}

	public virtual void BIHBMLLLCEP()
	{
		base.DoAfterShowUp();
		JEGNECDPAFK.BKLMJCEPNMK(OAKNNNMGEID, 602f, DNEMOLAGBHH: false);
	}

	public GuiElement DDIIHKEFFNA()
	{
		return this;
	}

	public virtual void NMHMFDOFDBC()
	{
		base.OIMKKAHOEKO();
		CGLIKOEBJNG();
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	public void EGLMNBKMBAM(Card[] HGPGKHLOHEF)
	{
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 502f);
	}

	private void NMHLKHGFFIL()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_GRENADEDAMAGE");
		if (texture2D != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = texture2D;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(624f * Singleton<GuiTexureAssets>.instance.KHHIIBIMMDH());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	public virtual void AKPHBJHGBKF()
	{
		base.DoAfterHide();
		CGLIKOEBJNG();
	}

	public void CMOEFABLABI(Card[] HGPGKHLOHEF)
	{
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 1547f);
	}

	public virtual void ONHFMLDPOKG()
	{
		base.DoAfterShowUp();
		JEGNECDPAFK.MEODANEBGGL(OAKNNNMGEID, 401f);
	}
}
