using UnityEngine;

[AddComponentMenu("NGUI/Tween/Rotation")]
public class TweenRotation : UITweener
{
	public Vector3 from;

	public Vector3 to;

	public bool useAbsolute;

	private Transform mTrans;

	public bool linear;

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

	public Quaternion rotation
	{
		get
		{
			if (useAbsolute)
			{
				return cachedTransform.rotation;
			}
			return cachedTransform.localRotation;
		}
		set
		{
			if (useAbsolute)
			{
				cachedTransform.rotation = value;
			}
			cachedTransform.localRotation = value;
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (useAbsolute)
		{
			cachedTransform.rotation = Quaternion.Slerp(Quaternion.Euler(from), Quaternion.Euler(to), factor);
		}
		else
		{
			cachedTransform.localRotation = Quaternion.Slerp(Quaternion.Euler(from), Quaternion.Euler(to), factor);
		}
	}

	public static TweenRotation Begin(GameObject go, float duration, Quaternion rot, bool useAbsolute = false)
	{
		TweenRotation tweenRotation = UITweener.Begin<TweenRotation>(go, duration);
		tweenRotation.useAbsolute = useAbsolute;
		tweenRotation.from = tweenRotation.rotation.eulerAngles;
		tweenRotation.to = rot.eulerAngles;
		if (duration <= 0f)
		{
			tweenRotation.onFinished = null;
			tweenRotation.Sample(1f, true);
			tweenRotation.enabled = false;
		}
		return tweenRotation;
	}

	public static TweenRotation Begin(GameObject go, float duration, Quaternion from, Quaternion to)
	{
		TweenRotation tweenRotation = UITweener.Begin<TweenRotation>(go, duration);
		tweenRotation.from = from.eulerAngles;
		tweenRotation.to = to.eulerAngles;
		if (duration <= 0f)
		{
			tweenRotation.Sample(1f, true);
			tweenRotation.enabled = false;
		}
		return tweenRotation;
	}
}
