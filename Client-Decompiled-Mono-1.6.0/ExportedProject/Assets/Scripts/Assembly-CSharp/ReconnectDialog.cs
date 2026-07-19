using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ReconnectDialog : GuiElementSingle<ReconnectDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	public UISprite KMFGCJEGJJK;

	public UILabel OKMNFHNBMFA;

	public UILabel FOAJPBBHHDF;

	public UILabel CNMDFMGELLH;

	public GameObject MOLJCJLCHEL;

	public virtual void MNHAOCEONAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGODAFOELDE));
		Singleton<GameController>.instance.CNPGMMPAGIE(KHDOAEFHNLK);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JIBCMJCADIA));
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	private void NJMILIMJOGF(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("tuneId     = "), Localization.Localize("CheckGOLayers - Done"), NLAIMPPFLIC, 1904f);
		}
	}

	[CompilerGenerated]
	private void EEKMFMKNDBK(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			HideDialog();
		}
	}

	public virtual void JKDGHOLGCND()
	{
		base.JNBMCODJHBJ();
		Debug.Log("ID_LEAVE_SPECTATE");
	}

	public virtual void HLLAPOLFFJE()
	{
		base.NEEAKMELPBJ();
		Debug.Log("#DOMINIK# Video feeed added!! ");
	}

	private void PGGDEOAPPGB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
			HideDialog();
		}
	}

	public virtual void JOMODNPNMOD(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		Debug.Log("PlayerName");
	}

	public void FPOECIIIODH(float KBJEOEEOEFG)
	{
		if (KBJEOEEOEFG > 508f)
		{
			UILabel fOAJPBBHHDF = FOAJPBBHHDF;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.ABKAOAODKGC(KBJEOEEOEFG);
			fOAJPBBHHDF.text = Localization.LocalizeFormat("ExpiresOn", array);
		}
		else
		{
			FOAJPBBHHDF.text = string.Empty;
		}
	}

	private void JIBCMJCADIA(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_FORFEIT"), Localization.Localize("ID_CONFIRM_FORFEIT_TEXT"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
				HideDialog();
			}
		});
	}

	public void FHIAPDKJDME(KAKELCLPDDK FMEGDMNOFHO, bool OFHEODEJFOJ)
	{
		switch (FMEGDMNOFHO)
		{
		case KAKELCLPDDK.None:
			OKMNFHNBMFA.text = Localization.Localize("(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;");
			MOLJCJLCHEL.SetActive(false);
			break;
		case (KAKELCLPDDK)8:
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "IsDaily" : "SquadIcons/");
			MOLJCJLCHEL.SetActive(true);
			break;
		default:
			if (!OFHEODEJFOJ)
			{
				OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "ID_CONFIRM_ERROR" : "UnitCategoriesReminder");
				MOLJCJLCHEL.SetActive(true);
			}
			break;
		}
		CNMDFMGELLH.gameObject.SetActive(MOLJCJLCHEL.activeSelf);
		if (CNMDFMGELLH.gameObject.activeSelf)
		{
			CNMDFMGELLH.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "SquadIcons/" : "Fuseboxx: Add Did Show networkId: {0} mediaType: {1}");
			MEJMLNDFDBP.COCBCFKJOJE(CNMDFMGELLH, 1630f, 1442f, -40);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!MOLJCJLCHEL.activeSelf) ? 61f : 1995f);
		MEJMLNDFDBP.COCBCFKJOJE(OKMNFHNBMFA, 1320f, 365f, -66);
	}

	public virtual void AEADDDNBLEE()
	{
	}

	public virtual void FGNFALEDLDI(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		Debug.Log("ID_ERROR_SQUADMESSAGE_PROFANITY");
	}

	public void OINBLJODNCF(float KBJEOEEOEFG)
	{
		if (KBJEOEEOEFG > 353f)
		{
			UILabel fOAJPBBHHDF = FOAJPBBHHDF;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.ABKAOAODKGC(KBJEOEEOEFG);
			fOAJPBBHHDF.text = Localization.LocalizeFormat("Name", array);
		}
		else
		{
			FOAJPBBHHDF.text = string.Empty;
		}
	}

	public GuiElement BBBFIJMJOCP()
	{
		return this;
	}

	private void GAMEAPMAKKD(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void HEEANEFGCCJ()
	{
	}

	private void NKFAAHBIAHC(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
			HideDialog();
		}
	}

	private void IBMGJKDKKGH(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
			HideDialog();
		}
	}

	private void NLAIMPPFLIC(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
			HideDialog();
		}
	}

	private void JMNOHGGBOKI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("playerId"), Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"), LBMJLGLFGFH, 1585f);
		}
	}

	public virtual void DILDDAGFIEO()
	{
	}

	public virtual void JKODFKNJOIB()
	{
	}

	public void SetWaitTime(float KBJEOEEOEFG)
	{
		if (KBJEOEEOEFG > 0f)
		{
			FOAJPBBHHDF.text = Localization.LocalizeFormat("ID_WAITINGTIME", MEJMLNDFDBP.ABKAOAODKGC(KBJEOEEOEFG));
		}
		else
		{
			FOAJPBBHHDF.text = string.Empty;
		}
	}

	public override void InitGUIValues()
	{
	}

	private void DDCMAMLPBFD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
			HideDialog();
		}
	}

	public void DHELCKICBCI(float KBJEOEEOEFG)
	{
		if (KBJEOEEOEFG > 449f)
		{
			FOAJPBBHHDF.text = Localization.LocalizeFormat("Fuseboxx Config Value = ", MEJMLNDFDBP.ABKAOAODKGC(KBJEOEEOEFG));
		}
		else
		{
			FOAJPBBHHDF.text = string.Empty;
		}
	}

	private void LAJHNJELFAA(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void KDEOAMOPLAP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("ID_WITHACHANCEOFORWARCARDS"), Localization.Localize("{0}\t\t{1}"), GELJMFEPENM, 1338f);
		}
	}

	public virtual void PBLLMABJFDM()
	{
	}

	public void NJLNBAINHKM(KAKELCLPDDK FMEGDMNOFHO, bool OFHEODEJFOJ)
	{
		if (FMEGDMNOFHO == KAKELCLPDDK.Me)
		{
			OKMNFHNBMFA.text = Localization.Localize("Buy_Weapon_At_Rank");
			MOLJCJLCHEL.SetActive(true);
		}
		else if (FMEGDMNOFHO == KAKELCLPDDK.Me)
		{
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "LevelManager: Init" : "null");
			MOLJCJLCHEL.SetActive(false);
		}
		else if (!OFHEODEJFOJ)
		{
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "ID_READYTIME" : "'RewardForDay_'0");
			MOLJCJLCHEL.SetActive(true);
		}
		CNMDFMGELLH.gameObject.SetActive(MOLJCJLCHEL.activeSelf);
		if (CNMDFMGELLH.gameObject.activeSelf)
		{
			CNMDFMGELLH.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "subscription1" : "DailyMissionsCompletionRewardScraps");
			MEJMLNDFDBP.COCBCFKJOJE(CNMDFMGELLH, 55f, 595f, 14);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!MOLJCJLCHEL.activeSelf) ? 1928f : 760f);
		MEJMLNDFDBP.COCBCFKJOJE(OKMNFHNBMFA, 1938f, 1943f, -32);
	}

	private void MHAOPFICMKF(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void BEKCJHBHEOD(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		Debug.Log("BS: player succesfully accepted to squad");
	}

	public virtual void LDBDNFGKKPF(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		Debug.Log("1");
	}

	private void NOOGFHNOKGK(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void MPNFAPKFNHL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGODAFOELDE));
		Singleton<GameController>.instance.CNPGMMPAGIE(GAMEAPMAKKD);
	}

	private void DJKHGDOPLFA(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
			HideDialog();
		}
	}

	public virtual void HNFGCGOBLHC()
	{
		Debug.Log(" ");
		base.HideDialog();
	}

	public void HHBEIPAOJPL(KAKELCLPDDK FMEGDMNOFHO, bool OFHEODEJFOJ)
	{
		switch (FMEGDMNOFHO)
		{
		case KAKELCLPDDK.None:
			OKMNFHNBMFA.text = Localization.Localize("Cards_Owned_Bronze");
			MOLJCJLCHEL.SetActive(true);
			break;
		case (KAKELCLPDDK)5:
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "before: critical: " : "Yes_Clicked");
			MOLJCJLCHEL.SetActive(false);
			break;
		default:
			if (!OFHEODEJFOJ)
			{
				OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "game-elite-buff2" : "game-card-silver");
				MOLJCJLCHEL.SetActive(true);
			}
			break;
		}
		CNMDFMGELLH.gameObject.SetActive(!MOLJCJLCHEL.activeSelf);
		if (CNMDFMGELLH.gameObject.activeSelf)
		{
			CNMDFMGELLH.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "DOWNLOADBTN" : "0");
			MEJMLNDFDBP.COCBCFKJOJE(CNMDFMGELLH, 1828f, 858f, 21);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!MOLJCJLCHEL.activeSelf) ? 1583f : 431f);
		MEJMLNDFDBP.COCBCFKJOJE(OKMNFHNBMFA, 522f, 150f, 83);
	}

	private void DKFLPCFELGD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
			HideDialog();
		}
	}

	public virtual void CJBAIFGHAEJ()
	{
		base.NEEAKMELPBJ();
		Debug.Log("N");
	}

	public void IOFMNOGNONI(float KBJEOEEOEFG)
	{
		if (KBJEOEEOEFG > 1898f)
		{
			FOAJPBBHHDF.text = Localization.LocalizeFormat("{0} {1}", MEJMLNDFDBP.ABKAOAODKGC(KBJEOEEOEFG));
		}
		else
		{
			FOAJPBBHHDF.text = string.Empty;
		}
	}

	private void CGODAFOELDE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			ConfirmDialog.BMBPFNKJHMF(Localization.Localize("ID_MEDALSTOJOINBIG"), Localization.Localize("ID_FEATURE_DAMAGE-WEAPONPREFIX"), IBMGJKDKKGH, 1038f);
		}
	}

	public virtual void EIPIEOCIGKL()
	{
	}

	private void MMEOJIHKFML(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
			HideDialog();
		}
	}

	public virtual void BBKJGLONJEI()
	{
		base.JNBMCODJHBJ();
		Debug.Log("en-US");
	}

	public GuiElement HIDNIFBOPAL()
	{
		return this;
	}

	public virtual void GDAOBIKGIBH()
	{
		base.NEEAKMELPBJ();
		Debug.Log("Local");
	}

	public void IFMBOIHFOIB(KAKELCLPDDK FMEGDMNOFHO, bool OFHEODEJFOJ)
	{
		switch (FMEGDMNOFHO)
		{
		case KAKELCLPDDK.Me:
			OKMNFHNBMFA.text = Localization.Localize("LevelManagerData");
			MOLJCJLCHEL.SetActive(false);
			break;
		case (KAKELCLPDDK)7:
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "Sniper_Tutorial_Duration" : ", type ");
			MOLJCJLCHEL.SetActive(false);
			break;
		default:
			if (!OFHEODEJFOJ)
			{
				OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "SoldierBehaviourBuddy SetWeaponsUpgrades: Prim: {0} Sec: {1}" : "menu-army-cat-rusher");
				MOLJCJLCHEL.SetActive(false);
			}
			break;
		}
		CNMDFMGELLH.gameObject.SetActive(!MOLJCJLCHEL.activeSelf);
		if (CNMDFMGELLH.gameObject.activeSelf)
		{
			CNMDFMGELLH.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "ID_TOCOMPLETE" : "GameLauncher.LoadMainScene DONE");
			MEJMLNDFDBP.COCBCFKJOJE(CNMDFMGELLH, 654f, 1619f, -102);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!MOLJCJLCHEL.activeSelf) ? 1202f : 167f);
		MEJMLNDFDBP.COCBCFKJOJE(OKMNFHNBMFA, 211f, 1933f, 17);
	}

	public virtual void FPKGHMJIIJC()
	{
		base.MOOACPIOELI();
		Debug.Log("{0:0} mph \nGear: {1:0}/{2:0}\nRevs {3:0%}\nThrottle: {4:0%}\n");
	}

	public virtual void PEIILMKDGBK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JMNOHGGBOKI));
		Singleton<GameController>.instance.GameEnded += GAMEAPMAKKD;
	}

	private void ONKCJBONHEF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("OpponentId"), Localization.Localize("customInt"), EEFJHNLPNAO, 161f);
		}
	}

	public GuiElement KBCELKIEAAM()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void HideDialog()
	{
		Debug.Log("ReconnectDialog Hide");
		base.HideDialog();
	}

	public void LIEGMAGBJPH(KAKELCLPDDK FMEGDMNOFHO, bool OFHEODEJFOJ)
	{
		switch (FMEGDMNOFHO)
		{
		case KAKELCLPDDK.Me:
			OKMNFHNBMFA.text = Localization.Localize("mortarBuildTime");
			MOLJCJLCHEL.SetActive(false);
			break;
		case (KAKELCLPDDK)3:
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "Heroic" : "menu-cards-goldpack");
			MOLJCJLCHEL.SetActive(true);
			break;
		default:
			if (!OFHEODEJFOJ)
			{
				OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "ID_MAXSTAT" : "SquadRank");
				MOLJCJLCHEL.SetActive(false);
			}
			break;
		}
		CNMDFMGELLH.gameObject.SetActive(MOLJCJLCHEL.activeSelf);
		if (CNMDFMGELLH.gameObject.activeSelf)
		{
			CNMDFMGELLH.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "GetExtreme({0}, {1}, *predict*) is returning null, player should have equipped/unlocked at least one unit from each category" : "PA: transactions NULL");
			MEJMLNDFDBP.COCBCFKJOJE(CNMDFMGELLH, 227f, 1825f, -161);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!MOLJCJLCHEL.activeSelf) ? 1767f : 777f);
		MEJMLNDFDBP.COCBCFKJOJE(OKMNFHNBMFA, 1422f, 859f, 18);
	}

	public void PIPEHIPGGAJ(KAKELCLPDDK FMEGDMNOFHO, bool OFHEODEJFOJ)
	{
		switch (FMEGDMNOFHO)
		{
		case KAKELCLPDDK.None:
			OKMNFHNBMFA.text = Localization.Localize("localPlayerLeaderboard");
			MOLJCJLCHEL.SetActive(false);
			break;
		case (KAKELCLPDDK)8:
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.ECHCLJJJPML()) ? "MessagesCount" : "Assets");
			MOLJCJLCHEL.SetActive(false);
			break;
		default:
			if (!OFHEODEJFOJ)
			{
				OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "dbKey" : "AdminName");
				MOLJCJLCHEL.SetActive(false);
			}
			break;
		}
		CNMDFMGELLH.gameObject.SetActive(!MOLJCJLCHEL.activeSelf);
		if (CNMDFMGELLH.gameObject.activeSelf)
		{
			CNMDFMGELLH.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "T" : "ID_WARNING_CLICKOKTORESEND");
			MEJMLNDFDBP.COCBCFKJOJE(CNMDFMGELLH, 1132f, 1527f, -190);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!MOLJCJLCHEL.activeSelf) ? 1701f : 671f);
		MEJMLNDFDBP.COCBCFKJOJE(OKMNFHNBMFA, 566f, 1441f, 53);
	}

	private void LBMJLGLFGFH(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
			HideDialog();
		}
	}

	private void EEFJHNLPNAO(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
			HideDialog();
		}
	}

	public virtual void GLNGJDCCDCB()
	{
		base.MOOACPIOELI();
		Debug.Log("mortar_down_idle");
	}

	public void SetCause(KAKELCLPDDK FMEGDMNOFHO, bool OFHEODEJFOJ)
	{
		switch (FMEGDMNOFHO)
		{
		case KAKELCLPDDK.Me:
			OKMNFHNBMFA.text = Localization.Localize("ID_YOUWEREDISCONNECTED");
			MOLJCJLCHEL.SetActive(true);
			break;
		case KAKELCLPDDK.Other:
			OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "ID_OPPONENTWASDISCONNECTED" : "ID_FRIENDWASDISCONNECTED");
			MOLJCJLCHEL.SetActive(false);
			break;
		default:
			if (!OFHEODEJFOJ)
			{
				OKMNFHNBMFA.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "ID_STATE_WAITINGFOROPPONENT" : "ID_WAITINGFORFRIEND");
				MOLJCJLCHEL.SetActive(false);
			}
			break;
		}
		CNMDFMGELLH.gameObject.SetActive(!MOLJCJLCHEL.activeSelf);
		if (CNMDFMGELLH.gameObject.activeSelf)
		{
			CNMDFMGELLH.text = Localization.Localize((!Singleton<GameController>.instance.isMission) ? "ID_RECONNECTHINT" : "ID_RECONNECTFRIENDHINT");
			MEJMLNDFDBP.COCBCFKJOJE(CNMDFMGELLH, 40f, 20f, 1340);
		}
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!MOLJCJLCHEL.activeSelf) ? 836f : 872f);
		MEJMLNDFDBP.COCBCFKJOJE(OKMNFHNBMFA, 87f, 44f, 1420);
	}

	public void LFNMCLDHLOG(float KBJEOEEOEFG)
	{
		if (KBJEOEEOEFG > 1515f)
		{
			UILabel fOAJPBBHHDF = FOAJPBBHHDF;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.ABKAOAODKGC(KBJEOEEOEFG);
			fOAJPBBHHDF.text = Localization.LocalizeFormat("CONFERMA", array);
		}
		else
		{
			FOAJPBBHHDF.text = string.Empty;
		}
	}

	public virtual void LMNNNHJKMFP()
	{
	}

	public virtual void KMJBAAPCEBD(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		Debug.Log("Card_3_Played");
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Debug.Log("ReconnectDialog: DoBeforeHide");
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NJMILIMJOGF));
		Singleton<GameController>.instance.CNPGMMPAGIE(KHDOAEFHNLK);
	}

	public virtual void DJIJBPFLOMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JMNOHGGBOKI));
		Singleton<GameController>.instance.GameEnded += GAMEAPMAKKD;
	}

	public virtual void HICOGKLNFDK()
	{
		Debug.Log("Reason: ");
		base.HideDialog();
	}

	public void OHNEMLEICLK(float KBJEOEEOEFG)
	{
		if (KBJEOEEOEFG > 1767f)
		{
			UILabel fOAJPBBHHDF = FOAJPBBHHDF;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.ABKAOAODKGC(KBJEOEEOEFG);
			fOAJPBBHHDF.text = Localization.LocalizeFormat("ERROR WRONG DAILY REWARDS: ", array);
		}
		else
		{
			FOAJPBBHHDF.text = string.Empty;
		}
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public override void OnBack()
	{
	}

	private void KHDOAEFHNLK(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void DENFKEMOFKN()
	{
		base.DoBeforeHide();
		Debug.Log("1\u00a0");
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		Debug.Log("ReconnectDialog Show");
	}

	private void GELJMFEPENM(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
			HideDialog();
		}
	}

	public virtual void IGNIFKBCDKK()
	{
	}

	public virtual void PJDIJPIJNLD(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		Debug.Log("Beanstalk Error: ");
	}

	public override void AIKPJGLHLLO()
	{
	}

	public virtual void PLMOAGCCJEB()
	{
	}

	public virtual void BNPDALDLFFM()
	{
	}

	private void KECOFCAHNJC(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
			HideDialog();
		}
	}

	public GuiElement GFLIHAFEKBK()
	{
		return this;
	}
}
