using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class AchievementsRow : IGoogle2uRow
	{
		public string CLASS;

		public int VALUE;

		public int REWARDWB;

		public int REWARDGOLD;

		public int REWARDSCRAPS;

		public int REWARDTICKETS;

		public int GROUPID;

		public string ANDROIDID;

		public string ANDROIDIDCHILL;

		public string IOSID;

		public string DESCRIPTION;

		public string GUITITLE;

		public string GUIDESCRIPTION;

		public string Get_CLASS
		{
			get
			{
				return CLASS;
			}
			set
			{
				CLASS = value;
			}
		}

		public int Get_VALUE
		{
			get
			{
				return VALUE;
			}
			set
			{
				VALUE = value;
			}
		}

		public int Get_REWARDWB
		{
			get
			{
				return REWARDWB;
			}
			set
			{
				REWARDWB = value;
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

		public int Get_REWARDSCRAPS
		{
			get
			{
				return REWARDSCRAPS;
			}
			set
			{
				REWARDSCRAPS = value;
			}
		}

		public int Get_REWARDTICKETS
		{
			get
			{
				return REWARDTICKETS;
			}
			set
			{
				REWARDTICKETS = value;
			}
		}

		public int Get_GROUPID
		{
			get
			{
				return GROUPID;
			}
			set
			{
				GROUPID = value;
			}
		}

		public string Get_ANDROIDID
		{
			get
			{
				return ANDROIDID;
			}
			set
			{
				ANDROIDID = value;
			}
		}

		public string Get_ANDROIDIDCHILL
		{
			get
			{
				return ANDROIDIDCHILL;
			}
			set
			{
				ANDROIDIDCHILL = value;
			}
		}

		public string Get_IOSID
		{
			get
			{
				return IOSID;
			}
			set
			{
				IOSID = value;
			}
		}

		public string Get_DESCRIPTION
		{
			get
			{
				return DESCRIPTION;
			}
			set
			{
				DESCRIPTION = value;
			}
		}

		public string Get_GUITITLE
		{
			get
			{
				return GUITITLE;
			}
			set
			{
				GUITITLE = value;
			}
		}

		public string Get_GUIDESCRIPTION
		{
			get
			{
				return GUIDESCRIPTION;
			}
			set
			{
				GUIDESCRIPTION = value;
			}
		}

		public int Length => 13;

		public string this[int i] => GetStringDataByIndex(i);

		public AchievementsRow()
		{
		}

		public AchievementsRow(string _ID, string _CLASS, string _VALUE, string _REWARDWB, string _REWARDGOLD, string _REWARDSCRAPS, string _REWARDTICKETS, string _GROUPID, string _ANDROIDID, string _ANDROIDIDCHILL, string _IOSID, string _DESCRIPTION, string _GUITITLE, string _GUIDESCRIPTION)
		{
			CLASS = _CLASS.Trim();
			if (int.TryParse(_VALUE, out var result))
			{
				VALUE = result;
			}
			else
			{
				Debug.LogError("Failed To Convert VALUE string: " + _VALUE + " to int");
			}
			if (int.TryParse(_REWARDWB, out var result2))
			{
				REWARDWB = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDWB string: " + _REWARDWB + " to int");
			}
			if (int.TryParse(_REWARDGOLD, out var result3))
			{
				REWARDGOLD = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDGOLD string: " + _REWARDGOLD + " to int");
			}
			if (int.TryParse(_REWARDSCRAPS, out var result4))
			{
				REWARDSCRAPS = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDSCRAPS string: " + _REWARDSCRAPS + " to int");
			}
			if (int.TryParse(_REWARDTICKETS, out var result5))
			{
				REWARDTICKETS = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDTICKETS string: " + _REWARDTICKETS + " to int");
			}
			if (int.TryParse(_GROUPID, out var result6))
			{
				GROUPID = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert GROUPID string: " + _GROUPID + " to int");
			}
			ANDROIDID = _ANDROIDID.Trim();
			ANDROIDIDCHILL = _ANDROIDIDCHILL.Trim();
			IOSID = _IOSID.Trim();
			DESCRIPTION = _DESCRIPTION.Trim();
			GUITITLE = _GUITITLE.Trim();
			GUIDESCRIPTION = _GUIDESCRIPTION.Trim();
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = CLASS.ToString();
				break;
			case 1:
				result = VALUE.ToString();
				break;
			case 2:
				result = REWARDWB.ToString();
				break;
			case 3:
				result = REWARDGOLD.ToString();
				break;
			case 4:
				result = REWARDSCRAPS.ToString();
				break;
			case 5:
				result = REWARDTICKETS.ToString();
				break;
			case 6:
				result = GROUPID.ToString();
				break;
			case 7:
				result = ANDROIDID.ToString();
				break;
			case 8:
				result = ANDROIDIDCHILL.ToString();
				break;
			case 9:
				result = IOSID.ToString();
				break;
			case 10:
				result = DESCRIPTION.ToString();
				break;
			case 11:
				result = GUITITLE.ToString();
				break;
			case 12:
				result = GUIDESCRIPTION.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "CLASS":
				result = CLASS.ToString();
				break;
			case "VALUE":
				result = VALUE.ToString();
				break;
			case "REWARDWB":
				result = REWARDWB.ToString();
				break;
			case "REWARDGOLD":
				result = REWARDGOLD.ToString();
				break;
			case "REWARDSCRAPS":
				result = REWARDSCRAPS.ToString();
				break;
			case "REWARDTICKETS":
				result = REWARDTICKETS.ToString();
				break;
			case "GROUPID":
				result = GROUPID.ToString();
				break;
			case "ANDROIDID":
				result = ANDROIDID.ToString();
				break;
			case "ANDROIDIDCHILL":
				result = ANDROIDIDCHILL.ToString();
				break;
			case "IOSID":
				result = IOSID.ToString();
				break;
			case "DESCRIPTION":
				result = DESCRIPTION.ToString();
				break;
			case "GUITITLE":
				result = GUITITLE.ToString();
				break;
			case "GUIDESCRIPTION":
				result = GUIDESCRIPTION.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{CLASS : " + CLASS.ToString() + "} ";
			empty = empty + "{VALUE : " + VALUE + "} ";
			empty = empty + "{REWARDWB : " + REWARDWB + "} ";
			empty = empty + "{REWARDGOLD : " + REWARDGOLD + "} ";
			empty = empty + "{REWARDSCRAPS : " + REWARDSCRAPS + "} ";
			empty = empty + "{REWARDTICKETS : " + REWARDTICKETS + "} ";
			empty = empty + "{GROUPID : " + GROUPID + "} ";
			empty = empty + "{ANDROIDID : " + ANDROIDID.ToString() + "} ";
			empty = empty + "{ANDROIDIDCHILL : " + ANDROIDIDCHILL.ToString() + "} ";
			empty = empty + "{IOSID : " + IOSID.ToString() + "} ";
			empty = empty + "{DESCRIPTION : " + DESCRIPTION.ToString() + "} ";
			empty = empty + "{GUITITLE : " + GUITITLE.ToString() + "} ";
			return empty + "{GUIDESCRIPTION : " + GUIDESCRIPTION.ToString() + "} ";
		}
	}
}
