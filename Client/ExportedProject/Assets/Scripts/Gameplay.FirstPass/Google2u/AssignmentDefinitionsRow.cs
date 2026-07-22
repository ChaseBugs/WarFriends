using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class AssignmentDefinitionsRow : IGoogle2uRow
	{
		public string DESCRIPTION;

		public string DESCRIPTIONSTRING;

		public bool PLAYERONLY;

		public string TARGET;

		public int TARGETMIN;

		public int TARGETMAX;

		public string SECONDTARGET;

		public string SECONDTARGETPARAMETER;

		public int SECONDTARGETMIN;

		public int SECONDTARGETMAX;

		public int GROUPTYPE;

		public string REWARD;

		public int REWARDWPMIN;

		public int REWARDWBMAX;

		public int REWARDGOLDMIN;

		public int REWARDGOLDMAX;

		public int GENERICMISSIONSTEPVALUE;

		public int SECONDGENERICMISSIONSTEPVALUE;

		public int GENERICMISSIONSTEPREWARD;

		public int GENERICMISSIONSTEPREWARDGOLD;

		public bool REMEMBERCOMPLETION;

		public string STRINGSTATUS;

		public string TYPE;

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

		public string Get_TARGET
		{
			get
			{
				return TARGET;
			}
			set
			{
				TARGET = value;
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

		public string Get_SECONDTARGET
		{
			get
			{
				return SECONDTARGET;
			}
			set
			{
				SECONDTARGET = value;
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

		public string Get_REWARD
		{
			get
			{
				return REWARD;
			}
			set
			{
				REWARD = value;
			}
		}

		public int Get_REWARDWPMIN
		{
			get
			{
				return REWARDWPMIN;
			}
			set
			{
				REWARDWPMIN = value;
			}
		}

		public int Get_REWARDWBMAX
		{
			get
			{
				return REWARDWBMAX;
			}
			set
			{
				REWARDWBMAX = value;
			}
		}

		public int Get_REWARDGOLDMIN
		{
			get
			{
				return REWARDGOLDMIN;
			}
			set
			{
				REWARDGOLDMIN = value;
			}
		}

		public int Get_REWARDGOLDMAX
		{
			get
			{
				return REWARDGOLDMAX;
			}
			set
			{
				REWARDGOLDMAX = value;
			}
		}

		public int Get_GENERICMISSIONSTEPVALUE
		{
			get
			{
				return GENERICMISSIONSTEPVALUE;
			}
			set
			{
				GENERICMISSIONSTEPVALUE = value;
			}
		}

		public int Get_SECONDGENERICMISSIONSTEPVALUE
		{
			get
			{
				return SECONDGENERICMISSIONSTEPVALUE;
			}
			set
			{
				SECONDGENERICMISSIONSTEPVALUE = value;
			}
		}

		public int Get_GENERICMISSIONSTEPREWARD
		{
			get
			{
				return GENERICMISSIONSTEPREWARD;
			}
			set
			{
				GENERICMISSIONSTEPREWARD = value;
			}
		}

		public int Get_GENERICMISSIONSTEPREWARDGOLD
		{
			get
			{
				return GENERICMISSIONSTEPREWARDGOLD;
			}
			set
			{
				GENERICMISSIONSTEPREWARDGOLD = value;
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

		public string Get_STRINGSTATUS
		{
			get
			{
				return STRINGSTATUS;
			}
			set
			{
				STRINGSTATUS = value;
			}
		}

		public string Get_TYPE
		{
			get
			{
				return TYPE;
			}
			set
			{
				TYPE = value;
			}
		}

		public int Length => 23;

		public string this[int i] => GetStringDataByIndex(i);

		public AssignmentDefinitionsRow()
		{
		}

		public AssignmentDefinitionsRow(string _ID, string _DESCRIPTION, string _DESCRIPTIONSTRING, string _PLAYERONLY, string _TARGET, string _TARGETMIN, string _TARGETMAX, string _SECONDTARGET, string _SECONDTARGETPARAMETER, string _SECONDTARGETMIN, string _SECONDTARGETMAX, string _GROUPTYPE, string _REWARD, string _REWARDWPMIN, string _REWARDWBMAX, string _REWARDGOLDMIN, string _REWARDGOLDMAX, string _GENERICMISSIONSTEPVALUE, string _SECONDGENERICMISSIONSTEPVALUE, string _GENERICMISSIONSTEPREWARD, string _GENERICMISSIONSTEPREWARDGOLD, string _REMEMBERCOMPLETION, string _STRINGSTATUS, string _TYPE)
		{
			DESCRIPTION = _DESCRIPTION.Trim();
			DESCRIPTIONSTRING = _DESCRIPTIONSTRING.Trim();
			if (bool.TryParse(_PLAYERONLY, out var result))
			{
				PLAYERONLY = result;
			}
			else
			{
				Debug.LogError("Failed To Convert PLAYERONLY string: " + _PLAYERONLY + " to bool");
			}
			TARGET = _TARGET.Trim();
			if (int.TryParse(_TARGETMIN, out var result2))
			{
				TARGETMIN = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert TARGETMIN string: " + _TARGETMIN + " to int");
			}
			if (int.TryParse(_TARGETMAX, out var result3))
			{
				TARGETMAX = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert TARGETMAX string: " + _TARGETMAX + " to int");
			}
			SECONDTARGET = _SECONDTARGET.Trim();
			SECONDTARGETPARAMETER = _SECONDTARGETPARAMETER.Trim();
			if (int.TryParse(_SECONDTARGETMIN, out var result4))
			{
				SECONDTARGETMIN = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert SECONDTARGETMIN string: " + _SECONDTARGETMIN + " to int");
			}
			if (int.TryParse(_SECONDTARGETMAX, out var result5))
			{
				SECONDTARGETMAX = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert SECONDTARGETMAX string: " + _SECONDTARGETMAX + " to int");
			}
			if (int.TryParse(_GROUPTYPE, out var result6))
			{
				GROUPTYPE = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert GROUPTYPE string: " + _GROUPTYPE + " to int");
			}
			REWARD = _REWARD.Trim();
			if (int.TryParse(_REWARDWPMIN, out var result7))
			{
				REWARDWPMIN = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDWPMIN string: " + _REWARDWPMIN + " to int");
			}
			if (int.TryParse(_REWARDWBMAX, out var result8))
			{
				REWARDWBMAX = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDWBMAX string: " + _REWARDWBMAX + " to int");
			}
			if (int.TryParse(_REWARDGOLDMIN, out var result9))
			{
				REWARDGOLDMIN = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDGOLDMIN string: " + _REWARDGOLDMIN + " to int");
			}
			if (int.TryParse(_REWARDGOLDMAX, out var result10))
			{
				REWARDGOLDMAX = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert REWARDGOLDMAX string: " + _REWARDGOLDMAX + " to int");
			}
			if (int.TryParse(_GENERICMISSIONSTEPVALUE, out var result11))
			{
				GENERICMISSIONSTEPVALUE = result11;
			}
			else
			{
				Debug.LogError("Failed To Convert GENERICMISSIONSTEPVALUE string: " + _GENERICMISSIONSTEPVALUE + " to int");
			}
			if (int.TryParse(_SECONDGENERICMISSIONSTEPVALUE, out var result12))
			{
				SECONDGENERICMISSIONSTEPVALUE = result12;
			}
			else
			{
				Debug.LogError("Failed To Convert SECONDGENERICMISSIONSTEPVALUE string: " + _SECONDGENERICMISSIONSTEPVALUE + " to int");
			}
			if (int.TryParse(_GENERICMISSIONSTEPREWARD, out var result13))
			{
				GENERICMISSIONSTEPREWARD = result13;
			}
			else
			{
				Debug.LogError("Failed To Convert GENERICMISSIONSTEPREWARD string: " + _GENERICMISSIONSTEPREWARD + " to int");
			}
			if (int.TryParse(_GENERICMISSIONSTEPREWARDGOLD, out var result14))
			{
				GENERICMISSIONSTEPREWARDGOLD = result14;
			}
			else
			{
				Debug.LogError("Failed To Convert GENERICMISSIONSTEPREWARDGOLD string: " + _GENERICMISSIONSTEPREWARDGOLD + " to int");
			}
			if (bool.TryParse(_REMEMBERCOMPLETION, out var result15))
			{
				REMEMBERCOMPLETION = result15;
			}
			else
			{
				Debug.LogError("Failed To Convert REMEMBERCOMPLETION string: " + _REMEMBERCOMPLETION + " to bool");
			}
			STRINGSTATUS = _STRINGSTATUS.Trim();
			TYPE = _TYPE.Trim();
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
				result = DESCRIPTIONSTRING.ToString();
				break;
			case 2:
				result = PLAYERONLY.ToString();
				break;
			case 3:
				result = TARGET.ToString();
				break;
			case 4:
				result = TARGETMIN.ToString();
				break;
			case 5:
				result = TARGETMAX.ToString();
				break;
			case 6:
				result = SECONDTARGET.ToString();
				break;
			case 7:
				result = SECONDTARGETPARAMETER.ToString();
				break;
			case 8:
				result = SECONDTARGETMIN.ToString();
				break;
			case 9:
				result = SECONDTARGETMAX.ToString();
				break;
			case 10:
				result = GROUPTYPE.ToString();
				break;
			case 11:
				result = REWARD.ToString();
				break;
			case 12:
				result = REWARDWPMIN.ToString();
				break;
			case 13:
				result = REWARDWBMAX.ToString();
				break;
			case 14:
				result = REWARDGOLDMIN.ToString();
				break;
			case 15:
				result = REWARDGOLDMAX.ToString();
				break;
			case 16:
				result = GENERICMISSIONSTEPVALUE.ToString();
				break;
			case 17:
				result = SECONDGENERICMISSIONSTEPVALUE.ToString();
				break;
			case 18:
				result = GENERICMISSIONSTEPREWARD.ToString();
				break;
			case 19:
				result = GENERICMISSIONSTEPREWARDGOLD.ToString();
				break;
			case 20:
				result = REMEMBERCOMPLETION.ToString();
				break;
			case 21:
				result = STRINGSTATUS.ToString();
				break;
			case 22:
				result = TYPE.ToString();
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
			case "DESCRIPTIONSTRING":
				result = DESCRIPTIONSTRING.ToString();
				break;
			case "PLAYERONLY":
				result = PLAYERONLY.ToString();
				break;
			case "TARGET":
				result = TARGET.ToString();
				break;
			case "TARGETMIN":
				result = TARGETMIN.ToString();
				break;
			case "TARGETMAX":
				result = TARGETMAX.ToString();
				break;
			case "SECONDTARGET":
				result = SECONDTARGET.ToString();
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
			case "REWARD":
				result = REWARD.ToString();
				break;
			case "REWARDWPMIN":
				result = REWARDWPMIN.ToString();
				break;
			case "REWARDWBMAX":
				result = REWARDWBMAX.ToString();
				break;
			case "REWARDGOLDMIN":
				result = REWARDGOLDMIN.ToString();
				break;
			case "REWARDGOLDMAX":
				result = REWARDGOLDMAX.ToString();
				break;
			case "GENERICMISSIONSTEPVALUE":
				result = GENERICMISSIONSTEPVALUE.ToString();
				break;
			case "SECONDGENERICMISSIONSTEPVALUE":
				result = SECONDGENERICMISSIONSTEPVALUE.ToString();
				break;
			case "GENERICMISSIONSTEPREWARD":
				result = GENERICMISSIONSTEPREWARD.ToString();
				break;
			case "GENERICMISSIONSTEPREWARDGOLD":
				result = GENERICMISSIONSTEPREWARDGOLD.ToString();
				break;
			case "REMEMBERCOMPLETION":
				result = REMEMBERCOMPLETION.ToString();
				break;
			case "STRINGSTATUS":
				result = STRINGSTATUS.ToString();
				break;
			case "TYPE":
				result = TYPE.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{DESCRIPTION : " + DESCRIPTION.ToString() + "} ";
			empty = empty + "{DESCRIPTIONSTRING : " + DESCRIPTIONSTRING.ToString() + "} ";
			empty = empty + "{PLAYERONLY : " + PLAYERONLY + "} ";
			empty = empty + "{TARGET : " + TARGET.ToString() + "} ";
			empty = empty + "{TARGETMIN : " + TARGETMIN + "} ";
			empty = empty + "{TARGETMAX : " + TARGETMAX + "} ";
			empty = empty + "{SECONDTARGET : " + SECONDTARGET.ToString() + "} ";
			empty = empty + "{SECONDTARGETPARAMETER : " + SECONDTARGETPARAMETER.ToString() + "} ";
			empty = empty + "{SECONDTARGETMIN : " + SECONDTARGETMIN + "} ";
			empty = empty + "{SECONDTARGETMAX : " + SECONDTARGETMAX + "} ";
			empty = empty + "{GROUPTYPE : " + GROUPTYPE + "} ";
			empty = empty + "{REWARD : " + REWARD.ToString() + "} ";
			empty = empty + "{REWARDWPMIN : " + REWARDWPMIN + "} ";
			empty = empty + "{REWARDWBMAX : " + REWARDWBMAX + "} ";
			empty = empty + "{REWARDGOLDMIN : " + REWARDGOLDMIN + "} ";
			empty = empty + "{REWARDGOLDMAX : " + REWARDGOLDMAX + "} ";
			empty = empty + "{GENERICMISSIONSTEPVALUE : " + GENERICMISSIONSTEPVALUE + "} ";
			empty = empty + "{SECONDGENERICMISSIONSTEPVALUE : " + SECONDGENERICMISSIONSTEPVALUE + "} ";
			empty = empty + "{GENERICMISSIONSTEPREWARD : " + GENERICMISSIONSTEPREWARD + "} ";
			empty = empty + "{GENERICMISSIONSTEPREWARDGOLD : " + GENERICMISSIONSTEPREWARDGOLD + "} ";
			empty = empty + "{REMEMBERCOMPLETION : " + REMEMBERCOMPLETION + "} ";
			empty = empty + "{STRINGSTATUS : " + STRINGSTATUS.ToString() + "} ";
			return empty + "{TYPE : " + TYPE.ToString() + "} ";
		}
	}
}
