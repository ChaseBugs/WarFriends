using UnityEngine;

public class InventoryHintText : Core_BaseScript
{
	[Header("Animating Parts")]
	public UISprite rectangle;

	public UISprite arrow;

	public UILabel text;

	private Vector3 mArrowPosition;

	public void Activate(bool shownContent)
	{
		mArrowPosition = arrow.transform.localPosition;
		if (shownContent)
		{
			StartAnimation();
		}
		else
		{
			HideEverything();
		}
	}

	private void HideEverything()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(rectangle.gameObject, 0.01f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = null;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(arrow.gameObject, 0.01f, 0f);
		tweenAlpha2.delay = 0f;
		tweenAlpha2.style = UITweener.Style.Once;
		tweenAlpha2.onFinished = null;
		TweenAlpha tweenAlpha3 = TweenAlpha.Begin(text.gameObject, 0.01f, 0f);
		tweenAlpha3.delay = 0f;
		tweenAlpha3.style = UITweener.Style.Once;
		tweenAlpha3.onFinished = delegate(UITweener tween)
		{
			tween.onFinished = null;
			base.gameObject.SetActive(value: true);
		};
	}

	private void StartAnimation()
	{
		base.gameObject.SetActive(value: true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(rectangle.gameObject, 0.3f, 0f, 0.7f);
		tweenAlpha.delay = 0f;
		tweenAlpha.onFinished = null;
		tweenAlpha.style = UITweener.Style.Once;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(text.gameObject, 0.3f, 0f, 0.7f);
		tweenAlpha2.onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(rectangle.gameObject, 0.3f, new Vector3(0f, -8f, 0f), new Vector3(0f, 10f, 0f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition.Begin(rectangle.gameObject, 0.3f, new Vector3(0f, 0f, 0f)).method = UITweener.Method.EaseOut;
			TweenAlpha.Begin(rectangle.gameObject, 0.3f, 1f);
		};
		float textX = text.transform.localPosition.x;
		TweenPosition tweenPosition2 = TweenPosition.Begin(text.gameObject, 0.3f, new Vector3(textX, -8f, -2f), new Vector3(textX, 10f, -2f));
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = delegate(UITweener tween2)
		{
			tween2.onFinished = null;
			TweenPosition.Begin(text.gameObject, 0.3f, new Vector3(textX, 0f, -2f)).method = UITweener.Method.EaseOut;
			TweenAlpha.Begin(text.gameObject, 0.3f, 1f).onFinished = delegate
			{
				AnimateBlicking();
			};
		};
		TweenAlpha tweenAlpha3 = TweenAlpha.Begin(arrow.gameObject, 0.5f, 0f, 1f);
		tweenAlpha3.delay = 0f;
		tweenAlpha3.onFinished = null;
		tweenAlpha3.style = UITweener.Style.Once;
		TweenPosition tweenPosition3 = TweenPosition.Begin(arrow.gameObject, 0.4f, new Vector3(0f, -150f, 0f), mArrowPosition.ReplaceY(mArrowPosition.y));
		tweenPosition3.method = UITweener.Method.EaseIn;
	}

	private void AnimateBlicking()
	{
		float alpha0 = 0.7f;
		float alpha1 = 1f;
		float duration = 0.3f;
		float t2 = 0.3f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(rectangle.gameObject, duration, alpha0, alpha1);
		tweenAlpha.method = UITweener.Method.EaseOut;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(text.gameObject, duration, alpha0, alpha1);
		tweenAlpha2.method = UITweener.Method.EaseOut;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha3 = TweenAlpha.Begin(rectangle.gameObject, t2, alpha1, alpha0);
			tweenAlpha3.method = UITweener.Method.EaseIn;
			TweenAlpha tweenAlpha4 = TweenAlpha.Begin(text.gameObject, t2, alpha1, alpha0);
			tweenAlpha4.method = UITweener.Method.EaseIn;
			tweenAlpha3.onFinished = delegate
			{
				AnimateBlicking();
			};
		};
	}
}
