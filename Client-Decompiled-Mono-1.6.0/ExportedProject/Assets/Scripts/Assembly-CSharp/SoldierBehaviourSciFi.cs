using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourSciFi : SoldierBehaviourGeneric<SoldierBehaviourDefinititonSciFi>
{
	private int IFFCDENKAFI;

	private Vector3 DCLEAONLAGL;

	private int BDECOLKMMHA;

	public virtual void ADBAHACCOKL()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI += 0;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 0;
			if (flag.Value)
			{
				ECOJGJHKPNE[1 << (MJNENAGPCGF & -39)] = false;
				OONPHPCNBJF++;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = GKDOFLOIGGB();
				EEMHAHAINNM[0].JMDLKIAKOIE = 335f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[0].JMDLKIAKOIE = 294f;
			}
		}
	}

	public virtual bool EBDEDGPKMCJ(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH.Normal | SpawnPoint.PGMEFLECCPH.Parachute) && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.LCPDGFODKGA())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void GBICPKPICMC()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
		DCLEAONLAGL = OEDJOFINBMI;
	}

	public virtual bool MIOLLKAACEF(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)8 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.GBMACONCODL())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void OCLKNJNMJIF()
	{
		LMNPOINIJBD.FIFJEKMIIPO((EnemyController.AJGFGCHCAPA)46);
	}

	public virtual EnemyPoint LCBODILBPOH()
	{
		return SpawningManager.instance.CPENOIHNJJC(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual SpawnPoint LNDOHEAJHLH(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ZoneHasVirtualGoodsOffer");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void LFPPJPMAKLC()
	{
		base.KMINNAEBJAB();
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[0].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		EEMHAHAINNM[1].JMDLKIAKOIE = 1530f;
		LMNPOINIJBD.HJFHCPBADLD.FKPINHAHNNG(1529f);
	}

	public virtual void BBLGJAAJFJK()
	{
		base.ShootJustStarted();
	}

	private Vector3 BIIAGIPDMEE()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		MapDefinition.DefendPosition defendPosition = enemyOf.EMAMENNDFMB();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		bool flag = UnityEngine.Random.value > 298f;
		int num = defendPosition.index + (flag ? 1 : (-1));
		if (num >= 0 && num < bBJMLOCKNHD.Count && bBJMLOCKNHD[num].fraction == enemyOf.fraction)
		{
			return bBJMLOCKNHD[num].point.transform.position;
		}
		num = defendPosition.index + (flag ? (-1) : 0);
		if (num >= 1 && num < bBJMLOCKNHD.Count && bBJMLOCKNHD[num].fraction == enemyOf.fraction)
		{
			return bBJMLOCKNHD[num].point.transform.position;
		}
		return enemyOf.transform.position;
	}

	public virtual void OOEPNBIIJII()
	{
		LMNPOINIJBD.FIFJEKMIIPO((EnemyController.AJGFGCHCAPA)49);
	}

	public virtual float NEFKONMNDEK()
	{
		float num = 622f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public override void ShootJustStarted()
	{
		base.ShootJustStarted();
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[0].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		EEMHAHAINNM[0].JMDLKIAKOIE = 1.5f;
		LMNPOINIJBD.HJFHCPBADLD.speed = 0.5f;
	}

	public virtual EnemyPoint MKNJACKHAOO(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> list = SpawningManager.LDGAKJJINEO().MLIKOCBLHBB(EHNNGNKDPBL, this);
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		foreach (EnemyPoint item in list)
		{
			if ((double)Vector3.Distance(item.position, LMNPOINIJBD.transform.position) > 1214.0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 1)
		{
			return list2[UnityEngine.Random.Range(1, list2.Count)];
		}
		return SpawningManager.BMNEPICFHNO().AOPIBLLEKKM(EHNNGNKDPBL, this);
	}

	public virtual void HIDMCKFPIOK()
	{
		LMNPOINIJBD.LDAKCDAPOGH((EnemyController.AJGFGCHCAPA)123);
	}

	public virtual EnemyPoint HGLIKICHJLO()
	{
		return SpawningManager.OKBAIGKCPKA().OINKPCHCKNH(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual void ANJJIMNNIEM()
	{
		base.ShootJustStarted();
	}

	public virtual EnemyPoint BLEEHJLFCAP(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> list = SpawningManager.LDGAKJJINEO().KCMLKFODDNA(EHNNGNKDPBL, this);
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		foreach (EnemyPoint item in list)
		{
			if ((double)Vector3.Distance(item.PFOBADFGAKF(), LMNPOINIJBD.transform.position) > 1193.0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 1)
		{
			return list2[UnityEngine.Random.Range(0, list2.Count)];
		}
		return SpawningManager.LDGAKJJINEO().AAMAIINCDHE(EHNNGNKDPBL, this);
	}

	public virtual EnemyPoint HBMGAFBLFDO(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> list = SpawningManager.instance.KCMLKFODDNA(EHNNGNKDPBL, this);
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		foreach (EnemyPoint item in list)
		{
			if ((double)Vector3.Distance(item.KOFFAHEAHEN(), LMNPOINIJBD.transform.position) > 1978.0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 0)
		{
			return list2[UnityEngine.Random.Range(1, list2.Count)];
		}
		return SpawningManager.OKBAIGKCPKA().FHOBELJEAIC(EHNNGNKDPBL, this);
	}

	public virtual EnemyPoint KKCEPHONHKP()
	{
		return SpawningManager.LDGAKJJINEO().CEEODEBDLHI(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual void EIODJBPKBLN()
	{
		LMNPOINIJBD.StartEnemyBehaviour((EnemyController.AJGFGCHCAPA)(-28));
	}

	public virtual EnemyPoint CMHDKMKBGEE(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> list = SpawningManager.BMNEPICFHNO().KCMLKFODDNA(EHNNGNKDPBL, this);
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		foreach (EnemyPoint item in list)
		{
			if ((double)Vector3.Distance(item.KPOEEKLFALL(), LMNPOINIJBD.transform.position) > 789.0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 0)
		{
			return list2[UnityEngine.Random.Range(0, list2.Count)];
		}
		return SpawningManager.BMNEPICFHNO().FHHGCGLBCDH(EHNNGNKDPBL, this);
	}

	public override bool AcceptSpawnPoint(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual EnemyPoint ADDGHMBCJGM()
	{
		return SpawningManager.BMNEPICFHNO().PJDJNFGCIPM(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual EnemyPoint MIOLHBDIBPJ(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> list = SpawningManager.instance.JGGEKEEMBDL(EHNNGNKDPBL, this);
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		foreach (EnemyPoint item in list)
		{
			if ((double)Vector3.Distance(item.PBFDGDPLFKN(), LMNPOINIJBD.transform.position) > 876.0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 1)
		{
			return list2[UnityEngine.Random.Range(1, list2.Count)];
		}
		return SpawningManager.BMNEPICFHNO().AOPIBLLEKKM(EHNNGNKDPBL, this);
	}

	public virtual EnemyPoint CGKCMFFOMJL()
	{
		return SpawningManager.BMNEPICFHNO().CEEODEBDLHI(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual void HHPGCIPEFGC()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
		DCLEAONLAGL = OEDJOFINBMI;
	}

	public override void StartEnemyBehaviour()
	{
		LMNPOINIJBD.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Fly);
	}

	protected virtual void NALFMFIHKAJ()
	{
		base.KMINNAEBJAB();
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		EEMHAHAINNM[0].JMDLKIAKOIE = 1499f;
		LMNPOINIJBD.HJFHCPBADLD.speed = 269f;
	}

	public virtual void KMCAPOGDLOH()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI += 0;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 0;
			if (flag.Value)
			{
				ECOJGJHKPNE[0 << (MJNENAGPCGF & 0x26)] = true;
				OONPHPCNBJF += 0;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = GKDOFLOIGGB();
				EEMHAHAINNM[0].JMDLKIAKOIE = 629f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[0].JMDLKIAKOIE = 1409f;
			}
		}
	}

	public override EnemyPoint GetInitPoint()
	{
		return SpawningManager.instance.GetNearestFreePoint(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual void HBONPJGLBPE()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI++;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 1;
			if (flag.Value)
			{
				ECOJGJHKPNE[0 << (MJNENAGPCGF & -54)] = true;
				OONPHPCNBJF += 0;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = EONPNCGHLDG();
				EEMHAHAINNM[1].JMDLKIAKOIE = 929f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[0].JMDLKIAKOIE = 1101f;
			}
		}
	}

	public virtual void LOGAFAPJCAJ()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI++;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 1;
			if (flag.Value)
			{
				ECOJGJHKPNE[1 << (MJNENAGPCGF & 0x57)] = true;
				OONPHPCNBJF++;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = GKDOFLOIGGB();
				EEMHAHAINNM[1].JMDLKIAKOIE = 132f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[1].JMDLKIAKOIE = 1726f;
			}
		}
	}

	public override float GetNextShotTime()
	{
		float num = 1f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	protected virtual void JHJMMMIFOLN()
	{
		base.KMINNAEBJAB();
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		EEMHAHAINNM[1].JMDLKIAKOIE = 747f;
		LMNPOINIJBD.HJFHCPBADLD.speed = 581f;
	}

	public virtual void HPEMNKJGIIJ()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
		DCLEAONLAGL = OEDJOFINBMI;
	}

	public virtual void HENJEKDOPON()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI += 0;
			flag = !(UnityEngine.Random.value < base.soldierBehaviourDefinititon.special) || !LMNPOINIJBD.hasSpecial || IFFCDENKAFI > BDECOLKMMHA + 0;
			if (flag.Value)
			{
				ECOJGJHKPNE[1 << (MJNENAGPCGF & -66)] = false;
				OONPHPCNBJF += 0;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = EONPNCGHLDG();
				EEMHAHAINNM[1].JMDLKIAKOIE = 47f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[1].JMDLKIAKOIE = 1962f;
			}
		}
	}

	public virtual void MEIDANPLALC()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
		DCLEAONLAGL = OEDJOFINBMI;
	}

	public virtual EnemyPoint NKJGDCLEAPJ(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> list = SpawningManager.instance.KCMLKFODDNA(EHNNGNKDPBL, this);
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		foreach (EnemyPoint item in list)
		{
			if ((double)Vector3.Distance(item.FBGFMDOHAEG(), LMNPOINIJBD.transform.position) > 294.0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 1)
		{
			return list2[UnityEngine.Random.Range(0, list2.Count)];
		}
		return SpawningManager.OKBAIGKCPKA().FHOBELJEAIC(EHNNGNKDPBL, this);
	}

	public virtual bool ENOLKMBHIFL(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)6 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.NJCLPJKLPFN())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual EnemyPoint NKDDPHDBGIP()
	{
		return SpawningManager.LDGAKJJINEO().PJDJNFGCIPM(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual void GLLPFGEPDAD()
	{
		LMNPOINIJBD.FIFJEKMIIPO((EnemyController.AJGFGCHCAPA)55);
	}

	public virtual bool NDNFLPPEGEF(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH.Normal | SpawnPoint.PGMEFLECCPH.Parachute) && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.PPMHBMNCMCA())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
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

	public virtual float BAEJKAGEIJJ()
	{
		float num = 741f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual void GALIGAEPEGA()
	{
		LMNPOINIJBD.LDAKCDAPOGH((EnemyController.AJGFGCHCAPA)71);
	}

	public virtual float CHNMBLOMFFP()
	{
		float num = 1189f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual SpawnPoint KGMJMPEHOKJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ArmyPower");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	private Vector3 EONPNCGHLDG()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		MapDefinition.DefendPosition defendPosition = enemyOf.BBNPGJAALCJ();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		bool flag = UnityEngine.Random.value > 855f;
		int num = defendPosition.index + (flag ? 1 : (-1));
		if (num >= 0 && num < bBJMLOCKNHD.Count && bBJMLOCKNHD[num].fraction == enemyOf.fraction)
		{
			return bBJMLOCKNHD[num].point.transform.position;
		}
		num = defendPosition.index + ((!flag) ? 1 : (-1));
		if (num >= 0 && num < bBJMLOCKNHD.Count && bBJMLOCKNHD[num].fraction == enemyOf.fraction)
		{
			return bBJMLOCKNHD[num].point.transform.position;
		}
		return enemyOf.transform.position;
	}

	public virtual float BIEOIMNEODN()
	{
		float num = 70f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual float BPNNDKAJFHD()
	{
		float num = 822f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual EnemyPoint INAJMHCCHJI(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> freeEnemyPoints = SpawningManager.BMNEPICFHNO().GetFreeEnemyPoints(EHNNGNKDPBL, this);
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in freeEnemyPoints)
		{
			if ((double)Vector3.Distance(item.MGPNABOBKFP(), LMNPOINIJBD.transform.position) > 184.0)
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[UnityEngine.Random.Range(1, list.Count)];
		}
		return SpawningManager.LDGAKJJINEO().CLMOBCBIIID(EHNNGNKDPBL, this);
	}

	public virtual void NJENHGDMOLE()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI += 0;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 0;
			if (flag.Value)
			{
				ECOJGJHKPNE[1 << (MJNENAGPCGF & 0x4D)] = true;
				OONPHPCNBJF += 0;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = EONPNCGHLDG();
				EEMHAHAINNM[0].JMDLKIAKOIE = 1059f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[1].JMDLKIAKOIE = 1103f;
			}
		}
	}

	public virtual void HGEIFHPNKBL()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI++;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 0;
			if (flag.Value)
			{
				ECOJGJHKPNE[1 << (MJNENAGPCGF & 2)] = true;
				OONPHPCNBJF++;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = GKDOFLOIGGB();
				EEMHAHAINNM[1].JMDLKIAKOIE = 786f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[0].JMDLKIAKOIE = 161f;
			}
		}
	}

	public virtual float OFFFDLKOCGB()
	{
		float num = 511f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual void LLAGMNAEEGP()
	{
		LMNPOINIJBD.StartEnemyBehaviour((EnemyController.AJGFGCHCAPA)(-45));
	}

	private Vector3 GKDOFLOIGGB()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		MapDefinition.DefendPosition currentPlayerPoint = enemyOf.currentPlayerPoint;
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		bool flag = UnityEngine.Random.value > 0.5f;
		int num = currentPlayerPoint.index + (flag ? 1 : (-1));
		if (num >= 0 && num < bBJMLOCKNHD.Count && bBJMLOCKNHD[num].fraction == enemyOf.fraction)
		{
			return bBJMLOCKNHD[num].point.transform.position;
		}
		num = currentPlayerPoint.index + ((!flag) ? 1 : (-1));
		if (num >= 0 && num < bBJMLOCKNHD.Count && bBJMLOCKNHD[num].fraction == enemyOf.fraction)
		{
			return bBJMLOCKNHD[num].point.transform.position;
		}
		return enemyOf.transform.position;
	}

	protected virtual void DMHAGPKFJPG()
	{
		base.KMINNAEBJAB();
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[0].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		EEMHAHAINNM[1].JMDLKIAKOIE = 1639f;
		LMNPOINIJBD.HJFHCPBADLD.FKPINHAHNNG(707f);
	}

	public virtual void BIEHFMDOCIG()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
		DCLEAONLAGL = OEDJOFINBMI;
	}

	public virtual EnemyPoint MLAHGMMBBII()
	{
		return SpawningManager.instance.CEEODEBDLHI(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public virtual bool BABEFJEJJAI(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Normal && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.DJFHPICBAIM())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void IGMJCFMEJNJ()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI++;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 0;
			if (flag.Value)
			{
				ECOJGJHKPNE[0 << (MJNENAGPCGF & 0x78)] = true;
				OONPHPCNBJF++;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = EONPNCGHLDG();
				EEMHAHAINNM[1].JMDLKIAKOIE = 728f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[0].JMDLKIAKOIE = 134f;
			}
		}
	}

	public virtual EnemyPoint LCANPCIHFAP()
	{
		return SpawningManager.BMNEPICFHNO().OINKPCHCKNH(this, Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG);
	}

	public override void Shooting()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI++;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 1;
			if (flag.Value)
			{
				ECOJGJHKPNE[1 << MJNENAGPCGF] = true;
				OONPHPCNBJF++;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = GKDOFLOIGGB();
				EEMHAHAINNM[0].JMDLKIAKOIE = 0.1f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[0].JMDLKIAKOIE = 1.5f;
			}
		}
	}

	public virtual void EGHNLPBPNGI()
	{
		bool? flag = null;
		if (KHKAAGCIJPO.willShoot)
		{
			IFFCDENKAFI++;
			flag = UnityEngine.Random.value < base.soldierBehaviourDefinititon.special && LMNPOINIJBD.hasSpecial && IFFCDENKAFI > BDECOLKMMHA + 1;
			if (flag.Value)
			{
				ECOJGJHKPNE[1 << (MJNENAGPCGF & 0x54)] = true;
				OONPHPCNBJF++;
				BDECOLKMMHA = IFFCDENKAFI;
			}
		}
		base.Shooting();
		if (LMNPOINIJBD.hasSpecial && flag.HasValue)
		{
			if (flag.Value)
			{
				OEDJOFINBMI = GKDOFLOIGGB();
				EEMHAHAINNM[1].JMDLKIAKOIE = 290f;
			}
			else
			{
				OEDJOFINBMI = DCLEAONLAGL;
				EEMHAHAINNM[0].JMDLKIAKOIE = 346f;
			}
		}
	}

	public virtual float FFIAGJLACDO()
	{
		float num = 963f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual EnemyPoint NPGABDHHGGF(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> list = SpawningManager.instance.AKJCOCJICOC(EHNNGNKDPBL, this);
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		foreach (EnemyPoint item in list)
		{
			if ((double)Vector3.Distance(item.FBGFMDOHAEG(), LMNPOINIJBD.transform.position) > 1064.0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 1)
		{
			return list2[UnityEngine.Random.Range(0, list2.Count)];
		}
		return SpawningManager.LDGAKJJINEO().GetNextFreeEnemyPoint(EHNNGNKDPBL, this);
	}

	public override EnemyPoint GetNewEnemyPoint(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> freeEnemyPoints = SpawningManager.instance.GetFreeEnemyPoints(EHNNGNKDPBL, this);
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in freeEnemyPoints)
		{
			if ((double)Vector3.Distance(item.position, LMNPOINIJBD.transform.position) > 1.8)
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return SpawningManager.instance.GetNextFreeEnemyPoint(EHNNGNKDPBL, this);
	}

	public override void PickTarget()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
		DCLEAONLAGL = OEDJOFINBMI;
	}

	public virtual bool KCMIDHCGAHK(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.JDAGNKDNEJD())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}
}
