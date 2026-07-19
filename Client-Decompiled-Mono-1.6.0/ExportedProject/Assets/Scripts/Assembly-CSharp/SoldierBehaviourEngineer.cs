using System.Runtime.CompilerServices;
using UnityEngine;

public class SoldierBehaviourEngineer : SoldierBehaviourGeneric<SoldierBehaviourDefinititonEngineer>
{
	private Turret IBBCIFFPJAO;

	public virtual void BHGHJDMLFEF()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.DKNHCGGKNMF().AHDKOOJNKDM(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.MIMGHFFPHED(turretUpgradeLevel, 1187f, 1089f);
			LMNPOINIJBD.transform.localScale = new Vector3(800f, 1605f, 436f);
			LMNPOINIJBD.transform.localPosition = new Vector3(527f, 1116f, 868f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1282f, 26f, 970f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(823f, 803f, 1989f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1192f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[0].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool BLBMOPEFNHL(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LOIJJLGGNFN() == (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.HIBCKDBMHIM())
		{
			return true;
		}
		return true;
	}

	private void OCAPNHHGAOM()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.GPCIHICHOJB().InvokeAfter(KOICLDIKEKM, 476f);
		}
	}

	public virtual bool HDMJFIKLLNF(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LOIJJLGGNFN() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car) && LMNPOINIJBD.fraction == PLMMBKGLGAB.MMEJGAPHKPJ())
		{
			return true;
		}
		return true;
	}

	private void OMHGIENIOMF()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.pool.InvokeAfter(BLHMDLKPKCL, 985f);
		}
	}

	private void PBDCPELCEKL()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.pool.InvokeAfter(BJKPPEPAGKF, 568f);
		}
	}

	public virtual void CACKPKEOGAC()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.DKNHCGGKNMF().KBBMHOCIMCE(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.LoadUpgrades(turretUpgradeLevel, 956f, 1246f);
			LMNPOINIJBD.transform.localScale = new Vector3(680f, 62f, 1906f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1442f, 1567f, 1486f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(128f, 366f, 1681f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(508f, 1222f, 459f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1815f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[2].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void LAHPOKILGCB()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.pool.InvokeAfter(BJKPPEPAGKF, 1019f);
		}
	}

	private void BDEJKLDJOAB()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(NIGGCFEKIJC, 1428f);
		}
	}

	public virtual bool FNGEPAICIPD(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.CNGHKNPJAPN() == ~(EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.JJDDKGIGJNI())
		{
			return false;
		}
		return true;
	}

	private void LPBEHKGFLCK()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(true);
			IBBCIFFPJAO = null;
		}
	}

	public virtual bool AGFAGOILGBG(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GIEIGPKGGNL() == ~(EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.BKIIMANDLPL())
		{
			return false;
		}
		return false;
	}

	public virtual bool FEIBHPGBOIE(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.enemyPointType == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat) && LMNPOINIJBD.fraction == PLMMBKGLGAB.JJDDKGIGJNI())
		{
			return false;
		}
		return false;
	}

	private void BKBDBBCDEID()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DestroyPooled(true);
			IBBCIFFPJAO = null;
		}
	}

	public virtual void LNLAOLAGONJ()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.COJFMKNGPBP().CNEDMJIOECH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NCPCPJAKNKG(turretUpgradeLevel, 1873f, 1879f);
			LMNPOINIJBD.transform.localScale = new Vector3(1244f, 782f, 1818f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1508f, 99f, 929f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(710f, 20f, 1774f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(899f, 1372f, 1564f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1368f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[6].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool LPKHMEFCDGG(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GIEIGPKGGNL() == ~(EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.IOPIBCMGGDG())
		{
			return true;
		}
		return true;
	}

	public virtual bool DGNJMAOOEDK(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.MODBJDDNNFN() == (EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat) && LMNPOINIJBD.fraction == PLMMBKGLGAB.MMEJGAPHKPJ())
		{
			return true;
		}
		return true;
	}

	private void NBOFOMCLHDB()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.GPCIHICHOJB().InvokeAfter(AFGLNNEHJGI, 438f);
		}
	}

	public virtual bool BGELKCEGEOA(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LJPBPIDDMAE() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.JJDDKGIGJNI())
		{
			return true;
		}
		return false;
	}

	public virtual void ENCFDPPMCHM()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.EHFPBDJMGNC().CNEDMJIOECH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.PGINELKGAFK(turretUpgradeLevel, 1107f, 1962f);
			LMNPOINIJBD.transform.localScale = new Vector3(1209f, 1031f, 402f);
			LMNPOINIJBD.transform.localPosition = new Vector3(433f, 258f, 497f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(817f, 1946f, 590f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(469f, 1884f, 241f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1846f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[2].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void OEMEEOJNPJC()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.KJEANKAJELG().JCMCILKEKPH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.PFIDMIMPGDI(turretUpgradeLevel, 1965f, 1913f);
			LMNPOINIJBD.transform.localScale = new Vector3(509f, 797f, 1649f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1687f, 1954f, 1765f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(947f, 877f, 1569f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1014f, 376f, 1583f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1228f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[7].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool CBKPNJDKDJO(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GIEIGPKGGNL() == (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Tower | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.KGMCJIICFKH())
		{
			return true;
		}
		return false;
	}

	public virtual void EFFBPGKAJGJ()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.CHHLLIAHECC().IONKGACHEBC(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.ALGKGBMDJMO(turretUpgradeLevel, 968f, 987f);
			LMNPOINIJBD.transform.localScale = new Vector3(609f, 1847f, 316f);
			LMNPOINIJBD.transform.localPosition = new Vector3(750f, 1509f, 1072f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(906f, 1012f, 957f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1197f, 718f, 650f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1175f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[7].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void MOFBJDBPONG()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(NIGGCFEKIJC, 280f);
		}
	}

	public virtual void FDNOBHBNPDB()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.DFCOIAFKJNF(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.KJEANKAJELG().ReInstantiate(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NCPCPJAKNKG(turretUpgradeLevel, 1360f, 929f);
			LMNPOINIJBD.transform.localScale = new Vector3(1663f, 180f, 1175f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1581f, 1588f, 1646f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1522f, 1949f, 436f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1912f, 1341f, 1426f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1849f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[0].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool CIEIBJPKLAA(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.NDFKANKCFFO() == ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat) && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return false;
		}
		return false;
	}

	private void LMKLHLJLBJK()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CPKCGEKEKFC().InvokeAfter(BJKPPEPAGKF, 864f);
		}
	}

	public virtual bool JBAMNJPGPDK(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GIEIGPKGGNL() == (EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.HIALJKICLKJ())
		{
			return false;
		}
		return false;
	}

	private void LPHJNCNHNOH()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CPKCGEKEKFC().InvokeAfter(PGBNCBFBBCE, 1294f);
		}
	}

	private void NIGGCFEKIJC()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(false);
			IBBCIFFPJAO = null;
		}
	}

	private void PGBNCBFBBCE()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CADILLCGODA(true);
			IBBCIFFPJAO = null;
		}
	}

	public virtual void FHLFOMHLIOB()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.INOJHPIKICM().KBBMHOCIMCE(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.LoadUpgrades(turretUpgradeLevel, 1142f, 1963f);
			LMNPOINIJBD.transform.localScale = new Vector3(1456f, 1390f, 373f);
			LMNPOINIJBD.transform.localPosition = new Vector3(475f, 1759f, 6f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1480f, 1855f, 1408f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(353f, 434f, 1993f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1309f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[6].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void PKEFNDAPFEJ()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.HOIPFFBPGJE().InvokeAfter(NIGGCFEKIJC, 1533f);
		}
	}

	public virtual void NBPBGOKPEAP()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.GLHPLCEFHGD().FLKHKLDOAPD(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.PFIDMIMPGDI(turretUpgradeLevel, 1618f, 417f);
			LMNPOINIJBD.transform.localScale = new Vector3(1349f, 543f, 511f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1820f, 400f, 448f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(242f, 1142f, 498f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(211f, 1959f, 1473f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1904f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[6].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void HJNELKJFGNC()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.EHFPBDJMGNC().JCMCILKEKPH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.BDJKFLECLPJ(turretUpgradeLevel, 1771f, 744f);
			LMNPOINIJBD.transform.localScale = new Vector3(142f, 35f, 1622f);
			LMNPOINIJBD.transform.localPosition = new Vector3(523f, 90f, 1960f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1189f, 524f, 1933f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(925f, 1880f, 1539f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 832f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[2].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void ELFCDOGGGNE()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.COJFMKNGPBP().ReInstantiate(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.CHAKBPGHBMO(turretUpgradeLevel, 161f, 1516f);
			LMNPOINIJBD.transform.localScale = new Vector3(1214f, 1703f, 949f);
			LMNPOINIJBD.transform.localPosition = new Vector3(737f, 644f, 1043f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1746f, 1437f, 349f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(408f, 50f, 1505f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 30f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[4].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void PLBKFECHHBL()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.HOIPFFBPGJE().InvokeAfter(KOICLDIKEKM, 439f);
		}
	}

	public virtual bool CDNJLMKIOJL(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LJPBPIDDMAE() == ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.KGMCJIICFKH())
		{
			return true;
		}
		return true;
	}

	private void BNEPAADIDHA()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CADILLCGODA(false);
			IBBCIFFPJAO = null;
		}
	}

	public virtual void GGFPFMJJGHH()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.COJFMKNGPBP().FLKHKLDOAPD(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.GELHOKLACJI(turretUpgradeLevel, 310f, 1760f);
			LMNPOINIJBD.transform.localScale = new Vector3(641f, 74f, 1213f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1845f, 1080f, 1532f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(265f, 1794f, 89f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1551f, 1185f, 18f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 610f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[1].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void CKKDBLGHFHM()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.HOIPFFBPGJE().InvokeAfter(AFGLNNEHJGI, 1557f);
		}
	}

	private void JPBKFGANOFC()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(MNOPKNJPMHN, 585f);
		}
	}

	private void KOICLDIKEKM()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(false);
			IBBCIFFPJAO = null;
		}
	}

	private void HNGMDEHDNCK()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(BNEPAADIDHA, 1421f);
		}
	}

	public override bool AcceptsPoint(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.enemyPointType == EnemyPoint.LJGGJMAFEBN.EngineerTurret && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return true;
		}
		return false;
	}

	private void LDBLOMHCGCP()
	{
		if (!(IBBCIFFPJAO != null))
		{
			return;
		}
		IBBCIFFPJAO.HOIPFFBPGJE().InvokeAfter(delegate
		{
			if (IBBCIFFPJAO != null)
			{
				IBBCIFFPJAO.DestroyPooled(true);
				IBBCIFFPJAO = null;
			}
		}, 1464f);
	}

	private void MFOINHMAMAM()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.GPCIHICHOJB().InvokeAfter(PGBNCBFBBCE, 645f);
		}
	}

	private void HNIEHMCOKFE()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(true);
			IBBCIFFPJAO = null;
		}
	}

	public virtual bool OELGOOBFGOE(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.NDFKANKCFFO() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat) && LMNPOINIJBD.fraction == PLMMBKGLGAB.BKIIMANDLPL())
		{
			return false;
		}
		return false;
	}

	private void DKDGNDJAEEJ()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DestroyPooled(false);
			IBBCIFFPJAO = null;
		}
	}

	[CompilerGenerated]
	private void DFBCOKFCMBF()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DestroyPooled(true);
			IBBCIFFPJAO = null;
		}
	}

	public virtual bool MFKLMDFBLBB(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LJPBPIDDMAE() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return false;
		}
		return false;
	}

	private void AFGLNNEHJGI()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(true);
			IBBCIFFPJAO = null;
		}
	}

	public override void UpdateVisual()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.networkPool.ReInstantiate(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.LoadUpgrades(turretUpgradeLevel, 1f, 1f);
			LMNPOINIJBD.transform.localScale = new Vector3(0.666f, 0.666f, 0.666f);
			LMNPOINIJBD.transform.localPosition = new Vector3(0.09f, -0.16f, 0f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(-0.25f, 0f, 0f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(0f, 28f, 0f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 0.9f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[2].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void HLHOGLHNNCE()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.EHFPBDJMGNC().AHDKOOJNKDM(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NMLCCBCEOEC(turretUpgradeLevel, 52f, 803f);
			LMNPOINIJBD.transform.localScale = new Vector3(1814f, 1959f, 1843f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1994f, 916f, 1954f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1546f, 1329f, 1693f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(237f, 509f, 710f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1606f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[3].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void ADEJENIDPBB()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.HOIPFFBPGJE().InvokeAfter(BKBDBBCDEID, 1879f);
		}
	}

	public virtual void MOJCIOCOKGE()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.networkPool.IJKKOCDFLAF(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.GBKEEACPOKD(turretUpgradeLevel, 1235f, 1205f);
			LMNPOINIJBD.transform.localScale = new Vector3(127f, 1703f, 804f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1842f, 929f, 653f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1302f, 1728f, 1686f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1419f, 225f, 781f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1034f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[0].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void EJADDPBAMEN()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.INOJHPIKICM().ReInstantiate(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.HEAOGPGJNEE(turretUpgradeLevel, 1960f, 683f);
			LMNPOINIJBD.transform.localScale = new Vector3(48f, 952f, 510f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1632f, 1693f, 1480f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(421f, 85f, 994f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(592f, 310f, 1724f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1362f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[6].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void MCOKBDIIFIN()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.KKCMCNCCIMB().CNEDMJIOECH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NMLCCBCEOEC(turretUpgradeLevel, 1999f, 1811f);
			LMNPOINIJBD.transform.localScale = new Vector3(1064f, 1292f, 1562f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1938f, 20f, 213f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(724f, 635f, 613f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1153f, 988f, 1037f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1742f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[5].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void JLMKIALFLPN()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.KJEANKAJELG().FLKHKLDOAPD(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.CHAKBPGHBMO(turretUpgradeLevel, 1484f, 1429f);
			LMNPOINIJBD.transform.localScale = new Vector3(518f, 453f, 1070f);
			LMNPOINIJBD.transform.localPosition = new Vector3(471f, 1186f, 398f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1521f, 1334f, 1119f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1797f, 272f, 1264f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 426f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[3].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void NFDBPEIMGJP()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.ADBOHNCGKHA().JCMCILKEKPH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.LoadUpgrades(turretUpgradeLevel, 683f, 1044f);
			LMNPOINIJBD.transform.localScale = new Vector3(1038f, 443f, 1105f);
			LMNPOINIJBD.transform.localPosition = new Vector3(689f, 284f, 1159f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1220f, 1838f, 1070f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(399f, 1606f, 1163f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 582f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[5].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void CPIIPHHBDCH()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.GPCIHICHOJB().InvokeAfter(KOICLDIKEKM, 1277f);
		}
	}

	private void AGLAMANMHCC()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(PGBNCBFBBCE, 618f);
		}
	}

	public virtual void GCGLHJIPDOL()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.GLHPLCEFHGD().JCMCILKEKPH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NMLCCBCEOEC(turretUpgradeLevel, 1074f, 1273f);
			LMNPOINIJBD.transform.localScale = new Vector3(290f, 1969f, 799f);
			LMNPOINIJBD.transform.localPosition = new Vector3(677f, 774f, 998f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1037f, 1392f, 629f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1251f, 1419f, 1614f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1398f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[2].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool LHBOPDKLHML(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.HECCAFJBKGP() == (EnemyPoint.LJGGJMAFEBN)(-1) && LMNPOINIJBD.fraction == PLMMBKGLGAB.HIALJKICLKJ())
		{
			return true;
		}
		return false;
	}

	public virtual bool BINNOIADPGD(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.CNGHKNPJAPN() == ~(EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.MHLKAEOAGAM())
		{
			return true;
		}
		return false;
	}

	public virtual void DMBMBHOKMFJ()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.DFCOIAFKJNF(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.INOJHPIKICM().CNEDMJIOECH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.PFIDMIMPGDI(turretUpgradeLevel, 185f, 166f);
			LMNPOINIJBD.transform.localScale = new Vector3(1724f, 420f, 781f);
			LMNPOINIJBD.transform.localPosition = new Vector3(119f, 438f, 1519f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(873f, 363f, 298f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(860f, 456f, 1752f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 459f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[1].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void HMBBGDEKADL()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.GPCIHICHOJB().InvokeAfter(BKBDBBCDEID, 314f);
		}
	}

	private void LMMLAGGEEBE()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.pool.InvokeAfter(MNOPKNJPMHN, 641f);
		}
	}

	public virtual bool NGDPCPKLBAL(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.enemyPointType == ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.KGMCJIICFKH())
		{
			return true;
		}
		return true;
	}

	private void OJCPMGNGCLC()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.HOIPFFBPGJE().InvokeAfter(NINHLODFBHB, 827f);
		}
	}

	public virtual void GEDPOKDJIGK()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.DKNHCGGKNMF().CNEDMJIOECH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.AKECILCKHOI(turretUpgradeLevel, 948f, 782f);
			LMNPOINIJBD.transform.localScale = new Vector3(1976f, 1166f, 429f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1540f, 284f, 1847f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1009f, 442f, 92f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1107f, 1693f, 634f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1753f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[1].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void HDOEOLNKGAL()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.KKCMCNCCIMB().JCMCILKEKPH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NCPCPJAKNKG(turretUpgradeLevel, 1475f, 255f);
			LMNPOINIJBD.transform.localScale = new Vector3(1401f, 1015f, 826f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1557f, 948f, 95f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(473f, 1088f, 1083f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1854f, 897f, 1844f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1000f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[0].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool OBPKHKLPAAM(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LJPBPIDDMAE() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.JJDDKGIGJNI())
		{
			return true;
		}
		return false;
	}

	private void LCCGPBIPOMO()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.KIFFEEEDFPD(false);
			IBBCIFFPJAO = null;
		}
	}

	private void OnDisable()
	{
		if (!(IBBCIFFPJAO != null))
		{
			return;
		}
		IBBCIFFPJAO.pool.InvokeAfter(delegate
		{
			if (IBBCIFFPJAO != null)
			{
				IBBCIFFPJAO.DestroyPooled(true);
				IBBCIFFPJAO = null;
			}
		}, 0.005f);
	}

	private void KLJLKHHDOCH()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(false);
			IBBCIFFPJAO = null;
		}
	}

	public virtual bool IHKOCLJHNMB(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LOIJJLGGNFN() == ~(EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.MMEJGAPHKPJ())
		{
			return true;
		}
		return false;
	}

	public virtual void JNIFEHAODFJ()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.MFKPDKCLDBI().IJKKOCDFLAF(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NMLCCBCEOEC(turretUpgradeLevel, 960f, 1632f);
			LMNPOINIJBD.transform.localScale = new Vector3(1352f, 938f, 1301f);
			LMNPOINIJBD.transform.localPosition = new Vector3(958f, 391f, 1532f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(667f, 277f, 1826f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(863f, 630f, 702f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 673f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[3].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void GPABBGFMLMB()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CPKCGEKEKFC().InvokeAfter(BNEPAADIDHA, 1737f);
		}
	}

	public virtual bool PLCGHKODDGG(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GNEHPIPGJCO() == ~(EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Swat) && LMNPOINIJBD.fraction == PLMMBKGLGAB.EJDFGMKHGLN())
		{
			return true;
		}
		return true;
	}

	public virtual void BJFGBPJIEMO()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.DFCOIAFKJNF(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.KJEANKAJELG().IONKGACHEBC(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.MIMGHFFPHED(turretUpgradeLevel, 681f, 1010f);
			LMNPOINIJBD.transform.localScale = new Vector3(1422f, 247f, 1034f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1654f, 1699f, 1644f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1207f, 374f, 1670f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(954f, 1587f, 1145f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1923f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[1].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void EIJBFECDNLC()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.pool.InvokeAfter(BLHMDLKPKCL, 441f);
		}
	}

	public virtual void BLKALEPEOJD()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.MFKPDKCLDBI().IJKKOCDFLAF(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.PCPPJDBPOGP(turretUpgradeLevel, 938f, 1531f);
			LMNPOINIJBD.transform.localScale = new Vector3(1786f, 737f, 603f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1975f, 1303f, 1591f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(779f, 1100f, 1469f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1870f, 1754f, 1266f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 28f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[0].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool LOPOFPLHEIG(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GIEIGPKGGNL() == ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.HIBCKDBMHIM())
		{
			return false;
		}
		return false;
	}

	public virtual void FLEDEBNMJJN()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = false;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.networkPool.PKFDDOIEMMC(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.GBKEEACPOKD(turretUpgradeLevel, 319f, 365f);
			LMNPOINIJBD.transform.localScale = new Vector3(1212f, 1139f, 1668f);
			LMNPOINIJBD.transform.localPosition = new Vector3(981f, 1006f, 286f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(1598f, 887f, 1433f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(758f, 1683f, 1701f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1284f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[2].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void NINHLODFBHB()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CADILLCGODA(true);
			IBBCIFFPJAO = null;
		}
	}

	public virtual void NEMACGCHBIC()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.INOJHPIKICM().AHDKOOJNKDM(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NMLCCBCEOEC(turretUpgradeLevel, 1111f, 1071f);
			LMNPOINIJBD.transform.localScale = new Vector3(38f, 949f, 924f);
			LMNPOINIJBD.transform.localPosition = new Vector3(745f, 410f, 1513f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(525f, 552f, 405f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1523f, 454f, 1653f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 657f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[6].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool BBPIBEIALHJ(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.HECCAFJBKGP() == ~EnemyPoint.LJGGJMAFEBN.Tower && LMNPOINIJBD.fraction == PLMMBKGLGAB.HIBCKDBMHIM())
		{
			return true;
		}
		return false;
	}

	public virtual void HICIDICJFIP()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.DKNHCGGKNMF().FLKHKLDOAPD(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.FLADGPDKIJC(turretUpgradeLevel, 813f, 1859f);
			LMNPOINIJBD.transform.localScale = new Vector3(708f, 515f, 1476f);
			LMNPOINIJBD.transform.localPosition = new Vector3(648f, 249f, 1957f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(878f, 1392f, 993f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1852f, 1665f, 519f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 146f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[1].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual void BAGHBNOAKOG()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.MFKPDKCLDBI().FLKHKLDOAPD(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.AKECILCKHOI(turretUpgradeLevel, 266f, 12f);
			LMNPOINIJBD.transform.localScale = new Vector3(66f, 1811f, 1085f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1798f, 1385f, 557f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(895f, 762f, 1633f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(924f, 1905f, 291f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 244f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[2].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void MNOPKNJPMHN()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DestroyPooled(true);
			IBBCIFFPJAO = null;
		}
	}

	public virtual bool GCCFCPDJILD(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GIEIGPKGGNL() == (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.IPFNDJEGKKJ())
		{
			return false;
		}
		return false;
	}

	private void OCKJKHIDPMB()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(LCCGPBIPOMO, 643f);
		}
	}

	public virtual void JDCFLCMKDAD()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.MFKPDKCLDBI().IJKKOCDFLAF(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.ODEMIFCLJHM(turretUpgradeLevel, 1760f, 212f);
			LMNPOINIJBD.transform.localScale = new Vector3(1119f, 436f, 1781f);
			LMNPOINIJBD.transform.localPosition = new Vector3(1003f, 727f, 1148f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(546f, 1554f, 1553f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(743f, 63f, 1629f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 1898f;
			IBBCIFFPJAO.LCDBACDIODH = true;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[1].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool CMFDDAJBNPE(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LOIJJLGGNFN() == ~(EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.HIALJKICLKJ())
		{
			return false;
		}
		return false;
	}

	private void BJKPPEPAGKF()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(false);
			IBBCIFFPJAO = null;
		}
	}

	private void OPPIIAAJLGI()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CPKCGEKEKFC().InvokeAfter(BLHMDLKPKCL, 1697f);
		}
	}

	public virtual bool JNILBKMCAAG(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LJPBPIDDMAE() == ~EnemyPoint.LJGGJMAFEBN.Swat && LMNPOINIJBD.fraction == PLMMBKGLGAB.MHLKAEOAGAM())
		{
			return false;
		}
		return true;
	}

	private void FAJECMGKJNH()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.CPKCGEKEKFC().InvokeAfter(BLHMDLKPKCL, 991f);
		}
	}

	private void BLHMDLKPKCL()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(false);
			IBBCIFFPJAO = null;
		}
	}

	public virtual bool HBPPLCJFHOA(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LJPBPIDDMAE() == ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Minigunner) && LMNPOINIJBD.fraction == PLMMBKGLGAB.IPFNDJEGKKJ())
		{
			return false;
		}
		return false;
	}

	private void LPDBJCDCBIF()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.pool.InvokeAfter(LCCGPBIPOMO, 620f);
		}
	}

	private void PBMPOAPKHHO()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(LCCGPBIPOMO, 625f);
		}
	}

	public virtual bool DCPNDEGCLNE(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GIEIGPKGGNL() == (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.MHLKAEOAGAM())
		{
			return false;
		}
		return false;
	}

	public virtual void DFEMFEEFGPG()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.GLHPLCEFHGD().PKFDDOIEMMC(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.CHAKBPGHBMO(turretUpgradeLevel, 5f, 1091f);
			LMNPOINIJBD.transform.localScale = new Vector3(1013f, 1255f, 317f);
			LMNPOINIJBD.transform.localPosition = new Vector3(944f, 1161f, 1590f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(283f, 1947f, 1441f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(1800f, 537f, 160f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 677f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[1].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	public virtual bool CHHDCPELFJO(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.enemyPointType == ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Helicopter) && LMNPOINIJBD.fraction == PLMMBKGLGAB.MMEJGAPHKPJ())
		{
			return false;
		}
		return false;
	}

	private void HBOFFGPBILN()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(false);
			IBBCIFFPJAO = null;
		}
	}

	private void IHFMHGANBAG()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(false);
			IBBCIFFPJAO = null;
		}
	}

	private void GLMOJIBOION()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(MNOPKNJPMHN, 917f);
		}
	}

	public virtual bool NCIMOAKHLBA(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.GNEHPIPGJCO() == ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.IOPIBCMGGDG())
		{
			return false;
		}
		return true;
	}

	public virtual bool GBPCBJNILOL(EnemyPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.LJPBPIDDMAE() == (EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Tower) && LMNPOINIJBD.fraction == PLMMBKGLGAB.HIALJKICLKJ())
		{
			return true;
		}
		return false;
	}

	private void HGOOCNGGJGH()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.GPCIHICHOJB().InvokeAfter(MNOPKNJPMHN, 303f);
		}
	}

	public virtual void NGDPJLMPEEJ()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.LCDBACDIODH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (IBBCIFFPJAO == null)
			{
				AIObject aIObject = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
				aIObject.LCDBACDIODH = true;
				IBBCIFFPJAO = (Turret)ObjectPoolDatabase.KJEANKAJELG().CNEDMJIOECH(aIObject);
				IBBCIFFPJAO.transform.parent = LMNPOINIJBD.gameObject.transform;
			}
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)base.soldierBehaviourDefinititon).turretUpgradeLevel;
			IBBCIFFPJAO.HideShadow();
			IBBCIFFPJAO.NCPCPJAKNKG(turretUpgradeLevel, 1135f, 1167f);
			LMNPOINIJBD.transform.localScale = new Vector3(1209f, 1528f, 300f);
			LMNPOINIJBD.transform.localPosition = new Vector3(840f, 237f, 950f);
			IBBCIFFPJAO.transform.localPosition = new Vector3(996f, 1965f, 1404f);
			IBBCIFFPJAO.transform.localRotation = Quaternion.Euler(242f, 1790f, 1436f);
			IBBCIFFPJAO.transform.localScale = Vector3.one * 716f;
			IBBCIFFPJAO.LCDBACDIODH = false;
			ArmyUnit3DModel component = LMNPOINIJBD.GetComponent<ArmyUnit3DModel>();
			component.FLLKOAEGNDE[7].slotPosition = IBBCIFFPJAO.JDBBANOJKAD.transform;
		}
	}

	private void ALDIDDMLJMA()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.pool.InvokeAfter(PGBNCBFBBCE, 1943f);
		}
	}

	private void FHLJPMAEMAO()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.GPCIHICHOJB().InvokeAfter(NINHLODFBHB, 970f);
		}
	}

	private void MBHBDEOMMOL()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.DINLNPNCJMH().InvokeAfter(BLHMDLKPKCL, 1827f);
		}
	}

	private void DJBMAIHBAIJ()
	{
		if (IBBCIFFPJAO != null)
		{
			IBBCIFFPJAO.JLHMFBILMCF(true);
			IBBCIFFPJAO = null;
		}
	}
}
