using UnityEngine;

public class EnemyPointEngineerTurret : EnemyPoint
{
	private Turret mTurret;

	public override bool isFree => base.isFree && turret == null;

	public override Vector3 position => base.position - base.transform.forward * 0.2f;

	public Vector3 turretPosition
	{
		get
		{
			NavMesh.SamplePosition(position + base.transform.forward * 0.4f, out var hit, 10f, 1);
			return hit.position;
		}
	}

	public Turret turret
	{
		get
		{
			return mTurret;
		}
		set
		{
			mTurret = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		switchState = EnemyController.EnemyAIState.EngineerTurret;
		base.enemyPointType = EnemyPointType.EngineerTurret;
	}

	public void SetTurret(Turret turret)
	{
		this.turret = turret;
		this.turret.Killed += TurretOnKilled;
	}

	private void TurretOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo damageInfo)
	{
		turret.Killed -= TurretOnKilled;
		if (gameMainEntity == turret)
		{
			turret = null;
		}
	}

	private void AiObjectOnAiObjectKilled(AIObject aiObject, DestroyableObject.DamageInfo damageInfo)
	{
	}

	private void OnDisable()
	{
		if (turret != null)
		{
			turret.Killed -= TurretOnKilled;
			turret = null;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}
}
