using System;
using UnityEngine;

[Serializable]
public class TankBehaviourDefinititon : VehicleBehaviourDefinititon
{
	public float damageCannon;

	public float maxShootTimeCannon;

	public float minShootTimeCannon;

	public override void LoadZeros()
	{
		base.LoadZeros();
		damageCannon = 0f;
		minShootTimeCannon = 0f;
		maxShootTimeCannon = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)d1;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)d2;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.Interpolate(d1, d2, ratio);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, ratio);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, ratio);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, ratio);
		return tankBehaviourDefinititon3;
	}

	public override void ScaleDamageAndHP(float damageFactor, float hpFactor)
	{
		damageCannon *= damageFactor;
		base.ScaleDamageAndHP(damageFactor, hpFactor);
	}
}
