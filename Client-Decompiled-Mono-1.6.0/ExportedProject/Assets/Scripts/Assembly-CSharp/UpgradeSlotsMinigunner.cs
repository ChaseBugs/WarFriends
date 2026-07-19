using Google2u;
using UnityEngine;

public class UpgradeSlotsMinigunner : UpgradeSlotsBaseSoldier<DBUpgradeSlotsShotgunner>
{
	protected virtual void HAABBCFAEEP(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "special");
	}

	protected virtual void GEGNJCCJHNA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "SAIR");
	}

	protected virtual void HHAPKGDKJEF(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, ";");
	}

	protected virtual void IMCCMGBJNFB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "Chat - new notifications: {0}, selectedSquadChat: {1}, currentState: {2}");
	}

	public virtual FCLADBGKCIA EOBOBBCNAJG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "kr");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 268f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA GOCBEJDJIAD(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "BS: On change language.");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1266f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void DEECDEBJIJB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "dogTagTimerLock");
	}

	public virtual FCLADBGKCIA GGOINMKALFG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_GUI_CHAT_SQUAD_KICK");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1989f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public override FCLADBGKCIA PerkImplementation(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void KNBLIGODKAJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "ArenaEnded");
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "ShieldRechargeRate");
	}

	protected virtual void ONJNBBOBCJK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_STAT_ALLTIMERUNS");
	}

	protected virtual void ENCLNAPOKGP(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "\n");
	}

	public virtual FCLADBGKCIA FDFKOEHEINC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "MINE");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 1008f + num;
		fCLADBGKCIA.AAHHALGKMNN = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA ANMBLLGJNAE(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "withAdvertiserSubAdgroup");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.CJIHIILEMMH = 909f + num;
		fCLADBGKCIA.AAHHALGKMNN = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void PJDFHGJEPOO(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMinigunner soldierBehaviourDefinititonMinigunner = (SoldierBehaviourDefinititonMinigunner)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMinigunner, FFCCFDJBLLD);
		soldierBehaviourDefinititonMinigunner.shieldRechargeRate += (float)base.excel.GetValue(FFCCFDJBLLD, "WithdrawerId");
	}
}
