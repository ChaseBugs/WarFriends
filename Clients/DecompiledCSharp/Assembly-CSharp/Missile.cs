using System;
using UnityEngine;

public class Missile : PhysicalAmmo
{
	private const float mCheckCollisionDistance = 0.5f;

	private Vector3 mDirection;

	private Transform mTransform;

	private Vector3 mLastPosition;

	private bool mExploded;

	public GameObject projectileModel;

	public GameObject smallParticles;

	public GameObject bigParticles;

	public GameObject burningSmokeParticles;

	public TrailRenderer trail;

	private Ray mDirRay;

	private RaycastHit mHitPom;

	private MissileSetup mSetup;

	public ParticleSystem particles;

	private bool mCheckColision;

	private Vector3 mFrom;

	private float mNrofRotations;

	private float mMiddleRot;

	private float mRotateMagnitude;

	private static int mC;

	private Vector3 mEnd;

	private Vector3 mStart;

	private Vector3 rotateVector;

	private bool mAnimating;

	private float progress;

	private float mAnimtime;

	private Vector3 mLastUpPos;

	private GameShootableEntity mTarget;

	protected override void Awake()
	{
		base.Awake();
		mTransform = base.transform;
	}

	public override void Fire(Vector3 from, Vector3 to)
	{
		mFrom = from;
		mAnimating = false;
		if (!isNetworkCopy && mSetup.curvedTrajectory)
		{
			SetUpTrajectory(from, to);
		}
		mDirection = to - from;
		Vector3 normalized = (to - from).normalized;
		if (Vector3.Distance(from, to) > 50f)
		{
			to = from + normalized * 50f;
			mDirection = to - from;
		}
		AnimateShot(from, to);
		mLastPosition = from;
		mExploded = false;
		mCheckColision = false;
	}

	private void SetUpTrajectory(Vector3 from, Vector3 to)
	{
		mDirection = to - from;
		mMiddleRot = UnityEngine.Random.Range(60f, 110f);
		if (mC++ % 2 == 0)
		{
			mMiddleRot *= -1f;
		}
		mNrofRotations = UnityEngine.Random.Range(mSetup.minMaxRotations.x, mSetup.minMaxRotations.y) * Mathf.Pow(mDirection.magnitude / 10f, 2f);
		mNrofRotations = Mathf.Clamp(mNrofRotations, 0f, mSetup.minMaxRotations.y * 1.2f);
		mRotateMagnitude = mSetup.baseRotationMagnitude * Mathf.Pow(mDirection.magnitude / 10f, 2f);
		mRotateMagnitude = Mathf.Clamp(mRotateMagnitude, 0f, 0.6f);
		mSetup.rotationProfile.postWrapMode = WrapMode.Loop;
		mSetup.rotationProfile.preWrapMode = WrapMode.Loop;
		photonView.RPC("SyncTrajectoryRPC", PhotonTargets.Others, mMiddleRot, mNrofRotations, mRotateMagnitude);
	}

	[PunRPC]
	protected void SyncTrajectoryRPC(float middleRot, float nrOfRotations, float rotatemagnitude)
	{
		mMiddleRot = middleRot;
		mNrofRotations = nrOfRotations;
		mRotateMagnitude = rotatemagnitude;
	}

	public void AnimateShot(Vector3 from, Vector3 to)
	{
		projectileModel.SetActive(value: true);
		switch (mSetup.missileType)
		{
		case MissileSetup.MissileType.RpgBasic:
			smallParticles.SetActive(value: false);
			bigParticles.SetActive(value: true);
			projectileModel.transform.localScale = new Vector3(1f, 1f, 1.4f);
			trail.startWidth = 0.2f;
			trail.endWidth = 0.2f;
			trail.time = 0.2f;
			burningSmokeParticles.SetActive(value: false);
			break;
		case MissileSetup.MissileType.Tank:
			smallParticles.SetActive(value: false);
			bigParticles.SetActive(value: false);
			projectileModel.transform.localScale = new Vector3(1f, 1f, 1.4f);
			trail.startWidth = 0.2f;
			trail.endWidth = 0.2f;
			trail.time = 0.2f;
			burningSmokeParticles.SetActive(value: false);
			break;
		case MissileSetup.MissileType.Small:
			smallParticles.SetActive(value: true);
			bigParticles.SetActive(value: false);
			projectileModel.transform.localScale = new Vector3(1f, 1f, 1.4f) * 0.5f;
			trail.startWidth = 0.08f;
			trail.endWidth = 0.08f;
			trail.time = 0.08f;
			burningSmokeParticles.SetActive(value: false);
			break;
		case MissileSetup.MissileType.RpgBold:
			smallParticles.SetActive(value: false);
			bigParticles.SetActive(value: true);
			projectileModel.transform.localScale = new Vector3(1f, 1f, 1.4f);
			trail.startWidth = 0.2f;
			trail.endWidth = 0.2f;
			trail.time = 0.2f;
			burningSmokeParticles.SetActive(value: true);
			break;
		}
		mDirection = to - from;
		base.gameObject.transform.rotation = Quaternion.LookRotation(mDirection);
		mStart = from;
		mEnd = to;
		mAnimating = true;
		mAnimtime = mDirection.magnitude / mSetup.speed;
		progress = 0f - mSetup.stopTime / mAnimtime;
		mDirection.Normalize();
		mExploded = false;
		mLastUpPos = from;
		particles.Clear();
		particles.Play();
	}

	public void SetTarget(GameShootableEntity e)
	{
		mTarget = e;
	}

	protected void Update()
	{
		if (mTarget != null && mTarget.targets.Count > 0)
		{
			mEnd = mTarget.targets[0].transform.position;
		}
		if (mAnimating)
		{
			progress += ((!ignoreTimeScale) ? Time.deltaTime : TimeManager.deltaTimeWithoutPauses) / mAnimtime;
			float num = Mathf.Clamp(progress, 0f, float.MaxValue);
			Vector3 vector = mStart + (mEnd - mStart) * num;
			Vector3 vector2 = ((!mSetup.curvedTrajectory) ? Vector3.zero : new Vector3(0f, Mathf.Sin(progress * (float)Math.PI) * 1.6f * mRotateMagnitude, 0f));
			if (mSetup.curvedTrajectory)
			{
				float angle = mMiddleRot + 360f * mNrofRotations * (progress - 0.5f);
				Vector3 vector3 = vector + vector2;
				Vector3 axis = vector3 - mLastUpPos;
				mLastUpPos = vector3;
				Vector3 vector4 = Quaternion.AngleAxis(angle, axis) * Vector3.up * mRotateMagnitude * mSetup.rotationProfile.Evaluate(progress);
				if (progress > 1f)
				{
					vector4.y = 0f;
					vector2 *= 2f;
				}
				vector2 += vector4;
			}
			mTransform.position = vector + vector2;
			if (progress > ((!mSetup.curvedTrajectory) ? 3f : 1.5f))
			{
				TryKill(base.transform.position);
				mAnimating = false;
			}
		}
		if (mCheckColision)
		{
			if (!mExploded)
			{
				CheckHit();
			}
		}
		else if (Vector3.Distance(mFrom, mTransform.position) > 0.5f)
		{
			mCheckColision = true;
		}
		mLastPosition = mTransform.position;
	}

	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
		MissileSetup missileSetup = setup as MissileSetup;
		if (missileSetup != null)
		{
			mSetup = missileSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	private bool CheckHit()
	{
		Vector3 direction = mTransform.position - mLastPosition;
		float magnitude = direction.magnitude;
		float maxDistance = magnitude + 2f * Time.deltaTime;
		mDirRay = new Ray(mLastPosition, direction);
		if (magnitude > 0f && Physics.Raycast(mDirRay, out mHitPom, maxDistance, Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask)))
		{
			TryKill(mHitPom.point);
			return true;
		}
		return false;
	}

	private void TryKill(Vector3 impactPos)
	{
		if (!mExploded)
		{
			Explosion.ExplosionType explosionType = mSetup.missileType switch
			{
				MissileSetup.MissileType.Small => Explosion.ExplosionType.Small, 
				MissileSetup.MissileType.RpgBasic => Explosion.ExplosionType.Medium, 
				MissileSetup.MissileType.RpgBold => Explosion.ExplosionType.Medium, 
				_ => Explosion.ExplosionType.Big, 
			};
			MissileSetup missileSetup = mSetup;
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = impactPos;
			explosionInfo.explodeDamage = missileSetup.explodeDamageAmount;
			explosionInfo.damageAmount = missileSetup.damageAmount;
			explosionInfo.owner = owner;
			explosionInfo.weapon = weapon;
			explosionInfo.deadRadius = missileSetup.deadRadius;
			explosionInfo.hurtRadius = missileSetup.hurtRadius;
			explosionInfo.exposionCoef = missileSetup.exposionCoef;
			explosionInfo.additionalUpForce = missileSetup.additionalUpForce;
			explosionInfo.isNetworkCopy = isNetworkCopy;
			explosionInfo.playerBehindShieldRatio = missileSetup.playerBehindShieldRatio;
			explosionInfo.type = explosionType;
			explosionInfo.isFake = isFake;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.MissileExplode(i);
			mExploded = true;
			particles.Stop();
			projectileModel.SetActive(value: false);
			DestroyPooled((!isNetworkCopy) ? 1.3f : 0.2f);
			mAnimating = false;
		}
	}

	public void Pause()
	{
		mAnimating = false;
	}

	public void Resume()
	{
		mAnimating = true;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		mAnimating = false;
		StopAllCoroutines();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		StopAllCoroutines();
		mTarget = null;
		projectileModel.gameObject.SetActive(value: false);
		mAnimating = false;
	}
}
