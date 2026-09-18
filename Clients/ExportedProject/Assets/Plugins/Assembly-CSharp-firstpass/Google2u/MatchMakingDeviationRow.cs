using System;
using UnityEngine;

namespace Google2u
{
[Serializable]
public class MatchMakingDeviationRow : IGoogle2uRow
{
	public int STEP1;

	public int STEP2;

	public int STEP3;

	public int STEP4;

	public int STEP5;

	public int STEP6;

	public int STEP7;

	public int STEP8;

	public int STEP9;

	public int STEP10;

	public int Get_STEP1
	{
		get
		{
			return STEP1;
		}
		set
		{
			STEP1 = value;
		}
	}

	public int Get_STEP2
	{
		get
		{
			return STEP2;
		}
		set
		{
			STEP2 = value;
		}
	}

	public int Get_STEP3
	{
		get
		{
			return STEP3;
		}
		set
		{
			STEP3 = value;
		}
	}

	public int Get_STEP4
	{
		get
		{
			return STEP4;
		}
		set
		{
			STEP4 = value;
		}
	}

	public int Get_STEP5
	{
		get
		{
			return STEP5;
		}
		set
		{
			STEP5 = value;
		}
	}

	public int Get_STEP6
	{
		get
		{
			return STEP6;
		}
		set
		{
			STEP6 = value;
		}
	}

	public int Get_STEP7
	{
		get
		{
			return STEP7;
		}
		set
		{
			STEP7 = value;
		}
	}

	public int Get_STEP8
	{
		get
		{
			return STEP8;
		}
		set
		{
			STEP8 = value;
		}
	}

	public int Get_STEP9
	{
		get
		{
			return STEP9;
		}
		set
		{
			STEP9 = value;
		}
	}

	public int Get_STEP10
	{
		get
		{
			return STEP10;
		}
		set
		{
			STEP10 = value;
		}
	}

	public int Length => 10;

	public string this[int i] => GetStringDataByIndex(i);

	public MatchMakingDeviationRow()
	{
	}

	public MatchMakingDeviationRow(string _NAME, string _STEP1, string _STEP2, string _STEP3, string _STEP4, string _STEP5, string _STEP6, string _STEP7, string _STEP8, string _STEP9, string _STEP10)
	{
		if (int.TryParse(_STEP1, out var result))
		{
			STEP1 = result;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP1 string: " + _STEP1 + " to int");
		}
		if (int.TryParse(_STEP2, out var result2))
		{
			STEP2 = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP2 string: " + _STEP2 + " to int");
		}
		if (int.TryParse(_STEP3, out var result3))
		{
			STEP3 = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP3 string: " + _STEP3 + " to int");
		}
		if (int.TryParse(_STEP4, out var result4))
		{
			STEP4 = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP4 string: " + _STEP4 + " to int");
		}
		if (int.TryParse(_STEP5, out var result5))
		{
			STEP5 = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP5 string: " + _STEP5 + " to int");
		}
		if (int.TryParse(_STEP6, out var result6))
		{
			STEP6 = result6;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP6 string: " + _STEP6 + " to int");
		}
		if (int.TryParse(_STEP7, out var result7))
		{
			STEP7 = result7;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP7 string: " + _STEP7 + " to int");
		}
		if (int.TryParse(_STEP8, out var result8))
		{
			STEP8 = result8;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP8 string: " + _STEP8 + " to int");
		}
		if (int.TryParse(_STEP9, out var result9))
		{
			STEP9 = result9;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP9 string: " + _STEP9 + " to int");
		}
		if (int.TryParse(_STEP10, out var result10))
		{
			STEP10 = result10;
		}
		else
		{
			Debug.LogError("Failed To Convert STEP10 string: " + _STEP10 + " to int");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = STEP1.ToString();
			break;
		case 1:
			result = STEP2.ToString();
			break;
		case 2:
			result = STEP3.ToString();
			break;
		case 3:
			result = STEP4.ToString();
			break;
		case 4:
			result = STEP5.ToString();
			break;
		case 5:
			result = STEP6.ToString();
			break;
		case 6:
			result = STEP7.ToString();
			break;
		case 7:
			result = STEP8.ToString();
			break;
		case 8:
			result = STEP9.ToString();
			break;
		case 9:
			result = STEP10.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "STEP1":
			result = STEP1.ToString();
			break;
		case "STEP2":
			result = STEP2.ToString();
			break;
		case "STEP3":
			result = STEP3.ToString();
			break;
		case "STEP4":
			result = STEP4.ToString();
			break;
		case "STEP5":
			result = STEP5.ToString();
			break;
		case "STEP6":
			result = STEP6.ToString();
			break;
		case "STEP7":
			result = STEP7.ToString();
			break;
		case "STEP8":
			result = STEP8.ToString();
			break;
		case "STEP9":
			result = STEP9.ToString();
			break;
		case "STEP10":
			result = STEP10.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{STEP1 : " + STEP1 + "} ";
		empty = empty + "{STEP2 : " + STEP2 + "} ";
		empty = empty + "{STEP3 : " + STEP3 + "} ";
		empty = empty + "{STEP4 : " + STEP4 + "} ";
		empty = empty + "{STEP5 : " + STEP5 + "} ";
		empty = empty + "{STEP6 : " + STEP6 + "} ";
		empty = empty + "{STEP7 : " + STEP7 + "} ";
		empty = empty + "{STEP8 : " + STEP8 + "} ";
		empty = empty + "{STEP9 : " + STEP9 + "} ";
		return empty + "{STEP10 : " + STEP10 + "} ";
	}
}
}
