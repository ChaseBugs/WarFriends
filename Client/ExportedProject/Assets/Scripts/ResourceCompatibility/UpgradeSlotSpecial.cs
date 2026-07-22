using System;
using System.Collections.Generic;

[Serializable]
public class UpgradeSlotSpecial : UpgradeSlot
{
	public override int id => 0;

	public override bool isSpecial => false;

	public override bool isMaxUpgraded => false;

	public override int indexOffset => 0;

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

	public override bool isBought => false;

	public override List<Tuple<string, float[]>> guiStatistics => null;

	public override List<Tuple<string, float>> guiStatisticsStart => null;

	public string abilityValue => null;

	public string abilityMaxValue => null;

	public string abilityStartValue => null;

	public override int armyPowerX10 => 0;

	public int DPDBILLBKDG(int OMGJHEGANFC, int LNOKLLPABOP)
	{
		return 0;
	}

	public float FKBGAECDGEH(int OMGJHEGANFC, int LNOKLLPABOP)
	{
		return 0f;
	}
}
