using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsGrennader : UpgradeSlotsBaseSoldier<DBUpgradeSlotsShotgunner>
{
	public override string shotDamageName
	{
		get
		{
			return Localization.Localize("ID_GRENADEDAMAGE");
		}
	}

	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "GrenadeExplodeDamage");
		}
	}

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int rowIndex = upgradeSlot.boughtIndex;
			float val = (float)base.excel.GetValue(rowIndex, "damage");
			list.Add(new Tuple<string, float>("ID_PISTOLDAMAGE", val));
			return list;
		}
	}

	protected virtual void CFFIJLOCCJB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "DepositedCards");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Cards");
	}

	[SpecialName]
	public virtual float GCLFFCBCMCF()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "N");
	}

	public virtual FCLADBGKCIA OACAPIGGDHI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "0.00");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 1695f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.IAODDBOALFF(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "GrenadeExplodeDamage");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "GrenadeMinDamage");
	}

	protected virtual void FHJNHBELHOD(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, ", keys.Length = ");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_ACTIVATION");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FAFHKANDBJC()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		float val = (float)base.excel.GetValue(rowIndex, "ID_WARSHOP_MEMBERSHIP");
		list.Add(new Tuple<string, float>("Gold_Balance", val));
		return list;
	}

	protected virtual void DEECDEBJIJB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Waiting too long to start match, Match start: {0} photon time: {1}");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "S");
	}

	public virtual FCLADBGKCIA EMGONALHMDD(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "DogTagSeconds");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 1568f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA KGPCCDKCPBG(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Mode");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 770f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void KHNCEMPLEDG(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "()Z");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "DepositedCards");
	}

	[SpecialName]
	public virtual string IPHFLHMOADC()
	{
		return Localization.Localize("ID_MINUTES");
	}

	protected virtual void MFPCNEBGHBN(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_PLAYERLEAGUE");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "GameController.Start START");
	}

	public virtual FCLADBGKCIA ADNCEJPLPFM(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ItemID");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 646f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void OINFGPBIOMN(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "discount");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_GUI_SQUADLEVELEDUP_NOINCR");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LKGKBLFHOPO()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		float val = (float)base.excel.GetValue(rowIndex, "Token");
		list.Add(new Tuple<string, float>("dogtagTimerLockTime: ", val));
		return list;
	}

	[SpecialName]
	public virtual float JDCGBDNBHNP()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "DogTagMax");
	}

	public virtual FCLADBGKCIA LEIFMDPNAAC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Shots_Hits");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 324f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void KMHIABAKPOI(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "country-brazil");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "RewardGold");
	}

	[SpecialName]
	public virtual float JBLFGNNMFIH()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "ID_MIN");
	}

	protected virtual void PILOCMCLPGL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "NULL");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "N0");
	}

	[SpecialName]
	public virtual string BPHGIMFPPDK()
	{
		return Localization.Localize("setTwitterUserId");
	}

	public virtual FCLADBGKCIA NJLAJHFEIFN(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Starting match against bot");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 951f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> DMLOLNJMOHC()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		float val = (float)base.excel.GetValue(rowIndex, "PromotedPlayerId");
		list.Add(new Tuple<string, float>("ID_FEATURE_DAMAGE", val));
		return list;
	}

	protected virtual void OLBOBDCGIKH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "N");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_ELITEPACK_UNITDESCRIPTION");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GMDOHCOAAIK()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		float val = (float)base.excel.GetValue(rowIndex, "menu-close");
		list.Add(new Tuple<string, float>("percent", val));
		return list;
	}

	[SpecialName]
	public virtual float LADDMGGFALC()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "ID_GC_LOGOUT_TITLE");
	}

	[SpecialName]
	public override float OKKENAGOLHA()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "LevelExperience");
	}

	protected virtual void PJDFHGJEPOO(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_LOWACTIVITY_TITLE");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_NO");
	}

	protected virtual void GEGNJCCJHNA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_TUTORIAL_KILLING_SCOPE");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_YOUNEEDMONEYTOUPGRADE");
	}

	protected virtual void JMOOPHKCCPJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "RweardModifierWB");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_YOUNEEDMONEYTOUPGRADEELITE");
	}

	[SpecialName]
	public virtual float NFECDGBCLCM()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "-[0-9]*$");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> MECDHCHLBPN()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "Password");
		list.Add(new Tuple<string, float>("Set match state: ", val));
		return list;
	}

	public override FCLADBGKCIA PerkImplementation(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "elite");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 1f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void GPEEFKNEFOK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot accept player");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "WarFriends non può funzionare senza scaricare questi dati aggiuntivi. Vuoi davvero USCIRE o vuoi scaricare i dati?");
	}

	[SpecialName]
	public virtual float HDIGKHDEDKO()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "ID_STATE_CONNECTINGTOSERVER");
	}

	[SpecialName]
	public virtual string HLKECEKPKFC()
	{
		return Localization.Localize("Received old game invite ( > {0} seconds). Not showing dialog. Opponent = {1}");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> KMDLAGPBGEF()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "ID_READYTIME");
		list.Add(new Tuple<string, float>("Gold", val));
		return list;
	}

	protected override void JHLLBDBFMNJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "reloadTime");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_ARENARULES_DEFENDERSPROHIBITED");
	}

	[SpecialName]
	public virtual string LOOIOKFCNCM()
	{
		return Localization.Localize("menu-assignments-type-deploy");
	}

	[SpecialName]
	public virtual string BNIPAOMMHMM()
	{
		return Localization.Localize("RewardMessage");
	}

	protected virtual void BOBDDINODDK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonGrennader, FFCCFDJBLLD);
		soldierBehaviourDefinititonGrennader.grenadeExplodeDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_INSTANTBATTLEHINT2");
		soldierBehaviourDefinititonGrennader.grenadeMinDamage += (float)base.excel.GetValue(FFCCFDJBLLD, "Buy_Rental_Power_Band_Gold");
	}

	public virtual FCLADBGKCIA OBMFFBFMEOI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "qbz_idle");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 761f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> OEJAHGFAPPK()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		float val = (float)base.excel.GetValue(rowIndex, "ArmyPower");
		list.Add(new Tuple<string, float>("\"{0}\"", val));
		return list;
	}

	public virtual FCLADBGKCIA HKCOEENHGLO(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_SQUADEMPTYTEXT-COOP");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.BAHEFCJKPIP = 30f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> IHLOJOFINCO()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "Level");
		list.Add(new Tuple<string, float>("Custom Verification", val));
		return list;
	}

	[SpecialName]
	public virtual float JNNHJCJGKDH()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "ID_XOFPLAYERSGETSRELEGATED");
	}

	[SpecialName]
	public virtual float GHPBEGDBFPB()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "1");
	}
}
