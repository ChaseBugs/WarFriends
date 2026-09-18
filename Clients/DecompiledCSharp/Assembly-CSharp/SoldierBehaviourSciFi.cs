using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourSciFi : SoldierBehaviourGeneric<SoldierBehaviourDefinititonSciFi>
{
	private int mCounter;

	private Vector3 mLastShotPos;

	private int mDoubleShot;

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

	public override void ShootJustStarted()
	{
		base.ShootJustStarted();
	}

	private Vector3 GetNextShieldPosition()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(controller.fraction);
		MapDefinition.DefendPosition currentPlayerPoint = enemyOf.currentPlayerPoint;
		List<MapDefinition.DefendPosition> playersPositions = Singleton<MapManager>.instance.currentMapDef.playersPositions;
		bool flag = UnityEngine.Random.value > 0.5f;
		int num = currentPlayerPoint.index + (flag ? 1 : (-1));
		if (num >= 0 && num < playersPositions.Count && playersPositions[num].fraction == enemyOf.fraction)
		{
			return playersPositions[num].point.transform.position;
		}
		num = currentPlayerPoint.index + ((!flag) ? 1 : (-1));
		if (num >= 0 && num < playersPositions.Count && playersPositions[num].fraction == enemyOf.fraction)
		{
			return playersPositions[num].point.transform.position;
		}
		return enemyOf.transform.position;
	}

	public override void Shooting()
	{
		bool? flag = null;
		if (currentWeapon.willShoot)
		{
			mCounter++;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && controller.hasSpecial && mCounter > mDoubleShot + 1;
			if (flag.Value)
			{
				mFakeAndRealShots[1 << mShotCounter] = true;
				mFireBatchSize++;
				mDoubleShot = mCounter;
			}
		}
		base.Shooting();
		if (controller.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				targetPosition = GetNextShieldPosition();
				mWeapons[0].cadence = 0.1f;
			}
			else
			{
				targetPosition = mLastShotPos;
				mWeapons[0].cadence = 1.5f;
			}
		}
	}

	public override EnemyPoint GetInitPoint()
	{
		return SpawningManager.instance.GetNearestFreePoint(this, Singleton<MapManager>.instance.currentMapDef.floorTransform);
	}

	public override EnemyPoint GetNewEnemyPoint(EnemyPoint currentEnemyPoint)
	{
		List<EnemyPoint> freeEnemyPoints = SpawningManager.instance.GetFreeEnemyPoints(currentEnemyPoint, this);
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in freeEnemyPoints)
		{
			if ((double)Vector3.Distance(item.position, controller.transform.position) > 1.8)
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return SpawningManager.instance.GetNextFreeEnemyPoint(currentEnemyPoint, this);
	}

	public override void StartEnemyBehaviour()
	{
		controller.StartEnemyBehaviour(EnemyController.EnemyAIState.Fly);
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)mWeapons[0].ammoSetup;
		grenadeAmmoSetup.damageAmount = base.mBehaviourDef.grenadeMinDamage;
		grenadeAmmoSetup.explodeDamageAmount = base.mBehaviourDef.grenadeExplodeDamage;
		grenadeAmmoSetup.playerBehindShieldRatio = upgradeSlots.playerBehindShieldDamageRatio;
		mWeapons[0].cadence = 1.5f;
		controller.agent.speed = 0.5f;
	}

	public override void PickTarget()
	{
		if (!TryPickDecoy())
		{
			PickPlayerOpponent(upgradeSlots.shieldHitProbability);
		}
		mLastShotPos = targetPosition;
	}
}
