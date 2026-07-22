using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class TaskDefinitionsRow : IGoogle2uRow
	{
		public string DESCRIPTION;

		public bool ISACTIVE;

		public string DESCRIPTIONSTRING;

		public bool PLAYERONLY;

		public int TARGETMIN;

		public int TARGETMAX;

		public string SECONDTARGETPARAMETER;

		public int SECONDTARGETMIN;

		public int SECONDTARGETMAX;

		public int GROUPTYPE;

		public int LEVELUNLOCK;

		public int DIFFICULTY;

		public bool REMEMBERCOMPLETION;

		public string Get_DESCRIPTION
		{
			get
			{
				return DESCRIPTION;
			}
			set
			{
				DESCRIPTION = value;
			}
		}

		public bool Get_ISACTIVE
		{
			get
			{
				return ISACTIVE;
			}
			set
			{
				ISACTIVE = value;
			}
		}

		public string Get_DESCRIPTIONSTRING
		{
			get
			{
				return DESCRIPTIONSTRING;
			}
			set
			{
				DESCRIPTIONSTRING = value;
			}
		}

		public bool Get_PLAYERONLY
		{
			get
			{
				return PLAYERONLY;
			}
			set
			{
				PLAYERONLY = value;
			}
		}

		public int Get_TARGETMIN
		{
			get
			{
				return TARGETMIN;
			}
			set
			{
				TARGETMIN = value;
			}
		}

		public int Get_TARGETMAX
		{
			get
			{
				return TARGETMAX;
			}
			set
			{
				TARGETMAX = value;
			}
		}

		public string Get_SECONDTARGETPARAMETER
		{
			get
			{
				return SECONDTARGETPARAMETER;
			}
			set
			{
				SECONDTARGETPARAMETER = value;
			}
		}

		public int Get_SECONDTARGETMIN
		{
			get
			{
				return SECONDTARGETMIN;
			}
			set
			{
				SECONDTARGETMIN = value;
			}
		}

		public int Get_SECONDTARGETMAX
		{
			get
			{
				return SECONDTARGETMAX;
			}
			set
			{
				SECONDTARGETMAX = value;
			}
		}

		public int Get_GROUPTYPE
		{
			get
			{
				return GROUPTYPE;
			}
			set
			{
				GROUPTYPE = value;
			}
		}

		public int Get_LEVELUNLOCK
		{
			get
			{
				return LEVELUNLOCK;
			}
			set
			{
				LEVELUNLOCK = value;
			}
		}

		public int Get_DIFFICULTY
		{
			get
			{
				return DIFFICULTY;
			}
			set
			{
				DIFFICULTY = value;
			}
		}

		public bool Get_REMEMBERCOMPLETION
		{
			get
			{
				return REMEMBERCOMPLETION;
			}
			set
			{
				REMEMBERCOMPLETION = value;
			}
		}

		public int Length => 13;

		public string this[int i] => GetStringDataByIndex(i);

		public TaskDefinitionsRow()
		{
		}

		public TaskDefinitionsRow(string _ID, string _DESCRIPTION, string _ISACTIVE, string _DESCRIPTIONSTRING, string _PLAYERONLY, string _TARGETMIN, string _TARGETMAX, string _SECONDTARGETPARAMETER, string _SECONDTARGETMIN, string _SECONDTARGETMAX, string _GROUPTYPE, string _LEVELUNLOCK, string _DIFFICULTY, string _REMEMBERCOMPLETION)
		{
			DESCRIPTION = _DESCRIPTION.Trim();
			if (bool.TryParse(_ISACTIVE, out var result))
			{
				ISACTIVE = result;
			}
			else
			{
				Debug.LogError("Failed To Convert ISACTIVE string: " + _ISACTIVE + " to bool");
			}
			DESCRIPTIONSTRING = _DESCRIPTIONSTRING.Trim();
			if (bool.TryParse(_PLAYERONLY, out var result2))
			{
				PLAYERONLY = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert PLAYERONLY string: " + _PLAYERONLY + " to bool");
			}
			if (int.TryParse(_TARGETMIN, out var result3))
			{
				TARGETMIN = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert TARGETMIN string: " + _TARGETMIN + " to int");
			}
			if (int.TryParse(_TARGETMAX, out var result4))
			{
				TARGETMAX = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert TARGETMAX string: " + _TARGETMAX + " to int");
			}
			SECONDTARGETPARAMETER = _SECONDTARGETPARAMETER.Trim();
			if (int.TryParse(_SECONDTARGETMIN, out var result5))
			{
				SECONDTARGETMIN = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert SECONDTARGETMIN string: " + _SECONDTARGETMIN + " to int");
			}
			if (int.TryParse(_SECONDTARGETMAX, out var result6))
			{
				SECONDTARGETMAX = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert SECONDTARGETMAX string: " + _SECONDTARGETMAX + " to int");
			}
			if (int.TryParse(_GROUPTYPE, out var result7))
			{
				GROUPTYPE = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert GROUPTYPE string: " + _GROUPTYPE + " to int");
			}
			if (int.TryParse(_LEVELUNLOCK, out var result8))
			{
				LEVELUNLOCK = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert LEVELUNLOCK string: " + _LEVELUNLOCK + " to int");
			}
			if (int.TryParse(_DIFFICULTY, out var result9))
			{
				DIFFICULTY = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert DIFFICULTY string: " + _DIFFICULTY + " to int");
			}
			if (bool.TryParse(_REMEMBERCOMPLETION, out var result10))
			{
				REMEMBERCOMPLETION = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert REMEMBERCOMPLETION string: " + _REMEMBERCOMPLETION + " to bool");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = DESCRIPTION.ToString();
				break;
			case 1:
				result = ISACTIVE.ToString();
				break;
			case 2:
				result = DESCRIPTIONSTRING.ToString();
				break;
			case 3:
				result = PLAYERONLY.ToString();
				break;
			case 4:
				result = TARGETMIN.ToString();
				break;
			case 5:
				result = TARGETMAX.ToString();
				break;
			case 6:
				result = SECONDTARGETPARAMETER.ToString();
				break;
			case 7:
				result = SECONDTARGETMIN.ToString();
				break;
			case 8:
				result = SECONDTARGETMAX.ToString();
				break;
			case 9:
				result = GROUPTYPE.ToString();
				break;
			case 10:
				result = LEVELUNLOCK.ToString();
				break;
			case 11:
				result = DIFFICULTY.ToString();
				break;
			case 12:
				result = REMEMBERCOMPLETION.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "DESCRIPTION":
				result = DESCRIPTION.ToString();
				break;
			case "ISACTIVE":
				result = ISACTIVE.ToString();
				break;
			case "DESCRIPTIONSTRING":
				result = DESCRIPTIONSTRING.ToString();
				break;
			case "PLAYERONLY":
				result = PLAYERONLY.ToString();
				break;
			case "TARGETMIN":
				result = TARGETMIN.ToString();
				break;
			case "TARGETMAX":
				result = TARGETMAX.ToString();
				break;
			case "SECONDTARGETPARAMETER":
				result = SECONDTARGETPARAMETER.ToString();
				break;
			case "SECONDTARGETMIN":
				result = SECONDTARGETMIN.ToString();
				break;
			case "SECONDTARGETMAX":
				result = SECONDTARGETMAX.ToString();
				break;
			case "GROUPTYPE":
				result = GROUPTYPE.ToString();
				break;
			case "LEVELUNLOCK":
				result = LEVELUNLOCK.ToString();
				break;
			case "DIFFICULTY":
				result = DIFFICULTY.ToString();
				break;
			case "REMEMBERCOMPLETION":
				result = REMEMBERCOMPLETION.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{DESCRIPTION : " + DESCRIPTION.ToString() + "} ";
			empty = empty + "{ISACTIVE : " + ISACTIVE + "} ";
			empty = empty + "{DESCRIPTIONSTRING : " + DESCRIPTIONSTRING.ToString() + "} ";
			empty = empty + "{PLAYERONLY : " + PLAYERONLY + "} ";
			empty = empty + "{TARGETMIN : " + TARGETMIN + "} ";
			empty = empty + "{TARGETMAX : " + TARGETMAX + "} ";
			empty = empty + "{SECONDTARGETPARAMETER : " + SECONDTARGETPARAMETER.ToString() + "} ";
			empty = empty + "{SECONDTARGETMIN : " + SECONDTARGETMIN + "} ";
			empty = empty + "{SECONDTARGETMAX : " + SECONDTARGETMAX + "} ";
			empty = empty + "{GROUPTYPE : " + GROUPTYPE + "} ";
			empty = empty + "{LEVELUNLOCK : " + LEVELUNLOCK + "} ";
			empty = empty + "{DIFFICULTY : " + DIFFICULTY + "} ";
			return empty + "{REMEMBERCOMPLETION : " + REMEMBERCOMPLETION + "} ";
		}
	}
}
