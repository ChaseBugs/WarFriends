using System;
using UnityEngine;

[Serializable]
public class CarBuggyBehaviourDefinititon : VehicleBehaviourDefinititon
{
	public float damageCannon;

	public float maxShootTimeCannon;

	public float minShootTimeCannon;

	public override void LoadZeros()
	{
		base.LoadZeros();
		maxShootTimeCannon = 0f;
		minShootTimeCannon = 0f;
		damageCannon = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)d1;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)d2;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.Interpolate(d1, d2, ratio);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, ratio);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, ratio);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, ratio);
		return carBuggyBehaviourDefinititon3;
	}

	public override void ScaleDamageAndHP(float damageFactor, float hpFactor)
	{
		damageCannon *= damageFactor;
		base.ScaleDamageAndHP(damageFactor, hpFactor);
	}
}
