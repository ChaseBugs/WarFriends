using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u;

[Serializable]
public class DBUpgradeSlotsEngineerRow : IGoogle2uRow
{
	public int TIER;

	public ObscuredFloat HP;

	public ObscuredFloat DAMAGE;

	public int TURRET;

	public int BATCHSIZEMIN;

	public int BATCHSIZEMAX;

	public float SHOTFREQUENCYMIN;

	public float SHOTFREQUENCYMAX;

	public ObscuredFloat REALSHOTPROBABILITY;

	public ObscuredInt NEXTUPGRADEPRICE;

	public int NEXTUPGRADEPRICEGOLD;

	public ObscuredFloat DELIVERYTIME;

	public float DPS;

	public float ARMYPOWER;

	public ObscuredFloat SPECIAL;

	public ObscuredFloat ELITE;

	public int Get_TIER
	{
		get
		{
			return TIER;
		}
		set
		{
			TIER = value;
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

	public int Get_TURRET
	{
		get
		{
			return TURRET;
		}
		set
		{
			TURRET = value;
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

	public ObscuredInt Get_NEXTUPGRADEPRICE
	{
		get
		{
			return NEXTUPGRADEPRICE;
		}
		set
		{
			NEXTUPGRADEPRICE = value;
		}
	}

	public int Get_NEXTUPGRADEPRICEGOLD
	{
		get
		{
			return NEXTUPGRADEPRICEGOLD;
		}
		set
		{
			NEXTUPGRADEPRICEGOLD = value;
		}
	}

	public ObscuredFloat Get_DELIVERYTIME
	{
		get
		{
			return DELIVERYTIME;
		}
		set
		{
			DELIVERYTIME = value;
		}
	}

	public float Get_DPS
	{
		get
		{
			return DPS;
		}
		set
		{
			DPS = value;
		}
	}

	public float Get_ARMYPOWER
	{
		get
		{
			return ARMYPOWER;
		}
		set
		{
			ARMYPOWER = value;
		}
	}

	public ObscuredFloat Get_SPECIAL
	{
		get
		{
			return SPECIAL;
		}
		set
		{
			SPECIAL = value;
		}
	}

	public ObscuredFloat Get_ELITE
	{
		get
		{
			return ELITE;
		}
		set
		{
			ELITE = value;
		}
	}

	public int Length => 16;

	public string this[int i] => GetStringDataByIndex(i);

	public DBUpgradeSlotsEngineerRow()
	{
	}

	public DBUpgradeSlotsEngineerRow(string _GOOGLEFU_ID, string _TIER, string _HP, string _DAMAGE, string _TURRET, string _BATCHSIZEMIN, string _BATCHSIZEMAX, string _SHOTFREQUENCYMIN, string _SHOTFREQUENCYMAX, string _REALSHOTPROBABILITY, string _NEXTUPGRADEPRICE, string _NEXTUPGRADEPRICEGOLD, string _DELIVERYTIME, string _DPS, string _ARMYPOWER, string _SPECIAL, string _ELITE)
	{
		if (int.TryParse(_TIER, out var result))
		{
			TIER = result;
		}
		else
		{
			Debug.LogError("Failed To Convert TIER string: " + _TIER + " to int");
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
		if (int.TryParse(_TURRET, out var result4))
		{
			TURRET = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert TURRET string: " + _TURRET + " to int");
		}
		if (int.TryParse(_BATCHSIZEMIN, out var result5))
		{
			BATCHSIZEMIN = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert BATCHSIZEMIN string: " + _BATCHSIZEMIN + " to int");
		}
		if (int.TryParse(_BATCHSIZEMAX, out var result6))
		{
			BATCHSIZEMAX = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert BATCHSIZEMAX string: " + _BATCHSIZEMAX + " to int");
		}
		if (float.TryParse(_SHOTFREQUENCYMIN, out var result7))
		{
			SHOTFREQUENCYMIN = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOTFREQUENCYMIN string: " + _SHOTFREQUENCYMIN + " to float");
		}
		if (float.TryParse(_SHOTFREQUENCYMAX, out var result8))
		{
			SHOTFREQUENCYMAX = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOTFREQUENCYMAX string: " + _SHOTFREQUENCYMAX + " to float");
		}
		if (float.TryParse(_REALSHOTPROBABILITY, out var result9))
		{
			REALSHOTPROBABILITY = result9;
		}
		else
		{
			Debug.LogError("Failed To Convert REALSHOTPROBABILITY string: " + _REALSHOTPROBABILITY + " to float");
		}
		if (int.TryParse(_NEXTUPGRADEPRICE, out var result10))
		{
			NEXTUPGRADEPRICE = result10;
		}
		else
		{
			Debug.LogError("Failed To Convert NEXTUPGRADEPRICE string: " + _NEXTUPGRADEPRICE + " to float");
		}
		if (int.TryParse(_NEXTUPGRADEPRICEGOLD, out var result11))
		{
			NEXTUPGRADEPRICEGOLD = result11;
		}
		else
		{
			Debug.LogError("Failed To Convert NEXTUPGRADEPRICEGOLD string: " + _NEXTUPGRADEPRICEGOLD + " to int");
		}
		if (float.TryParse(_DELIVERYTIME, out var result12))
		{
			DELIVERYTIME = result12;
		}
		else
		{
			Debug.LogError("Failed To Convert DELIVERYTIME string: " + _DELIVERYTIME + " to float");
		}
		if (float.TryParse(_DPS, out var result13))
		{
			DPS = result13;
		}
		else
		{
			Debug.LogError("Failed To Convert DPS string: " + _DPS + " to float");
		}
		if (float.TryParse(_ARMYPOWER, out var result14))
		{
			ARMYPOWER = result14;
		}
		else
		{
			Debug.LogError("Failed To Convert ARMYPOWER string: " + _ARMYPOWER + " to float");
		}
		if (float.TryParse(_SPECIAL, out var result15))
		{
			SPECIAL = result15;
		}
		else
		{
			Debug.LogError("Failed To Convert SPECIAL string: " + _SPECIAL + " to float");
		}
		if (float.TryParse(_ELITE, out var result16))
		{
			ELITE = result16;
		}
		else
		{
			Debug.LogError("Failed To Convert ELITE string: " + _ELITE + " to float");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = TIER.ToString();
			break;
		case 1:
			result = HP.ToString();
			break;
		case 2:
			result = DAMAGE.ToString();
			break;
		case 3:
			result = TURRET.ToString();
			break;
		case 4:
			result = BATCHSIZEMIN.ToString();
			break;
		case 5:
			result = BATCHSIZEMAX.ToString();
			break;
		case 6:
			result = SHOTFREQUENCYMIN.ToString();
			break;
		case 7:
			result = SHOTFREQUENCYMAX.ToString();
			break;
		case 8:
			result = REALSHOTPROBABILITY.ToString();
			break;
		case 9:
			result = NEXTUPGRADEPRICE.ToString();
			break;
		case 10:
			result = NEXTUPGRADEPRICEGOLD.ToString();
			break;
		case 11:
			result = DELIVERYTIME.ToString();
			break;
		case 12:
			result = DPS.ToString();
			break;
		case 13:
			result = ARMYPOWER.ToString();
			break;
		case 14:
			result = SPECIAL.ToString();
			break;
		case 15:
			result = ELITE.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "TIER":
			result = TIER.ToString();
			break;
		case "HP":
			result = HP.ToString();
			break;
		case "DAMAGE":
			result = DAMAGE.ToString();
			break;
		case "TURRET":
			result = TURRET.ToString();
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
		case "NEXTUPGRADEPRICE":
			result = NEXTUPGRADEPRICE.ToString();
			break;
		case "NEXTUPGRADEPRICEGOLD":
			result = NEXTUPGRADEPRICEGOLD.ToString();
			break;
		case "DELIVERYTIME":
			result = DELIVERYTIME.ToString();
			break;
		case "DPS":
			result = DPS.ToString();
			break;
		case "ARMYPOWER":
			result = ARMYPOWER.ToString();
			break;
		case "SPECIAL":
			result = SPECIAL.ToString();
			break;
		case "ELITE":
			result = ELITE.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{TIER : " + TIER + "} ";
		empty = empty + "{HP : " + HP.ToString() + "} ";
		empty = empty + "{DAMAGE : " + DAMAGE.ToString() + "} ";
		empty = empty + "{TURRET : " + TURRET + "} ";
		empty = empty + "{BATCHSIZEMIN : " + BATCHSIZEMIN + "} ";
		empty = empty + "{BATCHSIZEMAX : " + BATCHSIZEMAX + "} ";
		empty = empty + "{SHOTFREQUENCYMIN : " + SHOTFREQUENCYMIN + "} ";
		empty = empty + "{SHOTFREQUENCYMAX : " + SHOTFREQUENCYMAX + "} ";
		empty = empty + "{REALSHOTPROBABILITY : " + REALSHOTPROBABILITY.ToString() + "} ";
		empty = empty + "{NEXTUPGRADEPRICE : " + NEXTUPGRADEPRICE.ToString() + "} ";
		empty = empty + "{NEXTUPGRADEPRICEGOLD : " + NEXTUPGRADEPRICEGOLD + "} ";
		empty = empty + "{DELIVERYTIME : " + DELIVERYTIME.ToString() + "} ";
		empty = empty + "{DPS : " + DPS + "} ";
		empty = empty + "{ARMYPOWER : " + ARMYPOWER + "} ";
		empty = empty + "{SPECIAL : " + SPECIAL.ToString() + "} ";
		return empty + "{ELITE : " + ELITE.ToString() + "} ";
	}
}
