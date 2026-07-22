using System.Runtime.CompilerServices;

public class OLMNPIGEKJD : WeaponFeature
{
	public override string name => Localization.Localize("ID_FEATURE_AMMO");

	public override string fancyName => Localization.Localize("ID_FEATURE_AMMO-FANCY");

	public override string icon => "menu-weaponstats-totalammo";

	public override string description => Localization.Localize("ID_FEATURE_AMMO-DESCRIPTION");

	public override string statisticIncrease => MEJMLNDFDBP.DPAFFLMAFJG(base.value);

	public override string weaponPrefix => Localization.Localize("ID_FEATURE_AMMO-WEAPONPREFIX");

	public override float ammoCoef => 1f + (float)base.value;

	[SpecialName]
	public virtual string NGBDLLLPBDB()
	{
		return Localization.Localize("Play_Card_Tutorial");
	}

	[SpecialName]
	public virtual string BJMDFPLBNIA()
	{
		return Localization.Localize("ID_ARENALOSSREWARD");
	}

	public virtual string GPEHMMAMPCC(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	public virtual int LCJKLAHCGHG(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo > ILHEPJCFKIK.totalAmmo) ? 1 : (-1);
		}
		return 1;
	}

	[SpecialName]
	public virtual string APBIIOFPPGJ()
	{
		return Localization.Localize("0");
	}

	[SpecialName]
	public virtual string IHLMMJHHEAC()
	{
		return Localization.Localize("ArmyPower");
	}

	[SpecialName]
	public virtual string LPFFKPBFLIP()
	{
		return Localization.Localize("customFloat");
	}

	[SpecialName]
	public virtual string DJDLDNNHFNG()
	{
		return Localization.Localize("CONFIRM");
	}

	public virtual string EPJFJHKDACP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	public virtual string KANKAJODFIF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	[SpecialName]
	public virtual string HNJAJEBEFDM()
	{
		return "RIPROVA";
	}

	[SpecialName]
	public virtual string DDIMLOOCJCN()
	{
		return "ID_MOBCRUSH";
	}

	[SpecialName]
	public virtual string PGMONBBADOP()
	{
		return Localization.Localize("#VAVRO# Daily Mission Screen - NO MISSIONS!");
	}

	[SpecialName]
	public virtual float NJIGOOCKIDD()
	{
		return 1868f + (float)base.value;
	}

	[SpecialName]
	public virtual string ILPEFOEMOGG()
	{
		return Localization.Localize("Null cannot be saved as last weapon.");
	}

	[SpecialName]
	public virtual string FNDEIGGLOCL()
	{
		return Localization.Localize("2 RATE APP REMINDER\tLast game won: True\tVersion: {0}\tShown Times in this version: {1}/{2}\tTotal ranked wins: {3}?={4}\tIs level up: {5}\tLevel: {6}?={7}/{8}\tAfter update: {9}");
	}

	[SpecialName]
	public virtual string EADJGBBANIJ()
	{
		return Localization.Localize("Wins");
	}

	public virtual int JAKNMPJDPNK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo <= ILHEPJCFKIK.totalAmmo) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual string JOHKPOOMLIF()
	{
		return Localization.Localize("null");
	}

	[SpecialName]
	public virtual float BBOPCLHPPLM()
	{
		return 1359f + (float)base.value;
	}

	[SpecialName]
	public virtual string PLNJCFONBFC()
	{
		return Localization.Localize("getPowerHookExperimentDetails");
	}

	[SpecialName]
	public virtual string KDINHDMDGIG()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string FJGEACFGDFA()
	{
		return Localization.Localize("Medals requirement = ");
	}

	public virtual int KLNPHFPAPIP(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo <= ILHEPJCFKIK.totalAmmo) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string BDNEGHIGIHC()
	{
		return Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE");
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	public virtual string DFGKMHNKIOF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	[SpecialName]
	public virtual string EFJPCJAOHJA()
	{
		return Localization.Localize("Battle_length");
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo > ILHEPJCFKIK.totalAmmo) ? 1 : (-1);
		}
		return 0;
	}

	public virtual int DDIEKAJJPJO(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo <= ILHEPJCFKIK.totalAmmo) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual string NHEIJDECPJK()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string KPKHIIMMLDD()
	{
		return "LevelManager: Awake registering events";
	}

	[SpecialName]
	public virtual string DGDCHCPGGLD()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string CLJJEINCPOP()
	{
		return "S";
	}

	[SpecialName]
	public virtual string BCFCKKKIADL()
	{
		return Localization.Localize("No main position was set in map definition");
	}

	[SpecialName]
	public virtual string NKFLGIKBHKL()
	{
		return "getFriendsList";
	}

	public virtual int GMPCHKDNBKI(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo <= ILHEPJCFKIK.totalAmmo) ? (-1) : 0;
		}
		return 0;
	}

	public virtual string AECOKANGPIE(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	public virtual int DDCKBKMDEKN(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo <= ILHEPJCFKIK.totalAmmo) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string NMCOGOIODFC()
	{
		return Localization.Localize("Rank_Up");
	}

	[SpecialName]
	public virtual string JFOFBLDDDEN()
	{
		return Localization.Localize("ID_REMEMBERYOUCANSUBMITXVIDEOS");
	}

	[SpecialName]
	public virtual string DAJPOIGDKMH()
	{
		return Localization.Localize("AgainstOtherPlatform");
	}

	public virtual string FBJHGCMHFNP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	public virtual string FICHBLJBCPF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	[SpecialName]
	public virtual string FHCNKEMDICB()
	{
		return "Assignment: DestroyEnemyCratesAssignment Constructor";
	}

	[SpecialName]
	public virtual string KEMLBBJMNGN()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string GDGFNKAEGEL()
	{
		return "BuddyCard_";
	}

	[SpecialName]
	public virtual string PIOHNCLNAAL()
	{
		return Localization.Localize("ID_VETERANPACK");
	}

	public virtual string HEHAHNEBAFA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	[SpecialName]
	public virtual string ALBOHHNCNOM()
	{
		return Localization.Localize("menu-health-ico");
	}

	[SpecialName]
	public virtual string PONENGFDAAC()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string DDGNHMNOKGG()
	{
		return Localization.Localize("YES");
	}

	[SpecialName]
	public virtual string GDPEAPJJDLF()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual float GPBKNNDNPFE()
	{
		return 572f + (float)base.value;
	}

	[SpecialName]
	public virtual string EIBIIHIDDKG()
	{
		return Localization.Localize("unset");
	}

	[SpecialName]
	public virtual string IKONLCMMPAH()
	{
		return Localization.Localize("603 GAME STARTED");
	}

	[SpecialName]
	public virtual string ICICIAIJPAB()
	{
		return Localization.Localize("Skipping wararena notification");
	}

	[SpecialName]
	public virtual string BMENHMEGJDF()
	{
		return Localization.Localize("ID_READYTIME");
	}

	[SpecialName]
	public virtual string IKAFBHDADND()
	{
		return Localization.Localize("[.,]*");
	}

	[SpecialName]
	public virtual float AOKHJIPHAGD()
	{
		return 1394f + (float)base.value;
	}

	[SpecialName]
	public virtual string BMNHMKAMAHP()
	{
		return Localization.Localize("unlockLevel");
	}

	public virtual int LOELHKKGKEF(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo <= ILHEPJCFKIK.totalAmmo) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual float CPMLEKHECEH()
	{
		return 1992f + (float)base.value;
	}

	public virtual int OHHCDDCBMKD(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo > ILHEPJCFKIK.totalAmmo) ? 1 : (-1);
		}
		return 1;
	}

	[SpecialName]
	public virtual string PEIKMGAPPFG()
	{
		return Localization.Localize("Warbucks");
	}

	[SpecialName]
	public virtual float FBOBGGLLIGD()
	{
		return 816f + (float)base.value;
	}

	public virtual int LOHJDGNNHOA(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.totalAmmo != ILHEPJCFKIK.totalAmmo)
		{
			return (DDJKMDPGFPB.totalAmmo <= ILHEPJCFKIK.totalAmmo) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string DJBKLONGLPJ()
	{
		return Localization.Localize("{0}{1}{2} {3}{4} {5}{6} {7}{8}");
	}

	[SpecialName]
	public virtual string FIFNAKJOPCA()
	{
		return Localization.Localize("{0} / {1}");
	}

	public virtual string LHFCLNGOOAJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	[SpecialName]
	public virtual string DIGHAKNCOFI()
	{
		return "ID_WARNING_CONNECTIONERROR";
	}

	public virtual string NNNOOCKKEIF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	[SpecialName]
	public virtual string PJNLIHAALHM()
	{
		return Localization.Localize("PaidBattles");
	}

	[SpecialName]
	public virtual string FHOIABPLIMK()
	{
		return Localization.Localize("ZoneHasVirtualGoodsOffer is false, preloading Ad.");
	}

	[SpecialName]
	public virtual string EJDBHIOHMFG()
	{
		return Localization.Localize("ID_LEAGUE4");
	}

	public virtual string GCKALMKLFHH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.totalAmmo);
	}

	[SpecialName]
	public virtual string JEKDBENPDNB()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string HIBBBEMHAJJ()
	{
		return Localization.Localize("armyPower");
	}

	[SpecialName]
	public virtual string PMCFLDDLNAD()
	{
		return Localization.Localize("ID_READYTIME");
	}

	[SpecialName]
	public virtual string DDAELIHAPKF()
	{
		return "withPublisherSub2";
	}

	[SpecialName]
	public virtual string GJENBCNFDGF()
	{
		return Localization.Localize("Sync match start time {0} photon time: {1}");
	}

	[SpecialName]
	public virtual string HFOMPKLFFHC()
	{
		return Localization.Localize("warArenaReminder");
	}

	[SpecialName]
	public virtual string ADALODLIJAG()
	{
		return Localization.Localize("ID_FREE");
	}

	[SpecialName]
	public virtual string FJDNJDGBIBA()
	{
		return Localization.Localize("{0} 00 {1}");
	}

	[SpecialName]
	public virtual string CDKFPNGIOLH()
	{
		return Localization.Localize("S");
	}

	[SpecialName]
	public virtual string AHKMNPJGFLI()
	{
		return Localization.Localize("Card_2_Played");
	}

	[SpecialName]
	public virtual string DDOBDADADJO()
	{
		return "#Mission Rewards# 5 Heroic Missions completed. Gained {0} arena tickets";
	}

	[SpecialName]
	public virtual string MMHFNHAJGCN()
	{
		return Localization.Localize("response contain VipReward");
	}

	[SpecialName]
	public virtual string LMFKIIKIIEA()
	{
		return Localization.Localize("ID_CONFIRM_NOTLEADEROFSQUAD_TEXT");
	}
}
