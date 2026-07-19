using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class LevelManager : DatabaseSerializedObjectGeneric<LevelManager.LevelManagerData>
{
	public class ItemDelivery
	{
		public bool activationNeeded;

		public int boughtIndex;

		public long end;

		public string itemId;

		public int slotId;

		public long start;
	}

	public class LevelManagerData
	{
		public Dictionary<string, SavedArmySlots> savedArmies = new Dictionary<string, SavedArmySlots>();

		public Dictionary<string, SavedWeaponSlots> savedWeapons = new Dictionary<string, SavedWeaponSlots>();

		public ItemDelivery unitDelivery = new ItemDelivery();

		public ItemDelivery weaponDelivery = new ItemDelivery();

		public int GetRemainingUnitDelivery()
		{
			LevelBehaviour levelBehaviour = instance.DeliveringUnit();
			return (!(levelBehaviour == null)) ? ((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds) : 0;
		}

		public int GetRemainingWeaponDelivery()
		{
			WeaponLevelsSetup weaponLevelsSetup = instance.DeliveringWeapon();
			return (!(weaponLevelsSetup == null)) ? ((int)weaponLevelsSetup.remainingDeliveringSeconds) : 0;
		}
	}

	public class SavedArmySlots
	{
		public bool bought;

		public int boughtIndex;

		public int specialSlot;

		public bool showed;

		public int tier;

		public bool borrowed;

		public bool wasEquipped;

		public bool equipped;

		public int eliteSlot;

		public int parts;
	}

	public class SavedWeaponSlots
	{
		public bool bought;

		public int boughtIndex;

		public bool showed;

		public bool borrowed;

		public int specialFeature;
	}

	[Serializable]
	public class GameLevel
	{
		public int index;

		public LevelsRow row;

		public int displayNumber
		{
			get
			{
				return index + 1;
			}
		}

		public string displayString
		{
			get
			{
				return MEJMLNDFDBP.GMIPFLIEOHD(displayNumber);
			}
		}

		public string iconName
		{
			get
			{
				return displayNumber.ToString();
			}
		}

		public int golds
		{
			get
			{
				return row.REWARDGOLD;
			}
			set
			{
				Levels levelsSheet = instance.levelsSheet;
				if (index != -1)
				{
					levelsSheet.SetValue(index, "REWARDGOLD", value.ToString(CultureInfo.InvariantCulture));
				}
			}
		}

		public int score
		{
			get
			{
				return row.EXPERIENCE;
			}
		}

		public int convertGoldToWarbucks
		{
			get
			{
				return row.CONVERTGOLDTOWARBUCKS;
			}
		}

		[SpecialName]
		public int KGFMJMKDGPF()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public string KAKFPJPKHHB()
		{
			return MEJMLNDFDBP.GMIPFLIEOHD(KADNNBCOGGL());
		}

		[SpecialName]
		public int PFMGLDJDNBF()
		{
			return index + 1;
		}

		[SpecialName]
		public string LPANGEJPPOE()
		{
			return MEJMLNDFDBP.GMIPFLIEOHD(NPOEMAMPNEP());
		}

		[SpecialName]
		public int FJFNCBGDHBN()
		{
			return row.EXPERIENCE;
		}

		public GameLevel()
		{
		}

		[SpecialName]
		public int DHKGLLKHOFB()
		{
			return row.EXPERIENCE;
		}

		[SpecialName]
		public void LHIJKFFPMFB(int IDEBKDPMPGM)
		{
			Levels levelsSheet = instance.levelsSheet;
			if (index != -1)
			{
				levelsSheet.SetValue(index, "COPYCAT", IDEBKDPMPGM.ToString(CultureInfo.InvariantCulture));
			}
		}

		[SpecialName]
		public int MLCPALPKMIH()
		{
			return row.EXPERIENCE;
		}

		[SpecialName]
		public void KNHELOIILLN(int IDEBKDPMPGM)
		{
			Levels levelsSheet = instance.levelsSheet;
			if (index != -1)
			{
				levelsSheet.SetValue(index, "SquadRank", IDEBKDPMPGM.ToString(CultureInfo.InvariantCulture));
			}
		}

		[SpecialName]
		public int FMACCGDFPLJ()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public int MJABPEFBNKH()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public int EPHKCPOAKNH()
		{
			return row.EXPERIENCE;
		}

		[SpecialName]
		public int JJMKJGEGJIN()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public int CGNPNANGDNB()
		{
			return row.EXPERIENCE;
		}

		[SpecialName]
		public int ABCCINJGPGD()
		{
			return index + 0;
		}

		[SpecialName]
		public int JPBIJIOANEF()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public int KKPOMOBOIBG()
		{
			return row.CONVERTGOLDTOWARBUCKS;
		}

		public GameLevel(int BCCDDJMPBLL)
		{
			index = BCCDDJMPBLL;
		}

		[SpecialName]
		public int AMNGPKLNBEN()
		{
			return row.EXPERIENCE;
		}

		[SpecialName]
		public string CDLBEKECJNK()
		{
			return NPOEMAMPNEP().ToString();
		}

		[SpecialName]
		public int IFPPENLNNAO()
		{
			return row.EXPERIENCE;
		}

		[SpecialName]
		public string LMNDFNIKIFI()
		{
			return ABCCINJGPGD().ToString();
		}

		[SpecialName]
		public int JICMGFNAHFL()
		{
			return index + 1;
		}

		[SpecialName]
		public void OCMFMDAJHOH(int IDEBKDPMPGM)
		{
			Levels levelsSheet = instance.levelsSheet;
			if (index != -1)
			{
				levelsSheet.SetValue(index, "LootBox_Open", IDEBKDPMPGM.ToString(CultureInfo.InvariantCulture));
			}
		}

		[SpecialName]
		public string KJFPCOMOLLD()
		{
			return NPOEMAMPNEP().ToString();
		}

		[SpecialName]
		public string NOHAFIDFPCM()
		{
			return ELFCEEOLNFJ().ToString();
		}

		[SpecialName]
		public int JCHMDMGAGFN()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public string DLCFFHEKBAA()
		{
			return MEJMLNDFDBP.GMIPFLIEOHD(JICMGFNAHFL());
		}

		[SpecialName]
		public void ENFPOCGNPOK(int IDEBKDPMPGM)
		{
			Levels levelsSheet = instance.levelsSheet;
			if (index != -1)
			{
				levelsSheet.SetValue(index, "customInt", IDEBKDPMPGM.ToString(CultureInfo.InvariantCulture));
			}
		}

		[SpecialName]
		public int DPLGMBHGDOJ()
		{
			return row.CONVERTGOLDTOWARBUCKS;
		}

		[SpecialName]
		public string GIEIIPBAIBK()
		{
			return ELFCEEOLNFJ().ToString();
		}

		[SpecialName]
		public void ALJAOPJIDHJ(int IDEBKDPMPGM)
		{
			Levels levelsSheet = instance.levelsSheet;
			if (index != -1)
			{
				levelsSheet.SetValue(index, "-{0}-{1}", IDEBKDPMPGM.ToString(CultureInfo.InvariantCulture));
			}
		}

		[SpecialName]
		public int MHAOKJCDIOL()
		{
			return index + 0;
		}

		[SpecialName]
		public string IEFOIJAFOJC()
		{
			return MEJMLNDFDBP.GMIPFLIEOHD(PFMGLDJDNBF());
		}

		[SpecialName]
		public string FDACEOHEGPN()
		{
			return MEJMLNDFDBP.GMIPFLIEOHD(PFMGLDJDNBF());
		}

		[SpecialName]
		public int JIAOHNIFNEA()
		{
			return row.CONVERTGOLDTOWARBUCKS;
		}

		[SpecialName]
		public int KADNNBCOGGL()
		{
			return index + 0;
		}

		[SpecialName]
		public int HNGLMMCJABI()
		{
			return row.CONVERTGOLDTOWARBUCKS;
		}

		[SpecialName]
		public string JNODDKLJOAG()
		{
			return MEJMLNDFDBP.GMIPFLIEOHD(PFMGLDJDNBF());
		}

		[SpecialName]
		public int NPOEMAMPNEP()
		{
			return index + 1;
		}

		[SpecialName]
		public int BGOMFEEEMCC()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public string GIIHOHGFHBO()
		{
			return MEJMLNDFDBP.GMIPFLIEOHD(ABCCINJGPGD());
		}

		[SpecialName]
		public int HGNPGJDCDHF()
		{
			return row.REWARDGOLD;
		}

		[SpecialName]
		public string EGNEDNBPOEF()
		{
			return KADNNBCOGGL().ToString();
		}

		[SpecialName]
		public int ELFCEEOLNFJ()
		{
			return index + 0;
		}

		[SpecialName]
		public int OMHPPLNGCCB()
		{
			return row.EXPERIENCE;
		}

		[SpecialName]
		public void PEEINJHFKFE(int IDEBKDPMPGM)
		{
			Levels levelsSheet = instance.levelsSheet;
			if (index != -1)
			{
				levelsSheet.SetValue(index, "ID_ASSIGNMENTHINTWARPATH", IDEBKDPMPGM.ToString(CultureInfo.InvariantCulture));
			}
		}
	}

	private enum GIIHICNDJLG
	{
		FirstBest = 0,
		SecondBest = 1,
		FirstWorst = 2,
		SecondWorst = 3
	}

	private static LevelManager mInstance;

	public List<WeaponLevelsSetup> weaponLevelsSetups;

	public List<LevelBehaviour> behaviours;

	public List<LevelBehaviour> additionalBehaviours;

	private List<WeaponLevelsSetup> mWeaponsSortedByLevel = new List<WeaponLevelsSetup>();

	private List<LevelBehaviour> mUnitsSortedByLevel = new List<LevelBehaviour>();

	private Levels mLevelsSheet;

	private WeaponUpgrades mWeaponUpgradesSheet;

	private ArmyUpgrades mArmyUpgradesSheet;

	public int levelExperience;

	public long experience;

	public List<GameLevel> levels;

	private int mLevelNumber;

	private bool mIsLevelUp;

	private int serverArmyPower;

	private LevelBehaviour mRentedUnit;

	private WeaponLevelsSetup mEquippedWeaponBeforeRental;

	private PlayerVisual mPowerBandBeforeRental;

	public static LevelManager instance
	{
		get
		{
			mInstance = mInstance ?? ((LevelManager)UnityEngine.Object.FindObjectsOfType(typeof(LevelManager))[0]);
			return mInstance;
		}
	}

	public WeaponFeatures weaponFeatures { get; private set; }

	public List<WeaponLevelsSetup> weaponsSortedByLevel
	{
		get
		{
			return mWeaponsSortedByLevel;
		}
	}

	public List<LevelBehaviour> unitsSortedByLevel
	{
		get
		{
			return mUnitsSortedByLevel;
		}
	}

	public Levels levelsSheet
	{
		get
		{
			if (mLevelsSheet == null)
			{
				mLevelsSheet = GetComponent<Levels>();
			}
			return mLevelsSheet;
		}
	}

	public WeaponUpgrades weaponUpgradesSheet
	{
		get
		{
			if (mWeaponUpgradesSheet == null)
			{
				mWeaponUpgradesSheet = GetComponent<WeaponUpgrades>();
			}
			return mWeaponUpgradesSheet;
		}
	}

	public ArmyUpgrades armyUpgradesSheet
	{
		get
		{
			if (mArmyUpgradesSheet == null)
			{
				mArmyUpgradesSheet = GetComponent<ArmyUpgrades>();
			}
			return mArmyUpgradesSheet;
		}
	}

	public int levelNumber
	{
		get
		{
			return mLevelNumber;
		}
		private set
		{
			mLevelNumber = value;
			Singleton<EventTrackingManager>.instance.fuseboxxService.AMBPGAPFKHD(LPDEOBOCICH.ADBKMBDIMNC.Levels, mLevelNumber);
		}
	}

	public GameLevel currentLevel
	{
		get
		{
			return GetLevelDefinition(levelNumber);
		}
	}

	public GameLevel nextLevel
	{
		get
		{
			return (levelNumber != levels.Count - 1) ? GetLevelDefinition(levelNumber + 1) : currentLevel;
		}
	}

	public GameLevel previousLevel
	{
		get
		{
			return (levelNumber != 0) ? GetLevelDefinition(levelNumber - 1) : currentLevel;
		}
	}

	public bool isLevelUp
	{
		get
		{
			return mIsLevelUp;
		}
		set
		{
			mIsLevelUp = value;
			if (LevelManager.LevelUp != null && value)
			{
				LevelManager.LevelUp();
			}
		}
	}

	public int maxDisplayLevel
	{
		get
		{
			return levels.Count;
		}
	}

	public int armyPower
	{
		get
		{
			return unitPower + weaponPower + rankPower;
		}
	}

	public int bestArmyPower
	{
		get
		{
			return bestUnitPower + bestWeaponPower + rankPower;
		}
	}

	public int rankPower
	{
		get
		{
			return currentLevel.row.ARMYPOWER;
		}
	}

	public int unitPower
	{
		get
		{
			float num = 0f;
			foreach (LevelBehaviour behaviour in behaviours)
			{
				if (behaviour.upgradeSlots != null && behaviour.upgradeSlots.canUseInBattle && !behaviour.upgradeSlots.borrowed)
				{
					num += behaviour.upgradeSlots.armyPower;
				}
			}
			return MEJMLNDFDBP.LJDADOKBBNA(num);
		}
	}

	public int bestUnitPower
	{
		get
		{
			float num = 0f;
			foreach (KeyValuePair<LevelBehaviour.UnitType, List<LevelBehaviour>> bestValidCategoryCount in GetBestValidCategoryCounts(GetLevelBehavioursOrderByArmyPowerDesc()))
			{
				for (int i = 0; i < bestValidCategoryCount.Value.Count; i++)
				{
					num += bestValidCategoryCount.Value[i].upgradeSlots.armyPower;
				}
			}
			return MEJMLNDFDBP.LJDADOKBBNA(num);
		}
	}

	public int weaponPower
	{
		get
		{
			float num = 0f;
			foreach (PlayerInventory.InventorySlot inventorySlot in PlayerInventory.instance.inventorySlots)
			{
				WeaponLevelsSetup weaponLevelsSetup = inventorySlot.weaponLevelsSetup;
				if (weaponLevelsSetup != null && weaponLevelsSetup.MGAGEKAAJOL != null)
				{
					num += weaponLevelsSetup.weaponPower;
				}
			}
			return MEJMLNDFDBP.LJDADOKBBNA(num);
		}
	}

	public int bestWeaponPower
	{
		get
		{
			float num = 0f;
			foreach (PlayerInventory.InventorySlot inventorySlot in PlayerInventory.instance.inventorySlots)
			{
				WeaponLevelsSetup bestWeaponInCategory = GetBestWeaponInCategory(inventorySlot.category);
				if (bestWeaponInCategory != null)
				{
					num += bestWeaponInCategory.weaponPower;
				}
			}
			return MEJMLNDFDBP.LJDADOKBBNA(num);
		}
	}

	public int armyPowerX10
	{
		get
		{
			return unitPowerX10 + weaponPowerX10 + rankPowerX10;
		}
	}

	public int rankPowerX10
	{
		get
		{
			return 10 * rankPower;
		}
	}

	public int weaponPowerX10
	{
		get
		{
			return 10 * weaponPower;
		}
	}

	public int unitPowerX10
	{
		get
		{
			return 10 * unitPower;
		}
	}

	public int dailyMissionUnlockLevel
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WarpathUnlockLevel).FLOATVALUE;
		}
	}

	public int joinSquadUnlockLevel
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.JoinSquadUnlockLevel).FLOATVALUE;
		}
	}

	public int createSquadUnlockLevel
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CreateSquadUnlockLevel).FLOATVALUE;
		}
	}

	public int warcardsUnlockLevel
	{
		get
		{
			return (int)Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.WarcardsUnlockLevel).FLOATVALUE;
		}
	}

	public int goldenSuitcaseUnlockLevel
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseUnlockLevel).FLOATVALUE;
		}
	}

	public int lootboxUnlockLevel
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxesUnlockLevel).FLOATVALUE;
		}
	}

	public int instantBattleUnlockLevel
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleUnlockLevel).FLOATVALUE;
		}
	}

	public int warArenaUnlockLevel
	{
		get
		{
			return (int)(float)WarArena.instance.wararenaParameters.GetRow(WarArenaParameters.rowIds.UnlockLevel).FLOATVALUE;
		}
	}

	public int eventAssignmentUnlockLevel
	{
		get
		{
			return (int)(float)AssignmentsManager.instance.assignmentsConstants.GetRow(AssignmentsConstants.rowIds.EventAssignmentUnlockLevel).FLOATVALUE;
		}
	}

	public int squadUnlockLevel
	{
		get
		{
			return Mathf.Min(joinSquadUnlockLevel, createSquadUnlockLevel);
		}
	}

	public int squadJoinAndCreateUnlockLevel
	{
		get
		{
			return Mathf.Max(joinSquadUnlockLevel, createSquadUnlockLevel);
		}
	}

	public bool isDailyMissionLocked
	{
		get
		{
			return dailyMissionUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isWarcardsLocked
	{
		get
		{
			return warcardsUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isGoldenSuitcaseLocked
	{
		get
		{
			return goldenSuitcaseUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isSquadJoinLocked
	{
		get
		{
			return joinSquadUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isSquadJoinAndCreateLocked
	{
		get
		{
			return squadJoinAndCreateUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isSquadLocked
	{
		get
		{
			return squadUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isDailyRewardsLocked
	{
		get
		{
			return false;
		}
	}

	public bool isMainScreenPartsLocked
	{
		get
		{
			return !Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded || StatsManager.instance.matchmadeGames <= 0;
		}
	}

	public bool isLootboxesLocked
	{
		get
		{
			return lootboxUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isInstantBattleLocked
	{
		get
		{
			return instantBattleUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool isWarArenaLocked
	{
		get
		{
			return warArenaUnlockLevel > currentLevel.displayNumber;
		}
	}

	public bool showWarArenaPromoLocked
	{
		get
		{
			return isWarArenaLocked && warArenaUnlockLevel - 3 < currentLevel.displayNumber;
		}
	}

	public bool showWarArenaShortcut
	{
		get
		{
			return !isWarArenaLocked && (WarArena.instance.isReminderTime || WarArena.instance.isOpened);
		}
	}

	public bool isEventAssignmentLocked
	{
		get
		{
			return eventAssignmentUnlockLevel > currentLevel.displayNumber;
		}
	}

	public List<LevelBehaviour> armyUnlocks
	{
		get
		{
			List<LevelBehaviour> list = new List<LevelBehaviour>();
			if (Singleton<GameController>.instance.isTutorialStage2)
			{
				foreach (LevelBehaviour behaviour in behaviours)
				{
					if (behaviour.upgradeSlots.isTutorialUnit)
					{
						list.Add(behaviour);
					}
				}
			}
			else if (!Singleton<GameController>.instance.isTutorial)
			{
				foreach (LevelBehaviour behaviour2 in behaviours)
				{
					if (behaviour2.upgradeSlots.unlockLevelIndex == levelNumber && !behaviour2.upgradeSlots.bought)
					{
						list.Add(behaviour2);
					}
				}
			}
			return list;
		}
	}

	public List<WeaponLevelsSetup> weaponUnlocks
	{
		get
		{
			List<WeaponLevelsSetup> list = new List<WeaponLevelsSetup>();
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
				{
					if (weaponLevelsSetup.FICHPKKDGBK)
					{
						list.Add(weaponLevelsSetup);
					}
				}
			}
			else if (!Singleton<GameController>.instance.isTutorial)
			{
				foreach (WeaponLevelsSetup weaponLevelsSetup2 in weaponLevelsSetups)
				{
					if (weaponLevelsSetup2.unlockLevelIndex == levelNumber && !weaponLevelsSetup2.bought && weaponLevelsSetup2.purchasableInShop)
					{
						list.Add(weaponLevelsSetup2);
					}
				}
			}
			return list;
		}
	}

	public List<PlayerVisual> visualUnlocks
	{
		get
		{
			List<PlayerVisual> list = new List<PlayerVisual>();
			if (!Singleton<GameController>.instance.isTutorial)
			{
				foreach (PlayerVisualCategory playerVisualCategory in CamosManager.instance.playerVisualCategories)
				{
					if (playerVisualCategory is PlayerVisualCategoryPowerBands)
					{
						continue;
					}
					foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
					{
						if (allVisual.unlockLevelIndex == levelNumber && !allVisual.isBought && allVisual.purchasableInShop)
						{
							list.Add(allVisual);
						}
					}
				}
			}
			return list;
		}
	}

	public static bool isNoob
	{
		get
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MatchmakingEasyBotTillLevel).FLOATVALUE;
			if (instance.currentLevel.displayNumber <= num)
			{
				return true;
			}
			return false;
		}
	}

	public static event Action LevelUp;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void SetLevelNumber(int numberToSet)
	{
	}

	public GameLevel GetLevelDefinition(int level)
	{
		if (levels == null || levels.Count == 0)
		{
			return new GameLevel(level);
		}
		level = Mathf.Clamp(level, 0, levels.Count - 1);
		return levels[level];
	}

	public float InterpolateNumbersBasedOnLevel(int LowLevelTreshold, float lowLevelNumber, int HighLevelTreshold, float highLevelNumber)
	{
		int displayNumber = currentLevel.displayNumber;
		if (displayNumber <= LowLevelTreshold)
		{
			return lowLevelNumber;
		}
		if (displayNumber >= HighLevelTreshold)
		{
			return highLevelNumber;
		}
		float num = (float)(displayNumber - LowLevelTreshold) / (float)(HighLevelTreshold - LowLevelTreshold);
		return (1f - num) * lowLevelNumber + num * highLevelNumber;
	}

	private static List<LevelBehaviour> GetLevelBehavioursOrderByArmyPowerDesc()
	{
		List<LevelBehaviour> list = new List<LevelBehaviour>(instance.behaviours);
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.Sort((LevelBehaviour a, LevelBehaviour b) => a.upgradeSlots.armyPower.CompareTo(b.upgradeSlots.armyPower) * -1);
		return list;
	}

	private static Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> GetBestValidCategoryCounts(List<LevelBehaviour> orderedBehaviours)
	{
		int num = 0;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < orderedBehaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = orderedBehaviours[i];
			if (!levelBehaviour.upgradeSlots.bought)
			{
				continue;
			}
			List<LevelBehaviour> value;
			if (!dictionary.TryGetValue(levelBehaviour.unitType, out value))
			{
				value = new List<LevelBehaviour>();
				dictionary.Add(levelBehaviour.unitType, value);
			}
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 3)
				{
					continue;
				}
				num++;
			}
			if (value.Count < 2)
			{
				value.Add(levelBehaviour);
			}
		}
		return dictionary;
	}

	public static WeaponLevelsSetup GetBestWeaponInCategory(WeaponCategory category)
	{
		WeaponLevelsSetup weaponLevelsSetup = null;
		foreach (WeaponLevelsSetup weaponLevelsSetup2 in instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup2 != null && (weaponLevelsSetup2.BHCEOOLEHHG & category) != WeaponCategory.None && weaponLevelsSetup2.bought && weaponLevelsSetup2.MGAGEKAAJOL != null && (weaponLevelsSetup == null || weaponLevelsSetup2.weaponPower > weaponLevelsSetup.weaponPower))
			{
				weaponLevelsSetup = weaponLevelsSetup2;
			}
		}
		return weaponLevelsSetup;
	}

	public static WeaponLevelsSetup GetRandomInCategory(WeaponCategory category)
	{
		List<WeaponLevelsSetup> list = new List<WeaponLevelsSetup>();
		foreach (WeaponLevelsSetup weaponLevelsSetup in instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup != null && (weaponLevelsSetup.BHCEOOLEHHG & category) != WeaponCategory.None && weaponLevelsSetup.bought && weaponLevelsSetup.MGAGEKAAJOL != null)
			{
				list.Add(weaponLevelsSetup);
			}
		}
		return (list.Count <= 0) ? null : list[UnityEngine.Random.Range(0, list.Count)];
	}

	public int GetRankPower(int displayLevel)
	{
		int index = Mathf.Clamp(displayLevel - 1, 0, levels.Count);
		return levels[index].row.ARMYPOWER;
	}

	public int GetRankPowerX10(int displayLevel)
	{
		return 10 * GetRankPower(displayLevel);
	}

	public bool BuyRentalWeapon(WeaponLevelsSetup rentalWeapon, int salePrize)
	{
		int price = rentalWeapon.price;
		int priceGold = rentalWeapon.priceGold;
		if (price > 0 && !Singleton<Wallet>.instance.CanBuyW(salePrize))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(salePrize, rentalWeapon.weaponName);
			return false;
		}
		if (priceGold > 0 && !Singleton<Wallet>.instance.CanBuyGold(salePrize))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(salePrize, rentalWeapon.weaponName);
			return false;
		}
		if (price > 0)
		{
			Singleton<Wallet>.instance.CDIDDJGINID(salePrize);
		}
		if (priceGold > 0)
		{
			Singleton<Wallet>.instance.MBAFMBJFOKH(salePrize);
		}
		if (rentalWeapon.weaponDeliveryTime == 0)
		{
			rentalWeapon.ActivateWeapon();
		}
		else
		{
			rentalWeapon.Buy();
		}
		GuiScreenSingle<WeaponScreen>.instance.AfterWeaponIsBought(rentalWeapon, WeaponScreen.ABDDBOABKOK.Rental);
		Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(true);
		if (priceGold > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Rental_Weapon_Gold", "Weapon_ID", rentalWeapon.DHHKOKKDDDO(), salePrize);
			Singleton<EventTrackingManager>.instance.RegisterEconomyEvent("Spend_Gold_On_Weapons", salePrize);
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchasePremiumWeapon);
		}
		else
		{
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Rental_Weapon", "Weapon_ID", rentalWeapon.DHHKOKKDDDO(), salePrize);
			Singleton<EventTrackingManager>.instance.RegisterEconomyEvent("Spend_Warbucks_On_Weapons", salePrize);
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseSoftWeapon);
		}
		return true;
	}

	public void TryRentalUnit(LevelBehaviour rentalUnit)
	{
		mRentedUnit = rentalUnit;
		Singleton<ActiveUnitsManager>.instance.EquipRentalUnit(mRentedUnit);
	}

	public bool BuyRentalUnit(LevelBehaviour rentalUnit, int salePrize)
	{
		int price = rentalUnit.upgradeSlots.price;
		int priceGold = rentalUnit.upgradeSlots.priceGold;
		if (price > 0 && !Singleton<Wallet>.instance.CanBuyW(salePrize))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(salePrize, rentalUnit.unitName);
			return false;
		}
		if (priceGold > 0 && !Singleton<Wallet>.instance.CanBuyGold(salePrize))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(salePrize, rentalUnit.unitName);
			return false;
		}
		if (price > 0)
		{
			Singleton<Wallet>.instance.CDIDDJGINID(salePrize);
		}
		if (priceGold > 0)
		{
			Singleton<Wallet>.instance.MBAFMBJFOKH(salePrize);
		}
		if (rentalUnit.upgradeSlots.unitDeliveryTime == 0)
		{
			rentalUnit.upgradeSlots.ActivateUnit();
		}
		else
		{
			rentalUnit.upgradeSlots.Buy();
		}
		GuiScreenSingle<ArmyScreen>.instance.AfterUnitIsBought(rentalUnit);
		Debug.Log(string.Format("unit {0} start {1} end {2} current {3} activation needed {4} bought {5}", rentalUnit.upgradeSlots.name, rentalUnit.upgradeSlots.startDeliveryTime, rentalUnit.upgradeSlots.endDeliveryTime, Singleton<BeanstalkServerManager>.instance.currentTimestamp, rentalUnit.upgradeSlots.deliveryActivationNeeded, rentalUnit.upgradeSlots.bought));
		Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(true);
		if (priceGold > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Rental_Army_Unit_Gold", "Army_Unit_ID", rentalUnit.upgradeSlots.GetSheetName(), salePrize);
			Singleton<EventTrackingManager>.instance.RegisterEconomyEvent("Spend_Gold_On_Army", salePrize);
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchasePremiumUnit);
		}
		else
		{
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Rental_Army_Unit", "Army_Unit_ID", rentalUnit.upgradeSlots.GetSheetName(), salePrize);
			Singleton<EventTrackingManager>.instance.RegisterEconomyEvent("Spend_Warbucks_On_Army", salePrize);
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseSoftUnit);
		}
		return true;
	}

	public bool BuyRentalPowerBand(PlayerVisual rentalPowerBand, int salePrize)
	{
		int priceWarbucks = rentalPowerBand.priceWarbucks;
		int priceGold = rentalPowerBand.priceGold;
		if (priceWarbucks > 0 && !Singleton<Wallet>.instance.CanBuyW(salePrize))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(salePrize, rentalPowerBand.name);
			return false;
		}
		if (priceGold > 0 && !Singleton<Wallet>.instance.CanBuyGold(salePrize))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(salePrize, rentalPowerBand.name);
			return false;
		}
		if (priceWarbucks > 0)
		{
			Singleton<Wallet>.instance.CDIDDJGINID(salePrize);
		}
		if (priceGold > 0)
		{
			Singleton<Wallet>.instance.MBAFMBJFOKH(salePrize);
		}
		rentalPowerBand.BMIEJNIEDOP();
		EquipRentalVisual(rentalPowerBand, false);
		Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(true);
		Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Rental_Power_Band_Gold", "Item_ID", rentalPowerBand.row.NAME, salePrize);
		Singleton<EventTrackingManager>.instance.RegisterEconomyEvent("Spend_Gold_On_Power_Bands", salePrize);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
		return true;
	}

	public void EquipRentalWeapon(WeaponLevelsSetup rentalWeapon, bool onlyTry)
	{
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & rentalWeapon.BHCEOOLEHHG) != rentalWeapon.BHCEOOLEHHG)
			{
				continue;
			}
			if (onlyTry)
			{
				if (PlayerInventory.instance.inventorySlots[i].weaponLevelsSetup.DHHKOKKDDDO() != rentalWeapon.DHHKOKKDDDO() && PlayerInventory.instance.inventorySlots[i].weaponLevelsSetup.bought)
				{
					mEquippedWeaponBeforeRental = PlayerInventory.instance.inventorySlots[i].weaponLevelsSetup;
				}
				Debug.Log(string.Format("Try out: Equipping weapon \"{0}\" instead of weapon \"{1}\"", rentalWeapon.weaponName.ToUpper(), mEquippedWeaponBeforeRental.weaponName.ToUpper()));
			}
			else
			{
				Debug.Log(string.Format("Equipping weapon \"{0}\" from rental", rentalWeapon.weaponName.ToUpper()));
			}
			GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(rentalWeapon, i, WeaponScreen.ABDDBOABKOK.Rental);
			break;
		}
	}

	public void EquipRentalVisual(PlayerVisual rentalPowerBand, bool onlyTry)
	{
		foreach (PlayerVisualCategory playerVisualCategory in CamosManager.instance.playerVisualCategories)
		{
			if (rentalPowerBand.owner != playerVisualCategory)
			{
				continue;
			}
			if (onlyTry)
			{
				if (playerVisualCategory.equippedVisual != rentalPowerBand && playerVisualCategory.equippedVisual.isBought)
				{
					mPowerBandBeforeRental = playerVisualCategory.equippedVisual;
				}
				Debug.Log(string.Format("Try out: Equipping visual \"{0}\" instead of visual \"{1}\"", rentalPowerBand.name.ToUpper(), mPowerBandBeforeRental.name.ToUpper()));
			}
			else
			{
				Debug.Log(string.Format("Equipping visual \"{0}\" from rental", rentalPowerBand.name.ToUpper()));
			}
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(rentalPowerBand);
			break;
		}
	}

	private void UnequipRentalThings()
	{
		if (mEquippedWeaponBeforeRental != null)
		{
			for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
			{
				if ((PlayerInventory.instance.inventorySlots[i].category & mEquippedWeaponBeforeRental.BHCEOOLEHHG) == mEquippedWeaponBeforeRental.BHCEOOLEHHG)
				{
					mEquippedWeaponBeforeRental.tryOutWeapon = false;
					Debug.Log(string.Format("End Of Try Out: Equipping weapon before \"{0}\"", mEquippedWeaponBeforeRental.weaponName.ToUpper()));
					GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(mEquippedWeaponBeforeRental, i, WeaponScreen.ABDDBOABKOK.Server);
					break;
				}
			}
			mEquippedWeaponBeforeRental = null;
		}
		else
		{
			for (int j = 0; j < PlayerInventory.instance.inventorySlots.Count; j++)
			{
				if (PlayerInventory.instance.inventorySlots[j].weaponLevelsSetup.tryOutWeapon)
				{
					PlayerInventory.instance.inventorySlots[j].weaponLevelsSetup.tryOutWeapon = false;
					GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(StrongestBoughtWeapon(PlayerInventory.instance.inventorySlots[j].category), j, WeaponScreen.ABDDBOABKOK.Server);
					break;
				}
			}
		}
		if (mRentedUnit != null)
		{
			mRentedUnit.upgradeSlots.borrowed = false;
			Singleton<ActiveUnitsManager>.instance.UnequipRentalUnit(mRentedUnit);
			mRentedUnit = null;
		}
		if (mPowerBandBeforeRental == null)
		{
			return;
		}
		foreach (PlayerVisualCategory playerVisualCategory in CamosManager.instance.playerVisualCategories)
		{
			if (mPowerBandBeforeRental.owner != playerVisualCategory)
			{
				continue;
			}
			Debug.Log(string.Format("End Of Try Out: Equipping visual before \"{0}\"", mPowerBandBeforeRental.name.ToUpper()));
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(mPowerBandBeforeRental);
			break;
		}
		mPowerBandBeforeRental = null;
	}

	internal float GetPlayerLevelProgress()
	{
		if (levels == null)
		{
			Debug.Log("LevelManager: levels are null!!");
			return 0.5f;
		}
		return (float)(currentLevel.index + 1) / (float)levels.Count;
	}

	public int GetIndexOfNotBoughtUnit()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < behaviours.Count; i++)
		{
			if (behaviours[i].upgradeSlots != null && !behaviours[i].upgradeSlots.bought)
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return 0;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public int GetIndexOfNotBoughtWeapon()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < weaponLevelsSetups.Count; i++)
		{
			if (weaponLevelsSetups[i] != null && !weaponLevelsSetups[i].bought)
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return 0;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public int GetIndexOfUpgradeableWeapon()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < weaponLevelsSetups.Count; i++)
		{
			if (weaponLevelsSetups[i] != null && weaponLevelsSetups[i].bought && weaponLevelsSetups[i].weaponLevel < weaponLevelsSetups[i].maxWeaponLevel)
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return 0;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public LevelBehaviour GetBoughtUnitWithBiggestUnlockLevel()
	{
		LevelBehaviour levelBehaviour = null;
		foreach (LevelBehaviour behaviour in behaviours)
		{
			if (levelBehaviour == null)
			{
				if (behaviour.upgradeSlots.bought)
				{
					levelBehaviour = behaviour;
				}
			}
			else if (behaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.unlockLevelIndex < behaviour.upgradeSlots.unlockLevelIndex)
			{
				levelBehaviour = behaviour;
			}
		}
		return levelBehaviour;
	}

	public List<WeaponLevelsSetup> GetSuitableWeapons(WeaponCategory category, int maxLevel, float minWeaponPower, float maxWeaponPower, WeaponCategory excludeCategory)
	{
		List<WeaponLevelsSetup> list = new List<WeaponLevelsSetup>();
		for (int i = 0; i < weaponLevelsSetups.Count; i++)
		{
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[i];
			if (weaponLevelsSetup.purchasable != WeaponLevelsSetup.GILPPKMICCF.Hidden && (weaponLevelsSetup.BHCEOOLEHHG & category) == weaponLevelsSetup.BHCEOOLEHHG && (weaponLevelsSetup.BHCEOOLEHHG & excludeCategory) == 0)
			{
				float num = weaponLevelsSetup.GetWeaponPower(0, null);
				float num2 = weaponLevelsSetup.GetWeaponPower(weaponLevelsSetup.maxWeaponLevel, null);
				if (weaponLevelsSetup.unlockLevelIndex < maxLevel && minWeaponPower <= num2 && num <= maxWeaponPower)
				{
					list.Add(weaponLevelsSetup);
				}
			}
		}
		if (list.Count == 0)
		{
			Debug.LogError(string.Format("Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}", category, maxLevel, minWeaponPower, maxWeaponPower));
			int lastUnlockedWeapon = GetLastUnlockedWeapon(category, maxLevel - 1);
			list.Add(weaponLevelsSetups[lastUnlockedWeapon]);
		}
		return list;
	}

	public int GetLastUnlockedWeapon(WeaponCategory category, int level)
	{
		int num = -1;
		int num2 = -1;
		for (int i = 0; i < weaponLevelsSetups.Count; i++)
		{
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[i];
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) == weaponLevelsSetup.BHCEOOLEHHG && weaponLevelsSetup.unlockLevelIndex <= level && weaponLevelsSetup.unlockLevelIndex > num)
			{
				num2 = i;
				num = weaponLevelsSetup.unlockLevelIndex;
			}
		}
		int num3 = int.MaxValue;
		if (num2 == -1)
		{
			for (int j = 0; j < weaponLevelsSetups.Count; j++)
			{
				WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[j];
				if ((weaponLevelsSetup2.BHCEOOLEHHG & category) == weaponLevelsSetup2.BHCEOOLEHHG && weaponLevelsSetup2.unlockLevelIndex <= num3)
				{
					num2 = j;
					num3 = weaponLevelsSetup2.unlockLevelIndex;
				}
			}
		}
		return num2;
	}

	public float GetPrewProgress(int score)
	{
		int num = levelExperience - score;
		GameLevel gameLevel = currentLevel;
		if (num < 0)
		{
			gameLevel = previousLevel;
			num += gameLevel.score;
		}
		return (float)num / (float)gameLevel.score;
	}

	public float GetProgress()
	{
		if (currentLevel.displayNumber == instance.maxDisplayLevel)
		{
			return 0f;
		}
		float value = (float)levelExperience / (float)currentLevel.score;
		return Mathf.Clamp01(value);
	}

	public void SetLevelUpProgressForTutorial(int level, float xpFract, bool levelUp)
	{
		levelNumber = level - 1;
		levelExperience = Mathf.CeilToInt((float)currentLevel.score * xpFract);
		isLevelUp = levelUp;
	}

	public void CheckCurrentLevelForTutorial(int level)
	{
		if (levelNumber != level - 1)
		{
			levelNumber = level - 1;
		}
	}

	internal void DebugAddLevel()
	{
	}

	internal void LoadData(int level, int loadedLevelExperience, long loadedExperience, int loadedArmyPower)
	{
		levelNumber = level;
		levelExperience = loadedLevelExperience;
		experience = loadedExperience;
		serverArmyPower = loadedArmyPower;
	}

	internal void LoadData(int level, int experience)
	{
		levelNumber = level;
		levelExperience = experience;
	}

	internal void UpdateUnit(string index, JToken unitJson)
	{
		data.savedArmies[index] = JsonConvert.DeserializeObject<SavedArmySlots>((string)unitJson);
	}

	internal void UpdateWeapon(string index, JToken weaponJson)
	{
		data.savedWeapons[index] = JsonConvert.DeserializeObject<SavedWeaponSlots>((string)weaponJson);
		WeaponLevelsSetup weaponLevelsSetup = Weapon(index);
		if (!(weaponLevelsSetup != null))
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG == (PlayerInventory.instance.inventorySlots[i].category & weaponLevelsSetup.BHCEOOLEHHG))
			{
				num = i;
			}
		}
		PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[num];
		if (inventorySlot.weaponIndex != weaponLevelsSetup.indexInLevelManager || weaponLevelsSetup.bought)
		{
			return;
		}
		foreach (WeaponLevelsSetup weaponLevelsSetup2 in weaponLevelsSetups)
		{
			if (weaponLevelsSetup2.BHCEOOLEHHG == (inventorySlot.category & weaponLevelsSetup2.BHCEOOLEHHG) && weaponLevelsSetup2.bought)
			{
				GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(weaponLevelsSetup2, num, WeaponScreen.ABDDBOABKOK.Server);
				break;
			}
		}
	}

	internal void UpdateWeaponDelivery(JToken item)
	{
		Debug.LogError("Weapon delivery was : " + JsonConvert.SerializeObject(data.weaponDelivery));
		Debug.LogError("Weapon delivery now is : " + (string)item);
		data.weaponDelivery = JsonConvert.DeserializeObject<ItemDelivery>((string)item);
	}

	internal void UpdateUnitDelivery(JToken item)
	{
		Debug.LogError("Unit delivery was : " + JsonConvert.SerializeObject(data.unitDelivery));
		Debug.LogError("Unit delivery now is : " + (string)item);
		data.unitDelivery = JsonConvert.DeserializeObject<ItemDelivery>((string)item);
	}

	protected override void Awake()
	{
		base.Awake();
		Debug.Log("LevelManager: Awake");
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		Debug.Log("LevelManager: Awake registering events");
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
		mInstance = this;
		weaponFeatures = GetComponent<WeaponFeatures>();
		for (int i = 0; i < behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = behaviours[i];
			levelBehaviour.indexInLevelsManager = i;
			levelBehaviour.PresetOnStart();
		}
	}

	private void OnGameStarted()
	{
		isLevelUp = false;
	}

	private void OnGameEnded(GameController.HKGHCIEPGEL endReason)
	{
		if (Singleton<GameController>.instance.mainController.canDeployUnits)
		{
			UnequipRentalThings();
		}
	}

	public void Init()
	{
		Debug.Log("LevelManager: Init");
		levels = new List<GameLevel>();
		for (int i = 0; i < levelsSheet.Rows.Count; i++)
		{
			LevelsRow row = levelsSheet.Rows[i];
			levels.Add(new GameLevel
			{
				index = i,
				row = row
			});
		}
		mUnitsSortedByLevel.Clear();
		foreach (LevelBehaviour behaviour in behaviours)
		{
			bool flag = false;
			foreach (ArmyUpgradesRow row2 in armyUpgradesSheet.Rows)
			{
				if (behaviour.upgradeSlots.excel.GetType().ToString() == row2.NAME)
				{
					behaviour.upgradeSlots.Init(row2);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				behaviour.upgradeSlots.Init(new ArmyUpgradesRow
				{
					NAME = string.Empty
				});
			}
			mUnitsSortedByLevel.Add(behaviour);
		}
		foreach (LevelBehaviour additionalBehaviour in additionalBehaviours)
		{
			bool flag2 = false;
			foreach (ArmyUpgradesRow row3 in armyUpgradesSheet.Rows)
			{
				if (additionalBehaviour.upgradeSlots.excel.GetType().ToString() == row3.NAME)
				{
					additionalBehaviour.upgradeSlots.Init(row3);
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				additionalBehaviour.upgradeSlots.Init(new ArmyUpgradesRow
				{
					NAME = string.Empty
				});
			}
		}
		mUnitsSortedByLevel.Sort((LevelBehaviour unit1, LevelBehaviour unit2) => unit2.upgradeSlots.unlockLevelIndex.CompareTo(unit1.upgradeSlots.unlockLevelIndex));
		WeaponUpgrades component = GetComponent<WeaponUpgrades>();
		foreach (WeaponUpgradesRow row4 in component.Rows)
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
			{
				if (weaponLevelsSetup.weaponFeature == null)
				{
					weaponLevelsSetup.weaponFeature = new APLFCKFBIHK();
				}
				if (weaponLevelsSetup.DHHKOKKDDDO() == row4.NAME)
				{
					weaponLevelsSetup.HCICPDLJNCK = row4;
					break;
				}
			}
		}
		foreach (WeaponLevelsSetup weaponLevelsSetup2 in weaponLevelsSetups)
		{
			if (weaponLevelsSetup2.purchasableInBlackmarket && weaponLevelsSetup2.bought)
			{
				weaponLevelsSetup2.weaponFeature = weaponFeatures.CreateFeature(weaponLevelsSetup2, weaponLevelsSetup2.specialFeature);
			}
		}
		mWeaponsSortedByLevel.Clear();
		for (int num = 0; num < weaponLevelsSetups.Count; num++)
		{
			weaponLevelsSetups[num].Init();
			weaponLevelsSetups[num].indexInLevelManager = num;
			mWeaponsSortedByLevel.Add(weaponLevelsSetups[num]);
		}
		mWeaponsSortedByLevel.Sort((WeaponLevelsSetup weapon1, WeaponLevelsSetup weapon2) => weapon2.unlockLevelIndex.CompareTo(weapon1.unlockLevelIndex));
	}

	private void OnPlayerDataLoaded()
	{
		Init();
		PlayerInventory.instance.Init();
		Singleton<ActiveUnitsManager>.instance.Initialize();
		if (serverArmyPower != 0 && armyPower != serverArmyPower)
		{
			Singleton<BeanstalkServerManager>.instance.FGOGBNADPCE(armyPower);
		}
	}

	public List<UnitUpgradeDefinition> GetUpgrades()
	{
		List<LevelBehaviour> list = instance.behaviours;
		List<UnitUpgradeDefinition> list2 = new List<UnitUpgradeDefinition>();
		foreach (LevelBehaviour item in list)
		{
			UpgradeSlots.UnitUpgrades upgradeIndex = item.upgradeSlots.LoadData(item);
			list2.Add(new UnitUpgradeDefinition(item.upgradeSlots.canUseInBattle, upgradeIndex, item.upgradeSlots.isNew, item.upgradeSlots.actualTier));
		}
		return list2;
	}

	public LevelBehaviour GetBehaviour(Type type)
	{
		foreach (LevelBehaviour behaviour in behaviours)
		{
			if (behaviour.GetType() == type)
			{
				return behaviour;
			}
		}
		return null;
	}

	public LevelBehaviour DeliveringUnit()
	{
		ItemDelivery unitDelivery = data.unitDelivery;
		LevelBehaviour levelBehaviour = Unit(unitDelivery.itemId);
		if (levelBehaviour != null && levelBehaviour.upgradeSlots.isDeliveringOrDelivered)
		{
			return levelBehaviour;
		}
		return null;
	}

	public WeaponLevelsSetup DeliveringWeapon()
	{
		foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
		{
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
			{
				return weaponLevelsSetup;
			}
		}
		return null;
	}

	public float DamageFunction(float number)
	{
		return number * 10f;
	}

	internal void SetWeaponDeliveryTime(JToken jToken)
	{
		bool flag = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
		{
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			Debug.LogWarning("Server send time when weapon upgrade will be delivered - Player already hit button DELIVERY NOW - update delivery time is being ignored!");
			return;
		}
		int num = KHJJFPPACBP.HNMDPGKPLNK(jToken);
		int num2 = Singleton<BeanstalkServerManager>.instance.currentTimestamp + num;
		long num3 = num2 - data.weaponDelivery.end;
		Debug.Log("Setting weapon delivery in " + num2 + ", it was " + data.weaponDelivery.end + ", diff = " + num3);
		if (num3 > 5)
		{
			data.weaponDelivery.end = num2;
		}
	}

	internal void SetUnitDeliveryTime(JToken jToken)
	{
		bool flag = false;
		foreach (LevelBehaviour behaviour in behaviours)
		{
			if (behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			Debug.LogWarning("Server send time when unit upgrade will be delivered - Player already hit button DELIVERY NOW - update delivery time is being ignored!");
			return;
		}
		int num = KHJJFPPACBP.HNMDPGKPLNK(jToken);
		int num2 = Singleton<BeanstalkServerManager>.instance.currentTimestamp + num;
		long num3 = num2 - data.unitDelivery.end;
		Debug.Log("Setting unit delivery in " + num2 + ", it was " + data.unitDelivery.end + ", diff = " + num3);
		if (num3 > 5)
		{
			data.unitDelivery.end = num2;
		}
	}

	public WeaponLevelsSetup Weapon(string sheetName)
	{
		foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
		{
			if (weaponLevelsSetup.DHHKOKKDDDO() == sheetName)
			{
				return weaponLevelsSetup;
			}
		}
		return null;
	}

	public LevelBehaviour Unit(string sheetName)
	{
		foreach (LevelBehaviour behaviour in behaviours)
		{
			if (behaviour.upgradeSlots.GetSheetName() == sheetName)
			{
				return behaviour;
			}
		}
		return null;
	}

	public WeaponLevelsSetup Minigun()
	{
		foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG == WeaponCategory.Minigun)
			{
				return weaponLevelsSetup;
			}
		}
		return null;
	}

	public int NumberOfBought(WeaponCategory category)
	{
		int num = 0;
		foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG == category && !weaponLevelsSetup.tryOutWeapon && weaponLevelsSetup.bought)
			{
				num++;
			}
		}
		return num;
	}

	public LevelBehaviour GetUnit(Type type)
	{
		foreach (LevelBehaviour behaviour in behaviours)
		{
			if (behaviour.GetType() == type)
			{
				return behaviour;
			}
		}
		return null;
	}

	public bool IsUnit(string sheetName)
	{
		foreach (LevelBehaviour behaviour in behaviours)
		{
			if (behaviour.upgradeSlots.GetSheetName() == sheetName)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsWeapon(string sheetName)
	{
		foreach (WeaponLevelsSetup weaponLevelsSetup in weaponLevelsSetups)
		{
			if (weaponLevelsSetup.DHHKOKKDDDO() == sheetName)
			{
				return true;
			}
		}
		return false;
	}

	public WeaponLevelsSetup StrongestBoughtWeapon(WeaponCategory category)
	{
		WeaponLevelsSetup weaponLevelsSetup = null;
		for (int i = 0; i < weaponLevelsSetups.Count; i++)
		{
			if (!weaponLevelsSetups[i].tryOutWeapon && weaponLevelsSetups[i].bought && (category & weaponLevelsSetups[i].BHCEOOLEHHG) == weaponLevelsSetups[i].BHCEOOLEHHG)
			{
				if (weaponLevelsSetup == null)
				{
					weaponLevelsSetup = weaponLevelsSetups[i];
				}
				else if (weaponLevelsSetups[i].weaponPower > weaponLevelsSetup.weaponPower)
				{
					weaponLevelsSetup = weaponLevelsSetups[i];
				}
			}
		}
		return weaponLevelsSetup;
	}

	public static LevelBehaviour GetWorstEquipped(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.FirstWorst, unitType, (LevelBehaviour x) => x.upgradeSlots.equipped);
	}

	public static LevelBehaviour GetSecondWorstEquipped(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.SecondWorst, unitType, (LevelBehaviour x) => x.upgradeSlots.equipped);
	}

	public static LevelBehaviour GetWorstBought(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.FirstWorst, unitType, (LevelBehaviour x) => x.upgradeSlots.bought);
	}

	public static LevelBehaviour GetSecondWorstBought(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.SecondWorst, unitType, (LevelBehaviour x) => x.upgradeSlots.bought);
	}

	public static LevelBehaviour GetBestEquipped(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.FirstBest, unitType, (LevelBehaviour x) => x.upgradeSlots.equipped);
	}

	public static LevelBehaviour GetSecondBestEquipped(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.SecondBest, unitType, (LevelBehaviour x) => x.upgradeSlots.equipped);
	}

	public static LevelBehaviour GetBestBought(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.FirstBest, unitType, (LevelBehaviour x) => x.upgradeSlots.bought);
	}

	public static LevelBehaviour GetSecondBestBought(LevelBehaviour.UnitType unitType)
	{
		return GetExtreme(GIIHICNDJLG.SecondBest, unitType, (LevelBehaviour x) => x.upgradeSlots.bought);
	}

	private static LevelBehaviour GetExtreme(GIIHICNDJLG extremeType, LevelBehaviour.UnitType unitType, Func<LevelBehaviour, bool> filter)
	{
		if (filter == null)
		{
			throw new ArgumentNullException("filter");
		}
		bool flag = extremeType == GIIHICNDJLG.FirstBest || extremeType == GIIHICNDJLG.SecondBest;
		bool flag2 = extremeType == GIIHICNDJLG.FirstWorst || extremeType == GIIHICNDJLG.SecondWorst;
		int num = ((!flag) ? int.MaxValue : int.MinValue);
		int num2 = num;
		LevelBehaviour levelBehaviour = null;
		LevelBehaviour levelBehaviour2 = null;
		foreach (LevelBehaviour behaviour in instance.behaviours)
		{
			if (behaviour.unitType == unitType && filter(behaviour))
			{
				if ((flag && behaviour.upgradeSlots.unlockLevelIndex > num) || (flag2 && behaviour.upgradeSlots.unlockLevelIndex < num))
				{
					num2 = num;
					num = behaviour.upgradeSlots.unlockLevelIndex;
					levelBehaviour2 = levelBehaviour;
					levelBehaviour = behaviour;
				}
				else if ((flag && behaviour.upgradeSlots.unlockLevelIndex > num2) || (flag2 && behaviour.upgradeSlots.unlockLevelIndex < num2))
				{
					num2 = behaviour.upgradeSlots.unlockLevelIndex;
					levelBehaviour2 = behaviour;
				}
			}
		}
		LevelBehaviour result = ((extremeType != GIIHICNDJLG.FirstBest && extremeType != GIIHICNDJLG.FirstWorst) ? levelBehaviour2 : levelBehaviour);
		if (levelBehaviour == null)
		{
			Debug.LogErrorFormat("GetExtreme({0}, {1}, *predict*) is returning null, player should have equipped/unlocked at least one unit from each category", Enum.GetName(typeof(GIIHICNDJLG), extremeType), Enum.GetName(typeof(LevelBehaviour.UnitType), unitType));
		}
		return result;
	}
}
