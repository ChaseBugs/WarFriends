using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
[Serializable]
public class BalanceTableRow : IGoogle2uRow
{
	public ObscuredFloat PLAYERHP;

	public ObscuredFloat SHIELDHP;

	public ObscuredFloat Get_PLAYERHP
	{
		get
		{
			return PLAYERHP;
		}
		set
		{
			PLAYERHP = value;
		}
	}

	public ObscuredFloat Get_SHIELDHP
	{
		get
		{
			return SHIELDHP;
		}
		set
		{
			SHIELDHP = value;
		}
	}

	public int Length => 2;

	public string this[int i] => GetStringDataByIndex(i);

	public BalanceTableRow()
	{
	}

	public BalanceTableRow(string _GOOGLEFU_ID, string _PLAYERHP, string _SHIELDHP)
	{
		if (float.TryParse(_PLAYERHP, out var result))
		{
			PLAYERHP = result;
		}
		else
		{
			Debug.LogError("Failed To Convert PLAYERHP string: " + _PLAYERHP + " to float");
		}
		if (float.TryParse(_SHIELDHP, out var result2))
		{
			SHIELDHP = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert SHIELDHP string: " + _SHIELDHP + " to float");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = PLAYERHP.ToString();
			break;
		case 1:
			result = SHIELDHP.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "PLAYERHP":
			result = PLAYERHP.ToString();
			break;
		case "SHIELDHP":
			result = SHIELDHP.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{PLAYERHP : " + PLAYERHP.ToString() + "} ";
		return empty + "{SHIELDHP : " + SHIELDHP.ToString() + "} ";
	}
}
}
