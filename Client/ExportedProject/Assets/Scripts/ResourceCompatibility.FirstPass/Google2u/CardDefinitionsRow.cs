using System;

namespace Google2u
{
	[Serializable]
	public class CardDefinitionsRow : IGoogle2uRow
	{
		public string NAME;

		public int RARITY;

		public int FROMMISSION;

		public bool IMPLEMENTED;

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

		public int Get_FROMMISSION
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Get_IMPLEMENTED
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

		public CardDefinitionsRow()
		{
		}

		public CardDefinitionsRow(string _ID, string _NAME, string _RARITY, string _FROMMISSION, string _IMPLEMENTED)
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
