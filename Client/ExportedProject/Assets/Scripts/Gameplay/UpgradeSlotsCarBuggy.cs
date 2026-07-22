using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsCarBuggy : UpgradeSlotsVehicle<DBUpgradeSlotsCarBuggy>
{
	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "CannonDamage");
		}
	}

	public override float rateOfFire
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			if (base.excel.HasColumn("ShotFrequencyMinCannon") && base.excel.HasColumn("ShotFrequencyMaxCannon"))
			{
				float num = (float)base.excel.GetValue(rowIndex, "ShotFrequencyMinCannon");
				float num2 = (float)base.excel.GetValue(rowIndex, "ShotFrequencyMaxCannon");
				return 60f / ((num + num2) * 0.5f);
			}
			return 1f;
		}
	}

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

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float fFHHEHHFOKJ = (float)base.excel.GetValue(boughtIndexAbsolute, "special");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float BNDIJBAEKDP()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "ID_CATEGORY_SHOTGUN");
	}

	protected virtual void GHODIBPLOHM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)BJOIGFEOMHN;
		carBuggyBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMaxCannon");
		carBuggyBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ClearEntries");
		carBuggyBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "gold");
	}

	protected override void GELJGONICCH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)BJOIGFEOMHN;
		carBuggyBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Tier");
		carBuggyBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Achievements config for the '{0}' group contains less achievement definitions than is currently stored on the server.");
		carBuggyBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Wrong_Unit");
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float fFHHEHHFOKJ = (float)base.excel.GetValue(maxIndexInExcel, "special");
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float MOHAFOIHDKG()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		if (base.excel.HasColumn("ID_SECONDS") && base.excel.HasColumn("_shotgun"))
		{
			float num = (float)base.excel.GetValue(rowIndex, "CX6896566GD");
			float num2 = (float)base.excel.GetValue(rowIndex, "ID_GUI_SQUADLEVELEDUP");
			return 260f / ((num + num2) * 652f);
		}
		return 1799f;
	}

	public virtual List<Tuple<string, float[]>> HPHMKEDMNJO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "GOT MAINTENANCE MESSAGE IN CREATE ACCOUNT", "FuseRewardedAdOptionKey_ShowPostRoll");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[8] = Mathf.Round(tuple.Value2[1]);
		list.Add(tuple);
		return list;
	}

	protected virtual void GEGNJCCJHNA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)BJOIGFEOMHN;
		carBuggyBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;");
		carBuggyBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_ELITEPACK_UNITDESCRIPTION");
		carBuggyBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "SquadId");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> NMIDEDKLLLH()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "Beanstalk: On Get Friends");
			list.Add(new Tuple<string, float>("ID_TUTORIAL_RIFLE_UP", val));
			return list;
		}
		return base.unitSpecifics;
	}

	protected virtual void PJDFHGJEPOO(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)BJOIGFEOMHN;
		carBuggyBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "GameLauncher.Async started");
		carBuggyBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_STARTERASSIGNMENTX");
		carBuggyBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, " is not present in resources using default");
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

	protected virtual void DEECDEBJIJB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)BJOIGFEOMHN;
		carBuggyBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "throw_grenade_right");
		carBuggyBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Black_market_triggered");
		carBuggyBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "REGISTER PREDEFINED ASSIGNMENT EVENT COMPLETED");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> EKAMPJHPIGI()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "ID_YOUAREPREMIUMMEMBERWITHBENEFITS");
			list.Add(new Tuple<string, float>("ID_BATTLECANCELED", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> IFJEPMFEOCI()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int boughtIndexAbsolute = upgradeSlotSpecial.boughtIndexAbsolute;
			float val = (float)base.excel.GetValue(boughtIndexAbsolute, "Near avoid !! ");
			list.Add(new Tuple<string, float>("ID_NOW", val));
			return list;
		}
		return base.unitSpecifics;
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)BJOIGFEOMHN;
		carBuggyBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMaxCannon");
		carBuggyBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMinCannon");
		carBuggyBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "CannonDamage");
	}

	[SpecialName]
	public virtual float IDCCKJDKHPN()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "ID_VISUALRARITY2");
	}

	public virtual List<Tuple<string, float[]>> EJEOBKOJJII(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "dailyRewardData", "NEW TOP RUN = ");
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[3]);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual float NOBLFHBJHIG()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		if (base.excel.HasColumn("es") && base.excel.HasColumn("VIPMemeberShipAlmostEnded"))
		{
			float num = (float)base.excel.GetValue(rowIndex, "ID_CONFIRM_SQUADNAMETAKEN");
			float num2 = (float)base.excel.GetValue(rowIndex, "ID_BUYVALUEPACK");
			return 1251f / ((num + num2) * 181f);
		}
		return 1708f;
	}
}
