using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CarController))]
public class AICar : AICarBase<CarBehaviour>, NKMKCCDCHCL, KMHCMCBGFFC
{
	[FormerlySerializedAs("EADEPGKMMJP")]
	public TurretWeaponBasic KAEAMDOJMIF;

	[FormerlySerializedAs("CDOFFPIOHDE")]
	public TurretWeaponBasic PJJJKFOANDO;

	private EnemyController GIPEKIBEPEB;

	protected bool IDCFGLGCCEH;

	private bool NHJBHOBBHBO;

	private EnemyPointVehicle NLGBGOGCNKP;

	private void PJEKLOFGOIA(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.LDGAKJJINEO().Spawn(GIPEKIBEPEB, fraction, EEAMBOACAGF: false, NLGBGOGCNKP.KOFFAHEAHEN(), PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Walk);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.HHDHFIPJGNP();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += DNIJMECBLFC;
			IDCFGLGCCEH = false;
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.HEOPOOMLPJF();
		}
	}

	protected override void DPFHODDILIF(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(GHAGNCHNHEE, BDAKFIFCHLB, OPJHHEFKBBP);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	private void PCNCHHDLMHB()
	{
		DCJACJLHONG(KANKDLBGMLK: true);
	}

	public virtual void BMCDLGBGHKJ()
	{
		base.OnInstancied();
		KAEAMDOJMIF.MIAFDNDBJJF();
		PJJJKFOANDO.JNFKFJOECJE();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				DCJACJLHONG(KANKDLBGMLK: false);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(1854f, 1494f);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.NIGDCBDKKMJ();
			PJJJKFOANDO.NIGDCBDKKMJ();
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		KAEAMDOJMIF.ResetAiming();
		PJJJKFOANDO.ResetAiming();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				IDAOCGPNDBI(KANKDLBGMLK: true);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(0.7f, 0.16f);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
			PJJJKFOANDO.Reset();
		}
	}

	public virtual void CFNLFDABCIG()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.JJKADFBHAFB().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackGuaranteedCardsType).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.BOLKLBLLEAA().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.GNHKOAEKHCL().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.KANLNGPNLPL().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.KANLNGPNLPL().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.LKMCNMHOHCL().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.BDJAHILMEAA().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.BCLKFMFJEMA().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.GNHKOAEKHCL().special * 590f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.OLKMMBNBEOB().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 188f;
		PJJJKFOANDO.KMCFBCNNMGF = 1154f;
		PJJJKFOANDO.LLOHEBJBBDH = 1857f;
	}

	public virtual void FENEOGLFFPP()
	{
		base.OnInstancied();
		KAEAMDOJMIF.IEHMPLOKAHC();
		PJJJKFOANDO.MCEPKEIINAA();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				LMPFGJKBGDB(KANKDLBGMLK: true);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(696f, 1053f);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.HEOPOOMLPJF();
			PJJJKFOANDO.GGMKKIDFJOH();
		}
	}

	public virtual void IMHOHLIDMIG()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= HIAFJAKBGHG;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, HDBBKHIBCBD);
	}

	public virtual void GHMJLNIFHMM()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.GNHKOAEKHCL().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-9)).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.PNEKGALOFCJ().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.BDJAHILMEAA().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.OLKMMBNBEOB().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.DKCMFKLAGOF().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.BDJAHILMEAA().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.GNHKOAEKHCL().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.OLKMMBNBEOB().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.carBehaviourDefinititon.special * 817f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.PNEKGALOFCJ().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 37f;
		PJJJKFOANDO.KMCFBCNNMGF = 748f;
		PJJJKFOANDO.LLOHEBJBBDH = 1688f;
	}

	private void JINPPMKANPL(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().LMJOPLCEBAA(GIPEKIBEPEB, fraction, EEAMBOACAGF: true, NLGBGOGCNKP.position);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Swat);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.HHDHFIPJGNP();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += FPACCEEKHMA;
			IDCFGLGCCEH = false;
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.HEOPOOMLPJF();
		}
	}

	private void HGJLHEMIPOM(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.BMNEPICFHNO().CDHOPCCMOIH(GIPEKIBEPEB, fraction, EEAMBOACAGF: true, NLGBGOGCNKP.position);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Vehicle);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.LDKAMIJCEFH();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += DNIJMECBLFC;
			IDCFGLGCCEH = true;
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.HEOPOOMLPJF();
		}
	}

	protected virtual void FJBKNJKMKPE(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void DNIJMECBLFC(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FPACCEEKHMA;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && JHJJKEBNGEN())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = false;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = false;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
			}
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.HEOPOOMLPJF();
			InvokeAfter(DAKNIJFJAIN, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	private void BBFGFHGMEGH(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.Spawn(GIPEKIBEPEB, fraction, EEAMBOACAGF: true, NLGBGOGCNKP.MGPNABOBKFP(), PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Helicopter);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.AJMJGJOGBHC();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += FMILGFFPCAD;
			IDCFGLGCCEH = false;
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.GGMKKIDFJOH();
		}
	}

	private void DCJACJLHONG(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().CDHOPCCMOIH(GIPEKIBEPEB, fraction, EEAMBOACAGF: false, NLGBGOGCNKP.KOFFAHEAHEN(), PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Parachute);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.JAEEHKOFEIH();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += IMBPCFOCJPI;
			IDCFGLGCCEH = false;
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.HEOPOOMLPJF();
		}
	}

	public virtual void KEDIBIGNJAA()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.BCLKFMFJEMA().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-82)).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.JAEEHKOFEIH().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.PNEKGALOFCJ().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.LKMCNMHOHCL().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.JJKADFBHAFB().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.BCLKFMFJEMA().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.ONFFBDBGLBL().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.BCLKFMFJEMA().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.AJMJGJOGBHC().special * 1627f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.BOLKLBLLEAA().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.JGACHOEBKJG = 1651f;
		PJJJKFOANDO.KMCFBCNNMGF = 1106f;
		PJJJKFOANDO.LLOHEBJBBDH = 1903f;
	}

	private void GGKHLBONKJF(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().Spawn(GIPEKIBEPEB, fraction, EEAMBOACAGF: true, NLGBGOGCNKP.FBGFMDOHAEG(), PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Helicopter);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.POOBBDJPCMN();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += OPJHHEFKBBP;
			IDCFGLGCCEH = true;
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.NIGDCBDKKMJ();
		}
	}

	private void AKNOMEDCKAJ()
	{
		AHCAEAFCNMM(KANKDLBGMLK: false);
	}

	public virtual void HLOPIELMHMO()
	{
		base.OnInstancied();
		KAEAMDOJMIF.CJLPDLHIIGI();
		PJJJKFOANDO.MIAFDNDBJJF();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				JINPPMKANPL(KANKDLBGMLK: false);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(1607f, 249f);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.Reset();
			PJJJKFOANDO.NIGDCBDKKMJ();
		}
	}

	protected virtual void FOMNKAMCDBP(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void JIDDMOKDNNC()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.BOLKLBLLEAA().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WarcardAdInterval).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.LDKAMIJCEFH().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.LDKAMIJCEFH().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.BCLKFMFJEMA().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.AJMJGJOGBHC().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.ONFFBDBGLBL().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.BDJAHILMEAA().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.KDKHFDENKDA().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.OLKMMBNBEOB().special * 1074f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.KDKHFDENKDA().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 541f;
		PJJJKFOANDO.KMCFBCNNMGF = 1414f;
		PJJJKFOANDO.LLOHEBJBBDH = 238f;
	}

	[CompilerGenerated]
	private void BNGGHLNGLDO()
	{
		IDAOCGPNDBI(KANKDLBGMLK: false);
	}

	public virtual void EBDAMJKMJCC()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.KANLNGPNLPL().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward7).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.JAEEHKOFEIH().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.LDKAMIJCEFH().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.JDJPHKFFGKD().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.LKMCNMHOHCL().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.PNEKGALOFCJ().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.AEHIENAJDLM().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.LKMCNMHOHCL().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.LKMCNMHOHCL().special * 1642f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.ONFFBDBGLBL().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 1438f;
		PJJJKFOANDO.KMCFBCNNMGF = 652f;
		PJJJKFOANDO.LLOHEBJBBDH = 1206f;
	}

	private void FPACCEEKHMA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= NAIHLMOEAEB;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PPHLEDLNGIN())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = false;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.ECHCLJJJPML())
			{
				mDriving = false;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
			}
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.IPKNPABKAJD();
			InvokeAfter(delegate
			{
				IDAOCGPNDBI(KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	private void LMOOELDHHCO()
	{
		LMPFGJKBGDB(KANKDLBGMLK: false);
	}

	private void NDFCKBKDFHG(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= HIAFJAKBGHG;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && base.isInstantiated)
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = false;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.Stop;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
			}
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.IPKNPABKAJD();
			InvokeAfter(AKNOMEDCKAJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public virtual void INNFBEJIFIB()
	{
		base.OnInstancied();
		KAEAMDOJMIF.NHGIJBNBLIC();
		PJJJKFOANDO.JHGLCFPAPIK();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				AHCAEAFCNMM(KANKDLBGMLK: true);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(961f, 56f);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.MGJIOLLKHDK();
			PJJJKFOANDO.Reset();
		}
	}

	public virtual void HBFGEHIMBHD()
	{
		base.OnInstancied();
		KAEAMDOJMIF.ResetAiming();
		PJJJKFOANDO.CJLPDLHIIGI();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				BBFGFHGMEGH(KANKDLBGMLK: false);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(1775f, 823f);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.MGJIOLLKHDK();
			PJJJKFOANDO.GGMKKIDFJOH();
		}
	}

	public virtual void LPBJEOCCMNI()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.OEDCHCGJOIG().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-7)).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.POOBBDJPCMN().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.NAILHGJFJBH().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.LDKAMIJCEFH().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.AJMJGJOGBHC().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.BOLKLBLLEAA().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.LKMCNMHOHCL().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.KDKHFDENKDA().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.POOBBDJPCMN().special * 478f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.KDKHFDENKDA().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 1324f;
		PJJJKFOANDO.KMCFBCNNMGF = 1901f;
		PJJJKFOANDO.LLOHEBJBBDH = 1153f;
	}

	protected virtual void JJBINDDFJNC(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(GHAGNCHNHEE, BDAKFIFCHLB, FPACCEEKHMA);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void JEJKJLIGINL(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(512f, 543f);
		}
		else
		{
			FAJKAOFMDNF(702f, 1771f);
		}
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: false);
	}

	public override void EGEAFDFNEAP()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= APLPHCFKBKP;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, NAIHLMOEAEB);
	}

	public virtual void EADMBLNJGFK()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.JJKADFBHAFB().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalWoUDelayMin).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.BDJAHILMEAA().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.LDKAMIJCEFH().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.AEHIENAJDLM().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.LKMCNMHOHCL().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.BCLKFMFJEMA().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.KANLNGPNLPL().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.KANLNGPNLPL().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.NAILHGJFJBH().special * 1315f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.POOBBDJPCMN().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 439f;
		PJJJKFOANDO.KMCFBCNNMGF = 1714f;
		PJJJKFOANDO.LLOHEBJBBDH = 257f;
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.carBehaviourDefinititon.health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.carBehaviourDefinititon.damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.carBehaviourDefinititon.shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.carBehaviourDefinititon.fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.carBehaviourDefinititon.fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.carBehaviourDefinititon.minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.carBehaviourDefinititon.maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.carBehaviourDefinititon.probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.carBehaviourDefinititon.special * 0.1f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.carBehaviourDefinititon.special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 5f;
		PJJJKFOANDO.KMCFBCNNMGF = 15f;
		PJJJKFOANDO.LLOHEBJBBDH = 1f;
	}

	public virtual void GJNGEPHDIDG()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= LELHLNOGLED;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, FMILGFFPCAD);
	}

	public virtual void AAGOGKDHNJC()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.NAILHGJFJBH().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverCardRarity).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.JDJPHKFFGKD().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.NAILHGJFJBH().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.KANLNGPNLPL().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.BDJAHILMEAA().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.OEDCHCGJOIG().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.BDJAHILMEAA().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.KDKHFDENKDA().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.JAEEHKOFEIH().special * 811f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.OLKMMBNBEOB().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.JGACHOEBKJG = 257f;
		PJJJKFOANDO.KMCFBCNNMGF = 996f;
		PJJJKFOANDO.LLOHEBJBBDH = 63f;
	}

	private void IDAOCGPNDBI(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.Spawn(GIPEKIBEPEB, fraction, EEAMBOACAGF: false, NLGBGOGCNKP.position, PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Vehicle);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			VehicleBehaviourDefinititon carBehaviourDefinititon = base.currentBeh.carBehaviourDefinititon;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += OPJHHEFKBBP;
			IDCFGLGCCEH = false;
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
		}
	}

	public virtual void CLEDGDKIJDI(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(973f, 852f);
		}
		else
		{
			FAJKAOFMDNF(1534f, 834f);
		}
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: true);
	}

	protected override void NFFAPMFJLFJ(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(GHAGNCHNHEE, BDAKFIFCHLB, DNIJMECBLFC);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	protected virtual void PCFMLANCFPL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	protected override void GMKPEJCCONK(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(GHAGNCHNHEE, BDAKFIFCHLB, EOCPKOPGOLC);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public override void ICBAJOMDGII(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(295f, 1826f);
		}
		else
		{
			FAJKAOFMDNF(1175f, 575f);
		}
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: true);
	}

	public override void OBCAIFMOPPA()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= HDBBKHIBCBD;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, FMILGFFPCAD);
	}

	public virtual void KHEJCPFFOEC()
	{
		base.OnInstancied();
		KAEAMDOJMIF.CJLPDLHIIGI();
		PJJJKFOANDO.CJLPDLHIIGI();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				BBFGFHGMEGH(KANKDLBGMLK: true);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(725f, 1829f);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
			PJJJKFOANDO.HEOPOOMLPJF();
		}
	}

	protected virtual void LCGEOMHLJGO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void HDAMDKKPBME()
	{
		base.OnInstancied();
		KAEAMDOJMIF.JHGLCFPAPIK();
		PJJJKFOANDO.IEHMPLOKAHC();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				AHCAEAFCNMM(KANKDLBGMLK: true);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(1668f, 90f);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.MGJIOLLKHDK();
			PJJJKFOANDO.Reset();
		}
	}

	public virtual void DFDLGBELMGH()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.KDKHFDENKDA().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-105)).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.GNHKOAEKHCL().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.BCLKFMFJEMA().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.JAEEHKOFEIH().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.POOBBDJPCMN().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.DKCMFKLAGOF().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.AJMJGJOGBHC().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.JDJPHKFFGKD().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.BDJAHILMEAA().special * 1527f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.DKCMFKLAGOF().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.JGACHOEBKJG = 1581f;
		PJJJKFOANDO.KMCFBCNNMGF = 1085f;
		PJJJKFOANDO.LLOHEBJBBDH = 117f;
	}

	private void LMPFGJKBGDB(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().FJBJNELBAIO(GIPEKIBEPEB, fraction, EEAMBOACAGF: true, NLGBGOGCNKP.PBFDGDPLFKN(), PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Swat);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.POOBBDJPCMN();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += NDFCKBKDFHG;
			IDCFGLGCCEH = false;
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.BBBLJNFEACC();
		}
	}

	private void MODEEODBPGO(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FMILGFFPCAD;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PLPBGNOCCPI())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = false;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.ECHCLJJJPML())
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
			}
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
			InvokeAfter(APKBCLHCFIC, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public virtual void ICCLFDKECEA()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= APLPHCFKBKP;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, LELHLNOGLED);
	}

	private void HDBBKHIBCBD(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= EOCPKOPGOLC;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PPHLEDLNGIN())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.ECHCLJJJPML())
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.Stop;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
			}
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.MGJIOLLKHDK();
			InvokeAfter(delegate
			{
				IDAOCGPNDBI(KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	protected virtual void CFDOAICAMGB(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void NAIHLMOEAEB(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= OPJHHEFKBBP;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PLPBGNOCCPI())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = false;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
			}
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.IPKNPABKAJD();
			InvokeAfter(IEGAKAFAKOH, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public virtual void PNJDBOIFEMF()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= NAIHLMOEAEB;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, HDBBKHIBCBD);
	}

	public virtual void IDKGHKBALEB()
	{
		base.OnInstancied();
		KAEAMDOJMIF.CJLPDLHIIGI();
		PJJJKFOANDO.JHGLCFPAPIK();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				AHCAEAFCNMM(KANKDLBGMLK: false);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(783f, 1309f);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
			PJJJKFOANDO.GGMKKIDFJOH();
		}
	}

	protected virtual void IKKJCOHOAEE(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void NGCLMHDGCAD()
	{
		IDAOCGPNDBI(KANKDLBGMLK: true);
	}

	private void APKBCLHCFIC()
	{
		BBFGFHGMEGH(KANKDLBGMLK: false);
	}

	public virtual void PBICPGAPNNH()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= IMBPCFOCJPI;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, MODEEODBPGO);
	}

	private void APLPHCFKBKP(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= IMBPCFOCJPI;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PPHLEDLNGIN())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.ECHCLJJJPML())
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
			}
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.MGJIOLLKHDK();
			InvokeAfter(PCNCHHDLMHB, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public virtual void EJDOMPDOCKD()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= LELHLNOGLED;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, EOCPKOPGOLC);
	}

	public virtual void FIFKHFJAPAG()
	{
		base.OnInstancied();
		KAEAMDOJMIF.ResetAiming();
		PJJJKFOANDO.NHGIJBNBLIC();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				GGKHLBONKJF(KANKDLBGMLK: true);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(1243f, 1943f);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.MGJIOLLKHDK();
			PJJJKFOANDO.BBBLJNFEACC();
		}
	}

	public virtual void KCNFAKFCFHH(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(1280f, 1379f);
		}
		else
		{
			FAJKAOFMDNF(1033f, 957f);
		}
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: false);
	}

	public virtual void OCEOOGDKBHA()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= HDBBKHIBCBD;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, IMBPCFOCJPI);
	}

	private void EOCPKOPGOLC(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FBAHMKEDEJN;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PLPBGNOCCPI())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.ECHCLJJJPML())
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
			}
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.GGMKKIDFJOH();
			InvokeAfter(AKNOMEDCKAJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public override void KALNJKOBCAN()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= HIAFJAKBGHG;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, LELHLNOGLED);
	}

	protected virtual void MHPFMNLALNL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void IBANBKGKKNA()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.carBehaviourDefinititon.health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-128)).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.OLKMMBNBEOB().damage;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		bulletSetup.JPNAINOGAMM = base.currentBeh.PNEKGALOFCJ().shotSpeed;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.OEDCHCGJOIG().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.OLKMMBNBEOB().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.PNEKGALOFCJ().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.BOLKLBLLEAA().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.POOBBDJPCMN().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.EPDELOGPNAC = base.currentBeh.NAILHGJFJBH().special * 316f;
		missileSetup.ABFGHBDEBAN = base.currentBeh.BDJAHILMEAA().special;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.JGACHOEBKJG = 1438f;
		PJJJKFOANDO.KMCFBCNNMGF = 1204f;
		PJJJKFOANDO.LLOHEBJBBDH = 1270f;
	}

	private void IMBPCFOCJPI(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FPACCEEKHMA;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && JHJJKEBNGEN())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.Stop;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
			}
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.BBBLJNFEACC();
			InvokeAfter(OIEFPGMJLOC, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	private void FMILGFFPCAD(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FBAHMKEDEJN;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PLPBGNOCCPI())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = false;
				brakeCondition = FFKHOHMOBHH.Stop;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
			}
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.HEOPOOMLPJF();
			InvokeAfter(NGCLMHDGCAD, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public virtual void MHBGKDMIMJB()
	{
		base.OnInstancied();
		KAEAMDOJMIF.NHGIJBNBLIC();
		PJJJKFOANDO.MIAFDNDBJJF();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				JINPPMKANPL(KANKDLBGMLK: false);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(862f, 1210f);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.MGJIOLLKHDK();
			PJJJKFOANDO.Reset();
		}
	}

	public virtual void ADKHAKMLJKF()
	{
		base.OnInstancied();
		KAEAMDOJMIF.IEHMPLOKAHC();
		PJJJKFOANDO.MIAFDNDBJJF();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				IDAOCGPNDBI(KANKDLBGMLK: true);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(1993f, 643f);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.MGJIOLLKHDK();
			PJJJKFOANDO.GGMKKIDFJOH();
		}
	}

	private void IEGAKAFAKOH()
	{
		IDAOCGPNDBI(KANKDLBGMLK: false);
	}

	public virtual void JGGNIIPKNLB(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(974f, 1645f);
		}
		else
		{
			FAJKAOFMDNF(73f, 1226f);
		}
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: false);
	}

	protected override void DJPIEOMBAAN(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(GHAGNCHNHEE, BDAKFIFCHLB, FBAHMKEDEJN);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	private void HIAFJAKBGHG(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= APLPHCFKBKP;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PPHLEDLNGIN())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = false;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
			}
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.IPKNPABKAJD();
			InvokeAfter(AKNOMEDCKAJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	protected virtual void PDMCIALCJEO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void AHCAEAFCNMM(bool KANKDLBGMLK)
	{
		NLGBGOGCNKP = NLGBGOGCNKP ?? GetComponentInChildren<EnemyPointVehicle>();
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		NHJBHOBBHBO = KANKDLBGMLK;
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().FJBJNELBAIO(GIPEKIBEPEB, fraction, EEAMBOACAGF: true, NLGBGOGCNKP.FBGFMDOHAEG());
			NLGBGOGCNKP.IDNNIHBIMNO = GIPEKIBEPEB;
			GIPEKIBEPEB.NLGBGOGCNKP = NLGBGOGCNKP;
			GIPEKIBEPEB.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Walk);
			GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			VehicleBehaviourDefinititon vehicleBehaviourDefinititon = base.currentBeh.LKMCNMHOHCL();
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = vehicleBehaviourDefinititon.minShootTime;
			GIPEKIBEPEB.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = vehicleBehaviourDefinititon.maxShootTime;
			GIPEKIBEPEB.Killed += FBAHMKEDEJN;
			IDCFGLGCCEH = true;
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.NIGDCBDKKMJ();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= OPJHHEFKBBP;
		}
		OEBPFFBKBBD(NLGBGOGCNKP, OPJHHEFKBBP);
	}

	private void DAKNIJFJAIN()
	{
		DCJACJLHONG(KANKDLBGMLK: false);
	}

	protected virtual void AOCLLHOIKPO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void FBAHMKEDEJN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= NAIHLMOEAEB;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PLPBGNOCCPI())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = false;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
			}
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.HEOPOOMLPJF();
			InvokeAfter(PCNCHHDLMHB, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(0.7f, 0.16f);
		}
		else
		{
			FAJKAOFMDNF(0f, 0f);
		}
		PJJJKFOANDO.gameObject.SetActive(base.hasSpecial);
		GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: true);
	}

	private void OPJHHEFKBBP(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= OPJHHEFKBBP;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && base.isInstantiated)
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = true;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: false);
			}
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.Reset();
			InvokeAfter(delegate
			{
				IDAOCGPNDBI(KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	protected virtual void EODEIINLJPC(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void MCDCNKDBFEB()
	{
		base.OnInstancied();
		KAEAMDOJMIF.JNFKFJOECJE();
		PJJJKFOANDO.IEHMPLOKAHC();
		if (!LCDBACDIODH)
		{
			if (LAADDLGBFIG.isMine)
			{
				AHCAEAFCNMM(KANKDLBGMLK: false);
				SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, ((SpawnPointCar)FEFGKKDIGCI).MKIPAEDAADL);
			}
			FAJKAOFMDNF(1989f, 1413f);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
			PJJJKFOANDO.GGMKKIDFJOH();
		}
	}

	protected override void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	protected virtual void GMCNJCAJJPG(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(GHAGNCHNHEE, BDAKFIFCHLB, LELHLNOGLED);
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	private void LELHLNOGLED(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= NAIHLMOEAEB;
		if (MAIPDGCABNL == GIPEKIBEPEB && !IDCFGLGCCEH && PLPBGNOCCPI())
		{
			GIPEKIBEPEB.ClearEnemyPoint();
			IDCFGLGCCEH = false;
			EnemyController enemyController = (EnemyController)MAIPDGCABNL;
			enemyController.NLGBGOGCNKP = null;
			if (NHJBHOBBHBO && Singleton<GameController>.instance.isMission)
			{
				mDriving = true;
				brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
			}
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.NIGDCBDKKMJ();
			InvokeAfter(AKNOMEDCKAJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
	}

	private void OIEFPGMJLOC()
	{
		JINPPMKANPL(KANKDLBGMLK: false);
	}
}
