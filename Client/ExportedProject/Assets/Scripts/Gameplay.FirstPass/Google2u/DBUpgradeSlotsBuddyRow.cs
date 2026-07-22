using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class DBUpgradeSlotsBuddyRow : IGoogle2uRow
	{
		public int TIER;

		public float HP;

		public float DAMAGE;

		public float EXPLODEDAMAGEMIN;

		public float EXPLODEDAMAGEMAX;

		public int BATCHSIZEMIN;

		public int BATCHSIZEMAX;

		public float SHOTFREQUENCYMIN;

		public float SHOTFREQUENCYMAX;

		public float REALSHOTPROBABILITY;

		public float BONUSHP;

		public float BONUSDAMAGE;

		public int Get_TIER
		{
			get
			{
				return TIER;
			}
			set
			{
				TIER = value;
			}
		}

		public float Get_HP
		{
			get
			{
				return HP;
			}
			set
			{
				HP = value;
			}
		}

		public float Get_DAMAGE
		{
			get
			{
				return DAMAGE;
			}
			set
			{
				DAMAGE = value;
			}
		}

		public float Get_EXPLODEDAMAGEMIN
		{
			get
			{
				return EXPLODEDAMAGEMIN;
			}
			set
			{
				EXPLODEDAMAGEMIN = value;
			}
		}

		public float Get_EXPLODEDAMAGEMAX
		{
			get
			{
				return EXPLODEDAMAGEMAX;
			}
			set
			{
				EXPLODEDAMAGEMAX = value;
			}
		}

		public int Get_BATCHSIZEMIN
		{
			get
			{
				return BATCHSIZEMIN;
			}
			set
			{
				BATCHSIZEMIN = value;
			}
		}

		public int Get_BATCHSIZEMAX
		{
			get
			{
				return BATCHSIZEMAX;
			}
			set
			{
				BATCHSIZEMAX = value;
			}
		}

		public float Get_SHOTFREQUENCYMIN
		{
			get
			{
				return SHOTFREQUENCYMIN;
			}
			set
			{
				SHOTFREQUENCYMIN = value;
			}
		}

		public float Get_SHOTFREQUENCYMAX
		{
			get
			{
				return SHOTFREQUENCYMAX;
			}
			set
			{
				SHOTFREQUENCYMAX = value;
			}
		}

		public float Get_REALSHOTPROBABILITY
		{
			get
			{
				return REALSHOTPROBABILITY;
			}
			set
			{
				REALSHOTPROBABILITY = value;
			}
		}

		public float Get_BONUSHP
		{
			get
			{
				return BONUSHP;
			}
			set
			{
				BONUSHP = value;
			}
		}

		public float Get_BONUSDAMAGE
		{
			get
			{
				return BONUSDAMAGE;
			}
			set
			{
				BONUSDAMAGE = value;
			}
		}

		public int Length => 12;

		public string this[int i] => GetStringDataByIndex(i);

		public DBUpgradeSlotsBuddyRow()
		{
		}

		public DBUpgradeSlotsBuddyRow(string _STRING, string _TIER, string _HP, string _DAMAGE, string _EXPLODEDAMAGEMIN, string _EXPLODEDAMAGEMAX, string _BATCHSIZEMIN, string _BATCHSIZEMAX, string _SHOTFREQUENCYMIN, string _SHOTFREQUENCYMAX, string _REALSHOTPROBABILITY, string _BONUSHP, string _BONUSDAMAGE)
		{
			if (int.TryParse(_TIER, out var result))
			{
				TIER = result;
			}
			else
			{
				Debug.LogError("Failed To Convert TIER string: " + _TIER + " to int");
			}
			if (float.TryParse(_HP, out var result2))
			{
				HP = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert HP string: " + _HP + " to float");
			}
			if (float.TryParse(_DAMAGE, out var result3))
			{
				DAMAGE = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert DAMAGE string: " + _DAMAGE + " to float");
			}
			if (float.TryParse(_EXPLODEDAMAGEMIN, out var result4))
			{
				EXPLODEDAMAGEMIN = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert EXPLODEDAMAGEMIN string: " + _EXPLODEDAMAGEMIN + " to float");
			}
			if (float.TryParse(_EXPLODEDAMAGEMAX, out var result5))
			{
				EXPLODEDAMAGEMAX = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert EXPLODEDAMAGEMAX string: " + _EXPLODEDAMAGEMAX + " to float");
			}
			if (int.TryParse(_BATCHSIZEMIN, out var result6))
			{
				BATCHSIZEMIN = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert BATCHSIZEMIN string: " + _BATCHSIZEMIN + " to int");
			}
			if (int.TryParse(_BATCHSIZEMAX, out var result7))
			{
				BATCHSIZEMAX = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert BATCHSIZEMAX string: " + _BATCHSIZEMAX + " to int");
			}
			if (float.TryParse(_SHOTFREQUENCYMIN, out var result8))
			{
				SHOTFREQUENCYMIN = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert SHOTFREQUENCYMIN string: " + _SHOTFREQUENCYMIN + " to float");
			}
			if (float.TryParse(_SHOTFREQUENCYMAX, out var result9))
			{
				SHOTFREQUENCYMAX = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert SHOTFREQUENCYMAX string: " + _SHOTFREQUENCYMAX + " to float");
			}
			if (float.TryParse(_REALSHOTPROBABILITY, out var result10))
			{
				REALSHOTPROBABILITY = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert REALSHOTPROBABILITY string: " + _REALSHOTPROBABILITY + " to float");
			}
			if (float.TryParse(_BONUSHP, out var result11))
			{
				BONUSHP = result11;
			}
			else
			{
				Debug.LogError("Failed To Convert BONUSHP string: " + _BONUSHP + " to float");
			}
			if (float.TryParse(_BONUSDAMAGE, out var result12))
			{
				BONUSDAMAGE = result12;
			}
			else
			{
				Debug.LogError("Failed To Convert BONUSDAMAGE string: " + _BONUSDAMAGE + " to float");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = TIER.ToString();
				break;
			case 1:
				result = HP.ToString();
				break;
			case 2:
				result = DAMAGE.ToString();
				break;
			case 3:
				result = EXPLODEDAMAGEMIN.ToString();
				break;
			case 4:
				result = EXPLODEDAMAGEMAX.ToString();
				break;
			case 5:
				result = BATCHSIZEMIN.ToString();
				break;
			case 6:
				result = BATCHSIZEMAX.ToString();
				break;
			case 7:
				result = SHOTFREQUENCYMIN.ToString();
				break;
			case 8:
				result = SHOTFREQUENCYMAX.ToString();
				break;
			case 9:
				result = REALSHOTPROBABILITY.ToString();
				break;
			case 10:
				result = BONUSHP.ToString();
				break;
			case 11:
				result = BONUSDAMAGE.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "TIER":
				result = TIER.ToString();
				break;
			case "HP":
				result = HP.ToString();
				break;
			case "DAMAGE":
				result = DAMAGE.ToString();
				break;
			case "EXPLODEDAMAGEMIN":
				result = EXPLODEDAMAGEMIN.ToString();
				break;
			case "EXPLODEDAMAGEMAX":
				result = EXPLODEDAMAGEMAX.ToString();
				break;
			case "BATCHSIZEMIN":
				result = BATCHSIZEMIN.ToString();
				break;
			case "BATCHSIZEMAX":
				result = BATCHSIZEMAX.ToString();
				break;
			case "SHOTFREQUENCYMIN":
				result = SHOTFREQUENCYMIN.ToString();
				break;
			case "SHOTFREQUENCYMAX":
				result = SHOTFREQUENCYMAX.ToString();
				break;
			case "REALSHOTPROBABILITY":
				result = REALSHOTPROBABILITY.ToString();
				break;
			case "BONUSHP":
				result = BONUSHP.ToString();
				break;
			case "BONUSDAMAGE":
				result = BONUSDAMAGE.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{TIER : " + TIER + "} ";
			empty = empty + "{HP : " + HP + "} ";
			empty = empty + "{DAMAGE : " + DAMAGE + "} ";
			empty = empty + "{EXPLODEDAMAGEMIN : " + EXPLODEDAMAGEMIN + "} ";
			empty = empty + "{EXPLODEDAMAGEMAX : " + EXPLODEDAMAGEMAX + "} ";
			empty = empty + "{BATCHSIZEMIN : " + BATCHSIZEMIN + "} ";
			empty = empty + "{BATCHSIZEMAX : " + BATCHSIZEMAX + "} ";
			empty = empty + "{SHOTFREQUENCYMIN : " + SHOTFREQUENCYMIN + "} ";
			empty = empty + "{SHOTFREQUENCYMAX : " + SHOTFREQUENCYMAX + "} ";
			empty = empty + "{REALSHOTPROBABILITY : " + REALSHOTPROBABILITY + "} ";
			empty = empty + "{BONUSHP : " + BONUSHP + "} ";
			return empty + "{BONUSDAMAGE : " + BONUSDAMAGE + "} ";
		}
	}
}
