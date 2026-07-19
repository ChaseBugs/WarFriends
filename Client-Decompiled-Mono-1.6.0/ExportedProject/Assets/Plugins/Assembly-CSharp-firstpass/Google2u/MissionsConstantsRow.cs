using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class MissionsConstantsRow : IGoogle2uRow
	{
		public float VALUE;

		public string DBKEY;

		public float Get_VALUE
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

		public MissionsConstantsRow()
		{
		}

		public MissionsConstantsRow(string _ID, string _VALUE, string _DBKEY)
		{
			float result;
			if (float.TryParse(_VALUE, out result))
			{
				VALUE = result;
			}
			else
			{
				Debug.LogError("Failed To Convert VALUE string: " + _VALUE + " to float");
			}
			DBKEY = _DBKEY.Trim();
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
			case "VALUE":
				result = VALUE.ToString();
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
			empty = empty + "{VALUE : " + VALUE + "} ";
			return empty + "{DBKEY : " + DBKEY.ToString() + "} ";
		}
	}
}
