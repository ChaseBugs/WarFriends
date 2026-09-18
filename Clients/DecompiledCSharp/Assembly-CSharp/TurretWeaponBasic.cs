using System;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeaponBasic : Core_BaseScript
{
	public float aimTime = 1f;

	public int batchSizeMax = 5;

	public int batchSizeMin = 1;

	public Vector3 aimOffset;

	public float playerShieldProbability = 0.5f;

	public BatchedWeapon batchedWeapon;

	public Transform jointVertical;

	public Transform jontHorizontal;

	private bool mIsShooting;

	protected float mNextShotTime;

	protected PhotonView mPhotonView;

	protected GameShootableEntity mTarget;

	protected Transform mTransform;

	public float maxShootTime = 5f;

	public float maxShotRotation = 30f;

	public float minShootTime = 1f;

	protected AIObject mOwner;

	private Quaternion mHorizontalAim;

	private Quaternion mVerticalAim;

	[BitMask(typeof(GameShootableEntity.Target))]
	public GameShootableEntity.Target primTarget = GameShootableEntity.Target.Player;

	public Transform turretParent;

	public bool useUnitTarget = true;

	public bool primaryTargetOnly;

	public bool needToSeePrimaryTarget;

	public bool needToSeeSecondaryTarget;

	public Transform seeEnemyTransform;

	public bool predictPosition = true;

	public LevelBehaviour.UnitType primaryTarget;

	public LevelBehaviour.UnitType[] secondaryTargets;

	public float realShotProbability = 1f;

	public bool keepAimed;

	private bool mAim;

	protected override void Awake()
	{
		base.Awake();
		mTransform = base.transform;
		mPhotonView = GetComponent<PhotonView>();
		mOwner = NGUITools.FindInParents<AIObject>(base.gameObject);
		batchedWeapon.weapon.owner = mOwner;
		batchedWeapon.ShootEnded += ShootEnd;
		if (seeEnemyTransform == null)
		{
			seeEnemyTransform = batchedWeapon.weapon.spawnPoint;
		}
	}

	private void ShootEnd()
	{
		mNextShotTime = Time.time + UnityEngine.Random.Range(minShootTime, maxShootTime);
	}

	public virtual void Reset()
	{
		mAim = false;
		batchedWeapon.Reset();
		mNextShotTime = Time.time + UnityEngine.Random.Range(minShootTime, maxShootTime);
	}

	public void ResetAiming()
	{
		if (jointVertical != null)
		{
			TweenRotation.Begin(jointVertical.gameObject, 0f, Quaternion.identity);
		}
		mHorizontalAim = Quaternion.identity;
		mVerticalAim = Quaternion.identity;
		TweenRotation.Begin(jontHorizontal.gameObject, 0f, Quaternion.identity);
		mAim = false;
	}

	protected void Update()
	{
		if (Singleton<GameController>.instance.gameIsRunning && mPhotonView.isMine && Time.time > mNextShotTime && !batchedWeapon.shooting)
		{
			mNextShotTime = Time.time + maxShootTime * 2f;
			PickTarget();
		}
	}

	private void LateUpdate()
	{
		if (keepAimed && mAim)
		{
			jontHorizontal.transform.rotation = mHorizontalAim;
			Quaternion localRotation = Quaternion.Euler(0f, (Quaternion.Inverse(jontHorizontal.transform.parent.rotation) * mHorizontalAim).eulerAngles.y, 0f);
			jontHorizontal.transform.localRotation = localRotation;
			if (jointVertical != null)
			{
				jointVertical.transform.rotation = mVerticalAim;
			}
		}
	}

	private GameShootableEntity PickRandom(List<GameShootableEntity> targets, bool needToBeVisible)
	{
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		if (needToBeVisible)
		{
			foreach (GameShootableEntity target in targets)
			{
				List<GameShootableEntity.ShotTarget> shotTargets = target.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn);
				GameShootableEntity.ShotTarget shotTarget = shotTargets[0];
				if (AIObject.CanSeeTargetStatic(seeEnemyTransform.position, shotTarget.transform.position, 0.05f) && ComputeAngle(shotTarget.transform.position, out var _) < maxShotRotation)
				{
					list.Add(target);
				}
			}
		}
		else
		{
			list = targets;
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return null;
	}

	public virtual void PickTarget()
	{
		mTarget = null;
		if (!primaryTargetOnly)
		{
			List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(mOwner.fraction, new Type[1] { typeof(Decoy) });
			if (opponents.Count > 0)
			{
				mTarget = opponents[UnityEngine.Random.Range(0, opponents.Count)];
			}
		}
		if (mTarget == null)
		{
			if (useUnitTarget)
			{
				List<GameShootableEntity> opponents2 = GameShootableEntity.GetOpponents(mOwner.fraction, primaryTarget);
				mTarget = PickRandom(opponents2, needToSeePrimaryTarget);
			}
			else
			{
				List<GameShootableEntity> opponents3 = GameShootableEntity.GetOpponents(mOwner.fraction, primTarget);
				mTarget = PickRandom(opponents3, needToSeePrimaryTarget);
			}
		}
		if (!primaryTargetOnly)
		{
			if (mTarget == null)
			{
				List<GameShootableEntity> opponents4 = GameShootableEntity.GetOpponents(mOwner.fraction, secondaryTargets);
				mTarget = PickRandom(opponents4, needToSeeSecondaryTarget);
			}
			if (mTarget == null)
			{
				List<GameShootableEntity> opponents5 = GameShootableEntity.GetOpponents(mOwner.fraction);
				mTarget = PickRandom(opponents5, needToSeeSecondaryTarget);
			}
		}
		if (mTarget != null)
		{
			batchedWeapon.weapon.SetBullletSpeedCoef((!(mTarget.owner is PlayerController) || !useUnitTarget) ? 1f : 0.5f);
			mPhotonView.RPC("AimNetwork", PhotonTargets.Others, mTarget.transform.position + aimOffset);
			if (!Aim(mTarget.transform.position + aimOffset, OnAimed))
			{
				mNextShotTime = Time.time + UnityEngine.Random.Range(minShootTime, maxShootTime);
			}
		}
		else
		{
			mNextShotTime = Time.time + UnityEngine.Random.Range(minShootTime, maxShootTime);
		}
	}

	private float ComputeAngle(Vector3 position, out Vector3 axis)
	{
		Vector3 toDirection = position - base.transform.position;
		if (jointVertical == null)
		{
			toDirection.y = 0f;
		}
		Quaternion.FromToRotation(turretParent.forward, toDirection).ToAngleAxis(out var angle, out axis);
		return angle;
	}

	protected bool Aim(Vector3 position, UITweener.OnFinished finishDelegate)
	{
		Vector3 vector = position - base.transform.position;
		Vector3 axis;
		float num = ComputeAngle(position, out axis);
		Quaternion rot = Quaternion.LookRotation(vector, Vector3.up);
		if (Vector3.Angle(jontHorizontal.forward, vector) < 2.5f && Mathf.Abs(num) < maxShotRotation)
		{
			if (finishDelegate != null)
			{
				finishDelegate(null);
			}
			return true;
		}
		bool flag = false;
		if (num > maxShotRotation && num < 360f - maxShotRotation)
		{
			num = ((!(num < 180f)) ? (360f - maxShotRotation) : maxShotRotation);
			flag = true;
		}
		Quaternion quaternion = Quaternion.AngleAxis(num, axis);
		Quaternion quaternion2 = quaternion;
		quaternion2.eulerAngles = new Vector3(0f, quaternion.eulerAngles.y, 0f);
		Quaternion rot2 = jontHorizontal.transform.parent.rotation * quaternion2;
		float num2 = Quaternion.Angle(jontHorizontal.transform.localRotation, quaternion2);
		num2 = ((!(num2 > 180f)) ? num2 : (360f - num2));
		TweenRotation tweenRotation = TweenRotation.Begin(jontHorizontal.gameObject, Mathf.Max(aimTime * Mathf.Abs(num2 / 360f), 0.1f), rot2, useAbsolute: true);
		mHorizontalAim = rot2;
		if (jointVertical != null)
		{
			TweenRotation.Begin(jointVertical.gameObject, aimTime * Mathf.Abs(num2 / 360f), rot, useAbsolute: true);
			mVerticalAim = rot;
		}
		mAim = false;
		if (flag)
		{
			tweenRotation.onFinished = delegate
			{
				mAim = true;
			};
		}
		else
		{
			tweenRotation.onFinished = delegate(UITweener u)
			{
				if (finishDelegate != null)
				{
					finishDelegate(u);
				}
				mAim = true;
			};
		}
		return !flag;
	}

	[PunRPC]
	protected void AimNetwork(Vector3 position)
	{
		Aim(position, null);
	}

	protected void OnAimed(UITweener tween)
	{
		if (TurretSeesEnemy())
		{
			StartShooting();
		}
		else
		{
			mNextShotTime = Time.time + UnityEngine.Random.Range(minShootTime, maxShootTime);
		}
	}

	protected virtual void StartShooting()
	{
		Fire(batchedWeapon, mTarget, fake: false);
	}

	protected void Fire(BatchedWeapon w, GameShootableEntity target, bool fake)
	{
		if (!(target != null))
		{
			return;
		}
		int batchSize = UnityEngine.Random.Range(batchSizeMin, batchSizeMax);
		GameShootableEntity.ShotTarget shotTarget = null;
		shotTarget = target.GetNearestTarget(GameShootableEntity.ShotTargetType.AllIn, mTransform.position);
		PlayerController playerController = target.owner as PlayerController;
		if (playerController != null)
		{
			if (playerShieldProbability < 0f)
			{
				return;
			}
			float num = Vector3.Angle(playerController.aimForward, mTransform.position - mTarget.mTransform.position);
			shotTarget = ((!(num > 50f) && playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield && !(UnityEngine.Random.value < playerShieldProbability)) ? target.GetNearestTarget(GameShootableEntity.ShotTargetType.WholeBody, base.transform.position) : target.GetNearestTarget((playerController.playerState != PlayerController.PlayerStatex.Walking) ? GameShootableEntity.ShotTargetType.Shield : GameShootableEntity.ShotTargetType.Moving, base.transform.position));
		}
		Vector3 position = shotTarget.transform.position;
		Ammo.ShotType shotType = Ammo.GetShotType(shotTarget);
		if (predictPosition)
		{
			position = Singleton<AimingHelper>.instance.PredictPosition(w.weapon, position, mTarget.velocity, 0f);
		}
		float realShotProb = ((!fake) ? realShotProbability : 0f);
		w.ShootBatch(shotTarget, position, batchSize, realShotProb, shotType);
	}

	private bool TurretSeesEnemy()
	{
		List<GameShootableEntity.ShotTarget> shotTargets = mTarget.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn);
		GameShootableEntity.ShotTarget shotTarget = shotTargets[0];
		return AIObject.CanSeeTargetStatic(seeEnemyTransform.position, shotTarget.transform.position);
	}
}
