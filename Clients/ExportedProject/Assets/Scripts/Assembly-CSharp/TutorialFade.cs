using System;
using UnityEngine;

public class TutorialFade : GuiElementSingle<TutorialFade>
{
	public Transform top;

	public Transform left;

	public Transform right;

	public Transform down;

	public UIRoot root;

	private Transform mTransform;

	private float mOriginalAlpha;

	public Vector3 position;

	public Vector3 localPosition;

	public Vector3 size;

	public bool show;

	public bool hide;

	protected override void Update()
	{
		base.Update();
		if (show)
		{
			show = false;
			SetAndShow(base.transform.position, size, localPosition);
		}
		if (hide)
		{
			hide = false;
			Hide();
		}
	}

	public void SetAndShow(Vector3 globalPos, Vector3 size, Vector3 posLocalDiff)
	{
		if (mTransform == null)
		{
			mOriginalAlpha = top.GetComponent<UIWidget>().alpha;
			mTransform = base.transform;
		}
		mTransform.position = globalPos;
		Vector3 vector = mTransform.localPosition;
		vector.z = 0f;
		vector.x += posLocalDiff.x;
		vector.y += posLocalDiff.y;
		mTransform.localPosition = vector;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = size.x;
		one.y = ((float)root.activeHeight - size.y) * 0.5f - vector.y;
		zero.y = (one.y + size.y) * 0.5f;
		top.localPosition = zero;
		top.localScale = one;
		one.y = ((float)root.activeHeight - size.y) * 0.5f + vector.y;
		zero.y = (0f - (one.y + size.y)) * 0.5f;
		down.localPosition = zero;
		down.localScale = one;
		one.y = root.activeHeight;
		one.x = (root.activeWidth - size.x) * 0.5f + vector.x;
		zero.x = (0f - (one.x + size.x)) * 0.5f;
		zero.y = 0f - vector.y;
		left.localPosition = zero;
		left.localScale = one;
		one.x = (root.activeWidth - size.x) * 0.5f - vector.x;
		zero.x = (one.x + size.x) * 0.5f;
		right.localPosition = zero;
		right.localScale = one;
		TweenAlpha.Begin(top.gameObject, 0.45f, 0f, mOriginalAlpha);
		TweenAlpha.Begin(down.gameObject, 0.45f, 0f, mOriginalAlpha);
		TweenAlpha.Begin(left.gameObject, 0.45f, 0f, mOriginalAlpha);
		TweenAlpha.Begin(right.gameObject, 0.45f, 0f, mOriginalAlpha);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		TweenAlpha.Begin(top.gameObject, 0.1f, 0f);
		TweenAlpha.Begin(down.gameObject, 0.1f, 0f);
		TweenAlpha.Begin(left.gameObject, 0.1f, 0f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(right.gameObject, 0.1f, 0f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			base.gameObject.SetActive(value: false);
		});
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}
}
