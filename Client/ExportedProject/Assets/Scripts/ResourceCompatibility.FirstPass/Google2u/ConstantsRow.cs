using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class ConstantsRow : IGoogle2uRow
	{
		public ObscuredFloat FLOATVALUE;

		public string DBKEY;

		public ObscuredFloat Get_FLOATVALUE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public string Get_DBKEY
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public ConstantsRow()
		{
		}

		public ConstantsRow(string _NAME, string _FLOATVALUE, string _DBKEY)
		{
		}

		public string GetStringDataByIndex(int index)
		{
			return null;
		}

		public string GetStringData(string colID)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
