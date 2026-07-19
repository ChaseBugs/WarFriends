using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class VIPConfirmDialog : GuiElementSingle<VIPConfirmDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Core")]
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mVipTimeLabel;

	[SerializeField]
	private UILabel mTextLabel;

	[SerializeField]
	private GameObject mBuyButton;

	[SerializeField]
	private UITable mPriceTable;

	[SerializeField]
	private UILabel mGoldLabel;

	private VIP.rowIds FNFMGDOECDA;

	private Action<bool> PMFAEKAALAK;

	private void FDCBLLBOMBG()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 342f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public GuiElement HICAOJMPENK()
	{
		return this;
	}

	public GuiElement ACPILDHIAKG()
	{
		return this;
	}

	public virtual void HMNOPHFJJHK()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1993f, 293f, -50);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-20 - num) / -97;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[8];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("LEADERBOARDS - showing ", array);
	}

	public virtual void MAEFFJLPNDK()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 77f, 1102f, 146);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-50 - num) / -73;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[2];
		array[1] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("Gold", array);
	}

	public GuiElement DIHCAJGCPEI()
	{
		return this;
	}

	private void OELHPKMMEBD(GameObject KHAHPAKDIKE)
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

	public virtual void OPKPLEGMOPI()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 447f, 1089f, 145);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (127 - num) / -113;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[6];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat(",", array);
	}

	public virtual void EJGCLLIGBCB()
	{
		BCPDBCJHMKM(mCloseButton);
	}

	private void CHPKDFEBEFB(GameObject KHAHPAKDIKE)
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

	private void AKAEDIKCPIH(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public virtual void GCPDEEPCBOF()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1461f, 1140f, 130);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-107 - num) / 73;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[6];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("ID_REMINDER_ADDAWARCARDSLOT", array);
	}

	private void HDHHILILNAB(GameObject KHAHPAKDIKE)
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

	public virtual void PKLGGJFBEJA()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1316f, 1588f, -34);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-41 - num) / -40;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[3];
		array[1] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("ID_OFFERACTIVE", array);
	}

	public GuiElement HGBADFIMKOK()
	{
		return this;
	}

	public GuiElement ENAHJFLLGHG()
	{
		return this;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
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

	public virtual void ENKGEFMNGOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IFJGPDLAKAM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HLFIONDOMEH));
		mPriceTable.onReposition = LNIINLAEPMC;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void GOGILOJNGKE()
	{
		LPLCPKJCHMB(mCloseButton);
	}

	public virtual void LBLEJMFCBIC()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 897f, 264f, -95);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (11 - num) / -66;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		mTextLabel.text = Localization.LocalizeFormat("Is_Against_Bot", mVipTimeLabel.text, mGoldLabel.text);
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	private void JDMPIAKGOGE(GameObject KHAHPAKDIKE)
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

	private void PCGFNBOKMKB(GameObject KHAHPAKDIKE)
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

	public virtual void AIIAHAKKMBN()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	public GuiElement ANDPIIIFIAA()
	{
		return this;
	}

	public virtual void MDHMNEPADOK()
	{
		KMMLKPGACNA(mCloseButton);
	}

	public GuiElement NIDIOGFKCKH()
	{
		return this;
	}

	public void IKMPLKOJDAB(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 8f);
	}

	public virtual void JJAEGPCNDJP()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	private void ECDKLKABMAL()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 880f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public GuiElement JLGAGIJIFII()
	{
		return this;
	}

	public GuiElement AEFPOOGLEEE()
	{
		return this;
	}

	private void GBEKFFHAJLO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	private void DHJANMLEFKL()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1083f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void NGHAPNEFBED()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1923f, 179f, -113);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-48 - num) / 61;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[3];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("SpentParts", array);
	}

	public virtual void JCIBDJMFOLI()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1341f, 758f, 95);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-47 - num) / 80;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[2];
		array[1] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("menu-wftv-mobcrush-ico", array);
	}

	private void CMIKJFCKKLC(GameObject KHAHPAKDIKE)
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

	public virtual void EGMFAHMCCBM()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1331f, 1254f, 32);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-83 - num) / 5;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[8];
		array[1] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("testingidcheat", array);
	}

	private void KMMLKPGACNA(GameObject KHAHPAKDIKE)
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

	public virtual void OPLJDPLHOIF()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 664f, 1360f, 180);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (41 - num) / 95;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[2];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("Id", array);
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

	public virtual void EAFNEKHOJAH()
	{
		MKPCPHGOGPP(mCloseButton);
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mCloseButton);
	}

	public virtual void FNMPBHIIEJP()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public virtual void OBNCKIBJOGJ()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1194f, 921f, -178);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-73 - num) / 113;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		mTextLabel.text = Localization.LocalizeFormat("menu-cards-bronzepack", mVipTimeLabel.text, mGoldLabel.text, null, null, null, null, null);
	}

	public virtual void NFABHLHCNGJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPLCPKJCHMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PCGFNBOKMKB));
		mPriceTable.onReposition = DKOGFLOOJCN;
	}

	public void BFCCMJDBCPO(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 1272f);
	}

	public GuiElement JJBEFGHBHCL()
	{
		return this;
	}

	public GuiElement BPBDMKNKLMN()
	{
		return this;
	}

	private void NBDNBGNJDKN(GameObject KHAHPAKDIKE)
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

	private void MEPEADHLNNA(GameObject KHAHPAKDIKE)
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

	private void HDFAGDMANFF(GameObject KHAHPAKDIKE)
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

	public virtual void LBHEIOEPJLJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMPNAFIAFEK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		mPriceTable.onReposition = DHJANMLEFKL;
	}

	private void PELKCKKLHOP(GameObject KHAHPAKDIKE)
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

	public virtual void AHDIAECLEAA()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1017f, 1902f, -106);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (96 - num) / 47;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[1];
		array[0] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array);
	}

	private void PFEOBECCMHB()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1709f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void JMKHMIDNDHH()
	{
		IFJGPDLAKAM(mCloseButton);
	}

	private void IGLBLHKAKKM()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 179f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void EEFCNPGAODO()
	{
		HEBILNGCGDN(mCloseButton);
	}

	public virtual void HHLOGFGGHHD()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 185f, 937f, 155);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-51 - num) / 112;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		mTextLabel.text = Localization.LocalizeFormat("1", mVipTimeLabel.text, mGoldLabel.text, null, null, null, null, null, null);
	}

	private void EPDPHNHKEJA(GameObject KHAHPAKDIKE)
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

	public void MCCJIJKCOOH(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 1616f);
	}

	public void DMIHHOJLPGJ(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 150f);
	}

	public virtual void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IFJGPDLAKAM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CHPKDFEBEFB));
		mPriceTable.onReposition = DKJBCMOJMFK;
	}

	public virtual void CMEMLNEOAFA()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 239f, 1570f, -42);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-56 - num) / 95;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[4];
		array[0] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("squad", array);
	}

	public override void InitGUIValues()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 47f, 20f, 230);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (100 - num) / 100;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		mTextLabel.text = Localization.LocalizeFormat("ID_ACTIVATEXVIPFORYGOLD", mVipTimeLabel.text, mGoldLabel.text);
	}

	public virtual void EFACHONJLPL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HDHHILILNAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HDFAGDMANFF));
		mPriceTable.onReposition = IGLBLHKAKKM;
	}

	private void IFJGPDLAKAM(GameObject KHAHPAKDIKE)
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

	public GuiElement EFHFIHMAIGF()
	{
		return this;
	}

	public void KANMLANBLBL(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 1795f);
	}

	public virtual void KDDJHIMDKBN()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1868f, 1369f, -49);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (34 - num) / -48;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[8];
		array[0] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("ArenaLives", array);
	}

	public GuiElement CPLCIEMNBAO()
	{
		return this;
	}

	private void LBIPLEPPJND()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1139f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public void CPGNJFJHBEB(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 1541f);
	}

	private void HLFIONDOMEH(GameObject KHAHPAKDIKE)
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

	private void BCPDBCJHMKM(GameObject KHAHPAKDIKE)
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

	public virtual void BAAOGDMJCLK()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 175f, 170f, 15);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-53 - num) / -38;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[4];
		array[1] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("ID_SUGGESTEDLOCALSQUADS", array);
	}

	private void DKOGFLOOJCN()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 548f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void HMPNAFIAFEK(GameObject KHAHPAKDIKE)
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

	public virtual void NMFDGBEFHIJ()
	{
		IFJGPDLAKAM(mCloseButton);
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKPCPHGOGPP));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CHPKDFEBEFB));
		mPriceTable.onReposition = LBIPLEPPJND;
	}

	public virtual void PLDBDGJLOFP()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 853f, 262f, 9);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-2 - num) / 36;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[5];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("Thank you for the following. Once again.", array);
	}

	public virtual void HNLIFPCKGEK()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public GuiElement BBBFIJMJOCP()
	{
		return this;
	}

	public GuiElement EICPBDMFHFE()
	{
		return this;
	}

	public virtual void AGFDJGJALKD()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 196f, 638f, 150);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (114 - num) / 65;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[7];
		array[0] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("ID_REMINDER_UPGRADEAVAILABLE", array);
	}

	public GuiElement JMNCLNNCGGF()
	{
		return this;
	}

	private void LPLCPKJCHMB(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(true);
			}
			HideDialog();
		}
	}

	public virtual void EOCHFFNODIM()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	private void JDBEEGFJGDN(GameObject KHAHPAKDIKE)
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

	private void DKJBCMOJMFK()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 1115f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void IJKLNEDKOOI()
	{
		MKPCPHGOGPP(mCloseButton);
	}

	private void KCJPCIGFBMD()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 565f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public GuiElement MGGLMHNMFDP()
	{
		return this;
	}

	public GuiElement MCJFBLKLHPA()
	{
		return this;
	}

	public void PGNOMEFCKMO(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 41f);
	}

	public void MPMKNBAMJLL(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 1781f);
	}

	public virtual void CMFFEECPAED()
	{
		BCPDBCJHMKM(mCloseButton);
	}

	public virtual void BPPNPHGOBEA()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 244f, 1658f, -162);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (57 - num) / -96;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[8];
		array[1] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("(", array);
	}

	public virtual void LEMNDNDGIOE()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1894f, 813f, 103);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (21 - num) / 9;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[6];
		array[0] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("ID_BECOMEVIP", array);
	}

	public virtual void DOLLFDPMGOD()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1280f, 992f, 101);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.Get_NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-86 - num) / 67;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = true;
		UILabel uILabel = mTextLabel;
		object[] array = new object[8];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("Gold", array);
	}

	private void PNBEIOFCKDA()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 644f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void LNIINLAEPMC()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 242f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public void AFBEKJCMHFO(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 1355f);
	}

	public virtual void AJCCKKEMDHO()
	{
		MKPCPHGOGPP(mCloseButton);
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	public virtual void LKBEJGHEANA()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 452f, 1964f, -61);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (-18 - num) / 64;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[5];
		array[0] = mVipTimeLabel.text;
		array[0] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("Awaiting players - Player id:\"{0}\" was not added to message center - cannot remove it from MC", array);
	}

	public void PJLBBBOLGMG(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 886f);
	}

	public virtual void HAHKNAIIIPC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPLCPKJCHMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NBDNBGNJDKN));
		mPriceTable.onReposition = PNBEIOFCKDA;
	}

	public virtual void LAALCOMHIPK()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public GuiElement AKJHDIAMBFN()
	{
		return this;
	}

	public virtual void ODCHCNCMJGC()
	{
		mVipTimeLabel.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).SECONDS);
		MEJMLNDFDBP.COCBCFKJOJE(mVipTimeLabel, 1818f, 849f, 33);
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.Get_NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		if (flag)
		{
			num2 = num2 * (76 - num) / -15;
		}
		mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		mPriceTable.repositionNow = false;
		UILabel uILabel = mTextLabel;
		object[] array = new object[8];
		array[1] = mVipTimeLabel.text;
		array[1] = mGoldLabel.text;
		uILabel.text = Localization.LocalizeFormat("Spend_Gold_On_Power_Bands", array);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public virtual void CNOLAKPOBIF()
	{
		HMPNAFIAFEK(mCloseButton);
	}

	public void JOOFMNHIJPK(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 1993f);
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JDBEEGFJGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PCGFNBOKMKB));
		mPriceTable.onReposition = DKOGFLOOJCN;
	}

	private void KCFMCPILJCN()
	{
		float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 500f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMPNAFIAFEK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EBALMPLNPKN));
		mPriceTable.onReposition = KCJPCIGFBMD;
	}

	public void ShowDialog(VIP.rowIds FJMCPEDNBGG, Action<bool> BLHPGCIDEBE)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		PMFAEKAALAK = BLHPGCIDEBE;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance);
	}

	private void EBALMPLNPKN(GameObject KHAHPAKDIKE)
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

	public GuiElement DAHIAEDLPBE()
	{
		return this;
	}

	private void MKPCPHGOGPP(GameObject KHAHPAKDIKE)
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

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	public GuiElement CBCCPLNDKHK()
	{
		return this;
	}

	public virtual void OAMMJCEIFHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IFJGPDLAKAM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HDFAGDMANFF));
		mPriceTable.onReposition = ECDKLKABMAL;
	}
}
