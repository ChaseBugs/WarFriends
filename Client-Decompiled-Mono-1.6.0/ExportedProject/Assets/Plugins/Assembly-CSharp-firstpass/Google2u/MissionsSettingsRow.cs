using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class MissionsSettingsRow : IGoogle2uRow
	{
		public float DAILY1;

		public float DAILY2;

		public float DAILY3;

		public float HEROIC1;

		public float HEROIC2;

		public float HEROIC3;

		public float HEROIC4;

		public float HEROIC5;

		public string NAME;

		public float Get_DAILY1
		{
			get
			{
				return DAILY1;
			}
			set
			{
				DAILY1 = value;
			}
		}

		public float Get_DAILY2
		{
			get
			{
				return DAILY2;
			}
			set
			{
				DAILY2 = value;
			}
		}

		public float Get_DAILY3
		{
			get
			{
				return DAILY3;
			}
			set
			{
				DAILY3 = value;
			}
		}

		public float Get_HEROIC1
		{
			get
			{
				return HEROIC1;
			}
			set
			{
				HEROIC1 = value;
			}
		}

		public float Get_HEROIC2
		{
			get
			{
				return HEROIC2;
			}
			set
			{
				HEROIC2 = value;
			}
		}

		public float Get_HEROIC3
		{
			get
			{
				return HEROIC3;
			}
			set
			{
				HEROIC3 = value;
			}
		}

		public float Get_HEROIC4
		{
			get
			{
				return HEROIC4;
			}
			set
			{
				HEROIC4 = value;
			}
		}

		public float Get_HEROIC5
		{
			get
			{
				return HEROIC5;
			}
			set
			{
				HEROIC5 = value;
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

		public int Length
		{
			get
			{
				return 9;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public MissionsSettingsRow()
		{
		}

		public MissionsSettingsRow(string _ID, string _DAILY1, string _DAILY2, string _DAILY3, string _HEROIC1, string _HEROIC2, string _HEROIC3, string _HEROIC4, string _HEROIC5, string _NAME)
		{
			float result;
			if (float.TryParse(_DAILY1, out result))
			{
				DAILY1 = result;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILY1 string: " + _DAILY1 + " to float");
			}
			float result2;
			if (float.TryParse(_DAILY2, out result2))
			{
				DAILY2 = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILY2 string: " + _DAILY2 + " to float");
			}
			float result3;
			if (float.TryParse(_DAILY3, out result3))
			{
				DAILY3 = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert DAILY3 string: " + _DAILY3 + " to float");
			}
			float result4;
			if (float.TryParse(_HEROIC1, out result4))
			{
				HEROIC1 = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROIC1 string: " + _HEROIC1 + " to float");
			}
			float result5;
			if (float.TryParse(_HEROIC2, out result5))
			{
				HEROIC2 = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROIC2 string: " + _HEROIC2 + " to float");
			}
			float result6;
			if (float.TryParse(_HEROIC3, out result6))
			{
				HEROIC3 = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROIC3 string: " + _HEROIC3 + " to float");
			}
			float result7;
			if (float.TryParse(_HEROIC4, out result7))
			{
				HEROIC4 = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROIC4 string: " + _HEROIC4 + " to float");
			}
			float result8;
			if (float.TryParse(_HEROIC5, out result8))
			{
				HEROIC5 = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert HEROIC5 string: " + _HEROIC5 + " to float");
			}
			NAME = _NAME.Trim();
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = DAILY1.ToString();
				break;
			case 1:
				result = DAILY2.ToString();
				break;
			case 2:
				result = DAILY3.ToString();
				break;
			case 3:
				result = HEROIC1.ToString();
				break;
			case 4:
				result = HEROIC2.ToString();
				break;
			case 5:
				result = HEROIC3.ToString();
				break;
			case 6:
				result = HEROIC4.ToString();
				break;
			case 7:
				result = HEROIC5.ToString();
				break;
			case 8:
				result = NAME.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "DAILY1":
				result = DAILY1.ToString();
				break;
			case "DAILY2":
				result = DAILY2.ToString();
				break;
			case "DAILY3":
				result = DAILY3.ToString();
				break;
			case "HEROIC1":
				result = HEROIC1.ToString();
				break;
			case "HEROIC2":
				result = HEROIC2.ToString();
				break;
			case "HEROIC3":
				result = HEROIC3.ToString();
				break;
			case "HEROIC4":
				result = HEROIC4.ToString();
				break;
			case "HEROIC5":
				result = HEROIC5.ToString();
				break;
			case "NAME":
				result = NAME.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{DAILY1 : " + DAILY1 + "} ";
			empty = empty + "{DAILY2 : " + DAILY2 + "} ";
			empty = empty + "{DAILY3 : " + DAILY3 + "} ";
			empty = empty + "{HEROIC1 : " + HEROIC1 + "} ";
			empty = empty + "{HEROIC2 : " + HEROIC2 + "} ";
			empty = empty + "{HEROIC3 : " + HEROIC3 + "} ";
			empty = empty + "{HEROIC4 : " + HEROIC4 + "} ";
			empty = empty + "{HEROIC5 : " + HEROIC5 + "} ";
			return empty + "{NAME : " + NAME.ToString() + "} ";
		}
	}
}
