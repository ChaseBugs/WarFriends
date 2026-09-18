using System;
using System.Collections;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
	public enum SessionUpdate
	{
		None,
		Full,
		Light
	}

	private int mInactivityDelay = 300;

	private float mPauseTime;

	private bool mScheduleLightSessionUpdate;

	private bool mScheduleSessionUpdate;

	private bool mSheduleGCCheck;

	private bool mScheduleRefresh;

	private bool mGcAuthenticated;

	private bool mPaused;

	private bool inAppInProgress;

	private bool wasInapp;

	private SessionUpdate mSessionUpdate;

	private DateTime mLastTime;

	private int mHelpC;

	private DateTime mPauseDateTime;

	private float tryAutenticateTime = -1f;

	public bool gcAuthenticated
	{
		get
		{
			return mGcAuthenticated;
		}
		set
		{
			mGcAuthenticated = value;
		}
	}

	public bool schedulingOrInProgressAnyUpdate => mSessionUpdate != SessionUpdate.None || !gcAuthenticated || mScheduleSessionUpdate || mScheduleLightSessionUpdate;

	private bool skipFullSesionUpdate => GameLoginManager.instance == null || GameLoginManager.instance.data == null || !GameLoginManager.instance.data.isDeviceRegistered || Singleton<GameController>.instance == null || Singleton<GameController>.instance.isTutorialInProgressOrPlaned || GameLoginManager.instance.acountDataDownloadingInProgress;

	private bool fullUpdateCanBeDone => !GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData;

	public bool paused
	{
		get
		{
			return mPaused;
		}
		set
		{
			mPaused = value;
		}
	}

	public event Action ApplicationResumed;

	protected override void Awake()
	{
		mLastTime = DateTime.UtcNow;
		tryAutenticateTime = -1f;
		Singleton<GameCenterProvider>.instance.Authenticated += OnGcAuthenticated;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += InstanceOnAfterPlayerDataLoaded;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.SetPlayerStatus)
		{
			Debug.Log("SessionManager: Refreshed!");
			mScheduleRefresh = false;
		}
	}

	private void InstanceOnAfterPlayerDataLoaded()
	{
		Crittercism.SetUsername(GameLoginManager.currentPlayer.name);
	}

	private void OnGcAuthenticated(bool success)
	{
		Debug.Log("Session: On GC authenticated! Result = " + success);
		if (mSessionUpdate == SessionUpdate.None && !paused && !mScheduleSessionUpdate && !Singleton<GameController>.instance.isTutorial)
		{
			mScheduleLightSessionUpdate = true;
			mSheduleGCCheck = true;
			Debug.Log("set schedule gc check 1");
		}
		if (mSessionUpdate == SessionUpdate.None && !paused && !mScheduleSessionUpdate && !mScheduleLightSessionUpdate && Singleton<GameController>.instance.isTutorial)
		{
			if (GameLoginManager.instance.acountDataDownloadingInProgress)
			{
				mSheduleGCCheck = true;
				Debug.Log("set schedule gc check 2");
			}
			else
			{
				GameLoginManager.instance.GamecenterChangeDuringTutorial();
			}
		}
		gcAuthenticated = true;
	}

	private void OnApplicationQuit()
	{
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Singleton<BeanstalkServerManager>.instance.SetPlayerStatus(PlayerStatus.Offline);
		}
	}

	private void SendOnApplicationResumed(Transform root)
	{
		root.SendMessage("OnApplicationResumed", SendMessageOptions.DontRequireReceiver);
		for (int i = 0; i < root.childCount; i++)
		{
			Transform child = root.GetChild(i);
			SendOnApplicationResumed(child);
		}
	}

	protected void Update()
	{
		if (GameLoginManager.instance == null || GameLoginManager.instance.data == null)
			return;
		CheckLongSleep();
		if (paused)
		{
			if (inAppInProgress)
			{
				return;
			}
			mHelpC++;
			if (mHelpC > 10)
			{
				mHelpC = 0;
				paused = false;
				Debug.Log("SessionManager: Send OnApplicationResumed to Managers !!!");
				if (this.ApplicationResumed != null)
				{
					this.ApplicationResumed();
				}
				SendOnApplicationResumed(Singleton<MainSceneRoot>.instance.transform.Find("Managers"));
			}
			return;
		}
		if (!gcAuthenticated && Time.time - tryAutenticateTime > 3f && tryAutenticateTime > 0f)
		{
			Debug.LogError("GC autenticate wait time-out => let last GC state valid");
			tryAutenticateTime = -1f;
			gcAuthenticated = true;
		}
		if (gcAuthenticated && mSessionUpdate != SessionUpdate.None)
		{
			Debug.LogError("Session: Update GC authenticated! session update = " + mSessionUpdate);
			mScheduleLightSessionUpdate = false;
			if (!Singleton<BeanstalkServerManager>.instance.waitForInput)
			{
				switch (mSessionUpdate)
				{
				case SessionUpdate.Full:
					mScheduleSessionUpdate = true;
					break;
				case SessionUpdate.Light:
					LightUpdateSession();
					break;
				}
			}
			mSessionUpdate = SessionUpdate.None;
			tryAutenticateTime = -1f;
			gcAuthenticated = false;
			Debug.Log("Set false");
		}
		if (mScheduleLightSessionUpdate && Singleton<GameController>.instance.gameState == GameController.GameState.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			mScheduleLightSessionUpdate = false;
			LightUpdateSession();
		}
		bool flag = false;
		if (mSheduleGCCheck && GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && GuiElementSingle<UserExistsDialog>.instance.isShowed)
		{
			mScheduleSessionUpdate = true;
			flag = true;
			mScheduleLightSessionUpdate = false;
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
		}
		if (mScheduleSessionUpdate && (fullUpdateCanBeDone || flag))
		{
			mSheduleGCCheck = false;
			Debug.Log("SessionManager: Update, Full Session Update");
			if (TutorialManagerStage3.instance.isTutorialRunning)
			{
				TutorialManagerStage3.instance.StopAllCoroutines();
			}
			Singleton<GameController>.instance.Quit();
			if (Singleton<GameController>.instance.gameState == GameController.GameState.WaitingForResponse)
			{
				Singleton<GameController>.instance.TryStopLoading();
			}
			if (GuiScreenSingle<MainScreen>.instance.isShowed)
			{
				GuiScreenSingle<MainScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
			}
			mScheduleSessionUpdate = false;
			Debug.Log("========Session Update============");
			DialogManager.instance.HideAllDialogs();
			GameLoginManager.instance.RegisterOrLogin();
		}
		if (mSheduleGCCheck && Singleton<GameController>.instance.isTutorial && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			mSheduleGCCheck = false;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
		}
		if (Singleton<BeanstalkServerManager>.instance.lastUpdate > 2400 && mSessionUpdate == SessionUpdate.None && Singleton<GameController>.instance.gameState == GameController.GameState.Menu && !mScheduleRefresh)
		{
			Debug.LogError("SCHEDULING PLAYER STATUS UPDATE!!");
			Singleton<BeanstalkServerManager>.instance.SetPlayerStatus((!Singleton<GameController>.instance.gameIsRunning) ? PlayerStatus.Online : PlayerStatus.InGame);
			mScheduleRefresh = true;
		}
	}

	private void CheckLongSleep()
	{
		float num = (float)(DateTime.UtcNow - mLastTime).TotalSeconds;
		if (num > (float)mInactivityDelay && !skipFullSesionUpdate)
		{
			Debug.Log($"Check Device sleep at {mLastTime}, waked up at {DateTime.UtcNow} Dif: {num} Session update: {mSessionUpdate}, ScheduleSessionUpdate: {mScheduleSessionUpdate}");
			CheckSessionUpdate(num);
		}
		mLastTime = DateTime.UtcNow;
	}

	public void ScheduleGCCheck()
	{
		mSheduleGCCheck = true;
	}

	public void StartInapp()
	{
		inAppInProgress = true;
	}

	public void FinishInapp()
	{
		wasInapp = true;
		inAppInProgress = false;
	}

	protected void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
			{
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
			}
			paused = true;
			gcAuthenticated = false;
			tryAutenticateTime = -1f;
			mHelpC = 0;
			mPauseTime = Time.realtimeSinceStartup;
			mPauseDateTime = DateTime.UtcNow;
			if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
			{
				Singleton<BeanstalkServerManager>.instance.SetPlayerStatus(PlayerStatus.Offline);
				GC.Collect();
			}
			Debug.Log($"Device PAUSED at {DateTime.UtcNow} RealTime: {mPauseTime}, Doing CG.Collect() = {Singleton<GameController>.instance.gameState == GameController.GameState.Menu}");
			StopAllCoroutines();
		}
		else
		{
			Debug.Log($"Device UNPAUSED at {DateTime.UtcNow}");
		}
	}

	private void OnApplicationResumed()
	{
		InvokeAfterRealTime(delegate
		{
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}, 0.5f);
		if (skipFullSesionUpdate)
		{
			Debug.Log("SessionManager: Skipping sessions update. Device not registered or is in tutorial");
			if (gcAuthenticated && !mScheduleLightSessionUpdate && !mScheduleSessionUpdate && !Singleton<GameController>.instance.isTutorial)
			{
				mScheduleLightSessionUpdate = true;
			}
			if (gcAuthenticated)
			{
				mSheduleGCCheck = true;
			}
			gcAuthenticated = true;
		}
		else
		{
			float num = Time.realtimeSinceStartup - mPauseTime;
			float num2 = (float)(DateTime.UtcNow - mPauseDateTime).TotalSeconds;
			num = ((!(num2 > num)) ? num : num2);
			Debug.Log($"Device slept at {mPauseDateTime}, RealTime: {mPauseTime} waked up at {DateTime.UtcNow} RealTime: {Time.realtimeSinceStartup} and slept for {num}");
			CheckSessionUpdate(num);
			StartCoroutine(RadicalRoutine.Run(AuthenticateGc()));
		}
	}

	private void CheckSessionUpdate(float pauseLength)
	{
		if (mSessionUpdate != SessionUpdate.Full && !mScheduleSessionUpdate)
		{
			mScheduleLightSessionUpdate = false;
			mSessionUpdate = ((mPauseTime != 0f && pauseLength > (float)mInactivityDelay) ? SessionUpdate.Full : SessionUpdate.Light);
			Debug.Log(string.Concat("SessionManager: On application resumed, Setting session update = ", mSessionUpdate, ", waiting for GC"));
			if (mSessionUpdate == SessionUpdate.Full && fullUpdateCanBeDone)
			{
				LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), showCancelButton: false, hideBackgroundElements: false, showInstantly: true);
				Singleton<MessageManager>.instance.StopMessageCoroutine();
			}
			if (mSessionUpdate == SessionUpdate.Light)
			{
				InvokeAfterRealTime(delegate
				{
					Singleton<GuiManager>.instance.TurnOnInputCompletly();
				}, 0.15f);
			}
		}
		else
		{
			Debug.Log("skip session update scheduling, because alredy session update is " + mSessionUpdate.ToString() + " and mScheduleSessionUpdate is " + mScheduleSessionUpdate);
		}
	}

	private IEnumerator AuthenticateGc()
	{
		if (wasInapp)
		{
			gcAuthenticated = true;
			wasInapp = false;
			yield break;
		}
		Debug.Log("GC autentication corutine after pause started");
		yield return new WaitForRealSeconds(0.5f);
		if (!gcAuthenticated && mSessionUpdate != SessionUpdate.None)
		{
			if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
			{
				OnGcAuthenticated(Singleton<GameCenterProvider>.instance.isAuthenticated);
				yield break;
			}
			Debug.Log("call check CG autentication");
			tryAutenticateTime = Time.time;
			Singleton<GameCenterProvider>.instance.Authenticate(canShowLoginDialog: false);
		}
	}

	private void LightUpdateSession()
	{
		if (mScheduleSessionUpdate)
		{
			return;
		}
		Debug.Log("SessionManager: Light Session Update");
		if (GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			Debug.Log("Already loading player data, wait");
			mScheduleLightSessionUpdate = true;
			mSheduleGCCheck = true;
			return;
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			mSheduleGCCheck = false;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
			return;
		}
		mSheduleGCCheck = false;
		if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			Debug.Log("SessionManager: IN MENU!!");
			GameLoginManager.instance.RegisterOrLogin(SessionUpdate.Light);
			Singleton<PhotonConnectionManager>.instance.CheckIfShouldPing();
			return;
		}
		Debug.Log("SessionManager: NOT IN MENU!!!");
		if (!Singleton<GameController>.instance.isTutorial)
		{
			mScheduleLightSessionUpdate = true;
		}
	}
}
