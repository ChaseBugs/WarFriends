using System.Collections;
using System.Text;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public abstract class GameControllerPVP : GameControllerOnline
{
	protected bool mIsOverTime;

	protected bool mMinimizedInLobby;

	private bool isCurrentController => this == Singleton<GameController>.instance.mainController;

	protected virtual string mChoosingCardsText => Localization.Localize("ID_WAITINGFOROPPONENTCARDS");

	protected override void LoadLevelAndStartGame()
	{
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Singleton<BeanstalkServerManager>.instance.GameStartedMaster();
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.GameStartedClient();
		}
		base.LoadLevelAndStartGame();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DialogCompareUnits>.instance, 0f);
	}

	public override IEnumerator StartGame()
	{
		time = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE + 1f;
		Debug.Log("Set time to: " + time);
		base.mMainPlayerController.Killed -= OnPlayerControllerKilled;
		base.mMainPlayerController.Killed += OnPlayerControllerKilled;
		yield return StartCoroutine(base.StartGame());
		if (PhotonConnectionManager.IsSelfHostedActive)
		{
			SelfHostedBattleClient selfHosted = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
			if (selfHosted == null) throw new System.InvalidOperationException("Self-hosted scene adapter is missing.");
			selfHosted.ActivateDeathMatchScene(base.mMainPlayerController, GameControllerOnline.mOtherPlayerInstance);
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
		yield return StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
		if (PhotonConnectionManager.IsSelfHostedActive)
		{
			SelfHostedBattleClient client = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
			if (client != null) client.DispatchRpc("StartCameraAnimationFinishedRPC");
		}
		else mPhotonView.RPC("StartCameraAnimationFinishedRPC", PhotonTargets.Others, PlayerController.currentPlayer.playerNetworkId);
		StartCameraAnimationFinishedRPC(PlayerController.currentPlayer.playerNetworkId);
		yield return new WaitForRealSeconds(0.2f);
		GameControllerOnline.mOtherPlayerInstance.Killed -= OnOtherPlayerKilled;
		GameControllerOnline.mOtherPlayerInstance.Killed += OnOtherPlayerKilled;
		mIsOverTime = false;
	}

	private void OnOtherPlayerKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		GameControllerOnline.mOtherPlayerInstance.Killed -= OnOtherPlayerKilled;
		if (isCurrentController)
		{
			Singleton<GameCamera>.instance.FocusPlayer((PlayerController)gameMainEntity, damageInfo.owner is PlayerController);
			Singleton<MatchManager>.instance.SetHitBy(damageInfo);
			base.mMainController.gameEndReason = GameController.GameEndReason.Win;
			FinishGame();
		}
	}

	private void OnPlayerControllerKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		base.mMainPlayerController.Killed -= OnPlayerControllerKilled;
		if (isCurrentController)
		{
			Singleton<MatchManager>.instance.SetHitBy(damageInfo);
			base.mMainController.gameEndReason = GameController.GameEndReason.Killed;
			FinishGame();
		}
	}

	protected override Fractions GetPlayerFraction(PhotonPlayer player)
	{
		Fractions fractions = ((!player.IsMasterClient) ? Fractions.Enemies : Fractions.Allies);
		Debug.Log($"Getting fraction for {player} with result {fractions}");
		return fractions;
	}

	public abstract void StartRandomMatchMaking(float connectDelay = 1.5f);

	public abstract void RestartRandomMatchMaking(bool resetRandomConnectTime = true);

	public override void FinishChoosingCards()
	{
		LoadingDialog.SetLook(smallLook: true);
		base.FinishChoosingCards();
	}

	protected override void AllPlayersConnected()
	{
		if (!mBothPlayersConnected)
		{
			base.AllPlayersConnected();
			MatchManager.matchState = MatchState.BothPlayersConnected;
			if (mCardsChoosen && !PhotonConnectionManager.IsSelfHostedActive)
			{
				mPhotonView.RPC("FinishChoosingCardsRPC", PhotonTargets.AllBufferedViaServer, JsonConvert.SerializeObject(GetUnitsUpgrades()), PhotonNetwork.player.ID);
				LoadingDialog.ShowLoading(mChoosingCardsText);
			}
		}
		else
		{
			Debug.LogError("All players already connected");
		}
	}

	protected override void WaitingForOpponentCancelClicked()
	{
		Debug.Log("Loading - cancel clicked, will to try call disconnect");
		if (mCardsChoosen)
		{
			Debug.Log("Cancel - Disconnect, clicked in dialog !!!");
			PhotonConnectionManager.Disconnect();
			StopAllCoroutines();
			Reset();
			RestartRandomMatchMaking();
		}
	}

	public override void GetTimeProgressText(StringBuilder text)
	{
		text.Append((!DebugSettings.debugEnabled) ? string.Empty : ((!PhotonNetwork.isMasterClient) ? "CLIENT" : "MASTER"));
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			text.Append(Localization.Localize("ID_OVERTIME"));
		}
		else if (Singleton<GameController>.instance.time > 0f)
		{
			MiscTools.PrintableTimeTwoDigits(ref text, Singleton<GameController>.instance.time);
		}
	}

	protected void PlayerDisconnectedInLobby()
	{
		mBothPlayersConnected = false;
		if (mCardsChoosen)
		{
			Debug.LogError("Player disconected 0001");
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_OPPONENTCANCELLED"), Localization.Localize("ID_WARNING_OPPONENTDISCONNECTED"), 0f, null, string.Empty);
			LoadingDialog.Hide();
		}
		if (MatchManager.beforeMatch)
		{
			Debug.LogError("Player disconected 0002");
			PhotonConnectionManager.Disconnect();
			Reset();
			mRandomConnectTime = Time.realtimeSinceStartup;
			MatchManager.matchState = MatchState.GameCancelled;
			InvokeAfter(delegate
			{
				RestartRandomMatchMaking();
			}, 0.5f);
		}
	}

	public override void PauseGame(bool focusLost)
	{
		if (!gameIsRunning && focusLost && Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			if (base.isInMatch)
			{
				if (!mBothPlayersConnected)
				{
					PhotonConnectionManager.Disconnect();
					Reset();
				}
				mMinimizedInLobby = true;
			}
		}
		else
		{
			base.PauseGame(focusLost);
		}
	}

	public override void UnPauseGame()
	{
		if (!gameIsRunning && Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			if (base.isInMatch && !mBothPlayersConnected)
			{
				RestartRandomMatchMaking();
				mMinimizedInLobby = false;
			}
		}
		else
		{
			base.UnPauseGame();
		}
	}
}
