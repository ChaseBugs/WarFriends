using System;

namespace Google2u
{
	[Serializable]
	public class ArenaLootboxesRow : IGoogle2uRow
	{
		public string NAME;

		public int ELITEPARTSMIN;

		public int ELITEPARTSMAX;

		public int TICKETSMIN;

		public int TICKETSMAX;

		public int SCRAPSMIN;

		public int SCRAPSMAX;

		public int GOLDMIN;

		public int GOLDMAX;

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

		public int Get_ELITEPARTSMIN
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_ELITEPARTSMAX
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TICKETSMIN
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TICKETSMAX
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_SCRAPSMIN
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_SCRAPSMAX
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_GOLDMIN
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_GOLDMAX
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

		public ArenaLootboxesRow()
		{
		}

		public ArenaLootboxesRow(string _ID, string _NAME, string _ELITEPARTSMIN, string _ELITEPARTSMAX, string _TICKETSMIN, string _TICKETSMAX, string _SCRAPSMIN, string _SCRAPSMAX, string _GOLDMIN, string _GOLDMAX, string _WARBUCKS)
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
