using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class AugmentationEffectsRow : IGoogle2uRow
	{
		public int ENUMVALUE;

		public string NAME;

		public ObscuredInt RARITY;

		public ObscuredInt SLOT;

		public int Get_ENUMVALUE
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

		public ObscuredInt Get_RARITY
		{
			get
			{
				return default(ObscuredInt);
			}
			set
			{
			}
		}

		public ObscuredInt Get_SLOT
		{
			get
			{
				return default(ObscuredInt);
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public AugmentationEffectsRow()
		{
		}

		public AugmentationEffectsRow(string _ID, string _ENUMVALUE, string _NAME, string _RARITY, string _SLOT)
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
