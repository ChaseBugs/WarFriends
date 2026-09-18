using System;
using UnityEngine;

namespace Google2u
{
[Serializable]
public class UnitsContantsRow : IGoogle2uRow
{
	public float FLOATVALUE;

	public float Get_FLOATVALUE
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

	public int Length => 1;

	public string this[int i] => GetStringDataByIndex(i);

	public UnitsContantsRow()
	{
	}

	public UnitsContantsRow(string _NAME, string _FLOATVALUE)
	{
		if (float.TryParse(_FLOATVALUE, out var result))
		{
			FLOATVALUE = result;
		}
		else
		{
			Debug.LogError("Failed To Convert FLOATVALUE string: " + _FLOATVALUE + " to float");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		if (index == 0)
		{
			result = FLOATVALUE.ToString();
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
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		return empty + "{FLOATVALUE : " + FLOATVALUE + "} ";
	}
}
}
