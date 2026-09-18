using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
[Serializable]
public class ConstantsRow : IGoogle2uRow
{
	public ObscuredFloat FLOATVALUE;

	public string DBKEY;

	public ObscuredFloat Get_FLOATVALUE
	{
		get
		{
			return FLOATVALUE;
		}
		set
		{
			FLOATVALUE = value;
		}
	}

	public string Get_DBKEY
	{
		get
		{
			return DBKEY;
		}
		set
		{
			DBKEY = value;
		}
	}

	public int Length => 2;

	public string this[int i] => GetStringDataByIndex(i);

	public ConstantsRow()
	{
	}

	public ConstantsRow(string _NAME, string _FLOATVALUE, string _DBKEY)
	{
		if (float.TryParse(_FLOATVALUE, out var result))
		{
			FLOATVALUE = result;
		}
		else
		{
			Debug.LogError("Failed To Convert FLOATVALUE string: " + _FLOATVALUE + " to float");
		}
		DBKEY = _DBKEY.Trim();
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = FLOATVALUE.ToString();
			break;
		case 1:
			result = DBKEY.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "FLOATVALUE":
			result = FLOATVALUE.ToString();
			break;
		case "DBKEY":
			result = DBKEY.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{FLOATVALUE : " + FLOATVALUE.ToString() + "} ";
		return empty + "{DBKEY : " + DBKEY.ToString() + "} ";
	}
}
}
