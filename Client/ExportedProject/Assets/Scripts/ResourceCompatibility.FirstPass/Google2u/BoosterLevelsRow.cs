using System;

namespace Google2u
{
	[Serializable]
	public class BoosterLevelsRow : IGoogle2uRow
	{
		public int LEVEL;

		public int TIMEAMOUNT;

		public int Get_LEVEL
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIMEAMOUNT
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public BoosterLevelsRow()
		{
		}

		public BoosterLevelsRow(string _ID, string _LEVEL, string _TIMEAMOUNT)
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
