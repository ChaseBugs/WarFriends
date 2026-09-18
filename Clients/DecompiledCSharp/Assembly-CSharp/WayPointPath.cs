using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WayPointPath : Core_BaseScript
{
	[SerializeField]
	public List<WayPoint> wayPoints;

	public bool loadWayPoints;

	public float Radius = 0.5f;

	public MainGameEntity usedByEntity;

	public List<PositionTime> positions;

	public Vector3 this[int i]
	{
		get
		{
			if (positions != null)
			{
				return positions[i].position;
			}
			return default(Vector3);
		}
	}

	public int count => positions.Count;

	protected override void Awake()
	{
		base.Awake();
		int num = 0;
		if (wayPoints == null)
		{
			return;
		}
		foreach (WayPoint wayPoint in wayPoints)
		{
			wayPoint.index = num;
			num++;
		}
	}

	private void OnDrawGizmos()
	{
		if (wayPoints != null)
		{
			Gizmos.color = Color.red;
			for (int i = 1; i < wayPoints.Count; i++)
			{
				WayPoint wayPoint = wayPoints[i];
				WayPoint wayPoint2 = wayPoints[i - 1];
				Gizmos.DrawLine(wayPoint.transform.position, wayPoint2.transform.position);
			}
		}
	}
}
