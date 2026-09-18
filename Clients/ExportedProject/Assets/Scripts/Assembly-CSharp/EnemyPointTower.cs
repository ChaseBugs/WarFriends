using UnityEngine;

public class EnemyPointTower : EnemyPoint
{
	public Transform towerPosition;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.MachineGunPoint;
		base.enemyPointType = EnemyPointType.Tower;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, towerPosition.position);
		Gizmos.DrawWireCube(towerPosition.position, Vector3.one * 0.15f);
	}
}
