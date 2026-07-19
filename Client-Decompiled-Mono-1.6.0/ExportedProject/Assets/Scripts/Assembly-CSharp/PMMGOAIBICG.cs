using System.Runtime.CompilerServices;

public class PMMGOAIBICG : WeaponFeature
{
	public override string name
	{
		get
		{
			return Localization.Localize("ID_FEATURE_CRITICAL");
		}
	}

	public override string fancyName
	{
		get
		{
			return Localization.Localize("ID_FEATURE_CRITICAL-FANCY");
		}
	}

	public override string icon
	{
		get
		{
			return "menu-weaponstats-criticalchance";
		}
	}

	public override string description
	{
		get
		{
			return Localization.Localize("ID_FEATURE_CRITICAL-DESCRIPTION");
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
			return Localization.Localize("ID_FEATURE_CRITICAL-WEAPONPREFIX");
		}
	}

	public override float criticalCoef
	{
		get
		{
			return 1f + (float)base.value;
		}
	}

	public virtual int GOEKPMABNPK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.critical != ILHEPJCFKIK.critical)
		{
			return (DDJKMDPGFPB.critical > ILHEPJCFKIK.critical) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string DNHPLLKACKF()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual string CKMMHDEMONF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.critical);
	}

	[SpecialName]
	public virtual string GLJFGHEOPJP()
	{
		return Localization.Localize("Showing squad details dialog with SQUADNAME = ");
	}

	[SpecialName]
	public virtual string ECEBFFFAIJM()
	{
		return Localization.Localize("ID_LEAGUE15");
	}

	[SpecialName]
	public virtual string MLFHKBCNAHG()
	{
		return Localization.Localize("Lcom/google/android/gms/common/api/Scope;");
	}

	[SpecialName]
	public virtual string COCEHPDNFKE()
	{
		return Localization.Localize("NO EVENT ASSIGNMENT CONFIG RECEIVED!!!");
	}

	[SpecialName]
	public virtual float JMMILICHIJF()
	{
		return 141f + (float)base.value;
	}

	[SpecialName]
	public virtual string MBEMHDEDNLF()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual string HLMGJIILCCL(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string DCLJLGFKEDN()
	{
		return Localization.Localize("D2");
	}

	[SpecialName]
	public virtual float NOPKGJMDDJJ()
	{
		return 747f + (float)base.value;
	}

	public virtual string HLNDFLKOAIM(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.critical);
	}

	[SpecialName]
	public virtual string IGGMAMDJBNB()
	{
		return Localization.Localize("grenade_idle");
	}

	[SpecialName]
	public virtual string BELJOLMBEPG()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual int IABANGCKHOM(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.critical != ILHEPJCFKIK.critical)
		{
			return (DDJKMDPGFPB.critical > ILHEPJCFKIK.critical) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string PIMAHGPCIML()
	{
		return Localization.Localize("FacebookId");
	}

	public virtual string PCEAAHBJKPI(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string ELFBIDJAFML()
	{
		return "FeaturedVideos";
	}

	public override string StatisticIncrease(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string AKDEGDMJIPO()
	{
		return Localization.Localize("VipReward1");
	}

	public virtual string PIIKDAGCAIO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string ALDIHGNBBED()
	{
		return Localization.Localize("VipReward1");
	}

	[SpecialName]
	public virtual string OPMDEGMEPBD()
	{
		return "menu-button-small";
	}

	public virtual int ALIEEADLKGK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.critical != ILHEPJCFKIK.critical)
		{
			return (!(DDJKMDPGFPB.critical > ILHEPJCFKIK.critical)) ? (-1) : 0;
		}
		return 0;
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.critical);
	}

	public virtual string CDIKIELEJEF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string PANOOIPIGFD()
	{
		return Localization.Localize("\"NEGINFINITY\"");
	}

	public virtual string HFEFEJGHOMD(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.critical);
	}

	[SpecialName]
	public virtual string DDGNHMNOKGG()
	{
		return Localization.Localize("Total_Gold_Spent");
	}

	[SpecialName]
	public virtual string LPFFKPBFLIP()
	{
		return Localization.Localize("country-estonia");
	}

	[SpecialName]
	public virtual string IAEIIHBAJBP()
	{
		return Localization.Localize("ID_ERROR_SQUADNAMESHORT");
	}

	public virtual int GGOFHFDGNML(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.critical != ILHEPJCFKIK.critical)
		{
			return (!(DDJKMDPGFPB.critical > ILHEPJCFKIK.critical)) ? (-1) : 0;
		}
		return 1;
	}

	public virtual int DLJIOKMJDGK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.critical != ILHEPJCFKIK.critical)
		{
			return (DDJKMDPGFPB.critical > ILHEPJCFKIK.critical) ? 1 : (-1);
		}
		return 1;
	}

	public virtual string LLONECCPNGH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual float MPKMLFNMNDO()
	{
		return 314f + (float)base.value;
	}

	public virtual string CAJPBBOOBIJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.critical);
	}

	[SpecialName]
	public virtual float LFBCNKDKCAN()
	{
		return 394f + (float)base.value;
	}

	[SpecialName]
	public virtual string MBMDDBLCFOL()
	{
		return "ID_FEATURE_ACCURACY-WEAPONPREFIX";
	}

	[SpecialName]
	public virtual float FDHGMJCPODC()
	{
		return 1652f + (float)base.value;
	}

	public virtual string OLDGJFJEENN(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.critical);
	}

	public virtual string BGIKMIOLIMC(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual float LNAHBJDHKEC()
	{
		return 1028f + (float)base.value;
	}

	public virtual string BHOPBJLOPGK(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual float POCCPKLAJFN()
	{
		return 1093f + (float)base.value;
	}

	[SpecialName]
	public virtual string AGCDACOKJCB()
	{
		return Localization.Localize("220 NEXT TUTORIAL STARTING");
	}

	[SpecialName]
	public virtual string GJLIDPDFOJF()
	{
		return Localization.Localize("assignment");
	}

	[SpecialName]
	public virtual string AIPNGAFIJEF()
	{
		return Localization.Localize("getIsPayingUser");
	}

	[SpecialName]
	public virtual string MACEIABIHKP()
	{
		return Localization.Localize("menu-weapon-mp5-elite");
	}

	public virtual string LJGIBLIALLN(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string NMMJABOJHND()
	{
		return Localization.Localize("CardsInCardPack");
	}

	[SpecialName]
	public virtual string GCAICEOEEHC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string FJDNJDGBIBA()
	{
		return Localization.Localize("Time");
	}

	public virtual string ONBALDMCEKP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string OIFEOMOKLIB()
	{
		return Localization.Localize("squadCreationsCnt");
	}

	[SpecialName]
	public virtual float BHMPMLMEFFP()
	{
		return 295f + (float)base.value;
	}

	public virtual int NKGHBCEBLEM(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.critical != ILHEPJCFKIK.critical)
		{
			return (DDJKMDPGFPB.critical > ILHEPJCFKIK.critical) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string NNPOBBNPNCI()
	{
		return "ID_COLLECTXELITEPARTSANDUPGRADETOELITE";
	}

	[SpecialName]
	public virtual string JADEGBBIKHK()
	{
		return Localization.Localize("Warbucks");
	}

	[SpecialName]
	public virtual string JIIOJKMFCNP()
	{
		return Localization.Localize("ID_STATE_GAMEFINISHED");
	}

	public virtual string HECMKNHDKPL(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string KGBHICKFEBE()
	{
		return Localization.Localize("response contain VipReward");
	}

	[SpecialName]
	public virtual string KEMLBBJMNGN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string EFCOHICFKEO()
	{
		return Localization.Localize("DailyGoldDay");
	}

	[SpecialName]
	public virtual string JLPGKJOCDAN()
	{
		return Localization.Localize("menu-cards-bronzepack");
	}

	[SpecialName]
	public virtual string NAOMEHCLPOF()
	{
		return "ID_SKILLSHOTHINT_SLOWMOTIONKILL";
	}

	public virtual string IKMFKNLBEOA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	public virtual string BKFPAGNDIHJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string HKCGEHCLKMC()
	{
		return Localization.Localize("Scheduling notifications: ");
	}

	[SpecialName]
	public virtual string KGJIEDNENPD()
	{
		return Localization.Localize("Total_Warbucks_Earned");
	}

	[SpecialName]
	public virtual string HCHCFGENNEN()
	{
		return Localization.Localize("getTime");
	}

	[SpecialName]
	public virtual float AGDMJBLJCOD()
	{
		return 1272f + (float)base.value;
	}

	public virtual string LGIFKJEMHEI(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string JGBJIPDLNHC()
	{
		return Localization.Localize("api/");
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.critical != ILHEPJCFKIK.critical)
		{
			return (DDJKMDPGFPB.critical > ILHEPJCFKIK.critical) ? 1 : (-1);
		}
		return 0;
	}

	public virtual string HDNALBABJCL(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string ILPEFOEMOGG()
	{
		return Localization.Localize("ArmyPower");
	}

	[SpecialName]
	public virtual string JLJIAHPDBKH()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual string POJIINGCJKG(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.JJBMMICPIIG(JMMJHCOKCGG.critical);
	}

	public virtual string NFCLBOINFBO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(JMMJHCOKCGG.critical - JMMJHCOKCGG.baseCritical);
	}

	[SpecialName]
	public virtual string AINLHFEPMBC()
	{
		return Localization.Localize("MasterId");
	}

	[SpecialName]
	public virtual string IDLPMLNJMCN()
	{
		return Localization.Localize("customDate");
	}

	[SpecialName]
	public virtual string ALKNPBEINDA()
	{
		return Localization.Localize("N");
	}

	[SpecialName]
	public virtual string JEKDBENPDNB()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string NEGJKDFMFAF()
	{
		return Localization.Localize("WaitTime");
	}

	[SpecialName]
	public virtual string IDFKNGAPLCA()
	{
		return Localization.Localize("DailyGoldDay");
	}
}
