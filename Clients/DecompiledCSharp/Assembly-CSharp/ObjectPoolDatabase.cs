public class ObjectPoolDatabase : Singleton<ObjectPoolDatabase>
{
	public EnemyController enemy;

	public Healthbar healthbarPrefab;

	public Healthbar verticalHealthBar;

	public SkillShotDisplayer skillShotDisplayer;

	public SkillShotDisplayerItem skillShotDisplayerItem;

	public CustomDisplayerItem customDisplayerItem;

	public HudObjectIndicator2D indicator;

	public DamageDisplayer damageDisplayer;

	public NewUnitDisplayerItem newUnitDisplayer;

	public Drone drone;

	public AICar humvee;

	public AICarBuggy buggy;

	public AICarTransporter transporter;

	public Helicopter helicopter;

	public Tank tank;

	public Turret turret;

	public TurretRockets turretRockets;

	public Mech mech;

	public HeavyTurret heavyTurret;

	public AssaultHelicopter assaultHelicopter;

	public Decoy decoy;

	public MiniDrone miniDrone;

	public PlayerController player;

	public ShootableBox shootableBox;

	public Parachute parachute;

	public ObjectPool mainObjectPool;

	private static ObjectPool mAmmoPool;

	private static NetworkObjectPool mNetworkPool;

	public NoMoveIndikator noMoveIndikator;

	public BuddyNameDisplayer buddyNameDisplayer;

	public BulletSlow bulletSlow;

	public BulletPoison bulletPoison;

	public static ObjectPool ammoPool
	{
		get
		{
			if (mAmmoPool == null)
			{
				mAmmoPool = ObjectPool.GetPool("AmmoPool");
			}
			return mAmmoPool;
		}
		set
		{
			mAmmoPool = value;
		}
	}

	public static NetworkObjectPool networkPool
	{
		get
		{
			if (mNetworkPool == null)
			{
				mNetworkPool = ObjectPool.GetPool("NetworkPool") as NetworkObjectPool;
			}
			return mNetworkPool;
		}
		set
		{
			mNetworkPool = value;
		}
	}

	public static ObjectPool mainPool => Singleton<ObjectPoolDatabase>.instance.mainObjectPool;

	protected override void Awake()
	{
		base.Awake();
		mainObjectPool = GetComponent<ObjectPool>();
	}
}
