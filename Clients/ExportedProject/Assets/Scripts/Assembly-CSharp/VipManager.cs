using System;
using Google2u;
using UnityEngine;

public class VipManager : Singleton<VipManager>
{
	private float mVipWarbucksMultiplier;

	private float mVipGoldMultiplier;

	private float mVipXpMultiplier;

	private int mVipDogtags;

	private bool mLastVipStatus;

	public int vipExpiration { get; set; }

	public int vipStart { get; set; }

	public int numberOfVIPDogtags
	{
		get
		{
			if (mVipDogtags < 1)
			{
				mVipDogtags = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipDogtags).FLOATVALUE;
			}
			return mVipDogtags;
		}
	}

	public float vipWarbucksMultiplier
	{
		get
		{
			if (Math.Abs(mVipWarbucksMultiplier) < 0.01f)
			{
				mVipWarbucksMultiplier = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipWarbucksMultiplier).FLOATVALUE;
			}
			return mVipWarbucksMultiplier;
		}
	}

	public float vipGoldMultiplier
	{
		get
		{
			if (Math.Abs(mVipGoldMultiplier) < 0.01f)
			{
				mVipGoldMultiplier = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipGoldMultiplier).FLOATVALUE;
			}
			return mVipGoldMultiplier;
		}
	}

	public float vipXpMultiplier
	{
		get
		{
			if (Math.Abs(mVipXpMultiplier) < 0.01f)
			{
				mVipXpMultiplier = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipExperienceMultiplier).FLOATVALUE;
			}
			return mVipXpMultiplier;
		}
	}

	public event Action<bool> VipStatusChanged;

	protected void Update()
	{
		if (Singleton<BeanstalkServerManager>.instance == null || !Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
			return;
		bool flag = IsVipActive();
		if (mLastVipStatus != flag)
		{
			Debug.Log("Vip status changed!");
			mLastVipStatus = flag;
			if (this.VipStatusChanged != null)
			{
				this.VipStatusChanged(flag);
			}
			if (!flag)
			{
				Singleton<BeanstalkServerManager>.instance.OnVipExpired();
			}
		}
	}

	internal bool IsVipActive()
	{
		return vipExpiration > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public void LoadNewPlayer()
	{
		mLastVipStatus = IsVipActive();
		mVipWarbucksMultiplier = 0f;
		mVipGoldMultiplier = 0f;
		mVipDogtags = 0;
	}
}
