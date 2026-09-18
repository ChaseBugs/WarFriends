using System;
using UnityEngine;

public class BlinkingObjectMultiple : MonoBehaviour
{
	public int _blinkCount;

	public int TotalBlinkCount = 4;

	public float BlinkSpeed = 0.2f;

	public float from;

	public float to;

	public Action<BlinkingObjectMultiple> BlinkingFinished;

	public void Blink()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(base.gameObject, BlinkSpeed, from, to);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OnBlinkFinished));
		tweenAlphaHider.method = UITweener.Method.EaseInOut;
		_blinkCount = 0;
	}

	private void OnBlinkFinished(UITweener tween)
	{
		if (!base.enabled)
		{
			return;
		}
		if (_blinkCount == TotalBlinkCount)
		{
			tween.onFinished = null;
			BlinkingEnd();
			return;
		}
		if (_blinkCount % 2 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(base.gameObject, BlinkSpeed, from);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OnBlinkFinished));
			tweenAlphaHider.method = UITweener.Method.EaseInOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.Begin(base.gameObject, BlinkSpeed, to);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(OnBlinkFinished));
			tweenAlphaHider2.method = UITweener.Method.EaseInOut;
		}
		_blinkCount++;
	}

	private void BlinkingEnd()
	{
		if (BlinkingFinished != null)
		{
			BlinkingFinished(this);
		}
	}

	public static BlinkingObjectMultiple Begin(GameObject obj, float from, float to, int totalBlinkCount, float speed)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = obj.GetComponent<BlinkingObjectMultiple>() ?? obj.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.from = from;
		blinkingObjectMultiple.to = to;
		blinkingObjectMultiple.TotalBlinkCount = totalBlinkCount;
		blinkingObjectMultiple.BlinkSpeed = speed;
		blinkingObjectMultiple.Blink();
		return blinkingObjectMultiple;
	}

	private void OnDisable()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
	}
}
