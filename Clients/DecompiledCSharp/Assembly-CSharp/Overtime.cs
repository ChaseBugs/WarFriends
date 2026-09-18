using System;
using System.Collections.Generic;
using UnityEngine;

public class Overtime : GuiElementSingle<Overtime>
{
	public UISprite overtimeSprite;

	public UISprite glow;

	private TweenAnimator mAnimator;

	private Vector3 mGlowSize = new Vector3(500f, 109f, 1f);

	private bool mAnimationFinished;

	public bool isAnimationFinished => mAnimationFinished;

	public override void InitControls()
	{
		CheckOrCreateAnimator();
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<MatchManager>.instance.OverTimeStarted += OnOverTimeStart;
	}

	private void OnGameStarted()
	{
		mAnimationFinished = false;
	}

	private void OnOverTimeStart()
	{
		mAnimationFinished = false;
		mAnimator.PlayTweens();
	}

	public override void InitGUIValues()
	{
	}

	private void CheckOrCreateAnimator()
	{
		if (mAnimator == null)
		{
			mAnimator = base.gameObject.AddComponent<TweenAnimator>();
			mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
			AddAnimations();
			TweenAnimator tweenAnimator = mAnimator;
			tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(OnTweenFinished));
		}
	}

	private void OnTweenFinished(int tweenId)
	{
		if (tweenId == 14)
		{
			mAnimationFinished = true;
		}
	}

	private void AddAnimations()
	{
		float num = 0.2f;
		float num2 = 1f;
		float time = 0.01f;
		float time2 = 0.05f;
		float delay = 0.05f;
		Vector3 vector = new Vector3(mGlowSize.x * 6f, mGlowSize.y * 6f, 1f);
		Vector3 vector2 = new Vector3(mGlowSize.x * 3f, 1f, 1f);
		overtimeSprite.MakePixelPerfect();
		Vector3 localScale = overtimeSprite.transform.localScale;
		Vector3 vector3 = localScale * 1.2f;
		vector3.z = 1f;
		Vector3 vector4 = localScale * 1.1f;
		vector4.z = 1f;
		mAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, glow.gameObject, time2, 1f, 0f, -1, 0f);
		mAnimator.AddTween(from: Vector3.one, id: 2, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: glow.gameObject, time: num * 3f, to: vector, delay: 0f);
		mAnimator.AddTween(3, TweenAnimator.TweenType.Scale, glow.gameObject, num2 + num * 3f, vector2, 0f, 2);
		mAnimator.AddTween(4, TweenAnimator.TweenType.Alpha, glow.gameObject, time2, 0f, 0f, 3);
		mAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, overtimeSprite.gameObject, time2, 1f, 0f, -1, 0f);
		mAnimator.AddTween(from: Vector3.one, id: 6, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: overtimeSprite.gameObject, time: num * 3f, to: vector3, delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.Linear);
		mAnimator.AddTween(7, TweenAnimator.TweenType.Scale, overtimeSprite.gameObject, num, vector4, 0f, 6, null, UITweener.Method.Linear);
		mAnimator.AddTween(8, TweenAnimator.TweenType.Scale, overtimeSprite.gameObject, num2 + num * 2f, localScale, 0f, 7, null, UITweener.Method.Linear);
		mAnimator.AddTween(10, TweenAnimator.TweenType.Alpha, overtimeSprite.gameObject, time, 0f, delay, 8);
		mAnimator.AddTween(11, TweenAnimator.TweenType.Alpha, overtimeSprite.gameObject, time, 1f, delay, 10);
		mAnimator.AddTween(12, TweenAnimator.TweenType.Alpha, overtimeSprite.gameObject, time, 0f, delay, 11);
		mAnimator.AddTween(13, TweenAnimator.TweenType.Alpha, overtimeSprite.gameObject, time, 1f, delay, 12);
		mAnimator.AddTween(14, TweenAnimator.TweenType.Alpha, overtimeSprite.gameObject, time, 0f, delay, 13);
	}
}
