using UnityEngine;

public class EnemyPointRusher : EnemyPoint
{
	private bool mPosition;

	private PlayerPoint mActivePlayerPoint;

	public int index;

	private EnemyPointRusher mNearPoint;

	public Vector3 direction => base.transform.rotation * Vector3.forward;

	public PlayerPoint playerPoint { get; set; }

	public override Vector3 position => base.transform.position;

	public override bool isActive => playerPoint.shield.player != null;

	public bool isFreeWithNearNeighbour(EnemyPoint rusherPonitFrom)
	{
		if (rusherPonitFrom == mNearPoint)
		{
			return isFree;
		}
		return isFree && (mNearPoint == null || mNearPoint.isFree);
	}

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.Rusher;
		base.enemyPointType = EnemyPointType.Rusher;
	}

	protected override void Start()
	{
		base.Start();
		float num = float.MaxValue;
		foreach (MapDefinition.DefendPosition playersPosition in Singleton<MapManager>.instance.currentMapDef.playersPositions)
		{
			PlayerPoint point = playersPosition.point;
			float num2 = Vector3.Distance(point.transform.position, base.transform.position);
			if (num2 > 3f)
			{
				continue;
			}
			foreach (EnemyPointRusher rusherPoint in point.rusherPoints)
			{
				float num3 = Vector3.Distance(rusherPoint.position, position);
				if (num3 < num && num3 <= 0.2f && rusherPoint != this)
				{
					num = num3;
					mNearPoint = rusherPoint;
				}
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}
}
