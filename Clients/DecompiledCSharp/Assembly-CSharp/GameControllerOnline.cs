using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public abstract class GameControllerOnline : IGameController
{
	protected static PlayerController mOtherPlayerInstance;

	protected bool mBothPlayersConnected;

	private int mStateUpdateCounter;

	protected List<int> mPhotonIds;

	protected PhotonView mPhotonView;

	private bool mIsInMatch;

	private bool mShowWaitingForPlayer;

	protected bool mIsWaitingToAcceptInvitation;

	private double mMatchStart;

	protected bool mCardsChoosen;

	protected int mMapId;

	private float mTImer;

	protected bool mMapIdSet;

	protected int mPausesCount;

	protected float mRandomConnectTime;

	protected float mFindBotAfter = 10f;

	protected float mBotChooseCardsAfter = 15f;

	public override bool dropCreates
	{
		get
		{
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MatchmakingEasyBotTillLevel).FLOATVALUE;
			return !LevelManager.isNoob && mOtherPlayerInstance != null && (float)mOtherPlayerInstance.playerProperties.level > (float)fLOATVALUE;
		}
	}

	protected PlayerController mMainPlayerController => Singleton<GameController>.instance.mainPlayerController;

	public override float time { get; set; }

	public virtual string loadingWaitingCards => Localization.Localize("ID_WAITINGFOROPPONENTCARDS");

	public virtual string loadingWaiting => Localization.Localize("ID_STATE_WAITINGFOROPPONENT");

	private bool allPlayersFinishedLoading
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
			{
				if (player.Value.networkStatus.matchState < PlayerNetworkStatus.MatchState.LoadingFinished)
				{
					return false;
				}
			}
			return true;
		}
	}

	private bool allPlayersStartAnimation
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
			{
				if (!player.Value.networkStatus.startAnimationFinished)
				{
					return false;
				}
			}
			return true;
		}
	}

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

	public bool isInMatch
	{
		get
		{
			return mIsInMatch;
		}
		set
		{
			mIsInMatch = value;
			Debug.Log("Set isInMatch: " + value);
		}
	}

	public override bool canShowPause => !MatchManager.isReconnect && MatchManager.allPlayersFinishetStartAnimation;

	protected virtual bool shouldLooseDogtagWhenQuit => false;

	public override bool pauseCountDown => true;

	public override bool canDeployUnits => true;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (action == DatabaseAction.PayOneDogTag && Singleton<GameController>.instance.mainController == this)
		{
			Quit();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
		}
	}

	protected override void Start()
	{
		base.Start();
		PhotonView[] componentsInChildren = mMainPlayerController.GetComponentsInChildren<PhotonView>(includeInactive: true);
		mPhotonIds = new List<int>();
		PhotonView[] array = componentsInChildren;
		foreach (PhotonView photonView in array)
		{
			int item = ((photonView.viewID != 0) ? photonView.viewID : NetworkObjectPool.AllocateNetworkId());
			mPhotonIds.Add(item);
			mPhotonView.didAwake = true;
		}
	}

	public override IEnumerator StartGame()
	{
		mShowWaitingForPlayer = false;
		Debug.Log("ResumeMessageQueue");
		PhotonNetwork.ResumeMessageQueue();
		mMatchStart = double.PositiveInfinity;
		Fractions fr = mMainPlayerController.fraction;
		int ind = (int)PhotonNetwork.player.customProperties["defendPosition"];
		MapDefinition.DefendPosition defendPosition = GetMainPlayerPoint(fr, ind, PhotonNetwork.player);
		mMainPlayerController.MoveTo(defendPosition.point.transform.position, defendPosition.point.transform.rotation);
		mMainPlayerController.currentPlayerPoint = defendPosition;
		SetUpPhotonViews(mMainPlayerController);
		Debug.Log("Create player instance at " + defendPosition.point.transform.parent.name + " :" + defendPosition.point.name);
		int i = (int)mOtherPlayerInstance.playerProperties.photonPlayer.customProperties["defendPosition"];
		mOtherPlayerInstance.gameObject.SetActive(value: true);
		MapDefinition.DefendPosition def = GetMainPlayerPoint(mOtherPlayerInstance.fraction, i, mOtherPlayerInstance.playerProperties.photonPlayer);
		mOtherPlayerInstance.currentPlayerPoint = def;
		mOtherPlayerInstance.MoveTo(def.point.transform.position, def.point.transform.rotation);
		foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
		{
			player.Value.InitPlayer();
		}
		PlayerController.currentPlayer.networkStatus.matchState = PlayerNetworkStatus.MatchState.LoadingFinished;
		mPhotonView.RPC("LoadingFinishedRPC", PhotonTargets.AllBufferedViaServer, PhotonNetwork.player.ID, ++mStateUpdateCounter);
		float mYieldStartTime = Time.realtimeSinceStartup;
		InvokeAfter(delegate
		{
			if (PhotonNetwork.time < mMatchStart)
			{
				mShowWaitingForPlayer = true;
			}
		}, 3f);
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			while (!allPlayersFinishedLoading)
			{
				yield return null;
				if (!(Time.time > mYieldStartTime + 5f))
				{
					continue;
				}
				mYieldStartTime = Time.realtimeSinceStartup;
				Debug.LogError($"Waiting too long for all playersFinish to loading");
				foreach (KeyValuePair<int, PlayerController> playerController in PlayerController.players)
				{
					Debug.Log($"Player {playerController.Value.playerProperties.name} state: {playerController.Value.networkStatus.matchState}");
				}
			}
			SyncMatchStart(PhotonNetwork.time + 2.0);
		}
		mYieldStartTime = Time.realtimeSinceStartup;
		while (PhotonNetwork.time < mMatchStart)
		{
			yield return null;
			if (Time.time > mYieldStartTime + 5f)
			{
				mYieldStartTime = Time.realtimeSinceStartup;
				Debug.LogError($"Waiting too long to start match, Match start: {mMatchStart} photon time: {PhotonNetwork.time}");
			}
		}
		Singleton<MapManager>.instance.currentMapDef.InitShields();
		LoadingDialog.Hide();
		PhotonNetwork.NetworkStatisticsEnabled = true;
	}

	protected bool HasAllPlayersStateAtLeast(PlayerNetworkStatus.MatchState state)
	{
		foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
		{
			if (player.Value.networkStatus.matchState < state)
			{
				return false;
			}
		}
		return true;
	}

	protected bool HasAllPlayersStateExacly(PlayerNetworkStatus.MatchState state)
	{
		foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
		{
			if (player.Value.networkStatus.matchState != state)
			{
				return false;
			}
		}
		return true;
	}

	[PunRPC]
	protected void LoadingFinishedRPC(int playerID, int stateCounter)
	{
		PlayerController player = PlayerController.GetPlayer(playerID);
		if (player != null)
		{
			player.networkStatus.SetState(PlayerNetworkStatus.MatchState.LoadingFinished, stateCounter);
		}
	}

	public virtual void OnPhotonCustomRoomPropertiesChanged(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
		foreach (DictionaryEntry item in propertiesThatChanged)
		{
			if (item.Key as string == "MatchStart" && item.Value is double && (double)item.Value != double.PositiveInfinity)
			{
				mMatchStart = (double)item.Value;
				Debug.Log($"Match start time {mMatchStart} photon time: {PhotonNetwork.time}");
			}
		}
	}

	private void SyncMatchStart(double start)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable.Add("MatchStart", start);
		ExitGames.Client.Photon.Hashtable propertiesToSet = hashtable;
		if (PhotonNetwork.room != null)
		{
			PhotonNetwork.room.SetCustomProperties(propertiesToSet);
		}
		mMatchStart = start;
		Debug.Log($"Sync match start time {mMatchStart} photon time: {PhotonNetwork.time}");
	}

	public override void FinishChoosingCards()
	{
		mCardsChoosen = true;
		GuiElementSingle<ChatGuiElement>.instance.BattleStarted();
		GuiScreenSingle<CardSelectionScreen>.instance.SetCardsForGame();
		DialogManager.instance.HideAllDialogs();
		PlayerController.currentPlayer.playerProperties.chosenCards = CardManager.instance.selectedCards;
		PlayerController.currentPlayer.playerProperties.buddyCards = CardManager.instance.selectedBuddyCards;
		PlayerController.currentPlayer.playerProperties.upgrades = GetUnitsUpgrades();
		if (mBothPlayersConnected)
		{
			Debug.Log("Send FinishChoosingCardsRPC: " + PhotonNetwork.player.ID);
			if (!PhotonNetwork.offlineMode)
			{
				string text = JsonConvert.SerializeObject(GetUnitsUpgrades());
				string text2 = JsonConvert.SerializeObject(CardManager.instance.selectedBuddyCards);
				mPhotonView.RPC("FinishChoosingCardsRPC", PhotonTargets.AllBufferedViaServer, text, PhotonNetwork.player.ID, ++mStateUpdateCounter, CardManager.instance.selectedCards, text2);
			}
			LoadingDialog.ShowLoading(loadingWaitingCards);
		}
		else
		{
			LoadingDialog.ShowLoading(loadingWaitingCards, showCancelButton: true).cancelClicked = WaitingForOpponentCancelClicked;
		}
	}

	protected virtual void WaitingForOpponentCancelClicked()
	{
	}

	protected virtual void AllPlayersConnected()
	{
		Debug.Log("ALL PLAYERS CONNECTED");
		if (!mBothPlayersConnected)
		{
			mBothPlayersConnected = true;
			mIsWaitingToAcceptInvitation = false;
			PlayerController.players[PhotonNetwork.player.ID] = PlayerController.currentPlayer;
			PlayerController.currentPlayer = mMainPlayerController;
			PlayerController.currentPlayer.playerNetworkId = PhotonNetwork.player.ID;
			PlayerController.currentPlayer.networkStatus.Reset();
			PlayerController.currentPlayer.networkStatus.matchState = PlayerNetworkStatus.MatchState.Connected;
			PlayerController.currentPlayer.fraction = GetPlayerFraction(PhotonNetwork.player);
			PhotonPlayer[] playerList = PhotonNetwork.playerList;
			foreach (PhotonPlayer photonPlayer in playerList)
			{
				if (photonPlayer != PhotonNetwork.player)
				{
					CreatePlayerInstance(photonPlayer);
				}
			}
			PhotonNetwork.ResumeMessageQueue();
			PhotonNetwork.room.visible = false;
			int num = LevelManager.instance.currentLevel.displayNumber;
			foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
			{
				if (player.Value != null && player.Value.playerProperties != null)
				{
					num = Mathf.Max(num, player.Value.playerProperties.level);
				}
			}
			MatchManager.matchState = MatchState.BothPlayersConnected;
			MatchManager.matchStartTime = Time.realtimeSinceStartup + (float)GameVariables.GetMatchStartTime(num);
			MatchManager.invitationState = InvitationState.Accepted;
			if (mCardsChoosen)
			{
				string text = JsonConvert.SerializeObject(CardManager.instance.selectedBuddyCards);
				mPhotonView.RPC("FinishChoosingCardsRPC", PhotonTargets.AllBufferedViaServer, JsonConvert.SerializeObject(GetUnitsUpgrades()), PhotonNetwork.player.ID, ++mStateUpdateCounter, CardManager.instance.selectedCards, text);
				LoadingDialog.ShowLoading(loadingWaitingCards);
			}
		}
		else
		{
			Debug.LogError("All players already connected");
		}
	}

	[PunRPC]
	public virtual void FinishChoosingCardsRPC(string upgradesJson, int playerId, int stateCounter, string chosenCards, string selectedBuddyCards)
	{
		Debug.Log("Cards choosen " + playerId);
		PlayerController player = PlayerController.GetPlayer(playerId);
		if (!(player != null))
		{
			return;
		}
		if (player.networkStatus.SetState(PlayerNetworkStatus.MatchState.CardsChosen, stateCounter))
		{
			player.playerProperties.UpdateSelectedUnits(upgradesJson);
			List<Tuple<string, CardManager.BuddyCardData>> buddyCards = JsonConvert.DeserializeObject<List<Tuple<string, CardManager.BuddyCardData>>>(selectedBuddyCards);
			player.playerProperties.chosenCards = chosenCards;
			player.playerProperties.buddyCards = buddyCards;
			if (HasAllPlayersStateExacly(PlayerNetworkStatus.MatchState.CardsChosen) && PlayerController.players.Count >= 2)
			{
				LoadLevelAndStartGame();
			}
		}
		player.playerProperties.chosenCards = chosenCards;
	}

	protected virtual MapDefinition.DefendPosition GetMainPlayerPoint(Fractions fraction, int ind, PhotonPlayer p)
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
			return list[ind];
		}
		Debug.LogError("No main position was set in map definition");
		return null;
	}

	protected virtual Fractions GetPlayerFraction(PhotonPlayer player)
	{
		return Fractions.Allies;
	}

	protected virtual void LoadLevelAndStartGame()
	{
		Debug.Log("StopMessageQueue");
		PhotonNetwork.StopMessageQueue();
		Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
	}

	[PunRPC]
	protected void StartCameraAnimationFinishedRPC(int id)
	{
		PlayerController player = PlayerController.GetPlayer(id);
		Debug.Log($"StartCameraAnimationFinishedRPC for player {id} ");
		if (player != null)
		{
			player.networkStatus.startAnimationFinished = true;
		}
		else
		{
			Debug.LogError("Cant fing player");
		}
		ChekIfAllFinishedStartAnim();
	}

	private void ChekIfAllFinishedStartAnim()
	{
		if (GuiElementSingle<ReconnectDialog>.instance.isShowed && MatchManager.allPlayersFinishetStartAnimation)
		{
			GuiElementSingle<ReconnectDialog>.instance.HideDialog();
			TimeManager.Resume();
		}
	}

	protected virtual void StartMatch()
	{
		mShowWaitingForPlayer = false;
		mMainPlayerController.playerProperties = PlayerProperties.CreateForLocalPlayer();
		isInMatch = true;
		mStateUpdateCounter = 0;
		MatchManager.matchStartTime = 0f;
		MatchManager.matchState = MatchState.ConnectingToPhoton;
		PlayerController.currentPlayer.networkStatus.Reset();
		ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.player);
		TimeManager.instance.ResetPauseCounters();
	}

	public virtual void StartMultiplayerGame(DatabasePlayer otherPlayer, out string roomName, out bool isGoodPing)
	{
		Screen.sleepTimeout = -1;
		CloudRegionCode bestRegion = PhotonConnectionManager.GetBestRegion(PhotonConnectionManager.bestRegions, otherPlayer.bestRegions, out isGoodPing);
		if (isGoodPing)
		{
			SpendDogtagLocaly();
			Reset();
			PlayerController.players.Clear();
			mIsWaitingToAcceptInvitation = true;
			StartMatch();
			MatchManager.invitationState = InvitationState.Waiting;
			MatchManager.invitationExpireTime = Time.realtimeSinceStartup + 120f;
		}
		roomName = ((!isGoodPing) ? string.Empty : Singleton<PhotonConnectionManager>.instance.ConnectToRoom(bestRegion, 0.5f));
	}

	public virtual void StartMultiplayerGame(string roomName, CloudRegionCode region)
	{
		Screen.sleepTimeout = -1;
		SpendDogtagLocaly();
		Debug.Log("Connect to room " + roomName);
		PlayerController.players.Clear();
		Reset();
		StartMatch();
		MatchManager.invitationState = InvitationState.Accepted;
		Singleton<PhotonConnectionManager>.instance.ConnectToRoom(region, roomName, 2f);
	}

	protected virtual void Reset()
	{
		mIsWaitingToAcceptInvitation = false;
		mPausesCount = 0;
		mBothPlayersConnected = false;
		mCardsChoosen = false;
		MatchManager.invitationState = InvitationState.None;
		mMapIdSet = false;
	}

	[PunRPC]
	public void RematchRPC(int playerID, int stateUpdate)
	{
		PlayerController player = PlayerController.GetPlayer(playerID);
		if (player != null && player.networkStatus.SetState(PlayerNetworkStatus.MatchState.Rematch, stateUpdate))
		{
			CheckRematchStates();
		}
	}

	private void CheckRematchStates()
	{
		if (HasAllPlayersStateAtLeast(PlayerNetworkStatus.MatchState.Rematch))
		{
			AllPlayersConnected();
		}
		MatchManager.rematchExpireTime = Time.realtimeSinceStartup + 30f;
		Debug.LogError("Rematch Time" + MatchManager.rematchExpireTime + "Time: " + Time.realtimeSinceStartup);
	}

	public override void Rematch()
	{
		mShowWaitingForPlayer = false;
		if (PhotonNetwork.connected)
		{
			MatchManager.matchState = MatchState.WaitingForOpponent;
			int num = mMapId;
			Reset();
			mMapIdSet = true;
			mMapId = num;
			isInMatch = true;
			mPhotonView.RPC("RematchRPC", PhotonTargets.AllBufferedViaServer, PhotonNetwork.player.ID, ++mStateUpdateCounter);
			SpendDogtagLocaly();
			CheckRematchStates();
		}
		else
		{
			Debug.LogError("Not connected when rematch");
		}
	}

	protected virtual void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
	{
		if (PhotonNetwork.room.playerCount != 2)
		{
			PlayerController player = PlayerController.GetPlayer(otherPlayer.ID);
			if (player != null)
			{
				player.networkStatus.connectionState = PlayerNetworkStatus.ConnectionState.Disconnected;
			}
			if (mBothPlayersConnected && HasAllPlayersStateAtLeast(PlayerNetworkStatus.MatchState.CardsChosen))
			{
				PlayerDisconnectedDuringGame(otherPlayer);
			}
			else
			{
				PlayerDistonnectedBeforeAfterMatch(otherPlayer);
			}
		}
	}

	protected virtual void PlayerDistonnectedBeforeAfterMatch(PhotonPlayer otherPlayer)
	{
		mBothPlayersConnected = false;
		if (PlayerController.currentPlayer.networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch)
		{
			Debug.LogError("Player disconected 0001");
			LoadingDialog.Hide();
			bool flag = Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot;
			WarningDialog.ShowError(Localization.Localize((!flag) ? "ID_BATTLECANCELED" : "ID_COOPCANCELED"), Localization.Localize((!flag) ? "ID_OPPONENTREFUSEDTHEREMATCH" : "ID_FRIENDREFUSEDREMATCHCOOP"), 0f, delegate
			{
				Singleton<GuiManager>.instance.ShowMainScreen();
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				LoadingDialog.Hide();
			}, string.Empty);
			Quit();
			MatchManager.matchState = MatchState.GameCancelled;
			return;
		}
		if (MatchManager.beforeMatch)
		{
			Debug.LogError("Player disconected 0001");
			LoadingDialog.Hide();
			bool flag2 = Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot;
			ConfirmDialog.ShowAlert(delegate
			{
				Singleton<GuiManager>.instance.ShowMainScreen();
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				LoadingDialog.Hide();
			}, Localization.Localize((!flag2) ? "ID_CONFIRM_INFO" : "ID_BATTLECANCELED"), Localization.Localize((!flag2) ? "ID_CONFIRM_OPPONENTCANCELLED" : "ID_CONFIRM_FRIENDCANCELLED"));
			Quit();
		}
		MatchManager.matchState = MatchState.GameCancelled;
	}

	protected void PlayerDisconnectedDuringGame(PhotonPlayer otherPlayer)
	{
		Debug.LogError("Player disconected 0003");
		PlayerController player = PlayerController.GetPlayer(otherPlayer.ID);
		if (player != null)
		{
			if (!player.networkStatus.active)
			{
				Debug.Log("Inactive player disconnected: ");
				return;
			}
			if (player.networkStatus.matchState == PlayerNetworkStatus.MatchState.GameLoading)
			{
				player.networkStatus.matchState = PlayerNetworkStatus.MatchState.LoadingFinished;
				mMatchStart = PhotonNetwork.time;
			}
			if (PlayerController.currentPlayer.networkStatus.matchState == PlayerNetworkStatus.MatchState.GameFinished)
			{
				Debug.LogError("Player disconected 000122");
				PhotonConnectionManager.Disconnect();
				MatchManager.matchState = MatchState.GameCancelled;
			}
			CheckIfDisconnected3rdTime(player);
		}
		MatchManager.reconnectTime = Time.realtimeSinceStartup;
	}

	protected virtual void CheckIfDisconnected3rdTime(PlayerController playerController)
	{
		if (playerController.networkStatus.matchState >= PlayerNetworkStatus.MatchState.LoadingFinished && playerController.networkStatus.matchState < PlayerNetworkStatus.MatchState.GameFinished && playerController.networkStatus.reconnectsCount > 3)
		{
			mMainController.gameEndReason = GameController.GameEndReason.WinByForfeit;
			FinishGame();
			PhotonConnectionManager.Disconnect();
		}
	}

	private void OnConnectedToMaster()
	{
		if (!PhotonNetwork.offlineMode && !(Singleton<GameController>.instance.mainController != this) && !MatchManager.isReconnect)
		{
			MatchManager.matchState = MatchState.WaitingForOpponent;
		}
	}

	protected void OnJoinedRoom()
	{
		Singleton<GameController>.instance.battleId = (string)PhotonNetwork.room.customProperties["battleID"];
		Debug.Log($"Joined room: {PhotonNetwork.room.name}, name: {PhotonNetwork.player.name},  userId: {PhotonNetwork.player.ID}, allConnected: {mBothPlayersConnected}");
		PhotonPlayer[] playerList = PhotonNetwork.playerList;
		foreach (PhotonPlayer photonPlayer in playerList)
		{
			Debug.Log($"Player id: {photonPlayer.name}, player userId {photonPlayer.userId}");
		}
		if (PhotonNetwork.room != null && !mBothPlayersConnected && PhotonNetwork.room.playerCount == 2)
		{
			Debug.Log("Joined room" + PhotonNetwork.room.name + "id: " + PhotonNetwork.player.ID);
			PlayerController.currentPlayer.networkStatus.matchState = PlayerNetworkStatus.MatchState.Connected;
			AllPlayersConnected();
		}
	}

	protected void PlayerReconnected(PlayerController player, PhotonPlayer photonPlayer)
	{
		PlayerController.players[photonPlayer.ID] = player;
		player.playerNetworkId = photonPlayer.ID;
		player.playerProperties.photonPlayer = photonPlayer;
		player.networkStatus.connectionState = PlayerNetworkStatus.ConnectionState.Connected;
		SetUpPhotonViews(player);
		if (Singleton<PhotonConnectionManager>.instance.isClient && PhotonNetwork.isMasterClient)
		{
			Debug.Log("Setting master client");
			PhotonNetwork.SetMasterClient(photonPlayer);
		}
		foreach (KeyValuePair<int, PlayerController> player2 in PlayerController.players)
		{
			player2.Value.ReSync();
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			SpawningManager.instance.ReSyncUnits();
			Singleton<SpawningManagerDeathMatch>.instance.ReSyncPower();
			Singleton<MapManager>.instance.ResyncShields();
			ResyncTime();
		}
		ResyncPlayerStates();
	}

	private void ResyncTime()
	{
		mPhotonView.RPC("ResyncTimeRPC", PhotonTargets.Others, PhotonNetwork.player.ID, time);
	}

	[PunRPC]
	private void ResyncTimeRPC(float syncTime)
	{
		time = syncTime;
	}

	private void ResyncPlayerStates()
	{
		if (PlayerController.currentPlayer.networkStatus.matchState == PlayerNetworkStatus.MatchState.LoadingFinished)
		{
			mPhotonView.RPC("LoadingFinishedRPC", PhotonTargets.AllBufferedViaServer, PhotonNetwork.player.ID, mStateUpdateCounter);
		}
		if (PlayerController.currentPlayer.networkStatus.startAnimationFinished)
		{
			mPhotonView.RPC("StartCameraAnimationFinishedRPC", PhotonTargets.Others, PlayerController.currentPlayer.playerNetworkId);
		}
	}

	private void ChooseRightMapForOpponent(PhotonPlayer player)
	{
		mMapId = UnityEngine.Random.Range(0, Math.Min((int)PhotonNetwork.player.customProperties["maxMapId"], (int)player.customProperties["maxMapId"]));
		if ((int)PhotonNetwork.player.customProperties["isRandomMap"] == 0)
		{
			mMapId = (int)PhotonNetwork.player.customProperties["mapId"];
		}
		if ((int)player.customProperties["isRandomMap"] == 0)
		{
			mMapId = (int)player.customProperties["mapId"];
		}
		Debug.Log("Selected new room MAP id is: " + mMapId);
		mMapIdSet = true;
		PhotonCachedRPC.SendOfflineRPC(mPhotonView, "SetMapRPC", PhotonTargets.AllBufferedViaServer, mMapId);
	}

	[PunRPC]
	protected void SetMapRPC(int i)
	{
		Debug.Log("Map was set to: " + i);
		mMapId = i;
		mMapIdSet = true;
	}

	private void SetUpPhotonViews(PlayerController player)
	{
		PhotonView[] componentsInChildren = player.GetComponentsInChildren<PhotonView>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			int num = mPhotonIds[i] % 1000;
			photonView.viewID = 1000 * player.playerProperties.photonPlayer.ID + num;
			PhotonNetwork.networkingPeer.ChangePhotonView(photonView);
			photonView.didAwake = true;
		}
	}

	private void CreatePlayerInstance(PhotonPlayer player)
	{
		Debug.Log("Clear players");
		Fractions playerFraction = GetPlayerFraction(player);
		if (mOtherPlayerInstance == null)
		{
			mOtherPlayerInstance = UnityEngine.Object.Instantiate(Singleton<ObjectPoolDatabase>.instance.player);
			mOtherPlayerInstance.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
		mOtherPlayerInstance.gameObject.SetActive(value: false);
		if (playerFraction == PlayerController.currentPlayer.fraction)
		{
			Singleton<GameController>.instance.friend = mOtherPlayerInstance;
		}
		else
		{
			Singleton<GameController>.instance.opponent = mOtherPlayerInstance;
		}
		mOtherPlayerInstance.fraction = playerFraction;
		PlayerController.players[player.ID] = mOtherPlayerInstance;
		mOtherPlayerInstance.playerNetworkId = player.ID;
		mOtherPlayerInstance.playerProperties = PlayerProperties.CreateFromPhotonPlayer(player, mOtherPlayerInstance.fraction);
		mOtherPlayerInstance.weaponInventory.SetWeapons(mOtherPlayerInstance.playerProperties.weapons);
		mOtherPlayerInstance.networkStatus.Reset();
		mOtherPlayerInstance.networkStatus.matchState = PlayerNetworkStatus.MatchState.Connected;
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(mOtherPlayerInstance, useBackground: true, PlayerTexturePool.RenderType.Classic);
		SetUpPhotonViews(mOtherPlayerInstance);
	}

	private void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		Debug.Log(string.Format("PLAYER CONNECTED: {0}, name: {1},  userId: {2}, allConnected: {3}" + player.userId, player.ID, player.name, player.userId, mBothPlayersConnected));
		PhotonPlayer[] playerList = PhotonNetwork.playerList;
		foreach (PhotonPlayer photonPlayer in playerList)
		{
			Debug.Log("Player: " + photonPlayer.name);
		}
		if (!mBothPlayersConnected)
		{
			Debug.Log("Joined room" + ((PhotonNetwork.room == null) ? "null" : PhotonNetwork.room.name) + "id: " + PhotonNetwork.player.ID);
			ChooseRightMapForOpponent(player);
			AllPlayersConnected();
		}
	}

	protected void CheckIf(DisconnectCause cause)
	{
		if (cause == DisconnectCause.MaxCcuReached)
		{
			Quit();
			MatchManager.matchState = MatchState.GameCancelled;
			ConfirmDialog.ShowAlert(delegate
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}, Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_CONFIRM_MAXCCUREACHED"));
			GuiElementSingle<WarningDialog>.instance.HideDialog();
			Singleton<BeanstalkServerManager>.instance.PhotonIsFull();
			Singleton<DogTagManager>.instance.ResetLocalDogtags();
		}
	}

	protected virtual void OnCustomAuthenticationFailed()
	{
		Quit();
		MatchManager.matchState = MatchState.GameCancelled;
		ConfirmDialog.Hide();
		WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, delegate
		{
			Singleton<GuiManager>.instance.ShowMainScreen();
			GuiElementSingle<WarningDialog>.instance.okClicked = null;
		}, string.Empty);
		Singleton<DogTagManager>.instance.ResetLocalDogtags();
	}

	protected virtual void OnConnectionFail(DisconnectCause cause)
	{
		Debug.LogError("OnConnectionFailed: " + cause);
		Debug.LogError(DebugSettings.GetNetworkStatsText());
		CheckIf(cause);
		PlayerController.currentPlayer.networkStatus.connectionState = PlayerNetworkStatus.ConnectionState.Disconnected;
		if (mBothPlayersConnected && HasAllPlayersStateAtLeast(PlayerNetworkStatus.MatchState.CardsChosen))
		{
			ReconnectInGame();
		}
		else if ((MatchManager.beforeMatch || MatchManager.afterMatch) && Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			Debug.LogError("OnConnectionFailed: 00");
			ConfirmDialog.ShowAlert(delegate
			{
				Singleton<GuiManager>.instance.ShowMainScreen();
				LoadingDialog.Hide();
			}, Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_YOUWEREDISCONNECTED"));
			LoadingDialog.Hide();
			Quit();
		}
		else
		{
			MatchManager.matchState = MatchState.ConnectingToPhoton;
			InvokeAfter(delegate
			{
				PhotonConnectionManager.ConnectToPhotonSafe();
			}, 1.5f);
		}
	}

	protected void OnFailedToReconnect()
	{
		Debug.LogError("OnFailedToReconnect");
		ReconnectFailed();
	}

	protected void ReconnectInGame()
	{
		PlayerController.currentPlayer.networkStatus.connectionState = PlayerNetworkStatus.ConnectionState.Disconnected;
		MatchManager.matchState = MatchManager.matchState;
		MatchManager.reconnectTime = Time.realtimeSinceStartup;
		PhotonConnectionManager.TryRecconnectToPhoton();
	}

	protected virtual void CheckForReconnect()
	{
		CheckPlayersReconnectStates();
		if (gameIsRunning && (MatchManager.isReconnect || !MatchManager.allPlayersFinishetStartAnimation))
		{
			if (Time.realtimeSinceStartup > mTImer)
			{
				mTImer = Time.realtimeSinceStartup + 2f;
				Debug.Log($"CheckForReconnect: isReconnect: {MatchManager.reconnectState}");
			}
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
					else
					{
						mMainController.gameEndReason = GameController.GameEndReason.WinByForfeit;
						FinishGame();
						if (PhotonNetwork.room != null)
						{
							PhotonNetwork.room.open = false;
						}
						PhotonConnectionManager.Disconnect();
					}
					GuiElementSingle<ReconnectDialog>.instance.HideDialog();
					Debug.Log("Hide reconnect dialog");
				}
			}
			else
			{
				GuiElementSingle<ReconnectDialog>.instance.SetWaitTime(-1f);
			}
		}
		UpdateReconnectDialog();
	}

	protected void CheckPlayersReconnectStates()
	{
		if (PhotonNetwork.room == null || !PhotonNetwork.connected || PhotonNetwork.room.playerCount != 2 || !MatchManager.isReconnect || !gameIsRunning)
		{
			return;
		}
		PhotonPlayer[] playerList = PhotonNetwork.playerList;
		foreach (PhotonPlayer photonPlayer in playerList)
		{
			PlayerController playerController = PlayerController.FindPlayerWithUserId(photonPlayer.userId);
			if (playerController != null && playerController.networkStatus.connectionState == PlayerNetworkStatus.ConnectionState.Disconnected)
			{
				PlayerReconnected(playerController, photonPlayer);
			}
		}
		if (!MatchManager.isReconnect && MatchManager.allPlayersFinishetStartAnimation)
		{
			TimeManager.Resume();
			GuiElementSingle<ReconnectDialog>.instance.HideDialog();
			Debug.Log("Player reconnected in CheckPlayersReconnectStates");
		}
	}

	protected void UpdateReconnectDialog()
	{
		if ((MatchManager.isReconnect || !MatchManager.allPlayersFinishetStartAnimation) && gameIsRunning && !GuiElementSingle<ReconnectDialog>.instance.isShowed)
		{
			Debug.Log("Show reconnect dialog");
			if (TimeManager.instance.isPaused)
			{
				Debug.Log("Show reconnect dialog isPaused");
				GuiElementSingle<PauseScreen>.instance.HideDialog();
			}
			TimeManager.Pause(focusLost: false);
			Singleton<GuiManager>.instance.ShowDialogInstant(GuiElementSingle<ReconnectDialog>.instance);
			GuiElementSingle<ReconnectDialog>.instance.SetCause(MatchManager.reconnectState, MatchManager.allPlayersFinishetStartAnimation);
		}
		if (!MatchManager.isReconnect && MatchManager.allPlayersFinishetStartAnimation && gameIsRunning && GuiElementSingle<ReconnectDialog>.instance.isShowed)
		{
			TimeManager.Resume();
			GuiElementSingle<ReconnectDialog>.instance.HideDialog();
		}
	}

	private void OnDisconnectedFromPhoton()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			Debug.LogWarning("OnDisconnectedFromPhoton");
		}
	}

	protected void JoinRoomFailedAfterReconnect(int message)
	{
		Debug.LogError($"JoinRoomFailedAfterReconnect: {message} GameIsRunning: {gameIsRunning}");
		if (message == 32758 || message == 32764)
		{
			ReconnectFailed();
			return;
		}
		PhotonConnectionManager.Disconnect();
		InvokeAfter(delegate
		{
			Singleton<PhotonConnectionManager>.instance.ReconnectToRoom();
		}, 0.5f);
	}

	private void ReconnectFailed()
	{
		if (gameIsRunning)
		{
			Forfeit();
			Disconnect();
			return;
		}
		foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
		{
			if (player.Value.networkStatus.active && player.Value.networkStatus.matchState == PlayerNetworkStatus.MatchState.GameLoading)
			{
				player.Value.networkStatus.matchState = PlayerNetworkStatus.MatchState.LoadingFinished;
				mMatchStart = PhotonNetwork.time;
			}
		}
	}

	protected virtual void OnPhotonJoinRoomFailed(object[] codeAndMsg)
	{
		Debug.LogError($"OnPhotonJoinRoomFailed: {codeAndMsg[0]}, message {codeAndMsg[1]}");
		if (MatchManager.isReconnect)
		{
			JoinRoomFailedAfterReconnect(Convert.ToInt32(codeAndMsg[0]));
			return;
		}
		mIsWaitingToAcceptInvitation = false;
		if (MatchManager.beforeMatch)
		{
			Quit();
			MatchManager.matchState = MatchState.GameCancelled;
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_GAMEDOESNOTEXIST"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
				LoadingDialog.Hide();
			}, string.Empty);
		}
		else
		{
			Debug.LogError("Failed to join room during or after match and MatchManager.isReconnect = FALSE");
		}
	}

	private void OnConnectedToPhoton()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			Debug.Log("On conencted to photon");
		}
	}

	private void OnJoinedLobby()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			Debug.Log("On joined lobby");
		}
	}

	private void OnPhotonCreateRoomFailed()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			Debug.LogError("OnPhotonCreateRoomFailed");
		}
	}

	private void OnCreatedRoom()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			Debug.Log("OnCreatedRoom");
		}
	}

	private void OnLeftRoom()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			Debug.Log("#VAVRO# OnLeftRoom");
		}
	}

	protected void SetStateToAllPlayers(PlayerNetworkStatus.MatchState state)
	{
		foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
		{
			player.Value.networkStatus.matchState = state;
		}
	}

	public override void FinishGame()
	{
		if (gameIsRunning)
		{
			Singleton<MatchManager>.instance.matchTime = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE - time;
			mPhotonView.RPC("FinishGameMultiplayerRPC", PhotonTargets.Others, (byte)GetReasonForClient(Singleton<GameController>.instance.gameEndReason));
			gameIsRunning = false;
			Reset();
			MatchManager.matchState = MatchState.GameFinished;
			SetStateToAllPlayers(PlayerNetworkStatus.MatchState.GameFinished);
			mMainController.FinishGame();
		}
	}

	private GameController.GameEndReason GetReasonForClient(GameController.GameEndReason endReas)
	{
		return endReas switch
		{
			GameController.GameEndReason.Killed => GameController.GameEndReason.Win, 
			GameController.GameEndReason.Win => GameController.GameEndReason.Killed, 
			GameController.GameEndReason.Forfeit => GameController.GameEndReason.WinByForfeit, 
			GameController.GameEndReason.WinByForfeit => GameController.GameEndReason.Forfeit, 
			_ => endReas, 
		};
	}

	[PunRPC]
	protected virtual void FinishGameMultiplayerRPC(byte gameEndReason)
	{
		if (gameIsRunning)
		{
			Debug.Log("Finish game network");
			Singleton<MatchManager>.instance.matchTime = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE - time;
			gameIsRunning = false;
			Reset();
			MatchManager.matchState = MatchState.GameFinished;
			SetStateToAllPlayers(PlayerNetworkStatus.MatchState.GameFinished);
			Singleton<GameController>.instance.gameEndReason = (GameController.GameEndReason)gameEndReason;
			mMainController.FinishGame();
		}
	}

	public override void LoadingStarted()
	{
		SetStateToAllPlayers(PlayerNetworkStatus.MatchState.GameLoading);
		mMainPlayerController.playerProperties = PlayerProperties.CreateForLocalPlayer();
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: true);
	}

	public override void StopGame(bool switchScreen = true)
	{
		Disconnect();
		gameIsRunning = false;
		mMainController.StopGame(switchScreen);
	}

	public override void FreeLevel()
	{
		mOtherPlayerInstance.gameObject.SetActive(value: false);
		mMainPlayerController.currentPlayerPoint = null;
		mOtherPlayerInstance.currentPlayerPoint = null;
		isInMatch = false;
	}

	public override IEnumerator AquireLevelName()
	{
		float mYieldStartTime = Time.realtimeSinceStartup;
		while (!mMapIdSet)
		{
			if (Time.time > mYieldStartTime + 5f)
			{
				mYieldStartTime = Time.realtimeSinceStartup;
				Debug.Log("Waiting for map set");
			}
			yield return null;
		}
		Singleton<MapManager>.instance.SelectCurrentMap(mMapId);
		Singleton<GameController>.instance.levelName = Singleton<MapManager>.instance.currentMap.name;
		Debug.Log("Aquiire map id " + mMapId);
	}

	protected virtual void SpendDogtagLocaly()
	{
		Singleton<DogTagManager>.instance.UseDogTagLocaly();
	}

	protected virtual void PayDogtag()
	{
		Singleton<DogTagManager>.instance.PayOneDogTag();
	}

	public override void Quit()
	{
		PlayerController.currentPlayer.networkStatus.Reset();
		Screen.sleepTimeout = -2;
		if (shouldLooseDogtagWhenQuit)
		{
			PayDogtag();
		}
		Singleton<DogTagManager>.instance.ResetLocalDogtags();
		StopAllCoroutines();
		PhotonConnectionManager.Disconnect();
		Reset();
		isInMatch = false;
	}

	public virtual void PausematchMaking(bool pause)
	{
	}

	public override void Forfeit()
	{
		mMainController.gameEndReason = GameController.GameEndReason.Forfeit;
		FinishGame();
	}

	public override void PauseGame(bool focusLost)
	{
		if (!gameIsRunning)
		{
			return;
		}
		if (allPlayersStartAnimation || focusLost)
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
		PhotonNetwork.SendOutgoingCommands();
	}

	public override void ResumeGame()
	{
		TimeManager.Resume();
	}

	public override void UnPauseGame()
	{
	}

	public void Disconnect()
	{
		InvokeAfterRealTime(PhotonConnectionManager.Disconnect, 2f);
	}

	public virtual IEnumerator WaitForServerResponse()
	{
		yield break;
	}

	protected virtual void Update()
	{
		if (mCardsChoosen && !gameIsRunning)
		{
			float num = MatchManager.matchStartTime - Time.realtimeSinceStartup;
			if (num > 1f && MatchManager.matchState != MatchState.GameLoading)
			{
				LoadingDialog.SetText(MiscTools.PrintableTimeTwoDigits(num));
			}
			LoadingDialog.SetHeader(MatchManager.matchStatusLoading);
			if (PlayerController.currentPlayer.networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch)
			{
				LoadingDialog.SetHeader(MatchManager.matchStatusLoading);
				string matchTimeStatus = MatchManager.matchTimeStatus;
				string text = ((!string.IsNullOrEmpty(matchTimeStatus)) ? matchTimeStatus : MatchManager.matchStatusAfterMatch);
				LoadingDialog.SetText(text);
			}
		}
		if (!gameIsRunning && mShowWaitingForPlayer && MatchManager.matchState == MatchState.GameLoading && GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			LoadingDialog.SetHeader(Localization.Localize("ID_WAITINGFOROTHERPLAYER"));
		}
		if (PlayerController.currentPlayer.networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch && !mBothPlayersConnected && Time.realtimeSinceStartup > MatchManager.rematchExpireTime)
		{
			Quit();
			LoadingDialog.Hide();
			MatchManager.matchState = MatchState.GameCancelled;
			bool flag = Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot;
			WarningDialog.ShowError(Localization.Localize((!flag) ? "ID_BATTLECANCELED" : "ID_COOPCANCELED"), Localization.Localize((!flag) ? "ID_OPPONENTREFUSEDTHEREMATCH" : "ID_FRIENDREFUSEDREMATCHCOOP"), 0f, delegate
			{
				Singleton<GuiManager>.instance.ShowMainScreen();
				LoadingDialog.Hide();
			}, string.Empty);
			PlayerController.currentPlayer.networkStatus.Reset();
			GuiElementSingle<WarningDialog>.instance.HideDialog();
		}
		if (mIsWaitingToAcceptInvitation && (MatchManager.invitationState == InvitationState.Denied || MatchManager.invitationTimeRemaining <= 0f))
		{
			LoadingDialog.Hide();
			mIsWaitingToAcceptInvitation = false;
			Quit();
			GuiElementSingle<InvitationFailedDialog>.instance.ShowDialog(MatchManager.invitationState);
			MatchManager.matchState = MatchState.GameCancelled;
		}
		UpdatePause();
		CheckForReconnect();
	}

	protected virtual void UpdatePause()
	{
		if (gameIsRunning && TimeManager.instance.isPaused && TimeManager.pauseTimeLeft <= 0f && !MatchManager.isReconnect)
		{
			if (TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedRemote)
			{
				ResumeGame();
			}
			if (TimeManager.instance.pauseStatus == TimeManager.PauseStatus.PausedRemoteFocusLost)
			{
				mMainController.gameEndReason = GameController.GameEndReason.WinByForfeit;
				FinishGame();
			}
		}
	}
}
