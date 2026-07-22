using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class DBUpgradeSlotsExoPilotRow : IGoogle2uRow
	{
		public int TIER;

		public ObscuredFloat HP;

		public ObscuredFloat DAMAGE;

		public int BATCHSIZEMIN;

		public int BATCHSIZEMAX;

		public float SHOTFREQUENCYMIN;

		public float SHOTFREQUENCYMAX;

		public ObscuredFloat REALSHOTPROBABILITY;

		public ObscuredFloat SPECIAL;

		public ObscuredFloat ELITE;

		public int Get_TIER
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_HP
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DAMAGE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public int Get_BATCHSIZEMIN
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_BATCHSIZEMAX
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Get_SHOTFREQUENCYMIN
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Get_SHOTFREQUENCYMAX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_REALSHOTPROBABILITY
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_SPECIAL
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_ELITE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public DBUpgradeSlotsExoPilotRow()
		{
		}

		public DBUpgradeSlotsExoPilotRow(string _GOOGLEFU_ID, string _TIER, string _HP, string _DAMAGE, string _BATCHSIZEMIN, string _BATCHSIZEMAX, string _SHOTFREQUENCYMIN, string _SHOTFREQUENCYMAX, string _REALSHOTPROBABILITY, string _SPECIAL, string _ELITE)
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
