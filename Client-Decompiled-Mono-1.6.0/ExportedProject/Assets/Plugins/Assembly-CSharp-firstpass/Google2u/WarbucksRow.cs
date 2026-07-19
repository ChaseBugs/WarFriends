using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class WarbucksRow : IGoogle2uRow
	{
		public string NAME;

		public int GOLDPRICE;

		public int GOLDAMOUNT;

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

		public int Get_GOLDPRICE
		{
			get
			{
				return GOLDPRICE;
			}
			set
			{
				GOLDPRICE = value;
			}
		}

		public int Get_GOLDAMOUNT
		{
			get
			{
				return GOLDAMOUNT;
			}
			set
			{
				GOLDAMOUNT = value;
			}
		}

		public int Length
		{
			get
			{
				return 3;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public WarbucksRow()
		{
		}

		public WarbucksRow(string _ID, string _NAME, string _GOLDPRICE, string _GOLDAMOUNT)
		{
			NAME = _NAME.Trim();
			int result;
			if (int.TryParse(_GOLDPRICE, out result))
			{
				GOLDPRICE = result;
			}
			else
			{
				Debug.LogError("Failed To Convert GOLDPRICE string: " + _GOLDPRICE + " to int");
			}
			int result2;
			if (int.TryParse(_GOLDAMOUNT, out result2))
			{
				GOLDAMOUNT = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert GOLDAMOUNT string: " + _GOLDAMOUNT + " to int");
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
				result = GOLDPRICE.ToString();
				break;
			case 2:
				result = GOLDAMOUNT.ToString();
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
			case "GOLDPRICE":
				result = GOLDPRICE.ToString();
				break;
			case "GOLDAMOUNT":
				result = GOLDAMOUNT.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{NAME : " + NAME.ToString() + "} ";
			empty = empty + "{GOLDPRICE : " + GOLDPRICE + "} ";
			return empty + "{GOLDAMOUNT : " + GOLDAMOUNT + "} ";
		}
	}
}
