using System;
using UnityEngine;

namespace Google2u;

[Serializable]
public class CardPacksRow : IGoogle2uRow
{
	public string NAME;

	public int GOLD;

	public int WARBUCKS;

	public string Get_NAME
	{
		get
		{
			return NAME;
		}
		set
		{
			NAME = value;
		}
	}

	public int Get_GOLD
	{
		get
		{
			return GOLD;
		}
		set
		{
			GOLD = value;
		}
	}

	public int Get_WARBUCKS
	{
		get
		{
			return WARBUCKS;
		}
		set
		{
			WARBUCKS = value;
		}
	}

	public int Length => 3;

	public string this[int i] => GetStringDataByIndex(i);

	public CardPacksRow()
	{
	}

	public CardPacksRow(string _ID, string _NAME, string _GOLD, string _WARBUCKS)
	{
		NAME = _NAME.Trim();
		if (int.TryParse(_GOLD, out var result))
		{
			GOLD = result;
		}
		else
		{
			Debug.LogError("Failed To Convert GOLD string: " + _GOLD + " to int");
		}
		if (int.TryParse(_WARBUCKS, out var result2))
		{
			WARBUCKS = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert WARBUCKS string: " + _WARBUCKS + " to int");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = NAME.ToString();
			break;
		case 1:
			result = GOLD.ToString();
			break;
		case 2:
			result = WARBUCKS.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "NAME":
			result = NAME.ToString();
			break;
		case "GOLD":
			result = GOLD.ToString();
			break;
		case "WARBUCKS":
			result = WARBUCKS.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{NAME : " + NAME.ToString() + "} ";
		empty = empty + "{GOLD : " + GOLD + "} ";
		return empty + "{WARBUCKS : " + WARBUCKS + "} ";
	}
}
