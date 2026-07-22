using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPathDelayList : CameraPathPointList
{
	public delegate void CameraPathDelayEventHandler(float time);

	public float MINIMUM_EASE_VALUE;

	private float _lastPercentage;

	[SerializeField]
	private CameraPathDelay _introPoint;

	[SerializeField]
	private CameraPathDelay _outroPoint;

	[SerializeField]
	private bool delayInitialised;

	public new CameraPathDelay Item => null;

	public CameraPathDelay introPoint => null;

	public CameraPathDelay outroPoint => null;

	public event CameraPathDelayEventHandler CameraPathDelayEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void OnEnable()
	{
	}

	public override void Init(CameraPath _cameraPath)
	{
	}

	public void AddDelayPoint(CameraPathControlPoint atPoint)
	{
	}

	public CameraPathDelay AddDelayPoint(CameraPathControlPoint curvePointA, CameraPathControlPoint curvePointB, float curvePercetage)
	{
		return null;
	}

	public void OnAnimationStart(float startPercentage)
	{
	}

	public void CheckEvents(float percentage)
	{
	}

	public float CheckEase(float percent)
	{
		return 0f;
	}

	public void FireDelay(CameraPathDelay eventPoint)
	{
	}
}
