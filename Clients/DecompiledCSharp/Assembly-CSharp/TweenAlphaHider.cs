using UnityEngine;

public class TweenAlphaHider : UITweener
{
	public float from = 1f;

	public float to = 1f;

	private UISimpleHider _ui;

	public UISimpleHider Ui
	{
		get
		{
			if (_ui != null)
			{
				return _ui;
			}
			_ui = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
			return _ui;
		}
	}

	public float alpha
	{
		get
		{
			return Ui.alpha;
		}
		set
		{
			Ui.alpha = value;
		}
	}

	private void Awake()
	{
		_ui = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		alpha = Mathf.Lerp(from, to, factor);
	}

	public static TweenAlphaHider Begin(GameObject go, float duration, float alpha)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(go, duration);
		tweenAlphaHider.from = tweenAlphaHider.alpha;
		tweenAlphaHider.to = alpha;
		if (duration <= 0f)
		{
			tweenAlphaHider.Sample(1f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider Begin(GameObject go, float duration, float alphaFrom, float alphaTo)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(go, duration);
		tweenAlphaHider.from = alphaFrom;
		tweenAlphaHider.to = alphaTo;
		tweenAlphaHider.alpha = alphaFrom;
		if (duration <= 0f)
		{
			tweenAlphaHider.Sample(1f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}
}
