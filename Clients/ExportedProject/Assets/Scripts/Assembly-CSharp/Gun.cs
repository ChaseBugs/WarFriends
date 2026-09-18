using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
	public vp_MuzzleFlash muzzleFlash;

	public Vector3 shotOffset = new Vector3(0f, 0.1f, 0f);

	public ParticleSystem ammoParticles;

	public bool fastBullet;

	public override bool willShoot => base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)cadence;

	protected override Ammo Shoot(Vector3 position, bool isNetworkCopy)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.Instantiate(bulletPrefab, spawnPoint.transform.position + shotOffset, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = ignoreTimeScale;
			ammo.isFake = isFake;
			ammo.type = shotType;
			ammo.weapon = this;
			ammo.isNetworkCopy = isNetworkCopy;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.fast = fastBullet;
			}
			ammo.Fire(spawnPoint.transform.position + shotOffset, position);
		}
		if ((bool)muzzleFlash)
		{
			muzzleFlash.Shoot(ignoreTimeScale);
		}
		if (ammoParticles != null)
		{
			ammoParticles.Play(withChildren: true);
		}
		base.Shoot(position, isNetworkCopy);
		return ammo;
	}

	private void AmmoHit(bool b)
	{
	}

	public void DestroyBullets()
	{
		List<PoolableObject> objectsMadeOfPrefab = Ammo.ammoPool.GetObjectsMadeOfPrefab(bulletPrefab);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.weapon == this)
				{
					bulletBase.DestroyPooled();
				}
			}
		}
	}

	public override float ComputeFlyTimeToTarget(Vector3 position)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(spawnPoint.transform.position, position);
			return num / bulletSetup.bulletSpeed + 0.1f;
		}
		return 0.1f;
	}
}
