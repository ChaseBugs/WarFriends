using System;

namespace Google2u
{
	[Serializable]
	public class BotPerksRow : IGoogle2uRow
	{
		public int PLAYERPERKS;

		public int BOTPERKSMIN;

		public int BOTPERKSMAX;

		public int Get_PLAYERPERKS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_BOTPERKSMIN
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_BOTPERKSMAX
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

		public BotPerksRow()
		{
		}

		public BotPerksRow(string _ID, string _PLAYERPERKS, string _BOTPERKSMIN, string _BOTPERKSMAX)
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
