using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class AugmentationTriggersRow : IGoogle2uRow
	{
		public string NAME;

		public ObscuredInt RARITY;

		public ObscuredFloat PARAM1;

		public ObscuredFloat PARAM1MAX;

		public ObscuredFloat PARAM2;

		public ObscuredFloat PARAM2MAX;

		public ObscuredFloat COOLDOWN;

		public ObscuredFloat COOLDOWNMAX;

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

		public ObscuredFloat Get_PARAM1
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_PARAM1MAX
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_PARAM2
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_PARAM2MAX
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_COOLDOWN
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_COOLDOWNMAX
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

		public AugmentationTriggersRow()
		{
		}

		public AugmentationTriggersRow(string _ID, string _NAME, string _RARITY, string _PARAM1, string _PARAM1MAX, string _PARAM2, string _PARAM2MAX, string _COOLDOWN, string _COOLDOWNMAX)
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
