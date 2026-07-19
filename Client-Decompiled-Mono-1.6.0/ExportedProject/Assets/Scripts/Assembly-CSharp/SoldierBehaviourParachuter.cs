using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourParachuter : SoldierBehaviourRusher<SoldierBehaviourDefinititonParachuter>
{
	public float JKPMGFPHOIO = 2f;

	public override bool AcceptSpawnPoint(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual void FDJMAANBKLE(Vector3 MPHCNMDIPAI, bool GGJPNLDIGGM)
	{
		base.MDKABJDCKBI(MPHCNMDIPAI, GGJPNLDIGGM);
		EEMHAHAINNM[1].JMDLKIAKOIE = ((LMNPOINIJBD.IPIKDCMLOID != EnemyController.AJGFGCHCAPA.ObstacleHiding) ? 850f : 1655f);
	}

	protected virtual void ODLMMPHOBLF(Vector3 MPHCNMDIPAI, bool GGJPNLDIGGM)
	{
		base.MDKABJDCKBI(MPHCNMDIPAI, GGJPNLDIGGM);
		EEMHAHAINNM[1].JMDLKIAKOIE = ((LMNPOINIJBD.IPIKDCMLOID != EnemyController.AJGFGCHCAPA.Parachute) ? 1233f : 1466f);
	}

	public virtual void FIFJEKMIIPO()
	{
		base.StartEnemyBehaviour();
		if (LMNPOINIJBD.hasSpecial)
		{
			LMNPOINIJBD.SetUpKevlar(base.soldierBehaviourDefinititon.special);
		}
	}

	public override void PickTarget()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Parachute)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
			GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Shield, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = nearestTarget.transform.position;
			GLNJNLEHCDC = nearestTarget;
		}
		else
		{
			base.PickTarget();
		}
	}

	protected virtual void BOFFIOLOHJA()
	{
		base.DEFKBAMEKFI();
		BulletSetup bulletSetup = KHKAAGCIJPO.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			float num = LMNPOINIJBD.transform.position.PlanarDistance(enemyOf.NEAOHPOBCAN());
			bulletSetup.OFGIEEDGBPB = num < JKPMGFPHOIO;
		}
	}

	public virtual bool EBDEDGPKMCJ(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)7 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual void CPAGABAOFDN()
	{
		base.DEFKBAMEKFI();
		BulletSetup bulletSetup = KHKAAGCIJPO.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			float num = LMNPOINIJBD.transform.position.PlanarDistance(enemyOf.NEAOHPOBCAN());
			bulletSetup.OFGIEEDGBPB = num < JKPMGFPHOIO;
		}
	}

	public override bool AcceptsPoint(EnemyPoint PLMMBKGLGAB)
	{
		if (LMNPOINIJBD.spawnedByCard)
		{
			return LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction && ((PLMMBKGLGAB.enemyPointType & EnemyPoint.LJGGJMAFEBN.Corner) == EnemyPoint.LJGGJMAFEBN.Corner || (PLMMBKGLGAB.enemyPointType & EnemyPoint.LJGGJMAFEBN.Hiding) == EnemyPoint.LJGGJMAFEBN.Hiding);
		}
		return LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction && (PLMMBKGLGAB.enemyPointType & EnemyPoint.LJGGJMAFEBN.Rusher) == EnemyPoint.LJGGJMAFEBN.Rusher;
	}

	public override EnemyPoint GetInitPoint()
	{
		if (!LMNPOINIJBD.spawnedByCard)
		{
			return base.GetInitPoint();
		}
		return SpawningManager.instance.GetPoint(this);
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].JMDLKIAKOIE = 0.25f;
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "shotReal";
	}

	public virtual void CJOEAEFIMID()
	{
		base.StartEnemyBehaviour();
		if (LMNPOINIJBD.hasSpecial)
		{
			LMNPOINIJBD.SetUpKevlar(base.soldierBehaviourDefinititon.special);
		}
	}

	public virtual void FBJODOIOHEI()
	{
		base.StartEnemyBehaviour();
		if (LMNPOINIJBD.hasSpecial)
		{
			LMNPOINIJBD.SetUpKevlar(base.soldierBehaviourDefinititon.special);
		}
	}

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual EnemyPoint KLFPBKLPAEM()
	{
		if (!LMNPOINIJBD.spawnedByCard)
		{
			return base.GetInitPoint();
		}
		return SpawningManager.BMNEPICFHNO().GBCNMJIJJKM(this, 1161f);
	}

	public virtual bool JGMCMDBLKFA(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.LCPDGFODKGA())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual void EMOMBOIMKCJ(Vector3 MPHCNMDIPAI, bool GGJPNLDIGGM)
	{
		base.MDKABJDCKBI(MPHCNMDIPAI, GGJPNLDIGGM);
		EEMHAHAINNM[0].JMDLKIAKOIE = ((LMNPOINIJBD.IPIKDCMLOID != EnemyController.AJGFGCHCAPA.Walk) ? 415f : 1492f);
	}

	public virtual bool BKDKPJNHHFM(EnemyPoint PLMMBKGLGAB)
	{
		if (LMNPOINIJBD.spawnedByCard)
		{
			return LMNPOINIJBD.fraction == PLMMBKGLGAB.IOPIBCMGGDG() && (PLMMBKGLGAB.NDFKANKCFFO() & EnemyPoint.LJGGJMAFEBN.Hiding) != (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Corner) && (PLMMBKGLGAB.LJPBPIDDMAE() & (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner)) == 0;
		}
		return LMNPOINIJBD.fraction != PLMMBKGLGAB.JJDDKGIGJNI() || (PLMMBKGLGAB.HECCAFJBKGP() & (EnemyPoint.LJGGJMAFEBN)0) == 0;
	}

	public virtual void AIHAEONNMMO()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.ObstacleHiding)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			GameShootableEntity gameShootableEntity = enemyOf.gameShootableEntity;
			GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield, LMNPOINIJBD.NGCDDPCAGJB.position);
			OEDJOFINBMI = nearestTarget.transform.position;
			GLNJNLEHCDC = nearestTarget;
		}
		else
		{
			base.PickTarget();
		}
	}

	protected virtual void HAHBPECPMAD()
	{
		base.DEFKBAMEKFI();
		BulletSetup bulletSetup = KHKAAGCIJPO.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			float num = LMNPOINIJBD.transform.position.PlanarDistance(enemyOf.OBBPNKCOJNO());
			bulletSetup.OFGIEEDGBPB = num < JKPMGFPHOIO;
		}
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
		if (LMNPOINIJBD.hasSpecial)
		{
			LMNPOINIJBD.SetUpKevlar(base.soldierBehaviourDefinititon.special);
		}
	}

	public virtual bool GEPMKJNCBGN(EnemyPoint PLMMBKGLGAB)
	{
		if (LMNPOINIJBD.spawnedByCard)
		{
			return LMNPOINIJBD.fraction != PLMMBKGLGAB.fraction || (PLMMBKGLGAB.MODBJDDNNFN() & EnemyPoint.LJGGJMAFEBN.Car) == 0 || (PLMMBKGLGAB.enemyPointType & (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner)) == EnemyPoint.LJGGJMAFEBN.Hiding;
		}
		return LMNPOINIJBD.fraction != PLMMBKGLGAB.MHLKAEOAGAM() || (PLMMBKGLGAB.MODBJDDNNFN() & (EnemyPoint.LJGGJMAFEBN)0) == 0;
	}

	protected override void DEFKBAMEKFI()
	{
		base.DEFKBAMEKFI();
		BulletSetup bulletSetup = KHKAAGCIJPO.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			float num = LMNPOINIJBD.transform.position.PlanarDistance(enemyOf.position);
			bulletSetup.OFGIEEDGBPB = num < JKPMGFPHOIO;
		}
	}

	public virtual SpawnPoint PIKKPMIDFLI(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute)
				{
					return item;
				}
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("Testing Player");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected override void MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool GGJPNLDIGGM)
	{
		base.MDKABJDCKBI(MPHCNMDIPAI, GGJPNLDIGGM);
		EEMHAHAINNM[0].JMDLKIAKOIE = ((LMNPOINIJBD.IPIKDCMLOID != EnemyController.AJGFGCHCAPA.Parachute) ? 0.25f : 0.5f);
	}
}
