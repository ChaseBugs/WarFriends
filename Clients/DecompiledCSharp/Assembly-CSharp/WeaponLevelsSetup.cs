using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

[ExecuteInEditMode]
public class WeaponLevelsSetup<T> : WeaponLevelsSetup where T : LevelManager.WeaponLevelDefinition
{
	public T baseDefinition;

	public override float shotDamage => Convert.ToSingle(uprgradesExcel.GetValue(upgradeSlots.boughtIndex, "damage"));

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(statsFor(slot, "attack", "ID_SLOTUPGRADE_DAMAGE"));
		list.Add(statsFor(slot, "clipSize", "ID_SLOTUPGRADE_CLIP_SIZE"));
		list.Add(statsFor(slot, "reloadTime", "ID_SLOTUPGRADE_ROF"));
		list.Add(statsFor(slot, "ammo", "ID_SLOTUPGRADE_AMMO"));
		return list;
	}

	public override void LoadDefinition(byte? data = null, int level = 0)
	{
		baseDefinition.rateOfFire = base.rateOfFire;
		LevelManager.WeaponLevelDefinition weaponLevelDefinition = SetUpWeapon(data, level);
		weaponLevelDefinition.criticalDamage = base.critical;
		weaponLevelDefinition.burstLockTime = base.burstLockTime;
		weaponLevelDefinition.burstSize = base.burstSize;
		weaponLevelDefinition.accuracy = base.accuracy;
		weaponLevelDefinition.SetWeaponparameters(base.weapon);
	}

	public override LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data, int level)
	{
		T val = (T)baseDefinition.Copy();
		val.Zero();
		val.rateOfFire = baseDefinition.rateOfFire;
		int rowIndex = (data.HasValue ? data.Value : upgradeSlots.boughtIndex);
		T val2 = val;
		val2.reloadTime = (float)val2.reloadTime + (float)uprgradesExcel.GetValue(rowIndex, "reloadTime");
		T val3 = val;
		val3.damageAmount = (float)val3.damageAmount + (float)uprgradesExcel.GetValue(rowIndex, "damage");
		T val4 = val;
		val4.clipSize = (int)val4.clipSize + (int)uprgradesExcel.GetValue(rowIndex, "clipSize");
		T val5 = val;
		val5.ammoCount = (int)val5.ammoCount + (int)uprgradesExcel.GetValue(rowIndex, "ammo");
		return val;
	}

	public override Type Type()
	{
		return typeof(T);
	}

	protected Tuple<string, float[]> statsFor(UpgradeSlot slot, string identifier, string name)
	{
		Tuple<string, float[]> tuple = new Tuple<string, float[]>();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		num3 += Convert.ToSingle(uprgradesExcel.GetValue(upgradeSlots.boughtIndex, identifier));
		num += ((slot.boughtIndex >= maxWeaponLevel - 1) ? 0f : Convert.ToSingle(uprgradesExcel.GetValue(upgradeSlots.boughtIndex + 1, identifier)));
		int rowIndex = FindLastRowForSlot(upgradeSlots);
		num2 += Convert.ToSingle(uprgradesExcel.GetValue(rowIndex, identifier));
		tuple.Value1 = name;
		tuple.Value2 = new float[3] { num3, num2, num };
		return tuple;
	}
}
public abstract class WeaponLevelsSetup : Core_BaseScript
{
	public enum State
	{
		Locked,
		NotBuyed,
		WeaponDelivering,
		WeaponDelivered,
		Active,
		Delivering,
		Delivered
	}

	public enum Purchasable
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
		VeteranPack1,
		VeteranPack2,
		VeteranPack3,
		VeteranPack4,
		VeteranPack5
	}

	[Serializable]
	public class UpgradeSlot
	{
		[Header("Pointer")]
		public WeaponLevelsSetup owner;

		internal int mMaxPower = -1;

		public int boughtIndex
		{
			get
			{
				LevelManager.SavedWeaponSlots weaponSlot = owner.GetWeaponSlot();
				return weaponSlot.boughtIndex;
			}
			private set
			{
				if (value != boughtIndex)
				{
					owner.GetWeaponSlot().boughtIndex = value;
				}
			}
		}

		public int warArenaUpgrade => owner.maxWeaponLevel;

		public bool canActivate => !owner.delivering && owner.deliveryActivationNeeded;

		public bool canUpgrade => owner.CanUpgrade(this);

		public int deliveryTime => owner.DeliveryTime(this);

		public List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStats(this);

		public int instantBuyPrice
		{
			get
			{
				if (owner.remainingDeliveringSeconds < 0.0)
				{
					return 0;
				}
				return MiscTools.ConvertTimeIntoGold(Convert.ToInt32(owner.remainingDeliveringSeconds));
			}
		}

		public int level => boughtIndex + 1;

		public int upgradePrice => owner.UpgradePrice(this);

		public void Activate()
		{
			if (canActivate)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.ActivateUpgrade);
				boughtIndex++;
				owner.deliveryActivationNeeded = false;
				Debug.Log("Weapon upgrade for " + owner.GetSheetName() + " " + boughtIndex + " was activated.");
			}
		}

		public void BuyUpgrade()
		{
			if (canUpgrade)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Upgrade);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				owner.endDeliveryTime = owner.startDeliveryTime + deliveryTime;
				owner.deliveryActivationNeeded = true;
				Debug.Log("Started delivering weapon upgrade for " + owner.GetSheetName() + " " + boughtIndex + ". It will be ready in " + deliveryTime + " seconds.");
			}
		}

		public void InstantActivation()
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.ActivateUpgrade);
			boughtIndex++;
			owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			owner.deliveryActivationNeeded = false;
			Debug.Log("Weapon upgrade for " + owner.GetSheetName() + " " + boughtIndex + " was activated (through fast activation).");
		}
	}

	private const int nrOfExtraRows = 1;

	[Header("Name + Description")]
	public string weaponDictionaryId;

	[HideInInspector]
	public string weaponName;

	[Header("Weapon Screen")]
	public int guiOrder = 1;

	public Vector3 defaultPosition;

	public Vector2 defaultRotation;

	[Header("Weapon Settings")]
	public string weaponModelPrefabName;

	public string assetBundleName;

	public WeaponCategory weaponCategory;

	public bool isTutorialWeapon;

	public int indexInWeaponInventory;

	[HideInInspector]
	public int indexInLevelManager;

	[Header("List of Slots")]
	public UpgradeSlot upgradeSlots;

	[Header("For Automatic Generation of Slots")]
	public bool generateSlots;

	[Header("Other")]
	public WeaponUpgradesRow weaponUpgradesRow;

	[Header("Unit weapon equivalent")]
	public Weapon unitWeaponPrefab;

	public int unitWeaponLevel;

	public Weapon.WeaponType weaponType;

	protected Google2uComponentBase uprgradesExcel;

	private WeaponInventory mInventory;

	private string mSheetName;

	public bool tryOutWeapon
	{
		get
		{
			return GetWeaponSlot().borrowed;
		}
		set
		{
			GetWeaponSlot().borrowed = value;
		}
	}

	public string purchasableValue => weaponUpgradesRow.PURCHASABLE;

	public Purchasable purchasable
	{
		get
		{
			if (purchasableValue == "value")
			{
				return Purchasable.ValuePack;
			}
			if (purchasableValue == "starter")
			{
				return Purchasable.StarterPack;
			}
			if (purchasableValue == "assignment")
			{
				return Purchasable.StarterAssignment;
			}
			if (purchasableValue.StartsWith("elitepack"))
			{
				if (purchasableValue == "elitepack1")
				{
					return Purchasable.ElitePack1;
				}
				if (purchasableValue == "elitepack2")
				{
					return Purchasable.ElitePack2;
				}
				if (purchasableValue == "elitepack3")
				{
					return Purchasable.ElitePack3;
				}
				if (purchasableValue == "elitepack4")
				{
					return Purchasable.ElitePack4;
				}
				if (purchasableValue == "elitepack5")
				{
					return Purchasable.ElitePack5;
				}
				if (purchasableValue == "elitepack6")
				{
					return Purchasable.ElitePack6;
				}
			}
			if (purchasableValue.StartsWith("veteranpack"))
			{
				if (purchasableValue == "veteranpack1")
				{
					return Purchasable.VeteranPack1;
				}
				if (purchasableValue == "veteranpack2")
				{
					return Purchasable.VeteranPack2;
				}
				if (purchasableValue == "veteranpack3")
				{
					return Purchasable.VeteranPack3;
				}
				if (purchasableValue == "veteranpack4")
				{
					return Purchasable.VeteranPack4;
				}
				if (purchasableValue == "veteranpack5")
				{
					return Purchasable.VeteranPack5;
				}
			}
			return Purchasable.Shop;
		}
	}

	public bool purchasableInShop => purchasable == Purchasable.Shop;

	public bool canBeShownInScreen
	{
		get
		{
			if (bought || purchasableInShop || (purchasable == Purchasable.StarterPack && PlayerAnalytics.instance.showStarterPack))
			{
				return true;
			}
			if (purchasable == Purchasable.StarterPack || purchasable == Purchasable.ValuePack || purchasable == Purchasable.StarterAssignment)
			{
				return false;
			}
			return PlayerAnalytics.instance.ShowPack(purchasableValue);
		}
	}

	public bool canBeBought => LevelManager.instance.currentLevel.index >= weaponUpgradesRow.CANBEBOUGHT - 1;

	public bool bought
	{
		get
		{
			if (isTutorialWeapon)
			{
				if (Singleton<GameController>.instance.isTutorial)
				{
					return GetWeaponSlot().bought;
				}
				return true;
			}
			return (purchasableInShop && unlockLevelIndex == 0 && price == 0 && priceGold == 0) || (GetWeaponSlot().bought && canBeBought) || tryOutWeapon;
		}
		set
		{
			if (value != bought)
			{
				GetWeaponSlot().bought = value;
			}
		}
	}

	public bool boughtDeliveringInProgress
	{
		get
		{
			GetWeaponSlot();
			return deliveryActivationNeeded && delivering;
		}
	}

	public byte buyedIndices => (byte)upgradeSlots.boughtIndex;

	public int burstSize => weaponUpgradesRow.BURSTSIZE;

	public float burstLockTime => weaponUpgradesRow.BURSTLOCKTIME;

	public float accuracy => weaponUpgradesRow.ACCURACY;

	public float critical => weaponUpgradesRow.CRITICAL;

	public int shotVelocity => (int)(float)weaponUpgradesRow.SPEED;

	public float rateOfFire => weaponUpgradesRow.RATEOFFIRE;

	public int price => weaponUpgradesRow.PRICE;

	public int priceGold => weaponUpgradesRow.PRICEGOLD;

	public int weaponDeliveryTime => weaponUpgradesRow.DELIVERTIME;

	public float damageToPlayerRatio => weaponUpgradesRow.DAMAGETOPLAYER;

	public float damageToPlayerRatioOvertime => weaponUpgradesRow.DAMAGETOPLAYEROVERTIME;

	public float damageToPlayerBehindShieldRatio => weaponUpgradesRow.DAMAGETOPLAYERBEHINDSHIELD;

	public float damageToShield => weaponUpgradesRow.DAMAGETOSHIELD;

	public int unlockLevelIndex => weaponUpgradesRow.UNLOCKLEVEL - 1;

	public bool delivering
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return currentTimestampDouble < (double)endDeliveryTime;
		}
	}

	public bool deliveryActivationNeeded
	{
		get
		{
			LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
			return GetSheetName() == weaponDelivery.itemId && weaponDelivery.activationNeeded;
		}
		set
		{
			if (value != deliveryActivationNeeded)
			{
				LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
				weaponDelivery.itemId = GetSheetName();
				weaponDelivery.activationNeeded = value;
			}
		}
	}

	public long endDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
			return (!(GetSheetName() != weaponDelivery.itemId)) ? weaponDelivery.end : 0;
		}
		set
		{
			if (value != endDeliveryTime)
			{
				LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
				weaponDelivery.itemId = GetSheetName();
				weaponDelivery.end = value;
			}
		}
	}

	public int instantWeaponDeliveryPrice
	{
		get
		{
			if (remainingDeliveringSeconds < 0.0)
			{
				return 0;
			}
			return MiscTools.ConvertTimeIntoGold(Convert.ToInt32(remainingDeliveringSeconds));
		}
	}

	public int fullPrizeOfUpgradeDeliveryGold
	{
		get
		{
			if (!canBeUpgraded)
			{
				return 0;
			}
			return MiscTools.ConvertTimeIntoGold(upgradeSlots.deliveryTime);
		}
	}

	public virtual int maxWeaponLevel => uprgradesExcel.RowsGeneric.Count - 1;

	public PlayerWeapon playerWeapon => weaponInventory.allWeapons[indexInWeaponInventory];

	public float progressDelivering
	{
		get
		{
			if (weaponState != State.Delivering && weaponState != State.WeaponDelivering)
			{
				return 0f;
			}
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			double num = (currentTimestampDouble - (double)startDeliveryTime) / (double)(endDeliveryTime - startDeliveryTime);
			return Mathf.Clamp01((float)num);
		}
	}

	public virtual float rateOfFirePerMinute => 60f / rateOfFire;

	public double remainingDeliveringSeconds
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return (double)endDeliveryTime - currentTimestampDouble;
		}
	}

	public bool showed
	{
		get
		{
			return GetWeaponSlot().showed;
		}
		set
		{
			GetWeaponSlot().showed = true;
		}
	}

	public long startDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
			return (!(GetSheetName() != weaponDelivery.itemId)) ? weaponDelivery.start : 0;
		}
		set
		{
			if (value != startDeliveryTime)
			{
				LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
				weaponDelivery.itemId = GetSheetName();
				weaponDelivery.start = value;
			}
		}
	}

	public bool unlocked => unlockLevelIndex <= LevelManager.instance.currentLevel.index || bought;

	public virtual bool canBeUpgraded => weaponLevel < maxWeaponLevel;

	public LevelManager.GameLevel unlockLevel => LevelManager.instance.GetLevelDefinition(unlockLevelIndex);

	public float upgradesProgress => (float)weaponLevel / (float)maxWeaponLevel;

	public Weapon weapon => weaponInventory.allWeapons[indexInWeaponInventory].weapon;

	public WeaponInventory weaponInventory
	{
		get
		{
			if (mInventory == null)
			{
				mInventory = PlayerController.currentPlayer.weaponInventory;
			}
			return mInventory;
		}
		set
		{
			mInventory = value;
		}
	}

	public virtual int weaponLevel => bought ? upgradeSlots.level : 0;

	public float weaponPower => GetWeaponDPS((upgradeSlots != null) ? upgradeSlots.boughtIndex : GetWeaponSlot().boughtIndex);

	public int weaponPowerX10 => GetWeaponPowerX10(upgradeSlots.boughtIndex);

	public int weaponPowerX10Next => GetWeaponPowerX10(upgradeSlots.boughtIndex + 1);

	public int weaponPowerX10Max => GetWeaponPowerX10(FindLastRowForSlot(upgradeSlots));

	public State weaponState
	{
		get
		{
			if (!unlocked)
			{
				return State.Locked;
			}
			if (bought && delivering)
			{
				return State.Delivering;
			}
			if (bought && deliveryActivationNeeded)
			{
				return State.Delivered;
			}
			if (!bought && delivering)
			{
				return State.WeaponDelivering;
			}
			if (!bought && deliveryActivationNeeded)
			{
				return State.WeaponDelivered;
			}
			if (!bought)
			{
				return State.NotBuyed;
			}
			return State.Active;
		}
	}

	public virtual float shotDamage => 0f;

	public int totalAmmo
	{
		get
		{
			if (uprgradesExcel.HasColumn("ammo"))
			{
				return (int)uprgradesExcel.GetValue(upgradeSlots.boughtIndex, "ammo");
			}
			return 0;
		}
	}

	public int GetLevel(bool isBought, int boughtIndex)
	{
		return isBought ? (boughtIndex + 1) : 0;
	}

	public void ActivateWeapon()
	{
		bought = true;
		if (priceGold == 0)
		{
			deliveryActivationNeeded = false;
		}
	}

	public void Buy()
	{
		if (priceGold > 0)
		{
			bought = true;
			return;
		}
		bought = false;
		startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		endDeliveryTime = startDeliveryTime + weaponDeliveryTime;
		deliveryActivationNeeded = true;
		Debug.Log("Started delivering |" + GetSheetName() + "| time: " + weaponDeliveryTime + "s");
	}

	public bool CanUpgrade(UpgradeSlot slot)
	{
		return maxWeaponLevel > slot.boughtIndex + 1;
	}

	public int DeliveryTime(UpgradeSlot slot)
	{
		return (int)(float)uprgradesExcel.GetValue(slot.boughtIndex, "DeliveryTime");
	}

	public int FindLastRowForSlot(UpgradeSlot slot)
	{
		return maxWeaponLevel - 1;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		return new List<Tuple<string, float[]>>();
	}

	private float GetWeaponDPS(int index)
	{
		index = Mathf.Clamp(index, 0, maxWeaponLevel - 1);
		return (float)uprgradesExcel.GetValue(index, "DPS");
	}

	public float GetWeaponPower(int index)
	{
		return GetWeaponDPS(index);
	}

	public int GetWeaponPowerX10(int index)
	{
		return MiscTools.RoundToInt(10f * GetWeaponDPS(index));
	}

	public void Init()
	{
		upgradeSlots.owner = this;
		upgradeSlots.mMaxPower = -1;
	}

	public void InstantBuyWeapon()
	{
		bought = true;
		endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		deliveryActivationNeeded = false;
	}

	public abstract void LoadDefinition(byte? data = null, int level = 0);

	public abstract LevelManager.WeaponLevelDefinition SetUpWeapon(byte? data = null, int level = 0);

	public abstract Type Type();

	public virtual int UpgradePrice(UpgradeSlot slot)
	{
		return (int)uprgradesExcel.GetValue(slot.boughtIndex, "NextUpgradePrice");
	}

	internal string GetSheetName()
	{
		if (string.IsNullOrEmpty(mSheetName))
		{
			mSheetName = uprgradesExcel.GetType().ToString();
		}
		return mSheetName;
	}

	protected override void Awake()
	{
		base.Awake();
		uprgradesExcel = GetComponent<Google2uComponentBase>();
	}

	private LevelManager.SavedWeaponSlots GetWeaponSlot()
	{
		string sheetName = GetSheetName();
		if (LevelManager.instance.data.savedWeapons.TryGetValue(sheetName, out var value))
		{
			return value;
		}
		LevelManager.SavedWeaponSlots savedWeaponSlots = new LevelManager.SavedWeaponSlots();
		savedWeaponSlots.bought = false;
		savedWeaponSlots.showed = unlockLevelIndex == 0;
		savedWeaponSlots.boughtIndex = 0;
		value = savedWeaponSlots;
		LevelManager.instance.data.savedWeapons[sheetName] = value;
		return value;
	}
}
