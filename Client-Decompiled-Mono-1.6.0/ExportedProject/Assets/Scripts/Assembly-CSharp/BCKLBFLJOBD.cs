using System.Runtime.CompilerServices;

public class BCKLBFLJOBD : WeaponFeature
{
	public override string name
	{
		get
		{
			return Localization.Localize("ID_FEATURE_DAMAGE");
		}
	}

	public override string fancyName
	{
		get
		{
			return Localization.Localize("ID_FEATURE_DAMAGE-FANCY");
		}
	}

	public override string icon
	{
		get
		{
			return "menu-unitstats-shotdamage";
		}
	}

	public override string description
	{
		get
		{
			return Localization.Localize("ID_FEATURE_DAMAGE-DESCRIPTION");
		}
	}

	public override string statisticIncrease
	{
		get
		{
			return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
		}
	}

	public override string weaponPrefix
	{
		get
		{
			return Localization.Localize("ID_FEATURE_DAMAGE-WEAPONPREFIX");
		}
	}

	public override float damageCoef
	{
		get
		{
			return 1f + (float)base.value;
		}
	}

	[SpecialName]
	public virtual string PFEOGMKOMLI()
	{
		return Localization.Localize("YES");
	}

	[SpecialName]
	public virtual float LPPHBEPLPKK()
	{
		return 681f + (float)base.value;
	}

	[SpecialName]
	public virtual string NCOFJBEILBB()
	{
		return Localization.Localize("game-elite-debuff3");
	}

	[SpecialName]
	public virtual string IJFCLELHBIN()
	{
		return Localization.Localize("LootboxType");
	}

	[SpecialName]
	public virtual float IHPFENAJHLL()
	{
		return 932f + (float)base.value;
	}

	[SpecialName]
	public virtual string DAJPOIGDKMH()
	{
		return Localization.Localize("End Screen - Assignment tab:\nAssignment1:\t{0}\nAssignment2:\t{1}\nAssignment3:\t{2}\n");
	}

	[SpecialName]
	public virtual string IIHOHFHODHL()
	{
		return "rd";
	}

	[SpecialName]
	public virtual string GPEPHIDGDLH()
	{
		return "ShowAdForZoneID";
	}

	[SpecialName]
	public virtual string IFDFIGBAEHJ()
	{
		return Localization.Localize("D4");
	}

	[SpecialName]
	public virtual string KLPINCKBLNM()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual string FICHBLJBCPF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string IGPJJLNAACF()
	{
		return " ";
	}

	[SpecialName]
	public virtual string BAIKLLANCHF()
	{
		return "ID_HOUR_SMALL";
	}

	[SpecialName]
	public virtual string JOGFBKGGAFD()
	{
		return Localization.Localize("YES");
	}

	[SpecialName]
	public virtual string FGCFNGGFAPJ()
	{
		return Localization.Localize("ID_TWITTER_FOLLOWING_BUTTON");
	}

	[SpecialName]
	public virtual string ABOGLCDLJBL()
	{
		return Localization.Localize("ReportType");
	}

	[SpecialName]
	public virtual string JGBJIPDLNHC()
	{
		return Localization.Localize(" 3");
	}

	[SpecialName]
	public virtual string ICHFOJBJNEL()
	{
		return "SquadId";
	}

	[SpecialName]
	public virtual string EGNJBEPIDKN()
	{
		return "Assignments_Mega_Reward_claim";
	}

	public virtual int FPBHNEENDFJ(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage) ? 1 : (-1);
		}
		return 1;
	}

	[SpecialName]
	public virtual string PPBBGIKFGNC()
	{
		return "category";
	}

	[SpecialName]
	public virtual string CFHGCOKIKAK()
	{
		return "BuddyCardData";
	}

	[SpecialName]
	public virtual string DICFDLCOLIK()
	{
		return Localization.Localize("Player_Level");
	}

	public virtual string BLCLMIEFBOD(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	public virtual int LAFKCAILKDF(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string ACOOKCGAFGE()
	{
		return Localization.Localize("set weapon not borrowed");
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string APMBGMOCGIN()
	{
		return "fr";
	}

	[SpecialName]
	public virtual float CMJLEPAAALA()
	{
		return 325f + (float)base.value;
	}

	[SpecialName]
	public virtual string LMMFLPGODNF()
	{
		return Localization.Localize("ID_MISSION_KILL_HUD");
	}

	[SpecialName]
	public virtual float CPGICHODICA()
	{
		return 1023f + (float)base.value;
	}

	[SpecialName]
	public virtual string PANCCHFGCAJ()
	{
		return Localization.Localize("ID_PVP_BATTLE");
	}

	[SpecialName]
	public virtual string AINLHFEPMBC()
	{
		return Localization.Localize("leagueMedalsDiff");
	}

	[SpecialName]
	public virtual float MFBPHKKAHBI()
	{
		return 1234f + (float)base.value;
	}

	[SpecialName]
	public virtual string CAEOBMJHIEI()
	{
		return Localization.Localize("Card ID \"{0}\" is not pressent in card dictionary.");
	}

	[SpecialName]
	public virtual string AACBOPIFBGH()
	{
		return Localization.Localize("GameControllerCampaign.StartGame START");
	}

	[SpecialName]
	public virtual string HNCAHKAJHLE()
	{
		return "InstantiatePooledObjects ";
	}

	[SpecialName]
	public virtual string EKJJJJBPHMK()
	{
		return Localization.Localize("ID_TUTORIAL_KILLING2");
	}

	[SpecialName]
	public virtual string ANNNJOIJMKE()
	{
		return Localization.Localize(" 1\u00a0{0}");
	}

	public virtual int OOFKACGIBAK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (!(DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage)) ? (-1) : 0;
		}
		return 0;
	}

	public virtual string PNGJIOHBADA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string CIGALPDDHHI()
	{
		return Localization.Localize("Render player texture ERROR: Weapon load failed! (timeouted - 5 sec)");
	}

	[SpecialName]
	public virtual string BIJKOEGEMBD()
	{
		return "ID_GETFORNUMBERONE1";
	}

	public virtual int KDHGBFHMFFF(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (!(DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage)) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual string HHPNKHBHCJC()
	{
		return Localization.Localize("data.slots doesnt contain: ");
	}

	[SpecialName]
	public virtual string BJMDFPLBNIA()
	{
		return Localization.Localize("menu-powerband-health-ico");
	}

	[SpecialName]
	public virtual string PFMDPNBLBLK()
	{
		return Localization.Localize("InfluencerAlias");
	}

	[SpecialName]
	public virtual string JIFGNKPFJNL()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string HDOIEIDAAEE()
	{
		return Localization.Localize("ArmyPower");
	}

	[SpecialName]
	public virtual string NILFGEKIHFN()
	{
		return Localization.Localize("Skipping next withdraw basecause player left squad");
	}

	[SpecialName]
	public virtual string PHPMHEBBCEN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string MGAFIAEJLOA()
	{
		return Localization.Localize("#Notifications# registering {0} with name {1}\n{2}");
	}

	public virtual int KLNPHFPAPIP(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (!(DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage)) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual float FDKKHPHGAMM()
	{
		return 1054f + (float)base.value;
	}

	public virtual string DAPJLDCKDJB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string CLJJEINCPOP()
	{
		return "ChillingoSdkManager";
	}

	[SpecialName]
	public virtual string NHEIJDECPJK()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string GJLLNFBHPDL()
	{
		return Localization.Localize("resultMessage");
	}

	[SpecialName]
	public virtual string HBPCCEDFFEB()
	{
		return Localization.Localize("NEW CONFIG WILL BE LOADED FROM PREFS:");
	}

	[SpecialName]
	public virtual string JDHPKINPHKP()
	{
		return " NOT OK!\t\t\t\t\t\t";
	}

	public virtual string LHFCLNGOOAJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	public virtual int ALIEEADLKGK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (!(DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage)) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string IFBBHKIOCCJ()
	{
		return Localization.Localize("ID_SKILLSHOTHINT_ONTHEMOVE");
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string GBHGKBFIGOF()
	{
		return Localization.Localize("ID_MATCH_STARTS_IN");
	}

	[SpecialName]
	public virtual string PDPICPEFOEF()
	{
		return Localization.Localize("QUIT");
	}

	[SpecialName]
	public virtual string DJKFCIGEBGH()
	{
		return "Reward";
	}

	[SpecialName]
	public virtual string MGHHEFEJIMA()
	{
		return Localization.Localize("[]");
	}

	[SpecialName]
	public virtual string DIGHAKNCOFI()
	{
		return "{0} {1}{2}";
	}

	[SpecialName]
	public virtual string AMDHOEAEMPO()
	{
		return Localization.Localize(" ");
	}

	public virtual string LLPOPLKJIBB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	public virtual string AGNPEMIOEIF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string JEFNKBLCDNN()
	{
		return "WonBattles";
	}

	[SpecialName]
	public virtual string FNDEIGGLOCL()
	{
		return Localization.Localize("sniper_reload");
	}

	[SpecialName]
	public virtual float OJGMCGGOBFC()
	{
		return 1302f + (float)base.value;
	}

	[SpecialName]
	public virtual float BFCDPDAEABL()
	{
		return 215f + (float)base.value;
	}

	public virtual string ECJKCPHAKBO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string BDAKJFGNKGC()
	{
		return Localization.Localize("{0} Aa Tier {0}");
	}

	[SpecialName]
	public virtual string KHHDNAKMLDC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual float BFGIGCACINJ()
	{
		return 816f + (float)base.value;
	}

	[SpecialName]
	public virtual string OIFEOMOKLIB()
	{
		return Localization.Localize("-{0}");
	}

	[SpecialName]
	public virtual string DCBEOGCCOOE()
	{
		return Localization.Localize("FinishedAssignments:");
	}

	public virtual string FLKHAGCPIHE(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string JEKDBENPDNB()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual float NJHHDPFKKBN()
	{
		return 1045f + (float)base.value;
	}

	[SpecialName]
	public virtual string BKOKIBABBFB()
	{
		return Localization.Localize("ID_DAILYMISSIONX");
	}

	public virtual string NMDMJFHHKAM(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	public virtual string LEPBOCNPCJP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual string JCLDEAONIAM()
	{
		return Localization.Localize("The shader ");
	}

	[SpecialName]
	public virtual string FHOIABPLIMK()
	{
		return Localization.Localize("AR");
	}

	[SpecialName]
	public virtual string CGJANNNPMCM()
	{
		return Localization.Localize("Reward {0:D2}");
	}

	public virtual int DINOOOBPAFM(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.shotDamage != ILHEPJCFKIK.shotDamage)
		{
			return (!(DDJKMDPGFPB.shotDamage > ILHEPJCFKIK.shotDamage)) ? (-1) : 0;
		}
		return 0;
	}

	public virtual string OLDGJFJEENN(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	public virtual string GCKALMKLFHH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAJBCINJAGF(JMMJHCOKCGG.shotDamage);
	}

	[SpecialName]
	public virtual float BOHDIPDNLCN()
	{
		return 631f + (float)base.value;
	}

	[SpecialName]
	public virtual string DJDNLAHKBMM()
	{
		return Localization.Localize("ReSyncDisabledRPC");
	}

	[SpecialName]
	public virtual string CLMJKOCCNJG()
	{
		return Localization.Localize("RETRY");
	}

	[SpecialName]
	public virtual string GLDLMNIDIHG()
	{
		return Localization.Localize("newHeroicPoints");
	}

	[SpecialName]
	public virtual string KLMIHMJCAEE()
	{
		return Localization.Localize("BotCards");
	}

	[SpecialName]
	public virtual string HDJGEGHFPOJ()
	{
		return Localization.Localize("smallURL");
	}

	[SpecialName]
	public virtual string EFHBFLBIOMF()
	{
		return "menu-army-cat-rusher";
	}

	[SpecialName]
	public virtual string IDFKNGAPLCA()
	{
		return Localization.Localize("ID_ELITEUNITNAME");
	}

	[SpecialName]
	public virtual float FFJEKEKIEII()
	{
		return 1641f + (float)base.value;
	}

	[SpecialName]
	public virtual string IHCLJIHDEIB()
	{
		return Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC");
	}

	[SpecialName]
	public virtual string OKBDGBLEIPN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string DDIMLOOCJCN()
	{
		return "monoMem";
	}

	[SpecialName]
	public virtual string MPBJBJKHMKK()
	{
		return Localization.Localize("hasNext");
	}
}
