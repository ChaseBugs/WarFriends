using UnityEngine;

public class TweenAlpha : UITweener
{
	public float from;

	public float to;

	private UIWidget mWidget;

	private UIPanel mPanel;

	public float alpha
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
	}

	public static TweenAlpha Begin(GameObject go, float duration, float alpha)
	{
		return null;
	}

	public static TweenAlpha Begin(GameObject go, float duration, float fromAlpha, float toAlpha)
	{
		return null;
	}
}
