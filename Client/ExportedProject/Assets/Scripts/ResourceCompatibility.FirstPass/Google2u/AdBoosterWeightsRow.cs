using System;

namespace Google2u
{
	[Serializable]
	public class AdBoosterWeightsRow : IGoogle2uRow
	{
		public int AMOUNT;

		public float WEIGHT;

		public int Get_AMOUNT
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Get_WEIGHT
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public AdBoosterWeightsRow()
		{
		}

		public AdBoosterWeightsRow(string _ID, string _AMOUNT, string _WEIGHT)
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
