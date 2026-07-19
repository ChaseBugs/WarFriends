using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RenameDialog : GuiElementSingle<RenameDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	public UIInput KAIAJMCHLLD;

	public UILabel IIJCDFHDAGO;

	public UIButton LJNPCHFCGCN;

	[Header("Rename Button")]
	public UIButton EJNLELFGBJE;

	public UILabel FCOPKOJILNB;

	public GameObject DICPLMJFBJF;

	public UITable KPJAHKLCDBB;

	public UILabel GAODBNDPPAO;

	public GuiElement HDAEPEKEFCE()
	{
		return this;
	}

	public GuiElement ACPILDHIAKG()
	{
		return this;
	}

	public virtual void JGOHMOKMCKD()
	{
	}

	private void ECJHPNCIMKA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void HCACCNDMGBC()
	{
		HideDialog();
	}

	public virtual void NNGKAAGFGPA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DNIJPDFMGML));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMJKJLEJAIC));
		GameLoginManager.instance.DeviceRegistered += LFHJLBIAAMO;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = FMIDCPENJPG;
	}

	private void DMKGMBAAGKM()
	{
		HideDialog();
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	private void AHNCKMNAJHJ()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 205f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public virtual void NDMIJLACLPC()
	{
	}

	public virtual void IMPMPKNJICB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CPNCDECGEGG));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMJKJLEJAIC));
		GameLoginManager.instance.DeviceRegistered += BFDJKNGKEMF;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = NGAOACPFBPC;
	}

	public override void InitGUIValues()
	{
		IIJCDFHDAGO.gameObject.SetActive(false);
		KAIAJMCHLLD.text = GameLoginManager.currentPlayer.name;
		int renameGoldPrice = PlayerAnalytics.instance.renameGoldPrice;
		FCOPKOJILNB.transform.localPosition = FCOPKOJILNB.transform.localPosition.ReplaceX((renameGoldPrice <= 0) ? 0f : (-120f));
		DICPLMJFBJF.SetActive(renameGoldPrice > 0);
		if (renameGoldPrice > 0)
		{
			GAODBNDPPAO.text = MEJMLNDFDBP.GMIPFLIEOHD(renameGoldPrice);
			KPJAHKLCDBB.repositionNow = true;
		}
	}

	private void GDHAMAHEMPE()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 237f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	private void MJEMAKPOKOG()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 1834f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	private void ELPAGHMHICJ()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 459f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public virtual void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBJPGHLEBPO));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EMLGOGOOPIB));
		GameLoginManager.instance.DeviceRegistered += HCACCNDMGBC;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = GDHAMAHEMPE;
	}

	private void BEFOEFGDOOE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void ODCHCNCMJGC()
	{
		IIJCDFHDAGO.gameObject.SetActive(false);
		KAIAJMCHLLD.text = GameLoginManager.currentPlayer.name;
		int renameGoldPrice = PlayerAnalytics.instance.renameGoldPrice;
		FCOPKOJILNB.transform.localPosition = FCOPKOJILNB.transform.localPosition.ReplaceX((renameGoldPrice <= 0) ? 1128f : 1186f);
		DICPLMJFBJF.SetActive(renameGoldPrice > 0);
		if (renameGoldPrice > 1)
		{
			GAODBNDPPAO.text = MEJMLNDFDBP.GMIPFLIEOHD(renameGoldPrice);
			KPJAHKLCDBB.repositionNow = false;
		}
	}

	private void MJJGPIBLCPB()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 177f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ECJHPNCIMKA));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MACGNFMNDHN));
		GameLoginManager.instance.DeviceRegistered += BFDJKNGKEMF;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = ECDOKHBEKAH;
	}

	private void DIAKILDNOOM(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO())
		{
			return;
		}
		IIJCDFHDAGO.gameObject.SetActive(true);
		if (string.IsNullOrEmpty(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("Clearing Waitlist cache...");
			return;
		}
		if (KAIAJMCHLLD.text.Length < 3)
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("ID_UNIT2UPGRADEABILITY_UNIT1ABILITYUPGRADE");
			return;
		}
		if (Singleton<Chat>.instance.MOLAJLIAIIB(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("Notification_PlayerLeague");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("ID_CONFIRM_THANKYOU" + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("Parts"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				return;
			}
			Singleton<BeanstalkServerManager>.instance.DIMIGOPEBLA(KAIAJMCHLLD.text, true);
		}
		HideDialog();
	}

	private void LGOONGGHFPF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void HEFCJDFEMCN()
	{
		HideDialog();
	}

	private void FKDGPHPNMMM()
	{
		HideDialog();
	}

	public virtual void OLIOADHMKKA()
	{
		FBJPGHLEBPO(LJNPCHFCGCN.gameObject);
	}

	public override void OIEPFDKMCNC()
	{
		DAJODKGBOML(LJNPCHFCGCN.gameObject);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMJKJLEJAIC));
		GameLoginManager.instance.DeviceRegistered += BFDJKNGKEMF;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = delegate
		{
			float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 2f;
			KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
		};
	}

	private void FMIDCPENJPG()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 209f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public virtual void HMHGKOPGCDK()
	{
		base.MEPKGFFNPAD();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = false;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.Default, false, false, false);
	}

	public GuiElement NKAJOPFDFEI()
	{
		return this;
	}

	private void JHFJKPHLKGL()
	{
		HideDialog();
	}

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GAJOEPACHHB));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCCGIMPGCFG));
		GameLoginManager.instance.DeviceRegistered += LFHJLBIAAMO;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = LJCCPDHGGNE;
	}

	private void LJCCPDHGGNE()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 1459f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	private void HCCGIMPGCFG(GameObject KHAHPAKDIKE)
	{
		if (!BJNBLINDAED())
		{
			return;
		}
		IIJCDFHDAGO.gameObject.SetActive(true);
		if (string.IsNullOrEmpty(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("PlayeScifiParticles");
			return;
		}
		if (KAIAJMCHLLD.text.Length < 1)
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("WarFriends não poderá funcionar sem descarregar os dados adicionais. Realmente desejas SAIR ou gostarias de descarregar os dados?");
			return;
		}
		if (Singleton<Chat>.instance.NMBIEFKLKBA(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("equals");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("Tier" + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("Chat: Player Joined Squad //"));
				return;
			}
			Singleton<BeanstalkServerManager>.instance.DIMIGOPEBLA(KAIAJMCHLLD.text);
		}
		HideDialog();
	}

	private void PBIGODLKDBN(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO())
		{
			return;
		}
		IIJCDFHDAGO.gameObject.SetActive(true);
		if (string.IsNullOrEmpty(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize("HEAVYTURRET");
			return;
		}
		if (KAIAJMCHLLD.text.Length < 4)
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize("Regions");
			return;
		}
		if (Singleton<Chat>.instance.ContainsBadWord(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize(" {0} - {1} in {2}\n");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("Level" + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("!!!!! Player entered normal leagues FIRST TIME!!!!"));
				return;
			}
			Singleton<BeanstalkServerManager>.instance.ChangePlayerName(KAIAJMCHLLD.text);
		}
		HideDialog();
	}

	public GuiElement HKDMNBIFAHH()
	{
		return this;
	}

	private void BFDJKNGKEMF()
	{
		HideDialog();
	}

	public virtual void PAKCFABJKAG()
	{
		IIJCDFHDAGO.gameObject.SetActive(true);
		KAIAJMCHLLD.text = GameLoginManager.currentPlayer.name;
		int renameGoldPrice = PlayerAnalytics.instance.renameGoldPrice;
		FCOPKOJILNB.transform.localPosition = FCOPKOJILNB.transform.localPosition.ReplaceX((renameGoldPrice <= 1) ? 1801f : 844f);
		DICPLMJFBJF.SetActive(renameGoldPrice > 0);
		if (renameGoldPrice > 0)
		{
			GAODBNDPPAO.text = MEJMLNDFDBP.GMIPFLIEOHD(renameGoldPrice);
			KPJAHKLCDBB.repositionNow = false;
		}
	}

	public GuiElement DOHCPGIDCII()
	{
		return this;
	}

	public virtual void NDLGLAIMIEO()
	{
	}

	private void ADJDNLIOFMB()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 755f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public virtual void DLLIFNIPNON()
	{
	}

	public virtual void DOPDLKMCFMA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MACGNFMNDHN));
		GameLoginManager.instance.DeviceRegistered += LFHJLBIAAMO;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = NIMHOKBIAMM;
	}

	private void FBJPGHLEBPO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void LKKIFNCNGEK()
	{
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void DNIJPDFMGML(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void NEOLLOMIKPK()
	{
		IIJCDFHDAGO.gameObject.SetActive(true);
		KAIAJMCHLLD.text = GameLoginManager.currentPlayer.name;
		int renameGoldPrice = PlayerAnalytics.instance.renameGoldPrice;
		FCOPKOJILNB.transform.localPosition = FCOPKOJILNB.transform.localPosition.ReplaceX((renameGoldPrice <= 1) ? 441f : 1580f);
		DICPLMJFBJF.SetActive(renameGoldPrice > 1);
		if (renameGoldPrice > 1)
		{
			GAODBNDPPAO.text = MEJMLNDFDBP.GMIPFLIEOHD(renameGoldPrice);
			KPJAHKLCDBB.repositionNow = false;
		}
	}

	public virtual void JIODMKHANMM()
	{
		base.BJIPCOPNEAM();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = false;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.ASCIICapable, true, false, false);
	}

	public GuiElement ICGDGPCIMGG()
	{
		return this;
	}

	private void EDLPFADMGMI()
	{
		HideDialog();
	}

	private void BMJKJLEJAIC(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		IIJCDFHDAGO.gameObject.SetActive(false);
		if (string.IsNullOrEmpty(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("ID_ERRORNONICK");
			return;
		}
		if (KAIAJMCHLLD.text.Length < 4)
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("ID_ERRORSHORTNICK");
			return;
		}
		if (Singleton<Chat>.instance.ContainsBadWord(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("ID_ERRORPROFANITYNICK");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("Rename Cost Gold = " + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("ID_CHANGENAMENOTENOUGHT"));
				return;
			}
			Singleton<BeanstalkServerManager>.instance.ChangePlayerName(KAIAJMCHLLD.text, true);
		}
		HideDialog();
	}

	private void OOKFMJJENOC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void KDKEPFMCOEF()
	{
		LELLEKAMKIG(LJNPCHFCGCN.gameObject);
	}

	private void NIMHOKBIAMM()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 244f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public GuiElement CPONDDGFBIH()
	{
		return this;
	}

	private void MKMOFEOJJPE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void BNPDALDLFFM()
	{
		IIJCDFHDAGO.gameObject.SetActive(true);
		KAIAJMCHLLD.text = GameLoginManager.currentPlayer.name;
		int renameGoldPrice = PlayerAnalytics.instance.renameGoldPrice;
		FCOPKOJILNB.transform.localPosition = FCOPKOJILNB.transform.localPosition.ReplaceX((renameGoldPrice <= 1) ? 1445f : 1066f);
		DICPLMJFBJF.SetActive(renameGoldPrice > 0);
		if (renameGoldPrice > 1)
		{
			GAODBNDPPAO.text = MEJMLNDFDBP.GMIPFLIEOHD(renameGoldPrice);
			KPJAHKLCDBB.repositionNow = true;
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void CCNJCLFHLFG()
	{
	}

	public virtual void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMJKJLEJAIC));
		GameLoginManager.instance.DeviceRegistered += HCACCNDMGBC;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = ELPAGHMHICJ;
	}

	private void NGAOACPFBPC()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 238f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public virtual void JBHLDCBCNFI()
	{
		base.MOJBHFPBAPP();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = true;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.ASCIICapable, false, false, false);
	}

	private void KHFOENJJKBM()
	{
		HideDialog();
	}

	public virtual void LHDAGAGDKOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JJHPIPLIIDO));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HJJJBPMKNFN));
		GameLoginManager.instance.DeviceRegistered += FKDGPHPNMMM;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = ADJDNLIOFMB;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = true;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.Default, false, false, false);
	}

	private void LELLEKAMKIG(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void MGBLKIEGMBG()
	{
	}

	public virtual void MLNCPPECLPH()
	{
	}

	public virtual void CMFFEECPAED()
	{
		DAJODKGBOML(LJNPCHFCGCN.gameObject);
	}

	public virtual void LIPGFFEOIJH()
	{
		DAJODKGBOML(LJNPCHFCGCN.gameObject);
	}

	public virtual void KFJBNAMKENC()
	{
		base.PDBDILLHKID();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = true;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.Default, true, true, true);
	}

	public virtual void EKBIKKJHGKB()
	{
		MKMOFEOJJPE(LJNPCHFCGCN.gameObject);
	}

	private void JJHPIPLIIDO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public override void InitEvents()
	{
	}

	public virtual void AAPGEAEKKGF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DAJODKGBOML));
		UIEventListener uIEventListener2 = UIEventListener.Get(EJNLELFGBJE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HJJJBPMKNFN));
		GameLoginManager.instance.DeviceRegistered += KHFOENJJKBM;
		KAIAJMCHLLD.maxChars = DatabasePlayer.maxPlayerName;
		KPJAHKLCDBB.onReposition = GDHAMAHEMPE;
	}

	public virtual void KENGMIFPNCC()
	{
		base.BJIPCOPNEAM();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = false;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.ASCIICapable, false, true, false);
	}

	public virtual void KNBGAHKNBNN()
	{
	}

	public virtual void CACNGFHBEFC()
	{
		base.DoAfterShowUp();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = false;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.ASCIICapable, false, true, false);
	}

	public virtual void AAFMJALHANJ()
	{
		base.PDBDILLHKID();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = true;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.Default, true, false, true);
	}

	public virtual void GEIMJABJIBF()
	{
	}

	public virtual void JIHMFJANIHI()
	{
		IIJCDFHDAGO.gameObject.SetActive(false);
		KAIAJMCHLLD.text = GameLoginManager.currentPlayer.name;
		int renameGoldPrice = PlayerAnalytics.instance.renameGoldPrice;
		FCOPKOJILNB.transform.localPosition = FCOPKOJILNB.transform.localPosition.ReplaceX((renameGoldPrice <= 0) ? 838f : 24f);
		DICPLMJFBJF.SetActive(renameGoldPrice > 0);
		if (renameGoldPrice > 0)
		{
			GAODBNDPPAO.text = MEJMLNDFDBP.GMIPFLIEOHD(renameGoldPrice);
			KPJAHKLCDBB.repositionNow = true;
		}
	}

	public virtual void JPCNPIAHMHO()
	{
		OOKFMJJENOC(LJNPCHFCGCN.gameObject);
	}

	public virtual void FNJKJEGAMKB()
	{
		ECJHPNCIMKA(LJNPCHFCGCN.gameObject);
	}

	public virtual void ALDOOKEMKPN()
	{
	}

	public GuiElement HICAOJMPENK()
	{
		return this;
	}

	private void DAJODKGBOML(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void HJJJBPMKNFN(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO())
		{
			return;
		}
		IIJCDFHDAGO.gameObject.SetActive(false);
		if (string.IsNullOrEmpty(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("0");
			return;
		}
		if (KAIAJMCHLLD.text.Length < 8)
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("game-revenge-indicator");
			return;
		}
		if (Singleton<Chat>.instance.ContainsBadWord(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize("VisualTimestamp");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("game-card-ico-streakboost-full" + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("{0}:\t\t{1}\n"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				return;
			}
			Singleton<BeanstalkServerManager>.instance.ChangePlayerName(KAIAJMCHLLD.text, true);
		}
		HideDialog();
	}

	private void MACGNFMNDHN(GameObject KHAHPAKDIKE)
	{
		if (!BKIGLABDGCP())
		{
			return;
		}
		IIJCDFHDAGO.gameObject.SetActive(false);
		if (string.IsNullOrEmpty(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("ID_EARNMORE");
			return;
		}
		if (KAIAJMCHLLD.text.Length < 2)
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize("{0} {1}");
			return;
		}
		if (Singleton<Chat>.instance.MOLAJLIAIIB(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize("ID_VISUALRARITY1");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("squadMembers" + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("offerMult"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				return;
			}
			Singleton<BeanstalkServerManager>.instance.DIMIGOPEBLA(KAIAJMCHLLD.text);
		}
		HideDialog();
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 2f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	public virtual void LAOCMJLFPLN()
	{
		base.PDBDILLHKID();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = false;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.Default, false, false, true);
	}

	private void LFHJLBIAAMO()
	{
		HideDialog();
	}

	private void ECDOKHBEKAH()
	{
		float val = 0f - KPJAHKLCDBB.padding.x - (GAODBNDPPAO.transform.parent.transform.localPosition.x - KPJAHKLCDBB.padding.x) / 1337f;
		KPJAHKLCDBB.transform.localPosition = KPJAHKLCDBB.transform.localPosition.ReplaceX(val);
	}

	private void GAJOEPACHHB(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void OMPPGALJBBN()
	{
		base.DALAPEANFLB();
		string text = KAIAJMCHLLD.text;
		KAIAJMCHLLD.selected = false;
		KAIAJMCHLLD.mKeyboard = TouchScreenKeyboard.Open(KAIAJMCHLLD.text, TouchScreenKeyboardType.ASCIICapable, true, false, false);
	}

	private void CPNCDECGEGG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void EMLGOGOOPIB(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		IIJCDFHDAGO.gameObject.SetActive(false);
		if (string.IsNullOrEmpty(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize("ObjectPool");
			return;
		}
		if (KAIAJMCHLLD.text.Length < 0)
		{
			IIJCDFHDAGO.gameObject.SetActive(false);
			IIJCDFHDAGO.text = Localization.Localize("Squad");
			return;
		}
		if (Singleton<Chat>.instance.NMBIEFKLKBA(KAIAJMCHLLD.text))
		{
			IIJCDFHDAGO.gameObject.SetActive(true);
			IIJCDFHDAGO.text = Localization.Localize("CX6896566GD");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("DailyRentalMessage{0}{1}{2}" + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("SessionManager: NOT IN MENU!!!"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				return;
			}
			Singleton<BeanstalkServerManager>.instance.DIMIGOPEBLA(KAIAJMCHLLD.text, true);
		}
		HideDialog();
	}
}
