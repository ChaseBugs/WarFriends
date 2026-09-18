using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class Mech : MechanicalUnit<MechBehaviour>
{
	private enum MechState
	{
		Walk,
		Strafe,
		Shoot,
		Idle
	}

	[SerializeField]
	private NavigationAgent mAgent;

	[SerializeField]
	private DestroyableObjectMultipleParts mDestroyableObject;

	[SerializeField]
	private MechAnimator mMechAnimator;

	public float strafeSpeed = 0.3f;

	public List<BatchedWeapon> weapons;

	private EnemyPoint mEnemyPoint;

	private bool mIsShooting;

	private MechState mMechState;

	private float mNextShootTime;

	private GameShootableEntity mTarget;

	private readonly PhotonTransform mPhotonTransform = new PhotonTransform();

	public override DestroyableObject destroyableObj => mDestroyableObject;

	private MechBehaviour mMechBehaviour => (MechBehaviour)behaviour;

	public override void GetAudioSources(List<AudioSource> list)
	{
		base.GetAudioSources(list);
		if (mMechAnimator != null)
		{
			list.Add(mMechAnimator.mechSource);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject.isMetal = true;
		mDestroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		mDestroyableObject.OnDamage += DestroyableObjectOnOnDamage;
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.weapon.owner = this;
		}
		weapons[0].ShootEnded += OnShootEnded;
		MechAnimator mechAnimator = mMechAnimator;
		mechAnimator.Aimed = (Action)Delegate.Combine(mechAnimator.Aimed, new Action(OnAimed));
	}

	private void DestroyableObjectOnOnDamage(DestroyableObject arg1, DestroyableObject.DamageInfo arg2)
	{
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject obj, DestroyableObject.DamageInfo damageInfo)
	{
		if (isAlive)
		{
			Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position + base.transform.up * 0.2f, Vector3.up, "metalExplosion", "grenadeExplosion");
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = base.transform.position;
			explosionInfo.explodeDamage = 350f;
			explosionInfo.damageAmount = 40f;
			explosionInfo.owner = this;
			explosionInfo.isNetworkCopy = !photonView.isMine;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.Explode(i);
			mMechAnimator.StopWalkSound();
			OnKilled(damageInfo);
			DestroyEntity(0.2f);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.Reset();
		}
		mTarget = null;
		mMechAnimator.Reset();
		mAgent.Disable();
		mPower = behaviour.totalPower;
		if (isPrewiev)
		{
			mMechAnimator.PreviewIdle();
		}
		else
		{
			mMechAnimator.Idle();
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = mMechBehaviour.mechDefinition.health;
		mDestroyableObject.shotCoeficient = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		mDestroyableObject.RefillOffline();
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.weapon.ammoSetup.damageAmount = mMechBehaviour.mechDefinition.damage;
			BulletSetup bulletSetup = (BulletSetup)weapon.weapon.ammoSetup;
			bulletSetup.speed = mMechBehaviour.mechDefinition.shotSpeed;
			bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
			bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> spawnPoints = Singleton<MapManager>.instance.currentMapDef.spawnPointsCollection.spawnPoints;
		foreach (SpawnPoint item in spawnPoints)
		{
			if (AcceptSpawnPoint(item))
			{
				base.transform.position = item.transform.position;
				break;
			}
		}
	}

	public virtual bool AcceptSpawnPoint(SpawnPoint point)
	{
		return point.spawnPointType == SpawnPoint.SpawnPointType.Normal && fraction == point.fraction;
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
		FindPos(isFirst: true);
		mMechAnimator.Walk();
		mAgent.speed = base.currentBeh.mechDefinition.speed;
		mMechState = MechState.Walk;
		mNextShootTime = Time.time + 5f;
	}

	private void FindPos(bool isFirst)
	{
		List<EnemyPoint> points = SpawningManager.instance.GetPoints(EnemyPoint.EnemyPointType.Mech, mEnemyPoint, fraction);
		if (mEnemyPoint != null)
		{
			mEnemyPoint.enemyAtPoint = null;
		}
		EnemyPoint enemyPoint = points[UnityEngine.Random.Range(0, points.Count)];
		if (isFirst)
		{
			points.Sort((EnemyPoint a, EnemyPoint b) => Vector3.Distance(a.position, base.transform.position).CompareTo(Vector3.Distance(b.position, base.transform.position)));
			enemyPoint = points[0];
		}
		enemyPoint.enemyAtPoint = this;
		mEnemyPoint = enemyPoint;
		mAgent.SetDestination(enemyPoint.position);
	}

	protected override void Update()
	{
		base.Update();
		if (mEnemyPoint != null)
		{
			switch (mMechState)
			{
			case MechState.Walk:
				WalkUpdate();
				break;
			case MechState.Strafe:
				StrafeUpdate();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case MechState.Shoot:
			case MechState.Idle:
				break;
			}
		}
		if (!photonView.isMine && Singleton<GameController>.instance.gameIsRunning)
		{
			mPhotonTransform.Update(base.transform);
		}
	}

	private void WalkUpdate()
	{
		if (mEnemyPoint.IsEnemyPointReached(base.transform.position))
		{
			PickTarget(aim: true, needToSee: false);
			mMechAnimator.Idle();
			InvokeAfter(StrafeToNextPosition, 3f);
			mMechState = MechState.Idle;
		}
		if (Time.time > mNextShootTime && base.isInField)
		{
			if (PickTarget(aim: true, needToSee: true))
			{
				mMechState = MechState.Shoot;
				mMechAnimator.Idle();
				mAgent.Disable();
				InvokeAfter(ContinueWalking, 3f);
				mNextShootTime = float.MaxValue;
			}
			else
			{
				mNextShootTime = Time.time + 2.5f;
			}
		}
	}

	private void StrafeUpdate()
	{
		if (mEnemyPoint.IsEnemyPointReached(base.transform.position))
		{
			mMechAnimator.Idle();
			mMechState = MechState.Idle;
			InvokeAfter(StrafeToNextPosition, 3f);
		}
		mMechAnimator.LookAt(mTarget.transform.position, keepAimed: true);
		if (Time.time > mNextShootTime)
		{
			StartShooting();
			mMechAnimator.Shoot();
			mNextShootTime = float.MaxValue;
		}
	}

	private void StrafeToNextPosition()
	{
		FindPos(isFirst: false);
		bool left = Vector3.Cross(mTarget.transform.position - base.transform.position, mEnemyPoint.position - base.transform.position).y < 0f;
		mMechAnimator.Strafe(left);
		mMechState = MechState.Strafe;
		mAgent.speed = strafeSpeed;
		mNextShootTime = Time.time + UnityEngine.Random.Range(mMechBehaviour.mechDefinition.minShootTime, mMechBehaviour.mechDefinition.maxShootTime);
	}

	private void ContinueWalking()
	{
		mMechAnimator.Walk();
		mMechAnimator.LookAt(base.transform.position + base.transform.forward, keepAimed: false);
		mNextShootTime = Time.time + UnityEngine.Random.Range(mMechBehaviour.mechDefinition.minShootTime, mMechBehaviour.mechDefinition.maxShootTime);
		mAgent.SetDestination(mEnemyPoint.position);
		mMechState = MechState.Walk;
		mTarget = null;
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		mPhotonTransform.OnPhotonSerializeView(base.transform, stream, info);
	}

	public bool PickTarget(bool aim, bool needToSee)
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(fraction);
		mTarget = randomEnemy.gameShootableEntity;
		bool flag = false;
		if (needToSee)
		{
			flag = CanSeeTarget(mTarget.GetNearestTarget(GameShootableEntity.ShotTargetType.Shield, base.transform.position).transform.position);
		}
		if (aim && flag)
		{
			mMechAnimator.LookAt(mTarget.transform.position, keepAimed: false);
		}
		return flag;
	}

	private void OnAimed()
	{
		if (mTarget != null && mMechState == MechState.Shoot)
		{
			mMechAnimator.Shoot();
			StartShooting();
		}
	}

	private void StartShooting()
	{
		Vector3 tOffset = default(Vector3);
		Vector3 t2Offset = default(Vector3);
		Vector3 vector = default(Vector3);
		PlayerController playerController = mTarget.owner as PlayerController;
		GameShootableEntity.ShotTarget shotTarget = null;
		GameShootableEntity.ShotTarget shotTarget2 = null;
		if (playerController != null)
		{
			float num = GeometryTools.AngleSigned(playerController.aimForward, base.transform.position - mTarget.mTransform.position, Vector3.up);
			if (Mathf.Abs(num) < 50f && playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield)
			{
				if (UnityEngine.Random.value < behaviour.upgradeSlots.shieldHitProbability)
				{
					List<GameShootableEntity.ShotTarget> shotTargets = mTarget.GetShotTargets(GameShootableEntity.ShotTargetType.Shield);
					shotTarget = shotTargets[0];
					shotTarget2 = shotTargets[0];
				}
				else
				{
					List<GameShootableEntity.ShotTarget> shotTargets2 = mTarget.GetShotTargets(GameShootableEntity.ShotTargetType.WholeBody);
					shotTarget = shotTargets2[1];
					shotTarget2 = shotTargets2[0];
					if (Mathf.Abs(num) > 20f)
					{
						Vector3 lhs = shotTarget.transform.position - base.transform.position;
						lhs = lhs.ReplaceXY(0f, 0f).normalized * 0.1f;
						tOffset = ((!(num > 0f)) ? Vector3.zero : lhs);
						t2Offset = ((!(num <= 0f)) ? Vector3.zero : lhs);
					}
				}
			}
			else if (playerController.playerState == PlayerController.PlayerStatex.Walking)
			{
				shotTarget = mTarget.GetNearestTarget(GameShootableEntity.ShotTargetType.Moving, base.transform.position);
				shotTarget2 = shotTarget;
			}
			else
			{
				shotTarget = mTarget.GetNearestTarget(GameShootableEntity.ShotTargetType.WholeBody, base.transform.position);
				shotTarget2 = shotTarget;
			}
			Shoot(playerController.destroyableParts.velocity, shotTarget, shotTarget2, tOffset, t2Offset);
		}
		else
		{
			shotTarget = mTarget.GetNearestTarget(GameShootableEntity.ShotTargetType.AllIn, base.transform.position);
			Shoot(Vector3.zero, shotTarget, shotTarget, tOffset, t2Offset);
		}
	}

	private void Shoot(Vector3 velocity, GameShootableEntity.ShotTarget t, GameShootableEntity.ShotTarget t2, Vector3 tOffset, Vector3 t2Offset)
	{
		int batch = UnityEngine.Random.Range(mMechBehaviour.mechDefinition.fireBatchSizeMin, mMechBehaviour.mechDefinition.fireBatchSizeMax);
		Ammo.ShotType s = Ammo.GetShotType(t);
		Vector3 pos = t.transform.position;
		pos = Singleton<AimingHelper>.instance.PredictPosition(weapons[0].weapon, pos, velocity, 0f);
		float pr = mMechBehaviour.mechDefinition.probabilityOfRealShot;
		weapons[0].ShootBatch(t, pos + tOffset, (int)((double)batch * 0.5), pr, s);
		InvokeAfter(delegate
		{
			pos = t2.transform.position;
			s = Ammo.GetShotType(t2);
			if (t.type != GameShootableEntity.ShotTargetType.Shield)
			{
				pos = Singleton<AimingHelper>.instance.PredictPosition(weapons[0].weapon, pos, velocity, 0f);
			}
			weapons[1].ShootBatch(t, pos + t2Offset, batch - (int)((double)batch * 0.5), pr, s);
		}, (float)weapons[1].weapon.cadence * 0.5f);
	}

	private void OnShootEnded()
	{
		mMechAnimator.StopShoot();
		mNextShootTime = Time.time + UnityEngine.Random.Range(mMechBehaviour.mechDefinition.minShootTime, mMechBehaviour.mechDefinition.maxShootTime);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		mPhotonTransform.Reset();
	}
}
