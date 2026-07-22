using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPointCorner : EnemyPoint
{
	[FormerlySerializedAs("LAOJMLCBLBN")]
	public Vector3 PLEBANKIBPP = Vector3.forward;

	[FormerlySerializedAs("AGAAPHECDHG")]
	public bool NHKBMMIHAFH = true;

	private void DHIPGNALJKG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1540f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void EEMLMJCHKLM()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		IOIIEDDBIKD(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	protected virtual void NOOLAIEENFB()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		EMKAJOADOIH(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	protected virtual void DDJBFEJLMBP()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		NGCBJNCNCCM(LJGGJMAFEBN.Car);
	}

	protected virtual void NGICLHFNNJJ()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		NMLJBLGJCOA(LJGGJMAFEBN.Corner);
	}

	private void EFNOBFKGECB()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1152f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void PALNOFNGIGH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1357f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void MGMKGNALIFL()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1835f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void JKOCICFDCHC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1620f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void GIEHJNFKJAH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1619f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void IABJJOPLKFF()
	{
		PJEMCLFLGBL();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		EMKAJOADOIH(LJGGJMAFEBN.Rusher);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void DPDJMDLIHOK()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1287f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected override void MLBAFICPECE()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		EMKAJOADOIH(LJGGJMAFEBN.Hiding);
	}

	protected virtual void JLOKAFKICIM()
	{
		base.MLBAFICPECE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		MMPAHCDHGCN(LJGGJMAFEBN.Rusher);
	}

	private void JCHNMNLMPAN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 143f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void LKAACNCCDEL()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 260f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void DEFLNOIABMI()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 10f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void MEBEHLLPMPK()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		HBBKGCJEDNO((LJGGJMAFEBN)0);
	}

	private void EMIPNAHFCLO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1847f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void LFDEIPIDFMI()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 495f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void HCOJFEKEJCN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1009f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void BPHIJGOFILN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 546f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void IEKDFPMNHBF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1872f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void NPLBOMKAKCC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1185f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void JBDDMHGHOBM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 614f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void MNCPGFAHIFH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 987f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void ADLJNFLALKE()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 193f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void JJEONLDHCLO()
	{
		base.MLBAFICPECE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		HBBKGCJEDNO(LJGGJMAFEBN.Corner);
	}

	private void AKIDPDBEHFE()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1797f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		base.enemyPointType = LJGGJMAFEBN.Corner;
	}

	private void EIHNEMHDMKN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 505f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void FDGKIKCELDJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 752f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void PNCPCHDFBOB()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		KMPIAKMBIFL(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		EMKAJOADOIH(LJGGJMAFEBN.Corner);
	}

	protected virtual void OBEHLLBBEIL()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		IOIIEDDBIKD(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
	}

	protected virtual void BAGCDJMLCPF()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		CAEMAAMICOF(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
	}

	protected virtual void HOINLOMCGFD()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		EMKAJOADOIH(LJGGJMAFEBN.Corner);
	}

	private void GADEJINLIDD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 111f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void DMMNDFHGEJJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 124f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void AAJINFILNOM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 395f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void ECMMDCKONDK()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		NGCBJNCNCCM(LJGGJMAFEBN.Hiding);
	}

	protected virtual void FGOAPPLNMKL()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		IOIIEDDBIKD(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	protected virtual void NAMAMGENMGH()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		KMPIAKMBIFL(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	protected virtual void OGFAHEALGFN()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		IOIIEDDBIKD(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	private void JLMECNBOEEM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 483f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void LFGGIMELBCN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 952f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void PFGGLEONLKM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1145f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void CNDFBJAMADI()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1377f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void IHIEAKFHLFG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1366f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void ILCIMEIBGAD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1269f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void IKCLJIAJAIL()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		NMLJBLGJCOA(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	private void OONACPNEMFN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1479f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void IIPMNCCFNIA()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		NMLJBLGJCOA(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
	}

	protected virtual void IEBHCNFALAB()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		EMKAJOADOIH(LJGGJMAFEBN.Rusher);
	}

	private void KBPCBKHDFCJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 603f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void GBGDKNIMGMB()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		NGCBJNCNCCM(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
	}

	protected virtual void NIAEEICNNHL()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		IOIIEDDBIKD(LJGGJMAFEBN.Rusher);
	}

	private void AHDPDKEJJGJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1558f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void HEKKOLIHJDB()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1140f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void FBGDIBLANFO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1493f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void GIKGEIGMKNF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 271f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void OLBEOPKDEBJ()
	{
		PJEMCLFLGBL();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		HBBKGCJEDNO(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
	}

	protected virtual void OMDILMPFKII()
	{
		base.MLBAFICPECE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		base.enemyPointType = LJGGJMAFEBN.Hiding;
	}

	protected virtual void MMBMHLABBKN()
	{
		CFGDCEOLKJG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		NMLJBLGJCOA(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
	}

	protected virtual void KECNIEGEDBP()
	{
		PJEMCLFLGBL();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		base.enemyPointType = LJGGJMAFEBN.Car;
	}

	private void GFKBAOIJMJM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 967f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void KABFLGDJBMC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1850f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		base.enemyPointType = LJGGJMAFEBN.Corner;
	}

	private void KACCKHHMHOF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 648f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void GEPHFAECCII()
	{
		KNLKFOHBCKI();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		base.enemyPointType = (LJGGJMAFEBN)0;
	}

	protected virtual void CJOLAJGALCD()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		base.enemyPointType = LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner;
	}

	private void HPKANLKCPKO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 797f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	private void LLEKNBNBGKD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1661f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + PLEBANKIBPP);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.Cross(PLEBANKIBPP, (!NHKBMMIHAFH) ? (-Vector3.up) : Vector3.up));
	}

	protected virtual void HMMKNCDDDLH()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		EMKAJOADOIH(LJGGJMAFEBN.Corner);
	}

	protected virtual void IGOMLJOMFGA()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		HBBKGCJEDNO(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		IOIIEDDBIKD((LJGGJMAFEBN)0);
	}
}
