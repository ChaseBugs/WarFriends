using System.Runtime.CompilerServices;

public class HMPJJMGLMPM : WeaponFeature
{
	public override string name
	{
		get
		{
			return Localization.Localize("ID_FEATURE_ACCURACY");
		}
	}

	public override string fancyName
	{
		get
		{
			return Localization.Localize("ID_FEATURE_ACCURACY-FANCY");
		}
	}

	public override string icon
	{
		get
		{
			return "menu-weaponstats-accuracy";
		}
	}

	public override string description
	{
		get
		{
			return Localization.Localize("ID_FEATURE_ACCURACY-DESCRIPTION");
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
			return Localization.Localize("ID_FEATURE_ACCURACY-WEAPONPREFIX");
		}
	}

	public override float accuracyCoef
	{
		get
		{
			return 1f + (float)base.value;
		}
	}

	public virtual int GMCNPLOHEGP(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (!(DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy)) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual float GMLLPJFCLCD()
	{
		return 344f + (float)base.value;
	}

	[SpecialName]
	public virtual string CKFMCJEJNMJ()
	{
		return Localization.Localize("Exception message: ");
	}

	[SpecialName]
	public virtual string IBLINEPFJFB()
	{
		return Localization.Localize("Level");
	}

	[SpecialName]
	public virtual string EPGKBKMOOKI()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string NGCCNDOBFLL()
	{
		return "GoldExpCoefficient";
	}

	[SpecialName]
	public virtual string BEEEJFPIGCJ()
	{
		return Localization.Localize("D2");
	}

	[SpecialName]
	public virtual string KGBHICKFEBE()
	{
		return Localization.Localize("ID_UNITTYPE4-DESCRIPTION");
	}

	[SpecialName]
	public virtual string ONFJCGOILII()
	{
		return Localization.Localize("country-ukraine");
	}

	[SpecialName]
	public virtual string JIFGNKPFJNL()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual int OFGBMJEONPM(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (!(DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy)) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual string IAEIIHBAJBP()
	{
		return Localization.Localize("S");
	}

	[SpecialName]
	public virtual string NLMOCCLIEDD()
	{
		return Localization.Localize("GameLauncher.LoadMainScene");
	}

	public virtual string AKOLCONCODD(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.accuracy - JMMJHCOKCGG.baseAccuracy);
	}

	[SpecialName]
	public virtual string BMENHMEGJDF()
	{
		return Localization.Localize("Days_Since_Install");
	}

	[SpecialName]
	public virtual string CEFFPGFEPAL()
	{
		return Localization.Localize("country-noflag");
	}

	[SpecialName]
	public virtual float OPMGMNEGJGG()
	{
		return 1505f + (float)base.value;
	}

	public virtual string CKEBANPAGKE(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.accuracy - JMMJHCOKCGG.baseAccuracy);
	}

	[SpecialName]
	public virtual string GCBFEHGFOLJ()
	{
		return "Leaderboards - Squad Wars - NO INFO ABOUT SQUAD!!!!";
	}

	[SpecialName]
	public virtual string GLIHENAMEHA()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string INLLPOMLLEN()
	{
		return Localization.Localize("GameReward");
	}

	[SpecialName]
	public virtual string FIDPFBNJPEG()
	{
		return "LowLevel";
	}

	[SpecialName]
	public virtual float JFCCOAJICFP()
	{
		return 115f + (float)base.value;
	}

	[SpecialName]
	public virtual float DFFOGFBBGAF()
	{
		return 1257f + (float)base.value;
	}

	[SpecialName]
	public virtual string LJDIKLFOFCB()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string CIHBKOKGNCC()
	{
		return Localization.Localize("\tPush notification shown counter: {0}/{1}");
	}

	[SpecialName]
	public virtual string COPCNEDGBNJ()
	{
		return Localization.Localize("warArenaStart");
	}

	[SpecialName]
	public virtual string HHPMKFKELGE()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual float JKOEGEMKNOF()
	{
		return 1499f + (float)base.value;
	}

	[SpecialName]
	public virtual string EPPMHHPHHOB()
	{
		return Localization.Localize("Update of experience\t\t{0} -> {1}\t\t diff {2}, game rewards XP total {3}");
	}

	public virtual string CDIKIELEJEF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.accuracy - JMMJHCOKCGG.baseAccuracy);
	}

	[SpecialName]
	public virtual string CFIKEKFGDMD()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual string AFMNJNEGGOH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	[SpecialName]
	public virtual string KCCLBADOMBF()
	{
		return Localization.Localize("-");
	}

	public virtual int GHLOJIAIMBH(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (!(DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy)) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string LNFEJENKCPN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string EFCOHICFKEO()
	{
		return Localization.Localize("Leaderboards - Squad Wars - NO INFO ABOUT SQUAD WAR!!!!");
	}

	[SpecialName]
	public virtual string GKHLMGIPLJK()
	{
		return Localization.Localize("{0} {1}");
	}

	[SpecialName]
	public virtual string EADJGBBANIJ()
	{
		return Localization.Localize("game-elite-buff1");
	}

	public virtual int IJOPDKDGBMF(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy) ? 1 : (-1);
		}
		return 1;
	}

	[SpecialName]
	public virtual string JJPPIOALOCF()
	{
		return "Value3";
	}

	public virtual int JPDKDMGPLPC(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string IEJIICIAGHA()
	{
		return Localization.Localize("PlayWarcardsAssignment complate at: ");
	}

	public virtual int KHDIPDLDAFO(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (!(DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy)) ? (-1) : 0;
		}
		return 1;
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string HLMFODOONOD()
	{
		return "Show arena golden shield tutorial - pop-up";
	}

	public virtual string HFEFEJGHOMD(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	[SpecialName]
	public virtual string FNDEIGGLOCL()
	{
		return Localization.Localize("Play_Card_Tutorial");
	}

	[SpecialName]
	public virtual string NELCHBPACLC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual string NMDMJFHHKAM(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	[SpecialName]
	public virtual string EFNOCPODOLE()
	{
		return Localization.Localize("ID_WARSHOP_CARDPACKS");
	}

	[SpecialName]
	public virtual string POGGGLDGFIN()
	{
		return Localization.Localize("'friend'0");
	}

	public virtual string CIMNNIDNOEF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	[SpecialName]
	public virtual float HDJMEIIOIOC()
	{
		return 1547f + (float)base.value;
	}

	public virtual string JHCGFBBIGFE(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.accuracy - JMMJHCOKCGG.baseAccuracy);
	}

	[SpecialName]
	public virtual float DDKIDCBAKKC()
	{
		return 575f + (float)base.value;
	}

	public virtual int IABANGCKHOM(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy) ? 1 : (-1);
		}
		return 0;
	}

	public virtual string ECJKCPHAKBO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	public virtual string NHHPKHPCIPI(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.accuracy - JMMJHCOKCGG.baseAccuracy);
	}

	[SpecialName]
	public virtual string JDDIFOIGPMP()
	{
		return "Skipping dogtag notification";
	}

	[SpecialName]
	public virtual float JMJMLLGOCJM()
	{
		return 1312f + (float)base.value;
	}

	[SpecialName]
	public virtual string BKOKIBABBFB()
	{
		return Localization.Localize("BS: On Claim Assignment MegaReward");
	}

	public virtual string BGJABALDKGG(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	[SpecialName]
	public virtual string EAGLFFBBGGC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string IDENFABJJHJ()
	{
		return Localization.Localize("Level1");
	}

	[SpecialName]
	public virtual string EODNLLKDAEG()
	{
		return Localization.Localize("InventoryData");
	}

	public override string StatisticIncrease(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.accuracy - JMMJHCOKCGG.baseAccuracy);
	}

	[SpecialName]
	public virtual string PLJJMJDKIMH()
	{
		return Localization.Localize("EnteredLeague");
	}

	[SpecialName]
	public virtual float ELAPCCDIPPI()
	{
		return 1424f + (float)base.value;
	}

	[SpecialName]
	public virtual string LABBDAONIOJ()
	{
		return Localization.Localize("-");
	}

	public virtual string AKFACFJAKOH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	[SpecialName]
	public virtual string PHDEOONGAAA()
	{
		return Localization.Localize("country-noflag");
	}

	public virtual int AHBABJCDING(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.accuracy != ILHEPJCFKIK.accuracy)
		{
			return (DDJKMDPGFPB.accuracy > ILHEPJCFKIK.accuracy) ? 1 : (-1);
		}
		return 0;
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.accuracy);
	}

	[SpecialName]
	public virtual string KEMLBBJMNGN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string FFMOKGHPLJK()
	{
		return "SCOPE_GAMES";
	}

	[SpecialName]
	public virtual float MLJPMKNIGBA()
	{
		return 879f + (float)base.value;
	}

	[SpecialName]
	public virtual string BPKHNKKFGHP()
	{
		return Localization.Localize("ID_MEMBERS");
	}
}
