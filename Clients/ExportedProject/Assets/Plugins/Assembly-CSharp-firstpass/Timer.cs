using UnityEngine;

public class Timer
{
	private float mUpdateInterval;

	private float mLastUpdate;

	public Timer(float updateInterval)
	{
		mUpdateInterval = updateInterval;
	}

	public bool Update()
	{
		if (Time.realtimeSinceStartup > mLastUpdate + mUpdateInterval)
		{
			mLastUpdate = Time.realtimeSinceStartup;
			return true;
		}
		return false;
	}
}
