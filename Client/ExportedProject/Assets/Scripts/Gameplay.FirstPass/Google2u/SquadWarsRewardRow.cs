using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class SquadWarsRewardRow : IGoogle2uRow
	{
		public string MEMBERPOSITION;

		public int FRACTION;

		public string Get_MEMBERPOSITION
		{
			get
			{
				return MEMBERPOSITION;
			}
			set
			{
				MEMBERPOSITION = value;
			}
		}

		public int Get_FRACTION
		{
			get
			{
				return FRACTION;
			}
			set
			{
				FRACTION = value;
			}
		}

		public int Length => 2;

		public string this[int i] => GetStringDataByIndex(i);

		public SquadWarsRewardRow()
		{
		}

		public SquadWarsRewardRow(string _ID, string _MEMBERPOSITION, string _FRACTION)
		{
			MEMBERPOSITION = _MEMBERPOSITION.Trim();
			if (int.TryParse(_FRACTION, out var result))
			{
				FRACTION = result;
			}
			else
			{
				Debug.LogError("Failed To Convert FRACTION string: " + _FRACTION + " to int");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = MEMBERPOSITION.ToString();
				break;
			case 1:
				result = FRACTION.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "MEMBERPOSITION":
				result = MEMBERPOSITION.ToString();
				break;
			case "FRACTION":
				result = FRACTION.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{MEMBERPOSITION : " + MEMBERPOSITION.ToString() + "} ";
			return empty + "{FRACTION : " + FRACTION + "} ";
		}
	}
}
