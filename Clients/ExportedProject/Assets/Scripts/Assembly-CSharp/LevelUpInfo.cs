using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpInfo : Core_BaseScript
{
	[Header("-Core")]
	public UISprite border;

	public UISprite progress;

	public UISprite[] icons;

	public UILabel label;

	private TweenAnimator mAnimator;

	private Vector3 mBorderOriginalSize = new Vector3(400f, 68f, 1f);

	private Vector3 mBorderBigSize = new Vector3(570f, 97f, 1f);

	private Vector3 mBorderSmallSize = new Vector3(320f, 54f, 1f);

	private Vector3 mLabelOriginalPosition = new Vector3(6f, -3f, -1f);

	private Vector3 mLabelUpPosition = new Vector3(6f, 10f, -1f);

	private Vector3 mLabelDownPosition = new Vector3(6f, -31f, -1f);

	private FloatObject mZeroFill = new FloatObject(0f);

	private FloatObject mActualFill = new FloatObject(0f);

	private FloatObject mAnimationBiggestFill = new FloatObject(0f);

	private Vector3 mIconOriginalSize;

	private Vector3 mIconSmallSize;

	private Vector3 mIconDoubleSize;

	private Vector3 mIconTrippleSize;

	public void InitControls()
	{
		SetUpIconScales();
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		AddInfoAnimations();
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(OnTweenFinished));
	}

	private void SetUpIconScales()
	{
		icons[0].MakePixelPerfect();
		mIconOriginalSize = icons[0].transform.localScale;
		mIconSmallSize = (0.5f * mIconOriginalSize).ReplaceZ(1f);
		mIconDoubleSize = (2f * mIconOriginalSize).ReplaceZ(1f);
		mIconTrippleSize = (3f * mIconOriginalSize).ReplaceZ(1f);
	}

	public void InitGuiValues(float fillTo)
	{
		mAnimator.FinishTweens();
		mActualFill.val = Mathf.Clamp01(fillTo);
		mAnimationBiggestFill.val = Mathf.Clamp01(mActualFill.val + 0.1f);
		border.transform.localScale = mBorderBigSize;
		label.transform.localPosition = mLabelDownPosition;
		progress.fillAmount = 0f;
		icons[0].transform.localScale = mIconSmallSize;
		icons[1].transform.localScale = mIconOriginalSize;
		border.alpha = 0f;
		progress.alpha = 0f;
		label.alpha = 0f;
		icons[0].alpha = 0f;
		icons[1].alpha = 0f;
	}

	public void PlayAnimation(float delayed = 0f)
	{
		mAnimator.allTweens[0].delay = Mathf.Clamp(delayed, 0f, 10f);
		mAnimator.PlayTweens();
	}

	public void DebugRecreateAnimations()
	{
		mAnimator.allTweens.Clear();
		AddInfoAnimations();
	}

	private void AddInfoAnimations()
	{
		float num = 1f / (float)GuiElementSingle<LevelUpDialog>.instance.fps;
		mAnimator.AddTween(0, TweenAnimator.TweenType.Alpha, border.gameObject, 0.0001f, 0f, 0f, -1, 0f);
		mAnimator.AddTween(1, TweenAnimator.TweenType.Scale, border.gameObject, num * 6f, mBorderSmallSize, 0f, 0, mBorderBigSize, UITweener.Method.EaseIn);
		mAnimator.AddTween(2, TweenAnimator.TweenType.Scale, border.gameObject, num * 4f, mBorderOriginalSize, 0f, 1, mBorderSmallSize, UITweener.Method.EaseOut);
		mAnimator.AddTween(3, TweenAnimator.TweenType.Alpha, border.gameObject, num * 1f, 0.15f, 0f, 0, 0f, UITweener.Method.Linear);
		mAnimator.AddTween(4, TweenAnimator.TweenType.Alpha, border.gameObject, num * 5f, 0.6f, num * 2f, 1, 0.15f);
		mAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, border.gameObject, num * 4f, 0.3f, num * 5f, 12, 0.6f);
		mAnimator.AddTween(6, TweenAnimator.TweenType.Position, label.gameObject, num * 4f, mLabelUpPosition, num * 1f, 1, mLabelDownPosition, UITweener.Method.EaseIn);
		mAnimator.AddTween(7, TweenAnimator.TweenType.Position, label.gameObject, num * 5f, mLabelOriginalPosition, 0f, 6, mLabelUpPosition, UITweener.Method.EaseOut);
		mAnimator.AddTween(8, TweenAnimator.TweenType.Alpha, label.gameObject, num * 3f, 1f, 0f, 1, 0f);
		mAnimator.AddTween(9, TweenAnimator.TweenType.ProgressBar, progress.gameObject, num * 7f, mAnimationBiggestFill, num * 2f, 1, mZeroFill, UITweener.Method.EaseIn);
		mAnimator.AddTween(10, TweenAnimator.TweenType.ProgressBar, progress.gameObject, num * 4f, mActualFill, 0f, 9, mAnimationBiggestFill, UITweener.Method.EaseOut);
		mAnimator.AddTween(11, TweenAnimator.TweenType.Alpha, progress.gameObject, num * 7f, 0.4f, num * 2f, 1, 0f);
		mAnimator.AddTween(12, TweenAnimator.TweenType.Alpha, progress.gameObject, num * 4f, 0.15f, 0f, 9, 0.5f);
		mAnimator.AddTween(13, TweenAnimator.TweenType.Scale, icons[0].gameObject, num * 5f, mIconDoubleSize, num * 2f, 1, mIconSmallSize);
		mAnimator.AddTween(14, TweenAnimator.TweenType.Scale, icons[0].gameObject, num * 5f, mIconOriginalSize, 0f, 13, mIconDoubleSize);
		mAnimator.AddTween(15, TweenAnimator.TweenType.Alpha, icons[0].gameObject, num * 1f, 1f, num * 2f, 1, 0f, UITweener.Method.Linear);
		mAnimator.AddTween(16, TweenAnimator.TweenType.Scale, icons[1].gameObject, num * 10f, mIconTrippleSize, num * 2f, 1, mIconOriginalSize);
		mAnimator.AddTween(17, TweenAnimator.TweenType.Alpha, icons[1].gameObject, num * 1f, 0.3f, num * 2f, 1, 0f, UITweener.Method.Linear);
		mAnimator.AddTween(18, TweenAnimator.TweenType.Alpha, icons[1].gameObject, num * 2f, 0f, num * 7f, 17, 0.3f, UITweener.Method.Linear);
		mAnimator.GenerateTweens();
	}

	private void OnTweenFinished(int tweenId)
	{
		if (tweenId == 0)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Upgrade);
		}
	}

	public void TutorialHide(float time)
	{
		TweenAlpha.Begin(border.gameObject, time, 0f);
		TweenAlpha.Begin(label.gameObject, time, 0f);
		TweenAlpha.Begin(progress.gameObject, time, 0f);
		TweenAlpha.Begin(icons[0].gameObject, time, 0f);
		TweenAlpha.Begin(icons[1].gameObject, time, 0f);
	}
}
