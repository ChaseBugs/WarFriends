using UnityEngine.AI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AIObjectG<SoldierBehaviour>, IFraction, IGameMainEntity, ICharacter
{
	public enum EnemyAIState
	{
		Walk,
		Idle,
		ObstacleHiding,
		CornerHiding,
		Rusher,
		Vehicle,
		Parachute,
		Helicopter,
		Swat,
		MachineGunPoint,
		Minigunner,
		EngineerTurret,
		EngineerRepair,
		Fly,
		RusherSpare,
		Gunslinger,
		Mortar,
		Warp
	}

	private enum HeliPhase
	{
		Driving,
		Spawning,
		Spawned,
		Falling
	}

	public NavigationAgent agent;

	public DestroyableObjectMultipleParts destroyableObject;

	public Kevlar kevlar;

	public UnitShield shield;

	public EnemyPoint enemyPoint;

	public bool isHeadShot;

	public SoldierParts soldierParts;

	[SerializeField]
	private DestroyableObject mShield;

	[SerializeField]
	public SoldierAnimationController mSoldierAnimationController;

	[SerializeField]
	private SoldierMeshChanger mSoldierSoldierMeshChanger;

	public Transform mTransform;

	private bool mCanDie = true;

	private bool mIsShooting;

	private float mNextShootTime;

	private bool mCanShootWalk = true;

	public EnemyAIState enemyAiState;

	public HeadSizeSetter headSizeSetter;

	private Material mMyMaterial;

	private float mBuildTurretEndTime;

	private bool mCanShoot;

	public bool mExploded;

	private bool mFlyInit;

	private float mGoBackTimer;

	private HeliPhase mHeliPhase;

	private bool mIsCovered;

	private bool mIsGoingBack;

	private bool mIsRunning;

	private float mLastPosion;

	private float mMakeBUlletInvisibleTime;

	private float mProgress;

	private float mRepairTimer;

	private bool mSetStateAndSTarted;

	private float mStayTime;

	private float maxStayTime = 5f;

	private SoldierProperties mSoldierProperties = new SoldierProperties();

	private float mTime;

	private int mSyncTime;

	private bool mLanded;

	private Parachute mParachute;

	private float mPlayerOutOfRangeTime;

	private bool mCoverShotRight;

	private bool mIsHidingBehindCorner;

	public bool canChangePosition = true;

	private EnemyPointHelicopter mHeliPoint;

	private bool mIsCrawling;

	public bool mIsNetworkCopy;

	private List<GameObject> mJoints;

	private float mNextEnemyChangeTime;

	private float mPositionChangeTime;

	private bool mWillShoot;

	private float mHeliStartYPos;

	private float mHeliEndYPos;

	private bool mIsStartAnim;

	private Vector3 mStartAnimTargetPos;

	private int mShotsRemaining;

	private Vector3 mMortarStopPosition;

	private PlayerPoint mCurrentPlayerDefPos;

	private double mInterpolationBackTime = 0.18;

	private PhotonTransform mPhotonTransform = new PhotonTransform();

	private bool mSide;

	private int mNrOfWarps = 4;

	private float mWalkStartTime;

	public bool canBeFreezed => enemyAiState != EnemyAIState.Vehicle && enemyAiState != EnemyAIState.Helicopter && enemyAiState != EnemyAIState.MachineGunPoint;

	private bool mTargetReached => enemyAiState == EnemyAIState.ObstacleHiding || enemyAiState == EnemyAIState.CornerHiding || enemyAiState == EnemyAIState.Rusher || enemyAiState == EnemyAIState.Swat || enemyAiState == EnemyAIState.MachineGunPoint || enemyAiState == EnemyAIState.Minigunner || enemyAiState == EnemyAIState.EngineerTurret || enemyAiState == EnemyAIState.RusherSpare;

	public bool allowShoot
	{
		set
		{
			mCanShoot = value;
		}
	}

	public bool isCovered => mIsCovered;

	public bool isRunning => mIsRunning;

	public override DestroyableObject destroyableObj => destroyableObject;

	public int rusherCounts
	{
		get
		{
			int num = 0;
			foreach (MapDefinition.DefendPosition playersPosition in Singleton<MapManager>.instance.currentMapDef.playersPositions)
			{
				if (playersPosition.fraction == fraction)
				{
					continue;
				}
				foreach (EnemyPointRusher rusherPoint in playersPosition.point.rusherPoints)
				{
					if (!rusherPoint.isFree)
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	public new bool isInField => Singleton<MapManager>.instance.currentMapDef != null && Singleton<MapManager>.instance.currentMapDef.fieldArea != null && Singleton<MapManager>.instance.currentMapDef.fieldArea.bounds.Contains(base.transform.position);

	public SoldierBehaviour soldierBehaviour => (SoldierBehaviour)behaviour;

	public SpawnPoint spawnPoint { get; set; }

	public SoldierMeshChanger meshChanger => mSoldierSoldierMeshChanger;

	public string[] playerVisuals
	{
		get
		{
			return mSoldierProperties.visuals;
		}
		set
		{
			mSoldierProperties.visuals = value;
		}
	}

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo
	{
		get
		{
			return mSoldierProperties.equippedCamo;
		}
		set
		{
			mSoldierProperties.equippedCamo = value;
		}
	}

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet
	{
		get
		{
			return mSoldierProperties.equippedHelmet;
		}
		set
		{
			mSoldierProperties.equippedHelmet = value;
		}
	}

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory
	{
		get
		{
			return mSoldierProperties.equippedHeadAccesory;
		}
		set
		{
			mSoldierProperties.equippedHeadAccesory = value;
		}
	}

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand
	{
		get
		{
			return mSoldierProperties.equippedPowerBand;
		}
		set
		{
			mSoldierProperties.equippedPowerBand = value;
		}
	}

	public bool canDie
	{
		set
		{
		}
	}

	public event Action<EnemyController> onShoot;

	protected override void Awake()
	{
		base.Awake();
		destroyableObject.OnDeath += OnDeath;
		destroyableObject.OnDamage += OnDamage;
		mTransform = base.transform;
		fraction = Fractions.None;
		GameShootableEntity component = GetComponent<GameShootableEntity>();
	}

	private void OnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (base.gameObject.activeInHierarchy && damageInfo.type == DestroyableObject.DamageType.Poison)
		{
			hudObjectIndicator.Show("game-ico-poison", value: true, HudObjectIndicator.IndicatorAnimation.InfoIco);
			mLastPosion = mTime;
		}
	}

	private void OnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (!isAlive)
		{
			return;
		}
		if (headSizeSetter != null)
		{
			headSizeSetter.scaleF = 1f;
		}
		Freeze(freeze: false);
		Crittercism.LeaveBreadcrumb("OnDeath Freeze enemy");
		try
		{
			hudObjectIndicator.RemoveAllIconExceptDeathIco();
			mMakeBUlletInvisibleTime = mTime + 0.2f;
			soldierBehaviour.OnDeath(damageInfo);
			if (damageInfo.type == DestroyableObject.DamageType.Explosion && !mExploded)
			{
				mExploded = true;
				soldierParts.MakeTrigger(value: false);
				mSoldierAnimationController.SampleDead();
				if (enemyAiState == EnemyAIState.ObstacleHiding && mIsCrawling)
				{
					mSoldierAnimationController.SampleStand();
				}
				else
				{
					mSoldierAnimationController.Stop();
				}
				GetComponentInChildren<Animation>().enabled = false;
				soldierParts.EnableRagdol(wasHeadshot: false);
				Vector3 vector = new Vector3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
				soldierParts.body.GetComponent<Rigidbody>().AddForce(damageInfo.force, ForceMode.VelocityChange);
				soldierParts.body.GetComponent<Rigidbody>().AddTorque(vector.x, vector.y, vector.z);
				soldierParts.mWeaponRigidBodySwapper.RigidBodyObject.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(5f, 15f), ForceMode.VelocityChange);
				soldierParts.mWeaponRigidBodySwapper.RigidBodyObject.GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
			}
			else
			{
				isHeadShot = damageInfo.partIndex == 1 && damageInfo.type == DestroyableObject.DamageType.Shot;
				PlayShotRagdoll(damageInfo);
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
		Crittercism.LeaveBreadcrumb("OnDeath On Killed");
		OnKilled(damageInfo);
		agent.Disable();
		mSoldierAnimationController.Stop();
		mIsShooting = false;
		agent.enabled = false;
		InvokeAfter(HideUnderGround, UnityEngine.Random.Range(2f, 3f));
		ClearEnemyPoint();
		if (mParachute != null)
		{
			mParachute.Landed = null;
			mParachute = null;
		}
		Crittercism.LeaveBreadcrumb("OnDeath End");
	}

	public void PlayShotRagdoll(DestroyableObject.DamageInfo damageInfo)
	{
		soldierParts.MakeTrigger(value: false);
		mSoldierAnimationController.SampleDead();
		GetComponentInChildren<Animation>().enabled = false;
		soldierParts.EnableRagdol(isHeadShot);
		soldierParts.body.GetComponent<Rigidbody>().GetComponent<Rigidbody>().AddForce(damageInfo.force, ForceMode.VelocityChange);
		soldierParts.mWeaponRigidBodySwapper.RigidBodyObject.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(0.5f, 2f), ForceMode.VelocityChange);
		soldierParts.mWeaponRigidBodySwapper.RigidBodyObject.GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
		if (isHeadShot)
		{
			soldierParts.helmett.RigidBodyObject.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(1f, 3f) + damageInfo.force * 1.5f, ForceMode.VelocityChange);
		}
	}

	public void ClearEnemyPoint()
	{
		if (enemyPoint != null)
		{
			enemyPoint.enemyAtPoint = null;
			enemyPoint = null;
		}
	}

	private void HideUnderGround()
	{
		hudObjectIndicator.Disable();
		soldierParts.SetAllRigidBodiesToKinematic(value: true);
		TweenPosition.Begin(base.gameObject, 1f, base.transform.position, base.transform.position - Vector3.up, useLocal: false);
		DestroyEntity(1f);
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		mCanShoot = true;
		mPower = soldierBehaviour.totalPower;
		agent.Reset();
		agent.Disable();
		soldierParts.SetAllRigidBodiesToKinematic(value: true);
		mTime = Time.time;
		mPhotonTransform.Reset();
		StopAllCoroutines();
		SkinnedMeshRenderer componentInChildren = GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null && mMyMaterial != null)
		{
			componentInChildren.material = mMyMaterial;
		}
		kevlar.ClearKevlar();
		shield.ClearShield();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (headSizeSetter != null)
		{
			headSizeSetter.scaleF = 1f;
		}
		if (soldierBehaviour != null)
		{
			soldierBehaviour.Restart();
		}
		else
		{
			Debug.LogError("soldier behaviour is null !!!!");
		}
		mSoldierAnimationController.Reset();
		soldierParts.MakeTrigger(value: false);
		soldierParts.MakeCollidersBulletVisible();
		soldierParts.DisableJetPackParticles();
		mIsStartAnim = false;
		destroyableObject.ResetWeights();
		destroyableObject.RefillOffline();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		enemyAiState = EnemyAIState.Walk;
		mIsShooting = false;
		mExploded = false;
		isHeadShot = false;
		mIsCrawling = false;
		mPlayerOutOfRangeTime = 0f;
		mHeliPhase = HeliPhase.Spawning;
		mWillShoot = false;
		mLastPosion = 0f;
		mMakeBUlletInvisibleTime = 0f;
		mCanDie = true;
		canChangePosition = true;
		mCanShootWalk = true;
		if (photonView.isMine)
		{
			mIsNetworkCopy = false;
			agent.enabled = true;
		}
		else
		{
			mIsNetworkCopy = true;
			agent.enabled = false;
		}
		if (isPrewiev && soldierBehaviour != null)
		{
			mSoldierAnimationController.Idle(soldierBehaviour.currentWeapon.weaponType);
		}
	}

	public void StartEnemyBehaviour(EnemyAIState switchState)
	{
		mSetStateAndSTarted = false;
		enemyAiState = switchState;
		base.StartEnemyBehaviour();
		if (!mSetStateAndSTarted)
		{
			switch (switchState)
			{
			case EnemyAIState.Helicopter:
				SwitchState(EnemyAIState.Helicopter);
				ShadowSetActive(value: false);
				break;
			case EnemyAIState.Vehicle:
				SwitchState(EnemyAIState.Vehicle);
				ShadowSetActive(value: false);
				break;
			case EnemyAIState.Parachute:
				StopAllCoroutines();
				SwitchState(EnemyAIState.Parachute);
				ShadowSetActive(value: false);
				break;
			case EnemyAIState.Fly:
				StopAllCoroutines();
				SwitchState(EnemyAIState.Fly);
				ShadowSetActive(value: false);
				break;
			case EnemyAIState.Warp:
				StopAllCoroutines();
				SwitchState(EnemyAIState.Warp);
				break;
			default:
				Walk();
				GenerateInitPoint();
				break;
			}
		}
	}

	public void SetStateTo(EnemyAIState switchState, EnemyPoint target)
	{
		enemyAiState = switchState;
		if (switchState == EnemyAIState.Walk)
		{
			Walk();
			GenerateInitPoint(target);
		}
		mSetStateAndSTarted = true;
	}

	public void StartEnemyBehaviour(EnemyAIState switchState, EnemyPoint target)
	{
		base.StartEnemyBehaviour();
		SetStateTo(switchState, target);
	}

	public override void StartEnemyBehaviour()
	{
		soldierBehaviour.StartEnemyBehaviour();
	}

	private bool GenerateInitPoint(EnemyPoint point = null)
	{
		EnemyPoint initPoint = soldierBehaviour.GetInitPoint();
		if (point == null)
		{
			if (initPoint != null)
			{
				SetFinalTarget(initPoint);
				SwitchState(EnemyAIState.Walk);
			}
			else
			{
				InvokeAfter(delegate
				{
					GenerateInitPoint();
				}, 5f);
			}
			return false;
		}
		SetFinalTarget(point);
		return true;
	}

	public void SetFinalTarget(EnemyPoint target)
	{
		if (!(target == null))
		{
			if (enemyPoint != null)
			{
				enemyPoint.enemyAtPoint = null;
			}
			enemyPoint = target;
			if (enemyPoint.enemyAtPoint != null && enemyPoint.enemyAtPoint != this)
			{
				Debug.LogError("enemy point is not free");
			}
			enemyPoint.enemyAtPoint = this;
			target.GeneratePosition();
			agent.SetDestination(enemyPoint.position);
			agent.Resume();
			agent.stoppingDistance = 0f;
		}
	}

	protected override void Update()
	{
		base.Update();
		mTime += Time.deltaTime;
		if (mIsStartAnim)
		{
			StartAnimUpdate();
		}
		if (isPrewiev || Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			return;
		}
		if (mTime > mMakeBUlletInvisibleTime && mMakeBUlletInvisibleTime != 0f)
		{
			soldierParts.SoldierDeath();
			mBuildTurretEndTime = 0f;
		}
		if (!isAlive)
		{
			return;
		}
		if (mLastPosion != 0f && mTime > mLastPosion + 2.5f)
		{
			Debug.Log("Hide poison");
			hudObjectIndicator.Show("game-ico-poison", value: false, HudObjectIndicator.IndicatorAnimation.InfoIco);
			mLastPosion = 0f;
		}
		if (photonView.isMine && !mIsNetworkCopy)
		{
			mIsCovered = mIsCrawling || (enemyAiState == EnemyAIState.CornerHiding && mIsHidingBehindCorner);
			mIsRunning = enemyAiState == EnemyAIState.Walk && agent.velocity.sqrMagnitude > agent.speed * agent.speed * 0.9f;
			if (isAlive)
			{
				ShootingFromWeapon();
				if (enemyPoint != null && enemyPoint.enemyAtPoint != this)
				{
					Debug.LogError("bad enemy point");
				}
				switch (enemyAiState)
				{
				case EnemyAIState.Walk:
					WalkingUpdate();
					break;
				case EnemyAIState.ObstacleHiding:
					ObstacleHidingUpdate();
					break;
				case EnemyAIState.CornerHiding:
					CornerHidingUpdate();
					break;
				case EnemyAIState.Rusher:
					RusherUpdate();
					break;
				case EnemyAIState.RusherSpare:
					RusherSpareUpdate();
					break;
				case EnemyAIState.Swat:
					SwatUpdate();
					break;
				case EnemyAIState.Vehicle:
					VehicleUpdate();
					break;
				case EnemyAIState.Parachute:
					ParachuteUpdate();
					break;
				case EnemyAIState.Helicopter:
					HelicopterUpdate();
					break;
				case EnemyAIState.MachineGunPoint:
					MachineGunUpdate();
					break;
				case EnemyAIState.Minigunner:
					MinigunnerUpdate();
					break;
				case EnemyAIState.EngineerTurret:
					EngineerBuildTurretUpdate();
					break;
				case EnemyAIState.Fly:
					FlyingUpdate();
					break;
				case EnemyAIState.Gunslinger:
					GunslingerUpdate();
					break;
				case EnemyAIState.Mortar:
					MortarUpdate();
					break;
				case EnemyAIState.Warp:
					WarpUpdate();
					break;
				case EnemyAIState.Idle:
				case EnemyAIState.EngineerRepair:
					break;
				}
			}
		}
		else
		{
			OnlineUpdate();
		}
	}

	public void ImproveAllWeapons(float multiplier)
	{
		soldierBehaviour.ImproveAllWeapons(multiplier);
		photonView.RPC("ImproveAllWeaponsRPC", PhotonTargets.Others, multiplier);
	}

	private void SwitchStateToEngineerTurret()
	{
		float num = ((!base.hasSpecial) ? (soldierBehaviour.soldierBehaviourDefinititon.special + 0.2f) : soldierBehaviour.soldierBehaviourDefinititon.special);
		mBuildTurretEndTime = mTime + num;
		hudObjectIndicator.Show("game-engi-progress-fill", value: true, HudObjectIndicator.IndicatorAnimation.EngineerIco, (fraction != PlayerController.currentPlayer.fraction) ? Colours.redProgress : Colours.blue);
		photonView.RPC("ShowEngineerBuildingIndicator", PhotonTargets.Others, true, (byte)fraction);
		EnemyPointEngineerTurret enemyPointEngineerTurret = enemyPoint as EnemyPointEngineerTurret;
		Vector3 forward = enemyPointEngineerTurret.turretPosition - mTransform.position;
		forward.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.3f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		Repair();
	}

	private void EngineerBuildTurretUpdate()
	{
		float num = ((!base.hasSpecial) ? (soldierBehaviour.soldierBehaviourDefinititon.special + 0.2f) : soldierBehaviour.soldierBehaviourDefinititon.special);
		hudObjectIndicator.SetProgress("game-engi-progress-fill", 1f - (mBuildTurretEndTime - mTime) / num);
		if ((int)TimeManager.realTimeWithoutPauses != mSyncTime)
		{
			photonView.RPC("UpdateEngineerBuildingIndicator", PhotonTargets.Others, 1f - (mBuildTurretEndTime - mTime) / num);
			mSyncTime = (int)TimeManager.realTimeWithoutPauses;
		}
		if (mTime > mBuildTurretEndTime && mBuildTurretEndTime != 0f)
		{
			mBuildTurretEndTime = 0f;
			hudObjectIndicator.Show("game-engi-progress-fill", value: false, HudObjectIndicator.IndicatorAnimation.EngineerIco);
			photonView.RPC("ShowEngineerBuildingIndicator", PhotonTargets.Others, false, (byte)fraction);
			EnemyPointEngineerTurret enemyPointEngineerTurret = this.enemyPoint as EnemyPointEngineerTurret;
			Turret turret = (Turret)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<ObjectPoolDatabase>.instance.turret.preparedBehaviour);
			SpawningManager.instance.Spawn(turret, fraction, useEnergy: false, enemyPointEngineerTurret.turretPosition);
			enemyPointEngineerTurret.SetTurret(turret);
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)soldierBehaviour.soldierBehaviourDefinititon).turretUpgradeLevel;
			turret.LoadUpgrades(turretUpgradeLevel, unitUpgrades.scaleDamage, unitUpgrades.scaleHp);
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(this.enemyPoint);
			if (newEnemyPoint != null && newEnemyPoint != this.enemyPoint)
			{
				this.enemyPoint.enemyAtPoint = null;
				SetFinalTarget(newEnemyPoint);
				SwitchState(EnemyAIState.Walk);
			}
			else
			{
				Walk();
				agent.SetDestination(spawnPoint.transform.position);
				agent.Resume();
				agent.stoppingDistance = 0f;
				mIsGoingBack = true;
				mGoBackTimer = mTime;
			}
		}
		if (mIsGoingBack && mTime > mGoBackTimer + 1f)
		{
			mGoBackTimer = mTime;
			EnemyPoint enemyPoint = soldierBehaviour.GetNewEnemyPoint(null);
			EnemyPointEngineerTurret enemyPointEngineerTurret2 = (EnemyPointEngineerTurret)this.enemyPoint;
			if (enemyPointEngineerTurret2.turret == null)
			{
				enemyPoint = enemyPointEngineerTurret2;
			}
			if (enemyPoint != null)
			{
				mIsGoingBack = false;
				this.enemyPoint.enemyAtPoint = null;
				SetFinalTarget(enemyPoint);
				SwitchState(EnemyAIState.Walk);
			}
		}
	}

	private void SwitchStateToHelicopter()
	{
		agent.Stop();
		Idle();
		mHeliPhase = HeliPhase.Driving;
		TweenRotation.Begin(base.gameObject, 0.3f, enemyPoint.transform.rotation);
	}

	private void HelicopterUpdate()
	{
		try
		{
			if (mHeliPhase == HeliPhase.Spawning)
			{
				mProgress = Mathf.Clamp01(mProgress + Time.deltaTime);
				if (mJoints != null && mJoints.Count == 0)
				{
					OnHeliSpawnFinished(null);
					mHeliPhase = HeliPhase.Spawned;
				}
				Vector3 basePosition = base.transform.position.ReplaceY(Mathf.Lerp(mHeliStartYPos, mHeliEndYPos, mProgress));
				mTransform.position = GetRopePosition(basePosition);
				mTransform.rotation = Quaternion.LookRotation(mHeliPoint.helicopter.mTransform.right);
				if (mProgress >= 1f)
				{
					OnHeliSpawnFinished(null);
					mHeliPhase = HeliPhase.Spawned;
				}
			}
			if (mHeliPhase == HeliPhase.Driving && enemyPoint != null)
			{
				mTransform.position = enemyPoint.transform.position;
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	private Vector3 GetRopePosition(Vector3 basePosition)
	{
		Vector3 vector = basePosition + mSoldierAnimationController.leftPalm.position - base.transform.position;
		Vector3 result = basePosition;
		Vector3 vector2 = base.transform.forward * 0.02f - base.transform.right * 0.04f;
		if (mJoints != null)
		{
			Vector3 vector3 = mJoints[0].transform.position;
			if (vector.y >= vector3.y)
			{
				vector3.y = vector.y;
				result = basePosition + (vector3 - vector) + vector2;
			}
			else
			{
				for (int i = 1; i < mJoints.Count; i++)
				{
					Vector3 position = mJoints[i].transform.position;
					if (position.y <= vector.y)
					{
						float t = (position.y - vector.y) / (position.y - vector3.y);
						result = basePosition + (Vector3.Lerp(position, vector3, t) - vector) + vector2;
						break;
					}
					vector3 = position;
				}
			}
		}
		return result;
	}

	public void SpawnFromHelicopter()
	{
		if (enemyAiState == EnemyAIState.Helicopter)
		{
			mHeliPhase = HeliPhase.Spawning;
			RopeSlide();
			Vector3 position = (enemyPoint as EnemyPointHelicopter).ropePosition.position;
			NavMesh.SamplePosition(position, out var hit, 10f, 1);
			mHeliPoint = enemyPoint as EnemyPointHelicopter;
			mJoints = mHeliPoint.helicopter.rope.Joints;
			mProgress = 0f;
			mHeliStartYPos = base.transform.position.y;
			mHeliEndYPos = hit.position.y;
		}
	}

	private void OnHeliSpawnFinished(UITweener tween)
	{
		if (!isAlive)
		{
			return;
		}
		EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(enemyPoint);
		if (newEnemyPoint != null)
		{
			SetFinalTarget(newEnemyPoint);
			ShadowSetActive(value: true);
			SwitchState(EnemyAIState.Walk);
			return;
		}
		InvokeAfter(delegate
		{
			GenerateInitPoint();
		}, 5f);
		Walk();
		spawnPoint = soldierBehaviour.PickNormalSPawn(Singleton<MapManager>.instance.currentMapDef.spawnPointsCollection.spawnPoints);
		agent.SetDestination(spawnPoint.transform.position);
		agent.Resume();
		agent.stoppingDistance = 0f;
	}

	public void GenerateNextShootTime()
	{
		if (enemyAiState == EnemyAIState.Walk)
		{
			mNextShootTime = mTime + UnityEngine.Random.Range(soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax);
		}
		else
		{
			mNextShootTime = mTime + UnityEngine.Random.Range(soldierBehaviour.soldierBehaviourDefinititon.minShootTime, soldierBehaviour.soldierBehaviourDefinititon.maxShootTime);
		}
	}

	public void SwitchState(EnemyAIState state)
	{
		if (isAlive)
		{
			enemyAiState = state;
			switch (state)
			{
			case EnemyAIState.Walk:
				SwitchStateToWalking();
				break;
			case EnemyAIState.ObstacleHiding:
				agent.Stop();
				Crawl();
				mIsCrawling = true;
				GenerateNextShootTime();
				mNextEnemyChangeTime = mTime + (float)UnityEngine.Random.Range(10, 20);
				mPositionChangeTime = mTime + UnityEngine.Random.Range(2f, 4f);
				break;
			case EnemyAIState.CornerHiding:
			{
				EnemyPointCorner enemyPointCorner = (EnemyPointCorner)enemyPoint;
				agent.Stop();
				Idle();
				TweenRotation.Begin(base.gameObject, 0.5f, Quaternion.LookRotation(-enemyPointCorner.direction));
				Vector3 position = enemyPointCorner.position;
				position.y = mTransform.position.y;
				TweenPosition.Begin(base.gameObject, 0.5f, position);
				mIsHidingBehindCorner = true;
				GenerateNextShootTime();
				mNextEnemyChangeTime = mTime + (float)UnityEngine.Random.Range(10, 20);
				break;
			}
			case EnemyAIState.Rusher:
				SwitchStateToRusher();
				break;
			case EnemyAIState.RusherSpare:
				SwitchStateToRusherSpare();
				break;
			case EnemyAIState.Swat:
				SwitchStateToSwat();
				break;
			case EnemyAIState.Vehicle:
				SwitchStateToVehicle();
				break;
			case EnemyAIState.Parachute:
				SwitchStateToParachute();
				break;
			case EnemyAIState.Helicopter:
				SwitchStateToHelicopter();
				break;
			case EnemyAIState.MachineGunPoint:
				SwitchStateToMachineGun();
				break;
			case EnemyAIState.Minigunner:
				SwitchStateToMinigunner();
				break;
			case EnemyAIState.EngineerTurret:
				SwitchStateToEngineerTurret();
				break;
			case EnemyAIState.Fly:
				SwitchStateToFly();
				break;
			case EnemyAIState.Gunslinger:
				SwitchStateToGunslinger();
				break;
			case EnemyAIState.Mortar:
				SwitchStateToMortar();
				break;
			case EnemyAIState.Warp:
				SwitchStateToWarp();
				break;
			case EnemyAIState.Idle:
			case EnemyAIState.EngineerRepair:
				break;
			}
		}
	}

	[PunRPC]
	private void PlayeScifiParticles(bool enable)
	{
		if (enable)
		{
			soldierParts.EnableJetPack(fraction);
		}
		else
		{
			soldierParts.LessJetPackParticles();
		}
	}

	private void SwitchStateToFly()
	{
		enemyPoint = soldierBehaviour.GetInitPoint();
		if (enemyPoint != null)
		{
			enemyPoint.enemyAtPoint = this;
			agent.SetDestination(enemyPoint.position);
			Walk();
			GenerateNextShootTime();
			mIsCrawling = false;
			mFlyInit = true;
		}
		else
		{
			InvokeAfter(SwitchStateToFly, 5f);
		}
	}

	private void FlyingUpdate()
	{
		if (mFlyInit && isInField)
		{
			mFlyInit = false;
			agent.Fly(this.enemyPoint.position);
			agent.Disable();
			StartFlying();
			soldierParts.EnableJetPack(fraction);
			photonView.RPC("PlayeScifiParticles", PhotonTargets.Others, true);
			GenerateNextShootTime();
		}
		if (Vector3.Distance(mTransform.position, agent.flyPos) < 0.1f)
		{
			if (!mIsCrawling && agent.curentPathIndex > 1)
			{
				Crawl();
				mIsCrawling = true;
				soldierParts.LessJetPackParticles();
				photonView.RPC("PlayeScifiParticles", PhotonTargets.Others, false);
				EndShooting();
			}
			mStayTime += Time.deltaTime;
			if (mStayTime >= maxStayTime)
			{
				EnemyPoint enemyPoint = soldierBehaviour.GetNewEnemyPoint(this.enemyPoint) ?? this.enemyPoint;
				if (enemyPoint != null)
				{
					mStayTime = 0f;
					if (enemyPoint == this.enemyPoint)
					{
						agent.Fly(enemyPoint.position, UnityEngine.Random.Range(2f, 4f), base.transform.rotation);
					}
					else
					{
						agent.Fly(enemyPoint.position);
					}
					this.enemyPoint.enemyAtPoint = null;
					this.enemyPoint = enemyPoint;
					this.enemyPoint.enemyAtPoint = this;
					agent.enabled = false;
					InvokeAfter(delegate
					{
						agent.enabled = true;
					}, 0.46f);
					maxStayTime = UnityEngine.Random.Range(2, 3);
					mIsCrawling = false;
					StartFlying();
					soldierParts.EnableJetPack(fraction);
					photonView.RPC("PlayeScifiParticles", PhotonTargets.Others, true);
					GenerateNextShootTime();
				}
			}
		}
		if (agent.curentPathIndex == 1 && !mFlyInit)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
			Vector3 forward = enemyOf.transform.position - mTransform.position;
			forward.y = 0f;
			agent.flyRot = Quaternion.LookRotation(forward);
			if (mTime > mNextShootTime && (mTransform.position.PlanarDistance(agent.flyPos) > 1f || agent.stayTime < agent.current.time * 0.5f))
			{
				PrepareToShoot(tweenRotation: false, needToSeeEnemy: false, 0f);
			}
		}
	}

	private void TargetReached()
	{
		SwitchState(enemyPoint.switchState);
	}

	private void Shoot(float startTime)
	{
		GenerateNextShootTime();
		if (!isAlive)
		{
			return;
		}
		InvokeAfter(delegate
		{
			mIsShooting = true;
			soldierBehaviour.ShootJustStarted();
			if (this.onShoot != null)
			{
				this.onShoot(this);
			}
		}, startTime);
	}

	public void EndShooting()
	{
		mIsShooting = false;
		mWillShoot = false;
		ReturnToPreviousStateFromShot();
	}

	private void ShootingFromWeapon()
	{
		if (mIsShooting && isAlive)
		{
			soldierBehaviour.Shooting();
		}
	}

	private void ReturnToPreviousStateFromShot()
	{
		GenerateNextShootTime();
		if (photonView.isMine)
		{
			if (!isAlive)
			{
				return;
			}
			switch (enemyAiState)
			{
			case EnemyAIState.ObstacleHiding:
				mIsCrawling = true;
				break;
			case EnemyAIState.CornerHiding:
				mIsHidingBehindCorner = true;
				break;
			case EnemyAIState.Rusher:
			case EnemyAIState.RusherSpare:
				mNextShootTime = mTime + UnityEngine.Random.Range(2f, 4f);
				break;
			case EnemyAIState.Swat:
				mNextShootTime = mTime + UnityEngine.Random.Range(2f, 4f);
				break;
			case EnemyAIState.Walk:
				InvokeAfter(delegate
				{
					agent.Resume();
					Walk();
				}, 0.8f);
				break;
			case EnemyAIState.Helicopter:
				TweenRotation.Begin(base.gameObject, 0.3f, enemyPoint.transform.rotation);
				break;
			case EnemyAIState.Minigunner:
				mNextShootTime = mTime + 8f;
				break;
			case EnemyAIState.Parachute:
				break;
			case EnemyAIState.Fly:
				break;
			case EnemyAIState.Gunslinger:
				ReturnToPreviousStateFromShotGunSlinger();
				break;
			case EnemyAIState.Mortar:
				ReturnToPreviousStateFromMortar();
				break;
			case EnemyAIState.Idle:
			case EnemyAIState.Vehicle:
			case EnemyAIState.MachineGunPoint:
			case EnemyAIState.EngineerTurret:
			case EnemyAIState.EngineerRepair:
				break;
			}
		}
		else
		{
			switch (enemyAiState)
			{
			case EnemyAIState.Rusher:
			case EnemyAIState.RusherSpare:
				Idle();
				break;
			case EnemyAIState.Swat:
				InvokeAfter(Idle, 0.2f);
				break;
			case EnemyAIState.Walk:
				InvokeAfter(Walk, 0.8f);
				break;
			}
		}
	}

	public override void DestroyPooled()
	{
		try
		{
			enemyPoint = null;
			mSpawnEnabled = true;
			if (soldierBehaviour != null)
			{
				soldierBehaviour.DestroyBehaviour();
			}
			mParachute = null;
			mJoints = null;
			base.DestroyPooled();
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	private bool PrepareToStandShoot()
	{
		if (!mCanShoot)
		{
			return false;
		}
		soldierBehaviour.PickTarget();
		soldierBehaviour.StartShooting();
		Vector3 dir = soldierBehaviour.targetPosition - mTransform.position;
		dir.y = 0f;
		switch (soldierBehaviour.currentWeapon.weaponType)
		{
		case Weapon.WeaponType.Riffle:
		case Weapon.WeaponType.Pistol:
		case Weapon.WeaponType.Shotgun:
		case Weapon.WeaponType.QBZ:
		case Weapon.WeaponType.SniperRiffle:
		case Weapon.WeaponType.Flamethrower:
		case Weapon.WeaponType.QBZ2:
		case Weapon.WeaponType.DoubleSMG:
		case Weapon.WeaponType.Machinegun:
		case Weapon.WeaponType.Colt:
			if (enemyAiState == EnemyAIState.Walk)
			{
				ShootWalk(dir);
				Shoot(0.35f);
			}
			break;
		}
		mWillShoot = true;
		return true;
	}

	private bool PrepareToShoot(bool tweenRotation, bool needToSeeEnemy, float maxDist = 0f)
	{
		if (!mCanShoot)
		{
			return false;
		}
		soldierBehaviour.PickTarget();
		if (maxDist > 0f && Vector3.Distance(mTransform.position, soldierBehaviour.targetPosition) > maxDist)
		{
			mWillShoot = false;
			return false;
		}
		if (needToSeeEnemy)
		{
			Vector3 start = mTransform.position + Vector3.up * 0.2f;
			if (soldierBehaviour.currentWeapon.spawnPoint != null)
			{
				start.y = soldierBehaviour.currentWeapon.spawnPoint.position.y;
			}
			if (!CanSeeTarget(start, soldierBehaviour.targetPosition))
			{
				mWillShoot = false;
				return false;
			}
		}
		mSoldierAnimationController.ForceInScreen();
		if (!soldierBehaviour.StartShooting())
		{
			GenerateNextShootTime();
			return false;
		}
		if (tweenRotation)
		{
			Vector3 forward = soldierBehaviour.targetPosition - mTransform.position;
			forward.y = 0f;
			TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		}
		if (enemyAiState == EnemyAIState.CornerHiding)
		{
			EnemyPointCorner enemyPointCorner = enemyPoint as EnemyPointCorner;
			if (enemyPointCorner != null)
			{
				float num = GeometryTools.AngleSigned(-enemyPointCorner.direction, soldierBehaviour.targetPosition - mTransform.position, Vector3.up);
				if ((mCoverShotRight = num > 0f) != enemyPointCorner.rightSide || Mathf.Abs(num) < 10f)
				{
					return false;
				}
				Vector3 vector = soldierBehaviour.targetPosition - mTransform.position;
				Quaternion quaternion = Quaternion.LookRotation(-enemyPointCorner.direction);
				float num2 = GeometryTools.AngleSigned(-vector, -enemyPointCorner.direction, Vector3.up);
				Quaternion rot = quaternion * Quaternion.AngleAxis(0f - num2, Vector3.up);
				vector.y = 0f;
				TweenRotation.Begin(base.gameObject, 0.3f, rot).ignoreTimeScale = false;
			}
		}
		switch (soldierBehaviour.currentWeapon.weaponType)
		{
		case Weapon.WeaponType.Riffle:
		case Weapon.WeaponType.Pistol:
		case Weapon.WeaponType.GrenadeLauncher:
		case Weapon.WeaponType.Shotgun:
		case Weapon.WeaponType.QBZ:
		case Weapon.WeaponType.SniperRiffle:
		case Weapon.WeaponType.Flamethrower:
		case Weapon.WeaponType.QBZ2:
		case Weapon.WeaponType.DoubleSMG:
		case Weapon.WeaponType.Machinegun:
		case Weapon.WeaponType.Colt:
			switch (enemyAiState)
			{
			case EnemyAIState.Walk:
				ShootStand();
				Shoot(mSoldierAnimationController.StandShootLength(soldierBehaviour.currentWeapon.weaponType) * 0.3f);
				break;
			case EnemyAIState.ObstacleHiding:
				ShootFromCrawl(1f);
				Shoot(mSoldierAnimationController.GetStandUpFromCrawlLength(soldierBehaviour.currentWeapon.weaponType) + 0.05f);
				break;
			case EnemyAIState.CornerHiding:
				ShootFromCover(!mCoverShotRight, 0.7f);
				Shoot(mSoldierAnimationController.uncoverLength + 0.05f);
				break;
			case EnemyAIState.Rusher:
			case EnemyAIState.RusherSpare:
			{
				ShootStand();
				bool flag = soldierBehaviour.currentWeapon.weaponType == Weapon.WeaponType.Flamethrower;
				Shoot(mSoldierAnimationController.StandShootLength(soldierBehaviour.currentWeapon.weaponType) * ((!flag) ? 0.3f : 0f));
				break;
			}
			case EnemyAIState.Swat:
				ShootStand();
				Shoot(0.1f);
				break;
			case EnemyAIState.Helicopter:
				ShootStand();
				Shoot(0.5f);
				break;
			case EnemyAIState.Parachute:
				ShootStand();
				Shoot(mSoldierAnimationController.StandShootLength(soldierBehaviour.currentWeapon.weaponType) * 0.3f);
				break;
			case EnemyAIState.Fly:
				Shoot(0.05f);
				break;
			case EnemyAIState.Gunslinger:
				ShootStandNew(1f);
				Shoot(mSoldierAnimationController.GetStandPhase0Length(soldierBehaviour.currentWeapon.weaponType));
				break;
			}
			break;
		case Weapon.WeaponType.Grenade:
			switch (enemyAiState)
			{
			case EnemyAIState.Walk:
				ThrowGrenadeFromCrawl();
				Shoot(0.35f);
				break;
			case EnemyAIState.ObstacleHiding:
				ThrowGrenadeFromCrawl();
				Shoot(0.35f);
				break;
			case EnemyAIState.CornerHiding:
				ThrowGrenadeFromCover(!mCoverShotRight);
				Shoot(0.6f);
				break;
			case EnemyAIState.Fly:
				ShootStand();
				Shoot(0.3f);
				break;
			}
			break;
		case Weapon.WeaponType.Bazooka:
			switch (enemyAiState)
			{
			case EnemyAIState.ObstacleHiding:
				ShootFromBazookaFromCrawl();
				Shoot(0.87f);
				break;
			case EnemyAIState.CornerHiding:
				ShootFromBazookaFromCover(mCoverShotRight);
				Shoot(0.7f);
				break;
			case EnemyAIState.Fly:
				ShootStand();
				Shoot(0.3f);
				break;
			}
			break;
		case Weapon.WeaponType.SwatPistol:
		case Weapon.WeaponType.SwatSMG:
			switch (enemyAiState)
			{
			case EnemyAIState.Walk:
				ShootFromShield();
				Shoot(mSoldierAnimationController.swatShieldUncoverLength);
				break;
			case EnemyAIState.Rusher:
			case EnemyAIState.RusherSpare:
				ShootFromShield();
				Shoot(mSoldierAnimationController.swatShieldUncoverLength);
				break;
			case EnemyAIState.Swat:
				ShootFromShield();
				Shoot(mSoldierAnimationController.swatShieldUncoverLength);
				break;
			}
			break;
		case Weapon.WeaponType.Minigun:
			switch (enemyAiState)
			{
			case EnemyAIState.Walk:
				ShootStand();
				Shoot(0.5f);
				break;
			case EnemyAIState.Swat:
				ShootStand();
				Shoot(0.1f);
				break;
			case EnemyAIState.Helicopter:
				ShootStand();
				Shoot(0.5f);
				break;
			case EnemyAIState.Parachute:
				ShootStand();
				Shoot(0.3f);
				break;
			case EnemyAIState.Minigunner:
				ShootStand();
				Shoot(0.1f);
				break;
			}
			break;
		case Weapon.WeaponType.Mortar:
		{
			EnemyAIState enemyAIState = enemyAiState;
			if (enemyAIState == EnemyAIState.Mortar)
			{
				Shoot(0.3f);
			}
			break;
		}
		}
		mWillShoot = true;
		return true;
	}

	public void OnShot()
	{
		if (soldierBehaviour.currentWeapon == null)
		{
			return;
		}
		switch (soldierBehaviour.currentWeapon.weaponType)
		{
		case Weapon.WeaponType.GrenadeLauncher:
			mSoldierAnimationController.ShotFly();
			break;
		case Weapon.WeaponType.Riffle:
		case Weapon.WeaponType.Pistol:
		case Weapon.WeaponType.Shotgun:
		case Weapon.WeaponType.QBZ:
		case Weapon.WeaponType.SniperRiffle:
		case Weapon.WeaponType.Flamethrower:
		case Weapon.WeaponType.QBZ2:
		case Weapon.WeaponType.DoubleSMG:
		case Weapon.WeaponType.Machinegun:
		case Weapon.WeaponType.Colt:
			if (enemyAiState == EnemyAIState.ObstacleHiding)
			{
				mSoldierAnimationController.ShootFromCrawl(0.5f, 1f, soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.Rusher || enemyAiState == EnemyAIState.RusherSpare)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.Swat)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.CornerHiding)
			{
				mSoldierAnimationController.ShotFromCover(!mCoverShotRight, 1f, 0.5f, ignoreTimeScale: false, soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.Walk)
			{
				if (soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop)
				{
					mSoldierAnimationController.ShootStandAdditive(0.4f);
					mSoldierAnimationController.disableLookRot = false;
					Vector3 direction = soldierBehaviour.targetPosition - mTransform.position;
					direction.y = 0f;
					mSoldierAnimationController.LookAtUpperBody(direction);
				}
				else
				{
					mSoldierAnimationController.ShootStand(soldierBehaviour.currentWeapon.weaponType);
				}
			}
			if (enemyAiState == EnemyAIState.Parachute)
			{
				mSoldierAnimationController.ShootStandAdditive(0.25f);
			}
			if (enemyAiState == EnemyAIState.Gunslinger)
			{
				mSoldierAnimationController.ShootStandNew(soldierBehaviour.currentWeapon.weaponType, 1f, 0.5f);
			}
			break;
		case Weapon.WeaponType.SwatPistol:
		case Weapon.WeaponType.SwatSMG:
			if (enemyAiState == EnemyAIState.Walk)
			{
				mSoldierAnimationController.ShootFromSwatShield(0.5f, 1f);
			}
			if (enemyAiState == EnemyAIState.Rusher || enemyAiState == EnemyAIState.RusherSpare)
			{
				mSoldierAnimationController.ShootFromSwatShield(0.5f, 1f);
			}
			if (enemyAiState == EnemyAIState.Swat)
			{
				mSoldierAnimationController.ShootFromSwatShield(0.5f, 1f);
			}
			break;
		case Weapon.WeaponType.Minigun:
			if (enemyAiState == EnemyAIState.ObstacleHiding)
			{
				mSoldierAnimationController.ShootFromCrawl(0.5f, 1f, soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.Rusher || enemyAiState == EnemyAIState.RusherSpare)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.Swat)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.CornerHiding)
			{
				mSoldierAnimationController.ShotFromCover(!mCoverShotRight, 1f, 0.5f, ignoreTimeScale: false, soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.Walk || enemyAiState == EnemyAIState.Minigunner)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.currentWeapon.weaponType);
			}
			if (enemyAiState == EnemyAIState.Parachute)
			{
				mSoldierAnimationController.ShootStandAdditive(0.25f);
			}
			break;
		case Weapon.WeaponType.Grenade:
		case Weapon.WeaponType.Bazooka:
		case Weapon.WeaponType.Tool:
			break;
		}
	}

	public override void EnableSpawn()
	{
		base.EnableSpawn();
	}

	public override void DisableSpawn()
	{
		base.DisableSpawn();
		spawnPoint = null;
	}

	public override void Spawn()
	{
		base.Spawn();
		if (photonView.isMine && mSpawnEnabled)
		{
			try
			{
				spawnPoint = soldierBehaviour.PickSpawnPoint(Singleton<MapManager>.instance.currentMapDef.spawnPointsCollection.spawnPoints);
				mTransform.position = spawnPoint.transform.position;
				TweenPosition.Begin(base.gameObject, 0f, mTransform.position);
			}
			catch (Exception e)
			{
				Crittercism.LogHandledException(e);
			}
		}
	}

	private void OnSmokeStateChanged(bool b)
	{
		hudObjectIndicator.Show("game-ico-speed", b, HudObjectIndicator.IndicatorAnimation.InfoIco);
	}

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		soldierBehaviour.UpdateVisual();
		if (isPrewiev && soldierBehaviour != null)
		{
			mSoldierAnimationController.ForceInScreen();
			float time = 0f;
			if (!mSoldierAnimationController.IsIdle(soldierBehaviour.currentWeapon.weaponType, out time))
			{
				mSoldierAnimationController.SampleIdle(soldierBehaviour.currentWeapon.weaponType);
			}
			else
			{
				mSoldierAnimationController.SampleIdle(soldierBehaviour.currentWeapon.weaponType, time);
			}
			mSoldierAnimationController.Idle(soldierBehaviour.currentWeapon.weaponType);
		}
		soldierParts.shadow.gameObject.SetActive(value: false);
	}

	public void Wait(float time)
	{
		if (enemyAiState == EnemyAIState.Walk)
		{
			agent.Pause();
			Idle();
		}
		if (enemyAiState == EnemyAIState.Warp && agent.speed < 2f)
		{
			agent.Pause();
			Idle();
		}
	}

	public void Resume()
	{
		Debug.Log("==ENEMY RESUME==");
		if (enemyAiState == EnemyAIState.Walk)
		{
			Walk();
			agent.Resume();
		}
		if (enemyAiState == EnemyAIState.Warp && agent.speed < 2f)
		{
			agent.Resume();
			Walk();
		}
	}

	public void Freeze(bool freeze)
	{
		try
		{
			if (mParachute != null)
			{
				mParachute.Freeze(freeze);
			}
			if (!base.isInstantiated)
			{
				return;
			}
			base.enabled = !freeze;
			agent.enabled = !freeze;
			if (freeze)
			{
				agent.Pause();
				mSoldierAnimationController.Pause();
				return;
			}
			if (agent.navigationAgent.enabled)
			{
				agent.Resume();
			}
			mSoldierAnimationController.Resume();
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	public void FreezByCard(bool freeze)
	{
		Freeze(freeze);
		photonView.RPC("FreezeRPC", PhotonTargets.Others, freeze);
	}

	[PunRPC]
	public void FreezeRPC(bool freeze)
	{
		Freeze(freeze);
	}

	public void SetUpKevlar(float hpPercents = 0.2f)
	{
		kevlar.kevlarStrength = hpPercents;
		kevlar.SetUpKevlar((!shield.IsActive()) ? 1 : 2);
	}

	private void ParachuteUpdate()
	{
		if (!mLanded)
		{
			mTransform.position = mParachute.snapTransform.position;
			mTransform.rotation = mParachute.snapTransform.rotation;
			if (mTime > mNextShootTime && !PrepareToShoot(tweenRotation: false, needToSeeEnemy: true, 16f))
			{
				GenerateNextShootTime();
			}
		}
	}

	private void SwitchStateToParachute()
	{
		mLanded = false;
		agent.Stop();
		SpawnPointParachute spawnPointParachute = spawnPoint as SpawnPointParachute;
		mParachute = ObjectPoolDatabase.networkPool.InstantiateNetwork(Singleton<ObjectPoolDatabase>.instance.parachute, spawnPoint.transform.position, spawnPoint.transform.rotation) as Parachute;
		if (mParachute != null)
		{
			Parachute parachute = mParachute;
			parachute.Landed = (Action)Delegate.Combine(parachute.Landed, new Action(OnLanded));
			mParachute.flyDirection = spawnPoint.transform.forward;
		}
		Idle();
	}

	private void OnLanded()
	{
		EnemyPoint initPoint = soldierBehaviour.GetInitPoint();
		if (initPoint != null)
		{
			SetFinalTarget(initPoint);
			ShadowSetActive(value: true);
			SwitchState(EnemyAIState.Walk);
		}
		else
		{
			InvokeAfter(delegate
			{
				GenerateInitPoint();
			}, 5f);
			Walk();
			spawnPoint = soldierBehaviour.PickNormalSPawn(Singleton<MapManager>.instance.currentMapDef.spawnPointsCollection.spawnPoints);
			agent.SetDestination(spawnPoint.transform.position);
			agent.Resume();
			agent.stoppingDistance = 0f;
		}
		mLanded = true;
		mParachute.Landed = null;
		mParachute = null;
	}

	private void VehicleUpdate()
	{
		mTransform.position = enemyPoint.transform.position;
		mTransform.rotation = enemyPoint.transform.rotation;
	}

	private void SwitchStateToVehicle()
	{
		ShadowSetActive(value: false);
		agent.Stop();
		Idle();
		destroyableObject.SetText(string.Empty);
		soldierParts.MakeTrigger(value: true);
		mTransform.position = enemyPoint.transform.position;
		if (soldierBehaviour.currentWeapon != null)
		{
			soldierBehaviour.currentWeapon.gameObject.SetActive(value: false);
		}
		soldierBehaviour.UseTurret(null);
	}

	private void MachineGunUpdate()
	{
		if (mTime > mNextShootTime)
		{
			soldierBehaviour.PickTarget();
			soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = 0.9f;
			soldierBehaviour.StartShooting();
			Shoot(0.5f);
		}
	}

	public void SwitchStateToMachineGun()
	{
		EnemyPointTower enemyPointTower = (EnemyPointTower)enemyPoint;
		ShadowSetActive(value: false);
		agent.Stop();
		Idle();
		soldierParts.MakeTrigger(value: true);
		mTransform.position = enemyPointTower.towerPosition.position;
		mTransform.rotation = enemyPointTower.towerPosition.rotation;
		soldierBehaviour.currentWeapon.gameObject.SetActive(value: false);
	}

	public override void ReSync()
	{
		base.ReSync();
		if (isAlive)
		{
			if (mSoldierAnimationController.isIdle)
			{
				Idle();
			}
			if (mSoldierAnimationController.isRunning)
			{
				Walk();
			}
			if (mSoldierAnimationController.isSitting)
			{
				SittingIdle();
			}
			if (!soldierParts.shadow.gameObject.activeInHierarchy)
			{
				ShadowSetActive(value: false);
			}
		}
	}

	private PlayerPoint FindClosestEnemyPlayerPoint()
	{
		Vector3 position = enemyPoint.position;
		float num = float.MaxValue;
		PlayerPoint result = null;
		foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
		{
			if (player.Value.fraction != fraction && player.Value.currentPlayerPoint != null)
			{
				float num2 = Vector3.Distance(player.Value.currentPlayerPoint.point.transform.position, position);
				if (num2 < num)
				{
					num = num2;
					result = player.Value.currentPlayerPoint.point;
				}
			}
		}
		return result;
	}

	private EnemyPointRusher FindBestRusherPoint()
	{
		EnemyPointRusher enemyPointRusher = enemyPoint as EnemyPointRusher;
		if (enemyPointRusher != null)
		{
			List<EnemyPointRusher> rusherPoints = FindClosestEnemyPlayerPoint().rusherPoints;
			List<EnemyPointRusher> rusherPoints2 = enemyPointRusher.playerPoint.rusherPoints;
			int index = 0;
			float num = float.MaxValue;
			foreach (List<int> item in MiscTools.permutationsOfFOur)
			{
				foreach (EnemyPointRusher item2 in rusherPoints2)
				{
					EnemyPointRusher enemyPointRusher2 = rusherPoints[item[item2.index]];
					if (!item2.isFree && enemyPointRusher2.isFreeWithNearNeighbour(item2))
					{
						float num2 = Vector3.Distance(item2.position, enemyPointRusher2.position);
						if (enemyPointRusher2.index < 2)
						{
							num2 -= 1.7f;
						}
						if (num2 < num && rusherPoints[item[enemyPointRusher.index]].isFreeWithNearNeighbour(enemyPointRusher))
						{
							index = item[enemyPointRusher.index];
							num = num2;
						}
					}
				}
			}
			return rusherPoints[index];
		}
		return null;
	}

	private void RusherUpdate()
	{
		EnemyPointRusher enemyPointRusher = enemyPoint as EnemyPointRusher;
		if (!(enemyPointRusher != null))
		{
			return;
		}
		if (mTime > mNextShootTime && !mWillShoot && enemyPointRusher.playerPoint.shield.player != null)
		{
			PrepareToShoot(tweenRotation: true, needToSeeEnemy: false, 0f);
		}
		if (!enemyPoint.isActive && !mWillShoot)
		{
			mPlayerOutOfRangeTime += Time.deltaTime;
			if (mPlayerOutOfRangeTime > 1.5f)
			{
				EnemyPointRusher finalTarget = FindBestRusherPoint();
				SetFinalTarget(finalTarget);
				SwitchState(EnemyAIState.Walk);
				mPlayerOutOfRangeTime = 0f;
			}
		}
	}

	private void RusherSpareUpdate()
	{
		if (mTime > mNextShootTime && !mWillShoot)
		{
			PrepareToShoot(tweenRotation: true, needToSeeEnemy: false, 0f);
		}
		mPlayerOutOfRangeTime += Time.deltaTime;
		if (!(mPlayerOutOfRangeTime > 0.5f) || mWillShoot)
		{
			return;
		}
		mPlayerOutOfRangeTime = 0f;
		if (rusherCounts < 4)
		{
			EnemyPoint initPoint = soldierBehaviour.GetInitPoint();
			if (initPoint is EnemyPointRusher)
			{
				SetFinalTarget(initPoint);
				SwitchState(EnemyAIState.Walk);
			}
		}
	}

	private void SwitchStateToRusher()
	{
		mCanShootWalk = false;
		WeaponIgnoreLayer(TagsAndLayers.destroyableEntitiesShieldLayerNumber);
		mPlayerOutOfRangeTime = 0f;
		EnemyPointRusher enemyPointRusher = (EnemyPointRusher)enemyPoint;
		agent.Stop();
		Idle();
		Vector3 position = enemyPointRusher.position;
		position.y = mTransform.position.y;
		TweenPosition.Begin(base.gameObject, 0.5f, position);
		Vector3 forward = enemyPointRusher.playerPoint.transform.position - mTransform.position;
		forward.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.3f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		mIsHidingBehindCorner = true;
		mNextShootTime = mTime + 0.5f;
	}

	private void SwitchStateToRusherSpare()
	{
		mCanShootWalk = false;
		WeaponIgnoreLayer(TagsAndLayers.destroyableEntitiesShieldLayerNumber);
		mPlayerOutOfRangeTime = 0f;
		EnemyPointRusherSpare enemyPointRusherSpare = (EnemyPointRusherSpare)enemyPoint;
		agent.Stop();
		Idle();
		Vector3 position = enemyPointRusherSpare.position;
		position.y = mTransform.position.y;
		TweenPosition.Begin(base.gameObject, 0.5f, position);
		Vector3 direction = enemyPointRusherSpare.direction;
		direction.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.3f, Quaternion.LookRotation(direction)).ignoreTimeScale = false;
		mIsHidingBehindCorner = true;
		mNextShootTime = mTime + 0.5f;
	}

	private void SwatUpdate()
	{
		if (mTime > mNextShootTime)
		{
			PrepareToShoot(tweenRotation: true, needToSeeEnemy: false, 0f);
		}
	}

	private void SwitchStateToSwat()
	{
		agent.Stop();
		Idle();
		mNextShootTime = mTime + 0.5f;
	}

	private void MinigunnerUpdate()
	{
		if (mTime > mNextShootTime && !mWillShoot)
		{
			PrepareToShoot(tweenRotation: true, needToSeeEnemy: false, 0f);
		}
		else if (mTime > mNextEnemyChangeTime && !mWillShoot && !mIsShooting)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(enemyPoint);
			if (newEnemyPoint != null && newEnemyPoint != enemyPoint)
			{
				enemyPoint.enemyAtPoint = null;
				SetFinalTarget(newEnemyPoint);
				SwitchState(EnemyAIState.Walk);
			}
			else
			{
				mNextEnemyChangeTime += 2f;
			}
		}
	}

	private void SwitchStateToMinigunner()
	{
		if (mIsShooting)
		{
			Debug.LogError("Switching to minigunner when shooting !!!");
			mIsShooting = false;
			mWillShoot = false;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		agent.Stop();
		Vector3 forward = enemyOf.transform.position - mTransform.position;
		forward.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.5f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		Idle();
		mNextEnemyChangeTime = mTime + UnityEngine.Random.Range(6f, 10f);
		mNextShootTime = mTime + UnityEngine.Random.Range(2f, 4.5f);
	}

	private void SwitchStateToWalking()
	{
		Walk();
		WeaponIgnoreLayer(-1);
		GenerateNextShootTime();
	}

	public void StartStandShoot()
	{
		if (PrepareToShoot(tweenRotation: true, needToSeeEnemy: true, 0f))
		{
			agent.Stop();
		}
		else
		{
			GenerateNextShootTime();
		}
	}

	private void WalkingUpdate()
	{
		if (!mTargetReached && enemyPoint != null && enemyPoint.IsEnemyPointReached(mTransform.position) && !mWillShoot)
		{
			TargetReached();
		}
		if (mCanShootWalk)
		{
			if (!mTargetReached && mTime > mNextShootTime && soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunning && isInField && !soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop && !mWillShoot && mTransform.position.PlanarDistance(enemyPoint.position) > 1f)
			{
				soldierBehaviour.StandShoot();
			}
			if (!mTargetReached && mTime > mNextShootTime && isInField && soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop && !mWillShoot && enemyPoint != null && mTransform.position.PlanarDistance(enemyPoint.position) > 1f)
			{
				PrepareToStandShoot();
			}
		}
		if (!(enemyPoint != null))
		{
			return;
		}
		if (Vector3.Distance(enemyPoint.position, agent.destnation) > 0.5f && !mWillShoot && !agent.isStopped)
		{
			mPlayerOutOfRangeTime += Time.deltaTime;
			SetFinalTarget(enemyPoint);
			mPlayerOutOfRangeTime = 0f;
		}
		if (enemyPoint is EnemyPointRusher)
		{
			if (!enemyPoint.isActive && !mWillShoot && !agent.isStopped)
			{
				mPlayerOutOfRangeTime += Time.deltaTime;
				if (mPlayerOutOfRangeTime > 1.5f)
				{
					mPlayerOutOfRangeTime = 0f;
					EnemyPointRusher finalTarget = FindBestRusherPoint();
					SetFinalTarget(finalTarget);
				}
			}
			if (enemyPoint.isActive)
			{
				mPlayerOutOfRangeTime = 0f;
			}
		}
		if (!enemyPoint.gameObject.activeInHierarchy)
		{
			GenerateInitPoint();
		}
	}

	private void ObstacleHidingUpdate()
	{
		if (mIsCrawling && mTime > mNextShootTime)
		{
			PrepareToShoot(tweenRotation: true, needToSeeEnemy: false, 0f);
			mIsCrawling = false;
			mPositionChangeTime = mTime + UnityEngine.Random.Range(2f, 3f);
		}
		else if (mTime > mPositionChangeTime && !mWillShoot)
		{
			mPositionChangeTime = mTime + UnityEngine.Random.Range(2f, 6f);
			SetFinalTarget(enemyPoint);
		}
		else if (mIsCrawling && mTime > mNextEnemyChangeTime && !mWillShoot && canChangePosition)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(enemyPoint);
			if (newEnemyPoint != null && newEnemyPoint != enemyPoint)
			{
				enemyPoint.enemyAtPoint = null;
				SetFinalTarget(newEnemyPoint);
				mIsCrawling = false;
				SwitchState(EnemyAIState.Walk);
			}
			else
			{
				mNextEnemyChangeTime += 10f;
			}
		}
	}

	public void StartAnim(Vector3 to)
	{
		mIsStartAnim = true;
		mStartAnimTargetPos = to;
		agent.SetDestination(to);
		mSoldierAnimationController.Walk(soldierBehaviour.currentWeapon.weaponType);
		mIsRunning = true;
	}

	private void StartAnimUpdate()
	{
		if (base.transform.position.PlanarDistance(mStartAnimTargetPos) < 0.1f && mIsRunning)
		{
			mIsRunning = false;
			mSoldierAnimationController.Idle(soldierBehaviour.currentWeapon.weaponType);
		}
	}

	private void CornerHidingUpdate()
	{
		if (mIsHidingBehindCorner && mTime > mNextShootTime)
		{
			if (PrepareToShoot(tweenRotation: false, needToSeeEnemy: false, 0f))
			{
				mIsHidingBehindCorner = false;
			}
			else
			{
				GenerateNextShootTime();
			}
		}
		if (mIsHidingBehindCorner && mTime > mNextEnemyChangeTime && !mIsShooting)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(enemyPoint);
			if (newEnemyPoint != null && newEnemyPoint != enemyPoint)
			{
				enemyPoint.enemyAtPoint = null;
				SetFinalTarget(newEnemyPoint);
				mIsHidingBehindCorner = false;
				SwitchState(EnemyAIState.Walk);
			}
			else
			{
				mNextEnemyChangeTime += 10f;
			}
		}
	}

	private void SwitchStateToGunslinger()
	{
		mShotsRemaining = soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax;
		agent.Stop();
		mNextShootTime = mTime;
		mPositionChangeTime = mTime + UnityEngine.Random.Range(2f, 4f);
		SnapColt(toCover: false);
	}

	private void GunslingerUpdate()
	{
		if (mWillShoot)
		{
			return;
		}
		if (mShotsRemaining > 0)
		{
			if (mTime > mNextShootTime)
			{
				mShotsRemaining--;
				PrepareToShoot(tweenRotation: true, needToSeeEnemy: false, 0f);
			}
		}
		else if (mTime > mPositionChangeTime)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(enemyPoint);
			if (newEnemyPoint != null && newEnemyPoint != enemyPoint)
			{
				enemyPoint.enemyAtPoint = null;
				SetFinalTarget(newEnemyPoint);
				mIsCrawling = false;
				SwitchState(EnemyAIState.Walk);
			}
		}
	}

	private void ReturnToPreviousStateFromShotGunSlinger()
	{
		mNextShootTime = mTime + (float)soldierBehaviour.currentWeapon.cadence;
		mPositionChangeTime = mTime + 2f;
		if (mShotsRemaining == 0)
		{
			InvokeAfter(delegate
			{
				SnapColt(toCover: true);
			}, 1f);
		}
	}

	[PunRPC]
	public void SnapColt(bool toCover)
	{
		if (photonView.isMine)
		{
			photonView.RPC("SnapColt", PhotonTargets.Others, toCover);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			soldierBehaviour.mSoldierParts.SnapColt(toCover);
		}
	}

	private void SwitchStateToMortar()
	{
		mMortarStopPosition = base.transform.position;
		agent.Disable();
		BuildMortar();
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = soldierBehaviour.soldierBehaviourDefinititon as SoldierBehaviourDefinititonMortar;
		mNextShootTime = mTime + soldierBehaviourDefinititonMortar.mortarBuildTime;
		mPositionChangeTime = float.MaxValue;
		Rotate();
	}

	private void Rotate()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		mCurrentPlayerDefPos = enemyOf.currentPlayerPoint.point;
		Vector3 lhs = mCurrentPlayerDefPos.shield.shotPosition.position - mTransform.position;
		lhs = lhs.ReplaceY(0f);
		TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.LookRotation(lhs)).ignoreTimeScale = false;
	}

	private void MortarUpdate()
	{
		base.transform.position = mMortarStopPosition;
		if (mTime > mNextShootTime)
		{
			mNextShootTime = float.MaxValue;
			FireMortar();
			PrepareToShoot(tweenRotation: false, needToSeeEnemy: false, 0f);
		}
		else if (mNextShootTime != float.MaxValue)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
			if (mCurrentPlayerDefPos != enemyOf.currentPlayerPoint.point)
			{
				Rotate();
			}
		}
		if (mTime > mPositionChangeTime)
		{
			EnemyPoint newEnemyPoint = enemyPoint;
			if (enemyPoint.IsEnemyPointReached(mTransform.position))
			{
				newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(enemyPoint);
			}
			if (newEnemyPoint != null)
			{
				enemyPoint.enemyAtPoint = null;
				SetFinalTarget(newEnemyPoint);
				mIsCrawling = false;
				SwitchState(EnemyAIState.Walk);
			}
		}
	}

	[PunRPC]
	private void BuildMortar()
	{
		if (photonView.isMine)
		{
			photonView.RPC("BuildMortar", PhotonTargets.Others);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			mSoldierAnimationController.ForceInScreen();
			mSoldierAnimationController.BuildMortar();
		}
	}

	[PunRPC]
	private void FireMortar()
	{
		if (photonView.isMine)
		{
			photonView.RPC("FireMortar", PhotonTargets.Others);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			mSoldierAnimationController.FiredMortar();
		}
		soldierBehaviour.mSoldierParts.SnapWeaponToWorld();
		InvokeAfter(delegate
		{
			soldierBehaviour.mSoldierParts.SnapToHand();
		}, mSoldierAnimationController.mortarShotTime);
		mPositionChangeTime = mTime + mSoldierAnimationController.mortarShotTime + mSoldierAnimationController.mortarStandTime;
	}

	private void ReturnToPreviousStateFromMortar()
	{
		mNextShootTime = float.MaxValue;
	}

	private void OnlineUpdate()
	{
		mPhotonTransform.Update(mTransform);
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (!mIsStartAnim)
		{
			if (stream.isWriting)
			{
				stream.Serialize(ref mIsRunning);
				stream.Serialize(ref mIsCovered);
				stream.SendNext((byte)enemyAiState);
				mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			}
			else
			{
				stream.Serialize(ref mIsRunning);
				stream.Serialize(ref mIsCovered);
				SetAIStateFromNetwork((EnemyAIState)(byte)stream.ReceiveNext());
				mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			}
		}
	}

	private void SetAIStateFromNetwork(EnemyAIState state)
	{
		if (enemyAiState != state)
		{
			enemyAiState = state;
			if (state == EnemyAIState.Vehicle)
			{
				soldierParts.MakeTrigger(value: true);
				destroyableObject.SetText(string.Empty);
			}
		}
	}

	[PunRPC]
	private void ShootFromCrawl(float hideAfter)
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootFromCrawl", PhotonTargets.Others, hideAfter);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			mSoldierAnimationController.ShootFromCrawl(hideAfter, 1f, soldierBehaviour.currentWeapon.weaponType);
		}
	}

	[PunRPC]
	private void ShootStandNew(float hideAfter)
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootStandNew", PhotonTargets.Others, hideAfter);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			mSoldierAnimationController.ShootStandNew(soldierBehaviour.currentWeapon.weaponType, 1f, hideAfter);
		}
	}

	[PunRPC]
	private void Crawl()
	{
		if (photonView.isMine)
		{
			photonView.RPC("Crawl", PhotonTargets.Others);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			Weapon.WeaponType weaponType = soldierBehaviour.currentWeapon.weaponType;
			if (weaponType == Weapon.WeaponType.Bazooka)
			{
				mSoldierAnimationController.BazookaCrawl();
			}
			else
			{
				mSoldierAnimationController.Crawl();
			}
		}
	}

	[PunRPC]
	private void Idle()
	{
		if (photonView.isMine)
		{
			photonView.RPC("Idle", PhotonTargets.Others);
		}
		mSoldierAnimationController.Idle((soldierBehaviour.currentWeapon != null) ? soldierBehaviour.currentWeapon.weaponType : Weapon.WeaponType.Riffle);
	}

	[PunRPC]
	public void SittingIdle()
	{
		if (photonView.isMine)
		{
			photonView.RPC("SittingIdle", PhotonTargets.Others);
		}
		mSoldierAnimationController.SittingIdle();
	}

	[PunRPC]
	private void Repair()
	{
		if (photonView.isMine)
		{
			photonView.RPC("Repair", PhotonTargets.Others);
		}
		mSoldierAnimationController.Repair();
	}

	[PunRPC]
	private void StartFlying()
	{
		if (photonView.isMine)
		{
			photonView.RPC("StartFlying", PhotonTargets.Others);
		}
		mSoldierAnimationController.StartFlying();
	}

	[PunRPC]
	private void ShootFromCover(bool right, float hideAfter)
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootFromCover", PhotonTargets.Others, right, hideAfter);
		}
		else
		{
			mCoverShotRight = !right;
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			mSoldierAnimationController.ShotFromCover(right, 1f, hideAfter, ignoreTimeScale: false, soldierBehaviour.currentWeapon.weaponType);
		}
	}

	[PunRPC]
	private void Walk()
	{
		if (photonView.isMine)
		{
			photonView.RPC("Walk", PhotonTargets.Others);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			mSoldierAnimationController.Walk(soldierBehaviour.currentWeapon.weaponType);
		}
	}

	[PunRPC]
	private void RopeSlide()
	{
		if (photonView.isMine)
		{
			photonView.RPC("RopeSlide", PhotonTargets.Others);
		}
		mSoldierAnimationController.RopeSlide();
	}

	[PunRPC]
	private void ThrowGrenadeFromCrawl()
	{
		if (photonView.isMine)
		{
			photonView.RPC("ThrowGrenadeFromCrawl", PhotonTargets.Others);
		}
		mSoldierAnimationController.ThrowGrenadeFromCrawl();
	}

	[PunRPC]
	private void ShootFromShield()
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootFromShield", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootFromSwatShield(5f, 1f);
	}

	[PunRPC]
	private void ThrowGrenadeFromCover(bool right)
	{
		if (photonView.isMine)
		{
			photonView.RPC("ThrowGrenadeFromCover", PhotonTargets.Others, right);
		}
		mSoldierAnimationController.ThrowGrenadeFromCover(right, ignoreTimescale: false);
	}

	[PunRPC]
	private void ShootFromBazookaFromCrawl()
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootFromBazookaFromCrawl", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootFromBazokaCrawl();
	}

	[PunRPC]
	private void ShootFromBazookaFromCover(bool right)
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootFromBazookaFromCover", PhotonTargets.Others, right);
		}
		mSoldierAnimationController.ShootFromBazoka(right, ignoreTimeScale: false);
	}

	[PunRPC]
	private void ShootStand()
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootStand", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootStand(soldierBehaviour.currentWeapon.weaponType);
	}

	[PunRPC]
	private void ShootWalk(Vector3 dir)
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootWalk", PhotonTargets.Others, dir);
		}
		mSoldierAnimationController.disableLookRot = false;
		mSoldierAnimationController.lookBack = false;
		mSoldierAnimationController.ShootStandAdditive(0.5f);
		mSoldierAnimationController.LookAtUpperBody(dir, 1f);
	}

	[PunRPC]
	private void ShootAdditive()
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShootAdditive", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootStandAdditive(0.5f);
	}

	[PunRPC]
	private void ShadowSetActive(bool value)
	{
		if (photonView.isMine)
		{
			photonView.RPC("ShadowSetActive", PhotonTargets.Others, value);
		}
		soldierParts.ShadowSetActive(value);
	}

	[PunRPC]
	public void SoldierBehaviourSwitchWeapon(bool isSecondary)
	{
		if (soldierBehaviour != null)
		{
			soldierBehaviour.SwitchWeapon(isSecondary);
		}
	}

	[PunRPC]
	private void SoldierBehaviourStartShootingNetwork(Vector3 position, int fakeAndRealShots, bool isNetworkCopy, byte shotType, byte batchSize)
	{
		if (soldierBehaviour != null)
		{
			soldierBehaviour.StartShootingNetworkRPC(position, fakeAndRealShots, isNetworkCopy, shotType, batchSize);
		}
	}

	[PunRPC]
	private void SetCanDie(bool canDieValue)
	{
		mCanDie = canDieValue;
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePart(float mult, int index)
	{
		photonView.RPC("ChangeWeightForDestroyablePartRPC", PhotonTargets.Others, mult, index);
		ChangeWeightForDestroyablePartRPC(mult, index);
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePartRPC(float mult, int index)
	{
		destroyableObject.parts[index].weight *= mult;
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		destroyableObject.maxHealth = soldierBehaviour.soldierBehaviourDefinititon.health;
		destroyableObject.ResetWeights();
		destroyableObject.RefillOffline();
		agent.speed = soldierBehaviour.soldierBehaviourDefinititon.speed;
		soldierBehaviour.UpdateVisual();
	}

	[PunRPC]
	public void ShowEngineerBuildingIndicator(bool show, byte soldierFraction)
	{
		hudObjectIndicator.Show("game-engi-progress-fill", show, HudObjectIndicator.IndicatorAnimation.EngineerIco, ((Fractions)soldierFraction != PlayerController.currentPlayer.fraction) ? Colours.redProgress : Colours.blue);
	}

	[PunRPC]
	public void UpdateEngineerBuildingIndicator(float progress)
	{
		hudObjectIndicator.SetProgress("game-engi-progress-fill", progress);
	}

	[PunRPC]
	public void ImproveAllWeaponsRPC(float multiplayer)
	{
		soldierBehaviour.ImproveAllWeapons(multiplayer);
	}

	[PunRPC]
	public void WeaponIgnoreLayer(int layer)
	{
		if (photonView.isMine)
		{
			photonView.RPC("WeaponIgnoreLayer", PhotonTargets.Others, layer);
		}
		if (soldierBehaviour.currentWeapon != null)
		{
			soldierBehaviour.currentWeapon.ignoreLayersMask = ((layer >= 0) ? (1 << layer) : 0);
		}
	}

	public void UpdateHeadScale(float newScale)
	{
		photonView.RPC("UpdateHeadScaleRPC", PhotonTargets.Others, newScale);
		UpdateHeadScaleRPC(newScale);
	}

	[PunRPC]
	private void UpdateHeadScaleRPC(float newScale)
	{
		if (headSizeSetter != null)
		{
			headSizeSetter.scaleF = newScale;
		}
	}

	public void SetMaxHealthAndRefill(float maxHealth)
	{
		destroyableObject.maxHealth = maxHealth;
		destroyableObject.Refill();
	}

	private void WarpUpdate()
	{
		if (mTime > mPositionChangeTime)
		{
			mPositionChangeTime = float.MaxValue;
			mWalkStartTime = mTime;
			agent.speed = 0.2f;
			agent.SetDestination(GetNextPoint());
			Walk();
			if (mNrOfWarps == 0)
			{
				if (enemyPoint != null)
				{
					if (!enemyPoint.isActive)
					{
						EnemyPointRusher enemyPointRusher = FindBestRusherPoint();
						enemyPoint.enemyAtPoint = null;
						enemyPoint = enemyPointRusher;
					}
					enemyPoint.enemyAtPoint = this;
					agent.SetDestination(enemyPoint.position);
					Walk();
					mNextShootTime = float.MaxValue;
					mNextShootTime = mTime;
					mNrOfWarps = -1;
				}
				mIsCrawling = true;
			}
			else
			{
				mNrOfWarps--;
				mIsCrawling = false;
			}
		}
		if (mPositionChangeTime == float.MaxValue)
		{
			if (mTime < mWalkStartTime + 0.5f)
			{
				agent.speed = Mathf.Lerp(0.2f, soldierBehaviour.soldierBehaviourDefinititon.speed, (mTime - mWalkStartTime) / 0.5f);
			}
			if (mTime > mWalkStartTime + 1.5f && agent.speed < 2f)
			{
				agent.speed = 20f;
				agent.Warp();
				Warp();
			}
		}
		float num = base.transform.position.PlanarDistance(agent.destnation);
		if (num < 0.5f && mPositionChangeTime == float.MaxValue && mNrOfWarps >= 0)
		{
			mPositionChangeTime = mTime + 0.5f;
			WarpIdle();
		}
		if (enemyPoint != null && enemyPoint.IsEnemyPointReached(mTransform.position) && mNrOfWarps < 0)
		{
			agent.speed = soldierBehaviour.soldierBehaviourDefinititon.speed;
			SyncWarper();
			WarpIdle();
			TargetReached();
		}
	}

	private Vector3 GetRandomPointOnPath()
	{
		Vector3 destnation = agent.destnation;
		Bounds bounds = Singleton<MapManager>.instance.currentMapDef.fieldArea.bounds;
		bool flag = !mSide;
		float num = ((!flag) ? bounds.max.z : bounds.min.z);
		float num2 = (flag ? bounds.max.z : bounds.min.z);
		float num3 = ((!(num2 - num > 0f)) ? (-1f) : 1f);
		destnation.z = num + num3 * UnityEngine.Random.Range(1f, 2.7f);
		Plane plane = new Plane(Vector3.forward, new Vector3(0f, 0f, destnation.z));
		for (int i = 0; i < agent.corners.Length - 1; i++)
		{
			Vector3 vector = agent.corners[i];
			Vector3 vector2 = agent.corners[i + 1];
			float magnitude = (vector2 - vector).magnitude;
			Ray ray = new Ray(vector, vector2 - vector);
			if (plane.Raycast(ray, out var enter) && enter <= magnitude)
			{
				return ray.GetPoint(enter);
			}
		}
		Debug.Log("Warp - can not find random point - returning agent destination");
		NavMeshHit hit;
		return (!NavMesh.SamplePosition(agent.destnation, out hit, 5f, 1)) ? agent.destnation : hit.position;
	}

	private Vector3 GetNextPoint()
	{
		Bounds bounds = Singleton<MapManager>.instance.currentMapDef.fieldArea.bounds;
		bounds.size -= new Vector3(4f, 0f, UnityEngine.Random.Range(2f, 3.5f));
		Vector3 zero = Vector3.zero;
		zero.x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
		zero.y = bounds.min.y;
		zero.z = ((!mSide) ? bounds.max.z : bounds.min.z);
		mSide = !mSide;
		if (NavMesh.SamplePosition(zero, out var hit, 5f, 1))
		{
			return hit.position;
		}
		return GetNextPoint();
	}

	public void WarpAgain()
	{
		enemyAiState = EnemyAIState.Warp;
		mSide = UnityEngine.Random.value > 0.5f;
		mNrOfWarps = UnityEngine.Random.Range(0, 2);
		mPositionChangeTime = float.MaxValue;
		mWalkStartTime = mTime - 1.3f;
		agent.speed = 0f;
		agent.SetDestination(GetNextPoint());
		mIsCrawling = true;
	}

	private void SwitchStateToWarp()
	{
		enemyPoint = soldierBehaviour.GetInitPoint();
		mSide = UnityEngine.Random.value > 0.5f;
		mNrOfWarps = UnityEngine.Random.Range(1, 3);
		mPositionChangeTime = mTime - 1f;
		mIsCrawling = false;
		mWalkStartTime = float.MaxValue;
		if (enemyPoint != null)
		{
			enemyPoint.enemyAtPoint = this;
			agent.SetDestination(enemyPoint.position);
			Walk();
			mNextShootTime = float.MaxValue;
			mNextShootTime = mTime;
		}
		else
		{
			InvokeAfter(SwitchStateToWarp, 2f);
		}
	}

	[PunRPC]
	private void Warp()
	{
		SoldierBehaviourWarper soldierBehaviourWarper = soldierBehaviour as SoldierBehaviourWarper;
		soldierBehaviourWarper.ChangeToTransparent();
		if (photonView.isMine)
		{
			photonView.RPC("Warp", PhotonTargets.Others);
		}
		mSoldierAnimationController.Warp();
	}

	[PunRPC]
	private void WarpIdle()
	{
		SoldierBehaviourWarper soldierBehaviourWarper = soldierBehaviour as SoldierBehaviourWarper;
		soldierBehaviourWarper.ChangeToNormalMat();
		if (photonView.isMine)
		{
			photonView.RPC("WarpIdle", PhotonTargets.Others);
		}
		mSoldierAnimationController.WarpIdle();
	}

	private void SyncWarper()
	{
		if (photonView.isMine)
		{
			photonView.RPC("SyncWarperRPC", PhotonTargets.Others, base.transform.position, base.transform.rotation);
		}
	}

	[PunRPC]
	private void SyncWarperRPC(Vector3 position, Quaternion rotation)
	{
		mPhotonTransform.AddNewState(PhotonNetwork.time, position, rotation);
	}
}
