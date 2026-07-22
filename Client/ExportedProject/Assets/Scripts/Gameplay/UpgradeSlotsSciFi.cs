using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsSciFi : UpgradeSlotsBaseSoldier<DBUpgradeSlotsSciFi>
{
	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "GrenadeExplodeDamage");
		}
	}

	protected virtual void NMDMABMOLNH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_READYTIME");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "version");
	}

	protected virtual void PILOCMCLPGL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "{0} {1}");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_STATE_FRIENDISREADYTOBATTLE");
	}

	[SpecialName]
	public virtual float EPIKGOGPLPA()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "colt_idle01");
	}

	protected virtual void HFAANHPMDGB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_ERROR");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "These IDs have the same translations:\n");
	}

	protected virtual void DHBIAELMILA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "{0} {1}");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "game-elite-debuff2");
	}

	[SpecialName]
	public virtual float GPEEGLNJENJ()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "ID_CATEGORY_ASSAULTRIFLE");
	}

	protected virtual void IHFCNLLFFBC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "PlayerGold");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_YOUNEEDMONEYTOUPGRADE");
	}

	[SpecialName]
	public virtual float PGIDKDIPPPO()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "GLM: Add FB to custom account");
	}

	[SpecialName]
	public virtual float IPBAEIEHCAN()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "N");
	}

	protected virtual void IPPLGOIBDIC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "#AccoutCheck# Switching to GC account");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "game-engi-progress-bg");
	}

	public virtual FCLADBGKCIA CBINLBJBOEK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "304 STAGE 9 CONTINUE");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 720f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA DONFACOLCFE(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "LT");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 336f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float ECDPJAEKFOO()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "Position");
	}

	public virtual FCLADBGKCIA DHCDLIFGLKN(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "GoldCoefficient");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1118f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA FONMBGAANKI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_SUBSCRIPTIODETAILS_HINT3GOOGLE");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 857f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float MPEKDCCMEGP()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "MoneyPackDeadline");
	}

	[SpecialName]
	public virtual float PGMEABEFOLF()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "GoldReward{0}Min");
	}

	public virtual FCLADBGKCIA NCKOAFOBCCB(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_VISUALCATEGORYPARTS2");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 347f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA IBOCNJAIOFA(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_NOTIFICATION_DAILYREWARD_GOLD");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1605f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float NFECDGBCLCM()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "GoldBoxes");
	}

	public virtual FCLADBGKCIA ILDNBIPFKGJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "_SceneFogParams");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1597f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA LCNBGEPPMLO(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "BlackMarketOffer");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 911f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA IGGFLBFJJBO(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_CONFIRM_MAXCCUREACHED");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 738f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "GrenadeExplodeDamage");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "GrenadeMinDamage");
	}

	public virtual FCLADBGKCIA LKOJCHPLGFI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_FACEBOOKLOGOUTLEGALTEXT2");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 25f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float BNDIJBAEKDP()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, ")");
	}

	protected virtual void OPLOAODAGGB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_WARNING_CANTSENDINVITE");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "AssetBundleManifest downloaded assets count: {0}");
	}

	[SpecialName]
	public virtual float DICOLFELKDG()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "Card_3_Played");
	}

	protected virtual void DLBBANHBPLA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_GPGS_LOGIN_TUTORIAL_TEXT");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "test_attribute1");
	}

	[SpecialName]
	public virtual float DDFMACKDNEP()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "game-ico-blind");
	}

	public virtual FCLADBGKCIA DBBJMKKEJCK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "menu-weapon-benelli-starterpack");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 557f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void AGAAHJPHNML(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "BUYING CARD PACK: type:{0} -> cardType:{1}");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_TUTORIAL_GO_BUY_ARMY_2_DOWN");
	}

	public virtual FCLADBGKCIA ADNCEJPLPFM(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "CoolDown");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 653f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void CGCLGNJBEFE(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ERROR CLAIM ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "FR");
	}

	protected virtual void PMLBHJGBNFD(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "1");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Tank could not be spawned");
	}

	[SpecialName]
	public virtual float NLJCCCGDHEJ()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "Action ");
	}

	protected virtual void PFNBCPAMCML(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Xp");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_NO");
	}

	[SpecialName]
	public override float NOAHPDILHHP()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "Id");
	}

	[SpecialName]
	public virtual float GIMIJJGAFMN()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "SquadMembers");
	}

	protected virtual void NBHGNKIOLCM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_ARENARULES_BRONZEWARCARDS");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "elite2");
	}

	[SpecialName]
	public virtual float KKLNBOKMPAC()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "ID_CONFIRM_GAMECENTER");
	}

	public virtual FCLADBGKCIA HKCOEENHGLO(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "WarFriends");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1409f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float HADLIKDFCFL()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "[.,]*");
	}

	[SpecialName]
	public virtual float IPIJKPDNOHN()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "YES");
	}

	public override FCLADBGKCIA PerkImplementation(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA NJLAJHFEIFN(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_HEROICMISSIONS1");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 106f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA BCAOHCCJIED(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "PlayerGold");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 683f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float HNCGDGELCEO()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "ID_BUDDYCARD");
	}

	[SpecialName]
	public virtual float PAEGGNCMFPC()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "ID_SALEPERCENTLINE");
	}

	[SpecialName]
	public virtual float ABNNMFDKCLH()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "EventAssignmentClaimed");
	}

	public virtual FCLADBGKCIA FOILDKAGBHK(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "This labels must be done manualy (add sprite spacer arround):\n");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 871f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void EPDPCENBFNA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "^[0-9]*-");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Spawned by card:  progress:{0}, obj: {1},uu: {2} ");
	}

	public virtual FCLADBGKCIA OLFMCIIGONH(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_TUTORIAL_UPGRADEWEAPON_3");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1933f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float EHDDONPMJJN()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "WarBucks");
	}

	public virtual FCLADBGKCIA FCIMIIKKMHL(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_RANDOMWARCARDS");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1408f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float JDFKNDKNJHB()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "ID_CONFIRM_EXIT");
	}

	protected virtual void LNJFOFINJFO(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "throw_grenade_right");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "withOfferId");
	}

	protected virtual void KHNCEMPLEDG(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "\t\"FALSE\"");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "{0} {1}{2}");
	}

	protected virtual void KMHIABAKPOI(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Action ");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "DeviceToken");
	}

	public virtual FCLADBGKCIA MCDFNLGNLPF(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "CardRarity");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 752f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual float GCLFFCBCMCF()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "ID_CONFIRM_EXITINGMATCH");
	}

	protected virtual void CGIEKLJEGOC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "leagueDiff");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "WALLET - reward GOLD {0} animate:{1}");
	}

	protected virtual void ADOPFDABJFD(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_WARNING_NOTENOUGHGOLDARENA");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "shield_idle");
	}

	[SpecialName]
	public virtual float GHFFHLOLKCH()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "ID_READYTIME");
	}

	protected virtual void ILABCNMIGCF(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "menu-cards-bronzepack");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "MaxBattles");
	}

	protected virtual void FNEABDKLLDL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_SECOND");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_DEBUG_EVENTASSIGNMENTUPDATE");
	}

	public virtual FCLADBGKCIA KHBGIOMMLOF(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ZoneHasVirtualGoodsOffer");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.JNLLKFGHMNI = 1095f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void PNJEJJKJEDG(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonSciFi, FFCCFDJBLLD);
		soldierBehaviourDefinititonSciFi.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "A");
		soldierBehaviourDefinititonSciFi.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "null");
	}
}
