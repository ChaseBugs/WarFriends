using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourRusher<T> : SoldierBehaviourGeneric<T> where T : SoldierBehaviourDefinititon
{
	protected void KFJGJAECCHM()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.KEEKOJBIBEC().JPHAJDIIAAI().OLOPPGKIJNF() != null)
		{
			PlayerController playerController = enemyPointRusher.PPKCJIDHOPO().PHANADCNBFD().FCBGHBODHHP();
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI(~(GameShootableEntity.LAAAMBBNIJO.WholeBody | GameShootableEntity.LAAAMBBNIJO.Out), LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual EnemyPoint ABBCMDNANKO()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = randomEnemy.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 5)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1568f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.MMDCNGCOLEP())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.MOOGMFPMKEM());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Minigunner;
		return SpawningManager.LDGAKJJINEO().GBCNMJIJJKM(this, 31f);
	}

	protected void IHNJOOPLKNM()
	{
		NFGCPLPKAIP = true;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.PJHMKOJGKEP().LHHMNLJKOAO().NPOMEBDPBGL() != null)
		{
			PlayerController player = enemyPointRusher.PPKCJIDHOPO().CGKKGILAAPG().player;
			GameShootableEntity gameShootableEntity = player.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)35, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual bool BDBENOPBIBH(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 0;
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = randomEnemy.EMAMENNDFMB();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.NNDGHFOLJIB())
				{
					num += 0;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return false;
	}

	protected void MMPFEDFKKKJ()
	{
		NFGCPLPKAIP = true;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.EIGJJAGIBHI().shield.player != null)
		{
			PlayerController playerController = enemyPointRusher.playerPoint.LHHMNLJKOAO().OLOPPGKIJNF();
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)(-90), LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual bool PIELHNLDMEP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = randomEnemy.CMNFFACHCEE();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.NNDGHFOLJIB())
				{
					num += 0;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return true;
	}

	public virtual EnemyPoint KMHGEBCGKPH()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.CMNFFACHCEE().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 4)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1946f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.EHGKKKBCKCL())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.KOFFAHEAHEN());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Swat);
		return SpawningManager.LDGAKJJINEO().GetPoint(this, 447f);
	}

	public override bool CanBeSpawned(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 0;
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(ACJIGOBMLNH);
		MapDefinition.DefendPosition currentPlayerPoint = randomEnemy.currentPlayerPoint;
		if (currentPlayerPoint != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = currentPlayerPoint.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.isFree)
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	protected void BGOMBAFNGIJ()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.playerPoint.shield.player != null)
		{
			PlayerController player = enemyPointRusher.playerPoint.shield.player;
			GameShootableEntity gameShootableEntity = player.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Moving, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual EnemyPoint HKOANOKNELB()
	{
		PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.BBNPGJAALCJ().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 5)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 841f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.JCOPEJOIIIH())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.position);
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 1 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower);
		return SpawningManager.OKBAIGKCPKA().GBCNMJIJJKM(this, 989f);
	}

	public virtual EnemyPoint BFDFJGOFBGC()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 0)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 722f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.JKJBGIGAKIN())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.PBFDGDPLFKN());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower);
		return SpawningManager.OKBAIGKCPKA().GBCNMJIJJKM(this, 1612f);
	}

	public virtual EnemyPoint CGKCMFFOMJL()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.CMNFFACHCEE().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 1)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 184f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.OAPIGEDOKEO())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.MGPNABOBKFP());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 1 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Helicopter);
		return SpawningManager.BMNEPICFHNO().LFJKDLGIFFK(this, 382f);
	}

	public virtual bool NJAOOOHLCJP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.FDMHGNEGHDD(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.EMAMENNDFMB();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.MMDCNGCOLEP())
				{
					num += 0;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return false;
	}

	protected void ANNKHLOILEI()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.AIJPMKFLBGD().LHHMNLJKOAO().OLOPPGKIJNF() != null)
		{
			PlayerController playerController = enemyPointRusher.DBOOMCAGLEM().CGKKGILAAPG().NPOMEBDPBGL();
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)(-62), LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual void JKEACDIPFAD()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Parachute)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	protected void OMDDCBLMDAA()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.BJIDLOCAOIJ().CGKKGILAAPG().OLOPPGKIJNF() != null)
		{
			PlayerController playerController = enemyPointRusher.AICFDBHBAJI().KJCHIHLJMMF().OLOPPGKIJNF();
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI((GameShootableEntity.LAAAMBBNIJO)89, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual EnemyPoint FINEJBFGDBM()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.CMNFFACHCEE().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 4)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1534f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.BNAALFJKAHB())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.KPOEEKLFALL());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower;
		return SpawningManager.LDGAKJJINEO().GetPoint(this, 1799f);
	}

	public virtual bool IPFCAJBPNJL(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = randomEnemy.EMAMENNDFMB();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.isFree)
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual bool GLNMDLBCLMP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.FDMHGNEGHDD(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.CMNFFACHCEE();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.NNDGHFOLJIB())
				{
					num += 0;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return false;
	}

	public virtual bool GKEKLCLHHNI(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = randomEnemy.BBNPGJAALCJ();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.DHBLIDKNANH())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return true;
	}

	protected void ODFFNFECJBE()
	{
		NFGCPLPKAIP = true;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.KEEKOJBIBEC().KJCHIHLJMMF().player != null)
		{
			PlayerController playerController = enemyPointRusher.playerPoint.LMHDAIBCLDP().FCBGHBODHHP();
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI((GameShootableEntity.LAAAMBBNIJO)(-96), LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	protected void LNAKLHDLGBM()
	{
		NFGCPLPKAIP = true;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.PJHMKOJGKEP().LMHDAIBCLDP().player != null)
		{
			PlayerController player = enemyPointRusher.BJIDLOCAOIJ().KJCHIHLJMMF().player;
			GameShootableEntity gameShootableEntity = player.IJPPJNNDFIB();
			GLNJNLEHCDC = gameShootableEntity.AJBDIKBDLEA(~GameShootableEntity.LAAAMBBNIJO.Shield, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public override void PickTarget()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Rusher)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
		GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual bool CMPLMBDGDBC(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 0;
		PlayerController playerController = PlayerController.FDMHGNEGHDD(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.CMNFFACHCEE();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.BNAALFJKAHB())
				{
					num += 0;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	protected void FDNFNCICLCM()
	{
		NFGCPLPKAIP = true;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.PJHMKOJGKEP().PHANADCNBFD().FCBGHBODHHP() != null)
		{
			PlayerController player = enemyPointRusher.EJJKBLJAFEA().PNKKPNIMEPL().player;
			GameShootableEntity gameShootableEntity = player.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)115, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual void MEIDANPLALC()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Parachute)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.AJBDIKBDLEA(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual EnemyPoint MFKFBPMGDBH()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.EMAMENNDFMB().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 6)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 650f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.PKKBHKIOOFN())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.KPOEEKLFALL());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Swat;
		return SpawningManager.instance.GetPoint(this, 875f);
	}

	public virtual EnemyPoint LMFNGIOEDPG()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.EMAMENNDFMB().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 7)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1570f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.EHGKKKBCKCL())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.PFOBADFGAKF());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat;
		return SpawningManager.BMNEPICFHNO().GetPoint(this, 1427f);
	}

	public virtual EnemyPoint KJPGNECKGCM()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.CMNFFACHCEE().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 2)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 560f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.OAPIGEDOKEO())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.position);
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Minigunner;
		return SpawningManager.LDGAKJJINEO().LFJKDLGIFFK(this, 1644f);
	}

	protected void NAMJKJMECDA()
	{
		NFGCPLPKAIP = true;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.AICFDBHBAJI().IGEDGCNJCAP().OLOPPGKIJNF() != null)
		{
			PlayerController playerController = enemyPointRusher.BJIDLOCAOIJ().PNKKPNIMEPL().OLOPPGKIJNF();
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)48, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual bool AMEJNHBFMEH(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.BAEIKGKJOIN(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.BBNPGJAALCJ();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.NNDGHFOLJIB())
				{
					num += 0;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return false;
	}

	public virtual EnemyPoint EPCILFNNLBI()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.BBNPGJAALCJ().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 0)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1776f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.IBCECFGPMJO())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.PFOBADFGAKF());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Swat | EnemyPoint.LJGGJMAFEBN.Tower);
		return SpawningManager.LDGAKJJINEO().GBCNMJIJJKM(this, 1881f);
	}

	public override EnemyPoint GetInitPoint()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = randomEnemy.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 4)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = float.MaxValue;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.isFree)
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.position);
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 1 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.RusherSpare;
		return SpawningManager.instance.GetPoint(this);
	}

	protected void JCAHJDCEKCN()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.EJJKBLJAFEA().PHANADCNBFD().player != null)
		{
			PlayerController player = enemyPointRusher.PJHMKOJGKEP().CGKKGILAAPG().player;
			GameShootableEntity gameShootableEntity = player.IJPPJNNDFIB();
			GLNJNLEHCDC = gameShootableEntity.AJBDIKBDLEA((GameShootableEntity.LAAAMBBNIJO)(-55), LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual bool CHEEGBEHEKK(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.BAEIKGKJOIN(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.CMNFFACHCEE();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.NNDGHFOLJIB())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual void BNEDFLKKADN()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Parachute)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.AJBDIKBDLEA(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual void BOFCCNAAJFK()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Parachute)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual void FLDHHGOPJDC()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Walk)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual EnemyPoint MLAHGMMBBII()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = randomEnemy.CMNFFACHCEE().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 7)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1166f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.NNDGHFOLJIB())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.PBFDGDPLFKN());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Minigunner);
		return SpawningManager.LDGAKJJINEO().GBCNMJIJJKM(this, 453f);
	}

	public virtual void AKIBHHFNAHO()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.ObstacleHiding)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual void PGCLGAOLBGL()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.CornerHiding)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual bool ALGBICAFHLK(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.BGEKNDDACNP(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.CMNFFACHCEE();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.JCOPEJOIIIH())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return false;
	}

	public virtual EnemyPoint BOIGOLELKFH()
	{
		PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 2)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1307f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.IBCECFGPMJO())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.position);
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 1 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Minigunner);
		return SpawningManager.BMNEPICFHNO().GBCNMJIJJKM(this, 1009f);
	}

	public virtual void PAJBIENJKJA()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Swat)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.IJPPJNNDFIB();
		GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.None, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual void JKONAMDNKPO()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Rusher)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
		GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	public virtual void KODMCNBGKGP()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Helicopter)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
		GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	protected void BCIODKGKPCI()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.DKFHIPIJJJG().KJCHIHLJMMF().player != null)
		{
			PlayerController playerController = enemyPointRusher.EJJKBLJAFEA().LHHMNLJKOAO().OLOPPGKIJNF();
			GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
			GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.None, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	protected void JIGGNEENLBE()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.PJHMKOJGKEP().CGKKGILAAPG().player != null)
		{
			PlayerController player = enemyPointRusher.DBOOMCAGLEM().CGKKGILAAPG().player;
			GameShootableEntity gameShootableEntity = player.IJPPJNNDFIB();
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(~(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Out), LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual bool MLHJFAGGCJF(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.BGEKNDDACNP(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.EMAMENNDFMB();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.DKCLHDBPKCI())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public virtual bool HNKBFNMAKJB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 0;
		PlayerController playerController = PlayerController.BAEIKGKJOIN(ACJIGOBMLNH);
		MapDefinition.DefendPosition currentPlayerPoint = playerController.currentPlayerPoint;
		if (currentPlayerPoint != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = currentPlayerPoint.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.JCOPEJOIIIH())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public virtual bool OIOIGOBAOMN(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 0;
		PlayerController playerController = PlayerController.FDMHGNEGHDD(ACJIGOBMLNH);
		MapDefinition.DefendPosition currentPlayerPoint = playerController.currentPlayerPoint;
		if (currentPlayerPoint != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = currentPlayerPoint.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.DKCLHDBPKCI())
				{
					num += 0;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return true;
	}

	public virtual EnemyPoint NHPDICDDBIC()
	{
		PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.BBNPGJAALCJ().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 2)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1285f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.JKJBGIGAKIN())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.PFOBADFGAKF());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Helicopter;
		return SpawningManager.LDGAKJJINEO().LFJKDLGIFFK(this, 745f);
	}

	public virtual bool GBCDICCLBKJ(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.BGEKNDDACNP(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.EMAMENNDFMB();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.PKKBHKIOOFN())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return false;
	}

	public virtual bool DMMFMLBBMMF(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.FDMHGNEGHDD(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.CMNFFACHCEE();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.NNDGHFOLJIB())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual EnemyPoint JPFPOMDKFAN()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 7)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 166f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.JCOPEJOIIIH())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.MOOGMFPMKEM());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 1 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Minigunner);
		return SpawningManager.BMNEPICFHNO().GetPoint(this, 1549f);
	}

	public virtual EnemyPoint DMJMJDNNPHD()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.CMNFFACHCEE().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 7)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 89f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.DKCLHDBPKCI())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.KOFFAHEAHEN());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Swat;
		return SpawningManager.LDGAKJJINEO().GetPoint(this, 627f);
	}

	public virtual EnemyPoint KGAGGPAMBNL()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 5)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 833f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.JKJBGIGAKIN())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.MOOGMFPMKEM());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 1))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding;
		return SpawningManager.LDGAKJJINEO().GetPoint(this, 727f);
	}

	protected void MFNJDOELHPG()
	{
		NFGCPLPKAIP = true;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.DBOOMCAGLEM().JPHAJDIIAAI().FCBGHBODHHP() != null)
		{
			PlayerController playerController = enemyPointRusher.EIGJJAGIBHI().LHHMNLJKOAO().NPOMEBDPBGL();
			GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
			GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI((GameShootableEntity.LAAAMBBNIJO)35, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	protected void MPLIHJKHLOD()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.DKFHIPIJJJG().PNKKPNIMEPL().OLOPPGKIJNF() != null)
		{
			PlayerController playerController = enemyPointRusher.EIGJJAGIBHI().PKBPGCGNCAD().FCBGHBODHHP();
			GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
			GLNJNLEHCDC = gameShootableEntity.AJBDIKBDLEA(GameShootableEntity.LAAAMBBNIJO.WholeBody | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Moving, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	protected void GJIFMPEPJDF()
	{
		NFGCPLPKAIP = false;
		EnemyPointRusher enemyPointRusher = LMNPOINIJBD.NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null && enemyPointRusher.PPKCJIDHOPO().LHHMNLJKOAO().OLOPPGKIJNF() != null)
		{
			PlayerController playerController = enemyPointRusher.DPHNNHCLOHC().LMHDAIBCLDP().OLOPPGKIJNF();
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			GLNJNLEHCDC = gameShootableEntity.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)(-42), LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
	}

	public virtual EnemyPoint GOHDONBAGFM()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 1)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1945f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.DKCLHDBPKCI())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.PFOBADFGAKF());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 1 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Tower;
		return SpawningManager.OKBAIGKCPKA().GBCNMJIJJKM(this, 125f);
	}

	public virtual EnemyPoint DODEFKEOOCP()
	{
		PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 6)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 124f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.PKKBHKIOOFN())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.KOFFAHEAHEN());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 0 || (enemyPointRusher.DFHAAIFFLOE <= 1 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Tower | EnemyPoint.LJGGJMAFEBN.Minigunner);
		return SpawningManager.OKBAIGKCPKA().GetPoint(this, 65f);
	}

	public virtual EnemyPoint IDECHCFOMGO()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.currentPlayerPoint.point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 3)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 1840f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.isFree)
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.FBGFMDOHAEG());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = ~(EnemyPoint.LJGGJMAFEBN.Corner | EnemyPoint.LJGGJMAFEBN.Car | EnemyPoint.LJGGJMAFEBN.Minigunner);
		return SpawningManager.OKBAIGKCPKA().GetPoint(this, 1562f);
	}

	public virtual bool IOJEJGFANEL(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 0;
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = randomEnemy.EMAMENNDFMB();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.PKKBHKIOOFN())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual bool IPNAEJBOFEB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 1;
		PlayerController playerController = PlayerController.BGEKNDDACNP(ACJIGOBMLNH);
		MapDefinition.DefendPosition currentPlayerPoint = playerController.currentPlayerPoint;
		if (currentPlayerPoint != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = currentPlayerPoint.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.DKCLHDBPKCI())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public virtual bool IBALGGHLHBA(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		int num = 0;
		PlayerController playerController = PlayerController.FDMHGNEGHDD(ACJIGOBMLNH);
		MapDefinition.DefendPosition defendPosition = playerController.BBNPGJAALCJ();
		if (defendPosition != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = defendPosition.point.JGAIPICHEDP;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (item.DKCLHDBPKCI())
				{
					num++;
					if (num >= CEFIMGIDADI)
					{
						return true;
					}
				}
			}
		}
		return true;
	}

	public virtual EnemyPoint LCANPCIHFAP()
	{
		PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
		List<EnemyPointRusher> jGAIPICHEDP = playerController.BBNPGJAALCJ().point.JGAIPICHEDP;
		if (LMNPOINIJBD.rusherCounts < 3)
		{
			EnemyPointRusher enemyPointRusher = null;
			float num = 601f;
			foreach (EnemyPointRusher item in jGAIPICHEDP)
			{
				if (!item.MMDCNGCOLEP())
				{
					continue;
				}
				float num2 = Vector3.Distance(base.transform.position, item.MGPNABOBKFP());
				if (num2 < num)
				{
					EnemyPointRusher enemyPointRusher2 = item;
					if (enemyPointRusher == null || enemyPointRusher.DFHAAIFFLOE > 1 || (enemyPointRusher.DFHAAIFFLOE <= 0 && enemyPointRusher2.DFHAAIFFLOE <= 0))
					{
						num = num2;
						enemyPointRusher = enemyPointRusher2;
					}
				}
			}
			if (enemyPointRusher != null)
			{
				return enemyPointRusher;
			}
		}
		AGEBNJADJNG = EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Helicopter | EnemyPoint.LJGGJMAFEBN.Tower;
		return SpawningManager.BMNEPICFHNO().LFJKDLGIFFK(this, 1249f);
	}

	public virtual void JLENEFJKLHH()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.CornerHiding)
		{
			BGOMBAFNGIJ();
			return;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
		GLNJNLEHCDC = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.None, LMNPOINIJBD.NGCDDPCAGJB.position);
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}
}
