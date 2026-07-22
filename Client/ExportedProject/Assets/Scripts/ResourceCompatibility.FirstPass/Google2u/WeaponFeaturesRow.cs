using System;
using CodeStage.AntiCheat.ObscuredTypes;

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

		public string WEAPONFEAT;

		public ObscuredFloat Get_MAGAZINESIZE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_RELOAD
		{
			get
			{
				return default(ObscuredFloat);
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

		public ObscuredFloat Get_BURSTSIZE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public ObscuredFloat Get_TOTALAMMO
		{
			get
			{
				return default(ObscuredFloat);
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

		public ObscuredFloat Get_SHOTVELOCITY
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public string Get_WEAPONFEAT
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public WeaponFeaturesRow()
		{
		}

		public WeaponFeaturesRow(string _WEAPON, string _MAGAZINESIZE, string _RELOAD, string _DAMAGE, string _CRITICAL, string _BURSTSIZE, string _TOTALAMMO, string _ACCURACY, string _RATEOFFIRE, string _SHOTVELOCITY, string _WEAPONFEAT)
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
