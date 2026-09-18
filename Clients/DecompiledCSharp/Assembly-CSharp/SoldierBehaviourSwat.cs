using System;
using System.Collections.Generic;

public class SoldierBehaviourSwat : SoldierBehaviourRusher<SoldierBehaviourDefinititonSwat>
{
	public float thinTrailDistance = 2f;

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

	public override void UpdateVisual()
	{
		base.UpdateVisual();
		controller.agent.speed = ((!controller.hasSpecial) ? base.soldierBehaviourDefinititon.speed : (base.soldierBehaviourDefinititon.speed * (1f + base.soldierBehaviourDefinititon.special)));
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
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
		if (controller.spawnedByCard)
		{
			enemyPointType = EnemyPoint.EnemyPointType.Swat;
			return SpawningManager.instance.GetPoint(this, 0f);
		}
		return base.GetInitPoint();
	}

	public override bool AcceptsPoint(EnemyPoint point)
	{
		if (controller.spawnedByCard)
		{
			return base.AcceptsPoint(point) && (point.enemyPointType & EnemyPoint.EnemyPointType.Swat) == EnemyPoint.EnemyPointType.Swat;
		}
		return base.AcceptsPoint(point);
	}
}
