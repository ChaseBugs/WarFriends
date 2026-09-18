using System;
using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;

[ExecuteInEditMode]
[Skip]
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

	[Skip]
	public struct UnitUpgrades
	{
		public bool isElite;

		public bool isSpecial;

		public int slotUpgradeindex;

		public int slotUpgradeIndexElite;

		public int slotUpgradeIndexSpecial;

		public float scaleDamage;

		public float scaleHp;
		public UnitUpgrades(float scale) : this()
		{
			scaleDamage = scale;
			scaleHp = scale;
		}

		public static UnitUpgrades GetPreviewUpgrades(LevelBehaviour behavior, float scale = 1f)
		{
			UnitUpgrades result = default(UnitUpgrades);
			bool isUnlocked = behavior.upgradeSlots.upgradeSlotElite.isUnlocked;
			result.isElite = (behavior.upgradeSlots.upgradeSlotElite.isBought && !DebugSettings.instance.nonEliteUnits) || (showElite && isUnlocked);
			result.isSpecial = behavior.upgradeSlots.upgradeSlotSpecial.isBought;
			if (behavior.upgradeSlots.bought)
			{
				if (isUnlocked && showEliteUnitWhenBought && !DebugSettings.instance.nonEliteUnits)
				{
					result.isElite = true;
				}
				result.slotUpgradeindex = ((!result.isElite || behavior.upgradeSlots.upgradeSlotElite.isBought) ? behavior.upgradeSlots.upgradeSlot.boughtIndexAbsolute : behavior.upgradeSlots.upgradeSlot.maxIndexInExcel);
				result.slotUpgradeIndexElite = behavior.upgradeSlots.upgradeSlotElite.boughtIndexAbsolute;
				result.slotUpgradeIndexSpecial = behavior.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute;
			}
			else
			{
				result.slotUpgradeindex = (showMaxLevelWhenNotBought ? behavior.upgradeSlots.upgradeSlot.maxIndexInExcel : 0);
				result.slotUpgradeIndexElite = (showMaxLevelWhenNotBought ? behavior.upgradeSlots.upgradeSlotElite.maxIndexInExcel : 0);
				result.slotUpgradeIndexSpecial = (showMaxLevelWhenNotBought ? behavior.upgradeSlots.upgradeSlotSpecial.maxIndexInExcel : 0);
			}
			result.scaleDamage = scale;
			result.scaleHp = scale;
			return result;
		}

		public override string ToString()
		{
			return string.Format("slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}", slotUpgradeindex, slotUpgradeIndexElite, slotUpgradeIndexSpecial, isSpecial, scaleDamage, scaleHp);
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

	public bool generate;

	public string iconName;

	public bool isTutorialUnit;

	private Google2uComponentBase mExcel;

	private string mExcelType;

	public List<Sounds3DEnum> unitSounds;

	public static bool showMaxLevelWhenNotBought = true;

	public static bool showEliteUnitWhenBought;

	public static bool showElite;

	public UpgradeSlot upgradeSlot;

	public UpgradeSlotSpecial upgradeSlotSpecial;

	public UpgradeSlotElite upgradeSlotElite;

	public bool inSelectMenuEquipped;

	public string iconNameElite => iconName + ((!upgradeSlotElite.isUnlocked) ? string.Empty : "-elite");

	[HideInInspector]
	public bool borrowed
	{
		get
		{
			return GetArmySlot().borrowed;
		}
		set
		{
			GetArmySlot().borrowed = value;
		}
	}

	public ArmyUpgradesRow armyUpgradesRow { get; protected set; }

	public LevelManager.GameLevel unlockLevel
	{
		get
		{
			if (unlockLevelIndex < 0)
			{
				Debug.LogError(string.Concat("unlock level for: ", excel.GetType(), "out of range"));
			}
			return LevelManager.instance.GetLevelDefinition(unlockLevelIndex);
		}
	}

	public int unlockLevelIndex => armyUpgradesRow.UNLOCKLEVEL - 1;

	public int price => armyUpgradesRow.PRICE;

	public int priceGold => armyUpgradesRow.PRICEGOLD;

	public int unitDeliveryTime => armyUpgradesRow.DELIVERTIME;

	public int startUnitLevel => (armyUpgradesRow != null) ? armyUpgradesRow.STARTINGLEVEL : 0;

	public int startTier => armyUpgradesRow.STARTINGTIER;

	public float bulletSpeed => armyUpgradesRow.BULLETSPEED;

	public float playerBehindShieldDamageRatio => armyUpgradesRow.PLAYERBEHINDSHIELDDMGRATIO;

	public float playerDamageRatio => armyUpgradesRow.PLAYERDAMAGERATIO;

	public float playerDamageOvertimeRatio => armyUpgradesRow.PLAYERDAMAGEOVERTIMERATIO;

	public int totalPower => armyUpgradesRow.TOTALPOWER;

	public float coolDown => armyUpgradesRow.COOLDOWN;

	public float shieldHitProbability => armyUpgradesRow.HITSHIELDPROB;

	public string spawns
	{
		get
		{
			string sPAWNS = armyUpgradesRow.SPAWNS;
			return sPAWNS.Replace(" ", $" {Colours.stringGray}/{Colours.stringWhite} ");
		}
	}

	public float movementSpeed => armyUpgradesRow.MOVEMENTSPEED;

	public float soldierRespawnRate => armyUpgradesRow.UNITINMECHANICALRESPAWN;

	public virtual string shotDamageName => Localization.Localize("ID_SHOTDAMAGE");

	public virtual float damage => 0f;

	public virtual float accuracy
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			if (excel.HasColumn("realShotProbability"))
			{
				return (float)excel.GetValue(rowIndex, "realShotProbability");
			}
			return 1f;
		}
	}

	public virtual float rateOfFire
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			if (excel.HasColumn("ShotFrequencyMin") && excel.HasColumn("ShotFrequencyMax") && excel.HasColumn("BatchSizeMin") && excel.HasColumn("BatchSizeMax"))
			{
				float num = (float)excel.GetValue(rowIndex, "ShotFrequencyMin");
				float num2 = (float)excel.GetValue(rowIndex, "ShotFrequencyMax");
				int num3 = (int)excel.GetValue(rowIndex, "BatchSizeMin");
				int num4 = (int)excel.GetValue(rowIndex, "BatchSizeMax");
				return 60f / ((num + num2) * 0.5f) * ((float)(num3 + num4) * 0.5f);
			}
			return 1f;
		}
	}

	public virtual List<Tuple<string, float>> unitSpecifics => new List<Tuple<string, float>>();

	public virtual bool isSpecificTime => false;

	public int instantUnitDeliveryPrice
	{
		get
		{
			if (remainingDeliveringSeconds < 0.0)
			{
				return 0;
			}
			return MiscTools.ConvertTimeIntoGold(Convert.ToInt32(remainingDeliveringSeconds));
		}
	}

	public Google2uComponentBase excel
	{
		get
		{
			if (mExcel == null)
			{
				mExcel = GetComponent<Google2uComponentBase>();
				mExcelType = excel.GetType().ToString();
			}
			return mExcel;
		}
	}

	public bool canBeUpgraded => actualUnitLevel < actualMaxUnitLevel;

	public bool canBuy => !delivering && !deliveryActivationNeeded;

	public float progressDelivering
	{
		get
		{
			if (unitState != State.Delivering && unitState != State.UnitDelivering)
			{
				return 0f;
			}
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			double num = (currentTimestampDouble - (double)startDeliveryTime) / (double)(endDeliveryTime - startDeliveryTime);
			return Mathf.Clamp01((float)num);
		}
	}

	public double remainingDeliveringSeconds
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return (double)endDeliveryTime - currentTimestampDouble;
		}
	}

	public bool isDeliveringOrDelivered => unitState == State.UnitDelivering || unitState == State.UnitDelivered || unitState == State.Delivering || unitState == State.Delivered;

	public State unitState
	{
		get
		{
			if (!unlocked)
			{
				return State.Locked;
			}
			if (bought && delivering)
			{
				return State.Delivering;
			}
			if (bought && deliveryActivationNeeded)
			{
				return State.Delivered;
			}
			if (!bought && delivering)
			{
				return State.UnitDelivering;
			}
			if (!bought && deliveryActivationNeeded)
			{
				return State.UnitDelivered;
			}
			if (!bought)
			{
				return State.NotBuyed;
			}
			return State.Active;
		}
	}

	public bool unlocked => unlockLevelIndex <= LevelManager.instance.currentLevel.index || bought;

	public bool delivering
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return currentTimestampDouble < (double)endDeliveryTime;
		}
	}

	public bool deliveryActivationNeeded
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return GetSheetName() == unitDelivery.itemId && unitDelivery.activationNeeded;
		}
		set
		{
			if (value != deliveryActivationNeeded)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.activationNeeded = value;
			}
		}
	}

	public bool boughtDeliveringInProgress
	{
		get
		{
			GetArmySlot();
			return deliveryActivationNeeded && delivering;
		}
	}

	public bool canUseInBattle
	{
		get
		{
			LevelManager.SavedArmySlots armySlot = GetArmySlot();
			return (armySlot.equipped && bought) || armySlot.borrowed;
		}
	}

	public bool wasEquipped
	{
		get
		{
			return GetArmySlot().wasEquipped;
		}
		set
		{
			if (value != GetArmySlot().wasEquipped)
			{
				GetArmySlot().wasEquipped = value;
			}
		}
	}

	public bool equipped
	{
		get
		{
			return GetArmySlot().equipped;
		}
		set
		{
			if (value != GetArmySlot().equipped)
			{
				GetArmySlot().equipped = value;
			}
		}
	}

	public bool canBeBought => LevelManager.instance.currentLevel.index >= armyUpgradesRow.CANBEBOUGHT - 1;

	public bool bought
	{
		get
		{
			if (isTutorialUnit)
			{
				if (Singleton<GameController>.instance.isTutorial)
				{
					return GetArmySlot().bought;
				}
				return true;
			}
			return (GetArmySlot().bought && canBeBought) || (unlockLevelIndex == 0 && price == 0 && priceGold == 0) || borrowed || isTutorialUnit;
		}
		set
		{
			if (value != bought)
			{
				GetArmySlot().bought = value;
			}
		}
	}

	public int actualTier
	{
		get
		{
			if (!bought)
			{
				return startTier;
			}
			int tier = GetArmySlot().tier;
			if (tier == 0)
			{
				return startTier;
			}
			return tier;
		}
		private set
		{
			GetArmySlot().tier = value;
		}
	}

	public int actualUnitLevel => bought ? (upgradeSlot.boughtIndex + startUnitLevel) : 0;

	public int unlockTierLevel => GetUnlockTierLevel(actualTier);

	public bool isPromoteToNextTierLocked => unlockTierLevel > LevelManager.instance.currentLevel.displayNumber;

	public bool isNew
	{
		get
		{
			if (isTutorialUnit && Singleton<GameController>.instance.isTutorial)
			{
				return true;
			}
			bool wasAlreadyUsed;
			LevelBehaviour lastBoughtUnit = PlayerAnalytics.instance.GetLastBoughtUnit(out wasAlreadyUsed);
			if (lastBoughtUnit.upgradeSlots == this && !wasAlreadyUsed)
			{
				return true;
			}
			return borrowed;
		}
	}

	public int actualMinUnitLevel => upgradeSlot.actualMinLevel + startUnitLevel;

	public int actualMaxUnitLevel => upgradeSlot.actualMaxLevel + startUnitLevel;

	public float actualUpgradeProgress => (float)(actualUnitLevel - actualMinUnitLevel) / (float)(actualMaxUnitLevel - actualMinUnitLevel);

	public bool allUpgradesBought => upgradeSlot.isMaxUpgraded && upgradeSlotSpecial.isMaxUpgraded && upgradeSlotElite.isMaxUpgraded;

	public int numberOfUpgrades => upgradeSlot.maxPower;

	public int maxLevelOfUnit => upgradeSlot.maxPower + startUnitLevel;

	public float upgradesProgress
	{
		get
		{
			int num = (bought ? (upgradeSlot.boughtIndex + 1) : 0);
			return (float)num / (float)numberOfUpgrades;
		}
	}

	public float armyPower => GetArmyPower(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10 => GetArmyPowerX10(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10Max => GetArmyPowerX10(upgradeSlot.maxIndexInExcel, upgradeSlotSpecial.maxIndexInExcel, 6, upgradeSlotElite.maxIndexInExcel, upgradeSlotElite.isUnlocked);

	public int armyPowerX10NextSlot => GetArmyPowerX10(upgradeSlot.boughtIndex + 1, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10NextSpecialSlot => GetArmyPowerX10(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute + 1, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10NextEliteSlot => GetArmyPowerX10(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute + 1, upgradeSlotElite.isBought);

	public bool showed
	{
		get
		{
			return GetArmySlot().showed;
		}
		set
		{
			GetArmySlot().showed = true;
		}
	}

	public int boughtIndex => upgradeSlot.boughtIndex;

	public long startDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return (!(GetSheetName() != unitDelivery.itemId)) ? unitDelivery.start : 0;
		}
		set
		{
			if (value != startDeliveryTime)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.start = value;
			}
		}
	}

	public long endDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return (!(GetSheetName() != unitDelivery.itemId)) ? unitDelivery.end : 0;
		}
		set
		{
			if (value != endDeliveryTime)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.end = value;
			}
		}
	}

	public int deliveringSlotId
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return (!(GetSheetName() != unitDelivery.itemId)) ? unitDelivery.slotId : (-1);
		}
		set
		{
			if (value != deliveringSlotId)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.slotId = value;
			}
		}
	}

	public UpgradeSlot deliveringSlot
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			if (GetSheetName() == unitDelivery.itemId)
			{
				if (unitDelivery.slotId == 0)
				{
					return upgradeSlot;
				}
				if (unitDelivery.slotId == 1)
				{
					return upgradeSlotSpecial;
				}
			}
			return null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		upgradeSlot.owner = this;
		upgradeSlotSpecial.owner = this;
		upgradeSlotElite.owner = this;
	}

	public int GetUnlockTierLevel(int tier)
	{
		if (tier == 1)
		{
			return armyUpgradesRow.UNLOCKTIER2;
		}
		if (tier == 2)
		{
			return armyUpgradesRow.UNLOCKTIER3;
		}
		if (tier == 3)
		{
			return armyUpgradesRow.UNLOCKTIER4;
		}
		if (tier == 4)
		{
			return armyUpgradesRow.UNLOCKTIER5;
		}
		if (tier == 5)
		{
			return armyUpgradesRow.UNLOCKTIER6;
		}
		if (tier > 5)
		{
			return 999;
		}
		return 0;
	}

	public int GetMaxTierForLevel(int level)
	{
		if (level >= armyUpgradesRow.UNLOCKTIER6)
		{
			return 6;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER5)
		{
			return 5;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER4)
		{
			return 4;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER3)
		{
			return 3;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER2)
		{
			return 2;
		}
		return 1;
	}

	public int GetActualLevelForIndex(int index)
	{
		return index + startUnitLevel;
	}

	public float GetSoldierHpInMechanic(int rowIndex)
	{
		bool flag = excel.HasColumn("SoldierHP");
		rowIndex = Mathf.Clamp(rowIndex, 0, upgradeSlot.maxIndexInExcel);
		return (!flag) ? 0f : ((float)excel.GetValue(rowIndex, "SoldierHP"));
	}

	public float GetArmyPower(int index, int indexAbility, int tier, int indexElite, bool isEliteBought)
	{
		float num = upgradeSlot.GetArmyPower(index);
		float num2 = upgradeSlotSpecial.GetArmyPower(indexAbility, tier);
		float num3 = upgradeSlotElite.GetArmyPower(indexElite, isEliteBought);
		return num + num2 + num3;
	}

	public int GetArmyPowerX10(int index, int indexAbility, int tier, int indexElite, bool isEliteBought)
	{
		return MiscTools.RoundToInt(10f * GetArmyPower(index, indexAbility, tier, indexElite, isEliteBought));
	}

	public int GetTier(int boughtIndex)
	{
		return (int)excel.GetValue(boughtIndex, "Tier") + 1;
	}

	public void Init(ArmyUpgradesRow row)
	{
		upgradeSlot.owner = this;
		upgradeSlotSpecial.owner = this;
		armyUpgradesRow = row;
		upgradeSlot.mMaxPower = -1;
		upgradeSlot.mActualMaxLevel = -1;
		upgradeSlot.mActualMinLevel = -1;
		upgradeSlotSpecial.mMaxPower = -1;
		upgradeSlotSpecial.mActualMaxLevel = -1;
		upgradeSlotSpecial.mActualMinLevel = -1;
	}

	public LevelManager.SavedArmySlots GetArmySlot()
	{
		if (armyUpgradesRow == null)
		{
			armyUpgradesRow = new ArmyUpgradesRow
			{
				NAME = string.Empty
			};
		}
		if (LevelManager.instance.data.savedArmies.TryGetValue(GetSheetName(), out var value))
		{
			return value;
		}
		LevelManager.SavedArmySlots savedArmySlots = new LevelManager.SavedArmySlots();
		savedArmySlots.bought = false;
		savedArmySlots.tier = startTier;
		savedArmySlots.showed = unlockLevelIndex == 0;
		value = savedArmySlots;
		LevelManager.instance.data.savedArmies[GetSheetName()] = value;
		return value;
	}

	public int FindLastRowIndex()
	{
		return upgradeSlot.maxIndexInExcel;
	}

	public int GetLastndexForTier(int tier)
	{
		int num = 0;
		for (int i = 0; i < excel.RowsGeneric.Count; i++)
		{
			int num2 = (int)excel.GetValue(i, "Tier");
			if (num2 < tier && num2 >= 0)
			{
				num++;
			}
		}
		return Mathf.Clamp(num - 1, 0, int.MaxValue);
	}

	public virtual List<TechnologyVisualDefinition> GetVisuals(UnitUpgrades unitUpgrades)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, (!unitUpgrades.isElite) ? allVisuals : eliteVisuals));
		return list;
	}

	protected Tuple<string, float[]> StatsFor(UpgradeSlot slot, string identifier, string name)
	{
		Tuple<string, float[]> tuple = new Tuple<string, float[]>();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		num3 += Convert.ToSingle(excel.GetValue(slot.boughtIndexAbsolute, identifier));
		num += ((slot.boughtIndexAbsolute >= slot.maxIndexInExcel) ? 0f : Convert.ToSingle(excel.GetValue(slot.boughtIndexAbsolute + 1, identifier)));
		int maxIndexInExcel = slot.maxIndexInExcel;
		num2 += Convert.ToSingle(excel.GetValue(maxIndexInExcel, identifier));
		tuple.Value1 = name;
		tuple.Value2 = new float[3] { num3, num2, num };
		return tuple;
	}

	protected Tuple<string, float> StartStatsFor(UpgradeSlot slot, string identifier, string name)
	{
		Tuple<string, float> tuple = new Tuple<string, float>();
		tuple.Value1 = name;
		tuple.Value2 = Convert.ToSingle(excel.GetValue(upgradeSlot.boughtIndexAbsolute, identifier));
		return tuple;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		return new List<Tuple<string, float[]>>();
	}

	public virtual List<Tuple<string, float>> GetGuiStatsStart(UpgradeSlot slot)
	{
		return new List<Tuple<string, float>>();
	}

	public virtual List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "special", "percent"));
		return list;
	}

	public virtual List<Tuple<string, float>> GetGuiStatsSpecialStart(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		list.Add(StartStatsFor(slot, "special", "percent"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStatsElite(UpgradeSlotElite slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "elite", "percent"));
		return list;
	}

	public virtual List<Tuple<string, float>> GetGuiStatsEliteStart(UpgradeSlotElite slot)
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		list.Add(StartStatsFor(slot, "elite", "percent"));
		return list;
	}

	public virtual string GetAbilityCurrentValue(UpgradeSlotSpecial slot)
	{
		float value = slot.guiStatistics[0].Value2[0];
		return MiscTools.FormatFloatNumberAsPercent(value);
	}

	public virtual string GetAbilityMaxValue(UpgradeSlotSpecial slot)
	{
		float value = slot.guiStatistics[0].Value2[1];
		return MiscTools.FormatFloatNumberAsPercent(value);
	}

	public virtual string GetAbilityStartValue(UpgradeSlotSpecial slot)
	{
		return "0";
	}

	public virtual string GetEliteBuffCurrentValue(UpgradeSlotElite slot)
	{
		float value = slot.guiStatistics[0].Value2[0];
		return MiscTools.FormatFloatNumberAsPercent(value);
	}

	public virtual string GetEliteBuffMaxValue(UpgradeSlotElite slot)
	{
		float value = slot.guiStatistics[0].Value2[1];
		return MiscTools.FormatFloatNumberAsPercent(value);
	}

	public virtual string GetEliteBuffStartValue(UpgradeSlotElite slot)
	{
		return "0";
	}

	private string GetPath(Texture2D texture)
	{
		return string.Empty;
	}

	public abstract UnitUpgrades LoadData(LevelBehaviour behaviour, UnitUpgrades? boughtUpgrades = null, Perk perk = null);

	public UnitUpgrades LoadDataForWarArena(LevelBehaviour behaviour)
	{
		int num = excel.GetRowIndex("WARARENA");
		if (num < 0)
		{
			Debug.LogError($"{excel.GetType()} doesn't contain data for wararena unit");
			num = 0;
		}
		UnitUpgrades unitUpgrades = new UnitUpgrades(1f);
		UnitUpgrades unitUpgrades2 = unitUpgrades;
		unitUpgrades2.slotUpgradeindex = num;
		unitUpgrades = unitUpgrades2;
		LoadData(behaviour, new UnitUpgrades(1f)
		{
			slotUpgradeindex = num
		});
		BehaviourDefinititon behaviourDefinition = behaviour.behaviourDefinition;
		behaviour.behaviourDefinition = behaviourDefinition;
		return unitUpgrades;
	}

	public void LoadDataForCard(LevelBehaviour behaviour, float progress)
	{
		int num = excel.GetRowIndex("CARDS_MIN");
		int num2 = excel.GetRowIndex("CARDS_MAX");
		if (num < 0 || num2 < 0)
		{
			Debug.LogError($"{excel.GetType()} doesn't contain data for card unit");
			num = 0;
			num2 = 0;
		}
		LoadData(behaviour, new UnitUpgrades(1f)
		{
			slotUpgradeindex = num
		});
		BehaviourDefinititon behaviourDefinition = behaviour.behaviourDefinition;
		LoadData(behaviour, new UnitUpgrades(1f)
		{
			slotUpgradeindex = num2
		});
		BehaviourDefinititon behaviourDefinition2 = behaviour.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.Interpolate(behaviourDefinition, behaviourDefinition2, progress);
		behaviour.behaviourDefinition = behaviourDefinition3;
	}

	public string GetSheetName()
	{
		if (string.IsNullOrEmpty(mExcelType))
		{
			mExcelType = excel.GetType().ToString();
		}
		return mExcelType;
	}

	public virtual void NullOpponentVisuals()
	{
		foreach (TechnologyVisualDefinition allVisual in allVisuals)
		{
			allVisual.NullOpponent();
		}
		foreach (TechnologyVisualDefinition eliteVisual in eliteVisuals)
		{
			eliteVisual.NullOpponent();
		}
	}

	public virtual void NullMineVisuals()
	{
		foreach (TechnologyVisualDefinition allVisual in allVisuals)
		{
			allVisual.NullMine();
		}
		foreach (TechnologyVisualDefinition eliteVisual in eliteVisuals)
		{
			eliteVisual.NullMine();
		}
	}

	public virtual void NullCardVisuals(bool mine, bool opponent)
	{
		foreach (TechnologyVisualDefinition cardVisual in cardVisuals)
		{
			if (mine)
			{
				cardVisual.NullMine();
			}
			if (opponent)
			{
				cardVisual.NullOpponent();
			}
		}
	}

	public IEnumerator LoadMineVisualAsync(int boughtIndex, bool bought, List<TechnologyVisualDefinition> definitions)
	{
		TechnologyVisualDefinition def = GetTechnologyVisualDefinition(boughtIndex, definitions);
		if (bought && def != null)
		{
			yield return StartCoroutine(def.LoadMineAsync());
		}
		foreach (TechnologyVisualDefinition technologyVisualDefinition in definitions)
		{
			if (technologyVisualDefinition != def)
			{
				technologyVisualDefinition.NullMine();
			}
		}
	}

	public IEnumerator LoadOpponentVisualAsync(int boughtIndex, bool bought, List<TechnologyVisualDefinition> definitions)
	{
		TechnologyVisualDefinition def = GetTechnologyVisualDefinition(boughtIndex, definitions);
		if (bought && def != null)
		{
			yield return StartCoroutine(def.LoadOpponentAsync());
		}
		foreach (TechnologyVisualDefinition technologyVisualDefinition in definitions)
		{
			if (technologyVisualDefinition != def)
			{
				technologyVisualDefinition.NullOpponent();
			}
		}
	}

	public virtual IEnumerator LoadMineVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		yield return StartCoroutine(LoadMineVisualAsync(unitUpgrades.slotUpgradeindex, bought, (!unitUpgrades.isElite) ? allVisuals : eliteVisuals));
	}

	public virtual IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		yield return StartCoroutine(LoadOpponentVisualAsync(unitUpgrades.slotUpgradeindex, bought, (!unitUpgrades.isElite) ? allVisuals : eliteVisuals));
	}

	public virtual IEnumerator LoadMineVisualsCoroutineCards()
	{
		foreach (TechnologyVisualDefinition technologyVisualDefinition in cardVisuals)
		{
			yield return StartCoroutine(technologyVisualDefinition.LoadMineAsync());
		}
	}

	public virtual IEnumerator LoadOpponentVisualsCoroutineCards()
	{
		foreach (TechnologyVisualDefinition technologyVisualDefinition in cardVisuals)
		{
			yield return StartCoroutine(technologyVisualDefinition.LoadOpponentAsync());
		}
	}

	public void Buy()
	{
		if (priceGold > 0)
		{
			bought = true;
			return;
		}
		bought = false;
		startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		endDeliveryTime = startDeliveryTime + unitDeliveryTime;
		deliveryActivationNeeded = true;
		Debug.Log("Started delivering |" + GetSheetName() + "| time: " + unitDeliveryTime + "s");
	}

	public void InstantBuyUnit()
	{
		bought = true;
		actualTier = startTier;
		endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		deliveryActivationNeeded = false;
	}

	public void ActivateUnit()
	{
		bought = true;
		actualTier = startTier;
		if (priceGold == 0)
		{
			deliveryActivationNeeded = false;
		}
	}

	public void PromoteUnit()
	{
		actualTier++;
		upgradeSlot.mActualMaxLevel = -1;
		upgradeSlot.mActualMinLevel = -1;
		upgradeSlotSpecial.mActualMaxLevel = -1;
		upgradeSlotSpecial.mActualMinLevel = -1;
	}

	public TechnologyVisualDefinition GetTechnologyVisualDefinition(int level, List<TechnologyVisualDefinition> visuals)
	{
		TechnologyVisualDefinition result = null;
		if (visuals.Count > 0)
		{
			result = visuals[0];
		}
		foreach (TechnologyVisualDefinition visual in visuals)
		{
			if (visual.level <= level)
			{
				result = visual;
			}
		}
		return result;
	}

	public int GetDisplayLevelForIndex(int indexOfLevel)
	{
		return startUnitLevel + indexOfLevel;
	}

	public bool CanUpgrade(UpgradeSlot upgradeSlot1)
	{
		return excel.RowsGeneric.Count > boughtIndex;
	}

	public virtual void UnloadVisuals()
	{
		foreach (TechnologyVisualDefinition allVisual in allVisuals)
		{
			allVisual.UnloadAll();
		}
		foreach (TechnologyVisualDefinition eliteVisual in eliteVisuals)
		{
			eliteVisual.UnloadAll();
		}
		foreach (TechnologyVisualDefinition cardVisual in cardVisuals)
		{
			cardVisual.UnloadAll();
		}
	}

	public virtual Perk PerkImplementation(UnitUpgradeDefinition def, Perk currentPerk)
	{
		return currentPerk;
	}
}
