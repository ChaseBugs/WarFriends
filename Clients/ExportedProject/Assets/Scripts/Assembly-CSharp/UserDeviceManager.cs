using System.Collections.Generic;
using Beebyte.Obfuscator;
using CodeStage.AdvancedFPSCounter;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class UserDeviceManager : DatabaseSerializedObjectGeneric<UserDeviceManager.UserDevices>
{
	[Skip]
	public class UserDevices
	{
		public Dictionary<string, UserDevice> userDevices = new Dictionary<string, UserDevice>();
	}

	[Skip]
	public class UserDevice
	{
		public List<int> lastAverageFps = new List<int>();
	}

	private static UserDeviceManager mInstance;

	public static UserDeviceManager instance
	{
		get
		{
			mInstance = mInstance ?? ((UserDeviceManager)Object.FindObjectsOfType(typeof(UserDeviceManager))[0]);
			return mInstance;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnInstanceOnAfterPlayerDataLoaded;
	}

	private void OnInstanceOnAfterPlayerDataLoaded()
	{
		Debug.Log("IS SLOW DEVICE?? " + ((!IsSlowDevice()) ? "NO" : "YES"));
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (!data.userDevices.TryGetValue(deviceModel, out var value))
		{
			value = new UserDevice();
			data.userDevices.Add(deviceModel, value);
		}
		if (value.lastAverageFps.Count > 4)
		{
			for (int i = 0; i < value.lastAverageFps.Count - 1; i++)
			{
				value.lastAverageFps[i] = value.lastAverageFps[i + 1];
			}
			value.lastAverageFps[value.lastAverageFps.Count - 1] = AFPSCounter.Instance.fpsCounter.lastAverageValue;
		}
		else
		{
			value.lastAverageFps.Add(AFPSCounter.Instance.fpsCounter.lastAverageValue);
		}
	}

	public Tuple<string, string> GetUserDeviceData()
	{
		string deviceModel = SystemInfo.deviceModel;
		if (data.userDevices.ContainsKey(deviceModel))
		{
			return new Tuple<string, string>(deviceModel, JsonConvert.SerializeObject(data.userDevices[deviceModel]));
		}
		return null;
	}

	public float GetAverageMatchFPS()
	{
		string deviceModel = SystemInfo.deviceModel;
		if (!data.userDevices.TryGetValue(deviceModel, out var value) && data.userDevices.Count > 0)
		{
			using (Dictionary<string, UserDevice>.Enumerator enumerator = data.userDevices.GetEnumerator())
			{
			if (enumerator.MoveNext())
			{
				value = enumerator.Current.Value;
			}
				}
}
		if (value != null)
		{
			float num = 0f;
			foreach (int lastAverageFp in value.lastAverageFps)
			{
				num += (float)lastAverageFp;
			}
			return num / (float)value.lastAverageFps.Count;
		}
		return 0f;
	}

	public bool IsSlowDevice()
	{
		return GetAverageMatchFPS() < Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MatchmakingMinAverageFps).FLOATVALUE;
	}
}
