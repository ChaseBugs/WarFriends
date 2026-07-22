using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsCar : UpgradeSlotsVehicle<DBUpgradeSlotsCar>
{
	public override float damage => (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			if (upgradeSlotSpecial.isBought)
			{
				List<Tuple<string, float>> list = new List<Tuple<string, float>>();
				int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
				float val = (float)base.excel.GetValue(boughtIndexAbsolute, "special");
				list.Add(new Tuple<string, float>("ID_SECONDWEAPONDAMAGE", val));
				return list;
			}
			return base.unitSpecifics;
		}
	}

	public virtual string AECOOKDHDOH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "KickedPlayerDepositedCards");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> LBEOGHJFDBE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "HK", "Enemy Card {0} {1}");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[6]);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LBGANDNNHNB()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "S");
			list.Add(new Tuple<string, float>("AtlasPreparer.LoadGameCoroutine", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string AIGCAFOHPNP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "S");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string JDEHJIOAPOF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "com.tune.TuneLocation");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GFIMEFOEPLO()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "ID_MONTH");
			list.Add(new Tuple<string, float>("Sniper_Tutorial_Played", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> CCJIJNFNJCA()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "ID_TUTORIAL_DELIVERED_WEAPON");
			list.Add(new Tuple<string, float>("after update GC still GC account, but no added or missing gcID or gcPassword", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string BLOAENPPKMF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.NGJIJEDDPNH();
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Sprite \"{0}\" was used in files:");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string HMMHEFLFLLA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_ARENASHORTCUTEVENTEND");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string DLMPGNFMNCI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "menu-arena-scrap-ico");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "DPS", "damage");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[2]);
		list.Add(tuple);
		return list;
	}

	public virtual string HMAPLOCANBP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "bronze1");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float IFPOBPJFFDP()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ShotFrequencyMax");
	}

	[SpecialName]
	public virtual float FNNBGGNCHKH()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "No");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> MNNLNGPLIJA()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "colt_run");
			list.Add(new Tuple<string, float>("service", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string DCEABBHELHB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "SquadId");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string ADDJHNJEGCK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_WARNING_SERVERTIMEDOUT");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string EBPMNLGLDIM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "PlayerGold");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> ALMODBNNOGB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_STAT_WARCARDSPLAYED", "Min_fps");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[6]);
		list.Add(tuple);
		return list;
	}

	public virtual string JKCBOCEPFEF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "Labels that will be changed:\n");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string MHFDNJJMBNP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "zoneHasRewarded");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FEKJIDGICGM()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "ID_CONFIRM_UNKNOWNREASON");
			list.Add(new Tuple<string, float>("menu-info-close-ico", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> CKEALLMIODL()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "ID_DOGTAGSREQUIRED");
			list.Add(new Tuple<string, float>("player_level", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string FKCDLGEAOBO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "LastAction");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string DNIOLPKIBFN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ArmyPower");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string FCEOODDEKFF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "LEADERBOARDS - no friends, showing invite button (ignoring global / local)");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float BNPAFIPONAN()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_RESTART");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> EJGOEEMBLMK()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "^\\D*");
			list.Add(new Tuple<string, float>("ID_WAITINGFORFRIEND", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string CFKBCFKCONF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "SciFi");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> LDLPCFJGKHH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "upgrades", "FuseBoxx: Session Started");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[3]);
		list.Add(tuple);
		return list;
	}

	public virtual string EOKNOBFILLF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_CONFIRM_THANKYOU");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string MLGBAMIFPNF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "#DANIEL# Everyplay IsRecordingSupported: ");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> KLIDEDGAEGE()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "()I");
			list.Add(new Tuple<string, float>("FacebookLogin(", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> FINIMLNIEIC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "N", "warArenaCrown");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[0]);
		list.Add(tuple);
		return list;
	}

	public virtual string FOHMNJNLKGN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "HU");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> KCONNDJNAFM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_ARENARULES_NOCRATES", "OnAgeVerificationPendingDisplayed");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[8] = Mathf.Round(tuple.Value2[7]);
		list.Add(tuple);
		return list;
	}

	public virtual string JLCFDGBKNFK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_GUI_CHAT_SQUAD_KICK");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float MPEKDCCMEGP()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "test_attribute1");
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "special");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float EIKFPNCFBFG()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "getPackageManager");
	}

	public virtual string AFEDBFEJLIK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Google2u.");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> JNFPDMNEKAO()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "On Get PLayer Info");
			list.Add(new Tuple<string, float>("ID_YOUNEEDMONEYTOUPGRADEELITE", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> GPIAFEAJGNN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "GLM: RegisterOrLogin -  1", " = ");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[6]);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> PJBKGEEAFNK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP", "Locale");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[5] = Mathf.Round(tuple.Value2[8]);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PKOAKACFKAN()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "}");
			list.Add(new Tuple<string, float>("ID_CONFIRM_EXITWARFRIENDS", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string DFJMCHAFDHC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "ID_VIEWUNIT");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> NIFFEJGBBFH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_SALEPERCENT", "RweardModifierWB");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[2]);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual float ECDPJAEKFOO()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_UNITDETAILEDSTATISTICS");
	}

	public virtual string EGKMADEBCAG(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "toString");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string INANAKFKMKA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Parameter");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> MANCOFDOMEJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "IsWarArenaBattle", "Name");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[7] = Mathf.Round(tuple.Value2[6]);
		list.Add(tuple);
		return list;
	}

	public virtual string PNNEPJEAIGA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_DOGTAGSREFILL");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> BBHMNCIEGIL()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "{0} {1}");
			list.Add(new Tuple<string, float>("com/google/android/gms/games/Games", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "special");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string MAGEJHNANMA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "BAND_REWARD_RELOAD");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> GGOMPHHHJEA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "0\u00a0", "ID_TWITTER_GAIN_TITLE");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[0]);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> CLBLKCEIKGD(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "WALLET - initialization GOLD {0}", "WaveCoolDown");
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[7]);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PJCPHFNEKIH()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "BotUnitPower");
			list.Add(new Tuple<string, float>("Mine ammo null", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string EBCAANPHECN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "LevelName");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string BACKAHIIGJI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.NGJIJEDDPNH();
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string GLFDFGBGOAE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.NGJIJEDDPNH();
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "onFirstPlaylistDownloaded");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float HPFENBCCFBF()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "InstantBattleTime");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PNBGAIOPBNI()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "\n");
			list.Add(new Tuple<string, float>("Seats", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string EFMCFJHALPO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "defendPosition");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float NEFEJOFPPJD()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_ARENASTARTSTIMER");
	}

	public virtual List<Tuple<string, float[]>> JEIBBBIAKKP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_WARNING_CANTSENDINVITE_TEXT", "Database Message: Error parsing message!! Auto Ignore! ");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[4]);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> KELGJMFPJCN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_INSTANTBATTLE", "IsMatchMaking");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[6] = Mathf.Round(tuple.Value2[0]);
		list.Add(tuple);
		return list;
	}
}
