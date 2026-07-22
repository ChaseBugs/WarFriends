using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardHeadAhead : Card
{
	private List<float> CMDFFAJOAPE = new List<float>();

	private const float DNGPFHOCADB = 1.5f;

	private NetworkObjectPool IHFILHIAGLG;

	private bool NNDMKIACBBM;

	private bool CIADCEEGLAH;

	private float BHABHIDDBLH;

	private GHPGNELIDBM DMLJBALELCO;

	private PlayerController MBIAKMPDOPG;

	private PlayerController OLHENPNIINE;

	private bool KPBBNENJHPA;

	public float criticalChance => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.HeadAheadCritical).FLOATVALUE;

	private float GNCDFDFKHBO => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.HeadAheadTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(GNCDFDFKHBO), MEJMLNDFDBP.JJBMMICPIIG(criticalChance));

	public virtual void EHFGLMCNOJN()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= MFPOHEHPODE;
			KPBBNENJHPA = true;
			BGPDGFAFACP();
		}
	}

	public virtual void PFLGKCELNOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			BHABHIDDBLH = BGMDNNDEKOB();
			NNDMKIACBBM = false;
			LOLOPFIFFIG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		CIADCEEGLAH = true;
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = GADKELBDFIM();
		}
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			BHABHIDDBLH = GNCDFDFKHBO;
			NNDMKIACBBM = false;
			AJFAIDKMDCI(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		CIADCEEGLAH = false;
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = DOLGFBOFMIL();
		}
	}

	private void OPNMLIPEEMA(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += DFCHKAIAAPN;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.MFKPDKCLDBI();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(786f);
			}
		}
	}

	private void JIJLDDEJAFF()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = false;
			for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	private void BHFGLHDBFNN()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PLPBGNOCCPI() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(211f);
			}
		}
		DisconnectEvents();
	}

	private void KENCAAMLNHD()
	{
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(2f);
			}
		}
		DisconnectEvents();
	}

	protected void BHIABNNGKFO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1369f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			BHFGLHDBFNN();
			BGPDGFAFACP();
			NNDMKIACBBM = true;
		}
	}

	[SpecialName]
	public float DOLGFBOFMIL()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ShieldsUpCoef).FLOATVALUE;
	}

	private void HLJMKKDKJLI()
	{
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(1004f);
			}
		}
		DisconnectEvents();
	}

	[SpecialName]
	public float HFHGCFGFDDL()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-49)).FLOATVALUE;
	}

	private void JIMGAACEJGM()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PLPBGNOCCPI() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(1420f);
			}
		}
		DisconnectEvents();
	}

	private void HBCIMLCBCMA()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(8f);
			}
		}
		DisconnectEvents();
	}

	private void DMBBMHNDGCA()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = false;
			for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	private void MFPOHEHPODE(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1455f);
			}
		}
	}

	private void KGBLKFGHOAF(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(111f);
			}
		}
	}

	public virtual void EHFIHPJILMG()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = true;
			GBJCGLBHJJP();
		}
	}

	private void HAJKDHHNLBJ()
	{
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(837f);
			}
		}
		DisconnectEvents();
	}

	private void DECPGCPHJIJ()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = false;
			for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	public virtual void OMNIAIJHHKB()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= KGBLKFGHOAF;
			KPBBNENJHPA = false;
			DMBBMHNDGCA();
		}
	}

	private void PKOHNEPFBCA()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(580f);
			}
		}
		DisconnectEvents();
	}

	[SpecialName]
	public float PCNCKDALIKG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-48)).FLOATVALUE;
	}

	private void PLOJGHAEDIF()
	{
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(30f);
			}
		}
		DisconnectEvents();
	}

	private void FJLNANKLBOE()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(112f);
			}
		}
		DisconnectEvents();
	}

	[SpecialName]
	public virtual string DJDLDNNHFNG()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[8];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(GNCDFDFKHBO, "shotSniper");
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(criticalChance);
		return Localization.LocalizeFormat(keyFormat, array);
	}

	private void HACPCPLJIMD(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1412f);
			}
		}
	}

	private void HHLCKGJKFON(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += DFCHKAIAAPN;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1599f);
			}
		}
	}

	protected void MNFDMKFLAKO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 155f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			GGDEOAAAAOK();
			BGPDGFAFACP();
			NNDMKIACBBM = true;
		}
	}

	protected void BBCOBMGHMGE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1448f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			BHFGLHDBFNN();
			NGFHKIHKKMC();
			NNDMKIACBBM = true;
		}
	}

	[SpecialName]
	public virtual string PKCAJCNLEMO()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(BGMDNNDEKOB(), "getDaysSinceLastPlayed"), MEJMLNDFDBP.JJBMMICPIIG(HDMIECLBFNH()), null, null, null, null, null);
	}

	private void DFCHKAIAAPN(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1018f);
			}
		}
	}

	private void BGPDGFAFACP()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = true;
			for (int i = 0; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BHABHIDDBLH = GNCDFDFKHBO;
			NNDMKIACBBM = true;
			JMILIKCAALO(CIOPAKLHFIL);
		}
	}

	private void IMEJLNKGJJG(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(407f);
			}
		}
	}

	protected void CBOIHLDFKPI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 586f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			JIMGAACEJGM();
			DECPGCPHJIJ();
			NNDMKIACBBM = true;
		}
	}

	private void NGFHKIHKKMC()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = false;
			for (int i = 0; i < MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1.5f);
			}
		}
	}

	private void GGDEOAAAAOK()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(1300f);
			}
		}
		DisconnectEvents();
	}

	private void GJENHCLPFKK(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += KGBLKFGHOAF;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(703f);
			}
		}
	}

	[SpecialName]
	public float PHCDIJKJCMO()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-128)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string LPFFKPBFLIP()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[5];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(GNCDFDFKHBO, "gold");
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(GADKELBDFIM());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	protected void CKFENMDKKPE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1046f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			GGDEOAAAAOK();
			GBJCGLBHJJP();
			NNDMKIACBBM = true;
		}
	}

	public virtual void IMOIGILONEG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BHABHIDDBLH = GNCDFDFKHBO;
			NNDMKIACBBM = true;
			HHLCKGJKFON(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public virtual string NLMOCCLIEDD()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[2];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(GNCDFDFKHBO, "ID_WARNING_CLICKOKTORESEND");
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(criticalChance);
		return Localization.LocalizeFormat(keyFormat, array);
	}

	private void JHEFOBLJFJE()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(1796f);
			}
		}
		DisconnectEvents();
	}

	private void LOLOPFIFFIG(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += DFCHKAIAAPN;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1655f);
			}
		}
	}

	private void CNKHNGOGPMH(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(240f);
			}
		}
	}

	public virtual void GBFGPFAFPKH()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= CNKHNGOGPMH;
			KPBBNENJHPA = false;
			NGFHKIHKKMC();
		}
	}

	[SpecialName]
	public float HDMIECLBFNH()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)67).FLOATVALUE;
	}

	public virtual void HIFLEFPLMPG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BHABHIDDBLH = BGMDNNDEKOB();
			NNDMKIACBBM = true;
			HHLCKGJKFON(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public virtual string IOLLOCGDADC()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[7];
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(GNCDFDFKHBO, "Squad");
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(DOLGFBOFMIL());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	private void GLLJDGBDDCM()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = false;
			for (int i = 0; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	protected void EMFLLHFPOOB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1052f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			BHFGLHDBFNN();
			DECPGCPHJIJ();
			NNDMKIACBBM = true;
		}
	}

	[SpecialName]
	public float LGKDMAAELFM()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-30)).FLOATVALUE;
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
			DECPGCPHJIJ();
			NNDMKIACBBM = false;
		}
	}

	private void LAMAFHPPPKL()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = false;
			for (int i = 0; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i++)
			{
				MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	public virtual void FEBOADMCFJL()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= KGBLKFGHOAF;
			KPBBNENJHPA = false;
			DMBBMHNDGCA();
		}
	}

	public virtual void BPDAJHJNCLG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BHABHIDDBLH = GNCDFDFKHBO;
			NNDMKIACBBM = false;
			EKFLJOBLIID(CIOPAKLHFIL);
		}
	}

	public virtual void HBIKAAPKFON()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = true;
			JIJLDDEJAFF();
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			BHABHIDDBLH = GNCDFDFKHBO;
			NNDMKIACBBM = true;
			JMILIKCAALO(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		CIADCEEGLAH = true;
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = criticalChance;
		}
	}

	private void GBJCGLBHJJP()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = false;
			for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	private void NHHNJAMPCAC()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = true;
			for (int i = 0; i < MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	[SpecialName]
	private float BGMDNNDEKOB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-27)).FLOATVALUE;
	}

	public virtual void BPFGINOCHLH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BHABHIDDBLH = GNCDFDFKHBO;
			NNDMKIACBBM = true;
			LOLOPFIFFIG(CIOPAKLHFIL);
		}
	}

	private void MGHBMMJDKMK()
	{
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(431f);
			}
		}
		DisconnectEvents();
	}

	private void PDEGGBMFLII()
	{
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO)
			{
				enemyController.UpdateHeadScale(1f);
			}
		}
		DisconnectEvents();
	}

	public virtual void MLEBPBFEOKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			BHABHIDDBLH = GNCDFDFKHBO;
			NNDMKIACBBM = true;
			FDHAJGMKCAO(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		CIADCEEGLAH = true;
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.BEIIOAIJMFK().LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA = KCBNEKGNCNG();
		}
	}

	private void AJFAIDKMDCI(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += DJEKOFEBDIA;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1351f);
			}
		}
	}

	private void DJEKOFEBDIA(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction != GHPGNELIDBM.None && KLHPCPKJGOC.fraction == DMLJBALELCO)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(746f);
			}
		}
	}

	public virtual void PCLKGDCKEKO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BHABHIDDBLH = BGMDNNDEKOB();
			NNDMKIACBBM = false;
			JMILIKCAALO(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public float KCBNEKGNCNG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.RepPointsSilverCard).FLOATVALUE;
	}

	private void JMILIKCAALO(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1.5f);
			}
		}
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = false;
			DECPGCPHJIJ();
		}
	}

	public virtual void FEJKPDNPNOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			BHABHIDDBLH = BGMDNNDEKOB();
			NNDMKIACBBM = true;
			EKFLJOBLIID(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		CIADCEEGLAH = false;
		CMDFFAJOAPE.Clear();
		for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i++)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].weapon.ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = criticalChance;
		}
	}

	private void EKFLJOBLIID(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += IMEJLNKGJJG;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1455f);
			}
		}
	}

	public virtual void JPCAPPEPBHC()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IMEJLNKGJJG;
			KPBBNENJHPA = false;
			DMBBMHNDGCA();
		}
	}

	protected void NBFMDCFFBIJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1546f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			PKOHNEPFBCA();
			LAMAFHPPPKL();
			NNDMKIACBBM = false;
		}
	}

	public virtual void MHKIELKLIHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			BHABHIDDBLH = BGMDNNDEKOB();
			NNDMKIACBBM = true;
			LOLOPFIFFIG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		CIADCEEGLAH = true;
		CMDFFAJOAPE.Clear();
		for (int i = 0; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			CMDFFAJOAPE.Add(MBIAKMPDOPG.FMKGGADDHJK().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA);
			MBIAKMPDOPG.weaponInventory.LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = GADKELBDFIM();
		}
	}

	[SpecialName]
	public float GADKELBDFIM()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SwiftImmortalityTime).FLOATVALUE;
	}

	public virtual void KLEPKFBJIBA()
	{
		base.DisconnectEvents();
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DFCHKAIAAPN;
			KPBBNENJHPA = true;
			DMBBMHNDGCA();
		}
	}

	private void GDIBIDCDBGD()
	{
		if (CIADCEEGLAH)
		{
			CIADCEEGLAH = true;
			for (int i = 1; i < MBIAKMPDOPG.weaponInventory.LAGONJMBJMM.Count; i += 0)
			{
				MBIAKMPDOPG.JLMDEMFIHCA().LAGONJMBJMM[i].HFNAMMBPJAJ().ammoSetup.NFKPBDGGDEA = CMDFFAJOAPE[i];
			}
		}
	}

	private void FDHAJGMKCAO(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			AIObject.AfterSpawned += DJEKOFEBDIA;
			KPBBNENJHPA = true;
		}
		OLHENPNIINE = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		DMLJBALELCO = OLHENPNIINE.fraction;
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction == DMLJBALELCO && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(770f);
			}
		}
	}
}
