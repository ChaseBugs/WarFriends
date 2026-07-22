using System;

namespace Google2u
{
	[Serializable]
	public class SuperchargedUnitEffectsRow : IGoogle2uRow
	{
		public int ENUMVALUE;

		public string NAME;

		public int NUMOFPARAMS;

		public int CATEGORY;

		public string EFFECTVALUE1;

		public string EFFECTVALUE2;

		public string EFFECTVALUE3;

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

		public int Get_NUMOFPARAMS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_CATEGORY
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string Get_EFFECTVALUE1
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Get_EFFECTVALUE2
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Get_EFFECTVALUE3
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

		public SuperchargedUnitEffectsRow()
		{
		}

		public SuperchargedUnitEffectsRow(string _ID, string _ENUMVALUE, string _NAME, string _NUMOFPARAMS, string _CATEGORY, string _EFFECTVALUE1, string _EFFECTVALUE2, string _EFFECTVALUE3)
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
