using System;
using UnityEngine;

[Serializable]
public class SoldierBehaviourDefinititonSciFi : SoldierBehaviourDefinititon
{
	public float grenadeMinDamage;

	public float grenadeExplodeDamage;

	public override void LoadZeros()
	{
		base.LoadZeros();
		grenadeExplodeDamage = 0f;
		grenadeMinDamage = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		SoldierBehaviourDefinititonSciFi soldierBehaviourDefinititonSciFi = (SoldierBehaviourDefinititonSciFi)d1;
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader = (SoldierBehaviourDefinititonGrennader)d2;
		SoldierBehaviourDefinititonGrennader soldierBehaviourDefinititonGrennader2 = (SoldierBehaviourDefinititonGrennader)base.Interpolate(d1, d2, ratio);
		soldierBehaviourDefinititonGrennader2.grenadeExplodeDamage = (int)Mathf.Lerp(soldierBehaviourDefinititonSciFi.grenadeExplodeDamage, soldierBehaviourDefinititonGrennader.grenadeExplodeDamage, ratio);
		soldierBehaviourDefinititonGrennader2.grenadeMinDamage = (int)Mathf.Lerp(soldierBehaviourDefinititonSciFi.grenadeMinDamage, soldierBehaviourDefinititonGrennader.grenadeMinDamage, ratio);
		return soldierBehaviourDefinititonGrennader2;
	}

	public override void ScaleDamageAndHP(float damageFactor, float hpFactor)
	{
		grenadeExplodeDamage *= damageFactor;
		grenadeMinDamage *= damageFactor;
		base.ScaleDamageAndHP(damageFactor, hpFactor);
	}
}
