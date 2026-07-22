using System;

namespace Google2u
{
	[Serializable]
	public class PlayerVisualsRaritiesRow : IGoogle2uRow
	{
		public int VALUE;

		public float PROBABILITY;

		public int Get_VALUE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Get_PROBABILITY
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

		public PlayerVisualsRaritiesRow()
		{
		}

		public PlayerVisualsRaritiesRow(string _ID, string _VALUE, string _PROBABILITY)
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
