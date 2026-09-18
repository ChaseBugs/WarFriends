using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(EnemyBasicInventory))]
public abstract class SoldierBehaviour : LevelBehaviour
{
	public List<SoldierMeshChanger.SoldierStyle> soldierVisuals;

	public List<SoldierMeshChanger.SoldierStyle> eliteSoldierVisuals;

	public List<SoldierMeshChanger.SoldierStyle> cardSoldierVisuals;

	[BitMask(typeof(EnemyPoint.EnemyPointType))]
	public EnemyPoint.EnemyPointType enemyPointType;

	[BitMask(typeof(SpawnPoint.SpawnPointType))]
	public SpawnPoint.SpawnPointType spawnPointType;

	public SoldierParts mSoldierParts;

	protected EnemyBasicInventory mEnemyBasicInventory;

	private NavigationAgent mNavAgent;

	public EnemyController controller;

	public Weapon currentWeapon;

	protected Ammo.ShotType mShotType;

	protected int mShotCounter;

	protected int mFireBatchSize;

	protected bool mUseExternalWeapon;

	protected PhotonView mPhotonView;

	protected BitVector32 mFakeAndRealShots = new BitVector32(0);

	public Vector3 targetPosition;

	protected bool mIsNetworkShoot;

	protected bool mIsNetworCopy;

	private bool mIsNetworkWeapon;

	protected List<Weapon> mWeapons;

	protected bool mUseSecondaryWeapon;

	protected GameShootableEntity.ShotTarget mShotTarget;

	protected SoldierMeshChanger mSoldierMeshChanger => (!(controller != null)) ? null : controller.meshChanger;

	public List<Weapon> allWeapons => mEnemyBasicInventory.weaponInstancies;

	public SoldierBehaviourDefinititon soldierBehaviourDefinititon
	{
		get
		{
			return (SoldierBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	public virtual SoldierBehaviourDefinititon soldierBaseDefinition { get; set; }

	protected bool mHasSeconadryWeapon => mWeapons.Count > 1;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		if (mPhotonView != null)
		{
			mPhotonView.RebuildCache();
		}
	}

	public virtual void UpdateVisual()
	{
		if (controller.spawnedByCard)
		{
			mSoldierMeshChanger.SetSoldierStyle(cardSoldierVisuals);
			List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
			foreach (TechnologyVisualDefinition cardVisual in upgradeSlots.cardVisuals)
			{
				list.Add(cardVisual);
			}
			mSoldierMeshChanger.SetSoldierVisual(list, controller.fraction == PlayerController.currentPlayer.fraction);
			if (upgradeSlots.cardVisuals.Count > 2 && upgradeSlots.cardVisuals[2] != null)
			{
				mEnemyBasicInventory.SetWeaponsUpgrade(GetCardWeaponLevels());
			}
		}
		else
		{
			mSoldierMeshChanger.SetSoldierStyle(GetSoldierVisuals());
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(controller.unitUpgrades);
			mSoldierMeshChanger.SetSoldierVisual(visuals, controller.fraction == PlayerController.currentPlayer.fraction);
			if (visuals.Count > 2 && visuals[2] != null)
			{
				mEnemyBasicInventory.SetWeaponsUpgrade(GetWeaponLevels(controller.unitUpgrades));
			}
		}
	}

	public override IEnumerator PrepareVisualsForGameCoroutine(UpgradeSlots.UnitUpgrades unitUpgrades, bool bought, bool mine, bool unloadWeapon = false)
	{
		if (bought)
		{
			List<SoldierMeshChanger.SoldierStyle> visuals = ((!unitUpgrades.isElite || eliteSoldierVisuals.Count <= 0) ? soldierVisuals : eliteSoldierVisuals);
			foreach (SoldierMeshChanger.SoldierStyle soldierVisual in visuals)
			{
				soldierVisual.LoadModel();
			}
		}
		yield return StartCoroutine(base.PrepareVisualsForGameCoroutine(unitUpgrades, bought, mine));
		if (!bought)
		{
			yield break;
		}
		EnemyBasicInventory inventory = GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[0];
		List<TechnologyVisualDefinition> vis = upgradeSlots.GetVisuals(unitUpgrades);
		if (unloadWeapon)
		{
			foreach (EnemyBasicInventory.InventoryWeapon inventoryWeapon in inventory.weapons)
			{
				EnemyLeveledWeapon[] leveledWeapons = inventoryWeapon.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
				if (leveledWeapons.Length > 0)
				{
					EnemyLeveledWeapon leveledWeapon = leveledWeapons[0];
					leveledWeapon.UnloadModels(vis[2].weaponNumber);
				}
			}
		}
		if (vis.Count > 2 && vis[2] != null)
		{
			yield return StartCoroutine(inventory.PrepareWeaponCoroutine(GetWeaponLevels(unitUpgrades), forCard: false));
		}
		else
		{
			Debug.LogError("bad visuals for" + base.name + "!!!!");
		}
	}

	protected virtual int[] GetWeaponLevels(UpgradeSlots.UnitUpgrades unitUpgrades)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(unitUpgrades);
		return new int[1] { visuals[2].weaponNumber };
	}

	protected virtual int[] GetCardWeaponLevels()
	{
		return new int[1] { upgradeSlots.cardVisuals[2].weaponNumber };
	}

	public override IEnumerator PrepareVisualsForCardCoroutine(bool mine, bool opponent)
	{
		foreach (SoldierMeshChanger.SoldierStyle soldierVisual in cardSoldierVisuals)
		{
			soldierVisual.LoadModel();
		}
		EnemyBasicInventory inventory = GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[0];
		List<TechnologyVisualDefinition> vis = upgradeSlots.cardVisuals;
		if (vis.Count > 2 && vis[2] != null)
		{
			yield return StartCoroutine(inventory.PrepareWeaponCoroutine(GetCardWeaponLevels(), forCard: true));
		}
		else
		{
			Debug.LogError("bad card visuals for" + base.name + "!!!!");
		}
		yield return StartCoroutine(base.PrepareVisualsForCardCoroutine(mine, opponent));
	}

	public override void Init(AIObject aiObject)
	{
		base.Init(aiObject);
		EnemyController enemyController = (EnemyController)aiObject;
		controller = enemyController;
		mSoldierMeshChanger.SetSoldierStyle(GetSoldierVisuals());
		mSoldierParts = controller.GetComponent<SoldierParts>();
		mEnemyBasicInventory = GetComponent<EnemyBasicInventory>();
	}

	public virtual bool AcceptsPoint(EnemyPoint point)
	{
		EnemyPoint.EnemyPointType enemyPointType = this.enemyPointType;
		if (Singleton<GameController>.instance.isTutorial)
		{
			enemyPointType &= ~EnemyPoint.EnemyPointType.Corner;
		}
		return (enemyPointType & point.enemyPointType) == point.enemyPointType && controller.fraction == point.fraction;
	}

	public virtual bool AcceptSpawnPoint(SpawnPoint point)
	{
		return (spawnPointType & point.spawnPointType) == point.spawnPointType && controller.fraction == point.fraction;
	}

	public SpawnPoint PickNormalSPawn(IEnumerable<SpawnPoint> spawns)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint spawn in spawns)
		{
			if (spawn.spawnPointType == SpawnPoint.SpawnPointType.Normal && spawn.fraction == controller.fraction)
			{
				list.Add(spawn);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> spawns)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint spawn in spawns)
		{
			if (AcceptSpawnPoint(spawn))
			{
				list.Add(spawn);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual EnemyPoint GetNewEnemyPoint(EnemyPoint currentEnemyPoint)
	{
		return SpawningManager.instance.GetNextFreeEnemyPoint(currentEnemyPoint, this);
	}

	public virtual EnemyPoint GetInitPoint()
	{
		return SpawningManager.instance.GetPoint(this, 0f);
	}

	public virtual void Shooting()
	{
		if (!currentWeapon.willShoot)
		{
			return;
		}
		if (mEnemyBasicInventory.weaponIndex == 1)
		{
			Shoot(targetPosition, isFake: false);
			controller.OnShot();
			controller.EndShooting();
			InvokeAfter(delegate
			{
				SwitchWeapon(isSecondary: false);
			}, 0.5f);
			return;
		}
		if (mFakeAndRealShots[1 << mShotCounter])
		{
			Shoot(targetPosition, isFake: false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - targetPosition, Vector3.up).normalized * UnityEngine.Random.Range(0.5f, 1f);
			if ((double)UnityEngine.Random.value < 0.5)
			{
				vector = -vector;
			}
			Shoot(targetPosition + vector + new Vector3(0f, 0.5f, 0f), isFake: true);
		}
		controller.OnShot();
		mShotCounter++;
		if (mShotCounter >= mFireBatchSize)
		{
			mShotCounter = 0;
			controller.EndShooting();
		}
	}

	public virtual void PickTarget()
	{
		if (!TryPickDecoy())
		{
			PickRandomOpponent();
		}
	}

	public void UseTurret(Weapon weapon)
	{
		currentWeapon = weapon;
		mUseExternalWeapon = true;
	}

	public void SwitchWeapon(bool isSecondary)
	{
		if (controller.photonView.isMine)
		{
			controller.photonView.RPC("SoldierBehaviourSwitchWeapon", PhotonTargets.Others, isSecondary);
		}
		currentWeapon = mEnemyBasicInventory.SwitchWeapon(isSecondary ? 1 : 0);
	}

	protected virtual void Shoot(Vector3 position, bool isFake)
	{
		currentWeapon.isFake = isFake;
		currentWeapon.disableSync = !mUseExternalWeapon;
		currentWeapon.shotType = mShotType;
		OnBeforeFire();
		if (mIsNetworCopy)
		{
			currentWeapon.FireNetworkRPC(position, isFake, (byte)mShotType);
		}
		else
		{
			currentWeapon.Fire(position);
		}
	}

	protected virtual void OnBeforeFire()
	{
	}

	public virtual bool StartShooting()
	{
		if (mShotTarget == null)
		{
			return false;
		}
		mFireBatchSize = UnityEngine.Random.Range(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon.fireBatchSizeMax);
		mFireBatchSize = Mathf.Clamp(mFireBatchSize, 0, 14);
		mShotCounter = 0;
		mShotType = GetShotType(mShotTarget);
		if (mUseSecondaryWeapon)
		{
			SwitchWeapon(isSecondary: true);
			mFireBatchSize = 1;
			mUseSecondaryWeapon = false;
		}
		mFakeAndRealShots = new BitVector32(0);
		for (int i = 0; i < mFireBatchSize; i++)
		{
			mFakeAndRealShots[1 << i] = UnityEngine.Random.value < soldierBehaviourDefinititon.probabilityOfRealShot;
		}
		mIsNetworkWeapon = currentWeapon as PhysicalAmmoWeapon != null;
		mIsNetworCopy = false;
		PlayerController playerController = mShotTarget.shootableEntity.owner as PlayerController;
		if (playerController != null && !playerController.mPhotonView.isMine)
		{
			mIsNetworCopy = true;
		}
		mIsNetworCopy &= !mIsNetworkWeapon;
		return true;
	}

	public virtual void ShootJustStarted()
	{
		if (controller.photonView.isMine && !mIsNetworkWeapon && !mUseExternalWeapon)
		{
			controller.photonView.RPC("SoldierBehaviourStartShootingNetwork", PhotonTargets.Others, targetPosition, mFakeAndRealShots.Data, !mIsNetworCopy, (byte)mShotType, (byte)mFireBatchSize);
		}
	}

	public void StartShootingNetworkRPC(Vector3 position, int fakeAndRealShotsMask, bool isNetworkCopy, byte shotType, byte batchSize)
	{
		mShotCounter = 0;
		mFakeAndRealShots = new BitVector32(fakeAndRealShotsMask);
		mFireBatchSize = batchSize;
		mIsNetworkShoot = true;
		targetPosition = position;
		mIsNetworCopy = isNetworkCopy;
		mShotType = (Ammo.ShotType)shotType;
	}

	protected override void Update()
	{
		base.Update();
		if (!mIsNetworkShoot || !currentWeapon.willShoot || !controller.isAlive || mEnemyBasicInventory.weaponIndex == 1)
		{
			return;
		}
		if (mFakeAndRealShots[1 << mShotCounter])
		{
			Shoot(targetPosition, isFake: false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - targetPosition, Vector3.up).normalized * UnityEngine.Random.Range(0.3f, 0.5f);
			if ((double)UnityEngine.Random.value < 0.5)
			{
				vector = -vector;
			}
			Shoot(targetPosition + vector + new Vector3(0f, 0.3f, 0f), isFake: true);
		}
		controller.OnShot();
		mShotCounter++;
		if (mShotCounter >= mFireBatchSize)
		{
			mShotCounter = 0;
			controller.EndShooting();
			mIsNetworkShoot = false;
		}
	}

	public virtual void Restart()
	{
		if (controller.photonView.isMine || controller.isPrewiev)
		{
			mWeapons = mEnemyBasicInventory.AttachAllWeapons(mSoldierParts, controller.spawnedByCard, mSoldierMeshChanger);
			currentWeapon = mEnemyBasicInventory.SwitchWeapon(0);
			if (controller.isPrewiev && mWeapons.Count > 1)
			{
				currentWeapon = mEnemyBasicInventory.SwitchWeapon(1);
			}
			SyncWeapons();
			ApplyWeaponsSetup();
		}
		mShotCounter = 0;
		StopAllCoroutines();
		mIsNetworkShoot = false;
		mUseExternalWeapon = false;
	}

	protected void SyncWeapons()
	{
		if (mWeapons != null)
		{
			byte[] array = new byte[mWeapons.Count];
			for (int i = 0; i < mWeapons.Count; i++)
			{
				Weapon weapon = mWeapons[i];
				array[i] = (byte)weapon.indexInObjectPool;
			}
			if (!controller.isPrewiev)
			{
				mPhotonView.RPC("AttachWeaponsRPC", PhotonTargets.Others, array);
			}
		}
	}

	protected virtual void ApplyWeaponsSetup()
	{
		mEnemyBasicInventory.SetOwner(controller);
		mWeapons[0].ammoSetup.damageAmount = soldierBehaviourDefinititon.damage;
		mWeapons[0].ammoSetup.damageToPlayerCoeficient = upgradeSlots.playerDamageRatio;
		mWeapons[0].ammoSetup.damageToPlayerOvertimeCoeficient = upgradeSlots.playerDamageOvertimeRatio;
		mWeapons[0].cadence = 0.35f;
		Gun gun = mWeapons[0] as Gun;
		if (gun != null)
		{
			gun.shotOffset = Vector3.zero;
		}
		foreach (Weapon allWeapon in allWeapons)
		{
			allWeapon.ammoSetup.Reset();
			BulletSetup bulletSetup = allWeapon.ammoSetup as BulletSetup;
			if (bulletSetup != null)
			{
				bulletSetup.speed = soldierBehaviourDefinititon.shotSpeed;
			}
		}
	}

	public override void ReSync()
	{
		base.ReSync();
		SyncWeapons();
	}

	[PunRPC]
	protected virtual void AttachWeaponsRPC(byte[] indices)
	{
		if (mWeapons == null)
		{
			mWeapons = mEnemyBasicInventory.AttachAllWeapons(mSoldierParts, indices, controller.spawnedByCard, mSoldierMeshChanger);
			currentWeapon = mEnemyBasicInventory.SwitchWeapon(0);
			ApplyWeaponsSetup();
		}
	}

	public void ImproveAllWeapons(float fract)
	{
		for (int i = 0; i < mWeapons.Count; i++)
		{
			AmmoSetup ammoSetup = mWeapons[i].ammoSetup;
			ammoSetup.damageAmount = (float)ammoSetup.damageAmount * fract;
		}
	}

	public virtual void DestroyBehaviour()
	{
		mWeapons = null;
		if ((bool)mEnemyBasicInventory)
		{
			mEnemyBasicInventory.DestroyWeapons();
		}
		if ((bool)mSoldierMeshChanger)
		{
			mSoldierMeshChanger.NullTexturesAndMeshes();
		}
	}

	protected void PickRandomOpponent(UnitType unitType, GameShootableEntity.ShotTargetType shotTargetType = GameShootableEntity.ShotTargetType.AllIn)
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(controller.fraction, unitType);
		GameShootableEntity gameShootableEntity;
		if (opponents.Count > 0)
		{
			gameShootableEntity = opponents[UnityEngine.Random.Range(0, opponents.Count)];
		}
		else
		{
			opponents = GameShootableEntity.GetOpponents(controller.fraction, GameShootableEntity.anyUnit);
			if (opponents.Count <= 0)
			{
				PickPlayerOpponent(upgradeSlots.shieldHitProbability);
				return;
			}
			gameShootableEntity = opponents[UnityEngine.Random.Range(0, opponents.Count)];
		}
		if (!(gameShootableEntity == null))
		{
			if (mEnemyBasicInventory.weaponIndex == 1)
			{
				targetPosition = gameShootableEntity.transform.position;
			}
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(shotTargetType);
			int index = UnityEngine.Random.Range(0, shotTargets.Count);
			if (shotTargets.Count == 0 && shotTargetType != GameShootableEntity.ShotTargetType.AllIn)
			{
				shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn);
			}
			if (shotTargets.Count > 0)
			{
				targetPosition = shotTargets[index].transform.position;
				mShotTarget = shotTargets[index];
			}
		}
	}

	protected void PickRandomOpponent()
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.PickRandomOponentOf(controller.fraction);
		if (gameShootableEntity == null)
		{
			return;
		}
		if (gameShootableEntity.owner is PlayerController)
		{
			PickPlayerOpponent();
			return;
		}
		if (mEnemyBasicInventory.weaponIndex == 1)
		{
			targetPosition = mShotTarget.transform.position;
		}
		List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn);
		int index = UnityEngine.Random.Range(0, shotTargets.Count);
		mShotTarget = shotTargets[index];
		targetPosition = mShotTarget.transform.position;
	}

	protected bool TryPickDecoy()
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents<Decoy>(controller.fraction);
		if (opponents.Count == 0)
		{
			return false;
		}
		GameShootableEntity gameShootableEntity = opponents[UnityEngine.Random.Range(0, opponents.Count)];
		List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.All);
		mShotTarget = shotTargets[UnityEngine.Random.Range(0, shotTargets.Count)];
		targetPosition = mShotTarget.transform.position;
		return true;
	}

	protected Ammo.ShotType GetShotType(GameShootableEntity.ShotTarget target)
	{
		if (target != null && target.type == GameShootableEntity.ShotTargetType.Shield)
		{
			return Ammo.ShotType.Shield;
		}
		return Ammo.ShotType.Real;
	}

	protected void PickPlayerOpponent(float shieldProb = 0.5f)
	{
		if (shieldProb < 0f)
		{
			return;
		}
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(controller.fraction);
		GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
		float num = Vector3.Angle(randomEnemy.aimForward, controller.mTransform.position - gameShootableEntity.mTransform.position);
		if (randomEnemy.playerState == PlayerController.PlayerStatex.Walking)
		{
			shieldProb *= 0.5f;
		}
		bool flag = false;
		if (num > 50f || UnityEngine.Random.value <= shieldProb)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.Shield);
			if (shotTargets.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, shotTargets.Count);
				mShotTarget = shotTargets[index];
				targetPosition = mShotTarget.transform.position;
				flag = true;
			}
		}
		if (!flag)
		{
			if (randomEnemy.playerState == PlayerController.PlayerStatex.Walking)
			{
				mShotTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.ShotTargetType.Moving, controller.mTransform.position);
				targetPosition = Singleton<AimingHelper>.instance.PredictPosition(currentWeapon, mShotTarget.transform.position, gameShootableEntity.velocity, 0.1f);
			}
			else
			{
				mShotTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.ShotTargetType.WholeBody, controller.mTransform.position);
				targetPosition = mShotTarget.transform.position;
			}
		}
	}

	public virtual void StartEnemyBehaviour()
	{
		if (controller.spawnPoint is SpawnPointParachute)
		{
			controller.StartEnemyBehaviour(EnemyController.EnemyAIState.Parachute);
		}
		else
		{
			controller.StartEnemyBehaviour(EnemyController.EnemyAIState.Walk);
		}
	}

	public virtual void OnDeath(DestroyableObject.DamageInfo damageInfo)
	{
	}

	public override void Unload()
	{
		base.Unload();
		foreach (SoldierMeshChanger.SoldierStyle soldierVisual in soldierVisuals)
		{
			soldierVisual.UnloadModel();
		}
		foreach (SoldierMeshChanger.SoldierStyle eliteSoldierVisual in eliteSoldierVisuals)
		{
			eliteSoldierVisual.UnloadModel();
		}
		foreach (SoldierMeshChanger.SoldierStyle cardSoldierVisual in cardSoldierVisuals)
		{
			cardSoldierVisual.UnloadModel();
		}
		EnemyBasicInventory enemyBasicInventory = GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[0];
		if (Singleton<GameController>.instance.gameState != GameController.GameState.Menu)
		{
			return;
		}
		foreach (EnemyBasicInventory.InventoryWeapon weapon in enemyBasicInventory.weapons)
		{
			EnemyLeveledWeapon[] componentsInChildren = weapon.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
			if (componentsInChildren.Length > 0)
			{
				EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
				enemyLeveledWeapon.UnloadModels(-1);
			}
		}
	}

	public virtual void StandShoot()
	{
		controller.StartStandShoot();
	}

	private List<SoldierMeshChanger.SoldierStyle> GetSoldierVisuals()
	{
		return (!controller.unitUpgrades.isElite || eliteSoldierVisuals.Count <= 0) ? soldierVisuals : eliteSoldierVisuals;
	}
}
