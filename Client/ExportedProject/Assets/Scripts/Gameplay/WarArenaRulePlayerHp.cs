using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;

public class WarArenaRulePlayerHp : WarArenaRuleGeneric<WarArenaRulePlayerHp.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float playerHp;
	}

	protected virtual OCCICIIEHEF PAJJOHEGNKJ()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PACK"), (OBNJAIHEJOJ)4);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("hasNext"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.MNMEAAEKAMH();
	}

	public virtual bool ECEGIKLPBDP()
	{
		if (data.playerHp > 1577f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.KJDMOCMBFLJ();
	}

	protected virtual OCCICIIEHEF BNLBBIAKFJB()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("success"), (OBNJAIHEJOJ)8);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("antialiasing"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.OHFBLDPINHI();
	}

	public virtual bool OBNNGDGICIK()
	{
		if (data.playerHp > 135f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.DAHIFNEGKAD();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_MOREPLAYERHP"));
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_LESSPLAYERHP"));
		}
		return base.OHFBLDPINHI();
	}

	public virtual bool IJPKPGPEDCO()
	{
		if (data.playerHp > 1639f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.AKIJBMEBNNC();
	}

	protected virtual OCCICIIEHEF CGLNKNAPHDD()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(" OK!"), OBNJAIHEJOJ.FulFill);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("AndroidID"), OBNJAIHEJOJ.InfoText);
		}
		return base.OHFBLDPINHI();
	}

	public override bool AKIJBMEBNNC()
	{
		if (data.playerHp > 977f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.AKIJBMEBNNC();
	}

	protected virtual OCCICIIEHEF BEBKKFBIEJJ()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ShotFrequencyMaxCannon"), OBNJAIHEJOJ.InfoText);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("leagueMembers"));
		}
		return base.EPEIMHECJHK();
	}

	public virtual bool JEBKAPDIKAM()
	{
		if (data.playerHp > 212f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.DAHIFNEGKAD();
	}

	public virtual bool KGNCALOLAHJ()
	{
		if (data.playerHp > 1508f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.MPNDBIBDOCD();
	}

	public virtual bool OCOLAMMPOBP()
	{
		if (data.playerHp > 1030f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.AIMGMMCHEIO();
	}

	public virtual bool BEAIFLHACMB()
	{
		if (data.playerHp > 1470f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.OEAODGFDMGC();
	}

	protected virtual OCCICIIEHEF DJHPDCMGPOO()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_FEATURE_MAGAZINE"), (OBNJAIHEJOJ)4);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"));
		}
		return base.NELJBJBMOLH();
	}

	public virtual bool AKEHNCAPIDE()
	{
		if (data.playerHp > 1079f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.EKMMLNKADIL();
	}

	public virtual bool KEHNMKJNNLG()
	{
		if (data.playerHp > 211f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.MPNDBIBDOCD();
	}

	public virtual bool AONAAGJDHOD()
	{
		if (data.playerHp > 1595f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.CLPEMLCLDIJ();
	}

	public virtual bool IHIGFGJMKDB()
	{
		if (data.playerHp > 1301f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.EKMMLNKADIL();
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("1"), (OBNJAIHEJOJ)6);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PrepareBotForDeathMatch 00 "), (OBNJAIHEJOJ)7);
		}
		return base.MNMEAAEKAMH();
	}

	protected virtual OCCICIIEHEF BONNBPPGHKO()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("globalPlayerLeaderboard"), (OBNJAIHEJOJ)6);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Midnight"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.PEAIJAFJCBA();
	}

	protected virtual OCCICIIEHEF NACPOMOHGBJ()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("First you must run createStructure"), (OBNJAIHEJOJ)5);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_WARNING_SERVERTIMEDOUT"), (OBNJAIHEJOJ)6);
		}
		return base.OOBCHHAGFIO();
	}

	public virtual bool DMKIPBEAMBI()
	{
		if (data.playerHp > 536f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.NMPPLCHLCDK();
	}

	protected virtual OCCICIIEHEF NOLCHEFGPGB()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_OFFERWRONGDISCOUNT"), (OBNJAIHEJOJ)7);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"), OBNJAIHEJOJ.InfoText);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF DEKPLKOFMFM()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\"NaN\""), (OBNJAIHEJOJ)5);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CATEGORY_LOW_PL_ROCKET"), (OBNJAIHEJOJ)7);
		}
		return base.LOJHLDGDLIP();
	}

	public virtual bool MDINCFAKJPM()
	{
		if (data.playerHp > 1366f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.EDNAIMPLPGL();
	}

	protected virtual OCCICIIEHEF HFDCEAPEEGJ()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\n{0}\n"), (OBNJAIHEJOJ)6);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CRAFTING"), OBNJAIHEJOJ.InfoText);
		}
		return base.NNNAKBICOHM();
	}

	public virtual bool KOHMDOHKMIH()
	{
		if (data.playerHp > 1813f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.DAHIFNEGKAD();
	}

	public virtual bool LFJLHMIJLHK()
	{
		if (data.playerHp > 958f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.EKMMLNKADIL();
	}

	public virtual bool DFIMOMOIHCD()
	{
		if (data.playerHp > 1611f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.OEAODGFDMGC();
	}

	public virtual bool IDCLHHDLCPJ()
	{
		if (data.playerHp > 137f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.AIMGMMCHEIO();
	}

	public virtual bool LDMCCCLPOML()
	{
		if (data.playerHp > 1218f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.DDFGIDBHJIK();
	}

	public override bool AIMGMMCHEIO()
	{
		if (data.playerHp > 1094f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.AKIJBMEBNNC();
	}

	protected virtual OCCICIIEHEF PIMHAILAAEI()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("leagueMembers"), (OBNJAIHEJOJ)6);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("OK"), (OBNJAIHEJOJ)5);
		}
		return base.NNNAKBICOHM();
	}

	public virtual bool HCGMAHBEIMB()
	{
		if (data.playerHp > 1856f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.OAELLJPGBPC();
	}

	protected virtual OCCICIIEHEF NKPLBFGHGCO()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Param"), (OBNJAIHEJOJ)7);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SALEPERCENTLINE"), (OBNJAIHEJOJ)7);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF NMNDHOPPLLH()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("-[^-]*$"), (OBNJAIHEJOJ)7);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("NewVisuals"), (OBNJAIHEJOJ)6);
		}
		return base.PEAIJAFJCBA();
	}

	protected virtual OCCICIIEHEF DKBNNKANPLC()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_WAITINGFORFRIEND"));
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("D2"), (OBNJAIHEJOJ)6);
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF HPNAENEAMLB()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_AGAINSTTHESAMEOPPONENT"), (OBNJAIHEJOJ)4);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("TuneListener trackerDidReceiveDeeplink: "));
		}
		return base.EPEIMHECJHK();
	}

	protected virtual OCCICIIEHEF EEOALKHGIOE()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Session: On GC authenticated! Result = "), (OBNJAIHEJOJ)8);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}{2}"), (OBNJAIHEJOJ)7);
		}
		return base.NELJBJBMOLH();
	}

	protected virtual OCCICIIEHEF IMMALNHKFBH()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PARCELABLE_WRITE_RETURN_VALUE"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_STAT_KILLS"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.IBOOCJPKFLG();
	}

	public virtual bool AKCJIOOJHCG()
	{
		if (data.playerHp > 1624f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.AIMGMMCHEIO();
	}

	public virtual bool KJBLKMDHJMC()
	{
		if (data.playerHp > 795f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.DAHIFNEGKAD();
	}

	protected virtual OCCICIIEHEF HJHMLCPKGAB()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("LevelReward"), OBNJAIHEJOJ.InfoText);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ACD: Memory was tampered, cheater detected!"), OBNJAIHEJOJ.InfoText);
		}
		return base.IBOOCJPKFLG();
	}

	public virtual bool CFMHCPCKMEC()
	{
		if (data.playerHp > 1626f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.AIMGMMCHEIO();
	}

	public virtual bool JIBFELAHJDE()
	{
		if (data.playerHp > 1099f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.AKIJBMEBNNC();
	}

	protected override OCCICIIEHEF NNNAKBICOHM()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Army_Unit_ID"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}{1}[-] / {2}"), (OBNJAIHEJOJ)5);
		}
		return base.OMDJEDGCGOM();
	}

	public virtual bool MNJCKHIAHKK()
	{
		if (data.playerHp > 671f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.OAELLJPGBPC();
	}

	public virtual bool GEDHBEADJGG()
	{
		if (data.playerHp > 1788f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.MPNDBIBDOCD();
	}

	protected virtual OCCICIIEHEF LLKGHNIJOAN()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Font problems with labels"), (OBNJAIHEJOJ)7);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("isRandomMap"), (OBNJAIHEJOJ)6);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF HMEACMJLAOC()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Pack_Id"), (OBNJAIHEJOJ)8);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("service"));
		}
		return base.OMDJEDGCGOM();
	}

	protected override OCCICIIEHEF OMDJEDGCGOM()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_LOADING"), OBNJAIHEJOJ.InfoText);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Beanstalk: Dev access unlocked"), (OBNJAIHEJOJ)6);
		}
		return base.LOJHLDGDLIP();
	}

	public virtual bool LHKPJNGMDNA()
	{
		if (data.playerHp > 1285f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.NOHIGPGHNBO(data.playerHp);
		}
		return base.LPLPANBJDAM();
	}

	protected virtual OCCICIIEHEF BLKCJGPKBPH()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Grenade_Throwing_Tutorial_Duration"), (OBNJAIHEJOJ)6);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}"), OBNJAIHEJOJ.FulFill);
		}
		return base.LOJHLDGDLIP();
	}

	public override bool EKMMLNKADIL()
	{
		if (data.playerHp > 0f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetPlayerHP(data.playerHp);
		}
		return base.EKMMLNKADIL();
	}

	public virtual bool NLJBOPJBPPN()
	{
		if (data.playerHp > 453f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.DPKNOMGOFLG(data.playerHp);
		}
		return base.AIMGMMCHEIO();
	}

	protected virtual OCCICIIEHEF BIHMBFONHBL()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GUI_BUDDY"), OBNJAIHEJOJ.FulFill);
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.IEKDLDACNDI();
	}

	protected virtual OCCICIIEHEF IDGICNANPCC()
	{
		ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		if (data.playerHp > (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PROCESSING"));
		}
		if (data.playerHp < (float)fLOATVALUE)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Testing Player"), (OBNJAIHEJOJ)8);
		}
		return base.PEAIJAFJCBA();
	}
}
