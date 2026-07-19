using System.Runtime.CompilerServices;

public class PAHHHDKNAMI : WeaponFeature
{
	public override string name
	{
		get
		{
			return Localization.Localize("ID_FEATURE_RATE");
		}
	}

	public override string fancyName
	{
		get
		{
			return Localization.Localize("ID_FEATURE_RATE-FANCY");
		}
	}

	public override string icon
	{
		get
		{
			return "menu-weaponstats-rateoffire";
		}
	}

	public override string description
	{
		get
		{
			return Localization.Localize("ID_FEATURE_RATE-DESCRIPTION");
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
			return Localization.Localize("ID_FEATURE_RATE-WEAPONPREFIX");
		}
	}

	public override float rateOfFireCoef
	{
		get
		{
			return 1f - (float)base.value;
		}
	}

	[SpecialName]
	public virtual string KINEELGAHIH()
	{
		return Localization.Localize("Message {0}");
	}

	[SpecialName]
	public virtual string FHOIABPLIMK()
	{
		return Localization.Localize("ID_YOUNEEDMONEYTOTRAINSPECIAL");
	}

	[SpecialName]
	public virtual string HHPNKHBHCJC()
	{
		return Localization.Localize("leagueMembers");
	}

	[SpecialName]
	public virtual string ENFGGECMNJI()
	{
		return MEJMLNDFDBP.DPAFFLMAFJG(base.value);
	}

	[SpecialName]
	public virtual string AACBOPIFBGH()
	{
		return Localization.Localize("D4");
	}

	public override int CompareTwoWeapons(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.rateOfFire != ILHEPJCFKIK.rateOfFire)
		{
			return (!(DDJKMDPGFPB.rateOfFire > ILHEPJCFKIK.rateOfFire)) ? 1 : (-1);
		}
		return 0;
	}

	public virtual int HGAPLJIKNEN(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.rateOfFire != ILHEPJCFKIK.rateOfFire)
		{
			return (!(DDJKMDPGFPB.rateOfFire > ILHEPJCFKIK.rateOfFire)) ? 1 : (-1);
		}
		return 0;
	}

	[SpecialName]
	public virtual string OMNFODBNIFA()
	{
		return Localization.Localize("First you must run createStructure");
	}

	[SpecialName]
	public virtual string GHJLPMPBMOI()
	{
		return "Invitations";
	}

	public override string Statistic(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.KMDFJMCIFKA(JMMJHCOKCGG.rateOfFirePerMinute);
	}

	[SpecialName]
	public virtual string JOHKPOOMLIF()
	{
		return Localization.Localize("ID_MINAGO");
	}

	public virtual string LHFCLNGOOAJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		return MEJMLNDFDBP.KMDFJMCIFKA(JMMJHCOKCGG.rateOfFirePerMinute);
	}
}
