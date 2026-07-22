using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

public class BlackMarketStoreManager : DatabaseSerializedObjectGeneric<BlackMarketStoreManager.BlackMarketStoreData>
{
	public enum AOLKNONGMCJ
	{
		Unit,
		Weapon,
		Warcards,
		EliteParts,
		Scraps,
		Augmentation,
		Boosters,
		LoyaltyPoints,
		Tickets,
		WeaponAug,
		DoubleUpgrades
	}

	[Preserve]
	public class BlackMarketStoreData
	{
		public Dictionary<int, BMSlotData> slots;

		public int restockDeadline;

		public int restockPrice;

		public int lastRestockTime;

		public string PrintBMSlotData()
		{
			return null;
		}
	}

	[Preserve]
	public class BMSlotData
	{
		public AOLKNONGMCJ type;

		public string weaponName;

		public int special;

		public bool dupWeapon;

		public string unitName;

		public int level;

		public int specialSlot;

		public int eliteSlot;

		public int tier;

		public string cardName;

		public int effectId;

		public string triggerId;

		public BoosterManager.EBLCALOMCNP boosterType;

		public int amount;

		public OPGPFDFGCKE currencyType;

		public int price;

		public bool isBought;

		public int itemDbKey;

		public int eId;

		public int weaponCat;

		public int grade;

		public int xp;

		public AugmentationManager.ENBIFKHMAGA rarity;

		public WeaponAugsManager.BMDBMIKHHJN statId;
	}

	private static BlackMarketStoreManager DJDBDKFAKHN;

	private List<WeaponLevelsSetup> JNPIBBDLCNI;

	private LevelBehaviour LFJCEHJFPDD;

	private LevelBehaviour NKCLNCCBGCH;

	private bool DPELFIGPGMP;

	[CompilerGenerated]
	private bool _003CODHADHLHDKI_003Ek__BackingField;

	[CompilerGenerated]
	private Action PGFPODEIMEI;

	[CompilerGenerated]
	private Action LBJKDFBHOJG;

	public static BlackMarketStoreManager instance => null;

	public int deadline => 0;

	public int lastRestockTime => 0;

	public int restockPrice => 0;

	public bool isBMSUnlocked => false;

	public bool restockInProgress
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public event Action RestockBMStore
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action UpdateBMStore
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void OnDestroy()
	{
	}

	public bool IsRestockInProgress()
	{
		return false;
	}

	public void RestockResponse()
	{
	}

	public void StartRestocking()
	{
	}

	public void LoadBMStoreData(string AGBKKJBHJCA)
	{
	}

	public void SetPurchased(int PKELBCEPGLI)
	{
	}

	public void UpdateBMStoreGUI()
	{
	}

	public List<WeaponLevelsSetup> GetWeapons()
	{
		return null;
	}

	public LevelBehaviour GetUnit()
	{
		return null;
	}

	public bool WasBMOffer(LevelBehaviour NGEDOMFLLKI)
	{
		return false;
	}

	public bool IsWeaponInBMS(string AMLIEAPPMKJ)
	{
		return false;
	}

	public void SendAnalyticsForNewBMAll()
	{
	}

	private void IJDFOICMIIL(BMSlotData FDCOJJJHNME, int PKELBCEPGLI)
	{
	}

	public void SendAnalyticsForBMBuy(BMSlotData FDCOJJJHNME, int PKELBCEPGLI)
	{
	}

	private void MPHDOMBICLL()
	{
	}

	private void NEDDFNMPJGC()
	{
	}

	private void IMABLLLBACF()
	{
	}

	private WeaponLevelsSetup HLBCOAFIFFB(BMSlotData BHAHHOMJLGI)
	{
		return null;
	}

	protected override void Awake()
	{
	}

	public void ClearRestockDeadline()
	{
	}

	private void HBPOCFHCFPB(string NDMHNCPOOPO)
	{
	}

	private void LateUpdate()
	{
	}
}
