using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

[ExecuteInEditMode]
public abstract class UpgradeSlots : Core_BaseScript
{
	public enum State
	{
		Locked,
		NotBuyed,
		UnitDelivering,
		UnitDelivered,
		Active,
		Delivering,
		Delivered
	}

	public enum ScreenRightState
	{
		Locked,
		BuyIt,
		BuyRental,
		BMSubscriberOnly,
		Nothing
	}

	public enum ScreenLeftState
	{
		Empty,
		RentIt,
		Rented,
		Upgrade,
		DeliverNow,
		Activate,
		MaxUpgraded,
		Loyalty,
		BMEarlyUnlock,
		BMSkipped
	}

	public enum ScreenBottomState
	{
		Locked,
		Buyable,
		Rented,
		Rentable,
		EarlyAccess,
		Skipped,
		Other
	}

	public struct UnitUpgrades
	{
		public bool isElite;

		public bool isVeteran;

		public bool isSpecial;

		public int slotUpgradeindex;

		public int slotUpgradeIndexElite;

		public int slotUpgradeIndexSpecial;

		public float scaleDamage;

		public float scaleHp;

		public static UnitUpgrades GetPreviewUpgrades(LevelBehaviour behavior, float scale = 1f)
		{
			return default(UnitUpgrades);
		}

		public UnitUpgrades(float scale)
		{
			isElite = false;
			isVeteran = false;
			isSpecial = false;
			slotUpgradeindex = 0;
			slotUpgradeIndexElite = 0;
			slotUpgradeIndexSpecial = 0;
			scaleDamage = 0f;
			scaleHp = 0f;
		}

		public override string ToString()
		{
			return null;
		}
	}

	[Serializable]
	public class VisualSlotMesh
	{
		public MeshRenderer part;

		public MeshRenderer partRed;

		public int visualSlotId;
	}

	public List<TechnologyVisualDefinition> allVisuals;

	public List<TechnologyVisualDefinition> eliteVisuals;

	public List<TechnologyVisualDefinition> cardVisuals;

	public string iconName;

	public bool isTutorialUnit;

	private Google2uComponentBase mExcel;

	private string mExcelType;

	public List<ICHBAJOHDJC> unitSounds;

	public static bool showMaxLevelWhenNotBought;

	public static bool showEliteUnitWhenBought;

	public static bool showElite;

	public LevelBehaviour owner;

	public UpgradeSlot upgradeSlot;

	public UpgradeSlotSpecial upgradeSlotSpecial;

	public UpgradeSlotElite upgradeSlotElite;

	public bool inSelectMenuEquipped;

	public string iconNameElite => null;

	public string iconNameVeteran => null;

	public bool borrowed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool inCovertSlot
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ArmyUpgradesRow armyUpgradesRow { get; protected set; }

	public LevelManager.GameLevel unlockLevel => null;

	public int unlockLevelIndex => 0;

	public int price => 0;

	public int priceGold => 0;

	public int unitDeliveryTime => 0;

	public int startUnitLevel => 0;

	public int startTier => 0;

	public float bulletSpeed => 0f;

	public float playerBehindShieldDamageRatio => 0f;

	public float playerDamageRatio => 0f;

	public float playerDamageOvertimeRatio => 0f;

	public int totalPower => 0;

	public float coolDown => 0f;

	public float shieldHitProbability => 0f;

	public string spawns => null;

	public float movementSpeed => 0f;

	public float soldierRespawnRate => 0f;

	public virtual string shotDamageName => null;

	public virtual float damage => 0f;

	public virtual float accuracy => 0f;

	public virtual float rateOfFire => 0f;

	public virtual List<Tuple<string, float>> unitSpecifics => null;

	public virtual bool isSpecificTime => false;

	public int instantUnitDeliveryPrice => 0;

	public Google2uComponentBase excel => null;

	public bool canBeUpgraded => false;

	public bool canDisplayUpgradeSale => false;

	public bool canBuy => false;

	public float progressDelivering => 0f;

	public double remainingDeliveringSeconds => 0.0;

	public bool isDeliveringOrDelivered => false;

	public State unitState => default(State);

	public ScreenRightState screenRightState => default(ScreenRightState);

	public ScreenLeftState screenLeftState => default(ScreenLeftState);

	public ScreenBottomState screenBottomState => default(ScreenBottomState);

	public bool unlocked => false;

	public bool delivering => false;

	public bool deliveryActivationNeeded
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool boughtDeliveringInProgress => false;

	public bool canUseInBattle => false;

	public bool wasEquipped
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool equipped
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool canBeBought => false;

	public bool bought
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool isEarlyUnlockBMActive => false;

	private bool isSkippedBMActive => false;

	public int actualTier
	{
		get
		{
			return 0;
		}
		private set
		{
		}
	}

	public int bmTier
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int actualUnitLevel => 0;

	public int unlockTierLevel => 0;

	public bool isPromoteToNextTierLocked => false;

	public bool isNew => false;

	public virtual int actualMinUnitLevel => 0;

	public int actualMaxUnitLevel => 0;

	public int actualMaxBmLevel => 0;

	public float actualUpgradeProgress => 0f;

	public bool allUpgradesBought => false;

	public int numberOfUpgrades => 0;

	public int maxLevelOfUnit => 0;

	public float upgradesProgress => 0f;

	public int bmArmyPower => 0;

	public float armyPower => 0f;

	public int armyPowerX10 => 0;

	public int armyPowerX10Max => 0;

	public int armyPowerX10NextSlot => 0;

	public int armyPowerX10NextSpecialSlot => 0;

	public int armyPowerX10NextEliteSlot => 0;

	public bool showed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int boughtIndex => 0;

	public long startDeliveryTime
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	public long endDeliveryTime
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	public int deliveringSlotId
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public UpgradeSlot deliveringSlot => null;

	protected override void Awake()
	{
	}

	public int GetUnlockLevelForNextTier(int tier)
	{
		return 0;
	}

	public int GetUnlockLevelForTier(int tier)
	{
		return 0;
	}

	public int GetMaxTierForLevel(int level)
	{
		return 0;
	}

	public int GetActualLevelForIndex(int index)
	{
		return 0;
	}

	public float GetArmyPower(int index, int indexAbility, int tier, int indexElite, bool isEliteBought)
	{
		return 0f;
	}

	public int GetArmyPowerX10(int index, int indexAbility, int tier, int indexElite, bool isEliteBought)
	{
		return 0;
	}

	public int GetArenaArmyPowerX10(int index)
	{
		return 0;
	}

	public int GetTier(int boughtIndex)
	{
		return 0;
	}

	public void SetLocalUpgradedUnitFromBM()
	{
	}

	public void Init(ArmyUpgradesRow row)
	{
	}

	public virtual LevelManager.SavedArmySlots GetArmySlot()
	{
		return null;
	}

	public int FindLastRowIndex()
	{
		return 0;
	}

	public int GetLastndexForTier(int tier)
	{
		return 0;
	}

	private List<TechnologyVisualDefinition> GetVisualDefinitions(UnitUpgrades upgrades)
	{
		return null;
	}

	public virtual List<TechnologyVisualDefinition> GetVisuals(UnitUpgrades unitUpgrades)
	{
		return null;
	}

	protected Tuple<string, float[]> StatsFor(UpgradeSlot slot, string identifier, string name)
	{
		return null;
	}

	protected Tuple<string, float[]> StatsForBm(UpgradeSlot slot, string identifier, string name)
	{
		return null;
	}

	protected Tuple<string, float> StartStatsFor(UpgradeSlot slot, string identifier, string name)
	{
		return null;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		return null;
	}

	public virtual List<Tuple<string, float[]>> GetBmGuiStats(UpgradeSlot slot)
	{
		return null;
	}

	public virtual List<Tuple<string, float>> GetGuiStatsStart(UpgradeSlot slot)
	{
		return null;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial slot)
	{
		return null;
	}

	public virtual List<Tuple<string, float>> GetGuiStatsSpecialStart(UpgradeSlotSpecial slot)
	{
		return null;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStatsElite(UpgradeSlotElite slot)
	{
		return null;
	}

	public virtual List<Tuple<string, float>> GetGuiStatsEliteStart(UpgradeSlotElite slot)
	{
		return null;
	}

	public virtual string GetAbilityCurrentValue(UpgradeSlotSpecial slot)
	{
		return null;
	}

	public virtual string GetAbilityMaxValue(UpgradeSlotSpecial slot)
	{
		return null;
	}

	public virtual string GetAbilityStartValue(UpgradeSlotSpecial slot)
	{
		return null;
	}

	public virtual string GetEliteBuffCurrentValue(UpgradeSlotElite slot)
	{
		return null;
	}

	public virtual string GetEliteBuffMaxValue(UpgradeSlotElite slot)
	{
		return null;
	}

	public virtual string GetEliteBuffStartValue(UpgradeSlotElite slot)
	{
		return null;
	}

	private string GetPath(Texture2D texture)
	{
		return null;
	}

	public abstract UnitUpgrades LoadData(LevelBehaviour behaviour, UnitUpgrades? boughtUpgrades = null, FEPKHDHDKII perk = null);

	public UnitUpgrades LoadDataForWarArena(LevelBehaviour behaviour)
	{
		return default(UnitUpgrades);
	}

	public void LoadDataForCard(LevelBehaviour behaviour, float progress)
	{
	}

	public void LoadDataForInvader(LevelBehaviour behaviour, float progress)
	{
	}

	public string GetSheetName()
	{
		return null;
	}

	public virtual void NullOpponentVisuals()
	{
	}

	public virtual void NullMineVisuals()
	{
	}

	public virtual void NullCardVisuals(bool mine, bool opponent)
	{
	}

	public IEnumerator LoadMineVisualAsync(int boughtIndex, bool bought, List<TechnologyVisualDefinition> definitions)
	{
		return null;
	}

	public IEnumerator LoadOpponentVisualAsync(int boughtIndex, bool bought, List<TechnologyVisualDefinition> definitions)
	{
		return null;
	}

	public virtual IEnumerator LoadMineVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		return null;
	}

	public virtual IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		return null;
	}

	public virtual IEnumerator LoadMineVisualsCoroutineCards()
	{
		return null;
	}

	public virtual IEnumerator LoadOpponentVisualsCoroutineCards()
	{
		return null;
	}

	public void Buy()
	{
	}

	public void InstantBuyUnit()
	{
	}

	public void ActivateUnit()
	{
	}

	public void PromoteUnit()
	{
	}

	public TechnologyVisualDefinition GetTechnologyVisualDefinition(int level, List<TechnologyVisualDefinition> visuals)
	{
		return null;
	}

	public int GetDisplayLevelForIndex(int indexOfLevel)
	{
		return 0;
	}

	public bool CanUpgrade(UpgradeSlot upgradeSlot1)
	{
		return false;
	}

	public virtual void UnloadVisuals()
	{
	}

	public virtual void UnloadMineVisuals()
	{
	}

	public virtual void UnloadOpponentVisuals()
	{
	}

	public virtual FEPKHDHDKII PerkImplementation(UnitUpgradeDefinition def, FEPKHDHDKII currentPerk)
	{
		return null;
	}
}
