using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u;

[Serializable]
public class WeaponUpgradesRow : IGoogle2uRow
{
	public string NAME;

	public int UNLOCKLEVEL;

	public int CANBEBOUGHT;

	public ObscuredInt PRICE;

	public ObscuredInt PRICEGOLD;

	public int NSLOTS;

	public ObscuredFloat RATEOFFIRE;

	public ObscuredFloat CRITICAL;

	public int BURSTSIZE;

	public float BURSTLOCKTIME;

	public ObscuredFloat ACCURACY;

	public int DELIVERTIME;

	public string PURCHASABLE;

	public int WEAPONCATEGORY;

	public ObscuredFloat SPEED;

	public ObscuredFloat DAMAGETOPLAYER;

	public ObscuredFloat DAMAGETOPLAYEROVERTIME;

	public ObscuredFloat DAMAGETOPLAYERBEHINDSHIELD;

	public ObscuredFloat DAMAGETOSHIELD;

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

	public int Get_CANBEBOUGHT
	{
		get
		{
			return CANBEBOUGHT;
		}
		set
		{
			CANBEBOUGHT = value;
		}
	}

	public ObscuredInt Get_PRICE
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

	public ObscuredInt Get_PRICEGOLD
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

	public int Get_NSLOTS
	{
		get
		{
			return NSLOTS;
		}
		set
		{
			NSLOTS = value;
		}
	}

	public ObscuredFloat Get_RATEOFFIRE
	{
		get
		{
			return RATEOFFIRE;
		}
		set
		{
			RATEOFFIRE = value;
		}
	}

	public ObscuredFloat Get_CRITICAL
	{
		get
		{
			return CRITICAL;
		}
		set
		{
			CRITICAL = value;
		}
	}

	public int Get_BURSTSIZE
	{
		get
		{
			return BURSTSIZE;
		}
		set
		{
			BURSTSIZE = value;
		}
	}

	public float Get_BURSTLOCKTIME
	{
		get
		{
			return BURSTLOCKTIME;
		}
		set
		{
			BURSTLOCKTIME = value;
		}
	}

	public ObscuredFloat Get_ACCURACY
	{
		get
		{
			return ACCURACY;
		}
		set
		{
			ACCURACY = value;
		}
	}

	public int Get_DELIVERTIME
	{
		get
		{
			return DELIVERTIME;
		}
		set
		{
			DELIVERTIME = value;
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

	public int Get_WEAPONCATEGORY
	{
		get
		{
			return WEAPONCATEGORY;
		}
		set
		{
			WEAPONCATEGORY = value;
		}
	}

	public ObscuredFloat Get_SPEED
	{
		get
		{
			return SPEED;
		}
		set
		{
			SPEED = value;
		}
	}

	public ObscuredFloat Get_DAMAGETOPLAYER
	{
		get
		{
			return DAMAGETOPLAYER;
		}
		set
		{
			DAMAGETOPLAYER = value;
		}
	}

	public ObscuredFloat Get_DAMAGETOPLAYEROVERTIME
	{
		get
		{
			return DAMAGETOPLAYEROVERTIME;
		}
		set
		{
			DAMAGETOPLAYEROVERTIME = value;
		}
	}

	public ObscuredFloat Get_DAMAGETOPLAYERBEHINDSHIELD
	{
		get
		{
			return DAMAGETOPLAYERBEHINDSHIELD;
		}
		set
		{
			DAMAGETOPLAYERBEHINDSHIELD = value;
		}
	}

	public ObscuredFloat Get_DAMAGETOSHIELD
	{
		get
		{
			return DAMAGETOSHIELD;
		}
		set
		{
			DAMAGETOSHIELD = value;
		}
	}

	public int Length => 19;

	public string this[int i] => GetStringDataByIndex(i);

	public WeaponUpgradesRow()
	{
	}

	public WeaponUpgradesRow(string _ID, string _NAME, string _UNLOCKLEVEL, string _CANBEBOUGHT, string _PRICE, string _PRICEGOLD, string _NSLOTS, string _RATEOFFIRE, string _CRITICAL, string _BURSTSIZE, string _BURSTLOCKTIME, string _ACCURACY, string _DELIVERTIME, string _PURCHASABLE, string _WEAPONCATEGORY, string _SPEED, string _DAMAGETOPLAYER, string _DAMAGETOPLAYEROVERTIME, string _DAMAGETOPLAYERBEHINDSHIELD, string _DAMAGETOSHIELD)
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
		if (int.TryParse(_CANBEBOUGHT, out var result2))
		{
			CANBEBOUGHT = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert CANBEBOUGHT string: " + _CANBEBOUGHT + " to int");
		}
		if (int.TryParse(_PRICE, out var result3))
		{
			PRICE = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert PRICE string: " + _PRICE + " to float");
		}
		if (int.TryParse(_PRICEGOLD, out var result4))
		{
			PRICEGOLD = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert PRICEGOLD string: " + _PRICEGOLD + " to float");
		}
		if (int.TryParse(_NSLOTS, out var result5))
		{
			NSLOTS = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert NSLOTS string: " + _NSLOTS + " to int");
		}
		if (float.TryParse(_RATEOFFIRE, out var result6))
		{
			RATEOFFIRE = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert RATEOFFIRE string: " + _RATEOFFIRE + " to float");
		}
		if (float.TryParse(_CRITICAL, out var result7))
		{
			CRITICAL = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert CRITICAL string: " + _CRITICAL + " to float");
		}
		if (int.TryParse(_BURSTSIZE, out var result8))
		{
			BURSTSIZE = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert BURSTSIZE string: " + _BURSTSIZE + " to int");
		}
		if (float.TryParse(_BURSTLOCKTIME, out var result9))
		{
			BURSTLOCKTIME = result9;
		}
		else
		{
			Debug.LogError("Failed To Convert BURSTLOCKTIME string: " + _BURSTLOCKTIME + " to float");
		}
		if (float.TryParse(_ACCURACY, out var result10))
		{
			ACCURACY = result10;
		}
		else
		{
			Debug.LogError("Failed To Convert ACCURACY string: " + _ACCURACY + " to float");
		}
		if (int.TryParse(_DELIVERTIME, out var result11))
		{
			DELIVERTIME = result11;
		}
		else
		{
			Debug.LogError("Failed To Convert DELIVERTIME string: " + _DELIVERTIME + " to int");
		}
		PURCHASABLE = _PURCHASABLE.Trim();
		if (int.TryParse(_WEAPONCATEGORY, out var result12))
		{
			WEAPONCATEGORY = result12;
		}
		else
		{
			Debug.LogError("Failed To Convert WEAPONCATEGORY string: " + _WEAPONCATEGORY + " to int");
		}
		if (float.TryParse(_SPEED, out var result13))
		{
			SPEED = result13;
		}
		else
		{
			Debug.LogError("Failed To Convert SPEED string: " + _SPEED + " to float");
		}
		if (float.TryParse(_DAMAGETOPLAYER, out var result14))
		{
			DAMAGETOPLAYER = result14;
		}
		else
		{
			Debug.LogError("Failed To Convert DAMAGETOPLAYER string: " + _DAMAGETOPLAYER + " to float");
		}
		if (float.TryParse(_DAMAGETOPLAYEROVERTIME, out var result15))
		{
			DAMAGETOPLAYEROVERTIME = result15;
		}
		else
		{
			Debug.LogError("Failed To Convert DAMAGETOPLAYEROVERTIME string: " + _DAMAGETOPLAYEROVERTIME + " to float");
		}
		if (float.TryParse(_DAMAGETOPLAYERBEHINDSHIELD, out var result16))
		{
			DAMAGETOPLAYERBEHINDSHIELD = result16;
		}
		else
		{
			Debug.LogError("Failed To Convert DAMAGETOPLAYERBEHINDSHIELD string: " + _DAMAGETOPLAYERBEHINDSHIELD + " to float");
		}
		if (float.TryParse(_DAMAGETOSHIELD, out var result17))
		{
			DAMAGETOSHIELD = result17;
		}
		else
		{
			Debug.LogError("Failed To Convert DAMAGETOSHIELD string: " + _DAMAGETOSHIELD + " to float");
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
			result = CANBEBOUGHT.ToString();
			break;
		case 3:
			result = PRICE.ToString();
			break;
		case 4:
			result = PRICEGOLD.ToString();
			break;
		case 5:
			result = NSLOTS.ToString();
			break;
		case 6:
			result = RATEOFFIRE.ToString();
			break;
		case 7:
			result = CRITICAL.ToString();
			break;
		case 8:
			result = BURSTSIZE.ToString();
			break;
		case 9:
			result = BURSTLOCKTIME.ToString();
			break;
		case 10:
			result = ACCURACY.ToString();
			break;
		case 11:
			result = DELIVERTIME.ToString();
			break;
		case 12:
			result = PURCHASABLE.ToString();
			break;
		case 13:
			result = WEAPONCATEGORY.ToString();
			break;
		case 14:
			result = SPEED.ToString();
			break;
		case 15:
			result = DAMAGETOPLAYER.ToString();
			break;
		case 16:
			result = DAMAGETOPLAYEROVERTIME.ToString();
			break;
		case 17:
			result = DAMAGETOPLAYERBEHINDSHIELD.ToString();
			break;
		case 18:
			result = DAMAGETOSHIELD.ToString();
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
		case "CANBEBOUGHT":
			result = CANBEBOUGHT.ToString();
			break;
		case "PRICE":
			result = PRICE.ToString();
			break;
		case "PRICEGOLD":
			result = PRICEGOLD.ToString();
			break;
		case "NSLOTS":
			result = NSLOTS.ToString();
			break;
		case "RATEOFFIRE":
			result = RATEOFFIRE.ToString();
			break;
		case "CRITICAL":
			result = CRITICAL.ToString();
			break;
		case "BURSTSIZE":
			result = BURSTSIZE.ToString();
			break;
		case "BURSTLOCKTIME":
			result = BURSTLOCKTIME.ToString();
			break;
		case "ACCURACY":
			result = ACCURACY.ToString();
			break;
		case "DELIVERTIME":
			result = DELIVERTIME.ToString();
			break;
		case "PURCHASABLE":
			result = PURCHASABLE.ToString();
			break;
		case "WEAPONCATEGORY":
			result = WEAPONCATEGORY.ToString();
			break;
		case "SPEED":
			result = SPEED.ToString();
			break;
		case "DAMAGETOPLAYER":
			result = DAMAGETOPLAYER.ToString();
			break;
		case "DAMAGETOPLAYEROVERTIME":
			result = DAMAGETOPLAYEROVERTIME.ToString();
			break;
		case "DAMAGETOPLAYERBEHINDSHIELD":
			result = DAMAGETOPLAYERBEHINDSHIELD.ToString();
			break;
		case "DAMAGETOSHIELD":
			result = DAMAGETOSHIELD.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{NAME : " + NAME.ToString() + "} ";
		empty = empty + "{UNLOCKLEVEL : " + UNLOCKLEVEL + "} ";
		empty = empty + "{CANBEBOUGHT : " + CANBEBOUGHT + "} ";
		empty = empty + "{PRICE : " + PRICE.ToString() + "} ";
		empty = empty + "{PRICEGOLD : " + PRICEGOLD.ToString() + "} ";
		empty = empty + "{NSLOTS : " + NSLOTS + "} ";
		empty = empty + "{RATEOFFIRE : " + RATEOFFIRE.ToString() + "} ";
		empty = empty + "{CRITICAL : " + CRITICAL.ToString() + "} ";
		empty = empty + "{BURSTSIZE : " + BURSTSIZE + "} ";
		empty = empty + "{BURSTLOCKTIME : " + BURSTLOCKTIME + "} ";
		empty = empty + "{ACCURACY : " + ACCURACY.ToString() + "} ";
		empty = empty + "{DELIVERTIME : " + DELIVERTIME + "} ";
		empty = empty + "{PURCHASABLE : " + PURCHASABLE.ToString() + "} ";
		empty = empty + "{WEAPONCATEGORY : " + WEAPONCATEGORY + "} ";
		empty = empty + "{SPEED : " + SPEED.ToString() + "} ";
		empty = empty + "{DAMAGETOPLAYER : " + DAMAGETOPLAYER.ToString() + "} ";
		empty = empty + "{DAMAGETOPLAYEROVERTIME : " + DAMAGETOPLAYEROVERTIME.ToString() + "} ";
		empty = empty + "{DAMAGETOPLAYERBEHINDSHIELD : " + DAMAGETOPLAYERBEHINDSHIELD.ToString() + "} ";
		return empty + "{DAMAGETOSHIELD : " + DAMAGETOSHIELD.ToString() + "} ";
	}
}
