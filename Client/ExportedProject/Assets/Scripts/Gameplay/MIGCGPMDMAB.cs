using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class MIGCGPMDMAB
{
	[CompilerGenerated]
	private static Comparison<WarArenaRule.OCCICIIEHEF> LGJCBPOPCPA;

	public static List<WarArenaRule.OCCICIIEHEF> FLNLPCPAAEE
	{
		get
		{
			List<WarArenaRule.OCCICIIEHEF> list = new List<WarArenaRule.OCCICIIEHEF>();
			if (WarArena.instance.FPLIPHCJGFO == null)
			{
				return list;
			}
			foreach (WarArenaRule currenArenaRule in WarArena.instance.currenArenaRules)
			{
				WarArenaRule.OCCICIIEHEF guiRule = currenArenaRule.guiRule;
				if (guiRule != null && (currenArenaRule.GGPAFMAPJOG().showRule || guiRule.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.FulFill || guiRule.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.DoesNotMeet))
				{
					list.Add(guiRule);
				}
			}
			string lHFDEOPIFNE = Localization.LocalizeFormat("ID_ARENARULES_BATTLES", Colours.stringGreenArena, WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA);
			list.Add(new WarArenaRule.OCCICIIEHEF(lHFDEOPIFNE, WarArenaRule.OBNJAIHEJOJ.InfoText));
			int iLGNOFBHOMC = WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
			string lHFDEOPIFNE2 = ((iLGNOFBHOMC <= 1) ? Localization.LocalizeFormat("ID_ARENARULES_LIVE", Colours.stringGreenArena) : Localization.LocalizeFormat("ID_ARENARULES_LIVES", Colours.stringGreenArena, iLGNOFBHOMC));
			list.Add(new WarArenaRule.OCCICIIEHEF(lHFDEOPIFNE2, WarArenaRule.OBNJAIHEJOJ.InfoText));
			string lHFDEOPIFNE3 = Localization.LocalizeFormat("ID_ARENARULES_NORMALIZATION", Colours.stringGreenArena);
			list.Add(new WarArenaRule.OCCICIIEHEF(lHFDEOPIFNE3, WarArenaRule.OBNJAIHEJOJ.InfoText));
			list.StableSort((WarArenaRule.OCCICIIEHEF ANAEPPOLFIE, WarArenaRule.OCCICIIEHEF NNHGDOPKJNH) => (ANAEPPOLFIE.FJLBLLLEELD != NNHGDOPKJNH.FJLBLLLEELD) ? ANAEPPOLFIE.FJLBLLLEELD.CompareTo(NNHGDOPKJNH.FJLBLLLEELD) : 0);
			return list;
		}
	}

	public static List<WarArenaRule.OCCICIIEHEF> OBHCLNBEAFD
	{
		get
		{
			List<WarArenaRule.OCCICIIEHEF> list = new List<WarArenaRule.OCCICIIEHEF>();
			foreach (WarArenaRule currenArenaRule in WarArena.instance.currenArenaRules)
			{
				WarArenaRule.OCCICIIEHEF guiRule = currenArenaRule.guiRule;
				if (guiRule != null && guiRule.FJLBLLLEELD == WarArenaRule.OBNJAIHEJOJ.DoesNotMeet)
				{
					list.Add(guiRule);
				}
			}
			return list;
		}
	}

	public static string JONJEODEGMO(string JFACEEMNMGM)
	{
		if (WarArena.instance.FPLIPHCJGFO == null)
		{
			return string.Empty;
		}
		if (WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK)
		{
			return Localization.LocalizeFormat("ID_ARENASHORTCUTEVENTSTART", JFACEEMNMGM, MEJMLNDFDBP.CJCFPDLDMEK(WarArena.instance.FPLIPHCJGFO.MKOCGJKIJLB, "ID_READYTIME", string.Empty));
		}
		if (WarArena.instance.FPLIPHCJGFO.DIFPOOMLLEM)
		{
			return string.Empty;
		}
		IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM = WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG;
		IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM2 = WarArena.instance.FPLIPHCJGFO.HMINOMDIBAF;
		bool flag = cIFMKGIKJFM2 == null;
		if (cIFMKGIKJFM != null)
		{
			if (cIFMKGIKJFM.BDKNNNCHILL)
			{
				string keyFormat = ((!flag) ? "ID_ARENASHORTCUTPHASEEND" : "ID_ARENASHORTCUTEVENTEND");
				return Localization.LocalizeFormat(keyFormat, JFACEEMNMGM, MEJMLNDFDBP.CJCFPDLDMEK(cIFMKGIKJFM.LCGEMCALCCO, "ID_READYTIME", string.Empty));
			}
			if (!flag)
			{
				return Localization.LocalizeFormat("ID_ARENASHORTCUTPHASESTART", JFACEEMNMGM, MEJMLNDFDBP.CJCFPDLDMEK(cIFMKGIKJFM2.FBKJMMDCECF, "ID_READYTIME", string.Empty));
			}
		}
		return string.Empty;
	}

	public static string NCEBBJOLANF(bool MNIEPIMONBO = false, bool AODDNFMFPCP = false)
	{
		if (WarArena.instance.FPLIPHCJGFO == null || WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK || WarArena.instance.FPLIPHCJGFO.DIFPOOMLLEM)
		{
			return string.Empty;
		}
		IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM = WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG;
		if (cIFMKGIKJFM != null)
		{
			if (cIFMKGIKJFM.BDKNNNCHILL)
			{
				return Localization.LocalizeFormat((!AODDNFMFPCP) ? "ID_ARENAENDSTIMER" : "ID_ARENAENDSENTERTIMER", (!MNIEPIMONBO) ? Colours.stringGreenArena : "[-]", MEJMLNDFDBP.CJCFPDLDMEK(cIFMKGIKJFM.LCGEMCALCCO, "ID_READYTIME", string.Empty));
			}
			IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM2 = WarArena.instance.FPLIPHCJGFO.HMINOMDIBAF;
			if (cIFMKGIKJFM2 != null)
			{
				return Localization.LocalizeFormat((!AODDNFMFPCP) ? "ID_ARENASTARTSTIMER" : "ID_ARENASTARTSENTERTIMER", (!MNIEPIMONBO) ? Colours.stringGreenArena : "[-]", MEJMLNDFDBP.CJCFPDLDMEK(cIFMKGIKJFM2.FBKJMMDCECF, "ID_READYTIME", string.Empty));
			}
		}
		return string.Empty;
	}

	public static string LELBKHAECAC()
	{
		if (WarArena.instance.FPLIPHCJGFO == null || WarArena.instance.FPLIPHCJGFO.DIFPOOMLLEM)
		{
			return string.Empty;
		}
		if (WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK)
		{
			return Localization.LocalizeFormat("ID_ARENASTARTSTIMER", "[-]", MEJMLNDFDBP.CJCFPDLDMEK(WarArena.instance.remainigTimeTillStart, "ID_READYTIME", string.Empty));
		}
		IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM = WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG;
		if (cIFMKGIKJFM != null)
		{
			if (cIFMKGIKJFM.BDKNNNCHILL)
			{
				return string.Empty;
			}
			IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM2 = WarArena.instance.FPLIPHCJGFO.HMINOMDIBAF;
			if (cIFMKGIKJFM2 != null)
			{
				return Localization.LocalizeFormat("ID_ARENASTARTSTIMER", Colours.stringBlack, MEJMLNDFDBP.CJCFPDLDMEK(cIFMKGIKJFM2.FBKJMMDCECF, "ID_READYTIME", string.Empty));
			}
		}
		return string.Empty;
	}

	public static bool LBNPMFOAJAE()
	{
		return WarArena.instance.FPLIPHCJGFO != null && WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG != null && !WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL;
	}

	public static bool PACOBAAJCOK()
	{
		return WarArena.instance.FPLIPHCJGFO != null && WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK;
	}

	public static string DLOMFFMKIBM()
	{
		if (WarArena.instance.FPLIPHCJGFO == null || WarArena.instance.FPLIPHCJGFO.DIFPOOMLLEM)
		{
			return string.Empty;
		}
		if (WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK)
		{
			return Localization.LocalizeFormat("ID_ARENAEVENTSTARTSIN", MEJMLNDFDBP.CJCFPDLDMEK(WarArena.instance.remainigTimeTillStart, "ID_READYTIME", string.Empty));
		}
		return Localization.LocalizeFormat("ID_ARENAEVENTENDSIN", MEJMLNDFDBP.CJCFPDLDMEK(WarArena.instance.remainigTimeTillEnd, "ID_READYTIME", string.Empty));
	}

	public static bool NLLJDHEPKMG()
	{
		return WarArena.instance.FPLIPHCJGFO != null && WarArena.instance.isOpened && WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB - Singleton<BeanstalkServerManager>.instance.currentTimestamp < 10800;
	}

	public static string NBMKJPGBCEC()
	{
		if (WarArena.instance.FPLIPHCJGFO == null || WarArena.instance.FPLIPHCJGFO.DIFPOOMLLEM)
		{
			return string.Empty;
		}
		if (WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK)
		{
			return Localization.LocalizeFormat("ID_EVENTSTARTSINSMALL", Colours.stringGreenArena, MEJMLNDFDBP.CJCFPDLDMEK(WarArena.instance.remainigTimeTillStart, "ID_READYTIME", string.Empty));
		}
		return Localization.LocalizeFormat("ID_EVENTENDSINSMALL", Colours.stringGreenArena, MEJMLNDFDBP.CJCFPDLDMEK(WarArena.instance.remainigTimeTillEnd, "ID_READYTIME", string.Empty));
	}

	public static string LBKKLBKBGEA()
	{
		if (WarArena.instance.FPLIPHCJGFO != null && WarArena.instance.isOpened)
		{
			IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM = WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG;
			if (cIFMKGIKJFM != null && !cIFMKGIKJFM.BDKNNNCHILL)
			{
				IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM2 = WarArena.instance.FPLIPHCJGFO.HMINOMDIBAF;
				if (cIFMKGIKJFM2 != null)
				{
					return Localization.LocalizeFormat("ID_STARTSINX", MEJMLNDFDBP.CJCFPDLDMEK(cIFMKGIKJFM2.FBKJMMDCECF, "ID_READYTIME", string.Empty));
				}
			}
			return Localization.Localize("ID_BATTLEINARENA");
		}
		return Localization.Localize("ID_ARENACLOSED");
	}

	[CompilerGenerated]
	private static int AGFHOIBEOIG(WarArenaRule.OCCICIIEHEF ANAEPPOLFIE, WarArenaRule.OCCICIIEHEF NNHGDOPKJNH)
	{
		if (ANAEPPOLFIE.FJLBLLLEELD == NNHGDOPKJNH.FJLBLLLEELD)
		{
			return 0;
		}
		return ANAEPPOLFIE.FJLBLLLEELD.CompareTo(NNHGDOPKJNH.FJLBLLLEELD);
	}
}
