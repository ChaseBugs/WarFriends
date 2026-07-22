using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPathPointList : MonoBehaviour
{
	[SerializeField]
	private List<CameraPathPoint> _points;

	[SerializeField]
	protected CameraPath cameraPath;

	protected string pointTypeName;

	[NonSerialized]
	protected bool initialised;

	public CameraPathPoint Item => null;

	public int numberOfPoints => 0;

	public int realNumberOfPoints => 0;

	private void OnEnable()
	{
	}

	public virtual void Init(CameraPath _cameraPath)
	{
	}

	public virtual void CleanUp()
	{
	}

	public int IndexOf(CameraPathPoint point)
	{
		return 0;
	}

	public void AddPoint(CameraPathPoint newPoint, CameraPathControlPoint curvePointA, CameraPathControlPoint curvePointB, float curvePercetage)
	{
	}

	public void AddPoint(CameraPathPoint newPoint, float fixPercent)
	{
	}

	public void AddPoint(CameraPathPoint newPoint, CameraPathControlPoint atPoint)
	{
	}

	public void RemovePoint(CameraPathPoint newPoint)
	{
	}

	public void PathPointAddedEvent(CameraPathControlPoint addedPoint)
	{
	}

	public void PathPointRemovedEvent(CameraPathControlPoint removedPathPoint)
	{
	}

	public void CheckPointCullEventFromStart(float percent)
	{
	}

	public void CheckPointCullEventFromEnd(float percent)
	{
	}

	protected int GetNextPointIndex(float percent)
	{
		return 0;
	}

	protected int GetLastPointIndex(float percent)
	{
		return 0;
	}

	public CameraPathPoint GetPoint(int index)
	{
		return null;
	}

	public CameraPathPoint GetPoint(CameraPathControlPoint atPoint)
	{
		return null;
	}

	public void Clear()
	{
	}

	public CameraPathPoint DuplicatePointCheck()
	{
		return null;
	}

	protected virtual void RecalculatePoints()
	{
	}

	public void ReassignCP(CameraPathControlPoint from, CameraPathControlPoint to)
	{
	}
}
