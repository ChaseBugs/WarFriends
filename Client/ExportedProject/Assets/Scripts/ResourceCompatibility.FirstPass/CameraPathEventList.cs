using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPathEventList : CameraPathPointList
{
	public delegate void CameraPathEventPointHandler(string name);

	private float _lastPercentage;

	public new CameraPathEvent Item => null;

	public event CameraPathEventPointHandler CameraPathEventPoint
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

	public void AddEvent(CameraPathControlPoint atPoint)
	{
	}

	public CameraPathEvent AddEvent(CameraPathControlPoint curvePointA, CameraPathControlPoint curvePointB, float curvePercetage)
	{
		return null;
	}

	public void OnAnimationStart(float startPercentage)
	{
	}

	public void CheckEvents(float percentage)
	{
	}

	public void BroadCast(CameraPathEvent eventPoint)
	{
	}

	public void Call(CameraPathEvent eventPoint)
	{
	}
}
