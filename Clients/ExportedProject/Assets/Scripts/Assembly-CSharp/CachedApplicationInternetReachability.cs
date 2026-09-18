using UnityEngine;

public class CachedApplicationInternetReachability
{
	private static int mLastFrame = -1;

	private static NetworkReachability mCachedValue;

	public static NetworkReachability internetReachability
	{
		get
		{
			if (mLastFrame != Time.frameCount)
			{
				mLastFrame = Time.frameCount;
				mCachedValue = Application.internetReachability;
			}
			return mCachedValue;
		}
	}
}
