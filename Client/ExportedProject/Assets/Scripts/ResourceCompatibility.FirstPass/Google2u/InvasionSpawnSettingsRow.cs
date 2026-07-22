using System;

namespace Google2u
{
	[Serializable]
	public class InvasionSpawnSettingsRow : IGoogle2uRow
	{
		public int MAXONFIELD;

		public float COOLDOWN;

		public float FIRSTSPAWNDELAY;

		public int Get_MAXONFIELD
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Get_COOLDOWN
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Get_FIRSTSPAWNDELAY
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

		public InvasionSpawnSettingsRow()
		{
		}

		public InvasionSpawnSettingsRow(string _UNITNAME, string _MAXONFIELD, string _COOLDOWN, string _FIRSTSPAWNDELAY)
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
