using System;
using UnityEngine;

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
				return NAME;
			}
			set
			{
				NAME = value;
			}
		}

		public int Get_RARITY
		{
			get
			{
				return RARITY;
			}
			set
			{
				RARITY = value;
			}
		}

		public int Get_FROMMISSION
		{
			get
			{
				return FROMMISSION;
			}
			set
			{
				FROMMISSION = value;
			}
		}

		public bool Get_IMPLEMENTED
		{
			get
			{
				return IMPLEMENTED;
			}
			set
			{
				IMPLEMENTED = value;
			}
		}

		public int Length
		{
			get
			{
				return 4;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public CardDefinitionsRow()
		{
		}

		public CardDefinitionsRow(string _ID, string _NAME, string _RARITY, string _FROMMISSION, string _IMPLEMENTED)
		{
			NAME = _NAME.Trim();
			int result;
			if (int.TryParse(_RARITY, out result))
			{
				RARITY = result;
			}
			else
			{
				Debug.LogError("Failed To Convert RARITY string: " + _RARITY + " to int");
			}
			int result2;
			if (int.TryParse(_FROMMISSION, out result2))
			{
				FROMMISSION = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert FROMMISSION string: " + _FROMMISSION + " to int");
			}
			bool result3;
			if (bool.TryParse(_IMPLEMENTED, out result3))
			{
				IMPLEMENTED = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert IMPLEMENTED string: " + _IMPLEMENTED + " to bool");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = NAME.ToString();
				break;
			case 1:
				result = RARITY.ToString();
				break;
			case 2:
				result = FROMMISSION.ToString();
				break;
			case 3:
				result = IMPLEMENTED.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "NAME":
				result = NAME.ToString();
				break;
			case "RARITY":
				result = RARITY.ToString();
				break;
			case "FROMMISSION":
				result = FROMMISSION.ToString();
				break;
			case "IMPLEMENTED":
				result = IMPLEMENTED.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{NAME : " + NAME.ToString() + "} ";
			empty = empty + "{RARITY : " + RARITY + "} ";
			empty = empty + "{FROMMISSION : " + FROMMISSION + "} ";
			return empty + "{IMPLEMENTED : " + IMPLEMENTED + "} ";
		}
	}
}
