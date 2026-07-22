using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class PlayerBotsRow : IGoogle2uRow
	{
		public int NUMBER;

		public string NAME;

		public int DIFFICULTY;

		public int SKILL;

		public string PRIMARY;

		public string SECONDARY;

		public string EXPLOSIVES;

		public int LEAGUE;

		public int LEAGUEBOTID;

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

		public int Get_DIFFICULTY
		{
			get
			{
				return DIFFICULTY;
			}
			set
			{
				DIFFICULTY = value;
			}
		}

		public int Get_SKILL
		{
			get
			{
				return SKILL;
			}
			set
			{
				SKILL = value;
			}
		}

		public string Get_PRIMARY
		{
			get
			{
				return PRIMARY;
			}
			set
			{
				PRIMARY = value;
			}
		}

		public string Get_SECONDARY
		{
			get
			{
				return SECONDARY;
			}
			set
			{
				SECONDARY = value;
			}
		}

		public string Get_EXPLOSIVES
		{
			get
			{
				return EXPLOSIVES;
			}
			set
			{
				EXPLOSIVES = value;
			}
		}

		public int Get_LEAGUE
		{
			get
			{
				return LEAGUE;
			}
			set
			{
				LEAGUE = value;
			}
		}

		public int Get_LEAGUEBOTID
		{
			get
			{
				return LEAGUEBOTID;
			}
			set
			{
				LEAGUEBOTID = value;
			}
		}

		public int Length => 9;

		public string this[int i] => GetStringDataByIndex(i);

		public PlayerBotsRow()
		{
		}

		public PlayerBotsRow(string _ID, string _NUMBER, string _NAME, string _DIFFICULTY, string _SKILL, string _PRIMARY, string _SECONDARY, string _EXPLOSIVES, string _LEAGUE, string _LEAGUEBOTID)
		{
			if (int.TryParse(_NUMBER, out var result))
			{
				NUMBER = result;
			}
			else
			{
				Debug.LogError("Failed To Convert NUMBER string: " + _NUMBER + " to int");
			}
			NAME = _NAME.Trim();
			if (int.TryParse(_DIFFICULTY, out var result2))
			{
				DIFFICULTY = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert DIFFICULTY string: " + _DIFFICULTY + " to int");
			}
			if (int.TryParse(_SKILL, out var result3))
			{
				SKILL = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert SKILL string: " + _SKILL + " to int");
			}
			PRIMARY = _PRIMARY.Trim();
			SECONDARY = _SECONDARY.Trim();
			EXPLOSIVES = _EXPLOSIVES.Trim();
			if (int.TryParse(_LEAGUE, out var result4))
			{
				LEAGUE = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert LEAGUE string: " + _LEAGUE + " to int");
			}
			if (int.TryParse(_LEAGUEBOTID, out var result5))
			{
				LEAGUEBOTID = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert LEAGUEBOTID string: " + _LEAGUEBOTID + " to int");
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
				result = NAME.ToString();
				break;
			case 2:
				result = DIFFICULTY.ToString();
				break;
			case 3:
				result = SKILL.ToString();
				break;
			case 4:
				result = PRIMARY.ToString();
				break;
			case 5:
				result = SECONDARY.ToString();
				break;
			case 6:
				result = EXPLOSIVES.ToString();
				break;
			case 7:
				result = LEAGUE.ToString();
				break;
			case 8:
				result = LEAGUEBOTID.ToString();
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
			case "NAME":
				result = NAME.ToString();
				break;
			case "DIFFICULTY":
				result = DIFFICULTY.ToString();
				break;
			case "SKILL":
				result = SKILL.ToString();
				break;
			case "PRIMARY":
				result = PRIMARY.ToString();
				break;
			case "SECONDARY":
				result = SECONDARY.ToString();
				break;
			case "EXPLOSIVES":
				result = EXPLOSIVES.ToString();
				break;
			case "LEAGUE":
				result = LEAGUE.ToString();
				break;
			case "LEAGUEBOTID":
				result = LEAGUEBOTID.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{NUMBER : " + NUMBER + "} ";
			empty = empty + "{NAME : " + NAME.ToString() + "} ";
			empty = empty + "{DIFFICULTY : " + DIFFICULTY + "} ";
			empty = empty + "{SKILL : " + SKILL + "} ";
			empty = empty + "{PRIMARY : " + PRIMARY.ToString() + "} ";
			empty = empty + "{SECONDARY : " + SECONDARY.ToString() + "} ";
			empty = empty + "{EXPLOSIVES : " + EXPLOSIVES.ToString() + "} ";
			empty = empty + "{LEAGUE : " + LEAGUE + "} ";
			return empty + "{LEAGUEBOTID : " + LEAGUEBOTID + "} ";
		}
	}
}
