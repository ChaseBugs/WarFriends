using UnityEngine;

public class EnemyPointRusherSpare : EnemyPoint
{
	private bool mPosition;

	private PlayerPoint mActivePlayerPoint;

	public int index;

	private EnemyPointRusher mNearPoint;

	public Vector3 direction => base.transform.rotation * Vector3.forward;

	public PlayerPoint playerPoint { get; set; }

	public override Vector3 position => (!(base.transform != null)) ? Vector3.zero : base.transform.position;

	public override bool isActive => playerPoint.shield.player != null;

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.RusherSpare;
		base.enemyPointType = EnemyPointType.RusherSpare;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}
}
