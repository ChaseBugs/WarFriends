using System;
using UnityEngine;

[Serializable]
public class VehicleBehaviourDefinititon : BehaviourDefinititon
{
	public float minShootTime;

	public float maxShootTime;

	public float probabilityOfRealShot = 1f;

	public int fireBatchSizeMin;

	public int fireBatchSizeMax;

	public float special;

	public override void LoadZeros()
	{
		health = 0f;
		damage = 0f;
		minShootTime = 0f;
		maxShootTime = 0f;
		probabilityOfRealShot = 0f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		special = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)d1;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)d2;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)d1.Copy();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, ratio);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, ratio);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, ratio);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, ratio);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, ratio);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, ratio);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, ratio);
		return vehicleBehaviourDefinititon3;
	}
}
