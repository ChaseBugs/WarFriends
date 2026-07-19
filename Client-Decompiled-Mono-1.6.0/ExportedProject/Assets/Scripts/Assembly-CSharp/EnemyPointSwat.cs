using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPointSwat : EnemyPoint
{
	public Vector3 direction
	{
		get
		{
			return base.transform.rotation * Vector3.forward;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		base.enemyPointType = LJGGJMAFEBN.Swat;
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.CFGDCEOLKJG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		MMPAHCDHGCN(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower));
	}

	private void NGENGNFIFOP()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 702f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + AEHLLJECILA());
	}

	private void IFIEHGDOGON()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 620f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + MAPNKMMBPBL());
	}

	protected virtual void KALEMFKOGLE()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		KMPIAKMBIFL(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower);
	}

	private void HNJJEGIGGCI()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 388f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + FMCOOEMOOMD());
	}

	[SpecialName]
	public Vector3 HACJECBJOGG()
	{
		return base.transform.rotation * Vector3.forward;
	}

	protected override void CFGDCEOLKJG()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		MMPAHCDHGCN(~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car));
	}

	protected virtual void KODJIPJGFPB()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		MMPAHCDHGCN(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat);
	}

	[SpecialName]
	public Vector3 MAPNKMMBPBL()
	{
		return base.transform.rotation * Vector3.forward;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	[SpecialName]
	public Vector3 AEHLLJECILA()
	{
		return base.transform.rotation * Vector3.forward;
	}

	[SpecialName]
	public Vector3 FMCOOEMOOMD()
	{
		return base.transform.rotation * Vector3.forward;
	}

	protected virtual void NGGJHDCOLEC()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		KMPIAKMBIFL(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat);
	}
}
