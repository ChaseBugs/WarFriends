using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradeSlotSpecial : UpgradeSlot
{
	public override int id => 1;

	public override bool isSpecial => true;

	public override bool isMaxUpgraded => base.isMaxUpgraded || owner.startTier >= 6;

	public override int indexOffset => owner.armyUpgradesRow.STARTINGSPECIAL;

	public override int boughtIndex
	{
		get
		{
			if (owner == null)
			{
				return 0;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return Mathf.Clamp(armySlot.specialSlot, 0, base.maxPower - 1);
		}
		set
		{
			if (value != boughtIndex)
			{
				owner.GetArmySlot().specialSlot = value;
			}
		}
	}

	public override bool isBought => owner.actualTier > owner.startTier;

	public override List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStatsSpecial(this);

	public override List<Tuple<string, float>> guiStatisticsStart => owner.GetGuiStatsSpecialStart(this);

	public string abilityValue => owner.GetAbilityCurrentValue(this);

	public string abilityMaxValue => owner.GetAbilityMaxValue(this);

	public string abilityStartValue => owner.GetAbilityStartValue(this);

	public override int armyPowerX10 => GetArmyPowerX10(base.boughtIndexAbsolute, owner.actualTier);

	public int GetArmyPowerX10(int boughtIndexSpecial, int tier)
	{
		return MiscTools.RoundToInt(10f * GetArmyPower(boughtIndexSpecial, tier));
	}

	public float GetArmyPower(int boughtIndexSpecial, int tier)
	{
		boughtIndexSpecial = Mathf.Clamp(boughtIndexSpecial, indexOffset, base.maxIndexInExcel);
		return (tier <= owner.startTier) ? 0f : ((float)owner.excel.GetValue(boughtIndexSpecial, "ArmyPower"));
	}
}
