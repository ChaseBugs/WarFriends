using UnityEngine;

public class WaitForRealSeconds : CoroutineReturn
{
	private float mFinishTime;

	public override bool finished => Time.realtimeSinceStartup > mFinishTime;

	public WaitForRealSeconds(float timeToWait)
	{
		mFinishTime = Time.realtimeSinceStartup + timeToWait;
	}
}
