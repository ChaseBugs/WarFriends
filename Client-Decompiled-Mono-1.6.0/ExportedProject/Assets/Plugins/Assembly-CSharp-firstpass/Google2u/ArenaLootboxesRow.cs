using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class ArenaLootboxesRow : IGoogle2uRow
	{
		public string NAME;

		public int ELITEPARTSMIN;

		public int ELITEPARTSMAX;

		public int TICKETSMIN;

		public int TICKETSMAX;

		public int SCRAPSMIN;

		public int SCRAPSMAX;

		public int GOLDMIN;

		public int GOLDMAX;

		public int WARBUCKS;

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

		public int Get_ELITEPARTSMIN
		{
			get
			{
				return ELITEPARTSMIN;
			}
			set
			{
				ELITEPARTSMIN = value;
			}
		}

		public int Get_ELITEPARTSMAX
		{
			get
			{
				return ELITEPARTSMAX;
			}
			set
			{
				ELITEPARTSMAX = value;
			}
		}

		public int Get_TICKETSMIN
		{
			get
			{
				return TICKETSMIN;
			}
			set
			{
				TICKETSMIN = value;
			}
		}

		public int Get_TICKETSMAX
		{
			get
			{
				return TICKETSMAX;
			}
			set
			{
				TICKETSMAX = value;
			}
		}

		public int Get_SCRAPSMIN
		{
			get
			{
				return SCRAPSMIN;
			}
			set
			{
				SCRAPSMIN = value;
			}
		}

		public int Get_SCRAPSMAX
		{
			get
			{
				return SCRAPSMAX;
			}
			set
			{
				SCRAPSMAX = value;
			}
		}

		public int Get_GOLDMIN
		{
			get
			{
				return GOLDMIN;
			}
			set
			{
				GOLDMIN = value;
			}
		}

		public int Get_GOLDMAX
		{
			get
			{
				return GOLDMAX;
			}
			set
			{
				GOLDMAX = value;
			}
		}

		public int Get_WARBUCKS
		{
			get
			{
				return WARBUCKS;
			}
			set
			{
				WARBUCKS = value;
			}
		}

		public int Length
		{
			get
			{
				return 10;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public ArenaLootboxesRow()
		{
		}

		public ArenaLootboxesRow(string _ID, string _NAME, string _ELITEPARTSMIN, string _ELITEPARTSMAX, string _TICKETSMIN, string _TICKETSMAX, string _SCRAPSMIN, string _SCRAPSMAX, string _GOLDMIN, string _GOLDMAX, string _WARBUCKS)
		{
			NAME = _NAME.Trim();
			int result;
			if (int.TryParse(_ELITEPARTSMIN, out result))
			{
				ELITEPARTSMIN = result;
			}
			else
			{
				Debug.LogError("Failed To Convert ELITEPARTSMIN string: " + _ELITEPARTSMIN + " to int");
			}
			int result2;
			if (int.TryParse(_ELITEPARTSMAX, out result2))
			{
				ELITEPARTSMAX = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert ELITEPARTSMAX string: " + _ELITEPARTSMAX + " to int");
			}
			int result3;
			if (int.TryParse(_TICKETSMIN, out result3))
			{
				TICKETSMIN = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert TICKETSMIN string: " + _TICKETSMIN + " to int");
			}
			int result4;
			if (int.TryParse(_TICKETSMAX, out result4))
			{
				TICKETSMAX = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert TICKETSMAX string: " + _TICKETSMAX + " to int");
			}
			int result5;
			if (int.TryParse(_SCRAPSMIN, out result5))
			{
				SCRAPSMIN = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert SCRAPSMIN string: " + _SCRAPSMIN + " to int");
			}
			int result6;
			if (int.TryParse(_SCRAPSMAX, out result6))
			{
				SCRAPSMAX = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert SCRAPSMAX string: " + _SCRAPSMAX + " to int");
			}
			int result7;
			if (int.TryParse(_GOLDMIN, out result7))
			{
				GOLDMIN = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert GOLDMIN string: " + _GOLDMIN + " to int");
			}
			int result8;
			if (int.TryParse(_GOLDMAX, out result8))
			{
				GOLDMAX = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert GOLDMAX string: " + _GOLDMAX + " to int");
			}
			int result9;
			if (int.TryParse(_WARBUCKS, out result9))
			{
				WARBUCKS = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert WARBUCKS string: " + _WARBUCKS + " to int");
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
				result = ELITEPARTSMIN.ToString();
				break;
			case 2:
				result = ELITEPARTSMAX.ToString();
				break;
			case 3:
				result = TICKETSMIN.ToString();
				break;
			case 4:
				result = TICKETSMAX.ToString();
				break;
			case 5:
				result = SCRAPSMIN.ToString();
				break;
			case 6:
				result = SCRAPSMAX.ToString();
				break;
			case 7:
				result = GOLDMIN.ToString();
				break;
			case 8:
				result = GOLDMAX.ToString();
				break;
			case 9:
				result = WARBUCKS.ToString();
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
			case "ELITEPARTSMIN":
				result = ELITEPARTSMIN.ToString();
				break;
			case "ELITEPARTSMAX":
				result = ELITEPARTSMAX.ToString();
				break;
			case "TICKETSMIN":
				result = TICKETSMIN.ToString();
				break;
			case "TICKETSMAX":
				result = TICKETSMAX.ToString();
				break;
			case "SCRAPSMIN":
				result = SCRAPSMIN.ToString();
				break;
			case "SCRAPSMAX":
				result = SCRAPSMAX.ToString();
				break;
			case "GOLDMIN":
				result = GOLDMIN.ToString();
				break;
			case "GOLDMAX":
				result = GOLDMAX.ToString();
				break;
			case "WARBUCKS":
				result = WARBUCKS.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{NAME : " + NAME.ToString() + "} ";
			empty = empty + "{ELITEPARTSMIN : " + ELITEPARTSMIN + "} ";
			empty = empty + "{ELITEPARTSMAX : " + ELITEPARTSMAX + "} ";
			empty = empty + "{TICKETSMIN : " + TICKETSMIN + "} ";
			empty = empty + "{TICKETSMAX : " + TICKETSMAX + "} ";
			empty = empty + "{SCRAPSMIN : " + SCRAPSMIN + "} ";
			empty = empty + "{SCRAPSMAX : " + SCRAPSMAX + "} ";
			empty = empty + "{GOLDMIN : " + GOLDMIN + "} ";
			empty = empty + "{GOLDMAX : " + GOLDMAX + "} ";
			return empty + "{WARBUCKS : " + WARBUCKS + "} ";
		}
	}
}
