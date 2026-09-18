using UnityEngine;

public class SpawnPointCar : SpawnPointVehicle
{
	public Transform target;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(base.transform.position, 0.15f);
	}
}
