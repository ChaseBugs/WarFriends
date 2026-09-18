using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using UnityEngine;

public class PhotonConnectionManager : Singleton<PhotonConnectionManager>
{
	private static RoomConnection mCurrentRoomConnection;

	private int mJoinAttemtCounter;

	private int mLastCheck;

	private float mPingsFoundTime = float.MinValue;

	private string mRoomName;

	private bool mShouldCreateRoom;

	public static Dictionary<CloudRegionCode, int> bestRegions = new Dictionary<CloudRegionCode, int>();

	private int mTempTotalMatchesInRegions;

	private bool mIsPinging;

	public bool isClient { get; private set; }

	public bool isMasterClient => !isClient;

	private bool hasTimeoutToSomeRegion
	{
		get
		{
			foreach (KeyValuePair<CloudRegionCode, int> bestRegion in bestRegions)
			{
				if (bestRegion.Value > 3500)
				{
					return true;
				}
			}
			return false;
		}
	}

	private bool hasBadPing
	{
		get
		{
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;
			return (float)pingToBestRegion > (float)fLOATVALUE && hasTimeoutToSomeRegion;
		}
	}

	public static bool isInRoom => PhotonNetwork.connected && PhotonNetwork.inRoom && PhotonNetwork.room != null;

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
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && GameLoginManager.currentPlayer != null)
		{
			bool flag = GameLoginManager.currentPlayer.connectionType != connection;
			float num = Time.realtimeSinceStartup - mPingsFoundTime;
			if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu && !mIsPinging && Singleton<GuiManager>.instance.currentScreen != GuiScreenSingle<CardSelectionScreen>.instance && Singleton<GuiManager>.instance.currentScreen != GuiScreenSingle<EndScreen>.instance && (flag || num > 300f || (hasBadPing && num > 60f)))
			{
				Debug.Log($"PhotonConnectionManager: Find pings found before: {num} Connection changed {flag}");
				StartCoroutine(FindPingsCoroutine());
			}
		}
	}

	private void PlayerDataLoaded()
	{
		bestRegions = GameLoginManager.currentPlayer.bestRegions;
		CheckIfShouldPing();
	}

	private static void SetAuthenticationValues()
	{
		AuthenticationValues authenticationValues = new AuthenticationValues();
		authenticationValues.UserId = GameLoginManager.currentPlayer.id;
		AuthenticationValues authenticationValues2 = authenticationValues;
		authenticationValues2.AuthType = CustomAuthenticationType.Custom;
		authenticationValues2.AddAuthParameter("userId", GameLoginManager.currentPlayer.id);
		authenticationValues2.AddAuthParameter("version", Singleton<CurrentBundleVersion>.instance.version);
		authenticationValues2.AddAuthParameter("pass", GameLoginManager.instance.data.playerAccount.passwordByAccount);
		authenticationValues2.AddAuthParameter("account", GameLoginManager.instance.data.playerAccount.accountType.ToString());
		Debug.Log(authenticationValues2.ToString());
		PhotonNetwork.AuthValues = authenticationValues2;
	}

	public static void ConnectToPhotonSafe(CloudRegionCode? region = null)
	{
		switch (Singleton<BeanstalkServerManager>.instance.environment)
		{
		case DatabaseEnvironment.Production:
			PhotonNetwork.PhotonServerSettings.AppID = "74379913-3b64-482e-bda1-8a8d90c0f3f9";
			break;
		case DatabaseEnvironment.QA:
			PhotonNetwork.PhotonServerSettings.AppID = "6519f781-1ea7-421f-85d0-c9bb516e923d";
			break;
		case DatabaseEnvironment.DevelopmentSvk:
			PhotonNetwork.PhotonServerSettings.AppID = "ab5d043a-2edb-431f-a4a0-0571589ee058";
			break;
		default:
			PhotonNetwork.PhotonServerSettings.AppID = "bd18592b-6778-40f5-9327-0aba2d2f1e64";
			break;
		}
		Debug.Log("PhotonConnectionManager: ConnectToPhotonSafe " + ((!region.HasValue) ? "null" : region.Value.ToString()));
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		PhotonNetwork.offlineMode = false;
		PhotonNetwork.networkingPeer.LeftRoomCleanup();
		PhotonNetwork.Disconnect();
		if (region.HasValue)
		{
			PhotonNetwork.OverrideBestCloudServer(region.Value);
			Debug.Log("====== Connecting to region: " + region);
		}
		else
		{
			region = bestRegion;
		}
		bestRegion = region.Value;
		SetAuthenticationValues();
		Singleton<PhotonConnectionManager>.instance.StartCoroutine(ConnectToRegion(region.Value));
	}

	private static IEnumerator ConnectToRegion(CloudRegionCode region)
	{
		int counter = 0;
		while (PhotonNetwork.networkingPeer.State != ClientState.Disconnected && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
		{
			int num;
			counter = (num = counter + 1);
			if (num % 10 == 0)
			{
				Debug.Log("====== Waiting to connect to photon: " + PhotonNetwork.networkingPeer.State);
			}
			yield return null;
		}
		PhotonNetwork.ConnectToBestCloudServer("1.0" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.photonVersion, region);
	}

	public IEnumerator TryRecconnectToPhotonCoroutine()
	{
		Debug.LogError("TryRecconnectToPhotonCoroutine started");
		Debug.LogError("TryRecconnect TryRecconnectToPhotonCoroutine going to reconnect");
		for (int i = 0; i < 40; i++)
		{
			if (i % 5 == 0)
			{
				Debug.Log("Peer state: " + PhotonNetwork.networkingPeer.PeerState);
			}
			yield return new WaitForRealSeconds(1f);
			if (PhotonNetwork.networkingPeer.PeerState == PeerStateValue.Connected)
			{
				yield break;
			}
			if (PhotonNetwork.networkingPeer.PeerState == PeerStateValue.Disconnected)
			{
				Debug.Log("RE-CONNECTING CALLED " + PhotonNetwork.networkingPeer.PeerState);
				SetAuthenticationValues();
				PhotonNetwork.ConnectToBestCloudServer("1.0" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.photonVersion, bestRegion);
			}
		}
		Disconnect();
		Singleton<GameController>.instance.BroadcastMessage("OnFailedToReconnect", SendMessageOptions.DontRequireReceiver);
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
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		Singleton<PhotonConnectionManager>.instance.isClient = false;
		PhotonNetwork.offlineMode = true;
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.CreateRoom("OfflineRoom");
	}

	public static void Disconnect()
	{
		Debug.Log("PhotonConnectionManager: Disconnect");
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		PhotonNetwork.Disconnect();
	}

	public void CheckPingsNow()
	{
		if (!mIsPinging)
		{
			mPingsFoundTime = float.MinValue;
		}
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

	public void ReconnectToRoom()
	{
		Debug.Log($"Reconnect to room: {mRoomName}");
		PhotonNetwork.JoinRoom(mRoomName);
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

	private IEnumerator FindPingsCoroutine()
	{
		mIsPinging = true;
		if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
		{
			yield return new WaitForSeconds(3f);
			PhotonNetwork.offlineMode = false;
			Debug.Log("Pings: ConnectToNameServer");
			PhotonNetwork.ConnectToNameServer(string.Concat("1.0", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.photonVersion));
			while (PhotonNetwork.networkingPeer.State != ClientState.ConnectedToNameServer)
			{
				yield return null;
			}
			while (PhotonNetwork.networkingPeer.AvailableRegions == null)
			{
				if (PhotonNetwork.connectionStateDetailed != ClientState.ConnectingToNameServer && PhotonNetwork.connectionStateDetailed != ClientState.ConnectedToNameServer)
				{
					Debug.LogError("Call ConnectToNameServer to ping available regions.");
					yield break;
				}
				yield return new WaitForSeconds(0.25f);
			}
		}
		PhotonPingManager pingManager = new PhotonPingManager();
		Region[] regs = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
		Region[] array = regs;
		foreach (Region region in array)
		{
			StartCoroutine(pingManager.PingSocket(region));
		}
		while (!pingManager.Done)
		{
			yield return new WaitForSeconds(0.1f);
		}
		Dictionary<CloudRegionCode, int> regions = new Dictionary<CloudRegionCode, int>();
		string debugStr = "============PINGS===========\n";
		Region[] array2 = regs;
		foreach (Region region2 in array2)
		{
			if (region2.Code != CloudRegionCode.none)
			{
				regions[region2.Code] = region2.Ping;
			}
			debugStr += $"Region: {region2.Code} with ping {region2.Ping}, IP: {region2} \n";
		}
		Debug.Log(debugStr);
		bestRegions = regions;
		if (GameLoginManager.currentPlayer != null)
		{
			GameLoginManager.currentPlayer.bestRegions = regions;
			GameLoginManager.currentPlayer.connectionType = connection;
			Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(regions, connection);
		}
		PhotonNetwork.Disconnect();
		PhotonNetwork.offlineMode = true;
		mPingsFoundTime = Time.realtimeSinceStartup;
		mIsPinging = false;
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
