using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardSickness : Card
{
	public string JGMNNPFBOMO = "game-card-ico-sickness";

	public float EMJGLHNLDGD = 0.5f;

	public float HGOEHFJHDPL = 0.5f;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool JAOOMCLDJFD;

	private bool KPBBNENJHPA;

	private SpawningManagerDeathMatch.ArmyUnitDefinition KDGKDOLCIHG;

	protected override string mBonusName
	{
		get
		{
			return "-" + MEJMLNDFDBP.JJBMMICPIIG(EMJGLHNLDGD);
		}
	}

	private void EIEEMKHIFGN(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction != ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.ImproveAllWeapons(HGOEHFJHDPL);
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
				enemyController.cardIconIndicator.LDGKPCDJPLA(JGMNNPFBOMO, true);
			}
		}
	}

	public virtual void AIBAOLCOMBM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOAINAFDKJM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void CLNHBANGEDC(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("#Notifications# Database Token = ");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACFNMOBPMIF));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned += NMBIPNICPOO;
		}
	}

	[SpecialName]
	protected virtual string JEHGHDLNFIE()
	{
		return "Bad object with NavigationHelperCapsule LAYER" + MEJMLNDFDBP.JJBMMICPIIG(EMJGLHNLDGD);
	}

	public virtual void COGOPICCGKI()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IHKPEBIILCB;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACFNMOBPMIF));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BFMCHKMIJHN));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = true;
		}
	}

	private void BFMCHKMIJHN(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CLNHBANGEDC(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void LAAALDJHEIE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && BJOIGFEOMHN.armyUnit.behaviour is SoldierBehaviour)
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("[CardSickness] start new spawning before used spawning finish");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void GEGOIAIIJEN(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	protected virtual string ADNGKOAFINC()
	{
		return "Cache: Removing " + MEJMLNDFDBP.JJBMMICPIIG(EMJGLHNLDGD);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DOAINAFDKJM(CIOPAKLHFIL);
		}
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CLNHBANGEDC(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BLDICPPHHPA()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EIEEMKHIFGN;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(FHAKAOKAPEG));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(FJEDKLANBPF));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = false;
		}
	}

	private void FHAKAOKAPEG(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && BJOIGFEOMHN.armyUnit.behaviour is SoldierBehaviour)
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("right");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void NFEMLBMEPLD(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ID_BRONZELOOTBOXSMALL");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MJJNDJBFGDI));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(CEOIIEBPFMM));
			AIObject.AfterSpawned += COCGIAHIAFP;
		}
	}

	private void MJJNDJBFGDI(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && BJOIGFEOMHN.armyUnit.behaviour is SoldierBehaviour)
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("PACK");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void DCNKOLHIMLD()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= COCGIAHIAFP;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACFNMOBPMIF));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(DKPDPPLBLPI));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = false;
		}
	}

	private void KNCCLKMDLFM(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && BJOIGFEOMHN.armyUnit.behaviour is SoldierBehaviour)
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("PromotedPlayerId");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void KJAHCKBFJLJ(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void IGJJHCKMDBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MLENOBHPNBD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void IDNOCPDFCCD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CLNHBANGEDC(CIOPAKLHFIL);
		}
	}

	public override void DisconnectEvents()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = false;
		}
	}

	[SpecialName]
	protected virtual string OGJOKBKBNLO()
	{
		return "Daily_mission_start" + MEJMLNDFDBP.JJBMMICPIIG(EMJGLHNLDGD);
	}

	public virtual void BDBJJDHPJGM()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EOCPGDEHNKO));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(DKPDPPLBLPI));
			JAOOMCLDJFD = true;
			KPBBNENJHPA = true;
		}
	}

	public virtual void NLPMJPNEEOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CLNHBANGEDC(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void FJEDKLANBPF(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void DOAINAFDKJM(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("[CardSickness] - used again after spawning start, but before finish!!!");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned += NMBIPNICPOO;
		}
	}

	private void EOCPGDEHNKO(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && BJOIGFEOMHN.armyUnit.behaviour is SoldierBehaviour)
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("GameCenterId");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	[SpecialName]
	protected virtual string OHLFMCAPGOJ()
	{
		return "), " + MEJMLNDFDBP.JJBMMICPIIG(EMJGLHNLDGD);
	}

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction != ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.ImproveAllWeapons(HGOEHFJHDPL);
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
				enemyController.cardIconIndicator.Show(JGMNNPFBOMO, true);
			}
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOAINAFDKJM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void COCGIAHIAFP(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction != ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.ImproveAllWeapons(HGOEHFJHDPL);
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
				enemyController.cardIconIndicator.JCJFMHGNIOF(JGMNNPFBOMO, false, true);
			}
		}
	}

	public virtual void LOPOCGLOHLH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NFEMLBMEPLD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void JAEPJIECJIJ(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void DKPDPPLBLPI(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void IHKPEBIILCB(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction != ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.ImproveAllWeapons(HGOEHFJHDPL);
				enemyController.OJIHGNJFPFM.MCHGNPBACBJ(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
				enemyController.cardIconIndicator.NNPILDOKNJO(JGMNNPFBOMO, false, true);
			}
		}
	}

	private void CEOIIEBPFMM(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void MLENOBHPNBD(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("Bot Cards does not contain id: ");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACFNMOBPMIF));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(CEOIIEBPFMM));
			AIObject.AfterSpawned += EIEEMKHIFGN;
		}
	}

	public virtual void NJJBJAAHBNP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HHLDCNOHKKB(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void PAPAPDFEFMF(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	protected virtual string NEPPGCLBOFA()
	{
		return "()F" + MEJMLNDFDBP.JJBMMICPIIG(EMJGLHNLDGD);
	}

	private void HHLDCNOHKKB(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ShotFrequencyMax");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EOCPGDEHNKO));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(PAPAPDFEFMF));
			AIObject.AfterSpawned += COCGIAHIAFP;
		}
	}

	private void ACFNMOBPMIF(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL != ODCLPMADGFC && BJOIGFEOMHN.armyUnit.behaviour is SoldierBehaviour)
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("Level");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}
}
