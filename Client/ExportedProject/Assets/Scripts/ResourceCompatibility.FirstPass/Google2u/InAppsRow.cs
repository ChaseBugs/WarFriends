using System;

namespace Google2u
{
	[Serializable]
	public class InAppsRow : IGoogle2uRow
	{
		public string NAME;

		public int AMOUNT;

		public float PRICE;

		public bool CONSUMABLE;

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

		public float Get_PRICE
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Get_CONSUMABLE
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public InAppsRow()
		{
		}

		public InAppsRow(string _ID, string _NAME, string _AMOUNT, string _PRICE, string _CONSUMABLE)
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
