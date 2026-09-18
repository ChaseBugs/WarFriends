using UnityEngine;

public class PhysicalAmmoWeapon : Weapon
{
	public Vector3 shootOffset;

	protected PhysicalAmmo mLastAmmo;

	public override bool willShoot => base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)cadence;

	public override float nextShootProgress
	{
		get
		{
			if ((float)cadence == 0f)
			{
				return 1f;
			}
			return Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)cadence);
		}
	}

	protected override Ammo Shoot(Vector3 position, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			Vector3 vector = spawnPoint.transform.position + shootOffset;
			mLastAmmo = (PhysicalAmmo)ObjectPoolDatabase.networkPool.Instantiate(bulletPrefab, vector, Quaternion.identity);
			if (mLastAmmo != null)
			{
				PhotonNetwork.ChangeOwner(mLastAmmo.photonView, PhotonNetwork.player.ID);
				mLastAmmo.LoadAmmoSetup(base.ammoSetup);
				mLastAmmo.ignoreTimeScale = ignoreTimeScale;
				mLastAmmo.isFake = isFake;
				mLastAmmo.type = shotType;
				mLastAmmo.weapon = this;
				mLastAmmo.isNetworkCopy = false;
				int num = mLastAmmo.indexInObjectPool;
				if (mPhotonView != null)
				{
					mPhotonView.RPC("ShootCopyRPC", PhotonTargets.Others, num, vector, position, (byte)PhotonNetwork.player.ID, isFake);
				}
				mLastAmmo.Fire(vector, position);
				base.Shoot(position, isNetworkCopy: false);
				return mLastAmmo;
			}
		}
		return null;
	}

	public bool BaseShoot(Vector3 pos, bool isNetworkCopy)
	{
		return base.Shoot(pos, isNetworkCopy);
	}

	[PunRPC]
	public virtual void ShootCopyRPC(int index, Vector3 from, Vector3 to, byte playerID, bool isFakeShot)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.networkPool.ReInstantiate(bulletPrefab, index, from, Quaternion.identity);
		isFake = isFakeShot;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.photonView, playerID);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.isNetworkCopy = true;
			physicalAmmo.weapon = this;
			physicalAmmo.isFake = isFakeShot;
			physicalAmmo.Fire(from, to);
			BaseShoot(to, isNetworkCopy: true);
		}
		else
		{
			Debug.LogError("Physical ammo is null !!!");
		}
	}

	[PunRPC]
	public override void FireNetworkRPC(Vector3 to, bool fake, byte type)
	{
	}

	protected override void ShotNetworkCopy(Vector3 to)
	{
	}
}
