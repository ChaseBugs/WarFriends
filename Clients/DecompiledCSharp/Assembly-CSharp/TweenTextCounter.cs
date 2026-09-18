using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Text Counter Tween")]
internal class TweenTextCounter : UITweener
{
	public int from;

	public int to;

	public bool useSound;

	public SoundsManager.SoundsEnum soundType = SoundsManager.SoundsEnum.CounterSoundExperience;

	private string mPrefix = string.Empty;

	private UILabel mUiLabel;

	private float mLastSound;

	public int Text
	{
		get
		{
			if (mUiLabel != null)
			{
				int result = 0;
				if (int.TryParse(Regex.Replace(mUiLabel.text, "[.,]*", string.Empty), out result))
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
			return 0;
		}
		set
		{
			if (mUiLabel != null)
			{
				mUiLabel.text = ((value < 0) ? MiscTools.FormatBigNumber(value) : (mPrefix + MiscTools.FormatBigNumber(value)));
			}
		}
	}

	public void Awake()
	{
		mUiLabel = GetComponent<UILabel>();
		int result = 0;
		if (!int.TryParse(mUiLabel.text, out result))
		{
			mPrefix = Regex.Replace(mUiLabel.text, "[0-9.,]*", string.Empty);
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (mUiLabel != null)
		{
			string text = mUiLabel.text;
			Text = (int)Mathf.Lerp(from, to, factor);
			if (useSound && duration * factor > mLastSound + 0.065f && text != mUiLabel.text)
			{
				SoundsManager.Instance.PlaySound(soundType);
				mLastSound = duration * factor;
			}
		}
	}

	public static TweenTextCounter Begin(GameObject go, float duration, IntObject fromText, IntObject toText)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(go, duration);
		tweenTextCounter.from = fromText.val;
		tweenTextCounter.to = toText.val;
		tweenTextCounter.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenTextCounter.Sample(1f, isFinished: true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	public static TweenTextCounter Begin(GameObject go, float duration, IntObject toText)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(go, duration);
		tweenTextCounter.from = tweenTextCounter.Text;
		tweenTextCounter.to = toText.val;
		tweenTextCounter.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenTextCounter.Sample(1f, isFinished: true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}
}
