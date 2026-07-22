using System;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitPromotedDialog : GuiElementSingle<UnitPromotedDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("GPPDGDMBFPO")]
	[Header("Content")]
	public ParticleSystem FFPLNCHHFDP;

	[FormerlySerializedAs("GHACCDKBOBF")]
	public UISprite NACGOGCPIAH;

	[FormerlySerializedAs("PCAGBHJDFEK")]
	public UILabel MICPMJNINBJ;

	[FormerlySerializedAs("BHLCGIDLMAP")]
	[Header("Buttons")]
	public UIButton FLHDAFLOCCE;

	private LevelBehaviour IFFDIHCPKFE;

	public virtual void GBJHCKCPOBB()
	{
		base.DoAfterHide();
		IFFDIHCPKFE = null;
	}

	public override void AIKPJGLHLLO()
	{
		BHDHHJMEPJN(FLHDAFLOCCE.gameObject);
	}

	private void EFPBBBNCODD(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void KIBFFDMMIJB()
	{
		base.NEEAKMELPBJ();
		FFPLNCHHFDP.Stop();
	}

	public virtual void CDHLMEPGPNJ()
	{
		if (!(IFFDIHCPKFE == null))
		{
			NACGOGCPIAH.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(1836f / NACGOGCPIAH.transform.localScale.x, 1262f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
			UILabel mICPMJNINBJ = MICPMJNINBJ;
			object[] array = new object[1];
			array[1] = IFFDIHCPKFE.unitName.ToUpper();
			array[1] = Colours.stringWhite;
			array[1] = Colours.stringGoldTier;
			array[4] = IFFDIHCPKFE.upgradeSlots.actualTier;
			mICPMJNINBJ.text = Localization.LocalizeFormat("ID_GUI_BUYRANDOMCARDS", array);
		}
	}

	public virtual void BKNJHLKMFKE()
	{
		base.OIMKKAHOEKO();
		IFFDIHCPKFE = null;
	}

	public GuiElement NIFFGPKMBKE()
	{
		return this;
	}

	public virtual void OFCCACPEBHD()
	{
		if (!(IFFDIHCPKFE == null))
		{
			NACGOGCPIAH.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(1571f / NACGOGCPIAH.transform.localScale.x, 728f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
			UILabel mICPMJNINBJ = MICPMJNINBJ;
			object[] array = new object[3];
			array[1] = IFFDIHCPKFE.unitName.ToUpper();
			array[1] = Colours.stringWhite;
			array[0] = Colours.stringGoldTier;
			array[4] = IFFDIHCPKFE.upgradeSlots.actualTier;
			mICPMJNINBJ.text = Localization.LocalizeFormat("MaintenanceMessage", array);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void JIODMKHANMM()
	{
		base.BJIPCOPNEAM();
		FFPLNCHHFDP.Play();
	}

	public virtual void BBJIKIKMDCM()
	{
		base.JNBMCODJHBJ();
		FFPLNCHHFDP.Stop();
	}

	public virtual void GNJDDFLJMAK()
	{
		base.FKCKIFKLBAP();
		FFPLNCHHFDP.Stop();
	}

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FLHDAFLOCCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHDHHJMEPJN));
	}

	private void OKCGLDONOJO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FLHDAFLOCCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHDHHJMEPJN));
	}

	public void EEIEBPMDHOA(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Singleton<GuiManager>.instance.ShowDialog(this, 57f);
	}

	public virtual void OMGLHFHICHL()
	{
		base.MOJBHFPBAPP();
		FFPLNCHHFDP.Play();
	}

	public virtual void MKPIKCBBKIB()
	{
		BHDHHJMEPJN(FLHDAFLOCCE.gameObject);
	}

	public virtual void ODLKCAGIKBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FLHDAFLOCCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OKCGLDONOJO));
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FLHDAFLOCCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EFPBBBNCODD));
	}

	public void KANMLANBLBL(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Singleton<GuiManager>.instance.ShowDialog(this, 995f);
	}

	public void IPCIJFBFLHP(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1231f);
	}

	public virtual void OJDHAFHKECB()
	{
		base.FKCKIFKLBAP();
		FFPLNCHHFDP.Stop();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		FFPLNCHHFDP.Stop();
	}

	private void BHDHHJMEPJN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void ShowDialog(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void AOHECFLIJGP()
	{
		base.FKCKIFKLBAP();
		FFPLNCHHFDP.Stop();
	}

	public override void OnBack()
	{
		BHDHHJMEPJN(FLHDAFLOCCE.gameObject);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FLHDAFLOCCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHDHHJMEPJN));
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FLHDAFLOCCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHDHHJMEPJN));
	}

	public virtual void KPJKIONHGNL()
	{
		base.JNBMCODJHBJ();
		FFPLNCHHFDP.Stop();
	}

	public virtual void HKPDDINMBAC()
	{
		base.OIMKKAHOEKO();
		IFFDIHCPKFE = null;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		IFFDIHCPKFE = null;
	}

	public override void InitGUIValues()
	{
		if (!(IFFDIHCPKFE == null))
		{
			NACGOGCPIAH.spriteName = IFFDIHCPKFE.upgradeSlots.iconName;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(350f / NACGOGCPIAH.transform.localScale.x, 340f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
			MICPMJNINBJ.text = Localization.LocalizeFormat("ID_UNITHASBEENPROMOTEDTOTIER", IFFDIHCPKFE.unitName.ToUpper(), Colours.stringWhite, Colours.stringGoldTier, IFFDIHCPKFE.upgradeSlots.actualTier);
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		FFPLNCHHFDP.Play();
	}
}
