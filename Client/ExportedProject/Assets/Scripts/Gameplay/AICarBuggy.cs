using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CarController))]
public class AICarBuggy : AICarBase<CarBuggyBehaviour>
{
	[FormerlySerializedAs("NIAJCCMOEPL")]
	public EnemyPointVehicle BFLHDJMEFFE;

	[FormerlySerializedAs("ICBKFJLHIKI")]
	public EnemyPointVehicle IADBFJNBOLH;

	private bool KLOPFNOEFGM;

	[FormerlySerializedAs("CDOFFPIOHDE")]
	public TurretWeaponMultipleWeapons PJJJKFOANDO;

	[FormerlySerializedAs("EADEPGKMMJP")]
	public TurretWeaponBasic KAEAMDOJMIF;

	public virtual void GGDPJCEDGAA()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, FKBPOFDINEO);
		OEBPFFBKBBD(IADBFJNBOLH, FKBPOFDINEO);
	}

	protected override void IANOIAOGAHO(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(IADBFJNBOLH, BDAKFIFCHLB, ANAJEHBNBAL);
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, ANAJEHBNBAL);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.carBuggyBehaviourDefinititon.health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.carBuggyBehaviourDefinititon.damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.carBuggyBehaviourDefinititon.fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.carBuggyBehaviourDefinititon.fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.carBuggyBehaviourDefinititon.minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.carBuggyBehaviourDefinititon.maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.carBuggyBehaviourDefinititon.probabilityOfRealShot;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.carBuggyBehaviourDefinititon.damageCannon * 0.5f;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.carBuggyBehaviourDefinititon.shotSpeed;
		BatchedWeapon[] kBGEINIEKHI = PJJJKFOANDO.KBGEINIEKHI;
		foreach (BatchedWeapon batchedWeapon in kBGEINIEKHI)
		{
			missileSetup = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			missileSetup.ABFGHBDEBAN = base.currentBeh.carBuggyBehaviourDefinititon.damageCannon * 0.5f;
			missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
			missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
			missileSetup.JPNAINOGAMM = base.currentBeh.carBuggyBehaviourDefinititon.shotSpeed;
		}
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.carBuggyBehaviourDefinititon.minShootTimeCannon;
		PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.carBuggyBehaviourDefinititon.maxShootTimeCannon;
		PJJJKFOANDO.LLOHEBJBBDH = 1f;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		KAEAMDOJMIF.gameObject.SetActive(base.hasSpecial);
	}

	public virtual void JJFFOGIJHIH()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, ANAJEHBNBAL);
		OEBPFFBKBBD(IADBFJNBOLH, OPJHHEFKBBP);
	}

	public virtual void OCEOOGDKBHA()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, FKBPOFDINEO);
		OEBPFFBKBBD(IADBFJNBOLH, FKBPOFDINEO);
	}

	public virtual void BAGFLOCJGED()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, DKEHCPGFMFO);
		OEBPFFBKBBD(IADBFJNBOLH, OPJHHEFKBBP);
	}

	protected override void Update()
	{
		if (LCDBACDIODH)
		{
			return;
		}
		base.Update();
		if (KLOPFNOEFGM && IADBFJNBOLH.IDNNIHBIMNO != null)
		{
			EnemyController enemyController = IADBFJNBOLH.IDNNIHBIMNO as EnemyController;
			if (enemyController != null && enemyController.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Vehicle)
			{
				KLOPFNOEFGM = false;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
			}
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient && Singleton<GameController>.instance.gameIsRunning && base.isAlive)
		{
			if (TimeManager.realTimeWithoutPauses > BFLHDJMEFFE.nextSpawnTime && BFLHDJMEFFE.IDNNIHBIMNO == null)
			{
				IDAOCGPNDBI(KANKDLBGMLK: false, BFLHDJMEFFE);
			}
			if (TimeManager.realTimeWithoutPauses > IADBFJNBOLH.nextSpawnTime && IADBFJNBOLH.IDNNIHBIMNO == null)
			{
				IDAOCGPNDBI(KANKDLBGMLK: false, IADBFJNBOLH);
			}
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		PJJJKFOANDO.ResetAiming();
		KAEAMDOJMIF.ResetAiming();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				IDAOCGPNDBI(KANKDLBGMLK: true, IADBFJNBOLH);
				IDAOCGPNDBI(KANKDLBGMLK: true, BFLHDJMEFFE);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
				KLOPFNOEFGM = false;
				PJJJKFOANDO.enabled = true;
				KAEAMDOJMIF.enabled = true;
			}
			PJJJKFOANDO.Reset();
			KAEAMDOJMIF.Reset();
			FAJKAOFMDNF(0.5f, 0.14f);
		}
	}

	private void MIJPDADNDMA(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.Spawn(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.PBFDGDPLFKN());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.ObstacleHiding);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			if (PLMMBKGLGAB == BFLHDJMEFFE)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = base.currentBeh.EJBIOFOAOHB();
				PJJJKFOANDO.enabled = false;
				PJJJKFOANDO.GGMKKIDFJOH();
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.BBBLJNFEACC();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = base.currentBeh.ICOBNNBHOKA();
			}
			enemyController.SittingIdle();
			enemyController.Killed += ANAJEHBNBAL;
		}
	}

	protected virtual void CADMIJMEDIM(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(IADBFJNBOLH, BDAKFIFCHLB, ANAJEHBNBAL);
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, DKEHCPGFMFO);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	private void HGJLHEMIPOM(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.LDGAKJJINEO().FJBJNELBAIO(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.FGKJILDKPHC());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Parachute);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			if (PLMMBKGLGAB == BFLHDJMEFFE)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = base.currentBeh.NNKBIGKLBGA();
				PJJJKFOANDO.enabled = false;
				PJJJKFOANDO.HEOPOOMLPJF();
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.BBBLJNFEACC();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = base.currentBeh.KGBOCKAHMHK();
			}
			enemyController.SittingIdle();
			enemyController.Killed += FKBPOFDINEO;
		}
	}

	public virtual void GDJAPADHAEH()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, OPJHHEFKBBP);
		OEBPFFBKBBD(IADBFJNBOLH, DKEHCPGFMFO);
	}

	protected virtual void HKIOKFGBGIG(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(IADBFJNBOLH, BDAKFIFCHLB, OPJHHEFKBBP);
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, OPJHHEFKBBP);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	protected virtual void HEPILBHNNAB(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void ANAJEHBNBAL(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FKBPOFDINEO;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == IADBFJNBOLH)
		{
			enemyController.ClearEnemyPoint();
			mDriving = true;
			brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
			KLOPFNOEFGM = true;
			IADBFJNBOLH.nextSpawnTime = TimeManager.CEAFAMFNGCC() + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate;
		}
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.HEOPOOMLPJF();
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
			BFLHDJMEFFE.HGPFKHIGHBL(TimeManager.CEAFAMFNGCC() + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, OPJHHEFKBBP);
		OEBPFFBKBBD(IADBFJNBOLH, OPJHHEFKBBP);
	}

	protected virtual void HMNLAJOPDEL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void KEDIBIGNJAA()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.GOJJHEMCNIP().health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SilverCardRarityEarly).FLOATVALUE;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.BJINNENEJKP().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.AKDOKHPIDLP().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.FOKEDGJDJHE().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.EHEOIIIGJGG().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.FMKOCINCFDO().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.IBGKEBFEBBH().probabilityOfRealShot;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.ENEEEOOJCLF().damageCannon * 819f;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.PHOEGFELPBJ().shotSpeed;
		BatchedWeapon[] kBGEINIEKHI = PJJJKFOANDO.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			missileSetup = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			missileSetup.ABFGHBDEBAN = base.currentBeh.IPCCMHBIPDH().damageCannon * 83f;
			missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
			missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
			missileSetup.JPNAINOGAMM = base.currentBeh.FABCIFMDDBP().shotSpeed;
		}
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.KGBOCKAHMHK().minShootTimeCannon;
		PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.BJINNENEJKP().maxShootTimeCannon;
		PJJJKFOANDO.LLOHEBJBBDH = 227f;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		KAEAMDOJMIF.gameObject.SetActive(base.hasSpecial);
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(0.5f, 0.14f);
		}
		else
		{
			FAJKAOFMDNF(0f, 0f);
		}
		KAEAMDOJMIF.gameObject.SetActive(base.hasSpecial);
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
		enemyController.SittingIdle();
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, IADBFJNBOLH, DKIPMCCIKMF: true);
		enemyController.SittingIdle();
	}

	private void FKBPOFDINEO(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FKBPOFDINEO;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == IADBFJNBOLH)
		{
			enemyController.ClearEnemyPoint();
			mDriving = true;
			brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
			KLOPFNOEFGM = true;
			IADBFJNBOLH.LPFNGDNDEIO(TimeManager.realTimeWithoutPauses + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.BBBLJNFEACC();
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.NIGDCBDKKMJ();
			enemyController.ClearEnemyPoint();
			BFLHDJMEFFE.POBMDOKFHCB(TimeManager.realTimeWithoutPauses + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public virtual void JLFDKPCPDAG()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.FMKOCINCFDO().health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-114)).FLOATVALUE;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.ENEEEOOJCLF().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.PGCKJNMMDAB().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.BPJCOFLIMNK().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.KGBOCKAHMHK().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.LAKCHKHKAPH().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.BJINNENEJKP().probabilityOfRealShot;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.GFOCNMIIKMM().damageCannon * 1275f;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.OKMJLIEIEAG().shotSpeed;
		BatchedWeapon[] kBGEINIEKHI = PJJJKFOANDO.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			missileSetup = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			missileSetup.ABFGHBDEBAN = base.currentBeh.IBGKEBFEBBH().damageCannon * 564f;
			missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
			missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
			missileSetup.JPNAINOGAMM = base.currentBeh.FOKEDGJDJHE().shotSpeed;
		}
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.GOJJHEMCNIP().minShootTimeCannon;
		PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.BJINNENEJKP().maxShootTimeCannon;
		PJJJKFOANDO.LLOHEBJBBDH = 1057f;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		KAEAMDOJMIF.gameObject.SetActive(base.hasSpecial);
	}

	protected virtual void BPNLIABHCPN()
	{
		if (LCDBACDIODH)
		{
			return;
		}
		base.Update();
		if (KLOPFNOEFGM && IADBFJNBOLH.IDNNIHBIMNO != null)
		{
			EnemyController enemyController = IADBFJNBOLH.IDNNIHBIMNO as EnemyController;
			if (enemyController != null && enemyController.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.CornerHiding)
			{
				KLOPFNOEFGM = false;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.Stop;
			}
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient && Singleton<GameController>.instance.GHKPKDPOGHF() && base.isAlive)
		{
			if (TimeManager.realTimeWithoutPauses > BFLHDJMEFFE.CCOIPECKEKA() && BFLHDJMEFFE.IDNNIHBIMNO == null)
			{
				HGJLHEMIPOM(KANKDLBGMLK: true, BFLHDJMEFFE);
			}
			if (TimeManager.CEAFAMFNGCC() > IADBFJNBOLH.KJKPGBJDEOL() && IADBFJNBOLH.IDNNIHBIMNO == null)
			{
				IDAOCGPNDBI(KANKDLBGMLK: true, IADBFJNBOLH);
			}
		}
	}

	protected virtual void ANIGALMMAFA(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(IADBFJNBOLH, BDAKFIFCHLB, DKEHCPGFMFO);
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, ANAJEHBNBAL);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	protected virtual void PAAMBFCKOKO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void OPJHHEFKBBP(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= OPJHHEFKBBP;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == IADBFJNBOLH)
		{
			enemyController.ClearEnemyPoint();
			mDriving = false;
			brakeCondition = FFKHOHMOBHH.Stop;
			KLOPFNOEFGM = true;
			IADBFJNBOLH.nextSpawnTime = TimeManager.realTimeWithoutPauses + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate;
		}
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			PJJJKFOANDO.enabled = false;
			PJJJKFOANDO.Reset();
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.Reset();
			enemyController.ClearEnemyPoint();
			BFLHDJMEFFE.nextSpawnTime = TimeManager.realTimeWithoutPauses + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate;
		}
	}

	protected override void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void IDAOCGPNDBI(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.Spawn(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.position, PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Vehicle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			if (PLMMBKGLGAB == BFLHDJMEFFE)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = base.currentBeh.carBuggyBehaviourDefinititon;
				PJJJKFOANDO.enabled = true;
				PJJJKFOANDO.Reset();
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.Reset();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = base.currentBeh.carBuggyBehaviourDefinititon;
			}
			enemyController.SittingIdle();
			enemyController.Killed += OPJHHEFKBBP;
		}
	}

	protected virtual void OFNEGNKMKKG()
	{
		if (LCDBACDIODH)
		{
			return;
		}
		base.Update();
		if (KLOPFNOEFGM && IADBFJNBOLH.IDNNIHBIMNO != null)
		{
			EnemyController enemyController = IADBFJNBOLH.IDNNIHBIMNO as EnemyController;
			if (enemyController != null && enemyController.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Helicopter)
			{
				KLOPFNOEFGM = true;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.Stop;
			}
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient && Singleton<GameController>.instance.GHKPKDPOGHF() && base.isAlive)
		{
			if (TimeManager.realTimeWithoutPauses > BFLHDJMEFFE.LJJJBNFFBAG() && BFLHDJMEFFE.IDNNIHBIMNO == null)
			{
				HGJLHEMIPOM(KANKDLBGMLK: false, BFLHDJMEFFE);
			}
			if (TimeManager.realTimeWithoutPauses > IADBFJNBOLH.KJKPGBJDEOL() && IADBFJNBOLH.IDNNIHBIMNO == null)
			{
				MIJPDADNDMA(KANKDLBGMLK: true, IADBFJNBOLH);
			}
		}
	}

	public virtual void CADILLCGODA()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, DKEHCPGFMFO);
		OEBPFFBKBBD(IADBFJNBOLH, FKBPOFDINEO);
	}

	protected virtual void HDLDMGEFCEJ()
	{
		if (LCDBACDIODH)
		{
			return;
		}
		base.Update();
		if (KLOPFNOEFGM && IADBFJNBOLH.IDNNIHBIMNO != null)
		{
			EnemyController enemyController = IADBFJNBOLH.IDNNIHBIMNO as EnemyController;
			if (enemyController != null && enemyController.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Rusher)
			{
				KLOPFNOEFGM = true;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
			}
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient && Singleton<GameController>.instance.KKHKIEFMENC() && base.isAlive)
		{
			if (TimeManager.CEAFAMFNGCC() > BFLHDJMEFFE.MLAPEGEEOHM() && BFLHDJMEFFE.IDNNIHBIMNO == null)
			{
				HGJLHEMIPOM(KANKDLBGMLK: false, BFLHDJMEFFE);
			}
			if (TimeManager.CEAFAMFNGCC() > IADBFJNBOLH.PIAFDPMIPCK() && IADBFJNBOLH.IDNNIHBIMNO == null)
			{
				IDAOCGPNDBI(KANKDLBGMLK: false, IADBFJNBOLH);
			}
		}
	}

	public virtual void NFCPFIKBBGG(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(743f, 1762f);
		}
		else
		{
			FAJKAOFMDNF(411f, 1323f);
		}
		KAEAMDOJMIF.gameObject.SetActive(base.hasSpecial);
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: false);
		enemyController.SittingIdle();
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, IADBFJNBOLH, DKIPMCCIKMF: false);
		enemyController.SittingIdle();
	}

	public virtual void IGDALFFNNJP()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.GFOCNMIIKMM().health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-70)).FLOATVALUE;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.FOKEDGJDJHE().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.HEIMJHGPKBB().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.OMBFHHFMAAI().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.HEIMJHGPKBB().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.ICOBNNBHOKA().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.GFOCNMIIKMM().probabilityOfRealShot;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.DFJLLCOPBJB().damageCannon * 417f;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.KGBOCKAHMHK().shotSpeed;
		BatchedWeapon[] kBGEINIEKHI = PJJJKFOANDO.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			missileSetup = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			missileSetup.ABFGHBDEBAN = base.currentBeh.HEIMJHGPKBB().damageCannon * 136f;
			missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
			missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
			missileSetup.JPNAINOGAMM = base.currentBeh.PHOEGFELPBJ().shotSpeed;
		}
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.KGBOCKAHMHK().minShootTimeCannon;
		PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.NNKBIGKLBGA().maxShootTimeCannon;
		PJJJKFOANDO.LLOHEBJBBDH = 1817f;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		KAEAMDOJMIF.gameObject.SetActive(base.hasSpecial);
	}

	private void DKEHCPGFMFO(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= OPJHHEFKBBP;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == IADBFJNBOLH)
		{
			enemyController.ClearEnemyPoint();
			mDriving = true;
			brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
			KLOPFNOEFGM = false;
			IADBFJNBOLH.EMONHNMFMBB(TimeManager.CEAFAMFNGCC() + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.BBBLJNFEACC();
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.BBBLJNFEACC();
			enemyController.ClearEnemyPoint();
			BFLHDJMEFFE.ABAAJOFJCGK(TimeManager.realTimeWithoutPauses + ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	protected override void DPFHODDILIF(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(IADBFJNBOLH, BDAKFIFCHLB, OPJHHEFKBBP);
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, OPJHHEFKBBP);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void MMJBLFBLKHI()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.HFPKCMJMPCO().health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-12)).FLOATVALUE;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.HEIMJHGPKBB().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.carBuggyBehaviourDefinititon.fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.KEGGHHHANMM().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.BJINNENEJKP().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.KEGGHHHANMM().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.BPJCOFLIMNK().probabilityOfRealShot;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.NNKBIGKLBGA().damageCannon * 1021f;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.HFPKCMJMPCO().shotSpeed;
		BatchedWeapon[] kBGEINIEKHI = PJJJKFOANDO.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			missileSetup = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			missileSetup.ABFGHBDEBAN = base.currentBeh.CGJGEDIPJBO().damageCannon * 646f;
			missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
			missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
			missileSetup.JPNAINOGAMM = base.currentBeh.carBuggyBehaviourDefinititon.shotSpeed;
		}
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.GOJJHEMCNIP().minShootTimeCannon;
		PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.DFJLLCOPBJB().maxShootTimeCannon;
		PJJJKFOANDO.LLOHEBJBBDH = 1459f;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		KAEAMDOJMIF.gameObject.SetActive(base.hasSpecial);
	}
}
