using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class AssaultHelicopter : Vehicle<AssaultHelicopterBehaviour>
{
	private readonly PhotonTransform mPhotonTransform = new PhotonTransform();

	private float anglePom;

	public GameObject collidersForFall;

	public GameObject collidersForShot;

	public EnemyPointVehicle enemyPoint;

	public ParticleSystem fireDamage;

	public float gizmoSize = 100f;

	public List<Glass> glass;

	public DestroyableObject glassDestroyableObject;

	private DestroyableObjectMultipleParts mDestroyableObject;

	private bool mExploded;

	private float mNextShotTime;

	private float mPointReachedTime;

	private Rigidbody mRigidBody;

	private float mSpawnHealthPackTimer;

	private Transform mTransform;

	private int mWeaponShotCounter;

	private GameShootableEntity target;

	public List<BatchedWeapon> weapons;

	public float mass = 1f;

	public WayPointPath path;

	public float speed = 0.8f;

	public float breakDistance = 1f;

	public float breakSpeed = 0.4f;

	public bool dir = true;

	public bool loop;

	public float cornerDelayTime = 0.1f;

	private int mCurPathIndex;

	private int mPathLength;

	private Vector3 mSt;

	private float mStPom;

	private Vector3 mTargetPoint;

	private bool mUsingWayPoints;

	private Vector3 mVel;

	private Quaternion mFlyRot = Quaternion.identity;

	private AssaultHelicopterBehaviour mAssaultHelicopterBehaviour => (AssaultHelicopterBehaviour)behaviour;

	public override DestroyableObject destroyableObj => mDestroyableObject;

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = GetComponent<DestroyableObjectMultipleParts>();
		mDestroyableObject.isMetal = true;
		mDestroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		mDestroyableObject.OnDamage += DestroyableObjectOnOnDamage;
		mRigidBody = GetComponent<Rigidbody>();
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.weapon.owner = this;
		}
		mTransform = base.transform;
	}

	private void DestroyableObjectOnOnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if ((double)mDestroyableObject.healthRatio < 0.4 && damageInfo.type != DestroyableObject.DamageType.Basic)
		{
			fireDamage.Play();
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		mPhotonTransform.Reset();
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (path != null)
		{
			path.usedByEntity = null;
			path = null;
		}
		mRigidBody.isKinematic = false;
		DestroySoldier(enemyPoint, damageInfo);
		collidersForShot.gameObject.SetActive(value: false);
		OnKilled(damageInfo);
		InvokeAfterRealTime(delegate
		{
			collidersForFall.gameObject.SetActive(value: true);
		}, 0.2f);
		if (enemyPoint.enemyAtPoint != null)
		{
			enemyPoint.enemyAtPoint.Killed -= SoldierOnKilled;
		}
	}

	private void GenerateEnemy()
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour);
		enemyPoint.enemyAtPoint = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)behaviour.upgradeSlots.maxLevelOfUnit, behaviour.cardId);
			SpawningManager.instance.Spawn(enemyController, fraction, useEnergy: false, enemyPoint.position, startBehaviour: false);
			enemyPoint.enemyAtPoint = enemyController;
			enemyController.enemyPoint = enemyPoint;
			enemyController.StartEnemyBehaviour(EnemyController.EnemyAIState.Vehicle);
			enemyController.SetMaxHealthAndRefill(behaviour.upgradeSlots.GetSoldierHpInMechanic(unitUpgrades.slotUpgradeindex) * unitUpgrades.scaleHp);
			enemyController.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef + 1;
			enemyController.SittingIdle();
			enemyController.Killed += SoldierOnKilled;
		}
	}

	private void SoldierOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo arg2)
	{
		gameMainEntity.Killed -= SoldierOnKilled;
		EnemyController enemyController = gameMainEntity as EnemyController;
		enemyController.ClearEnemyPoint();
		destroyableObj.DoDamage(new DestroyableObject.DamageInfo
		{
			damageAmount = float.MaxValue,
			owner = arg2.owner,
			isNetwork = false,
			type = DestroyableObject.DamageType.Basic
		});
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!isAlive && !mExploded && TagsAndLayers.IsStatic(collision.gameObject))
		{
			Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateHeavy);
			mExploded = true;
			Singleton<HitParticleSystem>.instance.PlayParticles(mTransform.position, Vector3.up, "metalExplosion", "grenadeExplosion");
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = base.transform.position;
			explosionInfo.explodeDamage = destroyableObj.maxHealth * 0.3f;
			explosionInfo.damageAmount = destroyableObj.maxHealth * 0.03f;
			explosionInfo.owner = this;
			explosionInfo.isNetworkCopy = !photonView.isMine;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.MissileExplode(i);
			collidersForFall.gameObject.SetActive(value: false);
			DestroyEntity(0.2f);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = true;
		fireDamage.Stop();
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.Reset();
		}
		if (!isPrewiev)
		{
			SetShadowsActive(value: true);
			StopAllCoroutines();
			mPower = behaviour.totalPower;
			mNextShotTime = Time.time + 2f;
			mExploded = false;
			collidersForFall.gameObject.SetActive(value: false);
			collidersForShot.gameObject.SetActive(value: true);
			if (photonView.isMine)
			{
				GenerateEnemy();
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		fireDamage.Stop();
	}

	public void SetWayPoint(WayPoint point)
	{
		mPathLength = point.path.wayPoints.Count;
		mCurPathIndex = point.index;
		mTargetPoint = point.transform.position;
		mUsingWayPoints = true;
		path = point.path;
		point.path.usedByEntity = this;
	}

	private void FixedUpdate()
	{
		if (!isPrewiev && !isAlive && Singleton<GameController>.instance.gameIsRunning)
		{
			Vector3 vector = Singleton<MapManager>.instance.currentMapDef.floorTransform.position - base.transform.position;
			vector.Normalize();
			mRigidBody.AddForce(Vector3.up * 8.5f + vector * 3f, ForceMode.Force);
			mRigidBody.AddTorque(mTransform.up * 0.6f, ForceMode.Force);
		}
	}

	protected override void Update()
	{
		base.Update();
		if (isPrewiev)
		{
			return;
		}
		if (TimeManager.realTimeWithoutPauses > mSpawnHealthPackTimer && fraction == PlayerController.currentPlayer.fraction && Singleton<GameController>.instance.gameIsRunning && base.hasSpecial)
		{
			mSpawnHealthPackTimer = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(10f, 30f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.shootableBox, base.transform.position + Vector3.up * 0.2f + base.transform.forward * 0.2f, Quaternion.identity);
			shootableBox.mode = ShootableBox.Mode.Health;
			shootableBox.power = mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.special;
		}
		if (photonView.isMine)
		{
			if (isAlive)
			{
				Movement();
			}
		}
		else if (mRigidBody.isKinematic)
		{
			mPhotonTransform.Update(mTransform);
		}
	}

	private void StartShooting()
	{
		Vector3 vector = default(Vector3);
		PlayerController playerController = target.owner as PlayerController;
		GameShootableEntity.ShotTarget shotTarget = null;
		GameShootableEntity.ShotTarget shotTarget2 = null;
		if (playerController != null)
		{
			float num = Vector3.Angle(playerController.aimForward, mTransform.position - target.mTransform.position);
			if (num < 50f && playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield)
			{
				if (UnityEngine.Random.value < behaviour.upgradeSlots.shieldHitProbability)
				{
					List<GameShootableEntity.ShotTarget> shotTargets = target.GetShotTargets(GameShootableEntity.ShotTargetType.Shield);
					shotTarget = shotTargets[0];
					shotTarget2 = shotTargets[0];
				}
				else
				{
					List<GameShootableEntity.ShotTarget> shotTargets2 = target.GetShotTargets(GameShootableEntity.ShotTargetType.WholeBody);
					shotTarget = shotTargets2[1];
					shotTarget2 = shotTargets2[0];
				}
			}
			else if (playerController.playerState == PlayerController.PlayerStatex.Walking)
			{
				shotTarget = target.GetNearestTarget(GameShootableEntity.ShotTargetType.Moving, base.transform.position);
				shotTarget2 = shotTarget;
			}
			else
			{
				shotTarget = target.GetNearestTarget(GameShootableEntity.ShotTargetType.WholeBody, base.transform.position);
				shotTarget2 = shotTarget;
			}
			Shoot(playerController.destroyableParts.velocity, shotTarget, shotTarget2);
		}
		else
		{
			shotTarget = target.GetNearestTarget(GameShootableEntity.ShotTargetType.AllIn, base.transform.position);
			Shoot(Vector3.zero, shotTarget, shotTarget);
		}
	}

	private void Shoot(Vector3 velocity, GameShootableEntity.ShotTarget t, GameShootableEntity.ShotTarget t2)
	{
		int batch = UnityEngine.Random.Range(mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.fireBatchSizeMin, mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.fireBatchSizeMax);
		Ammo.ShotType s = Ammo.GetShotType(t);
		Vector3 pos = t.transform.position;
		pos = Singleton<AimingHelper>.instance.PredictPosition(weapons[0].weapon, pos, velocity, 0f);
		float pr = mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.probabilityOfRealShot;
		weapons[0].ShootBatch(t, pos, (int)((double)batch * 0.5), pr, s);
		InvokeAfter(delegate
		{
			pos = t2.transform.position;
			s = Ammo.GetShotType(t2);
			if (t.type != GameShootableEntity.ShotTargetType.Shield)
			{
				pos = Singleton<AimingHelper>.instance.PredictPosition(weapons[0].weapon, pos, velocity, 0f);
			}
			weapons[1].ShootBatch(t, pos, batch - (int)((double)batch * 0.5), pr, s);
		}, (float)weapons[1].weapon.cadence * 0.5f);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + mVel * gizmoSize);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + mSt * gizmoSize);
	}

	public virtual void PickTarget()
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, new Type[1] { typeof(Decoy) });
		if (opponents.Count > 0)
		{
			target = opponents[UnityEngine.Random.Range(0, opponents.Count)];
			return;
		}
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(fraction);
		target = randomEnemy.gameShootableEntity;
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> spawnPoints = Singleton<MapManager>.instance.currentMapDef.spawnPointsCollectionAssaultHelis.spawnPoints;
		List<SpawnPointDrone> list = new List<SpawnPointDrone>();
		foreach (SpawnPoint item in spawnPoints)
		{
			SpawnPointDrone spawnPointDrone = (SpawnPointDrone)item;
			if (spawnPointDrone.pointToJoin.path.usedByEntity == null && spawnPointDrone.fraction == fraction)
			{
				list.Add(spawnPointDrone);
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			SpawnPointDrone spawnPointDrone2 = list[index];
			base.transform.position = spawnPointDrone2.transform.position;
			Vector3 forward = spawnPointDrone2.pointToJoin.transform.position - spawnPointDrone2.transform.position;
			forward.y = 0f;
			mFlyRot = Quaternion.LookRotation(forward);
			SetWayPoint(spawnPointDrone2.pointToJoin);
		}
		else
		{
			Debug.LogError("AssaultHeli could not be spawned");
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		SetShadowsActive(value: true);
		ClearEnemyPoint(enemyPoint, SoldierOnKilled);
		if (path != null)
		{
			path.usedByEntity = null;
			path = null;
		}
	}

	protected override void SetupCollisionLayers(Fractions fraction)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(fraction, isFlying: true);
		}
	}

	private Vector3 Steer(Vector3 target, bool bFinalPoint = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < mPointReachedTime + cornerDelayTime)
		{
			return default(Vector3);
		}
		Vector3 vector = target - mTransform.position;
		Vector3 normalized = vector.normalized;
		if (bFinalPoint && vector.magnitude < breakDistance)
		{
			float num = vector.magnitude / breakDistance;
			normalized *= breakSpeed * deltaTime * num;
		}
		else
		{
			normalized *= speed * deltaTime;
		}
		Vector3 vector2 = normalized - mVel;
		return vector2 / mass;
	}

	private void Movement()
	{
		if (!mUsingWayPoints || !(Time.timeScale > 0.1f) || !(path != null))
		{
			return;
		}
		if (Time.time > mNextShotTime)
		{
			PickTarget();
			StartShooting();
			mNextShotTime += UnityEngine.Random.Range(mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.minShootTime, mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.maxShootTime);
		}
		if (Vector3.Distance(mTransform.position, mTargetPoint) < path.Radius)
		{
			if (UnityEngine.Random.value < 0.1f)
			{
				dir = !dir;
			}
			mPointReachedTime = Time.time;
			if (mCurPathIndex < mPathLength - 1 && dir)
			{
				mCurPathIndex++;
				mTargetPoint = path.wayPoints[mCurPathIndex].transform.position;
			}
			else if (mCurPathIndex != 0 && !dir)
			{
				mCurPathIndex--;
				mTargetPoint = path.wayPoints[mCurPathIndex].transform.position;
			}
			else if (loop && dir)
			{
				mCurPathIndex = 0;
				mTargetPoint = path.wayPoints[mCurPathIndex].transform.position;
			}
			else
			{
				if (!loop || dir)
				{
					mUsingWayPoints = false;
					return;
				}
				mCurPathIndex = mPathLength - 1;
				mTargetPoint = path.wayPoints[mCurPathIndex].transform.position;
			}
		}
		if (mCurPathIndex < mPathLength)
		{
			mSt = Steer(mTargetPoint, bFinalPoint: true);
			mVel += mSt;
			mTransform.position += mVel;
			if (target != null)
			{
				Vector3 forward = target.mTransform.position - mTransform.position;
				forward.y = 0f;
				mFlyRot = Quaternion.LookRotation(forward);
			}
			base.transform.position += mVel;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, ComputeRot(mVel), Time.deltaTime * 3f);
		}
	}

	private Quaternion ComputeRot(Vector3 vel)
	{
		float num = Vector3.Angle(Vector3.up, vel);
		if (num < 70f || num > 110f)
		{
			return mFlyRot;
		}
		Vector3 forward = vel;
		forward.y = 0f;
		forward.Normalize();
		Vector3 v = Quaternion.LookRotation(forward) * Vector3.forward;
		v.y = 0f;
		Vector3 v2 = mFlyRot * Vector3.forward;
		v2.y = 0f;
		float angle = GeometryTools.AngleSigned(v, v2, Vector3.up);
		forward.y = -0.3f;
		return Quaternion.LookRotation(forward) * Quaternion.AngleAxis(angle, Vector3.up);
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.health;
		mDestroyableObject.shotCoeficient = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		mDestroyableObject.RefillOffline();
		foreach (BatchedWeapon weapon in weapons)
		{
			weapon.weapon.ammoSetup.damageAmount = mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.damage;
			BulletSetup bulletSetup = (BulletSetup)weapon.weapon.ammoSetup;
			bulletSetup.speed = mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.shotSpeed;
			bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
			bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		}
		mSpawnHealthPackTimer = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(10f, 30f);
		glassDestroyableObject.maxHealth = (float)mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.glassHealth * unitUpgrades.scaleHp;
		glassDestroyableObject.owner = this;
		glassDestroyableObject.RefillOffline();
		foreach (Glass item in glass)
		{
			item.Enable();
		}
		speed = Mathf.Clamp(mAssaultHelicopterBehaviour.assaultHelicopterBehaviour.speed, 0.2f, 0.6f);
		breakSpeed = speed;
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		EnemyController enemyController = GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, enemyPoint, disableWeapon: true);
		enemyController.SittingIdle();
		if (isPrewiev)
		{
			mRigidBody.isKinematic = true;
		}
		SetShadowsActive(value: false);
	}

	public override void DoReverseAnim()
	{
		base.DoReverseAnim();
		TweenPosition.Begin(base.gameObject, 2f, base.gameObject.transform.position + Vector3.up * 1.5f);
	}
}
