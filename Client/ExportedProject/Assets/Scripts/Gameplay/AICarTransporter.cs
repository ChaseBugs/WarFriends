using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CarController))]
public class AICarTransporter : AICarBase<CarTransporterBehaviour>
{
	private sealed class PJCLFNKKBJH
	{
		internal WayPointPath NMDBNHBDMJO;

		internal AICarTransporter BJGCPDNMHDH;

		internal void FIBGJHCGHJH()
		{
			BJGCPDNMHDH.DOPCNLMPKBJ(NMDBNHBDMJO);
		}

		internal void NNIJEDKBPGJ()
		{
			BJGCPDNMHDH.NMMLMIKBEHP(NMDBNHBDMJO);
		}

		internal void LHPPLGOOLEC()
		{
			BJGCPDNMHDH.IMBNBPOJLON(NMDBNHBDMJO);
		}

		internal void KJIFNOJILDB()
		{
			BJGCPDNMHDH.DOPCNLMPKBJ(NMDBNHBDMJO);
		}

		internal void LJCDGJKCNEC()
		{
			BJGCPDNMHDH.IMBNBPOJLON(NMDBNHBDMJO);
		}
	}

	[FormerlySerializedAs("NIAJCCMOEPL")]
	public EnemyPointVehicle BFLHDJMEFFE;

	[FormerlySerializedAs("EADEPGKMMJP")]
	public TransporterTurret KAEAMDOJMIF;

	[FormerlySerializedAs("LKKMJIDOMJK")]
	public List<WayPointPath> MJFOKJGNNIJ;

	private List<MiniDrone> HCEECPGJHJN = new List<MiniDrone>();

	public virtual void DLOGLCIOHFD(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(768f, 887f);
		}
		else
		{
			FAJKAOFMDNF(716f, 1992f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: false);
	}

	public virtual void MIDPOHMOMJP()
	{
		base.OnInstancied();
		KAEAMDOJMIF.ResetAiming();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 153f : 1369f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			NGNBNOJBIDP(KANKDLBGMLK: false, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ[FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 0]);
			if (base.hasSpecial)
			{
				MGMEEDJFEGJ();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.MGJIOLLKHDK();
		FAJKAOFMDNF(654f, 1874f);
	}

	public virtual void OHPOAJHEPDP()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.IECIICHOIKJ().health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-119)).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.KMFALEIINPH().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.KJKAECKLDLB().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.KNJDACBPFOC().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.PDFDHPAIJOG().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.APCAPJFEPDO().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.BCHOCFPLPGL().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.KEDLNEOHLAK().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void COCICBONBHH()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, BLCHKEMBIOA);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.Killed -= DMJGHEGNMFL;
		}
	}

	protected virtual void JIIJIAJEDMI(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, CBMEFBODLHB);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = true,
				EPDELOGPNAC = 1018f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.DIOEINBFJBG(LIBKKGHEJHH);
				item.destroyableObject.DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void BFGIIFEJCJH()
	{
		base.OnInstancied();
		KAEAMDOJMIF.ResetAiming();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 1942f : 1675f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			PJGEAAOIAGJ(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.ANAIBGIIJNO(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				KKABJGFNJEE();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.GGMKKIDFJOH();
		FAJKAOFMDNF(1928f, 1123f);
	}

	private void MHGNCKFIDPH()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			NMMLMIKBEHP(item);
		}
	}

	protected virtual void PMOIOADCKPO()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	private void AAAOMGCJNKL(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.BMNEPICFHNO().FJBJNELBAIO(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.FGKJILDKPHC(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Idle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.HKMBOBGCMCB();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += CBMEFBODLHB;
		}
	}

	protected virtual void PBABAOKEBEJ(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void OHEJEFLEPJJ(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= BOEGIPJLAGE;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.wayPointPath;
		InvokeAfterRealTime(pJCLFNKKBJH.NNIJEDKBPGJ, Random.Range(769f, 1311f));
	}

	public virtual void FIFKHFJAPAG()
	{
		base.OnInstancied();
		KAEAMDOJMIF.MCEPKEIINAA();
		EFPDLLPCGCB.MCPBHHMPPFJ((!LCDBACDIODH) ? 281f : 172f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			JINPPMKANPL(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.LJLCJIDJIEL(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 0));
			if (base.hasSpecial)
			{
				IIGPOMPKIEA();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.Reset();
		FAJKAOFMDNF(945f, 1700f);
	}

	protected virtual void HMNLAJOPDEL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void CLEDGDKIJDI(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(1429f, 1656f);
		}
		else
		{
			FAJKAOFMDNF(809f, 1806f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
	}

	private void EJNBDNGIOLI(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().Spawn(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.KPOEEKLFALL());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Rusher);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.BCHOCFPLPGL();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += MHLGKDEOOIB;
		}
	}

	public virtual void CADILLCGODA()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, BLCHKEMBIOA);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.DIOEINBFJBG(LLECKLPNNLF);
		}
	}

	protected virtual void DGINDFFBGAC(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, MHLGKDEOOIB);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = false,
				EPDELOGPNAC = 1424f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.Killed -= CDEKGHNCALE;
				item.NGMHBPOPFDN().DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
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
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.carTransporterBehaviourDefinititon;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += OPJHHEFKBBP;
		}
	}

	protected virtual void DLJDKNGAEGO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void GHGKCOPKIDM(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[1].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.KKCMCNCCIMB().CDLAPFKMGCM(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.SetWayPoint(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.transporterToRepair = this;
		miniDrone.LBFLPAKMIKM(base.currentBeh.IECIICHOIKJ().special);
		miniDrone.Killed += LIBKKGHEJHH;
		miniDrone.NGMHBPOPFDN().maxHealth = (float)base.currentBeh.EILJBMDGGBB().health * base.currentBeh.BCHOCFPLPGL().repairBotHP;
		miniDrone.destroyableObject.Refill();
		HCEECPGJHJN.Add(miniDrone);
	}

	public virtual void GHMJLNIFHMM()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.JMJLBDCCBGL().health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WarcardAdInterval).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.APCAPJFEPDO().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.KNJDACBPFOC().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.AMFOFKBJLBC().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.NEGCBJPLIAB().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.APCAPJFEPDO().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.BCHOCFPLPGL().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.IHHOHMCAFLO().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	protected virtual void JIADGGDEJIO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void AGFBBIOFIAD()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			HMKKFLDKHGA(item);
		}
	}

	private void LLGBHJFKNCN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= LLGBHJFKNCN;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.JAPHCAFHKGO();
		InvokeAfterRealTime(pJCLFNKKBJH.LHPPLGOOLEC, Random.Range(1953f, 1338f));
	}

	public override void JMAFCGDIICK()
	{
		base.OnInstancied();
		KAEAMDOJMIF.IEHMPLOKAHC();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 862f : 642f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			DFPNFCEOPLK(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.DEOBIHLLHCJ(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 0));
			if (base.hasSpecial)
			{
				POGOLMDBMGI();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.MGJIOLLKHDK();
		FAJKAOFMDNF(1684f, 1955f);
	}

	public virtual void KNLBMEIMGGH()
	{
		base.OnInstancied();
		KAEAMDOJMIF.MIAFDNDBJJF();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 504f : 283f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			NGNBNOJBIDP(KANKDLBGMLK: false, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.HHHAHIKHDOC(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 0));
			if (base.hasSpecial)
			{
				LCJLMOJLJFM();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.GGMKKIDFJOH();
		FAJKAOFMDNF(272f, 1672f);
	}

	private void CMEFMLBNFDI()
	{
		JINPPMKANPL(KANKDLBGMLK: false, BFLHDJMEFFE);
	}

	public virtual void NOBFBIPOCPB()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.EKNEADCFDJM().health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppReward).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.KMFALEIINPH().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.EAHNAILAILC().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.KKMOFHIDBMO().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.LDKLEMNGKMF().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.carTransporterBehaviourDefinititon.minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.KJKAECKLDLB().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.HKMBOBGCMCB().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void NMMLMIKBEHP(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[1].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.KKCMCNCCIMB().LFJGLEIEJGN(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.SetWayPoint(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.OGKJDPMBHEF(this);
		miniDrone.repairRatioPerSec = base.currentBeh.MMHDGGLKHCA().special;
		miniDrone.Killed += LIBKKGHEJHH;
		miniDrone.destroyableObject.maxHealth = (float)base.currentBeh.KKMOFHIDBMO().health * base.currentBeh.BCHOCFPLPGL().repairBotHP;
		miniDrone.destroyableObject.APJEBOPJPLA();
		HCEECPGJHJN.Add(miniDrone);
	}

	public virtual void ODONOHNOLHH()
	{
		base.ReSync();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	private void JINPPMKANPL(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().DEFBPHBPFCF(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.MOOGMFPMKEM(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Rusher);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.HKMBOBGCMCB();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += NGKMDHADEHN;
		}
	}

	private void FNPMNIHKKPC()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			OHGKGKLIIDM(item);
		}
	}

	private void PAOOEBLGMIB()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			LBFLBANLOJM(item);
		}
	}

	private void CBMEFBODLHB(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= NGKMDHADEHN;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(CMEFMLBNFDI, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
		}
	}

	protected virtual void GJDMGFNGDNB(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, OPJHHEFKBBP);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = true,
				EPDELOGPNAC = 896f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.Killed -= LLECKLPNNLF;
				item.destroyableObject.DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void MBLBLACFLAC()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.PDFDHPAIJOG().health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.KMFALEIINPH().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.JMJLBDCCBGL().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.BCHOCFPLPGL().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.NEGCBJPLIAB().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.PDFDHPAIJOG().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.NEEKJLMMJOE().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.NEEKJLMMJOE().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	protected virtual void JFKPFGJDIPM(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void IEBEKGBILEL()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.carTransporterBehaviourDefinititon.health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_VIPRewardDuration).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.EILJBMDGGBB().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.KJKAECKLDLB().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.IECIICHOIKJ().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.KEDLNEOHLAK().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.KJKAECKLDLB().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.HKMBOBGCMCB().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.LDKLEMNGKMF().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void CGKEMGOFKFJ()
	{
		base.NJHLFLIBBCL();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	private void GGEICMLCJHG(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= KFPKJOANFDD;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(PCNCHHDLMHB, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
		}
	}

	private void KFPKJOANFDD(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= BLCHKEMBIOA;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(PBEDDAGADAP, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.BBBLJNFEACC();
		}
	}

	public virtual void JHIOGMNJGMI()
	{
		base.OnInstancied();
		KAEAMDOJMIF.JHGLCFPAPIK();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 588f : 734f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			PJGEAAOIAGJ(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.PBCBBBFOLFP(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				POGOLMDBMGI();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.IPKNPABKAJD();
		FAJKAOFMDNF(1347f, 704f);
	}

	public virtual void KCMEHKMFPKN()
	{
		base.OnInstancied();
		KAEAMDOJMIF.JHGLCFPAPIK();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 568f : 1228f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			AAAOMGCJNKL(KANKDLBGMLK: false, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.NGBNBEKAOIA(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				PAOOEBLGMIB();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.BBBLJNFEACC();
		FAJKAOFMDNF(343f, 490f);
	}

	protected virtual void BFMNAMEJMIJ()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	public virtual void HHCKPKCGLDG()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, GGEICMLCJHG);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.CPGAEHGKAHL(OHEJEFLEPJJ);
		}
	}

	private void NGKMDHADEHN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= FPACCEEKHMA;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(PBEDDAGADAP, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
		}
	}

	protected virtual void GCOJHEDPIKL()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	private void JLCNLLPMGNN()
	{
		MEBLGNFBOEJ(KANKDLBGMLK: false, BFLHDJMEFFE);
	}

	private void LBFLBANLOJM(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[0].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.COJFMKNGPBP().DMDLDLBCMHE(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.OCOCNNIBDCB(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.OGKJDPMBHEF(this);
		miniDrone.LBFLPAKMIKM(base.currentBeh.JMJLBDCCBGL().special);
		miniDrone.Killed += CDEKGHNCALE;
		miniDrone.NGMHBPOPFDN().maxHealth = (float)base.currentBeh.APCAPJFEPDO().health * base.currentBeh.IHHOHMCAFLO().repairBotHP;
		miniDrone.NGMHBPOPFDN().OEAGCMGINCB();
		HCEECPGJHJN.Add(miniDrone);
	}

	protected virtual void PEKJOENHDDI()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	public virtual void IDCCNMMNDHO()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, OPJHHEFKBBP);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.Killed -= LIBKKGHEJHH;
		}
	}

	public virtual void OEMOOAENMHN()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, FPACCEEKHMA);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.MDBJJHNADJE(PAEDMDDGKBC);
		}
	}

	private void OHGKGKLIIDM(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[1].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.KJEANKAJELG().LFJGLEIEJGN(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.OCOCNNIBDCB(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.transporterToRepair = this;
		miniDrone.repairRatioPerSec = base.currentBeh.KKMOFHIDBMO().special;
		miniDrone.Killed += DMJGHEGNMFL;
		miniDrone.NGMHBPOPFDN().maxHealth = (float)base.currentBeh.IHHOHMCAFLO().health * base.currentBeh.KMFALEIINPH().repairBotHP;
		miniDrone.NGMHBPOPFDN().OEAGCMGINCB();
		HCEECPGJHJN.Add(miniDrone);
	}

	protected virtual void PPOHBNGGDJI(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, OPJHHEFKBBP);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = false,
				EPDELOGPNAC = 526f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.Killed -= LLECKLPNNLF;
				item.destroyableObject.DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	private void KKABJGFNJEE()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			IMBNBPOJLON(item);
		}
	}

	public virtual void AOCBOEBAFHF(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(1585f, 1519f);
		}
		else
		{
			FAJKAOFMDNF(643f, 453f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
	}

	private void AGCMOCCBKAB()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			DOPCNLMPKBJ(item);
		}
	}

	protected virtual void OFDJHFMAJBI()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	public virtual void GCNDLBLILAL()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, CBMEFBODLHB);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.CPGAEHGKAHL(OHEJEFLEPJJ);
		}
	}

	public virtual void FCOEGLMLAKG()
	{
		base.OnInstancied();
		KAEAMDOJMIF.JNFKFJOECJE();
		EFPDLLPCGCB.MCPBHHMPPFJ((!LCDBACDIODH) ? 94f : 841f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			AOEDDKEALMB(KANKDLBGMLK: false, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.DEOBIHLLHCJ(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				KKABJGFNJEE();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.HEOPOOMLPJF();
		FAJKAOFMDNF(138f, 1766f);
	}

	private void PJGEAAOIAGJ(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().JLGCKNOKGBL(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.MGPNABOBKFP());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Helicopter);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.GACPAFNOAPF();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = false;
			enemyController.Killed += FDOJDKIKDAF;
		}
	}

	public override void FLPDMLGAOMC()
	{
		base.OnInstancied();
		KAEAMDOJMIF.JNFKFJOECJE();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 1594f : 1798f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			EJNBDNGIOLI(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.DMKDFIJIBEP(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				KKBHANICOCD();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.GGMKKIDFJOH();
		FAJKAOFMDNF(1389f, 1348f);
	}

	public virtual void DAKBLLJKMDE()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, NGKMDHADEHN);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.Killed -= LLGBHJFKNCN;
		}
	}

	private void DOPCNLMPKBJ(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[1].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.DKNHCGGKNMF().NIHNNPIHFKD(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.SetWayPoint(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.OGKJDPMBHEF(this);
		miniDrone.repairRatioPerSec = base.currentBeh.KEDLNEOHLAK().special;
		miniDrone.Killed += LLECKLPNNLF;
		miniDrone.NGMHBPOPFDN().maxHealth = (float)base.currentBeh.KJKAECKLDLB().health * base.currentBeh.EILJBMDGGBB().repairBotHP;
		miniDrone.NGMHBPOPFDN().OEAGCMGINCB();
		HCEECPGJHJN.Add(miniDrone);
	}

	private void LDBKBKIEPOJ(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.DEFBPHBPFCF(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.MOOGMFPMKEM());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Parachute);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.NEEKJLMMJOE();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += FPACCEEKHMA;
		}
	}

	private void LFFIMGJHAGJ()
	{
		DFPNFCEOPLK(KANKDLBGMLK: false, BFLHDJMEFFE);
	}

	private void EFBBFGKBBKN()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			HMKKFLDKHGA(item);
		}
	}

	private void BDLEFCHHAIA()
	{
		AFMEAHLIGHC(KANKDLBGMLK: true, BFLHDJMEFFE);
	}

	protected virtual void JKHLHMHCJJO(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, KFPKJOANFDD);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = false,
				EPDELOGPNAC = 1853f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.MDBJJHNADJE(LLECKLPNNLF);
				item.destroyableObject.DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void ELHFLKNEJHG(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(963f, 1594f);
		}
		else
		{
			FAJKAOFMDNF(1318f, 1863f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
	}

	protected virtual void PNEKCEHBGPD()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	protected virtual void PCBFMABPBFG(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, FPACCEEKHMA);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = false,
				EPDELOGPNAC = 1107f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.DIOEINBFJBG(LLECKLPNNLF);
				item.destroyableObject.DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void CEEFPDOADBH()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.PDFDHPAIJOG().health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-18)).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.LDCBCMECIBL().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.AMFOFKBJLBC().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.carTransporterBehaviourDefinititon.fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.KJKAECKLDLB().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.EILJBMDGGBB().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.GACPAFNOAPF().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.carTransporterBehaviourDefinititon.probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public override void PEBOKCPJCBB()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, FDOJDKIKDAF);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.Killed -= OHEJEFLEPJJ;
		}
	}

	protected virtual void FMMKMEADDFI(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, FPACCEEKHMA);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = true,
				EPDELOGPNAC = 904f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.MDBJJHNADJE(DMJGHEGNMFL);
				item.NGMHBPOPFDN().DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void HBCALMGGFHP()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, GGEICMLCJHG);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.MDBJJHNADJE(PAEDMDDGKBC);
		}
	}

	private void POGOLMDBMGI()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			IMBNBPOJLON(item);
		}
	}

	private void DMJGHEGNMFL(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= DMJGHEGNMFL;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.wayPointPath;
		InvokeAfterRealTime(pJCLFNKKBJH.LJCDGJKCNEC, Random.Range(35f, 45f));
	}

	private void LCJLMOJLJFM()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			IMBNBPOJLON(item);
		}
	}

	private void PCNCHHDLMHB()
	{
		AOEDDKEALMB(KANKDLBGMLK: true, BFLHDJMEFFE);
	}

	private void AABENKBODGN(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[0].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.GLHPLCEFHGD().DMDLDLBCMHE(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.OCOCNNIBDCB(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.OGKJDPMBHEF(this);
		miniDrone.LBFLPAKMIKM(base.currentBeh.IECIICHOIKJ().special);
		miniDrone.Killed += CDEKGHNCALE;
		miniDrone.destroyableObject.maxHealth = (float)base.currentBeh.IECIICHOIKJ().health * base.currentBeh.KEDLNEOHLAK().repairBotHP;
		miniDrone.NGMHBPOPFDN().Refill();
		HCEECPGJHJN.Add(miniDrone);
	}

	private void FPACCEEKHMA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= OPJHHEFKBBP;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(LFFIMGJHAGJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.MGJIOLLKHDK();
		}
	}

	public virtual void AKCMKHMDIPB(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(1283f, 1073f);
		}
		else
		{
			FAJKAOFMDNF(1807f, 627f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
	}

	public virtual void LCGFIIMJJAJ()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.KDILGMAOLLF().health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-106)).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.HKMBOBGCMCB().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.KEDLNEOHLAK().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.KMFALEIINPH().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.EILJBMDGGBB().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.carTransporterBehaviourDefinititon.minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.EKNEADCFDJM().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.LDKLEMNGKMF().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void OPJHHEFKBBP(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= OPJHHEFKBBP;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(delegate
			{
				IDAOCGPNDBI(KANKDLBGMLK: false, BFLHDJMEFFE);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.Reset();
		}
	}

	private void IIGPOMPKIEA()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			GPJGEJBBGMJ(item);
		}
	}

	protected virtual void EFBNFJHJCGF(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, GGEICMLCJHG);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = true,
				EPDELOGPNAC = 644f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.MDBJJHNADJE(PAEDMDDGKBC);
				item.destroyableObject.DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	protected override void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void IMBNBPOJLON(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[0].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.networkPool.InstantiateNetwork(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.SetWayPoint(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.transporterToRepair = this;
		miniDrone.repairRatioPerSec = base.currentBeh.carTransporterBehaviourDefinititon.special;
		miniDrone.Killed += DMJGHEGNMFL;
		miniDrone.destroyableObject.maxHealth = (float)base.currentBeh.carTransporterBehaviourDefinititon.health * base.currentBeh.carTransporterBehaviourDefinititon.repairBotHP;
		miniDrone.destroyableObject.Refill();
		HCEECPGJHJN.Add(miniDrone);
	}

	public virtual void PJDBAOFEHDO(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(1384f, 1099f);
		}
		else
		{
			FAJKAOFMDNF(1660f, 1362f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
	}

	private void LIBKKGHEJHH(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= BOEGIPJLAGE;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.wayPointPath;
		InvokeAfterRealTime(pJCLFNKKBJH.LJCDGJKCNEC, Random.Range(1656f, 187f));
	}

	public virtual void DDOPOEJBDGA()
	{
		base.OnInstancied();
		KAEAMDOJMIF.NHGIJBNBLIC();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 156f : 1005f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			AOEDDKEALMB(KANKDLBGMLK: false, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.JJAOGCLMIEA(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				KKABJGFNJEE();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.MGJIOLLKHDK();
		FAJKAOFMDNF(286f, 678f);
	}

	protected virtual void BOPGJFGMNJM()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	public virtual void HJMFCGPNLPM()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.JMJLBDCCBGL().health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-17)).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.BCHOCFPLPGL().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.GACPAFNOAPF().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.NEGCBJPLIAB().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.IECIICHOIKJ().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.LDKLEMNGKMF().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.MMHDGGLKHCA().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.NEGCBJPLIAB().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void HMKKFLDKHGA(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[0].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.MFKPDKCLDBI().DMDLDLBCMHE(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.SetWayPoint(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.transporterToRepair = this;
		miniDrone.repairRatioPerSec = base.currentBeh.KNJDACBPFOC().special;
		miniDrone.Killed += CDEKGHNCALE;
		miniDrone.NGMHBPOPFDN().maxHealth = (float)base.currentBeh.IHHOHMCAFLO().health * base.currentBeh.MMHDGGLKHCA().repairBotHP;
		miniDrone.NGMHBPOPFDN().OEAGCMGINCB();
		HCEECPGJHJN.Add(miniDrone);
	}

	public virtual void NLIJBOCKKID()
	{
		base.OnInstancied();
		KAEAMDOJMIF.IEHMPLOKAHC();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 268f : 1151f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			NGNBNOJBIDP(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.DOBNHCEPNNP(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 0));
			if (base.hasSpecial)
			{
				EFBBFGKBBKN();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.BBBLJNFEACC();
		FAJKAOFMDNF(1671f, 248f);
	}

	public virtual void JFCDKHPGPAK()
	{
		base.ReSync();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	protected virtual void BAHDLPDOCDO()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	protected virtual void GDNNAEFLBPM(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public virtual void KLJDDCAOOAK()
	{
		base.NJHLFLIBBCL();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	public virtual void JAPFKKCPCIM(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(946f, 480f);
		}
		else
		{
			FAJKAOFMDNF(1282f, 87f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: false);
	}

	private void FKIHKMOJOGL()
	{
		JINPPMKANPL(KANKDLBGMLK: true, BFLHDJMEFFE);
	}

	private void HJMMMPGBOJF()
	{
		PJGEAAOIAGJ(KANKDLBGMLK: true, BFLHDJMEFFE);
	}

	private void MHLGKDEOOIB(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= KFPKJOANFDD;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(delegate
			{
				IDAOCGPNDBI(KANKDLBGMLK: false, BFLHDJMEFFE);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.NIGDCBDKKMJ();
		}
	}

	private void MGMEEDJFEGJ()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			AABENKBODGN(item);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		KAEAMDOJMIF.ResetAiming();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 1f : 1.7f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			IDAOCGPNDBI(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ[FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1]);
			if (base.hasSpecial)
			{
				POGOLMDBMGI();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.Reset();
		FAJKAOFMDNF(0.5f, 0.09f);
	}

	private void BPIBIMDFLHI(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[1].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.INOJHPIKICM().DFEMKMAMAGM(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.OCOCNNIBDCB(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.OGKJDPMBHEF(this);
		miniDrone.repairRatioPerSec = base.currentBeh.IHHOHMCAFLO().special;
		miniDrone.Killed += CDEKGHNCALE;
		miniDrone.destroyableObject.maxHealth = (float)base.currentBeh.NEEKJLMMJOE().health * base.currentBeh.PDFDHPAIJOG().repairBotHP;
		miniDrone.destroyableObject.Refill();
		HCEECPGJHJN.Add(miniDrone);
	}

	public virtual void CLNEFAJAPFD()
	{
		base.OnInstancied();
		KAEAMDOJMIF.MIAFDNDBJJF();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 189f : 1188f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			AOEDDKEALMB(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.BHKEOLDAIEE(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 0));
			if (base.hasSpecial)
			{
				AGFBBIOFIAD();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.HEOPOOMLPJF();
		FAJKAOFMDNF(1077f, 1841f);
	}

	private void FDOJDKIKDAF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= MHLGKDEOOIB;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(PBEDDAGADAP, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.GGMKKIDFJOH();
		}
	}

	public virtual void OPEANMHGPEO()
	{
		base.ReSync();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	public virtual void HEFMOGBPLND()
	{
		base.MAGNFBCGDDI();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	private void NGFCGPILFBI()
	{
		NACJCEGCHKD(KANKDLBGMLK: true, BFLHDJMEFFE);
	}

	public virtual void CHLBJIIMAJA(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(1842f, 1103f);
		}
		else
		{
			FAJKAOFMDNF(1475f, 847f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
	}

	public virtual void JCKJAAPKEHG()
	{
		base.OnInstancied();
		KAEAMDOJMIF.MLIIJGJENIE();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 1593f : 565f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			DFPNFCEOPLK(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.LCKLPAMGKDP(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				MHGNCKFIDPH();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.IPKNPABKAJD();
		FAJKAOFMDNF(101f, 1367f);
	}

	private void CDEKGHNCALE(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= DMJGHEGNMFL;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.wayPointPath;
		InvokeAfterRealTime(pJCLFNKKBJH.FIBGJHCGHJH, Random.Range(630f, 894f));
	}

	protected virtual void NPHAFNIGEAN(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	protected virtual void CJPFLJAAODD()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	public override void HPPIBGEJMNL()
	{
		base.OnInstancied();
		KAEAMDOJMIF.JHGLCFPAPIK();
		EFPDLLPCGCB.MCPBHHMPPFJ((!LCDBACDIODH) ? 972f : 248f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			NACJCEGCHKD(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.BHKEOLDAIEE(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				IIGPOMPKIEA();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.MGJIOLLKHDK();
		FAJKAOFMDNF(1590f, 1948f);
	}

	public virtual void GMJGDOMOIFO()
	{
		base.NJHLFLIBBCL();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	protected virtual void DJJHBGCKAGA(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		base.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public override void ReSync()
	{
		base.ReSync();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	private void MAFNPJJPODN(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[0].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.ADBOHNCGKHA().AAOLAKJGODC(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.OCOCNNIBDCB(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.OGKJDPMBHEF(this);
		miniDrone.repairRatioPerSec = base.currentBeh.KEDLNEOHLAK().special;
		miniDrone.Killed += DMJGHEGNMFL;
		miniDrone.destroyableObject.maxHealth = (float)base.currentBeh.EKNEADCFDJM().health * base.currentBeh.NEGCBJPLIAB().repairBotHP;
		miniDrone.NGMHBPOPFDN().OEAGCMGINCB();
		HCEECPGJHJN.Add(miniDrone);
	}

	private void PBEDDAGADAP()
	{
		NGNBNOJBIDP(KANKDLBGMLK: true, BFLHDJMEFFE);
	}

	public virtual void KDIEJODLEEK()
	{
		base.NJHLFLIBBCL();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, OPJHHEFKBBP);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.Killed -= DMJGHEGNMFL;
		}
	}

	private void LFIICEOFGEG()
	{
		AFMEAHLIGHC(KANKDLBGMLK: true, BFLHDJMEFFE);
	}

	private void PAEDMDDGKBC(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= DMJGHEGNMFL;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.wayPointPath;
		InvokeAfterRealTime(pJCLFNKKBJH.KJIFNOJILDB, Random.Range(1051f, 1445f));
	}

	private void BLCHKEMBIOA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		MAIPDGCABNL.Killed -= MHLGKDEOOIB;
		EnemyController enemyController = (EnemyController)MAIPDGCABNL;
		if (enemyController.NLGBGOGCNKP == BFLHDJMEFFE)
		{
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(HJMMMPGBOJF, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.Reset();
		}
	}

	private void NACJCEGCHKD(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.LDGAKJJINEO().Spawn(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.MOOGMFPMKEM(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Swat);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.AMFOFKBJLBC();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += CBMEFBODLHB;
		}
	}

	private void BOEGIPJLAGE(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= LLECKLPNNLF;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.wayPointPath;
		InvokeAfterRealTime(pJCLFNKKBJH.KJIFNOJILDB, Random.Range(1378f, 362f));
	}

	private void NGPAILDDNMM(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[1].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.KJEANKAJELG().DFEMKMAMAGM(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.OCOCNNIBDCB(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.OGKJDPMBHEF(this);
		miniDrone.repairRatioPerSec = base.currentBeh.AMFOFKBJLBC().special;
		miniDrone.Killed += LIBKKGHEJHH;
		miniDrone.NGMHBPOPFDN().maxHealth = (float)base.currentBeh.LDKLEMNGKMF().health * base.currentBeh.KMFALEIINPH().repairBotHP;
		miniDrone.NGMHBPOPFDN().Refill();
		HCEECPGJHJN.Add(miniDrone);
	}

	public virtual void DOKMLFGACCK(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(585f, 1530f);
		}
		else
		{
			FAJKAOFMDNF(566f, 1321f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: false);
	}

	private void KKBHANICOCD()
	{
		HCEECPGJHJN.Clear();
		foreach (WayPointPath item in MJFOKJGNNIJ)
		{
			GPJGEJBBGMJ(item);
		}
	}

	private void NGNBNOJBIDP(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.BMNEPICFHNO().LMJOPLCEBAA(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.PFOBADFGAKF(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Parachute);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.LGPOHLDIKNK();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += KFPKJOANFDD;
		}
	}

	private void AOEDDKEALMB(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.BMNEPICFHNO().FJBJNELBAIO(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.MGPNABOBKFP(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Walk);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.LDKLEMNGKMF();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = false;
			enemyController.Killed += NGKMDHADEHN;
		}
	}

	public virtual void MFMIDADDDOH()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.EILJBMDGGBB().health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalVisualProbability).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.PDFDHPAIJOG().damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.KNJDACBPFOC().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.KMFALEIINPH().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.KNJDACBPFOC().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.LDKLEMNGKMF().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.NBMLJHLGKME().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.MFFCGMIBLBK().probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			FAJKAOFMDNF(0.5f, 0.09f);
		}
		else
		{
			FAJKAOFMDNF(0f, 0f);
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, BFLHDJMEFFE, DKIPMCCIKMF: true);
	}

	public virtual void NCOEKKPJOAF()
	{
		base.OnInstancied();
		KAEAMDOJMIF.NHGIJBNBLIC();
		EFPDLLPCGCB.MaxSpeed = ((!LCDBACDIODH) ? 1334f : 603f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			AOEDDKEALMB(KANKDLBGMLK: true, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.KBNCGICLDFF(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				IIGPOMPKIEA();
			}
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.BBBLJNFEACC();
		FAJKAOFMDNF(1390f, 1734f);
	}

	private void MEBLGNFBOEJ(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().FJBJNELBAIO(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.KPOEEKLFALL(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Idle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.KMFALEIINPH();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += CBMEFBODLHB;
		}
	}

	protected virtual void NICOJPNKLMM(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, NGKMDHADEHN);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = true,
				EPDELOGPNAC = 1126f,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.CPGAEHGKAHL(LIBKKGHEJHH);
				item.NGMHBPOPFDN().DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	public virtual void LHNBEMJCPAC()
	{
		base.MAGNFBCGDDI();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	public virtual void AKBGCBDNPMD()
	{
		base.NJHLFLIBBCL();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	[CompilerGenerated]
	private void BNGGHLNGLDO()
	{
		IDAOCGPNDBI(KANKDLBGMLK: false, BFLHDJMEFFE);
	}

	public virtual void KFMBOBPFBLM()
	{
		base.ReSync();
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.ReSync();
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.carTransporterBehaviourDefinititon.health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		foreach (BatchedWeapon item in KAEAMDOJMIF.GGKGGMNIDMI)
		{
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.EPDELOGPNAC = base.currentBeh.carTransporterBehaviourDefinititon.damage;
			bulletSetup.JPNAINOGAMM = base.currentBeh.carTransporterBehaviourDefinititon.shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.carTransporterBehaviourDefinititon.fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.carTransporterBehaviourDefinititon.fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.carTransporterBehaviourDefinititon.minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.carTransporterBehaviourDefinititon.maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.carTransporterBehaviourDefinititon.probabilityOfRealShot;
		KAEAMDOJMIF.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	protected override void DPFHODDILIF(DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		HNEMALNACJP(BFLHDJMEFFE, BDAKFIFCHLB, OPJHHEFKBBP);
		if (LAADDLGBFIG.isMine)
		{
			DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
			{
				KLOJNPBGFIG = false,
				EPDELOGPNAC = float.MaxValue,
				LPGMLOCLBGP = Vector3.up,
				HNFNINFCBEJ = null
			};
			foreach (MiniDrone item in HCEECPGJHJN)
			{
				item.Killed -= DMJGHEGNMFL;
				item.destroyableObject.DoDamage(kMJKKNFDFMM);
			}
		}
		base.DPFHODDILIF(BDAKFIFCHLB);
	}

	private void AFMEAHLIGHC(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.LMJOPLCEBAA(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.KOFFAHEAHEN());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Idle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.EKNEADCFDJM();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += KFPKJOANFDD;
		}
	}

	public virtual void MKNKCKLEHEE()
	{
		base.OnInstancied();
		KAEAMDOJMIF.MIAFDNDBJJF();
		EFPDLLPCGCB.MCPBHHMPPFJ((!LCDBACDIODH) ? 983f : 1060f);
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			EJNBDNGIOLI(KANKDLBGMLK: false, BFLHDJMEFFE);
			SetTarget(FEFGKKDIGCI.MEDNJFIDNIL, FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.LCKLPAMGKDP(FEFGKKDIGCI.MEDNJFIDNIL.KJKEAADMJPJ.items.Length - 1));
			if (base.hasSpecial)
			{
				FNPMNIHKKPC();
			}
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.GGMKKIDFJOH();
		FAJKAOFMDNF(266f, 320f);
	}

	private void LLECKLPNNLF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PJCLFNKKBJH pJCLFNKKBJH = new PJCLFNKKBJH();
		pJCLFNKKBJH.BJGCPDNMHDH = this;
		MAIPDGCABNL.Killed -= DMJGHEGNMFL;
		MiniDrone miniDrone = (MiniDrone)MAIPDGCABNL;
		HCEECPGJHJN.Remove(miniDrone);
		pJCLFNKKBJH.NMDBNHBDMJO = miniDrone.wayPointPath;
		InvokeAfterRealTime(pJCLFNKKBJH.LHPPLGOOLEC, Random.Range(1134f, 1802f));
	}

	private void GPJGEJBBGMJ(WayPointPath LEOPKHKDLEJ)
	{
		Transform transform = LEOPKHKDLEJ.wayPoints[1].transform;
		MiniDrone miniDrone = (MiniDrone)ObjectPoolDatabase.DKNHCGGKNMF().DMDLDLBCMHE(Singleton<ObjectPoolDatabase>.instance.NNNDICKBHMN, transform.position, transform.rotation);
		miniDrone.SetWayPoint(LEOPKHKDLEJ);
		miniDrone.fraction = fraction;
		miniDrone.transporterToRepair = this;
		miniDrone.LBFLPAKMIKM(base.currentBeh.KKMOFHIDBMO().special);
		miniDrone.Killed += DMJGHEGNMFL;
		miniDrone.destroyableObject.maxHealth = (float)base.currentBeh.JMJLBDCCBGL().health * base.currentBeh.NEEKJLMMJOE().repairBotHP;
		miniDrone.NGMHBPOPFDN().APJEBOPJPLA();
		HCEECPGJHJN.Add(miniDrone);
	}

	public virtual void AGDBBOCPACP()
	{
		base.DestroyPooled();
		OEBPFFBKBBD(BFLHDJMEFFE, FPACCEEKHMA);
		foreach (MiniDrone item in HCEECPGJHJN)
		{
			item.Killed -= LIBKKGHEJHH;
		}
	}

	protected override void Update()
	{
		if (!LCDBACDIODH)
		{
			base.Update();
		}
	}

	private void DFPNFCEOPLK(bool KANKDLBGMLK, EnemyPointVehicle PLMMBKGLGAB)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().CDHOPCCMOIH(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.KPOEEKLFALL(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Idle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
			CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon = base.currentBeh.LGPOHLDIKNK();
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime = carTransporterBehaviourDefinititon.minShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime = carTransporterBehaviourDefinititon.maxShootTime;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 0;
			enemyController.soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = carTransporterBehaviourDefinititon.probabilityOfRealShot;
			KAEAMDOJMIF.enabled = true;
			enemyController.Killed += OPJHHEFKBBP;
		}
	}
}
