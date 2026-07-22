using System;

namespace Google2u
{
	[Serializable]
	public class AugmentationLevelsRow : IGoogle2uRow
	{
		public int LEVEL;

		public int EXPERIENCE;

		public int RARITY;

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

		public int Get_RARITY
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

		public AugmentationLevelsRow()
		{
		}

		public AugmentationLevelsRow(string _ID, string _LEVEL, string _EXPERIENCE, string _RARITY)
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
