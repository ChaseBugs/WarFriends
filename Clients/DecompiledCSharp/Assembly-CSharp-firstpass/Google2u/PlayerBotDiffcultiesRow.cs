using System;
using UnityEngine;

namespace Google2u;

[Serializable]
public class PlayerBotDiffcultiesRow : IGoogle2uRow
{
	public int NUMBER;

	public float SHOOTFREQUENCYMIN;

	public float SHOOTFREQUENCYMAX;

	public float SHOOTINGLENGTHMIN;

	public float SHOOTINGLENGTHMAX;

	public float SHOOTACCURACY;

	public float HEADSHOTPROBABILITY;

	public float INDANGERCOEFICIENT;

	public float PICKOPPONENTSHOTPROBABILITY;

	public float PICKOPPONENTSHOTPROBABILITYNOSHIELD;

	public float PICKWALKINGOPPONENTSHOTPROBABILITY;

	public float SWITCHGRENADEBAZOOKAPROBABILITY;

	public float IGNORESHOTPROBABILITY;

	public float SNIPERLOOKTIME;

	public float SENDUNITMINTIME;

	public float SENDUNITMAXTIME;

	public float PICKBONUSPROBABILITYMINTIME;

	public float PICKBONUSPROBABILITYMAXTIME;

	public float PICKMYBONUSCOEF;

	public float OVERTIMESHIELDMINTIME;

	public float OVERTIMESHIELDMAXTIME;

	public string CARDS;

	public string CARDSFREQUENCY;

	public float BUDDYCARDPROB;

	public float OPPONENTOFFENSE;

	public float OPPONENTOFFENCEREACTIONTIME;

	public float OPPONENTSNIPERDEFFENSE;

	public float OPPONENTSNIPERDEFENSEREACTIONTIME;

	public int MAXUNITS;

	public int Get_NUMBER
	{
		get
		{
			return NUMBER;
		}
		set
		{
			NUMBER = value;
		}
	}

	public float Get_SHOOTFREQUENCYMIN
	{
		get
		{
			return SHOOTFREQUENCYMIN;
		}
		set
		{
			SHOOTFREQUENCYMIN = value;
		}
	}

	public float Get_SHOOTFREQUENCYMAX
	{
		get
		{
			return SHOOTFREQUENCYMAX;
		}
		set
		{
			SHOOTFREQUENCYMAX = value;
		}
	}

	public float Get_SHOOTINGLENGTHMIN
	{
		get
		{
			return SHOOTINGLENGTHMIN;
		}
		set
		{
			SHOOTINGLENGTHMIN = value;
		}
	}

	public float Get_SHOOTINGLENGTHMAX
	{
		get
		{
			return SHOOTINGLENGTHMAX;
		}
		set
		{
			SHOOTINGLENGTHMAX = value;
		}
	}

	public float Get_SHOOTACCURACY
	{
		get
		{
			return SHOOTACCURACY;
		}
		set
		{
			SHOOTACCURACY = value;
		}
	}

	public float Get_HEADSHOTPROBABILITY
	{
		get
		{
			return HEADSHOTPROBABILITY;
		}
		set
		{
			HEADSHOTPROBABILITY = value;
		}
	}

	public float Get_INDANGERCOEFICIENT
	{
		get
		{
			return INDANGERCOEFICIENT;
		}
		set
		{
			INDANGERCOEFICIENT = value;
		}
	}

	public float Get_PICKOPPONENTSHOTPROBABILITY
	{
		get
		{
			return PICKOPPONENTSHOTPROBABILITY;
		}
		set
		{
			PICKOPPONENTSHOTPROBABILITY = value;
		}
	}

	public float Get_PICKOPPONENTSHOTPROBABILITYNOSHIELD
	{
		get
		{
			return PICKOPPONENTSHOTPROBABILITYNOSHIELD;
		}
		set
		{
			PICKOPPONENTSHOTPROBABILITYNOSHIELD = value;
		}
	}

	public float Get_PICKWALKINGOPPONENTSHOTPROBABILITY
	{
		get
		{
			return PICKWALKINGOPPONENTSHOTPROBABILITY;
		}
		set
		{
			PICKWALKINGOPPONENTSHOTPROBABILITY = value;
		}
	}

	public float Get_SWITCHGRENADEBAZOOKAPROBABILITY
	{
		get
		{
			return SWITCHGRENADEBAZOOKAPROBABILITY;
		}
		set
		{
			SWITCHGRENADEBAZOOKAPROBABILITY = value;
		}
	}

	public float Get_IGNORESHOTPROBABILITY
	{
		get
		{
			return IGNORESHOTPROBABILITY;
		}
		set
		{
			IGNORESHOTPROBABILITY = value;
		}
	}

	public float Get_SNIPERLOOKTIME
	{
		get
		{
			return SNIPERLOOKTIME;
		}
		set
		{
			SNIPERLOOKTIME = value;
		}
	}

	public float Get_SENDUNITMINTIME
	{
		get
		{
			return SENDUNITMINTIME;
		}
		set
		{
			SENDUNITMINTIME = value;
		}
	}

	public float Get_SENDUNITMAXTIME
	{
		get
		{
			return SENDUNITMAXTIME;
		}
		set
		{
			SENDUNITMAXTIME = value;
		}
	}

	public float Get_PICKBONUSPROBABILITYMINTIME
	{
		get
		{
			return PICKBONUSPROBABILITYMINTIME;
		}
		set
		{
			PICKBONUSPROBABILITYMINTIME = value;
		}
	}

	public float Get_PICKBONUSPROBABILITYMAXTIME
	{
		get
		{
			return PICKBONUSPROBABILITYMAXTIME;
		}
		set
		{
			PICKBONUSPROBABILITYMAXTIME = value;
		}
	}

	public float Get_PICKMYBONUSCOEF
	{
		get
		{
			return PICKMYBONUSCOEF;
		}
		set
		{
			PICKMYBONUSCOEF = value;
		}
	}

	public float Get_OVERTIMESHIELDMINTIME
	{
		get
		{
			return OVERTIMESHIELDMINTIME;
		}
		set
		{
			OVERTIMESHIELDMINTIME = value;
		}
	}

	public float Get_OVERTIMESHIELDMAXTIME
	{
		get
		{
			return OVERTIMESHIELDMAXTIME;
		}
		set
		{
			OVERTIMESHIELDMAXTIME = value;
		}
	}

	public string Get_CARDS
	{
		get
		{
			return CARDS;
		}
		set
		{
			CARDS = value;
		}
	}

	public string Get_CARDSFREQUENCY
	{
		get
		{
			return CARDSFREQUENCY;
		}
		set
		{
			CARDSFREQUENCY = value;
		}
	}

	public float Get_BUDDYCARDPROB
	{
		get
		{
			return BUDDYCARDPROB;
		}
		set
		{
			BUDDYCARDPROB = value;
		}
	}

	public float Get_OPPONENTOFFENSE
	{
		get
		{
			return OPPONENTOFFENSE;
		}
		set
		{
			OPPONENTOFFENSE = value;
		}
	}

	public float Get_OPPONENTOFFENCEREACTIONTIME
	{
		get
		{
			return OPPONENTOFFENCEREACTIONTIME;
		}
		set
		{
			OPPONENTOFFENCEREACTIONTIME = value;
		}
	}

	public float Get_OPPONENTSNIPERDEFFENSE
	{
		get
		{
			return OPPONENTSNIPERDEFFENSE;
		}
		set
		{
			OPPONENTSNIPERDEFFENSE = value;
		}
	}

	public float Get_OPPONENTSNIPERDEFENSEREACTIONTIME
	{
		get
		{
			return OPPONENTSNIPERDEFENSEREACTIONTIME;
		}
		set
		{
			OPPONENTSNIPERDEFENSEREACTIONTIME = value;
		}
	}

	public int Get_MAXUNITS
	{
		get
		{
			return MAXUNITS;
		}
		set
		{
			MAXUNITS = value;
		}
	}

	public int Length => 29;

	public string this[int i] => GetStringDataByIndex(i);

	public PlayerBotDiffcultiesRow()
	{
	}

	public PlayerBotDiffcultiesRow(string _ID, string _NUMBER, string _SHOOTFREQUENCYMIN, string _SHOOTFREQUENCYMAX, string _SHOOTINGLENGTHMIN, string _SHOOTINGLENGTHMAX, string _SHOOTACCURACY, string _HEADSHOTPROBABILITY, string _INDANGERCOEFICIENT, string _PICKOPPONENTSHOTPROBABILITY, string _PICKOPPONENTSHOTPROBABILITYNOSHIELD, string _PICKWALKINGOPPONENTSHOTPROBABILITY, string _SWITCHGRENADEBAZOOKAPROBABILITY, string _IGNORESHOTPROBABILITY, string _SNIPERLOOKTIME, string _SENDUNITMINTIME, string _SENDUNITMAXTIME, string _PICKBONUSPROBABILITYMINTIME, string _PICKBONUSPROBABILITYMAXTIME, string _PICKMYBONUSCOEF, string _OVERTIMESHIELDMINTIME, string _OVERTIMESHIELDMAXTIME, string _CARDS, string _CARDSFREQUENCY, string _BUDDYCARDPROB, string _OPPONENTOFFENSE, string _OPPONENTOFFENCEREACTIONTIME, string _OPPONENTSNIPERDEFFENSE, string _OPPONENTSNIPERDEFENSEREACTIONTIME, string _MAXUNITS)
	{
		if (int.TryParse(_NUMBER, out var result))
		{
			NUMBER = result;
		}
		else
		{
			Debug.LogError("Failed To Convert NUMBER string: " + _NUMBER + " to int");
		}
		if (float.TryParse(_SHOOTFREQUENCYMIN, out var result2))
		{
			SHOOTFREQUENCYMIN = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOOTFREQUENCYMIN string: " + _SHOOTFREQUENCYMIN + " to float");
		}
		if (float.TryParse(_SHOOTFREQUENCYMAX, out var result3))
		{
			SHOOTFREQUENCYMAX = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOOTFREQUENCYMAX string: " + _SHOOTFREQUENCYMAX + " to float");
		}
		if (float.TryParse(_SHOOTINGLENGTHMIN, out var result4))
		{
			SHOOTINGLENGTHMIN = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOOTINGLENGTHMIN string: " + _SHOOTINGLENGTHMIN + " to float");
		}
		if (float.TryParse(_SHOOTINGLENGTHMAX, out var result5))
		{
			SHOOTINGLENGTHMAX = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOOTINGLENGTHMAX string: " + _SHOOTINGLENGTHMAX + " to float");
		}
		if (float.TryParse(_SHOOTACCURACY, out var result6))
		{
			SHOOTACCURACY = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert SHOOTACCURACY string: " + _SHOOTACCURACY + " to float");
		}
		if (float.TryParse(_HEADSHOTPROBABILITY, out var result7))
		{
			HEADSHOTPROBABILITY = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert HEADSHOTPROBABILITY string: " + _HEADSHOTPROBABILITY + " to float");
		}
		if (float.TryParse(_INDANGERCOEFICIENT, out var result8))
		{
			INDANGERCOEFICIENT = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert INDANGERCOEFICIENT string: " + _INDANGERCOEFICIENT + " to float");
		}
		if (float.TryParse(_PICKOPPONENTSHOTPROBABILITY, out var result9))
		{
			PICKOPPONENTSHOTPROBABILITY = result9;
		}
		else
		{
			Debug.LogError("Failed To Convert PICKOPPONENTSHOTPROBABILITY string: " + _PICKOPPONENTSHOTPROBABILITY + " to float");
		}
		if (float.TryParse(_PICKOPPONENTSHOTPROBABILITYNOSHIELD, out var result10))
		{
			PICKOPPONENTSHOTPROBABILITYNOSHIELD = result10;
		}
		else
		{
			Debug.LogError("Failed To Convert PICKOPPONENTSHOTPROBABILITYNOSHIELD string: " + _PICKOPPONENTSHOTPROBABILITYNOSHIELD + " to float");
		}
		if (float.TryParse(_PICKWALKINGOPPONENTSHOTPROBABILITY, out var result11))
		{
			PICKWALKINGOPPONENTSHOTPROBABILITY = result11;
		}
		else
		{
			Debug.LogError("Failed To Convert PICKWALKINGOPPONENTSHOTPROBABILITY string: " + _PICKWALKINGOPPONENTSHOTPROBABILITY + " to float");
		}
		if (float.TryParse(_SWITCHGRENADEBAZOOKAPROBABILITY, out var result12))
		{
			SWITCHGRENADEBAZOOKAPROBABILITY = result12;
		}
		else
		{
			Debug.LogError("Failed To Convert SWITCHGRENADEBAZOOKAPROBABILITY string: " + _SWITCHGRENADEBAZOOKAPROBABILITY + " to float");
		}
		if (float.TryParse(_IGNORESHOTPROBABILITY, out var result13))
		{
			IGNORESHOTPROBABILITY = result13;
		}
		else
		{
			Debug.LogError("Failed To Convert IGNORESHOTPROBABILITY string: " + _IGNORESHOTPROBABILITY + " to float");
		}
		if (float.TryParse(_SNIPERLOOKTIME, out var result14))
		{
			SNIPERLOOKTIME = result14;
		}
		else
		{
			Debug.LogError("Failed To Convert SNIPERLOOKTIME string: " + _SNIPERLOOKTIME + " to float");
		}
		if (float.TryParse(_SENDUNITMINTIME, out var result15))
		{
			SENDUNITMINTIME = result15;
		}
		else
		{
			Debug.LogError("Failed To Convert SENDUNITMINTIME string: " + _SENDUNITMINTIME + " to float");
		}
		if (float.TryParse(_SENDUNITMAXTIME, out var result16))
		{
			SENDUNITMAXTIME = result16;
		}
		else
		{
			Debug.LogError("Failed To Convert SENDUNITMAXTIME string: " + _SENDUNITMAXTIME + " to float");
		}
		if (float.TryParse(_PICKBONUSPROBABILITYMINTIME, out var result17))
		{
			PICKBONUSPROBABILITYMINTIME = result17;
		}
		else
		{
			Debug.LogError("Failed To Convert PICKBONUSPROBABILITYMINTIME string: " + _PICKBONUSPROBABILITYMINTIME + " to float");
		}
		if (float.TryParse(_PICKBONUSPROBABILITYMAXTIME, out var result18))
		{
			PICKBONUSPROBABILITYMAXTIME = result18;
		}
		else
		{
			Debug.LogError("Failed To Convert PICKBONUSPROBABILITYMAXTIME string: " + _PICKBONUSPROBABILITYMAXTIME + " to float");
		}
		if (float.TryParse(_PICKMYBONUSCOEF, out var result19))
		{
			PICKMYBONUSCOEF = result19;
		}
		else
		{
			Debug.LogError("Failed To Convert PICKMYBONUSCOEF string: " + _PICKMYBONUSCOEF + " to float");
		}
		if (float.TryParse(_OVERTIMESHIELDMINTIME, out var result20))
		{
			OVERTIMESHIELDMINTIME = result20;
		}
		else
		{
			Debug.LogError("Failed To Convert OVERTIMESHIELDMINTIME string: " + _OVERTIMESHIELDMINTIME + " to float");
		}
		if (float.TryParse(_OVERTIMESHIELDMAXTIME, out var result21))
		{
			OVERTIMESHIELDMAXTIME = result21;
		}
		else
		{
			Debug.LogError("Failed To Convert OVERTIMESHIELDMAXTIME string: " + _OVERTIMESHIELDMAXTIME + " to float");
		}
		CARDS = _CARDS.Trim();
		CARDSFREQUENCY = _CARDSFREQUENCY.Trim();
		if (float.TryParse(_BUDDYCARDPROB, out var result22))
		{
			BUDDYCARDPROB = result22;
		}
		else
		{
			Debug.LogError("Failed To Convert BUDDYCARDPROB string: " + _BUDDYCARDPROB + " to float");
		}
		if (float.TryParse(_OPPONENTOFFENSE, out var result23))
		{
			OPPONENTOFFENSE = result23;
		}
		else
		{
			Debug.LogError("Failed To Convert OPPONENTOFFENSE string: " + _OPPONENTOFFENSE + " to float");
		}
		if (float.TryParse(_OPPONENTOFFENCEREACTIONTIME, out var result24))
		{
			OPPONENTOFFENCEREACTIONTIME = result24;
		}
		else
		{
			Debug.LogError("Failed To Convert OPPONENTOFFENCEREACTIONTIME string: " + _OPPONENTOFFENCEREACTIONTIME + " to float");
		}
		if (float.TryParse(_OPPONENTSNIPERDEFFENSE, out var result25))
		{
			OPPONENTSNIPERDEFFENSE = result25;
		}
		else
		{
			Debug.LogError("Failed To Convert OPPONENTSNIPERDEFFENSE string: " + _OPPONENTSNIPERDEFFENSE + " to float");
		}
		if (float.TryParse(_OPPONENTSNIPERDEFENSEREACTIONTIME, out var result26))
		{
			OPPONENTSNIPERDEFENSEREACTIONTIME = result26;
		}
		else
		{
			Debug.LogError("Failed To Convert OPPONENTSNIPERDEFENSEREACTIONTIME string: " + _OPPONENTSNIPERDEFENSEREACTIONTIME + " to float");
		}
		if (int.TryParse(_MAXUNITS, out var result27))
		{
			MAXUNITS = result27;
		}
		else
		{
			Debug.LogError("Failed To Convert MAXUNITS string: " + _MAXUNITS + " to int");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = NUMBER.ToString();
			break;
		case 1:
			result = SHOOTFREQUENCYMIN.ToString();
			break;
		case 2:
			result = SHOOTFREQUENCYMAX.ToString();
			break;
		case 3:
			result = SHOOTINGLENGTHMIN.ToString();
			break;
		case 4:
			result = SHOOTINGLENGTHMAX.ToString();
			break;
		case 5:
			result = SHOOTACCURACY.ToString();
			break;
		case 6:
			result = HEADSHOTPROBABILITY.ToString();
			break;
		case 7:
			result = INDANGERCOEFICIENT.ToString();
			break;
		case 8:
			result = PICKOPPONENTSHOTPROBABILITY.ToString();
			break;
		case 9:
			result = PICKOPPONENTSHOTPROBABILITYNOSHIELD.ToString();
			break;
		case 10:
			result = PICKWALKINGOPPONENTSHOTPROBABILITY.ToString();
			break;
		case 11:
			result = SWITCHGRENADEBAZOOKAPROBABILITY.ToString();
			break;
		case 12:
			result = IGNORESHOTPROBABILITY.ToString();
			break;
		case 13:
			result = SNIPERLOOKTIME.ToString();
			break;
		case 14:
			result = SENDUNITMINTIME.ToString();
			break;
		case 15:
			result = SENDUNITMAXTIME.ToString();
			break;
		case 16:
			result = PICKBONUSPROBABILITYMINTIME.ToString();
			break;
		case 17:
			result = PICKBONUSPROBABILITYMAXTIME.ToString();
			break;
		case 18:
			result = PICKMYBONUSCOEF.ToString();
			break;
		case 19:
			result = OVERTIMESHIELDMINTIME.ToString();
			break;
		case 20:
			result = OVERTIMESHIELDMAXTIME.ToString();
			break;
		case 21:
			result = CARDS.ToString();
			break;
		case 22:
			result = CARDSFREQUENCY.ToString();
			break;
		case 23:
			result = BUDDYCARDPROB.ToString();
			break;
		case 24:
			result = OPPONENTOFFENSE.ToString();
			break;
		case 25:
			result = OPPONENTOFFENCEREACTIONTIME.ToString();
			break;
		case 26:
			result = OPPONENTSNIPERDEFFENSE.ToString();
			break;
		case 27:
			result = OPPONENTSNIPERDEFENSEREACTIONTIME.ToString();
			break;
		case 28:
			result = MAXUNITS.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "NUMBER":
			result = NUMBER.ToString();
			break;
		case "SHOOTFREQUENCYMIN":
			result = SHOOTFREQUENCYMIN.ToString();
			break;
		case "SHOOTFREQUENCYMAX":
			result = SHOOTFREQUENCYMAX.ToString();
			break;
		case "SHOOTINGLENGTHMIN":
			result = SHOOTINGLENGTHMIN.ToString();
			break;
		case "SHOOTINGLENGTHMAX":
			result = SHOOTINGLENGTHMAX.ToString();
			break;
		case "SHOOTACCURACY":
			result = SHOOTACCURACY.ToString();
			break;
		case "HEADSHOTPROBABILITY":
			result = HEADSHOTPROBABILITY.ToString();
			break;
		case "INDANGERCOEFICIENT":
			result = INDANGERCOEFICIENT.ToString();
			break;
		case "PICKOPPONENTSHOTPROBABILITY":
			result = PICKOPPONENTSHOTPROBABILITY.ToString();
			break;
		case "PICKOPPONENTSHOTPROBABILITYNOSHIELD":
			result = PICKOPPONENTSHOTPROBABILITYNOSHIELD.ToString();
			break;
		case "PICKWALKINGOPPONENTSHOTPROBABILITY":
			result = PICKWALKINGOPPONENTSHOTPROBABILITY.ToString();
			break;
		case "SWITCHGRENADEBAZOOKAPROBABILITY":
			result = SWITCHGRENADEBAZOOKAPROBABILITY.ToString();
			break;
		case "IGNORESHOTPROBABILITY":
			result = IGNORESHOTPROBABILITY.ToString();
			break;
		case "SNIPERLOOKTIME":
			result = SNIPERLOOKTIME.ToString();
			break;
		case "SENDUNITMINTIME":
			result = SENDUNITMINTIME.ToString();
			break;
		case "SENDUNITMAXTIME":
			result = SENDUNITMAXTIME.ToString();
			break;
		case "PICKBONUSPROBABILITYMINTIME":
			result = PICKBONUSPROBABILITYMINTIME.ToString();
			break;
		case "PICKBONUSPROBABILITYMAXTIME":
			result = PICKBONUSPROBABILITYMAXTIME.ToString();
			break;
		case "PICKMYBONUSCOEF":
			result = PICKMYBONUSCOEF.ToString();
			break;
		case "OVERTIMESHIELDMINTIME":
			result = OVERTIMESHIELDMINTIME.ToString();
			break;
		case "OVERTIMESHIELDMAXTIME":
			result = OVERTIMESHIELDMAXTIME.ToString();
			break;
		case "CARDS":
			result = CARDS.ToString();
			break;
		case "CARDSFREQUENCY":
			result = CARDSFREQUENCY.ToString();
			break;
		case "BUDDYCARDPROB":
			result = BUDDYCARDPROB.ToString();
			break;
		case "OPPONENTOFFENSE":
			result = OPPONENTOFFENSE.ToString();
			break;
		case "OPPONENTOFFENCEREACTIONTIME":
			result = OPPONENTOFFENCEREACTIONTIME.ToString();
			break;
		case "OPPONENTSNIPERDEFFENSE":
			result = OPPONENTSNIPERDEFFENSE.ToString();
			break;
		case "OPPONENTSNIPERDEFENSEREACTIONTIME":
			result = OPPONENTSNIPERDEFENSEREACTIONTIME.ToString();
			break;
		case "MAXUNITS":
			result = MAXUNITS.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{NUMBER : " + NUMBER + "} ";
		empty = empty + "{SHOOTFREQUENCYMIN : " + SHOOTFREQUENCYMIN + "} ";
		empty = empty + "{SHOOTFREQUENCYMAX : " + SHOOTFREQUENCYMAX + "} ";
		empty = empty + "{SHOOTINGLENGTHMIN : " + SHOOTINGLENGTHMIN + "} ";
		empty = empty + "{SHOOTINGLENGTHMAX : " + SHOOTINGLENGTHMAX + "} ";
		empty = empty + "{SHOOTACCURACY : " + SHOOTACCURACY + "} ";
		empty = empty + "{HEADSHOTPROBABILITY : " + HEADSHOTPROBABILITY + "} ";
		empty = empty + "{INDANGERCOEFICIENT : " + INDANGERCOEFICIENT + "} ";
		empty = empty + "{PICKOPPONENTSHOTPROBABILITY : " + PICKOPPONENTSHOTPROBABILITY + "} ";
		empty = empty + "{PICKOPPONENTSHOTPROBABILITYNOSHIELD : " + PICKOPPONENTSHOTPROBABILITYNOSHIELD + "} ";
		empty = empty + "{PICKWALKINGOPPONENTSHOTPROBABILITY : " + PICKWALKINGOPPONENTSHOTPROBABILITY + "} ";
		empty = empty + "{SWITCHGRENADEBAZOOKAPROBABILITY : " + SWITCHGRENADEBAZOOKAPROBABILITY + "} ";
		empty = empty + "{IGNORESHOTPROBABILITY : " + IGNORESHOTPROBABILITY + "} ";
		empty = empty + "{SNIPERLOOKTIME : " + SNIPERLOOKTIME + "} ";
		empty = empty + "{SENDUNITMINTIME : " + SENDUNITMINTIME + "} ";
		empty = empty + "{SENDUNITMAXTIME : " + SENDUNITMAXTIME + "} ";
		empty = empty + "{PICKBONUSPROBABILITYMINTIME : " + PICKBONUSPROBABILITYMINTIME + "} ";
		empty = empty + "{PICKBONUSPROBABILITYMAXTIME : " + PICKBONUSPROBABILITYMAXTIME + "} ";
		empty = empty + "{PICKMYBONUSCOEF : " + PICKMYBONUSCOEF + "} ";
		empty = empty + "{OVERTIMESHIELDMINTIME : " + OVERTIMESHIELDMINTIME + "} ";
		empty = empty + "{OVERTIMESHIELDMAXTIME : " + OVERTIMESHIELDMAXTIME + "} ";
		empty = empty + "{CARDS : " + CARDS.ToString() + "} ";
		empty = empty + "{CARDSFREQUENCY : " + CARDSFREQUENCY.ToString() + "} ";
		empty = empty + "{BUDDYCARDPROB : " + BUDDYCARDPROB + "} ";
		empty = empty + "{OPPONENTOFFENSE : " + OPPONENTOFFENSE + "} ";
		empty = empty + "{OPPONENTOFFENCEREACTIONTIME : " + OPPONENTOFFENCEREACTIONTIME + "} ";
		empty = empty + "{OPPONENTSNIPERDEFFENSE : " + OPPONENTSNIPERDEFFENSE + "} ";
		empty = empty + "{OPPONENTSNIPERDEFENSEREACTIONTIME : " + OPPONENTSNIPERDEFENSEREACTIONTIME + "} ";
		return empty + "{MAXUNITS : " + MAXUNITS + "} ";
	}
}
