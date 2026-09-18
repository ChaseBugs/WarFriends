using System;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Counter Special")]
public class TweenCounterSpecial : UITweener
{
	public int from;

	public int to;

	public bool useSound;

	public SoundsManager.SoundsEnum soundType = SoundsManager.SoundsEnum.CounterSoundExperience;

	private UILabel mUiLabel;

	private float mLastSound;

	public int text
	{
		get
		{
			if (mUiLabel != null)
			{
				if (int.TryParse(Regex.Replace(mUiLabel.text, "[.,]*", string.Empty), out var result))
				{
					return result;
				}
				string s = Regex.Replace(mUiLabel.text, "^\\D*", string.Empty);
				return int.Parse(s, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
			}
			return 0;
		}
		set
		{
			if (mUiLabel != null)
			{
				if (this.SetText != null)
				{
					this.SetText(mUiLabel, value);
				}
				else
				{
					mUiLabel.text = MiscTools.FormatBigNumber(value);
				}
			}
		}
	}

	public event Action<UILabel, int> SetText;

	public void Awake()
	{
		mUiLabel = GetComponent<UILabel>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (mUiLabel != null)
		{
			string text = mUiLabel.text;
			this.text = (int)Mathf.Lerp(from, to, factor);
			if (useSound && duration * factor > mLastSound + 0.065f && text != mUiLabel.text)
			{
				SoundsManager.Instance.PlaySound(soundType);
				mLastSound = duration * factor;
			}
		}
	}

	public static TweenCounterSpecial Begin(GameObject go, float duration, IntObject fromText, IntObject toText)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(go, duration);
		tweenCounterSpecial.from = fromText.val;
		tweenCounterSpecial.to = toText.val;
		tweenCounterSpecial.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenCounterSpecial.Sample(1f, isFinished: true);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	public static TweenCounterSpecial Begin(GameObject go, float duration, IntObject toText)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(go, duration);
		tweenCounterSpecial.from = tweenCounterSpecial.text;
		tweenCounterSpecial.to = toText.val;
		tweenCounterSpecial.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenCounterSpecial.Sample(1f, isFinished: true);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}
}
