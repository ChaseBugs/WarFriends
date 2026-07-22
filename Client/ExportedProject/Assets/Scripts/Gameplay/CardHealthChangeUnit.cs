using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CardHealthChangeUnit : Card
{
	[FormerlySerializedAs("JBEELCCPCHA")]
	public float EMJGLHNLDGD = 0.5f;

	[FormerlySerializedAs("FGBCJLFOJCB")]
	public string JGMNNPFBOMO = "game-card-ico-healingstorm";

	[FormerlySerializedAs("HKIHKGIICFD")]
	public bool AHPOKGJKGDA;

	[FormerlySerializedAs("KHLDFFAMDIP")]
	public bool GJOOGHFBFDJ;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool JAOOMCLDJFD;

	private bool KPBBNENJHPA;

	private PlayerController MBIAKMPDOPG;

	private SpawningManagerDeathMatch.ArmyUnitDefinition KDGKDOLCIHG;

	public virtual void BCBFENPIIMP()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NAFCEPENCPD;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MPLHDHIGICE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			JAOOMCLDJFD = true;
			KPBBNENJHPA = true;
			MBIAKMPDOPG.cardIconIndicator.EOEDEJKJKMN(JGMNNPFBOMO, NABOFKMBMKH: true);
		}
	}

	private void HDBLMKOAEJE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("69dfa7c2");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void CBHJEHCBLCG(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("VIP");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BJCIHHDEJLG));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(KPOHABMDFFL));
			AIObject.AfterSpawned += MECIMBCEPEH;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF(JGMNNPFBOMO, NABOFKMBMKH: true);
	}

	public virtual void OJLEHLGEMLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LCLKEIAGCFN(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DHAHBJDIJHH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void EKLPOFAMLJK(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1690.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public virtual void LIEFDNNMNAP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MKOGOCPMAEA(CIOPAKLHFIL);
		}
	}

	private void PMNMFJPPAAK(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void OMNMPBCHGOM(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void COCGIAHIAFP(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 771.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.APJEBOPJPLA();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void KPOHABMDFFL(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void LBDALMLDEAD(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 711.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.MCHGNPBACBJ(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void DHAHBJDIJHH(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("Squad: {0}  SquadPoints: {1}  Reputations: {2}  SquadRank: {3}");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACLOLIHHKHA));
			AIObject.AfterSpawned += MECIMBCEPEH;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE(JGMNNPFBOMO, NABOFKMBMKH: false, HGNIGKCLLHM: true);
	}

	public virtual void FMGMNCGPGFL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MKOGOCPMAEA(CIOPAKLHFIL);
		}
	}

	public virtual void FHPAJBONKON(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EJNMOHAPNFH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void FFHCOKEKNMD(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("HP: {0} ACC: {1} SHS: {2}SP: {3}");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OFJMLGBMNPD));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OMNMPBCHGOM));
			AIObject.AfterSpawned += BMMBJOFANIN;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO(JGMNNPFBOMO, NABOFKMBMKH: false);
	}

	public virtual void BDBJJDHPJGM()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FEEDMLOILNJ;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OJAKFJODCNP));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OMBDHAAPHLH));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = true;
			MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL(JGMNNPFBOMO, NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
	}

	private void BMMBJOFANIN(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1187.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.APJEBOPJPLA();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void PDBKPIBDGEJ(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1401.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public virtual void NMOKBODAKHB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= MECIMBCEPEH;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(HDBLMKOAEJE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MEAKJKMHINK));
			JAOOMCLDJFD = true;
			KPBBNENJHPA = false;
			MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH(JGMNNPFBOMO, NABOFKMBMKH: true);
		}
	}

	private void LAAALDJHEIE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("[CardHealthChangeUnit] start new spawning before used spawning finish");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void MLEBPBFEOKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MAOGCCLPAGB(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void HNHKJDLIFJG()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= HAIABCMEKCP;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BJCIHHDEJLG));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = false;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE(JGMNNPFBOMO, NABOFKMBMKH: false);
		}
	}

	private void OJAKFJODCNP(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("{");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void ILGMMCAGIIM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LCLKEIAGCFN(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void MIOFIHJOHJL(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void GEGOIAIIJEN(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void CNNDGKAAEAH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CEKHLHHCONK(CIOPAKLHFIL);
		}
	}

	private void OMBDHAAPHLH(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void KDPEOGLJPOB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MAOGCCLPAGB(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JMOEJDAJMOH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			FFHCOKEKNMD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void PMHBDFDNDKL(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("WarFriends");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EDLNLFPIDFK));
			AIObject.AfterSpawned += FEEDMLOILNJ;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH(JGMNNPFBOMO, NABOFKMBMKH: true, HGNIGKCLLHM: true);
	}

	private void DOAINAFDKJM(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("[CardHealthChangeUnit] - used again after spawning start, but before finish!!!");
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
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.Show(JGMNNPFBOMO, NABOFKMBMKH: true);
	}

	public virtual void NIAHNLPGODG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			FFHCOKEKNMD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.Refill();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void OOEDPELGKHI(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("leagueMembers");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BICMHBLIDAK));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned += OFDMLCEEJAF;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH(JGMNNPFBOMO, NABOFKMBMKH: true);
	}

	private void AAPNCMLGCLK(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("deliveryReduce");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EHLLNMHFOGE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned += OFDMLCEEJAF;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO(JGMNNPFBOMO, NABOFKMBMKH: false, HGNIGKCLLHM: true);
	}

	private void KJAHCKBFJLJ(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void EJNPEHDKDOH(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void FFLGCDPGDBC(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("ID_STATE_CONNECTINGTOSERVER");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void COKFNDMEGBI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			OLAAJDLDBGP(CIOPAKLHFIL);
		}
	}

	private void MAOGCCLPAGB(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ID_FACEBOOKINVITEFRIENDSTEXT-FIGHT");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MPLHDHIGICE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OMNMPBCHGOM));
			AIObject.AfterSpawned += COCGIAHIAFP;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.Show(JGMNNPFBOMO, NABOFKMBMKH: true, HGNIGKCLLHM: true);
	}

	public virtual void JGNCOJLCGFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			FFHCOKEKNMD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void EDLNLFPIDFK(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void JCIPDJMFFDB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EKLPOFAMLJK;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BICMHBLIDAK));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MEAKJKMHINK));
			JAOOMCLDJFD = true;
			KPBBNENJHPA = true;
			MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA(JGMNNPFBOMO, NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	private void BJCIHHDEJLG(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("Level");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void KKEPLAFJKOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EJNMOHAPNFH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KKKLOPOOINA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			OOEDPELGKHI(CIOPAKLHFIL);
		}
	}

	private void PBLENIDHNDC(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError(", ");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(FHAKAOKAPEG));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OOPIBBOHOEL));
			AIObject.AfterSpawned += BMMBJOFANIN;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL(JGMNNPFBOMO, NABOFKMBMKH: true);
	}

	private void MPLHDHIGICE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("Warbucks");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void PFDAKJJKHHN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PMHBDFDNDKL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void MOHBIBOFIME(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void ECJGKKEGCGA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HNOFOJBOMEH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BGLMKFDPDNB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PMHBDFDNDKL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOAINAFDKJM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void NDCBNKKHJOJ(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1702.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.Refill();
			}
			else
			{
				enemyController.OJIHGNJFPFM.MCHGNPBACBJ(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void DINPMCHPLMI(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void APIMDACOKLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LCLKEIAGCFN(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void ACLOLIHHKHA(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void EHLHDPHGLFA(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1487.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.APJEBOPJPLA();
			}
			else
			{
				enemyController.OJIHGNJFPFM.MCHGNPBACBJ(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public virtual void LAOLPNLFPJM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DOAINAFDKJM(CIOPAKLHFIL);
		}
	}

	public virtual void IDAFLCICMKD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DHAHBJDIJHH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void IAKCKOPFABO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CEKHLHHCONK(CIOPAKLHFIL);
		}
	}

	private void LBFKJBPKNII(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 857.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.MCHGNPBACBJ(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void FDIOFGGOOGI(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 509.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.APJEBOPJPLA();
			}
			else
			{
				enemyController.OJIHGNJFPFM.MCHGNPBACBJ(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public virtual void EGNFLFADMPP()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= HAIABCMEKCP;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BICMHBLIDAK));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(KPOHABMDFFL));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = true;
			MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO(JGMNNPFBOMO, NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	private void HAIABCMEKCP(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 929.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public virtual void FDEJIFMBBEF()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= HAIABCMEKCP;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MIOFIHJOHJL));
			JAOOMCLDJFD = true;
			KPBBNENJHPA = true;
			MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO(JGMNNPFBOMO, NABOFKMBMKH: false);
		}
	}

	private void LCLKEIAGCFN(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ID_UPGRADENOW");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(HDBLMKOAEJE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OMBDHAAPHLH));
			AIObject.AfterSpawned += COCGIAHIAFP;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL(JGMNNPFBOMO, NABOFKMBMKH: true, HGNIGKCLLHM: true);
	}

	private void CEKHLHHCONK(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("#Notifications# Received a with data id = {0}");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EHLLNMHFOGE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(DINPMCHPLMI));
			AIObject.AfterSpawned += EKLPOFAMLJK;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME(JGMNNPFBOMO, NABOFKMBMKH: false, HGNIGKCLLHM: true);
	}

	private void AHNGHFCAKHK(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1514.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.Refill();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public virtual void MOIEAEMCOID()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FEEDMLOILNJ;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACLOLIHHKHA));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = true;
			MBIAKMPDOPG.cardIconIndicator.OFPAGLLFPPK(JGMNNPFBOMO, NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	private void MEAKJKMHINK(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	private void OFJMLGBMNPD(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("FB hosted app link: https://fb.me/1157647734253183");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void EHDCLHPLIHJ(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 949.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void OFDMLCEEJAF(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1252.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.Refill();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public virtual void OAJHAPCNJML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CBHJEHCBLCG(CIOPAKLHFIL);
		}
	}

	public virtual void IFHKCJGBDAN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			PBLENIDHNDC(CIOPAKLHFIL);
		}
	}

	private void FHAKAOKAPEG(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("\n\nDEBUG STATE: ");
			}
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void BICMHBLIDAK(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("ID_CONFIRM_ERROR");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void LOPOCGLOHLH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HNOFOJBOMEH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void HLBAHDMEALA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CEKHLHHCONK(CIOPAKLHFIL);
		}
	}

	private void NAFCEPENCPD(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 351.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void EJNMOHAPNFH(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("08");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MPLHDHIGICE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACLOLIHHKHA));
			AIObject.AfterSpawned += EHLHDPHGLFA;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.Show(JGMNNPFBOMO, NABOFKMBMKH: false);
	}

	public virtual void EOODECJEMIE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			OOEDPELGKHI(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void EELOEIHNOOH(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ID_CONTAINSXWARCARDS");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EHLLNMHFOGE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(ACLOLIHHKHA));
			AIObject.AfterSpawned += NDCBNKKHJOJ;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.Show(JGMNNPFBOMO, NABOFKMBMKH: false);
	}

	private void HNOFOJBOMEH(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("com/google/android/gms/common/api/Status");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OFJMLGBMNPD));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EDLNLFPIDFK));
			AIObject.AfterSpawned += NAFCEPENCPD;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH(JGMNNPFBOMO, NABOFKMBMKH: true);
	}

	public virtual void BKNCKLLMJHI()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EHLHDPHGLFA;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MPLHDHIGICE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(PMNMFJPPAAK));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = false;
			MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC(JGMNNPFBOMO, NABOFKMBMKH: true);
		}
	}

	private void OOPIBBOHOEL(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void LGCPPPIGHDE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MAOGCCLPAGB(CIOPAKLHFIL);
		}
	}

	public virtual void JNMGIFGMBPF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EELOEIHNOOH(CIOPAKLHFIL);
		}
	}

	private void EHLLNMHFOGE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			if (JAOOMCLDJFD)
			{
				Debug.LogError("[CardSickness] start new spawning before used spawning finish");
			}
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void CAMIINLBENC(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void DGCEELPOEHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HNOFOJBOMEH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void DKKPMPPNJEC(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 765.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.MCHGNPBACBJ(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
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
			MBIAKMPDOPG.cardIconIndicator.Show(JGMNNPFBOMO, NABOFKMBMKH: false);
		}
	}

	private void FEEDMLOILNJ(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 125.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.Refill();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	private void FJEDKLANBPF(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (!((CIOPAKLHFIL == ODCLPMADGFC) ^ AHPOKGJKGDA) && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null)
		{
			DisconnectEvents();
		}
	}

	public virtual void IOKJMNMABHC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			AAPNCMLGCLK(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void OLAAJDLDBGP(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("115 STAGE 5 STARTED");
			JAOOMCLDJFD = true;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OFJMLGBMNPD));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(CAMIINLBENC));
			AIObject.AfterSpawned += MECIMBCEPEH;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF(JGMNNPFBOMO, NABOFKMBMKH: false);
	}

	public virtual void JBNMBMOJPAK()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DCHCCCMKAGK;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BJCIHHDEJLG));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OMNMPBCHGOM));
			JAOOMCLDJFD = false;
			KPBBNENJHPA = true;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH(JGMNNPFBOMO, NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
	}

	private void DCHCCCMKAGK(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1443.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DOAINAFDKJM(CIOPAKLHFIL);
		}
	}

	private void MKOGOCPMAEA(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("Message");
			JAOOMCLDJFD = false;
		}
		if (!KPBBNENJHPA)
		{
			KPBBNENJHPA = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OFJMLGBMNPD));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(DINPMCHPLMI));
			AIObject.AfterSpawned += MECIMBCEPEH;
		}
		if (GJOOGHFBFDJ)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		}
		else
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		}
		MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE(JGMNNPFBOMO, NABOFKMBMKH: false);
	}

	public virtual void IICEPDLKIFP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			AAPNCMLGCLK(CIOPAKLHFIL);
		}
	}

	private void MECIMBCEPEH(AIObject KLHPCPKJGOC)
	{
		if (!JAOOMCLDJFD || ((KLHPCPKJGOC.fraction == ODCLPMADGFC) ^ AHPOKGJKGDA))
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (enemyController != null)
		{
			if ((double)EMJGLHNLDGD > 1529.0)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= EMJGLHNLDGD;
				enemyController.OJIHGNJFPFM.Refill();
			}
			else
			{
				enemyController.OJIHGNJFPFM.RefillTo(enemyController.OJIHGNJFPFM.maxHealth * EMJGLHNLDGD);
			}
		}
	}
}
