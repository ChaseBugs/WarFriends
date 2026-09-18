using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Text Long Counter Tween")]
internal class TweenTextCounterLong : UITweener
{
	public long from;

	public long to;

	public bool useSound;

	public SoundsManager.SoundsEnum soundType = SoundsManager.SoundsEnum.CounterSoundExperience;

	private string mPrefix = string.Empty;

	private UILabel mUiLabel;

	private float mLastSound;

	public long Text
	{
		get
		{
			if (mUiLabel != null)
			{
				long result = 0L;
				if (long.TryParse(Regex.Replace(mUiLabel.text, "[.,]*", string.Empty), out result))
				{
					if (mUiLabel.text.ToCharArray()[0] == '+')
					{
						mPrefix = "+";
					}
					return result;
				}
				mPrefix = Regex.Replace(mUiLabel.text, "[0-9.,]*", string.Empty);
				string s = Regex.Replace(mUiLabel.text, "^\\D*", string.Empty);
				return int.Parse(s, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
			}
			return 0L;
		}
		set
		{
			if (mUiLabel != null)
			{
				mUiLabel.text = ((value < 0) ? MiscTools.FormatBigNumberLong(value) : (mPrefix + MiscTools.FormatBigNumberLong(value)));
			}
		}
	}

	public void Awake()
	{
		mUiLabel = GetComponent<UILabel>();
		long result = 0L;
		if (!long.TryParse(mUiLabel.text, out result))
		{
			mPrefix = Regex.Replace(mUiLabel.text, "[0-9.,]*", string.Empty);
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (mUiLabel != null)
		{
			string text = mUiLabel.text;
			Text = (long)Mathf.Lerp(from, to, factor);
			if (useSound && duration * factor > mLastSound + 0.065f && text != mUiLabel.text)
			{
				SoundsManager.Instance.PlaySound(soundType);
				mLastSound = duration * factor;
			}
		}
	}

	public static TweenTextCounterLong Begin(GameObject go, float duration, LongObject fromText, LongObject toText)
	{
		TweenTextCounterLong tweenTextCounterLong = UITweener.Begin<TweenTextCounterLong>(go, duration);
		tweenTextCounterLong.from = fromText.val;
		tweenTextCounterLong.to = toText.val;
		tweenTextCounterLong.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenTextCounterLong.Sample(1f, isFinished: true);
			tweenTextCounterLong.enabled = false;
		}
		return tweenTextCounterLong;
	}

	public static TweenTextCounterLong Begin(GameObject go, float duration, LongObject toText)
	{
		TweenTextCounterLong tweenTextCounterLong = UITweener.Begin<TweenTextCounterLong>(go, duration);
		tweenTextCounterLong.from = tweenTextCounterLong.Text;
		tweenTextCounterLong.to = toText.val;
		tweenTextCounterLong.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenTextCounterLong.Sample(1f, isFinished: true);
			tweenTextCounterLong.enabled = false;
		}
		return tweenTextCounterLong;
	}
}
