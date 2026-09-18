using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourMinigunner : SoldierBehaviourGeneric<SoldierBehaviourDefinititonMinigunner>
{
	private static int mLastSpawnPoint;

	private Vector3 mStartTargetPosition;

	public override void PickTarget()
	{
		if (!TryPickDecoy())
		{
			if (controller.spawnedByCard)
			{
				PickPlayerOpponent(1f);
			}
			else
			{
				PickPlayerOpponent(upgradeSlots.shieldHitProbability);
			}
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
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		PlayerController pl = PlayerController.GetEnemyOf(controller.fraction);
		list.Sort(delegate(SpawnPoint a, SpawnPoint b)
		{
			float value = (pl.transform.position - a.transform.position).sqrMagnitude;
			if (mLastSpawnPoint % 2 == 0)
			{
				value = 0f;
			}
			float num = (pl.transform.position - b.transform.position).sqrMagnitude;
			if (mLastSpawnPoint % 2 != 0)
			{
				num = 0f;
			}
			return num.CompareTo(value);
		});
		mLastSpawnPoint++;
		if (list.Count > 1)
		{
			return list[0];
		}
		return list[0];
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		mWeapons[0].cadence = 0.17f;
		mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;
		BulletSetup bulletSetup = (BulletSetup)mWeapons[0].ammoSetup;
		bulletSetup.realShotTexture = "shotReal";
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
		if (controller.hasSpecial)
		{
			controller.shield.shieldStrength = base.soldierBehaviourDefinititon.special;
			controller.shield.shieldRechargeRate = (base.soldierBehaviourDefinititon as SoldierBehaviourDefinititonMinigunner).shieldRechargeRate;
			controller.shield.SetUpShield();
		}
	}
}
