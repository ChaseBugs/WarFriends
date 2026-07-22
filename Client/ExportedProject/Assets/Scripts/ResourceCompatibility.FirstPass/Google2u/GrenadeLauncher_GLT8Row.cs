using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class GrenadeLauncher_GLT8Row : IGoogle2uRow
	{
		public ObscuredFloat RELOADTIME;

		public ObscuredInt AMMO;

		public ObscuredFloat EXPLODEDAMAGE;

		public ObscuredFloat MINDAMAGE;

		public ObscuredInt NEXTUPGRADEPRICE;

		public int NEXTUPGRADEPRICEGOLD;

		public ObscuredFloat DELIVERYTIME;

		public float DPS;

		public float DEADRADIUS;

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

		public ObscuredFloat Get_EXPLODEDAMAGE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_MINDAMAGE
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

		public float Get_DEADRADIUS
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

		public GrenadeLauncher_GLT8Row()
		{
		}

		public GrenadeLauncher_GLT8Row(string _GOOGLEFU_ID, string _RELOADTIME, string _AMMO, string _EXPLODEDAMAGE, string _MINDAMAGE, string _NEXTUPGRADEPRICE, string _NEXTUPGRADEPRICEGOLD, string _DELIVERYTIME, string _DPS, string _DEADRADIUS, string _ATTACK)
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
