using UnityEngine;

public class TweenPanelClipping : UITweener
{
	public Vector4 from = Vector4.one;

	public Vector4 to = Vector4.one;

	private UIPanel mPanel;

	public Vector4 clip
	{
		get
		{
			return mPanel.clipRange;
		}
		set
		{
			mPanel.clipRange = value;
		}
	}

	private void Awake()
	{
		mPanel = GetComponent<UIPanel>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		mPanel.clipRange = from * (1f - factor) + to * factor;
	}

	public static TweenPanelClipping Begin(GameObject go, float duration, Vector4 clip)
	{
		TweenPanelClipping tweenPanelClipping = UITweener.Begin<TweenPanelClipping>(go, duration);
		tweenPanelClipping.from = tweenPanelClipping.clip;
		tweenPanelClipping.to = clip;
		if (duration <= 0f)
		{
			tweenPanelClipping.Sample(1f, isFinished: true);
			tweenPanelClipping.enabled = false;
		}
		return tweenPanelClipping;
	}

	public static TweenPanelClipping Begin(GameObject go, float duration, Vector4 fromCLip, Vector4 toClip)
	{
		TweenPanelClipping tweenPanelClipping = UITweener.Begin<TweenPanelClipping>(go, duration);
		tweenPanelClipping.from = fromCLip;
		tweenPanelClipping.to = toClip;
		if (duration <= 0f)
		{
			tweenPanelClipping.Sample(1f, isFinished: true);
			tweenPanelClipping.enabled = false;
		}
		return tweenPanelClipping;
	}
}
