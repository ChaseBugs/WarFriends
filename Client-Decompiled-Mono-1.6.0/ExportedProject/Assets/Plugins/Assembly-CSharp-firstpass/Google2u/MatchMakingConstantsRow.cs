using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class MatchMakingConstantsRow : IGoogle2uRow
	{
		public float FLOATVALUE;

		public float Get_FLOATVALUE
		{
			get
			{
				return FLOATVALUE;
			}
			set
			{
				FLOATVALUE = value;
			}
		}

		public int Length
		{
			get
			{
				return 1;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public MatchMakingConstantsRow()
		{
		}

		public MatchMakingConstantsRow(string _NAME, string _FLOATVALUE)
		{
			float result;
			if (float.TryParse(_FLOATVALUE, out result))
			{
				FLOATVALUE = result;
			}
			else
			{
				Debug.LogError("Failed To Convert FLOATVALUE string: " + _FLOATVALUE + " to float");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			if (index == 0)
			{
				result = FLOATVALUE.ToString();
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			if (colID != null && colID == "FLOATVALUE")
			{
				result = FLOATVALUE.ToString();
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			return empty + "{FLOATVALUE : " + FLOATVALUE + "} ";
		}
	}
}
