using Beebyte.Obfuscator;
using Google2u;

[Skip]
public class WinStreakManager : DatabaseSerializedObjectGeneric<WinStreakManager.WinStreak>
{
	[Skip]
	public class WinStreak
	{
		public int WinCount;

		public int TimeStamp;

		public int Deadline => TimeStamp + (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakInterval).FLOATVALUE;

		public int winstreakNumber => IsActive() ? WinCount : 0;

		public int remainingTime => Deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;

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

		internal bool IsActive()
		{
			return WinCount > 0 && Deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}
}
