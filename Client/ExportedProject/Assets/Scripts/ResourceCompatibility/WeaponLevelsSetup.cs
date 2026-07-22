using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public abstract class WeaponLevelsSetup : Core_BaseScript
{
	public enum NFIGJECBCBO
	{
		Locked,
		NotBuyed,
		WeaponDelivering,
		WeaponDelivered,
		Active,
		Delivering,
		Delivered
	}

	public enum EMBENCEOBDP
	{
		Locked,
		BuyIt,
		Equip,
		BuyPack,
		BuyBlackmarket,
		BuyRental,
		BuyCooldown,
		Empty
	}

	public enum LHIIOHANBOE
	{
		Empty,
		RentIt,
		Rented,
		Upgrade,
		DeliverNow,
		Activate,
		MaxUpgraded
	}

	public enum GHBCODKEMIE
	{
		Special,
		Locked,
		Buyable,
		Rentable,
		Rented,
		Other
	}

	public enum FPKFFPOKNGD
	{
		Shop,
		ValuePack,
		StarterPack,
		StarterAssignment,
		ElitePack1,
		ElitePack2,
		ElitePack3,
		ElitePack4,
		ElitePack5,
		ElitePack6,
		ElitePack7,
		VeteranPack0,
		VeteranPack1,
		VeteranPack2,
		VeteranPack3,
		VeteranPack4,
		VeteranPack5,
		BlackMarket,
		StarterPackOld,
		Hidden
	}

	[Serializable]
	public class UpgradeSlot
	{
		public WeaponLevelsSetup owner;

		internal int mMaxPower;

		public int boughtIndex
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public int warArenaUpgrade => 0;

		public bool canActivate => false;

		public bool canUpgrade => false;

		public int deliveryTime => 0;

		public List<Tuple<string, float[]>> guiStatistics => null;

		public int instantBuyPrice => 0;

		public int level => 0;

		public int upgradePrice => 0;

		public void KKJLGGJCAIJ(int EPNGMAHENPA)
		{
		}

		public void BEGPHBINMJA()
		{
		}

		public int DKDAMHOIDKG(int LFBANFEJNEF)
		{
			return 0;
		}

		public void IKBMNGFDLFK()
		{
		}
	}

	public string FCJOMEAMOIM;

	public int KPLGCBBCCPF;

	public Vector3 CBPLLMBIFGM;

	public Vector2 CCEBJEKMAGP;

	public string JPFGCEHMFJK;

	public string LMBBOKMEPGI;

	public WeaponCategory FCNJEGHDPKH;

	public bool CAPDONFMIPF;

	public int FIBJOPOJBMC;

	public WeaponLevelsSetup BJBNDCJEHBJ;

	public UpgradeSlot HEBMDHGPGGF;

	public Weapon OIMBFLDOJHN;

	public int FENDMDEKFNJ;

	public Weapon.BAGDEMJGIOF JHEJINKHHLK;

	protected Google2uComponentBase NMCLIBHEPIJ;

	private WeaponInventory JCHDDFGCLDB;

	private const int IAGGEEEGLIO = 1;

	[CompilerGenerated]
	private WeaponFeature _003CJOGMDIOPFKD_003Ek__BackingField;

	[CompilerGenerated]
	private WeaponUpgradesRow _003CAMDEPACHBPA_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CAHCBGPNGDGI_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CKJALPPLCJHE_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CDJKOBJPPIJF_003Ek__BackingField;

	[CompilerGenerated]
	private Dictionary<string, LevelManager.VariantData> _003CIILMFCIGNDD_003Ek__BackingField;

	[CompilerGenerated]
	private Dictionary<string, int> _003CIAHMEFGAIJD_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CBLJDENLCOEC_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CMCHAGFENOJD_003Ek__BackingField;

	private string PNPDMIDCDOL;

	public string weaponName => null;

	public string weaponNameWithoutPerk => null;

	public WeaponFeature weaponFeature
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public WeaponUpgradesRow weaponUpgradesRow
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public int indexInLevelManager
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public bool tryOutWeapon
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string purchasableValue => null;

	public FPKFFPOKNGD purchasable => default(FPKFFPOKNGD);

	public bool purchasableInShop => false;

	public bool purchasableInBlackmarket => false;

	public bool purchasableInPack => false;

	public bool canBeShownInScreen => false;

	public Color weaponBackground => default(Color);

	public bool canBeBought => false;

	public bool bought
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int specialFeature
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public bool dupWeapon
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public Dictionary<string, LevelManager.VariantData> variantData
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public Dictionary<string, int> augs
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public float extraAmmoFromWaugs
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public int dismantled
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public bool boughtDeliveringInProgress => false;

	public int dismantlingCooldown => 0;

	public virtual int burstSize => 0;

	public float burstLockTime => 0f;

	public float baseAccuracy => 0f;

	public float accuracy => 0f;

	public float baseCritical => 0f;

	public float critical => 0f;

	public float shotVelocity => 0f;

	public float rateOfFire => 0f;

	public int price => 0;

	public int priceGold => 0;

	public int weaponDeliveryTime => 0;

	public float damageToPlayerRatio => 0f;

	public float damageToPlayerRatioOvertime => 0f;

	public float damageToPlayerBehindShieldRatio => 0f;

	public float damageToShield => 0f;

	public int blackmarketPrice => 0;

	public float reloadGUI => 0f;

	public int magazineGUI => 0;

	public int grade => 0;

	public int materialsCreatedFromWeapon => 0;

	public int unlockLevelIndex => 0;

	public bool delivering => false;

	public bool deliveryActivationNeeded
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public long endDeliveryTime
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	public int instantWeaponDeliveryPrice => 0;

	public int fullPrizeOfUpgradeDeliveryGold => 0;

	public virtual int maxWeaponLevel => 0;

	public PlayerWeapon playerWeapon => null;

	public float progressDelivering => 0f;

	public virtual float rateOfFirePerMinute => 0f;

	public double remainingDeliveringSeconds => 0.0;

	public bool showed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public long startDeliveryTime
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	public bool unlocked => false;

	public virtual bool canBeUpgraded => false;

	public LevelManager.GameLevel unlockLevel => null;

	public float upgradesProgress => 0f;

	public Weapon weapon => null;

	public WeaponInventory weaponInventory
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual int weaponLevel => 0;

	public float weaponPower => 0f;

	public int weaponPowerX10 => 0;

	public int weaponPowerX10Next => 0;

	public int weaponPowerX10Max => 0;

	public NFIGJECBCBO weaponState => default(NFIGJECBCBO);

	public EMBENCEOBDP screenRightState => default(EMBENCEOBDP);

	public LHIIOHANBOE screenLeftState => default(LHIIOHANBOE);

	public GHBCODKEMIE screenBottomState => default(GHBCODKEMIE);

	public string excelSheetName => null;

	public virtual float shotDamage => 0f;

	public int totalAmmo => 0;

	public LevelManager.SavedWeaponSlots weaponSlot => null;

	public void LoadDefinition(byte? BMIADLFBMEN = null, int DBMLGANKIOK = 0)
	{
	}

	public float GetBoughtParam(byte? BMIADLFBMEN, string HHDCBKDKICG)
	{
		return 0f;
	}

	public virtual void SetWeaponparameters(Weapon AEBEOCBIBFI, byte? BMIADLFBMEN)
	{
	}

	protected Tuple<string, float[]> OJHMHFKHEMN(UpgradeSlot DHBBBJLNMPH, string NGOFEJGOJNE, string LEGNKFCNBGA, float DAMNCHALAPG, bool NHBBCBMIGKG = false)
	{
		return null;
	}

	private bool LDDKNDGNAIA()
	{
		return false;
	}

	public int GetLevel(bool MIHCMBEHLME, int MHPPLILOJND)
	{
		return 0;
	}

	public void Buy(int NIEPAPEHJOO = -1)
	{
	}

	public void InstantBuyWeapon()
	{
	}

	public void ActivateWeapon()
	{
	}

	public void DeactivateWeapon()
	{
	}

	public bool CanUpgrade(UpgradeSlot DHBBBJLNMPH)
	{
		return false;
	}

	public int DeliveryTime(UpgradeSlot DHBBBJLNMPH)
	{
		return 0;
	}

	public int FindLastRowForSlot(UpgradeSlot DHBBBJLNMPH)
	{
		return 0;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot DHBBBJLNMPH)
	{
		return null;
	}

	private float ABCHDFEHPLB(int EPNGMAHENPA, WeaponFeature FLJDODKMJBO = null, bool BADDPCDHJCB = true)
	{
		return 0f;
	}

	public float GetWeaponPower(int EPNGMAHENPA, WeaponFeature FLJDODKMJBO)
	{
		return 0f;
	}

	public int GetWeaponPowerX10(int EPNGMAHENPA, WeaponFeature FLJDODKMJBO, bool BADDPCDHJCB = true)
	{
		return 0;
	}

	public void Init()
	{
	}

	public virtual int UpgradePrice(UpgradeSlot DHBBBJLNMPH)
	{
		return 0;
	}

	internal string DNDMJKFIJNL()
	{
		return null;
	}

	protected override void Awake()
	{
	}

	private LevelManager.SavedWeaponSlots INMLAHGPIEE()
	{
		return null;
	}
}
