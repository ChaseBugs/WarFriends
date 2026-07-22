using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SubscriptionConfirmDialog : GuiElementSingle<SubscriptionConfirmDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	[SerializeField]
	private GameObject mCloseButton;

	[Header("Middle")]
	[SerializeField]
	private UILabel mText;

	[SerializeField]
	[FormerlySerializedAs("mGuestAccountPart")]
	private GameObject mDetailsButton;

	[Header("Bottom")]
	[SerializeField]
	[FormerlySerializedAs("mUserAgreementButton")]
	private GameObject mBottomButton;

	private Action<bool> PMFAEKAALAK;

	private bool MDBHMDHAGNA;

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
		}
	}

	private void IFCOACMGAJB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	public virtual void FACKIKMABGK()
	{
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("Unit_Upgrade").Value2;
		mText.text = Localization.LocalizeFormat(DJPHNADGNPJ(), value);
	}

	private string EDBPJEHMCOF()
	{
		return (!MDBHMDHAGNA) ? "ID_CONFIRMSUBSRIPTIONANDROIDTEXT" : "ID_CONFIRMTRAILSUBSRIPTIONANDROIDTEXT";
	}

	public virtual void PFCKKOBABEL()
	{
		MDGOKNMIDIB(mCloseButton);
	}

	public virtual void FNNHJPMKDOM()
	{
		CFKMKONHEHE(mCloseButton);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAAJENFGNJN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
	}

	public override void OIEPFDKMCNC()
	{
		MDGOKNMIDIB(mCloseButton);
	}

	private void GEHOFBCKDBP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionDetailsDialog>.instance, 1228f);
		}
	}

	public virtual void BBIHNICEDGE()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public GuiElement GMPEFKABFGG()
	{
		return this;
	}

	public virtual void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OEEEAMKAAJE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GEHOFBCKDBP));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CHNOMEDHAFD));
	}

	public void ShowDialog(Action<bool> BLHPGCIDEBE, bool OCEFFHCECIL = false)
	{
		PMFAEKAALAK = BLHPGCIDEBE;
		MDBHMDHAGNA = OCEFFHCECIL;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionConfirmDialog>.instance);
	}

	private void PKJCDAKFNNM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	public virtual void CICEFDONBML()
	{
		OEEEAMKAAJE(mCloseButton);
	}

	private void INNANKPAMCF(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	private void HBHENOJONKO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	private string OIIGKIOICHE()
	{
		return (!MDBHMDHAGNA) ? "Leaderboard removed succesfully" : "ID_NOTIFICATION_WARARENAREMINDER{0}";
	}

	public virtual void POFPIJKJFBP()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	public virtual void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDGOKNMIDIB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAAJENFGNJN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFCOACMGAJB));
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	private void DDMOIEPDMCG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	public override void InitGUIValues()
	{
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("subscription1").Value2;
		mText.text = Localization.LocalizeFormat(EDBPJEHMCOF(), value);
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	private string PDMPMCDKPFM()
	{
		return (!MDBHMDHAGNA) ? "gameCenterId" : "/";
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private string HADEPDGDBAH()
	{
		return (!MDBHMDHAGNA) ? "/PC/" : "Gold Spent ";
	}

	public virtual void BCLAFFCPCEH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DDMOIEPDMCG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAAJENFGNJN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CHNOMEDHAFD));
	}

	public void EMBNLMGLNFN(Action<bool> BLHPGCIDEBE, bool OCEFFHCECIL = false)
	{
		PMFAEKAALAK = BLHPGCIDEBE;
		MDBHMDHAGNA = OCEFFHCECIL;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionConfirmDialog>.instance, 55f);
	}

	public void GGDDMHEOENG(Action<bool> BLHPGCIDEBE, bool OCEFFHCECIL = false)
	{
		PMFAEKAALAK = BLHPGCIDEBE;
		MDBHMDHAGNA = OCEFFHCECIL;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionConfirmDialog>.instance, 923f);
	}

	private void OEEEAMKAAJE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
		}
	}

	public virtual void LMNNNHJKMFP()
	{
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(" AND ").Value2;
		UILabel uILabel = mText;
		string keyFormat = HADEPDGDBAH();
		object[] array = new object[0];
		array[1] = value;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	private void CHNOMEDHAFD(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
		}
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDGOKNMIDIB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GEHOFBCKDBP));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PHNAHOPPINB));
	}

	public virtual void KPMLFMMINEP()
	{
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("Changed country to {0} from {1}.").Value2;
		mText.text = Localization.LocalizeFormat(IONBOBHMICJ(), value);
	}

	private string EIFIPGAGANK()
	{
		return (!MDBHMDHAGNA) ? "ID_TUTORIAL_TAPON" : "commando_shooting";
	}

	private void PHNAHOPPINB(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
		}
	}

	private void IDJMEDOGFGI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	public void ACAEMEEFCAH(Action<bool> BLHPGCIDEBE, bool OCEFFHCECIL = false)
	{
		PMFAEKAALAK = BLHPGCIDEBE;
		MDBHMDHAGNA = OCEFFHCECIL;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionConfirmDialog>.instance, 213f);
	}

	public virtual void EKBIKKJHGKB()
	{
		DDMOIEPDMCG(mCloseButton);
	}

	public virtual void PLAKLPJEAHM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OEEEAMKAAJE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GEHOFBCKDBP));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PKJCDAKFNNM));
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mCloseButton);
	}

	private string IONBOBHMICJ()
	{
		return (!MDBHMDHAGNA) ? "ID_ARENAREWARDEXPIRATION" : "{0}{1}";
	}

	private void FHCHEKPCHLJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
		}
	}

	public virtual void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAAJENFGNJN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PKJCDAKFNNM));
	}

	public virtual void EJGCLLIGBCB()
	{
		OEEEAMKAAJE(mCloseButton);
	}

	private void MAAJENFGNJN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: false);
			}
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionDetailsDialog>.instance);
		}
	}

	public virtual void DBMCMLINOPD()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}

	private string DJPHNADGNPJ()
	{
		return (!MDBHMDHAGNA) ? "ExtraRewards" : "ID_ELITEPACK";
	}

	public virtual void CKGGNJACIGL()
	{
		MDGOKNMIDIB(mCloseButton);
	}

	public virtual void MHIGAEFCIAF()
	{
		base.OIMKKAHOEKO();
		PMFAEKAALAK = null;
	}

	private void MDGOKNMIDIB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	public void OPPAFPHDKNL(Action<bool> BLHPGCIDEBE, bool OCEFFHCECIL = false)
	{
		PMFAEKAALAK = BLHPGCIDEBE;
		MDBHMDHAGNA = OCEFFHCECIL;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionConfirmDialog>.instance, 189f);
	}

	public GuiElement JPJLCBBIHFE()
	{
		return this;
	}

	public virtual void MGIDNGCKLCF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DDMOIEPDMCG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mDetailsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAAJENFGNJN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mBottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PHNAHOPPINB));
	}

	public void OAAABGFLAFG(Action<bool> BLHPGCIDEBE, bool OCEFFHCECIL = false)
	{
		PMFAEKAALAK = BLHPGCIDEBE;
		MDBHMDHAGNA = OCEFFHCECIL;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SubscriptionConfirmDialog>.instance, 1342f);
	}

	private void CFKMKONHEHE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (PMFAEKAALAK != null)
			{
				PMFAEKAALAK(obj: true);
			}
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		PMFAEKAALAK = null;
	}
}
