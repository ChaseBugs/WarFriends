using System.Collections.Generic;
using UnityEngine;

public class DeathMatchUnitsGuiElementFixed : DeathMatchUnitsGuiElement
{
	protected override float mAnimDelay => 0f;

	protected override bool isActive => Singleton<GameController>.instance.mainController.spawningType == SpawningType.Fixed;

	private SpawningManagerDeathMatch.ArmyUnitDefinition FindNew(List<SpawningManagerDeathMatch.ArmyUnitDefinition> findIn, List<SpawningManagerDeathMatch.ArmyUnitDefinition> curent)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in findIn)
		{
			if (!curent.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	protected override void FillAndSortUnits()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> currentArmyUnitDefinitions = Singleton<SpawningManagerDeathMatch>.instance.currentArmyUnitDefinitions;
		for (int i = 0; i < Mathf.Max(mUnits.Count, 3); i++)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < mUnits.Count) ? mUnits[i] : null);
			if (armyUnitDefinition == null || !currentArmyUnitDefinitions.Contains(armyUnitDefinition))
			{
				if (i >= mUnits.Count)
				{
					mUnits.Add(FindNew(currentArmyUnitDefinitions, mUnits));
				}
				else
				{
					mUnits[i] = FindNew(currentArmyUnitDefinitions, mUnits);
				}
			}
		}
	}

	protected override void HideProgress()
	{
	}
}
