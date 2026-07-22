using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardCantDieJustNow : Card
{
	[FormerlySerializedAs("AMFPLNAPLND")]
	public float CDMKEBONMKG = 10f;

	private NetworkObjectPool IHFILHIAGLG;

	private bool NNDMKIACBBM;

	private float BHABHIDDBLH;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool KPBBNENJHPA;

	private List<EnemyController> NJHHNHMELHK = new List<EnemyController>();

	private void BGCOCKPNJLG(GHPGNELIDBM CIOPAKLHFIL)
	{
		ONMDPLIACPF(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += PNMHLEAEGPF;
			KPBBNENJHPA = true;
		}
	}

	public virtual void GDEHLDBGNHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BGCOCKPNJLG(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LEJJDMBMPKO()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= FNILEHIHAEE;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void APIDBEOGDIJ()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DKACBNCLCJI;
			KPBBNENJHPA = false;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	private void FAPKLAPHGAA()
	{
		DisconnectEvents();
		BHABHIDDBLH = 1293f;
		NNDMKIACBBM = true;
	}

	public virtual void OFKFFAHMEDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			OMJMODMJHNE(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void HEOOBBBLKJO(GHPGNELIDBM CIOPAKLHFIL)
	{
		PMCBAPPBFBN(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += JNONKHOLLKF;
			KPBBNENJHPA = false;
		}
	}

	private void NLGDOHDIJCO(GHPGNELIDBM CIOPAKLHFIL)
	{
		ONMDPLIACPF(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += ONAPNNGOGED;
			KPBBNENJHPA = true;
		}
	}

	private void DFCHKAIAAPN(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void CCBIKOCGMLG()
	{
		DisconnectEvents();
		BHABHIDDBLH = 912f;
		NNDMKIACBBM = false;
	}

	public virtual void LJMBCGFCBKL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HEOOBBBLKJO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	public virtual void JIOHEKONMMN()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= AAFIBMAILCH;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void ECJGKKEGCGA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NNGEEBEOMAA(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HBCDIGFODGP(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void ANGGDLPGCMD(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void BMCMJNDOCEC()
	{
		DisconnectEvents();
		BHABHIDDBLH = 787f;
		NNDMKIACBBM = false;
	}

	private void JNONKHOLLKF(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void MLDGNMHNMCB()
	{
		DisconnectEvents();
		BHABHIDDBLH = 203f;
		NNDMKIACBBM = false;
	}

	private void DCLIPNDLEAG(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void CBFLAMOFABB(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.COJFMKNGPBP();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void OEIFHKALAMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FFLMGLBOIHF(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	private void PMCBAPPBFBN(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void AOFKIMNKMKN()
	{
		DisconnectEvents();
		BHABHIDDBLH = 774f;
		NNDMKIACBBM = false;
	}

	private void OCODCCGLMMB()
	{
		DisconnectEvents();
		BHABHIDDBLH = 375f;
		NNDMKIACBBM = true;
	}

	protected void HAMDMFGNIKD()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1798f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				BMCMJNDOCEC();
			}
		}
	}

	private void EMNIEIHNCIA(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KJEANKAJELG();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void IBGLCMGDEDM(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.CHHLLIAHECC();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void GGDCNLJCBMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NLGDOHDIJCO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	public virtual void GBNLHEIMKLJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NLGDOHDIJCO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	public virtual void OGIJCLOAKGK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NLGDOHDIJCO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	public virtual void DODDKKBAPFK()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IAMNGHMHFPF;
			KPBBNENJHPA = false;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void HEBJPOCEMIL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			LLIHPOMDOCO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	private void KBMNBDMAINC()
	{
		DisconnectEvents();
		BHABHIDDBLH = 978f;
		NNDMKIACBBM = false;
	}

	private void NNGEEBEOMAA(GHPGNELIDBM CIOPAKLHFIL)
	{
		ONMDPLIACPF(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += DKACBNCLCJI;
			KPBBNENJHPA = true;
		}
	}

	public virtual void BECBKICGOKB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DMCMKKGCFGP;
			KPBBNENJHPA = false;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	private void DGKLMDGDLDF(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.COJFMKNGPBP();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void CPDECMKHKGD()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= PNMHLEAEGPF;
			KPBBNENJHPA = false;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	private void NBDIBEMLHHO()
	{
		DisconnectEvents();
		BHABHIDDBLH = 1490f;
		NNDMKIACBBM = true;
	}

	public virtual void IDAFLCICMKD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NNGEEBEOMAA(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void MNJPIOEHBEM()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1116f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				HELBPEANABN();
			}
		}
	}

	public virtual void CNPPBAKNJFO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HDDBCJFILNK(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void HDDBCJFILNK(GHPGNELIDBM CIOPAKLHFIL)
	{
		DGKLMDGDLDF(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += OFDMLCEEJAF;
			KPBBNENJHPA = false;
		}
	}

	public override void DisconnectEvents()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= NMBIPNICPOO;
			KPBBNENJHPA = false;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	private void GGDEOAAAAOK()
	{
		DisconnectEvents();
		BHABHIDDBLH = 610f;
		NNDMKIACBBM = false;
	}

	public virtual void PEGJJBMLEML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			OMJMODMJHNE(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void OBNPMMDGFME(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			OMJMODMJHNE(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void ONMDPLIACPF(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.GLHPLCEFHGD();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void HBLPPLHGCJH()
	{
		DisconnectEvents();
		BHABHIDDBLH = 1732f;
		NNDMKIACBBM = false;
	}

	public virtual void HGCCDEBNHED(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CFLFCCJGCLJ(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HELBPEANABN()
	{
		DisconnectEvents();
		BHABHIDDBLH = 767f;
		NNDMKIACBBM = false;
	}

	private void BDCKCBFJNOA()
	{
		DisconnectEvents();
		BHABHIDDBLH = 548f;
		NNDMKIACBBM = true;
	}

	private void MNJFFOPCEJH(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void KFHAGFLJLOG(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void FADCIJMMNNA()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= KFHAGFLJLOG;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	protected void LNHOPPAFMPH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 243f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				HBLPPLHGCJH();
			}
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			OMJMODMJHNE(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BIBLDGBIPGP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BGCOCKPNJLG(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void CFLFCCJGCLJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		EMNIEIHNCIA(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += AOBNAGMABME;
			KPBBNENJHPA = false;
		}
	}

	public virtual void LACMNIFBEBL()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= KAPGNNMBFKI;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void CHJKKHIOOIH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NNGEEBEOMAA(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void CIHJAAFHLIM()
	{
		DisconnectEvents();
		BHABHIDDBLH = 1984f;
		NNDMKIACBBM = true;
	}

	public virtual void GHAOLPJPNLD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CFLFCCJGCLJ(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				PDEGGBMFLII();
			}
		}
	}

	private void GAMMONLLKFA(GHPGNELIDBM CIOPAKLHFIL)
	{
		IBGLCMGDEDM(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += EHDCLHPLIHJ;
			KPBBNENJHPA = true;
		}
	}

	private void EAONGBEPMEG(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	protected void IODGCIIDJEK()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1532f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				FAPKLAPHGAA();
			}
		}
	}

	public virtual void EBAOBEANINE()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= AOBNAGMABME;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void DBOIGEABADE()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= AOBNAGMABME;
			KPBBNENJHPA = false;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	private void CMLACCOMGMG(GHPGNELIDBM CIOPAKLHFIL)
	{
		MNJFFOPCEJH(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += FNILEHIHAEE;
			KPBBNENJHPA = false;
		}
	}

	private void DKACBNCLCJI(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
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
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void KBAAGMDFMMM(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void DKOMGEKACEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BGCOCKPNJLG(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void NAJHDPPPHBG(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void BIDGKKBHCBA()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= AOBNAGMABME;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void JKDJAMBENPH()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= ANGGDLPGCMD;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void PFLGKCELNOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CMLACCOMGMG(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void MLOJPAEBLBL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			OMJMODMJHNE(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void AEJBIPHAKFI(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.DKNHCGGKNMF();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	protected void BBCOBMGHMGE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 826f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				AOFKIMNKMKN();
			}
		}
	}

	private void PNMHLEAEGPF(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void PIKDELOGJDK()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= PNMHLEAEGPF;
			KPBBNENJHPA = false;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void DLGKHDCPNBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NNGEEBEOMAA(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void KAPGNNMBFKI(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void HPFMMIJJFBJ()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IAMNGHMHFPF;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	private void FCGNBMLDNBO(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.INOJHPIKICM();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void CJOCFGPDMLJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			LLIHPOMDOCO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void HHIJJEDGAJE(GHPGNELIDBM CIOPAKLHFIL)
	{
		PMHBFIKLJLM(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += ONAPNNGOGED;
			KPBBNENJHPA = false;
		}
	}

	private void AAFIBMAILCH(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void INDKIEPALNH()
	{
		DisconnectEvents();
		BHABHIDDBLH = 407f;
		NNDMKIACBBM = true;
	}

	public virtual void JMNNGMOAMEO()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IAMNGHMHFPF;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	protected void FAHGDKLEKMN()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1856f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				BMCMJNDOCEC();
			}
		}
	}

	private void FFLMGLBOIHF(GHPGNELIDBM CIOPAKLHFIL)
	{
		NAJHDPPPHBG(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += OFDMLCEEJAF;
			KPBBNENJHPA = false;
		}
	}

	private void OMJMODMJHNE(GHPGNELIDBM CIOPAKLHFIL)
	{
		KAFBGHMPNNL(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += NMBIPNICPOO;
			KPBBNENJHPA = true;
		}
	}

	public virtual void LIEFDNNMNAP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			AKBLEBCMGEO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	private void MPIABFEGBIM()
	{
		DisconnectEvents();
		BHABHIDDBLH = 886f;
		NNDMKIACBBM = false;
	}

	public virtual void JLPKHOPFEIN()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= IAMNGHMHFPF;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	protected void CJAHPFMAMKK()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 903f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				HELBPEANABN();
			}
		}
	}

	private void PDEGGBMFLII()
	{
		DisconnectEvents();
		BHABHIDDBLH = 0f;
		NNDMKIACBBM = false;
	}

	private void DDGEDBPCOEJ()
	{
		DisconnectEvents();
		BHABHIDDBLH = 826f;
		NNDMKIACBBM = false;
	}

	private void AOBNAGMABME(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void IFHKCJGBDAN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			GAMMONLLKFA(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void ONAPNNGOGED(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void LLIHPOMDOCO(GHPGNELIDBM CIOPAKLHFIL)
	{
		PMHBFIKLJLM(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += IAMNGHMHFPF;
			KPBBNENJHPA = true;
		}
	}

	public virtual void JCFIFGAJKCB()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= DKACBNCLCJI;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = true;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void JPCAPPEPBHC()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= PNMHLEAEGPF;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}

	public virtual void IGJJHCKMDBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HEOOBBBLKJO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LLIHPOMDOCO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DGAOKHJIADO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HEOOBBBLKJO(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void OFDMLCEEJAF(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void IBIBIGINJLB(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.EHFPBDJMGNC();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void IAMNGHMHFPF(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void ECPFFFDACHB(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void CKCMGDAJAAP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NNGEEBEOMAA(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void AGNFCPGCEGF(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> list = IHFILHIAGLG.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void AEDODFGIJLN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FFLMGLBOIHF(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = false;
		}
	}

	private void FNILEHIHAEE(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void KAFBGHMPNNL(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	private void EHDCLHPLIHJ(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			OMJMODMJHNE(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
	}

	private void AKBLEBCMGEO(GHPGNELIDBM CIOPAKLHFIL)
	{
		FCGNBMLDNBO(CIOPAKLHFIL);
		if (!KPBBNENJHPA)
		{
			ODCLPMADGFC = CIOPAKLHFIL;
			AIObject.AfterSpawned += KBAAGMDFMMM;
			KPBBNENJHPA = true;
		}
	}

	protected void OOCJOBIIKAH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1774f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				HBLPPLHGCJH();
			}
		}
	}

	private void LLENLFBBIFG()
	{
		DisconnectEvents();
		BHABHIDDBLH = 174f;
		NNDMKIACBBM = false;
	}

	private void DMCMKKGCFGP(AIObject KLHPCPKJGOC)
	{
		if (KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = true;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	protected void EHLEBOMGCJN()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 480f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				INDKIEPALNH();
			}
		}
	}

	public virtual void MOLBFBJEFIL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			FFLMGLBOIHF(CIOPAKLHFIL);
			BHABHIDDBLH = CDMKEBONMKG;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void GGABIBEFHGM()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1842f)
			{
				BHABHIDDBLH -= Time.deltaTime;
			}
			else
			{
				BDCKCBFJNOA();
			}
		}
	}

	private void PMHBFIKLJLM(GHPGNELIDBM CIOPAKLHFIL)
	{
		IHFILHIAGLG = ObjectPoolDatabase.KKCMCNCCIMB();
		List<PoolableObject> objectsMadeOfPrefab = IHFILHIAGLG.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == CIOPAKLHFIL)
			{
				enemyController.canDie = false;
				NJHHNHMELHK.Add(enemyController);
			}
		}
	}

	public virtual void DHMNAJKOGIM()
	{
		if (KPBBNENJHPA)
		{
			AIObject.AfterSpawned -= ECPFFFDACHB;
			KPBBNENJHPA = true;
		}
		foreach (EnemyController item in NJHHNHMELHK)
		{
			item.canDie = false;
		}
		NJHHNHMELHK.Clear();
	}
}
