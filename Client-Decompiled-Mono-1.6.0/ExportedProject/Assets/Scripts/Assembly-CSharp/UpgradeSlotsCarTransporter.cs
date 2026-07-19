using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsCarTransporter : UpgradeSlotsVehicle<DBUpgradeSlotsTransporter>
{
	public override float damage
	{
		get
		{
			return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");
		}
	}

	public virtual FCLADBGKCIA DKMMEMBLKIH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, " NOT OK!\t\t\t\t\t\t");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1468f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA LCNBGEPPMLO(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_CONFIRM_FRIENDINSQUAD");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1084f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float NGEPCCOJOBB()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "game-card-silver");
	}

	[SpecialName]
	public virtual float DAMHGECFEJE()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "ID_WARNING_WARCARDNOTFOUNDINCOLLECTION");
	}

	[SpecialName]
	public virtual float DDMAMKDINOJ()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_SYSTEMMAINTENANCE");
	}

	protected virtual void OINFGPBIOMN(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, ", ");
	}

	[SpecialName]
	public virtual float HDIGKHDEDKO()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "/");
	}

	protected virtual void LJKPCEJGEPJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "to ");
	}

	public virtual FCLADBGKCIA JGLPFPMOHNH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_NEWLOOTBOXINBATTLE");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1713f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public override FCLADBGKCIA PerkImplementation(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float DGPFNDMHDNN()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "Days_Since_Install");
	}

	[SpecialName]
	public virtual float EJIDNLKFBDO()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_WARSHOP_MEMBERSHIP");
	}

	public virtual FCLADBGKCIA KNEKNPKMHBJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "setGameData");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 840f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA ACPMPOJGIEC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ClientId");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1649f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA CBINLBJBOEK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "#Mission Rewards# Current Heroic Points: ");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 274f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA BEODDOPBPIN(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_READYTIME");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1982f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA ADNCEJPLPFM(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "clipSize");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 758f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void CIMKPOAIOAO(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "RowIDs");
	}

	protected virtual void GOGNCGEAAEM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "//");
	}

	[SpecialName]
	public virtual float MOCIHCFDPIA()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "D2");
	}

	protected virtual void MHJOBPFJEEP(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "ReconnectDialog Hide");
	}

	[SpecialName]
	public virtual float MBCFGBJCKFC()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "menu-warbucks");
	}

	protected virtual void HFAANHPMDGB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "ColumnNames");
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "repairBotHP");
	}

	public virtual FCLADBGKCIA HJHFEOECLBF(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, " is not present in resources using default");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 448f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float OKKENAGOLHA()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "rocketlauncher");
	}

	public virtual FCLADBGKCIA PAOEMMDPOIG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_SILVERPACKS");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 426f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float GIMIJJGAFMN()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "#AccoutCheck# GamecenterChangeDuringTutorial - Check current GC on server");
	}

	protected virtual void PLDMCMIFJFC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "country-japan");
	}

	public virtual FCLADBGKCIA KKLLHDJKLDH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "MessageId");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 354f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void CGIEKLJEGOC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_READYTIME");
	}

	[SpecialName]
	public virtual float AFFPBOAFOKL()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "Terms: On Age Verification Criteria Not Met ");
	}

	[SpecialName]
	public virtual float GNDIIFHFNMF()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_ZEROSECONDS");
	}

	[SpecialName]
	public virtual float JBLFGNNMFIH()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "com/google/android/gms/common/ConnectionResult");
	}

	[SpecialName]
	public virtual float ABNNMFDKCLH()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT");
	}

	[SpecialName]
	public virtual float LADDMGGFALC()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "RegisterEvent(");
	}

	public virtual FCLADBGKCIA FBEEFOALJEM(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "{0} / {1} {2}");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 233f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void MFPCNEBGHBN(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "oo");
	}

	protected virtual void IMCCMGBJNFB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "]");
	}

	protected virtual void AOEHMACDCAL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "First you must run createStructure");
	}

	protected virtual void IPPLGOIBDIC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "}");
	}

	[SpecialName]
	public virtual float IFPOBPJFFDP()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_CONFIRM_ERROR");
	}

	protected virtual void OOFBLGAHEFM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "FirstSpawnDelay");
	}

	[SpecialName]
	public virtual float NPKBEIEOGHN()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "LevelExperience");
	}

	[SpecialName]
	public virtual float NCHPJCFAKFN()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_STAT_UNITSDEPLOYED");
	}

	[SpecialName]
	public virtual float FLDLOHDMKDK()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "SoldierBehaviourBuddy ChangeEquippedWeapons: Prim: {0} Sec: {1}");
	}

	[SpecialName]
	public virtual float KMFOHAAACCH()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "Received old game invite ( > {0} seconds). Not showing dialog. Opponent = {1}");
	}

	protected override void EGGDBGBIEDK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "워프렌즈를 실행하려면 약 190MB의 추가 데이터를 다운로드 받아야 합니다.\n다운로드 시간은 네트워크 및 지역에 따라 달라질 수 있습니다.\n\n계속 진행하시겠습니까?");
	}

	[SpecialName]
	public virtual float EPIKGOGPLPA()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "FacebookName");
	}

	[SpecialName]
	public virtual float BFLIJKNEBHP()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "-");
	}

	public virtual FCLADBGKCIA HHIPMIHLOCP(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Fuseb oxx manager: TEsting stufff");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 109f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float MPEKDCCMEGP()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "_N");
	}

	[SpecialName]
	public virtual float PMHGFOHHCIG()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "SquadId");
	}

	[SpecialName]
	public virtual float KFOAGAAMFFN()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "flawless");
	}

	protected virtual void IAEODNMFDCN(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, " {0}{1}");
	}

	protected override void PMGEOKJNIMP(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "InApp");
	}

	protected virtual void PLDBFLCGKAP(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "AdminName");
	}

	protected virtual void JMOOPHKCCPJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_WARNING_WRONGINDEXTOACTIVATEELITE");
	}

	[SpecialName]
	public virtual float NNPPCPNCJMP()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "{0} {1}/ {2}{3}");
	}

	public virtual FCLADBGKCIA JEFMGKJCOKK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "S");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1635f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float BNDIJBAEKDP()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "EmailLogin(");
	}

	[SpecialName]
	public virtual float HADLIKDFCFL()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_INBRONZE2");
	}

	[SpecialName]
	public virtual float HJANHJJPLDF()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "<");
	}

	[SpecialName]
	public virtual float LKCCBEBHPEI()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Assignment Screen - Daily - Claim Clicked");
	}

	[SpecialName]
	public virtual float NCPCANPPDKC()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Test");
	}

	public virtual FCLADBGKCIA NGHAJKOAMLH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ABOUT TO SHOW DAILY GOLD BOOST ");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 20f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA MJDNIHHNFMJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "FacebookId");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 419f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA ECKNHEOPIHJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "HeroicPoints");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 241f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA APHMEDALKGH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "special");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 494f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA PBEFDEOMGFH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "127 NEXT TUTORIAL STARTING");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 937f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA JDIEOEFCAFF(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "{0}{1}[-] / {2}");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 823f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void HEJOCPKFLJA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_WINSTREAK");
	}

	[SpecialName]
	public virtual float IPIJKPDNOHN()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "offerMult");
	}

	[SpecialName]
	public virtual float ENCPFNKOKOD()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "$#");
	}

	[SpecialName]
	public virtual float NLDICGHLJLI()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "ID_CONFIRM_LOWACTIVITYTHEREARE");
	}

	public virtual FCLADBGKCIA BCFEANBLOIH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 272f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float MMIFCAOBPHP()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_TWITTER_GAIN_AGAIN_TITLE");
	}

	protected override void GELJGONICCH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "Card_1_Played");
	}

	protected virtual void BOBDDINODDK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_STARTERASSIGNMENT");
	}

	[SpecialName]
	public virtual float MOMPDIAAHII()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "N");
	}

	[SpecialName]
	public virtual float PGMEABEFOLF()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "One Time Reward: ");
	}

	[SpecialName]
	public virtual float FNNBGGNCHKH()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "*.prefab");
	}

	protected virtual void PFNBCPAMCML(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "Player profile - {0} is banned {1}");
	}

	protected virtual void GEGNJCCJHNA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "PlacementMatchesRequired");
	}

	[SpecialName]
	public virtual float ELNJADICLKK()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_LOADING");
	}

	protected virtual void OFFCCIENCOK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "#PETER# Weapon Screen - LEFT BUTTON - weapon is rented - do nothing");
	}

	[SpecialName]
	public virtual float LNADNMDPIDO()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "CreationTime");
	}

	public virtual FCLADBGKCIA COGBMCEHJHJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_FINALDAILYGOLDBOOSTER");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 97f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA LGCAONHPGJL(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "\tNumber of games after fb login: {0}/{1}");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1584f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void IGCDAKGMACC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = (CarTransporterBehaviourDefinititon)BJOIGFEOMHN;
		carTransporterBehaviourDefinititon.repairBotHP += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_YES");
	}

	public virtual FCLADBGKCIA ODENJFHHCLI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "(Lcom/google/android/gms/common/api/GoogleApiClient;)Landroid/content/Intent;");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 488f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA FOPKAFNAEHE(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "shootAdditive");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1168f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}
}
