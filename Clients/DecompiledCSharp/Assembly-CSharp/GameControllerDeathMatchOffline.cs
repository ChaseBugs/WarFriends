using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Google2u;
using UnityEngine;

public class GameControllerDeathMatchOffline : IGameController
{
	private int mBotConfigurationId;

	protected PlayerController mBotInstance;

	private float mDevicePaused;

	private bool mIsOverTime;

	private bool mRecconectDialogShowed;

	private bool mShouldForfeit;

	private int mPausesCount;

	private PlayerController mMainPlayerController => Singleton<GameController>.instance.mainPlayerController;

	public GameController mMainController
	{
		get
		{
			return Singleton<GameController>.instance;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public override bool dropCreates => !LevelManager.isNoob;

	public override bool canShowPause => !MatchManager.isReconnect;

	public override List<Card> cardsForGame
	{
		get
		{
			return Singleton<GameController>.instance.gameControllerDeathMatch.cardsForGame;
		}
		set
		{
			Singleton<GameController>.instance.gameControllerDeathMatch.cardsForGame = value;
		}
	}

	public override float time { get; set; }

	public override bool gameIsRunning
	{
		get
		{
			return mMainController.gameIsRunning;
		}
		set
		{
			mMainController.gameIsRunning = value;
		}
	}

	public override bool canDeployUnits => true;

	public override string quitText => string.Empty;

	public override bool pauseCountDown => true;

	public override void FreeLevel()
	{
	}

	public override IEnumerator AquireLevelName()
	{
		yield break;
	}

	public override void Quit()
	{
	}

	public void PausematchMaking(bool pause)
	{
	}

	public override IEnumerator StartGame()
	{
		Debug.Log("Clear players");
		PlayerController.players.Clear();
		Debug.Log("Start DMO");
		Fractions fr = mMainPlayerController.fraction;
		MapDefinition.DefendPosition defendPosition = GetMainPlayerPoint(fr);
		mMainPlayerController.MoveTo(defendPosition.point.transform.position, defendPosition.point.transform.rotation);
		mMainPlayerController.fraction = fr;
		mMainPlayerController.currentPlayerPoint = defendPosition;
		PlayerController.currentPlayer = mMainPlayerController;
		PlayerController.players[0] = mMainPlayerController;
		mMainPlayerController.playerNetworkId = 0;
		mMainPlayerController.InitPlayer();
		mMainPlayerController.Killed -= OnPlayerControllerKilled;
		mMainPlayerController.Killed += OnPlayerControllerKilled;
		CreateBotInstance();
		Singleton<MapManager>.instance.currentMapDef.InitShields();
		LoadingDialog.Hide();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
		yield return StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
		yield return new WaitForSeconds(0.2f);
		Time.timeScale = 1f;
		time = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE;
		mPausesCount = 0;
		mIsOverTime = false;
	}

	public override void FinishGame()
	{
		if (gameIsRunning)
		{
			mBotInstance.playerProperties.EndMatch(Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.Win);
			Singleton<MatchManager>.instance.matchTime = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE - time;
			gameIsRunning = false;
			if (Singleton<GameController>.instance.isRandomMatchMaking && Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.Win)
			{
				CardManager.AddCardForWinner();
			}
			mMainController.FinishGame();
		}
	}

	public override void LoadingStarted()
	{
		mDevicePaused = 0f;
		mShouldForfeit = false;
		PhotonConnectionManager.JoinOfflineGame();
		Singleton<GameController>.instance.battleId = GameLoginManager.currentPlayer.id + "-" + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		mMainPlayerController.playerProperties = PlayerProperties.CreateForLocalPlayer();
		Singleton<BeanstalkServerManager>.instance.GameStartedMaster(mBotConfigurationId);
		LoadingDialog.SetLook(smallLook: true);
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: true);
		if (!GuiElementSingle<DialogCompareUnits>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DialogCompareUnits>.instance, 0f);
		}
		mRecconectDialogShowed = false;
		PlayerController.currentPlayer.networkStatus.connectionState = PlayerNetworkStatus.ConnectionState.Connected;
		PlayerController.currentPlayer.networkStatus.startAnimationFinished = true;
		mBotInstance.networkStatus.startAnimationFinished = true;
		MatchManager.reconnectTime = 0f;
	}

	public override void StopGame(bool switchScreen = true)
	{
		gameIsRunning = false;
		mMainController.StopGame(switchScreen);
	}

	public override void Forfeit()
	{
		mMainController.gameEndReason = GameController.GameEndReason.Forfeit;
		FinishGame();
	}

	public override void PauseGame(bool focusLost)
	{
		if (gameIsRunning)
		{
			if (!TimeManager.instance.isPaused)
			{
				mPausesCount++;
			}
			if (mPausesCount <= 1)
			{
				TimeManager.Pause(focusLost);
			}
			else if (focusLost)
			{
				Forfeit();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CantPauseDialog>.instance, 0f);
			}
		}
		else if (Singleton<GameController>.instance.gameState == GameController.GameState.Loading)
		{
			mDevicePaused = Time.realtimeSinceStartup;
		}
	}

	public override void ResumeGame()
	{
		TimeManager.Resume();
	}

	public override void UnPauseGame()
	{
		if (gameIsRunning)
		{
			Debug.Log($"GameControllerDMO: Application resumed pased at time: {TimeManager.pauseStart} timeLeft {TimeManager.pauseTimeLeft}, currentTime: {DateTime.Now}");
			if (gameIsRunning && TimeManager.pauseTimeLeft <= 0f)
			{
				Forfeit();
			}
		}
		else if (Singleton<GameController>.instance.gameState == GameController.GameState.Loading && mDevicePaused != 0f)
		{
			float num = Time.realtimeSinceStartup - mDevicePaused;
			if (num > 30f)
			{
				mShouldForfeit = true;
			}
		}
	}

	public override void FinishChoosingCards()
	{
	}

	public override void Rematch()
	{
		mMainController.SwitchToDeathMatch();
		mMainController.Rematch();
	}

	protected MapDefinition.DefendPosition GetMainPlayerPoint(Fractions fraction)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition playersPosition in Singleton<MapManager>.instance.currentMapDef.playersPositions)
		{
			if (playersPosition.mainPosition && playersPosition.fraction == fraction)
			{
				list.Add(playersPosition);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		Debug.LogError("No main position was set in map definition");
		return null;
	}

	protected void CreateBotInstance()
	{
		mBotInstance.gameObject.SetActive(value: true);
		Fractions fraction = mBotInstance.fraction;
		MapDefinition.DefendPosition mainPlayerPoint = GetMainPlayerPoint(fraction);
		mBotInstance.MoveTo(mainPlayerPoint.point.transform.position, mainPlayerPoint.point.transform.rotation);
		mBotInstance.fraction = fraction;
		mBotInstance.currentPlayerPoint = mainPlayerPoint;
		PlayerController.players[10] = mBotInstance;
		mBotInstance.playerNetworkId = 10;
		mBotInstance.Killed -= OnBotKilled;
		mBotInstance.Killed += OnBotKilled;
		mBotInstance.InitPlayer();
		if (StatsManager.instance.matchmadeGames == 0)
		{
			mBotInstance.destroyableParts.maxHealth *= 0.5f;
			mBotInstance.destroyableParts.Refill();
		}
		else if (BotManager.useEasyBot)
		{
			mBotInstance.destroyableParts.maxHealth *= Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.EasyBotHpCoeficient).FLOATVALUE;
			mBotInstance.destroyableParts.Refill();
		}
		PlayerBot playerBot = mBotInstance.playerBot;
		playerBot.enabled = true;
	}

	public void PrepareBot()
	{
		Fractions fraction = ((UnityEngine.Random.value < 0.5f) ? Fractions.Enemies : Fractions.Allies);
		mMainPlayerController.fraction = fraction;
		ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.player);
		mBotInstance = (PlayerController)ObjectPoolDatabase.networkPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.player);
		Singleton<GameController>.instance.opponent = mBotInstance;
		PlayerBot playerBot = mBotInstance.playerBot;
		playerBot.enabled = true;
		Fractions fraction2 = ((mMainPlayerController.fraction == Fractions.Allies) ? Fractions.Enemies : Fractions.Allies);
		PlayerController.players[10] = mBotInstance;
		mBotInstance.fraction = fraction2;
		mBotConfigurationId = Singleton<BotManager>.instance.PrepareBotForDeathMatch(playerBot);
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(mBotInstance, useBackground: true, PlayerTexturePool.RenderType.Classic);
	}

	private void OnBotKilled(IGameMainEntity arg1, DestroyableObject.DamageInfo arg2)
	{
		if (Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(arg2);
			if (gameIsRunning)
			{
				mMainController.gameEndReason = GameController.GameEndReason.Win;
				FinishGame();
				Singleton<GameCamera>.instance.FocusPlayer((PlayerController)arg1, arg2.owner is PlayerController);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		PlayerController.currentPlayer = mMainPlayerController;
	}

	private void OnPlayerControllerKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo arg3)
	{
		if (Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(arg3);
			if (gameIsRunning)
			{
				PlayerController playerController = (PlayerController)gameMainEntity;
				mMainController.gameEndReason = (playerController.isCurrentPlayer ? GameController.GameEndReason.Killed : GameController.GameEndReason.Win);
				FinishGame();
			}
		}
	}

	protected void Update()
	{
		if (!(Singleton<GameController>.instance.mainController == this))
		{
			return;
		}
		if (gameIsRunning)
		{
			time -= TimeManager.deltaTimeWithoutPauses;
			if (mShouldForfeit)
			{
				Forfeit();
				mShouldForfeit = false;
			}
		}
		if (gameIsRunning && TimeManager.instance.isPausedLocaly && TimeManager.pauseTimeLeft <= 0f && !MatchManager.isReconnect)
		{
			ResumeGame();
		}
		if ((time <= 0f || (DebugSettings.debugEnabled && Input.GetKeyDown(KeyCode.T))) && gameIsRunning && !mIsOverTime)
		{
			mIsOverTime = true;
			Singleton<MatchManager>.instance.StartOverTime(mMainPlayerController, mBotInstance);
		}
		CheckForReconnect();
	}

	protected virtual void CheckForReconnect()
	{
		if (CachedApplicationInternetReachability.internetReachability == NetworkReachability.NotReachable)
		{
			if (MatchManager.isReconnect && MatchManager.reconnectTime == 0f)
			{
				PlayerController.currentPlayer.networkStatus.IncreaseDisconnects();
				MatchManager.reconnectTime = Time.realtimeSinceStartup;
				mRecconectDialogShowed = false;
			}
		}
		else
		{
			MatchManager.reconnectTime = 0f;
			if (!MatchManager.isReconnect && gameIsRunning && GuiElementSingle<ReconnectDialog>.instance.isShowed)
			{
				GuiElementSingle<ReconnectDialog>.instance.HideDialog();
				TimeManager.Resume();
			}
		}
		if (gameIsRunning && MatchManager.isReconnect)
		{
			float value = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.reconnectTime);
			value = Mathf.Clamp(value, 0f, float.PositiveInfinity);
			GuiElementSingle<ReconnectDialog>.instance.SetWaitTime(value);
			if (value <= 0f)
			{
				if (MatchManager.reconnectState == ReconnectState.Me)
				{
					Forfeit();
				}
				GuiElementSingle<ReconnectDialog>.instance.HideDialog();
			}
		}
		UpdateReconnectDialog();
	}

	protected void UpdateReconnectDialog()
	{
		if (MatchManager.isReconnect && gameIsRunning && !mRecconectDialogShowed)
		{
			mRecconectDialogShowed = true;
			if (TimeManager.instance.isPaused)
			{
				GuiElementSingle<PauseScreen>.instance.HideDialog();
			}
			TimeManager.Pause(focusLost: false);
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ReconnectDialog>.instance, 0f);
			GuiElementSingle<ReconnectDialog>.instance.SetCause(MatchManager.reconnectState, MatchManager.allPlayersFinishetStartAnimation);
		}
	}

	public override void GetTimeProgressText(StringBuilder text)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			text.Append(Localization.Localize("ID_OVERTIME"));
		}
		else
		{
			MiscTools.PrintableTimeTwoDigits(ref text, Singleton<GameController>.instance.time);
		}
	}
}
