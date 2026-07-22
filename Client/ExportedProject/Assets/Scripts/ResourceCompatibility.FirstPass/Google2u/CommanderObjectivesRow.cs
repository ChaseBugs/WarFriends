using System;

namespace Google2u
{
	[Serializable]
	public class CommanderObjectivesRow : IGoogle2uRow
	{
		public int ID;

		public bool ALLOWONLYONCE;

		public int TIER1CONDITION;

		public int TIER1TARGET;

		public int TIER1REWARD;

		public int TIER2CONDITION;

		public int TIER2TARGET;

		public int TIER2REWARD;

		public int TIER3CONDITION;

		public int TIER3TARGET;

		public int TIER3REWARD;

		public int Get_ID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Get_ALLOWONLYONCE
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int Get_TIER1CONDITION
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER1TARGET
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER1REWARD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER2CONDITION
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER2TARGET
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER2REWARD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER3CONDITION
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER3TARGET
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIER3REWARD
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

		public CommanderObjectivesRow()
		{
		}

		public CommanderObjectivesRow(string _GOAL, string _ID, string _ALLOWONLYONCE, string _TIER1CONDITION, string _TIER1TARGET, string _TIER1REWARD, string _TIER2CONDITION, string _TIER2TARGET, string _TIER2REWARD, string _TIER3CONDITION, string _TIER3TARGET, string _TIER3REWARD)
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
