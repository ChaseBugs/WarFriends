using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameControllerCoop : GameControllerOnline
{
	public override string loadingWaitingCards => Localization.Localize("ID_WAITINGFORFRIENDCARDS");

	public override string loadingWaiting => Localization.Localize("ID_WAITINGFORFRIEND");

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

	public override bool canDeployUnits => MissionsManager.instance.currentMission is BotMission && PhotonNetwork.isMasterClient;

	protected override bool shouldLooseDogtagWhenQuit => mBothPlayersConnected;

	public override string quitText => Localization.Localize((!shouldLooseDogtagWhenQuit) ? "ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT" : "ID_CONFIRM_EXITINGCOOP_TEXT");

	private Dictionary<string, UnitUpgradeDefinition> mUpgradedSlotsDic { get; set; }

	public override List<UnitUpgradeDefinition> opponentUpgrades
	{
		get
		{
			List<UnitUpgradeDefinition> upgrades = MissionsManager.instance.currentMission.GetUpgrades();
			mUpgradedSlotsDic = new Dictionary<string, UnitUpgradeDefinition>();
			for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				mUpgradedSlotsDic[levelBehaviour.GetType().ToString()] = upgrades[i];
			}
			return upgrades;
		}
	}

	public override List<UnitUpgradeDefinition> myUpgrades
	{
		get
		{
			if (Singleton<PhotonConnectionManager>.instance.isClient)
			{
				return Singleton<GameController>.instance.friend.playerProperties.upgrades;
			}
			return base.myUpgrades;
		}
	}

	protected override void AllPlayersConnected()
	{
		base.AllPlayersConnected();
		Debug.Log("IS COOP BOT: " + Singleton<GameController>.instance.isCoopBot);
		if (mCardsChoosen)
		{
			BotMission botMission = MissionsManager.instance.currentMission as BotMission;
			if (botMission != null)
			{
				PlayerController botInstance = botMission.botInstance;
				botInstance.networkStatus.matchState = PlayerNetworkStatus.MatchState.CardsChosen;
			}
		}
		if (Singleton<GameController>.instance.isCoopBot)
		{
			if (!PhotonNetwork.isMasterClient)
			{
				FinishChoosingCards();
			}
		}
		else
		{
			LoadLevelAndStartGame();
		}
	}

	protected override void LoadLevelAndStartGame()
	{
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Singleton<BeanstalkServerManager>.instance.GameCoopStartedMaster();
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.GameCoopStartedClient();
		}
		base.LoadLevelAndStartGame();
	}

	protected override MapDefinition.DefendPosition GetMainPlayerPoint(Fractions fraction, int ind, PhotonPlayer player)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition playersPosition in Singleton<MapManager>.instance.currentMapDef.playersPositions)
		{
			if (playersPosition.mainPosition && playersPosition.fraction == fraction)
			{
				list.Add(playersPosition);
			}
		}
		if (list.Count > 1)
		{
			if (player.isMasterClient)
			{
				return list[0];
			}
			return list[1];
		}
		Debug.LogError("No main position was set in map definition");
		return null;
	}

	public override void LoadingStarted()
	{
		base.LoadingStarted();
		MissionsManager.instance.currentMission.LoadingStarted();
	}

	public new void StartMultiplayerGame(DatabasePlayer otherPlayer, out string roomName, out bool isGoodPing)
	{
		LoadingDialog.SetLook(smallLook: false);
		base.StartMultiplayerGame(otherPlayer, out roomName, out isGoodPing);
		if (Singleton<GameController>.instance.isCoop && isGoodPing)
		{
			LoadingDialog.ShowLoading(Localization.Localize("ID_WAITINGFORFRIEND"), showCancelButton: true, hideBackgroundElements: true).cancelClicked = DialogResult;
		}
	}

	protected override void StartMatch()
	{
		base.StartMatch();
		Singleton<GameController>.instance.friend = null;
	}

	public override void StartMultiplayerGame(string roomName, CloudRegionCode region)
	{
		LoadingDialog.SetLook(smallLook: false);
		base.StartMultiplayerGame(roomName, region);
		if (Singleton<GameController>.instance.isCoop)
		{
			LoadingDialog.ShowLoading(Localization.Localize("ID_WAITINGFORFRIEND"), showCancelButton: false, hideBackgroundElements: true).cancelClicked = DialogResult;
		}
	}

	private void DialogResult()
	{
		Debug.Log("Cancel clicked, will to try call disconnect ");
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
		Debug.Log("Disconnect, clicked on dialog !!!");
		PhotonConnectionManager.Disconnect();
		StopAllCoroutines();
		Quit();
	}

	public override IEnumerator StartGame()
	{
		base.mMainPlayerController.Killed -= OnPlayerControllerKilled;
		base.mMainPlayerController.Killed += OnPlayerControllerKilled;
		GameControllerOnline.mOtherPlayerInstance.Killed -= OtherPlayerInstanceOnKilled;
		GameControllerOnline.mOtherPlayerInstance.Killed += OtherPlayerInstanceOnKilled;
		yield return StartCoroutine(base.StartGame());
		time = 0f;
		MissionsManager.instance.PlayCurrentMission();
		yield return new WaitForSeconds(0.2f);
		LoadingDialog.Hide();
		Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
		if (base.mMainController.isCoopBot || base.mMainController.isCampaignBot)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
			yield return StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
			mPhotonView.RPC("StartCameraAnimationFinishedRPC", PhotonTargets.Others, PlayerController.currentPlayer.playerNetworkId);
			StartCameraAnimationFinishedRPC(PlayerController.currentPlayer.playerNetworkId);
			yield return new WaitForSeconds(0.2f);
		}
		else
		{
			yield return StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(2f));
			mPhotonView.RPC("StartCameraAnimationFinishedRPC", PhotonTargets.Others, PlayerController.currentPlayer.playerNetworkId);
			StartCameraAnimationFinishedRPC(PlayerController.currentPlayer.playerNetworkId);
			yield return new WaitForSeconds(0.8f);
		}
	}

	private void OtherPlayerInstanceOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		if (Singleton<GameController>.instance.mainController == this && !Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			PlayerController player = (PlayerController)gameMainEntity;
			Singleton<GameCamera>.instance.FocusPlayer(player, damageInfo.owner is PlayerController);
		}
	}

	public override void GetTimeProgressText(StringBuilder text)
	{
		MiscTools.PrintableTimeTwoDigits(ref text, MissionsManager.instance.time);
	}

	public override void Quit()
	{
		base.Quit();
		MissionsManager.instance.QuitCurrentMission();
	}

	private void OnPlayerControllerKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo arg3)
	{
		base.mMainPlayerController.Killed -= OnPlayerControllerKilled;
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this && !Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Singleton<MatchManager>.instance.SetHitBy(arg3);
			base.mMainController.gameEndReason = GameController.GameEndReason.Kia;
			PlayerController.currentPlayer.networkStatus.matchState = PlayerNetworkStatus.MatchState.GameFinished;
			mPhotonView.RPC("FinishGameCoopClient", PhotonTargets.Others, (byte)Singleton<GameController>.instance.gameEndReason, PhotonNetwork.player.ID);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameOverScreen>.instance);
			StartCoroutine(StartSpectate());
		}
	}

	private IEnumerator StartSpectate()
	{
		while (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
		{
			yield return null;
			if (GuiElementSingle<PauseScreen>.instance.isShowed)
			{
				GuiElementSingle<PauseScreen>.instance.HideDialog();
			}
		}
		TimeManager.instance.SetupPhysicsTiming(ragdoll: false);
		Singleton<PerformanceManager>.instance.SetShadowsDistance(shortDistance: false);
		Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.mOtherPlayerInstance);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
		PlayerController.currentPlayer.gameObject.SetActive(value: false);
		if (TimeManager.instance.isPaused && gameIsRunning)
		{
			TimeManager.FreezeGame();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 0f);
		}
		else
		{
			TimeManager.UnFreezeGame(0f);
		}
	}

	protected override void UpdatePause()
	{
		if (!gameIsRunning || !TimeManager.instance.isPaused || !(TimeManager.pauseTimeLeft <= 0f) || MatchManager.isReconnect)
		{
			return;
		}
		if (TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedRemote)
		{
			ResumeGame();
		}
		if (TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedRemoteFocusLost)
		{
			if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
			{
				ResumeGame();
			}
			else
			{
				Forfeit();
			}
		}
	}

	public override void Forfeit()
	{
		base.Forfeit();
		MissionsManager.instance.currentMission.EndMission();
		if (Singleton<PhotonConnectionManager>.instance.isClient)
		{
			Disconnect();
		}
	}

	public override void FinishGame()
	{
		StopAllCoroutines();
		if (base.mMainController.isCoop)
		{
			TimeManager.instance.EndMission();
		}
		if (gameIsRunning)
		{
			Singleton<MatchManager>.instance.matchTime = time;
			if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
			{
				mPhotonView.RPC("FinishGameMultiplayerRPC", PhotonTargets.Others, (byte)Singleton<GameController>.instance.gameEndReason);
			}
			else
			{
				mPhotonView.RPC("FinishGameCoopClient", PhotonTargets.Others, (byte)Singleton<GameController>.instance.gameEndReason, PhotonNetwork.player.ID);
			}
			SetStateToAllPlayers(PlayerNetworkStatus.MatchState.GameFinished);
			MatchManager.matchState = MatchState.GameFinished;
			gameIsRunning = false;
			Reset();
			base.mMainController.FinishGame();
		}
	}

	[PunRPC]
	private void FinishGameCoopClient(byte gameEndReason, int playerId)
	{
		DisalblePlayerAndResumeGame(playerId, 3f, (GameController.GameEndReason)gameEndReason);
	}

	private void DisalblePlayerAndResumeGame(int playerId, float time, GameController.GameEndReason gameEndReason)
	{
		PlayerController player = PlayerController.GetPlayer(playerId);
		if (player != null)
		{
			if (gameEndReason == GameController.GameEndReason.Kia)
			{
				GuiElementSingle<CoopInfos>.instance.ShowCoopPartnerDied();
			}
			else
			{
				GuiElementSingle<CoopInfos>.instance.ShowCoopPartnerLeft();
				ResumeGame();
			}
			player.currentPlayerPoint = null;
			player.networkStatus.active = false;
			player.networkStatus.startAnimationFinished = true;
			InvokeAfterRealTime(delegate
			{
				player.gameObject.SetActive(value: false);
				TimeManager.instance.SetupPhysicsTiming(ragdoll: false);
			}, time);
		}
	}

	[PunRPC]
	protected override void FinishGameMultiplayerRPC(byte gameEndReason)
	{
		StopAllCoroutines();
		if (base.mMainController.isCoop)
		{
			TimeManager.instance.EndMission();
		}
		base.FinishGameMultiplayerRPC(gameEndReason);
	}

	protected override void CheckIfDisconnected3rdTime(PlayerController playerController)
	{
	}

	protected override void CheckForReconnect()
	{
		CheckPlayersReconnectStates();
		if (gameIsRunning && (MatchManager.isReconnect || !MatchManager.allPlayersFinishetStartAnimation))
		{
			if (MatchManager.isReconnect)
			{
				float value = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.reconnectTime);
				value = Mathf.Clamp(value, 0f, float.PositiveInfinity);
				GuiElementSingle<ReconnectDialog>.instance.SetWaitTime(value);
				if (value <= 0f && (PhotonNetwork.room == null || PhotonNetwork.room.playerCount != 2))
				{
					if (MatchManager.reconnectState == ReconnectState.Me)
					{
						Forfeit();
					}
					else if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
					{
						if (PhotonNetwork.room != null)
						{
							PhotonNetwork.room.open = false;
						}
						GuiElementSingle<ReconnectDialog>.instance.HideDialog();
						TimeManager.Resume();
						DisalblePlayerAndResumeGame(Singleton<GameController>.instance.friend.playerNetworkId, 0f, GameController.GameEndReason.Forfeit);
					}
					else
					{
						Forfeit();
					}
					GuiElementSingle<ReconnectDialog>.instance.HideDialog();
				}
			}
			else
			{
				GuiElementSingle<ReconnectDialog>.instance.SetWaitTime(-1f);
			}
		}
		UpdateReconnectDialog();
	}

	protected override void Update()
	{
		base.Update();
		Mission currentMission = MissionsManager.instance.currentMission;
		if (gameIsRunning && TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedRemote && TimeManager.pauseTimeLeft <= 0f && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			mPhotonView.RPC("FinishGameMultiplayerRPC", PhotonTargets.Others, (byte)5);
			TimeManager.Resume();
		}
		if (Time.realtimeSinceStartup > MatchManager.matchStartTime && mBothPlayersConnected && !mCardsChoosen && PhotonNetwork.inRoom && Singleton<GameController>.instance.isCoopBot)
		{
			FinishChoosingCards();
		}
		if (PlayerController.currentPlayer.networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch && GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			LoadingDialog.SetHeader(MatchManager.matchStatusLoading);
			string matchTimeStatus = MatchManager.matchTimeStatus;
			string text = ((!string.IsNullOrEmpty(matchTimeStatus)) ? matchTimeStatus : MatchManager.matchStatusAfterMatch);
			LoadingDialog.SetText(text);
		}
		if (MatchManager.matchState == MatchState.WaitingForOpponent && GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			string matchTimeStatus2 = MatchManager.matchTimeStatus;
			LoadingDialog.SetText(matchTimeStatus2);
		}
	}

	public override IEnumerator AquireLevelName()
	{
		yield break;
	}

	public override void FinishChoosingCards()
	{
		BotMission botMission = MissionsManager.instance.currentMission as BotMission;
		if (botMission != null && botMission.botInstance != null)
		{
			if (mBothPlayersConnected)
			{
				PlayerController botInstance = botMission.botInstance;
				botInstance.networkStatus.matchState = PlayerNetworkStatus.MatchState.CardsChosen;
			}
			base.FinishChoosingCards();
			LoadingDialog.ShowLoading(loadingWaitingCards);
		}
	}

	public override void Rematch()
	{
		LoadingDialog.SetLook(smallLook: false);
		MissionsManager.instance.currentMission.OpenMission(null, isInvite: false, isRematch: true, isHeroicMode: false);
		BotMission botMission = MissionsManager.instance.currentMission as BotMission;
		if (botMission != null)
		{
			PlayerController botInstance = botMission.botInstance;
			botInstance.networkStatus.matchState = PlayerNetworkStatus.MatchState.Rematch;
			if (PhotonNetwork.isMasterClient)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			}
			else
			{
				LoadingDialog.ShowLoading(Localization.Localize("ID_WAITINGFORFRIEND"), showCancelButton: true, hideBackgroundElements: true).cancelClicked = DialogResult;
			}
		}
		else
		{
			LoadingDialog.ShowLoading(Localization.Localize("ID_WAITINGFORFRIEND"), showCancelButton: true, hideBackgroundElements: true).cancelClicked = DialogResult;
		}
		base.Rematch();
	}

	public override void PauseGame(bool focusLost)
	{
		if (!gameIsRunning)
		{
			return;
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			if (mPausesCount < 1)
			{
				TimeManager.Pause(focusLost);
			}
			else if (focusLost)
			{
				TimeManager.Pause(focusLost);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CantPauseDialog>.instance, 0f);
			}
		}
		else if (PlayerController.currentPlayer.networkStatus.matchState == PlayerNetworkStatus.MatchState.GameFinished)
		{
			Forfeit();
		}
		else if (mPausesCount < 1)
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
		mPausesCount++;
		PhotonNetwork.SendOutgoingCommands();
	}

	protected override Dictionary<string, UnitUpgradeDefinition> GetUpgradesDictionary(Fractions fraction)
	{
		if (Singleton<PhotonConnectionManager>.instance.isClient)
		{
			return Singleton<GameController>.instance.friend.playerProperties.upgradesDictionary;
		}
		if (fraction == PlayerController.currentPlayer.fraction)
		{
			return PlayerController.currentPlayer.playerProperties.upgradesDictionary;
		}
		return mUpgradedSlotsDic;
	}

	public override UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool isPreview, AIObject o)
	{
		LevelBehaviour behaviour = o.behaviour;
		Fractions fraction = o.fraction;
		UpgradeSlots.UnitUpgrades unitUpgrades = base.PickUpgradesForUnit(isPreview, o);
		unitUpgrades = MissionsManager.ScaleUpgradesForMission(fraction, behaviour, unitUpgrades);
		behaviour.behaviourDefinition.ScaleDamageAndHP(unitUpgrades.scaleDamage, unitUpgrades.scaleHp);
		return unitUpgrades;
	}
}
