using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsDrone : UpgradeSlotsMechanical<DBUpgradeSlotsDrone>
{
	public override float damage
	{
		get
		{
			return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");
		}
	}

	public virtual FCLADBGKCIA KLIKICEICGA(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ANDROID HANDLER: ON PLAYERDATA LOADED");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 269f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual List<Tuple<string, float[]>> NGKJOJBBLHF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "RETRY", "SquadWarsProcessing"));
		return list;
	}

	public virtual string KIFFKDHONFO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> GFJHJOKKKEL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "RETRY", "ID_OFFERACTIVE"));
		return list;
	}

	public virtual FCLADBGKCIA DONNEJAJOJN(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "PlayShotAnimationNetwork");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1572f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string PHHOLNMJECG(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string HPOKICKDNEM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> MPDMBPDBCIK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ID_WARNING_OFFEREXPIRED", "BeginnersLeague"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> HPHMKEDMNJO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "offerName", "type"));
		return list;
	}

	public virtual string NGKIFGNIOLK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string FKMHFBFLCDM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float BNDIJBAEKDP()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "Waiting for map set");
	}

	[SpecialName]
	public virtual float PDLDGNOOHGN()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Wrong_Weapon");
	}

	public virtual List<Tuple<string, float[]>> HJCBLLNHDCB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ID_WARNING_BUDDYCARDNOTREADY", "ID_OFFERENDSIN"));
		return list;
	}

	public virtual string BDOFDIJOKIK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float LPIBDCHKNGN()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "#AccoutCheck# FacebookLoginDuringTutorial - Check current FB on server");
	}

	[SpecialName]
	public virtual float OKKENAGOLHA()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "BattleId");
	}

	public virtual FCLADBGKCIA HJHFEOECLBF(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "resizing texture ");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 873f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual List<Tuple<string, float[]>> BPOGHCDJPIL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "Name", "About to show GC Change Name Dialog"));
		return list;
	}

	public override FCLADBGKCIA PerkImplementation(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string JGNLKIIKGBM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string IBBBMLKGGAP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string EOKNOBFILLF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string DCEABBHELHB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float DICOLFELKDG()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "menu-button-oneside");
	}

	public virtual string HFJMCMGIAFO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string CLBOPDLJNMJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> MJCHFMPBIJP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "null", "MX"));
		return list;
	}

	[SpecialName]
	public virtual float MMEPIELHDCM()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "ID_PASTEYOURVIDEOLINKHERE");
	}

	public virtual FCLADBGKCIA PAOEMMDPOIG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "'friend'0");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 992f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA MEHFPIDFCJF(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_MINUTES");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1812f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA PAGAHILNOLJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Player_Waited_Till_Delivery_Ends");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1897f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string JOMIGNJCJOJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float HADLIKDFCFL()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ArmyPower");
	}

	public virtual string FCEOODDEKFF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string AIAJPALDKJK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float GIMIJJGAFMN()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "{0}\u00a0{1}");
	}

	public virtual string GCPJFILNMPD(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string JOMHMAFFNKD(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float NLDICGHLJLI()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "S");
	}

	public virtual FCLADBGKCIA PMACINNNKGJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Different actual league Id \"{0}\" and database message - league entered - league id \"{1}\"");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1630f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string FAOGBNOMAGA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string DAKFLDOOKJF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string LGMMBIAOFGM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string KNOMJDGFNGN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual FCLADBGKCIA ILDNBIPFKGJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "S");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1597f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float HJANHJJPLDF()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "Dictionary filled and contains {0} ids\n");
	}

	public virtual FCLADBGKCIA BCAOHCCJIED(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "WarArenaData");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 997f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string KINCBOKHECI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string INANAKFKMKA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> ADONNICJDKH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "SquadWarsId", "OnPhotonJoinRoomFailed: {0}, message {1}"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> JIOHEFMGJAM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "PhotonConnectionManager: Disconnect", "IAPOfferInfo"));
		return list;
	}

	public virtual string HJLHLPIGOKD(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual FCLADBGKCIA APCLCIPDCBA(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "withAdvertiserSubAdgroup");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1665f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual List<Tuple<string, float[]>> GEBBFENPBMO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "SquadId", "For {0} - {1} are objects in different Z\n{2} in {3} and {4} in {5}"));
		return list;
	}

	public virtual FCLADBGKCIA LANOACNEMLO(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Gold");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 642f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA GGOINMKALFG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Player_Had_To_Select_Grenade");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 840f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string NIOFKJIDOLF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float PAEGGNCMFPC()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "WarFriends");
	}

	[SpecialName]
	public virtual float KJIDOAKNFII()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "502 MENU BATTLE SCREEN SHOWN");
	}

	public virtual string JBKHGBCMAIM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float EEMJHJKAKKL()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Warbucks");
	}

	public virtual List<Tuple<string, float[]>> LCIGBEJHIDC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ID_CATEGORY_SMG", "ID_YOUNEEDMONEYTOUPGRADE"));
		return list;
	}

	public virtual string JPBMBNALMPJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual FCLADBGKCIA EEKMBIDIGIG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "FOUND");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 346f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual string EFMCFJHALPO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "special", "seconds"));
		return list;
	}

	public virtual FCLADBGKCIA FOILDKAGBHK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Beanstalk: Crash Report Succesfully Sent");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1397f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual List<Tuple<string, float[]>> GFLGLKDNJNC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "Labels that will be changed:\n", "BundleId"));
		return list;
	}

	public virtual string MGCBNDHECAK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.NEJNMDNOAKD()[0].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual float NGEPCCOJOBB()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Skillshot 0000");
	}

	[SpecialName]
	public virtual float LECDGGPECCE()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "WarFriends");
	}

	public virtual string DDOCINPCOHK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[0];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string EBCAANPHECN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> LDBDMIOLBKI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "country-romania", "us-east-1:a951d2ae-0491-424d-8240-ae25baedf92a"));
		return list;
	}

	[SpecialName]
	public virtual float FLHBAANJEOJ()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "({0}\u00a0/\u00a0{1})");
	}

	[SpecialName]
	public virtual float JBLFGNNMFIH()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Card_2_Played");
	}

	[SpecialName]
	public virtual float PMHGFOHHCIG()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "BUDDY WARCARD");
	}

	public virtual string CFKBCFKCONF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> INHKHFELKCB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "colt_run", "MineCards"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> PIKFKBLMCIM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "MagazineSize", "Reload"));
		return list;
	}

	public virtual string MJMACJFLGLE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		float fFHHEHHFOKJ = ACHJJKCIBCN.guiStatistics[1].Value2[1];
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual FCLADBGKCIA OACAPIGGDHI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Spend_Warbucks_On_Army");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 413f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float NPKBEIEOGHN()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), " TOTAL ALLOCATED: ");
	}
}
