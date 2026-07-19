using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class MissionsRewardsRow : IGoogle2uRow
	{
		public int LEVEL;

		public int DAILYGOLD;

		public int DAILYTICKETS;

		public int DAILYSCRAPS;

		public int DAILYBRONZECARDS;

		public int DAILYSILVERCARDS;

		public int DAILYGOLDCARDS;

		public int HEROICGOLDMISSION;

		public int HEROICGOLD;

		public int HEROICTICKETS;

		public int HEROICSCRAPS;

		public int HEROICBRONZEPACK;

		public int HEROICSILVERPACK;

		public int HEROICGOLDPACK;

		public int HEROICELITEPARTS;

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

		public int Get_DAILYGOLD
		{
			get
			{
				return DAILYGOLD;
			}
			set
			{
				DAILYGOLD = value;
			}
		}

		public int Get_DAILYTICKETS
		{
			get
			{
				return DAILYTICKETS;
			}
			set
			{
				DAILYTICKETS = value;
			}
		}

		public int Get_DAILYSCRAPS
		{
			get
			{
				return DAILYSCRAPS;
			}
			set
			{
				DAILYSCRAPS = value;
			}
		}

		public int Get_DAILYBRONZECARDS
		{
			get
			{
				return DAILYBRONZECARDS;
			}
			set
			{
				DAILYBRONZECARDS = value;
			}
		}

		public int Get_DAILYSILVERCARDS
		{
			get
			{
				return DAILYSILVERCARDS;
			}
			set
			{
				DAILYSILVERCARDS = value;
			}
		}

		public int Get_DAILYGOLDCARDS
		{
			get
			{
				return DAILYGOLDCARDS;
			}
			set
			{
				DAILYGOLDCARDS = value;
			}
		}

		public int Get_HEROICGOLDMISSION
		{
			get
			{
				return HEROICGOLDMISSION;
			}
			set
			{
				HEROICGOLDMISSION = value;
			}
		}

		public int Get_HEROICGOLD
		{
			get
			{
				return HEROICGOLD;
			}
			set
			{
				HEROICGOLD = value;
			}
		}

		public int Get_HEROICTICKETS
		{
			get
			{
				return HEROICTICKETS;
			}
			set
			{
				HEROICTICKETS = value;
			}
		}

		public int Get_HEROICSCRAPS
		{
			get
			{
				return HEROICSCRAPS;
			}
			set
			{
				HEROICSCRAPS = value;
			}
		}

		public int Get_HEROICBRONZEPACK
		{
			get
			{
				return HEROICBRONZEPACK;
			}
			set
			{
				HEROICBRONZEPACK = value;
			}
		}

		public int Get_HEROICSILVERPACK
		{
			get
			{
				return HEROICSILVERPACK;
			}
			set
			{
				HEROICSILVERPACK = value;
			}
		}

		public int Get_HEROICGOLDPACK
		{
			get
			{
				return HEROICGOLDPACK;
			}
			set
			{
				HEROICGOLDPACK = value;
			}
		}

		public int Get_HEROICELITEPARTS
		{
			get
			{
				return HEROICELITEPARTS;
			}
			set
			{
				HEROICELITEPARTS = value;
			}
		}

		public int Length
		{
			get
			{
				return 15;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public MissionsRewardsRow()
		{
		}

		public MissionsRewardsRow(string _ID, string _LEVEL, string _DAILYGOLD, string _DAILYTICKETS, string _DAILYSCRAPS, string _DAILYBRONZECARDS, string _DAILYSILVERCARDS, string _DAILYGOLDCARDS, string _HEROICGOLDMISSION, string _HEROICGOLD, string _HEROICTICKETS, string _HEROICSCRAPS, string _HEROICBRONZEPACK, string _HEROICSILVERPACK, string _HEROICGOLDPACK, string _HEROICELITEPARTS)
		{
			int result;
			if (int.TryParse(_LEVEL, out result))
			{
				LEVEL = result;
			}
			else
			{
				Debug.LogError("Failed To Convert LEVEL string: " + _LEVEL + " to int");
			}
			int result2;
			if (int.TryParse(_DAILYGOLD, out result2))
			{
				DAILYGOLD = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYGOLD string: " + _DAILYGOLD + " to int");
			}
			int result3;
			if (int.TryParse(_DAILYTICKETS, out result3))
			{
				DAILYTICKETS = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYTICKETS string: " + _DAILYTICKETS + " to int");
			}
			int result4;
			if (int.TryParse(_DAILYSCRAPS, out result4))
			{
				DAILYSCRAPS = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYSCRAPS string: " + _DAILYSCRAPS + " to int");
			}
			int result5;
			if (int.TryParse(_DAILYBRONZECARDS, out result5))
			{
				DAILYBRONZECARDS = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYBRONZECARDS string: " + _DAILYBRONZECARDS + " to int");
			}
			int result6;
			if (int.TryParse(_DAILYSILVERCARDS, out result6))
			{
				DAILYSILVERCARDS = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYSILVERCARDS string: " + _DAILYSILVERCARDS + " to int");
			}
			int result7;
			if (int.TryParse(_DAILYGOLDCARDS, out result7))
			{
				DAILYGOLDCARDS = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYGOLDCARDS string: " + _DAILYGOLDCARDS + " to int");
			}
			int result8;
			if (int.TryParse(_HEROICGOLDMISSION, out result8))
			{
				HEROICGOLDMISSION = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICGOLDMISSION string: " + _HEROICGOLDMISSION + " to int");
			}
			int result9;
			if (int.TryParse(_HEROICGOLD, out result9))
			{
				HEROICGOLD = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICGOLD string: " + _HEROICGOLD + " to int");
			}
			int result10;
			if (int.TryParse(_HEROICTICKETS, out result10))
			{
				HEROICTICKETS = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICTICKETS string: " + _HEROICTICKETS + " to int");
			}
			int result11;
			if (int.TryParse(_HEROICSCRAPS, out result11))
			{
				HEROICSCRAPS = result11;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICSCRAPS string: " + _HEROICSCRAPS + " to int");
			}
			int result12;
			if (int.TryParse(_HEROICBRONZEPACK, out result12))
			{
				HEROICBRONZEPACK = result12;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICBRONZEPACK string: " + _HEROICBRONZEPACK + " to int");
			}
			int result13;
			if (int.TryParse(_HEROICSILVERPACK, out result13))
			{
				HEROICSILVERPACK = result13;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICSILVERPACK string: " + _HEROICSILVERPACK + " to int");
			}
			int result14;
			if (int.TryParse(_HEROICGOLDPACK, out result14))
			{
				HEROICGOLDPACK = result14;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICGOLDPACK string: " + _HEROICGOLDPACK + " to int");
			}
			int result15;
			if (int.TryParse(_HEROICELITEPARTS, out result15))
			{
				HEROICELITEPARTS = result15;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICELITEPARTS string: " + _HEROICELITEPARTS + " to int");
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
				result = DAILYGOLD.ToString();
				break;
			case 2:
				result = DAILYTICKETS.ToString();
				break;
			case 3:
				result = DAILYSCRAPS.ToString();
				break;
			case 4:
				result = DAILYBRONZECARDS.ToString();
				break;
			case 5:
				result = DAILYSILVERCARDS.ToString();
				break;
			case 6:
				result = DAILYGOLDCARDS.ToString();
				break;
			case 7:
				result = HEROICGOLDMISSION.ToString();
				break;
			case 8:
				result = HEROICGOLD.ToString();
				break;
			case 9:
				result = HEROICTICKETS.ToString();
				break;
			case 10:
				result = HEROICSCRAPS.ToString();
				break;
			case 11:
				result = HEROICBRONZEPACK.ToString();
				break;
			case 12:
				result = HEROICSILVERPACK.ToString();
				break;
			case 13:
				result = HEROICGOLDPACK.ToString();
				break;
			case 14:
				result = HEROICELITEPARTS.ToString();
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
			case "DAILYGOLD":
				result = DAILYGOLD.ToString();
				break;
			case "DAILYTICKETS":
				result = DAILYTICKETS.ToString();
				break;
			case "DAILYSCRAPS":
				result = DAILYSCRAPS.ToString();
				break;
			case "DAILYBRONZECARDS":
				result = DAILYBRONZECARDS.ToString();
				break;
			case "DAILYSILVERCARDS":
				result = DAILYSILVERCARDS.ToString();
				break;
			case "DAILYGOLDCARDS":
				result = DAILYGOLDCARDS.ToString();
				break;
			case "HEROICGOLDMISSION":
				result = HEROICGOLDMISSION.ToString();
				break;
			case "HEROICGOLD":
				result = HEROICGOLD.ToString();
				break;
			case "HEROICTICKETS":
				result = HEROICTICKETS.ToString();
				break;
			case "HEROICSCRAPS":
				result = HEROICSCRAPS.ToString();
				break;
			case "HEROICBRONZEPACK":
				result = HEROICBRONZEPACK.ToString();
				break;
			case "HEROICSILVERPACK":
				result = HEROICSILVERPACK.ToString();
				break;
			case "HEROICGOLDPACK":
				result = HEROICGOLDPACK.ToString();
				break;
			case "HEROICELITEPARTS":
				result = HEROICELITEPARTS.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{LEVEL : " + LEVEL + "} ";
			empty = empty + "{DAILYGOLD : " + DAILYGOLD + "} ";
			empty = empty + "{DAILYTICKETS : " + DAILYTICKETS + "} ";
			empty = empty + "{DAILYSCRAPS : " + DAILYSCRAPS + "} ";
			empty = empty + "{DAILYBRONZECARDS : " + DAILYBRONZECARDS + "} ";
			empty = empty + "{DAILYSILVERCARDS : " + DAILYSILVERCARDS + "} ";
			empty = empty + "{DAILYGOLDCARDS : " + DAILYGOLDCARDS + "} ";
			empty = empty + "{HEROICGOLDMISSION : " + HEROICGOLDMISSION + "} ";
			empty = empty + "{HEROICGOLD : " + HEROICGOLD + "} ";
			empty = empty + "{HEROICTICKETS : " + HEROICTICKETS + "} ";
			empty = empty + "{HEROICSCRAPS : " + HEROICSCRAPS + "} ";
			empty = empty + "{HEROICBRONZEPACK : " + HEROICBRONZEPACK + "} ";
			empty = empty + "{HEROICSILVERPACK : " + HEROICSILVERPACK + "} ";
			empty = empty + "{HEROICGOLDPACK : " + HEROICGOLDPACK + "} ";
			return empty + "{HEROICELITEPARTS : " + HEROICELITEPARTS + "} ";
		}
	}
}
