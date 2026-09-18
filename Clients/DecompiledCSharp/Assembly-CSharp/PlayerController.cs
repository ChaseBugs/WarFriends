using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MainGameEntity, TimeScaleIgnorable, IFraction, IGameMainEntity, ICharacter
{
	public enum PlayerStatex
	{
		HidingBehindShield,
		Walking,
		WalkingToNewlevel
	}

	public static PlayerController currentPlayer;

	public static Dictionary<int, PlayerController> players = new Dictionary<int, PlayerController>();

	public PlayerNetworkStatus networkStatus;

	public List<AimTarget> aimTargets;

	public DestroyableObjectPlayer destroyableParts;

	public bool isPreview;

	private Material mMyMaterial;

	public PhotonView mPhotonView;

	private PlayerStatex mPlayerState;

	public SoldierParts soldierParts;

	public int playerNetworkId;

	public PlayerProperties playerProperties = new PlayerProperties();

	public AimTarget swipeArea;

	public KinematicRagdoll ragdoll;

	[SerializeField]
	private SoldierMeshChanger mMeshChanger;

	public PlayerBot playerBot;

	public float chanceToNoDamage;

	private static readonly List<PlayerController> mHelpPlayers = new List<PlayerController>();

	public bool canSendUnits;

	public bool friendlyKillOver;

	public bool mCanSendUnits;

	private GameObject mClickedObj;

	private MapDefinition.DefendPosition mCurrentPlayerPoint;

	public Fractions mFraction = Fractions.Enemies;

	private bool mGoLeft;

	private bool mGoRight;

	private MapDefinition.DefendPosition mGoToPosition;

	private float mHitTime;

	private bool mIsBlind;

	private float mIsBlindTime;

	private Vector3 mLastPos;

	private int? mReloadingWeaponIndex;

	private SkinnedMeshRenderer mSkinnedMeshRenderer;

	private Vector3 mStartSwipePos;

	private bool mSwipeStarted;

	private Transform mTransform;

	private Quaternion mWantedLookRotation;

	private PhotonTransform mPhotonTransform = new PhotonTransform();

	private float mWantedUpperBodyRot;

	public bool movingFreeze;

	public float playerHitPointCoef = 1f;

	public bool tutorialImmortality;

	public bool updateWeapons;

	public float weaponDamageCoef = 1f;

	public List<Collider> ragdollColliders;

	private bool mIsUp;

	public bool canSendCards = true;

	private NavigationAgent mNavigationAgent;

	private float mLastPoison;

	public WeaponInventory weaponInventory { get; private set; }

	public SoldierAnimationController soldierAnimator { get; private set; }

	public GameShootableEntity gameShootableEntity { get; private set; }

	public bool clicked { get; private set; }

	public MapDefinition.DefendPosition currentPlayerPoint
	{
		get
		{
			return mCurrentPlayerPoint;
		}
		set
		{
			if (mCurrentPlayerPoint != null && mCurrentPlayerPoint.point.shield != null)
			{
				mCurrentPlayerPoint.point.shield.player = null;
			}
			mCurrentPlayerPoint = value;
			if (mCurrentPlayerPoint != null && mCurrentPlayerPoint.point.shield != null)
			{
				mCurrentPlayerPoint.point.shield.player = this;
			}
		}
	}

	public bool isImmortal
	{
		get
		{
			return destroyableParts.isImmortal;
		}
		set
		{
			destroyableParts.isImmortal = value;
		}
	}

	public float weaponReloadCoef { get; set; }

	public float speed
	{
		get
		{
			return mNavigationAgent.speed;
		}
		set
		{
			mNavigationAgent.speed = value;
		}
	}

	public PlayerStatex playerState
	{
		get
		{
			return mPlayerState;
		}
		private set
		{
			if (mPlayerState != value)
			{
				mPlayerState = value;
				if (this.PlayerStateChanged != null)
				{
					this.PlayerStateChanged(value);
				}
			}
		}
	}

	public Vector3 position => mTransform.position;

	public Vector3 aimForward
	{
		get
		{
			if (currentPlayerPoint == null || currentPlayerPoint.point == null)
			{
				return -mTransform.forward;
			}
			return -currentPlayerPoint.point.transform.forward;
		}
	}

	public Vector3 aimToMiddleOfMap
	{
		get
		{
			if (Singleton<MapManager>.instance.currentMapDef != null && Singleton<MapManager>.instance.currentMapDef.floorTransform != null)
			{
				Vector3 vector = Singleton<MapManager>.instance.currentMapDef.floorTransform.position - mTransform.position;
				float num = GeometryTools.AngleSigned(vector, aimForward, Vector3.up);
				if (num > 15f)
				{
					return Quaternion.AngleAxis(15f, -Vector3.up) * aimForward;
				}
				if (num < -15f)
				{
					return Quaternion.AngleAxis(-15f, -Vector3.up) * aimForward;
				}
				return vector;
			}
			return base.transform.forward;
		}
	}

	public bool isCurrentPlayer => currentPlayer == this;

	public override Fractions fraction
	{
		get
		{
			return mFraction;
		}
		set
		{
			if (fraction != value)
			{
				mFraction = value;
			}
			SetupCollisionLayers(mFraction);
		}
	}

	public override IFraction owner
	{
		get
		{
			return this;
		}
		set
		{
		}
	}

	public override int power { get; set; }

	public bool ignoreTimeScale
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public SoldierMeshChanger meshChanger => mMeshChanger;

	public string[] playerVisuals
	{
		get
		{
			return playerProperties.playerVisuals;
		}
		set
		{
			playerProperties.playerVisuals = value;
		}
	}

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo
	{
		get
		{
			return playerProperties.equippedCamo;
		}
		set
		{
			playerProperties.equippedCamo = value;
		}
	}

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet
	{
		get
		{
			return playerProperties.equippedHelmet;
		}
		set
		{
			playerProperties.equippedHelmet = value;
		}
	}

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory
	{
		get
		{
			return playerProperties.equippedHeadAccesory;
		}
		set
		{
			playerProperties.equippedHeadAccesory = value;
		}
	}

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand
	{
		get
		{
			return playerProperties.equippedPowerBand;
		}
		set
		{
			playerProperties.equippedPowerBand = value;
		}
	}

	public event Action<PlayerStatex> PlayerStateChanged;

	public override event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;

	public void ChangeWeightForDestroyablePart(float mult, int index)
	{
		photonView.RPC("ChangeWeightForDestroyablePartRPC", PhotonTargets.Others, mult, index);
		ChangeWeightForDestroyablePartRPC(mult, index);
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePartRPC(float mult, int index)
	{
		destroyableParts.parts[index].weight *= mult;
	}

	[PunRPC]
	private void SetCurrentPoint(int index)
	{
		if (Singleton<MapManager>.instance.currentMapDef != null)
		{
			mCurrentPlayerPoint = Singleton<MapManager>.instance.currentMapDef.playersPositions[index];
		}
	}

	[PunRPC]
	public void AddAmmoRPC(int index, int amount)
	{
		weaponInventory.usedWeapons[index].weapon.ammoLeft += amount;
	}

	public void SetNoDamageChance(float chance)
	{
		chanceToNoDamage = chance;
		photonView.RPC("SetNoDamageChanceRPC", PhotonTargets.Others, chance);
	}

	[PunRPC]
	public void SetNoDamageChanceRPC(float chance)
	{
		chanceToNoDamage = chance;
	}

	protected override void Start()
	{
		base.Start();
		isAlive = true;
	}

	protected override void Awake()
	{
		base.Awake();
		swipeArea.ignoreLayer = true;
		swipeArea.Clicked += SwipeAreaOnClicked;
		soldierAnimator = GetComponentInChildren<SoldierAnimationController>();
		mNavigationAgent = GetComponent<NavigationAgent>();
		weaponInventory = GetComponentInChildren<WeaponInventory>();
		soldierParts = GetComponent<SoldierParts>();
		gameShootableEntity = GetComponent<GameShootableEntity>();
		weaponInventory.SetUpPlayer(this);
		destroyableParts.OnDeath += OnDeath;
		destroyableParts.OnDamage += OnDamage;
		SetupCollisionLayers(mFraction);
		mPlayerState = PlayerStatex.HidingBehindShield;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		mPhotonView = GetComponent<PhotonView>();
		mTransform = base.transform;
		weaponInventory.SelectedWeaponChanged += WeaponInventoryOnSelectedWeaponChanged;
		PhotonView[] componentsInChildren = GetComponentsInChildren<PhotonView>(includeInactive: true);
		PhotonView[] array = componentsInChildren;
		foreach (PhotonView photonView in array)
		{
			photonView.didAwake = true;
		}
		mSkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
		networkStatus = new PlayerNetworkStatus(this);
		playerBot = GetComponentsInChildren<PlayerBot>()[0];
	}

	private void OnGameStarted()
	{
		if (base.gameObject.activeSelf && fraction == currentPlayer.fraction && DebugSettings.instance.data.showPlayerHealthBar)
		{
			destroyableParts.healthbar.Enable();
			destroyableParts.healthbar.FadeIn(1f);
		}
	}

	private Vector3 GetGroundPosition(Vector3 position)
	{
		if (NavMesh.SamplePosition(position, out var hit, 10f, 1))
		{
			return hit.position;
		}
		return position;
	}

	public void MoveTo(Vector3 pos, Quaternion rot)
	{
		mTransform.position = GetGroundPosition(pos);
		mTransform.rotation = rot;
		mNavigationAgent.SetDestination(pos);
	}

	public void InitPlayerForCamera()
	{
		if (mMyMaterial != null)
		{
			mSkinnedMeshRenderer.material = mMyMaterial;
		}
		soldierParts.helmett.Swap(toRigidBody: false);
		soldierAnimator.Reset();
		SelectPrimary();
		CamosManager.instance.ApplyVisuals(this, playerProperties.playerVisuals, useHighRes: true);
	}

	public void InitPlayer()
	{
		speed = 1f;
		weaponInventory.cannotChange = false;
		playerProperties.ClearAccesories();
		soldierAnimator.SetTPose();
		foreach (Collider ragdollCollider in ragdollColliders)
		{
			ragdollCollider.enabled = false;
		}
		DestroyableObjectpart[] parts = destroyableParts.parts;
		foreach (DestroyableObjectpart destroyableObjectpart in parts)
		{
			destroyableObjectpart.GetComponent<Collider>().enabled = true;
		}
		soldierParts.shadow.gameObject.SetActive(value: true);
		soldierParts.helmett.Swap(toRigidBody: false);
		GetComponent<Kevlar>().ClearKevlar();
		weaponInventory.startGameWithIndex = 0;
		mLastPos = Vector3.zero;
		if (mMyMaterial != null)
		{
			mSkinnedMeshRenderer.material = mMyMaterial;
		}
		if (destroyableParts.healthbar != null)
		{
			destroyableParts.healthbar.Disable();
		}
		isPreview = false;
		tutorialImmortality = false;
		weaponReloadCoef = 1f;
		weaponDamageCoef = 1f;
		playerHitPointCoef = 1f;
		soldierAnimator.Reset();
		weaponInventory.SetWeapons(playerProperties.weapons);
		CamosManager.instance.ApplyVisuals(this, playerProperties.playerVisuals, useHighRes: true);
		if (isCurrentPlayer || mPhotonView.isMine)
		{
			destroyableParts.maxHealth = Singleton<GameController>.instance.mainController.GetPlayerHP(this) * playerHitPointCoef;
			Debug.Log("SET HP: " + destroyableParts.maxHealth + "name: " + playerProperties.name);
			destroyableParts.Refill();
		}
		isAlive = true;
		soldierParts.SetAllRigidBodiesToKinematic(value: true);
		ragdoll.ResetRagdoll();
		soldierAnimator.Enable();
		soldierAnimator.Reset();
		soldierAnimator.Idle(Weapon.WeaponType.Riffle);
		soldierAnimator.lookBack = true;
		updateWeapons = true;
		canSendUnits = true;
		canSendCards = true;
		mNavigationAgent.Stop();
		mNavigationAgent.Reset();
		playerState = PlayerStatex.HidingBehindShield;
		mIsBlind = false;
		mIsBlindTime = 0f;
		if (currentPlayerPoint != null && currentPlayerPoint.point.shield != null)
		{
			currentPlayerPoint.point.shield.player = this;
		}
		if (isCurrentPlayer)
		{
			UICamera.genericEventHandler = base.gameObject;
		}
		foreach (PlayerWeapon allWeapon in weaponInventory.allWeapons)
		{
			allWeapon.ignoreTimeScale = true;
		}
		foreach (AimTarget aimTarget in aimTargets)
		{
			aimTarget.gameObject.SetActive(!isCurrentPlayer);
		}
		swipeArea.gameObject.SetActive(isCurrentPlayer);
		destroyableParts.healthbarColor = ((currentPlayer.fraction == fraction) ? Color.green : Color.red);
		mHitTime = -1f;
		hudObjectIndicator.Show(value: false);
		chanceToNoDamage = 0f;
		isImmortal = false;
		isAlive = true;
		playerBot.enabled = false;
		mNavigationAgent.Disable();
		hudObjectIndicator.Reset();
		movingFreeze = false;
		friendlyKillOver = false;
		networkStatus.active = true;
		mPhotonTransform.Reset();
	}

	public void SelectPrimary()
	{
		PlayerInventory.EquippedWeapon[] weapons = playerProperties.weapons;
		PlayerInventory.EquippedWeapon[] weapons2 = new PlayerInventory.EquippedWeapon[1] { weapons[0] };
		weaponInventory.SetWeapons(weapons2);
		Singleton<AssetBundleManager>.instance.StartCoroutine(weaponInventory.currentWeapon.LoadWeapon());
	}

	public void HideWeapon()
	{
		weaponInventory.currentWeapon.gameObject.SetActive(value: false);
	}

	public void Preview(bool idle)
	{
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotation component2 = GetComponent<TweenRotation>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		mNavigationAgent.Disable();
		StopAllCoroutines();
		if (mMyMaterial != null)
		{
			mSkinnedMeshRenderer.material = mMyMaterial;
		}
		soldierParts.SetAllRigidBodiesToKinematic(value: true);
		soldierParts.shadow.SetActive(value: false);
		soldierAnimator.Reset();
		soldierAnimator.SetIdle(idle ? Weapon.WeaponType.Tool : Weapon.WeaponType.Riffle);
		isPreview = true;
	}

	[PunRPC]
	private void InitBotRPC(byte f)
	{
		isPreview = false;
		fraction = (Fractions)f;
		playerProperties.weapons = null;
		InitPlayer();
		playerNetworkId = 10;
		players[10] = this;
		Debug.Log("Init bot RPC");
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
	}

	private void PlayTrail(DestroyableObject.DamageInfo info, Vector3 from, float time)
	{
		if (isCurrentPlayer && !info.isNetwork)
		{
			if (mPhotonView.isMine)
			{
				Singleton<ShotTrailRenderer>.instance.PlayShot(from, info.hitPosition, time);
				return;
			}
			mPhotonView.RPC("PlayTrailRPC", PhotonTargets.Others, from, info.hitPosition, time);
		}
	}

	[PunRPC]
	private void PlayTrailRPC(Vector3 from, Vector3 to, float time)
	{
		Singleton<ShotTrailRenderer>.instance.PlayShot(from, to, time);
	}

	private void OnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		BattleAnalyticsManager.instance.DoPlayerDamage(this, damageInfo);
		if (DebugSettings.debugPlayerDamage)
		{
			destroyableParts.healthbar.SetText(damageInfo.damageAmount.ToString());
		}
		else
		{
			destroyableParts.healthbar.SetText(string.Empty);
		}
		if (isCurrentPlayer)
		{
			MainGameEntity mainGameEntity = damageInfo.owner as MainGameEntity;
			if (mainGameEntity != null && mainGameEntity != this)
			{
				mainGameEntity.SetRevenge();
			}
		}
		if (damageInfo.type == DestroyableObject.DamageType.Shot)
		{
			PlayerController playerController = damageInfo.owner as PlayerController;
			if (playerController != null)
			{
				Transform spawnPoint = playerController.weaponInventory.currentWeapon.weapon.spawnPoint;
				PlayTrail(damageInfo, spawnPoint.transform.position, 1.2f);
			}
			else
			{
				EnemyController enemyController = damageInfo.owner as EnemyController;
				if (enemyController != null)
				{
					Transform spawnPoint2 = enemyController.soldierBehaviour.currentWeapon.spawnPoint;
					PlayTrail(damageInfo, spawnPoint2.transform.position, 0.6f);
				}
				else
				{
					Drone drone = damageInfo.owner as Drone;
					if (drone != null)
					{
						Transform spawnPoint3 = drone.weapon.weapon.spawnPoint;
						PlayTrail(damageInfo, spawnPoint3.transform.position, 0.6f);
					}
					else
					{
						Turret turret = damageInfo.owner as Turret;
						if (turret != null)
						{
							PlayTrail(damageInfo, turret.turretWeapon.batchedWeapon.weapon.spawnPoint.transform.position, 0.6f);
						}
					}
				}
			}
		}
		if (damageInfo.type == DestroyableObject.DamageType.Poison)
		{
			hudObjectIndicator.Show("game-ico-poison", value: true, HudObjectIndicator.IndicatorAnimation.InfoIco);
			mLastPoison = Time.time;
		}
		if ((UnityEngine.Random.value < chanceToNoDamage || damageInfo.owner == this) && !damageInfo.isNetwork && !isImmortal)
		{
			destroyableParts.health += damageInfo.damageAmount;
			return;
		}
		if (destroyableParts.healthRatio < 0.2f && ((isCurrentPlayer && Singleton<GameController>.instance.isTutorial) || tutorialImmortality))
		{
			destroyableParts.health += damageInfo.damageAmount;
		}
		if (isCurrentPlayer)
		{
			if (damageInfo.damageAmount > 0f)
			{
				float angle = float.MaxValue;
				if (damageInfo.type != DestroyableObject.DamageType.Basic && damageInfo.type != DestroyableObject.DamageType.Poison)
				{
					Singleton<GameCamera>.instance.HitShake();
					DestroyableObject.DamageType type = damageInfo.type;
					if (type == DestroyableObject.DamageType.Explosion || type == DestroyableObject.DamageType.Shiver)
					{
						Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateHeavy);
					}
					else
					{
						Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateMedium);
					}
					Component component = damageInfo.owner as Component;
					if (component != null)
					{
						angle = GeometryTools.AngleSigned(component.transform.position - mTransform.position, Camera.main.transform.forward, Vector3.up);
					}
				}
				GuiScreenSingle<HudScreen>.instance.PlayBloodOverlay(damageInfo.damageAmount, angle);
			}
		}
		else
		{
			destroyableParts.healthbar.Enable();
			destroyableParts.healthbar.FadeIn(1f);
		}
		mHitTime = Time.time;
		hudObjectIndicator.Show("game-neardeath-indicator", IsNearDeath() && !isCurrentPlayer, HudObjectIndicator.IndicatorAnimation.InfoIco);
	}

	private void OnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		hudObjectIndicator.Hide("game-neardeath-indicator", 0f);
		soldierParts.shadow.gameObject.SetActive(value: false);
		if (isAlive)
		{
			AnimateDeath(damageInfo);
		}
		if (isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.FocusPlayer(this, damageInfo.owner is PlayerController);
		}
		mNavigationAgent.Stop();
		OnKilled(destroyableObject, damageInfo);
		Singleton<HitParticleSystem>.instance.HideAllParticles(HitParticles.ParticleType.Blood);
		isAlive = false;
	}

	private void AnimateDeath(DestroyableObject.DamageInfo damageInfo)
	{
		Rigidbody component = soldierParts.body.GetComponent<Rigidbody>();
		DestroyableObjectpart[] parts = destroyableParts.parts;
		foreach (DestroyableObjectpart destroyableObjectpart in parts)
		{
			if (destroyableObjectpart.GetComponent<Rigidbody>() == null)
			{
				destroyableObjectpart.GetComponent<Collider>().enabled = false;
			}
		}
		foreach (Collider ragdollCollider in ragdollColliders)
		{
			ragdollCollider.enabled = true;
		}
		SetLayerRecursively(ragdoll.gameObject, TagsAndLayers.bulletsIgnoreLayer);
		TimeManager.instance.SetupPhysicsTiming(ragdoll: true);
		soldierAnimator.Stop();
		ragdoll.GoRagdoll();
		if (damageInfo.type == DestroyableObject.DamageType.Explosion)
		{
			Vector3 vector = new Vector3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
			component.AddForce(damageInfo.force * 3f, ForceMode.Impulse);
			component.AddTorque(vector.x, vector.y, vector.z, ForceMode.Impulse);
		}
		else
		{
			Vector3 force = damageInfo.force * 6f + Vector3.up * damageInfo.force.magnitude * 0.6f;
			component.AddForce(force, ForceMode.Impulse);
		}
	}

	private void SwipeAreaOnClicked()
	{
		mSwipeStarted = true;
		mStartSwipePos = Input.mousePosition;
	}

	protected override void Update()
	{
		if (isPreview)
		{
			return;
		}
		base.Update();
		if (mPlayerState == PlayerStatex.HidingBehindShield && (mTransform.position - mLastPos).sqrMagnitude > 0.2f)
		{
			mLastPos = mTransform.position;
		}
		if (mLastPoison != 0f && Time.time > mLastPoison + 2.5f)
		{
			Debug.Log("Hide poison");
			hudObjectIndicator.Show("game-ico-poison", value: false, HudObjectIndicator.IndicatorAnimation.InfoIco);
			mLastPoison = 0f;
		}
		if (mIsBlind && Time.time > mIsBlindTime)
		{
			mIsBlind = false;
			hudObjectIndicator.Show("game-ico-blind", value: false, HudObjectIndicator.IndicatorAnimation.InfoIco);
		}
		bool flag = fraction == currentPlayer.fraction;
		if (mHitTime != 0f && Time.time > mHitTime + 3f && !flag && !Singleton<MatchManager>.instance.isOverTime && !Singleton<GameController>.instance.isTutorial)
		{
			mHitTime = 0f;
			destroyableParts.healthbar.FadeOut();
		}
		if (!mPhotonView.isMine && !isCurrentPlayer)
		{
			mPhotonTransform.Update(mTransform);
			soldierAnimator.transform.localRotation = Quaternion.Slerp(soldierAnimator.transform.localRotation, mWantedLookRotation, Time.deltaTime * 12f);
			soldierAnimator.disableLookRot = true;
		}
		if (weaponInventory.currentWeapon.weapon.isReloading)
		{
			if (weaponInventory.weaponIndex != mReloadingWeaponIndex && soldierAnimator.isIdle)
			{
				soldierAnimator.Reload(weaponInventory.currentWeapon.weapon.weaponType);
				mReloadingWeaponIndex = weaponInventory.weaponIndex;
			}
		}
		else
		{
			mReloadingWeaponIndex = null;
		}
		if (Singleton<GameController>.instance.gameIsRunning && mPhotonView.isMine && isAlive && Singleton<GameController>.instance.gameIsRunning)
		{
			soldierAnimator.disableLookRot = false;
			if (isCurrentPlayer)
			{
				if (Input.GetMouseButtonDown(0))
				{
					mSwipeStarted = false;
					AimTarget aimTarget = Singleton<AimingHelper>.instance.AimClickableColliders();
					if (aimTarget != null)
					{
						clicked = true;
					}
				}
				if (Singleton<InputController>.instance.swipeEnded && !mSwipeStarted)
				{
					mStartSwipePos = Singleton<InputController>.instance.swipePosition - Singleton<InputController>.instance.pressPosition;
					float num = Vector3.Angle(mStartSwipePos, Vector3.up);
					if (mStartSwipePos.magnitude > (float)Screen.width * 0.05f && num > 70f)
					{
						clicked = true;
						if (mStartSwipePos.x > 0f)
						{
							GoRight();
						}
						else
						{
							GoLeft();
						}
					}
				}
				if (Input.GetMouseButtonUp(0) && mSwipeStarted)
				{
					mStartSwipePos = Input.mousePosition - mStartSwipePos;
					float num2 = Vector3.Angle(mStartSwipePos, Vector3.up);
					if (mStartSwipePos.magnitude > (float)Screen.width * 0.05f && num2 > 60f)
					{
						clicked = true;
						if (mStartSwipePos.x > 0f)
						{
							GoRight();
						}
						else
						{
							GoLeft();
						}
					}
				}
			}
			if (mPlayerState == PlayerStatex.Walking && mGoToPosition != null && mTransform.position.PlanarDistance(mGoToPosition.point.transform.position) < 0.05f)
			{
				Vector3 toPos = mGoToPosition.point.transform.position;
				toPos.y = mTransform.position.y;
				TweenPosition.Begin(base.gameObject, 0.3f, mTransform.position, toPos, useLocal: false);
				playerState = PlayerStatex.HidingBehindShield;
				TweenRotation.Begin(base.gameObject, 0.5f, mGoToPosition.point.transform.rotation);
				soldierAnimator.lookBack = true;
				Idle();
				mNavigationAgent.Disable();
			}
		}
		if (Singleton<GameController>.instance.gameIsRunning && isCurrentPlayer && weaponInventory.currentWeapon.weapon.outOfAmmo && !clicked && Input.GetMouseButton(0))
		{
			GuiScreenSingle<HudScreen>.instance.ShowNoAmmoMagazine(weaponInventory.currentWeapon);
		}
		else if (Singleton<GameController>.instance.gameIsRunning && isCurrentPlayer && weaponInventory.currentWeapon.weapon.reloadableWeapon && weaponInventory.currentWeapon.weapon.isReloading && !clicked && Input.GetMouseButton(0))
		{
			GuiScreenSingle<HudScreen>.instance.ShowReloadingIco(weaponInventory.currentWeapon);
		}
		if (Singleton<GameController>.instance.gameIsRunning && updateWeapons && !TimeManager.instance.mIsFreezed)
		{
			weaponInventory.currentWeapon.UpdateWeapon();
		}
		else if ((TimeManager.instance.mIsFreezed || !updateWeapons) && Input.GetMouseButtonUp(0))
		{
			weaponInventory.currentWeapon.MouseUpAndNoUpdate();
		}
		if (mPhotonView.isMine)
		{
			UpdateGoLeftRight();
		}
		if (!mPhotonView.isMine)
		{
			soldierAnimator.currentUpperBodyRotation = Mathf.Lerp(soldierAnimator.currentUpperBodyRotation, mWantedUpperBodyRot, Time.deltaTime * 12f);
			soldierAnimator.SetUpperBodyRot(soldierAnimator.currentUpperBodyRotation);
		}
	}

	private void GameControllerOnGameEnded(bool b)
	{
	}

	private void WeaponInventoryOnSelectedWeaponChanged(PlayerWeapon playerWeapon)
	{
		if (playerState == PlayerStatex.HidingBehindShield)
		{
			soldierAnimator.Idle(playerWeapon.weapon.weaponType);
		}
		else if (playerWeapon.weapon.weaponType == Weapon.WeaponType.Bazooka)
		{
			soldierAnimator.BazookaWalk();
		}
		else
		{
			soldierAnimator.Walk(playerWeapon.weapon.weaponType);
		}
	}

	protected virtual void OnKilled(DestroyableObject arg2, DestroyableObject.DamageInfo arg3)
	{
		if (Killed != null)
		{
			Killed(this, arg3);
		}
	}

	public void PlayShotAnimation(Weapon.WeaponType weapon, bool right, Vector3 direction)
	{
		direction.y = 0f;
		if (playerState == PlayerStatex.HidingBehindShield)
		{
			switch (weapon)
			{
			case Weapon.WeaponType.Grenade:
				soldierAnimator.ThrowGrenadeFromCover(!right, ignoreTimescale: true);
				soldierAnimator.LookAt(direction);
				break;
			case Weapon.WeaponType.Bazooka:
				soldierAnimator.ShootFromBazoka(right, ignoreTimeScale: true);
				soldierAnimator.LookAt(direction, 1.5f);
				break;
			default:
				soldierAnimator.ShotFromCover(!right, 4f, 0.4f, ignoreTimeScale: true, weapon);
				soldierAnimator.LookAt(direction);
				break;
			}
		}
		if (playerState == PlayerStatex.Walking)
		{
			switch (weapon)
			{
			case Weapon.WeaponType.Grenade:
				soldierAnimator.ThrowGrenadeFromCover(!right, ignoreTimeScale);
				soldierAnimator.LookAtUpperBody(direction);
				break;
			case Weapon.WeaponType.Bazooka:
				soldierAnimator.ShootFromBazokaWalk();
				soldierAnimator.LookAt(direction, 0.5f);
				break;
			default:
				soldierAnimator.ShootStandAdditive(0.4f);
				soldierAnimator.LookAtUpperBody(direction);
				break;
			}
		}
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("PlayShotAnimationNetwork", PhotonTargets.Others, (byte)weapon, right);
		}
	}

	[PunRPC]
	public void PlayShotAnimationNetwork(byte weapon, bool right)
	{
		if (playerState == PlayerStatex.HidingBehindShield)
		{
			switch (weapon)
			{
			case 1:
				soldierAnimator.ThrowGrenadeFromCover(!right, ignoreTimeScale);
				break;
			case 2:
				soldierAnimator.ShootFromBazoka(right, ignoreTimeScale: true);
				break;
			default:
				soldierAnimator.ShotFromCover(!right, 4f, 0.4f, ignoreTimeScale: true, (Weapon.WeaponType)weapon);
				break;
			}
		}
		if (playerState == PlayerStatex.Walking)
		{
			switch (weapon)
			{
			case 1:
				soldierAnimator.ThrowGrenadeFromCover(!right, ignoreTimeScale);
				break;
			case 2:
				soldierAnimator.ShootFromBazokaWalk();
				break;
			default:
				soldierAnimator.ShootStandAdditive(0.4f);
				break;
			}
		}
	}

	[PunRPC]
	public void Uncover(bool right, bool hideBack)
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Uncover", PhotonTargets.Others, right, hideBack);
		}
		if (playerState == PlayerStatex.HidingBehindShield)
		{
			Weapon.WeaponType weaponType = weaponInventory.currentWeapon.weapon.weaponType;
			if (weaponType == Weapon.WeaponType.Bazooka)
			{
				soldierAnimator.Idle(weaponInventory.currentWeapon.weapon.weaponType);
				soldierAnimator.LookAt(-base.transform.forward, 0.3f);
			}
			else
			{
				soldierAnimator.ShotFromCover(!right, 4f, 0.25f, ignoreTimeScale: true, dontShoot: true, hideBack, weaponInventory.currentWeapon.weapon.weaponType);
			}
		}
		if (playerState == PlayerStatex.Walking)
		{
			soldierAnimator.ShootStandAdditive(0.25f, hideBack);
		}
	}

	[PunRPC]
	private void Idle()
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Idle", PhotonTargets.Others);
		}
		soldierAnimator.Idle(weaponInventory.currentWeapon.weapon.weaponType);
	}

	[PunRPC]
	private void Walk()
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Walk", PhotonTargets.Others);
		}
		soldierAnimator.Walk(weaponInventory.currentWeapon.weapon.weaponType);
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			stream.SendNext(soldierAnimator.mTransform.localRotation.eulerAngles.y);
			stream.SendNext(soldierAnimator.currentUpperBodyRotation);
			stream.SendNext(playerState);
		}
		else
		{
			mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
			float y = (float)stream.ReceiveNext();
			mWantedLookRotation = Quaternion.Euler(0f, y, 0f);
			mWantedUpperBodyRot = (float)stream.ReceiveNext();
			playerState = (PlayerStatex)(int)stream.ReceiveNext();
		}
	}

	public static PlayerController GetEnemyOf(Fractions f)
	{
		if (currentPlayer.fraction != f)
		{
			return currentPlayer;
		}
		foreach (KeyValuePair<int, PlayerController> player in players)
		{
			if (player.Value.fraction != f)
			{
				return player.Value;
			}
		}
		return currentPlayer;
	}

	public static List<PlayerController> GetEnemiesOf(Fractions f)
	{
		List<PlayerController> list = new List<PlayerController>();
		foreach (KeyValuePair<int, PlayerController> player in players)
		{
			if (player.Value.fraction != f && player.Value.networkStatus.active)
			{
				list.Add(player.Value);
			}
		}
		return list;
	}

	public static PlayerController GetRandomEnemy(Fractions f)
	{
		mHelpPlayers.Clear();
		foreach (KeyValuePair<int, PlayerController> player in players)
		{
			if (player.Value.fraction != f && player.Value.networkStatus.active)
			{
				mHelpPlayers.Add(player.Value);
			}
		}
		if (mHelpPlayers.Count > 0)
		{
			return mHelpPlayers[UnityEngine.Random.Range(0, mHelpPlayers.Count)];
		}
		return currentPlayer;
	}

	public static PlayerController GetPlayerOld(Fractions f)
	{
		if (currentPlayer.fraction == f)
		{
			return currentPlayer;
		}
		foreach (KeyValuePair<int, PlayerController> player in players)
		{
			if (player.Value.fraction == f)
			{
				return player.Value;
			}
		}
		if (currentPlayer.fraction != f)
		{
			Debug.LogError("Can not find player with fraction " + f);
		}
		return currentPlayer;
	}

	public static PlayerController GetPlayer(Fractions f)
	{
		if (currentPlayer.fraction == f)
		{
			return currentPlayer;
		}
		foreach (KeyValuePair<int, PlayerController> player in players)
		{
			if (player.Value.fraction == f)
			{
				return player.Value;
			}
		}
		return null;
	}

	public static PlayerController GetFriend(Fractions f)
	{
		foreach (KeyValuePair<int, PlayerController> player in players)
		{
			if (player.Value.fraction == f && !player.Value.isCurrentPlayer)
			{
				return player.Value;
			}
		}
		if (currentPlayer.fraction == f)
		{
			return currentPlayer;
		}
		return null;
	}

	public static PlayerController GetMaster()
	{
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			return currentPlayer;
		}
		return GetFriend(currentPlayer.fraction);
	}

	public static PlayerController GetPlayer(int photonNetworkId)
	{
		players.TryGetValue(photonNetworkId, out var value);
		if (value == null)
		{
			Debug.LogError($"Player with id {photonNetworkId} doesnt exists ! ");
		}
		return value;
	}

	public static PlayerController FindPlayerWithUserId(string userId)
	{
		foreach (KeyValuePair<int, PlayerController> player in players)
		{
			if (player.Value.playerProperties.playerID == userId)
			{
				return player.Value;
			}
		}
		Debug.LogError($"Player with playerId {userId} doesnt exists ! ");
		return null;
	}

	public MapDefinition.DefendPosition GoLeft()
	{
		if (currentPlayerPoint != null)
		{
			return GoLeft(currentPlayerPoint);
		}
		return null;
	}

	public MapDefinition.DefendPosition GoLeft(MapDefinition.DefendPosition point)
	{
		if (movingFreeze || !isAlive || !Singleton<GameController>.instance.gameIsRunning)
		{
			return null;
		}
		mGoRight = false;
		mGoLeft = false;
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition == point)
			{
				break;
			}
		}
		if (num > 0)
		{
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (availablePoints[num2].fraction == fraction && availablePoints[num2].point.shield.player == null)
				{
					mGoLeft = true;
					mGoToPosition = availablePoints[num2];
					mGoToPosition.point.shield.GetLock();
					GoTo(mGoToPosition);
					return mGoToPosition;
				}
			}
		}
		ShowCantMove(-1);
		return null;
	}

	private void GoTo(MapDefinition.DefendPosition position, float delay = 0.02f)
	{
		playerState = PlayerStatex.Walking;
		if (delay > 0f)
		{
			InvokeAfter(delegate
			{
				mNavigationAgent.SetDestination(position.point.transform.position);
			}, delay);
		}
		else
		{
			mNavigationAgent.SetDestination(position.point.transform.position);
		}
		soldierAnimator.lookBack = false;
		Walk();
	}

	private void UpdateGoLeftRight()
	{
		if (!mGoRight && !mGoLeft)
		{
			return;
		}
		if (mGoToPosition.point.shield.lockResult == Shield.LockResult.Success)
		{
			currentPlayerPoint = mGoToPosition;
			if (mPhotonView.isMine)
			{
				mPhotonView.RPC("SetCurrentPoint", PhotonTargets.Others, mCurrentPlayerPoint.index);
			}
			mGoRight = false;
			mGoLeft = false;
		}
		if (mGoToPosition.point.shield.lockResult != Shield.LockResult.Failure)
		{
			return;
		}
		if (mGoRight)
		{
			GoRight(mGoToPosition);
			if (!mGoRight)
			{
				mGoToPosition = currentPlayerPoint;
				GoTo(mGoToPosition);
			}
		}
		if (mGoLeft)
		{
			GoLeft(mGoToPosition);
			if (!mGoLeft)
			{
				mGoToPosition = currentPlayerPoint;
				GoTo(mGoToPosition);
			}
		}
	}

	public MapDefinition.DefendPosition GoRight()
	{
		if (currentPlayerPoint != null)
		{
			return GoRight(currentPlayerPoint);
		}
		return null;
	}

	public MapDefinition.DefendPosition GoRight(MapDefinition.DefendPosition point)
	{
		if (movingFreeze || !isAlive || !Singleton<GameController>.instance.gameIsRunning)
		{
			return null;
		}
		mGoRight = false;
		mGoLeft = false;
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition == point)
			{
				break;
			}
		}
		if (num < availablePoints.Count - 1)
		{
			for (int i = num + 1; i < availablePoints.Count; i++)
			{
				if (availablePoints[i].fraction == fraction && availablePoints[i].point.shield.player == null)
				{
					mGoRight = true;
					mGoToPosition = availablePoints[i];
					mGoToPosition.point.shield.GetLock();
					GoTo(mGoToPosition);
					return mGoToPosition;
				}
			}
		}
		ShowCantMove(1);
		return null;
	}

	private void ShowCantMove(int direction)
	{
		if (playerState != PlayerStatex.Walking)
		{
			Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(base.transform.position);
			Vector3 vector = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			NoMoveIndikator noMoveIndikator = Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.noMoveIndikator, vector, Quaternion.identity) as NoMoveIndikator;
			if (noMoveIndikator != null)
			{
				noMoveIndikator.StartAnimation(direction);
			}
		}
	}

	public void MakeBlind(float time)
	{
		Debug.Log("Stop shooting " + base.name + ", " + Time.time);
		hudObjectIndicator.Show("game-ico-blind", value: true, HudObjectIndicator.IndicatorAnimation.InfoIco);
		mIsBlind = true;
		mIsBlindTime = Time.time + time;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		currentPlayerPoint = null;
	}

	public void SetUpKevlar(float strength = 0.25f)
	{
		Kevlar component = GetComponent<Kevlar>();
		component.kevlarStrength = strength;
		component.SetUpKevlar();
	}

	private void SetupCollisionLayers(Fractions fraction)
	{
		int fractionBulletLayer = Singleton<TagsAndLayers>.instance.GetFractionBulletLayer(fraction, isFlying: false);
		SetLayerRecursively(ragdoll.gameObject, fractionBulletLayer);
	}

	public bool IsNearDeath()
	{
		return destroyableParts.healthRatio <= 0.15f;
	}

	public bool IsDeath()
	{
		return destroyableParts.health <= 0f;
	}

	protected void LateUpdate()
	{
		mIsUp = !Input.GetMouseButton(0);
		if (mIsUp)
		{
			clicked = false;
		}
	}

	private void OnPress(bool pressed)
	{
		if (pressed && Singleton<GameController>.instance.gameIsRunning && UICamera.currentTouch.pressed != base.gameObject)
		{
			mClickedObj = UICamera.currentTouch.pressed;
			clicked = true;
			Singleton<InputController>.instance.CancelClick();
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
	}

	public void ReSync()
	{
		if (isCurrentPlayer)
		{
			destroyableParts.Sync();
		}
	}
}
