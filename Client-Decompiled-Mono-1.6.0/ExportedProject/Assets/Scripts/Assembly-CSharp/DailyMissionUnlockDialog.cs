using System;
using UnityEngine;

public class DailyMissionUnlockDialog : GuiElementSingle<DailyMissionUnlockDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Middle")]
	private UILabel mSmallTitle;

	[SerializeField]
	private GameObject mLeftWing;

	[SerializeField]
	private GameObject mRightWing;

	[Header("Bottom")]
	[SerializeField]
	private GameObject mBottomButton;

	public virtual void KPMLFMMINEP()
	{
		mSmallTitle.text = Localization.Localize("\r");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 1403f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 608f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 1774f);
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public virtual void MAEFFJLPNDK()
	{
		mSmallTitle.text = Localization.Localize("ID_NA");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 345f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 1653f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 1717f);
	}

	public virtual void GOGILOJNGKE()
	{
		LHCPEGEAKJK(mBottomButton);
	}

	public void HBLKPCHIPPH()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 695f);
	}

	private void MNPEAFHFMNA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void JKODFKNJOIB()
	{
		NFFPCAIJOJJ(mBottomButton);
	}

	public virtual void PLAKLPJEAHM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OFIOBJOJFGO));
	}

	public virtual void GEKFHJKIAMF()
	{
		MEDMIFHEHOP(mBottomButton);
	}

	public virtual void ILMDHKEMCAM()
	{
		CEJBINIOAGH(mBottomButton);
	}

	public void DJPBIEBIAOJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 512f);
	}

	public virtual void PGEODBJFHFC()
	{
		LHCPEGEAKJK(mBottomButton);
	}

	public virtual void PFCKKOBABEL()
	{
		BOJLCNLLMHN(mBottomButton);
	}

	public virtual void DJIJBPFLOMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DACMCHHPCCF));
	}

	public void NFFOFBDCHMF()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 49f);
	}

	public virtual void JCIBDJMFOLI()
	{
		mSmallTitle.text = Localization.Localize("getRewardedInfoForZoneID");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 720f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 1695f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 100f);
	}

	private void EMINCIOMMMO(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void CEJBINIOAGH(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public void KLMGKBDODBJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1927f);
	}

	public void IFMMDKLNLJL()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 229f);
	}

	public void CKFHOLNFGML()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 867f);
	}

	public virtual void LIEGBJHHFIG()
	{
		mSmallTitle.text = Localization.Localize("Show");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 1614f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 1043f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 1914f);
	}

	public void KAFJNOAIILO()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 978f);
	}

	private void IMMCLCLNKCM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement AHDGOCGHIHJ()
	{
		return this;
	}

	public GuiElement IJGPFBLCKJD()
	{
		return this;
	}

	public virtual void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HFGOPKGBJIK));
	}

	private void OFLNNFBFAEI(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public void GFBDMPINFFP()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 647f);
	}

	public virtual void CJMOCAFCDPE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DACMCHHPCCF));
	}

	public void CBPJNPHOAFN()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 843f);
	}

	public virtual void EJGCLLIGBCB()
	{
		HFGOPKGBJIK(mBottomButton);
	}

	public virtual void ILPCBCHMEOK()
	{
		EMINCIOMMMO(mBottomButton);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void ECIHKLEMBIB()
	{
		mSmallTitle.text = Localization.Localize("UnsentRewards");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 1978f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 1475f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 1580f);
	}

	public GuiElement MLDGJCPHNFA()
	{
		return this;
	}

	private void NFFPCAIJOJJ(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void GAGKEJAFBOH()
	{
		HIMEHJFMKHD(mBottomButton);
	}

	private void OFIOBJOJFGO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EMINCIOMMMO));
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	public GuiElement ENAHJFLLGHG()
	{
		return this;
	}

	private void NFCBPFKEJIJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void MGHNHDOBJFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MEDMIFHEHOP));
	}

	private void LPLCPKJCHMB(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void DOANAOOEAKD()
	{
		HIMEHJFMKHD(mBottomButton);
	}

	public virtual void HFLEDEBGPBI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HFGOPKGBJIK));
	}

	private void BHFAGCAKPNM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void BOJLCNLLMHN(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void LHCPEGEAKJK(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void NMADELLJEPP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OFLNNFBFAEI));
	}

	public virtual void JKDNILNHHLG()
	{
		MEDMIFHEHOP(mBottomButton);
	}

	public void PNAFICLOFAB()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1375f);
	}

	public virtual void EJLHAPDGBCL()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public virtual void DEFCMABOJGD()
	{
		mSmallTitle.text = Localization.Localize("Android");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 525f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 458f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 1045f);
	}

	public virtual void CPAKIBKODJC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HFGOPKGBJIK));
	}

	public virtual void FNNHJPMKDOM()
	{
		IMMCLCLNKCM(mBottomButton);
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void PEIILMKDGBK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHCPEGEAKJK));
	}

	public virtual void NEKKPJFGOKP()
	{
		OFIOBJOJFGO(mBottomButton);
	}

	public GuiElement HMLFKOLADFB()
	{
		return this;
	}

	public GuiElement CPLCIEMNBAO()
	{
		return this;
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMMCLCLNKCM));
	}

	public override void InitGUIValues()
	{
		mSmallTitle.text = Localization.Localize("ID_DAILYMISSIONSUNLOCKEDHINT3TITLE");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 2f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 12f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 12f);
	}

	public virtual void IACJMNAFNCI()
	{
		BHFAGCAKPNM(mBottomButton);
	}

	public GuiElement HDNIHBJDLKF()
	{
		return this;
	}

	public void CAIACJMENOP()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1329f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void OMOACFMFADM()
	{
		MEDMIFHEHOP(mBottomButton);
	}

	public virtual void LBFHGMHJKJC()
	{
		MNPEAFHFMNA(mBottomButton);
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	public GuiElement KBCHMKHIADB()
	{
		return this;
	}

	public virtual void CHPAFPBJAEM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OFIOBJOJFGO));
	}

	public virtual void JCGDALOBGHO()
	{
		mSmallTitle.text = Localization.Localize("\t\"FALSE\"");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 521f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 974f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 1569f);
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DACMCHHPCCF));
	}

	public virtual void HEOMHIGCMOC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BOJLCNLLMHN));
	}

	public virtual void OKMMGFMKJGG()
	{
		mSmallTitle.text = Localization.Localize("UIReflectionEffect reference missing for index ");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 529f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 517f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 1578f);
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CEJBINIOAGH));
	}

	public virtual void HHEEDIHHCEA()
	{
		mSmallTitle.text = Localization.Localize("Beanstalk: On Update device token");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 638f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 154f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 600f);
	}

	public void CKEBENBOEAO()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1271f);
	}

	public void AFBEKJCMHFO()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 333f);
	}

	public void OAAABGFLAFG()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 547f);
	}

	public virtual void OLIOADHMKKA()
	{
		MNPEAFHFMNA(mBottomButton);
	}

	public virtual void PGOMBLHHHKD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EMINCIOMMMO));
	}

	private void DACMCHHPCCF(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void HIMEHJFMKHD(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void MEDMIFHEHOP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void JMNHKBNACBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BOJLCNLLMHN));
	}

	public virtual void CHFHCBLGINB()
	{
		mSmallTitle.text = Localization.Localize("N");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 1215f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 1080f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 12f);
	}

	public void FICIAACOGLB()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 190f);
	}

	public void HLGALFANPBC()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1105f);
	}

	public virtual void JMKDHCIKJMG()
	{
		mSmallTitle.text = Localization.Localize("daily reward claimed");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 1383f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 1639f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 124f);
	}

	public GuiElement MOMKIEKEFFJ()
	{
		return this;
	}

	public virtual void HKFICJFNOPM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EMINCIOMMMO));
	}

	public void GILDIKINMFE()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1192f);
	}

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void JKAKKFIIBLG()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public virtual void PJHCHEHKHEN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void IDKBKFNPAPD()
	{
		NFFPCAIJOJJ(mBottomButton);
	}

	public void IKMPLKOJDAB()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 420f);
	}

	private void HFGOPKGBJIK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public GuiElement LLMDPKEJJHI()
	{
		return this;
	}

	public void OOLLHJHMOFJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 105f);
	}

	public virtual void PBLLMABJFDM()
	{
		mSmallTitle.text = Localization.Localize(" ");
		float num = mSmallTitle.relativeSize.x * mSmallTitle.transform.localScale.x / 308f;
		mLeftWing.transform.localPosition = mLeftWing.transform.localPosition.ReplaceX(0f - num - 109f);
		mRightWing.transform.localPosition = mRightWing.transform.localPosition.ReplaceX(num + 538f);
	}
}
