using System;
using UnityEngine;
using UnityEngine.Serialization;

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

		[FormerlySerializedAs("DAILYAUGCRATES")]
		public int HEROICGOLDMISSION;

		[FormerlySerializedAs("HEROICGOLDMISSION")]
		public int HEROICGOLD;

		[FormerlySerializedAs("HEROICGOLD")]
		public int HEROICTICKETS;

		[FormerlySerializedAs("HEROICTICKETS")]
		public int HEROICSCRAPS;

		[FormerlySerializedAs("HEROICSCRAPS")]
		public int HEROICBRONZEPACK;

		[FormerlySerializedAs("HEROICBRONZEPACK")]
		public int HEROICSILVERPACK;

		[FormerlySerializedAs("HEROICSILVERPACK")]
		public int HEROICGOLDPACK;

		[FormerlySerializedAs("HEROICGOLDPACK")]
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

		public int Length => 15;

		public string this[int i] => GetStringDataByIndex(i);

		public MissionsRewardsRow()
		{
		}

		public MissionsRewardsRow(string _ID, string _LEVEL, string _DAILYGOLD, string _DAILYTICKETS, string _DAILYSCRAPS, string _DAILYBRONZECARDS, string _DAILYSILVERCARDS, string _DAILYGOLDCARDS, string _HEROICGOLDMISSION, string _HEROICGOLD, string _HEROICTICKETS, string _HEROICSCRAPS, string _HEROICBRONZEPACK, string _HEROICSILVERPACK, string _HEROICGOLDPACK, string _HEROICELITEPARTS)
		{
			if (int.TryParse(_LEVEL, out var result))
			{
				LEVEL = result;
			}
			else
			{
				Debug.LogError("Failed To Convert LEVEL string: " + _LEVEL + " to int");
			}
			if (int.TryParse(_DAILYGOLD, out var result2))
			{
				DAILYGOLD = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYGOLD string: " + _DAILYGOLD + " to int");
			}
			if (int.TryParse(_DAILYTICKETS, out var result3))
			{
				DAILYTICKETS = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYTICKETS string: " + _DAILYTICKETS + " to int");
			}
			if (int.TryParse(_DAILYSCRAPS, out var result4))
			{
				DAILYSCRAPS = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYSCRAPS string: " + _DAILYSCRAPS + " to int");
			}
			if (int.TryParse(_DAILYBRONZECARDS, out var result5))
			{
				DAILYBRONZECARDS = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYBRONZECARDS string: " + _DAILYBRONZECARDS + " to int");
			}
			if (int.TryParse(_DAILYSILVERCARDS, out var result6))
			{
				DAILYSILVERCARDS = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYSILVERCARDS string: " + _DAILYSILVERCARDS + " to int");
			}
			if (int.TryParse(_DAILYGOLDCARDS, out var result7))
			{
				DAILYGOLDCARDS = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILYGOLDCARDS string: " + _DAILYGOLDCARDS + " to int");
			}
			if (int.TryParse(_HEROICGOLDMISSION, out var result8))
			{
				HEROICGOLDMISSION = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICGOLDMISSION string: " + _HEROICGOLDMISSION + " to int");
			}
			if (int.TryParse(_HEROICGOLD, out var result9))
			{
				HEROICGOLD = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICGOLD string: " + _HEROICGOLD + " to int");
			}
			if (int.TryParse(_HEROICTICKETS, out var result10))
			{
				HEROICTICKETS = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICTICKETS string: " + _HEROICTICKETS + " to int");
			}
			if (int.TryParse(_HEROICSCRAPS, out var result11))
			{
				HEROICSCRAPS = result11;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICSCRAPS string: " + _HEROICSCRAPS + " to int");
			}
			if (int.TryParse(_HEROICBRONZEPACK, out var result12))
			{
				HEROICBRONZEPACK = result12;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICBRONZEPACK string: " + _HEROICBRONZEPACK + " to int");
			}
			if (int.TryParse(_HEROICSILVERPACK, out var result13))
			{
				HEROICSILVERPACK = result13;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICSILVERPACK string: " + _HEROICSILVERPACK + " to int");
			}
			if (int.TryParse(_HEROICGOLDPACK, out var result14))
			{
				HEROICGOLDPACK = result14;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROICGOLDPACK string: " + _HEROICGOLDPACK + " to int");
			}
			if (int.TryParse(_HEROICELITEPARTS, out var result15))
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
