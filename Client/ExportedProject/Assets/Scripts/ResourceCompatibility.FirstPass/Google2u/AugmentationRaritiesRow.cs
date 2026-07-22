using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class AugmentationRaritiesRow : IGoogle2uRow
	{
		public string DBKEY;

		public ObscuredFloat BATTLECRATEPROB;

		public ObscuredFloat BASICCRATEPROB;

		public ObscuredFloat ADVANCEDCRATEPROB;

		public ObscuredFloat PROCRATEPROB;

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

		public ObscuredFloat Get_BATTLECRATEPROB
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_BASICCRATEPROB
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_ADVANCEDCRATEPROB
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_PROCRATEPROB
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

		public AugmentationRaritiesRow()
		{
		}

		public AugmentationRaritiesRow(string _NAME, string _DBKEY, string _BATTLECRATEPROB, string _BASICCRATEPROB, string _ADVANCEDCRATEPROB, string _PROCRATEPROB)
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
