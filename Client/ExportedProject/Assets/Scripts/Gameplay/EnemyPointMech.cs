using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPointMech : EnemyPoint
{
	public Vector3 direction => base.transform.rotation * Vector3.forward;

	private void PALNOFNGIGH()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(311f, 1587f, 267f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 971f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1334f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + ALHBCCJOMJL());
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Minigunner;
		base.enemyPointType = LJGGJMAFEBN.Mech;
	}

	[SpecialName]
	public Vector3 FEKIIMECACD()
	{
		return base.transform.rotation * Vector3.forward;
	}

	protected virtual void FIGOGIMJIIN()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)56;
		KMPIAKMBIFL(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Minigunner));
	}

	private void AAJINFILNOM()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(1741f, 805f, 1373f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 905f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1733f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + OINMPPCDFGB());
	}

	private void DHIPGNALJKG()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(1116f, 960f, 1173f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 704f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1585f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	public override bool MOKMCBFCMFJ(Vector3 IBONOHAIAAC)
	{
		return FGKJILDKPHC().PlanarDistance(IBONOHAIAAC) < 193f;
	}

	protected virtual void JJEONLDHCLO()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)29;
		IOIIEDDBIKD(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Tower | LJGGJMAFEBN.Minigunner));
	}

	private void FGIOPBBNHLB()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(408f, 1867f, 947f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1969f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1911f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	private void GFADEDGHLFC()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(644f, 1843f, 1221f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 316f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 407f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + FEKIIMECACD());
	}

	private void MKPOBMBBKLL()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(1868f, 620f, 109f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1299f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 700f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + FEKIIMECACD());
	}

	private void NGENGNFIFOP()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(1483f, 1792f, 1756f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1164f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1003f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + AFBKDHLCLMF());
	}

	[SpecialName]
	public Vector3 ALHBCCJOMJL()
	{
		return base.transform.rotation * Vector3.forward;
	}

	protected virtual void PCDHCIDJJOB()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-106);
		NGCBJNCNCCM(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Tower | LJGGJMAFEBN.Minigunner);
	}

	private void LOIBFJMMJGC()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(1923f, 1527f, 4f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1540f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1595f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + OINMPPCDFGB());
	}

	public virtual bool GDKDGLBOFJD(Vector3 IBONOHAIAAC)
	{
		return PFOBADFGAKF().PlanarDistance(IBONOHAIAAC) < 1773f;
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-90);
		CAEMAAMICOF(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Minigunner));
	}

	private void KBPCBKHDFCJ()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(933f, 391f, 2f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 498f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 495f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + AFBKDHLCLMF());
	}

	public override bool IsEnemyPointReached(Vector3 IBONOHAIAAC)
	{
		return position.PlanarDistance(IBONOHAIAAC) < 0.02f;
	}

	[SpecialName]
	public Vector3 OINMPPCDFGB()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public virtual bool IDGLHFGEHIN(Vector3 IBONOHAIAAC)
	{
		return KPOEEKLFALL().PlanarDistance(IBONOHAIAAC) < 350f;
	}

	public virtual bool BANNNPOHABP(Vector3 IBONOHAIAAC)
	{
		return MGPNABOBKFP().PlanarDistance(IBONOHAIAAC) < 777f;
	}

	[SpecialName]
	public Vector3 AFBKDHLCLMF()
	{
		return base.transform.rotation * Vector3.forward;
	}

	public virtual bool IAJDOCMCFMK(Vector3 IBONOHAIAAC)
	{
		return KPOEEKLFALL().PlanarDistance(IBONOHAIAAC) < 1402f;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(0f, 0.5f, 0.1f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 0.08f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	private void FMIMKIOJLOI()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(1049f, 208f, 1902f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1642f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 830f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + FEKIIMECACD());
	}

	private void CDEPGJBKMDK()
	{
		Gizmos.color = Color.red;
		Gizmos.color = new Color(1619f, 1360f, 1697f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 374f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1277f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + direction);
	}

	protected virtual void EJFMJDFPGFE()
	{
		CFGDCEOLKJG();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-3);
		NGCBJNCNCCM(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Minigunner));
	}

	[SpecialName]
	public Vector3 NBMNELMCICC()
	{
		return base.transform.rotation * Vector3.forward;
	}
}
