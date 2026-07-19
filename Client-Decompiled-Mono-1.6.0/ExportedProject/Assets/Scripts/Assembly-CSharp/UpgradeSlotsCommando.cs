using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class UpgradeSlotsCommando : UpgradeSlotsBaseSoldier<DBUpgradeSlotsCommando>
{
	public override List<Tuple<string, float>> unitSpecifics
	{
		get
		{
			if (upgradeSlotSpecial.isBought)
			{
				List<Tuple<string, float>> list = new List<Tuple<string, float>>();
				float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "damage");
				float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "special");
				float val = num * num2;
				list.Add(new Tuple<string, float>("ID_POISONDAMAGE", val));
				return list;
			}
			return base.unitSpecifics;
		}
	}

	public virtual string HCEIBGCOFLP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "AdAvailabilityResponse(");
		int rowIndex = ACHJJKCIBCN.NGJIJEDDPNH();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "CZ");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> OHCDNIMGGMJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Cards choosen ", "queryInventorySucceededEvent. total purchases: {0}, total skus: {1}");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[7] = Mathf.Round(tuple.Value2[4] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string EPMCADJMLOD(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Showing squad details dialog with SQUADNAME = ");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Player profile - Show dialog for {0} from CACHE: {1}");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> HGPBGBJMCHA()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "customInt");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "menu-arena-scrap-ico");
			float val = num * num2;
			list.Add(new Tuple<string, float>("Game_Type", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> DGLDMPNCKPD(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Show {0} invitation dialog id: {1}", "Region");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[6] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> HLOADBGHJFE()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "offerMult");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "Play_Card_Tutorial");
			float val = num * num2;
			list.Add(new Tuple<string, float>("\":\n", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string HCEPCNJOOEO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PPKAIEKPNID();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "WarFriends requer permissão para aceder aos ficheiros de armazenamento de media para descarregar dados críticos de jogo.Sem essa permissão o jogo não poderá funcionar adequadamente e será encerrado. Por favor, tente novamente ou encerre WarFriends.");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "LevelName");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PBDLNOLPHDC()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "global");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "YES");
			float val = num * num2;
			list.Add(new Tuple<string, float>("Hearts", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string KCKCEPJEKEE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "localSquadLeaderboard");
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_ARENARULES_UNBREAKABLESHIELDS");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string ODEINKHFDIG(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "com/google/android/gms/common/ConnectionResult");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "Unfreeze ");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string DECJEAIPNAP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Play_Card_Tutorial_Duration");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "$5-$10");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PKOAKACFKAN()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "BotWeaponPower");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "ID_READYTIME");
			float val = num * num2;
			list.Add(new Tuple<string, float>("hasConnectedApi", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string MGCBNDHECAK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_GOLDPACK");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Fb_login");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string HMAPLOCANBP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ReSyncDisabledRPC");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_STARTERASSIGNMENT6");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> LAEGALELAFK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "0.0.0", "ID_ISALREADYMEMBEROFANOTHERSQUAD");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[2] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string JPBMBNALMPJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "DRIVE_EXTERNAL_STORAGE_REQUIRED");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Enemy could not be spawned");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string FJPNKKIAKCK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "game-label-you-red");
		int rowIndex2 = ACHJJKCIBCN.NGJIJEDDPNH();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex2, "menu-attack-ico");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string NIOPOBIPMDG(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_ARENAFLAWLESS");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "ADDING POWERBAND ON CLIENT ");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string LAJCAAMLPII(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Sniper_Tutorial_Duration");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_LOOTBOXES");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string JKBOMIICBFM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "()Lcom/google/android/gms/common/api/Status;");
		int maxIndexInExcel2 = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel2, "LootBoxShowUp");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FOFFJGAMJID()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), " OK!");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "Gold_Balance");
			float val = num * num2;
			list.Add(new Tuple<string, float>("SheetConfig", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string BNFHNNPJNMP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "Region");
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Get player data: I WILL TRY TO SEND PN DEVICE TOKEN");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string GNNKADMBBEP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "워프렌즈는 이 추가 데이터를 다운로드 받지 않으면 실행할 수 없습니다. 정말 종료하시겠습니까? 아니면 데이터를 다운로드 받으시겠습니까?");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "CURRENT PLAYER - depositedCardsDic is null");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> NIFFEJGBBFH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "D2", "ID_TUTORIAL_START_PHASE2");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[3] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> ELNHNHLGFIE()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_ARENARULES_NOWARCARDS");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "-DESCRIPTION");
			float val = num * num2;
			list.Add(new Tuple<string, float>("FuseBoxx: Session Login Error, code = ", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public override string GetAbilityMaxValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "damage");
		int maxIndexInExcel2 = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel2, "special");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> LJFNDNJFINE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "確認", "DeployHeli");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[6] = Mathf.Round(tuple.Value2[1] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FEKJIDGICGM()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_CONFIRM_ERRORCLAIMREWARD_TEXT");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "globalPlayerLeaderboard");
			float val = num * num2;
			list.Add(new Tuple<string, float>("ID_LOADING", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> HEIIAGCIKIK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "already in clan (in cache)", "TW");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[5] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string ANDEIHHMFAN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.NGJIJEDDPNH();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "FuseSDK: Error parsing RewardInfo. Returning default value.");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "ExpireTime");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string MFBBEKHFMLL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.NGJIJEDDPNH();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "com/google/android/gms/common/ConnectionResult");
		int rowIndex2 = ACHJJKCIBCN.NGJIJEDDPNH();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex2, "N0");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> BGIMLGONLLA()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "BurstSize");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "ID_REPORTUSER_ITEM2");
			float val = num * num2;
			list.Add(new Tuple<string, float>("ID_ARENASHORTCUTEVENTSTART", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> GCLDBFDJJPP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "WaveCoolDown", "Not a gold reward.");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[0] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string CFKBCFKCONF(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "false");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Buffer already sent!");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string DNHBDHDAGDI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PPKAIEKPNID();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Sessions");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "menu-weapon-mp5-elite");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> OMMNMKCAKGM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "qbz2_idle", "+{0}");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[5] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string FAIHIFALJEN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "TimeOfMatch");
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_VIPTIME");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> OCNMONJHEAA()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_CONFIRM_SQUADISNOTPUBLIC");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "SPAWNCOUNT");
			float val = num * num2;
			list.Add(new Tuple<string, float>("TryActivateBonusRPC", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string PDLBHHIMLJH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_LOADING");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "ID_STAT_ACCURACY");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> IFJEPMFEOCI()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_ASSIGNMENTHINTWARPATH");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "Grenade_Throwing_Tutorial_Duration");
			float val = num * num2;
			list.Add(new Tuple<string, float>("MinDamage", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string JEJEAJPNJGH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "ID_GOLD");
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_CONFIRM_SQUADLEAVEERROR");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string LCNCJPKABLM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "PhotonConnectionManager: ConnectToPhotonSafe ");
		int maxIndexInExcel2 = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel2, "ID_REPORTUSER_ITEM0");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GMDOHCOAAIK()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Bad inventory data, data= ");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "de");
			float val = num * num2;
			list.Add(new Tuple<string, float>("BuyHearth-{0}", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> MNCFGFKKKAP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "DAILY REWARDS - currently locked!", "GameLauncher.Async done");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[7] = Mathf.Round(tuple.Value2[3] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FDFMALLCGHD()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "expireTime");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "League: {0}  LeagueId: {1}  LeagueDivision: {2}  WeeklyMedals: {3}  GLobalMedals: {4}");
			float val = num * num2;
			list.Add(new Tuple<string, float>("#AccoutCheck# OnCheckFacebookInTutorial: ", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> HAJBGPEIKJN()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "Buy_Lootboxes");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "PlayerGold");
			float val = num * num2;
			list.Add(new Tuple<string, float>("Player disconected 0001", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PJCPHFNEKIH()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "+");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "player_level");
			float val = num * num2;
			list.Add(new Tuple<string, float>("MaxBattles", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> OLNCELGINIC()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "ID_MINUTES");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "ID_YOUMANAGEDTOWINXARENABATTLESYOU");
			float val = num * num2;
			list.Add(new Tuple<string, float>("true", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string IBMAMJICNDG(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "ID_BECOMEAVIP");
		int maxIndexInExcel2 = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel2, "Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot accept player");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> ADPJMLKOIKM()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "PA: gold spent ");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "Password");
			float val = num * num2;
			list.Add(new Tuple<string, float>("setExistingUser", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> CLBLKCEIKGD(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "()I", "Display_Rating_Box");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[8] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string BLPEIKDIFHI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "menu-army-cat-shooter");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_SILVERWARCARDS");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> NFFBDABMJDG()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_PROMOTEDTODIVISION");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "country-netherlands");
			float val = num * num2;
			list.Add(new Tuple<string, float>("false", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string AIAJPALDKJK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "[]");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "ID_CONFIRM_LOGINFAILURE");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> JCCEPGPALKM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "_SceneFogParams", "Stage");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[4] * num);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> KGFHHHEPAMP(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "([,.!\\?-_:;]|\\s)", "120 MENU LEVEL UP SHOWN");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[8] = Mathf.Round(tuple.Value2[4] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> ILBKCKFPKGP()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "WarFriends");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "USD");
			float val = num * num2;
			list.Add(new Tuple<string, float>("{0} Army Icon LVL{1} ORDER{2}", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string KBHGAMPCKFJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.CFBCGGMBJGB();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "TimeStamp");
		int rowIndex2 = ACHJJKCIBCN.CFBCGGMBJGB();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex2, "Wrong_Category");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FADODKMMFOP()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Level");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "ID_CONFIRM_SERVERERROR");
			float val = num * num2;
			list.Add(new Tuple<string, float>("ID_GUI_DELIVERING", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> BJICHMIGMEC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "gameCenterId", "#ATLASSEARCH# ");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[0] * num);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> OFHOCMAJCEL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "VISUAL = NULL", "+");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[8] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> NOMBLFGCOOL()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "primary");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "ID_TUTORIAL_UPGRADEWEAPON_9");
			float val = num * num2;
			list.Add(new Tuple<string, float>("{0} == {1}", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> BHCLLGFHMOE()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "SquadEventProgress");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "GooglePlay");
			float val = num * num2;
			list.Add(new Tuple<string, float>("Ranks/", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LFGKGIFKPFK()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "{0}{1}{2} {3}{4}");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "UNKNOWN FUSEBOXX CONFIGURATION KEY = ");
			float val = num * num2;
			list.Add(new Tuple<string, float>("after update GC still GC account, but no added or missing gcID or gcPassword", val));
			return list;
		}
		return base.unitSpecifics;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> PCCFCNGPDGI()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "HeroicMissionsCompletionRewardCardPack");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "KR");
			float val = num * num2;
			list.Add(new Tuple<string, float>("Is_Against_Bot", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string NFEDDJBPOIK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.NGJIJEDDPNH();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Reason");
		int maxIndexInExcel = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "0$");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string KFKGEDLCOFB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "N");
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "game-card-ico-explosivetiming");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FONJBFFCFEH()
	{
		if (upgradeSlotSpecial.BDAAHLLPPGN())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PPKAIEKPNID(), "longValue");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "Units generated");
			float val = num * num2;
			list.Add(new Tuple<string, float>("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string DLMPGNFMNCI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Key = ");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "game-card-ico-streakboost-full");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> BOMLACBAFAH(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_CONFIRM_SERVERERROR", "Battle_End_Dialog");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[1].Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[5] = Mathf.Round(tuple.Value2[7] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> MNNLNGPLIJA()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "ID_CONFIRM_NOSQUADACTIONS_TITLE");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, " 1\u00a0{0}");
			float val = num * num2;
			list.Add(new Tuple<string, float>("SH: Init", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string INBELFENKLB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, " (#");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "D2");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string GLEFHNIMMBN(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PPKAIEKPNID();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Card_3_Played");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Scenes to go through: {0}");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string KDGCLLFAFFM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "BlackMarketMessage-{0}");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "ID_STAT_GLOBALXP");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> DAECKIKMOLC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "damage", "Yes_Clicked");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[5] * num);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> JIOHEFMGJAM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Squad Event Ended. Squad completed ", "game-missions-blue-mission-ico");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> ANENEDDNGBK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Google2u.Grenade_FRAG", "Added");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[1].Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[7] = Mathf.Round(tuple.Value2[3] * num);
		list.Add(tuple);
		return list;
	}

	public override List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "special", "damage");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[2] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string KPEPJHBGOIL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "Fuseboxx: virtual goods offer accepted wtih object ");
		int rowIndex = ACHJJKCIBCN.CFBCGGMBJGB();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "!!!UNDER TABLE!!! ");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> LBEOGHJFDBE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Id", "Spend_Gold_On_Army");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[7] = Mathf.Round(tuple.Value2[4] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string MLLECIBIIGA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "otherInfo");
		int maxIndexInExcel2 = ACHJJKCIBCN.maxIndexInExcel;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel2, "Reported");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> MPDMBPDBCIK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Regions", "{0} {1}");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> GFJHJOKKKEL(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_ASSIGNMENTHINTCRATES", "()Lcom/google/android/gms/games/stats/PlayerStats;");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[1].Value2[1]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[4] = Mathf.Round(tuple.Value2[8] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string HJIEDDHNAEC(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.boughtIndex;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "mortar_down_idle");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "PACK");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> ANKLKEAJHBB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_WARNING_ERRORCLAIMASSIGNMENT", " ");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[2] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string GLFDFGBGOAE(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int maxIndexInExcel = ACHJJKCIBCN.owner.upgradeSlot.maxIndexInExcel;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(maxIndexInExcel, "DogTagMax");
		int rowIndex = ACHJJKCIBCN.NGJIJEDDPNH();
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_CRAFTING");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> HBMLGHIGFBI(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "BAND_REWARD_RELOAD", "{0}{1}[-] {2}/[-] 3");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[1].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[7] = Mathf.Round(tuple.Value2[8] * num);
		list.Add(tuple);
		return list;
	}

	public override string GetAbilityCurrentValue(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.boughtIndex;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "damage");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "special");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual string LFDPDNDENHM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.boughtIndex;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "Days_Since_Install");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "getTime");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> GGOMPHHHJEA(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Tutorial_Step_Complete", "GameLauncher.LoadMainScene OBB");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[0].Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[8] = Mathf.Round(tuple.Value2[7] * num);
		list.Add(tuple);
		return list;
	}

	public virtual List<Tuple<string, float[]>> OMMNODCIOFO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "Wrong_Weapon", "ArmyPower");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[0]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[5] = Mathf.Round(tuple.Value2[6] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string BOAKANAHDBJ(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.PAKKPEPIHPK();
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "NEW TOP RUN = ");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "Assignment: Error, task definition not found for id = ");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> HECMACODOGB()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "apple");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "C0");
			float val = num * num2;
			list.Add(new Tuple<string, float>("Checker", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual List<Tuple<string, float[]>> CHOAINBBFAO(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_TUTORIAL_PROGRESS_KILLING2", "menu-squad-{0}");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.guiStatistics[0].Value2[1]);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[1] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[2] = Mathf.Round(tuple.Value2[2] * num);
		list.Add(tuple);
		return list;
	}

	public virtual string LGMMBIAOFGM(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.boughtIndex;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "ID_READYTIME");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "AtlasPreparer - WHITENING ATLAS ");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	public virtual List<Tuple<string, float[]>> IFFHLDFEKEB(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		Tuple<string, float[]> tuple = StatsFor(ACHJJKCIBCN, "ID_DOUBLEGOLD", "NON");
		float num = LevelManager.instance.DamageFunction(upgradeSlot.NEJNMDNOAKD()[1].Value2[0]);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[0] * num);
		tuple.Value2[0] = Mathf.Round(tuple.Value2[1] * num);
		tuple.Value2[3] = Mathf.Round(tuple.Value2[4] * num);
		list.Add(tuple);
		return list;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> BOMAPKBADCN()
	{
		if (upgradeSlotSpecial.isBought)
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.PAKKPEPIHPK(), "SquadId");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "ID_FREEPERCENT");
			float val = num * num2;
			list.Add(new Tuple<string, float>("player name", val));
			return list;
		}
		return base.unitSpecifics;
	}

	public virtual string KOLPKHJIFOK(UpgradeSlotSpecial ACHJJKCIBCN)
	{
		int rowIndex = ACHJJKCIBCN.owner.upgradeSlot.boughtIndex;
		float num = (float)ACHJJKCIBCN.owner.excel.GetValue(rowIndex, "OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}");
		int boughtIndexAbsolute = ACHJJKCIBCN.boughtIndexAbsolute;
		float num2 = (float)ACHJJKCIBCN.owner.excel.GetValue(boughtIndexAbsolute, "RewardId");
		float fFHHEHHFOKJ = num * num2;
		return MEJMLNDFDBP.MAJBCINJAGF(fFHHEHHFOKJ);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LIFKJPGGKLM()
	{
		if (upgradeSlotSpecial.JFAELKHPLLA())
		{
			List<Tuple<string, float>> list = new List<Tuple<string, float>>();
			float num = (float)base.excel.GetValue(upgradeSlot.boughtIndex, "Cards");
			float num2 = (float)base.excel.GetValue(upgradeSlotSpecial.boughtIndexAbsolute, "ID_CONFIRM_STARTUPERROR_TEXT");
			float val = num * num2;
			list.Add(new Tuple<string, float>("RETRYPERM", val));
			return list;
		}
		return base.unitSpecifics;
	}
}
