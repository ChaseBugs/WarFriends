using System;
using UnityEngine;

namespace Google2u;

[Serializable]
public class PlayerVisualsRow : IGoogle2uRow
{
	public string NAME;

	public int UNLOCKLEVEL;

	public int PRICEWARBUCKS;

	public int PRICEGOLD;

	public int TIME;

	public int DECALTYPE;

	public float DECALVALUE;

	public int CATEGORYID;

	public bool ONLYFORVIP;

	public string PURCHASABLE;

	public int CATEGORY;

	public int PARTS;

	public int DUPLICATEWARBUCKS;

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

	public int Get_UNLOCKLEVEL
	{
		get
		{
			return UNLOCKLEVEL;
		}
		set
		{
			UNLOCKLEVEL = value;
		}
	}

	public int Get_PRICEWARBUCKS
	{
		get
		{
			return PRICEWARBUCKS;
		}
		set
		{
			PRICEWARBUCKS = value;
		}
	}

	public int Get_PRICEGOLD
	{
		get
		{
			return PRICEGOLD;
		}
		set
		{
			PRICEGOLD = value;
		}
	}

	public int Get_TIME
	{
		get
		{
			return TIME;
		}
		set
		{
			TIME = value;
		}
	}

	public int Get_DECALTYPE
	{
		get
		{
			return DECALTYPE;
		}
		set
		{
			DECALTYPE = value;
		}
	}

	public float Get_DECALVALUE
	{
		get
		{
			return DECALVALUE;
		}
		set
		{
			DECALVALUE = value;
		}
	}

	public int Get_CATEGORYID
	{
		get
		{
			return CATEGORYID;
		}
		set
		{
			CATEGORYID = value;
		}
	}

	public bool Get_ONLYFORVIP
	{
		get
		{
			return ONLYFORVIP;
		}
		set
		{
			ONLYFORVIP = value;
		}
	}

	public string Get_PURCHASABLE
	{
		get
		{
			return PURCHASABLE;
		}
		set
		{
			PURCHASABLE = value;
		}
	}

	public int Get_CATEGORY
	{
		get
		{
			return CATEGORY;
		}
		set
		{
			CATEGORY = value;
		}
	}

	public int Get_PARTS
	{
		get
		{
			return PARTS;
		}
		set
		{
			PARTS = value;
		}
	}

	public int Get_DUPLICATEWARBUCKS
	{
		get
		{
			return DUPLICATEWARBUCKS;
		}
		set
		{
			DUPLICATEWARBUCKS = value;
		}
	}

	public int Length => 13;

	public string this[int i] => GetStringDataByIndex(i);

	public PlayerVisualsRow()
	{
	}

	public PlayerVisualsRow(string _ID, string _NAME, string _UNLOCKLEVEL, string _PRICEWARBUCKS, string _PRICEGOLD, string _TIME, string _DECALTYPE, string _DECALVALUE, string _CATEGORYID, string _ONLYFORVIP, string _PURCHASABLE, string _CATEGORY, string _PARTS, string _DUPLICATEWARBUCKS)
	{
		NAME = _NAME.Trim();
		if (int.TryParse(_UNLOCKLEVEL, out var result))
		{
			UNLOCKLEVEL = result;
		}
		else
		{
			Debug.LogError("Failed To Convert UNLOCKLEVEL string: " + _UNLOCKLEVEL + " to int");
		}
		if (int.TryParse(_PRICEWARBUCKS, out var result2))
		{
			PRICEWARBUCKS = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert PRICEWARBUCKS string: " + _PRICEWARBUCKS + " to int");
		}
		if (int.TryParse(_PRICEGOLD, out var result3))
		{
			PRICEGOLD = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert PRICEGOLD string: " + _PRICEGOLD + " to int");
		}
		if (int.TryParse(_TIME, out var result4))
		{
			TIME = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert TIME string: " + _TIME + " to int");
		}
		if (int.TryParse(_DECALTYPE, out var result5))
		{
			DECALTYPE = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert DECALTYPE string: " + _DECALTYPE + " to int");
		}
		if (float.TryParse(_DECALVALUE, out var result6))
		{
			DECALVALUE = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert DECALVALUE string: " + _DECALVALUE + " to float");
		}
		if (int.TryParse(_CATEGORYID, out var result7))
		{
			CATEGORYID = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert CATEGORYID string: " + _CATEGORYID + " to int");
		}
		if (bool.TryParse(_ONLYFORVIP, out var result8))
		{
			ONLYFORVIP = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert ONLYFORVIP string: " + _ONLYFORVIP + " to bool");
		}
		PURCHASABLE = _PURCHASABLE.Trim();
		if (int.TryParse(_CATEGORY, out var result9))
		{
			CATEGORY = result9;
		}
		else
		{
			Debug.LogError("Failed To Convert CATEGORY string: " + _CATEGORY + " to int");
		}
		if (int.TryParse(_PARTS, out var result10))
		{
			PARTS = result10;
		}
		else
		{
			Debug.LogError("Failed To Convert PARTS string: " + _PARTS + " to int");
		}
		if (int.TryParse(_DUPLICATEWARBUCKS, out var result11))
		{
			DUPLICATEWARBUCKS = result11;
		}
		else
		{
			Debug.LogError("Failed To Convert DUPLICATEWARBUCKS string: " + _DUPLICATEWARBUCKS + " to int");
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
			result = UNLOCKLEVEL.ToString();
			break;
		case 2:
			result = PRICEWARBUCKS.ToString();
			break;
		case 3:
			result = PRICEGOLD.ToString();
			break;
		case 4:
			result = TIME.ToString();
			break;
		case 5:
			result = DECALTYPE.ToString();
			break;
		case 6:
			result = DECALVALUE.ToString();
			break;
		case 7:
			result = CATEGORYID.ToString();
			break;
		case 8:
			result = ONLYFORVIP.ToString();
			break;
		case 9:
			result = PURCHASABLE.ToString();
			break;
		case 10:
			result = CATEGORY.ToString();
			break;
		case 11:
			result = PARTS.ToString();
			break;
		case 12:
			result = DUPLICATEWARBUCKS.ToString();
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
		case "UNLOCKLEVEL":
			result = UNLOCKLEVEL.ToString();
			break;
		case "PRICEWARBUCKS":
			result = PRICEWARBUCKS.ToString();
			break;
		case "PRICEGOLD":
			result = PRICEGOLD.ToString();
			break;
		case "TIME":
			result = TIME.ToString();
			break;
		case "DECALTYPE":
			result = DECALTYPE.ToString();
			break;
		case "DECALVALUE":
			result = DECALVALUE.ToString();
			break;
		case "CATEGORYID":
			result = CATEGORYID.ToString();
			break;
		case "ONLYFORVIP":
			result = ONLYFORVIP.ToString();
			break;
		case "PURCHASABLE":
			result = PURCHASABLE.ToString();
			break;
		case "CATEGORY":
			result = CATEGORY.ToString();
			break;
		case "PARTS":
			result = PARTS.ToString();
			break;
		case "DUPLICATEWARBUCKS":
			result = DUPLICATEWARBUCKS.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{NAME : " + NAME.ToString() + "} ";
		empty = empty + "{UNLOCKLEVEL : " + UNLOCKLEVEL + "} ";
		empty = empty + "{PRICEWARBUCKS : " + PRICEWARBUCKS + "} ";
		empty = empty + "{PRICEGOLD : " + PRICEGOLD + "} ";
		empty = empty + "{TIME : " + TIME + "} ";
		empty = empty + "{DECALTYPE : " + DECALTYPE + "} ";
		empty = empty + "{DECALVALUE : " + DECALVALUE + "} ";
		empty = empty + "{CATEGORYID : " + CATEGORYID + "} ";
		empty = empty + "{ONLYFORVIP : " + ONLYFORVIP + "} ";
		empty = empty + "{PURCHASABLE : " + PURCHASABLE.ToString() + "} ";
		empty = empty + "{CATEGORY : " + CATEGORY + "} ";
		empty = empty + "{PARTS : " + PARTS + "} ";
		return empty + "{DUPLICATEWARBUCKS : " + DUPLICATEWARBUCKS + "} ";
	}
}
