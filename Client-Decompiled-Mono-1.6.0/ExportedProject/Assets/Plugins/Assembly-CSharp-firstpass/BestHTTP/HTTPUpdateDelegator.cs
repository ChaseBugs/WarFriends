using System.Threading;
using BestHTTP.Caching;
using BestHTTP.Cookies;
using UnityEngine;

namespace BestHTTP
{
	[ExecuteInEditMode]
	public sealed class HTTPUpdateDelegator : MonoBehaviour
	{
		private static bool IsSetupCalled;

		public static HTTPUpdateDelegator Instance { get; private set; }

		public static bool IsCreated { get; private set; }

		public static bool IsThreaded { get; set; }

		public static bool IsThreadRunning { get; private set; }

		public static int ThreadFrequencyInMS { get; set; }

		static HTTPUpdateDelegator()
		{
			ThreadFrequencyInMS = 100;
		}

		public static void CheckInstance()
		{
			try
			{
				if (!IsCreated)
				{
					GameObject gameObject = GameObject.Find("HTTP Update Delegator");
					if (gameObject != null)
					{
						Instance = gameObject.GetComponent<HTTPUpdateDelegator>();
					}
					if (Instance == null)
					{
						gameObject = new GameObject("HTTP Update Delegator");
						gameObject.hideFlags = HideFlags.HideAndDontSave;
						Object.DontDestroyOnLoad(gameObject);
						Instance = gameObject.AddComponent<HTTPUpdateDelegator>();
					}
					IsCreated = true;
				}
			}
			catch
			{
				HTTPManager.Logger.Error("HTTPUpdateDelegator", "Please call the BestHTTP.HTTPManager.Setup() from one of Unity's event(eg. awake, start) before you send any request!");
			}
		}

		private void Setup()
		{
			HTTPCacheService.SetupCacheFolder();
			CookieJar.SetupFolder();
			CookieJar.Load();
			if (IsThreaded)
			{
				new Thread(ThreadFunc).Start();
			}
			IsSetupCalled = true;
		}

		private void ThreadFunc(object obj)
		{
			HTTPManager.Logger.Information("HTTPUpdateDelegator", "Update Thread Started");
			try
			{
				IsThreadRunning = true;
				while (IsThreadRunning)
				{
					HTTPManager.OnUpdate();
					Thread.Sleep(ThreadFrequencyInMS);
				}
			}
			finally
			{
				HTTPManager.Logger.Information("HTTPUpdateDelegator", "Update Thread Ended");
			}
		}

		private void Update()
		{
			if (!IsSetupCalled)
			{
				IsSetupCalled = true;
				Setup();
			}
			if (!IsThreaded)
			{
				HTTPManager.OnUpdate();
			}
		}

		private void OnDisable()
		{
			OnApplicationQuit();
		}

		private void OnApplicationQuit()
		{
			IsThreadRunning = false;
			if (IsCreated)
			{
				IsCreated = false;
				HTTPManager.OnQuit();
			}
		}
	}
}
