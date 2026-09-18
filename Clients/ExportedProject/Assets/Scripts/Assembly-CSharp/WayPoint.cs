using UnityEngine;

public class WayPoint : Core_BaseScript
{
	public WayPointPath path;

	public int index;

	public float stayTime;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(base.transform.position, 0.2f * Vector3.one);
		Gizmos.color = Color.green;
		Gizmos.DrawRay(base.transform.position, base.transform.forward);
	}
}
