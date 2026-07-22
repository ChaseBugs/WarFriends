using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;

public class WarArenaRuleCrates : WarArenaRuleGeneric<WarArenaRuleCrates.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float killStreakRatio = 0.75f;
	}

	public virtual void BNNJHPAOIKP()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.IONJNJKPMHK();
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		if (data.killStreakRatio <= 667f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GOOGLEPLAYLOGOUTTEXT"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CREATE"));
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SALEPERCENTLINE"), (OBNJAIHEJOJ)5);
		}
		return base.OMDJEDGCGOM();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.killStreakRatio <= 0f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_NOCRATES"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_LESSCRATES"));
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_MORECRATES"));
		}
		return base.OHFBLDPINHI();
	}

	public virtual void OBGPNLJGPMN()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.EPDLHJFDJBE();
	}

	protected virtual OCCICIIEHEF NKIBBGOBKOF()
	{
		if (data.killStreakRatio <= 31f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("subscription1"), (OBNJAIHEJOJ)6);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-attack-ico"));
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_OFFERACTIVE"), OBNJAIHEJOJ.FulFill);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF FOHHCGJLPON()
	{
		if (data.killStreakRatio <= 959f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("RETRY"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\n"), OBNJAIHEJOJ.FulFill);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(">$500"), (OBNJAIHEJOJ)7);
		}
		return base.IEKDLDACNDI();
	}

	public virtual void EGJJPHIFHHL()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.IONJNJKPMHK();
	}

	public virtual void EFHEFJFBMHL()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.IONJNJKPMHK();
	}

	public override void IBEGGCHBJGC()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.FBDFHHKIICO();
	}

	protected virtual OCCICIIEHEF EPOLOANGNOI()
	{
		if (data.killStreakRatio <= 1407f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("UnsentRewards"), OBNJAIHEJOJ.InfoText);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("#DANIEL# No Achievements found."), (OBNJAIHEJOJ)8);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Medals"), (OBNJAIHEJOJ)8);
		}
		return base.PEAIJAFJCBA();
	}

	public override void FBDFHHKIICO()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.GJFHGPMMDEM();
	}

	public virtual void FABNAAKKJIK()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.EPDLHJFDJBE();
	}

	public override void GFJMJLMFPKO()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.LFFGKLJMMGF();
	}

	protected virtual OCCICIIEHEF KMLOHPNKIDO()
	{
		if (data.killStreakRatio <= 1624f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("S"), (OBNJAIHEJOJ)7);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("601 TUTORIAL STARTED"), (OBNJAIHEJOJ)6);
		}
		return base.IBOOCJPKFLG();
	}

	public virtual void OELEPKHPFKE()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.LFFGKLJMMGF();
	}

	public virtual void DHIMKHMIANB()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.APIJFIPABAO();
	}

	protected virtual OCCICIIEHEF NPEPOGICIDM()
	{
		if (data.killStreakRatio <= 1114f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-attack-ico"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("RegisterBirthday()"), (OBNJAIHEJOJ)5);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}{1}[-]"), OBNJAIHEJOJ.FulFill);
		}
		return base.MFBIPMEKFAF();
	}

	public override void JNEGPCHLGKD()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.JNEGPCHLGKD();
	}

	protected virtual OCCICIIEHEF MEFHLDONKGE()
	{
		if (data.killStreakRatio <= 1484f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Rematch Time"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("NL"), (OBNJAIHEJOJ)8);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TOCOMPLETE"), (OBNJAIHEJOJ)4);
		}
		return base.LOJHLDGDLIP();
	}

	public virtual void EBOGLFIBIIH()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.JMLIBCJJOIA();
	}

	protected virtual OCCICIIEHEF PKEGIGAEKNM()
	{
		if (data.killStreakRatio <= 677f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CATEGORY_LOW_PL_LMG"), (OBNJAIHEJOJ)6);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_TRANSACTIONSRESTORED"));
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V"), (OBNJAIHEJOJ)4);
		}
		return base.PEAIJAFJCBA();
	}

	protected virtual OCCICIIEHEF DJHPDCMGPOO()
	{
		if (data.killStreakRatio <= 1234f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Current Language = "));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BufferManager: new manual buffer, id = "), (OBNJAIHEJOJ)7);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Attempt"), (OBNJAIHEJOJ)5);
		}
		return base.MNMEAAEKAMH();
	}

	protected virtual OCCICIIEHEF FGNOKLGEPGA()
	{
		if (data.killStreakRatio <= 1433f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("withAdvertiserSubAd"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-cards-goldpack"), (OBNJAIHEJOJ)4);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("elite"), OBNJAIHEJOJ.FulFill);
		}
		return base.IEKDLDACNDI();
	}

	public virtual void ILCHIKABJIC()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.HIHFCANHINM();
	}

	public override void GJFHGPMMDEM()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.GJFHGPMMDEM();
	}

	public virtual void NLGDPEIHILO()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.LFFGKLJMMGF();
	}

	protected virtual OCCICIIEHEF NDFDHEEOPHM()
	{
		if (data.killStreakRatio <= 758f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("({0} / {1})"), (OBNJAIHEJOJ)6);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("pistol_idle"), (OBNJAIHEJOJ)6);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.NNNAKBICOHM();
	}

	protected override OCCICIIEHEF EPEIMHECJHK()
	{
		if (data.killStreakRatio <= 1017f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WRONG GAMEOBJECT LAYER ({0}) FOR: {1} LAYER:{2}"), (OBNJAIHEJOJ)8);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Shots_Fired"), OBNJAIHEJOJ.InfoText);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("en"), OBNJAIHEJOJ.FulFill);
		}
		return base.NNNAKBICOHM();
	}

	public virtual void KFKHPMDEKMG()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.IBEGGCHBJGC();
	}

	public virtual void CJFEHCCGAHN()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.GFJMJLMFPKO();
	}

	protected virtual OCCICIIEHEF NJBKGEHKDLG()
	{
		if (data.killStreakRatio <= 887f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Get player data: NOT SENDING PN DEVICE TOKEN"), (OBNJAIHEJOJ)6);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("FuseSDK: Parsing error in _AccountLoginError"), (OBNJAIHEJOJ)4);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GUI_EQUIP"), OBNJAIHEJOJ.FulFill);
		}
		return base.IEKDLDACNDI();
	}

	protected virtual OCCICIIEHEF PBNCCMPCFPE()
	{
		if (data.killStreakRatio <= 95f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_STARTERPACK"), OBNJAIHEJOJ.DoesNotMeet);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_FEATURE_SHOTSPEED"), (OBNJAIHEJOJ)7);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Check Device sleep at {0}, waked up at {1} Dif: {2} Session update: {3}, ScheduleSessionUpdate: {4}"), (OBNJAIHEJOJ)5);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF PCCCPHOEGBH()
	{
		if (data.killStreakRatio <= 378f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Unfreeze "));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_PLAYERALREADYEXISTS"), (OBNJAIHEJOJ)6);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PlayeScifiParticles"), OBNJAIHEJOJ.FulFill);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual void FPJNGFNKPAF()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.JMLIBCJJOIA();
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		if (data.killStreakRatio <= 966f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("payloadKeys"), (OBNJAIHEJOJ)4);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SLOTUPGRADE_AMMO"), (OBNJAIHEJOJ)7);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SELECTTWOUNITS"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.EPEIMHECJHK();
	}

	protected virtual OCCICIIEHEF KNLNGNJEBMP()
	{
		if (data.killStreakRatio <= 1620f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Claiming reward "), OBNJAIHEJOJ.DoesNotMeet);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("DepositedCards"), (OBNJAIHEJOJ)8);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Total_Warbucks_Spent"), (OBNJAIHEJOJ)7);
		}
		return base.PEAIJAFJCBA();
	}

	protected virtual OCCICIIEHEF MPGOGPEDECJ()
	{
		if (data.killStreakRatio <= 1044f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("D2"), (OBNJAIHEJOJ)8);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_READYTIME"), (OBNJAIHEJOJ)8);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Clearing Waitlist cache..."), (OBNJAIHEJOJ)8);
		}
		return base.MNMEAAEKAMH();
	}

	public override void HBPJJCDCPLG()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.GJFHGPMMDEM();
	}

	public virtual void KMJDCBMACDK()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.JMLIBCJJOIA();
	}

	public virtual void LLMDGDJNJEN()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.JMLIBCJJOIA();
	}

	public virtual void EEDEKPALGAA()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.GJFHGPMMDEM();
	}

	public virtual void BLFJKKHNMDM()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.ANCJEMCFEID();
	}

	public override void APIJFIPABAO()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.ALJKKBMBBFM();
	}

	public virtual void NOPELHPBFNB()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.LFFGKLJMMGF();
	}

	public virtual void FMCCKHKGBDE()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.GJFHGPMMDEM();
	}

	protected override OCCICIIEHEF CKKHLNNIKHE()
	{
		if (data.killStreakRatio <= 610f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WarArenaId with ID {0} not found in DB!"), (OBNJAIHEJOJ)7);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Card_1_Played"));
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(" set league "), OBNJAIHEJOJ.InfoText);
		}
		return base.OOBCHHAGFIO();
	}

	public virtual void GDJEPBFADLB()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.FBDFHHKIICO();
	}

	protected virtual OCCICIIEHEF CCHDCMOJNFP()
	{
		if (data.killStreakRatio <= 344f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}"), OBNJAIHEJOJ.DoesNotMeet);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_TRANSACTIONSRESTORED"), OBNJAIHEJOJ.FulFill);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("end"), (OBNJAIHEJOJ)5);
		}
		return base.BEDAAOOPNLB();
	}

	public virtual void LIEANPEIJHK()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.GFJMJLMFPKO();
	}

	protected virtual OCCICIIEHEF PAJJOHEGNKJ()
	{
		if (data.killStreakRatio <= 355f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("dogtags"), OBNJAIHEJOJ.DoesNotMeet);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("DailyMissionsCompletionRewardScraps"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Name"), (OBNJAIHEJOJ)7);
		}
		return base.EPEIMHECJHK();
	}

	protected virtual OCCICIIEHEF CGLNKNAPHDD()
	{
		if (data.killStreakRatio <= 1570f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Tutorial_Step_Complete"), (OBNJAIHEJOJ)8);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Can not find boss"), (OBNJAIHEJOJ)4);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_FEATURE_CRITICAL-WEAPONPREFIX"), OBNJAIHEJOJ.FulFill);
		}
		return base.NNNAKBICOHM();
	}

	public virtual void EPMPJNBBILB()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.IONJNJKPMHK();
	}

	protected virtual OCCICIIEHEF OHNKNEHMLPB()
	{
		if (data.killStreakRatio <= 1334f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("LifeCount"), (OBNJAIHEJOJ)8);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_REGULARPRIZE"), OBNJAIHEJOJ.InfoText);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_EXITINGMATCH"), (OBNJAIHEJOJ)5);
		}
		return base.MFBIPMEKFAF();
	}

	public virtual void DGFFIKIFNOK()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.FBDFHHKIICO();
	}

	protected virtual OCCICIIEHEF AFENBKLIJDC()
	{
		if (data.killStreakRatio <= 1975f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_YES"), (OBNJAIHEJOJ)6);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}"), OBNJAIHEJOJ.InfoText);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("elite"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.OHFBLDPINHI();
	}

	public virtual void JNKLOBHLNNB()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.FBDFHHKIICO();
	}

	protected virtual OCCICIIEHEF NOLCHEFGPGB()
	{
		if (data.killStreakRatio <= 22f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Scenes to go through: {0}"), OBNJAIHEJOJ.FulFill);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"));
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("HEAVYTURRET"), (OBNJAIHEJOJ)4);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF DEKPLKOFMFM()
	{
		if (data.killStreakRatio <= 1420f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("IsWarArenaBattle"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}{2}"), (OBNJAIHEJOJ)6);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Gold_Balance"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.BEDAAOOPNLB();
	}

	protected virtual OCCICIIEHEF BNBPAJLLFPI()
	{
		if (data.killStreakRatio <= 264f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT"), (OBNJAIHEJOJ)5);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Recieved {0} messages:"), (OBNJAIHEJOJ)6);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BufferManager: remove buffer, id = "), (OBNJAIHEJOJ)5);
		}
		return base.IBOOCJPKFLG();
	}

	protected virtual OCCICIIEHEF GJLFCGNCDMI()
	{
		if (data.killStreakRatio <= 1784f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_HOU"));
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Min"), (OBNJAIHEJOJ)6);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Error setting match state {0} to player {1}"), (OBNJAIHEJOJ)6);
		}
		return base.IEKDLDACNDI();
	}

	public virtual void DLDDBLFIFMB()
	{
		Singleton<ScoreManager>.instance.FJPNILFKIAB = data.killStreakRatio;
		base.EPDLHJFDJBE();
	}

	protected virtual OCCICIIEHEF NACPOMOHGBJ()
	{
		if (data.killStreakRatio <= 95f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("A"), OBNJAIHEJOJ.InfoText);
		}
		ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio);
		ObscuredFloat fLOATVALUE = row.FLOATVALUE;
		if (data.killStreakRatio < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Beanstalk: Dev access unlocked"), OBNJAIHEJOJ.FulFill);
		}
		if (data.killStreakRatio > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("temp_google_user_id"), OBNJAIHEJOJ.InfoText);
		}
		return base.LOJHLDGDLIP();
	}
}
