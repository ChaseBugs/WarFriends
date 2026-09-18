using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Scale Touch")]
public class UIButtonScaleTouch : MonoBehaviour
{
	public Transform tweenTarget;

	public Vector3 hover = new Vector3(1.1f, 1.1f, 1.1f);

	public Vector3 pressed = new Vector3(1.05f, 1.05f, 1.05f);

	public float duration = 0.2f;

	private Vector3 mScale;

	private bool mStarted;

	private bool mHighlighted;

	private bool mIsPressed;

	private bool mSomething;

	private void Start()
	{
		if (!mStarted)
		{
			mStarted = true;
			if (tweenTarget == null)
			{
				tweenTarget = base.transform;
			}
			mScale = tweenTarget.localScale;
		}
	}

	private void OnEnable()
	{
		if (mStarted && mHighlighted)
		{
			OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	private void OnDisable()
	{
		if (tweenTarget != null)
		{
			TweenScale component = tweenTarget.GetComponent<TweenScale>();
			if (component != null)
			{
				component.scale = mScale;
				component.enabled = false;
			}
		}
	}

	private void Init()
	{
		if (tweenTarget == null)
		{
			tweenTarget = base.transform;
		}
		mScale = tweenTarget.localScale;
	}

	public virtual void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!mStarted)
			{
				Start();
			}
			mIsPressed = isPressed;
			if (isPressed)
			{
				TweenScale tweenScale = TweenScale.Begin(tweenTarget.gameObject, duration, Vector3.Scale(mScale, pressed));
				tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, new UITweener.OnFinished(OnPressedFinished));
				tweenScale.method = UITweener.Method.EaseInOut;
				mSomething = true;
			}
			else if (!mSomething)
			{
				TweenScale.Begin(tweenTarget.gameObject, duration, mScale).method = UITweener.Method.EaseInOut;
			}
		}
	}

	private void OnPressedFinished(UITweener tween)
	{
		if (mSomething && !mIsPressed)
		{
			TweenScale.Begin(tweenTarget.gameObject, duration, mScale).method = UITweener.Method.EaseInOut;
		}
		mSomething = false;
	}

	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!mStarted)
			{
				Start();
			}
			mHighlighted = isOver;
		}
	}
}
