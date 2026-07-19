using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class LMG_PKMachinegunEliteRow : IGoogle2uRow
	{
		public ObscuredFloat RELOADTIME;

		public ObscuredInt CLIPSIZE;

		public ObscuredInt AMMO;

		public ObscuredFloat DAMAGE;

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

		public LMG_PKMachinegunEliteRow()
		{
		}

		public LMG_PKMachinegunEliteRow(string _GOOGLEFU_ID, string _RELOADTIME, string _CLIPSIZE, string _AMMO, string _DAMAGE, string _NEXTUPGRADEPRICE, string _NEXTUPGRADEPRICEGOLD, string _DELIVERYTIME, string _DPS, string _ATTACK)
		{
			float result;
			if (float.TryParse(_RELOADTIME, out result))
			{
				RELOADTIME = result;
			}
			else
			{
				Debug.LogError("Failed To Convert RELOADTIME string: " + _RELOADTIME + " to float");
			}
			int result2;
			if (int.TryParse(_CLIPSIZE, out result2))
			{
				CLIPSIZE = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert CLIPSIZE string: " + _CLIPSIZE + " to float");
			}
			int result3;
			if (int.TryParse(_AMMO, out result3))
			{
				AMMO = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert AMMO string: " + _AMMO + " to float");
			}
			float result4;
			if (float.TryParse(_DAMAGE, out result4))
			{
				DAMAGE = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert DAMAGE string: " + _DAMAGE + " to float");
			}
			int result5;
			if (int.TryParse(_NEXTUPGRADEPRICE, out result5))
			{
				NEXTUPGRADEPRICE = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert NEXTUPGRADEPRICE string: " + _NEXTUPGRADEPRICE + " to float");
			}
			int result6;
			if (int.TryParse(_NEXTUPGRADEPRICEGOLD, out result6))
			{
				NEXTUPGRADEPRICEGOLD = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert NEXTUPGRADEPRICEGOLD string: " + _NEXTUPGRADEPRICEGOLD + " to int");
			}
			float result7;
			if (float.TryParse(_DELIVERYTIME, out result7))
			{
				DELIVERYTIME = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert DELIVERYTIME string: " + _DELIVERYTIME + " to float");
			}
			float result8;
			if (float.TryParse(_DPS, out result8))
			{
				DPS = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert DPS string: " + _DPS + " to float");
			}
			float result9;
			if (float.TryParse(_ATTACK, out result9))
			{
				ATTACK = result9;
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
				result = DAMAGE.ToString();
				break;
			case 4:
				result = NEXTUPGRADEPRICE.ToString();
				break;
			case 5:
				result = NEXTUPGRADEPRICEGOLD.ToString();
				break;
			case 6:
				result = DELIVERYTIME.ToString();
				break;
			case 7:
				result = DPS.ToString();
				break;
			case 8:
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
			case "DAMAGE":
				result = DAMAGE.ToString();
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
			empty = empty + "{DAMAGE : " + DAMAGE.ToString() + "} ";
			empty = empty + "{NEXTUPGRADEPRICE : " + NEXTUPGRADEPRICE.ToString() + "} ";
			empty = empty + "{NEXTUPGRADEPRICEGOLD : " + NEXTUPGRADEPRICEGOLD + "} ";
			empty = empty + "{DELIVERYTIME : " + DELIVERYTIME.ToString() + "} ";
			empty = empty + "{DPS : " + DPS + "} ";
			return empty + "{ATTACK : " + ATTACK + "} ";
		}
	}
}
