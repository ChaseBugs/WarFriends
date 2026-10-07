using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using UnityEngine;

public class PhotonConnectionManager : Singleton<PhotonConnectionManager>
{
	private static SelfHostedBattleClient GetActiveSelfHostedClient()
	{
		SelfHostedBattleClient client = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
		return client != null && client.PhotonCompatibility != null && client.PhotonCompatibility.IsConnected ? client : null;
	}

	private static SelfHostedBattleClient GetOwnedSelfHostedClient()
	{
		SelfHostedBattleClient client = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
		return client != null && client.OwnsMatch ? client : null;
	}

	public static bool IsSelfHostedActive => GetOwnedSelfHostedClient() != null;

	public static double GetNetworkTime()
	{
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null && selfHosted.State != null)
			return selfHosted.State.ServerTick / 30.0;
		return PhotonNetwork.time;
	}

	public static int GetPlayerCount()
	{
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null && selfHosted.State != null)
			return selfHosted.State.Players.Count;
		return PhotonNetwork.room == null ? 0 : PhotonNetwork.room.playerCount;
	}

	public static string GetBattleId()
	{
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null && selfHosted.State != null)
			return selfHosted.State.MatchId;
		if (PhotonNetwork.room == null || PhotonNetwork.room.customProperties == null)
			return string.Empty;
		object value;
		return PhotonNetwork.room.customProperties.TryGetValue("battleID", out value) ? value as string ?? string.Empty : string.Empty;
	}

	private static RoomConnection mCurrentRoomConnection;

	private int mJoinAttemtCounter;

	private int mLastCheck;


	private string mRoomName;

	private bool mShouldCreateRoom;

	public static Dictionary<CloudRegionCode, int> bestRegions = new Dictionary<CloudRegionCode, int>();

	private int mTempTotalMatchesInRegions;


	public bool isClient { get; private set; }

	public bool isMasterClient => !isClient;

	public static bool isInRoom
	{
		get
		{
			SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
			if (selfHosted != null) return true;
			return PhotonNetwork.connected && PhotonNetwork.inRoom && PhotonNetwork.room != null;
		}
	}

	public static InternetConnection connection => (InternetConnection)Application.internetReachability;

	public static CloudRegionCode bestRegion { get; private set; }

	public static List<Tuple<CloudRegionCode, int>> bestRegionsSorted
	{
		get
		{
			List<Tuple<CloudRegionCode, int>> list = new List<Tuple<CloudRegionCode, int>>();
			if (bestRegions != null)
			{
				foreach (KeyValuePair<CloudRegionCode, int> bestRegion in bestRegions)
				{
					list.Add(new Tuple<CloudRegionCode, int>(bestRegion.Key, bestRegion.Value));
				}
			}
			list.Sort((Tuple<CloudRegionCode, int> a, Tuple<CloudRegionCode, int> b) => a.Value2.CompareTo(b.Value2));
			if (list.Count == 0)
			{
				Debug.LogError("we dont have best regions for player");
				list.Add(new Tuple<CloudRegionCode, int>(CloudRegionCode.au, 0));
			}
			return list;
		}
	}

	public static int pingToBestRegion
	{
		get
		{
			int value = 4000;
			bestRegions.TryGetValue(bestRegion, out value);
			return value;
		}
	}

	public static int totalMatchesInRegions { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += PlayerDataLoaded;
		CustomTypes.Register();
	}

	protected override void Start()
	{
		base.Start();
		PhotonNetwork.sendRate = 26;
		PhotonNetwork.sendRateOnSerialize = 13;
		PhotonNetwork.networkingPeer.DisconnectTimeout = 4000;
		PhotonNetwork.networkingPeer.SentCountAllowance = 5;
		PhotonNetwork.networkingPeer.MaximumTransferUnit = 1500;
		PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = 60;
		PhotonNetwork.autoJoinLobby = false;
	}

	private void Update()
	{
		if ((int)Time.realtimeSinceStartup != mLastCheck)
		{
			mLastCheck = (int)Time.realtimeSinceStartup;
			CheckIfShouldPing();
		}
	}

	public void CheckIfShouldPing()
	{
		// The self-hosted allocator chooses the battle endpoint. A Photon Cloud
		// region probe would contact a retired online service from the menu.
	}

	private void PlayerDataLoaded()
	{
		bestRegions = GameLoginManager.currentPlayer.bestRegions;
		CheckIfShouldPing();
	}

	public static void ConnectToPhotonSafe(CloudRegionCode? region = null)
	{
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null)
		{
			Debug.Log("PhotonConnectionManager: self-hosted room already owns the connection");
			return;
		}
		Debug.LogError("Photon Cloud rooms are unavailable in the offline build; use self-hosted matchmaking.");
	}

	public IEnumerator TryRecconnectToPhotonCoroutine()
	{
		Debug.LogError("Photon Cloud reconnect is unavailable in the offline build.");
		Singleton<GameController>.instance.BroadcastMessage("OnFailedToReconnect", SendMessageOptions.DontRequireReceiver);
		yield break;
	}

	private void OnConnectedToMaster()
	{
		if (PhotonNetwork.offlineMode)
		{
			return;
		}
		Debug.Log("OnConnectedToMaster");
		PhotonNetwork.player.name = GameLoginManager.currentPlayer.name;
		PhotonNetwork.player.SetCustomProperties(PlayerProperties.photonPlayerProperties);
		if (mCurrentRoomConnection != null)
		{
			if (mCurrentRoomConnection.isRandom)
			{
				if (mShouldCreateRoom)
				{
					CreateRoom();
				}
				else
				{
					TryRandomConnect();
				}
			}
			else
			{
				CreateOrJoinRoom();
			}
		}
		else if (MatchManager.isReconnect)
		{
			PhotonNetwork.JoinRoom(mRoomName);
		}
	}

	private void OnJoinedRoom()
	{
		Debug.Log($"OnJoinedRoom: {DateTime.Now}");
		if (mCurrentRoomConnection != null)
		{
			mCurrentRoomConnection = null;
			mRoomName = PhotonNetwork.room.name;
			isClient = !PhotonNetwork.isMasterClient;
			SendOnJoinedNewRoom();
		}
	}

	private void SendOnJoinedNewRoom()
	{
		foreach (PhotonCachedRPC photonCachedRpc in PhotonCachedRPC.photonCachedRpcs)
		{
			photonCachedRpc.SendMessage("OnJoinedNewRoom", SendMessageOptions.DontRequireReceiver);
		}
		Singleton<GameController>.instance.BroadcastMessage("OnJoinedNewRoom", SendMessageOptions.DontRequireReceiver);
	}

	public void CompleteSelfHostedJoin()
	{
		SelfHostedBattleClient selfHosted = GetActiveSelfHostedClient();
		if (selfHosted == null || selfHosted.State == null || string.IsNullOrEmpty(selfHosted.LocalPlayerId))
			throw new InvalidOperationException("A connected self-hosted roster is required.");
		mCurrentRoomConnection = null;
		mRoomName = selfHosted.State.MatchId;
		isClient = selfHosted.State.Players.Count == 0 || selfHosted.State.Players[0].PlayerId != selfHosted.LocalPlayerId;
		MatchManager.matchState = MatchState.WaitingForOpponent;
		SendOnJoinedNewRoom();
	}

	private void CreateOrJoinRoom()
	{
		if (PhotonNetwork.connectionState == ConnectionState.Connected)
		{
			if (isClient)
			{
				string roomName = mRoomName;
				Debug.Log("Try Joining room " + mRoomName);
				PhotonNetwork.JoinRoom(roomName);
			}
			else
			{
				CreateRoom();
			}
		}
	}

	private void TryRandomConnect()
	{
		if (mCurrentRoomConnection != null)
		{
			MatchManager.matchState = MatchState.WaitingForOpponent;
			TypedLobby lobby = mCurrentRoomConnection.lobby;
			string sqlFilter = mCurrentRoomConnection.GetSqlFilter(mJoinAttemtCounter);
			PhotonNetwork.JoinRandomRoom(null, 2, MatchmakingMode.FillRoom, lobby, sqlFilter);
			if (bestRegionsSorted != null && bestRegionsSorted.Count > 0 && bestRegion == bestRegionsSorted[0].Value1)
			{
				Debug.Log("Try random connect " + sqlFilter);
			}
		}
	}

	public string GetNewRoomName()
	{
		string text = GameLoginManager.currentPlayer.id + "r" + UnityEngine.Random.Range(10000, 999999);
		Debug.Log($"Will connect to rooom: {text}");
		return text;
	}

	private void CreateRoom()
	{
		isClient = false;
		if (mCurrentRoomConnection != null)
		{
			RoomOptions roomOptions = mCurrentRoomConnection.roomOptions;
			TypedLobby lobby = mCurrentRoomConnection.lobby;
			PhotonNetwork.JoinOrCreateRoom(mRoomName, roomOptions, lobby);
		}
	}

	public static void JoinOfflineGame()
	{
		Debug.Log("PhotonConnectionManager: JoinOfflineGame");
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null)
		{
			Debug.Log("PhotonConnectionManager: self-hosted session owns offline-compatible room state");
			return;
		}
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		Singleton<PhotonConnectionManager>.instance.isClient = false;
		PhotonNetwork.offlineMode = true;
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.CreateRoom("OfflineRoom");
	}

	public static void Disconnect()
	{
		Debug.Log("PhotonConnectionManager: Disconnect");
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null)
		{
			selfHosted.LeaveMatch();
			return;
		}
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		PhotonNetwork.Disconnect();
	}

	public void CheckPingsNow()
	{
		// Retained for recovered UI callers; the self-hosted allocator owns routing.
	}

	public string ConnectToRoom(CloudRegionCode best, float connectionDelay)
	{
		mRoomName = GetNewRoomName();
		isClient = false;
		mCurrentRoomConnection = new RoomConnectionInvite();
		InvokeAfterRealTime(delegate
		{
			ConnectToPhotonSafe(best);
		}, connectionDelay);
		return mRoomName;
	}

	public void ConnectToRoom(CloudRegionCode best, string roomName, float connectionDelay)
	{
		if (GetOwnedSelfHostedClient() != null)
		{
			mRoomName = roomName;
			isClient = true;
			Debug.Log("PhotonConnectionManager: self-hosted room owns the join");
			return;
		}
		isClient = true;
		mCurrentRoomConnection = new RoomConnectionInvite();
		mRoomName = roomName;
		InvokeAfterRealTime(delegate
		{
			ConnectToPhotonSafe(best);
		}, connectionDelay);
	}

	public void ConnnectToRandomRoom(CloudRegionCode best, float connectionDelay)
	{
		if (GetOwnedSelfHostedClient() != null)
		{
			Debug.Log("PhotonConnectionManager: self-hosted room owns random matchmaking");
			return;
		}
		mRoomName = GetNewRoomName();
		mShouldCreateRoom = false;
		mJoinAttemtCounter = 1;
		mCurrentRoomConnection = new RoomConnectionRandom();
		InvokeAfterRealTime(delegate
		{
			ConnectToPhotonSafe(best);
		}, connectionDelay);
		mTempTotalMatchesInRegions = 0;
	}

	public void ConnnectToRandomRoomWarArena(float connectionDelay)
	{
		if (GetOwnedSelfHostedClient() != null)
		{
			Debug.Log("PhotonConnectionManager: self-hosted room owns War Arena matchmaking");
			return;
		}
		mRoomName = GetNewRoomName();
		mShouldCreateRoom = false;
		mJoinAttemtCounter = 1;
		mCurrentRoomConnection = new RoomConnectionWarArena();
		mTempTotalMatchesInRegions = 0;
		CloudRegionCode best = GetBestAllowedRegion(mCurrentRoomConnection.allowedRegions);
		InvokeAfterRealTime(delegate
		{
			ConnectToPhotonSafe(best);
		}, connectionDelay);
	}

	public async void ReconnectToRoom()
	{
		Debug.Log($"Reconnect to room: {mRoomName}");
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null)
		{
			if (!selfHosted.IsConnected)
			{
				try { await selfHosted.ReconnectWithRecoveredSession(); }
				catch (Exception failure) { Debug.LogError("Self-hosted room reconnect failed: " + failure); }
			}
			return;
		}
		Debug.LogError("A self-hosted match is required to reconnect to a room.");
	}

	private void OnPhotonRandomJoinFailed()
	{
		if (mCurrentRoomConnection != null && mCurrentRoomConnection.isRandom)
		{
			mJoinAttemtCounter++;
			if (mJoinAttemtCounter < mCurrentRoomConnection.maxSearchSteps + 1)
			{
				TryRandomConnect();
			}
			else
			{
				TryAnotherRegionForMatchmaking();
			}
		}
	}

	protected void OnFailedToConnectToPhoton()
	{
		Debug.LogError("OnFailedToConnectToPhoton: ");
		if (mCurrentRoomConnection == null)
		{
			return;
		}
		if (mCurrentRoomConnection.isRandom)
		{
			InvokeAfter(delegate
			{
				ConnnectToRandomRoom(bestRegion, 0f);
			}, 1.5f);
		}
		else
		{
			InvokeAfter(delegate
			{
				ConnectToPhotonSafe();
			}, 1.5f);
		}
	}

	public void OnLobbyStatisticsUpdate()
	{
		foreach (TypedLobbyInfo lobbyStatistic in PhotonNetwork.LobbyStatistics)
		{
			if (mCurrentRoomConnection != null && lobbyStatistic.Name == mCurrentRoomConnection.lobbyName)
			{
				int num = lobbyStatistic.RoomCount * 2 - lobbyStatistic.PlayerCount;
				int num2 = lobbyStatistic.RoomCount - num;
				mTempTotalMatchesInRegions += num2;
				Debug.Log($"Stats for lobby {lobbyStatistic}, matches {mTempTotalMatchesInRegions} time {DateTime.Now}");
			}
		}
	}

	private void TryAnotherRegionForMatchmaking()
	{
		mJoinAttemtCounter = 1;
		int num = 0;
		for (num = 0; num < bestRegionsSorted.Count; num++)
		{
			Tuple<CloudRegionCode, int> tuple = bestRegionsSorted[num];
			if (tuple.Value1 == bestRegion)
			{
				num++;
				break;
			}
		}
		if (mCurrentRoomConnection != null && mCurrentRoomConnection.isRandom)
		{
			for (; num < bestRegionsSorted.Count && !mCurrentRoomConnection.allowedRegions.Contains(bestRegionsSorted[num].Value1); num++)
			{
			}
			int maxRegionsToConnect = mCurrentRoomConnection.maxRegionsToConnect;
			float maxPing = mCurrentRoomConnection.maxPing;
			if (num < bestRegionsSorted.Count && (float)bestRegionsSorted[num].Value2 <= maxPing && num < maxRegionsToConnect)
			{
				Tuple<CloudRegionCode, int> tuple2 = bestRegionsSorted[num];
				ConnectToPhotonSafe(tuple2.Value1);
				return;
			}
			ConnectToPhotonSafe(bestRegionsSorted[0].Value1);
			mShouldCreateRoom = mCurrentRoomConnection.shouldCreateRoom;
			totalMatchesInRegions = mTempTotalMatchesInRegions;
			mTempTotalMatchesInRegions = 0;
		}
	}

	public static void TryRecconnectToPhoton()
	{
		Singleton<PhotonConnectionManager>.instance.StartCoroutine(RadicalRoutine.Run(Singleton<PhotonConnectionManager>.instance.TryRecconnectToPhotonCoroutine()));
	}

	public static CloudRegionCode GetBestAllowedRegion(List<CloudRegionCode> allowed)
	{
		foreach (Tuple<CloudRegionCode, int> item in bestRegionsSorted)
		{
			if (allowed.Contains(item.Value1))
			{
				return item.Value1;
			}
		}
		return bestRegion;
	}

	public static CloudRegionCode GetBestRegion(Dictionary<CloudRegionCode, int> bestRegions1, Dictionary<CloudRegionCode, int> bestRegions2, out bool isGood)
	{
		isGood = false;
		int num = int.MaxValue;
		CloudRegionCode cloudRegionCode = CloudRegionCode.eu;
		if (bestRegions1 == null)
		{
			return cloudRegionCode;
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingForChallenge).FLOATVALUE;
		foreach (KeyValuePair<CloudRegionCode, int> item in bestRegions1)
		{
			if (bestRegions2 != null && bestRegions2.ContainsKey(item.Key))
			{
				int num2 = bestRegions2[item.Key];
				if (item.Value + num2 < num)
				{
					cloudRegionCode = item.Key;
					num = item.Value + num2;
					isGood = (float)item.Value <= (float)fLOATVALUE && (float)num2 <= (float)fLOATVALUE;
				}
			}
		}
		Debug.Log($"Returning {cloudRegionCode} isGoodPing: {isGood}");
		return cloudRegionCode;
	}
}
