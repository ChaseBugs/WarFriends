using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class CountryInfoRow : IGoogle2uRow
	{
		public string ISO3;

		public int ISONUMERIC;

		public string FIPS;

		public string CONTINENT;

		public string CURRENCYCODE;

		public string CURRENCYNAME;

		public string LANGUAGES;

		public string NEIGHBOURS;

		public string Get_ISO3
		{
			get
			{
				return ISO3;
			}
			set
			{
				ISO3 = value;
			}
		}

		public int Get_ISONUMERIC
		{
			get
			{
				return ISONUMERIC;
			}
			set
			{
				ISONUMERIC = value;
			}
		}

		public string Get_FIPS
		{
			get
			{
				return FIPS;
			}
			set
			{
				FIPS = value;
			}
		}

		public string Get_CONTINENT
		{
			get
			{
				return CONTINENT;
			}
			set
			{
				CONTINENT = value;
			}
		}

		public string Get_CURRENCYCODE
		{
			get
			{
				return CURRENCYCODE;
			}
			set
			{
				CURRENCYCODE = value;
			}
		}

		public string Get_CURRENCYNAME
		{
			get
			{
				return CURRENCYNAME;
			}
			set
			{
				CURRENCYNAME = value;
			}
		}

		public string Get_LANGUAGES
		{
			get
			{
				return LANGUAGES;
			}
			set
			{
				LANGUAGES = value;
			}
		}

		public string Get_NEIGHBOURS
		{
			get
			{
				return NEIGHBOURS;
			}
			set
			{
				NEIGHBOURS = value;
			}
		}

		public int Length => 8;

		public string this[int i] => GetStringDataByIndex(i);

		public CountryInfoRow()
		{
		}

		public CountryInfoRow(string _ISO, string _ISO3, string _ISONUMERIC, string _FIPS, string _CONTINENT, string _CURRENCYCODE, string _CURRENCYNAME, string _LANGUAGES, string _NEIGHBOURS)
		{
			ISO3 = _ISO3.Trim();
			if (int.TryParse(_ISONUMERIC, out var result))
			{
				ISONUMERIC = result;
			}
			else
			{
				Debug.LogError("Failed To Convert ISONUMERIC string: " + _ISONUMERIC + " to int");
			}
			FIPS = _FIPS.Trim();
			CONTINENT = _CONTINENT.Trim();
			CURRENCYCODE = _CURRENCYCODE.Trim();
			CURRENCYNAME = _CURRENCYNAME.Trim();
			LANGUAGES = _LANGUAGES.Trim();
			NEIGHBOURS = _NEIGHBOURS.Trim();
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = ISO3.ToString();
				break;
			case 1:
				result = ISONUMERIC.ToString();
				break;
			case 2:
				result = FIPS.ToString();
				break;
			case 3:
				result = CONTINENT.ToString();
				break;
			case 4:
				result = CURRENCYCODE.ToString();
				break;
			case 5:
				result = CURRENCYNAME.ToString();
				break;
			case 6:
				result = LANGUAGES.ToString();
				break;
			case 7:
				result = NEIGHBOURS.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "ISO3":
				result = ISO3.ToString();
				break;
			case "ISONUMERIC":
				result = ISONUMERIC.ToString();
				break;
			case "FIPS":
				result = FIPS.ToString();
				break;
			case "CONTINENT":
				result = CONTINENT.ToString();
				break;
			case "CURRENCYCODE":
				result = CURRENCYCODE.ToString();
				break;
			case "CURRENCYNAME":
				result = CURRENCYNAME.ToString();
				break;
			case "LANGUAGES":
				result = LANGUAGES.ToString();
				break;
			case "NEIGHBOURS":
				result = NEIGHBOURS.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{ISO3 : " + ISO3.ToString() + "} ";
			empty = empty + "{ISONUMERIC : " + ISONUMERIC + "} ";
			empty = empty + "{FIPS : " + FIPS.ToString() + "} ";
			empty = empty + "{CONTINENT : " + CONTINENT.ToString() + "} ";
			empty = empty + "{CURRENCYCODE : " + CURRENCYCODE.ToString() + "} ";
			empty = empty + "{CURRENCYNAME : " + CURRENCYNAME.ToString() + "} ";
			empty = empty + "{LANGUAGES : " + LANGUAGES.ToString() + "} ";
			return empty + "{NEIGHBOURS : " + NEIGHBOURS.ToString() + "} ";
		}
	}
}
