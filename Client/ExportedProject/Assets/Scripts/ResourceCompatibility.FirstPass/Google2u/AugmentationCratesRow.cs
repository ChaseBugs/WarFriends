using System;

namespace Google2u
{
	[Serializable]
	public class AugmentationCratesRow : IGoogle2uRow
	{
		public string NAME;

		public int GOLD;

		public int COUNT;

		public string GUARANTEEDTYPE;

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

		public int Get_GOLD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_COUNT
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string Get_GUARANTEEDTYPE
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

		public AugmentationCratesRow()
		{
		}

		public AugmentationCratesRow(string _ID, string _NAME, string _GOLD, string _COUNT, string _GUARANTEEDTYPE)
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
