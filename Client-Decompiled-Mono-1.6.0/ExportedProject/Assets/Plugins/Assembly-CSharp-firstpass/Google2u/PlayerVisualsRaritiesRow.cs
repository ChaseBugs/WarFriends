using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class PlayerVisualsRaritiesRow : IGoogle2uRow
	{
		public int VALUE;

		public float PROBABILITY;

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

		public float Get_PROBABILITY
		{
			get
			{
				return PROBABILITY;
			}
			set
			{
				PROBABILITY = value;
			}
		}

		public int Length
		{
			get
			{
				return 2;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public PlayerVisualsRaritiesRow()
		{
		}

		public PlayerVisualsRaritiesRow(string _ID, string _VALUE, string _PROBABILITY)
		{
			int result;
			if (int.TryParse(_VALUE, out result))
			{
				VALUE = result;
			}
			else
			{
				Debug.LogError("Failed To Convert VALUE string: " + _VALUE + " to int");
			}
			float result2;
			if (float.TryParse(_PROBABILITY, out result2))
			{
				PROBABILITY = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert PROBABILITY string: " + _PROBABILITY + " to float");
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
				result = PROBABILITY.ToString();
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
			case "PROBABILITY":
				result = PROBABILITY.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{VALUE : " + VALUE + "} ";
			return empty + "{PROBABILITY : " + PROBABILITY + "} ";
		}
	}
}
