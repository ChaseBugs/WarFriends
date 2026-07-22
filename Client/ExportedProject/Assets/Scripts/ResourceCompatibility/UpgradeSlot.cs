using System;
using System.Collections.Generic;

[Serializable]
public class UpgradeSlot
{
	public UpgradeSlots owner;

	internal int mMaxPower;

	internal int mMaxRowForActualTier;

	internal int mMinRowForActualTier;

	public virtual int id => 0;

	public virtual bool isSpecial => false;

	public virtual int indexOffset => 0;

	public virtual bool isMaxUpgraded => false;

	public bool isDelivering => false;

	public bool isTierFullUpgraded => false;

	public virtual int boughtIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int boughtIndexAbsolute => 0;

	public virtual int bmIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int bmIndexAbsolute => 0;

	public virtual bool isBought
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool isUnlocked => false;

	public bool canUpgrade => false;

	public bool canBuy => false;

	public bool canActivate => false;

	public int upgradePrice => 0;

	public virtual List<Tuple<string, float[]>> bmGuiStatistics => null;

	public virtual List<Tuple<string, float[]>> guiStatistics => null;

	public virtual List<Tuple<string, float>> guiStatisticsStart => null;

	public int minRowForActualTier => 0;

	public virtual int maxRowForActualTier => 0;

	public int maxPower => 0;

	public int maxIndexInExcel => 0;

	public int deliveryTime => 0;

	public int instantBuyPrice => 0;

	public int fullPrizeOfUpgradeDeliveryGold => 0;

	public virtual int armyPowerX10 => 0;

	public int OHMKKIMEBCE(int LNOKLLPABOP)
	{
		return 0;
	}

	public int HEGLBCBPGJN(int LNOKLLPABOP)
	{
		return 0;
	}

	public int BDGPDPFAFOD(int LNOKLLPABOP)
	{
		return 0;
	}

	private int DPDBILLBKDG(int MHPPLILOJND)
	{
		return 0;
	}

	public float FKBGAECDGEH(int MHPPLILOJND, bool BADDPCDHJCB = true)
	{
		return 0f;
	}

	public int DKDAMHOIDKG(int LFBANFEJNEF)
	{
		return 0;
	}

	public void BEGPHBINMJA()
	{
	}

	public void IKBMNGFDLFK()
	{
	}

	public void BIMHOKOAKBI()
	{
	}
}
