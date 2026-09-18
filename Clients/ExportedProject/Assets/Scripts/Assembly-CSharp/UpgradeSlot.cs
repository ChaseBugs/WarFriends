using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradeSlot
{
	public UpgradeSlots owner;

	internal int mMaxPower = -1;

	internal int mActualMaxLevel = -1;

	internal int mActualMinLevel = -1;

	public virtual int id => 0;

	public virtual bool isSpecial => false;

	public virtual int indexOffset => 0;

	public virtual bool isMaxUpgraded => boughtIndex + 1 >= maxPower;

	public bool isDelivering => owner.deliveringSlot == this;

	public bool isTierFullUpgraded => boughtIndex == actualMaxLevel;

	public virtual int boughtIndex
	{
		get
		{
			if (owner == null)
			{
				return 0;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return Mathf.Clamp(armySlot.boughtIndex, 0, maxPower - 1);
		}
		set
		{
			if (value != boughtIndex)
			{
				owner.GetArmySlot().boughtIndex = value;
			}
		}
	}

	public int boughtIndexAbsolute => boughtIndex + indexOffset;

	public virtual bool isBought
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public virtual bool isUnlocked => true;

	public bool canUpgrade => owner.CanUpgrade(this);

	public bool canBuy => owner.canBuy;

	public bool canActivate => !owner.delivering && owner.deliveryActivationNeeded;

	public int upgradePrice => (int)owner.excel.GetValue(boughtIndexAbsolute, "NextUpgradePrice");

	public virtual List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStats(this);

	public virtual List<Tuple<string, float>> guiStatisticsStart => owner.GetGuiStatsStart(this);

	public int actualMinLevel
	{
		get
		{
			if (mActualMinLevel > -1)
			{
				return mActualMinLevel;
			}
			if (!owner.excel.HasColumn("Tier"))
			{
				Debug.LogError($"Excel {owner.excel.GetType()} dont have row Tier!!!");
				return 0;
			}
			int num = 0;
			for (int i = 0; i < owner.excel.RowsGeneric.Count; i++)
			{
				int num2 = (int)owner.excel.GetValue(i, "Tier");
				if (num2 / 10 == id && num2 >= 0)
				{
					num2 %= 10;
					if (num2 > -1 && num2 < owner.actualTier - 1)
					{
						num++;
					}
				}
			}
			mActualMinLevel = Mathf.Max(0, num - 1);
			return mActualMinLevel;
		}
	}

	public virtual int actualMaxLevel
	{
		get
		{
			if (mActualMaxLevel > -1)
			{
				return mActualMaxLevel;
			}
			if (!owner.excel.HasColumn("Tier"))
			{
				Debug.LogError($"Excel {owner.excel.GetType()} dont have row Tier!!!");
				return owner.excel.RowsGeneric.Count;
			}
			int num = 0;
			for (int i = 0; i < owner.excel.RowsGeneric.Count; i++)
			{
				int num2 = (int)owner.excel.GetValue(i, "Tier");
				if (num2 / 10 == id && num2 >= 0)
				{
					num2 %= 10;
					if (num2 > -1 && num2 < owner.actualTier)
					{
						num++;
					}
				}
			}
			mActualMaxLevel = Mathf.Max(0, num - 1);
			return mActualMaxLevel;
		}
	}

	public int maxPower
	{
		get
		{
			if (mMaxPower > 0)
			{
				return mMaxPower;
			}
			if (!owner.excel.HasColumn("Tier"))
			{
				return owner.excel.RowsGeneric.Count;
			}
			int num = 0;
			for (int i = 0; i < owner.excel.RowsGeneric.Count; i++)
			{
				int num2 = (int)owner.excel.GetValue(i, "Tier");
				if (num2 / 10 == id && num2 >= 0)
				{
					num++;
				}
			}
			mMaxPower = num;
			return num;
		}
	}

	public int maxIndexInExcel => indexOffset + maxPower - 1;

	public int deliveryTime => (int)(float)owner.excel.GetValue(boughtIndexAbsolute, "DeliveryTime");

	public int instantBuyPrice
	{
		get
		{
			if (owner.remainingDeliveringSeconds < 0.0)
			{
				return 0;
			}
			return MiscTools.ConvertTimeIntoGold(Convert.ToInt32(owner.remainingDeliveringSeconds));
		}
	}

	public int fullPrizeOfUpgradeDeliveryGold
	{
		get
		{
			if (!owner.canBeUpgraded)
			{
				return 0;
			}
			return MiscTools.ConvertTimeIntoGold(deliveryTime);
		}
	}

	public virtual int armyPowerX10 => GetArmyPowerX10(boughtIndexAbsolute);

	public int GetArmyPowerX10(int boughtIndex)
	{
		return MiscTools.RoundToInt(10f * GetArmyPower(boughtIndex));
	}

	public float GetArmyPower(int boughtIndex)
	{
		boughtIndex = Mathf.Clamp(boughtIndex, 0, maxIndexInExcel);
		return (float)owner.excel.GetValue(boughtIndex, "ArmyPower");
	}

	public void BuyUpgrade()
	{
		if (canUpgrade && canBuy)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Upgrade);
			owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			owner.endDeliveryTime = owner.startDeliveryTime + deliveryTime;
			owner.deliveryActivationNeeded = true;
			owner.deliveringSlotId = id;
			Debug.Log("Started delivering army upgrade for " + owner.GetSheetName() + "  " + boughtIndex + ". It will be ready in " + deliveryTime + " seconds.");
		}
	}

	public void Activate()
	{
		if (canActivate)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.ActivateUpgrade);
			boughtIndex++;
			owner.deliveryActivationNeeded = false;
			Debug.Log("Army upgrade for " + owner.GetSheetName() + "  " + boughtIndex + " was activated.");
		}
	}

	public void InstantActivation()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.ActivateUpgrade);
		boughtIndex++;
		owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		owner.deliveryActivationNeeded = false;
		Debug.Log("Army upgrade for " + owner.GetSheetName() + " " + boughtIndex + " was activated (through fast activation).");
	}
}
