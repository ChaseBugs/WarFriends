using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

[Serializable]
public class UpgradeSlotElite : UpgradeSlot
{
	public override int id => 2;

	public override bool isSpecial => true;

	public override int indexOffset => owner.armyUpgradesRow.STARTINGELITE;

	public override bool isMaxUpgraded => !isUnlocked || base.isMaxUpgraded;

	public int upgradePriceParts => (int)owner.excel.GetValue(base.boughtIndexAbsolute, "NextUpgradePriceGold");

	public float progress => (float)currentParts / (float)upgradePriceParts;

	public int missingScraps
	{
		get
		{
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PartToScrapsUpgrade).FLOATVALUE;
			return (int)((float)(upgradePriceParts - currentParts) * (float)fLOATVALUE);
		}
	}

	public int currentParts
	{
		get
		{
			return owner.GetArmySlot().parts;
		}
		set
		{
			owner.GetArmySlot().parts = value;
		}
	}

	public override int boughtIndex
	{
		get
		{
			if (owner == null)
			{
				return 0;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return Mathf.Clamp(armySlot.eliteSlot, 0, base.maxPower - 1);
		}
		set
		{
			if (value != boughtIndex)
			{
				owner.GetArmySlot().eliteSlot = value;
			}
		}
	}

	public override bool isUnlocked => owner.armyUpgradesRow.STARTINGELITE > 0;

	public override bool isBought
	{
		get
		{
			if (!isUnlocked)
			{
				return false;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return armySlot.eliteSlot > 0;
		}
	}

	public override List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStatsElite(this);

	public override List<Tuple<string, float>> guiStatisticsStart => owner.GetGuiStatsEliteStart(this);

	public string buffValue => owner.GetEliteBuffCurrentValue(this);

	public string buffMaxValue => owner.GetEliteBuffMaxValue(this);

	public string buffStartValue => owner.GetEliteBuffStartValue(this);

	public override int armyPowerX10 => GetArmyPowerX10(base.boughtIndexAbsolute, isBought);

	public override int actualMaxLevel => base.maxPower - 1;

	public int GetArmyPowerX10(int boughtIndexElite, bool bought)
	{
		return MiscTools.RoundToInt(10f * GetArmyPower(boughtIndexElite, bought));
	}

	public float GetArmyPower(int boughtIndexElite, bool bought)
	{
		boughtIndexElite = Mathf.Clamp(boughtIndexElite, indexOffset, base.maxIndexInExcel);
		return (!bought) ? 0f : ((float)owner.excel.GetValue(boughtIndexElite, "ArmyPower"));
	}

	public void BuyAndActivate()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.ActivateUpgrade);
		boughtIndex++;
		Debug.Log("Army upgrade for " + owner.GetSheetName() + "  " + boughtIndex + " was BuyAndActivated.");
	}
}
