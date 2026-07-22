using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourGunslinger : SoldierBehaviourGeneric<SoldierBehaviourDefinititonGunslinger>
{
	public virtual SpawnPoint HAGEINLDFOB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("S");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual bool FFIGMHEPBOD()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 0;
		return result;
	}

	protected virtual void DJJANKLPDAK()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 1349f;
		Gun gun = EEMHAHAINNM[1] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 1287f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "localSquadLeaderboard";
	}

	public virtual void JGGGLOPBCKG()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.PGLCMPHHKJJ().GEAMOMEEFKM() is PlayerController)) ? 1228f : 1157f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.ENKMEEDAALF(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.LKLFCIJLNKF().OEPMLIKCGCC(), 961f);
		}
		base.ShootJustStarted();
	}

	public virtual void POBACLDNNNL()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: true);
	}

	public virtual void GJJDKBLNHJI()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: false);
	}

	public virtual void GPNFENEPALO()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.ONFDKHBOCHM().GEAMOMEEFKM() is PlayerController)) ? 82f : 1722f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.PHHCNIABKLA(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.LKLFCIJLNKF().GIKCFPEIFPP(), 1757f);
		}
		base.ShootJustStarted();
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: true);
	}

	protected virtual void IDELNBCDPCO()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 327f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 1971f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "Unit_Upgrade";
	}

	public virtual void DOCACLAOBHJ()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.ONIPNOJANCF().GEAMOMEEFKM() is PlayerController)) ? 135f : 485f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.HHJLJCLJNED(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.MDMGOJAPBAG().CMIDLDAHGJP(), 1204f);
		}
		base.ShootJustStarted();
	}

	public virtual void AGFCJFPBCCE()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.AEMIOOMACHK().GEAMOMEEFKM() is PlayerController)) ? 1158f : 1371f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.EGLIJJGEINK(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.LKLFCIJLNKF().CAMAJAIDKLJ(), 1767f);
		}
		base.ShootJustStarted();
	}

	public virtual void FLPODMPMHJM()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: true);
	}

	public virtual void DPNPDPEABEI()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.KMOOHKLNJLG().owner is PlayerController)) ? 1162f : 909f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.IPADKBMDBLE(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.KMOOHKLNJLG().PGCKGAELBFB(), 1510f);
		}
		base.ShootJustStarted();
	}

	public virtual bool BAHMLEJPOLI()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 0;
		return result;
	}

	public override bool StartShooting()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 1;
		return result;
	}

	public virtual void GPIGKBKMLPJ()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerRusher, GameShootableEntity.LAAAMBBNIJO.Body);
		}
	}

	public virtual SpawnPoint IIHCHHDOAGL(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("id");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void FMLPPMBAFCL()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: true);
	}

	public virtual bool ICBDIIAHHHG()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 0;
		return result;
	}

	public virtual SpawnPoint ELPEJHIEHEL(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Show2RPC");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint NBKGKGCKGMG(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("0.0.0");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void PGJKPFODJIC()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: true);
	}

	public virtual bool IMBGEAPKGAK()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 1;
		return result;
	}

	public virtual void GOODLIAKOMG()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.AKCFPMPAGOO().GEAMOMEEFKM() is PlayerController)) ? 96f : 1754f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.KAEMPBHPOLJ(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.KNIODJFBAGH().CMIDLDAHGJP(), 930f);
		}
		base.ShootJustStarted();
	}

	public override void ShootJustStarted()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.shootableEntity.owner is PlayerController)) ? 1f : 0.5f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.PredictPosition(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.shootableEntity.velocity);
		}
		base.ShootJustStarted();
	}

	public virtual bool PABJMIJCIJL()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 1;
		return result;
	}

	protected virtual void JGKEECKDGME()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 1976f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 886f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "UnitTutorial";
	}

	public virtual void CHMCOCBLDJH()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.Defender, GameShootableEntity.LAAAMBBNIJO.Body);
		}
	}

	public virtual void IEMMMBOOLHF()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: true);
	}

	public virtual bool DBMMMOFGPOE()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 0;
		return result;
	}

	public virtual SpawnPoint PFCBFDKOHJH(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("#VOJTA# SENDING COMPLETE STARTER ASSIGNMENSTS!!!");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void JHJMMMIFOLN()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 160f;
		Gun gun = EEMHAHAINNM[1] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 664f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "Player_Avoided_Grenade_On_First_Try";
	}

	public virtual SpawnPoint ACCCIDOJDLA(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("-placement");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual bool IHCALMEKAHH()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 1;
		return result;
	}

	public virtual void OCBCBLPPHLI()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA((UnitType)6, GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Out);
		}
	}

	public virtual SpawnPoint INIAHMLFLOJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("RefillRPC");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void FIFJEKMIIPO()
	{
		base.StartEnemyBehaviour();
		LMNPOINIJBD.SnapColt(BBAOMJODMDH: false);
	}

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void CFCEECJOMPL()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.KNIODJFBAGH().GEAMOMEEFKM() is PlayerController)) ? 388f : 1971f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.HEPNNOHFFGH(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.KNIODJFBAGH().PGCKGAELBFB(), 1673f);
		}
		base.ShootJustStarted();
	}

	public virtual bool HJNKIDONDML()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 1;
		return result;
	}

	public virtual SpawnPoint DDJIEBLLCOF(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("D2");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void LDGKCCFFLJM()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[0].JMDLKIAKOIE = 490f;
		Gun gun = EEMHAHAINNM[1] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 266f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "MigrateFriends(";
	}

	protected virtual void HACPGEIMIMD()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 699f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 1358f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "DropRate";
	}

	protected virtual void ECLKNHLFENC()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 159f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 1465f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "_FrustumCornersWS";
	}

	public virtual SpawnPoint JKJIAEGMHAC(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("com/google/android/gms/games/stats/PlayerStats");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual bool HONEEPLBILF()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 0;
		return result;
	}

	protected virtual void OFJPNALIEJC()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[0].JMDLKIAKOIE = 901f;
		Gun gun = EEMHAHAINNM[1] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 579f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_INPROGRESS";
	}

	public override void PickTarget()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerRusher, GameShootableEntity.LAAAMBBNIJO.Head);
		}
	}

	public virtual bool HKNGHNAHLIH()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 0;
		return result;
	}

	public virtual bool LHJOGHHJCKI()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 1;
		return result;
	}

	public virtual SpawnPoint HLEPMMBBJIM(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("ERNEUT VERSUCHEN");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint BPCGOGGIBPE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception(" - {0}");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void APIFLEGHLBP()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.shootableEntity.GEAMOMEEFKM() is PlayerController)) ? 988f : 1379f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.HEPNNOHFFGH(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.MDMGOJAPBAG().velocity, 907f);
		}
		base.ShootJustStarted();
	}

	public virtual void FJAPNAKFHBG()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerExplosive, GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out);
		}
	}

	public virtual SpawnPoint LOOMKIFFHJF(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("ID_CONFIRM_ERROR");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void NIGMDLFGOEI()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerRusher, GameShootableEntity.LAAAMBBNIJO.Out);
		}
	}

	public virtual SpawnPoint LNDOHEAJHLH(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("/");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void KPOELIFMEFO()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA((UnitType)4, GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield);
		}
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[0].JMDLKIAKOIE = 0.18f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 0.05f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "shotSniper";
	}

	protected virtual void ABHLPNFCEFN()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[0].JMDLKIAKOIE = 492f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 118f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "moneypack1B";
	}

	protected virtual void DMHAGPKFJPG()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 1625f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 1336f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_GUI_POWERBANDON";
	}

	public virtual void KODMCNBGKGP()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.Defender, GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield);
		}
	}

	public virtual bool MHDKNIMBGMK()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 1;
		return result;
	}

	protected virtual void OOENLAPFNFK()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 598f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 986f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "-";
	}

	public virtual void EHFBPPDAOJP()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.KNIODJFBAGH().GEAMOMEEFKM() is PlayerController)) ? 1267f : 1244f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.FHIELLINPIH(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.ONFDKHBOCHM().CMIDLDAHGJP(), 1066f);
		}
		base.ShootJustStarted();
	}

	public virtual SpawnPoint DMGGDBEFLIJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("game-card-ico-supersoldiers");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void BJPKNHIJIJG()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerShooter, GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out);
		}
	}

	public virtual void DAMKCAIBJPI()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerExplosive, GameShootableEntity.LAAAMBBNIJO.Head);
		}
	}

	public virtual SpawnPoint JKFLLPCIFNL(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("ID_PACKXGOLD");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual bool POEBKJAOPKB()
	{
		bool result = base.StartShooting();
		OONPHPCNBJF = 0;
		return result;
	}

	protected virtual void MABPICGMMLL()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[0].JMDLKIAKOIE = 1746f;
		Gun gun = EEMHAHAINNM[1] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 1178f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_AWESOME";
	}

	public virtual void GIFDCHBOEDJ()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.AEMIOOMACHK().GEAMOMEEFKM() is PlayerController)) ? 1894f : 1595f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.OIHCCIIKEHK(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.AEMIOOMACHK().PGCKGAELBFB(), 543f);
		}
		base.ShootJustStarted();
	}

	protected virtual void NEMCCFEFEBD()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		EEMHAHAINNM[1].JMDLKIAKOIE = 670f;
		Gun gun = EEMHAHAINNM[1] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.up * 1749f;
		}
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_CONFIRM_ACCOUNTBANNED";
	}
}
