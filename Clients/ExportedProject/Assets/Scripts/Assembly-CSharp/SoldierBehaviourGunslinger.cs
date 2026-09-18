using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourGunslinger : SoldierBehaviourGeneric<SoldierBehaviourDefinititonGunslinger>
{
	public override bool StartShooting()
	{
		bool result = base.StartShooting();
		mFireBatchSize = 1;
		return result;
	}

	public override void ShootJustStarted()
	{
		if (mShotTarget != null)
		{
			currentWeapon.SetBullletSpeedCoef((mShotTarget == null || !(mShotTarget.shootableEntity.owner is PlayerController)) ? 1f : 0.5f);
			targetPosition = Singleton<AimingHelper>.instance.PredictPosition(currentWeapon, mShotTarget.transform.position, mShotTarget.shootableEntity.velocity, 0f);
		}
		base.ShootJustStarted();
	}

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> spawns)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint spawn in spawns)
		{
			if (AcceptSpawnPoint(spawn))
			{
				list.Add(spawn);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		mWeapons[0].cadence = 0.18f;
		Gun gun = mWeapons[0] as Gun;
		if (gun != null)
		{
			gun.shotOffset = Vector3.up * 0.05f;
		}
		BulletSetup bulletSetup = (BulletSetup)mWeapons[0].ammoSetup;
		bulletSetup.realShotTexture = "shotSniper";
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
		controller.SnapColt(toCover: true);
	}

	public override void PickTarget()
	{
		if (currentWeapon != null && !TryPickDecoy())
		{
			PickRandomOpponent(UnitType.AttackerRusher, GameShootableEntity.ShotTargetType.Head);
		}
	}
}
