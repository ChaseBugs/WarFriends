using System;
using System.Collections.Generic;

public static class GKPNDPLOIJC
{
	private static Dictionary<PerkAffects, HashSet<Type>> LJHFJLHANPA = new Dictionary<PerkAffects, HashSet<Type>>();

	public static HashSet<Type> NBKENFKJIBP(PerkAffects CGLGDDEDGBJ)
	{
		if (LJHFJLHANPA.TryGetValue(CGLGDDEDGBJ, out var value))
		{
			return value;
		}
		return OOMGONILBBP(CGLGDDEDGBJ);
	}

	private static HashSet<Type> OOMGONILBBP(PerkAffects LCNNLGIOKNE)
	{
		LJHFJLHANPA[LCNNLGIOKNE] = new HashSet<Type>();
		if (LCNNLGIOKNE.category == PPOHICEELFI.All)
		{
			foreach (LevelBehaviourManager.BehaviourEntry item in Singleton<LevelBehaviourManager>.instance.DHKKHDABING)
			{
				MEJIHGOODGG(LCNNLGIOKNE, item);
			}
		}
		else
		{
			LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)(LCNNLGIOKNE.category - 1);
			foreach (LevelBehaviourManager.BehaviourEntry item2 in Singleton<LevelBehaviourManager>.instance.DHKKHDABING)
			{
				if (item2.behaviour.unitType == unitType)
				{
					MEJIHGOODGG(LCNNLGIOKNE, item2);
				}
			}
		}
		return LJHFJLHANPA[LCNNLGIOKNE];
	}

	private static void MEJIHGOODGG(PerkAffects LCNNLGIOKNE, LevelBehaviourManager.BehaviourEntry IIHPBNNDMBM)
	{
		if (((IIHPBNNDMBM.behaviour.isSoldier && LCNNLGIOKNE.mech == KHAJKMKAHIC.Soldier) || (!IIHPBNNDMBM.behaviour.isSoldier && LCNNLGIOKNE.mech == KHAJKMKAHIC.Mech) || LCNNLGIOKNE.mech == KHAJKMKAHIC.All) && ((IIHPBNNDMBM.behaviour.isAir && LCNNLGIOKNE.fly == GHNACCCKAIG.Fly) || (!IIHPBNNDMBM.behaviour.isAir && LCNNLGIOKNE.fly == GHNACCCKAIG.Ground) || LCNNLGIOKNE.fly == GHNACCCKAIG.All))
		{
			LJHFJLHANPA[LCNNLGIOKNE].Add(IIHPBNNDMBM.behaviour.GetType());
		}
	}
}
