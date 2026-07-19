using System;
using Google2u;
using UnityEngine;

public class SubscriptionManager : DatabaseSerializedObjectGeneric<SubscriptionManager.Subscription>
{
	public class Subscription
	{
		public string type;

		public int expireTime;

		public int subscribeSince;
	}

	private static SubscriptionManager mInstance;

	private bool mLastSubscribeStatus;

	public static SubscriptionManager instance
	{
		get
		{
			mInstance = mInstance ?? ((SubscriptionManager)UnityEngine.Object.FindObjectsOfType(typeof(SubscriptionManager))[0]);
			return mInstance;
		}
	}

	private float mUpgradesConstantMultiplier
	{
		get
		{
			return Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.UpgradesSubscriptionMultiplierTime).FLOATVALUE;
		}
	}

	public float upgradesMultiplier
	{
		get
		{
			return (!isSubscribed) ? 1f : mUpgradesConstantMultiplier;
		}
	}

	public int expireTime
	{
		get
		{
			return (data != null) ? data.expireTime : 0;
		}
	}

	public int subscribeStart
	{
		get
		{
			return isSubscribed ? data.subscribeSince : 0;
		}
	}

	public string upgradesPercent
	{
		get
		{
			return MEJMLNDFDBP.JJBMMICPIIG(1f - mUpgradesConstantMultiplier);
		}
	}

	public string minusUpgradesPercent
	{
		get
		{
			return MEJMLNDFDBP.JJBMMICPIIG(mUpgradesConstantMultiplier - 1f);
		}
	}

	public string dogtagsPercent
	{
		get
		{
			int constDogtagSeconds = Singleton<DogTagManager>.instance.constDogtagSeconds;
			int constDogtagSubscriptionSeconds = Singleton<DogTagManager>.instance.constDogtagSubscriptionSeconds;
			return MEJMLNDFDBP.JJBMMICPIIG(1f - (float)constDogtagSubscriptionSeconds / (float)constDogtagSeconds);
		}
	}

	public bool isSubscribed
	{
		get
		{
			return expireTime > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	public bool trialSubscriptionUsed
	{
		get
		{
			return data.expireTime > 0;
		}
	}

	public event Action SubscriptionStateChanged;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void UpdateSubscription(int expireDate)
	{
		data.expireTime = expireDate;
		if (this.SubscriptionStateChanged != null)
		{
			this.SubscriptionStateChanged();
		}
		mLastSubscribeStatus = isSubscribed;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(EverySecondUpdate));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.EGMLDACJFCF = (Action)Delegate.Combine(counterManager2.EGMLDACJFCF, new Action(EverySecondUpdate));
	}

	public void BuySubcription()
	{
		Singleton<DogTagManager>.instance.ELLJNHLPDNF = ((!Singleton<DogTagManager>.instance.isFull) ? (Singleton<BeanstalkServerManager>.instance.currentTimestamp + Singleton<DogTagManager>.instance.timeToGetDogtag - Singleton<DogTagManager>.instance.remainingTimeForNextDogtag) : (Singleton<BeanstalkServerManager>.instance.currentTimestamp - 10));
		Singleton<BeanstalkServerManager>.instance.BuyInApp("subscription1");
		if (this.SubscriptionStateChanged != null)
		{
			this.SubscriptionStateChanged();
		}
	}

	private void EverySecondUpdate()
	{
		if (mLastSubscribeStatus != isSubscribed)
		{
			mLastSubscribeStatus = isSubscribed;
			if (this.SubscriptionStateChanged != null)
			{
				this.SubscriptionStateChanged();
			}
		}
	}
}
