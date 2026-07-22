using System;
using System.Collections.Generic;

[Serializable]
public class UpgradeSlotElite : UpgradeSlot
{
	public enum BHIHJBDFBMC
	{
		NotImplemented,
		Locked,
		ConvertScrapsToParts,
		Activate,
		Upgrade,
		TierFull,
		MaxUpgrades
	}

	public override int id => 0;

	public override bool isSpecial => false;

	public override int indexOffset => 0;

	public override bool isMaxUpgraded => false;

	public int upgradePriceParts => 0;

	public float progress => 0f;

	public int missingScraps => 0;

	public int currentParts
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override int boughtIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override int bmIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override bool isUnlocked => false;

	public bool isImplemented => false;

	public override bool isBought => false;

	public override List<Tuple<string, float[]>> guiStatistics => null;

	public override List<Tuple<string, float>> guiStatisticsStart => null;

	public string buffValue => null;

	public string buffMaxValue => null;

	public string buffStartValue => null;

	public override int armyPowerX10 => 0;

	public int unlockTier => 0;

	public bool haveEnoughtParts => false;

	public int nextTierIndexForUpgrades => 0;

	public int DPDBILLBKDG(int CJAFDJMEGPP, bool OHOPOOEPMNP)
	{
		return 0;
	}

	public new float FKBGAECDGEH(int CJAFDJMEGPP, bool OHOPOOEPMNP)
	{
		return 0f;
	}

	public int HAMJMEAEFNG(int FBMFNHPAENB)
	{
		return 0;
	}

	public void MKMHEEEFGDP()
	{
	}

	public BHIHJBDFBMC LODHJCJNCHE()
	{
		return default(BHIHJBDFBMC);
	}
}
