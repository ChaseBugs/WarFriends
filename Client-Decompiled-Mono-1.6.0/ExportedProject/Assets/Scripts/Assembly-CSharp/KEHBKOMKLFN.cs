using System.Runtime.CompilerServices;

public class KEHBKOMKLFN : WeaponFeature
{
	public override string name
	{
		get
		{
			return Localization.Localize("ID_FEATURE_MAGAZINE");
		}
	}

	public override string fancyName
	{
		get
		{
			return Localization.Localize("ID_FEATURE_MAGAZINE-FANCY");
		}
	}

	public override string icon
	{
		get
		{
			return "menu-army-ammo-ico";
		}
	}

	public override bool menuMainAtlas
	{
		get
		{
			return false;
		}
	}

	public override string description
	{
		get
		{
			return Localization.Localize("ID_FEATURE_MAGAZINE-DESCRIPTION");
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
			return Localization.Localize("ID_FEATURE_MAGAZINE-WEAPONPREFIX");
		}
	}

	public override float clipSizeCoef
	{
		get
		{
			return 1f + (float)base.value;
		}
	}

	[SpecialName]
	public virtual string IAEIIHBAJBP()
	{
		return Localization.Localize("_AccountLoginError(");
	}

	public virtual string EGDHOIFOADA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual string DGFBOCCJJFN()
	{
		return Localization.Localize("dataEnabled");
	}

	[SpecialName]
	public virtual string MIANMFIEBBH()
	{
		return Localization.Localize("$10-$20");
	}

	[SpecialName]
	public virtual string KIJPFMCCDIH()
	{
		return Localization.Localize("menu-sidetab-challenge");
	}

	public virtual string LLPOPLKJIBB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	public virtual int DAFCDDFDDBL(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.magazineGUI != ILHEPJCFKIK.magazineGUI)
		{
			return (DDJKMDPGFPB.magazineGUI > ILHEPJCFKIK.magazineGUI) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string JIFGNKPFJNL()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string OPMDEGMEPBD()
	{
		return "menu-sidetab-player-kick";
	}

	[SpecialName]
	public virtual string GLIHENAMEHA()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string EADJGBBANIJ()
	{
		return Localization.Localize(" x ");
	}

	[SpecialName]
	public virtual string FOBLFPKMIMC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual string IACDBCGGKCL()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string NKDGJNGLIOG()
	{
		return Localization.Localize("Password");
	}

	public virtual string AKFACFJAKOH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual string DALJHOJGOMO()
	{
		return "menu-assignments-type-cards";
	}

	public virtual string GABMNBOJBAD(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual string AMBPKBALDFA()
	{
		return Localization.Localize("Deploys_Count");
	}

	[SpecialName]
	public virtual string NGCCNDOBFLL()
	{
		return "ID_STAT_WINLOSSRATIO";
	}

	[SpecialName]
	public virtual string KIMGHDOBBCK()
	{
		return "shotReal";
	}

	[SpecialName]
	public virtual string LIOEMAPGFAP()
	{
		return Localization.Localize("ID_STAT_MAXMEDALSGAINED");
	}

	[SpecialName]
	public virtual string NELCHBPACLC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string OLNKEAGJEMH()
	{
		return Localization.Localize("ID_REWARD");
	}

	public virtual int JEEBLPMALLK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.magazineGUI != ILHEPJCFKIK.magazineGUI)
		{
			return (DDJKMDPGFPB.magazineGUI > ILHEPJCFKIK.magazineGUI) ? 1 : (-1);
		}
		return 0;
	}

	public virtual string PJKKMHJHKOB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual float KCECBEMJIHN()
	{
		return 341f + (float)base.value;
	}

	public virtual int AHBABJCDING(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.magazineGUI != ILHEPJCFKIK.magazineGUI)
		{
			return (DDJKMDPGFPB.magazineGUI <= ILHEPJCFKIK.magazineGUI) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual string MBEMHDEDNLF()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string BDONDLCOLJE()
	{
		return "offerType";
	}

	[SpecialName]
	public virtual string MJEKDAHELPI()
	{
		return "purchaseToken";
	}

	[SpecialName]
	public virtual string FFMOKGHPLJK()
	{
		return "PlayerId";
	}

	[SpecialName]
	public virtual string NONDJAMJFDH()
	{
		return Localization.Localize("Not sending error about error message to database.");
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.magazineGUI != ILHEPJCFKIK.magazineGUI)
		{
			return (DDJKMDPGFPB.magazineGUI > ILHEPJCFKIK.magazineGUI) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string PANOOIPIGFD()
	{
		return Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARDPACK");
	}

	[SpecialName]
	public virtual string FJMGKDLILDH()
	{
		return Localization.Localize("ID_GUI_RATEWFNOW_DESC");
	}

	[SpecialName]
	public virtual string ENGLHENAHMI()
	{
		return Localization.Localize("ID_INGOLD2");
	}

	public virtual string GFOHBCGGOAA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual string KDINHDMDGIG()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string BOFMALCLIMP()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	public virtual string DNEFIADHLBB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual string CEFBOMFAPMG()
	{
		return Localization.Localize("Clear players");
	}

	[SpecialName]
	public virtual string MGIEIKLHILA()
	{
		return Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARD");
	}

	[SpecialName]
	public virtual bool GBPLPLHBFHO()
	{
		return false;
	}

	[SpecialName]
	public virtual string GEFMJAAHMFG()
	{
		return Localization.Localize("player_look_left");
	}

	[SpecialName]
	public virtual string GDCJHKLNENL()
	{
		return "Buy_Units";
	}

	[SpecialName]
	public virtual string PPBBGIKFGNC()
	{
		return "addPowerbandTime";
	}

	[SpecialName]
	public virtual string MHFAOAHLMBE()
	{
		return Localization.Localize("Effect light has to be attached to gameobject with a particle system component or to a gameobject whos parent has a particle system component.");
	}

	[SpecialName]
	public virtual bool POIHJGJAFPN()
	{
		return false;
	}

	[SpecialName]
	public virtual string DJBKLONGLPJ()
	{
		return Localization.Localize("C1");
	}

	[SpecialName]
	public virtual float NCLJODHLNON()
	{
		return 750f + (float)base.value;
	}

	public virtual string BAIBMLCIPFC(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.MAGANIIGHON(JMMJHCOKCGG.magazineGUI);
	}

	[SpecialName]
	public virtual string HAFELEJJBJM()
	{
		return Localization.Localize("GoldExpCoefficient");
	}

	[SpecialName]
	public virtual string NNBPHOHNDJN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string NGBDLLLPBDB()
	{
		return Localization.Localize("(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V");
	}

	[SpecialName]
	public virtual string OKKPDHECLGG()
	{
		return "ID_AFFECTEDOWNUNITS";
	}

	[SpecialName]
	public virtual string NAGMHGGPJOE()
	{
		return Localization.Localize("Update of experience\t\t{0} -> {1}\t\t diff {2}, game rewards XP total {3}");
	}

	[SpecialName]
	public virtual string PEIKMGAPPFG()
	{
		return Localization.Localize("ID_SQUADSIZEINCREASEATSQUADRANK");
	}

	[SpecialName]
	public virtual string ONJBEOKCDBC()
	{
		return Localization.Localize("open");
	}

	[SpecialName]
	public virtual string PBJAEOADBGD()
	{
		return Localization.Localize("RunningOut");
	}

	public virtual int LGNKCMADGBN(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.magazineGUI != ILHEPJCFKIK.magazineGUI)
		{
			return (DDJKMDPGFPB.magazineGUI <= ILHEPJCFKIK.magazineGUI) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string PFEOGMKOMLI()
	{
		return Localization.Localize("LootboxType");
	}

	[SpecialName]
	public virtual float FEHBPFEJHFH()
	{
		return 577f + (float)base.value;
	}

	[SpecialName]
	public virtual float JJCOAJMLNOI()
	{
		return 1602f + (float)base.value;
	}

	public virtual int KHDIPDLDAFO(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.magazineGUI != ILHEPJCFKIK.magazineGUI)
		{
			return (DDJKMDPGFPB.magazineGUI > ILHEPJCFKIK.magazineGUI) ? 1 : (-1);
		}
		return 1;
	}
}
