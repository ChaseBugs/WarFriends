using Google2u;

public class WinStreakManager : DatabaseSerializedObjectGeneric<WinStreakManager.WinStreak>
{
	public class WinStreak
	{
		public int WinCount;

		public int TimeStamp;

		public bool isInfinite
		{
			get
			{
				return TimeStamp - Singleton<BeanstalkServerManager>.instance.currentTimestamp > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakInterval).FLOATVALUE;
			}
		}

		public int deadline
		{
			get
			{
				return TimeStamp + (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakInterval).FLOATVALUE;
			}
		}

		public int winstreakNumber
		{
			get
			{
				return isActive ? WinCount : 0;
			}
		}

		public bool isActive
		{
			get
			{
				return WinCount > 0 && (deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp || isInfinite);
			}
		}

		public WinStreak()
		{
			WinCount = 0;
			TimeStamp = 0;
		}

		public WinStreak(int ts, int wc)
		{
			WinCount = wc;
			TimeStamp = ts;
		}
	}
}
