using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/XP Text Counter Tween")]
internal class TweenXPTextCounter : UITweener
{
	public int from;

	public int to;

	public int maxWidth;

	public bool useSound;

	public SoundsManager.SoundsEnum soundType = SoundsManager.SoundsEnum.CounterSoundExperience;

	private UILabel mUiLabel;

	private float mLastSound;

	private float mDefaultScale;

	public int Text
	{
		get
		{
			if (mUiLabel != null)
			{
				int num = 0;
				string s = Regex.Replace(mUiLabel.text, "^\\D*", string.Empty);
				return int.Parse(s, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
			}
			return 0;
		}
		set
		{
			if (mUiLabel != null)
			{
				mUiLabel.text = string.Format("{0} {1}{2}[-]", MiscTools.FormatBigNumber(value), Colours.stringBlue, "XP");
				if (maxWidth > 0)
				{
					MiscTools.SetUILabelRescale(mUiLabel, mDefaultScale, 20f, maxWidth);
				}
			}
		}
	}

	public void Awake()
	{
		mUiLabel = GetComponent<UILabel>();
		if (mUiLabel != null)
		{
			mDefaultScale = mUiLabel.transform.localScale.y;
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

	public static TweenXPTextCounter Begin(GameObject go, float duration, IntObject fromText, IntObject toText)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(go, duration);
		tweenXPTextCounter.from = fromText.val;
		tweenXPTextCounter.to = toText.val;
		tweenXPTextCounter.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenXPTextCounter.Sample(1f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter Begin(GameObject go, float duration, IntObject toText)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(go, duration);
		tweenXPTextCounter.from = tweenXPTextCounter.Text;
		tweenXPTextCounter.to = toText.val;
		tweenXPTextCounter.mLastSound = 0f;
		if (duration <= 0f)
		{
			tweenXPTextCounter.Sample(1f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}
}
