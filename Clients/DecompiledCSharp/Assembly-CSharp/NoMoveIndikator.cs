using UnityEngine;

public class NoMoveIndikator : PoolableObject
{
	private float liveTime;

	private TweenPosition tp;

	private TweenAlphaTk2d ta;

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		liveTime = 0.5f;
		if (tp != null)
		{
			tp.enabled = false;
		}
		if (ta != null)
		{
			ta.enabled = false;
		}
	}

	public void StartAnimation(int direction)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 20f;
		localPosition.x += direction * 14;
		localPosition.z -= 10f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)direction * 10f;
		tp = TweenPosition.Begin(base.gameObject, 0.5f, localPosition);
		ta = TweenAlphaTk2d.Begin(base.gameObject, 0.5f, 0f, 0.7f);
		ta.alpha = 0f;
	}

	protected void Update()
	{
		liveTime -= Time.unscaledDeltaTime;
		if (liveTime < 0f)
		{
			DestroyPooled();
		}
	}
}
