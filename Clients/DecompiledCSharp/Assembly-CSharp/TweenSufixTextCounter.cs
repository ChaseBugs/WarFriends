using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Suffix Text Counter Tween")]
internal class TweenSufixTextCounter : UITweener
{
	public int from;

	public int to;

	public bool useSound;

	public SoundsManager.SoundsEnum soundType = SoundsManager.SoundsEnum.CounterSoundExperience;

	private string mSufix = string.Empty;

	private UILabel mUiLabel;

	private float mLastSound;

	public int Text
	{
		get
		{
			if (mUiLabel != null)
			{
				if (int.TryParse(Regex.Replace(mUiLabel.text, "[.,]*", string.Empty), out var result))
				{
					return result;
				}
				mSufix = Regex.Replace(mUiLabel.text, "[0-9.,]*", string.Empty);
				string s = Regex.Replace(mUiLabel.text, "\\D*$", string.Empty);
				return int.Parse(s);
			}
			return 0;
		}
		set
		{
			if (mUiLabel != null)
			{
				mUiLabel.text = MiscTools.FormatBigNumber(value) + mSufix;
			}
		}
	}

	public void Awake()
	{
		mUiLabel = GetComponent<UILabel>();
		if (!int.TryParse(mUiLabel.text, out var _))
		{
			mSufix = Regex.Replace(mUiLabel.text, "[0-9.,]*", string.Empty);
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

	public static TweenSufixTextCounter Begin(GameObject go, float duration, IntObject fromText, IntObject toText)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(go, duration);
		tweenSufixTextCounter.from = fromText.val;
		tweenSufixTextCounter.to = toText.val;
		tweenSufixTextCounter.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenSufixTextCounter.Sample(1f, isFinished: true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter Begin(GameObject go, float duration, IntObject toText)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(go, duration);
		tweenSufixTextCounter.from = tweenSufixTextCounter.Text;
		tweenSufixTextCounter.to = toText.val;
		tweenSufixTextCounter.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenSufixTextCounter.Sample(1f, isFinished: true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}
}
