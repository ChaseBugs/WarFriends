using UnityEngine;

public class EnemyPointSwat : EnemyPoint
{
	public Vector3 direction => base.transform.rotation * Vector3.forward;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.Swat;
		base.enemyPointType = EnemyPointType.Swat;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}
}
