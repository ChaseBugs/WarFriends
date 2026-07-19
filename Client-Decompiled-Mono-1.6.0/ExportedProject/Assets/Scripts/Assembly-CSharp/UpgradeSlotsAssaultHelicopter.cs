using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsAssaultHelicopter : UpgradeSlotsVehicle<DBUpgradeSlotsDrone>
{
	public override float damage
	{
		get
		{
			return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");
		}
	}

	protected virtual void MHOECCBIJGM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, ") ");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, " GC connect: ");
	}

	[SpecialName]
	public virtual float NGNCDPFOGBO()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "ID_INVITEDYOUTOCOOP");
	}

	protected virtual void ADOPFDABJFD(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "ID_STATE_WAITINGFOROPPONENT");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "FuseSDK: NULL FriendsList.");
	}

	[SpecialName]
	public virtual float MPEKDCCMEGP()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "SendLogs");
	}

	public virtual FCLADBGKCIA INACKGEIKGC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, " {0}\u00a0{1}");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 246f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float NOAHPDILHHP()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Hide reconnect dialog");
	}

	public virtual FCLADBGKCIA LEIFMDPNAAC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "SquadMates");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 83f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA GGOINMKALFG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "getCurrentVariantId");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 764f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA JMMCJHFJDCC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Rank");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 495f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA ODENJFHHCLI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "#Swipe failed, distance threshold condition");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 137f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void OFFCCIENCOK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "GoldDeducted");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_EXITINGMATCH");
	}

	protected virtual void NLJLKCJLCHH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "/");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_SEARCHFORSQUAD");
	}

	protected virtual void FHJNHBELHOD(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "WENEEDTO");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "HELMETS_SANTA");
	}

	public virtual FCLADBGKCIA LGONMMOPMOO(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "await");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1836f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float ECDPJAEKFOO()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "ID_TUTORIAL_GRENADETHROW_DOWN");
	}

	public virtual FCLADBGKCIA CBINLBJBOEK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "C3");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1226f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA KNEKNPKMHBJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "FinishChoosingCardsRPC");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 325f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float GJBEMAEAKBL()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "S");
	}

	public virtual FCLADBGKCIA EEKMBIDIGIG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_ARENAFLAWLESSREWARDS");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 992f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void DEECDEBJIJB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "ID_GUI_EQUIPPED");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "twitter");
	}

	[SpecialName]
	public virtual float GCLFFCBCMCF()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_WARNING_NOTENOUGHGOLDARENA");
	}

	[SpecialName]
	public virtual float MOCIHCFDPIA()
	{
		return (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Action ");
	}

	[SpecialName]
	public virtual float MMEPIELHDCM()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "{0}{1}");
	}

	protected virtual void DLBBANHBPLA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "PayForRename");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "Error - sheet {0} doesnt have column {1}");
	}

	public virtual FCLADBGKCIA OBMFFBFMEOI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "craftingFinished");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1255f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float BNDIJBAEKDP()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_MAX");
	}

	[SpecialName]
	public virtual float NEFEJOFPPJD()
	{
		return (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "Start");
	}

	protected virtual void KNBLIGODKAJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "ID_WARNING_ADVERTISEMENTVIDEODIDNOTSTART");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "BR");
	}

	public virtual FCLADBGKCIA BCFEANBLOIH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Cards_Buddy_Played");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 564f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float KGMGGEGHHFJ()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "如不下载这些额外数据，《战争之友》将无法运行。您希望退出还是下载这些数据？");
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "glassHP");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "speed");
	}

	public virtual FCLADBGKCIA GOCBEJDJIAD(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Received FB Friends from server: ");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1991f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected override void EKODDIEBFKG(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, "ID_GETSP");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "trial");
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

	protected virtual void LLDKBIDOIJA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviourDefinititon = (AssaultHelicopterBehaviourDefinititon)BJOIGFEOMHN;
		assaultHelicopterBehaviourDefinititon.glassHealth = (float)assaultHelicopterBehaviourDefinititon.glassHealth + (float)base.excel.GetValue(FFCCFDJBLLD, " (#");
		assaultHelicopterBehaviourDefinititon.speed += (float)base.excel.GetValue(FFCCFDJBLLD, "Tickets");
	}

	public virtual FCLADBGKCIA NGJAIEPJDFC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "SquadRank");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 580f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float AFFPBOAFOKL()
	{
		return (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "percent");
	}

	public virtual FCLADBGKCIA KNMIJMGKNME(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "\t\"TRUE\"");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 423f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}
}
