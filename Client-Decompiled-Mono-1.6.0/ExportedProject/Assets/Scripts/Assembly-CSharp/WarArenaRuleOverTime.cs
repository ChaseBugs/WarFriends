using System;
using Google2u;

public class WarArenaRuleOverTime : WarArenaRuleGeneric<WarArenaRuleOverTime.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public int overtimeAfter = 120;
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENAMODEUNLOCKED"));
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Action "));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackGuaranteedCardsType);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Battles_Played"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("REGISTER VIEW STARTER ASSIGNMENT "), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.OOBCHHAGFIO();
	}

	public virtual void MMHMLHKOAKK()
	{
		base.HBPJJCDCPLG();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF LLAMMNLFPGC()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("flight_forward_jetpack_elite"), (OBNJAIHEJOJ)8);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TUTORIAL_START_PHASE2"), (OBNJAIHEJOJ)7);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarity);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("GameCenterName"), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GUI_CHEATWARNING"), (OBNJAIHEJOJ)5);
		}
		return base.IEKDLDACNDI();
	}

	public virtual void OAMLLOFDFHN()
	{
		base.IONJNJKPMHK();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF HJHMLCPKGAB()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_AREYOUSUREYOUWANTTOCONVERTPARTS"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("RETRY"), (OBNJAIHEJOJ)8);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("LevelName"), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\n"), (OBNJAIHEJOJ)5);
		}
		return base.IBOOCJPKFLG();
	}

	protected override OCCICIIEHEF MNMEAAEKAMH()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("registerGender"), (OBNJAIHEJOJ)6);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Connection Timed Out!"), OBNJAIHEJOJ.InfoText);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SilverCardRarity);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}"), OBNJAIHEJOJ.InfoText);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("^\\D*"), (OBNJAIHEJOJ)5);
		}
		return base.OMDJEDGCGOM();
	}

	public virtual void NOPELHPBFNB()
	{
		base.FBDFHHKIICO();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF BBKDBPOMDMK()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\n"), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Chat Tab: added time to messages, reinitializing chat messages."), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("assignment"), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Text"));
		}
		return base.BEDAAOOPNLB();
	}

	public virtual void DEHMMBCLOFC()
	{
		base.ANCJEMCFEID();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF FOHHCGJLPON()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Animation from State: Crafting to State: Ready"), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(")"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ShieldRespawnRatePerSec);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_UNIT2UPGRADE_UNIT1BUY"), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TOCOMPLETE"), (OBNJAIHEJOJ)4);
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF IBFBBFCOOMP()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_GAMEDIDNTEXIST"), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("0.#"), OBNJAIHEJOJ.DoesNotMeet);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player_Waited_Till_Delivery_Ends"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WarsEvaluation"));
		}
		return base.OOBCHHAGFIO();
	}

	public virtual void EMPADMNAHHH()
	{
		base.ALJKKBMBBFM();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void FPJNGFNKPAF()
	{
		base.ANCJEMCFEID();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF KBBNGLNFBHM()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ON FINISH PLAYER LEAGUE, RESULT ="), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("visuals: wrong number {0} -{1}"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ShieldRespawnRatePerSec);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("reloadTime"), (OBNJAIHEJOJ)6);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Set time to: "), OBNJAIHEJOJ.InfoText);
		}
		return base.LOJHLDGDLIP();
	}

	protected virtual OCCICIIEHEF IDGICNANPCC()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("warbucks"), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BeginnersLeague"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCardRarity);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Directory \"{0}\" does not exists"), (OBNJAIHEJOJ)8);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"));
		}
		return base.MNMEAAEKAMH();
	}

	protected virtual OCCICIIEHEF MHFONBFBNJL()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("null"), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("added"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackGuaranteedCardsType);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("REMOVING CURRENT PLAYER FROM SQUAD "), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("isRandomMap"), (OBNJAIHEJOJ)5);
		}
		return base.MFBIPMEKFAF();
	}

	public virtual void AGOIGAJMEAO()
	{
		base.JNEGPCHLGKD();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF AFENBKLIJDC()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("FB_Connect"), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("GameGold"), OBNJAIHEJOJ.DoesNotMeet);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackGuaranteedCardsType);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Card_1_Played"), (OBNJAIHEJOJ)8);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("FacebookId"), (OBNJAIHEJOJ)4);
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF NMNDHOPPLLH()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("App installed"), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("response= "), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SÌ"), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("elitepack2"), (OBNJAIHEJOJ)5);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual void OFMFHAEKFPP()
	{
		base.JNEGPCHLGKD();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF GIGFFEIMCDL()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PlayerData"), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Win"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.BronzePackGuaranteedCardsType);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_STATE_OPPONENTISREADYTOBATTLE"), (OBNJAIHEJOJ)8);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("withContentId"), (OBNJAIHEJOJ)8);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual void PFAAMLAEKIM()
	{
		base.EPDLHJFDJBE();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public override void JNEGPCHLGKD()
	{
		base.LFFGKLJMMGF();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF GJLFCGNCDMI()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Arena Lives: "), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}{1}"), OBNJAIHEJOJ.InfoText);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_EMPTYSQUADMESSAGE"), OBNJAIHEJOJ.InfoText);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("count: "), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.PEAIJAFJCBA();
	}

	protected virtual OCCICIIEHEF EFAOEMFMBHI()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Inactive player disconnected: "), (OBNJAIHEJOJ)6);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_MEMBERS"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackMaxRarityCardsType);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Overtime_Was_Already_Explained"), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SALEPERCENTLINE"), (OBNJAIHEJOJ)8);
		}
		return base.LMOHCGEPLAH();
	}

	public virtual void PMCIEKHOEHD()
	{
		base.HBPJJCDCPLG();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF BONNBPPGHKO()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("set acces token: "), (OBNJAIHEJOJ)5);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Checking success string: "), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.BronzePackMaxRarityCardsType);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Step10"), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("100+."), (OBNJAIHEJOJ)7);
		}
		return base.IEKDLDACNDI();
	}

	protected virtual OCCICIIEHEF CGLNKNAPHDD()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ROCKETLAUNCHERTUTORIALTEXT"), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ACTIVATEINSTEADOF"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.DeathMatchTime);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Level"), (OBNJAIHEJOJ)5);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ReSyncPowerRPC"));
		}
		return base.MNMEAAEKAMH();
	}

	public override void IBEGGCHBJGC()
	{
		base.JNEGPCHLGKD();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void KKBBMPFNKGJ()
	{
		base.FBDFHHKIICO();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void IPCGELBGCDO()
	{
		base.JMLIBCJJOIA();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void FKPKLIABCGC()
	{
		base.FBDFHHKIICO();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void MPDCMCLHIPA()
	{
		base.LFFGKLJMMGF();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void HBGADKDOEDH()
	{
		base.HIHFCANHINM();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF PIMHAILAAEI()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_READYTIME"), (OBNJAIHEJOJ)8);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(" set beginners league "), (OBNJAIHEJOJ)6);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("CheckGOLayers - Done"));
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Sniper_Tutorial_Played"), (OBNJAIHEJOJ)6);
		}
		return base.IEKDLDACNDI();
	}

	public virtual void DKOGPGIKGLN()
	{
		base.APIJFIPABAO();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public override void APIJFIPABAO()
	{
		base.IBEGGCHBJGC();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void NABMPNFGLKM()
	{
		base.LFFGKLJMMGF();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void CJFEHCCGAHN()
	{
		base.LFFGKLJMMGF();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF PCCCPHOEGBH()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SEC"), (OBNJAIHEJOJ)8);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_AGAINSTTHESAMEOPPONENT"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackMaxRarityCardsType);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Show Waiting Dialog "), OBNJAIHEJOJ.InfoText);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("unity"), OBNJAIHEJOJ.FulFill);
		}
		return base.LOJHLDGDLIP();
	}

	public virtual void HBEIPMGNMCF()
	{
		base.IONJNJKPMHK();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void BLFJKKHNMDM()
	{
		base.FBDFHHKIICO();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void KMJDCBMACDK()
	{
		base.HIHFCANHINM();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF NPEPOGICIDM()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("VipCardMessage {0}"), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("newHeroicPoints"), (OBNJAIHEJOJ)8);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarity);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Career Record {0:D2}"));
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Unit_Upgrade"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.CKKHLNNIKHE();
	}

	public override void GJFHGPMMDEM()
	{
		base.GJFHGPMMDEM();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void KDPPNFLMDHG()
	{
		base.ANCJEMCFEID();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF DMJPIAALNJK()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("NumberOfMission"), (OBNJAIHEJOJ)6);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("CONFIRMAR"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.BronzePackBronzeCards);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ShotFrequencyMin"), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("S"), (OBNJAIHEJOJ)4);
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF BEBKKFBIEJJ()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}\n{1}"));
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_INSILVER1"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\"NaN\""), (OBNJAIHEJOJ)5);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Play_Card_Tutorial_Duration"), OBNJAIHEJOJ.FulFill);
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF MEFHLDONKGE()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Twitch"), (OBNJAIHEJOJ)6);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WarFriends requires permission to access your media storage in order to download critical game data.Without this permission the game cannot function and will be closed. Please retry or quit WarFriends."), OBNJAIHEJOJ.InfoText);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\""), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("instantBattleAvailable"), OBNJAIHEJOJ.FulFill);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual void OAMKKKAEKGE()
	{
		base.IBEGGCHBJGC();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF NOLCHEFGPGB()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("MessageId"), OBNJAIHEJOJ.FulFill);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("None"), OBNJAIHEJOJ.FulFill);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ShieldRespawnRatePerSec);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Challenge Counter expired!"), (OBNJAIHEJOJ)7);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_NOTIFICATION_DAILYREWARD_MESSAGE"), (OBNJAIHEJOJ)5);
		}
		return base.IEKDLDACNDI();
	}

	public virtual void EFDFHKGHPIA()
	{
		base.ALJKKBMBBFM();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void DLDDBLFIFMB()
	{
		base.JNEGPCHLGKD();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_NOOVERTIME"));
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_INSTANTOVERTIME"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_LATEOVERTIME"));
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_EARLYOVERTIME"));
		}
		return base.OHFBLDPINHI();
	}

	public virtual void LOLHOEAKDND()
	{
		base.LFFGKLJMMGF();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void OKHFAMGFDGF()
	{
		base.LFFGKLJMMGF();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public override void ALJKKBMBBFM()
	{
		base.IBEGGCHBJGC();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void IPDONLIDIOB()
	{
		base.HBPJJCDCPLG();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF OIJBDMDPHGD()
	{
		if (data.overtimeAfter < 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("registerGender"), (OBNJAIHEJOJ)5);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_STAT_ARENALOOTBOXES"), OBNJAIHEJOJ.InfoText);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackBronzeCards);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_LEAVESQUAD"));
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_MAX"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.NELJBJBMOLH();
	}

	public virtual void DGFFIKIFNOK()
	{
		base.JMLIBCJJOIA();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} Empty"), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("C1"), (OBNJAIHEJOJ)8);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.DeathMatchTime);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GETTOAVOIDRELEGATION1"), OBNJAIHEJOJ.InfoText);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("bazooka"));
		}
		return base.BEDAAOOPNLB();
	}

	public virtual void GNGIFIEJOJJ()
	{
		base.JMLIBCJJOIA();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void EGJJPHIFHHL()
	{
		base.JMLIBCJJOIA();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	public virtual void EFHEFJFBMHL()
	{
		base.HBPJJCDCPLG();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetOverTime(data.overtimeAfter);
	}

	protected virtual OCCICIIEHEF NKIBBGOBKOF()
	{
		if (data.overtimeAfter < 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-gold"), (OBNJAIHEJOJ)5);
		}
		if (data.overtimeAfter == 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("facebookFriends"), OBNJAIHEJOJ.DoesNotMeet);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SilverCardRarity);
		int num = (int)(float)row.FLOATVALUE;
		if (data.overtimeAfter > num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Please add "), (OBNJAIHEJOJ)4);
		}
		if (data.overtimeAfter < num)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-gold"), (OBNJAIHEJOJ)8);
		}
		return base.MFBIPMEKFAF();
	}
}
