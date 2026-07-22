using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class DBUpgradeSlotsOrbRow : IGoogle2uRow
	{
		public int TYPE;

		public ObscuredFloat HP;

		public ObscuredFloat DAMAGE;

		public ObscuredFloat EXPLODEDAMAGE;

		public int BATCHSIZEMIN;

		public int BATCHSIZEMAX;

		public float SHOTFREQUENCYMIN;

		public float SHOTFREQUENCYMAX;

		public ObscuredFloat REALSHOTPROBABILITY;

		public int Get_TYPE
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

		public ObscuredFloat Get_EXPLODEDAMAGE
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

		public int Length => 0;

		public string Item => null;

		public DBUpgradeSlotsOrbRow()
		{
		}

		public DBUpgradeSlotsOrbRow(string _GOOGLEFU_ID, string _TYPE, string _HP, string _DAMAGE, string _EXPLODEDAMAGE, string _BATCHSIZEMIN, string _BATCHSIZEMAX, string _SHOTFREQUENCYMIN, string _SHOTFREQUENCYMAX, string _REALSHOTPROBABILITY)
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
