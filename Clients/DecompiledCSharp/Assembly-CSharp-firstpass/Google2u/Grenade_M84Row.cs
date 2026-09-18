using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u;

[Serializable]
public class Grenade_M84Row : IGoogle2uRow
{
	public ObscuredFloat RELOADTIME;

	public ObscuredInt AMMO;

	public ObscuredFloat MINDAMAGE;

	public ObscuredFloat EXPLODEDAMAGE;

	public ObscuredInt NEXTUPGRADEPRICE;

	public int NEXTUPGRADEPRICEGOLD;

	public ObscuredFloat DELIVERYTIME;

	public float DPS;

	public float ATTACK;

	public ObscuredFloat Get_RELOADTIME
	{
		get
		{
			return RELOADTIME;
		}
		set
		{
			RELOADTIME = value;
		}
	}

	public ObscuredInt Get_AMMO
	{
		get
		{
			return AMMO;
		}
		set
		{
			AMMO = value;
		}
	}

	public ObscuredFloat Get_MINDAMAGE
	{
		get
		{
			return MINDAMAGE;
		}
		set
		{
			MINDAMAGE = value;
		}
	}

	public ObscuredFloat Get_EXPLODEDAMAGE
	{
		get
		{
			return EXPLODEDAMAGE;
		}
		set
		{
			EXPLODEDAMAGE = value;
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

	public float Get_ATTACK
	{
		get
		{
			return ATTACK;
		}
		set
		{
			ATTACK = value;
		}
	}

	public int Length => 9;

	public string this[int i] => GetStringDataByIndex(i);

	public Grenade_M84Row()
	{
	}

	public Grenade_M84Row(string _GOOGLEFU_ID, string _RELOADTIME, string _AMMO, string _MINDAMAGE, string _EXPLODEDAMAGE, string _NEXTUPGRADEPRICE, string _NEXTUPGRADEPRICEGOLD, string _DELIVERYTIME, string _DPS, string _ATTACK)
	{
		if (float.TryParse(_RELOADTIME, out var result))
		{
			RELOADTIME = result;
		}
		else
		{
			Debug.LogError("Failed To Convert RELOADTIME string: " + _RELOADTIME + " to float");
		}
		if (int.TryParse(_AMMO, out var result2))
		{
			AMMO = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert AMMO string: " + _AMMO + " to float");
		}
		if (float.TryParse(_MINDAMAGE, out var result3))
		{
			MINDAMAGE = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert MINDAMAGE string: " + _MINDAMAGE + " to float");
		}
		if (float.TryParse(_EXPLODEDAMAGE, out var result4))
		{
			EXPLODEDAMAGE = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert EXPLODEDAMAGE string: " + _EXPLODEDAMAGE + " to float");
		}
		if (int.TryParse(_NEXTUPGRADEPRICE, out var result5))
		{
			NEXTUPGRADEPRICE = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert NEXTUPGRADEPRICE string: " + _NEXTUPGRADEPRICE + " to float");
		}
		if (int.TryParse(_NEXTUPGRADEPRICEGOLD, out var result6))
		{
			NEXTUPGRADEPRICEGOLD = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert NEXTUPGRADEPRICEGOLD string: " + _NEXTUPGRADEPRICEGOLD + " to int");
		}
		if (float.TryParse(_DELIVERYTIME, out var result7))
		{
			DELIVERYTIME = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert DELIVERYTIME string: " + _DELIVERYTIME + " to float");
		}
		if (float.TryParse(_DPS, out var result8))
		{
			DPS = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert DPS string: " + _DPS + " to float");
		}
		if (float.TryParse(_ATTACK, out var result9))
		{
			ATTACK = result9;
		}
		else
		{
			Debug.LogError("Failed To Convert ATTACK string: " + _ATTACK + " to float");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = RELOADTIME.ToString();
			break;
		case 1:
			result = AMMO.ToString();
			break;
		case 2:
			result = MINDAMAGE.ToString();
			break;
		case 3:
			result = EXPLODEDAMAGE.ToString();
			break;
		case 4:
			result = NEXTUPGRADEPRICE.ToString();
			break;
		case 5:
			result = NEXTUPGRADEPRICEGOLD.ToString();
			break;
		case 6:
			result = DELIVERYTIME.ToString();
			break;
		case 7:
			result = DPS.ToString();
			break;
		case 8:
			result = ATTACK.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "RELOADTIME":
			result = RELOADTIME.ToString();
			break;
		case "AMMO":
			result = AMMO.ToString();
			break;
		case "MINDAMAGE":
			result = MINDAMAGE.ToString();
			break;
		case "EXPLODEDAMAGE":
			result = EXPLODEDAMAGE.ToString();
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
		case "ATTACK":
			result = ATTACK.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{RELOADTIME : " + RELOADTIME.ToString() + "} ";
		empty = empty + "{AMMO : " + AMMO.ToString() + "} ";
		empty = empty + "{MINDAMAGE : " + MINDAMAGE.ToString() + "} ";
		empty = empty + "{EXPLODEDAMAGE : " + EXPLODEDAMAGE.ToString() + "} ";
		empty = empty + "{NEXTUPGRADEPRICE : " + NEXTUPGRADEPRICE.ToString() + "} ";
		empty = empty + "{NEXTUPGRADEPRICEGOLD : " + NEXTUPGRADEPRICEGOLD + "} ";
		empty = empty + "{DELIVERYTIME : " + DELIVERYTIME.ToString() + "} ";
		empty = empty + "{DPS : " + DPS + "} ";
		return empty + "{ATTACK : " + ATTACK + "} ";
	}
}
