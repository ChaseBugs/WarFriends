using System;

namespace Google2u
{
	[Serializable]
	public class PiggyBankRow : IGoogle2uRow
	{
		public int MAXGOLD;

		public int GOLDPERBATTLE;

		public string NAME;

		public int Get_MAXGOLD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_GOLDPERBATTLE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

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

		public int Length => 0;

		public string Item => null;

		public PiggyBankRow()
		{
		}

		public PiggyBankRow(string _TIER, string _MAXGOLD, string _GOLDPERBATTLE, string _NAME)
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
