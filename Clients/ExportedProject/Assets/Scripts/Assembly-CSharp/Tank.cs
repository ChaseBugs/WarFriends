using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class Tank : Vehicle<TankBehaviour>
{
	public float speed = 0.8f;

	public float pathRadius = 0.7f;

	private DestroyableObjectMultipleParts mDestroyableObject;

	public EnemyPointVehicle enemyPointTurret;

	public EnemyPointVehicle enemyPointCannon;

	public Animation tankAnimationRight;

	public Animation tankAnimationLeft;

	public GameObject carveCollider;

	public GameObject obstacleColliders;

	private Vector3 mRopeTargetPos;

	private Transform mTransform;

	private int mPathLength;

	private int mCurPathIndex;

	private Transform mTargetPoint;

	private bool mUsingWayPoints;

	private Rigidbody mRigibody;

	private bool mTargetReached;

	private Vector3 mStayDir;

	private Vector3 mWantedPosition;

	private Quaternion mWantedRotation;

	private float mVel;

	public TurretWeaponBasic cannon;

	public TurretWeaponBasic turret;

	public AnimationCurve steerForce;

	private Vector3 mStartPos;

	public float torqueMultiplayer = 2f;

	private readonly PhotonTransform mPhotonTransform = new PhotonTransform();

	public float reverseMultiplier = 0.2f;

	public float reverseMaxSpeed = 1f;

	private WaypointCircuit mCircout;

	private SpawnPointCar spawnedFrom;

	public override DestroyableObject destroyableObj => mDestroyableObject;

	private void OnEnable()
	{
		Weapon.OnShotFired -= WeaponOnOnShotFired;
		Weapon.OnShotFired += WeaponOnOnShotFired;
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 position)
	{
		if (weapon == cannon.batchedWeapon.weapon)
		{
			CannonOnShooted(position);
		}
	}

	private void OnDisable()
	{
		Weapon.OnShotFired -= WeaponOnOnShotFired;
	}

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = GetComponent<DestroyableObjectMultipleParts>();
		mTransform = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		mDestroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		mRigibody = GetComponent<Rigidbody>();
		tankAnimationRight["right"].wrapMode = WrapMode.Loop;
		tankAnimationLeft["left"].wrapMode = WrapMode.Loop;
		Object.DontDestroyOnLoad(carveCollider);
		mStartPos = cannon.transform.localPosition;
	}

	private void CannonOnShooted(Vector3 position)
	{
		Vector3 position2 = cannon.batchedWeapon.weapon.spawnPoint.transform.position;
		PlayShootFeedBack(position - position2);
		Vector3 vector = cannon.transform.InverseTransformDirection((position - position2).normalized);
		TweenPosition tweenPosition = TweenPosition.Begin(cannon.gameObject, 0.25f, mStartPos, mStartPos - vector * 0.16f);
		tweenPosition.NumOfRepetitions = 2;
		tweenPosition.style = UITweener.Style.PingPong;
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (isAlive)
		{
			Singleton<HitParticleSystem>.instance.PlayParticles(mTransform.position - base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			Singleton<HitParticleSystem>.instance.PlayParticles(mTransform.position + base.transform.up * 0.2f, Vector3.up, "metalExplosion", "grenadeExplosion");
			DestroySoldier(enemyPointCannon, damageInfo);
			DestroySoldier(enemyPointTurret, damageInfo);
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = base.transform.position;
			explosionInfo.explodeDamage = destroyableObj.maxHealth * 0.3f;
			explosionInfo.damageAmount = destroyableObj.maxHealth * 0.03f;
			explosionInfo.owner = this;
			explosionInfo.isNetworkCopy = !photonView.isMine;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.MissileExplode(i);
			OnKilled(damageInfo);
			DestroyEntity(0.2f);
		}
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (inGame)
		{
			tankAnimationLeft.Stop();
			tankAnimationRight.Stop();
			GetComponent<Rigidbody>().isKinematic = false;
		}
		else
		{
			tankAnimationLeft.Play("left");
			tankAnimationRight.Play("right");
			GetComponent<Rigidbody>().isKinematic = true;
		}
		EnemyController enemyController = GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, enemyPointCannon, disableWeapon: true);
		enemyController = GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, enemyPointTurret, disableWeapon: true);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = isPrewiev;
		tankAnimationLeft.Play("left");
		tankAnimationRight.Play("right");
		cannon.enabled = false;
		turret.ResetAiming();
		if (!isPrewiev)
		{
			StopAllCoroutines();
			obstacleColliders.gameObject.SetActive(value: true);
			mTargetReached = false;
			mRigibody.velocity = Vector3.zero;
			mRigibody.angularVelocity = Vector3.zero;
			mPower = base.currentBeh.totalPower;
			if (photonView.isMine)
			{
				GenerateEnemy(enemyPointTurret, isFirst: true);
				GenerateEnemy(enemyPointCannon, isFirst: true);
			}
			cannon.enabled = true;
			cannon.Reset();
			turret.enabled = true;
			turret.Reset();
			cannon.ResetAiming();
			GetComponent<Rigidbody>().isKinematic = !photonView.isMine;
		}
	}

	private void GenerateEnemy(EnemyPointVehicle point, bool isFirst)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour);
		point.enemyAtPoint = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)behaviour.upgradeSlots.maxLevelOfUnit, behaviour.cardId);
			SpawningManager.instance.Spawn(enemyController, fraction, useEnergy: false, point.position, startBehaviour: false);
			point.enemyAtPoint = enemyController;
			enemyController.enemyPoint = point;
			enemyController.StartEnemyBehaviour(EnemyController.EnemyAIState.Vehicle);
			enemyController.SetMaxHealthAndRefill(behaviour.upgradeSlots.GetSoldierHpInMechanic(unitUpgrades.slotUpgradeindex) * unitUpgrades.scaleHp);
			enemyController.Killed += EnemyOnKilled;
			if (point == enemyPointTurret)
			{
				enemyController.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef - 1;
				turret.enabled = true;
				turret.Reset();
			}
			else
			{
				enemyController.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef - 1;
				cannon.enabled = true;
				cannon.Reset();
			}
		}
	}

	private void EnemyOnKilled(IGameMainEntity arg1, DestroyableObject.DamageInfo arg3)
	{
		EnemyController enemyController = (EnemyController)arg1;
		if (enemyController.enemyPoint == enemyPointTurret)
		{
			InvokeAfterRealTime(delegate
			{
				GenerateEnemy(enemyPointTurret, isFirst: false);
			}, behaviour.upgradeSlots.soldierRespawnRate);
			turret.enabled = false;
			turret.Reset();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.enemyPoint == enemyPointCannon)
		{
			cannon.enabled = false;
			cannon.Reset();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(delegate
			{
				GenerateEnemy(enemyPointCannon, isFirst: false);
			}, behaviour.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= EnemyOnKilled;
	}

	protected override void Start()
	{
		base.Start();
	}

	public override void SafeStart()
	{
		base.SafeStart();
		carveCollider.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		mPhotonTransform.Reset();
	}

	public void SetWayPoint(WaypointCircuit circout)
	{
		mPathLength = circout.waypointList.items.Length;
		mCurPathIndex = 0;
		mTargetPoint = circout.waypointList.items[0].transform;
		mUsingWayPoints = true;
		mCircout = circout;
	}

	protected override void Update()
	{
		base.Update();
		if (isPrewiev)
		{
			return;
		}
		if (photonView.isMine)
		{
			float magnitude = mRigibody.velocity.magnitude;
			float num = magnitude / speed;
			tankAnimationRight["right"].speed = num;
			tankAnimationLeft["left"].speed = num;
			return;
		}
		if (!photonView.isMine && Singleton<GameController>.instance.gameIsRunning)
		{
			mPhotonTransform.Update(mTransform);
		}
		float num2 = mVel / speed;
		tankAnimationRight["right"].speed = num2;
		tankAnimationLeft["left"].speed = num2;
	}

	private void FixedUpdate()
	{
		if (mDoReverseAnim && mRigibody.velocity.magnitude < reverseMaxSpeed)
		{
			mRigibody.AddForce(-mTransform.forward.normalized * reverseMultiplier, ForceMode.VelocityChange);
		}
		if (!isPrewiev && mUsingWayPoints && photonView.isMine && mTargetPoint != null && mCircout != null)
		{
			if (mTransform.position.PlanarDistance(mTargetPoint.position) < pathRadius && mCurPathIndex < mPathLength - 1)
			{
				mCurPathIndex++;
				mTargetPoint = mCircout.waypointList[mCurPathIndex];
			}
			Vector3 vector = (mTargetPoint.position - base.transform.position).ReplaceY(0f);
			vector = vector.ClampMagnitude(0.65f, 1f);
			float num = 360f - Vector3.Angle(vector, mTransform.forward);
			float num2 = Mathf.Pow(num / 360f, 3f);
			Vector3 vector2 = vector * speed * num2;
			Vector3 force = (vector2 - mRigibody.velocity).ReplaceY(0f);
			mRigibody.AddForce(force, ForceMode.VelocityChange);
			if (!mTargetReached)
			{
				Vector3 normalized = vector.normalized;
				float f = Vector3.Dot(mTransform.forward, normalized);
				Vector3 vector3 = Vector3.Cross(mTransform.forward, normalized) * torqueMultiplayer * steerForce.Evaluate(Mathf.Abs(f));
				Vector3 torque = vector3 - mRigibody.angularVelocity;
				mRigibody.AddTorque(torque, ForceMode.VelocityChange);
			}
			if (mCurPathIndex == mPathLength - 1 && !mTargetReached && mTargetPoint.position.PlanarDistance(base.transform.position) < 0.1f)
			{
				mTargetReached = true;
				mStayDir = base.transform.forward;
				carveCollider.gameObject.SetActive(value: true);
				obstacleColliders.gameObject.SetActive(value: false);
				carveCollider.transform.position = mTransform.position;
				carveCollider.transform.rotation = mTransform.rotation;
				GetComponent<Rigidbody>().isKinematic = true;
				isParked = true;
			}
		}
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			stream.SendNext(mRigibody.velocity.magnitude);
		}
		else
		{
			mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			mVel = (float)stream.ReceiveNext();
		}
	}

	private void OnDrawGizmos()
	{
		if ((bool)mTargetPoint)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(mTargetPoint.position, 0.3f);
		}
	}

	public void PlayShootFeedBack(Vector3 direction)
	{
		if (photonView.isMine)
		{
			if (!mRigibody.isKinematic)
			{
				mRigibody.AddForce(-direction.normalized * 20f, ForceMode.Impulse);
				mRigibody.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 0.1f, carveCollider.transform.position + 0.01f * Vector3.up - mStayDir * 0.01f, useLocal: false);
				tweenPosition.NumOfRepetitions = 2;
				tweenPosition.style = UITweener.Style.PingPong;
			}
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> spawnPoints = Singleton<MapManager>.instance.currentMapDef.spawnPointsCollectionCars.spawnPoints;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in spawnPoints)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.fraction == fraction && spawnPointCar.usedByEntity == null)
			{
				list.Add(spawnPointCar);
			}
		}
		if (list.Count > 0)
		{
			int index = Random.Range(0, list.Count);
			SpawnPointCar spawnPointCar2 = list[index];
			base.transform.position = spawnPointCar2.transform.position;
			base.transform.rotation = Quaternion.LookRotation(spawnPointCar2.waypointCircuit.waypointList[0].transform.position - spawnPointCar2.transform.position);
			spawnedFrom = spawnPointCar2;
			spawnedFrom.usedByEntity = this;
			SetWayPoint(spawnPointCar2.waypointCircuit);
		}
		else
		{
			Debug.LogError("Tank could not be spawned");
		}
	}

	public override void DestroyPooled()
	{
		ClearEnemyPoint(enemyPointTurret, EnemyOnKilled);
		ClearEnemyPoint(enemyPointCannon, EnemyOnKilled);
		carveCollider.gameObject.SetActive(value: false);
		obstacleColliders.gameObject.SetActive(value: false);
		if (spawnedFrom != null)
		{
			spawnedFrom.usedByEntity = null;
			spawnedFrom = null;
		}
		base.DestroyPooled();
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = base.currentBeh.tankBehaviourDefinititon.health;
		mDestroyableObject.RefillOffline();
		mDestroyableObject.shotCoeficient = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		MissileSetup missileSetup = (MissileSetup)cannon.batchedWeapon.weapon.ammoSetup;
		missileSetup.explodeDamageAmount = base.currentBeh.tankBehaviourDefinititon.damageCannon;
		missileSetup.damageAmount = base.currentBeh.tankBehaviourDefinititon.damageCannon / 30f;
		missileSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		missileSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.playerBehindShieldRatio = preparedBehaviour.upgradeSlots.playerBehindShieldDamageRatio;
		cannon.batchSizeMax = 1;
		cannon.batchSizeMin = 1;
		cannon.playerShieldProbability = behaviour.upgradeSlots.shieldHitProbability;
		if (base.hasSpecial)
		{
			cannon.minShootTime = base.currentBeh.tankBehaviourDefinititon.minShootTimeCannon * 0.7f;
			cannon.maxShootTime = base.currentBeh.tankBehaviourDefinititon.maxShootTimeCannon * 0.7f;
		}
		else
		{
			cannon.minShootTime = base.currentBeh.tankBehaviourDefinititon.minShootTimeCannon;
			cannon.maxShootTime = base.currentBeh.tankBehaviourDefinititon.maxShootTimeCannon;
		}
		cannon.realShotProbability = 1f;
		BulletSetup bulletSetup = (BulletSetup)turret.batchedWeapon.weapon.ammoSetup;
		bulletSetup.damageAmount = base.currentBeh.tankBehaviourDefinititon.damage;
		bulletSetup.speed = base.currentBeh.tankBehaviourDefinititon.shotSpeed;
		bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		turret.batchSizeMax = base.currentBeh.tankBehaviourDefinititon.fireBatchSizeMax;
		turret.batchSizeMin = base.currentBeh.tankBehaviourDefinititon.fireBatchSizeMin;
		turret.minShootTime = base.currentBeh.tankBehaviourDefinititon.minShootTime;
		turret.maxShootTime = base.currentBeh.tankBehaviourDefinititon.maxShootTime;
		turret.realShotProbability = base.currentBeh.tankBehaviourDefinititon.probabilityOfRealShot;
		speed = base.currentBeh.tankBehaviourDefinititon.speed;
	}
}
