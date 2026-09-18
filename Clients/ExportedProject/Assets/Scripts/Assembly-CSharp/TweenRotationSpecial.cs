using UnityEngine;

[AddComponentMenu("NGUI/Tween/Rotation")]
public class TweenRotationSpecial : UITweener
{
	public float from;

	public float to;

	public Vector3 rotationAxis;

	private Transform mTrans;

	public Vector3 baseRotation;

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

	protected override void OnUpdate(float factor, bool isFinished)
	{
		float angle = from * (1f - factor) + to * factor;
		cachedTransform.localRotation = Quaternion.AngleAxis(angle, rotationAxis) * Quaternion.Euler(baseRotation);
	}

	public static TweenRotationSpecial Begin(GameObject go, float duration, Vector3 rotAxis, float angleFrom, float angleTo)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(go, duration);
		tweenRotationSpecial.from = angleFrom;
		tweenRotationSpecial.to = angleTo;
		tweenRotationSpecial.rotationAxis = rotAxis;
		if (duration <= 0f)
		{
			tweenRotationSpecial.Sample(1f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}
}
