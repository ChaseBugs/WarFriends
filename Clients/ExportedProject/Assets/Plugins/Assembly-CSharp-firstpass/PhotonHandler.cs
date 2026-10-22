using System;
using System.Collections;
using System.Diagnostics;
using ExitGames.Client.Photon;
using UnityEngine;

internal class PhotonHandler : MonoBehaviour
{
	private const string PlayerPrefsKey = "PUNCloudBestRegion";

	public static PhotonHandler SP;

	public int updateInterval;

	public int updateIntervalOnSerialize;

	private int nextSendTickCount;

	private int nextSendTickCountOnSerialize;

	private static bool sendThreadShouldRun;

	private static Stopwatch timerToStopConnectionInBackground;

	protected internal static bool AppQuits;

	protected internal static Type PingImplementation;

	internal static CloudRegionCode BestRegionCodeCurrently = CloudRegionCode.none;

	internal static CloudRegionCode BestRegionCodeInPreferences
	{
		get
		{
			string text = PlayerPrefs.GetString("PUNCloudBestRegion", string.Empty);
			if (!string.IsNullOrEmpty(text))
			{
				return Region.Parse(text);
			}
			return CloudRegionCode.none;
		}
		set
		{
			if (value == CloudRegionCode.none)
			{
				PlayerPrefs.DeleteKey("PUNCloudBestRegion");
			}
			else
			{
				PlayerPrefs.SetString("PUNCloudBestRegion", value.ToString());
			}
		}
	}

	protected void Awake()
	{
		if (SP != null && SP != this && SP.gameObject != null)
		{
			UnityEngine.Object.DestroyImmediate(SP.gameObject);
		}
		SP = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		updateInterval = 1000 / PhotonNetwork.sendRate;
		updateIntervalOnSerialize = 1000 / PhotonNetwork.sendRateOnSerialize;
		StartFallbackSendAckThread();
	}

	protected void OnLevelWasLoaded(int level)
	{
		PhotonNetwork.networkingPeer.SetLevelInPropsIfSynced(SceneManagerHelper.ActiveSceneName);
	}

	protected void OnApplicationQuit()
	{
		AppQuits = true;
		StopFallbackSendAckThread();
		PhotonNetwork.Disconnect();
	}

	protected void OnApplicationPause(bool pause)
	{
		if (PhotonNetwork.BackgroundTimeout > 0.1f)
		{
			if (timerToStopConnectionInBackground == null)
			{
				timerToStopConnectionInBackground = new Stopwatch();
			}
			timerToStopConnectionInBackground.Reset();
			if (pause)
			{
				timerToStopConnectionInBackground.Start();
			}
			else
			{
				timerToStopConnectionInBackground.Stop();
			}
		}
		if (pause)
		{
			StopFallbackSendAckThread();
		}
		else
		{
			StartFallbackSendAckThread();
		}
	}

	protected void OnDestroy()
	{
		StopFallbackSendAckThread();
	}

	protected void Update()
	{
		// Local compatibility callbacks are synchronous; protobuf transport is serviced by War.Client.
	}

	protected void OnJoinedRoom()
	{
		PhotonNetwork.networkingPeer.LoadLevelIfSynced();
	}

	protected void OnCreatedRoom()
	{
		PhotonNetwork.networkingPeer.SetLevelInPropsIfSynced(SceneManagerHelper.ActiveSceneName);
	}

	public static void StartFallbackSendAckThread()
	{
		// No Photon transport thread is started in the self-hosted Client.
	}

	public static void StopFallbackSendAckThread()
	{
		sendThreadShouldRun = false;
	}

	public static bool FallbackSendAckThread()
	{
		return false;
	}

	protected internal static void PingAvailableRegionsAndConnectToBest()
	{
		// The Backend assigns the endpoint; Photon regions are never queried.
	}

	internal IEnumerator PingAvailableRegionsCoroutine(bool connectToBest)
	{
		BestRegionCodeCurrently = CloudRegionCode.none;
		yield break;
	}
}
