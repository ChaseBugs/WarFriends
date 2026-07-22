using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class UserExistsDialog : GuiElementSingle<UserExistsDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("NEHDELJDCMK")]
	[Header("Content")]
	public UILabel DEOJCFEFBHP;

	[FormerlySerializedAs("KEBHACNJKBE")]
	[Header("Left Current User")]
	public UIButton EDHCOMHOKDC;

	[FormerlySerializedAs("KFHPJOAGDJC")]
	public UISprite FGPMJKLPAKC;

	[FormerlySerializedAs("BPOHLLIJOCH")]
	public UILabel GFILDBFKGGF;

	[FormerlySerializedAs("LBPANFEDACE")]
	public UILabel DGOHBCOGBFI;

	[FormerlySerializedAs("PNJJLLCBBBE")]
	public UILabel JDDDDOBAFEO;

	[Header("Right Other User")]
	[FormerlySerializedAs("LKKMLODGHHL")]
	public UIButton EPFODCCNGDL;

	[FormerlySerializedAs("LLLCMCLPCGJ")]
	public UILabel GNFBJLMLMKO;

	[FormerlySerializedAs("JDFPCNECAOC")]
	public UISprite CLEIOAHGDOC;

	[FormerlySerializedAs("EMEJIDEHDGG")]
	public UILabel KCIJEEMOJGG;

	[FormerlySerializedAs("JBHMPKIJBLI")]
	public UILabel ADHAGKLPHDJ;

	[FormerlySerializedAs("IIBDKFLBAFP")]
	public UILabel MDPJMCPEJOG;

	[FormerlySerializedAs("FGPPMIGAFGM")]
	public Action<bool> MEKJGALICMK;

	private AccountType GJJLDLNNNIA;

	private string IPICABMDMKG;

	private int EAJLNKEMAHN;

	private int ODONLNHHECI;

	private string CKGDAGHKPON;

	private void CKEHAALCALC()
	{
		DGOHBCOGBFI.text = GameLoginManager.currentPlayer.name;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 1759f, 1573f, 1);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		GFILDBFKGGF.text = currentLevel.IEFOIJAFOJC();
		FGPMJKLPAKC.spriteName = currentLevel.EGNEDNBPOEF();
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.skill);
	}

	public virtual void EMGHCAHOJNC()
	{
		if (GJJLDLNNNIA == AccountType.Facebook)
		{
			DEOJCFEFBHP.text = Localization.Localize("GLM: RegisterOrLogin -  2");
			GNFBJLMLMKO.text = Localization.Localize("special");
		}
		else if (GJJLDLNNNIA == (AccountType)8)
		{
			DEOJCFEFBHP.text = Localization.Localize(" (#");
			GNFBJLMLMKO.text = Localization.Localize("ID_SECOND");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("Player_Waited_Till_Delivery_Ends"));
			GNFBJLMLMKO.text = Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT");
		}
		JFPKCPIJOME();
		OANJAIKMEDC();
	}

	private void LEOMFIPAANG()
	{
		DGOHBCOGBFI.text = GameLoginManager.currentPlayer.name;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 1259f, 128f);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		GFILDBFKGGF.text = currentLevel.displayString;
		FGPMJKLPAKC.spriteName = currentLevel.EGNEDNBPOEF();
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.skill);
	}

	private void GGFIMGFPKCO()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 1999f, 267f);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.displayString;
		CLEIOAHGDOC.spriteName = levelDefinition.NOHAFIDFPCM();
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	private void JFPKCPIJOME()
	{
		DGOHBCOGBFI.text = GameLoginManager.currentPlayer.name;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 1094f, 1470f);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		GFILDBFKGGF.text = currentLevel.JNODDKLJOAG();
		FGPMJKLPAKC.spriteName = currentLevel.LMNDFNIKIFI();
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.skill);
	}

	public virtual void NIHDCNNMBIK()
	{
		base.OIMKKAHOEKO();
		MEKJGALICMK = null;
	}

	public virtual void HAKBKLLHGBC()
	{
	}

	public virtual void NLBAPEADKNJ()
	{
		base.DoAfterHide();
		MEKJGALICMK = null;
	}

	private void BPJOPBEKDIP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			string oKMNFHNBMFA = Localization.Localize("Fuseboxx: Override Sheet Constants");
			object[] array = new object[4];
			array[1] = ADHAGKLPHDJ.text;
			array[1] = KCIJEEMOJGG.text;
			array[4] = DGOHBCOGBFI.text;
			array[7] = GFILDBFKGGF.text;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("seconds", array), MFBANAJEOJP, 1362f);
		}
	}

	private void KDLGODIJLJD(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		string oKMNFHNBMFA = Localization.Localize("SMG_run");
		object[] array = new object[4];
		array[0] = DGOHBCOGBFI.text;
		array[0] = GFILDBFKGGF.text;
		array[6] = ADHAGKLPHDJ.text;
		array[5] = KCIJEEMOJGG.text;
		ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("ID_SILVERPACK", array), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				if (MEKJGALICMK != null)
				{
					MEKJGALICMK(obj: true);
				}
				HideDialog();
			}
		}, 494f);
	}

	public virtual void PHNKOMPPPLD()
	{
		if (GJJLDLNNNIA == (AccountType)7)
		{
			DEOJCFEFBHP.text = Localization.Localize("Tickets");
			GNFBJLMLMKO.text = Localization.Localize("ID_PACK");
		}
		else if (GJJLDLNNNIA == AccountType.Facebook)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_MISSION_WAVE");
			GNFBJLMLMKO.text = Localization.Localize("+0");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("fuse offer: {0}"));
			GNFBJLMLMKO.text = Localization.Localize("N");
		}
		EFIOIFBLGKO();
		NPEGMGCIHJI();
	}

	public override void OnBack()
	{
	}

	public virtual void PAHEFBCOENP()
	{
		if (GJJLDLNNNIA == (AccountType)8)
		{
			DEOJCFEFBHP.text = Localization.Localize("vipStart");
			GNFBJLMLMKO.text = Localization.Localize("SquadRank");
		}
		else if (GJJLDLNNNIA == AccountType.GameCenter)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_REMINDER_UPGRADEAVAILABLE");
			GNFBJLMLMKO.text = Localization.Localize("Google2u.DBUpgradeSlotsCar");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("DogTagCap"));
			GNFBJLMLMKO.text = Localization.Localize("cards");
		}
		JFPKCPIJOME();
		NPEGMGCIHJI();
	}

	private void KDCGNJALGNN(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	private void JMGAPKDOKCG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			string oKMNFHNBMFA = Localization.Localize(" NOT OK!\t\t\t\t\t\t");
			object[] array = new object[0];
			array[1] = DGOHBCOGBFI.text;
			array[0] = GFILDBFKGGF.text;
			array[1] = ADHAGKLPHDJ.text;
			array[8] = KCIJEEMOJGG.text;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("#DOMINIK# weapon not found", array), EAHGDJODDKB, 501f);
		}
	}

	private void PMFFGBIJPMP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			string oKMNFHNBMFA = Localization.Localize("SpecialPackFromServer");
			object[] array = new object[1];
			array[0] = ADHAGKLPHDJ.text;
			array[0] = KCIJEEMOJGG.text;
			array[0] = DGOHBCOGBFI.text;
			array[3] = GFILDBFKGGF.text;
			ConfirmDialog.NMLMDFGOHDC(oKMNFHNBMFA, Localization.LocalizeFormat("Assignment ID: {0}\nERROR: {1}\nSTACKTRACE: {2}", array), MFBANAJEOJP, 1235f);
		}
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	public virtual void AEOHKMFNAGF()
	{
		base.DoAfterHide();
		MEKJGALICMK = null;
	}

	public virtual void JCJECJKBKGD()
	{
		if (GJJLDLNNNIA == AccountType.GooglePlay)
		{
			DEOJCFEFBHP.text = Localization.Localize("Configurations hacked");
			GNFBJLMLMKO.text = Localization.Localize("Weapons/");
		}
		else if (GJJLDLNNNIA == (AccountType)1)
		{
			DEOJCFEFBHP.text = Localization.Localize("RESETING SQUAD WARCARDS");
			GNFBJLMLMKO.text = Localization.Localize("ID_NA");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("Tutorial_Step_Complete"));
			GNFBJLMLMKO.text = Localization.Localize("com/google/android/gms/common/api/Status");
		}
		CKEHAALCALC();
		JPOPEKOLCCN();
	}

	public GuiElement JEAMNJAPFJK()
	{
		return this;
	}

	private void HBBGLPCLADK()
	{
		DGOHBCOGBFI.text = GameLoginManager.currentPlayer.name;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 741f, 769f);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		GFILDBFKGGF.text = currentLevel.GIIHOHGFHBO();
		FGPMJKLPAKC.spriteName = currentLevel.NOHAFIDFPCM();
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.skill);
	}

	private void LFELDNDAOOO()
	{
		DGOHBCOGBFI.text = GameLoginManager.currentPlayer.name;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 983f, 125f, 1);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		GFILDBFKGGF.text = currentLevel.KAKFPJPKHHB();
		FGPMJKLPAKC.spriteName = currentLevel.LMNDFNIKIFI();
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.skill);
	}

	private void MDOADBLPMDI(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		string oKMNFHNBMFA = Localization.Localize("response for {0}");
		object[] array = new object[0];
		array[0] = DGOHBCOGBFI.text;
		array[0] = GFILDBFKGGF.text;
		array[2] = ADHAGKLPHDJ.text;
		array[7] = KCIJEEMOJGG.text;
		ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("Category ", array), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				if (MEKJGALICMK != null)
				{
					MEKJGALICMK(obj: true);
				}
				HideDialog();
			}
		}, 290f);
	}

	public GuiElement MOMKIEKEFFJ()
	{
		return this;
	}

	public virtual void OKMMGFMKJGG()
	{
		if (GJJLDLNNNIA == (AccountType)1)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_X_CARDS");
			GNFBJLMLMKO.text = Localization.Localize("VipReward2");
		}
		else if (GJJLDLNNNIA == (AccountType)6)
		{
			DEOJCFEFBHP.text = Localization.Localize("ArenaEnded");
			GNFBJLMLMKO.text = Localization.Localize("GetCurrentMapDefinition");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("WENEEDTO"));
			GNFBJLMLMKO.text = Localization.Localize("ActivateBonusResultRPC");
		}
		JFPKCPIJOME();
		OHNHFNEPCOK();
	}

	[CompilerGenerated]
	private void LILJIAKCEJM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: false);
			}
			HideDialog();
		}
	}

	public virtual void OMOJHCOKAHP()
	{
	}

	private void GAPJFGKADMH(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			string oKMNFHNBMFA = Localization.Localize("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: LOCKED\t\tbutton type: LEVEL UP");
			object[] array = new object[0];
			array[1] = DGOHBCOGBFI.text;
			array[0] = GFILDBFKGGF.text;
			array[2] = ADHAGKLPHDJ.text;
			array[8] = KCIJEEMOJGG.text;
			ConfirmDialog.NMLMDFGOHDC(oKMNFHNBMFA, Localization.LocalizeFormat(" on object ", array), OLKOIEBMKPM, 792f);
		}
	}

	public virtual void EBOBKBJNNDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDOAHOIIKFL));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ENGMOCOBPMO));
	}

	private void NLLHABFONHI(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	private void MFBANAJEOJP(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: false);
			}
			HideDialog();
		}
	}

	private void EGFNFBFHLJB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			string oKMNFHNBMFA = Localization.Localize("matchMadeGames");
			object[] array = new object[7];
			array[1] = DGOHBCOGBFI.text;
			array[1] = GFILDBFKGGF.text;
			array[1] = ADHAGKLPHDJ.text;
			array[3] = KCIJEEMOJGG.text;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("ID_TUTORIAL_TAPON", array), NLLHABFONHI, 565f);
		}
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDLGODIJLJD));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMNNGINKNAP));
	}

	private void CEEKEKOKDFP(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			string oKMNFHNBMFA = Localization.Localize("^\\D*");
			object[] array = new object[8];
			array[0] = DGOHBCOGBFI.text;
			array[0] = GFILDBFKGGF.text;
			array[1] = ADHAGKLPHDJ.text;
			array[5] = KCIJEEMOJGG.text;
			ConfirmDialog.LGANINAGPLB(oKMNFHNBMFA, Localization.LocalizeFormat("Enemy Card {0} {1}", array), BEKBJEEGIPI, 155f);
		}
	}

	public void ShowDialog(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void JGDJCCIPNHC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDLGODIJLJD));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMNNGINKNAP));
	}

	private void FDOAHOIIKFL(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_AREYOUSURE"), Localization.LocalizeFormat("ID_CONFIRM_SELECTEDANDDELETEDACCOUNT", DGOHBCOGBFI.text, GFILDBFKGGF.text, ADHAGKLPHDJ.text, KCIJEEMOJGG.text), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				if (MEKJGALICMK != null)
				{
					MEKJGALICMK(obj: true);
				}
				HideDialog();
			}
		});
	}

	public void OAAABGFLAFG(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 272f);
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDLGODIJLJD));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMNNGINKNAP));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement MBELJEEONHN()
	{
		return this;
	}

	private void EFFOLNBPNPK()
	{
		DGOHBCOGBFI.text = GameLoginManager.currentPlayer.name;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 30f, 22f);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		GFILDBFKGGF.text = currentLevel.displayString;
		FGPMJKLPAKC.spriteName = currentLevel.iconName;
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.skill);
	}

	[CompilerGenerated]
	private void IDOPECDKLEM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public virtual void GCPDEEPCBOF()
	{
		if (GJJLDLNNNIA == (AccountType)7)
		{
			DEOJCFEFBHP.text = Localization.Localize("Removed WarCards for tutorial: ");
			GNFBJLMLMKO.text = Localization.Localize("DisplayNotifications()");
		}
		else if (GJJLDLNNNIA == AccountType.GooglePlay)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_CONFIRM_FRIENDINSQUAD_TEXT");
			GNFBJLMLMKO.text = Localization.Localize("ID_CONFIRM_ERROR");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("ID_MEMBERSHIP_HINT5TRIAL"));
			GNFBJLMLMKO.text = Localization.Localize("menu-sidetab-player-promote");
		}
		LEOMFIPAANG();
		FKBHILIPPLB();
	}

	private void OHNHFNEPCOK()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 275f, 795f, 1);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.displayString;
		CLEIOAHGDOC.spriteName = levelDefinition.KJFPCOMOLLD();
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	public virtual void MAKLJNDMOFG()
	{
		base.OIMKKAHOEKO();
		MEKJGALICMK = null;
	}

	public virtual void NMHMFDOFDBC()
	{
		base.DoAfterHide();
		MEKJGALICMK = null;
	}

	public void DEDOCPBAEMC(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1797f);
	}

	public void IKMPLKOJDAB(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1258f);
	}

	public void AHJFFMAFCEG(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1430f);
	}

	private void EOJIIGINDJF(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			string oKMNFHNBMFA = Localization.Localize("rookie2");
			object[] array = new object[0];
			array[0] = ADHAGKLPHDJ.text;
			array[1] = KCIJEEMOJGG.text;
			array[1] = DGOHBCOGBFI.text;
			array[1] = GFILDBFKGGF.text;
			ConfirmDialog.NMLMDFGOHDC(oKMNFHNBMFA, Localization.LocalizeFormat("LootboxesCost", array), MFBANAJEOJP, 335f);
		}
	}

	private void GMNNGINKNAP(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			string oKMNFHNBMFA = Localization.Localize("Token");
			object[] array = new object[4];
			array[0] = ADHAGKLPHDJ.text;
			array[0] = KCIJEEMOJGG.text;
			array[6] = DGOHBCOGBFI.text;
			array[6] = GFILDBFKGGF.text;
			ConfirmDialog.BMBPFNKJHMF(oKMNFHNBMFA, Localization.LocalizeFormat("AssignmentData", array), NOCIKFDOPBI, 412f);
		}
	}

	public GuiElement NGOFDGAGECA()
	{
		return this;
	}

	private void EFIOIFBLGKO()
	{
		DGOHBCOGBFI.text = GameLoginManager.currentPlayer.name;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 80f, 312f, 1);
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		GFILDBFKGGF.text = currentLevel.IEFOIJAFOJC();
		FGPMJKLPAKC.spriteName = currentLevel.NOHAFIDFPCM();
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.skill);
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGFNFBFHLJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HLONPMGELIO));
	}

	private void PMADCJHKAEL(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	private void HHGCAOILMFH()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 25f, 193f);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.GIIHOHGFHBO();
		CLEIOAHGDOC.spriteName = levelDefinition.EGNEDNBPOEF();
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	private void ABILEAMKGDP(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public void CPEKKCLJFBA(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 381f);
	}

	public virtual void BNEPKGCDIFH()
	{
		if (GJJLDLNNNIA == (AccountType)7)
		{
			DEOJCFEFBHP.text = Localization.Localize("menu-cards-bronzepack");
			GNFBJLMLMKO.text = Localization.Localize("Automatic_Equip");
		}
		else if (GJJLDLNNNIA == (AccountType)1)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_CONFIRM_SERVERERROR");
			GNFBJLMLMKO.text = Localization.Localize("Wrong_Weapon");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("ID_CONFIRM_GAMELAREADYENDED"));
			GNFBJLMLMKO.text = Localization.Localize("HAS NO ELITE PARTS");
		}
		JFPKCPIJOME();
		JPOPEKOLCCN();
	}

	public virtual void AIJEMOLBNEC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JMGAPKDOKCG));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMFFGBIJPMP));
	}

	public virtual void FACKIKMABGK()
	{
		if (GJJLDLNNNIA == (AccountType)7)
		{
			DEOJCFEFBHP.text = Localization.Localize("D4");
			GNFBJLMLMKO.text = Localization.Localize("registerEvent");
		}
		else if (GJJLDLNNNIA == (AccountType)1)
		{
			DEOJCFEFBHP.text = Localization.Localize("Automatic_Equip");
			GNFBJLMLMKO.text = Localization.Localize("Awaiting players - Removing player ");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("KickedPlayerId"));
			GNFBJLMLMKO.text = Localization.Localize("WarBucks");
		}
		HBBGLPCLADK();
		JPOPEKOLCCN();
	}

	private void EAHGDJODDKB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public virtual void BKDELMODAHM()
	{
	}

	public virtual void KICJHALCOOM()
	{
		base.OIMKKAHOEKO();
		MEKJGALICMK = null;
	}

	public void CJNMLPANNPD(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1821f);
	}

	public virtual void EGNPMLEJLMJ()
	{
	}

	public void FGAOCOCPAIF(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 34f);
	}

	public virtual void NMMEDNEGDNI()
	{
		base.OIMKKAHOEKO();
		MEKJGALICMK = null;
	}

	public virtual void HKFICJFNOPM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDOADBLPMDI));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EOJIIGINDJF));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		MEKJGALICMK = null;
	}

	private void FKBHILIPPLB()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 287f, 1281f, 1);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.DLCFFHEKBAA();
		CLEIOAHGDOC.spriteName = levelDefinition.NOHAFIDFPCM();
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	public virtual void PAIKCHDABEJ()
	{
	}

	public virtual void JKODFKNJOIB()
	{
	}

	private void HLMIFCLJKEE()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 537f, 1030f);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.GIIHOHGFHBO();
		CLEIOAHGDOC.spriteName = levelDefinition.iconName;
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	private void OLKOIEBMKPM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		if (GJJLDLNNNIA == AccountType.GooglePlay)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_USEREXISTSGOOGLEPLAYTEXT");
			GNFBJLMLMKO.text = Localization.Localize("ID_GOOGLEPLAYUSER");
		}
		else if (GJJLDLNNNIA == AccountType.GameCenter)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_USEREXISTSGAMECENTERTEXT");
			GNFBJLMLMKO.text = Localization.Localize("ID_GAMECENTERUSER");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("ID_USEREXISTSFACEBOOKTEXT"));
			GNFBJLMLMKO.text = Localization.Localize("ID_FACEBOOKUSER");
		}
		EFFOLNBPNPK();
		OANJAIKMEDC();
	}

	private void BKIJJEOGFKH(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDOAHOIIKFL));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ENGMOCOBPMO));
	}

	private void BEKBJEEGIPI(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: false);
			}
			HideDialog();
		}
	}

	public virtual void PDHNLAMPOBN()
	{
		if (GJJLDLNNNIA == (AccountType)6)
		{
			DEOJCFEFBHP.text = Localization.Localize("Region");
			GNFBJLMLMKO.text = Localization.Localize("Starting LocalPersistenceManager!");
		}
		else if (GJJLDLNNNIA == AccountType.Guest)
		{
			DEOJCFEFBHP.text = Localization.Localize("#Mission Rewards# Heroic was opened");
			GNFBJLMLMKO.text = Localization.Localize("BundleId");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("null"));
			GNFBJLMLMKO.text = Localization.Localize("ID_GUI_GOLD");
		}
		CKEHAALCALC();
		OHNHFNEPCOK();
	}

	public void ELODCMCIEDP(AccountType FEPHCHKJGHD, Action<bool> FBFJNHLKJEC, string HECDGAPMDHJ, int LPGGKFLFGGN = 2, int OCFJAJCKLDH = 500, string LBDHPLANFLB = "")
	{
		GJJLDLNNNIA = FEPHCHKJGHD;
		MEKJGALICMK = FBFJNHLKJEC;
		IPICABMDMKG = HECDGAPMDHJ;
		EAJLNKEMAHN = LPGGKFLFGGN;
		ODONLNHHECI = OCFJAJCKLDH;
		CKGDAGHKPON = LBDHPLANFLB;
		Singleton<GuiManager>.instance.ShowDialog(this, 347f);
	}

	private void ENGMOCOBPMO(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_AREYOUSURE"), Localization.LocalizeFormat("ID_CONFIRM_SELECTEDANDDELETEDACCOUNT", ADHAGKLPHDJ.text, KCIJEEMOJGG.text, DGOHBCOGBFI.text, GFILDBFKGGF.text), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				if (MEKJGALICMK != null)
				{
					MEKJGALICMK(obj: false);
				}
				HideDialog();
			}
		});
	}

	private void HLONPMGELIO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			string oKMNFHNBMFA = Localization.Localize("\nCPAPI:{\"cmd\":\"Filter\" \"name\":\"");
			object[] array = new object[8];
			array[0] = ADHAGKLPHDJ.text;
			array[0] = KCIJEEMOJGG.text;
			array[5] = DGOHBCOGBFI.text;
			array[0] = GFILDBFKGGF.text;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("RealTimeMultiplayer", array), MFBANAJEOJP, 1681f);
		}
	}

	public GuiElement ENAHJFLLGHG()
	{
		return this;
	}

	public GuiElement ANDPIIIFIAA()
	{
		return this;
	}

	private void OANJAIKMEDC()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 30f, 22f);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.displayString;
		CLEIOAHGDOC.spriteName = levelDefinition.iconName;
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	private void PPFNKOAILOJ(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public virtual void IJHNPCPFEKF()
	{
		if (GJJLDLNNNIA == (AccountType)8)
		{
			DEOJCFEFBHP.text = Localization.Localize("03");
			GNFBJLMLMKO.text = Localization.Localize("elitepack1");
		}
		else if (GJJLDLNNNIA == AccountType.GooglePlay)
		{
			DEOJCFEFBHP.text = Localization.Localize("ID_CONFIRM_LEAVE_SPECTATE_TEXT");
			GNFBJLMLMKO.text = Localization.Localize("_Color");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("Subscription"));
			GNFBJLMLMKO.text = Localization.Localize("N0");
		}
		JFPKCPIJOME();
		OHNHFNEPCOK();
	}

	private void NPEGMGCIHJI()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 1986f, 537f);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.KAKFPJPKHHB();
		CLEIOAHGDOC.spriteName = levelDefinition.iconName;
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	public GuiElement KHNOCHHPLDF()
	{
		return this;
	}

	private void JPOPEKOLCCN()
	{
		ADHAGKLPHDJ.text = IPICABMDMKG;
		MEJMLNDFDBP.COCBCFKJOJE(ADHAGKLPHDJ, 237f, 661f);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(EAJLNKEMAHN);
		KCIJEEMOJGG.text = levelDefinition.displayString;
		CLEIOAHGDOC.spriteName = levelDefinition.CDLBEKECJNK();
		MDPJMCPEJOG.text = MEJMLNDFDBP.GMIPFLIEOHD(ODONLNHHECI);
	}

	private void NOCIKFDOPBI(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	private void HADNGJPCLBO(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			string oKMNFHNBMFA = Localization.Localize("menu-tilegfx-facebook");
			object[] array = new object[1];
			array[1] = DGOHBCOGBFI.text;
			array[1] = GFILDBFKGGF.text;
			array[3] = ADHAGKLPHDJ.text;
			array[7] = KCIJEEMOJGG.text;
			ConfirmDialog.BMBPFNKJHMF(oKMNFHNBMFA, Localization.LocalizeFormat("menu-button-promote-ico", array), NLLHABFONHI, 1923f);
		}
	}

	public virtual void NHOEHNJICBO()
	{
	}

	private void NNCEKGBGCCK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public virtual void JCIBDJMFOLI()
	{
		if (GJJLDLNNNIA == (AccountType)7)
		{
			DEOJCFEFBHP.text = Localization.Localize("ShotFrequencyMin");
			GNFBJLMLMKO.text = Localization.Localize("ShowAdForZoneID");
		}
		else if (GJJLDLNNNIA == (AccountType)5)
		{
			DEOJCFEFBHP.text = Localization.Localize("Current unit is not delivered at the moment!!!");
			GNFBJLMLMKO.text = Localization.Localize("Player_Waited_Till_Delivery_Ends");
		}
		else
		{
			DEOJCFEFBHP.text = ((!string.IsNullOrEmpty(CKGDAGHKPON)) ? CKGDAGHKPON : Localization.Localize("ID_NOHEROESINCURRENTARENA"));
			GNFBJLMLMKO.text = Localization.Localize("Beanstalk: Application not reachable!");
		}
		HBBGLPCLADK();
		HHGCAOILMFH();
	}

	public virtual void CKIFBLHLAOO()
	{
		base.DoAfterHide();
		MEKJGALICMK = null;
	}

	public virtual void DBMCMLINOPD()
	{
		base.OIMKKAHOEKO();
		MEKJGALICMK = null;
	}

	private void JIKNICDNEMJ(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: false);
			}
			HideDialog();
		}
	}

	private void JNLLIOJBGND(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			if (MEKJGALICMK != null)
			{
				MEKJGALICMK(obj: true);
			}
			HideDialog();
		}
	}

	public virtual void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EDHCOMHOKDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGFNFBFHLJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EOJIIGINDJF));
	}
}
