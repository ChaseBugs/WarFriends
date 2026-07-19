using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WarBucksConfirmDialog : GuiElementSingle<WarBucksConfirmDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	[SerializeField]
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mTextLabel;

	[SerializeField]
	private GameObject mBuyButton;

	[SerializeField]
	private UITable mPriceTable;

	[SerializeField]
	private UILabel mGoldLabel;

	private InAppDataManager.InappDefinition LJKOPCPDPFL;

	private Action<bool> PMFAEKAALAK;

	private void FCCGLAONMOJ(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public GuiElement AHDGOCGHIHJ()
	{
		return this;
	}

	public GuiElement BBBFIJMJOCP()
	{
		return this;
	}

	public virtual void EFINNDNBJDN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CLECGBJLOGN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAFEJGDDCGO));
		mPriceTable.onReposition = MGALGNDOBBM;
	}

	private void OIDNJLCGMHO(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public virtual void NOMBEBADCKJ()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public virtual void NMMEDNEGDNI()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	private void AJNFCLPCFCL()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1280f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void CBOBIADFILJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEHFGBFMOGL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = AJNFCLPCFCL;
	}

	public virtual void EJLHAPDGBCL()
	{
		OEEEAMKAAJE(mCloseButton);
	}

	private void INFAOFEJCJJ(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public void ShowDialog(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance);
	}

	private void HECLHGPCBHJ()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 642f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void PAHEFBCOENP()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.EBIHNPDKAJD());
		mPriceTable.repositionNow = false;
		mTextLabel.text = Localization.LocalizeFormat("#PETER# User was watching ad - waiting for server reward", MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount));
	}

	private void KEHFGBFMOGL(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void LFDIOJJLKCG()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	private void FMHNFPEHKKJ()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1552f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void MHOAADPCCIP()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1234f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public void PJDNPHAHFBE(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 1643f);
	}

	public virtual void AKPHBJHGBKF()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public void HLGALFANPBC(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 82f);
	}

	public virtual void CNOLAKPOBIF()
	{
		MDAFMMKHANB(mCloseButton);
	}

	private void IDJMEDOGFGI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public void EBELHKPCLBI(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 931f);
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OEEEAMKAAJE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = BHADJPEPODO;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mCloseButton);
	}

	public void JKIMMLIGLAF(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 1546f);
	}

	private void OEEEAMKAAJE(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public void PCBDDAMEPCJ(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 642f);
	}

	public virtual void MDHMNEPADOK()
	{
		MILCLFOEHCP(mCloseButton);
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	public virtual void FJFDJJJNCAJ()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public virtual void INPIJKMMADI()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public GuiElement KBCHMKHIADB()
	{
		return this;
	}

	private void BHADJPEPODO()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 366f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void MGALGNDOBBM()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 595f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void CFKMKONHEHE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void JAEMPMDIACE()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public virtual void OCFOEGJBNCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CLECGBJLOGN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FNICMELODII));
		mPriceTable.onReposition = GGNGBHPPNLL;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void MAFEJGDDCGO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	private void DFFDOIFMGKE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public virtual void NIHENNDPJFB()
	{
		CFKMKONHEHE(mCloseButton);
	}

	private void OKFMJOFEBAO()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 235f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public void IPCIJFBFLHP(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 1836f);
	}

	public virtual void CAJPNCELIJA()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	private void GGNGBHPPNLL()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1770f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public void JOOFMNHIJPK(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 772f);
	}

	private void FMAGLNJIMKF()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 510f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void BBIHNICEDGE()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	public virtual void GMOFOOGNOAH()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.EBIHNPDKAJD());
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount);
		uILabel.text = Localization.LocalizeFormat("DamageEventPlayer damage: {0} to {1} new HP {2}", array);
	}

	public virtual void NDBAEHKKJMH()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.PEKNLCLFIME());
		mPriceTable.repositionNow = false;
		mTextLabel.text = Localization.LocalizeFormat("Claim_Day", MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount));
	}

	private void LEADPAPNKGC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void BGDPJGNKPKB()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public void ACFAKGIGBCG(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 175f);
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDAFMMKHANB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAFEJGDDCGO));
		mPriceTable.onReposition = HECLHGPCBHJ;
	}

	public GuiElement NFPBFHJINIC()
	{
		return this;
	}

	public void OMCEGPODDHL(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 1912f);
	}

	public virtual void INMFKHJDBIP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CFKMKONHEHE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DFFDOIFMGKE));
		mPriceTable.onReposition = delegate
		{
			float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
			mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void LMGBCIFHGFL()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 532f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void DLNJFMIDPFE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDAFMMKHANB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FNICMELODII));
		mPriceTable.onReposition = MEMCFDGJDAG;
	}

	private void MDAFMMKHANB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.goldPrice);
		mPriceTable.repositionNow = true;
		mTextLabel.text = Localization.LocalizeFormat("ID_DOYOUWANTTOBUYWARBUCKS", MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void LCMFDLLFBDC()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.goldPrice);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount);
		uILabel.text = Localization.LocalizeFormat("Sniper_Tutorial_Played", array);
	}

	private void MILCLFOEHCP(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public GuiElement IJGPFBLCKJD()
	{
		return this;
	}

	private void NAOPHHPFFPG()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 385f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void IJKLNEDKOOI()
	{
		MILCLFOEHCP(mCloseButton);
	}

	private void INNANKPAMCF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public virtual void GMJCEEHFAJG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CLECGBJLOGN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(INFAOFEJCJJ));
		mPriceTable.onReposition = MHOAADPCCIP;
	}

	public override void OIMKKAHOEKO()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public virtual void FOAALJKPPPC()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.goldPrice);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount);
		uILabel.text = Localization.LocalizeFormat("Action ", array);
	}

	public virtual void FOIGMBKCOBH()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public virtual void GBPEJMFMBJM()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
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

	private void MEMCFDGJDAG()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1013f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void CLECGBJLOGN(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public virtual void MPNFAPKFNHL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(INNANKPAMCF));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FBLCFPKOKLK));
		mPriceTable.onReposition = AJNFCLPCFCL;
	}

	public void EGLMNBKMBAM(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 235f);
	}

	public virtual void MDLMEDANPLD()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.PEKNLCLFIME());
		mPriceTable.repositionNow = false;
		mTextLabel.text = Localization.LocalizeFormat("Id", MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount));
	}

	public virtual void BGPAHPGDDJB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CFKMKONHEHE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FBLCFPKOKLK));
		mPriceTable.onReposition = delegate
		{
			float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
			mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void NODJKBBENBL(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 506f);
	}

	private void FNICMELODII(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public void OOLLHJHMOFJ(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 654f);
	}

	private void DACMCHHPCCF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public virtual void OFCCACPEBHD()
	{
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.EBIHNPDKAJD());
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(LJKOPCPDPFL.warbucksAmount);
		uILabel.text = Localization.LocalizeFormat("N", array);
	}

	public virtual void FMEJLMMLBPD()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(INNANKPAMCF));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FBLCFPKOKLK));
		mPriceTable.onReposition = FMHNFPEHKKJ;
	}

	public void IKJNNOFBFGL(InAppDataManager.InappDefinition GIFJOLADLEB, Action<bool> BLHPGCIDEBE)
	{
		LJKOPCPDPFL = GIFJOLADLEB;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WarBucksConfirmDialog>.instance, 1285f);
	}

	private void FBLCFPKOKLK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(false);
			}
			HideDialog();
		}
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}
}
