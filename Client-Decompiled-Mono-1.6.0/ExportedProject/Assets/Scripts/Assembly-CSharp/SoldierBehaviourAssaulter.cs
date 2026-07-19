using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourAssaulter : SoldierBehaviourGeneric<SoldierBehaviourDefinititonBasicSoldier>
{
	private float ADDICBANAAB;

	public virtual bool GOABCPPNNOK(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)8 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.DJEPLLFFBEC())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void KEILCABALCB()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 1659f + UnityEngine.Random.value;
	}

	protected virtual void IODGCIIDJEK()
	{
		base.Update();
		if (!(LMNPOINIJBD != null) || !(TimeManager.CEAFAMFNGCC() > ADDICBANAAB) || LMNPOINIJBD.fraction != PlayerController.OGMBJPKOPCB.fraction || !Singleton<GameController>.instance.KKHKIEFMENC() || !LMNPOINIJBD.isInField || !LMNPOINIJBD.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(LMNPOINIJBD.transform.position, 409f, TagsAndLayers.DJLKEEHPAGA);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.OGMBJPKOPCB.fraction || enemyController == LMNPOINIJBD)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !list.Contains(destroyableObjectpart.JPPDEOKJBLO))
				{
					list.Add(destroyableObjectpart.JPPDEOKJBLO);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(LMNPOINIJBD.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, true);
		}
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + 1457f;
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

	public virtual SpawnPoint LLNMIAOJDBM(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)0)
				{
					return item;
				}
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("ServerResponseHandler.GetConfigurations DONE");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void OFDJHFMAJBI()
	{
		base.Update();
		if (!(LMNPOINIJBD != null) || !(TimeManager.realTimeWithoutPauses > ADDICBANAAB) || LMNPOINIJBD.fraction != PlayerController.OGMBJPKOPCB.fraction || !Singleton<GameController>.instance.KKHKIEFMENC() || !LMNPOINIJBD.isInField || !LMNPOINIJBD.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(LMNPOINIJBD.transform.position, 638f, TagsAndLayers.DJLKEEHPAGA);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.OGMBJPKOPCB.fraction || enemyController == LMNPOINIJBD)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !list.Contains(destroyableObjectpart.JPPDEOKJBLO))
				{
					list.Add(destroyableObjectpart.JPPDEOKJBLO);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(LMNPOINIJBD.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, true);
		}
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 1174f;
	}

	public override bool AcceptSpawnPoint(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void GDFAAMHDLEJ()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 255f + UnityEngine.Random.value;
	}

	public virtual void DOOFNOFFFGG()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 419f + UnityEngine.Random.value;
	}

	public virtual void MEIDANPLALC()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.Defender, (GameShootableEntity.LAAAMBBNIJO)160);
		}
	}

	protected virtual void FNPJIBHOCLL()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "CardId";
	}

	public virtual SpawnPoint HLFIPBNDCKE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)6)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("N");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint EJPEFALCGIE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)6)
				{
					return item;
				}
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("MigrateFriends(");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual bool HBGELMLFCKI(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)7 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.IMHAFCPPPIJ())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void BHJGHMIHCOC()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + 661f + UnityEngine.Random.value;
	}

	public virtual bool GCGPEJHIONN(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)0 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.JCFMEBFCGJI())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public override void Restart()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 2f + UnityEngine.Random.value;
	}

	public override void PickTarget()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerRusher);
		}
	}

	public virtual SpawnPoint HJAMHCBDBLE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Normal)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("null");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void KOKHDDEHBFD()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA((UnitType)5, (GameShootableEntity.LAAAMBBNIJO)134);
		}
	}

	public virtual SpawnPoint BDGGOLLCKHP(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)5)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Not sending error to database!!");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint HAGEINLDFOB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)5)
				{
					return item;
				}
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("Experience");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected override void Update()
	{
		base.Update();
		if (!(LMNPOINIJBD != null) || !(TimeManager.realTimeWithoutPauses > ADDICBANAAB) || LMNPOINIJBD.fraction != PlayerController.OGMBJPKOPCB.fraction || !Singleton<GameController>.instance.gameIsRunning || !LMNPOINIJBD.isInField || !LMNPOINIJBD.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(LMNPOINIJBD.transform.position, 1.5f, TagsAndLayers.DJLKEEHPAGA);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.OGMBJPKOPCB.fraction || enemyController == LMNPOINIJBD)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !list.Contains(destroyableObjectpart.JPPDEOKJBLO))
				{
					list.Add(destroyableObjectpart.JPPDEOKJBLO);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(LMNPOINIJBD.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, false);
		}
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 2f;
	}

	public virtual void AGPFLLKCJPE()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 694f + UnityEngine.Random.value;
	}

	public virtual void GMGFCBAPPDM()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 1222f + UnityEngine.Random.value;
	}

	public virtual SpawnPoint GKABAALGIEE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)7)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Started delivering |");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void HFMKHHEMPFC()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 690f + UnityEngine.Random.value;
	}

	public virtual void BJPKNHIJIJG()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerExplosive, (GameShootableEntity.LAAAMBBNIJO)194);
		}
	}

	public virtual bool LBNNMOONEHK(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Normal && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.ANHBFEDCPCA())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void JODMNOKBEII()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 1677f + UnityEngine.Random.value;
	}

	public override void ShootJustStarted()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.shootableEntity.owner is PlayerController)) ? 3f : 1f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.PredictPosition(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.shootableEntity.velocity, 0.3f);
		}
		base.ShootJustStarted();
	}

	public virtual SpawnPoint IIHCHHDOAGL(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH.Normal | SpawnPoint.PGMEFLECCPH.Parachute))
				{
					return item;
				}
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("Pack_Type");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "shotReal";
	}

	protected virtual void CMELHMEBEFI()
	{
		base.Update();
		if (!(LMNPOINIJBD != null) || !(TimeManager.realTimeWithoutPauses > ADDICBANAAB) || LMNPOINIJBD.fraction != PlayerController.OGMBJPKOPCB.fraction || !Singleton<GameController>.instance.GHKPKDPOGHF() || !LMNPOINIJBD.isInField || !LMNPOINIJBD.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(LMNPOINIJBD.transform.position, 1435f, TagsAndLayers.DJLKEEHPAGA);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.OGMBJPKOPCB.fraction || enemyController == LMNPOINIJBD)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !list.Contains(destroyableObjectpart.JPPDEOKJBLO))
				{
					list.Add(destroyableObjectpart.JPPDEOKJBLO);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(LMNPOINIJBD.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, true);
		}
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 1790f;
	}

	protected virtual void EBGBDDIADEJ()
	{
		base.Update();
		if (!(LMNPOINIJBD != null) || !(TimeManager.CEAFAMFNGCC() > ADDICBANAAB) || LMNPOINIJBD.fraction != PlayerController.OGMBJPKOPCB.fraction || !Singleton<GameController>.instance.GHKPKDPOGHF() || !LMNPOINIJBD.isInField || !LMNPOINIJBD.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(LMNPOINIJBD.transform.position, 1362f, TagsAndLayers.DJLKEEHPAGA);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.OGMBJPKOPCB.fraction || enemyController == LMNPOINIJBD)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !list.Contains(destroyableObjectpart.JPPDEOKJBLO))
				{
					list.Add(destroyableObjectpart.JPPDEOKJBLO);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(LMNPOINIJBD.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, false);
		}
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + 547f;
	}

	public virtual bool BFADEOCLCIP(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)5 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.AHFOPAOPBDF())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual bool CHNELLIKBPD(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)0 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.ANHBFEDCPCA())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void ICMDKPBCPJN()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.ONFDKHBOCHM().GEAMOMEEFKM() is PlayerController)) ? 1085f : 233f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.OAOOGPJEDBL(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.PGLCMPHHKJJ().CMIDLDAHGJP(), 1629f);
		}
		base.ShootJustStarted();
	}

	public virtual SpawnPoint MLNIFOEHBIP(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)0)
				{
					return item;
				}
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("NO");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void BGFAEOGHEHF()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.AKCFPMPAGOO().GEAMOMEEFKM() is PlayerController)) ? 1879f : 1265f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.PNBAFAAGNMC(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.PGLCMPHHKJJ().CAMAJAIDKLJ(), 785f);
		}
		base.ShootJustStarted();
	}

	protected virtual void FNIPIGKJKEI()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "<font ";
	}

	public virtual void BJGMIHGMCKE()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.PGLCMPHHKJJ().GEAMOMEEFKM() is PlayerController)) ? 495f : 297f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.FGFDJJHPCHG(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.AEMIOOMACHK().CMIDLDAHGJP(), 1018f);
		}
		base.ShootJustStarted();
	}

	public virtual void JOLJLKMKHHD()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.LKLFCIJLNKF().owner is PlayerController)) ? 984f : 1524f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.EGLIJJGEINK(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.MDMGOJAPBAG().OEPMLIKCGCC(), 1101f);
		}
		base.ShootJustStarted();
	}

	public virtual void JDEAFMHPCFG()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA((UnitType)6, ~(GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out | GameShootableEntity.LAAAMBBNIJO.Moving));
		}
	}

	protected virtual void OFNEGNKMKKG()
	{
		base.Update();
		if (!(LMNPOINIJBD != null) || !(TimeManager.CEAFAMFNGCC() > ADDICBANAAB) || LMNPOINIJBD.fraction != PlayerController.OGMBJPKOPCB.fraction || !Singleton<GameController>.instance.gameIsRunning || !LMNPOINIJBD.isInField || !LMNPOINIJBD.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(LMNPOINIJBD.transform.position, 515f, TagsAndLayers.DJLKEEHPAGA);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.OGMBJPKOPCB.fraction || enemyController == LMNPOINIJBD)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !list.Contains(destroyableObjectpart.JPPDEOKJBLO))
				{
					list.Add(destroyableObjectpart.JPPDEOKJBLO);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(LMNPOINIJBD.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, false);
		}
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + 852f;
	}

	protected virtual void AFCIHLADLHH()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "-[0-9]*$";
	}

	public virtual void DAMKCAIBJPI()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA(UnitType.AttackerShooter, (GameShootableEntity.LAAAMBBNIJO)175);
		}
	}

	protected virtual void OCOHBMCJHJG()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_VISUALCATEGORYPART1";
	}

	public virtual void GBMAPBOEHIC()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 953f + UnityEngine.Random.value;
	}

	protected virtual void CDJBEAIDHKH()
	{
		base.Update();
		if (!(LMNPOINIJBD != null) || !(TimeManager.CEAFAMFNGCC() > ADDICBANAAB) || LMNPOINIJBD.fraction != PlayerController.OGMBJPKOPCB.fraction || !Singleton<GameController>.instance.KKHKIEFMENC() || !LMNPOINIJBD.isInField || !LMNPOINIJBD.hasSpecial)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(LMNPOINIJBD.transform.position, 910f, TagsAndLayers.DJLKEEHPAGA);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			EnemyController enemyController = component.owner as EnemyController;
			if (enemyController == null || enemyController.fraction != PlayerController.OGMBJPKOPCB.fraction || enemyController == LMNPOINIJBD)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !list.Contains(destroyableObjectpart.JPPDEOKJBLO))
				{
					list.Add(destroyableObjectpart.JPPDEOKJBLO);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			item.HealSoldier(LMNPOINIJBD.destroyableObj.maxHealth * base.soldierBehaviourDefinititon.special, true);
		}
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + 253f;
	}

	public virtual void OAHOKOAIMKO()
	{
		base.Restart();
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + 550f + UnityEngine.Random.value;
	}

	public virtual void BPFFDOJGJFP()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.AKCFPMPAGOO().owner is PlayerController)) ? 1995f : 597f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.KAEMPBHPOLJ(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.shootableEntity.CMIDLDAHGJP(), 1522f);
		}
		base.ShootJustStarted();
	}

	public virtual void DIOENKJAGKB()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.ONFDKHBOCHM().GEAMOMEEFKM() is PlayerController)) ? 260f : 305f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.PHHCNIABKLA(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.AEMIOOMACHK().velocity, 763f);
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
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)8)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("ReSyncDisabledRPC");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual bool MNELKNNMIPE(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)7 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.OMNFCJBMMNL())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual void OJKAIIFGLMJ()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_SCHEDULEDMAINTENANCEOFSERVER";
	}

	public virtual void JKONAMDNKPO()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA((UnitType)7, GameShootableEntity.LAAAMBBNIJO.WholeBody | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out | GameShootableEntity.LAAAMBBNIJO.Moving);
		}
	}

	public virtual void JKAAHGKPBAK()
	{
		if (KHKAAGCIJPO != null && !BAGHBFNKEOP())
		{
			GOOKGAHJEHA((UnitType)6, ~(GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out | GameShootableEntity.LAAAMBBNIJO.Moving));
		}
	}

	public virtual void CFCEECJOMPL()
	{
		if (GLNJNLEHCDC != null)
		{
			KHKAAGCIJPO.SetBullletSpeedCoef((GLNJNLEHCDC == null || !(GLNJNLEHCDC.AEMIOOMACHK().owner is PlayerController)) ? 945f : 1365f);
			OEDJOFINBMI = Singleton<AimingHelper>.instance.ENKMEEDAALF(KHKAAGCIJPO, OEDJOFINBMI, GLNJNLEHCDC.FOLGBDHKFAH().velocity, 187f);
		}
		base.ShootJustStarted();
	}
}
