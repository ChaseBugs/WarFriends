using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class Helicopter : Vehicle<HelicopterBehaviour>
{
	public float breakDistance = 4f;

	public float breakSpeed = 0.4f;

	public List<EnemyPointHelicopter> enemyPoints;

	public EnemyPointVehicle enemyPointVehicle;

	public bool loop;

	private float mActual;

	private float mAnglePom;

	public float mass = 1f;

	private int mCurPathIndex;

	private DestroyableObjectMultipleParts mDestroyableObject;

	private Quaternion mHorizontal = Quaternion.identity;

	private bool mIsBreaking;

	private bool mIsStopped;

	private int mPathLength;

	private Rigidbody mRigidBody;

	private Vector3 mRopeEndPos;

	private Vector3 mRopeTargetPos;

	private float mRt;

	private bool mShowRope;

	private Vector3 mSt;

	private Transform mStopPoint;

	private Transform mTargetPoint;

	private float mTimeDelta;

	private float mTimeStart;

	private bool mTimeStarted;

	public Transform mTransform;

	public float multiplier = 1f;

	private bool mUsingWayPoints;

	private Vector3 mVel;

	private Quaternion mVertical = Quaternion.identity;

	public WayPointPath path;

	public QuickRope2 rope;

	private EnemyController soldier;

	public float speed = 0.8f;

	public TurretWeaponBasic turret;

	public ParticleSystem[] particles;

	private readonly PhotonTransform mPhotonTransform = new PhotonTransform();

	public override DestroyableObject destroyableObj => mDestroyableObject;

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = GetComponent<DestroyableObjectMultipleParts>();
		mRigidBody = GetComponent<Rigidbody>();
		mTransform = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		mDestroyableObject.OnDeath += OnOnDeath;
	}

	private void OnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		StopAllCoroutines();
		mRigidBody.isKinematic = false;
		mRigidBody.useGravity = true;
		if (isAlive)
		{
			base.gameObject.layer = TagsAndLayers.collideOnlyEnviroment;
			mDestroyableObject.gameObject.layer = TagsAndLayers.collideOnlyEnviroment;
			DestroyableObjectpart[] parts = mDestroyableObject.parts;
			foreach (DestroyableObjectpart destroyableObjectpart in parts)
			{
				destroyableObjectpart.gameObject.layer = TagsAndLayers.collideOnlyEnviroment;
			}
			mRigidBody.AddTorque(new Vector3(0f, 1f, 0f), ForceMode.VelocityChange);
			foreach (EnemyPointHelicopter enemyPoint in enemyPoints)
			{
				DestroySoldier(enemyPoint, damageInfo);
			}
			OnKilled(damageInfo);
			DestroySoldier(enemyPointVehicle, damageInfo);
		}
		if (path != null)
		{
			path.usedByEntity = null;
			path = null;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!isAlive && TagsAndLayers.IsStatic(collision.collider.gameObject))
		{
			Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateHeavy);
			DestroyEntity(0.2f);
			Singleton<HitParticleSystem>.instance.PlayParticles(mTransform.position + base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			Singleton<HitParticleSystem>.instance.PlayParticles(mTransform.position - base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = base.transform.position;
			explosionInfo.explodeDamage = destroyableObj.maxHealth * 0.5f;
			explosionInfo.damageAmount = destroyableObj.maxHealth * 0.05f;
			explosionInfo.owner = this;
			explosionInfo.isNetworkCopy = !photonView.isMine;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.MissileExplode(i);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		StopAllCoroutines();
		mRigidBody.isKinematic = true;
		mIsStopped = false;
		mPower = base.currentBeh.totalPower;
		rope.ropeEnd.gameObject.SetActive(value: false);
		rope.gameObject.SetActive(value: false);
		if (!isPrewiev)
		{
			InvokeAfterRealTime(delegate
			{
				rope.ropeEnd.transform.localPosition = mRopeEndPos;
				rope.ropeEnd.gameObject.SetActive(value: true);
				rope.gameObject.SetActive(value: true);
			}, 2f);
		}
		turret.enabled = true;
		turret.Reset();
		turret.ResetAiming();
		SetShadowsActive(value: true);
		ParticleSystem[] array = particles;
		foreach (ParticleSystem particleSystem in array)
		{
			particleSystem.gameObject.SetActive(value: true);
		}
	}

	public override void SafeStart()
	{
		base.SafeStart();
		mRopeEndPos = rope.ropeEnd.transform.localPosition;
	}

	public override void BeforeInstancied()
	{
		mPhotonTransform.Reset();
		foreach (EnemyPointHelicopter enemyPoint in enemyPoints)
		{
			enemyPoint.enemyAtPoint = null;
		}
		base.BeforeInstancied();
		rope.ropeEnd.transform.localPosition = mRopeEndPos;
		mShowRope = false;
		rope.gameObject.SetActive(value: false);
	}

	public void SetWayPoint(WayPoint point)
	{
		mPathLength = point.path.wayPoints.Count;
		mCurPathIndex = point.index;
		mTargetPoint = point.transform;
		mUsingWayPoints = true;
		path = point.path;
		point.path.usedByEntity = this;
	}

	protected override void Update()
	{
		base.Update();
		if (isPrewiev)
		{
			return;
		}
		if (mShowRope)
		{
			if (rope.ropeEnd.transform.position.y > mRopeTargetPos.y)
			{
				rope.ExtendRope(0.7f);
			}
			else
			{
				mShowRope = false;
			}
		}
		if (photonView.isMine)
		{
			if (!isAlive || !mUsingWayPoints || !(path != null))
			{
				return;
			}
			if (Vector3.Distance(mTransform.position, mTargetPoint.position) < path.Radius)
			{
				if (mCurPathIndex < mPathLength - 1)
				{
					mCurPathIndex++;
					mTargetPoint = path.wayPoints[mCurPathIndex].transform;
				}
				else if (loop)
				{
					mCurPathIndex = 0;
					mTargetPoint = path.wayPoints[mCurPathIndex].transform;
				}
			}
			mSt = Steer();
			mVel += mSt;
			mTransform.position += mVel * Time.timeScale;
			Vector3 forward = ((!mIsBreaking) ? mVel : (mTargetPoint.position - mTransform.position));
			if (forward.y > 0f && !mIsBreaking)
			{
				forward.y *= -1f;
			}
			else
			{
				forward.y = 0f;
			}
			if (forward.sqrMagnitude > 0f)
			{
				mVertical = Quaternion.Slerp(mVertical, Quaternion.LookRotation(forward), (!mIsBreaking) ? (Time.deltaTime * 5f) : (Time.deltaTime * 2f));
			}
			if (mVel.sqrMagnitude > 0f && mSt.sqrMagnitude > 0f)
			{
				float num = mSt.magnitude / Time.deltaTime;
				mAnglePom = Mathf.Lerp(mAnglePom, GeometryTools.AngleSigned(mSt, mVel, Vector3.up), Time.deltaTime * 5f);
				Quaternion quaternion = Quaternion.AngleAxis(mAnglePom * multiplier * num, mVel);
				if ((!float.IsNaN(quaternion.x) && !float.IsNaN(quaternion.y)) || mIsBreaking)
				{
					mHorizontal = Quaternion.Slerp(mHorizontal, (!mIsBreaking) ? quaternion : Quaternion.identity, (!mIsBreaking) ? Time.deltaTime : (Time.deltaTime * 0.5f));
				}
			}
			mTransform.rotation = mHorizontal * mVertical;
		}
		else if (mRigidBody.isKinematic)
		{
			mPhotonTransform.Update(mTransform);
		}
	}

	protected float UpdateRealTimeDelta()
	{
		mRt = Time.realtimeSinceStartup;
		if (mTimeStarted)
		{
			float b = mRt - mTimeStart;
			mActual += Mathf.Max(0f, b);
			mTimeDelta = 0.001f * Mathf.Round(mActual * 1000f);
			mActual -= mTimeDelta;
			if (mTimeDelta > 1f)
			{
				mTimeDelta = 1f;
			}
			mTimeStart = mRt;
		}
		else
		{
			mTimeStarted = true;
			mTimeStart = mRt;
			mTimeDelta = 0f;
		}
		return mTimeDelta;
	}

	public Vector3 Steer()
	{
		float num = UpdateRealTimeDelta();
		Vector3 vector = mTargetPoint.position - mTransform.position;
		float magnitude = (mStopPoint.position - mTransform.position).magnitude;
		vector.Normalize();
		if (magnitude < breakDistance)
		{
			vector = mStopPoint.position - mTransform.position;
			vector.Normalize();
			vector *= breakSpeed * num * (magnitude / breakDistance);
			mIsBreaking = true;
			if (magnitude < 1f && !mIsStopped)
			{
				mIsStopped = true;
				StopPointReached();
			}
		}
		else
		{
			vector *= speed * num;
			mIsBreaking = false;
		}
		Vector3 vector2 = vector - mVel;
		float num2 = ((!mIsBreaking) ? mass : (mass * 0.2f));
		return vector2 / num2;
	}

	private void StopPointReached()
	{
		StartCoroutine(DeployEnemies());
		photonView.RPC("ShowRope", PhotonTargets.Others);
		ShowRope();
		if (base.hasSpecial)
		{
			InvokeAfter(SpawnAdditionalAssaulter, base.currentBeh.helicopterBehaviourDefinititon.special);
		}
	}

	private void SpawnAdditionalAssaulter()
	{
		if (isAlive)
		{
			SpawnAssaulter(enemyPoints[0], checkPoints: true);
			StartCoroutine(DeployEnemies(1f));
			InvokeAfter(SpawnAdditionalAssaulter, base.currentBeh.helicopterBehaviourDefinititon.special);
		}
	}

	[PunRPC]
	private void ShowRope()
	{
		Plane plane = new Plane(Vector3.up, PlayerController.currentPlayer.currentPlayerPoint.point.transform.position);
		Ray ray = new Ray(rope.transform.position, Vector3.down);
		Vector3 sourcePosition = rope.transform.position;
		if (plane.Raycast(ray, out var enter))
		{
			sourcePosition = ray.GetPoint(enter);
		}
		NavMesh.SamplePosition(sourcePosition, out var hit, 10f, 1);
		mRopeTargetPos = hit.position;
		mShowRope = true;
	}

	private IEnumerator DeployEnemies(float waitTime = 5f)
	{
		yield return new WaitForSeconds(waitTime);
		foreach (EnemyPointHelicopter enemyPointHelicopter in enemyPoints)
		{
			if (enemyPointHelicopter.enemyAtPoint != null)
			{
				EnemyController enemy = enemyPointHelicopter.enemyAtPoint as EnemyController;
				if (isAlive && enemy != null)
				{
					enemy.SpawnFromHelicopter();
				}
			}
			yield return new WaitForSeconds(2f);
		}
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> spawnPoints = Singleton<MapManager>.instance.currentMapDef.spawnPointsCollectionHelicopters.spawnPoints;
		List<SpawnPointHelicopter> list = new List<SpawnPointHelicopter>();
		foreach (SpawnPoint item in spawnPoints)
		{
			SpawnPointHelicopter spawnPointHelicopter = (SpawnPointHelicopter)item;
			if (spawnPointHelicopter.wayPointToJoin.path.usedByEntity == null && fraction == spawnPointHelicopter.fraction)
			{
				list.Add(spawnPointHelicopter);
			}
		}
		if (list.Count > 0)
		{
			int index = Random.Range(0, list.Count);
			SpawnPointHelicopter spawnPointHelicopter2 = list[index];
			base.transform.position = spawnPointHelicopter2.transform.position;
			base.transform.rotation = spawnPointHelicopter2.transform.rotation;
			SetWayPoint(spawnPointHelicopter2.wayPointToJoin);
			mStopPoint = spawnPointHelicopter2.wayPointToStop.transform;
		}
		else
		{
			Debug.LogError("Helicopter could not be spawned");
		}
		if (photonView.isMine)
		{
			for (int i = 0; i < base.currentBeh.helicopterBehaviourDefinititon.crew; i++)
			{
				EnemyPointHelicopter enemyPointHelicopter = enemyPoints[i];
				SpawnAssaulter(enemyPointHelicopter, checkPoints: false);
			}
			GenerateMachineGunner();
		}
	}

	private void SpawnAssaulter(EnemyPointHelicopter enemyPointHelicopter, bool checkPoints)
	{
		EnemyController enemyController = null;
		LevelBehaviour levelBehaviour = Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour;
		enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(levelBehaviour);
		if (enemyController != null)
		{
			List<EnemyPoint> points = SpawningManager.instance.GetPoints(EnemyPoint.EnemyPointType.Hiding, null, fraction);
			if (!checkPoints || points.Count > 0)
			{
				enemyController.DisableSpawn();
				int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
				enemyController.SpawnByCard((float)actualLevelForIndex / (float)behaviour.upgradeSlots.maxLevelOfUnit, behaviour.cardId);
				SpawningManager.instance.Spawn(enemyController, fraction, useEnergy: false, enemyPointHelicopter.position, startBehaviour: false);
				enemyPointHelicopter.enemyAtPoint = enemyController;
				enemyController.enemyPoint = enemyPointHelicopter;
				enemyController.StartEnemyBehaviour(EnemyController.EnemyAIState.Helicopter);
				enemyController.SetMaxHealthAndRefill(behaviour.upgradeSlots.GetSoldierHpInMechanic(unitUpgrades.slotUpgradeindex) * unitUpgrades.scaleHp);
			}
		}
	}

	private void GenerateMachineGunner()
	{
		soldier = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour);
		soldier.fraction = fraction;
		soldier.DisableSpawn();
		int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
		soldier.SpawnByCard((float)actualLevelForIndex / (float)behaviour.upgradeSlots.maxLevelOfUnit, behaviour.cardId);
		SpawningManager.instance.Spawn(soldier, fraction, useEnergy: false, enemyPointVehicle.transform.position, startBehaviour: false);
		enemyPointVehicle.enemyAtPoint = soldier;
		soldier.power = 0;
		soldier.enemyPoint = enemyPointVehicle;
		soldier.StartEnemyBehaviour(EnemyController.EnemyAIState.Vehicle);
		soldier.SetMaxHealthAndRefill(behaviour.upgradeSlots.GetSoldierHpInMechanic(unitUpgrades.slotUpgradeindex) * unitUpgrades.scaleHp);
		soldier.behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef - 1;
		soldier.Killed += EnemyAtTurretOnKilled;
		turret.enabled = true;
		turret.Reset();
	}

	private void EnemyAtTurretOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		soldier.Killed -= EnemyAtTurretOnKilled;
		soldier = null;
		turret.enabled = false;
		turret.Reset();
		InvokeAfter(GenerateMachineGunner, behaviour.upgradeSlots.soldierRespawnRate);
	}

	public override void DestroyPooled()
	{
		if (isPrewiev)
		{
			SetShadowsActive(value: true);
		}
		base.DestroyPooled();
		rope.ropeEnd.transform.localPosition = mRopeEndPos;
		if (soldier != null)
		{
			soldier.Killed -= EnemyAtTurretOnKilled;
			soldier.DestroyPooled();
		}
		ClearEnemyPoint(enemyPointVehicle, EnemyAtTurretOnKilled);
		if (path != null)
		{
			path.usedByEntity = null;
			path = null;
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = base.currentBeh.helicopterBehaviourDefinititon.health;
		mDestroyableObject.shotCoeficient = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		mDestroyableObject.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)turret.batchedWeapon.weapon.ammoSetup;
		bulletSetup.damageAmount = base.currentBeh.helicopterBehaviourDefinititon.damage;
		bulletSetup.speed = base.currentBeh.helicopterBehaviourDefinititon.shotSpeed;
		bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		turret.batchSizeMax = base.currentBeh.helicopterBehaviourDefinititon.fireBatchSizeMax;
		turret.batchSizeMin = base.currentBeh.helicopterBehaviourDefinititon.fireBatchSizeMin;
		turret.minShootTime = base.currentBeh.helicopterBehaviourDefinititon.minShootTime;
		turret.maxShootTime = base.currentBeh.helicopterBehaviourDefinititon.maxShootTime;
		turret.realShotProbability = base.currentBeh.helicopterBehaviourDefinititon.probabilityOfRealShot;
		speed = base.currentBeh.helicopterBehaviourDefinititon.speed;
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (isPrewiev)
		{
			GeneratePreviewEnemy(Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour, enemyPointVehicle, disableWeapon: true);
			for (int i = 0; i < base.currentBeh.helicopterBehaviourDefinititon.crew; i++)
			{
				EnemyPointHelicopter point = enemyPoints[i];
				LevelBehaviour beh = Singleton<LevelBehaviourManager>.instance.levelBehaviours[0].behaviour;
				GeneratePreviewEnemy(beh, point, disableWeapon: false);
			}
			mRigidBody.isKinematic = true;
		}
		SetShadowsActive(value: false);
		ParticleSystem[] array = particles;
		foreach (ParticleSystem particleSystem in array)
		{
			particleSystem.gameObject.SetActive(value: false);
		}
	}

	protected override void SetupCollisionLayers(Fractions fraction)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(fraction, isFlying: true);
		}
	}

	public override void DoReverseAnim()
	{
		base.DoReverseAnim();
		TweenPosition.Begin(base.gameObject, 2f, base.gameObject.transform.position + Vector3.up * 1.5f);
	}
}
