using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class StarterAssignmentsRow : IGoogle2uRow
	{
		public int VALUE;

		public int REWARDWB;

		public int REWARDGOLD;

		public int ORDER;

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

		public int Get_ORDER
		{
			get
			{
				return ORDER;
			}
			set
			{
				ORDER = value;
			}
		}

		public int Length => 4;

		public string this[int i] => GetStringDataByIndex(i);

		public StarterAssignmentsRow()
		{
		}

		public StarterAssignmentsRow(string _ID, string _VALUE, string _REWARDWB, string _REWARDGOLD, string _ORDER)
		{
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
			if (int.TryParse(_ORDER, out var result4))
			{
				ORDER = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert ORDER string: " + _ORDER + " to int");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = VALUE.ToString();
				break;
			case 1:
				result = REWARDWB.ToString();
				break;
			case 2:
				result = REWARDGOLD.ToString();
				break;
			case 3:
				result = ORDER.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "VALUE":
				result = VALUE.ToString();
				break;
			case "REWARDWB":
				result = REWARDWB.ToString();
				break;
			case "REWARDGOLD":
				result = REWARDGOLD.ToString();
				break;
			case "ORDER":
				result = ORDER.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{VALUE : " + VALUE + "} ";
			empty = empty + "{REWARDWB : " + REWARDWB + "} ";
			empty = empty + "{REWARDGOLD : " + REWARDGOLD + "} ";
			return empty + "{ORDER : " + ORDER + "} ";
		}
	}
}
