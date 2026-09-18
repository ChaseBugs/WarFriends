using UnityEngine;

public class EnemyPointMech : EnemyPoint
{
	public Vector3 direction => base.transform.rotation * Vector3.forward;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.Minigunner;
		base.enemyPointType = EnemyPointType.Mech;
	}

	public override bool IsEnemyPointReached(Vector3 enemyPos)
	{
		return position.PlanarDistance(enemyPos) < 0.02f;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(0f, 0.5f, 0.1f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 0.08f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}
}
