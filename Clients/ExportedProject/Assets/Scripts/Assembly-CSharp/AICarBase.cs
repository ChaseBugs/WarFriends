using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class AICarBase<T> : Vehicle<T> where T : LevelBehaviour
{
	public enum BrakeCondition
	{
		TargetDirectionDifference,
		Stop
	}

	[SerializeField]
	[Range(0f, 1f)]
	private float cautiousSpeedFactor = 0.05f;

	[SerializeField]
	[Range(0f, 180f)]
	private float cautiousMaxAngle = 50f;

	[SerializeField]
	private float cautiousMaxDistance = 100f;

	[SerializeField]
	private float cautiousAngularVelocityFactor = 30f;

	[SerializeField]
	private float steerSensitivity = 0.05f;

	[SerializeField]
	private float accelSensitivity = 0.04f;

	[SerializeField]
	private float brakeSensitivity = 1f;

	[SerializeField]
	protected BrakeCondition brakeCondition;

	[SerializeField]
	protected bool mDriving;

	[SerializeField]
	private Transform target;

	[SerializeField]
	private bool stopWhenTargetReached;

	[SerializeField]
	private float reachTargetThreshold = 2f;

	public PhysicsEventsListener frontTrigger;

	public Transform finalTransform;

	public SpawnPointVehicle spawnedFrom;

	public GameObject obstacleCollider;

	public EnemyPointVehicle enemyPointVehicle;

	protected CarController carController;

	private Rigidbody mRigidbody;

	private float mWantedAccel;

	private float mWantedSteer;

	private float mSteer;

	private float mAccel;

	protected DestroyableObjectMultipleParts mDestroyableObject;

	protected Transform mTransform;

	protected Quaternion mStartRotation;

	private readonly PhotonTransform mPhotonTransform = new PhotonTransform();

	private bool mEnemySeen;

	private float mEnemySeenTime;

	public override DestroyableObject destroyableObj => mDestroyableObject;

	public override void SafeStart()
	{
		base.SafeStart();
		obstacleCollider.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	protected override void Awake()
	{
		base.Awake();
		carController = GetComponent<CarController>();
		mRigidbody = GetComponent<Rigidbody>();
		PhysicsEventsListener physicsEventsListener = frontTrigger;
		physicsEventsListener.onTriggerStay = (Action<Collider>)Delegate.Combine(physicsEventsListener.onTriggerStay, new Action<Collider>(OnFrontTriggerStay));
		UnityEngine.Object.DontDestroyOnLoad(obstacleCollider);
		mDestroyableObject = GetComponent<DestroyableObjectMultipleParts>();
		mDestroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		mTransform = base.transform;
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		CarController obj = carController;
		T val = base.currentBeh;
		obj.MaxSpeed = val.behaviourDefinition.speed;
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject arg1, DestroyableObject.DamageInfo arg2)
	{
		if (isAlive)
		{
			Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position - base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position + base.transform.up * 0.2f, Vector3.up, "metalExplosion", "grenadeExplosion");
			OnKilled(arg2);
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = base.transform.position;
			explosionInfo.explodeDamage = 350f;
			explosionInfo.damageAmount = 40f;
			explosionInfo.owner = this;
			explosionInfo.isNetworkCopy = !photonView.isMine;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.Explode(i);
			DestroyEntity(0.2f);
		}
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (inGame)
		{
			carController.rigidBody.freezeRotation = true;
			carController.rigidBody.velocity = Vector3.zero;
			carController.rigidBody.isKinematic = false;
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		mPhotonTransform.Reset();
	}

	private void OnFrontTriggerStay(Collider collider)
	{
		if (TagsAndLayers.IsDestroyableObject(collider.gameObject) && brakeCondition == BrakeCondition.TargetDirectionDifference)
		{
			DestroyableObjectpart component = collider.GetComponent<DestroyableObjectpart>();
			if (component != null)
			{
				mEnemySeen = true;
				mEnemySeenTime = Time.time;
			}
		}
	}

	private void FixedUpdate()
	{
		if (isPrewiev)
		{
			if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
			{
				carController.Move(0f, 0.1f);
			}
			else if (mDoReverseAnim)
			{
				carController.Move(0f, -0.6f);
			}
			else
			{
				carController.HandBrake(stopSpin: true);
			}
			return;
		}
		if (photonView.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Drive();
		}
		if (!photonView.isMine && Singleton<PhotonConnectionManager>.instance.isClient)
		{
			mRigidbody.isKinematic = true;
			if (mWantedAccel > 0f)
			{
				carController.Move(mWantedSteer, mWantedAccel);
			}
			else
			{
				carController.HandBrake(stopSpin: false);
			}
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				mPhotonTransform.Update(mTransform);
			}
		}
	}

	private void Drive()
	{
		if (brakeCondition == BrakeCondition.Stop)
		{
			carController.HandBrake(stopSpin: true);
			mAccel = 0f;
		}
		if (target == null || !mDriving)
		{
			carController.HandBrake(stopSpin: true);
			mAccel = 0f;
			return;
		}
		Vector3 to = mTransform.forward;
		if (mRigidbody.velocity.magnitude > carController.MaxSpeed * 0.1f)
		{
			to = mRigidbody.velocity;
		}
		float num = carController.MaxSpeed;
		switch (brakeCondition)
		{
		case BrakeCondition.TargetDirectionDifference:
		{
			float b = Vector3.Angle(target.forward, to);
			float a = mRigidbody.angularVelocity.magnitude * cautiousAngularVelocityFactor;
			float t = Mathf.InverseLerp(0f, cautiousMaxAngle, Mathf.Max(a, b));
			num = Mathf.Lerp(carController.MaxSpeed, carController.MaxSpeed * cautiousSpeedFactor, t);
			break;
		}
		case BrakeCondition.Stop:
			if (carController.CurrentSpeed < 0.001f)
			{
				mDriving = false;
				obstacleCollider.gameObject.SetActive(value: true);
				obstacleCollider.transform.position = mTransform.position;
				obstacleCollider.transform.rotation = mTransform.rotation;
				isParked = true;
			}
			mAccel = 0f;
			carController.HandBrake(stopSpin: true);
			return;
		}
		Vector3 position = target.position;
		if (brakeCondition == BrakeCondition.Stop)
		{
			if (finalTransform == null)
			{
				return;
			}
			position = finalTransform.position;
		}
		if (mEnemySeen)
		{
			if (Time.time > mEnemySeenTime + 1f)
			{
				mEnemySeen = false;
			}
			else
			{
				num = Mathf.Lerp(-1f, 0f, mEnemySeenTime - Time.time);
			}
		}
		float num2 = ((!(num < carController.CurrentSpeed)) ? accelSensitivity : brakeSensitivity);
		mAccel = Mathf.Clamp((num - carController.CurrentSpeed) * num2, -1f, 1f);
		Vector3 vector = mTransform.InverseTransformPoint(position);
		float num3 = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		mSteer = Mathf.Clamp(num3 * steerSensitivity, -1f, 1f) * Mathf.Sign(carController.CurrentSpeed);
		carController.Move(mSteer, mAccel);
		if (!(finalTransform == null) && stopWhenTargetReached && (mTransform.position - finalTransform.position).magnitude < reachTargetThreshold && brakeCondition != BrakeCondition.Stop)
		{
			brakeCondition = BrakeCondition.Stop;
		}
	}

	protected override void Update()
	{
		base.Update();
	}

	protected virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			stream.SendNext(mAccel);
			stream.SendNext(mSteer);
			stream.SendNext((byte)fraction);
		}
		else
		{
			mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			mWantedAccel = (float)stream.ReceiveNext();
			mWantedSteer = (float)stream.ReceiveNext();
			fraction = (Fractions)(byte)stream.ReceiveNext();
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		StopAllCoroutines();
		T val = base.currentBeh;
		mPower = val.totalPower;
		mDriving = false;
		mRigidbody.isKinematic = isPrewiev;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if (spawnedFrom != null)
		{
			spawnedFrom.usedByEntity = null;
			spawnedFrom = null;
		}
		obstacleCollider.gameObject.SetActive(value: false);
		finalTransform = null;
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.circuit = null;
	}

	public void SetTarget(WaypointCircuit circuit, Transform finaLPosition)
	{
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.Reset();
		component.circuit = circuit;
		finalTransform = finaLPosition;
		mDriving = true;
		brakeCondition = BrakeCondition.TargetDirectionDifference;
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
		int index = UnityEngine.Random.Range(0, list.Count);
		spawnedFrom = list[index];
		mTransform.position = spawnedFrom.transform.position;
		mStartRotation = Quaternion.LookRotation(spawnedFrom.waypointCircuit.Waypoints[0].transform.position - spawnedFrom.transform.position);
		mTransform.rotation = mStartRotation;
		spawnedFrom.usedByEntity = this;
	}

	protected void ChangeWheels(float targetPos, float susDistance)
	{
		Wheel[] wheels = carController.wheels;
		foreach (Wheel wheel in wheels)
		{
			JointSpring suspensionSpring = wheel.wheelCollider.suspensionSpring;
			suspensionSpring.targetPosition = targetPos;
			suspensionSpring.spring = 400f;
			suspensionSpring.damper = 9f;
			wheel.wheelCollider.suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = susDistance;
		}
	}

	[PunRPC]
	public override void ReSyncRPC(byte fr, Vector3 positon, Quaternion rotation, UpgradeSlots.UnitUpgrades upgrades, bool spawnedByCard, float progress, string cardId)
	{
		base.ReSyncRPC(fr, positon, rotation, upgrades, spawnedByCard, progress, cardId);
		mPhotonTransform.AddNewState(PhotonNetwork.time, positon, rotation);
	}

	protected override void SetupCollisionLayers(Fractions fraction)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(fraction, isFlying: true);
		}
	}
}
