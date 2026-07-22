using UnityEngine;

public class TweenPosition : UITweener
{
	public Vector3 from;

	public Vector3 to;

	public bool useLocal;

	private Transform mTrans;

	public Transform cachedTransform => null;

	public Vector3 position
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
	}

	public static TweenPosition Begin(GameObject go, float duration, Vector3 pos, bool useLocal = true)
	{
		return null;
	}

	public static TweenPosition Begin(GameObject go, float duration, Vector3 fromnPos, Vector3 toPos, bool useLocal = true)
	{
		return null;
	}
}
