using System;

namespace Google2u
{
	[Serializable]
	public class VersionsRow : IGoogle2uRow
	{
		public string VALUE;

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

		public int Length => 1;

		public string this[int i] => GetStringDataByIndex(i);

		public VersionsRow()
		{
		}

		public VersionsRow(string _ID, string _VALUE)
		{
			VALUE = _VALUE.Trim();
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			if (index == 0)
			{
				result = VALUE.ToString();
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			if (colID != null && colID == "VALUE")
			{
				result = VALUE.ToString();
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			return empty + "{VALUE : " + VALUE.ToString() + "} ";
		}
	}
}
