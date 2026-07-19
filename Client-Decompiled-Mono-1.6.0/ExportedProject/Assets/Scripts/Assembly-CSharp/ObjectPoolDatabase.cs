using System.Runtime.CompilerServices;

public class ObjectPoolDatabase : Singleton<ObjectPoolDatabase>
{
	public EnemyController KGGJOOAFDIF;

	public Healthbar MCMHGKKPHPO;

	public Healthbar GIMONALHCPI;

	public SkillShotDisplayer NBKAACNKJEM;

	public SkillShotDisplayerItem LLADEBAFJKO;

	public CustomDisplayerItem KCIILAOHOOH;

	public HudObjectIndicator2D JPDFMABBKDI;

	public DamageDisplayer EMONHGIAHLD;

	public NewUnitDisplayerItem HPEONIPEEJJ;

	public Drone ODHKBPHKKMG;

	public AICar OOCEFGMGEPL;

	public AICarBuggy DIHENLLJCLK;

	public AICarTransporter LDAKGDHKIPB;

	public Helicopter HCCENNJFGMA;

	public Tank KBIJLNKODDD;

	public Turret KAEAMDOJMIF;

	public TurretRockets BCHKIMFJFBP;

	public Mech GPGAKDJHFKH;

	public HeavyTurret NOHJIDOIEFD;

	public AssaultHelicopter JFJFEJMJNHN;

	public Decoy MGNCHMDCEGG;

	public MiniDrone NNNDICKBHMN;

	public PlayerController KHLGDCHJJPB;

	public ShootableBox CJDMHNIJHDB;

	public Parachute NGABCDPNGBJ;

	public ObjectPool GHGMIFHAOMI;

	private static ObjectPool DNJGBBNLOPE;

	private static NetworkObjectPool LEGMLHDBKOD;

	private static ObjectPool OMDMKAMCGEC;

	public NoMoveIndikator GFJILBKKDFA;

	public BuddyNameDisplayer JDNMAKKMPOA;

	public BulletSlow MBFIEGEELKG;

	public BulletPoison PPMGFHHDCPF;

	public static ObjectPool ammoPool
	{
		get
		{
			if (DNJGBBNLOPE == null)
			{
				DNJGBBNLOPE = ObjectPool.GetPool("AmmoPool");
			}
			return DNJGBBNLOPE;
		}
		set
		{
			DNJGBBNLOPE = value;
		}
	}

	public static NetworkObjectPool networkPool
	{
		get
		{
			if (LEGMLHDBKOD == null)
			{
				LEGMLHDBKOD = ObjectPool.GetPool("NetworkPool") as NetworkObjectPool;
			}
			return LEGMLHDBKOD;
		}
		set
		{
			LEGMLHDBKOD = value;
		}
	}

	public static ObjectPool mainPool
	{
		get
		{
			return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
		}
	}

	public static ObjectPool guiManagerPool
	{
		get
		{
			if (OMDMKAMCGEC == null)
			{
				OMDMKAMCGEC = ObjectPool.GetPool("GUiManager");
			}
			return OMDMKAMCGEC;
		}
	}

	public static void InstantiatePooledObjects(NPNOIGHIALL DKNEHBEJABC)
	{
		ALJKAAMHHLB.DPDCBOLJKOI("InstantiatePooledObjects " + DKNEHBEJABC);
		ammoPool.InstantiatePooledObjects(DKNEHBEJABC);
		mainPool.InstantiatePooledObjects(DKNEHBEJABC);
		networkPool.InstantiatePooledObjects(DKNEHBEJABC);
		guiManagerPool.InstantiatePooledObjects(DKNEHBEJABC);
		ALJKAAMHHLB.PDICPJLEKBI("InstantiatePooledObjects " + DKNEHBEJABC);
	}

	public static void EOGLFOKEDPF(NPNOIGHIALL DKNEHBEJABC)
	{
		ALJKAAMHHLB.ABLGNNLDNHC("VIP bought" + DKNEHBEJABC);
		FLAHKAIJHBP().GBCKONMLAKH(DKNEHBEJABC);
		BCPEKNNHIIK().NKFOJNFCGME(DKNEHBEJABC);
		ADBOHNCGKHA().KDJBEAJPOEO(DKNEHBEJABC);
		guiManagerPool.NKFOJNFCGME(DKNEHBEJABC);
		ALJKAAMHHLB.GHBPDBCICLM("ID_ACCEPT" + DKNEHBEJABC);
	}

	[SpecialName]
	public static ObjectPool IFDEKPHHCCN()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.KCDIJNAKLMD("ID_INVITATIONDENIED");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static ObjectPool KPHHGHIGGKE()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static void IKCDINLDIKB(NetworkObjectPool IDEBKDPMPGM)
	{
		LEGMLHDBKOD = IDEBKDPMPGM;
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static ObjectPool MIHGEFILDMN()
	{
		if (OMDMKAMCGEC == null)
		{
			OMDMKAMCGEC = ObjectPool.GetPool("message= ");
		}
		return OMDMKAMCGEC;
	}

	[SpecialName]
	public static ObjectPool MJICOPNOKGA()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static NetworkObjectPool MFKPDKCLDBI()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.GetPool("isSuccess") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	[SpecialName]
	public static ObjectPool AAICLLMEDGP()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.GetPool("Error - sheet {0} doesnt have column {1}");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static ObjectPool PAKMCMNDEKJ()
	{
		if (OMDMKAMCGEC == null)
		{
			OMDMKAMCGEC = ObjectPool.DBDJFIHHPAO("119 LOADING MENU");
		}
		return OMDMKAMCGEC;
	}

	[SpecialName]
	public static NetworkObjectPool KKCMCNCCIMB()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.KCDIJNAKLMD("BotLevel") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	public void EADCPPNFGNA(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		COJFMKNGPBP().SetupPhotonView(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static void EKPDAAJPBLC(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	[SpecialName]
	public static ObjectPool HKDKCFCKDHE()
	{
		if (OMDMKAMCGEC == null)
		{
			OMDMKAMCGEC = ObjectPool.KCDIJNAKLMD("FacebookPassword");
		}
		return OMDMKAMCGEC;
	}

	public void POLFBJJLNGA(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		networkPool.SetupPhotonView(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static void BFCEGLLGAFC(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	[SpecialName]
	public static ObjectPool PIKHOEJEHFJ()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static void ELPLMAENJHA(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	[SpecialName]
	public static void FFFCJEPFEAA(NetworkObjectPool IDEBKDPMPGM)
	{
		LEGMLHDBKOD = IDEBKDPMPGM;
	}

	protected virtual void KALEMFKOGLE()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static NetworkObjectPool ADBOHNCGKHA()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.DBDJFIHHPAO("ID_YOURREWARDS") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	[SpecialName]
	public static ObjectPool AAMONMBFDPJ()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static ObjectPool FLAHKAIJHBP()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.DBDJFIHHPAO("ID_REMINDER_VIPALMOSTEXPIRED");
		}
		return DNJGBBNLOPE;
	}

	public void JKBEFLIPMOK(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		CHHLLIAHECC().GINKKNHNFFM(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static ObjectPool BCPEKNNHIIK()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static ObjectPool HCKJMICDIDF()
	{
		if (OMDMKAMCGEC == null)
		{
			OMDMKAMCGEC = ObjectPool.DBDJFIHHPAO("Exception while processing received sheets: ");
		}
		return OMDMKAMCGEC;
	}

	[SpecialName]
	public static ObjectPool FCGIJGLGGPJ()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	protected virtual void OLBEOPKDEBJ()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	public static void OJOAADFNHFN(NPNOIGHIALL DKNEHBEJABC)
	{
		ALJKAAMHHLB.KNALFHAOFBN("D5" + DKNEHBEJABC);
		IFDEKPHHCCN().KDJBEAJPOEO(DKNEHBEJABC);
		BBGJLDLFEHK().KDJBEAJPOEO(DKNEHBEJABC);
		ADBOHNCGKHA().NKFOJNFCGME(DKNEHBEJABC);
		NNBBOKKENHC().InstantiatePooledObjects(DKNEHBEJABC);
		ALJKAAMHHLB.AKJCKAKDOGM("Processing the request Timed Out!" + DKNEHBEJABC);
	}

	[SpecialName]
	public static NetworkObjectPool GLHPLCEFHGD()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.GetPool("\t\"FALSE\"") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	public void SetupEnemyPhotonView(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		networkPool.SetupPhotonView(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	protected override void Awake()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static void GGBMDJIHJCL(NetworkObjectPool IDEBKDPMPGM)
	{
		LEGMLHDBKOD = IDEBKDPMPGM;
	}

	[SpecialName]
	public static NetworkObjectPool DKNHCGGKNMF()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.DBDJFIHHPAO("ID_COOPCANCELED") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	[SpecialName]
	public static ObjectPool IPAAIIEHGDL()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static ObjectPool HPBDNODOBDD()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.GetPool("Create player instance at ");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static void DHGGEMIGANN(NetworkObjectPool IDEBKDPMPGM)
	{
		LEGMLHDBKOD = IDEBKDPMPGM;
	}

	[SpecialName]
	public static NetworkObjectPool KJEANKAJELG()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.GetPool("Area") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	public void DHDKJDMNENJ(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		CHHLLIAHECC().SetupPhotonView(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static ObjectPool BJMKGOIPLEI()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.DBDJFIHHPAO("menu-arena-scrap-ico");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static ObjectPool IHBCNMIIPPO()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static ObjectPool KEOEDDFOMIP()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.DBDJFIHHPAO("payloadKeys");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static NetworkObjectPool CHHLLIAHECC()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.KCDIJNAKLMD("withContentId") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	[SpecialName]
	public static ObjectPool BGMMBPKLPFI()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static void IKDKIACJMEH(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	[SpecialName]
	public static void LEEACLADJJK(NetworkObjectPool IDEBKDPMPGM)
	{
		LEGMLHDBKOD = IDEBKDPMPGM;
	}

	[SpecialName]
	public static ObjectPool EHLMGMBAKBO()
	{
		if (OMDMKAMCGEC == null)
		{
			OMDMKAMCGEC = ObjectPool.KCDIJNAKLMD("ID_LEAGUESTAYHINT1");
		}
		return OMDMKAMCGEC;
	}

	[SpecialName]
	public static NetworkObjectPool INOJHPIKICM()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.GetPool("id") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	[SpecialName]
	public static ObjectPool NNBBOKKENHC()
	{
		if (OMDMKAMCGEC == null)
		{
			OMDMKAMCGEC = ObjectPool.KCDIJNAKLMD("505 MENU ARMY SCREEN BUY UPGRADE");
		}
		return OMDMKAMCGEC;
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static ObjectPool JIFIGAGLHAP()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static void MFIKGNKHALI(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	public void JLGIGOENFJF(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		KJEANKAJELG().DKJOHKNMFGI(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static void PIDIOECLLCJ(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static void MALFIBOCOHI(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	[SpecialName]
	public static ObjectPool MCACDGOEBHE()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.GetPool(" TOTAL ALLOCATED: ");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static void JFGEHDKKIOF(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	[SpecialName]
	public static ObjectPool DFFBGMOJEPM()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.DBDJFIHHPAO("ID_NOTIFICATION_DAILYREWARD_CARDPACK");
		}
		return DNJGBBNLOPE;
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static NetworkObjectPool COJFMKNGPBP()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.KCDIJNAKLMD("Starter_Assignment_Completed") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	[SpecialName]
	public static ObjectPool PABAMAJHKIN()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.GetPool("elite3");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static ObjectPool NNCLBGKMNEN()
	{
		if (DNJGBBNLOPE == null)
		{
			DNJGBBNLOPE = ObjectPool.GetPool("ID");
		}
		return DNJGBBNLOPE;
	}

	[SpecialName]
	public static ObjectPool LCFPFDACPCI()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	public static void KHLPFECMGCL(NPNOIGHIALL DKNEHBEJABC)
	{
		ALJKAAMHHLB.KNALFHAOFBN("\r" + DKNEHBEJABC);
		PABAMAJHKIN().NKFOJNFCGME(DKNEHBEJABC);
		AAMONMBFDPJ().GBCKONMLAKH(DKNEHBEJABC);
		DKNHCGGKNMF().KDJBEAJPOEO(DKNEHBEJABC);
		MIHGEFILDMN().KDJBEAJPOEO(DKNEHBEJABC);
		ALJKAAMHHLB.ELFCGAGEFLH("TuneListener.DecodeFrom64(string)" + DKNEHBEJABC);
	}

	[SpecialName]
	public static NetworkObjectPool EHFPBDJMGNC()
	{
		if (LEGMLHDBKOD == null)
		{
			LEGMLHDBKOD = ObjectPool.DBDJFIHHPAO("TimeBonus") as NetworkObjectPool;
		}
		return LEGMLHDBKOD;
	}

	public void JPAPJCLPCDB(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		ADBOHNCGKHA().GINKKNHNFFM(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static void EJAHIKPAFCL(NetworkObjectPool IDEBKDPMPGM)
	{
		LEGMLHDBKOD = IDEBKDPMPGM;
	}

	public void PIDLIKLAHCG(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		DKNHCGGKNMF().GINKKNHNFFM(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static ObjectPool GGEDHGBCHOA()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	[SpecialName]
	public static ObjectPool BBGJLDLFEHK()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	public static void DJBHEMBOCDC(NPNOIGHIALL DKNEHBEJABC)
	{
		ALJKAAMHHLB.JIBKGLAPOIB("AtlasPreparer.LoadGameCoroutine" + DKNEHBEJABC);
		AAICLLMEDGP().NKFOJNFCGME(DKNEHBEJABC);
		BCPEKNNHIIK().NKFOJNFCGME(DKNEHBEJABC);
		KKCMCNCCIMB().NKFOJNFCGME(DKNEHBEJABC);
		MIHGEFILDMN().KDJBEAJPOEO(DKNEHBEJABC);
		ALJKAAMHHLB.AEHLEODHMGP("consumePurchaseSucceededEvent: " + DKNEHBEJABC);
	}

	public void INECNNOPGFJ(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		DKNHCGGKNMF().DKJOHKNMFGI(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	protected virtual void GBGDKNIMGMB()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	public void IFHNPLFJIDH(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		DKNHCGGKNMF().SetupPhotonView(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		GHGMIFHAOMI = GetComponent<ObjectPool>();
	}

	[SpecialName]
	public static ObjectPool BCHHIFLKMDA()
	{
		return Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI;
	}

	public void IINHKJBGEDF(int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		networkPool.SetupPhotonView(KGGJOOAFDIF, FMAOPCINBDA, DFHAAIFFLOE);
	}

	[SpecialName]
	public static void HPFLMKBLLKO(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}

	[SpecialName]
	public static void IKKCLPIBEOH(ObjectPool IDEBKDPMPGM)
	{
		DNJGBBNLOPE = IDEBKDPMPGM;
	}
}
