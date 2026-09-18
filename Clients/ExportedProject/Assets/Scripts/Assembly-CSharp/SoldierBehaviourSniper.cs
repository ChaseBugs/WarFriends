using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourSniper : SoldierBehaviourGeneric<SoldierBehaviourDefinititonSniper>
{
	public override EnemyPoint GetNewEnemyPoint(EnemyPoint currentEnemyPoint)
	{
		List<EnemyPoint> enemyPoints = SpawningManager.instance.enemyPoints;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(controller.fraction).transform;
		foreach (EnemyPoint item in enemyPoints)
		{
			if (Vector3.Distance(item.position, transform.position) > base.mBehaviourDef.minSniperDistance && item.isFree && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(0, list.Count)];
		}
		return null;
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		if (controller.hasSpecial)
		{
			mWeapons[0].ammoSetup.criticalProbability = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			mWeapons[0].ammoSetup.criticalProbability = 0f;
		}
		mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		BulletSetup bulletSetup = (BulletSetup)mWeapons[0].ammoSetup;
		bulletSetup.realShotTexture = "shotSniper";
	}

	public override EnemyPoint GetInitPoint()
	{
		return SpawningManager.instance.GetPoint(this, base.mBehaviourDef.minSniperDistance, PlayerController.GetEnemyOf(controller.fraction).transform);
	}

	public override void PickTarget()
	{
		if (!TryPickDecoy())
		{
			PickPlayerOpponent(upgradeSlots.shieldHitProbability);
		}
	}
}
