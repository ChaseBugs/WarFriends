using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u;

[Serializable]
public class ArmyUpgradesRow : IGoogle2uRow
{
	public string NAME;

	public int UNLOCKLEVEL;

	public ObscuredInt PRICE;

	public int CANBEBOUGHT;

	public ObscuredInt PRICEGOLD;

	public ObscuredInt TOTALPOWER;

	public ObscuredFloat COOLDOWN;

	public int DANGERCOEFICIENT;

	public int DELIVERTIME;

	public int STARTINGTIER;

	public int STARTINGLEVEL;

	public int STARTINGSPECIAL;

	public int STARTINGELITE;

	public ObscuredFloat BULLETSPEED;

	public ObscuredFloat PLAYERBEHINDSHIELDDMGRATIO;

	public ObscuredFloat PLAYERDAMAGERATIO;

	public ObscuredFloat PLAYERDAMAGEOVERTIMERATIO;

	public int UNITTYPE;

	public string SPAWNS;

	public ObscuredFloat MOVEMENTSPEED;

	public float COOPHP;

	public float COOPDAMAGE;

	public float HEROICHP;

	public float HEROICDAMAGE;

	public float HEROICCOOPHP;

	public float HEROICCOOPDAMAGE;

	public float UNITINMECHANICALRESPAWN;

	public int CLIENTID;

	public float HITSHIELDPROB;

	public int UNLOCKTIER2;

	public int UNLOCKTIER3;

	public int UNLOCKTIER4;

	public int UNLOCKTIER5;

	public int UNLOCKTIER6;

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

	public ObscuredInt Get_TOTALPOWER
	{
		get
		{
			return TOTALPOWER;
		}
		set
		{
			TOTALPOWER = value;
		}
	}

	public ObscuredFloat Get_COOLDOWN
	{
		get
		{
			return COOLDOWN;
		}
		set
		{
			COOLDOWN = value;
		}
	}

	public int Get_DANGERCOEFICIENT
	{
		get
		{
			return DANGERCOEFICIENT;
		}
		set
		{
			DANGERCOEFICIENT = value;
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

	public int Get_STARTINGTIER
	{
		get
		{
			return STARTINGTIER;
		}
		set
		{
			STARTINGTIER = value;
		}
	}

	public int Get_STARTINGLEVEL
	{
		get
		{
			return STARTINGLEVEL;
		}
		set
		{
			STARTINGLEVEL = value;
		}
	}

	public int Get_STARTINGSPECIAL
	{
		get
		{
			return STARTINGSPECIAL;
		}
		set
		{
			STARTINGSPECIAL = value;
		}
	}

	public int Get_STARTINGELITE
	{
		get
		{
			return STARTINGELITE;
		}
		set
		{
			STARTINGELITE = value;
		}
	}

	public ObscuredFloat Get_BULLETSPEED
	{
		get
		{
			return BULLETSPEED;
		}
		set
		{
			BULLETSPEED = value;
		}
	}

	public ObscuredFloat Get_PLAYERBEHINDSHIELDDMGRATIO
	{
		get
		{
			return PLAYERBEHINDSHIELDDMGRATIO;
		}
		set
		{
			PLAYERBEHINDSHIELDDMGRATIO = value;
		}
	}

	public ObscuredFloat Get_PLAYERDAMAGERATIO
	{
		get
		{
			return PLAYERDAMAGERATIO;
		}
		set
		{
			PLAYERDAMAGERATIO = value;
		}
	}

	public ObscuredFloat Get_PLAYERDAMAGEOVERTIMERATIO
	{
		get
		{
			return PLAYERDAMAGEOVERTIMERATIO;
		}
		set
		{
			PLAYERDAMAGEOVERTIMERATIO = value;
		}
	}

	public int Get_UNITTYPE
	{
		get
		{
			return UNITTYPE;
		}
		set
		{
			UNITTYPE = value;
		}
	}

	public string Get_SPAWNS
	{
		get
		{
			return SPAWNS;
		}
		set
		{
			SPAWNS = value;
		}
	}

	public ObscuredFloat Get_MOVEMENTSPEED
	{
		get
		{
			return MOVEMENTSPEED;
		}
		set
		{
			MOVEMENTSPEED = value;
		}
	}

	public float Get_COOPHP
	{
		get
		{
			return COOPHP;
		}
		set
		{
			COOPHP = value;
		}
	}

	public float Get_COOPDAMAGE
	{
		get
		{
			return COOPDAMAGE;
		}
		set
		{
			COOPDAMAGE = value;
		}
	}

	public float Get_HEROICHP
	{
		get
		{
			return HEROICHP;
		}
		set
		{
			HEROICHP = value;
		}
	}

	public float Get_HEROICDAMAGE
	{
		get
		{
			return HEROICDAMAGE;
		}
		set
		{
			HEROICDAMAGE = value;
		}
	}

	public float Get_HEROICCOOPHP
	{
		get
		{
			return HEROICCOOPHP;
		}
		set
		{
			HEROICCOOPHP = value;
		}
	}

	public float Get_HEROICCOOPDAMAGE
	{
		get
		{
			return HEROICCOOPDAMAGE;
		}
		set
		{
			HEROICCOOPDAMAGE = value;
		}
	}

	public float Get_UNITINMECHANICALRESPAWN
	{
		get
		{
			return UNITINMECHANICALRESPAWN;
		}
		set
		{
			UNITINMECHANICALRESPAWN = value;
		}
	}

	public int Get_CLIENTID
	{
		get
		{
			return CLIENTID;
		}
		set
		{
			CLIENTID = value;
		}
	}

	public float Get_HITSHIELDPROB
	{
		get
		{
			return HITSHIELDPROB;
		}
		set
		{
			HITSHIELDPROB = value;
		}
	}

	public int Get_UNLOCKTIER2
	{
		get
		{
			return UNLOCKTIER2;
		}
		set
		{
			UNLOCKTIER2 = value;
		}
	}

	public int Get_UNLOCKTIER3
	{
		get
		{
			return UNLOCKTIER3;
		}
		set
		{
			UNLOCKTIER3 = value;
		}
	}

	public int Get_UNLOCKTIER4
	{
		get
		{
			return UNLOCKTIER4;
		}
		set
		{
			UNLOCKTIER4 = value;
		}
	}

	public int Get_UNLOCKTIER5
	{
		get
		{
			return UNLOCKTIER5;
		}
		set
		{
			UNLOCKTIER5 = value;
		}
	}

	public int Get_UNLOCKTIER6
	{
		get
		{
			return UNLOCKTIER6;
		}
		set
		{
			UNLOCKTIER6 = value;
		}
	}

	public int Length => 34;

	public string this[int i] => GetStringDataByIndex(i);

	public ArmyUpgradesRow()
	{
	}

	public ArmyUpgradesRow(string _ID, string _NAME, string _UNLOCKLEVEL, string _PRICE, string _CANBEBOUGHT, string _PRICEGOLD, string _TOTALPOWER, string _COOLDOWN, string _DANGERCOEFICIENT, string _DELIVERTIME, string _STARTINGTIER, string _STARTINGLEVEL, string _STARTINGSPECIAL, string _STARTINGELITE, string _BULLETSPEED, string _PLAYERBEHINDSHIELDDMGRATIO, string _PLAYERDAMAGERATIO, string _PLAYERDAMAGEOVERTIMERATIO, string _UNITTYPE, string _SPAWNS, string _MOVEMENTSPEED, string _COOPHP, string _COOPDAMAGE, string _HEROICHP, string _HEROICDAMAGE, string _HEROICCOOPHP, string _HEROICCOOPDAMAGE, string _UNITINMECHANICALRESPAWN, string _CLIENTID, string _HITSHIELDPROB, string _UNLOCKTIER2, string _UNLOCKTIER3, string _UNLOCKTIER4, string _UNLOCKTIER5, string _UNLOCKTIER6)
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
		if (int.TryParse(_PRICE, out var result2))
		{
			PRICE = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert PRICE string: " + _PRICE + " to float");
		}
		if (int.TryParse(_CANBEBOUGHT, out var result3))
		{
			CANBEBOUGHT = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert CANBEBOUGHT string: " + _CANBEBOUGHT + " to int");
		}
		if (int.TryParse(_PRICEGOLD, out var result4))
		{
			PRICEGOLD = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert PRICEGOLD string: " + _PRICEGOLD + " to float");
		}
		if (int.TryParse(_TOTALPOWER, out var result5))
		{
			TOTALPOWER = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert TOTALPOWER string: " + _TOTALPOWER + " to float");
		}
		if (float.TryParse(_COOLDOWN, out var result6))
		{
			COOLDOWN = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert COOLDOWN string: " + _COOLDOWN + " to float");
		}
		if (int.TryParse(_DANGERCOEFICIENT, out var result7))
		{
			DANGERCOEFICIENT = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert DANGERCOEFICIENT string: " + _DANGERCOEFICIENT + " to int");
		}
		if (int.TryParse(_DELIVERTIME, out var result8))
		{
			DELIVERTIME = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert DELIVERTIME string: " + _DELIVERTIME + " to int");
		}
		if (int.TryParse(_STARTINGTIER, out var result9))
		{
			STARTINGTIER = result9;
		}
		else
		{
			Debug.LogError("Failed To Convert STARTINGTIER string: " + _STARTINGTIER + " to int");
		}
		if (int.TryParse(_STARTINGLEVEL, out var result10))
		{
			STARTINGLEVEL = result10;
		}
		else
		{
			Debug.LogError("Failed To Convert STARTINGLEVEL string: " + _STARTINGLEVEL + " to int");
		}
		if (int.TryParse(_STARTINGSPECIAL, out var result11))
		{
			STARTINGSPECIAL = result11;
		}
		else
		{
			Debug.LogError("Failed To Convert STARTINGSPECIAL string: " + _STARTINGSPECIAL + " to int");
		}
		if (int.TryParse(_STARTINGELITE, out var result12))
		{
			STARTINGELITE = result12;
		}
		else
		{
			Debug.LogError("Failed To Convert STARTINGELITE string: " + _STARTINGELITE + " to int");
		}
		if (float.TryParse(_BULLETSPEED, out var result13))
		{
			BULLETSPEED = result13;
		}
		else
		{
			Debug.LogError("Failed To Convert BULLETSPEED string: " + _BULLETSPEED + " to float");
		}
		if (float.TryParse(_PLAYERBEHINDSHIELDDMGRATIO, out var result14))
		{
			PLAYERBEHINDSHIELDDMGRATIO = result14;
		}
		else
		{
			Debug.LogError("Failed To Convert PLAYERBEHINDSHIELDDMGRATIO string: " + _PLAYERBEHINDSHIELDDMGRATIO + " to float");
		}
		if (float.TryParse(_PLAYERDAMAGERATIO, out var result15))
		{
			PLAYERDAMAGERATIO = result15;
		}
		else
		{
			Debug.LogError("Failed To Convert PLAYERDAMAGERATIO string: " + _PLAYERDAMAGERATIO + " to float");
		}
		if (float.TryParse(_PLAYERDAMAGEOVERTIMERATIO, out var result16))
		{
			PLAYERDAMAGEOVERTIMERATIO = result16;
		}
		else
		{
			Debug.LogError("Failed To Convert PLAYERDAMAGEOVERTIMERATIO string: " + _PLAYERDAMAGEOVERTIMERATIO + " to float");
		}
		if (int.TryParse(_UNITTYPE, out var result17))
		{
			UNITTYPE = result17;
		}
		else
		{
			Debug.LogError("Failed To Convert UNITTYPE string: " + _UNITTYPE + " to int");
		}
		SPAWNS = _SPAWNS.Trim();
		if (float.TryParse(_MOVEMENTSPEED, out var result18))
		{
			MOVEMENTSPEED = result18;
		}
		else
		{
			Debug.LogError("Failed To Convert MOVEMENTSPEED string: " + _MOVEMENTSPEED + " to float");
		}
		if (float.TryParse(_COOPHP, out var result19))
		{
			COOPHP = result19;
		}
		else
		{
			Debug.LogError("Failed To Convert COOPHP string: " + _COOPHP + " to float");
		}
		if (float.TryParse(_COOPDAMAGE, out var result20))
		{
			COOPDAMAGE = result20;
		}
		else
		{
			Debug.LogError("Failed To Convert COOPDAMAGE string: " + _COOPDAMAGE + " to float");
		}
		if (float.TryParse(_HEROICHP, out var result21))
		{
			HEROICHP = result21;
		}
		else
		{
			Debug.LogError("Failed To Convert HEROICHP string: " + _HEROICHP + " to float");
		}
		if (float.TryParse(_HEROICDAMAGE, out var result22))
		{
			HEROICDAMAGE = result22;
		}
		else
		{
			Debug.LogError("Failed To Convert HEROICDAMAGE string: " + _HEROICDAMAGE + " to float");
		}
		if (float.TryParse(_HEROICCOOPHP, out var result23))
		{
			HEROICCOOPHP = result23;
		}
		else
		{
			Debug.LogError("Failed To Convert HEROICCOOPHP string: " + _HEROICCOOPHP + " to float");
		}
		if (float.TryParse(_HEROICCOOPDAMAGE, out var result24))
		{
			HEROICCOOPDAMAGE = result24;
		}
		else
		{
			Debug.LogError("Failed To Convert HEROICCOOPDAMAGE string: " + _HEROICCOOPDAMAGE + " to float");
		}
		if (float.TryParse(_UNITINMECHANICALRESPAWN, out var result25))
		{
			UNITINMECHANICALRESPAWN = result25;
		}
		else
		{
			Debug.LogError("Failed To Convert UNITINMECHANICALRESPAWN string: " + _UNITINMECHANICALRESPAWN + " to float");
		}
		if (int.TryParse(_CLIENTID, out var result26))
		{
			CLIENTID = result26;
		}
		else
		{
			Debug.LogError("Failed To Convert CLIENTID string: " + _CLIENTID + " to int");
		}
		if (float.TryParse(_HITSHIELDPROB, out var result27))
		{
			HITSHIELDPROB = result27;
		}
		else
		{
			Debug.LogError("Failed To Convert HITSHIELDPROB string: " + _HITSHIELDPROB + " to float");
		}
		if (int.TryParse(_UNLOCKTIER2, out var result28))
		{
			UNLOCKTIER2 = result28;
		}
		else
		{
			Debug.LogError("Failed To Convert UNLOCKTIER2 string: " + _UNLOCKTIER2 + " to int");
		}
		if (int.TryParse(_UNLOCKTIER3, out var result29))
		{
			UNLOCKTIER3 = result29;
		}
		else
		{
			Debug.LogError("Failed To Convert UNLOCKTIER3 string: " + _UNLOCKTIER3 + " to int");
		}
		if (int.TryParse(_UNLOCKTIER4, out var result30))
		{
			UNLOCKTIER4 = result30;
		}
		else
		{
			Debug.LogError("Failed To Convert UNLOCKTIER4 string: " + _UNLOCKTIER4 + " to int");
		}
		if (int.TryParse(_UNLOCKTIER5, out var result31))
		{
			UNLOCKTIER5 = result31;
		}
		else
		{
			Debug.LogError("Failed To Convert UNLOCKTIER5 string: " + _UNLOCKTIER5 + " to int");
		}
		if (int.TryParse(_UNLOCKTIER6, out var result32))
		{
			UNLOCKTIER6 = result32;
		}
		else
		{
			Debug.LogError("Failed To Convert UNLOCKTIER6 string: " + _UNLOCKTIER6 + " to int");
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
			result = PRICE.ToString();
			break;
		case 3:
			result = CANBEBOUGHT.ToString();
			break;
		case 4:
			result = PRICEGOLD.ToString();
			break;
		case 5:
			result = TOTALPOWER.ToString();
			break;
		case 6:
			result = COOLDOWN.ToString();
			break;
		case 7:
			result = DANGERCOEFICIENT.ToString();
			break;
		case 8:
			result = DELIVERTIME.ToString();
			break;
		case 9:
			result = STARTINGTIER.ToString();
			break;
		case 10:
			result = STARTINGLEVEL.ToString();
			break;
		case 11:
			result = STARTINGSPECIAL.ToString();
			break;
		case 12:
			result = STARTINGELITE.ToString();
			break;
		case 13:
			result = BULLETSPEED.ToString();
			break;
		case 14:
			result = PLAYERBEHINDSHIELDDMGRATIO.ToString();
			break;
		case 15:
			result = PLAYERDAMAGERATIO.ToString();
			break;
		case 16:
			result = PLAYERDAMAGEOVERTIMERATIO.ToString();
			break;
		case 17:
			result = UNITTYPE.ToString();
			break;
		case 18:
			result = SPAWNS.ToString();
			break;
		case 19:
			result = MOVEMENTSPEED.ToString();
			break;
		case 20:
			result = COOPHP.ToString();
			break;
		case 21:
			result = COOPDAMAGE.ToString();
			break;
		case 22:
			result = HEROICHP.ToString();
			break;
		case 23:
			result = HEROICDAMAGE.ToString();
			break;
		case 24:
			result = HEROICCOOPHP.ToString();
			break;
		case 25:
			result = HEROICCOOPDAMAGE.ToString();
			break;
		case 26:
			result = UNITINMECHANICALRESPAWN.ToString();
			break;
		case 27:
			result = CLIENTID.ToString();
			break;
		case 28:
			result = HITSHIELDPROB.ToString();
			break;
		case 29:
			result = UNLOCKTIER2.ToString();
			break;
		case 30:
			result = UNLOCKTIER3.ToString();
			break;
		case 31:
			result = UNLOCKTIER4.ToString();
			break;
		case 32:
			result = UNLOCKTIER5.ToString();
			break;
		case 33:
			result = UNLOCKTIER6.ToString();
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
		case "PRICE":
			result = PRICE.ToString();
			break;
		case "CANBEBOUGHT":
			result = CANBEBOUGHT.ToString();
			break;
		case "PRICEGOLD":
			result = PRICEGOLD.ToString();
			break;
		case "TOTALPOWER":
			result = TOTALPOWER.ToString();
			break;
		case "COOLDOWN":
			result = COOLDOWN.ToString();
			break;
		case "DANGERCOEFICIENT":
			result = DANGERCOEFICIENT.ToString();
			break;
		case "DELIVERTIME":
			result = DELIVERTIME.ToString();
			break;
		case "STARTINGTIER":
			result = STARTINGTIER.ToString();
			break;
		case "STARTINGLEVEL":
			result = STARTINGLEVEL.ToString();
			break;
		case "STARTINGSPECIAL":
			result = STARTINGSPECIAL.ToString();
			break;
		case "STARTINGELITE":
			result = STARTINGELITE.ToString();
			break;
		case "BULLETSPEED":
			result = BULLETSPEED.ToString();
			break;
		case "PLAYERBEHINDSHIELDDMGRATIO":
			result = PLAYERBEHINDSHIELDDMGRATIO.ToString();
			break;
		case "PLAYERDAMAGERATIO":
			result = PLAYERDAMAGERATIO.ToString();
			break;
		case "PLAYERDAMAGEOVERTIMERATIO":
			result = PLAYERDAMAGEOVERTIMERATIO.ToString();
			break;
		case "UNITTYPE":
			result = UNITTYPE.ToString();
			break;
		case "SPAWNS":
			result = SPAWNS.ToString();
			break;
		case "MOVEMENTSPEED":
			result = MOVEMENTSPEED.ToString();
			break;
		case "COOPHP":
			result = COOPHP.ToString();
			break;
		case "COOPDAMAGE":
			result = COOPDAMAGE.ToString();
			break;
		case "HEROICHP":
			result = HEROICHP.ToString();
			break;
		case "HEROICDAMAGE":
			result = HEROICDAMAGE.ToString();
			break;
		case "HEROICCOOPHP":
			result = HEROICCOOPHP.ToString();
			break;
		case "HEROICCOOPDAMAGE":
			result = HEROICCOOPDAMAGE.ToString();
			break;
		case "UNITINMECHANICALRESPAWN":
			result = UNITINMECHANICALRESPAWN.ToString();
			break;
		case "CLIENTID":
			result = CLIENTID.ToString();
			break;
		case "HITSHIELDPROB":
			result = HITSHIELDPROB.ToString();
			break;
		case "UNLOCKTIER2":
			result = UNLOCKTIER2.ToString();
			break;
		case "UNLOCKTIER3":
			result = UNLOCKTIER3.ToString();
			break;
		case "UNLOCKTIER4":
			result = UNLOCKTIER4.ToString();
			break;
		case "UNLOCKTIER5":
			result = UNLOCKTIER5.ToString();
			break;
		case "UNLOCKTIER6":
			result = UNLOCKTIER6.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{NAME : " + NAME.ToString() + "} ";
		empty = empty + "{UNLOCKLEVEL : " + UNLOCKLEVEL + "} ";
		empty = empty + "{PRICE : " + PRICE.ToString() + "} ";
		empty = empty + "{CANBEBOUGHT : " + CANBEBOUGHT + "} ";
		empty = empty + "{PRICEGOLD : " + PRICEGOLD.ToString() + "} ";
		empty = empty + "{TOTALPOWER : " + TOTALPOWER.ToString() + "} ";
		empty = empty + "{COOLDOWN : " + COOLDOWN.ToString() + "} ";
		empty = empty + "{DANGERCOEFICIENT : " + DANGERCOEFICIENT + "} ";
		empty = empty + "{DELIVERTIME : " + DELIVERTIME + "} ";
		empty = empty + "{STARTINGTIER : " + STARTINGTIER + "} ";
		empty = empty + "{STARTINGLEVEL : " + STARTINGLEVEL + "} ";
		empty = empty + "{STARTINGSPECIAL : " + STARTINGSPECIAL + "} ";
		empty = empty + "{STARTINGELITE : " + STARTINGELITE + "} ";
		empty = empty + "{BULLETSPEED : " + BULLETSPEED.ToString() + "} ";
		empty = empty + "{PLAYERBEHINDSHIELDDMGRATIO : " + PLAYERBEHINDSHIELDDMGRATIO.ToString() + "} ";
		empty = empty + "{PLAYERDAMAGERATIO : " + PLAYERDAMAGERATIO.ToString() + "} ";
		empty = empty + "{PLAYERDAMAGEOVERTIMERATIO : " + PLAYERDAMAGEOVERTIMERATIO.ToString() + "} ";
		empty = empty + "{UNITTYPE : " + UNITTYPE + "} ";
		empty = empty + "{SPAWNS : " + SPAWNS.ToString() + "} ";
		empty = empty + "{MOVEMENTSPEED : " + MOVEMENTSPEED.ToString() + "} ";
		empty = empty + "{COOPHP : " + COOPHP + "} ";
		empty = empty + "{COOPDAMAGE : " + COOPDAMAGE + "} ";
		empty = empty + "{HEROICHP : " + HEROICHP + "} ";
		empty = empty + "{HEROICDAMAGE : " + HEROICDAMAGE + "} ";
		empty = empty + "{HEROICCOOPHP : " + HEROICCOOPHP + "} ";
		empty = empty + "{HEROICCOOPDAMAGE : " + HEROICCOOPDAMAGE + "} ";
		empty = empty + "{UNITINMECHANICALRESPAWN : " + UNITINMECHANICALRESPAWN + "} ";
		empty = empty + "{CLIENTID : " + CLIENTID + "} ";
		empty = empty + "{HITSHIELDPROB : " + HITSHIELDPROB + "} ";
		empty = empty + "{UNLOCKTIER2 : " + UNLOCKTIER2 + "} ";
		empty = empty + "{UNLOCKTIER3 : " + UNLOCKTIER3 + "} ";
		empty = empty + "{UNLOCKTIER4 : " + UNLOCKTIER4 + "} ";
		empty = empty + "{UNLOCKTIER5 : " + UNLOCKTIER5 + "} ";
		return empty + "{UNLOCKTIER6 : " + UNLOCKTIER6 + "} ";
	}
}
