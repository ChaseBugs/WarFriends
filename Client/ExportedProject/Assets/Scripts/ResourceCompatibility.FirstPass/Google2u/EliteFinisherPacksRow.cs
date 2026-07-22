using System;

namespace Google2u
{
	[Serializable]
	public class EliteFinisherPacksRow : IGoogle2uRow
	{
		public string NAME;

		public int PARTS;

		public int SCRAPS;

		public int WARBUCKS;

		public string Get_NAME
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Get_PARTS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_SCRAPS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_WARBUCKS
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

		public EliteFinisherPacksRow()
		{
		}

		public EliteFinisherPacksRow(string _ID, string _NAME, string _PARTS, string _SCRAPS, string _WARBUCKS)
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
