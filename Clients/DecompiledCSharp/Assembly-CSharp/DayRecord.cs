using UnityEngine;

public class DayRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite daySprite;

	public UISprite progressSprite;

	public UISprite[] animationSprites;

	public UISprite animationDay;

	private Vector3 mVectorOneSize = new Vector3(1f, 1f, 0f);

	private Vector3 mZeroPointEightSize = new Vector3(58f, 62f, 0f);

	private Vector3 mOriginalSize = new Vector3(72f, 78f, 0f);

	private Vector3 mOneAndHalfSize = new Vector3(108f, 117f, 0f);

	private Vector3 mTwoAndHalfSize = new Vector3(180f, 195f, 0f);

	private Vector3 mThreeAndHalfSize = new Vector3(252f, 273f, 0f);

	public void Initialize(bool dayCompleted, bool fillNextProgress)
	{
		daySprite.spriteName = ((!dayCompleted) ? AssignmentsManager.dayNotCompleted : AssignmentsManager.dayCompleted);
		progressSprite.color = ((!fillNextProgress) ? Colours.grayProgress : Colours.goldProgress);
	}

	public void StopAnimations()
	{
		TweenAlpha.Begin(daySprite.gameObject, 0f, 1f, 1f).onFinished = null;
		TweenAlpha.Begin(animationDay.gameObject, 0f, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(animationSprites[0].gameObject, 0f, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(animationSprites[1].gameObject, 0f, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(animationSprites[2].gameObject, 0f, 0f, 0f).onFinished = null;
		TweenScale.Begin(animationDay.gameObject, 0f, mVectorOneSize).onFinished = null;
		TweenScale.Begin(animationSprites[0].gameObject, 0f, mZeroPointEightSize).onFinished = null;
		TweenScale.Begin(animationSprites[1].gameObject, 0f, mZeroPointEightSize).onFinished = null;
		TweenScale.Begin(animationSprites[2].gameObject, 0f, mZeroPointEightSize).onFinished = null;
	}

	public void Animate(float dur, float delay)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.AssignmentDayCompleted);
		AnimateFirstFlash(dur);
		TweenAlpha.Begin(daySprite.gameObject, delay * 2f, 1f, 1f).onFinished = delegate
		{
			AnimateMiddleFlash(dur);
		};
	}

	private void AnimateFirstFlash(float dur)
	{
		GameObject go = animationSprites[0].gameObject;
		TweenScale.Begin(go, 0f, mZeroPointEightSize).onFinished = null;
		TweenAlpha.Begin(go, 0f, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(go, dur * 0.5f, 0f, 0.8f).onFinished = delegate
		{
			TweenAlpha.Begin(go, dur * 0.2f, 0.8f, 0.6f).onFinished = null;
			TweenScale tweenScale = TweenScale.Begin(go, dur, mZeroPointEightSize, mTwoAndHalfSize);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = delegate
			{
				TweenAlpha.Begin(go, dur * 0.6f, 0.6f, 0f).onFinished = null;
				TweenScale tweenScale2 = TweenScale.Begin(go, dur * 0.6f, mThreeAndHalfSize);
				tweenScale2.method = UITweener.Method.EaseOut;
				tweenScale2.onFinished = null;
			};
		};
	}

	private void AnimateMiddleFlash(float dur)
	{
		GameObject go = animationSprites[1].gameObject;
		TweenScale.Begin(go, 0f, mZeroPointEightSize).onFinished = null;
		TweenAlpha.Begin(go, 0f, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(go, dur * 0.5f, 0f, 0.8f).onFinished = delegate
		{
			TweenAlpha.Begin(go, dur * 0.2f, 0.8f, 0.6f).onFinished = delegate
			{
				TweenAlpha.Begin(go, dur * 0.6f, 0.6f, 0f).onFinished = null;
				AnimateCompleted(dur);
			};
			TweenScale.Begin(go, dur * 0.8f, mZeroPointEightSize, mOneAndHalfSize).method = UITweener.Method.EaseIn;
		};
	}

	private void AnimateCompleted(float dur)
	{
		TweenAlpha.Begin(animationDay.gameObject, dur * 0.2f, 0f, 1f).onFinished = null;
		TweenScale tweenScale = TweenScale.Begin(animationDay.gameObject, dur * 0.6f, mVectorOneSize, mOneAndHalfSize);
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = delegate
		{
			AnimateLastFlash(dur);
			TweenScale tweenScale2 = TweenScale.Begin(animationDay.gameObject, dur * 0.4f, mOriginalSize);
			tweenScale2.method = UITweener.Method.EaseOut;
			tweenScale2.onFinished = delegate
			{
				GuiScreenSingle<AssignmentsScreen>.instance.dailyPart.daysProgress.EndOfDayProgressAnimation();
				TweenAlpha.Begin(animationDay.gameObject, dur * 3f, 1f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(animationDay.gameObject, 0f, 0f, 0f).onFinished = null;
				};
			};
		};
	}

	private void AnimateLastFlash(float dur)
	{
		GameObject go = animationSprites[2].gameObject;
		TweenScale.Begin(go, 0f, mZeroPointEightSize).onFinished = null;
		TweenAlpha.Begin(go, 0f, 0.8f, 0.8f).onFinished = null;
		TweenScale tweenScale = TweenScale.Begin(go, dur * 1f, mOneAndHalfSize, mThreeAndHalfSize);
		tweenScale.method = UITweener.Method.EaseOut;
		tweenScale.onFinished = null;
		TweenAlpha.Begin(go, dur * 0.5f, 0.8f, 0.6f).onFinished = delegate
		{
			TweenAlpha.Begin(go, dur * 0.5f, 0.6f, 0f).onFinished = null;
		};
	}
}
