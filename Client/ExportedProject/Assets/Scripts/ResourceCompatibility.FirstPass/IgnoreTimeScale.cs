using UnityEngine;

public class IgnoreTimeScale : MonoBehaviour
{
	private float mRt;

	private float mTimeStart;

	private float mTimeDelta;

	private float mActual;

	private bool mTimeStarted;

	public float realTime => 0f;

	public float realTimeDelta => 0f;

	protected virtual void OnEnable()
	{
	}

	protected float UpdateRealTimeDelta()
	{
		return 0f;
	}
}
