using System;
using UnityEngine;

[Serializable]
public class SoldierBehaviourDefinititonBuddy : SoldierBehaviourDefinititon
{
	public float explodeMaxDamage;

	public float explodeMinDamage;

	public override void LoadZeros()
	{
		base.LoadZeros();
		explodeMaxDamage = 0f;
		explodeMinDamage = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)d1;
		SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy2 = (SoldierBehaviourDefinititonBuddy)d2;
		SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy3 = (SoldierBehaviourDefinititonBuddy)base.Interpolate(d1, d2, ratio);
		soldierBehaviourDefinititonBuddy3.explodeMaxDamage = (int)Mathf.Lerp(soldierBehaviourDefinititonBuddy.explodeMaxDamage, soldierBehaviourDefinititonBuddy2.explodeMaxDamage, ratio);
		soldierBehaviourDefinititonBuddy3.explodeMinDamage = (int)Mathf.Lerp(soldierBehaviourDefinititonBuddy.explodeMinDamage, soldierBehaviourDefinititonBuddy2.explodeMinDamage, ratio);
		return soldierBehaviourDefinititonBuddy3;
	}
}
