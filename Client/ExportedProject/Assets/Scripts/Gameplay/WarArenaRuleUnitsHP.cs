using System;

public class WarArenaRuleUnitsHP : WarArenaRuleGeneric<WarArenaRuleUnitsHP.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float healthMultiplier = 1f;
	}

	public virtual bool ECEGIKLPBDP()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.DDFGIDBHJIK();
	}

	public override bool AKIJBMEBNNC()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.FGHKBLLKOBL();
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		if (data.healthMultiplier > 1356f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Skip assignment success"));
		}
		if (data.healthMultiplier < 708f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_LOADING"), (OBNJAIHEJOJ)4);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual bool NAFCNBIPEKM()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.OEAODGFDMGC();
	}

	public virtual bool KEHNMKJNNLG()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.KFJLPGPAAAN();
	}

	protected virtual OCCICIIEHEF KNLNGNJEBMP()
	{
		if (data.healthMultiplier > 170f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ENTERARENA"), (OBNJAIHEJOJ)6);
		}
		if (data.healthMultiplier < 1371f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("NEW CONFIG WILL BE LOADED FROM PREFS:"), (OBNJAIHEJOJ)5);
		}
		return base.NELJBJBMOLH();
	}

	public virtual bool APBOMMHMLBI()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.OEAODGFDMGC();
	}

	public override bool EKMMLNKADIL()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.EKMMLNKADIL();
	}

	public virtual bool FBHCPDPGHFC()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.OEAODGFDMGC();
	}

	public virtual bool DFPDACAGFPO()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.MPNDBIBDOCD();
	}

	protected override OCCICIIEHEF MNMEAAEKAMH()
	{
		if (data.healthMultiplier > 1848f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_DAILYGOLDBOOSTERHINT1"), OBNJAIHEJOJ.FulFill);
		}
		if (data.healthMultiplier < 377f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_PLAYPVPRANKEDBATTLESTOGETLOOTBOX"), OBNJAIHEJOJ.InfoText);
		}
		return base.OMDJEDGCGOM();
	}

	public virtual bool HJEDAJDHEIG()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.OAELLJPGBPC();
	}

	public virtual bool GEDHBEADJGG()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.FGHKBLLKOBL();
	}

	public virtual bool MIPKONGICFO()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.KJDMOCMBFLJ();
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		if (data.healthMultiplier > 1300f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("VISUAL = NULL"), (OBNJAIHEJOJ)7);
		}
		if (data.healthMultiplier < 1539f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Wrong_Category"), OBNJAIHEJOJ.FulFill);
		}
		return base.OOBCHHAGFIO();
	}

	protected virtual OCCICIIEHEF EODHPEMMMAD()
	{
		if (data.healthMultiplier > 1970f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BoughtIndex"), (OBNJAIHEJOJ)7);
		}
		if (data.healthMultiplier < 469f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("#Mission Rewards# Current Heroic Points: "), (OBNJAIHEJOJ)6);
		}
		return base.MNMEAAEKAMH();
	}

	protected virtual OCCICIIEHEF EGPLLIKFDNA()
	{
		if (data.healthMultiplier > 1226f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}/{1}"), (OBNJAIHEJOJ)5);
		}
		if (data.healthMultiplier < 1495f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("withPublisherSub1"), OBNJAIHEJOJ.InfoText);
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF HPNAENEAMLB()
	{
		if (data.healthMultiplier > 1288f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE"), (OBNJAIHEJOJ)7);
		}
		if (data.healthMultiplier < 771f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("isNormal"), (OBNJAIHEJOJ)8);
		}
		return base.IEKDLDACNDI();
	}

	public virtual bool LCLHBPOHONI()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.NMPPLCHLCDK();
	}

	public virtual bool ACODIEIBMHN()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.KJDMOCMBFLJ();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.healthMultiplier > 1f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_STRONGERUNITS"));
		}
		if (data.healthMultiplier < 1f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_WEAKERUNITS"));
		}
		return base.OHFBLDPINHI();
	}

	public override bool KJDMOCMBFLJ()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.hpCoeficient = data.healthMultiplier;
		return base.KFJLPGPAAAN();
	}
}
