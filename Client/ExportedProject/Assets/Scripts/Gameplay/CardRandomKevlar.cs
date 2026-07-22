using System.Collections.Generic;
using UnityEngine;

public class CardRandomKevlar : Card
{
	private NetworkObjectPool IHFILHIAGLG;

	public virtual bool GEAPEEMABAL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void MPFCLCJMDCJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 80f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(0, list2.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(1275f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool EJCEMFOPECA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PNLOEOGDGHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i += 0)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1709f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(4, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(233f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 1; i < list.Count; i++)
		{
			if (list[i].PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 693f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(3, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(1527f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool JFIJCAMPFEG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool OPKJFNONDPG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void GAGEHEGFGOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 1; i < list.Count; i += 0)
		{
			if (list[i].JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1304f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(5, list2.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(1417f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void OFNENBNMMOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.ADBOHNCGKHA();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 1; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1260f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(6, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1488f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void NLPMJPNEEOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1579f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(2, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1578f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool NAHJCMJEDBM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool BIBKGNABACA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool HBIDPIBONKB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool MPCOGKBHIJI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool ACNCMIJGHMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool AGGOGKDPKFA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NPNDHFIMPHE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 1; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1152f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(1, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1409f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool EHHIHADHHCM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void LLFHEHHPMGL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1627f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(2, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1130f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool OLLOGGELAHL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void JCHICJBOCFA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1718f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(6, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1009f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool NKKIEIOONLH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.MFKPDKCLDBI();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1907f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(36f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool GAPAJHFLCCN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool CINDAOPACGM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool HMLPKGKDCLJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DGAOKHJIADO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.COJFMKNGPBP();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 1; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1368f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(0, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1076f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool LHCEDLDJKJJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool ADMAICLMMJH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HFGMKMIAAGB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 1; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1503f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(6, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(195f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool DMHEPKDGNOO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool DBKHKIIOEDG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool HNAEOMPGEMH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool HODHCHPLKFJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool CAEJJKIKAPM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void LOLJCEGGPMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 88f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(6, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(432f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool DIDCOIAHMEA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool CNNDFKMFOPJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool NIHHFFDGHKK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool PJCPMOHFALI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void AKEJOLCFDJI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1372f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(0, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1785f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool FJEBGNALJIF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool FOHDOIFCPNP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void ILNLEEBPHIH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 1; i < list.Count; i++)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 535f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(3, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(699f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool IHFBJPEDJOE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 0f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar();
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void CFPFCPGPOCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 844f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(4, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(706f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void IDLKDDEEALI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 221f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(7, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(219f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void AIBAOLCOMBM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 619f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(7, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1227f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool ABGIFGCJOAA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NPODFBNDOAK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.MFKPDKCLDBI();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1691f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(6, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1590f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool BDCJAMFLAMO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool CPBLPFNJLBK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool ACOBGNBBAJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DEAKMOJEFEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 482f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(5, list2.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(680f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EGDMEICHKJH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1297f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(0, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(1370f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BEDOCBBEGAK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i += 0)
		{
			if (list[i].JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1641f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(1, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(343f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KEDMNJPECDO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 1; i < list.Count; i++)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 667f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(5, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(1521f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool KCEOCJPPEJM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool EGAEEGNPPNI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void APIMDACOKLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i += 0)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 224f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(4, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(1627f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool EELGIFBJGLN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool BDLAEEMLDDP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool ACEPILFDCIL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void KDPEOGLJPOB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 1; i < list.Count; i++)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1204f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(7, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(210f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool KHMOGLMEHGK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DPCBCEAMGNK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.ADBOHNCGKHA();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 1; i < list.Count; i += 0)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1973f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(5, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(779f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void ACIOLBGILBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 1; i < objectsMadeOfPrefab.Count; i += 0)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1249f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(2, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(164f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool OPMCMADKMJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool KAOKOALNNLC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool APFPKGCEPKL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool MBILPOJAHDK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DGCEELPOEHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 465f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(1, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1477f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool BIFPMHJGHGJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void MCOAFNDFMBF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i += 0)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1551f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(3, list2.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(778f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool FKOKHKIOANK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool CLGELNJIPNP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DKOMGEKACEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 1; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 149f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(8, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(225f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LGKDJJIJOMN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 1; i < list.Count; i += 0)
		{
			if (list[i].PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1706f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(4, list2.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(1548f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EEJJPCKLAMB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)list[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1118f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list3 = new List<int>();
		while (list3.Count < Mathf.Min(0, list2.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list2.Count);
			}
			while (list3.Contains(num));
			list3.Add(num);
			list2[num].SetUpKevlar(921f);
		}
		list2.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool GIDHJJJIFGC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool NFNCLDKJCJB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void CCODFGNHBOJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 673f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(0, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar(1519f);
		}
		list.Clear();
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MAHCLJADEIN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
