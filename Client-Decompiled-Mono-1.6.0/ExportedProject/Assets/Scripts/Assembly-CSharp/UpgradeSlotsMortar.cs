using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsMortar : UpgradeSlotsBaseSoldier<DBUpgradeSlotsGrennader>
{
	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int rowIndex = upgradeSlot.boughtIndex;
			list.Add(new Tuple<string, float>("ID_MORTARBUILDTIME", (float)base.excel.GetValue(rowIndex, "mortarBuildTime")));
			return list;
		}
	}

	public override bool isSpecificTime
	{
		get
		{
			return true;
		}
	}

	protected virtual void IMCCMGBJNFB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "SIGN_IN_REQUIRED");
	}

	[SpecialName]
	public virtual bool BMFIEGFKFCF()
	{
		return true;
	}

	[SpecialName]
	public virtual bool IHPCFOGJEHJ()
	{
		return true;
	}

	public virtual FCLADBGKCIA FDFKOEHEINC(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "Twitch");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1555f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void CGIEKLJEGOC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "Sessions");
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

	protected virtual void PJDFHGJEPOO(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "special");
	}

	[SpecialName]
	public virtual bool ODDOOPNGOOM()
	{
		return false;
	}

	protected virtual void NGMKJIHFCJA(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "key= ");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> ADPJMLKOIKM()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		list.Add(new Tuple<string, float>("PlayerId", (float)base.excel.GetValue(rowIndex, "WarFriendsは、この追加データのダウンロードなしでは動作しません。やめてもよいですか？またはデータをダウンロードしますか？")));
		return list;
	}

	public virtual FCLADBGKCIA FJLCDAGEGEA(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_READYTIME");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 46f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.OCDCNFLDNEP(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void EGGDBGBIEDK(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "Anticheat");
	}

	public virtual FCLADBGKCIA OBMFFBFMEOI(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "MoneyPackTimeLimitedOffer");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 938f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.CGIKCOFAHDE(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	public virtual FCLADBGKCIA ILDNBIPFKGJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "RETRY");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 995f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.JNGHOGBNJPC(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> CIHNJJEDHGJ()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		list.Add(new Tuple<string, float>("BG", (float)base.excel.GetValue(rowIndex, "VipReward1")));
		return list;
	}

	public virtual FCLADBGKCIA APCLCIPDCBA(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 1, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "GameCenterProvider function PlayerLoggedOutEvent() called => GC: Player logged out event - can autenticate fail: ");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1216f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected virtual void GHODIBPLOHM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "shootAdditive");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GMDOHCOAAIK()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		list.Add(new Tuple<string, float>("ID_SALEPERCENT", (float)base.excel.GetValue(rowIndex, "ID_BATTLEINARENA")));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> JNFPDMNEKAO()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		list.Add(new Tuple<string, float>(" AFTER: critical: ", (float)base.excel.GetValue(rowIndex, "Key = ")));
		return list;
	}

	protected virtual void NLJLKCJLCHH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "com/google/android/gms/common/ConnectionResult");
	}

	protected virtual void CFFIJLOCCJB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "PowerBandExpiresOn");
	}

	public virtual FCLADBGKCIA KNEKNPKMHBJ(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "chatmessage");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1609f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.NDOKEJMONCB(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual bool MIJJEILKNMI()
	{
		return false;
	}

	[SpecialName]
	public virtual bool LMHNKAIAKCH()
	{
		return true;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LBGANDNNHNB()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		list.Add(new Tuple<string, float>("ID_ARENAWINS", (float)base.excel.GetValue(rowIndex, "Card_2_Played")));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FONJBFFCFEH()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		list.Add(new Tuple<string, float>("ammo", (float)base.excel.GetValue(rowIndex, "SHOW WAR ARENA DIALOG!!")));
		return list;
	}

	protected virtual void GELJGONICCH(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "Buggy");
	}

	[SpecialName]
	public virtual bool KPBDGIFPALC()
	{
		return true;
	}

	[SpecialName]
	public virtual bool GFAGGNKOCFE()
	{
		return false;
	}

	[SpecialName]
	public virtual bool CDGKAKAMGEM()
	{
		return true;
	}

	public virtual FCLADBGKCIA ANMBLLGJNAE(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "TimeOfMatch");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1361f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 1;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)BJOIGFEOMHN;
		base.IPGEHGPGGKL((BehaviourDefinititon)soldierBehaviourDefinititonMortar, FFCCFDJBLLD);
		soldierBehaviourDefinititonMortar.mortarBuildTime += (float)base.excel.GetValue(FFCCFDJBLLD, "mortarBuildTime");
	}

	public virtual FCLADBGKCIA ADNCEJPLPFM(UnitUpgradeDefinition BJOIGFEOMHN, FCLADBGKCIA NCKMDDFDHKI)
	{
		int rowIndex = Mathf.Clamp(BJOIGFEOMHN.unitUpgrades.slotUpgradeIndexElite, 0, base.excel.RowsGeneric.Count);
		float num = (float)base.excel.GetValue(rowIndex, "ID_TUTORIAL_GO_TO_ARMORY_4");
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		fCLADBGKCIA.ACKOHPCAOEA = 1065f - num;
		fCLADBGKCIA.GLOMGLHDKNI = 0;
		FCLADBGKCIA lGNIBPKIMNN = fCLADBGKCIA;
		return FCLADBGKCIA.COCEIANAAJJ(lGNIBPKIMNN, NCKMDDFDHKI);
	}

	[SpecialName]
	public virtual bool CBDKGILKJFB()
	{
		return true;
	}

	[SpecialName]
	public virtual bool DHNHMNNCIAG()
	{
		return false;
	}
}
