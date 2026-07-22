using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using UnityEngine;
using WarFriends.Legacy;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _003Crecord_003Ek__BackingField;

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

	public static bool record
	{
		[CompilerGenerated]
		get
		{
			return _003Crecord_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003Crecord_003Ek__BackingField = value;
		}
	}

	public static DebugSettings instance
	{
		get
		{
			mInstance = mInstance ?? ((DebugSettings)SingletonSupport.FindOrCreate(typeof(DebugSettings)));
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

	public static bool isOurDevice => false;

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
			item.gameObject.SetActive(value: false);
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
		return $"TotalPacketBytes: {stats.TotalPacketBytes} TotalCommandBytes: {stats.TotalCommandBytes} TotalPacketCount: {stats.TotalPacketCount} TotalCommandsInPackets: {stats.TotalCommandsInPackets} UnreliableCommandCount: {stats.UnreliableCommandCount} ReliableCommandCount: {stats.ReliableCommandCount}";
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
			string text = $"Out|In|Sum:\t{trafficStatsGameLevel.TotalOutgoingMessageCount,4} | {trafficStatsGameLevel.TotalIncomingMessageCount,4} | {trafficStatsGameLevel.TotalMessageCount,4}";
			string text2 = $"{num}sec average:";
			string text3 = $"Out|In|Sum:\t{trafficStatsGameLevel.TotalOutgoingMessageCount / num,4} | {trafficStatsGameLevel.TotalIncomingMessageCount / num,4} | {trafficStatsGameLevel.TotalMessageCount / num,4}";
			string empty = string.Empty;
			string empty2 = string.Empty;
			empty = "Incoming: " + GetStats(PhotonNetwork.networkingPeer.TrafficStatsIncoming);
			empty2 = "Outgoing: " + GetStats(PhotonNetwork.networkingPeer.TrafficStatsOutgoing);
			string empty3 = string.Empty;
			empty3 = string.Format("ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms", trafficStatsGameLevel.LongestDeltaBetweenSending, trafficStatsGameLevel.LongestDeltaBetweenDispatching, trafficStatsGameLevel.LongestEventCallback, trafficStatsGameLevel.LongestEventCallbackCode, trafficStatsGameLevel.LongestOpResponseCallback, trafficStatsGameLevel.LongestOpResponseCallbackOpCode, PhotonNetwork.networkingPeer.RoundTripTime, PhotonNetwork.networkingPeer.RoundTripTimeVariance);
			string text4 = "Out queue" + PhotonNetwork.networkingPeer.QueuedOutgoingCommands;
			string text5 = "In queue" + PhotonNetwork.networkingPeer.QueuedOutgoingCommands;
			return $"{text}\n{text2}\n{text3}\n{empty}\n{empty2}\n{empty3}\n{text5}\n{text4}";
		}
		return string.Empty;
	}
}
