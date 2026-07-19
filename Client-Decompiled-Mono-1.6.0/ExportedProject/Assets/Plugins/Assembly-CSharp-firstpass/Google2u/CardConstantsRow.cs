using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class CardConstantsRow : IGoogle2uRow
	{
		public float FLOATVALUE;

		public string DBKEY;

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

		public string Get_DBKEY
		{
			get
			{
				return DBKEY;
			}
			set
			{
				DBKEY = value;
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

		public CardConstantsRow()
		{
		}

		public CardConstantsRow(string _NAME, string _FLOATVALUE, string _DBKEY)
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
			DBKEY = _DBKEY.Trim();
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = FLOATVALUE.ToString();
				break;
			case 1:
				result = DBKEY.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "FLOATVALUE":
				result = FLOATVALUE.ToString();
				break;
			case "DBKEY":
				result = DBKEY.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{FLOATVALUE : " + FLOATVALUE + "} ";
			return empty + "{DBKEY : " + DBKEY.ToString() + "} ";
		}
	}
}
