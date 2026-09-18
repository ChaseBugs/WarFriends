using System;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Time Counter Tween")]
internal class TweenTimeCounter : UITweener
{
	public int from;

	public int to;

	private UILabel mUiLabel;

	public int Text
	{
		get
		{
			if (mUiLabel == null)
			{
				return 0;
			}
			string[] array = mUiLabel.text.Split(':');
			if (array.Length < 2)
			{
				return 0;
			}
			if (int.TryParse(array[0], out var result) && int.TryParse(array[1], out var result2))
			{
				return result * 60 + result2;
			}
			return int.Parse(Regex.Replace(array[0], "\\D*", string.Empty)) * 60 + int.Parse(Regex.Replace(array[1], "\\D*", string.Empty));
		}
		set
		{
			if (mUiLabel != null)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(value);
				mUiLabel.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
			}
		}
	}

	public void Awake()
	{
		mUiLabel = GetComponent<UILabel>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		Text = (int)Mathf.Lerp(from, to, factor);
	}

	public static TweenTimeCounter Begin(GameObject go, float duration, IntObject fromText, IntObject toText)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(go, duration);
		tweenTimeCounter.from = fromText.val;
		tweenTimeCounter.to = toText.val;
		if (duration <= 0f)
		{
			tweenTimeCounter.Sample(1f, isFinished: true);
			tweenTimeCounter.enabled = false;
		}
		return tweenTimeCounter;
	}

	public static TweenTimeCounter Begin(GameObject go, float duration, IntObject toText)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(go, duration);
		tweenTimeCounter.from = tweenTimeCounter.Text;
		tweenTimeCounter.to = toText.val;
		if (duration <= 0f)
		{
			tweenTimeCounter.Sample(1f, isFinished: true);
			tweenTimeCounter.enabled = false;
		}
		return tweenTimeCounter;
	}
}
