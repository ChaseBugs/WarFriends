using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourMachineGunner : SoldierBehaviourGeneric<SoldierBehaviourDefinititonMachineGunner>
{
	private float ADDICBANAAB;

	protected virtual void CJAHPFMAMKK()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1693f, 101f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.PABAMAJHKIN().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 883f + LMNPOINIJBD.transform.forward * 571f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.OGNMNJCOOPL(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual void LFIAGHDMAPD()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(1272f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void DMIPDMEIGGK()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.GHKPKDPOGHF() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1004f, 1632f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.FLAHKAIJHBP().Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1244f + LMNPOINIJBD.transform.forward * 1189f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.GENAGCFIDMH(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void NOMENDMLHJP()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 745f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(628f, 1206f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "menu-arena-ticket";
	}

	public virtual void AFHOIGOKINF()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				IEONNICKBBH(5f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual SpawnPoint BPBIGCEMLKJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("squadName");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void HOIHIFDGCJN()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 865f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1365f, 173f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "Weapon";
	}

	protected virtual void GPAPHKOAFLK()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 432f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1826f, 20f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "ID_CONFIRM_DELETESQUAD_TEXT";
	}

	protected virtual void LHJAGNOOBAF()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(480f, 934f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.PABAMAJHKIN().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1718f + LMNPOINIJBD.transform.forward * 1185f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.OGNMNJCOOPL(ShootableBox.EOBFNHDMLHJ.Health);
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void GIOFPLDAHFN()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1583f, 1979f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.BJMKGOIPLEI().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1477f + LMNPOINIJBD.transform.forward * 1263f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void FHKMMHFGCJJ()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1705f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1164f, 1172f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "Stage";
	}

	public virtual void CHNNIJFOAIJ()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(797f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual SpawnPoint HFPDJJBIAMI(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("YourAppId");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint HPNDFOMBDMJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("  ");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint APGGOLJLFGK(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("URL");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void CMELHMEBEFI()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1864f, 917f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 68f + LMNPOINIJBD.transform.forward * 929f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Health);
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void FADMNOLLJFG()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(599f, 1268f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.AAICLLMEDGP().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 751f + LMNPOINIJBD.transform.forward * 60f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void ELJHCOHCAJI()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1755f, 375f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 776f + LMNPOINIJBD.transform.forward * 84f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Health);
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual void DFHAECDJEOG()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(1524f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void NLNGDEIDDCA()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 428f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(268f, 1604f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "ID_CONFIRM_ACCOUNTBANNED";
	}

	protected virtual void PNEKCEHBGPD()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(560f, 926f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.KEOEDDFOMIP().Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 278f + LMNPOINIJBD.transform.forward * 172f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual void GBICPKPICMC()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(1385f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void LEODNPHAEAE()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(148f, 1915f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.IFDEKPHHCCN().Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1072f + LMNPOINIJBD.transform.forward * 1477f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.OGNMNJCOOPL(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual SpawnPoint KGMJMPEHOKJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_SLOTUPGRADE_ROF");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint KGLCECBBNCO(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("Server Error, no squad details");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void KPOELIFMEFO()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				IEONNICKBBH(499f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void LIMHNKKJODK()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.GHKPKDPOGHF() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(108f, 4f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.NNCLBGKMNEN().Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1007f + LMNPOINIJBD.transform.forward * 801f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
				shootableBox.KIPIOECGMDJ(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void EKPBOMOMMFB()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1061f, 1838f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.IFDEKPHHCCN().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 305f + LMNPOINIJBD.transform.forward * 697f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual SpawnPoint CHAPHIFCCGG(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("DogTagCap");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void NPKIJOAFPDN()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1548f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1271f, 839f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "WarFriends";
	}

	protected virtual void FNPJIBHOCLL()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 916f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1950f, 1765f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "squadMembers";
	}

	protected virtual void MOBANAPAHEF()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1074f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(250f, 496f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "ID_UNITTYPE4";
	}

	protected virtual void NGLCFHHHMPF()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.GHKPKDPOGHF() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(846f, 754f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.FLAHKAIJHBP().Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 597f + LMNPOINIJBD.transform.forward * 598f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void HEIGGMKHGAK()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1984f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1659f, 1989f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "Id";
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 0.25f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(15f, 30f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "shotReal";
	}

	public virtual SpawnPoint KJNFBKMDBOG(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("WarFriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Пожалуйста, подтверди разрешение в последующем диалоге. Мы никогда не воспользуемся эти разрешением для каких-либо других целей.");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public override void PickTarget()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				IEONNICKBBH(0.3f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void GIDMJLFJNBJ()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(87f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void BIEHFMDOCIG()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(211f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void JBKEOMOGMDM()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1295f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1182f, 358f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "ID_LOADING";
	}

	public virtual void COJDFKIEMBI()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(164f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual SpawnPoint DFKMCBGEHPF(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("SquadWarsProcessing");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void IJGGAOKOFLO()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(1048f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void HAMDMFGNIKD()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(106f, 225f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.PABAMAJHKIN().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 280f + LMNPOINIJBD.transform.forward * 738f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.OGNMNJCOOPL(ShootableBox.EOBFNHDMLHJ.Health);
				shootableBox.power = base.soldierBehaviourDefinititon.special;
			}
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
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
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
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("Time");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint EFKFIJFKEEA(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("unlockLevel");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void CDJBEAIDHKH()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1343f, 1082f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.IFDEKPHHCCN().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 138f + LMNPOINIJBD.transform.forward * 221f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual SpawnPoint IKDANHNIEKO(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_WARNING_INCORRECTASSIGNMENTS_TEXT");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void FDPOJHLHGJO()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(74f, 19f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.IFDEKPHHCCN().Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1976f + LMNPOINIJBD.transform.forward * 1016f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Ammo;
				shootableBox.power = base.soldierBehaviourDefinititon.special;
			}
		}
	}

	protected virtual void KGPGGLHMKJF()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 850f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(427f, 1230f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "videoName";
	}

	public virtual void LMHPIEPLEHD()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				IEONNICKBBH(1805f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void CLAKINKPCHA()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(915f, 1271f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.KEOEDDFOMIP().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 909f + LMNPOINIJBD.transform.forward * 927f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.GENAGCFIDMH(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual void LDPBJHHKLPB()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(163f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual SpawnPoint LNEGECOGEAH(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("GameControllerWarArena.StartGame DONE");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint HDPPOAONJLA(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("Pack_Id");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void DEBGBGGOCEN()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1300f, 526f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.IFDEKPHHCCN().EJIHLMEDEEB(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1893f + LMNPOINIJBD.transform.forward * 610f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Ammo;
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void LIIIAMCABLH()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1517f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(691f, 1365f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "MoneyPackDeadline";
	}

	protected virtual void DJJANKLPDAK()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1265f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(880f, 825f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "com.tune.TunePreloadData";
	}

	public virtual SpawnPoint FPJOEELDIKD(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("Region: {0} with ping {1}, IP: {2} \n");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual SpawnPoint HLFIPBNDCKE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("Locale");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void MMNALAIAOMO()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(1381f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(30f, 60f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 0.2f + LMNPOINIJBD.transform.forward * 0.2f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Ammo;
				shootableBox.power = base.soldierBehaviourDefinititon.special;
			}
		}
	}

	protected virtual void OMHMFGHINHL()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 87f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(244f, 864f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "BUDDY WARCARD";
	}

	public virtual SpawnPoint GLJEANJMKFI(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("OnDisconnectedFromPhoton");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void JCCIPOFJBLE()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1638f, 57f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.NNCLBGKMNEN().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 369f + LMNPOINIJBD.transform.forward * 206f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Ammo;
				shootableBox.KIPIOECGMDJ(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual SpawnPoint MOHKOMNGKFG(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_READYTIME");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void CJPFLJAAODD()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1862f, 735f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.HPBDNODOBDD().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 134f + LMNPOINIJBD.transform.forward * 850f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Ammo);
				shootableBox.KIPIOECGMDJ(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void PJLKNBGFHKE()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1248f, 1548f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.EJIHLMEDEEB(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 104f + LMNPOINIJBD.transform.forward * 240f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.NIMBEKLIKML(ShootableBox.EOBFNHDMLHJ.Health);
				shootableBox.BFKENPOFION(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void OPNBENNKNIG()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1896f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(561f, 1378f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "End Of Try Out: Equipping visual before \"{0}\"";
	}

	public virtual void OLOGDEBDHDB()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(1833f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void FGECFIBLFMD()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1765f, 1190f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1936f + LMNPOINIJBD.transform.forward * 77f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.GENAGCFIDMH(ShootableBox.EOBFNHDMLHJ.Health);
				shootableBox.KIPIOECGMDJ(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual SpawnPoint ACKAEFFOPLE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_REMINDER_YOURVIPMEMBERSHIP");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint GMEAFMIFLMM(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("PurchaseVerification(");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void OAKENJAPHHC()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1894f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1681f, 392f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "Current player squadRank:{0} and info in all members squadRank:{1}";
	}

	public virtual void FFDGEPANMNE()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(61f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void NPNOFFCDIKJ()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(84f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void DLCDDPCNBHP()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(1946f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void CBNBDNKKLKG()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(909f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void OFJPNALIEJC()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1416f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(211f, 1329f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "ID_PHASEX";
	}

	protected virtual void NNBJOHLBIED()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1604f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(263f, 340f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "menu-army-ammo-ico";
	}

	protected virtual void BLIOEMBLNBJ()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1631f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1661f, 903f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "{0}\u00a0{1}";
	}

	protected virtual void JHJMMMIFOLN()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 199f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(217f, 476f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "RowIDs";
	}

	public virtual SpawnPoint JLHCMPIGJOH(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("eventStart");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual SpawnPoint IEFNFMPNJKB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_BATTLEWINBONUSRISESTO");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual SpawnPoint EELLONCACNN(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("BattleRewards");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void DKDKAOPJCBA()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.GHKPKDPOGHF() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(308f, 35f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.AAICLLMEDGP().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1274f + LMNPOINIJBD.transform.forward * 307f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
				shootableBox.power = base.soldierBehaviourDefinititon.special;
			}
		}
	}

	public virtual void CPHGNMADEDH()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				IEONNICKBBH(444f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void HDPBLKLGBPI()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(1239f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void JGJPGHLPMEE()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(1389f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void IHLFCNMJENJ()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(324f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void JMHMGOGIOMG()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(930f, 1141f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.AAICLLMEDGP().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 3f + LMNPOINIJBD.transform.forward * 939f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
				shootableBox.KIPIOECGMDJ(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	protected virtual void AAIACLKCBED()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 174f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(777f, 1178f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "OnButtonClick";
	}

	public virtual void NCBJNHALIKE()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(1147f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual SpawnPoint NJEEMBPGGCB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("Card_1_Played");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint EHNHGBDEDEM(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("menu-arena-scrap-ico");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void GICJFHCKMEH()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(669f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void EDKCAPIKCPF()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1095f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1346f, 404f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "ID_NEWLOOTBOXINBATTLES";
	}

	public virtual SpawnPoint LPGBJNLBKNE(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("S");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void HNAJPBCFGCI()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1734f;
		ADDICBANAAB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1411f, 693f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "CONFIRM";
	}

	public virtual void MEIDANPLALC()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				IEONNICKBBH(281f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual SpawnPoint CGLPGPDKECD(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_ASSIGNMENTHINTCRATES");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual SpawnPoint ICGIPFHFHAB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("HELMETS_EMPTY");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void POPKBELFDHJ()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.realTimeWithoutPauses > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.GHKPKDPOGHF() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1076f, 856f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.IFDEKPHHCCN().EJIHLMEDEEB(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 1131f + LMNPOINIJBD.transform.forward * 842f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.OGNMNJCOOPL(ShootableBox.EOBFNHDMLHJ.Health);
				shootableBox.GCEMHMONNFG(base.soldierBehaviourDefinititon.special);
			}
		}
	}

	public virtual void ANDBDBHGNFL()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.OJHIKLMNHNE())
			{
				IEONNICKBBH(1271f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void ELNGOBHHAMA()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 1236f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1130f, 369f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "Quit called for game controller.";
	}

	protected virtual void MNJPIOEHBEM()
	{
		base.Update();
		if (LMNPOINIJBD != null && TimeManager.CEAFAMFNGCC() > ADDICBANAAB && LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.GHKPKDPOGHF() && LMNPOINIJBD.isInField && LMNPOINIJBD.hasSpecial)
		{
			ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(505f, 467f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.IFDEKPHHCCN().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, LMNPOINIJBD.transform.position + Vector3.up * 160f + LMNPOINIJBD.transform.forward * 907f, Quaternion.identity);
			if (shootableBox != null)
			{
				shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
				shootableBox.power = base.soldierBehaviourDefinititon.special;
			}
		}
	}

	public virtual void JKONAMDNKPO()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(61f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	public virtual void HPEMNKJGIIJ()
	{
		if (!BAGHBFNKEOP())
		{
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				IEONNICKBBH(366f);
			}
			else
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
			}
		}
	}

	protected virtual void IKFLJEGGGHO()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[1];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 814f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1558f, 1770f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "hasConnectedApi";
	}

	protected virtual void EFPGIJHLHBB()
	{
		base.KMINNAEBJAB();
		Weapon weapon = EEMHAHAINNM[0];
		BulletSetup bulletSetup = (BulletSetup)weapon.ammoSetup;
		weapon.JMDLKIAKOIE = 864f;
		ADDICBANAAB = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(526f, 1051f);
		weapon.OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		bulletSetup.KLGJDBCMCAA = "SWITCH TO DEATCHMATCH";
	}
}
