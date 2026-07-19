using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPointGunslinger : EnemyPoint
{
	private Vector3 EGNBHPMJDFA;

	public override Vector3 position
	{
		get
		{
			return base.transform.position;
		}
	}

	[SpecialName]
	public virtual Vector3 MKGJCPKNEFI()
	{
		return base.transform.position;
	}

	protected virtual void HCNOHLLOGBO()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)81;
		CAEMAAMICOF(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Car | LJGGJMAFEBN.Swat));
	}

	[SpecialName]
	public virtual Vector3 MINAAEHINCI()
	{
		return base.transform.position;
	}

	private void CDEPGJBKMDK()
	{
		Gizmos.color = new Color(14f, 1012f, 836f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 775f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 100f);
	}

	[SpecialName]
	public virtual Vector3 KFMEKDNOOPM()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual Vector3 BFFKKCCLDHM()
	{
		return base.transform.position;
	}

	[SpecialName]
	public virtual Vector3 HJEIBFHHGGE()
	{
		return base.transform.position;
	}

	private void NGENGNFIFOP()
	{
		Gizmos.color = new Color(477f, 703f, 1395f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1033f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1698f);
	}

	private void IFHBEGBINDL()
	{
		Gizmos.color = new Color(511f, 338f, 1873f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 374f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 649f);
	}

	protected virtual void BMLLLOBPGIB()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)60;
		base.enemyPointType = LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Tower | LJGGJMAFEBN.Minigunner;
	}

	protected virtual void KODJIPJGFPB()
	{
		CFGDCEOLKJG();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)98;
		KMPIAKMBIFL(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Minigunner));
	}

	[SpecialName]
	public virtual Vector3 CPMAMIEIHDF()
	{
		return base.transform.position;
	}

	protected virtual void OHHLNKPIHBH()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)66;
		CAEMAAMICOF(~(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower));
	}

	protected virtual void JJEONLDHCLO()
	{
		CFGDCEOLKJG();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-40);
		EMKAJOADOIH(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower);
	}

	private void EBOALKHIJLN()
	{
		Gizmos.color = new Color(372f, 1879f, 1277f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1540f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 669f);
	}

	protected virtual void CIGLDDGDAPM()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.MachineGunPoint;
		IOIIEDDBIKD(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter));
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1f, 0.1f, 0.5f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 0.08f);
	}

	private void GIEHJNFKJAH()
	{
		Gizmos.color = new Color(802f, 1845f, 618f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 467f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1165f);
	}

	private void PPMJJCNMJLO()
	{
		Gizmos.color = new Color(448f, 434f, 198f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 972f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 1827f);
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Gunslinger;
		base.enemyPointType = LJGGJMAFEBN.Gunslinger;
	}

	private void PLGDNELNGBG()
	{
		Gizmos.color = new Color(1739f, 1641f, 229f);
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 779f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 734f);
	}
}
