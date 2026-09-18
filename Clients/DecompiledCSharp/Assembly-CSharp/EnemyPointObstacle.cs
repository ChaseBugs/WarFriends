using UnityEngine;

public class EnemyPointObstacle : EnemyPoint
{
	public Transform obstacleStart;

	public Transform obstacleEnd;

	private Vector3 mGeneratedPosition;

	private Vector3 diff;

	public override Vector3 position => mGeneratedPosition;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.ObstacleHiding;
		base.enemyPointType = EnemyPointType.Hiding;
		mGeneratedPosition = Vector3.Lerp(obstacleStart.position, obstacleEnd.position, 0.5f);
	}

	public override void GeneratePosition()
	{
		mGeneratedPosition = Vector3.Lerp(obstacleStart.position, obstacleEnd.position, Mathf.Clamp(Random.value, 0f, 1f));
		base.GeneratePosition();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(obstacleStart.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(obstacleStart.transform.position, Vector3.one * 0.08f);
		Gizmos.DrawLine(obstacleStart.transform.position, obstacleEnd.transform.position);
		Gizmos.DrawWireCube(obstacleEnd.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(obstacleEnd.transform.position, Vector3.one * 0.08f);
	}
}
