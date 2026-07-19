using UnityEngine;

public class TweenColorTk2d : UITweener
{
	public Color from = Color.white;

	public Color to = Color.white;

	private tk2dSprite mWidget;

	private tk2dTextMesh mWidgetText;

	public Color color
	{
		get
		{
			if (mWidget != null)
			{
				return mWidget.color;
			}
			if (mWidgetText != null)
			{
				return mWidgetText.color;
			}
			return default(Color);
		}
		set
		{
			if (mWidget != null)
			{
				mWidget.color = value;
			}
			if (mWidgetText != null)
			{
				mWidgetText.color = value;
			}
		}
	}

	private void Awake()
	{
		mWidget = GetComponentInChildren<tk2dSprite>();
		mWidgetText = GetComponentInChildren<tk2dTextMesh>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		color = Color.Lerp(from, to, factor);
	}

	public static TweenColorTk2d Begin(GameObject go, float duration, Color color)
	{
		TweenColorTk2d tweenColorTk2d = UITweener.Begin<TweenColorTk2d>(go, duration);
		tweenColorTk2d.from = tweenColorTk2d.color;
		tweenColorTk2d.to = color;
		if (duration <= 0f)
		{
			tweenColorTk2d.Sample(1f, true);
			tweenColorTk2d.enabled = false;
		}
		return tweenColorTk2d;
	}

	public static TweenColorTk2d Begin(GameObject go, float duration, Color from, Color to)
	{
		TweenColorTk2d tweenColorTk2d = UITweener.Begin<TweenColorTk2d>(go, duration);
		tweenColorTk2d.from = from;
		tweenColorTk2d.to = to;
		tweenColorTk2d.Sample(0f, true);
		if (duration <= 0f)
		{
			tweenColorTk2d.Sample(1f, true);
			tweenColorTk2d.enabled = false;
		}
		return tweenColorTk2d;
	}
}
