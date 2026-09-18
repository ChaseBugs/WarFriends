using UnityEngine;

public class EnemyPointHelicopter : EnemyPoint
{
	public Helicopter helicopter;

	public Transform ropePosition;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.Helicopter;
		base.enemyPointType = EnemyPointType.Helicopter;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 2f);
		if (ropePosition != null)
		{
			Gizmos.DrawWireCube(ropePosition.position, Vector3.one * 0.03f);
		}
	}
}
