using System;
using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using CodeStage.AntiCheat.ObscuredTypes;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class TutorialManagerStage1 : TutorialManagerBase
{
	public const string id = "Stage1";

	private static TutorialManagerStage1 mInstance;

	private List<EnemyController> botSoldiers = new List<EnemyController>();

	private List<EnemyController> enemiesToKill = new List<EnemyController>();

	private EnemyController firstShotgunner;

	public bool isShooted;

	private int mAlreadyKilledUnits;

	private int mAssaultRifleShots;

	private bool mCanUpdateSpawned;

	private bool mGrenadeExploded;

	private bool mGrenaderShot;

	private Vector3 mParatrooperPosition;

	private MapDefinition.DefendPosition mPoint;

	private bool mSpawnTut;

	private bool mSpawnTutShotguners;

	private int mSpawnedSoldiers;

	private bool prepareUnitsInvoked;

	private bool mWaitingForSendUnit;

	private WeaponLevelsSetup mTutorialWeapon;

	private PlayerInventory.InventorySlot mSlotForTutorialWeapon;

	private EnemyController mEnemyForHoldAnimation;

	private Vector3 mEnemyForHoldAnimationPosition;

	private int mBotSpawnedUnitPower = 4;

	private int weaponBoughtState;

	public static TutorialManagerStage1 instance
	{
		get
		{
			mInstance = mInstance ?? ((TutorialManagerStage1)UnityEngine.Object.FindObjectsOfType(typeof(TutorialManagerStage1))[0]);
			return mInstance;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		mCanUpdateSpawned = false;
	}

	private void OnGameEnded(GameController.GameEndReason obj)
	{
		mCanUpdateSpawned = false;
		SpawningManagerDeathMatch spawningManagerDeathMatch = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(spawningManagerDeathMatch.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(StartSpawning));
		SpawningManagerDeathMatch spawningManagerDeathMatch2 = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch2.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(spawningManagerDeathMatch2.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(FinishSpawning));
		Singleton<GameController>.instance.GameEnded -= OnGameEnded;
		Singleton<TutorialProgressShower>.instance.CheckNum(0, playSound: false);
		StopAllCoroutines();
		if (mPlayerBotTutorial != null)
		{
			UnityEngine.Object.Destroy(mPlayerBotTutorial);
			mPlayerBotTutorial = null;
		}
		if (base.isTutorialRunning)
		{
			GameLoginManager.instance.TryPresetStartingCurrency();
			Singleton<SpawningManagerDeathMatch>.instance.baseCoolDown = 2f;
			if (Singleton<GameController>.instance.gameEndReason != GameController.GameEndReason.Forfeit)
			{
				Singleton<EventTrackingManager>.instance.RegisterTutorialGameEnded("118 GAME END");
				LevelManager.instance.SetLevelUpProgressForTutorial(2, 0f, levelUp: true);
				Singleton<Wallet>.instance.SetRewardForTutorial(500, 1);
				StartCoroutine(RadicalRoutine.Run(MenuPartCorutine()));
			}
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
		}
	}

	protected override void AfterSpawned(AIObject aiObject)
	{
		base.AfterSpawned(aiObject);
		if (!base.isTutorialRunning)
		{
			return;
		}
		if (!mSpawnTut && aiObject.fraction == Fractions.Allies)
		{
			mSpawnTut = true;
		}
		if (mSpawnTutShotguners && aiObject.fraction == Fractions.Allies)
		{
			mSpawnTutShotguners = false;
		}
		if (!(aiObject is EnemyController) || aiObject.fraction != Fractions.Allies)
		{
			return;
		}
		EnemyController enemyController = (EnemyController)aiObject;
		if (enemyController.soldierBehaviour is SoldierBehaviourShotgunner)
		{
			if (firstShotgunner == null)
			{
				firstShotgunner = enemyController;
			}
			Debug.Log("Shotgunner spawned");
			enemyController.SetMaxHealthAndRefill(1500f);
			ShotGunBulletSetup shotGunBulletSetup = (ShotGunBulletSetup)enemyController.soldierBehaviour.currentWeapon.ammoSetup;
			shotGunBulletSetup.maxDamage = 3000f;
			shotGunBulletSetup.minDamage = 300f;
		}
		if (enemyController.soldierBehaviour is SoldierBehaviourSniper)
		{
			if (firstShotgunner == null)
			{
				firstShotgunner = enemyController;
			}
			BulletSetup bulletSetup = (BulletSetup)enemyController.soldierBehaviour.currentWeapon.ammoSetup;
			bulletSetup.damageAmount = 100f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 1f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 3f;
		}
		if (enemyController.soldierBehaviour is SoldierBehaviourMachineGunner)
		{
			BulletSetup bulletSetup2 = (BulletSetup)enemyController.soldierBehaviour.currentWeapon.ammoSetup;
			bulletSetup2.damageAmount = 40f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 1f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 1f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 4;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 4;
		}
		if (enemyController.soldierBehaviour is SoldierBehaviourGrennader)
		{
			GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)enemyController.soldierBehaviour.allWeapons[1].ammoSetup;
			grenadeAmmoSetup.explodeDamageAmount = 100f;
			grenadeAmmoSetup.explodeAfterTime = 1f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 0.2f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 0.2f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.switchToSecondaryProb = 1f;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 3;
			enemyController.onShoot += OnShoot;
		}
		if (!mCanUpdateSpawned)
		{
			return;
		}
		TutorialMapDefinition component = Singleton<MapManager>.instance.currentMapDef.GetComponent<TutorialMapDefinition>();
		List<SpawnPoint> spawnPoints = Singleton<MapManager>.instance.currentMapDef.spawnPointsCollection.spawnPoints;
		int num = mSpawnedSoldiers % 2;
		for (int num2 = spawnPoints.Count - 1; num2 >= 0; num2--)
		{
			if (spawnPoints[num2].fraction == Fractions.Allies && spawnPoints[num2].spawnPointType == SpawnPoint.SpawnPointType.Normal && --num < 0)
			{
				Vector3 spawnPosForMachinegunner = GetSpawnPosForMachinegunner(mSpawnedSoldiers);
				enemyController.transform.position = spawnPosForMachinegunner;
				enemyController.transform.rotation = spawnPoints[num2].transform.rotation;
				if (enemyController.soldierBehaviour is SoldierBehaviourGrennader)
				{
					enemyController.SetStateTo(EnemyController.EnemyAIState.Walk, component.firstUnitTargets[mSpawnedSoldiers]);
				}
				if (enemyController.soldierBehaviour is SoldierBehaviourSniper)
				{
					enemyController.SetStateTo(EnemyController.EnemyAIState.Walk, component.firstUnitTargets[mSpawnedSoldiers + 2]);
				}
				break;
			}
		}
		mSpawnedSoldiers++;
	}

	private Vector3 GetSpawnPosForMachinegunner(int machineGunner)
	{
		Camera main = Camera.main;
		float num = main.fieldOfView * 0.5f * main.aspect * 1.05f;
		Vector3 vector = main.transform.forward * 5.9f;
		vector.y = 0f;
		Quaternion quaternion = Quaternion.AngleAxis(num * (float)((machineGunner <= 0) ? 1 : (-1)), Vector3.up);
		Vector3 sourcePosition = main.transform.position + quaternion * vector;
		sourcePosition.y = -2.579f;
		NavMesh.SamplePosition(sourcePosition, out var hit, 20f, 1);
		return hit.position;
	}

	private void OnGameStarted()
	{
		if (base.isTutorialRunning)
		{
			GuiElementSingle<InventoryGuiElement>.instance.Hide();
			if (mPlayerBotTutorial != null)
			{
				mPlayerBotTutorial.Init();
			}
			Singleton<GameController>.instance.opponent.destroyableParts.healthbar.Disable();
			InvokeAfterFrame(delegate
			{
				GuiElementSingle<InventoryGuiElement>.instance.SetWeaponsShowed(0);
			});
		}
	}

	public override void StartTutorial(bool isContinue)
	{
		base.StartTutorial(isContinue);
		PrepareDataForTutorial();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("101 LOADING MAP");
		MapDefinition currentMapDef = Singleton<MapManager>.instance.currentMapDef;
		PhotonLevelIDChanger component = currentMapDef.GetComponent<PhotonLevelIDChanger>();
		PhotonView[] views = component.views;
		foreach (PhotonView photonView in views)
		{
			if (photonView.name.StartsWith("barrelDesert"))
			{
				photonView.gameObject.SetActive(value: false);
			}
		}
		SetPlayerDefaultWeapons();
		data.started = true;
		Save();
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		StopAllCoroutines();
		mSpawnTut = false;
		mSpawnTutShotguners = false;
		mCanUpdateSpawned = false;
		SpawningManagerDeathMatch spawningManagerDeathMatch = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(spawningManagerDeathMatch.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(StartSpawning));
		SpawningManagerDeathMatch spawningManagerDeathMatch2 = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch2.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(spawningManagerDeathMatch2.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(FinishSpawning));
		StartCoroutine(RadicalRoutine.Run(Tutorial(Singleton<GameController>.instance.opponent)));
		Weapon.OnShotFired += WeaponOnOnShotFired;
	}

	private void PrepareDataForTutorial()
	{
		LevelManager.instance.SetLevelUpProgressForTutorial(1, 0f, levelUp: false);
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private IEnumerator Tutorial(PlayerController playerController)
	{
		playerController.playerBot.enabled = false;
		mPlayerBotTutorial = playerController.gameObject.AddComponent<PlayerBotTutorial>();
		mPlayerBotTutorial.playerController.destroyableParts.maxHealth = 300f;
		mPlayerBotTutorial.playerController.destroyableParts.Refill();
		PlayerController.currentPlayer.destroyableParts.maxHealth = 2000f;
		PlayerController.currentPlayer.destroyableParts.RefillOffline();
		mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.Wait;
		PlayerController.GetEnemyOf(Fractions.Allies).tutorialImmortality = true;
		PlayerController.currentPlayer.tutorialImmortality = true;
		Singleton<TutorialProgressShower>.instance.Hide();
		yield return StartCoroutine(RadicalRoutine.Run(MovementTutorial()));
		StartCoroutine(RadicalRoutine.Run(CheckAmmo()));
		yield return StartCoroutine(RadicalRoutine.Run(RifleTutorial()));
		yield return StartCoroutine(RadicalRoutine.Run(ShowEnemy()));
		yield return StartCoroutine(RadicalRoutine.Run(LearnSendingUnits()));
		prepareUnitsInvoked = false;
		yield return StartCoroutine(RadicalRoutine.Run(KillingUnitTutorial()));
	}

	private IEnumerator ShowEnemy()
	{
		PlayerController.currentPlayer.movingFreeze = true;
		while (PlayerController.currentPlayer.playerState != PlayerController.PlayerStatex.HidingBehindShield)
		{
			yield return null;
		}
		yield return new WaitForRealSeconds(1f);
		Singleton<TutorialProgressShower>.instance.Hide();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("109 STAGE 3 STARTED");
		FreezeEnemies();
		PlayerController.currentPlayer.updateWeapons = false;
		PlayerController.currentPlayer.movingFreeze = true;
		Singleton<GameController>.instance.opponent.destroyableParts.healthbar.Enable();
		Singleton<GameController>.instance.opponent.destroyableParts.healthbar.FadeIn(0.1f);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampEnemyPresent);
		Singleton<GameCamera>.instance.FocusEnemyPlayerTutorial(PlayerController.GetEnemyOf(Fractions.Allies));
		yield return new WaitForRealSeconds(2f);
		GuiElementSingle<PlayerHealthBars>.instance.TutorialShowEnemy();
		GuiScreenSingle<HudScreen>.instance.ShowKillEnemyHint();
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_BIG_REVEAL_UP", string.Empty, 0.3f, TutorialDialog.DialogPosition.Center, showContinue: true);
		PlayerController.currentPlayer.updateWeapons = false;
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("110 STAGE 3 CONTINUE");
		GuiScreenSingle<HudScreen>.instance.HideKillEnemyHint();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampWoosh);
		Singleton<GameCamera>.instance.UnfocusTutorial();
		yield return new WaitForRealSeconds(2f);
	}

	private IEnumerator CheckAmmo()
	{
		while (true)
		{
			if (PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoLeft < 41)
			{
				PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoLeft = 100;
			}
			yield return new WaitForRealSeconds(2f);
		}
	}

	private void OnShoot(EnemyController enemy)
	{
		isShooted = true;
		enemy.onShoot -= OnShoot;
		enemy.allowShoot = false;
		SoldierBehaviour soldierBehaviour = enemy.soldierBehaviour;
		if (soldierBehaviour is SoldierBehaviourGrennader && enemy.fraction == Fractions.Enemies)
		{
			enemy.soldierBehaviour.soldierBehaviourDefinititon.switchToSecondaryProb = 0.2f;
			enemy.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 4f;
			enemy.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 6f;
			enemy.GenerateNextShootTime();
			mGrenaderShot = true;
		}
		if (soldierBehaviour is SoldierBehaviourGrennader && enemy.fraction == Fractions.Allies)
		{
			enemy.soldierBehaviour.soldierBehaviourDefinititon.switchToSecondaryProb = 0.7f;
			enemy.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 2f;
			enemy.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 3f;
			enemy.GenerateNextShootTime();
			enemy.allowShoot = true;
		}
		if (soldierBehaviour is SoldierBehaviourBazooka)
		{
			enemy.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 4f;
			enemy.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 6f;
			enemy.GenerateNextShootTime();
		}
	}

	private IEnumerator MovementTutorial()
	{
		mGrenaderShot = false;
		PlayerController.currentPlayer.movingFreeze = true;
		mPoint = PlayerController.currentPlayer.currentPlayerPoint;
		while (Singleton<GameController>.instance.gameState != GameController.GameState.Playing)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0f);
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("102 GAME STARTED");
		GuiElementSingle<PlayerHealthBars>.instance.TutorialShowPlayer();
		List<MapDefinition.DefendPosition> shieldPoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		for (int i = 0; i < shieldPoints.Count; i++)
		{
			shieldPoints[i].point.shield.maxHealth = 400f;
			shieldPoints[i].point.shield.Refill();
		}
		Singleton<ScoreManager>.instance.killStreakScoreRatio = 0f;
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_WELCOME_UP", string.Empty, 0.3f, TutorialDialog.DialogPosition.Center, showContinue: true);
		PlayerController.currentPlayer.updateWeapons = false;
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		mPlayerBotTutorial.playerController.currentPlayerPoint.point.shield.isImmortal = true;
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("103 STAGE 1 CONTINUE");
		GuiElementSingle<TutorialDialog>.instance.Hide();
		mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.Wait;
		if (enemiesToKill == null)
		{
			enemiesToKill = new List<EnemyController>();
		}
		else
		{
			enemiesToKill.Clear();
		}
		isShooted = false;
		EnemyController enemy = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[4]);
		if (enemy != null && enemy.prefab != null)
		{
			enemy.fraction = Fractions.Enemies;
			int prefabIndex = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemy.prefab];
			enemy = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(prefabIndex, enemy.indexInObjectPool);
			enemy.onShoot += OnShoot;
			enemy.StartEnemyBehaviour();
			enemy.power = 0;
			enemiesToKill.Add(enemy);
			enemy.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 0.1f;
			enemy.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 0.2f;
			enemy.transform.position = enemy.enemyPoint.position;
			ObscuredFloat myDmg = ((BulletSetup)PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoSetup).damageAmount;
			enemy.SetMaxHealthAndRefill((float)myDmg * 4.5f);
		}
		InvokeAfterRealTime(delegate
		{
			enemy = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[6]);
			if (enemy != null && enemy.prefab != null)
			{
				enemy.fraction = Fractions.Enemies;
				int i3 = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemy.prefab];
				enemy = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(i3, enemy.indexInObjectPool);
				enemy.soldierBehaviour.soldierBehaviourDefinititon.switchToSecondaryProb = 1f;
				enemy.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 0f;
				enemy.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 0.2f;
				enemy.onShoot += OnShoot;
				enemy.StartEnemyBehaviour();
				enemy.power = 0;
				enemy.SetMaxHealthAndRefill(1000f);
				enemiesToKill.Add(enemy);
			}
		}, 1f);
		while (!isShooted)
		{
			yield return null;
		}
		yield return new WaitForFixedUpdate();
		yield return new WaitForSeconds(1.5f);
		yield return new WaitForFixedUpdate();
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_COVER"), 2);
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorialDirectly(Localization.LocalizeFormat("ID_TUTORIAL_SWIPE_UP", mPlayerBotTutorial.playerController.playerProperties.name), Localization.Localize("ID_TUTORIAL_SWIPE_DOWN"), 0.15f);
		Vector3 playerWorldPosition = PlayerController.currentPlayer.destroyableParts.parts[1].transform.position;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(playerWorldPosition, playerWorldPosition + PlayerController.currentPlayer.transform.right * 0.7f, 0.3f, isGui: false);
		RadicalRoutine swipeShield = RadicalRoutine.Create(UpdateSwipeShieldAnimation());
		StartCoroutine(RadicalRoutine.Run(swipeShield.enumerator));
		FreezeEnemies();
		PlayerController.currentPlayer.movingFreeze = false;
		while (PlayerController.currentPlayer.currentPlayerPoint == mPoint)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("104 STAGE 1 COVER 1");
		Singleton<TutorialProgressShower>.instance.CheckNum(0);
		swipeShield.Cancel();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		UnfreezeEnemies();
		mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.Wait;
		while (PlayerController.currentPlayer.playerState != PlayerController.PlayerStatex.HidingBehindShield)
		{
			yield return null;
		}
		GuiElementSingle<InventoryGuiElement>.instance.Show();
		GuiElementSingle<InventoryGuiElement>.instance.SetWeaponsShowed(8);
		PlayerController.currentPlayer.updateWeapons = true;
		PlayerController.currentPlayer.weaponInventory.cannotChange = false;
		PlayerController.currentPlayer.weaponInventory.currentWeapon = PlayerController.currentPlayer.weaponInventory.usedWeapons[0];
		PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.clipSize = 20;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoLeft = 100;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoLeftInClip = 20;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.reloadTime = 1f;
		mAssaultRifleShots = 0;
		PlayerClickWeapon w = (PlayerClickWeapon)PlayerController.currentPlayer.weaponInventory.usedWeapons[0];
		w.autofire = false;
		while (!mGrenaderShot)
		{
			yield return null;
		}
		mPoint = PlayerController.currentPlayer.currentPlayerPoint;
		EnemyController e = enemiesToKill[1];
		if (e != null)
		{
			float ratio = e.destroyableObj.healthRatio;
			e.destroyableObj.maxHealth = 100f;
			e.destroyableObj.health = 100f * ratio;
		}
		yield return new WaitForFixedUpdate();
		yield return new WaitForSeconds(0.7f);
		yield return new WaitForFixedUpdate();
		playerWorldPosition = PlayerController.currentPlayer.destroyableParts.parts[1].transform.position;
		bool isLeft = PlayerController.currentPlayer.currentPlayerPoint.index == 4;
		Debug.Log("Shield index: " + PlayerController.currentPlayer.currentPlayerPoint.index + "isLeft " + isLeft);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(playerWorldPosition, playerWorldPosition + PlayerController.currentPlayer.transform.right * ((!isLeft) ? 0.7f : (-0.7f)), 0.3f, isGui: false);
		swipeShield = RadicalRoutine.Create(UpdateSwipeShieldAnimation(isLeft));
		StartCoroutine(RadicalRoutine.Run(swipeShield.enumerator));
		mGrenadeExploded = false;
		Weapon.OnShotHit += WeaponOnOnShotHit;
		bool playerAvoidedGrenadeOnFirstTry = false;
		while (!mGrenadeExploded)
		{
			if (PlayerController.currentPlayer.currentPlayerPoint != mPoint)
			{
				playerAvoidedGrenadeOnFirstTry = true;
				break;
			}
			yield return null;
		}
		if (PlayerController.currentPlayer.currentPlayerPoint == mPoint)
		{
			playerAvoidedGrenadeOnFirstTry = false;
			yield return new WaitForRealSeconds(2f);
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_SWIPE_UP2", "ID_TUTORIAL_SWIPE_DOWN", 0.3f);
			FreezeEnemies();
			PlayerController.currentPlayer.movingFreeze = false;
			PlayerController.currentPlayer.updateWeapons = false;
			while (PlayerController.currentPlayer.currentPlayerPoint == mPoint)
			{
				yield return null;
			}
			PlayerController.currentPlayer.updateWeapons = true;
			Singleton<TutorialProgressShower>.instance.CheckNum(1);
			GuiElementSingle<TutorialDialog>.instance.Hide();
			UnfreezeEnemies();
		}
		else
		{
			Singleton<TutorialProgressShower>.instance.CheckNum(1);
			yield return new WaitForRealSeconds(1f);
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialCoverEvent("105 STAGE 1 COVER 2", playerAvoidedGrenadeOnFirstTry);
		swipeShield.Cancel();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
		Weapon.OnShotHit -= WeaponOnOnShotHit;
		mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.Wait;
		yield return new WaitForRealSeconds(1f);
		Singleton<TutorialProgressShower>.instance.Hide();
		for (int i2 = 0; i2 < enemiesToKill.Count; i2++)
		{
			enemiesToKill[i2].allowShoot = true;
		}
	}

	private void WeaponOnOnShotHit(Weapon weapon, Ammo ammo, Vector3 vector3, bool isNetwork, DestroyableObject hit)
	{
		if (weapon is Grenade)
		{
			mGrenadeExploded = true;
		}
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 vector3)
	{
		if (weapon == PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon)
		{
			mAssaultRifleShots++;
		}
	}

	private IEnumerator RifleTutorial()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("106 STAGE 2 STARTED");
		int killedCount = 0;
		foreach (EnemyController e in enemiesToKill)
		{
			if (!e.isAlive)
			{
				killedCount++;
			}
		}
		for (int i = 0; i < killedCount; i++)
		{
			Debug.Log("Generating extra enemy");
			EnemyController enemy = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[0]);
			if (enemy != null && enemy.prefab != null)
			{
				enemy.fraction = Fractions.Enemies;
				int prefabIndex = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemy.prefab];
				enemy = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(prefabIndex, enemy.indexInObjectPool);
				enemy.StartEnemyBehaviour();
				enemy.power = 0;
				enemiesToKill.Add(enemy);
			}
		}
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING"), 2);
		StartCoroutine(RadicalRoutine.Run(CheckIfPlayerShootsWithAssaultRifle()));
		yield return new WaitForSeconds(1f);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapingSoldier(int.MaxValue);
		yield return StartCoroutine(RadicalRoutine.Run(CheckKilled(1, killedCount)));
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("107 STAGE 2 KILLED 1. SOLDIER");
		Singleton<TutorialProgressShower>.instance.CheckNum(0);
		yield return StartCoroutine(RadicalRoutine.Run(CheckKilled(2, killedCount)));
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("108 STAGE 2 KILLED 2. SOLDIER");
		Singleton<TutorialProgressShower>.instance.CheckNum(1);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapingSoldier();
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING_SCOPE"), 1);
		enemiesToKill.Clear();
		TutorialMapDefinition tut = Singleton<MapManager>.instance.currentMapDef.GetComponent<TutorialMapDefinition>();
		EnemyController machinegunner = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[9]);
		if (machinegunner != null && machinegunner.prefab != null)
		{
			machinegunner.fraction = Fractions.Enemies;
			int prefabIndex2 = ObjectPoolDatabase.networkPool.prefabToIndexDic[machinegunner.prefab];
			machinegunner.DisableSpawn();
			Transform sp = tut.spawnForMachinegunner.transform;
			machinegunner = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(prefabIndex2, machinegunner.indexInObjectPool, sp.position, sp.rotation);
			machinegunner.StartEnemyBehaviour(EnemyController.EnemyAIState.Walk, tut.machinegunnerPoint);
			machinegunner.canChangePosition = false;
			machinegunner.power = 0;
			enemiesToKill.Add(machinegunner);
			machinegunner.agent.speed = 1f;
			machinegunner.SetMaxHealthAndRefill(machinegunner.destroyableObject.maxHealth * 2.5f);
			machinegunner.destroyableObj.isImmortal = true;
		}
		mEnemyForHoldAnimation = machinegunner;
		yield return new WaitForSeconds(4.2f);
		foreach (EnemyController enemyController in enemiesToKill)
		{
			enemyController.destroyableObj.isImmortal = false;
		}
		PlayerClickWeapon w = (PlayerClickWeapon)PlayerController.currentPlayer.weaponInventory.usedWeapons[0];
		w.autofire = true;
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_KILLING_SCOPE", "ID_TUTORIAL_KILLING_SCOPE_DOWN", 0f, TutorialDialog.DialogPosition.Right);
		mEnemyForHoldAnimationPosition = mEnemyForHoldAnimation.destroyableObj.transform.position + mEnemyForHoldAnimation.destroyableObj.transform.up * 0.38f;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(mEnemyForHoldAnimationPosition, isGui: false);
		RadicalRoutine holdAnimationUpdater = RadicalRoutine.Create(UpdateHoldAnimationForEnemy());
		StartCoroutine(RadicalRoutine.Run(holdAnimationUpdater.enumerator));
		yield return StartCoroutine(RadicalRoutine.Run(CheckKilled(1, 0)));
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("108B STAGE 2 KILLED SOLDIER SCOPE");
		Singleton<TutorialProgressShower>.instance.CheckNum(0);
		holdAnimationUpdater.Cancel();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
	}

	private IEnumerator CheckKilled(int count, int extra)
	{
		while (true)
		{
			int killedCount = 0;
			foreach (EnemyController e in enemiesToKill)
			{
				if (!e.isAlive)
				{
					killedCount++;
				}
			}
			if (killedCount >= count + extra)
			{
				break;
			}
			yield return null;
		}
	}

	private IEnumerator CheckIfPlayerShootsWithAssaultRifle()
	{
		yield return new WaitForRealSeconds(5f);
		if (mAssaultRifleShots < 2)
		{
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_RIFLE_UP", "ID_TUTORIAL_RIFLE_DOWN", -0.3f);
			TimeManager.FreezeGame();
			PlayerController.currentPlayer.updateWeapons = false;
			while (!Input.GetMouseButton(0))
			{
				yield return null;
			}
			PlayerController.currentPlayer.updateWeapons = true;
			GuiElementSingle<InventoryGuiElement>.instance.HideHintText();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			TimeManager.UnFreezeGame(0f);
		}
	}

	private IEnumerator UpdateHoldAnimationForEnemy()
	{
		while (true)
		{
			if (mEnemyForHoldAnimation != null)
			{
				mEnemyForHoldAnimationPosition = mEnemyForHoldAnimation.destroyableObj.transform.position + mEnemyForHoldAnimation.destroyableObj.transform.up * 0.38f;
			}
			if (Input.GetMouseButtonUp(0))
			{
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(mEnemyForHoldAnimationPosition, isGui: false);
			}
			else if (Input.GetMouseButtonDown(0))
			{
				GuiElementSingle<TutorialOverlayGuiElement>.instance.InstantStopHoldAnimation();
			}
			else
			{
				GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateHoldAnimation(mEnemyForHoldAnimationPosition, isGui: false);
			}
			yield return null;
		}
	}

	private IEnumerator KillingUnitTutorial()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("115 STAGE 5 STARTED");
		StartCoroutine(RadicalRoutine.Run(BotSpawningsUnits()));
		mPlayerBotTutorial.playerController.tutorialImmortality = true;
		ApplyPowersToEnemies();
		mSpawnTut = false;
		Singleton<SpawningManagerDeathMatch>.instance.powerLeft = 0;
		mBotSpawnedUnitPower = 4;
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> armyUnityDefinitions = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
		{
			new Tuple<int, int>(6, 0),
			new Tuple<int, int>(6, 1)
		});
		DeathMatchUnitsGuiElement.instance.onSendUnit += OnSendUnit;
		mWaitingForSendUnit = true;
		Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(armyUnityDefinitions);
		Singleton<SpawningManagerDeathMatch>.instance.powerLeft = 0;
		yield return new WaitForSeconds(2.5f);
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2"), 1);
		DeathMatchUnitsGuiElement.instance.guiCards[0].powerProgress.StartTutorialAnimation(0);
		DeathMatchUnitsGuiElement.instance.guiCards[1].powerProgress.StartTutorialAnimation(1);
		if (mWaitingForSendUnit && (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft < 2)
		{
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_KILLING2", string.Empty, 0f, TutorialDialog.DialogPosition.Center, showContinue: true, showDeployIcon: true);
			TimeManager.FreezeGame();
			PlayerController.currentPlayer.updateWeapons = false;
			while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
			{
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapingSoldier(int.MaxValue);
			GuiElementSingle<TutorialDialog>.instance.Hide();
			TimeManager.UnFreezeGame(0f);
		}
		PlayerController.currentPlayer.updateWeapons = true;
		while ((int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft < 2 && mWaitingForSendUnit)
		{
			yield return null;
		}
		if (mWaitingForSendUnit)
		{
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapingSoldier();
			yield return new WaitForRealSeconds(0.5f);
			DeathMatchUnitsGuiElement.instance.ShowHintText(show: true);
			Vector3 guiUnitPos = DeathMatchUnitsGuiElement.instance.guiCards[1].transform.position + new Vector3(0.05f, 0.05f, 0f);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(guiUnitPos);
			GuiElementSingle<TutorialFade>.instance.SetAndShow(DeathMatchUnitsGuiElement.instance.transform.parent.position, new Vector3(1140f, 1100f, 0f), Vector3.zero);
			DeathMatchUnitsGuiElement.instance.guiCards[0].powerProgress.StopTutorialAnimation();
			DeathMatchUnitsGuiElement.instance.guiCards[1].powerProgress.StopTutorialAnimation();
			TimeManager.Begin(0.5f, 1f, 0.2f);
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
			while (mWaitingForSendUnit)
			{
				yield return null;
			}
			TimeManager.Begin(0.5f, 0.2f, 1f);
		}
		DeathMatchUnitsGuiElement.instance.onSendUnit -= OnSendUnit;
		mBotSpawnedUnitPower = 1;
		GuiElementSingle<TutorialFade>.instance.Hide();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("116 STAGE 5 CONTINUE");
		StartCoroutine(SpawnCheck(-0.1f));
		while (!mSpawnTut)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("117 STAGE 5 SPAWNED");
		DeathMatchUnitsGuiElement.instance.ShowHintText(show: false);
		mPlayerBotTutorial.playerController.tutorialImmortality = false;
		yield return new WaitForSeconds(1f);
		Singleton<TutorialProgressShower>.instance.Hide();
	}

	private IEnumerator KillEnemyTutorial()
	{
		if (!prepareUnitsInvoked)
		{
			yield return new WaitForSeconds(2f);
		}
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_FINISHHIM", string.Empty, 0f, TutorialDialog.DialogPosition.Center, showContinue: true);
		TimeManager.FreezeGame();
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		GuiElementSingle<TutorialDialog>.instance.Hide();
		TimeManager.UnFreezeGame(0f);
		int checkNum = 0;
		if (!mSpawnTut)
		{
			Vector3 shotgunnerPosition = DeathMatchUnitsGuiElement.instance.guiCards[2].transform.position;
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(shotgunnerPosition + new Vector3(0.05f, 0.05f, 0f));
			while (!mSpawnTut)
			{
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			checkNum++;
		}
		yield return new WaitForSeconds(1f);
	}

	private void BotSoldierKilled(IGameMainEntity unit, DestroyableObject.DamageInfo demage)
	{
		unit.Killed -= BotSoldierKilled;
		if (demage.owner == null || demage.owner.fraction == Fractions.Allies)
		{
			mAlreadyKilledUnits++;
		}
	}

	private IEnumerator BotSpawningsUnits()
	{
		mAlreadyKilledUnits = 0;
		if (botSoldiers == null)
		{
			botSoldiers = new List<EnemyController>();
		}
		else
		{
			for (int i = 0; i < botSoldiers.Count; i++)
			{
				botSoldiers[i].Killed -= BotSoldierKilled;
			}
			botSoldiers.Clear();
		}
		while (mPlayerBotTutorial.playerController.isAlive)
		{
			for (int i2 = botSoldiers.Count - 1; i2 >= 0; i2--)
			{
				if (!botSoldiers[i2].isAlive || botSoldiers[i2].fraction != Fractions.Enemies)
				{
					botSoldiers.RemoveAt(i2);
				}
			}
			if (botSoldiers.Count < 3)
			{
				int add = 1;
				if (prepareUnitsInvoked)
				{
					add = 11;
				}
				if (UnityEngine.Random.Range(0, add + botSoldiers.Count * botSoldiers.Count * botSoldiers.Count) == 0)
				{
					int toSpawn = UnityEngine.Random.Range(1, 3);
					int type = UnityEngine.Random.Range(0, 3);
					if (type == 1)
					{
						type = 9;
					}
					if (type == 0)
					{
						toSpawn++;
					}
					for (int j = 0; j < toSpawn; j++)
					{
						EnemyController enemy = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[type]);
						if (enemy != null && enemy.prefab != null)
						{
							enemy.fraction = Fractions.Enemies;
							int prefabIndex = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemy.prefab];
							enemy = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(prefabIndex, enemy.indexInObjectPool);
							enemy.power = mBotSpawnedUnitPower;
							enemy.StartEnemyBehaviour();
							botSoldiers.Add(enemy);
							enemy.power = mBotSpawnedUnitPower;
							enemy.Killed -= BotSoldierKilled;
							enemy.Killed += BotSoldierKilled;
						}
					}
				}
			}
			yield return new WaitForRealSeconds(0.25f);
		}
	}

	private void StartSpawning(Fractions fract, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (fract == Fractions.Allies)
		{
			SpawningManagerDeathMatch spawningManagerDeathMatch = Singleton<SpawningManagerDeathMatch>.instance;
			spawningManagerDeathMatch.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(spawningManagerDeathMatch.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(StartSpawning));
			mCanUpdateSpawned = true;
			mSpawnedSoldiers = 0;
		}
	}

	private void FinishSpawning(Fractions fract, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (fract == Fractions.Allies)
		{
			SpawningManagerDeathMatch spawningManagerDeathMatch = Singleton<SpawningManagerDeathMatch>.instance;
			spawningManagerDeathMatch.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(spawningManagerDeathMatch.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(FinishSpawning));
			mCanUpdateSpawned = false;
		}
	}

	private EnemyController CreateEnemyWithBehavior(LevelBehaviour behaviour, bool isPreview = false)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(behaviour);
		if (enemyController != null && enemyController.prefab != null)
		{
			enemyController.fraction = Fractions.Allies;
			enemyController.isPrewiev = isPreview;
			int i = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemyController.prefab];
			enemyController = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(i, enemyController.indexInObjectPool);
			if (isPreview)
			{
				enemyController.UpdatePreview(inGame: true);
			}
			return enemyController;
		}
		return null;
	}

	private IEnumerator LearnSendingUnits()
	{
		mPlayerBotTutorial.playerController.currentPlayerPoint.point.shield.isImmortal = true;
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("111 STAGE 4 STARTED");
		List<EnemyController> myUnits = new List<EnemyController>(4)
		{
			CreateEnemyWithBehavior(LevelManager.instance.behaviours[9], isPreview: true),
			CreateEnemyWithBehavior(LevelManager.instance.behaviours[6], isPreview: true),
			CreateEnemyWithBehavior(LevelManager.instance.behaviours[1], isPreview: true)
		};
		Vector3 myPosition = PlayerController.currentPlayer.transform.position;
		myPosition.x += ((!ScreenManager.isSmallScreen) ? 1.4f : 1.85f);
		myPosition.z -= 0.75f;
		for (int i = 0; i < myUnits.Count; i++)
		{
			myUnits[i].transform.position = myPosition;
			myUnits[i].transform.rotation = Quaternion.Euler(0f, 120f - (float)i * 30f, 0f);
			myPosition.z += 0.5f;
			if (i == 0)
			{
				myPosition.x += 0.2f;
			}
			if (i == 1)
			{
				myPosition.x -= 0.2f;
			}
		}
		float fixedTime = Time.fixedDeltaTime;
		yield return new WaitForRealSeconds(0.5f);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampUnitPresent);
		Singleton<GameCamera>.instance.SetFollowedActive(followed: false);
		Transform cameraTransform = Singleton<GameCamera>.instance.transform;
		float steps = 1.5f / fixedTime;
		float stepSize = 2f / steps;
		while (steps > 1f)
		{
			cameraTransform.Translate(0f, 0f, 0f - stepSize);
			steps -= 1f;
			yield return new WaitForFixedUpdate();
		}
		cameraTransform.Translate(0f, 0f, (0f - stepSize) * steps);
		yield return new WaitForRealSeconds(1f);
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_ARMYEXPLAIN_UP", string.Empty, 0.5f, TutorialDialog.DialogPosition.Center, showContinue: true);
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("112 STAGE 4 CONTINUE");
		GuiElementSingle<TutorialDialog>.instance.Hide();
		Singleton<GameCamera>.instance.SetFollowedActive(followed: true);
		for (int j = 0; j < myUnits.Count; j++)
		{
			myUnits[j].DestroyPooled(1f);
		}
		yield return new WaitForSeconds(1.5f);
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_UNITS"), 2);
		SpawningManagerDeathMatch spawningManagerDeathMatch = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(spawningManagerDeathMatch.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(StartSpawning));
		SpawningManagerDeathMatch spawningManagerDeathMatch2 = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch2.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(spawningManagerDeathMatch2.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(FinishSpawning));
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_GRENADERS_UP", "ID_TUTORIAL_GRENADERS_DOWN", 0f);
		GuiElementSingle<TutorialDialog>.instance.blinkText = false;
		GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("game-tutorial-grenadier", "menu-army-cat-explosive");
		Singleton<SpawningManagerDeathMatch>.instance.isTutorial = true;
		mSpawnTut = false;
		DeathMatchUnitsGuiElement.instance.TutorialSetCards();
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> grenadierArmyUnitDefinitions = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
		{
			new Tuple<int, int>(7, 1)
		});
		Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(grenadierArmyUnitDefinitions);
		Singleton<SpawningManagerDeathMatch>.instance.powerLeft = 4;
		Singleton<SpawningManagerDeathMatch>.instance.baseCoolDown = 16f;
		DeathMatchUnitsGuiElement.instance.deployEnergyElement.shouldUpdate = true;
		yield return new WaitForRealSeconds(2f);
		Vector3 guiUnitPos = DeathMatchUnitsGuiElement.instance.guiCards[0].transform.position + new Vector3(0.05f, 0.05f, 0f);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(guiUnitPos);
		while (!mSpawnTut)
		{
			yield return null;
		}
		mPlayerBotTutorial.playerController.currentPlayerPoint.point.shield.isImmortal = false;
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("113 STAGE 4 SPAWN 1 DONE");
		try
		{
			Singleton<TutorialProgressShower>.instance.CheckNum(0);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			PlayerController.currentPlayer.updateWeapons = true;
			PlayerController.currentPlayer.movingFreeze = false;
			UnfreezeEnemies();
			mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.Wait;
		}
		catch (Exception ex)
		{
			Crittercism.LogHandledException(ex);
			Debug.LogError(ex.Message);
			Debug.LogError(ex.StackTrace);
		}
		while (mPlayerBotTutorial.playerController.currentPlayerPoint == null || mPlayerBotTutorial.playerController.currentPlayerPoint.point == null || mPlayerBotTutorial.playerController.currentPlayerPoint.point.shield == null || mPlayerBotTutorial.playerController.currentPlayerPoint.point.shield.healthRatio > 0.01f)
		{
			yield return null;
		}
		try
		{
			List<PoolableObject> enemies = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
			Crittercism.LeaveBreadcrumb("Going generate units");
			foreach (PoolableObject poolableObject in enemies)
			{
				EnemyController enemy = poolableObject as EnemyController;
				if (enemy != null && enemy.soldierBehaviour != null && enemy.soldierBehaviour is SoldierBehaviourGrennader && enemy.soldierBehaviour.soldierBehaviourDefinititon != null)
				{
					if (enemy.soldierBehaviour.allWeapons != null && enemy.soldierBehaviour.allWeapons.Count > 1)
					{
						GrenadeAmmoSetup setup = (GrenadeAmmoSetup)enemy.soldierBehaviour.allWeapons[1].ammoSetup;
						setup.explodeDamageAmount = 50f;
						setup.explodeAfterTime = 2f;
					}
					enemy.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 2f;
					enemy.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 4f;
					enemy.soldierBehaviour.soldierBehaviourDefinititon.switchToSecondaryProb = 0.2f;
					enemy.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
					enemy.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 4;
				}
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
		try
		{
			Crittercism.LeaveBreadcrumb("Units generated");
			FreezeEnemies();
			Crittercism.LeaveBreadcrumb("Enemies Freezed");
			PlayerController.currentPlayer.updateWeapons = false;
			PlayerController.currentPlayer.movingFreeze = true;
			SpawningManagerDeathMatch spawningManagerDeathMatch3 = Singleton<SpawningManagerDeathMatch>.instance;
			spawningManagerDeathMatch3.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(spawningManagerDeathMatch3.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(StartSpawning));
			SpawningManagerDeathMatch spawningManagerDeathMatch4 = Singleton<SpawningManagerDeathMatch>.instance;
			spawningManagerDeathMatch4.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(spawningManagerDeathMatch4.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(FinishSpawning));
			Crittercism.LeaveBreadcrumb("Showing dialog");
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_MACHINEGUNNERS_UP", "ID_TUTORIAL_MACHINEGUNNERS_DOWN", 0f);
			GuiElementSingle<TutorialDialog>.instance.blinkText = false;
			GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("game-tutorial-minigunner", "menu-army-cat-shooter");
			Singleton<SpawningManagerDeathMatch>.instance.isTutorial = true;
			mSpawnTut = false;
			DeathMatchUnitsGuiElement.instance.TutorialSetCards();
			grenadierArmyUnitDefinitions = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
			{
				new Tuple<int, int>(13, 1)
			});
			Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(grenadierArmyUnitDefinitions);
			Singleton<SpawningManagerDeathMatch>.instance.baseCoolDown = 16f;
		}
		catch (Exception e2)
		{
			Crittercism.LogHandledException(e2);
		}
		yield return new WaitForRealSeconds(2f);
		guiUnitPos = DeathMatchUnitsGuiElement.instance.guiCards[0].transform.position + new Vector3(0.05f, 0.05f, 0f);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(guiUnitPos);
		while (!mSpawnTut)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("114 STAGE 4 SPAWN 2 DONE");
		Singleton<TutorialProgressShower>.instance.CheckNum(1);
		PlayerController.currentPlayer.updateWeapons = true;
		PlayerController.currentPlayer.movingFreeze = false;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		UnfreezeEnemies();
		mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.ShootEnemies;
		yield return new WaitForRealSeconds(1.5f);
		Singleton<TutorialProgressShower>.instance.Hide();
		float maxTime = TimeManager.realTimeWithoutPauses + 10f;
		while (mPlayerBotTutorial.playerController.destroyableParts.healthRatio > 0.6f && maxTime > TimeManager.realTimeWithoutPauses)
		{
			yield return null;
		}
	}

	private void ApplyPowersToEnemies()
	{
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == Fractions.Enemies && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.power = 4;
			}
			if (enemyController.fraction == Fractions.Allies && enemyController.soldierBehaviour is SoldierBehaviourMachineGunner)
			{
				BulletSetup bulletSetup = (BulletSetup)enemyController.soldierBehaviour.currentWeapon.ammoSetup;
				bulletSetup.damageAmount = 20f;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = 1f;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = 4f;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 4;
			}
		}
	}

	private IEnumerator WaitShotgunerIsIN()
	{
		firstShotgunner = null;
		while (firstShotgunner == null)
		{
			yield return null;
		}
		while (!firstShotgunner.isInField)
		{
			yield return null;
		}
		PlayerController.GetEnemyOf(Fractions.Allies).tutorialImmortality = false;
		yield return new WaitForSeconds(1f);
		Singleton<TutorialProgressShower>.instance.Hide();
	}

	private IEnumerator UpdateSwipeShieldAnimation(bool isLeft = false)
	{
		while (true)
		{
			Vector3 playerWorldPosition = PlayerController.currentPlayer.destroyableParts.parts[1].transform.position;
			GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(playerWorldPosition, playerWorldPosition + PlayerController.currentPlayer.transform.right * ((!isLeft) ? 0.7f : (-0.7f)), isGui: false);
			yield return new WaitForRealSeconds(0.1f);
		}
	}

	internal void LoadData(string jsonData)
	{
		SerializedObject = JsonConvert.DeserializeObject<TutorialData>(jsonData);
	}

	public void CheckAfterDownload()
	{
		if (weaponBoughtState > 0 && base.isTutorialRunning)
		{
			LevelManager.instance.CheckCurrentLevelForTutorial(2);
			if (weaponBoughtState < 3)
			{
				mTutorialWeapon.bought = false;
			}
		}
	}

	private IEnumerator MenuPartCorutine()
	{
		weaponBoughtState = 1;
		ArmyPreviewCamera.rotationEnabled = false;
		WeaponPreviewCamera.rotationEnabled = false;
		UIDraggablePanel.panelDisabled = true;
		foreach (WeaponLevelsSetup v in LevelManager.instance.weaponLevelsSetups)
		{
			if (v.isTutorialWeapon)
			{
				mTutorialWeapon = v;
				v.bought = false;
				break;
			}
		}
		if (mTutorialWeapon == null)
		{
			Debug.LogError("There is no weapon selected as tutorial weapon!!!!!!!");
		}
		foreach (PlayerInventory.InventorySlot inventorySlot in PlayerInventory.instance.inventorySlots)
		{
			if (mTutorialWeapon.weaponCategory == (inventorySlot.category & mTutorialWeapon.weaponCategory))
			{
				mSlotForTutorialWeapon = inventorySlot;
			}
		}
		mSlotForTutorialWeapon.weaponIndex = -1;
		while (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
		{
			yield return null;
		}
		while (!GuiElementSingle<LevelUpDialog>.instance.completeAnimation)
		{
			yield return null;
		}
		GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("120 MENU LEVEL UP SHOWN");
		yield return new WaitForSeconds(0.1f);
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_2"), Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_2_DOWN"), -0.2f, TutorialDialog.DialogPosition.Right, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.items[0].tutorialHandPosition.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.items[0].centerObject.transform.position, GuiElementSingle<LevelUpDialog>.instance.items[0].itemCollider.size, showBlueOverlay: false);
		while (GuiElementSingle<LevelUpDialog>.instance.isShowed)
		{
			yield return null;
		}
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide(0.4f);
		while (!GuiScreenSingle<WeaponScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("121 MENU WEAPON SCREEN SHOWN");
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		bool selectedWrongCategory = false;
		bool selectedWrongWeapon = false;
		if (mTutorialWeapon.weaponCategory != (mTutorialWeapon.weaponCategory & GuiScreenSingle<WeaponScreen>.instance.selectedCategory))
		{
			selectedWrongCategory = true;
			GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_3"), Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_3_DOWN"), 0.25f, TutorialDialog.DialogPosition.Center, useCollider: false);
			Vector3 pos = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[2].transform.position;
			Transform bg = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[2].background.transform;
			if (bg != null)
			{
				pos.x += bg.lossyScale.x * 0.5f;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(pos);
			GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(pos, bg.localScale);
			while (mTutorialWeapon.weaponCategory != (mTutorialWeapon.weaponCategory & GuiScreenSingle<WeaponScreen>.instance.selectedCategory))
			{
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		}
		if (GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup != mTutorialWeapon)
		{
			selectedWrongWeapon = false;
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(0.5f);
			GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_GO_TO_ARMORY_4", 0.25f);
			WeaponGuiRecord tutorialWeaponGui = null;
			Vector3 globalPos = Vector3.zero;
			Vector3 size = Vector3.one;
			List<WeaponGuiRecord> allWeapons = GuiScreenSingle<WeaponScreen>.instance.weaponIcons;
			if (allWeapons != null)
			{
				foreach (WeaponGuiRecord v2 in allWeapons)
				{
					if (v2.weaponSetup == mTutorialWeapon)
					{
						tutorialWeaponGui = v2;
						globalPos = tutorialWeaponGui.transform.position;
						size = tutorialWeaponGui.GetComponent<BoxCollider>().size;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(globalPos);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size);
						break;
					}
				}
			}
			while (GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup != mTutorialWeapon)
			{
				if (tutorialWeaponGui != null && tutorialWeaponGui.transform.position != globalPos)
				{
					globalPos = tutorialWeaponGui.transform.position;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(globalPos);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size);
				}
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("122 MENU WEAPON SCREEN TUTORIAL WEAPON SELECTED", selectedWrongCategory, selectedWrongWeapon);
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(0.5f);
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_5"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_BUY")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.warbucksIcon.cachedTransform.position, new Vector3(40f, -56f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.rightButton, showBlueOverlay: false);
		while (GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup.weaponState == WeaponLevelsSetup.State.NotBuyed)
		{
			yield return null;
		}
		weaponBoughtState = 2;
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("123 MENU WEAPON SCREEN TUTORIAL WEAPON BUY CLICKED");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds((!GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup.bought) ? 1.1f : 0.55f);
		if (!GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup.bought)
		{
			bool playerWaitedTillDeliveryEnds = false;
			GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_DELIVER"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_DELIVERNOW")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.buttonDeliverNowPart.transform.position, new Vector3(40f, -56f, 0f));
			GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.rightButton, showBlueOverlay: false);
			bool canChange = true;
			while (!GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup.bought)
			{
				if (canChange && GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup.weaponState == WeaponLevelsSetup.State.WeaponDelivered)
				{
					canChange = false;
					playerWaitedTillDeliveryEnds = true;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
					GuiElementSingle<TutorialDialog>.instance.Hide();
					GuiElementSingle<TutorialClickOverlay>.instance.Hide();
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					yield return new WaitForSeconds(1.1f);
					GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_DELIVERED_WEAPON"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_ACTIVATION")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.buttonActivatePart.transform.position, new Vector3(40f, -56f, 0f));
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.rightButton, showBlueOverlay: false);
				}
				yield return false;
			}
			weaponBoughtState = 3;
			Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("124 MENU WEAPON SCREEN TUTORIAL WEAPON ACTIVATED", playerWaitedTillDeliveryEnds);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(0.5f);
		}
		weaponBoughtState = 4;
		bool automaticEquip = true;
		if (mSlotForTutorialWeapon.weaponLevelsSetup != GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup)
		{
			automaticEquip = false;
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(0.55f);
			GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_6"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_GUI_EQUIP")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.equipButton.transform.position);
			GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.equipButton, showBlueOverlay: false);
			while (mSlotForTutorialWeapon.weaponLevelsSetup != GuiScreenSingle<WeaponScreen>.instance.selectedIcon.weaponSetup)
			{
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(0.5f);
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("125 MENU WEAPON SCREEN TUTORIAL WEAPON EQUIPPED", automaticEquip);
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.backButton.transform.position, new Vector3(0f, -25f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.backButton);
		GuiElementSingle<TutorialClickOverlay>.instance.StartBorderAnimation();
		yield return new WaitForSeconds(0.55f);
		while (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			yield return null;
		}
		SavingLastSelected.instance.SaveLastWeapon(LevelManager.instance.weaponLevelsSetups[1]);
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("126 MENU BATTLE SCREEN SHOWN");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_8"), Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_8_DOWN"), 0.1f, TutorialDialog.DialogPosition.Right, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.playerVsPlayerButton.positionForTutorialHand.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.playerVsPlayerButton.pvpButton);
		while (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("127 NEXT TUTORIAL STARTING");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		UIDraggablePanel.panelDisabled = false;
		ArmyPreviewCamera.rotationEnabled = true;
		WeaponPreviewCamera.rotationEnabled = true;
		weaponBoughtState = 0;
	}

	private void OnSendUnit()
	{
		if (mWaitingForSendUnit)
		{
			mWaitingForSendUnit = false;
		}
	}

	public void EquipTutorialWeaponAfterSkipTutorial()
	{
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.isTutorialWeapon)
			{
				mTutorialWeapon = weaponLevelsSetup;
				weaponLevelsSetup.bought = true;
				break;
			}
		}
		if (mTutorialWeapon == null)
		{
			return;
		}
		mTutorialWeapon.bought = true;
		int num = LevelManager.instance.weaponLevelsSetups.FindIndex((WeaponLevelsSetup w1) => w1.GetSheetName() == mTutorialWeapon.GetSheetName());
		if (num < 0)
		{
			return;
		}
		foreach (PlayerInventory.InventorySlot inventorySlot in PlayerInventory.instance.inventorySlots)
		{
			if (mTutorialWeapon.weaponCategory == (inventorySlot.category & mTutorialWeapon.weaponCategory))
			{
				inventorySlot.weaponIndex = num;
			}
		}
	}
}
