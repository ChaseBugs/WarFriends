using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourFlamethrower : SoldierBehaviourRusher<SoldierBehaviourDefinititonFlamethrower>
{
	public override void OnDeath(DestroyableObject.DamageInfo damageInfo)
	{
		damageInfo.type = DestroyableObject.DamageType.Explosion;
		base.OnDeath(damageInfo);
		if (controller.hasSpecial)
		{
			Singleton<HitParticleSystem>.instance.PlayParticle(controller.transform.position + Vector3.up, Vector3.up, 3);
		}
		if (controller.photonView.isMine)
		{
			Singleton<ExplosionManager>.instance.MissileExplode(controller.transform.position, base.soldierBehaviourDefinititon.damage, currentWeapon.owner, currentWeapon, Explosion.ExplosionType.Big);
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
			float sqrMagnitude = (pl.transform.position - a.transform.position).sqrMagnitude;
			return (pl.transform.position - b.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		});
		return list[0];
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		FlameAmmoSetup flameAmmoSetup = (FlameAmmoSetup)mWeapons[0].ammoSetup;
		flameAmmoSetup.maxDamage = (float)base.soldierBehaviourDefinititon.damage / 6f;
		flameAmmoSetup.minDamage = (float)base.soldierBehaviourDefinititon.damage * 0.1f / 6f;
		base.soldierBehaviourDefinititon.canShootWhileRunningDontStop = false;
	}
}
