using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;

public class UpgradeSlotsTank : UpgradeSlotsVehicle<DBUpgradeSlotsTank>
{
	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "CannonDamage");
		}
	}

	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			int rowIndex = upgradeSlot.boughtIndex;
			float val = (float)base.excel.GetValue(rowIndex, "damage");
			list.Add(new Tuple<string, float>("ID_SECONDWEAPONDAMAGE", val));
			return list;
		}
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> MOMOFDABHKK()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "ID_SLOTUPGRADE_DAMAGE");
		list.Add(new Tuple<string, float>("{0:3} {1}", val));
		return list;
	}

	protected virtual void LNJFOFINJFO(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ShowEngineerBuildingIndicator");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ActivityType");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Tickets");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GFIMEFOEPLO()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		float val = (float)base.excel.GetValue(rowIndex, "version");
		list.Add(new Tuple<string, float>("Lcom/google/android/gms/games/snapshot/Snapshots;", val));
		return list;
	}

	protected virtual void LDNGMGDGKOD(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_SQUADALREADYEXISTS");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Gunslinger");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_SQUADFULL");
	}

	protected virtual void IPPLGOIBDIC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Used {0} cards od rarity {1}");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, " failure. Server response = ");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_GUI_PLAYER");
	}

	[SpecialName]
	public virtual float CJHHFLDAMIB()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "LevelName");
	}

	[SpecialName]
	public virtual float NGEPCCOJOBB()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "SquadId");
	}

	protected virtual void GHODIBPLOHM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Buy_Army_Unit_Gold");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "{0}: {1}\n");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "SetBlinkIntervalRPC");
	}

	[SpecialName]
	public virtual float HKEMJOKCAOE()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, " ");
	}

	protected virtual void HAABBCFAEEP(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "visuals: {0} {1} {2} {3}");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "N");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Direct");
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMaxCannon");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMinCannon");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "CannonDamage");
	}

	[SpecialName]
	public virtual float LNADNMDPIDO()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "getLatitude");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LKGKBLFHOPO()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		float val = (float)base.excel.GetValue(rowIndex, " {0}\u00a0{1}");
		list.Add(new Tuple<string, float>("ID_ARENARULES_STRONGERUNITS", val));
		return list;
	}

	protected virtual void JMOOPHKCCPJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "OOOOPS");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "View_Stats");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "S");
	}

	protected override void HHAPKGDKJEF(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "NÃO");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "《WarFriends》需要權限才能存取你的媒體儲存檔以便下載關鍵資料。請接受以下所示的權限對話，我們絕不會將此權限使用在其他用途。");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "0");
	}

	protected virtual void PMHMENENDHI(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Tank");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "StarterAssignmentsData");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_SLOTUPGRADE_POWER");
	}

	protected virtual void PGCOOBEHFAG(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "N");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Time");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "/PC/");
	}

	[SpecialName]
	public virtual float MMIFCAOBPHP()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "Overtime_Was_Already_Explained");
	}

	[SpecialName]
	public virtual float GPEEGLNJENJ()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "AssetBundleManifestObjectt loaded");
	}

	[SpecialName]
	public virtual float KMCAGLDGEKI()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "308 GAME END");
	}

	protected override void CHBNPMNNOCG(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_GETSP");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "HELMETS_CROWNSILVER");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_INAPP_FAILED");
	}

	[SpecialName]
	public virtual float PPILOFBGPLJ()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "Scripts Full Path: \"{0}\"\n");
	}

	protected virtual void PILOCMCLPGL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Win");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMin");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "cardPack");
	}

	[SpecialName]
	public virtual float NOAHPDILHHP()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "\":\n");
	}

	protected virtual void PDBLCCLDKDP(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "'x'0");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_RANK");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "About to show Buy Cards Reminder");
	}

	protected virtual void HFAANHPMDGB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_READYTIME");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "FuseSDK_Prime31_IAB::GetSkuInfo: Error parsing ");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_NOSUCHPACK");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> NKIPNGFAEFH()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "ID_JOINSQUADUNLOCKED");
		list.Add(new Tuple<string, float>("ID_NOTIFICATION_DAILYREWARD_MESSAGE", val));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> CKEALLMIODL()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "ActionId");
		list.Add(new Tuple<string, float>("\"", val));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FAFHKANDBJC()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		float val = (float)base.excel.GetValue(rowIndex, "placement");
		list.Add(new Tuple<string, float>("Cards", val));
		return list;
	}

	[SpecialName]
	public virtual float LECDGGPECCE()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, " mSpriteName:");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> MECDHCHLBPN()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		float val = (float)base.excel.GetValue(rowIndex, "clipSize");
		list.Add(new Tuple<string, float>("MineCards", val));
		return list;
	}

	protected virtual void DEECDEBJIJB(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "#PETER# Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "NotificationsEnabled");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_ARENARULES_SHIELDSBREAKSLOWER");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PJCPHFNEKIH()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		float val = (float)base.excel.GetValue(rowIndex, "#PETER# BlackMarket offer came - show it!");
		list.Add(new Tuple<string, float>("purchaseToken", val));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> KMDLAGPBGEF()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "cancel");
		list.Add(new Tuple<string, float>("ID_TUTORIAL_NEWDRAGCARD", val));
		return list;
	}

	protected virtual void IHFCNLLFFBC(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Weapon {0} is purchasable through {1}");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "discount");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "RETRY");
	}

	protected virtual void MHOECCBIJGM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "bazooka_run");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "placement");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_READYTIME");
	}

	[SpecialName]
	public virtual float OKKENAGOLHA()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "ID_CLAIMED");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GFBIOGLMNFA()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "N");
		list.Add(new Tuple<string, float>("AddedCards", val));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> KABABKCILOP()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		float val = (float)base.excel.GetValue(rowIndex, "No main position was set in map definition");
		list.Add(new Tuple<string, float>("primary", val));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> CIHNJJEDHGJ()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "S");
		list.Add(new Tuple<string, float>("Position", val));
		return list;
	}

	protected override void KHNCEMPLEDG(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)BJOIGFEOMHN;
		tankBehaviourDefinititon.maxShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "Player_id");
		tankBehaviourDefinititon.minShootTimeCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "leagueId");
		tankBehaviourDefinititon.damageCannon += (float)base.excel.GetValue(FFCCFDJBLLD, "0");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FONJBFFCFEH()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		float val = (float)base.excel.GetValue(rowIndex, "LevelExperience");
		list.Add(new Tuple<string, float>("WENEEDTO", val));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> BGIMLGONLLA()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		float val = (float)base.excel.GetValue(rowIndex, "ID_TUTORIAL_GO_TO_ARMORY_3");
		list.Add(new Tuple<string, float>("ID_REMINDER_GETPOWERBANDTOINCREASE", val));
		return list;
	}

	[SpecialName]
	public virtual float PGIDKDIPPPO()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "audio/menu");
	}

	[SpecialName]
	public virtual float MMEPIELHDCM()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "GuaranteedScraps");
	}

	[SpecialName]
	public virtual float GIMIJJGAFMN()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "ID_REMINDER_VIPALMOSTEXPIRED");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FDFMALLCGHD()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		float val = (float)base.excel.GetValue(rowIndex, "A");
		list.Add(new Tuple<string, float>("In queue", val));
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> ADPJMLKOIKM()
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		int rowIndex = upgradeSlot.boughtIndex;
		float val = (float)base.excel.GetValue(rowIndex, "Evaluation is old! ");
		list.Add(new Tuple<string, float>("WarArenaData", val));
		return list;
	}

	[SpecialName]
	public virtual float NEFEJOFPPJD()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "D2");
	}
}
