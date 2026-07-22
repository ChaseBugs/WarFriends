using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class MissionsRow : IGoogle2uRow
	{
		public int LEVEL;

		public int MAP_STAGE;

		public string MISSIONTYPE;

		public string OBJECTIVE;

		public int TIME;

		public int SCORE1;

		public int SCORE2;

		public int SCORE3;

		public int MAX_UNITS_AT_ONCE;

		public int REWARD_WARBUCKS;

		public int REWARD_GOLD;

		public int REWARD_XP;

		public int BOT_NUMBER_DIFFICULTY;

		public int BOTLEVEL;

		public float BOTHPREDUCTION;

		public string TUTORIALS;

		public string CRATES;

		public string DATA;

		public float HPTARGET;

		public float TIMETARGET;

		public int RECOMMENDEDARMYPOWER;

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

		public int Get_MAP_STAGE
		{
			get
			{
				return MAP_STAGE;
			}
			set
			{
				MAP_STAGE = value;
			}
		}

		public string Get_MISSIONTYPE
		{
			get
			{
				return MISSIONTYPE;
			}
			set
			{
				MISSIONTYPE = value;
			}
		}

		public string Get_OBJECTIVE
		{
			get
			{
				return OBJECTIVE;
			}
			set
			{
				OBJECTIVE = value;
			}
		}

		public int Get_TIME
		{
			get
			{
				return TIME;
			}
			set
			{
				TIME = value;
			}
		}

		public int Get_SCORE1
		{
			get
			{
				return SCORE1;
			}
			set
			{
				SCORE1 = value;
			}
		}

		public int Get_SCORE2
		{
			get
			{
				return SCORE2;
			}
			set
			{
				SCORE2 = value;
			}
		}

		public int Get_SCORE3
		{
			get
			{
				return SCORE3;
			}
			set
			{
				SCORE3 = value;
			}
		}

		public int Get_MAX_UNITS_AT_ONCE
		{
			get
			{
				return MAX_UNITS_AT_ONCE;
			}
			set
			{
				MAX_UNITS_AT_ONCE = value;
			}
		}

		public int Get_REWARD_WARBUCKS
		{
			get
			{
				return REWARD_WARBUCKS;
			}
			set
			{
				REWARD_WARBUCKS = value;
			}
		}

		public int Get_REWARD_GOLD
		{
			get
			{
				return REWARD_GOLD;
			}
			set
			{
				REWARD_GOLD = value;
			}
		}

		public int Get_REWARD_XP
		{
			get
			{
				return REWARD_XP;
			}
			set
			{
				REWARD_XP = value;
			}
		}

		public int Get_BOT_NUMBER_DIFFICULTY
		{
			get
			{
				return BOT_NUMBER_DIFFICULTY;
			}
			set
			{
				BOT_NUMBER_DIFFICULTY = value;
			}
		}

		public int Get_BOTLEVEL
		{
			get
			{
				return BOTLEVEL;
			}
			set
			{
				BOTLEVEL = value;
			}
		}

		public float Get_BOTHPREDUCTION
		{
			get
			{
				return BOTHPREDUCTION;
			}
			set
			{
				BOTHPREDUCTION = value;
			}
		}

		public string Get_TUTORIALS
		{
			get
			{
				return TUTORIALS;
			}
			set
			{
				TUTORIALS = value;
			}
		}

		public string Get_CRATES
		{
			get
			{
				return CRATES;
			}
			set
			{
				CRATES = value;
			}
		}

		public string Get_DATA
		{
			get
			{
				return DATA;
			}
			set
			{
				DATA = value;
			}
		}

		public float Get_HPTARGET
		{
			get
			{
				return HPTARGET;
			}
			set
			{
				HPTARGET = value;
			}
		}

		public float Get_TIMETARGET
		{
			get
			{
				return TIMETARGET;
			}
			set
			{
				TIMETARGET = value;
			}
		}

		public int Get_RECOMMENDEDARMYPOWER
		{
			get
			{
				return RECOMMENDEDARMYPOWER;
			}
			set
			{
				RECOMMENDEDARMYPOWER = value;
			}
		}

		public int Length => 21;

		public string this[int i] => GetStringDataByIndex(i);

		public MissionsRow()
		{
		}

		public MissionsRow(string _ID, string _LEVEL, string _MAP_STAGE, string _MISSIONTYPE, string _OBJECTIVE, string _TIME, string _SCORE1, string _SCORE2, string _SCORE3, string _MAX_UNITS_AT_ONCE, string _REWARD_WARBUCKS, string _REWARD_GOLD, string _REWARD_XP, string _BOT_NUMBER_DIFFICULTY, string _BOTLEVEL, string _BOTHPREDUCTION, string _TUTORIALS, string _CRATES, string _DATA, string _HPTARGET, string _TIMETARGET, string _RECOMMENDEDARMYPOWER)
		{
			if (int.TryParse(_LEVEL, out var result))
			{
				LEVEL = result;
			}
			else
			{
				Debug.LogError("Failed To Convert LEVEL string: " + _LEVEL + " to int");
			}
			if (int.TryParse(_MAP_STAGE, out var result2))
			{
				MAP_STAGE = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert MAP_STAGE string: " + _MAP_STAGE + " to int");
			}
			MISSIONTYPE = _MISSIONTYPE.Trim();
			OBJECTIVE = _OBJECTIVE.Trim();
			if (int.TryParse(_TIME, out var result3))
			{
				TIME = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert TIME string: " + _TIME + " to int");
			}
			if (int.TryParse(_SCORE1, out var result4))
			{
				SCORE1 = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert SCORE1 string: " + _SCORE1 + " to int");
			}
			if (int.TryParse(_SCORE2, out var result5))
			{
				SCORE2 = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert SCORE2 string: " + _SCORE2 + " to int");
			}
			if (int.TryParse(_SCORE3, out var result6))
			{
				SCORE3 = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert SCORE3 string: " + _SCORE3 + " to int");
			}
			if (int.TryParse(_MAX_UNITS_AT_ONCE, out var result7))
			{
				MAX_UNITS_AT_ONCE = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert MAX_UNITS_AT_ONCE string: " + _MAX_UNITS_AT_ONCE + " to int");
			}
			if (int.TryParse(_REWARD_WARBUCKS, out var result8))
			{
				REWARD_WARBUCKS = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARD_WARBUCKS string: " + _REWARD_WARBUCKS + " to int");
			}
			if (int.TryParse(_REWARD_GOLD, out var result9))
			{
				REWARD_GOLD = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARD_GOLD string: " + _REWARD_GOLD + " to int");
			}
			if (int.TryParse(_REWARD_XP, out var result10))
			{
				REWARD_XP = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARD_XP string: " + _REWARD_XP + " to int");
			}
			if (int.TryParse(_BOT_NUMBER_DIFFICULTY, out var result11))
			{
				BOT_NUMBER_DIFFICULTY = result11;
			}
			else
			{
				Debug.LogError("Failed To Convert BOT_NUMBER_DIFFICULTY string: " + _BOT_NUMBER_DIFFICULTY + " to int");
			}
			if (int.TryParse(_BOTLEVEL, out var result12))
			{
				BOTLEVEL = result12;
			}
			else
			{
				Debug.LogError("Failed To Convert BOTLEVEL string: " + _BOTLEVEL + " to int");
			}
			if (float.TryParse(_BOTHPREDUCTION, out var result13))
			{
				BOTHPREDUCTION = result13;
			}
			else
			{
				Debug.LogError("Failed To Convert BOTHPREDUCTION string: " + _BOTHPREDUCTION + " to float");
			}
			TUTORIALS = _TUTORIALS.Trim();
			CRATES = _CRATES.Trim();
			DATA = _DATA.Trim();
			if (float.TryParse(_HPTARGET, out var result14))
			{
				HPTARGET = result14;
			}
			else
			{
				Debug.LogError("Failed To Convert HPTARGET string: " + _HPTARGET + " to float");
			}
			if (float.TryParse(_TIMETARGET, out var result15))
			{
				TIMETARGET = result15;
			}
			else
			{
				Debug.LogError("Failed To Convert TIMETARGET string: " + _TIMETARGET + " to float");
			}
			if (int.TryParse(_RECOMMENDEDARMYPOWER, out var result16))
			{
				RECOMMENDEDARMYPOWER = result16;
			}
			else
			{
				Debug.LogError("Failed To Convert RECOMMENDEDARMYPOWER string: " + _RECOMMENDEDARMYPOWER + " to int");
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
				result = MAP_STAGE.ToString();
				break;
			case 2:
				result = MISSIONTYPE.ToString();
				break;
			case 3:
				result = OBJECTIVE.ToString();
				break;
			case 4:
				result = TIME.ToString();
				break;
			case 5:
				result = SCORE1.ToString();
				break;
			case 6:
				result = SCORE2.ToString();
				break;
			case 7:
				result = SCORE3.ToString();
				break;
			case 8:
				result = MAX_UNITS_AT_ONCE.ToString();
				break;
			case 9:
				result = REWARD_WARBUCKS.ToString();
				break;
			case 10:
				result = REWARD_GOLD.ToString();
				break;
			case 11:
				result = REWARD_XP.ToString();
				break;
			case 12:
				result = BOT_NUMBER_DIFFICULTY.ToString();
				break;
			case 13:
				result = BOTLEVEL.ToString();
				break;
			case 14:
				result = BOTHPREDUCTION.ToString();
				break;
			case 15:
				result = TUTORIALS.ToString();
				break;
			case 16:
				result = CRATES.ToString();
				break;
			case 17:
				result = DATA.ToString();
				break;
			case 18:
				result = HPTARGET.ToString();
				break;
			case 19:
				result = TIMETARGET.ToString();
				break;
			case 20:
				result = RECOMMENDEDARMYPOWER.ToString();
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
			case "MAP_STAGE":
				result = MAP_STAGE.ToString();
				break;
			case "MISSIONTYPE":
				result = MISSIONTYPE.ToString();
				break;
			case "OBJECTIVE":
				result = OBJECTIVE.ToString();
				break;
			case "TIME":
				result = TIME.ToString();
				break;
			case "SCORE1":
				result = SCORE1.ToString();
				break;
			case "SCORE2":
				result = SCORE2.ToString();
				break;
			case "SCORE3":
				result = SCORE3.ToString();
				break;
			case "MAX_UNITS_AT_ONCE":
				result = MAX_UNITS_AT_ONCE.ToString();
				break;
			case "REWARD_WARBUCKS":
				result = REWARD_WARBUCKS.ToString();
				break;
			case "REWARD_GOLD":
				result = REWARD_GOLD.ToString();
				break;
			case "REWARD_XP":
				result = REWARD_XP.ToString();
				break;
			case "BOT_NUMBER_DIFFICULTY":
				result = BOT_NUMBER_DIFFICULTY.ToString();
				break;
			case "BOTLEVEL":
				result = BOTLEVEL.ToString();
				break;
			case "BOTHPREDUCTION":
				result = BOTHPREDUCTION.ToString();
				break;
			case "TUTORIALS":
				result = TUTORIALS.ToString();
				break;
			case "CRATES":
				result = CRATES.ToString();
				break;
			case "DATA":
				result = DATA.ToString();
				break;
			case "HPTARGET":
				result = HPTARGET.ToString();
				break;
			case "TIMETARGET":
				result = TIMETARGET.ToString();
				break;
			case "RECOMMENDEDARMYPOWER":
				result = RECOMMENDEDARMYPOWER.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{LEVEL : " + LEVEL + "} ";
			empty = empty + "{MAP_STAGE : " + MAP_STAGE + "} ";
			empty = empty + "{MISSIONTYPE : " + MISSIONTYPE.ToString() + "} ";
			empty = empty + "{OBJECTIVE : " + OBJECTIVE.ToString() + "} ";
			empty = empty + "{TIME : " + TIME + "} ";
			empty = empty + "{SCORE1 : " + SCORE1 + "} ";
			empty = empty + "{SCORE2 : " + SCORE2 + "} ";
			empty = empty + "{SCORE3 : " + SCORE3 + "} ";
			empty = empty + "{MAX_UNITS_AT_ONCE : " + MAX_UNITS_AT_ONCE + "} ";
			empty = empty + "{REWARD_WARBUCKS : " + REWARD_WARBUCKS + "} ";
			empty = empty + "{REWARD_GOLD : " + REWARD_GOLD + "} ";
			empty = empty + "{REWARD_XP : " + REWARD_XP + "} ";
			empty = empty + "{BOT_NUMBER_DIFFICULTY : " + BOT_NUMBER_DIFFICULTY + "} ";
			empty = empty + "{BOTLEVEL : " + BOTLEVEL + "} ";
			empty = empty + "{BOTHPREDUCTION : " + BOTHPREDUCTION + "} ";
			empty = empty + "{TUTORIALS : " + TUTORIALS.ToString() + "} ";
			empty = empty + "{CRATES : " + CRATES.ToString() + "} ";
			empty = empty + "{DATA : " + DATA.ToString() + "} ";
			empty = empty + "{HPTARGET : " + HPTARGET + "} ";
			empty = empty + "{TIMETARGET : " + TIMETARGET + "} ";
			return empty + "{RECOMMENDEDARMYPOWER : " + RECOMMENDEDARMYPOWER + "} ";
		}
	}
}
