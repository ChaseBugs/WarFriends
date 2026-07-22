using System;
using Google2u;
using WarFriends.Legacy;

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
			mInstance = mInstance ?? ((SubscriptionManager)SingletonSupport.FindOrCreate(typeof(SubscriptionManager)));
			return mInstance;
		}
	}

	private float mUpgradesConstantMultiplier => Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.UpgradesSubscriptionMultiplierTime).FLOATVALUE;

	public float upgradesMultiplier => (!isSubscribed) ? 1f : mUpgradesConstantMultiplier;

	public int expireTime => (data != null) ? data.expireTime : 0;

	public int subscribeStart => isSubscribed ? data.subscribeSince : 0;

	public string upgradesPercent => MEJMLNDFDBP.JJBMMICPIIG(1f - mUpgradesConstantMultiplier);

	public string minusUpgradesPercent => MEJMLNDFDBP.JJBMMICPIIG(mUpgradesConstantMultiplier - 1f);

	public string dogtagsPercent
	{
		get
		{
			int constDogtagSeconds = Singleton<DogTagManager>.instance.constDogtagSeconds;
			int constDogtagSubscriptionSeconds = Singleton<DogTagManager>.instance.constDogtagSubscriptionSeconds;
			return MEJMLNDFDBP.JJBMMICPIIG(1f - (float)constDogtagSubscriptionSeconds / (float)constDogtagSeconds);
		}
	}

	public bool isSubscribed => expireTime > Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public bool trialSubscriptionUsed => data.expireTime > 0;

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
