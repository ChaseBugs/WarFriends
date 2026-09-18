using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u;

[Serializable]
public class DBUpgradeSlotsTurretRow : IGoogle2uRow
{
	public int TYPE;

	public ObscuredFloat HP;

	public ObscuredFloat DAMAGE;

	public int BATCHSIZEMIN;

	public int BATCHSIZEMAX;

	public float SHOTFREQUENCYMIN;

	public float SHOTFREQUENCYMAX;

	public ObscuredFloat REALSHOTPROBABILITY;

	public int Get_TYPE
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

	public ObscuredFloat Get_HP
	{
		get
		{
			return HP;
		}
		set
		{
			HP = value;
		}
	}

	public ObscuredFloat Get_DAMAGE
	{
		get
		{
			return DAMAGE;
		}
		set
		{
			DAMAGE = value;
		}
	}

	public int Get_BATCHSIZEMIN
	{
		get
		{
			return BATCHSIZEMIN;
		}
		set
		{
			BATCHSIZEMIN = value;
		}
	}

	public int Get_BATCHSIZEMAX
	{
		get
		{
			return BATCHSIZEMAX;
		}
		set
		{
			BATCHSIZEMAX = value;
		}
	}

	public float Get_SHOTFREQUENCYMIN
	{
		get
		{
			return SHOTFREQUENCYMIN;
		}
		set
		{
			SHOTFREQUENCYMIN = value;
		}
	}

	public float Get_SHOTFREQUENCYMAX
	{
		get
		{
			return SHOTFREQUENCYMAX;
		}
		set
		{
			SHOTFREQUENCYMAX = value;
		}
	}

	public ObscuredFloat Get_REALSHOTPROBABILITY
	{
		get
		{
			return REALSHOTPROBABILITY;
		}
		set
		{
			REALSHOTPROBABILITY = value;
		}
	}

	public int Length => 8;

	public string this[int i] => GetStringDataByIndex(i);

	public DBUpgradeSlotsTurretRow()
	{
	}

	public DBUpgradeSlotsTurretRow(string _GOOGLEFU_ID, string _TYPE, string _HP, string _DAMAGE, string _BATCHSIZEMIN, string _BATCHSIZEMAX, string _SHOTFREQUENCYMIN, string _SHOTFREQUENCYMAX, string _REALSHOTPROBABILITY)
	{
		if (int.TryParse(_TYPE, out var result))
		{
			TYPE = result;
		}
		else
		{
			Debug.LogError("Failed To Convert TYPE string: " + _TYPE + " to int");
		}
		if (float.TryParse(_HP, out var result2))
		{
			HP = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert HP string: " + _HP + " to float");
		}
		if (float.TryParse(_DAMAGE, out var result3))
		{
			DAMAGE = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert DAMAGE string: " + _DAMAGE + " to float");
		}
		if (int.TryParse(_BATCHSIZEMIN, out var result4))
		{
			BATCHSIZEMIN = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert BATCHSIZEMIN string: " + _BATCHSIZEMIN + " to int");
		}
		if (int.TryParse(_BATCHSIZEMAX, out var result5))
		{
			BATCHSIZEMAX = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert BATCHSIZEMAX string: " + _BATCHSIZEMAX + " to int");
		}
		if (float.TryParse(_SHOTFREQUENCYMIN, out var result6))
		{
			SHOTFREQUENCYMIN = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOTFREQUENCYMIN string: " + _SHOTFREQUENCYMIN + " to float");
		}
		if (float.TryParse(_SHOTFREQUENCYMAX, out var result7))
		{
			SHOTFREQUENCYMAX = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOTFREQUENCYMAX string: " + _SHOTFREQUENCYMAX + " to float");
		}
		if (float.TryParse(_REALSHOTPROBABILITY, out var result8))
		{
			REALSHOTPROBABILITY = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert REALSHOTPROBABILITY string: " + _REALSHOTPROBABILITY + " to float");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = TYPE.ToString();
			break;
		case 1:
			result = HP.ToString();
			break;
		case 2:
			result = DAMAGE.ToString();
			break;
		case 3:
			result = BATCHSIZEMIN.ToString();
			break;
		case 4:
			result = BATCHSIZEMAX.ToString();
			break;
		case 5:
			result = SHOTFREQUENCYMIN.ToString();
			break;
		case 6:
			result = SHOTFREQUENCYMAX.ToString();
			break;
		case 7:
			result = REALSHOTPROBABILITY.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "TYPE":
			result = TYPE.ToString();
			break;
		case "HP":
			result = HP.ToString();
			break;
		case "DAMAGE":
			result = DAMAGE.ToString();
			break;
		case "BATCHSIZEMIN":
			result = BATCHSIZEMIN.ToString();
			break;
		case "BATCHSIZEMAX":
			result = BATCHSIZEMAX.ToString();
			break;
		case "SHOTFREQUENCYMIN":
			result = SHOTFREQUENCYMIN.ToString();
			break;
		case "SHOTFREQUENCYMAX":
			result = SHOTFREQUENCYMAX.ToString();
			break;
		case "REALSHOTPROBABILITY":
			result = REALSHOTPROBABILITY.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{TYPE : " + TYPE + "} ";
		empty = empty + "{HP : " + HP.ToString() + "} ";
		empty = empty + "{DAMAGE : " + DAMAGE.ToString() + "} ";
		empty = empty + "{BATCHSIZEMIN : " + BATCHSIZEMIN + "} ";
		empty = empty + "{BATCHSIZEMAX : " + BATCHSIZEMAX + "} ";
		empty = empty + "{SHOTFREQUENCYMIN : " + SHOTFREQUENCYMIN + "} ";
		empty = empty + "{SHOTFREQUENCYMAX : " + SHOTFREQUENCYMAX + "} ";
		return empty + "{REALSHOTPROBABILITY : " + REALSHOTPROBABILITY.ToString() + "} ";
	}
}
