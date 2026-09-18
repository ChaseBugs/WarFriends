using System;
using UnityEngine;

[RequireComponent(typeof(TweenColor))]
public class BlinkingObject : MonoBehaviour
{
	private int _blinkCount;

	public int TotalBlinkCount = 4;

	public float BlinkSpeed = 0.2f;

	public Color FromColor;

	public Color ToColor;

	public bool setColorAfterDisable = true;

	private Color? mColorBeforeBlink;

	public Action<BlinkingObject> BlinkingFinished;

	public bool ignoreTimeScale;

	private void Awake()
	{
	}

	public void Blink()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, BlinkSpeed, ToColor);
		mColorBeforeBlink = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(OnBlinkFinished));
		tweenColor.method = UITweener.Method.EaseInOut;
		tweenColor.ignoreTimeScale = ignoreTimeScale;
		_blinkCount = 0;
		base.enabled = true;
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
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, BlinkSpeed, FromColor);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(OnBlinkFinished));
			tweenColor.method = UITweener.Method.EaseInOut;
			tweenColor.ignoreTimeScale = ignoreTimeScale;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, BlinkSpeed, ToColor);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(OnBlinkFinished));
			tweenColor2.method = UITweener.Method.EaseInOut;
			tweenColor2.ignoreTimeScale = ignoreTimeScale;
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

	public static BlinkingObject Begin(GameObject obj, Color fromColor, Color toColor, int totalBlinkCount, float speed)
	{
		BlinkingObject blinkingObject = obj.GetComponent<BlinkingObject>() ?? obj.AddComponent<BlinkingObject>();
		blinkingObject.FromColor = fromColor;
		blinkingObject.ToColor = toColor;
		blinkingObject.TotalBlinkCount = totalBlinkCount;
		blinkingObject.BlinkSpeed = speed;
		blinkingObject.enabled = true;
		blinkingObject.Blink();
		return blinkingObject;
	}

	private void OnDisable()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && mColorBeforeBlink.HasValue && setColorAfterDisable)
		{
			TweenColor.Begin(base.gameObject, 0f, mColorBeforeBlink.Value);
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void OnEnable()
	{
	}
}
