using System.Runtime.CompilerServices;

public class JOMIECOADEB : WeaponFeature
{
	public override string name => Localization.Localize("ID_FEATURE_BURSTSIZE");

	public override string fancyName => Localization.Localize("ID_FEATURE_BURSTSIZE-FANCY");

	public override string icon => "menu-weaponstats-burstsize";

	public override string description => Localization.Localize("ID_FEATURE_BURSTSIZE-DESRIPTION");

	public override string statisticIncrease => MEJMLNDFDBP.AKEMDPDJPLH(base.value);

	public override string weaponPrefix => Localization.Localize("ID_FEATURE_BURSTSIZE-WEAPONPREFIX");

	public override int burstAdd => (int)(float)base.value;

	[SpecialName]
	public virtual string PEMJGAHGHFG()
	{
		return Localization.Localize("You probably assigned bad type of AmmoSetup to gun");
	}

	[SpecialName]
	public virtual string OOJNBFGEGME()
	{
		return Localization.Localize("SetAngle");
	}

	[SpecialName]
	public virtual string DDBOKNGIIJO()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 1936f);
	}

	public virtual string IAOMOHIEOHK(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string HBIPPPOMGMM()
	{
		return Localization.Localize("Player no longer in squad!");
	}

	[SpecialName]
	public virtual string JIFGNKPFJNL()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 1682f);
	}

	public virtual string FBJHGCMHFNP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string NEGJKDFMFAF()
	{
		return Localization.Localize("Awake '{0}'");
	}

	[SpecialName]
	public virtual string CFIKEKFGDMD()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 731f);
	}

	[SpecialName]
	public virtual string AIPNGAFIJEF()
	{
		return Localization.Localize("REGISTER VIEW STARTER ASSIGNMENT ");
	}

	[SpecialName]
	public virtual string PCDCKGGLBMF()
	{
		return "CustomizationTutorialMessage";
	}

	[SpecialName]
	public virtual string EJBEDABFGDG()
	{
		return "Pause status: {0}, WantedTimeScale: {1}, TimeScale: {2}, Freezed:  {3}";
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize > ILHEPJCFKIK.burstSize) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string MACEIABIHKP()
	{
		return Localization.Localize("), ");
	}

	[SpecialName]
	public virtual string CGCEEBCGCFH()
	{
		return Localization.Localize("ID_HEROICMISSIONS1");
	}

	[SpecialName]
	public virtual string DDGNHMNOKGG()
	{
		return Localization.Localize("null");
	}

	[SpecialName]
	public virtual string NAAJDJDKLDD()
	{
		return Localization.Localize("getDaysSinceLastPlayed");
	}

	[SpecialName]
	public virtual string KJPPOAIIFNO()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 231f);
	}

	public virtual string GFOHBCGGOAA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual int KPMGAHIIJOK()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string JADEGBBIKHK()
	{
		return Localization.Localize(" set beginners league ");
	}

	[SpecialName]
	public virtual int OPLGHNCFAHC()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string PEIKMGAPPFG()
	{
		return Localization.Localize("VisualType");
	}

	[SpecialName]
	public virtual int OGEHLMOLDFO()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual int MOKOBGKJLPH()
	{
		return (int)(float)base.value;
	}

	public virtual string LDLFLALBGKK(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string LHMOCDFMKPE()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 419f);
	}

	[SpecialName]
	public virtual string KCOPNOBOFNB()
	{
		return Localization.Localize("Direct");
	}

	public virtual int LCJKLAHCGHG(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize > ILHEPJCFKIK.burstSize) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string EFNOCPODOLE()
	{
		return Localization.Localize("count");
	}

	[SpecialName]
	public virtual string IENFENJHEIM()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 1635f);
	}

	[SpecialName]
	public virtual string EMICNMMNBIG()
	{
		return Localization.Localize("ID_MISSIONANIMATION_BOSSWAVEIN");
	}

	[SpecialName]
	public virtual int PJGCEAIHPGO()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string JKFGPBBMDKK()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 1184f);
	}

	[SpecialName]
	public virtual string PFIBJDFFKEG()
	{
		return Localization.Localize("en-US");
	}

	public virtual int JPDKDMGPLPC(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize <= ILHEPJCFKIK.burstSize) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual int KJPIBFIEDLB()
	{
		return (int)(float)base.value;
	}

	public virtual string LGIKEMEOCJN(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual int EFCNBGHNDIM()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string LHEBLNBHHHA()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 1151f);
	}

	public virtual int JBJODEPEFGA(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize > ILHEPJCFKIK.burstSize) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string GHJLPMPBMOI()
	{
		return "SquadId";
	}

	public virtual string DOLDBEFGDBH(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	public virtual string JLHHJHGGODO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string BELJOLMBEPG()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 278f);
	}

	[SpecialName]
	public virtual string HBPCCEDFFEB()
	{
		return Localization.Localize("warArenaCrown");
	}

	public virtual string BPECFDCJCHN(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string ACOOKCGAFGE()
	{
		return Localization.Localize("Error parsing Fuseboxx configuration. Key = ");
	}

	[SpecialName]
	public virtual string EAGLFFBBGGC()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 268f);
	}

	[SpecialName]
	public virtual string HLBAJGPAHMI()
	{
		return Localization.Localize("BoughtIndex");
	}

	public virtual int AKJFHEEBOIC(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize > ILHEPJCFKIK.burstSize) ? 1 : (-1);
		}
		return 1;
	}

	public virtual int IJOPDKDGBMF(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize <= ILHEPJCFKIK.burstSize) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual int BOGDCCPLMPH()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string PANCCHFGCAJ()
	{
		return Localization.Localize(" pass: ");
	}

	public virtual string MHGHJPNPDAL(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string BCFCKKKIADL()
	{
		return Localization.Localize("BattleId");
	}

	[SpecialName]
	public virtual string HIAFMLENKCB()
	{
		return Localization.Localize("ID_CONFIRM_INAPP_FAILED");
	}

	[SpecialName]
	public virtual string CJNEFNNOAIN()
	{
		return Localization.Localize("Fuseboxx: Add Did Show networkId: {0} mediaType: {1}");
	}

	[SpecialName]
	public virtual string IBCHHANJMKL()
	{
		return Localization.Localize(" was activated (through fast activation).");
	}

	[SpecialName]
	public virtual string GBHGKBFIGOF()
	{
		return Localization.Localize("#AccoutCheck# GoogleLoggedIn tutorial - wrong situation -> do nothing");
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string KBNELGGPDKE()
	{
		return Localization.Localize("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERING\t\tbutton type: DELIVER NOW");
	}

	public virtual int JHOBDBPGDHG(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize > ILHEPJCFKIK.burstSize) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string OIAGLGFLOFH()
	{
		return Localization.Localize("Sand");
	}

	[SpecialName]
	public virtual string IGIJEBKBPII()
	{
		return Localization.Localize("Vip");
	}

	[SpecialName]
	public virtual string FENHDGOEFMG()
	{
		return Localization.Localize("You probably assigned bad type of AmmoSetup to gun");
	}

	[SpecialName]
	public virtual string EKAMEPKEIDK()
	{
		return Localization.Localize("ID_SLOTUPGRADE_DAMAGE");
	}

	[SpecialName]
	public virtual string ELJDAELLMCO()
	{
		return Localization.Localize("fake-division");
	}

	[SpecialName]
	public virtual string PKCGGJCMCNO()
	{
		return Localization.Localize("Current Locale unity = ");
	}

	[SpecialName]
	public virtual string HAMHLNLGFGD()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 500f);
	}

	[SpecialName]
	public virtual int OEHIFELJHKN()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string MFGCLJLJCOA()
	{
		return "ID_PLAYERIDNUMBER";
	}

	[SpecialName]
	public virtual int EMBMCJGJCKF()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual int EICIAPPOGPH()
	{
		return (int)(float)base.value;
	}

	public virtual int IABANGCKHOM(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize > ILHEPJCFKIK.burstSize) ? 1 : (-1);
		}
		return 1;
	}

	[SpecialName]
	public virtual string LNGJNNCJBCN()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 824f);
	}

	[SpecialName]
	public virtual int NBDNHKHIMAF()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string HFLGNDBNMAD()
	{
		return "Name";
	}

	[SpecialName]
	public virtual string IOPIAPEBAOE()
	{
		return Localization.Localize("ID_NEWASSIGNMENTIN");
	}

	[SpecialName]
	public virtual string NCOFJBEILBB()
	{
		return Localization.Localize("ID_BLACKMARKETLEFTTEXT2");
	}

	public virtual int FKCDCDFADGE(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize > ILHEPJCFKIK.burstSize) ? 1 : (-1);
		}
		return 1;
	}

	[SpecialName]
	public virtual string OKKPDHECLGG()
	{
		return "CardId";
	}

	[SpecialName]
	public virtual string CGDNPOLJLJO()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 1865f);
	}

	[SpecialName]
	public virtual int POADEKMGHBI()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual int BHNLJDGGNDB()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string MDLEEMEJPAC()
	{
		return Localization.Localize("ID_OK");
	}

	public virtual string BLCLMIEFBOD(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	public virtual int LOHJDGNNHOA(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize <= ILHEPJCFKIK.burstSize) ? (-1) : 0;
		}
		return 1;
	}

	[SpecialName]
	public virtual int IEGBKGIKKEB()
	{
		return (int)(float)base.value;
	}

	public virtual string DNEFIADHLBB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string KCBLIKMGDCB()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 294f);
	}

	public virtual int DDIEKAJJPJO(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize <= ILHEPJCFKIK.burstSize) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string BOMELBMBCIB()
	{
		return "ID_TUTORIAL_FORGOT_SPAWN_UP";
	}

	[SpecialName]
	public virtual string BFBDCCHJCHB()
	{
		return Localization.Localize("DailyMissionsCompletionRewardScraps");
	}

	public virtual string MBDCPACDHBI(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual string DNHPLLKACKF()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 696f);
	}

	[SpecialName]
	public virtual int EPMANPGLLMP()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string HHKJLMAAOBC()
	{
		return Localization.Localize("Some error occurred. Please, try again later.");
	}

	[SpecialName]
	public virtual string DCLJLGFKEDN()
	{
		return Localization.Localize("DamageEventPlayerShoot");
	}

	[SpecialName]
	public virtual string NONDJAMJFDH()
	{
		return Localization.Localize("WarFriends");
	}

	[SpecialName]
	public virtual string IDFKNGAPLCA()
	{
		return Localization.Localize("No connection.");
	}

	[SpecialName]
	public virtual string BOGMMFKKIOE()
	{
		return Localization.Localize("ID_SEARCHRESULTSFOR");
	}

	public virtual int IMBMKLMAFHK(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.burstSize != ILHEPJCFKIK.burstSize)
		{
			return (DDJKMDPGFPB.burstSize <= ILHEPJCFKIK.burstSize) ? (-1) : 0;
		}
		return 0;
	}

	[SpecialName]
	public virtual string CCHDMKIPMNL()
	{
		return Localization.Localize("arenaLeaderboard");
	}

	[SpecialName]
	public virtual string EGNJBEPIDKN()
	{
		return "ACD: Memory was tampered, cheater detected!";
	}

	public virtual string OIMGJIOCMDF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	public virtual string IDMPCDNGHHL(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.burstSize);
	}

	[SpecialName]
	public virtual int GANFPHAEKDG()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual int IEKMPOFGLKB()
	{
		return (int)(float)base.value;
	}

	[SpecialName]
	public virtual string PEDLKGELFFA()
	{
		return Localization.Localize("Sessions");
	}

	[SpecialName]
	public virtual string NFLKEMFBLAP()
	{
		return MEJMLNDFDBP.AKEMDPDJPLH(base.value, 645f);
	}
}
