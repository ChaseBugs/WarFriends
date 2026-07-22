using System;

namespace Google2u
{
	[Serializable]
	public class StringConstantsRow : IGoogle2uRow
	{
		public string VALUE;

		public string DBKEY;

		public string Get_VALUE
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

		public int Length => 2;

		public string this[int i] => GetStringDataByIndex(i);

		public StringConstantsRow()
		{
		}

		public StringConstantsRow(string _ID, string _VALUE, string _DBKEY)
		{
			VALUE = _VALUE.Trim();
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
			empty = empty + "{VALUE : " + VALUE.ToString() + "} ";
			return empty + "{DBKEY : " + DBKEY.ToString() + "} ";
		}
	}
}
