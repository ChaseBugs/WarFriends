using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourGrennader : SoldierBehaviourGeneric<SoldierBehaviourDefinititonGrennader>
{
	public override void PickTarget()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: true);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual bool DFABNKCLICE(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.NAJDKHPMEFN(ACJIGOBMLNH) + CEFIMGIDADI < 1;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	protected virtual int[] IGLOCKCEOJI(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[5]
		{
			visuals[7].weaponNumber,
			0,
			0,
			0,
			0
		};
	}

	protected override int[] CIOODNFANAH(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[2]
		{
			0,
			visuals[2].weaponNumber
		};
	}

	public virtual bool OMPEJKJOCLE(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.FPBGGFGLJEH(ACJIGOBMLNH) + CEFIMGIDADI < 2;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual void KOKHDDEHBFD()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: true);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	protected virtual void DDJHBIHGBHI()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "FuseSDK: Parsing error in _FriendsMigrated";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 706f - 776f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1007f;
		}
	}

	protected virtual void NALFMFIHKAJ()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_YOUMANAGEDTOWINXARENABATTLESYOU";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[0].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1513f - 141f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 568f;
		}
	}

	public virtual void BOFCCNAAJFK()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 0;
			LGCNELDNFAE = false;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual bool AJMCCCLNNLI(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.LCPDGFODKGA())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual int[] KANBNMLMKFB(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[8]
		{
			visuals[1].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	public virtual SpawnPoint MDAFNCNLOGI(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
		if (list.Count <= 1)
		{
			throw new Exception("\n");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual void NHANJLMOJAI()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual float GNNPCHKDPIK()
	{
		float num = 1616f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual bool POOEMJHEKIC(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Normal && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.NJCLPJKLPFN())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual int[] NIFMKGLDJHG(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[2]
		{
			visuals[4].weaponNumber,
			0
		};
	}

	public virtual void OADCBDHGKEA()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 4 && upgradeSlots.cardVisuals[5] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[7]
				{
					upgradeSlots.cardVisuals[7].weaponNumber,
					0,
					0,
					0,
					0,
					0,
					0
				});
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 2 && visuals[2] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[5]
				{
					visuals[7].weaponNumber,
					0,
					0,
					0,
					0
				});
			}
		}
	}

	public virtual SpawnPoint MELDBEFAPMJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Texture reference count is less than zero!");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void CAOCJDMPLLJ()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 0 && upgradeSlots.cardVisuals[1] != null)
			{
				EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
				int[] array = new int[1];
				array[1] = upgradeSlots.cardVisuals[5].weaponNumber;
				iILCGHOLDHF.SetWeaponsUpgrade(array);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 7 && visuals[4] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[2]
				{
					0,
					visuals[1].weaponNumber
				});
			}
		}
	}

	protected virtual int[] FAOJNFEAIJH()
	{
		return new int[7]
		{
			upgradeSlots.cardVisuals[2].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	public override void UpdateVisual()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 2 && upgradeSlots.cardVisuals[2] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[2]
				{
					0,
					upgradeSlots.cardVisuals[2].weaponNumber
				});
			}
			return;
		}
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
		if (visuals.Count > 2 && visuals[2] != null)
		{
			IILCGHOLDHF.SetWeaponsUpgrade(new int[2]
			{
				0,
				visuals[2].weaponNumber
			});
		}
	}

	public virtual bool OAIANBLCPCF(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void EDFEMNOCNMH()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual void MCBJNDDMGND()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 8 && upgradeSlots.cardVisuals[0] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[3]
				{
					upgradeSlots.cardVisuals[5].weaponNumber,
					0,
					0
				});
			}
			return;
		}
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
		if (visuals.Count > 0 && visuals[0] != null)
		{
			EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
			int[] array = new int[1];
			array[1] = visuals[5].weaponNumber;
			iILCGHOLDHF.BFLFMOIJBKJ(array);
		}
	}

	public virtual void ACMOGJCCGKB()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 6 && upgradeSlots.cardVisuals[4] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[5]
				{
					upgradeSlots.cardVisuals[7].weaponNumber,
					0,
					0,
					0,
					0
				});
			}
			return;
		}
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
		if (visuals.Count > 4 && visuals[3] != null)
		{
			IILCGHOLDHF.BFLFMOIJBKJ(new int[7]
			{
				0,
				visuals[2].weaponNumber,
				0,
				0,
				0,
				0,
				0
			});
		}
	}

	protected virtual int[] ALINFDHCHKG(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[7]
		{
			0,
			visuals[5].weaponNumber,
			0,
			0,
			0,
			0,
			0
		};
	}

	public virtual void HMODJEBGOEI()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 2 && upgradeSlots.cardVisuals[7] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[8]
				{
					0,
					upgradeSlots.cardVisuals[1].weaponNumber,
					0,
					0,
					0,
					0,
					0,
					0
				});
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 2 && visuals[5] != null)
			{
				EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
				int[] array = new int[1];
				array[1] = visuals[0].weaponNumber;
				iILCGHOLDHF.BFLFMOIJBKJ(array);
			}
		}
	}

	public virtual float ABNOPJINCDM()
	{
		float num = 998f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	protected virtual int[] DGOKGKECHGP()
	{
		return new int[6]
		{
			upgradeSlots.cardVisuals[6].weaponNumber,
			0,
			0,
			0,
			0,
			0
		};
	}

	public virtual void HLHOGLHNNCE()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 6 && upgradeSlots.cardVisuals[5] != null)
			{
				IILCGHOLDHF.BFLFMOIJBKJ(new int[2]
				{
					0,
					upgradeSlots.cardVisuals[2].weaponNumber
				});
			}
			return;
		}
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
		if (visuals.Count > 2 && visuals[6] != null)
		{
			IILCGHOLDHF.SetWeaponsUpgrade(new int[8]
			{
				visuals[0].weaponNumber,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			});
		}
	}

	public virtual SpawnPoint CHMNEBLFDHM(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_KILLEDBYYOURARMYUNIT");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual bool CHJLDIFAFDM(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.FKMIDGIKHGG(ACJIGOBMLNH) + CEFIMGIDADI < 0;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	protected virtual int[] IOCIPHIJMDB(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[8]
		{
			0,
			visuals[2].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	protected virtual void CACEPIADMOD()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "create new account and add FB";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 955f - 1675f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 420f;
		}
	}

	protected virtual int[] PFNHOGFPIFM()
	{
		return new int[4]
		{
			0,
			upgradeSlots.cardVisuals[1].weaponNumber,
			0,
			0
		};
	}

	protected virtual int[] DBGAMFPHHED(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[5]
		{
			visuals[2].weaponNumber,
			0,
			0,
			0,
			0
		};
	}

	public virtual bool LCBNOKJPDKL(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)0 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.JDAGNKDNEJD())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual float AFGEAFJMMOM()
	{
		float num = 225f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual SpawnPoint HPNDFOMBDMJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
		if (list.Count <= 0)
		{
			throw new Exception("]");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual bool KBHFNDOBFKK(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.None)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.JJAOGCLMIEA(ACJIGOBMLNH) + CEFIMGIDADI < 7;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual bool BDBENOPBIBH(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.None)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.NAJDKHPMEFN(ACJIGOBMLNH) + CEFIMGIDADI < 0;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	protected virtual int[] LIAPCCPPPPB(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[4]
		{
			0,
			visuals[5].weaponNumber,
			0,
			0
		};
	}

	public virtual bool OJHIIALBOPF(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.LCPDGFODKGA())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void JFGMIECDCGO()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 1 && upgradeSlots.cardVisuals[8] != null)
			{
				IILCGHOLDHF.BFLFMOIJBKJ(new int[7]
				{
					upgradeSlots.cardVisuals[0].weaponNumber,
					0,
					0,
					0,
					0,
					0,
					0
				});
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 6 && visuals[8] != null)
			{
				EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
				int[] array = new int[1];
				array[1] = visuals[5].weaponNumber;
				iILCGHOLDHF.SetWeaponsUpgrade(array);
			}
		}
	}

	protected virtual int[] COPBKFLEDKP(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[2]
		{
			visuals[8].weaponNumber,
			0
		};
	}

	public virtual SpawnPoint JOLCPADCBKB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception(" , ");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual void NPKIJOAFPDN()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "PromotedPlayer";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 694f - 1614f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 927f;
		}
	}

	public virtual void JLMKIALFLPN()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 4 && upgradeSlots.cardVisuals[7] != null)
			{
				EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
				int[] array = new int[0];
				array[1] = upgradeSlots.cardVisuals[8].weaponNumber;
				iILCGHOLDHF.BFLFMOIJBKJ(array);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 4 && visuals[6] != null)
			{
				IILCGHOLDHF.BFLFMOIJBKJ(new int[2]
				{
					visuals[1].weaponNumber,
					0
				});
			}
		}
	}

	public virtual SpawnPoint ONPIMPACIEF(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Adding warcards from cardpool:\n");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual SpawnPoint DPFEENCBLJF(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
		if (list.Count <= 1)
		{
			throw new Exception("ID_CONFIRM_SQUADEVENT_TEXT");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	public virtual void FFDGEPANMNE()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = false;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual SpawnPoint HIEGLBIFHHJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
		if (list.Count <= 0)
		{
			throw new Exception("ID_READYTIME");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual void JCPKHLAODJN()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "leagueMedals";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 831f - 713f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 150f;
		}
	}

	public override float GetNextShotTime()
	{
		float num = 1f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual SpawnPoint APFODBGBBJM(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_SQUADLEVEL");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual int[] AAKLBFCOHMO()
	{
		return new int[1] { upgradeSlots.cardVisuals[3].weaponNumber };
	}

	public virtual void IIAHCKLALMD()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: true);
			OONPHPCNBJF = 0;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual bool NGPEKELPKNG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.None)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.MEEBMIMAGPF(ACJIGOBMLNH) + CEFIMGIDADI < 2;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual bool NMELHBBOMHK(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)6 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void CPHGNMADEDH()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: true);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual bool LPIAFFJHLEP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.JJAOGCLMIEA(ACJIGOBMLNH) + CEFIMGIDADI < 8;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual bool FHKILOGBEOA(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.None)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.PBCBBBFOLFP(ACJIGOBMLNH) + CEFIMGIDADI < 7;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual bool NENEJCFNPIL(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.JCFMEBFCGJI())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual bool PEIFMKHAILA(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)0 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.LIDLAMJCPAO())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void EFFBPGKAJGJ()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 5 && upgradeSlots.cardVisuals[8] != null)
			{
				EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
				int[] array = new int[0];
				array[0] = upgradeSlots.cardVisuals[6].weaponNumber;
				iILCGHOLDHF.SetWeaponsUpgrade(array);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 8 && visuals[8] != null)
			{
				IILCGHOLDHF.BFLFMOIJBKJ(new int[2]
				{
					visuals[3].weaponNumber,
					0
				});
			}
		}
	}

	public virtual bool EDILICJABJJ(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)6 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.CJPHCHPDCOK())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual int[] EPBEJECGBLE(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[3]
		{
			0,
			visuals[4].weaponNumber,
			0
		};
	}

	protected virtual int[] DDAJKFIJDIF(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[8]
		{
			visuals[4].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	public virtual SpawnPoint NEIIDJMEEBC(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4)
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("PACK");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual int[] KFDMDBKNNGG()
	{
		return new int[5]
		{
			0,
			upgradeSlots.cardVisuals[3].weaponNumber,
			0,
			0,
			0
		};
	}

	public virtual bool GLNMDLBCLMP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.JKMCJNGFINK(ACJIGOBMLNH) + CEFIMGIDADI < 2;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual float PFJIOLAIGPN()
	{
		float num = 609f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual bool CHNELLIKBPD(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.JLLFKJHLLHM())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "shotReal";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 3f - 3f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 3f;
		}
	}

	protected virtual void COEEJDCEGIN()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "Warbucks";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 697f - 389f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 965f;
		}
	}

	public virtual bool ONMBMFADGHO(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)7 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.EEDKOIDPMJJ())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void DPAAMINIPCI()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 4 && upgradeSlots.cardVisuals[8] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[6]
				{
					0,
					upgradeSlots.cardVisuals[4].weaponNumber,
					0,
					0,
					0,
					0
				});
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 6 && visuals[7] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[2]
				{
					visuals[2].weaponNumber,
					0
				});
			}
		}
	}

	public virtual float AFNFJGMCBPE()
	{
		float num = 12f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	protected virtual int[] LEIGGMIIAIC()
	{
		return new int[2]
		{
			upgradeSlots.cardVisuals[7].weaponNumber,
			0
		};
	}

	protected virtual int[] GGFGFJFDBAD()
	{
		return new int[5]
		{
			0,
			upgradeSlots.cardVisuals[2].weaponNumber,
			0,
			0,
			0
		};
	}

	protected virtual int[] PNJANDBGFFO()
	{
		return new int[5]
		{
			0,
			upgradeSlots.cardVisuals[8].weaponNumber,
			0,
			0,
			0
		};
	}

	public virtual float HMDOJEHJAMM()
	{
		float num = 581f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	protected virtual int[] IMBKJOIPEBF(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[7]
		{
			visuals[6].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	public virtual void JKEACDIPFAD()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: true);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual void GGOKLBLGLNE()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 0;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	protected virtual void OLGHOHLHMDA()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "Data";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[0].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 896f - 598f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1255f;
		}
	}

	public virtual SpawnPoint JKJIAEGMHAC(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("registerCustomEventString");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
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
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH.Normal | SpawnPoint.PGMEFLECCPH.Parachute))
				{
					return item;
				}
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Beanstalk: Send Log. Wait for Response with Log Id....");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	protected virtual int[] DFFOACFMAGI()
	{
		return new int[5]
		{
			0,
			upgradeSlots.cardVisuals[1].weaponNumber,
			0,
			0,
			0
		};
	}

	protected virtual int[] BDGPHKLAPCB()
	{
		return new int[4]
		{
			upgradeSlots.cardVisuals[3].weaponNumber,
			0,
			0,
			0
		};
	}

	protected virtual int[] LOMEOIGGFKG()
	{
		return new int[2]
		{
			upgradeSlots.cardVisuals[4].weaponNumber,
			0
		};
	}

	protected virtual int[] CAOCFKLEDOP(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[8]
		{
			0,
			visuals[1].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	protected override int[] JDEDGDMMIFJ()
	{
		return new int[2]
		{
			0,
			upgradeSlots.cardVisuals[2].weaponNumber
		};
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

	public virtual bool DCPPIMLAJCN(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.LGJKIBHFGAM(ACJIGOBMLNH) + CEFIMGIDADI < 7;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	protected virtual void HMAJANNILPL()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "getGameDataKeys";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1486f - 1793f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1486f;
		}
	}

	protected virtual int[] NKGKKNNHMCL()
	{
		return new int[8]
		{
			0,
			upgradeSlots.cardVisuals[8].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	public virtual bool NFCPFLELGPJ(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.LJBCFEEIEAH(ACJIGOBMLNH) + CEFIMGIDADI < 8;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual void MCKPEPNDAKM()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 7 && upgradeSlots.cardVisuals[1] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[8]
				{
					upgradeSlots.cardVisuals[5].weaponNumber,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				});
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 4 && visuals[3] != null)
			{
				IILCGHOLDHF.BFLFMOIJBKJ(new int[6]
				{
					0,
					visuals[4].weaponNumber,
					0,
					0,
					0,
					0
				});
			}
		}
	}

	public virtual float IOLEDFPGCOC()
	{
		float num = 1616f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual SpawnPoint NFDJOFNEMGF(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
				if (item.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4)
				{
					return item;
				}
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("HBEJDPMOCCD");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual int[] ELGAJBLDKAD(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		int[] array = new int[0];
		array[1] = visuals[1].weaponNumber;
		return array;
	}

	protected virtual int[] PMALNCPEIMM()
	{
		return new int[7]
		{
			upgradeSlots.cardVisuals[3].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	public virtual SpawnPoint POOGLFDGPMK(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("10 Unit Categories\tWas shown {0}\tGames {1}/{2}");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual float NKDBOKMCBGM()
	{
		float num = 630f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual bool CFFAIIFBBFP(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)4 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.ANHBFEDCPCA())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual bool EGCDLKBLKAA(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.LJBCFEEIEAH(ACJIGOBMLNH) + CEFIMGIDADI < 7;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	protected virtual int[] DBHGHPFMFEM()
	{
		return new int[6]
		{
			upgradeSlots.cardVisuals[1].weaponNumber,
			0,
			0,
			0,
			0,
			0
		};
	}

	protected virtual int[] DNGHOBGOEHF()
	{
		int[] array = new int[1];
		array[1] = upgradeSlots.cardVisuals[7].weaponNumber;
		return array;
	}

	protected virtual void JAHAFIMOCLD()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "Attempts";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1061f - 799f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1046f;
		}
	}

	public override bool AcceptSpawnPoint(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Parachute && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction)
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual void LBJJJNJHCFH()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "{0} Empty";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1500f - 460f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1748f;
		}
	}

	protected virtual int[] BKBIJFIEIAN()
	{
		return new int[4]
		{
			0,
			upgradeSlots.cardVisuals[7].weaponNumber,
			0,
			0
		};
	}

	public virtual bool CJNPFPFJOHP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.None)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.LJBCFEEIEAH(ACJIGOBMLNH) + CEFIMGIDADI < 2;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual SpawnPoint HMJFOGHKABB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("ID_CONFIRM_STARTUPERROR");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual bool OCJNCKIJPCI(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)6 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.IPJOMHKDPKC())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	protected virtual int[] DFMJCGGFJGH(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		int[] array = new int[1];
		array[1] = visuals[3].weaponNumber;
		return array;
	}

	public virtual void JAIEBBDBODL()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 3 && upgradeSlots.cardVisuals[5] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[7]
				{
					upgradeSlots.cardVisuals[2].weaponNumber,
					0,
					0,
					0,
					0,
					0,
					0
				});
			}
			return;
		}
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
		if (visuals.Count > 8 && visuals[3] != null)
		{
			IILCGHOLDHF.SetWeaponsUpgrade(new int[8]
			{
				0,
				visuals[8].weaponNumber,
				0,
				0,
				0,
				0,
				0,
				0
			});
		}
	}

	public virtual float ALDCGOIKOBE()
	{
		float num = 345f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual bool HGHOLHIFBHI(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH)8 && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.LIDLAMJCPAO())
		{
			return true;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual void BOEJMGNMINK()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 0;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	protected virtual int[] JCCKPMPEDCO(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[8]
		{
			0,
			visuals[2].weaponNumber,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	protected virtual void NLHNGNKGMPM()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_WARNING_CONNECTIONERROR_TEXT";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[0].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1591f - 744f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1921f;
		}
	}

	public virtual bool PFHHJCFBHKL(SpawnPoint PLMMBKGLGAB)
	{
		if (PLMMBKGLGAB.APMKFCIEBAF == (SpawnPoint.PGMEFLECCPH.Normal | SpawnPoint.PGMEFLECCPH.Parachute) && base.KKOCPACHJII.canUseParachute && LMNPOINIJBD.fraction == PLMMBKGLGAB.NHLDLEOIHMJ())
		{
			return false;
		}
		return base.AcceptSpawnPoint(PLMMBKGLGAB);
	}

	public virtual float BDOEGCIGDCE()
	{
		float num = 954f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual SpawnPoint CKFPJOOHKJG(IEnumerable<SpawnPoint> AJNOOHNJMDN)
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
			throw new Exception("Data");
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		return list[index];
	}

	protected virtual int[] GPAKKNEGKAI(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		int[] array = new int[1];
		array[1] = visuals[8].weaponNumber;
		return array;
	}

	public virtual float FGLIHMPMMFE()
	{
		float num = 1565f / (float)LMNPOINIJBD.IGKDFJKEELP.CJIHIILEMMH;
		return UnityEngine.Random.Range(base.soldierBehaviourDefinititon.minShootTime, base.soldierBehaviourDefinititon.maxShootTime) * num;
	}

	public virtual bool BMKBHHMLHFH(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.PBCBBBFOLFP(ACJIGOBMLNH) + CEFIMGIDADI < 5;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	protected virtual void IHDGKGCAOLD()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "offerMult";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[0].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 402f - 505f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 639f;
		}
	}

	public virtual void ONIPHFFFKAD()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 1 && upgradeSlots.cardVisuals[2] != null)
			{
				EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
				int[] array = new int[0];
				array[0] = upgradeSlots.cardVisuals[7].weaponNumber;
				iILCGHOLDHF.BFLFMOIJBKJ(array);
			}
			return;
		}
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
		if (visuals.Count > 3 && visuals[8] != null)
		{
			IILCGHOLDHF.SetWeaponsUpgrade(new int[3]
			{
				0,
				visuals[0].weaponNumber,
				0
			});
		}
	}

	public override bool CanBeSpawned(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.LGJKIBHFGAM(ACJIGOBMLNH) + CEFIMGIDADI < 2;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual void JIPJBHCMOFF()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = true;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual bool NOEIMIFAAIJ(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.None)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.LGJKIBHFGAM(ACJIGOBMLNH) + CEFIMGIDADI < 6;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual bool ODIKGIPPOFP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.None)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.JKMCJNGFINK(ACJIGOBMLNH) + CEFIMGIDADI < 2;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual void FOEBPKEBCNB()
	{
		if (base.soldierBehaviourDefinititon.useSecondaryWeapon && base.HOHDBPODOAN && UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb && !POPLFNCCLHJ)
		{
			SwitchWeapon(AFKKHLPPGLN: false);
			OONPHPCNBJF = 0;
			LGCNELDNFAE = false;
		}
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual bool CMPLMBDGDBC(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if ((Singleton<GameController>.instance.isTutorialStage2 || Singleton<GameController>.instance.isTutorialStage3) && ACJIGOBMLNH == GHPGNELIDBM.Enemies)
		{
			foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
			{
				if (GetType() == item.behaviour.GetType())
				{
					return item.spawns.FPBGGFGLJEH(ACJIGOBMLNH) + CEFIMGIDADI < 0;
				}
			}
		}
		return base.CanBeSpawned(ACJIGOBMLNH, CEFIMGIDADI);
	}

	public virtual void HCAPCDDKKFG()
	{
		base.UpdateVisual();
		if (LMNPOINIJBD.spawnedByCard)
		{
			if (upgradeSlots.cardVisuals.Count > 2 && upgradeSlots.cardVisuals[5] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(new int[6]
				{
					0,
					upgradeSlots.cardVisuals[7].weaponNumber,
					0,
					0,
					0,
					0
				});
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			if (visuals.Count > 4 && visuals[7] != null)
			{
				EnemyBasicInventory iILCGHOLDHF = IILCGHOLDHF;
				int[] array = new int[1];
				array[1] = visuals[8].weaponNumber;
				iILCGHOLDHF.SetWeaponsUpgrade(array);
			}
		}
	}

	protected virtual void OMHMFGHINHL()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "menu-sidetab-player-add";
		bulletSetup.EPDELOGPNAC = base.KKOCPACHJII.damage;
		GrenadeAmmoSetup grenadeAmmoSetup = (GrenadeAmmoSetup)EEMHAHAINNM[1].ammoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = base.KKOCPACHJII.grenadeMinDamage;
		grenadeAmmoSetup.ABFGHBDEBAN = base.KKOCPACHJII.grenadeExplodeDamage;
		grenadeAmmoSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		grenadeAmmoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		grenadeAmmoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		if (LMNPOINIJBD.hasSpecial)
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 1820f - 1440f * base.soldierBehaviourDefinititon.special;
		}
		else
		{
			grenadeAmmoSetup.KFEBGOKJGGH = 638f;
		}
	}
}
