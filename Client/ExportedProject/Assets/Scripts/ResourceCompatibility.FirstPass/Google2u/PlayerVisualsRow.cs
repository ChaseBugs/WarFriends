using System;

namespace Google2u
{
	[Serializable]
	public class PlayerVisualsRow : IGoogle2uRow
	{
		public string NAME;

		public int UNLOCKLEVEL;

		public int PRICEWARBUCKS;

		public int PRICEGOLD;

		public int TIME;

		public int DECALTYPE;

		public float DECALVALUE;

		public int CATEGORYID;

		public bool ONLYFORVIP;

		public string PURCHASABLE;

		public int CATEGORY;

		public int PARTS;

		public int DUPLICATEWARBUCKS;

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

		public int Get_UNLOCKLEVEL
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_PRICEWARBUCKS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_PRICEGOLD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_TIME
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_DECALTYPE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Get_DECALVALUE
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int Get_CATEGORYID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Get_ONLYFORVIP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string Get_PURCHASABLE
		{
			get
			{
				return null;
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

		public int Get_PARTS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_DUPLICATEWARBUCKS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public PlayerVisualsRow()
		{
		}

		public PlayerVisualsRow(string _ID, string _NAME, string _UNLOCKLEVEL, string _PRICEWARBUCKS, string _PRICEGOLD, string _TIME, string _DECALTYPE, string _DECALVALUE, string _CATEGORYID, string _ONLYFORVIP, string _PURCHASABLE, string _CATEGORY, string _PARTS, string _DUPLICATEWARBUCKS)
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
