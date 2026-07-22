using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class WeaponFeaturesRow : IGoogle2uRow
	{
		public ObscuredFloat MAGAZINESIZE;

		public ObscuredFloat RELOAD;

		public ObscuredFloat DAMAGE;

		public ObscuredFloat CRITICAL;

		public ObscuredFloat BURSTSIZE;

		public ObscuredFloat TOTALAMMO;

		public ObscuredFloat ACCURACY;

		public ObscuredFloat RATEOFFIRE;

		public ObscuredFloat SHOTVELOCITY;

		public ObscuredFloat Get_MAGAZINESIZE
		{
			get
			{
				return MAGAZINESIZE;
			}
			set
			{
				MAGAZINESIZE = value;
			}
		}

		public ObscuredFloat Get_RELOAD
		{
			get
			{
				return RELOAD;
			}
			set
			{
				RELOAD = value;
			}
		}

		public ObscuredFloat Get_DAMAGE
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

		public ObscuredFloat Get_CRITICAL
		{
			get
			{
				return CRITICAL;
			}
			set
			{
				CRITICAL = value;
			}
		}

		public ObscuredFloat Get_BURSTSIZE
		{
			get
			{
				return BURSTSIZE;
			}
			set
			{
				BURSTSIZE = value;
			}
		}

		public ObscuredFloat Get_TOTALAMMO
		{
			get
			{
				return TOTALAMMO;
			}
			set
			{
				TOTALAMMO = value;
			}
		}

		public ObscuredFloat Get_ACCURACY
		{
			get
			{
				return ACCURACY;
			}
			set
			{
				ACCURACY = value;
			}
		}

		public ObscuredFloat Get_RATEOFFIRE
		{
			get
			{
				return RATEOFFIRE;
			}
			set
			{
				RATEOFFIRE = value;
			}
		}

		public ObscuredFloat Get_SHOTVELOCITY
		{
			get
			{
				return SHOTVELOCITY;
			}
			set
			{
				SHOTVELOCITY = value;
			}
		}

		public int Length => 9;

		public string this[int i] => GetStringDataByIndex(i);

		public WeaponFeaturesRow()
		{
		}

		public WeaponFeaturesRow(string _WEAPON, string _MAGAZINESIZE, string _RELOAD, string _DAMAGE, string _CRITICAL, string _BURSTSIZE, string _TOTALAMMO, string _ACCURACY, string _RATEOFFIRE, string _SHOTVELOCITY)
		{
			if (float.TryParse(_MAGAZINESIZE, out var result))
			{
				MAGAZINESIZE = result;
			}
			else
			{
				Debug.LogError("Failed To Convert MAGAZINESIZE string: " + _MAGAZINESIZE + " to float");
			}
			if (float.TryParse(_RELOAD, out var result2))
			{
				RELOAD = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert RELOAD string: " + _RELOAD + " to float");
			}
			if (float.TryParse(_DAMAGE, out var result3))
			{
				DAMAGE = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert DAMAGE string: " + _DAMAGE + " to float");
			}
			if (float.TryParse(_CRITICAL, out var result4))
			{
				CRITICAL = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert CRITICAL string: " + _CRITICAL + " to float");
			}
			if (float.TryParse(_BURSTSIZE, out var result5))
			{
				BURSTSIZE = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert BURSTSIZE string: " + _BURSTSIZE + " to float");
			}
			if (float.TryParse(_TOTALAMMO, out var result6))
			{
				TOTALAMMO = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert TOTALAMMO string: " + _TOTALAMMO + " to float");
			}
			if (float.TryParse(_ACCURACY, out var result7))
			{
				ACCURACY = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert ACCURACY string: " + _ACCURACY + " to float");
			}
			if (float.TryParse(_RATEOFFIRE, out var result8))
			{
				RATEOFFIRE = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert RATEOFFIRE string: " + _RATEOFFIRE + " to float");
			}
			if (float.TryParse(_SHOTVELOCITY, out var result9))
			{
				SHOTVELOCITY = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert SHOTVELOCITY string: " + _SHOTVELOCITY + " to float");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = MAGAZINESIZE.ToString();
				break;
			case 1:
				result = RELOAD.ToString();
				break;
			case 2:
				result = DAMAGE.ToString();
				break;
			case 3:
				result = CRITICAL.ToString();
				break;
			case 4:
				result = BURSTSIZE.ToString();
				break;
			case 5:
				result = TOTALAMMO.ToString();
				break;
			case 6:
				result = ACCURACY.ToString();
				break;
			case 7:
				result = RATEOFFIRE.ToString();
				break;
			case 8:
				result = SHOTVELOCITY.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "MAGAZINESIZE":
				result = MAGAZINESIZE.ToString();
				break;
			case "RELOAD":
				result = RELOAD.ToString();
				break;
			case "DAMAGE":
				result = DAMAGE.ToString();
				break;
			case "CRITICAL":
				result = CRITICAL.ToString();
				break;
			case "BURSTSIZE":
				result = BURSTSIZE.ToString();
				break;
			case "TOTALAMMO":
				result = TOTALAMMO.ToString();
				break;
			case "ACCURACY":
				result = ACCURACY.ToString();
				break;
			case "RATEOFFIRE":
				result = RATEOFFIRE.ToString();
				break;
			case "SHOTVELOCITY":
				result = SHOTVELOCITY.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{MAGAZINESIZE : " + MAGAZINESIZE.ToString() + "} ";
			empty = empty + "{RELOAD : " + RELOAD.ToString() + "} ";
			empty = empty + "{DAMAGE : " + DAMAGE.ToString() + "} ";
			empty = empty + "{CRITICAL : " + CRITICAL.ToString() + "} ";
			empty = empty + "{BURSTSIZE : " + BURSTSIZE.ToString() + "} ";
			empty = empty + "{TOTALAMMO : " + TOTALAMMO.ToString() + "} ";
			empty = empty + "{ACCURACY : " + ACCURACY.ToString() + "} ";
			empty = empty + "{RATEOFFIRE : " + RATEOFFIRE.ToString() + "} ";
			return empty + "{SHOTVELOCITY : " + SHOTVELOCITY.ToString() + "} ";
		}
	}
}
