using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class PrestigeRow : IGoogle2uRow
	{
		public int LEVEL;

		public long EXPERIENCE;

		public float PLAYERPOWER;

		public int ARMYPOWER;

		public long DAILYEXPCAP;

		public int LPREWARD;

		public ObscuredFloat PLAYERHP;

		public ObscuredFloat SHIELDHP;

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

		public long Get_EXPERIENCE
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public float Get_PLAYERPOWER
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int Get_ARMYPOWER
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public long Get_DAILYEXPCAP
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public int Get_LPREWARD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_PLAYERHP
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_SHIELDHP
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

		public PrestigeRow()
		{
		}

		public PrestigeRow(string _ID, string _LEVEL, string _EXPERIENCE, string _PLAYERPOWER, string _ARMYPOWER, string _DAILYEXPCAP, string _LPREWARD, string _PLAYERHP, string _SHIELDHP)
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
