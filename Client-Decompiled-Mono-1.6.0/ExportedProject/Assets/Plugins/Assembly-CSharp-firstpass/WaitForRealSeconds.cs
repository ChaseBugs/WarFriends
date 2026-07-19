using UnityEngine;

public class WaitForRealSeconds : CoroutineReturn
{
	private float mFinishTime;

	public override bool finished
	{
		get
		{
			return Time.realtimeSinceStartup > mFinishTime;
		}
	}

	public WaitForRealSeconds(float timeToWait)
	{
		mFinishTime = Time.realtimeSinceStartup + timeToWait;
	}
}
