using UnityEngine;

public class TimeTweener : UITweener
{
	private float from;

	private float to;

	private const float fixedTime = 0.02f;

	protected override void OnUpdate(float factor, bool isFinished)
	{
	}

	public static TimeTweener Begin(GameObject obj, float duration, float from, float to)
	{
		return null;
	}

	public TimeTweener Begin(float duration, float from, float to)
	{
		return null;
	}

	public void SetTimeScale(float value)
	{
	}
}
