using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPointVehicle : EnemyPoint
{
	[CompilerGenerated]
	private float _003CKEAOMANFBDK_003Ek__BackingField;

	public float nextSpawnTime
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	protected override void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public override bool IsEnemyPointReached(Vector3 JFOCKCBCNFC)
	{
		return false;
	}

	private void OnDrawGizmos()
	{
	}
}
