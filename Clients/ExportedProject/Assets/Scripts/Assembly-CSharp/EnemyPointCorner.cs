using UnityEngine;

public class EnemyPointCorner : EnemyPoint
{
	public Vector3 direction = Vector3.forward;

	public bool rightSide = true;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.CornerHiding;
		base.enemyPointType = EnemyPointType.Corner;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(direction, (!rightSide) ? (-Vector3.up) : Vector3.up));
	}
}
