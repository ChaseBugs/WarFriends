using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardHealthForSoldiers : Card
{
	private NetworkObjectPool IHFILHIAGLG;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool KPBBNENJHPA;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private const string EJLCMBEKFFN = "game-card-ico-supersoldiers";

	public float multiplierMaxHealth => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SuperSoldiersCoef).FLOATVALUE;

	public float timeInSec => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SuperSoldiersTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(multiplierMaxHealth), MEJMLNDFDBP.AIPKMDCJCOG(timeInSec));

	protected override string mBonusName => MEJMLNDFDBP.KEPEILBMDMD(multiplierMaxHealth);

	[SpecialName]
	public float BIEICDNMOID()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)92).FLOATVALUE;
	}

	[SpecialName]
	public virtual string FJDNJDGBIBA()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[6];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(LHNJMNECKAL());
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(timeInSec, "ID_TUTORIAL_PROGRESS_KILLING2");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void JMOEJDAJMOH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HIJFBPNHHPI(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void MBPPLOKEJJL(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = timeInSec;
			NNDMKIACBBM = true;
			ODCLPMADGFC = CIOPAKLHFIL;
			MCBFDIEALNM(ODCLPMADGFC);
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = false;
		}
	}

	private void IHKPEBIILCB(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= IMNGBPKGONM() + 1744f;
				enemyController.OJIHGNJFPFM.APJEBOPJPLA();
				enemyController.cardIconIndicator.JEDGCOMDEKM("squadMembers", BHABHIDDBLH, timeInSec, GBJOJBKCEKN: true);
			}
		}
	}

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= multiplierMaxHealth + 1f;
				enemyController.OJIHGNJFPFM.Refill();
				enemyController.cardIconIndicator.Show("game-card-ico-supersoldiers", BHABHIDDBLH, timeInSec, GBJOJBKCEKN: true);
			}
		}
	}

	[SpecialName]
	protected virtual string GCABFJJDENG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(multiplierMaxHealth);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HIJFBPNHHPI(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string NMMJABOJHND()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(IMNGBPKGONM()), MEJMLNDFDBP.AIPKMDCJCOG(timeInSec, "ServerResponseHandler.ServerRequestFinished databaseAction: "), null, null);
	}

	public virtual bool APJIPKCJKLF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count < 8)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public float NONJKHLLNJI()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)127).FLOATVALUE;
	}

	private void MCBFDIEALNM(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 953f && enemyController.canBeFreezed)
				{
					float nEJNIEEHCKJ = enemyController.OJIHGNJFPFM.maxHealth * KBCIDFHCOKN();
					enemyController.OJIHGNJFPFM.maxHealth *= BIEICDNMOID() + 197f;
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.FFMLINMFADM("JoinMatch_ServerConnect", BHABHIDDBLH, timeInSec, GBJOJBKCEKN: true);
				}
			}
		}
	}

	public virtual void DMILKJIGIND(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HIJFBPNHHPI(CIOPAKLHFIL);
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

	[SpecialName]
	public float JKGNCOGIDLK()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-35)).FLOATVALUE;
	}

	public virtual void CPALNIACCKB()
	{
		if (!KPBBNENJHPA)
		{
			return;
		}
		AIObject.AfterSpawned -= IHKPEBIILCB;
		KPBBNENJHPA = true;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (!item.PLPBGNOCCPI())
			{
				continue;
			}
			EnemyController enemyController = (EnemyController)item;
			if (enemyController.fraction == ODCLPMADGFC && enemyController.OJIHGNJFPFM.health != 1222f)
			{
				enemyController.OJIHGNJFPFM.maxHealth /= ALKMPOLBOEG() + 873f;
				if (enemyController.OJIHGNJFPFM.health > enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(630f, CAKABHIPCDF: true);
				}
				enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
			}
		}
	}

	[SpecialName]
	public float LHNJMNECKAL()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)90).FLOATVALUE;
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HIJFBPNHHPI(CIOPAKLHFIL);
		}
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBPPLOKEJJL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string PMCFLDDLNAD()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[7];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(BIEICDNMOID());
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(timeInSec, "ID_UNLOCKEDATRANK");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void AKGODDNOGNO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBPPLOKEJJL(CIOPAKLHFIL);
		}
	}

	public override void DisconnectEvents()
	{
		if (!KPBBNENJHPA)
		{
			return;
		}
		AIObject.AfterSpawned -= NMBIPNICPOO;
		KPBBNENJHPA = false;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (!item.isInstantiated)
			{
				continue;
			}
			EnemyController enemyController = (EnemyController)item;
			if (enemyController.fraction == ODCLPMADGFC && enemyController.OJIHGNJFPFM.health != 0f)
			{
				enemyController.OJIHGNJFPFM.maxHealth /= multiplierMaxHealth + 1f;
				if (enemyController.OJIHGNJFPFM.health > enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.Heal(0f, CAKABHIPCDF: false);
				}
				enemyController.OJIHGNJFPFM.Sync();
			}
		}
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
			DisconnectEvents();
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
		}
	}

	[SpecialName]
	public float FHKGHEDFKAO()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-78)).FLOATVALUE;
	}

	private void HIJFBPNHHPI(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!KPBBNENJHPA)
		{
			BHABHIDDBLH = timeInSec;
			NNDMKIACBBM = true;
			ODCLPMADGFC = CIOPAKLHFIL;
			EKNOPMILPCC(ODCLPMADGFC);
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	[SpecialName]
	protected virtual string EBMFKIKGHGI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ALKMPOLBOEG());
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBPPLOKEJJL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void KNIAAECLFFK()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 451f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				return;
			}
			DisconnectEvents();
			BHABHIDDBLH = 1379f;
			NNDMKIACBBM = false;
		}
	}

	public virtual void CKLOEEJCAOH()
	{
		if (!KPBBNENJHPA)
		{
			return;
		}
		AIObject.AfterSpawned -= JFIBFJMHNBP;
		KPBBNENJHPA = false;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (!item.PLPBGNOCCPI())
			{
				continue;
			}
			EnemyController enemyController = (EnemyController)item;
			if (enemyController.fraction == ODCLPMADGFC && enemyController.OJIHGNJFPFM.health != 1587f)
			{
				enemyController.OJIHGNJFPFM.maxHealth /= ALKMPOLBOEG() + 1024f;
				if (enemyController.OJIHGNJFPFM.health > enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(412f, CAKABHIPCDF: false);
				}
				enemyController.OJIHGNJFPFM.Sync();
			}
		}
	}

	public virtual void HHKFLIABFCA()
	{
		if (!KPBBNENJHPA)
		{
			return;
		}
		AIObject.AfterSpawned -= JFIBFJMHNBP;
		KPBBNENJHPA = true;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (!item.JHJJKEBNGEN())
			{
				continue;
			}
			EnemyController enemyController = (EnemyController)item;
			if (enemyController.fraction == ODCLPMADGFC && enemyController.OJIHGNJFPFM.health != 554f)
			{
				enemyController.OJIHGNJFPFM.maxHealth /= FHKGHEDFKAO() + 10f;
				if (enemyController.OJIHGNJFPFM.health > enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(1230f, CAKABHIPCDF: true);
				}
				enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
			}
		}
	}

	[SpecialName]
	protected virtual string MIEFNCLBKEG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(multiplierMaxHealth);
	}

	[SpecialName]
	public float ALKMPOLBOEG()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)57).FLOATVALUE;
	}

	public virtual void OAJHAPCNJML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBPPLOKEJJL(CIOPAKLHFIL);
		}
	}

	private void EKNOPMILPCC(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health > 0f && enemyController.canBeFreezed)
				{
					float nEJNIEEHCKJ = enemyController.OJIHGNJFPFM.maxHealth * multiplierMaxHealth;
					enemyController.OJIHGNJFPFM.maxHealth *= multiplierMaxHealth + 1f;
					enemyController.OJIHGNJFPFM.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.Show("game-card-ico-supersoldiers", BHABHIDDBLH, timeInSec, GBJOJBKCEKN: true);
				}
			}
		}
	}

	[SpecialName]
	public float IMNGBPKGONM()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE;
	}

	public virtual void OCODHIGNMID()
	{
		if (!KPBBNENJHPA)
		{
			return;
		}
		AIObject.AfterSpawned -= JFIBFJMHNBP;
		KPBBNENJHPA = true;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (!item.JHJJKEBNGEN())
			{
				continue;
			}
			EnemyController enemyController = (EnemyController)item;
			if (enemyController.fraction == ODCLPMADGFC && enemyController.OJIHGNJFPFM.health != 461f)
			{
				enemyController.OJIHGNJFPFM.maxHealth /= LHNJMNECKAL() + 176f;
				if (enemyController.OJIHGNJFPFM.health > enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(1539f, CAKABHIPCDF: true);
				}
				enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
			}
		}
	}

	[SpecialName]
	public float KBCIDFHCOKN()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-80)).FLOATVALUE;
	}

	public virtual bool BDCJAMFLAMO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count < 6)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void JFIBFJMHNBP(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.OJIHGNJFPFM.maxHealth *= KBCIDFHCOKN() + 1200f;
				enemyController.OJIHGNJFPFM.OEAGCMGINCB();
				enemyController.cardIconIndicator.LOFMDBHAFAO("C0", BHABHIDDBLH, timeInSec, GBJOJBKCEKN: true);
			}
		}
	}

	public virtual void CCODFGNHBOJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HIJFBPNHHPI(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool AHCCCGNDDNI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (EAOABLKHNKG.Count < 5)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
