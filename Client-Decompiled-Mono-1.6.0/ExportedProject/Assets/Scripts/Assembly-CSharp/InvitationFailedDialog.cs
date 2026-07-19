using System;
using UnityEngine;

public class InvitationFailedDialog : GuiElementSingle<InvitationFailedDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	public UILabel NFNLBEGFLHC;

	[Header("Middle")]
	public UILabel JPCIACBHGHO;

	[Header("Bottom")]
	public UIButton CCFFNAKFPPE;

	private OOJDIACPBED DAHCKIBAPFP;

	public virtual void NAOJCFMFLLA()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)7)
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_EMPTYARENAHEROESCURRENT");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("Confirmed_In_App") : Localization.Localize("CZ"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("warcards");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("ID_GC_LOGIN_TUTORIAL_TITLE") : Localization.Localize("ID_LVLNUMBER"));
		}
	}

	public virtual void MDLMEDANPLD()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)5)
		{
			NFNLBEGFLHC.text = Localization.Localize("Awaiting players - Adding player ");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("BeAdvisedJoinOrCreateSquad") : Localization.Localize("ID_STAT_SHOTGUNKILLS"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("Generate army 2");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("Setting performance to: ") : Localization.Localize("Current Locale unity = "));
		}
	}

	public void FNGFBKPACAN(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 587f);
	}

	public virtual void JBPMEEOHJIH()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)7)
		{
			NFNLBEGFLHC.text = Localization.Localize("{0} / {1}");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("GrenadeMinDamage") : Localization.Localize("{0}{1}[-] {2}/[-] {3}"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_NOTIFICATION_LAPSED_VIP");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("#AccoutCheck# FB login during tutorial") : Localization.Localize("SERVICE_MISSING_PERMISSION"));
		}
	}

	public void JKIMMLIGLAF(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 456f);
	}

	public virtual void JHJFMOCHJHP()
	{
		PNPHMONMFJG(CCFFNAKFPPE.gameObject);
	}

	public virtual void HGKNCKIKBDC()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.None)
		{
			NFNLBEGFLHC.text = Localization.Localize("IsPublic");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("?") : Localization.Localize("ID_NOLONGERAVAILABLE"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_WARNING_NOTENOUGHTLEVEL");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("{0}\u00a0{1}") : Localization.Localize("App could not be run"));
		}
	}

	public virtual void PGJDLKDMCHN()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)6)
		{
			NFNLBEGFLHC.text = Localization.Localize("$1.99");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize(" ") : Localization.Localize("StartEnemyBehaviourNetwork"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_TUTORIAL_SNIPERSHOOT_DOWN");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ItemRarity_4") : Localization.Localize("PlayerInfo"));
		}
	}

	public void PJDNPHAHFBE(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1111f);
	}

	public virtual void OLIOADHMKKA()
	{
		BNCICCJAIJJ(CCFFNAKFPPE.gameObject);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CHCMEJEPOHH));
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKFNOHPOLCN));
	}

	public virtual void AIIJHNNODDM()
	{
		AJFINACMHIG(CCFFNAKFPPE.gameObject);
	}

	public virtual void CAALKACDJEK()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)5)
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_INMASTER2");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT") : Localization.Localize("]"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_EMPTYUNITTRAIN");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize(" x ") : Localization.Localize("ID_NORMAL_OBJECTIVE"));
		}
	}

	public void DOKNIFNNCDH(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1935f);
	}

	public void CKJCFLGKPOA(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 435f);
	}

	public virtual void MCKBAIKEPEF()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Waiting)
		{
			NFNLBEGFLHC.text = Localization.Localize("{0} 00 {1}");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("N") : Localization.Localize("ID_CONFIRM_SERVERCOULDNOTCOMPLETED"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_WARSHOP_MEMBERSHIP");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("await") : Localization.Localize("102 GAME STARTED"));
		}
	}

	private void NBKHAHCONKP(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void JOPPNGGBMCE()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}

	private void PKFNOHPOLCN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void PPLBJDJIIPN()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)5)
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_SQUADEVENT");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT") : Localization.Localize("ID_HOURANDMORE"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_TUTORIAL_SWIPE_DOWN");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT") : Localization.Localize("false"));
		}
	}

	public virtual void FNLELBKLNBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NBKHAHCONKP));
	}

	public virtual void EODIJMEGKHF()
	{
		AEEFHPFKBGA(CCFFNAKFPPE.gameObject);
	}

	private void PIAGKIIHBNB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void MDHJIPDGDAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGGLBBOPDNN));
	}

	public void GONOICLIMKO(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1216f);
	}

	public virtual void DHMNIOHKIGC()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)8)
		{
			NFNLBEGFLHC.text = Localization.Localize(")");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("SquadName") : Localization.Localize("special"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("SpawnByCardRPC");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize(", action = connection check") : Localization.Localize("RETRY"));
		}
	}

	public void ShowDialog(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void KFLBEIPPMBF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DOOFLIDLDFA));
	}

	private void GDNHKMFLEKB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	private void AJFINACMHIG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public void FMIGENMGBCL(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1847f);
	}

	public void MPFAAHLLHJC(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 561f);
	}

	public void BBGJMMKIGJG(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1199f);
	}

	public void AJCILBFBNMK(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 389f);
	}

	public void EMBNLMGLNFN(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1814f);
	}

	private void CCHDCEDFNNB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public override void InitGUIValues()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Denied)
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_INVITATIONDENIED");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_YOUROPPONENTHASDENIED") : Localization.Localize("ID_YOURFRIENDHASDENIED"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_INVITATIONNOTACCEPTED");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_YOUROPPONENTHASNOTACCEPTED") : Localization.Localize("ID_YOURFRIENDHASNOTACCEPTED"));
		}
	}

	public void FKOEBBHPOBP(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 7f);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AJFINACMHIG));
	}

	public GuiElement JEAMNJAPFJK()
	{
		return this;
	}

	public GuiElement FKCNDEANKNA()
	{
		return this;
	}

	public void IMJEPFACICP(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 473f);
	}

	public virtual void FACKIKMABGK()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)8)
		{
			NFNLBEGFLHC.text = Localization.Localize("\t\"FALSE\"");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("ID_RETRY") : Localization.Localize("#Mission Rewards# Mission Game Rewards Came"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("#Swipe failed, distance threshold condition");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE") : Localization.Localize("battlesLostInRow"));
		}
	}

	public virtual void GEDIFKPBIML()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}

	public virtual void KFANFNCILJI()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)7)
		{
			NFNLBEGFLHC.text = Localization.Localize("clipSize");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("N") : Localization.Localize("ID_YOUNEEDXTICKETSFOREXTRAHEART"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("left");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("Name") : Localization.Localize("[^\\d]"));
		}
	}

	public void GKCAKMLOIBI(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 865f);
	}

	public void JOOFMNHIJPK(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1559f);
	}

	private void OBCKNKOEPBK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void NHKGKDBAKLH()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Denied)
		{
			NFNLBEGFLHC.text = Localization.Localize("GameCenterName");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("game-card-ico-shielddestroyer") : Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC_TEXT"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("Assignment_Issued");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("NextWithdraw") : Localization.Localize("boxOpen"));
		}
	}

	public virtual void AGFDJGJALKD()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Waiting)
		{
			NFNLBEGFLHC.text = Localization.Localize("Please add object to pool, before instanciing it ::: prefab name = {0}");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("ID_ENGLISH") : Localization.Localize("dogTagTimerLock"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize(" = ");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize(" NOT OK!\t\t\t\t\t\t") : Localization.Localize("Time"));
		}
	}

	public virtual void KMCKIIFEKCA()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Accepted)
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_TUTORIAL_TAPON");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("0%") : Localization.Localize("ID_YOURBEST"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("AddedCards");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("success") : Localization.Localize("ETM: Show Rewarded Video"));
		}
	}

	public virtual void JDFDNLGMPFJ()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Waiting)
		{
			NFNLBEGFLHC.text = Localization.Localize("*****   Bootcamp Play warcards Ended   *****");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_EXTRAAMMO") : Localization.Localize("#VOJTA# WAR ARENA CONFIG RECEIVED! Id = "));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_GUI_UNLOCKEDAT");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("TEST") : Localization.Localize("ID_YOUHAVENOGOLDWARCARDSAVAILABLE"));
		}
	}

	public virtual void HMNOPHFJJHK()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)5)
		{
			NFNLBEGFLHC.text = Localization.Localize("BatchSizeMax");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("null") : Localization.Localize("#AccoutCheck# FacebookLoginDuringTutorial - ALL OK - loged to FB connectet to this account"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("{0}\t");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_RETRY") : Localization.Localize("Add RARITY {0} warcard - {1}"));
		}
	}

	public GuiElement HDNIHBJDLKF()
	{
		return this;
	}

	public virtual void DHNILCPGLLI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGGLBBOPDNN));
	}

	private void AMFBCAFIACM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public GuiElement NDOMPDOOJND()
	{
		return this;
	}

	public void OPICOKKMEKG(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1149f);
	}

	public virtual void DFLGLEJIPCO()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)7)
		{
			NFNLBEGFLHC.text = Localization.Localize("shield_hide");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("Beanstalk: Get Player Data - unset rewards set!") : Localization.Localize("N"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("equippedID");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("ID_SELECTTWOUNITS") : Localization.Localize("resizing texture "));
		}
	}

	public void HAJGLINBGNN(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1625f);
	}

	public virtual void IOLNONPHCMM()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)8)
		{
			NFNLBEGFLHC.text = Localization.Localize("tempuser@tempcompany.com");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("NULL unit") : Localization.Localize("Get Custom Profile Variables"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_CONFIRM_SQUADALREADYEXISTS");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("BOT") : Localization.Localize("null"));
		}
	}

	private void BNCICCJAIJJ(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void ELAONOIOFEP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JIGEKLCJCNA));
	}

	public GuiElement BBBFIJMJOCP()
	{
		return this;
	}

	public void IOAICJBKOIP(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 9f);
	}

	private void FKLJJACDBOJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public void OMCEGPODDHL(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 928f);
	}

	public GuiElement CBANDKHPNBD()
	{
		return this;
	}

	public void LNCDCBNNKHN(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1682f);
	}

	private void KPNAPLMCIGO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void ODLKCAGIKBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGGLBBOPDNN));
	}

	private void IMNOAJOHEMO(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void LBIJJNEOELO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGGLBBOPDNN));
	}

	public virtual void CCLAJHMFLDF()
	{
		PNPHMONMFJG(CCFFNAKFPPE.gameObject);
	}

	public void MCJEBLNCJMM(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1315f);
	}

	public void ONHPOAIKLAO(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1175f);
	}

	private void CHDJANBMGED(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CHDJANBMGED));
	}

	public virtual void DCNGEGFNAGG()
	{
		BNCICCJAIJJ(CCFFNAKFPPE.gameObject);
	}

	public void POPMFPMBHIP(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1776f);
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMNOAJOHEMO));
	}

	public virtual void HFPPNCJBIDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKFNOHPOLCN));
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDNHKMFLEKB));
	}

	public GuiElement EMJNNILLFIM()
	{
		return this;
	}

	private void CGGLBBOPDNN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
	}

	public void FACFLKKLGEB(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1017f);
	}

	public GuiElement JJKOKNIDFIN()
	{
		return this;
	}

	public GuiElement LLMDPKEJJHI()
	{
		return this;
	}

	public virtual void HPNDBDNEOIN()
	{
		AMFBCAFIACM(CCFFNAKFPPE.gameObject);
	}

	public virtual void HHEEDIHHCEA()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.None)
		{
			NFNLBEGFLHC.text = Localization.Localize(",  ");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("JoinRoomFailedAfterReconnect: {0} GameIsRunning: {1}") : Localization.Localize("menu-attack-ico"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("Deposited Warcards: ");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("ID_REMINDER_SUITUPSOLDIER") : Localization.Localize("skip session update scheduling, because alredy session update is "));
		}
	}

	public GuiElement MLDGJCPHNFA()
	{
		return this;
	}

	public virtual void KPEJMMBDODD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JIGEKLCJCNA));
	}

	public virtual void ENJOLLFPEDI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JIGEKLCJCNA));
	}

	public virtual void KCAFCPAFBMC()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Accepted)
		{
			NFNLBEGFLHC.text = Localization.Localize("LeagueId");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("setGoogleUserId") : Localization.Localize(" {0}\u00a0{1}"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_STATE_WAITINGFOROPPONENT");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("Buy_Weapon_Upgrade") : Localization.Localize("ID_CUSTOMEVENTEND"));
		}
	}

	public virtual void BGPAHPGDDJB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDNHKMFLEKB));
	}

	public virtual void CDMCFJMCKBP()
	{
		AJFINACMHIG(CCFFNAKFPPE.gameObject);
	}

	public void EBELHKPCLBI(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 594f);
	}

	private void JIGEKLCJCNA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	private void CHCMEJEPOHH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	private void PNPHMONMFJG(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void JDFDJPAAIAA()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)5)
		{
			NFNLBEGFLHC.text = Localization.Localize("Exception stacktrace: ");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("+") : Localization.Localize("ID_CONFIRM_PROMOTETOLEADER"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_YOUHAVENOSILVERWARCARDSAVAILABLE");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("[-]") : Localization.Localize("\"NEGINFINITY\""));
		}
	}

	public virtual void LOMJAAPJHKI()
	{
		AEEFHPFKBGA(CCFFNAKFPPE.gameObject);
	}

	public void KFKNFJCGMFD(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 898f);
	}

	public void AHGBJNLFAGE(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 61f);
	}

	public virtual void MNHAOCEONAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ILENDHMOPJN));
	}

	public GuiElement IBAKPCCGMKI()
	{
		return this;
	}

	public virtual void OMKNGOBMFGM()
	{
		JIGEKLCJCNA(CCFFNAKFPPE.gameObject);
	}

	public GuiElement NKAJOPFDFEI()
	{
		return this;
	}

	private void HKMNJKPFGJO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void JCGDALOBGHO()
	{
		if (DAHCKIBAPFP == (OOJDIACPBED)7)
		{
			NFNLBEGFLHC.text = Localization.Localize("eventStart");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("Spend_Gold_On_Power_Bands") : Localization.Localize("TEXTURE SIZE IS: "));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("Google2u.DBUpgradeSlotsAssaulter");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("menu-army-ammo-ico") : Localization.Localize("N"));
		}
	}

	private void ILENDHMOPJN(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	private void AEEFHPFKBGA(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public virtual void FBDMBKKDEDC()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Denied)
		{
			NFNLBEGFLHC.text = Localization.Localize("QUIT");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} warcards") : Localization.Localize("ID_GOLDPACKS"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("URL");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("bazooka_shot_run") : Localization.Localize("startActivity"));
		}
	}

	public void BFCCMJDBCPO(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 1387f);
	}

	public virtual void MHIFDHGPDCK()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.Denied)
		{
			NFNLBEGFLHC.text = Localization.Localize("ID_TUTORIAL_PHASE");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("setGravityForPopups") : Localization.Localize("Tickets"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("GLM: After tutorial GC check");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("smallThumbnailBig") : Localization.Localize("Quests"));
		}
	}

	public GuiElement FCIKCCPLAAF()
	{
		return this;
	}

	public virtual void FCPGJBMGBLJ()
	{
		IMNOAJOHEMO(CCFFNAKFPPE.gameObject);
	}

	public override void OnBack()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}

	private void DOOFLIDLDFA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (Singleton<GameController>.instance.isMission)
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
		}
	}

	public GuiElement PPMHDKPGEFD()
	{
		return this;
	}

	public void ONBNOKMABOL(OOJDIACPBED KOMEBAICKME)
	{
		DAHCKIBAPFP = KOMEBAICKME;
		Singleton<GuiManager>.instance.ShowDialog(this, 485f);
	}

	public GuiElement FBCEIODHNLC()
	{
		return this;
	}

	public virtual void BNEPKGCDIFH()
	{
		if (DAHCKIBAPFP == OOJDIACPBED.None)
		{
			NFNLBEGFLHC.text = Localization.Localize("test_attribute2");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.isMission) ? Localization.Localize("({0} / {1})") : Localization.Localize("LootBoxRotation"));
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("smallThumbnailBig");
			JPCIACBHGHO.text = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Localization.Localize("author") : Localization.Localize("Requests"));
		}
	}

	public virtual void PGHAMCBHBOD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDNHKMFLEKB));
	}

	public GuiElement BMBDJLLFECJ()
	{
		return this;
	}
}
