using UnityEngine;

public class SpawnPointParachute : SpawnPoint
{
	protected override void Awake()
	{
		base.Awake();
		spawnPointType = SpawnPointType.Parachute;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(base.transform.position, 0.15f);
	}
}
