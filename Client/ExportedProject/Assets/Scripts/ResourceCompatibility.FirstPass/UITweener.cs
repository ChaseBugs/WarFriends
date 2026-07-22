using AnimationOrTween;
using UnityEngine;

public abstract class UITweener : IgnoreTimeScale
{
	public enum Method
	{
		Linear,
		EaseIn,
		EaseOut,
		EaseInOut,
		BounceIn,
		BounceOut
	}

	public enum Style
	{
		Once,
		Loop,
		PingPong
	}

	public delegate void OnFinished(UITweener tween);

	public OnFinished onFinished;

	public OnFinished onBegin;

	public Method method;

	public Style style;

	public AnimationCurve animationCurve;

	public bool ignoreTimeScale;

	public float delay;

	public float duration;

	public bool steeperCurves;

	public int tweenGroup;

	public GameObject eventReceiver;

	public string callWhenFinished;

	public int NumOfRepetitions;

	public int id;

	private bool mStarted;

	private bool mBegan;

	private float mStartTime;

	private float mDuration;

	private float mAmountPerDelta;

	private float mFactor;

	private float mRepetitions;

	public bool dontResetCurve;

	public float amountPerDelta => 0f;

	public float tweenFactor => 0f;

	public Direction direction => default(Direction);

	private void Start()
	{
	}

	private bool CheckRepetitions()
	{
		return false;
	}

	protected virtual void Update()
	{
	}

	private void OnDisable()
	{
	}

	public void Sample(float factor, bool isFinished)
	{
	}

	private float BounceLogic(float val)
	{
		return 0f;
	}

	public void Play(bool forward)
	{
	}

	public void Reset()
	{
	}

	public void Toggle()
	{
	}

	protected abstract void OnUpdate(float factor, bool isFinished);

	public static T Begin<T>(GameObject go, float duration) where T : UITweener
	{
		return null;
	}

	protected void Begin(float duration)
	{
	}
}
