using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Recording : Singleton<Recording>
{
	private static bool mCanRecord;

	private static bool mTryToSetRecording;

	private static bool mTryToSetBroadcast;

	private static float startTime;

	private static int totalBattles;

	public static float xCoords;

	public static float yCoords;

	private static bool mIsBroadcasting;

	public static bool canBroadcast => SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3 && GetSDKLevel() > 20;

	public static bool recordingEnabled
	{
		get
		{
			return DebugSettings.record && canRecord;
		}
		set
		{
			if (value)
			{
				tryToSetRecording = true;
			}
			else
			{
				DebugSettings.record = false;
			}
		}
	}

	public static bool isBroadcasting => mIsBroadcasting;

	public bool isRecording => false;

	public static bool canRecord => mCanRecord;

	public static bool tryToSetRecording
	{
		get
		{
			return mTryToSetRecording;
		}
		set
		{
			mTryToSetRecording = value;
		}
	}

	public static bool tryToSetBroadcast
	{
		get
		{
			return mTryToSetBroadcast;
		}
		set
		{
			mTryToSetBroadcast = value;
		}
	}

	public event Action Changed;

	public event Action<bool> BroadcastChanged;

	public bool CheckModel(string desiredModel, int minVersion)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (deviceModel.StartsWith(desiredModel))
		{
			Debug.Log("Recording: CheckModel" + desiredModel);
			string text = deviceModel.Replace(desiredModel, string.Empty);
			string[] array = text.Split(',');
			if (array.Length > 0)
			{
				int result = 0;
				int.TryParse(array[0], out result);
				Debug.Log($"Recording: CheckModel version {result}");
				if (result >= minVersion)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static int GetSDKLevel()
	{
		IntPtr clazz = AndroidJNI.FindClass("android.os.Build$VERSION");
		IntPtr staticFieldID = AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
		return AndroidJNI.GetStaticIntField(clazz, staticFieldID);
	}

	protected override void Awake()
	{
		base.Awake();
		mCanRecord &= CheckModel("iPad", 4) || CheckModel("iPhone", 6);
	}

	public static void StartBroadcast()
	{
		Debug.Log("Start broadcasting");
	}

	private static void BroadcastError(string err)
	{
		Debug.LogError(err);
	}

	public static void FinishBroadcast()
	{
		Debug.Log("Finish broadcasting");
		mIsBroadcasting = false;
		if (Singleton<Recording>.instance.BroadcastChanged != null)
		{
			Singleton<Recording>.instance.BroadcastChanged(obj: false);
		}
	}

	private void OnApplicationResumed()
	{
		if (mIsBroadcasting)
		{
			FinishBroadcast();
		}
	}

	public void StartRecording()
	{
		if (DebugSettings.record)
		{
			CancelRecording();
		}
	}

	public void StopRecording()
	{
		if (!DebugSettings.record)
		{
		}
	}

	public void CancelRecording()
	{
		if (!DebugSettings.record)
		{
		}
	}

	public void ShowPreview()
	{
		if (!DebugSettings.record)
		{
		}
	}
}
