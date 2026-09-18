using System;
using System.Collections.Specialized;
using UnityEngine;

public class BatchedWeapon : Core_BaseScript
{
	public Weapon weapon;

	public float fakeShotDispersion = 1f;

	private BitVector32 mFakeAndRealShots = new BitVector32(0);

	private byte mFireBatchSize;

	private PhotonView mPhotonView;

	private bool mShootLocaly;

	private int mShotCounter;

	private Ammo.ShotType mShotType;

	private Vector3 mTargetPosition;

	public bool shooting { get; private set; }

	public event Action ShootEnded;

	public event Action<Vector3> Shooted;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
	}

	public void ShootBatch(GameShootableEntity.ShotTarget target, Vector3 position, int batchSize, float realShotProb, Ammo.ShotType shotType)
	{
		mFireBatchSize = (byte)batchSize;
		mFakeAndRealShots = new BitVector32(0);
		for (int i = 0; i < mFireBatchSize; i++)
		{
			mFakeAndRealShots[1 << i] = UnityEngine.Random.value < realShotProb;
		}
		mShotCounter = 0;
		shooting = true;
		mTargetPosition = position;
		mShotType = shotType;
		mShootLocaly = true;
		PlayerController playerController = target.shootableEntity.owner as PlayerController;
		if (playerController != null && !playerController.photonView.isMine)
		{
			mShootLocaly = false;
		}
		mPhotonView.RPC("ShootBatchRPC", PhotonTargets.Others, mTargetPosition, mFakeAndRealShots.Data, !mShootLocaly, (byte)mShotType, mFireBatchSize);
	}

	[PunRPC]
	private void ShootBatchRPC(Vector3 position, int fakeAndRealShotsMask, bool shootLocaly, byte shotType, byte batchSize)
	{
		mShotCounter = 0;
		mFakeAndRealShots = new BitVector32(fakeAndRealShotsMask);
		mFireBatchSize = batchSize;
		shooting = true;
		mTargetPosition = position;
		mShootLocaly = shootLocaly;
		mShotType = (Ammo.ShotType)shotType;
	}

	protected void Update()
	{
		if (!shooting || !weapon.willShoot)
		{
			return;
		}
		if (mFakeAndRealShots[1 << mShotCounter])
		{
			Shoot(mTargetPosition, isFake: false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - mTargetPosition, Vector3.up).normalized * UnityEngine.Random.Range(0.3f, 0.5f) * fakeShotDispersion;
			if ((double)UnityEngine.Random.value < 0.5)
			{
				vector = -vector;
			}
			Shoot(mTargetPosition + vector + new Vector3(0f, 0.3f, 0f) * fakeShotDispersion, isFake: true);
		}
		mShotCounter++;
		if (mShotCounter >= mFireBatchSize)
		{
			mShotCounter = 0;
			shooting = false;
			if (this.ShootEnded != null)
			{
				this.ShootEnded();
			}
		}
	}

	private void Shoot(Vector3 position, bool isFake)
	{
		if (this.Shooted != null)
		{
			this.Shooted(position);
		}
		weapon.isFake = isFake;
		weapon.disableSync = true;
		weapon.shotType = mShotType;
		if (mShootLocaly)
		{
			weapon.Fire(position);
		}
		else
		{
			weapon.FireNetworkRPC(position, isFake, (byte)mShotType);
		}
	}

	public void Reset()
	{
		shooting = false;
	}
}
