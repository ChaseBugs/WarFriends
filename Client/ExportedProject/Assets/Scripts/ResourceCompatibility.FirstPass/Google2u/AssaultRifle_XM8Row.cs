using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class AssaultRifle_XM8Row : IGoogle2uRow
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
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredInt Get_CLIPSIZE
		{
			get
			{
				return default(ObscuredInt);
			}
			set
			{
			}
		}

		public ObscuredInt Get_AMMO
		{
			get
			{
				return default(ObscuredInt);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DAMAGE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredInt Get_NEXTUPGRADEPRICE
		{
			get
			{
				return default(ObscuredInt);
			}
			set
			{
			}
		}

		public int Get_NEXTUPGRADEPRICEGOLD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DELIVERYTIME
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public float Get_DPS
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Get_ATTACK
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public AssaultRifle_XM8Row()
		{
		}

		public AssaultRifle_XM8Row(string _GOOGLEFU_ID, string _RELOADTIME, string _CLIPSIZE, string _AMMO, string _DAMAGE, string _NEXTUPGRADEPRICE, string _NEXTUPGRADEPRICEGOLD, string _DELIVERYTIME, string _DPS, string _ATTACK)
		{
		}

		public string GetStringDataByIndex(int index)
		{
			return null;
		}

		public string GetStringData(string colID)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
