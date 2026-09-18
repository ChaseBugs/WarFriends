using System;
using UnityEngine;

namespace Google2u
{
[Serializable]
public class AchievementsRow : IGoogle2uRow
{
	public int VALUE;

	public int REWARDWB;

	public int REWARDGOLD;

	public string ANDROIDID;

	public string ANDROIDIDCHILL;

	public int Get_VALUE
	{
		get
		{
			return VALUE;
		}
		set
		{
			VALUE = value;
		}
	}

	public int Get_REWARDWB
	{
		get
		{
			return REWARDWB;
		}
		set
		{
			REWARDWB = value;
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

	public string Get_ANDROIDID
	{
		get
		{
			return ANDROIDID;
		}
		set
		{
			ANDROIDID = value;
		}
	}

	public string Get_ANDROIDIDCHILL
	{
		get
		{
			return ANDROIDIDCHILL;
		}
		set
		{
			ANDROIDIDCHILL = value;
		}
	}

	public int Length => 5;

	public string this[int i] => GetStringDataByIndex(i);

	public AchievementsRow()
	{
	}

	public AchievementsRow(string _ID, string _VALUE, string _REWARDWB, string _REWARDGOLD, string _ANDROIDID, string _ANDROIDIDCHILL)
	{
		if (int.TryParse(_VALUE, out var result))
		{
			VALUE = result;
		}
		else
		{
			Debug.LogError("Failed To Convert VALUE string: " + _VALUE + " to int");
		}
		if (int.TryParse(_REWARDWB, out var result2))
		{
			REWARDWB = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert REWARDWB string: " + _REWARDWB + " to int");
		}
		if (int.TryParse(_REWARDGOLD, out var result3))
		{
			REWARDGOLD = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert REWARDGOLD string: " + _REWARDGOLD + " to int");
		}
		ANDROIDID = _ANDROIDID.Trim();
		ANDROIDIDCHILL = _ANDROIDIDCHILL.Trim();
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = VALUE.ToString();
			break;
		case 1:
			result = REWARDWB.ToString();
			break;
		case 2:
			result = REWARDGOLD.ToString();
			break;
		case 3:
			result = ANDROIDID.ToString();
			break;
		case 4:
			result = ANDROIDIDCHILL.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "VALUE":
			result = VALUE.ToString();
			break;
		case "REWARDWB":
			result = REWARDWB.ToString();
			break;
		case "REWARDGOLD":
			result = REWARDGOLD.ToString();
			break;
		case "ANDROIDID":
			result = ANDROIDID.ToString();
			break;
		case "ANDROIDIDCHILL":
			result = ANDROIDIDCHILL.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{VALUE : " + VALUE + "} ";
		empty = empty + "{REWARDWB : " + REWARDWB + "} ";
		empty = empty + "{REWARDGOLD : " + REWARDGOLD + "} ";
		empty = empty + "{ANDROIDID : " + ANDROIDID.ToString() + "} ";
		return empty + "{ANDROIDIDCHILL : " + ANDROIDIDCHILL.ToString() + "} ";
	}
}
}
