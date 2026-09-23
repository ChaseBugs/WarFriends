using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AdvancedFPSCounter;
using Prime31;
using UnityEngine;

public class GameController : Singleton<GameController>
{
	public enum GameEndReason
	{
		None = 0,
		Killed = 1,
		Win = 2,
		WinByForfeit = 3,
		Forfeit = 5,
		Kia = 8,
		MissionFailed = 9,
		MissionSuccess = 10
	}

	[Flags]
	public enum GameType
	{
		Campaign = 2,
		Coop = 4,
		DeathMatch = 8,
		DeathMatchOffline = 0x10,
		WarArena = 0x20
	}

	public enum GameState
	{
		Menu,
		WaitingForResponse,
		Loading,
		Playing
	}

	public enum ServerResponse
	{
		None,
		Error,
		Success
	}

	public delegate void GameStartDelegate();

	public GameControllerCampaign gameControllerCampaign;

	public GameControllerCoop gameControllerCoop;

	public GameControllerDeathMatch gameControllerDeathMatch;

	public GameControllerDeathMatchOffline gameControllerDeathMatchOffline;

	public GameControllerTutorial gameControllerTutorial;

	public GameControllerWarArena gameControllerWarArena;

	public GameEndReason gameEndReason;

	public AudioClip lostSound;

	private bool? mGameCreated;

	private bool mGameIsRunning;

	private bool mIsHost;

	private bool mIsRestart;

	private bool mIsAccountChanged;

	private ChallengeMessage mMessage;

	private IGameController mMainController;

	private PlayerController mOpponent;

	public PlayerController friend;

	public string levelName;

	public AudioClip winSound;

	private string mBattleId;

	private bool mPlayTutorial;

	public PlayerController mainPlayerController;

	private string mLog;

	public GameState gameState { get; private set; }

	public IGameController mainController
	{
		get
		{
			return mMainController;
		}
		set
		{
			EnableDisableController(gameControllerCampaign, value);
			EnableDisableController(gameControllerCoop, value);
			EnableDisableController(gameControllerDeathMatch, value);
			EnableDisableController(gameControllerDeathMatchOffline, value);
			EnableDisableController(gameControllerTutorial, value);
			EnableDisableController(gameControllerWarArena, value);
			mMainController = value;
		}
	}

	public float time => mainController.time;

	public bool wonLastGame => gameEndReason == GameEndReason.MissionSuccess || gameEndReason == GameEndReason.Win || gameEndReason == GameEndReason.WinByForfeit;

	public bool gameIsRunning
	{
		get
		{
			return mGameIsRunning;
		}
		set
		{
			TimeManager.instance.gameIsRunning = value;
			mGameIsRunning = value;
		}
	}

	public GameType gameType
	{
		get
		{
			if (isCoop || isCoopBot)
			{
				return GameType.Coop;
			}
			if (isDeathMatch)
			{
				return GameType.DeathMatch;
			}
			if (isDeathMatchOffline)
			{
				return GameType.DeathMatchOffline;
			}
			if (isWarArena)
			{
				return GameType.WarArena;
			}
			return GameType.Campaign;
		}
	}

	public bool isMission => isCampaign || isCampaignBot || isCoop || isCoopBot;

	public bool isCampaign => object.Equals(mainController, gameControllerCampaign) && !(MissionsManager.instance.currentMission is BotMission);

	public bool isCoop => object.Equals(mainController, gameControllerCoop) && !(MissionsManager.instance.currentMission is BotMission);

	public bool isCampaignBot => object.Equals(mainController, gameControllerCampaign) && MissionsManager.instance.currentMission is BotMission;

	public bool isCoopBot => object.ReferenceEquals(mainController, gameControllerCoop) && MissionsManager.instance.currentMission is BotMission;

	public bool isBattle => isDeathMatch || isDeathMatchOffline;

	public bool isPVP => isDeathMatch || isDeathMatchOffline || isWarArena;

	public bool isDeathMatch => object.Equals(mainController, gameControllerDeathMatch);

	public bool isDeathMatchOffline => object.Equals(mainController, gameControllerDeathMatchOffline);

	public bool isWarArena => object.Equals(mainController, gameControllerWarArena);

	public bool isTutorial => object.Equals(mainController, gameControllerTutorial);

	public bool isTutorialInProgressOrPlaned => mPlayTutorial || isTutorial;

	public bool isTutorialStage1 => object.Equals(mainController, gameControllerTutorial) && TutorialManagerStage1.instance.isTutorialRunning;

	public bool isTutorialStage2 => object.Equals(mainController, gameControllerTutorial) && TutorialManagerStage2.instance.isTutorialRunning;

	public bool isTutorialStage3 => object.Equals(mainController, gameControllerTutorial) && TutorialManagerStage3.instance.isTutorialRunning;

	public bool isFirstLoadingOfWarfriends => !SavingLastSelected.instance.firstTutorialGameEnded;

	public string battleId
	{
		get
		{
			return mBattleId;
		}
		set
		{
			mBattleId = value;
		}
	}

	public bool isRandomMatchMaking => isBattle && gameControllerDeathMatch.isRandomMatchMaking;

	public bool isChallenge => isBattle && !gameControllerDeathMatch.isRandomMatchMaking;

	public bool isInMenuOrWait => gameState <= GameState.WaitingForResponse;

	public bool isLoadingOrPlaying => gameState >= GameState.Loading;

	public ServerResponse gameEndServerResponse { get; set; }

	public DatabaseResult errorReason { get; set; }

	public PlayerController opponent
	{
		get
		{
			return mOpponent;
		}
		set
		{
			Debug.Log("Set opponent: " + ((!(value != null)) ? "null" : value.name));
			mOpponent = value;
		}
	}

	public event Action<GameEndReason> GameEnded;

	public event GameStartDelegate BeforeGameStarted;

	public event GameStartDelegate GameStarted;

	public event GameStartDelegate AfterGameStarted;

	public event Action SceneFreed;

	private void EnableDisableController(Component newGameCo, IGameController c)
	{
		newGameCo.gameObject.SetActive(object.Equals(newGameCo, c));
	}

	public void StopAllTutorials()
	{
		TutorialManagerStage1.instance.FinishTutorial();
		TutorialManagerStage2.instance.FinishTutorial();
		TutorialManagerStage3.instance.FinishTutorial();
	}

	protected override void Awake()
	{
		base.Awake();
		Application.targetFrameRate = 60;
		gameState = GameState.Menu;
		Time.timeScale = 1f;
		PhotonNetwork.offlineMode = true;
		Singleton<BeanstalkServerManager>.instance.MatchMakingGameCreated += InstanceOnMatchMakingGameCreated;
		TimeManager.instance.GamePaused += OnGamePaused;
		TimeManager.instance.GameResumed += OnGameResumed;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		PlayerController.currentPlayer = mainPlayerController;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.CreateGcAccount || action == DatabaseAction.AddDebugGoodies || action == DatabaseAction.GetPlayerData || action == DatabaseAction.CreateAccount || action == DatabaseAction.MaxAll)
		{
			if (action == DatabaseAction.CreateGcAccount || action == DatabaseAction.CreateAccount || action == DatabaseAction.GetPlayerData)
			{
				Singleton<MessageManager>.instance.StopMessageCoroutine();
			}
			Debug.Log("SETTING AFTER PLAYER DATA LOADED -> WAITING FOR " + action);
			Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += InstanceOnAfterPlayerDataLoaded;
		}
	}

	public void InstanceOnAfterPlayerDataLoaded()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded -= InstanceOnAfterPlayerDataLoaded;
		if (gameState == GameState.Menu)
		{
			if (mPlayTutorial)
			{
				DialogManager.instance.HideAllDialogs();
				Singleton<GameController>.instance.ContinueTutorialImmediately();
				mPlayTutorial = false;
			}
			else if (!Singleton<GameController>.instance.isTutorial)
			{
				if (!GuiElementSingle<Background>.instance.isShowed)
				{
					Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<Background>.instance);
				}
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
				Singleton<GameCamera>.instance.Disable();
			}
		}
		Debug.Log("acountDataDownloadingInProgress = False");
		GameLoginManager.instance.acountDataDownloadingInProgress = false;
	}

	private void InstanceOnMatchMakingGameCreated(bool b)
	{
		Debug.Log("Game created on server+" + b);
		mGameCreated = b;
	}

	public void SwitchToSinglePlayer()
	{
		mainController = gameControllerCampaign;
	}

	public void SwitchToCoop()
	{
		mainController = gameControllerCoop;
		gameControllerCoop.isInMatch = false;
	}

	public void SwitchToTutorial()
	{
		mainController = gameControllerTutorial;
	}

	public void SwitchToDeathMatch()
	{
		mainController = gameControllerDeathMatch;
		gameControllerDeathMatch.isInMatch = false;
	}

	public void SwitchToWarArena()
	{
		mainController = gameControllerWarArena;
		gameControllerDeathMatch.isInMatch = false;
	}

	public void SwitchToDeatchMatchOffline()
	{
		mainController = gameControllerDeathMatchOffline;
		Debug.Log("#VAVRO# switch to DM OFFLINE");
	}

	private void RunApplication()
	{
		try
		{
			LoadingDialog.ShowLoading(string.Empty, showCancelButton: false, hideBackgroundElements: false, showInstantly: true);
			GameLoginManager.instance.RegisterOrLogin();
		}
		catch (Exception ex)
		{
			Debug.LogError("Caught Exception at startup " + ex.Message);
			Debug.LogError("Stacktrace " + ex.StackTrace);
			DialogManager.instance.HideAllDialogs();
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_CONFIRM_STARTUPERROR_TEXT", ex.Message), Localization.Localize("ID_CONFIRM_STARTUPERROR"), 0f, delegate
			{
				Debug.Log("RETRY");
				RunApplication();
			}, string.Empty);
		}
	}

	protected override void Start()
	{
		base.Start();
		RunApplication();
		SwitchToSinglePlayer();
	}

	public void StartGame(string mapName = "ModernTown")
	{
		mGameCreated = null;
		mainController.LoadingStarted();
		StartCoroutine(LoadAndStartNewMap(mapName));
	}

	private IEnumerator LoadAndStartNewMap(string levelName)
	{
		Singleton<PerformanceManager>.instance.SetShadowsDistance(shortDistance: false);
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
		Screen.sleepTimeout = -1;
		MatchManager.matchState = MatchState.GameLoading;
		gameState = GameState.WaitingForResponse;
		Singleton<Chat>.instance.Disconnect();
		CamosManager.instance.Null();
		UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Depth;
		PlayerController.currentPlayer.gameObject.SetActive(value: true);
		TimeManager.Reset();
		this.levelName = levelName;
		yield return StartCoroutine(WaitForServerResponse());
		yield return StartCoroutine(mainController.AquireLevelName());
		gameState = GameState.Loading;
		Singleton<ObjectPoolDatabase>.instance.mainObjectPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.indicator);
		Singleton<ObjectPoolDatabase>.instance.mainObjectPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.buddyNameDisplayer);
		yield return new WaitForSeconds(1f);
		GuiElementSingle<Background>.instance.DestroyParallax();
		yield return StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
		Resources.UnloadUnusedAssets();
		yield return StartCoroutine(Singleton<MapManager>.instance.Load(this.levelName));
		GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
		GuiScreenSingle<HudScreen>.instance.SetTransparent();
		if (this.BeforeGameStarted != null)
		{
			this.BeforeGameStarted();
		}
		yield return StartCoroutine(Singleton<UpgradesManager>.instance.LoadMineUpgrades(mainController.myUpgrades));
		yield return StartCoroutine(Singleton<UpgradesManager>.instance.LoadOpponentUpgradesForGame(mainController.opponentUpgrades));
		yield return StartCoroutine(CardManager.instance.InitGameCards(PlayerController.currentPlayer.playerProperties.chosenCards, isOpponnetCard: false, isCurrentPlayer: true));
		if (mOpponent != null)
		{
			yield return StartCoroutine(mOpponent.weaponInventory.LoadWeapons());
			CardManager.instance.SetBuddyCardsOher(mOpponent.playerProperties.buddyCards);
			yield return StartCoroutine(CardManager.instance.InitGameCards(mOpponent.playerProperties.chosenCards, isOpponnetCard: true, isCurrentPlayer: false));
		}
		if (friend != null)
		{
			yield return StartCoroutine(friend.weaponInventory.LoadWeapons());
			CardManager.instance.SetBuddyCardsOher(friend.playerProperties.buddyCards);
			yield return StartCoroutine(CardManager.instance.InitGameCards(friend.playerProperties.chosenCards, isOpponnetCard: false, isCurrentPlayer: false));
		}
		yield return StartCoroutine(PlayerController.currentPlayer.weaponInventory.LoadWeapons());
		Singleton<SoundsManager3D>.instance.LoadSounds();
		yield return null;
		Resources.UnloadUnusedAssets();
		EnemyController enemy = Singleton<ObjectPoolDatabase>.instance.enemy;
		NetworkObjectPool pool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> enemies = pool.pooledObjects[pool.prefabToIndexDic[enemy]];
		foreach (PoolableObject poolableObject in enemies)
		{
			EnemyController e = (EnemyController)poolableObject;
			e.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 5f;
			e.enabled = false;
			e.gameObject.SetActive(value: true);
			e.mSoldierAnimationController.Walk(Weapon.WeaponType.Pistol);
			yield return null;
			yield return null;
			e.gameObject.SetActive(value: false);
			e.enabled = true;
		}
		Singleton<Recording>.instance.StartRecording();
		yield return StartCoroutine(RadicalRoutine.Run(mainController.StartGame()));
		gameState = GameState.Playing;
		Singleton<GameCamera>.instance.Enable();
		yield return null;
		Time.timeScale = 1f;
		gameEndReason = GameEndReason.None;
		if (this.GameStarted != null)
		{
			this.GameStarted();
		}
		if (this.AfterGameStarted != null)
		{
			this.AfterGameStarted();
		}
		yield return new WaitForSeconds(0.2f);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
		yield return new WaitForSeconds(0.5f);
		mainController.gameIsRunning = true;
		LoadingDialog.Hide();
		InvokeAfter(delegate
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}, 5f);
	}

	public IEnumerator WaitForServerResponse()
	{
		while (true)
		{
			bool? flag = mGameCreated;
			if (flag.HasValue)
			{
				break;
			}
			yield return null;
		}
		if (mGameCreated != true)
		{
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SERVERERROR_TEXT"), Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, delegate
			{
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				GameLoginManager.Relog();
			}, string.Empty);
			TryStopLoading();
			Quit();
			if ((bool)(mainController as GameControllerOnline))
			{
				((GameControllerOnline)mainController).Disconnect();
			}
		}
	}

	public void Rematch()
	{
		mainController.Rematch();
	}

	public void StartHostMultiplayer()
	{
		mIsHost = true;
		Singleton<MapManager>.instance.SelectCurrentMap(mMessage.mapName);
		if (mMessage.gameType == GameType.DeathMatch)
		{
			Debug.Log("SWITCH TO DEATCHMATCH");
			SwitchToDeathMatch();
		}
		if (mMessage.gameType == GameType.Coop)
		{
			Debug.Log("SWITCH TO Coop");
			SwitchToCoop();
		}
		if (isDeathMatch)
		{
			gameControllerDeathMatch.StartMultiplayerGame(mMessage.roomName, mMessage.region);
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
		}
		if (isCoop)
		{
			gameControllerCoop.StartMultiplayerGame(mMessage.roomName, mMessage.region);
		}
		if (isCoopBot)
		{
			gameControllerCoop.StartMultiplayerGame(mMessage.roomName, mMessage.region);
			gameControllerCoop.FinishChoosingCards();
		}
	}

	public bool SetChallenge(DatabaseMessage message)
	{
		mMessage = (ChallengeMessage)message;
		if (mMessage.clientVersion != Singleton<CurrentBundleVersion>.instance.photonVersion)
		{
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_WARNING_BADVERSIONERROR_TEXT", mMessage.clientVersion, Singleton<CurrentBundleVersion>.instance.photonVersion), Localization.Localize("ID_WARNING_BADVERSIONERROR"), 0f, null, string.Empty);
			return false;
		}
		return true;
	}

	public void StartMultiplayerGame(DatabasePlayer player)
	{
		mIsHost = false;
		string roomName;
		bool isGoodPing;
		if (isDeathMatch)
		{
			gameControllerDeathMatch.StartMultiplayerGame(player, out roomName, out isGoodPing);
			if (isGoodPing)
			{
				Singleton<BeanstalkServerManager>.instance.Challenge(roomName: roomName, otherPlayer: player, mapName: Singleton<MapManager>.instance.currentMap.name, missionNumber: string.Empty, missionData: string.Empty);
				GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT"), Localization.Localize("ID_WARNING_CANNOTINVITE"), 0f, null, string.Empty);
				Singleton<PhotonConnectionManager>.instance.CheckPingsNow();
			}
		}
		if (isCoop)
		{
			gameControllerCoop.StartMultiplayerGame(player, out roomName, out isGoodPing);
			if (isGoodPing)
			{
				Singleton<BeanstalkServerManager>.instance.Challenge(player, Singleton<MapManager>.instance.currentMap.name, MissionsManager.instance.indexMissionToStart.ToString(), Json.encode(MissionsManager.instance.currentMission.savedData), roomName, MissionsManager.instance.currentMission.playingInHeroicMode);
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT"), Localization.Localize("ID_WARNING_CANNOTINVITE"), 0f, null, string.Empty);
				Singleton<PhotonConnectionManager>.instance.CheckPingsNow();
			}
		}
		if (isCoopBot)
		{
			gameControllerCoop.StartMultiplayerGame(player, out roomName, out isGoodPing);
			if (isGoodPing)
			{
				Singleton<BeanstalkServerManager>.instance.Challenge(player, Singleton<MapManager>.instance.currentMap.name, MissionsManager.instance.indexMissionToStart.ToString(), Json.encode(MissionsManager.instance.currentMission.savedData), roomName, MissionsManager.instance.currentMission.playingInHeroicMode);
				GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT"), Localization.Localize("ID_WARNING_CANNOTINVITE"), 0f, null, string.Empty);
			}
		}
	}

	public void TryStopLoading()
	{
		if (gameState <= GameState.WaitingForResponse)
		{
			gameState = GameState.Menu;
			StopAllCoroutines();
		}
		else
		{
			Debug.LogError("Stop Loading called when Game is loading or running");
		}
	}

	public void OnGameResumed(TimeManager.PauseStatus pauseStatus)
	{
		GuiElementSingle<PauseScreen>.instance.HideDialog();
	}

	public void OnGamePaused(TimeManager.PauseStatus pauseStatus)
	{
		if (mainController.canShowPause && gameIsRunning)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 0f);
		}
	}

	protected void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			mainController.PauseGame(focusLost: true);
			Debug.Log("Application paused");
		}
	}

	protected void OnApplicationResumed()
	{
		Debug.Log("GameController: Application resumed");
		mainController.UnPauseGame();
	}

	public void InteruptStartingTutorial()
	{
		mPlayTutorial = false;
	}

	public void ContinueOrStartTutorial()
	{
		Debug.LogError("set continue in tutorial");
		mPlayTutorial = true;
	}

	public void ContinueTutorialImmediately()
	{
		Singleton<GameController>.instance.StartTutorialInternal(string.Empty);
		Singleton<BeanstalkServerManager>.instance.RestartTutorial();
	}

	public void TestDisconnect()
	{
		Debug.Log("Test disconnect");
		SelfHostedBattleClient selfHosted = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
		if (selfHosted != null && selfHosted.PhotonCompatibility != null && selfHosted.PhotonCompatibility.IsConnected)
		{
			selfHosted.PhotonCompatibility.Disconnect();
			return;
		}
		PhotonNetwork.Disconnect();
		InvokeAfterRealTime(delegate
		{
			Component component = mainController;
			component.SendMessage("OnConnectionFail", DisconnectCause.DisconnectByClientTimeout, SendMessageOptions.DontRequireReceiver);
		}, 2f);
	}

	private void StartTutorialInternal(string tutorialId = "")
	{
		if (!string.IsNullOrEmpty(tutorialId))
		{
			battleId = tutorialId;
		}
		SwitchToTutorial();
		string mapName = GameControllerTutorial.GetMapName();
		StartGame(mapName);
	}

	public void FinishGame()
	{
		Debug.Log("Finish Game");
		SoundsManager.Instance.PlaySound((!wonLastGame) ? lostSound : winSound);
		mIsRestart = false;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameOverScreen>.instance);
		StartCoroutine(RadicalRoutine.Run(WaitForGameEndResponse()));
		if (this.GameEnded != null)
		{
			Delegate[] invocationList = this.GameEnded.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				try
				{
					Delegate obj = invocationList[i];
					obj.Method.Invoke(obj.Target, new object[1] { gameEndReason });
				}
				catch (Exception e)
				{
					Crittercism.LogHandledException(e);
				}
			}
		}
		BattleAnalyticsManager.instance.FinishGame();
		Singleton<BeanstalkServerManager>.instance.GameEnded(gameEndReason);
	}

	public IEnumerator RestartTutorial()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("{0}99 RESTART", gameControllerTutorial.tutorialStageId.Replace("Stage", string.Empty)));
		mIsRestart = true;
		if (this.GameEnded != null)
		{
			this.GameEnded(gameEndReason);
		}
		Singleton<BeanstalkServerManager>.instance.GameEnded(gameEndReason);
		yield return StartCoroutine(RadicalRoutine.Run(WaitForGameEndResponse()));
		while (gameState != GameState.Menu)
		{
			yield return null;
		}
		Time.timeScale = 1f;
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: true);
		yield return new WaitForSeconds(0.1f);
		GameControllerTutorial.RestartTutorial();
		ContinueTutorialImmediately();
	}

	private IEnumerator WaitForGameEndResponse()
	{
		mLog = null;
		Singleton<BeanstalkServerManager>.instance.ActionUpdated += OnBeanstalkActionUpdated;
		if (!mIsRestart)
		{
			while (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
			{
				yield return null;
			}
			Singleton<Recording>.instance.StopRecording();
			yield return new WaitForRealSeconds(0.5f);
		}
		LoadingDialog.SetLook(smallLook: false);
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: true);
		if (DebugSettings.debugEnabled && mLog != null)
		{
			LoadingDialog.SetText(mLog);
		}
		while (gameEndServerResponse == ServerResponse.None)
		{
			yield return null;
		}
		Singleton<BeanstalkServerManager>.instance.ActionUpdated -= OnBeanstalkActionUpdated;
		if (gameEndServerResponse == ServerResponse.Error)
		{
			string message = Localization.Localize("ID_CONFIRM_UNKNOWNREASON");
			string errorMessage;
			switch (errorReason)
			{
				case DatabaseResult.ServerRespondedWithError: errorMessage = Localization.Localize("ID_CONFIRM_SERVERRESPONDEDWITHERROR"); break;
				case DatabaseResult.ServerDidntRespondAfterGame: errorMessage = Localization.Localize("ID_CONFIRM_SERVERDIDNTRESPONDAFTER"); break;
				case DatabaseResult.GameDidntExist: errorMessage = Localization.Localize("ID_CONFIRM_GAMEDIDNTEXIST"); break;
				case DatabaseResult.GameAlreadyEnded: errorMessage = Localization.Localize("ID_CONFIRM_GAMELAREADYENDED"); break;
				case DatabaseResult.InvalidToken: errorMessage = Localization.Localize("ID_CONFIRM_LOGGEDOUT_TEXT"); break;
				default: errorMessage = string.Format("{0} {1}.", Localization.Localize("ID_CONFIRM_OTHERSERVERRESPONDERROR"), (int)errorReason); break;
			}
			WarningDialog.ShowError(errorMessage, Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, delegate
			{
				gameEndReason = GameEndReason.Forfeit;
				FreeLevel(switchScreen: true, wasError: true);
			}, string.Empty);
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: true, showInstantly: true);
		}
		if (gameEndServerResponse == ServerResponse.Success)
		{
			FreeLevel(switchScreen: true);
		}
	}

	private void OnBeanstalkActionUpdated(DatabaseAction databaseAction, int i, ActionStage arg3)
	{
		if (DebugSettings.debugEnabled)
		{
			mLog = $"WaitForGameEndResponse Try {i} action {arg3}";
			Debug.Log(mLog + " time: " + Time.realtimeSinceStartup);
			LoadingDialog.SetText(mLog);
		}
	}

	public void ChangeAccountDuringTutorial()
	{
		mainController.StopGame(switchScreen: false);
		mainController.Forfeit();
		mIsAccountChanged = true;
	}

	public void StopGame(bool switchScreen)
	{
		FreeLevel(switchScreen);
		gameEndReason = GameEndReason.Forfeit;
		if (this.GameEnded != null)
		{
			this.GameEnded(gameEndReason);
		}
		Singleton<BeanstalkServerManager>.instance.GameEnded(gameEndReason);
	}

	private void FreeLevel(bool switchScreen, bool wasError = false)
	{
		StartCoroutine(RadicalRoutine.Run(Free(switchScreen, wasError)));
	}

	private IEnumerator Free(bool switchScreen, bool wasError)
	{
		Screen.sleepTimeout = -2;
		gameState = GameState.Loading;
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: true);
		if (DebugSettings.debugEnabled && mLog != null)
		{
			LoadingDialog.SetText(mLog);
		}
		yield return new WaitForRealSeconds(0.5f);
		PlayerController.currentPlayer.gameObject.SetActive(value: false);
		Singleton<GameCamera>.instance.Disable();
		LightmapSettings.lightmaps = new LightmapData[0];
		LightmapSettings.lightProbes = null;
		yield return new WaitForRealSeconds(0.2f);
		TimeManager.Reset();
		Ammo.ammoPool.FreeWholePool();
		ObjectPoolDatabase.ammoPool.FreeWholePool();
		ObjectPoolDatabase.networkPool.FreeWholePool();
		Singleton<MapManager>.instance.DestroyCurrentScene();
		if (this.SceneFreed != null)
		{
			this.SceneFreed();
		}
		mainController.FreeLevel();
		EnemyLeveledWeapon.ClearModels();
		PlayerWeapon.ClearModels();
		Singleton<UpgradesManager>.instance.UnloadAll();
		Singleton<SoundsManager3D>.instance.UnloadSounds();
		CardManager.instance.ReleaseCards(PlayerController.currentPlayer.playerProperties.chosenCards, isOpponnetCard: false, isCurrentPlayer: true);
		if (mOpponent != null)
		{
			CardManager.instance.ReleaseCards(mOpponent.playerProperties.chosenCards, isOpponnetCard: true, isCurrentPlayer: false);
		}
		if (friend != null)
		{
			CardManager.instance.ReleaseCards(friend.playerProperties.chosenCards, isOpponnetCard: false, isCurrentPlayer: false);
		}
		TimeManager.instance.EndOfEndGame();
		yield return new WaitForRealSeconds(0.2f);
		Resources.UnloadUnusedAssets();
		yield return new WaitForRealSeconds(0.5f);
		if (!isMission)
		{
			PlayerAnalytics.instance.UseLastBoughtUnit();
		}
		CamosManager.instance.LoadAll();
		GuiElementSingle<Background>.instance.LoadParallax();
		yield return StartCoroutine(Singleton<AtlasPreparer>.instance.LoadMenuClearGameCoroutine());
		yield return new WaitForRealSeconds(0.2f);
		Singleton<DogTagManager>.instance.ResetLocalDogtags();
		UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Nothing;
		gameState = GameState.Menu;
		Singleton<Chat>.instance.Connect();
		if (mIsAccountChanged)
		{
			mIsAccountChanged = false;
			GameLoginManager.instance.AccountChange();
		}
		else if (!mIsRestart)
		{
			LoadingDialog.Hide();
			if (wasError)
			{
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				GameLoginManager.Relog();
			}
			else if (switchScreen)
			{
				mainController.ShowResultsScreen();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}

	public void Quit()
	{
		if (isInMenuOrWait)
		{
			if (mainController != null)
			{
				Debug.Log("Quit called for game controller.");
				mainController.Quit();
				LoadingDialog.SetLook(smallLook: false);
			}
		}
		else
		{
			Debug.LogError("Quit called when Game is loading or running");
		}
	}
}
