using UnityEngine.Scripting;

public class WinStreakManager : DatabaseSerializedObjectGeneric<WinStreakManager.WinStreak>
{
	[Preserve]
	public class WinStreak
	{
		public int WinCount;

		public int TimeStamp;

		public bool isInfinite => false;

		public int deadline => 0;

		public int winstreakNumber => 0;

		public bool isActive => false;

		public WinStreak()
		{
		}

		public WinStreak(int ts, int wc)
		{
		}
	}
}
