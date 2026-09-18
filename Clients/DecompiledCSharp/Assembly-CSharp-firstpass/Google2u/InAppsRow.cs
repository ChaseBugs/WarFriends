using System;
using UnityEngine;

namespace Google2u;

[Serializable]
public class InAppsRow : IGoogle2uRow
{
	public string NAME;

	public int AMOUNT;

	public float PRICE;

	public bool CONSUMABLE;

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

	public int Get_AMOUNT
	{
		get
		{
			return AMOUNT;
		}
		set
		{
			AMOUNT = value;
		}
	}

	public float Get_PRICE
	{
		get
		{
			return PRICE;
		}
		set
		{
			PRICE = value;
		}
	}

	public bool Get_CONSUMABLE
	{
		get
		{
			return CONSUMABLE;
		}
		set
		{
			CONSUMABLE = value;
		}
	}

	public int Length => 4;

	public string this[int i] => GetStringDataByIndex(i);

	public InAppsRow()
	{
	}

	public InAppsRow(string _ID, string _NAME, string _AMOUNT, string _PRICE, string _CONSUMABLE)
	{
		NAME = _NAME.Trim();
		if (int.TryParse(_AMOUNT, out var result))
		{
			AMOUNT = result;
		}
		else
		{
			Debug.LogError("Failed To Convert AMOUNT string: " + _AMOUNT + " to int");
		}
		if (float.TryParse(_PRICE, out var result2))
		{
			PRICE = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert PRICE string: " + _PRICE + " to float");
		}
		if (bool.TryParse(_CONSUMABLE, out var result3))
		{
			CONSUMABLE = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert CONSUMABLE string: " + _CONSUMABLE + " to bool");
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
			result = AMOUNT.ToString();
			break;
		case 2:
			result = PRICE.ToString();
			break;
		case 3:
			result = CONSUMABLE.ToString();
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
		case "AMOUNT":
			result = AMOUNT.ToString();
			break;
		case "PRICE":
			result = PRICE.ToString();
			break;
		case "CONSUMABLE":
			result = CONSUMABLE.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{NAME : " + NAME.ToString() + "} ";
		empty = empty + "{AMOUNT : " + AMOUNT + "} ";
		empty = empty + "{PRICE : " + PRICE + "} ";
		return empty + "{CONSUMABLE : " + CONSUMABLE + "} ";
	}
}
