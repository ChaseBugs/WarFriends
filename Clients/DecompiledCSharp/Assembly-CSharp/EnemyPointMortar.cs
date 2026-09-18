using UnityEngine;

public class EnemyPointMortar : EnemyPoint
{
	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.Mortar;
		base.enemyPointType = EnemyPointType.Mortar;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1f, 0.5f, 0.1f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 0.08f);
	}
}
