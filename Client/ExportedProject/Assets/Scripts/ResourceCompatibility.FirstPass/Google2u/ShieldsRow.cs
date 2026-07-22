using System;

namespace Google2u
{
	[Serializable]
	public class ShieldsRow : IGoogle2uRow
	{
		public string DBKEY;

		public string NAME;

		public int RARITY;

		public string PURCHASABLE;

		public bool DESCRIPTION;

		public bool CANBOTEQUIP;

		public int PARTS;

		public int DUPLICATEWARBUCKS;

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

		public int Get_RARITY
		{
			get
			{
				return 0;
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

		public bool Get_DESCRIPTION
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Get_CANBOTEQUIP
		{
			get
			{
				return false;
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

		public ShieldsRow()
		{
		}

		public ShieldsRow(string _ID, string _DBKEY, string _NAME, string _RARITY, string _PURCHASABLE, string _DESCRIPTION, string _CANBOTEQUIP, string _PARTS, string _DUPLICATEWARBUCKS)
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
