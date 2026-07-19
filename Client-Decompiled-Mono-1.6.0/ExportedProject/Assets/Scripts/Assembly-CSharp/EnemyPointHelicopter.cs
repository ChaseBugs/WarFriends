using UnityEngine;

public class EnemyPointHelicopter : EnemyPoint
{
	public Helicopter HCCENNJFGMA;

	public Transform MOIAAKCCFDI;

	private void GIEHJNFKJAH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1290f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 363f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 516f);
		}
	}

	protected override void IODPOHKAKNN()
	{
		base.IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		EMKAJOADOIH(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter);
	}

	protected virtual void BKNKFFEHJOA()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		HBBKGCJEDNO(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Tower));
	}

	protected virtual void OIKLJGMKMAE()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		base.enemyPointType = LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower;
	}

	private void DEEIFBABFMO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 442f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 782f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 1549f);
		}
	}

	protected override void KNLKFOHBCKI()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		EMKAJOADOIH(~(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Car | LJGGJMAFEBN.Swat));
	}

	protected virtual void EJNJCILPBEC()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		NMLJBLGJCOA(~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower));
	}

	private void MPMNGLJDNKK()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1296f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1115f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 1854f);
		}
	}

	private void PPOCKBMLMEA()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 293f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 196f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 271f);
		}
	}

	private void GLCONDAAKHC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 11f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 554f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 115f);
		}
	}

	private void MAKPKDNNJKG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 867f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1465f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 642f);
		}
	}

	protected virtual void BAGCDJMLCPF()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		HBBKGCJEDNO(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Tower);
	}

	protected virtual void GBGDKNIMGMB()
	{
		MLBAFICPECE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		CAEMAAMICOF(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Tower));
	}

	protected virtual void FIEKOBKAHKA()
	{
		base.KNLKFOHBCKI();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		base.enemyPointType = ~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Tower);
	}

	protected virtual void IOKMAFLIJEG()
	{
		base.KNLKFOHBCKI();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		MMPAHCDHGCN(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Car | LJGGJMAFEBN.Swat));
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		base.enemyPointType = LJGGJMAFEBN.Helicopter;
	}

	protected virtual void IABJJOPLKFF()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		base.enemyPointType = LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat;
	}

	protected virtual void HMMKNCDDDLH()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		EMKAJOADOIH(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Tower);
	}

	private void FGIOPBBNHLB()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 167f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1103f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 7f);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 2f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 0.03f);
		}
	}

	private void EIPHAAOKAFD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1003f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1038f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 1000f);
		}
	}

	private void HHLLINDJOLB()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1386f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 336f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 707f);
		}
	}

	private void LOIBFJMMJGC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1109f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1372f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 1734f);
		}
	}

	private void KBPCBKHDFCJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1611f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 197f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 573f);
		}
	}

	protected virtual void MFKNMALEKKB()
	{
		base.IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		MMPAHCDHGCN(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter);
	}

	private void DMMNDFHGEJJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1929f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 390f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 1473f);
		}
	}

	protected virtual void HMBBGNKFNCK()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		EMKAJOADOIH(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower));
	}

	protected virtual void FIGOGIMJIIN()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		NMLJBLGJCOA(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Tower));
	}

	private void DKCEANEBPDD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1525f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1090f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 461f);
		}
	}

	protected virtual void EIPLFPJNCIB()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.CornerHiding;
		MMPAHCDHGCN(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower);
	}

	private void DODCNMMECKJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 13f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1094f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 358f);
		}
	}

	protected virtual void OLBEOPKDEBJ()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		HBBKGCJEDNO(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Swat);
	}

	private void GFADEDGHLFC()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 179f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 325f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 1062f);
		}
	}

	protected virtual void KODJIPJGFPB()
	{
		PJEMCLFLGBL();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		KMPIAKMBIFL(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Car);
	}

	protected virtual void BMLLLOBPGIB()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		KMPIAKMBIFL(~(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Swat));
	}

	private void GIGEHNNOMGP()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1786f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1800f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 98f);
		}
	}

	protected virtual void PCDHCIDJJOB()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		HBBKGCJEDNO(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower);
	}

	protected virtual void DCKJHAILENK()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		base.enemyPointType = LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Tower;
	}

	private void ABBGKOIPHJK()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1055f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 410f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 88f);
		}
	}

	private void IHLLGADCCKI()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 939f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 1478f);
		if (MOIAAKCCFDI != null)
		{
			Gizmos.DrawWireCube(MOIAAKCCFDI.position, Vector3.one * 198f);
		}
	}

	protected virtual void FNJKFDOMGOO()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		HBBKGCJEDNO(~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat));
	}
}
