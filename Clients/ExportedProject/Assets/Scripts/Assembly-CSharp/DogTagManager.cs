using System;
using System.Collections;
using Google2u;
using UnityEngine;

public class DogTagManager : Singleton<DogTagManager>
{
	private const int mBaseDogtagRefillPrice = 35;

	public Action DogtagServerUpdate;

	[Header("Server setted values")]
	public int lastUpdate;

	public int seconds;

	public int max;

	private int mDogTagWaitingTime = 720;

	private int mLastDogTagCount = -1;

	private int mUsedDogtagsLocaly;

	private int mTimeOfLastLocalDogUse;

	public int dogtagRefillPrice => 35 - 2 * currentDogtags;

	public int timeToGetDogtag => mDogTagWaitingTime;

	private int mServerSeconds => seconds + (Singleton<BeanstalkServerManager>.instance.currentTimestamp - lastUpdate);

	private int mVipSeconds => Singleton<VipManager>.instance.numberOfVIPDogtags * mDogTagWaitingTime;

	private int mMaxSeconds => (!Singleton<VipManager>.instance.IsVipActive()) ? max : (max + mVipSeconds);

	private int mCurrentSeconds => (!Singleton<VipManager>.instance.IsVipActive()) ? mServerSeconds : (mServerSeconds + mVipSeconds);

	private int mCurrentSecondsClamp => Mathf.Clamp(mCurrentSeconds, 0, mMaxSeconds);

	private int mCurrentLocalSeconds => mCurrentSecondsClamp - mUsedDogtagsLocaly * mDogTagWaitingTime;

	private int mSecondsSinceLocalDogTagUsed => Singleton<BeanstalkServerManager>.instance.currentTimestamp - mTimeOfLastLocalDogUse;

	public int currentDogtags => mCurrentLocalSeconds / mDogTagWaitingTime;

	public int maximumDogtags => mMaxSeconds / mDogTagWaitingTime;

	public bool isEmpty => mCurrentSeconds < mDogTagWaitingTime;

	public bool isFull => currentDogtags >= maximumDogtags;

	public int remainingTimeForNextDogtag
	{
		get
		{
			if (mUsedDogtagsLocaly > 0)
			{
				return mDogTagWaitingTime - (mCurrentLocalSeconds + mSecondsSinceLocalDogTagUsed) % mDogTagWaitingTime;
			}
			return (!isFull) ? (mDogTagWaitingTime - mCurrentLocalSeconds % mDogTagWaitingTime) : 0;
		}
	}

	public float progressToNextDogtag
	{
		get
		{
			if (mUsedDogtagsLocaly > 0)
			{
				return (float)((mCurrentLocalSeconds + mSecondsSinceLocalDogTagUsed) % mDogTagWaitingTime) / (float)mDogTagWaitingTime;
			}
			return (float)(mCurrentLocalSeconds % mDogTagWaitingTime) / (float)mDogTagWaitingTime;
		}
	}

	public event Action<int> DogtagsChanged;

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
	}

	private void OnPlayerDataLoaded()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE;
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE;
		Debug.Log($"DogTag Manager: Configurations loaded: dogtag seconds: {num} dogtag count: {num2}");
		mDogTagWaitingTime = num;
		max = num2 * num;
		InitDogTagCount();
	}

	internal void InitDogTagCount()
	{
		mLastDogTagCount = currentDogtags;
	}

	internal void UpdateDogtags(int dtSeconds, int dtLastUpdate, int dtMax = 0)
	{
		mUsedDogtagsLocaly = 0;
		lastUpdate = dtLastUpdate;
		seconds = dtSeconds;
		if (dtMax != 0)
		{
			max = dtMax;
		}
		Debug.Log($"DogTag Manager: Update from server\ncurrentDogtags {currentDogtags}\nserver response: seconds {seconds} lastUpdate {lastUpdate}\nserverSeconds {mServerSeconds} currentTime {Singleton<BeanstalkServerManager>.instance.currentTimestamp} maxSeconds {max}");
		if (DogtagServerUpdate != null)
		{
			DogtagServerUpdate();
		}
		PushNotificationManager.instance.ScheduleLocalDogtagNotification(max - seconds);
	}

	protected override void Start()
	{
		base.Start();
		StartCoroutine(UpdateDogTags(0.5f));
	}

	private void OnApplicationResumed()
	{
		if (this.DogtagsChanged != null)
		{
			this.DogtagsChanged(currentDogtags);
		}
	}

	private IEnumerator UpdateDogTags(float updateTime)
	{
		while (GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			yield return null;
		}
		while (true)
		{
			int dogtagsInteger = currentDogtags;
			if (this.DogtagsChanged != null)
			{
				this.DogtagsChanged(dogtagsInteger);
			}
			if (mLastDogTagCount != -1 && mLastDogTagCount != dogtagsInteger)
			{
				if (dogtagsInteger > mLastDogTagCount)
				{
					bool isInMenu = Singleton<GameController>.instance.gameState == GameController.GameState.Menu;
					bool canPlaySound = isInMenu && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && !Singleton<SessionManager>.instance.schedulingOrInProgressAnyUpdate;
					Debug.Log("DogTag Manager: Playing dogtag sound - I am in menu: " + isInMenu + " account data are being downloaded: " + GameLoginManager.instance.acountDataDownloadingInProgress + " loading player data: " + Singleton<BeanstalkServerManager>.instance.loadingPlayerData + " any update scheduled or in progress: " + Singleton<SessionManager>.instance.schedulingOrInProgressAnyUpdate);
					if (canPlaySound)
					{
						SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DogTagGain);
					}
				}
				mLastDogTagCount = dogtagsInteger;
			}
			yield return new WaitForSeconds(updateTime);
		}
	}

	public bool CanUseDogtags(int amount)
	{
		return currentDogtags >= amount;
	}

	public void UseDogTagLocaly()
	{
		Debug.Log("DogTag Manager: Use LOCAL DogTag");
		GuiElementSingle<HeaderDogtagButton>.instance.AnimateDogtagUse();
		mUsedDogtagsLocaly++;
		mTimeOfLastLocalDogUse = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (this.DogtagsChanged != null)
		{
			this.DogtagsChanged(currentDogtags);
		}
	}

	public void ResetLocalDogtags()
	{
		mUsedDogtagsLocaly = 0;
		if (this.DogtagsChanged != null)
		{
			this.DogtagsChanged(currentDogtags);
		}
	}

	public void RefillAllDogtags()
	{
		PushNotificationManager.instance.CancelLocalNotification("dogtag");
		seconds = max;
		if (this.DogtagsChanged != null)
		{
			this.DogtagsChanged(currentDogtags);
		}
	}

	public void PayOneDogTag()
	{
		Debug.Log($"DogTag Manager: Pay one dogtag {seconds}, used localy:{mUsedDogtagsLocaly}");
		Singleton<BeanstalkServerManager>.instance.PayOneDogtag();
		if (mUsedDogtagsLocaly == 0)
		{
			GuiElementSingle<HeaderDogtagButton>.instance.AnimateDogtagUse();
		}
		int num = mServerSeconds;
		int num2 = mDogTagWaitingTime;
		if (num > max)
		{
			num2 += num - max;
		}
		seconds -= num2;
		if (this.DogtagsChanged != null)
		{
			this.DogtagsChanged(currentDogtags);
		}
	}
}
