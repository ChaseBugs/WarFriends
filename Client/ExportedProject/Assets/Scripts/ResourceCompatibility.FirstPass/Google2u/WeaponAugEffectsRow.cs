using System;

namespace Google2u
{
	[Serializable]
	public class WeaponAugEffectsRow : IGoogle2uRow
	{
		public int ENUMVALUE;

		public string NAME;

		public string PARAMETERS;

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

		public string Get_PARAMETERS
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

		public WeaponAugEffectsRow()
		{
		}

		public WeaponAugEffectsRow(string _ID, string _ENUMVALUE, string _NAME, string _PARAMETERS)
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
