using UnityEngine;

[AddComponentMenu("NGUI/Tween/Progress Bar Tween")]
internal class TweenProgressBar : UITweener
{
	public float from;

	public float to;

	private UISprite mUiSprite;

	public float fillAmount
	{
		get
		{
			if (mUiSprite != null)
			{
				return mUiSprite.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (mUiSprite != null)
			{
				mUiSprite.fillAmount = value;
			}
		}
	}

	public void Awake()
	{
		mUiSprite = GetComponent<UISprite>();
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		fillAmount = Mathf.Lerp(from, to, factor);
	}

	public static TweenProgressBar Begin(GameObject go, float duration, FloatObject fromAmount, FloatObject toAmount)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(go, duration);
		tweenProgressBar.from = fromAmount.val;
		tweenProgressBar.to = toAmount.val;
		if (duration <= 0f)
		{
			tweenProgressBar.Sample(1f, isFinished: true);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar Begin(GameObject go, float duration, FloatObject toAmount)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(go, duration);
		tweenProgressBar.from = tweenProgressBar.fillAmount;
		tweenProgressBar.to = toAmount.val;
		if (duration <= 0f)
		{
			tweenProgressBar.Sample(1f, isFinished: true);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}
}
