using System.Collections.Generic;
using Google2u;

public abstract class UpgradeSlotsGeneric<T> : UpgradeSlots where T : Google2uComponentBase
{
	private T mDatabaseObject;

	public T databaseObject
	{
		get
		{
			if (mDatabaseObject == null)
			{
				mDatabaseObject = GetComponent<T>();
			}
			return mDatabaseObject;
		}
	}

	public override UnitUpgrades LoadData(LevelBehaviour behaviour, UnitUpgrades? boughtUnitUpgrades = null, Perk perk = null)
	{
		UnitUpgrades result = new UnitUpgrades(1f);
		if (behaviour != null)
		{
			BehaviourDefinititon behaviourDefinititon = behaviour.baseBehaviourDefinititon.Copy();
			behaviourDefinititon.shotSpeed = base.bulletSpeed;
			behaviourDefinititon.speed = base.movementSpeed;
			behaviourDefinititon.LoadZeros();
			if (boughtUnitUpgrades.HasValue)
			{
				result = boughtUnitUpgrades.Value;
			}
			else
			{
				result.slotUpgradeindex = upgradeSlot.boughtIndexAbsolute;
				result.slotUpgradeIndexSpecial = upgradeSlotSpecial.boughtIndexAbsolute;
				result.slotUpgradeIndexElite = upgradeSlotElite.boughtIndexAbsolute;
				result.isSpecial = upgradeSlotSpecial.isBought;
				result.isElite = upgradeSlotElite.isBought;
			}
			List<int> list = new List<int>();
			list.Add(result.slotUpgradeindex);
			List<int> list2 = list;
			if (result.isSpecial)
			{
				list2.Add(result.slotUpgradeIndexSpecial);
			}
			if (result.isElite)
			{
				list2.Add(result.slotUpgradeIndexElite);
			}
			foreach (int item in list2)
			{
				LoadDefinitionFromXLS(behaviourDefinititon, item);
			}
			if (perk != null)
			{
				behaviourDefinititon.ScaleByPerk(perk);
			}
			behaviour.behaviourDefinition = behaviourDefinititon;
		}
		return result;
	}

	protected virtual void LoadDefinitionFromXLS(BehaviourDefinititon def, int rowIndex)
	{
	}
}
