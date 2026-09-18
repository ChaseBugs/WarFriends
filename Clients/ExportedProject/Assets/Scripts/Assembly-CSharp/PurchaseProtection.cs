using System.Collections.Generic;

public class PurchaseProtection : Singleton<PurchaseProtection>
{
	private bool mDogtagProgress;

	private List<string> mVipInProgress;

	private List<string> mLootboxInProgress;

	public bool dogtagRefillInProgress => mDogtagProgress;

	public void RefillingDogtags()
	{
		mDogtagProgress = true;
	}

	public void BuyingLootboxes(string id)
	{
		if (!mLootboxInProgress.Contains(id))
		{
			mLootboxInProgress.Add(id);
		}
	}

	public void LootboxResponseCame(string id)
	{
		if (mLootboxInProgress.Contains(id))
		{
			mLootboxInProgress.Remove(id);
		}
	}

	public bool IsLootboxPurchasing(string id)
	{
		return mLootboxInProgress.Contains(id);
	}

	public bool IsAnyLootboxPurchasing()
	{
		return mLootboxInProgress.Count > 0;
	}

	public void BuyingVIP(string id)
	{
		if (!mVipInProgress.Contains(id))
		{
			mVipInProgress.Add(id);
		}
	}

	public void VIPResponseCame(string id)
	{
		if (mVipInProgress.Contains(id))
		{
			mVipInProgress.Remove(id);
		}
	}

	public bool IsVIPPurchasing(string id)
	{
		return mVipInProgress.Contains(id);
	}

	public bool IsAnyVIPPurchasing()
	{
		return mVipInProgress.Count > 0;
	}

	protected override void Awake()
	{
		base.Awake();
		Initialize();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
	}

	private void Initialize()
	{
		mVipInProgress = new List<string>();
		mLootboxInProgress = new List<string>();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.RefillDogtags)
		{
			mDogtagProgress = false;
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (action == DatabaseAction.RefillDogtags)
		{
			mDogtagProgress = false;
		}
	}

	private void OnAfterPlayerDataLoaded()
	{
		mDogtagProgress = false;
		mVipInProgress.Clear();
		mLootboxInProgress.Clear();
	}
}
