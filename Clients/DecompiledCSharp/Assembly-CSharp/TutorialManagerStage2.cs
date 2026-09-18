using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;

[Skip]
public class TutorialManagerStage2 : TutorialManagerBase
{
	public const string id = "Stage2";

	private static TutorialManagerStage2 mInstance;

	private bool mAssalterKilled;

	private int mAssaltersKilledNotGrenade;

	private AIObject mFirstParatrooper;

	private List<AIObject> mParatroopers = new List<AIObject>();

	private bool mGameStarted;

	private Vector3 mGrenadeArea;

	private Vector3 mParatrooperPosition;

	private int mSniperKilled;

	private int mSniperRifleShots;

	private LevelBehaviour mTutorialUnit;

	private int mUnitBoughtState;

	public static TutorialManagerStage2 instance
	{
		get
		{
			mInstance = mInstance ?? Object.FindObjectOfType<TutorialManagerStage2>();
			return mInstance;
		}
	}

	public override bool autoDeployEnabled => true;

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	private void OnGameStarted()
	{
		mGameStarted = true;
		if (base.isTutorialRunning)
		{
			Singleton<GameController>.instance.opponent.destroyableParts.healthbar.Enable();
			Singleton<GameController>.instance.opponent.destroyableParts.healthbar.FadeIn(0.1f);
		}
	}

	private void OnGameEnded(GameController.GameEndReason obj)
	{
		if (base.isTutorialRunning)
		{
			GameLoginManager.instance.TryPresetStartingCurrency();
			Weapon.OnShotFired -= WeaponOnOnShotFired;
			StopAllCoroutines();
			if (Singleton<GameController>.instance.gameEndReason != GameController.GameEndReason.Forfeit)
			{
				Singleton<EventTrackingManager>.instance.RegisterTutorialGameEnded("210 GAME END");
				LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, levelUp: true);
				Singleton<Wallet>.instance.SetRewardForTutorial(1000, 2);
				StartCoroutine(RadicalRoutine.Run(Menu()));
			}
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
			Singleton<TutorialProgressShower>.instance.Disable();
			Debug.Log("*****   Bootcamp 2/3 Ended   *****");
		}
	}

	private IEnumerator Menu()
	{
		ArmyPreviewCamera.rotationEnabled = false;
		WeaponPreviewCamera.rotationEnabled = false;
		UIDraggablePanel.panelDisabled = true;
		yield return StartCoroutine(RadicalRoutine.Run(BuyTutorialUnit()));
		UIDraggablePanel.panelDisabled = false;
		ArmyPreviewCamera.rotationEnabled = true;
		WeaponPreviewCamera.rotationEnabled = true;
		mUnitBoughtState = 0;
	}

	public override void StartTutorial(bool isContinue)
	{
		base.StartTutorial(isContinue);
		PrepareDataForTutorial();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("201 LOADING MAP");
		SetPlayerDefaultWeapons(enableRifle: true, enableSniper: true);
		PlayerController.currentPlayer.weaponInventory.cannotChange = false;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoLeft = 5;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoLeftInClip = 5;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.cadence = 1f;
		PlayerController.currentPlayer.updateWeapons = true;
		if (isContinue)
		{
			data.gold = (int)Singleton<Wallet>.instance.gold;
			data.wb = (int)Singleton<Wallet>.instance.warBucks;
		}
		else if (data.gold != 0 && data.wb != 0)
		{
			Singleton<Wallet>.instance.SetTutorialCurrency(data.wb, data.gold);
		}
		data.started = true;
		Save();
		mSniperRifleShots = 0;
		Weapon.OnShotFired += WeaponOnOnShotFired;
		Singleton<TutorialProgressShower>.instance.Disable();
		StartCoroutine(RadicalRoutine.Run(WeaponGrenadeTutorial()));
		Debug.Log("*****   Bootcamp 2/3 Started   *****");
	}

	private void PrepareDataForTutorial()
	{
		LevelManager.instance.SetLevelUpProgressForTutorial(2, 0f, levelUp: false);
		PlayerController.currentPlayer.playerProperties.level = 2;
		PlayerController.GetEnemyOf(PlayerController.currentPlayer.fraction).playerProperties.level = 2;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void ParachuteKilled(IGameMainEntity enemy, DestroyableObject.DamageInfo damage)
	{
		if (PlayerController.currentPlayer.weaponInventory.currentWeapon == PlayerController.currentPlayer.weaponInventory.usedWeapons[1])
		{
			mSniperKilled++;
		}
		enemy.Killed -= ParachuteKilled;
	}

	private IEnumerator UpdateHoldSniperShoot()
	{
		while (true)
		{
			if (Input.GetMouseButtonUp(0))
			{
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(mParatrooperPosition, isGui: false);
			}
			else if (Input.GetMouseButtonDown(0))
			{
				GuiElementSingle<TutorialOverlayGuiElement>.instance.InstantStopHoldAnimation();
			}
			else
			{
				GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateHoldAnimation(mParatrooperPosition, isGui: false);
			}
			yield return null;
		}
	}

	private IEnumerator SpawnParatroopers(int count = 1)
	{
		mParatroopers.Clear();
		for (int i = 0; i < count; i++)
		{
			AIObject enemy = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[5]);
			if (enemy != null && enemy.prefab != null)
			{
				enemy.fraction = Fractions.Enemies;
				int prefabIndex = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemy.prefab];
				enemy = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(prefabIndex, enemy.indexInObjectPool);
				enemy.power = 0;
				enemy.StartEnemyBehaviour();
				enemy.destroyableObj.maxHealth = 100f;
				enemy.destroyableObj.Refill();
				enemy.Killed -= ParachuteKilled;
				enemy.Killed += ParachuteKilled;
				EnemyController soldier = (EnemyController)enemy;
				BulletSetup setup = (BulletSetup)soldier.soldierBehaviour.currentWeapon.ammoSetup;
				setup.damageAmount = (float)setup.damageAmount * 0.1f;
				mParatroopers.Add(enemy);
				if (i == 0)
				{
					mFirstParatrooper = enemy;
					mFirstParatrooper.destroyableObj.isImmortal = true;
				}
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	private IEnumerator SniperExplain()
	{
		mSniperKilled = 0;
		yield return StartCoroutine(SpawnParatroopers());
		Singleton<TutorialProgressShower>.instance.Hide();
		Debug.LogError(mFirstParatrooper.transform.position.y);
		while (mFirstParatrooper.transform.position.y > -1.990423f)
		{
			yield return null;
		}
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_SNIPER"), 1);
		PlayerController.currentPlayer.weaponInventory.cannotChange = false;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.ammoLeft = 50;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.ammoLeftInClip = 10;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.clipSize = 10;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.ammoSetup.damageAmount = 150f;
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_SNIPER_UP", "ID_TUTORIAL_SNIPER_DOWN", -0.3f);
		Vector3 sniperRiflePosition = GuiElementSingle<InventoryGuiElement>.instance.invItems[2].transform.position + 0.1f * Vector3.up;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(sniperRiflePosition);
		TimeManager.FreezeGame();
		DeathMatchUnitsGuiElement.instance.DisableCardClick();
		DeathMatchUnitsGuiElement.instance.ShowHintText(show: false);
		mShowDeployHint = false;
		while (PlayerController.currentPlayer.weaponInventory.currentWeapon != PlayerController.currentPlayer.weaponInventory.usedWeapons[1])
		{
			yield return null;
		}
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		PlayerController.currentPlayer.weaponInventory.cannotChange = true;
		TimeManager.UnFreezeGame(0f);
		FreezeEnemies();
		yield return new WaitForSeconds(0.5f);
		foreach (AIObject paratrooper in mParatroopers)
		{
			paratrooper.destroyableObj.isImmortal = false;
		}
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_SNIPERSHOOT_UP", "ID_TUTORIAL_SNIPERSHOOT_DOWN", -0.3f);
		mParatrooperPosition = mFirstParatrooper.destroyableObj.transform.position + mFirstParatrooper.destroyableObj.transform.up * 0.4f;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(mParatrooperPosition, isGui: false);
		RadicalRoutine holdSniper = RadicalRoutine.Create(UpdateHoldSniperShoot());
		StartCoroutine(RadicalRoutine.Run(holdSniper.enumerator));
		while (mSniperKilled == 0)
		{
			yield return null;
		}
		Singleton<TutorialProgressShower>.instance.CheckNum(0);
		UnfreezeEnemies();
		DeathMatchUnitsGuiElement.instance.EnableCardClick();
		mShowDeployHint = true;
		holdSniper.Cancel();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		yield return new WaitForSeconds(0.5f);
		PlayerController.currentPlayer.weaponInventory.cannotChange = false;
		yield return new WaitForRealSeconds(0.5f);
		Singleton<TutorialProgressShower>.instance.Hide();
		yield return new WaitForRealSeconds(2f);
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2"), 1);
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 vector3)
	{
		if (weapon == PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon)
		{
			mSniperRifleShots++;
		}
	}

	private IEnumerator WeaponGrenadeTutorial()
	{
		yield return new WaitForEndOfFrame();
		mGameStarted = false;
		while (!mGameStarted)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("202 GAME STARTED");
		Singleton<ScoreManager>.instance.killStreakScoreRatio = 0f;
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = true;
		StartCoroutine(RadicalRoutine.Run(CheckAmmo()));
		PlayerController enemyPlayer = PlayerController.GetEnemyOf(Fractions.Allies);
		enemyPlayer.destroyableParts.maxHealth = 125f;
		enemyPlayer.destroyableParts.Refill();
		enemyPlayer.tutorialImmortality = true;
		PlayerBot bot = enemyPlayer.playerBot;
		bot.botConfig = BotManager.GetWeakBotConfig();
		bot.maxUnits = 5;
		bot.canUseCards = false;
		PlayerController.currentPlayer.tutorialImmortality = true;
		yield return new WaitForRealSeconds(0.5f);
		yield return StartCoroutine(RadicalRoutine.Run(Welcome()));
		Singleton<SpawningManagerDeathMatch>.instance.powerLeft = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
		Singleton<SpawningManagerDeathMatch>.instance.powerLeftEnemy = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
		DeathMatchUnitsGuiElement.instance.deployEnergyElement.shouldUpdate = true;
		DeathMatchUnitsGuiElement.instance.deployEnergyElement.InstantUpdate();
		yield return new WaitForRealSeconds(1f);
		StartCoroutine(RadicalRoutine.Run(Overtime()));
		yield return new WaitForRealSeconds(1f);
		yield return StartCoroutine(RadicalRoutine.Run(ThrowGrenade()));
		StartCoroutine(RadicalRoutine.Run(SpawnCheck()));
		yield return new WaitForRealSeconds(15f);
		bool sniperTutorial = false;
		int time = 0;
		if (mSniperRifleShots == 0)
		{
			sniperTutorial = true;
			time = (int)TimeManager.realTimeWithoutPauses;
			yield return StartCoroutine(RadicalRoutine.Run(SniperExplain()));
			time = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - time);
		}
		PlayerController.GetEnemyOf(Fractions.Allies).tutorialImmortality = false;
		Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("207 STAGE 7 SNIPER", sniperTutorial, time);
	}

	private IEnumerator Overtime()
	{
		while (Singleton<GameController>.instance.gameControllerTutorial.time > 0f)
		{
			yield return new WaitForSeconds(1f);
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("208 OVERTIME");
		Singleton<MatchManager>.instance.StartOverTime(PlayerController.currentPlayer, Singleton<GameController>.instance.opponent);
		yield return new WaitForSeconds(1f);
		TimeManager.FreezeGame();
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_OVERTIME", string.Empty, 0.3f, TutorialDialog.DialogPosition.Center, showContinue: true);
		PlayerController.currentPlayer.updateWeapons = false;
		data.overtimeShowed = true;
		Save();
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("209 OVERTIME CONTINUE");
		PlayerController.currentPlayer.updateWeapons = true;
		GuiElementSingle<TutorialDialog>.instance.Hide();
		TimeManager.UnFreezeGame(0f);
	}

	private IEnumerator Welcome()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("203 AUTOSPAWN STARTED");
		yield return new WaitForRealSeconds(0.85f);
		TimeManager.FreezeGame();
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_FULL_ARSENAL", "ID_TUTORIAL_FULL_ARSENAL_DOWN", 0.3f, TutorialDialog.DialogPosition.Center, showContinue: true);
		PlayerController.currentPlayer.updateWeapons = false;
		GuiElementSingle<InventoryGuiElement>.instance.ShowHintText();
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("204 AUTOSPAWN CONTINUE");
		PlayerController.currentPlayer.updateWeapons = true;
		GuiElementSingle<TutorialDialog>.instance.Hide();
		TimeManager.UnFreezeGame(0f);
		GuiElementSingle<InventoryGuiElement>.instance.HideHintText();
		DeathMatchUnitsGuiElement.instance.Enable();
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

	private void AssaulterKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		if (PlayerController.currentPlayer.weaponInventory.currentWeapon == PlayerController.currentPlayer.weaponInventory.usedWeapons[2])
		{
			mAssalterKilled = true;
		}
		else
		{
			mAssaltersKilledNotGrenade++;
		}
	}

	private IEnumerator UpdateSwipeGrenadeThrow()
	{
		while (true)
		{
			Vector3 playerWorldPosition = PlayerController.currentPlayer.destroyableParts.parts[1].transform.position;
			GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(playerWorldPosition, mGrenadeArea, isGui: false);
			yield return null;
		}
	}

	private IEnumerator ThrowGrenade()
	{
		int assaultersToGenerate = 4;
		mAssalterKilled = false;
		TutorialMapDefinition tut = Singleton<MapManager>.instance.currentMapDef.GetComponent<TutorialMapDefinition>();
		List<EnemyController> asaulters = new List<EnemyController>();
		for (int i = 0; i < assaultersToGenerate; i++)
		{
			EnemyController enemy = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[0]);
			if (enemy != null && enemy.prefab != null)
			{
				enemy.fraction = Fractions.Enemies;
				int prefabIndex = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemy.prefab];
				enemy.DisableSpawn();
				Transform sp = tut.spawnForGrenadeSoldiers.transform;
				enemy = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(prefabIndex, enemy.indexInObjectPool, sp.position, sp.rotation);
				enemy.StartEnemyBehaviour(EnemyController.EnemyAIState.Walk, tut.enemyPointsCollection.enemyPoints[i]);
				enemy.canChangePosition = false;
				enemy.Killed -= AssaulterKilled;
				enemy.Killed += AssaulterKilled;
				enemy.agent.speed = 1f;
				enemy.destroyableObj.isImmortal = true;
				asaulters.Add(enemy);
			}
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(5f);
		bool playerHadToSelectGrenade = false;
		if (PlayerController.currentPlayer.weaponInventory.currentWeapon != PlayerController.currentPlayer.weaponInventory.usedWeapons[2])
		{
			playerHadToSelectGrenade = true;
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_GRENADE_UP", "ID_TUTORIAL_GRENADE_DOWN", 0f);
			Vector3 grenadePosition = GuiElementSingle<InventoryGuiElement>.instance.invItems[1].transform.position + 0.1f * Vector3.up;
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(grenadePosition);
			PlayerController.currentPlayer.canSendUnits = false;
			TimeManager.FreezeGame();
			yield return new WaitForRealSeconds(1.5f);
			while (PlayerController.currentPlayer.weaponInventory.currentWeapon != PlayerController.currentPlayer.weaponInventory.usedWeapons[2])
			{
				yield return null;
			}
			PlayerController.currentPlayer.weaponInventory.cannotChange = true;
		}
		else
		{
			playerHadToSelectGrenade = false;
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_GRENADE_UP", string.Empty, 0f, TutorialDialog.DialogPosition.Center, showContinue: true);
			Vector3 grenadePosition2 = GuiElementSingle<InventoryGuiElement>.instance.invItems[1].transform.position + 0.1f * Vector3.up;
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(grenadePosition2);
			PlayerController.currentPlayer.canSendUnits = false;
			TimeManager.FreezeGame();
			PlayerController.currentPlayer.weaponInventory.cannotChange = true;
			while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
			{
				yield return null;
			}
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowEvent("205 STAGE 6 GRENADE SELECTED", playerHadToSelectGrenade);
		foreach (EnemyController enemyController in asaulters)
		{
			enemyController.destroyableObj.isImmortal = false;
		}
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		PlayerSwipeWeapon sw = (PlayerSwipeWeapon)PlayerController.currentPlayer.weaponInventory.usedWeapons[2];
		sw.SetTutorialPosition(tut.grenadePoint.transform.position);
		GrenadeAmmoSetup setup = (GrenadeAmmoSetup)sw.weapon.ammoSetup;
		setup.deadRadius = 1.6f;
		setup.hurtRadius = 2.3f;
		PlayerController.currentPlayer.updateWeapons = true;
		while (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
		{
			yield return null;
		}
		yield return new WaitForRealSeconds(0.1f);
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRES_THROW"), 1);
		int grenadeThrowingTutorialDuration = (int)TimeManager.realTimeWithoutPauses;
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_GRENADETHROW_UP", "ID_TUTORIAL_GRENADETHROW_DOWN", 0.3f, TutorialDialog.DialogPosition.Left);
		mGrenadeArea = tut.grenadePoint.transform.position;
		Vector3 playerWorldPosition = PlayerController.currentPlayer.destroyableParts.parts[1].transform.position;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(playerWorldPosition, mGrenadeArea, 0.3f, isGui: false, 1.3f);
		RadicalRoutine swipeGrenade = RadicalRoutine.Create(UpdateSwipeGrenadeThrow());
		StartCoroutine(RadicalRoutine.Run(swipeGrenade.enumerator));
		TimeManager.UnFreezeGame(0f);
		FreezeEnemies();
		PlayerController.GetEnemyOf(Fractions.Allies).isImmortal = true;
		while (!mAssalterKilled)
		{
			if (PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoLeft == 0)
			{
				PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoLeft = 1;
			}
			yield return null;
		}
		grenadeThrowingTutorialDuration = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - grenadeThrowingTutorialDuration);
		Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowingEvent("206 STAGE 6 GRENADE THROWING", grenadeThrowingTutorialDuration);
		Singleton<TutorialProgressShower>.instance.CheckNum(0);
		PlayerController.currentPlayer.canSendUnits = true;
		PlayerController.currentPlayer.weaponInventory.cannotChange = false;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoLeft = 5;
		PlayerController.GetEnemyOf(Fractions.Allies).isImmortal = false;
		UnfreezeEnemies();
		swipeGrenade.Cancel();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		yield return new WaitForRealSeconds(1f);
		yield return new WaitForRealSeconds(1.5f);
		Singleton<TutorialProgressShower>.instance.Hide();
		Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2"), 1);
	}

	public void CheckAfterDownload()
	{
		if (mUnitBoughtState > 0 && base.isTutorialRunning)
		{
			LevelManager.instance.CheckCurrentLevelForTutorial(3);
			if (mUnitBoughtState < 3)
			{
				mTutorialUnit.upgradeSlots.bought = false;
			}
		}
	}

	private IEnumerator BuyTutorialUnit()
	{
		mUnitBoughtState = 1;
		foreach (LevelBehaviour v in LevelManager.instance.behaviours)
		{
			if (v.upgradeSlots.isTutorialUnit)
			{
				v.upgradeSlots.bought = false;
				mTutorialUnit = v;
				break;
			}
		}
		if (mTutorialUnit == null)
		{
			Debug.LogError("There is no unit selected as tutorial unit!!!!!!");
		}
		while (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
		{
			yield return null;
		}
		while (!GuiElementSingle<LevelUpDialog>.instance.completeAnimation)
		{
			yield return null;
		}
		GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("212 MENU LEVEL UP SHOWN");
		yield return new WaitForSeconds(0.1f);
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_2"), Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_2_DOWN"), -0.2f, TutorialDialog.DialogPosition.Right, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.items[0].tutorialHandPosition.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.items[0].centerObject.transform.position, GuiElementSingle<LevelUpDialog>.instance.items[0].itemCollider.size, showBlueOverlay: false);
		while (GuiElementSingle<LevelUpDialog>.instance.isShowed)
		{
			yield return null;
		}
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide(0.4f);
		while (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("213 MENU ARMY SCREEN SHOWN");
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		bool selectedWrongUnit = false;
		if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour != mTutorialUnit)
		{
			selectedWrongUnit = true;
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(0.5f);
			GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_GO_BUY_ARMY_3", 0.25f);
			List<ArmyUpgradeIcon> allIcons = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
			ArmyUpgradeIcon usedIcon = null;
			Vector3 globalPos = Vector3.zero;
			Vector3 size = Vector3.one;
			if (allIcons != null)
			{
				foreach (ArmyUpgradeIcon v2 in allIcons)
				{
					if (v2.levelBehaviour == mTutorialUnit)
					{
						usedIcon = v2;
						globalPos = v2.transform.position;
						size = v2.GetComponent<BoxCollider>().size;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(globalPos);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size);
						break;
					}
				}
			}
			while (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour != mTutorialUnit)
			{
				if (usedIcon != null && usedIcon.transform.position != globalPos)
				{
					globalPos = usedIcon.transform.position;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(globalPos);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size);
				}
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("214 MENU ARMY SCREEN TUTORIAL UNIT", selectedWrongUnit);
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(0.5f);
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_4"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_BUY")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.armyRightContent.warbucksIcon.cachedTransform.position, new Vector3(40f, -56f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.armyRightContent.rightButton, showBlueOverlay: false);
		while (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed)
		{
			yield return null;
		}
		mUnitBoughtState = 2;
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("215 MENU ARMY SCREEN TUTORIAL UNIT BUY CLICKED");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(1.1f);
		if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.bought)
		{
			bool playerWaitedTillDeliveryEnds = false;
			GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_DELIVER"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_DELIVERNOW")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.armyRightContent.buttonDeliverNowPart.transform.position, new Vector3(40f, -56f, 0f));
			GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.armyRightContent.rightButton, showBlueOverlay: false);
			bool canChange = true;
			while (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.bought)
			{
				if (canChange && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivered)
				{
					playerWaitedTillDeliveryEnds = true;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
					GuiElementSingle<TutorialDialog>.instance.Hide();
					GuiElementSingle<TutorialClickOverlay>.instance.Hide();
					canChange = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					yield return new WaitForSeconds(1.1f);
					GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_DELIVERED_UNIT"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_ACTIVATION")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.armyRightContent.buttonActivatePart.transform.position, new Vector3(40f, -56f, 0f));
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.armyRightContent.rightButton, showBlueOverlay: false);
				}
				yield return false;
			}
			mUnitBoughtState = 3;
			Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("216 MENU ARMY SCREEN TUTORIAL UNIT ACTIVATED", playerWaitedTillDeliveryEnds);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(0.5f);
		}
		mUnitBoughtState = 4;
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.backButton.transform.position, new Vector3(0f, -25f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.backButton);
		GuiElementSingle<TutorialClickOverlay>.instance.StartBorderAnimation();
		yield return new WaitForSeconds(0.5f);
		while (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("217 MENU BATTLE SCREEN SHOWN");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_6"), Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_6_DOWN"), 0.1f, TutorialDialog.DialogPosition.Right, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.playerVsPlayerButton.positionForTutorialHand.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.playerVsPlayerButton.pvpButton);
		while (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("220 NEXT TUTORIAL STARTING");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		mUnitBoughtState = 5;
	}

	public void EquipTutorialUnitAfterSkipTutorial()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots.isTutorialUnit)
			{
				behaviour.upgradeSlots.bought = true;
				behaviour.upgradeSlots.equipped = true;
				break;
			}
		}
	}
}
