using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP;
using CodeStage.AdvancedFPSCounter;
using UnityEngine;

public class PerformanceLoggerManager : Singleton<PerformanceLoggerManager>
{
	private const string mConnectionUrl = "http://aboutfun.cust.n2n.cz/soldierz_hardware_stats.php";

	private int mMemoryWarningDuringGame;

	private int mRecievedWarnings;

	private HTTPRequest mDownload;

	public int memoryWarningDuringGame
	{
		get
		{
			return mMemoryWarningDuringGame;
		}
		set
		{
			mMemoryWarningDuringGame = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		StartCoroutine(RadicalRoutine.Run(CheckMemoryWarnings()));
	}

	private void InstanceOnGameStarted()
	{
		memoryWarningDuringGame = 0;
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		if (DebugSettings.isOurDevice)
		{
			List<Tuple<string, object>> list = new List<Tuple<string, object>>();
			list.Add(new Tuple<string, object>("id", SystemInfo.deviceUniqueIdentifier));
			list.Add(new Tuple<string, object>("deviceName", SystemInfo.deviceName));
			list.Add(new Tuple<string, object>("version", Singleton<CurrentBundleVersion>.instance.version));
			list.Add(new Tuple<string, object>("mode", Singleton<GameController>.instance.gameType.ToString()));
			list.Add(new Tuple<string, object>("phoneType", Application.platform.ToString()));
			list.Add(new Tuple<string, object>("AVG_FPS", AFPSCounter.Instance.fpsCounter.lastAverageValue.ToString()));
			list.Add(new Tuple<string, object>("MIN_FPS", AFPSCounter.Instance.fpsCounter.lastMinimumValue.ToString()));
			list.Add(new Tuple<string, object>("MIN_FPS", AFPSCounter.Instance.fpsCounter.lastMinimumValue.ToString()));
			list.Add(new Tuple<string, object>("allocMem", AFPSCounter.Instance.memoryCounter.lastAllocatedValue));
			list.Add(new Tuple<string, object>("monoMem", AFPSCounter.Instance.memoryCounter.lastMonoValue));
			list.Add(new Tuple<string, object>("totalMem", AFPSCounter.Instance.memoryCounter.lastTotalValue));
			list.Add(new Tuple<string, object>("isMaster", PhotonNetwork.isMasterClient.ToString()));
			list.Add(new Tuple<string, object>("memoryWarnings", memoryWarningDuringGame.ToString()));
			list.Add(new Tuple<string, object>("Metal", Singleton<PerformanceManager>.instance.isMetal));
			List<Tuple<string, object>> data = list;
			StartCoroutine(SendData(data));
		}
	}

	private IEnumerator CheckMemoryWarnings()
	{
		while (true)
		{
			mRecievedWarnings = 0;
			yield return new WaitForRealSeconds(10f);
			if (mRecievedWarnings > 0)
			{
				Debug.LogError($"Recieved {mRecievedWarnings} memory warnings in last 10 seconds");
			}
		}
	}

	public void ReceivedMemoryWarning(string message)
	{
		memoryWarningDuringGame++;
		mRecievedWarnings++;
	}

	private IEnumerator SendData(IEnumerable<Tuple<string, object>> data)
	{
		Debug.Log("Send data");
		mDownload = new HTTPRequest(new Uri("http://aboutfun.cust.n2n.cz/soldierz_hardware_stats.php"), HTTPMethods.Post, OnRequestSend)
		{
			Timeout = TimeSpan.FromSeconds(20.0),
			ConnectTimeout = TimeSpan.FromSeconds(20.0),
			DisableRetry = true,
			DisableCache = true
		};
		foreach (Tuple<string, object> tuple in data)
		{
			mDownload.AddField(tuple.Value1, tuple.Value2.ToString());
		}
		mDownload.Send();
		yield return mDownload;
	}

	private void OnRequestSend(HTTPRequest originalrequest, HTTPResponse response)
	{
	}
}
