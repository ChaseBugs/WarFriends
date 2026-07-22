using System.Collections.Generic;
using UnityEngine;

public class CardPoisonedArmy : Card
{
	private const float ECPLEHPPPDB = 0.5f;

	private const float CDMKEBONMKG = 5f;

	private bool NNDMKIACBBM;

	private GHPGNELIDBM ODCLPMADGFC;

	private PlayerController MBIAKMPDOPG;

	private float BHABHIDDBLH;

	private float FJGBLENGCLG;

	private void MIABEDHCHAH()
	{
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			HNFNINFCBEJ = MBIAKMPDOPG,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Suicide
		};
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.MFKPDKCLDBI().GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = item as EnemyController;
				if (enemyController != null && enemyController.isAlive && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
				{
					kMJKKNFDFMM.EPDELOGPNAC = enemyController.destroyableObj.maxHealth / 1491f * 1000f * Random.Range(1363f, 1567f);
					enemyController.OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
				}
			}
		}
	}

	public virtual void CPALNIACCKB()
	{
		NNDMKIACBBM = false;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		NNDMKIACBBM = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		MBIAKMPDOPG = PlayerController.GetPlayerOld(ODCLPMADGFC);
		BHABHIDDBLH = 5f;
		MPJFKOLPDAO();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		NNDMKIACBBM = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		BHABHIDDBLH = 66f;
		JFCOMJMDNCL();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void MPJFKOLPDAO()
	{
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			HNFNINFCBEJ = MBIAKMPDOPG,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Poison
		};
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = item as EnemyController;
				if (enemyController != null && enemyController.isAlive && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
				{
					kMJKKNFDFMM.EPDELOGPNAC = enemyController.destroyableObj.maxHealth / 5f * 0.5f * Random.Range(0.5f, 0.75f);
					enemyController.OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
				}
			}
		}
	}

	public override void DisconnectEvents()
	{
		NNDMKIACBBM = false;
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		NNDMKIACBBM = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		BHABHIDDBLH = 1925f;
		MIABEDHCHAH();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void JFCOMJMDNCL()
	{
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			HNFNINFCBEJ = MBIAKMPDOPG,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Poison
		};
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = item as EnemyController;
				if (enemyController != null && enemyController.isAlive && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
				{
					kMJKKNFDFMM.EPDELOGPNAC = enemyController.destroyableObj.maxHealth / 661f * 716f * Random.Range(357f, 1736f);
					enemyController.OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
				}
			}
		}
	}

	protected void OFNEGNKMKKG()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1908f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			FJGBLENGCLG += Time.deltaTime;
			if (FJGBLENGCLG > 583f)
			{
				MIABEDHCHAH();
				FJGBLENGCLG -= 1047f;
			}
		}
		else
		{
			NNDMKIACBBM = false;
			BHABHIDDBLH = 1550f;
		}
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void ABMOHFELOFN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		NNDMKIACBBM = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		MBIAKMPDOPG = PlayerController.GetPlayerOld(ODCLPMADGFC);
		BHABHIDDBLH = 1551f;
		MIABEDHCHAH();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void Update()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 0f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			FJGBLENGCLG += Time.deltaTime;
			if (FJGBLENGCLG > 0.5f)
			{
				MPJFKOLPDAO();
				FJGBLENGCLG -= 0.5f;
			}
		}
		else
		{
			NNDMKIACBBM = false;
			BHABHIDDBLH = 0f;
		}
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		NNDMKIACBBM = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		BHABHIDDBLH = 1496f;
		JFCOMJMDNCL();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void CFIKIKCBGKI()
	{
		NNDMKIACBBM = false;
	}

	protected void OPMNIHDAHAA()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1894f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			FJGBLENGCLG += Time.deltaTime;
			if (FJGBLENGCLG > 872f)
			{
				MIABEDHCHAH();
				FJGBLENGCLG -= 1767f;
			}
		}
		else
		{
			NNDMKIACBBM = false;
			BHABHIDDBLH = 1550f;
		}
	}

	public virtual bool BJODPJNOMLK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 4)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NEPIKOKDBHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		NNDMKIACBBM = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(ODCLPMADGFC);
		BHABHIDDBLH = 1711f;
		MPJFKOLPDAO();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}
}
