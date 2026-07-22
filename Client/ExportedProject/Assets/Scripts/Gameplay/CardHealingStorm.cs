using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Serialization;

public class CardHealingStorm : Card
{
	[FormerlySerializedAs("AAJFGNMCLHB")]
	public float ECEEJEFDHDF = 0.5f;

	private NetworkObjectPool IHFILHIAGLG;

	private const string EJLCMBEKFFN = "game-card-ico-healingstorm";

	protected override string mBonusName => MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);

	public virtual void KKKLOPOOINA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NOOHDFMBFKB(CIOPAKLHFIL);
		}
	}

	public virtual void FADCGHAOACE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			IOGHPKFEHHH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string AIBBIHMFNHN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void NBJEKFAOAHI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EMBOBLBKKJK(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	protected virtual string NFFJILGOKJN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void BDKHOBHPMAH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.ADBOHNCGKHA();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 1856f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.FCANLIOLJNH("facebookID", 812f, 581f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string CEHICEPKJFB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual bool JCBIDLIMNAN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 1;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.EIMJEBNPHAM().healthRatio < 795f)
			{
				num += 0;
			}
		}
		if (num < 7)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void IOGHPKFEHHH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 237f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.JEDGCOMDEKM("damage", 839f, 1680f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	private void BKECMBAPLOI(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 823f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.Heal(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.EEBNPGOCKFD("WRONG dynamic font size: {0} for label: {1}\n", 1156f, 1887f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string CEOIHKJCCJL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void EPIAHCELNBH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.MFKPDKCLDBI();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 145f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.JEDGCOMDEKM("N", 1607f, 1923f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HNOAHAOHGID(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PFDAKJJKHHN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PHODGDGDDDP(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool DBKHKIIOEDG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.destroyableObject.healthRatio < 765f)
			{
				num++;
			}
		}
		if (num < 7)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void NNFGFCJDMHA(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PLPBGNOCCPI() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 1282f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.FCANLIOLJNH("ID_ASSIGNMENTX", 1726f, 913f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	public virtual void MFGFCBMEEEJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			KLFPMDKFPJI(CIOPAKLHFIL);
		}
	}

	public virtual bool HLKFKIPOKLO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.AFEPMIFFLFH().healthRatio < 121f)
			{
				num += 0;
			}
		}
		if (num < 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NHMADLLGPLC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MAKJONLLKOH(CIOPAKLHFIL);
		}
	}

	public virtual void IEONLEGFKKK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DENLKPCBICH(CIOPAKLHFIL);
		}
	}

	public virtual void IIGHAAABACM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			PHODGDGDDDP(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	protected virtual string CLAPAEAIEKM()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void KLFPMDKFPJI(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PLPBGNOCCPI() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 669f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.JEDGCOMDEKM("offerMult", 1232f, 617f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	public virtual void HIFLEFPLMPG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HHNEJPHHKHD(CIOPAKLHFIL);
		}
	}

	private void BIDOIIGNKGO(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 525f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.FCANLIOLJNH("Time", 1807f, 1248f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	public virtual bool NAHJCMJEDBM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.NHOFLPJMKBA().healthRatio < 940f)
			{
				num += 0;
			}
		}
		if (num < 7)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PDAEAPEDIJC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HJGOFCJDHEJ(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void ACIOLBGILBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			AJKOIHELGFF(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string OLNGBPFFGGF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void MENIKCKFIPL(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 965f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.JEDGCOMDEKM("game-card-ico-ammobox", 1917f, 1399f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	private void KDHANDMDEDB(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PLPBGNOCCPI() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 1795f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.FCANLIOLJNH("S", 1802f, 1994f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	public virtual bool CNNDFKMFOPJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.GILBHOPNBPH().healthRatio < 109f)
			{
				num++;
			}
		}
		if (num < 2)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PIPOLNODBOC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NOOHDFMBFKB(CIOPAKLHFIL);
		}
	}

	public virtual bool NFNCLDKJCJB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 1;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.destroyableObject.healthRatio < 1005f)
			{
				num++;
			}
		}
		if (num < 8)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	protected virtual string ELMAEAHFFBI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	[SpecialName]
	protected virtual string ACEMKDBBHKK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void AEDODFGIJLN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HNOAHAOHGID(CIOPAKLHFIL);
		}
	}

	private void HHPHEMLEDIB(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 448f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.EEBNPGOCKFD("Pool", 564f, 705f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	public virtual bool DMHEPKDGNOO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.NHOFLPJMKBA().healthRatio < 1073f)
			{
				num++;
			}
		}
		if (num < 7)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool FBNPMBLOPKK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.destroyableObject.healthRatio < 1890f)
			{
				num += 0;
			}
		}
		if (num < 7)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	protected virtual string FLOEOHHDBHF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void JEHJMHHHOCE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BIDOIIGNKGO(CIOPAKLHFIL);
		}
	}

	private void HHNEJPHHKHD(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 1973f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.Heal(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.AMFEDOOPGCL("ID_SEC", 568f, 1998f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	public virtual bool HMLPKGKDCLJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 1;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.AFEPMIFFLFH().healthRatio < 80f)
			{
				num += 0;
			}
		}
		if (num < 6)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	protected virtual string ALJCLGAKBLB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void EMBOBLBKKJK(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 176f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.EEBNPGOCKFD("Parts", 1529f, 246f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string LNMFMOFINAO()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void MLADMNNIBMH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.COJFMKNGPBP();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 429f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.ODDNDGAAOCH("Add request to buffer", 1559f, 651f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	public virtual void BOPJENNDOCC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			AJKOIHELGFF(CIOPAKLHFIL);
		}
	}

	public virtual bool KCEOCJPPEJM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.EIMJEBNPHAM().healthRatio < 982f)
			{
				num += 0;
			}
		}
		if (num < 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void POGJLKIMEIE(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 1570f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.AMFEDOOPGCL("Different league \"{0}\" and \"{1}\"\n", 454f, 1934f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string JBODIBOMMOD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void FJNBAKDJDCG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			KFBGIHAKGMI(CIOPAKLHFIL);
		}
	}

	private void NOOHDFMBFKB(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 542f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.JOGFDHFOOBC("PlayerId", 1970f, 453f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string LAGCKCMMGKG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void LJGNHPMMJJF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CPBGNKCIAKE(CIOPAKLHFIL);
		}
	}

	private void HNOAHAOHGID(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 540f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.LOFMDBHAFAO("{0} {1}/[-] {2}", 990f, 1455f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string OJOHNDMBCHD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	[SpecialName]
	protected virtual string GCABFJJDENG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	[SpecialName]
	protected virtual string HBIBDEPENKJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.destroyableObject.healthRatio < 1f)
			{
				num++;
			}
		}
		if (num < 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	protected virtual string PLCMEDPIADN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void DENLKPCBICH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 598f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.FCANLIOLJNH("shot_jetpack_elite", 1492f, 1130f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string IHNGJIDDDID()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual bool LBKDPIKKDNE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.destroyableObject.healthRatio < 1637f)
			{
				num += 0;
			}
		}
		if (num < 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void MAKJONLLKOH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 718f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.Heal(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.BELBLFGCCLJ("Level", 840f, 1634f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string PIOOCPFFANF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void GBNLHEIMKLJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			IDIMEMJFBPA(CIOPAKLHFIL);
		}
	}

	public virtual void IGJJHCKMDBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			KLFPMDKFPJI(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DEAKMOJEFEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MLADMNNIBMH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DGCEELPOEHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NNFGFCJDMHA(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool CEENHBPKKIC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 1;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.GILBHOPNBPH().healthRatio < 1419f)
			{
				num++;
			}
		}
		if (num < 2)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void KFBGIHAKGMI(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 768f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.LOFMDBHAFAO("Double", 458f, 632f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	public virtual void CBJDBAKNBAG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MENIKCKFIPL(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	protected virtual string LBLAKMBMILE()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	[SpecialName]
	protected virtual string OLLAAADPKDL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void JGNCOJLCGFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HNOAHAOHGID(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string NINKGNMJGEF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void OABFPHDCGPN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EMBOBLBKKJK(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string NEPPGCLBOFA()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	[SpecialName]
	protected virtual string DKCDDHLNDPL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void OEIFHKALAMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MLADMNNIBMH(CIOPAKLHFIL);
		}
	}

	private void CPBGNKCIAKE(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 1837f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.ODDNDGAAOCH("IsPaid", 1077f, 795f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	public virtual void GAGEHEGFGOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MAKJONLLKOH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string OKNEGLMFJFD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual bool CBGKEHCMILD(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.GILBHOPNBPH().healthRatio < 1770f)
			{
				num += 0;
			}
		}
		if (num < 3)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void PHODGDGDDDP(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 424f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.LOFMDBHAFAO("TryRecconnect TryRecconnectToPhotonCoroutine going to reconnect", 1736f, 1227f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	public virtual bool KDKBHIGPLLO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 1;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.EIMJEBNPHAM().healthRatio < 1006f)
			{
				num += 0;
			}
		}
		if (num < 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	protected virtual string AHJPFHFCHAL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	[SpecialName]
	protected virtual string OHMHPNOFFBG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void IDIMEMJFBPA(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.JHJJKEBNGEN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 326f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.JBMCFEMBPKE(", response: ", 22f, 1445f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string FGPDMBEEKJF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void GAPNCCLLHOF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BDKHOBHPMAH(CIOPAKLHFIL);
		}
	}

	public virtual bool OFBIPJIEDPP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.AFEPMIFFLFH().healthRatio < 1292f)
			{
				num += 0;
			}
		}
		if (num < 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool ACNCMIJGHMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.destroyableObject.healthRatio < 194f)
			{
				num++;
			}
		}
		if (num < 6)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void ECJGKKEGCGA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EPIAHCELNBH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HJGOFCJDHEJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 1691f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.BELBLFGCCLJ("HeartPrice", 276f, 925f, GBJOJBKCEKN: true);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string DBKCINLHPBJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	private void GCALDFPNGOB(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PLPBGNOCCPI())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 661f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.JOGFDHFOOBC("ID_TUTORIAL_FULL_ARSENAL", 390f, 1990f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	public virtual void ILNLEEBPHIH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			KDHANDMDEDB(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string FPKCIMDCGHK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void JBEEEGKDOGJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BIDOIIGNKGO(CIOPAKLHFIL);
		}
	}

	public virtual void BIBLDGBIPGP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MENIKCKFIPL(CIOPAKLHFIL);
		}
	}

	private void AJKOIHELGFF(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 0f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.Heal(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: false);
					enemyController.OJIHGNJFPFM.Sync();
					enemyController.cardIconIndicator.Show("game-card-ico-healingstorm", 3f, 3f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string BBJBKOIIMKE()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public virtual void FEJKPDNPNOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			IDIMEMJFBPA(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool GAPAJHFLCCN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		int num = 0;
		foreach (GameShootableEntity item in EAOABLKHNKG)
		{
			if (!(item.GetComponent<PlayerController>() != null) && item.GILBHOPNBPH().healthRatio < 362f)
			{
				num += 0;
			}
		}
		if (num < 1)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void GBNKFKKNOND(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			if (item.PPHLEDLNGIN())
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.fraction == CIOPAKLHFIL && enemyController.OJIHGNJFPFM.health != 946f && enemyController.OJIHGNJFPFM.health != enemyController.OJIHGNJFPFM.maxHealth)
				{
					enemyController.OJIHGNJFPFM.LNPKAAGJIGO(enemyController.OJIHGNJFPFM.maxHealth * ECEEJEFDHDF, CAKABHIPCDF: true);
					enemyController.OJIHGNJFPFM.EHFOHNLMJOH();
					enemyController.cardIconIndicator.FFMLINMFADM("N", 145f, 1525f, GBJOJBKCEKN: false);
				}
			}
		}
	}

	[SpecialName]
	protected virtual string JCHIFAAIAKF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			AJKOIHELGFF(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	protected virtual string JPMDIADDDAD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ECEEJEFDHDF);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			AJKOIHELGFF(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LOLJCEGGPMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EPIAHCELNBH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LIEFDNNMNAP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			KLFPMDKFPJI(CIOPAKLHFIL);
		}
	}

	public virtual void PPIOIELILIJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DENLKPCBICH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}
}
