using System;
using UnityEngine;

namespace Google2u
{
[Serializable]
public class SkillshotsRow : IGoogle2uRow
{
	public int SCOREMP;

	public int SCORESINGLE;

	public int RIBBONCOUNT;

	public int RIBBONREWARDMINWB;

	public int RIBBONREWARDMAXWB;

	public int Get_SCOREMP
	{
		get
		{
			return SCOREMP;
		}
		set
		{
			SCOREMP = value;
		}
	}

	public int Get_SCORESINGLE
	{
		get
		{
			return SCORESINGLE;
		}
		set
		{
			SCORESINGLE = value;
		}
	}

	public int Get_RIBBONCOUNT
	{
		get
		{
			return RIBBONCOUNT;
		}
		set
		{
			RIBBONCOUNT = value;
		}
	}

	public int Get_RIBBONREWARDMINWB
	{
		get
		{
			return RIBBONREWARDMINWB;
		}
		set
		{
			RIBBONREWARDMINWB = value;
		}
	}

	public int Get_RIBBONREWARDMAXWB
	{
		get
		{
			return RIBBONREWARDMAXWB;
		}
		set
		{
			RIBBONREWARDMAXWB = value;
		}
	}

	public int Length => 5;

	public string this[int i] => GetStringDataByIndex(i);

	public SkillshotsRow()
	{
	}

	public SkillshotsRow(string _ID, string _SCOREMP, string _SCORESINGLE, string _RIBBONCOUNT, string _RIBBONREWARDMINWB, string _RIBBONREWARDMAXWB)
	{
		if (int.TryParse(_SCOREMP, out var result))
		{
			SCOREMP = result;
		}
		else
		{
			Debug.LogError("Failed To Convert SCOREMP string: " + _SCOREMP + " to int");
		}
		if (int.TryParse(_SCORESINGLE, out var result2))
		{
			SCORESINGLE = result2;
		}
		else
		{
			Debug.LogError("Failed To Convert SCORESINGLE string: " + _SCORESINGLE + " to int");
		}
		if (int.TryParse(_RIBBONCOUNT, out var result3))
		{
			RIBBONCOUNT = result3;
		}
		else
		{
			Debug.LogError("Failed To Convert RIBBONCOUNT string: " + _RIBBONCOUNT + " to int");
		}
		if (int.TryParse(_RIBBONREWARDMINWB, out var result4))
		{
			RIBBONREWARDMINWB = result4;
		}
		else
		{
			Debug.LogError("Failed To Convert RIBBONREWARDMINWB string: " + _RIBBONREWARDMINWB + " to int");
		}
		if (int.TryParse(_RIBBONREWARDMAXWB, out var result5))
		{
			RIBBONREWARDMAXWB = result5;
		}
		else
		{
			Debug.LogError("Failed To Convert RIBBONREWARDMAXWB string: " + _RIBBONREWARDMAXWB + " to int");
		}
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 0:
			result = SCOREMP.ToString();
			break;
		case 1:
			result = SCORESINGLE.ToString();
			break;
		case 2:
			result = RIBBONCOUNT.ToString();
			break;
		case 3:
			result = RIBBONREWARDMINWB.ToString();
			break;
		case 4:
			result = RIBBONREWARDMAXWB.ToString();
			break;
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "SCOREMP":
			result = SCOREMP.ToString();
			break;
		case "SCORESINGLE":
			result = SCORESINGLE.ToString();
			break;
		case "RIBBONCOUNT":
			result = RIBBONCOUNT.ToString();
			break;
		case "RIBBONREWARDMINWB":
			result = RIBBONREWARDMINWB.ToString();
			break;
		case "RIBBONREWARDMAXWB":
			result = RIBBONREWARDMAXWB.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		empty = empty + "{SCOREMP : " + SCOREMP + "} ";
		empty = empty + "{SCORESINGLE : " + SCORESINGLE + "} ";
		empty = empty + "{RIBBONCOUNT : " + RIBBONCOUNT + "} ";
		empty = empty + "{RIBBONREWARDMINWB : " + RIBBONREWARDMINWB + "} ";
		return empty + "{RIBBONREWARDMAXWB : " + RIBBONREWARDMAXWB + "} ";
	}
}
}
