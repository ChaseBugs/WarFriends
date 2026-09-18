using System;
using UnityEngine;

[Serializable]
public class SoldierBehaviourDefinititon : BehaviourDefinititon
{
	public float probabilityOfRealShot = 1f;

	public int fireBatchSizeMin = 1;

	public int fireBatchSizeMax = 4;

	public float minShootTime = 1f;

	public float maxShootTime = 5f;

	public bool useSecondaryWeapon;

	public float switchToSecondaryProb;

	public bool canShootWhileRunning;

	public bool canShootWhileRunningDontStop;

	public bool canUseParachute;

	public float walkShotTimeMin = 1f;

	public float walkShotTimeMax = 5f;

	public float special;

	public override void LoadZeros()
	{
		health = 0f;
		probabilityOfRealShot = 0f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		minShootTime = 0f;
		maxShootTime = 0f;
		damage = 0f;
		special = 0f;
		walkShotTimeMin = 0f;
		walkShotTimeMax = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)d1;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)d2;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)d1.Copy();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, ratio);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, ratio);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, ratio);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, ratio);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, ratio);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, ratio);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, ratio);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, ratio);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, ratio);
		return soldierBehaviourDefinititon3;
	}

	public override void ScaleByPerk(Perk perk)
	{
		base.ScaleByPerk(perk);
		probabilityOfRealShot *= perk.accuracyCoef;
	}
}
