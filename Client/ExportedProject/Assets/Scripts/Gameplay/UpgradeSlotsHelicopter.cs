using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsHelicopter : UpgradeSlotsVehicle<DBUpgradeSlotsHelicopter>
{
	public override float damage => (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int rowIndex = upgradeSlot.boughtIndex;
			list.Add(new Tuple<string, float>("ID_DEPLOYEDSOLDIERS", (int)base.excel.GetValue(rowIndex, "Seats")));
			return list;
		}
	}

	public virtual FCLADBGKCIA KLIKICEICGA(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Subscription Expired");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1813f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float EHDDONPMJJN()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_NOTIFICATION_WEAPONUPGRADEDELIVERED");
	}

	public virtual string FAOGBNOMAGA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string NMHIFOHOLLL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string HFNNDCMCBFE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PCFAEBCECAM()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		list.Add(new Tuple<string, float>("RegisterAge()", (int)base.excel.GetValue(rowIndex, "ID_CONFIRM_FORFEIT_TEXT")));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> ALBFOHHPENC()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		list.Add(new Tuple<string, float>("SheetConfiguraton", (int)base.excel.GetValue(rowIndex, "FuseSDK: Parsing error in _PurchaseVerification")));
		return list;
	}

	public virtual string HAMHBDHFBGG(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> HHMNCKJHIDF()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		list.Add(new Tuple<string, float>("ID_GOLDCARD", (int)base.excel.GetValue(rowIndex, "menu-squad-{0}")));
		return list;
	}

	public virtual FCLADBGKCIA EEKMBIDIGIG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_SLOTUPGRADE_DAMAGE");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1474f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		HelicopterBehaviourDefinititon helicopterBehaviourDefinititon = (HelicopterBehaviourDefinititon)BJOIGFEOMHN;
		helicopterBehaviourDefinititon.crew += (int)base.excel.GetValue(FFCCFDJBLLD, "Seats");
	}

	protected override void PLFPGNEENMH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		HelicopterBehaviourDefinititon helicopterBehaviourDefinititon = (HelicopterBehaviourDefinititon)BJOIGFEOMHN;
		helicopterBehaviourDefinititon.crew += (int)base.excel.GetValue(FFCCFDJBLLD, "Have discount {0} to buy {1}");
	}

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> LCIGBEJHIDC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, " (", "forever"));
		return list;
	}

	public virtual string GLFDFGBGOAE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float NFECDGBCLCM()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "\n\nDEBUG STATE: ");
	}

	public virtual string KCKCEPJEKEE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "special", "seconds"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LDLPCFJGKHH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "Adding warcards from cardpool:\n", "ID_INTIME"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> ICOPDBOLAFH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ID_SLOTUPGRADE_DAMAGE", "S"));
		return list;
	}

	[SpecialName]
	public virtual float DJNNEPGGGIP()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "ElitePartsGained");
	}

	public virtual List<Tuple<string, float[]>> AOBEFGHEPEI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "Weapon", "ID_DELIVERNOW"));
		return list;
	}

	public virtual string FKMHFBFLCDM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string KBHGAMPCKFJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	protected virtual void LMOAMPIPDNH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		HelicopterBehaviourDefinititon helicopterBehaviourDefinititon = (HelicopterBehaviourDefinititon)BJOIGFEOMHN;
		helicopterBehaviourDefinititon.crew += (int)base.excel.GetValue(FFCCFDJBLLD, "ID_GUI_ALLCARDS");
	}

	public virtual string FKCDLGEAOBO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string KOLPKHJIFOK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	protected override void OLBOBDCGIKH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		HelicopterBehaviourDefinititon helicopterBehaviourDefinititon = (HelicopterBehaviourDefinititon)BJOIGFEOMHN;
		helicopterBehaviourDefinititon.crew += (int)base.excel.GetValue(FFCCFDJBLLD, "Buy_Weapon_At_Rank");
	}

	public virtual FCLADBGKCIA APCLCIPDCBA(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, " <=");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 41f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string KKNMIEOCJPM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> OFHOCMAJCEL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "Time", "Parallax/Parallax"));
		return list;
	}

	[SpecialName]
	public virtual float PGIDKDIPPPO()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "GameCenterId");
	}

	public virtual string PKOOCGLDPEF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float NGEPCCOJOBB()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "menu-sidetab-player-demote");
	}

	[SpecialName]
	public virtual float PALPFNMBMMJ()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Saving GC Player Account change!");
	}

	public virtual List<Tuple<string, float[]>> BNAEOEMIMDG(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "TranslationIdFinder.cs", "+{0}"));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> MJPBKPKIIHO()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		list.Add(new Tuple<string, float>("*****   Bootcamp 3/3 Ended   *****", (int)base.excel.GetValue(rowIndex, "SquadMembers")));
		return list;
	}

	[SpecialName]
	public virtual float EIKFPNCFBFG()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "CAUGHT AN MISSION EXCEPTION ");
	}

	public virtual List<Tuple<string, float[]>> MJLKMGDGPMI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "AdminId", "WarBucks"));
		return list;
	}

	public virtual string KHIFJONPCPM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual FCLADBGKCIA CBINLBJBOEK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_SKILLSHOTHINT_EXPLOSIVEKILL");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 188f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string DFJMCHAFDHC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string GMECFMAEOIC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float PPILOFBGPLJ()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "SERVICE_UPDATING");
	}

	public virtual string LCNCJPKABLM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float NGNCDPFOGBO()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "ID_XARENATICKETS");
	}

	public virtual List<Tuple<string, float[]>> HJCBLLNHDCB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "gold", "0"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> CBCJELADOIL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "0", "repairBotHP"));
		return list;
	}

	protected virtual void MLPIBJGMAGH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		HelicopterBehaviourDefinititon helicopterBehaviourDefinititon = (HelicopterBehaviourDefinititon)BJOIGFEOMHN;
		helicopterBehaviourDefinititon.crew += (int)base.excel.GetValue(FFCCFDJBLLD, "resultMessage");
	}

	public override FCLADBGKCIA PerkImplementation(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual List<Tuple<string, float[]>> GECHEOIGCPN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "Google2u.DBUpgradeSlotsMachineGunner", "1"));
		return list;
	}
}
