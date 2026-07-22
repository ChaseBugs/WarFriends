using System;
using UnityEngine;

[CreateAssetMenu]
public class WarArenaRuleRandomUnitCategory : WarArenaRuleGeneric<WarArenaRuleRandomUnitCategory.Data>
{
	[Serializable]
	public class Data : RuleData
	{
	}

	private LevelBehaviour.UnitType getRandomType => default(LevelBehaviour.UnitType);

	protected override HIBLLEGMMEM ENNBBKNEMBH()
	{
		return null;
	}

	public override bool JPBAMFLFLFA()
	{
		return false;
	}
}
