using UnityEngine;

[AddComponentMenu("NGUI/Tween/Position")]
public class TweenPosition : UITweener
{
	public Vector3 from;

	public Vector3 to;

	public bool useLocal = true;

	private Transform mTrans;

	public Transform cachedTransform
	{
		get
		{
			if (mTrans == null)
			{
				mTrans = base.transform;
			}
			return mTrans;
		}
	}

	public Vector3 position
	{
		get
		{
			if (useLocal)
			{
				return cachedTransform.localPosition;
			}
			return cachedTransform.position;
		}
		set
		{
			if (useLocal)
			{
				cachedTransform.localPosition = value;
			}
			cachedTransform.position = value;
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (useLocal)
		{
			cachedTransform.localPosition = from * (1f - factor) + to * factor;
		}
		else
		{
			cachedTransform.position = from * (1f - factor) + to * factor;
		}
	}

	public static TweenPosition Begin(GameObject go, float duration, Vector3 pos, bool useLocal = true)
	{
		TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
		tweenPosition.useLocal = useLocal;
		tweenPosition.from = tweenPosition.position;
		tweenPosition.to = pos;
		if (duration <= 0f)
		{
			tweenPosition.Sample(1f, true);
			tweenPosition.enabled = false;
		}
		return tweenPosition;
	}

	public static TweenPosition Begin(GameObject go, float duration, Vector3 fromnPos, Vector3 toPos, bool useLocal = true)
	{
		TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
		tweenPosition.useLocal = useLocal;
		tweenPosition.from = fromnPos;
		tweenPosition.to = toPos;
		if (duration <= 0f)
		{
			tweenPosition.Sample(1f, true);
			tweenPosition.enabled = false;
		}
		return tweenPosition;
	}
}
