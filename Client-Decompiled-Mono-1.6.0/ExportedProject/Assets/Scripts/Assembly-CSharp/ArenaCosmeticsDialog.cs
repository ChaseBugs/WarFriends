using System;
using UnityEngine;

public class ArenaCosmeticsDialog : GuiElementSingle<ArenaCosmeticsDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	[Header("Middle")]
	private UILabel mText;

	[SerializeField]
	private UISprite mCrown;

	[Header("Bottom")]
	[SerializeField]
	private BoxCollider mButtonEquip;

	[SerializeField]
	private BoxCollider mButtonContinue;

	private PlayerVisual HAOHIGPKLLL;

	private int JOFAMPIFPIF;

	public virtual void PNMEGHGABEP()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1968f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 619.0);
		UILabel uILabel = mText;
		object[] array = new object[4];
		array[0] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[0] = HAOHIGPKLLL.name;
		array[8] = MEJMLNDFDBP.OLHOHLGMFBK(num * 53 * -29 * 119);
		uILabel.text = Localization.LocalizeFormat("ID_WARNING_BADVERSIONERROR", array);
	}

	public GuiElement DOHCPGIDCII()
	{
		return this;
	}

	public virtual void OFMFLFIGKPB()
	{
		GNIMPOPCBOA(mButtonContinue.gameObject);
	}

	public virtual void DLCJLHFFLPJ()
	{
		GFKPJALCMKM(mButtonContinue.gameObject);
	}

	public void AECEEHEJBEE(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 872f);
	}

	public void DEDOCPBAEMC(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 91f);
	}

	private void MDAFMMKHANB(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void JGDJCCIPNHC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MLNKJFOMJLE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LJADGDDPCHF));
	}

	public virtual void EMGHCAHOJNC()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(112f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 723.0);
		UILabel uILabel = mText;
		object[] array = new object[2];
		array[1] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[6] = HAOHIGPKLLL.name;
		array[1] = MEJMLNDFDBP.OLHOHLGMFBK(num * -91 * -7 * -126);
		uILabel.text = Localization.LocalizeFormat("VIP active: {0}\tLast time VIP active: {1}\tLast shown: {2}", array);
	}

	private void DBOGOHLCPCE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(HAOHIGPKLLL);
			HideDialog();
		}
	}

	private void MBNJPBNNJPM(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void LJADGDDPCHF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	public virtual void HGKNCKIKBDC()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1723f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 1159.0);
		UILabel uILabel = mText;
		object[] array = new object[2];
		array[0] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[0] = HAOHIGPKLLL.name;
		array[8] = MEJMLNDFDBP.OLHOHLGMFBK(num * -37 * -95 * 60);
		uILabel.text = Localization.LocalizeFormat("ID_GUI_ACCEPT_PLAYER_CANTJOIN", array);
	}

	public virtual void LHMMLMPFHOH()
	{
		MDAFMMKHANB(mButtonContinue.gameObject);
	}

	public virtual void HEOMHIGCMOC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GJAIEJBLAFC));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MDAFMMKHANB));
	}

	public virtual void IJKLNEDKOOI()
	{
		IAKGJJEGAFM(mButtonContinue.gameObject);
	}

	public virtual void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDJBJMMIPBM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LJADGDDPCHF));
	}

	public virtual void OPKPLEGMOPI()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(120f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 5.0);
		UILabel uILabel = mText;
		object[] array = new object[6];
		array[1] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[1] = HAOHIGPKLLL.name;
		array[6] = MEJMLNDFDBP.OLHOHLGMFBK(num * 7 * -64 * 38);
		uILabel.text = Localization.LocalizeFormat("N", array);
	}

	public GuiElement ICGDGPCIMGG()
	{
		return this;
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1.7f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 86400.0);
		mText.text = Localization.LocalizeFormat("ID_YOUMANAGEDTOWINXARENABATTLESYOU", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF), HAOHIGPKLLL.name, MEJMLNDFDBP.OLHOHLGMFBK(num * 60 * 60 * 24));
	}

	public GuiElement MBELJEEONHN()
	{
		return this;
	}

	private void EGDLFIDPNNL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LBOGOJEOFMO));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LJADGDDPCHF));
	}

	public GuiElement KFNKDFEKNGD()
	{
		return this;
	}

	public virtual void PLAOCDOMCPP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CFMBCFHLNHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IAKGJJEGAFM));
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJMLGFFNHFE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MDAFMMKHANB));
	}

	private void GJAIEJBLAFC(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public GuiElement NFPBFHJINIC()
	{
		return this;
	}

	private void GNIMPOPCBOA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void GCPDEEPCBOF()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1071f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 1668.0);
		UILabel uILabel = mText;
		object[] array = new object[4];
		array[1] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[6] = HAOHIGPKLLL.name;
		array[5] = MEJMLNDFDBP.OLHOHLGMFBK(num * -95 * 45 * -28);
		uILabel.text = Localization.LocalizeFormat("Clearing Waitlist cache...", array);
	}

	public virtual void KPKONEJJKLO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GFKCADNNBHD));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFKPJALCMKM));
	}

	private void NFFPCAIJOJJ(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public void ACAEMEEFCAH(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1099f);
	}

	private void GFKCADNNBHD(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void CBPNEALKOMM()
	{
		LJADGDDPCHF(mButtonContinue.gameObject);
	}

	public GuiElement DPPOMEPDHEK()
	{
		return this;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void MDLMEDANPLD()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1454f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 984.0);
		UILabel uILabel = mText;
		object[] array = new object[7];
		array[0] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[4] = HAOHIGPKLLL.name;
		array[3] = MEJMLNDFDBP.OLHOHLGMFBK(num * -44 * -52 * -5);
		uILabel.text = Localization.LocalizeFormat("ID_GUI_SQUADLEVELEDUP_CARDPOOLINC", array);
	}

	private void MLLJAPBBJMC(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mButtonContinue.gameObject);
	}

	public void OMCEGPODDHL(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1119f);
	}

	public void AJCILBFBNMK(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1175f);
	}

	private void GDJBJMMIPBM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	private void OJMLGFFNHFE(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void FEGPCLBPIOI()
	{
		MBNJPBNNJPM(mButtonContinue.gameObject);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void ANDKEDMDFGP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void AFABKGHDPHB()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(125f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 1068.0);
		UILabel uILabel = mText;
		object[] array = new object[0];
		array[0] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[0] = HAOHIGPKLLL.name;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(num * -119 * 66 * 78);
		uILabel.text = Localization.LocalizeFormat("WFX_MF", array);
	}

	public void ShowDialog(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void OPICOKKMEKG(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 38f);
	}

	private void AFJDDCHHGCA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void LIEGBJHHFIG()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1257f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 1798.0);
		UILabel uILabel = mText;
		object[] array = new object[8];
		array[0] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[4] = HAOHIGPKLLL.name;
		array[7] = MEJMLNDFDBP.OLHOHLGMFBK(num * -10 * -49 * -106);
		uILabel.text = Localization.LocalizeFormat("Country", array);
	}

	public GuiElement HDAEPEKEFCE()
	{
		return this;
	}

	public virtual void PNLGFNBEOLG()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(143f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 1763.0);
		UILabel uILabel = mText;
		object[] array = new object[2];
		array[1] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[0] = HAOHIGPKLLL.name;
		array[1] = MEJMLNDFDBP.OLHOHLGMFBK(num * 91 * 48 * 48);
		uILabel.text = Localization.LocalizeFormat("SMG_run", array);
	}

	public void PJDNPHAHFBE(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 25f);
	}

	public virtual void PGHAMCBHBOD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MLLJAPBBJMC));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFKPJALCMKM));
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DBOGOHLCPCE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void DFMCKHMFNHO()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1339f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 288.0);
		UILabel uILabel = mText;
		object[] array = new object[5];
		array[1] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[1] = HAOHIGPKLLL.name;
		array[4] = MEJMLNDFDBP.OLHOHLGMFBK(num * 118 * -82 * -64);
		uILabel.text = Localization.LocalizeFormat("fr-FR", array);
	}

	public GuiElement EJHNJALEFHJ()
	{
		return this;
	}

	private void MLNKJFOMJLE(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	private void GFKPJALCMKM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement AMKOIKGIMLN()
	{
		return this;
	}

	public virtual void HCGDNLHIOBL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MJODJGFHNGB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFKPJALCMKM));
	}

	public virtual void ILHPNHECBJG()
	{
		GFKPJALCMKM(mButtonContinue.gameObject);
	}

	public virtual void PPLBJDJIIPN()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1422f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 1237.0);
		UILabel uILabel = mText;
		object[] array = new object[6];
		array[1] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[3] = HAOHIGPKLLL.name;
		array[6] = MEJMLNDFDBP.OLHOHLGMFBK(num * -85 * -62 * 28);
		uILabel.text = Localization.LocalizeFormat("no pack name", array);
	}

	private void GCPGEEOGGBJ(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void KBKGCLEBJFA()
	{
		LJADGDDPCHF(mButtonContinue.gameObject);
	}

	public virtual void ICKDDKGDBON()
	{
		MDAFMMKHANB(mButtonContinue.gameObject);
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGDLFIDPNNL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LJADGDDPCHF));
	}

	public GuiElement KDMHKOBOOFM()
	{
		return this;
	}

	public virtual void JLIJMJCJHGF()
	{
		GCPGEEOGGBJ(mButtonContinue.gameObject);
	}

	public void BBGJMMKIGJG(PlayerVisual LGDDJNBEJIN, int OOJLAJLBCPB)
	{
		HAOHIGPKLLL = LGDDJNBEJIN;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1214f);
	}

	public GuiElement LLMDPKEJJHI()
	{
		return this;
	}

	public virtual void FCPGJBMGBLJ()
	{
		LJADGDDPCHF(mButtonContinue.gameObject);
	}

	private void CFMBCFHLNHK(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void EIPIEOCIGKL()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1205f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 90.0);
		UILabel uILabel = mText;
		object[] array = new object[6];
		array[1] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[1] = HAOHIGPKLLL.name;
		array[7] = MEJMLNDFDBP.OLHOHLGMFBK(num * -14 * 31 * 120);
		uILabel.text = Localization.LocalizeFormat("ID_COOPCANCELED", array);
	}

	private void MJODJGFHNGB(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void EHNFJGINHDJ()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1112f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 102.0);
		UILabel uILabel = mText;
		object[] array = new object[8];
		array[0] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[7] = HAOHIGPKLLL.name;
		array[6] = MEJMLNDFDBP.OLHOHLGMFBK(num * 52 * -118 * -113);
		uILabel.text = Localization.LocalizeFormat("Tier", array);
	}

	public virtual void JCGDALOBGHO()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1489f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 579.0);
		UILabel uILabel = mText;
		object[] array = new object[5];
		array[0] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[4] = HAOHIGPKLLL.name;
		array[2] = MEJMLNDFDBP.OLHOHLGMFBK(num * -37 * -81 * -81);
		uILabel.text = Localization.LocalizeFormat("x{0}", array);
	}

	private void IAKGJJEGAFM(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	public virtual void EFKFHFNAOHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJMLGFFNHFE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MDAFMMKHANB));
	}

	private void LBOGOJEOFMO(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void HKKHHAKOFHL()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1357f);
		int num = (int)(HAOHIGPKLLL.remainingTime / 662.0);
		UILabel uILabel = mText;
		object[] array = new object[4];
		array[0] = Colours.stringGreenArena;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[7] = HAOHIGPKLLL.name;
		array[2] = MEJMLNDFDBP.OLHOHLGMFBK(num * 1 * 79 * -111);
		uILabel.text = Localization.LocalizeFormat("'friend'0", array);
	}

	public virtual void BCGIKEKOPLL()
	{
		LJADGDDPCHF(mButtonContinue.gameObject);
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ACOECCEDEPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MDAFMMKHANB));
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	public virtual void IDKBKFNPAPD()
	{
		MDAFMMKHANB(mButtonContinue.gameObject);
	}

	private void ACOECCEDEPF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(HAOHIGPKLLL);
			HideDialog();
		}
	}

	public virtual void JNLAEKOOMMH()
	{
		mTitle.text = HAOHIGPKLLL.name.ToUpper();
		mCrown.spriteName = HAOHIGPKLLL.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(635f);
		int num = (int)(HAOHIGPKLLL.AOLJCFDNMEL() / 37.0);
		UILabel uILabel = mText;
		object[] array = new object[2];
		array[1] = Colours.stringGreenArena;
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(JOFAMPIFPIF);
		array[0] = HAOHIGPKLLL.name;
		array[2] = MEJMLNDFDBP.OLHOHLGMFBK(num * -125 * 110 * 46);
		uILabel.text = Localization.LocalizeFormat("ID_LEVEL", array);
	}
}
