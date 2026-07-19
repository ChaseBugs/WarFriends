using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class SquadLeaderboardsRow : IGoogle2uRow
	{
		public int DBID;

		public int TIER1REWARD;

		public int TIER2REWARD;

		public int TIER3REWARD;

		public int TIER4REWARD;

		public int TIER5REWARD;

		public float GOUPPERCENTAGE;

		public float GODOWNPERCENTAGE;

		public int Get_DBID
		{
			get
			{
				return DBID;
			}
			set
			{
				DBID = value;
			}
		}

		public int Get_TIER1REWARD
		{
			get
			{
				return TIER1REWARD;
			}
			set
			{
				TIER1REWARD = value;
			}
		}

		public int Get_TIER2REWARD
		{
			get
			{
				return TIER2REWARD;
			}
			set
			{
				TIER2REWARD = value;
			}
		}

		public int Get_TIER3REWARD
		{
			get
			{
				return TIER3REWARD;
			}
			set
			{
				TIER3REWARD = value;
			}
		}

		public int Get_TIER4REWARD
		{
			get
			{
				return TIER4REWARD;
			}
			set
			{
				TIER4REWARD = value;
			}
		}

		public int Get_TIER5REWARD
		{
			get
			{
				return TIER5REWARD;
			}
			set
			{
				TIER5REWARD = value;
			}
		}

		public float Get_GOUPPERCENTAGE
		{
			get
			{
				return GOUPPERCENTAGE;
			}
			set
			{
				GOUPPERCENTAGE = value;
			}
		}

		public float Get_GODOWNPERCENTAGE
		{
			get
			{
				return GODOWNPERCENTAGE;
			}
			set
			{
				GODOWNPERCENTAGE = value;
			}
		}

		public int Length
		{
			get
			{
				return 8;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public SquadLeaderboardsRow()
		{
		}

		public SquadLeaderboardsRow(string _ID, string _DBID, string _TIER1REWARD, string _TIER2REWARD, string _TIER3REWARD, string _TIER4REWARD, string _TIER5REWARD, string _GOUPPERCENTAGE, string _GODOWNPERCENTAGE)
		{
			int result;
			if (int.TryParse(_DBID, out result))
			{
				DBID = result;
			}
			else
			{
				Debug.LogError("Failed To Convert DBID string: " + _DBID + " to int");
			}
			int result2;
			if (int.TryParse(_TIER1REWARD, out result2))
			{
				TIER1REWARD = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert TIER1REWARD string: " + _TIER1REWARD + " to int");
			}
			int result3;
			if (int.TryParse(_TIER2REWARD, out result3))
			{
				TIER2REWARD = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert TIER2REWARD string: " + _TIER2REWARD + " to int");
			}
			int result4;
			if (int.TryParse(_TIER3REWARD, out result4))
			{
				TIER3REWARD = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert TIER3REWARD string: " + _TIER3REWARD + " to int");
			}
			int result5;
			if (int.TryParse(_TIER4REWARD, out result5))
			{
				TIER4REWARD = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert TIER4REWARD string: " + _TIER4REWARD + " to int");
			}
			int result6;
			if (int.TryParse(_TIER5REWARD, out result6))
			{
				TIER5REWARD = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert TIER5REWARD string: " + _TIER5REWARD + " to int");
			}
			float result7;
			if (float.TryParse(_GOUPPERCENTAGE, out result7))
			{
				GOUPPERCENTAGE = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert GOUPPERCENTAGE string: " + _GOUPPERCENTAGE + " to float");
			}
			float result8;
			if (float.TryParse(_GODOWNPERCENTAGE, out result8))
			{
				GODOWNPERCENTAGE = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert GODOWNPERCENTAGE string: " + _GODOWNPERCENTAGE + " to float");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = DBID.ToString();
				break;
			case 1:
				result = TIER1REWARD.ToString();
				break;
			case 2:
				result = TIER2REWARD.ToString();
				break;
			case 3:
				result = TIER3REWARD.ToString();
				break;
			case 4:
				result = TIER4REWARD.ToString();
				break;
			case 5:
				result = TIER5REWARD.ToString();
				break;
			case 6:
				result = GOUPPERCENTAGE.ToString();
				break;
			case 7:
				result = GODOWNPERCENTAGE.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "DBID":
				result = DBID.ToString();
				break;
			case "TIER1REWARD":
				result = TIER1REWARD.ToString();
				break;
			case "TIER2REWARD":
				result = TIER2REWARD.ToString();
				break;
			case "TIER3REWARD":
				result = TIER3REWARD.ToString();
				break;
			case "TIER4REWARD":
				result = TIER4REWARD.ToString();
				break;
			case "TIER5REWARD":
				result = TIER5REWARD.ToString();
				break;
			case "GOUPPERCENTAGE":
				result = GOUPPERCENTAGE.ToString();
				break;
			case "GODOWNPERCENTAGE":
				result = GODOWNPERCENTAGE.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{DBID : " + DBID + "} ";
			empty = empty + "{TIER1REWARD : " + TIER1REWARD + "} ";
			empty = empty + "{TIER2REWARD : " + TIER2REWARD + "} ";
			empty = empty + "{TIER3REWARD : " + TIER3REWARD + "} ";
			empty = empty + "{TIER4REWARD : " + TIER4REWARD + "} ";
			empty = empty + "{TIER5REWARD : " + TIER5REWARD + "} ";
			empty = empty + "{GOUPPERCENTAGE : " + GOUPPERCENTAGE + "} ";
			return empty + "{GODOWNPERCENTAGE : " + GODOWNPERCENTAGE + "} ";
		}
	}
}
