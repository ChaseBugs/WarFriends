using System;
using UnityEngine;

namespace Google2u
{
[Serializable]
public class SquadEmblemsRow : IGoogle2uRow
{
	public string ICONNAME;

	public int UNLOCKLEVEL;

	public string TYPE;

	public string Get_ICONNAME
	{
		get
		{
			return ICONNAME;
		}
		set
		{
			ICONNAME = value;
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

	public string Get_TYPE
	{
		get
		{
			return TYPE;
		}
		set
		{
			TYPE = value;
		}
	}

	public int Length => 3;

	public string this[int i] => GetStringDataByIndex(i);

	public SquadEmblemsRow()
	{
	}

	public SquadEmblemsRow(string _ID, string _ICONNAME, string _UNLOCKLEVEL, string _TYPE)
	{
		ICONNAME = _ICONNAME.Trim();
		if (int.TryParse(_UNLOCKLEVEL, out var result))
		{
			UNLOCKLEVEL = result;
		}
		else
		{
			Debug.LogError("Failed To Convert UNLOCKLEVEL string: " + _UNLOCKLEVEL + " to int");
		}
		TYPE = _TYPE.Trim();
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = ICONNAME.ToString();
			break;
		case 1:
			result = UNLOCKLEVEL.ToString();
			break;
		case 2:
			result = TYPE.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "ICONNAME":
			result = ICONNAME.ToString();
			break;
		case "UNLOCKLEVEL":
			result = UNLOCKLEVEL.ToString();
			break;
		case "TYPE":
			result = TYPE.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{ICONNAME : " + ICONNAME.ToString() + "} ";
		empty = empty + "{UNLOCKLEVEL : " + UNLOCKLEVEL + "} ";
		return empty + "{TYPE : " + TYPE.ToString() + "} ";
	}
}
}
