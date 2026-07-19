using System.Collections.Generic;
using UnityEngine;

public class CardHeadsUp : Card
{
	public float CDMKEBONMKG = 15f;

	private const float IOOJGHMOODB = 1.5f;

	private NetworkObjectPool IHFILHIAGLG;

	private bool NNDMKIACBBM;

	private float BHABHIDDBLH;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool KPBBNENJHPA;

	private const string EJLCMBEKFFN = "game-card-ico-headsup";

	public virtual void LIEFDNNMNAP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EKBDILNKKFL(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void ECOEANEFCDO()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(649f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(825f, 0);
		enemyOf = PlayerController.GetPlayerOld(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(398f, 1);
	}

	public virtual void KDPEOGLJPOB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			ILIKCHCLBIH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void BLJDCBFEHML()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(782f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1679f, 0);
		enemyOf = PlayerController.CCPHMCAIJNA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(616f, 1);
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PDNJFAJLDCH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void DNHPFEFEMEO(GHPGNELIDBM CIOPAKLHFIL)
	{
		IOMBHMBMFFB(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= HAIABCMEKCP;
			AIObject.AfterSpawned += HAIABCMEKCP;
			KPBBNENJHPA = true;
		}
	}

	public virtual void FPEHDBIODEO()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EDJLCAAKFED;
			KPBBNENJHPA = false;
		}
	}

	private void IAEBOHOHBPO()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(413f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1821f, 0);
		enemyOf = PlayerController.GetPlayerOld(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1220f, 0);
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DNGMHNMPJCL(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void CFLALBENGJN()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 696f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			MHKGGCNCBGF();
			NNDMKIACBBM = true;
		}
	}

	protected void ECFIMCCNBBN()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 425f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			KGOHMHJJEJA();
			NNDMKIACBBM = true;
		}
	}

	private void EEBJCEEELBG(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1794f, 1);
				enemyController.cardIconIndicator.JOGFDHFOOBC("ID_MAXSTAT", BHABHIDDBLH, CDMKEBONMKG, false);
			}
		}
	}

	public virtual void EOODECJEMIE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PDNJFAJLDCH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void CONMCLCEAMM(GHPGNELIDBM CIOPAKLHFIL)
	{
		KALGLGDOOLN(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			AIObject.AfterSpawned += FEIKLKCDCLO;
			KPBBNENJHPA = true;
		}
	}

	private void HOKPJDMIBOH(GHPGNELIDBM CIOPAKLHFIL)
	{
		AMGNPLCNJMC(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FDIOFGGOOGI;
			AIObject.AfterSpawned += OPLNOCMDCLI;
			KPBBNENJHPA = true;
		}
	}

	private void IBPBPPAJPEJ()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1640f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1800f, 0);
		enemyOf = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1889f, 1);
	}

	private void NCNFGBAIIFD(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1719f, 1);
				enemyController.cardIconIndicator.JOGFDHFOOBC("WaitForGameEndResponse Try {0} action {1}", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1822f, 1);
		enemyOf.cardIconIndicator.AMFEDOOPGCL("ID_GUI_EQUIPPED", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(993f, 0);
		enemyOf.cardIconIndicator.Show("D2", CDMKEBONMKG, CDMKEBONMKG, false);
	}

	private void MFOABFGCMDF(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PLPBGNOCCPI() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(283f, 0);
				enemyController.cardIconIndicator.FFMLINMFADM("Fuseboxx: virtual goods offer accepted wtih object ", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(821f, 0);
		enemyOf.cardIconIndicator.FCANLIOLJNH("Hide reconnect dialog", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(332f, 1);
		enemyOf.cardIconIndicator.BELBLFGCCLJ("PlayerArmyPower", CDMKEBONMKG, CDMKEBONMKG, false);
	}

	private void JCOEDIKPJBO(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PLPBGNOCCPI() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(333f, 1);
				enemyController.cardIconIndicator.ODDNDGAAOCH("SpecialOffers", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(598f, 0);
		enemyOf.cardIconIndicator.LOFMDBHAFAO("Name", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1413f, 0);
		enemyOf.cardIconIndicator.AMFEDOOPGCL("game-label-won", CDMKEBONMKG, CDMKEBONMKG, false);
	}

	private void ONFPHFLLFFO(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(557f, 0);
				enemyController.cardIconIndicator.FFMLINMFADM("metalExplosion", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1709f, 0);
		enemyOf.cardIconIndicator.BELBLFGCCLJ("Note:", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1753f, 0);
		enemyOf.cardIconIndicator.Show("AdZone", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void MHKGGCNCBGF()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(30f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1391f, 0);
		enemyOf = PlayerController.HEAGPACBLJA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(189f, 1);
	}

	private void PDNJFAJLDCH(GHPGNELIDBM CIOPAKLHFIL)
	{
		HHAPEBHKBFI(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DOMKPAADIGJ;
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	public virtual void ILGMMCAGIIM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DNGMHNMPJCL(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void OILNMENAOMN()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1685f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(792f, 1);
		enemyOf = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(268f, 0);
	}

	public virtual void MMCIIOJDLHK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HOKPJDMIBOH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void OJLEHLGEMLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HOKPJDMIBOH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HAIABCMEKCP(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(490f, 0);
				enemyController.cardIconIndicator.AMFEDOOPGCL("+{0}%", BHABHIDDBLH, CDMKEBONMKG, false);
			}
		}
	}

	private void OPLNOCMDCLI(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(545f, 0);
				enemyController.cardIconIndicator.JOGFDHFOOBC("WENEEDTO", BHABHIDDBLH, CDMKEBONMKG, true);
			}
		}
	}

	private void EFNHDHKEPLJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		AKDPAEDPLIJ(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= MHPMELBCCMB;
			AIObject.AfterSpawned += EEBJCEEELBG;
			KPBBNENJHPA = true;
		}
	}

	private void NDJONPHPIMI(GHPGNELIDBM CIOPAKLHFIL)
	{
		DCHKHMMCIJE(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = false;
		}
	}

	private void FMIAGFNDJML(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(444f, 1);
				enemyController.cardIconIndicator.EEBNPGOCKFD("ShotFrequencyMaxCannon", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(711f, 1);
		enemyOf.cardIconIndicator.JEDGCOMDEKM("registerAge", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1285f, 1);
		enemyOf.cardIconIndicator.ODDNDGAAOCH("KEYBOARD DONNNEEEE, was canceled: ", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	public virtual void GBNLHEIMKLJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			ILIKCHCLBIH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	protected void OCBLKIFKJEG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1677f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			OILNMENAOMN();
			NNDMKIACBBM = true;
		}
	}

	private void IOMBHMBMFFB(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PLPBGNOCCPI() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1366f, 0);
				enemyController.cardIconIndicator.JOGFDHFOOBC("S", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1629f, 0);
		enemyOf.cardIconIndicator.JOGFDHFOOBC("An object of the desired type does not exist: ", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(260f, 1);
		enemyOf.cardIconIndicator.JEDGCOMDEKM("()Ljava/lang/String;", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	public override void DisconnectEvents()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = false;
		}
	}

	protected void GIHJKCGLGEB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 693f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			PLOJGHAEDIF();
			NNDMKIACBBM = false;
		}
	}

	private void HFIKLDBJGML()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(532f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1513f, 1);
		enemyOf = PlayerController.CCPHMCAIJNA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(949f, 0);
	}

	private void MHPMELBCCMB(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1284f, 0);
				enemyController.cardIconIndicator.FCANLIOLJNH("DepositedCards", BHABHIDDBLH, CDMKEBONMKG, true);
			}
		}
	}

	private void CFEIOLAEOLJ()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(748f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(288f, 1);
		enemyOf = PlayerController.GetPlayerOld(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1175f, 0);
	}

	private void DNGMHNMPJCL(GHPGNELIDBM CIOPAKLHFIL)
	{
		NCNFGBAIIFD(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= OPLNOCMDCLI;
			AIObject.AfterSpawned += DOMKPAADIGJ;
			KPBBNENJHPA = false;
		}
	}

	public virtual void MBMLMJPHOKP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			ILIKCHCLBIH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	protected void JJNMKIAJPNA()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1060f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			BLJDCBFEHML();
			NNDMKIACBBM = false;
		}
	}

	protected void IAPBHPLNNNO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 86f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			HIMGMKAJFLJ();
			NNDMKIACBBM = false;
		}
	}

	public virtual void LEJJDMBMPKO()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= OPLNOCMDCLI;
			KPBBNENJHPA = false;
		}
	}

	public virtual void KEDMNJPECDO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DNHPFEFEMEO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void OOPMEFHHFNK()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(974f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(250f, 0);
		enemyOf = PlayerController.CCPHMCAIJNA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(556f, 1);
	}

	private void EDJLCAAKFED(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1986f, 1);
				enemyController.cardIconIndicator.FFMLINMFADM("NULL WARCARD", BHABHIDDBLH, CDMKEBONMKG, false);
			}
		}
	}

	public virtual void KCJNPJOBDNE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CONMCLCEAMM(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void ONPDLDBODGD(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(74f, 1);
				enemyController.cardIconIndicator.FFMLINMFADM("Enemy Card {0} {1}", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(934f, 0);
		enemyOf.cardIconIndicator.BELBLFGCCLJ("Updating squad emblem from: {0} to: {1}", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(683f, 0);
		enemyOf.cardIconIndicator.JBMCFEMBPKE("RUN ON CHILDREN OF OBJECT \"", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void DCHKHMMCIJE(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.MFKPDKCLDBI();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(219f, 1);
				enemyController.cardIconIndicator.JEDGCOMDEKM("CARDS_MIN", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(73f, 1);
		enemyOf.cardIconIndicator.FCANLIOLJNH("ID_TWITTER_GAIN_AGAIN_TEXT", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(397f, 1);
		enemyOf.cardIconIndicator.JBMCFEMBPKE("M", CDMKEBONMKG, CDMKEBONMKG, false);
	}

	protected void ENIICMOFDIG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 324f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			IIIGIKMNOEJ();
			NNDMKIACBBM = false;
		}
	}

	private void KGOHMHJJEJA()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(137f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1298f, 0);
		enemyOf = PlayerController.HEAGPACBLJA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(832f, 0);
	}

	private void NECFJNNKBEM(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(624f, 0);
				enemyController.cardIconIndicator.AMFEDOOPGCL("No connection.", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1633f, 1);
		enemyOf.cardIconIndicator.BELBLFGCCLJ("RATE APP REMINDER\tVersion: {0}\tShown Times in this version: {1}/{2}", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1799f, 0);
		enemyOf.cardIconIndicator.EEBNPGOCKFD("NOT REMOVING FACEBOOK FROM CURRENTPLAYER", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void EHDCLHPLIHJ(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(916f, 0);
				enemyController.cardIconIndicator.FFMLINMFADM("ACD: Phone jail braked", BHABHIDDBLH, CDMKEBONMKG, false);
			}
		}
	}

	public virtual void NBJEKFAOAHI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DNGMHNMPJCL(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	private void INDKIEPALNH()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PLPBGNOCCPI() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1508f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1448f, 0);
		enemyOf = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(198f, 0);
	}

	public virtual void IJMDPLLHJNF()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FDIOFGGOOGI;
			KPBBNENJHPA = true;
		}
	}

	public virtual void EBAOBEANINE()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DOMKPAADIGJ;
			KPBBNENJHPA = true;
		}
	}

	private void FKDGPPFHLGC()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(139f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1625f, 1);
		enemyOf = PlayerController.HEAGPACBLJA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1410f, 0);
	}

	public virtual void BIDGKKBHCBA()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FDIOFGGOOGI;
			KPBBNENJHPA = false;
		}
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			KFMOIHGBJNN(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HHAPEBHKBFI(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.MFKPDKCLDBI();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1961f, 1);
				enemyController.cardIconIndicator.JOGFDHFOOBC("Gui Manager: Starting Messages Coroutine for: ", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1451f, 0);
		enemyOf.cardIconIndicator.AMFEDOOPGCL("ID_YOUNEEDMONEYTOBUY", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(118f, 0);
		enemyOf.cardIconIndicator.FCANLIOLJNH("ID_CONFIRM_INFO", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void MOJIGLDKPCC(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.ADBOHNCGKHA();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PLPBGNOCCPI() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1111f, 1);
				enemyController.cardIconIndicator.JEDGCOMDEKM("DecalManagerData", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1849f, 1);
		enemyOf.cardIconIndicator.JOGFDHFOOBC("ID_TABLE_AP", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(972f, 1);
		enemyOf.cardIconIndicator.BELBLFGCCLJ("GameGold", CDMKEBONMKG, CDMKEBONMKG, false);
	}

	private void KAPGNNMBFKI(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1906f, 1);
				enemyController.cardIconIndicator.JBMCFEMBPKE("SoldierHP", BHABHIDDBLH, CDMKEBONMKG, false);
			}
		}
	}

	private void DOMKPAADIGJ(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(154f, 0);
				enemyController.cardIconIndicator.FCANLIOLJNH("Warbucks", BHABHIDDBLH, CDMKEBONMKG, true);
			}
		}
	}

	private void NFJCLDLIDOL(GHPGNELIDBM CIOPAKLHFIL)
	{
		COMCNMOMILO(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EDJLCAAKFED;
			AIObject.AfterSpawned += DOMKPAADIGJ;
			KPBBNENJHPA = false;
		}
	}

	private void CLEALKAKMMD()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(263f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1715f, 1);
		enemyOf = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(822f, 1);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			LAALPCGGNPP(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void ILIKCHCLBIH(GHPGNELIDBM CIOPAKLHFIL)
	{
		HHAPEBHKBFI(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FDIOFGGOOGI;
			AIObject.AfterSpawned += EHDCLHPLIHJ;
			KPBBNENJHPA = true;
		}
	}

	private void LAALPCGGNPP(GHPGNELIDBM CIOPAKLHFIL)
	{
		KALGLGDOOLN(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	public virtual void NPAMMCJAFLL()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DOMKPAADIGJ;
			KPBBNENJHPA = true;
		}
	}

	public virtual void IKKEFBECFOD()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = false;
		}
	}

	private void COMCNMOMILO(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.ADBOHNCGKHA();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(290f, 0);
				enemyController.cardIconIndicator.FCANLIOLJNH("SciFi", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1865f, 1);
		enemyOf.cardIconIndicator.EEBNPGOCKFD(" S:", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(517f, 1);
		enemyOf.cardIconIndicator.FCANLIOLJNH("GO TO OFFER", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void KALGLGDOOLN(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1.5f, 1);
				enemyController.cardIconIndicator.Show("game-card-ico-headsup", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1.5f, 1);
		enemyOf.cardIconIndicator.Show("game-card-ico-headsup", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1.5f, 1);
		enemyOf.cardIconIndicator.Show("game-card-ico-headsup", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	public virtual void KGJHODJEFMB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= KAPGNNMBFKI;
			KPBBNENJHPA = false;
		}
	}

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1.5f, 1);
				enemyController.cardIconIndicator.Show("game-card-ico-headsup", BHABHIDDBLH, CDMKEBONMKG, true);
			}
		}
	}

	public virtual void NGMABAMINEE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EKBDILNKKFL(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	protected void IDPOHKDKDNL()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 434f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			PDEGGBMFLII();
			NNDMKIACBBM = false;
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LAALPCGGNPP(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void OLMPLJDKFAI()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1245f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(299f, 1);
		enemyOf = PlayerController.GetPlayerOld(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(908f, 0);
	}

	public virtual void IOIOHIHKFBN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NFJCLDLIDOL(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	private void PLOJGHAEDIF()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(647f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1589f, 0);
		enemyOf = PlayerController.GetPlayerOld(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1424f, 1);
	}

	private void FDIOFGGOOGI(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1961f, 0);
				enemyController.cardIconIndicator.ODDNDGAAOCH("\t\"TRUE\"", BHABHIDDBLH, CDMKEBONMKG, false);
			}
		}
	}

	public virtual void LOLJCEGGPMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PDNJFAJLDCH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void IICEPDLKIFP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CONMCLCEAMM(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	private void NPEIIEDKHCC(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PLPBGNOCCPI() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(106f, 0);
				enemyController.cardIconIndicator.ODDNDGAAOCH("Terms: On Age Verification Criteria Not Met ", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1392f, 0);
		enemyOf.cardIconIndicator.FCANLIOLJNH("FacebookId", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(858f, 1);
		enemyOf.cardIconIndicator.BELBLFGCCLJ("Id", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			PDEGGBMFLII();
			NNDMKIACBBM = false;
		}
	}

	private void JIMGAACEJGM()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1943f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(670f, 1);
		enemyOf = PlayerController.GetPlayerOld(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(613f, 1);
	}

	public virtual void OCNCHNBNCOL()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EHDCLHPLIHJ;
			KPBBNENJHPA = false;
		}
	}

	private void MDNCBJJAPHL(GHPGNELIDBM CIOPAKLHFIL)
	{
		AKDPAEDPLIJ(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			AIObject.AfterSpawned += EEBJCEEELBG;
			KPBBNENJHPA = true;
		}
	}

	private void FENJHHAJPEI(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.COJFMKNGPBP();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1680f, 0);
				enemyController.cardIconIndicator.JBMCFEMBPKE("ID_SALEPERCENTLINE", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(791f, 1);
		enemyOf.cardIconIndicator.JBMCFEMBPKE("rental for unexist unit: {0}", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1658f, 1);
		enemyOf.cardIconIndicator.ODDNDGAAOCH("Prefabs to go through: {0} + {1}\n", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void FEIKLKCDCLO(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1426f, 0);
				enemyController.cardIconIndicator.Show("S", BHABHIDDBLH, CDMKEBONMKG, false);
			}
		}
	}

	private void AKDPAEDPLIJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(867f, 1);
				enemyController.cardIconIndicator.FFMLINMFADM("ID_READYTIME", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1362f, 1);
		enemyOf.cardIconIndicator.EEBNPGOCKFD("#PETER# Weapon Screen - RIGHT BUTTON - should not happen", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(878f, 1);
		enemyOf.cardIconIndicator.ODDNDGAAOCH("There is no definition for card {0}", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void AMGNPLCNJMC(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(500f, 1);
				enemyController.cardIconIndicator.FCANLIOLJNH("ID_VISUALRARITY4", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(842f, 0);
		enemyOf.cardIconIndicator.FFMLINMFADM("Buy_Upgrade_For_Army_Unit", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(825f, 0);
		enemyOf.cardIconIndicator.FCANLIOLJNH("PlayerLevel", CDMKEBONMKG, CDMKEBONMKG, false);
	}

	private void BOOIDBMIHDB(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PLPBGNOCCPI() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1424f, 0);
				enemyController.cardIconIndicator.FCANLIOLJNH("testingideventtierreward", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1998f, 1);
		enemyOf.cardIconIndicator.FFMLINMFADM(" TOTAL MEMORY (GC): ", CDMKEBONMKG, CDMKEBONMKG, false);
		enemyOf = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(323f, 1);
		enemyOf.cardIconIndicator.FFMLINMFADM("Visual", CDMKEBONMKG, CDMKEBONMKG, false);
	}

	private void FDDGDDHMBCL(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1816f, 0);
				enemyController.cardIconIndicator.JEDGCOMDEKM("Squad", CDMKEBONMKG, CDMKEBONMKG, false);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1005f, 1);
		enemyOf.cardIconIndicator.LOFMDBHAFAO("WarArenaId with ID {0} not found in DB!", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1748f, 0);
		enemyOf.cardIconIndicator.LOFMDBHAFAO("HELMETS_SANTA", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	public virtual void JCIPDJMFFDB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DOMKPAADIGJ;
			KPBBNENJHPA = true;
		}
	}

	private void ODJFHKEBDFO()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1781f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1914f, 1);
		enemyOf = PlayerController.HEAGPACBLJA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1261f, 1);
	}

	private void PDEGGBMFLII()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(2f / 3f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(2f / 3f, 1);
		enemyOf = PlayerController.GetPlayerOld(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(2f / 3f, 1);
	}

	public virtual void NMOKBODAKHB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= MHPMELBCCMB;
			KPBBNENJHPA = false;
		}
	}

	public virtual void DALLEPFGPIC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			KFMOIHGBJNN(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void AGEIHHIEDPL(GHPGNELIDBM CIOPAKLHFIL)
	{
		FALGGBAODEN(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= OPLNOCMDCLI;
			AIObject.AfterSpawned += HAIABCMEKCP;
			KPBBNENJHPA = false;
		}
	}

	public virtual void CHGDCMOAEEN()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= MHPMELBCCMB;
			KPBBNENJHPA = false;
		}
	}

	public virtual void PDAPJMGBOFF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LAALPCGGNPP(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void OEEJHKFLFAB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 261f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			OLMPLJDKFAI();
			NNDMKIACBBM = true;
		}
	}

	private void HIMGMKAJFLJ()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(807f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1745f, 0);
		enemyOf = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1709f, 1);
	}

	private void FALGGBAODEN(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1629f, 1);
				enemyController.cardIconIndicator.LOFMDBHAFAO("ID_STAT_WINS", CDMKEBONMKG, CDMKEBONMKG, true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1728f, 1);
		enemyOf.cardIconIndicator.Show("WarFriends richiede l'autorizzazione alla memorizzazione multimediale per scaricare dati fondamentali per il gioco.Accetta la finestra di dialogo di autorizzazione che verrà visualizzata. Non useremo questa autorizzazione per altri scopi.", CDMKEBONMKG, CDMKEBONMKG, true);
		enemyOf = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		enemyOf.ChangeWeightForDestroyablePart(1174f, 1);
		enemyOf.cardIconIndicator.EEBNPGOCKFD("\t\"TRUE\"", CDMKEBONMKG, CDMKEBONMKG, true);
	}

	private void KFMOIHGBJNN(GHPGNELIDBM CIOPAKLHFIL)
	{
		FALGGBAODEN(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= OPLNOCMDCLI;
			AIObject.AfterSpawned += MHPMELBCCMB;
			KPBBNENJHPA = false;
		}
	}

	private void FBDHEMDMDDG()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.PPHLEDLNGIN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(253f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(917f, 1);
		enemyOf = PlayerController.HEAGPACBLJA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(35f, 1);
	}

	public virtual void KELMJCLFCJG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EFNHDHKEPLJ(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void EKBDILNKKFL(GHPGNELIDBM CIOPAKLHFIL)
	{
		MFOABFGCMDF(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FDIOFGGOOGI;
			AIObject.AfterSpawned += EHDCLHPLIHJ;
			KPBBNENJHPA = false;
		}
	}

	public virtual void BDBJJDHPJGM()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FDIOFGGOOGI;
			KPBBNENJHPA = true;
		}
	}

	public virtual void MGGLFJENAFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HOKPJDMIBOH(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BAALHHDAPNE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DNGMHNMPJCL(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void LNKCMGBDEDO(GHPGNELIDBM CIOPAKLHFIL)
	{
		FMIAGFNDJML(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= MHPMELBCCMB;
			AIObject.AfterSpawned += DOMKPAADIGJ;
			KPBBNENJHPA = false;
		}
	}

	private void IIIGIKMNOEJ()
	{
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != GHPGNELIDBM.None && enemyController.JHJJKEBNGEN() && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1327f, 0);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1607f, 1);
		enemyOf = PlayerController.CCPHMCAIJNA(ODCLPMADGFC);
		enemyOf.ChangeWeightForDestroyablePart(1099f, 1);
	}
}
