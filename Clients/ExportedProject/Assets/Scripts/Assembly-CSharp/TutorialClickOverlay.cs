using System;
using UnityEngine;

public class TutorialClickOverlay : GuiElementSingle<TutorialClickOverlay>
{
	public Transform top;

	public Transform left;

	public Transform right;

	public Transform down;

	public Transform border;

	public GameObject animationBorder;

	public UIRoot root;

	private Transform mTransform;

	private Vector3 addSize = new Vector3(32f, 32f, 0f);

	private float mAlpha;

	private float mOriginalAlpha;

	private TweenAlpha hideTween;

	public void SetByButton(GameObject buttonGameObject, bool showBlueOverlay = true)
	{
		BoxCollider component = buttonGameObject.GetComponent<BoxCollider>();
		SetAndShow(buttonGameObject.transform.position, component.size, component.center, showBlueOverlay);
	}

	public void SetByButton(UIButton button, bool showBlueOverlay = true)
	{
		BoxCollider component = button.GetComponent<BoxCollider>();
		SetAndShow(button.transform.position, component.size, component.center, showBlueOverlay);
	}

	public void SetAndShow(Vector3 globalPos, Vector3 size, bool showBlueOverlay = true)
	{
		SetAndShow(globalPos, size, Vector3.zero, showBlueOverlay);
	}

	private void SetAndShow(Vector3 globalPos, Vector3 size, Vector3 posLocalDiff, bool showBlueOverlay)
	{
		if (mTransform == null)
		{
			mOriginalAlpha = top.GetComponent<UIWidget>().alpha;
			mTransform = base.transform;
		}
		mAlpha = ((!showBlueOverlay) ? 0f : mOriginalAlpha);
		mTransform.position = globalPos;
		Vector3 localPosition = mTransform.localPosition;
		localPosition.z = 0f;
		localPosition.x += posLocalDiff.x;
		localPosition.y += posLocalDiff.y;
		mTransform.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = size.x;
		one.y = ((float)root.activeHeight - size.y) * 0.5f - localPosition.y;
		zero.y = (one.y + size.y) * 0.5f;
		top.localPosition = zero;
		top.localScale = one;
		one.y = ((float)root.activeHeight - size.y) * 0.5f + localPosition.y;
		zero.y = (0f - (one.y + size.y)) * 0.5f;
		down.localPosition = zero;
		down.localScale = one;
		one.y = root.activeHeight;
		one.x = (root.activeWidth - size.x) * 0.5f + localPosition.x;
		zero.x = (0f - (one.x + size.x)) * 0.5f;
		zero.y = 0f - localPosition.y;
		left.localPosition = zero;
		left.localScale = one;
		one.x = (root.activeWidth - size.x) * 0.5f - localPosition.x;
		zero.x = (one.x + size.x) * 0.5f;
		right.localPosition = zero;
		right.localScale = one;
		border.localScale = size + addSize;
		animationBorder.transform.localScale = border.localScale;
		animationBorder.SetActive(value: false);
		bool flag = !base.gameObject.activeSelf;
		if (hideTween != null)
		{
			flag = true;
		}
		if (flag)
		{
			TweenAlpha.Begin(top.gameObject, 0.45f, 0f, mAlpha).alpha = 0f;
			TweenAlpha.Begin(down.gameObject, 0.45f, 0f, mAlpha).alpha = 0f;
			TweenAlpha.Begin(left.gameObject, 0.45f, 0f, mAlpha).alpha = 0f;
			TweenAlpha.Begin(right.gameObject, 0.45f, 0f, mAlpha).alpha = 0f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(border.gameObject, 0.45f, 0f, 1f);
			tweenAlpha.alpha = 0f;
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.onFinished = BorderBlick;
			hideTween = null;
			base.gameObject.SetActive(value: true);
		}
		else
		{
			BorderBlick(null);
		}
		border.gameObject.SetActive(!Singleton<GameController>.instance.gameIsRunning);
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
	}

	private void BorderBlick(UITweener tw)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(border.gameObject, 0.6f, 1f, 0.6f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.NumOfRepetitions = 0;
	}

	public void Hide(float dur = 0.1f)
	{
		if (base.gameObject.activeSelf)
		{
			StopBorderAnimation();
			TweenAlpha.Begin(top.gameObject, dur, 0f);
			TweenAlpha.Begin(down.gameObject, dur, 0f);
			TweenAlpha.Begin(left.gameObject, dur, 0f);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(border.gameObject, dur, 0f);
			tweenAlpha.style = UITweener.Style.Once;
			hideTween = TweenAlpha.Begin(right.gameObject, dur, 0f);
			TweenAlpha tweenAlpha2 = hideTween;
			tweenAlpha2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha2.onFinished, (UITweener.OnFinished)delegate
			{
				animationBorder.SetActive(value: false);
				base.gameObject.SetActive(value: false);
			});
		}
	}

	public void StartBorderAnimation()
	{
		animationBorder.SetActive(value: true);
		BorderTweenLoop(TweenScale.Begin(animationBorder, 0f, border.transform.localScale));
	}

	private void BorderTweenLoop(UITweener tween)
	{
		Vector3 toScale = border.transform.localScale.MultiplyXY(2f);
		TweenScale.Begin(animationBorder, 0.6f, border.transform.localScale, toScale);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(animationBorder, 0.6f, 1f, 0f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = BorderTweenLoop;
	}

	public void StopBorderAnimation()
	{
		if (animationBorder.activeSelf)
		{
			TweenScale.Begin(animationBorder, 0f, border.transform.localScale);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(animationBorder, 0.05f, 0f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = null;
		}
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}
}
