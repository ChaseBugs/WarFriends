using UnityEngine;

public class TweenAlphaTk2d : UITweener
{
	public float from = 1f;

	public float to = 1f;

	private tk2dBaseSprite mWidget;

	private tk2dTextMesh mWidgetText;

	private TextMesh mText;

	private TextMeshWithStroke mTextWithStroke;

	public float alpha
	{
		get
		{
			if (mWidget != null)
			{
				return mWidget.color.a;
			}
			if (mWidgetText != null)
			{
				return mWidgetText.color.a;
			}
			if (mText != null)
			{
				return mText.color.a;
			}
			if (mTextWithStroke != null)
			{
				return mTextWithStroke.alpha;
			}
			return 0f;
		}
		set
		{
			if (mWidget != null)
			{
				mWidget.color = new Color(mWidget.color.r, mWidget.color.g, mWidget.color.b, value);
			}
			if (mWidgetText != null)
			{
				mWidgetText.color = new Color(mWidgetText.color.r, mWidgetText.color.g, mWidgetText.color.b, value);
			}
			if (mText != null)
			{
				mText.color = new Color(mText.color.r, mText.color.g, mText.color.b, value);
			}
			if (mTextWithStroke != null)
			{
				mTextWithStroke.alpha = value;
			}
		}
	}

	private void Awake()
	{
		mWidget = GetComponentInChildren<tk2dBaseSprite>();
		mWidgetText = GetComponentInChildren<tk2dTextMesh>();
		mText = GetComponentInChildren<TextMesh>();
		mTextWithStroke = GetComponentInChildren<TextMeshWithStroke>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		alpha = Mathf.Lerp(from, to, factor);
	}

	public static TweenAlphaTk2d Begin(GameObject go, float duration, float alpha)
	{
		TweenAlphaTk2d tweenAlphaTk2d = UITweener.Begin<TweenAlphaTk2d>(go, duration);
		tweenAlphaTk2d.from = tweenAlphaTk2d.alpha;
		tweenAlphaTk2d.to = alpha;
		if (duration <= 0f)
		{
			tweenAlphaTk2d.Sample(1f, true);
			tweenAlphaTk2d.enabled = false;
		}
		return tweenAlphaTk2d;
	}

	public static TweenAlphaTk2d Begin(GameObject go, float duration, float fromAlpha, float toAlpha)
	{
		TweenAlphaTk2d tweenAlphaTk2d = UITweener.Begin<TweenAlphaTk2d>(go, duration);
		tweenAlphaTk2d.from = fromAlpha;
		tweenAlphaTk2d.to = toAlpha;
		tweenAlphaTk2d.Sample(0f, true);
		if (duration <= 0f)
		{
			tweenAlphaTk2d.Sample(1f, true);
			tweenAlphaTk2d.enabled = false;
		}
		return tweenAlphaTk2d;
	}
}
