using System;
using Google2u;
using UnityEngine;

public class GameControllerDeathMatch : GameControllerPVP
{
	private bool mFakeBatteleWithBot;

	private bool mIsTutorial;

	private float mWaitingTime = 20f;

	public bool isRandomMatchMaking { get; private set; }

	public override string loadingWaiting => Localization.Localize((!isRandomMatchMaking) ? "ID_STATE_WAITINGFOROPPONENT" : "ID_STATE_SEARCHINGFOROPPONENT");

	protected override string mChoosingCardsText => Localization.Localize((!isRandomMatchMaking) ? "ID_WAITINGFORFRIENDCARDS" : "ID_WAITINGFOROPPONENTCARDS");

	protected override bool shouldLooseDogtagWhenQuit => false;

	public override string quitText => Localization.Localize((!isRandomMatchMaking) ? "ID_CONFIRM_EXITINGMATCHNODOGTAG_TEXT" : "ID_CONFIRM_EXITINGMATCH_TEXT");

	public override void StartRandomMatchMaking(float connectDelay = 1.5f)
	{
		LoadingDialog.SetLook(smallLook: true);
		Screen.sleepTimeout = -1;
		PlayerController.players.Clear();
		StartMatch();
		Tuple<CloudRegionCode, int> tuple = PhotonConnectionManager.bestRegionsSorted[0];
		bool flag = (float)tuple.Value2 > (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;
		mWaitingTime = Singleton<GameVariables>.instance.maxMatchmakingTime;
		if (flag || BotManager.useEasyBot || UserDeviceManager.instance.IsSlowDevice() || StatsManager.instance.deathMatchLossesInRow >= 3f)
		{
			Reset();
			isRandomMatchMaking = true;
			mRandomConnectTime = Time.realtimeSinceStartup;
			MatchManager.matchState = MatchState.ConnectingToPhoton;
			InvokeAfter(delegate
			{
				MatchManager.matchState = MatchState.WaitingForOpponent;
			}, 1f);
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			mFindBotAfter = ((!BotManager.useEasyBot) ? UnityEngine.Random.Range(11f, 12f) : 2f);
			mBotChooseCardsAfter = ((!BotManager.useEasyBot) ? UnityEngine.Random.Range(16f, 20f) : 4f);
			mFakeBatteleWithBot = true;
			PayDogtag();
		}
		else
		{
			Reset();
			isRandomMatchMaking = true;
			mRandomConnectTime = Time.realtimeSinceStartup;
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			BeginSelfHostedRandomMatchmaking(connectDelay);
			PayDogtag();
		}
	}

	private async void BeginSelfHostedRandomMatchmaking(float connectDelay)
	{
		try
		{
			if (connectDelay > 0f)
				await System.Threading.Tasks.Task.Delay((int)(connectDelay * 1000f));
			SelfHostedBattleClient client = SelfHostedBattleClient.GetOrCreate();
			await client.MatchmakeWithRecoveredSession();
			Singleton<PhotonConnectionManager>.instance.CompleteSelfHostedJoin();
			AllPlayersConnected();
		}
		catch (Exception exception)
		{
			Debug.LogError("Self-hosted matchmaking failed: " + exception.GetType().Name);
			MatchManager.matchState = MatchState.GameCancelled;
			Reset();
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT"), Localization.Localize("ID_WARNING_CANNOTINVITE"), 0f, null, string.Empty);
		}
	}

	public void StartTutorialMatch()
	{
		LoadingDialog.SetLook(smallLook: true);
		Screen.sleepTimeout = -1;
		PlayerController.players.Clear();
		StartMatch();
		Reset();
		isRandomMatchMaking = true;
		mRandomConnectTime = Time.realtimeSinceStartup;
		MatchManager.matchState = MatchState.ConnectingToPhoton;
		InvokeAfter(delegate
		{
			MatchManager.matchState = MatchState.WaitingForOpponent;
		}, 0.2f);
		GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
		mFindBotAfter = 0.2f;
		mBotChooseCardsAfter = 1f;
		mFakeBatteleWithBot = true;
		mIsTutorial = true;
	}

	public override void FinishGame()
	{
		if (MatchManager.isReconnect)
		{
			Disconnect();
		}
		base.FinishGame();
		if (isRandomMatchMaking)
		{
			if (Singleton<GameController>.instance.gameEndReason == GameController.GameEndReason.Win)
			{
				CardManager.AddCardForWinner();
			}
			Disconnect();
		}
	}

	[PunRPC]
	protected override void FinishGameMultiplayerRPC(byte gameEndReason)
	{
		if (MatchManager.isReconnect)
		{
			Disconnect();
		}
		base.FinishGameMultiplayerRPC(gameEndReason);
		if (isRandomMatchMaking)
		{
			Disconnect();
		}
	}

	public override void StartMultiplayerGame(DatabasePlayer otherPlayer, out string roomName, out bool isGoodPing)
	{
		isRandomMatchMaking = false;
		LoadingDialog.SetLook(smallLook: true);
		base.StartMultiplayerGame(otherPlayer, out roomName, out isGoodPing);
	}

	public override void StartMultiplayerGame(string roomName, CloudRegionCode region)
	{
		isRandomMatchMaking = false;
		LoadingDialog.SetLook(smallLook: true);
		base.StartMultiplayerGame(roomName, region);
	}

	public override void RestartRandomMatchMaking(bool resetRandomConnectTime = true)
	{
		LoadingDialog.SetLook(smallLook: true);
		float num = mRandomConnectTime;
		Reset();
		PlayerController.players.Clear();
		mRandomConnectTime = ((!resetRandomConnectTime) ? num : Time.realtimeSinceStartup);
		isRandomMatchMaking = true;
		StartMatch();
		BeginSelfHostedRandomMatchmaking(0f);
	}

	protected override void AllPlayersConnected()
	{
		if (!mBothPlayersConnected)
		{
			if (!isRandomMatchMaking)
			{
				MatchManager.invitationState = InvitationState.Accepted;
			}
			base.AllPlayersConnected();
		}
	}

	protected override void Update()
	{
		if (Time.realtimeSinceStartup > mRandomConnectTime + mWaitingTime && mRandomConnectTime != 0f && isRandomMatchMaking && !mBothPlayersConnected && !mFakeBatteleWithBot && Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			if (!PhotonConnectionManager.isInRoom)
			{
				Singleton<EventTrackingManager>.instance.MatchMaking(40f);
			}
			PhotonConnectionManager.Disconnect();
			PhotonNetwork.offlineMode = true;
			StopAllCoroutines();
			mFakeBatteleWithBot = true;
			Singleton<BeanstalkServerManager>.instance.GetSquadsByExperience();
			MatchManager.matchState = MatchState.WaitingForOpponent;
			mFindBotAfter = mWaitingTime + UnityEngine.Random.Range(1f, 1f);
			Singleton<GameController>.instance.opponent = null;
			mBotChooseCardsAfter = mWaitingTime + UnityEngine.Random.Range(1f, (!DebugSettings.debugEnabled) ? 10f : 2f);
			Debug.Log("Starting match against bot");
		}
		if (mFakeBatteleWithBot)
		{
			if (Time.realtimeSinceStartup > mRandomConnectTime + mFindBotAfter && mRandomConnectTime != 0f && MatchManager.matchState == MatchState.WaitingForOpponent && isRandomMatchMaking)
			{
				mBothPlayersConnected = true;
				Singleton<GameController>.instance.gameControllerDeathMatchOffline.PrepareBot();
				int num = LevelManager.instance.currentLevel.displayNumber;
				if (Singleton<GameController>.instance.mainPlayerController != null && Singleton<GameController>.instance.mainPlayerController.playerProperties != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.mainPlayerController.playerProperties.level);
				}
				if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.playerProperties != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.opponent.playerProperties.level);
				}
				MatchManager.matchState = MatchState.BothPlayersConnected;
				MatchManager.matchStartTime = Time.realtimeSinceStartup + (float)GameVariables.GetMatchStartTime(num);
				Singleton<GameController>.instance.opponent.networkStatus.Reset();
				Singleton<GameController>.instance.opponent.networkStatus.matchState = PlayerNetworkStatus.MatchState.Connected;
				if (mCardsChoosen)
				{
					string title = ((!isRandomMatchMaking) ? Localization.Localize("ID_WAITINGFORFRIENDCARDS") : Localization.Localize("ID_WAITINGFOROPPONENTCARDS"));
					LoadingDialog.ShowLoading(title);
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DialogCompareUnits>.instance, 0f);
				}
			}
			if (Singleton<GameController>.instance.opponent != null)
			{
				PlayerController opponent = Singleton<GameController>.instance.opponent;
				if (Time.realtimeSinceStartup > mRandomConnectTime + mBotChooseCardsAfter && mRandomConnectTime != 0f && MatchManager.matchState == MatchState.BothPlayersConnected && opponent.networkStatus.matchState == PlayerNetworkStatus.MatchState.Connected)
				{
					opponent.networkStatus.matchState = PlayerNetworkStatus.MatchState.CardsChosen;
				}
				PlayerNetworkStatus.MatchState matchState = opponent.networkStatus.matchState;
				if (mRandomConnectTime != 0f && mCardsChoosen && matchState == PlayerNetworkStatus.MatchState.CardsChosen)
				{
					mRandomConnectTime = 0f;
					base.isInMatch = false;
					Singleton<GameController>.instance.SwitchToDeatchMatchOffline();
					Singleton<GameController>.instance.TryStopLoading();
					Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
				}
			}
		}
		if (Time.realtimeSinceStartup > MatchManager.matchStartTime && mBothPlayersConnected && !mCardsChoosen && (PhotonNetwork.inRoom || PhotonConnectionManager.IsSelfHostedActive || mFakeBatteleWithBot) && !mIsTutorial)
		{
			FinishChoosingCards();
		}
		if (gameIsRunning && !TimeManager.instance.mIsFreezed)
		{
			time -= Time.deltaTime;
		}
		if (time <= 0f && gameIsRunning && !Singleton<PhotonConnectionManager>.instance.isClient && !mIsOverTime)
		{
			mIsOverTime = true;
			Singleton<MatchManager>.instance.StartOverTime(base.mMainPlayerController, GameControllerOnline.mOtherPlayerInstance);
		}
		base.Update();
	}

	protected override void StartMatch()
	{
		base.StartMatch();
		Singleton<GameController>.instance.opponent = null;
		mMinimizedInLobby = false;
	}

	public override void Quit()
	{
		base.Quit();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
	}

	protected override void Reset()
	{
		base.Reset();
		mCardsChoosen = false;
		mRandomConnectTime = 0f;
		mFakeBatteleWithBot = false;
		mIsTutorial = false;
	}

	public override void Rematch()
	{
		LoadingDialog.SetLook(smallLook: true);
		if (isRandomMatchMaking)
		{
			StartRandomMatchMaking();
		}
		else
		{
			base.Rematch();
		}
		GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
	}

	protected override void SpendDogtagLocaly()
	{
		if (isRandomMatchMaking)
		{
			Singleton<DogTagManager>.instance.UseDogTagLocaly();
		}
	}

	protected override void PayDogtag()
	{
		if (isRandomMatchMaking)
		{
			Singleton<DogTagManager>.instance.PayOneDogTag();
		}
	}

	protected void OnJoinedNewRoom()
	{
		float fLOATVALUE = Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MatchmakingInRoomTime).FLOATVALUE;
		float num = Time.realtimeSinceStartup - mRandomConnectTime;
		if (num + fLOATVALUE < mWaitingTime)
		{
			mWaitingTime = num + fLOATVALUE;
		}
		if (isRandomMatchMaking)
		{
			Singleton<EventTrackingManager>.instance.MatchMaking(num);
		}
		Debug.Log($"Matchmaking took {num}, assigning bot in 10 secs");
	}

	protected override void OnConnectionFail(DisconnectCause cause)
	{
		if (isRandomMatchMaking)
		{
			Debug.LogError("OnConnectionFailed: " + cause);
			Debug.LogError(DebugSettings.GetNetworkStatsText());
			CheckIf(cause);
			if (mBothPlayersConnected && HasAllPlayersStateAtLeast(PlayerNetworkStatus.MatchState.CardsChosen))
			{
				ReconnectInGame();
			}
			else if (mBothPlayersConnected && (mMinimizedInLobby || Application.internetReachability == NetworkReachability.NotReachable))
			{
				if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
				{
					PayDogtag();
					MatchManager.matchState = MatchState.ConnectingToPhoton;
					InvokeAfter(delegate
					{
						RestartRandomMatchMaking(resetRandomConnectTime: false);
					}, 1f);
					Debug.LogError("OnConnectionFailed: restarting minus dogtag");
				}
				else
				{
					Debug.LogError("OnConnectionFailed: no dogtags");
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 0f);
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
					Quit();
				}
			}
			else
			{
				Debug.LogError("OnConnectionFailed: restarting");
				LoadingDialog.Hide();
				MatchManager.matchState = MatchState.ConnectingToPhoton;
				InvokeAfter(delegate
				{
					RestartRandomMatchMaking(resetRandomConnectTime: false);
				}, 1f);
			}
		}
		else
		{
			base.OnConnectionFail(cause);
		}
	}

	protected override void PlayerDistonnectedBeforeAfterMatch(PhotonPlayer otherPlayer)
	{
		if (isRandomMatchMaking)
		{
			PlayerDisconnectedInLobby();
		}
		else
		{
			base.PlayerDistonnectedBeforeAfterMatch(otherPlayer);
		}
	}

	protected override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
	{
		if (isRandomMatchMaking)
		{
			Debug.LogError($"OnPhotonJoinRoomFailed: {codeAndMsg[0]}, message {codeAndMsg[1]}");
			if (MatchManager.isReconnect)
			{
				JoinRoomFailedAfterReconnect(Convert.ToInt32(codeAndMsg[0]));
			}
			else
			{
				RestartRandomMatchMaking();
			}
		}
		else
		{
			base.OnPhotonJoinRoomFailed(codeAndMsg);
		}
	}
}
