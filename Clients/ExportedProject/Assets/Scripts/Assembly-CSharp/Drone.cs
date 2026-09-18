using System;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MechanicalUnit<DroneBehaviour>, IMechanicalUnit
{
	public GameObject eliteDrone;

	public ParticleSystem fireDamage;

	public GameObject normalDrone;

	public Material normalMaterial;

	public Material transparentMaterial;

	public BatchedWeapon weapon;

	private DestroyableObject mDestroyableObject;

	private DroneSteering mDroneSteering;

	private bool mExploded;

	private Transform mTransform;

	private GameShootableEntity target;

	private float mNextShotTime;

	private float mInvisibleLength;

	private bool mIsInvisible;

	private float mNextInvisibleTime;

	public override DestroyableObject destroyableObj => mDestroyableObject;

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = GetComponent<DestroyableObject>();
		mDestroyableObject.isMetal = true;
		mDestroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		mDestroyableObject.OnDamage += DestroyableObjectOnOnDamage;
		weapon.weapon.owner = this;
		mTransform = base.transform;
		normalMaterial = visuals.mainRenderer.material;
		mDroneSteering = GetComponent<DroneSteering>();
	}

	private void DestroyableObjectOnOnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if ((double)mDestroyableObject.healthRatio < 0.4)
		{
			fireDamage.Play();
		}
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		mDroneSteering.Clear();
		mDroneSteering.FallDown();
		OnKilled(damageInfo);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!isAlive && !mExploded)
		{
			Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateHeavy);
			mExploded = true;
			DestroyEntity(0.2f);
			Debug.Log("Drone explode");
			Singleton<HitParticleSystem>.instance.PlayParticles(mTransform.position, Vector3.up, "metalExplosion", "grenadeExplosion");
			Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
			explosionInfo.position = base.transform.position;
			explosionInfo.explodeDamage = destroyableObj.maxHealth * 0.5f;
			explosionInfo.damageAmount = destroyableObj.maxHealth * 0.05f;
			explosionInfo.owner = this;
			explosionInfo.isNetworkCopy = !photonView.isMine;
			explosionInfo.deadRadius = 0.7f;
			explosionInfo.hurtRadius = 1.4f;
			Explosion.ExplosionInfo i = explosionInfo;
			Explosion.MissileExplode(i);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		mDroneSteering.Init();
		fireDamage.Stop();
		isAlive = true;
		eliteDrone.SetActive(base.spawnedByCard);
		normalDrone.SetActive(!base.spawnedByCard);
		StopAllCoroutines();
		mPower = behaviour.totalPower;
		mNextShotTime = Time.time + 2f;
		mExploded = false;
		mNextInvisibleTime = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(5f, 10f);
		SetTransparent(isTransparent: false);
	}

	protected Ammo.ShotType GetShotType(GameShootableEntity.ShotTarget target)
	{
		if (target.type == GameShootableEntity.ShotTargetType.Shield)
		{
			return Ammo.ShotType.Shield;
		}
		return Ammo.ShotType.Real;
	}

	private void Shooting()
	{
	}

	protected override void Start()
	{
		base.Start();
		fireDamage.Stop();
	}

	public void SetWayPoint(WayPoint point)
	{
		mDroneSteering.SetWayPoint(point, this);
	}

	[PunRPC]
	protected void SetTransparent(bool isTransparent)
	{
		if (photonView.isMine)
		{
			photonView.RPC("SetTransparent", PhotonTargets.Others, isTransparent);
		}
		mIsInvisible = isTransparent;
		if (isTransparent)
		{
			visuals.ChangeMaterial(transparentMaterial);
		}
		else
		{
			visuals.ChangeMaterial(normalMaterial);
		}
	}

	protected override void Update()
	{
		base.Update();
		if (isPrewiev)
		{
			mIsInvisible = false;
			mNextInvisibleTime = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(3f, 5f);
		}
		else
		{
			if (!photonView.isMine || !isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.gameIsRunning)
			{
				if (!mIsInvisible)
				{
					if (TimeManager.realTimeWithoutPauses > mNextInvisibleTime)
					{
						SetTransparent(isTransparent: true);
						destroyableObj.isImmortal = true;
						mInvisibleLength = base.currentBeh.droneBehaviourDefinition.special + UnityEngine.Random.Range(0f, 1f);
					}
				}
				else if (TimeManager.realTimeWithoutPauses > mNextInvisibleTime + mInvisibleLength)
				{
					destroyableObj.isImmortal = false;
					SetTransparent(isTransparent: false);
					mNextInvisibleTime = TimeManager.realTimeWithoutPauses + (10f - base.currentBeh.droneBehaviourDefinition.special) + UnityEngine.Random.Range(0f, 1f);
				}
			}
			if (Time.time > mNextShotTime)
			{
				PickTarget();
				StartShooting();
				mNextShotTime += UnityEngine.Random.Range(base.currentBeh.droneBehaviourDefinition.minShootTime, base.currentBeh.droneBehaviourDefinition.maxShootTime);
			}
		}
	}

	private void StartShooting()
	{
		if (target == null)
		{
			return;
		}
		float num = float.MaxValue;
		GameShootableEntity.ShotTarget shotTarget = null;
		foreach (GameShootableEntity.ShotTarget shotTarget2 in target.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn))
		{
			float num2 = Vector3.Distance(base.transform.position, shotTarget2.transform.position);
			if (num2 < num && shotTarget2.type != GameShootableEntity.ShotTargetType.Out)
			{
				shotTarget = shotTarget2;
				num = num2;
			}
		}
		PlayerController playerController = target.owner as PlayerController;
		if (playerController != null)
		{
			float num3 = Vector3.Angle(playerController.aimForward, mTransform.position - target.mTransform.position);
			if (base.currentBeh.upgradeSlots.shieldHitProbability >= 0f)
			{
				Shoot(t: (!(num3 < 50f) || !(UnityEngine.Random.value > base.currentBeh.upgradeSlots.shieldHitProbability) || playerController.playerState != PlayerController.PlayerStatex.HidingBehindShield) ? target.GetNearestTarget(GameShootableEntity.ShotTargetType.Shield, mTransform.position) : target.GetNearestTarget(GameShootableEntity.ShotTargetType.WholeBody, mTransform.position), velocity: Vector3.zero);
			}
		}
		else if (shotTarget != null)
		{
			Shoot(shotTarget.shootableEntity.velocity, shotTarget);
		}
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		if (isPrewiev)
		{
			mDroneSteering.Init();
			mDroneSteering.enabled = false;
		}
	}

	private void Shoot(Vector3 velocity, GameShootableEntity.ShotTarget t)
	{
		int batchSize = UnityEngine.Random.Range(base.currentBeh.droneBehaviourDefinition.fireBatchSizeMin, base.currentBeh.droneBehaviourDefinition.fireBatchSizeMax);
		Ammo.ShotType shotType = Ammo.GetShotType(t);
		Vector3 position = t.transform.position;
		position = Singleton<AimingHelper>.instance.PredictPosition(weapon.weapon, position, velocity, 0f);
		float probabilityOfRealShot = base.currentBeh.droneBehaviourDefinition.probabilityOfRealShot;
		weapon.ShootBatch(t, position, batchSize, probabilityOfRealShot, shotType);
	}

	private void PickTarget()
	{
		target = null;
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, new Type[1] { typeof(Decoy) });
		foreach (GameShootableEntity item in opponents)
		{
			if (CanSeeTarget(item.transform.position))
			{
				target = item;
				break;
			}
		}
		if (target == null)
		{
			opponents = GameShootableEntity.GetOpponents(fraction, LevelBehaviour.UnitType.AttackerRusher);
			foreach (GameShootableEntity item2 in opponents)
			{
				if (CanSeeTarget(item2.transform.position))
				{
					target = item2;
					break;
				}
			}
		}
		if (target == null)
		{
			opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.anyUnit);
			foreach (GameShootableEntity item3 in opponents)
			{
				if (CanSeeTarget(item3.transform.position))
				{
					target = item3;
					break;
				}
			}
		}
		if (target == null)
		{
			opponents = GameShootableEntity.GetOpponents(fraction);
			foreach (GameShootableEntity item4 in opponents)
			{
				if (CanSeeTarget(item4.transform.position))
				{
					target = item4;
					break;
				}
			}
		}
		weapon.weapon.SetBullletSpeedCoef((!(target != null) || !(target.owner is PlayerController)) ? 1f : 0.5f);
		mDroneSteering.lookTarget = ((!(target == null)) ? target.mTransform : null);
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> spawnPoints = Singleton<MapManager>.instance.currentMapDef.spawnPointsCollectionDrones.spawnPoints;
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
			int index = ((list.Count > 2) ? UnityEngine.Random.Range(0, 2) : 0);
			SpawnPointDrone spawnPointDrone2 = list[index];
			base.transform.position = spawnPointDrone2.transform.position;
			SetWayPoint(spawnPointDrone2.pointToJoin);
		}
		else
		{
			Debug.LogError("Dron could not be spawned");
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		mDroneSteering.Clear();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = base.currentBeh.droneBehaviourDefinition.health;
		mDestroyableObject.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)weapon.weapon.ammoSetup;
		bulletSetup.damageAmount = base.currentBeh.droneBehaviourDefinition.damage;
		bulletSetup.speed = base.currentBeh.droneBehaviourDefinition.shotSpeed;
		bulletSetup.damageToPlayerCoeficient = behaviour.upgradeSlots.playerDamageRatio;
		bulletSetup.damageToPlayerOvertimeCoeficient = behaviour.upgradeSlots.playerDamageOvertimeRatio;
		mDroneSteering.speed = base.currentBeh.droneBehaviourDefinition.speed;
	}

	protected override void SetupCollisionLayers(Fractions fraction)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(fraction, isFlying: true);
		}
	}

	public void DoReverseAnim()
	{
		TweenPosition.Begin(base.gameObject, 2f, base.gameObject.transform.position - base.gameObject.transform.right * 1.5f + Vector3.up);
	}
}
