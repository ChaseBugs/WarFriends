using System;
using Fabric.Crashlytics;
using Fabric.Internal.Runtime;
using UnityEngine;

namespace Fabric.Internal.Crashlytics
{
	public class CrashlyticsInit : MonoBehaviour
	{
		private static readonly string kitName = "Crashlytics";

		private static CrashlyticsInit instance;

		private void Awake()
		{
			Debug.Log("[Crashlytics Init] Awake");
			if (instance == null)
			{
				AwakeOnce();
				instance = this;
				Debug.Log("[Crashlytics Init] Awake->DontDestroyOnLoad");
				UnityEngine.Object.DontDestroyOnLoad(this);
			}
			else if (instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void AwakeOnce()
		{
			Debug.Log("[Crashlytics Init] AwakeOnce");
			RegisterExceptionHandlers();
		}

		private static void RegisterExceptionHandlers()
		{
			Debug.Log("[Crashlytics Init] RegisterExceptionHandlers");
			if (IsSDKInitialized())
			{
				Debug.Log("[Crashlytics Init] RegisterExceptionHandlers->IsSDKInitialized() == true");
				Utils.Log(kitName, "Registering exception handlers");
				AppDomain.CurrentDomain.UnhandledException += HandleException;
				Application.logMessageReceived += HandleLog;
			}
			else
			{
				Debug.Log("[Crashlytics Init] RegisterExceptionHandlers->IsSDKInitialized() == false");
				Utils.Log(kitName, "Did not register exception handlers: Crashlytics SDK was not initialized");
			}
		}

		private static bool IsSDKInitialized()
		{
			Debug.Log("[Crashlytics Init] IsSDKInitialized");
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.crashlytics.android.Crashlytics");
			AndroidJavaObject androidJavaObject = null;
			try
			{
				Debug.Log("[Crashlytics Init] IsSDKInitialized->CallStatic Before");
				androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
				Debug.Log("[Crashlytics Init] IsSDKInitialized->CallStatic After");
			}
			catch (Exception ex)
			{
				Debug.Log("[Crashlytics Init] IsSDKInitialized->CallStatic Exception: " + ex.ToString());
				androidJavaObject = null;
			}
			return androidJavaObject != null;
		}

		private static void HandleException(object sender, UnhandledExceptionEventArgs eArgs)
		{
			Exception ex = (Exception)eArgs.ExceptionObject;
			HandleLog(ex.Message.ToString(), ex.StackTrace.ToString(), LogType.Exception);
		}

		private static void HandleLog(string message, string stackTraceString, LogType type)
		{
			if (type == LogType.Exception)
			{
				Utils.Log(kitName, "Recording exception: " + message);
				Utils.Log(kitName, "Exception stack trace: " + stackTraceString);
				string[] messageParts = getMessageParts(message);
				Fabric.Crashlytics.Crashlytics.RecordCustomException(messageParts[0], messageParts[1], stackTraceString);
			}
		}

		private static string[] getMessageParts(string message)
		{
			char[] separator = new char[1] { ':' };
			string[] array = message.Split(separator, 2, StringSplitOptions.None);
			string[] array2 = array;
			foreach (string text in array2)
			{
				text.Trim();
			}
			if (array.Length == 2)
			{
				return array;
			}
			return new string[2] { "Exception", message };
		}
	}
}
