using UnityEngine;

public class Grenade : PhysicalAmmoWeapon
{
	private MeshRenderer mMeshRenderer;

	public GrenadeAmmoBase.GrenadeAmmoType grenadeTpe;

	public bool changeMesh;

	private Mesh mMesh;

	private void OnEnable()
	{
		if (changeMesh)
		{
			if (mMeshRenderer == null)
			{
				mMeshRenderer = GetComponentInChildren<MeshRenderer>();
			}
			if (mMeshRenderer != null)
			{
				mMesh = mMeshRenderer.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected override Ammo Shoot(Vector3 position, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			mLastAmmo = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.Instantiate(bulletPrefab, spawnPoint.transform.position + shootOffset, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)mLastAmmo;
			if (mLastAmmo != null)
			{
				PhotonNetwork.ChangeOwner(mLastAmmo.photonView, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(grenadeTpe, mMeshRenderer, mMesh);
				mLastAmmo.LoadAmmoSetup(base.ammoSetup);
				mLastAmmo.ignoreTimeScale = ignoreTimeScale;
				mLastAmmo.isFake = isFake;
				mLastAmmo.type = shotType;
				mLastAmmo.weapon = this;
				mLastAmmo.isNetworkCopy = false;
				mLastAmmo.Fire(spawnPoint.transform.position + shootOffset, position);
				int num = mLastAmmo.indexInObjectPool;
				if (mPhotonView != null)
				{
					mPhotonView.RPC("ShootCopyRPC", PhotonTargets.Others, num, spawnPoint.transform.position + shootOffset, position, (byte)PhotonNetwork.player.ID, isFake);
				}
				BaseShoot(position, isNetworkCopy);
				return mLastAmmo;
			}
		}
		return null;
	}

	[PunRPC]
	public override void ShootCopyRPC(int index, Vector3 from, Vector3 to, byte ID, bool isFakeShot)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.ReInstantiate(bulletPrefab, index, from, Quaternion.identity);
		isFake = isFakeShot;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.photonView, ID);
			grenadeAmmoBase.ChangeGrenade(grenadeTpe, mMeshRenderer, mMesh);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.isNetworkCopy = true;
			grenadeAmmoBase.weapon = this;
			grenadeAmmoBase.isFake = isFakeShot;
			grenadeAmmoBase.Fire(from, to);
			BaseShoot(to, isNetworkCopy: true);
		}
		else
		{
			Debug.LogError("Physical ammo is null !!!");
		}
	}
}
