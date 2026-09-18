using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourAssaulter : SoldierBehaviourGeneric<SoldierBehaviourDefinititonBasicSoldier>
{
	private float mTimer;

	public override void ShootJustStarted()
	{
		if (mShotTarget != null)
		{
			currentWeapon.SetBullletSpeedCoef((mShotTarget == null || !(mShotTarget.shootableEntity.owner is PlayerController)) ? 3f : 1f);
			targetPosition = Singleton<AimingHelper>.instance.PredictPosition(currentWeapon, targetPosition, mShotTarget.shootableEntity.velocity, 0.3f);
		}
		base.ShootJustStarted();
	}

	public override bool AcceptSpawnPoint(SpawnPoint point)
	{
		if (point.spawnPointType == SpawnPoint.SpawnPointType.Parachute && base.mBehaviourDef.canUseParachute && controller.fraction == point.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(point);
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

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		BulletSetup bulletSetup = (BulletSetup)mWeapons[0].ammoSetup;
		bulletSetup.realShotTexture = "shotReal";
	}

	public override void PickTarget()
	{
		if (currentWeapon != null && !TryPickDecoy())
		{
			PickRandomOpponent(UnitType.AttackerRusher);
		}
	}

	public override void Restart()
	{
		base.Restart();
		mTimer = TimeManager.realTimeWithoutPauses + 2f + UnityEngine.Random.value;
	}

	protected override void Update()
	{
		base.Update();
		if (!(controller != null) || !(TimeManager.realTimeWithoutPauses > mTimer) || controller.fraction != PlayerController.currentPlayer.fraction || !Singleton<GameController>.instance.gameIsRunning || !controller.isInField || !controller.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(controller.transform.position, 1.5f, TagsAndLayers.destroyableObjectsMask);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.currentPlayer.fraction || enemyController == controller)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.ownerDestroyableObject != null) || !list.Contains(destroyableObjectpart.ownerDestroyableObject))
				{
					list.Add(destroyableObjectpart.ownerDestroyableObject);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(controller.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, isNetworkCopy: false);
		}
		mTimer = TimeManager.realTimeWithoutPauses + 2f;
	}
}
