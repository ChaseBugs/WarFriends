using UnityEngine;

public class EnemyPointVehicle : EnemyPoint
{
	public float nextSpawnTime { get; set; }

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.Vehicle;
		base.enemyPointType = EnemyPointType.Car;
	}

	private void OnEnable()
	{
	}

	public override bool IsEnemyPointReached(Vector3 enemyPos)
	{
		return position.PlanarDistance(enemyPos) < 1f;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}
}
