using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;

[Skip]
public class TutorialManagerStage3 : TutorialManagerBase
{
	public const string id = "Stage3";

	private static TutorialManagerStage3 mInstance;

	public CardsGuiElementNew cardGUI;

	private bool mGameStarted;

	public static TutorialManagerStage3 instance
	{
		get
		{
			mInstance = mInstance ?? Object.FindObjectOfType<TutorialManagerStage3>();
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
		AIObject.AfterSpawned += AfterSpawned;
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

	protected override void AfterSpawned(AIObject aiObject)
	{
		base.AfterSpawned(aiObject);
		if (base.isTutorialRunning)
		{
			TurretRockets turretRockets = aiObject as TurretRockets;
			if (turretRockets != null && turretRockets.fraction == PlayerController.currentPlayer.fraction)
			{
				MissileSetup component = turretRockets.GetComponent<MissileSetup>();
				component.playerBehindShieldRatio = 0.04f;
				component.explodeDamageAmount = 400f;
				turretRockets.destroyableObj.maxHealth *= 2f;
				turretRockets.destroyableObj.Refill();
			}
		}
	}

	public void FinishMenuTutorial()
	{
		StartCoroutine(AfterGameCoroutine());
	}

	private IEnumerator AfterGameCoroutine()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("309 END");
		LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(1f);
		Singleton<BeanstalkServerManager>.instance.TutorialEnded();
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
		while (DialogManager.instance.isSomeDialogShowed)
		{
			if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
			{
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
			}
			if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
			{
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
			}
			yield return null;
		}
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		Singleton<AchievementsManager>.instance.CompleteAchievements<AchievementFinishBootcamp>();
		if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 0f);
			yield return new WaitForSeconds(0.4f);
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
			while (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
			{
				yield return null;
			}
			yield return new WaitForSeconds(0.1f);
			while (DialogManager.instance.isSomeDialogShowed)
			{
				yield return null;
			}
			GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
			GameLoginManager.instance.AfterTutorialGCcheck();
			while (GameLoginManager.instance.changeGCAfterTutorialInProgress)
			{
				yield return null;
			}
		}
		else
		{
			yield return new WaitForSeconds(0.4f);
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}
		Debug.LogError("TUTORIAL ENDED");
		base.isTutorialRunning = false;
		Singleton<GameController>.instance.SwitchToSinglePlayer();
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
		GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
		TutorialManagerStage6.instance.RunTutorial();
	}

	private void OnGameEnded(GameController.GameEndReason obj)
	{
		if (base.isTutorialRunning)
		{
			GameLoginManager.instance.TryPresetStartingCurrency();
			Singleton<EventTrackingManager>.instance.RegisterTutorialGameEnded("308 GAME END");
			StopAllCoroutines();
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
			Singleton<Wallet>.instance.SetRewardForTutorial(2500, 3);
			Singleton<ScoreManager>.instance.score += 10000;
			LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, levelUp: false);
			Debug.Log("*****   Bootcamp 3/3 Ended   *****");
			LevelManager.instance.levelExperience += Singleton<ScoreManager>.instance.score;
		}
	}

	public override void StartTutorial(bool isContinue)
	{
		SetPlayerDefaultWeapons(enableRifle: true, enableSniper: true, enableGrenade: true);
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
		base.StartTutorial(isContinue);
		PrepareDataForTutorial();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("301 LOADING MAP");
		StartCoroutine(RadicalRoutine.Run(Welcome()));
	}

	private void PrepareDataForTutorial()
	{
		LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, levelUp: false);
		PlayerController.currentPlayer.playerProperties.level = 3;
		PlayerController.GetEnemyOf(PlayerController.currentPlayer.fraction).playerProperties.level = 3;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	public override void FinishTutorial()
	{
		base.FinishTutorial();
		Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged -= InstanceOnArmyChangedFirst;
	}

	private void InstanceOnArmyChangedFirst()
	{
		Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged -= InstanceOnArmyChangedFirst;
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> tutorial = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
		{
			new Tuple<int, int>(0, 0),
			new Tuple<int, int>(0, 0),
			new Tuple<int, int>(0, 0)
		});
		Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(tutorial);
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[1]);
		if (enemyController != null && enemyController.prefab != null)
		{
			enemyController.fraction = Fractions.Enemies;
			int i = ObjectPoolDatabase.networkPool.prefabToIndexDic[enemyController.prefab];
			enemyController = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(i, enemyController.indexInObjectPool);
			enemyController.power = 4;
			enemyController.StartEnemyBehaviour();
			enemyController.power = 4;
		}
		StartCoroutine(CheckKilledShotGunner(enemyController));
		InvokeAfter(delegate
		{
			PlayerController opponent = Singleton<GameController>.instance.opponent;
			opponent.playerBot.canSpawn = true;
		}, 5f);
	}

	private IEnumerator CheckKilledShotGunner(EnemyController enemy)
	{
		while (enemy.isAlive)
		{
			yield return null;
		}
		PlayerController enemyPlayer = Singleton<GameController>.instance.opponent;
		enemyPlayer.tutorialImmortality = false;
	}

	private IEnumerator Welcome()
	{
		mGameStarted = false;
		yield return new WaitForEndOfFrame();
		Debug.Log("*****   Bootcamp 3/3 Started   *****");
		while (!mGameStarted)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("302 GAME STARTED");
		List<MapDefinition.DefendPosition> shieldPoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		for (int i = 0; i < shieldPoints.Count; i++)
		{
			shieldPoints[i].point.shield.maxHealth = 500f;
			shieldPoints[i].point.shield.Refill();
		}
		Singleton<ScoreManager>.instance.killStreakScoreRatio = 0f;
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
		Singleton<SpawningManagerDeathMatch>.instance.baseCoolDown = 2f;
		StartCoroutine(RadicalRoutine.Run(CheckAmmo()));
		PlayerController enemyPlayer = PlayerController.GetEnemyOf(Fractions.Allies);
		enemyPlayer.destroyableParts.maxHealth = 125f;
		enemyPlayer.destroyableParts.Refill();
		enemyPlayer.tutorialImmortality = true;
		PlayerBot bot = enemyPlayer.playerBot;
		bot.botConfig = BotManager.GetWeakBotConfig();
		bot.maxUnits = 6;
		bot.canUseCards = false;
		bot = enemyPlayer.playerBot;
		PlayerController.currentPlayer.tutorialImmortality = true;
		while (!Singleton<GameController>.instance.gameIsRunning)
		{
			yield return null;
		}
		bot.canSpawn = false;
		yield return new WaitForSeconds(2f);
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> c = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
		{
			new Tuple<int, int>(0, 1),
			new Tuple<int, int>(0, 1),
			new Tuple<int, int>(0, 1)
		});
		Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(c);
		Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += InstanceOnArmyChangedFirst;
		DeathMatchUnitsGuiElement.instance.deployEnergyElement.shouldUpdate = true;
		DeathMatchUnitsGuiElement.instance.deployEnergyElement.InstantUpdate();
		Singleton<SpawningManagerDeathMatch>.instance.Enable();
		yield return new WaitForSeconds(0.5f);
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("303 STAGE 9 STARTED");
		TimeManager.FreezeGame();
		GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_START_PHASE2", "ID_TUTORIAL_START_PHASE2_DOWN", 0f, TutorialDialog.DialogPosition.Center, showContinue: true);
		GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("game-tutorial-infantry", "menu-army-cat-defender");
		PlayerController.currentPlayer.updateWeapons = false;
		PlayerController.currentPlayer.canSendUnits = false;
		PlayerController.currentPlayer.canSendCards = false;
		while (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
		{
			yield return null;
		}
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition currentArmyUnitDefinition in Singleton<SpawningManagerDeathMatch>.instance.currentArmyUnitDefinitions)
		{
			if (currentArmyUnitDefinition.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
			{
				Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(currentArmyUnitDefinition);
				break;
			}
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("304 STAGE 9 CONTINUE");
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = true;
		Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
		StartCoroutine(RadicalRoutine.Run(SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FullAutoDeployTime).FLOATVALUE - 1f)));
		GuiElementSingle<TutorialDialog>.instance.Hide();
		PlayerController.currentPlayer.canSendCards = true;
		PlayerController.currentPlayer.canSendUnits = true;
		TimeManager.UnFreezeGame(0f);
		yield return new WaitForSeconds(1f);
		PlayerController.currentPlayer.updateWeapons = true;
		StartCoroutine(SpawnCheck());
		yield return new WaitForSeconds(9f);
		StartCoroutine(RadicalRoutine.Run(Overtime()));
	}

	private IEnumerator Overtime()
	{
		while (Singleton<GameController>.instance.gameControllerTutorial.time > 0f)
		{
			yield return new WaitForSeconds(1f);
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("306 OVERTIME");
		Singleton<MatchManager>.instance.StartOverTime(PlayerController.currentPlayer, Singleton<GameController>.instance.opponent);
		if (!TutorialManagerStage2.instance.data.overtimeShowed)
		{
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
			PlayerController.currentPlayer.updateWeapons = true;
			GuiElementSingle<TutorialDialog>.instance.Hide();
			TimeManager.UnFreezeGame(0f);
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("TUTORIAL 3 OVERTIME CONTINUE", TutorialManagerStage2.instance.data.overtimeShowed);
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
}
