using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

public class LevelManager : DatabaseSerializedObjectGeneric<LevelManager.LevelManagerData>
{
	public delegate void UnitDataUpdated(string unitId);

	[Preserve]
	public class ItemDelivery
	{
		public bool activationNeeded;

		public int boughtIndex;

		public long end;

		public string itemId;

		public int slotId;

		public long start;

		public int specialFeature;
	}

	[Preserve]
	public class LevelManagerData
	{
		public Dictionary<string, SavedArmySlots> savedArmies;

		public Dictionary<string, SavedWeaponSlots> savedWeapons;

		public ItemDelivery unitDelivery;

		public ItemDelivery weaponDelivery;

		public ItemDelivery unitDelivery2;

		public int GetRemainingUnitDelivery()
		{
			return 0;
		}

		public int GetRemainingUnitDeliverySecond()
		{
			return 0;
		}

		public int GetRemainingWeaponDelivery()
		{
			return 0;
		}
	}

	[Preserve]
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

		public int bmIndex;

		public int bmTier;

		public int bmSpecialIndex;

		public int bmEliteIndex;

		public bool inCovertSlot;

		public int eliteSlot;

		public int parts;
	}

	[Preserve]
	public class SavedWeaponSlots
	{
		public bool bought;

		public int boughtIndex;

		public bool showed;

		public bool borrowed;

		public int specialFeature;

		public Dictionary<string, VariantData> variantData;

		public Dictionary<string, int> augs;

		public int dismantled;
	}

	[Preserve]
	public class VariantData
	{
		public bool bought;

		public int boughtIndex;

		public bool showed;

		public bool borrowed;

		public Dictionary<string, int> augs;

		public int dismantled;
	}

	[Serializable]
	public class GameLevel
	{
		public int index;

		public LevelsRow row;

		public int displayNumber => 0;

		public string displayString => null;

		public string iconName => null;

		public int golds
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int score => 0;

		public int convertGoldToWarbucks => 0;

		public int maxAdBoosters => 0;

		public GameLevel(int level)
		{
		}

		public GameLevel()
		{
		}
	}

	private enum ExtremeType
	{
		FirstBest,
		SecondBest,
		FirstWorst,
		SecondWorst
	}

	private static LevelManager mInstance;

	public List<WeaponLevelsSetup> weaponLevelsSetups;

	public List<LevelBehaviour> behaviours;

	public List<LevelBehaviour> additionalBehaviours;

	private List<WeaponLevelsSetup> mWeaponsSortedByLevel;

	private List<LevelBehaviour> mUnitsSortedByLevel;

	private List<WeaponLevelsSetup> bmWeaponLevelsSetups;

	private Levels mLevelsSheet;

	private WeaponUpgrades mWeaponUpgradesSheet;

	private ArmyUpgrades mArmyUpgradesSheet;

	public int levelExperience;

	public long experience;

	public List<GameLevel> levels;

	private int mLevelIndex;

	private bool mIsLevelUp;

	private int serverArmyPower;

	public static LevelManager instance => null;

	public WeaponFeatures weaponFeatures { get; private set; }

	public List<WeaponLevelsSetup> weaponsSortedByLevel => null;

	public List<LevelBehaviour> unitsSortedByLevel => null;

	public Levels levelsSheet => null;

	public WeaponUpgrades weaponUpgradesSheet => null;

	public ArmyUpgrades armyUpgradesSheet => null;

	public int levelIndex
	{
		get
		{
			return 0;
		}
		private set
		{
		}
	}

	public GameLevel currentLevel => null;

	public GameLevel nextLevel => null;

	public GameLevel previousLevel => null;

	public bool isLevelUp
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int maxDisplayLevel => 0;

	public bool isMaxLevel => false;

	public int armyPower => 0;

	public int bestArmyPower => 0;

	public int bestArmyPowerScaled => 0;

	public int bestArmyPowerScaledPrestigeIndependent => 0;

	public int rankPower => 0;

	public int rankPowerPrestigeIndependent => 0;

	public int unitPower => 0;

	public int bestUnitPower => 0;

	public int bestUnitPowerScaled => 0;

	public int weaponPower => 0;

	public int bestWeaponPower => 0;

	public int armyPowerX10 => 0;

	public int rankPowerX10 => 0;

	public int weaponPowerX10 => 0;

	public int unitPowerX10 => 0;

	public int armyPowerScaledX10 => 0;

	public int unitPowerScaledX10 => 0;

	public int dailyMissionUnlockLevel => 0;

	public int piggyBankUnlockLevel => 0;

	public int joinSquadUnlockLevel => 0;

	public int createSquadUnlockLevel => 0;

	public int warcardsUnlockLevel => 0;

	public int augmentationsUnlockLevel => 0;

	public int goldenSuitcaseUnlockLevel => 0;

	public int lootboxUnlockLevel => 0;

	public int instantBattleUnlockLevel => 0;

	public int warArenaUnlockLevel => 0;

	public int prestigeUnlockLevel => 0;

	public int eventAssignmentUnlockLevel => 0;

	public int blackMarketStoreUnlockLevel => 0;

	public int weaponAugsUnlockLevel => 0;

	public int covertUnitUnlockLevel => 0;

	public int superChargedUnitUnlockLevel => 0;

	public int squadUnlockLevel => 0;

	public int squadJoinAndCreateUnlockLevel => 0;

	public bool isDailyMissionLocked => false;

	public bool isPiggyBankLocked => false;

	public bool isWarcardsLocked => false;

	public bool isAugmentationsLocked => false;

	public bool isGoldenSuitcaseLocked => false;

	public bool isSquadJoinLocked => false;

	public bool isSquadJoinAndCreateLocked => false;

	public bool isSquadLocked => false;

	public bool isMainScreenPartsLocked => false;

	public bool isLootboxesLocked => false;

	public bool isInstantBattleLocked => false;

	public bool isWarArenaLocked => false;

	public bool showWarArenaPromoLocked => false;

	public bool showWarArenaShortcut => false;

	public bool isEventAssignmentLocked => false;

	public bool isBlackMarketLocked => false;

	public bool isWeaponAugsLocked => false;

	public bool isCovertUnitLocked => false;

	public bool isSuperChargedUnitsLocked => false;

	public List<LevelBehaviour> armyUnlocks => null;

	public List<WeaponLevelsSetup> weaponUnlocks => null;

	public List<PlayerVisual> visualUnlocks => null;

	public static bool isNoob => false;

	public static bool canHaveCrates => false;

	public event UnitDataUpdated onUnitDataUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action LevelUp
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void OnDestroy()
	{
	}

	public void SetLevelNumber(int numberToSet)
	{
	}

	public GameLevel GetLevelDefinition(int levelIndex)
	{
		return null;
	}

	public float InterpolateNumbersBasedOnLevel(int LowLevelTreshold, float lowLevelNumber, int HighLevelTreshold, float highLevelNumber)
	{
		return 0f;
	}

	public WeaponLevelsSetup GetBMVariant(int indexInWeaponInventory, int specialVariant)
	{
		return null;
	}

	public static WeaponLevelsSetup GetBestWeaponInCategory(WeaponCategory category)
	{
		return null;
	}

	public static WeaponLevelsSetup GetRandomInCategory(WeaponCategory category)
	{
		return null;
	}

	public int GetRankPower(int displayLevel)
	{
		return 0;
	}

	public int GetRankPowerX10(int displayLevel)
	{
		return 0;
	}

	internal float GetPlayerLevelProgress()
	{
		return 0f;
	}

	public int GetIndexOfNotBoughtUnit()
	{
		return 0;
	}

	public int GetIndexOfNotBoughtWeapon()
	{
		return 0;
	}

	public int GetIndexOfUpgradeableWeapon()
	{
		return 0;
	}

	public LevelBehaviour GetBoughtUnitWithBiggestUnlockLevel()
	{
		return null;
	}

	public List<WeaponLevelsSetup> GetSuitableWeapons(WeaponCategory category, int maxLevel, float minWeaponPower, float maxWeaponPower, WeaponCategory excludeCategory)
	{
		return null;
	}

	public int GetLastUnlockedWeapon(WeaponCategory category, int level)
	{
		return 0;
	}

	public int GetLastUnlockedWeaponForBot(WeaponCategory category, int level)
	{
		return 0;
	}

	public int GetLastBoughtWeapon(WeaponCategory category)
	{
		return 0;
	}

	public float GetPrewProgress(int score)
	{
		return 0f;
	}

	public float GetProgress()
	{
		return 0f;
	}

	public void SetLevelUpProgressForTutorial(int level, float xpFract, bool levelUp)
	{
	}

	public void CheckCurrentLevelForTutorial(int level)
	{
	}

	internal void DebugAddLevel()
	{
	}

	internal void LoadData(int level, int loadedLevelExperience, long loadedExperience, int loadedArmyPower)
	{
	}

	internal void LoadData(int level, int experience)
	{
	}

	internal void UpdateUnit(string index, JToken unitJson)
	{
	}

	internal void UpdateWeapon(string index, JToken weaponJson, int specialFeature = -1)
	{
	}

	internal void UpdateWeaponDelivery(JToken item)
	{
	}

	internal void UpdateUnitDelivery(JToken item)
	{
	}

	internal void UpdateSecondUnitDelivery(JToken item)
	{
	}

	protected override void Awake()
	{
	}

	private void OnGameStarted()
	{
	}

	private void OnGameEnded(GameController.ALOAMODMHMO endReason)
	{
	}

	public void Init()
	{
	}

	public WeaponLevelsSetup AddBMVariant(int indexInLevelManager, int specialFeature)
	{
		return null;
	}

	private void OnPlayerDataLoaded()
	{
	}

	public List<UnitUpgradeDefinition> GetUpgrades()
	{
		return null;
	}

	public LevelBehaviour GetBehaviour(Type type)
	{
		return null;
	}

	public LevelBehaviour DeliveringUnit()
	{
		return null;
	}

	public LevelBehaviour SecondDeliveringUnit()
	{
		return null;
	}

	public WeaponLevelsSetup DeliveringWeapon()
	{
		return null;
	}

	public float DamageFunction(float number)
	{
		return 0f;
	}

	internal void SetWeaponDeliveryTime(JToken jToken)
	{
	}

	internal void SetUnitDeliveryTime(JToken jToken, string sheetName)
	{
	}

	public WeaponLevelsSetup Weapon(string sheetName, int special = -1)
	{
		return null;
	}

	public LevelBehaviour Unit(string sheetName)
	{
		return null;
	}

	public LevelBehaviour StrongestBoughtUnit(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public int NumberOfBought(WeaponCategory category)
	{
		return 0;
	}

	public int NumberOfEquippedPerks()
	{
		return 0;
	}

	public LevelBehaviour GetUnit(Type type)
	{
		return null;
	}

	public bool IsUnit(string sheetName)
	{
		return false;
	}

	public bool IsWeapon(string sheetName)
	{
		return false;
	}

	public WeaponLevelsSetup StrongestBoughtWeapon(WeaponCategory category)
	{
		return null;
	}

	public static LevelBehaviour GetWorstEquipped(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public static LevelBehaviour GetSecondWorstEquipped(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public static LevelBehaviour GetWorstBought(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public static LevelBehaviour GetSecondWorstBought(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public static LevelBehaviour GetBestEquipped(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public static LevelBehaviour GetSecondBestEquipped(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public static LevelBehaviour GetBestBought(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	public static LevelBehaviour GetSecondBestBought(LevelBehaviour.UnitType unitType)
	{
		return null;
	}

	private static LevelBehaviour GetExtreme(ExtremeType extremeType, LevelBehaviour.UnitType unitType, Func<LevelBehaviour, bool> filter)
	{
		return null;
	}
}
