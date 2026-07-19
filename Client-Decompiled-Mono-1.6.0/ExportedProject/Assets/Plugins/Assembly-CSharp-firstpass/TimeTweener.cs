using UnityEngine;

public class TimeTweener : UITweener
{
	private float from = 1f;

	private float to = 1f;

	private const float fixedTime = 0.02f;

	protected override void OnUpdate(float factor, bool isFinished)
	{
		Time.timeScale = Mathf.Lerp(from, to, factor);
	}

	public static TimeTweener Begin(GameObject obj, float duration, float from, float to)
	{
		TimeTweener timeTweener = UITweener.Begin<TimeTweener>(obj, duration);
		timeTweener.from = from;
		timeTweener.to = to;
		if (duration <= 0f)
		{
			timeTweener.Sample(1f, true);
			timeTweener.enabled = false;
		}
		return timeTweener;
	}

	public TimeTweener Begin(float duration, float from, float to)
	{
		Begin(duration);
		this.from = from;
		this.to = to;
		if (duration <= 0f)
		{
			Sample(1f, true);
			base.enabled = false;
		}
		return this;
	}

	public void SetTimeScale(float value)
	{
		Time.timeScale = value;
	}
}
