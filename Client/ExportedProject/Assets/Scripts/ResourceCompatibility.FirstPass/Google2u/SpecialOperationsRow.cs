using System;

namespace Google2u
{
	[Serializable]
	public class SpecialOperationsRow : IGoogle2uRow
	{
		public string SERVER_ID;

		public int TYPE;

		public int FRIENDSTORECRUIT;

		public int DAYSUNTILNEXTOBJECTIVE;

		public int REWARD;

		public int RANKTOACHIEVE;

		public int FRIENDSRECRUITED;

		public string Get_SERVER_ID
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Get_TYPE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_FRIENDSTORECRUIT
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_DAYSUNTILNEXTOBJECTIVE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_REWARD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_RANKTOACHIEVE
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_FRIENDSRECRUITED
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public SpecialOperationsRow()
		{
		}

		public SpecialOperationsRow(string _ID, string _SERVER_ID, string _TYPE, string _FRIENDSTORECRUIT, string _DAYSUNTILNEXTOBJECTIVE, string _REWARD, string _RANKTOACHIEVE, string _FRIENDSRECRUITED)
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
