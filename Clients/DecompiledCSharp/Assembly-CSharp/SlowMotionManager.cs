using UnityEngine;

public class SlowMotionManager : Singleton<SlowMotionManager>
{
	private float mLastUpdate;

	private PhotonView mPhotonView;

	private float mTimeRemaining;

	public AudioClip slowMotionStartSound;

	private bool wasNormalSlowmotion;

	public float slowMotionStrength => 1f - (Time.timeScale - 0.33f) / 0.66f;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		mTimeRemaining = 0f;
	}

	protected void Update()
	{
		if (mTimeRemaining == 0f || TimeManager.instance.isPaused)
		{
			return;
		}
		mTimeRemaining -= TimeManager.deltaTimeWithoutPauses;
		mTimeRemaining = Mathf.Clamp(mTimeRemaining, -0.1f, float.MaxValue);
		if (mTimeRemaining < 1f)
		{
			if (mTimeRemaining < 0.01f)
			{
				mTimeRemaining = 0f;
			}
			TimeManager.Begin(0f, 1f - mTimeRemaining, 1f - mTimeRemaining);
		}
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		base.enabled = false;
	}

	private void InstanceOnGameStarted()
	{
		Time.timeScale = 1f;
		base.enabled = true;
	}

	private void SlowGameFor(float seconds)
	{
		if (!(seconds < 2f))
		{
			mTimeRemaining = seconds;
			TimeManager.Begin(1f, Time.timeScale, 0.33f);
			SoundsManager.Instance.PlaySound(slowMotionStartSound);
		}
	}

	public void SlowMotionFor(float seconds)
	{
		if (PhotonNetwork.isMasterClient)
		{
			SlowGameFor(seconds);
			return;
		}
		Singleton<SlowMotionManager>.instance.mPhotonView.RPC("SlowMotionForNetwork", PhotonNetwork.masterClient, seconds);
	}

	[PunRPC]
	protected void SlowMotionForNetwork(float seconds)
	{
		SlowGameFor(seconds);
	}
}
