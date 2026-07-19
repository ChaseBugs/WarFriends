using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SubmitVideoDialog : GuiElementSingle<SubmitVideoDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Input")]
	private UIInput mVideoLinkInput;

	[SerializeField]
	private UILabel mHintLabel;

	[SerializeField]
	[Header("Hint")]
	private BoxCollider mHintCollider;

	[SerializeField]
	private UISprite mHintIcon;

	[SerializeField]
	private UIPanel mHintDialogPanel;

	[SerializeField]
	private BoxCollider mHintDialogCollider;

	[SerializeField]
	[Header("Buttons")]
	private GameObject mCloseButton;

	[SerializeField]
	private GameObject mSubmitButton;

	private bool EGEDDPMJELL;

	private void HBOFLFHFDOB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HGOAIEDOAEP();
		}
	}

	private void OGELDMBCJHJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (EGEDDPMJELL)
			{
				HGOAIEDOAEP();
			}
			else
			{
				DJDLPEFIHHO();
			}
		}
	}

	public GuiElement HHMPBPKPEKD()
	{
		return this;
	}

	private void IIPMPDJLDPF(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
	}

	public GuiElement LGCLDIDHJHB()
	{
		return this;
	}

	private void BBGPJOJOIEA(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(false);
	}

	private void CKPKIKJFMIE()
	{
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 753f, 514f).onFinished = PBFMKHLEIFD;
	}

	public virtual void CAALKACDJEK()
	{
		mVideoLinkInput.defaultText = Localization.Localize("Call ConnectToNameServer to ping available regions.");
		int num = 6;
		mHintLabel.text = Localization.LocalizeFormat("BlackMarketOffer", num);
	}

	private void MOFHDMPDMGJ()
	{
		EGEDDPMJELL = true;
		mHintDialogPanel.alpha1 = 443f;
		mHintDialogPanel.gameObject.SetActive(true);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	private void NNNANGBNCHA()
	{
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1755f, 729f).onFinished = OIBICJGNHFM;
	}

	public virtual void HFLEDEBGPBI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMIFEJHCDOH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BIDHMEPFGII));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EFCJFJFKAEE));
		MOFHDMPDMGJ();
	}

	public virtual void KCEOCJGOPMF()
	{
		JNEODNPDLCL(mCloseButton);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void HLPIGMMOIPJ(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(false);
	}

	private void LDPMHHCOLFF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			string text = mVideoLinkInput.text;
			if (string.IsNullOrEmpty(text) || text.Length < 6)
			{
				string stringRedWarning = Colours.stringRedWarning;
				object[] array = new object[6];
				array[1] = Colours.stringWhite;
				array[0] = Colours.stringRedWarning;
				WarningDialog.KHOMNBHMFGA(stringRedWarning + Localization.LocalizeFormat(" TOTAL ALLOCATED: ", array), Localization.Localize("DailyBonus"), 284f, null, string.Empty, true, true);
			}
			else
			{
				MHEHGPLIFHF.CDPMHEAJPCN(mVideoLinkInput.text);
				HideDialog();
			}
		}
	}

	private void IKNIJPLOMCC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (EGEDDPMJELL)
			{
				LPKDPHAPDGL();
			}
			else
			{
				NIPEIIMAPPM();
			}
		}
	}

	private void ENODMGPKLCM(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
	}

	private void KJINDLKEIOB(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	private void JNFEBKIELEA()
	{
		mHintDialogPanel.alpha1 = 0.005f;
		mHintDialogPanel.gameObject.SetActive(true);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 0.3f, 1f).onFinished = delegate
		{
			mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		};
	}

	private void IACFLBFCICC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (EGEDDPMJELL)
			{
				LAAOLNBADMM();
			}
			else
			{
				EKMGBNGFOPK();
			}
		}
	}

	public virtual void BBIHNICEDGE()
	{
		base.DoAfterHide();
		MOFHDMPDMGJ();
	}

	public virtual void DNFPEBEDLIG()
	{
		mVideoLinkInput.defaultText = Localization.Localize("OnDeath End");
		int num = 8;
		UILabel uILabel = mHintLabel;
		object[] array = new object[0];
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("VisualType", array);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		GNNIDEFLEKC();
	}

	private void CMCAFPBIIAC(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	public virtual void EEFEFOHKIBF()
	{
		base.DoAfterHide();
		MCLLNGINIHB();
	}

	public GuiElement IBAKPCCGMKI()
	{
		return this;
	}

	private void BIBGCAKJFMH()
	{
		EGEDDPMJELL = true;
		mHintDialogPanel.alpha1 = 1967f;
		mHintDialogPanel.gameObject.SetActive(true);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	private void ACAAOCNELCL(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	public virtual void DLDGKEHFKDP()
	{
		base.OIMKKAHOEKO();
		AMGIOJDMDPK();
	}

	private void BBGJGPDKJOL()
	{
		mHintDialogPanel.alpha1 = 635f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 889f, 402f).onFinished = delegate
		{
			mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		};
	}

	private void KOOBMLLDEPE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			CKPKIKJFMIE();
		}
	}

	private void JGJJIDHFNMB(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			string text = mVideoLinkInput.text;
			if (string.IsNullOrEmpty(text) || text.Length < 2)
			{
				string stringRedWarning = Colours.stringRedWarning;
				object[] array = new object[0];
				array[0] = Colours.stringWhite;
				array[1] = Colours.stringRedWarning;
				WarningDialog.ShowError(stringRedWarning + Localization.LocalizeFormat("PlayerLevel", array), Localization.Localize("D"), 552f, null, string.Empty, false, true);
			}
			else
			{
				MHEHGPLIFHF.ICCFCMFAKMO(mVideoLinkInput.text);
				HideDialog();
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void NAEDEGMIBNH(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (EGEDDPMJELL)
			{
				HGOAIEDOAEP();
			}
			else
			{
				NNMLHDCCFDO();
			}
		}
	}

	private void MMGLPPKHCCM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public override void OIMKKAHOEKO()
	{
		base.DoAfterHide();
		DOELJALPOGO();
	}

	private void BIDHMEPFGII(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (EGEDDPMJELL)
			{
				HGOAIEDOAEP();
			}
			else
			{
				JNFEBKIELEA();
			}
		}
	}

	private void DKMDDMJNFIK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			string text = mVideoLinkInput.text;
			if (string.IsNullOrEmpty(text) || text.Length < 3)
			{
				WarningDialog.ShowError(Colours.stringRedWarning + Localization.LocalizeFormat("ID_ERROR_SHORTINPUT", Colours.stringWhite, Colours.stringRedWarning), Localization.Localize("ID_WARNING_INVALIDLINK"), 0f, null, string.Empty);
			}
			else
			{
				MHEHGPLIFHF.PNHDGLHLNIE(mVideoLinkInput.text);
				HideDialog();
			}
		}
	}

	public virtual void IMKECOIFJFK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMIFEJHCDOH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MEHPJFJJHAI));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BIDHMEPFGII));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HBOFLFHFDOB));
		GNNIDEFLEKC();
	}

	private void GNNIDEFLEKC()
	{
		EGEDDPMJELL = false;
		mHintDialogPanel.alpha1 = 0f;
		mHintDialogPanel.gameObject.SetActive(false);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DKMDDMJNFIK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BIDHMEPFGII));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		GNNIDEFLEKC();
	}

	private void ANGNCHFAMEK()
	{
		mHintDialogPanel.alpha1 = 1668f;
		mHintDialogPanel.gameObject.SetActive(true);
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1208f, 220f).onFinished = IIPMPDJLDPF;
	}

	private void EFCJFJFKAEE(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HGOAIEDOAEP();
		}
	}

	private void MKNBINKBPPL()
	{
		EGEDDPMJELL = false;
		mHintDialogPanel.alpha1 = 1266f;
		mHintDialogPanel.gameObject.SetActive(false);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	private void PCPJAKNOKMK(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
	}

	private void EKMGBNGFOPK()
	{
		mHintDialogPanel.alpha1 = 1636f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 223f, 540f).onFinished = IIPMPDJLDPF;
	}

	public virtual void MKPIKCBBKIB()
	{
		MEHPJFJJHAI(mCloseButton);
	}

	[CompilerGenerated]
	private void DDKEOGGNKFC(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
	}

	private void DLALCNMFJIK(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
	}

	public virtual void OPKPLEGMOPI()
	{
		mVideoLinkInput.defaultText = Localization.Localize("BAND_TYPE_DAMAGE");
		int num = 4;
		UILabel uILabel = mHintLabel;
		object[] array = new object[0];
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("L", array);
	}

	public virtual void FKOEHKCLAEG()
	{
		mVideoLinkInput.defaultText = Localization.Localize("ID_CONFIRM_ERROR");
		int num = 8;
		UILabel uILabel = mHintLabel;
		object[] array = new object[0];
		array[0] = num;
		uILabel.text = Localization.LocalizeFormat("ID_READYTIME", array);
	}

	private void OBIMNDEMCCL()
	{
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 381f, 1716f).onFinished = delegate
		{
			mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			mHintDialogPanel.gameObject.SetActive(false);
		};
	}

	private void OIBICJGNHFM(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(false);
	}

	private void HGOAIEDOAEP()
	{
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 0.3f, 0f).onFinished = delegate
		{
			mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			mHintDialogPanel.gameObject.SetActive(false);
		};
	}

	private void HFKLDKIEBGK(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void HLBIJGPEPIO()
	{
		base.OIMKKAHOEKO();
		BIBGCAKJFMH();
	}

	private void NNMLHDCCFDO()
	{
		mHintDialogPanel.alpha1 = 1162f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1960f, 859f).onFinished = PCPJAKNOKMK;
	}

	public virtual void PDHNLAMPOBN()
	{
		mVideoLinkInput.defaultText = Localization.Localize("ID_STAT_MINIGUNKILLS");
		int num = 4;
		UILabel uILabel = mHintLabel;
		object[] array = new object[1];
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("Amount", array);
	}

	private void DJDLPEFIHHO()
	{
		mHintDialogPanel.alpha1 = 167f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1983f, 1137f).onFinished = DLALCNMFJIK;
	}

	private void PBFMKHLEIFD(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(false);
	}

	public virtual void FEAALEEPBFP()
	{
		mVideoLinkInput.defaultText = Localization.Localize("ID_GUI_VIPMEMBERSHIP");
		int num = 3;
		mHintLabel.text = Localization.LocalizeFormat("ID_SELECTFRIENDERRORNORESULT", num);
	}

	private void EDDGMAPMNKA(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(false);
	}

	private void DCPGACMJJJA()
	{
		mHintDialogPanel.alpha1 = 616f;
		mHintDialogPanel.gameObject.SetActive(true);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 63f, 1398f).onFinished = LDDHMMNJGED;
	}

	private void ECADABKANMC(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	private void OEDPFDBMPCF()
	{
		mHintDialogPanel.alpha1 = 1444f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1057f, 1465f).onFinished = ENODMGPKLCM;
	}

	private void BEFGADJBKPF()
	{
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1340f, 1029f).onFinished = ACAAOCNELCL;
	}

	private void LAAOLNBADMM()
	{
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 503f, 433f).onFinished = OIBICJGNHFM;
	}

	private void LDCODEEMMAC(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	public virtual void EJGCLLIGBCB()
	{
		JNEODNPDLCL(mCloseButton);
	}

	private void MPDCAJHBFNA()
	{
		mHintDialogPanel.alpha1 = 670f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 521f, 135f).onFinished = delegate
		{
			mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		};
	}

	private void PGPDLPDDPBI()
	{
		mHintDialogPanel.alpha1 = 884f;
		mHintDialogPanel.gameObject.SetActive(true);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1764f, 1126f).onFinished = ENODMGPKLCM;
	}

	private void HNDEGABFODL()
	{
		mHintDialogPanel.alpha1 = 973f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 995f, 1552f).onFinished = ENODMGPKLCM;
	}

	private void MCLLNGINIHB()
	{
		EGEDDPMJELL = false;
		mHintDialogPanel.alpha1 = 246f;
		mHintDialogPanel.gameObject.SetActive(true);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	public virtual void EAFNEKHOJAH()
	{
		JNEODNPDLCL(mCloseButton);
	}

	private void JNEODNPDLCL(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void KCIALEJPHMK()
	{
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 715f, 230f).onFinished = KDEFBCPNPJB;
	}

	private void HLOLBGFOEDP(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	private void FMIFEJHCDOH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			string text = mVideoLinkInput.text;
			if (string.IsNullOrEmpty(text) || text.Length < 5)
			{
				string stringRedWarning = Colours.stringRedWarning;
				object[] array = new object[1];
				array[0] = Colours.stringWhite;
				array[0] = Colours.stringRedWarning;
				WarningDialog.JACKIDKHKAI(stringRedWarning + Localization.LocalizeFormat("0", array), Localization.Localize("RETRYPERM"), 1802f, null, string.Empty, true, true);
			}
			else
			{
				MHEHGPLIFHF.FLCADAOMPLO(mVideoLinkInput.text);
				HideDialog();
			}
		}
	}

	public virtual void KJGJNENLEOF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DKMDDMJNFIK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NAEDEGMIBNH));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EFCJFJFKAEE));
		AMGIOJDMDPK();
	}

	private void LDDHMMNJGED(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
	}

	private void LLEFGACNOKM()
	{
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1660f, 487f).onFinished = KJINDLKEIOB;
	}

	private void HDKFHDBAGFK()
	{
		EGEDDPMJELL = true;
		mHintDialogPanel.alpha1 = 315f;
		mHintDialogPanel.gameObject.SetActive(true);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	public virtual void ACLOLICAKGL()
	{
		mVideoLinkInput.defaultText = Localization.Localize("Gold");
		int num = 7;
		mHintLabel.text = Localization.LocalizeFormat("Days_Since_Install", num);
	}

	public virtual void LBIJJNEOELO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGAOIFBBOGG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BIDHMEPFGII));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		MKNBINKBPPL();
	}

	private void PAGMNHMCMOF(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HGOAIEDOAEP();
		}
	}

	public GuiElement ICGDGPCIMGG()
	{
		return this;
	}

	public virtual void CBOBIADFILJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JGJJIDHFNMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MMGLPPKHCCM));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IACFLBFCICC));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		AMGIOJDMDPK();
	}

	public virtual void FNMPBHIIEJP()
	{
		base.DoAfterHide();
		MCLLNGINIHB();
	}

	public override void InitGUIValues()
	{
		mVideoLinkInput.defaultText = Localization.Localize("ID_PASTEYOURVIDEOLINKHERE");
		int num = 5;
		mHintLabel.text = Localization.LocalizeFormat("ID_REMEMBERYOUCANSUBMITXVIDEOS", num);
	}

	private void IIEODOAPMFM(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AFGOKBIDGII));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MMGLPPKHCCM));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IKNIJPLOMCC));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JKPFDMPELBN));
		MOFHDMPDMGJ();
	}

	private void ADDJMFAJFHC(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			string text = mVideoLinkInput.text;
			if (string.IsNullOrEmpty(text) || text.Length < 5)
			{
				string stringRedWarning = Colours.stringRedWarning;
				object[] array = new object[0];
				array[0] = Colours.stringWhite;
				array[1] = Colours.stringRedWarning;
				WarningDialog.ShowError(stringRedWarning + Localization.LocalizeFormat("First_Time_Check_Leagues", array), Localization.Localize("Cant fing player"), 908f, null, string.Empty, false, true);
			}
			else
			{
				MHEHGPLIFHF.OOHAOGELPIM(mVideoLinkInput.text);
				HideDialog();
			}
		}
	}

	private void KDEFBCPNPJB(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(true);
	}

	private void AFGOKBIDGII(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			string text = mVideoLinkInput.text;
			if (string.IsNullOrEmpty(text) || text.Length < 7)
			{
				string stringRedWarning = Colours.stringRedWarning;
				object[] array = new object[1];
				array[1] = Colours.stringWhite;
				array[1] = Colours.stringRedWarning;
				WarningDialog.JACKIDKHKAI(stringRedWarning + Localization.LocalizeFormat("Buy_Weapon_Upgrade", array), Localization.Localize("Gold"), 805f, null, string.Empty, true);
			}
			else
			{
				MHEHGPLIFHF.OOGPGLGDAIJ(mVideoLinkInput.text);
				HideDialog();
			}
		}
	}

	private void NIPEIIMAPPM()
	{
		mHintDialogPanel.alpha1 = 1121f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1448f, 1093f).onFinished = IIPMPDJLDPF;
	}

	public virtual void JCIBDJMFOLI()
	{
		mVideoLinkInput.defaultText = Localization.Localize("Subscription");
		int num = 4;
		UILabel uILabel = mHintLabel;
		object[] array = new object[1];
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("ID_TUTORIAL_PROGRESS_SNIPER", array);
	}

	private void DOELJALPOGO()
	{
		EGEDDPMJELL = false;
		mHintDialogPanel.alpha1 = 1636f;
		mHintDialogPanel.gameObject.SetActive(true);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	public virtual void PAHEFBCOENP()
	{
		mVideoLinkInput.defaultText = Localization.Localize("Army_Unit_ID");
		int num = 1;
		mHintLabel.text = Localization.LocalizeFormat("Client", num);
	}

	public GuiElement EMILFFGPHGK()
	{
		return this;
	}

	public virtual void KFANFNCILJI()
	{
		mVideoLinkInput.defaultText = Localization.Localize("(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Z");
		int num = 0;
		UILabel uILabel = mHintLabel;
		object[] array = new object[1];
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("ShieldRechargeRate", array);
	}

	private void CHEHNCHAPIK()
	{
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 628f, 944f).onFinished = ACAAOCNELCL;
	}

	private void LPKDPHAPDGL()
	{
		EGEDDPMJELL = true;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 1727f, 372f).onFinished = IIEODOAPMFM;
	}

	private void HDKHFPADCIO(UITweener MGDJMGHCAAI)
	{
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		mHintDialogPanel.gameObject.SetActive(false);
	}

	private void CGAOIFBBOGG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			string text = mVideoLinkInput.text;
			if (string.IsNullOrEmpty(text) || text.Length < 8)
			{
				WarningDialog.ShowError(Colours.stringRedWarning + Localization.LocalizeFormat("Grenadier", Colours.stringWhite, Colours.stringRedWarning, null, null, null, null), Localization.Localize("dogTagTimerLock"), 1433f, null, string.Empty, true);
			}
			else
			{
				MHEHGPLIFHF.HPLDKJICLND(mVideoLinkInput.text);
				HideDialog();
			}
		}
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mSubmitButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGAOIFBBOGG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MMGLPPKHCCM));
		UIEventListener uIEventListener3 = UIEventListener.Get(mHintCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CJIHJNIECEB));
		UIEventListener uIEventListener4 = UIEventListener.Get(mHintDialogCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HBOFLFHFDOB));
		MKNBINKBPPL();
	}

	private void AMGIOJDMDPK()
	{
		EGEDDPMJELL = true;
		mHintDialogPanel.alpha1 = 834f;
		mHintDialogPanel.gameObject.SetActive(false);
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
	}

	private void JKPFDMPELBN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HGOAIEDOAEP();
		}
	}

	private void MEHPJFJJHAI(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void DJMCADMNEDH()
	{
		mVideoLinkInput.defaultText = Localization.Localize("RefillRPC");
		int num = 5;
		UILabel uILabel = mHintLabel;
		object[] array = new object[0];
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("ID_NOTIFICATION_LAPSED_MORE", array);
	}

	private void CJIHJNIECEB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (EGEDDPMJELL)
			{
				LLEFGACNOKM();
			}
			else
			{
				JFNECBDHIBA();
			}
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(mCloseButton);
	}

	public virtual void POFPIJKJFBP()
	{
		base.OIMKKAHOEKO();
		AMGIOJDMDPK();
	}

	private void JFNECBDHIBA()
	{
		mHintDialogPanel.alpha1 = 1131f;
		mHintDialogPanel.gameObject.SetActive(false);
		EGEDDPMJELL = false;
		TweenAlpha.Begin(mHintDialogPanel.gameObject, 997f, 1641f).onFinished = delegate
		{
			mHintIcon.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		};
	}

	private void JFFKPFBGMGC(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			LPKDPHAPDGL();
		}
	}
}
