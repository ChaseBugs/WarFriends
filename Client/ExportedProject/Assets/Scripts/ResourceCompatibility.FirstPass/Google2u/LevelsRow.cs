using System;

namespace Google2u
{
	[Serializable]
	public class LevelsRow : IGoogle2uRow
	{
		public int LEVEL;

		public int EXPERIENCE;

		public int REWARDGOLD;

		public int ARMYPOWER;

		public int CONVERTGOLDTOWARBUCKS;

		public float PLAYERPOWER;

		public float INVADERSCALINGMULTIPLIER;

		public int MAXADBOOSTERS;

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

		public int Get_EXPERIENCE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_REWARDGOLD
		{
			get
			{
				return 0;
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

		public int Get_CONVERTGOLDTOWARBUCKS
		{
			get
			{
				return 0;
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

		public float Get_INVADERSCALINGMULTIPLIER
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int Get_MAXADBOOSTERS
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

		public LevelsRow()
		{
		}

		public LevelsRow(string _ID, string _LEVEL, string _EXPERIENCE, string _REWARDGOLD, string _ARMYPOWER, string _CONVERTGOLDTOWARBUCKS, string _PLAYERPOWER, string _INVADERSCALINGMULTIPLIER, string _MAXADBOOSTERS)
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
