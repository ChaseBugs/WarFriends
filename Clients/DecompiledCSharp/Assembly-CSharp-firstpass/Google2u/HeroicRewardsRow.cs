using System;
using UnityEngine;

namespace Google2u;

[Serializable]
public class HeroicRewardsRow : IGoogle2uRow
{
	public int MAXLEVEL;

	public int MAXMISSION;

	public int REWARDGOLD;

	public int REWARDWARBUCKS;

	public int Get_MAXLEVEL
	{
		get
		{
			return MAXLEVEL;
		}
		set
		{
			MAXLEVEL = value;
		}
	}

	public int Get_MAXMISSION
	{
		get
		{
			return MAXMISSION;
		}
		set
		{
			MAXMISSION = value;
		}
	}

	public int Get_REWARDGOLD
	{
		get
		{
			return REWARDGOLD;
		}
		set
		{
			REWARDGOLD = value;
		}
	}

	public int Get_REWARDWARBUCKS
	{
		get
		{
			return REWARDWARBUCKS;
		}
		set
		{
			REWARDWARBUCKS = value;
		}
	}

	public int Length => 4;

	public string this[int i] => GetStringDataByIndex(i);

	public HeroicRewardsRow()
	{
	}

	public HeroicRewardsRow(string _ID, string _MAXLEVEL, string _MAXMISSION, string _REWARDGOLD, string _REWARDWARBUCKS)
	{
		if (int.TryParse(_MAXLEVEL, out var result))
		{
			MAXLEVEL = result;
		}
		else
		{
			Debug.LogError("Failed To Convert MAXLEVEL string: " + _MAXLEVEL + " to int");
		}
		if (int.TryParse(_MAXMISSION, out var result2))
		{
			MAXMISSION = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert MAXMISSION string: " + _MAXMISSION + " to int");
		}
		if (int.TryParse(_REWARDGOLD, out var result3))
		{
			REWARDGOLD = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert REWARDGOLD string: " + _REWARDGOLD + " to int");
		}
		if (int.TryParse(_REWARDWARBUCKS, out var result4))
		{
			REWARDWARBUCKS = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert REWARDWARBUCKS string: " + _REWARDWARBUCKS + " to int");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = MAXLEVEL.ToString();
			break;
		case 1:
			result = MAXMISSION.ToString();
			break;
		case 2:
			result = REWARDGOLD.ToString();
			break;
		case 3:
			result = REWARDWARBUCKS.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "MAXLEVEL":
			result = MAXLEVEL.ToString();
			break;
		case "MAXMISSION":
			result = MAXMISSION.ToString();
			break;
		case "REWARDGOLD":
			result = REWARDGOLD.ToString();
			break;
		case "REWARDWARBUCKS":
			result = REWARDWARBUCKS.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{MAXLEVEL : " + MAXLEVEL + "} ";
		empty = empty + "{MAXMISSION : " + MAXMISSION + "} ";
		empty = empty + "{REWARDGOLD : " + REWARDGOLD + "} ";
		return empty + "{REWARDWARBUCKS : " + REWARDWARBUCKS + "} ";
	}
}
