using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class LMG_MinigunRow : IGoogle2uRow
	{
		public ObscuredFloat HEATTIME;

		public ObscuredInt AMMO;

		public ObscuredFloat DAMAGE;

		public ObscuredInt NEXTUPGRADEPRICE;

		public int NEXTUPGRADEPRICEGOLD;

		public ObscuredFloat DELIVERYTIME;

		public float DPS;

		public float ATTACK;

		public ObscuredFloat Get_HEATTIME
		{
			get
			{
				return HEATTIME;
			}
			set
			{
				HEATTIME = value;
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

		public int Length => 8;

		public string this[int i] => GetStringDataByIndex(i);

		public LMG_MinigunRow()
		{
		}

		public LMG_MinigunRow(string _GOOGLEFU_ID, string _HEATTIME, string _AMMO, string _DAMAGE, string _NEXTUPGRADEPRICE, string _NEXTUPGRADEPRICEGOLD, string _DELIVERYTIME, string _DPS, string _ATTACK)
		{
			if (float.TryParse(_HEATTIME, out var result))
			{
				HEATTIME = result;
			}
			else
			{
				Debug.LogError("Failed To Convert HEATTIME string: " + _HEATTIME + " to float");
			}
			if (int.TryParse(_AMMO, out var result2))
			{
				AMMO = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert AMMO string: " + _AMMO + " to float");
			}
			if (float.TryParse(_DAMAGE, out var result3))
			{
				DAMAGE = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert DAMAGE string: " + _DAMAGE + " to float");
			}
			if (int.TryParse(_NEXTUPGRADEPRICE, out var result4))
			{
				NEXTUPGRADEPRICE = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert NEXTUPGRADEPRICE string: " + _NEXTUPGRADEPRICE + " to float");
			}
			if (int.TryParse(_NEXTUPGRADEPRICEGOLD, out var result5))
			{
				NEXTUPGRADEPRICEGOLD = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert NEXTUPGRADEPRICEGOLD string: " + _NEXTUPGRADEPRICEGOLD + " to int");
			}
			if (float.TryParse(_DELIVERYTIME, out var result6))
			{
				DELIVERYTIME = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert DELIVERYTIME string: " + _DELIVERYTIME + " to float");
			}
			if (float.TryParse(_DPS, out var result7))
			{
				DPS = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert DPS string: " + _DPS + " to float");
			}
			if (float.TryParse(_ATTACK, out var result8))
			{
				ATTACK = result8;
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
				result = HEATTIME.ToString();
				break;
			case 1:
				result = AMMO.ToString();
				break;
			case 2:
				result = DAMAGE.ToString();
				break;
			case 3:
				result = NEXTUPGRADEPRICE.ToString();
				break;
			case 4:
				result = NEXTUPGRADEPRICEGOLD.ToString();
				break;
			case 5:
				result = DELIVERYTIME.ToString();
				break;
			case 6:
				result = DPS.ToString();
				break;
			case 7:
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
			case "HEATTIME":
				result = HEATTIME.ToString();
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
			empty = empty + "{HEATTIME : " + HEATTIME.ToString() + "} ";
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
