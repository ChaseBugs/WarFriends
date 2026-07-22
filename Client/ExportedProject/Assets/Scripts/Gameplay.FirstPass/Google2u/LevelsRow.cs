using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class LevelsRow : IGoogle2uRow
	{
		public int LEVEL;

		public int EXPERIENCE;

		public int REWARDGOLD;

		public int ARMYPOWER;

		public int CONVERTGOLDTOWARBUCKS;

		public int Get_LEVEL
		{
			get
			{
				return LEVEL;
			}
			set
			{
				LEVEL = value;
			}
		}

		public int Get_EXPERIENCE
		{
			get
			{
				return EXPERIENCE;
			}
			set
			{
				EXPERIENCE = value;
			}
		}

		public int Get_REWARDGOLD
		{
			get
			{
				return REWARDGOLD;
			}
			set
			{
				REWARDGOLD = value;
			}
		}

		public int Get_ARMYPOWER
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

		public int Get_CONVERTGOLDTOWARBUCKS
		{
			get
			{
				return CONVERTGOLDTOWARBUCKS;
			}
			set
			{
				CONVERTGOLDTOWARBUCKS = value;
			}
		}

		public int Length => 5;

		public string this[int i] => GetStringDataByIndex(i);

		public LevelsRow()
		{
		}

		public LevelsRow(string _ID, string _LEVEL, string _EXPERIENCE, string _REWARDGOLD, string _ARMYPOWER, string _CONVERTGOLDTOWARBUCKS)
		{
			if (int.TryParse(_LEVEL, out var result))
			{
				LEVEL = result;
			}
			else
			{
				Debug.LogError("Failed To Convert LEVEL string: " + _LEVEL + " to int");
			}
			if (int.TryParse(_EXPERIENCE, out var result2))
			{
				EXPERIENCE = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert EXPERIENCE string: " + _EXPERIENCE + " to int");
			}
			if (int.TryParse(_REWARDGOLD, out var result3))
			{
				REWARDGOLD = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDGOLD string: " + _REWARDGOLD + " to int");
			}
			if (int.TryParse(_ARMYPOWER, out var result4))
			{
				ARMYPOWER = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert ARMYPOWER string: " + _ARMYPOWER + " to int");
			}
			if (int.TryParse(_CONVERTGOLDTOWARBUCKS, out var result5))
			{
				CONVERTGOLDTOWARBUCKS = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert CONVERTGOLDTOWARBUCKS string: " + _CONVERTGOLDTOWARBUCKS + " to int");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = LEVEL.ToString();
				break;
			case 1:
				result = EXPERIENCE.ToString();
				break;
			case 2:
				result = REWARDGOLD.ToString();
				break;
			case 3:
				result = ARMYPOWER.ToString();
				break;
			case 4:
				result = CONVERTGOLDTOWARBUCKS.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "LEVEL":
				result = LEVEL.ToString();
				break;
			case "EXPERIENCE":
				result = EXPERIENCE.ToString();
				break;
			case "REWARDGOLD":
				result = REWARDGOLD.ToString();
				break;
			case "ARMYPOWER":
				result = ARMYPOWER.ToString();
				break;
			case "CONVERTGOLDTOWARBUCKS":
				result = CONVERTGOLDTOWARBUCKS.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{LEVEL : " + LEVEL + "} ";
			empty = empty + "{EXPERIENCE : " + EXPERIENCE + "} ";
			empty = empty + "{REWARDGOLD : " + REWARDGOLD + "} ";
			empty = empty + "{ARMYPOWER : " + ARMYPOWER + "} ";
			return empty + "{CONVERTGOLDTOWARBUCKS : " + CONVERTGOLDTOWARBUCKS + "} ";
		}
	}
}
