using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CardSoldiersShootout : Card
{
	[FormerlySerializedAs("ECMDHCFKLFN")]
	public float LJJHCEPJDNF = 0.75f;

	[FormerlySerializedAs("CFNCDFJOLNL")]
	public float KMLIBGBOPMG = 60f;

	private NetworkObjectPool IHFILHIAGLG;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool KPBBNENJHPA;

	private float BHABHIDDBLH;

	private bool IEDBBDLCLEL;

	private const string EJLCMBEKFFN = "game-card-ico-triggerhappy";

	protected override string mBonusName => MEJMLNDFDBP.KEPEILBMDMD(1f - LJJHCEPJDNF);

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.Show("game-card-ico-triggerhappy", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: true);
			}
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MGIHEKKKHNM(CIOPAKLHFIL);
		}
	}

	public virtual void BDBJJDHPJGM()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = false;
		}
	}

	protected void CHHKMBGOMJJ()
	{
		if (!IEDBBDLCLEL)
		{
			return;
		}
		if (BHABHIDDBLH > 1446f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			return;
		}
		BHABHIDDBLH = 247f;
		IEDBBDLCLEL = true;
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.OJIHGNJFPFM.health != 385f && enemyController.fraction == ODCLPMADGFC && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax /= LJJHCEPJDNF;
			}
		}
	}

	private void IMPNDIPLKLO(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = KMLIBGBOPMG;
			IEDBBDLCLEL = true;
			ODCLPMADGFC = CIOPAKLHFIL;
			OKBBIBBHHEP(ODCLPMADGFC);
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	public virtual bool APJIPKCJKLF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count < 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MGIHEKKKHNM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BLDICPPHHPA()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EKLPOFAMLJK;
			KPBBNENJHPA = true;
		}
	}

	private void BFOKJCKBLHJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = KMLIBGBOPMG;
			IEDBBDLCLEL = false;
			ODCLPMADGFC = CIOPAKLHFIL;
			BPGKEFPLNFK(ODCLPMADGFC);
			AIObject.AfterSpawned += EKLPOFAMLJK;
			KPBBNENJHPA = true;
		}
	}

	public virtual bool BIFPMHJGHGJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count < 6)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void OKBBIBBHHEP(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.OJIHGNJFPFM.health != 960f && enemyController.fraction == CIOPAKLHFIL && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.BELBLFGCCLJ("SlowMotionForNetwork", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: false);
			}
		}
	}

	public virtual void PIKDELOGJDK()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EKLPOFAMLJK;
			KPBBNENJHPA = false;
		}
	}

	[SpecialName]
	protected virtual string OLLAAADPKDL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(914f - LJJHCEPJDNF);
	}

	private void BPGKEFPLNFK(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.MFKPDKCLDBI();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.OJIHGNJFPFM.health != 286f && enemyController.fraction == CIOPAKLHFIL && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.JBMCFEMBPKE("Pack: Vip ", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: false);
			}
		}
	}

	public virtual void HHKFLIABFCA()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	public virtual void ADOPAMNECND(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FHACMLDBMEA(CIOPAKLHFIL);
		}
	}

	protected void AAABJNBFLEG()
	{
		if (!IEDBBDLCLEL)
		{
			return;
		}
		if (BHABHIDDBLH > 191f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			return;
		}
		BHABHIDDBLH = 748f;
		IEDBBDLCLEL = false;
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.OJIHGNJFPFM.health != 1567f && enemyController.fraction == ODCLPMADGFC && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax /= LJJHCEPJDNF;
			}
		}
	}

	private void MGIHEKKKHNM(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = KMLIBGBOPMG;
			IEDBBDLCLEL = true;
			ODCLPMADGFC = CIOPAKLHFIL;
			LCADNIKAICD(ODCLPMADGFC);
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	protected void JMHFNCOODKH()
	{
		if (!IEDBBDLCLEL)
		{
			return;
		}
		if (BHABHIDDBLH > 1328f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			return;
		}
		BHABHIDDBLH = 1319f;
		IEDBBDLCLEL = true;
		DisconnectEvents();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.OJIHGNJFPFM.health != 705f && enemyController.fraction == ODCLPMADGFC && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax /= LJJHCEPJDNF;
			}
		}
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BFOKJCKBLHJ(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void DisconnectEvents()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = false;
		}
	}

	private void LCADNIKAICD(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.OJIHGNJFPFM.health != 0f && enemyController.fraction == CIOPAKLHFIL && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.Show("game-card-ico-triggerhappy", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: true);
			}
		}
	}

	protected void EKPBOMOMMFB()
	{
		if (!IEDBBDLCLEL)
		{
			return;
		}
		if (BHABHIDDBLH > 1682f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			return;
		}
		BHABHIDDBLH = 95f;
		IEDBBDLCLEL = true;
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.OJIHGNJFPFM.health != 1478f && enemyController.fraction == ODCLPMADGFC && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax /= LJJHCEPJDNF;
			}
		}
	}

	public virtual void EMGGMHONMCM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FHACMLDBMEA(CIOPAKLHFIL);
		}
	}

	public virtual void GKDDIKLDCHC()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= EKLPOFAMLJK;
			KPBBNENJHPA = true;
		}
	}

	private void BKLINCKMMJM(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = KMLIBGBOPMG;
			IEDBBDLCLEL = true;
			ODCLPMADGFC = CIOPAKLHFIL;
			OKBBIBBHHEP(ODCLPMADGFC);
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	private void AKHLCGMIIBN(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PLPBGNOCCPI() && enemyController.OJIHGNJFPFM.health != 81f && enemyController.fraction == CIOPAKLHFIL && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.FFMLINMFADM("Bad Player Visuals!", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: false);
			}
		}
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MGIHEKKKHNM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string FPKCIMDCGHK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(1116f - LJJHCEPJDNF);
	}

	protected void Update()
	{
		if (!IEDBBDLCLEL)
		{
			return;
		}
		if (BHABHIDDBLH > 0f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			return;
		}
		BHABHIDDBLH = 0f;
		IEDBBDLCLEL = false;
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.OJIHGNJFPFM.health != 0f && enemyController.fraction == ODCLPMADGFC && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin /= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax /= LJJHCEPJDNF;
			}
		}
	}

	private void KAFONELJPEM(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.OJIHGNJFPFM.health != 1668f && enemyController.fraction == CIOPAKLHFIL && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.FCANLIOLJNH("N", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: true);
			}
		}
	}

	private void FHACMLDBMEA(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = KMLIBGBOPMG;
			IEDBBDLCLEL = false;
			ODCLPMADGFC = CIOPAKLHFIL;
			OKBBIBBHHEP(ODCLPMADGFC);
			AIObject.AfterSpawned += EKLPOFAMLJK;
			KPBBNENJHPA = false;
		}
	}

	public virtual void COKFNDMEGBI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FHACMLDBMEA(CIOPAKLHFIL);
		}
	}

	private void IDLALOOEGLD(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.OJIHGNJFPFM.health != 476f && enemyController.fraction == CIOPAKLHFIL && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.EEBNPGOCKFD(" was activated.", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: false);
			}
		}
	}

	[SpecialName]
	protected virtual string DMGHILGBHAB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(156f - LJJHCEPJDNF);
	}

	public virtual bool ACOBGNBBAJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count < 4)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void EKLPOFAMLJK(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= LJJHCEPJDNF;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= LJJHCEPJDNF;
				enemyController.cardIconIndicator.EEBNPGOCKFD(")", BHABHIDDBLH, KMLIBGBOPMG, GBJOJBKCEKN: true);
			}
		}
	}
}
