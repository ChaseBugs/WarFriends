using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

[Serializable]
public class PlayerVisual
{
	public enum IGDDHIKBPAI
	{
		Locked,
		NotBuyed,
		Ready,
		Active
	}

	public enum OCFKFHGJBFN
	{
		Shop,
		ValuePack,
		StarterPack,
		StarterAssignment,
		Arena,
		Event,
		Hidden,
		Loyalty
	}

	public enum BJLIFLPNINI
	{
		Common,
		Uncommon,
		Rare,
		Epic,
		Legendary
	}

	public string visualName;

	public string icon;

	private PlayerVisualsRow mRow;

	public static Dictionary<BJLIFLPNINI, string> RarityNames;

	public PlayerVisualsRow row
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool tryOutVisual
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public IGDDHIKBPAI camoState => default(IGDDHIKBPAI);

	public PlayerVisualCategory owner { get; set; }

	public string id { get; set; }

	public string name => null;

	public virtual string description => null;

	public virtual int endPromotion => 0;

	public bool isActive => false;

	public bool isDefault => false;

	public virtual bool isBought => false;

	public bool isEquipped => false;

	public bool isUnlocked => false;

	public bool canBeShownInScreen => false;

	public bool canBotUseIt => false;

	public bool isVipOnly => false;

	public int priceGold => 0;

	public int priceWarbucks => 0;

	public int priceLoyalty => 0;

	public BJLIFLPNINI rarity => default(BJLIFLPNINI);

	public string rarityName => null;

	public int numberOfParts => 0;

	public int numberOfPartsMax => 0;

	public int duplicateWarbucks => 0;

	public float progress => 0f;

	public virtual int decalType => 0;

	public int timeActive => 0;

	public float decalValue => 0f;

	public string decalValueString => null;

	public virtual string decalMiniIcon => null;

	public virtual Color decalMiniIconColor => default(Color);

	public virtual string decalShortName => null;

	public virtual string decalTypeName => null;

	public virtual bool isEmptyPowerBand => false;

	public OCFKFHGJBFN purchasable => default(OCFKFHGJBFN);

	public bool purchasableInShop => false;

	public bool purchasableInArena => false;

	public bool purchasableByLoyalty => false;

	public bool purchasableInPack => false;

	public bool purchaseableInCST => false;

	public bool isFromArena => false;

	public double remainingTime => 0.0;

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

	public bool notificate
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual int startPromotion => 0;

	public int unlockLevelIndex => 0;

	public LevelManager.GameLevel unlockLevel => null;

	public virtual void CDJFLJEACIP()
	{
	}

	public virtual void OHIHNNGKLIM(int GKGOGCKECKM)
	{
	}

	public virtual void FPFDNHHGFPP()
	{
	}

	public virtual void DMNOEANLNHM(AFIKFLMIBBA HHCDBKJFPBD, bool LGJJGEBKKKF = false)
	{
	}

	public virtual void FLNGJDAAMND()
	{
	}

	public void KKADLOMOPHC()
	{
	}

	public int JKFNAHJHFOC(int JPIPAIOGHFE)
	{
		return 0;
	}

	internal string DNDMJKFIJNL()
	{
		return null;
	}

	private CamosManager.SavedPlayerVisual HEMPGJJNCKE()
	{
		return null;
	}

	public virtual void BMHGNPDPBGL()
	{
	}

	public virtual void OCNHEFIPELO()
	{
	}
}
