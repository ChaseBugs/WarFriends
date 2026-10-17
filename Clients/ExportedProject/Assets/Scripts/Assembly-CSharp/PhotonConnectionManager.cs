using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using War.Client;
using UnityEngine;

public class PhotonConnectionManager : Singleton<PhotonConnectionManager>
{
    private const int UnknownRegionPingMilliseconds = 4000;
    private const double BattleTicksPerSecond = 30.0;
    private const double MillisecondsPerSecond = 1000.0;
	private static readonly LocalOfflineRoom mLocalOfflineRoom = new LocalOfflineRoom();
	private static bool mCreatingLocalSoloRoom;

	public static bool IsLocalSoloRoom =>
		!IsSelfHostedActive &&
		(mCreatingLocalSoloRoom || mLocalOfflineRoom.IsInRoom);

	private static SelfHostedBattleClient GetActiveSelfHostedClient()
	{
		SelfHostedBattleClient client = GetOwnedSelfHostedClient();
		return client != null && client.PhotonCompatibility != null && client.PhotonCompatibility.IsConnected ? client : null;
	}

	private static SelfHostedBattleClient GetOwnedSelfHostedClient()
	{
		SelfHostedBattleClient client = SelfHostedBattleClient.Active;
		return client != null && client.OwnsMatch ? client : null;
	}

	public static bool IsSelfHostedActive => GetOwnedSelfHostedClient() != null;

    /// <summary>Uses only the owned server tick or the recovered unsigned local offline clock.</summary>
	public static double GetNetworkTime()
	{
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
        if (selfHosted != null)
        {
            // An owned session without its first snapshot has no authoritative clock yet.
            return selfHosted.State == null ? 0.0 : selfHosted.State.ServerTick / BattleTicksPerSecond;
        }
        // The recovered offline Photon clock used this unsigned millisecond counter by default.
        return unchecked((uint)Environment.TickCount) / MillisecondsPerSecond;
	}

    /// <summary>Reads the owned roster or local room model without consulting a retired Photon room.</summary>
	public static int GetPlayerCount()
	{
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null)
			return selfHosted.State == null ? 0 : selfHosted.State.Players.Count;
		if (mLocalOfflineRoom.IsOffline)
			return mLocalOfflineRoom.PlayerCount;
		return 0;
	}

    /// <summary>Returns only the battle ID confirmed by the owned self-hosted snapshot.</summary>
	public static string GetBattleId()
	{
		SelfHostedBattleClient selfHosted = GetOwnedSelfHostedClient();
		if (selfHosted != null && selfHosted.State != null)
			return selfHosted.State.MatchId;
        return string.Empty;
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
			if (mLocalOfflineRoom.IsOffline) return mLocalOfflineRoom.IsInRoom;
			return false;
		}
	}

	public static InternetConnection connection => (InternetConnection)Application.internetReachability;

	public static CloudRegionCode bestRegion { get; private set; } = CloudRegionCode.none;

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
			// No measurements means no Photon regions, not a fabricated zero-latency route.
			return list;
		}
	}

	public static int pingToBestRegion
	{
		get
		{
            int measuredPing;
            if (bestRegions != null && bestRegions.TryGetValue(bestRegion, out measuredPing))
            {
                return measuredPing;
            }
            return UnknownRegionPingMilliseconds;
		}
	}

	public static int totalMatchesInRegions { get; private set; }

    /// <summary>Uses only an actual cached measurement for the recovered latency-based bot decision.</summary>
    public static bool HasMeasuredRegionPingAbove(float maximumPingMilliseconds)
    {
        if (float.IsNaN(maximumPingMilliseconds) || float.IsInfinity(maximumPingMilliseconds) ||
            maximumPingMilliseconds < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumPingMilliseconds));
        }

        List<Tuple<CloudRegionCode, int>> regions = bestRegionsSorted;
        return regions.Count != 0 && regions[0].Value2 > maximumPingMilliseconds;
    }

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += PlayerDataLoaded;
		CustomTypes.Register();
	}

	protected override void Start()
	{
		base.Start();
        // Self-hosted UDP owns transport configuration; startup must not initialize a Photon peer here.
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
		// Cloud connection callbacks can still arrive from retained Photon scene
		// components. They must never open a room in the offline build.
		Debug.LogError("Photon Cloud room admission is unavailable; use the self-hosted battle grant.");
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

	private void TryRandomConnect()
	{
		Debug.LogError("Photon random matchmaking is unavailable; use the self-hosted Backend queue.");
	}

	public string GetNewRoomName()
	{
		string text = GameLoginManager.currentPlayer.id + "r" + UnityEngine.Random.Range(10000, 999999);
		Debug.Log($"Will connect to rooom: {text}");
		return text;
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
		bool offlineModeWasAlreadyEnabled = PhotonNetwork.offlineMode;
		PhotonNetwork.offlineMode = true;
		if (!PhotonNetwork.offlineMode)
			throw new InvalidOperationException("Local solo room could not enter offline mode.");
		if (offlineModeWasAlreadyEnabled)
			mLocalOfflineRoom.ObserveExistingOfflineMode();
		PhotonNetwork.LeaveRoom();
		// EnterOfflineRoom sends OnJoinedRoom synchronously, before CreateRoom
		// returns and before the portable room model records the completed join.
		mCreatingLocalSoloRoom = true;
		try
		{
			if (!PhotonNetwork.CreateRoom(LocalOfflineRoom.SoloRoomName))
				throw new InvalidOperationException("Local solo room could not be created.");
		}
		finally
		{
			mCreatingLocalSoloRoom = false;
		}
        // SDK callbacks can cancel or leave the room even when CreateRoom returned true.
        if (!PhotonNetwork.offlineMode)
        {
            mLocalOfflineRoom.Disconnect();
            return;
        }
        if (PhotonNetwork.room == null)
        {
            mLocalOfflineRoom.ObserveDetachedOfflinePlayer(PhotonNetwork.player.ID);
            return;
        }

		mLocalOfflineRoom.JoinSoloRoom();
	}

	public static void Disconnect()
	{
		Debug.Log("PhotonConnectionManager: Disconnect");
        // Disabling a scene object does not release its retained battle ownership.
        SelfHostedBattleClient selfHosted = SelfHostedBattleClient.Active;
        if (selfHosted == null)
        {
            selfHosted = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
        }
		if (selfHosted != null && (selfHosted.OwnsMatch || selfHosted.IsMatchmaking))
		{
			selfHosted.LeaveMatch();
			return;
		}
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		mLocalOfflineRoom.Disconnect();
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
        if (bestRegionsSorted.Count == 0)
        {
            // The self-hosted allocator owns routing when no Photon measurements exist.
            return;
        }
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
		CloudRegionCode cloudRegionCode = CloudRegionCode.none;
		if (bestRegions1 == null || bestRegions1.Count == 0 || bestRegions2 == null || bestRegions2.Count == 0)
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
