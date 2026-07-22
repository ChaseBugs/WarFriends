using System;
using System.Collections.Generic;
using UnityEngine;

public class CardBackstab : Card
{
	private NetworkObjectPool IHFILHIAGLG;

	private PlayerController MBIAKMPDOPG;

	public const string EJLCMBEKFFN = "game-card-ico-backstab";

	public virtual void NEPIKOKDBHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			NBJMKJIOEIK(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			PPABONIFFJC(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool IHFBJPEDJOE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void GJCKHJLEPKG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			FNOIEMOAJHL(CIOPAKLHFIL);
		}
	}

	public virtual bool MBILPOJAHDK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void CGEHACEDBOM(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.ADBOHNCGKHA();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1722f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(200f, list2.Count - 0);
		int index = (int)Math.Round(num, 0);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list2[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list2[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		list2[index].cardIconIndicator.GGHDIAFACAH("GameCenterManager: Authenticate called - canShowDialog:", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		list2[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	private void LPAOIHNCJOC(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 593f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(1891f, list2.Count - 1);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list2[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list2[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		list2[index].cardIconIndicator.LDGKPCDJPLA("PACK", NABOFKMBMKH: false);
		list2[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	public virtual bool GOMECHLBMMC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void JJCPMANBNJF(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.COJFMKNGPBP();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			if (item.JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1280f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(1507f, list2.Count - 0);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list2[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list2[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		list2[index].cardIconIndicator.JCJFMHGNIOF("placement", NABOFKMBMKH: true);
		list2[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	private void CLGPIFNBBLI(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 334f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(1155f, list.Count - 0);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		list[index].cardIconIndicator.BBJADAJPJHH("TuneListener trackerDidEnqueueUrl: ", NABOFKMBMKH: true);
		list[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	private void CEILKLHBHNJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 0f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(0f, list.Count - 1);
		int index = (int)Math.Round(num, 0);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list[index].gameObject.transform.forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		list[index].cardIconIndicator.Show("game-card-ico-backstab", NABOFKMBMKH: true);
		list[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	private void INFIHDFOGNB(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 935f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(628f, list2.Count - 0);
		int index = (int)Math.Round(num, 0);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list2[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list2[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		list2[index].cardIconIndicator.OFPAGLLFPPK("PlayerName", NABOFKMBMKH: false);
		list2[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			PPABONIFFJC(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void CEFBHGFLLOC(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 336f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(21f, list.Count - 0);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list[index].gameObject.transform.forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		list[index].cardIconIndicator.GCLFBCIKNAH("([,.!\\?-_:;]|\\s)", NABOFKMBMKH: false);
		list[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			JJCPMANBNJF(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void NBJEKFAOAHI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			INFIHDFOGNB(CIOPAKLHFIL);
		}
	}

	public virtual void MCJKBKPKDMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			LPAOIHNCJOC(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool JCBIDLIMNAN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void DIEPONMKBJF(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 387f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(1866f, list.Count - 0);
		int index = (int)Math.Round(num, 0);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		list[index].cardIconIndicator.DLNGGGOEDLL("WarFriends", NABOFKMBMKH: false);
		list[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	public virtual bool KDBLNFOLICC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HFGMKMIAAGB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			NBJMKJIOEIK(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool OFBIPJIEDPP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void KEDMNJPECDO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			CLGPIFNBBLI(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool BJODPJNOMLK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void IDNOCPDFCCD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			FNOIEMOAJHL(CIOPAKLHFIL);
		}
	}

	private void FBAOHGMIKDK(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1221f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(200f, list2.Count - 1);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list2[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list2[index].gameObject.transform.forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		list2[index].cardIconIndicator.FJILILFMPIF("WALLET - spent scraps {0}", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		list2[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			CEILKLHBHNJ(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PEGJJBMLEML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			NBJMKJIOEIK(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			FCGDMEKLGDH(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool KHMOGLMEHGK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void NBJMKJIOEIK(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 101f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(1644f, list2.Count - 1);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list2[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list2[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		list2[index].cardIconIndicator.PEBHGOMEKME(" {0}\u00a0{1}", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		list2[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			CEILKLHBHNJ(CIOPAKLHFIL);
		}
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void PPABONIFFJC(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.ADBOHNCGKHA();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 408f && enemyController.canBeFreezed)
				{
					list2.Add(enemyController);
				}
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(1775f, list2.Count - 0);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list2[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list2[index].gameObject.transform.forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		list2[index].cardIconIndicator.GCLFBCIKNAH("qbz2_idle", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		list2[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	private void FCGDMEKLGDH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 671f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(704f, list.Count - 0);
		int index = (int)Math.Round(num, 0);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list[index].gameObject.transform.forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		list[index].cardIconIndicator.FJILILFMPIF("Error Deserializing JSON for ", NABOFKMBMKH: true);
		list[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}

	private void FNOIEMOAJHL(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 1823f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(701f, list.Count - 1);
		int index = (int)Math.Round(num, 1);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = list[index].OJIHGNJFPFM.maxHealth,
			LPGMLOCLBGP = list[index].gameObject.transform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item2 in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item2.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		list[index].cardIconIndicator.GKAOMCGCDGE("facebookID", NABOFKMBMKH: true);
		list[index].OJIHGNJFPFM.DoDamage(kMJKKNFDFMM);
	}
}
