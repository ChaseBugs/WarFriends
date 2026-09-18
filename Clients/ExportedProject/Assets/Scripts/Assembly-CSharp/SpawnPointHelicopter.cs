using UnityEngine;

public class SpawnPointHelicopter : SpawnPoint
{
	public WayPoint wayPointToJoin;

	public WayPoint wayPointToStop;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, 0.15f);
	}
}
