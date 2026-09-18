using System;
using UnityEngine;

[Serializable]
public class SoldierBehaviourDefinititonGrennader : SoldierBehaviourDefinititon
{
	public float grenadeExplodeDamage;

	public float grenadeMinDamage;

	public override void LoadZeros()
	{
		base.LoadZeros();
		grenadeExplodeDamage = 0f;
		grenadeMinDamage = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)d1;
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader2 = (SoldierBehaviourDefinititonGrennader)d2;
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader3 = (SoldierBehaviourDefinititonGrennader)base.Interpolate(d1, d2, ratio);
		soldierBehaviourDefinititonGrennader3.grenadeExplodeDamage = (int)Mathf.Lerp(soldierBehaviourDefinititonGrennader.grenadeExplodeDamage, soldierBehaviourDefinititonGrennader2.grenadeExplodeDamage, ratio);
		soldierBehaviourDefinititonGrennader3.grenadeMinDamage = (int)Mathf.Lerp(soldierBehaviourDefinititonGrennader.grenadeMinDamage, soldierBehaviourDefinititonGrennader2.grenadeMinDamage, ratio);
		return soldierBehaviourDefinititonGrennader3;
	}

	public override void ScaleDamageAndHP(float damageFactor, float hpFactor)
	{
		grenadeExplodeDamage *= damageFactor;
		grenadeMinDamage *= damageFactor;
		base.ScaleDamageAndHP(damageFactor, hpFactor);
	}
}
