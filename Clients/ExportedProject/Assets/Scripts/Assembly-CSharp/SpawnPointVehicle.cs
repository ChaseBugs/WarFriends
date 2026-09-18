using UnityEngine;

public class SpawnPointVehicle : SpawnPoint
{
	public WaypointCircuit waypointCircuit;

	public AIObject usedByEntity;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, 0.15f);
	}
}
