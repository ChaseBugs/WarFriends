using UnityEngine;

public class WaitForRealSecondsWithoutPause : CoroutineReturn
{
	private float finishTime;

	public override bool finished
	{
		get
		{
			return Time.unscaledTime > finishTime;
		}
	}

	public WaitForRealSecondsWithoutPause(float timeToWait)
	{
		finishTime = Time.unscaledTime + timeToWait;
	}
}
