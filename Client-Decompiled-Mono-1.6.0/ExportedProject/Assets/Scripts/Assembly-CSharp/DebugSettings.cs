using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using UnityEngine;

public class DebugSettings : InGameSerializedObjectGeneric<DebugSettings.DebugSettingsData>
{
	public class DebugSettingsData
	{
		public bool debugEnabled;

		public bool forceMyHB;

		public bool forceOpponentHB = true;

		public bool showHud = true;

		public bool playBlood = true;

		public bool showPrimaryScopes = true;

		public bool showPlayerHealthBar = true;

		public bool autoDeploy = true;

		public bool vibrations = true;

		public bool record;

		public bool cameraOn;

		public bool microphoneOn;

		public bool autoStartMatch;

		public string configVersion = string.Empty;

		public bool warenaEnableMultipleMatches;

		public bool warenaLoadLocalConfig;
	}

	public List<GameObject> objectsToDisable;

	public static bool isDevelopmentBuild = false;

	private static DebugSettings mInstance;

	private static bool mMaxLevels = false;

	private static bool mMaxUnits = false;

	public static bool debugAI = false;

	public static bool drawExplosions = false;

	private static bool mIsMessageQueueRunning = true;

	public static bool drawCameraLines = true;

	public static bool debugShooting;

	public static bool debugPlayerDamage;

	public static bool stopShooting = false;

	public static bool botSpawns = true;

	private static float mProb;

	private static int mHeadIndex;

	private static float[] mHeadSizes = new float[3] { 1f, 0.9f, 0.8f };

	public bool alwaysShittyPerformance
	{
		get
		{
			if (ObscuredPrefs.HasKey("alwaysShittyPerformance"))
			{
				return ObscuredPrefs.GetInt("alwaysShittyPerformance") > 0;
			}
			ObscuredPrefs.SetInt("alwaysShittyPerformance", 0);
			return false;
		}
		set
		{
			ObscuredPrefs.SetInt("alwaysShittyPerformance", value ? 1 : 0);
		}
	}

	public bool nonEliteUnits
	{
		get
		{
			if (ObscuredPrefs.HasKey("nonEliteUnits"))
			{
				return ObscuredPrefs.GetInt("nonEliteUnits") > 0;
			}
			ObscuredPrefs.SetInt("nonEliteUnits", 0);
			return false;
		}
		set
		{
			ObscuredPrefs.SetInt("nonEliteUnits", value ? 1 : 0);
		}
	}

	public static bool debugEnabled
	{
		get
		{
			return false;
		}
		set
		{
			instance.data.debugEnabled = value;
			instance.Save();
			if (instance.Changed != null)
			{
				instance.Changed();
			}
		}
	}

	public static bool healthbarsOnOpponentUnits
	{
		get
		{
			return instance.data.forceOpponentHB;
		}
		set
		{
			instance.data.forceOpponentHB = value;
			instance.Save();
		}
	}

	public static bool healthbarsOnMyUnits
	{
		get
		{
			return instance.data.forceMyHB;
		}
		set
		{
			instance.data.forceMyHB = value;
			instance.Save();
		}
	}

	public static bool playerHealthbars
	{
		get
		{
			return instance.data.showPlayerHealthBar;
		}
		set
		{
			instance.data.showPlayerHealthBar = value;
			instance.Save();
		}
	}

	public static bool autoDeploy
	{
		get
		{
			return instance.data.autoDeploy;
		}
		set
		{
			instance.data.autoDeploy = value;
			instance.Save();
		}
	}

	public static bool vibrations
	{
		get
		{
			return instance.data.vibrations;
		}
		set
		{
			instance.data.vibrations = value;
			instance.Save();
		}
	}

	public static bool cameraInBroadcast
	{
		get
		{
			return instance.data.cameraOn;
		}
		set
		{
			instance.data.cameraOn = value;
			instance.Save();
		}
	}

	public static bool microphoneInBroadcast
	{
		get
		{
			return instance.data.microphoneOn;
		}
		set
		{
			instance.data.microphoneOn = value;
			instance.Save();
		}
	}

	public static bool record { get; set; }

	public static DebugSettings instance
	{
		get
		{
			mInstance = mInstance ?? ((DebugSettings)UnityEngine.Object.FindObjectsOfType(typeof(DebugSettings))[0]);
			return mInstance;
		}
	}

	public static bool showPrimaryScopes
	{
		get
		{
			return instance.data.showPrimaryScopes;
		}
		set
		{
			instance.data.showPrimaryScopes = value;
			instance.Save();
			if (instance.Changed != null)
			{
				instance.Changed();
			}
		}
	}

	public static bool isOurDevice
	{
		get
		{
			return false;
		}
	}

	public static bool isMessageQueueRunning
	{
		get
		{
			return mIsMessageQueueRunning;
		}
		set
		{
			if (mIsMessageQueueRunning != value)
			{
				mIsMessageQueueRunning = value;
				PhotonNetwork.isMessageQueueRunning = value;
			}
		}
	}

	public event Action Changed;

	protected override void Awake()
	{
		base.Awake();
		if (isOurDevice)
		{
			return;
		}
		foreach (GameObject item in objectsToDisable)
		{
			item.gameObject.SetActive(false);
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected void Update()
	{
		if (!drawExplosions)
		{
			return;
		}
		foreach (Tuple<Vector3, float, float, bool> item in DFHALNOAGGC.JOIIFMGLFMN)
		{
			if (item.Value4)
			{
				CameraLineRenderer.DrawSphere(item.Value1, item.Value2, Color.magenta);
				CameraLineRenderer.DrawSphere(item.Value1, item.Value3, Color.black);
			}
			else
			{
				CameraLineRenderer.DrawSphere(item.Value1, item.Value2, Color.red);
				CameraLineRenderer.DrawSphere(item.Value1, item.Value3, Color.green);
			}
		}
	}

	private static string GetStats(TrafficStats stats)
	{
		return string.Format("TotalPacketBytes: {0} TotalCommandBytes: {1} TotalPacketCount: {2} TotalCommandsInPackets: {3} UnreliableCommandCount: {4} ReliableCommandCount: {5}", stats.TotalPacketBytes, stats.TotalCommandBytes, stats.TotalPacketCount, stats.TotalCommandsInPackets, stats.UnreliableCommandCount, stats.ReliableCommandCount);
	}

	public static string GetNetworkStatsText()
	{
		TrafficStatsGameLevel trafficStatsGameLevel = PhotonNetwork.networkingPeer.TrafficStatsGameLevel;
		if (trafficStatsGameLevel != null)
		{
			long num = PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000;
			if (num == 0)
			{
				num = 1L;
			}
			string text = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingMessageCount, trafficStatsGameLevel.TotalIncomingMessageCount, trafficStatsGameLevel.TotalMessageCount);
			string text2 = string.Format("{0}sec average:", num);
			string text3 = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingMessageCount / num, trafficStatsGameLevel.TotalIncomingMessageCount / num, trafficStatsGameLevel.TotalMessageCount / num);
			string empty = string.Empty;
			string empty2 = string.Empty;
			empty = "Incoming: " + GetStats(PhotonNetwork.networkingPeer.TrafficStatsIncoming);
			empty2 = "Outgoing: " + GetStats(PhotonNetwork.networkingPeer.TrafficStatsOutgoing);
			string empty3 = string.Empty;
			empty3 = string.Format("ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms", trafficStatsGameLevel.LongestDeltaBetweenSending, trafficStatsGameLevel.LongestDeltaBetweenDispatching, trafficStatsGameLevel.LongestEventCallback, trafficStatsGameLevel.LongestEventCallbackCode, trafficStatsGameLevel.LongestOpResponseCallback, trafficStatsGameLevel.LongestOpResponseCallbackOpCode, PhotonNetwork.networkingPeer.RoundTripTime, PhotonNetwork.networkingPeer.RoundTripTimeVariance);
			string text4 = "Out queue" + PhotonNetwork.networkingPeer.QueuedOutgoingCommands;
			string text5 = "In queue" + PhotonNetwork.networkingPeer.QueuedOutgoingCommands;
			return string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}", text, text2, text3, empty, empty2, empty3, text5, text4);
		}
		return string.Empty;
	}
}
