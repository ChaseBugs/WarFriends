using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourRusher<T> : SoldierBehaviourGeneric<T> where T : SoldierBehaviourDefinititon
{
	public override bool CanBeSpawned(Fractions f, int numberOfEnemies)
	{
		int num = 0;
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(f);
		MapDefinition.DefendPosition currentPlayerPoint = randomEnemy.currentPlayerPoint;
		if (currentPlayerPoint != null)
		{
			List<EnemyPointRusher> rusherPoints = currentPlayerPoint.point.rusherPoints;
			foreach (EnemyPointRusher item in rusherPoints)
			{
				if (item.isFree)
				{
					num++;
					if (num >= numberOfEnemies)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public override EnemyPoint GetInitPoint()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(controller.fraction);
		List<EnemyPointRusher> rusherPoints = randomEnemy.currentPlayerPoint.point.rusherPoints;
		if (controller.rusherCounts < 4)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = float.MaxValue;
			foreach (EnemyPointRusher item in rusherPoints)
			{
				if (!item.isFree)
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.position);
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.index > 1 || (enemyPointRusher.index <= 1 && enemyPointRusher2.index <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		enemyPointType = EnemyPoint.EnemyPointType.RusherSpare;
		return SpawningManager.instance.GetPoint(this, 0f);
	}

	public override void PickTarget()
	{
		if (controller.enemyAiState == EnemyController.EnemyAIState.Rusher)
		{
			PickRusherTarget();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(controller.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
		mShotTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.ShotTargetType.Body, controller.mTransform.position);
		targetPosition = mShotTarget.transform.position;
	}

	protected void PickRusherTarget()
	{
		mIsNetworCopy = false;
		EnemyPointRusher enemyPointRusher = controller.enemyPoint as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.playerPoint.shield.player != null)
		{
			PlayerController player = enemyPointRusher.playerPoint.shield.player;
			GameShootableEntity gameShootableEntity = player.gameShootableEntity;
			mShotTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.ShotTargetType.Moving, controller.mTransform.position);
			targetPosition = mShotTarget.transform.position;
		}
	}
}
