using System;
using System.Collections.Generic;

public class WarArenaRuleCardsFilter : WarArenaRuleGeneric<WarArenaRuleCardsFilter.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public CardManager.CardFilter filter;
	}

	private static Dictionary<CardManager.CardFilter, string> mTexts = new Dictionary<CardManager.CardFilter, string>
	{
		{
			CardManager.CardFilter.None,
			"ID_ARENARULES_NOWARCARDS"
		},
		{
			CardManager.CardFilter.Bronze,
			"ID_ARENARULES_BRONZEWARCARDS"
		},
		{
			CardManager.CardFilter.Silver,
			"ID_ARENARULES_SILVERWARCARDS"
		},
		{
			CardManager.CardFilter.Gold,
			"ID_ARENARULES_GOLDWARCARDS"
		},
		{
			CardManager.CardFilter.Buddy,
			"ID_ARENARULES_BUDDYWARCARDS"
		}
	};

	protected virtual OCCICIIEHEF BNBPAJLLFPI()
	{
		if (data.filter != (CardManager.CardFilter)(-94))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.FulFill);
		}
		return base.EPEIMHECJHK();
	}

	protected virtual OCCICIIEHEF NMNDHOPPLLH()
	{
		if (data.filter != ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.InfoText);
		}
		return base.MNMEAAEKAMH();
	}

	protected override OCCICIIEHEF IBOOCJPKFLG()
	{
		if (data.filter != (CardManager.CardFilter)159)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)5);
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF IBFBBFCOOMP()
	{
		if (data.filter != (CardManager.CardFilter)(-80))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.FulFill);
		}
		return base.LMOHCGEPLAH();
	}

	public virtual bool OAEPBDCAKHC()
	{
		base.EKMMLNKADIL();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return false;
	}

	public virtual bool MMCGGCFABAJ()
	{
		base.CLPEMLCLDIJ();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return true;
	}

	protected override OCCICIIEHEF NNNAKBICOHM()
	{
		if (data.filter != (CardManager.CardFilter)96)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)4);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual bool CICCFGCHCMB()
	{
		base.DDFGIDBHJIK();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return true;
	}

	public virtual bool FLLKDDFAFAD()
	{
		base.AIMGMMCHEIO();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return false;
	}

	public override bool OAELLJPGBPC()
	{
		base.AKIJBMEBNNC();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return true;
	}

	protected virtual OCCICIIEHEF HPNAENEAMLB()
	{
		if (data.filter != (CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected | CardManager.CardFilter.Random))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.FulFill);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF EODHPEMMMAD()
	{
		if (data.filter != (CardManager.CardFilter)(-166))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)8);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		if (data.filter != (CardManager.CardFilter)135)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)8);
		}
		return base.BEDAAOOPNLB();
	}

	public virtual bool EKGJEGJKHBE()
	{
		base.EDNAIMPLPGL();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return true;
	}

	public virtual bool NBMHHPPMACH()
	{
		base.FGHKBLLKOBL();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return true;
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		if (data.filter != (CardManager.CardFilter)(-90))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)8);
		}
		return base.NELJBJBMOLH();
	}

	protected virtual OCCICIIEHEF DJHPDCMGPOO()
	{
		if (data.filter != (CardManager.CardFilter)170)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.IEKDLDACNDI();
	}

	public virtual bool OCOLAMMPOBP()
	{
		base.AIMGMMCHEIO();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return true;
	}

	public virtual bool IGIMHDBBFJI()
	{
		base.LPLPANBJDAM();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return true;
	}

	public override bool AIMGMMCHEIO()
	{
		base.NMPPLCHLCDK();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return false;
	}

	public virtual bool MNJCKHIAHKK()
	{
		base.LPLPANBJDAM();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return true;
	}

	public virtual bool DOCIOINNLBP()
	{
		base.OEAODGFDMGC();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return false;
	}

	protected virtual OCCICIIEHEF KBBNGLNFBHM()
	{
		if (data.filter != (CardManager.CardFilter)96)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.InfoText);
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF KMLOHPNKIDO()
	{
		if (data.filter != (CardManager.CardFilter)126)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF IKAEPAPKLOB()
	{
		if (data.filter != (CardManager.CardFilter.Silver | CardManager.CardFilter.Buddy | CardManager.CardFilter.Random))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)8);
		}
		return base.NELJBJBMOLH();
	}

	public virtual bool APDCHBMJHEC()
	{
		base.KJDMOCMBFLJ();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return false;
	}

	public virtual bool AHIHNCGCOKK()
	{
		base.LPLPANBJDAM();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return true;
	}

	protected virtual OCCICIIEHEF EEOALKHGIOE()
	{
		if (data.filter != (CardManager.CardFilter)111)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)8);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual bool FBHCPDPGHFC()
	{
		base.KJDMOCMBFLJ();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return false;
	}

	protected virtual OCCICIIEHEF EGPLLIKFDNA()
	{
		if (data.filter != (CardManager.CardFilter)180)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.IBOOCJPKFLG();
	}

	protected virtual OCCICIIEHEF MEFHLDONKGE()
	{
		if (data.filter != (CardManager.CardFilter)(-177))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)8);
		}
		return base.OHFBLDPINHI();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.filter != CardManager.CardFilter.All)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]));
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		if (data.filter != (CardManager.CardFilter)170)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)5);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual bool KEHNMKJNNLG()
	{
		base.OAELLJPGBPC();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return false;
	}

	protected override OCCICIIEHEF MNMEAAEKAMH()
	{
		if (data.filter != (CardManager.CardFilter)(-97))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)5);
		}
		return base.EPEIMHECJHK();
	}

	public virtual bool OPEFGGIFJAN()
	{
		base.FGHKBLLKOBL();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return true;
	}

	protected virtual OCCICIIEHEF HMEACMJLAOC()
	{
		if (data.filter != (CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.FulFill);
		}
		return base.NNNAKBICOHM();
	}

	public override bool EKMMLNKADIL()
	{
		base.EKMMLNKADIL();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetCardsFilter(data.filter);
		return true;
	}

	protected virtual OCCICIIEHEF BONNBPPGHKO()
	{
		if (data.filter != (CardManager.CardFilter)(-94))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.EPEIMHECJHK();
	}

	public virtual bool DFPDACAGFPO()
	{
		base.AIMGMMCHEIO();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return false;
	}

	public override bool CLPEMLCLDIJ()
	{
		base.DJDCOJHOBJP();
		Singleton<GameController>.instance.MBPKLMKBJAB.POEANIJJLOM(data.filter);
		return false;
	}

	protected virtual OCCICIIEHEF PBNCCMPCFPE()
	{
		if (data.filter != ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Preselected))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), (OBNJAIHEJOJ)4);
		}
		return base.BEDAAOOPNLB();
	}

	protected virtual OCCICIIEHEF CCHDCMOJNFP()
	{
		if (data.filter != ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected | CardManager.CardFilter.Random))
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]), OBNJAIHEJOJ.FulFill);
		}
		return base.NELJBJBMOLH();
	}
}
