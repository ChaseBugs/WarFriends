using System;
using UnityEngine;

public class TimeManager : Core_BaseScript
{
	public enum PauseStatus
	{
		Resumed,
		PausedLocaly,
		PausedLocalyFocusLost,
		PausedRemote,
		PausedRemoteFocusLost
	}

	private const float maxSpeed = 5f;

	public bool mIsFreezed;

	public bool gameIsRunning;

	private float from = 1f;

	private float to = 1f;

	private float mTimeScaleBeforeFreeze;

	private static DateTime mPauseStart;

	private float mDeltaTime;

	private float mRealDeltaTime;

	private float mDefaultFixedDeltaTime;

	private float mRealTime;

	private float mLastRealTime;

	private float mWantedTimeScale = 1f;

	private PhotonView mPhotonView;

	private static TimeManager mInstance;

	private int mPauseCounter;

	[Header("End Game")]
	public float endGamePhase0Time = 0.5f;

	public float endGamePhase0Time1 = 0.05f;

	public float endGamePhase0Time2 = 0.05f;

	public float endGamePhase1Time = 0.3f;

	public float endGamePhase1Time1 = 0.2f;

	public float endGamePhase1Time2 = 0.05f;

	public float endGamePhase2Time = 1f;

	public float endGamePhase2Time1 = 0.05f;

	public float endGamePhase2Time2 = 0.3f;

	private TimeTweener mTimeTweener;

	public static TimeManager instance
	{
		get
		{
			mInstance = mInstance ?? ((TimeManager)UnityEngine.Object.FindObjectsOfType(typeof(TimeManager))[0]);
			return mInstance;
		}
	}

	public PauseStatus pauseStatus { get; set; }

	public static float pauseTimeLeft => 30f - (float)(DateTime.Now - pauseStart).TotalSeconds;

	public static float deltaTimeWithoutPauses => instance.mDeltaTime;

	public static float realDeltaTime => instance.mRealDeltaTime;

	public static float realTimeWithoutPauses => instance.mRealTime;

	public bool isPaused => pauseStatus != PauseStatus.Resumed;

	public bool isPausedLocaly => pauseStatus == PauseStatus.PausedLocaly || pauseStatus == PauseStatus.PausedLocalyFocusLost;

	public static DateTime pauseStart => mPauseStart;

	public event Action<PauseStatus> GamePaused;

	public event Action<PauseStatus> GameResumed;

	protected override void Awake()
	{
		mInstance = this;
		mPhotonView = GetComponent<PhotonView>();
		mPhotonView.synchronization = ViewSynchronization.ReliableDeltaCompressed;
		mTimeTweener = GetComponent<TimeTweener>();
		mDefaultFixedDeltaTime = Time.fixedDeltaTime;
	}

	protected override void Start()
	{
		base.Start();
		mDeltaTime = 0f;
		mRealDeltaTime = 0f;
		mRealTime = 0f;
		mLastRealTime = Time.realtimeSinceStartup;
	}

	protected void Update()
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		if (!mPhotonView.isMine && PhotonConnectionManager.isInRoom && !mIsFreezed && gameIsRunning)
		{
			SetTimeScale(Mathf.Lerp(Time.timeScale, mWantedTimeScale, Mathf.Max(Time.deltaTime, 0.1f) * 12f));
		}
		if (Time.timeScale == 0f || mIsFreezed)
		{
			mDeltaTime = 0f;
		}
		else
		{
			mDeltaTime = Time.realtimeSinceStartup - mLastRealTime;
			mDeltaTime = Mathf.Clamp(mDeltaTime, 0f, 0.2f);
			mRealTime += mDeltaTime;
		}
		mRealDeltaTime = Time.realtimeSinceStartup - mLastRealTime;
		mLastRealTime = Time.realtimeSinceStartup;
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	private void PauseGame(bool focusLost)
	{
		mPauseCounter++;
		bool flag = !isPausedLocaly;
		if (flag)
		{
			mPauseStart = DateTime.Now;
		}
		if (PhotonNetwork.player != null)
		{
			mPhotonView.RPC("PauseGameRPC", PhotonTargets.AllBufferedViaServer, focusLost, flag, PhotonNetwork.player.ID, mPauseCounter);
		}
		FreezeGame();
		pauseStatus = PauseStatus.PausedLocaly;
		if (focusLost)
		{
			pauseStatus = PauseStatus.PausedLocalyFocusLost;
		}
		Debug.Log($"PauseGame: Focus lost {focusLost}, time: {mPauseStart}");
		if (this.GamePaused != null)
		{
			this.GamePaused(pauseStatus);
		}
	}

	[PunRPC]
	private void PauseGameRPC(bool focusLost, bool setTime, int playerID, int counter)
	{
		if (!gameIsRunning || PhotonNetwork.player == null || PhotonNetwork.player.ID == playerID)
		{
			return;
		}
		PlayerController player = PlayerController.GetPlayer(playerID);
		if (player != null && counter > player.networkStatus.pausesCount)
		{
			player.networkStatus.pausesCount = counter;
			Debug.Log($"PauseGameRPC: Focus lost {focusLost} setTIme {setTime}");
			if (setTime)
			{
				mPauseStart = DateTime.Now;
			}
			pauseStatus = PauseStatus.PausedRemote;
			if (focusLost)
			{
				pauseStatus = PauseStatus.PausedRemoteFocusLost;
			}
			if (this.GamePaused != null)
			{
				this.GamePaused(pauseStatus);
			}
			FreezeGame();
		}
	}

	public void ResetPauseCounters()
	{
		mPauseCounter = 0;
	}

	private void ResumeGame(float timeScale)
	{
		pauseStatus = PauseStatus.Resumed;
		mPhotonView.RPC("ResumeGameRPC", PhotonTargets.Others);
		UnFreezeGame(timeScale);
		if (this.GameResumed != null)
		{
			this.GameResumed(pauseStatus);
		}
	}

	[PunRPC]
	private void ResumeGameRPC()
	{
		pauseStatus = PauseStatus.Resumed;
		UnFreezeGame(0f);
		if (this.GameResumed != null)
		{
			this.GameResumed(pauseStatus);
		}
	}

	public void SetTimeScale(float value)
	{
		mTimeTweener.SetTimeScale(value);
	}

	public void EndGame()
	{
		Debug.LogWarning(string.Format("End Game", string.Empty));
		FreezeGame();
		Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.PrepareHeavy);
		TimeTweener timeTweener = BeginIgnoreFreeze(endGamePhase0Time, endGamePhase0Time1, endGamePhase0Time2);
		timeTweener.delay = 0f;
		timeTweener.onFinished = OnFinished;
	}

	private void OnFinished(UITweener tween)
	{
		if (DebugSettings.instance.data.vibrations)
		{
			Vibration.Vibrate(1000L);
		}
		TimeTweener timeTweener = BeginIgnoreFreeze(endGamePhase1Time, endGamePhase1Time1, endGamePhase1Time2);
		timeTweener.delay = 0f;
		timeTweener.onFinished = OnFinished2;
	}

	private void OnFinished2(UITweener tween)
	{
		TimeTweener timeTweener = BeginIgnoreFreeze(endGamePhase2Time, endGamePhase2Time1, endGamePhase2Time2);
	}

	public void EndMission()
	{
		if (!mIsFreezed)
		{
			TimeTweener timeTweener = BeginIgnoreFreeze(endGamePhase0Time, 0.001f, 0.001f);
			timeTweener.delay = 0f;
		}
		instance.mIsFreezed = true;
	}

	public void EndOfEndGame()
	{
		SetupPhysicsTiming(ragdoll: false);
	}

	public static TimeTweener Begin(float duration, float from, float to)
	{
		if (!instance.mIsFreezed)
		{
			return instance.mTimeTweener.Begin(duration, from, to);
		}
		return instance.mTimeTweener;
	}

	private static TimeTweener BeginIgnoreFreeze(float duration, float from, float to)
	{
		return TimeTweener.Begin(instance.gameObject, duration, from, to);
	}

	public static void FreezeGame()
	{
		if (!instance.mIsFreezed)
		{
			if (Time.timeScale >= 0.1f)
			{
				instance.mTimeScaleBeforeFreeze = Time.timeScale;
			}
			instance.mIsFreezed = true;
			Debug.Log("Freeze game:" + instance.mTimeScaleBeforeFreeze);
			instance.SetTimeScale(0f);
		}
	}

	public static void Pause(bool focusLost)
	{
		instance.PauseGame(focusLost);
	}

	public static void Reset()
	{
		instance.mIsFreezed = false;
		instance.mTimeScaleBeforeFreeze = 1f;
		instance.mWantedTimeScale = 1f;
		instance.pauseStatus = PauseStatus.Resumed;
		instance.SetTimeScale(1f);
		Begin(0f, 1f, 1f);
	}

	public static void Resume(float timeScale = 0f)
	{
		instance.ResumeGame(timeScale);
	}

	public static void UnFreezeGame(float timeScale = 0f)
	{
		instance.mIsFreezed = false;
		Debug.Log("Unfreeze " + instance.mTimeScaleBeforeFreeze);
		float num = Mathf.Max(Time.timeScale, 0f);
		Begin(0.5f, num, (!(timeScale > 0.5f)) ? instance.mTimeScaleBeforeFreeze : timeScale);
		instance.mWantedTimeScale = instance.mTimeScaleBeforeFreeze;
	}

	public static float GetTimeScaledSpeed(float speed, bool ignoreTimeScale)
	{
		float value = ((!ignoreTimeScale) ? 1f : (1f / Time.timeScale));
		value = Mathf.Clamp(value, 0f, 5f);
		return speed * value;
	}

	public static float GetTimeScaledInterval(float interval, bool ignoreTimeScale)
	{
		return (!ignoreTimeScale) ? interval : (interval * Time.timeScale);
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(Time.timeScale);
		}
		else
		{
			mWantedTimeScale = (float)stream.ReceiveNext();
		}
	}

	public void DebugTime()
	{
		Debug.LogError($"Pause status: {pauseStatus}, WantedTimeScale: {mWantedTimeScale}, TimeScale: {Time.timeScale}, Freezed:  {mIsFreezed}");
	}

	public void SetupPhysicsTiming(bool ragdoll)
	{
		Time.fixedDeltaTime = ((!ragdoll) ? mDefaultFixedDeltaTime : 0.004f);
	}
}
