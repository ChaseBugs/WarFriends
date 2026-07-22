using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class PlayerLeaderboardsRow : IGoogle2uRow
	{
		public int DBID;

		public int REWARDWARBUCKS;

		public int REWARDSQUADPOINTS;

		public float WINFACTOR;

		public float LOSEFACTOR;

		public int NOTENOUGHTPLAYERSGOLDREWARD;

		public int DURATION;

		public float GOUP;

		public float GODOWN;

		public string NAME;

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

		public int Get_REWARDWARBUCKS
		{
			get
			{
				return REWARDWARBUCKS;
			}
			set
			{
				REWARDWARBUCKS = value;
			}
		}

		public int Get_REWARDSQUADPOINTS
		{
			get
			{
				return REWARDSQUADPOINTS;
			}
			set
			{
				REWARDSQUADPOINTS = value;
			}
		}

		public float Get_WINFACTOR
		{
			get
			{
				return WINFACTOR;
			}
			set
			{
				WINFACTOR = value;
			}
		}

		public float Get_LOSEFACTOR
		{
			get
			{
				return LOSEFACTOR;
			}
			set
			{
				LOSEFACTOR = value;
			}
		}

		public int Get_NOTENOUGHTPLAYERSGOLDREWARD
		{
			get
			{
				return NOTENOUGHTPLAYERSGOLDREWARD;
			}
			set
			{
				NOTENOUGHTPLAYERSGOLDREWARD = value;
			}
		}

		public int Get_DURATION
		{
			get
			{
				return DURATION;
			}
			set
			{
				DURATION = value;
			}
		}

		public float Get_GOUP
		{
			get
			{
				return GOUP;
			}
			set
			{
				GOUP = value;
			}
		}

		public float Get_GODOWN
		{
			get
			{
				return GODOWN;
			}
			set
			{
				GODOWN = value;
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

		public int Length => 10;

		public string this[int i] => GetStringDataByIndex(i);

		public PlayerLeaderboardsRow()
		{
		}

		public PlayerLeaderboardsRow(string _ID, string _DBID, string _REWARDWARBUCKS, string _REWARDSQUADPOINTS, string _WINFACTOR, string _LOSEFACTOR, string _NOTENOUGHTPLAYERSGOLDREWARD, string _DURATION, string _GOUP, string _GODOWN, string _NAME)
		{
			if (int.TryParse(_DBID, out var result))
			{
				DBID = result;
			}
			else
			{
				Debug.LogError("Failed To Convert DBID string: " + _DBID + " to int");
			}
			if (int.TryParse(_REWARDWARBUCKS, out var result2))
			{
				REWARDWARBUCKS = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDWARBUCKS string: " + _REWARDWARBUCKS + " to int");
			}
			if (int.TryParse(_REWARDSQUADPOINTS, out var result3))
			{
				REWARDSQUADPOINTS = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDSQUADPOINTS string: " + _REWARDSQUADPOINTS + " to int");
			}
			if (float.TryParse(_WINFACTOR, out var result4))
			{
				WINFACTOR = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert WINFACTOR string: " + _WINFACTOR + " to float");
			}
			if (float.TryParse(_LOSEFACTOR, out var result5))
			{
				LOSEFACTOR = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert LOSEFACTOR string: " + _LOSEFACTOR + " to float");
			}
			if (int.TryParse(_NOTENOUGHTPLAYERSGOLDREWARD, out var result6))
			{
				NOTENOUGHTPLAYERSGOLDREWARD = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert NOTENOUGHTPLAYERSGOLDREWARD string: " + _NOTENOUGHTPLAYERSGOLDREWARD + " to int");
			}
			if (int.TryParse(_DURATION, out var result7))
			{
				DURATION = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert DURATION string: " + _DURATION + " to int");
			}
			if (float.TryParse(_GOUP, out var result8))
			{
				GOUP = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert GOUP string: " + _GOUP + " to float");
			}
			if (float.TryParse(_GODOWN, out var result9))
			{
				GODOWN = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert GODOWN string: " + _GODOWN + " to float");
			}
			NAME = _NAME.Trim();
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
				result = REWARDWARBUCKS.ToString();
				break;
			case 2:
				result = REWARDSQUADPOINTS.ToString();
				break;
			case 3:
				result = WINFACTOR.ToString();
				break;
			case 4:
				result = LOSEFACTOR.ToString();
				break;
			case 5:
				result = NOTENOUGHTPLAYERSGOLDREWARD.ToString();
				break;
			case 6:
				result = DURATION.ToString();
				break;
			case 7:
				result = GOUP.ToString();
				break;
			case 8:
				result = GODOWN.ToString();
				break;
			case 9:
				result = NAME.ToString();
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
			case "REWARDWARBUCKS":
				result = REWARDWARBUCKS.ToString();
				break;
			case "REWARDSQUADPOINTS":
				result = REWARDSQUADPOINTS.ToString();
				break;
			case "WINFACTOR":
				result = WINFACTOR.ToString();
				break;
			case "LOSEFACTOR":
				result = LOSEFACTOR.ToString();
				break;
			case "NOTENOUGHTPLAYERSGOLDREWARD":
				result = NOTENOUGHTPLAYERSGOLDREWARD.ToString();
				break;
			case "DURATION":
				result = DURATION.ToString();
				break;
			case "GOUP":
				result = GOUP.ToString();
				break;
			case "GODOWN":
				result = GODOWN.ToString();
				break;
			case "NAME":
				result = NAME.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{DBID : " + DBID + "} ";
			empty = empty + "{REWARDWARBUCKS : " + REWARDWARBUCKS + "} ";
			empty = empty + "{REWARDSQUADPOINTS : " + REWARDSQUADPOINTS + "} ";
			empty = empty + "{WINFACTOR : " + WINFACTOR + "} ";
			empty = empty + "{LOSEFACTOR : " + LOSEFACTOR + "} ";
			empty = empty + "{NOTENOUGHTPLAYERSGOLDREWARD : " + NOTENOUGHTPLAYERSGOLDREWARD + "} ";
			empty = empty + "{DURATION : " + DURATION + "} ";
			empty = empty + "{GOUP : " + GOUP + "} ";
			empty = empty + "{GODOWN : " + GODOWN + "} ";
			return empty + "{NAME : " + NAME.ToString() + "} ";
		}
	}
}
