using System;
using Google2u;
using UnityEngine;

public class GameControllerDeathMatch : GameControllerPVP
{
	private bool mFakeBatteleWithBot;

	private bool mIsTutorial;

    private System.Threading.CancellationTokenSource _matchmakingRequest;
    private SelfHostedBattleClient _matchmakingClient;
    private bool _switchingToBot;
    private int _matchmakingGeneration;

	private float mWaitingTime = 20f;

	public bool isRandomMatchMaking { get; private set; }

	public override string loadingWaiting => Localization.Localize((!isRandomMatchMaking) ? "ID_STATE_WAITINGFOROPPONENT" : "ID_STATE_SEARCHINGFOROPPONENT");

	protected override string mChoosingCardsText => Localization.Localize((!isRandomMatchMaking) ? "ID_WAITINGFORFRIENDCARDS" : "ID_WAITINGFOROPPONENTCARDS");

	protected override bool shouldLooseDogtagWhenQuit => false;

	public override string quitText => Localization.Localize((!isRandomMatchMaking) ? "ID_CONFIRM_EXITINGMATCHNODOGTAG_TEXT" : "ID_CONFIRM_EXITINGMATCH_TEXT");

	public override void StartRandomMatchMaking(float connectDelay = 1.5f)
	{
        RequireAbortRecoveryComplete();
        SelfHostedBattleClient previous = PhotonConnectionManager.GetOwnedSelfHostedClient();
        if (previous != null)
        {
            // Source random Rematch starts a new search; it cannot reuse a terminal room.
            previous.ReleaseEndedMatchForNewSearch();
        }
		LoadingDialog.SetLook(smallLook: true);
		Screen.sleepTimeout = -1;
		PlayerController.players.Clear();
		StartMatch();
        // Missing retired-service measurements cannot prove high latency or force a local bot battle.
        bool hasMeasuredHighPing = PhotonConnectionManager.HasMeasuredRegionPingAbove(
            (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE);
		mWaitingTime = Singleton<GameVariables>.instance.maxMatchmakingTime;
        if (OfflineBotProgress.IsDisconnected || hasMeasuredHighPing || BotManager.useEasyBot || UserDeviceManager.instance.IsSlowDevice() ||
            StatsManager.instance.deathMatchLossesInRow >= 3f)
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
			BeginSelfHostedRandomMatchmakingAsync(connectDelay);
			PayDogtag();
		}
	}

    private async void BeginSelfHostedRandomMatchmakingAsync(float connectDelay)
    {
        var request = new System.Threading.CancellationTokenSource();
        _matchmakingRequest = request;
        try
        {
            if (connectDelay > 0f)
            {
                const int MillisecondsPerSecond = 1000;
                await System.Threading.Tasks.Task.Delay((int)(connectDelay * MillisecondsPerSecond), request.Token);
            }

            request.Token.ThrowIfCancellationRequested();
            SelfHostedBattleClient client = SelfHostedBattleClient.GetOrCreate();
            _matchmakingClient = client;
            await client.MatchmakeWithRecoveredSession();
            request.Token.ThrowIfCancellationRequested();
            if (_matchmakingRequest != request || _switchingToBot)
            {
                return;
            }

            Singleton<PhotonConnectionManager>.instance.CompleteSelfHostedJoin();
            AllPlayersConnected();
        }
        catch (OperationCanceledException)
        {
            // Leaving or restarting the lobby must not publish a join or reset a newer request.
        }
        catch (Exception exception)
        {
            if (_matchmakingRequest == request && !request.IsCancellationRequested && !_switchingToBot)
            {
                Debug.LogError("Self-hosted matchmaking failed: " + exception.GetType().Name);
                MatchManager.matchState = MatchState.GameCancelled;
                Reset();
                WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT"),
                    Localization.Localize("ID_WARNING_CANNOTINVITE"), 0f, null, string.Empty);
            }
        }
        finally
        {
            if (_matchmakingRequest == request)
            {
                _matchmakingRequest = null;
                _matchmakingClient = null;
            }

            request.Dispose();
        }
    }

    private async void SwitchTimedOutSearchToBotAsync()
    {
        _switchingToBot = true;
        var request = _matchmakingRequest;
        float searchStarted = mRandomConnectTime;
        int generation = _matchmakingGeneration;
        try
        {
            // A queue timeout is not a cancellation receipt. Wait until the Backend
            // confirms this search cannot also admit a human opponent.
            SelfHostedBattleClient client = _matchmakingClient ?? SelfHostedBattleClient.Active;
            if (client != null)
            {
                await client.CancelMatchmaking();
            }
            if (this == null || !isActiveAndEnabled || generation != _matchmakingGeneration || mRandomConnectTime != searchStarted ||
                !isRandomMatchMaking || mBothPlayersConnected)
            {
                return;
            }
            if (request != null && _matchmakingRequest == request)
            {
                request.Cancel();
            }
            PhotonConnectionManager.Disconnect();
            PhotonNetwork.offlineMode = true;
            mFakeBatteleWithBot = true;
            MatchManager.matchState = MatchState.WaitingForOpponent;
            mFindBotAfter = Time.realtimeSinceStartup - searchStarted + 1f;
            mBotChooseCardsAfter = Time.realtimeSinceStartup - searchStarted +
                UnityEngine.Random.Range(1f, !DebugSettings.debugEnabled ? 10f : 2f);
            Singleton<GameController>.instance.opponent = null;
            Debug.Log("Starting match against bot after confirmed queue cancellation");
        }
        catch (Exception exception)
        {
            // Keep the queue owner on failure; starting another battle could double-admit.
            Debug.LogWarning("Bot fallback is waiting for queue cancellation: " + exception.GetType().Name);
            if (generation == _matchmakingGeneration) mRandomConnectTime = Time.realtimeSinceStartup;
        }
        finally
        {
            if (generation == _matchmakingGeneration) _switchingToBot = false;
        }
    }

    private void CancelSelfHostedMatchmaking()
    {
        System.Threading.CancellationTokenSource request = _matchmakingRequest;
        SelfHostedBattleClient client = _matchmakingClient;
        _matchmakingRequest = null;
        _matchmakingClient = null;
        if (request != null)
        {
            request.Cancel();
            if (client != null && (client.IsMatchmaking || client.OwnsMatch))
            {
                client.LeaveMatch();
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        CancelSelfHostedMatchmaking();
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
		BeginSelfHostedRandomMatchmakingAsync(0f);
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
        if (!_switchingToBot && !mFakeBatteleWithBot && !mBothPlayersConnected &&
            isRandomMatchMaking && mRandomConnectTime != 0f &&
            Time.realtimeSinceStartup > mRandomConnectTime + mWaitingTime &&
            Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
        {
            SwitchTimedOutSearchToBotAsync();
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
        SelfHostedBattleClient selfHosted = SelfHostedBattleClient.Active;
        if (selfHosted != null && selfHosted.OwnsMatch)
        {
            ApplySelfHostedClock(selfHosted);
        }
        else
        {
            if (gameIsRunning && !TimeManager.instance.mIsFreezed)
            {
                time -= Time.deltaTime;
            }

            if (time <= 0f && gameIsRunning && !Singleton<PhotonConnectionManager>.instance.isClient && !mIsOverTime)
            {
                mIsOverTime = true;
                Singleton<MatchManager>.instance.StartOverTime(
                    base.mMainPlayerController, GameControllerOnline.mOtherPlayerInstance);
            }
        }
		base.Update();
	}

    private void ApplySelfHostedClock(SelfHostedBattleClient client)
    {
        if (client.State == null)
        {
            return;
        }

        // Local frame time must not start overtime, destroy shields or send a retired Photon RPC.
        War.Client.PvpMatchClock clock = War.Client.PvpMatchClock.FromSnapshot(client.State);
        time = clock.RemainingSeconds;
        mIsOverTime = clock.IsOvertime;
        if (gameIsRunning)
        {
            // Preserve the recovered GameStarted-before-overtime UI callback order while loading.
            Singleton<MatchManager>.instance.ApplySelfHostedOvertime(clock);
        }
    }

	protected override void StartMatch()
	{
		base.StartMatch();
		Singleton<GameController>.instance.opponent = null;
		mMinimizedInLobby = false;
	}

	public override void Quit()
	{
        if (mMainController.IsSelfHostedAbortRecovery)
        {
            return;
        }

		base.Quit();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
	}

	protected override void Reset()
	{
        _matchmakingGeneration++;
        _switchingToBot = false;
        CancelSelfHostedMatchmaking();
		base.Reset();
		mCardsChoosen = false;
		mRandomConnectTime = 0f;
		mFakeBatteleWithBot = false;
		mIsTutorial = false;
	}

	public override void Rematch()
	{
        if (!isRandomMatchMaking)
        {
            RequireSelfHostedRematchSource();
        }

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
