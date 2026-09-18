using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourParachuter : SoldierBehaviourRusher<SoldierBehaviourDefinititonParachuter>
{
	public float thinTrailDistance = 2f;

	public override bool AcceptSpawnPoint(SpawnPoint point)
	{
		if (point.spawnPointType == SpawnPoint.SpawnPointType.Parachute && base.mBehaviourDef.canUseParachute && controller.fraction == point.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(point);
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
		if (controller.hasSpecial)
		{
			controller.SetUpKevlar(base.soldierBehaviourDefinititon.special);
		}
	}

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> spawns)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint spawn in spawns)
		{
			if (AcceptSpawnPoint(spawn))
			{
				list.Add(spawn);
				if (spawn.spawnPointType == SpawnPoint.SpawnPointType.Parachute)
				{
					return spawn;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected override void Shoot(Vector3 position, bool isFake)
	{
		base.Shoot(position, isFake);
		mWeapons[0].cadence = ((controller.enemyAiState != EnemyController.EnemyAIState.Parachute) ? 0.25f : 0.5f);
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		mWeapons[0].cadence = 0.25f;
		mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		BulletSetup bulletSetup = (BulletSetup)mWeapons[0].ammoSetup;
		bulletSetup.realShotTexture = "shotReal";
	}

	protected override void OnBeforeFire()
	{
		base.OnBeforeFire();
		BulletSetup bulletSetup = currentWeapon.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(controller.fraction);
			float num = controller.transform.position.PlanarDistance(enemyOf.position);
			bulletSetup.useThinTrail = num < thinTrailDistance;
		}
	}

	public override EnemyPoint GetInitPoint()
	{
		if (!controller.spawnedByCard)
		{
			return base.GetInitPoint();
		}
		return SpawningManager.instance.GetPoint(this, 0f);
	}

	public override void PickTarget()
	{
		if (controller.enemyAiState == EnemyController.EnemyAIState.Parachute)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(controller.fraction);
			GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
			GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.ShotTargetType.Shield, controller.mTransform.position);
			targetPosition = nearestTarget.transform.position;
			mShotTarget = nearestTarget;
		}
		else
		{
			base.PickTarget();
		}
	}

	public override bool AcceptsPoint(EnemyPoint point)
	{
		if (controller.spawnedByCard)
		{
			return controller.fraction == point.fraction && ((point.enemyPointType & EnemyPoint.EnemyPointType.Corner) == EnemyPoint.EnemyPointType.Corner || (point.enemyPointType & EnemyPoint.EnemyPointType.Hiding) == EnemyPoint.EnemyPointType.Hiding);
		}
		return controller.fraction == point.fraction && (point.enemyPointType & EnemyPoint.EnemyPointType.Rusher) == EnemyPoint.EnemyPointType.Rusher;
	}
}
