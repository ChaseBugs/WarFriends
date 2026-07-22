using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class AugmentationConstantsRow : IGoogle2uRow
	{
		public string DBKEY;

		public ObscuredFloat FLOATVALUE;

		public string Get_DBKEY
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_FLOATVALUE
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

		public AugmentationConstantsRow()
		{
		}

		public AugmentationConstantsRow(string _ID, string _DBKEY, string _FLOATVALUE)
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
