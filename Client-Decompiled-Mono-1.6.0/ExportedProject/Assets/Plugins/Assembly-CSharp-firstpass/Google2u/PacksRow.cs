using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class PacksRow : IGoogle2uRow
	{
		public string NAME;

		public int VIPSECONDS;

		public int WARBUCKS;

		public int GOLD;

		public int GOLDCARDS;

		public int SILVERCARDS;

		public string PLAYERVISUALS;

		public string WEAPONS;

		public bool CARDSLOT;

		public string ARMYUNITS;

		public float PRICE;

		public float REGULARPRICE;

		public float SALE;

		public string GUIORDER;

		public string USE;

		public string FREELABEL;

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

		public int Get_VIPSECONDS
		{
			get
			{
				return VIPSECONDS;
			}
			set
			{
				VIPSECONDS = value;
			}
		}

		public int Get_WARBUCKS
		{
			get
			{
				return WARBUCKS;
			}
			set
			{
				WARBUCKS = value;
			}
		}

		public int Get_GOLD
		{
			get
			{
				return GOLD;
			}
			set
			{
				GOLD = value;
			}
		}

		public int Get_GOLDCARDS
		{
			get
			{
				return GOLDCARDS;
			}
			set
			{
				GOLDCARDS = value;
			}
		}

		public int Get_SILVERCARDS
		{
			get
			{
				return SILVERCARDS;
			}
			set
			{
				SILVERCARDS = value;
			}
		}

		public string Get_PLAYERVISUALS
		{
			get
			{
				return PLAYERVISUALS;
			}
			set
			{
				PLAYERVISUALS = value;
			}
		}

		public string Get_WEAPONS
		{
			get
			{
				return WEAPONS;
			}
			set
			{
				WEAPONS = value;
			}
		}

		public bool Get_CARDSLOT
		{
			get
			{
				return CARDSLOT;
			}
			set
			{
				CARDSLOT = value;
			}
		}

		public string Get_ARMYUNITS
		{
			get
			{
				return ARMYUNITS;
			}
			set
			{
				ARMYUNITS = value;
			}
		}

		public float Get_PRICE
		{
			get
			{
				return PRICE;
			}
			set
			{
				PRICE = value;
			}
		}

		public float Get_REGULARPRICE
		{
			get
			{
				return REGULARPRICE;
			}
			set
			{
				REGULARPRICE = value;
			}
		}

		public float Get_SALE
		{
			get
			{
				return SALE;
			}
			set
			{
				SALE = value;
			}
		}

		public string Get_GUIORDER
		{
			get
			{
				return GUIORDER;
			}
			set
			{
				GUIORDER = value;
			}
		}

		public string Get_USE
		{
			get
			{
				return USE;
			}
			set
			{
				USE = value;
			}
		}

		public string Get_FREELABEL
		{
			get
			{
				return FREELABEL;
			}
			set
			{
				FREELABEL = value;
			}
		}

		public int Length
		{
			get
			{
				return 16;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public PacksRow()
		{
		}

		public PacksRow(string _ID, string _NAME, string _VIPSECONDS, string _WARBUCKS, string _GOLD, string _GOLDCARDS, string _SILVERCARDS, string _PLAYERVISUALS, string _WEAPONS, string _CARDSLOT, string _ARMYUNITS, string _PRICE, string _REGULARPRICE, string _SALE, string _GUIORDER, string _USE, string _FREELABEL)
		{
			NAME = _NAME.Trim();
			int result;
			if (int.TryParse(_VIPSECONDS, out result))
			{
				VIPSECONDS = result;
			}
			else
			{
				Debug.LogError("Failed To Convert VIPSECONDS string: " + _VIPSECONDS + " to int");
			}
			int result2;
			if (int.TryParse(_WARBUCKS, out result2))
			{
				WARBUCKS = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert WARBUCKS string: " + _WARBUCKS + " to int");
			}
			int result3;
			if (int.TryParse(_GOLD, out result3))
			{
				GOLD = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert GOLD string: " + _GOLD + " to int");
			}
			int result4;
			if (int.TryParse(_GOLDCARDS, out result4))
			{
				GOLDCARDS = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert GOLDCARDS string: " + _GOLDCARDS + " to int");
			}
			int result5;
			if (int.TryParse(_SILVERCARDS, out result5))
			{
				SILVERCARDS = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert SILVERCARDS string: " + _SILVERCARDS + " to int");
			}
			PLAYERVISUALS = _PLAYERVISUALS.Trim();
			WEAPONS = _WEAPONS.Trim();
			bool result6;
			if (bool.TryParse(_CARDSLOT, out result6))
			{
				CARDSLOT = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert CARDSLOT string: " + _CARDSLOT + " to bool");
			}
			ARMYUNITS = _ARMYUNITS.Trim();
			float result7;
			if (float.TryParse(_PRICE, out result7))
			{
				PRICE = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert PRICE string: " + _PRICE + " to float");
			}
			float result8;
			if (float.TryParse(_REGULARPRICE, out result8))
			{
				REGULARPRICE = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert REGULARPRICE string: " + _REGULARPRICE + " to float");
			}
			float result9;
			if (float.TryParse(_SALE, out result9))
			{
				SALE = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert SALE string: " + _SALE + " to float");
			}
			GUIORDER = _GUIORDER.Trim();
			USE = _USE.Trim();
			FREELABEL = _FREELABEL.Trim();
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
				result = VIPSECONDS.ToString();
				break;
			case 2:
				result = WARBUCKS.ToString();
				break;
			case 3:
				result = GOLD.ToString();
				break;
			case 4:
				result = GOLDCARDS.ToString();
				break;
			case 5:
				result = SILVERCARDS.ToString();
				break;
			case 6:
				result = PLAYERVISUALS.ToString();
				break;
			case 7:
				result = WEAPONS.ToString();
				break;
			case 8:
				result = CARDSLOT.ToString();
				break;
			case 9:
				result = ARMYUNITS.ToString();
				break;
			case 10:
				result = PRICE.ToString();
				break;
			case 11:
				result = REGULARPRICE.ToString();
				break;
			case 12:
				result = SALE.ToString();
				break;
			case 13:
				result = GUIORDER.ToString();
				break;
			case 14:
				result = USE.ToString();
				break;
			case 15:
				result = FREELABEL.ToString();
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
			case "VIPSECONDS":
				result = VIPSECONDS.ToString();
				break;
			case "WARBUCKS":
				result = WARBUCKS.ToString();
				break;
			case "GOLD":
				result = GOLD.ToString();
				break;
			case "GOLDCARDS":
				result = GOLDCARDS.ToString();
				break;
			case "SILVERCARDS":
				result = SILVERCARDS.ToString();
				break;
			case "PLAYERVISUALS":
				result = PLAYERVISUALS.ToString();
				break;
			case "WEAPONS":
				result = WEAPONS.ToString();
				break;
			case "CARDSLOT":
				result = CARDSLOT.ToString();
				break;
			case "ARMYUNITS":
				result = ARMYUNITS.ToString();
				break;
			case "PRICE":
				result = PRICE.ToString();
				break;
			case "REGULARPRICE":
				result = REGULARPRICE.ToString();
				break;
			case "SALE":
				result = SALE.ToString();
				break;
			case "GUIORDER":
				result = GUIORDER.ToString();
				break;
			case "USE":
				result = USE.ToString();
				break;
			case "FREELABEL":
				result = FREELABEL.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{NAME : " + NAME.ToString() + "} ";
			empty = empty + "{VIPSECONDS : " + VIPSECONDS + "} ";
			empty = empty + "{WARBUCKS : " + WARBUCKS + "} ";
			empty = empty + "{GOLD : " + GOLD + "} ";
			empty = empty + "{GOLDCARDS : " + GOLDCARDS + "} ";
			empty = empty + "{SILVERCARDS : " + SILVERCARDS + "} ";
			empty = empty + "{PLAYERVISUALS : " + PLAYERVISUALS.ToString() + "} ";
			empty = empty + "{WEAPONS : " + WEAPONS.ToString() + "} ";
			empty = empty + "{CARDSLOT : " + CARDSLOT + "} ";
			empty = empty + "{ARMYUNITS : " + ARMYUNITS.ToString() + "} ";
			empty = empty + "{PRICE : " + PRICE + "} ";
			empty = empty + "{REGULARPRICE : " + REGULARPRICE + "} ";
			empty = empty + "{SALE : " + SALE + "} ";
			empty = empty + "{GUIORDER : " + GUIORDER.ToString() + "} ";
			empty = empty + "{USE : " + USE.ToString() + "} ";
			return empty + "{FREELABEL : " + FREELABEL.ToString() + "} ";
		}
	}
}
