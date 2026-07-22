using System;

namespace Google2u
{
	[Serializable]
	public class SuperSquadQualPointsRow : IGoogle2uRow
	{
		public int QUALIFICATIONPOINTS;

		public int POSITION;

		public int Get_QUALIFICATIONPOINTS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Get_POSITION
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

		public SuperSquadQualPointsRow()
		{
		}

		public SuperSquadQualPointsRow(string _ID, string _QUALIFICATIONPOINTS, string _POSITION)
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
