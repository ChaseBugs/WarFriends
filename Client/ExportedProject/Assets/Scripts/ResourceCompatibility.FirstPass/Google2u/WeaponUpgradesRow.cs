using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class WeaponUpgradesRow : IGoogle2uRow
	{
		public string NAME;

		public int UNLOCKLEVEL;

		public int CANBEBOUGHT;

		public ObscuredInt PRICE;

		public ObscuredInt PRICEGOLD;

		public int CLIENTID;

		public ObscuredFloat RATEOFFIRE;

		public ObscuredFloat CRITICAL;

		public int BURSTSIZE;

		public float BURSTLOCKTIME;

		public ObscuredFloat ACCURACY;

		public int DELIVERTIME;

		public string PURCHASABLE;

		public int WEAPONCATEGORY;

		public ObscuredFloat SPEED;

		public ObscuredFloat DAMAGETOPLAYER;

		public ObscuredFloat DAMAGETOPLAYEROVERTIME;

		public ObscuredFloat DAMAGETOPLAYERBEHINDSHIELD;

		public ObscuredFloat DAMAGETOSHIELD;

		public bool ISRENTABLE;

		public int GRADE;

		public int DISMANTLEMATERIALS;

		public ObscuredFloat DISMANTLEMATERIALSUPGRADEBONUS;

		public float MINDPS;

		public float MAXDPS;

		public string Get_NAME
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Get_UNLOCKLEVEL
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_CANBEBOUGHT
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ObscuredInt Get_PRICE
		{
			get
			{
				return default(ObscuredInt);
			}
			set
			{
			}
		}

		public ObscuredInt Get_PRICEGOLD
		{
			get
			{
				return default(ObscuredInt);
			}
			set
			{
			}
		}

		public int Get_CLIENTID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_RATEOFFIRE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_CRITICAL
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public int Get_BURSTSIZE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Get_BURSTLOCKTIME
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_ACCURACY
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public int Get_DELIVERTIME
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string Get_PURCHASABLE
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Get_WEAPONCATEGORY
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_SPEED
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DAMAGETOPLAYER
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DAMAGETOPLAYEROVERTIME
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DAMAGETOPLAYERBEHINDSHIELD
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DAMAGETOSHIELD
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public bool Get_ISRENTABLE
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int Get_GRADE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_DISMANTLEMATERIALS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ObscuredFloat Get_DISMANTLEMATERIALSUPGRADEBONUS
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public float Get_MINDPS
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Get_MAXDPS
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

		public WeaponUpgradesRow()
		{
		}

		public WeaponUpgradesRow(string _ID, string _NAME, string _UNLOCKLEVEL, string _CANBEBOUGHT, string _PRICE, string _PRICEGOLD, string _CLIENTID, string _RATEOFFIRE, string _CRITICAL, string _BURSTSIZE, string _BURSTLOCKTIME, string _ACCURACY, string _DELIVERTIME, string _PURCHASABLE, string _WEAPONCATEGORY, string _SPEED, string _DAMAGETOPLAYER, string _DAMAGETOPLAYEROVERTIME, string _DAMAGETOPLAYERBEHINDSHIELD, string _DAMAGETOSHIELD, string _ISRENTABLE, string _GRADE, string _DISMANTLEMATERIALS, string _DISMANTLEMATERIALSUPGRADEBONUS, string _MINDPS, string _MAXDPS)
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
