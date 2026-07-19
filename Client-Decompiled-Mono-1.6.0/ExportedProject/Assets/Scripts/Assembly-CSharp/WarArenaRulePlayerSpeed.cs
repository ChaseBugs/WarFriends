using System;

public class WarArenaRulePlayerSpeed : WarArenaRuleGeneric<WarArenaRulePlayerSpeed.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float playerSpeed = 1f;
	}

	public virtual void KFKHPMDEKMG()
	{
		base.IBEGGCHBJGC();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void NMKEFAEGDLL()
	{
		base.JNEGPCHLGKD();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.playerSpeed > 1f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_PLAYERSMOVEFASTER"));
		}
		if (data.playerSpeed < 1f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_PLAYERSMOVESLOWER"));
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF MPGOGPEDECJ()
	{
		if (data.playerSpeed > 1383f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("DeathEventShoot"));
		}
		if (data.playerSpeed < 1096f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ColumnNames"), (OBNJAIHEJOJ)6);
		}
		return base.EPEIMHECJHK();
	}

	public virtual void JMICMACJAIK()
	{
		base.IBEGGCHBJGC();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF CCHDCMOJNFP()
	{
		if (data.playerSpeed > 1280f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SKILLSHOTHINT_MULTIKILL"), OBNJAIHEJOJ.InfoText);
		}
		if (data.playerSpeed < 924f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("0"), (OBNJAIHEJOJ)7);
		}
		return base.LOJHLDGDLIP();
	}

	protected virtual OCCICIIEHEF HFDCEAPEEGJ()
	{
		if (data.playerSpeed > 1429f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-squadrank-ico"), (OBNJAIHEJOJ)4);
		}
		if (data.playerSpeed < 1333f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("VIP bought"), (OBNJAIHEJOJ)5);
		}
		return base.IEKDLDACNDI();
	}

	protected virtual OCCICIIEHEF FOHHCGJLPON()
	{
		if (data.playerSpeed > 1400f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ShowEngineerBuildingIndicator"), (OBNJAIHEJOJ)7);
		}
		if (data.playerSpeed < 751f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_3_DOWN"), (OBNJAIHEJOJ)5);
		}
		return base.NNNAKBICOHM();
	}

	protected virtual OCCICIIEHEF NDEMIEDBIPE()
	{
		if (data.playerSpeed > 1801f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC_TEXT"), (OBNJAIHEJOJ)6);
		}
		if (data.playerSpeed < 981f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ENGLISH"), (OBNJAIHEJOJ)5);
		}
		return base.PEAIJAFJCBA();
	}

	protected virtual OCCICIIEHEF FGNOKLGEPGA()
	{
		if (data.playerSpeed > 364f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ADD GOOGLE PLAY ACCOUNT WITH "), (OBNJAIHEJOJ)8);
		}
		if (data.playerSpeed < 1414f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("mapId"), OBNJAIHEJOJ.InfoText);
		}
		return base.LMOHCGEPLAH();
	}

	public virtual void GNOLLKKOKPO()
	{
		base.HBPJJCDCPLG();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected override OCCICIIEHEF MNMEAAEKAMH()
	{
		if (data.playerSpeed > 928f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_UNITCANBEPROMOTEDTOTIER"), (OBNJAIHEJOJ)8);
		}
		if (data.playerSpeed < 1036f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_RENTAL_PISTOL"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.LOJHLDGDLIP();
	}

	protected virtual OCCICIIEHEF MHONCCANCOG()
	{
		if (data.playerSpeed > 846f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), (OBNJAIHEJOJ)5);
		}
		if (data.playerSpeed < 1844f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("game-card-ico-swiftimmortality"), OBNJAIHEJOJ.FulFill);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF PIMHAILAAEI()
	{
		if (data.playerSpeed > 1845f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Awaiting players - Player id:\"{0}\" already added to message center"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.playerSpeed < 1288f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("UNKNOWN FUSEBOXX CONFIGURATION KEY = "), (OBNJAIHEJOJ)4);
		}
		return base.OHFBLDPINHI();
	}

	public override void APIJFIPABAO()
	{
		base.ALJKKBMBBFM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void HJGLJNHOKIB()
	{
		base.APIJFIPABAO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	public override void GJFHGPMMDEM()
	{
		base.GJFHGPMMDEM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected override OCCICIIEHEF CKKHLNNIKHE()
	{
		if (data.playerSpeed > 809f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Squad"), (OBNJAIHEJOJ)7);
		}
		if (data.playerSpeed < 1585f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Days_Since_Install"), (OBNJAIHEJOJ)5);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF CNCKNEMOHJL()
	{
		if (data.playerSpeed > 919f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SyncTrajectoryRPC"), OBNJAIHEJOJ.FulFill);
		}
		if (data.playerSpeed < 969f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_DOWNLOADINGFILES"), (OBNJAIHEJOJ)8);
		}
		return base.LMOHCGEPLAH();
	}

	public virtual void JNKLOBHLNNB()
	{
		base.ALJKKBMBBFM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void KMHLMLHBBAH()
	{
		base.GJFHGPMMDEM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	public virtual void OGOFKFDHJHK()
	{
		base.HIHFCANHINM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF DIIEJEJLKCF()
	{
		if (data.playerSpeed > 1058f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ELITEUNITNAME"), (OBNJAIHEJOJ)4);
		}
		if (data.playerSpeed < 1988f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("added"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.CKKHLNNIKHE();
	}

	protected override OCCICIIEHEF OMDJEDGCGOM()
	{
		if (data.playerSpeed > 552f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Facebook login failed: "), (OBNJAIHEJOJ)5);
		}
		if (data.playerSpeed < 1936f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENAMODE"), (OBNJAIHEJOJ)6);
		}
		return base.MNMEAAEKAMH();
	}

	protected virtual OCCICIIEHEF MEFHLDONKGE()
	{
		if (data.playerSpeed > 584f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Error in bot finding position"), (OBNJAIHEJOJ)4);
		}
		if (data.playerSpeed < 1142f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("US"), (OBNJAIHEJOJ)7);
		}
		return base.BEDAAOOPNLB();
	}

	public virtual void DEHMMBCLOFC()
	{
		base.LFFGKLJMMGF();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void EGEDKGLILBI()
	{
		base.HBPJJCDCPLG();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF DJHPDCMGPOO()
	{
		if (data.playerSpeed > 22f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("TryActivateBonusRPC"), (OBNJAIHEJOJ)4);
		}
		if (data.playerSpeed < 1430f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PlayerArmyPower"), (OBNJAIHEJOJ)5);
		}
		return base.OOBCHHAGFIO();
	}

	public override void JNEGPCHLGKD()
	{
		base.FBDFHHKIICO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	public virtual void LLMDGDJNJEN()
	{
		base.IONJNJKPMHK();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void DHIMKHMIANB()
	{
		base.EPDLHJFDJBE();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF NOLCHEFGPGB()
	{
		if (data.playerSpeed > 433f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GUI_EQUIPPED"), (OBNJAIHEJOJ)5);
		}
		if (data.playerSpeed < 1250f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(")"), (OBNJAIHEJOJ)7);
		}
		return base.OMDJEDGCGOM();
	}

	public virtual void EEDEKPALGAA()
	{
		base.GFJMJLMFPKO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF NMNDHOPPLLH()
	{
		if (data.playerSpeed > 1857f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TUTORIAL_GRENADERS_DOWN"), OBNJAIHEJOJ.FulFill);
		}
		if (data.playerSpeed < 627f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SALEPERCENTLINE"), OBNJAIHEJOJ.InfoText);
		}
		return base.MFBIPMEKFAF();
	}

	public virtual void FKPKLIABCGC()
	{
		base.GJFHGPMMDEM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		if (data.playerSpeed > 287f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TUTORIAL_BIG_REVEAL_UP"), (OBNJAIHEJOJ)5);
		}
		if (data.playerSpeed < 838f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Squad"), (OBNJAIHEJOJ)5);
		}
		return base.MFBIPMEKFAF();
	}

	public virtual void DGFFIKIFNOK()
	{
		base.ALJKKBMBBFM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF GIGFFEIMCDL()
	{
		if (data.playerSpeed > 916f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("MasterId"), (OBNJAIHEJOJ)7);
		}
		if (data.playerSpeed < 885f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_PVP_BATTLE"), OBNJAIHEJOJ.InfoText);
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF FNOGDBMIBHM()
	{
		if (data.playerSpeed > 1122f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Hide poison"), (OBNJAIHEJOJ)6);
		}
		if (data.playerSpeed < 319f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("writeToParcel"), (OBNJAIHEJOJ)4);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual void DGGBFKPEAFF()
	{
		base.ANCJEMCFEID();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void OAMKKKAEKGE()
	{
		base.LFFGKLJMMGF();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	public virtual void ACNNFHACMFB()
	{
		base.IBEGGCHBJGC();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	public virtual void PMCIEKHOEHD()
	{
		base.APIJFIPABAO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	protected virtual OCCICIIEHEF PAJJOHEGNKJ()
	{
		if (data.playerSpeed > 1900f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("OnFetchDeferredAppLinkSucceededEvent"));
		}
		if (data.playerSpeed < 580f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ACCEPT_REMATCH_IN"), (OBNJAIHEJOJ)7);
		}
		return base.BEDAAOOPNLB();
	}

	protected virtual OCCICIIEHEF DKBNNKANPLC()
	{
		if (data.playerSpeed > 219f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("D2"), OBNJAIHEJOJ.FulFill);
		}
		if (data.playerSpeed < 918f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_FORFEIT"), (OBNJAIHEJOJ)5);
		}
		return base.IBOOCJPKFLG();
	}

	protected override OCCICIIEHEF IEKDLDACNDI()
	{
		if (data.playerSpeed > 1162f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("describeContents"));
		}
		if (data.playerSpeed < 677f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Warbucks"), (OBNJAIHEJOJ)6);
		}
		return base.EPEIMHECJHK();
	}

	public virtual void HHHIFDPBLNP()
	{
		base.FBDFHHKIICO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	protected virtual OCCICIIEHEF JGADEDPFGEN()
	{
		if (data.playerSpeed > 865f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Different squads \"{0}\" and \"{1}\"\n"));
		}
		if (data.playerSpeed < 642f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("#PLAYERID# Saving Player Account with PlayerId = "));
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		if (data.playerSpeed > 1990f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Get Experiment Details"), (OBNJAIHEJOJ)7);
		}
		if (data.playerSpeed < 1653f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Bad Decal Manager Data"), OBNJAIHEJOJ.FulFill);
		}
		return base.OMDJEDGCGOM();
	}

	public override void JMLIBCJJOIA()
	{
		base.LFFGKLJMMGF();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF NJBKGEHKDLG()
	{
		if (data.playerSpeed > 337f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("0"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.playerSpeed < 972f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Found labels with shadow font in children:\n"), OBNJAIHEJOJ.InfoText);
		}
		return base.LMOHCGEPLAH();
	}

	public virtual void NPBAJKNNBDI()
	{
		base.FBDFHHKIICO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void JFFANMBFLFL()
	{
		base.GFJMJLMFPKO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF BONNBPPGHKO()
	{
		if (data.playerSpeed > 126f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}"), (OBNJAIHEJOJ)4);
		}
		if (data.playerSpeed < 1801f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_NOW"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.EPEIMHECJHK();
	}

	public virtual void DGHKFLAOHFH()
	{
		base.JNEGPCHLGKD();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	public virtual void MPDCMCLHIPA()
	{
		base.ALJKKBMBBFM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF OICKGOGBDAB()
	{
		if (data.playerSpeed > 870f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"), OBNJAIHEJOJ.FulFill);
		}
		if (data.playerSpeed < 687f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GUI_VIPMEMBERSHIP"), (OBNJAIHEJOJ)5);
		}
		return base.OMDJEDGCGOM();
	}

	public virtual void EPMPJNBBILB()
	{
		base.HBPJJCDCPLG();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void CHMFPJDKEIF()
	{
		base.HIHFCANHINM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void OAIEIPFJMHN()
	{
		base.HIHFCANHINM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public override void FBDFHHKIICO()
	{
		base.GFJMJLMFPKO();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	protected virtual OCCICIIEHEF HADBACCEMBP()
	{
		if (data.playerSpeed > 1092f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("videoName"), (OBNJAIHEJOJ)4);
		}
		if (data.playerSpeed < 1560f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("L"), (OBNJAIHEJOJ)4);
		}
		return base.OMDJEDGCGOM();
	}

	public override void HBPJJCDCPLG()
	{
		base.JNEGPCHLGKD();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.speed = data.playerSpeed;
	}

	public virtual void HBEIPMGNMCF()
	{
		base.ALJKKBMBBFM();
		PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
		oGMBJPKOPCB.FOCHCKLMPBH(data.playerSpeed);
	}

	protected override OCCICIIEHEF IBOOCJPKFLG()
	{
		if (data.playerSpeed > 1521f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GUI_LEAGUEBONUS"), OBNJAIHEJOJ.FulFill);
		}
		if (data.playerSpeed < 677f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SquadWarsId"));
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF BLKCJGPKBPH()
	{
		if (data.playerSpeed > 1486f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_SQUADISALREADYFULL"), OBNJAIHEJOJ.InfoText);
		}
		if (data.playerSpeed < 1329f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\""), OBNJAIHEJOJ.FulFill);
		}
		return base.EPEIMHECJHK();
	}
}
