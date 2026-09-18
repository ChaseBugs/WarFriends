using System;
using System.Collections.Generic;

public static class PerkUnitCategories
{
	private static Dictionary<PerkAffects, HashSet<Type>> mCache = new Dictionary<PerkAffects, HashSet<Type>>();

	public static HashSet<Type> GetUnits(PerkAffects unitcategory)
	{
		if (mCache.TryGetValue(unitcategory, out var value))
		{
			return value;
		}
		return FillUnitCat(unitcategory);
	}

	private static HashSet<Type> FillUnitCat(PerkAffects perkAffects)
	{
		mCache[perkAffects] = new HashSet<Type>();
		if (perkAffects.category == PerkUnitCategory.All)
		{
			foreach (LevelBehaviourManager.BehaviourEntry levelBehaviour in Singleton<LevelBehaviourManager>.instance.levelBehaviours)
			{
				CheckUnit(perkAffects, levelBehaviour);
			}
		}
		else
		{
			LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)(perkAffects.category - 1);
			foreach (LevelBehaviourManager.BehaviourEntry levelBehaviour2 in Singleton<LevelBehaviourManager>.instance.levelBehaviours)
			{
				if (levelBehaviour2.behaviour.unitType == unitType)
				{
					CheckUnit(perkAffects, levelBehaviour2);
				}
			}
		}
		return mCache[perkAffects];
	}

	private static void CheckUnit(PerkAffects perkAffects, LevelBehaviourManager.BehaviourEntry levelBehaviour)
	{
		if (((levelBehaviour.behaviour.isSoldier && perkAffects.mech == PerkMechcategory.Soldier) || (!levelBehaviour.behaviour.isSoldier && perkAffects.mech == PerkMechcategory.Mech) || perkAffects.mech == PerkMechcategory.All) && ((levelBehaviour.behaviour.isAir && perkAffects.fly == PerkFlyCategory.Fly) || (!levelBehaviour.behaviour.isAir && perkAffects.fly == PerkFlyCategory.Ground) || perkAffects.fly == PerkFlyCategory.All))
		{
			mCache[perkAffects].Add(levelBehaviour.behaviour.GetType());
		}
	}
}
