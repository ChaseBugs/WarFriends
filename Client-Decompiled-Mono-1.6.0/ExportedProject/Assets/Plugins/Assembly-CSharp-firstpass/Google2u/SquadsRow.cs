using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class SquadsRow : IGoogle2uRow
	{
		public int LEVEL;

		public int SIZE;

		public string NAME;

		public long EXPERIENCE;

		public int CARDPOOLSIZE;

		public int Get_LEVEL
		{
			get
			{
				return LEVEL;
			}
			set
			{
				LEVEL = value;
			}
		}

		public int Get_SIZE
		{
			get
			{
				return SIZE;
			}
			set
			{
				SIZE = value;
			}
		}

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

		public long Get_EXPERIENCE
		{
			get
			{
				return EXPERIENCE;
			}
			set
			{
				EXPERIENCE = value;
			}
		}

		public int Get_CARDPOOLSIZE
		{
			get
			{
				return CARDPOOLSIZE;
			}
			set
			{
				CARDPOOLSIZE = value;
			}
		}

		public int Length
		{
			get
			{
				return 5;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public SquadsRow()
		{
		}

		public SquadsRow(string _ID, string _LEVEL, string _SIZE, string _NAME, string _EXPERIENCE, string _CARDPOOLSIZE)
		{
			int result;
			if (int.TryParse(_LEVEL, out result))
			{
				LEVEL = result;
			}
			else
			{
				Debug.LogError("Failed To Convert LEVEL string: " + _LEVEL + " to int");
			}
			int result2;
			if (int.TryParse(_SIZE, out result2))
			{
				SIZE = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert SIZE string: " + _SIZE + " to int");
			}
			NAME = _NAME.Trim();
			long result3;
			if (long.TryParse(_EXPERIENCE, out result3))
			{
				EXPERIENCE = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert EXPERIENCE string: " + _EXPERIENCE + " to long");
			}
			int result4;
			if (int.TryParse(_CARDPOOLSIZE, out result4))
			{
				CARDPOOLSIZE = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert CARDPOOLSIZE string: " + _CARDPOOLSIZE + " to int");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = LEVEL.ToString();
				break;
			case 1:
				result = SIZE.ToString();
				break;
			case 2:
				result = NAME.ToString();
				break;
			case 3:
				result = EXPERIENCE.ToString();
				break;
			case 4:
				result = CARDPOOLSIZE.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "LEVEL":
				result = LEVEL.ToString();
				break;
			case "SIZE":
				result = SIZE.ToString();
				break;
			case "NAME":
				result = NAME.ToString();
				break;
			case "EXPERIENCE":
				result = EXPERIENCE.ToString();
				break;
			case "CARDPOOLSIZE":
				result = CARDPOOLSIZE.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{LEVEL : " + LEVEL + "} ";
			empty = empty + "{SIZE : " + SIZE + "} ";
			empty = empty + "{NAME : " + NAME.ToString() + "} ";
			empty = empty + "{EXPERIENCE : " + EXPERIENCE + "} ";
			return empty + "{CARDPOOLSIZE : " + CARDPOOLSIZE + "} ";
		}
	}
}
