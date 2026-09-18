using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourShotgunner : SoldierBehaviourRusher<SoldierBehaviourDefinititonBasicSoldier>
{
	public override void PickTarget()
	{
		if (controller.enemyAiState == EnemyController.EnemyAIState.Rusher)
		{
			PickRusherTarget();
			return;
		}
		mIsNetworCopy = false;
		GameShootableEntity gameShootableEntity = GameShootableEntity.PickOpponentInView(controller.fraction, controller.mTransform.position, controller.mTransform.forward, 45f, 5f);
		if (gameShootableEntity == null)
		{
			PickPlayerOpponent();
			return;
		}
		if (gameShootableEntity.owner is PlayerController)
		{
			PickPlayerOpponent(0f);
			return;
		}
		List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.All);
		int index = UnityEngine.Random.Range(0, shotTargets.Count);
		mShotTarget = shotTargets[index];
		targetPosition = mShotTarget.transform.position;
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
		PlayerController pl = PlayerController.GetEnemyOf(controller.fraction);
		list.Sort(delegate(SpawnPoint a, SpawnPoint b)
		{
			float sqrMagnitude = (pl.transform.position - a.transform.position).sqrMagnitude;
			return (pl.transform.position - b.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		});
		return list[0];
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		ShotGunBulletSetup shotGunBulletSetup = (ShotGunBulletSetup)mWeapons[0].ammoSetup;
		shotGunBulletSetup.maxDamage = base.soldierBehaviourDefinititon.damage;
		shotGunBulletSetup.minDamage = (float)base.soldierBehaviourDefinititon.damage * 0.1f;
		if (controller.hasSpecial)
		{
			base.soldierBehaviourDefinititon.canShootWhileRunningDontStop = true;
			base.soldierBehaviourDefinititon.walkShotTimeMax /= base.soldierBehaviourDefinititon.special;
			base.soldierBehaviourDefinititon.walkShotTimeMin /= base.soldierBehaviourDefinititon.special;
		}
		else
		{
			base.soldierBehaviourDefinititon.canShootWhileRunningDontStop = false;
		}
	}
}
