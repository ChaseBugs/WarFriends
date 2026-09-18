using UnityEngine;

public class SpawnPointDrone : SpawnPoint
{
	public WayPoint pointToJoin;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(base.transform.position, 0.15f);
	}
}
