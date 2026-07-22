using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class Shotgun_StrikerRow : IGoogle2uRow
	{
		public ObscuredFloat RELOADTIME;

		public ObscuredInt CLIPSIZE;

		public ObscuredInt AMMO;

		public ObscuredFloat MINDAMAGE;

		public ObscuredFloat MAXDAMAGE;

		public ObscuredInt NEXTUPGRADEPRICE;

		public int NEXTUPGRADEPRICEGOLD;

		public ObscuredFloat DELIVERYTIME;

		public float DPS;

		public float ATTACK;

		public ObscuredFloat Get_RELOADTIME
		{
			get
			{
				return RELOADTIME;
			}
			set
			{
				RELOADTIME = value;
			}
		}

		public ObscuredInt Get_CLIPSIZE
		{
			get
			{
				return CLIPSIZE;
			}
			set
			{
				CLIPSIZE = value;
			}
		}

		public ObscuredInt Get_AMMO
		{
			get
			{
				return AMMO;
			}
			set
			{
				AMMO = value;
			}
		}

		public ObscuredFloat Get_MINDAMAGE
		{
			get
			{
				return MINDAMAGE;
			}
			set
			{
				MINDAMAGE = value;
			}
		}

		public ObscuredFloat Get_MAXDAMAGE
		{
			get
			{
				return MAXDAMAGE;
			}
			set
			{
				MAXDAMAGE = value;
			}
		}

		public ObscuredInt Get_NEXTUPGRADEPRICE
		{
			get
			{
				return NEXTUPGRADEPRICE;
			}
			set
			{
				NEXTUPGRADEPRICE = value;
			}
		}

		public int Get_NEXTUPGRADEPRICEGOLD
		{
			get
			{
				return NEXTUPGRADEPRICEGOLD;
			}
			set
			{
				NEXTUPGRADEPRICEGOLD = value;
			}
		}

		public ObscuredFloat Get_DELIVERYTIME
		{
			get
			{
				return DELIVERYTIME;
			}
			set
			{
				DELIVERYTIME = value;
			}
		}

		public float Get_DPS
		{
			get
			{
				return DPS;
			}
			set
			{
				DPS = value;
			}
		}

		public float Get_ATTACK
		{
			get
			{
				return ATTACK;
			}
			set
			{
				ATTACK = value;
			}
		}

		public int Length => 10;

		public string this[int i] => GetStringDataByIndex(i);

		public Shotgun_StrikerRow()
		{
		}

		public Shotgun_StrikerRow(string _GOOGLEFU_ID, string _RELOADTIME, string _CLIPSIZE, string _AMMO, string _MINDAMAGE, string _MAXDAMAGE, string _NEXTUPGRADEPRICE, string _NEXTUPGRADEPRICEGOLD, string _DELIVERYTIME, string _DPS, string _ATTACK)
		{
			if (float.TryParse(_RELOADTIME, out var result))
			{
				RELOADTIME = result;
			}
			else
			{
				Debug.LogError("Failed To Convert RELOADTIME string: " + _RELOADTIME + " to float");
			}
			if (int.TryParse(_CLIPSIZE, out var result2))
			{
				CLIPSIZE = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert CLIPSIZE string: " + _CLIPSIZE + " to float");
			}
			if (int.TryParse(_AMMO, out var result3))
			{
				AMMO = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert AMMO string: " + _AMMO + " to float");
			}
			if (float.TryParse(_MINDAMAGE, out var result4))
			{
				MINDAMAGE = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert MINDAMAGE string: " + _MINDAMAGE + " to float");
			}
			if (float.TryParse(_MAXDAMAGE, out var result5))
			{
				MAXDAMAGE = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert MAXDAMAGE string: " + _MAXDAMAGE + " to float");
			}
			if (int.TryParse(_NEXTUPGRADEPRICE, out var result6))
			{
				NEXTUPGRADEPRICE = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert NEXTUPGRADEPRICE string: " + _NEXTUPGRADEPRICE + " to float");
			}
			if (int.TryParse(_NEXTUPGRADEPRICEGOLD, out var result7))
			{
				NEXTUPGRADEPRICEGOLD = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert NEXTUPGRADEPRICEGOLD string: " + _NEXTUPGRADEPRICEGOLD + " to int");
			}
			if (float.TryParse(_DELIVERYTIME, out var result8))
			{
				DELIVERYTIME = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert DELIVERYTIME string: " + _DELIVERYTIME + " to float");
			}
			if (float.TryParse(_DPS, out var result9))
			{
				DPS = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert DPS string: " + _DPS + " to float");
			}
			if (float.TryParse(_ATTACK, out var result10))
			{
				ATTACK = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert ATTACK string: " + _ATTACK + " to float");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = RELOADTIME.ToString();
				break;
			case 1:
				result = CLIPSIZE.ToString();
				break;
			case 2:
				result = AMMO.ToString();
				break;
			case 3:
				result = MINDAMAGE.ToString();
				break;
			case 4:
				result = MAXDAMAGE.ToString();
				break;
			case 5:
				result = NEXTUPGRADEPRICE.ToString();
				break;
			case 6:
				result = NEXTUPGRADEPRICEGOLD.ToString();
				break;
			case 7:
				result = DELIVERYTIME.ToString();
				break;
			case 8:
				result = DPS.ToString();
				break;
			case 9:
				result = ATTACK.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "RELOADTIME":
				result = RELOADTIME.ToString();
				break;
			case "CLIPSIZE":
				result = CLIPSIZE.ToString();
				break;
			case "AMMO":
				result = AMMO.ToString();
				break;
			case "MINDAMAGE":
				result = MINDAMAGE.ToString();
				break;
			case "MAXDAMAGE":
				result = MAXDAMAGE.ToString();
				break;
			case "NEXTUPGRADEPRICE":
				result = NEXTUPGRADEPRICE.ToString();
				break;
			case "NEXTUPGRADEPRICEGOLD":
				result = NEXTUPGRADEPRICEGOLD.ToString();
				break;
			case "DELIVERYTIME":
				result = DELIVERYTIME.ToString();
				break;
			case "DPS":
				result = DPS.ToString();
				break;
			case "ATTACK":
				result = ATTACK.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{RELOADTIME : " + RELOADTIME.ToString() + "} ";
			empty = empty + "{CLIPSIZE : " + CLIPSIZE.ToString() + "} ";
			empty = empty + "{AMMO : " + AMMO.ToString() + "} ";
			empty = empty + "{MINDAMAGE : " + MINDAMAGE.ToString() + "} ";
			empty = empty + "{MAXDAMAGE : " + MAXDAMAGE.ToString() + "} ";
			empty = empty + "{NEXTUPGRADEPRICE : " + NEXTUPGRADEPRICE.ToString() + "} ";
			empty = empty + "{NEXTUPGRADEPRICEGOLD : " + NEXTUPGRADEPRICEGOLD + "} ";
			empty = empty + "{DELIVERYTIME : " + DELIVERYTIME.ToString() + "} ";
			empty = empty + "{DPS : " + DPS + "} ";
			return empty + "{ATTACK : " + ATTACK + "} ";
		}
	}
}
