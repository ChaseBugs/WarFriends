using UnityEngine;

public class EnemyPointGunslinger : EnemyPoint
{
	private Vector3 mGeneratedPosition;

	public override Vector3 position => base.transform.position;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.Gunslinger;
		base.enemyPointType = EnemyPointType.Gunslinger;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1f, 0.1f, 0.5f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 0.08f);
	}
}
